using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NineDragons_XSD_Editor.UI
{
    public partial class InputKeyDialog : Form
    {
        private byte[] keys;

        public InputKeyDialog()
        {
            InitializeComponent();
        }

        public InputKeyDialog(ref byte[] keys)
            : this()
        {
            this.keys = keys;
            key1.Text = keys[0].ToString("X2");
            key2.Text = keys[1].ToString("X2");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(key1.Text)) keys[0] = Convert.ToByte(key1.Text, 16);
            if (!String.IsNullOrEmpty(key2.Text)) keys[1] = Convert.ToByte(key2.Text, 16);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
