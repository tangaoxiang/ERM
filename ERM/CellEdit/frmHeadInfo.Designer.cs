using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmHeadInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHeadInfo));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.btnClearHeadInfo = new ERM.UI.Controls.SkinButtonEX();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.btnSave = new ERM.UI.Controls.SkinButtonEX();
            this.cboVars = new ERM.UI.Controls.TXComboxEX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClearHeadInfo);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.cboVars);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(335, 121);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "表头信息：";
            // 
            // btnClearHeadInfo
            // 
            this.btnClearHeadInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnClearHeadInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClearHeadInfo.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnClearHeadInfo.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnClearHeadInfo.BorderColor = System.Drawing.Color.Transparent;
            this.btnClearHeadInfo.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClearHeadInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearHeadInfo.DownBack = null;
            this.btnClearHeadInfo.FlatAppearance.BorderSize = 0;
            this.btnClearHeadInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearHeadInfo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnClearHeadInfo.ForeColor = System.Drawing.Color.Black;
            this.btnClearHeadInfo.GlowColor = System.Drawing.Color.Transparent;
            this.btnClearHeadInfo.InnerBorderColor = System.Drawing.Color.White;
            this.btnClearHeadInfo.Location = new System.Drawing.Point(255, 42);
            this.btnClearHeadInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearHeadInfo.MouseBack = null;
            this.btnClearHeadInfo.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnClearHeadInfo.Name = "btnClearHeadInfo";
            this.btnClearHeadInfo.NormlBack = null;
            this.btnClearHeadInfo.Palace = true;
            this.btnClearHeadInfo.Radius = 10;
            this.btnClearHeadInfo.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnClearHeadInfo.Size = new System.Drawing.Size(70, 28);
            this.btnClearHeadInfo.TabIndex = 8;
            this.btnClearHeadInfo.TabStop = false;
            this.btnClearHeadInfo.Text = "清除";
            this.btnClearHeadInfo.UseVisualStyleBackColor = false;
            this.btnClearHeadInfo.Click += new System.EventHandler(this.btnClearHeadInfo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnCancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnCancel.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DownBack = null;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(150, 83);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 10;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnSave.Location = new System.Drawing.Point(72, 83);
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
            // cboVars
            // 
            this.cboVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVars.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboVars.FormattingEnabled = true;
            this.cboVars.Location = new System.Drawing.Point(14, 42);
            this.cboVars.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboVars.Name = "cboVars";
            this.cboVars.Size = new System.Drawing.Size(235, 25);
            this.cboVars.TabIndex = 7;
            // 
            // frmHeadInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(343, 159);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(343, 159);
            this.Name = "frmHeadInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "表头信息";
            this.Load += new System.EventHandler(this.frmHeadInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private SkinLabelEX label1;
        private SkinButtonEX btnClearHeadInfo;
        private SkinButtonEX btnCancel;
        private SkinButtonEX btnSave;
        internal TXComboxEX cboVars;

    }
}