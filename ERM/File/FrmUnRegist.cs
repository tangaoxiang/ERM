using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI
{
    public partial class FrmUnRegist : ERM.UI.Controls.Skin_DevEX
    {
        TreeNode _TNode;
        frmFileMain _frmFileMain;
        string _TreeNodeState_flg;
        public TreeFactory treeFactory;
        public FrmUnRegist(TreeNode TNode, frmFileMain frmFileMain, string TreeNodeState_flg, TreeFactory treeFactoryTmp)
        {
            InitializeComponent();
            _TNode = TNode;
            _frmFileMain = frmFileMain;
            _TreeNodeState_flg = TreeNodeState_flg;
            treeFactory = treeFactoryTmp;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            bool is_Check = false;
            foreach (TreeNode c_node in tv_Info.Nodes[0].Nodes)
            {
                if (c_node.Checked)
                {
                    is_Check = true;
                    break;
                }
            }
            if (!is_Check || tv_Info.Nodes[0].Nodes.Count == 0)
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件！");
                return;
            }

            foreach (TreeNode NewNode in tv_Info.Nodes[0].Nodes)
            {
                if (NewNode.Checked)
                {
                    MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(NewNode.Name, Globals.ProjectNO);
                    if (fileMDL != null && fileMDL.isvisible == 1)
                    {
                        fileMDL.ArchiveID = "";
                        fileMDL.fileStatus = "3";
                        NewNode.ImageIndex = (treeFactory.CheckEFileByFileID(NewNode.Name, 2) == true) ? 7 : 2;//判断是否有电子文件
                        NewNode.SelectedImageIndex = NewNode.ImageIndex;
                        (new BLL.T_FileList_BLL()).Update(fileMDL);
                    }
                }
            }
            TXMessageBoxExtensions.Info("提示：成功撤消文件！");
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tv_Info_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckControl(e);
        }
        /// <summary>
        /// 系列节点 Checked 属性控制
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
        /// 改变父节点的选中状态，此处为所有子节点不选中时才取消父节点选中，可以根据需要修改
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

        private void FrmUnRegist_Shown(object sender, EventArgs e)
        {
            TreeNode nodeGD = new TreeNode();
            nodeGD.Text = _TNode.Text;
            nodeGD.Tag = _TNode.Name;
            nodeGD.SelectedImageIndex = 1;
            nodeGD.ImageIndex = 1;
            nodeGD.Name = _TNode.Name;

            (new TreeFactory()).InitGDTree(Globals.ProjectNO, _TreeNodeState_flg, nodeGD,
                                true, 2, true);

            tv_Info.Nodes.Add(nodeGD);
            tv_Info.ExpandAll();
        }

        private void btn_OK_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {

        }
    }
}
