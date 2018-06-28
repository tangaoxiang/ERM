using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ERM.UI.Controls
{
    /// <summary>
    /// 继承CSKIN窗体皮肤的公共类
    /// </summary>
    public class Skin_DevEX : CCWin.Skin_DevExpress
    {
        public Skin_DevEX()
            : base()
        {
            base.Font = new System.Drawing.Font("微软雅黑",9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            base.ForeColor = System.Drawing.Color.Black;
            base.Radius = 8;
            base.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            base.Shadow = true;
            base.ShadowWidth = 5;
            base.SkinOpacity = 1;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            base.Special = true;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            base.TitleCenter = false;
            //base.TitleColor = Color.Gainsboro;
            //base.Resize+=Skin_DevEX_Resize;
            base.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            base.BackgroundImage = Properties.Resources.panel2_BackgroundImage;
            base.BackgroundImageLayout = ImageLayout.Stretch;
        }

        /// <summary>
        /// 双缓冲消除窗体闪烁
        /// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //       // cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}


        /// <summary>
        /// 改变窗体大小时重绘控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Skin_DevEX_Resize(object sender, EventArgs e)
        {
           // base.Update();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Skin_DevEX));
            this.SuspendLayout();
            // 
            // Skin_DevEX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(459, 305);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Skin_DevEX";
            this.Load += new System.EventHandler(this.Skin_DevEX_Load);
            this.Shown += new System.EventHandler(this.Skin_DevEX_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Skin_DevEX_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Skin_DevEX_KeyPress);
            this.ResumeLayout(false);

        }

        private void Skin_DevEX_Shown(object sender, EventArgs e)
        {
           
        }

        private void Skin_DevEX_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Skin_DevEX_Load(object sender, EventArgs e)
        {

        }

        private void Skin_DevEX_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
