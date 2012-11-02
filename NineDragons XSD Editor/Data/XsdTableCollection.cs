//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NineDragons_XSD_Editor.Data
{
    public class XsdTableCollection : INotifyPropertyChanged
    {
        private BindingList<XsdTable> listTable = new BindingList<XsdTable>();
        public event PropertyChangedEventHandler PropertyChanged;

        public XsdTableCollection()
        {
            BindEvents();
        }

        private void BindEvents()
        {
            listTable.ListChanged +=
                new ListChangedEventHandler(this.TableListChangedEventHandler);
        }

        public void Add(int numRows, byte[] name)
        {
            XsdTable table = new XsdTable
            {
                NumRows = numRows,
                Name = name
            };
            this.listTable.Add(table);
        }

        public BindingList<XsdTable> Tables
        {
            set { this.listTable = value; }
            get { return this.listTable; }
        }

        private void TableListChangedEventHandler(object sender, ListChangedEventArgs e)
        {
            this.NotifyPropertyChanged("Tables");
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
