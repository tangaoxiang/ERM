using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmChangeUserPasswd
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeUserPasswd));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.txtUserLogin = new ERM.UI.Controls.TXTextBoxEX();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.btnConfirm = new ERM.UI.Controls.SkinButtonEX();
            this.txtConfrmPasswd = new ERM.UI.Controls.TXTextBoxEX();
            this.txtNewPasswd = new ERM.UI.Controls.TXTextBoxEX();
            this.txtOldPasswd = new ERM.UI.Controls.TXTextBoxEX();
            this.label4 = new ERM.UI.Controls.SkinLabelEX();
            this.label3 = new ERM.UI.Controls.SkinLabelEX();
            this.label2 = new ERM.UI.Controls.SkinLabelEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.txtUserLogin);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.txtConfrmPasswd);
            this.panel1.Controls.Add(this.txtNewPasswd);
            this.panel1.Controls.Add(this.txtOldPasswd);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(284, 178);
            this.panel1.TabIndex = 0;
            // 
            // txtUserLogin
            // 
            this.txtUserLogin.BackColor = System.Drawing.Color.Transparent;
            this.txtUserLogin.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtUserLogin.Enabled = false;
            this.txtUserLogin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserLogin.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtUserLogin.Image = null;
            this.txtUserLogin.ImageSize = new System.Drawing.Size(0, 0);
            this.txtUserLogin.Location = new System.Drawing.Point(72, 11);
            this.txtUserLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserLogin.MaxLength = 20;
            this.txtUserLogin.Name = "txtUserLogin";
            this.txtUserLogin.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUserLogin.PasswordChar = '\0';
            this.txtUserLogin.Required = false;
            this.txtUserLogin.Size = new System.Drawing.Size(205, 25);
            this.txtUserLogin.TabIndex = 30;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnCancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnCancel.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DownBack = null;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCancel.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(171, 137);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 10;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfirm.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnConfirm.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnConfirm.BorderColor = System.Drawing.Color.Transparent;
            this.btnConfirm.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.DownBack = null;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnConfirm.GlowColor = System.Drawing.Color.Transparent;
            this.btnConfirm.InnerBorderColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(73, 137);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MouseBack = null;
            this.btnConfirm.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NormlBack = null;
            this.btnConfirm.Palace = true;
            this.btnConfirm.Radius = 10;
            this.btnConfirm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnConfirm.Size = new System.Drawing.Size(70, 28);
            this.btnConfirm.TabIndex = 28;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtConfrmPasswd
            // 
            this.txtConfrmPasswd.BackColor = System.Drawing.Color.Transparent;
            this.txtConfrmPasswd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtConfrmPasswd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConfrmPasswd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConfrmPasswd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtConfrmPasswd.Image = null;
            this.txtConfrmPasswd.ImageSize = new System.Drawing.Size(0, 0);
            this.txtConfrmPasswd.Location = new System.Drawing.Point(72, 104);
            this.txtConfrmPasswd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConfrmPasswd.MaxLength = 20;
            this.txtConfrmPasswd.Name = "txtConfrmPasswd";
            this.txtConfrmPasswd.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtConfrmPasswd.PasswordChar = '*';
            this.txtConfrmPasswd.Required = false;
            this.txtConfrmPasswd.Size = new System.Drawing.Size(205, 25);
            this.txtConfrmPasswd.TabIndex = 27;
            // 
            // txtNewPasswd
            // 
            this.txtNewPasswd.BackColor = System.Drawing.Color.Transparent;
            this.txtNewPasswd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNewPasswd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPasswd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNewPasswd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtNewPasswd.Image = null;
            this.txtNewPasswd.ImageSize = new System.Drawing.Size(0, 0);
            this.txtNewPasswd.Location = new System.Drawing.Point(72, 73);
            this.txtNewPasswd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewPasswd.MaxLength = 20;
            this.txtNewPasswd.Name = "txtNewPasswd";
            this.txtNewPasswd.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNewPasswd.PasswordChar = '*';
            this.txtNewPasswd.Required = false;
            this.txtNewPasswd.Size = new System.Drawing.Size(205, 25);
            this.txtNewPasswd.TabIndex = 26;
            // 
            // txtOldPasswd
            // 
            this.txtOldPasswd.BackColor = System.Drawing.Color.Transparent;
            this.txtOldPasswd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtOldPasswd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldPasswd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOldPasswd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtOldPasswd.Image = null;
            this.txtOldPasswd.ImageSize = new System.Drawing.Size(0, 0);
            this.txtOldPasswd.Location = new System.Drawing.Point(72, 42);
            this.txtOldPasswd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOldPasswd.MaxLength = 20;
            this.txtOldPasswd.Name = "txtOldPasswd";
            this.txtOldPasswd.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOldPasswd.PasswordChar = '*';
            this.txtOldPasswd.Required = false;
            this.txtOldPasswd.Size = new System.Drawing.Size(205, 25);
            this.txtOldPasswd.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "确认密码";
            // 
            // label3
            // 
            this.label3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "新密码";
            // 
            // label2
            // 
            this.label2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "旧密码";
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "用户名";
            // 
            // frmChangeUserPasswd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(292, 216);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(345, 256);
            this.MinimizeBox = false;
            this.Name = "frmChangeUserPasswd";
            this.ShowInTaskbar = false;
            this.Text = "修改用户密码";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmChangeUserPasswd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private Controls.TXTextBoxEX txtUserLogin;
        private Controls.SkinButtonEX btnCancel;
        private Controls.SkinButtonEX btnConfirm;
        private Controls.TXTextBoxEX txtConfrmPasswd;
        private Controls.TXTextBoxEX txtNewPasswd;
        private Controls.TXTextBoxEX txtOldPasswd;
        private Controls.SkinLabelEX label4;
        private Controls.SkinLabelEX label3;
        private Controls.SkinLabelEX label2;
        private Controls.SkinLabelEX label1;

    }
}