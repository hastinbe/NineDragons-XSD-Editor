//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.Windows.Forms;
using System.Drawing;

namespace NineDragons_XSD_Editor.Components
{
    public class DataGridViewEx : DataGridView
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Rows[this.CurrentRow.Index].ErrorText = String.Empty;
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
