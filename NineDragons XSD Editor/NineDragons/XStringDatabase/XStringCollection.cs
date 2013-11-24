//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NineDragons.XStringDatabase
{
    public class XStringCollection
    {
        private BindingList<XString> _rows = new BindingList<XString>();

        public void Add(int id, int parameterOrder, int length, byte[] textString)
        {
            XString text = new XString();
            text.ResourceIndex = id;
            text.ParameterOrder.Add(parameterOrder);
            text.TextStringLength.Add(length);
            text.TextString.Add(textString);
            this._rows.Add(text);
        }

        public void Add(int id, List<int> parameterOrder, List<int> length, List<byte[]> textString)
        {
            XString text = new XString
            {
                ResourceIndex = id,
                ParameterOrder = parameterOrder,
                TextStringLength = length,
                TextString = textString
            };

            this._rows.Add(text);
        }

        public BindingList<XString> Rows
        {
            get { return this._rows; }
        }
    }
}
