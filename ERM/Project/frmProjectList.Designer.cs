using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmProjectList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjectList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsList = new ERM.UI.Controls.Skin_ToolStripEX();
            this.ts_Find = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.tsEdit = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tdExProject = new System.Windows.Forms.ToolStripButton();
            this.tsImportProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_DaoChu = new System.Windows.Forms.ToolStripButton();
            this.tsb_DaoRu = new System.Windows.Forms.ToolStripButton();
            this.tsb_FuZhi = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSetPoint = new System.Windows.Forms.ToolStripButton();
            this.tsCheck = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.btnClear = new ERM.UI.Controls.SkinButtonEX();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new ERM.UI.Controls.SkinPanelEX();
            this.dgProject = new ERM.UI.Controls.Skin_DataGridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tsList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProject)).BeginInit();
            this.SuspendLayout();
            // 
            // tsList
            // 
            this.tsList.Arrow = System.Drawing.Color.Black;
            this.tsList.AutoSize = false;
            this.tsList.Back = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            this.tsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.tsList.BackgroundImage = global::ERM.UI.Properties.Resources.about_bg1;
            this.tsList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsList.BackRadius = 4;
            this.tsList.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.tsList.Base = System.Drawing.Color.Empty;
            this.tsList.BaseFore = System.Drawing.Color.Black;
            this.tsList.BaseForeAnamorphosis = false;
            this.tsList.BaseForeAnamorphosisBorder = 4;
            this.tsList.BaseForeAnamorphosisColor = System.Drawing.Color.Black;
            this.tsList.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.tsList.BaseHoverFore = System.Drawing.Color.Black;
            this.tsList.BaseItemAnamorphosis = true;
            this.tsList.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.BaseItemBorderShow = true;
            this.tsList.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("tsList.BaseItemDown")));
            this.tsList.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("tsList.BaseItemMouse")));
            this.tsList.BaseItemNorml = null;
            this.tsList.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.BaseItemRadius = 4;
            this.tsList.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsList.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.BindTabControl = null;
            this.tsList.CanOverflow = false;
            this.tsList.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.tsList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tsList.Fore = System.Drawing.Color.Black;
            this.tsList.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsList.HoverFore = System.Drawing.Color.Black;
            this.tsList.ItemAnamorphosis = true;
            this.tsList.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.ItemBorderShow = false;
            this.tsList.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.ItemRadius = 4;
            this.tsList.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_Find,
            this.toolStripSeparator1,
            this.tsAdd,
            this.tsEdit,
            this.tsDelete,
            this.toolStripSeparator4,
            this.tdExProject,
            this.tsImportProject,
            this.toolStripSeparator2,
            this.tsb_DaoChu,
            this.tsb_DaoRu,
            this.tsb_FuZhi,
            this.toolStripSeparator3,
            this.tsbSetPoint,
            this.tsCheck});
            this.tsList.Location = new System.Drawing.Point(4, 34);
            this.tsList.Name = "tsList";
            this.tsList.Padding = new System.Windows.Forms.Padding(0);
            this.tsList.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsList.Size = new System.Drawing.Size(653, 51);
            this.tsList.SkinAllColor = true;
            this.tsList.Stretch = true;
            this.tsList.TabIndex = 7;
            this.tsList.TitleAnamorphosis = true;
            this.tsList.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.tsList.TitleRadius = 4;
            this.tsList.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // ts_Find
            // 
            this.ts_Find.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.ts_Find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ts_Find.Image = global::ERM.UI.Properties.Resources.ico01;
            this.ts_Find.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ts_Find.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts_Find.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Find.Margin = new System.Windows.Forms.Padding(0);
            this.ts_Find.Name = "ts_Find";
            this.ts_Find.Size = new System.Drawing.Size(50, 51);
            this.ts_Find.Text = "查找(&F)";
            this.ts_Find.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ts_Find.Click += new System.EventHandler(this.ts_Find_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 51);
            // 
            // tsAdd
            // 
            this.tsAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.tsAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsAdd.Image = global::ERM.UI.Properties.Resources.ProjectSelect_Add11;
            this.tsAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Margin = new System.Windows.Forms.Padding(0);
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(58, 51);
            this.tsAdd.Text = " 新增(N)";
            this.tsAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // tsEdit
            // 
            this.tsEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsEdit.Image = global::ERM.UI.Properties.Resources.ProjectSelect_Edit11;
            this.tsEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEdit.Margin = new System.Windows.Forms.Padding(0);
            this.tsEdit.Name = "tsEdit";
            this.tsEdit.Size = new System.Drawing.Size(51, 51);
            this.tsEdit.Text = "修改(E)";
            this.tsEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsEdit.Click += new System.EventHandler(this.tsEdit_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsDelete.Image = global::ERM.UI.Properties.Resources.ProjectSelect_Del11;
            this.tsDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Margin = new System.Windows.Forms.Padding(0);
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(53, 51);
            this.tsDelete.Text = "删除(D)";
            this.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsDelete.Click += new System.EventHandler(this.btnProjectDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 51);
            // 
            // tdExProject
            // 
            this.tdExProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tdExProject.Image = global::ERM.UI.Properties.Resources.ProjectSelect_Import;
            this.tdExProject.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tdExProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tdExProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tdExProject.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tdExProject.Name = "tdExProject";
            this.tdExProject.Size = new System.Drawing.Size(52, 45);
            this.tdExProject.Text = "备份(&B)";
            this.tdExProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tdExProject.Click += new System.EventHandler(this.tdExProject_Click);
            // 
            // tsImportProject
            // 
            this.tsImportProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsImportProject.Image = global::ERM.UI.Properties.Resources.ProjectSelect_Import;
            this.tsImportProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsImportProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImportProject.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tsImportProject.Name = "tsImportProject";
            this.tsImportProject.Size = new System.Drawing.Size(52, 45);
            this.tsImportProject.Text = "恢复(&R)";
            this.tsImportProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsImportProject.Click += new System.EventHandler(this.tsImportProject_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 51);
            // 
            // tsb_DaoChu
            // 
            this.tsb_DaoChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.tsb_DaoChu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsb_DaoChu.Image = global::ERM.UI.Properties.Resources.anjuanico04;
            this.tsb_DaoChu.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb_DaoChu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_DaoChu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_DaoChu.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tsb_DaoChu.Name = "tsb_DaoChu";
            this.tsb_DaoChu.Size = new System.Drawing.Size(84, 48);
            this.tsb_DaoChu.Text = "导出项目信息";
            this.tsb_DaoChu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb_DaoChu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_DaoChu.Click += new System.EventHandler(this.tsb_DaoChu_Click);
            // 
            // tsb_DaoRu
            // 
            this.tsb_DaoRu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsb_DaoRu.Image = global::ERM.UI.Properties.Resources.CellEdit_Import;
            this.tsb_DaoRu.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb_DaoRu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_DaoRu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_DaoRu.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tsb_DaoRu.Name = "tsb_DaoRu";
            this.tsb_DaoRu.Size = new System.Drawing.Size(48, 48);
            this.tsb_DaoRu.Text = "导入(&I)";
            this.tsb_DaoRu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb_DaoRu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_DaoRu.Visible = false;
            this.tsb_DaoRu.Click += new System.EventHandler(this.tsb_DaoRu_Click);
            // 
            // tsb_FuZhi
            // 
            this.tsb_FuZhi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsb_FuZhi.Image = global::ERM.UI.Properties.Resources.scanbutton011;
            this.tsb_FuZhi.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb_FuZhi.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_FuZhi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_FuZhi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tsb_FuZhi.Name = "tsb_FuZhi";
            this.tsb_FuZhi.Size = new System.Drawing.Size(60, 48);
            this.tsb_FuZhi.Text = "工程复制";
            this.tsb_FuZhi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb_FuZhi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_FuZhi.Click += new System.EventHandler(this.tsb_FuZhi_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 51);
            // 
            // tsbSetPoint
            // 
            this.tsbSetPoint.Image = global::ERM.UI.Properties.Resources._04;
            this.tsbSetPoint.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSetPoint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSetPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetPoint.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tsbSetPoint.Name = "tsbSetPoint";
            this.tsbSetPoint.Size = new System.Drawing.Size(84, 48);
            this.tsbSetPoint.Text = "工程坐标设置";
            this.tsbSetPoint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSetPoint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSetPoint.Click += new System.EventHandler(this.tsbSetPoint_Click);
            // 
            // tsCheck
            // 
            this.tsCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsCheck.Image = global::ERM.UI.Properties.Resources.ProjectSelect_Exit;
            this.tsCheck.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsCheck.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCheck.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tsCheck.Name = "tsCheck";
            this.tsCheck.Size = new System.Drawing.Size(52, 48);
            this.tsCheck.Text = "退出(&C)";
            this.tsCheck.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsCheck.Click += new System.EventHandler(this.tsCheck_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 502);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(653, 47);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.BackRectangle = new System.Drawing.Rectangle(84, 29, 84, 29);
            this.btnClear.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnClear.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnClear.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.DownBack = null;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.GlowColor = System.Drawing.Color.Transparent;
            this.btnClear.InnerBorderColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(289, 11);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.MouseBack = null;
            this.btnClear.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnClear.Name = "btnClear";
            this.btnClear.NormlBack = null;
            this.btnClear.Palace = true;
            this.btnClear.Radius = 6;
            this.btnClear.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnClear.Size = new System.Drawing.Size(84, 29);
            this.btnClear.TabIndex = 7;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "选择";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(653, 47);
            this.label1.TabIndex = 8;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.dgProject);
            this.panel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.DownBack = null;
            this.panel2.Location = new System.Drawing.Point(4, 85);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.MouseBack = null;
            this.panel2.Name = "panel2";
            this.panel2.NormlBack = null;
            this.panel2.Radius = 4;
            this.panel2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel2.Size = new System.Drawing.Size(653, 417);
            this.panel2.TabIndex = 10;
            // 
            // dgProject
            // 
            this.dgProject.AllowUserToAddRows = false;
            this.dgProject.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dgProject.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProject.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgProject.BackgroundColor = System.Drawing.Color.White;
            this.dgProject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgProject.ColumnFont = null;
            this.dgProject.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgProject.ColumnHeadersHeight = 26;
            this.dgProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgProject.ColumnSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            this.dgProject.ColumnSelectForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProject.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProject.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgProject.EnableHeadersVisualStyles = false;
            this.dgProject.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgProject.GridColor = System.Drawing.Color.Gainsboro;
            this.dgProject.HeadFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgProject.HeadSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.dgProject.HeadSelectForeColor = System.Drawing.SystemColors.ControlText;
            this.dgProject.LineNumberForeColor = System.Drawing.Color.Black;
            this.dgProject.Location = new System.Drawing.Point(0, 0);
            this.dgProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgProject.MinimumSize = new System.Drawing.Size(655, 255);
            this.dgProject.MultiSelect = false;
            this.dgProject.Name = "dgProject";
            this.dgProject.ReadOnly = true;
            this.dgProject.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProject.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgProject.RowHeadersVisible = false;
            this.dgProject.RowHeadersWidth = 22;
            this.dgProject.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgProject.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgProject.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgProject.RowTemplate.Height = 25;
            this.dgProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProject.Size = new System.Drawing.Size(655, 417);
            this.dgProject.SkinGridColor = System.Drawing.Color.Gainsboro;
            this.dgProject.TabIndex = 10;
            this.dgProject.TitleBack = null;
            this.dgProject.TitleBackColorBegin = System.Drawing.Color.White;
            this.dgProject.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.dgProject.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProject_CellContentClick);
            this.dgProject.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProject_CellDoubleClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmProjectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(661, 553);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsList);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(661, 425);
            this.Name = "frmProjectList";
            this.Text = "工程管理";
            this.TitleSuitColor = true;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frmProjectList_Activated);
            this.Deactivate += new System.EventHandler(this.frmProjectList_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProjectSelect_FormClosing);
            this.Load += new System.EventHandler(this.frmProjectSelect_Load);
            this.Click += new System.EventHandler(this.frmProjectList_Click);
            this.Leave += new System.EventHandler(this.frmProjectList_Leave);
            this.MouseLeave += new System.EventHandler(this.frmProjectList_MouseLeave);
            this.tsList.ResumeLayout(false);
            this.tsList.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Skin_ToolStripEX tsList;
        public System.Windows.Forms.ToolStripButton tsImportProject;
        public System.Windows.Forms.ToolStripButton tsEdit;
        public System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripButton tsCheck;
        public System.Windows.Forms.ToolStripButton tsAdd;
        private SkinPanelEX panel1;
        private SkinPanelEX panel2;
        private ERM.UI.Controls.SkinButtonEX btnClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tdExProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.ToolStripButton ts_Find;
        public System.Windows.Forms.ToolStripButton tsb_DaoRu;
        private System.Windows.Forms.ToolStripButton tsb_FuZhi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsb_DaoChu;
        private Skin_DataGridEX dgProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbSetPoint;
    }
}