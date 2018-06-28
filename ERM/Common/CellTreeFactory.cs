using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Digi.DBUtility;
using System.Text.RegularExpressions;
using ERM.CBLL;
using TX.Framework.WindowUI.Controls;

namespace ERM.UI
{
    //Leo Test
    public class TreeFactory : ITreeFactory
    {
        ERM.CBLL.CellTreesData treesData = new ERM.CBLL.CellTreesData();
        /// <summary>
        /// ����ģ��ͼ��
        /// </summary>
        /// <param name="Nodes"></param>
        public void SetIcon(TreeNodeCollection Nodes)
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i].ImageIndex == 2 || Nodes[i].ImageIndex == 4 || Nodes[i].ImageIndex == 5)
                {
                    this.SetNodeIcon((TreeNodeEx)(Nodes[i]));
                }
                if (Nodes[i].Nodes.Count > 0)
                {
                    SetIcon(Nodes[i].Nodes);
                }
            }
        }
        public DataSet GetDS(string projectNo, string KeyString)
        {
            return null;
        }
        /// <summary>
        /// ����ģ��ͼ��
        /// </summary>
        /// <param name="NewNode"></param>
        /// <param name="cbll"></param>
        /// <param name="FileStatus"></param>
        /// <returns></returns>
        public void SetNodeIcon(TreeNodeEx NewNode)
        {
            CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            if (NewNode.Nodes.Count > 0 && NewNode.ImageIndex == 1)
            {
                for (int i = 0; i < NewNode.Nodes.Count; i++)
                {
                    TreeNodeEx StatusNode = (TreeNodeEx)NewNode.Nodes[i];
                    SetImageIndex(cbll, StatusNode);
                }
            }
            else
            {
                SetImageIndex(cbll, NewNode);
            }
        }
        private void SetImageIndex(CBLL.FileRegist cbll, TreeNodeEx StatusNode)
        {
            string FileStatus = null;
            FileStatus = cbll.GetRegistFileStatus(OpeartPath(StatusNode), Globals.ProjectNO);
            if (!String.IsNullOrEmpty(FileStatus))
            {
                if (FileStatus.Equals("4"))
                {
                    StatusNode.ImageIndex = 4;
                    StatusNode.SelectedImageIndex = 4;
                }
                if (FileStatus.Equals("1"))
                {
                    StatusNode.ImageIndex = 5;
                    StatusNode.SelectedImageIndex = 5;
                }
                if (FileStatus.Equals("5"))
                {
                    StatusNode.ImageIndex = 4;
                    StatusNode.SelectedImageIndex = 4;
                }
            }
        }

        public void RefreshNode(TreeNodeEx Node, bool withImage, string projectNo, bool IsCount, bool isAll, CellCreate enumTree)
        {
        }
        private DataTable tempDS = null;
        private void GetAllData()
        {
            if (tempDS == null)
            {
                tempDS = new DataTable();
                BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                IList<MDL.T_FileList> fileList = fileBLL.FindByProjectNO(Globals.ProjectNO);
                tempDS = MyCommon.ToDataTable<MDL.T_FileList>(fileList);
            }
        }
        public void ResetDS()
        {
            tempDS = null;
        }

        /// <summary>
        /// ����TreeNodeEx�ĸ��ڵ��Tag
        /// </summary>
        /// <param name="obj">���ڵ�</param>
        /// <param name="AllOrHasOrNotFlag">���ڵ��Tag���</param>
        private void UpdateParentTag(TreeNodeEx obj, int AllOrHasOrNotFlag)
        {
            if (obj.Parent != null)
            {
                obj.Parent.Tag = AllOrHasOrNotFlag;
                UpdateParentTag((TreeNodeEx)obj.Parent, AllOrHasOrNotFlag);
            }
        }
        public string GetFinal_fileCount(TreeNodeEx node)
        {
            return "";
        }
        /// <summary>
        /// ȥ��·���е�[0],*
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public string OpeartPath(TreeNodeEx node)
        {
            return "";
        }
        public void GetCelllFileList(TreeView tv, string FileID)
        {
            IList<MDL.T_CellAndEFile> dv = (new BLL.T_CellAndEFile_BLL()).FindByFileID(FileID, Globals.ProjectNO, 0);
            tv.Nodes.Clear();
            if (dv.Count == 0)
            {
                //����ģ��� ����м�¼����ӹ��� ���û�оͲ���� ��ʾ��
                IList<MDL.T_CellFileTemplate> EFTemplate_List =
                    (new BLL.T_CellFileTemplate_BLL()).FindByFileID(FileID);
                if (EFTemplate_List != null && EFTemplate_List.Count > 0)
                {
                    foreach (MDL.T_CellFileTemplate c_template in EFTemplate_List)
                    {
                        MDL.T_CellAndEFile add_MDL = new ERM.MDL.T_CellAndEFile();
                        add_MDL.CellID = c_template.CellID;
                        add_MDL.ProjectNO = Globals.ProjectNO;
                        add_MDL.FileID = c_template.FileID;
                        add_MDL.parentid = c_template.parentid;
                        add_MDL.codeno = c_template.codeno;
                        add_MDL.title = c_template.title;
                        add_MDL.filepath = "";
                        add_MDL.isvisible = 1;
                        add_MDL.orderindex = c_template.orderindex;
                        (new BLL.T_CellAndEFile_BLL()).Add(add_MDL);

                    }

                    dv = (new BLL.T_CellAndEFile_BLL()).FindByFileID(FileID, Globals.ProjectNO, 0);
                }
            }
            if (dv.Count == 0)
                return;
            //tv.BeginUpdate();
            foreach (MDL.T_CellAndEFile obj in dv)
            {
                //�ж�ģ���ļ��������Ƶ���û���ļ������
                //ERM.MDL.T_CellFileTemplate cellFileTemplatModel =
                //    (new BLL.T_CellFileTemplate_BLL()).Find(obj.CellID);
                //if (cellFileTemplatModel != null)
                //{
                //    string CelllTplFile = Application.StartupPath + "\\Template" + cellFileTemplatModel.filepath;
                //    if (!System.IO.File.Exists(CelllTplFile))
                //    {
                //        continue;
                //    }
                //}
                //�ж��ļ���׺�Ƿ����
                if (obj.filepath == null || obj.filepath == "" || MyCommon.CheckFillSuffix(obj.filepath, ".cll"))
                {
                    TreeNodeEx node = new TreeNodeEx();
                    node.Name = obj.CellID;
                    node.NodeValue = obj.filepath == null ? "" : obj.filepath;
                    node.Text = obj.title;
                    node.Tag = 0;//new string[] { obj.customdefine"].ToString(), drv["docstatus"].ToString() };
                    int imageindex = 3;
                    //if (Convert.ToInt16(obj.DoStatus) > 0)
                    //    imageindex = 4;
                    node.ImageIndex = imageindex;
                    node.SelectedImageIndex = imageindex;

                    tv.Nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// ��TreeView�ؼ���ѡ����һ���ڵ�
        /// </summary>
        /// <param name="treeView">TreeView</param>
        public void SelectNextNode(TreeView treeView)
        {
            if (treeView.Nodes.Count > 0)
            {
                TreeNode node = treeView.SelectedNode;
                if (node == null)
                {
                    node = treeView.Nodes[0];
                    treeView.SelectedNode = node;
                    return;
                }
                node.Expand();
                treeView.SelectedNode = node.NextVisibleNode;
                treeView.Focus();
            }
        }
        /// <summary>
        /// ��TreeView�ؼ���ѡ����һ���ڵ�
        /// </summary>
        /// <param name="treeView">TreeView</param>
        public void SelectPrevNode(TreeView treeView)
        {
            if (treeView.Nodes.Count > 0)
            {
                TreeNode FirstNode = treeView.Nodes[0];
                TreeNode tempNode;
                TreeNode node = treeView.SelectedNode;
                if (node == null)
                {
                    treeView.SelectedNode = FirstNode;
                    return;
                }
                TreeNode PrevVisibleNode = node.PrevVisibleNode;
                if (PrevVisibleNode == null || PrevVisibleNode == FirstNode)
                {
                    treeView.SelectedNode = FirstNode;
                    return;
                }
                tempNode = PrevVisibleNode;
                if (PrevVisibleNode == node.Parent)
                {
                    treeView.SelectedNode = tempNode;
                    return;
                }
                if (tempNode == null)
                {
                    treeView.SelectedNode = FirstNode;
                    return;
                }
                int childNodes = tempNode.GetNodeCount(false);
                if (childNodes == 0)
                {
                    treeView.SelectedNode = tempNode;
                    return;
                }
                else
                {
                    PrevVisibleNode = tempNode;
                    while (true)
                    {
                        tempNode = PrevVisibleNode.LastNode;
                        if (tempNode == null) break;
                        PrevVisibleNode = tempNode;
                    }
                    treeView.SelectedNode = PrevVisibleNode;
                }
                treeView.Focus();
            }
        }
        /// <summary>
        /// ��TreeView�ؼ���Ѱ�ҵ�NodeID,Ȼ��ѡ�иýڵ�
        /// </summary>
        /// <param name="tv">TreeView�ؼ�</param>
        /// <param name="NodeID">NodeID,��ֵ��Node.Name��</param>
        public void SelectNode(TreeView tv, string NodeID)
        {
            TreeNode[] nodes = tv.Nodes.Find(NodeID, true);
            if (nodes != null && nodes.Length > 0)
            {
                tv.Visible = false;
                tv.SelectedNode = tv.Nodes[0];  //��ѡ�����ڵ㣬��֤AfterSelect�¼�����
                tv.SelectedNode = nodes[nodes.Length - 1];
                if (nodes[nodes.Length - 1].Nodes != null && nodes[nodes.Length - 1].Nodes.Count > 0)
                {
                    nodes[nodes.Length - 1].Expand();
                }
                tv.Visible = true;
                nodes[nodes.Length - 1].EnsureVisible();
            }
            tv.Focus();
        }
        /// <summary>
        /// ��TreeView�ؼ���Ѱ�ҵ�NodeID,Ȼ��ѡ�иýڵ�
        /// </summary>
        /// <param name="tv">TreeView�ؼ�</param>
        /// <param name="NodeID">NodeID,��ֵ��Node.Name��</param>
        public void SelectNodeImage(TreeView tv, string NodeID)
        {
            TreeNode[] nodes = tv.Nodes.Find(NodeID, true);
            if (nodes != null && nodes.Length > 0)
            {
                tv.Visible = false;

                tv.SelectedNode = nodes[0];  //��ѡ�����ڵ㣬��֤AfterSelect�¼�����
                nodes[nodes.Length - 1].ImageIndex = (CheckEFileByFileID(nodes[nodes.Length - 1].Name, 1) == true) ? 7 : 2;//�ж��Ƿ��е����ļ�
                nodes[nodes.Length - 1].SelectedImageIndex = nodes[nodes.Length - 1].ImageIndex;
                tv.Visible = true;
            }
            tv.Focus();
        }
        /// <summary>
        /// ѡ�нڵ㣬ֱ�Ӵ�treeview��ѡ�񣬶�����treeview�ĵ�һ���ڵ���ѡ��
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="nodeid"></param>
        public void SelectNode2(TreeView tv, string nodeid)
        {
            TreeNode[] nodes = tv.Nodes.Find(nodeid, true);
            if (nodes != null && nodes.Length > 0)
            {
                tv.Visible = false;
                tv.SelectedNode = null;
                tv.SelectedNode = nodes[0];
                if (nodes[0].Nodes != null && nodes[0].Nodes.Count > 0)
                {
                    nodes[0].Expand();
                }
                tv.Visible = true;
                nodes[0].EnsureVisible();
            }
            tv.Focus();
        }
        /// <summary>
        /// ɾ��ĳһ�ڵ㼰�����ӽڵ㣬����ʱ����ʹCell�ؼ��򿪵��ǿձ�
        /// ���ǲ���Ҫɾ���Ľڵ��е�ĳһ����Է�ɾ�������ļ�ʧ��
        /// </summary>
        /// <param name="theNode"></param>
        /// <param name="tableName"></param>
        /// <param name="projectNo"></param>
        public void DelNodes(TreeNodeEx theNode, string tableName, string CellTable, string projectNo)
        {
            string sql = "";
            if (theNode.ImageIndex == ImageLists.Root)
            {
                sql = "delete from " + tableName;
                if (projectNo != "")
                {
                    sql += " where ProjectNO='" + projectNo + "'";
                }
                if (projectNo != "")
                {
                    MyCommon.DeleteAndCreateEmptyDirectory(Globals.ProjectPath, false);
                    MyCommon.DeleteAndCreateEmptyDirectory(Globals.ProjectPath, true);
                }
                return;
            }
            this.DelNode(theNode, tableName, CellTable, projectNo);
        }

        ERM.BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
        private void DelNode(TreeNodeEx theNode, string tableName, string celltable, string projectNo)
        {
            if (theNode.ImageIndex == 2)//ͼƬΪ2����ģ�壬Ҫɾ���ڵ��������û����
            {
                cellBLL.Delete(theNode.Name, Globals.ProjectNO);
                DataSet ds = treesData.DelArchiveData(theNode.Name, projectNo);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (System.IO.File.Exists(Globals.ProjectPath + dr["filepath"].ToString()))
                    {
                        System.IO.File.Delete(Globals.ProjectPath + dr["filepath"].ToString());
                    }
                }
            }
            else if (theNode.ImageIndex == 1)//ͼ��Ϊ1��Ŀ¼Ҫ����ɾ��
            {
                BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                fileBLL.Delete(theNode.Name, projectNo);
                for (int i = 0; i < theNode.Nodes.Count; i++)
                {
                    DelNode((TreeNodeEx)theNode.Nodes[i], tableName, celltable, projectNo);
                }
            }
            else if (theNode.ImageIndex == 3)//ͼ��Ϊ3���û��ı��
            {
            }
        }
        /// <summary>
        /// �������� TreeView �� ImageList
        /// </summary>
        /// <returns>ImageList</returns>
        public ImageList CreateTreeImageList()
        {
            ImageList imageList1 = new ImageList();
            imageList1.TransparentColor = Color.Magenta;
            imageList1.ColorDepth = ColorDepth.Depth24Bit;
            imageList1.Images.Add(Properties.Resources.tree_home);//��һ��Ŀ¼
            imageList1.Images.Add(Properties.Resources.tree_folder);//�ļ���
            imageList1.Images.Add(Properties.Resources.tree_file);//�ļ�
            imageList1.Images.Add(Properties.Resources.tree_cell);//���
            imageList1.Images.Add(Properties.Resources.tree_cell_lock);//������
            imageList1.Images.Add(Properties.Resources.tree_file_s);//�ļ�����
            imageList1.Images.Add(Properties.Resources.tree_folder_s);//�ļ��д���
            imageList1.Images.Add(Properties.Resources.tree_efile);//�ļ��Ǽ�
            return imageList1;
        }
        private List<string> FilterDataByPath(DataRow[] rows, List<string> list, DataSet NewData)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                if (!list.Contains(rows[i]["treepath"].ToString()))
                {
                    list.Add(rows[i]["treepath"].ToString());
                }
                if (!rows[i]["ID"].ToString().Equals("01"))
                {
                    DataRow[] NewRows = NewData.Tables[0].Select("treepath = '" + rows[i]["ParentPath"].ToString() + "'");
                    list = FilterDataByPath(NewRows, list, NewData);
                }
            }
            return list;
        }
        /// <summary>
        /// ����ID �趨�����¼�����ļ�������
        /// </summary>
        /// <param name="fileid">�ļ�ID</param>
        private string SetTreeNodeExText(string fileid)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            ERM.MDL.T_FileList fileList = fileBLL.Find(fileid, Globals.ProjectNO);
            if (fileList == null)
            {
                return "";
            }
            else
            {
                return fileList.wjtm;
            }
        }
        /// �õݹ�ķ�����ȡ��
        /// </summary>
        /// <param name="treeView">��Ҫ�����ݰ󶨵���TreeView�ؼ�</param>
        /// <param name="tableName">�����������ڵı�</param>
        public void GetFileTree(TreeView treeView, string fileRecording_templet, string cell_tempet, bool withImage, string projectNo, bool IsCount, bool isAll, FileStatus treeEnum)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="fileRecording_templet"></param>
        /// <param name="cell_tempet"></param>
        /// <param name="withImage"></param>
        /// <param name="projectNo"></param>
        /// <param name="IsCount"></param>
        /// <param name="isAll"></param>
        public void AddFileNode(TreeNodeEx Node, string projectNo)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="withImage"></param>
        /// <param name="projectNo"></param>
        /// <param name="IsCount"></param>
        /// <param name="isAll"></param>
        public void RefreshFileNode(TreeNodeEx Node, bool withImage, string projectNo, bool IsCount, bool isAll, FileStatus treeEnum, bool IsRush)
        {
        }
        /// <summary>
        /// ��ȡ���Ľڵ㣬��������������
        /// </summary>
        /// <param name="nodes">TreeNodeCollection</param>
        /// <param name="nodeID">Ҫ��ѯ�Ľڵ�</param>
        private void LoadFileChildNodes(TreeNodeCollection nodes, string parentID, bool withImage, bool IsCount, bool isAll)
        {
        }
        public void LoadRightTree(string ProjectNO, TreeView trvFile)
        {
        }
        void GetDataTableParentId(DataTable tb, string projectNo, string ParentId, DataTable Returntb, DataSet dsFileRecording_Templet, string ProjectNO)
        {
        }
        void BindDataParentId(DataTable Returntb, TreeNode tn, string ParentId, DataSet dsFinal_File)
        {
        }

        #region ================================ �ļ��Ǽ���ͳ�Ƶ����ļ����� �������� ======================================================
        public void CreatemyFavoritesNode(TreeNodeEx pNode)
        {
            try
            {
                /*
                 * ��ȡϵͳ���Ѿ�Copy����Դ�ñ��ļ����� 
                 * �����������·�����ļ��б�
                 */
                pNode.Nodes.Clear();
                MyFavorites objMyFavorites = new MyFavorites();
                Dictionary<string, string> hTable = objMyFavorites.Read();//��ȡϵͳ���Ѿ�Copy����Դ�ñ��ļ�����

                foreach (KeyValuePair<string, string> obj in hTable)
                {
                    string wjtm = SetTreeNodeExText(obj.Key);
                    if (wjtm == "")
                        continue;
                    TreeNodeEx childNode = new TreeNodeEx();
                    childNode.NodeValue = obj.Value;
                    childNode.NodeKey = obj.Key;
                    childNode.Text = wjtm;//i.ToString() + "." +SetTreeNodeExText(obj.Key);
                    childNode.Name = obj.Key;
                    childNode.ImageIndex = 2;
                    childNode.SelectedImageIndex = 2;
                    pNode.Nodes.Insert(0, childNode);//����
                }
                int index_flg = 1;
                foreach (TreeNode node_flg in pNode.Nodes)
                {
                    node_flg.Text = index_flg + "." + node_flg.Text;
                    index_flg++;
                }
            }
            catch { }
        }
        /// <summary>
        /// ���ݹ��̰�TreeView ��Ҫ�����ļ��Ǽ���ͳ�Ƶ����ļ�����
        /// </summary>
        /// <param name="treeView">��ʾ��TreeView�ؼ�</param>
        /// <param name="withImage">�������趨ImageIndex��SelectedImageIndex���жϱ���������������</param>
        /// <param name="projectNo">����ID</param>
        /// <param name="AllOrHasOrNotFlag">�ļ�״̬��0ȫ�� 1�޵����ļ� 2�е����ļ� 3δ�Ǽ��ļ� 4�ѵǼ��ļ� 5δ��� 6�����</param>
        /// <param name="is_flg">���ļ��Ǽ����õı�Ǳ��� �����ļ��Ǽ�ҳ�����ת��˷���</param>
        public void GetTree(TreeView treeView, string projectNo, string strSqlWhere, bool isShowmyFavorites, bool isImageIndex, int showImgeflg, bool isShowEFileCount, int IsUseDefined=1)
        {
            treeView.Nodes.Clear();
            if (isShowmyFavorites)
            {
                try
                {
                    /*
                     * ��ȡϵͳ���Ѿ�Copy����Դ�ñ��ļ����� 
                     * �����������·�����ļ��б�
                     */
                    TreeNodeEx myFavoritesNode = new TreeNodeEx();
                    myFavoritesNode.Text = "�����¼�����ļ�";
                    myFavoritesNode.Tag = "";//���Ϊ����Ҫ����¼�
                    int iPos1 = treeView.Nodes.Add(myFavoritesNode);
                    TreeNodeEx pNode1 = (TreeNodeEx)treeView.Nodes[iPos1];
                    MyFavorites objMyFavorites = new MyFavorites();
                    Dictionary<string, string> hTable = objMyFavorites.Read();//��ȡϵͳ���Ѿ�Copy����Դ�ñ��ļ�����
                    int i = hTable.Count;

                    foreach (KeyValuePair<string, string> obj in hTable)
                    {
                        string wjtm = SetTreeNodeExText(obj.Key);
                        if (wjtm == "")
                            continue;
                        TreeNodeEx childNode = new TreeNodeEx();
                        childNode.NodeValue = obj.Value;
                        childNode.NodeKey = obj.Key;
                        childNode.Text = wjtm;
                        childNode.Name = obj.Key;
                        childNode.ImageIndex = 2;
                        childNode.SelectedImageIndex = 2;
                        i--;
                        pNode1.Nodes.Insert(0, childNode);//����
                    }
                    int index_flg = 1;
                    foreach (TreeNode node_flg in pNode1.Nodes)
                    {
                        node_flg.Text = index_flg + "." + node_flg.Text;
                        index_flg++;
                    }
                }
                catch { }
            }

            if (strSqlWhere != "")
            {
                strSqlWhere += " AND ";
            }
            strSqlWhere += " isvisible=1 ";

            if (showImgeflg == 2 || showImgeflg == 3)
            {
                InitGDTree(projectNo, strSqlWhere, treeView, isImageIndex, showImgeflg, isShowEFileCount, IsUseDefined);
            }
            else
                InitTree(projectNo, strSqlWhere, treeView, isImageIndex, showImgeflg, isShowEFileCount, IsUseDefined);

            foreach (TreeNodeEx pNode in treeView.Nodes)
            {
                pNode.ImageIndex = 0;
                pNode.SelectedImageIndex = pNode.ImageIndex;
            }
            if (treeView.Nodes.Count > 0)
            {
                treeView.Nodes[treeView.Nodes.Count - 1].Expand();
            }
        }

        //Leo
        private void InitTree(string ProjectNO, string strSqlWhere, TreeView treeView1,
            bool isImageIndex, int showImgeflg, bool isShowEFileCount, int IsUseDefined)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            BLL.T_CellAndEFile_BLL cellFile_bll = new ERM.BLL.T_CellAndEFile_BLL();

            DataTable dTable1 = fileBLL.GetAllDS(ProjectNO);
            DataTable dTable2 = null;
            if (isShowEFileCount)
            {
                dTable2 = cellFile_bll.FindAllByProjectNO(ProjectNO);
            }
            DataTable DT2 = dTable1.Clone();
            DT2.Rows.Clear();
            DataRow[] fileRow = null;
            if (strSqlWhere == " isvisible=1 " || strSqlWhere == "filestatus=1 AND  isvisible=1 " || strSqlWhere == "filestatus=2 AND  isvisible=1 ")
            {
                foreach (DataRow r2 in dTable1.Rows)
                {
                    DT2.Rows.Add(r2.ItemArray);
                }
            }
            else
            {
                fileRow = dTable1.Select(strSqlWhere);
                foreach (DataRow r1 in fileRow)
                {
                    if (DT2.Select("FileID='" + r1["FileID"].ToString() + "'").Length <= 0)
                    {
                        DT2.Rows.Add(r1.ItemArray);
                        GetParent(dTable1, DT2, r1["ParentID"].ToString());
                    }
                }
            }

            InsertParent2Tree(dTable2, DT2, strSqlWhere, "", treeView1.Nodes, isImageIndex, showImgeflg, isShowEFileCount);

            if (strSqlWhere == "filestatus=1 AND  isvisible=1 " || strSqlWhere == "filestatus=2 AND  isvisible=1 ")
            {
                RemoveNotCellNode(treeView1.Nodes);
            }
        }

        private void InsertParent2Tree(DataTable dTable2, DataTable DT2, string strSqlWhere,
            string ParentID, TreeNodeCollection pNode, bool isImageIndex, int showImgeflg, bool isShowEFileCount)
        {
            DataRow[] rows = DT2.Select("ParentID='" + ParentID + "'", "OrderIndex ASC");
            foreach (DataRow r1 in rows)
            {
                TreeNodeEx tNode = new TreeNodeEx();
                tNode.Name = r1["FileID"].ToString();
                tNode.Text = r1["wjtm"].ToString();
                tNode.NodeKey = MyCommon.ToString(r1["table_name"]); ;      //������
                tNode.NodeValue = MyCommon.ToString(r1["filepath"]);

                tNode.SelectedImageIndex = 1;

                if (MyCommon.ToInt(r1["isvisible"]) == 1)
                {//���ļ�����״̬ͼ��
                    int fileStatus = MyCommon.ToInt(r1["filestatus"]);

                    //if (fileStatus == 0)//ͼ���Ӧ
                    //{
                    //    tNode.SelectedImageIndex = 2;
                    //}
                    //else if (fileStatus == 1)
                    //{
                    //    tNode.SelectedImageIndex = 3;
                    //}
                    //else if (fileStatus == 2)
                    //{
                    //    tNode.SelectedImageIndex = 4;
                    //}
                    //else if (fileStatus == 3)
                    //{
                    //    tNode.SelectedImageIndex = 5;
                    //}

                    if (isImageIndex)
                    {
                        bool EfileCount_flg = false;
                        if (isShowEFileCount) //��õ����ļ�����
                        {
                            DataRow[] ERows = dTable2.Select("FileID='" + tNode.Name + "' AND DoStatus='1'");
                            countText = tNode.Text;

                            if (ERows != null && ERows.Length > 0)
                            {
                                countText = "[" + ERows.Length + "]" + countText;
                                EfileCount_flg = true;
                            }
                            else
                                countText = "[0]" + countText;
                            if (showImgeflg != 1)
                                tNode.Text = countText;
                        }

                        if ((strSqlWhere == "filestatus=1 AND  isvisible=1 " || strSqlWhere == "filestatus=2 AND  isvisible=1 "))
                        {
                            if (isShowEFileCount && EfileCount_flg)
                            {
                                //��ʾ�������Ҵ��ڵ����ļ�
                                if (strSqlWhere == "filestatus=1 AND  isvisible=1 ")//��ʾ�޵��ӵ���� ���Ǵ��ڵ����ļ� ������һ��
                                    continue;
                            }
                            else if (isShowEFileCount && EfileCount_flg == false)
                            {
                                //��ʾ�������ǲ����ڵ����ļ�
                                if (strSqlWhere == "filestatus=2 AND  isvisible=1 ")//���е��ӵ���� ���ǲ����ڵ����ļ� ������һ��
                                    continue;
                            }
                            else
                            {
                                //����ʾ����
                                DataRow[] ERows = dTable2.Select("FileID='" + tNode.Name + "'");
                                if (ERows != null && ERows.Length > 0)//�ж��Ƿ��е����ļ�
                                {
                                    if (strSqlWhere == "filestatus=1 AND  isvisible=1 ")//��ʾ�޵��ӵ���� ���Ǵ��ڵ����ļ� ������һ��
                                        continue;
                                }
                                else
                                {
                                    if (strSqlWhere == "filestatus=2 AND  isvisible=1 ")//���е��ӵ���� ���ǲ����ڵ����ļ� ������һ��
                                        continue;
                                }
                            }
                        }

                        switch (showImgeflg)
                        {
                            case 1:
                                if (fileStatus == 6)
                                    tNode.SelectedImageIndex = 4;//���
                                else
                                {
                                    if (isShowEFileCount)
                                        tNode.SelectedImageIndex = (EfileCount_flg == true) ? 7 : 2;//�ж��Ƿ��е����ļ�
                                    else
                                    {
                                        DataRow[] ERows = dTable2.Select("FileID='" + tNode.Name + "' AND DoStatus='1'");
                                        if (ERows != null && ERows.Length > 0)//�ж��Ƿ��е����ļ�
                                            tNode.SelectedImageIndex = 7;
                                        else
                                            tNode.SelectedImageIndex = 2;
                                    }
                                }
                                break;
                            case 2:
                                if (fileStatus == 6)
                                    tNode.SelectedImageIndex = 4;//���
                                else
                                {
                                    if (fileStatus == 4)//�ж��Ƿ�Ǽ� 
                                        tNode.SelectedImageIndex = 5;
                                    else
                                    {
                                        if (isShowEFileCount)
                                            tNode.SelectedImageIndex = (EfileCount_flg == true) ? 7 : 2;//�ж��Ƿ��е����ļ�
                                        else
                                        {
                                            DataRow[] ERows = dTable2.Select("FileID='" + tNode.Name + "' AND DoStatus='1'");
                                            if (ERows != null && ERows.Length > 0)//�ж��Ƿ��е����ļ�
                                                tNode.SelectedImageIndex = 7;
                                            else
                                                tNode.SelectedImageIndex = 2;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        tNode.SelectedImageIndex = 2;
                    }
                }
                tNode.ImageIndex = tNode.SelectedImageIndex;
                pNode.Add(tNode);
                InsertParent2Tree(dTable2, DT2, strSqlWhere, r1["FileID"].ToString(), tNode.Nodes, isImageIndex, showImgeflg, isShowEFileCount);
            }
        }

        private void GetParent(DataTable fileDS, DataTable DT2, string ParentID)
        {
            DataRow[] parentRow = fileDS.Select("FileID='" + ParentID + "'");
            foreach (DataRow r1 in parentRow)
            {
                if (DT2.Select("FileID='" + r1["FileID"].ToString() + "'").Length <= 0)
                {
                    DT2.Rows.Add(r1.ItemArray);
                    GetParent(fileDS, DT2, r1["ParentID"].ToString());
                }
            }
        }

        /// <summary>
        ///  ˢ�µ����ڵ���Ϣ ���� YQ 2011-06-29 
        /// </summary>
        /// <param name="ProjectNO"></param>
        /// <param name="strSqlWhere"></param>
        /// <param name="treeView_Node"></param>
        /// <param name="isImageIndex"></param>
        /// <param name="showImgeflg"></param>
        /// <param name="isShowEFileCount"></param>
        public void InitTree(string ProjectNO, string strSqlWhere, TreeNode treeView_Node,
            bool isImageIndex, int showImgeflg, bool isShowEFileCount)
        {
            treeView_Node.Nodes.Clear();
            if (strSqlWhere != "")
            {
                strSqlWhere += " AND ";
            }
            strSqlWhere += " isvisible=1 ";

            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            BLL.T_CellAndEFile_BLL cellFile_bll = new ERM.BLL.T_CellAndEFile_BLL();

            DataTable dTable1 = fileBLL.GetAllDS(ProjectNO);

            DataTable dTable2 = null;
            if (isShowEFileCount)
            {
                dTable2 = cellFile_bll.FindAllByProjectNO(ProjectNO);
            }
            DataTable DT2 = dTable1.Clone();
            DT2.Rows.Clear();
            DataRow[] fileRow = null;
            if (strSqlWhere == " isvisible=1 " || strSqlWhere == "filestatus=1 AND  isvisible=1 " || strSqlWhere == "filestatus=2 AND  isvisible=1 ")
            {
                foreach (DataRow r2 in dTable1.Rows)
                {
                    DT2.Rows.Add(r2.ItemArray);
                }
            }
            else
            {
                fileRow = dTable1.Select(strSqlWhere);

                foreach (DataRow r1 in fileRow)
                {
                    if (DT2.Select("FileID='" + r1["FileID"].ToString() + "'").Length <= 0)
                    {
                        DT2.Rows.Add(r1.ItemArray);

                        GetParent(dTable1, DT2, r1["ParentID"].ToString());
                    }
                }
            }
            InsertParent2Tree(dTable2, DT2, strSqlWhere, treeView_Node.Name, treeView_Node.Nodes, isImageIndex, showImgeflg, isShowEFileCount);

            if (strSqlWhere == "filestatus=1 AND  isvisible=1 " || strSqlWhere == "filestatus=2 AND  isvisible=1 ")
            {
                RemoveNotCellNode(treeView_Node.Nodes);
            }
        }

        /// <summary>
        /// �Ƴ�û�нڵ�ĸ��ڵ�
        /// </summary>
        /// <param name="pNode"></param>
        private void RemoveNotCellNode(TreeNodeCollection pNode)
        {
            for (int i = 0; i < pNode.Count; i++)
            {
                if (pNode[i].ImageIndex == 1)
                {
                    if (pNode[i].Nodes.Count > 0)
                        RemoveNotCellNode(pNode[i].Nodes);
                    if (pNode[i].Nodes.Count <= 0)
                    {
                        pNode[i].Remove();
                        i--;
                    }
                }
            }
        }

        /// <summary>
        /// �ı��м����
        /// </summary>
        string countText = string.Empty;

        /// <summary>
        /// ��ȡ�ļ��µĵ����ļ�����
        /// </summary>
        /// <param name="fildID">�ļ�ID</param>
        /// <param name="cellfileNode">�ļ�TreeNodeEx�ڵ�</param>
        /// <param name="isGetfileName">�Ƿ�ͨ��ID ��ѯ���µ����� bool:trueͨ����ѯ��ȡ���� falseֱ�ӻ�ȡ�ڵ�Text</param>
        public void GetCellFileNodesCount(TreeNodeEx cellfileNode, bool isGetfileName)
        {
            BLL.T_CellAndEFile_BLL cellFile_bll = new ERM.BLL.T_CellAndEFile_BLL();
            BLL.T_FileList_BLL fileList_bll = new ERM.BLL.T_FileList_BLL();

            //�ļ��ڵ�����
            if (isGetfileName)
            {
                #region ������ж���Ŀ�����������Ʒ�����������ƻ��ȡ����
                //IList<MDL.T_FileList> fileList = fileList_bll.FindByFileID(cellfileNode.Name);
                //if (fileList != null && fileList.Count > 0)
                //{
                //    countText = fileList[0].wjtm;
                //}
                //else
                //{
                //    countText = cellfileNode.Text;
                //}
                #endregion

                MDL.T_FileList file_MDL = fileList_bll.Find(cellfileNode.Name, Globals.ProjectNO);
                if (file_MDL != null)
                {
                    countText = file_MDL.wjtm;
                }
                else
                {
                    countText = cellfileNode.Text;
                }
            }
            else
            {
                countText = cellfileNode.Text;
            }

            //IList<MDL.T_CellAndEFile> cellList =
            //    cellFile_bll.FindByFileIDAndNOCell(cellfileNode.Name, Globals.ProjectNO);

            IList<MDL.T_CellAndEFile> cellList =
                cellFile_bll.FindByGdFileID(cellfileNode.Name, Globals.ProjectNO);
            if (cellList != null && cellList.Count > 0)
            {
                countText = "[" + cellList.Count + "]" + countText;
            }
            else
            {
                countText = "[0]" + countText;
            }
            cellfileNode.Text = countText;
        }

        /// <summary>
        /// �ж�Ŀ¼���Ƿ��¼��ʩ���ñ�
        /// </summary>
        /// <param name="fileID">Ŀ¼ID</param>
        /// <param name="a_flg">���ͣ�1�����ñ�2�ļ��Ǽ�</param>
        /// <returns>bool:true��ʾ��ʩ���ñ�����������ļ� false��ʾû��ʩ���ñ�����������ļ�</returns>
        public bool CheckEFileByFileID(string fileID, int a_flg)
        {
            BLL.T_CellAndEFile_BLL cellFile_bll = new ERM.BLL.T_CellAndEFile_BLL();
            bool return_flg = false;
            if (a_flg == 1)
            {
                IList<MDL.T_CellAndEFile> cellList =
                cellFile_bll.FindByFileIDAndNOCell(fileID, Globals.ProjectNO);
                if (cellList != null && cellList.Count > 0)
                    return_flg = true;
            }
            else if (a_flg == 2)
            {
                IList<MDL.T_CellAndEFile> cellList =
                    cellFile_bll.FindByGdFileID(fileID, Globals.ProjectNO);
                if (cellList != null && cellList.Count > 0)
                    return_flg = true;
            }
            return return_flg;
        }

        #region 2011-0701 YQ ��ȡ���ڵ����� ������ͳ����������
        /// <summary>
        /// �жϵ�ǰǨ����ļ� ��ʲô���� 1 ��������  2���� 3��Ƭ����
        /// </summary>
        /// <param name="fileID">Ŀ¼ID</param>
        /// <param name="efile_type">���ͱ�ǣ����Ĭ��ֵ1</param>
        public void GetParentNodeType(string fileID, ref int efile_type)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            DataTable dTable1 = fileBLL.GetAllDS(Globals.ProjectNO);
            if (dTable1 != null && dTable1.Rows.Count > 0)
            {
                DataRow[] file_row = dTable1.Select("FileID='" + fileID + "'");
                if (file_row != null && file_row.Length > 0)
                {
                    dg_flg = true;
                    GetParent(dTable1,
                        file_row[0]["ParentID"].ToString().Trim(),
                        ref efile_type);
                }
            }
        }
        /// <summary>
        /// �ݹ��жϱ���
        /// </summary>
        bool dg_flg = true;
        /// <summary>
        /// �жϵ�ǰ���ļ���ʲô���� 1 ��������  2���� 3��Ƭ����
        /// </summary>
        /// <param name="fileDS">Ŀ¼��Ϣ</param>
        /// <param name="ParentID">�ϼ�ID</param>
        /// <param name="efile_type">���ͱ�ǣ����Ĭ��ֵ1</param>
        private void GetParent(DataTable fileDS,
            string ParentID, ref int efile_type)
        {
            if (dg_flg)
            {
                DataRow[] parentRow = fileDS.Select("FileID='" + ParentID + "'");
                if (parentRow != null && parentRow.Length > 0)
                {
                    if (parentRow[0]["ParentID"] != null
                        && parentRow[0]["ParentID"].ToString().Trim() != "")
                    {
                        GetParent(fileDS,
                            parentRow[0]["ParentID"].ToString().Trim(),
                            ref efile_type);
                    }

                    string wjtm = parentRow[0]["wjtm"] == null ? "" : parentRow[0]["wjtm"].ToString();
                    if (wjtm != "")
                    {
                        if (wjtm.IndexOf("����") != -1)
                            efile_type = 2;
                        else if (wjtm.IndexOf("ͼ") != -1)
                            efile_type = 3;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// ��ʾ���й��������Ϣ
        /// </summary>
        /// <param name="ProjectNO"></param>
        /// <param name="strSqlWhere"></param>
        /// <param name="treeView1"></param>
        /// <param name="isImageIndex"></param>
        /// <param name="showImgeflg"></param>
        /// <param name="isShowEFileCount"></param>
        private void InitGDTree(string ProjectNO, string strSqlWhere, TreeView treeView1,
            bool isImageIndex, int showImgeflg, bool isShowEFileCount, int IsUseDefined)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            BLL.T_CellAndEFile_BLL cellFile_bll = new ERM.BLL.T_CellAndEFile_BLL();

            DataTable dTable1 = fileBLL.GetAllDS(ProjectNO);
            DataTable dTable2 = null;
            if (isShowEFileCount)
            {
                dTable2 = cellFile_bll.FindAllByProjectNO(ProjectNO);
            }
            IList<MDL.T_GdList> gd_list = (new BLL.T_GdList_BLL()).FindByProjectNo(ProjectNO);

            DataRow[] rows = null;
            if (IsUseDefined==3)
                rows = dTable1.Select("ParentID='' ", "OrderIndex ASC");
            else
                rows = dTable1.Select("ParentID='' or IsUseDefined=" + IsUseDefined, "OrderIndex ASC");

            if (rows != null && rows.Length > 0)
            {
                treeView1.Nodes.Clear();
                TreeNodeEx tNodep = new TreeNodeEx();
                tNodep.Name = rows[0]["FileID"].ToString();
                tNodep.Text = rows[0]["wjtm"].ToString();
                tNodep.NodeKey = MyCommon.ToString(rows[0]["table_name"]); ;      //������
                tNodep.NodeValue = MyCommon.ToString(rows[0]["filepath"]);
                tNodep.SelectedImageIndex = 1;

                foreach (MDL.T_GdList gd_mdl in gd_list)
                {
                    TreeNodeEx gdNode = new TreeNodeEx();
                    gdNode.Name = gd_mdl.ID;
                    gdNode.Text = gd_mdl.GdName;
                    gdNode.SelectedImageIndex = 1;

                    if (strSqlWhere == "" || 
                        strSqlWhere == " isvisible=1 " ||
                        strSqlWhere == " IsUseDefined = 1 AND  isvisible=1 " ||
                        strSqlWhere == " IsUseDefined = 0 AND  isvisible=1 " || 
                        strSqlWhere == "filestatus=1 AND  isvisible=1 " ||
                        strSqlWhere == "filestatus=2 AND  isvisible=1 " ||
                        strSqlWhere == " IsUseDefined = 1 AND  filestatus=1 AND  isvisible=1 " ||
                        strSqlWhere == " IsUseDefined = 0 AND  filestatus=2 AND  isvisible=1 ")
                    {
                        rows = dTable1.Select("GDID='" + gd_mdl.ID + "'", "GdFileOrderIndex ASC");
                    }
                    else
                    {
                        rows = dTable1.Select("GDID='" + gd_mdl.ID + "' and " + strSqlWhere, "GdFileOrderIndex ASC");
                    }

                    foreach (DataRow r1 in rows)
                    {
                        if (MyCommon.ToInt(r1["isvisible"]) == 1 &&
                           (MyCommon.ToInt(r1["IsUseDefined"]) == IsUseDefined) || IsUseDefined==3)
                        {
                            TreeNodeEx tNode = new TreeNodeEx();
                            tNode.Name = r1["FileID"].ToString();
                            tNode.Text = r1["wjtm"].ToString();
                            tNode.NodeKey = MyCommon.ToString(r1["table_name"]); ;      //������
                            tNode.NodeValue = MyCommon.ToString(r1["filepath"]);
                            tNode.SelectedImageIndex = 2;
                            //���ļ�����״̬ͼ��
                            int fileStatus = MyCommon.ToInt(r1["filestatus"]);
                            if (isImageIndex)
                            {
                                bool EfileCount_flg = false;
                                if (isShowEFileCount) //��õ����ļ�����
                                {
                                    DataRow[] ERows = dTable2.Select("GdFileID='" + tNode.Name + "' AND DoStatus='1'");
                                    countText = tNode.Text;

                                    if (ERows != null && ERows.Length > 0)
                                    {
                                        countText = "[" + ERows.Length + "]" + countText;
                                        EfileCount_flg = true;
                                    }
                                    else
                                        countText = "[0]" + countText;
                                    if (showImgeflg != 1)
                                        tNode.Text = countText;
                                }

                                if ((strSqlWhere == "filestatus=1 AND  isvisible=1 " || strSqlWhere == "filestatus=2 AND  isvisible=1 "))
                                {
                                    #region
                                    if (isShowEFileCount && EfileCount_flg)
                                    {
                                        //��ʾ�������Ҵ��ڵ����ļ�
                                        if (strSqlWhere == "filestatus=1 AND  isvisible=1 ")//��ʾ�޵��ӵ���� ���Ǵ��ڵ����ļ� ������һ��
                                            continue;
                                    }
                                    else if (isShowEFileCount && EfileCount_flg == false)
                                    {
                                        //��ʾ�������ǲ����ڵ����ļ�
                                        if (strSqlWhere == "filestatus=2 AND  isvisible=1 ")//���е��ӵ���� ���ǲ����ڵ����ļ� ������һ��
                                            continue;
                                    }
                                    else
                                    {
                                        //����ʾ����
                                        DataRow[] ERows = dTable2.Select("FileID='" + tNode.Name + "'");
                                        if (ERows != null && ERows.Length > 0)//�ж��Ƿ��е����ļ�
                                        {
                                            if (strSqlWhere == "filestatus=1 AND  isvisible=1 ")//��ʾ�޵��ӵ���� ���Ǵ��ڵ����ļ� ������һ��
                                                continue;
                                        }
                                        else
                                        {
                                            if (strSqlWhere == "filestatus=2 AND  isvisible=1 ")//���е��ӵ���� ���ǲ����ڵ����ļ� ������һ��
                                                continue;
                                        }
                                    }
                                    #endregion
                                }

                                switch (showImgeflg)
                                {
                                    #region
                                    case 1:
                                        if (fileStatus == 6)
                                        {
                                            tNode.SelectedImageIndex = 4;//���
                                        }
                                        else
                                        {
                                            if (isShowEFileCount)
                                                tNode.SelectedImageIndex = (EfileCount_flg == true) ? 7 : 2;//�ж��Ƿ��е����ļ�
                                            else
                                            {
                                                DataRow[] ERows = dTable2.Select("GdFileID='" + tNode.Name + "' AND DoStatus='1'");
                                                if (ERows != null && ERows.Length > 0)//�ж��Ƿ��е����ļ�
                                                    tNode.SelectedImageIndex = 7;
                                                else
                                                    tNode.SelectedImageIndex = 2;
                                            }
                                        }
                                        break;
                                    case 2:
                                        if (fileStatus == 6)
                                        {
                                            tNode.SelectedImageIndex = 4;//���
                                        }
                                        else
                                        {
                                            if (fileStatus == 4)//�ж��Ƿ�Ǽ� 
                                                tNode.SelectedImageIndex = 5;
                                            else
                                            {
                                                if (isShowEFileCount)
                                                    tNode.SelectedImageIndex = (EfileCount_flg == true) ? 7 : 2;//�ж��Ƿ��е����ļ�
                                                else
                                                {
                                                    DataRow[] ERows = dTable2.Select("GdFileID='" + tNode.Name + "' AND DoStatus='1'");
                                                    if (ERows != null && ERows.Length > 0)//�ж��Ƿ��е����ļ�
                                                        tNode.SelectedImageIndex = 7;
                                                    else
                                                        tNode.SelectedImageIndex = 2;
                                                }
                                            }
                                        }
                                        break;
                                    #endregion
                                }
                            }
                            else
                            {
                                tNode.SelectedImageIndex = 2;
                            }
                            tNode.ImageIndex = tNode.SelectedImageIndex;
                            gdNode.Nodes.Add(tNode);
                        }
                    }
                    gdNode.ImageIndex = gdNode.SelectedImageIndex;
                    if ((dTable1.Select("FileID='" + gd_mdl.ID + "' and IsUseDefined = 1 ","OrderIndex ASC").Length > 0
                        || IsUseDefined == 3) && IsUseDefined != 0)
                    {
                        tNodep.Nodes.Add(gdNode);
                    }
                    else if( IsUseDefined == 0 )
                    {
                        if (dTable1.Select("FileID='" + gd_mdl.ID + "' and IsUseDefined = 1 ", "OrderIndex ASC").Length == 0)
                                tNodep.Nodes.Add(gdNode);
                    }
                }
                tNodep.ImageIndex = tNodep.SelectedImageIndex;
                treeView1.Nodes.Add(tNodep);
            }

            if (strSqlWhere == "filestatus=1 AND  isvisible=1 " || strSqlWhere == "filestatus=2 AND  isvisible=1 ")
            {
                RemoveNotCellNode(treeView1.Nodes);
            }
        }

        /// <summary>
        /// ˢ�¹鵵����£��ļ��б���Ϣ
        /// </summary>
        /// <param name="ProjectNO">���̱��</param>
        /// <param name="strSqlWhere">��������</param>
        /// <param name="treeView_Node">�鵵���ڵ�</param>
        /// <param name="isImageIndex">�Ƿ���Ҫ��ʾ�����ļ�</param>
        /// <param name="showImgeflg">��ʾ�����ļ���ͼ��</param>
        /// <param name="isShowEFileCount">�Ƿ���ʾ����</param>
        public void InitGDTree(string ProjectNO, string strSqlWhere, TreeNode treeView_Node,
           bool isImageIndex, int showImgeflg, bool isShowEFileCount)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            BLL.T_CellAndEFile_BLL cellFile_bll = new ERM.BLL.T_CellAndEFile_BLL();

            DataTable dTable1 = fileBLL.GetAllDS(ProjectNO);
            DataTable dTable2 = null;
            if (isShowEFileCount)
            {
                dTable2 = cellFile_bll.FindAllByProjectNO(ProjectNO);
            }
            DataRow[] rows = null;
            if (strSqlWhere == "" || strSqlWhere == " isvisible=1 " || strSqlWhere == "filestatus=1 AND  isvisible=1 " || strSqlWhere == "filestatus=2 AND  isvisible=1 ")
            {
                rows = dTable1.Select("GDID='" + treeView_Node.Name + "'", "GdFileOrderIndex ASC");
            }
            else
            {
                rows = dTable1.Select("GDID='" + treeView_Node.Name + "' and " + strSqlWhere, "GdFileOrderIndex ASC");
            }

            treeView_Node.Nodes.Clear();

            foreach (DataRow r1 in rows)
            {
                if (MyCommon.ToInt(r1["isvisible"]) == 1)
                {
                    TreeNodeEx tNode = new TreeNodeEx();
                    tNode.Name = r1["FileID"].ToString();
                    tNode.Text = r1["wjtm"].ToString();
                    tNode.NodeKey = MyCommon.ToString(r1["table_name"]); ;      //������
                    tNode.NodeValue = MyCommon.ToString(r1["filepath"]);
                    tNode.SelectedImageIndex = 2;
                    //���ļ�����״̬ͼ��
                    int fileStatus = MyCommon.ToInt(r1["filestatus"]);
                    if (isImageIndex)
                    {
                        bool EfileCount_flg = false;
                        if (isShowEFileCount) //��õ����ļ�����
                        {
                            DataRow[] ERows = dTable2.Select("GdFileID='" + tNode.Name + "' AND DoStatus='1'");
                            countText = tNode.Text;

                            if (ERows != null && ERows.Length > 0)
                            {
                                countText = "[" + ERows.Length + "]" + countText;
                                EfileCount_flg = true;
                            }
                            else
                                countText = "[0]" + countText;
                            if (showImgeflg != 1)
                                tNode.Text = countText;
                        }

                        if ((strSqlWhere == "filestatus=1 AND  isvisible=1 " || strSqlWhere == "filestatus=2 AND  isvisible=1 "))
                        {
                            #region
                            if (isShowEFileCount && EfileCount_flg)
                            {
                                //��ʾ�������Ҵ��ڵ����ļ�
                                if (strSqlWhere == "filestatus=1 AND  isvisible=1 ")//��ʾ�޵��ӵ���� ���Ǵ��ڵ����ļ� ������һ��
                                    continue;
                            }
                            else if (isShowEFileCount && EfileCount_flg == false)
                            {
                                //��ʾ�������ǲ����ڵ����ļ�
                                if (strSqlWhere == "filestatus=2 AND  isvisible=1 ")//���е��ӵ���� ���ǲ����ڵ����ļ� ������һ��
                                    continue;
                            }
                            else
                            {
                                //����ʾ����
                                DataRow[] ERows = dTable2.Select("FileID='" + tNode.Name + "'");
                                if (ERows != null && ERows.Length > 0)//�ж��Ƿ��е����ļ�
                                {
                                    if (strSqlWhere == "filestatus=1 AND  isvisible=1 ")//��ʾ�޵��ӵ���� ���Ǵ��ڵ����ļ� ������һ��
                                        continue;
                                }
                                else
                                {
                                    if (strSqlWhere == "filestatus=2 AND  isvisible=1 ")//���е��ӵ���� ���ǲ����ڵ����ļ� ������һ��
                                        continue;
                                }
                            }
                            #endregion
                        }

                        switch (showImgeflg)
                        {
                            #region
                            case 1:
                                if (fileStatus == 6)
                                    tNode.SelectedImageIndex = 4;//���
                                else
                                {
                                    if (isShowEFileCount)
                                        tNode.SelectedImageIndex = (EfileCount_flg == true) ? 7 : 2;//�ж��Ƿ��е����ļ�
                                    else
                                    {
                                        DataRow[] ERows = dTable2.Select("GdFileID='" + tNode.Name + "' AND DoStatus='1'");
                                        if (ERows != null && ERows.Length > 0)//�ж��Ƿ��е����ļ�
                                            tNode.SelectedImageIndex = 7;
                                        else
                                            tNode.SelectedImageIndex = 2;
                                    }
                                }
                                break;
                            case 2:
                                if (fileStatus == 6)
                                    tNode.SelectedImageIndex = 4;//���
                                else
                                {
                                    if (fileStatus == 4)//�ж��Ƿ�Ǽ� 
                                        tNode.SelectedImageIndex = 5;
                                    else
                                    {
                                        if (isShowEFileCount)
                                            tNode.SelectedImageIndex = (EfileCount_flg == true) ? 7 : 2;//�ж��Ƿ��е����ļ�
                                        else
                                        {
                                            DataRow[] ERows = dTable2.Select("GdFileID='" + tNode.Name + "' AND DoStatus='1'");
                                            if (ERows != null && ERows.Length > 0)//�ж��Ƿ��е����ļ�
                                                tNode.SelectedImageIndex = 7;
                                            else
                                                tNode.SelectedImageIndex = 2;
                                        }
                                    }
                                }
                                break;
                            #endregion
                        }
                    }
                    else
                    {
                        tNode.SelectedImageIndex = 2;
                    }
                    tNode.ImageIndex = tNode.SelectedImageIndex;
                    treeView_Node.Nodes.Add(tNode);
                }
            }
        }

        public void InitGDTree2(string ProjectNO, string strSqlWhere, TreeNode treeView_Node,
           bool isImageIndex, int showImgeflg, bool isShowEFileCount)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            BLL.T_CellAndEFile_BLL cellFile_bll = new ERM.BLL.T_CellAndEFile_BLL();

            DataTable dTable1 = fileBLL.GetAllDS(ProjectNO);
            DataTable dTable2 = null;
            if (isShowEFileCount)
            {
                dTable2 = cellFile_bll.FindAllByProjectNO(ProjectNO);
            }
            IList<MDL.T_GdList> gd_list = (new BLL.T_GdList_BLL()).FindByProjectNo(ProjectNO);
            treeView_Node.Nodes.Clear();
            foreach (MDL.T_GdList gd_mdl in gd_list)
            {
                TreeNodeEx gdNode = new TreeNodeEx();
                gdNode.Name = gd_mdl.ID;
                gdNode.Text = gd_mdl.GdName;
                gdNode.SelectedImageIndex = 1;
                DataRow[] rows = null;
                if (strSqlWhere == "" || strSqlWhere == " isvisible=1 " || strSqlWhere == "filestatus=1 AND  isvisible=1 " || strSqlWhere == "filestatus=2 AND  isvisible=1 ")
                {
                    rows = dTable1.Select("GDID='" + gd_mdl.ID + "'", "GdFileOrderIndex ASC");
                }
                else
                {
                    rows = dTable1.Select("GDID='" + gd_mdl.ID + "' and " + strSqlWhere, "GdFileOrderIndex ASC");
                }
                foreach (DataRow r1 in rows)
                {
                    if (MyCommon.ToInt(r1["isvisible"]) == 1)
                    {
                        TreeNodeEx tNode = new TreeNodeEx();
                        tNode.Name = r1["FileID"].ToString();
                        tNode.Text = r1["wjtm"].ToString();
                        tNode.NodeKey = MyCommon.ToString(r1["table_name"]); ;      //������
                        tNode.NodeValue = MyCommon.ToString(r1["filepath"]);
                        tNode.SelectedImageIndex = 2;
                        //���ļ�����״̬ͼ��
                        int fileStatus = MyCommon.ToInt(r1["filestatus"]);
                        if (isImageIndex)
                        {
                            bool EfileCount_flg = false;
                            if (isShowEFileCount) //��õ����ļ�����
                            {
                                DataRow[] ERows = dTable2.Select("GdFileID='" + tNode.Name + "' AND DoStatus='1'");
                                countText = tNode.Text;

                                if (ERows != null && ERows.Length > 0)
                                {
                                    countText = "[" + ERows.Length + "]" + countText;
                                    EfileCount_flg = true;
                                }
                                else
                                    countText = "[0]" + countText;
                                if (showImgeflg != 1)
                                    tNode.Text = countText;
                            }

                            if ((strSqlWhere == "filestatus=1 AND  isvisible=1 " || strSqlWhere == "filestatus=2 AND  isvisible=1 "))
                            {
                                #region
                                if (isShowEFileCount && EfileCount_flg)
                                {
                                    //��ʾ�������Ҵ��ڵ����ļ�
                                    if (strSqlWhere == "filestatus=1 AND  isvisible=1 ")//��ʾ�޵��ӵ���� ���Ǵ��ڵ����ļ� ������һ��
                                        continue;
                                }
                                else if (isShowEFileCount && EfileCount_flg == false)
                                {
                                    //��ʾ�������ǲ����ڵ����ļ�
                                    if (strSqlWhere == "filestatus=2 AND  isvisible=1 ")//���е��ӵ���� ���ǲ����ڵ����ļ� ������һ��
                                        continue;
                                }
                                else
                                {
                                    //����ʾ����
                                    DataRow[] ERows = dTable2.Select("FileID='" + tNode.Name + "'");
                                    if (ERows != null && ERows.Length > 0)//�ж��Ƿ��е����ļ�
                                    {
                                        if (strSqlWhere == "filestatus=1 AND  isvisible=1 ")//��ʾ�޵��ӵ���� ���Ǵ��ڵ����ļ� ������һ��
                                            continue;
                                    }
                                    else
                                    {
                                        if (strSqlWhere == "filestatus=2 AND  isvisible=1 ")//���е��ӵ���� ���ǲ����ڵ����ļ� ������һ��
                                            continue;
                                    }
                                }
                                #endregion
                            }

                            switch (showImgeflg)
                            {
                                #region
                                case 1:
                                    if (fileStatus == 6)
                                        tNode.SelectedImageIndex = 4;//���
                                    else
                                    {
                                        if (isShowEFileCount)
                                            tNode.SelectedImageIndex = (EfileCount_flg == true) ? 7 : 2;//�ж��Ƿ��е����ļ�
                                        else
                                        {
                                            DataRow[] ERows = dTable2.Select("GdFileID='" + tNode.Name + "' AND DoStatus='1'");
                                            if (ERows != null && ERows.Length > 0)//�ж��Ƿ��е����ļ�
                                                tNode.SelectedImageIndex = 7;
                                            else
                                                tNode.SelectedImageIndex = 2;
                                        }
                                    }
                                    break;
                                case 2:
                                    if (fileStatus == 6)
                                        tNode.SelectedImageIndex = 4;//���
                                    else
                                    {
                                        if (fileStatus == 4)//�ж��Ƿ�Ǽ� 
                                            tNode.SelectedImageIndex = 5;
                                        else
                                        {
                                            if (isShowEFileCount)
                                                tNode.SelectedImageIndex = (EfileCount_flg == true) ? 7 : 2;//�ж��Ƿ��е����ļ�
                                            else
                                            {
                                                DataRow[] ERows = dTable2.Select("GdFileID='" + tNode.Name + "' AND DoStatus='1'");
                                                if (ERows != null && ERows.Length > 0)//�ж��Ƿ��е����ļ�
                                                    tNode.SelectedImageIndex = 7;
                                                else
                                                    tNode.SelectedImageIndex = 2;
                                            }
                                        }
                                    }
                                    break;
                                #endregion
                            }
                        }
                        else
                        {
                            tNode.SelectedImageIndex = 2;
                        }
                        tNode.ImageIndex = tNode.SelectedImageIndex;
                        gdNode.Nodes.Add(tNode);
                    }
                }
                gdNode.ImageIndex = gdNode.SelectedImageIndex;
                treeView_Node.Nodes.Add(gdNode);
            }
        }

        #endregion
    }

    /// <summary>
    /// ������Ϣ���ύ���̴�����ã��������ʱ���ٵõ����������Ϣ������ÿ�ζ��������ݿ�
    /// </summary>
    public class ProjectFactory
    {
        private string _openedProjectNo = "";
        private ERM.BLL.T_Projects_BLL projectsData = new ERM.BLL.T_Projects_BLL();
        private ERM.BLL.T_Units_BLL unitData = new ERM.BLL.T_Units_BLL();
        private Hashtable _projectDetail;
        public ProjectFactory(string openedProjectNo)
        {
            this._openedProjectNo = openedProjectNo;
            ERM.MDL.T_Projects projectInfo = projectsData.Find(_openedProjectNo);
            Hashtable projectDetail = new Hashtable();
            projectDetail.Add("address", projectInfo.address);
            projectDetail.Add("area", projectInfo.area1);
            projectDetail.Add("area2", projectInfo.area2);
            projectDetail.Add("district", projectInfo.district);
            projectDetail.Add("category", projectInfo.category);
            projectDetail.Add("begindate", projectInfo.begindate);
            projectDetail.Add("bjdate", projectInfo.bjdate);
            projectDetail.Add("enddate", projectInfo.enddate);
            projectDetail.Add("floors1", projectInfo.floors1);
            projectDetail.Add("floors2", projectInfo.floors2);
            projectDetail.Add("ghcode", projectInfo.ghcode);
            projectDetail.Add("passwd", projectInfo.passwd);
            projectDetail.Add("price1", projectInfo.price1);
            projectDetail.Add("price2", projectInfo.price2);
            projectDetail.Add("high", projectInfo.high);
            projectDetail.Add("projectname", projectInfo.projectname);
            projectDetail.Add("ProjectNO", projectInfo.ProjectNO);
            projectDetail.Add("projecttype", projectInfo.projecttype);
            projectDetail.Add("sgcode", projectInfo.sgcode);
            projectDetail.Add("ydpzcode", projectInfo.ydpzcode);
            projectDetail.Add("ydxkcode", projectInfo.ydxkcode);
            projectDetail.Add("stru", projectInfo.stru);
            projectDetail.Add("tempid", projectInfo.tempid);
            projectDetail.Add("hjqk", projectInfo.hjqk);
            projectDetail.Add("zzmj", projectInfo.zzmj);
            projectDetail.Add("bgyfmj", projectInfo.bgyfmj);
            projectDetail.Add("syyfmj", projectInfo.syyfmj);
            projectDetail.Add("cfmj", projectInfo.cfmj);
            projectDetail.Add("dxsmj", projectInfo.dxsmj);
            projectDetail.Add("qtyfmj", projectInfo.qtyfmj);
            projectDetail.Add("ts1", projectInfo.ts1);
            projectDetail.Add("ts2", projectInfo.ts2);
            projectDetail.Add("ts3", projectInfo.ts3);
            projectDetail.Add("ts4", projectInfo.ts4);
            projectDetail.Add("tstotal", projectInfo.tstotal);
            projectDetail.Add("zygz", projectInfo.zygz);
            projectDetail.Add("zjy", projectInfo.zjy);
            projectDetail.Add("sgbzz", projectInfo.sgbzz);
            projectDetail.Add("tbr", projectInfo.tbr);
            projectDetail.Add("jsdwshr", projectInfo.jsdwshr);
            projectDetail.Add("jldwshr", projectInfo.jldwshr);
            projectDetail.Add("createdate", projectInfo.createdate);
            DataView dv;
            MDL.T_Units obj = new ERM.MDL.T_Units();
            obj.ProjectNO = _openedProjectNo;
            obj.unittype = "unit1";
            dv = unitData.GetList(obj).Tables[0].DefaultView;
            if (dv.Count == 0)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("jsdw_mc", "");
                    projectDetail.Add("jsdw_xmfzr", "");
                }
                else
                {
                    projectDetail.Add("jsdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("jsdw_xmfzr", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] jsdwmc = new string[dv.Count];  //��λ����
                string[] jsdwxmfzr = new string[dv.Count]; //��Ŀ������
                for (int i = 0; i < dv.Count; i++)
                {
                    jsdwmc[i] = dv[i]["dwmc"].ToString();
                    jsdwxmfzr[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("jsdw_mc", jsdwmc);
                projectDetail.Add("jsdw_xmfzr", jsdwxmfzr);
            }
            obj.unittype = "unit2";
            dv = unitData.GetList(obj).Tables[0].DefaultView;
            if (dv.Count == 0)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("kcdw_mc", "");
                    projectDetail.Add("kcdw_xmfzr", "");
                    projectDetail.Add("kcdw_jsfzr", "");
                }
                else
                {
                    projectDetail.Add("kcdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("kcdw_xmfzr", dv[0]["fzr"].ToString());
                    projectDetail.Add("kcdw_jsfzr", dv[0]["xmjl"].ToString());
                }
            }
            else
            {
                string[] kcdwmc = new string[dv.Count];  //��λ����
                string[] kcdwxmfzr = new string[dv.Count]; //��Ŀ������
                string[] kcdwjsfzr = new string[dv.Count]; //����������
                for (int i = 0; i < dv.Count; i++)
                {
                    kcdwmc[i] = dv[i]["dwmc"].ToString();
                    kcdwxmfzr[i] = dv[i]["fzr"].ToString();
                    kcdwjsfzr[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("kcdw_mc", kcdwmc);
                projectDetail.Add("kcdw_xmfzr", kcdwxmfzr);
                projectDetail.Add("kcdw_jsfzr", kcdwjsfzr);
            }
            obj.unittype = "unit3";
            dv = unitData.GetList(obj).Tables[0].DefaultView;
            if (dv.Count == 0)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("sjdw_mc", "");
                    projectDetail.Add("sjdw_xmfzr", "");
                    projectDetail.Add("sjdw_jsfzr", "");
                }
                else
                {
                    projectDetail.Add("sjdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("sjdw_xmfzr", dv[0]["fzr"].ToString());
                    projectDetail.Add("sjdw_jsfzr", dv[0]["xmjl"].ToString());
                }
            }
            else
            {
                string[] sjdwmc = new string[dv.Count];  //��λ����
                string[] sjdwxmfzr = new string[dv.Count]; //��Ŀ������
                string[] sjdwjsfzr = new string[dv.Count]; //����������
                for (int i = 0; i < dv.Count; i++)
                {
                    sjdwmc[i] = dv[i]["dwmc"].ToString();
                    sjdwxmfzr[i] = dv[i]["dwmc"].ToString();
                    sjdwjsfzr[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("sjdw_mc", sjdwmc);
                projectDetail.Add("sjdw_xmfzr", sjdwxmfzr);
                projectDetail.Add("sjdw_jsfzr", sjdwjsfzr);
            }
            obj.unittype = "unit4";
            dv = unitData.GetList(obj).Tables[0].DefaultView;
            if (dv.Count == 0)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("sgdw_mc", "");
                    projectDetail.Add("sgdw_xmfzr", "");
                    projectDetail.Add("sgdw_jsfzr", "");
                }
                else
                {
                    projectDetail.Add("sgdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("sgdw_xmfzr", dv[0]["xmjl"].ToString());
                    projectDetail.Add("sgdw_jsfzr", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] sgdwmc = new string[dv.Count];  //��λ����
                string[] sgdwxmfzr = new string[dv.Count]; //��Ŀ����
                string[] sgdwjsfzr = new string[dv.Count]; //����������
                for (int i = 0; i < dv.Count; i++)
                {
                    sgdwmc[i] = dv[i]["dwmc"].ToString();
                    sgdwxmfzr[i] = dv[i]["xmjl"].ToString();
                    sgdwjsfzr[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("sgdw_mc", sgdwmc);
                projectDetail.Add("sgdw_xmfzr", sgdwxmfzr);
                projectDetail.Add("sgdw_jsfzr", sgdwjsfzr);
            }
            obj.unittype = "unit5";
            dv = unitData.GetList(obj).Tables[0].DefaultView;
            if (dv.Count == 0)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("sgtdw_mc", "");
                    projectDetail.Add("sgtdw_xmfzr", "");
                }
                else
                {
                    projectDetail.Add("sgtdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("sgtdw_xmfzr", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] sgtdwmc = new string[dv.Count];  //��λ����
                string[] sgtdwxmfzr = new string[dv.Count]; //��Ŀ������
                for (int i = 0; i < dv.Count; i++)
                {
                    sgtdwmc[i] = dv[i]["dwmc"].ToString();
                    sgtdwxmfzr[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("sgtdw_mc", sgtdwmc);
                projectDetail.Add("sgtdw_xmfzr", sgtdwxmfzr);
            }
            obj.unittype = "unit6";
            dv = unitData.GetList(obj).Tables[0].DefaultView;
            if (dv.Count == 0)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("jldw_mc", "");
                    projectDetail.Add("jldw_jlgcs", "");
                    projectDetail.Add("jldw_zjlgcs", "");
                }
                else
                {
                    projectDetail.Add("jldw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("jldw_jlgcs", dv[0]["fzr"].ToString());
                    projectDetail.Add("jldw_zjlgcs", dv[0]["xmjl"].ToString());
                }
            }
            else
            {
                string[] jldwmc = new string[dv.Count];  //��λ����
                string[] jldwjlgcs = new string[dv.Count]; //������ʦ
                string[] jldwzjlgcs = new string[dv.Count]; //�ܼ�����ʦ
                for (int i = 0; i < dv.Count; i++)
                {
                    jldwmc[i] = dv[i]["dwmc"].ToString();
                    jldwjlgcs[i] = dv[i]["fzr"].ToString();
                    jldwzjlgcs[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("jldw_mc", jldwmc);
                projectDetail.Add("jldw_jlgcs", jldwjlgcs);
                projectDetail.Add("jldw_zjlgcs", jldwzjlgcs);
            }
            obj.unittype = "unit7";
            dv = unitData.GetList(obj).Tables[0].DefaultView;
            if (dv.Count == 0)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("jddw_mc", "");
                    projectDetail.Add("jddw_jdy", "");
                }
                else
                {
                    projectDetail.Add("jddw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("jddw_jdy", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] jddwmc = new string[dv.Count];  //��λ����
                string[] jddwjdy = new string[dv.Count]; //�ලԱ
                for (int i = 0; i < dv.Count; i++)
                {
                    jddwmc[i] = dv[i]["dwmc"].ToString();
                    jddwjdy[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("jddw_mc", jddwmc);
                projectDetail.Add("jddw_jdy", jddwjdy);
            }
            obj.unittype = "unit8";
            dv = unitData.GetList(obj).Tables[0].DefaultView;
            if (dv.Count == 0)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("fbdw_mc", "");
                    projectDetail.Add("fbdw_xmfzr", "");
                    projectDetail.Add("fbdw_jsfzr", "");
                }
                else
                {
                    projectDetail.Add("fbdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("fbdw_xmfzr", dv[0]["xmjl"].ToString());
                    projectDetail.Add("fbdw_jsfzr", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] fbdwmc = new string[dv.Count];  //��λ����
                string[] fbdwjsfzr = new string[dv.Count]; //����������
                string[] fbdwxmjl = new string[dv.Count]; //��Ŀ����
                for (int i = 0; i < dv.Count; i++)
                {
                    fbdwmc[i] = dv[i]["dwmc"].ToString();
                    fbdwjsfzr[i] = dv[i]["fzr"].ToString();
                    fbdwxmjl[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("fbdw_mc", fbdwmc);
                projectDetail.Add("fbdw_xmfzr", fbdwxmjl);
                projectDetail.Add("fbdw_jsfzr", fbdwjsfzr);
            }
            obj.unittype = "unit9";
            dv = unitData.GetList(obj).Tables[0].DefaultView;
            if (dv.Count == 0)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("zcbdw_mc", "");
                    projectDetail.Add("zcbdw_xmfzr", "");
                    projectDetail.Add("zcbdw_fzr", "");
                }
                else
                {
                    projectDetail.Add("zcbdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("zcbdw_xmfzr", dv[0]["xmjl"].ToString());
                    projectDetail.Add("zcbdw_fzr", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] zcbdwmc = new string[dv.Count];  //��λ����
                string[] zcbdwfzr = new string[dv.Count]; //�ܳа�������
                string[] zcbdwxmjl = new string[dv.Count]; //��Ŀ����
                for (int i = 0; i < dv.Count; i++)
                {
                    zcbdwmc[i] = dv[i]["dwmc"].ToString();
                    zcbdwfzr[i] = dv[i]["fzr"].ToString();
                    zcbdwxmjl[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("zcbdw_mc", zcbdwmc);
                projectDetail.Add("zcbdw_xmfzr", zcbdwxmjl);
                projectDetail.Add("zcbdw_fzr", zcbdwfzr);
            }
            obj.unittype = "unit10";
            dv = unitData.GetList(obj).Tables[0].DefaultView;
            if (dv.Count == 0)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("azdw_mc", "");
                    projectDetail.Add("azdw_xmfzr", "");
                    projectDetail.Add("azdw_azfzr", "");
                }
                else
                {
                    projectDetail.Add("azdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("azdw_xmfzr", dv[0]["xmjl"].ToString());
                    projectDetail.Add("azdw_azfzr", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] azdwmc = new string[dv.Count];  //��λ����
                string[] azdwazfzr = new string[dv.Count]; //��װ������
                string[] azdwxmjl = new string[dv.Count]; //��Ŀ����
                for (int i = 0; i < dv.Count; i++)
                {
                    azdwmc[i] = dv[i]["dwmc"].ToString();
                    azdwazfzr[i] = dv[i]["fzr"].ToString();
                    azdwxmjl[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("azdw_mc", azdwmc);
                projectDetail.Add("azdw_xmfzr", azdwxmjl);
                projectDetail.Add("azdw_azfzr", azdwazfzr);
            }
            obj.unittype = "unit12";
            dv = unitData.GetList(obj).Tables[0].DefaultView;
            if (dv.Count == 0)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("sgdw_bzz", "");
                }
                else
                {
                    projectDetail.Add("sgdw_bzz", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] sgdw_bzz = new string[dv.Count]; //���鳤
                for (int i = 0; i < dv.Count; i++)
                {
                    sgdw_bzz[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("sgdw_bzz", sgdw_bzz);
            }
            obj.unittype = "unit13";
            dv = unitData.GetList(obj).Tables[0].DefaultView;
            if (dv.Count == 0)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("sgdw_zygz", "");
                }
                else
                {
                    projectDetail.Add("sgdw_zygz", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] sgdw_zygz = new string[dv.Count]; //���鳤
                for (int i = 0; i < dv.Count; i++)
                {
                    sgdw_zygz[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("sgdw_zygz", sgdw_zygz);
            }
            this._projectDetail = projectDetail;
        }
        /// <summary>
        /// ��ȡ����������Ϣ���ڱ�ͷ���ʱ��
        /// </summary>
        public Hashtable ProjectDetail
        {
            get { return _projectDetail; }
        }
    }
}
