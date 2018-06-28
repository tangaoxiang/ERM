using CCWin.SkinControl;
using ERM.UI.Controls;
using System.Windows.Forms;
namespace ERM.UI
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.btnClose = new ERM.UI.Controls.SkinButtonEX();
            this.lbl_QQ = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImage = global::ERM.UI.Properties.Resources.about_bg;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.lbl_QQ);
            this.panel1.Controls.Add(this.lbl_email);
            this.panel1.Controls.Add(this.lbl_phone);
            this.panel1.Controls.Add(this.lblRemark);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.lblCopyright);
            this.panel1.Controls.Add(this.lblAppTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(471, 254);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnClose.BorderColor = System.Drawing.Color.Transparent;
            this.btnClose.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DownBack = null;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnClose.GlowColor = System.Drawing.Color.Transparent;
            this.btnClose.InnerBorderColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(390, 219);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MouseBack = null;
            this.btnClose.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnClose.Name = "btnClose";
            this.btnClose.NormlBack = null;
            this.btnClose.Palace = true;
            this.btnClose.Radius = 10;
            this.btnClose.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnClose.Size = new System.Drawing.Size(70, 28);
            this.btnClose.TabIndex = 23;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "确定(O)";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl_QQ
            // 
            this.lbl_QQ.AutoSize = true;
            this.lbl_QQ.BackColor = System.Drawing.Color.Transparent;
            this.lbl_QQ.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_QQ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(79)))), ((int)(((byte)(107)))));
            this.lbl_QQ.Location = new System.Drawing.Point(208, 106);
            this.lbl_QQ.Name = "lbl_QQ";
            this.lbl_QQ.Size = new System.Drawing.Size(110, 17);
            this.lbl_QQ.TabIndex = 22;
            this.lbl_QQ.Text = "QQ：2689428488";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.BackColor = System.Drawing.Color.Transparent;
            this.lbl_email.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(79)))), ((int)(((byte)(107)))));
            this.lbl_email.Location = new System.Drawing.Point(13, 126);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(177, 17);
            this.lbl_email.TabIndex = 21;
            this.lbl_email.Text = "邮箱：\tsupport@digipower.cn";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.BackColor = System.Drawing.Color.Transparent;
            this.lbl_phone.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_phone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(79)))), ((int)(((byte)(107)))));
            this.lbl_phone.Location = new System.Drawing.Point(13, 106);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(157, 17);
            this.lbl_phone.TabIndex = 20;
            this.lbl_phone.Text = "联系电话：0755-83995038";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.BackColor = System.Drawing.Color.Transparent;
            this.lblRemark.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(79)))), ((int)(((byte)(107)))));
            this.lblRemark.Location = new System.Drawing.Point(13, 157);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(440, 51);
            this.lblRemark.TabIndex = 17;
            this.lblRemark.Text = "警告: 本计算机程序受著作权法和国际公约的保护，未经授权擅自复制或散布本程\r\n序的部分或全部，将承受严厉的民事和刑事处罚，对已知的违反者将给予法律范围\r\n内的全面" +
    "制裁。";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Location = new System.Drawing.Point(11, 148);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(458, 1);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(79)))), ((int)(((byte)(107)))));
            this.lblVersion.Location = new System.Drawing.Point(13, 52);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(105, 17);
            this.lblVersion.TabIndex = 15;
            this.lblVersion.Text = "产品版本：1.0.0.0";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(79)))), ((int)(((byte)(107)))));
            this.lblID.Location = new System.Drawing.Point(13, 33);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(95, 17);
            this.lblID.TabIndex = 14;
            this.lblID.Text = "产品标识：ERM";
            // 
            // lblCopyright
            // 
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(79)))), ((int)(((byte)(107)))));
            this.lblCopyright.Location = new System.Drawing.Point(13, 70);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(291, 34);
            this.lblCopyright.TabIndex = 13;
            this.lblCopyright.Text = "版权所有(C) 2003-2017 深圳市世纪伟图科技开发有限公司。保留所有权利。\r\n";
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAppTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(79)))), ((int)(((byte)(107)))));
            this.lblAppTitle.Location = new System.Drawing.Point(13, 13);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(271, 17);
            this.lblAppTitle.TabIndex = 12;
            this.lblAppTitle.Text = "产品名称：建设工程电子文件归档与管理系统v3.0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ERM.UI.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(343, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 69);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(479, 292);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.Text = "关于";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private Label lbl_QQ;
        private Label lbl_email;
        private Label lbl_phone;
        private Label lblRemark;
        private GroupBox groupBox1;
        private Label lblVersion;
        private Label lblID;
        private Label lblCopyright;
        private Label lblAppTitle;
        private PictureBox pictureBox1;
        private SkinButtonEX btnClose;

    }
}