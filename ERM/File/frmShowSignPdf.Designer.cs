namespace ERM.UI
{
    partial class frmShowSignPdf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowSignPdf));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ts = new System.Windows.Forms.ToolStrip();
            this.tsSignHand = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.axPDFReader1 = new AxiWebPDF.AxPDFReader();
            this.panel1.SuspendLayout();
            this.ts.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPDFReader1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 43);
            this.panel1.TabIndex = 1;
            // 
            // ts
            // 
            this.ts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSignHand,
            this.tsSave});
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(662, 43);
            this.ts.TabIndex = 0;
            // 
            // tsSignHand
            // 
            this.tsSignHand.Image = global::ERM.UI.Properties.Resources.handsign;
            this.tsSignHand.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSignHand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSignHand.Name = "tsSignHand";
            this.tsSignHand.Size = new System.Drawing.Size(57, 40);
            this.tsSignHand.Text = "手动签章";
            this.tsSignHand.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsSignHand.Click += new System.EventHandler(this.tsSignHand_Click);
            // 
            // tsSave
            // 
            this.tsSave.Image = global::ERM.UI.Properties.Resources.registico13;
            this.tsSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(33, 40);
            this.tsSave.Text = "保存";
            this.tsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.axPDFReader1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(662, 569);
            this.panel2.TabIndex = 0;
            // 
            // axPDFReader1
            // 
            this.axPDFReader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPDFReader1.Enabled = true;
            this.axPDFReader1.Location = new System.Drawing.Point(0, 0);
            this.axPDFReader1.Name = "axPDFReader1";
            this.axPDFReader1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPDFReader1.OcxState")));
            this.axPDFReader1.Size = new System.Drawing.Size(662, 569);
            this.axPDFReader1.TabIndex = 0;
            // 
            // frmShowSignPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 612);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShowSignPdf";
            this.Text = "查看合并文件";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmShowSignPdf_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPDFReader1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton tsSignHand;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton tsSave;
        private AxiWebPDF.AxPDFReader axPDFReader1;
    }
}