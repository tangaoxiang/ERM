using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    public partial class frmReName : ERM.UI.Controls.Skin_DevEX
    {
        TreeNodeEx NewNode = null;
        //string OldTitle = null;
        //string oldNum = null;
        public frmReName(TreeNodeEx node)
        {
            if (node != null)
            {
                InitializeComponent();
                NewNode = node;
                //OldTitle = node.Text;
                if (node.ImageIndex == 3)
                {
                    txtReName.Text = node.Text;
                    //txtReName.Text = node.Text.Substring(node.Text.LastIndexOf("]") + 1);
                    //oldNum = node.Text.Substring(0, node.Text.LastIndexOf("]") + 1);
                }
                else
                {
                    //获取文件信息
                    MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(node.Name, Globals.ProjectNO);
                    txtReName.Text = fileMDL1.wjtm;
                    //txtReName.Text = node.Text;
                    //oldNum = "";
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save(this.txtReName.Text);
        }
        /// <summary>
        /// 保存
        /// </summary>
        public void Save(string text)
        {
            //CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();



            if (!String.IsNullOrEmpty(text))
            {
                if (!MyCommon.IsMatchCode(text))
                {
                    TXMessageBoxExtensions.Info("包含非法字符,不能保存！");
                    return;
                }
                //for (int i = 0; i < NewNode.Parent.Nodes.Count; i++)
                //{
                //    string newtext = NewNode.Parent.Nodes[i].Text.Trim().Substring(NewNode.Parent.Nodes[i].Text.Trim().LastIndexOf("]") + 1);
                //    if (text.Trim().Equals(newtext))
                //    {
                //        TXMessageBoxExtensions.Info("重命名失败,同一层级下节点名字不能重复！");
                //        return;
                //    }
                //}
                try
                {
                    if (NewNode.ImageIndex == 3)
                    {
                        BLL.T_CellAndEFile_BLL cellAndFile_bll = new BLL.T_CellAndEFile_BLL();
                        MDL.T_CellAndEFile cellMDL = cellAndFile_bll.Find(NewNode.Name, Globals.ProjectNO);
                        cellMDL.title = text;
                        cellAndFile_bll.Update(cellMDL);

                        //cbll.UpdateAttachmentTitle(OpeartPath((TreeNodeEx)(NewNode.Parent)), Globals.ProjectNO, OldTitle, text);
                    }
                    else
                    {
                        BLL.T_FileList_BLL fileList_bll = new BLL.T_FileList_BLL();
                        MDL.T_FileList fileMDL1 = fileList_bll.Find(NewNode.Name, Globals.ProjectNO);
                        fileMDL1.wjtm = text;
                        fileMDL1.gdwj = text;
                        fileList_bll.Update(fileMDL1);
                        //string OldPath = OpeartPath((TreeNodeEx)NewNode);
                        //string NewPath = OldPath.Substring(0, OldPath.LastIndexOf("\\") + 1) + text;
                        //cbll.UpdateFinal_fileTitle(NewPath, Globals.ProjectNO, OldPath);
                        //cbll.UpdateCell_TempletTitle(NewPath, Globals.ProjectNO, OldPath, text);
                        //cbll.UpdateAttachmentFilePath(NewPath, OldPath, Globals.ProjectNO);
                    }
                    NewNode.Text = text;
                    TXMessageBoxExtensions.Info("修改成功！");
                    this.Close();
                }
                catch
                {
                    TXMessageBoxExtensions.Info("重命名失败！");
                }
            }
            else
            {
                TXMessageBoxExtensions.Info("名称不能为空！");
                return;
            }
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
                    string treepath = node.Parent.FullPath + "\\" + node.Text.Substring(node.Text.LastIndexOf("]") + 1);
                    treepath = treepath.Replace("*", "");
                    return treepath;
                }
                if (node.ImageIndex == 3)
                {
                    string treepath = node.Parent.Parent.FullPath + "\\" + node.Parent.Text.Substring(node.Text.LastIndexOf("]") + 1) + "\\" + node.Text;
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
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {

        }
    }
}
