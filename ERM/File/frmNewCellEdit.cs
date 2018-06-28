using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.CBLL;
using ERM.Common;
namespace ERM.UI
{
    public partial class frmNewCellEdit : Form
    {
        Form parentForm;
        private DigiBTreeFactory treeFactory = new DigiBTreeFactory();
        CellTreesData td = new CellTreesData();
        int TreeOrList = 0;
        public frmNewCellEdit(Form f)
        {
            InitializeComponent();
            treeView1.ImageList = treeFactory.CreateTreeImageList();
            treeView1.HideSelection = false;
            LoadList();
            parentForm = f;
            ;
            treeFactory.GetFileTree(this.treeView1, true, Globals.ProjectNO, true);
            CheckEnable();
        }
        /// <summary>
        /// 新增节点的方法 
        /// </summary>
        /// <param name="Level">根为0,同级为1,子级为2</param>
        private void NewNode(int Level)
        {
            TreeNode Node = treeView1.SelectedNode;
            if (Node == null && Level != 0)
                return;
            if (Node != null)
            {
                if (Node.Tag.ToString() != "kongbai")
                {
                    Functions.ShowWarning("节点为归档文件，不能在该节点下添加自定义目录！");
                    return;
                }
                if (Level == 2)
                {
                    if (Node.Nodes.Count > 0)
                    {
                        if (CheckCanDragDrop(Node))
                        {
                            Functions.ShowWarning("归档文件只能在最末级！不能添加！");
                            return;
                        }
                    }
                }
                else if (Level == 1)
                {
                    if (Node.Parent == null) return;
                    if (CheckCanDragDrop(Node.Parent))
                    {
                        Functions.ShowWarning("归档文件只能在最末级！,不能添加！");
                        return;
                    }
                }
            }
            frmSetNodeName frm = new frmSetNodeName(Node, "同级节点", this.treeView1);
            DialogResult drs = frm.ShowDialog();
            if (drs == DialogResult.OK)
            {
                if (!CheckSameTitle(Level, Node, frm.GetNodeText))
                {
                    Functions.ShowWarning("同一节点下不能同名!");
                    return;
                }
                ;
                string id = Level == 0 ? "01" : Level == 1 ? td.GetNewFileRecording_Templet_NextID(Node.Parent.Name) : td.GetNewFileRecording_Templet_NextID(Node.Name);
                string title = Functions.ToSqlString(frm.GetNodeText);
                string ptreepath = Level == 0 ? "" : Level == 1 ? Functions.ToSqlString(Node.Parent.FullPath) : Functions.ToSqlString(Node.FullPath);
                string treepath = Level == 0 ? title : Functions.ToSqlString(ptreepath) + "\\" + title;
                string table_name = "kongbai";
                td.InsertNewFileRecording_Templet(ptreepath, treepath, table_name, title, id);
                if (Level == 0 || Node.Level == 0)
                    treeFactory.GetFileTree(this.treeView1, true, Globals.ProjectNO, true);
                else
                    treeFactory.RefreshFileNode(Level == 1 ? Node.Parent : Node, true, Globals.ProjectNO, true);
                treeFactory.SelectNode1(this.treeView1, id);
                treeView1.Focus();
            }
        }
        /// <summary>
        /// 新增同级目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAddNodeBrother_Click(object sender, EventArgs e)
        {
            NewNode(1);
        }
        /// <summary>
        /// 新增子目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAddNodeChild_Click(object sender, EventArgs e)
        {
            NewNode(2);
        }
        /// <summary>
        /// 选择带编号的文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAddBrotherModel_Click(object sender, EventArgs e)
        {
            frmSelectTemplate frm = new frmSelectTemplate();
            frm.Show();
        }
        /// <summary>
        /// 新增加根目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAddRoot_Click(object sender, EventArgs e)
        {
            NewNode(0);
        }
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            if (TreeOrList == 2)
            {
                Point pt;
                TreeNode targeNode;
                pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
                targeNode = (TreeNode)this.treeView1.GetNodeAt(pt);
                if (string.Compare(targeNode.Tag.ToString(), "kongbai", true) != 0)
                {
                    return;
                }
                if (!CheckCanDragDrop(targeNode))
                {
                    Functions.ShowWarning("归档文件只能添加在最末级！");
                    return;
                }
                if (targeNode.Name.Length > 2)
                {
                    ListViewItem NewItem = (ListViewItem)e.Data.GetData("System.Windows.Forms.ListViewItem");
                    ListView.SelectedListViewItemCollection ListItems = listView1.SelectedItems;
                    int flag = td.GetNewFileRecording_TempletID(targeNode.Name);
                    if (ListItems.Count + flag > 99)
                    {
                        if (Functions.ShowQuestion("该节点下包含过多的文件,要继续添加吗?") != DialogResult.Yes)
                            return;
                    }
                    ;
                    foreach (ListViewItem item in ListItems)
                    {
                        if (flag > 99)
                        {
                            Functions.ShowWarning("ID超出范围");
                            break;
                        }
                        TreeNode NewNode = new TreeNode();
                        NewNode.Text = item.Text;
                        NewNode.Tag = item.Name;
                        NewNode.ImageIndex = 1;
                        NewNode.SelectedImageIndex = 1;
                        NewNode.Name = targeNode.Name + flag.ToString("D2");
                        targeNode.Nodes.Add(NewNode);
                        td.InsertNewFileRecording_Templet(Functions.ToSqlString(NewNode.Parent.FullPath), Functions.ToSqlString(NewNode.FullPath), NewNode.Tag.ToString(), item.Text, targeNode.Name + flag.ToString("D2"));
                        flag++;
                    }
                    LoadList();
                    targeNode.Expand();
                }
            }
        }
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private bool CheckCanDragDrop(TreeNode tn)
        {
            foreach (TreeNode node in tn.Nodes)
            {
                if (string.Compare(node.Tag.ToString(), "kongbai", true) == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private bool CheckSameTitle(int level, TreeNode tn,string title)
        {
            if (level == 0) return true;//根目录
            if (level == 1)//如果是根目录的同级目录  不会发生
            {
                if (tn.Level == 0) return false;
            }
            TreeNode tmp = level == 1 ? tn.Parent : tn;//同级目录就选父,子目录就是当前
            foreach (TreeNode node in tn.Nodes)
            {
                if (node.Text == title)
                    return false;
            }
            return true;
        }
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeOrList = 1;
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);
                TreeNode theNode = treeView1.GetNodeAt(p);
                if (theNode != null)
                {
                    treeView1.SelectedNode = theNode;
                }
            }
        }
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeOrList = 2;
        }
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            ;
            TreeNodeEx NewNode = (TreeNodeEx)(e.Node);
            if (NewNode.Parent != null)
            {
                if (NewNode.IsFirstExpand)
                {
                    RefreshNode((TreeNodeEx)NewNode);
                }
            }
        }
        /// <summary>
        /// 全部展开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_ExpandAll_Click(object sender, EventArgs e)
        {
            ;
            treeView1.BeginUpdate();
            treeView1.ExpandAll();
            if (treeView1.Nodes[0] != null)
            {
                treeView1.Nodes[0].EnsureVisible();
                treeView1.SelectedNode = treeView1.Nodes[0];
            }
            treeView1.EndUpdate();
        }
        /// <summary>
        /// 全部折叠
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_CollapseAll_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
            if (treeView1.Nodes[0] != null)
            {
                treeView1.Nodes[0].EnsureVisible();
                treeView1.SelectedNode = treeView1.Nodes[0];
            }
        }
        /// <summary>
        /// 上一条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_Prev_Click(object sender, EventArgs e)
        {
            treeFactory.SelectPrevNode(treeView1);
        }
        /// <summary>
        /// 下一条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_Next_Click(object sender, EventArgs e)
        {
            treeFactory.SelectNextNode(treeView1);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_Del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除<" + this.treeView1.SelectedNode.Text + ">节点及其子节点信息", "节点删除警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ;
                this.DelNode(this.treeView1.SelectedNode);
            }
        }
        /// <summary>
        /// 刷新节点
        /// </summary>
        /// <param name="node"></param>
        private void RefreshNode(TreeNodeEx NewNode)
        {
            if (NewNode.IsFirstExpand)
            {
                if (NewNode.ImageIndex == 1)
                {
                    treeFactory.RefreshFileNode(NewNode, true, Globals.ProjectNO, true);
                }
            }
        }
        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="node"></param>
        private void DelNode(TreeNode node)
        {
            ////刷新节点
            td.DeleteNewFileRecording_Templet(node.Name);
            if (string.Compare("01", node.Name) != 0)
                treeFactory.RefreshFileNode(node.Parent, true, Globals.ProjectNO, true);
            else
                treeView1.Nodes.Clear();
            CheckEnable();
            LoadList();
        }
        /// <summary>
        /// 获取路径集合
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<string> GetTreepath(TreeNode NewNode, List<string> list)
        {
            foreach (TreeNode node in NewNode.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    list = GetTreepath(node, list);
                }
                else
                {
                    list.Add(node.FullPath);
                }
            }
            return list;
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
        /// 　初始化listview
        /// </summary>
        private void LoadList()
        {
            DataSet ds = td.GetTableName(Globals.ProjectNO);
            listView1.View = View.List;
            listView1.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListViewItem it = new ListViewItem();
                it.Name = ds.Tables[0].Rows[i]["table_name"].ToString();
                it.Text = ds.Tables[0].Rows[i]["gdwj"].ToString();
                listView1.Items.Add(it);
            }
        }
        private void frmNewCellEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
        }
        /// <summary>
        /// 按钮及菜单能否点击的判断
        /// </summary>
        private void CheckEnable()
        {
            t1_ExpandAll.Enabled = false;
            t1_CollapseAll.Enabled = false;
            t1_Find.Enabled = false;
            t1_Prev.Enabled = false;
            t1_Next.Enabled = false;
            MenuAddRoot.Enabled = false;
            MenuAddNodeBrother.Enabled = false;
            MenuAddNodeChild.Enabled = false;
            MenuAddBrotherModel.Enabled = false;
            MenuAddChildModel.Enabled = false;
            t1_Del.Enabled = false;
            if (treeView1.Nodes.Count == 0)  //树上没有任何节点
            {
                MenuAddRoot.Enabled = true;
            }
            else //树上有节点
            {
                t1_ExpandAll.Enabled = true;
                t1_CollapseAll.Enabled = true;
                t1_Find.Enabled = true;
                t1_Prev.Enabled = true;
                t1_Next.Enabled = true;
                TreeNode node = treeView1.SelectedNode;  //选中的节点
                if (node != null)  //如果有选中的节点
                {
                    t1_Del.Enabled = true;
                    MenuAddNodeChild.Enabled = true;
                    if (node.Level != 0) //不是根节点
                    {
                        MenuAddNodeBrother.Enabled = true;
                        MenuAddNodeChild.Enabled = true;
                    }
                }
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CheckEnable();
        }
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            Point mousePoint = treeView1.PointToClient(new Point(e.X, e.Y));
            TreeNode theNode = treeView1.GetNodeAt(mousePoint);
            if (theNode != null)
            {
                if (string.Compare(theNode.Tag.ToString(), "kongbai", true) == 0)
                {
                    treeView1.SelectedNode = theNode;
                    treeView1.Focus();
                }
            }
        }
    }
}
