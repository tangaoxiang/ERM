using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmSaveFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaveFile));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.grb_1 = new ERM.UI.Controls.TXGroupEX();
            this.pl_gd = new ERM.UI.Controls.SkinPanelEX();
            this.btnSave = new ERM.UI.Controls.SkinButtonEX();
            this.panel1.SuspendLayout();
            this.grb_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.grb_1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(950, 630);
            this.panel1.TabIndex = 0;
            // 
            // grb_1
            // 
            this.grb_1.BackColor = System.Drawing.Color.Transparent;
            this.grb_1.BorderColor = System.Drawing.Color.Gainsboro;
            this.grb_1.CaptionColor = System.Drawing.Color.Black;
            this.grb_1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.grb_1.Controls.Add(this.pl_gd);
            this.grb_1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.grb_1.ForeColor = System.Drawing.Color.Black;
            this.grb_1.Location = new System.Drawing.Point(4, 4);
            this.grb_1.Margin = new System.Windows.Forms.Padding(4);
            this.grb_1.Name = "grb_1";
            this.grb_1.Padding = new System.Windows.Forms.Padding(4);
            this.grb_1.Size = new System.Drawing.Size(940, 591);
            this.grb_1.TabIndex = 47;
            this.grb_1.TabStop = false;
            this.grb_1.Text = "省统表资料组卷分类";
            this.grb_1.TextMargin = 6;
            // 
            // pl_gd
            // 
            this.pl_gd.AutoScroll = true;
            this.pl_gd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.pl_gd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pl_gd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pl_gd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_gd.DownBack = null;
            this.pl_gd.Location = new System.Drawing.Point(4, 20);
            this.pl_gd.Margin = new System.Windows.Forms.Padding(4);
            this.pl_gd.MouseBack = null;
            this.pl_gd.Name = "pl_gd";
            this.pl_gd.NormlBack = null;
            this.pl_gd.Radius = 4;
            this.pl_gd.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.pl_gd.Size = new System.Drawing.Size(932, 567);
            this.pl_gd.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnSave.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DownBack = null;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnSave.GlowColor = System.Drawing.Color.Transparent;
            this.btnSave.InnerBorderColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(420, 598);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MouseBack = null;
            this.btnSave.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnSave.Name = "btnSave";
            this.btnSave.NormlBack = null;
            this.btnSave.Palace = true;
            this.btnSave.Radius = 10;
            this.btnSave.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSave.Size = new System.Drawing.Size(70, 28);
            this.btnSave.TabIndex = 46;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSaveFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(958, 668);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSaveFile";
            this.Text = "请选择-组卷类别";
            this.Load += new System.EventHandler(this.frmSaveFile_Load);
            this.Shown += new System.EventHandler(this.frmSaveFile_Shown);
            this.panel1.ResumeLayout(false);
            this.grb_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private TXGroupEX grb_1;
        private SkinPanelEX pl_gd;
        private SkinButtonEX btnSave;

    }
}