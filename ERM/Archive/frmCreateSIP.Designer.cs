using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmCreateSIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateSIP));
            this.btnExplorer = new ERM.UI.Controls.SkinButtonEX();
            this.opt2 = new TX.Framework.WindowUI.Controls.TXRadioButton();
            this.opt1 = new TX.Framework.WindowUI.Controls.TXRadioButton();
            this.txtLoc = new ERM.UI.Controls.TXTextBoxEX();
            this.label2 = new ERM.UI.Controls.SkinLabelEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.btnConfirm = new ERM.UI.Controls.SkinButtonEX();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.butClose = new ERM.UI.Controls.SkinButtonEX();
            this.progressBar2 = new CCWin.SkinControl.SkinProgressBar();
            this.label5 = new ERM.UI.Controls.SkinLabelEX();
            this.progressBar1 = new CCWin.SkinControl.SkinProgressBar();
            this.label7 = new ERM.UI.Controls.SkinLabelEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tmrStart = new System.Windows.Forms.Timer(this.components);
            this.panelTop = new ERM.UI.Controls.SkinPanelEX();
            this.lbl_ProjectName = new ERM.UI.Controls.SkinLabelEX();
            this.panelBottom = new ERM.UI.Controls.SkinPanelEX();
            this.lblMsg = new ERM.UI.Controls.SkinLabelEX();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExplorer
            // 
            this.btnExplorer.BackColor = System.Drawing.Color.Transparent;
            this.btnExplorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExplorer.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnExplorer.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnExplorer.BorderColor = System.Drawing.Color.Transparent;
            this.btnExplorer.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExplorer.DownBack = null;
            this.btnExplorer.FlatAppearance.BorderSize = 0;
            this.btnExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExplorer.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnExplorer.ForeColor = System.Drawing.Color.Black;
            this.btnExplorer.GlowColor = System.Drawing.Color.Transparent;
            this.btnExplorer.InnerBorderColor = System.Drawing.Color.White;
            this.btnExplorer.Location = new System.Drawing.Point(413, 106);
            this.btnExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.btnExplorer.MouseBack = null;
            this.btnExplorer.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnExplorer.Name = "btnExplorer";
            this.btnExplorer.NormlBack = null;
            this.btnExplorer.Palace = true;
            this.btnExplorer.Radius = 10;
            this.btnExplorer.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnExplorer.Size = new System.Drawing.Size(84, 28);
            this.btnExplorer.TabIndex = 13;
            this.btnExplorer.TabStop = false;
            this.btnExplorer.Text = "浏览...";
            this.btnExplorer.UseVisualStyleBackColor = false;
            this.btnExplorer.Click += new System.EventHandler(this.btnExplorer_Click);
            // 
            // opt2
            // 
            this.opt2.AutoSize = true;
            this.opt2.Location = new System.Drawing.Point(413, 13);
            this.opt2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.opt2.MaxRadius = 8;
            this.opt2.MinimumSize = new System.Drawing.Size(22, 22);
            this.opt2.MinRadius = 4;
            this.opt2.Name = "opt2";
            this.opt2.Size = new System.Drawing.Size(74, 22);
            this.opt2.TabIndex = 11;
            this.opt2.Text = "直接上报";
            this.opt2.UseVisualStyleBackColor = true;
            this.opt2.Visible = false;
            // 
            // opt1
            // 
            this.opt1.AutoSize = true;
            this.opt1.Checked = true;
            this.opt1.Location = new System.Drawing.Point(12, 13);
            this.opt1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.opt1.MaxRadius = 8;
            this.opt1.MinimumSize = new System.Drawing.Size(22, 22);
            this.opt1.MinRadius = 4;
            this.opt1.Name = "opt1";
            this.opt1.Size = new System.Drawing.Size(98, 22);
            this.opt1.TabIndex = 8;
            this.opt1.TabStop = true;
            this.opt1.Text = "生成上报文件";
            this.opt1.UseVisualStyleBackColor = true;
            // 
            // txtLoc
            // 
            this.txtLoc.BackColor = System.Drawing.Color.Transparent;
            this.txtLoc.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtLoc.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLoc.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtLoc.Image = null;
            this.txtLoc.ImageSize = new System.Drawing.Size(0, 0);
            this.txtLoc.Location = new System.Drawing.Point(12, 106);
            this.txtLoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLoc.Multiline = true;
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLoc.PasswordChar = '\0';
            this.txtLoc.ReadOnly = true;
            this.txtLoc.Required = false;
            this.txtLoc.Size = new System.Drawing.Size(398, 25);
            this.txtLoc.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "存储路径：";
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "工程名称：";
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
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnConfirm.GlowColor = System.Drawing.Color.Transparent;
            this.btnConfirm.InnerBorderColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(346, 181);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MouseBack = null;
            this.btnConfirm.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NormlBack = null;
            this.btnConfirm.Palace = true;
            this.btnConfirm.Radius = 10;
            this.btnConfirm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnConfirm.Size = new System.Drawing.Size(70, 28);
            this.btnConfirm.TabIndex = 15;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
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
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(427, 181);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 10;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // butClose
            // 
            this.butClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.butClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butClose.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.butClose.BaseColor = System.Drawing.Color.Empty;
            this.butClose.BorderColor = System.Drawing.Color.Transparent;
            this.butClose.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.butClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butClose.DownBack = null;
            this.butClose.FlatAppearance.BorderSize = 0;
            this.butClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butClose.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butClose.ForeColor = System.Drawing.Color.Black;
            this.butClose.GlowColor = System.Drawing.Color.Transparent;
            this.butClose.InnerBorderColor = System.Drawing.Color.White;
            this.butClose.Location = new System.Drawing.Point(379, 221);
            this.butClose.Margin = new System.Windows.Forms.Padding(0);
            this.butClose.MouseBack = null;
            this.butClose.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.butClose.Name = "butClose";
            this.butClose.NormlBack = null;
            this.butClose.Palace = true;
            this.butClose.Radius = 10;
            this.butClose.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.butClose.Size = new System.Drawing.Size(80, 30);
            this.butClose.TabIndex = 17;
            this.butClose.TabStop = false;
            this.butClose.Text = "退出";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Visible = false;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Back = null;
            this.progressBar2.BackColor = System.Drawing.Color.Transparent;
            this.progressBar2.BarBack = null;
            this.progressBar2.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.progressBar2.ForeColor = System.Drawing.Color.Red;
            this.progressBar2.Location = new System.Drawing.Point(27, 177);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.progressBar2.Size = new System.Drawing.Size(429, 33);
            this.progressBar2.Step = 1;
            this.progressBar2.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(24, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "总体进度";
            // 
            // progressBar1
            // 
            this.progressBar1.Back = null;
            this.progressBar1.BackColor = System.Drawing.Color.Transparent;
            this.progressBar1.BarBack = null;
            this.progressBar1.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.progressBar1.ForeColor = System.Drawing.Color.Red;
            this.progressBar1.Location = new System.Drawing.Point(27, 88);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.progressBar1.Size = new System.Drawing.Size(429, 33);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.BorderColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(24, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "当前进度";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "SIP 文件(*.sip)|*.sip";
            // 
            // tmrStart
            // 
            this.tmrStart.Tick += new System.EventHandler(this.tmrStart_Tick);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTop.Controls.Add(this.lbl_ProjectName);
            this.panelTop.Controls.Add(this.btnExplorer);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.opt2);
            this.panelTop.Controls.Add(this.btnConfirm);
            this.panelTop.Controls.Add(this.opt1);
            this.panelTop.Controls.Add(this.txtLoc);
            this.panelTop.Controls.Add(this.btnCancel);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.DownBack = null;
            this.panelTop.Location = new System.Drawing.Point(4, 34);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTop.MouseBack = null;
            this.panelTop.Name = "panelTop";
            this.panelTop.NormlBack = null;
            this.panelTop.Radius = 4;
            this.panelTop.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelTop.Size = new System.Drawing.Size(502, 220);
            this.panelTop.TabIndex = 20;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // lbl_ProjectName
            // 
            this.lbl_ProjectName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbl_ProjectName.AutoSize = true;
            this.lbl_ProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lbl_ProjectName.BorderColor = System.Drawing.Color.Transparent;
            this.lbl_ProjectName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ProjectName.ForeColor = System.Drawing.Color.Black;
            this.lbl_ProjectName.Location = new System.Drawing.Point(93, 52);
            this.lbl_ProjectName.Name = "lbl_ProjectName";
            this.lbl_ProjectName.Size = new System.Drawing.Size(49, 17);
            this.lbl_ProjectName.TabIndex = 17;
            this.lbl_ProjectName.Text = "project";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBottom.Controls.Add(this.lblMsg);
            this.panelBottom.Controls.Add(this.butClose);
            this.panelBottom.Controls.Add(this.label7);
            this.panelBottom.Controls.Add(this.progressBar2);
            this.panelBottom.Controls.Add(this.progressBar1);
            this.panelBottom.Controls.Add(this.label5);
            this.panelBottom.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelBottom.DownBack = null;
            this.panelBottom.Location = new System.Drawing.Point(2, 261);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelBottom.MouseBack = null;
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.NormlBack = null;
            this.panelBottom.Radius = 4;
            this.panelBottom.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelBottom.Size = new System.Drawing.Size(469, 275);
            this.panelBottom.TabIndex = 21;
            // 
            // lblMsg
            // 
            this.lblMsg.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.BorderColor = System.Drawing.Color.Transparent;
            this.lblMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Black;
            this.lblMsg.Location = new System.Drawing.Point(24, 18);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(38, 17);
            this.lblMsg.TabIndex = 18;
            this.lblMsg.Text = "信息..";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // frmCreateSIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(510, 258);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateSIP";
            this.Text = "资料上报";
            this.Load += new System.EventHandler(this.frmCreateSIP_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ERM.UI.Controls.SkinButtonEX btnExplorer;
        private TXRadioButton opt2;
        private TXRadioButton opt1;
        private ERM.UI.Controls.TXTextBoxEX txtLoc;
        private ERM.UI.Controls.SkinLabelEX label2;
        private ERM.UI.Controls.SkinLabelEX label1;
        private ERM.UI.Controls.SkinButtonEX btnConfirm;
        private ERM.UI.Controls.SkinButtonEX btnCancel;
        private ERM.UI.Controls.SkinButtonEX butClose;
        private SkinProgressBar progressBar2;
        private ERM.UI.Controls.SkinLabelEX label5;
        private SkinProgressBar progressBar1;
        private ERM.UI.Controls.SkinLabelEX label7;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer tmrStart;
        private SkinPanelEX panelTop;
        private SkinPanelEX panelBottom;
        private ERM.UI.Controls.SkinLabelEX lblMsg;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private ERM.UI.Controls.SkinLabelEX lbl_ProjectName;
        private System.ComponentModel.BackgroundWorker bgWorker;
    }
}