using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ERM.Common;
namespace ERM.UI
{
    public partial class frmRegistSearch : ERM.UI.Controls.Skin_DevEX
    {
        TreeView tree;
        ArrayList SearchList = new ArrayList();
        public ITreeFactory treeFactory;
        FileStatus treeEnum = FileStatus.Full;
        frmFileMain ParentForm;
        private string LastKey = "";
        private DataRow[] dr = null;
        private int SearchIndex = 4;
        public frmRegistSearch(TreeView t, FileStatus r, frmFileMain _parentForm, ITreeFactory Itree)
        {
           
            InitializeComponent();
            this.txtSearchTitle._TextBox.TextChanged += txtSearchTitle_TextChanged;
            tree = t;
            treeEnum = r;
            ParentForm = _parentForm;
            treeFactory = Itree;
        }
        private void SetIcon(TreeNodeCollection Nodes)
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i].ImageIndex == 2 || Nodes[i].ImageIndex == 4 || Nodes[i].ImageIndex == 5)
                {
                    treeFactory.SetNodeIcon((TreeNodeEx)(Nodes[i]));
                }
                if (Nodes[i].Nodes.Count > 0)
                {
                    SetIcon(Nodes[i].Nodes);
                }
            }
        }
        private void btnSearchConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (LastKey != txtSearchTitle.Text || dr == null || dr.Length == 0)
                {
                    LastKey = txtSearchTitle.Text;
                    SearchIndex = 0;
                    DataSet ds = treeFactory.GetDS(Globals.ProjectNO, txtSearchTitle.Text);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dr = ds.Tables[0].Select();//("title like '%" + txtSearchTitle.Text + "%'", "length,orderindex");
                    }
                    else
                    {
                        MyCommon.Show("未找到任何符合关键字的记录！");
                        return;
                    }
                }
                if (SearchIndex >= dr.Length)
                {
                    SearchIndex = 0;
                }
                if (dr != null && dr.Length > 0)
                {
                    DataRow dr1 = dr[SearchIndex++];
                    string obj = "";
                    obj = dr1["id"].ToString();
                    TreeNodeCollection pNodes = tree.Nodes;
                    for (int i1 = 2; i1 <= obj.Length; i1 += 2)
                    {
                        string nodeID = obj.Substring(0, i1);
                        pNodes = SearchAndExpendNode(pNodes, nodeID);
                    }
                    tree.SelectedNode.Name = obj;
                }
            }
            catch (Exception)
            {
                TX.Framework.WindowUI.Forms.TXMessageBoxExtensions.Info("未找到任何符合关键字的记录！");
            }
        }
        private TreeNodeCollection SearchAndExpendNode(TreeNodeCollection pNodes, string nodeID)
        {
            if (pNodes == null)
                return null;
            TreeNode[] nodes = pNodes.Find(nodeID, true);
            if (nodes != null && nodes.Length > 0)
            {
                if (nodes[0].Nodes != null && nodes[0].Nodes.Count > 0)
                {
                    nodes[0].Expand();
                }
                tree.SelectedNode = nodes[0];
                nodes[0].EnsureVisible();
            }
            if (nodes.Length > 0 && nodes[0].Nodes.Count > 0)
            {
                return nodes[0].Nodes;
            }
            else
            {
                return null;
            }
        }

        private void txtSearchTitle_Load(object sender, EventArgs e)
        {

        }

        private void btnSearchConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void txtSearchTitle_TextChanged(object sender, EventArgs e)
        {
            this.btnSearchConfirm.Enabled = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
