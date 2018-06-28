using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmPX
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPX));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.dgv_PX = new ERM.UI.Controls.Skin_DataGridEX();
            this.cl_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLast = new ERM.UI.Controls.SkinButtonEX();
            this.btnTop = new ERM.UI.Controls.SkinButtonEX();
            this.btnDown = new ERM.UI.Controls.SkinButtonEX();
            this.btnUp = new ERM.UI.Controls.SkinButtonEX();
            this.btnCancle = new ERM.UI.Controls.SkinButtonEX();
            this.btnSave = new ERM.UI.Controls.SkinButtonEX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PX)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.dgv_PX);
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.btnTop);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.btnCancle);
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
            this.panel1.Size = new System.Drawing.Size(863, 667);
            this.panel1.TabIndex = 0;
            // 
            // dgv_PX
            // 
            this.dgv_PX.AllowUserToAddRows = false;
            this.dgv_PX.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dgv_PX.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_PX.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_PX.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_PX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_PX.ColumnFont = null;
            this.dgv_PX.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PX.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_PX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_ID,
            this.cl_Index,
            this.cl_Name});
            this.dgv_PX.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_PX.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_PX.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_PX.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_PX.EnableHeadersVisualStyles = false;
            this.dgv_PX.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_PX.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgv_PX.HeadFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_PX.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_PX.LineNumberForeColor = System.Drawing.Color.Black;
            this.dgv_PX.Location = new System.Drawing.Point(0, 0);
            this.dgv_PX.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_PX.MultiSelect = false;
            this.dgv_PX.Name = "dgv_PX";
            this.dgv_PX.ReadOnly = true;
            this.dgv_PX.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_PX.RowHeadersVisible = false;
            this.dgv_PX.RowHeadersWidth = 22;
            this.dgv_PX.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_PX.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_PX.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_PX.RowTemplate.Height = 25;
            this.dgv_PX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PX.Size = new System.Drawing.Size(863, 613);
            this.dgv_PX.TabIndex = 7;
            this.dgv_PX.TitleBack = null;
            this.dgv_PX.TitleBackColorBegin = System.Drawing.Color.White;
            this.dgv_PX.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            // 
            // cl_ID
            // 
            this.cl_ID.HeaderText = "ID";
            this.cl_ID.Name = "cl_ID";
            this.cl_ID.ReadOnly = true;
            this.cl_ID.Visible = false;
            // 
            // cl_Index
            // 
            this.cl_Index.HeaderText = "序号";
            this.cl_Index.Name = "cl_Index";
            this.cl_Index.ReadOnly = true;
            this.cl_Index.Width = 80;
            // 
            // cl_Name
            // 
            this.cl_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cl_Name.HeaderText = "名称";
            this.cl_Name.Name = "cl_Name";
            this.cl_Name.ReadOnly = true;
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.Transparent;
            this.btnLast.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLast.BackgroundImage")));
            this.btnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLast.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnLast.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnLast.BorderColor = System.Drawing.Color.Transparent;
            this.btnLast.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.DownBack = null;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnLast.ForeColor = System.Drawing.Color.Black;
            this.btnLast.GlowColor = System.Drawing.Color.Transparent;
            this.btnLast.InnerBorderColor = System.Drawing.Color.White;
            this.btnLast.Location = new System.Drawing.Point(450, 627);
            this.btnLast.Margin = new System.Windows.Forms.Padding(0);
            this.btnLast.MouseBack = null;
            this.btnLast.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnLast.Name = "btnLast";
            this.btnLast.NormlBack = null;
            this.btnLast.Palace = true;
            this.btnLast.Radius = 10;
            this.btnLast.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnLast.Size = new System.Drawing.Size(70, 28);
            this.btnLast.TabIndex = 13;
            this.btnLast.TabStop = false;
            this.btnLast.Text = "置 后";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnTop
            // 
            this.btnTop.BackColor = System.Drawing.Color.Transparent;
            this.btnTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTop.BackgroundImage")));
            this.btnTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTop.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnTop.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnTop.BorderColor = System.Drawing.Color.Transparent;
            this.btnTop.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTop.DownBack = null;
            this.btnTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTop.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnTop.ForeColor = System.Drawing.Color.Black;
            this.btnTop.GlowColor = System.Drawing.Color.Transparent;
            this.btnTop.InnerBorderColor = System.Drawing.Color.White;
            this.btnTop.Location = new System.Drawing.Point(39, 627);
            this.btnTop.Margin = new System.Windows.Forms.Padding(0);
            this.btnTop.MouseBack = null;
            this.btnTop.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnTop.Name = "btnTop";
            this.btnTop.NormlBack = null;
            this.btnTop.Palace = true;
            this.btnTop.Radius = 10;
            this.btnTop.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnTop.Size = new System.Drawing.Size(70, 28);
            this.btnTop.TabIndex = 12;
            this.btnTop.TabStop = false;
            this.btnTop.Text = "置 顶";
            this.btnTop.UseVisualStyleBackColor = false;
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.Transparent;
            this.btnDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDown.BackgroundImage")));
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDown.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnDown.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnDown.BorderColor = System.Drawing.Color.Transparent;
            this.btnDown.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown.DownBack = null;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDown.ForeColor = System.Drawing.Color.Black;
            this.btnDown.GlowColor = System.Drawing.Color.Transparent;
            this.btnDown.InnerBorderColor = System.Drawing.Color.White;
            this.btnDown.Location = new System.Drawing.Point(314, 627);
            this.btnDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnDown.MouseBack = null;
            this.btnDown.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnDown.Name = "btnDown";
            this.btnDown.NormlBack = null;
            this.btnDown.Palace = true;
            this.btnDown.Radius = 10;
            this.btnDown.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnDown.Size = new System.Drawing.Size(70, 28);
            this.btnDown.TabIndex = 11;
            this.btnDown.TabStop = false;
            this.btnDown.Text = "下 移";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.Transparent;
            this.btnUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUp.BackgroundImage")));
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUp.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnUp.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnUp.BorderColor = System.Drawing.Color.Transparent;
            this.btnUp.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp.DownBack = null;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnUp.ForeColor = System.Drawing.Color.Black;
            this.btnUp.GlowColor = System.Drawing.Color.Transparent;
            this.btnUp.InnerBorderColor = System.Drawing.Color.White;
            this.btnUp.Location = new System.Drawing.Point(171, 627);
            this.btnUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnUp.MouseBack = null;
            this.btnUp.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnUp.Name = "btnUp";
            this.btnUp.NormlBack = null;
            this.btnUp.Palace = true;
            this.btnUp.Radius = 10;
            this.btnUp.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnUp.Size = new System.Drawing.Size(70, 28);
            this.btnUp.TabIndex = 10;
            this.btnUp.TabStop = false;
            this.btnUp.Text = "上 移";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.Color.Transparent;
            this.btnCancle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancle.BackgroundImage")));
            this.btnCancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancle.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnCancle.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnCancle.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancle.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancle.DownBack = null;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancle.ForeColor = System.Drawing.Color.Black;
            this.btnCancle.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancle.InnerBorderColor = System.Drawing.Color.White;
            this.btnCancle.Location = new System.Drawing.Point(738, 627);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancle.MouseBack = null;
            this.btnCancle.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.NormlBack = null;
            this.btnCancle.Palace = true;
            this.btnCancle.Radius = 10;
            this.btnCancle.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancle.Size = new System.Drawing.Size(70, 28);
            this.btnCancle.TabIndex = 9;
            this.btnCancle.TabStop = false;
            this.btnCancle.Text = "取 消";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
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
            this.btnSave.Location = new System.Drawing.Point(589, 627);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MouseBack = null;
            this.btnSave.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnSave.Name = "btnSave";
            this.btnSave.NormlBack = null;
            this.btnSave.Palace = true;
            this.btnSave.Radius = 10;
            this.btnSave.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSave.Size = new System.Drawing.Size(70, 28);
            this.btnSave.TabIndex = 8;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmPX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(871, 705);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPX";
            this.Text = "排序";
            this.Load += new System.EventHandler(this.frmPX_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private Skin_DataGridEX dgv_PX;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_Name;
        private SkinButtonEX btnLast;
        private SkinButtonEX btnTop;
        private SkinButtonEX btnDown;
        private SkinButtonEX btnUp;
        private SkinButtonEX btnCancle;
        private SkinButtonEX btnSave;


    }
}