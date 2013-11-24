using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NineDragons.XStringDatabase
{
    abstract public class Xsd
    {
        public event LoadedEventHandler Loaded;

        public SectionCollection sectionCollection = new SectionCollection();

        public static readonly IList<int> ValidHeaders
            = new ReadOnlyCollection<int>(new List<int> { 0xFFCF });

        public int MaxLanguages { get; set; }

        public int header = 0x0000;
        public int version = 0x0000;
        public int totalSectionCount { get; set; }

        public string Filename { get; set; }
        public byte[] Keys { get; set; }
        public bool isEncrypted { get; set; }

        public KeyValuePair<int, string>[] languages = new KeyValuePair<int, string>[1];

        protected Xsd()
        {
        }

        protected Xsd(Version version) 
            : this()
        {
            this.header = ValidHeaders[0];
            this.version = (int)version;
            this.setupLanguages();
        }

        protected void BindEvents()
        {
            sectionCollection.PropertyChanged +=
                new PropertyChangedEventHandler(this.PropertyChangedEventHandler);
        }

        /// <summary>
        /// Setup languages for supported XSD versions
        /// </summary>
        protected void setupLanguages()
        {
            switch ((Version)version)
            {
                case Version.Separated: MaxLanguages = 0; break;
                case Version.Version1: MaxLanguages = 5; break;
                case Version.Version2: MaxLanguages = 11; break;
            }

            if (MaxLanguages == 0)
            {
                languages[0] = new KeyValuePair<int, string>((int)Language.English, Enum.GetName(typeof(Language), Language.English));
            }
            else
            {
                languages = new KeyValuePair<int, string>[MaxLanguages];
                for (int i = 0; i < MaxLanguages; i++)
                    languages[i] = new KeyValuePair<int, string>(i, Enum.GetName(typeof(Language), i));
            }
        }

        protected void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            // Update the header's count of sections
            if (e.PropertyName == "Sections")
                totalSectionCount = sectionCollection.Sections.Count;
        }

        protected virtual void OnLoaded(EventArgs e)
        {
            if (Loaded != null)
                Loaded(this, e);
        }

        public void load()
        {
            load(Filename);
        }

        public abstract void load(string filename);

        public void write(bool withEncryption = false)
        {
            write(Filename, withEncryption);
        }

        public abstract void write(string filename, bool withEncryption = false);

        public MergeResult Merge(Xsd source, MergeType type)
        {
            if (type == MergeType.MatchingOnly)
            {
                try
                {
                    foreach (Section sourceSection in source.sectionCollection.Sections)
                    {
                        foreach (Section destSection in this.sectionCollection.Sections)
                        {
                            if (destSection.NameEqualsTo(sourceSection.Name))
                            {
                                foreach (XString sourceTextString in sourceSection.XStrings.Rows)
                                {
                                    foreach (XString destTextString in destSection.XStrings.Rows)
                                    {
                                        if (destTextString.ResourceIndex == sourceTextString.ResourceIndex)
                                        {
                                            destTextString.TextString = sourceTextString.TextString;
                                            destTextString.TextStringLength = sourceTextString.TextStringLength;
                                            destTextString.ParameterOrder = sourceTextString.ParameterOrder;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (System.Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return new MergeResult(MergeStatus.Failure);
                }
            }

            return new MergeResult(MergeStatus.Success);
        }

        public enum MergeStatus { Success, Failure }
        public enum MergeType { MatchingOnly }

        public class MergeResult
        {
            public string message;
            public MergeStatus status;

            public MergeResult(MergeStatus s)
            {
                status = s;
            }
        }

        public enum Language
        {
            Korean,
            Vietnamese,
            Taiwanese,
            English,
            Unknown1,
            Chinese,
            Russian,
            Unknown2,
            Thai,
            French,
            German
        }

        public enum Version
        {
            Version1 = 0x0001,
            Separated = 0xFF01,
            Version2 = 0x0002
        }
    }
}
