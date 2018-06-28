using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmXsd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXsd));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.chk_Replece = new TX.Framework.WindowUI.Controls.TXCheckBox();
            this.txt_RMax = new ERM.UI.Controls.TXTextBoxEX();
            this.txt_RMin = new ERM.UI.Controls.TXTextBoxEX();
            this.label3 = new ERM.UI.Controls.SkinLabelEX();
            this.label2 = new ERM.UI.Controls.SkinLabelEX();
            this.checkBox1 = new TX.Framework.WindowUI.Controls.TXCheckBox();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.btnOK = new ERM.UI.Controls.SkinButtonEX();
            this.UpDown1 = new System.Windows.Forms.DomainUpDown();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.chk_Replece);
            this.panel1.Controls.Add(this.txt_RMax);
            this.panel1.Controls.Add(this.txt_RMin);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.UpDown1);
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
            this.panel1.Size = new System.Drawing.Size(330, 209);
            this.panel1.TabIndex = 0;
            // 
            // chk_Replece
            // 
            this.chk_Replece.AutoSize = true;
            this.chk_Replece.Location = new System.Drawing.Point(219, 65);
            this.chk_Replece.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk_Replece.MinimumSize = new System.Drawing.Size(20, 20);
            this.chk_Replece.Name = "chk_Replece";
            this.chk_Replece.Size = new System.Drawing.Size(99, 21);
            this.chk_Replece.TabIndex = 21;
            this.chk_Replece.Text = "覆盖现有数据";
            this.chk_Replece.UseVisualStyleBackColor = true;
            // 
            // txt_RMax
            // 
            this.txt_RMax.BackColor = System.Drawing.Color.Transparent;
            this.txt_RMax.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_RMax.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_RMax.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_RMax.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_RMax.Image = null;
            this.txt_RMax.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_RMax.Location = new System.Drawing.Point(126, 129);
            this.txt_RMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_RMax.MaxLength = 8;
            this.txt_RMax.Name = "txt_RMax";
            this.txt_RMax.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_RMax.PasswordChar = '\0';
            this.txt_RMax.Required = false;
            this.txt_RMax.Size = new System.Drawing.Size(192, 25);
            this.txt_RMax.TabIndex = 20;
            // 
            // txt_RMin
            // 
            this.txt_RMin.BackColor = System.Drawing.Color.Transparent;
            this.txt_RMin.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_RMin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_RMin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_RMin.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_RMin.Image = null;
            this.txt_RMin.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_RMin.Location = new System.Drawing.Point(126, 99);
            this.txt_RMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_RMin.MaxLength = 8;
            this.txt_RMin.Name = "txt_RMin";
            this.txt_RMin.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_RMin.PasswordChar = '\0';
            this.txt_RMin.Required = false;
            this.txt_RMin.Size = new System.Drawing.Size(192, 25);
            this.txt_RMin.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "随机数的最大值：";
            // 
            // label2
            // 
            this.label2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "随机数的最小值：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 65);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.MinimumSize = new System.Drawing.Size(20, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 21);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "显示正数符号";
            this.checkBox1.UseVisualStyleBackColor = true;
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
            this.btnCancel.Location = new System.Drawing.Point(182, 170);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 10;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOK.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnOK.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnOK.BorderColor = System.Drawing.Color.Transparent;
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DownBack = null;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.GlowColor = System.Drawing.Color.Transparent;
            this.btnOK.InnerBorderColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(91, 170);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.MouseBack = null;
            this.btnOK.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = null;
            this.btnOK.Palace = true;
            this.btnOK.Radius = 10;
            this.btnOK.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnOK.Size = new System.Drawing.Size(70, 28);
            this.btnOK.TabIndex = 12;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // UpDown1
            // 
            this.UpDown1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.UpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpDown1.Items.Add("0");
            this.UpDown1.Items.Add("1");
            this.UpDown1.Items.Add("2");
            this.UpDown1.Items.Add("3");
            this.UpDown1.Items.Add("4");
            this.UpDown1.Items.Add("5");
            this.UpDown1.Location = new System.Drawing.Point(19, 34);
            this.UpDown1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpDown1.Name = "UpDown1";
            this.UpDown1.ReadOnly = true;
            this.UpDown1.Size = new System.Drawing.Size(299, 23);
            this.UpDown1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "输入随机测量值精确度（小数点后几位）：";
            // 
            // frmXsd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(338, 247);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXsd";
            this.ShowInTaskbar = false;
            this.Text = "随机填充";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        internal TXCheckBox chk_Replece;
        private Controls.TXTextBoxEX txt_RMax;
        private Controls.TXTextBoxEX txt_RMin;
        private Controls.SkinLabelEX label3;
        private Controls.SkinLabelEX label2;
        internal TXCheckBox checkBox1;
        private Controls.SkinButtonEX btnCancel;
        private Controls.SkinButtonEX btnOK;
        internal System.Windows.Forms.DomainUpDown UpDown1;
        private Controls.SkinLabelEX label1;

    }
}