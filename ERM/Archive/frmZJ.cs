using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.MDL;
using ERM.Common;
using System.Text.RegularExpressions;
using ERM.UI;
using ERM.BLL;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Forms;
using ERM.UI.Common;
namespace ERM.UI
{
    public partial class frmZJ : Skin_DevEX
    {
        ERM.UI.TreeFactory treeFactory;
        ERM.CBLL.FinalArchive archiveBLLEx = new ERM.CBLL.FinalArchive();
        ERM.BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
        ERM.BLL.T_Archive_BLL archiveBLL = new ERM.BLL.T_Archive_BLL();//�������ݿ������
        
        ERM.MDL.T_Archive archiveMDL = new T_Archive();//����ʵ����
        ERM.CBLL.PrintFinalArchive finalArchive = new ERM.CBLL.PrintFinalArchive();
        
        ERM.BLL.T_FileList_BLL fileList_bll = new ERM.BLL.T_FileList_BLL();//�ļ������� 2011-3-17 from YQ
        ERM.CBLL.PageSize PageSizeDB = new ERM.CBLL.PageSize();//���ݿ������ 2011-3-17 from YQ �����жϰ����С����
        private TreeNode tnEdit = null;
        ExcelHelp ExcelHelp = new ExcelHelp();

        //��ӡ
        Print_Common print_common = new Print_Common(Application.StartupPath);
        /// <summary>
        /// Ĭ����ʾ��pdf�ļ���true���ļ��Ǽ���Ϣ 
        /// </summary>
        private bool Isfile = true;
        int TreeOrList = 0;
        public frmZJ()
        {
            InitializeComponent();
        }
        private Form _parentForm;
        public frmZJ(Form parentForm)
        {
            InitializeComponent();
            treeFactory = new ERM.UI.TreeFactory();
            rightFileTree.ImageList = imgList;
            this._parentForm = parentForm;
            BindData();
            ucFileInfo1 = new FileRegistInfo();
            ucFileInfo1.Dock = DockStyle.Fill;
            this.ucFileInfo1.Enabled = false;
            this.tabPage2.Controls.Add(ucFileInfo1);
            Init();
        }
        private void Init()
        {
            this.Text = "��� - " + Globals.Projectname;
            tsbtnSave.Enabled = false;
            groupBoxArrich.Enabled = false;
        }
        private string optype;
        public string OpType
        {
            get { return this.optype; }
            set { this.optype = value; }
        }
        private string archiveID;
        public string ArchiveID
        {
            get { return this.archiveID; }
            set { this.archiveID = value; }
        }
        /// <summary>
        /// �Զ��������ڵ�
        /// </summary>
        private TreeNode _AutoNewNode = null;
        public TreeNode AutoNewNode
        {
            get { return this._AutoNewNode; }
            set { this._AutoNewNode = value; }
        }
        /// <summary>
        /// �رմ����Ƿ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSelectFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult drs = CheckSave();
            if (drs == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            this._parentForm.Show();��//��ʾ������
            this._parentForm.Activate();//������� 
        }
        /// <summary>
        /// ҳ������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSelectFiles_Load(object sender, EventArgs e)
        {
            LoadLeftArchiveTree();//�󶨰���Ŀ¼���Լ�������ļ�
            LoadRightTree();//���ұߵĹ鵵��

            axSPApplication1.Options.TabBarVisible = false;
            axSPApplication1.CommandBars[0].Visible = false;

            (new ReadWriteAppConfig()).Write("ArchDefalut_ljr", "");
            (new ReadWriteAppConfig()).Write("ArchDefalut_shr", ""); 
        }
        /// <summary>
        /// ��λ��
        /// </summary>
        private void BindUnit()
        {
            IList<MDL.T_Units> dsbxdw = (new BLL.T_Units_BLL()).FindByProjectNO(Globals.ProjectNO);
            cmbbzdw.DisplayMember = "dwmc";
            cmbbzdw.ValueMember = "unittype";
            this.cmbbzdw.DataSource = dsbxdw;
            //cmbbzdw.Items.Clear();
            //string zcb = "";
            //if (dsbxdw.Count > 0)
            //{
            //    for (int i = 0; i < dsbxdw.Count; i++)
            //    {
            //        if (dsbxdw[i].unittype == "unit1")
            //            zcb = dsbxdw[i].dwmc;
            //        else
            //            this.cmbbzdw.Items.Add(dsbxdw[i].dwmc);
            //    }
            //}
           // this.cmbbzdw.Items.Insert(0, zcb);
        }
        /// <summary>
        /// ������
        /// </summary>
        private void BindData()
        {
            BindUnit();
            ReadWriteAppConfig config = new ReadWriteAppConfig();

            DataSet ds = PageSizeDB.GetList();//������
            this.cmbjhlx.Items.Clear();
            string defaultType = "";
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow pagesize_row in ds.Tables[0].Rows)
                {
                    this.cmbjhlx.Items.Add(pagesize_row["PTYPE"].ToString());
                    if (pagesize_row["IsDefault"].ToString() == "1")
                        defaultType = pagesize_row["PTYPE"].ToString();
                }
            }
            if (defaultType != "")
                this.cmbjhlx.Text = defaultType;
           // dptbzksrq.Text = DateTime.Now.ToString("yyyy.MM.dd");
        }
        private void LoadRightTree()
        {
            /***************************************************************************
             * ˵���� 20110707 ��ʾ�Ѿ��Ǽ� �а��������ļ�
             ***************************************************************************/
            treeFactory.GetTree(rightFileTree, Globals.ProjectNO, "filestatus=4", false, false, 3, false,3);
        }
        /// <summary>
        /// ���ذ������ĸ��ڵ�
        /// </summary>
        private void LoadLeftArchiveTree()
        {
            this.leftArchiveTree.Nodes.Clear();
            this.leftArchiveTree.ImageList = this.imgList;
            TreeNode ProjectNode = new TreeNode();
            ProjectNode.Tag = Globals.ProjectNO;
            ProjectNode.Text = Globals.Projectname; //+ "���Ŀ¼";
            ProjectNode.SelectedImageIndex = 0;
            ProjectNode.ImageIndex = 0;
            InitArchiveTree(Globals.ProjectNO, ProjectNode);
            leftArchiveTree.Nodes.Add(ProjectNode);
            leftArchiveTree.SelectedNode = leftArchiveTree.Nodes[0];
            leftArchiveTree.SelectedNode.Expand();
        }
        /// <summary>
        /// �󶨰�������
        /// </summary>
        /// <param name="ProjectNO"></param>
        /// <param name="ProjectNode"></param>
        private void InitArchiveTree(String ProjectNO,
            TreeNode ProjectNode)
        {
            IList<ERM.MDL.T_Archive> FinalArchives = archiveBLL.FindByProjectNO(ProjectNO);
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            bool UpdateOrderIndex_flg = false;
            if (FinalArchives.Count > 0)
            {
                foreach (T_Archive finalarchive in FinalArchives)
                {
                    if (!UpdateOrderIndex_flg && finalarchive.OrderIndex == 0)
                        UpdateOrderIndex_flg = true;

                    TreeNode nodeAjtm = new TreeNode();
                    nodeAjtm.Text = "[" + finalarchive .OrderIndex+ "]" + finalarchive.ajtm;
                    nodeAjtm.Tag = finalarchive.ArchiveID;
                    nodeAjtm.SelectedImageIndex = 1;
                    nodeAjtm.ImageIndex = 1;
                    nodeAjtm.Name = finalarchive.ArchiveID;
                    IList<MDL.T_FileList> cellList = (new BLL.T_FileList_BLL()).FindByArchiveID2(finalarchive.ArchiveID, Globals.ProjectNO);
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
            if (UpdateOrderIndex_flg)
                archiveBLLEx.MoveArchiveOrderindex(ProjectNode);//��������˳��
        }
        /// <summary>
        /// �ļ���ˢ�³ɹ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsFileRef_Click(object sender, EventArgs e)
        {
            LoadRightTree();
        }
        /// <summary>
        /// ���ļ����Ĳ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvFile_MouseDown(object sender, MouseEventArgs e)
        {
            trviewArchive_MouseUp(sender, e);
            this.TreeOrList = 1; //�ļ����϶���־λ
        }
        private void trviewArchive_MouseUp(object sender, MouseEventArgs e)
        {
            {
                Point p = new Point(e.X, e.Y);
                TreeView tv = (TreeView)sender;
                TreeNode theNode = tv.GetNodeAt(p);
                if (theNode != null)
                {
                    tv.SelectedNode = theNode;
                }
            }
        }
        /// <summary>
        /// ˢ�°���Ŀ¼��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsRef_Click(object sender, EventArgs e)
        {
            LoadLeftArchiveTree();//�󶨰���Ŀ¼���Լ�������ļ�
        }
        /// <summary>
        /// �ļ����϶��Ĳ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvFile_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DialogResult drs = CheckSave();
            if (drs == DialogResult.Cancel) return;
            else if (drs == DialogResult.No)
            {
                trviewArchive_AfterSelect(null, null);
            }
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
        /// <summary>
        /// �϶��������������Ƿ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trviewArchive_DragEnter(object sender, DragEventArgs e)
        {
            leftArchiveTree.Focus();//��ק����ʱ����ý���
            e.Effect = DragDropEffects.Move;
        }
        private void trviewArchive_DragOver(object sender, DragEventArgs e)
        {
            Point mousePoint = leftArchiveTree.PointToClient(new Point(e.X, e.Y));
            TreeNode theNode = leftArchiveTree.GetNodeAt(mousePoint);
            if (theNode != null)
            {
                leftArchiveTree.Focus();
                leftArchiveTree.SelectedNode = theNode;
            }
        }
        /// <summary>
        /// �Ϸ����ʱ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trviewArchive_DragDrop(object sender, DragEventArgs e)
        {
            if (this.TreeOrList == 1)
            {
                #region ���ļ����϶�������������
                TabSelect(0);
                TreeNode selectFileNode;
                selectFileNode = rightFileTree.SelectedNode;

                if (selectFileNode.Level == 0)
                {
                    TXMessageBoxExtensions.Info("�������϶����ڵ㣡");
                    return;
                }

                if (!selectFileNode.Checked)
                {
                    TXMessageBoxExtensions.Info("���ȹ�ѡҪ�϶����ļ���");
                    return;
                }

                for (int j = 0; j < rightFileTree.Nodes[0].Nodes.Count; j++)
                {
                    if (rightFileTree.Nodes[0].Nodes[j].Checked && rightFileTree.Nodes[0].Nodes[j].Nodes.Count == 0)
                    {
                        TXMessageBoxExtensions.Info("����ѡ���϶���Ŀ¼û���ļ�,�����϶���");
                        return;
                    }
                }

                TreeNode archiveNode = leftArchiveTree.SelectedNode;
                ArrayList FileIDList = new ArrayList();//PDF�ļ� �������Լ���
                if (archiveNode != null)
                {
                    Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                    TreeNode DestinationNode = archiveNode;// ((TreeView)sender).GetNodeAt(pt);
                    if (DestinationNode == null)
                    {
                        TXMessageBoxExtensions.Info("���Ϸŵ�Ŀ�İ���Ŀ¼�У�");
                        return;
                    }
                    if (DestinationNode.Level != 1)
                    {
                        if (DestinationNode.Level == 2)
                        {
                            archiveNode = archiveNode.Parent;
                        }
                        else
                        {
                            TXMessageBoxExtensions.Info("���Ϸŵ�Ŀ�İ���Ŀ¼�У�");
                            return;
                        }
                    }
                }
                checkEqualsParent_flg = true;
                isSavaCellFile_flg = true;
                FileLists.Clear();

                finalarchive = archiveBLL.Find(ArchiveID);
                if (finalarchive == null)
                {
                    TXMessageBoxExtensions.Info("�Ϸŵ�Ŀ�İ������,�������Ϸţ�");
                    return;
                }
                CheckRightFileSelectedIsArchLX(rightFileTree.Nodes);
                //��������
                if (!isSavaCellFile_flg)
                {
                    return;
                }
                if (archiveNode.Nodes.Count > 0)
                {
                    //�ұ���ק��TreeNodes���������е�TreeNodes�����ж� �Ƿ�����ͬ������
                    CheckCellFileIsEqualsParent(archiveNode, rightFileTree.Nodes);
                    //�ұ���ק��TreeNodes�е������ļ��Ƿ�����ͬ������
                    CheckRightCellFileIsEqualsParent(rightFileTree.Nodes);
                    //�жϵ�ǰѡ�е�Node�Ƿ����ļ� �����Ƿ�ѡ�� 
                    //Ȼ���� ���ұ�ѡ�е��ļ������ж��Ƿ�����ͬһ������
                    if (checkEqualsParent_flg && selectFileNode.ImageIndex == 2 && (!selectFileNode.Checked))
                    {
                        CheckRightCellFileSelectedIsEqualsParent(rightFileTree.Nodes, selectFileNode);
                    }
                    //�жϵ�ǰѡ�е�Node�Ƿ����ļ� �����Ƿ�ѡ�� 
                    //Ȼ���� ���������е��ļ������ж��Ƿ�����ͬһ������
                    if (checkEqualsParent_flg && selectFileNode.ImageIndex == 2 && (!selectFileNode.Checked))
                    {
                        foreach (TreeNode leftchird in archiveNode.Nodes)
                        {
                            //�ж��Ƿ�����ͬһ���ļ���
                            if (!CheckIsEqualsParent(selectFileNode.Parent.Name, leftchird.Name))
                            {
                                DialogResult return_dialog = TXMessageBoxExtensions.Question("�Ƿ�ȷ������ͬ���͵��ļ����ͬһ����");
                                if (return_dialog == DialogResult.OK)
                                {
                                    isSavaCellFile_flg = true;
                                }
                                else
                                {
                                    isSavaCellFile_flg = false;
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    //�ұ���ק��TreeNodes�е������ļ��Ƿ�����ͬ������
                    CheckRightCellFileIsEqualsParent(rightFileTree.Nodes);
                    //�жϵ�ǰѡ�е�Node�Ƿ����ļ� �����Ƿ�ѡ�� 
                    //Ȼ���� ���ұ�ѡ�е��ļ������ж��Ƿ�����ͬһ������
                    if (checkEqualsParent_flg && selectFileNode.ImageIndex == 2 && (!selectFileNode.Checked))
                    {
                        CheckRightCellFileSelectedIsEqualsParent(rightFileTree.Nodes, selectFileNode);
                    }
                }

                //��������
                if (isSavaCellFile_flg)
                {
                    checkRightTree_flg = true;
                    CheckRightTreeViewFilePDF(rightFileTree.Nodes);
                    if (!checkRightTree_flg)
                        return;
                    //����˴���ק������������
                    ArchiveTzzCount = 0;
                    ArchiveZpzCount = 0;
                    savaArchiveCount = 0;
                    ArchiveCount = 0;
                    ArchiveLigerCount = 0;
                    //��ȡ�˴������������
                    GetRightTreeViewFileCount(rightFileTree.Nodes);
                    GetArchiveLeftTreeCount(archiveNode.Nodes);
                    //����е��ܴ�С�͸�����С
                    GetArchiveCount(ArchiveID);

                    if (savaArchiveCount > ArchiveCount && savaArchiveCount <= ArchiveLigerCount)
                    {
                        //�������� С�ڸ���ֵ 
                        DialogResult dialogValue =
                            TXMessageBoxExtensions.Question("�˴�������ļ���������" +
                            savaArchiveCount + "�ţ������ڰ���е�����ֵ��" + ArchiveCount + "�ţ��Ƿ�������");
                        if (dialogValue == DialogResult.OK)
                            isSavaCellFile_flg = true;
                        else
                            isSavaCellFile_flg = false;
                    }
                    else if (savaArchiveCount > ArchiveLigerCount)
                    {
                        //��������ĸ���ֵ
                        DialogResult dialogValue =
                            TXMessageBoxExtensions.Question("�˴�������ļ���������" +
                            savaArchiveCount + "�ţ������ڰ���еĸ�������ֵ��"
                            + ArchiveLigerCount + "�ţ��Ƿ�������");
                        if (dialogValue == DialogResult.OK)
                            isSavaCellFile_flg = true;
                        else
                            isSavaCellFile_flg = false;
                    }

                    if (isSavaCellFile_flg)
                    {
                        AddArchive(rightFileTree.Nodes, finalarchive);
                        /*
                         * Ϊ�˽�ֹˢ�� �϶�����ʱ�� ֱ���Ƴ������
                         *  //LoadLeftArchiveTree();
                            //LoadRightTree();
                            //trviewArchive_AfterSelect(null, null);
                         */
                        GetTreeRightToLeft(rightFileTree.Nodes, archiveNode);
                        //�Ƴ��ұߵ�TreeNode
                        //rightFileTree.Nodes.Remove(selectFileNode);
                        isSelect_flg = string.Empty;
                        RemoveRightTreeViewCheckNodes(rightFileTree.Nodes);

                        //ͳ������ ���֣�ҳ�� ͼֽ���ţ� ͼƬ���ţ�
                        ERM.MDL.T_Archive archive_mdl = archiveBLL.Find(ArchiveID);
                        archive_mdl.wzz = savaArchiveCount.ToString();
                        archive_mdl.tzz = ArchiveTzzCount.ToString();
                        archive_mdl.zpz = ArchiveZpzCount.ToString();
                        archive_mdl.dtz = ArchiveDtCount.ToString();
                        archive_mdl.dpz = ArchiveDpCount.ToString();
                        archiveBLL.Update(archive_mdl);
                    }
                }
                #endregion
            }
            else
            {
                #region �������ڲ��϶������������Ŀ¼�ڹ����е�˳���
                TreeNode moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                Point pt;
                TreeNode targeNode;
                pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
                targeNode = leftArchiveTree.GetNodeAt(pt);
                if (targeNode == moveNode)
                    return;
                if (TreeOperation.CheckPath(moveNode, targeNode))
                {
                    if (moveNode.Level == 1)//�ƶ�����Ŀ¼
                    {
                        if (targeNode.TreeView == moveNode.TreeView)//ͬһ�����ƶ�
                        {
                            TreeNode tmp = (TreeNode)moveNode.Clone();
                            targeNode.Parent.Nodes.Insert(targeNode.Index, tmp);
                            targeNode.Expand();
                            moveNode.Remove();//�Ƴ�ԭ�ڵ�
                            archiveBLLEx.MoveAFinalArchiveOrderindex(targeNode);//�ƶ���������������˳��
                            CheckEnable();
                        }
                    }
                    else//�п��ܵ����ļ����� PDF ���� ʵ�ʵ��������ļ��ڰ����е�˳�� ����ͬһ�������µĵ����ļ�˳��
                    {
                        if (targeNode.TreeView == moveNode.TreeView)//ͬһ�����ƶ�
                        {
                            targeNode.Parent.Nodes.Insert(targeNode.Index, (TreeNode)moveNode.Clone());//�����ڲ��ļ�����
                            targeNode.Expand();
                            targeNode.TreeView.SelectedNode = targeNode.Parent.Nodes[targeNode.Index - 1];
                            TreeNode tn = moveNode.Parent;
                            string ArchiveID = tn.Tag.ToString();
                            moveNode.Remove();//�Ƴ�ԭ�ڵ�

                            archiveBLLEx.MoveFinalAttachment_ArchIndex(targeNode, ArchiveID, Globals.ProjectNO);
                            CheckEnable();
                        }
                    }
                }
                else
                {
                    TXMessageBoxExtensions.Info("ֻ����ͬһ�㼶���ƶ���");
                    return;
                }
                #endregion
            }
        }

        #region �ұ����϶��¼� �ݹ��ȡ�ļ���Ϣ ����ˢ��Ч��
        /*
         * 
         * 2011-3-15 �϶� ����ˢ��Ч��
         */
        /// <summary>
        /// �ұ����϶��¼� �ݹ��ȡ�ļ���Ϣ
        /// </summary>
        /// <param name="parentNodes">�ұ�ѡ���϶�TerrNodes</param>
        /// <param name="addparentNode">���Ŀ��TreeNode�ڵ�</param>        
        private void GetTreeRightToLeft(TreeNodeCollection parentNodes, TreeNode addparentNode)
        {
            foreach (TreeNode chirdnode in parentNodes)
            {
                if (chirdnode.Nodes.Count > 0)
                {
                    GetTreeRightToLeft(chirdnode.Nodes, addparentNode);
                }
                else
                {
                    if ((chirdnode.Checked || chirdnode.IsSelected) && chirdnode.ImageIndex == 2)
                    {
                        TreeNode pdfNode = new TreeNode();
                        pdfNode.Text = chirdnode.Text;
                        pdfNode.Tag = chirdnode.Tag;
                        pdfNode.StateImageKey = chirdnode.StateImageKey;
                        pdfNode.Name = chirdnode.Name;
                        pdfNode.SelectedImageIndex = 2;
                        pdfNode.ImageIndex = 2;
                        addparentNode.Nodes.Add(pdfNode);
                    }
                }
            }
        }

        string isSelect_flg = string.Empty;
        /// <summary>
        /// �Ƴ��ұ�TreeViewѡ���ļ�
        /// </summary>
        /// <param name="rightTreeViewNodes">�ұ�TreeView��Nodes</param>
        private void RemoveRightTreeViewCheckNodes(TreeNodeCollection rightTreeViewNodes)
        {
            //foreach (TreeNode remove_node in rightTreeViewNodes)
            //{
            //    if (remove_node.Nodes.Count > 0)
            //    {
            //        RemoveRightTreeViewCheckNodes(remove_node.Nodes);
            //    }
            //    else
            //    {
            //        if ((remove_node.Checked || remove_node.IsSelected) && remove_node.ImageIndex == 2)
            //        {
            //            rightFileTree.Nodes.Remove(remove_node);
            //            //rightTreeViewNodes.Remove(remove_node);
            //        }
            //    }
            //    if ((remove_node.Checked || remove_node.IsSelected) && remove_node.Nodes.Count == 0 && remove_node.Level != 0)
            //    {
            //        rightFileTree.Nodes.Remove(remove_node);
            //        //rightTreeViewNodes.Remove(remove_node);
            //    }
            //}

            int count = rightTreeViewNodes.Count;
            for (int i = 0; i < count; i++)
            {
                TreeNode childNode = rightTreeViewNodes[i];
                // �Ƴ�֮ǰ���ӽڵ���
                int childCount = childNode.Nodes.Count;
                // �Ƴ��㷨
                if (childCount > 0)
                {
                    // �ݹ����
                    RemoveRightTreeViewCheckNodes(childNode.Nodes);
                    // �Ƴ�֮��ʣ����ӽڵ�
                    childCount = childNode.Nodes.Count;
                }
                else if (childNode.Nodes.Count == 0 && (childNode.Checked || childNode.IsSelected))
                {
                    // �Ƴ���ѡ�еĽڵ�
                    if (childNode.IsSelected && string.IsNullOrEmpty(isSelect_flg))
                    {
                        isSelect_flg = childNode.Name;

                        rightTreeViewNodes.Remove(childNode);
                        --count;
                        --i;
                    }
                    else if (childNode.Checked)
                    {
                        rightTreeViewNodes.Remove(childNode);
                        --count;
                        --i;
                    }
                }
                //// �Ƴ���ѡ�еĸ��ڵ㣨������ڵ���ӽڵ���Ϊ0�����ڵ�ҲҪ�Ƴ���
                //if (childCount == 0 && (childNode.Checked || childNode.IsSelected))
                //{
                //    rightTreeViewNodes.Remove(childNode);
                //    --count;
                //    --i;
                //}
            }
        }

        #endregion

        #region �ж�������С
        /// <summary>
        /// ͼֽ��
        /// </summary>
        int ArchiveTzzCount = 0;
        /// <summary>
        /// ��Ƭ��
        /// </summary>
        int ArchiveZpzCount = 0;
        /// <summary>
        /// ��ͼ��
        /// </summary>
        int ArchiveDtCount = 0;
        /// <summary>
        /// ��Ƭ��
        /// </summary>
        int ArchiveDpCount = 0;
        /// <summary>
        /// һ����ק���������
        /// </summary>
        int savaArchiveCount = 0;
        /// <summary>
        /// ������������С
        /// </summary>
        int ArchiveCount = 0;
        /// <summary>
        /// ��������������С
        /// </summary>
        int ArchiveLigerCount = 0;

        bool checkRightTree_flg = true;
        /// <summary>
        /// �ұ�TreeView ѡ���ļ��ĵ����ļ��Ƿ���ȷ
        /// </summary>
        /// <param name="rightMoveNode">�ұ�TreeView�ڵ㼯��</param>
        private void CheckRightTreeViewFilePDF(TreeNodeCollection rightMoveNode)
        {
            if (checkRightTree_flg)
            {
                foreach (TreeNode chird in rightMoveNode)
                {
                    if (chird.Nodes.Count > 0)
                    {
                        CheckRightTreeViewFilePDF(chird.Nodes);
                    }
                    else
                    {
                        if (chird.ImageIndex == 2 && (chird.Checked || chird.IsSelected))
                        {
                            T_FileList fileList = fileList_bll.Find(chird.Name, Globals.ProjectNO);
                            if (fileList.selected == 1 || fileList.filepath == null || fileList.filepath == "")
                            {
                                ConvertFile2PDF2(fileList.FileID);
                            }
                            else
                            {
                                string tFilePath = fileList.filepath.Replace("MPDF\\", "");
                                string sourMfile = Globals.ProjectPath + fileList.filepath;
                                if (!System.IO.File.Exists(sourMfile))
                                {
                                    ConvertFile2PDF2(fileList.FileID);
                                }
                            }

                            IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByGdFileID(chird.Name, Globals.ProjectNO);

                            T_FileList fileList_temp = fileList_bll.Find(chird.Name, Globals.ProjectNO);
                            if ((fileList_temp.filepath == null || fileList_temp.filepath == "") &&
                                 cellList.Count > 0)
                            {
                               TXMessageBoxExtensions.Info("��ʾ���ļ���" + fileList.gdwj + "�������ļ���Ϣ�����޷���������");
                                checkRightTree_flg = false;
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �ұ�TreeView ѡ�л�ѡ��CheckBoxδѡ�е��ļ�������
        /// </summary>
        /// <param name="rightMoveNode">�ұ�TreeView�ڵ㼯��</param>
        private void GetRightTreeViewFileCount(TreeNodeCollection rightMoveNode)
        {
            foreach (TreeNode chird in rightMoveNode)
            {
                if (chird.Nodes.Count > 0)
                {
                    GetRightTreeViewFileCount(chird.Nodes);
                }
                else
                {
                    if (chird.ImageIndex == 2 && (chird.Checked || chird.IsSelected))
                    {
                        T_FileList fileList = fileList_bll.Find(chird.Name, Globals.ProjectNO);
                        savaArchiveCount += fileList.sl;
                        if (fileList.tzz != null && fileList.tzz.Trim() != "")
                            ArchiveTzzCount += MyCommon.ToInt(fileList.tzz.Trim());
                        if (fileList.zpz != null && fileList.zpz.Trim() != "")
                            ArchiveZpzCount += MyCommon.ToInt(fileList.zpz.Trim());
                        if (fileList.dtz != null && fileList.dtz.Trim() != "")//��ͼ
                            ArchiveDtCount += MyCommon.ToInt(fileList.dtz.Trim());
                        if (fileList.dpz != null && fileList.dpz.Trim() != "")//��Ƭ
                            ArchiveDpCount += MyCommon.ToInt(fileList.dpz.Trim());
                    }
                }
            }
        }

        /// <summary>
        /// ��ȡ��߰��������Ѿ����ڵ��ļ���������
        /// </summary>
        /// <param name="rightMoveNode">���ѡ�а���TreeNode�Ľڵ㼯��</param>
        private void GetArchiveLeftTreeCount(TreeNodeCollection leftTreeFileNode)
        {
            foreach (TreeNode chird in leftTreeFileNode)
            {
                if (chird.Nodes.Count > 0)
                {
                    GetArchiveLeftTreeCount(chird.Nodes);
                }
                else
                {
                    if (chird.ImageIndex == 2)
                    {
                        T_FileList fileList = fileList_bll.Find(chird.Name, Globals.ProjectNO);
                        savaArchiveCount += fileList.sl;
                        if (fileList.tzz != null && fileList.tzz.Trim() != "")//ͼֽ
                            ArchiveTzzCount += MyCommon.ToInt(fileList.tzz.Trim());
                        if (fileList.zpz != null && fileList.zpz.Trim() != "")//��Ƭ
                            ArchiveZpzCount += MyCommon.ToInt(fileList.zpz.Trim());
                        if (fileList.dtz != null && fileList.dtz.Trim() != "")//��ͼ
                            ArchiveDtCount += MyCommon.ToInt(fileList.dtz.Trim());
                        if (fileList.dpz != null && fileList.dpz.Trim() != "")//��Ƭ
                            ArchiveDpCount += MyCommon.ToInt(fileList.dpz.Trim());
                    }
                }
            }
        }
        /// <summary>
        /// ��ȡ���������� �� ������������С
        /// </summary>
        /// <param name="archiveID">����ID</param>
        private void GetArchiveCount(string archiveID)
        {
            try
            {
                ERM.MDL.T_Archive finalarchive = archiveBLL.Find(archiveID);
                if (finalarchive != null)
                {
                    DataSet pageSizeData = new ERM.BLL.PageSize().GetList("PTYPE='" + finalarchive.jhlx + "'");
                    if (pageSizeData != null && pageSizeData.Tables.Count > 0)
                    {
                        ArchiveCount = MyCommon.ToInt((pageSizeData.Tables[0].Rows[0]["Pages"] == null) ? 0 :
                            pageSizeData.Tables[0].Rows[0]["Pages"]);

                        ArchiveLigerCount = ArchiveCount + MyCommon.ToInt((pageSizeData.Tables[0].Rows[0]["Pfloat"] == null) ? 0 :
                            pageSizeData.Tables[0].Rows[0]["Pfloat"]);
                    }
                }
            }
            catch { TXMessageBoxExtensions.Info("��ʾ���������þ�����ͣ�"); }
        }
        #endregion

        /// <summary>
        /// ���ѡ�еİ�����Ϣ
        /// </summary>
        ERM.MDL.T_Archive finalarchive = null;
        /// <summary>
        /// �Ƿ񱣴����
        /// </summary>
        bool isSavaCellFile_flg = false;
        /// <summary>
        /// ֹͣ�ݹ�ѭ������
        /// </summary>
        bool checkEqualsParent_flg = false;

        #region �жϴ��ұ���ק����߰�����ļ��Ƿ����Ѿ��ڰ����е��ļ����� ͬ������
        /// <summary>
        /// �жϴ��ұ���ק����߰�����ļ��Ƿ����Ѿ��ڰ����е��ļ����� ͬ������
        /// �����ͬ������ ��ֱ�����
        /// ������� ��Ҫ��ʾ�жϣ��Ƿ����
        /// </summary>
        /// <param name="leftArchiveNode">��߰���ڵ����</param>
        /// <param name="rightMoveNode">�ұ��϶����ļ������ļ��ж���</param>
        private void CheckCellFileIsEqualsParent(TreeNode leftArchiveNode, TreeNodeCollection rightMoveNode)
        {
            #region ==============================================================================================================
            if (checkEqualsParent_flg)
            {
                foreach (TreeNode chird in rightMoveNode)
                {
                    if (chird.Nodes.Count > 0)
                    {
                        CheckCellFileIsEqualsParent(leftArchiveNode, chird.Nodes);
                    }
                    else
                    {
                        if (chird.ImageIndex == 2 && chird.Checked)
                        {
                            foreach (TreeNode leftchird in leftArchiveNode.Nodes)
                            {
                                //�ж��Ƿ�����ͬһ���ļ���
                                if (!CheckIsEqualsParent(chird.Parent.Name, leftchird.Name))
                                {
                                    DialogResult return_dialog = TXMessageBoxExtensions.Question("�Ƿ�ȷ������ͬ���͵��ļ����ͬһ����");
                                    if (return_dialog == DialogResult.OK)
                                    {
                                        checkEqualsParent_flg = false;
                                        isSavaCellFile_flg = true;
                                    }
                                    else
                                    {
                                        checkEqualsParent_flg = false;
                                        isSavaCellFile_flg = false;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    //�����ݹ�ѭ��
                    if (!checkEqualsParent_flg)
                    {
                        break;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// �ж��ļ���ID �Ƿ����ļ����ļ���ID��ͬ
        /// </summary>
        /// <param name="parentID">�ļ���ID</param>
        /// <param name="fileID">�ļ�ID</param>
        /// <returns>bool:true��ͬ false��ͬ</returns>
        private bool CheckIsEqualsParent(string parentID, string fileID)
        {
            #region =======================================================================
            bool return_flg = false;
            T_FileList fileList = fileList_bll.Find(fileID, Globals.ProjectNO);
            if (string.Equals(parentID, fileList.ParentID))
            {
                return_flg = true;
            }
            return return_flg;
            #endregion
        }
        #endregion

        #region �жϴ��ұ���ק���ļ��Ƿ����� ͬ������
        /// <summary>
        /// ��ʱ��� �ұ��ƶ��ļ�����Ϣ
        /// </summary>
        List<T_FileList> FileLists = new List<T_FileList>();

        /// <summary>
        /// �ж��ұ��ƶ����ļ����Ƿ�Ҳ�в���ͬ���͵��ļ�
        /// �����ͬ������ ��ֱ�����
        /// ������� ��Ҫ��ʾ�жϣ��Ƿ����
        /// </summary>
        /// <param name="rightMoveNode">�ұ��϶����ļ������ļ��ж���</param>
        private void CheckRightCellFileIsEqualsParent(TreeNodeCollection rightMoveNode)
        {
            #region ===============================================================================================================
            if (checkEqualsParent_flg)
            {
                foreach (TreeNode r_MoveNode in rightMoveNode)
                {
                    if (r_MoveNode.Nodes.Count > 0)
                    {
                        CheckRightCellFileIsEqualsParent(r_MoveNode.Nodes);
                    }
                    else
                    {
                        if (r_MoveNode.ImageIndex == 2 && r_MoveNode.Checked)
                        {
                            //�ļ�
                            foreach (T_FileList r_MoveFileList in FileLists)
                            {
                                if (r_MoveNode.Name != r_MoveFileList.FileID
                                    && r_MoveNode.Parent.Name != r_MoveFileList.ParentID)
                                {
                                    //��ͬ���͵��ļ� 
                                    DialogResult return_dialog = TXMessageBoxExtensions.Question("�Ƿ�ȷ������ͬ���͵��ļ����ͬһ����");
                                    if (return_dialog == DialogResult.OK)
                                    {
                                        checkEqualsParent_flg = false;
                                        isSavaCellFile_flg = true;
                                    }
                                    else
                                    {
                                        checkEqualsParent_flg = false;
                                        isSavaCellFile_flg = false;
                                    }
                                    break;
                                }
                            }
                            //��ŵ���ʱ������ �����ж�
                            if (isSavaCellFile_flg && checkEqualsParent_flg)
                            {
                                T_FileList filelist = new T_FileList();
                                filelist.FileID = r_MoveNode.Name;
                                filelist.ParentID = r_MoveNode.Parent.Name;
                                FileLists.Add(filelist);
                            }
                        }
                    }
                    //����ѭ���ݹ�
                    if (!checkEqualsParent_flg)
                    {
                        break;
                    }
                }
            }
            #endregion
        }
        #endregion

        /// <summary>
        /// �ж��ұ�ѡ����ļ����ͣ��Ƿ��밸�����õ��ļ����ͣ�һ��
        /// (����) һ��
        /// (ֽ��) �� (����+ֽ��) һ��
        /// �����ͬ������ ��ֱ�����
        /// ������� ��Ҫ��ʾ�жϣ��Ƿ����
        /// ���ڣ�20140726 YQ
        /// </summary>
        /// <param name="rightMoveNode">�ұ��϶����ļ������ļ��ж���</param>
        private void CheckRightFileSelectedIsArchLX(TreeNodeCollection rightMoveNode)
        {
            #region
            if (checkEqualsParent_flg)
            {
                foreach (TreeNode r_MoveNode in rightMoveNode)
                {
                    if (r_MoveNode.Nodes.Count > 0)
                    {
                        CheckRightFileSelectedIsArchLX(r_MoveNode.Nodes);
                    }
                    else
                    {
                        if (r_MoveNode.ImageIndex == 2 && (r_MoveNode.Checked || r_MoveNode.IsSelected))
                        {
                            //��ͬ���͵��ļ� 
                            T_FileList fileList = fileList_bll.Find(r_MoveNode.Name, Globals.ProjectNO);
                            if (fileList != null)
                            {
                                if ((finalarchive.wjlx == "����" && (finalarchive.wjlx != fileList.wjlx))
                                    || (finalarchive.wjlx != "����" &&
                                    (string.IsNullOrEmpty(fileList.wjlx) || fileList.wjlx == "����" || fileList.wjlx.Trim() == "")))
                                {
                                   //TXMessageBoxExtensions.Info("��ʾ���������ļ���������Ϊ����ʱ���˰����ڲ����������ļ����ͣ� \n ����ܰ��ʾ����鿴ѡ�е��ļ������밸���ļ�����һ�¡�\n �ļ���" + fileList.wjtm + " \n�ļ����ͣ�" + fileList.wjlx);
                                   // checkEqualsParent_flg = false;
                                   // isSavaCellFile_flg = false;
                                   // break;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// �ж��ұ��ƶ����ļ����Ƿ�Ҳ�в���ͬ���͵��ļ�
        /// �����ͬ������ ��ֱ�����
        /// ������� ��Ҫ��ʾ�жϣ��Ƿ����
        /// </summary>
        /// <param name="rightMoveNode">�ұ��϶����ļ������ļ��ж���</param>
        /// <param name="selectMoveNode">�ұ��϶� ��CheckBoxû��ѡ�е��ļ��ж���</param>
        private void CheckRightCellFileSelectedIsEqualsParent(TreeNodeCollection rightMoveNode, TreeNode selectMoveNode)
        {
            #region ===============================================================================================================
            if (checkEqualsParent_flg)
            {
                foreach (TreeNode r_MoveNode in rightMoveNode)
                {
                    if (r_MoveNode.Nodes.Count > 0)
                    {
                        CheckRightCellFileSelectedIsEqualsParent(r_MoveNode.Nodes, selectMoveNode);
                    }
                    else
                    {
                        if (r_MoveNode.ImageIndex == 2 && r_MoveNode.Checked)
                        {
                            if (r_MoveNode.Name != selectMoveNode.Name
                                   && r_MoveNode.Parent.Name != selectMoveNode.Parent.Name)
                            {
                                //��ͬ���͵��ļ� 
                                DialogResult return_dialog = TXMessageBoxExtensions.Question("�Ƿ�ȷ������ͬ���͵��ļ����ͬһ����");
                                if (return_dialog == DialogResult.OK)
                                {
                                    checkEqualsParent_flg = false;
                                    isSavaCellFile_flg = true;
                                }
                                else
                                {
                                    checkEqualsParent_flg = false;
                                    isSavaCellFile_flg = false;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            #endregion
        }
        /// <summary>
        /// ���浱ǰѡ���϶����ļ���Ϣ
        /// </summary>
        /// <param name="fileNode">TreeView����</param>
        /// <param name="archiveMDL">���ID</param>
        private void AddArchive(TreeNodeCollection fileNodes, MDL.T_Archive archiveMDL)
        {
            foreach (TreeNode file_node in fileNodes)
            {
                if (file_node.Nodes.Count > 0)
                {
                    AddArchive(file_node.Nodes, archiveMDL);
                }
                else
                {
                    if ((file_node.Checked || file_node.IsSelected) && file_node.ImageIndex == 2)
                    {
                        MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(file_node.Name, Globals.ProjectNO);

                        if (fileMDL != null)
                        {
                            try
                            {
                                fileMDL.ArchiveID = archiveMDL.ArchiveID;
                                fileMDL.ArchiveIndex = (fileList_bll.GetArchiveOrderIndex(archiveMDL.ArchiveID, Globals.ProjectNO)) + 1;
                                fileMDL.fileStatus = "6";//�����
                                fileMDL.bgqx = archiveMDL.bgqx == null ? "" : archiveMDL.bgqx;
                                fileMDL.mj = archiveMDL.mj == null ? "" : archiveMDL.mj;
                                fileList_bll.Update(fileMDL);
                            }
                            catch(Exception ex)
                            {
                                MyCommon.WriteLog(ex.Message + archiveMDL.ArchiveID + 
                                                  file_node.Name + 
                                                  fileMDL.FileID + Globals.ProjectNO);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// �������϶���־λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trviewArchive_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DialogResult drs = CheckSave();
            if (drs == DialogResult.Cancel) return;
            else if (drs == DialogResult.No)
            {
                trviewArchive_AfterSelect(null, null);
            }
            DoDragDrop(e.Item, DragDropEffects.Move);//�������϶���־λ
        }
        /// <summary>
        /// �������ڲ�����˳��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trviewArchive_MouseDown(object sender, MouseEventArgs e)
        {
            this.TreeOrList = 2; //�������϶���־λ
        }

        /// <summary>
        /// �õ��ڵ���ӽڵ�  �ݹ�ʱ�õ�
        /// </summary>
        /// <param name="node"></param>
        /// <param name="result"></param>
        private int GetFileSL(TreeNode node)
        {
            int iCount = 0;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                iCount += GetFileSL(node.Nodes[i]);
            }
            MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(node.Name, Globals.ProjectNO);
            iCount += fileMDL.sl;
            return iCount;
        }
        private void GetNodePDFNode(TreeNode node, ArrayList FileIDListNode)
        {
            if (node.Name.ToString() == "pdf")//����ڵ�������pdf �򽫴��뼯����
            {
                FileIDListNode.Add(node);
            }
            if (node.Nodes.Count != 0)
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    GetNodePDFNode(node.Nodes[i], FileIDListNode);
                }
        }
        private void GetNodeArchive(TreeNode node, DataTable tbArchive)
        {
            if (node.Level == 1)//����ڵ�������pdf �򽫴��뼯����
            {
                DataRow drtb = tbArchive.NewRow();
                drtb["ArchiveID"] = node.Tag.ToString();
                drtb["ajtm"] = node.Text;
                drtb["ProjectNO"] = Globals.ProjectNO;
                tbArchive.Rows.Add(drtb);
            }
            if (node.Nodes.Count != 0)
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    GetNodeArchive(node.Nodes[i], tbArchive);
                }
        }
        /// <summary>
        /// ���永��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            bool b = SaveData();
            if (b)
            {
                TXMessageBoxExtensions.Info("����ɹ���");
            }
        }
        /// <summary>
        /// ȷ�����永����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            SaveData();
        }
        /// <summary>
        /// ��֤���ݱ�����
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            //2015-05-27 YQ ���α���������           
            if (this.txtajtm.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("������������Ϊ�գ�");//������������Ϊ��
                this.txtajtm.Focus();
                return false;
            }
            if (this.cmbbzdw.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("��������Ƶ�λ��");
                this.cmbbzdw.Focus();
                return false;
            }

            if (this.txtLjr.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("�����������ˣ�");
                this.txtLjr.Focus();
                return false;
            }

             if (this.dptzlrq.TextEx.Trim() == "")
             {
                 TXMessageBoxExtensions.Info("������������ڣ�");
                 this.dptzlrq.Focus();
                 return false;
             }

             //if (this.txtOrderIndex.Text.Trim() == "")
             //{
             //    TXMessageBoxExtensions.Info("�����밸����ţ�");
             //    this.txtOrderIndex.Focus();
             //    return false;
             //}
 
             int result = 0;
             if (!int.TryParse(this.txtOrderIndex.Text,out result))
             {
                 //TXMessageBoxExtensions.Info("��������ȷ�İ������");
                 //txtOrderIndex.Text = "";
                 //txtOrderIndex.Focus();
                 //return false;
             }

             if (!MyCommon.RegexDate(dptzlrq.TextEx.Trim(), "-") && dptzlrq.TextEx.Trim() != "")
             {
                 TXMessageBoxExtensions.Info("��������ȷ�����ڸ�ʽ(��.��.��)");
                 dptzlrq.Text = "";
                 dptzlrq.Focus();
                 return false;
             }
            return true;
        }
        /// <summary>
        /// ��������
        /// </summary>
        private void GetData()
        {
           // archiveMDL.dh = MyCommon.ToSqlString(this.txtdh.Text.Trim());
            archiveMDL.ajtm = MyCommon.ToSqlString(this.txtajtm.Text.Trim());
            archiveMDL.ljr = MyCommon.ToSqlString(this.txtLjr.Text.Trim());
           
            //archiveMDL.bzksrq = this.dptbzksrq.TextEx;//Value.ToShortDateString();
            //archiveMDL.bzjsrq = this.dptbzjsrq.TextEx;//Value.ToShortDateString();
            archiveMDL.mj = MyCommon.ToSqlString(this.cmbmj.Text.Trim());
            archiveMDL.bzdw = MyCommon.ToSqlString(this.cmbbzdw.Text.Trim());
            archiveMDL.ajlx = MyCommon.ToSqlString(this.cmbajlx.Text.Trim());
            archiveMDL.jhlx = MyCommon.ToSqlString(this.cmbjhlx.Text.Trim());
            archiveMDL.bgqx = MyCommon.ToSqlString(this.cmbbgqx.Text.Trim());
            archiveMDL.bz = MyCommon.ToSqlString(this.txtbz.Text.Trim());
        
            archiveMDL.dw = "ҳ";
            archiveMDL.zlrq = dptzlrq.TextEx.Trim();

            ReadWriteAppConfig config = new ReadWriteAppConfig();
            config.Write("ArchDefalut_ProjectNO", Globals.ProjectNO);
            config.Write("ArchDefalut_ajtm", archiveMDL.ajtm);
            config.Write("ArchDefalut_bzdw", archiveMDL.bzdw);
            config.Write("ArchDefalut_jhlx", archiveMDL.jhlx);
            config.Write("ArchDefalut_bgqx", archiveMDL.bgqx);
            config.Write("ArchDefalut_mj", archiveMDL.mj);
            config.Write("ArchDefalut_ljr", archiveMDL.ljr);
            config.Write("ArchDefalut_bzksrq", archiveMDL.bzksrq);
            config.Write("ArchDefalut_bzjsrq", archiveMDL.bzjsrq);
            config.Write("ArchDefalut_ajlx", archiveMDL.ajlx);
            config.Write("ArchDefalut_shr", archiveMDL.ajs);
        }
        /// <summary>
        /// ��������
        /// </summary>
        private bool SaveData()
        {
            if (!ValidateData())
            {
                return false;
            }

            if (this.OpType == "Add")//���
            {
                TreeNode tn = this.leftArchiveTree.TopNode;
                if (tn == null)
                {
                    TXMessageBoxExtensions.Info("��ˢ��֮������ӣ�");
                    return false;
                }
                GetData();
                TreeNode nodeAjtm = new TreeNode();
                this.archiveID = Guid.NewGuid().ToString();
                archiveMDL.ArchiveID = archiveID;
                archiveMDL.ProjectNO = Globals.ProjectNO;
                archiveMDL.OrderIndex = (new BLL.T_Archive_BLL()).GetMaxOrderIndex(Globals.ProjectNO) + 1;
                archiveMDL.wzz = "0";
                archiveMDL.tzz = "0";
                archiveMDL.dtz = "0";
                archiveMDL.zpz = "0";
                archiveMDL.dpz = "0";
                archiveMDL.swp = "0";
                archiveBLL.Add(archiveMDL);//���
                nodeAjtm.Name = archiveMDL.ArchiveID;
                nodeAjtm.Text = archiveMDL.ajtm;
                nodeAjtm.Tag = archiveMDL.ArchiveID;
                nodeAjtm.SelectedImageIndex = 1;
                nodeAjtm.ImageIndex = 1;
                
                tn.Nodes.Add(nodeAjtm);
                this.leftArchiveTree.SelectedNode = nodeAjtm;
            }
            if (this.OpType == "Edit") //�༭������Ϣ
            {
                if (tnEdit != null)
                {
                    archiveMDL = archiveBLL.Find(archiveID);
                    archiveMDL.ArchiveID = archiveID;
                    archiveMDL.OrderIndex = Convert.ToInt32(txtOrderIndex.Text);
                    if (archiveMDL != null)
                    {
                        GetData();
                        archiveBLL.Update(archiveMDL);//����
                        this.leftArchiveTree.SelectedNode = tnEdit;
                        this.leftArchiveTree.SelectedNode.Text = archiveMDL.ajtm;
                    }
                    else
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// ��������ñ仯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbjhlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbjhlx.Text != null && this.cmbjhlx.Text.Trim() != "")
            {
                string jhlx = this.cmbjhlx.Text;
                DataSet page_ds = PageSizeDB.GetPageSizePTYPE(jhlx);
                if (page_ds != null && page_ds.Tables.Count > 0 &&
                    page_ds.Tables[0] != null && page_ds.Tables[0].Rows.Count > 0)
                {
                    archiveMDL.sl = page_ds.Tables[0].Rows[0]["Pages"].ToString();
                    archiveMDL.dw = "ҳ";
                    archiveMDL.ysfw = archiveMDL.sl + "��" + page_ds.Tables[0].Rows[0]["Pfloat"].ToString();//ҳ����Χ
                }
            }
        }
        /// <summary>
        /// �������¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trviewArchive_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = this.leftArchiveTree.SelectedNode;
            CheckEnable();
            if (tn.Level == 1)//��ʾ������Ϣ
            {
                T_FileList_BLL fbll = new T_FileList_BLL();
                tnEdit = tn;
                this.OpType = "Edit";
                archiveID = tn.Tag.ToString();
                SetDataFinalArchive(tn.Tag.ToString());
                TabSelect(0);
                tsbtnSave.Enabled = true;
                groupBoxArrich.Enabled = true;
    
                tpArchiveID = tn.Tag.ToString();
                tpArchiveName = tn.Text;
                string GetMixDate = fbll.GetMixDate(Globals.ProjectNO, archiveID).Trim();
                string GetMaxDate = fbll.GetMaxDate(Globals.ProjectNO, archiveID).Trim();
    
                string ljrtmp = "", shrtmp = "";//������ �����
                ReadWriteAppConfig rwljr = new ReadWriteAppConfig();
                ljrtmp = rwljr.Read("ArchDefalut_ljr");
                shrtmp = rwljr.Read("ArchDefalut_shr");
                if (ljrtmp != "" && txtLjr.Text.Trim() == "")
                {
                    txtLjr.Text = ljrtmp;
                }
       
                BatchBindFileList(tpArchiveID, tpArchiveName);
            }
            else if (tn.Level == 2)//��ʾPDF�ļ�
            {
                TabSelect(1);
                string filepath = ConvertFile2PDF(tn.Name);
                BatchBindFileList(tn.Parent.Tag.ToString(), tpArchiveName);
                SetDataFinalArchive(tn.Parent.Tag.ToString());
                try
                {
                    for (int i = 0; i < this.gvFileList.Rows.Count; i++)
                    {
                        DataGridViewRow dgv_row = gvFileList.Rows[i];
                        if (dgv_row.Cells[1].Value.ToString() == tn.Tag.ToString())
                        {
                            dgv_row.Selected = true;
                            continue;
                        }
                    }
                }
                catch (Exception)
                {

                }
                ucFileInfo1.ShowData(leftArchiveTree.SelectedNode);
                ShowPDF(Globals.ProjectPath + filepath);
            }
        }

        #region
        /// <summary>
        ///  ��ѡ�а�����ļ�,���ڿ�����¼�ļ���Ϣ jdk 20151116
        /// </summary>
        /// <param name="ArchiveID"></param>
        /// <param name="ArchiveName"></param>
        private void BatchBindFileList(string ArchiveID, string ArchiveName)
        {
            try
            {
                int _manualcount = 0;
                lbArchiveName.Text = "��ǰ����:" + (ArchiveName.Length > 10 ? ArchiveName.Substring(0, 10) + "..." : ArchiveName);
                IList<MDL.T_FileList> cellList = (new T_FileList_BLL()).FindByArchiveID2(ArchiveID, Globals.ProjectNO);
                if (gvFileList.Rows.Count > 0)
                    gvFileList.Rows.Clear();
                if (cellList != null && cellList.Count > 0)
                {
                    foreach (T_FileList objFileList in cellList)
                    {
                        gvFileList.Rows.Add();
                        gvFileList.Rows[gvFileList.Rows.Count - 1].Cells["clm_FileID"].Value = objFileList.FileID;
                        gvFileList.Rows[gvFileList.Rows.Count - 1].Cells["clm_FileID"].Tag = objFileList;
                        gvFileList.Rows[gvFileList.Rows.Count - 1].Cells["clm_ArchiveIndex"].Value = objFileList.ArchiveIndex;
                        gvFileList.Rows[gvFileList.Rows.Count - 1].Cells["clm_Wjtm"].Value = objFileList.wjtm;
                        gvFileList.Rows[gvFileList.Rows.Count - 1].Cells["clm_ZRR"].Value = objFileList.zrr;
                        gvFileList.Rows[gvFileList.Rows.Count - 1].Cells["clm_wh"].Value = objFileList.wh;
                        if (objFileList.CreateDate != "" && objFileList.CreateDate2 != "")
                            gvFileList.Rows[gvFileList.Rows.Count - 1].Cells["clm_CreateDate"].Value = objFileList.CreateDate + "��" + objFileList.CreateDate2;
                        if (objFileList.CreateDate != "" && objFileList.CreateDate2 == "")
                            gvFileList.Rows[gvFileList.Rows.Count - 1].Cells["clm_CreateDate"].Value = objFileList.CreateDate;

                        gvFileList.Rows[gvFileList.Rows.Count - 1].Cells["clm_sl"].Value = objFileList.sl;
                        gvFileList.Rows[gvFileList.Rows.Count - 1].Cells["clm_stys"].Value = objFileList.stys;
                        _manualcount += objFileList.sl;
                    }
                }

                bool is_Check = false;
                if (this.gvFileList.Rows != null && this.gvFileList.Rows.Count > 0)
                {
                    if (this.gvFileList.Rows[0].Cells["clm_Select"].Value == null
                           || this.gvFileList.Rows[0].Cells["clm_Select"].Value.ToString().Equals("False"))
                        is_Check = true;
                    for (int i1 = 0; i1 < gvFileList.Rows.Count; i1++)
                    {
                        gvFileList.Rows[i1].Cells["clm_Select"].Value = is_Check;
                    }
                }
                lbArchiveManualCount.Text = "��ǰ������ҳ��: " + _manualcount.ToString() + " ҳ";
            }
            catch (Exception e)
            {
                MyCommon.WriteLog(e.Message);
            }
        }

        private string tpArchiveID, tpArchiveName;
        DataGridViewCellStyle cellOkStype = new DataGridViewCellStyle();
        DataGridViewCellStyle cellErrorStype = new DataGridViewCellStyle();

        /// <summary>
        /// ���������¼�ļ���Ϣ  jdk 20151116
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            gvFileList.EndEdit();
            List<T_FileList> ltFileList = new List<T_FileList>();

            for (int i = 0; i < gvFileList.Rows.Count; i++)
            {
                if (gvFileList.Rows[i].Cells["clm_Select"].Value == null
                    || gvFileList.Rows[i].Cells["clm_Select"].Value.ToString().Equals("False"))
                    continue;

                T_FileList objFileList = gvFileList.Rows[i].Cells["clm_FileID"].Tag as T_FileList;
                objFileList.ArchiveIndex = MyCommon.ToInt(gvFileList.Rows[i].Cells["clm_ArchiveIndex"].Value);
                objFileList.wjtm = MyCommon.ToString(gvFileList.Rows[i].Cells["clm_Wjtm"].Value);
                objFileList.zrr = MyCommon.ToString(gvFileList.Rows[i].Cells["clm_ZRR"].Value);
                objFileList.wh = MyCommon.ToString(gvFileList.Rows[i].Cells["clm_wh"].Value);
                objFileList.CreateDate = MyCommon.ToString(gvFileList.Rows[i].Cells["clm_CreateDate"].Value).Split('��')[0];
                if (MyCommon.ToString(gvFileList.Rows[i].Cells["clm_CreateDate"].Value).Split('��').Length > 1)
                {
                    objFileList.CreateDate2 = MyCommon.ToString(gvFileList.Rows[i].Cells["clm_CreateDate"].Value).Split('��')[1];
                }
                else
                {
                    objFileList.CreateDate2 = "";
                }
                objFileList.sl = MyCommon.ToInt(gvFileList.Rows[i].Cells["clm_sl"].Value);
                objFileList.stys = MyCommon.ToInt(gvFileList.Rows[i].Cells["clm_stys"].Value);
                ltFileList.Add(gvFileList.Rows[i].Cells["clm_FileID"].Tag as T_FileList);
            }
            if (ltFileList.Count > 0)
            {
                foreach (T_FileList objFileList in ltFileList)
                {
                    fileList_bll.Update(objFileList);
                }

                BatchBindFileList(tpArchiveID, tpArchiveName);

                T_Archive archiveObj = archiveBLL.Find(archiveID);
                if (archiveObj != null)
                {
                    archiveBLL.UpdateArchiveTextNums(archiveObj);//ͳ�ư������ļ�������ҳ��,���°�����е��ļ�ҳ�� 
                    SetDataFinalArchive(archiveID); //���¼��ذ�����¼��Ϣ
                }

                TXMessageBoxExtensions.Info("��������ɹ�!");
            }
            else
            {
                TXMessageBoxExtensions.Info("����ѡ��һ��ſ��Ա���!");
            }
        }

        /// <summary>
        /// ��������Ч��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFileList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                cellOkStype.BackColor = Color.White;
               // cellErrorStype.BackColor = Color.Red;
                cellErrorStype.SelectionBackColor = Color.Red;

                DataGridView grid = sender as DataGridView;
                if (grid.Columns[e.ColumnIndex].Name == "clm_ArchiveIndex" || grid.Columns[e.ColumnIndex].Name == "clm_sl")
                {
                    try
                    {
                        Convert.ToInt32(e.FormattedValue);
                        grid.Rows[e.RowIndex].DefaultCellStyle = cellOkStype;
                    }
                    catch
                    {
                        e.Cancel = true;
                        grid.Rows[e.RowIndex].DefaultCellStyle = cellErrorStype;
                    }
                }
                if (grid.Columns[e.ColumnIndex].Name == "clm_CreateDate")
                {
                    try
                    {
                        Convert.ToDateTime(e.FormattedValue.ToString().Split('��')[0]).ToString("yyyy-MM-dd");
                        if (e.FormattedValue.ToString().Split('��').Length > 1)
                            Convert.ToDateTime(e.FormattedValue.ToString().Split('��')[1]).ToString("yyyy-MM-dd");
                        grid.Rows[e.RowIndex].DefaultCellStyle = cellOkStype;
                    }
                    catch
                    {
                        e.Cancel = true;
                        grid.Rows[e.RowIndex].DefaultCellStyle = cellErrorStype;
                    }
                }

                if (grid.Columns[e.ColumnIndex].Name == "clm_stys")
                {
                    try
                    {
                        Convert.ToInt32(e.FormattedValue.ToString());
                        grid.Rows[e.RowIndex].DefaultCellStyle = cellOkStype;
                    }
                    catch (Exception)
                    {
                        e.Cancel = true;
                        grid.Rows[e.RowIndex].DefaultCellStyle = cellErrorStype;
                    }
                }
            }
        }

        /// <summary>
        /// ����ȫѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFileList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gvFileList.Columns[e.ColumnIndex].Name == "clm_Select")
            {
                gvFileList.EndEdit();
                bool is_Check = false;
                if (this.gvFileList.Rows != null && this.gvFileList.Rows.Count > 0)
                {
                    if (this.gvFileList.Rows[0].Cells["clm_Select"].Value == null
                           || this.gvFileList.Rows[0].Cells["clm_Select"].Value.ToString().Equals("False"))
                        is_Check = true;
                    for (int i1 = 0; i1 < gvFileList.Rows.Count; i1++)
                    {
                        gvFileList.Rows[i1].Cells["clm_Select"].Value = is_Check;
                    }
                }
            }
        }
        #endregion

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
            if (fileMDL!=null && fileMDL.selected == 1 && cellList != null && cellList.Count > 0)
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
                        catch (Exception e)
                        {
                            iPageCount = 0;
                            fileMDL.filepath = "";
                            MyCommon.WriteLog("�ϲ�PDFʧ�ܣ�������Ϣ��" + e.Message);
                        }
                    }
                    else
                    {
                        fileMDL.filepath = "";
                    }

                    //1 ��������  2���� 3��Ƭ����
                    int EFileType_flg = 1;
                    TreeFactory treeFactory = new TreeFactory();
                    treeFactory.GetParentNodeType(FileID, ref EFileType_flg);

                    if (EFileType_flg == 1)
                    {
                        if (FileList.Length > 0)
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
        /// �����ļ�ID �ϲ�PDF
        /// </summary>
        /// <param name="FileID">�ļ�ID</param>
        /// <returns>�ļ�PDF·��</returns>
        private string ConvertFile2PDF2(string FileID)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            MDL.T_FileList fileMDL = fileBLL.Find(FileID, Globals.ProjectNO);
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByGdFileID(FileID, Globals.ProjectNO);

            System.Collections.ArrayList fileArryList = new System.Collections.ArrayList();

            bool isUpdateFileSelect_flg = false;
            foreach (MDL.T_CellAndEFile cellMDL in cellList)
            {
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
                            cellMDL.fileTreePath = "";
                            MyCommon.WriteLog("ת��PDFʧ�ܣ�������Ϣ��" + e.Message);
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
                    catch (Exception e)
                    {
                        iPageCount = 0;
                        fileMDL.filepath = "";
                        MyCommon.WriteLog("�ϲ�PDFʧ�ܣ�������Ϣ��" + e.Message);
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
                    if (FileList.Length > 0)
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

        private void TabSelect(int i)
        {
            //ucFileInfo1.Enabled = false;
            if (i == 0)
            {
                tabControl1.SelectTab(0);
            }
            else if (Isfile == true)
            {
                tabControl1.SelectTab(1);
                ucFileInfo1.Enabled = false;
            }
            else
            {
                tabControl1.SelectTab(2);
            }
        }
        private void CheckEnable()
        {
            TreeNode tn = this.leftArchiveTree.SelectedNode;
            if (tn == null) return;
            tsbtnDown.Enabled = false;//����
            tsbtnUp.Enabled = false;//����
            btnDeleteArchive.Enabled = false;//ɾ������
            tsmiDeleteArchive.Enabled = false;
            DeleteArchive.Enabled = false;
            //btnMoveOut.Enabled = false;//�Ƴ��ļ�
            tsmiMoveOut.Enabled = false;
            menuMoveOut.Enabled = false;
            tsmiFinalfile.Enabled = false;
            if (tn.PrevNode != null)
                tsbtnUp.Enabled = true;
            if (tn.NextNode != null)
                tsbtnDown.Enabled = true;
            if (tn.Level == 0)
            {
            }
            else
            {
                if (tn.Level == 1)//��ʾ������Ϣ
                {
                    btnDeleteArchive.Enabled = true;
                    tsmiDeleteArchive.Enabled = true;
                    DeleteArchive.Enabled = true;
                    ////this.txtProjectno.ReadOnly = false;
                    TabSelect(0);
                }
                if (tn.Level == 2)//��ʾPDF�ļ�
                {
                    tsmiFinalfile.Enabled = true;
                    btnMoveOut.Enabled = true;//�Ƴ��ļ�
                    tsmiMoveOut.Enabled = true;
                    menuMoveOut.Enabled = true;
                    TabSelect(1);
                }
            }
        }
        private void trvFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectNode = this.rightFileTree.SelectedNode;
            if (selectNode != null)
            {
                MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(selectNode.Name, Globals.ProjectNO);
                if (fileMDL != null)
                {
                    TabSelect(1);
                    ucFileInfo1.ShowData(selectNode);
                    ucFileInfo1.Enabled = false;
                    ShowPDF(Globals.ProjectPath + fileMDL.filepath);
                }
            }
        }
        private void SetDataFinalArchive(string archiveID)
        {
            ERM.MDL.T_Archive archiveMDL = archiveBLL.Find(archiveID);
            if (archiveMDL != null)
            {
                this.txtajtm.Text = archiveMDL.ajtm;
                this.txtLjr.Text = archiveMDL.ljr.ToString();
                this.cmbbzdw.Text = archiveMDL.bzdw;
                this.cmbjhlx.SelectedItem = archiveMDL.jhlx;
                this.cmbajlx.SelectedItem = archiveMDL.ajlx;
                this.cmbbgqx.Text = archiveMDL.bgqx;
                this.cmbmj.Text = archiveMDL.mj;
                this.txtOrderIndex.Text = archiveMDL.OrderIndex.ToString();
                this.txtbz.Text = archiveMDL.bz;
                this.dptzlrq.Text = archiveMDL.zlrq == null || archiveMDL.zlrq == "" ? "" : archiveMDL.zlrq;
            }
        }

        /// <summary>
        /// ������Ϣ�Գ���
        /// </summary>
        void AddFinalArchive()
        {
            TabSelect(0);
            BindData();
        }
        void SetGroupBox()
        {
            foreach (Control C in this.groupBoxArrich.Controls)
            {
                if (C is TextBox)
                {
                    if (C.Name != "txtProjectno")
                        C.Text = "";
                }
                if (C is ComboBox)
                {
                    if (C.Name == "cmbjhlx")
                        continue;
                    ComboBox c = (ComboBox)C;
                    if (c.Items.Count > 0)
                    {
                        c.SelectedIndex = 0;
                    }
                }
            }
        }

        private void tsmiAddArchive_Click(object sender, EventArgs e)
        {
            btnAddArchive.PerformClick();
        }
        private void tsmiMoveOut_Click(object sender, EventArgs e)
        {
            btnMoveOut.PerformClick();
        }
        private void tsmiDeleteArchive_Click(object sender, EventArgs e)
        {
            btnDeleteArchive.PerformClick();
        }
        private void tsmiClose_Click(object sender, EventArgs e)
        {
            btnClose.PerformClick();
        }
        //// �����ұ���
        private void btnAddArchive_Click(object sender, EventArgs e)
        {
            this.txtOrderIndex.Text = "1";
            tsbtnSave.Enabled = true;
            groupBoxArrich.Enabled = true;
            //groupBoxSenCass.Enabled = true;
            DialogResult drs = CheckSave();
            if (drs == DialogResult.Cancel) return;
            this.OpType = "Add";
            AddFinalArchive();
            SetGroupBox();
            //this.txtLjr.Text = Globals.Fullname.ToString();
            txtajtm.Text = Globals.Projectname;
            txtajtm.Focus();

            ReadWriteAppConfig config = new ReadWriteAppConfig();
            //string bzdw = config.Read("ArchDefalut_bzdw");
            //if (bzdw.Trim() != "")
            //    this.cmbbzdw.Text = bzdw;
            this.cmbbzdw.SelectedIndex = 0;

            ReadWriteAppConfig rwljr = new ReadWriteAppConfig();
            string ljrtmp = rwljr.Read("ArchDefalut_ljr");//������
            string shrtmp = rwljr.Read("ArchDefalut_shr");//�����
            if (ljrtmp != "" && txtLjr.Text.Trim() == "")
            {
                txtLjr.Text = ljrtmp;
            }

            string arch_projectno = config.Read("ArchDefalut_ProjectNO");
            if (arch_projectno.Trim() == "" ||
                arch_projectno.Trim() != Globals.ProjectNO.Trim())
                return;

            string ajtm = config.Read("ArchDefalut_ajtm");
            if (ajtm.Trim() != "")
                this.txtajtm.Text = ajtm;
            string jhlx = config.Read("ArchDefalut_jhlx");
            if (jhlx.Trim() != "")
                this.cmbjhlx.Text = jhlx;
            string bgqx = config.Read("ArchDefalut_bgqx");
            if (bgqx.Trim() != "")
                this.cmbbgqx.Text = bgqx;
            string mj = config.Read("ArchDefalut_mj");
            if (mj.Trim() != "")
                this.cmbmj.Text = mj;
            string bzksrq = config.Read("ArchDefalut_bzksrq");
            string bzjsrq = config.Read("ArchDefalut_bzjsrq");
            this.txtOrderIndex.Text = ((archiveBLL.GetMaxOrderIndex(Globals.ProjectNO)) + 1).ToString();
            this.dptzlrq.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            cmbmj.SelectedIndex = 1;
            cmbbgqx.SelectedIndex = 2;
        }
        /// <summary>
        /// ɾ�������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteArchive_Click(object sender, EventArgs e)
        {
            bool resuf_flg = false;
            if (TXMessageBoxExtensions.Question("ȷ��Ҫɾ��ѡ��İ����� ��") == DialogResult.Cancel)
            {
                return;
            }
            foreach (TreeNode node in this.leftArchiveTree.Nodes[0].Nodes)
            {
                if (node != null && node.Checked && node.Level == 1)
                {//ɾ��һ��������Ϣ
                    {
                        MDL.T_Archive archiveMDL = (new BLL.T_Archive_BLL()).Find(node.Name);
                        if (archiveMDL != null)
                        {
                            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                            IList<MDL.T_FileList> fileList = fileBLL.FindByArchiveID(archiveMDL.ArchiveID, Globals.ProjectNO);
                            foreach (MDL.T_FileList obj in fileList)
                            {
                                obj.ArchiveID = "";
                                obj.fileStatus = "4";
                                fileBLL.Update(obj);
                            }
                        }
                        resuf_flg = true;
                    }
                }
            }
           
            for (int i = 0; i < this.leftArchiveTree.Nodes[0].Nodes.Count; i++)
            {
                TreeNode node = this.leftArchiveTree.Nodes[0].Nodes[i];
                if (node != null && node.Checked && node.Level == 1)
                {//ɾ��һ��������Ϣ
                    (new BLL.T_Archive_BLL()).Delete(node.Name);
                    //�޸Ĵ˰�����֮������а�������
                    this.leftArchiveTree.Nodes[0].Nodes.Remove(node);//�Ӱ������Ƴ�
                    i--;
                }
            }

            if (resuf_flg)
            {
               // UpdateArchiveIndex(Globals.ProjectNO);
                treeFactory.ResetDS();//����״̬�ı仯����Ҫ����ȡ������״̬    
                LoadRightTree();
            }
            else
            {
                TXMessageBoxExtensions.Info("��ѡ��Ҫɾ���İ���!");
            }
            SetGroupBox();
        }
        /// <summary>
        /// ���� ������Ŀ�°������� ��ӡ˳��
        /// </summary>
        /// <param name="ProjectNO"></param>
        private void UpdateArchiveIndex(String ProjectNO)
        {
            IList<ERM.MDL.T_Archive> FinalArchives = archiveBLL.FindByProjectNO(ProjectNO);
            if (FinalArchives != null && FinalArchives.Count > 0)
            {
                int index = 1;
                foreach (ERM.MDL.T_Archive arch_info in FinalArchives)
                {
                    arch_info.OrderIndex = index;
                    archiveBLL.Update(arch_info);
                    index++;
                }
            }
        }
        /// <summary>
        /// ��߰������ļ� �Ƴ��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveOut_Click(object sender, EventArgs e)
        {
            removeOut_flg = false;
            CheckLeftTreeRemoveCount(leftArchiveTree.Nodes);
            if (!removeOut_flg)
            {
                //�ж��Ƿ�ѡ�����ļ�
                TXMessageBoxExtensions.Info("����ѡ��Ҫ�Ƴ����ļ�");
            }
            else
            {
                if (TXMessageBoxExtensions.Question("ȷ���Ƴ�ѡ�е��ļ��� ��") == DialogResult.Cancel)
                {
                    return;
                }

                isSelect_flg = string.Empty;
                RemoveLeftTreeViewCheckedNodes(leftArchiveTree.Nodes);
                treeFactory.ResetDS();//����״̬�ı仯����Ҫ����ȡ������״̬
                LoadRightTree();
            }
        }
        /// <summary>
        /// �жϱ���
        /// </summary>
        bool removeOut_flg = false;
        /// <summary>
        /// �Ƴ��ļ���ʱ���ж��Ƿ�ѡ�����ļ�
        /// </summary>
        /// <param name="rightTreeViewNodes">���TreeView��Nodes</param>
        private void CheckLeftTreeRemoveCount(TreeNodeCollection leftTreeViewNodes)
        {
            if (!removeOut_flg)
            {
                foreach (TreeNode remove_node in leftTreeViewNodes)
                {
                    if (remove_node.Nodes.Count > 0)
                    {
                        CheckLeftTreeRemoveCount(remove_node.Nodes);
                    }
                    else
                    {
                        if ((remove_node.Checked || remove_node.IsSelected) && remove_node.ImageIndex == 2)
                        {
                            removeOut_flg = true;
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// �Ƴ����TreeViewѡ���ļ� 2010-3-17 YQ
        /// </summary>
        /// <param name="rightTreeViewNodes">���TreeView��Nodes</param>        
        private void RemoveLeftTreeViewCheckedNodes(TreeNodeCollection leftTreeViewNodes)
        {
            foreach (TreeNode remove_node in leftTreeViewNodes)
            {
                if (remove_node.Nodes.Count > 0)
                {
                    RemoveLeftTreeViewCheckedNodes(remove_node.Nodes);
                }
                else
                {
                    if ((remove_node.Checked || remove_node.IsSelected) && remove_node.ImageIndex == 2)
                    {
                        // �Ƴ���ѡ�еĽڵ�
                        if (remove_node.IsSelected && string.IsNullOrEmpty(isSelect_flg))
                        {
                            isSelect_flg = remove_node.Name;

                            MDL.T_FileList fileMDL = fileList_bll.Find(remove_node.Name, Globals.ProjectNO);
                            fileMDL.fileStatus = "4";
                            fileMDL.ArchiveID = "";
                            fileList_bll.Update(fileMDL);
                        }
                        else if (remove_node.Checked)
                        {
                            MDL.T_FileList fileMDL = fileList_bll.Find(remove_node.Name, Globals.ProjectNO);
                            fileMDL.fileStatus = "4";
                            fileMDL.ArchiveID = "";
                            fileList_bll.Update(fileMDL);
                        }

                    }
                }
            }
            TreeNode archiveNode = null;
            string r_isSelct_flg = string.Empty;
            for (int i = 0; i < leftTreeViewNodes.Count; i++)
            {
                TreeNode remove_node = leftTreeViewNodes[i];
                if ((remove_node.Checked || remove_node.IsSelected) && remove_node.ImageIndex == 2)
                {
                    // �Ƴ���ѡ�еĽڵ�
                    if (remove_node.IsSelected && string.IsNullOrEmpty(r_isSelct_flg))
                    {
                        archiveNode = remove_node.Parent;
                        r_isSelct_flg = remove_node.Name;
                        leftArchiveTree.Nodes.Remove(remove_node);
                        i--;
                    }
                    else if (remove_node.Checked)
                    {
                        archiveNode = remove_node.Parent;
                        leftArchiveTree.Nodes.Remove(remove_node);
                        i--;
                    }
                }
            }

            //ͳ������ 
            if (archiveNode != null)
            {
                ArchiveTzzCount = 0;
                ArchiveZpzCount = 0;
                savaArchiveCount = 0;
                ArchiveDtCount = 0;
                ArchiveDpCount = 0;
                //��ȡ�˴������������
                GetArchiveLeftTreeCount(archiveNode.Nodes);

                //ͳ������ ���֣�ҳ�� ͼֽ���ţ� ͼƬ���ţ�
                ERM.MDL.T_Archive archive_mdl = archiveBLL.Find(archiveNode.Name);
                if (archive_mdl != null)
                {
                    archive_mdl.wzz = savaArchiveCount.ToString();
                    archive_mdl.tzz = ArchiveTzzCount.ToString();
                    archive_mdl.zpz = ArchiveZpzCount.ToString();
                    archive_mdl.dtz = ArchiveDtCount.ToString();
                    archive_mdl.dpz = ArchiveDpCount.ToString();
                    archiveBLL.Update(archive_mdl);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRightTree_Click(object sender, EventArgs e)
        {
            if (this.panelRight.Visible)
            {
                this.panelRight.Visible = false;
            }
            else
            {
                this.panelRight.Visible = true;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DialogResult drs = CheckSave();
            if (drs == DialogResult.Cancel) return;
            frmSelectFiles_Load(null, null);
        }
        private void menuAddArchive_Click(object sender, EventArgs e)
        {
            btnAddArchive.PerformClick();
        }
        private void menuMoveOut_Click(object sender, EventArgs e)
        {
            btnMoveOut.PerformClick();
        }
        private void DeleteArchive_Click(object sender, EventArgs e)
        {
            btnDeleteArchive.PerformClick();
        }
        private void tsBtnLeftNext_Click(object sender, EventArgs e)
        {
            TreeNode node = leftArchiveTree.SelectedNode;
            if (node == null)
            {
                node = leftArchiveTree.Nodes[0];
                leftArchiveTree.SelectedNode = node;
                return;
            }
            node.Expand();
            leftArchiveTree.SelectedNode = node.NextVisibleNode;
            leftArchiveTree.Focus();
        }
        private void tsbtnDown_Click(object sender, EventArgs e)
        {
            TreeNode moveNode = leftArchiveTree.SelectedNode;
            if (moveNode == null)
                return;
            TreeNode targetNode = moveNode.NextNode;
            if (targetNode == null)
                return;
            DialogResult drs = CheckSave();
            if (drs == DialogResult.Cancel) return;
            MoveNode(targetNode, moveNode, 0);
        }
        private void tsbtnUp_Click(object sender, EventArgs e)
        {
            TreeNode moveNode = leftArchiveTree.SelectedNode;
            if (moveNode == null)
                return;
            TreeNode targetNode = moveNode.PrevNode;
            if (targetNode == null)
                return;
            DialogResult drs = CheckSave();
            if (drs == DialogResult.Cancel) return;
            MoveNode(moveNode, targetNode, 1);
        }
        private void MoveNode(TreeNode SourNode, TreeNode TargetNode, int index)
        {
            if (SourNode.Level == 1)//�ƶ�����Ŀ¼
            {
                if (SourNode.TreeView == SourNode.TreeView)//ͬһ�����ƶ�
                {
                    TargetNode.Parent.Nodes.Insert(TargetNode.Index, (TreeNode)SourNode.Clone());
                    TargetNode.TreeView.SelectedNode = null;
                    TargetNode.TreeView.SelectedNode = TargetNode.Parent.Nodes[TargetNode.Index - index];
                    SourNode.Remove();//�Ƴ�ԭ�ڵ�
                    archiveBLLEx.MoveAFinalArchiveOrderindex(TargetNode);//�ƶ���������������˳��
                    CheckEnable();
                }
            }
            else//�п��ܵ����ļ����� PDF ���� ʵ�ʵ��������ļ��ڰ����е�˳�� ����ͬһ�������µĵ����ļ�˳��
            {
                if (TargetNode.TreeView == SourNode.TreeView)//ͬһ�����ƶ�
                {
                    TargetNode.Parent.Nodes.Insert(TargetNode.Index, (TreeNode)SourNode.Clone());//�����ڲ��ļ�����
                    TargetNode.Expand();
                    TargetNode.TreeView.SelectedNode = TargetNode.Parent.Nodes[TargetNode.Index - index];
                    TreeNode tn = SourNode.Parent;
                    string ArchiveID = tn.Tag.ToString();
                    SourNode.Remove();//�Ƴ�ԭ�ڵ�

                    archiveBLLEx.MoveFinalAttachment_ArchIndex(TargetNode, ArchiveID, Globals.ProjectNO);
                    CheckEnable();
                }
            }
        }
        /// <summary>
        /// ��beforeselectһ������Ƿ��Ѿ����޸�
        /// </summary>
        /// <returns>����yes��ʾͨ�� no��ʾ��Ҫ���¼������� cancelȡ���¼� </returns>
        private DialogResult CheckSave()
        {
            return DialogResult.OK;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                Isfile = true;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                Isfile = false;
            }
        }
        /// <summary>
        /// �����ұ�TreeViewȫѡ״̬
        /// </summary>
        /// <param name="rightTreeNodes">TreeView��Nodes����</param>
        /// <param name="checkState">ѡ��״̬</param>
        private void SetTreeViewCheckState(TreeNodeCollection rightTreeNodes, bool checkState)
        {
            foreach (TreeNode r_Node in rightTreeNodes)
            {
                r_Node.Checked = checkState;
                if (r_Node.Nodes.Count > 0)
                {
                    SetTreeViewCheckState(r_Node.Nodes, checkState);
                }
            }
        }
        /// <summary>
        /// TreeView�ڵ�ѡ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckControl(e);
        }
        /// <summary>
        /// ϵ�нڵ� Checked ���Կ���
        /// </summary>
        /// <param name="e"></param>
        public void CheckControl(TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node != null && !Convert.IsDBNull(e.Node))
                {
                    CheckParentNode(e.Node);
                    if (e.Node.Nodes.Count > 0)
                    {
                        CheckAllChildNodes(e.Node, e.Node.Checked);
                    }
                }
            }
        }
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

        #region ˽�з���

        /// <summary>
        /// �ı������ӽڵ��״̬
        /// </summary>
        /// <param name="pn"></param>
        /// <param name="IsChecked"></param>
        private void CheckAllChildNodes(TreeNode pn, bool IsChecked)
        {
            foreach (TreeNode tn in pn.Nodes)
            {
                tn.Checked = IsChecked;

                if (tn.Nodes.Count > 0)
                {
                    CheckAllChildNodes(tn, IsChecked);
                }
            }
        }

        /// <summary>
        /// �ı丸�ڵ��ѡ��״̬���˴�Ϊ�����ӽڵ㲻ѡ��ʱ��ȡ�����ڵ�ѡ�У����Ը�����Ҫ�޸�
        /// </summary>
        /// <param name="curNode"></param>
        private void CheckParentNode(TreeNode curNode)
        {
            bool bChecked = false;

            if (curNode.Parent != null)
            {
                foreach (TreeNode node in curNode.Parent.Nodes)
                {
                    if (node.Checked)
                    {
                        bChecked = true;
                        break;
                    }
                }

                if (bChecked)
                {
                    curNode.Parent.Checked = true;
                    CheckParentNode(curNode.Parent);
                }
                else
                {
                    curNode.Parent.Checked = false;
                    CheckParentNode(curNode.Parent);
                }
            }
        }

        #endregion

        private void frmZJ_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
            this.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        /// <summary>
        /// ������ճ����ѡ�е��б�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPaste_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvFileList.Rows.Count; i++)
            {
                if (gvFileList.Rows[i].Cells["clm_Select"].Value == null
                    || gvFileList.Rows[i].Cells["clm_Select"].Value.ToString().Equals("False"))
                    continue;
                gvFileList.Rows[i].Cells["clm_FileID"].Value = gvFileList.Rows[i].Cells["clm_FileID"].Value;
                gvFileList.Rows[i].Cells["clm_FileID"].Tag = gvFileList.Rows[i].Cells["clm_FileID"].Tag;
                gvFileList.Rows[i].Cells["clm_ArchiveIndex"].Value = gvFileList.Rows[i].Cells["clm_ArchiveIndex"].Value;
                if (txtwjtm.Text.Trim() != "")
                {
                    gvFileList.Rows[i].Cells["clm_Wjtm"].Value = txtwjtm.Text.Trim();
                }
                if (txtzrr.Text.Trim() != "")
                {
                    gvFileList.Rows[i].Cells["clm_ZRR"].Value = txtzrr.Text.Trim();
                }
                if (txtkssj.TextEx.Trim() != "" && txtjssj.TextEx.Trim() != "")
                {
                    if (DateTime.Parse(txtkssj.TextEx.Trim()) > DateTime.Parse(txtjssj.TextEx.Trim()))
                    {
                        TXMessageBoxExtensions.Info("�γɿ�ʼʱ�䲻�ܴ����γɽ���ʱ�䣡");
                        txtjssj.TextEx = "";
                        this.txtjssj.Focus();
                        return;
                    }
                    else
                    {
                        gvFileList.Rows[i].Cells["clm_CreateDate"].Value = txtkssj.TextEx.Trim() + "��" + txtjssj.TextEx.Trim();
                    }
                }
                else if (txtkssj.TextEx.Trim() != "")
                {
                    gvFileList.Rows[i].Cells["clm_CreateDate"].Value = txtkssj.TextEx.Trim();
                }
                else if (txtjssj.TextEx.Trim() != "")
                {
                    gvFileList.Rows[i].Cells["clm_CreateDate"].Value = txtjssj.TextEx.Trim();
                }
                gvFileList.Rows[i].Cells["clm_sl"].Value = gvFileList.Rows[i].Cells["clm_sl"].Value;
            }

            TXMessageBoxExtensions.Info("����ճ���ɹ�!");
            txtwjtm.Text = "";
            txtzrr.Text = "";
            txtkssj.TextEx = "";
            txtjssj.TextEx = "";
        }
        /// <summary>
        /// ���Ƶ�λ��֤
        /// </summary>
        /// <returns></returns>
        private bool cmbbzdwValidating()
        {
            bool flag = true;
            IList<T_Units> itu = (new BLL.T_Units_BLL()).FindBydwmc(cmbbzdw.Text.Trim());
            if (itu == null || itu.Count <= 0)
            {
                TXMessageBoxExtensions.Info("��λ������");
                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// ��ӡ����Ŀ¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsPrintJNML_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.leftArchiveTree.SelectedNode;
            theNode = theNode.FirstNode;
            if (theNode == null)
            {
                TXMessageBoxExtensions.Info("��ʾ����ѡ�����Ŀ¼���д�ӡ��");
                return;
            }

            if (theNode.Level == 2)
            {
                string fileID = theNode.Name;
                MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fileID, Globals.ProjectNO);
                if (fileMDL1.fileStatus != "6")
                {
                    TXMessageBoxExtensions.Info("��ʾ��û�����,�������ӡ��");
                    return;
                }
                string archiveID = fileMDL1.ArchiveID;
                List<string> list = new List<string>();
                list.Add(archiveID);
                DataView dv = finalArchive.Print_Jnml(list);

                print_common.DoPrint("Archivemulu", dv);
            }
            else
            {
                TXMessageBoxExtensions.Info("��ʾ����ѡ�����Ŀ¼���д�ӡ��");
            }
        }



        /// <summary>
        /// ��ӡ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsPrintAJFM_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.leftArchiveTree.SelectedNode;
            theNode = theNode.FirstNode;
            if (theNode == null)
            {
                TXMessageBoxExtensions.Info("��ʾ����ѡ�����Ŀ¼���д�ӡ��");
                return;
            }
            if (theNode.Level == 2)
            {
                //string reportPath = Application.StartupPath + @"\Reports\Archivefengpi.mrt";
                //frmReports = new frmReport(reportPath);
                //frmReports.ShowDialog();
              DoPrint(theNode);
            }
            else
            {
                TXMessageBoxExtensions.Info("��ʾ����ѡ�����Ŀ¼���д�ӡ��");
            }
        }

        /// <summary>
        /// ��ӡ�����Ƥ
        /// </summary>
        /// <param name="theNode"></param>
        /// <param name="Print"></param>
        /// <param name="SelectCount"></param>
        static int currentIndex = 1;//��������
        private void DoPrint(TreeNode theNode)
        {

            string fileID = theNode.Name;
            MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fileID, Globals.ProjectNO);
            if (fileMDL1.fileStatus != "6")
            {
                TXMessageBoxExtensions.Info("��ʾ��û�����,�������ӡ��");
                return;
            }
            string archiveID = fileMDL1.ArchiveID;
            List<string> list = new List<string>();
            list.Add(archiveID);
            DataView dv = finalArchive.Print_Ajfm(list, Globals.ProjectNO.ToString());
           // dv.Table.Columns.Add("currentIndex");
            //��ӵ�ǰ������
           // dv.Table.Rows[0]["currentIndex"] = currentIndex.ToString();
            print_common.DoPrint("Archivefengpi", dv);
            //print_common.MergePdf(SelectCount);
        }

        private void txtdh_Leave(object sender, EventArgs e)
        {
            TXMessageBoxExtensions.Info("1");
        }

        private void dptbzksrq_Leave(object sender, EventArgs e)
        {
        }

        private void dptbzjsrq_Leave(object sender, EventArgs e)
        {

        }

        private void txtkssj_Leave(object sender, EventArgs e)
        {

        }

        private void txtjssj_Leave(object sender, EventArgs e)
        {

        }

        private void txtajtm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtajtm.SelectAll();
        }

        private void drpFileStaus0_Click(object sender, EventArgs e)
        {
            treeFactory.GetTree(rightFileTree, Globals.ProjectNO, "filestatus=4", false, false, 3, false, 3);
            this.drpFileStatus.Text = drpFileStaus0.Text;
        }

        private void drpFileStaus7_Click(object sender, EventArgs e)
        {
            treeFactory.GetTree(rightFileTree, Globals.ProjectNO, " filestatus=4 and IsUseDefined = 0", false, false, 3, false, 0);
            this.drpFileStatus.Text = drpFileStaus7.Text;
        }

        private void drpFileStaus8_Click(object sender, EventArgs e)
        {
            treeFactory.GetTree(rightFileTree, Globals.ProjectNO, " filestatus=4 and IsUseDefined = 1", false, false, 3, false, 1);
            this.drpFileStatus.Text = drpFileStaus8.Text;
        }

        private void tsPrintBKB_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.leftArchiveTree.SelectedNode;
            theNode = theNode.FirstNode;
            if (theNode == null) { TXMessageBoxExtensions.Info("��ʾ����ѡ�����Ŀ¼���д�ӡ��"); return; }
              
            if (theNode.Level == 2)
            {
                string fileID = theNode.Name;
                MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fileID, Globals.ProjectNO);
                if (fileMDL1.fileStatus != "6")
                {
                    TXMessageBoxExtensions.Info("��ʾ��û�����,�������ӡ��");
                    return;
                }
                string archiveID = fileMDL1.ArchiveID;
                List<string> list = new List<string>();
                list.Add(archiveID);
                DataView dv = finalArchive.Print_Bkb(list);
                archiveBLL.UpdateByBK(archiveBLL.Find(archiveID));
                print_common.DoPrint("juanneibeikao", dv);
            }
            else
            {
                TXMessageBoxExtensions.Info("��ʾ����ѡ�����Ŀ¼���д�ӡ��");
            }
        }
        /// <summary>  
        private void tsExportExcelArchive_Click(object sender, EventArgs e)
        {
            string projectcode = "";
            string fileID = "";
            TreeNode theNode = this.leftArchiveTree.SelectedNode;
            theNode = theNode.FirstNode;

            if (theNode == null)
            {
                TXMessageBoxExtensions.Info("��ʾ����ѡ�����Ŀ¼���е�����");
                return;
            }
              
            if (theNode.Level == 1)
            {
                projectcode = Globals.ProjectNO;
            }
            else if (theNode.Level == 2)
            {
                fileID = theNode.Parent.Name;
            }
            DataTable dt = (new CBLL.PrintFinalArchive()).ExportArchive(fileID, projectcode);
            ExcelHelp.DataTableToExcel(dt, "����Ŀ¼", Globals.Projectname + "���̵�������Ŀ¼", Globals.Projectname);
        }

        private void tsExportJNML_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.leftArchiveTree.SelectedNode;
            
            theNode = theNode.FirstNode;
            if (theNode == null)
            {
                TXMessageBoxExtensions.Info("��ʾ����ѡ�����Ŀ¼���е�����");
                return;
            }
               
            if (theNode.Level == 2)
            {
                string fileID = theNode.Name;
                MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fileID, Globals.ProjectNO);
                if (fileMDL1.fileStatus != "6")
                {
                    TXMessageBoxExtensions.Info("��ʾ��û�����,����������");
                    return;
                }
                string archiveID = fileMDL1.ArchiveID;

                DataTable dt = finalArchive.Export_Jnml(archiveID).ToTable();
                dt = finalArchive.JNMLData(dt, "export");
                ExcelHelp.DataTableToExcelTemplet(dt, "����Ŀ¼", theNode.Parent.Text);
            }
            else
            {
                TXMessageBoxExtensions.Info("��ʾ����ѡ�����Ŀ¼���е�����");
            }
        }

        private void dptzlrq_Leave(object sender, EventArgs e)
        {
        }
    }
}
