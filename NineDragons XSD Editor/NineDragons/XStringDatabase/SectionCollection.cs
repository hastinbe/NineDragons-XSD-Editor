//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NineDragons.XStringDatabase
{
    public class SectionCollection : INotifyPropertyChanged
    {
        private BindingList<Section> listSection = new BindingList<Section>();
        public event PropertyChangedEventHandler PropertyChanged;

        public SectionCollection()
        {
            BindEvents();
        }

        private void BindEvents()
        {
            listSection.ListChanged +=
                new ListChangedEventHandler(this.SectionListChangedEventHandler);
        }

        public void Add(int count, byte[] name)
        {
            Section header = new Section
            {
                XStringCount = count,
                Name = name,
            };
            this.listSection.Add(header);
        }

        public void Add(Section section)
        {
            Add(section.XStringCount, section.Name);
        }

        public BindingList<Section> Sections
        {
            set { this.listSection = value; }
            get { return this.listSection; }
        }

        private void SectionListChangedEventHandler(object sender, ListChangedEventArgs e)
        {
            this.NotifyPropertyChanged("Sections");
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
