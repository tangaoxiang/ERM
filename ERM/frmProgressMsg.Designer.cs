using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    partial class frmProgressMsg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProgressMsg));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.btn_Cancel = new ERM.UI.Controls.SkinButtonEX();
            this.lbl_Message = new ERM.UI.Controls.SkinLabelEX();
            this.pbProcess = new CCWin.SkinControl.SkinProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.lbl_Message);
            this.panel1.Controls.Add(this.pbProcess);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(577, 81);
            this.panel1.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.BackgroundImage")));
            this.btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Cancel.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btn_Cancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btn_Cancel.BorderColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.DownBack = null;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.GlowColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.InnerBorderColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(500, 48);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Cancel.MouseBack = null;
            this.btn_Cancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.NormlBack = null;
            this.btn_Cancel.Palace = true;
            this.btn_Cancel.Radius = 10;
            this.btn_Cancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btn_Cancel.Size = new System.Drawing.Size(70, 28);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.TabStop = false;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_Message
            // 
            this.lbl_Message.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Message.BorderColor = System.Drawing.Color.Transparent;
            this.lbl_Message.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Message.ForeColor = System.Drawing.Color.Black;
            this.lbl_Message.Location = new System.Drawing.Point(9, 49);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(43, 17);
            this.lbl_Message.TabIndex = 11;
            this.lbl_Message.Text = "label1";
            // 
            // pbProcess
            // 
            this.pbProcess.Back = null;
            this.pbProcess.BackColor = System.Drawing.Color.Transparent;
            this.pbProcess.BarBack = null;
            this.pbProcess.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.pbProcess.ForeColor = System.Drawing.Color.Red;
            this.pbProcess.Location = new System.Drawing.Point(12, 8);
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.pbProcess.Size = new System.Drawing.Size(558, 33);
            this.pbProcess.TabIndex = 10;
            // 
            // frmProgressMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.ClientSize = new System.Drawing.Size(585, 119);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProgressMsg";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProgressMsg_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private SkinButtonEX btn_Cancel;
        public SkinLabelEX lbl_Message;
        public SkinProgressBar pbProcess;


    }
}