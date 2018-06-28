namespace ERM.UI
{
    partial class frmSignpassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignpassword));
            this.btnExit = new System.Windows.Forms.Button();
            this.txtSignPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.axPDFReader1 = new AxiWebPDF.AxPDFReader();
            ((System.ComponentModel.ISupportInitialize)(this.axPDFReader1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::ERM.UI.Properties.Resources.button;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(169, 49);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(69, 21);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "取消";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // txtSignPassword
            // 
            this.txtSignPassword.Location = new System.Drawing.Point(23, 12);
            this.txtSignPassword.MaxLength = 50;
            this.txtSignPassword.Name = "txtSignPassword";
            this.txtSignPassword.PasswordChar = '*';
            this.txtSignPassword.Size = new System.Drawing.Size(300, 21);
            this.txtSignPassword.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::ERM.UI.Properties.Resources.button;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(80, 49);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 21);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // axPDFReader1
            // 
            this.axPDFReader1.Enabled = true;
            this.axPDFReader1.Location = new System.Drawing.Point(279, 40);
            this.axPDFReader1.Name = "axPDFReader1";
            this.axPDFReader1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPDFReader1.OcxState")));
            this.axPDFReader1.Size = new System.Drawing.Size(192, 192);
            this.axPDFReader1.TabIndex = 3;
            // 
            // frmSignpassword
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(337, 75);
            this.Controls.Add(this.axPDFReader1);
            this.Controls.Add(this.txtSignPassword);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSignpassword";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.axPDFReader1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtSignPassword;
        private System.Windows.Forms.Button btnSave;
        private AxiWebPDF.AxPDFReader axPDFReader1;
    }
}