using CCWin.SkinControl;
using ERM.UI.Controls;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmCellEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCellEdit));
            this.statusStrip1 = new TX.Framework.WindowUI.Controls.TXStatusStrip();
            this.tssLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageBorder = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu = new CCWin.SkinControl.SkinMenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPageSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiImportXls = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetAsTemplet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHideArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddCustomCell = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEditNode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelNode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFill = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRepeatFill = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRndFill = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRndSelectFill = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSumSum = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSumH = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSumV = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSum = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInsertPic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMergeCell = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUnmergeCell = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRepair = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAutoEval = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCellOption = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPageOption = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_TOFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Excel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_PDF = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReadOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRepeatFill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRndFill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRndSelectFill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSumSum = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSumH = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSumV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSum = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClearText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClearImage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClearFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInsertPic = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMergeCell = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUnmergeCell = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRepair = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCellOption = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCell = new ERM.UI.Controls.Skin_ContextStripEX(this.components);
            this.menuCellLine = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_wanggexian = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_kuangxian = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_leftline = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_rightline = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_topline = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_buttonline = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_zhengxian = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_fangxian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClearCellLine = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_clearwgx = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_clearkx = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_clearleftline = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_clearrightline = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_cleartopline = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_clearbuttonline = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_clearzxx = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_clearfxx = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImge = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAutoEval = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCellPageSet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCellHeadInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_TOFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Excel1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_PDF2 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenu = new ERM.UI.Controls.Skin_ContextStripEX(this.components);
            this.menuEditNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelNode = new System.Windows.Forms.ToolStripMenuItem();
            this.customPanel2 = new ERM.UI.CustomPanel();
            this.panel2 = new SkinPanelEX();
            this.toolArchive = new ERM.UI.MyToolStrip();
            this.t1_Up = new System.Windows.Forms.ToolStripButton();
            this.t1_Down = new System.Windows.Forms.ToolStripButton();
            this.checkBoxSelectAll = new TX.Framework.WindowUI.Controls.TXCheckBox();
            this.toolArchiveTab = new ERM.UI.MyToolStrip();
            this.tabArchive = new System.Windows.Forms.ToolStripLabel();
            this.imgHideArchive = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new SkinPanelEX();
            this.Cell2 = new AxCELL50Lib.AxCell();
            this.Cell1 = new AxCELL50Lib.AxCell();
            this.cboLine = new ERM.UI.ComboBoxEx();
            this.toolCellAssitant = new TX.Framework.WindowUI.Controls.TXToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnPrintpreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCut = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRow = new System.Windows.Forms.ToolStripButton();
            this.btnCol = new System.Windows.Forms.ToolStripButton();
            this.btnGridline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMergeCell = new System.Windows.Forms.ToolStripButton();
            this.btnUnmergeCell = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.cboZoom = new System.Windows.Forms.ToolStripComboBox();
            this.btnInsertCol = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteCol = new System.Windows.Forms.ToolStripButton();
            this.btnInsertRow = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteRow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRndFill = new System.Windows.Forms.ToolStripButton();
            this.dro_CellFill = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsm_ReperFill = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_AllFill = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_SelectFill = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSumH = new System.Windows.Forms.ToolStripButton();
            this.btnSumV = new System.Windows.Forms.ToolStripButton();
            this.btnSum = new System.Windows.Forms.ToolStripButton();
            this.toolCellFormat = new TX.Framework.WindowUI.Controls.TXToolStrip();
            this.cboFonts = new System.Windows.Forms.ToolStripComboBox();
            this.cboFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnItalic = new System.Windows.Forms.ToolStripButton();
            this.btnUnderLine = new System.Windows.Forms.ToolStripButton();
            this.btnBackColor = new System.Windows.Forms.ToolStripButton();
            this.btnForeColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.btnWordWrap = new System.Windows.Forms.ToolStripButton();
            this.btnAlignLeft = new System.Windows.Forms.ToolStripButton();
            this.btnAlignCenter = new System.Windows.Forms.ToolStripButton();
            this.btnAlignRight = new System.Windows.Forms.ToolStripButton();
            this.btnAlignTop = new System.Windows.Forms.ToolStripButton();
            this.btnAlignMiddle = new System.Windows.Forms.ToolStripButton();
            this.btnAlignBottom = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.lblLine = new System.Windows.Forms.ToolStripLabel();
            this.btnDrawBorder = new System.Windows.Forms.ToolStripSplitButton();
            this.menuDrawBorder1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDrawBorder2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDrawBorder3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDrawBorder4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDrawBorder5 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDrawBorder6 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDrawBorder7 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDrawBorder8 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEraseBorder = new System.Windows.Forms.ToolStripSplitButton();
            this.menuEraseBorder1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEraseBorder2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEraseBorder3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEraseBorder4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEraseBorder5 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEraseBorder6 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEraseBorder7 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEraseBorder8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.btnDrawTria = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDrawCir = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_FH = new System.Windows.Forms.ToolStripButton();
            this.ts_FH2 = new System.Windows.Forms.ToolStripButton();
            this.ts_FH3 = new System.Windows.Forms.ToolStripButton();
            this.tx_FH4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSymbol = new System.Windows.Forms.ToolStripButton();
            this.btnInsertPic = new System.Windows.Forms.ToolStripButton();
            this.ts_CellReadOnly = new System.Windows.Forms.ToolStripButton();
            this.btnHideArchive = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopyFile = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStat_fb = new System.Windows.Forms.ToolStripButton();
            this.btnStat_fx = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator36 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.mainTool = new ERM.UI.Controls.Skin_ToolStripEX();
            this.btn_InputTemplet = new System.Windows.Forms.ToolStripButton();
            this.toolCopy = new System.Windows.Forms.ToolStripButton();
            this.toolPaster = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonModify = new System.Windows.Forms.ToolStripButton();
            this.btn_Imge = new System.Windows.Forms.ToolStripButton();
            this.tsb_FL = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsb_SavaAndGd = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.contextMenuCell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.customPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolArchive.SuspendLayout();
            this.toolArchiveTab.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cell2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell1)).BeginInit();
            this.toolCellAssitant.SuspendLayout();
            this.toolCellFormat.SuspendLayout();
            this.mainTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.statusStrip1.BackgroundImage = global::ERM.UI.Properties.Resources.titlebg4;
            this.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusStrip1.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.statusStrip1.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel1,
            this.tssLabel2,
            this.tssLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(4, 671);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1022, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLabel1
            // 
            this.tssLabel1.AutoSize = false;
            this.tssLabel1.BackColor = System.Drawing.Color.Transparent;
            this.tssLabel1.LinkColor = System.Drawing.Color.Blue;
            this.tssLabel1.Name = "tssLabel1";
            this.tssLabel1.Size = new System.Drawing.Size(554, 17);
            this.tssLabel1.Spring = true;
            this.tssLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssLabel2
            // 
            this.tssLabel2.AutoSize = false;
            this.tssLabel2.BackColor = System.Drawing.Color.Transparent;
            this.tssLabel2.LinkColor = System.Drawing.Color.Blue;
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
            this.tsmiManage,
            this.tsmiEdit});
            this.mainMenu.Location = new System.Drawing.Point(4, 34);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.mainMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.mainMenu.Size = new System.Drawing.Size(1022, 27);
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
            this.tsmiPageSetup,
            this.tsmiPrintPreview,
            this.tsmiPrint,
            this.toolStripSeparator1,
            this.tsmiImportXls,
            this.tsmiSetAsTemplet,
            this.toolStripMenuItem1,
            this.tsmiClose});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(58, 21);
            this.tsmiFile.Text = "文件(&F)";
            // 
            // tsmiPageSetup
            // 
            this.tsmiPageSetup.Name = "tsmiPageSetup";
            this.tsmiPageSetup.Size = new System.Drawing.Size(153, 22);
            this.tsmiPageSetup.Text = "页面设置(&U)...";
            this.tsmiPageSetup.Visible = false;
            // 
            // tsmiPrintPreview
            // 
            this.tsmiPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("tsmiPrintPreview.Image")));
            this.tsmiPrintPreview.Name = "tsmiPrintPreview";
            this.tsmiPrintPreview.Size = new System.Drawing.Size(153, 22);
            this.tsmiPrintPreview.Text = "打印预览(&V)";
            this.tsmiPrintPreview.Visible = false;
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsmiPrint.Image")));
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.Size = new System.Drawing.Size(153, 22);
            this.tsmiPrint.Text = "打印(&P)...";
            this.tsmiPrint.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // tsmiImportXls
            // 
            this.tsmiImportXls.Name = "tsmiImportXls";
            this.tsmiImportXls.Size = new System.Drawing.Size(153, 22);
            this.tsmiImportXls.Text = "导入Excel文件";
            this.tsmiImportXls.Visible = false;
            // 
            // tsmiSetAsTemplet
            // 
            this.tsmiSetAsTemplet.Name = "tsmiSetAsTemplet";
            this.tsmiSetAsTemplet.Size = new System.Drawing.Size(153, 22);
            this.tsmiSetAsTemplet.Text = "存为模板";
            this.tsmiSetAsTemplet.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            this.toolStripMenuItem1.Visible = false;
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(153, 22);
            this.tsmiClose.Text = "关闭(&C)";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // tsmiManage
            // 
            this.tsmiManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHideArchive,
            this.toolStripMenuItem3,
            this.tsmiAddCustomCell,
            this.tsmiCopyFile,
            this.toolStripSeparator4,
            this.tsmiEditNode,
            this.tsmiDelNode});
            this.tsmiManage.Name = "tsmiManage";
            this.tsmiManage.Size = new System.Drawing.Size(88, 21);
            this.tsmiManage.Text = "目录管理(&M)";
            // 
            // tsmiHideArchive
            // 
            this.tsmiHideArchive.Name = "tsmiHideArchive";
            this.tsmiHideArchive.Size = new System.Drawing.Size(163, 22);
            this.tsmiHideArchive.Text = "隐藏目录";
            this.tsmiHideArchive.Click += new System.EventHandler(this.tsmiHideArchive_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 6);
            // 
            // tsmiAddCustomCell
            // 
            this.tsmiAddCustomCell.Name = "tsmiAddCustomCell";
            this.tsmiAddCustomCell.Size = new System.Drawing.Size(163, 22);
            this.tsmiAddCustomCell.Text = "自定表格";
            this.tsmiAddCustomCell.Visible = false;
            // 
            // tsmiCopyFile
            // 
            this.tsmiCopyFile.Name = "tsmiCopyFile";
            this.tsmiCopyFile.Size = new System.Drawing.Size(163, 22);
            this.tsmiCopyFile.Text = "复制表格";
            this.tsmiCopyFile.Click += new System.EventHandler(this.tsmiCopyFile_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(160, 6);
            // 
            // tsmiEditNode
            // 
            this.tsmiEditNode.Name = "tsmiEditNode";
            this.tsmiEditNode.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmiEditNode.Size = new System.Drawing.Size(163, 22);
            this.tsmiEditNode.Text = "修改";
            this.tsmiEditNode.Click += new System.EventHandler(this.tsmiEditNode_Click);
            // 
            // tsmiDelNode
            // 
            this.tsmiDelNode.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDelNode.Image")));
            this.tsmiDelNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiDelNode.Name = "tsmiDelNode";
            this.tsmiDelNode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.tsmiDelNode.Size = new System.Drawing.Size(163, 22);
            this.tsmiDelNode.Text = "删除(&D)";
            this.tsmiDelNode.Click += new System.EventHandler(this.tsmiDelNode_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUndo,
            this.tsmiRedo,
            this.toolStripSeparator21,
            this.tsmiCut,
            this.tsmiCopy,
            this.tsmiPaste,
            this.toolStripSeparator23,
            this.tsmiSelectAll,
            this.tsmiFill,
            this.tsmiSumSum,
            this.tsmiClear,
            this.toolStripSeparator24,
            this.tsmiSymbol,
            this.tsmiInsertPic,
            this.tsmiMergeCell,
            this.tsmiUnmergeCell,
            this.toolStripSeparator27,
            this.tsmiRepair,
            this.tsmiAutoEval,
            this.tsmiCellOption,
            this.tsmiPageOption,
            this.tsm_TOFile});
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(83, 21);
            this.tsmiEdit.Text = "表格编辑(&E)";
            // 
            // tsmiUndo
            // 
            this.tsmiUndo.Image = ((System.Drawing.Image)(resources.GetObject("tsmiUndo.Image")));
            this.tsmiUndo.Name = "tsmiUndo";
            this.tsmiUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmiUndo.Size = new System.Drawing.Size(169, 22);
            this.tsmiUndo.Text = "撤消(&U)";
            this.tsmiUndo.Click += new System.EventHandler(this.tsmiUndo_Click);
            // 
            // tsmiRedo
            // 
            this.tsmiRedo.Image = ((System.Drawing.Image)(resources.GetObject("tsmiRedo.Image")));
            this.tsmiRedo.Name = "tsmiRedo";
            this.tsmiRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.tsmiRedo.Size = new System.Drawing.Size(169, 22);
            this.tsmiRedo.Text = "重做(&R)";
            this.tsmiRedo.Click += new System.EventHandler(this.tsmiRedo_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(166, 6);
            // 
            // tsmiCut
            // 
            this.tsmiCut.Image = ((System.Drawing.Image)(resources.GetObject("tsmiCut.Image")));
            this.tsmiCut.Name = "tsmiCut";
            this.tsmiCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmiCut.Size = new System.Drawing.Size(169, 22);
            this.tsmiCut.Text = "剪切(&T)";
            this.tsmiCut.Click += new System.EventHandler(this.tsmiCut_Click);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsmiCopy.Image")));
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmiCopy.Size = new System.Drawing.Size(169, 22);
            this.tsmiCopy.Text = "复制(&C)";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // tsmiPaste
            // 
            this.tsmiPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsmiPaste.Image")));
            this.tsmiPaste.Name = "tsmiPaste";
            this.tsmiPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmiPaste.Size = new System.Drawing.Size(169, 22);
            this.tsmiPaste.Text = "粘贴(&P)";
            this.tsmiPaste.Click += new System.EventHandler(this.tsmiPaste_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(166, 6);
            // 
            // tsmiSelectAll
            // 
            this.tsmiSelectAll.Name = "tsmiSelectAll";
            this.tsmiSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmiSelectAll.Size = new System.Drawing.Size(169, 22);
            this.tsmiSelectAll.Text = "全选";
            this.tsmiSelectAll.Click += new System.EventHandler(this.tsmiSelectAll_Click);
            // 
            // tsmiFill
            // 
            this.tsmiFill.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRepeatFill,
            this.tsmiRndFill,
            this.tsmiRndSelectFill});
            this.tsmiFill.Name = "tsmiFill";
            this.tsmiFill.Size = new System.Drawing.Size(169, 22);
            this.tsmiFill.Text = "填充(&F)";
            // 
            // tsmiRepeatFill
            // 
            this.tsmiRepeatFill.Name = "tsmiRepeatFill";
            this.tsmiRepeatFill.Size = new System.Drawing.Size(156, 22);
            this.tsmiRepeatFill.Text = "重复填充";
            this.tsmiRepeatFill.Click += new System.EventHandler(this.tsmiRepeatFill_Click);
            // 
            // tsmiRndFill
            // 
            this.tsmiRndFill.Name = "tsmiRndFill";
            this.tsmiRndFill.Size = new System.Drawing.Size(156, 22);
            this.tsmiRndFill.Text = "随机填充(所有)";
            this.tsmiRndFill.Click += new System.EventHandler(this.tsmiRndFill_Click);
            // 
            // tsmiRndSelectFill
            // 
            this.tsmiRndSelectFill.Name = "tsmiRndSelectFill";
            this.tsmiRndSelectFill.Size = new System.Drawing.Size(156, 22);
            this.tsmiRndSelectFill.Text = "随机填充(选中)";
            this.tsmiRndSelectFill.Click += new System.EventHandler(this.tsmiRndSelectFill_Click);
            // 
            // tsmiSumSum
            // 
            this.tsmiSumSum.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSumH,
            this.tsmiSumV,
            this.tsmiSum});
            this.tsmiSumSum.Name = "tsmiSumSum";
            this.tsmiSumSum.Size = new System.Drawing.Size(169, 22);
            this.tsmiSumSum.Text = "汇总";
            // 
            // tsmiSumH
            // 
            this.tsmiSumH.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSumH.Image")));
            this.tsmiSumH.Name = "tsmiSumH";
            this.tsmiSumH.Size = new System.Drawing.Size(124, 22);
            this.tsmiSumH.Text = "横向求和";
            this.tsmiSumH.Click += new System.EventHandler(this.tsmiSumH_Click);
            // 
            // tsmiSumV
            // 
            this.tsmiSumV.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSumV.Image")));
            this.tsmiSumV.Name = "tsmiSumV";
            this.tsmiSumV.Size = new System.Drawing.Size(124, 22);
            this.tsmiSumV.Text = "纵向求和";
            this.tsmiSumV.Click += new System.EventHandler(this.tsmiSumV_Click);
            // 
            // tsmiSum
            // 
            this.tsmiSum.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSum.Image")));
            this.tsmiSum.Name = "tsmiSum";
            this.tsmiSum.Size = new System.Drawing.Size(124, 22);
            this.tsmiSum.Text = "双向求和";
            this.tsmiSum.Click += new System.EventHandler(this.tsmiSum_Click);
            // 
            // tsmiClear
            // 
            this.tsmiClear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClearText,
            this.tsmiClearImage,
            this.tsmiClearFormat,
            this.tsmiClearAll});
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(169, 22);
            this.tsmiClear.Text = "清除";
            // 
            // tsmiClearText
            // 
            this.tsmiClearText.Name = "tsmiClearText";
            this.tsmiClearText.Size = new System.Drawing.Size(124, 22);
            this.tsmiClearText.Text = "清除文字";
            this.tsmiClearText.Click += new System.EventHandler(this.tsmiClearText_Click);
            // 
            // tsmiClearImage
            // 
            this.tsmiClearImage.Name = "tsmiClearImage";
            this.tsmiClearImage.Size = new System.Drawing.Size(124, 22);
            this.tsmiClearImage.Text = "清除图像";
            this.tsmiClearImage.Click += new System.EventHandler(this.tsmiClearImage_Click);
            // 
            // tsmiClearFormat
            // 
            this.tsmiClearFormat.Name = "tsmiClearFormat";
            this.tsmiClearFormat.Size = new System.Drawing.Size(124, 22);
            this.tsmiClearFormat.Text = "清除格式";
            this.tsmiClearFormat.Click += new System.EventHandler(this.tsmiClearFormat_Click);
            // 
            // tsmiClearAll
            // 
            this.tsmiClearAll.Name = "tsmiClearAll";
            this.tsmiClearAll.Size = new System.Drawing.Size(124, 22);
            this.tsmiClearAll.Text = "清除全部";
            this.tsmiClearAll.Click += new System.EventHandler(this.tsmiClearAll_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(166, 6);
            // 
            // tsmiSymbol
            // 
            this.tsmiSymbol.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSymbol.Image")));
            this.tsmiSymbol.Name = "tsmiSymbol";
            this.tsmiSymbol.Size = new System.Drawing.Size(169, 22);
            this.tsmiSymbol.Text = "插入特殊符号";
            this.tsmiSymbol.Click += new System.EventHandler(this.tsmiSymbol_Click);
            // 
            // tsmiInsertPic
            // 
            this.tsmiInsertPic.Image = ((System.Drawing.Image)(resources.GetObject("tsmiInsertPic.Image")));
            this.tsmiInsertPic.Name = "tsmiInsertPic";
            this.tsmiInsertPic.Size = new System.Drawing.Size(169, 22);
            this.tsmiInsertPic.Text = "插入图片";
            this.tsmiInsertPic.Click += new System.EventHandler(this.tsmiInsertPic_Click);
            // 
            // tsmiMergeCell
            // 
            this.tsmiMergeCell.Name = "tsmiMergeCell";
            this.tsmiMergeCell.Size = new System.Drawing.Size(169, 22);
            this.tsmiMergeCell.Text = "设置组合(&J)";
            this.tsmiMergeCell.Click += new System.EventHandler(this.tsmiMergeCell_Click);
            // 
            // tsmiUnmergeCell
            // 
            this.tsmiUnmergeCell.Name = "tsmiUnmergeCell";
            this.tsmiUnmergeCell.Size = new System.Drawing.Size(169, 22);
            this.tsmiUnmergeCell.Text = "取消组合(G)";
            this.tsmiUnmergeCell.Click += new System.EventHandler(this.tsmiUnmergeCell_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(166, 6);
            // 
            // tsmiRepair
            // 
            this.tsmiRepair.Name = "tsmiRepair";
            this.tsmiRepair.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiRepair.Size = new System.Drawing.Size(169, 22);
            this.tsmiRepair.Text = "表格评定";
            this.tsmiRepair.Click += new System.EventHandler(this.tsmiRepair_Click);
            // 
            // tsmiAutoEval
            // 
            this.tsmiAutoEval.Checked = true;
            this.tsmiAutoEval.CheckOnClick = true;
            this.tsmiAutoEval.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiAutoEval.Name = "tsmiAutoEval";
            this.tsmiAutoEval.Size = new System.Drawing.Size(169, 22);
            this.tsmiAutoEval.Text = "自动评定";
            this.tsmiAutoEval.Click += new System.EventHandler(this.tsmiAutoEval_Click);
            // 
            // tsmiCellOption
            // 
            this.tsmiCellOption.Name = "tsmiCellOption";
            this.tsmiCellOption.Size = new System.Drawing.Size(169, 22);
            this.tsmiCellOption.Text = "单元格设置";
            this.tsmiCellOption.Click += new System.EventHandler(this.tsmiCellOption_Click);
            // 
            // tsmiPageOption
            // 
            this.tsmiPageOption.Name = "tsmiPageOption";
            this.tsmiPageOption.Size = new System.Drawing.Size(169, 22);
            this.tsmiPageOption.Text = "页面设置";
            this.tsmiPageOption.Click += new System.EventHandler(this.tsmiPageOption_Click);
            // 
            // tsm_TOFile
            // 
            this.tsm_TOFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Excel,
            this.tsmi_PDF});
            this.tsm_TOFile.Name = "tsm_TOFile";
            this.tsm_TOFile.Size = new System.Drawing.Size(169, 22);
            this.tsm_TOFile.Text = "输出文件";
            // 
            // tsmi_Excel
            // 
            this.tsmi_Excel.Name = "tsmi_Excel";
            this.tsmi_Excel.Size = new System.Drawing.Size(129, 22);
            this.tsmi_Excel.Text = "Excel文件";
            this.tsmi_Excel.Click += new System.EventHandler(this.tsmi_Excel_Click);
            // 
            // tsmi_PDF
            // 
            this.tsmi_PDF.Name = "tsmi_PDF";
            this.tsmi_PDF.Size = new System.Drawing.Size(129, 22);
            this.tsmi_PDF.Text = "PDF文件";
            this.tsmi_PDF.Click += new System.EventHandler(this.tsmi_PDF_Click);
            // 
            // menuReadOnly
            // 
            this.menuReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("menuReadOnly.Image")));
            this.menuReadOnly.Name = "menuReadOnly";
            this.menuReadOnly.Size = new System.Drawing.Size(169, 22);
            this.menuReadOnly.Text = "设置只读";
            this.menuReadOnly.Click += new System.EventHandler(this.menuReadOnly_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(166, 6);
            // 
            // menuCut
            // 
            this.menuCut.Image = ((System.Drawing.Image)(resources.GetObject("menuCut.Image")));
            this.menuCut.Name = "menuCut";
            this.menuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuCut.Size = new System.Drawing.Size(169, 22);
            this.menuCut.Text = "剪切(&T)";
            this.menuCut.Click += new System.EventHandler(this.menuCut_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuCopy.Image")));
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuCopy.Size = new System.Drawing.Size(169, 22);
            this.menuCopy.Text = "复制(&C)";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuPaste
            // 
            this.menuPaste.Image = ((System.Drawing.Image)(resources.GetObject("menuPaste.Image")));
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuPaste.Size = new System.Drawing.Size(169, 22);
            this.menuPaste.Text = "粘贴(&P)";
            this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(166, 6);
            // 
            // menuFill
            // 
            this.menuFill.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRepeatFill,
            this.menuRndFill,
            this.menuRndSelectFill});
            this.menuFill.Name = "menuFill";
            this.menuFill.Size = new System.Drawing.Size(169, 22);
            this.menuFill.Text = "填充(&F)";
            // 
            // menuRepeatFill
            // 
            this.menuRepeatFill.Name = "menuRepeatFill";
            this.menuRepeatFill.Size = new System.Drawing.Size(156, 22);
            this.menuRepeatFill.Text = "重复填充";
            this.menuRepeatFill.Click += new System.EventHandler(this.menuRepeatFill_Click);
            // 
            // menuRndFill
            // 
            this.menuRndFill.Name = "menuRndFill";
            this.menuRndFill.Size = new System.Drawing.Size(156, 22);
            this.menuRndFill.Text = "随机填充(所有)";
            this.menuRndFill.Click += new System.EventHandler(this.menuRndFill_Click);
            // 
            // menuRndSelectFill
            // 
            this.menuRndSelectFill.Name = "menuRndSelectFill";
            this.menuRndSelectFill.Size = new System.Drawing.Size(156, 22);
            this.menuRndSelectFill.Text = "随机填充(选中)";
            this.menuRndSelectFill.Click += new System.EventHandler(this.tsmiRndSelectFill_Click);
            // 
            // menuSumSum
            // 
            this.menuSumSum.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSumH,
            this.menuSumV,
            this.menuSum});
            this.menuSumSum.Name = "menuSumSum";
            this.menuSumSum.Size = new System.Drawing.Size(169, 22);
            this.menuSumSum.Text = "汇总";
            // 
            // menuSumH
            // 
            this.menuSumH.Name = "menuSumH";
            this.menuSumH.Size = new System.Drawing.Size(124, 22);
            this.menuSumH.Text = "横向求和";
            this.menuSumH.Click += new System.EventHandler(this.menuSumH_Click);
            // 
            // menuSumV
            // 
            this.menuSumV.Name = "menuSumV";
            this.menuSumV.Size = new System.Drawing.Size(124, 22);
            this.menuSumV.Text = "纵向求和";
            this.menuSumV.Click += new System.EventHandler(this.menuSumV_Click);
            // 
            // menuSum
            // 
            this.menuSum.Name = "menuSum";
            this.menuSum.Size = new System.Drawing.Size(124, 22);
            this.menuSum.Text = "双向求和";
            this.menuSum.Click += new System.EventHandler(this.menuSum_Click);
            // 
            // menuClear
            // 
            this.menuClear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClearText,
            this.menuClearImage,
            this.menuClearFormat,
            this.menuClearAll});
            this.menuClear.Name = "menuClear";
            this.menuClear.Size = new System.Drawing.Size(169, 22);
            this.menuClear.Text = "清除";
            // 
            // menuClearText
            // 
            this.menuClearText.Name = "menuClearText";
            this.menuClearText.Size = new System.Drawing.Size(124, 22);
            this.menuClearText.Text = "清除文字";
            this.menuClearText.Click += new System.EventHandler(this.menuClearText_Click);
            // 
            // menuClearImage
            // 
            this.menuClearImage.Name = "menuClearImage";
            this.menuClearImage.Size = new System.Drawing.Size(124, 22);
            this.menuClearImage.Text = "清除图像";
            this.menuClearImage.Click += new System.EventHandler(this.menuClearImage_Click);
            // 
            // menuClearFormat
            // 
            this.menuClearFormat.Name = "menuClearFormat";
            this.menuClearFormat.Size = new System.Drawing.Size(124, 22);
            this.menuClearFormat.Text = "清除格式";
            this.menuClearFormat.Click += new System.EventHandler(this.menuClearFormat_Click);
            // 
            // menuClearAll
            // 
            this.menuClearAll.Name = "menuClearAll";
            this.menuClearAll.Size = new System.Drawing.Size(124, 22);
            this.menuClearAll.Text = "清除全部";
            this.menuClearAll.Click += new System.EventHandler(this.menuClearAll_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(166, 6);
            // 
            // menuSymbol
            // 
            this.menuSymbol.Image = ((System.Drawing.Image)(resources.GetObject("menuSymbol.Image")));
            this.menuSymbol.Name = "menuSymbol";
            this.menuSymbol.Size = new System.Drawing.Size(169, 22);
            this.menuSymbol.Text = "插入特殊符号";
            this.menuSymbol.Click += new System.EventHandler(this.menuSymbol_Click);
            // 
            // menuInsertPic
            // 
            this.menuInsertPic.Image = ((System.Drawing.Image)(resources.GetObject("menuInsertPic.Image")));
            this.menuInsertPic.Name = "menuInsertPic";
            this.menuInsertPic.Size = new System.Drawing.Size(169, 22);
            this.menuInsertPic.Text = "插入图片";
            this.menuInsertPic.Click += new System.EventHandler(this.menuInsertPic_Click);
            // 
            // menuMergeCell
            // 
            this.menuMergeCell.Name = "menuMergeCell";
            this.menuMergeCell.Size = new System.Drawing.Size(169, 22);
            this.menuMergeCell.Text = "设置组合(&J)";
            this.menuMergeCell.Click += new System.EventHandler(this.menuMergeCell_Click);
            // 
            // menuUnmergeCell
            // 
            this.menuUnmergeCell.Name = "menuUnmergeCell";
            this.menuUnmergeCell.Size = new System.Drawing.Size(169, 22);
            this.menuUnmergeCell.Text = "取消组合(&G)";
            this.menuUnmergeCell.Click += new System.EventHandler(this.menuUnmergeCell_Click);
            // 
            // toolStripSeparator28
            // 
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            this.toolStripSeparator28.Size = new System.Drawing.Size(166, 6);
            // 
            // menuRepair
            // 
            this.menuRepair.Name = "menuRepair";
            this.menuRepair.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.menuRepair.Size = new System.Drawing.Size(169, 22);
            this.menuRepair.Text = "表格评定";
            this.menuRepair.Click += new System.EventHandler(this.menuRepair_Click);
            // 
            // menuCellOption
            // 
            this.menuCellOption.Name = "menuCellOption";
            this.menuCellOption.Size = new System.Drawing.Size(169, 22);
            this.menuCellOption.Text = "单元格设置";
            this.menuCellOption.Click += new System.EventHandler(this.menuCellOption_Click);
            // 
            // contextMenuCell
            // 
            this.contextMenuCell.Arrow = System.Drawing.Color.Black;
            this.contextMenuCell.Back = System.Drawing.Color.White;
            this.contextMenuCell.BackRadius = 4;
            this.contextMenuCell.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.contextMenuCell.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.contextMenuCell.Fore = System.Drawing.Color.Black;
            this.contextMenuCell.HoverFore = System.Drawing.Color.Black;
            this.contextMenuCell.ItemAnamorphosis = true;
            this.contextMenuCell.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenuCell.ItemBorderShow = true;
            this.contextMenuCell.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenuCell.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenuCell.ItemRadius = 4;
            this.contextMenuCell.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenuCell.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReadOnly,
            this.toolStripSeparator29,
            this.menuCut,
            this.menuCopy,
            this.menuPaste,
            this.toolStripSeparator25,
            this.menuFill,
            this.menuSumSum,
            this.menuCellLine,
            this.menuClearCellLine,
            this.menuClear,
            this.toolStripSeparator26,
            this.menuSymbol,
            this.menuImge,
            this.menuInsertPic,
            this.menuMergeCell,
            this.menuUnmergeCell,
            this.toolStripSeparator28,
            this.menuRepair,
            this.menuAutoEval,
            this.menuCellOption,
            this.menuCellPageSet,
            this.menuCellHeadInfo,
            this.tsmi_TOFile});
            this.contextMenuCell.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenuCell.Name = "contextMenuCell";
            this.contextMenuCell.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenuCell.Size = new System.Drawing.Size(170, 468);
            this.contextMenuCell.SkinAllColor = true;
            this.contextMenuCell.TitleAnamorphosis = true;
            this.contextMenuCell.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.contextMenuCell.TitleRadius = 4;
            this.contextMenuCell.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // menuCellLine
            // 
            this.menuCellLine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_wanggexian,
            this.menu_kuangxian,
            this.menu_leftline,
            this.menu_rightline,
            this.menu_topline,
            this.menu_buttonline,
            this.menu_zhengxian,
            this.menu_fangxian});
            this.menuCellLine.Image = global::ERM.UI.Properties.Resources.c_Border;
            this.menuCellLine.Name = "menuCellLine";
            this.menuCellLine.Size = new System.Drawing.Size(169, 22);
            this.menuCellLine.Text = "画网格线";
            // 
            // menu_wanggexian
            // 
            this.menu_wanggexian.Name = "menu_wanggexian";
            this.menu_wanggexian.Size = new System.Drawing.Size(148, 22);
            this.menu_wanggexian.Text = "画网格线";
            this.menu_wanggexian.Click += new System.EventHandler(this.menuDrawBorder1_Click);
            // 
            // menu_kuangxian
            // 
            this.menu_kuangxian.Name = "menu_kuangxian";
            this.menu_kuangxian.Size = new System.Drawing.Size(148, 22);
            this.menu_kuangxian.Text = "画框线";
            this.menu_kuangxian.Click += new System.EventHandler(this.menuDrawBorder2_Click);
            // 
            // menu_leftline
            // 
            this.menu_leftline.Name = "menu_leftline";
            this.menu_leftline.Size = new System.Drawing.Size(148, 22);
            this.menu_leftline.Text = "画单元格左线";
            this.menu_leftline.Click += new System.EventHandler(this.menuDrawBorder3_Click);
            // 
            // menu_rightline
            // 
            this.menu_rightline.Name = "menu_rightline";
            this.menu_rightline.Size = new System.Drawing.Size(148, 22);
            this.menu_rightline.Text = "画单元格右线";
            this.menu_rightline.Click += new System.EventHandler(this.menuDrawBorder4_Click);
            // 
            // menu_topline
            // 
            this.menu_topline.Name = "menu_topline";
            this.menu_topline.Size = new System.Drawing.Size(148, 22);
            this.menu_topline.Text = "画单元格上线";
            this.menu_topline.Click += new System.EventHandler(this.menuDrawBorder5_Click);
            // 
            // menu_buttonline
            // 
            this.menu_buttonline.Name = "menu_buttonline";
            this.menu_buttonline.Size = new System.Drawing.Size(148, 22);
            this.menu_buttonline.Text = "画单元格下线";
            this.menu_buttonline.Click += new System.EventHandler(this.menuDrawBorder6_Click);
            // 
            // menu_zhengxian
            // 
            this.menu_zhengxian.Name = "menu_zhengxian";
            this.menu_zhengxian.Size = new System.Drawing.Size(148, 22);
            this.menu_zhengxian.Text = "画正斜线";
            this.menu_zhengxian.Click += new System.EventHandler(this.menuDrawBorder7_Click);
            // 
            // menu_fangxian
            // 
            this.menu_fangxian.Name = "menu_fangxian";
            this.menu_fangxian.Size = new System.Drawing.Size(148, 22);
            this.menu_fangxian.Text = "画反斜线";
            this.menu_fangxian.Click += new System.EventHandler(this.menuDrawBorder8_Click);
            // 
            // menuClearCellLine
            // 
            this.menuClearCellLine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_clearwgx,
            this.menu_clearkx,
            this.menu_clearleftline,
            this.menu_clearrightline,
            this.menu_cleartopline,
            this.menu_clearbuttonline,
            this.menu_clearzxx,
            this.menu_clearfxx});
            this.menuClearCellLine.Image = global::ERM.UI.Properties.Resources.c_EraseBorder;
            this.menuClearCellLine.Name = "menuClearCellLine";
            this.menuClearCellLine.Size = new System.Drawing.Size(169, 22);
            this.menuClearCellLine.Text = "抹网格线";
            // 
            // menu_clearwgx
            // 
            this.menu_clearwgx.Name = "menu_clearwgx";
            this.menu_clearwgx.Size = new System.Drawing.Size(148, 22);
            this.menu_clearwgx.Text = "抹网格线";
            this.menu_clearwgx.Click += new System.EventHandler(this.menuEraseBorder1_Click);
            // 
            // menu_clearkx
            // 
            this.menu_clearkx.Name = "menu_clearkx";
            this.menu_clearkx.Size = new System.Drawing.Size(148, 22);
            this.menu_clearkx.Text = "抹框线";
            this.menu_clearkx.Click += new System.EventHandler(this.menuEraseBorder2_Click);
            // 
            // menu_clearleftline
            // 
            this.menu_clearleftline.Name = "menu_clearleftline";
            this.menu_clearleftline.Size = new System.Drawing.Size(148, 22);
            this.menu_clearleftline.Text = "抹单元格左线";
            this.menu_clearleftline.Click += new System.EventHandler(this.menuEraseBorder3_Click);
            // 
            // menu_clearrightline
            // 
            this.menu_clearrightline.Name = "menu_clearrightline";
            this.menu_clearrightline.Size = new System.Drawing.Size(148, 22);
            this.menu_clearrightline.Text = "抹单元格右线";
            this.menu_clearrightline.Click += new System.EventHandler(this.menuEraseBorder4_Click);
            // 
            // menu_cleartopline
            // 
            this.menu_cleartopline.Name = "menu_cleartopline";
            this.menu_cleartopline.Size = new System.Drawing.Size(148, 22);
            this.menu_cleartopline.Text = "抹单元格上线";
            this.menu_cleartopline.Click += new System.EventHandler(this.menuEraseBorder5_Click);
            // 
            // menu_clearbuttonline
            // 
            this.menu_clearbuttonline.Name = "menu_clearbuttonline";
            this.menu_clearbuttonline.Size = new System.Drawing.Size(148, 22);
            this.menu_clearbuttonline.Text = "抹单元格下线";
            this.menu_clearbuttonline.Click += new System.EventHandler(this.menuEraseBorder6_Click);
            // 
            // menu_clearzxx
            // 
            this.menu_clearzxx.Name = "menu_clearzxx";
            this.menu_clearzxx.Size = new System.Drawing.Size(148, 22);
            this.menu_clearzxx.Text = "抹正斜线";
            this.menu_clearzxx.Click += new System.EventHandler(this.menuEraseBorder7_Click);
            // 
            // menu_clearfxx
            // 
            this.menu_clearfxx.Name = "menu_clearfxx";
            this.menu_clearfxx.Size = new System.Drawing.Size(148, 22);
            this.menu_clearfxx.Text = "抹反斜线";
            this.menu_clearfxx.Click += new System.EventHandler(this.menuEraseBorder8_Click);
            // 
            // menuImge
            // 
            this.menuImge.Image = global::ERM.UI.Properties.Resources._10;
            this.menuImge.Name = "menuImge";
            this.menuImge.Size = new System.Drawing.Size(169, 22);
            this.menuImge.Text = "画图";
            this.menuImge.Click += new System.EventHandler(this.menuImge_Click);
            // 
            // menuAutoEval
            // 
            this.menuAutoEval.Checked = true;
            this.menuAutoEval.CheckOnClick = true;
            this.menuAutoEval.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuAutoEval.Name = "menuAutoEval";
            this.menuAutoEval.Size = new System.Drawing.Size(169, 22);
            this.menuAutoEval.Text = "自动评定";
            this.menuAutoEval.Click += new System.EventHandler(this.menuAutoEval_Click);
            // 
            // menuCellPageSet
            // 
            this.menuCellPageSet.Name = "menuCellPageSet";
            this.menuCellPageSet.Size = new System.Drawing.Size(169, 22);
            this.menuCellPageSet.Text = "页面设置";
            this.menuCellPageSet.Click += new System.EventHandler(this.tsmiPageOption_Click);
            // 
            // menuCellHeadInfo
            // 
            this.menuCellHeadInfo.Name = "menuCellHeadInfo";
            this.menuCellHeadInfo.Size = new System.Drawing.Size(169, 22);
            this.menuCellHeadInfo.Text = "表头信息";
            this.menuCellHeadInfo.Click += new System.EventHandler(this.menuCellHeadInfo_Click);
            // 
            // tsmi_TOFile
            // 
            this.tsmi_TOFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Excel1,
            this.tsmi_PDF2});
            this.tsmi_TOFile.Name = "tsmi_TOFile";
            this.tsmi_TOFile.Size = new System.Drawing.Size(169, 22);
            this.tsmi_TOFile.Text = "输出文件";
            // 
            // tsmi_Excel1
            // 
            this.tsmi_Excel1.Name = "tsmi_Excel1";
            this.tsmi_Excel1.Size = new System.Drawing.Size(129, 22);
            this.tsmi_Excel1.Text = "Excel文件";
            this.tsmi_Excel1.Click += new System.EventHandler(this.tsmi_Excel_Click);
            // 
            // tsmi_PDF2
            // 
            this.tsmi_PDF2.Name = "tsmi_PDF2";
            this.tsmi_PDF2.Size = new System.Drawing.Size(129, 22);
            this.tsmi_PDF2.Text = "PDF文件";
            this.tsmi_PDF2.Click += new System.EventHandler(this.tsmi_PDF_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::ERM.UI.Properties.Settings.Default, "TreeWidth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(4, 101);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.customPanel2);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(1, 2, 1, 4);
            this.splitContainer1.Panel1MinSize = 2;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.cboLine);
            this.splitContainer1.Panel2.Controls.Add(this.toolCellAssitant);
            this.splitContainer1.Panel2.Controls.Add(this.toolCellFormat);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.splitContainer1.Size = new System.Drawing.Size(1022, 570);
            this.splitContainer1.SplitterDistance = 337;
            this.splitContainer1.TabIndex = 7;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.CheckBoxes = true;
            this.treeView1.ContextMenuStrip = this.contextMenu;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.ItemHeight = 18;
            this.treeView1.Location = new System.Drawing.Point(1, 67);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(335, 499);
            this.treeView1.TabIndex = 3;
            this.treeView1.TabStop = false;
            this.treeView1.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_BeforeLabelEdit);
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // contextMenu
            // 
            this.contextMenu.Arrow = System.Drawing.Color.Black;
            this.contextMenu.Back = System.Drawing.Color.White;
            this.contextMenu.BackRadius = 4;
            this.contextMenu.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.contextMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.contextMenu.Fore = System.Drawing.Color.Black;
            this.contextMenu.HoverFore = System.Drawing.Color.Black;
            this.contextMenu.ItemAnamorphosis = true;
            this.contextMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenu.ItemBorderShow = true;
            this.contextMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenu.ItemRadius = 4;
            this.contextMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditNode,
            this.menuDelNode});
            this.contextMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenu.Size = new System.Drawing.Size(147, 48);
            this.contextMenu.SkinAllColor = true;
            this.contextMenu.TitleAnamorphosis = true;
            this.contextMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.contextMenu.TitleRadius = 4;
            this.contextMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // menuEditNode
            // 
            this.menuEditNode.Name = "menuEditNode";
            this.menuEditNode.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuEditNode.Size = new System.Drawing.Size(146, 22);
            this.menuEditNode.Text = "重命名";
            this.menuEditNode.Click += new System.EventHandler(this.menuEditNode_Click);
            // 
            // menuDelNode
            // 
            this.menuDelNode.Image = ((System.Drawing.Image)(resources.GetObject("menuDelNode.Image")));
            this.menuDelNode.Name = "menuDelNode";
            this.menuDelNode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.menuDelNode.Size = new System.Drawing.Size(146, 22);
            this.menuDelNode.Text = "删除";
            this.menuDelNode.Click += new System.EventHandler(this.menuDelNode_Click);
            // 
            // customPanel2
            // 
            this.customPanel2.Controls.Add(this.panel2);
            this.customPanel2.Controls.Add(this.checkBoxSelectAll);
            this.customPanel2.Controls.Add(this.toolArchiveTab);
            this.customPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.customPanel2.Location = new System.Drawing.Point(1, 2);
            this.customPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Padding = new System.Windows.Forms.Padding(1, 0, 1, 2);
            this.customPanel2.Size = new System.Drawing.Size(335, 65);
            this.customPanel2.StartColor = System.Drawing.SystemColors.Control;
            this.customPanel2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.toolArchive);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(58, 25);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 38);
            this.panel2.TabIndex = 4;
            // 
            // toolArchive
            // 
            this.toolArchive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.toolArchive.CanOverflow = false;
            this.toolArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolArchive.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolArchive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.t1_Up,
            this.t1_Down});
            this.toolArchive.Location = new System.Drawing.Point(0, 0);
            this.toolArchive.Name = "toolArchive";
            this.toolArchive.Padding = new System.Windows.Forms.Padding(0);
            this.toolArchive.Size = new System.Drawing.Size(276, 38);
            this.toolArchive.TabIndex = 2;
            this.toolArchive.Text = "myToolStrip1";
            // 
            // t1_Up
            // 
            this.t1_Up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.t1_Up.Image = ((System.Drawing.Image)(resources.GetObject("t1_Up.Image")));
            this.t1_Up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.t1_Up.Name = "t1_Up";
            this.t1_Up.Size = new System.Drawing.Size(23, 35);
            this.t1_Up.Text = "toolStripButton2";
            this.t1_Up.ToolTipText = "向上移动电子表格";
            this.t1_Up.Click += new System.EventHandler(this.t1_Up_Click);
            // 
            // t1_Down
            // 
            this.t1_Down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.t1_Down.Image = ((System.Drawing.Image)(resources.GetObject("t1_Down.Image")));
            this.t1_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.t1_Down.Name = "t1_Down";
            this.t1_Down.Size = new System.Drawing.Size(23, 35);
            this.t1_Down.Text = "toolStripButton3";
            this.t1_Down.ToolTipText = "向下移动电子表格";
            this.t1_Down.Click += new System.EventHandler(this.t1_Down_Click);
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.checkBoxSelectAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(1, 25);
            this.checkBoxSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSelectAll.MinimumSize = new System.Drawing.Size(20, 20);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.checkBoxSelectAll.Size = new System.Drawing.Size(57, 38);
            this.checkBoxSelectAll.TabIndex = 3;
            this.checkBoxSelectAll.Text = "全选";
            this.checkBoxSelectAll.UseVisualStyleBackColor = false;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // toolArchiveTab
            // 
            this.toolArchiveTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.toolArchiveTab.BackgroundImage = global::ERM.UI.Properties.Resources.tit_bg;
            this.toolArchiveTab.DrawBorder = true;
            this.toolArchiveTab.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolArchiveTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabArchive,
            this.imgHideArchive});
            this.toolArchiveTab.Location = new System.Drawing.Point(1, 0);
            this.toolArchiveTab.Name = "toolArchiveTab";
            this.toolArchiveTab.Size = new System.Drawing.Size(333, 25);
            this.toolArchiveTab.TabIndex = 0;
            this.toolArchiveTab.Text = "myToolStrip1";
            // 
            // tabArchive
            // 
            this.tabArchive.BackColor = System.Drawing.Color.Transparent;
            this.tabArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tabArchive.Image = ((System.Drawing.Image)(resources.GetObject("tabArchive.Image")));
            this.tabArchive.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tabArchive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tabArchive.Margin = new System.Windows.Forms.Padding(8, 2, 0, -1);
            this.tabArchive.Name = "tabArchive";
            this.tabArchive.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tabArchive.Size = new System.Drawing.Size(64, 24);
            this.tabArchive.Text = "归档范围";
            // 
            // imgHideArchive
            // 
            this.imgHideArchive.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.imgHideArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imgHideArchive.Image = ((System.Drawing.Image)(resources.GetObject("imgHideArchive.Image")));
            this.imgHideArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imgHideArchive.Name = "imgHideArchive";
            this.imgHideArchive.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.imgHideArchive.Size = new System.Drawing.Size(23, 22);
            this.imgHideArchive.Text = "关闭";
            this.imgHideArchive.Click += new System.EventHandler(this.imgHideArchive_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Cell2);
            this.panel1.Controls.Add(this.Cell1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(679, 516);
            this.panel1.TabIndex = 8;
            // 
            // Cell2
            // 
            this.Cell2.Enabled = true;
            this.Cell2.Location = new System.Drawing.Point(53, 38);
            this.Cell2.Margin = new System.Windows.Forms.Padding(4);
            this.Cell2.Name = "Cell2";
            this.Cell2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Cell2.OcxState")));
            this.Cell2.Size = new System.Drawing.Size(461, 189);
            this.Cell2.TabIndex = 7;
            this.Cell2.Visible = false;
            // 
            // Cell1
            // 
            this.Cell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell1.Enabled = true;
            this.Cell1.Location = new System.Drawing.Point(4, 4);
            this.Cell1.Margin = new System.Windows.Forms.Padding(4);
            this.Cell1.Name = "Cell1";
            this.Cell1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Cell1.OcxState")));
            this.Cell1.Size = new System.Drawing.Size(671, 508);
            this.Cell1.TabIndex = 6;
            this.Cell1.AllowMove += new AxCELL50Lib._DCell2000Events_AllowMoveEventHandler(this.Cell1_AllowMove);
            this.Cell1.AllowInputFormula += new AxCELL50Lib._DCell2000Events_AllowInputFormulaEventHandler(this.Cell1_AllowInputFormula);
            this.Cell1.MouseLClick += new AxCELL50Lib._DCell2000Events_MouseLClickEventHandler(this.Cell1_MouseLClick);
            this.Cell1.MouseDClick += new AxCELL50Lib._DCell2000Events_MouseDClickEventHandler(this.Cell1_MouseDClick);
            this.Cell1.MouseMoving += new AxCELL50Lib._DCell2000Events_MouseMovingEventHandler(this.Cell1_MouseMoving);
            this.Cell1.EditFinish += new AxCELL50Lib._DCell2000Events_EditFinishEventHandler(this.Cell1_EditFinish);
            this.Cell1.MenuStart += new AxCELL50Lib._DCell2000Events_MenuStartEventHandler(this.Cell1_MenuStart);
            this.Cell1.KeyDown2 += new AxCELL50Lib._DCell2000Events_KeyDown2EventHandler(this.Cell1_KeyDown2);
            // 
            // cboLine
            // 
            this.cboLine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLine.FormattingEnabled = true;
            this.cboLine.ImageList = null;
            this.cboLine.Location = new System.Drawing.Point(538, 2);
            this.cboLine.Margin = new System.Windows.Forms.Padding(4);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(81, 24);
            this.cboLine.TabIndex = 5;
            // 
            // toolCellAssitant
            // 
            this.toolCellAssitant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.toolCellAssitant.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.toolCellAssitant.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.toolCellAssitant.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnPrint,
            this.btnPrintpreview,
            this.toolStripSeparator16,
            this.btnCut,
            this.btnCopy,
            this.btnPaste,
            this.toolStripSeparator22,
            this.btnUndo,
            this.btnRedo,
            this.toolStripSeparator17,
            this.btnRow,
            this.btnCol,
            this.btnGridline,
            this.toolStripSeparator18,
            this.btnMergeCell,
            this.btnUnmergeCell,
            this.toolStripSeparator19,
            this.cboZoom,
            this.btnInsertCol,
            this.btnDeleteCol,
            this.btnInsertRow,
            this.btnDeleteRow,
            this.toolStripSeparator15,
            this.btnRndFill,
            this.dro_CellFill,
            this.btnSumH,
            this.btnSumV,
            this.btnSum});
            this.toolCellAssitant.Location = new System.Drawing.Point(1, 27);
            this.toolCellAssitant.Name = "toolCellAssitant";
            this.toolCellAssitant.Size = new System.Drawing.Size(679, 25);
            this.toolCellAssitant.TabIndex = 3;
            this.toolCellAssitant.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton1";
            this.btnSave.ToolTipText = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 22);
            this.btnPrint.Text = "toolStripButton29";
            this.btnPrint.ToolTipText = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintpreview
            // 
            this.btnPrintpreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintpreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintpreview.Image")));
            this.btnPrintpreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintpreview.Name = "btnPrintpreview";
            this.btnPrintpreview.Size = new System.Drawing.Size(23, 22);
            this.btnPrintpreview.Text = "toolStripButton1";
            this.btnPrintpreview.ToolTipText = "打印预览";
            this.btnPrintpreview.Click += new System.EventHandler(this.btnPrintpreview_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCut
            // 
            this.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCut.Image = ((System.Drawing.Image)(resources.GetObject("btnCut.Image")));
            this.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(23, 22);
            this.btnCut.Text = "toolStripButton1";
            this.btnCut.ToolTipText = "剪切";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(23, 22);
            this.btnCopy.Text = "toolStripButton2";
            this.btnCopy.ToolTipText = "复制";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(23, 22);
            this.btnPaste.Text = "toolStripButton3";
            this.btnPaste.ToolTipText = "粘贴";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(23, 22);
            this.btnUndo.Text = "toolStripButton4";
            this.btnUndo.ToolTipText = "撤消";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(23, 22);
            this.btnRedo.Text = "toolStripButton6";
            this.btnRedo.ToolTipText = "重做";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRow
            // 
            this.btnRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRow.Image = ((System.Drawing.Image)(resources.GetObject("btnRow.Image")));
            this.btnRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRow.Name = "btnRow";
            this.btnRow.Size = new System.Drawing.Size(23, 22);
            this.btnRow.Text = "toolStripButton1";
            this.btnRow.ToolTipText = "显示/隐藏行标";
            this.btnRow.Click += new System.EventHandler(this.btnRow_Click);
            // 
            // btnCol
            // 
            this.btnCol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCol.Image = ((System.Drawing.Image)(resources.GetObject("btnCol.Image")));
            this.btnCol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCol.Name = "btnCol";
            this.btnCol.Size = new System.Drawing.Size(23, 22);
            this.btnCol.Text = "toolStripButton2";
            this.btnCol.ToolTipText = "显示/隐藏列标";
            this.btnCol.Click += new System.EventHandler(this.btnCol_Click);
            // 
            // btnGridline
            // 
            this.btnGridline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGridline.Image = ((System.Drawing.Image)(resources.GetObject("btnGridline.Image")));
            this.btnGridline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGridline.Name = "btnGridline";
            this.btnGridline.Size = new System.Drawing.Size(23, 22);
            this.btnGridline.Text = "toolStripButton1";
            this.btnGridline.ToolTipText = "显示/隐藏网格线";
            this.btnGridline.Click += new System.EventHandler(this.btnGridline_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // btnMergeCell
            // 
            this.btnMergeCell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMergeCell.Image = ((System.Drawing.Image)(resources.GetObject("btnMergeCell.Image")));
            this.btnMergeCell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMergeCell.Name = "btnMergeCell";
            this.btnMergeCell.Size = new System.Drawing.Size(23, 22);
            this.btnMergeCell.Text = "toolStripButton1";
            this.btnMergeCell.ToolTipText = "组合单元格";
            this.btnMergeCell.Click += new System.EventHandler(this.btnMergeCell_Click);
            // 
            // btnUnmergeCell
            // 
            this.btnUnmergeCell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnmergeCell.Image = ((System.Drawing.Image)(resources.GetObject("btnUnmergeCell.Image")));
            this.btnUnmergeCell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnmergeCell.Name = "btnUnmergeCell";
            this.btnUnmergeCell.Size = new System.Drawing.Size(23, 22);
            this.btnUnmergeCell.Text = "toolStripButton1";
            this.btnUnmergeCell.ToolTipText = "取消组合单元";
            this.btnUnmergeCell.Click += new System.EventHandler(this.btnUnmergeCell_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // cboZoom
            // 
            this.cboZoom.AutoCompleteCustomSource.AddRange(new string[] {
            "200%",
            "150%",
            "120%",
            "100%",
            "90%",
            "80%",
            "70%",
            "60%",
            "50%",
            "20%",
            "10%",
            "5%",
            "3%"});
            this.cboZoom.Items.AddRange(new object[] {
            "200%",
            "150%",
            "120%",
            "100%",
            "90%",
            "80%",
            "70%",
            "60%",
            "50%",
            "20%",
            "10%",
            "5%",
            "3%"});
            this.cboZoom.Name = "cboZoom";
            this.cboZoom.Size = new System.Drawing.Size(87, 25);
            this.cboZoom.ToolTipText = "显示比例";
            this.cboZoom.DropDownClosed += new System.EventHandler(this.cboZoom_DropDownClosed);
            this.cboZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboZoom_KeyDown);
            // 
            // btnInsertCol
            // 
            this.btnInsertCol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInsertCol.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertCol.Image")));
            this.btnInsertCol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInsertCol.Name = "btnInsertCol";
            this.btnInsertCol.Size = new System.Drawing.Size(23, 22);
            this.btnInsertCol.Text = "toolStripButton1";
            this.btnInsertCol.ToolTipText = "插入列";
            this.btnInsertCol.Click += new System.EventHandler(this.btnInsertCol_Click);
            // 
            // btnDeleteCol
            // 
            this.btnDeleteCol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteCol.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteCol.Image")));
            this.btnDeleteCol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteCol.Name = "btnDeleteCol";
            this.btnDeleteCol.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteCol.Text = "toolStripButton3";
            this.btnDeleteCol.ToolTipText = "删除列";
            this.btnDeleteCol.Click += new System.EventHandler(this.btnDeleteCol_Click);
            // 
            // btnInsertRow
            // 
            this.btnInsertRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInsertRow.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertRow.Image")));
            this.btnInsertRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInsertRow.Name = "btnInsertRow";
            this.btnInsertRow.Size = new System.Drawing.Size(23, 22);
            this.btnInsertRow.Text = "toolStripButton2";
            this.btnInsertRow.ToolTipText = "插入行";
            this.btnInsertRow.Click += new System.EventHandler(this.btnInsertRow_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteRow.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteRow.Image")));
            this.btnDeleteRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteRow.Text = "toolStripButton4";
            this.btnDeleteRow.ToolTipText = "删除行";
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRndFill
            // 
            this.btnRndFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRndFill.Image = ((System.Drawing.Image)(resources.GetObject("btnRndFill.Image")));
            this.btnRndFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRndFill.Name = "btnRndFill";
            this.btnRndFill.Size = new System.Drawing.Size(23, 22);
            this.btnRndFill.Text = "toolStripButton1";
            this.btnRndFill.ToolTipText = "随机填充";
            this.btnRndFill.Visible = false;
            this.btnRndFill.Click += new System.EventHandler(this.btnRndFill_Click);
            // 
            // dro_CellFill
            // 
            this.dro_CellFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dro_CellFill.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_ReperFill,
            this.tsm_AllFill,
            this.tsm_SelectFill});
            this.dro_CellFill.Image = global::ERM.UI.Properties.Resources.c_AutoFill;
            this.dro_CellFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dro_CellFill.Name = "dro_CellFill";
            this.dro_CellFill.Size = new System.Drawing.Size(29, 22);
            this.dro_CellFill.Text = "随机填充";
            this.dro_CellFill.ToolTipText = "随机填充";
            // 
            // tsm_ReperFill
            // 
            this.tsm_ReperFill.Name = "tsm_ReperFill";
            this.tsm_ReperFill.Size = new System.Drawing.Size(156, 22);
            this.tsm_ReperFill.Text = "重复填充";
            this.tsm_ReperFill.ToolTipText = "重复填充";
            this.tsm_ReperFill.Click += new System.EventHandler(this.menuRepeatFill_Click);
            // 
            // tsm_AllFill
            // 
            this.tsm_AllFill.Name = "tsm_AllFill";
            this.tsm_AllFill.Size = new System.Drawing.Size(156, 22);
            this.tsm_AllFill.Text = "随机填充(所有)";
            this.tsm_AllFill.ToolTipText = "随机填充(所有)";
            this.tsm_AllFill.Click += new System.EventHandler(this.menuRndFill_Click);
            // 
            // tsm_SelectFill
            // 
            this.tsm_SelectFill.Name = "tsm_SelectFill";
            this.tsm_SelectFill.Size = new System.Drawing.Size(156, 22);
            this.tsm_SelectFill.Text = "随机填充(选中)";
            this.tsm_SelectFill.ToolTipText = "随机填充(选中)";
            this.tsm_SelectFill.Click += new System.EventHandler(this.tsmiRndSelectFill_Click);
            // 
            // btnSumH
            // 
            this.btnSumH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSumH.Image = ((System.Drawing.Image)(resources.GetObject("btnSumH.Image")));
            this.btnSumH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSumH.Name = "btnSumH";
            this.btnSumH.Size = new System.Drawing.Size(23, 22);
            this.btnSumH.Text = "toolStripButton2";
            this.btnSumH.ToolTipText = "横向求和";
            this.btnSumH.Click += new System.EventHandler(this.btnSumH_Click);
            // 
            // btnSumV
            // 
            this.btnSumV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSumV.Image = ((System.Drawing.Image)(resources.GetObject("btnSumV.Image")));
            this.btnSumV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSumV.Name = "btnSumV";
            this.btnSumV.Size = new System.Drawing.Size(23, 22);
            this.btnSumV.Text = "toolStripButton3";
            this.btnSumV.ToolTipText = "纵向求和";
            this.btnSumV.Click += new System.EventHandler(this.btnSumV_Click);
            // 
            // btnSum
            // 
            this.btnSum.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSum.Image = ((System.Drawing.Image)(resources.GetObject("btnSum.Image")));
            this.btnSum.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(23, 22);
            this.btnSum.Text = "toolStripButton4";
            this.btnSum.ToolTipText = "双向求和";
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // toolCellFormat
            // 
            this.toolCellFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.toolCellFormat.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.toolCellFormat.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.toolCellFormat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboFonts,
            this.cboFontSize,
            this.toolStripSeparator12,
            this.btnBold,
            this.btnItalic,
            this.btnUnderLine,
            this.btnBackColor,
            this.btnForeColor,
            this.toolStripSeparator13,
            this.btnWordWrap,
            this.btnAlignLeft,
            this.btnAlignCenter,
            this.btnAlignRight,
            this.btnAlignTop,
            this.btnAlignMiddle,
            this.btnAlignBottom,
            this.toolStripSeparator14,
            this.lblLine,
            this.btnDrawBorder,
            this.btnEraseBorder,
            this.toolStripSplitButton1,
            this.ts_FH,
            this.ts_FH2,
            this.ts_FH3,
            this.tx_FH4,
            this.toolStripSeparator20,
            this.btnSymbol,
            this.btnInsertPic,
            this.ts_CellReadOnly});
            this.toolCellFormat.Location = new System.Drawing.Point(1, 2);
            this.toolCellFormat.Name = "toolCellFormat";
            this.toolCellFormat.Size = new System.Drawing.Size(679, 25);
            this.toolCellFormat.TabIndex = 2;
            this.toolCellFormat.Text = "toolStrip1";
            // 
            // cboFonts
            // 
            this.cboFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFonts.Name = "cboFonts";
            this.cboFonts.Size = new System.Drawing.Size(116, 25);
            this.cboFonts.ToolTipText = "字体";
            this.cboFonts.DropDownClosed += new System.EventHandler(this.cboFonts_DropDownClosed);
            // 
            // cboFontSize
            // 
            this.cboFontSize.AutoSize = false;
            this.cboFontSize.DropDownWidth = 50;
            this.cboFontSize.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "30",
            "36",
            "42",
            "48",
            "72",
            "100",
            "150",
            "300",
            "500",
            "1200",
            "2000"});
            this.cboFontSize.Name = "cboFontSize";
            this.cboFontSize.Size = new System.Drawing.Size(57, 25);
            this.cboFontSize.ToolTipText = "字号";
            this.cboFontSize.DropDownClosed += new System.EventHandler(this.cboFontSize_DropDownClosed);
            this.cboFontSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboFontSize_KeyDown);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBold
            // 
            this.btnBold.CheckOnClick = true;
            this.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBold.Image = ((System.Drawing.Image)(resources.GetObject("btnBold.Image")));
            this.btnBold.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(23, 22);
            this.btnBold.ToolTipText = "粗体";
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.CheckOnClick = true;
            this.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItalic.Image = ((System.Drawing.Image)(resources.GetObject("btnItalic.Image")));
            this.btnItalic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(23, 22);
            this.btnItalic.ToolTipText = "斜体";
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnUnderLine
            // 
            this.btnUnderLine.CheckOnClick = true;
            this.btnUnderLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnderLine.Image = ((System.Drawing.Image)(resources.GetObject("btnUnderLine.Image")));
            this.btnUnderLine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUnderLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnderLine.Name = "btnUnderLine";
            this.btnUnderLine.Size = new System.Drawing.Size(23, 22);
            this.btnUnderLine.ToolTipText = "下划线";
            this.btnUnderLine.Click += new System.EventHandler(this.btnUnderLine_Click);
            // 
            // btnBackColor
            // 
            this.btnBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBackColor.Image = ((System.Drawing.Image)(resources.GetObject("btnBackColor.Image")));
            this.btnBackColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(23, 22);
            this.btnBackColor.ToolTipText = "背景色";
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // btnForeColor
            // 
            this.btnForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnForeColor.Image = ((System.Drawing.Image)(resources.GetObject("btnForeColor.Image")));
            this.btnForeColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnForeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(23, 22);
            this.btnForeColor.ToolTipText = "前景色";
            this.btnForeColor.Click += new System.EventHandler(this.btnForeColor_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // btnWordWrap
            // 
            this.btnWordWrap.CheckOnClick = true;
            this.btnWordWrap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnWordWrap.Image = ((System.Drawing.Image)(resources.GetObject("btnWordWrap.Image")));
            this.btnWordWrap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnWordWrap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWordWrap.Name = "btnWordWrap";
            this.btnWordWrap.Size = new System.Drawing.Size(23, 22);
            this.btnWordWrap.ToolTipText = "折行显示";
            this.btnWordWrap.Click += new System.EventHandler(this.btnWordWrap_Click);
            // 
            // btnAlignLeft
            // 
            this.btnAlignLeft.CheckOnClick = true;
            this.btnAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignLeft.Image")));
            this.btnAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignLeft.Name = "btnAlignLeft";
            this.btnAlignLeft.Size = new System.Drawing.Size(23, 22);
            this.btnAlignLeft.ToolTipText = "居左";
            this.btnAlignLeft.Click += new System.EventHandler(this.btnAlignLeft_Click);
            // 
            // btnAlignCenter
            // 
            this.btnAlignCenter.CheckOnClick = true;
            this.btnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignCenter.Image")));
            this.btnAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignCenter.Name = "btnAlignCenter";
            this.btnAlignCenter.Size = new System.Drawing.Size(23, 22);
            this.btnAlignCenter.ToolTipText = "居中";
            this.btnAlignCenter.Click += new System.EventHandler(this.btnAlignCenter_Click);
            // 
            // btnAlignRight
            // 
            this.btnAlignRight.CheckOnClick = true;
            this.btnAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignRight.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignRight.Image")));
            this.btnAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignRight.Name = "btnAlignRight";
            this.btnAlignRight.Size = new System.Drawing.Size(23, 22);
            this.btnAlignRight.ToolTipText = "居右";
            this.btnAlignRight.Click += new System.EventHandler(this.btnAlignRight_Click);
            // 
            // btnAlignTop
            // 
            this.btnAlignTop.CheckOnClick = true;
            this.btnAlignTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignTop.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignTop.Image")));
            this.btnAlignTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignTop.Name = "btnAlignTop";
            this.btnAlignTop.Size = new System.Drawing.Size(23, 22);
            this.btnAlignTop.ToolTipText = "居上";
            this.btnAlignTop.Click += new System.EventHandler(this.btnAlignTop_Click);
            // 
            // btnAlignMiddle
            // 
            this.btnAlignMiddle.CheckOnClick = true;
            this.btnAlignMiddle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignMiddle.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignMiddle.Image")));
            this.btnAlignMiddle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignMiddle.Name = "btnAlignMiddle";
            this.btnAlignMiddle.Size = new System.Drawing.Size(23, 22);
            this.btnAlignMiddle.ToolTipText = "垂直居中";
            this.btnAlignMiddle.Click += new System.EventHandler(this.btnAlignMiddle_Click);
            // 
            // btnAlignBottom
            // 
            this.btnAlignBottom.CheckOnClick = true;
            this.btnAlignBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignBottom.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignBottom.Image")));
            this.btnAlignBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignBottom.Name = "btnAlignBottom";
            this.btnAlignBottom.Size = new System.Drawing.Size(23, 22);
            this.btnAlignBottom.ToolTipText = "居下";
            this.btnAlignBottom.Click += new System.EventHandler(this.btnAlignBottom_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = false;
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(80, 22);
            // 
            // btnDrawBorder
            // 
            this.btnDrawBorder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDrawBorder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDrawBorder1,
            this.menuDrawBorder2,
            this.menuDrawBorder3,
            this.menuDrawBorder4,
            this.menuDrawBorder5,
            this.menuDrawBorder6,
            this.menuDrawBorder7,
            this.menuDrawBorder8});
            this.btnDrawBorder.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawBorder.Image")));
            this.btnDrawBorder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDrawBorder.Name = "btnDrawBorder";
            this.btnDrawBorder.Size = new System.Drawing.Size(32, 22);
            this.btnDrawBorder.Text = "toolStripButton1";
            this.btnDrawBorder.ToolTipText = "画网格线";
            this.btnDrawBorder.ButtonClick += new System.EventHandler(this.btnDrawBorder_ButtonClick);
            // 
            // menuDrawBorder1
            // 
            this.menuDrawBorder1.Name = "menuDrawBorder1";
            this.menuDrawBorder1.Size = new System.Drawing.Size(148, 22);
            this.menuDrawBorder1.Text = "画网格线";
            this.menuDrawBorder1.Click += new System.EventHandler(this.menuDrawBorder1_Click);
            // 
            // menuDrawBorder2
            // 
            this.menuDrawBorder2.Name = "menuDrawBorder2";
            this.menuDrawBorder2.Size = new System.Drawing.Size(148, 22);
            this.menuDrawBorder2.Text = "画框线";
            this.menuDrawBorder2.Click += new System.EventHandler(this.menuDrawBorder2_Click);
            // 
            // menuDrawBorder3
            // 
            this.menuDrawBorder3.Name = "menuDrawBorder3";
            this.menuDrawBorder3.Size = new System.Drawing.Size(148, 22);
            this.menuDrawBorder3.Text = "画单元格左线";
            this.menuDrawBorder3.Click += new System.EventHandler(this.menuDrawBorder3_Click);
            // 
            // menuDrawBorder4
            // 
            this.menuDrawBorder4.Name = "menuDrawBorder4";
            this.menuDrawBorder4.Size = new System.Drawing.Size(148, 22);
            this.menuDrawBorder4.Text = "画单元格右线";
            this.menuDrawBorder4.Click += new System.EventHandler(this.menuDrawBorder4_Click);
            // 
            // menuDrawBorder5
            // 
            this.menuDrawBorder5.Name = "menuDrawBorder5";
            this.menuDrawBorder5.Size = new System.Drawing.Size(148, 22);
            this.menuDrawBorder5.Text = "画单元格上线";
            this.menuDrawBorder5.Click += new System.EventHandler(this.menuDrawBorder5_Click);
            // 
            // menuDrawBorder6
            // 
            this.menuDrawBorder6.Name = "menuDrawBorder6";
            this.menuDrawBorder6.Size = new System.Drawing.Size(148, 22);
            this.menuDrawBorder6.Text = "画单元格下线";
            this.menuDrawBorder6.Click += new System.EventHandler(this.menuDrawBorder6_Click);
            // 
            // menuDrawBorder7
            // 
            this.menuDrawBorder7.Name = "menuDrawBorder7";
            this.menuDrawBorder7.Size = new System.Drawing.Size(148, 22);
            this.menuDrawBorder7.Text = "画正斜线";
            this.menuDrawBorder7.Click += new System.EventHandler(this.menuDrawBorder7_Click);
            // 
            // menuDrawBorder8
            // 
            this.menuDrawBorder8.Name = "menuDrawBorder8";
            this.menuDrawBorder8.Size = new System.Drawing.Size(148, 22);
            this.menuDrawBorder8.Text = "画反斜线";
            this.menuDrawBorder8.Click += new System.EventHandler(this.menuDrawBorder8_Click);
            // 
            // btnEraseBorder
            // 
            this.btnEraseBorder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEraseBorder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEraseBorder1,
            this.menuEraseBorder2,
            this.menuEraseBorder3,
            this.menuEraseBorder4,
            this.menuEraseBorder5,
            this.menuEraseBorder6,
            this.menuEraseBorder7,
            this.menuEraseBorder8});
            this.btnEraseBorder.Image = ((System.Drawing.Image)(resources.GetObject("btnEraseBorder.Image")));
            this.btnEraseBorder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEraseBorder.Name = "btnEraseBorder";
            this.btnEraseBorder.Size = new System.Drawing.Size(32, 22);
            this.btnEraseBorder.Text = "toolStripSplitButton1";
            this.btnEraseBorder.ToolTipText = "抹网格线";
            this.btnEraseBorder.ButtonClick += new System.EventHandler(this.btnEraseBorder_ButtonClick);
            // 
            // menuEraseBorder1
            // 
            this.menuEraseBorder1.Name = "menuEraseBorder1";
            this.menuEraseBorder1.Size = new System.Drawing.Size(148, 22);
            this.menuEraseBorder1.Text = "抹网格线";
            this.menuEraseBorder1.Click += new System.EventHandler(this.menuEraseBorder1_Click);
            // 
            // menuEraseBorder2
            // 
            this.menuEraseBorder2.Name = "menuEraseBorder2";
            this.menuEraseBorder2.Size = new System.Drawing.Size(148, 22);
            this.menuEraseBorder2.Text = "抹框线";
            this.menuEraseBorder2.Click += new System.EventHandler(this.menuEraseBorder2_Click);
            // 
            // menuEraseBorder3
            // 
            this.menuEraseBorder3.Name = "menuEraseBorder3";
            this.menuEraseBorder3.Size = new System.Drawing.Size(148, 22);
            this.menuEraseBorder3.Text = "抹单元格左线";
            this.menuEraseBorder3.Click += new System.EventHandler(this.menuEraseBorder3_Click);
            // 
            // menuEraseBorder4
            // 
            this.menuEraseBorder4.Name = "menuEraseBorder4";
            this.menuEraseBorder4.Size = new System.Drawing.Size(148, 22);
            this.menuEraseBorder4.Text = "抹单元格右线";
            this.menuEraseBorder4.Click += new System.EventHandler(this.menuEraseBorder4_Click);
            // 
            // menuEraseBorder5
            // 
            this.menuEraseBorder5.Name = "menuEraseBorder5";
            this.menuEraseBorder5.Size = new System.Drawing.Size(148, 22);
            this.menuEraseBorder5.Text = "抹单元格上线";
            this.menuEraseBorder5.Click += new System.EventHandler(this.menuEraseBorder5_Click);
            // 
            // menuEraseBorder6
            // 
            this.menuEraseBorder6.Name = "menuEraseBorder6";
            this.menuEraseBorder6.Size = new System.Drawing.Size(148, 22);
            this.menuEraseBorder6.Text = "抹单元格下线";
            this.menuEraseBorder6.Click += new System.EventHandler(this.menuEraseBorder6_Click);
            // 
            // menuEraseBorder7
            // 
            this.menuEraseBorder7.Name = "menuEraseBorder7";
            this.menuEraseBorder7.Size = new System.Drawing.Size(148, 22);
            this.menuEraseBorder7.Text = "抹正斜线";
            this.menuEraseBorder7.Click += new System.EventHandler(this.menuEraseBorder7_Click);
            // 
            // menuEraseBorder8
            // 
            this.menuEraseBorder8.Name = "menuEraseBorder8";
            this.menuEraseBorder8.Size = new System.Drawing.Size(148, 22);
            this.menuEraseBorder8.Text = "抹反斜线";
            this.menuEraseBorder8.Click += new System.EventHandler(this.menuEraseBorder8_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDrawTria,
            this.btnDrawCir});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "画符号";
            // 
            // btnDrawTria
            // 
            this.btnDrawTria.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawTria.Image")));
            this.btnDrawTria.Name = "btnDrawTria";
            this.btnDrawTria.Size = new System.Drawing.Size(112, 22);
            this.btnDrawTria.Text = "画三角";
            this.btnDrawTria.Click += new System.EventHandler(this.btnDrawTria_Click);
            // 
            // btnDrawCir
            // 
            this.btnDrawCir.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawCir.Image")));
            this.btnDrawCir.Name = "btnDrawCir";
            this.btnDrawCir.Size = new System.Drawing.Size(112, 22);
            this.btnDrawCir.Text = "画圆圈";
            this.btnDrawCir.Click += new System.EventHandler(this.btnDrawCir_Click);
            // 
            // ts_FH
            // 
            this.ts_FH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_FH.Image = ((System.Drawing.Image)(resources.GetObject("ts_FH.Image")));
            this.ts_FH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_FH.Name = "ts_FH";
            this.ts_FH.Size = new System.Drawing.Size(23, 21);
            this.ts_FH.Text = "×";
            this.ts_FH.Click += new System.EventHandler(this.ts_FH_Click);
            // 
            // ts_FH2
            // 
            this.ts_FH2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_FH2.Image = ((System.Drawing.Image)(resources.GetObject("ts_FH2.Image")));
            this.ts_FH2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_FH2.Name = "ts_FH2";
            this.ts_FH2.Size = new System.Drawing.Size(23, 21);
            this.ts_FH2.Text = "√";
            this.ts_FH2.Click += new System.EventHandler(this.ts_FH2_Click);
            // 
            // ts_FH3
            // 
            this.ts_FH3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_FH3.Image = ((System.Drawing.Image)(resources.GetObject("ts_FH3.Image")));
            this.ts_FH3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_FH3.Name = "ts_FH3";
            this.ts_FH3.Size = new System.Drawing.Size(23, 21);
            this.ts_FH3.Text = "○";
            this.ts_FH3.Click += new System.EventHandler(this.ts_FH3_Click);
            // 
            // tx_FH4
            // 
            this.tx_FH4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tx_FH4.Image = ((System.Drawing.Image)(resources.GetObject("tx_FH4.Image")));
            this.tx_FH4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tx_FH4.Name = "tx_FH4";
            this.tx_FH4.Size = new System.Drawing.Size(24, 21);
            this.tx_FH4.Text = "／";
            this.tx_FH4.Click += new System.EventHandler(this.tx_FH4_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSymbol
            // 
            this.btnSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSymbol.Image = ((System.Drawing.Image)(resources.GetObject("btnSymbol.Image")));
            this.btnSymbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSymbol.Name = "btnSymbol";
            this.btnSymbol.Size = new System.Drawing.Size(23, 20);
            this.btnSymbol.Text = "toolStripButton1";
            this.btnSymbol.ToolTipText = "插入特殊符号";
            this.btnSymbol.Click += new System.EventHandler(this.btnSymbol_Click);
            // 
            // btnInsertPic
            // 
            this.btnInsertPic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInsertPic.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertPic.Image")));
            this.btnInsertPic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInsertPic.Name = "btnInsertPic";
            this.btnInsertPic.Size = new System.Drawing.Size(23, 20);
            this.btnInsertPic.Text = "toolStripButton2";
            this.btnInsertPic.ToolTipText = "插入图片";
            this.btnInsertPic.Click += new System.EventHandler(this.btnInsertPic_Click);
            // 
            // ts_CellReadOnly
            // 
            this.ts_CellReadOnly.Image = global::ERM.UI.Properties.Resources.ReadOnly;
            this.ts_CellReadOnly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_CellReadOnly.Name = "ts_CellReadOnly";
            this.ts_CellReadOnly.Size = new System.Drawing.Size(23, 20);
            this.ts_CellReadOnly.ToolTipText = "设置只读";
            this.ts_CellReadOnly.Click += new System.EventHandler(this.ts_CellReadOnly_Click);
            // 
            // btnHideArchive
            // 
            this.btnHideArchive.Image = ((System.Drawing.Image)(resources.GetObject("btnHideArchive.Image")));
            this.btnHideArchive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnHideArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHideArchive.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnHideArchive.Name = "btnHideArchive";
            this.btnHideArchive.Size = new System.Drawing.Size(60, 36);
            this.btnHideArchive.Text = "显示目录";
            this.btnHideArchive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHideArchive.ToolTipText = "显示目录";
            this.btnHideArchive.Click += new System.EventHandler(this.btnHideArchive_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 40);
            // 
            // btnCopyFile
            // 
            this.btnCopyFile.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyFile.Image")));
            this.btnCopyFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCopyFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyFile.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCopyFile.Name = "btnCopyFile";
            this.btnCopyFile.Size = new System.Drawing.Size(60, 36);
            this.btnCopyFile.Text = "快速复制";
            this.btnCopyFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCopyFile.Click += new System.EventHandler(this.btnCopyFile_Click);
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDelete.Image")));
            this.tsbtnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(60, 36);
            this.tsbtnDelete.Text = "删除表格";
            this.tsbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnDelete.ToolTipText = "删除表格";
            this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
            // 
            // toolStripSeparator31
            // 
            this.toolStripSeparator31.Name = "toolStripSeparator31";
            this.toolStripSeparator31.Size = new System.Drawing.Size(6, 40);
            // 
            // btnStat_fb
            // 
            this.btnStat_fb.Image = ((System.Drawing.Image)(resources.GetObject("btnStat_fb.Image")));
            this.btnStat_fb.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStat_fb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStat_fb.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnStat_fb.Name = "btnStat_fb";
            this.btnStat_fb.Size = new System.Drawing.Size(60, 36);
            this.btnStat_fb.Text = "分部汇总";
            this.btnStat_fb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStat_fb.Visible = false;
            // 
            // btnStat_fx
            // 
            this.btnStat_fx.Image = ((System.Drawing.Image)(resources.GetObject("btnStat_fx.Image")));
            this.btnStat_fx.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStat_fx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStat_fx.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnStat_fx.Name = "btnStat_fx";
            this.btnStat_fx.Size = new System.Drawing.Size(60, 36);
            this.btnStat_fx.Text = "分项汇总";
            this.btnStat_fx.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStat_fx.Visible = false;
            // 
            // toolStripSeparator36
            // 
            this.toolStripSeparator36.Name = "toolStripSeparator36";
            this.toolStripSeparator36.Size = new System.Drawing.Size(6, 40);
            this.toolStripSeparator36.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 36);
            this.btnClose.Text = "关闭";
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
            this.btnHideArchive,
            this.toolStripSeparator5,
            this.btn_InputTemplet,
            this.toolCopy,
            this.toolPaster,
            this.btnCopyFile,
            this.toolStripButtonModify,
            this.tsbtnDelete,
            this.btn_Imge,
            this.tsb_FL,
            this.toolStripSeparator31,
            this.toolStripButton2,
            this.tsb_SavaAndGd,
            this.btnStat_fb,
            this.btnStat_fx,
            this.toolStripSeparator36,
            this.btnClose});
            this.mainTool.Location = new System.Drawing.Point(4, 61);
            this.mainTool.Name = "mainTool";
            this.mainTool.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.mainTool.Size = new System.Drawing.Size(1022, 40);
            this.mainTool.SkinAllColor = true;
            this.mainTool.Stretch = true;
            this.mainTool.TabIndex = 4;
            this.mainTool.Text = "MyToolStrip1";
            this.mainTool.TitleAnamorphosis = true;
            this.mainTool.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.mainTool.TitleRadius = 4;
            this.mainTool.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // btn_InputTemplet
            // 
            this.btn_InputTemplet.Image = global::ERM.UI.Properties.Resources._08;
            this.btn_InputTemplet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_InputTemplet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_InputTemplet.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_InputTemplet.Name = "btn_InputTemplet";
            this.btn_InputTemplet.Size = new System.Drawing.Size(60, 36);
            this.btn_InputTemplet.Text = "引入模板";
            this.btn_InputTemplet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_InputTemplet.Click += new System.EventHandler(this.btn_InputTemplet_Click);
            // 
            // toolCopy
            // 
            this.toolCopy.Image = global::ERM.UI.Properties.Resources.scanbutton02;
            this.toolCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCopy.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.toolCopy.Name = "toolCopy";
            this.toolCopy.Size = new System.Drawing.Size(60, 36);
            this.toolCopy.Text = "复制表格";
            this.toolCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolCopy.Click += new System.EventHandler(this.toolCopy_Click);
            // 
            // toolPaster
            // 
            this.toolPaster.Image = global::ERM.UI.Properties.Resources.scanbutton014;
            this.toolPaster.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolPaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPaster.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.toolPaster.Name = "toolPaster";
            this.toolPaster.Size = new System.Drawing.Size(60, 36);
            this.toolPaster.Text = "粘贴表格";
            this.toolPaster.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolPaster.Click += new System.EventHandler(this.toolPaster_Click);
            // 
            // toolStripButtonModify
            // 
            this.toolStripButtonModify.Image = global::ERM.UI.Properties.Resources.CellEdit_CustomCell;
            this.toolStripButtonModify.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonModify.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.toolStripButtonModify.Name = "toolStripButtonModify";
            this.toolStripButtonModify.Size = new System.Drawing.Size(60, 36);
            this.toolStripButtonModify.Text = "修改表名";
            this.toolStripButtonModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonModify.ToolTipText = "修改表格";
            this.toolStripButtonModify.Click += new System.EventHandler(this.toolStripButtonModify_Click);
            // 
            // btn_Imge
            // 
            this.btn_Imge.AutoSize = false;
            this.btn_Imge.Image = global::ERM.UI.Properties.Resources._10;
            this.btn_Imge.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Imge.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_Imge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Imge.Name = "btn_Imge";
            this.btn_Imge.Size = new System.Drawing.Size(44, 44);
            this.btn_Imge.Text = "画 图";
            this.btn_Imge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Imge.Click += new System.EventHandler(this.btn_Imge_Click);
            // 
            // tsb_FL
            // 
            this.tsb_FL.AutoSize = false;
            this.tsb_FL.Image = global::ERM.UI.Properties.Resources.template_1_;
            this.tsb_FL.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb_FL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_FL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_FL.Name = "tsb_FL";
            this.tsb_FL.Size = new System.Drawing.Size(44, 44);
            this.tsb_FL.Text = "范例";
            this.tsb_FL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_FL.Click += new System.EventHandler(this.tsb_FL_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "保存";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolbtnSave_Click);
            // 
            // tsb_SavaAndGd
            // 
            this.tsb_SavaAndGd.Image = global::ERM.UI.Properties.Resources.CellEdit_CheckIn;
            this.tsb_SavaAndGd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_SavaAndGd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_SavaAndGd.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tsb_SavaAndGd.Name = "tsb_SavaAndGd";
            this.tsb_SavaAndGd.Size = new System.Drawing.Size(72, 36);
            this.tsb_SavaAndGd.Text = "保存并归档";
            this.tsb_SavaAndGd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_SavaAndGd.Click += new System.EventHandler(this.tsb_SavaAndGd_Click);
            // 
            // frmCellEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(1030, 697);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainTool);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "frmCellEdit";
            this.Text = "城市建设电子文件整理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmCellEdit_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.contextMenuCell.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.customPanel2.ResumeLayout(false);
            this.customPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolArchive.ResumeLayout(false);
            this.toolArchive.PerformLayout();
            this.toolArchiveTab.ResumeLayout(false);
            this.toolArchiveTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cell2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell1)).EndInit();
            this.toolCellAssitant.ResumeLayout(false);
            this.toolCellAssitant.PerformLayout();
            this.toolCellFormat.ResumeLayout(false);
            this.toolCellFormat.PerformLayout();
            this.mainTool.ResumeLayout(false);
            this.mainTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private TXStatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiPageSetup;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ERM.UI.CustomPanel customPanel2;
        private ERM.UI.MyToolStrip toolArchive;
        private ERM.UI.MyToolStrip toolArchiveTab;
        private System.Windows.Forms.ToolStripLabel tabArchive;
        private System.Windows.Forms.ToolStripButton imgHideArchive;
        private TXToolStrip toolCellAssitant;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private TXToolStrip toolCellFormat;
        private System.Windows.Forms.ToolStripComboBox cboFonts;
        private System.Windows.Forms.ToolStripComboBox cboFontSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripButton btnUnderLine;
        private System.Windows.Forms.ToolStripButton btnBackColor;
        private System.Windows.Forms.ToolStripButton btnForeColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton btnWordWrap;
        private System.Windows.Forms.ToolStripButton btnAlignLeft;
        private System.Windows.Forms.ToolStripButton btnAlignCenter;
        private System.Windows.Forms.ToolStripButton btnAlignRight;
        private System.Windows.Forms.ToolStripButton btnAlignTop;
        private System.Windows.Forms.ToolStripButton btnAlignMiddle;
        private System.Windows.Forms.ToolStripButton btnAlignBottom;
        private System.Windows.Forms.ToolStripMenuItem tsmiManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiHideArchive;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddCustomCell;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditNode;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton btnPrintpreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripButton btnCut;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton btnRow;
        private System.Windows.Forms.ToolStripButton btnCol;
        private System.Windows.Forms.ToolStripButton btnGridline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripButton btnMergeCell;
        private System.Windows.Forms.ToolStripButton btnUnmergeCell;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripComboBox cboZoom;
        private System.Windows.Forms.ToolStripButton btnInsertCol;
        private System.Windows.Forms.ToolStripButton btnInsertRow;
        private System.Windows.Forms.ToolStripButton btnDeleteCol;
        private System.Windows.Forms.ToolStripButton btnDeleteRow;
        private System.Windows.Forms.ToolStripLabel lblLine;
        private ERM.UI.ComboBoxEx cboLine;
        private System.Windows.Forms.ImageList imageBorder;
        private System.Windows.Forms.ToolStripSplitButton btnDrawBorder;
        private System.Windows.Forms.ToolStripMenuItem menuDrawBorder1;
        private System.Windows.Forms.ToolStripMenuItem menuDrawBorder2;
        private System.Windows.Forms.ToolStripMenuItem menuDrawBorder3;
        private System.Windows.Forms.ToolStripMenuItem menuDrawBorder4;
        private System.Windows.Forms.ToolStripMenuItem menuDrawBorder5;
        private System.Windows.Forms.ToolStripMenuItem menuDrawBorder6;
        private System.Windows.Forms.ToolStripSplitButton btnEraseBorder;
        private System.Windows.Forms.ToolStripMenuItem menuDrawBorder7;
        private System.Windows.Forms.ToolStripMenuItem menuDrawBorder8;
        private System.Windows.Forms.ToolStripMenuItem menuEraseBorder1;
        private System.Windows.Forms.ToolStripMenuItem menuEraseBorder2;
        private System.Windows.Forms.ToolStripMenuItem menuEraseBorder3;
        private System.Windows.Forms.ToolStripMenuItem menuEraseBorder4;
        private System.Windows.Forms.ToolStripMenuItem menuEraseBorder5;
        private System.Windows.Forms.ToolStripMenuItem menuEraseBorder6;
        private System.Windows.Forms.ToolStripMenuItem menuEraseBorder7;
        private System.Windows.Forms.ToolStripMenuItem menuEraseBorder8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton btnRndFill;
        private System.Windows.Forms.ToolStripButton btnSumH;
        private System.Windows.Forms.ToolStripButton btnSumV;
        private System.Windows.Forms.ToolStripButton btnSum;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripButton btnSymbol;
        private System.Windows.Forms.ToolStripButton btnInsertPic;
        private System.Windows.Forms.ToolStripMenuItem tsmiUndo;
        private System.Windows.Forms.ToolStripMenuItem tsmiRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripMenuItem tsmiCut;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrintPreview;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
        private System.Windows.Forms.ToolStripMenuItem tsmiFill;
        private System.Windows.Forms.ToolStripMenuItem tsmiSumSum;
        private System.Windows.Forms.ToolStripMenuItem tsmiRepeatFill;
        private System.Windows.Forms.ToolStripMenuItem tsmiRndFill;
        private System.Windows.Forms.ToolStripMenuItem tsmiSumH;
        private System.Windows.Forms.ToolStripMenuItem tsmiSumV;
        private System.Windows.Forms.ToolStripMenuItem tsmiSum;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator24;
        private System.Windows.Forms.ToolStripMenuItem tsmiSymbol;
        private System.Windows.Forms.ToolStripMenuItem tsmiInsertPic;
        private System.Windows.Forms.ToolStripMenuItem tsmiCellOption;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearText;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearFormat;
        private System.Windows.Forms.ToolStripMenuItem tsmiMergeCell;
        private System.Windows.Forms.ToolStripMenuItem tsmiUnmergeCell;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator27;
        private System.Windows.Forms.ToolStripMenuItem tsmiRepair;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAll;
        private System.Windows.Forms.ToolStripMenuItem menuReadOnly;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripMenuItem menuCut;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator25;
        private System.Windows.Forms.ToolStripMenuItem menuFill;
        private System.Windows.Forms.ToolStripMenuItem menuRepeatFill;
        private System.Windows.Forms.ToolStripMenuItem menuRndFill;
        private System.Windows.Forms.ToolStripMenuItem menuSumSum;
        private System.Windows.Forms.ToolStripMenuItem menuSumH;
        private System.Windows.Forms.ToolStripMenuItem menuSumV;
        private System.Windows.Forms.ToolStripMenuItem menuSum;
        private System.Windows.Forms.ToolStripMenuItem menuClear;
        private System.Windows.Forms.ToolStripMenuItem menuClearText;
        private System.Windows.Forms.ToolStripMenuItem menuClearImage;
        private System.Windows.Forms.ToolStripMenuItem menuClearFormat;
        private System.Windows.Forms.ToolStripMenuItem menuClearAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator26;
        private System.Windows.Forms.ToolStripMenuItem menuSymbol;
        private System.Windows.Forms.ToolStripMenuItem menuInsertPic;
        private System.Windows.Forms.ToolStripMenuItem menuMergeCell;
        private System.Windows.Forms.ToolStripMenuItem menuUnmergeCell;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator28;
        private System.Windows.Forms.ToolStripMenuItem menuRepair;
        private System.Windows.Forms.ToolStripMenuItem menuCellOption;
        private Skin_ContextStripEX contextMenuCell;
        private SkinMenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private AxCELL50Lib.AxCell Cell1;
        private AxCELL50Lib.AxCell Cell2;
        internal TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyFile;
        private System.Windows.Forms.ToolStripButton t1_Up;
        private System.Windows.Forms.ToolStripButton t1_Down;
        private System.Windows.Forms.ToolStripMenuItem tsmiAutoEval;
        private System.Windows.Forms.ToolStripMenuItem menuAutoEval;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem btnDrawTria;
        private System.Windows.Forms.ToolStripMenuItem btnDrawCir;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetAsTemplet;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiImportXls;
        //private System.Windows.Forms.ToolStripButton btnSetSize;
        private System.Windows.Forms.ToolStripMenuItem menuCellHeadInfo;
        private Skin_ContextStripEX contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuEditNode;
        private System.Windows.Forms.ToolStripMenuItem menuDelNode;
        private SkinPanelEX panel1;
        private System.Windows.Forms.ToolStripButton btnHideArchive;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnCopyFile;
        private System.Windows.Forms.ToolStripButton tsbtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator31;
        private System.Windows.Forms.ToolStripButton btnStat_fb;
        private System.Windows.Forms.ToolStripButton btnStat_fx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator36;
        private System.Windows.Forms.ToolStripButton btnClose;
        private Skin_ToolStripEX mainTool;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolPaster;
        private System.Windows.Forms.ToolStripButton toolCopy;
        private TXCheckBox checkBoxSelectAll;
        private SkinPanelEX panel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonModify;
        private System.Windows.Forms.ToolStripButton btn_InputTemplet;
        private System.Windows.Forms.ToolStripButton ts_CellReadOnly;
        private System.Windows.Forms.ToolStripMenuItem tsmiPageOption;
        private System.Windows.Forms.ToolStripMenuItem tsmiRndSelectFill;
        private System.Windows.Forms.ToolStripMenuItem menuRndSelectFill;
        private System.Windows.Forms.ToolStripMenuItem menuCellPageSet;
        private System.Windows.Forms.ToolStripMenuItem menuCellLine;
        private System.Windows.Forms.ToolStripMenuItem menu_wanggexian;
        private System.Windows.Forms.ToolStripMenuItem menu_kuangxian;
        private System.Windows.Forms.ToolStripMenuItem menu_leftline;
        private System.Windows.Forms.ToolStripMenuItem menu_rightline;
        private System.Windows.Forms.ToolStripMenuItem menu_topline;
        private System.Windows.Forms.ToolStripMenuItem menu_buttonline;
        private System.Windows.Forms.ToolStripMenuItem menu_zhengxian;
        private System.Windows.Forms.ToolStripMenuItem menu_fangxian;
        private System.Windows.Forms.ToolStripMenuItem menuClearCellLine;
        private System.Windows.Forms.ToolStripMenuItem menu_clearwgx;
        private System.Windows.Forms.ToolStripMenuItem menu_clearkx;
        private System.Windows.Forms.ToolStripMenuItem menu_clearleftline;
        private System.Windows.Forms.ToolStripMenuItem menu_clearrightline;
        private System.Windows.Forms.ToolStripMenuItem menu_cleartopline;
        private System.Windows.Forms.ToolStripMenuItem menu_clearbuttonline;
        private System.Windows.Forms.ToolStripMenuItem menu_clearzxx;
        private System.Windows.Forms.ToolStripMenuItem menu_clearfxx;
        private System.Windows.Forms.ToolStripDropDownButton dro_CellFill;
        private System.Windows.Forms.ToolStripMenuItem tsm_AllFill;
        private System.Windows.Forms.ToolStripMenuItem tsm_SelectFill;
        private System.Windows.Forms.ToolStripMenuItem tsm_ReperFill;
        private System.Windows.Forms.ToolStripButton btn_Imge;
        private System.Windows.Forms.ToolStripMenuItem menuImge;
        private System.Windows.Forms.ToolStripButton tsb_SavaAndGd;
        private System.Windows.Forms.ToolStripButton ts_FH;
        private System.Windows.Forms.ToolStripButton ts_FH2;
        private System.Windows.Forms.ToolStripButton ts_FH3;
        private System.Windows.Forms.ToolStripButton tx_FH4;
        private System.Windows.Forms.ToolStripMenuItem tsm_TOFile;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Excel;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PDF;
        private System.Windows.Forms.ToolStripMenuItem tsmi_TOFile;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Excel1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PDF2;
        private System.Windows.Forms.ToolStripButton tsb_FL;

    }
}