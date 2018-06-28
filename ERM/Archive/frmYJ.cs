using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ERM.MDL;
using System.Xml;
using System.Reflection;
using ERM.BLL;
using ERM.UI.Common;
using ERM.UI.Common.XmlMapping;
using TX.Framework.WindowUI.Forms;
using System.Drawing;
using Stimulsoft.Report;
using Stimulsoft.Base;
using Stimulsoft.Base.Serializing;
using Stimulsoft.Base.Localization;
using Stimulsoft.Base.Drawing;
using Stimulsoft.Base.Services;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Export;
using Stimulsoft.Report.Render;
using Stimulsoft.Report.ReportControls;
using Stimulsoft.Report.Design;
using Stimulsoft.Report.Dictionary;
using System.IO;
using System.Drawing.Printing;
using System.Diagnostics;
using Spire.Pdf;
using Stimulsoft.Report.Viewer;


namespace ERM.UI
{
    public partial class frmYJ : ERM.UI.Controls.Skin_DevEX
    {
        StiReport Project_report = new StiReport();
        StiReport Archive_report = new StiReport();
        StiReport fileReport = new StiReport();
        Print_Common print_common = new Print_Common(Application.StartupPath);
        public static int x = 0;
        ERM.BLL.T_Archive_BLL FinalArchiveDB = new ERM.BLL.T_Archive_BLL();
        ERM.BLL.T_Projects_BLL ProjectsDB = new ERM.BLL.T_Projects_BLL();
        ERM.BLL.T_Item_BLL ItemDB = new ERM.BLL.T_Item_BLL();
        ERM.CBLL.FinalArchive CBFinalArchive = new ERM.CBLL.FinalArchive();
        ERM.BLL.T_FileList_BLL FinalFileDB = new ERM.BLL.T_FileList_BLL();
        ERM.CBLL.PrintFinalArchive finalArchive = new ERM.CBLL.PrintFinalArchive();
        private ProjectItemUnits projectFactory;
        private T_Projects project;
        private T_Item item;
        private IProjectXML projectXML;
        private string Spec = "EngHouseSpec";

        frmReport frmReports = null;
        public frmYJ()
        {
            InitializeComponent();

        }
        public frmYJ(Form parentForm)
        {
            InitializeComponent();
            this._parentForm = parentForm;
            projectFactory = new ProjectItemUnits(Globals.ProjectNO);
            this.stiArchive.Size = this.stiFile.Size = this.stiProject.Size;
            this.stiArchive.ShowZoomPageWidth = this.stiProject.ShowZoomPageWidth = this.stiFile.ShowZoomPageWidth = true;
            this.stiArchive.ShowFullScreen = this.stiProject.ShowFullScreen = this.stiFile.ShowFullScreen = false;
            _fileID = string.Empty;
            _archiveID = string.Empty;
        }
        private Form _parentForm;
        private void frmArchive_Load(object sender, EventArgs e)
        {
            this.Text = "移交 - " + Globals.Projectname;
            tssLabel1.Text = Globals.NormalStatus;              //就绪
            tssLabel2.Text = Globals.AppTitle;                  //应用程序标题
            tssLabel3.Text = "当前用户：" + Globals.LoginUser;  //当前用户
            LoadTree();
            project = ProjectsDB.Find(Globals.ProjectNO);

            if (project != null)
            {
                if (project.ProjectCategory.ToLower() != "buildding")
                {
                    Spec = "EngFacilitySpec";
                }
            }

            item = ItemDB.Find(project.ItemID);
            panelLeft.Width = Convert.ToInt16(Globals.TreeWidth);

            LoadProjectTemp(project.ProjectCategory);//加载工程级模板

            if (Convert.ToBoolean(Properties.Settings.Default.PrintYjml))
            {
                toolStripMenuItem3.Visible = true;
            }
        }
        private void frmArchive_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (axSPApplication1.Documents.ActiveDocument != null)
                axSPApplication1.Documents.CloseAll();

