//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NineDragons_XSD_Editor.Data
{
    public class XsdTableRowCollection
    {
        private BindingList<XsdTableRow> _rows = new BindingList<XsdTableRow>();

        public void Add(int id, int unknown, int nameLen, byte[] name)
        {
            XsdTableRow tableRow = new XsdTableRow
            {
                ID = id,
                Unknown = unknown,
                NameLen = nameLen,
                Name = name
            };
            this._rows.Add(tableRow);
        }

        public BindingList<XsdTableRow> Rows
        {
            get { return this._rows; }
        }
    }
}
