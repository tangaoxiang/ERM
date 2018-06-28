using CCWin.SkinControl;
using ERM.UI.Controls;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmExportProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportProject));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.tabControl1 = new TX.Framework.WindowUI.Controls.TXTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox1 = new ERM.UI.Controls.SkinListBoxEX();
            this.button3 = new ERM.UI.Controls.SkinButtonEX();
            this.button2 = new ERM.UI.Controls.SkinButtonEX();
            this.strFileName = new ERM.UI.Controls.SkinLabelEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.button1 = new ERM.UI.Controls.SkinButtonEX();
            this.lbl_BarText = new ERM.UI.Controls.SkinLabelEX();
            this.pgb_Bar = new CCWin.SkinControl.SkinProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.strFileName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lbl_BarText);
            this.panel1.Controls.Add(this.pgb_Bar);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(536, 428);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BaseTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.tabControl1.BorderColor = System.Drawing.Color.Gainsboro;
            this.tabControl1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.CheckedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.HeightLightTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(536, 310);
            this.tabControl1.TabCornerRadius = 3;
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(528, 277);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "备份/恢复";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Back = null;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(3, 4);
            this.listBox1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox1.MouseColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(206)))), ((int)(((byte)(255)))));
            this.listBox1.Name = "listBox1";
            this.listBox1.RowBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(218)))), ((int)(((byte)(242)))));
            this.listBox1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(160)))), ((int)(((byte)(222)))));
            this.listBox1.Size = new System.Drawing.Size(522, 276);
            this.listBox1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.button3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.button3.BorderColor = System.Drawing.Color.Transparent;
            this.button3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.DownBack = null;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.GlowColor = System.Drawing.Color.Transparent;
            this.button3.InnerBorderColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(307, 393);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.MouseBack = null;
            this.button3.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.button3.Name = "button3";
            this.button3.NormlBack = null;
            this.button3.Palace = true;
            this.button3.Radius = 10;
            this.button3.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.button3.Size = new System.Drawing.Size(70, 28);
            this.button3.TabIndex = 13;
            this.button3.TabStop = false;
            this.button3.Text = "浏览文件";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.button2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.button2.BorderColor = System.Drawing.Color.Transparent;
            this.button2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DownBack = null;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.GlowColor = System.Drawing.Color.Transparent;
            this.button2.InnerBorderColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(383, 393);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.MouseBack = null;
            this.button2.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.button2.Name = "button2";
            this.button2.NormlBack = null;
            this.button2.Palace = true;
            this.button2.Radius = 10;
            this.button2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.button2.Size = new System.Drawing.Size(70, 28);
            this.button2.TabIndex = 12;
            this.button2.TabStop = false;
            this.button2.Text = "开始";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // strFileName
            // 
            this.strFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.strFileName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.strFileName.BackColor = System.Drawing.Color.Transparent;
            this.strFileName.BorderColor = System.Drawing.Color.Transparent;
            this.strFileName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.strFileName.ForeColor = System.Drawing.Color.Black;
            this.strFileName.Location = new System.Drawing.Point(53, 368);
            this.strFileName.Name = "strFileName";
            this.strFileName.Size = new System.Drawing.Size(223, 17);
            this.strFileName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "文件：";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
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
            this.button1.Location = new System.Drawing.Point(458, 393);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.MouseBack = null;
            this.button1.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.button1.Name = "button1";
            this.button1.NormlBack = null;
            this.button1.Palace = true;
            this.button1.Radius = 10;
            this.button1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.button1.Size = new System.Drawing.Size(70, 28);
            this.button1.TabIndex = 10;
            this.button1.TabStop = false;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_BarText
            // 
            this.lbl_BarText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_BarText.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbl_BarText.AutoSize = true;
            this.lbl_BarText.BackColor = System.Drawing.Color.Transparent;
            this.lbl_BarText.BorderColor = System.Drawing.Color.Transparent;
            this.lbl_BarText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_BarText.ForeColor = System.Drawing.Color.Black;
            this.lbl_BarText.Location = new System.Drawing.Point(3, 317);
            this.lbl_BarText.Name = "lbl_BarText";
            this.lbl_BarText.Size = new System.Drawing.Size(43, 17);
            this.lbl_BarText.TabIndex = 15;
            this.lbl_BarText.Text = "label2";
            // 
            // pgb_Bar
            // 
            this.pgb_Bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgb_Bar.Back = null;
            this.pgb_Bar.BackColor = System.Drawing.Color.Transparent;
            this.pgb_Bar.BarBack = null;
            this.pgb_Bar.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.pgb_Bar.ForeColor = System.Drawing.Color.Red;
            this.pgb_Bar.Location = new System.Drawing.Point(3, 338);
            this.pgb_Bar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgb_Bar.Name = "pgb_Bar";
            this.pgb_Bar.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.pgb_Bar.Size = new System.Drawing.Size(525, 23);
            this.pgb_Bar.TabIndex = 14;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmExportProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(544, 466);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(544, 466);
            this.Name = "frmExportProject";
            this.Text = "备份/恢复";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExportProject_FormClosing);
            this.Load += new System.EventHandler(this.frmExportProject_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private TXTabControl tabControl1;
        private TabPage tabPage1;
        private SkinListBoxEX listBox1;
        private Controls.SkinButtonEX button3;
        private Controls.SkinButtonEX button2;
        private Controls.SkinLabelEX strFileName;
        private Controls.SkinLabelEX label1;
        private Controls.SkinButtonEX button1;
        private Controls.SkinLabelEX lbl_BarText;
        private SkinProgressBar pgb_Bar;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;

    }
}