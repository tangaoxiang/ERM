namespace ERM.UI
{
    partial class frmShowExample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowExample));
            this.Cell1 = new AxCELL50LibU.AxCell();
            ((System.ComponentModel.ISupportInitialize)(this.Cell1)).BeginInit();
            this.SuspendLayout();
            // 
            // Cell1
            // 
            this.Cell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell1.Enabled = true;
            this.Cell1.Location = new System.Drawing.Point(0, 0);
            this.Cell1.Name = "Cell1";
            this.Cell1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Cell1.OcxState")));
            this.Cell1.Size = new System.Drawing.Size(704, 473);
            this.Cell1.TabIndex = 3;
            // 
            // frmShowExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 473);
            this.Controls.Add(this.Cell1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShowExample";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "填写示范";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmShowExample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Cell1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxCELL50LibU.AxCell Cell1;
    }
}