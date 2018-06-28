using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmReName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReName));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.btnExit = new ERM.UI.Controls.SkinButtonEX();
            this.btnSave = new ERM.UI.Controls.SkinButtonEX();
            this.txtReName = new ERM.UI.Controls.TXTextBoxEX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtReName);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(392, 89);
            this.panel1.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnExit.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnExit.BorderColor = System.Drawing.Color.Transparent;
            this.btnExit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DownBack = null;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.GlowColor = System.Drawing.Color.Transparent;
            this.btnExit.InnerBorderColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(206, 49);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.MouseBack = null;
            this.btnExit.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnExit.Name = "btnExit";
            this.btnExit.NormlBack = null;
            this.btnExit.Palace = true;
            this.btnExit.Radius = 10;
            this.btnExit.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnExit.Size = new System.Drawing.Size(70, 28);
            this.btnExit.TabIndex = 6;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "取消";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnSave.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DownBack = null;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.Transparent;
            this.btnSave.InnerBorderColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(116, 49);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MouseBack = null;
            this.btnSave.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnSave.Name = "btnSave";
            this.btnSave.NormlBack = null;
            this.btnSave.Palace = true;
            this.btnSave.Radius = 10;
            this.btnSave.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSave.Size = new System.Drawing.Size(70, 28);
            this.btnSave.TabIndex = 5;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtReName
            // 
            this.txtReName.BackColor = System.Drawing.Color.Transparent;
            this.txtReName.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtReName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReName.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtReName.Image = null;
            this.txtReName.ImageSize = new System.Drawing.Size(0, 0);
            this.txtReName.Location = new System.Drawing.Point(24, 16);
            this.txtReName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtReName.MaxLength = 50;
            this.txtReName.Name = "txtReName";
            this.txtReName.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtReName.PasswordChar = '\0';
            this.txtReName.Required = false;
            this.txtReName.Size = new System.Drawing.Size(350, 25);
            this.txtReName.TabIndex = 4;
            // 
            // frmReName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(400, 127);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 152);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 127);
            this.Name = "frmReName";
            this.ShowInTaskbar = false;
            this.Text = "重命名";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private Controls.SkinButtonEX btnExit;
        private Controls.SkinButtonEX btnSave;
        private Controls.TXTextBoxEX txtReName;

    }
}