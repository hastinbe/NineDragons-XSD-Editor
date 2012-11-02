//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using NineDragons_XSD_Editor.Data;
using NineDragons_XSD_Editor.Utilities;
using System.Diagnostics;

namespace NineDragons_XSD_Editor.Data
{
    public class Xsd
    {
        public XsdHeader header = new XsdHeader();
        public XsdTableCollection tableCollection = new XsdTableCollection();

        public Xsd()
        {
            BindEvents();
        }

        public Xsd(string path) : this()
        {
            Path = path;
        }

        private void BindEvents()
        {
            tableCollection.PropertyChanged +=
                new PropertyChangedEventHandler(this.PropertyChangedEventHandler);
        }

        private void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            // Update the header's count of tables
            if (e.PropertyName == "Tables")
                header.NumTables = tableCollection.Tables.Count;
        }

        public bool load()
        {
            return load(Path);
        }

        public bool write()
        {
            return write(Path);
        }

        public bool write(string path)
        {
            if (String.IsNullOrEmpty(path))
                return false;

            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
                {
                    // Write header
                    bw.Write(header.Unknown1);
                    bw.Write(header.Unknown2);
                    bw.Write(header.NumTables);

                    // Write tables
                    foreach (XsdTable table in tableCollection.Tables)
                    {
                        bw.Write(table.NumRows);
                        bw.Write(table.Name);

                        // Write table rows
                        foreach (XsdTableRow row in table.RowCollection.Rows)
                        {
                            bw.Write(row.ID);
                            bw.Write(row.Unknown);
                            bw.Write(row.NameLen);
                            bw.Write(row.Name);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            Path = path;
            return true;
        }

        public bool load(string path)
        {
            /*
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found: " + path);*/
            if (!File.Exists(path))
                return false;

            Path = path;

            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                // Header vars
                int numTables;

                // Table vars
                int tableIndex;
                int tableRowCount;
                byte[] tableName;

                // Row vars
                int rowId;
                int rowUnknown;
                int rowNameLen;
                byte[] rowName;

                // Read header
                header.Unknown1 = br.ReadInt32();
                header.Unknown2 = br.ReadInt32();
                header.NumTables = br.ReadInt32();

                // Read tables
                // Note: do not use header.NumTables directly, its value is changed when
                //       a table is added to the collection
                for (tableIndex = 0, numTables = header.NumTables; tableIndex < numTables; tableIndex++)
                {
                    tableRowCount = br.ReadInt32();
                    tableName = br.ReadBytes(XsdTable.NAME_MAXLEN);

                    tableCollection.Add(tableRowCount, tableName);

                    // Read table rows
                    for (int j = 0; j < tableRowCount; j++)
                    {
                        rowId = br.ReadInt32();
                        rowUnknown = br.ReadInt32();
                        rowNameLen = br.ReadInt32();
                        rowName = br.ReadBytes(rowNameLen * 2); // They claim to use unicode, but use 2 bytes per character for all languages..

                        tableCollection.Tables[tableIndex]
                            .RowCollection.Add(rowId, rowUnknown, rowNameLen, rowName);
                    }
                }
            }

            return true;
            /*
            foreach (XsdTableRow row in tableCollection.Tables[0].RowCollection.Rows)
            {
                Debug.WriteLine(Encoding.Unicode.GetString(row.Name));
            }
            */
        }

        public MergeResult Merge(Xsd sourceXsd, MergeType type)
        {
            if (type == MergeType.MatchingOnly)
            {
                try
                {
                    foreach (XsdTable sourceTable in sourceXsd.tableCollection.Tables)
                    {
                        foreach (XsdTable destTable in this.tableCollection.Tables)
                        {
                            if (Common.ByteArraysEqual(sourceTable.Name, destTable.Name))
                            {
                                //Debug.WriteLine("Found matching table name: " + sourceTable.UnicodeName);
                                foreach (XsdTableRow sourceRow in sourceTable.RowCollection.Rows)
                                {
                                    foreach (XsdTableRow destRow in destTable.RowCollection.Rows)
                                    {
                                        if (destRow.ID == sourceRow.ID)
                                        {
                                            destRow.Name = sourceRow.Name;
                                            destRow.NameLen = sourceRow.NameLen;
                                            //Debug.WriteLine("Rewriting ID: " + destRow.ID.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return new MergeResult(MergeStatus.Failure);
                }
            }

            return new MergeResult(MergeStatus.Success);
        }

        public string Path { get; set; }

        public enum MergeStatus { Success, Failure }
        public enum MergeType { MatchingOnly }

        public class MergeResult
        {
            public string message;
            public Xsd.MergeStatus status;

            public MergeResult(Xsd.MergeStatus s)
            {
                status = s;
            }
        }
    }
}
