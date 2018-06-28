using ERM.UI.Controls;
namespace ERM.UI
{
    partial class frmGdmlList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGdmlList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.skin_ToolStripEX1 = new ERM.UI.Controls.Skin_ToolStripEX();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.gridGD = new ERM.UI.Controls.Skin_DataGridEX();
            this.txGroupBox1 = new TX.Framework.WindowUI.Controls.TXGroupBox();
            this.btnClear = new ERM.UI.Controls.SkinButtonEX();
            this.btnSearch = new ERM.UI.Controls.SkinButtonEX();
            this.txtTitle = new ERM.UI.Controls.TXTextBoxEX();
            this.skinLabelEX3 = new ERM.UI.Controls.SkinLabelEX();
            this.cboType = new ERM.UI.Controls.TXComboxEX();
            this.skinLabelEX1 = new ERM.UI.Controls.SkinLabelEX();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sorts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.skin_ToolStripEX1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGD)).BeginInit();
            this.txGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.skin_ToolStripEX1);
            this.panel1.Controls.Add(this.gridGD);
            this.panel1.Controls.Add(this.txGroupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 445);
            this.panel1.TabIndex = 0;
            // 
            // skin_ToolStripEX1
            // 
            this.skin_ToolStripEX1.Arrow = System.Drawing.Color.Black;
            this.skin_ToolStripEX1.AutoSize = false;
            this.skin_ToolStripEX1.Back = System.Drawing.Color.White;
            this.skin_ToolStripEX1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skin_ToolStripEX1.BackgroundImage")));
            this.skin_ToolStripEX1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skin_ToolStripEX1.BackRadius = 4;
            this.skin_ToolStripEX1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skin_ToolStripEX1.Base = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            this.skin_ToolStripEX1.BaseFore = System.Drawing.Color.Black;
            this.skin_ToolStripEX1.BaseForeAnamorphosis = false;
            this.skin_ToolStripEX1.BaseForeAnamorphosisBorder = 4;
            this.skin_ToolStripEX1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skin_ToolStripEX1.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.skin_ToolStripEX1.BaseHoverFore = System.Drawing.Color.Black;
            this.skin_ToolStripEX1.BaseItemAnamorphosis = true;
            this.skin_ToolStripEX1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skin_ToolStripEX1.BaseItemBorderShow = true;
            this.skin_ToolStripEX1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skin_ToolStripEX1.BaseItemDown")));
            this.skin_ToolStripEX1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skin_ToolStripEX1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skin_ToolStripEX1.BaseItemMouse")));
            this.skin_ToolStripEX1.BaseItemNorml = null;
            this.skin_ToolStripEX1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skin_ToolStripEX1.BaseItemRadius = 4;
            this.skin_ToolStripEX1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skin_ToolStripEX1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skin_ToolStripEX1.BindTabControl = null;
            this.skin_ToolStripEX1.CanOverflow = false;
            this.skin_ToolStripEX1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skin_ToolStripEX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skin_ToolStripEX1.Fore = System.Drawing.Color.Black;
            this.skin_ToolStripEX1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skin_ToolStripEX1.HoverFore = System.Drawing.Color.Black;
            this.skin_ToolStripEX1.ItemAnamorphosis = true;
            this.skin_ToolStripEX1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skin_ToolStripEX1.ItemBorderShow = true;
            this.skin_ToolStripEX1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skin_ToolStripEX1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skin_ToolStripEX1.ItemRadius = 4;
            this.skin_ToolStripEX1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skin_ToolStripEX1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton1});
            this.skin_ToolStripEX1.Location = new System.Drawing.Point(0, 0);
            this.skin_ToolStripEX1.Name = "skin_ToolStripEX1";
            this.skin_ToolStripEX1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skin_ToolStripEX1.Size = new System.Drawing.Size(802, 50);
            this.skin_ToolStripEX1.SkinAllColor = true;
            this.skin_ToolStripEX1.Stretch = true;
            this.skin_ToolStripEX1.TabIndex = 19;
            this.skin_ToolStripEX1.Text = "skin_ToolStripEX1";
            this.skin_ToolStripEX1.TitleAnamorphosis = true;
            this.skin_ToolStripEX1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skin_ToolStripEX1.TitleRadius = 4;
            this.skin_ToolStripEX1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.BackColor = System.Drawing.Color.Black;
            this.toolStripButton3.Image = global::ERM.UI.Properties.Resources.Page_Add;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(36, 47);
            this.toolStripButton3.Text = "新增";
            this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton3.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackColor = System.Drawing.Color.Black;
            this.toolStripButton2.Image = global::ERM.UI.Properties.Resources._02;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(36, 47);
            this.toolStripButton2.Text = "编辑";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.Black;
            this.toolStripButton1.Image = global::ERM.UI.Properties.Resources.anjuanico02;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(36, 47);
            this.toolStripButton1.Text = "删除";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // gridGD
            // 
            this.gridGD.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.gridGD.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridGD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridGD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridGD.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridGD.BackgroundColor = System.Drawing.Color.White;
            this.gridGD.ColumnFont = null;
            this.gridGD.ColumnForeColor = System.Drawing.Color.Black;
            this.gridGD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridGD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridGD.ColumnHeadersHeight = 26;
            this.gridGD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridGD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.fileType,
            this.GdName,
            this.sorts});
            this.gridGD.ColumnSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            this.gridGD.ColumnSelectForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridGD.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridGD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridGD.EnableHeadersVisualStyles = false;
            this.gridGD.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridGD.GridColor = System.Drawing.Color.Gainsboro;
            this.gridGD.HeadFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridGD.HeadSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.gridGD.HeadSelectForeColor = System.Drawing.SystemColors.ControlText;
            this.gridGD.LineNumberForeColor = System.Drawing.Color.Black;
            this.gridGD.Location = new System.Drawing.Point(0, 116);
            this.gridGD.MultiSelect = false;
            this.gridGD.Name = "gridGD";
            this.gridGD.ReadOnly = true;
            this.gridGD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridGD.RowHeadersVisible = false;
            this.gridGD.RowHeadersWidth = 22;
            this.gridGD.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.gridGD.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridGD.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridGD.RowTemplate.Height = 25;
            this.gridGD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGD.Size = new System.Drawing.Size(802, 326);
            this.gridGD.SkinGridColor = System.Drawing.Color.Gainsboro;
            this.gridGD.TabIndex = 13;
            this.gridGD.TitleBack = null;
            this.gridGD.TitleBackColorBegin = System.Drawing.Color.White;
            this.gridGD.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.gridGD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridGD_CellClick);
            this.gridGD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.skin_DataGridEX1_CellContentClick);
            this.gridGD.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridGD_CellDoubleClick);
            // 
            // txGroupBox1
            // 
            this.txGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.txGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.txGroupBox1.CaptionColor = System.Drawing.Color.Black;
            this.txGroupBox1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.txGroupBox1.Controls.Add(this.btnClear);
            this.txGroupBox1.Controls.Add(this.btnSearch);
            this.txGroupBox1.Controls.Add(this.txtTitle);
            this.txGroupBox1.Controls.Add(this.skinLabelEX3);
            this.txGroupBox1.Controls.Add(this.cboType);
            this.txGroupBox1.Controls.Add(this.skinLabelEX1);
            this.txGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txGroupBox1.Location = new System.Drawing.Point(6, 53);
            this.txGroupBox1.Name = "txGroupBox1";
            this.txGroupBox1.Size = new System.Drawing.Size(783, 57);
            this.txGroupBox1.TabIndex = 0;
            this.txGroupBox1.TabStop = false;
            this.txGroupBox1.Text = "查询";
            this.txGroupBox1.TextMargin = 6;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnClear.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnClear.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnClear.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.DownBack = null;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.GlowColor = System.Drawing.Color.Transparent;
            this.btnClear.InnerBorderColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(616, 19);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.MouseBack = null;
            this.btnClear.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnClear.Name = "btnClear";
            this.btnClear.NormlBack = null;
            this.btnClear.Palace = true;
            this.btnClear.Radius = 10;
            this.btnClear.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnClear.Size = new System.Drawing.Size(70, 28);
            this.btnClear.TabIndex = 9;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "重置";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnSearch.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnSearch.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnSearch.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.DownBack = null;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.GlowColor = System.Drawing.Color.Transparent;
            this.btnSearch.InnerBorderColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(527, 19);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.MouseBack = null;
            this.btnSearch.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NormlBack = null;
            this.btnSearch.Palace = true;
            this.btnSearch.Radius = 10;
            this.btnSearch.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSearch.Size = new System.Drawing.Size(75, 28);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "查询(&Enter)";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Transparent;
            this.txtTitle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTitle.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtTitle.Image = null;
            this.txtTitle.ImageSize = new System.Drawing.Size(0, 0);
            this.txtTitle.Location = new System.Drawing.Point(307, 22);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Padding = new System.Windows.Forms.Padding(2);
            this.txtTitle.PasswordChar = '\0';
            this.txtTitle.Required = false;
            this.txtTitle.Size = new System.Drawing.Size(196, 25);
            this.txtTitle.TabIndex = 5;
            // 
            // skinLabelEX3
            // 
            this.skinLabelEX3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX3.AutoSize = true;
            this.skinLabelEX3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX3.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabelEX3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX3.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX3.Location = new System.Drawing.Point(233, 25);
            this.skinLabelEX3.Name = "skinLabelEX3";
            this.skinLabelEX3.Size = new System.Drawing.Size(68, 17);
            this.skinLabelEX3.TabIndex = 4;
            this.skinLabelEX3.Text = "目录题名：";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "--请选择--"});
            this.cboType.Location = new System.Drawing.Point(88, 19);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 25);
            this.cboType.TabIndex = 1;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // skinLabelEX1
            // 
            this.skinLabelEX1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX1.AutoSize = true;
            this.skinLabelEX1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabelEX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX1.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX1.Location = new System.Drawing.Point(14, 25);
            this.skinLabelEX1.Name = "skinLabelEX1";
            this.skinLabelEX1.Size = new System.Drawing.Size(68, 17);
            this.skinLabelEX1.TabIndex = 0;
            this.skinLabelEX1.Text = "工程类别：";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.Visible = false;
            // 
            // fileType
            // 
            this.fileType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fileType.HeaderText = "归档目录类别";
            this.fileType.MinimumWidth = 100;
            this.fileType.Name = "fileType";
            this.fileType.ReadOnly = true;
            // 
            // GdName
            // 
            this.GdName.FillWeight = 100.4892F;
            this.GdName.HeaderText = "目录题名";
            this.GdName.MinimumWidth = 500;
            this.GdName.Name = "GdName";
            this.GdName.ReadOnly = true;
            // 
            // sorts
            // 
            this.sorts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sorts.FillWeight = 0.61567F;
            this.sorts.HeaderText = "排序位置";
            this.sorts.MinimumWidth = 100;
            this.sorts.Name = "sorts";
            this.sorts.ReadOnly = true;
            // 
            // frmGdmlList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 483);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGdmlList";
            this.Text = "归档目录管理";
            this.panel1.ResumeLayout(false);
            this.skin_ToolStripEX1.ResumeLayout(false);
            this.skin_ToolStripEX1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGD)).EndInit();
            this.txGroupBox1.ResumeLayout(false);
            this.txGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private TX.Framework.WindowUI.Controls.TXGroupBox txGroupBox1;
        private Controls.SkinButtonEX btnClear;
        private Controls.SkinButtonEX btnSearch;
        private Controls.TXTextBoxEX txtTitle;
        private Controls.SkinLabelEX skinLabelEX3;
        private TXComboxEX cboType;
        private Controls.SkinLabelEX skinLabelEX1;
        private Controls.Skin_DataGridEX gridGD;
        private Controls.Skin_ToolStripEX skin_ToolStripEX1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileType;
        private System.Windows.Forms.DataGridViewTextBoxColumn GdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sorts;
    }
}