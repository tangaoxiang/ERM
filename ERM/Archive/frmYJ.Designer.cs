using CCWin.SkinControl;
using ERM.UI.Controls;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmYJ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYJ));
            this.mainMenu = new CCWin.SkinControl.SkinMenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPrint_fengmian_All = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint_jnml_All = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint_bkb_All = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPrint4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPrintGCGK = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSIP = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateSIP = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_NEWYJ = new System.Windows.Forms.ToolStripMenuItem();
            this.stiProject = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.panlTop = new ERM.UI.Controls.SkinPanelEX();
            this.mainTool = new ERM.UI.Controls.Skin_ToolStripEX();
            this.btnSArchiveVisible = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripSplitButton();
            this.btnPrint1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint_fengmian_All = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint_jnml_All = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint_bkb_All = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint5 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint6 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint7 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_gcgk = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintFile = new System.Windows.Forms.ToolStripButton();
            this.btnUploadSIP = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmOLDYJ = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNEWYJ = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.panelFull = new ERM.UI.Controls.SkinPanelEX();
            this.panelRight = new ERM.UI.Controls.SkinPanelEX();
            this.tabGrade = new TX.Framework.WindowUI.Controls.TXTabControl();
            this.tabPage1 = new CCWin.SkinControl.SkinTabPage();
            this.wizard1 = new Stimulsoft.Controls.Win.DotNetBar.Wizard();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelLeft = new ERM.UI.Controls.SkinPanelEX();
            this.treeArchive = new System.Windows.Forms.TreeView();
            this.toolArchiveTab = new System.Windows.Forms.ToolStrip();
            this.tsArchive = new System.Windows.Forms.ToolStripButton();
            this.tsButClose = new System.Windows.Forms.ToolStripButton();
            this.tabArchive = new CCWin.SkinControl.SkinTabPage();
            this.stiArchive = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.tabFile = new CCWin.SkinControl.SkinTabPage();
            this.stiFile = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.tabElecFile = new CCWin.SkinControl.SkinTabPage();
            this.axSPApplication1 = new AxiStylePDF.AxSPApplication();
            this.lblAttach = new System.Windows.Forms.LinkLabel();
            this.Cell0 = new AxCELL50Lib.AxCell();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.panelButton = new ERM.UI.Controls.SkinPanelEX();
            this.statusStrip1 = new TX.Framework.WindowUI.Controls.TXStatusStrip();
            this.tssLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BackWorkerYJ = new System.ComponentModel.BackgroundWorker();
            this.mainMenu.SuspendLayout();
            this.panlTop.SuspendLayout();
            this.mainTool.SuspendLayout();
            this.panelFull.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.tabGrade.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.toolArchiveTab.SuspendLayout();
            this.tabArchive.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.tabElecFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axSPApplication1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell0)).BeginInit();
            this.panelButton.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Arrow = System.Drawing.Color.Black;
            this.mainMenu.Back = System.Drawing.Color.White;
            this.mainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.mainMenu.BackgroundImage = global::ERM.UI.Properties.Resources.top;
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
            this.tsmiPrint,
            this.tsmiSIP});
            this.mainMenu.Location = new System.Drawing.Point(4, 34);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.mainMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.mainMenu.Size = new System.Drawing.Size(1284, 29);
            this.mainMenu.SkinAllColor = true;
            this.mainMenu.TabIndex = 7;
            this.mainMenu.Text = "menuStrip1";
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
            // tsmiPrint
            // 
            this.tsmiPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPrint1,
            this.tsmiPrint2,
            this.tsmiPrint3,
            this.toolStripSeparator3,
            this.tsmiPrint_fengmian_All,
            this.tsmiPrint_jnml_All,
            this.tsmiPrint_bkb_All,
            this.toolStripMenuItem4,
            this.tsmiPrint4,
            this.tsmiPrint5,
            this.tsmiPrint6,
            this.tsmiPrint7,
            this.toolStripMenuItem3,
            this.tsmiPrintGCGK});
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.Size = new System.Drawing.Size(83, 21);
            this.tsmiPrint.Text = "目录打印(&P)";
            // 
            // tsmiPrint1
            // 
            this.tsmiPrint1.Name = "tsmiPrint1";
            this.tsmiPrint1.Size = new System.Drawing.Size(232, 22);
            this.tsmiPrint1.Text = "打印案卷封皮";
            this.tsmiPrint1.Visible = false;
            this.tsmiPrint1.Click += new System.EventHandler(this.btnPrint1_Click);
            // 
            // tsmiPrint2
            // 
            this.tsmiPrint2.Name = "tsmiPrint2";
            this.tsmiPrint2.Size = new System.Drawing.Size(232, 22);
            this.tsmiPrint2.Text = "打印卷内目录";
            this.tsmiPrint2.Visible = false;
            this.tsmiPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // tsmiPrint3
            // 
            this.tsmiPrint3.Name = "tsmiPrint3";
            this.tsmiPrint3.Size = new System.Drawing.Size(232, 22);
            this.tsmiPrint3.Text = "打印卷内备考表";
            this.tsmiPrint3.Visible = false;
            this.tsmiPrint3.Click += new System.EventHandler(this.btnPrint3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(229, 6);
            // 
            // tsmiPrint_fengmian_All
            // 
            this.tsmiPrint_fengmian_All.Name = "tsmiPrint_fengmian_All";
            this.tsmiPrint_fengmian_All.Size = new System.Drawing.Size(232, 22);
            this.tsmiPrint_fengmian_All.Text = "批量打印案卷封皮";
            this.tsmiPrint_fengmian_All.Click += new System.EventHandler(this.btnPrint_fengmian_All_Click);
            // 
            // tsmiPrint_jnml_All
            // 
            this.tsmiPrint_jnml_All.Name = "tsmiPrint_jnml_All";
            this.tsmiPrint_jnml_All.Size = new System.Drawing.Size(232, 22);
            this.tsmiPrint_jnml_All.Text = "批量打印卷内目录";
            this.tsmiPrint_jnml_All.Click += new System.EventHandler(this.btnPrint_fengmian_All_Click);
            // 
            // tsmiPrint_bkb_All
            // 
            this.tsmiPrint_bkb_All.Name = "tsmiPrint_bkb_All";
            this.tsmiPrint_bkb_All.Size = new System.Drawing.Size(232, 22);
            this.tsmiPrint_bkb_All.Text = "批量打印卷内备考表";
            this.tsmiPrint_bkb_All.Click += new System.EventHandler(this.btnPrint_fengmian_All_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(229, 6);
            // 
            // tsmiPrint4
            // 
            this.tsmiPrint4.Name = "tsmiPrint4";
            this.tsmiPrint4.Size = new System.Drawing.Size(232, 22);
            this.tsmiPrint4.Text = "打印卷内电子文件";
            this.tsmiPrint4.Visible = false;
            // 
            // tsmiPrint5
            // 
            this.tsmiPrint5.Name = "tsmiPrint5";
            this.tsmiPrint5.Size = new System.Drawing.Size(232, 22);
            this.tsmiPrint5.Text = "打印电子文件登记表";
            this.tsmiPrint5.Click += new System.EventHandler(this.btnPrint5_Click);
            // 
            // tsmiPrint6
            // 
            this.tsmiPrint6.Name = "tsmiPrint6";
            this.tsmiPrint6.Size = new System.Drawing.Size(232, 22);
            this.tsmiPrint6.Text = "打印电子档案项目级登记表";
            this.tsmiPrint6.Click += new System.EventHandler(this.btnPrint6_Click);
            // 
            // tsmiPrint7
            // 
            this.tsmiPrint7.Name = "tsmiPrint7";
            this.tsmiPrint7.Size = new System.Drawing.Size(232, 22);
            this.tsmiPrint7.Text = "打印电子档案移交接收登记表";
            this.tsmiPrint7.Click += new System.EventHandler(this.btnPrint7_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(229, 6);
            this.toolStripMenuItem3.Visible = false;
            // 
            // tsmiPrintGCGK
            // 
            this.tsmiPrintGCGK.Name = "tsmiPrintGCGK";
            this.tsmiPrintGCGK.Size = new System.Drawing.Size(232, 22);
            this.tsmiPrintGCGK.Text = "打印工程项目信息";
            this.tsmiPrintGCGK.Click += new System.EventHandler(this.tsmiPrintGCGK_Click);
            // 
            // tsmiSIP
            // 
            this.tsmiSIP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateSIP,
            this.tsmi_NEWYJ});
            this.tsmiSIP.Name = "tsmiSIP";
            this.tsmiSIP.Size = new System.Drawing.Size(83, 21);
            this.tsmiSIP.Text = "资料上报(E)";
            // 
            // tsmiCreateSIP
            // 
            this.tsmiCreateSIP.Name = "tsmiCreateSIP";
            this.tsmiCreateSIP.Size = new System.Drawing.Size(168, 22);
            this.tsmiCreateSIP.Text = "归档移交(老系统)";
            this.tsmiCreateSIP.Visible = false;
            this.tsmiCreateSIP.Click += new System.EventHandler(this.btnUploadSIP_Click);
            // 
            // tsmi_NEWYJ
            // 
            this.tsmi_NEWYJ.Name = "tsmi_NEWYJ";
            this.tsmi_NEWYJ.Size = new System.Drawing.Size(168, 22);
            this.tsmi_NEWYJ.Text = "归档移交";
            this.tsmi_NEWYJ.Click += new System.EventHandler(this.tsmiCreateNewSIP_Click);
            // 
            // stiProject
            // 
            this.stiProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stiProject.Location = new System.Drawing.Point(0, 0);
            this.stiProject.Name = "stiProject";
            this.stiProject.Report = null;
            this.stiProject.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stiProject.ShowBookmarksPanel = false;
            this.stiProject.ShowCloseButton = false;
            this.stiProject.ShowContextMenu = false;
            this.stiProject.ShowDotMatrixModeButton = false;
            this.stiProject.ShowEditor = false;
            this.stiProject.ShowEditorTool = false;
            this.stiProject.ShowExport = false;
            this.stiProject.ShowFind = false;
            this.stiProject.ShowFindTool = false;
            this.stiProject.ShowFullScreen = false;
            this.stiProject.ShowOpen = false;
            this.stiProject.ShowPageDelete = false;
            this.stiProject.ShowPageDesign = false;
            this.stiProject.ShowPageNew = false;
            this.stiProject.ShowPageSize = false;
            this.stiProject.ShowPrint = false;
            this.stiProject.ShowSave = false;
            this.stiProject.ShowSaveDocumentFile = false;
            this.stiProject.ShowSendEMail = false;
            this.stiProject.ShowSendEMailDocumentFile = false;
            this.stiProject.ShowThumbsPanel = false;
            this.stiProject.ShowViewModeMultiplePages = false;
            this.stiProject.ShowZoom = false;
            this.stiProject.ShowZoomMultiplePages = false;
            this.stiProject.ShowZoomOnePage = false;
            this.stiProject.ShowZoomPageWidth = false;
            this.stiProject.ShowZoomTwoPages = false;
            this.stiProject.Size = new System.Drawing.Size(1009, 561);
            this.stiProject.TabIndex = 0;
            this.stiProject.ThumbsPanelEnabled = false;
            // 
            // panlTop
            // 
            this.panlTop.BackColor = System.Drawing.Color.Transparent;
            this.panlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panlTop.Controls.Add(this.mainTool);
            this.panlTop.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panlTop.DownBack = null;
            this.panlTop.Location = new System.Drawing.Point(4, 63);
            this.panlTop.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panlTop.MouseBack = null;
            this.panlTop.Name = "panlTop";
            this.panlTop.NormlBack = null;
            this.panlTop.Radius = 4;
            this.panlTop.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panlTop.Size = new System.Drawing.Size(1284, 54);
            this.panlTop.TabIndex = 8;
            // 
            // mainTool
            // 
            this.mainTool.Arrow = System.Drawing.Color.Black;
            this.mainTool.AutoSize = false;
            this.mainTool.Back = System.Drawing.Color.White;
            this.mainTool.BackColor = System.Drawing.Color.Transparent;
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
            this.mainTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTool.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.mainTool.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.mainTool.Fore = System.Drawing.Color.Black;
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
            this.btnSArchiveVisible,
            this.btnPrint,
            this.btnPrintFile,
            this.btnUploadSIP,
            this.toolStripSeparator1,
            this.btnClose});
            this.mainTool.Location = new System.Drawing.Point(0, 0);
            this.mainTool.Name = "mainTool";
            this.mainTool.Padding = new System.Windows.Forms.Padding(0, 1, 0, 4);
            this.mainTool.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.mainTool.Size = new System.Drawing.Size(1284, 54);
            this.mainTool.SkinAllColor = true;
            this.mainTool.Stretch = true;
            this.mainTool.TabIndex = 8;
            this.mainTool.Text = "MyToolStrip1";
            this.mainTool.TitleAnamorphosis = true;
            this.mainTool.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.mainTool.TitleRadius = 4;
            this.mainTool.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // btnSArchiveVisible
            // 
            this.btnSArchiveVisible.Image = global::ERM.UI.Properties.Resources._071;
            this.btnSArchiveVisible.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSArchiveVisible.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSArchiveVisible.Margin = new System.Windows.Forms.Padding(1, 2, 5, 2);
            this.btnSArchiveVisible.Name = "btnSArchiveVisible";
            this.btnSArchiveVisible.Size = new System.Drawing.Size(84, 45);
            this.btnSArchiveVisible.Text = "隐藏案卷列表";
            this.btnSArchiveVisible.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSArchiveVisible.Click += new System.EventHandler(this.btnSArchiveVisible_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint1,
            this.btnPrint2,
            this.btnPrint3,
            this.toolStripMenuItem2,
            this.btnPrint_fengmian_All,
            this.btnPrint_jnml_All,
            this.btnPrint_bkb_All,
            this.toolStripSeparator4,
            this.btnPrint5,
            this.btnPrint6,
            this.btnPrint7,
            this.tsmi_gcgk});
            this.btnPrint.Image = global::ERM.UI.Properties.Resources.zujuanico02;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Margin = new System.Windows.Forms.Padding(1, 2, 5, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 45);
            this.btnPrint.Text = "目录打印";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnPrint1
            // 
            this.btnPrint1.Name = "btnPrint1";
            this.btnPrint1.Size = new System.Drawing.Size(232, 22);
            this.btnPrint1.Text = "打印案卷封皮";
            this.btnPrint1.Visible = false;
            this.btnPrint1.Click += new System.EventHandler(this.btnPrint1_Click);
            // 
            // btnPrint2
            // 
            this.btnPrint2.Name = "btnPrint2";
            this.btnPrint2.Size = new System.Drawing.Size(232, 22);
            this.btnPrint2.Text = "打印卷内目录";
            this.btnPrint2.Visible = false;
            this.btnPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // btnPrint3
            // 
            this.btnPrint3.Name = "btnPrint3";
            this.btnPrint3.Size = new System.Drawing.Size(232, 22);
            this.btnPrint3.Text = "打印卷内备考表";
            this.btnPrint3.Visible = false;
            this.btnPrint3.Click += new System.EventHandler(this.btnPrint3_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(229, 6);
            this.toolStripMenuItem2.Visible = false;
            // 
            // btnPrint_fengmian_All
            // 
            this.btnPrint_fengmian_All.Name = "btnPrint_fengmian_All";
            this.btnPrint_fengmian_All.Size = new System.Drawing.Size(232, 22);
            this.btnPrint_fengmian_All.Text = "批量打印案卷封皮";
            this.btnPrint_fengmian_All.Click += new System.EventHandler(this.btnPrint_fengmian_All_Click);
            // 
            // btnPrint_jnml_All
            // 
            this.btnPrint_jnml_All.Name = "btnPrint_jnml_All";
            this.btnPrint_jnml_All.Size = new System.Drawing.Size(232, 22);
            this.btnPrint_jnml_All.Text = "批量打印卷内目录";
            this.btnPrint_jnml_All.Click += new System.EventHandler(this.btnPrint_fengmian_All_Click);
            // 
            // btnPrint_bkb_All
            // 
            this.btnPrint_bkb_All.Name = "btnPrint_bkb_All";
            this.btnPrint_bkb_All.Size = new System.Drawing.Size(232, 22);
            this.btnPrint_bkb_All.Text = "批量打印卷内备考表";
            this.btnPrint_bkb_All.Click += new System.EventHandler(this.btnPrint_fengmian_All_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(229, 6);
            // 
            // btnPrint5
            // 
            this.btnPrint5.Name = "btnPrint5";
            this.btnPrint5.Size = new System.Drawing.Size(232, 22);
            this.btnPrint5.Text = "打印电子文件登记表";
            this.btnPrint5.Click += new System.EventHandler(this.btnPrint5_Click);
            // 
            // btnPrint6
            // 
            this.btnPrint6.Name = "btnPrint6";
            this.btnPrint6.Size = new System.Drawing.Size(232, 22);
            this.btnPrint6.Text = "打印电子档案项目级登记表";
            this.btnPrint6.Click += new System.EventHandler(this.btnPrint6_Click);
            // 
            // btnPrint7
            // 
            this.btnPrint7.Name = "btnPrint7";
            this.btnPrint7.Size = new System.Drawing.Size(232, 22);
            this.btnPrint7.Text = "打印电子档案移交接收登记表";
            this.btnPrint7.Click += new System.EventHandler(this.btnPrint7_Click);
            // 
            // tsmi_gcgk
            // 
            this.tsmi_gcgk.Name = "tsmi_gcgk";
            this.tsmi_gcgk.Size = new System.Drawing.Size(232, 22);
            this.tsmi_gcgk.Text = "打印项目及工程信息表";
            this.tsmi_gcgk.Click += new System.EventHandler(this.tsmiPrintGCGK_Click);
            // 
            // btnPrintFile
            // 
            this.btnPrintFile.Image = global::ERM.UI.Properties.Resources.批量打印;
            this.btnPrintFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrintFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintFile.Margin = new System.Windows.Forms.Padding(1, 2, 5, 2);
            this.btnPrintFile.Name = "btnPrintFile";
            this.btnPrintFile.Size = new System.Drawing.Size(60, 45);
            this.btnPrintFile.Text = "文件打印";
            this.btnPrintFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrintFile.Click += new System.EventHandler(this.btnPrintFile_Click);
            // 
            // btnUploadSIP
            // 
            this.btnUploadSIP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOLDYJ,
            this.tsmNEWYJ});
            this.btnUploadSIP.Image = global::ERM.UI.Properties.Resources.zujuanico03;
            this.btnUploadSIP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUploadSIP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUploadSIP.Margin = new System.Windows.Forms.Padding(1, 2, 5, 2);
            this.btnUploadSIP.Name = "btnUploadSIP";
            this.btnUploadSIP.Size = new System.Drawing.Size(69, 45);
            this.btnUploadSIP.Text = "归档移交";
            this.btnUploadSIP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsmOLDYJ
            // 
            this.tsmOLDYJ.Name = "tsmOLDYJ";
            this.tsmOLDYJ.Size = new System.Drawing.Size(168, 22);
            this.tsmOLDYJ.Text = "归档移交(老系统)";
            this.tsmOLDYJ.Click += new System.EventHandler(this.btnUploadSIP_Click);
            // 
            // tsmNEWYJ
            // 
            this.tsmNEWYJ.Name = "tsmNEWYJ";
            this.tsmNEWYJ.Size = new System.Drawing.Size(168, 22);
            this.tsmNEWYJ.Text = "归档移交";
            this.tsmNEWYJ.Click += new System.EventHandler(this.tsmiCreateNewSIP_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 49);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::ERM.UI.Properties.Resources.zujuanico04;
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Margin = new System.Windows.Forms.Padding(1, 2, 5, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 45);
            this.btnClose.Text = "关闭";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelFull
            // 
            this.panelFull.AutoSize = true;
            this.panelFull.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panelFull.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelFull.Controls.Add(this.panelRight);
            this.panelFull.Controls.Add(this.splitter1);
            this.panelFull.Controls.Add(this.panelLeft);
            this.panelFull.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFull.DownBack = null;
            this.panelFull.Location = new System.Drawing.Point(4, 117);
            this.panelFull.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelFull.MouseBack = null;
            this.panelFull.Name = "panelFull";
            this.panelFull.NormlBack = null;
            this.panelFull.Radius = 4;
            this.panelFull.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelFull.Size = new System.Drawing.Size(1284, 616);
            this.panelFull.TabIndex = 9;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRight.Controls.Add(this.tabGrade);
            this.panelRight.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.DownBack = null;
            this.panelRight.Location = new System.Drawing.Point(267, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelRight.MouseBack = null;
            this.panelRight.Name = "panelRight";
            this.panelRight.NormlBack = null;
            this.panelRight.Radius = 4;
            this.panelRight.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelRight.Size = new System.Drawing.Size(1017, 616);
            this.panelRight.TabIndex = 2;
            // 
            // tabGrade
            // 
            this.tabGrade.BaseTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabGrade.BorderColor = System.Drawing.Color.Gainsboro;
            this.tabGrade.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.tabGrade.CheckedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.tabGrade.Controls.Add(this.tabPage1);
            this.tabGrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGrade.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tabGrade.HeightLightTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.tabGrade.Location = new System.Drawing.Point(0, 0);
            this.tabGrade.Margin = new System.Windows.Forms.Padding(1, 5, 3, 5);
            this.tabGrade.Name = "tabGrade";
            this.tabGrade.SelectedIndex = 0;
            this.tabGrade.Size = new System.Drawing.Size(1017, 616);
            this.tabGrade.TabCornerRadius = 3;
            this.tabGrade.TabIndex = 8;
            this.tabGrade.SelectedIndexChanged += new System.EventHandler(this.tabGrade_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tabPage1.Controls.Add(this.stiProject);
            this.tabPage1.Controls.Add(this.wizard1);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1009, 583);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.TabItemImage = null;
            this.tabPage1.Text = "工程概况";
            // 
            // wizard1
            // 
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.FinishButtonTabIndex = 3;
            // 
            // 
            // 
            this.wizard1.FooterStyle.BackColor = System.Drawing.SystemColors.Control;
            this.wizard1.FooterStyle.BackColorGradientAngle = 90;
            this.wizard1.FooterStyle.BorderBottomWidth = 1;
            this.wizard1.FooterStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.wizard1.FooterStyle.BorderLeftWidth = 1;
            this.wizard1.FooterStyle.BorderRightWidth = 1;
            this.wizard1.FooterStyle.BorderTop = Stimulsoft.Controls.Win.DotNetBar.eStyleBorderType.Etched;
            this.wizard1.FooterStyle.BorderTopColor = System.Drawing.SystemColors.Control;
            this.wizard1.FooterStyle.BorderTopWidth = 1;
            this.wizard1.FooterStyle.TextAlignment = Stimulsoft.Controls.Win.DotNetBar.eStyleTextAlignment.Center;
            this.wizard1.FooterStyle.TextColorSchemePart = Stimulsoft.Controls.Win.DotNetBar.eColorSchemePart.PanelText;
            this.wizard1.HeaderCaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // 
            // 
            this.wizard1.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.wizard1.HeaderStyle.BackColorGradientAngle = 90;
            this.wizard1.HeaderStyle.BorderBottom = Stimulsoft.Controls.Win.DotNetBar.eStyleBorderType.Etched;
            this.wizard1.HeaderStyle.BorderBottomWidth = 1;
            this.wizard1.HeaderStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.wizard1.HeaderStyle.BorderLeftWidth = 1;
            this.wizard1.HeaderStyle.BorderRightWidth = 1;
            this.wizard1.HeaderStyle.BorderTopWidth = 1;
            this.wizard1.HeaderStyle.TextAlignment = Stimulsoft.Controls.Win.DotNetBar.eStyleTextAlignment.Center;
            this.wizard1.HeaderStyle.TextColorSchemePart = Stimulsoft.Controls.Win.DotNetBar.eColorSchemePart.PanelText;
            this.wizard1.Location = new System.Drawing.Point(0, 0);
            this.wizard1.Name = "wizard1";
            this.wizard1.Size = new System.Drawing.Size(1009, 583);
            this.wizard1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.splitter1.Location = new System.Drawing.Point(264, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 616);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.AutoScroll = true;
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLeft.Controls.Add(this.treeArchive);
            this.panelLeft.Controls.Add(this.toolArchiveTab);
            this.panelLeft.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.DownBack = null;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelLeft.MouseBack = null;
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.NormlBack = null;
            this.panelLeft.Radius = 4;
            this.panelLeft.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelLeft.Size = new System.Drawing.Size(264, 616);
            this.panelLeft.TabIndex = 0;
            // 
            // treeArchive
            // 
            this.treeArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeArchive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.treeArchive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeArchive.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.treeArchive.HideSelection = false;
            this.treeArchive.ItemHeight = 18;
            this.treeArchive.Location = new System.Drawing.Point(0, 27);
            this.treeArchive.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.treeArchive.Name = "treeArchive";
            this.treeArchive.Size = new System.Drawing.Size(264, 554);
            this.treeArchive.TabIndex = 4;
            this.treeArchive.TabStop = false;
            this.treeArchive.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeArchive_AfterSelect);
            // 
            // toolArchiveTab
            // 
            this.toolArchiveTab.AutoSize = false;
            this.toolArchiveTab.BackColor = System.Drawing.Color.Black;
            this.toolArchiveTab.BackgroundImage = global::ERM.UI.Properties.Resources.tit_bg;
            this.toolArchiveTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolArchiveTab.CanOverflow = false;
            this.toolArchiveTab.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolArchiveTab.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolArchiveTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsArchive,
            this.tsButClose});
            this.toolArchiveTab.Location = new System.Drawing.Point(0, 0);
            this.toolArchiveTab.Name = "toolArchiveTab";
            this.toolArchiveTab.Size = new System.Drawing.Size(264, 27);
            this.toolArchiveTab.Stretch = true;
            this.toolArchiveTab.TabIndex = 0;
            this.toolArchiveTab.Text = "组卷目录";
            // 
            // tsArchive
            // 
            this.tsArchive.BackgroundImage = global::ERM.UI.Properties.Resources.title_btnbg1;
            this.tsArchive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsArchive.Image = global::ERM.UI.Properties.Resources.title_btnbg1;
            this.tsArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsArchive.Margin = new System.Windows.Forms.Padding(8, 2, 2, 2);
            this.tsArchive.Name = "tsArchive";
            this.tsArchive.Padding = new System.Windows.Forms.Padding(7, 3, 6, 2);
            this.tsArchive.Size = new System.Drawing.Size(49, 23);
            this.tsArchive.Text = "目录";
            // 
            // tsButClose
            // 
            this.tsButClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsButClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButClose.Image = global::ERM.UI.Properties.Resources.c_no;
            this.tsButClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButClose.Name = "tsButClose";
            this.tsButClose.Size = new System.Drawing.Size(23, 24);
            this.tsButClose.Text = "关闭";
            this.tsButClose.Visible = false;
            this.tsButClose.Click += new System.EventHandler(this.tsButClose_Click);
            // 
            // tabArchive
            // 
            this.tabArchive.AutoScroll = true;
            this.tabArchive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tabArchive.Controls.Add(this.stiArchive);
            this.tabArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabArchive.Location = new System.Drawing.Point(4, 29);
            this.tabArchive.Margin = new System.Windows.Forms.Padding(0);
            this.tabArchive.Name = "tabArchive";
            this.tabArchive.Size = new System.Drawing.Size(1009, 583);
            this.tabArchive.TabIndex = 1;
            this.tabArchive.TabItemImage = null;
            this.tabArchive.Text = "案卷级信息";
            // 
            // stiArchive
            // 
            this.stiArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stiArchive.Location = new System.Drawing.Point(0, 0);
            this.stiArchive.Name = "stiArchive";
            this.stiArchive.Report = null;
            this.stiArchive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stiArchive.ShowBookmarksPanel = false;
            this.stiArchive.ShowCloseButton = false;
            this.stiArchive.ShowContextMenu = false;
            this.stiArchive.ShowEditor = false;
            this.stiArchive.ShowEditorTool = false;
            this.stiArchive.ShowExport = false;
            this.stiArchive.ShowFind = false;
            this.stiArchive.ShowFindTool = false;
            this.stiArchive.ShowOpen = false;
            this.stiArchive.ShowPageDelete = false;
            this.stiArchive.ShowPageDesign = false;
            this.stiArchive.ShowPageNew = false;
            this.stiArchive.ShowPageSize = false;
            this.stiArchive.ShowPrint = false;
            this.stiArchive.ShowSave = false;
            this.stiArchive.ShowSaveDocumentFile = false;
            this.stiArchive.ShowSendEMail = false;
            this.stiArchive.ShowSendEMailDocumentFile = false;
            this.stiArchive.ShowThumbsPanel = false;
            this.stiArchive.ShowViewModeMultiplePages = false;
            this.stiArchive.ShowZoom = false;
            this.stiArchive.ShowZoomMultiplePages = false;
            this.stiArchive.ShowZoomOnePage = false;
            this.stiArchive.ShowZoomPageWidth = false;
            this.stiArchive.ShowZoomTwoPages = false;
            this.stiArchive.Size = new System.Drawing.Size(0, 0);
            this.stiArchive.TabIndex = 1;
            this.stiArchive.ThumbsPanelEnabled = false;
            // 
            // tabFile
            // 
            this.tabFile.AutoScroll = true;
            this.tabFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tabFile.Controls.Add(this.stiFile);
            this.tabFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFile.Location = new System.Drawing.Point(4, 29);
            this.tabFile.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabFile.Name = "tabFile";
            this.tabFile.Size = new System.Drawing.Size(1009, 583);
            this.tabFile.TabIndex = 2;
            this.tabFile.TabItemImage = null;
            this.tabFile.Text = "文件级信息";
            // 
            // stiFile
            // 
            this.stiFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stiFile.Location = new System.Drawing.Point(0, 0);
            this.stiFile.Name = "stiFile";
            this.stiFile.Report = null;
            this.stiFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stiFile.ShowBookmarksPanel = false;
            this.stiFile.ShowCloseButton = false;
            this.stiFile.ShowContextMenu = false;
            this.stiFile.ShowEditor = false;
            this.stiFile.ShowEditorTool = false;
            this.stiFile.ShowExport = false;
            this.stiFile.ShowFind = false;
            this.stiFile.ShowFindTool = false;
            this.stiFile.ShowOpen = false;
            this.stiFile.ShowPageDelete = false;
            this.stiFile.ShowPageDesign = false;
            this.stiFile.ShowPageNew = false;
            this.stiFile.ShowPageSize = false;
            this.stiFile.ShowPrint = false;
            this.stiFile.ShowSave = false;
            this.stiFile.ShowSaveDocumentFile = false;
            this.stiFile.ShowSendEMail = false;
            this.stiFile.ShowSendEMailDocumentFile = false;
            this.stiFile.ShowThumbsPanel = false;
            this.stiFile.ShowViewModeMultiplePages = false;
            this.stiFile.ShowZoom = false;
            this.stiFile.ShowZoomMultiplePages = false;
            this.stiFile.ShowZoomOnePage = false;
            this.stiFile.ShowZoomPageWidth = false;
            this.stiFile.ShowZoomTwoPages = false;
            this.stiFile.Size = new System.Drawing.Size(0, 0);
            this.stiFile.TabIndex = 2;
            this.stiFile.ThumbsPanelEnabled = false;
            // 
            // tabElecFile
            // 
            this.tabElecFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.tabElecFile.Controls.Add(this.axSPApplication1);
            this.tabElecFile.Controls.Add(this.lblAttach);
            this.tabElecFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabElecFile.Location = new System.Drawing.Point(4, 29);
            this.tabElecFile.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabElecFile.Name = "tabElecFile";
            this.tabElecFile.Size = new System.Drawing.Size(1009, 583);
            this.tabElecFile.TabIndex = 3;
            this.tabElecFile.TabItemImage = null;
            this.tabElecFile.Text = "电子文件查看";
            // 
            // axSPApplication1
            // 
            this.axSPApplication1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axSPApplication1.Enabled = true;
            this.axSPApplication1.Location = new System.Drawing.Point(0, 0);
            this.axSPApplication1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.axSPApplication1.Name = "axSPApplication1";
            this.axSPApplication1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSPApplication1.OcxState")));
            this.axSPApplication1.Size = new System.Drawing.Size(1009, 583);
            this.axSPApplication1.TabIndex = 4;
            // 
            // lblAttach
            // 
            this.lblAttach.AutoSize = true;
            this.lblAttach.Location = new System.Drawing.Point(482, 808);
            this.lblAttach.Name = "lblAttach";
            this.lblAttach.Size = new System.Drawing.Size(173, 12);
            this.lblAttach.TabIndex = 3;
            this.lblAttach.TabStop = true;
            this.lblAttach.Text = "该文件包含附件，请点击查看。";
            this.lblAttach.Visible = false;
            // 
            // Cell0
            // 
            this.Cell0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell0.Enabled = true;
            this.Cell0.Location = new System.Drawing.Point(0, 0);
            this.Cell0.Margin = new System.Windows.Forms.Padding(100, 5, 3, 5);
            this.Cell0.Name = "Cell0";
            this.Cell0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Cell0.OcxState")));
            this.Cell0.Padding = new System.Windows.Forms.Padding(100, 0, 0, 0);
            this.Cell0.Size = new System.Drawing.Size(1077, 583);
            this.Cell0.TabIndex = 5;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imgList.Images.SetKeyName(0, "tree_home.png");
            this.imgList.Images.SetKeyName(1, "tree_folder.png");
            this.imgList.Images.SetKeyName(2, "tree_file.png");
            this.imgList.Images.SetKeyName(3, "tree_file_s.png");
            // 
            // panelButton
            // 
            this.panelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelButton.Controls.Add(this.statusStrip1);
            this.panelButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.DownBack = null;
            this.panelButton.Location = new System.Drawing.Point(4, 703);
            this.panelButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelButton.MouseBack = null;
            this.panelButton.Name = "panelButton";
            this.panelButton.NormlBack = null;
            this.panelButton.Radius = 4;
            this.panelButton.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelButton.Size = new System.Drawing.Size(1284, 30);
            this.panelButton.TabIndex = 10;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.statusStrip1.BackgroundImage = global::ERM.UI.Properties.Resources.titlebg;
            this.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusStrip1.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel1,
            this.tssLabel2,
            this.tssLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 24, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1284, 30);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLabel1
            // 
            this.tssLabel1.AutoSize = false;
            this.tssLabel1.BackColor = System.Drawing.Color.Transparent;
            this.tssLabel1.Name = "tssLabel1";
            this.tssLabel1.Size = new System.Drawing.Size(809, 25);
            this.tssLabel1.Spring = true;
            this.tssLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssLabel2
            // 
            this.tssLabel2.AutoSize = false;
            this.tssLabel2.BackColor = System.Drawing.Color.Transparent;
            this.tssLabel2.Name = "tssLabel2";
            this.tssLabel2.Size = new System.Drawing.Size(300, 25);
            // 
            // tssLabel3
            // 
            this.tssLabel3.AutoSize = false;
            this.tssLabel3.BackColor = System.Drawing.Color.Transparent;
            this.tssLabel3.Name = "tssLabel3";
            this.tssLabel3.Size = new System.Drawing.Size(150, 25);
            // 
            // BackWorkerYJ
            // 
            this.BackWorkerYJ.WorkerReportsProgress = true;
            this.BackWorkerYJ.WorkerSupportsCancellation = true;
            this.BackWorkerYJ.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackWorkerYJ_DoWork);
            this.BackWorkerYJ.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackWorkerYJ_ProgressChanged);
            this.BackWorkerYJ.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackWorkerYJ_RunWorkerCompleted);
            // 
            // frmYJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(1292, 737);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.panelFull);
            this.Controls.Add(this.panlTop);
            this.Controls.Add(this.mainMenu);
            this.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.Name = "frmYJ";
            this.Text = "移交";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmArchive_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmYJ_FormClosed);
            this.Load += new System.EventHandler(this.frmArchive_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.panlTop.ResumeLayout(false);
            this.mainTool.ResumeLayout(false);
            this.mainTool.PerformLayout();
            this.panelFull.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.tabGrade.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.toolArchiveTab.ResumeLayout(false);
            this.toolArchiveTab.PerformLayout();
            this.tabArchive.ResumeLayout(false);
            this.tabFile.ResumeLayout(false);
            this.tabElecFile.ResumeLayout(false);
            this.tabElecFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axSPApplication1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell0)).EndInit();
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SkinMenuStrip mainMenu;
        private ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint1;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint2;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint4;
        private System.Windows.Forms.ToolStripMenuItem tsmiSIP;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateSIP;
        private SkinPanelEX panlTop;
        private Skin_ToolStripEX mainTool;
        private System.Windows.Forms.ToolStripSplitButton btnPrint;
        private System.Windows.Forms.ToolStripMenuItem btnPrint1;
        private System.Windows.Forms.ToolStripMenuItem btnPrint2;
        private System.Windows.Forms.ToolStripMenuItem btnPrint3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnClose;
        private SkinPanelEX panelFull;
        private System.Windows.Forms.Splitter splitter1;
        private SkinPanelEX panelLeft;
        private SkinPanelEX panelRight;
        private TXTabControl tabGrade;
        private System.Windows.Forms.LinkLabel lblAttach;
        private Stimulsoft.Report.Viewer.StiViewerControl stiProject;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStripButton btnSArchiveVisible;
        private SkinPanelEX panelButton;
        private System.Windows.Forms.ToolStripMenuItem btnPrint5;
        private System.Windows.Forms.ToolStripMenuItem btnPrint6;
        private System.Windows.Forms.ToolStripMenuItem btnPrint7;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint5;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint6;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint7;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem btnPrint_fengmian_All;
        private System.Windows.Forms.ToolStripMenuItem btnPrint_jnml_All;
        private System.Windows.Forms.ToolStripMenuItem btnPrint_bkb_All;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint_fengmian_All;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint_jnml_All;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint_bkb_All;
        private System.Windows.Forms.ToolStripButton btnPrintFile;
        private ToolStrip toolArchiveTab;
        private System.Windows.Forms.ToolStripButton tsArchive;
        private System.Windows.Forms.ToolStripButton tsButClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_NEWYJ;
        private System.Windows.Forms.ToolStripDropDownButton btnUploadSIP;
        private System.Windows.Forms.ToolStripMenuItem tsmOLDYJ;
        private System.Windows.Forms.ToolStripMenuItem tsmNEWYJ;
        private System.ComponentModel.BackgroundWorker BackWorkerYJ;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrintGCGK;
        private System.Windows.Forms.ToolStripMenuItem tsmi_gcgk;
        private AxiStylePDF.AxSPApplication axSPApplication1;
        internal TreeView treeArchive;
        private AxCELL50Lib.AxCell Cell0;
        private SkinTabPage tabPage1;
        private SkinTabPage tabArchive;
        private SkinTabPage tabFile;
        private SkinTabPage tabElecFile;
        private Stimulsoft.Controls.Win.DotNetBar.Wizard wizard1;
        private Stimulsoft.Report.Viewer.StiViewerControl stiArchive;
        private Stimulsoft.Report.Viewer.StiViewerControl stiFile;
        private TXStatusStrip statusStrip1;
        private ToolStripStatusLabel tssLabel1;
        private ToolStripStatusLabel tssLabel2;
        private ToolStripStatusLabel tssLabel3;
    }
}