using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmProjectCopy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjectCopy));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.label4 = new ERM.UI.Controls.SkinLabelEX();
            this.label3 = new ERM.UI.Controls.SkinLabelEX();
            this.cbx_Trage = new ERM.UI.Controls.TXComboxEX();
            this.cbx_Source = new ERM.UI.Controls.TXComboxEX();
            this.btn_Colse = new ERM.UI.Controls.SkinButtonEX();
            this.btn_Copy = new ERM.UI.Controls.SkinButtonEX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbx_Trage);
            this.panel1.Controls.Add(this.cbx_Source);
            this.panel1.Controls.Add(this.btn_Colse);
            this.panel1.Controls.Add(this.btn_Copy);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(336, 120);
            this.panel1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.label4.BorderColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(31, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "将工程：";
            // 
            // label3
            // 
            this.label3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "复制到工程：";
            // 
            // cbx_Trage
            // 
            this.cbx_Trage.DropDownHeight = 110;
            this.cbx_Trage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Trage.DropDownWidth = 233;
            this.cbx_Trage.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbx_Trage.FormattingEnabled = true;
            this.cbx_Trage.IntegralHeight = false;
            this.cbx_Trage.Location = new System.Drawing.Point(93, 46);
            this.cbx_Trage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_Trage.Name = "cbx_Trage";
            this.cbx_Trage.Size = new System.Drawing.Size(233, 25);
            this.cbx_Trage.TabIndex = 1;
            // 
            // cbx_Source
            // 
            this.cbx_Source.DropDownHeight = 110;
            this.cbx_Source.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Source.DropDownWidth = 233;
            this.cbx_Source.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbx_Source.FormattingEnabled = true;
            this.cbx_Source.IntegralHeight = false;
            this.cbx_Source.Location = new System.Drawing.Point(93, 16);
            this.cbx_Source.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_Source.Name = "cbx_Source";
            this.cbx_Source.Size = new System.Drawing.Size(233, 25);
            this.cbx_Source.TabIndex = 0;
            // 
            // btn_Colse
            // 
            this.btn_Colse.BackColor = System.Drawing.Color.Transparent;
            this.btn_Colse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Colse.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btn_Colse.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btn_Colse.BorderColor = System.Drawing.Color.Transparent;
            this.btn_Colse.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Colse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Colse.DownBack = null;
            this.btn_Colse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Colse.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Colse.ForeColor = System.Drawing.Color.Black;
            this.btn_Colse.GlowColor = System.Drawing.Color.Transparent;
            this.btn_Colse.InnerBorderColor = System.Drawing.Color.White;
            this.btn_Colse.Location = new System.Drawing.Point(190, 82);
            this.btn_Colse.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Colse.MouseBack = null;
            this.btn_Colse.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btn_Colse.Name = "btn_Colse";
            this.btn_Colse.NormlBack = null;
            this.btn_Colse.Palace = true;
            this.btn_Colse.Radius = 10;
            this.btn_Colse.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btn_Colse.Size = new System.Drawing.Size(70, 28);
            this.btn_Colse.TabIndex = 4;
            this.btn_Colse.TabStop = false;
            this.btn_Colse.Text = "关 闭";
            this.btn_Colse.UseVisualStyleBackColor = false;
            this.btn_Colse.Click += new System.EventHandler(this.btn_Colse_Click);
            // 
            // btn_Copy
            // 
            this.btn_Copy.BackColor = System.Drawing.Color.Transparent;
            this.btn_Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Copy.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btn_Copy.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btn_Copy.BorderColor = System.Drawing.Color.Transparent;
            this.btn_Copy.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Copy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Copy.DownBack = null;
            this.btn_Copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Copy.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Copy.ForeColor = System.Drawing.Color.Black;
            this.btn_Copy.GlowColor = System.Drawing.Color.Transparent;
            this.btn_Copy.InnerBorderColor = System.Drawing.Color.White;
            this.btn_Copy.Location = new System.Drawing.Point(108, 82);
            this.btn_Copy.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Copy.MouseBack = null;
            this.btn_Copy.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.NormlBack = null;
            this.btn_Copy.Palace = true;
            this.btn_Copy.Radius = 10;
            this.btn_Copy.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btn_Copy.Size = new System.Drawing.Size(70, 28);
            this.btn_Copy.TabIndex = 3;
            this.btn_Copy.TabStop = false;
            this.btn_Copy.Text = "复 制";
            this.btn_Copy.UseVisualStyleBackColor = false;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Click);
            // 
            // frmProjectCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(344, 158);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProjectCopy";
            this.Text = "工程复制";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProjectCopy_FormClosing);
            this.Load += new System.EventHandler(this.frmProjectCopy_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private ERM.UI.Controls.SkinButtonEX btn_Colse;
        private ERM.UI.Controls.SkinButtonEX btn_Copy;
        private TXComboxEX cbx_Source;
        private ERM.UI.Controls.SkinLabelEX label4;
        private ERM.UI.Controls.SkinLabelEX label3;
        private TXComboxEX cbx_Trage;

    }
}