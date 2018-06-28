using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERM.UI.Controls
{
    public partial class Skin_ToolStripEX : CCWin.SkinControl.SkinToolStrip
    {
        public Skin_ToolStripEX()
            : base()
        {
            base.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            base.Arrow = System.Drawing.Color.Black;
            base.AutoSize = false;
            base.Back = System.Drawing.Color.White;
            base.BackgroundImage = global::ERM.UI.Properties.Resources.top;
            base.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            base.BackRadius = 4;
            base.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            base.Base = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            base.BaseFore = System.Drawing.Color.Black;
            base.BaseForeAnamorphosis = false;
            base.BaseForeAnamorphosisBorder = 4;
            base.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            base.BaseForeOffset = new System.Drawing.Point(0, 0);
            base.BaseHoverFore = System.Drawing.Color.Black;
            base.BaseItemAnamorphosis = true;
            base.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            base.BaseItemBorderShow = true;
            base.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            base.BaseItemNorml = null;
            base.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            base.BaseItemRadius = 4;
            base.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            base.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            base.BindTabControl = null;
            base.CanOverflow = false;
            base.Dock = System.Windows.Forms.DockStyle.Top;
            base.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            base.Fore = System.Drawing.Color.Black;
            base.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            base.HoverFore = System.Drawing.Color.Black;
            base.ItemAnamorphosis = true;
            base.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            base.ItemBorderShow = true;
            base.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            base.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            base.ItemRadius = 4;
            base.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            base.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            base.SkinAllColor = true;
            base.Stretch = true;
            base.TitleAnamorphosis = true;
            base.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            base.TitleRadius = 4;
            base.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
        }
    }
}
