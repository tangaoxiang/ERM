using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TX.Framework.WindowUI.Forms
{
    public class SkinButton : CCWin.SkinControl.SkinButton
    {
        public SkinButton()
            : base()
        {
            base.BackColor = System.Drawing.Color.SkyBlue;
            base.BackgroundImage = global::TX.Framework.WindowUI.Properties.Resources.button;
            base.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            base.BaseColor = System.Drawing.Color.Empty;
            base.BorderColor = System.Drawing.Color.Transparent;
            base.ControlState = CCWin.SkinClass.ControlState.Normal;
            base.Cursor = System.Windows.Forms.Cursors.Hand;
            base.DownBack = null;
            base.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            base.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            base.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            base.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            base.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            base.Margin = new System.Windows.Forms.Padding(0);
            base.MouseBack = null;
            base.MouseBaseColor = System.Drawing.Color.SkyBlue;
            base.NormlBack = null;
            base.Palace = true;
            base.Radius = 10;
            base.UseVisualStyleBackColor = false;
        }
    }
}
