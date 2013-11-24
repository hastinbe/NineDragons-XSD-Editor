//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using NineDragons_XSD_Editor.Components;
using NineDragons_XSD_Editor.UI;
using NineDragons.XStringDatabase;

namespace NineDragons_XSD_Editor
{
    public partial class frmMain : Form
    {
        private List<Xsd> xsd = new List<Xsd>();
        private string baseTitle = "9Dragons XSD Editor";
        private string baseFilename = "Untitled";
        private bool isModified = false;
        private byte[] keys = new byte[] { 0x17, 0x08 };
        public string findText = "";
        public string lastfindText = "";
        public int findSectionIndex = 0;
        public int findRowIndex = 0;
        public int findColumnIndex = 0;

        private BackgroundWorker loadWorker;
        private BackgroundWorker mergeWorker;

        public frmMain()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, dataSectionRows, new object[] { true });

            dataSectionRows.AutoGenerateColumns = false;
        }

        private void setupGrid()
        {
            dataSectionRows.Columns.Clear();
            dataSectionRows.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "ResourceIndex",
                HeaderText = "ID",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            });

            for (int i = 0; i < xsd[0].languages.Length; i++)
            {
                dataSectionRows.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TextString",
                    HeaderText = xsd[0].languages[i].Value,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Resizable = DataGridViewTriState.True
                });
            }
        }

        private void XsdFileLoaded(object sender, EventArgs e)
        {
            setupGrid();
        }

        private void newXsd()
        {
            xsd.Insert(0, new XsdFile(baseFilename, keys));
            xsd[0].version = (int)Xsd.Version.Separated;
            xsd[0].header = Xsd.ValidHeaders[0];

            lstSection.DataSource = xsd[0].sectionCollection.Sections;
            lstSection.DisplayMember = "UnicodeName";
            lstSection.ItemImage = global::NineDragons_XSD_Editor.Properties.Resources.section;

            xsd[0].sectionCollection.Sections.ListChanged
                += new ListChangedEventHandler(Sections_ListChanged);
            xsd[0].Loaded += new LoadedEventHandler(XsdFileLoaded);

            dataSectionRows.Enabled = false;
            btnAddSection.Enabled = false;
            btnEditSection.Enabled = false;
            btnDeleteSection.Enabled = false;

            // Update toolbar
            toolbtnSave.Enabled = false;
            toolbtnMerge.Enabled = false;
            toolbtnFind.Enabled = false;

            // Update menu
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            saveWithEncryptionToolStripMenuItem.Enabled = false;
            findToolStripMenuItem1.Enabled = false;
            findNextToolStripMenuItem.Enabled = false;
            replaceToolStripMenuItem.Enabled = false;

            this.Text = String.Format("{0} - {1}", baseFilename, baseTitle);

            updateStatus();
        }

        private void Sections_ListChanged(object sender, ListChangedEventArgs e)
        {
            Debug.WriteLine("Sections_ListChanged");
            if (lstSection.Items.Count < 1)
            {
                newXsd();
                return;
            }

            if (!isModified)
                this.Text = this.Text.Insert(0, "*");

            dataSectionRows.Enabled = true;
            btnAddSection.Enabled = true;
            btnEditSection.Enabled = true;
            btnDeleteSection.Enabled = true;

            // Update toolbar
            toolbtnSave.Enabled = true;
            toolbtnMerge.Enabled = true;
            toolbtnFind.Enabled = true;
            
            // Update menu
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            saveWithEncryptionToolStripMenuItem.Enabled = true;
            findToolStripMenuItem1.Enabled = true;
            findNextToolStripMenuItem.Enabled = true;
            replaceToolStripMenuItem.Enabled = true;

            isModified = true;
        }

        private void updateStatus()
        {
            toollblNumSection.Text = String.Format("{0} sections", xsd[0].totalSectionCount);

            if (null != lstSection.SelectedItem)
            {
                Section section = (Section)lstSection.SelectedItem;
                toollblNumRow.Text = String.Format("{0} rows", section.XStringCount);
            }

            lstSection.Refresh();
        }

        private void lstSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != lstSection.SelectedItem)
            {
                Section section = (Section)lstSection.SelectedItem;
                dataSectionRows.DataSource = section.XStrings.Rows;
                findSectionIndex = lstSection.SelectedIndex;
                updateStatus();
                btnAddSection.Enabled = true;
                btnEditSection.Enabled = true;
                btnDeleteSection.Enabled = true;
            }
            else
            {
                btnAddSection.Enabled = false;
                btnEditSection.Enabled = false;
                btnDeleteSection.Enabled = false;
            }
        }

        private void dataSectionRows_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataSectionRows.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dataSectionRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 1 || e.Value == null) return;

            List<byte[]> textStrings = (List<byte[]>)e.Value;
            if (e.ColumnIndex > textStrings.Count)
            {
                e.Value = String.Empty;
                e.FormattingApplied = true;
                return;
            }

            byte[] rowName = textStrings[e.ColumnIndex - 1];

            e.Value = (rowName != null && rowName.Length > 1)
                ? Encoding.Unicode.GetString(rowName)
                : String.Empty;
            e.FormattingApplied = true;
        }

        private void dataSectionRows_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex < 1) return;
            if (e.Value.GetType() == typeof(String))
            {
                var index = e.ColumnIndex - 1;
                var text = e.Value.ToString();
                var section = xsd[0].sectionCollection.Sections[lstSection.SelectedIndex];
                var row = section.XStrings.Rows[e.RowIndex];
                var btext = Encoding.Unicode.GetBytes(text);

                // Add all language textstrings for this row
                if (row.TextString.Count <= index)
                    for (int i = row.TextString.Count; i < xsd[0].MaxLanguages; i++)
                        row.TextString.Add(new byte[0]);

                // Add all language textstring lengths for this row
                if (row.TextStringLength.Count <= index)
                    for (int i = row.TextStringLength.Count; i < xsd[0].MaxLanguages; i++)
                        row.TextStringLength.Add(Encoding.Unicode.GetString(row.TextString[i]).Length);

                row.TextString[index] = btext;
                row.TextStringLength[index] = text.Length;

                e.Value = row.TextString;
                e.ParsingApplied = true;
                updateStatus();
            }
        }

        private bool OpenXsd(int xsdIndex)
        {
            string filename = OpenXsdDialog();
            if (filename == string.Empty)
                return false;

            if (xsdIndex == 0)
                xsd.Clear();

            if (xsdIndex > 0 && !(xsd[0] is Xsd))
                MessageBox.Show("Cannot open additional XSDs. Try loading an XSD.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            xsd.Insert(xsdIndex, (new XsdFile(filename, keys)));

            if (xsdIndex == 0)
            {
                loadWorker = new BackgroundWorker();
                loadWorker.WorkerSupportsCancellation = true;
                loadWorker.DoWork += new DoWorkEventHandler(this.LoadWorker_DoWork);
                loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadWorker_RunWorkerCompleted);
                busySectionPanel.Visible = true;

                if (loadWorker.IsBusy && loadWorker.WorkerSupportsCancellation)
                    loadWorker.CancelAsync();
                else
                    loadWorker.RunWorkerAsync(xsdIndex);
            }
            else
            {
                xsd[xsdIndex].load();
            }

            return true;
        }

        private string OpenXsdDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XSD files (*.xsd)|*.xsd|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : string.Empty;
        }

        private void SaveXsd()
        {
            if (false == File.Exists(xsd[0].Filename))
            {
                DialogResult dResult = 
                    MessageBox.Show("The file '" + xsd[0].Filename + "' no longer exists. Save to this file anyway?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                switch (dResult)
                {
                    case DialogResult.No: SaveXsdAs(); return;
                    case DialogResult.Cancel: return;
                }
            }

            try
            {
                xsd[0].write();
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Text = String.Format("{0}{1} - {2}", 
                xsd[0].Filename, xsd[0].isEncrypted ? " [Encrypted]" : "", baseTitle);

            isModified = false;
        }

        private void SaveXsdAs(bool withEncryption = false)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XSD files (*.xsd)|*.xsd|All files (*.*)|*.*";
            dialog.FilterIndex = 1;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                xsd[0].write(dialog.FileName, withEncryption);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Text = String.Format("{0}{1} - {2}",
                xsd[0].Filename,
                xsd[0].isEncrypted ? " [Encrypted]" : "",
                baseTitle);
            isModified = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenXsd(0);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(xsd[0].Filename))
                SaveXsdAs();
            else
                SaveXsd();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveXsdAs();
        }

        private void saveWithEncryptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool withEncryption = true;
            SaveXsdAs(withEncryption);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.Show();
        }

        private void toolbtnOpen_Click(object sender, EventArgs e)
        {
            OpenXsd(0);
        }

        private void toolbtnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(xsd[0].Filename))
                SaveXsdAs();
            else
                SaveXsd();
        }

        private void btnAddSection_Click(object sender, EventArgs e)
        {
            InputBoxResult result = 
                InputBox.Show("Name:", "Add section", "", new InputBoxValidatingHandler(Validate_AddSection));
        }

        private void Validate_AddSection(object sender, InputBoxValidatingArgs e)
        {
            string text = e.Text;
            if (text.Length == 0)
            {
                e.Cancel = true;
                e.Message = "Section name is required";
                return;
            }

            byte[] bName = Encoding.Unicode.GetBytes(text);

            if (xsd.Count < 1)
            {
                newXsd();
                setupGrid();
            }

            foreach (Section section in xsd[0].sectionCollection.Sections)
            {
                if (section.NameEqualsTo(bName))
                {
                    MessageBox.Show("Duplicate section name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            xsd[0].sectionCollection.Sections.Add(new Section(0, bName));
            updateStatus();
            lstSection.ClearSelected();
            lstSection.SelectedIndex = lstSection.Items.Count - 1;
            lstSection.Focus();

            dataSectionRows.DataSource = ((Section)lstSection.SelectedItem).XStrings.Rows;
        }

        private void Validate_EditSection(object sender, InputBoxValidatingArgs e)
        {
            string text = e.Text;
            if (text.Length == 0)
            {
                e.Cancel = true;
                e.Message = "Section name is required";
                return;
            }

            byte[] bName = Encoding.Unicode.GetBytes(text);

            foreach (Section section in xsd[0].sectionCollection.Sections)
            {
                if (section.NameEqualsTo(bName))
                {
                    MessageBox.Show("Duplicate section name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (null != lstSection.SelectedItem)
            {
                Section section = (Section)lstSection.SelectedItem;
                section.Name = bName;
            }
            updateStatus();
        }

        public bool Replace(string find, string replace, bool replaceAll = false)
        {
            var found = Find(find, findSectionIndex, findRowIndex, findColumnIndex);
            if (found)
            {
                var section = xsd[0].sectionCollection.Sections[lstSection.SelectedIndex];
                var row = section.XStrings.Rows[findRowIndex];
                var str = Encoding.Unicode.GetString(row.TextString[findColumnIndex]);
                str = str.Replace(find, replace);

                row.TextString[findColumnIndex] = Encoding.Unicode.GetBytes(str);
                row.TextStringLength[findColumnIndex] = str.Length;
                dataSectionRows.CurrentCell.Value = row.TextString;

                if (replaceAll)
                {
                    while (Replace(find, replace, replaceAll)) ;
                }
                updateStatus();
            }
            return found;
        }

        public bool Find(string find, int sectionIndex = 0, int rowIndex = 0, int colIndex = 0)
        {
            var bFound = false;

            if (xsd[0].sectionCollection.Sections.Count < 1)
                return bFound;

            if (find.Length == 0)
                return bFound;

            if (find != lastfindText)
            {
                sectionIndex = findSectionIndex = 0;
                rowIndex = findRowIndex = 0;
                colIndex = findColumnIndex = 0;
            }
            else
            {
                findSectionIndex = sectionIndex;
                findRowIndex = rowIndex;
                findColumnIndex = colIndex;
            }

            lastfindText = findText = find;
            
            if (findColumnIndex >= dataSectionRows.Columns.Count - 1)
            {
                findColumnIndex = 0;
                findRowIndex++;
            }

            if (findSectionIndex > xsd[0].sectionCollection.Sections.Count)
                findSectionIndex = 0;

            if (findRowIndex > xsd[0].sectionCollection.Sections[findSectionIndex].XStrings.Rows.Count)
                findRowIndex = 0;

            // Section loop
            for (int i = findSectionIndex; i < xsd[0].sectionCollection.Sections.Count; i++)
            {
                // Row loop
                var section = xsd[0].sectionCollection.Sections[i];
                for (int j = findRowIndex; j < section.XStrings.Rows.Count; j++)
                {
                    // Column loop
                    var row = section.XStrings.Rows[j];
                    for (int k = findColumnIndex; k < row.TextString.Count; k++)
                    {
                        string name = Encoding.Unicode.GetString(row.TextString[k]);
                        if (name.Contains(find))
                        {
                            findSectionIndex = i;
                            findRowIndex = j;
                            findColumnIndex = k;

                            lstSection.SelectedIndex = findSectionIndex;
                            dataSectionRows.ClearSelection();
                            dataSectionRows.CurrentCell = dataSectionRows[findColumnIndex + 1, findRowIndex];
                            dataSectionRows.FirstDisplayedScrollingRowIndex = findRowIndex;
                            dataSectionRows.Focus();
                            
                            bFound = true;
                            return bFound;
                        }
                    }
                }
            }

            findSectionIndex = 0;
            findRowIndex = 0;
            findColumnIndex = 0;

            return bFound;
        }

        public bool FindNext()
        {
            return Find(findText, findSectionIndex, findRowIndex, findColumnIndex + 1);
        }

        public bool FindNext(string find)
        {
            findText = find;
            return FindNext();
        }

        private void btnEditSection_Click(object sender, EventArgs e)
        {
            if (null != lstSection.SelectedItem)
            {
                Section section = (Section)lstSection.SelectedItem;
                InputBoxResult result = InputBox.Show("Name:", "Edit section", section.UnicodeName, new InputBoxValidatingHandler(Validate_EditSection));
            }
        }

        private void btnDeleteSection_Click(object sender, EventArgs e)
        {
            if (null != lstSection.SelectedItem)
            {
                if (DialogResult.Yes != MessageBox.Show("Are you sure you want to delete this section?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    return;

                dataSectionRows.EndEdit();
                Section section = (Section)lstSection.SelectedItem;
                section.XStrings.Rows.Clear();
                xsd[0].sectionCollection.Sections.Remove(section);
            }
        }



        private void btnCancelBusy_Click(object sender, EventArgs e)
        {
            if (mergeWorker.IsBusy && mergeWorker.WorkerSupportsCancellation)
            {
                labelBusyStatus.Text = "Cancelling...";
                mergeWorker.CancelAsync();
            }
            else if (loadWorker.IsBusy && loadWorker.WorkerSupportsCancellation)
            {
                labelBusyStatus.Text = "Cancelling...";
                loadWorker.CancelAsync();
            }
        }

        private void busySectionPanel_VisibleChanged(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            /*
             * The panel is enabled/disabled by visibility, therefore we need
             * to setup a default state when the control visibility is true
             */
            if (panel.Visible)
            {
                labelBusyStatus.Text = "Please wait...";
                progressIndicator.Start();

                menu.Enabled = false;
                toolbar.Enabled = false;
                statusbar.Enabled = false;
                splitContainer1.Panel1.Enabled = false;

                foreach (Control c in splitContainer1.Panel2.Controls)
                {
                    switch (c.Name)
                    {
                        case "busySectionPanel":
                            c.Enabled = true;
                            break;
                        default:
                            c.Enabled = false;
                            break;
                    }
                }
            }
            else
            {
                progressIndicator.Stop();

                statusbar.Enabled = true;
                toolbar.Enabled = true;
                menu.Enabled = true;
                splitContainer1.Panel1.Enabled = true;

                foreach (Control c in splitContainer1.Panel2.Controls)
                    c.Enabled = true;
            }
        }


        #region Delegates
        private void LoadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker == null) return;
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                int xsdIndex = (int)e.Argument;
                xsd[xsdIndex].load();
                e.Result = true;
            }
            catch (NineDragons.XStringDatabase.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Result = null;
                e.Cancel = true;
            }
        }

        private delegate Xsd.MergeResult MergeXsdDelegate();
        private Xsd.MergeResult DelegateMergeXsd()
        {
            return xsd[0].Merge(xsd[1], Xsd.MergeType.MatchingOnly);
        }
        #endregion

        #region BackgroundWorker Events
        private void LoadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadWorker.DoWork -= new DoWorkEventHandler(this.LoadWorker_DoWork);
            loadWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(this.LoadWorker_RunWorkerCompleted);
            loadWorker.Dispose();

            if (e.Cancelled || e.Result == null || (bool)e.Result == false)
            {
                busySectionPanel.Visible = false;
                return;
            }

            lstSection.DataSource = xsd[0].sectionCollection.Sections;
            lstSection.DisplayMember = "UnicodeName";

            // Update statusbar
            updateStatus();

            // Update menu
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            saveWithEncryptionToolStripMenuItem.Enabled = true;
            findToolStripMenuItem1.Enabled = true;
            findNextToolStripMenuItem.Enabled = true;
            replaceToolStripMenuItem.Enabled = true;

            // Update toolbar
            toolbtnSave.Enabled = true;
            toolbtnMerge.Enabled = true;
            toolbtnFind.Enabled = true;

            dataSectionRows.Enabled = true;

            this.Text = String.Format("{0}{1} - {2}",
                xsd[0].Filename,
                xsd[0].isEncrypted ? " [Encrypted]" : "",
                baseTitle);
            setupGrid();


            busySectionPanel.Visible = false;
        }

        private void MergeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker == null) return;
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                e.Result = ((MergeXsdDelegate)e.Argument).Invoke();
            }
            catch (System.Exception)
            {
                e.Result = null;
                e.Cancel = true;
            }
        }

        private void MergeWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mergeWorker.DoWork -= new DoWorkEventHandler(this.MergeWorker_DoWork);
            mergeWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(this.MergeWorker_RunWorkerCompleted);
            mergeWorker.Dispose();

            if (e.Cancelled || e.Result == null)
            {
                busySectionPanel.Visible = false;
                return;
            }

            Xsd.MergeResult result = e.Result as Xsd.MergeResult;

            switch (result.status)
            {
                case Xsd.MergeStatus.Failure:
                    MessageBox.Show("Merge failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            busySectionPanel.Visible = false;
        }
        #endregion


        private void matchingOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenXsd(1);
            }
            catch (NineDragons.XStringDatabase.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mergeWorker = new BackgroundWorker();
            mergeWorker.WorkerSupportsCancellation = true;
            mergeWorker.DoWork += new DoWorkEventHandler(this.MergeWorker_DoWork);
            mergeWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.MergeWorker_RunWorkerCompleted);
            busySectionPanel.Visible = true;

            if (mergeWorker.IsBusy && mergeWorker.WorkerSupportsCancellation)
                mergeWorker.CancelAsync();
            else
                mergeWorker.RunWorkerAsync(new MergeXsdDelegate(DelegateMergeXsd));
        }

        private void setKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new UI.InputKeyDialog(ref keys);
            form.ShowDialog();
        }

        private void toolbtnFind_Click(object sender, EventArgs e)
        {
            Form form = new UI.FindWindow(this);
            form.Show();
        }

        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolbtnFind_Click(sender, e);
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find(findText, findSectionIndex, findRowIndex, findColumnIndex + 1);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new UI.ReplaceWindow(this);
            form.Show();
        }
    }
}
