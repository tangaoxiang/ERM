namespace ERM.UI
{
    partial class ConvertCell2PDF
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertCell2PDF));
            this.Cell2 = new AxCELL50Lib.AxCell();
            this.axSPApplication1 = new AxiStylePDF.AxSPApplication();
            ((System.ComponentModel.ISupportInitialize)(this.Cell2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSPApplication1)).BeginInit();
            this.SuspendLayout();
            // 
            // Cell2
            // 
            this.Cell2.Enabled = true;
            this.Cell2.Location = new System.Drawing.Point(14, 23);
            this.Cell2.Name = "Cell2";
            this.Cell2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Cell2.OcxState")));
            this.Cell2.Size = new System.Drawing.Size(114, 77);
            this.Cell2.TabIndex = 10;
            this.Cell2.Visible = false;
            // 
            // axSPApplication1
            // 
            this.axSPApplication1.Enabled = true;
            this.axSPApplication1.Location = new System.Drawing.Point(14, 108);
            this.axSPApplication1.Name = "axSPApplication1";
            this.axSPApplication1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSPApplication1.OcxState")));
            this.axSPApplication1.Size = new System.Drawing.Size(192, 192);
            this.axSPApplication1.TabIndex = 11;
            // 
            // ConvertCell2PDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axSPApplication1);
            this.Controls.Add(this.Cell2);
            this.Name = "ConvertCell2PDF";
            this.Size = new System.Drawing.Size(211, 190);
            ((System.ComponentModel.ISupportInitialize)(this.Cell2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSPApplication1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxCELL50Lib.AxCell Cell2;
        private AxiStylePDF.AxSPApplication axSPApplication1;
   
    }
}
