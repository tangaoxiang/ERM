using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmCellNameEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCellNameEdit));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.groupBox1 = new ERM.UI.Controls.TXGroupEX();
            this.label3 = new ERM.UI.Controls.SkinLabelEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.btnExplorer = new ERM.UI.Controls.SkinButtonEX();
            this.txtTitle = new ERM.UI.Controls.TXTextBoxEX();
            this.txtFilePath = new ERM.UI.Controls.TXTextBoxEX();
            this.label2 = new ERM.UI.Controls.SkinLabelEX();
            this.btnConfirm = new ERM.UI.Controls.SkinButtonEX();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.groupBox1);
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
            this.panel1.Size = new System.Drawing.Size(509, 95);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.CaptionColor = System.Drawing.Color.Black;
            this.groupBox1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnExplorer);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(500, 54);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "属性";
            this.groupBox1.TextMargin = 6;
            // 
            // label3
            // 
            this.label3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "只能替换用户自定义、且未提交的表格";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "标题";
            // 
            // btnExplorer
            // 
            this.btnExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.btnExplorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExplorer.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnExplorer.BaseColor = System.Drawing.Color.Empty;
            this.btnExplorer.BorderColor = System.Drawing.Color.White;
            this.btnExplorer.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExplorer.DownBack = null;
            this.btnExplorer.FlatAppearance.BorderSize = 0;
            this.btnExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExplorer.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExplorer.ForeColor = System.Drawing.Color.Black;
            this.btnExplorer.GlowColor = System.Drawing.Color.Transparent;
            this.btnExplorer.InnerBorderColor = System.Drawing.Color.White;
            this.btnExplorer.Location = new System.Drawing.Point(399, 71);
            this.btnExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.btnExplorer.MouseBack = null;
            this.btnExplorer.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnExplorer.Name = "btnExplorer";
            this.btnExplorer.NormlBack = null;
            this.btnExplorer.Palace = true;
            this.btnExplorer.Radius = 10;
            this.btnExplorer.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnExplorer.Size = new System.Drawing.Size(80, 30);
            this.btnExplorer.TabIndex = 4;
            this.btnExplorer.TabStop = false;
            this.btnExplorer.Text = "浏览...";
            this.btnExplorer.UseVisualStyleBackColor = true;
            this.btnExplorer.Visible = false;
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
            this.txtTitle.Location = new System.Drawing.Point(57, 19);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTitle.PasswordChar = '\0';
            this.txtTitle.Required = false;
            this.txtTitle.Size = new System.Drawing.Size(431, 25);
            this.txtTitle.TabIndex = 1;
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.Color.Transparent;
            this.txtFilePath.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtFilePath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFilePath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFilePath.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtFilePath.Image = null;
            this.txtFilePath.ImageSize = new System.Drawing.Size(0, 0);
            this.txtFilePath.Location = new System.Drawing.Point(76, 71);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFilePath.MaxLength = 200;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFilePath.PasswordChar = '\0';
            this.txtFilePath.Required = false;
            this.txtFilePath.Size = new System.Drawing.Size(318, 30);
            this.txtFilePath.TabIndex = 3;
            this.txtFilePath.Visible = false;
            // 
            // label2
            // 
            this.label2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "替换表格";
            this.label2.Visible = false;
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
            this.btnConfirm.Location = new System.Drawing.Point(180, 63);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MouseBack = null;
            this.btnConfirm.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NormlBack = null;
            this.btnConfirm.Palace = true;
            this.btnConfirm.Radius = 10;
            this.btnConfirm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnConfirm.Size = new System.Drawing.Size(70, 28);
            this.btnConfirm.TabIndex = 9;
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
            this.btnCancel.Location = new System.Drawing.Point(259, 63);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 10;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // frmCellNameEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(517, 133);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCellNameEdit";
            this.ShowInTaskbar = false;
            this.Text = "修改节点";
            this.Load += new System.EventHandler(this.frmMainEdit_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private Controls.SkinLabelEX label3;
        private Controls.SkinLabelEX label1;
        private Controls.SkinButtonEX btnExplorer;
        public Controls.TXTextBoxEX txtTitle;
        public Controls.TXTextBoxEX txtFilePath;
        private Controls.SkinLabelEX label2;
        private Controls.SkinButtonEX btnConfirm;
        private Controls.SkinButtonEX btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private TXGroupEX groupBox1;

    }
}