using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERM.UI.Controls
{
   public class Skin_ContextStripEX:CCWin.SkinControl.SkinContextMenuStrip
    {
       public Skin_ContextStripEX(System.ComponentModel.IContainer components)
           : base()
       {
          base.Arrow = System.Drawing.Color.Black;
          //base.Back = System.Drawing.Color.White;
          base.BackRadius = 4;
          base.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
          base.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
          base.Fore = System.Drawing.Color.Black;
          base.HoverFore = System.Drawing.Color.Black;
          base.ItemAnamorphosis = true;
          base.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
          base.ItemBorderShow = true;
          base.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
          base.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
          base.ItemRadius = 4;
       }
    }
}
