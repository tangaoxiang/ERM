using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmSetNodeName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetNodeName));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.btnConsle = new ERM.UI.Controls.SkinButtonEX();
            this.btnSave = new ERM.UI.Controls.SkinButtonEX();
            this.txtNodeName = new ERM.UI.Controls.TXTextBoxEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnConsle);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtNodeName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(342, 109);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnConsle
            // 
            this.btnConsle.BackColor = System.Drawing.Color.Transparent;
            this.btnConsle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConsle.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnConsle.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnConsle.BorderColor = System.Drawing.Color.Transparent;
            this.btnConsle.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnConsle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConsle.DownBack = null;
            this.btnConsle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnConsle.ForeColor = System.Drawing.Color.Black;
            this.btnConsle.GlowColor = System.Drawing.Color.Transparent;
            this.btnConsle.InnerBorderColor = System.Drawing.Color.White;
            this.btnConsle.Location = new System.Drawing.Point(260, 72);
            this.btnConsle.Margin = new System.Windows.Forms.Padding(0);
            this.btnConsle.MouseBack = null;
            this.btnConsle.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnConsle.Name = "btnConsle";
            this.btnConsle.NormlBack = null;
            this.btnConsle.Palace = true;
            this.btnConsle.Radius = 10;
            this.btnConsle.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnConsle.Size = new System.Drawing.Size(70, 28);
            this.btnConsle.TabIndex = 8;
            this.btnConsle.TabStop = false;
            this.btnConsle.Text = "取消";
            this.btnConsle.UseVisualStyleBackColor = false;
            this.btnConsle.Click += new System.EventHandler(this.btnConsle_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnSave.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DownBack = null;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.Transparent;
            this.btnSave.InnerBorderColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(176, 72);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MouseBack = null;
            this.btnSave.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnSave.Name = "btnSave";
            this.btnSave.NormlBack = null;
            this.btnSave.Palace = true;
            this.btnSave.Radius = 10;
            this.btnSave.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSave.Size = new System.Drawing.Size(70, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNodeName
            // 
            this.txtNodeName.BackColor = System.Drawing.Color.Transparent;
            this.txtNodeName.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNodeName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNodeName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNodeName.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtNodeName.Image = null;
            this.txtNodeName.ImageSize = new System.Drawing.Size(0, 0);
            this.txtNodeName.Location = new System.Drawing.Point(21, 40);
            this.txtNodeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNodeName.MaxLength = 25;
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNodeName.PasswordChar = '\0';
            this.txtNodeName.Required = false;
            this.txtNodeName.Size = new System.Drawing.Size(309, 25);
            this.txtNodeName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "请输入节点名称：";
            // 
            // frmSetNodeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(350, 147);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(348, 147);
            this.Name = "frmSetNodeName";
            this.Text = "设置节点名称";
            this.Load += new System.EventHandler(this.frmSetNodeName_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private Controls.SkinButtonEX btnConsle;
        private Controls.SkinButtonEX btnSave;
        private Controls.TXTextBoxEX txtNodeName;
        private Controls.SkinLabelEX label1;

    }
}