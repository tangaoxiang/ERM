using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmMainGetTempletFromStandard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainGetTempletFromStandard));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customPanel1 = new ERM.UI.Controls.SkinPanelEX();
            this.txtTitle = new ERM.UI.Controls.TXTextBoxEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.customPanel3 = new ERM.UI.Controls.SkinPanelEX();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.btnSure = new ERM.UI.Controls.SkinButtonEX();
            this.customPanel2 = new ERM.UI.Controls.SkinPanelEX();
            this.label2 = new ERM.UI.Controls.SkinLabelEX();
            this.txtLocalPath = new ERM.UI.Controls.TXTextBoxEX();
            this.btnExplorer = new ERM.UI.Controls.SkinButtonEX();
            this.Cell1 = new AxCELL50Lib.AxCell();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.customPanel3.SuspendLayout();
            this.customPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cell1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.Cell1);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(518, 185);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.customPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.customPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.customPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(518, 185);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.customPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.customPanel1.Controls.Add(this.txtTitle);
            this.customPanel1.Controls.Add(this.label1);
            this.customPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.customPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel1.DownBack = null;
            this.customPanel1.Location = new System.Drawing.Point(3, 4);
            this.customPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customPanel1.MouseBack = null;
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.NormlBack = null;
            this.customPanel1.Radius = 4;
            this.customPanel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.customPanel1.Size = new System.Drawing.Size(512, 77);
            this.customPanel1.TabIndex = 1;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.SystemColors.Window;
            this.txtTitle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTitle.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtTitle.Image = null;
            this.txtTitle.ImageSize = new System.Drawing.Size(0, 0);
            this.txtTitle.Location = new System.Drawing.Point(110, 6);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTitle.PasswordChar = '\0';
            this.txtTitle.Required = false;
            this.txtTitle.Size = new System.Drawing.Size(406, 68);
            this.txtTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(36, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "表格名称：";
            // 
            // customPanel3
            // 
            this.customPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.customPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.customPanel3.Controls.Add(this.btnCancel);
            this.customPanel3.Controls.Add(this.btnSure);
            this.customPanel3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.customPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel3.DownBack = null;
            this.customPanel3.Location = new System.Drawing.Point(3, 149);
            this.customPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customPanel3.MouseBack = null;
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.NormlBack = null;
            this.customPanel3.Radius = 4;
            this.customPanel3.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.customPanel3.Size = new System.Drawing.Size(512, 106);
            this.customPanel3.TabIndex = 0;
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
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DownBack = null;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(255, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 10;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.BackColor = System.Drawing.Color.Transparent;
            this.btnSure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSure.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnSure.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnSure.BorderColor = System.Drawing.Color.Transparent;
            this.btnSure.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSure.DownBack = null;
            this.btnSure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSure.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSure.ForeColor = System.Drawing.Color.Black;
            this.btnSure.GlowColor = System.Drawing.Color.Transparent;
            this.btnSure.InnerBorderColor = System.Drawing.Color.White;
            this.btnSure.Location = new System.Drawing.Point(174, 6);
            this.btnSure.Margin = new System.Windows.Forms.Padding(0);
            this.btnSure.MouseBack = null;
            this.btnSure.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnSure.Name = "btnSure";
            this.btnSure.NormlBack = null;
            this.btnSure.Palace = true;
            this.btnSure.Radius = 10;
            this.btnSure.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSure.Size = new System.Drawing.Size(70, 28);
            this.btnSure.TabIndex = 0;
            this.btnSure.TabStop = false;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = false;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // customPanel2
            // 
            this.customPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.customPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.customPanel2.Controls.Add(this.label2);
            this.customPanel2.Controls.Add(this.txtLocalPath);
            this.customPanel2.Controls.Add(this.btnExplorer);
            this.customPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.customPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel2.DownBack = null;
            this.customPanel2.Location = new System.Drawing.Point(3, 89);
            this.customPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customPanel2.MouseBack = null;
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.NormlBack = null;
            this.customPanel2.Radius = 4;
            this.customPanel2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.customPanel2.Size = new System.Drawing.Size(512, 52);
            this.customPanel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(36, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "选择路径：";
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtLocalPath.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtLocalPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLocalPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLocalPath.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtLocalPath.Image = null;
            this.txtLocalPath.ImageSize = new System.Drawing.Size(0, 0);
            this.txtLocalPath.Location = new System.Drawing.Point(108, 10);
            this.txtLocalPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLocalPath.PasswordChar = '\0';
            this.txtLocalPath.ReadOnly = true;
            this.txtLocalPath.Required = false;
            this.txtLocalPath.Size = new System.Drawing.Size(295, 30);
            this.txtLocalPath.TabIndex = 0;
            // 
            // btnExplorer
            // 
            this.btnExplorer.BackColor = System.Drawing.Color.Transparent;
            this.btnExplorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExplorer.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnExplorer.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnExplorer.BorderColor = System.Drawing.Color.Transparent;
            this.btnExplorer.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExplorer.DownBack = null;
            this.btnExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExplorer.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnExplorer.ForeColor = System.Drawing.Color.Black;
            this.btnExplorer.GlowColor = System.Drawing.Color.Transparent;
            this.btnExplorer.InnerBorderColor = System.Drawing.Color.White;
            this.btnExplorer.Location = new System.Drawing.Point(411, 10);
            this.btnExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.btnExplorer.MouseBack = null;
            this.btnExplorer.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnExplorer.Name = "btnExplorer";
            this.btnExplorer.NormlBack = null;
            this.btnExplorer.Palace = true;
            this.btnExplorer.Radius = 10;
            this.btnExplorer.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnExplorer.Size = new System.Drawing.Size(70, 28);
            this.btnExplorer.TabIndex = 1;
            this.btnExplorer.TabStop = false;
            this.btnExplorer.Text = "浏览";
            this.btnExplorer.UseVisualStyleBackColor = false;
            this.btnExplorer.Click += new System.EventHandler(this.btnExplorer_Click);
            // 
            // Cell1
            // 
            this.Cell1.Enabled = true;
            this.Cell1.Location = new System.Drawing.Point(42, 166);
            this.Cell1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cell1.Name = "Cell1";
            this.Cell1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Cell1.OcxState")));
            this.Cell1.Size = new System.Drawing.Size(100, 50);
            this.Cell1.TabIndex = 34;
            this.Cell1.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmMainGetTempletFromStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(526, 223);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainGetTempletFromStandard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "新增";
            this.Load += new System.EventHandler(this.frmMainGetTempletFromStandard_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.customPanel1.ResumeLayout(false);
            this.customPanel1.PerformLayout();
            this.customPanel3.ResumeLayout(false);
            this.customPanel2.ResumeLayout(false);
            this.customPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cell1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SkinPanelEX customPanel1;
        private Controls.TXTextBoxEX txtTitle;
        private Controls.SkinLabelEX label1;
        private SkinPanelEX customPanel3;
        private Controls.SkinButtonEX btnCancel;
        private Controls.SkinButtonEX btnSure;
        private SkinPanelEX customPanel2;
        private Controls.SkinLabelEX label2;
        internal Controls.TXTextBoxEX txtLocalPath;
        private Controls.SkinButtonEX btnExplorer;
        private AxCELL50Lib.AxCell Cell1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

    }
}