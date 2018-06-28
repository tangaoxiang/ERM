namespace Digi.B
{
    partial class frmSetNodeName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetNodeName));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNodeName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnConsle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入节点名称：";
            // 
            // txtNodeName
            // 
            this.txtNodeName.Location = new System.Drawing.Point(14, 33);
            this.txtNodeName.MaxLength = 25;
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(265, 21);
            this.txtNodeName.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::Digi.B.Properties.Resources.button;
            this.btnSave.Location = new System.Drawing.Point(124, 70);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 21);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnConsle
            // 
            this.btnConsle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConsle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConsle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsle.Image = global::Digi.B.Properties.Resources.button;
            this.btnConsle.Location = new System.Drawing.Point(210, 70);
            this.btnConsle.Name = "btnConsle";
            this.btnConsle.Size = new System.Drawing.Size(69, 21);
            this.btnConsle.TabIndex = 4;
            this.btnConsle.Text = "取消";
            this.btnConsle.UseVisualStyleBackColor = true;
            this.btnConsle.Click += new System.EventHandler(this.btnConsle_Click);
            // 
            // frmSetNodeName
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnConsle;
            this.ClientSize = new System.Drawing.Size(298, 103);
            this.Controls.Add(this.btnConsle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNodeName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetNodeName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置节点名称";
            this.Load += new System.EventHandler(this.frmSetNodeName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnConsle;
    }
}