using CCWin.SkinControl;
using ERM.UI.Controls;
using System.Windows.Forms;
namespace ERM.UI
{
    partial class frm2PDFProgressMsg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2PDFProgressMsg));
            this.panel1 = new SkinPanelEX();
            this.label2 = new SkinLabelEX();
            this.progressBar1 = new CCWin.SkinControl.SkinProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 67);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "0/5";
            // 
            // progressBar1
            // 
            this.progressBar1.Back = null;
            this.progressBar1.BackColor = System.Drawing.Color.Transparent;
            this.progressBar1.BarBack = null;
            this.progressBar1.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.progressBar1.ForeColor = System.Drawing.Color.Red;
            this.progressBar1.Location = new System.Drawing.Point(13, 26);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.progressBar1.Size = new System.Drawing.Size(493, 35);
            this.progressBar1.TabIndex = 3;
            // 
            // frm2PDFProgressMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(521, 105);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.Name = "frm2PDFProgressMsg";
            this.Text = "电子文件转换中...";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm2PDFProgressMsg_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm2PDFProgressMsg_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        public SkinLabelEX label2;
        public SkinProgressBar progressBar1;

    }
}