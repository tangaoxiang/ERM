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
namespace ERM.UI
{
    public class NewFactory : ITreeFactory
    {
            DataSet ds;
            DataSet dsSearch;
            DataSet dsArchive;
            ERM.CBLL.CellTreesData treesData = new ERM.CBLL.CellTreesData();
        /// <summary>
        /// 设置模板图标
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
        public DataSet GetDS(string projectNo,string KeyString)
        {
            ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            dsSearch = cbll.GetSearchDS(projectNo, KeyString);
            return dsSearch;
        }
        /// 用递归的方法读取树
        /// </summary>
        /// <param name="treeView">需要把数据绑定到的TreeView控件</param>
        /// <param name="tableName">树的数据所在的表</param>
        public void GetTree(TreeView treeView, bool withImage, string projectNo, bool IsCount, bool isAll)
            {
                ////获取数据
                ////新建节点
                ////添加节点
                ////添加子节点
                ////展开根节点
                ////销毁
            }
        public void RefreshNode(TreeNodeEx Node, bool withImage, string projectNo, bool IsCount, bool isAll, CellCreate enumTree)
        {
            ////树
            ////添加节点
            ////添加子节点
            ////销毁
        }
        /// <summary>
        /// 获取树的节点，跟其他方法合用
        /// </summary>
        /// <param name="nodes">TreeNodeCollection</param>
        /// <param name="nodeID">要查询的节点</param>
            /// 用递归的方法读取树
            /// </summary>
            /// <param name="treeView">需要把数据绑定到的TreeView控件</param>
            /// <param name="tableName">树的数据所在的表</param>
            public void GetFileTree(TreeView treeView, string fileRecording_templet, string cell_tempet, bool withImage, string projectNo, bool IsCount, bool isAll, FileStatus treeEnum)
            {
                treeView.Nodes.Clear();
                ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
                if (treeEnum == FileStatus.Full)
                {
                    ds = cbll.RegistGetNewFileRecording_Templet(projectNo);
                }
                else
                {
                    ds = FilterData(ds, treeEnum);
                }
                CellTreesData treesData = new CellTreesData();
                dsArchive = treesData.GetArchives(projectNo);
                if (ds != null)
                {
                    DataView dataView = new DataView(ds.Tables[0]);
                    dataView.RowFilter = "id='01'";
                    if (dataView.Count == 0)
                        return;
                    string nodeID = "";
                    string title = "";
                    string codeno = "";
                    int imageindex = 0;
                    TreeNodeEx node;
                    nodeID = dataView[0]["ParentPath"].ToString();  //节点唯一ID
                    title = dataView[0]["title"].ToString();    //标题
                    codeno = dataView[0]["id"].ToString();    //表格代码
                    node = new TreeNodeEx();
                    node.Name = "01";         //节点唯一ID,用来检索
                    node.Text = title;          //标题
                    if (withImage)
                    {
                        node.ImageIndex = imageindex;
                        node.SelectedImageIndex = imageindex;
                    }
                    treeView.BeginUpdate();
                    treeView.Nodes.Add(node);
                    if (string.IsNullOrEmpty(nodeID))
                    {
                        nodeID = dataView[0]["treepath"].ToString();
                    }
                    LoadFileChildNodes(node.Nodes, codeno, withImage, IsCount, isAll);
                    treeView.EndUpdate();
                    treeView.Nodes[0].Expand();
                    ds = null;
                }
            }
            /// <summary>
            /// 过滤文件登记数据
            /// </summary>
            /// <param name="data"></param>
            /// <param name="treeEnum"></param>
            /// <returns></returns>
            private DataSet FilterData(DataSet data, FileStatus treeEnum)
            {
                return null;
            }
            private DataSet FilterDataWithNoNode(DataSet NewData)
            {
                ERM.CBLL.CellTreesData CBLL = new CellTreesData();
                List<string> list = new List<string>();
                DataRow[] rows = NewData.Tables[0].Select("imageindex = 2");
                if (rows.Length > 0)
                {
                    list = FilterDataByPath(rows, list, NewData);
                    string path = SetList2SqlIn(list);
                    DataRow[] NewRows = NewData.Tables[0].Select("treepath not in (" + path + ")");
                    foreach (DataRow dr in NewRows)
                    {
                        NewData.Tables[0].Rows.Remove(dr);
                    }
                    return NewData;
                }
                return null;
            }
            /// <summary>
            /// 把list/string/转成SQL 中的in格式
            /// </summary>
            /// <param name="list"></param>
            /// <returns></returns>
            private string SetList2SqlIn(List<string> list)
            {
                string strlist = "";
                string ss = "123";
                foreach (string str in list)
                {
                    strlist += ("'" + str + "',");
                }
                strlist += ("'" + ss + "',");
                return strlist;
            }
            /// <summary>
            /// 获取树的节点，跟其他方法合用
            /// </summary>
            /// <param name="nodes">TreeNodeCollection</param>
            /// <param name="nodeID">要查询的节点</param>
            private void LoadFileChildNodes(TreeNodeCollection nodes, string parentID, bool withImage, bool IsCount, bool isAll)
            {
                if (ds == null)
                {
                    return;
                }
                DataView dataView = new DataView(ds.Tables[0]);
                dataView.RowFilter = "parentid='" + parentID + "'";
                foreach (DataRowView drv in dataView)
                {
                    TreeNodeEx node = new TreeNodeEx();
                    node.Name = drv["id"].ToString();
                    node.NodeKey = drv["id"].ToString();
                    if (withImage)
                    {
                        node.ImageIndex = Convert.ToInt32(drv["imageindex"]);
                        node.SelectedImageIndex = Convert.ToInt32(drv["imageindex"]);
                    }
                    node.Text = drv["title"].ToString();
                    nodes.Add(node);
                    if (IsCount)
                    {
                        if (node.ImageIndex == 5 || node.ImageIndex == 2)
                        {
                            node.Text = GetFinal_fileCount(node) + drv["title"].ToString();
                        }
                    }
                    if (isAll)
                    {
                        node.IsFirstExpand = false;
                    }
                    else
                    {
                        if (GetFileCount(drv["id"].ToString(), Convert.ToInt32(drv["imageindex"])) != "[0]")
                        {
                            if (node.ImageIndex != 2)
                            {
                                TreeNodeEx node1 = new TreeNodeEx();
                                node1.Name = "临时数据";
                                node1.Text = "临时数据";
                                node.Nodes.Add(node1);
                            }
                        }
                    }
                }
            }
            public string GetFinal_fileCount(TreeNodeEx node)
            {
                ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
                string count = "[0]";
                string NUM = "0";
                if (node.ImageIndex == 4)
                {
                    NUM = cbll.GetAttachmentCheckListCount(OpeartPath(node), Globals.ProjectNO);
                }
                else
                {
                   NUM = cbll.GetAttachmentListCount(OpeartPath(node), Globals.ProjectNO);
                }
                if (!String.IsNullOrEmpty(NUM))
                {
                    count = "[" + NUM + "]";
                }
                return count;
            }
            /// <summary>
            /// 去掉路径中的[0],*
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            public string OpeartPath(TreeNodeEx node)
            {
                BLL.T_CellAndEFile_BLL efileBLL = new ERM.BLL.T_CellAndEFile_BLL();
                return efileBLL.Find(node.Name, Globals.ProjectNO).filepath;
            }
        /// <summary>
        /// 根据路径过滤数据
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="list"></param>
        /// <param name="NewData"></param>
        /// <returns></returns>
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
                        DataRow[] NewRows = NewData.Tables[0].Select("id = '" + rows[i]["parentid"].ToString() + "'");
                        list = FilterDataByPath(NewRows, list, NewData);
                    }
                }
                return list;
            }
            public string GetFileCount(string NodeID, int ImageIndex)
            {
                string count = "[0]";
                if (ImageIndex == 2)
                {
                    DataView dataView = new DataView(dsArchive.Tables[0]);
                    dataView.RowFilter = "CellParentID='" + NodeID + "'";
                    count = "[" + dataView.Count + "]";
                }
                else
                {
                    count = "";
                }
                return count;
            }
            /// <summary>
            /// 刷新节点
            /// </summary>
            /// <param name="Node"></param>
            /// <param name="withImage"></param>
            /// <param name="projectNo"></param>
            /// <param name="IsCount"></param>
            /// <param name="isAll"></param>
        public void RefreshFileNode(TreeNodeEx Node, bool withImage, string projectNo, bool IsCount, bool isAll, FileStatus treeEnum, bool IsRush)
            {
                TreeView treeView1 = Node.TreeView;
                ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    if (treeEnum == FileStatus.Full)
                    {
                        ds = cbll.RegistGetNewFileRecording_Templet(Globals.ProjectNO);
                    }
                    else
                    {
                        ds = FilterData(ds, treeEnum);
                    }
                }
                if (!IsRush)
                {
                    if (treeEnum == FileStatus.Full)
                    {
                        ds = cbll.RegistGetNewFileRecording_Templet(Globals.ProjectNO);
                    }
                    else
                    {
                        ds = FilterData(ds, treeEnum);
                    }
                }
                dsArchive = treesData.GetArchives(projectNo);
                DataView dataView = new DataView(ds.Tables[0]);
                if (dataView.Count == 0)
                {
                    treeView1.Nodes.Clear();
                    return;
                }
                Node.Nodes.Clear();
                if (Node.Parent == null)
                {
                    Node.Name = "01";
                }
                dataView.RowFilter = "id='" + Node.Name + "'";
                if (dataView.Count > 0)
                {
                    Node.NodeKey = dataView[0]["filepath"].ToString();
                    Node.NodeValue = dataView[0]["filepath"].ToString();    //华表路径
                    if (withImage)
                    {
                        if (Node.Parent == null)
                        {
                            Node.ImageIndex = 0;
                            Node.SelectedImageIndex = 0;
                        }
                        else
                        {
                            Node.ImageIndex = Convert.ToInt32(dataView[0]["imageindex"]);
                            Node.SelectedImageIndex = Convert.ToInt32(dataView[0]["imageindex"]);
                        }
                    }
                    if (IsCount)
                    {
                        if (Node.ImageIndex == 5 || Node.ImageIndex == 2)
                        {
                            Node.Text = GetFinal_fileCount(Node) + dataView[0]["title"].ToString();
                        }
                    }
                    treeView1.BeginUpdate();
                    LoadFileChildNodes(Node.Nodes, Node.Name, withImage, IsCount, isAll);
                    Node.IsFirstExpand = false;
                    treeView1.EndUpdate();
                }
            }
           /// <summary>
            /// 增加节点
           /// </summary>
           /// <param name="Node"></param>
           /// <param name="projectNo"></param>
            public void AddFileNode(TreeNodeEx Node, string projectNo)
            {
                int intCount = 0;
                List<string> list = new List<string>();
                ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
                string fullPath = OpeartPath(Node);
                if (Node.ImageIndex != 4)
                {
                    ds = cbll.GetArchiveDataAtPath(fullPath, projectNo);
                    DataView dataView = new DataView(ds.Tables[0]);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        TreeNodeEx NewNode = new TreeNodeEx();
                        NewNode.Name = ds.Tables[0].Rows[i]["id"].ToString();
                        NewNode.NodeKey = ds.Tables[0].Rows[i]["filepath"].ToString();    //表格代码
                        NewNode.NodeValue = ds.Tables[0].Rows[i]["filepath"].ToString();    //华表路径
                        NewNode.ImageIndex = 3;
                        NewNode.SelectedImageIndex = 3;
                        NewNode.Text = ds.Tables[0].Rows[i]["title"].ToString();           //标题
                        Node.Nodes.Add(NewNode);
                        list.Add(ds.Tables[0].Rows[i]["title"].ToString());
                        intCount++;
                    }
                }
                DataSet ADS = cbll.GetAttachment(fullPath, Globals.ProjectNO);
                bool IsHave = true;
                for (int i = 0; i < ADS.Tables[0].Rows.Count; i++)
                {
                    TreeNodeEx NewNode = new TreeNodeEx();
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (ADS.Tables[0].Rows[i]["title"].ToString().Equals(ds.Tables[0].Rows[j]["title"].ToString()))
                        {
                            IsHave = false;
                            break;
                        }
                    }
                    if (IsHave)
                    {
                        NewNode.Name = ADS.Tables[0].Rows[i]["attachid"].ToString();
                        NewNode.NodeKey = ADS.Tables[0].Rows[i]["attachid"].ToString();    //表格代码
                        NewNode.NodeValue = ADS.Tables[0].Rows[i]["filepath"].ToString();    //华表路径
                        NewNode.ImageIndex = 3;
                        NewNode.SelectedImageIndex = 3;
                        NewNode.Text = ADS.Tables[0].Rows[i]["title"].ToString();           //标题
                        Node.Nodes.Add(NewNode);
                        intCount++;
                    }
                    IsHave = true;
                }
                Node.Expand();
                ds = null;
            }
            /// <summary>
            /// 设置模版图标
            /// </summary>
            /// <param name="NewNode"></param>
            /// <param name="cbll"></param>
            /// <param name="FileStatus"></param>
            /// <returns></returns>
            public void SetNodeIcon(TreeNodeEx NewNode)
            {
                CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
                if (NewNode.Nodes.Count > 0 && NewNode.ImageIndex==1)
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
            /// <summary>
            /// 在TreeView控件上选中上一个节点
            /// </summary>
            /// <param name="treeView">TreeView</param>
            public void SelectPrevNode(TreeView treeView)
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
            /// <summary>
            /// 在TreeView控件上选中下一个节点
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
            /// 创建用于 TreeView 的 ImageList
            /// </summary>
            /// <returns>ImageList</returns>
            public ImageList CreateTreeImageList()
            {
                ImageList imageList1 = new ImageList();
                imageList1.TransparentColor = Color.Magenta;
                imageList1.ColorDepth = ColorDepth.Depth24Bit;
                imageList1.Images.Add(Properties.Resources.tree_home);
                imageList1.Images.Add(Properties.Resources.tree_folder);
                imageList1.Images.Add(Properties.Resources.tree_file);
                imageList1.Images.Add(Properties.Resources.tree_cell);
                imageList1.Images.Add(Properties.Resources.tree_cell_lock);
                imageList1.Images.Add(Properties.Resources.tree_file_s);
                imageList1.Images.Add(Properties.Resources.tree_folder_s);
                return imageList1;
            }
        public void LoadRightTree(string ProjectNO, TreeView trvFile)
        {
            ERM.CBLL.FinalArchive CBFinalArchive = new ERM.CBLL.FinalArchive();
            DataSet dsUnGroup = CBFinalArchive.GetUnGroupFiles(ProjectNO,Globals.UnSignCanGroup);//未组卷的文件
            DataSet dsNewFileRecording_Templet_All = CBFinalArchive.GetNewFileRecording_Templet_All();//新归档目录所有的
            DataSet dsFinal_file = CBFinalArchive.GetFinalFile(ProjectNO, Globals.UnSignCanGroup);
            Dictionary<string, DataRow> dicAll = new Dictionary<string, DataRow>();
            foreach (DataRow dr in dsNewFileRecording_Templet_All.Tables[0].Rows)
            {
                dicAll.Add(dr["id"].ToString(), dr);
            }
            Dictionary<string, DataRow> dicUnGroup = new Dictionary<string, DataRow>();
            foreach (DataRow dr in dsUnGroup.Tables[0].Rows)
            {
                dicUnGroup.Add(dr["id"].ToString(), dr);
            }
            Dictionary<string, DataRow> dicTree = new Dictionary<string, DataRow>();
            foreach (KeyValuePair<string, DataRow> key in dicUnGroup)
            {
                if (!dicTree.ContainsKey(key.Key))
                {
                    dicTree.Add(key.Key, key.Value);
                    GetParent(key.Value["parentid"].ToString(), dicAll, dicTree);
                }
            }
            DataTable dt = dsUnGroup.Tables[0].Clone();
            foreach (KeyValuePair<string, DataRow> key in dicTree)
            {
                dt.ImportRow(key.Value);
            }
            trvFile.Nodes.Clear();
            DataRow[] drs = dt.Select("id='01'");
            TreeNode root = new TreeNode();
            if (drs.Length > 0)
            {
                root.Name = drs[0]["id"].ToString();
                root.Text = drs[0]["title"].ToString();
                root.ImageIndex = 0;
                root.SelectedImageIndex = 0;
                GetChild(root, dt, dsFinal_file);
            }
            else
            {
                root.Name = "01";
                root.Text = "工程性质";
                root.ImageIndex = 0;
                root.SelectedImageIndex = 0;
            }
            trvFile.Nodes.Add(root);
            trvFile.Nodes[0].Expand();
        }
        private void GetChild(TreeNode pNode, DataTable dt, DataSet dsFiles)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = "parentid='" + pNode.Name + "'";
            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    TreeNode node = new TreeNode();
                    node.Text = drv["title"].ToString();
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                    node.Name = drv["id"].ToString();
                    if (!string.IsNullOrEmpty(drv["oldid"].ToString()))
                    {
                        DataView dv2 = new DataView(dsFiles.Tables[0]);
                        dv2.RowFilter = "parentid='" + drv["oldid"].ToString() + "'";
                        foreach (DataRowView drv2 in dv2)
                        {
                            TreeNode node_file = new TreeNode();
                            node_file.Text = drv2["wjmc"].ToString();
                            node_file.Tag = drv2["FileId"].ToString();
                            node_file.Name = "pdf";
                            node_file.ImageIndex = 2;
                            node_file.SelectedImageIndex = 2;
                            node.Nodes.Add(node_file);
                        }
                    }
                    GetChild(node, dt, dsFiles);
                    pNode.Nodes.Add(node);
                }
            }
        }
        private void GetParent(string parentid, Dictionary<string, DataRow> dicAll, Dictionary<string, DataRow> dicTree)
        {
            if (!dicTree.ContainsKey(parentid))
            {
                if (parentid != "")
                {
                    dicTree.Add(dicAll[parentid]["id"].ToString(), dicAll[parentid]);
                    GetParent(dicAll[parentid]["parentid"].ToString(), dicAll, dicTree);
                }
            }
        }
        }
    }
