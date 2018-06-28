using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERM.UI.Controls
{
    public class SkinButtonEX : CCWin.SkinControl.SkinButton
    {
        public SkinButtonEX()
            : base()
        {
            //base.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            //base.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            //base.BaseColor = System.Drawing.Color.FromArgb(110, 186, 225);
            //base.BorderColor = System.Drawing.Color.SkyBlue;
            //base.ControlState = CCWin.SkinClass.ControlState.Normal;
            //base.Cursor = System.Windows.Forms.Cursors.Hand;
            //base.DownBack = null;
            //base.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //base.Font = new System.Drawing.Font("微软雅黑", 9F);
            //base.ForeColor = System.Drawing.Color.Black;
            //base.InnerBorderColor = System.Drawing.Color.White;
            //base.MouseBack = null;
            //base.MouseBaseColor = System.Drawing.Color.SkyBlue;
            //base.Palace = true;
            //base.Radius = 6;
            //base.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            base.Size = new System.Drawing.Size(70, 28);
           // base.UseVisualStyleBackColor = false;
            this.BackColor = System.Drawing.Color.Transparent;
            base.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            base.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            base.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            base.BorderColor = System.Drawing.Color.SkyBlue;
            base.ControlState = CCWin.SkinClass.ControlState.Normal;
            base.Cursor = System.Windows.Forms.Cursors.Hand;
            base.DownBack = null;
            base.FlatAppearance.BorderSize = 0;
            base.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            base.Font = new System.Drawing.Font("微软雅黑", 9F);
            base.ForeColor = System.Drawing.Color.Black;
            base.GlowColor = System.Drawing.Color.Transparent;
            base.InnerBorderColor = System.Drawing.Color.White;
            base.Location = new System.Drawing.Point(165, 437);
            base.Margin = new System.Windows.Forms.Padding(0);
            base.MouseBack = null;
            base.MouseBaseColor = System.Drawing.Color.SkyBlue;
            base.NormlBack = null;
            base.Palace = true;
            base.Radius = 10;
            base.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            base.TabStop = false;
            base.UseVisualStyleBackColor = false;
        }
    }
}
