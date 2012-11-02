//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.ComponentModel;

namespace NineDragons_XSD_Editor.Data
{
    public class XsdTableRow : INotifyPropertyChanged
    {
        private int _ID = 0;
        private int _Unknown = 0;
        private int _NameLen = 0;
        private byte[] _Name = new byte[] {};

        public event PropertyChangedEventHandler PropertyChanged;

        public XsdTableRow()
        {
        }

        public XsdTableRow(int id, int unknown, int nameLen, byte[] name)
        {
            _ID = id;
            _Unknown = unknown;
            _NameLen = nameLen;
            _Name = name;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; this.NotifyPropertyChanged("ID"); }
        }

        public int Unknown
        {
            get { return _Unknown; }
            set { _Unknown = value; this.NotifyPropertyChanged("Unknown"); }
        }

        public int NameLen
        {
            get { return _NameLen; }
            set { _NameLen = value; this.NotifyPropertyChanged("NameLen"); }
        }

        public byte[] Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                _NameLen = System.Text.Encoding.Unicode.GetString(value).Length;
                this.NotifyPropertyChanged("Name");
            }
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
