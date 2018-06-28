using CCWin.SkinControl;
using ERM.UI.Controls;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmZJ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZJ));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStripArchive = new ERM.UI.Controls.Skin_ContextStripEX(this.components);
            this.tsPrintJNML = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPrintAJFM = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPrintBKB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExportJNML = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExportExcelArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoveOut = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.panelFull = new ERM.UI.Controls.SkinPanelEX();
            this.tabControl1 = new TX.Framework.WindowUI.Controls.TXTabControl();
            this.tabPage1 = new CCWin.SkinControl.SkinTabPage();
            this.groupBoxArrich = new ERM.UI.Controls.TXGroupEX();
            this.skinLabelEX3 = new ERM.UI.Controls.SkinLabelEX();
            this.txtbz = new ERM.UI.Controls.TXTextBoxEX();
            this.skinLabelEX2 = new ERM.UI.Controls.SkinLabelEX();
            this.txtOrderIndex = new ERM.UI.Controls.NumberTextBoxEX();
            this.skinLabelEX1 = new ERM.UI.Controls.SkinLabelEX();
            this.dptzlrq = new ERM.UI.DateTimeEx1(this.components);
            this.label38 = new ERM.UI.Controls.SkinLabelEX();
            this.cmbajlx = new ERM.UI.Controls.TXComboxEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.label17 = new ERM.UI.Controls.SkinLabelEX();
            this.label15 = new ERM.UI.Controls.SkinLabelEX();
            this.label14 = new ERM.UI.Controls.SkinLabelEX();
            this.cmbjhlx = new ERM.UI.Controls.TXComboxEX();
            this.cmbbgqx = new ERM.UI.Controls.TXComboxEX();
            this.cmbmj = new ERM.UI.Controls.TXComboxEX();
            this.cmbbzdw = new ERM.UI.Controls.TXComboxEX();
            this.txtajtm = new ERM.UI.Controls.TXTextBoxEX();
            this.label11 = new ERM.UI.Controls.SkinLabelEX();
            this.label3 = new ERM.UI.Controls.SkinLabelEX();
            this.label9 = new ERM.UI.Controls.SkinLabelEX();
            this.label8 = new ERM.UI.Controls.SkinLabelEX();
            this.txtLjr = new ERM.UI.Controls.TXTextBoxEX();
            this.label7 = new ERM.UI.Controls.SkinLabelEX();
            this.label5 = new ERM.UI.Controls.SkinLabelEX();
            this.tabPage2 = new CCWin.SkinControl.SkinTabPage();
            this.tabPage4 = new CCWin.SkinControl.SkinTabPage();
            this.panel2 = new ERM.UI.Controls.SkinPanelEX();
            this.gvFileList = new ERM.UI.Controls.Skin_DataGridEX();
            this.clm_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clm_FileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ArchiveIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Wjtm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ZRR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_wh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_stys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.btnPaste = new ERM.UI.Controls.SkinButtonEX();
            this.btnSave = new ERM.UI.Controls.SkinButtonEX();
            this.txtkssj = new ERM.UI.DateTimeEx(this.components);
            this.txtjssj = new ERM.UI.DateTimeEx(this.components);
            this.label36 = new ERM.UI.Controls.SkinLabelEX();
            this.label35 = new ERM.UI.Controls.SkinLabelEX();
            this.txtwjtm = new ERM.UI.Controls.TXTextBoxEX();
            this.label34 = new ERM.UI.Controls.SkinLabelEX();
            this.txtzrr = new ERM.UI.Controls.TXTextBoxEX();
            this.label32 = new ERM.UI.Controls.SkinLabelEX();
            this.lbArchiveManualCount = new ERM.UI.Controls.SkinLabelEX();
            this.lbArchiveName = new ERM.UI.Controls.SkinLabelEX();
            this.tabPage3 = new CCWin.SkinControl.SkinTabPage();
            this.axSPApplication1 = new AxiStylePDF.AxSPApplication();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelRight = new ERM.UI.Controls.SkinPanelEX();
            this.panelRightButton = new ERM.UI.Controls.SkinPanelEX();
            this.rightFileTree = new System.Windows.Forms.TreeView();
            this.panelRightTop = new ERM.UI.Controls.SkinPanelEX();
            this.tsRight = new ERM.UI.Controls.Skin_ToolStripEX();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.drpFileStatus = new System.Windows.Forms.ToolStripDropDownButton();
            this.drpFileStaus0 = new System.Windows.Forms.ToolStripMenuItem();
            this.drpFileStaus7 = new System.Windows.Forms.ToolStripMenuItem();
            this.drpFileStaus8 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelLeft = new ERM.UI.Controls.SkinPanelEX();
            this.panelLeftButton = new ERM.UI.Controls.SkinPanelEX();
            this.leftArchiveTree = new ERM.UI.Controls.TreeViewEX();
            this.panelLeftTop = new ERM.UI.Controls.SkinPanelEX();
            this.tsLeft = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tabArchive = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnDown = new System.Windows.Forms.ToolStripButton();
            this.tsbtnUp = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.miniToolStrip = new CCWin.SkinControl.SkinMenuStrip();
            this.menuStrip1 = new CCWin.SkinControl.SkinMenuStrip();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRightTree = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFinalfile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new ERM.UI.Controls.Skin_ToolStripEX();
            this.btnAddArchive = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteArchive = new System.Windows.Forms.ToolStripButton();
            this.btnMoveOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.myToolStrip1 = new ERM.UI.MyToolStrip();
            this.paneTop = new ERM.UI.Controls.SkinPanelEX();
            this.contextMenuStripArchive.SuspendLayout();
            this.panelFull.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxArrich.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFileList)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axSPApplication1)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelRightButton.SuspendLayout();
            this.panelRightTop.SuspendLayout();
            this.tsRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelLeftButton.SuspendLayout();
            this.panelLeftTop.SuspendLayout();
            this.tsLeft.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.paneTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripArchive
            // 
            this.contextMenuStripArchive.Arrow = System.Drawing.Color.Black;
            this.contextMenuStripArchive.Back = System.Drawing.Color.White;
            this.contextMenuStripArchive.BackRadius = 4;
            this.contextMenuStripArchive.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.contextMenuStripArchive.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.contextMenuStripArchive.Fore = System.Drawing.Color.Black;
            this.contextMenuStripArchive.HoverFore = System.Drawing.Color.Black;
            this.contextMenuStripArchive.ItemAnamorphosis = true;
            this.contextMenuStripArchive.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenuStripArchive.ItemBorderShow = true;
            this.contextMenuStripArchive.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenuStripArchive.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenuStripArchive.ItemRadius = 4;
            this.contextMenuStripArchive.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenuStripArchive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPrintJNML,
            this.tsPrintAJFM,
            this.tsPrintBKB,
            this.tsExportJNML,
            this.tsExportExcelArchive,
            this.DeleteArchive,
            this.menuMoveOut});
            this.contextMenuStripArchive.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenuStripArchive.Name = "contextMenuStripArchive";
            this.contextMenuStripArchive.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenuStripArchive.Size = new System.Drawing.Size(149, 158);
            this.contextMenuStripArchive.SkinAllColor = true;
            this.contextMenuStripArchive.Text = "添加";
            this.contextMenuStripArchive.TitleAnamorphosis = true;
            this.contextMenuStripArchive.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.contextMenuStripArchive.TitleRadius = 4;
            this.contextMenuStripArchive.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tsPrintJNML
            // 
            this.tsPrintJNML.Image = global::ERM.UI.Properties.Resources._19;
            this.tsPrintJNML.Name = "tsPrintJNML";
            this.tsPrintJNML.Size = new System.Drawing.Size(148, 22);
            this.tsPrintJNML.Text = "打印卷内目录";
            this.tsPrintJNML.Click += new System.EventHandler(this.tsPrintJNML_Click);
            // 
            // tsPrintAJFM
            // 
            this.tsPrintAJFM.Image = global::ERM.UI.Properties.Resources._19;
            this.tsPrintAJFM.Name = "tsPrintAJFM";
            this.tsPrintAJFM.Size = new System.Drawing.Size(148, 22);
            this.tsPrintAJFM.Text = "打印案卷封面";
            this.tsPrintAJFM.Click += new System.EventHandler(this.tsPrintAJFM_Click);
            // 
            // tsPrintBKB
            // 
            this.tsPrintBKB.Image = global::ERM.UI.Properties.Resources._19;
            this.tsPrintBKB.Name = "tsPrintBKB";
            this.tsPrintBKB.Size = new System.Drawing.Size(148, 22);
            this.tsPrintBKB.Text = "打印备考表";
            this.tsPrintBKB.Click += new System.EventHandler(this.tsPrintBKB_Click);
            // 
            // tsExportJNML
            // 
            this.tsExportJNML.Name = "tsExportJNML";
            this.tsExportJNML.Size = new System.Drawing.Size(148, 22);
            this.tsExportJNML.Text = "导出卷内目录";
            this.tsExportJNML.Click += new System.EventHandler(this.tsExportJNML_Click);
            // 
            // tsExportExcelArchive
            // 
            this.tsExportExcelArchive.Name = "tsExportExcelArchive";
            this.tsExportExcelArchive.Size = new System.Drawing.Size(148, 22);
            this.tsExportExcelArchive.Text = "导出案卷目录";
            this.tsExportExcelArchive.Click += new System.EventHandler(this.tsExportExcelArchive_Click);
            // 
            // DeleteArchive
            // 
            this.DeleteArchive.Name = "DeleteArchive";
            this.DeleteArchive.Size = new System.Drawing.Size(148, 22);
            this.DeleteArchive.Text = "删除案卷";
            this.DeleteArchive.Click += new System.EventHandler(this.DeleteArchive_Click);
            // 
            // menuMoveOut
            // 
            this.menuMoveOut.Name = "menuMoveOut";
            this.menuMoveOut.Size = new System.Drawing.Size(148, 22);
            this.menuMoveOut.Text = "移出文件";
            this.menuMoveOut.Click += new System.EventHandler(this.menuMoveOut_Click);
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
            // panelFull
            // 
            this.panelFull.AutoScroll = true;
            this.panelFull.BackColor = System.Drawing.Color.Transparent;
            this.panelFull.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelFull.Controls.Add(this.tabControl1);
            this.panelFull.Controls.Add(this.splitter2);
            this.panelFull.Controls.Add(this.splitter1);
            this.panelFull.Controls.Add(this.panelRight);
            this.panelFull.Controls.Add(this.panelLeft);
            this.panelFull.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFull.DownBack = null;
            this.panelFull.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.panelFull.Location = new System.Drawing.Point(4, 112);
            this.panelFull.MouseBack = null;
            this.panelFull.Name = "panelFull";
            this.panelFull.NormlBack = null;
            this.panelFull.Radius = 4;
            this.panelFull.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelFull.Size = new System.Drawing.Size(1352, 621);
            this.panelFull.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.BaseTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabControl1.BorderColor = System.Drawing.Color.Gainsboro;
            this.tabControl1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.CheckedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tabControl1.HeightLightTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.tabControl1.ImageList = this.imgList;
            this.tabControl1.Location = new System.Drawing.Point(256, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 621);
            this.tabControl1.TabCornerRadius = 3;
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.tabPage1.Controls.Add(this.groupBoxArrich);
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.ImageIndex = 1;
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 588);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.TabItemImage = null;
            this.tabPage1.Text = "案卷信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxArrich
            // 
            this.groupBoxArrich.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxArrich.BorderColor = System.Drawing.Color.Gainsboro;
            this.groupBoxArrich.CaptionColor = System.Drawing.Color.Black;
            this.groupBoxArrich.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxArrich.Controls.Add(this.skinLabelEX3);
            this.groupBoxArrich.Controls.Add(this.txtbz);
            this.groupBoxArrich.Controls.Add(this.skinLabelEX2);
            this.groupBoxArrich.Controls.Add(this.txtOrderIndex);
            this.groupBoxArrich.Controls.Add(this.skinLabelEX1);
            this.groupBoxArrich.Controls.Add(this.dptzlrq);
            this.groupBoxArrich.Controls.Add(this.label38);
            this.groupBoxArrich.Controls.Add(this.cmbajlx);
            this.groupBoxArrich.Controls.Add(this.label1);
            this.groupBoxArrich.Controls.Add(this.label17);
            this.groupBoxArrich.Controls.Add(this.label15);
            this.groupBoxArrich.Controls.Add(this.label14);
            this.groupBoxArrich.Controls.Add(this.cmbjhlx);
            this.groupBoxArrich.Controls.Add(this.cmbbgqx);
            this.groupBoxArrich.Controls.Add(this.cmbmj);
            this.groupBoxArrich.Controls.Add(this.cmbbzdw);
            this.groupBoxArrich.Controls.Add(this.txtajtm);
            this.groupBoxArrich.Controls.Add(this.label11);
            this.groupBoxArrich.Controls.Add(this.label3);
            this.groupBoxArrich.Controls.Add(this.label9);
            this.groupBoxArrich.Controls.Add(this.label8);
            this.groupBoxArrich.Controls.Add(this.txtLjr);
            this.groupBoxArrich.Controls.Add(this.label7);
            this.groupBoxArrich.Controls.Add(this.label5);
            this.groupBoxArrich.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBoxArrich.ForeColor = System.Drawing.Color.Black;
            this.groupBoxArrich.Location = new System.Drawing.Point(3, 1);
            this.groupBoxArrich.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            this.groupBoxArrich.Name = "groupBoxArrich";
            this.groupBoxArrich.Size = new System.Drawing.Size(777, 587);
            this.groupBoxArrich.TabIndex = 86;
            this.groupBoxArrich.TabStop = false;
            this.groupBoxArrich.Text = "案卷级信息";
            this.groupBoxArrich.TextMargin = 6;
            // 
            // skinLabelEX3
            // 
            this.skinLabelEX3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX3.AutoSize = true;
            this.skinLabelEX3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX3.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabelEX3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX3.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX3.Location = new System.Drawing.Point(43, 188);
            this.skinLabelEX3.Name = "skinLabelEX3";
            this.skinLabelEX3.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX3.TabIndex = 114;
            this.skinLabelEX3.Text = "*";
            // 
            // txtbz
            // 
            this.txtbz.BackColor = System.Drawing.Color.Transparent;
            this.txtbz.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtbz.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtbz.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtbz.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtbz.Image = null;
            this.txtbz.ImageSize = new System.Drawing.Size(0, 0);
            this.txtbz.Location = new System.Drawing.Point(117, 386);
            this.txtbz.MaxLength = 20;
            this.txtbz.Multiline = true;
            this.txtbz.Name = "txtbz";
            this.txtbz.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtbz.PasswordChar = '\0';
            this.txtbz.Required = false;
            this.txtbz.Size = new System.Drawing.Size(633, 104);
            this.txtbz.TabIndex = 11;
            // 
            // skinLabelEX2
            // 
            this.skinLabelEX2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX2.AutoSize = true;
            this.skinLabelEX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX2.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabelEX2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX2.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX2.Location = new System.Drawing.Point(57, 391);
            this.skinLabelEX2.Name = "skinLabelEX2";
            this.skinLabelEX2.Size = new System.Drawing.Size(56, 17);
            this.skinLabelEX2.TabIndex = 113;
            this.skinLabelEX2.Text = "卷内备考";
            // 
            // txtOrderIndex
            // 
            this.txtOrderIndex.BackColor = System.Drawing.Color.Transparent;
            this.txtOrderIndex.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtOrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrderIndex.DecimalLength = 0;
            this.txtOrderIndex.Enabled = false;
            this.txtOrderIndex.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOrderIndex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOrderIndex.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtOrderIndex.Image = null;
            this.txtOrderIndex.ImageSize = new System.Drawing.Size(0, 0);
            this.txtOrderIndex.Location = new System.Drawing.Point(117, 345);
            this.txtOrderIndex.MaxValuelLength = 4;
            this.txtOrderIndex.Name = "txtOrderIndex";
            this.txtOrderIndex.PasswordChar = '\0';
            this.txtOrderIndex.Required = false;
            this.txtOrderIndex.ShowMsg = false;
            this.txtOrderIndex.Size = new System.Drawing.Size(633, 25);
            this.txtOrderIndex.TabIndex = 10;
            this.txtOrderIndex.Tag = "案卷序号不能为空,int";
            // 
            // skinLabelEX1
            // 
            this.skinLabelEX1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX1.AutoSize = true;
            this.skinLabelEX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabelEX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX1.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX1.Location = new System.Drawing.Point(57, 350);
            this.skinLabelEX1.Name = "skinLabelEX1";
            this.skinLabelEX1.Size = new System.Drawing.Size(56, 17);
            this.skinLabelEX1.TabIndex = 111;
            this.skinLabelEX1.Text = "案卷序号";
            // 
            // dptzlrq
            // 
            this.dptzlrq.BorderColor = System.Drawing.Color.Gainsboro;
            this.dptzlrq.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dptzlrq.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dptzlrq.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dptzlrq.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dptzlrq.Image = null;
            this.dptzlrq.ImageSize = new System.Drawing.Size(0, 0);
            this.dptzlrq.Location = new System.Drawing.Point(117, 184);
            this.dptzlrq.Name = "dptzlrq";
            this.dptzlrq.PasswordChar = '\0';
            this.dptzlrq.Required = false;
            this.dptzlrq.Size = new System.Drawing.Size(633, 25);
            this.dptzlrq.TabIndex = 6;
            this.dptzlrq.TextEx = "";
            this.dptzlrq.Leave += new System.EventHandler(this.dptzlrq_Leave);
            // 
            // label38
            // 
            this.label38.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.BorderColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(57, 188);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(56, 17);
            this.label38.TabIndex = 109;
            this.label38.Text = "编制日期";
            // 
            // cmbajlx
            // 
            this.cmbajlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbajlx.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmbajlx.FormattingEnabled = true;
            this.cmbajlx.Items.AddRange(new object[] {
            "文字",
            "图纸",
            "照片",
            "混合"});
            this.cmbajlx.Location = new System.Drawing.Point(117, 225);
            this.cmbajlx.Margin = new System.Windows.Forms.Padding(0);
            this.cmbajlx.MaxLength = 20;
            this.cmbajlx.Name = "cmbajlx";
            this.cmbajlx.Size = new System.Drawing.Size(633, 25);
            this.cmbajlx.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(58, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 94;
            this.label1.Text = "案卷类型";
            // 
            // label17
            // 
            this.label17.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label17.BorderColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(55, 152);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 17);
            this.label17.TabIndex = 92;
            this.label17.Text = "*";
            // 
            // label15
            // 
            this.label15.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label15.BorderColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(43, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 17);
            this.label15.TabIndex = 90;
            this.label15.Text = "*";
            // 
            // label14
            // 
            this.label14.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label14.BorderColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(43, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 17);
            this.label14.TabIndex = 88;
            this.label14.Text = "*";
            // 
            // cmbjhlx
            // 
            this.cmbjhlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbjhlx.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmbjhlx.FormattingEnabled = true;
            this.cmbjhlx.Location = new System.Drawing.Point(117, 107);
            this.cmbjhlx.MaxLength = 20;
            this.cmbjhlx.Name = "cmbjhlx";
            this.cmbjhlx.Size = new System.Drawing.Size(633, 25);
            this.cmbjhlx.TabIndex = 4;
            this.cmbjhlx.SelectedIndexChanged += new System.EventHandler(this.cmbjhlx_SelectedIndexChanged);
            // 
            // cmbbgqx
            // 
            this.cmbbgqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbgqx.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmbbgqx.FormattingEnabled = true;
            this.cmbbgqx.Items.AddRange(new object[] {
            "长期",
            "短期",
            "永久"});
            this.cmbbgqx.Location = new System.Drawing.Point(117, 264);
            this.cmbbgqx.MaxLength = 20;
            this.cmbbgqx.Name = "cmbbgqx";
            this.cmbbgqx.Size = new System.Drawing.Size(633, 25);
            this.cmbbgqx.TabIndex = 8;
            // 
            // cmbmj
            // 
            this.cmbmj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmj.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbmj.FormattingEnabled = true;
            this.cmbmj.Items.AddRange(new object[] {
            "内部",
            "秘密",
            "公开",
            "国内",
            "机密",
            "绝密"});
            this.cmbmj.Location = new System.Drawing.Point(117, 305);
            this.cmbmj.MaxLength = 20;
            this.cmbmj.Name = "cmbmj";
            this.cmbmj.Size = new System.Drawing.Size(633, 25);
            this.cmbmj.TabIndex = 9;
            // 
            // cmbbzdw
            // 
            this.cmbbzdw.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmbbzdw.FormattingEnabled = true;
            this.cmbbzdw.Location = new System.Drawing.Point(117, 69);
            this.cmbbzdw.MaxLength = 30;
            this.cmbbzdw.Name = "cmbbzdw";
            this.cmbbzdw.Size = new System.Drawing.Size(633, 25);
            this.cmbbzdw.TabIndex = 3;
            // 
            // txtajtm
            // 
            this.txtajtm.BackColor = System.Drawing.Color.Transparent;
            this.txtajtm.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtajtm.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtajtm.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtajtm.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtajtm.Image = null;
            this.txtajtm.ImageSize = new System.Drawing.Size(0, 0);
            this.txtajtm.Location = new System.Drawing.Point(117, 31);
            this.txtajtm.MaxLength = 30;
            this.txtajtm.Name = "txtajtm";
            this.txtajtm.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtajtm.PasswordChar = '\0';
            this.txtajtm.Required = false;
            this.txtajtm.Size = new System.Drawing.Size(633, 25);
            this.txtajtm.TabIndex = 2;
            this.txtajtm.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtajtm_MouseDoubleClick);
            // 
            // label11
            // 
            this.label11.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label11.BorderColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(58, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 17);
            this.label11.TabIndex = 78;
            this.label11.Text = "案卷题名";
            // 
            // label3
            // 
            this.label3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label3.BorderColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(58, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "编制单位";
            // 
            // label9
            // 
            this.label9.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label9.BorderColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(56, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 42;
            this.label9.Text = "保管期限";
            // 
            // label8
            // 
            this.label8.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label8.BorderColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(81, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "密级";
            // 
            // txtLjr
            // 
            this.txtLjr.BackColor = System.Drawing.Color.Transparent;
            this.txtLjr.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtLjr.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtLjr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLjr.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtLjr.Image = null;
            this.txtLjr.ImageSize = new System.Drawing.Size(0, 0);
            this.txtLjr.Location = new System.Drawing.Point(117, 145);
            this.txtLjr.MaxLength = 10;
            this.txtLjr.Name = "txtLjr";
            this.txtLjr.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtLjr.PasswordChar = '\0';
            this.txtLjr.Required = false;
            this.txtLjr.Size = new System.Drawing.Size(633, 25);
            this.txtLjr.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label7.BorderColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(68, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "立卷人";
            // 
            // label5
            // 
            this.label5.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label5.BorderColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(58, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "案卷厚度";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.tabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage2.ImageIndex = 2;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(782, 588);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.TabItemImage = null;
            this.tabPage2.Text = "单文件信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.tabPage4.Controls.Add(this.panel2);
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage4.ImageIndex = 2;
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(782, 588);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.TabItemImage = null;
            this.tabPage4.Text = "多文件信息";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.gvFileList);
            this.panel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.DownBack = null;
            this.panel2.Location = new System.Drawing.Point(0, 93);
            this.panel2.MouseBack = null;
            this.panel2.Name = "panel2";
            this.panel2.NormlBack = null;
            this.panel2.Radius = 4;
            this.panel2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel2.Size = new System.Drawing.Size(782, 495);
            this.panel2.TabIndex = 1;
            // 
            // gvFileList
            // 
            this.gvFileList.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.gvFileList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvFileList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvFileList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvFileList.BackgroundColor = System.Drawing.Color.White;
            this.gvFileList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvFileList.ColumnFont = null;
            this.gvFileList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvFileList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvFileList.ColumnHeadersHeight = 26;
            this.gvFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_Select,
            this.clm_FileID,
            this.clm_ArchiveIndex,
            this.clm_Wjtm,
            this.clm_ZRR,
            this.clm_wh,
            this.clm_CreateDate,
            this.clm_sl,
            this.clm_stys});
            this.gvFileList.ColumnSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            this.gvFileList.ColumnSelectForeColor = System.Drawing.Color.Black;
            this.gvFileList.DefaultCellBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvFileList.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvFileList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvFileList.EnableHeadersVisualStyles = false;
            this.gvFileList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvFileList.GridColor = System.Drawing.Color.Gainsboro;
            this.gvFileList.HeadFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvFileList.HeadSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.gvFileList.HeadSelectForeColor = System.Drawing.SystemColors.ControlText;
            this.gvFileList.LineNumberForeColor = System.Drawing.Color.Black;
            this.gvFileList.Location = new System.Drawing.Point(0, 0);
            this.gvFileList.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.gvFileList.MultiSelect = false;
            this.gvFileList.Name = "gvFileList";
            this.gvFileList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gvFileList.RowHeadersVisible = false;
            this.gvFileList.RowHeadersWidth = 22;
            this.gvFileList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.gvFileList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gvFileList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gvFileList.RowTemplate.Height = 25;
            this.gvFileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFileList.Size = new System.Drawing.Size(782, 495);
            this.gvFileList.SkinGridColor = System.Drawing.Color.Gainsboro;
            this.gvFileList.TabIndex = 0;
            this.gvFileList.TitleBack = null;
            this.gvFileList.TitleBackColorBegin = System.Drawing.Color.White;
            this.gvFileList.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.gvFileList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvFileList_CellValidating);
            this.gvFileList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvFileList_ColumnHeaderMouseClick);
            // 
            // clm_Select
            // 
            this.clm_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clm_Select.HeaderText = "全选";
            this.clm_Select.Name = "clm_Select";
            this.clm_Select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clm_Select.Width = 44;
            // 
            // clm_FileID
            // 
            this.clm_FileID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clm_FileID.HeaderText = "id";
            this.clm_FileID.Name = "clm_FileID";
            this.clm_FileID.ReadOnly = true;
            this.clm_FileID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clm_FileID.Visible = false;
            // 
            // clm_ArchiveIndex
            // 
            this.clm_ArchiveIndex.FillWeight = 83.47712F;
            this.clm_ArchiveIndex.HeaderText = "序号";
            this.clm_ArchiveIndex.MaxInputLength = 2;
            this.clm_ArchiveIndex.Name = "clm_ArchiveIndex";
            this.clm_ArchiveIndex.ReadOnly = true;
            this.clm_ArchiveIndex.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clm_Wjtm
            // 
            this.clm_Wjtm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clm_Wjtm.FillWeight = 83.47712F;
            this.clm_Wjtm.HeaderText = "文件题名";
            this.clm_Wjtm.MaxInputLength = 200;
            this.clm_Wjtm.Name = "clm_Wjtm";
            // 
            // clm_ZRR
            // 
            this.clm_ZRR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clm_ZRR.FillWeight = 83.47712F;
            this.clm_ZRR.HeaderText = "责任者";
            this.clm_ZRR.MaxInputLength = 50;
            this.clm_ZRR.Name = "clm_ZRR";
            // 
            // clm_wh
            // 
            this.clm_wh.FillWeight = 83.47712F;
            this.clm_wh.HeaderText = "文(图)号";
            this.clm_wh.Name = "clm_wh";
            // 
            // clm_CreateDate
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.clm_CreateDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.clm_CreateDate.FillWeight = 202.6144F;
            this.clm_CreateDate.HeaderText = "形成日期";
            this.clm_CreateDate.Name = "clm_CreateDate";
            this.clm_CreateDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clm_sl
            // 
            this.clm_sl.FillWeight = 83.47712F;
            this.clm_sl.HeaderText = "上传页数";
            this.clm_sl.MaxInputLength = 4;
            this.clm_sl.Name = "clm_sl";
            // 
            // clm_stys
            // 
            this.clm_stys.HeaderText = "实体页数";
            this.clm_stys.Name = "clm_stys";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnPaste);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtkssj);
            this.panel1.Controls.Add(this.txtjssj);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.txtwjtm);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.txtzrr);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.lbArchiveManualCount);
            this.panel1.Controls.Add(this.lbArchiveName);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(782, 93);
            this.panel1.TabIndex = 0;
            // 
            // btnPaste
            // 
            this.btnPaste.BackColor = System.Drawing.Color.Transparent;
            this.btnPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPaste.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnPaste.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnPaste.BorderColor = System.Drawing.Color.Transparent;
            this.btnPaste.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnPaste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaste.DownBack = null;
            this.btnPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaste.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnPaste.ForeColor = System.Drawing.Color.Black;
            this.btnPaste.GlowColor = System.Drawing.Color.Transparent;
            this.btnPaste.InnerBorderColor = System.Drawing.Color.White;
            this.btnPaste.Location = new System.Drawing.Point(702, 53);
            this.btnPaste.Margin = new System.Windows.Forms.Padding(0);
            this.btnPaste.MouseBack = null;
            this.btnPaste.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.NormlBack = null;
            this.btnPaste.Palace = true;
            this.btnPaste.Radius = 10;
            this.btnPaste.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnPaste.Size = new System.Drawing.Size(70, 28);
            this.btnPaste.TabIndex = 18;
            this.btnPaste.TabStop = false;
            this.btnPaste.Text = "批量粘贴";
            this.btnPaste.UseVisualStyleBackColor = false;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
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
            this.btnSave.Location = new System.Drawing.Point(702, 17);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MouseBack = null;
            this.btnSave.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnSave.Name = "btnSave";
            this.btnSave.NormlBack = null;
            this.btnSave.Palace = true;
            this.btnSave.Radius = 10;
            this.btnSave.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSave.Size = new System.Drawing.Size(70, 28);
            this.btnSave.TabIndex = 17;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "批量保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtkssj
            // 
            this.txtkssj.BackColor = System.Drawing.SystemColors.Window;
            this.txtkssj.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtkssj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtkssj.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtkssj.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtkssj.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtkssj.Image = null;
            this.txtkssj.ImageSize = new System.Drawing.Size(0, 0);
            this.txtkssj.Location = new System.Drawing.Point(577, 19);
            this.txtkssj.Name = "txtkssj";
            this.txtkssj.PasswordChar = '\0';
            this.txtkssj.Required = false;
            this.txtkssj.Size = new System.Drawing.Size(120, 23);
            this.txtkssj.TabIndex = 13;
            this.txtkssj.TextEx = "";
            this.txtkssj.Leave += new System.EventHandler(this.txtkssj_Leave);
            // 
            // txtjssj
            // 
            this.txtjssj.BackColor = System.Drawing.SystemColors.Window;
            this.txtjssj.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtjssj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtjssj.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjssj.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtjssj.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtjssj.Image = null;
            this.txtjssj.ImageSize = new System.Drawing.Size(0, 0);
            this.txtjssj.Location = new System.Drawing.Point(577, 55);
            this.txtjssj.Name = "txtjssj";
            this.txtjssj.PasswordChar = '\0';
            this.txtjssj.Required = false;
            this.txtjssj.Size = new System.Drawing.Size(120, 23);
            this.txtjssj.TabIndex = 15;
            this.txtjssj.TextEx = "";
            this.txtjssj.Leave += new System.EventHandler(this.txtjssj_Leave);
            // 
            // label36
            // 
            this.label36.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label36.BorderColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label36.ForeColor = System.Drawing.Color.Black;
            this.label36.Location = new System.Drawing.Point(481, 56);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(92, 17);
            this.label36.TabIndex = 14;
            this.label36.Text = "形成结束时间：";
            // 
            // label35
            // 
            this.label35.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label35.BorderColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(481, 21);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(92, 17);
            this.label35.TabIndex = 13;
            this.label35.Text = "形成开始时间：";
            // 
            // txtwjtm
            // 
            this.txtwjtm.BackColor = System.Drawing.SystemColors.Window;
            this.txtwjtm.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtwjtm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtwjtm.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtwjtm.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtwjtm.Image = null;
            this.txtwjtm.ImageSize = new System.Drawing.Size(0, 0);
            this.txtwjtm.Location = new System.Drawing.Point(313, 19);
            this.txtwjtm.MaxLength = 20;
            this.txtwjtm.Name = "txtwjtm";
            this.txtwjtm.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtwjtm.PasswordChar = '\0';
            this.txtwjtm.Required = false;
            this.txtwjtm.Size = new System.Drawing.Size(162, 23);
            this.txtwjtm.TabIndex = 12;
            // 
            // label34
            // 
            this.label34.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label34.BorderColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(241, 21);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(68, 17);
            this.label34.TabIndex = 11;
            this.label34.Text = "文件题名：";
            // 
            // txtzrr
            // 
            this.txtzrr.BackColor = System.Drawing.SystemColors.Window;
            this.txtzrr.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtzrr.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzrr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtzrr.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtzrr.Image = null;
            this.txtzrr.ImageSize = new System.Drawing.Size(0, 0);
            this.txtzrr.Location = new System.Drawing.Point(313, 55);
            this.txtzrr.MaxLength = 20;
            this.txtzrr.Name = "txtzrr";
            this.txtzrr.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtzrr.PasswordChar = '\0';
            this.txtzrr.Required = false;
            this.txtzrr.Size = new System.Drawing.Size(162, 23);
            this.txtzrr.TabIndex = 14;
            // 
            // label32
            // 
            this.label32.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label32.BorderColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(253, 56);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(56, 17);
            this.label32.TabIndex = 8;
            this.label32.Text = "责任者：";
            // 
            // lbArchiveManualCount
            // 
            this.lbArchiveManualCount.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbArchiveManualCount.AutoSize = true;
            this.lbArchiveManualCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lbArchiveManualCount.BorderColor = System.Drawing.Color.Transparent;
            this.lbArchiveManualCount.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbArchiveManualCount.ForeColor = System.Drawing.Color.Black;
            this.lbArchiveManualCount.Location = new System.Drawing.Point(12, 56);
            this.lbArchiveManualCount.Name = "lbArchiveManualCount";
            this.lbArchiveManualCount.Size = new System.Drawing.Size(104, 17);
            this.lbArchiveManualCount.TabIndex = 7;
            this.lbArchiveManualCount.Text = "当前案卷总页数：";
            // 
            // lbArchiveName
            // 
            this.lbArchiveName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbArchiveName.AutoSize = true;
            this.lbArchiveName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lbArchiveName.BorderColor = System.Drawing.Color.Transparent;
            this.lbArchiveName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbArchiveName.ForeColor = System.Drawing.Color.Black;
            this.lbArchiveName.Location = new System.Drawing.Point(48, 21);
            this.lbArchiveName.Name = "lbArchiveName";
            this.lbArchiveName.Size = new System.Drawing.Size(68, 17);
            this.lbArchiveName.TabIndex = 0;
            this.lbArchiveName.Text = "当前案卷：";
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.tabPage3.Controls.Add(this.axSPApplication1);
            this.tabPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage3.ImageIndex = 3;
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(782, 588);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.TabItemImage = null;
            this.tabPage3.Text = "电子文件查看";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // axSPApplication1
            // 
            this.axSPApplication1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axSPApplication1.Enabled = true;
            this.axSPApplication1.Location = new System.Drawing.Point(3, 3);
            this.axSPApplication1.Name = "axSPApplication1";
            this.axSPApplication1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSPApplication1.OcxState")));
            this.axSPApplication1.Size = new System.Drawing.Size(776, 582);
            this.axSPApplication1.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.Control;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(1046, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 621);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Control;
            this.splitter1.Location = new System.Drawing.Point(253, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 621);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRight.Controls.Add(this.panelRightButton);
            this.panelRight.Controls.Add(this.panelRightTop);
            this.panelRight.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.DownBack = null;
            this.panelRight.Location = new System.Drawing.Point(1049, 0);
            this.panelRight.MouseBack = null;
            this.panelRight.Name = "panelRight";
            this.panelRight.NormlBack = null;
            this.panelRight.Radius = 4;
            this.panelRight.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelRight.Size = new System.Drawing.Size(303, 621);
            this.panelRight.TabIndex = 5;
            // 
            // panelRightButton
            // 
            this.panelRightButton.BackColor = System.Drawing.Color.Transparent;
            this.panelRightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRightButton.Controls.Add(this.rightFileTree);
            this.panelRightButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelRightButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightButton.DownBack = null;
            this.panelRightButton.Location = new System.Drawing.Point(0, 28);
            this.panelRightButton.MouseBack = null;
            this.panelRightButton.Name = "panelRightButton";
            this.panelRightButton.NormlBack = null;
            this.panelRightButton.Radius = 4;
            this.panelRightButton.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelRightButton.Size = new System.Drawing.Size(303, 593);
            this.panelRightButton.TabIndex = 2;
            // 
            // rightFileTree
            // 
            this.rightFileTree.AllowDrop = true;
            this.rightFileTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rightFileTree.CheckBoxes = true;
            this.rightFileTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightFileTree.HideSelection = false;
            this.rightFileTree.ItemHeight = 18;
            this.rightFileTree.Location = new System.Drawing.Point(0, 0);
            this.rightFileTree.Name = "rightFileTree";
            this.rightFileTree.Size = new System.Drawing.Size(303, 593);
            this.rightFileTree.TabIndex = 6;
            this.rightFileTree.TabStop = false;
            this.rightFileTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterCheck);
            this.rightFileTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trvFile_ItemDrag);
            this.rightFileTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvFile_AfterSelect);
            this.rightFileTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvFile_MouseDown);
            this.rightFileTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trviewArchive_MouseUp);
            // 
            // panelRightTop
            // 
            this.panelRightTop.BackColor = System.Drawing.Color.Transparent;
            this.panelRightTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRightTop.Controls.Add(this.tsRight);
            this.panelRightTop.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightTop.DownBack = null;
            this.panelRightTop.Location = new System.Drawing.Point(0, 0);
            this.panelRightTop.MouseBack = null;
            this.panelRightTop.Name = "panelRightTop";
            this.panelRightTop.NormlBack = null;
            this.panelRightTop.Radius = 4;
            this.panelRightTop.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelRightTop.Size = new System.Drawing.Size(303, 28);
            this.panelRightTop.TabIndex = 1;
            // 
            // tsRight
            // 
            this.tsRight.Arrow = System.Drawing.Color.Black;
            this.tsRight.AutoSize = false;
            this.tsRight.Back = System.Drawing.Color.White;
            this.tsRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.tsRight.BackgroundImage = global::ERM.UI.Properties.Resources.tit_bg;
            this.tsRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsRight.BackRadius = 4;
            this.tsRight.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.tsRight.Base = System.Drawing.Color.Empty;
            this.tsRight.BaseFore = System.Drawing.Color.Black;
            this.tsRight.BaseForeAnamorphosis = false;
            this.tsRight.BaseForeAnamorphosisBorder = 4;
            this.tsRight.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.tsRight.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.tsRight.BaseHoverFore = System.Drawing.Color.Black;
            this.tsRight.BaseItemAnamorphosis = true;
            this.tsRight.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsRight.BaseItemBorderShow = true;
            this.tsRight.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("tsRight.BaseItemDown")));
            this.tsRight.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsRight.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("tsRight.BaseItemMouse")));
            this.tsRight.BaseItemNorml = null;
            this.tsRight.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsRight.BaseItemRadius = 4;
            this.tsRight.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsRight.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsRight.BindTabControl = null;
            this.tsRight.CanOverflow = false;
            this.tsRight.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.tsRight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsRight.Fore = System.Drawing.Color.Black;
            this.tsRight.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsRight.HoverFore = System.Drawing.Color.Black;
            this.tsRight.ItemAnamorphosis = true;
            this.tsRight.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsRight.ItemBorderShow = true;
            this.tsRight.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsRight.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsRight.ItemRadius = 4;
            this.tsRight.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.drpFileStatus});
            this.tsRight.Location = new System.Drawing.Point(0, 0);
            this.tsRight.Name = "tsRight";
            this.tsRight.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsRight.Size = new System.Drawing.Size(303, 28);
            this.tsRight.SkinAllColor = true;
            this.tsRight.Stretch = true;
            this.tsRight.TabIndex = 8;
            this.tsRight.Text = "toolStrip2";
            this.tsRight.TitleAnamorphosis = true;
            this.tsRight.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.tsRight.TitleRadius = 4;
            this.tsRight.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.BackColor = System.Drawing.Color.Black;
            this.toolStripLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripLabel2.Image = global::ERM.UI.Properties.Resources.title_btnbg11;
            this.toolStripLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(8, 3, 0, 0);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripLabel2.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toolStripLabel2.RightToLeftAutoMirrorImage = true;
            this.toolStripLabel2.Size = new System.Drawing.Size(93, 25);
            this.toolStripLabel2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // drpFileStatus
            // 
            this.drpFileStatus.BackColor = System.Drawing.Color.White;
            this.drpFileStatus.BackgroundImage = global::ERM.UI.Properties.Resources.tit_bg;
            this.drpFileStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.drpFileStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drpFileStaus0,
            this.drpFileStaus7,
            this.drpFileStaus8});
            this.drpFileStatus.Image = ((System.Drawing.Image)(resources.GetObject("drpFileStatus.Image")));
            this.drpFileStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drpFileStatus.Name = "drpFileStatus";
            this.drpFileStatus.Size = new System.Drawing.Size(69, 25);
            this.drpFileStatus.Text = "数据过滤";
            // 
            // drpFileStaus0
            // 
            this.drpFileStaus0.BackColor = System.Drawing.Color.White;
            this.drpFileStaus0.Name = "drpFileStaus0";
            this.drpFileStaus0.Size = new System.Drawing.Size(160, 22);
            this.drpFileStaus0.Text = "全部";
            this.drpFileStaus0.Click += new System.EventHandler(this.drpFileStaus0_Click);
            // 
            // drpFileStaus7
            // 
            this.drpFileStaus7.BackColor = System.Drawing.Color.White;
            this.drpFileStaus7.Image = global::ERM.UI.Properties.Resources.tree_file;
            this.drpFileStaus7.Name = "drpFileStaus7";
            this.drpFileStaus7.Size = new System.Drawing.Size(160, 22);
            this.drpFileStaus7.Text = "系统登记文件";
            this.drpFileStaus7.Click += new System.EventHandler(this.drpFileStaus7_Click);
            // 
            // drpFileStaus8
            // 
            this.drpFileStaus8.BackColor = System.Drawing.Color.White;
            this.drpFileStaus8.Image = global::ERM.UI.Properties.Resources.tree_file;
            this.drpFileStaus8.Name = "drpFileStaus8";
            this.drpFileStaus8.Size = new System.Drawing.Size(160, 22);
            this.drpFileStaus8.Text = "自定义登记文件";
            this.drpFileStaus8.Click += new System.EventHandler(this.drpFileStaus8_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLeft.Controls.Add(this.panelLeftButton);
            this.panelLeft.Controls.Add(this.panelLeftTop);
            this.panelLeft.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.DownBack = null;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.MouseBack = null;
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.NormlBack = null;
            this.panelLeft.Radius = 4;
            this.panelLeft.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelLeft.Size = new System.Drawing.Size(253, 621);
            this.panelLeft.TabIndex = 4;
            // 
            // panelLeftButton
            // 
            this.panelLeftButton.AutoScroll = true;
            this.panelLeftButton.BackColor = System.Drawing.Color.Transparent;
            this.panelLeftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLeftButton.Controls.Add(this.leftArchiveTree);
            this.panelLeftButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelLeftButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftButton.DownBack = null;
            this.panelLeftButton.Location = new System.Drawing.Point(0, 28);
            this.panelLeftButton.MouseBack = null;
            this.panelLeftButton.Name = "panelLeftButton";
            this.panelLeftButton.NormlBack = null;
            this.panelLeftButton.Radius = 4;
            this.panelLeftButton.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelLeftButton.Size = new System.Drawing.Size(253, 623);
            this.panelLeftButton.TabIndex = 6;
            // 
            // leftArchiveTree
            // 
            this.leftArchiveTree.AllowDrop = true;
            this.leftArchiveTree.BorderColor = System.Drawing.Color.Gainsboro;
            this.leftArchiveTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.leftArchiveTree.CheckBoxes = true;
            this.leftArchiveTree.ContextMenuStrip = this.contextMenuStripArchive;
            this.leftArchiveTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftArchiveTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.leftArchiveTree.HideSelection = false;
            this.leftArchiveTree.ItemHeight = 18;
            this.leftArchiveTree.Location = new System.Drawing.Point(0, 0);
            this.leftArchiveTree.Name = "leftArchiveTree";
            this.leftArchiveTree.Size = new System.Drawing.Size(253, 623);
            this.leftArchiveTree.TabIndex = 6;
            this.leftArchiveTree.TabStop = false;
            this.leftArchiveTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterCheck);
            this.leftArchiveTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trviewArchive_ItemDrag);
            this.leftArchiveTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trviewArchive_AfterSelect);
            this.leftArchiveTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.trviewArchive_DragDrop);
            this.leftArchiveTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.trviewArchive_DragEnter);
            this.leftArchiveTree.DragOver += new System.Windows.Forms.DragEventHandler(this.trviewArchive_DragOver);
            this.leftArchiveTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trviewArchive_MouseDown);
            this.leftArchiveTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trviewArchive_MouseUp);
            // 
            // panelLeftTop
            // 
            this.panelLeftTop.BackColor = System.Drawing.Color.Transparent;
            this.panelLeftTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLeftTop.Controls.Add(this.tsLeft);
            this.panelLeftTop.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftTop.DownBack = null;
            this.panelLeftTop.Location = new System.Drawing.Point(0, 0);
            this.panelLeftTop.MouseBack = null;
            this.panelLeftTop.Name = "panelLeftTop";
            this.panelLeftTop.NormlBack = null;
            this.panelLeftTop.Radius = 4;
            this.panelLeftTop.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panelLeftTop.Size = new System.Drawing.Size(253, 28);
            this.panelLeftTop.TabIndex = 5;
            // 
            // tsLeft
            // 
            this.tsLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.tsLeft.BackgroundImage = global::ERM.UI.Properties.Resources.tit_bg;
            this.tsLeft.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tabArchive,
            this.tsbtnDown,
            this.tsbtnUp});
            this.tsLeft.Location = new System.Drawing.Point(0, 0);
            this.tsLeft.Name = "tsLeft";
            this.tsLeft.Size = new System.Drawing.Size(253, 26);
            this.tsLeft.TabIndex = 7;
            this.tsLeft.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 23);
            // 
            // tabArchive
            // 
            this.tabArchive.AutoSize = false;
            this.tabArchive.BackColor = System.Drawing.Color.DarkCyan;
            this.tabArchive.BackgroundImage = global::ERM.UI.Properties.Resources.title_btnbg1;
            this.tabArchive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tabArchive.Margin = new System.Windows.Forms.Padding(8, 3, 0, 0);
            this.tabArchive.Name = "tabArchive";
            this.tabArchive.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tabArchive.RightToLeftAutoMirrorImage = true;
            this.tabArchive.Size = new System.Drawing.Size(76, 23);
            this.tabArchive.Text = "已组卷目录";
            this.tabArchive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbtnDown
            // 
            this.tsbtnDown.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDown.Image")));
            this.tsbtnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDown.Name = "tsbtnDown";
            this.tsbtnDown.Size = new System.Drawing.Size(23, 23);
            this.tsbtnDown.Text = "向下移";
            this.tsbtnDown.ToolTipText = "向下移";
            this.tsbtnDown.Click += new System.EventHandler(this.tsbtnDown_Click);
            // 
            // tsbtnUp
            // 
            this.tsbtnUp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUp.Image")));
            this.tsbtnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUp.Name = "tsbtnUp";
            this.tsbtnUp.Size = new System.Drawing.Size(23, 23);
            this.tsbtnUp.Text = "向上移";
            this.tsbtnUp.ToolTipText = "向上移";
            this.tsbtnUp.Click += new System.EventHandler(this.tsbtnUp_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 10;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipTitle = "填写说明：";
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.Arrow = System.Drawing.Color.Black;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Back = System.Drawing.Color.White;
            this.miniToolStrip.BackgroundImage = global::ERM.UI.Properties.Resources.top;
            this.miniToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.miniToolStrip.BackRadius = 4;
            this.miniToolStrip.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.miniToolStrip.Base = System.Drawing.Color.Empty;
            this.miniToolStrip.BaseFore = System.Drawing.Color.Black;
            this.miniToolStrip.BaseForeAnamorphosis = false;
            this.miniToolStrip.BaseForeAnamorphosisBorder = 4;
            this.miniToolStrip.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.miniToolStrip.BaseHoverFore = System.Drawing.Color.Black;
            this.miniToolStrip.BaseItemAnamorphosis = true;
            this.miniToolStrip.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.miniToolStrip.BaseItemBorderShow = true;
            this.miniToolStrip.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("miniToolStrip.BaseItemDown")));
            this.miniToolStrip.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.miniToolStrip.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("miniToolStrip.BaseItemMouse")));
            this.miniToolStrip.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.miniToolStrip.BaseItemRadius = 4;
            this.miniToolStrip.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.miniToolStrip.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.miniToolStrip.Fore = System.Drawing.Color.Black;
            this.miniToolStrip.HoverFore = System.Drawing.Color.Black;
            this.miniToolStrip.ItemAnamorphosis = true;
            this.miniToolStrip.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.miniToolStrip.ItemBorderShow = true;
            this.miniToolStrip.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.miniToolStrip.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.miniToolStrip.ItemRadius = 4;
            this.miniToolStrip.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.miniToolStrip.Location = new System.Drawing.Point(95, 4);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.miniToolStrip.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.miniToolStrip.Size = new System.Drawing.Size(1240, 27);
            this.miniToolStrip.SkinAllColor = true;
            this.miniToolStrip.TabIndex = 0;
            this.miniToolStrip.TitleAnamorphosis = true;
            this.miniToolStrip.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.miniToolStrip.TitleRadius = 4;
            this.miniToolStrip.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Arrow = System.Drawing.Color.Black;
            this.menuStrip1.Back = System.Drawing.Color.White;
            this.menuStrip1.BackgroundImage = global::ERM.UI.Properties.Resources.top;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.BackRadius = 4;
            this.menuStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.menuStrip1.Base = System.Drawing.Color.Empty;
            this.menuStrip1.BaseFore = System.Drawing.Color.Black;
            this.menuStrip1.BaseForeAnamorphosis = false;
            this.menuStrip1.BaseForeAnamorphosisBorder = 4;
            this.menuStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.menuStrip1.BaseHoverFore = System.Drawing.Color.Black;
            this.menuStrip1.BaseItemAnamorphosis = true;
            this.menuStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.BaseItemBorderShow = true;
            this.menuStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BaseItemDown")));
            this.menuStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BaseItemMouse")));
            this.menuStrip1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.BaseItemRadius = 4;
            this.menuStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStrip1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menuStrip1.Fore = System.Drawing.Color.Black;
            this.menuStrip1.HoverFore = System.Drawing.Color.Black;
            this.menuStrip1.ItemAnamorphosis = true;
            this.menuStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.ItemBorderShow = true;
            this.menuStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.ItemRadius = 4;
            this.menuStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this.MenuItemEdit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
            this.menuStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStrip1.Size = new System.Drawing.Size(1352, 25);
            this.menuStrip1.SkinAllColor = true;
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.TitleAnamorphosis = true;
            this.menuStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.menuStrip1.TitleRadius = 4;
            this.menuStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClose});
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(44, 21);
            this.MenuItemFile.Text = "文件";
            // 
            // tsmiClose
            // 
            this.tsmiClose.Image = global::ERM.UI.Properties.Resources.anjuanico07;
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(100, 22);
            this.tsmiClose.Text = "关闭";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddArchive,
            this.tsmiDeleteArchive,
            this.tsmiMoveOut,
            this.toolStripSeparator1,
            this.tsmiRightTree,
            this.tsmiFinalfile});
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.Size = new System.Drawing.Size(44, 21);
            this.MenuItemEdit.Text = "编辑";
            // 
            // tsmiAddArchive
            // 
            this.tsmiAddArchive.Image = global::ERM.UI.Properties.Resources.anjuanico01;
            this.tsmiAddArchive.Name = "tsmiAddArchive";
            this.tsmiAddArchive.Size = new System.Drawing.Size(124, 22);
            this.tsmiAddArchive.Text = "添加案卷";
            this.tsmiAddArchive.Click += new System.EventHandler(this.tsmiAddArchive_Click);
            // 
            // tsmiDeleteArchive
            // 
            this.tsmiDeleteArchive.Image = global::ERM.UI.Properties.Resources.anjuanico02;
            this.tsmiDeleteArchive.Name = "tsmiDeleteArchive";
            this.tsmiDeleteArchive.Size = new System.Drawing.Size(124, 22);
            this.tsmiDeleteArchive.Text = "删除案卷";
            this.tsmiDeleteArchive.Click += new System.EventHandler(this.tsmiDeleteArchive_Click);
            // 
            // tsmiMoveOut
            // 
            this.tsmiMoveOut.Image = global::ERM.UI.Properties.Resources.anjuanico03;
            this.tsmiMoveOut.Name = "tsmiMoveOut";
            this.tsmiMoveOut.Size = new System.Drawing.Size(124, 22);
            this.tsmiMoveOut.Text = "移出文件";
            this.tsmiMoveOut.Click += new System.EventHandler(this.tsmiMoveOut_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // tsmiRightTree
            // 
            this.tsmiRightTree.Image = global::ERM.UI.Properties.Resources.anjuanico04;
            this.tsmiRightTree.Name = "tsmiRightTree";
            this.tsmiRightTree.Size = new System.Drawing.Size(124, 22);
            this.tsmiRightTree.Text = "归档目录";
            this.tsmiRightTree.Visible = false;
            // 
            // tsmiFinalfile
            // 
            this.tsmiFinalfile.Image = global::ERM.UI.Properties.Resources.anjuanico05;
            this.tsmiFinalfile.Name = "tsmiFinalfile";
            this.tsmiFinalfile.Size = new System.Drawing.Size(124, 22);
            this.tsmiFinalfile.Text = "电子文件";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Arrow = System.Drawing.Color.Black;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Back = System.Drawing.Color.White;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            this.toolStrip1.BackgroundImage = global::ERM.UI.Properties.Resources.about_bg;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.BackRadius = 4;
            this.toolStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.toolStrip1.Base = System.Drawing.Color.Empty;
            this.toolStrip1.BaseFore = System.Drawing.Color.Black;
            this.toolStrip1.BaseForeAnamorphosis = false;
            this.toolStrip1.BaseForeAnamorphosisBorder = 4;
            this.toolStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.toolStrip1.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.toolStrip1.BaseHoverFore = System.Drawing.Color.Black;
            this.toolStrip1.BaseItemAnamorphosis = true;
            this.toolStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolStrip1.BaseItemBorderShow = true;
            this.toolStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BaseItemDown")));
            this.toolStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BaseItemMouse")));
            this.toolStrip1.BaseItemNorml = null;
            this.toolStrip1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolStrip1.BaseItemRadius = 4;
            this.toolStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.toolStrip1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolStrip1.BindTabControl = null;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.toolStrip1.Fore = System.Drawing.Color.Black;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(5);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.HoverFore = System.Drawing.Color.Black;
            this.toolStrip1.ItemAnamorphosis = true;
            this.toolStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolStrip1.ItemBorderShow = true;
            this.toolStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.toolStrip1.ItemRadius = 4;
            this.toolStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddArchive,
            this.tsbtnSave,
            this.btnDeleteArchive,
            this.btnMoveOut,
            this.toolStripSeparator12,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1352, 53);
            this.toolStrip1.SkinAllColor = true;
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "刷新";
            this.toolStrip1.TitleAnamorphosis = true;
            this.toolStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            this.toolStrip1.TitleRadius = 4;
            this.toolStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // btnAddArchive
            // 
            this.btnAddArchive.Image = global::ERM.UI.Properties.Resources.anjuanico01;
            this.btnAddArchive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddArchive.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddArchive.Name = "btnAddArchive";
            this.btnAddArchive.Size = new System.Drawing.Size(60, 53);
            this.btnAddArchive.Text = "添加案卷";
            this.btnAddArchive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddArchive.Click += new System.EventHandler(this.btnAddArchive_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Margin = new System.Windows.Forms.Padding(0);
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(60, 53);
            this.tsbtnSave.Text = "保存案卷";
            this.tsbtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // btnDeleteArchive
            // 
            this.btnDeleteArchive.Image = global::ERM.UI.Properties.Resources.anjuanico02;
            this.btnDeleteArchive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeleteArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteArchive.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteArchive.Name = "btnDeleteArchive";
            this.btnDeleteArchive.Size = new System.Drawing.Size(60, 53);
            this.btnDeleteArchive.Text = "删除案卷";
            this.btnDeleteArchive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteArchive.Click += new System.EventHandler(this.btnDeleteArchive_Click);
            // 
            // btnMoveOut
            // 
            this.btnMoveOut.Image = global::ERM.UI.Properties.Resources.anjuanico03;
            this.btnMoveOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMoveOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveOut.Margin = new System.Windows.Forms.Padding(0);
            this.btnMoveOut.Name = "btnMoveOut";
            this.btnMoveOut.Size = new System.Drawing.Size(60, 53);
            this.btnMoveOut.Text = "移出文件";
            this.btnMoveOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMoveOut.Click += new System.EventHandler(this.btnMoveOut_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 53);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::ERM.UI.Properties.Resources.anjuanico07;
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 53);
            this.btnClose.Text = "关闭";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // myToolStrip1
            // 
            this.myToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(217)))), ((int)(((byte)(206)))));
            this.myToolStrip1.BackgroundImage = global::ERM.UI.Properties.Resources.tit_bg;
            this.myToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myToolStrip1.DrawBorder = true;
            this.myToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.myToolStrip1.Location = new System.Drawing.Point(0, 86);
            this.myToolStrip1.Name = "myToolStrip1";
            this.myToolStrip1.Size = new System.Drawing.Size(1771, 24);
            this.myToolStrip1.TabIndex = 3;
            this.myToolStrip1.Text = "myToolStrip1";
            this.myToolStrip1.Visible = false;
            // 
            // paneTop
            // 
            this.paneTop.BackColor = System.Drawing.Color.Transparent;
            this.paneTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paneTop.Controls.Add(this.myToolStrip1);
            this.paneTop.Controls.Add(this.toolStrip1);
            this.paneTop.Controls.Add(this.menuStrip1);
            this.paneTop.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.paneTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneTop.DownBack = null;
            this.paneTop.Location = new System.Drawing.Point(4, 34);
            this.paneTop.MouseBack = null;
            this.paneTop.Name = "paneTop";
            this.paneTop.NormlBack = null;
            this.paneTop.Radius = 4;
            this.paneTop.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.paneTop.Size = new System.Drawing.Size(1352, 78);
            this.paneTop.TabIndex = 4;
            // 
            // frmZJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(1360, 737);
            this.Controls.Add(this.panelFull);
            this.Controls.Add(this.paneTop);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.Name = "frmZJ";
            this.Text = "组卷";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSelectFiles_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmZJ_FormClosed);
            this.Load += new System.EventHandler(this.frmSelectFiles_Load);
            this.contextMenuStripArchive.ResumeLayout(false);
            this.panelFull.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxArrich.ResumeLayout(false);
            this.groupBoxArrich.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvFileList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axSPApplication1)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRightButton.ResumeLayout(false);
            this.panelRightTop.ResumeLayout(false);
            this.tsRight.ResumeLayout(false);
            this.tsRight.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeftButton.ResumeLayout(false);
            this.panelLeftTop.ResumeLayout(false);
            this.panelLeftTop.PerformLayout();
            this.tsLeft.ResumeLayout(false);
            this.tsLeft.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.paneTop.ResumeLayout(false);
            this.paneTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Skin_ContextStripEX contextMenuStripArchive;
        private System.Windows.Forms.ToolStripMenuItem DeleteArchive;
        private SkinPanelEX panelFull;
        private SkinPanelEX panelRight;
        private SkinPanelEX panelLeft;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem tsPrintJNML;
        private System.Windows.Forms.ToolStripMenuItem tsPrintAJFM;
        private SkinPanelEX panelLeftButton;
        private SkinPanelEX panelRightButton;
        private SkinPanelEX panelRightTop;
        private Skin_ToolStripEX tsRight;
        internal TreeView rightFileTree;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private TXGroupEX groupBoxArrich;
        private ERM.UI.Controls.SkinLabelEX label17;
        private ERM.UI.Controls.SkinLabelEX label15;
        private ERM.UI.Controls.SkinLabelEX label14;
        private TXComboxEX cmbjhlx;
        private TXComboxEX cmbbgqx;
        private TXComboxEX cmbmj;
        private TXComboxEX cmbbzdw;
        private ERM.UI.Controls.TXTextBoxEX txtajtm;
        private ERM.UI.Controls.SkinLabelEX label11;
        private ERM.UI.Controls.SkinLabelEX label3;
        private ERM.UI.Controls.SkinLabelEX label9;
        private ERM.UI.Controls.SkinLabelEX label8;
        private ERM.UI.Controls.TXTextBoxEX txtLjr;
        private ERM.UI.Controls.SkinLabelEX label7;
        private ERM.UI.Controls.SkinLabelEX label5;
        private FileRegistInfo ucFileInfo1;
        private System.Windows.Forms.ToolStripMenuItem menuMoveOut;
        private TXComboxEX cmbajlx;
        private ERM.UI.Controls.SkinLabelEX label1;
        private TXTabControl tabControl1;
        private SkinTabPage tabPage1;
        private SkinTabPage tabPage2;
        private SkinTabPage tabPage3;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolTip toolTip1;
        private AxiStylePDF.AxSPApplication axSPApplication1;
        private SkinTabPage tabPage4;
        private SkinPanelEX panel2;
        private Skin_DataGridEX gvFileList;
        private SkinPanelEX panel1;
        private ERM.UI.Controls.SkinLabelEX lbArchiveName;
        private ERM.UI.Controls.SkinLabelEX lbArchiveManualCount;
        private ERM.UI.Controls.SkinLabelEX label32;
        private ERM.UI.Controls.TXTextBoxEX txtzrr;
        private ERM.UI.Controls.TXTextBoxEX txtwjtm;
        private ERM.UI.Controls.SkinLabelEX label34;
        private ERM.UI.Controls.SkinLabelEX label36;
        private ERM.UI.Controls.SkinLabelEX label35;
        private DateTimeEx txtkssj;
        private DateTimeEx txtjssj;
        private System.Windows.Forms.ToolStripDropDownButton drpFileStatus;
        private System.Windows.Forms.ToolStripMenuItem drpFileStaus0;
        private System.Windows.Forms.ToolStripMenuItem drpFileStaus7;
        private System.Windows.Forms.ToolStripMenuItem drpFileStaus8;
        private System.Windows.Forms.ToolStripMenuItem tsPrintBKB;
        private System.Windows.Forms.ToolStripMenuItem tsExportExcelArchive;
        private System.Windows.Forms.ToolStripMenuItem tsExportJNML;
        private DateTimeEx1 dptzlrq;
        private ERM.UI.Controls.SkinLabelEX label38;
        private Controls.SkinButtonEX btnPaste;
        private Controls.SkinButtonEX btnSave;
        internal TreeViewEX leftArchiveTree;
        private SkinPanelEX panelLeftTop;
        private ToolStrip tsLeft;
        private ToolStripButton tsbtnDown;
        private ToolStripButton tsbtnUp;
        private SkinMenuStrip miniToolStrip;
        private SkinMenuStrip menuStrip1;
        private ToolStripMenuItem MenuItemFile;
        private ToolStripMenuItem tsmiClose;
        private ToolStripMenuItem MenuItemEdit;
        private ToolStripMenuItem tsmiAddArchive;
        private ToolStripMenuItem tsmiDeleteArchive;
        private ToolStripMenuItem tsmiMoveOut;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiRightTree;
        private ToolStripMenuItem tsmiFinalfile;
        private Skin_ToolStripEX toolStrip1;
        private ToolStripButton btnAddArchive;
        private ToolStripButton tsbtnSave;
        private ToolStripButton btnDeleteArchive;
        private ToolStripButton btnMoveOut;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton btnClose;
        private MyToolStrip myToolStrip1;
        private SkinPanelEX paneTop;
        private ToolStripLabel tabArchive;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private TXTextBoxEX txtbz;
        private SkinLabelEX skinLabelEX2;
        private NumberTextBoxEX txtOrderIndex;
        private SkinLabelEX skinLabelEX1;
        private SkinLabelEX skinLabelEX3;
        private DataGridViewCheckBoxColumn clm_Select;
        private DataGridViewTextBoxColumn clm_FileID;
        private DataGridViewTextBoxColumn clm_ArchiveIndex;
        private DataGridViewTextBoxColumn clm_Wjtm;
        private DataGridViewTextBoxColumn clm_ZRR;
        private DataGridViewTextBoxColumn clm_wh;
        private DataGridViewTextBoxColumn clm_CreateDate;
        private DataGridViewTextBoxColumn clm_sl;
        private DataGridViewTextBoxColumn clm_stys;
    }
}