using ERM.UI.Controls;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmPrintBat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintBat));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.lblMsg = new ERM.UI.Controls.SkinLabelEX();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.btnPrint = new ERM.UI.Controls.SkinButtonEX();
            this.chkAll = new TX.Framework.WindowUI.Controls.TXCheckBox();
            this.lstFiles = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.lstFiles);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(513, 386);
            this.panel1.TabIndex = 0;
            // 
            // lblMsg
            // 
            this.lblMsg.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lblMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lblMsg.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lblMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Black;
            this.lblMsg.Location = new System.Drawing.Point(16, 362);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(492, 21);
            this.lblMsg.TabIndex = 9;
            this.lblMsg.Text = "选择要打印的案卷进行打印，打印可能需要花费一定的时间，请稍候。\r\n";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnCancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnCancel.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DownBack = null;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(438, 319);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 6;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "关闭(&C)";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrint.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnPrint.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnPrint.BorderColor = System.Drawing.Color.Transparent;
            this.btnPrint.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.DownBack = null;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.GlowColor = System.Drawing.Color.Transparent;
            this.btnPrint.InnerBorderColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(357, 319);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.MouseBack = null;
            this.btnPrint.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.NormlBack = null;
            this.btnPrint.Palace = true;
            this.btnPrint.Radius = 6;
            this.btnPrint.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnPrint.Size = new System.Drawing.Size(70, 28);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(6, 319);
            this.chkAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAll.MinimumSize = new System.Drawing.Size(20, 20);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(80, 21);
            this.chkAll.TabIndex = 6;
            this.chkAll.Text = "全选/取消";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lstFiles
            // 
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(0, 0);
            this.lstFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(513, 310);
            this.lstFiles.TabIndex = 5;
            // 
            // frmPrintBat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(521, 424);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintBat";
            this.Text = "批量打印";
            this.Load += new System.EventHandler(this.frmPrintCell_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private Controls.SkinLabelEX lblMsg;
        private Controls.SkinButtonEX btnCancel;
        private Controls.SkinButtonEX btnPrint;
        private TXCheckBox chkAll;
        private CheckedListBox lstFiles;

    }
}