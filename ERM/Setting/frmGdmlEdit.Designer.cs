using ERM.UI.Controls;
namespace ERM.UI
{
    partial class frmGdmlEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGdmlEdit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtGdtm = new ERM.UI.Controls.TXTextBoxEX();
            this.skinLabelEX2 = new ERM.UI.Controls.SkinLabelEX();
            this.btnCancel = new ERM.UI.Controls.SkinButtonEX();
            this.btnSave = new ERM.UI.Controls.SkinButtonEX();
            this.txtOrderIndex = new ERM.UI.NumberTextBox();
            this.skinLabelEX4 = new ERM.UI.Controls.SkinLabelEX();
            this.cboType = new ERM.UI.Controls.TXComboxEX();
            this.skinLabelEX1 = new ERM.UI.Controls.SkinLabelEX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtGdtm);
            this.panel1.Controls.Add(this.skinLabelEX2);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtOrderIndex);
            this.panel1.Controls.Add(this.skinLabelEX4);
            this.panel1.Controls.Add(this.cboType);
            this.panel1.Controls.Add(this.skinLabelEX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 138);
            this.panel1.TabIndex = 0;
            // 
            // txtGdtm
            // 
            this.txtGdtm.BackColor = System.Drawing.Color.Transparent;
            this.txtGdtm.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtGdtm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGdtm.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGdtm.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtGdtm.Image = null;
            this.txtGdtm.ImageSize = new System.Drawing.Size(0, 0);
            this.txtGdtm.Location = new System.Drawing.Point(77, 41);
            this.txtGdtm.MaxLength = 25;
            this.txtGdtm.Name = "txtGdtm";
            this.txtGdtm.Padding = new System.Windows.Forms.Padding(2);
            this.txtGdtm.PasswordChar = '\0';
            this.txtGdtm.Required = false;
            this.txtGdtm.Size = new System.Drawing.Size(212, 25);
            this.txtGdtm.TabIndex = 16;
            // 
            // skinLabelEX2
            // 
            this.skinLabelEX2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX2.AutoSize = true;
            this.skinLabelEX2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX2.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabelEX2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX2.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX2.Location = new System.Drawing.Point(15, 45);
            this.skinLabelEX2.Name = "skinLabelEX2";
            this.skinLabelEX2.Size = new System.Drawing.Size(56, 17);
            this.skinLabelEX2.TabIndex = 15;
            this.skinLabelEX2.Text = "目录名称";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnCancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnCancel.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DownBack = null;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(178, 101);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Palace = true;
            this.btnCancel.Radius = 10;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 12;
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
            this.btnSave.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnSave.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DownBack = null;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.Transparent;
            this.btnSave.InnerBorderColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(80, 101);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MouseBack = null;
            this.btnSave.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnSave.Name = "btnSave";
            this.btnSave.NormlBack = null;
            this.btnSave.Palace = true;
            this.btnSave.Radius = 10;
            this.btnSave.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSave.Size = new System.Drawing.Size(70, 28);
            this.btnSave.TabIndex = 11;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtOrderIndex
            // 
            this.txtOrderIndex.BackColor = System.Drawing.Color.Transparent;
            this.txtOrderIndex.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtOrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrderIndex.DecimalLength = 0;
            this.txtOrderIndex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrderIndex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOrderIndex.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtOrderIndex.Image = null;
            this.txtOrderIndex.ImageSize = new System.Drawing.Size(0, 0);
            this.txtOrderIndex.Location = new System.Drawing.Point(78, 72);
            this.txtOrderIndex.MaxValuelLength = 4;
            this.txtOrderIndex.Name = "txtOrderIndex";
            this.txtOrderIndex.PasswordChar = '\0';
            this.txtOrderIndex.Required = false;
            this.txtOrderIndex.ShowMsg = false;
            this.txtOrderIndex.Size = new System.Drawing.Size(212, 23);
            this.txtOrderIndex.TabIndex = 7;
            this.txtOrderIndex.Tag = "排序号,int";
            this.txtOrderIndex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderIndex_KeyDown);
            this.txtOrderIndex.Leave += new System.EventHandler(this.txtOrderIndex_Leave);
            // 
            // skinLabelEX4
            // 
            this.skinLabelEX4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX4.AutoSize = true;
            this.skinLabelEX4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX4.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabelEX4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX4.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX4.Location = new System.Drawing.Point(28, 75);
            this.skinLabelEX4.Name = "skinLabelEX4";
            this.skinLabelEX4.Size = new System.Drawing.Size(44, 17);
            this.skinLabelEX4.TabIndex = 6;
            this.skinLabelEX4.Text = "排序号";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(77, 10);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(212, 25);
            this.cboType.TabIndex = 1;
            // 
            // skinLabelEX1
            // 
            this.skinLabelEX1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX1.AutoSize = true;
            this.skinLabelEX1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabelEX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX1.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX1.Location = new System.Drawing.Point(15, 14);
            this.skinLabelEX1.Name = "skinLabelEX1";
            this.skinLabelEX1.Size = new System.Drawing.Size(56, 17);
            this.skinLabelEX1.TabIndex = 0;
            this.skinLabelEX1.Text = "文件类别";
            // 
            // frmGdmlEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(311, 176);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGdmlEdit";
            this.Text = "frmGdListEdit";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private TXComboxEX cboType;
        private Controls.SkinLabelEX skinLabelEX1;
        private NumberTextBox txtOrderIndex;
        private Controls.SkinLabelEX skinLabelEX4;
        private Controls.SkinButtonEX btnCancel;
        private Controls.SkinButtonEX btnSave;
        private Controls.TXTextBoxEX txtGdtm;
        private Controls.SkinLabelEX skinLabelEX2;
    }
}