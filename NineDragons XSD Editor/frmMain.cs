//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using NineDragons_XSD_Editor.Components;
using NineDragons_XSD_Editor.Data;
using NineDragons_XSD_Editor.UI;
using NineDragons_XSD_Editor.Utilities;
using System.Text;
using System.Xml;

namespace NineDragons_XSD_Editor
{
    public partial class frmMain : Form
    {
        private List<Xsd> xsd = new List<Xsd>();
        private string baseTitle = "9Dragons XSD Editor";
        private string baseFilename = "Untitled";
        private bool isModified = false;
        private byte[] keys = new byte[] { 0x17, 0x08 };
        private string findText = "";
        private int findTableIndex = 0;
        private int findRowIndex = 0;

        public frmMain()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            initializeGrid();
            newXsd();
        }

        private void initializeGrid()
        {
            // Double buffering
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, dataTableRows, new object[] { true });

            dataTableRows.AutoGenerateColumns = false;
            dataTableRows.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn {
                    DataPropertyName = "ID",
                    HeaderText = "ID",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                },
                new DataGridViewTextBoxColumn {
                    DataPropertyName = "Name",
                    HeaderText = "Name",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                }
            });
        }

        private void newXsd()
        {
            xsd.Insert(0, new Xsd(keys));
            lstTable.DataSource = xsd[0].tableCollection.Tables;
            lstTable.DisplayMember = "UnicodeName";
            lstTable.ItemImage = global::NineDragons_XSD_Editor.Properties.Resources.table;
            xsd[0].tableCollection.Tables.ListChanged
                += new ListChangedEventHandler(Tables_ListChanged);

            dataTableRows.Enabled = false;
            btnDeleteTable.Enabled = false;
            btnEditTable.Enabled = false;
            toolbtnSave.Enabled = false;
            toolbtnMerge.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;

            this.Text = String.Format("{0} - {1}", baseFilename, baseTitle);
            updateStatus();
        }

        private void Tables_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (lstTable.Items.Count < 1)
            {
                newXsd();
                return;
            }

            if (!isModified)
                this.Text = this.Text.Insert(0, "*");

            dataTableRows.Enabled = true;
            btnDeleteTable.Enabled = true;
            btnEditTable.Enabled = true;
            toolbtnSave.Enabled = true;
            toolbtnMerge.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

            isModified = true;
        }

        private void updateStatus()
        {
            toollblNumTable.Text = String.Format("{0} tables", xsd[0].header.NumTables);

            if (null != lstTable.SelectedItem)
            {
                XsdTable table = (XsdTable)lstTable.SelectedItem;
                toollblNumRow.Text = String.Format("{0} rows", table.NumRows);
            }

            lstTable.Refresh();
        }

        private void lstTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != lstTable.SelectedItem)
            {
                XsdTable table = (XsdTable)lstTable.SelectedItem;
                dataTableRows.DataSource = table.RowCollection.Rows;
                findTableIndex = lstTable.SelectedIndex;
                updateStatus();
                btnEditTable.Enabled = true;
                btnDeleteTable.Enabled = true;
            }
            else
            {
                btnEditTable.Enabled = false;
                btnDeleteTable.Enabled = false;
            }
        }

        private void dataTableRows_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataTableRows.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dataTableRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 1 || e.Value == null) return;

            byte[] rowName = (byte[])e.Value;

            e.Value = (rowName != null && rowName.Length > 1)
                ? Encoding.Unicode.GetString(rowName)
                : String.Empty;
        }

        private void dataTableRows_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex != 1) return;

            // Convert edited table row name into a byte array
            if (e.Value.GetType() == typeof(String))
            {
                e.Value = Encoding.Unicode.GetBytes(e.Value.ToString());
                e.ParsingApplied = true;
                updateStatus();
            }
        }

        private void dataTableRows_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (e.ColumnIndex != 1) return;
            //if (e.RowIndex == this.dataTableRows.RowCount - 1) return;

            /*
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                if (e.ColumnIndex == 0)
                    dataTableRows.Rows[e.RowIndex].ErrorText = "ID field cannot be empty. Press ESC to cancel";
                else if (e.ColumnIndex == 1)
                    dataTableRows.Rows[e.RowIndex].ErrorText = "Name field cannot be empty. Press ESC to cancel";
                e.Cancel = true;
            }
            */
        }

        private bool OpenFirstXsd()
        {
            string filename = OpenXsdDialog();
            if (filename == string.Empty)
                return false;

            xsd.Clear();
            xsd.Insert(0, (new Xsd(filename, keys)));
            if (false == xsd[0].load())
                return false;
            lstTable.DataSource = xsd[0].tableCollection.Tables;
            lstTable.DisplayMember = "UnicodeName";

            // Update statusbar
            updateStatus();

            // Update menu
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

            // Update toolbar
            toolbtnSave.Enabled = true;
            toolbtnMerge.Enabled = true;

            dataTableRows.Enabled = true;

            this.Text = String.Format("{0}{1} - {2}", 
                xsd[0].Path, 
                xsd[0].isEncrypted ? " [Encrypted]" : "", 
                baseTitle);
            return true;
        }

        private bool OpenSecondXsd()
        {
            string filename = OpenXsdDialog();
            if (filename == string.Empty)
                return false;

            if (!(xsd[0] is Xsd))
            {
                MessageBox.Show("Cannot open file because you have not loaded an XSD first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            xsd.Insert(1, (new Xsd(filename, keys)));
            return xsd[1].load();
        }

        private string OpenXsdDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XSD files (*.xsd)|*.xsd|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : string.Empty;
        }

        private bool SaveXsd()
        {
            if (false == System.IO.File.Exists(xsd[0].Path))
            {
                DialogResult dResult = MessageBox.Show("The file '" + xsd[0].Path + "' no longer exists. Save to this file anyway?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                switch (dResult)
                {
                    case DialogResult.No: return SaveXsdAs();
                    case DialogResult.Cancel: return false;
                }
            }

            bool result = xsd[0].write();

            if (result)
            {
                this.Text = String.Format("{0}{1} - {2}",
                    xsd[0].Path,
                    xsd[0].isEncrypted ? " [Encrypted]" : "",
                    baseTitle);
                isModified = false;
            }

            return result;
        }

        private bool SaveXsdAs(bool withEncryption = false)
        {
            bool result = false;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XSD files (*.xsd)|*.xsd|All files (*.*)|*.*";
            dialog.FilterIndex = 1;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                result = xsd[0].write(dialog.FileName, withEncryption);

                if (result)
                {
                    this.Text = String.Format("{0}{1} - {2}",
                        xsd[0].Path,
                        xsd[0].isEncrypted ? " [Encrypted]" : "",
                        baseTitle);
                    isModified = false;
                }
            }

            return result;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFirstXsd();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(xsd[0].Path))
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
            OpenFirstXsd();
        }

        private void toolbtnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(xsd[0].Path))
                SaveXsdAs();
            else
                SaveXsd();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            InputBoxResult result = InputBox.Show("Name:", "Add table", "", new InputBoxValidatingHandler(Validate_AddTable));
        }

        private void Validate_AddTable(object sender, InputBoxValidatingArgs e)
        {
            string text = e.Text.Trim();
            if (text.Length == 0)
            {
                e.Cancel = true;
                e.Message = "Table name is required";
                return;
            }

            byte[] bName = Encoding.Unicode.GetBytes(text);

            foreach (XsdTable table in xsd[0].tableCollection.Tables)
            {
                if (Common.ByteArraysEqual(bName, table.Name))
                {
                    MessageBox.Show("Duplicate table name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            xsd[0].tableCollection.Tables.Add(new XsdTable(0, bName));
            updateStatus();
            lstTable.ClearSelected();
            lstTable.SelectedIndex = lstTable.Items.Count - 1;
            lstTable.Focus();
        }

        private void Validate_EditTable(object sender, InputBoxValidatingArgs e)
        {
            string text = e.Text.Trim();
            if (text.Length == 0)
            {
                e.Cancel = true;
                e.Message = "Table name is required";
                return;
            }

            byte[] bName = Encoding.Unicode.GetBytes(text);

            foreach (XsdTable table in xsd[0].tableCollection.Tables)
            {
                if (Common.ByteArraysEqual(bName, table.Name))
                {
                    MessageBox.Show("Duplicate table name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (null != lstTable.SelectedItem)
            {
                XsdTable table = (XsdTable)lstTable.SelectedItem;
                table.Name = bName;
            }
            updateStatus();
        }

        private void Validate_Find(object sender, InputBoxValidatingArgs e)
        {
            string text = e.Text.Trim();
            if (text.Length == 0)
            {
                e.Cancel = true;
                return;
            }

            Find(text);
        }

        private bool Find(string text, int tableIndex = 0, int rowIndex = 0)
        {
            var bFound = false;

            if (xsd[0].tableCollection.Tables.Count < 1)
                return bFound;

            text = text.Trim();
            if (text.Length == 0)
                return bFound;

            findText = text;
            findTableIndex = tableIndex;
            findRowIndex = rowIndex;

            if (findTableIndex > xsd[0].tableCollection.Tables.Count)
                findTableIndex = 0;

            if (findRowIndex > xsd[0].tableCollection.Tables[findTableIndex].RowCollection.Rows.Count)
                findRowIndex = 0;

            for (int i = findTableIndex; i < xsd[0].tableCollection.Tables.Count; i++)
            {
                var table = xsd[0].tableCollection.Tables[i];
                for (int j = findRowIndex; j < table.RowCollection.Rows.Count; j++)
                {
                    var row = table.RowCollection.Rows[j];
                    string name = Encoding.Unicode.GetString(row.Name);

                    if (name.Contains(text))
                    {
                        lstTable.SelectedIndex = i;
                        dataTableRows.ClearSelection();
                        dataTableRows.CurrentCell = null;
                        dataTableRows.Rows[j].Selected = true;
                        dataTableRows.FirstDisplayedScrollingRowIndex = j;
                        bFound = true;
                        findTableIndex = i;
                        findRowIndex = j;
                        return bFound;
                    }
                }
            }

            findTableIndex = 0;
            findRowIndex = 0;

            return bFound;
        }


        private void btnEditTable_Click(object sender, EventArgs e)
        {
            if (null != lstTable.SelectedItem)
            {
                XsdTable table = (XsdTable)lstTable.SelectedItem;
                InputBoxResult result = InputBox.Show("Name:", "Edit table", table.UnicodeName, new InputBoxValidatingHandler(Validate_EditTable));
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (null != lstTable.SelectedItem)
            {
                if (DialogResult.Yes != MessageBox.Show("Are you sure you want to delete this table?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    return;

                dataTableRows.EndEdit();
                XsdTable table = (XsdTable)lstTable.SelectedItem;
                table.RowCollection.Rows.Clear();
                xsd[0].tableCollection.Tables.Remove(table);
            }
        }



        private void btnCancelBusy_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy &&
                backgroundWorker.WorkerSupportsCancellation)
            {
                labelBusyStatus.Text = "Cancelling...";
                backgroundWorker.CancelAsync();
            }
        }

        private void busyTablePanel_VisibleChanged(object sender, EventArgs e)
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

                statusbar.Enabled = false;
                toolbar.Enabled = false;
                menu.Enabled = false;
                splitContainer1.Panel1.Enabled = false;

                foreach (Control c in splitContainer1.Panel2.Controls)
                {
                    switch (c.Name)
                    {
                        case "busyTablePanel":
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


        // Delegate methods
        private delegate Xsd.MergeResult MergeDelegate();
        private Xsd.MergeResult DelegateMergeXsd()
        {
            return xsd[0].Merge(xsd[1], Xsd.MergeType.MatchingOnly); ;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker != null)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    try
                    {
                        e.Result = ((MergeDelegate)e.Argument).Invoke();
                    }
                    catch (Exception)
                    {
                        e.Result = null;
                        e.Cancel = true;
                    }
                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled || e.Result == null)
            {
                busyTablePanel.Visible = false;
                return;
            }

            Xsd.MergeResult result = e.Result as Xsd.MergeResult;

            switch (result.status)
            {
                    /*
                case Xsd.MergeStatus.Success:
                    MessageBox.Show("Merge was successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                     */
                case Xsd.MergeStatus.Failure:
                    MessageBox.Show("Merge failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            busyTablePanel.Visible = false;
        }

        private void matchingOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenSecondXsd())
            {
                busyTablePanel.Visible = true;

                if (backgroundWorker.IsBusy && backgroundWorker.WorkerSupportsCancellation)
                    backgroundWorker.CancelAsync();
                else
                    backgroundWorker.RunWorkerAsync(new MergeDelegate(DelegateMergeXsd));
            }
        }

        private void contextMenuExportXML_Click(object sender, EventArgs e)
        {
            if (null != lstTable.SelectedItem)
            {
                XsdTable table = (XsdTable)lstTable.SelectedItem;
                XmlDocument doc = new XmlDocument();

                char[] invalidChars = new char[] { '\t', '\r', '\n', '\x0B', '\0' };

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(table.UnicodeName.Trim(invalidChars) + ".xml", settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement(table.UnicodeName.Trim(invalidChars));

                    foreach (XsdTableRow row in table.RowCollection.Rows)
                    {
                        writer.WriteStartElement("row");
                        writer.WriteElementString("id", row.ID.ToString());
                        writer.WriteElementString("name", Encoding.Unicode.GetString(row.Name).Trim(invalidChars));
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        private void contextMenuTable_Opening(object sender, CancelEventArgs e)
        {
            contextMenuTable.Enabled = (lstTable.SelectedIndex < 0 ? false : true);
        }

        private static DialogResult SetKeysDialog(ref byte[] keys)
        {
            System.Drawing.Size size = new System.Drawing.Size(175, 95);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Set Cipher Keys";

            System.Windows.Forms.Label label1 = new Label();
            label1.Size = new System.Drawing.Size(80, 23);
            label1.Location = new System.Drawing.Point(10, 10);
            label1.Text = "Cipher Key 1:";
            inputBox.Controls.Add(label1);

            System.Windows.Forms.TextBox key1 = new TextBox();
            key1.Size = new System.Drawing.Size(75, 23);
            key1.Location = new System.Drawing.Point(90, 7);
            key1.MaxLength = 2;
            key1.TextAlign = HorizontalAlignment.Center;
            key1.Text = keys[0].ToString("X2");
            inputBox.Controls.Add(key1);

            System.Windows.Forms.Label label2 = new Label();
            label2.Size = new System.Drawing.Size(80, 23);
            label2.Location = new System.Drawing.Point(10, 37);
            label2.Text = "Cipher Key 2:";
            inputBox.Controls.Add(label2);

            System.Windows.Forms.TextBox key2 = new TextBox();
            key2.Size = new System.Drawing.Size(75, 23);
            key2.Location = new System.Drawing.Point(90, 34);
            key2.MaxLength = 2;
            key2.TextAlign = HorizontalAlignment.Center;
            key2.Text = keys[1].ToString("X2");
            inputBox.Controls.Add(key2);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 26);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(10, 62);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 26);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(90, 62);
            inputBox.Controls.Add(cancelButton);

            DialogResult result = inputBox.ShowDialog();

            if (!String.IsNullOrEmpty(key1.Text))
                keys[0] = Convert.ToByte(key1.Text, 16);
            if (!String.IsNullOrEmpty(key2.Text))
                keys[1] = Convert.ToByte(key2.Text, 16);

            return result;
        }

        private void setKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetKeysDialog(ref keys);
        }

        private void toolbtnFind_Click(object sender, EventArgs e)
        {
            InputBoxResult result = InputBox.Show("Name:", "Find", "", new InputBoxValidatingHandler(Validate_Find));
        }

        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InputBoxResult result = InputBox.Show("Name:", "Find", "", new InputBoxValidatingHandler(Validate_Find));
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find(findText, findTableIndex, findRowIndex+1);
        }
    }
}
