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
        /// �жϵ�ǰѡ�еĽڵ��Ƿ�Ϊģ��
        /// </summary>
        /// <returns>bool</returns>
        private bool Command_IsSelectModel(int pImageIndex) {
            return pImageIndex == 2;
        }
        /// <summary>
        /// �жϵ�ǰѡ�еĽڵ��Ƿ�ΪĿ¼
        /// </summary>
        /// <returns>bool</returns>
        private bool Command_IsSelectFile(int pImageIndex) {
            return pImageIndex == 1;
        }
        /// <summary>
        /// �жϵ�ǰѡ�еĽڵ��Ƿ�Ϊ���ڵ�
        /// </summary>
        /// <returns>bool</returns>
        private bool Command_IsSelectRoot(int pImageIndex) {
            return pImageIndex == 0;
        }
        /// �õݹ�ķ�����ȡ��
        /// </summary>
        /// <param name="treeView">��Ҫ�����ݰ󶨵���TreeView�ؼ�</param>
        /// <param name="tableName">�����������ڵı�</param>
        public void GetTree(TreeView treeView, string fileRecording_templet, string  cell_tempet, bool withImage, string projectNo, bool IsAll)
        {
            treeView.Nodes.Clear();
            ds = vars.GetTrees(true, Globals.ProjectNO);
            DataView dataView = new DataView(ds.Tables[0]);
            dataView.RowFilter = "id='01'";
            if (dataView.Count == 0)
                return;
            DataRowView tRow = dataView[0];
            ERM.MDL.T_FileList M_FileRecording_Templet = this.Command_GetFile(tRow);//��ȡ�ļ�����ģ��
            TreeNodeEx node = new TreeNodeEx();
            node.Name = M_FileRecording_Templet.id;         //�ڵ�ΨһID,��������
            node.Text = M_FileRecording_Templet.gdwj;          //����
            node.Tag = M_FileRecording_Templet; //�Ƿ����һ���ڵ�,����·��,�Ƿ��û�������,����
            node.Checked = M_FileRecording_Templet.isvisible ==1?true:false;//�Ƿ�ɼ�
            if (withImage)
            {
                node.ImageIndex = 0;//0Ϊ��Ŀ¼ͼƬ��
                node.SelectedImageIndex = 0;//0Ϊ��Ŀ¼ͼƬ��
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
            M_Cell_Templet.id = tRow["id"].ToString();  //�ڵ�ΨһID
            M_Cell_Templet.title = tRow["title"].ToString();    //����
            M_Cell_Templet.filepath = tRow["filepath"].ToString();    //����·��
            M_Cell_Templet.examplepath = tRow["examplepath"].ToString();  //�����ļ�
            M_Cell_Templet.codeno = tRow["codeno"].ToString();    //������
            M_Cell_Templet.codetype = Convert.ToInt32(tRow["codetype"]);//�������
            M_Cell_Templet.customdefine = Convert.ToInt32(tRow["customdefine"]);//�û��Զ���
            M_Cell_Templet.fbmc = tRow["fbmc"].ToString();//�ֲ�����
            M_Cell_Templet.fxmc = tRow["fxmc"].ToString();//��������
            M_Cell_Templet.isvisible = Convert.ToInt16( tRow["isvisible"]) ;//�Ƿ�ɼ�
            M_Cell_Templet.orderindex = Convert.ToInt32(tRow["orderindex"]);//˳���
            M_Cell_Templet.parentid = tRow["parentid"].ToString();    //���ڵ�ID
            M_Cell_Templet.ys = Convert.ToInt32(tRow["ys"]);//ҳ��
            M_Cell_Templet.zfbmc = tRow["zfbmc"].ToString();//�ӷֲ�����
            M_Cell_Templet.zrr = tRow["zrr"].ToString();//������
            M_Cell_Templet.ProjectNO = CPROJECTNO;//���̱��
            return M_Cell_Templet;
        }
        private ERM.MDL.T_FileList Command_GetFile(DataRowView tRow) {
            ERM.MDL.T_FileList M_FileRecording_Templet = new ERM.MDL.T_FileList();
            M_FileRecording_Templet.id = tRow["id"].ToString();  //�ڵ�ΨһID
            M_FileRecording_Templet.gdwj = tRow["title"].ToString();    //����
            M_FileRecording_Templet.zrr = tRow["zrr"].ToString();//������
            M_FileRecording_Templet.OrderIndex = Convert.ToInt32(tRow["orderindex"]);//˳���
            M_FileRecording_Templet.isvisible = Convert.ToInt16( tRow["isvisible"]);//�Ƿ�ɼ�
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
        /// ��ȡ���Ľڵ㣬��������������
        /// </summary>
        /// <param name="nodes">TreeNodeCollection</param>
        /// <param name="nodeID">Ҫ��ѯ�Ľڵ�</param>
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
                    ERM.MDL.T_FileList M_FileRecording_Templet = this.Command_GetFile(drv);//��ȡ�ļ�����ģ��
                    node.Name = M_FileRecording_Templet.id;         //�ڵ�ΨһID,��������
                    node.Text = M_FileRecording_Templet.gdwj;          //����
                    node.Tag = M_FileRecording_Templet; //�Ƿ����һ���ڵ�,����·��,�Ƿ��û�������,����
                    node.Checked = M_FileRecording_Templet.isvisible == 1 ? true : false;//�Ƿ�ɼ�
                } else if (this.Command_IsSelectModel(Convert.ToInt32(drv["imageindex"]))) {
                    ERM.MDL.T_CellAndEFile M_Cell_Templet = this.Command_GetModel(drv);//��ȡ�ļ�����ģ��
                    node.Name = M_Cell_Templet.id;         //�ڵ�ΨһID,��������
                    node.Text = M_Cell_Templet.title;          //����
                    node.Tag = M_Cell_Templet; //�Ƿ����һ���ڵ�,����·��,�Ƿ��û�������,����
                    node.Checked = M_Cell_Templet.isvisible == 1 ? true : false;//�Ƿ�ɼ�
                    node.NodeKey = M_Cell_Templet.codeno;
                    node.NodeValue = M_Cell_Templet.filepath;
                } else if (this.Command_IsSelectRoot(Convert.ToInt32(drv["imageindex"]))) {
                    ERM.MDL.T_FileList M_FileRecording_Templet = this.Command_GetFile(drv);//��ȡ�ļ�����ģ��
                    node.Name = M_FileRecording_Templet.id;         //�ڵ�ΨһID,��������
                    node.Text = M_FileRecording_Templet.gdwj;          //����
                    node.Tag = M_FileRecording_Templet; //�Ƿ����һ���ڵ�,����·��,�Ƿ��û�������,����
                    node.Checked = M_FileRecording_Templet.isvisible == 1 ? true : false;//�Ƿ�ɼ�
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
                        node1.Name = "��ʱ����";
                        node1.Text = "��ʱ����";
                        node.Nodes.Add(node1);
                    }
                }
                tNodes.SetValue(node, tNodesCount++);
            }
            if (80 < tNodes.Length) {//����京�е��ӽڵ�������80��,����BeginUpdate����
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
        /// ��TreeView�ؼ���ѡ����һ���ڵ�
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
        /// ��TreeView�ؼ���ѡ����һ���ڵ�
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
        /// ��TreeView�ؼ���Ѱ�ҵ��ڵ㣬Ȼ��ѡ�иýڵ�
        /// </summary>
        /// <param name="node">��Ҫѡ�еĽڵ�</param>
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
                    tv.SelectedNode = tv.Nodes[0];  //��ѡ�����ڵ㣬��֤AfterSelect�¼�����
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
        /// ��TreeView�ؼ���Ѱ�ҵ�NodeID,Ȼ��ѡ�иýڵ�
        /// </summary>
        /// <param name="tv">TreeView�ؼ�</param>
        /// <param name="NodeID">NodeID,��ֵ��Node.Name��</param>
        public void SelectNode(TreeView tv, string NodeID)
        {
            TreeNode[] nodes = tv.Nodes[0].Nodes.Find(NodeID, true);
            if (nodes != null && nodes.Length > 0)
            {
                tv.Visible = false;
                tv.SelectedNode = tv.Nodes[0];  //��ѡ�����ڵ㣬��֤AfterSelect�¼�����
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
        /// ��TreeView�ؼ���Ѱ�ҵ�NodeID,Ȼ��ѡ�иýڵ�
        /// </summary>
        /// <param name="tv">TreeView�ؼ�</param>
        /// <param name="NodeID">NodeID,��ֵ��Node.Name��</param>
        public void SelectNodeO(TreeView tv, string NodeID)
        {
            TreeNode[] nodes = tv.Nodes[0].Nodes.Find(NodeID, true);
            if (nodes != null && nodes.Length > 0)
            {
                tv.Visible = false;
                tv.SelectedNode = tv.Nodes[0];  //��ѡ�����ڵ㣬��֤AfterSelect�¼�����
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
        /// ��TreeView�ؼ���Ѱ�ҵ�NodeID,Ȼ��ѡ�иýڵ� ���Ǵ�nodes[0].nodes
        /// </summary>
        /// <param name="tv">TreeView�ؼ�</param>
        /// <param name="NodeID">NodeID,��ֵ��Node.Name��</param>
        public void SelectNode1(TreeView tv, string NodeID)
        {
            TreeNode[] nodes = tv.Nodes.Find(NodeID, true);
            if (nodes != null && nodes.Length > 0)
            {
                tv.Visible = false;
                tv.SelectedNode = tv.Nodes[0];  //��ѡ�����ڵ㣬��֤AfterSelect�¼�����
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
        /// ɾ��ĳһ�ڵ㼰�����ӽڵ㣬����ʱ����ʹCell�ؼ��򿪵��ǿձ�
        /// ���ǲ���Ҫɾ���Ľڵ��е�ĳһ����Է�ɾ�������ļ�ʧ��
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
            ////ɾ�����ݿ��еļ�¼
            ////DBFunc.ExecuteSql(sql);
            ////ɾ������
            ////�ݹ�
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
            imageList1.Images.Add(Properties.Resources.tree_home);
            imageList1.Images.Add(Properties.Resources.tree_folder);
            imageList1.Images.Add(Properties.Resources.tree_file);
            imageList1.Images.Add(Properties.Resources.tree_cell);
            imageList1.Images.Add(Properties.Resources.tree_cell_lock);
            imageList1.Images.Add(Properties.Resources.tree_file_s);
            imageList1.Images.Add(Properties.Resources.tree_folder_s);
            return imageList1;
        }
        /// �õݹ�ķ�����ȡ��
        /// </summary>
        /// <param name="treeView">��Ҫ�����ݰ󶨵���TreeView�ؼ�</param>
        /// <param name="tableName">�����������ڵı�</param>
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
            nodeID = dataView[0]["id"].ToString();  //�ڵ�ΨһID
            title = dataView[0]["title"].ToString();    //����
            tag = dataView[0]["table_name"].ToString();
            node = new TreeNodeEx();
            node.Name = nodeID;         //�ڵ�ΨһID,��������
            node.Text = title;          //����
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
        /// �����ļ��Ǽ�����
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
        /// ��list/string/ת��SQL �е�in��ʽ
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
        /// ��ȡ���Ľڵ㣬��������������
        /// </summary>
        /// <param name="nodes">TreeNodeCollection</param>
        /// <param name="nodeID">Ҫ��ѯ�Ľڵ�</param>
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
                            node1.Name = "��ʱ����";
                            node1.Text = "��ʱ����";
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
        /// ȥ��·���е�[0],*
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
        /// ˢ�½ڵ�
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
