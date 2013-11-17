//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
namespace NineDragons_XSD_Editor
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.contextMenuTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportXML = new System.Windows.Forms.ToolStripMenuItem();
            this.flowSectionControls = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.btnEditTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.busyTablePanel = new System.Windows.Forms.Panel();
            this.progressIndicator = new ProgressControls.ProgressIndicator();
            this.labelBusyStatus = new System.Windows.Forms.Label();
            this.btnCancelBusy = new System.Windows.Forms.Button();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.toollblNumTable = new System.Windows.Forms.ToolStripStatusLabel();
            this.toollblNumRow = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnMerge = new System.Windows.Forms.ToolStripDropDownButton();
            this.matchingOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstTable = new NineDragons_XSD_Editor.Components.ListBoxEx();
            this.dataTableRows = new NineDragons_XSD_Editor.Components.DataGridViewEx();
            this.saveWithEncryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuTable.SuspendLayout();
            this.flowSectionControls.SuspendLayout();
            this.busyTablePanel.SuspendLayout();
            this.layout.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRows)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.busyTablePanel);
            this.splitContainer1.Panel2.Controls.Add(this.dataTableRows);
            this.splitContainer1.Size = new System.Drawing.Size(738, 352);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lstTable);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowSectionControls);
            this.splitContainer2.Size = new System.Drawing.Size(246, 352);
            this.splitContainer2.SplitterDistance = 321;
            this.splitContainer2.TabIndex = 1;
            // 
            // contextMenuTable
            // 
            this.contextMenuTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuExport});
            this.contextMenuTable.Name = "contextMenuTable";
            this.contextMenuTable.Size = new System.Drawing.Size(108, 26);
            this.contextMenuTable.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuTable_Opening);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuExportXML});
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(107, 22);
            this.contextMenuExport.Text = "Export";
            // 
            // contextMenuExportXML
            // 
            this.contextMenuExportXML.Name = "contextMenuExportXML";
            this.contextMenuExportXML.Size = new System.Drawing.Size(98, 22);
            this.contextMenuExportXML.Text = "XML";
            this.contextMenuExportXML.Click += new System.EventHandler(this.contextMenuExportXML_Click);
            // 
            // flowSectionControls
            // 
            this.flowSectionControls.Controls.Add(this.btnAddTable);
            this.flowSectionControls.Controls.Add(this.btnEditTable);
            this.flowSectionControls.Controls.Add(this.btnDeleteTable);
            this.flowSectionControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSectionControls.Location = new System.Drawing.Point(0, 0);
            this.flowSectionControls.Margin = new System.Windows.Forms.Padding(0);
            this.flowSectionControls.Name = "flowSectionControls";
            this.flowSectionControls.Size = new System.Drawing.Size(246, 27);
            this.flowSectionControls.TabIndex = 0;
            // 
            // btnAddTable
            // 
            this.btnAddTable.Image = global::NineDragons_XSD_Editor.Properties.Resources.add;
            this.btnAddTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTable.Location = new System.Drawing.Point(0, 0);
            this.btnAddTable.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnAddTable.Size = new System.Drawing.Size(56, 26);
            this.btnAddTable.TabIndex = 0;
            this.btnAddTable.Text = "Add";
            this.btnAddTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // btnEditTable
            // 
            this.btnEditTable.Enabled = false;
            this.btnEditTable.Image = global::NineDragons_XSD_Editor.Properties.Resources.edit;
            this.btnEditTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditTable.Location = new System.Drawing.Point(56, 0);
            this.btnEditTable.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditTable.Name = "btnEditTable";
            this.btnEditTable.Size = new System.Drawing.Size(67, 26);
            this.btnEditTable.TabIndex = 2;
            this.btnEditTable.Text = "Edit...";
            this.btnEditTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditTable.UseVisualStyleBackColor = true;
            this.btnEditTable.Click += new System.EventHandler(this.btnEditTable_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Enabled = false;
            this.btnDeleteTable.Image = global::NineDragons_XSD_Editor.Properties.Resources.delete;
            this.btnDeleteTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteTable.Location = new System.Drawing.Point(123, 0);
            this.btnDeleteTable.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnDeleteTable.Size = new System.Drawing.Size(72, 26);
            this.btnDeleteTable.TabIndex = 1;
            this.btnDeleteTable.Text = "Delete";
            this.btnDeleteTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // busyTablePanel
            // 
            this.busyTablePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.busyTablePanel.BackColor = System.Drawing.SystemColors.Control;
            this.busyTablePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.busyTablePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.busyTablePanel.Controls.Add(this.progressIndicator);
            this.busyTablePanel.Controls.Add(this.labelBusyStatus);
            this.busyTablePanel.Controls.Add(this.btnCancelBusy);
            this.busyTablePanel.Location = new System.Drawing.Point(168, 132);
            this.busyTablePanel.Name = "busyTablePanel";
            this.busyTablePanel.Size = new System.Drawing.Size(185, 80);
            this.busyTablePanel.TabIndex = 7;
            this.busyTablePanel.Visible = false;
            this.busyTablePanel.VisibleChanged += new System.EventHandler(this.busyTablePanel_VisibleChanged);
            // 
            // progressIndicator
            // 
            this.progressIndicator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressIndicator.Location = new System.Drawing.Point(3, 2);
            this.progressIndicator.Name = "progressIndicator";
            this.progressIndicator.Size = new System.Drawing.Size(32, 32);
            this.progressIndicator.TabIndex = 2;
            this.progressIndicator.Text = "progressIndicator";
            // 
            // labelBusyStatus
            // 
            this.labelBusyStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBusyStatus.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBusyStatus.Location = new System.Drawing.Point(49, 10);
            this.labelBusyStatus.Name = "labelBusyStatus";
            this.labelBusyStatus.Size = new System.Drawing.Size(126, 18);
            this.labelBusyStatus.TabIndex = 3;
            this.labelBusyStatus.Text = "Please wait...";
            // 
            // btnCancelBusy
            // 
            this.btnCancelBusy.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelBusy.Image = global::NineDragons_XSD_Editor.Properties.Resources.delete;
            this.btnCancelBusy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelBusy.Location = new System.Drawing.Point(59, 41);
            this.btnCancelBusy.Name = "btnCancelBusy";
            this.btnCancelBusy.Size = new System.Drawing.Size(69, 29);
            this.btnCancelBusy.TabIndex = 4;
            this.btnCancelBusy.Text = "&Cancel";
            this.btnCancelBusy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelBusy.UseVisualStyleBackColor = false;
            this.btnCancelBusy.Click += new System.EventHandler(this.btnCancelBusy_Click);
            // 
            // layout
            // 
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.Controls.Add(this.statusbar, 0, 2);
            this.layout.Controls.Add(this.toolbar, 0, 0);
            this.layout.Controls.Add(this.splitContainer1, 0, 1);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 24);
            this.layout.Name = "layout";
            this.layout.RowCount = 3;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout.Size = new System.Drawing.Size(744, 406);
            this.layout.TabIndex = 3;
            // 
            // statusbar
            // 
            this.statusbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toollblNumTable,
            this.toollblNumRow});
            this.statusbar.Location = new System.Drawing.Point(0, 382);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(744, 24);
            this.statusbar.TabIndex = 4;
            this.statusbar.Text = "statusStrip1";
            // 
            // toollblNumTable
            // 
            this.toollblNumTable.Name = "toollblNumTable";
            this.toollblNumTable.Size = new System.Drawing.Size(0, 19);
            // 
            // toollblNumRow
            // 
            this.toollblNumRow.Name = "toollblNumRow";
            this.toollblNumRow.Size = new System.Drawing.Size(0, 19);
            // 
            // toolbar
            // 
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnOpen,
            this.toolbtnSave,
            this.toolStripSeparator1,
            this.toolbtnMerge});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(744, 24);
            this.toolbar.TabIndex = 3;
            this.toolbar.Text = "toolStrip1";
            // 
            // toolbtnOpen
            // 
            this.toolbtnOpen.Image = global::NineDragons_XSD_Editor.Properties.Resources.fileopen;
            this.toolbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnOpen.Name = "toolbtnOpen";
            this.toolbtnOpen.Size = new System.Drawing.Size(65, 21);
            this.toolbtnOpen.Text = "Open...";
            this.toolbtnOpen.Click += new System.EventHandler(this.toolbtnOpen_Click);
            // 
            // toolbtnSave
            // 
            this.toolbtnSave.Enabled = false;
            this.toolbtnSave.Image = global::NineDragons_XSD_Editor.Properties.Resources.save;
            this.toolbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSave.Name = "toolbtnSave";
            this.toolbtnSave.Size = new System.Drawing.Size(51, 21);
            this.toolbtnSave.Text = "Save";
            this.toolbtnSave.Click += new System.EventHandler(this.toolbtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
            // 
            // toolbtnMerge
            // 
            this.toolbtnMerge.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matchingOnlyToolStripMenuItem});
            this.toolbtnMerge.Enabled = false;
            this.toolbtnMerge.Image = global::NineDragons_XSD_Editor.Properties.Resources.merge;
            this.toolbtnMerge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnMerge.Name = "toolbtnMerge";
            this.toolbtnMerge.Size = new System.Drawing.Size(70, 21);
            this.toolbtnMerge.Text = "Merge";
            // 
            // matchingOnlyToolStripMenuItem
            // 
            this.matchingOnlyToolStripMenuItem.Name = "matchingOnlyToolStripMenuItem";
            this.matchingOnlyToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.matchingOnlyToolStripMenuItem.Text = "Matching Only...";
            this.matchingOnlyToolStripMenuItem.Click += new System.EventHandler(this.matchingOnlyToolStripMenuItem_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(744, 24);
            this.menu.TabIndex = 4;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveWithEncryptionToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::NineDragons_XSD_Editor.Properties.Resources.fileopen;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = global::NineDragons_XSD_Editor.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setKeysToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // setKeysToolStripMenuItem
            // 
            this.setKeysToolStripMenuItem.Name = "setKeysToolStripMenuItem";
            this.setKeysToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.setKeysToolStripMenuItem.Text = "Set Cipher Keys";
            this.setKeysToolStripMenuItem.Click += new System.EventHandler(this.setKeysToolStripMenuItem_Click);
            // 
            // lstTable
            // 
            this.lstTable.ContextMenuStrip = this.contextMenuTable;
            this.lstTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstTable.FormattingEnabled = true;
            this.lstTable.ItemHeight = 18;
            this.lstTable.Location = new System.Drawing.Point(0, 0);
            this.lstTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstTable.Name = "lstTable";
            this.lstTable.Size = new System.Drawing.Size(246, 321);
            this.lstTable.TabIndex = 0;
            this.lstTable.SelectedIndexChanged += new System.EventHandler(this.lstTable_SelectedIndexChanged);
            // 
            // dataTableRows
            // 
            this.dataTableRows.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataTableRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableRows.Enabled = false;
            this.dataTableRows.Location = new System.Drawing.Point(0, 0);
            this.dataTableRows.Name = "dataTableRows";
            this.dataTableRows.Size = new System.Drawing.Size(488, 352);
            this.dataTableRows.TabIndex = 1;
            this.dataTableRows.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableRows_CellEndEdit);
            this.dataTableRows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataTableRows_CellFormatting);
            this.dataTableRows.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataTableRows_CellParsing);
            this.dataTableRows.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataTableRows_CellValidating);
            // 
            // saveWithEncryptionToolStripMenuItem
            // 
            this.saveWithEncryptionToolStripMenuItem.Name = "saveWithEncryptionToolStripMenuItem";
            this.saveWithEncryptionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveWithEncryptionToolStripMenuItem.Text = "Save with Encryption";
            this.saveWithEncryptionToolStripMenuItem.Click += new System.EventHandler(this.saveWithEncryptionToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 430);
            this.Controls.Add(this.layout);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "9Dragons XSD Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuTable.ResumeLayout(false);
            this.flowSectionControls.ResumeLayout(false);
            this.busyTablePanel.ResumeLayout(false);
            this.layout.ResumeLayout(false);
            this.layout.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NineDragons_XSD_Editor.Components.ListBoxEx lstTable;
        private NineDragons_XSD_Editor.Components.DataGridViewEx dataTableRows;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolbtnSave;
        private System.Windows.Forms.ToolStripStatusLabel toollblNumTable;
        private System.Windows.Forms.ToolStripStatusLabel toollblNumRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolbtnOpen;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowSectionControls;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button btnEditTable;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Panel busyTablePanel;
        private ProgressControls.ProgressIndicator progressIndicator;
        private System.Windows.Forms.Label labelBusyStatus;
        private System.Windows.Forms.Button btnCancelBusy;
        private System.Windows.Forms.ToolStripDropDownButton toolbtnMerge;
        private System.Windows.Forms.ToolStripMenuItem matchingOnlyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuTable;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExportXML;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWithEncryptionToolStripMenuItem;
    }
}

