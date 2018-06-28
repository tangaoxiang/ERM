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
    public partial class frmDelInfo : ERM.UI.Controls.Skin_DevEX
    {
        int _Action_Flg;
        TreeNode _TNode;
        frmFileMain _frmFileMain;
        string _TreeNodeState_flg;
        public frmDelInfo(TreeNode TNode, int Action_Flg, frmFileMain frmFileMain, string TreeNodeState_flg)
        {
            InitializeComponent();
            _TNode = TNode;
            _Action_Flg = Action_Flg;
            _frmFileMain = frmFileMain;
            _TreeNodeState_flg = TreeNodeState_flg;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 私有方法
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
        /// <summary>
        /// 改变所有子节点的状态
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

        #endregion

        private void tv_Info_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckControl(e);
        }

        private void frmDelInfo_Shown(object sender, EventArgs e)
        {
            if (_Action_Flg == 1)
            {
                TreeNode nodeGD = new TreeNode();
                nodeGD.Text = _TNode.Text;
                nodeGD.Tag = _TNode.Name;
                nodeGD.SelectedImageIndex = 1;
                nodeGD.ImageIndex = 1;
                nodeGD.Name = _TNode.Name;

                (new TreeFactory()).InitGDTree(Globals.ProjectNO, _TreeNodeState_flg, nodeGD,
                                   true, 2, true);

                //BLL.T_FileList_BLL FileList_BLL = new BLL.T_FileList_BLL();
                ////归档类别
                //DataTable tbl_FileInfo = FileList_BLL.GetFileByGDID(Globals.ProjectNO, _TNode.Name);
                //if (tbl_FileInfo != null)
                //{
                //    foreach (DataRow f_row in tbl_FileInfo.Rows)
                //    {
                //        TreeNode File_Node = new TreeNode();
                //        File_Node.Text = f_row["wjtm"].ToString();
                //        File_Node.Tag = f_row["FileID"].ToString();
                //        File_Node.StateImageKey = f_row["filepath"].ToString();
                //        File_Node.Name = f_row["FileID"].ToString();

                //        int fileStatus = MyCommon.ToInt(f_row["fileStatus"]);
                //        if (fileStatus == 6)
                //            File_Node.SelectedImageIndex = 4;//组卷
                //        else
                //        {
                //            if (fileStatus == 4)//判断是否登记 
                //                File_Node.SelectedImageIndex = 5;
                //            else
                //            {
                //                if (isShowEFileCount)
                //                    tNode.SelectedImageIndex = (EfileCount_flg == true) ? 7 : 2;//判断是否有电子文件
                //                else
                //                {
                //                    DataRow[] ERows = dTable2.Select("FileID='" + tNode.Name + "' AND DoStatus='1'");
                //                    if (ERows != null && ERows.Length > 0)//判断是否有电子文件
                //                        tNode.SelectedImageIndex = 7;
                //                    else
                //                        tNode.SelectedImageIndex = 2;
                //                }
                //            }
                //        }


                //        if (f_row["fileStatus"] != null &&
                //            f_row["fileStatus"].ToString() == "6")
                //        {
                //            File_Node.SelectedImageIndex = 4;
                //            File_Node.ImageIndex = 4;
                //        }
                //        else
                //        {
                //            File_Node.SelectedImageIndex = 2;
                //            File_Node.ImageIndex = 2;
                //        }
                //        nodeGD.Nodes.Add(File_Node);
                //    }
                //}
                tv_Info.Nodes.Add(nodeGD);
                tv_Info.ExpandAll();
            }
            else if (_Action_Flg == 2)
            {
                //删除电子文件
                TreeNode nodeFile = new TreeNode();
                nodeFile.Text = _TNode.Text;
                nodeFile.Tag = _TNode.Name;
                nodeFile.SelectedImageIndex = 1;
                nodeFile.ImageIndex = 1;
                nodeFile.Name = _TNode.Name;

                BLL.T_CellAndEFile_BLL cellFile = new ERM.BLL.T_CellAndEFile_BLL();
                IList<MDL.T_CellAndEFile> cellList =
                    cellFile.FindByGdFileID(_TNode.Name, Globals.ProjectNO);
                foreach (MDL.T_CellAndEFile obj in cellList)
                {
                    TreeNodeEx cnode = new TreeNodeEx();
                    cnode.Text = obj.title;
                    cnode.Name = obj.CellID;
                    cnode.NodeValue = obj.filepath;
                    cnode.ImageIndex = 3;
                    cnode.SelectedImageIndex = 3;
                    nodeFile.Nodes.Add(cnode);
                }
                tv_Info.Nodes.Add(nodeFile);
                tv_Info.ExpandAll();
            }
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
            if (!is_Check)
            {
                TXMessageBoxExtensions.Info("请选择需要删除的记录！");
                return;
            }

            //if (_frmFileMain.axpdfInterface1.FileName != null && _frmFileMain.axpdfInterface1.FileName.Length > 0)
            //    _frmFileMain.axpdfInterface1.CloseFile();

            if (_Action_Flg == 1)
            {
                BLL.T_FileList_BLL FileList_BLL = new BLL.T_FileList_BLL();
                BLL.T_CellAndEFile_BLL CellAndEFile_BLL = new BLL.T_CellAndEFile_BLL();
                //归档类别
                DataTable tbl_FileInfo = FileList_BLL.GetFileByGDID(Globals.ProjectNO, _TNode.Name);

                foreach (TreeNode f_node in tv_Info.Nodes[0].Nodes)
                {
                    if (!f_node.Checked || f_node.ImageIndex == 4)
                        continue;
                    //归档类别
                    DataRow[] file_rows = tbl_FileInfo.Select("FileID='" + f_node.Name + "'");

                    if (file_rows != null && file_rows.Length > 0)
                    {
                        if (file_rows[0]["filepath"] != null && file_rows[0]["filepath"].ToString().Trim() != "")
                        {
                            if (System.IO.File.Exists(Globals.ProjectPath + file_rows[0]["filepath"].ToString()))
                            {
                                System.IO.File.Delete(Globals.ProjectPath + file_rows[0]["filepath"].ToString());
                            }
                        }
                        IList<MDL.T_CellAndEFile> cellList =
                            CellAndEFile_BLL.FindByGdFileID(f_node.Name, Globals.ProjectNO);

                        foreach (MDL.T_CellAndEFile cellMDL in cellList)
                        {
                            if (cellMDL != null &&
                                System.IO.File.Exists(Globals.ProjectPath + cellMDL.filepath)
                                && !string.IsNullOrWhiteSpace(cellMDL.filepath)
                                && cellMDL.filepath.EndsWith(".cll"))//原件
                            {
                                cellMDL.GdFileID = "";
                                CellAndEFile_BLL.Update(cellMDL);
                            }
                            else
                            {
                                if (System.IO.File.Exists(Globals.ProjectPath + cellMDL.filepath))
                                {
                                    System.IO.File.Delete(Globals.ProjectPath + cellMDL.filepath);
                                }
                                if (System.IO.File.Exists(Globals.ProjectPath + cellMDL.fileTreePath))
                                {
                                    System.IO.File.Delete(Globals.ProjectPath + cellMDL.fileTreePath);
                                }

                                MyCommon.DeleteOldEfile(cellMDL.CellID, Globals.ProjectNO);  //删除电子文件对应的原文信息
                                CellAndEFile_BLL.Delete(cellMDL.CellID, Globals.ProjectNO);
                            }
                        }
                        FileList_BLL.Delete(f_node.Name, Globals.ProjectNO);
                    }
                }
            }
            else if (_Action_Flg == 2)
            {
                //删除电子文件
                BLL.T_CellAndEFile_BLL CellAndEFile_BLL = new BLL.T_CellAndEFile_BLL();
                IList<MDL.T_CellAndEFile> cellList =
                    CellAndEFile_BLL.FindByGdFileID(tv_Info.Nodes[0].Name, Globals.ProjectNO);

                foreach (TreeNode c_node in tv_Info.Nodes[0].Nodes)
                {
                    if (c_node.Checked)
                    {
                        MDL.T_CellAndEFile cellMDL = CellAndEFile_BLL.Find(c_node.Name, Globals.ProjectNO);

                        if (cellMDL != null &&
                        System.IO.File.Exists(Globals.ProjectPath + cellMDL.filepath)
                        && !string.IsNullOrWhiteSpace(cellMDL.filepath)
                        && cellMDL.filepath.EndsWith(".cll"))//原件
                        {
                            cellMDL.GdFileID = "";
                            CellAndEFile_BLL.Update(cellMDL);
                        }
                        else
                        {
                            if (System.IO.File.Exists(Globals.ProjectPath + cellMDL.filepath))
                            {
                                System.IO.File.Delete(Globals.ProjectPath + cellMDL.filepath);
                            }
                            if (System.IO.File.Exists(Globals.ProjectPath + cellMDL.fileTreePath))
                            {
                                System.IO.File.Delete(Globals.ProjectPath + cellMDL.fileTreePath);
                            }

                            MyCommon.DeleteOldEfile(cellMDL.CellID, Globals.ProjectNO);  //删除电子文件对应的原文信息
                            CellAndEFile_BLL.Delete(cellMDL.CellID, Globals.ProjectNO);
                        }
                    }
                }
            }
            TXMessageBoxExtensions.Info("删除成功！");
            this.DialogResult = DialogResult.OK;
        }

        private void btn_OK_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {

        }

    }
}
