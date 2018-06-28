namespace Digi.B
{
	partial class frmWelcome
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
            this.btnZjz = new System.Windows.Forms.Button();
            this.btnGd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnZjz
            // 
            this.btnZjz.Location = new System.Drawing.Point(121, 74);
            this.btnZjz.Name = "btnZjz";
            this.btnZjz.Size = new System.Drawing.Size(75, 23);
            this.btnZjz.TabIndex = 0;
            this.btnZjz.Text = "质检站目录";
            this.btnZjz.UseVisualStyleBackColor = true;
            this.btnZjz.Click += new System.EventHandler(this.btnZjz_Click);
            // 
            // btnGd
            // 
            this.btnGd.Location = new System.Drawing.Point(312, 74);
            this.btnGd.Name = "btnGd";
            this.btnGd.Size = new System.Drawing.Size(75, 23);
            this.btnGd.TabIndex = 0;
            this.btnGd.Text = "归档目录";
            this.btnGd.UseVisualStyleBackColor = true;
            this.btnGd.Click += new System.EventHandler(this.btnGd_Click);
            // 
            // frmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 175);
            this.Controls.Add(this.btnGd);
            this.Controls.Add(this.btnZjz);
            this.Name = "frmWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmWelcome";
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Button btnZjz;
        private System.Windows.Forms.Button btnGd;
	}
}