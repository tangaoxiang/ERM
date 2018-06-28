using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI.CellEdit
{
    partial class frmSetSignatureDt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetSignatureDt));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.groupBox1 = new ERM.UI.Controls.TXGroupEX();
            this.dateTimeEx1 = new ERM.UI.DateTimeEx(this.components);
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.btnExplorer = new ERM.UI.Controls.SkinButtonEX();
            this.button1 = new ERM.UI.Controls.SkinButtonEX();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(321, 113);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.CaptionColor = System.Drawing.Color.Black;
            this.groupBox1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Controls.Add(this.dateTimeEx1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnExplorer);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(308, 61);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "临时签章日期";
            this.groupBox1.TextMargin = 6;
            // 
            // dateTimeEx1
            // 
            this.dateTimeEx1.BorderColor = System.Drawing.Color.Gainsboro;
            this.dateTimeEx1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateTimeEx1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimeEx1.ForeColor = System.Drawing.Color.Black;
            this.dateTimeEx1.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dateTimeEx1.Image = null;
            this.dateTimeEx1.ImageSize = new System.Drawing.Size(0, 0);
            this.dateTimeEx1.Location = new System.Drawing.Point(46, 26);
            this.dateTimeEx1.Name = "dateTimeEx1";
            this.dateTimeEx1.PasswordChar = '\0';
            this.dateTimeEx1.Required = false;
            this.dateTimeEx1.Size = new System.Drawing.Size(256, 23);
            this.dateTimeEx1.TabIndex = 11;
            this.dateTimeEx1.TextEx = "";
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // btnExplorer
            // 
            this.btnExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            this.btnExplorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExplorer.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnExplorer.BaseColor = System.Drawing.Color.Empty;
            this.btnExplorer.BorderColor = System.Drawing.Color.Transparent;
            this.btnExplorer.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExplorer.DownBack = null;
            this.btnExplorer.FlatAppearance.BorderSize = 0;
            this.btnExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExplorer.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExplorer.ForeColor = System.Drawing.Color.Black;
            this.btnExplorer.GlowColor = System.Drawing.Color.Transparent;
            this.btnExplorer.InnerBorderColor = System.Drawing.Color.White;
            this.btnExplorer.Location = new System.Drawing.Point(399, 78);
            this.btnExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.btnExplorer.MouseBack = null;
            this.btnExplorer.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnExplorer.Name = "btnExplorer";
            this.btnExplorer.NormlBack = null;
            this.btnExplorer.Palace = true;
            this.btnExplorer.Radius = 10;
            this.btnExplorer.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnExplorer.Size = new System.Drawing.Size(80, 30);
            this.btnExplorer.TabIndex = 4;
            this.btnExplorer.TabStop = false;
            this.btnExplorer.Text = "浏览...";
            this.btnExplorer.UseVisualStyleBackColor = true;
            this.btnExplorer.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.button1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.button1.BorderColor = System.Drawing.Color.Transparent;
            this.button1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DownBack = null;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.GlowColor = System.Drawing.Color.Transparent;
            this.button1.InnerBorderColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(127, 81);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.MouseBack = null;
            this.button1.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.button1.Name = "button1";
            this.button1.NormlBack = null;
            this.button1.Palace = true;
            this.button1.Radius = 10;
            this.button1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.button1.Size = new System.Drawing.Size(83, 28);
            this.button1.TabIndex = 11;
            this.button1.TabStop = false;
            this.button1.Text = "设置日期";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSetSignatureDt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(329, 151);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetSignatureDt";
            this.Text = "签章日期设定";
            this.Load += new System.EventHandler(this.frmSetSignatureDt_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private DateTimeEx dateTimeEx1;
        private Controls.SkinLabelEX label1;
        private Controls.SkinButtonEX btnExplorer;
        private Controls.SkinButtonEX button1;
        private TXGroupEX groupBox1;

    }
}