using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI.Project
{
    partial class frmProjectSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjectSearch));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.txt_ProjectNo = new ERM.UI.Controls.TXTextBoxEX();
            this.lbl_No = new ERM.UI.Controls.SkinLabelEX();
            this.btnSearchConfirm = new ERM.UI.Controls.SkinButtonEX();
            this.txt_ProjectName = new ERM.UI.Controls.TXTextBoxEX();
            this.lbl_ProjectName = new ERM.UI.Controls.SkinLabelEX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.txt_ProjectNo);
            this.panel1.Controls.Add(this.lbl_No);
            this.panel1.Controls.Add(this.btnSearchConfirm);
            this.panel1.Controls.Add(this.txt_ProjectName);
            this.panel1.Controls.Add(this.lbl_ProjectName);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(283, 97);
            this.panel1.TabIndex = 0;
            // 
            // txt_ProjectNo
            // 
            this.txt_ProjectNo.BackColor = System.Drawing.Color.Transparent;
            this.txt_ProjectNo.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ProjectNo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ProjectNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ProjectNo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ProjectNo.Image = null;
            this.txt_ProjectNo.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ProjectNo.Location = new System.Drawing.Point(73, 4);
            this.txt_ProjectNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_ProjectNo.MaxLength = 30;
            this.txt_ProjectNo.Name = "txt_ProjectNo";
            this.txt_ProjectNo.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ProjectNo.PasswordChar = '\0';
            this.txt_ProjectNo.Required = false;
            this.txt_ProjectNo.Size = new System.Drawing.Size(203, 25);
            this.txt_ProjectNo.TabIndex = 12;
            this.txt_ProjectNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ProjectNo_KeyDown);
            // 
            // lbl_No
            // 
            this.lbl_No.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbl_No.AutoSize = true;
            this.lbl_No.BackColor = System.Drawing.Color.Transparent;
            this.lbl_No.BorderColor = System.Drawing.Color.Transparent;
            this.lbl_No.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_No.ForeColor = System.Drawing.Color.Black;
            this.lbl_No.Location = new System.Drawing.Point(11, 8);
            this.lbl_No.Name = "lbl_No";
            this.lbl_No.Size = new System.Drawing.Size(56, 17);
            this.lbl_No.TabIndex = 13;
            this.lbl_No.Text = "工程编号";
            // 
            // btnSearchConfirm
            // 
            this.btnSearchConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearchConfirm.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnSearchConfirm.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnSearchConfirm.BorderColor = System.Drawing.Color.Transparent;
            this.btnSearchConfirm.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSearchConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchConfirm.DownBack = null;
            this.btnSearchConfirm.FlatAppearance.BorderSize = 0;
            this.btnSearchConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchConfirm.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSearchConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnSearchConfirm.GlowColor = System.Drawing.Color.Transparent;
            this.btnSearchConfirm.InnerBorderColor = System.Drawing.Color.White;
            this.btnSearchConfirm.Location = new System.Drawing.Point(154, 64);
            this.btnSearchConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearchConfirm.MouseBack = null;
            this.btnSearchConfirm.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnSearchConfirm.Name = "btnSearchConfirm";
            this.btnSearchConfirm.NormlBack = null;
            this.btnSearchConfirm.Palace = true;
            this.btnSearchConfirm.Radius = 10;
            this.btnSearchConfirm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSearchConfirm.Size = new System.Drawing.Size(122, 27);
            this.btnSearchConfirm.TabIndex = 11;
            this.btnSearchConfirm.TabStop = false;
            this.btnSearchConfirm.Text = "查找下一个";
            this.btnSearchConfirm.UseVisualStyleBackColor = false;
            this.btnSearchConfirm.Click += new System.EventHandler(this.btnSearchConfirm_Click);
            // 
            // txt_ProjectName
            // 
            this.txt_ProjectName.BackColor = System.Drawing.Color.Transparent;
            this.txt_ProjectName.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ProjectName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ProjectName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ProjectName.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ProjectName.Image = null;
            this.txt_ProjectName.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ProjectName.Location = new System.Drawing.Point(73, 35);
            this.txt_ProjectName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_ProjectName.MaxLength = 30;
            this.txt_ProjectName.Name = "txt_ProjectName";
            this.txt_ProjectName.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ProjectName.PasswordChar = '\0';
            this.txt_ProjectName.Required = false;
            this.txt_ProjectName.Size = new System.Drawing.Size(203, 25);
            this.txt_ProjectName.TabIndex = 9;
            // 
            // lbl_ProjectName
            // 
            this.lbl_ProjectName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbl_ProjectName.AutoSize = true;
            this.lbl_ProjectName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ProjectName.BorderColor = System.Drawing.Color.Transparent;
            this.lbl_ProjectName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ProjectName.ForeColor = System.Drawing.Color.Black;
            this.lbl_ProjectName.Location = new System.Drawing.Point(11, 39);
            this.lbl_ProjectName.Name = "lbl_ProjectName";
            this.lbl_ProjectName.Size = new System.Drawing.Size(56, 17);
            this.lbl_ProjectName.TabIndex = 10;
            this.lbl_ProjectName.Text = "工程名称";
            // 
            // frmProjectSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(291, 135);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProjectSearch";
            this.ShowInTaskbar = false;
            this.Text = "快速查找";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmProjectSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private Controls.TXTextBoxEX txt_ProjectNo;
        private Controls.SkinLabelEX lbl_No;
        private Controls.SkinButtonEX btnSearchConfirm;
        private Controls.TXTextBoxEX txt_ProjectName;
        private Controls.SkinLabelEX lbl_ProjectName;

    }
}