using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing.Text;
using ERM.Common;
using System.Threading;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI
{
    public delegate bool delPrintPDF(string filepath, string id);
    public partial class frmCellMain : ERM.UI.Controls.Skin_DevEX
    {
        #region 参数初始化
        private string findKey = "";
        private IList<MDL.T_FileList> dsFildResult;
        public TreeFactory treeFactory = new TreeFactory();
        private ERM.CBLL.CellTreesData treesData = new ERM.CBLL.CellTreesData();
        private ERM.MDL.T_FileList fileModel;
        private ERM.MDL.T_CellAndEFile cellMode;
        private ERM.BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
        private Form _parentForm;
        delPrintPDF Mydel;//= new delPrintPDF(PrintCellToPDF);//打印委托
        public string CopyFileID = "";
        frmMainSearch searchFrm;

        //private Printer oPrinter = null;
        //private BCL.easyPDF6.Interop.EasyPDFPrinter.Digipower.PrinterMonitor oPrinterMonitor = null;

        private string outFile = "";
        private string tempFile = Application.StartupPath + "\\temp2\\";

        #endregion

        #region 窗体函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parentForm">父窗体</param>
        public frmCellMain(Form parentForm)
        {
            InitializeComponent();
            this.Cell2.Login("digipower", "11100101845", "1040-1145-0062-4005");
            this.Cell2.LocalizeControl(0x804);
            this._parentForm = parentForm;
            this.Init();

            Mydel = new delPrintPDF(PrintCellToPDF);
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (searchFrm != null)
            {
                try
                {
                    searchFrm.Close();
                }
                catch { }
            }
            this._parentForm.Show();
            this._parentForm.Activate();
        }

        /// <summary>
        /// 显示Cell文件
        /// </summary>
        /// <param name="fileID">文件ID</param>
        private void showCell(string fileID)
        {
            // string fileID = e.Node.Name;
            IList<MDL.T_CellAndEFile> cellAndEFile_List =
              (new BLL.T_CellAndEFile_BLL()).FindByFileID(fileID, Globals.ProjectNO);
            if (cellAndEFile_List != null && cellAndEFile_List.Count > 0)
            {
                string filePath = cellAndEFile_List[0].filepath;
                if (filePath != null && filePath.Length > 0 && filePath.IndexOf(".cll") > -1)
                {
                    int retValue = Cell2.OpenFile(string.Concat(Globals.ProjectPath, filePath), "");
                    Cell2.HScrollHeight = 1;
                    //Cell2.VScrollWidth = 0;
                    if (Cell2.GetTotalSheets() > 1)
                        Cell2.SetCurSheet(0);
                }
                else
                {
                    IList<MDL.T_CellFileTemplate> cellFileTemplate_List =
                     (new BLL.T_CellFileTemplate_BLL()).FindByFileID(fileID);
                    if (cellFileTemplate_List != null && cellFileTemplate_List.Count > 0
                        && cellFileTemplate_List[0].filepath != null && cellFileTemplate_List[0].filepath.Length > 0)
                    {

                        int retValue = Cell2.OpenFile(string.Concat(Application.StartupPath, "\\", "Template", cellFileTemplate_List[0].filepath), "");
                        //Cell2.AutoScrollOffset = 1;
                        //Cell2.VScrollWidth = 0;
                        if (Cell2.GetTotalSheets() > 1)
                            Cell2.SetCurSheet(0);
                    }
                    else
                    {
                        Cell2.OpenFile(Globals.BlankCell, "");
                    }
                }
            }
            else
            {
                Cell2.OpenFile(Globals.BlankCell, "");
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.CheckEnable();
            this.listView1.Items.Clear();
            //foreach (TreeNode subnode in e.Node.Nodes)
            //{
            //    listView1.Items.Add(subnode.Name, subnode.Text, subnode.ImageIndex);
            //}
            treeView1.Focus();
            string fileID = e.Node.Name;
            showCell(fileID);
        }
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Font nodeFont = ((TreeView)(sender)).Font;  //字体
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Node.Bounds);  //背景
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, e.Bounds.Left, e.Bounds.Top + 4);  //前景文字
            }
            else
            {
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 4);  //前景文字
            }
        }
        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
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
        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsmiFind_Click(object sender, EventArgs e)
        {
            this.FindCell();
        }
        private void tsmiNewChildNode_Click(object sender, EventArgs e)
        {
            this.NewFloder(1);
        }
        private void tsmiNewTable_Click(object sender, EventArgs e)
        {
            this.NewTable();
        }
        private void tsmiDelNode_Click(object sender, EventArgs e)
        {
            this.DelNode();
        }
        private void tsmiEditNode_Click(object sender, EventArgs e)
        {
            this.EditNode();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            this.FindCell();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            tsmiClose.PerformClick();
        }
        private void t1_Find_Click(object sender, EventArgs e)
        {
            this.FindCell();
        }
        private void t1_EditNode_Click(object sender, EventArgs e)
        {
            this.EditNode();
        }
        private void t1_DelNode_Click(object sender, EventArgs e)
        {
            this.DelNode();
        }
        private void menuNewChildNode_Click(object sender, EventArgs e)
        {
            this.NewFloder(1);
        }
        private void menuNewTable_Click(object sender, EventArgs e)
        {
            this.NewTable();
        }
        private void menuEditNode_Click(object sender, EventArgs e)
        {
            this.EditNode();
        }
        private void menuDelNode_Click(object sender, EventArgs e)
        {
            TreeNodeEx theNode = (TreeNodeEx)treeView1.SelectedNode;
            if (theNode == null) return;
            this.DelNode();
        }
        private void MenuItemExp_Click(object sender, EventArgs e)
        {
            TreeNodeEx theNode = (TreeNodeEx)treeView1.SelectedNode;
            if (theNode == null || theNode.Text.Trim() == "最近著录过的文件" ||
                (theNode.Parent != null && theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选中有效的节点导出数据！");
                return;
            }
            ERM.UI.frmExpData Frm = new ERM.UI.frmExpData(theNode);
            if (Frm.ShowDialog() == DialogResult.OK)
            {
                TXMessageBoxExtensions.Info("导出数据成功！");
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TreeNode CureNode = treeView1.SelectedNode;
            if (CureNode == null)
            {
                TXMessageBoxExtensions.Info("提示：选择需要导入的节点！");
                return;
            }

            if (CureNode.ImageIndex != 1)
            {
                if (CureNode.ImageIndex == 0 && CureNode.Text.Trim() == "最近著录过的文件")
                {
                    TXMessageBoxExtensions.Info("提示：只能选择文件夹目录或文件目录导入！");
                    return;
                }
                else if (CureNode.ImageIndex == 4)
                {
                    TXMessageBoxExtensions.Info("提示：已组卷的目录不允许编辑！ \n 【温馨提示：如想编辑请在文件登记中撤销登记或在组卷目录移除此文件】");
                    return;
                }
                else if (CureNode.ImageIndex == 3)
                {
                    TXMessageBoxExtensions.Info("提示：只能选择文件夹目录或文件目录导入！");
                    return;
                }
            }

            int DelCount = 0;
            bool check_flg = false;
            CheckFileNodeIsArch(CureNode, ref check_flg, ref DelCount);
            if (check_flg)
            {
                TXMessageBoxExtensions.Info("提示：已组卷 或 保存的目录不允许编辑！ \n 【温馨提示：如想编辑请在文件登记中撤销登记或在组卷目录移除此文件】");
                return;
            }

            if (TXMessageBoxExtensions.Question("提示：确定给节点：[ " + CureNode.Text + " ] 导入信息吗？") != DialogResult.OK)
                return;

            frmImpData Frm = new frmImpData(CureNode, TreeNodeState_flg, 1);
            DialogResult drt = Frm.ShowDialog();
            if (drt == DialogResult.OK)
            {
                treeFactory.ResetDS();
                TXMessageBoxExtensions.Info("导入数据成功！");
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (searchFrm != null)
            {
                try
                {
                    searchFrm.Close();
                }
                catch { }
            }
            ////当前节点
            TreeNodeEx theNode = treeView1.SelectedNode as TreeNodeEx;
            if (theNode == null)
                return;
            if (theNode.ImageIndex == 2 || theNode.ImageIndex == 7)
            {
                this.Cell2.closefile();

                frmCellEdit frm = new frmCellEdit(this, theNode, Mydel);
                frm.ShowDialog();

                showCell(theNode.Name);

                theNode.ImageIndex = (treeFactory.CheckEFileByFileID(theNode.Name, 1) == true) ? 7 : 2;//判断是否有电子文件
                theNode.SelectedImageIndex = theNode.ImageIndex;

                MyFavorites obj = new MyFavorites();
                obj.Write(theNode.Name, theNode.Text);

                if (treeView1.Nodes.Count > 0)
                {
                    if (treeView1.Nodes[0].Text == "最近著录过的文件")
                    {
                        if (theNode.Parent != null && theNode.Parent.Text == "最近著录过的文件")
                        {
                            treeFactory.CreatemyFavoritesNode((TreeNodeEx)treeView1.Nodes[0]);
                            treeFactory.SelectNodeImage(treeView1, theNode.Name);
                        }
                        else
                        {
                            treeFactory.CreatemyFavoritesNode((TreeNodeEx)treeView1.Nodes[0]);
                        }
                    }
                    if (treeView1.Nodes.Count >= 1 && (!(treeView1.Nodes[1].IsExpanded)))
                    {
                        treeView1.Nodes[1].Expand();
                    }
                }
            }
            else if (theNode.ImageIndex == 4)
            {
                TXMessageBoxExtensions.Info("提示：已组卷的目录不允许编辑！ \n 【温馨提示：如想编辑请在文件登记中撤销登记或在组卷目录移除此文件】");
            }
        }
        private bool Printcells(string filepath, string printerName)
        {
            int b = Cell2.OpenFile(filepath, "");
            if (b != 1)
                return false;

            Cell2.PrintSetAlign(1, 1);
            Cell2.PrintSetMargin(5, 5, 5, 5);

            //判断当前页 所有的单元是否只读
            // 如果当前页的所有单元格只读，就不转换PDF
            // 否则 就直接转换PDF
            bool isToPDF_flg = true;
            for (int j = 0; j < Cell2.GetTotalSheets(); j++)
            {
                Cell2.SetCurSheet(j);
                string TittleName = Cell2.GetSheetLabel(j);
                if (TittleName != null &&
                    TittleName.Contains("填表提示"))//
                    continue;

                isToPDF_flg = true;
                for (int iRow = 1; iRow < Cell2.GetRows(j) - 1; iRow++)
                {
                    if (!isToPDF_flg)
                        break;
                    if (Cell2.IsRowHidden(iRow, j) == false && Cell2.GetRowHeight(1, iRow, j) > 10)
                    {
                        for (int iCol = 1; iCol < Cell2.GetCols(j) - 1; iCol++)
                        {
                            if (!isToPDF_flg)
                                break;
                            if (Cell2.IsColHidden(iCol, j) == false && Cell2.GetColWidth(1, iCol, j) > 10)
                            {
                                if (Cell2.GetCellInput(iCol, iRow, j) != 5)
                                {
                                    isToPDF_flg = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                if ((!isToPDF_flg))
                {
                    Cell2.PrintSheet(0, j);
                }
            }
            Cell2.closefile();
            return true;
        }
        void treeView1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent("TreeNodeEx"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckFilter())
                return;
            Point pt;
            TreeNodeEx targeNode;
            pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
            targeNode = (TreeNodeEx)this.treeView1.GetNodeAt(pt);
            if (targeNode == null)
                return;
            TreeNodeEx moveNode = (TreeNodeEx)e.Data.GetData("TreeNodeEx");
            if (moveNode == targeNode)
                return;
            TreeNode pNode = targeNode.Parent;
            if (pNode == null) return;
            if (pNode != moveNode.Parent)
                return;
            moveNode.Remove();
            pNode.Nodes.Insert(targeNode.Index, moveNode);
            List<string> ids = new List<string>();
            for (int i = 0; i < pNode.Nodes.Count; i++)
            {
                ids.Add(pNode.Nodes[i].Name);
            }
            ////移除拖放的节点 
            //ERM.CBLL.CellTreesData.UpdateSeriersFileOrderIndex(ids, Globals.ProjectNO);
            treeView1.SelectedNode = moveNode;
        }
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop((TreeNodeEx)e.Item, DragDropEffects.Move);
            }
        }
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            Point mousePoint = treeView1.PointToClient(new Point(e.X, e.Y));
            TreeNode theNode = treeView1.GetNodeAt(mousePoint);
            if (theNode != null)
            {
                treeView1.AfterSelect -= new TreeViewEventHandler(treeView1_AfterSelect);
                treeView1.SelectedNode = theNode;
                treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
            }
        }

        /// <summary>
        /// 目录当前状态 默认"" 全部
        /// </summary>
        string TreeNodeState_flg = "";
        /// <summary>
        ///显示全部 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAll_Click(object sender, EventArgs e)
        {
            btnFileter.Text = btnAll.Text;
            //treeFactory.GetTree(this.treeView1, true, Globals.ProjectNO, 0, 1);
            treeFactory.GetTree(treeView1, Globals.ProjectNO, "", true, true, 1, true);
            TreeNodeState_flg = "";
        }
        /// <summary>
        /// 未等级文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoCheckIn_Click(object sender, EventArgs e)
        {
            btnFileter.Text = btnNoCheckIn.Text;
            //treeFactory.GetTree(this.treeView1, true, Globals.ProjectNO, 1, 1);
            //treeFactory.HideEmptyNode((TreeNodeEx)treeView1.Nodes[treeView1.Nodes.Count - 1], 1);
            treeFactory.GetTree(treeView1, Globals.ProjectNO, "filestatus=1", true, true, 1, true);
            TreeNodeState_flg = "filestatus=1";
        }
        /// <summary>
        /// 已等级文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHasCheckIn_Click(object sender, EventArgs e)
        {
            btnFileter.Text = btnHasCheckIn.Text;
            //treeFactory.GetTree(this.treeView1, true, Globals.ProjectNO, 2, 1);
            //treeFactory.HideEmptyNode((TreeNodeEx)treeView1.Nodes[treeView1.Nodes.Count - 1], 2);
            treeFactory.GetTree(treeView1, Globals.ProjectNO, "filestatus=2", true, true, 1, true);
            TreeNodeState_flg = "filestatus=2";
        }

        private void menuCopyFile_Click(object sender, EventArgs e)
        {
            TreeNodeEx theNode = treeView1.SelectedNode as TreeNodeEx;
            if (theNode == null)
                return;
            if (theNode.ImageIndex == 2 || theNode.ImageIndex == 7 || theNode.ImageIndex == 4)
            {
                CopyFileID = theNode.Name;//copy
            }
        }
        private void menuPasteFile_Click(object sender, EventArgs e)
        {
            TreeNodeEx theNode = treeView1.SelectedNode as TreeNodeEx;
            if (theNode == null)
                return;
            if (CopyFileID != "")
            {
                BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                //fileBLL.FindByFileID(

                MDL.T_FileList fileMDL = fileBLL.Find(CopyFileID, Globals.ProjectNO);
                string OldFileID = fileMDL.FileID;
                string NewFileID = Guid.NewGuid().ToString().ToUpper();
                fileMDL.FileID = NewFileID;
                fileMDL.ParentID = theNode.Name;
                fileMDL.ArchiveID = "";
                fileMDL.fileStatus = "0";
                fileMDL.wjtm += "_复制";
                fileMDL.gdwj += "_复制";
                fileMDL.OrderIndex = fileBLL.GetMaxOrderIndex(theNode.Name, Globals.ProjectNO) + 1;
                fileBLL.Add(fileMDL);

                BLL.T_CellAndEFile_BLL cellTplBLL = new ERM.BLL.T_CellAndEFile_BLL();
                IList<MDL.T_CellAndEFile> cellTplList = cellTplBLL.FindByFileID(CopyFileID, Globals.ProjectNO);//cellTplBLL.FindByFileID(CopyFileID, Globals.ProjectNO, 0);

                foreach (MDL.T_CellAndEFile obj in cellTplList)
                {
                    string newCellID = Guid.NewGuid().ToString().ToUpper();
                    string fileName = Globals.ProjectPath + obj.filepath;

                    if (System.IO.File.Exists(fileName))
                    {
                        System.IO.File.Copy(fileName, fileName.ToUpper().Replace(obj.CellID.ToUpper(), newCellID), true);
                        obj.filepath = obj.filepath.ToUpper().Replace(obj.CellID.ToUpper(), newCellID);
                    }
                    else
                    {
                        obj.filepath = "";
                    }

                    string fileNamePDF = Globals.ProjectPath + obj.fileTreePath;
                    if (System.IO.File.Exists(fileNamePDF))
                    {
                        System.IO.File.Copy(fileNamePDF, fileNamePDF.ToUpper().Replace(obj.CellID.ToUpper(), newCellID), true);
                        obj.fileTreePath = obj.fileTreePath.ToUpper().Replace(obj.CellID.ToUpper(), newCellID);
                    }
                    else
                    {
                        obj.fileTreePath = "";
                    }

                    obj.CellID = newCellID;
                    obj.FileID = NewFileID;

                    cellTplBLL.Add(obj);
                }

                TreeNodeEx newNode = new TreeNodeEx();
                newNode.Name = fileMDL.FileID;
                newNode.Text = fileMDL.wjtm;
                newNode.ImageIndex = (treeFactory.CheckEFileByFileID(newNode.Name, 1) == true) ? 7 : 2;//判断是否有电子文件;
                newNode.SelectedImageIndex = newNode.ImageIndex;
                newNode.NodeValue = fileMDL.FileID;

                theNode.Nodes.Add(newNode);
            }
            else
            {
                TXMessageBoxExtensions.Info("请先复制!");
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            foreach (TreeNode t1 in treeView1.SelectedNode.Nodes)
            {
                if (t1.Name == listView1.SelectedItems[0].Name)
                {
                    treeView1.SelectedNode = t1;
                    break;
                }
            }
            treeView1_DoubleClick(sender, e);
        }
        private void frmCellMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void Print_All_Click(object sender, EventArgs e)
        {
            PrintAll(0);
        }
        private void Print_Sava_Click(object sender, EventArgs e)
        {
            PrintAll(1);
        }
        private void PrintAll(int type_flg)
        {
            if (treeView1.SelectedNode == null)
            {
                TXMessageBoxExtensions.Info("请选择你要打印的内容");
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("title", typeof(string));
            dt.Columns.Add("filed", typeof(string));

            IList<MDL.T_CellAndEFile> cellList = null;
            if (type_flg == 0)
            {
                CreateCellTemp(ref dt, treeView1.SelectedNode);
                if (dt.Rows.Count == 0)
                {
                    TXMessageBoxExtensions.Info("无任何文件可以打印");
                    return;
                }
                delPrintPDF del = new delPrintPDF(Printcells);
                frmPrintCell frm = new frmPrintCell(dt.DefaultView, del, true);
                frm.ShowDialog();
            }
            else
            {
                cellList =
                    treesData.GetNodeChildren(treeView1.SelectedNode.Name, Globals.ProjectNO, Globals.ProjectPath, type_flg);
                if (cellList != null && cellList.Count > 0)
                {
                    foreach (MDL.T_CellAndEFile cellAndEFile_mdl in cellList)
                    {
                        if (!MyCommon.CheckFillSuffix(cellAndEFile_mdl.filepath, ".cll"))
                            continue;
                        dt.Rows.Add(new object[] { cellAndEFile_mdl.title, Globals.ProjectPath + "\\" + cellAndEFile_mdl.filepath });
                    }
                    if (dt.Rows.Count == 0)
                    {
                        TXMessageBoxExtensions.Info("无任何文件可以打印");
                        return;
                    }
                    delPrintPDF del = new delPrintPDF(Printcells);
                    frmPrintCell frm = new frmPrintCell(dt.DefaultView, del, true);
                    frm.ShowDialog();
                }
                else
                {
                    TXMessageBoxExtensions.Info("无任何文件可以打印");
                }
            }

        }
        private void CreateCellTemp(ref DataTable dt, TreeNode node)
        {
            //查找模板表 如果有记录就添加过来 如果没有就不添加 显示空
            IList<MDL.T_CellFileTemplate> EFTemplate_List =
                (new BLL.T_CellFileTemplate_BLL()).FindByFileID(node.Name);

            if (EFTemplate_List != null && EFTemplate_List.Count > 0)
            {
                foreach (MDL.T_CellFileTemplate c_template in EFTemplate_List)
                {
                    if (!MyCommon.CheckFillSuffix(c_template.filepath, ".cll"))
                        continue;
                    dt.Rows.Add(new object[] { c_template.title, Application.StartupPath + "\\Template" + c_template.filepath });
                }
            }
            foreach (TreeNode node_temp in node.Nodes)
            {
                CreateCellTemp(ref dt, node_temp);
            }
        }
        #endregion

        #region 自定义函数
        /// <summary>
        /// 初始化详细过程
        /// </summary>
        public void Init()
        {
            try
            {
                Cell2.WorkbookReadonly = true;
                this.Text = "工程资料用表 - " + Globals.Projectname;  //窗体标题
                tssLabel1.Text = Globals.NormalStatus;                          //状态栏:就绪
                tssLabel2.Text = Globals.AppTitle;                              //状态栏:应用程序标题
                tssLabel3.Text = "当前用户：" + Globals.LoginUser;              //状态栏:当前用户
                ImageList imageList1 = treeFactory.CreateTreeImageList();
                treeView1.ImageList = imageList1;
                treeFactory.GetTree(treeView1, Globals.ProjectNO, "", true, true, 1, true);
                Cell2.OpenFile(Globals.BlankCell, "");
                listView1.LargeImageList = imageList1;
                listView1.SmallImageList = imageList1;
            }
            catch
            {
            }
        }
        public bool PrintCellToPDF(string fileName, string id)
        {
            //Cell2.OpenFile(fileName, "");
            //System.Collections.ArrayList fileList = new System.Collections.ArrayList();
            //Cell2.SetPrinter(PrinterOperate.UsePrinterName);
            //Cell2.PrintPara(1, 1, 0, 0); //单色打印
            //for (int j = 0; j < Cell2.GetTotalSheets(); j++)
            //{
            //    string TittleName = Cell2.GetSheetLabel(j);
            //    if (!TittleName.Contains(Globals.Descriptive))
            //    {
            //        fileList.Add(tempFile + j.ToString() + ".pdf");
            //        outFile = tempFile + j.ToString() + ".pdf";
            //        NewPrint();
            //        oPrinterMonitor.OnPrinterInit += new _IPrinterMonitorEvents_OnPrinterInitEventHandler(oPrinterMonitor_OnPrinterInit);
            //        Cell2.PrintSheet(0, j);
            //        oPrinterMonitor.OnPrinterInit -= new _IPrinterMonitorEvents_OnPrinterInitEventHandler(oPrinterMonitor_OnPrinterInit);
            //    }
            //}
            //Cell2.closefile();
            //string[] FileName = new string[fileList.Count];
            //for (int i = 0; i < fileList.Count; i++)
            //{
            //    FileName[i] = fileList[i].ToString();
            //}
            //PDFProcessor processor = new PDFProcessor();
            //processor.Initialize("Digipower PDF Printer");
            //processor.LicenseKey = Globals.LicenseKey;
            //try
            //{
            //    processor.MergeBatch(FileName, fileName.Replace(@".cll", @".pdf"));
            //    MyCommon.DeleteAndCreateEmptyDirectory(tempFile);
            //    treesData.SH(id, 1, Globals.ProjectNO);
            //    return true;
            //}
            //catch
            //{
            //    MyCommon.DeleteAndCreateEmptyDirectory(tempFile);
            //    return false;
            //}
            return false;
        }

        /// <summary>
        /// 打印调的方法
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="showmsg"></param>
        //public void Test(DataTable dt, bool showmsg)
        //{
        //    if (Globals.SH == 0)
        //    {
        //        TXMessageBoxExtensions.Info("您没有提交权限！");
        //        return;
        //    }
        //    if (dt.Rows.Count > 0)
        //    {
        //        string CurPrinterName = PrinterOperate.GetDefaultPrinterName();
        //        if (CurPrinterName != PrinterOperate.UsePrinterName)//如果当前打印机不是EASYPDF就要设置
        //        {
        //            PrinterOperate.SetPrinter(PrinterOperate.UsePrinterName);
        //        }
        //        frmRefreshHead frm = new frmRefreshHead(Mydel, dt);
        //        frm.SetTitle = "提交中…";
        //        frm.SetMsg = "正在处理数据，请稍候…";
        //        if (frm.ShowDialog() != DialogResult.OK)
        //        {
        //            if (!string.IsNullOrEmpty(frm.ErrorMsg))
        //            {
        //                TXMessageBoxExtensions.Info(frm.ErrorMsg);
        //            }
        //        }
        //        else
        //        {
        //            if (showmsg)
        //                TXMessageBoxExtensions.Info("提交完成！");
        //        }
        //        if (CurPrinterName != PrinterOperate.UsePrinterName)
        //        {
        //            PrinterOperate.SetPrinter(CurPrinterName);
        //        }//设置打印机后，设回来
        //    }
        //    else
        //    {
        //        TXMessageBoxExtensions.Info("没有找到需要提交的文件！");
        //    }
        //}
        /// <summary>
        /// 新建目录，0为同级，1为子级
        /// </summary>
        /// <param name="level">0为同级，1为子级</param>
        private void NewFloder(int level)
        {
            try
            {
                TreeNodeEx parentNode = (TreeNodeEx)treeView1.SelectedNode;
                if (parentNode == null) return;
                TreeNodeEx tempNode = null;//传个空值用
                frmMainGetTempletFromStandard frm = new frmMainGetTempletFromStandard(tempNode, false, parentNode);
                DialogResult ret = frm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    string Title = MyCommon.ToSqlString(frm.StrTitle.Trim());
                    int orderindex = (new BLL.T_FileList_BLL()).GetMaxOrderIndex(parentNode.Name, Globals.ProjectNO);
                    string ProjectNO = Globals.ProjectNO;

                    fileModel = new ERM.MDL.T_FileList();
                    fileModel.gdwj = Title;
                    fileModel.wjtm = Title;
                    fileModel.FileID = Guid.NewGuid().ToString();
                    fileModel.ParentID = parentNode.Name;
                    fileModel.ProjectNO = ProjectNO;
                    fileModel.OrderIndex = orderindex + 1;
                    fileModel.fileStatus = "0";
                    fileModel.FL = 0;

                    BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                    fileModel.isvisible = 0;
                    fileBLL.Add(fileModel);

                    TreeNodeEx newNode = new TreeNodeEx();
                    newNode.Name = fileModel.FileID;
                    newNode.Text = fileModel.wjtm;
                    newNode.ImageIndex = 1;
                    newNode.SelectedImageIndex = 1;
                    parentNode.Nodes.Add(newNode);
                }
            }
            catch
            {
            }
        }
        private void NewTable()
        {
            try
            {
                TreeNodeEx theNode = (TreeNodeEx)treeView1.SelectedNode;
                if (theNode == null) return;
                TreeNodeEx tempNode = null;//传个空值进去
                frmMainGetTempletFromStandard frm = new frmMainGetTempletFromStandard(tempNode, true, theNode);
                DialogResult ret = frm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    //2011-3-18 去掉表格代码 
                    //AddNewNode("", frm.txtLocalPath.Text.ToLower(), MyCommon.ToSqlString(frm.txtCodeno.Text.Trim()), MyCommon.ToSqlString(frm.StrTitle.Trim()), Convert.ToInt16(frm.txtys.Text));
                    AddNewNode("", frm.txtLocalPath.Text.ToLower(), MyCommon.ToSqlString(frm.StrTitle.Trim()));
                }
            }
            catch (Exception ex)
            {
                ////TXMessageBoxExtensions.InfoErrors(ex);
            }
        }
        private void AddNewNode(string Action, string txtLocalPath, string StrTitle)
        {
            TreeNodeEx theNode = (TreeNodeEx)treeView1.SelectedNode;

            int orderindex = (new BLL.T_CellAndEFile_BLL()).GetMaxOrderIndex(theNode.Name, Globals.ProjectNO);//treesData.GetNextIndex(theNode.Name, Globals.ProjectNO);
            string ParentID = theNode.Name;
            string Filepath = txtLocalPath;
            string Title = StrTitle;
            string ProjectNO = Globals.ProjectNO;

            fileModel = new ERM.MDL.T_FileList();
            fileModel.gdwj = Title;
            fileModel.wjtm = Title;
            fileModel.FileID = Guid.NewGuid().ToString();
            fileModel.ParentID = ParentID;
            fileModel.ProjectNO = ProjectNO;
            fileModel.OrderIndex = (new BLL.T_FileList_BLL()).GetMaxOrderIndex(ParentID, Globals.ProjectNO) + 1;
            fileModel.isvisible = 1;
            fileModel.fileStatus = "0";
            fileModel.FL = 0;

            (new BLL.T_FileList_BLL()).Add(fileModel);

            MDL.T_CellAndEFile cellMode = new ERM.MDL.T_CellAndEFile();
            cellMode.CellID = Guid.NewGuid().ToString();

            if (!System.IO.File.Exists(Filepath))
            {
                TXMessageBoxExtensions.Info("文件不存在！");
                return;
            }
            System.IO.File.Copy(Filepath, Globals.ProjectPath + "ODOC\\" + cellMode.CellID + ".cll", true);

            cellMode.filepath = "ODOC\\" + cellMode.CellID + ".cll";

            cellMode.orderindex = orderindex + 1;
            cellMode.FileID = fileModel.FileID;
            cellMode.isvisible = 1;
            cellMode.EFileType = true;//电子文件类型，0=false 系统的，-1=true 用户上传的
            cellMode.ProjectNO = ProjectNO;
            cellMode.title = Title;
            cellBLL.Add(cellMode);

            TreeNodeEx newNode = new TreeNodeEx();
            newNode.Name = cellMode.FileID;
            newNode.ImageIndex = 2;
            newNode.SelectedImageIndex = 2;
            newNode.Text = cellMode.title;

            theNode.Nodes.Add(newNode);
            theNode.Expand();
        }
        /// <summary>
        /// 修改节点属性
        /// </summary>
        private void EditNode()
        {
            try
            {
                TreeNodeEx theNode = (TreeNodeEx)treeView1.SelectedNode;
                if (theNode == null) return;
                if (theNode.Parent == null) return;

                if (theNode.ImageIndex == 4)
                {
                    TXMessageBoxExtensions.Info("提示：已经组卷的文件不允许修改！");
                    return;
                }

                frmMainGetTempletFromStandard frm = new frmMainGetTempletFromStandard(theNode, (theNode.ImageIndex == 2 || theNode.ImageIndex == 7), (TreeNodeEx)theNode.Parent);
                frm.Text = "修改";
                DialogResult ret = frm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    if (GetTrueText(theNode.Text) == frm.StrTitle.Trim())
                    {
                        return;
                    }
                    string title = MyCommon.ToSqlString(frm.StrTitle.Trim());
                    theNode.Text = title;
                    MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(theNode.Name, Globals.ProjectNO);
                    if (fileMDL != null)
                    {
                        fileMDL.wjtm = title;
                        (new BLL.T_FileList_BLL()).Update(fileMDL);
                    }
                }
            }
            catch (Exception ex)
            {
                ////TXMessageBoxExtensions.InfoErrors(ex);
            }
        }
        private string GetTrueText(string curText)
        {
            return curText.Remove(0, curText.IndexOf(']') + 1).Replace("*", "");
        }
        /// <summary>
        /// 删除当前节点
        /// </summary>
        private void DelNode()
        {
            frm2PDFProgressMsg dfmsg = null;
            try
            {
                TreeNodeEx theNode = (TreeNodeEx)treeView1.SelectedNode;
                if (theNode == null) return;
                TreeNodeEx parentNode = (TreeNodeEx)theNode.Parent;
                if (parentNode == null)
                    return;
                if (parentNode.Tag != null && parentNode.Tag.ToString() == "")
                {
                    MyFavorites myFav1 = new MyFavorites();
                    myFav1.Delete(theNode.Name);
                    theNode.Remove();
                    return;
                }

                int DelCount = 0;
                if (theNode.ImageIndex == 1)
                {
                    bool check_flg = false;
                    CheckFileNodeIsArch(theNode, ref check_flg, ref DelCount);
                    if (check_flg)
                    {
                        TXMessageBoxExtensions.Info("提示：已经组卷的文件目录不允许修改！");
                        return;
                    }
                }
                DialogResult ret = TXMessageBoxExtensions.Question("确定删除 [" + GetTrueText(theNode.Text) + "] 及其子节点？");
                if (ret == DialogResult.OK)
                {
                    this.Enabled = false;

                    MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(theNode.Name, Globals.ProjectNO);
                    if (fileMDL != null)
                    {
                        if (int.Parse(fileMDL.fileStatus) > 3)
                        {
                            TXMessageBoxExtensions.Info("该文件已经 登记或组卷，无法进行删除操作！");
                            this.Enabled = true;
                            return;
                        }
                        dfmsg = new frm2PDFProgressMsg();
                        if (theNode.ImageIndex == 1)
                        {
                            dfmsg.progressBar1.Maximum = DelCount;
                            dfmsg.label2.Text = "正在删除：0/" + DelCount.ToString();
                            dfmsg.Show();
                            Application.DoEvents();
                        }
                        else
                        {
                            dfmsg.progressBar1.Maximum = 2;
                            dfmsg.progressBar1.Value = 1;
                            dfmsg.label2.Text = "正在删除：1/1";
                            dfmsg.Show();
                            Application.DoEvents();
                        }

                        DeleteRecycle(theNode.Name, ref dfmsg);
                        theNode.Remove();
                        CheckEnable();
                        tssLabel1.Text = Globals.NormalStatus;
                    }
                    this.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                if (dfmsg != null)
                {
                    dfmsg.Dispose();
                    dfmsg.Close();
                }
            }
            finally
            {
                this.Enabled = true;
                if (dfmsg != null)
                {
                    dfmsg.Dispose();
                    dfmsg.Close();
                }
            }
        }

        /// <summary>
        /// 判断目录下是否有目录已经组卷
        /// </summary>
        /// <param name="SelectTreeNode">文件夹节点对象</param>
        /// <param name="check_flg">判断标识：传入false 返回true表示有组卷 false则没有组卷</param>
        private void CheckFileNodeIsArch(TreeNode SelectTreeNode, ref bool check_flg, ref int NodeCount)
        {
            if (!check_flg)
            {
                foreach (TreeNode cure_node in SelectTreeNode.Nodes)
                {
                    NodeCount++;
                    if (cure_node.Nodes != null && cure_node.Nodes.Count > 0)
                        CheckFileNodeIsArch(cure_node, ref check_flg, ref NodeCount);

                    MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(cure_node.Name, Globals.ProjectNO);
                    if (fileMDL != null)
                    {
                        if (int.Parse(fileMDL.fileStatus) > 3)
                        {
                            check_flg = true;
                            break;
                        }
                    }
                }
            }
        }
        private void DeleteRecycle(string FileID, ref frm2PDFProgressMsg frmMsg)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            IList<MDL.T_FileList> fileList = fileBLL.FindByParentID(FileID, Globals.ProjectNO);
            foreach (MDL.T_FileList obj in fileList)
            {
                DeleteRecycle(obj.FileID, ref frmMsg);
            }

            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByFileID(FileID, Globals.ProjectNO, 0);
            foreach (MDL.T_CellAndEFile obj in cellList)
            {
                if (System.IO.File.Exists(Globals.ProjectPath + obj.filepath))
                {
                    System.IO.File.Delete(Globals.ProjectPath + obj.filepath);
                }
                if (System.IO.File.Exists(Globals.ProjectPath + obj.fileTreePath))
                {
                    System.IO.File.Delete(Globals.ProjectPath + obj.fileTreePath);
                }
                cellBLL.Delete(obj.CellID, Globals.ProjectNO);
            }

            fileBLL.Delete(FileID, Globals.ProjectNO);

            if (frmMsg.progressBar1.Value < frmMsg.progressBar1.Maximum)
                frmMsg.progressBar1.Value++;
            frmMsg.label2.Text = "正在删除：" + frmMsg.progressBar1.Value.ToString() + "/" + frmMsg.progressBar1.Maximum.ToString();
            Application.DoEvents();
        }

        /// <summary>
        /// 检查某个节点有没有已经提交的表格，有的话不允许删除
        /// </summary>
        private string StrCheck = "";
        private void CheckCanDel(TreeNodeEx node)
        {
            if (node.ImageIndex == 2 || node.ImageIndex == 7)
                StrCheck += "'" + node.Name + "',";
            else
            {
                TreeNodeCollection nodes = node.Nodes;
                for (int i = 0; i < nodes.Count; i++)
                {
                    CheckCanDel((TreeNodeEx)nodes[i]);
                }
            }
        }
        /// <summary>
        /// 查找表格
        /// </summary>
        private void FindCell()
        {
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
        /// 用来被查找子窗口调用、进行查询的具体方法
        /// </summary>
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
                TXMessageBoxExtensions.Info("没有找到相关资料！");
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
                treeFactory.SelectNode(treeView1, obj3.FileID);
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
        /// <summary>
        /// 按钮、菜单等能否点击的判断
        /// </summary>
        private void CheckEnable()
        {
            tsmiNew.Enabled = false;  //新增
            tsmiNewChildNode.Enabled = false;  //新增子目录
            tsmiNewTable.Enabled = false;  //新增模板
            tsmiEditNode.Enabled = false;  //修改节点属性
            tsmiDelNode.Enabled = false;  //删除当前节点
            menuNewChildNode.Enabled = false;  //新增子目录
            menuNewTable.Enabled = false;  //新增模板表格
            menuEditNode.Enabled = false;　　//修改节点属性
            menuDelNode.Enabled = false;　　//删除当前节点
            t1_EditNode.Enabled = false;  //修改节点属性
            t1_DelNode.Enabled = false;  //删除节点
            TreeNode node = treeView1.SelectedNode;
            if (node != null)
            {
                menuCopyFile.Enabled = true;
                menuPasteFile.Enabled = true;
                tsMenuInput.Enabled = true;

                if (node.ImageIndex == 0)
                {
                    //如果是根节点，注意：不允许删除根节点
                    if (node.Text.Trim() == "最近著录过的文件")
                    {
                        tsMenuInput.Enabled = false;
                        menuPasteFile.Enabled = false;//粘贴
                    }
                    else
                    {
                        menuNewChildNode.Enabled = true;  //新增子目录
                        tsmiNew.Enabled = true; //新增
                        tsmiNewChildNode.Enabled = true;  //新增子目录
                    }
                    menuCopyFile.Enabled = false;//复制
                }
                else if (node.ImageIndex == 1)
                {
                    //如果是文件夹
                    tsmiNew.Enabled = true; //新增
                    tsmiNewChildNode.Enabled = true;  //新增子目录
                    tsmiNewTable.Enabled = true; //新增模板表格
                    tsmiEditNode.Enabled = true; //修改节点属性
                    tsmiDelNode.Enabled = true;  //删除节点
                    t1_EditNode.Enabled = true;  //修改节点属性
                    t1_DelNode.Enabled = true;  //删除节点
                    menuNewChildNode.Enabled = true;  //新增子目录
                    menuNewTable.Enabled = true;  //新增模板表格
                    menuEditNode.Enabled = true;　　//修改节点属性
                    menuDelNode.Enabled = true;　　//删除节点
                    menuCopyFile.Enabled = false;
                    menuPasteFile.Enabled = true;
                }
                else
                {
                    if (node.Parent != null && node.Parent.Text.Trim() == "最近著录过的文件")
                    {

                    }
                    else
                    {
                        tsmiEditNode.Enabled = true; //修改节点属性
                        tsmiDelNode.Enabled = true;  //删除节点
                        t1_EditNode.Enabled = true;  //修改节点属性
                        t1_DelNode.Enabled = true;  //删除节点
                        menuEditNode.Enabled = true;　　//修改节点属性
                        menuDelNode.Enabled = true;　　//删除节点                        
                    }
                    menuPasteFile.Enabled = false;
                }
            }
        }
        private bool CheckFilter()
        {
            return true;
        }
        #endregion

        private void tsb_FL_Click(object sender, EventArgs e)
        {
            if (searchFrm != null)
            {
                try
                {
                    searchFrm.Close();
                }
                catch { }
            }
            ////当前节点
            TreeNodeEx theNode = treeView1.SelectedNode as TreeNodeEx;
            if (theNode == null)
                return;
            if (theNode.ImageIndex == 2 || theNode.ImageIndex == 7)
            {
                frmTemplateInfo frm_TemplateInfo = new frmTemplateInfo(theNode.Name);
                frm_TemplateInfo.ShowDialog();
            }
        }

        private void Cell2_DropCellSelected(object sender, AxCELL50Lib._DCell2000Events_DropCellSelectedEvent e)
        {

        }
    }
}
