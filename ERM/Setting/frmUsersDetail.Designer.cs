using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmUsersDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsersDetail));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.cmbUnits = new ERM.UI.Controls.TXTextBoxEX();
            this.txtFullname = new ERM.UI.Controls.TXTextBoxEX();
            this.label2 = new ERM.UI.Controls.SkinLabelEX();
            this.txtTitle = new ERM.UI.Controls.TXTextBoxEX();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.label3 = new ERM.UI.Controls.SkinLabelEX();
            this.btnConfirm = new ERM.UI.Controls.SkinButtonEX();
            this.cmbUnitsType = new ERM.UI.Controls.TXComboxEX();
            this.label7 = new ERM.UI.Controls.SkinLabelEX();
            this.label8 = new ERM.UI.Controls.SkinLabelEX();
            this.txtpasswd2 = new ERM.UI.Controls.TXTextBoxEX();
            this.txtphone = new ERM.UI.Controls.TXTextBoxEX();
            this.label9 = new ERM.UI.Controls.SkinLabelEX();
            this.txtpasswd = new ERM.UI.Controls.TXTextBoxEX();
            this.label4 = new ERM.UI.Controls.SkinLabelEX();
            this.label6 = new ERM.UI.Controls.SkinLabelEX();
            this.txtLogin = new ERM.UI.Controls.TXTextBoxEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.cmbUnits);
            this.panel1.Controls.Add(this.txtFullname);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.cmbUnitsType);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtpasswd2);
            this.panel1.Controls.Add(this.txtphone);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtpasswd);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtLogin);
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
            this.panel1.Size = new System.Drawing.Size(444, 283);
            this.panel1.TabIndex = 0;
            // 
            // cmbUnits
            // 
            this.cmbUnits.BackColor = System.Drawing.SystemColors.Window;
            this.cmbUnits.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmbUnits.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbUnits.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUnits.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.cmbUnits.Image = null;
            this.cmbUnits.ImageSize = new System.Drawing.Size(0, 0);
            this.cmbUnits.Location = new System.Drawing.Point(90, 208);
            this.cmbUnits.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbUnits.MaxLength = 25;
            this.cmbUnits.Name = "cmbUnits";
            this.cmbUnits.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbUnits.PasswordChar = '\0';
            this.cmbUnits.Required = false;
            this.cmbUnits.Size = new System.Drawing.Size(345, 25);
            this.cmbUnits.TabIndex = 58;
            // 
            // txtFullname
            // 
            this.txtFullname.BackColor = System.Drawing.Color.Transparent;
            this.txtFullname.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtFullname.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFullname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFullname.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtFullname.Image = null;
            this.txtFullname.ImageSize = new System.Drawing.Size(0, 0);
            this.txtFullname.Location = new System.Drawing.Point(90, 105);
            this.txtFullname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFullname.MaxLength = 25;
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFullname.PasswordChar = '\0';
            this.txtFullname.Required = false;
            this.txtFullname.Size = new System.Drawing.Size(131, 25);
            this.txtFullname.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(52, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "姓名";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Transparent;
            this.txtTitle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTitle.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtTitle.Image = null;
            this.txtTitle.ImageSize = new System.Drawing.Size(0, 0);
            this.txtTitle.Location = new System.Drawing.Point(90, 138);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTitle.MaxLength = 25;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTitle.PasswordChar = '\0';
            this.txtTitle.Required = false;
            this.txtTitle.Size = new System.Drawing.Size(345, 25);
            this.txtTitle.TabIndex = 48;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnCancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnCancel.BorderColor = System.Drawing.Color.Empty;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DownBack = null;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnCancel.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(245, 245);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 10;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(52, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "职称";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfirm.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnConfirm.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnConfirm.BorderColor = System.Drawing.Color.Empty;
            this.btnConfirm.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.DownBack = null;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnConfirm.GlowColor = System.Drawing.Color.Transparent;
            this.btnConfirm.InnerBorderColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(156, 245);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MouseBack = null;
            this.btnConfirm.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NormlBack = null;
            this.btnConfirm.Palace = true;
            this.btnConfirm.Radius = 10;
            this.btnConfirm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnConfirm.Size = new System.Drawing.Size(70, 28);
            this.btnConfirm.TabIndex = 41;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cmbUnitsType
            // 
            this.cmbUnitsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnitsType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmbUnitsType.FormattingEnabled = true;
            this.cmbUnitsType.Items.AddRange(new object[] {
            "建设单位  ",
            "勘查单位 ",
            "设计单位",
            "施工单位 ",
            "施工图审单位 ",
            "监理单位",
            "监督单位　",
            "分包单位　",
            "安装单位　",
            "其它单位"});
            this.cmbUnitsType.Location = new System.Drawing.Point(90, 172);
            this.cmbUnitsType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbUnitsType.MaxLength = 25;
            this.cmbUnitsType.Name = "cmbUnitsType";
            this.cmbUnitsType.Size = new System.Drawing.Size(345, 25);
            this.cmbUnitsType.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.BorderColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(266, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 55;
            this.label7.Text = "电话";
            // 
            // label8
            // 
            this.label8.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BorderColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(4, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 57;
            this.label8.Text = "所在单位类型";
            // 
            // txtpasswd2
            // 
            this.txtpasswd2.BackColor = System.Drawing.Color.Transparent;
            this.txtpasswd2.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtpasswd2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpasswd2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtpasswd2.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtpasswd2.Image = null;
            this.txtpasswd2.ImageSize = new System.Drawing.Size(0, 0);
            this.txtpasswd2.Location = new System.Drawing.Point(90, 73);
            this.txtpasswd2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtpasswd2.MaxLength = 25;
            this.txtpasswd2.Name = "txtpasswd2";
            this.txtpasswd2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtpasswd2.PasswordChar = '*';
            this.txtpasswd2.Required = false;
            this.txtpasswd2.Size = new System.Drawing.Size(345, 25);
            this.txtpasswd2.TabIndex = 45;
            // 
            // txtphone
            // 
            this.txtphone.BackColor = System.Drawing.Color.Transparent;
            this.txtphone.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtphone.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtphone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtphone.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtphone.Image = null;
            this.txtphone.ImageSize = new System.Drawing.Size(0, 0);
            this.txtphone.Location = new System.Drawing.Point(304, 103);
            this.txtphone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtphone.MaxLength = 25;
            this.txtphone.Name = "txtphone";
            this.txtphone.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtphone.PasswordChar = '\0';
            this.txtphone.Required = false;
            this.txtphone.Size = new System.Drawing.Size(131, 25);
            this.txtphone.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.BorderColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(28, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 54;
            this.label9.Text = "确认密码";
            // 
            // txtpasswd
            // 
            this.txtpasswd.BackColor = System.Drawing.Color.Transparent;
            this.txtpasswd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtpasswd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpasswd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtpasswd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtpasswd.Image = null;
            this.txtpasswd.ImageSize = new System.Drawing.Size(0, 0);
            this.txtpasswd.Location = new System.Drawing.Point(90, 41);
            this.txtpasswd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtpasswd.MaxLength = 25;
            this.txtpasswd.Name = "txtpasswd";
            this.txtpasswd.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtpasswd.PasswordChar = '*';
            this.txtpasswd.Required = false;
            this.txtpasswd.Size = new System.Drawing.Size(345, 25);
            this.txtpasswd.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(52, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 53;
            this.label4.Text = "密码";
            // 
            // label6
            // 
            this.label6.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(28, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 56;
            this.label6.Text = "所在单位";
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.Transparent;
            this.txtLogin.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtLogin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLogin.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtLogin.Image = null;
            this.txtLogin.ImageSize = new System.Drawing.Size(0, 0);
            this.txtLogin.Location = new System.Drawing.Point(90, 11);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLogin.MaxLength = 25;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLogin.PasswordChar = '\0';
            this.txtLogin.Required = false;
            this.txtLogin.Size = new System.Drawing.Size(345, 25);
            this.txtLogin.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(40, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "用户名";
            // 
            // frmUsersDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(452, 321);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsersDetail";
            this.Radius = 10;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmUsersDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private TXTextBoxEX cmbUnits;
        private TXTextBoxEX txtFullname;
        private SkinLabelEX label2;
        private TXTextBoxEX txtTitle;
        private SkinButtonEX btnCancel;
        private SkinLabelEX label3;
        private SkinButtonEX btnConfirm;
        private TXComboxEX cmbUnitsType;
        private SkinLabelEX label7;
        private SkinLabelEX label8;
        private TXTextBoxEX txtpasswd2;
        private TXTextBoxEX txtphone;
        private SkinLabelEX label9;
        private TXTextBoxEX txtpasswd;
        private SkinLabelEX label4;
        private SkinLabelEX label6;
        private TXTextBoxEX txtLogin;
        private SkinLabelEX label1;

    }
}