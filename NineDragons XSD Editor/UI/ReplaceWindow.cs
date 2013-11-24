using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NineDragons_XSD_Editor.UI
{
    public partial class ReplaceWindow : Form
    {
        private readonly frmMain parentForm;

        public ReplaceWindow()
        {
            InitializeComponent();
        }

        public ReplaceWindow(frmMain parentForm)
            : this()
        {
            this.parentForm = parentForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            parentForm.FindNext(txtFind.Text);
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                parentForm.FindNext(txtFind.Text);
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (parentForm.lastfindText == txtFind.Text
                && parentForm.findSectionIndex == 0
                && parentForm.findRowIndex == 0
                && parentForm.findColumnIndex == 0)
            {
                parentForm.FindNext(txtFind.Text);
            }
            else
            {
                parentForm.Replace(txtFind.Text, txtReplace.Text);
            }
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            parentForm.Replace(txtFind.Text, txtReplace.Text, true);
        }
    }
}