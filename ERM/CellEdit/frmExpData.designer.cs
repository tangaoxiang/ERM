using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmExpData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpData));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.btnExplorer = new ERM.UI.Controls.SkinButtonEX();
            this.txtLoc = new ERM.UI.Controls.TXTextBoxEX();
            this.label2 = new ERM.UI.Controls.SkinLabelEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.progressBar1 = new CCWin.SkinControl.SkinProgressBar();
            this.lblTitle = new ERM.UI.Controls.SkinLabelEX();
            this.btnConfirm = new ERM.UI.Controls.SkinButtonEX();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImage = global::ERM.UI.Properties.Resources.about_bg;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnExplorer);
            this.panel1.Controls.Add(this.txtLoc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(457, 194);
            this.panel1.TabIndex = 0;
            // 
            // btnExplorer
            // 
            this.btnExplorer.BackColor = System.Drawing.Color.Transparent;
            this.btnExplorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExplorer.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
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
            this.btnExplorer.Location = new System.Drawing.Point(381, 44);
            this.btnExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.btnExplorer.MouseBack = null;
            this.btnExplorer.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnExplorer.Name = "btnExplorer";
            this.btnExplorer.NormlBack = null;
            this.btnExplorer.Palace = true;
            this.btnExplorer.Radius = 10;
            this.btnExplorer.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnExplorer.Size = new System.Drawing.Size(70, 28);
            this.btnExplorer.TabIndex = 29;
            this.btnExplorer.TabStop = false;
            this.btnExplorer.Text = "浏览";
            this.btnExplorer.UseVisualStyleBackColor = false;
            this.btnExplorer.Click += new System.EventHandler(this.btnExplorer_Click);
            // 
            // txtLoc
            // 
            this.txtLoc.BackColor = System.Drawing.Color.White;
            this.txtLoc.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtLoc.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLoc.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtLoc.Image = null;
            this.txtLoc.ImageSize = new System.Drawing.Size(0, 0);
            this.txtLoc.Location = new System.Drawing.Point(75, 45);
            this.txtLoc.Margin = new System.Windows.Forms.Padding(4);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLoc.PasswordChar = '\0';
            this.txtLoc.ReadOnly = true;
            this.txtLoc.Required = false;
            this.txtLoc.Size = new System.Drawing.Size(303, 24);
            this.txtLoc.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "存储路径：";
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "导出数据可能需要一段时间，请稍候…";
            // 
            // progressBar1
            // 
            this.progressBar1.Back = null;
            this.progressBar1.BackColor = System.Drawing.Color.Transparent;
            this.progressBar1.BarBack = null;
            this.progressBar1.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.progressBar1.ForeColor = System.Drawing.Color.Red;
            this.progressBar1.Location = new System.Drawing.Point(11, 171);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.progressBar1.Size = new System.Drawing.Size(442, 18);
            this.progressBar1.Step = 2;
            this.progressBar1.TabIndex = 31;
            // 
            // lblTitle
            // 
            this.lblTitle.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.BorderColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(11, 81);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(56, 17);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "当前进度";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfirm.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
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
            this.btnConfirm.Location = new System.Drawing.Point(305, 140);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MouseBack = null;
            this.btnConfirm.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NormlBack = null;
            this.btnConfirm.Palace = true;
            this.btnConfirm.Radius = 10;
            this.btnConfirm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnConfirm.Size = new System.Drawing.Size(70, 28);
            this.btnConfirm.TabIndex = 27;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
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
            this.btnCancel.Location = new System.Drawing.Point(381, 140);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 10;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "SIP 文件(*.sip)|*.sip";
            // 
            // frmExpData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(465, 232);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(463, 232);
            this.Name = "frmExpData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "导出数据";
            this.Load += new System.EventHandler(this.frmExpData_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private Controls.SkinButtonEX btnExplorer;
        private Controls.TXTextBoxEX txtLoc;
        private Controls.SkinLabelEX label2;
        private Controls.SkinLabelEX label1;
        private SkinProgressBar progressBar1;
        private Controls.SkinLabelEX lblTitle;
        private Controls.SkinButtonEX btnConfirm;
        private Controls.SkinButtonEX btnCancel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    }
}