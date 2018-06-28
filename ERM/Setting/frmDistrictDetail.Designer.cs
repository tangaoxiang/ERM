using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmDistrictDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDistrictDetail));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.groupBox1 = new ERM.UI.Controls.TXGroupEX();
            this.label2 = new ERM.UI.Controls.SkinLabelEX();
            this.numOrderIndex = new System.Windows.Forms.NumericUpDown();
            this.txtDistrictName = new ERM.UI.Controls.TXTextBoxEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.btnConfirm = new ERM.UI.Controls.SkinButtonEX();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOrderIndex)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(284, 131);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.groupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.CaptionColor = System.Drawing.Color.Black;
            this.groupBox1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numOrderIndex);
            this.groupBox1.Controls.Add(this.txtDistrictName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(269, 83);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "区域管理";
            this.groupBox1.TextMargin = 6;
            // 
            // label2
            // 
            this.label2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "排列顺序";
            // 
            // numOrderIndex
            // 
            this.numOrderIndex.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.numOrderIndex.Location = new System.Drawing.Point(70, 48);
            this.numOrderIndex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numOrderIndex.Name = "numOrderIndex";
            this.numOrderIndex.Size = new System.Drawing.Size(191, 25);
            this.numOrderIndex.TabIndex = 17;
            // 
            // txtDistrictName
            // 
            this.txtDistrictName.BackColor = System.Drawing.Color.Transparent;
            this.txtDistrictName.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDistrictName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDistrictName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDistrictName.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtDistrictName.Image = null;
            this.txtDistrictName.ImageSize = new System.Drawing.Size(0, 0);
            this.txtDistrictName.Location = new System.Drawing.Point(70, 18);
            this.txtDistrictName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDistrictName.MaxLength = 25;
            this.txtDistrictName.Name = "txtDistrictName";
            this.txtDistrictName.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDistrictName.PasswordChar = '\0';
            this.txtDistrictName.Required = false;
            this.txtDistrictName.Size = new System.Drawing.Size(191, 25);
            this.txtDistrictName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "区域名称";
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
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnConfirm.GlowColor = System.Drawing.Color.Transparent;
            this.btnConfirm.InnerBorderColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(78, 98);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MouseBack = null;
            this.btnConfirm.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NormlBack = null;
            this.btnConfirm.Palace = true;
            this.btnConfirm.Radius = 10;
            this.btnConfirm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnConfirm.Size = new System.Drawing.Size(70, 28);
            this.btnConfirm.TabIndex = 37;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
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
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnCancel.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(167, 98);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 10;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmDistrictDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(292, 169);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDistrictDetail";
            this.ShowInTaskbar = false;
            this.Text = "区域管理";
            this.Load += new System.EventHandler(this.frmDistrictDetail_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOrderIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private TXGroupEX groupBox1;
        private Controls.SkinLabelEX label2;
        private System.Windows.Forms.NumericUpDown numOrderIndex;
        internal Controls.TXTextBoxEX txtDistrictName;
        private Controls.SkinLabelEX label1;
        private Controls.SkinButtonEX btnCancel;
        private Controls.SkinButtonEX btnConfirm;


    }
}