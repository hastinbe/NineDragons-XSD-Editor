//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.ComponentModel;
using System.Text;
using NineDragons_XSD_Editor.Utilities;

namespace NineDragons_XSD_Editor.Data
{
    public class XsdTable
    {
        public const int NAME_MAXLEN = 128;
        public int NumRows = 0;
        protected byte[] _Name;

        public XsdTableRowCollection RowCollection = new XsdTableRowCollection();

        public XsdTable()
        {
            BindEvents();
        }

        public XsdTable(int numRows, byte[] name) : this()
        {
            NumRows = numRows;
            Name = name;
        }

        private void BindEvents()
        {
            RowCollection.Rows.ListChanged += new ListChangedEventHandler(this.RowListChangedEventHandler);
        }

        public byte[] Name
        {
            get { return _Name; }
            set { _Name = ByteArrayToFixedByteArray(value, NAME_MAXLEN); }
        }

        public string UnicodeName
        {
            get { return Encoding.Unicode.GetString(Name); }
            set { Name = StringToFixedUnicodeByteArray(value, NAME_MAXLEN); }
        }

        protected byte[] ByteArrayToFixedByteArray(byte[] value, int size)
        {
            byte[] fixedByte = new byte[NAME_MAXLEN];
            int len = value.Length;
            for (int i = 0; i < len && i < NAME_MAXLEN; i++)
                fixedByte[i] = value[i];
            return fixedByte;
        }

        protected byte[] StringToFixedUnicodeByteArray(string value, int size)
        {
            byte[] tmp = Encoding.Unicode.GetBytes(value);
            byte[] fixedByte = new byte[size];
            int len = tmp.Length;
            for (int i = 0; i < len && i < size; i++)
                fixedByte[i] = tmp[i];
            return fixedByte;
        }

        public override string ToString()
        {
            return UnicodeName;
        }

        private void RowListChangedEventHandler(object sender, ListChangedEventArgs e)
        {
            // Update the number of rows when the list of table rows are modified
            NumRows = RowCollection.Rows.Count;
        }
    }
}
