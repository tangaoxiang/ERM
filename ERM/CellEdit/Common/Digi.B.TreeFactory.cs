using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.IO;
using ERM.CBLL;
namespace ERM.UI
{
    public class DigiBTreeFactory
    {
        DataSet ds;
        DataSet dsArchive;
        ERM.CBLL.Vars vars = new Vars();
        /// <summary>
        /// 判断当前选中的节点是否为模版
        /// </summary>
        /// <returns>bool</returns>
        private bool Command_IsSelectModel(int pImageIndex) {
            return pImageIndex == 2;
        }
        /// <summary>
        /// 判断当前选中的节点是否为目录
        /// </summary>
        /// <returns>bool</returns>
        private bool Command_IsSelectFile(int pImageIndex) {
            return pImageIndex == 1;
        }
        /// <summary>
        /// 判断当前选中的节点是否为根节点
        /// </summary>
        /// <returns>bool</returns>
        private bool Command_IsSelectRoot(int pImageIndex) {
            return pImageIndex == 0;
        }
        /// 用递归的方法读取树
        /// </summary>
        /// <param name="treeView">需要把数据绑定到的TreeView控件</param>
        /// <param name="tableName">树的数据所在的表</param>
        public void GetTree(TreeView treeView, string fileRecording_templet, string  cell_tempet, bool withImage, string projectNo, bool IsAll)
        {
            treeView.Nodes.Clear();
            ds = vars.GetTrees(true, Globals.ProjectNO);
            DataView dataView = new DataView(ds.Tables[0]);
            dataView.RowFilter = "id='01'";
            if (dataView.Count == 0)
                return;
            DataRowView tRow = dataView[0];
            ERM.MDL.T_FileList M_FileRecording_Templet = this.Command_GetFile(tRow);//获取文件对象模型
            TreeNodeEx node = new TreeNodeEx();
            node.Name = M_FileRecording_Templet.id;         //节点唯一ID,用来检索
            node.Text = M_FileRecording_Templet.gdwj;          //标题
            node.Tag = M_FileRecording_Templet; //是否最后一个节点,范例路径,是否用户定义表格,附件
            node.Checked = M_FileRecording_Templet.isvisible ==1?true:false;//是否可见
            if (withImage)
            {
                node.ImageIndex = 0;//0为根目录图片号
                node.SelectedImageIndex = 0;//0为根目录图片号
            }
            treeView.BeginUpdate();
            treeView.Nodes.Add(node);
            LoadChildNodes(node, node.Name, withImage, IsAll);
            node.IsFirstExpand = false;
            treeView.EndUpdate();
            treeView.Nodes[0].Expand();
        }
        const string CPROJECTNO = "digipower";
        private ERM.MDL.T_CellAndEFile Command_GetModel(DataRowView tRow) {
            ERM.MDL.T_CellAndEFile M_Cell_Templet = new ERM.MDL.T_CellAndEFile();
            M_Cell_Templet.id = tRow["id"].ToString();  //节点唯一ID
            M_Cell_Templet.title = tRow["title"].ToString();    //标题
            M_Cell_Templet.filepath = tRow["filepath"].ToString();    //华表路径
            M_Cell_Templet.examplepath = tRow["examplepath"].ToString();  //范例文件
            M_Cell_Templet.codeno = tRow["codeno"].ToString();    //表格代码
            M_Cell_Templet.codetype = Convert.ToInt32(tRow["codetype"]);//结点类型
            M_Cell_Templet.customdefine = Convert.ToInt32(tRow["customdefine"]);//用户自定义
            M_Cell_Templet.fbmc = tRow["fbmc"].ToString();//分部名称
            M_Cell_Templet.fxmc = tRow["fxmc"].ToString();//分项名称
            M_Cell_Templet.isvisible = Convert.ToInt16( tRow["isvisible"]) ;//是否可见
            M_Cell_Templet.orderindex = Convert.ToInt32(tRow["orderindex"]);//顺序号
            M_Cell_Templet.parentid = tRow["parentid"].ToString();    //父节点ID
            M_Cell_Templet.ys = Convert.ToInt32(tRow["ys"]);//页数
            M_Cell_Templet.zfbmc = tRow["zfbmc"].ToString();//子分部名称
            M_Cell_Templet.zrr = tRow["zrr"].ToString();//责任人
            M_Cell_Templet.ProjectNO = CPROJECTNO;//工程编号
            return M_Cell_Templet;
        }
        private ERM.MDL.T_FileList Command_GetFile(DataRowView tRow) {
            ERM.MDL.T_FileList M_FileRecording_Templet = new ERM.MDL.T_FileList();
            M_FileRecording_Templet.id = tRow["id"].ToString();  //节点唯一ID
            M_FileRecording_Templet.gdwj = tRow["title"].ToString();    //标题
            M_FileRecording_Templet.zrr = tRow["zrr"].ToString();//责任人
            M_FileRecording_Templet.OrderIndex = Convert.ToInt32(tRow["orderindex"]);//顺序号
            M_FileRecording_Templet.isvisible = Convert.ToInt16( tRow["isvisible"]);//是否可见
            M_FileRecording_Templet.gclx = tRow["gclx"].ToString();
            M_FileRecording_Templet.jsdw = tRow["jsdw"].ToString();
            M_FileRecording_Templet.jldw = tRow["jldw"].ToString();
            M_FileRecording_Templet.sgdw = tRow["sgdw"].ToString();
            M_FileRecording_Templet.sjdw = tRow["sjdw"].ToString();
            M_FileRecording_Templet.wjmj = tRow["wjmj"].ToString();
            M_FileRecording_Templet.cjdag = tRow["cjdag"].ToString();
            M_FileRecording_Templet.table_name = tRow["table_name"].ToString();
            M_FileRecording_Templet.ProjectNO = CPROJECTNO;
            return M_FileRecording_Templet;
        }
        public void RefreshNode(TreeNodeEx Node, string fileRecording_templet, string cell_tempet, bool withImage, string projectNo, bool IsAll)
        {
            TreeView treeView1 = Node.TreeView;
            ////dsArchive = vars.GetArchives();
            Node.Nodes.Clear();
            ds = vars.GetTrees(true, Globals.ProjectNO);
            LoadChildNodes(Node, Node.Name, withImage, IsAll);
            Node.IsFirstExpand = false;
        }
        /// <summary>
        /// 获取树的节点，跟其他方法合用
        /// </summary>
        /// <param name="nodes">TreeNodeCollection</param>
        /// <param name="nodeID">要查询的节点</param>
        private void LoadChildNodes(TreeNodeEx pParentNode, string parentID, bool withImage, bool IsAll) {
            if (ds == null) {
                return;
            }
            DataView dataView = new DataView(ds.Tables[0]);
            dataView.RowFilter = "ParentID='" + parentID + "'";
            TreeNodeEx[] tNodes = new TreeNodeEx[dataView.Count];
            int tNodesCount = 0;
            foreach (DataRowView drv in dataView) {
                TreeNodeEx node = new TreeNodeEx();
                if (this.Command_IsSelectFile(Convert.ToInt32(drv["imageindex"]))) {
                    ERM.MDL.T_FileList M_FileRecording_Templet = this.Command_GetFile(drv);//获取文件对象模型
                    node.Name = M_FileRecording_Templet.id;         //节点唯一ID,用来检索
                    node.Text = M_FileRecording_Templet.gdwj;          //标题
                    node.Tag = M_FileRecording_Templet; //是否最后一个节点,范例路径,是否用户定义表格,附件
                    node.Checked = M_FileRecording_Templet.isvisible == 1 ? true : false;//是否可见
                } else if (this.Command_IsSelectModel(Convert.ToInt32(drv["imageindex"]))) {
                    ERM.MDL.T_CellAndEFile M_Cell_Templet = this.Command_GetModel(drv);//获取文件对象模型
                    node.Name = M_Cell_Templet.id;         //节点唯一ID,用来检索
                    node.Text = M_Cell_Templet.title;          //标题
                    node.Tag = M_Cell_Templet; //是否最后一个节点,范例路径,是否用户定义表格,附件
                    node.Checked = M_Cell_Templet.isvisible == 1 ? true : false;//是否可见
                    node.NodeKey = M_Cell_Templet.codeno;
                    node.NodeValue = M_Cell_Templet.filepath;
                } else if (this.Command_IsSelectRoot(Convert.ToInt32(drv["imageindex"]))) {
                    ERM.MDL.T_FileList M_FileRecording_Templet = this.Command_GetFile(drv);//获取文件对象模型
                    node.Name = M_FileRecording_Templet.id;         //节点唯一ID,用来检索
                    node.Text = M_FileRecording_Templet.gdwj;          //标题
                    node.Tag = M_FileRecording_Templet; //是否最后一个节点,范例路径,是否用户定义表格,附件
                    node.Checked = M_FileRecording_Templet.isvisible == 1 ? true : false;//是否可见
                }
                if (withImage) {
                    node.ImageIndex = Convert.ToInt32(drv["imageindex"]);
                    node.SelectedImageIndex = Convert.ToInt32(drv["imageindex"]);
                }
                node.Text = drv["title"].ToString();
                if (node.ImageIndex != 2)
                {
                    if (IsAll)
                    {
                        LoadChildNodes(node, node.Name, true, true);
                        node.IsFirstExpand = false;
                    }
                    else
                    {
                        TreeNodeEx node1 = new TreeNodeEx();
                        node1.Name = "临时数据";
                        node1.Text = "临时数据";
                        node.Nodes.Add(node1);
                    }
                }
                tNodes.SetValue(node, tNodesCount++);
            }
            if (80 < tNodes.Length) {//如果其含有的子节点数大于80个,启动BeginUpdate方法
                pParentNode.TreeView.BeginUpdate();
                pParentNode.Nodes.AddRange(tNodes);
                pParentNode.TreeView.EndUpdate();
            } else {
                pParentNode.Nodes.AddRange(tNodes);
            }
        }
        public string GetFileCount(string NodeID, int ImageIndex)
        {
            string count = "[0]";
            if (ImageIndex == 2)
            {
                DataView dataView = new DataView(dsArchive.Tables[0]);
                dataView.RowFilter = "CellParentID=" + NodeID ;
                count = "[" + dataView.Count + "]";
            }
            else
            {
                count = "";
            }
            return count;
        }
        /// <summary>
        /// 在TreeView控件上选中下一个节点
        /// </summary>
        /// <param name="treeView">TreeView</param>
        public void SelectNextNode(TreeView treeView)
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
        /// 在TreeView控件上寻找到节点，然后选中该节点
        /// </summary>
        /// <param name="node">需要选中的节点</param>
        public void SelectNode(TreeNodeEx node)
        {
            try
            {
                TreeView tv = node.TreeView;
                string nodeID = node.Name;
                TreeNode[] nodes = tv.Nodes[0].Nodes.Find(nodeID, true);
                if (nodes != null && nodes.Length > 0)
                {
                    tv.Visible = false;
                    tv.SelectedNode = tv.Nodes[0];  //先选定根节点，保证AfterSelect事件触发
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
            catch { }
        }
        /// <summary>
        /// 在TreeView控件上寻找到NodeID,然后选中该节点
        /// </summary>
        /// <param name="tv">TreeView控件</param>
        /// <param name="NodeID">NodeID,该值在Node.Name上</param>
        public void SelectNode(TreeView tv, string NodeID)
        {
            TreeNode[] nodes = tv.Nodes[0].Nodes.Find(NodeID, true);
            if (nodes != null && nodes.Length > 0)
            {
                tv.Visible = false;
                tv.SelectedNode = tv.Nodes[0];  //先选定根节点，保证AfterSelect事件触发
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
        /// 在TreeView控件上寻找到NodeID,然后选中该节点
        /// </summary>
        /// <param name="tv">TreeView控件</param>
        /// <param name="NodeID">NodeID,该值在Node.Name上</param>
        public void SelectNodeO(TreeView tv, string NodeID)
        {
            TreeNode[] nodes = tv.Nodes[0].Nodes.Find(NodeID, true);
            if (nodes != null && nodes.Length > 0)
            {
                tv.Visible = false;
                tv.SelectedNode = tv.Nodes[0];  //先选定根节点，保证AfterSelect事件触发
                tv.SelectedNode = nodes[0];
                if (nodes[0].Nodes != null && nodes[0].Nodes.Count > 0)
                {
                    nodes[0].Expand();
                }
                tv.Visible = true;
            }
            tv.Focus();
        }
        /// <summary>
        /// 在TreeView控件上寻找到NodeID,然后选中该节点 不是从nodes[0].nodes
        /// </summary>
        /// <param name="tv">TreeView控件</param>
        /// <param name="NodeID">NodeID,该值在Node.Name上</param>
        public void SelectNode1(TreeView tv, string NodeID)
        {
            TreeNode[] nodes = tv.Nodes.Find(NodeID, true);
            if (nodes != null && nodes.Length > 0)
            {
                tv.Visible = false;
                tv.SelectedNode = tv.Nodes[0];  //先选定根节点，保证AfterSelect事件触发
                tv.SelectedNode = nodes[0];
                if (nodes[0].Nodes != null && nodes[0].Nodes.Count > 0)
                {
                    nodes[0].Expand();
                }
                tv.Visible = true;
            }
            tv.Focus();
        }
        /// <summary>
        /// 删除某一节点及所有子节点，调用时请先使Cell控件打开的是空表，
        /// 而是不需要删除的节点中的某一表格，以防删除电子文件失败
        /// </summary>
        /// <param name="theNode"></param>
        /// <param name="tableName"></param>
        /// <param name="projectNo"></param>
        public void DelNodes(TreeNodeEx theNode, string tableName, string projectNo)
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
                    common.DeleteAndCreateEmptyDirectory(Globals.ProjectPath);
                }
                return;
            }
            this.DelNode(theNode, tableName, projectNo);
            if (theNode.Parent != null)
            {
                TreeNodeEx parentNode = (TreeNodeEx)theNode.Parent;
                if (parentNode.Nodes.Count == 1)
                {
                    sql = "update " + tableName + " set lastleaf=1 where nodeid=" + parentNode.Name;
                    if (projectNo != "")
                    {
                        sql += " and ProjectNO='" + projectNo + "'";
                    }
                }
            }
        }
        private void DelNode(TreeNodeEx theNode, string tableName, string projectNo)
        {
            ////删除数据库中的记录
            ////DBFunc.ExecuteSql(sql);
            ////删除附件
            ////递归
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
        /// 用递归的方法读取树
        /// </summary>
        /// <param name="treeView">需要把数据绑定到的TreeView控件</param>
        /// <param name="tableName">树的数据所在的表</param>
        public void GetFileTree(TreeView treeView, bool withImage, string projectNo, bool isAll)
        {
            treeView.Nodes.Clear();
            ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            ds = cbll.GetNewFileRecording_Templet(projectNo);
            DataView dataView = new DataView(ds.Tables[0]);
            dataView.RowFilter = "id='01'";
            if (dataView.Count == 0)
                return;
            string nodeID = "";
            string title = "";
            int imageindex = 0;
            string tag = "";
            TreeNodeEx node;
            nodeID = dataView[0]["id"].ToString();  //节点唯一ID
            title = dataView[0]["title"].ToString();    //标题
            tag = dataView[0]["table_name"].ToString();
            node = new TreeNodeEx();
            node.Name = nodeID;         //节点唯一ID,用来检索
            node.Text = title;          //标题
            node.Tag = tag;
            if (withImage)
            {
                node.ImageIndex = imageindex;
                node.SelectedImageIndex = imageindex;
            }
            treeView.BeginUpdate();
            LoadFileChildNodes(node.Nodes, nodeID, withImage,  isAll);
            treeView.Nodes.Add(node);
            treeView.EndUpdate();
            treeView.Nodes[0].Expand();
            ds = null;
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
            List<string> list = new List<string>();
            DataRow[] rows = NewData.Tables[0].Select("imageindex = 2");
            list = FilterDataByPath(rows, list, NewData);
            string path = SetList2SqlIn(list);
            DataRow[] NewRows = NewData.Tables[0].Select("treepath not in (" + path + ")");
            foreach (DataRow dr in NewRows)
            {
                NewData.Tables[0].Rows.Remove(dr);
            }
            return NewData;
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
        private void LoadFileChildNodes(TreeNodeCollection nodes, string parentID, bool withImage, bool isAll)
        {
            ERM.CBLL.FileRegist cbll = new FileRegist();
            if (ds == null)
            {
                return;
            }
            DataView dataView = new DataView(ds.Tables[0]);
            dataView.RowFilter = "parentid='" + parentID + "' and imageindex<>2";
            foreach (DataRowView drv in dataView)
            {
                TreeNodeEx node = new TreeNodeEx();
                node.Name = drv["id"].ToString();
                node.Tag = drv["table_name"].ToString();
                if (withImage)
                {
                    node.ImageIndex = Convert.ToInt32(drv["imageindex"]);
                    node.SelectedImageIndex = Convert.ToInt32(drv["imageindex"]);
                }
                node.Text = drv["title"].ToString();
                nodes.Add(node);
                if (isAll)
                {
                    LoadFileChildNodes(node.Nodes, node.Name, withImage,  isAll);
                    node.IsFirstExpand = false;
                }
                else
                {
                    if (GetFileCount(drv["id"].ToString(), Convert.ToInt32(drv["imageindex"])) != "[0]")
                    {
                        if (cbll.GetNewFileRecording_TempletCountlist(node.FullPath))
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
            string NUM = cbll.GetAttachmentListCount(OpeartPath(node), Globals.ProjectNO);
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
        private string OpeartPath(TreeNodeEx node)
        {
            if (node != null)
            {
                if (node.ImageIndex == 2 | node.ImageIndex == 4 | node.ImageIndex == 5)
                {
                    string treepath = null;
                    if (node.Text.LastIndexOf("]") > 0)
                    {
                        treepath = node.Parent.FullPath + "\\" + node.Text.Substring(node.Text.LastIndexOf("]") + 1);
                    }
                    else
                    {
                        treepath = node.Parent.FullPath + "\\" + node.Text;
                    }
                    treepath = treepath.Replace("*", "");
                    return treepath;
                }
                if (node.ImageIndex == 3)
                {
                    string treepath = null;
                    if (node.Text.LastIndexOf("]") > 0)
                    {
                        treepath = node.Parent.FullPath + "\\" + node.Text.Substring(node.Text.LastIndexOf("]") + 1);
                    }
                    else
                    {
                        treepath = node.Parent.FullPath + "\\" + node.Text;
                    }
                    treepath = treepath.Replace("*", "");
                    return treepath;
                }
                return null;
            }
            else
            {
                return null;
            }
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
        /// 刷新节点
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="withImage"></param>
        /// <param name="projectNo"></param>
        /// <param name="IsCount"></param>
        /// <param name="isAll"></param>
        public void RefreshFileNode(TreeNode NodeNode, bool withImage, string projectNo, bool isAll)
        {
            TreeNodeEx Node = (TreeNodeEx)NodeNode;
            TreeView treeView1 = Node.TreeView;
            ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            ds = cbll.RegistGetNewFileRecording_Templet(projectNo);
            DataView dataView = new DataView(ds.Tables[0]);
            if (dataView.Count == 0)
            {
                treeView1.Nodes.Clear();
                return;
            }
            Node.Nodes.Clear();
            dataView.RowFilter = "id='" + Node.Name + "'";
            if (dataView.Count > 0)
            {
                treeView1.BeginUpdate();
                Node.Text = dataView[0]["title"].ToString();
                Node.Tag = dataView[0]["table_name"].ToString();
                LoadFileChildNodes(Node.Nodes, Node.Name, withImage, isAll);
                Node.IsFirstExpand = false;
                treeView1.EndUpdate();
            }
        }
    }
}
