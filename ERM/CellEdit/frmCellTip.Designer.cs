namespace ERM.UI.CellEdit
{
    partial class frmCellTip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCellTip));
            this.htmlEditor1 = new WinHtmlEditor.HtmlEditor();
            this.SuspendLayout();
            // 
            // htmlEditor1
            // 
            this.htmlEditor1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.htmlEditor1.BodyInnerHTML = null;
            this.htmlEditor1.BodyInnerText = null;
            this.htmlEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlEditor1.EnterToBR = false;
            this.htmlEditor1.FontSize = WinHtmlEditor.FontSize.Three;
            this.htmlEditor1.Location = new System.Drawing.Point(4, 34);
            this.htmlEditor1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.htmlEditor1.Name = "htmlEditor1";
            this.htmlEditor1.ShowStatusBar = false;
            this.htmlEditor1.ShowToolBar = false;
            this.htmlEditor1.ShowWb = true;
            this.htmlEditor1.Size = new System.Drawing.Size(972, 750);
            this.htmlEditor1.TabIndex = 0;
            this.htmlEditor1.WebBrowserShortcutsEnabled = true;
            // 
            // frmCellTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(980, 788);
            this.Controls.Add(this.htmlEditor1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "frmCellTip";
            this.Text = "提示";
            this.ResumeLayout(false);

        }

        #endregion

        private WinHtmlEditor.HtmlEditor htmlEditor1;
    }
}