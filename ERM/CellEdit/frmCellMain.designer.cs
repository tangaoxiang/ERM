using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmCellMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCellMain));
            this.statusStrip1 = new TX.Framework.WindowUI.Controls.TXStatusStrip();
            this.tssLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuInput = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCopyFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPasteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuNewChildNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewTable = new System.Windows.Forms.ToolStripMenuItem();
            this.imageBorder = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu = new ERM.UI.Controls.Skin_MenuToolEX();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFind = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewChildNode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditNode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelNode = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.mainTool = new ERM.UI.Controls.Skin_ToolStripEX();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.Dro_Print = new System.Windows.Forms.ToolStripDropDownButton();
            this.Print_All = new System.Windows.Forms.ToolStripMenuItem();
            this.Print_Sava = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsOutput = new System.Windows.Forms.ToolStripButton();
            this.tsb_FL = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.customPanel2 = new ERM.UI.CustomPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Cell2 = new AxCELL50Lib.AxCell();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolArchive = new ERM.UI.MyToolStrip();
            this.t1_Find = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.t1_EditNode = new System.Windows.Forms.ToolStripButton();
            this.t1_DelNode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFileter = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNoCheckIn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHasCheckIn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolArchiveTab = new ERM.UI.Controls.Skin_ToolStripEX();
            this.tabArchive = new System.Windows.Forms.ToolStripLabel();
            this.imgHideArchive = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.mainTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.customPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cell2)).BeginInit();
            this.toolArchive.SuspendLayout();
            this.toolArchiveTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.statusStrip1.BackgroundImage = global::ERM.UI.Properties.Resources.titlebg;
            this.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusStrip1.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.statusStrip1.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel1,
            this.tssLabel2,
            this.tssLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(4, 679);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            this.statusStrip1.Size = new System.Drawing.Size(975, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLabel1
            // 
            this.tssLabel1.AutoSize = false;
            this.tssLabel1.BackColor = System.Drawing.Color.Transparent;
            this.tssLabel1.Name = "tssLabel1";
            this.tssLabel1.Size = new System.Drawing.Size(507, 17);
            this.tssLabel1.Spring = true;
            this.tssLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssLabel2
            // 
            this.tssLabel2.AutoSize = false;
            this.tssLabel2.BackColor = System.Drawing.Color.Transparent;
            this.tssLabel2.Name = "tssLabel2";
            this.tssLabel2.Size = new System.Drawing.Size(300, 17);
            // 
            // tssLabel3
            // 
            this.tssLabel3.AutoSize = false;
            this.tssLabel3.BackColor = System.Drawing.Color.Transparent;
            this.tssLabel3.Name = "tssLabel3";
            this.tssLabel3.Size = new System.Drawing.Size(150, 17);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuInput,
            this.MenuItemExp,
            this.toolStripMenuItem1,
            this.menuCopyFile,
            this.menuPasteFile,
            this.menuDelNode,
            this.menuEditNode,
            this.toolStripSeparator4,
            this.menuNewChildNode,
            this.menuNewTable});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(164, 192);
            // 
            // tsMenuInput
            // 
            this.tsMenuInput.Name = "tsMenuInput";
            this.tsMenuInput.Size = new System.Drawing.Size(163, 22);
            this.tsMenuInput.Text = "导入";
            this.tsMenuInput.Visible = false;
            this.tsMenuInput.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MenuItemExp
            // 
            this.MenuItemExp.Name = "MenuItemExp";
            this.MenuItemExp.Size = new System.Drawing.Size(163, 22);
            this.MenuItemExp.Text = "导出";
            this.MenuItemExp.Visible = false;
            this.MenuItemExp.Click += new System.EventHandler(this.MenuItemExp_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            this.toolStripMenuItem1.Visible = false;
            // 
            // menuCopyFile
            // 
            this.menuCopyFile.Name = "menuCopyFile";
            this.menuCopyFile.Size = new System.Drawing.Size(163, 22);
            this.menuCopyFile.Text = "复制文件";
            this.menuCopyFile.Click += new System.EventHandler(this.menuCopyFile_Click);
            // 
            // menuPasteFile
            // 
            this.menuPasteFile.Name = "menuPasteFile";
            this.menuPasteFile.Size = new System.Drawing.Size(163, 22);
            this.menuPasteFile.Text = "粘贴文件";
            this.menuPasteFile.Click += new System.EventHandler(this.menuPasteFile_Click);
            // 
            // menuDelNode
            // 
            this.menuDelNode.Image = ((System.Drawing.Image)(resources.GetObject("menuDelNode.Image")));
            this.menuDelNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuDelNode.Name = "menuDelNode";
            this.menuDelNode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.menuDelNode.Size = new System.Drawing.Size(163, 22);
            this.menuDelNode.Text = "删除(&D)";
            this.menuDelNode.Click += new System.EventHandler(this.menuDelNode_Click);
            // 
            // menuEditNode
            // 
            this.menuEditNode.Name = "menuEditNode";
            this.menuEditNode.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuEditNode.Size = new System.Drawing.Size(163, 22);
            this.menuEditNode.Text = "重命名";
            this.menuEditNode.Click += new System.EventHandler(this.menuEditNode_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(160, 6);
            // 
            // menuNewChildNode
            // 
            this.menuNewChildNode.Image = ((System.Drawing.Image)(resources.GetObject("menuNewChildNode.Image")));
            this.menuNewChildNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuNewChildNode.Name = "menuNewChildNode";
            this.menuNewChildNode.Size = new System.Drawing.Size(163, 22);
            this.menuNewChildNode.Text = "新增子目录(&L)";
            this.menuNewChildNode.Click += new System.EventHandler(this.menuNewChildNode_Click);
            // 
            // menuNewTable
            // 
            this.menuNewTable.Image = ((System.Drawing.Image)(resources.GetObject("menuNewTable.Image")));
            this.menuNewTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuNewTable.Name = "menuNewTable";
            this.menuNewTable.Size = new System.Drawing.Size(163, 22);
            this.menuNewTable.Text = "新增表格";
            this.menuNewTable.Click += new System.EventHandler(this.menuNewTable_Click);
            // 
            // imageBorder
            // 
            this.imageBorder.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageBorder.ImageStream")));
            this.imageBorder.TransparentColor = System.Drawing.Color.White;
            this.imageBorder.Images.SetKeyName(0, "");
            this.imageBorder.Images.SetKeyName(1, "");
            this.imageBorder.Images.SetKeyName(2, "");
            this.imageBorder.Images.SetKeyName(3, "");
            this.imageBorder.Images.SetKeyName(4, "");
            this.imageBorder.Images.SetKeyName(5, "");
            this.imageBorder.Images.SetKeyName(6, "");
            this.imageBorder.Images.SetKeyName(7, "");
            this.imageBorder.Images.SetKeyName(8, "");
            this.imageBorder.Images.SetKeyName(9, "");
            this.imageBorder.Images.SetKeyName(10, "");
            // 
            // mainMenu
            // 
            this.mainMenu.Arrow = System.Drawing.Color.Black;
            this.mainMenu.Back = System.Drawing.Color.White;
            this.mainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.mainMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainMenu.BackgroundImage")));
            this.mainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainMenu.BackRadius = 4;
            this.mainMenu.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.mainMenu.Base = System.Drawing.Color.Empty;
            this.mainMenu.BaseFore = System.Drawing.Color.Black;
            this.mainMenu.BaseForeAnamorphosis = false;
            this.mainMenu.BaseForeAnamorphosisBorder = 4;
            this.mainMenu.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.mainMenu.BaseHoverFore = System.Drawing.Color.Black;
            this.mainMenu.BaseItemAnamorphosis = true;
            this.mainMenu.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainMenu.BaseItemBorderShow = true;
            this.mainMenu.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("mainMenu.BaseItemDown")));
            this.mainMenu.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainMenu.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("mainMenu.BaseItemMouse")));
            this.mainMenu.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainMenu.BaseItemRadius = 4;
            this.mainMenu.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.mainMenu.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.mainMenu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainMenu.Fore = System.Drawing.Color.Black;
            this.mainMenu.HoverFore = System.Drawing.Color.Black;
            this.mainMenu.ItemAnamorphosis = true;
            this.mainMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainMenu.ItemBorderShow = true;
            this.mainMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainMenu.ItemRadius = 4;
            this.mainMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiManage});
            this.mainMenu.Location = new System.Drawing.Point(4, 34);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.mainMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.mainMenu.Size = new System.Drawing.Size(975, 27);
            this.mainMenu.SkinAllColor = true;
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "myMenuStrip1";
            this.mainMenu.TitleAnamorphosis = true;
            this.mainMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.mainMenu.TitleRadius = 4;
            this.mainMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClose});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(58, 21);
            this.tsmiFile.Text = "文件(&F)";
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(116, 22);
            this.tsmiClose.Text = "关闭(&C)";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // tsmiManage
            // 
            this.tsmiManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFind,
            this.toolStripSeparator9,
            this.tsmiNew,
            this.tsmiEditNode,
            this.tsmiDelNode});
            this.tsmiManage.Name = "tsmiManage";
            this.tsmiManage.Size = new System.Drawing.Size(88, 21);
            this.tsmiManage.Text = "目录管理(&M)";
            // 
            // tsmiFind
            // 
            this.tsmiFind.Image = ((System.Drawing.Image)(resources.GetObject("tsmiFind.Image")));
            this.tsmiFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiFind.Name = "tsmiFind";
            this.tsmiFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmiFind.Size = new System.Drawing.Size(167, 22);
            this.tsmiFind.Text = "快速查找";
            this.tsmiFind.Click += new System.EventHandler(this.tsmiFind_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(164, 6);
            // 
            // tsmiNew
            // 
            this.tsmiNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewChildNode,
            this.tsmiNewTable});
            this.tsmiNew.Image = ((System.Drawing.Image)(resources.GetObject("tsmiNew.Image")));
            this.tsmiNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(167, 22);
            this.tsmiNew.Text = "新增";
            // 
            // tsmiNewChildNode
            // 
            this.tsmiNewChildNode.Image = ((System.Drawing.Image)(resources.GetObject("tsmiNewChildNode.Image")));
            this.tsmiNewChildNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiNewChildNode.Name = "tsmiNewChildNode";
            this.tsmiNewChildNode.Size = new System.Drawing.Size(152, 22);
            this.tsmiNewChildNode.Text = "新增子目录(&B)";
            this.tsmiNewChildNode.Click += new System.EventHandler(this.tsmiNewChildNode_Click);
            // 
            // tsmiNewTable
            // 
            this.tsmiNewTable.Image = ((System.Drawing.Image)(resources.GetObject("tsmiNewTable.Image")));
            this.tsmiNewTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiNewTable.Name = "tsmiNewTable";
            this.tsmiNewTable.Size = new System.Drawing.Size(152, 22);
            this.tsmiNewTable.Text = "新增模板...";
            this.tsmiNewTable.Click += new System.EventHandler(this.tsmiNewTable_Click);
            // 
            // tsmiEditNode
            // 
            this.tsmiEditNode.Name = "tsmiEditNode";
            this.tsmiEditNode.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmiEditNode.Size = new System.Drawing.Size(167, 22);
            this.tsmiEditNode.Text = "修改";
            this.tsmiEditNode.Click += new System.EventHandler(this.tsmiEditNode_Click);
            // 
            // tsmiDelNode
            // 
            this.tsmiDelNode.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDelNode.Image")));
            this.tsmiDelNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiDelNode.Name = "tsmiDelNode";
            this.tsmiDelNode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.tsmiDelNode.Size = new System.Drawing.Size(167, 22);
            this.tsmiDelNode.Text = "删除(&D)";
            this.tsmiDelNode.Click += new System.EventHandler(this.tsmiDelNode_Click);
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Margin = new System.Windows.Forms.Padding(1, 2, 8, 2);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(60, 50);
            this.btnFind.Text = "快速查找";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Margin = new System.Windows.Forms.Padding(1, 2, 8, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 50);
            this.btnClose.Text = " 关闭 ";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // mainTool
            // 
            this.mainTool.Arrow = System.Drawing.Color.Black;
            this.mainTool.AutoSize = false;
            this.mainTool.Back = System.Drawing.Color.White;
            this.mainTool.BackgroundImage = global::ERM.UI.Properties.Resources.about_bg;
            this.mainTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainTool.BackRadius = 4;
            this.mainTool.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.mainTool.Base = System.Drawing.Color.Empty;
            this.mainTool.BaseFore = System.Drawing.Color.Black;
            this.mainTool.BaseForeAnamorphosis = false;
            this.mainTool.BaseForeAnamorphosisBorder = 4;
            this.mainTool.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.mainTool.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.mainTool.BaseHoverFore = System.Drawing.Color.Black;
            this.mainTool.BaseItemAnamorphosis = true;
            this.mainTool.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainTool.BaseItemBorderShow = true;
            this.mainTool.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("mainTool.BaseItemDown")));
            this.mainTool.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainTool.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("mainTool.BaseItemMouse")));
            this.mainTool.BaseItemNorml = null;
            this.mainTool.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainTool.BaseItemRadius = 4;
            this.mainTool.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.mainTool.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainTool.BindTabControl = null;
            this.mainTool.CanOverflow = false;
            this.mainTool.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.mainTool.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainTool.Fore = System.Drawing.Color.Black;
            this.mainTool.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.mainTool.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainTool.HoverFore = System.Drawing.Color.Black;
            this.mainTool.ItemAnamorphosis = true;
            this.mainTool.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainTool.ItemBorderShow = true;
            this.mainTool.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainTool.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.mainTool.ItemRadius = 4;
            this.mainTool.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.mainTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFind,
            this.toolStripSeparator7,
            this.Dro_Print,
            this.toolStripButton1,
            this.tsOutput,
            this.tsb_FL,
            this.btnClose});
            this.mainTool.Location = new System.Drawing.Point(4, 61);
            this.mainTool.Name = "mainTool";
            this.mainTool.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.mainTool.Size = new System.Drawing.Size(975, 54);
            this.mainTool.SkinAllColor = true;
            this.mainTool.Stretch = true;
            this.mainTool.TabIndex = 4;
            this.mainTool.Text = "MyToolStrip1";
            this.mainTool.TitleAnamorphosis = true;
            this.mainTool.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.mainTool.TitleRadius = 4;
            this.mainTool.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 54);
            // 
            // Dro_Print
            // 
            this.Dro_Print.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Print_All,
            this.Print_Sava});
            this.Dro_Print.Image = global::ERM.UI.Properties.Resources.批量打印;
            this.Dro_Print.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Dro_Print.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Dro_Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Dro_Print.Name = "Dro_Print";
            this.Dro_Print.Size = new System.Drawing.Size(69, 51);
            this.Dro_Print.Text = "批量打印";
            this.Dro_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Print_All
            // 
            this.Print_All.Name = "Print_All";
            this.Print_All.Size = new System.Drawing.Size(172, 22);
            this.Print_All.Text = "全部资料用表";
            this.Print_All.Click += new System.EventHandler(this.Print_All_Click);
            // 
            // Print_Sava
            // 
            this.Print_Sava.Name = "Print_Sava";
            this.Print_Sava.Size = new System.Drawing.Size(172, 22);
            this.Print_Sava.Text = "已保存的资料用表";
            this.Print_Sava.Click += new System.EventHandler(this.Print_Sava_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(1, 2, 8, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 50);
            this.toolStripButton1.Text = "导入数据";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsOutput
            // 
            this.tsOutput.Image = global::ERM.UI.Properties.Resources.CellEdit_Collect;
            this.tsOutput.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsOutput.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOutput.Margin = new System.Windows.Forms.Padding(1, 2, 8, 2);
            this.tsOutput.Name = "tsOutput";
            this.tsOutput.Size = new System.Drawing.Size(60, 50);
            this.tsOutput.Text = "导出数据";
            this.tsOutput.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsOutput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsOutput.Visible = false;
            this.tsOutput.Click += new System.EventHandler(this.MenuItemExp_Click);
            // 
            // tsb_FL
            // 
            this.tsb_FL.AutoSize = false;
            this.tsb_FL.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb_FL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_FL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_FL.Name = "tsb_FL";
            this.tsb_FL.Size = new System.Drawing.Size(44, 44);
            this.tsb_FL.Text = "范例";
            this.tsb_FL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_FL.Click += new System.EventHandler(this.tsb_FL_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::ERM.UI.Properties.Settings.Default, "TreeWidth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(4, 115);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.customPanel2);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(1, 2, 1, 4);
            this.splitContainer1.Panel1MinSize = 2;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(975, 564);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 7;
            // 
            // customPanel2
            // 
            this.customPanel2.Controls.Add(this.splitContainer2);
            this.customPanel2.Controls.Add(this.toolArchive);
            this.customPanel2.Controls.Add(this.toolArchiveTab);
            this.customPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel2.Location = new System.Drawing.Point(1, 2);
            this.customPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Padding = new System.Windows.Forms.Padding(1, 0, 1, 2);
            this.customPanel2.Size = new System.Drawing.Size(973, 558);
            this.customPanel2.StartColor = System.Drawing.SystemColors.Control;
            this.customPanel2.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(1, 51);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.Cell2);
            this.splitContainer2.Panel2.Controls.Add(this.listView1);
            this.splitContainer2.Size = new System.Drawing.Size(971, 505);
            this.splitContainer2.SplitterDistance = 228;
            this.splitContainer2.TabIndex = 9;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.ContextMenuStrip = this.contextMenu;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.ItemHeight = 18;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(228, 505);
            this.treeView1.TabIndex = 10;
            this.treeView1.TabStop = false;
            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // Cell2
            // 
            this.Cell2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell2.Enabled = true;
            this.Cell2.Location = new System.Drawing.Point(0, 0);
            this.Cell2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cell2.Name = "Cell2";
            this.Cell2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Cell2.OcxState")));
            this.Cell2.Size = new System.Drawing.Size(739, 505);
            this.Cell2.TabIndex = 0;
            this.Cell2.DropCellSelected += new AxCELL50Lib._DCell2000Events_DropCellSelectedEventHandler(this.Cell2_DropCellSelected);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(739, 505);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 408;
            // 
            // toolArchive
            // 
            this.toolArchive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.toolArchive.CanOverflow = false;
            this.toolArchive.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolArchive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.t1_Find,
            this.toolStripSeparator3,
            this.t1_EditNode,
            this.t1_DelNode,
            this.toolStripSeparator1,
            this.btnFileter});
            this.toolArchive.Location = new System.Drawing.Point(1, 26);
            this.toolArchive.Name = "toolArchive";
            this.toolArchive.Padding = new System.Windows.Forms.Padding(0);
            this.toolArchive.Size = new System.Drawing.Size(971, 25);
            this.toolArchive.TabIndex = 2;
            this.toolArchive.Text = "myToolStrip1";
            // 
            // t1_Find
            // 
            this.t1_Find.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.t1_Find.Image = ((System.Drawing.Image)(resources.GetObject("t1_Find.Image")));
            this.t1_Find.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.t1_Find.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.t1_Find.Name = "t1_Find";
            this.t1_Find.Size = new System.Drawing.Size(23, 22);
            this.t1_Find.Text = "查找";
            this.t1_Find.Click += new System.EventHandler(this.t1_Find_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // t1_EditNode
            // 
            this.t1_EditNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.t1_EditNode.Image = ((System.Drawing.Image)(resources.GetObject("t1_EditNode.Image")));
            this.t1_EditNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.t1_EditNode.Name = "t1_EditNode";
            this.t1_EditNode.Size = new System.Drawing.Size(23, 22);
            this.t1_EditNode.Text = "修改";
            this.t1_EditNode.ToolTipText = "修改";
            this.t1_EditNode.Click += new System.EventHandler(this.t1_EditNode_Click);
            // 
            // t1_DelNode
            // 
            this.t1_DelNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.t1_DelNode.Image = ((System.Drawing.Image)(resources.GetObject("t1_DelNode.Image")));
            this.t1_DelNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.t1_DelNode.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.t1_DelNode.Name = "t1_DelNode";
            this.t1_DelNode.Size = new System.Drawing.Size(23, 22);
            this.t1_DelNode.Text = "删除";
            this.t1_DelNode.Click += new System.EventHandler(this.t1_DelNode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
            // 
            // btnFileter
            // 
            this.btnFileter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAll,
            this.btnNoCheckIn,
            this.btnHasCheckIn});
            this.btnFileter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFileter.Name = "btnFileter";
            this.btnFileter.Size = new System.Drawing.Size(45, 22);
            this.btnFileter.Text = "全部";
            this.btnFileter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnAll
            // 
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(136, 22);
            this.btnAll.Text = "全部";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnNoCheckIn
            // 
            this.btnNoCheckIn.Image = global::ERM.UI.Properties.Resources.tree_file;
            this.btnNoCheckIn.ImageTransparentColor = System.Drawing.Color.White;
            this.btnNoCheckIn.Name = "btnNoCheckIn";
            this.btnNoCheckIn.Size = new System.Drawing.Size(136, 22);
            this.btnNoCheckIn.Text = "未登记表格";
            this.btnNoCheckIn.Click += new System.EventHandler(this.btnNoCheckIn_Click);
            // 
            // btnHasCheckIn
            // 
            this.btnHasCheckIn.Image = global::ERM.UI.Properties.Resources.tree_efile;
            this.btnHasCheckIn.Name = "btnHasCheckIn";
            this.btnHasCheckIn.Size = new System.Drawing.Size(136, 22);
            this.btnHasCheckIn.Text = "已登记表格";
            this.btnHasCheckIn.Click += new System.EventHandler(this.btnHasCheckIn_Click);
            // 
            // toolArchiveTab
            // 
            this.toolArchiveTab.Arrow = System.Drawing.Color.Black;
            this.toolArchiveTab.AutoSize = false;
            this.toolArchiveTab.Back = System.Drawing.Color.White;
            this.toolArchiveTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.toolArchiveTab.BackgroundImage = global::ERM.UI.Properties.Resources.tit_bg;
            this.toolArchiveTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolArchiveTab.BackRadius = 4;
            this.toolArchiveTab.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.toolArchiveTab.Base = System.Drawing.Color.Empty;
            this.toolArchiveTab.BaseFore = System.Drawing.Color.Black;
            this.toolArchiveTab.BaseForeAnamorphosis = false;
            this.toolArchiveTab.BaseForeAnamorphosisBorder = 4;
            this.toolArchiveTab.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.toolArchiveTab.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.toolArchiveTab.BaseHoverFore = System.Drawing.Color.Black;
            this.toolArchiveTab.BaseItemAnamorphosis = true;
            this.toolArchiveTab.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolArchiveTab.BaseItemBorderShow = true;
            this.toolArchiveTab.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("toolArchiveTab.BaseItemDown")));
            this.toolArchiveTab.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolArchiveTab.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("toolArchiveTab.BaseItemMouse")));
            this.toolArchiveTab.BaseItemNorml = null;
            this.toolArchiveTab.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolArchiveTab.BaseItemRadius = 4;
            this.toolArchiveTab.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.toolArchiveTab.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolArchiveTab.BindTabControl = null;
            this.toolArchiveTab.CanOverflow = false;
            this.toolArchiveTab.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.toolArchiveTab.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolArchiveTab.Fore = System.Drawing.Color.Black;
            this.toolArchiveTab.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolArchiveTab.HoverFore = System.Drawing.Color.Black;
            this.toolArchiveTab.ItemAnamorphosis = true;
            this.toolArchiveTab.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolArchiveTab.ItemBorderShow = true;
            this.toolArchiveTab.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolArchiveTab.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolArchiveTab.ItemRadius = 4;
            this.toolArchiveTab.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.toolArchiveTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabArchive,
            this.imgHideArchive});
            this.toolArchiveTab.Location = new System.Drawing.Point(1, 0);
            this.toolArchiveTab.Name = "toolArchiveTab";
            this.toolArchiveTab.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.toolArchiveTab.Size = new System.Drawing.Size(971, 26);
            this.toolArchiveTab.SkinAllColor = true;
            this.toolArchiveTab.Stretch = true;
            this.toolArchiveTab.TabIndex = 0;
            this.toolArchiveTab.Text = "myToolStrip1";
            this.toolArchiveTab.TitleAnamorphosis = true;
            this.toolArchiveTab.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.toolArchiveTab.TitleRadius = 4;
            this.toolArchiveTab.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tabArchive
            // 
            this.tabArchive.BackColor = System.Drawing.Color.Transparent;
            this.tabArchive.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabArchive.BackgroundImage")));
            this.tabArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tabArchive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tabArchive.Margin = new System.Windows.Forms.Padding(8, 3, 0, 0);
            this.tabArchive.Name = "tabArchive";
            this.tabArchive.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tabArchive.RightToLeftAutoMirrorImage = true;
            this.tabArchive.Size = new System.Drawing.Size(64, 23);
            this.tabArchive.Text = "归档范围";
            this.tabArchive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // imgHideArchive
            // 
            this.imgHideArchive.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.imgHideArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imgHideArchive.Enabled = false;
            this.imgHideArchive.Image = ((System.Drawing.Image)(resources.GetObject("imgHideArchive.Image")));
            this.imgHideArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imgHideArchive.Name = "imgHideArchive";
            this.imgHideArchive.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.imgHideArchive.Size = new System.Drawing.Size(23, 23);
            this.imgHideArchive.Text = "关闭";
            this.imgHideArchive.Visible = false;
            // 
            // frmCellMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(983, 705);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainTool);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "frmCellMain";
            this.Text = "frmCellMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCellMain_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.mainTool.ResumeLayout(false);
            this.mainTool.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.customPanel2.ResumeLayout(false);
            this.customPanel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cell2)).EndInit();
            this.toolArchive.ResumeLayout(false);
            this.toolArchive.PerformLayout();
            this.toolArchiveTab.ResumeLayout(false);
            this.toolArchiveTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TXStatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel3;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuNewChildNode;
        private System.Windows.Forms.ToolStripMenuItem menuEditNode;
        private System.Windows.Forms.ToolStripMenuItem menuDelNode;
        private System.Windows.Forms.ToolStripMenuItem menuNewTable;
        private System.Windows.Forms.ImageList imageBorder;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripButton btnClose;
        private Skin_MenuToolEX mainMenu;
        private Skin_ToolStripEX mainTool;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private ERM.UI.CustomPanel customPanel2;
        private ERM.UI.MyToolStrip toolArchive;
        private System.Windows.Forms.ToolStripButton t1_Find;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton t1_EditNode;
        private System.Windows.Forms.ToolStripButton t1_DelNode;
        private Skin_ToolStripEX toolArchiveTab;
        private System.Windows.Forms.ToolStripLabel tabArchive;
        private System.Windows.Forms.ToolStripButton imgHideArchive;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem tsmiManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewChildNode;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditNode;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton btnFileter;
        private System.Windows.Forms.ToolStripMenuItem btnAll;
        private System.Windows.Forms.ToolStripMenuItem btnNoCheckIn;
        private System.Windows.Forms.ToolStripMenuItem btnHasCheckIn;
        private System.Windows.Forms.ToolStripMenuItem menuCopyFile;
        private System.Windows.Forms.ToolStripMenuItem menuPasteFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;        
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private AxCELL50Lib.AxCell Cell2;
        private System.Windows.Forms.ToolStripButton tsOutput;
        private System.Windows.Forms.ToolStripMenuItem tsMenuInput;
        private System.Windows.Forms.ToolStripDropDownButton Dro_Print;
        private System.Windows.Forms.ToolStripMenuItem Print_All;
        private System.Windows.Forms.ToolStripMenuItem Print_Sava;
        private System.Windows.Forms.ToolStripButton tsb_FL;
    }
}