using ERM.UI.Controls;
namespace ERM.UI
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.axsp = new AxiStylePDF.AxSPApplication();
            ((System.ComponentModel.ISupportInitialize)(this.axsp)).BeginInit();
            this.SuspendLayout();
            // 
            // axsp
            // 
            this.axsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axsp.Enabled = true;
            this.axsp.Location = new System.Drawing.Point(4, 34);
            this.axsp.Name = "axsp";
            this.axsp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axsp.OcxState")));
            this.axsp.Size = new System.Drawing.Size(893, 520);
            this.axsp.TabIndex = 0;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 558);
            this.Controls.Add(this.axsp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReport";
            this.Text = "报表打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.axsp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxiStylePDF.AxSPApplication axsp;

    }
}