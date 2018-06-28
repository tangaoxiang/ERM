using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmCellFillRnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCellFillRnd));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.groupBox1 = new ERM.UI.Controls.TXGroupEX();
            this.txtMax = new ERM.UI.Controls.NumberTextBoxEX();
            this.label2 = new ERM.UI.Controls.SkinLabelEX();
            this.txtMin = new ERM.UI.Controls.NumberTextBoxEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.btnConfirm = new ERM.UI.Controls.SkinButtonEX();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(276, 131);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.CaptionColor = System.Drawing.Color.Black;
            this.groupBox1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Controls.Add(this.txtMax);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(4, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(268, 90);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选项";
            this.groupBox1.TextMargin = 6;
            // 
            // txtMax
            // 
            this.txtMax.BackColor = System.Drawing.Color.Transparent;
            this.txtMax.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMax.DecimalLength = 0;
            this.txtMax.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMax.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMax.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtMax.Image = null;
            this.txtMax.ImageSize = new System.Drawing.Size(0, 0);
            this.txtMax.Location = new System.Drawing.Point(110, 52);
            this.txtMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMax.MaxValuelLength = 8;
            this.txtMax.Name = "txtMax";
            this.txtMax.PasswordChar = '\0';
            this.txtMax.Required = false;
            this.txtMax.ShowMsg = false;
            this.txtMax.Size = new System.Drawing.Size(138, 23);
            this.txtMax.TabIndex = 3;
            this.txtMax.Tag = "随机数的最大值,int";
            // 
            // label2
            // 
            this.label2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "随机数的最大值";
            // 
            // txtMin
            // 
            this.txtMin.BackColor = System.Drawing.Color.Transparent;
            this.txtMin.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMin.DecimalLength = 0;
            this.txtMin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMin.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtMin.Image = null;
            this.txtMin.ImageSize = new System.Drawing.Size(0, 0);
            this.txtMin.Location = new System.Drawing.Point(110, 19);
            this.txtMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMin.MaxValuelLength = 8;
            this.txtMin.Name = "txtMin";
            this.txtMin.PasswordChar = '\0';
            this.txtMin.Required = false;
            this.txtMin.ShowMsg = false;
            this.txtMin.Size = new System.Drawing.Size(138, 23);
            this.txtMin.TabIndex = 1;
            this.txtMin.Tag = "随机数的最小值,int";
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "随机数的最小值";
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
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(156, 100);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 10;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 5;
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
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnConfirm.GlowColor = System.Drawing.Color.Transparent;
            this.btnConfirm.InnerBorderColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(66, 100);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MouseBack = null;
            this.btnConfirm.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NormlBack = null;
            this.btnConfirm.Palace = true;
            this.btnConfirm.Radius = 10;
            this.btnConfirm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnConfirm.Size = new System.Drawing.Size(70, 28);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // frmCellFillRnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(284, 169);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(314, 255);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(282, 169);
            this.Name = "frmCellFillRnd";
            this.ShowInTaskbar = false;
            this.Text = "随机填充";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private Controls.NumberTextBoxEX txtMax;
        private Controls.SkinLabelEX label2;
        private Controls.NumberTextBoxEX txtMin;
        private Controls.SkinLabelEX label1;
        private Controls.SkinButtonEX btnCancel;
        private Controls.SkinButtonEX btnConfirm;
        private TXGroupEX groupBox1;

    }
}