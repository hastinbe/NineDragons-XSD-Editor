using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NineDragons_XSD_Editor.UI
{
    public partial class FindWindow : Form
    {
        private readonly frmMain parentForm;

        public FindWindow()
        {
            InitializeComponent();
        }

        public FindWindow(frmMain parentForm)
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
    }
}
