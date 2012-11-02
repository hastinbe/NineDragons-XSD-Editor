//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.Windows.Forms;
using System.Drawing;

namespace NineDragons_XSD_Editor.Components
{
    public class ListBoxEx : ListBox
    {
        public Image ItemImage = null;
        public RectangleF ItemImagePadding = new RectangleF(4, 0, 32, 32);
        private bool[] hasDrawnImage = new bool[255];

        public ListBoxEx()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable; // We're using custom drawing.
            this.ItemHeight = 40; // Set the item height to 40.
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // Make sure we're not trying to draw something that isn't there.
            if (e.Index >= this.Items.Count || e.Index <= -1)
                return;

            // Get the item object.
            object item = this.Items[e.Index];
            if (item == null)
                return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            // Draw the item
            string text = item.ToString();
            RectangleF textPos = e.Bounds;

            if (ItemImage != null)
            {
                e.Graphics.DrawImage(ItemImage, e.Bounds.X + ItemImagePadding.X,
                    (e.Bounds.Bottom + e.Bounds.Top) / 2 - ItemImage.PhysicalDimension.Height / 2);
                textPos.X += ItemImage.PhysicalDimension.Width + ItemImagePadding.X * 2;
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.DrawString(text, this.Font, new SolidBrush(Color.White), textPos);
            }
            else
            {
                e.Graphics.DrawString(text, this.Font, new SolidBrush(Color.Black), textPos);
            }
        }
    }
}
