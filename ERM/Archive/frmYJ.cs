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
            this.Text = "�ƽ� - " + Globals.Projectname;
            tssLabel1.Text = Globals.NormalStatus;              //����
            tssLabel2.Text = Globals.AppTitle;                  //Ӧ�ó������
            tssLabel3.Text = "��ǰ�û���" + Globals.LoginUser;  //��ǰ�û�
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

            LoadProjectTemp(project.ProjectCategory);//���ع��̼�ģ��

            if (Convert.ToBoolean(Properties.Settings.Default.PrintYjml))
            {
                toolStripMenuItem3.Visible = true;
            }
        }
        private void frmArchive_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (axSPApplication1.Documents.ActiveDocument != null)
                axSPApplication1.Documents.CloseAll();

            this._parentForm.Show();��//��ʾ������
            this._parentForm.Activate();//�������
        }
        /// <summary>
        /// �����ݿ��ȡ������
        /// </summary>
        public void LoadTree()
        {
            this.treeArchive.Nodes.Clear();
            this.treeArchive.ImageList = this.imgList;
            TreeNode ProjectNode = new TreeNode();
            ProjectNode.Tag = Globals.ProjectNO;
            ProjectNode.Text = Globals.Projectname; //+ "���Ŀ¼";
            ProjectNode.SelectedImageIndex = 0;
            ProjectNode.ImageIndex = 0;
            InitArchiveTree(Globals.ProjectNO, ProjectNode);
            treeArchive.Nodes.Add(ProjectNode);
            ProjectNode.Expand();
            treeArchive.SelectedNode = treeArchive.Nodes[0];
            this.tabGrade.SelectedIndex = 0;
            //if (treeArchive.Nodes[0].Nodes.Count > 0)
            //{
            //    //tsmiPrint_bkb_All.Enabled = true;//������ӡ������
            //   // btnPrint_bkb_All.Enabled = true;
            //    //tsmiPrint_fengmian_All.Enabled = true;//������ӡ����
            //    //btnPrint_fengmian_All.Enabled = true;
            //    //tsmiPrint_jnml_All.Enabled = true;//������ӡ����Ŀ¼
            //    //btnPrint_jnml_All.Enabled = true;
            //}
            //else
            //{
            //    tsmiPrint_bkb_All.Enabled = false;//������ӡ������
            //    btnPrint_bkb_All.Enabled = false;
            //    tsmiPrint_fengmian_All.Enabled = false;//������ӡ����
            //    btnPrint_fengmian_All.Enabled = false;
            //    tsmiPrint_jnml_All.Enabled = false;//������ӡ����Ŀ¼
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
        ///  �����ڵ�ѡ������ѡ�з���
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
                    this.tabGrade.SelectedIndex = 0;//���̼�
                    break;
                case 1:
                    if (node.Level == 1)
                    {
                        this.tabGrade.SelectedIndex = 1;//����
                        LoadArchiveData(node.Tag.ToString());
                    }
                    break;
                case 2:
                    if (node.Level == 2)
                    {
                        this.tabGrade.SelectedIndex = 2; //�ļ���
                        LoadFinal_file(node.Tag.ToString());
                        LoadEFileTemp(node.Tag.ToString());
                    }
                    break;
            }
            tssLabel1.Text = Globals.NormalStatus;
        }
        void setMenuPrint()
        {
            this.btnPrint1.Enabled = false;//��Ƥ
            this.tsmiPrint1.Enabled = false;
            this.btnPrint2.Enabled = false;//����Ŀ¼
            this.tsmiPrint2.Enabled = false;
            this.btnPrint3.Enabled = false;//������
            this.tsmiPrint3.Enabled = false;
            if (treeArchive.SelectedNode != null && treeArchive.SelectedNode.Level == 1)
            {
                this.btnPrint1.Enabled = true;//��Ƥ
                this.tsmiPrint1.Enabled = true;
                this.btnPrint2.Enabled = true;//����Ŀ¼
                this.tsmiPrint2.Enabled = true;
                this.btnPrint3.Enabled = true;//������
                this.tsmiPrint3.Enabled = true;
            }
        }
        /// <summary>
        /// ���ع���ģ��
        /// </summary>
        private void LoadProjectTemp(string projectTempType)
        {
            Project_report.Load(Application.StartupPath + @"\Reports\" + projectTempType + ".mrt");//���ر���  
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
        /// ���ذ�����
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
            Archive_report.Load(Application.StartupPath + @"\Reports\Archive.mrt");//���ر���  
            this.Archive_report.RegData("Archive_report", dv);
            Archive_report.Render();
            stiArchive.Report = Archive_report;
        }

        /// <summary>
        /// �����ļ�
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
                    TXMessageBoxExtensions.Info("����ؼ�����");
                }
            }
        }
        /// <summary>
        /// �鵵�ƽ�
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
        /// ��Ӱ�����Ϣ
        /// </summary>
        /// <param name="ProjectNO">���̺�</param>
        /// <param name="ProjectNode">���̽ڵ�</param>
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
                (new ERM.CBLL.FinalArchive()).MoveArchiveOrderindex(ProjectNode);//��������˳��
        }

        private void tabGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode node = this.treeArchive.SelectedNode;
            if (node == null) return;
            int level = node.Level;
            if (node.Level == 2)//�����ļ�
            {
                if (tabGrade.SelectedIndex == 3)//�����ļ�
                {
                    TabIndex = 3;
                    LoadEFileTemp(node.Tag.ToString());
                }
                else if (tabGrade.SelectedIndex == 2)//�ļ��Ǽ�
                {
                    TabIndex = 2;
                    LoadFinal_file(node.Tag.ToString());
                }
            }
            else//�����ļ���ʱ��
            {
                if (tabGrade.SelectedIndex == 3)//����ǵ����ļ�
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
                btnSArchiveVisible.Text = "��ʾ�����б�";
            }
            else
            {
                panelLeft.Visible = true;
                btnSArchiveVisible.Text = "���ذ����б�";
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
                TXMessageBoxExtensions.Info("��ѡ�񰸾�Ŀ¼");
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

        List<TreeNode> Nodes = new List<TreeNode>();//������ӡ�ڵ��б�
        static List<string> fileList = new List<string>();//��¼��ӡ��PDF����
        StiReport stiReport = null;//��ӡ�������
        static int index = 0;
        /// <summary>
        /// ������ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_fengmian_All_Click(object sender, EventArgs e)
        {
            index = 0;
            Nodes.Clear();
            fileList.Clear();

            if (treeArchive.Nodes[0].Nodes.Count == 0) { 
                TXMessageBoxExtensions.Info("����Ŀ¼Ϊ��,���ܴ�ӡ");
                return;
            }

            for (int i = 0; i < treeArchive.Nodes[0].Nodes.Count; i++)
            {
                Nodes.Add(treeArchive.Nodes[0].Nodes[i]);
            }

            DelPrint del = null;
            ToolStripMenuItem objSender = (ToolStripMenuItem)sender;
            if (objSender == btnPrint_bkb_All || objSender == tsmiPrint_bkb_All)//������
                del = new DelPrint(DoPrint3);
            else if (objSender == btnPrint_fengmian_All || objSender == tsmiPrint_fengmian_All)//����
                del = new DelPrint(DoPrint1);
            else if (objSender == btnPrint_jnml_All || objSender == tsmiPrint_jnml_All)//����Ŀ¼
                del = new DelPrint(DoPrint2);
            frmPrintBat frm = new frmPrintBat(Nodes, del);
            if (objSender == btnPrint_bkb_All || objSender == tsmiPrint_bkb_All)//������
                frm.Text = "������ӡ-��������";
            else if (objSender == btnPrint_fengmian_All || objSender == tsmiPrint_fengmian_All)//����
                frm.Text = "������ӡ-�����Ƥ";
            else if (objSender == btnPrint_jnml_All || objSender == tsmiPrint_jnml_All)//����Ŀ¼
                frm.Text = "������ӡ-����Ŀ¼";
            frm.ShowDialog();
        }

        /// <summary>
        /// ��ӡ�����Ƥ
        /// </summary>
        private void DoPrint1(List<string> selectID)
        {
            DataView dv = finalArchive.Print_Ajfm(selectID, Globals.ProjectNO.ToString());

            //dv.Table.Columns.Add("currentIndex");
            ////��ӵ�ǰ������
            //for (int i = 0; i < dv.Table.Rows.Count; i++)
            //{
            //    dv.Table.Rows[i]["currentIndex"] = (i+1).ToString();
            //}

            print_common.DoPrint("Archivefengpi", dv);
        }

        /// <summary>
        /// ��ӡ����Ŀ¼
        /// </summary>
        private void DoPrint2(List<string> selectID)
        {
            DataView dv = finalArchive.Print_Jnml(selectID);
            print_common.DoPrint("Archivemulu", dv);
        }

        /// <summary>
        /// ��ӡ������
        /// </summary>
        /// <param name="theNode"></param>
        /// <param name="print"></param>
        private void DoPrint3(List<string> selectID)
        {
            DataView dv = finalArchive.Print_Bkb(selectID);
            print_common.DoPrint("juanneibeikao", dv);
        }

        /// <summary>
        /// �ļ��ǼǱ���
        /// </summary>
        private void DoPrint5()
        {
            DataView dv = finalArchive.Print_ProjectFile(Globals.ProjectNO);
            if (dv.Table.Rows.Count==0)
            {
                TXMessageBoxExtensions.Info("�ļ���ϢΪ��,���ܴ�ӡ");
                return;
            }
            print_common.DoPrint("wjdjb", dv);
        }
        /// <summary>
        /// ��Ŀ�ǼǱ���
        /// </summary>
        private void DoPrint6()
        {
            DataView dv = finalArchive.Print_Project_Item(Globals.ProjectNO);
            print_common.DoPrint("xiangmudjb", dv);
        }
        /// <summary>
        /// �ƽ��ǼǱ���
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
                TXMessageBoxExtensions.Info("����Ŀ¼Ϊ��,���ܴ�ӡ");
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
                //���˸�MPDF
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
        /// �ƽ���JAVA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiCreateNewSIP_Click(object sender, EventArgs e)
        {
            #region ������ʼ��
            frm2PDFProgressMsg dfmsg = new frm2PDFProgressMsg();
            dfmsg.progressBar1.Maximum = 100;
            dfmsg.progressBar1.Value = 50;
            dfmsg.Text = "���ڼ���ƽ���Ϣ...";
            dfmsg.label2.Text = "���ڼ���ƽ���Ϣ...";
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

            YJ_JAVA.Title = "��ѡ�񹤳̱��:" + Globals.ProjectNO + ",�������ƣ�" + Globals.Projectname + ",�ϱ����ϵĴ�ŵ�ַ!";
            YJ_JAVA.FileName = Globals.Projectname + ".zip";
            YJ_JAVA.Filter = "ZIP(�ƽ��ļ�) | *.zip";
            string filePath = "";
            if (YJ_JAVA.ShowDialog() == DialogResult.OK)
            {
                filePath = YJ_JAVA.FileName;
            }
            else
                return;
            #endregion

            #region ���̼�XML
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
                CreateElement("specType", Spec, To_JavaXml, engBaseInfo, Spec == "EngFacilitySpec" ? "��������" : "��������");
                projectXML.setXmlInfo(To_JavaXml, engBaseInfo, project, root);
                //���������
                SetPointXML(To_JavaXml, engBaseInfo);
                CreateElement("archCount", FinalArchives.Count.ToString(), To_JavaXml, engBaseInfo, "�ܾ���");//�ܾ���
                //if (Spec != "EngHouseSpec")
               // {
                    //CreateElement("start_x", project.Start_X, To_JavaXml, engBaseInfo, "��ʼ����X");
                    //CreateElement("start_y", project.Start_Y, To_JavaXml, engBaseInfo, "��ʼ����Y");
                    //CreateElement("end_x", project.End_X, To_JavaXml, engBaseInfo, "��������X");
                    //CreateElement("end_y", project.End_Y, To_JavaXml, engBaseInfo, "��������Y");
                //}
            }


            #endregion

            #region ������չ��
            projectXML = ProjectXML_Factory.getInstance(new T_Dict_BLL().FindByKeyWord("ProjectCategory"), project.ProjectCategory);
            if (projectXML != null)
            {
                projectXML.setXmlInfo(To_JavaXml, engBaseInfo, project, root);
            }
            #endregion

            #region ��ĿXML
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

            #region ��ʱĿ¼
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

            #region ��������

            int archIndex = 1;
            int fileIndex = 1;
            if (FinalArchives.Count > 0)
            {
                dfmsg.progressBar1.Maximum = FinalArchives.Count;
                dfmsg.progressBar1.Value = 0;
                dfmsg.Text = "�����ƽ���Ϣ...";
                dfmsg.label2.Text = "�����ƽ�������Ϣ...";
                dfmsg.Show();
                Application.DoEvents();

                foreach (T_Archive finalarchive in FinalArchives)
                {
                    dfmsg.progressBar1.Value++;
                    dfmsg.label2.Text = "�����ƽ����� [" + finalarchive.ajtm + "] ";
                    Application.DoEvents();

                    //PDF�洢Ŀ¼
                    MyCommon.DeleteAndCreateEmptyDirectory(
                        System.IO.Path.Combine(tempPath + "\\efile", archIndex.ToString()), true);
                    //ԭ�Ĵ洢Ŀ¼
                    MyCommon.DeleteAndCreateEmptyDirectory(
                        System.IO.Path.Combine(tempPath + "\\yw", archIndex.ToString()), true);

                    XmlElement archInfo = To_JavaXml.CreateElement("archInfo");
                    GetArchiveXE(finalarchive, To_JavaXml, archInfo);

                    IList<MDL.T_FileList> FinaFiles =
                        FinalFileDB.FindByArchiveID2(finalarchive.ArchiveID, Globals.ProjectNO);
                    foreach (T_FileList finalfile in FinaFiles)
                    {
                        //ԭ����,�ļ��洢Ŀ¼
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
            dfmsg.label2.Text = "����ѹ���ƽ���Ϣ...";
            Application.DoEvents();

            //xml �ļ�����Ŀ¼
            To_JavaXml.Save(System.IO.Path.Combine(tempPath, Globals.ProjectNO + ".xml"));

            SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
            SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
            {
                tmp.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                tmp.CompressDirectory(tempPath, filePath);
            }
            MyCommon.DeleteAndCreateEmptyDirectory(tempPath, false);

            //��Ŀxml �ļ�����Ŀ¼
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
            TXMessageBoxExtensions.Info("��ʾ������ɹ���");
            #endregion
        }

        /// <summary>
        /// ͨ�ô���XmlElement����
        /// </summary>
        /// <param name="KeyName">KeyName</param>
        /// <param name="KeyValue">KeyValue</param>
        /// <param name="xDoc">XmlDocument����</param>
        /// <param name="PElement">XmlElement��������</param>
        private void CreateElement(string KeyName, string KeyValue,
            XmlDocument xDoc, XmlElement PElement, string description = "")
        {
            XmlElement X_temp = xDoc.CreateElement(KeyName);
            X_temp.SetAttribute("value", KeyValue);
            //X_temp.SetAttribute("description", description);
            PElement.AppendChild(X_temp);
        }
        /// <summary>
        /// ��������XML
        /// </summary>
        /// <param name="obj">T_Archive</param>
        /// <param name="xDoc">XmlDocument����</param>
        /// <param name="archInfo">XmlElement��������</param>
        private void GetArchiveXE(T_Archive obj, XmlDocument xDoc, XmlElement archInfo)
        {
            projectXML = new Common.XmlMapping.Archive(obj);
            if (projectXML != null)
            {
                projectXML.setXmlInfo(xDoc, archInfo, project);
            }
        }

        /// <summary>
        /// �����ļ�XML
        /// </summary>
        /// <param name="obj">T_Archive</param>
        /// <param name="xDoc">XmlDocument����</param>
        /// <param name="PElement">XmlElement��������</param>
        /// <param name="tempPath">�����ļ��洢Ŀ¼</param>
        /// <param name="archIndex">�������</param>
        /// <param name="fileIndex">�����µ��ļ����</param>
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
        /// ����������ϢXML����
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

        #region �ϲ�PDF���� 2011-6-17 YQ ˵������Ҫ��Ǩ�ƹ���δ�ϲ�PDF����
        /// <summary>
        /// �����ļ�ID �ϲ�PDF
        /// </summary>
        /// <param name="FileID">�ļ�ID</param>
        /// <returns>�ļ�PDF·��</returns>
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
                dfmsg.label2.Text = "����ת�� 0/" + cellList.Count;
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
                        dfmsg.label2.Text = "����ת�� " + curIndex + "/" + cellList.Count;
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
                            MyCommon.WriteLog("PDFת��ʧ�ܣ�������Ϣ��" + e.Message);
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
                                MyCommon.WriteLog("PDFת��ʧ�ܣ�������Ϣ��" + e.Message);
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
                //fileMDL.selected = 1;//��������,�������������д�
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
                    //1 ��������  2���� 3��Ƭ����
                    int EFileType_flg = 1;
                    TreeFactory treeFactory = new TreeFactory();
                    treeFactory.GetParentNodeType(FileID, ref EFileType_flg);

                    if (EFileType_flg == 1)
                    {
                        if (FileList.Length > 0)  //jdk 20151117 �ж�����е����ļ������»�ȡ���ҳ��,���򲻹�
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
        /// ת��PDF
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
                            MyCommon.WriteLog("PDFת��ʧ�ܣ�������Ϣ��" + e.Message);
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
                                MyCommon.WriteLog("PDFת��ʧ�ܣ�������Ϣ��" + e.Message);
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
            //fileMDL.selected = 1;//��������,�������������д�
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
                //1 ��������  2���� 3��Ƭ����
                int EFileType_flg = 1;
                TreeFactory treeFactory = new TreeFactory();
                treeFactory.GetParentNodeType(FileID, ref EFileType_flg);

                if (EFileType_flg == 1)
                {
                    if (FileList.Length > 0)  //jdk 20151117 �ж�����е����ļ������»�ȡ���ҳ��,���򲻹�
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
        /// �ƽ� ����ж��ļ��µĵ����ļ��Ƿ���ȷ
        /// </summary>
        /// <returns>bool: true �� false ����</returns>
        private bool CheckFilePDF()
        {
            ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);
            DataSet dsFinalArchive = projectFactory.GetListArchive(Globals.ProjectNO, "");
            if (dsFinalArchive.Tables.Count < 1 || dsFinalArchive.Tables[0].Rows.Count < 1)
            {
                TXMessageBoxExtensions.Info("��ʾ��û���κΰ�������ƽ���");
                return false;
            }
            int count_FinalArchive = dsFinalArchive.Tables[0].Rows.Count;
            bool checkfile_flag = true;
            for (int i = 0; i < count_FinalArchive; i++)
            {
                BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                IList<MDL.T_FileList> fileList =
                    fileBLL.FindByArchiveID2(dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString(), Globals.ProjectNO);
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
                        TXMessageBoxExtensions.Info("��ʾ���ļ���" + obj.gdwj + "�������ļ���Ϣ�����޷��ƽ��������");
                        checkfile_flag = false;
                        break;
                    }
                }
                if (!checkfile_flag)
                    break;
            }
            return checkfile_flag;
        }

        #region ���߳��ƽ� ��ʱ����
        frmProgressMsg frm_ProgressMsg = null;
        private bool CreateYJInfo()
        {
            frm_ProgressMsg = new frmProgressMsg();
            frm_ProgressMsg.Show();
            frm_ProgressMsg.TopMost = true;

            for (int i = 1; i < 100; i++)
            {
                BackWorkerYJ.ReportProgress(i, "2;���ڽ��м���ƽ�����...");
                System.Threading.Thread.Sleep(1000);
            }

            return false;
            if (!CheckFilePDF())
            {
                BackWorkerYJ.CancelAsync();
                return false;
            }

            SaveFileDialog YJ_JAVA = new SaveFileDialog();
            YJ_JAVA.Title = "��ѡ�񹤳̱��:" + Globals.ProjectNO + ",�������ƣ�" + Globals.Projectname + ",�ϱ����ϵĴ�ŵ�ַ!";
            YJ_JAVA.FileName = Globals.ProjectNO + ".zip";
            YJ_JAVA.Filter = "ZIP(�ƽ��ļ�) | *.zip";
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
            CreateElement("engName", item.ConStructionProjectName, To_JavaXml, engBaseInfo);//��Ŀ����
            CreateElement("engZone", "", To_JavaXml, engBaseInfo);//��������
            CreateElement("engLocation", project.address, To_JavaXml, engBaseInfo);//���̵�ַ
            CreateElement("referenceNo", project.ProjectNO, To_JavaXml, engBaseInfo);//���̱��
            CreateElement("developmentsOrgName", projectFactory.ProjectDetail["jsdw_mc"].ToString(), To_JavaXml, engBaseInfo);//���赥λ
            CreateElement("initiationApprovalOrgSid", "", To_JavaXml, engBaseInfo);//������׼��λ
            CreateElement("designOrgSid", projectFactory.ProjectDetail["sjdw_mc"].ToString(), To_JavaXml, engBaseInfo);//��Ƶ�λ
            CreateElement("reconnaissanceOrgSid", projectFactory.ProjectDetail["kcdw_mc"].ToString(), To_JavaXml, engBaseInfo);//���쵥λ
            CreateElement("supervisionOrgSid", projectFactory.ProjectDetail["jldw_mc"].ToString(), To_JavaXml, engBaseInfo);//����λ
            CreateElement("initiationApprovalNo", "", To_JavaXml, engBaseInfo);//������׼�ĺ�
            CreateElement("landUsePlanningNo", projectFactory.ProjectDetail["ydpzcode"].ToString(), To_JavaXml, engBaseInfo);//�õع滮���֤��
            CreateElement("constructNo", projectFactory.ProjectDetail["sgcode"].ToString(), To_JavaXml, engBaseInfo);//ʩ������ĺ�
            CreateElement("planCertificateNo", "", To_JavaXml, engBaseInfo);//�滮���պϸ�֤��
            CreateElement("startDate", projectFactory.ProjectDetail["begindate"].ToString(), To_JavaXml, engBaseInfo);//����ʱ��
            CreateElement("endDate", projectFactory.ProjectDetail["enddate"].ToString(), To_JavaXml, engBaseInfo);//����ʱ��
            CreateElement("constructOrgSid", projectFactory.ProjectDetail["sgdw_mc"].ToString(), To_JavaXml, engBaseInfo);//ʩ����λ
            CreateElement("roadName", "", To_JavaXml, engBaseInfo);//·��
            CreateElement("engFormerName", "", To_JavaXml, engBaseInfo);//����������
            CreateElement("microNo", "", To_JavaXml, engBaseInfo);//������΢��
            CreateElement("oldEngId", "", To_JavaXml, engBaseInfo);//ԭ�൵��
            CreateElement("projManageName", "", To_JavaXml, engBaseInfo);//��Ŀ����λ
            CreateElement("serveyOrgSid", "", To_JavaXml, engBaseInfo);//��浥λ
            CreateElement("engPlanningNo", projectFactory.ProjectDetail["ghcode"].ToString(), To_JavaXml, engBaseInfo);//���̹滮�ĺ�
            CreateElement("fireOpinionNo", "", To_JavaXml, engBaseInfo);//�����������������
            CreateElement("designNo", "", To_JavaXml, engBaseInfo);//��ƺ�
            CreateElement("landNo", "", To_JavaXml, engBaseInfo);//����֤��
            CreateElement("textCount", "", To_JavaXml, engBaseInfo);//���־�
            CreateElement("drawCount", "", To_JavaXml, engBaseInfo);//ͼֽ��
            CreateElement("photoCount", "", To_JavaXml, engBaseInfo);//��Ƭ��
            CreateElement("cdCount", "", To_JavaXml, engBaseInfo);//���̾��ޣ�
            CreateElement("handoverOrgName", "", To_JavaXml, engBaseInfo);//�ƽ���λ
            CreateElement("transferUser", "", To_JavaXml, engBaseInfo);//�ƽ���
            CreateElement("archivingDate", "", To_JavaXml, engBaseInfo);//��������

            CreateElement("consTypeCode", project.stru, To_JavaXml, engBaseInfo);//�ṹ����
            CreateElement("projectCost", projectFactory.ProjectDetail["allcost"].ToString(), To_JavaXml, engBaseInfo);//�������
            CreateElement("height", project.high, To_JavaXml, engBaseInfo);//�����߶�
            CreateElement("landUseArea", projectFactory.ProjectDetail["usesoiareasum"].ToString(), To_JavaXml, engBaseInfo);//��ռ�����-����
            CreateElement("handoverOrgName", projectFactory.ProjectDetail["constructionareasum"].ToString(), To_JavaXml, engBaseInfo);//�ܽ������-����
            CreateElement("buildingNums", "", To_JavaXml, engBaseInfo);//����
            CreateElement("overNums", project.floors1, To_JavaXml, engBaseInfo);//���ϲ���
            CreateElement("underNums", project.floors2, To_JavaXml, engBaseInfo);//���²���
            CreateElement("finishArea", "", To_JavaXml, engBaseInfo);//�������
            CreateElement("holenums", "", To_JavaXml, engBaseInfo);//����
            CreateElement("startX", "", To_JavaXml, engBaseInfo);//���
            CreateElement("endX", "", To_JavaXml, engBaseInfo);//ֹ��
            CreateElement("length", "", To_JavaXml, engBaseInfo); //����
            CreateElement("width", "", To_JavaXml, engBaseInfo);//���
            CreateElement("span", "", To_JavaXml, engBaseInfo);//�羶
            CreateElement("loadCode", "", To_JavaXml, engBaseInfo); //���ؼ���
            CreateElement("headroom", "", To_JavaXml, engBaseInfo);//����
            CreateElement("pipeDiameter", "", To_JavaXml, engBaseInfo); //ֱ��
            CreateElement("pipeMaterial", "", To_JavaXml, engBaseInfo);//�ܲ�
            CreateElement("basisTypeCode", "", To_JavaXml, engBaseInfo);//�ػ�����
            CreateElement("totalLength", "", To_JavaXml, engBaseInfo);//�ܳ���
            CreateElement("underArea", project.dxsmj, To_JavaXml, engBaseInfo);//���½������
            CreateElement("projCount", "", To_JavaXml, engBaseInfo); //��λ������ 

            //��ʱĿ¼
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
                FinalArchives.Count.ToString(), To_JavaXml, engBaseInfo);//�ܾ���


            int archIndex = 1;
            int fileIndex = 1;
            if (FinalArchives.Count > 0)
            {
                foreach (T_Archive finalarchive in FinalArchives)
                {
                    //PDF�洢Ŀ¼
                    MyCommon.DeleteAndCreateEmptyDirectory(
                        System.IO.Path.Combine(tempPath + "\\efile", archIndex.ToString()), true);
                    //ԭ�Ĵ洢Ŀ¼
                    MyCommon.DeleteAndCreateEmptyDirectory(
                        System.IO.Path.Combine(tempPath + "\\yw", archIndex.ToString()), true);

                    XmlElement archInfo = To_JavaXml.CreateElement("archInfo");
                    GetArchiveXE(finalarchive, To_JavaXml, archInfo);

                    IList<MDL.T_FileList> FinaFiles =
                        FinalFileDB.FindByArchiveID2(finalarchive.ArchiveID, Globals.ProjectNO);
                    foreach (T_FileList finalfile in FinaFiles)
                    {
                        //ԭ����,�ļ��洢Ŀ¼
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
            //xml �ļ�����Ŀ¼
            To_JavaXml.Save(System.IO.Path.Combine(tempPath, Globals.ProjectNO + ".xml"));
            SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
            SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
            {
                tmp.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                tmp.CompressDirectory(tempPath, filePath);
            }

            MyCommon.DeleteAndCreateEmptyDirectory(tempPath, false);
            MyCommon.DeleteAndCreateEmptyDirectory(tempPath, true);
            TXMessageBoxExtensions.Info("��ʾ������ɹ���");
            return true;
        }
        /// <summary>
        /// ��ʼִ���첽����
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
        /// ���� ��ʾ
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
        /// ����֮��
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
                TXMessageBoxExtensions.Info("�ƽ�����" + ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// ������ʾPDF
        /// </summary>
        /// <param name="pdfPath">pdf·��</param>
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
                    MyCommon.WriteLog("��ȡPDFʧ�ܣ�������Ϣ��" + ex.Message);
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
        /// ���̱����ӡ
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
        /// �ƽ�ǰ����鹤����Ϣ�Ƿ�����
        /// </summary>
        /// <returns>bool: true�����ƽ� falseֹͣ�ƽ�</returns>
        private bool YJCheckProjectItemInfo()
        {
            bool return_flg = false;
            StringBuilder showText = new StringBuilder();
            MDL.T_Projects projectMDL =
                (new BLL.T_Projects_BLL()).Find(Globals.ProjectNO);
            if (projectMDL != null)
            {
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.ProjectNO))) //���̱��
                {
                    showText.Append("���̱�ţ�");
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.district))) //����
                {
                    showText.Append("����");
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.projectname))) //��������
                {
                    showText.Append("�������ƣ�");
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.address))) //���̵�ַ
                {
                    showText.Append("���̵�ַ��");
                }
                //�жϽ������͵Ľṹ����
                if (project.ProjectCategory.ToLower() == "buildding")
                {
                    if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.stru))) //�ṹ����
                    {
                        showText.Append("�ṹ���ͣ�");
                    }
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.ydpzcode))) //�����õ���׼���
                {
                   // showText.Append("�����õ���׼��ţ�");
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.ydxkcode))) //�õع滮���֤��
                {
                    //showText.Append("�õع滮���֤�ţ�");
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.ghcode))) //�滮���֤��
                {
                   // showText.Append("�滮���֤�ţ�");
                }
                if (string.IsNullOrWhiteSpace(MyCommon.ToString(projectMDL.sgcode))) //����ʩ�����֤��
                {
                  //  showText.Append("����ʩ�����֤�ţ�");
                }

                if (showText.Length > 0)
                {
                    showText.Remove(showText.Length - 1, 1);
                    if (TXMessageBoxExtensions.Question("��ʾ������������Ϣ��¼������ \n" +
                        showText.ToString() + " \n �Ƿ�����ƽ���") == DialogResult.OK)
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
