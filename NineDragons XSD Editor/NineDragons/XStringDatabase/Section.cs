//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.ComponentModel;
using System.Text;

namespace NineDragons.XStringDatabase
{
    public class Section
    {
        public const int NAME_MAXLEN = 64;
        public int XStringCount = 0;
        protected byte[] _Name;

        public XStringCollection XStrings = new XStringCollection();

        public Section()
        {
            BindEvents();
        }

        public Section(int count, byte[] name)
            : this()
        {
            XStringCount = count;
            Name = name;
        }

        private void BindEvents()
        {
            XStrings.Rows.ListChanged += new ListChangedEventHandler(this.RowListChangedEventHandler);
        }

        public byte[] Name
        {
            get { return _Name; }
            set { _Name = ByteArrayToFixedByteArray(value, sizeof(char) * NAME_MAXLEN); }
        }

        public string UnicodeName
        {
            get { return Encoding.Unicode.GetString(Name); }
            set { Name = StringToFixedUnicodeByteArray(value, sizeof(char) * NAME_MAXLEN); }
        }

        public bool NameEqualsTo(byte[] CompareName)
        {
            if (Name == null && CompareName == null) return true;
            if (Name == null && CompareName != null) return false;
            if (CompareName == null && Name != null) return false;
            if (Name.Length != CompareName.Length) return false;
            if (Name.GetHashCode() == CompareName.GetHashCode()) return true;

            for (int i = 0, len = Name.Length; i < len; i++)
                if (Name[i] != CompareName[i])
                    return false;
            return true;
        }

        protected byte[] ByteArrayToFixedByteArray(byte[] value, int size)
        {
            byte[] fixedByte = new byte[size];
            int len = value.Length;
            for (int i = 0; i < len && i < size; i++)
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
            // Update the number of rows when the list of section rows are modified
            XStringCount = XStrings.Rows.Count;
        }
    }
}
