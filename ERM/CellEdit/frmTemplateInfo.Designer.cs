namespace ERM.UI
{
    partial class frmTemplateInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemplateInfo));
            this.axCell1 = new AxCELL50Lib.AxCell();
            ((System.ComponentModel.ISupportInitialize)(this.axCell1)).BeginInit();
            this.SuspendLayout();
            // 
            // axCell1
            // 
            this.axCell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axCell1.Enabled = true;
            this.axCell1.Location = new System.Drawing.Point(4, 34);
            this.axCell1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.axCell1.Name = "axCell1";
            this.axCell1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCell1.OcxState")));
            this.axCell1.Size = new System.Drawing.Size(1028, 750);
            this.axCell1.TabIndex = 0;
            // 
            // frmTemplateInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1036, 788);
            this.Controls.Add(this.axCell1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "frmTemplateInfo";
            this.Text = "范例";
            this.Load += new System.EventHandler(this.frmTemplateInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axCell1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxCELL50Lib.AxCell axCell1;
    }
}