using ERM.UI.Controls;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmRegistSearch
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistSearch));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.btnSearchConfirm = new ERM.UI.Controls.SkinButtonEX();
            this.txtSearchTitle = new ERM.UI.Controls.TXTextBoxEX();
            this.label10 = new ERM.UI.Controls.SkinLabelEX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnSearchConfirm);
            this.panel1.Controls.Add(this.txtSearchTitle);
            this.panel1.Controls.Add(this.label10);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(424, 77);
            this.panel1.TabIndex = 0;
            // 
            // btnSearchConfirm
            // 
            this.btnSearchConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearchConfirm.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnSearchConfirm.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnSearchConfirm.BorderColor = System.Drawing.Color.Transparent;
            this.btnSearchConfirm.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSearchConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchConfirm.DownBack = null;
            this.btnSearchConfirm.FlatAppearance.BorderSize = 0;
            this.btnSearchConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchConfirm.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSearchConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnSearchConfirm.GlowColor = System.Drawing.Color.Transparent;
            this.btnSearchConfirm.InnerBorderColor = System.Drawing.Color.White;
            this.btnSearchConfirm.Location = new System.Drawing.Point(294, 40);
            this.btnSearchConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearchConfirm.MouseBack = null;
            this.btnSearchConfirm.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnSearchConfirm.Name = "btnSearchConfirm";
            this.btnSearchConfirm.NormlBack = null;
            this.btnSearchConfirm.Palace = true;
            this.btnSearchConfirm.Radius = 10;
            this.btnSearchConfirm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSearchConfirm.Size = new System.Drawing.Size(117, 28);
            this.btnSearchConfirm.TabIndex = 11;
            this.btnSearchConfirm.TabStop = false;
            this.btnSearchConfirm.Text = "查找下一个";
            this.btnSearchConfirm.UseVisualStyleBackColor = false;
            this.btnSearchConfirm.Click += new System.EventHandler(this.btnSearchConfirm_Click);
            // 
            // txtSearchTitle
            // 
            this.txtSearchTitle.BackColor = System.Drawing.Color.Transparent;
            this.txtSearchTitle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtSearchTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSearchTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSearchTitle.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtSearchTitle.Image = null;
            this.txtSearchTitle.ImageSize = new System.Drawing.Size(0, 0);
            this.txtSearchTitle.Location = new System.Drawing.Point(77, 8);
            this.txtSearchTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchTitle.MaxLength = 50;
            this.txtSearchTitle.Name = "txtSearchTitle";
            this.txtSearchTitle.Padding = new System.Windows.Forms.Padding(2);
            this.txtSearchTitle.PasswordChar = '\0';
            this.txtSearchTitle.Required = false;
            this.txtSearchTitle.Size = new System.Drawing.Size(334, 25);
            this.txtSearchTitle.TabIndex = 9;
            this.txtSearchTitle.TextChanged += new System.EventHandler(this.txtSearchTitle_TextChanged);
            // 
            // label10
            // 
            this.label10.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(16, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "节点名称";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // frmRegistSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(432, 115);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistSearch";
            this.ShowInTaskbar = false;
            this.Text = "查找";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private Controls.SkinButtonEX btnSearchConfirm;
        private TXTextBoxEX txtSearchTitle;
        private Controls.SkinLabelEX label10;

    }
}