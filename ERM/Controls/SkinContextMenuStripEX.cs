using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERM.UI.Controls
{
    public class SkinContextMenuStripEX:CCWin.SkinControl.SkinContextMenuStrip
    {
        public SkinContextMenuStripEX() : base() { setting(); }
        public SkinContextMenuStripEX(System.ComponentModel.IContainer components)
            : base()
        {

            setting();
        }

        /// <summary>
        /// 初始参数
        /// </summary>
        private void setting() {
            base.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            base.Arrow = System.Drawing.Color.Black;
            base.Back = System.Drawing.Color.White;
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
            base.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
        }
    }
}