            this._parentForm.Show();　//显示父窗体
            this._parentForm.Activate();//激活父窗体
        }
        /// <summary>
        /// 从数据库读取整个树
        /// </summary>
        public void LoadTree()
        {
            this.treeArchive.Nodes.Clear();
            this.treeArchive.ImageList = this.imgList;
            TreeNode ProjectNode = new TreeNode();
            ProjectNode.Tag = Globals.ProjectNO;
            ProjectNode.Text = Globals.Projectname; //+ "组卷目录";
            ProjectNode.SelectedImageIndex = 0;
            ProjectNode.ImageIndex = 0;
            InitArchiveTree(Globals.ProjectNO, ProjectNode);
            treeArchive.Nodes.Add(ProjectNode);
            ProjectNode.Expand();
            treeArchive.SelectedNode = treeArchive.Nodes[0];
            this.tabGrade.SelectedIndex = 0;
            //if (treeArchive.Nodes[0].Nodes.Count > 0)
            //{
            //    //tsmiPrint_bkb_All.Enabled = true;//批量打印备考表
            //   // btnPrint_bkb_All.Enabled = true;
            //    //tsmiPrint_fengmian_All.Enabled = true;//批量打印封面
            //    //btnPrint_fengmian_All.Enabled = true;
            //    //tsmiPrint_jnml_All.Enabled = true;//批量打印卷内目录
            //    //btnPrint_jnml_All.Enabled = true;
            //}
            //else
            //{
            //    tsmiPrint_bkb_All.Enabled = false;//批量打印备考表
            //    btnPrint_bkb_All.Enabled = false;
            //    tsmiPrint_fengmian_All.Enabled = false;//批量打印封面
            //    btnPrint_fengmian_All.Enabled = false;
            //    tsmiPrint_jnml_All.Enabled = false;//批量打印卷内目录
            //    btnPrint_jnml_All.Enabled = false;
            //}
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsmiClose_Click(object sender, EventArgs e)
        {
            frmArchive_FormClosing(null, null);
        }
        /// <summary>
        ///  对树节点选项内容选中发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeArchive_AfterSelect(object sender, TreeViewEventArgs e)
        {
            setMenuPrint();
            TreeNode node = this.treeArchive.SelectedNode;
            if (node == null) return;
            int level = node.Level;
            tssLabel1.Text = Globals.WaitStatus;
            switch (level)
            {
                case 0:
                    this.tabGrade.SelectedIndex = 0;//工程级
                    break;
                case 1:
                    if (node.Level == 1)
                    {
                        this.tabGrade.SelectedIndex = 1;//案卷级
                        LoadArchiveData(node.Tag.ToString());
                    }
                    break;
                case 2:
                    if (node.Level == 2)
                    {
                        this.tabGrade.SelectedIndex = 2; //文件级
                        LoadFinal_file(node.Tag.ToString());
                        LoadEFileTemp(node.Tag.ToString());
                    }
                    break;
            }
            tssLabel1.Text = Globals.NormalStatus;
        }
        void setMenuPrint()
        {
            this.btnPrint1.Enabled = false;//封皮
            this.tsmiPrint1.Enabled = false;
            this.btnPrint2.Enabled = false;//卷内目录
            this.tsmiPrint2.Enabled = false;
            this.btnPrint3.Enabled = false;//备考表
            this.tsmiPrint3.Enabled = false;
            if (treeArchive.SelectedNode != null && treeArchive.SelectedNode.Level == 1)
            {
                this.btnPrint1.Enabled = true;//封皮
                this.tsmiPrint1.Enabled = true;
                this.btnPrint2.Enabled = true;//卷内目录
                this.tsmiPrint2.Enabled = true;
                this.btnPrint3.Enabled = true;//备考表
                this.tsmiPrint3.Enabled = true;
            }
        }
        /// <summary>
        /// 加载工程模板
        /// </summary>
        private void LoadProjectTemp(string projectTempType)
        {
            Project_report.Load(Application.StartupPath + @"\Reports\" + projectTempType + ".mrt");//加载报表  
            DataTable dt = CreateTable();
            Project_report.RegData("Project_report", dt.DefaultView);
            Project_report.Compile();
            Project_report.Render();
            stiProject.Report = Project_report;
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "GCReport";
            DataColumn dc;
            DataRow dr = dt.NewRow();

            foreach (var item in projectFactory.ProjectDetail.Keys)
            {
                dc = new DataColumn();
                dc.ColumnName = item.ToString();
                dt.Columns.Add(dc);
                dr[item.ToString()] = projectFactory.ProjectDetail[item.ToString()].ToString();
            }

            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 加载案卷报表
        /// </summary>
        static string _archiveID = string.Empty;
        private void LoadArchiveData(string archiveID)
        {
            if (_archiveID == archiveID)
            {
                return;
            }

            if (!this.tabGrade.TabPages.ContainsKey("tabArchive"))
            {
                if (this.tabGrade.Contains(tabFile))
                {
                    this.tabGrade.Controls.Remove(tabFile);
                    this.tabGrade.Controls.Remove(tabElecFile);
                    this.tabGrade.Controls.Add(this.tabArchive);
                    this.tabGrade.Controls.Add(tabFile);
                    this.tabGrade.Controls.Add(tabElecFile);
                }
                else
                {
                    this.tabGrade.Controls.Add(this.tabArchive);
                }

                this.tabGrade.SelectedTab = tabArchive;
            }

            _archiveID = archiveID;

            BLL.T_Archive_BLL archiveBLL = new ERM.BLL.T_Archive_BLL();
            DataView dv = archiveBLL.GetListByArchiveID(archiveID).Tables[0].DefaultView;
            Archive_report.Load(Application.StartupPath + @"\Reports\Archive.mrt");//加载报表  
            this.Archive_report.RegData("Archive_report", dv);
            Archive_report.Render();
            stiArchive.Report = Archive_report;
        }

        /// <summary>
        /// 加载文件
        /// </summary>
        /// <param name="fileID"></param>
        static string _fileID = string.Empty;
        private void LoadFinal_file(string fileID)
        {
            if (_fileID == fileID)
            {
                return;
            }

            if (!this.tabGrade.TabPages.ContainsKey("tabFile"))
            {
                this.tabGrade.Controls.Add(this.tabFile);
                this.tabGrade.SelectedTab = tabFile;
            }

            _fileID = fileID;
            fileReport.Load(Application.StartupPath + @"\Reports\File.mrt");
            MDL.T_FileList fileMDL = new T_FileList();
            fileMDL.FileID = fileID;
            fileMDL.ProjectNO = Globals.ProjectNO;
            DataView dv = FinalFileDB.GetList(fileMDL).Tables[0].DefaultView;

            fileReport.RegData("fileReport", dv);
            fileReport.Compile();
            fileReport.Render();
            stiFile.Report = fileReport;
        }

        private void LoadEFileTemp(string FileID)
        {
            ERM.MDL.T_FileList finalfile = FinalFileDB.Find(FileID, Globals.ProjectNO);
            if (finalfile != null)
            {
                string filepath = ConvertFile2PDF(FileID);//finalfile.filepath;
                try
                {
                    string MregeredPDFPath = Globals.ProjectPath + filepath;

                    if (!this.tabGrade.TabPages.ContainsKey("tabElecFile"))
                    {
                        this.tabGrade.Controls.Add(this.tabElecFile);
                    }

                    ShowPDF(MregeredPDFPath);
                }
                catch
                {
                    TXMessageBoxExtensions.Info("浏览控件出错！");
                }
            }
        }
        /// <summary>
        /// 归档移交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUploadSIP_Click(object sender, EventArgs e)
        {
            if (axSPApplication1.Documents.ActiveDocument != null)
                axSPApplication1.Documents.CloseAll();
            OpenNewForm op = new OpenNewForm();
            op.ShowOnce("ERM.UI.frmCreateSIP");
        }
        /// <summary>
        /// 添加案卷级信息
        /// </summary>
        /// <param name="ProjectNO">工程号</param>
        /// <param name="ProjectNode">工程节点</param>
        private void InitArchiveTree(String ProjectNO, TreeNode ProjectNode)
        {
            BLL.T_Archive_BLL archiveBLL = new ERM.BLL.T_Archive_BLL();
            IList<ERM.MDL.T_Archive> FinalArchives = archiveBLL.FindByProjectNO(ProjectNO);
            //BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            BLL.T_FileList_BLL FileList_BLL = new BLL.T_FileList_BLL();
            bool UpdateArchIndex_flg = false;
            if (FinalArchives.Count > 0)
            {
                foreach (T_Archive finalarchive in FinalArchives)
                {
                    if (!UpdateArchIndex_flg && finalarchive.OrderIndex == 0)
                        UpdateArchIndex_flg = true;

                    TreeNode nodeAjtm = new TreeNode();
                    nodeAjtm.Text = "["+finalarchive.OrderIndex+"]"+finalarchive.ajtm;
                    nodeAjtm.Tag = finalarchive.ArchiveID;
                    nodeAjtm.SelectedImageIndex = 1;
                    nodeAjtm.ImageIndex = 1;
                    nodeAjtm.Name = finalarchive.ArchiveID;
                    IList<MDL.T_FileList> cellList = FileList_BLL.FindByArchiveID2(finalarchive.ArchiveID, Globals.ProjectNO);
                    foreach (T_FileList obj2 in cellList)
                    {
                        TreeNode pdfNode = new TreeNode();
                        pdfNode.Text = obj2.wjtm;
                        pdfNode.Tag = obj2.FileID;
                        pdfNode.StateImageKey = obj2.filepath;
                        pdfNode.Name = obj2.FileID;
                        pdfNode.SelectedImageIndex = 2;
                        pdfNode.ImageIndex = 2;
                        nodeAjtm.Nodes.Add(pdfNode);
                    }
                    ProjectNode.Nodes.Add(nodeAjtm);
                }
            }
            if (UpdateArchIndex_flg)
                (new ERM.CBLL.FinalArchive()).MoveArchiveOrderindex(ProjectNode);//调整案卷顺序
        }

        private void tabGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode node = this.treeArchive.SelectedNode;
            if (node == null) return;
            int level = node.Level;
            if (node.Level == 2)//电子文件
            {
                if (tabGrade.SelectedIndex == 3)//电子文件
                {
                    TabIndex = 3;
                    LoadEFileTemp(node.Tag.ToString());
                }
                else if (tabGrade.SelectedIndex == 2)//文件登记
                {
                    TabIndex = 2;
                    LoadFinal_file(node.Tag.ToString());
                }
            }
            else//不是文件的时候
            {
                if (tabGrade.SelectedIndex == 3)//如果是电子文件
                {
                    //if (axpdfInterface1.FileName != null && axpdfInterface1.FileName.Length > 0)
                    //    axpdfInterface1.CloseFile();
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                }
            }
        }
        private void btnSArchiveVisible_Click(object sender, EventArgs e)
        {
            if (panelLeft.Visible)
            {
                panelLeft.Visible = false;
                btnSArchiveVisible.Text = "显示案卷列表";
            }
            else
            {
                panelLeft.Visible = true;
                btnSArchiveVisible.Text = "隐藏案卷列表";
            }
        }
        private void tsButClose_Click(object sender, EventArgs e)
        {
            panelLeft.Visible = false;
        }
        private void btnPrint1_Click(object sender, EventArgs e)
        {
            TreeNode theNode = treeArchive.SelectedNode;
            if (theNode == null)
                return;

            List<string> list = new List<string>();
            list.Add(theNode.Tag.ToString());

            if (theNode.Level == 1)
                this.DoPrint1(list);
        }
        private void btnPrint2_Click(object sender, EventArgs e)
        {
            TreeNode theNode = treeArchive.SelectedNode;
            if (theNode == null)
                return;

            List<string> list = new List<string>();
            list.Add(theNode.Tag.ToString());
           
            if (theNode.Level == 1)
                this.DoPrint2(list);
        }
        private void btnPrint3_Click(object sender, EventArgs e)
        {
            TreeNode theNode = treeArchive.SelectedNode;
            if (theNode == null)
                TXMessageBoxExtensions.Info("请选择案卷目录");
                return;

            List<string> list = new List<string>();
            list.Add(theNode.Tag.ToString());

            if (theNode.Level == 1)
                this.DoPrint3(list);
        }
        private void btnPrint5_Click(object sender, EventArgs e)
        {
            fileList.Clear();
            fileList.Add(Application.StartupPath + @"\Reports\wjdjb.pdf");
            index = 0;
            DoPrint5();
        }
        private void btnPrint6_Click(object sender, EventArgs e)
        {
            fileList.Clear();
            fileList.Add(Application.StartupPath + @"\Reports\xiangmudjb.pdf");
            index = 0;
            DoPrint6();
        }
        private void btnPrint7_Click(object sender, EventArgs e)
        {
            fileList.Clear();
            fileList.Add(Application.StartupPath + @"\Reports\yijiaodjb.pdf");
            index = 0;
            DoPrint7();
        }

        List<TreeNode> Nodes = new List<TreeNode>();//批量打印节点列表
        static List<string> fileList = new List<string>();//记录打印的PDF名称
        StiReport stiReport = null;//打印报表对象
        static int index = 0;
        /// <summary>
        /// 批量打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_fengmian_All_Click(object sender, EventArgs e)
        {
            index = 0;
            Nodes.Clear();
            fileList.Clear();

            if (treeArchive.Nodes[0].Nodes.Count == 0) { 
                TXMessageBoxExtensions.Info("案卷目录为空,不能打印");
                return;
            }

            for (int i = 0; i < treeArchive.Nodes[0].Nodes.Count; i++)
            {
                Nodes.Add(treeArchive.Nodes[0].Nodes[i]);
            }

            DelPrint del = null;
            ToolStripMenuItem objSender = (ToolStripMenuItem)sender;
            if (objSender == btnPrint_bkb_All || objSender == tsmiPrint_bkb_All)//备考表
                del = new DelPrint(DoPrint3);
            else if (objSender == btnPrint_fengmian_All || objSender == tsmiPrint_fengmian_All)//封面
                del = new DelPrint(DoPrint1);
            else if (objSender == btnPrint_jnml_All || objSender == tsmiPrint_jnml_All)//卷内目录
                del = new DelPrint(DoPrint2);
            frmPrintBat frm = new frmPrintBat(Nodes, del);
            if (objSender == btnPrint_bkb_All || objSender == tsmiPrint_bkb_All)//备考表
                frm.Text = "批量打印-案卷备考表";
            else if (objSender == btnPrint_fengmian_All || objSender == tsmiPrint_fengmian_All)//封面
                frm.Text = "批量打印-案卷封皮";
            else if (objSender == btnPrint_jnml_All || objSender == tsmiPrint_jnml_All)//卷内目录
                frm.Text = "批量打印-卷内目录";
            frm.ShowDialog();
        }

        /// <summary>
        /// 打印案卷封皮
        /// </summary>
        private void DoPrint1(List<string> selectID)
        {
            DataView dv = finalArchive.Print_Ajfm(selectID, Globals.ProjectNO.ToString());

            //dv.Table.Columns.Add("currentIndex");
            ////添加当前卷数列
            //for (int i = 0; i < dv.Table.Rows.Count; i++)
            //{
            //    dv.Table.Rows[i]["currentIndex"] = (i+1).ToString();
            //}

            print_common.DoPrint("Archivefengpi", dv);
        }

        /// <summary>
        /// 打印案卷目录
        /// </summary>
        private void DoPrint2(List<string> selectID)
        {
            DataView dv = finalArchive.Print_Jnml(selectID);
            print_common.DoPrint("Archivemulu", dv);
        }

        /// <summary>
        /// 打印备考表
        /// </summary>
        /// <param name="theNode"></param>
        /// <param name="print"></param>
        private void DoPrint3(List<string> selectID)
        {
            DataView dv = finalArchive.Print_Bkb(selectID);
            print_common.DoPrint("juanneibeikao", dv);
        }

        /// <summary>
        /// 文件登记报告
        /// </summary>
        private void DoPrint5()
        {
            DataView dv = finalArchive.Print_ProjectFile(Globals.ProjectNO);
            if (dv.Table.Rows.Count==0)
            {
                TXMessageBoxExtensions.Info("文件信息为空,不能打印");
                return;
            }
            print_common.DoPrint("wjdjb", dv);
        }
        /// <summary>
        /// 项目登记报告
        /// </summary>
        private void DoPrint6()
        {
            DataView dv = finalArchive.Print_Project_Item(Globals.ProjectNO);
            print_common.DoPrint("xiangmudjb", dv);
        }
        /// <summary>
        /// 移交登记报告
        /// </summary>
        private void DoPrint7()
        {
            DataView dv = finalArchive.Print_Project_Item(Globals.ProjectNO);
            print_common.DoPrint("yijiaodjb", dv);
        }
        private void btnPrintFile_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeArchive.SelectedNode;
            if (tn == null)
            {
                TXMessageBoxExtensions.Info("案卷目录为空,不能打印");
                return; 
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("title", typeof(string));
            dt.Columns.Add("filed", typeof(string));
            GetChild(tn, dt);
            string strpath = null;
            if (axSPApplication1.Documents.ActiveDocument != null)
            {
                strpath = System.IO.Path.Combine(axSPApplication1.Documents.ActiveDocument.FileInformation.FileLocation
                    , axSPApplication1.Documents.ActiveDocument.FileInformation.FileName);
                axSPApplication1.Documents.CloseAll();
            }

            delPrintPDF del = new delPrintPDF(PrintFinalFile);
            frmPrintCell frm = new frmPrintCell(dt.DefaultView, del, tn);
            frm.ShowDialog();
            //if (!string.IsNullOrEmpty(strpath) && System.IO.File.Exists(strpath))
            //{
            //    ShowPDF(strpath);
            //}
            //else
            //{
            //    if (axSPApplication1.Documents.ActiveDocument != null)
            //        axSPApplication1.Documents.CloseAll();
            //}
        }
        private bool PrintFinalFile(string filepath, string printername)
        {
            try
            {
                CustomPaperSize cps = new CustomPaperSize();
                PrintSet.PrinterSetting pageset = new PrintSet.PrinterSetting();
                PrintSet.PrinterData ps = new PrintSet.PrinterData();
                ps.Duplex = PrintSet.PageDuplex.DMDUP_VERTICAL;
                return true;
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info(ex.ToString());
                return false;
            }
        }
        private void GetChild(TreeNode pnode, DataTable dt)
        {
            if (pnode.Level == 2)
            {
                //多了个MPDF
                dt.Rows.Add(new object[] { pnode.Text, Globals.ProjectPath + "\\" + pnode.StateImageKey });
            }
            else
            {
                for (int i = 0; i < pnode.Nodes.Count; i++)
                    GetChild(pnode.Nodes[i], dt);
            }
        }
        private void frmYJ_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        XmlElement root;
        /// <summary>
        /// 移交，JAVA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiCreateNewSIP_Click(object sender, EventArgs e)
        {
            #region 导出初始化
            frm2PDFProgressMsg dfmsg = new frm2PDFProgressMsg();
            dfmsg.progressBar1.Maximum = 100;
            dfmsg.progressBar1.Value = 50;
            dfmsg.Text = "正在检查移交信息...";
            dfmsg.label2.Text = "正在检查移交信息...";
            dfmsg.Show();
            Application.DoEvents();
            if (!YJCheckProjectItemInfo())
            {
                dfmsg.Dispose();
                dfmsg.Close();
                return;
            }
            if (!CheckFilePDF())
            {
                dfmsg.Dispose();
                dfmsg.Close();
                return;
            }
            dfmsg.Hide();

            SaveFileDialog YJ_JAVA = new SaveFileDialog();

            YJ_JAVA.Title = "请选择工程编号:" + Globals.ProjectNO + ",工程名称：" + Globals.Projectname + ",上报资料的存放地址!";
            YJ_JAVA.FileName = Globals.Projectname + ".zip";
            YJ_JAVA.Filter = "ZIP(移交文件) | *.zip";
            string filePath = "";
            if (YJ_JAVA.ShowDialog() == DialogResult.OK)
            {
                filePath = YJ_JAVA.FileName;
            }
            else
                return;
            #endregion

            #region 工程级XML
            IList<ERM.MDL.T_Archive> FinalArchives = FinalArchiveDB.FindByProjectNO(Globals.ProjectNO);
            XmlDocument To_JavaXml = new System.Xml.XmlDocument();
            XmlDeclaration dec = To_JavaXml.CreateXmlDeclaration("1.0", "UTF-8", null);
            To_JavaXml.AppendChild(dec);

            root = To_JavaXml.CreateElement("information");
            To_JavaXml.AppendChild(root);

            XmlElement engBaseInfo = To_JavaXml.CreateElement("engBaseInfo");
            root.AppendChild(engBaseInfo);

            projectXML = new ERM.UI.Common.XmlMapping.Project(projectFactory);
            if (projectXML != null)
            {
                CreateElement("specType", Spec, To_JavaXml, engBaseInfo, Spec == "EngFacilitySpec" ? "市政工程" : "建筑工程");
                projectXML.setXmlInfo(To_JavaXml, engBaseInfo, project, root);
                //设置座标点
                SetPointXML(To_JavaXml, engBaseInfo);
                CreateElement("archCount", FinalArchives.Count.ToString(), To_JavaXml, engBaseInfo, "总卷数");//总卷数
                //if (Spec != "EngHouseSpec")
               // {
                    //CreateElement("start_x", project.Start_X, To_JavaXml, engBaseInfo, "开始坐标X");
                    //CreateElement("start_y", project.Start_Y, To_JavaXml, engBaseInfo, "开始坐标Y");
                    //CreateElement("end_x", project.End_X, To_JavaXml, engBaseInfo, "结束坐标X");
                    //CreateElement("end_y", project.End_Y, To_JavaXml, engBaseInfo, "结束坐标Y");
                //}
            }


            #endregion

            #region 工程扩展项
            projectXML = ProjectXML_Factory.getInstance(new T_Dict_BLL().FindByKeyWord("ProjectCategory"), project.ProjectCategory);
            if (projectXML != null)
            {
                projectXML.setXmlInfo(To_JavaXml, engBaseInfo, project, root);
            }
            #endregion

            #region 项目XML
            XmlDocument To_JavaConStrProXml = new System.Xml.XmlDocument();
            XmlDeclaration decConStrPro = To_JavaConStrProXml.CreateXmlDeclaration("1.0", "UTF-8", null);
            To_JavaConStrProXml.AppendChild(decConStrPro);

            XmlElement rootConStrPro = To_JavaConStrProXml.CreateElement("information");
            To_JavaConStrProXml.AppendChild(rootConStrPro);

            XmlElement projBaseInfoXML = To_JavaConStrProXml.CreateElement("projBaseInfo");
            rootConStrPro.AppendChild(projBaseInfoXML);

            projectXML = new ERM.UI.Common.XmlMapping.Item(projectFactory);
            if (projectXML != null)
            {
                projectXML.setXmlInfo(To_JavaConStrProXml, projBaseInfoXML, project);
            }
            #endregion

            #region 临时目录
            string tempPath = System.IO.Path.Combine(Application.StartupPath, "temp_YJ", Guid.NewGuid().ToString());
            if (System.IO.Directory.Exists(tempPath))
            {
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath, true);
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath + "\\efile", true);
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath + "\\yw", true);
            }
            else
            {
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath, false);
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath, true);
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath + "\\efile", true);
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath + "\\yw", true);
            }

            #endregion

            #region 导出保存

            int archIndex = 1;
            int fileIndex = 1;
            if (FinalArchives.Count > 0)
            {
                dfmsg.progressBar1.Maximum = FinalArchives.Count;
                dfmsg.progressBar1.Value = 0;
                dfmsg.Text = "正在移交信息...";
                dfmsg.label2.Text = "正在移交案卷信息...";
                dfmsg.Show();
                Application.DoEvents();

                foreach (T_Archive finalarchive in FinalArchives)
                {
                    dfmsg.progressBar1.Value++;
                    dfmsg.label2.Text = "正在移交案卷 [" + finalarchive.ajtm + "] ";
                    Application.DoEvents();

                    //PDF存储目录
                    MyCommon.DeleteAndCreateEmptyDirectory(
                        System.IO.Path.Combine(tempPath + "\\efile", archIndex.ToString()), true);
                    //原文存储目录
                    MyCommon.DeleteAndCreateEmptyDirectory(
                        System.IO.Path.Combine(tempPath + "\\yw", archIndex.ToString()), true);

                    XmlElement archInfo = To_JavaXml.CreateElement("archInfo");
                    GetArchiveXE(finalarchive, To_JavaXml, archInfo);

                    IList<MDL.T_FileList> FinaFiles =
                        FinalFileDB.FindByArchiveID2(finalarchive.ArchiveID, Globals.ProjectNO);
                    foreach (T_FileList finalfile in FinaFiles)
                    {
                        //原文中,文件存储目录
                        MyCommon.DeleteAndCreateEmptyDirectory(
                        System.IO.Path.Combine(tempPath + "\\yw\\" + archIndex.ToString(), fileIndex.ToString()), true);

                        GetFileXE(finalfile, To_JavaXml, archInfo, tempPath, archIndex, fileIndex);
                        fileIndex++;
                    }
                    engBaseInfo.AppendChild(archInfo);
                    archIndex++;
                    fileIndex = 1;
                }
            }

            dfmsg.progressBar1.Value = dfmsg.progressBar1.Maximum / 2;
            dfmsg.label2.Text = "正在压缩移交信息...";
            Application.DoEvents();

            //xml 文件保存目录
            To_JavaXml.Save(System.IO.Path.Combine(tempPath, Globals.ProjectNO + ".xml"));

            SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
            SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
            {
                tmp.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                tmp.CompressDirectory(tempPath, filePath);
            }
            MyCommon.DeleteAndCreateEmptyDirectory(tempPath, false);

            //项目xml 文件保存目录
            string tempPathXm = System.IO.Path.Combine(Application.StartupPath, "temp_YJXM", Guid.NewGuid().ToString());
            if (System.IO.Directory.Exists(tempPathXm))
            {
                MyCommon.DeleteAndCreateEmptyDirectory(tempPathXm, false);
            }
            else
            {
                MyCommon.DeleteAndCreateEmptyDirectory(tempPathXm, true);
            }
            To_JavaConStrProXml.Save(System.IO.Path.Combine(tempPathXm, Globals.Projectname + item.ConStructionProjectName + ".xml"));
            SevenZip.SevenZipCompressor tmp1 = new SevenZip.SevenZipCompressor();
            {
                tmp1.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                tmp1.CompressDirectory(tempPathXm, filePath.Replace(Globals.Projectname, Globals.Projectname + item.ConStructionProjectName));
            }

            if (dfmsg != null)
            {
                dfmsg.Dispose();
                dfmsg.Close();
            }
            MyCommon.DeleteAndCreateEmptyDirectory(tempPathXm, false);
            TXMessageBoxExtensions.Info("提示：保存成功！");
            #endregion
        }

        /// <summary>
        /// 通用创建XmlElement对象
        /// </summary>
        /// <param name="KeyName">KeyName</param>
        /// <param name="KeyValue">KeyValue</param>
        /// <param name="xDoc">XmlDocument对象</param>
        /// <param name="PElement">XmlElement父级对象</param>
        private void CreateElement(string KeyName, string KeyValue,
            XmlDocument xDoc, XmlElement PElement, string description = "")
        {
            XmlElement X_temp = xDoc.CreateElement(KeyName);
            X_temp.SetAttribute("value", KeyValue);
            //X_temp.SetAttribute("description", description);
            PElement.AppendChild(X_temp);
        }
        /// <summary>
        /// 构建案卷XML
        /// </summary>
        /// <param name="obj">T_Archive</param>
        /// <param name="xDoc">XmlDocument对象</param>
        /// <param name="archInfo">XmlElement父级对象</param>
        private void GetArchiveXE(T_Archive obj, XmlDocument xDoc, XmlElement archInfo)
        {
            projectXML = new Common.XmlMapping.Archive(obj);
            if (projectXML != null)
            {
                projectXML.setXmlInfo(xDoc, archInfo, project);
            }
        }

        /// <summary>
        /// 构建文件XML
        /// </summary>
        /// <param name="obj">T_Archive</param>
        /// <param name="xDoc">XmlDocument对象</param>
        /// <param name="PElement">XmlElement父级对象</param>
        /// <param name="tempPath">电子文件存储目录</param>
        /// <param name="archIndex">案卷序号</param>
        /// <param name="fileIndex">案卷下的文件序号</param>
        private void GetFileXE(T_FileList obj, XmlDocument xDoc, XmlElement PElement,
            string tempPath, int archIndex, int fileIndex)
        {
            projectXML = new Common.XmlMapping.File(tempPath, obj, archIndex, fileIndex);
            if (projectXML != null)
            {
                projectXML.setXmlInfo(xDoc, PElement, project, root);
            }
        }

        /// <summary>
        /// 工程坐标信息XML设置
        /// </summary>
        /// <param name="xDoc"></param>
        /// <param name="PElement"></param>
        /// <param name="tempPath"></param>
        private void SetPointXML(XmlDocument xDoc, XmlElement PElement)
        {
            projectXML = new Common.XmlMapping.Point();
            if (projectXML != null)
            {
                projectXML.setXmlInfo(xDoc, PElement, project, root);
            }
        }

        #region 合并PDF功能 2011-6-17 YQ 说明：主要是迁移工程未合并PDF问题
        /// <summary>
        /// 根据文件ID 合并PDF
        /// </summary>
        /// <param name="FileID">文件ID</param>
        /// <returns>文件PDF路径</returns>
        private string ConvertFile2PDF(string FileID)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            MDL.T_FileList fileMDL = fileBLL.Find(FileID, Globals.ProjectNO);
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByGdFileID(FileID, Globals.ProjectNO);

            System.Collections.ArrayList fileArryList = new System.Collections.ArrayList();

            frm2PDFProgressMsg dfmsg = null;
            if (fileMDL.selected == 1 && cellList != null && cellList.Count > 0)
            {
                dfmsg = new frm2PDFProgressMsg();
                dfmsg.progressBar1.Maximum = cellList.Count;
                dfmsg.label2.Text = "正在转换 0/" + cellList.Count;
                dfmsg.Show();
            }
            int curIndex = 1;

            bool isUpdateFileSelect_flg = false;
            foreach (MDL.T_CellAndEFile cellMDL in cellList)
            {
                if (fileMDL.selected == 1)
                {
                    if (dfmsg.label2.Text != "")
                    {
                        dfmsg.label2.Text = "正在转换 " + curIndex + "/" + cellList.Count;
                        dfmsg.progressBar1.Value = curIndex;
                        Application.DoEvents();
                    }
                }
                curIndex++;
                string pdfPath = "";
                if (cellMDL.DocYs == null || cellMDL.DocYs == 1 || cellMDL.fileTreePath == String.Empty || cellMDL.fileTreePath == "")
                {
                    if (!isUpdateFileSelect_flg)
                        isUpdateFileSelect_flg = true;

                    using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                    {
                        try
                        {
                            int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath, Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".pdf");
                            if (iPageCount != 0)
                                cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".pdf";
                            else
                                cellMDL.fileTreePath = "";
                            cellMDL.DocYs = 0;
                            cellMDL.DoStatus = 1;
                            cellMDL.ys = iPageCount;
                            cellBLL.Update(cellMDL);
                        }
                        catch (Exception e)
                        {
                            //TXMessageBoxExtensions.Info(e.Message);
                            MyCommon.WriteLog("PDF转换失败！错误信息：" + e.Message);
                        }
                        pdfPath = cellMDL.fileTreePath;
                    }
                }
                else
                {
                    pdfPath = cellMDL.fileTreePath;
                    if (!System.IO.File.Exists(Globals.ProjectPath + pdfPath)
                        && !string.IsNullOrWhiteSpace(cellMDL.fileTreePath))
                    {
                        if (!isUpdateFileSelect_flg)
                            isUpdateFileSelect_flg = true;
                        using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                        {
                            try
                            {
                                int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath,
                                    Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".pdf");
                                if (iPageCount == 0)
                                    cellMDL.fileTreePath = "";
                                else
                                    cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".pdf";
                                cellMDL.DocYs = 0;
                                cellMDL.DoStatus = 1;
                                cellMDL.ys = iPageCount;
                                cellBLL.Update(cellMDL);
                            }
                            catch (Exception e)
                            {
                                cellMDL.fileTreePath = "";
                                MyCommon.WriteLog("PDF转换失败！错误信息：" + e.Message);
                            }
                            pdfPath = cellMDL.fileTreePath;
                        }
                    }
                }

                if (!System.IO.File.Exists(Globals.ProjectPath + pdfPath))
                {
                    continue;
                }
                fileArryList.Add(Globals.ProjectPath + pdfPath);
            }

            if (dfmsg != null)
            {
                dfmsg.Dispose();
                dfmsg.Close();
            }
            if (!isUpdateFileSelect_flg
               && (string.IsNullOrWhiteSpace(fileMDL.filepath) ||
               !System.IO.File.Exists(Globals.ProjectPath + fileMDL.filepath)))
            {
                isUpdateFileSelect_flg = true;
            }
            if (isUpdateFileSelect_flg)
            {
                //fileMDL.selected = 1;//有新内容,有日期型数据有错。
                //(new ERM.BLL.T_FileList_BLL()).Update(fileMDL);

                string[] FileList = new string[fileArryList.Count];
                for (int i = 0; i < fileArryList.Count; i++)
                {
                    FileList[i] = fileArryList[i].ToString();
                }
                using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                {
                    int iPageCount = 0;
                    if (FileList.Length > 0)
                    {
                        try
                        {
                            iPageCount = c1.MergePDF(FileList, Globals.ProjectPath + "MPDF\\" + FileID + ".pdf");
                            fileMDL.filepath = "MPDF\\" + FileID + ".pdf";
                        }
                        catch
                        {
                            iPageCount = 0;
                            fileMDL.filepath = "";
                        }
                    }
                    else
                    {
                        fileMDL.filepath = "";
                    }
                    //fileMDL.sl = iPageCount;
                    //1 文字数量  2声像 3照片数量
                    int EFileType_flg = 1;
                    TreeFactory treeFactory = new TreeFactory();
                    treeFactory.GetParentNodeType(FileID, ref EFileType_flg);

                    if (EFileType_flg == 1)
                    {
                        if (FileList.Length > 0)  //jdk 20151117 判断如果有电子文件则重新获取获得页数,否则不管
                            fileMDL.sl = iPageCount;
                    }
                    else if (EFileType_flg == 3)
                    {
                        int tzz = MyCommon.ToInt(fileMDL.tzz);
                        int dtz = MyCommon.ToInt(fileMDL.dtz);
                        int zpz = MyCommon.ToInt(fileMDL.zpz);
                        int dpz = MyCommon.ToInt(fileMDL.dpz);

                        fileMDL.dw = (iPageCount + dtz).ToString();
                        fileMDL.tzz = (iPageCount).ToString();
                        fileMDL.dtz = dtz.ToString();

                        fileMDL.wzz = (zpz + dpz).ToString();
                        fileMDL.zpz = zpz.ToString();
                        fileMDL.dpz = dpz.ToString();
                    }
                    else if (EFileType_flg == 2)
                    {
                        int tzz = MyCommon.ToInt(fileMDL.tzz);
                        int dtz = MyCommon.ToInt(fileMDL.dtz);
                        int zpz = MyCommon.ToInt(fileMDL.zpz);
                        int dpz = MyCommon.ToInt(fileMDL.dpz);

                        fileMDL.dw = (tzz + dtz).ToString();
                        fileMDL.tzz = tzz.ToString();
                        fileMDL.dtz = dtz.ToString();

                        fileMDL.wzz = (iPageCount + dpz).ToString();
                        fileMDL.zpz = iPageCount.ToString();
                        fileMDL.dpz = dpz.ToString();
                    }

                    fileMDL.selected = 0;
                    fileBLL.Update(fileMDL);
                }
            }
            return fileMDL.filepath;
        }

        /// <summary>
        /// 转换PDF
        /// </summary>
        /// <param name="FileID"></param>
        /// <returns></returns>
        private string ConvertFilePDF(string FileID)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            MDL.T_FileList fileMDL = fileBLL.Find(FileID, Globals.ProjectNO);
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByGdFileID(FileID, Globals.ProjectNO);

            System.Collections.ArrayList fileArryList = new System.Collections.ArrayList();

            int curIndex = 1;

            bool isUpdateFileSelect_flg = false;
            foreach (MDL.T_CellAndEFile cellMDL in cellList)
            {
                curIndex++;
                string pdfPath = "";
                if (cellMDL.DocYs == null || cellMDL.DocYs == 1 || cellMDL.fileTreePath == String.Empty || cellMDL.fileTreePath == "")
                {
                    if (!isUpdateFileSelect_flg)
                        isUpdateFileSelect_flg = true;

                    using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                    {
                        try
                        {
                            int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath, Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".pdf");
                            if (iPageCount != 0)
                                cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".pdf";
                            else
                                cellMDL.fileTreePath = "";
                            cellMDL.DocYs = 0;
                            cellMDL.DoStatus = 1;
                            cellMDL.ys = iPageCount;
                            cellBLL.Update(cellMDL);
                        }
                        catch (Exception e)
                        {
                            //TXMessageBoxExtensions.Info(e.Message);
                            MyCommon.WriteLog("PDF转换失败！错误信息：" + e.Message);
                        }
                        pdfPath = cellMDL.fileTreePath;
                    }
                }
                else
                {
                    pdfPath = cellMDL.fileTreePath;
                    if (!System.IO.File.Exists(Globals.ProjectPath + pdfPath)
                        && !string.IsNullOrWhiteSpace(cellMDL.fileTreePath))
                    {
                        if (!isUpdateFileSelect_flg)
                            isUpdateFileSelect_flg = true;
                        using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                        {
                            try
                            {
                                int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath,
                                    Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".pdf");
                                if (iPageCount == 0)
                                    cellMDL.fileTreePath = "";
                                else
                                    cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".pdf";
                                cellMDL.DocYs = 0;
                                cellMDL.DoStatus = 1;
                                cellMDL.ys = iPageCount;
                                cellBLL.Update(cellMDL);
                            }
                            catch (Exception e)
                            {
                                cellMDL.fileTreePath = "";
                                MyCommon.WriteLog("PDF转换失败！错误信息：" + e.Message);
                            }
                            pdfPath = cellMDL.fileTreePath;
                        }
                    }
                }

                if (!System.IO.File.Exists(Globals.ProjectPath + pdfPath))
                {
                    continue;
                }
                fileArryList.Add(Globals.ProjectPath + pdfPath);
            }
            //fileMDL.selected = 1;//有新内容,有日期型数据有错。
            //(new ERM.BLL.T_FileList_BLL()).Update(fileMDL);

            string[] FileList = new string[fileArryList.Count];
            for (int i = 0; i < fileArryList.Count; i++)
            {
                FileList[i] = fileArryList[i].ToString();
            }
            using (ConvertCell2PDF c1 = new ConvertCell2PDF())
            {
                int iPageCount = 0;
                if (FileList.Length > 0)
                {
                    try
                    {
                        iPageCount = c1.MergePDF(FileList, Globals.ProjectPath + "MPDF\\" + FileID + ".pdf");
                        fileMDL.filepath = "MPDF\\" + FileID + ".pdf";
                    }
                    catch
                    {
                        iPageCount = 0;
                        fileMDL.filepath = "";
                    }
                }
                else
                {
                    fileMDL.filepath = "";
                }
                //fileMDL.sl = iPageCount;
                //1 文字数量  2声像 3照片数量
                int EFileType_flg = 1;
                TreeFactory treeFactory = new TreeFactory();
                treeFactory.GetParentNodeType(FileID, ref EFileType_flg);

                if (EFileType_flg == 1)
                {
                    if (FileList.Length > 0)  //jdk 20151117 判断如果有电子文件则重新获取获得页数,否则不管
                        fileMDL.sl = iPageCount;
                }
                else if (EFileType_flg == 3)
                {
                    int tzz = MyCommon.ToInt(fileMDL.tzz);
                    int dtz = MyCommon.ToInt(fileMDL.dtz);
                    int zpz = MyCommon.ToInt(fileMDL.zpz);
                    int dpz = MyCommon.ToInt(fileMDL.dpz);

                    fileMDL.dw = (iPageCount + dtz).ToString();
                    fileMDL.tzz = (iPageCount).ToString();
                    fileMDL.dtz = dtz.ToString();

                    fileMDL.wzz = (zpz + dpz).ToString();
                    fileMDL.zpz = zpz.ToString();
                    fileMDL.dpz = dpz.ToString();
                }
                else if (EFileType_flg == 2)
                {
                    int tzz = MyCommon.ToInt(fileMDL.tzz);
                    int dtz = MyCommon.ToInt(fileMDL.dtz);
                    int zpz = MyCommon.ToInt(fileMDL.zpz);
                    int dpz = MyCommon.ToInt(fileMDL.dpz);

                    fileMDL.dw = (tzz + dtz).ToString();
                    fileMDL.tzz = tzz.ToString();
                    fileMDL.dtz = dtz.ToString();

                    fileMDL.wzz = (iPageCount + dpz).ToString();
                    fileMDL.zpz = iPageCount.ToString();
                    fileMDL.dpz = dpz.ToString();
                }

                fileMDL.selected = 0;
                fileBLL.Update(fileMDL);
            }
            return fileMDL.filepath;
        }
        #endregion

        /// <summary>
        /// 移交 检查判断文件下的电子文件是否正确
        /// </summary>
        /// <returns>bool: true 无 false 有误</returns>
        private bool CheckFilePDF()
        {
            ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);
            DataSet dsFinalArchive = projectFactory.GetListArchive(Globals.ProjectNO, "");
            if (dsFinalArchive.Tables.Count < 1 || dsFinalArchive.Tables[0].Rows.Count < 1)
            {
                TXMessageBoxExtensions.Info("提示：没有任何案卷可以移交！");
                return false;
            }
            int count_FinalArchive = dsFinalArchive.Tables[0].Rows.Count;
            bool checkfile_flag = true;
            for (int i = 0; i < count_FinalArchive; i++)
            {
                BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                IList<MDL.T_FileList> fileList =
                    fileBLL.FindByArchiveID2(dsFinalArchive.Tables[0].Rows[i]["案卷ID"].ToString(), Globals.ProjectNO);
                foreach (MDL.T_FileList obj in fileList)
                {
                    if (obj.selected == 1 || obj.filepath == null || obj.filepath == "")
                    {
                        ConvertFilePDF(obj.FileID);
                    }
                    else
                    {
                        string tFilePath = obj.filepath.Replace("MPDF\\", "");
                        string sourMfile = Globals.ProjectPath + obj.filepath;
                        if (!System.IO.File.Exists(sourMfile))
                        {
                            ConvertFilePDF(obj.FileID);
                        }
                    }
                    IList<MDL.T_CellAndEFile> cellList =
                        (new ERM.BLL.T_CellAndEFile_BLL()).FindByGdFileID(obj.FileID, Globals.ProjectNO);
                    ERM.MDL.T_FileList file_model = (new ERM.BLL.T_FileList_BLL()).Find(obj.FileID, Globals.ProjectNO);
                    if ((file_model.filepath == null || file_model.filepath == "") &&
                         cellList.Count > 0)
                    {
                        TXMessageBoxExtensions.Info("提示：文件【" + obj.gdwj + "】电子文件信息有误！无法移交，请审查");
                        checkfile_flag = false;
                        break;
                    }
                }
                if (!checkfile_flag)
                    break;
            }
            return checkfile_flag;
        }

        #region 多线程移交 暂时屏蔽
        frmProgressMsg frm_ProgressMsg = null;
        private bool CreateYJInfo()
        {
            frm_ProgressMsg = new frmProgressMsg();
            frm_ProgressMsg.Show();
            frm_ProgressMsg.TopMost = true;

            for (int i = 1; i < 100; i++)
            {
                BackWorkerYJ.ReportProgress(i, "2;正在进行检测移交内容...");
                System.Threading.Thread.Sleep(1000);
            }

            return false;
            if (!CheckFilePDF())
            {
                BackWorkerYJ.CancelAsync();
                return false;
            }

            SaveFileDialog YJ_JAVA = new SaveFileDialog();
            YJ_JAVA.Title = "请选择工程编号:" + Globals.ProjectNO + ",工程名称：" + Globals.Projectname + ",上报资料的存放地址!";
            YJ_JAVA.FileName = Globals.ProjectNO + ".zip";
            YJ_JAVA.Filter = "ZIP(移交文件) | *.zip";
            string filePath = "";
            if (YJ_JAVA.ShowDialog() == DialogResult.OK)
            {
                filePath = YJ_JAVA.FileName;
            }
            else
                return false;

            XmlDocument To_JavaXml = new System.Xml.XmlDocument();
            XmlDeclaration dec = To_JavaXml.CreateXmlDeclaration("1.0", "UTF-8", null);
            To_JavaXml.AppendChild(dec);

            XmlElement root = To_JavaXml.CreateElement("information");
            To_JavaXml.AppendChild(root);

            XmlElement engBaseInfo = To_JavaXml.CreateElement("engBaseInfo");
            root.AppendChild(engBaseInfo);

            CreateElement("specType", Spec, To_JavaXml, engBaseInfo);
            CreateElement("engName", item.ConStructionProjectName, To_JavaXml, engBaseInfo);//项目名称
            CreateElement("engZone", "", To_JavaXml, engBaseInfo);//工程区域
            CreateElement("engLocation", project.address, To_JavaXml, engBaseInfo);//工程地址
            CreateElement("referenceNo", project.ProjectNO, To_JavaXml, engBaseInfo);//工程编号
            CreateElement("developmentsOrgName", projectFactory.ProjectDetail["jsdw_mc"].ToString(), To_JavaXml, engBaseInfo);//建设单位
            CreateElement("initiationApprovalOrgSid", "", To_JavaXml, engBaseInfo);//立项批准单位
            CreateElement("designOrgSid", projectFactory.ProjectDetail["sjdw_mc"].ToString(), To_JavaXml, engBaseInfo);//设计单位
            CreateElement("reconnaissanceOrgSid", projectFactory.ProjectDetail["kcdw_mc"].ToString(), To_JavaXml, engBaseInfo);//勘察单位
            CreateElement("supervisionOrgSid", projectFactory.ProjectDetail["jldw_mc"].ToString(), To_JavaXml, engBaseInfo);//监理单位
            CreateElement("initiationApprovalNo", "", To_JavaXml, engBaseInfo);//立项批准文号
            CreateElement("landUsePlanningNo", projectFactory.ProjectDetail["ydpzcode"].ToString(), To_JavaXml, engBaseInfo);//用地规划许可证号
            CreateElement("constructNo", projectFactory.ProjectDetail["sgcode"].ToString(), To_JavaXml, engBaseInfo);//施工许可文号
            CreateElement("planCertificateNo", "", To_JavaXml, engBaseInfo);//规划验收合格证号
            CreateElement("startDate", projectFactory.ProjectDetail["begindate"].ToString(), To_JavaXml, engBaseInfo);//开工时间
            CreateElement("endDate", projectFactory.ProjectDetail["enddate"].ToString(), To_JavaXml, engBaseInfo);//竣工时间
            CreateElement("constructOrgSid", projectFactory.ProjectDetail["sgdw_mc"].ToString(), To_JavaXml, engBaseInfo);//施工单位
            CreateElement("roadName", "", To_JavaXml, engBaseInfo);//路名
            CreateElement("engFormerName", "", To_JavaXml, engBaseInfo);//工程曾用名
            CreateElement("microNo", "", To_JavaXml, engBaseInfo);//光盘缩微号
            CreateElement("oldEngId", "", To_JavaXml, engBaseInfo);//原编档号
            CreateElement("projManageName", "", To_JavaXml, engBaseInfo);//项目管理单位
            CreateElement("serveyOrgSid", "", To_JavaXml, engBaseInfo);//测绘单位
            CreateElement("engPlanningNo", projectFactory.ProjectDetail["ghcode"].ToString(), To_JavaXml, engBaseInfo);//工程规划文号
            CreateElement("fireOpinionNo", "", To_JavaXml, engBaseInfo);//建筑消防验收意见书
            CreateElement("designNo", "", To_JavaXml, engBaseInfo);//设计号
            CreateElement("landNo", "", To_JavaXml, engBaseInfo);//土地证号
            CreateElement("textCount", "", To_JavaXml, engBaseInfo);//文字卷
            CreateElement("drawCount", "", To_JavaXml, engBaseInfo);//图纸卷
            CreateElement("photoCount", "", To_JavaXml, engBaseInfo);//照片卷
            CreateElement("cdCount", "", To_JavaXml, engBaseInfo);//光盘卷（无）
            CreateElement("handoverOrgName", "", To_JavaXml, engBaseInfo);//移交单位
            CreateElement("transferUser", "", To_JavaXml, engBaseInfo);//移交人
            CreateElement("archivingDate", "", To_JavaXml, engBaseInfo);//进馆日期

            CreateElement("consTypeCode", project.stru, To_JavaXml, engBaseInfo);//结构类型
            CreateElement("projectCost", projectFactory.ProjectDetail["allcost"].ToString(), To_JavaXml, engBaseInfo);//工程造价
            CreateElement("height", project.high, To_JavaXml, engBaseInfo);//建筑高度
            CreateElement("landUseArea", projectFactory.ProjectDetail["usesoiareasum"].ToString(), To_JavaXml, engBaseInfo);//总占地面积-房屋
            CreateElement("handoverOrgName", projectFactory.ProjectDetail["constructionareasum"].ToString(), To_JavaXml, engBaseInfo);//总建筑面积-房屋
            CreateElement("buildingNums", "", To_JavaXml, engBaseInfo);//栋数
            CreateElement("overNums", project.floors1, To_JavaXml, engBaseInfo);//地上层数
            CreateElement("underNums", project.floors2, To_JavaXml, engBaseInfo);//地下层数
            CreateElement("finishArea", "", To_JavaXml, engBaseInfo);//竣工面积
            CreateElement("holenums", "", To_JavaXml, engBaseInfo);//孔数
            CreateElement("startX", "", To_JavaXml, engBaseInfo);//起点
            CreateElement("endX", "", To_JavaXml, engBaseInfo);//止点
            CreateElement("length", "", To_JavaXml, engBaseInfo); //长度
            CreateElement("width", "", To_JavaXml, engBaseInfo);//宽度
            CreateElement("span", "", To_JavaXml, engBaseInfo);//跨径
            CreateElement("loadCode", "", To_JavaXml, engBaseInfo); //荷载级别
            CreateElement("headroom", "", To_JavaXml, engBaseInfo);//净空
            CreateElement("pipeDiameter", "", To_JavaXml, engBaseInfo); //直径
            CreateElement("pipeMaterial", "", To_JavaXml, engBaseInfo);//管材
            CreateElement("basisTypeCode", "", To_JavaXml, engBaseInfo);//地基处理
            CreateElement("totalLength", "", To_JavaXml, engBaseInfo);//总长度
            CreateElement("underArea", project.dxsmj, To_JavaXml, engBaseInfo);//地下建筑面积
            CreateElement("projCount", "", To_JavaXml, engBaseInfo); //单位工程数 

            //临时目录
            string tempPath = System.IO.Path.Combine(Application.StartupPath, Guid.NewGuid().ToString());
            if (System.IO.Directory.Exists(tempPath))
            {
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath, true);
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath + "\\efile", true);
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath + "\\yw", true);
            }
            else
            {
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath, false);
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath, true);
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath + "\\efile", true);
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath + "\\yw", true);
            }

            IList<ERM.MDL.T_Archive> FinalArchives = FinalArchiveDB.FindByProjectNO(Globals.ProjectNO);
            CreateElement("archCount",
                FinalArchives.Count.ToString(), To_JavaXml, engBaseInfo);//总卷数


            int archIndex = 1;
            int fileIndex = 1;
            if (FinalArchives.Count > 0)
            {
                foreach (T_Archive finalarchive in FinalArchives)
                {
                    //PDF存储目录
                    MyCommon.DeleteAndCreateEmptyDirectory(
                        System.IO.Path.Combine(tempPath + "\\efile", archIndex.ToString()), true);
                    //原文存储目录
                    MyCommon.DeleteAndCreateEmptyDirectory(
                        System.IO.Path.Combine(tempPath + "\\yw", archIndex.ToString()), true);

                    XmlElement archInfo = To_JavaXml.CreateElement("archInfo");
                    GetArchiveXE(finalarchive, To_JavaXml, archInfo);

                    IList<MDL.T_FileList> FinaFiles =
                        FinalFileDB.FindByArchiveID2(finalarchive.ArchiveID, Globals.ProjectNO);
                    foreach (T_FileList finalfile in FinaFiles)
                    {
                        //原文中,文件存储目录
                        MyCommon.DeleteAndCreateEmptyDirectory(
                        System.IO.Path.Combine(tempPath + "\\yw\\" + archIndex.ToString(), fileIndex.ToString()), true);

                        GetFileXE(finalfile, To_JavaXml, archInfo, tempPath, archIndex, fileIndex);
                        fileIndex++;
                    }
                    engBaseInfo.AppendChild(archInfo);
                    archIndex++;
                    fileIndex = 1;
                }
            }
            //xml 文件保存目录
            To_JavaXml.Save(System.IO.Path.Combine(tempPath, Globals.ProjectNO + ".xml"));
            SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
            SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
            {
                tmp.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                tmp.CompressDirectory(tempPath, filePath);
            }

            MyCommon.DeleteAndCreateEmptyDirectory(tempPath, false);
            MyCommon.DeleteAndCreateEmptyDirectory(tempPath, true);
            TXMessageBoxExtensions.Info("提示：保存成功！");
            return true;
        }
        /// <summary>
        /// 开始执行异步处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackWorkerYJ_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = CreateYJInfo();
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 进度 提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackWorkerYJ_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int ProgressValue = e.ProgressPercentage;
            string Flg = (string)e.UserState;

            if (Flg.StartsWith("1"))
            {
                frm_ProgressMsg.SetProcessValue(ProgressValue);
            }
            else if (Flg.StartsWith("2"))
            {
                frm_ProgressMsg.SetProcessValue(ProgressValue, (Flg.Split(';'))[1]);
            }
        }
        /// <summary>
        /// 结束之后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackWorkerYJ_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                frm_ProgressMsg.Close();
            }
            catch (TargetInvocationException ex)
            {
                TXMessageBoxExtensions.Info("移交错误：" + ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// 设置显示PDF
        /// </summary>
        /// <param name="pdfPath">pdf路径</param>
        private void ShowPDF(string pdfPath)
        {
            if (pdfPath != null
              && pdfPath != ""
              && System.IO.File.Exists(pdfPath))
            {
                try
                {
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                    axSPApplication1.Documents.Open(pdfPath);
                }
                catch (Exception ex)
                {
                    MyCommon.WriteLog("读取PDF失败！错误信息：" + ex.Message);
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                }
            }
            else
            {
                if (axSPApplication1.Documents.ActiveDocument != null)
                    axSPApplication1.Documents.CloseAll();
            }
        }

        /// <summary>
        /// 工程报表打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiPrintGCGK_Click(object sender, EventArgs e)
        {
            StiReport yijiaodjbReport = new StiReport();
            string reportPath = string.Empty;
            if (project.ProjectCategory == "Buildding")
            {
                reportPath = "gcgk1";
            }
            else
            {
                reportPath = project.ProjectCategory;
            }
            DataTable dt = CreateTable();
            print_common.DoPrint(reportPath, dt.DefaultView);
        }

        /// <summary>
        /// 移交前，检查工程信息是否完整
        /// </summary>
        /// <returns>bool: true继续移交 false停止移交</returns>
        private bool YJCheckProjectItemInfo()
        {
            bool return_flg = false;
            StringBuilder showText = new StringBuilder();
            MDL.T_Projects projectMDL =
                (new BLL.T_Projects_BLL()).Find(Globals.ProjectNO);
            if (projectMDL != null)
            {
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.ProjectNO))) //工程编号
                {
                    showText.Append("工程编号，");
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.district))) //区域
                {
                    showText.Append("区域，");
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.projectname))) //工程名称
                {
                    showText.Append("工程名称，");
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.address))) //工程地址
                {
                    showText.Append("工程地址，");
                }
                //判断建筑类型的结构类型
                if (project.ProjectCategory.ToLower() == "buildding")
                {
                    if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.stru))) //结构类型
                    {
                        showText.Append("结构类型，");
                    }
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.ydpzcode))) //工程用地批准书号
                {
                   // showText.Append("工程用地批准书号，");
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.ydxkcode))) //用地规划许可证号
                {
                    //showText.Append("用地规划许可证号，");
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.ghcode))) //规划许可证号
                {
                   // showText.Append("规划许可证号，");
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.sgcode))) //工程施工许可证号
                {
                  //  showText.Append("工程施工许可证号，");
                }

                if (showText.Length > 0)
                {
                    showText.Remove(showText.Length - 1, 1);
                    if (TXMessageBoxExtensions.Question("提示：工程以下信息著录不完整 \n" +
                        showText.ToString() + " \n 是否继续移交？") == DialogResult.OK)
                        return_flg = true;
                    else
                        return_flg = false;
                }
                else
                    return_flg = true;
            }
            return return_flg;
        }
    }
    public delegate void DelPrint(List<string> selectID);
}
