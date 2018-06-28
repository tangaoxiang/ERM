using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.CBLL;

namespace Digi.B
{
    public partial class frmNewCellEdit : Form
    {
        #region ��ʼ��

        Form parentForm;
        //��������
        private TreeFactory treeFactory = new TreeFactory();

        TreesData td = new TreesData();

        int TreeOrList = 0;

        public frmNewCellEdit(Form f)
        {
            InitializeComponent();

            treeView1.ImageList = treeFactory.CreateTreeImageList();

            treeView1.HideSelection = false;

            LoadList();
            parentForm = f;
            //��ʼ���ļ��Ǽ���
            this.Cursor = Cursors.WaitCursor;
            treeFactory.GetFileTree(this.treeView1, true, Globals.OpenedProjectNo,  true);
            CheckEnable();
            this.Cursor = Cursors.Default;
        }

        #endregion

        #region �����ļ���

        /// <summary>
        /// �����ڵ�ķ��� 
        /// </summary>
        /// <param name="Level">��Ϊ0,ͬ��Ϊ1,�Ӽ�Ϊ2</param>
        private void NewNode(int Level)
        {
            TreeNode Node = treeView1.SelectedNode;
            if (Node == null && Level!=0)
                return;
            if (Node != null)
            {
                if (Node.Tag.ToString() != "kongbai")
                {
                    Functions.ShowWarning("�ڵ�Ϊ�鵵�ļ��������ڸýڵ��������Զ���Ŀ¼��");
                    return;
                }
                if (Level == 2)
                {
                    if (Node.Nodes.Count > 0)
                    {
                        if (CheckCanDragDrop(Node))
                        {
                            Functions.ShowWarning("�鵵�ļ�ֻ������ĩ�����������ӣ�");
                            return;
                        }
                    }
                }
                else if (Level == 1)
                {
                    if (Node.Parent == null) return;
                    if (CheckCanDragDrop(Node.Parent))
                    {
                        Functions.ShowWarning("�鵵�ļ�ֻ������ĩ����,�������ӣ�");
                        return;
                    }
                }
            }

            frmSetNodeName frm = new frmSetNodeName(Node, "ͬ���ڵ�", this.treeView1);
            DialogResult drs =  frm.ShowDialog();
            if (drs == DialogResult.OK)
            {
                if (!CheckSameTitle(Level, Node, frm.GetNodeText))
                {
                    Functions.ShowWarning("ͬһ�ڵ��²���ͬ��!");
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                string id = Level == 0 ? "01" : Level==1 ? td.GetNewFileRecording_Templet_NextID(Node.Parent.Name):td.GetNewFileRecording_Templet_NextID(Node.Name);
                string title = Functions.ToSqlString( frm.GetNodeText);
                string ptreepath = Level == 0 ? "" : Level == 1 ?Functions.ToSqlString( Node.Parent.FullPath) :Functions.ToSqlString( Node.FullPath);
                string treepath = Level==0?title :Functions.ToSqlString(ptreepath) + "\\" + title;
                string table_name = "kongbai";
                td.InsertNewFileRecording_Templet(ptreepath, treepath, table_name, title, id);
                if (Level == 0 || Node.Level==0 )
                    treeFactory.GetFileTree(this.treeView1, true, Globals.OpenedProjectNo,  true);
                else
                    treeFactory.RefreshFileNode(Level == 1 ? Node.Parent : Node, true, Globals.OpenedProjectNo, true);
                treeFactory.SelectNode1(this.treeView1, id);
                treeView1.Focus();
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ����ͬ��Ŀ¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAddNodeBrother_Click(object sender, EventArgs e)
        {
            //TreeNode Node = this.treeView1.SelectedNode;

            //if (Node != null && Node.Parent != null)
            //{
            //    frmSetNodeName frm = new frmSetNodeName(Node,"ͬ��Ŀ¼",this.treeView1);

            //    frm.Show();
            //}
            NewNode(1);
        }

       /// <summary>
       /// ������Ŀ¼
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void MenuAddNodeChild_Click(object sender, EventArgs e)
        {
            //TreeNode Node = this.treeView1.SelectedNode;

            //if (Node != null)
            //{
            //    frmSetNodeName frm = new frmSetNodeName(Node,"��Ŀ¼",this.treeView1);

            //    frm.Show();
            //}
            NewNode(2);
        }

        /// <summary>
        /// ѡ�����ŵ��ļ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAddBrotherModel_Click(object sender, EventArgs e)
        {
            frmSelectTemplate frm = new frmSelectTemplate();

            frm.Show();
        }

        /// <summary>
        /// �����Ӹ�Ŀ¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAddRoot_Click(object sender, EventArgs e)
        {
            //frmSetNodeName frm = new frmSetNodeName(null, "��Ŀ¼", this.treeView1);

            //frm.Show();
            NewNode(0);
        }

        #endregion

        #region treeview�Ϸ��¼�

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
                //�����������ȷ��Ҫ�ƶ�����Ŀ��ڵ�
                Point pt;
                TreeNode targeNode;
                pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
                targeNode = (TreeNode)this.treeView1.GetNodeAt(pt);
                if (string.Compare(targeNode.Tag.ToString(), "kongbai", true) != 0)
                {
                    //Functions.ShowWarning("�鵵�ļ��²������ӹ鵵�ļ�");
                    return;
                }
                if (!CheckCanDragDrop(targeNode))
                {
                    Functions.ShowWarning("�鵵�ļ�ֻ����������ĩ����");
                    return;
                }
                if (targeNode.Name.Length >2)
                {
                    ListViewItem NewItem = (ListViewItem)e.Data.GetData("System.Windows.Forms.ListViewItem");

                    ListView.SelectedListViewItemCollection ListItems = listView1.SelectedItems;

                   int flag = td.GetNewFileRecording_TempletID(targeNode.Name);

                   if (ListItems.Count + flag > 99)
                   {
                       if(Functions.ShowQuestion("�ýڵ��°���������ļ�,Ҫ����������?")!= DialogResult.Yes)
                       return;
                   }
                   this.Cursor = Cursors.WaitCursor;
                    foreach (ListViewItem item in ListItems)
                    {
                        if (flag > 99)
                        {
                            Functions.ShowWarning("ID������Χ");
                            this.Cursor = Cursors.Default;
                            break;
                        }
                        TreeNode NewNode = new TreeNode();

                        NewNode.Text = item.Text;

                        NewNode.Tag = item.Name;

                        NewNode.ImageIndex = 1;

                        NewNode.SelectedImageIndex = 1;

                        NewNode.Name = targeNode.Name + flag.ToString("D2");
                        targeNode.Nodes.Add(NewNode);

                        td.InsertNewFileRecording_Templet(Functions.ToSqlString(NewNode.Parent.FullPath),Functions.ToSqlString( NewNode.FullPath),NewNode.Tag.ToString(), item.Text, targeNode.Name + flag.ToString("D2"));

                        flag++;

                    }
                    LoadList();
                    targeNode.Expand();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        #endregion
        private bool CheckCanDragDrop(TreeNode tn )
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
            if (level == 0) return true;//��Ŀ¼
            if (level == 1)//����Ǹ�Ŀ¼��ͬ��Ŀ¼  ���ᷢ��
            {
                if (tn.Level == 0) return false;
            }
            TreeNode tmp = level == 1 ? tn.Parent : tn;//ͬ��Ŀ¼��ѡ��,��Ŀ¼���ǵ�ǰ
            foreach (TreeNode node in tn.Nodes)
            {
                if (node.Text == title)
                    return false;
            }
            return true;
        }

        #region ���¼�

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeOrList = 1;
                    //�Ҽ�����ڵ��ֱ�ӽ���ѡ��
            // �������ʹ�����ǰ�������Ҽ�...
            if (e.Button == MouseButtons.Right) {
                // ȡ����걻���µ�λ�á�
                Point p = new Point(e.X, e.Y);

                // ȡ�ñ�ʹ����������Ҽ����µĽڵ㡣
                TreeNode theNode = treeView1.GetNodeAt(p);

                // �����걻����֮���Ƿ������һ���ڵ㡣
                if (theNode != null) {
                    // ѡȡ��ʹ����������Ҽ����µĽڵ㡣
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
            this.Cursor = Cursors.WaitCursor;

            //��ȡ���еĽڵ�
            TreeNodeEx NewNode = (TreeNodeEx)(e.Node) ;

            if (NewNode.Parent != null)
            {
                //����ڵ����
                if (NewNode.IsFirstExpand)
                {
                    RefreshNode((TreeNodeEx)NewNode);
                }
            }

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region �������¼�

        /// <summary>
        /// ȫ��չ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_ExpandAll_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            treeView1.BeginUpdate();
            //if (null != this.treeView1.SelectedNode)
            //{
            //    treeView1.SelectedNode.ExpandAll();
            //}
            //else if(treeView1.Nodes[0]!=null)
            //{
            //    treeView1.Nodes[0].ExpandAll();
            //}
            treeView1.ExpandAll();
            if (treeView1.Nodes[0] != null)
            {
                treeView1.Nodes[0].EnsureVisible();
                treeView1.SelectedNode = treeView1.Nodes[0];
            }
                treeView1.EndUpdate();
            this.Cursor = Cursors.Default;
            
        }

        /// <summary>
        /// ȫ���۵�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_CollapseAll_Click(object sender, EventArgs e)
        {
            //if (null != this.treeView1.SelectedNode)
            //{
            //    this.treeView1.SelectedNode.Collapse();
            //}
            //else
            //{
                treeView1.CollapseAll();
                if (treeView1.Nodes[0] != null)
                {
                    treeView1.Nodes[0].EnsureVisible();
                    treeView1.SelectedNode = treeView1.Nodes[0];
                }
            //}
        }

        /// <summary>
        /// ��һ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_Prev_Click(object sender, EventArgs e)
        {
            treeFactory.SelectPrevNode(treeView1);
        }

        /// <summary>
        /// ��һ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_Next_Click(object sender, EventArgs e)
        {
            treeFactory.SelectNextNode(treeView1);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_Del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("�Ƿ�ɾ��<" + this.treeView1.SelectedNode.Text + ">�ڵ㼰���ӽڵ���Ϣ", "�ڵ�ɾ������", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.DelNode(this.treeView1.SelectedNode);
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region ��������

        /// <summary>
        /// ˢ�½ڵ�
        /// </summary>
        /// <param name="node"></param>
        private void RefreshNode(TreeNodeEx NewNode)
        {
            //����ڵ��ǵ�һ��չ��
            if (NewNode.IsFirstExpand)
            {
                //�������Ĳ���ģ��Ҳ���ǵ����ļ�
                if (NewNode.ImageIndex == 1)
                {
                    //ˢ�½ڵ�
                    treeFactory.RefreshFileNode(NewNode, true, Globals.OpenedProjectNo,  true);
                }
            }

        }

        /// <summary>
        /// ɾ���ڵ�
        /// </summary>
        /// <param name="node"></param>
        private void DelNode(TreeNode node)
        {
            //DigiPower.ERM.CBLL.FileRegist cbll = new FileRegist();

            ////ˢ�½ڵ�
            //treeFactory.RefreshFileNode((TreeNodeEx)node, true, Globals.OpenedProjectNo, true, true, RegistEnum.FULL);

            //List<string> list = new List<string>();

            //list.Add(node.FullPath);

            //list = GetTreepath(node, list);

            //string strPath = "111";

            //strPath = SetList2SqlIn(list);

            //cbll.DeleteNewFileRecording_TempletCountByTreepath(strPath);

            td.DeleteNewFileRecording_Templet(node.Name);
            if (string.Compare("01", node.Name) != 0)
                //��ʼ���ļ��Ǽ���
                treeFactory.RefreshFileNode(node.Parent, true, Globals.OpenedProjectNo, true);
            else
                treeView1.Nodes.Clear();
            CheckEnable();
            LoadList();

            
        }

        /// <summary>
        /// ��ȡ·������
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<string> GetTreepath(TreeNode NewNode,List<string> list)
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
        /// ����ʼ��listview
        /// </summary>
        private void LoadList()
        {
            DataSet ds = td.GetTableName(Globals.OpenedProjectNo);

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

        #endregion

        private void frmNewCellEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
        }

        /// <summary>
        /// ��ť���˵��ܷ������ж�
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

            //tsmiNewRoot.Enabled = false;
            //tsmiNewBrotherNode.Enabled = false;
            //tsmiNewChildNode.Enabled = false;
            //tsmiAddBrotherModel.Enabled = false;
            //tsmiAddChildModel.Enabled = false;
            //tsmiDelNode.Enabled = false;


            if (treeView1.Nodes.Count == 0)  //����û���κνڵ�
            {
                MenuAddRoot.Enabled = true;
                //tsmiNewRoot.Enabled = true;
            }
            else //�����нڵ�
            {
                t1_ExpandAll.Enabled = true;
                t1_CollapseAll.Enabled = true;
                t1_Find.Enabled = true;
                t1_Prev.Enabled = true;
                t1_Next.Enabled = true;



                //tsmiNewBrotherNode.Enabled = true;
                //tsmiNewChildNode.Enabled = true;
                //tsmiAddBrotherModel.Enabled = true;
                //tsmiAddChildModel.Enabled = true;

                TreeNode node = treeView1.SelectedNode;  //ѡ�еĽڵ�
                if (node != null)  //�����ѡ�еĽڵ�
                {
                    t1_Del.Enabled = true;
                    //tsmiDelNode.Enabled = true;
                    MenuAddNodeChild.Enabled = true;
                    if (node.Level != 0) //���Ǹ��ڵ�
                    {
                        MenuAddNodeBrother.Enabled = true;
                        //tsmiNewBrotherNode.Enabled = true;
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