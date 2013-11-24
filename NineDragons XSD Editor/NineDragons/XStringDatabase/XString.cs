//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NineDragons.XStringDatabase
{
    public class XString : INotifyPropertyChanged
    {
        private int _resourceIndex;
        private List<byte[]> _textString = new List<byte[]>();
        private List<int> _textStringLength = new List<int>();
        private List<int> _parameterOrder = new List<int>();

        public event PropertyChangedEventHandler PropertyChanged;

        public XString()
        {
        }

        public XString(int resourceIndex, byte[] textString, int parameterOrder, int textStringLength)
        {
            _resourceIndex = resourceIndex;
            _textString.Add(textString);
            _textStringLength.Add(textStringLength);
            _parameterOrder.Add(parameterOrder);
        }

        public int ResourceIndex
        {
            get { return _resourceIndex; }
            set { _resourceIndex = value; this.NotifyPropertyChanged("ResourceIndex"); }
        }

        public List<byte[]> TextString
        {
            get { return _textString; }
            set { _textString = value; this.NotifyPropertyChanged("TextString"); }
        }

        public List<int> TextStringLength
        {
            get { return _textStringLength; }
            set { _textStringLength = value; this.NotifyPropertyChanged("TextStringLength"); }
        }

        public List<int> ParameterOrder
        {
            get { return _parameterOrder; }
            set { _parameterOrder = value; this.NotifyPropertyChanged("ParameterOrder"); }
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
