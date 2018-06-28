using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using BCL.easyPDF6.Interop.EasyPDFPrinter.Digipower;
using BCL.easyPDF6.Interop.EasyPDFProcessor.Digipower;
using ERM.MDL;
using ERM.CBLL;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using CAPICOM;
using System.Collections;
using System.Xml;
namespace ERM.UI
{
    public partial class frmFileMain : Form
    {
        frmMainSearch searchFrm;
        string MovedCellPath = Globals.ODOCPath + "\\";
        string PDFPath = Globals.SPDFPath + "\\";
        string MregeredPDFPath = Globals.MPDFPath + "\\";
        string projectPath = Globals.ProjectPath + "\\";
        string PDFTemp = Globals.PDFTemp + "\\";
        //string DWGXML = Globals.DWGXML + "\\";
        //string DWGFont = Globals.DWGFont + "\\";
        string ReportPath = Application.StartupPath + "\\Reports\\regist.pdf";
        ImageList imagelist = new ImageList();
        int TreeOrList = 0;
        FileStatus treeEnum = FileStatus.Full;
        private Form _parentForm;
        public TreeFactory treeFactory = new TreeFactory();
        bool IsSource = false;
        bool IsCancel = false;
        bool IsFirst = true;
        Form parentForm = null;
        TreeNodeEx SNode = null;
        View DefaultListView = View.SmallIcon;
        public bool SignPassword = false;
        TreeNode LastNode = null;
        public frmFileMain(Form parentForm)
        {
            InitializeComponent();
            CreateObjDic();
            //treeFactory.GetTree(treeRight, true, Globals.ProjectNO, 0, true);
            treeFactory.GetTree(treeRight, Globals.ProjectNO, "", true, true, 2, true);
            this._parentForm = parentForm;
            splitContainer3.Panel2Collapsed = true;
            treeRight.ImageList = treeFactory.CreateTreeImageList();
            treeRight.Width = Convert.ToInt32(Globals.TreeWidth);
            treeRight.HideSelection = false;
            this.Text = Globals.AppTitle + " - " + Globals.ProjectNO;  //窗体标题
            parentForm = this.parentForm;
            axPDFReader1.ShowMenus = 0;
            axPDFReader1.ShowSigns = 0;
            axPDFReader1.ShowMarks = 0;
            axPDFReader1.ShowState = 1;
            axPDFReader1.ShowTitle = 0;
            axPDFReader1.Zoom = -2;
            tbtnShowFileList_Click(null, null);
        }
        /// <summary>
        /// 关闭发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFileAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (searchFrm != null)
            {
                try
                {
                    searchFrm.Close();
                }
                catch { }
            }
            this._parentForm.Show();　//显示父窗体
            this._parentForm.Activate();//激活父窗体
            //启用快速著录是保存选择的节点信息
            treeRight_BeforeSelect(null, null);
        }
        private void frmFileAdd_Load(object sender, EventArgs e)
        {
            this.Text = "文件登记 - " + Globals.Projectname;
        }
        /// <summary>
        /// 添加本地文件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAdd_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 提交　签名签章
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCheck_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 反审操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsunCheck_Click(object sender, EventArgs e)
        {
            ////反审的前提是没有组卷的文件
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelete_Click(object sender, EventArgs e)
        {
            TreeNodeEx theNode = (TreeNodeEx)treeRight.SelectedNode;
            if (theNode == null)
                return;

            if (theNode.ImageIndex == 2 || theNode.ImageIndex == 3 || theNode.ImageIndex == 5 || theNode.ImageIndex == 4 || theNode.ImageIndex == 7)
            {
                //判断文件状态 已经组卷的文件不允许修改
                string fileID = string.Empty;
                if (theNode.ImageIndex == 2 || theNode.ImageIndex == 5 || theNode.ImageIndex == 4 || theNode.ImageIndex == 7)
                    fileID = theNode.Name;
                else
                    fileID = theNode.Parent.Name;
                MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fileID, Globals.ProjectNO);
                if (fileMDL1.fileStatus == "6")
                {
                    MyCommon.ShowWarning("已经组卷的文件不允许修改！");
                    return;
                }
            }


            if (MessageBox.Show("你真的要移除文件" + this.treeRight.SelectedNode.Text.Substring(this.treeRight.SelectedNode.Text.LastIndexOf("]") + 1) + "吗？", SystemTips.MSG_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (theNode.ImageIndex == 2 || theNode.ImageIndex == 5 || theNode.ImageIndex == 7)
                {//删除文件
                    DeleteTemplet();
                }
                else if (theNode.ImageIndex == 3)
                {//移除电子文件                    
                    if (axPDFReader1.isOpen == 1)
                    {
                        axPDFReader1.WebClose();
                    }
                    MDL.T_CellAndEFile cellMDL = (new BLL.T_CellAndEFile_BLL()).Find(theNode.Name, Globals.ProjectNO);
                    if (System.IO.File.Exists(Globals.ProjectPath + cellMDL.filepath))
                    {
                        System.IO.File.Delete(Globals.ProjectPath + cellMDL.filepath);
                    }
                    if (System.IO.File.Exists(Globals.ProjectPath + cellMDL.fileTreePath))
                    {
                        System.IO.File.Delete(Globals.ProjectPath + cellMDL.fileTreePath);
                    }

                    (new BLL.T_CellAndEFile_BLL()).Delete(theNode.Name, Globals.ProjectNO);

                    BLL.T_FileList_BLL fileList_bll = (new BLL.T_FileList_BLL());
                    MDL.T_FileList fileList_mdl = fileList_bll.Find(cellMDL.FileID, Globals.ProjectNO);
                    fileList_mdl.selected = 1;
                    fileList_bll.Update(fileList_mdl);

                    UpdatePDFView((TreeNodeEx)theNode.Parent);
                    //this.fileBaseInfo.ShowData(theNode.Parent);

                    //统计电子文件数
                    TreeNodeEx theNodeParentNode = (TreeNodeEx)theNode.Parent;
                    treeFactory.GetCellFileNodesCount(theNodeParentNode, true);

                    if (theNode.Parent.ImageIndex == 2 || theNode.Parent.ImageIndex == 7)
                        theNode.Parent.ImageIndex = (treeFactory.CheckEFileByFileID(theNode.Parent.Name) == true) ? 7 : 2;//判断是否有电子文件
                }

                if (treeRight.SelectedNode.Parent != null)
                {
                    treeRight.SelectedNode.Parent.Nodes.Remove(theNode);
                }
            }
            else
            {
                return;
            }
        }

        private void UpdatePDFView(TreeNodeEx theNode)
        {
            string PDFFile = Globals.ProjectPath + ConvertFile2PDF(theNode.Name);
            if (System.IO.File.Exists(PDFFile))
            {
                if (axPDFReader1.isOpen == 1)
                {
                    axPDFReader1.WebClose();
                }
                axPDFReader1.WebOpenLocalFile(PDFFile);
            }
            else
            {
                try
                {
                    axPDFReader1.WebClose();
                }
                catch { }
            }
        }
        /// <summary>
        /// 添加模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAddTemplate_Click(object sender, EventArgs e)
        {
            AddTemplet();
        }
        /// <summary>
        /// 删除模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDeleteTemplate_Click(object sender, EventArgs e)
        {
            tsDelete_Click(null, null);
        }
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void treeRight_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void AddEFile(TreeNodeEx targeNode)
        {
            if (targeNode == null)
            {
                MyCommon.Show("请选中左侧的文件！");
                return;
            }
            ListView.SelectedListViewItemCollection ListItems = listView1.SelectedItems;
            try
            {
                frm2PDFProgressMsg dlg = new frm2PDFProgressMsg();
                dlg.label2.Text = "";
                if (ListItems.Count > 0)
                {
                    dlg.label2.Text = "/" + ListItems.Count.ToString();
                    dlg.progressBar1.Maximum = ListItems.Count;
                    dlg.Show();
                    Application.DoEvents();
                }

                targeNode.Text = targeNode.Text.Replace("导入完成 ", "");
                string strNameBK = targeNode.Text;
                targeNode.Text += "导入中(0/" + ListItems.Count + ") " + strNameBK;
                ArrayList list = new ArrayList();
                int i1 = 0;
                foreach (ListViewItem item in ListItems)
                {
                    i1++;
                    if (dlg.label2.Text != "")
                    {
                        dlg.label2.Text = i1.ToString() + "/" + ListItems.Count.ToString();
                        dlg.progressBar1.Value = i1;
                        Application.DoEvents();
                    }
                    targeNode.Text = "导入中(" + i1 + "/" + ListItems.Count + ") " + strNameBK;
                    UploadEFile(item.Name, targeNode);
                }
                //targeNode.Text = "导入完成 " + strNameBK;

                treeFactory.GetCellFileNodesCount(targeNode, true);

                if (dlg.label2.Text != "")
                {
                    dlg.Close();
                }
            }
            catch (Exception ex)
            {
                MyCommon.Show(ex.ToString());
            }
        }
        private void treeRight_DragDrop(object sender, DragEventArgs e)
        {
            Point pt;
            TreeNodeEx targeNode;
            pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
            targeNode = (TreeNodeEx)treeRight.GetNodeAt(pt);

            if (targeNode.ImageIndex == 2 || targeNode.ImageIndex == 5 || targeNode.ImageIndex == 4 || targeNode.ImageIndex == 7)
            {
                //判断文件状态 已经组卷的文件不允许修改
                MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(targeNode.Name, Globals.ProjectNO);
                if (fileMDL1.fileStatus == "6")
                {
                    MyCommon.ShowWarning("已经组卷的文件不允许修改！");
                    return;
                }
            }

            if (this.TreeOrList == 1)
            {
                if (targeNode.ImageIndex == 2 || targeNode.ImageIndex == 5 || targeNode.ImageIndex == 7)
                {
                    AddEFile(targeNode);

                    if (targeNode.ImageIndex == 2 || targeNode.ImageIndex == 7)
                        targeNode.ImageIndex = (treeFactory.CheckEFileByFileID(targeNode.Name) == true) ? 7 : 2;//判断是否有电子文件

                    string PDFFile = Globals.ProjectPath + ConvertFile2PDF(targeNode.Name);
                    if (System.IO.File.Exists(PDFFile))
                    {
                        if (axPDFReader1.isOpen == 1)
                        {
                            axPDFReader1.WebClose();
                        }
                        axPDFReader1.WebOpenLocalFile(PDFFile);
                    }
                    else
                    {
                        try
                        {
                            axPDFReader1.WebClose();
                        }
                        catch { }
                    }
                    this.fileBaseInfo.ShowData(targeNode);
                }
                else
                {
                    MyCommon.Show("你只能把文件移到文件中！");
                }
            }
            else//右边树内部拖动
            {
                TreeNodeEx fromNode = (TreeNodeEx)treeRight.SelectedNode;// (TreeNodeEx)e.Data.GetData("ERM.Common.TreeNodeEx");
                if (fromNode == null)
                    return;
                if (targeNode.ImageIndex != 1 || targeNode.ImageIndex != 2)
                {
                    MyCommon.Show("提示：只能把文件移到文件夹中！");
                    return;
                }

                if (fromNode.ImageIndex == 2 || fromNode.ImageIndex == 5 || fromNode.ImageIndex == 4 || fromNode.ImageIndex == 7)//文件拖动
                {
                    if (targeNode.ImageIndex == 1)
                    {
                        MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fromNode.Name, Globals.ProjectNO);
                        MDL.T_FileList fileMDL2 = (new BLL.T_FileList_BLL()).Find(targeNode.Name, Globals.ProjectNO);
                        fileMDL1.ParentID = fileMDL2.FileID;
                        fileMDL1.OrderIndex = 1;
                        (new BLL.T_FileList_BLL()).Update(fileMDL1);

                        fromNode.Remove();
                        targeNode.Nodes.Insert(0, (TreeNode)fromNode);

                        UpdateNodeLevel((TreeNode)(fromNode.Parent));
                        UpdateNodeLevel((TreeNode)(targeNode));
                    }
                    else
                    {
                        /*
                         * 先将自己替换为原来的Index 然后再将目的以后的目录（index+1）
                         */
                        MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fromNode.Name, Globals.ProjectNO);
                        MDL.T_FileList fileMDL2 = (new BLL.T_FileList_BLL()).Find(targeNode.Name, Globals.ProjectNO);
                        fileMDL1.ParentID = fileMDL2.ParentID;
                        fileMDL1.OrderIndex = fileMDL2.OrderIndex;
                        (new BLL.T_FileList_BLL()).Update(fileMDL1);

                        fromNode.Remove();
                        targeNode.Parent.Nodes.Insert(targeNode.Index, (TreeNode)fromNode);

                        UpdateNodeLevel((TreeNode)(fromNode.Parent));
                        UpdateNodeLevel((TreeNode)(targeNode.Parent));
                    }
                }
                //else//文件夹拖动
                //{
                //    if (targeNode.ImageIndex == 1)//文件夹
                //    {
                //        MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fromNode.Name, Globals.ProjectNO);
                //        MDL.T_FileList fileMDL2 = (new BLL.T_FileList_BLL()).Find(targeNode.Name, Globals.ProjectNO);
                //        fileMDL1.ParentID = fileMDL2.FileID;
                //        fileMDL1.OrderIndex = 1;
                //        (new BLL.T_FileList_BLL()).Update(fileMDL1);

                //        fromNode.Remove();
                //        targeNode.Nodes.Insert(0, (TreeNode)fromNode);

                //        UpdateNodeLevel((TreeNode)(fromNode.Parent));
                //        UpdateNodeLevel((TreeNode)(targeNode));
                //    }
                //    else//文件
                //    {
                //        MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fromNode.Name, Globals.ProjectNO);
                //        MDL.T_FileList fileMDL2 = (new BLL.T_FileList_BLL()).Find(targeNode.Name, Globals.ProjectNO);
                //        fileMDL1.ParentID = fileMDL2.ParentID;
                //        fileMDL1.OrderIndex = fileMDL2.OrderIndex;
                //        (new BLL.T_FileList_BLL()).Update(fileMDL1);

                //        fromNode.Remove();
                //        targeNode.Parent.Nodes.Insert(targeNode.Index, (TreeNode)fromNode);

                //        UpdateNodeLevel((TreeNode)(fromNode.Parent));
                //        UpdateNodeLevel((TreeNode)(targeNode.Parent));
                //    }
                //}
            }
        }
        private void treeRight_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeRight_AfterSelect(object sender, TreeViewEventArgs e)
        {
            axPDFReader1.DisplayMode = 3;

            ExpendNode(e.Node);
            TreeNode DestinationNode = ((TreeView)sender).SelectedNode;
            if (DestinationNode == null || DestinationNode.Name == String.Empty)
                return;
            TreeNodeEx theNode = (TreeNodeEx)DestinationNode;
            if (theNode.Name == String.Empty)
                return;
            fileBaseInfo.Enabled = false;

            if (theNode.ImageIndex == 2 || theNode.ImageIndex == 5 || theNode.ImageIndex == 4 || theNode.ImageIndex == 7)
            {
                MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(theNode.Name, Globals.ProjectNO);
                if (fileMDL == null)
                    return;
                if (fileMDL.isvisible == 0)
                {
                    fileBaseInfo.Enabled = false;
                    return;
                }
                else
                {
                    if (fileMDL.fileStatus == "6")
                        fileBaseInfo.Enabled = false;
                    else
                        fileBaseInfo.Enabled = true;
                    Globals.ZRR = fileBaseInfo.zrr.Text;
                    this.fileBaseInfo.ShowData(theNode);
                    if (fileBaseInfo.btnbEnableQuickInput.Checked == true)
                    {
                        if (fileBaseInfo.zrr.Text == "")
                        {
                            fileBaseInfo.zrr.Text = Globals.ZRR;
                        }
                    }
                }
                this.Enabled = false;
                UpdatePDFView(theNode);
                this.Enabled = true;

                if (theNode.Nodes.Count <= 0)
                {
                    BLL.T_CellAndEFile_BLL cellFile = new ERM.BLL.T_CellAndEFile_BLL();
                    IList<MDL.T_CellAndEFile> cellList = cellFile.FindByFileIDAndNOCell(theNode.Name, Globals.ProjectNO);
                    foreach (MDL.T_CellAndEFile obj in cellList)
                    {
                        TreeNodeEx cnode = new TreeNodeEx();
                        cnode.Text = obj.title;
                        cnode.Name = obj.CellID;
                        cnode.NodeValue = obj.filepath;
                        cnode.ImageIndex = 3;
                        cnode.SelectedImageIndex = 3;
                        theNode.Nodes.Add(cnode);
                    }
                    theNode.ExpandAll();
                }
            }
            if (theNode.ImageIndex == 3)
            {
                tabControl1.SelectedTab = tabControl1.TabPages["tablEfileShow"];
                string pdfPath = ConvertCell2PDF(theNode.Name);
                string PDFFile = Globals.ProjectPath + pdfPath;
                if (System.IO.File.Exists(PDFFile))
                {
                    axPDFReader1.WebOpenLocalFile(PDFFile);
                }
                else
                {
                    axPDFReader1.WebClose();
                }
            }
        }
        private string ConvertCell2PDF(string CellID)
        {
            string PDFFileName = "";
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            MDL.T_CellAndEFile cellMDL = cellBLL.Find(CellID, Globals.ProjectNO);
            if (cellMDL != null)
            {
                if (cellMDL.DocYs == null || cellMDL.DocYs == 1 || cellMDL.fileTreePath == String.Empty)
                {
                    if (axPDFReader1.isOpen == 1)
                    {
                        axPDFReader1.WebClose();
                    }
                    ConvertCell2PDF c1 = new ConvertCell2PDF();
                    try
                    {
                        int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath, Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".daf");
                        cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".daf";
                        cellMDL.DocYs = 0;
                        cellMDL.ys = iPageCount;
                        cellBLL.Update(cellMDL);

                        MDL.T_FileList fileMDL = (new ERM.BLL.T_FileList_BLL()).Find(cellMDL.FileID, Globals.ProjectNO);
                        fileMDL.selected = 1;//有新内容,有日期型数据有错。
                        (new ERM.BLL.T_FileList_BLL()).Update(fileMDL);
                    }
                    catch (Exception e)
                    {
                        MyCommon.ShowInfo(e.Message);
                        return ConvertCell2PDF(CellID);//重新调用一次
                    }
                    PDFFileName = cellMDL.fileTreePath;
                }
                else
                {
                    PDFFileName = cellMDL.fileTreePath;
                }
            }
            return PDFFileName;
        }
        private string ConvertFile2PDF(string FileID)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            MDL.T_FileList fileMDL = fileBLL.Find(FileID, Globals.ProjectNO);
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByFileIDAndNOCell(FileID, Globals.ProjectNO);

            //string[] FileList = new string[cellList.Count];

            System.Collections.ArrayList fileArryList = new ArrayList();

            frm2PDFProgressMsg dfmsg = null;
            if (fileMDL.selected == 1 && cellList != null && cellList.Count > 0)
            {
                dfmsg = new frm2PDFProgressMsg();
                dfmsg.progressBar1.Maximum = cellList.Count;
                dfmsg.label2.Text = "正在转换 0/" + cellList.Count;
                dfmsg.Show();
            }
            //int i1 = 0;
            int curIndex = 1;
            foreach (MDL.T_CellAndEFile cellMDL in cellList)
            {
                if (fileMDL.selected == 1)
                {
                    if (dfmsg.label2.Text != "")
                    {
                        dfmsg.label2.Text = "正在转换 " + curIndex + "/" + cellList.Count;
                        dfmsg.progressBar1.Value = curIndex;
                        Application.DoEvents();
                    }
                }
                curIndex++;
                string pdfPath = ConvertCell2PDF(cellMDL.CellID);

                if (!System.IO.File.Exists(Globals.ProjectPath + pdfPath))
                {
                    continue;
                }
                fileArryList.Add(Globals.ProjectPath + pdfPath);
                //FileList[i1++] = Globals.ProjectPath + pdfPath;
            }

            if (fileMDL.selected == 1 && dfmsg != null)
            {
                dfmsg.Dispose();
                dfmsg.Close();
            }

            string[] FileList = new string[fileArryList.Count];
            for (int i = 0; i < fileArryList.Count; i++)
            {
                FileList[i] = fileArryList[i].ToString();
            }
            fileMDL = fileBLL.Find(FileID, Globals.ProjectNO);
            if (fileMDL.selected == 1)
            {
                axPDFReader1.WebClose();
                ConvertCell2PDF c1 = new ConvertCell2PDF();
                fileMDL = fileBLL.Find(FileID, Globals.ProjectNO);
                int iPageCount = 0;
                if (FileList.Length > 0)
                {
                    iPageCount = c1.MergePDF(FileList, Globals.ProjectPath + "MPDF\\" + FileID + ".daf");
                    fileMDL.filepath = "MPDF\\" + FileID + ".daf";
                }
                else
                {
                    fileMDL.filepath = "";
                }
                fileMDL.sl = iPageCount;
                fileMDL.selected = 0;
                fileBLL.Update(fileMDL);
            }
            return fileMDL.filepath;
        }
        private void tsAddRight_Click(object sender, EventArgs e)
        {
            tsAdd_Click(null, null);
        }
        private void tsRemoveRight_Click(object sender, EventArgs e)
        {
            tsDelete_Click(null, null);
        }
        ////提交
        ////反提交
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsOutput_Click(object sender, EventArgs e)
        {
            TreeNodeEx theNode = (TreeNodeEx)treeRight.SelectedNode;
            if (theNode == null) return;
            ERM.UI.frmExpData Frm = new ERM.UI.frmExpData(theNode);
            if (Frm.ShowDialog() == DialogResult.OK)
            {
                //if (Frm.dtErr.Rows.Count > 0)
                //{
                //    frmOutInError frm = new frmOutInError(this, Frm.dtErr, false);
                //    frm.Owner = this;
                //    frm.Show();
                //    frm.Focus();
                //}
                //else
                MyCommon.ShowInfo("导出数据成功！");
            }
        }
        /// <summary>
        /// 关闭资源管理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            splitContainer3.Panel2Collapsed = true;
        }
        /// <summary>
        /// 显示目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHideArchive_Click(object sender, EventArgs e)
        {
            if (sp1.Panel1Collapsed)
            {
                sp1.Panel1Collapsed = false;
                //btnHideArchive.Text = "隐藏目录";
            }
            else
            {
                sp1.Panel1Collapsed = true;
                //btnHideArchive.Text = "显示目录";
            }
        }
        /// <summary>
        /// 隐藏目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            sp1.Panel1Collapsed = true;
        }
        /// <summary>
        /// 显示资源管理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmsiExplorer_Click(object sender, EventArgs e)
        {
            splitContainer3.Panel2Collapsed = false;
            if (!IsSource)
            {
                ShowResources();
            }
        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsInput_Click(object sender, EventArgs e)
        {
            frmImpData frm = new frmImpData("REGIST", this.treeRight, this, treeFactory);
            frm.ShowDialog();
        }
        /// <summary>
        /// 显示资源管理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsResoure_Click(object sender, EventArgs e)
        {
            splitContainer3.Panel2Collapsed = false;
            if (!IsSource)
            {
                ShowResources();
            }
        }
        /// <summary>
        /// 撤消登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsUnRegist_Click(object sender, EventArgs e)
        {
            TreeNodeEx NewNode = (TreeNodeEx)(this.treeRight.SelectedNode);
            if (NewNode != null)
            {
                if (NewNode.ImageIndex == 2 || NewNode.ImageIndex == 3 || NewNode.ImageIndex == 5 || NewNode.ImageIndex == 4 || NewNode.ImageIndex == 7)
                {
                    //判断文件状态 已经组卷的文件不允许修改
                    string fileID = string.Empty;
                    if (NewNode.ImageIndex == 2 || NewNode.ImageIndex == 5 || NewNode.ImageIndex == 4 || NewNode.ImageIndex == 7)
                        fileID = NewNode.Name;
                    else
                        fileID = NewNode.Parent.Name;
                    MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fileID, Globals.ProjectNO);
                    if (fileMDL1.fileStatus == "6")
                    {
                        DialogResult check_result =
                            MyCommon.ShowQuestion("确定将已经组卷的文件撤销登记吗？  \r\n\n【温馨提示：撤销登记后，文件自动从组卷中移除】");
                        if (check_result == DialogResult.No)
                            return;
                    }
                    else if (fileMDL1.fileStatus == "0")
                    {
                        return;
                    }
                }

                MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(NewNode.Name, Globals.ProjectNO);
                if (fileMDL != null && fileMDL.isvisible == 1)
                {
                    fileMDL.ArchiveID = "";
                    fileMDL.fileStatus = "3";
                    NewNode.ImageIndex = (treeFactory.CheckEFileByFileID(NewNode.Name) == true) ? 7 : 2;//判断是否有电子文件
                    (new BLL.T_FileList_BLL()).Update(fileMDL);
                    fileBaseInfo.Enabled = true;
                    MyCommon.Show("提示：成功撤消文件！");
                }
                else
                {
                    MyCommon.Show("提示：请选择需要撤消的文件！");
                }
            }
            ////先判断工程资料用表表中是否有该记录
        }
        /// <summary>
        /// 扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScan_Click(object sender, EventArgs e)
        {
            if (this.treeRight.SelectedNode.ImageIndex == 2 || this.treeRight.SelectedNode.ImageIndex == 5 || this.treeRight.SelectedNode.ImageIndex == 7)
            {
            }
            else
            {
                MyCommon.Show("只有未进行合并的文件才能添加扫描文件！");
            }
        }
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!fileBaseInfo.Enabled)
            {
                return;
            }
            if (!String.IsNullOrEmpty(this.fileBaseInfo.dptCreateDate2.Text))
            {
                if (!this.fileBaseInfo.dptCreateDate2.Text.Equals(this.fileBaseInfo.dptCreateDate.Text) && (this.fileBaseInfo.dptCreateDate2.Value < this.fileBaseInfo.dptCreateDate.Value))
                {
                    MyCommon.Show("形成结束时间必须大于形成开始时间！");
                    return;
                }
            }
            if (this.treeRight.SelectedNode != null)
            {
                {
                    try
                    {
                        this.SaveEx((TreeNodeEx)(this.treeRight.SelectedNode));
                        this.treeRight.SelectedNode.ImageIndex = 5;
                        treeRight.SelectedNode.SelectedImageIndex = treeRight.SelectedNode.ImageIndex;
                        IsFirst = false;
                        Globals.ZRR = this.fileBaseInfo.zrr.Text;
                        this.fileBaseInfo.flag1 = true;
                        this.fileBaseInfo.flag2 = true;
                    }
                    catch
                    {
                        MyCommon.Show("保存失败！");
                    }
                }
                if (this.treeRight.SelectedNode.ImageIndex == 4)
                {
                    MyCommon.Show("合并后的文件登记不允许更新,请先拆分！");
                }
                if (this.treeRight.SelectedNode.ImageIndex == 1)
                {
                    MyCommon.Show("只有已登记的模版才能保存！");
                }
            }
        }
        /// <summary>
        /// 显示未登记文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnRegistFile_Click(object sender, EventArgs e)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            DataSet ds = fileBLL.GetNoInputFile(Globals.ProjectNO);
            DataView dv = ds.Tables[0].DefaultView;
            frmPrint frm = new frmPrint(Application.StartupPath + @"\Reports\unarchived.cll", dv, "UnArchived", null);
            frm.ShowDialog();
        }
        private void btnClosed_Click(object sender, EventArgs e)
        {
            TemplateClear();
            this.Close();
        }
        private void TemplateClear()
        {
            this.axPDFReader1.WebClose();
            if (Directory.Exists(PDFTemp))
            {
                string[] FileNames = Directory.GetFiles(PDFTemp);
                for (int i = 0; i < FileNames.Length; i++)
                {
                    if (System.IO.File.Exists(FileNames[i]))
                    {
                        System.IO.File.Delete(FileNames[i]);
                    }
                }
            }
        }
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsReName_Click(object sender, EventArgs e)
        {
            ReName();
        }
        /// <summary>
        /// 添加DWG字库文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnAddDWG_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string userName = Environment.UserName;
        //        FolderBrowserDialog FolderBrowserDialog1 = new FolderBrowserDialog();
        //        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
        //        if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
        //        {
        //            string path = FolderBrowserDialog1.SelectedPath;
        //            string pathname = FolderBrowserDialog1.SelectedPath.Substring(FolderBrowserDialog1.SelectedPath.LastIndexOf("\\") + 1);
        //            //if (!System.IO.Directory.Exists(DWGFont + pathname))
        //            //{
        //            //    System.IO.Directory.CreateDirectory(DWGFont + pathname);
        //            //}
        //            string[] FileNames = Directory.GetFiles(path);
        //            string NewFileName = null;
        //            foreach (string str in FileNames)
        //            {
        //                NewFileName = str.Substring(str.LastIndexOf("\\") + 1);
        //                System.IO.File.Copy(str, DWGFont + pathname + "\\" + NewFileName, true);
        //            }
        //        }
        //        MyCommon.Show("DWG字库文件导入成功!!");
        //    }
        //    catch
        //    {
        //        MyCommon.Show("DWG字库文件导入失败!!");
        //    }
        //}
        /// <summary>
        /// 判断文本是否有改变
        /// </summary>
        /// <param name="NewNode"></param>
        /// <returns></returns>
        private bool IsTextChanged(TreeNodeEx NewNode)
        {
            FileRegist cbll = new FileRegist();
            DataSet ds = new DataSet();
            bool result = false;
            if (NewNode.ImageIndex == 2 | NewNode.ImageIndex == 4 | NewNode.ImageIndex == 5 | NewNode.ImageIndex == 7)
            {
                BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                MDL.T_FileList fileMDL = new T_FileList();
                fileMDL.FileID = NewNode.Name;
                ds = fileBLL.GetList(fileMDL);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (!this.fileBaseInfo.wjtm.Text.Equals(ds.Tables[0].Rows[0]["wjtm"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.zrr.Text.Equals(ds.Tables[0].Rows[0]["zrr"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.wh.Text.Equals(ds.Tables[0].Rows[0]["wh"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.bgqx.Text.Equals(ds.Tables[0].Rows[0]["bgqx"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.mj.Text.Equals(ds.Tables[0].Rows[0]["mj"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.ztlx.Text.Equals(ds.Tables[0].Rows[0]["ztlx"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.sl.Text.Equals(ds.Tables[0].Rows[0]["sl"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.gg.Text.Equals(ds.Tables[0].Rows[0]["gg"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.gb.Text.Equals(ds.Tables[0].Rows[0]["wjgbdm"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.wjlx.Text.Equals(ds.Tables[0].Rows[0]["wjlxdm"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.psdd.Text.Equals(ds.Tables[0].Rows[0]["psdd"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.psz.Text.Equals(ds.Tables[0].Rows[0]["psz"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.fbl.Text.Equals(ds.Tables[0].Rows[0]["fbl"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.xjpp.Text.Equals(ds.Tables[0].Rows[0]["xjpp"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.xjxh.Text.Equals(ds.Tables[0].Rows[0]["xjxh"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.dw.Text.Equals(ds.Tables[0].Rows[0]["dw"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.wh.Text.Equals(ds.Tables[0].Rows[0]["wh"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.sb.Text.Equals(ds.Tables[0].Rows[0]["sb"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.fz.Text.Equals(ds.Tables[0].Rows[0]["bz"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.wjmc.Text.Equals(ds.Tables[0].Rows[0]["wjmc"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.FileID.Text.Equals(ds.Tables[0].Rows[0]["FileID"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.wjbsm.Text.Equals(ds.Tables[0].Rows[0]["wjbsm"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.wzz.Text.Equals(ds.Tables[0].Rows[0]["wzz"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.tzz.Text.Equals(ds.Tables[0].Rows[0]["tzz"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.dtz.Text.Equals(ds.Tables[0].Rows[0]["dtz"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.zpz.Text.Equals(ds.Tables[0].Rows[0]["zpz"].ToString()))
                    {
                        return true;
                    }
                    if (!this.fileBaseInfo.dpz.Text.Equals(ds.Tables[0].Rows[0]["dpz"].ToString()))
                    {
                        return true;
                    }
                    if (this.fileBaseInfo.flag1)
                    {
                        if (!this.fileBaseInfo.dptCreateDate.Value.ToString().Equals(ds.Tables[0].Rows[0]["CreateDate"].ToString()) && ds.Tables[0].Rows[0]["CreateDate"].ToString().Substring(1) != "001-01-01 0:00:00")
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (!this.fileBaseInfo.dptCreateDate.Value.ToString().Equals(ds.Tables[0].Rows[0]["CreateDate"].ToString()))
                        {
                            return true;
                        }
                    }
                    if (this.fileBaseInfo.flag2)
                    {
                        if (!this.fileBaseInfo.dptCreateDate2.Value.ToString().Equals(ds.Tables[0].Rows[0]["CreateDate2"].ToString()) && ds.Tables[0].Rows[0]["CreateDate2"].ToString().Substring(1) != "001-01-01 0:00:00")
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (!this.fileBaseInfo.dptCreateDate2.Value.ToString().Equals(ds.Tables[0].Rows[0]["CreateDate2"].ToString()))
                        {
                            return true;
                        }
                    }
                    if (!this.fileBaseInfo.dptpssj.Value.ToString().Equals(ds.Tables[0].Rows[0]["pssj"].ToString()))
                    {
                        return true;
                    }
                }
                return false;
            }
            return false; ;
        }
        /// <summary>
        /// 添加外部文件
        /// </summary>
        /// <param name="openFileDialog1"></param>
        public void UploadEFile(string uploadFile, TreeNodeEx fileNode)
        {
            FileInfo uploadFileInfo = new FileInfo(uploadFile);
            string FileType = uploadFileInfo.Extension;
            if (uploadFileInfo.Length > (1024 * 25 * 1024))
            {
                MyCommon.Show("外部文件不能大于25M！");
                return;
            }
            try
            {
                string eFileID = Guid.NewGuid().ToString();
                System.IO.File.Copy(uploadFile, MovedCellPath + eFileID + FileType, true);
                ERM.MDL.T_CellAndEFile model = new ERM.MDL.T_CellAndEFile();
                model.CellID = eFileID;
                model.ProjectNO = Globals.ProjectNO;
                model.filepath = "ODOC\\" + eFileID + FileType;
                model.FileID = fileNode.Name;
                model.title = uploadFileInfo.Name.Replace(FileType, "");
<<<<<<< .mine
                //if (FileType.ToUpper().Equals(".CLL"))
                //{
                if (axPDFReader1.isOpen == 1)
=======
                //if (FileType.ToUpper().Equals(".CLL"))
>>>>>>> .r253
                {
                    axPDFReader1.WebClose();
                }
<<<<<<< .mine
                ConvertCell2PDF convertCell2PDF = new ConvertCell2PDF();
                //int iPageCount = convertCell2PDF.PrintCellToPDF(uploadFile, model.FileID);
                //model.fileTreePath = model.CellID + ".daf";
=======
                //else
                //{
                //    Convert2PDF convert2PDF = new Convert2PDF();
                //    int iPageCount = 0;
                //    if (FileType.ToUpper().Equals(".PDF") || FileType.ToUpper().Equals(".DAF"))
                //    {
                //        System.IO.File.Copy(uploadFile, Globals.ProjectPath + "PDF\\" + model.CellID + ".daf", true);
                //        iPageCount = convert2PDF.GetPDFPageCount(Globals.ProjectPath + "PDF\\" + model.CellID + ".daf");
                //    }
                //    else
                //    {
                //        iPageCount = convert2PDF.Print2PDF(uploadFile, Globals.ProjectPath + "PDF\\" + model.CellID + ".daf");
                //    }
>>>>>>> .r253

<<<<<<< .mine
                int iPageCount = convertCell2PDF.PrintCellToPDF(uploadFile, Globals.ProjectPath + "PDF\\" + model.CellID + ".daf");
                model.fileTreePath = "PDF\\" + model.CellID + ".daf";
                model.ys = iPageCount;
                model.DocYs = 0;//Leo 已打过包的，下次不用打
                //}
                //else
                //{
                //    Convert2PDF convert2PDF = new Convert2PDF();
                //    int iPageCount = 0;
                //    if (FileType.ToUpper().Equals(".PDF") || FileType.ToUpper().Equals(".DAF"))
                //    {
                //        System.IO.File.Copy(uploadFile, Globals.ProjectPath + "PDF\\" + model.CellID + ".daf", true);
                //        iPageCount = convert2PDF.GetPDFPageCount(Globals.ProjectPath + "PDF\\" + model.CellID + ".daf");
                //    }
                //    else
                //    {
                //        iPageCount = convert2PDF.Print2PDF(uploadFile, Globals.ProjectPath + "PDF\\" + model.CellID + ".daf");
                //    }

                //    model.fileTreePath = "PDF\\" + model.CellID + ".daf";
                //    model.ys = iPageCount;
                //    model.DocYs = 0;//Leo 已打过包的，下次不用打
                //}
=======
                //    model.fileTreePath = "PDF\\" + model.CellID + ".daf";
                //    model.ys = iPageCount;
                //    model.DocYs = 0;//Leo 已打过包的，下次不用打
                //}
>>>>>>> .r253
                model.orderindex = (new BLL.T_CellAndEFile_BLL()).GetMaxOrderIndex(fileNode.Name, Globals.ProjectNO) + 1;
                (new BLL.T_CellAndEFile_BLL()).Add(model);
                MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(model.FileID, Globals.ProjectNO);
                fileMDL.selected = 1;
                (new BLL.T_FileList_BLL()).Update(fileMDL);
                TreeNodeEx NewNode = new TreeNodeEx();
                NewNode.Name = model.CellID;
                NewNode.Text = model.title;
                NewNode.SelectedImageIndex = 3;
                NewNode.ImageIndex = 3;
                NewNode.NodeValue = model.CellID;
                fileNode.Nodes.Add(NewNode);
                return;
            }
            catch
            {
                return;
            }
        }
        private string outFile = "";
        private string tempFile = Application.StartupPath + "\\temp2\\";
        private int oPrinterMonitor_OnPrinterInit(int uID, PrintJobInfo JobInfo)
        {
            PDFSetting oPDFSetting = JobInfo.PDFSetting;
            oPDFSetting.UiAlerts = false;
            oPDFSetting.UiFileDialog = false;
            oPDFSetting.UiPropertiesDialog = false;
            JobInfo.OutputFileName = outFile;
            return (int)prnMonitorResponse.PRN_MON_CONTINUE_CONVERSION;
        }
        private int oPrinterMonitor_OnPrinterUpdate(int uID, PrintJobInfo JobInfo)
        {
            return (int)prnMonitorResponse.PRN_MON_CONTINUE_CONVERSION;
        }
        private int oPrinterMonitor_OnPrinterStart(int uID)
        {
            return (int)prnMonitorResponse.PRN_MON_CONTINUE_CONVERSION;
        }
        private int oPrinterMonitor_OnPageStart(int uID, int PageNumber)
        {
            return (int)prnMonitorResponse.PRN_MON_CONTINUE_CONVERSION;
        }
        private int oPrinterMonitor_OnPrinterEnd(int uID, int ErrCode)
        {
            return (int)prnMonitorResponse.PRN_MON_CONTINUE_CONVERSION;
        }
        /// <summary>
        /// 如果该模版无登记则先登记
        /// </summary>
        /// <param name="node"></param>
        /// <param name="cbll"></param>
        /// <param name="NewNode"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        private DataSet IfNoRegist(TreeNodeEx node, FileRegist cbll, TreeNodeEx NewNode, DataSet ds)
        {
            return ds;
        }
        /// <summary>
        /// 返回工程资料用表新加电子文件记录的ID
        /// </summary>
        /// <param name="cbll"></param>
        /// <param name="NewNode"></param>
        /// <returns></returns>
        private string GetNewArchiveDataID(FileRegist cbll, TreeNodeEx NewNode)
        {
            string ArID = cbll.GetArchiveDataFilepath(treeFactory.OpeartPath(NewNode), Globals.ProjectNO);
            if (!String.IsNullOrEmpty(ArID))
            {
                ArID = ArID.Substring(ArID.LastIndexOf("\\") + 1);
                ArID = ArID.Substring(0, ArID.LastIndexOf("."));
            }
            return ArID;
        }
        /// <summary>
        /// 设置外部引用的节点属性
        /// </summary>
        /// <param name="ExternalFileName"></param>
        /// <returns></returns>
        private TreeNodeEx SetExternalValue(string ExternalFileName)
        {
            TreeNodeEx NewNode = new TreeNodeEx();
            NewNode.NodeValue = ExternalFileName;
            NewNode.ImageIndex = 3;
            NewNode.SelectedImageIndex = 3;
            string path = ExternalFileName.Substring(ExternalFileName.LastIndexOf('\\') + 1);
            NewNode.Text = path.Substring(0, path.LastIndexOf("."));
            return NewNode;
        }
        /// <summary>
        /// 取父节点ID
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetPartentID(TreeNodeEx node)
        {
            string PartentID = null;
            if (node.PrevNode != null)
            {
                long Pid = Convert.ToInt64(node.PrevNode.Name) + 1;
                PartentID = "0" + Pid.ToString();
            }
            else
            {
                PartentID = node.Parent.Name + "01";
            }
            return PartentID;
        }
        /// <summary>
        /// 取节点在父节点中的顺序
        /// </summary>
        /// <param name="node"></param>
        /// <param name="NewNode"></param>
        /// <returns></returns>
        private int GetOrderIndex(TreeNodeEx node, TreeNodeEx NewNode)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                if (NewNode.Name.Equals(node.Nodes[i].Name))
                {
                    return i + 1;
                }
            }
            return 0;
        }
        /// <summary>
        /// 必须先调用这个方法，以后的合并才能成功
        /// </summary>
        ///// <summary>
        ///// 将指定文件打印成PDF
        ///// </summary>
        ///// <param name="FilePath"></param>
        ///// <param name="NewNode"></param>
        private void KillProcess()
        {
            try
            {
                System.Diagnostics.Process[] excelProc = System.Diagnostics.Process.GetProcessesByName("AcroRd32");
                System.DateTime startTime = new DateTime();
                int m, killId = 0;
                for (m = 0; m < excelProc.Length; m++)
                {
                    if (startTime < excelProc[m].StartTime)
                    {
                        startTime = excelProc[m].StartTime;
                        killId = m;
                    }
                }
                if (excelProc.Length > 0)
                {
                    if (excelProc[killId].HasExited == false)
                    {
                        excelProc[killId].Kill();
                    }
                }
            }
            catch
            {
                MyCommon.Show("文件转换失败！");
            }
        }
        /// <summary>
        /// 移除节点
        /// </summary>
        private void RemoveNode()
        {
            TreeNodeEx node = (TreeNodeEx)this.treeRight.SelectedNode;
            ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            if (node == null)
            {
                return;
            }
            else
            {
                string TreePath = treeFactory.OpeartPath(node);
                if (node.ImageIndex == 2 | node.ImageIndex == 4 | node.ImageIndex == 5 | node.ImageIndex == 7)
                {
                    try
                    {
                        string IsAddTem = cbll.GetCell_TempletCustomdefine(TreePath);
                        if (!String.IsNullOrEmpty(IsAddTem) && IsAddTem.Equals("1"))
                        {
                            try
                            {
                                for (int i = 0; i < node.Nodes.Count; i++)
                                {
                                    DeleteRecordingAtFileList((TreeNodeEx)(node.Nodes[i]), cbll, TreePath);
                                }
                                DeleteRecordingAtTemplet(node, cbll, TreePath);
                                node.Remove();
                                MyCommon.Show("删除自定义模版成功！");
                            }
                            catch
                            {
                                MyCommon.Show("删除自定义模版失败！");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MyCommon.Show(ex.ToString());
                    }
                }
                if (node.ImageIndex == 3)
                {
                    try
                    {
                        string Customdefine = cbll.GetAttachmentCustomdefine(treeFactory.OpeartPath((TreeNodeEx)(node.Parent)), node.Text, Globals.ProjectNO);
                        if (Customdefine.Equals("系统内部"))
                        {
                            MyCommon.Show("只能删除外部添加的电子文件！");
                        }
                        else
                        {
                            DeleteRecordingAtFileList(node, cbll, TreePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MyCommon.Show(ex.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// 电子文件级删除数据库操作
        /// </summary>
        /// <param name="node"></param>
        /// <param name="cbll"></param>
        /// <param name="TreePath"></param>
        private void DeleteRecordingAtFileList(TreeNodeEx node, ERM.CBLL.FileRegist cbll, string TreePath)
        {
            cbll.DeleteFileRecord(node.Text, treeFactory.OpeartPath((TreeNodeEx)node.Parent), Globals.ProjectNO);
            node.Parent.Text = treeFactory.GetFinal_fileCount((TreeNodeEx)(node.Parent)) + node.Parent.Text.Substring(node.Parent.Text.LastIndexOf("]") + 1);
            this.treeRight.Nodes.Remove(node);
        }
        /// <summary>
        /// 模版级删除数据库操作
        /// </summary>
        /// <param name="node"></param>
        /// <param name="cbll"></param>
        /// <param name="TreePath"></param>
        private void DeleteRecordingAtTemplet(TreeNodeEx node, ERM.CBLL.FileRegist cbll, string TreePath)
        {
            cbll.DeleteFinal_file(TreePath, Globals.ProjectNO);
            DeleteRegistFileList(node, cbll, TreePath);
            cbll.DeleteCell_TempletRecord(treeFactory.OpeartPath((TreeNodeEx)node), Globals.ProjectNO);
        }
        private void DeleteArchiveDataList(TreeNodeEx node, ERM.CBLL.FileRegist cbll)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                cbll.DeleteArchiveDataRecord(treeFactory.OpeartPath((TreeNodeEx)node.Nodes[i]), Globals.ProjectNO);
            }
        }
        /// <summary>
        /// 删除文件登记下的电子文件登记信息
        /// </summary>
        /// <param name="node">模版节点</param>
        /// <param name="cbll"></param>
        /// <param name="TreePath">模版全路径</param>
        private void DeleteRegistFileList(TreeNodeEx node, ERM.CBLL.FileRegist cbll, string TreePath)
        {
            if (node.Nodes.Count <= 0)
            {
                treeFactory.AddFileNode(node, Globals.ProjectNO);
            }
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                string PdfFileName = cbll.GetAttachmentPdfPath(node.Nodes[i].Text, TreePath, Globals.ProjectNO);
                cbll.DeleteFileRecord(node.Nodes[i].Text, TreePath, Globals.ProjectNO);
                DeleteFileAtAtt(PdfFileName);
            }
        }
        /// <summary>
        /// 电子文件级文件删除
        /// </summary>
        /// <param name="PdfFileName"></param>
        private void DeleteFileAtAtt(string PdfFileName)
        {
            if (System.IO.File.Exists(PDFPath + PdfFileName))
            {
                System.IO.File.Delete(PDFPath + PdfFileName);
            }
            string OldFileName = null;
            if (!String.IsNullOrEmpty(PdfFileName))
            {
                OldFileName = PdfFileName.Replace(".daf", ".cll");
            }
            if (System.IO.File.Exists(MovedCellPath + OldFileName))
            {
                System.IO.File.Delete(MovedCellPath + OldFileName);
            }
        }
        /// <summary>
        /// 复制操作
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="NewNode"></param>
        private void CopyFile(string Name, TreeNodeEx NewNode)
        {
            if (System.IO.File.Exists(projectPath + NewNode.NodeValue))
            {
                System.IO.File.Copy(projectPath + NewNode.NodeValue.Replace(".cll", ".daf"), PDFPath + Name + ".daf", true);
            }
            ////删除DAF文件
            if (System.IO.File.Exists(projectPath + NewNode.NodeValue))
            {
                System.IO.File.Copy(projectPath + NewNode.NodeValue, MovedCellPath + Name + ".cll", true);
            }
        }
        /// <summary>
        /// 取文件以GUID命名的文件名
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="NewNode"></param>
        /// <returns></returns>
        private string GetPDFNameAsGUID(string Name, TreeNodeEx NewNode)
        {
            ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            Name = NewNode.NodeKey;
            if (!String.IsNullOrEmpty(Name))
            {
                Name = NewNode.NodeKey.Substring(NewNode.NodeKey.LastIndexOf("\\") + 1);
                if (Name.Length > 36)
                {
                    Name = Name.Substring(0, Name.Length - 4);
                }
                if (Name.Length < 36)
                {
                    string FileName = null;
                    FileName = cbll.GetArchiveDataFilepath(treeFactory.OpeartPath(NewNode), Globals.ProjectNO);
                    if (String.IsNullOrEmpty(FileName))
                    {
                        FileName = cbll.GetAttachmentPdfPath(NewNode.Text, treeFactory.OpeartPath((TreeNodeEx)NewNode.Parent), Globals.ProjectNO);
                    }
                    if (!String.IsNullOrEmpty(FileName))
                    {
                        FileName = FileName.Substring(FileName.LastIndexOf("\\") + 1);
                        if (FileName.Length > 36)
                        {
                            FileName = FileName.Substring(0, FileName.Length - 4);
                        }
                    }
                    return FileName;
                }
            }
            return Name;
        }
        /// <summary>
        /// 批量提交
        /// </summary>
        /// <param name="Node"></param>
        private void VolumeCheck(TreeNodeEx Node)
        {
            TreeNode NewNode;
            TreeNodeEx NodeNode;
            ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            if (Node.ImageIndex == 2 | Node.ImageIndex == 4 | Node.ImageIndex == 5 | Node.ImageIndex == 7)
            {
                this.Check(Node, 1);
            }
            else
            {
                for (int i = 0; i < Node.Nodes.Count; i++)
                {
                    NewNode = Node.Nodes[i];
                    NodeNode = (TreeNodeEx)NewNode;
                    if (NodeNode.ImageIndex == 2 || NodeNode.ImageIndex == 5 | Node.ImageIndex == 7)
                    {
                        VolumeCheck(NodeNode);
                    }
                    if (NodeNode.ImageIndex == 1)
                    {
                        treeFactory.RefreshFileNode(NodeNode, true, Globals.ProjectNO, true, true, treeEnum, true);
                        treeFactory.SetNodeIcon(NodeNode);
                        VolumeCheck(NodeNode);
                    }
                }
            }
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="Node"></param>
        private bool Check(TreeNodeEx Node, int HowCheck)
        {
            ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            string FileStatus = cbll.GetRegistFileStatus(treeFactory.OpeartPath(Node), Globals.ProjectNO);
            if (!String.IsNullOrEmpty(FileStatus))
            {
                if (!FileStatus.Equals("4") && !FileStatus.Equals("5"))
                {
                    UpdateNodeLevel(Node);
                    DataSet ds = cbll.GetAttachment(treeFactory.OpeartPath(Node), Globals.ProjectNO);
                    string[] FileName = new string[ds.Tables[0].Rows.Count];
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        FileName = GetPDFFileName(ds, FileName);
                        if (FileName.Length > 0)
                        {
                            bool PathIsNull = FileNameIsNullOrEmpty(FileName);
                            string FileRegistID = cbll.FindFileRegistID(treeFactory.OpeartPath(Node), Globals.ProjectNO);
                            if (PathIsNull)
                            {
                                int nTzz = 0;
                                int nDtz = 0;
                                if (!String.IsNullOrEmpty(this.fileBaseInfo.tzz.GetText))
                                {
                                    nTzz = Convert.ToInt32(this.fileBaseInfo.tzz.GetText);
                                }
                                if (!String.IsNullOrEmpty(this.fileBaseInfo.dtz.GetText))
                                {
                                    nDtz = Convert.ToInt32(this.fileBaseInfo.dtz.GetText);
                                }
                                int TzResult = nTzz + nDtz;
                                int nZpz = 0;
                                int nDpz = 0;
                                if (!String.IsNullOrEmpty(this.fileBaseInfo.zpz.GetText))
                                {
                                    nZpz = Convert.ToInt32(this.fileBaseInfo.zpz.GetText);
                                }
                                if (!String.IsNullOrEmpty(this.fileBaseInfo.dpz.GetText))
                                {
                                    nDpz = Convert.ToInt32(this.fileBaseInfo.dpz.GetText);
                                }
                                int ZpResult = nZpz + nDpz;
                            }
                        }
                        if (Node.ImageIndex == 5)
                        {
                            Node.ImageIndex = 4;
                            Node.SelectedImageIndex = 4;
                        }
                        this.SetButtonStatus(Node);
                    }
                    else
                    {
                        if (HowCheck == 2)
                        {
                            MyCommon.Show("无电子文件的文件登记不能合并！");
                            return false;
                        }
                    }
                }
                else
                {
                    if (HowCheck == 2)
                    {
                        MyCommon.Show("已合并或已组卷的文件登记不能再次合并！");
                        return false;
                    }
                }
            }
            else
            {
                if (HowCheck == 2)
                {
                    MyCommon.Show("未登记的文件登记不能合并！");
                    return false;
                }
            }
            return true;
        }
        ///// <summary>
        ///// 合并pdf并更新文件登记表
        ///// </summary>
        ///// <param name="Node"></param>
        ///// <param name="cbll"></param>
        ///// <param name="FileName"></param>
        ///// <param name="FileRegistID"></param>
        /// <summary>
        /// 判断后缀名
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool CheckExt(string[] FileName)
        {
            bool ResultFlag = false;
            string[] ext = Globals.PrintType.Split(';');
            foreach (string FileExt in FileName)
            {
                foreach (string TypeExt in ext)
                {
                    if (FileExt.Substring(FileExt.LastIndexOf(".") + 1).ToUpper().Equals(TypeExt.ToUpper()))
                    {
                        ResultFlag = true;
                    }
                }
            }
            return ResultFlag;
        }
        /// <summary>
        /// 取文件登记下所有电子文件原文件大小总和
        /// </summary>
        /// <param name="FileRegistID"></param>
        /// <returns></returns>
        public string GetFileListLength(string FileRegistID)
        {
            ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            DataSet ds = cbll.GetAttachmentyswjpath(FileRegistID);
            long Count = 0;
            string Result = null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                FileInfo info = null;
                if (dr["yswjpath"].ToString().ToUpper().LastIndexOf(".DWG") > 0)
                {
                    info = new FileInfo(PDFPath + dr["filepath"].ToString());
                }
                else
                {
                    info = new FileInfo(MovedCellPath + dr["yswjpath"].ToString());
                }
                Count += info.Length;
            }
            Count = Count / 1024;
            Result = Count.ToString() + "KB";
            if (Count > 1024)
            {
                Count = Count / 1024;
                Result = Count.ToString() + "M";
            }
            if (Count > 1024)
            {
                Count = Count / 1024;
                Result = Count.ToString() + "G";
            }
            return Result;
        }
        /// <summary>
        /// 判断文件路径是否有空，有空则不合法
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private bool FileNameIsNullOrEmpty(string[] FileName)
        {
            bool PathIsNull = true;
            for (int i = 0; i < FileName.Length; i++)
            {
                if (String.IsNullOrEmpty(FileName[i]))
                {
                    PathIsNull = false;
                    break;
                }
            }
            return PathIsNull;
        }
        /// <summary>
        /// 取pdf的路径集合
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="FileName"></param>
        private string[] GetPDFFileName(DataSet ds, string[] FileName)
        {
            this.axPDFReader1.WebClose();
            MyCommon.DeleteAndCreateEmptyDirectory(PDFTemp);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string NewPath = PDFTemp + ds.Tables[0].Rows[i]["filepath"].ToString();
                NewPath = NewPath.Replace(".daf", ".pdf");
                if (System.IO.File.Exists(PDFPath + ds.Tables[0].Rows[i]["filepath"].ToString()))
                {
                    System.IO.File.Copy(PDFPath + ds.Tables[0].Rows[i]["filepath"].ToString(), NewPath);
                }
                FileName[i] = NewPath;
            }
            return FileName;
        }
        /// <summary>
        /// 批量反提交
        /// </summary>
        /// <param name="Node"></param>
        private void VolumeUnCheck(TreeNodeEx Node)
        {
            TreeNode NewNode;
            TreeNodeEx NodeNode;
            ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            if (Node.ImageIndex == 4)
            {
                this.UnCheck(Node, 1);
            }
            else
            {
                for (int i = 0; i < Node.Nodes.Count; i++)
                {
                    NewNode = Node.Nodes[i];
                    NodeNode = (TreeNodeEx)NewNode;
                    if (NodeNode.ImageIndex == 2 || NodeNode.ImageIndex == 5 || NodeNode.ImageIndex == 4 || NodeNode.ImageIndex == 7)
                    {
                        VolumeUnCheck(NodeNode);
                    }
                    if (NodeNode.ImageIndex == 1)
                    {
                        treeFactory.RefreshFileNode(NodeNode, true, Globals.ProjectNO, true, true, FileStatus.Full, true);
                        treeFactory.SetNodeIcon(NodeNode);
                        VolumeUnCheck(NodeNode);
                    }
                }
            }
        }
        /// <summary>
        /// 反审操作
        /// </summary>
        private void UnCheck(TreeNodeEx node, int HowCheck)
        {
            ERM.CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            MDL.T_FileList fileMDL = new T_FileList();
            fileMDL.FileID = node.Name;
            DataSet ds = fileBLL.GetList(fileMDL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    OperationAtUnCheck(cbll, node, ds, HowCheck);
                    this.SetButtonStatus(node);
                    this.fileBaseInfo.SetControls(true);
                }
                catch
                {
                    MyCommon.Show("拆分文件操作失败！");
                }
            }
        }
        /// <summary>
        /// 如果有文件登记信息则进行反审操作
        /// </summary>
        /// <param name="cbll"></param>
        /// <param name="node"></param>
        /// <param name="ds"></param>
        private void OperationAtUnCheck(ERM.CBLL.FileRegist cbll, TreeNodeEx node, DataSet ds, int HowCheck)
        {
            if (ds.Tables[0].Rows[0]["fileStatus"].ToString().Equals("5"))
            {
                if (HowCheck == 2)
                {
                    MyCommon.Show("已经组卷的文件不允许拆分！");
                }
                return;
            }
            if (ds.Tables[0].Rows[0]["fileStatus"].ToString().Equals("4"))
            {
                DeleteAtUnCheck(cbll, node, ds);
                node.ImageIndex = 5;
                node.SelectedImageIndex = 5;
                this.fileBaseInfo.sl.Text = "0";
                this.fileBaseInfo.wjdx.Text = "";
            }
            else
            {
                if (HowCheck == 2)
                {
                    MyCommon.Show("未合并的文件不允许拆分！");
                }
            }
        }
        /// <summary>
        /// 反提交时所做的删除操作
        /// </summary>
        /// <param name="cbll"></param>
        /// <param name="node"></param>
        /// <param name="ds"></param>
        private void DeleteAtUnCheck(ERM.CBLL.FileRegist cbll, TreeNodeEx node, DataSet ds)
        {
            cbll.UnCheckUpdateFileRegist(treeFactory.OpeartPath(node), Globals.ProjectNO);
            if (System.IO.File.Exists(MregeredPDFPath + ds.Tables[0].Rows[0]["filepath"].ToString()))
            {
                System.IO.File.Delete(MregeredPDFPath + ds.Tables[0].Rows[0]["filepath"].ToString());
            }
        }
        public string SaveEx(TreeNodeEx node)
        {
            FileRegistInfo frm = new FileRegistInfo();
            T_FileList model = (new BLL.T_FileList_BLL()).Find(node.Name, Globals.ProjectNO);
            if (model != null && model.FileID == node.Name)
            {
                model.TreePath = MyCommon.ToSqlString(treeFactory.OpeartPath(node));
                model.wjcj = MyCommon.ToSqlString(node.Level.ToString());
                model.wjbsm = MyCommon.ToSqlString(this.fileBaseInfo.wjbsm.Text);
                model.wjtm = MyCommon.ToSqlString(this.fileBaseInfo.wjtm.Text);
                if (this.fileBaseInfo.dptCreateDate.CustomFormat == "")
                {
                    model.CreateDate = this.fileBaseInfo.dptCreateDate.Value.ToString();
                }
                if (this.fileBaseInfo.dptCreateDate2.CustomFormat == "")
                {
                    model.CreateDate2 = this.fileBaseInfo.dptCreateDate2.Value.ToString();
                }
                model.ztlx = MyCommon.ToSqlString(this.fileBaseInfo.ztlx.Text.ToString());
                model.gg = MyCommon.ToSqlString(this.fileBaseInfo.gg.Text.ToString());
                model.bgqx = MyCommon.ToSqlString(this.fileBaseInfo.bgqx.Text.ToString());
                model.mj = MyCommon.ToSqlString(this.fileBaseInfo.mj.Text.ToString());
                model.wjgbdm = MyCommon.ToSqlString(this.fileBaseInfo.gb.Text.Trim());
                model.wjlxdm = MyCommon.ToSqlString(this.fileBaseInfo.wjlx.Text.ToString());
                model.wjgs = MyCommon.ToSqlString(this.fileBaseInfo.wjgs.Text.Trim());
                model.wjdx = MyCommon.ToSqlString(this.fileBaseInfo.wjdx.Text.Trim());
                model.psdd = MyCommon.ToSqlString(this.fileBaseInfo.psdd.Text.Trim());
                model.pssj = this.fileBaseInfo.dptpssj.Value.ToShortDateString();
                model.psz = MyCommon.ToSqlString(this.fileBaseInfo.psz.Text.Trim());
                model.fbl = MyCommon.ToSqlString(this.fileBaseInfo.fbl.Text.Trim());
                model.xjpp = MyCommon.ToSqlString(this.fileBaseInfo.xjpp.Text.Trim());
                model.xjxh = MyCommon.ToSqlString(this.fileBaseInfo.xjxh.Text.Trim());
                model.sb = MyCommon.ToSqlString(this.fileBaseInfo.sb.Text.Trim());
                model.wjgs = MyCommon.ToSqlString(this.fileBaseInfo.wjgs.Text);
                model.bz = MyCommon.ToSqlString(this.fileBaseInfo.fz.Text);
                model.zrr = MyCommon.ToSqlString(this.fileBaseInfo.zrr.Text);
                model.ProjectNO = MyCommon.ToSqlString(Globals.ProjectNO);
                model.wh = MyCommon.ToSqlString(this.fileBaseInfo.wh.Text);
                int nTzz = 0;
                int nDtz = 0;
                if (!String.IsNullOrEmpty(this.fileBaseInfo.tzz.Text))
                {
                    nTzz = Convert.ToInt32(this.fileBaseInfo.tzz.Text);
                }
                if (!String.IsNullOrEmpty(this.fileBaseInfo.dtz.Text))
                {
                    nDtz = Convert.ToInt32(this.fileBaseInfo.dtz.Text);
                }
                int TzResult = nTzz + nDtz;
                model.dw = TzResult.ToString();
                TreeNodeEx NodeNode = (TreeNodeEx)node.Parent;
                model.FileID = MyCommon.ToSqlString(this.fileBaseInfo.FileID.Text);
                model.wjmc = MyCommon.ToSqlString(this.fileBaseInfo.wjmc.Text);
                int nZpz = 0;
                int nDpz = 0;
                if (!String.IsNullOrEmpty(this.fileBaseInfo.zpz.Text))
                {
                    nZpz = Convert.ToInt32(this.fileBaseInfo.zpz.Text);
                }
                if (!String.IsNullOrEmpty(this.fileBaseInfo.dpz.Text))
                {
                    nDpz = Convert.ToInt32(this.fileBaseInfo.dpz.Text);
                }
                int ZpResult = nZpz + nDpz;
                model.wzz = ZpResult.ToString();
                model.tzz = this.fileBaseInfo.tzz.GetText;
                model.dtz = this.fileBaseInfo.dtz.GetText;
                model.zpz = this.fileBaseInfo.zpz.GetText;
                model.dpz = this.fileBaseInfo.dpz.GetText;
                model.fileStatus = "4";//Leo 有登记文件
                try
                {
                    BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                    fileBLL.Update(model);
                    return model.FileID;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 重命名
        /// </summary>
        private void ReName()
        {
            TreeNodeEx NewNode = (TreeNodeEx)(this.treeRight.SelectedNode);
            if (NewNode == null && NewNode.Level == 0)
                return;
            if (NewNode.ImageIndex == 2 || NewNode.ImageIndex == 3 || NewNode.ImageIndex == 5 || NewNode.ImageIndex == 4 || NewNode.ImageIndex == 7)
            {
                //判断文件状态 已经组卷的文件不允许修改
                string fileID = string.Empty;
                if (NewNode.ImageIndex == 2 || NewNode.ImageIndex == 5 || NewNode.ImageIndex == 4 || NewNode.ImageIndex == 7)
                    fileID = NewNode.Name;
                else
                    fileID = NewNode.Parent.Name;
                MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fileID, Globals.ProjectNO);
                if (fileMDL1.fileStatus == "6")
                {
                    MyCommon.ShowWarning("已经组卷的文件不允许修改！");
                    return;
                }
            }
            frmReName frm = new frmReName(NewNode);
            frm.ShowDialog();
            treeFactory.GetCellFileNodesCount(NewNode, true);
        }
        /// <summary>
        /// 节点移动
        /// </summary>
        /// <param name="MoveType"></param>
        private void NodeMove(string MoveType)
        {
            TreeNodeEx NewNode = (TreeNodeEx)(this.treeRight.SelectedNode);
            if (NewNode != null)
            {
                if (NewNode.ImageIndex == 1 || NewNode.ImageIndex == 2 || NewNode.ImageIndex == 3 || NewNode.ImageIndex == 5 || NewNode.ImageIndex == 4 || NewNode.ImageIndex == 7)
                {
                    TreeNodeEx MoveNode = new TreeNodeEx();
                    if (MoveType.Trim().ToUpper().Equals("UP"))
                    {
                        MoveNode = (TreeNodeEx)(NewNode.PrevNode);
                    }
                    else
                    {
                        MoveNode = (TreeNodeEx)(NewNode.NextNode);
                    }
                    if (MoveNode == null)
                    {
                        return;
                    }
                    NewNode.Remove();
                    if (MoveType.Trim().ToUpper().Equals("UP"))
                    {
                        MoveNode.Parent.Nodes.Insert(MoveNode.Index, NewNode);
                    }
                    else
                    {
                        MoveNode.Parent.Nodes.Insert(MoveNode.Index + 1, NewNode);
                    }
                    if (NewNode.ImageIndex == 1 || NewNode.ImageIndex == 2 || NewNode.ImageIndex == 5 || NewNode.ImageIndex == 4 || NewNode.ImageIndex == 7)
                    {
                        UpdateNodeLevel((TreeNode)(MoveNode.Parent));
                    }
                    else if (NewNode.ImageIndex == 3)
                    {
                        BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
                        int OrderIndex = 1;
                        foreach (TreeNode obj in MoveNode.Parent.Nodes)
                        {
                            MDL.T_CellAndEFile cellMDL = cellBLL.Find(obj.Name, Globals.ProjectNO);
                            cellMDL.orderindex = OrderIndex++;
                            //fileMDL.DocYs = 1;//只是移动。文件不用重转
                            cellBLL.Update(cellMDL);
                        }
                        ////要提示文件级的更新
                        //BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                        //MDL.T_FileList fileMDL = fileBLL.Find(cellMDL.FileID, Globals.ProjectNO);
                        //fileMDL.selected = 1;
                        //fileBLL.Update(fileMDL);

                        UpdatePDFView((TreeNodeEx)NewNode.Parent);
                    }
                    this.treeRight.SelectedNode = NewNode;
                }
                else
                {
                    MyCommon.Show("当前选择项不可以移动！");
                }
            }
        }
        /// <summary>
        /// 设置工程资料用表电子文件实体值
        /// </summary>
        /// <param name="model"></param>
        /// <param name="NewNode"></param>
        /// <returns></returns>
        /// <summary>
        ///登记电子文件数据实体赋值
        /// </summary>
        /// <param name="model"></param>
        /// <param name="node"></param>
        /// <param name="PDFPath"></param>
        /// <param name="OrderIndex"></param>
        /// <param name="PgeCount"></param>
        /// <returns></returns>
        private TreeNodeEx IsHavePartentNode(TreeNodeEx NewNode)
        {
            TreeNodeEx oldnodes = (TreeNodeEx)NewNode.Parent;
            TreeNode[] node = treeRight.Nodes.Find(oldnodes.FullPath, true);
            TreeNodeEx[] nodes = new TreeNodeEx[node.Length];
            for (int i = 0; i < node.Length; i++)
            {
                nodes[i] = (TreeNodeEx)node[i];
            }
            if (nodes.Length > 0)
            {
                return nodes[0];
            }
            return null;
        }
        /// <summary>
        /// 创建工程文件夹
        /// </summary>
        private void CreateObjDic()
        {
            if (!System.IO.Directory.Exists(PDFPath))
            {
                System.IO.Directory.CreateDirectory(PDFPath);
            }
            if (!System.IO.Directory.Exists(MovedCellPath))
            {
                System.IO.Directory.CreateDirectory(MovedCellPath);
            }
            if (!System.IO.Directory.Exists(MregeredPDFPath))
            {
                System.IO.Directory.CreateDirectory(MregeredPDFPath);
            }
            if (!System.IO.Directory.Exists(PDFTemp))
            {
                System.IO.Directory.CreateDirectory(PDFTemp);
            }
            //if (!System.IO.Directory.Exists(DWGXML))
            //{
            //    System.IO.Directory.CreateDirectory(DWGXML);
            //}
            //if (!System.IO.Directory.Exists(DWGFont))
            //{
            //    System.IO.Directory.CreateDirectory(DWGFont);
            //}
        }
        ///// <summary>
        ///// 去掉路径中的[0],*
        ///// </summary>
        ///// <param name="node"></param>
        ///// <returns></returns>
        /// <summary>
        /// 更新数据库中的节点顺序
        /// </summary>
        /// <param name="?"></param>
        private void UpdateNodeLevel(TreeNode Node)
        {//借此机会重排一下
            int OrderIndex = 1;
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            foreach (TreeNode obj in Node.Nodes)
            {
                MDL.T_FileList fileMDL = fileBLL.Find(obj.Name, Globals.ProjectNO);
                fileMDL.OrderIndex = OrderIndex++;
                //fileMDL.selected = 1;
                fileBLL.Update(fileMDL);
            }
        }
        /// <summary>
        /// 复制华表到指定位置
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private void CopyTable(TreeNodeEx node)
        {
            TreeNodeEx NewNode = new TreeNodeEx();
            string NewPath;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                NewNode = (TreeNodeEx)node.Nodes[i];
                NewPath = MovedCellPath + NewNode.NodeKey + ".cell";
                if (System.IO.File.Exists(NewNode.NodeValue))
                {
                    System.IO.File.Copy(NewNode.NodeValue, NewPath, true);
                    NewNode.NodeValue = NewPath;
                }
            }
        }
        /// <summary>
        /// 添加模版
        /// </summary>
        private void AddTemplet()
        {
            TreeNodeEx FileNode = new TreeNodeEx();
            FileNode = (TreeNodeEx)this.treeRight.SelectedNode;
            if (FileNode != null && FileNode.ImageIndex == 1)
            {
                frmAddTemplet frm = new frmAddTemplet(FileNode, _parentForm, treeFactory);
                DialogResult return_dialog = frm.ShowDialog();
                if (return_dialog == DialogResult.Yes)
                {
                    int OrderIndex = (new BLL.T_FileList_BLL()).GetMaxOrderIndex(FileNode.Name, Globals.ProjectNO);
                    MDL.T_FileList fileMDL = new T_FileList();
                    fileMDL.FileID = Guid.NewGuid().ToString();
                    fileMDL.ProjectNO = Globals.ProjectNO;
                    fileMDL.ParentID = FileNode.Name;
                    fileMDL.wjtm = frm.txtReName.Text;
                    fileMDL.OrderIndex = OrderIndex + 1;
                    fileMDL.fileStatus = "0";
                    TreeNodeEx newNode = new TreeNodeEx();
                    newNode.Name = fileMDL.FileID;
                    newNode.Text = fileMDL.wjtm;
                    if (frm.checkBox1.Checked == true)
                    {
                        newNode.ImageIndex = 1;
                        newNode.SelectedImageIndex = 1;
                        fileMDL.isvisible = 0;
                    }
                    else
                    {
                        newNode.ImageIndex = 2;
                        newNode.SelectedImageIndex = 2;
                        fileMDL.isvisible = 1;
                    }
                    (new BLL.T_FileList_BLL()).Add(fileMDL);
                    FileNode.Nodes.Add(newNode);
                }
            }
            else
            {
                MyCommon.Show("请选中文件夹！！");
            }
            //this.treeRight.SelectedNode = FileNode.LastNode;
        }
        /// <summary>
        /// 删除模版
        /// </summary>
        private void DeleteTemplet()
        {
            TreeNodeEx Node = (TreeNodeEx)treeRight.SelectedNode;
            if (Node != null)
            {
                DeleteFileNode(Node);
            }
            ////取文件登记状态
            ////根据文件登记状态删除模版
        }
        private void DeleteFileNode(TreeNodeEx node)
        {
            foreach (TreeNodeEx obj in node.Nodes)
            {
                DeleteFileNode(obj);
            }
            MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(node.Name, Globals.ProjectNO);
            if (fileMDL != null)
            {
                if (axPDFReader1.isOpen == 1)
                {
                    axPDFReader1.WebClose();
                }
                if (System.IO.File.Exists(Globals.ProjectPath + fileMDL.filepath))
                {
                    System.IO.File.Delete(Globals.ProjectPath + fileMDL.filepath);
                }
            }

            IList<MDL.T_CellAndEFile> cellList = (new BLL.T_CellAndEFile_BLL()).FindByFileID(node.Name, Globals.ProjectNO, 0);
            foreach (MDL.T_CellAndEFile cellMDL in cellList)
            {
                if (System.IO.File.Exists(Globals.ProjectPath + cellMDL.filepath))
                {
                    System.IO.File.Delete(Globals.ProjectPath + cellMDL.filepath);
                }
                if (System.IO.File.Exists(Globals.ProjectPath + cellMDL.fileTreePath))
                {
                    System.IO.File.Delete(Globals.ProjectPath + cellMDL.fileTreePath);
                }
            }

            (new BLL.T_FileList_BLL()).Delete(node.Name, Globals.ProjectNO);
            (new BLL.T_CellAndEFile_BLL()).DeleteByFileID(node.Name, Globals.ProjectNO);
        }
        /// <summary>
        /// 根据文件登记状态删除模版
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="FileStatus"></param>
        private void DeleteTempletWithFileStatus(TreeNodeEx Node, string FileStatus)
        {
            if (!String.IsNullOrEmpty(FileStatus))
            {
                if (!FileStatus.Equals("4"))
                {
                    if (Node.ImageIndex != 1)
                    {
                        RemoveNode();
                    }
                    else
                    {
                        MyCommon.Show("只能删除文件和电子文件节点！");
                    }
                }
            }
            else
            {
                MyCommon.Show("删除失败，电子文件对应的文件登记为空！");
            }
        }
        /// <summary>
        /// 取文件登记状态
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="cbll"></param>
        /// <param name="FileStatus"></param>
        /// <returns></returns>
        private string GetFileStatusAtDeleteTemplet(TreeNodeEx Node, ERM.CBLL.FileRegist cbll, string FileStatus)
        {
            if (Node.ImageIndex == 3)
            {
                FileStatus = cbll.GetRegistFileStatus(treeFactory.OpeartPath((TreeNodeEx)Node.Parent), Globals.ProjectNO);
            }
            if (Node.ImageIndex == 2 || Node.ImageIndex == 5 || Node.ImageIndex == 4 || Node.ImageIndex == 7)
            {
                FileStatus = cbll.GetRegistFileStatus(treeFactory.OpeartPath(Node), Globals.ProjectNO);
            }
            return FileStatus;
        }
        /// <summary>
        /// 添加模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            AddTemplet();
        }
        /// <summary>
        /// 删除模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveTemplate_Click(object sender, EventArgs e)
        {
            tsDelete_Click(null, null);
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            tsCheck_Click(null, null);
        }
        /// <summary>
        /// 反提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnCheck_Click(object sender, EventArgs e)
        {
            tsunCheck_Click(null, null);
        }
        /// <summary>
        /// 打开资源管理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnShowFileList_Click(object sender, EventArgs e)
        {
            splitContainer3.Panel2Collapsed = !splitContainer3.Panel2Collapsed;
            if (!IsSource)
            {
                ShowResources();
            }
        }
        private void ShowResources()
        {
            TreeImageList.TransparentColor = Color.Magenta;
            TreeImageList.ColorDepth = ColorDepth.Depth24Bit;
            Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 15);
            TreeImageList.Images.Add(ic0);
            Icon ic1 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 5);
            TreeImageList.Images.Add(ic1);
            Icon ic2 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 7);
            TreeImageList.Images.Add(Properties.Resources.tree_folder);
            Icon ic3 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 11);
            TreeImageList.Images.Add(ic3);
            Icon ic4 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 3);
            TreeImageList.Images.Add(Properties.Resources.tree_folder);
            Icon ic5 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 4);
            TreeImageList.Images.Add(ic5);
            Icon ic6 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 101);
            TreeImageList.Images.Add(ic6);
            GetDrive();
            IsSource = true;
        }
        [DllImport("Shell32.dll")]
        public static extern int ExtractIcon(IntPtr h, string strx, int ii);
        [DllImport("Shell32.dll")]
        public static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            public char szDisplayName;
            public char szTypeName;
        }
        string strFilePath = "";
        protected virtual Icon myExtractIcon(string FileName, int iIndex)
        {
            try
            {
                IntPtr hIcon = (IntPtr)ExtractIcon(this.Handle, FileName, iIndex);
                if (!hIcon.Equals(null))
                {
                    Icon icon = Icon.FromHandle(hIcon);
                    return icon;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
            return null;
        }
        protected virtual void SetIcon(ImageList imageList, string FileName, bool tf)
        {
            SHFILEINFO fi = new SHFILEINFO();
            if (tf == true)
            {
                int iTotal = (int)SHGetFileInfo(FileName, 0, ref fi, 100, 16640);//SHGFI_ICON|SHGFI_SMALLICON
                try
                {
                    if (iTotal > 0)
                    {
                        Icon ic = Icon.FromHandle(fi.hIcon);
                        imageList.Images.Add(ic);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
            }
            else
            {
                int iTotal = (int)SHGetFileInfo(FileName, 0, ref fi, 100, 257);
                try
                {
                    if (iTotal > 0)
                    {
                        Icon ic = Icon.FromHandle(fi.hIcon);
                        imageList.Images.Add(ic);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
            }
        }
        public void GetDrive()
        {
            treeView1.ImageList = TreeImageList;
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            TreeNode RootNode = new TreeNode("我的电脑", 0, 0);
            treeView1.Nodes.Add(RootNode);
            int iImageIndex = 2; int iSelectedIndex = 2;
            string[] astrDrives = Directory.GetLogicalDrives();
            foreach (string str in astrDrives)
            {
                if (str == "A:\\")
                { iImageIndex = 1; iSelectedIndex = 1; }
                else if (str == "G:\\")
                { iImageIndex = 3; iSelectedIndex = 3; }
                else
                { iImageIndex = 2; iSelectedIndex = 2; }
                TreeNode tnDrive = new TreeNode(str, iImageIndex, iSelectedIndex);
                treeView1.Nodes[0].Nodes.Add(tnDrive);
                AddDirectories(tnDrive, true);
                if (str == "C:\\")
                { treeView1.SelectedNode = tnDrive; }
            }
            TreeNode tnDrive1 = new TreeNode("桌面", 4, 4);
            treeView1.Nodes[0].Nodes.Add(tnDrive1);
            AddDirectories(tnDrive1, false);
            treeView1.EndUpdate();
        }
        void AddDirectories(TreeNode tn, bool flag)
        {
            tn.Nodes.Clear();
            string strPath = null;
            if (flag)
            {
                strPath = tn.FullPath;
                strPath = strPath.Remove(0, 5);
            }
            else
            {
                strPath = "C:\\Documents and Settings\\" + Environment.UserName + "\\" + (tn.FullPath.Substring(tn.FullPath.LastIndexOf("桌面")));
            }
            DirectoryInfo dirinfo = new DirectoryInfo(strPath);
            DirectoryInfo[] adirinfo;
            try
            {
                adirinfo = dirinfo.GetDirectories();
            }
            catch
            { return; }
            int iImageIndex = 4; int iSelectedIndex = 5;
            foreach (DirectoryInfo di in adirinfo)
            {
                if (di.Name == "RECYCLER" || di.Name == "RECYCLED" || di.Name == "Recycled")
                { iImageIndex = 6; iSelectedIndex = 6; }
                else
                { iImageIndex = 4; iSelectedIndex = 5; }
                TreeNode tnDir = new TreeNode(di.Name, iImageIndex, iSelectedIndex);
                tn.Nodes.Add(tnDir);
            }
        }
        private void treeView1_BeforeExpand_1(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            treeView1.BeginUpdate();
            foreach (TreeNode tn in e.Node.Nodes)
            {
                if (tn.FullPath.LastIndexOf("桌面") > 0)
                {
                    AddDirectories(tn, false);
                }
                else
                {
                    AddDirectories(tn, true);
                }
            }
            treeView1.EndUpdate();
        }
        protected virtual void InitList(TreeNode tn)
        {
            this.LisrimageList2.Images.Clear();
            this.LisrimageList.Images.Clear();
            Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 3);
            LisrimageList.Images.Add(ic0);
            LisrimageList2.Images.Add(ic0);
            string strPath = null;
            if (tn.FullPath.LastIndexOf("桌面") > 0)
            {
                strPath = "C:\\Documents and Settings\\" + Environment.UserName + "\\" + (tn.FullPath.Substring(tn.FullPath.LastIndexOf("桌面")));
            }
            else
            {
                strPath = tn.FullPath;
                strPath = strPath.Remove(0, 5);
            }
            DirectoryInfo curDir = new DirectoryInfo(strPath);//创建目录对象。
            FileInfo[] dirFiles;
            if (String.IsNullOrEmpty(curDir.Extension))
            {
                try
                {
                    dirFiles = curDir.GetFiles();
                }
                catch { return; }
                int iCount = 0; int iconIndex = 1;//用1，而不用0是要让过0号图标。
                foreach (FileInfo fileInfo in dirFiles)
                {
                    string strFileName = fileInfo.Name;
                    string str = fileInfo.FullName;
                    try
                    {
                        SetIcon(LisrimageList, str, false);
                        SetIcon(LisrimageList2, str, true);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
                    iCount++;
                    iconIndex++;
                }
                strFilePath = strPath;
            }
        }
        private void treeView1_AfterSelect_1(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node.Text == "我的电脑")
            { return; }
            InitList(e.Node);
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.listView1.Items.Clear();
            if (e.Node.FullPath.Length >= 5 || e.Node.Text.Equals("桌面"))
            {
                DirectoryInfo dirinfo = null;
                if (e.Node.Text.Equals("桌面"))
                {
                    dirinfo = new DirectoryInfo("C:\\Documents and Settings\\" + Environment.UserName + "\\桌面");
                }
                else
                {
                    if (e.Node.FullPath.LastIndexOf("桌面") > 0)
                    {
                        dirinfo = new DirectoryInfo("C:\\Documents and Settings\\" + Environment.UserName + "\\" + (e.Node.FullPath.Substring(e.Node.FullPath.LastIndexOf("桌面"))));
                    }
                    else
                    {
                        dirinfo = new DirectoryInfo(e.Node.FullPath.Remove(0, 5));
                    }
                }
                FileInfo[] dirFiles;
                try
                {
                    dirFiles = dirinfo.GetFiles();
                }
                catch
                {
                    return;
                }
                int iCount = 0;
                ImageList listSmall = new ImageList();
                ImageList listLarge = new ImageList();
                foreach (FileInfo fi in dirFiles)
                {
                    if (Globals.PrintType.IndexOf(fi.Name.Substring(fi.Name.LastIndexOf(".") + 1).Trim().ToUpper()) >= 0)
                    {
                        string str = fi.FullName;
                        try
                        {
                            SetIcon(listSmall, str, false);
                            SetIcon(listLarge, str, true);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
                        string[] arrSubItem = new string[4];
                        if (!fi.Name.Equals("pagefile.sys"))
                        {
                            arrSubItem[0] = fi.Name;
                            arrSubItem[1] = fi.Length + " 字节";
                            arrSubItem[2] = fi.Extension.Substring(fi.Extension.LastIndexOf('.') + 1);
                            arrSubItem[3] = fi.LastAccessTime.ToString();
                        }
                        else
                        { arrSubItem[1] = "未知大小"; arrSubItem[2] = "未知日期"; arrSubItem[3] = "未知日期"; }
                        ListViewItem tnDir = new ListViewItem();
                        tnDir.ImageIndex = iCount;
                        tnDir.Name = str;
                        tnDir.SubItems[0].Text = arrSubItem[0];
                        tnDir.SubItems.Add(arrSubItem[1]);
                        tnDir.SubItems.Add(arrSubItem[2]);
                        tnDir.SubItems.Add(arrSubItem[3]);
                        this.listView1.Items.Add(tnDir);
                        if (DefaultListView != View.SmallIcon)
                        {
                            listView1.View = DefaultListView;
                        }
                        else
                        {
                            listView1.View = View.Details;
                        }
                        this.listView1.SmallImageList = listLarge;
                        this.listView1.LargeImageList = listSmall;
                        iCount++;
                    }
                }
            }
        }
        private void treeFile_MouseDown(object sender, MouseEventArgs e)
        {
            TreeOrList = 1;
        }
        private void treeRight_MouseDown(object sender, MouseEventArgs e)
        {
            TreeOrList = 0;
        }
        /// <summary>
        /// 点击节点操作
        /// </summary>
        /// <param name="NewNode"></param>
        private void RefreshNode(TreeNodeEx NewNode)
        {
            return;
            CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            OperationAtRefeshNode(NewNode, cbll);
            OperationAtClickTemplet(NewNode, cbll);
            OperationAtClickFileList(NewNode);
        }
        /// <summary>
        /// 根据所选择的节点设置按钮的属性
        /// </summary>
        /// <param name="NewNode"></param>
        private void SetButtonStatus(TreeNodeEx NewNode)
        {
            CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            string IsInput = "0";
            string IsChecked = null;
            if (NewNode.ImageIndex != 1)
            {
                if (NewNode.ImageIndex == 3)
                {
                    IsInput = cbll.GetCell_TempletCustomdefine(treeFactory.OpeartPath((TreeNodeEx)(NewNode.Parent)));
                    IsChecked = cbll.GetRegistFileStatus(treeFactory.OpeartPath((TreeNodeEx)(NewNode.Parent)), Globals.ProjectNO);
                }
                else
                {
                    if (NewNode.Tag != "")
                    {
                        IsInput = cbll.GetCell_TempletCustomdefine(treeFactory.OpeartPath(NewNode));
                        IsChecked = cbll.GetRegistFileStatus(treeFactory.OpeartPath(NewNode), Globals.ProjectNO);
                    }
                }
            }
            if (NewNode.Parent == null)
            {
                treeRight.LabelEdit = false;
                tsAddTemplate.Visible = false;
                t1_EditNode.Visible = false;
                tsOutput.Visible = false;
            }
            if (NewNode.ImageIndex == 1)
            {
                treeRight.LabelEdit = false;
                if (Globals.TreeSelectView.Equals("CJDAG"))
                {
                    if (cbll.GetNewFileRecording_TempletHasTable_Name(NewNode.FullPath))
                    {
                        tsAddTemplate.Visible = true;
                        tsmiAddTemplate.Visible = true;
                    }
                    else
                    {
                        tsAddTemplate.Visible = false;
                        tsmiAddTemplate.Visible = false;
                    }
                }
                else
                {
                    tsAddTemplate.Visible = true;
                    tsmiAddTemplate.Visible = true;
                }
                tsDeleteTemplate.Visible = false;
                tsmiMoveTemplate.Visible = false;
                tsmiSignature.Visible = true;
                tsmiUnSignature.Visible = true;
                tsUnRegist.Visible = false;
                tsReName.Visible = false;
                t1_DelNode.Visible = false;
                t1_EditNode.Visible = false;
                tsOutput.Visible = true;
            }
            if (NewNode.ImageIndex == 2 || NewNode.ImageIndex == 7)
            {
                tsAddTemplate.Visible = false;
                tsmiAddTemplate.Visible = false;
                if (!String.IsNullOrEmpty(IsInput) && IsInput.Equals("1"))
                {
                    treeRight.LabelEdit = false;
                    tsDeleteTemplate.Visible = true;
                    tsmiMoveTemplate.Visible = true;
                    t1_DelNode.Visible = true;
                }
                else
                {
                    treeRight.LabelEdit = false;
                    tsDeleteTemplate.Visible = false;
                    tsmiMoveTemplate.Visible = false;
                    t1_DelNode.Visible = false;
                }
                tsmiSignature.Visible = false;
                tsmiUnSignature.Visible = false;
                tsUnRegist.Visible = false;
                tsReName.Visible = false;
                t1_EditNode.Visible = false;
                tsOutput.Visible = false;
            }
            if (NewNode.ImageIndex == 4)
            {
                treeRight.LabelEdit = false;
                tsAddTemplate.Visible = false;
                tsmiAddTemplate.Visible = false;
                tsDeleteTemplate.Visible = false;
                tsmiMoveTemplate.Visible = false;
                tsmiSignature.Visible = true;
                tsmiUnSignature.Visible = true;
                tsUnRegist.Visible = false;
                tsReName.Visible = false;
                t1_DelNode.Visible = false;
                t1_EditNode.Visible = false;
                tsOutput.Visible = false;
            }
            if (NewNode.ImageIndex == 5)
            {
                tsAddTemplate.Visible = false;
                tsmiAddTemplate.Visible = false;
                if (!String.IsNullOrEmpty(IsInput) && IsInput.Equals("1"))
                {
                    treeRight.LabelEdit = false;
                    tsDeleteTemplate.Visible = true;
                    tsmiMoveTemplate.Visible = true;
                    t1_DelNode.Visible = true;
                }
                else
                {
                    treeRight.LabelEdit = false;
                    tsDeleteTemplate.Visible = false;
                    tsmiMoveTemplate.Visible = false;
                    t1_DelNode.Visible = false;
                }
                tsmiSignature.Visible = false;
                tsmiUnSignature.Visible = false;
                tsUnRegist.Visible = true;
                if ((!String.IsNullOrEmpty(IsInput)) && IsInput.Equals("1"))
                {
                    tsReName.Visible = true;
                    t1_EditNode.Visible = true;
                }
                else
                {
                    tsReName.Visible = false;
                    t1_EditNode.Visible = false;
                }
                tsOutput.Visible = false;
            }
            if (NewNode.ImageIndex == 3)
            {
                treeRight.LabelEdit = true;
                tsAddTemplate.Visible = false;
                tsmiAddTemplate.Visible = false;
                tsDeleteTemplate.Visible = false;
                tsmiMoveTemplate.Visible = false;
                tsmiSignature.Visible = false;
                tsmiUnSignature.Visible = false;
                string IsCustor = cbll.GetAttachmentCustomdefine(treeFactory.OpeartPath((TreeNodeEx)(NewNode.Parent)), NewNode.Text, Globals.ProjectNO);
                if (IsChecked != null && (IsChecked.Equals("4") || IsChecked.Equals("5") || String.IsNullOrEmpty(IsCustor) || IsCustor.Equals("系统内部")))
                {
                    treeRight.LabelEdit = false;
                    tsReName.Visible = false;
                    t1_DelNode.Visible = false;
                    t1_EditNode.Visible = false;
                }
                else
                {
                    tsReName.Visible = true;
                    t1_DelNode.Visible = true;
                    t1_EditNode.Visible = true;
                }
                tsUnRegist.Visible = false;
                tsOutput.Visible = false;
            }
        }
        /// <summary>
        /// 点击电子文件的时候所做的操作
        /// </summary>
        /// <param name="NewNode"></param>
        private void OperationAtClickFileList(TreeNodeEx NewNode)
        {
            if (NewNode.ImageIndex == 3)
            {
                string ViewPath = null;
                try
                {
                    if (NewNode.NodeKey.Length < 36)
                    {
                        ViewPath = NewNode.NodeValue.Substring(NewNode.NodeValue.LastIndexOf("\\") + 1);
                        ViewPath = ViewPath.Substring(0, ViewPath.LastIndexOf("."));
                        if (!System.IO.File.Exists(PDFPath + ViewPath + ".daf"))
                        {
                            if (System.IO.File.Exists(projectPath + "\\" + Globals.ProjectNO + "\\" + ViewPath + ".daf"))
                            {
                                System.IO.File.Copy(projectPath + "\\" + Globals.ProjectNO + "\\" + ViewPath + ".daf", PDFPath + ViewPath + ".daf", true);
                            }
                        }
                        if (!System.IO.File.Exists(MovedCellPath + ViewPath + ".cll"))
                        {
                            if (System.IO.File.Exists(projectPath + Globals.ProjectNO + "\\" + ViewPath + ".cll"))
                            {
                                System.IO.File.Copy(projectPath + Globals.ProjectNO + "\\" + ViewPath + ".cll", MovedCellPath + ViewPath + ".cll", true);
                            }
                        }
                    }
                    else
                    {
                        ViewPath = NewNode.NodeKey.Substring(NewNode.NodeKey.LastIndexOf("\\") + 1);
                        if (NewNode.NodeKey.Length > 36)
                        {
                            ViewPath = ViewPath.Substring(0, ViewPath.LastIndexOf("."));
                        }
                    }
                    this.axPDFReader1.WebClose();
                    if (System.IO.Directory.Exists(PDFTemp))
                    {
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(PDFTemp);
                    }
                    if (System.IO.File.Exists(PDFPath + ViewPath + ".daf"))
                    {
                        System.IO.File.Copy(PDFPath + ViewPath + ".daf", PDFTemp + ViewPath + ".pdf", true);
                        if (System.IO.File.Exists(PDFTemp + ViewPath + ".pdf"))
                        {
                            this.axPDFReader1.WebOpenLocalFile(PDFTemp + ViewPath + ".pdf");
                        }
                        else
                        {
                            MyCommon.Show("原文件不存在,或已被删除！");
                            axPDFReader1.WebClose();
                        }
                    }
                    else
                    {
                        MyCommon.Show("您要查看的文件不存在,或已被删除！");
                    }
                    this.treeRight.SelectedNode.Checked = true;
                }
                catch
                {
                    MyCommon.Show("浏览错误！！");
                }
            }
        }
        /// <summary>
        /// 点击模版的时候所做的操作
        /// </summary>
        /// <param name="NewNode"></param>
        /// <param name="cbll"></param>
        private void OperationAtClickTemplet(TreeNodeEx NewNode, CBLL.FileRegist cbll)
        {
            if (NewNode.ImageIndex == 2 | NewNode.ImageIndex == 4 | NewNode.ImageIndex == 5 | NewNode.ImageIndex == 7)
            {
                this.fileBaseInfo.Visible = true;
                fileBaseInfo.ShowData(NewNode);
            }
            else
            {
                this.fileBaseInfo.Visible = false;
            }
        }
        /// <summary>
        /// 初始化展开的节点
        /// </summary>
        /// <param name="NewNode"></param>
        /// <param name="cbll"></param>
        private void OperationAtRefeshNode(TreeNodeEx NewNode, CBLL.FileRegist cbll)
        {
            if (NewNode.IsFirstExpand)
            {
                if (NewNode.ImageIndex == 1)
                {
                    treeFactory.RefreshFileNode(NewNode, true, Globals.ProjectNO, true, false, treeEnum, true);
                    if (NewNode.Nodes.Count > 0)
                    {
                        treeFactory.SetNodeIcon(NewNode);
                    }
                }
            }
        }
        /// <summary>
        /// 双击节点操作
        /// </summary>
        /// <param name="theNode"></param>
        public void OperationAtDoubleClickNode(TreeNodeEx theNode)
        {
            return;
            CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            if (theNode == null) return;
            if (theNode.ImageIndex == 2 | theNode.ImageIndex == 4 | theNode.ImageIndex == 5 | theNode.ImageIndex == 7)
            {
                if (theNode.Nodes.Count <= 0)
                {//需要加入节点
                }
                fileBaseInfo.ShowData(theNode);
            }
        }
        /// <summary>
        /// 获取合并后的PDF路径
        /// </summary>
        /// <param name="TreePath"></param>
        /// <returns></returns>
        private string GetPdfPath(string TreePath)
        {
            CBLL.FileRegist cbll = new ERM.CBLL.FileRegist();
            DataSet ds = cbll.GetPdfPath(TreePath, Globals.ProjectNO);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["filepath"].ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 上一节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_prev_Click(object sender, EventArgs e)
        {
            treeFactory.SelectPrevNode(treeRight);
        }
        /// <summary>
        /// 下一节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_Next_Click(object sender, EventArgs e)
        {
            treeFactory.SelectNextNode(treeRight);
        }
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_EditNode_Click(object sender, EventArgs e)
        {
            ReName();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_DelNode_Click(object sender, EventArgs e)
        {
            tsDelete_Click(null, null);
        }
        /// <summary>
        /// 节点上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_Up_Click(object sender, EventArgs e)
        {
            NodeMove("UP");
        }
        /// <summary>
        /// 节点下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_Down_Click(object sender, EventArgs e)
        {
            NodeMove("DOWN");
        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiImportFile_Click(object sender, EventArgs e)
        {
            tsInput_Click(null, null);
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiMoveFile_Click(object sender, EventArgs e)
        {
            tsOutput_Click(null, null);
        }
        /// <summary>
        /// 添加模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAddTemplate_Click(object sender, EventArgs e)
        {
            tsAddTemplate_Click(null, null);
        }
        /// <summary>
        /// 删除模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiMoveTemplate_Click(object sender, EventArgs e)
        {
            tsDeleteTemplate_Click(null, null);
        }
        /// <summary>
        /// 合并文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiCheck_Click(object sender, EventArgs e)
        {
            tsCheck_Click(null, null);
        }
        /// <summary>
        /// 拆分文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiUnCheck_Click(object sender, EventArgs e)
        {
            tsunCheck_Click(null, null);
        }
        /// <summary>
        /// 未登记文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiUnRegist_Click(object sender, EventArgs e)
        {
            btnUnRegistFile_Click(null, null);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSave_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
        }
        /// <summary>
        /// 大图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiListLarge_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
            DefaultListView = listView1.View;
        }
        /// <summary>
        /// 小图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiListSmall_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiListList_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
            DefaultListView = listView1.View;
        }
        /// <summary>
        /// 详细列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiListDetail_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            DefaultListView = listView1.View;
        }
        /// <summary>
        /// 有电子文件的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drptsmiNoAttachment_Click(object sender, EventArgs e)
        {
            //treeFactory.GetTree(treeRight, true, Globals.ProjectNO, 2, true);
            //treeFactory.HideEmptyNode((TreeNodeEx)treeRight.Nodes[treeRight.Nodes.Count - 1], 2);
            treeFactory.GetTree(treeRight, Globals.ProjectNO, "filestatus=2", true, true, 2, true);
            this.drpFileStatus.Text = drpFileStaus2.Text;
        }
        /// <summary>
        /// 已登记的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drptsmiNoRegost_Click(object sender, EventArgs e)
        {
            //treeFactory.GetTree(treeRight, true, Globals.ProjectNO, 4, true);
            //treeFactory.HideEmptyNode((TreeNodeEx)treeRight.Nodes[treeRight.Nodes.Count - 1], 4);
            treeFactory.GetTree(treeRight, Globals.ProjectNO, "filestatus=4", true, true, 2, true);
            this.drpFileStatus.Text = drpFileStaus4.Text;
        }
        /// <summary>
        /// 未组卷的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drptsmiNoPaper_Click(object sender, EventArgs e)
        {
            //treeFactory.GetTree(treeRight, true, Globals.ProjectNO, 5, true);
            //treeFactory.HideEmptyNode((TreeNodeEx)treeRight.Nodes[treeRight.Nodes.Count - 1], 5);
            //            treeFactory.GetTree(treeRight, Globals.ProjectNO, "filestatus=5", true, true, 2, true);
            treeFactory.GetTree(treeRight, Globals.ProjectNO, "filestatus in(0,1,2,3,4,5)", true, true, 2, true);
            this.drpFileStatus.Text = drpFileStaus5.Text;
        }
        /// <summary>
        /// 组卷的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drptsmiIsPaper_Click(object sender, EventArgs e)
        {
            //treeFactory.GetTree(treeRight, true, Globals.ProjectNO, 6, true);
            //treeFactory.HideEmptyNode((TreeNodeEx)treeRight.Nodes[treeRight.Nodes.Count - 1], 6);
            treeFactory.GetTree(treeRight, Globals.ProjectNO, "filestatus=6", true, true, 2, true);
            this.drpFileStatus.Text = drpFileStaus6.Text;
        }
        /// <summary>
        /// 全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drptsmiIsFull_Click(object sender, EventArgs e)
        {
            //treeFactory.GetTree(treeRight, true, Globals.ProjectNO, 0, true);
            treeFactory.GetTree(treeRight, Globals.ProjectNO, "", true, true, 2, true);
            this.drpFileStatus.Text = drpFileStaus0.Text;
        }
        /// <summary>
        /// 无电子文件的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //treeFactory.GetTree(treeRight, true, Globals.ProjectNO, 1, true);
            //treeFactory.HideEmptyNode((TreeNodeEx)treeRight.Nodes[treeRight.Nodes.Count - 1], 1);
            treeFactory.GetTree(treeRight, Globals.ProjectNO, "filestatus=1", true, true, 2, true);
            this.drpFileStatus.Text = drpFileStaus1.Text;
        }
        /// <summary>
        /// 未登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //treeFactory.GetTree(treeRight, true, Globals.ProjectNO, 3, true);
            //treeFactory.HideEmptyNode((TreeNodeEx)treeRight.Nodes[treeRight.Nodes.Count - 1], 3);
            treeFactory.GetTree(treeRight, Globals.ProjectNO, "filestatus in (0,1,2,3,5)", true, true, 2, true);
            this.drpFileStatus.Text = drpFileStaus3.Text;
        }
        public bool RegistFirst = false;
        /// <summary>
        /// 快速查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ////frm._FirstLoad = RegistFirst;
            searchFrm = (frmMainSearch)Application.OpenForms["frmMainSearch"];
            if (searchFrm == null)
            {
                searchFrm = new frmMainSearch(this);
                searchFrm.Owner = this;
                searchFrm.Show();
            }
            searchFrm.Focus();
        }
        /// <summary>
        /// DWG字库管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnDeleteDWG_Click(object sender, EventArgs e)
        //{
        //    //FrmDeleteDwgFont frm = new FrmDeleteDwgFont();
        //    frm.Show();
        //}
        private void TestCheck(TreeNode Node)
        {
            ERM.CBLL.FileRegist cbll = new FileRegist();
            DataSet dsT = cbll.GetWillCheckTemplate(cbll.GetFilePID(treeFactory.OpeartPath((TreeNodeEx)Node), Globals.ProjectNO), Globals.ProjectNO);
            if (dsT != null && dsT.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsT.Tables[0].Rows.Count; i++)
                {
                    DataSet ds = cbll.GetAttachment(dsT.Tables[0].Rows[i]["Treepath"].ToString(), Globals.ProjectNO);
                    string[] FileName = new string[ds.Tables[0].Rows.Count];
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        FileName = GetPDFFileName(ds, FileName);
                        if (FileName.Length > 0)
                        {
                            bool PathIsNull = FileNameIsNullOrEmpty(FileName);
                            DataSet dsNum = cbll.FindFileRegistNum(dsT.Tables[0].Rows[i]["Treepath"].ToString(), Globals.ProjectNO);
                            string FileRegistID = dsNum.Tables[0].Rows[0]["FileID"].ToString();
                            if (PathIsNull)
                            {
                                int nTzz = 0;
                                int nDtz = 0;
                                if (!String.IsNullOrEmpty(dsT.Tables[0].Rows[i]["tzz"].ToString()))
                                {
                                    nTzz = Convert.ToInt32(dsT.Tables[0].Rows[i]["tzz"].ToString());
                                }
                                if (!String.IsNullOrEmpty(dsT.Tables[0].Rows[i]["dtz"].ToString()))
                                {
                                    nDtz = Convert.ToInt32(dsT.Tables[0].Rows[i]["dtz"].ToString());
                                }
                                int TzResult = nTzz + nDtz;
                                int nZpz = 0;
                                int nDpz = 0;
                                if (!String.IsNullOrEmpty(dsT.Tables[0].Rows[i]["zpz"].ToString()))
                                {
                                    nZpz = Convert.ToInt32(dsT.Tables[0].Rows[i]["zpz"].ToString());
                                }
                                if (!String.IsNullOrEmpty(dsT.Tables[0].Rows[i]["dpz"].ToString()))
                                {
                                    nDpz = Convert.ToInt32(dsT.Tables[0].Rows[i]["dpz"].ToString());
                                }
                                int ZpResult = nZpz + nDpz;
                            }
                        }
                    }
                }
            }
            this.SetButtonStatus((TreeNodeEx)Node);
            treeFactory.SetIcon(Node.Nodes);
        }

        private void tsShowMPdf_Click(object sender, EventArgs e)
        {
            if (this.treeRight.SelectedNode.ImageIndex == 4)
            {
                this.axPDFReader1.WebClose();
                ERM.CBLL.FileRegist CBLL = new FileRegist();
                string FilePath = CBLL.GetMPdfPath(treeFactory.OpeartPath((TreeNodeEx)this.treeRight.SelectedNode), Globals.ProjectNO);
            }
        }
        private void tsPrint_Click(object sender, EventArgs e)
        {
            ERM.CBLL.FileRegist cbll = new FileRegist();
            DataSet dsT = cbll.GetWillPrintTemplate(cbll.GetFilePID(treeFactory.OpeartPath((TreeNodeEx)this.treeRight.SelectedNode), Globals.ProjectNO), Globals.ProjectNO, MregeredPDFPath);
            DataView dw = dsT.Tables[0].DefaultView;
            delPrintPDF del = new delPrintPDF(NodePrint);
            frmPrintCell fCell = new frmPrintCell(dw, del, null);
            fCell.ShowDialog();
        }
        private bool NodePrint(string filepath, string printname)
        {
            if (System.IO.File.Exists(filepath))
            {
                ERM.CBLL.FileRegist cbll = new FileRegist();
                this.axPDFReader1.WebClose();
                this.axPDFReader1.WebOpenLocalFile(filepath);
                this.axPDFReader1.WebPrint(1, printname, 0, 0, false);
                this.axPDFReader1.WebClose();
            }
            else
            {
                axPDFReader1.WebClose();
            }
            return true;
        }
        /// <summary>
        /// 重命名节点操作
        /// </summary>
        private void RenameNodetext(string NewText)
        {
            if (!String.IsNullOrEmpty(NewText))
            {
                if (ERM.Common.FilterChars.HasFilterChars(NewText))
                {
                    MyCommon.ShowWarning("不能包含有" + ERM.Common.FilterChars.Chars2String() + "等字符！");
                    return;
                }
                frmReName frm = new frmReName((TreeNodeEx)this.treeRight.SelectedNode);
                frm.Save(NewText);
            }
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
        }
        private void mnuAddEFile_Click(object sender, EventArgs e)
        {
        }

        private void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            Globals.ZRR = fileBaseInfo.zrr.Text;
            btnSave_Click(sender, e);
            TreeNodeEx theNode = (TreeNodeEx)treeRight.SelectedNode;
            if (theNode != null)
            {
                treeRight.SelectedNode = theNode.NextNode;
            }
        }
        private string findKey = "";
        private IList<MDL.T_FileList> dsFildResult;
        private ERM.CBLL.CellTreesData treesData = new ERM.CBLL.CellTreesData();
        public string DoFind(string nodeid, string codeno, string title, bool check1, bool check2)
        {
            string ret = nodeid;
            if (dsFildResult == null || dsFildResult.Count <= 0 || findKey == "" || findKey != title)
            {
                dsFildResult = treesData.DoFind(nodeid.Trim(','), MyCommon.ToSqlString(title), MyCommon.ToSqlString(codeno), check1, check2, Globals.ProjectNO);
                findKey = title;
            }
            if (dsFildResult == null || dsFildResult.Count <= 0)
            {
                ret = "";
                MyCommon.ShowInfo("没有找到相关资料！");
            }
            else
            {
                MDL.T_FileList obj = new ERM.MDL.T_FileList();
                if (dsFildResult.Count > 0)
                {
                    obj = dsFildResult[0];
                    dsFildResult.RemoveAt(0);
                    ExpendParentNode(obj);
                }
            }
            return ret;
        }
        private ArrayList pnodeList = new ArrayList();
        private void ExpendParentNode(MDL.T_FileList obj)
        {
            pnodeList.Clear();
            GetParentNode(obj);
            foreach (MDL.T_FileList obj3 in pnodeList)
            {
                treeFactory.SelectNode(treeRight, obj3.FileID);
            }
        }
        private void GetParentNode(MDL.T_FileList obj)
        {
            pnodeList.Insert(0, obj);
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            MDL.T_FileList objP = fileBLL.Find(obj.ParentID, obj.ProjectNO);
            if (objP != null)
            {
                GetParentNode(objP);
            }
        }
        private void ExpendNode(TreeNode currentNode)
        {
            //    foreach (TreeNodeEx obj in currentNode.Nodes)
            //    {
            //if (obj.Nodes.Count < 1)
            //{
            //    int iTag = 0;
            //    if (obj.Tag != null)
            //    {
            //        iTag = int.Parse(obj.Tag.ToString());
            //    }
            //    treeFactory.LoadFileChildNodes(obj.Nodes, obj.Name, iTag, 2);
            //}
            //}
        }
        private void treeRight_AfterExpand(object sender, TreeViewEventArgs e)
        {
            ExpendNode(e.Node);
        }
        private void toolbarImport_Click(object sender, EventArgs e)
        {
            frmImpData Frm = new frmImpData();
            DialogResult drt = Frm.ShowDialog();
            if (drt == DialogResult.OK)
            {
                // treeFactory.GetTree(treeView1, true, Globals.ProjectNO, 0, true);
                //treeFactory.GetTree(treeRight, true, Globals.ProjectNO, 0, true);
                treeFactory.GetTree(treeRight, Globals.ProjectNO, "", true, true, 2, true);
                //if (Frm.dtErr.Rows.Count > 0)
                //{
                //    frmOutInError frm = new frmOutInError(this, Frm.dtErr, true);
                //    frm.Owner = this;
                //    frm.Show();
                //    frm.Focus();
                //}
                //else
                MyCommon.ShowInfo("导入数据成功！");
            }
        }

        private void ts_SavaItem_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
        }

        private void treeRight_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode curNode = treeRight.SelectedNode;
            if (curNode != null && (curNode.ImageIndex == 2 || curNode.ImageIndex == 5 || curNode.ImageIndex == 7) && fileBaseInfo.btnbEnableQuickInput.Checked == true)
            {
                btnSave_Click(null, null);
            }
        }
    }
}
