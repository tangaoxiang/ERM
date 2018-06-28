using CCWin.SkinControl;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            this.cboLogin = new TX.Framework.WindowUI.Controls.TXComboBox();
            this.lbltitle3 = new ERM.UI.Controls.SkinLabelEX();
            this.lbltitle1 = new ERM.UI.Controls.SkinLabelEX();
            this.lblVersion = new ERM.UI.Controls.SkinLabelEX();
            this.lbltitle2 = new ERM.UI.Controls.SkinLabelEX();
            this.btnOK = new CCWin.SkinControl.SkinButton();
            this.label2 = new ERM.UI.Controls.SkinLabelEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.txtPasswd = new ERM.UI.Controls.TXTextBoxEX();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = global::ERM.UI.Properties.Resources.button3;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.BaseColor = System.Drawing.Color.Empty;
            this.btnCancel.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DownBack = null;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(458, 221);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Radius = 4;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 88;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboLogin
            // 
            this.cboLogin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboLogin.FormattingEnabled = true;
            this.cboLogin.Location = new System.Drawing.Point(375, 156);
            this.cboLogin.Name = "cboLogin";
            this.cboLogin.Size = new System.Drawing.Size(153, 25);
            this.cboLogin.TabIndex = 87;
            // 
            // lbltitle3
            // 
            this.lbltitle3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbltitle3.AutoSize = true;
            this.lbltitle3.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle3.BorderColor = System.Drawing.Color.Transparent;
            this.lbltitle3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbltitle3.ForeColor = System.Drawing.Color.Black;
            this.lbltitle3.Location = new System.Drawing.Point(356, 306);
            this.lbltitle3.Name = "lbltitle3";
            this.lbltitle3.Size = new System.Drawing.Size(15, 17);
            this.lbltitle3.TabIndex = 86;
            this.lbltitle3.Text = "3";
            // 
            // lbltitle1
            // 
            this.lbltitle1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbltitle1.AutoSize = true;
            this.lbltitle1.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle1.BorderColor = System.Drawing.Color.Transparent;
            this.lbltitle1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbltitle1.ForeColor = System.Drawing.Color.Black;
            this.lbltitle1.Location = new System.Drawing.Point(356, 264);
            this.lbltitle1.Name = "lbltitle1";
            this.lbltitle1.Size = new System.Drawing.Size(15, 17);
            this.lbltitle1.TabIndex = 85;
            this.lbltitle1.Text = "1";
            // 
            // lblVersion
            // 
            this.lblVersion.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.BorderColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVersion.ForeColor = System.Drawing.Color.Red;
            this.lblVersion.Location = new System.Drawing.Point(375, 126);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(141, 22);
            this.lblVersion.TabIndex = 84;
            this.lblVersion.Text = "版本 :";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVersion.Visible = false;
            // 
            // lbltitle2
            // 
            this.lbltitle2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbltitle2.AutoSize = true;
            this.lbltitle2.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle2.BorderColor = System.Drawing.Color.Transparent;
            this.lbltitle2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbltitle2.ForeColor = System.Drawing.Color.Black;
            this.lbltitle2.Location = new System.Drawing.Point(356, 285);
            this.lbltitle2.Name = "lbltitle2";
            this.lbltitle2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbltitle2.Size = new System.Drawing.Size(15, 17);
            this.lbltitle2.TabIndex = 83;
            this.lbltitle2.Text = "2";
            this.lbltitle2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BackgroundImage = global::ERM.UI.Properties.Resources.button3;
            this.btnOK.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnOK.BaseColor = System.Drawing.Color.Empty;
            this.btnOK.BorderColor = System.Drawing.Color.Transparent;
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DownBack = null;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(375, 221);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.MouseBack = null;
            this.btnOK.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = null;
            this.btnOK.Palace = true;
            this.btnOK.Radius = 4;
            this.btnOK.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnOK.Size = new System.Drawing.Size(70, 28);
            this.btnOK.TabIndex = 82;
            this.btnOK.Text = "登录";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(332, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 81;
            this.label2.Text = "密码 :";
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(308, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 79;
            this.label1.Text = "用户名称 :";
            // 
            // txtPasswd
            // 
            this.txtPasswd.BackColor = System.Drawing.Color.Transparent;
            this.txtPasswd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPasswd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPasswd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPasswd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtPasswd.Image = null;
            this.txtPasswd.ImageSize = new System.Drawing.Size(0, 0);
            this.txtPasswd.Location = new System.Drawing.Point(374, 188);
            this.txtPasswd.MaxLength = 20;
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtPasswd.PasswordChar = '●';
            this.txtPasswd.Required = false;
            this.txtPasswd.Size = new System.Drawing.Size(155, 25);
            this.txtPasswd.TabIndex = 80;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.BackgroundImage = global::ERM.UI.Properties.Resources.longin1;
            this.BackLayout = false;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(548, 332);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cboLogin);
            this.Controls.Add(this.lbltitle3);
            this.Controls.Add(this.lbltitle1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lbltitle2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPasswd);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ICoOffset = new System.Drawing.Point(-50, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.Radius = 10;
            this.Tag = "";
            this.Text = "";
            this.TitleCenter = true;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SkinButton btnCancel;
        private TXComboBox cboLogin;
        private Controls.SkinLabelEX lbltitle3;
        private Controls.SkinLabelEX lbltitle1;
        private Controls.SkinLabelEX lblVersion;
        private Controls.SkinLabelEX lbltitle2;
        private SkinButton btnOK;
        private Controls.SkinLabelEX label2;
        private Controls.SkinLabelEX label1;
        private Controls.TXTextBoxEX txtPasswd;








    }
}