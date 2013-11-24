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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowSectionControls = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddSection = new System.Windows.Forms.Button();
            this.btnEditSection = new System.Windows.Forms.Button();
            this.btnDeleteSection = new System.Windows.Forms.Button();
            this.busySectionPanel = new System.Windows.Forms.Panel();
            this.progressIndicator = new ProgressControls.ProgressIndicator();
            this.labelBusyStatus = new System.Windows.Forms.Label();
            this.btnCancelBusy = new System.Windows.Forms.Button();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.toollblNumSection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toollblNumRow = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnMerge = new System.Windows.Forms.ToolStripDropDownButton();
            this.matchingOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbtnFind = new System.Windows.Forms.ToolStripButton();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWithEncryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lstSection = new NineDragons_XSD_Editor.Components.ListBoxEx();
            this.dataSectionRows = new NineDragons_XSD_Editor.Components.DataGridViewEx();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowSectionControls.SuspendLayout();
            this.busySectionPanel.SuspendLayout();
            this.layout.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSectionRows)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.busySectionPanel);
            this.splitContainer1.Panel2.Controls.Add(this.dataSectionRows);
            this.splitContainer1.Size = new System.Drawing.Size(1110, 469);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.SplitterWidth = 3;
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
            this.splitContainer2.Panel1.Controls.Add(this.lstSection);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowSectionControls);
            this.splitContainer2.Size = new System.Drawing.Size(212, 469);
            this.splitContainer2.SplitterDistance = 432;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 1;
            // 
            // flowSectionControls
            // 
            this.flowSectionControls.Controls.Add(this.btnAddSection);
            this.flowSectionControls.Controls.Add(this.btnEditSection);
            this.flowSectionControls.Controls.Add(this.btnDeleteSection);
            this.flowSectionControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSectionControls.Location = new System.Drawing.Point(0, 0);
            this.flowSectionControls.Margin = new System.Windows.Forms.Padding(0);
            this.flowSectionControls.Name = "flowSectionControls";
            this.flowSectionControls.Size = new System.Drawing.Size(212, 31);
            this.flowSectionControls.TabIndex = 0;
            // 
            // btnAddSection
            // 
            this.btnAddSection.Enabled = false;
            this.btnAddSection.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSection.Image")));
            this.btnAddSection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSection.Location = new System.Drawing.Point(0, 0);
            this.btnAddSection.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddSection.Name = "btnAddSection";
            this.btnAddSection.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnAddSection.Size = new System.Drawing.Size(56, 26);
            this.btnAddSection.TabIndex = 0;
            this.btnAddSection.Text = "Add";
            this.btnAddSection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddSection.UseVisualStyleBackColor = true;
            this.btnAddSection.Click += new System.EventHandler(this.btnAddSection_Click);
            // 
            // btnEditSection
            // 
            this.btnEditSection.Enabled = false;
            this.btnEditSection.Image = ((System.Drawing.Image)(resources.GetObject("btnEditSection.Image")));
            this.btnEditSection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditSection.Location = new System.Drawing.Point(56, 0);
            this.btnEditSection.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditSection.Name = "btnEditSection";
            this.btnEditSection.Size = new System.Drawing.Size(66, 26);
            this.btnEditSection.TabIndex = 2;
            this.btnEditSection.Text = "Edit...";
            this.btnEditSection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditSection.UseVisualStyleBackColor = true;
            this.btnEditSection.Click += new System.EventHandler(this.btnEditSection_Click);
            // 
            // btnDeleteSection
            // 
            this.btnDeleteSection.Enabled = false;
            this.btnDeleteSection.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSection.Image")));
            this.btnDeleteSection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteSection.Location = new System.Drawing.Point(122, 0);
            this.btnDeleteSection.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteSection.Name = "btnDeleteSection";
            this.btnDeleteSection.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnDeleteSection.Size = new System.Drawing.Size(72, 26);
            this.btnDeleteSection.TabIndex = 1;
            this.btnDeleteSection.Text = "Delete";
            this.btnDeleteSection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteSection.UseVisualStyleBackColor = true;
            this.btnDeleteSection.Click += new System.EventHandler(this.btnDeleteSection_Click);
            // 
            // busySectionPanel
            // 
            this.busySectionPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.busySectionPanel.BackColor = System.Drawing.SystemColors.Control;
            this.busySectionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.busySectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.busySectionPanel.Controls.Add(this.progressIndicator);
            this.busySectionPanel.Controls.Add(this.labelBusyStatus);
            this.busySectionPanel.Controls.Add(this.btnCancelBusy);
            this.busySectionPanel.Location = new System.Drawing.Point(346, 203);
            this.busySectionPanel.Name = "busySectionPanel";
            this.busySectionPanel.Size = new System.Drawing.Size(185, 80);
            this.busySectionPanel.TabIndex = 7;
            this.busySectionPanel.Visible = false;
            this.busySectionPanel.VisibleChanged += new System.EventHandler(this.busySectionPanel_VisibleChanged);
            // 
            // progressIndicator
            // 
            this.progressIndicator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressIndicator.Location = new System.Drawing.Point(3, 3);
            this.progressIndicator.Name = "progressIndicator";
            this.progressIndicator.Size = new System.Drawing.Size(36, 36);
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
            this.btnCancelBusy.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelBusy.Image")));
            this.btnCancelBusy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelBusy.Location = new System.Drawing.Point(59, 42);
            this.btnCancelBusy.Name = "btnCancelBusy";
            this.btnCancelBusy.Size = new System.Drawing.Size(69, 30);
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
            this.layout.Location = new System.Drawing.Point(0, 25);
            this.layout.Name = "layout";
            this.layout.RowCount = 3;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.layout.Size = new System.Drawing.Size(1116, 523);
            this.layout.TabIndex = 3;
            // 
            // statusbar
            // 
            this.statusbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toollblNumSection,
            this.toollblNumRow});
            this.statusbar.Location = new System.Drawing.Point(0, 499);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(1116, 24);
            this.statusbar.TabIndex = 4;
            this.statusbar.Text = "statusStrip1";
            // 
            // toollblNumSection
            // 
            this.toollblNumSection.Name = "toollblNumSection";
            this.toollblNumSection.Size = new System.Drawing.Size(0, 19);
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
            this.toolbtnMerge,
            this.toolbtnFind});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(1116, 24);
            this.toolbar.TabIndex = 3;
            this.toolbar.Text = "toolStrip1";
            // 
            // toolbtnOpen
            // 
            this.toolbtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnOpen.Image")));
            this.toolbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnOpen.Name = "toolbtnOpen";
            this.toolbtnOpen.Size = new System.Drawing.Size(65, 21);
            this.toolbtnOpen.Text = "Open...";
            this.toolbtnOpen.Click += new System.EventHandler(this.toolbtnOpen_Click);
            // 
            // toolbtnSave
            // 
            this.toolbtnSave.Enabled = false;
            this.toolbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnSave.Image")));
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
            this.toolbtnMerge.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnMerge.Image")));
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
            // toolbtnFind
            // 
            this.toolbtnFind.Enabled = false;
            this.toolbtnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnFind.Name = "toolbtnFind";
            this.toolbtnFind.Size = new System.Drawing.Size(34, 21);
            this.toolbtnFind.Text = "Find";
            this.toolbtnFind.Click += new System.EventHandler(this.toolbtnFind_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.findToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menu.Size = new System.Drawing.Size(1116, 25);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
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
            // saveWithEncryptionToolStripMenuItem
            // 
            this.saveWithEncryptionToolStripMenuItem.Enabled = false;
            this.saveWithEncryptionToolStripMenuItem.Name = "saveWithEncryptionToolStripMenuItem";
            this.saveWithEncryptionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveWithEncryptionToolStripMenuItem.Text = "Save with Encryption";
            this.saveWithEncryptionToolStripMenuItem.Click += new System.EventHandler(this.saveWithEncryptionToolStripMenuItem_Click);
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
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setKeysToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 19);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // setKeysToolStripMenuItem
            // 
            this.setKeysToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("setKeysToolStripMenuItem.Image")));
            this.setKeysToolStripMenuItem.Name = "setKeysToolStripMenuItem";
            this.setKeysToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.setKeysToolStripMenuItem.Text = "Set Cipher Keys";
            this.setKeysToolStripMenuItem.Click += new System.EventHandler(this.setKeysToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem1,
            this.findNextToolStripMenuItem,
            this.replaceToolStripMenuItem});
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(42, 19);
            this.findToolStripMenuItem.Text = "Find";
            // 
            // findToolStripMenuItem1
            // 
            this.findToolStripMenuItem1.Enabled = false;
            this.findToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("findToolStripMenuItem1.Image")));
            this.findToolStripMenuItem1.Name = "findToolStripMenuItem1";
            this.findToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.findToolStripMenuItem1.Text = "Find...";
            this.findToolStripMenuItem1.Click += new System.EventHandler(this.findToolStripMenuItem1_Click);
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.Enabled = false;
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            this.findNextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.findNextToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.findNextToolStripMenuItem.Text = "Find Next";
            this.findNextToolStripMenuItem.Click += new System.EventHandler(this.findNextToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Enabled = false;
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.replaceToolStripMenuItem.Text = "Replace...";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
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
            // 
            // lstSection
            // 
            this.lstSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstSection.FormattingEnabled = true;
            this.lstSection.ItemHeight = 18;
            this.lstSection.Location = new System.Drawing.Point(0, 0);
            this.lstSection.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lstSection.Name = "lstSection";
            this.lstSection.Size = new System.Drawing.Size(212, 432);
            this.lstSection.TabIndex = 0;
            this.lstSection.SelectedIndexChanged += new System.EventHandler(this.lstSection_SelectedIndexChanged);
            // 
            // dataSectionRows
            // 
            this.dataSectionRows.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataSectionRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSectionRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSectionRows.Enabled = false;
            this.dataSectionRows.Location = new System.Drawing.Point(0, 0);
            this.dataSectionRows.Name = "dataSectionRows";
            this.dataSectionRows.Size = new System.Drawing.Size(895, 469);
            this.dataSectionRows.TabIndex = 1;
            this.dataSectionRows.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSectionRows_CellEndEdit);
            this.dataSectionRows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataSectionRows_CellFormatting);
            this.dataSectionRows.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataSectionRows_CellParsing);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 548);
            this.Controls.Add(this.layout);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmMain";
            this.Text = "9Dragons XSD Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.flowSectionControls.ResumeLayout(false);
            this.busySectionPanel.ResumeLayout(false);
            this.layout.ResumeLayout(false);
            this.layout.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSectionRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NineDragons_XSD_Editor.Components.ListBoxEx lstSection;
        private NineDragons_XSD_Editor.Components.DataGridViewEx dataSectionRows;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolbtnSave;
        private System.Windows.Forms.ToolStripStatusLabel toollblNumSection;
        private System.Windows.Forms.ToolStripStatusLabel toollblNumRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolbtnOpen;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowSectionControls;
        private System.Windows.Forms.Button btnAddSection;
        private System.Windows.Forms.Button btnDeleteSection;
        private System.Windows.Forms.Button btnEditSection;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Panel busySectionPanel;
        private ProgressControls.ProgressIndicator progressIndicator;
        private System.Windows.Forms.Label labelBusyStatus;
        private System.Windows.Forms.Button btnCancelBusy;
        private System.Windows.Forms.ToolStripDropDownButton toolbtnMerge;
        private System.Windows.Forms.ToolStripMenuItem matchingOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWithEncryptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolbtnFind;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem findNextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
    }
}

