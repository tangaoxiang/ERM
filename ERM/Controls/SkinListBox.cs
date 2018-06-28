using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERM.UI.Controls
{
    public class SkinListBoxEX:CCWin.SkinControl.SkinListBox
    {
        public SkinListBoxEX() :base(){
           base.Back = null;
           base.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
           base.FormattingEnabled = true;
           base.HorizontalScrollbar = true;
           base.ItemHeight = 17;
           base.Margin = new System.Windows.Forms.Padding(0);
           base.SelectedColor = System.Drawing.Color.FromArgb(103,160,222);
           base.MouseColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(206)))), ((int)(((byte)(255)))));
           base.RowBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(218)))), ((int)(((byte)(242)))));
        }
    }
}
