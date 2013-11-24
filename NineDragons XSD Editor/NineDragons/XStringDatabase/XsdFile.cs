//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NineDragons.XStringDatabase
{
    public delegate void LoadedEventHandler(object sender, EventArgs e);

    public class XsdFile : Xsd
    {
        public XsdFile()
        {
            //languages[0] = new KeyValuePair<int, string>((int)Language.English, Enum.GetName(typeof(Language), Language.English));
            BindEvents();
        }

        public XsdFile(string filename) : this()
        {
            Filename = filename;
        }

        public XsdFile(string filename, byte[] keys) : this()
        {
            Filename = filename;
            Keys = keys;
        }

        public XsdFile(byte[] keys)
            : this()
        {
            Keys = keys;
        }

        public XsdFile(Version version)
            : base(version)
        {
            BindEvents();
        }

        public override void load(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException("File '" + filename + "' does not exist.");

            isEncrypted = false;
            Filename = filename;

            using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                header = br.ReadInt32();
                if (!ValidHeaders.Contains(header))
                    throw new Exception(string.Format("File '{0}' is not valid. [{1}]", filename, header.ToString("X4")));

                version = br.ReadInt32();

                this.setupLanguages();

                int stringLength;
                byte[] stringText;
                totalSectionCount = br.ReadInt32();

                Debug.WriteLine(string.Format("Version: {0} (Languages={1} Sections={2})", 
                    version.ToString("X4"),
                    MaxLanguages, 
                    totalSectionCount));

                for (int i = 0, numSections = totalSectionCount; i < numSections; i++)
                {
                    Section section = new Section();
                    section.XStringCount = br.ReadInt32();
                    section.Name = br.ReadBytes(sizeof(char) * Section.NAME_MAXLEN);

                    // String is XOR'd
                    if (section.Name.Length > 1 && section.Name[1] == Keys[1])
                    {
                        isEncrypted = true;
                        section.Name = TextEncrypt.BikeyXor(section.Name, Keys);
                    }

                    sectionCollection.Add(section);

                    for (int j = 0; j < section.XStringCount; j++)
                    {
                        XString textStringItem = new XString();
                        textStringItem.ResourceIndex = br.ReadInt32();

                        if (version == (int)Version.Separated)
                        {
                            textStringItem.ParameterOrder.Add(br.ReadInt32());

                            stringLength = br.ReadInt32();
                            stringText = br.ReadBytes(sizeof(char) * stringLength);

                            if (isEncrypted)
                                stringText = TextEncrypt.BikeyXor(stringText, Keys);

                            textStringItem.TextString.Add(stringText);
                            textStringItem.TextStringLength.Add(stringLength);

                            sectionCollection.Sections[i].XStrings.Add(
                                textStringItem.ResourceIndex,
                                textStringItem.ParameterOrder[0],
                                textStringItem.TextStringLength[0],
                                textStringItem.TextString[0]);

                            continue;
                        }


                        for (int lancnt = 0; lancnt < MaxLanguages; lancnt++)
                        {
                            textStringItem.ParameterOrder.Add(br.ReadInt32());
                        }

                        for (int lancnt = 0; lancnt < MaxLanguages; lancnt++)
                        {
                            stringLength = br.ReadInt32();
                            stringText = br.ReadBytes(sizeof(char) * stringLength);

                            if (isEncrypted)
                                stringText = TextEncrypt.BikeyXor(stringText, Keys);

                            textStringItem.TextString.Add(stringText);
                            textStringItem.TextStringLength.Add(stringLength);
                        }

                        sectionCollection.Sections[i].XStrings.Add(
                                textStringItem.ResourceIndex,
                                textStringItem.ParameterOrder,
                                textStringItem.TextStringLength,
                                textStringItem.TextString);
                    }
                }
            }

            OnLoaded(EventArgs.Empty);
        }

        public override void write(string filename, bool withEncryption = false)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                // Write header
                bw.Write(header);
                bw.Write(version);
                bw.Write(totalSectionCount);

                // Write sections
                foreach (Section section in sectionCollection.Sections)
                {
                    byte[] sectionName = isEncrypted || withEncryption
                        ? TextEncrypt.BikeyXor((byte[])section.Name.Clone(), Keys) 
                        : section.Name;
                    bw.Write(section.XStringCount);
                    bw.Write(sectionName);

                    if (version == (int)Version.Separated)
                    {
                        foreach (XString row in section.XStrings.Rows)
                        {
                            if (row.TextString.Count < 1)
                                row.TextString.Add(new byte[0]);

                            byte[] textString = isEncrypted || withEncryption
                                ? TextEncrypt.BikeyXor(row.TextString[0], Keys)
                                : row.TextString[0];
                            
                            if (row.ParameterOrder.Count < 1)
                                row.ParameterOrder.Add(0);

                            if (row.TextStringLength.Count < 1)
                                row.TextStringLength.Add(Encoding.Unicode.GetString(textString).Length);

                            bw.Write(row.ResourceIndex);
                            bw.Write(row.ParameterOrder[0]);
                            bw.Write(row.TextStringLength[0]);
                            bw.Write(textString);
                        }
                    }
                    else
                    {
                        foreach (XString row in section.XStrings.Rows)
                        {
                            bw.Write(row.ResourceIndex);

                            // Fill in empty parameter orders
                            if (row.ParameterOrder.Count <= MaxLanguages)
                                for (int i = row.ParameterOrder.Count; i < MaxLanguages; i++)
                                    row.ParameterOrder.Add(0);

                            // Fill in empty text strings
                            if (row.TextString.Count <= MaxLanguages)
                                for (int i = row.TextString.Count; i < MaxLanguages; i++)
                                    row.TextString[i] = new byte[0];

                            // Fill in empty text string lengths
                            if (row.TextStringLength.Count <= MaxLanguages)
                                for (int i = row.TextStringLength.Count; i < MaxLanguages; i++)
                                    row.TextStringLength[i] = Encoding.Unicode.GetString(row.TextString[i]).Length;

                            foreach (int parameterOrder in row.ParameterOrder)
                                bw.Write(parameterOrder);

                            for (int lancnt = 0; lancnt < MaxLanguages; lancnt++)
                            {
                                byte[] textString = isEncrypted || withEncryption
                                    ? TextEncrypt.BikeyXor(row.TextString[lancnt], Keys)
                                    : row.TextString[lancnt];
                                bw.Write(row.TextStringLength[lancnt]);
                                bw.Write(textString);
                            }
                        }
                    }
                }
            }

            if (withEncryption)
                isEncrypted = true;

            Filename = filename;
        }
    }
}
