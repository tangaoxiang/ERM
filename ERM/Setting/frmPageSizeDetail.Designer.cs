using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmPageSizeDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPageSizeDetail));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.numPfloat = new System.Windows.Forms.NumericUpDown();
            this.numPages = new System.Windows.Forms.NumericUpDown();
            this.chIsDefault = new TX.Framework.WindowUI.Controls.TXCheckBox();
            this.label4 = new ERM.UI.Controls.SkinLabelEX();
            this.label3 = new ERM.UI.Controls.SkinLabelEX();
            this.label2 = new ERM.UI.Controls.SkinLabelEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.txtptype = new ERM.UI.Controls.TXTextBoxEX();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.btnConfirm = new ERM.UI.Controls.SkinButtonEX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPfloat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPages)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.numPfloat);
            this.panel1.Controls.Add(this.numPages);
            this.panel1.Controls.Add(this.chIsDefault);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtptype);
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
            this.panel1.Size = new System.Drawing.Size(281, 174);
            this.panel1.TabIndex = 0;
            // 
            // numPfloat
            // 
            this.numPfloat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPfloat.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.numPfloat.Location = new System.Drawing.Point(86, 72);
            this.numPfloat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numPfloat.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numPfloat.Name = "numPfloat";
            this.numPfloat.Size = new System.Drawing.Size(181, 23);
            this.numPfloat.TabIndex = 52;
            // 
            // numPages
            // 
            this.numPages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPages.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.numPages.Location = new System.Drawing.Point(86, 40);
            this.numPages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numPages.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numPages.Name = "numPages";
            this.numPages.Size = new System.Drawing.Size(181, 23);
            this.numPages.TabIndex = 51;
            // 
            // chIsDefault
            // 
            this.chIsDefault.AutoSize = true;
            this.chIsDefault.Location = new System.Drawing.Point(86, 105);
            this.chIsDefault.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chIsDefault.MinimumSize = new System.Drawing.Size(20, 20);
            this.chIsDefault.Name = "chIsDefault";
            this.chIsDefault.Size = new System.Drawing.Size(20, 20);
            this.chIsDefault.TabIndex = 50;
            this.chIsDefault.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(25, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 48;
            this.label4.Text = "设为默认";
            // 
            // label3
            // 
            this.label3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 49;
            this.label3.Text = "页数浮动值";
            // 
            // label2
            // 
            this.label2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "页数稳定值";
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "卷册类别";
            // 
            // txtptype
            // 
            this.txtptype.BackColor = System.Drawing.Color.Transparent;
            this.txtptype.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtptype.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtptype.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtptype.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtptype.Image = null;
            this.txtptype.ImageSize = new System.Drawing.Size(0, 0);
            this.txtptype.Location = new System.Drawing.Point(86, 11);
            this.txtptype.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtptype.MaxLength = 20;
            this.txtptype.Name = "txtptype";
            this.txtptype.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtptype.PasswordChar = '\0';
            this.txtptype.Required = false;
            this.txtptype.Size = new System.Drawing.Size(181, 21);
            this.txtptype.TabIndex = 43;
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
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnCancel.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(185, 138);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 10;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 45;
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
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnConfirm.GlowColor = System.Drawing.Color.Transparent;
            this.btnConfirm.InnerBorderColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(84, 138);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MouseBack = null;
            this.btnConfirm.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NormlBack = null;
            this.btnConfirm.Palace = true;
            this.btnConfirm.Radius = 10;
            this.btnConfirm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnConfirm.Size = new System.Drawing.Size(70, 28);
            this.btnConfirm.TabIndex = 44;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // frmPageSizeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(289, 212);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(289, 233);
            this.MinimizeBox = false;
            this.Name = "frmPageSizeDetail";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmPageSizeDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPfloat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private System.Windows.Forms.NumericUpDown numPfloat;
        private System.Windows.Forms.NumericUpDown numPages;
        private TXCheckBox chIsDefault;
        private Controls.SkinLabelEX label4;
        private Controls.SkinLabelEX label3;
        private Controls.SkinLabelEX label2;
        private Controls.SkinLabelEX label1;
        private Controls.TXTextBoxEX txtptype;
        private Controls.SkinButtonEX btnCancel;
        private Controls.SkinButtonEX btnConfirm;

    }
}