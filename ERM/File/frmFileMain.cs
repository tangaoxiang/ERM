using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
//using BCL.easyPDF6.Interop.EasyPDFPrinter.Digipower;
//using BCL.easyPDF6.Interop.EasyPDFProcessor.Digipower;
using ERM.MDL;
using ERM.CBLL;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using System.Xml;
using ERM.UI.CellEdit;
using TX.Framework.WindowUI.Forms;
using ERM.UI.Controls;

namespace ERM.UI
{
    public partial class frmFileMain : Skin_DevEX
    {
        frmMainSearch searchFrm;
        string MovedCellPath = Globals.ODOCPath + "\\";
        string PDFPath = Globals.SPDFPath + "\\";
        string MregeredPDFPath = Globals.MPDFPath + "\\";
        string projectPath = Globals.ProjectPath + "\\";
        string PDFTemp = Globals.PDFTemp + "\\";
        string ReportPath = Application.StartupPath + "\\Reports\\regist.pdf";

        ImageList imagelist = new ImageList();
        int TreeOrList = 0;

        ERM.CBLL.PrintFinalArchive finalArchive = new ERM.CBLL.PrintFinalArchive();

        private Form _parentForm;
        public TreeFactory treeFactory = new TreeFactory();
        bool IsSource = false;
        int isdy = 3;
        View DefaultListView = View.SmallIcon;
        public frmFileMain(Form parentForm)
        {
            InitializeComponent();
            CreateObjDic();
            this._parentForm = parentForm;
            this.fileBaseInfo = new FileRegistInfo();
            this.fileBaseInfo.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(fileBaseInfo);
            drpFileStatus.TextChanged += drpFileStatus_TextChanged;

        }

        private void drpFileStatus_TextChanged(object sender, EventArgs e)
        {

        }
        private void frmFileAdd_Load(object sender, EventArgs e)
        {
            this.Text = "文件登记 - " + Globals.Projectname;

            treeFactory.GetTree(treeRight, Globals.ProjectNO, " IsUseDefined = 0 ", true, true, 2, true, 0);
            splitContainer3.Panel2Collapsed = true;
            treeRight.ImageList = treeFactory.CreateTreeImageList();
            treeRight.Width = MyCommon.ToInt(Globals.TreeWidth);
            treeRight.HideSelection = false;
            //PDF 初始化信息

            //this.axpdfInterface1.ShowToolbarButton(2, 0);
            //this.axpdfInterface1.ShowToolbarButton(23, 0);
            //this.axpdfInterface1.ShowToolbarButton(24, 0);
            //this.axpdfInterface1.ShowToolbarButton(25, 0);
            //this.axpdfInterface1.ShowToolbarButton(26, 0);
            //this.axpdfInterface1.ShowToolbarButton(27, 0);
            //this.axpdfInterface1.ShowToolbarButton(28, 0);

            axSPApplication1.Options.TabBarVisible = false;
            axSPApplication1.CommandBars[0].Visible = false;

            tbtnShowFileList_Click(null, null);//显示资源管理器
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
            //if (axpdfInterface1.FileName != null && axpdfInterface1.FileName.Length > 0)
            //    axpdfInterface1.CloseFile();

            treeRight_BeforeSelect(null, null);//启用快速著录是保存选择的节点信息

            this._parentForm.Show();　//显示父窗体
            this._parentForm.Activate();//激活父窗体
        }

        /// <summary>
        /// 窗体关闭之后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFileMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
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

                    if (cure_node.ImageIndex == 4)
                    {
                        check_flg = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelete_Click(object sender, EventArgs e)
        {
            TreeNodeEx theNode = (TreeNodeEx)treeRight.SelectedNode;

            if (theNode == null || theNode.Level == 0 || theNode.Text == "最近著录过的文件" ||
                (theNode.Parent != null && theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的目录进行删除！");
                return;
            }

            if (theNode.ImageIndex == 2 || theNode.ImageIndex == 3 ||
                theNode.ImageIndex == 5 || theNode.ImageIndex == 4 || theNode.ImageIndex == 7)
            {
                //判断文件状态 已经组卷的文件不允许修改
                string fileID = string.Empty;
                if (theNode.ImageIndex == 2 || theNode.ImageIndex == 5 || theNode.ImageIndex == 4 || theNode.ImageIndex == 7)
                    fileID = theNode.Name;
                else
                    fileID = theNode.Parent.Name;

                MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fileID, Globals.ProjectNO);
                if (MyCommon.ToInt(fileMDL1.IsUseDefined) == 0)
                {
                    TXMessageBoxExtensions.Info("提示：系统目录不能进行删除！");
                    return;
                }
                if (fileMDL1.fileStatus == "6")
                {
                    TXMessageBoxExtensions.Info("提示：已经组卷的文件不允许修改！");
                    return;
                }
            }
            else
            {
                DataTable dtisdefined = (new BLL.T_FileList_BLL()).GetFileByGDID(Globals.ProjectNO, theNode.Name);

                if (dtisdefined.Rows.Count > 0)
                {
                    if (MyCommon.ToInt(dtisdefined.Rows[0]["IsUseDefined"]) == 0)
                    {
                        TXMessageBoxExtensions.Info("提示：系统目录不能进行删除！");
                        return;
                    }
                }
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

            this.Enabled = false;
            string showText = "[" + this.treeRight.SelectedNode.Text.Substring(this.treeRight.SelectedNode.Text.LastIndexOf("]") + 1) + "]";
            if (theNode.ImageIndex == 1)
            {
                showText += " 文件夹";
            }
            else if (theNode.ImageIndex == 3)
            {
                showText += " 电子文件";
            }
            else
            {
                showText += " 节点";
            }
            frm2PDFProgressMsg dfmsg = null;
            try
            {
                if (TXMessageBoxExtensions.Question("提示：确定要删除 " + showText + "吗？") == DialogResult.OK)
                {
                    //移除电子文件        
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();

                    if (theNode.ImageIndex == 1 || theNode.ImageIndex == 2 ||
                        theNode.ImageIndex == 5 || theNode.ImageIndex == 7)
                    {
                        dfmsg = new frm2PDFProgressMsg();
                        dfmsg.progressBar1.Maximum = DelCount;
                        dfmsg.label2.Text = "正在删除：0/" + DelCount.ToString();
                        dfmsg.Show();
                        Application.DoEvents();
                        DeleteTemplet(ref dfmsg);//删除文件
                    }
                    else if (theNode.ImageIndex == 3)
                    {
                        BLL.T_FileList_BLL fileList_bll = (new BLL.T_FileList_BLL());
                        MDL.T_FileList fileList_mdl =
                            fileList_bll.Find(theNode.Parent.Name, Globals.ProjectNO);
                        //判断是否签过章
                        using (ConvertCell2PDF cl = new ConvertCell2PDF())
                        {
                            if (cl.GetPDFKEYCount(Globals.ProjectPath + fileList_mdl.filepath) > 0)
                            {
                                if (TXMessageBoxExtensions.Question("提示：此文件 " + fileList_mdl.wjtm + " \n 已签过章，如果删除，此前的签章就会失效，确定继续操作吗？") != DialogResult.OK)
                                    return;
                            }
                        }

                        dfmsg = new frm2PDFProgressMsg();
                        dfmsg.progressBar1.Maximum = 2;
                        dfmsg.progressBar1.Value = 1;
                        dfmsg.label2.Text = "正在删除：1/1";
                        dfmsg.Show();
                        Application.DoEvents();

                        BLL.T_CellAndEFile_BLL EFile_BLL = new BLL.T_CellAndEFile_BLL();
                        MDL.T_CellAndEFile cellMDL = EFile_BLL.Find(theNode.Name, Globals.ProjectNO);

                        if (cellMDL != null &&
                                System.IO.File.Exists(Globals.ProjectPath + cellMDL.filepath)
                                && !string.IsNullOrWhiteSpace(cellMDL.filepath)
                                && cellMDL.filepath.EndsWith(".cll"))//原件
                        {
                            cellMDL.GdFileID = "";
                            EFile_BLL.Update(cellMDL);
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

                            MyCommon.DeleteOldEfile(theNode.Name, Globals.ProjectNO); //删除电子文件对应的原文信息 
                            EFile_BLL.Delete(theNode.Name, Globals.ProjectNO);
                        }

                        fileList_mdl.selected = 1;
                        fileList_bll.Update(fileList_mdl);

                        UpdatePDFView((TreeNodeEx)theNode.Parent);

                        MDL.T_FileList showfileList_mdl = fileList_bll.Find(theNode.Parent.Name, Globals.ProjectNO);
                        bool update_flg = this.fileBaseInfo.isUpdateInfo_flg;
                        this.fileBaseInfo.sl.Text = MyCommon.ToInt(showfileList_mdl.sl).ToString();//文字张
                        // this.fileBaseInfo.wzz.Text = MyCommon.ToInt(showfileList_mdl.wzz).ToString();// 照片张 注：图样张=图纸张+底图张
                        this.fileBaseInfo.tzz.Text = MyCommon.ToInt(showfileList_mdl.tzz).ToString();//图纸张
                        this.fileBaseInfo.dtz.Text = MyCommon.ToInt(showfileList_mdl.dtz).ToString();//底图张
                        //this.fileBaseInfo.dw.Text = MyCommon.ToInt(showfileList_mdl.dw).ToString(); //注：图样张=照片张+底片张
                        this.fileBaseInfo.zpz.Text = MyCommon.ToInt(showfileList_mdl.zpz).ToString();//照片张  
                        this.fileBaseInfo.dpz.Text = MyCommon.ToInt(showfileList_mdl.dpz).ToString();//底片张
                        this.fileBaseInfo.isUpdateInfo_flg = update_flg;

                        //统计电子文件数
                        TreeNodeEx theNodeParentNode = (TreeNodeEx)theNode.Parent;
                        treeFactory.GetCellFileNodesCount(theNodeParentNode, true);

                        if (theNode.Parent.ImageIndex == 2 || theNode.Parent.ImageIndex == 7)
                            theNode.Parent.ImageIndex = (treeFactory.CheckEFileByFileID(theNode.Parent.Name, 2) == true) ? 7 : 2;//判断是否有电子文件
                        theNode.Parent.SelectedImageIndex = theNode.Parent.ImageIndex;
                    }

                    if (treeRight.SelectedNode.Parent != null)
                    {
                        treeRight.SelectedNode.Parent.Nodes.Remove(theNode);
                    }
                }
                this.Enabled = true;
            }
            catch
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
        /// 删除模版
        /// </summary>
        private void DeleteTemplet(ref frm2PDFProgressMsg frmMsg)
        {
            TreeNodeEx Node = (TreeNodeEx)treeRight.SelectedNode;
            if (Node != null)
            {
                DeleteFileNode(Node, ref frmMsg);
            }
        }
        private void DeleteFileNode(TreeNodeEx node, ref frm2PDFProgressMsg frmMsg)
        {
            foreach (TreeNodeEx obj in node.Nodes)
            {
                DeleteFileNode(obj, ref frmMsg);
            }
            MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(node.Name, Globals.ProjectNO);
            if (fileMDL != null)
            {
                if (System.IO.File.Exists(Globals.ProjectPath + fileMDL.filepath))
                {
                    System.IO.File.Delete(Globals.ProjectPath + fileMDL.filepath);
                }
            }
            IList<MDL.T_CellAndEFile> cellList =
                (new BLL.T_CellAndEFile_BLL()).FindByGdFileID(node.Name, Globals.ProjectNO);
            foreach (MDL.T_CellAndEFile cellMDL in cellList)
            {
                if (cellMDL != null &&
                    System.IO.File.Exists(Globals.ProjectPath + cellMDL.filepath)
                    && !string.IsNullOrWhiteSpace(cellMDL.filepath)
                    && cellMDL.filepath.EndsWith(".cll"))//原件
                {
                    cellMDL.GdFileID = "";
                    (new BLL.T_CellAndEFile_BLL()).Update(cellMDL);
                }
                else
                {
                    if (System.IO.File.Exists(Globals.ProjectPath + cellMDL.filepath))
                    {
                        //    if (System.IO.Path.GetExtension(Globals.ProjectPath + cellMDL.filepath).ToLower() == ".cll")
                        //        continue;
                        System.IO.File.Delete(Globals.ProjectPath + cellMDL.filepath);
                    }
                    if (System.IO.File.Exists(Globals.ProjectPath + cellMDL.fileTreePath))
                    {
                        System.IO.File.Delete(Globals.ProjectPath + cellMDL.fileTreePath);
                    }
                    (new BLL.T_CellAndEFile_BLL()).Delete(cellMDL.CellID, Globals.ProjectNO);
                }
            }
            (new BLL.T_FileList_BLL()).Delete(node.Name, Globals.ProjectNO);
            (new BLL.T_FileList_BLL()).DeleteGdList(node.Name);
            if (frmMsg.progressBar1.Value < frmMsg.progressBar1.Maximum)
                frmMsg.progressBar1.Value++;
            frmMsg.label2.Text = "正在删除：" + frmMsg.progressBar1.Value.ToString() + "/" + frmMsg.progressBar1.Maximum.ToString();
            Application.DoEvents();
        }
        /// <summary>
        /// 添加文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAddTemplate_Click(object sender, EventArgs e)
        {
            AddTemplet(true);
        }
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAddTemlateFile_Click(object sender, EventArgs e)
        {
            AddTemplet(false);
        }
        /// <summary>
        /// 添加模版
        /// </summary>
        /// <param name="fileOrFlord_flg">boo:文件夹或文件 (true文件夹 false文件)</param>
        private void AddTemplet(bool fileOrFlord_flg)
        {
            TreeNodeEx FileNode = new TreeNodeEx();
            FileNode = (TreeNodeEx)this.treeRight.SelectedNode;
            if (FileNode == null) { TXMessageBoxExtensions.Info("请选中有效目录进行添加节点！"); return; }
            if (FileNode != null &&
                (FileNode.ImageIndex == 1
                || (FileNode.ImageIndex == 0 && FileNode.Text != "最近著录过的文件")) &&
                (FileNode.Level == 0 && fileOrFlord_flg) ||
                (FileNode.Level == 1 && !fileOrFlord_flg))
            {
                frmAddTemplet frm = new frmAddTemplet(FileNode, _parentForm, treeFactory, fileOrFlord_flg);
                DialogResult return_dialog = frm.ShowDialog();
                if (return_dialog == DialogResult.OK)
                {
                    int OrderIndex = (new BLL.T_FileList_BLL()).GetMaxGdFileOrderIndex(FileNode.Name, Globals.ProjectNO);
                    MDL.T_FileList fileMDL = new T_FileList();
                    fileMDL.FileID = Guid.NewGuid().ToString();
                    fileMDL.ProjectNO = Globals.ProjectNO;
                    fileMDL.wjtm = frm.txtReName.Text.Trim();
                    fileMDL.OrderIndex = OrderIndex + 1;
                    fileMDL.fileStatus = "0";
                    fileMDL.FL = 1;
                    fileMDL.IsUseDefined = 1;
                    //fileMDL.ProjectCategory = (new BLL.T_FileList_BLL()).FindByProjectNO(Globals.ProjectNO).ProjectCategory;
                    if (!fileOrFlord_flg)
                    {
                        fileMDL.ParentID = FileNode.Name;
                        fileMDL.GDID = FileNode.Name;
                    }
                    else
                    {
                        fileMDL.ParentID = (new BLL.T_FileList_BLL()).FindBywjtm(FileNode.Text)[0].FileID;
                    }

                    TreeNodeEx newNode = new TreeNodeEx();
                    newNode.Name = fileMDL.FileID;
                    newNode.Text = fileMDL.wjtm;

                    if (frm.checkBox1.Checked == true)
                    {
                        newNode.ImageIndex = 1;
                        newNode.SelectedImageIndex = 1;
                        fileMDL.isvisible = 1;
                    }
                    else
                    {
                        newNode.ImageIndex = 2;
                        newNode.SelectedImageIndex = 2;
                        fileMDL.isvisible = 1;
                        treeFactory.GetCellFileNodesCount(newNode, true);
                    }
                    BLL.T_FileList_BLL FileList_BLL = new BLL.T_FileList_BLL();
                    fileMDL.GdFileOrderIndex =
                        FileList_BLL.GetMaxGdFileOrderIndex(FileNode.Name, Globals.ProjectNO) + 1;
                    FileList_BLL.Add(fileMDL);

                    if (fileOrFlord_flg)//T_FileListTemplate T_GdListTemplate T_GdList 
                    {
                        int OrderIndexTmp = FileList_BLL.GetMaxTemplateOrderIndex();
                        if (OrderIndexTmp < 10000)
                        {
                            OrderIndexTmp = 10000;
                        }
                        //FileList_BLL.CopyFileToFileTemplate(fileMDL.FileID, OrderIndexTmp + 1);

                        OrderIndexTmp = (new BLL.T_GdList_BLL()).GetMaxTemplateOrderIndex(Globals.ProjectNO);
                        if (OrderIndexTmp < 10000)
                        {
                            OrderIndexTmp = 10000;
                        }

                        MDL.T_GdList tg = new T_GdList();
                        tg.ID = fileMDL.FileID;
                        tg.GdName = frm.txtReName.Text.Trim();
                        tg.ProjectNo = Globals.ProjectNO;
                        tg.IsShow = 1;
                        tg.OrderIndex = OrderIndexTmp + 1;
                        (new BLL.T_GdList_BLL()).Insert(tg);
                    }
                    FileNode.Nodes.Add(newNode);
                    FileNode.Expand();
                }
            }
            else
            {
                TXMessageBoxExtensions.Info("请选中有效目录进行添加节点！");
            }
            //this.treeRight.SelectedNode = FileNode.LastNode;
        }

        /// <summary>
        /// 显示PDF
        /// </summary>
        /// <param name="theNode"></param>
        private void UpdatePDFView(TreeNodeEx theNode)
        {
            string PDFFile = Globals.ProjectPath + ConvertFile2PDF(theNode);
            ShowPDF(PDFFile, true);
        }
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void treeRight_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        /// <summary>
        /// 添加外部文件
        /// </summary>
        /// <param name="uploadFile">添加文件</param>
        /// <param name="fileNode">选择的文件节点</param>
        /// <param name="dlg">进度提示界面</param>
        /// <param name="checkInput_flg">判断是否检查签章，单个文件且导入的文件节点下没有电子文件，就不需要检查</param>
        /// <returns>bool:导入状态</returns>
        public bool UploadEFile(string uploadFile, TreeNodeEx fileNode, frm2PDFProgressMsg dlg, bool checkInput_flg, string PDFFilePath = "")
        {
            bool return_flg = true;


            FileInfo uploadFileInfo = new FileInfo(uploadFile);
            string FileType = uploadFileInfo.Extension;
            if (!MyCommon.CheckFileType(uploadFileInfo.Extension))
            {
                if (dlg != null)
                    dlg.Close();
                TXMessageBoxExtensions.Info("提示：上传失败！ \n【温馨提示：只允许上传的文件的格式为：*.JPG,*.JPEG,*.PNG,*.GIF,*.BMP,*.DOC,*.DOCX,*.XLS,*.XLSX,*.PPT,*PPTX,*.TIF,*.PDF,*.CLL,*.TXT】");
                return_flg = false;
            }
            else if (uploadFileInfo.Length <= 0)
            {
                if (dlg != null)
                    dlg.Close();
                TXMessageBoxExtensions.Info("上传文件大小，必须大于 0KB！");
                return_flg = false;
            }
            else
            {
                try
                {
                    /*
                     * 20140822 YQ 验证导入的PDF是否带有签章，所有遇签章的PDF不能导入
                     * 
                     */
                    ERM.MDL.T_CellAndEFile model = new ERM.MDL.T_CellAndEFile();
                    string eFileID = "";
                    if (PDFFilePath == "")
                    {
                        eFileID = Guid.NewGuid().ToString();
                    }
                    else
                    {
                        eFileID = PDFFilePath.Remove(0, PDFFilePath.LastIndexOf('\\') + 1).Replace(".pdf", "");
                    }
                    System.IO.File.Copy(uploadFile, MovedCellPath + eFileID + FileType, true);
                    File.SetAttributes(MovedCellPath + eFileID + FileType, FileAttributes.Normal);

                    //if (axpdfInterface1.FileName != null && axpdfInterface1.FileName.Length > 0)
                    //    axpdfInterface1.CloseFile();
                    int iPageCount = 0;
                    using (ConvertCell2PDF convertCell2PDF = new ConvertCell2PDF())
                    {
                        try
                        {
                            if (System.IO.Path.GetExtension(uploadFile).ToLower() == ".pdf"
                                && checkInput_flg
                                && convertCell2PDF.GetPDFKEYCount(uploadFile) > 0)
                            {
                                if (dlg != null)
                                    dlg.Close();
                                TXMessageBoxExtensions.Info("已签章的PDF无法添加！");
                                return_flg = false;
                            }
                            else
                            {
                                model.CellID = eFileID;
                                model.ProjectNO = Globals.ProjectNO;
                                model.filepath = "ODOC\\" + eFileID + FileType;
                                model.FileID = fileNode.Name;
                                model.title = uploadFileInfo.Name.Replace(FileType, "");
                                model.GdFileID = fileNode.Name;

                                iPageCount = 0; //convertCell2PDF.PrintCellToPDF(uploadFile, Globals.ProjectPath + "PDF\\" + model.CellID + ".pdf");
                                //**************************************************************//

                                if (PDFFilePath != "")//批量转换pdf 
                                {
                                    iPageCount = convertCell2PDF.MergePDFFilesPages(PDFFilePath);
                                }
                                else
                                {
                                    iPageCount = convertCell2PDF.PrintCellToPDF(uploadFile,
                                                 Globals.ProjectPath + "PDF\\" + model.CellID + ".pdf");
                                }


                                if (iPageCount > 0)
                                {
                                    model.fileTreePath = "PDF\\" + model.CellID + ".pdf";
                                    model.DoStatus = 1;
                                    model.ys = iPageCount;
                                    model.DocYs = 0;//Leo 已打过包的，下次不用打
                                }
                                else
                                {
                                    return_flg = false;
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            return_flg = false;
                            MyCommon.WriteLog("ConvertCell2PDF导入文件PDF转换失败！错误信息：" + ex.Message);
                        }

                        convertCell2PDF.Dispose();
                    }

                    if (return_flg)
                    {
                        BLL.T_CellAndEFile_BLL EFile_BLL = new BLL.T_CellAndEFile_BLL();
                        model.GdOrderIndex = EFile_BLL.GetMaxGdFileOrderIndex(fileNode.Name, Globals.ProjectNO) + 1;
                        EFile_BLL.Add(model);

                        BLL.T_FileList_BLL FileList_BLL = new BLL.T_FileList_BLL();
                        MDL.T_FileList fileMDL = FileList_BLL.Find(model.FileID, Globals.ProjectNO);
                        fileMDL.selected = 1;
                        FileList_BLL.Update(fileMDL);

                        //添加原文信息
                        MyCommon.InsertOldEfile(model.CellID, Globals.ProjectNO, Globals.LoginUser, "文件登记-从资源管理器拖入", uploadFile);

                        TreeNodeEx NewNode = new TreeNodeEx();
                        NewNode.Name = model.CellID;
                        NewNode.Text = model.title;
                        NewNode.SelectedImageIndex = 3;
                        NewNode.ImageIndex = 3;
                        NewNode.NodeValue = model.CellID;
                        fileNode.Nodes.Add(NewNode);

                    }
                    else
                    {
                        if (dlg != null)
                            dlg.Close();

                        DeleteUpLoadFile(MovedCellPath + eFileID + FileType, PDFFilePath);//删除文件上传失败文件
                        TXMessageBoxExtensions.Info("提示：文件上传失败！\n【温馨提示: 上传文件可能有误，请核实！】" + "张数：" + iPageCount);
                    }
                }
                catch (Exception ex)
                {
                    return_flg = false;
                    MyCommon.WriteLog("UploadEFile导入文件PDF转换失败！错误信息：" + ex.Message);
                }
            }
            return return_flg;
        }
        /// <summary>
        /// 删除文件上传失败文件
        /// </summary>
        /// <param name="sourcefile"></param>
        /// <param name="pdffile"></param>
        private void DeleteUpLoadFile(string sourcefile, string pdffile)
        {
            if (!string.IsNullOrEmpty(sourcefile))
            {
                File.Delete(sourcefile);
            }
            if (!string.IsNullOrEmpty(pdffile))
            {
                File.Delete(pdffile);
            }
        }
        /// <summary>
        /// 从右边listview中拉入文件
        /// </summary>
        /// <param name="targeNode"></param>
        private void AddEFile(TreeNodeEx targeNode)
        {
            if (targeNode == null)
            {
                TXMessageBoxExtensions.Info("请选中左侧的文件！");
                return;
            }
            frm2PDFProgressMsg dlg = null;
            try
            {
                ListView.SelectedListViewItemCollection ListItems = listView1.SelectedItems;

                dlg = new frm2PDFProgressMsg();
                dlg.label2.Text = "";
                if (ListItems.Count > 0)
                {
                    dlg.label2.Text = "正在导入：0/" + ListItems.Count.ToString();
                    dlg.progressBar1.Maximum = ListItems.Count;
                    dlg.Show();
                    Application.DoEvents();
                }
                targeNode.Text = targeNode.Text.Replace("导入完成 ", "");
                string strNameBK = targeNode.Text;
                targeNode.Text += "导入中(0/" + ListItems.Count + ") " + strNameBK;
                ArrayList list = new ArrayList();

                bool checkInput_flg = false;
                if (ListItems.Count > 1)
                {
                    checkInput_flg = true;
                }
                else if (ListItems.Count == 1)
                {
                    IList<MDL.T_CellAndEFile> EFile_list =
                        (new BLL.T_CellAndEFile_BLL()).FindByGdFileID(targeNode.Name, Globals.ProjectNO);
                    if (EFile_list == null || EFile_list.Count == 0)
                    {
                        checkInput_flg = false;
                    }
                    else
                    {
                        //判断之前的PDF文件是否签过章
                        checkInput_flg = true;
                    }
                }
                //pdf转换
                List<ConvertPdfFile> pdffileist = GeneratePDFList(ListItems, dlg, strNameBK, targeNode);

                if (pdffileist.Count != ListItems.Count)
                {
                    TXMessageBoxExtensions.Info("部分文件转换失败!");
                    if (dlg != null)
                        dlg.Close();
                }
                else
                {
                    if (dlg != null)
                        dlg.Close();
                    foreach (ConvertPdfFile item in pdffileist)
                    {
                        if (!UploadEFile(item.SourceFilePath, targeNode, dlg, checkInput_flg, item.PDFFilePath))
                        {
                            break;
                        }
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
            catch (Exception ex)
            {
                if (dlg != null)
                    dlg.Close();
                MyCommon.WriteLog("拖入文件错误！" + ex.Message);
            }
            finally
            {
                if (dlg != null)
                    dlg.Close();
                treeFactory.GetCellFileNodesCount(targeNode, true);
            }
        }
        private void treeRight_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Point pt;
                TreeNodeEx targeNode;
                pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
                targeNode = (TreeNodeEx)treeRight.GetNodeAt(pt);

                if (targeNode.ImageIndex == 2 || targeNode.ImageIndex == 5 || targeNode.ImageIndex == 4 || targeNode.ImageIndex == 7)
                {
                    //判断文件状态 已经组卷的文件不允许修改
                    MDL.T_FileList fileMDL1 =
                        (new BLL.T_FileList_BLL()).Find(targeNode.Name, Globals.ProjectNO);
                    if (fileMDL1.fileStatus == "6")
                    {
                        TXMessageBoxExtensions.Info("已经组卷的文件不允许修改！");
                        return;
                    }
                }

                if (this.TreeOrList == 1)
                {
                    if (targeNode.ImageIndex == 2 || targeNode.ImageIndex == 5 || targeNode.ImageIndex == 7)
                    {
                        MDL.T_FileList fileList_mdl = (new BLL.T_FileList_BLL()).Find(targeNode.Name, Globals.ProjectNO);
                        //判断是否签过章
                        using (ConvertCell2PDF cl = new ConvertCell2PDF())
                        {
                            if (cl.GetPDFKEYCount(Globals.ProjectPath + fileList_mdl.filepath) > 0)
                            {
                                if (TXMessageBoxExtensions.Question("提示：此文件 " + fileList_mdl.wjtm + "\n 已签过章，如果加入新的文件，此前的签章就会失效，确定继续操作吗？") != DialogResult.OK)
                                    return;
                            }
                        }
                        AddEFile(targeNode);

                        if (targeNode.ImageIndex == 2 || targeNode.ImageIndex == 7)
                            targeNode.ImageIndex = (treeFactory.CheckEFileByFileID(targeNode.Name, 2) == true) ? 7 : 2;//判断是否有电子文件
                        targeNode.SelectedImageIndex = targeNode.ImageIndex;
                        {
                            string PDFFile = Globals.ProjectPath + ConvertFile2PDF(targeNode);
                            return;
                        }
                    }
                    else if (targeNode.ImageIndex == 1)
                    {
                        //为文件夹，自动添加文件
                        if (TXMessageBoxExtensions.Question("提示：确定添加到文件夹： " + targeNode.Text + " \n 系统会自动创建文件条目，确定继续操作吗？") != DialogResult.OK)
                            return;
                        ListView.SelectedListViewItemCollection ListItems = listView1.SelectedItems;

                        foreach (ListViewItem item in ListItems)
                        {
                            //判断文件后缀为docx是否安装了office以上版本
                            if (System.IO.Path.GetExtension(item.Name).ToLower() == ".docx"
                                && !Globals.SystemDocxOffice)
                            {
                                TXMessageBoxExtensions.Info("添加后缀为：docx的电子文件，系统必须安装Office2007以上版本 \n 【温馨提示：请先安装Office2007】");
                                return;
                            }
                        }

                        frm2PDFProgressMsg dlg = null;
                        try
                        {
                            dlg = new frm2PDFProgressMsg();
                            dlg.label2.Text = "";
                            if (ListItems.Count > 0)
                            {
                                dlg.label2.Text = "正在导入：0/" + ListItems.Count.ToString();
                                dlg.progressBar1.Maximum = ListItems.Count;
                                dlg.Show();
                                Application.DoEvents();
                            }
                            ArrayList list = new ArrayList();

                            //pdf转换
                            List<ConvertPdfFile> pdffilelist = GeneratePDFList(ListItems, dlg, targeNode.Text, targeNode);

                            foreach (ConvertPdfFile item in pdffilelist)
                            {
                                BLL.T_FileList_BLL FileList_BLL = new BLL.T_FileList_BLL();
                                int OrderIndex = FileList_BLL.GetMaxGdFileOrderIndex(targeNode.Name, Globals.ProjectNO);
                                MDL.T_FileList fileMDL = new T_FileList();
                                fileMDL.FileID = Guid.NewGuid().ToString();
                                fileMDL.ProjectNO = Globals.ProjectNO;
                                fileMDL.ParentID = targeNode.Name;
                                fileMDL.wjtm = System.IO.Path.GetFileNameWithoutExtension(item.SourceFilePath);
                                fileMDL.OrderIndex = OrderIndex + 1;
                                fileMDL.fileStatus = "0";
                                fileMDL.isvisible = 1;
                                fileMDL.FL = 1;
                                fileMDL.GDID = targeNode.Name;
                                fileMDL.GdFileOrderIndex =
                                    FileList_BLL.GetMaxGdFileOrderIndex(targeNode.Name, Globals.ProjectNO) + 1;
                                FileList_BLL.Add(fileMDL);

                                TreeNodeEx newNode = new TreeNodeEx();
                                newNode.Name = fileMDL.FileID;
                                newNode.Text = fileMDL.wjtm;
                                newNode.ImageIndex = 7;
                                newNode.SelectedImageIndex = 7;
                                fileMDL.isvisible = 1;
                                targeNode.Nodes.Add(newNode);

                                if (!UploadEFile(item.SourceFilePath, newNode, dlg, false, item.PDFFilePath))
                                {
                                    if (dlg != null)
                                        dlg.Close();
                                    break;
                                }
                                treeFactory.GetCellFileNodesCount(newNode, true);
                            }
                            if (dlg != null)
                                dlg.Close();
                        }
                        catch (Exception ex)
                        {
                            if (dlg != null)
                                dlg.Close();
                            MyCommon.WriteLog("拖入文件错误！" + ex.Message);
                        }
                        finally
                        {
                            if (dlg != null)
                                dlg.Close();
                        }
                        targeNode.Expand();
                    }
                }
                else//右边树内部拖动
                {
                    TreeNodeEx fromNode = (TreeNodeEx)treeRight.SelectedNode;// (TreeNodeEx)e.Data.GetData("ERM.Common.TreeNodeEx");
                    if (fromNode == null || fromNode.ImageIndex == 0 || fromNode.Level == 1
                        || (targeNode.ImageIndex == 0 && targeNode.Text == "最近著录过的文件"))
                        return;
                    if (fromNode.ImageIndex == 2 || fromNode.ImageIndex == 5 || fromNode.ImageIndex == 4 || fromNode.ImageIndex == 7)
                    {
                        //判断文件状态 已经组卷的文件不允许修改
                        MDL.T_FileList fileMDL1 =
                            (new BLL.T_FileList_BLL()).Find(fromNode.Name, Globals.ProjectNO);
                        if (fileMDL1.fileStatus == "6")
                        {
                            TXMessageBoxExtensions.Info("已经组卷的文件不允许修改！");
                            return;
                        }
                    }
                    else if (fromNode.ImageIndex == 3)//电子文件移动
                    {
                        if (fromNode.Parent != null && fromNode.Parent.ImageIndex == 4)
                        {
                            TXMessageBoxExtensions.Info("已经组卷的文件不允许修改！");
                            return;
                        }
                        //判断当前的文件是否签过章，如果移动会改变电子签章
                        MDL.T_FileList fileList_mdl =
                          (new BLL.T_FileList_BLL()).Find(fromNode.Parent.Name, Globals.ProjectNO);
                        //判断是否签过章
                        using (ConvertCell2PDF cl = new ConvertCell2PDF())
                        {
                            if (cl.GetPDFKEYCount(Globals.ProjectPath + fileList_mdl.filepath) > 0)
                            {
                                if (TXMessageBoxExtensions.Question("提示：此文件 " + fileList_mdl.wjtm + " \n 已签过章，如果移动，此前的签章就会失效，确定继续操作吗？") != DialogResult.OK)
                                    return;
                            }
                        }
                    }
                    if (targeNode.Name == fromNode.Name)
                        return;

                    if (fromNode.ImageIndex == 2 || fromNode.ImageIndex == 5
                        || fromNode.ImageIndex == 4 || fromNode.ImageIndex == 7)//文件拖动
                    {
                        #region
                        if (targeNode.ImageIndex == 1
                            || (targeNode.ImageIndex == 0
                            && targeNode.Text != "最近著录过的文件"))
                        {
                            if (targeNode.Name == fromNode.Parent.Name)
                                return;

                            BLL.T_FileList_BLL FileList_bll = new BLL.T_FileList_BLL();
                            MDL.T_FileList fileMDL1 = FileList_bll.Find(fromNode.Name, Globals.ProjectNO);
                            MDL.T_FileList fileMDL2 = FileList_bll.Find(targeNode.Name, Globals.ProjectNO);
                            fileMDL1.GDID = fileMDL2.FileID;
                            fileMDL1.GdFileOrderIndex = FileList_bll.GetMaxGdFileOrderIndex(fileMDL2.FileID, Globals.ProjectNO) + 1;
                            (new BLL.T_FileList_BLL()).Update(fileMDL1);

                            fromNode.Remove();
                            if (targeNode.Nodes == null ||
                                targeNode.Nodes.Count == 0)
                                targeNode.Nodes.Insert(0, (TreeNode)fromNode);
                            else
                                targeNode.Nodes.Add((TreeNode)fromNode);

                            UpdateNodeLevel((TreeNode)(targeNode));
                        }
                        else if (targeNode.ImageIndex != 3 && targeNode.ImageIndex != 0)
                        {
                            /*
                             * 先将自己替换为原来的Index 然后再将目的以后的目录（index+1）
                             */
                            BLL.T_FileList_BLL FileList_bll = new BLL.T_FileList_BLL();
                            MDL.T_FileList fileMDL1 = (FileList_bll).Find(fromNode.Name, Globals.ProjectNO);
                            MDL.T_FileList fileMDL2 = (FileList_bll).Find(targeNode.Name, Globals.ProjectNO);
                            fileMDL1.GDID = fileMDL2.GDID;
                            fileMDL1.GdFileOrderIndex = FileList_bll.GetMaxGdFileOrderIndex(fileMDL2.GDID, Globals.ProjectNO) + 1;
                            (FileList_bll).Update(fileMDL1);

                            fromNode.Remove();
                            targeNode.Parent.Nodes.Insert(targeNode.Index, (TreeNode)fromNode);
                            UpdateNodeLevel((TreeNode)(targeNode.Parent));
                        }
                        #endregion
                    }
                    else if (fromNode.ImageIndex == 3)//电子文件移动
                    {
                        #region
                        if (targeNode.ImageIndex != 1 && targeNode.ImageIndex != 0 && targeNode.ImageIndex != 3 && targeNode.ImageIndex != 4)//文件
                        {
                            if (targeNode.Name == fromNode.Parent.Name)
                                return;
                            BLL.T_CellAndEFile_BLL EFile_BLL = new BLL.T_CellAndEFile_BLL();
                            MDL.T_CellAndEFile fileMDL1 = (EFile_BLL).Find(fromNode.Name, Globals.ProjectNO);

                            BLL.T_FileList_BLL fileList_bll = new BLL.T_FileList_BLL();
                            MDL.T_FileList fileList_mdl = fileList_bll.Find(fileMDL1.GdFileID, Globals.ProjectNO);
                            fileList_mdl.selected = 1;
                            fileList_bll.Update(fileList_mdl);

                            MDL.T_FileList fileMDL2 = fileList_bll.Find(targeNode.Name, Globals.ProjectNO);
                            fileMDL1.GdFileID = fileMDL2.FileID;
                            fileMDL1.GdOrderIndex = (EFile_BLL).GetMaxGdFileOrderIndex(fileMDL2.FileID, Globals.ProjectNO) + 1;
                            (EFile_BLL).Update(fileMDL1);

                            fromNode.Parent.ImageIndex = (treeFactory.CheckEFileByFileID(fromNode.Parent.Name, 2) == true) ? 7 : 2;//判断是否有电子文件
                            fromNode.Parent.SelectedImageIndex = fromNode.Parent.ImageIndex;
                            treeFactory.GetCellFileNodesCount(((TreeNodeEx)fromNode.Parent), true);

                            fromNode.Remove();
                            if (targeNode.Nodes == null ||
                                targeNode.Nodes.Count == 0)
                                targeNode.Nodes.Insert(0, (TreeNode)fromNode);
                            else
                                targeNode.Nodes.Add((TreeNode)fromNode);

                            UpdateNodeCellLevel((TreeNode)(targeNode));
                            targeNode.ImageIndex = (treeFactory.CheckEFileByFileID(targeNode.Name, 2) == true) ? 7 : 2;//判断是否有电子文件
                            targeNode.SelectedImageIndex = targeNode.ImageIndex;
                            treeFactory.GetCellFileNodesCount(((TreeNodeEx)targeNode), true);

                            MDL.T_FileList fileList_mdl2 = fileList_bll.Find(targeNode.Name, Globals.ProjectNO);
                            fileList_mdl2.selected = 1;
                            fileList_bll.Update(fileList_mdl2);
                        }
                        else if (targeNode.ImageIndex == 3)//电子文件
                        {
                            BLL.T_CellAndEFile_BLL EFile_BLL = new BLL.T_CellAndEFile_BLL();

                            MDL.T_CellAndEFile fileMDL1 = EFile_BLL.Find(fromNode.Name, Globals.ProjectNO);
                            BLL.T_FileList_BLL fileList_bll = (new BLL.T_FileList_BLL());
                            MDL.T_FileList fileList_mdl = fileList_bll.Find(fileMDL1.GdFileID, Globals.ProjectNO);
                            fileList_mdl.selected = 1;
                            fileList_bll.Update(fileList_mdl);

                            MDL.T_CellAndEFile fileMDL2 = EFile_BLL.Find(targeNode.Name, Globals.ProjectNO);
                            fileMDL1.GdFileID = fileMDL2.GdFileID;
                            fileMDL1.GdOrderIndex = fileMDL2.GdOrderIndex;
                            EFile_BLL.Update(fileMDL1);

                            fromNode.Parent.ImageIndex = (treeFactory.CheckEFileByFileID(fromNode.Parent.Name, 2) == true) ? 7 : 2;//判断是否有电子文件
                            fromNode.Parent.SelectedImageIndex = fromNode.Parent.ImageIndex;
                            treeFactory.GetCellFileNodesCount(((TreeNodeEx)fromNode.Parent), true);

                            fromNode.Remove();
                            targeNode.Parent.Nodes.Insert(targeNode.Index, (TreeNode)fromNode);

                            UpdateNodeCellLevel((TreeNode)(targeNode.Parent));

                            targeNode.Parent.ImageIndex = (treeFactory.CheckEFileByFileID(targeNode.Parent.Name, 2) == true) ? 7 : 2;//判断是否有电子文件
                            targeNode.Parent.SelectedImageIndex = targeNode.Parent.ImageIndex;
                            treeFactory.GetCellFileNodesCount(((TreeNodeEx)targeNode.Parent), true);

                            MDL.T_FileList fileList_mdl2 = fileList_bll.Find(fileMDL2.GdFileID, Globals.ProjectNO);
                            fileList_mdl2.selected = 1;
                            fileList_bll.Update(fileList_mdl2);
                        }
                        #endregion
                    }
                    else if (fromNode.ImageIndex == 1)//文件夹拖动
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                MyCommon.WriteLog("拖拉文件错误，信息：" + ex.Message);
            }
        }
        private void treeRight_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void treeRight_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeRightAfterSelect();
        }

        private void treeRightAfterSelect()
        {
            TreeNode DestinationNode = treeRight.SelectedNode;
            if (DestinationNode == null || DestinationNode.Name == String.Empty)
                return;
            TreeNodeEx theNode = (TreeNodeEx)DestinationNode;
            if (theNode.Name == String.Empty)
                return;
            if (fileBaseInfo == null)
            {
                fileBaseInfo = new FileRegistInfo();
            }
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

                    Globals.ZRR = fileBaseInfo.cmbzrz.SelectedText;
                    this.fileBaseInfo.ShowData(theNode);

                    if (fileBaseInfo.btnbEnableQuickInput.Checked == true)
                    {
                        if (fileBaseInfo.cmbzrz.SelectedText == "")
                        {
                            fileBaseInfo.cmbzrz.SelectedText = Globals.ZRR;
                        }
                    }
                    this.fileBaseInfo.isUpdateInfo_flg = false;//保存提示
                }

                if (theNode.Nodes.Count <= 0)
                {
                    BLL.T_CellAndEFile_BLL cellFile = new ERM.BLL.T_CellAndEFile_BLL();
                    IList<MDL.T_CellAndEFile> cellList =
                        cellFile.FindByGdFileID(theNode.Name, Globals.ProjectNO);
                    //IList<MDL.T_CellAndEFile> cellList = 
                    //    cellFile.FindByFileIDAndNOCell(theNode.Name, Globals.ProjectNO);
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
                else
                {
                    BLL.T_CellAndEFile_BLL cellFile = new ERM.BLL.T_CellAndEFile_BLL();
                    IList<MDL.T_CellAndEFile> cellList =
                        cellFile.FindByGdFileID(theNode.Name, Globals.ProjectNO);
                    if (cellList.Count != theNode.Nodes.Count)
                    {
                        theNode.Nodes.Clear();
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
            }
            if (theNode.ImageIndex == 3)
            {
                tabControl1.SelectedTab = tabControl1.TabPages["tablEfileShow"];
                string pdfPath = ConvertCell2PDF(theNode.Name);
                string PDFFile = Globals.ProjectPath + pdfPath;
                ShowPDF(PDFFile, false);
            }
            else if (theNode.ImageIndex != 1 && theNode.ImageIndex != 0)
            {
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsOutput_Click(object sender, EventArgs e)
        {
            TreeNodeEx theNode = (TreeNodeEx)treeRight.SelectedNode;
            if (theNode == null || theNode.Text.Trim() == "最近著录过的文件" ||
                (theNode.Parent != null && theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选中有效的节点导出数据！");
                return;
            }
            if (theNode.ImageIndex == 3)
            {
                TXMessageBoxExtensions.Info("提示：只能选文件或文件夹节点导出数据！");
                return;
            }
            if (theNode.ImageIndex == 0)
            {
                TXMessageBoxExtensions.Info("提示：整个工程导出可在工程管理进行备份和恢复进行处理！");
                return;
            }
            ERM.UI.frmExpData Frm = new ERM.UI.frmExpData(theNode);
            if (Frm.ShowDialog() == DialogResult.OK)
            {
                TXMessageBoxExtensions.Info("导出数据成功！");
            }
        }
        /// <summary>
        /// 导入方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbarImport_Click(object sender, EventArgs e)
        {
            TreeNode CureNode = treeRight.SelectedNode;
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

            bool check_flg = false;
            int DelCount = 0;
            CheckFileNodeIsArch(CureNode, ref check_flg, ref DelCount);
            if (check_flg)
            {
                TXMessageBoxExtensions.Info("提示：已组卷的目录不允许编辑！ \n 【温馨提示：如想编辑请在文件登记中撤销登记或在组卷目录移除此文件】");
                return;
            }

            string showText = "[" + CureNode.Text.Substring(CureNode.Text.LastIndexOf("]") + 1) + "]";

            if (TXMessageBoxExtensions.Question("提示：确定给节点： " + showText + "  导入信息吗？") != DialogResult.OK)
                return;

            frmImpData Frm = new frmImpData(CureNode, TreeNodeState_flg, 2);
            DialogResult drt = Frm.ShowDialog();
            if (drt == DialogResult.OK)
            {
                TXMessageBoxExtensions.Info("导入数据成功！");
                treeRight_AfterSelect(null, null);
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
                if (NewNode.Text.Trim() == "最近著录过的文件" || (NewNode.Parent != null &&
                    NewNode.Parent.Text.Trim() == "最近著录过的文件"))
                {
                    TXMessageBoxExtensions.Info("提示：请选择有效的文件！");
                    return;
                }

                if (NewNode.ImageIndex == 2 || NewNode.ImageIndex == 5 || NewNode.ImageIndex == 4 || NewNode.ImageIndex == 7)
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
                            TXMessageBoxExtensions.Question("确定将已经组卷的文件撤销登记吗？  \r\n\n【温馨提示：撤销登记后，文件自动从组卷中移除】");
                        if (check_result == DialogResult.Cancel)
                            return;
                    }
                    else if (fileMDL1.fileStatus == "0")
                    {
                        TXMessageBoxExtensions.Info("提示：成功撤消文件！");
                        return;
                    }
                }
                else if (NewNode.ImageIndex == 3)
                {
                    TXMessageBoxExtensions.Info("提示：请选择有效的文件！");
                    return;
                }

                MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(NewNode.Name, Globals.ProjectNO);
                if (fileMDL != null && fileMDL.isvisible == 1)
                {
                    fileMDL.ArchiveID = "";
                    fileMDL.fileStatus = "3";
                    NewNode.ImageIndex = (treeFactory.CheckEFileByFileID(NewNode.Name, 2) == true) ? 7 : 2;//判断是否有电子文件
                    NewNode.SelectedImageIndex = NewNode.ImageIndex;
                    (new BLL.T_FileList_BLL()).Update(fileMDL);
                    fileBaseInfo.Enabled = true;
                    TXMessageBoxExtensions.Info("提示：成功撤消文件！");
                }
                else
                {
                    TXMessageBoxExtensions.Info("提示：请选择需要撤消的文件！");
                }
            }
        }
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.treeRight.SelectedNode;
            if (theNode == null || theNode.ImageIndex == 1 || theNode.ImageIndex == 0 || theNode.ImageIndex == 3
                || (theNode.Text.Trim() == "最近著录过的文件") || (theNode.Parent != null &&
                theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件！");
                isNextNode_flg = false;
                return;
            }
            if (!fileBaseInfo.Enabled)
            {
                isNextNode_flg = false;
                return;
            }

            if (!String.IsNullOrEmpty(this.fileBaseInfo.dptCreateDate2.TextEx))
            {
                if (this.fileBaseInfo.dptCreateDate.TextEx=="")
                {
                    TXMessageBoxExtensions.Info("形成开始日期不能为空!");
                    this.fileBaseInfo.dptCreateDate.TextEx = "";
                    this.fileBaseInfo.dptCreateDate.Focus();
                    isNextNode_flg = false;
                    return;
                }

                if (!this.fileBaseInfo.dptCreateDate2.TextEx.Equals(this.fileBaseInfo.dptCreateDate.TextEx) &&
                    this.fileBaseInfo.dptCreateDate2.TextEx != "" &&
                        this.fileBaseInfo.dptCreateDate.TextEx != "" &&
                            (MyCommon.ToDate(this.fileBaseInfo.dptCreateDate2.TextEx) <
                            MyCommon.ToDate(this.fileBaseInfo.dptCreateDate.TextEx)))
                {
                    TXMessageBoxExtensions.Info("提示：形成结束时间 必须大于 形成开始时间！");
                    this.fileBaseInfo.dptCreateDate2.TextEx = "";
                    this.fileBaseInfo.dptCreateDate2.Focus();
                    isNextNode_flg = false;
                    return;
                }
            }
            if (this.treeRight.SelectedNode != null)
            {
                {
                    try
                    {   //tzz sl dtz dw zpz wzz dpz 载体类型
                        bool ispp = true;//是否匹配
                        switch (MyCommon.ToSqlString(this.fileBaseInfo.ztlx.Text.ToString()))
                        {
                            case "纸质":
                                if ((MyCommon.ToSqlString(this.fileBaseInfo.tzz.Text.ToString()) != "" &&
                                     MyCommon.ToInt(this.fileBaseInfo.tzz.Text.ToString()) > 0) ||
                                    (MyCommon.ToSqlString(this.fileBaseInfo.dtz.Text.ToString()) != "" &&
                                     MyCommon.ToInt(this.fileBaseInfo.dtz.Text.ToString()) > 0) ||
                                    // (MyCommon.ToSqlString(this.fileBaseInfo.dw.Text.ToString()) != "" &&
                                    // MyCommon.ToInt(this.fileBaseInfo.dw.Text.ToString()) > 0) ||
                                    (MyCommon.ToSqlString(this.fileBaseInfo.zpz.Text.ToString()) != "" &&
                                     MyCommon.ToInt(this.fileBaseInfo.zpz.Text.ToString()) > 0) ||
                                    //(MyCommon.ToSqlString(this.fileBaseInfo.wzz.Text.ToString()) != "" &&
                                    // MyCommon.ToInt(this.fileBaseInfo.wzz.Text.ToString()) > 0) ||
                                    (MyCommon.ToSqlString(this.fileBaseInfo.dpz.Text.ToString()) != "" &&
                                     MyCommon.ToInt(this.fileBaseInfo.dpz.Text.ToString()) > 0)
                                    ) { ispp = false; }
                                break;
                            case "图纸":
                                if ((MyCommon.ToSqlString(this.fileBaseInfo.sl.Text.ToString()) != "" &&
                                     MyCommon.ToInt(this.fileBaseInfo.sl.Text.ToString()) > 0) ||
                                    (MyCommon.ToSqlString(this.fileBaseInfo.dtz.Text.ToString()) != "" &&
                                     MyCommon.ToInt(this.fileBaseInfo.dtz.Text.ToString()) > 0) ||
                                    (MyCommon.ToSqlString(this.fileBaseInfo.zpz.Text.ToString()) != "" &&
                                     MyCommon.ToInt(this.fileBaseInfo.zpz.Text.ToString()) > 0) ||
                                    //(MyCommon.ToSqlString(this.fileBaseInfo.wzz.Text.ToString()) != "" &&
                                    // MyCommon.ToInt(this.fileBaseInfo.wzz.Text.ToString()) > 0) ||
                                    (MyCommon.ToSqlString(this.fileBaseInfo.dpz.Text.ToString()) != "" &&
                                     MyCommon.ToInt(this.fileBaseInfo.dpz.Text.ToString()) > 0)
                                    ) { ispp = false; }
                                break;
                            case "底图":
                                if ((MyCommon.ToSqlString(this.fileBaseInfo.tzz.Text.ToString()) != "" &&
                                    MyCommon.ToInt(this.fileBaseInfo.tzz.Text.ToString()) > 0) ||
                                   (MyCommon.ToSqlString(this.fileBaseInfo.sl.Text.ToString()) != "" &&
                                    MyCommon.ToInt(this.fileBaseInfo.sl.Text.ToString()) > 0) ||
                                    //(MyCommon.ToSqlString(this.fileBaseInfo.dw.Text.ToString()) != "" &&
                                    // MyCommon.ToInt(this.fileBaseInfo.dw.Text.ToString()) > 0) ||
                                   (MyCommon.ToSqlString(this.fileBaseInfo.zpz.Text.ToString()) != "" &&
                                    MyCommon.ToInt(this.fileBaseInfo.zpz.Text.ToString()) > 0) ||
                                    //(MyCommon.ToSqlString(this.fileBaseInfo.wzz.Text.ToString()) != "" &&
                                    // MyCommon.ToInt(this.fileBaseInfo.wzz.Text.ToString()) > 0) ||
                                   (MyCommon.ToSqlString(this.fileBaseInfo.dpz.Text.ToString()) != "" &&
                                    MyCommon.ToInt(this.fileBaseInfo.dpz.Text.ToString()) > 0)
                                   ) { ispp = false; }
                                break;
                            case "照片":
                                if ((MyCommon.ToSqlString(this.fileBaseInfo.tzz.Text.ToString()) != "" &&
                                    MyCommon.ToInt(this.fileBaseInfo.tzz.Text.ToString()) > 0) ||
                                   (MyCommon.ToSqlString(this.fileBaseInfo.sl.Text.ToString()) != "" &&
                                    MyCommon.ToInt(this.fileBaseInfo.sl.Text.ToString()) > 0) ||
                                   (MyCommon.ToSqlString(this.fileBaseInfo.dtz.Text.ToString()) != "" &&
                                    MyCommon.ToInt(this.fileBaseInfo.dtz.Text.ToString()) > 0) ||
                                    //(MyCommon.ToSqlString(this.fileBaseInfo.dw.Text.ToString()) != "" &&
                                    // MyCommon.ToInt(this.fileBaseInfo.dw.Text.ToString()) > 0) ||
                                   (MyCommon.ToSqlString(this.fileBaseInfo.dpz.Text.ToString()) != "" &&
                                    MyCommon.ToInt(this.fileBaseInfo.dpz.Text.ToString()) > 0)
                                   ) { ispp = false; }
                                break;
                            case "底片":
                                if ((MyCommon.ToSqlString(this.fileBaseInfo.tzz.Text.ToString()) != "" &&
                                    MyCommon.ToInt(this.fileBaseInfo.tzz.Text.ToString()) > 0) ||
                                   (MyCommon.ToSqlString(this.fileBaseInfo.sl.Text.ToString()) != "" &&
                                    MyCommon.ToInt(this.fileBaseInfo.sl.Text.ToString()) > 0) ||
                                   (MyCommon.ToSqlString(this.fileBaseInfo.dtz.Text.ToString()) != "" &&
                                    MyCommon.ToInt(this.fileBaseInfo.dtz.Text.ToString()) > 0) ||
                                    //(MyCommon.ToSqlString(this.fileBaseInfo.dw.Text.ToString()) != "" &&
                                    // MyCommon.ToInt(this.fileBaseInfo.dw.Text.ToString()) > 0) ||
                                   (MyCommon.ToSqlString(this.fileBaseInfo.zpz.Text.ToString()) != "" &&
                                    MyCommon.ToInt(this.fileBaseInfo.zpz.Text.ToString()) > 0)
                                    // ||
                                    // (MyCommon.ToSqlString(this.fileBaseInfo.wzz.Text.ToString()) != "" &&
                                    //  MyCommon.ToInt(this.fileBaseInfo.wzz.Text.ToString()) > 0)
                                   ) { ispp = false; }
                                break;
                        }
                        if (!ispp)
                        {
                            isNextNode_flg = false;
                            TXMessageBoxExtensions.Info("载体类型与对应的页数张数不一致！");
                            this.fileBaseInfo.tzz.Text = "0";
                            this.fileBaseInfo.sl.Text = "0";
                            this.fileBaseInfo.dtz.Text = "0";
                            // this.fileBaseInfo.dw.Text = "0";
                            this.fileBaseInfo.zpz.Text = "0";
                            //this.fileBaseInfo.wzz.Text = "0";
                            this.fileBaseInfo.dpz.Text = "0";
                        }
                        else
                        {
                            if (this.fileBaseInfo.txtstys.Text.Trim() == "")
                            {
                                TXMessageBoxExtensions.Info("实体页数不能为空");
                                fileBaseInfo.txtstys.Focus();
                                isNextNode_flg = false;
                                return;
                            }

                            if (this.fileBaseInfo.txtWzys.Text.Trim() == "")
                            {
                                TXMessageBoxExtensions.Info("文字页数不能为空");
                                fileBaseInfo.txtWzys.Focus();
                                isNextNode_flg = false;
                                return;
                            }

                            if (this.fileBaseInfo.wh.Text.Trim() == "")
                            {
                                TXMessageBoxExtensions.Info("文图号不能为空");
                                fileBaseInfo.wh.Focus();
                                isNextNode_flg = false;
                                return;
                            }
                            if (this.fileBaseInfo.cmbzrz.Text.Trim() == "")
                            {
                                TXMessageBoxExtensions.Info("责任人不能为空");
                                fileBaseInfo.cmbzrz.Focus();
                                isNextNode_flg = false;
                                return;
                            }

                            object obj = this.SaveEx((TreeNodeEx)(this.treeRight.SelectedNode));
                            this.treeRight.SelectedNode.ImageIndex = 5;
                            treeRight.SelectedNode.SelectedImageIndex = treeRight.SelectedNode.ImageIndex;
                            Globals.ZRR = this.fileBaseInfo.cmbzrz.SelectedText;
                            this.fileBaseInfo.flag1 = true;
                            this.fileBaseInfo.flag2 = true;
                            this.fileBaseInfo.isUpdateInfo_flg = false;
                            isNextNode_flg = false;
                            if (obj != null)
                            {
                                TXMessageBoxExtensions.Info("保存成功！");
                            }
                        }
                    }
                    catch
                    {
                        isNextNode_flg = false;
                        TXMessageBoxExtensions.Info("保存失败！");
                    }
                }
                if (this.treeRight.SelectedNode.ImageIndex == 4)
                {
                    isNextNode_flg = false;
                    TXMessageBoxExtensions.Info("合并后的文件登记不允许更新,请先拆分！");
                }
                if (this.treeRight.SelectedNode.ImageIndex == 1)
                {
                    isNextNode_flg = false;
                    TXMessageBoxExtensions.Info("只有已登记的模版才能保存！");
                }
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public string SaveEx(TreeNodeEx node)
        {
            FileRegistInfo frm = new FileRegistInfo();
            T_FileList model = (new BLL.T_FileList_BLL()).Find(node.Name, Globals.ProjectNO);
            if (model != null && model.FileID == node.Name)
            {
                model.TreePath = MyCommon.ToSqlString(treeFactory.OpeartPath(node));
                model.wjcj = MyCommon.ToSqlString(node.Level.ToString());
                // model.wjbsm = MyCommon.ToSqlString(this.fileBaseInfo.wjbsm.Text);
                model.wjtm = MyCommon.ToSqlString(this.fileBaseInfo.wjtm.Text);

                //if (this.fileBaseInfo.dptCreateDate.CustomFormat == "")
                {
                    model.CreateDate = this.fileBaseInfo.dptCreateDate.TextEx;//Value.ToString();
                }
                //if (this.fileBaseInfo.dptCreateDate2.CustomFormat == "")
                {
                    model.CreateDate2 = this.fileBaseInfo.dptCreateDate2.TextEx;//Value.ToString();
                }
                model.ztlx = MyCommon.ToSqlString(this.fileBaseInfo.ztlx.Text.ToString());
                model.gg = MyCommon.ToSqlString(this.fileBaseInfo.gg.Text.ToString());
                //  model.bgqx = MyCommon.ToSqlString(this.fileBaseInfo.bgqx.Text.ToString());
                // model.mj = MyCommon.ToSqlString(this.fileBaseInfo.mj.Text.ToString());
                model.wjgbdm = MyCommon.ToSqlString(this.fileBaseInfo.gb.Text.Trim());
                //model.wjlxdm = MyCommon.ToSqlString(this.fileBaseInfo.wjlx.Text.ToString());
               // model.wjgs = MyCommon.ToSqlString(this.fileBaseInfo.wjgs.Text.Trim());
               // model.wjdx = MyCommon.ToSqlString(this.fileBaseInfo.wjdx.Text.Trim());
                // model.psdd = MyCommon.ToSqlString(this.fileBaseInfo.psdd.Text.Trim());
                //  model.pssj = this.fileBaseInfo.dptpssj.TextEx;//Value.ToShortDateString();
                // model.psz = MyCommon.ToSqlString(this.fileBaseInfo.psz.Text.Trim());
                //model.fbl = MyCommon.ToSqlString(this.fileBaseInfo.fbl.Text.Trim());
                //model.xjpp = MyCommon.ToSqlString(this.fileBaseInfo.xjpp.Text.Trim());
                // model.xjxh = MyCommon.ToSqlString(this.fileBaseInfo.xjxh.Text.Trim());
                // model.sb = MyCommon.ToSqlString(this.fileBaseInfo.sb.Text.Trim());

                model.stys = Convert.ToInt32(this.fileBaseInfo.txtstys.Text);
                model.wzys = Convert.ToInt32(this.fileBaseInfo.txtWzys.Text);
                model.bz = MyCommon.ToSqlString(this.fileBaseInfo.fz.Text);
                model.zrr = MyCommon.ToSqlString(this.fileBaseInfo.cmbzrz.Text);
                //model.wjlx = MyCommon.ToSqlString(this.fileBaseInfo.cmb_wjlx.Text);
                model.ProjectNO = MyCommon.ToSqlString(Globals.ProjectNO);
                model.wh = MyCommon.ToSqlString(this.fileBaseInfo.wh.Text);
                int nTzz = 0;
                int nDtz = 0;
                if (!String.IsNullOrEmpty(this.fileBaseInfo.tzz.Text))
                {
                    nTzz = MyCommon.ToInt(this.fileBaseInfo.tzz.Text);//图纸
                }
                if (!String.IsNullOrEmpty(this.fileBaseInfo.dtz.Text))
                {
                    nDtz = MyCommon.ToInt(this.fileBaseInfo.dtz.Text);//底图张
                }
                int TzResult = nTzz + nDtz;
                model.dw = TzResult.ToString();//图样
                //this.fileBaseInfo.dw.Text = TzResult.ToString();
                TreeNodeEx NodeNode = (TreeNodeEx)node.Parent;
                //model.FileID = MyCommon.ToSqlString(this.fileBaseInfo.FileID.Text);
                // model.wjmc = MyCommon.ToSqlString(this.fileBaseInfo.wjmc.Text);
                int nZpz = 0;
                int nDpz = 0;
                if (!String.IsNullOrEmpty(this.fileBaseInfo.zpz.Text))
                {
                    nZpz = MyCommon.ToInt(this.fileBaseInfo.zpz.Text);//照片张
                }
                if (!String.IsNullOrEmpty(this.fileBaseInfo.dpz.Text))
                {
                    nDpz = MyCommon.ToInt(this.fileBaseInfo.dpz.Text);//底片张
                }
                int ZpResult = nZpz + nDpz;
                model.wzz = ZpResult.ToString();//照片数量
                // this.fileBaseInfo.wzz.Text = ZpResult.ToString();
                model.tzz = this.fileBaseInfo.tzz.GetText;//图纸
                model.dtz = this.fileBaseInfo.dtz.GetText;//底图张
                model.zpz = this.fileBaseInfo.zpz.GetText;//照片张
                model.dpz = this.fileBaseInfo.dpz.GetText;////底片张
                model.fileStatus = "4";//Leo 有登记文件
                model.sl = MyCommon.ToInt(this.fileBaseInfo.sl.Text);//jdk 20151117 文字页数

                try
                {
                    BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                    fileBLL.Update(model);

                    if (node.Text.Trim() != model.wjtm.Trim())
                    {
                        node.Text = model.wjtm.Trim();
                        treeFactory.GetCellFileNodesCount(node, true);
                    }

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
        private void btnClosed_Click(object sender, EventArgs e)
        {
            TemplateClear();
            this.Close();
        }
        private void TemplateClear()
        {
            //if (axpdfInterface1.FileName != null && axpdfInterface1.FileName.Length > 0)
            //    axpdfInterface1.CloseFile();

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
        /// 重命名
        /// </summary>
        private void ReName()
        {
            TreeNodeEx NewNode = (TreeNodeEx)(this.treeRight.SelectedNode);
            if (NewNode == null || NewNode.Level == 0 || NewNode.Level == 1
                || (NewNode.Parent != null && NewNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的目录重命名！");
                return;
            }

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
                    TXMessageBoxExtensions.Info("已经组卷的文件不允许修改！");
                    return;
                }
            }

            frmReName frm = new frmReName(NewNode);
            frm.ShowDialog();
            if (NewNode.ImageIndex != 1 && NewNode.ImageIndex != 3)
            {
                bool update_flg = this.fileBaseInfo.isUpdateInfo_flg;
                fileBaseInfo.wjtm.Text = NewNode.Text;
                this.fileBaseInfo.isUpdateInfo_flg = update_flg;
                treeFactory.GetCellFileNodesCount(NewNode, true);
            }
        }
        /// <summary>
        /// 节点移动
        /// </summary>
        /// <param name="MoveType"></param>
        private void NodeMove(string MoveType)
        {
            TreeNodeEx NewNode = (TreeNodeEx)(this.treeRight.SelectedNode);
            if (NewNode == null || NewNode.Level == 0 || NewNode.Level == 1)
                return;
            if (NewNode.Parent != null && NewNode.Parent.Text.Trim() == "最近著录过的文件")
                return;

            if (NewNode != null)
            {
                if (NewNode.ImageIndex == 1 || NewNode.ImageIndex == 2 || NewNode.ImageIndex == 3
                    || NewNode.ImageIndex == 5 || NewNode.ImageIndex == 4 || NewNode.ImageIndex == 7)
                {
                    if (NewNode.Parent.Nodes.Count <= 1)
                        return;
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
                    if (NewNode.ImageIndex == 3)
                    {
                        BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                        MDL.T_FileList fileMDL = fileBLL.Find(NewNode.Parent.Name, Globals.ProjectNO);
                        //判断是否签过章
                        using (ConvertCell2PDF cl = new ConvertCell2PDF())
                        {
                            if (cl.GetPDFKEYCount(Globals.ProjectPath + fileMDL.filepath) > 0)
                            {
                                if (TXMessageBoxExtensions.Question("提示：此文件 " + fileMDL.wjtm + " \n 已签过章，如果移动，此前的签章就会失效，确定继续操作吗？") != DialogResult.OK)
                                    return;
                            }
                        }
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
                            cellMDL.GdOrderIndex = OrderIndex++;
                            cellBLL.Update(cellMDL);
                        }
                        //要提示文件级的更新
                        BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                        MDL.T_FileList fileMDL = fileBLL.Find(MoveNode.Parent.Name, Globals.ProjectNO);
                        fileMDL.selected = 1;
                        fileBLL.Update(fileMDL);
                        UpdatePDFView((TreeNodeEx)NewNode.Parent);
                    }
                    this.treeRight.SelectedNode = NewNode;
                }
                else
                {
                    TXMessageBoxExtensions.Info("当前选择项不可以移动！");
                }
            }
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
        }
        /// <summary>
        /// 更新数据库中的节点顺序
        /// </summary>
        /// <param name="?"></param>
        private void UpdateNodeLevel(TreeNode Node)
        {
            //借此机会重排一下
            int OrderIndex = 1;
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            foreach (TreeNode obj in Node.Nodes)
            {
                MDL.T_FileList fileMDL = fileBLL.Find(obj.Name, Globals.ProjectNO);
                if (fileMDL == null)
                    continue;
                fileMDL.GdFileOrderIndex = OrderIndex++;
                //fileMDL.selected = 1;
                fileBLL.Update(fileMDL);
            }
        }
        private void UpdateNodeCellLevel(TreeNode Node)
        {
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            int OrderIndex = 1;
            foreach (TreeNode obj in Node.Nodes)
            {
                MDL.T_CellAndEFile cellMDL = cellBLL.Find(obj.Name, Globals.ProjectNO);
                cellMDL.GdOrderIndex = OrderIndex++;
                cellBLL.Update(cellMDL);
            }
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();

            MDL.T_FileList fileMDL = fileBLL.Find(Node.Name, Globals.ProjectNO);
            if (fileMDL != null)
            {
                fileMDL.selected = 1;
                fileBLL.Update(fileMDL);
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
                TreeImageList.TransparentColor = Color.Magenta;
                TreeImageList.ColorDepth = ColorDepth.Depth24Bit;
                ListDrivers();
                IsSource = true;
            }
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
                //ShowResources();
                TreeImageList.TransparentColor = Color.Magenta;
                TreeImageList.ColorDepth = ColorDepth.Depth24Bit;
                ListDrivers();
                IsSource = true;
            }
        }
        #region 资源管理器
        //private void ShowResources()
        //{
        //    TreeImageList.TransparentColor = Color.Magenta;
        //    TreeImageList.ColorDepth = ColorDepth.Depth24Bit;
        //    Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 15);
        //    TreeImageList.Images.Add(ic0);
        //    Icon ic1 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 5);
        //    TreeImageList.Images.Add(ic1);
        //    Icon ic2 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 7);
        //    TreeImageList.Images.Add(Properties.Resources.tree_folder);
        //    Icon ic3 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 11);
        //    TreeImageList.Images.Add(ic3);
        //    Icon ic4 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 3);
        //    TreeImageList.Images.Add(Properties.Resources.tree_folder);
        //    Icon ic5 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 4);
        //    TreeImageList.Images.Add(ic5);
        //    Icon ic6 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 101);
        //    TreeImageList.Images.Add(ic6);
        //    GetDrive();
        //    //ListDrivers();
        //    IsSource = true;
        //}
        //[DllImport("Shell32.dll")]
        //public static extern int ExtractIcon(IntPtr h, string strx, int ii);
        //[DllImport("Shell32.dll")]
        //public static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
        //public struct SHFILEINFO
        //{
        //    public IntPtr hIcon;
        //    public int iIcon;
        //    public uint dwAttributes;
        //    public char szDisplayName;
        //    public char szTypeName;
        //}
        //protected virtual Icon myExtractIcon(string FileName, int iIndex)
        //{
        //    try
        //    {
        //        IntPtr hIcon = (IntPtr)ExtractIcon(this.Handle, FileName, iIndex);
        //        if (!hIcon.Equals(null))
        //        {
        //            Icon icon = Icon.FromHandle(hIcon);
        //            return icon;
        //        }
        //    }
        //    catch (Exception ex)
        //    { 
        //        TXMessageBoxExtensions.Info(ex.Message, "错误提示", 0, MessageBoxIcon.Error); 
        //    }
        //    return null;
        //}
        //protected virtual void SetIcon(ImageList imageList, string FileName, bool tf)
        //{
        //    SHFILEINFO fi = new SHFILEINFO();
        //    if (tf == true)
        //    {
        //        int iTotal = (int)SHGetFileInfo(FileName, 0, ref fi, 100, 16640);//SHGFI_ICON|SHGFI_SMALLICON
        //        try
        //        {
        //            if (iTotal > 0)
        //            {
        //                Icon ic = Icon.FromHandle(fi.hIcon);
        //                imageList.Images.Add(ic);
        //            }
        //        }
        //        catch (Exception ex)
        //        { TXMessageBoxExtensions.Info(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
        //    }
        //    else
        //    {
        //        int iTotal = (int)SHGetFileInfo(FileName, 0, ref fi, 100, 257);
        //        try
        //        {
        //            if (iTotal > 0)
        //            {
        //                Icon ic = Icon.FromHandle(fi.hIcon);
        //                imageList.Images.Add(ic);
        //            }
        //        }
        //        catch (Exception ex)
        //        { TXMessageBoxExtensions.Info(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
        //    }
        //}
        //public void GetDrive()
        //{
        //    treeView1.ImageList = TreeImageList;
        //    treeView1.BeginUpdate();
        //    treeView1.Nodes.Clear();
        //    //TreeNode RootNode = new TreeNode("我的电脑", 0, 0);
        //    //treeView1.Nodes.Add(RootNode);
        //    int iImageIndex = 2; int iSelectedIndex = 2;
        //    string[] astrDrives = Directory.GetLogicalDrives();
        //    foreach (string str in astrDrives)
        //    {
        //        if (str == "A:\\")
        //        {
        //            iImageIndex = 1;
        //            iSelectedIndex = 1;
        //        }
        //        else if (str == "G:\\")
        //        {
        //            iImageIndex = 3;
        //            iSelectedIndex = 3;
        //        }
        //        else
        //        {
        //            iImageIndex = 2;
        //            iSelectedIndex = 2;
        //        }
        //        TreeNode tnDrive = new TreeNode(str, iImageIndex, iSelectedIndex);
        //        treeView1.Nodes.Add(tnDrive);
        //        //if (str == "C:\\")
        //        //{
        //        //    treeView1.SelectedNode = tnDrive;
        //        //}
        //    }
        //    TreeNode tnDrive1 = new TreeNode("桌面", 4, 4);
        //    treeView1.Nodes.Add(tnDrive1);

        //    foreach (TreeNode tn in treeView1.Nodes)
        //    {
        //        AddDirectories(tn);
        //    }

        //    treeView1.EndUpdate();
        //}

        //protected virtual void InitList(TreeNode tn)
        //{
        //    try
        //    {
        //        this.LisrimageList2.Images.Clear();
        //        this.LisrimageList.Images.Clear();
        //        Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 3);
        //        LisrimageList.Images.Add(ic0);
        //        LisrimageList2.Images.Add(ic0);
        //        string strPath = null;
        //        if (tn.Text.Equals("桌面") && tn.Level == 0)
        //        {
        //            strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        //            if (!System.IO.Directory.Exists(strPath))
        //                return;
        //        }
        //        else if (tn.FullPath.StartsWith("桌面"))
        //        {
        //            strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + tn.FullPath.Remove(0, 2);
        //            if (!System.IO.Directory.Exists(strPath))
        //                return;
        //        }
        //        else
        //            strPath = tn.FullPath;    

        //        DirectoryInfo curDir = new DirectoryInfo(strPath);//创建目录对象。
        //        FileInfo[] dirFiles;
        //        if (String.IsNullOrEmpty(curDir.Extension))
        //        {
        //            try
        //            {
        //                dirFiles = curDir.GetFiles();
        //            }
        //            catch 
        //            {
        //                return;
        //            }
        //            int iCount = 0; int iconIndex = 1;//用1，而不用0是要让过0号图标。
        //            foreach (FileInfo fileInfo in dirFiles)
        //            {
        //                string strFileName = fileInfo.Name;
        //                string str = fileInfo.FullName;
        //                try
        //                {
        //                    SetIcon(LisrimageList, str, false);
        //                    SetIcon(LisrimageList2, str, true);
        //                }
        //                catch (Exception ex)
        //                { 
        //                    TXMessageBoxExtensions.Info(ex.Message, "错误提示", 0, MessageBoxIcon.Error);
        //                }
        //                iCount++;
        //                iconIndex++;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    { TXMessageBoxExtensions.Info(ex.Message); }
        //}
        //private void treeView1_AfterSelect_1(object sender, System.Windows.Forms.TreeViewEventArgs e)
        //{
        //    if (e.Node.Text == "我的电脑")
        //    {
        //        return;
        //    }
        //    try
        //    {
        //        InitList(e.Node);
        //    }
        //    catch (Exception ex)
        //    {
        //        TXMessageBoxExtensions.Info(ex.Message);
        //    }
        //}
        //private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    try
        //    {
        //        this.listView1.Items.Clear();
        //        string strPath = null;
        //        DirectoryInfo dirinfo = null;
        //        if (e.Node.Text.Equals("桌面") && e.Node.Level == 0)
        //        {
        //            strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        //            if (!System.IO.Directory.Exists(strPath))
        //                return;
        //        }
        //        else if (e.Node.FullPath.StartsWith("桌面"))
        //        {
        //            strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + e.Node.FullPath.Remove(0, 2);
        //            if (!System.IO.Directory.Exists(strPath))
        //                return;
        //        }
        //        else
        //            strPath = e.Node.FullPath;
        //        if (System.IO.Directory.Exists(strPath))
        //            dirinfo = new DirectoryInfo(strPath);
        //        else
        //            return;

        //        FileInfo[] dirFiles;
        //        try
        //        {
        //            dirFiles = dirinfo.GetFiles();
        //        }
        //        catch (IOException ex)
        //        {
        //            return;
        //        }
        //        catch (UnauthorizedAccessException ex)
        //        {
        //            return;
        //        }
        //        catch (Exception ex)
        //        {
        //            return;
        //        }
        //        int iCount = 0;
        //        ImageList listSmall = new ImageList();
        //        ImageList listLarge = new ImageList();
        //        foreach (FileInfo fi in dirFiles)
        //        {
        //            if (MyCommon.CheckFileType(fi.Extension))
        //            {
        //                string str = fi.FullName;
        //                try
        //                {
        //                    SetIcon(listSmall, str, false);
        //                    SetIcon(listLarge, str, true);
        //                }
        //                catch (Exception ex)
        //                {
        //                    TXMessageBoxExtensions.Info(ex.Message, "错误提示", 0, MessageBoxIcon.Error);
        //                }
        //                string[] arrSubItem = new string[4];
        //                if (!fi.Name.Equals("pagefile.sys"))
        //                {
        //                    arrSubItem[0] = fi.Name;
        //                    arrSubItem[1] = fi.Length + " 字节";
        //                    arrSubItem[2] = fi.Extension;
        //                    arrSubItem[3] = fi.LastAccessTime.ToString();
        //                }
        //                else
        //                {
        //                    arrSubItem[0] = fi.Name;
        //                    arrSubItem[1] = "未知大小";
        //                    arrSubItem[2] = "未知日期";
        //                    arrSubItem[3] = "未知日期";
        //                }
        //                ListViewItem tnDir = new ListViewItem();
        //                tnDir.ImageIndex = iCount;
        //                tnDir.Name = str;
        //                tnDir.SubItems[0].Text = arrSubItem[0];
        //                tnDir.SubItems.Add(arrSubItem[1]);
        //                tnDir.SubItems.Add(arrSubItem[2]);
        //                tnDir.SubItems.Add(arrSubItem[3]);
        //                this.listView1.Items.Add(tnDir);

        //                if (DefaultListView != View.SmallIcon)
        //                {
        //                    listView1.View = DefaultListView;
        //                }
        //                else
        //                {
        //                    listView1.View = View.Details;
        //                }
        //                this.listView1.SmallImageList = listLarge;
        //                this.listView1.LargeImageList = listSmall;
        //                iCount++;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TXMessageBoxExtensions.Info(ex.Message);
        //    }
        //}
        //private void treeView1_BeforeExpand_1(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        //{
        //    try
        //    {
        //        treeView1.BeginUpdate();
        //        foreach (TreeNode tn in e.Node.Nodes)
        //        {
        //            //if (tn.FullPath.LastIndexOf("桌面") > 0)
        //            //{
        //            //    AddDirectories(tn, false);
        //            //}
        //            //else
        //            //{
        //            //    AddDirectories(tn, true);
        //            //}
        //            AddDirectories(tn);
        //        }
        //        treeView1.EndUpdate();
        //    }
        //    catch (Exception ex)
        //    {
        //        TXMessageBoxExtensions.Info(ex.Message, "错误提示", 0, MessageBoxIcon.Error);
        //    }
        //}
        //void AddDirectories(TreeNode tn)
        //{           
        //    string strPath = null;
        //    //if (flag)
        //    //{
        //    //    strPath = tn.FullPath;
        //    //    strPath = strPath.Remove(0, 5);
        //    //}
        //    //else
        //    //{
        //    //    strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + (tn.FullPath.Substring(tn.FullPath.LastIndexOf("桌面") + 2));
        //    //}

        //    if (tn.Text.Equals("桌面") && tn.Level == 1)
        //    {
        //        strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        //        if (!System.IO.Directory.Exists(strPath))
        //            return;
        //    }
        //    else if (tn.FullPath.StartsWith("桌面"))
        //    {
        //        strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + tn.FullPath.Remove(0, 2);
        //        if (!System.IO.Directory.Exists(strPath))
        //            return;
        //    }
        //    else
        //        strPath = tn.FullPath;
        //    if (!System.IO.Directory.Exists(strPath))
        //        return;
        //    tn.Nodes.Clear();

        //    DirectoryInfo dirinfo = new DirectoryInfo(strPath);
        //    DirectoryInfo[] adirinfo;
        //    try
        //    {
        //        adirinfo = dirinfo.GetDirectories();
        //    }
        //    catch
        //    {
        //        return;
        //    }
        //    int iImageIndex = 4; int iSelectedIndex = 5;
        //    foreach (DirectoryInfo di in adirinfo)
        //    {
        //        if (di.Name == "RECYCLER" || di.Name == "RECYCLED" || di.Name == "Recycled")
        //        {
        //            iImageIndex = 6; iSelectedIndex = 6;
        //        }
        //        else
        //        {
        //            iImageIndex = 4; iSelectedIndex = 5;
        //        }
        //        TreeNode tnDir = new TreeNode(di.Name, iImageIndex, iSelectedIndex);
        //        tn.Nodes.Add(tnDir);
        //    }
        //}
        #endregion

        #region 修改资源管理器显示
        //列出磁盘
        private void ListDrivers()
        {
            treeView1.Nodes.Clear();
            listView1.Items.Clear();
            DriveInfo[] drivers = DriveInfo.GetDrives();
            foreach (DriveInfo driver in drivers)
            {
                TreeNode node = treeView1.Nodes.Add(driver.Name);
                //ListViewItem item = listView1.Items.Add(driver.Name);
                //item.Name = driver.Name;
                //判断驱动器类型，用不同图标显示
                switch (driver.DriveType)
                {
                    case DriveType.CDRom:   //光驱
                        {
                            node.ImageIndex = 0;
                            node.SelectedImageIndex = 0;
                            //item.ImageIndex = 3;
                            break;
                        }
                    default:    //默认，显示为磁盘图标
                        {
                            node.ImageIndex = 1;
                            node.SelectedImageIndex = 1;
                            //item.ImageIndex = 1;
                            break;
                        }
                }
            }
            treeView1.Nodes.Add("桌面");
            foreach (TreeNode node in treeView1.Nodes)
            {
                NodeUpdate(node);
            }
        }
        /// <summary>
        /// 更新结点(列出当前目录下的子目录)
        /// </summary>
        /// <param name="node"></param>
        private void NodeUpdate(TreeNode node)
        {
            try
            {
                node.Nodes.Clear();
                if (node.FullPath == "桌面" && node.Level == 0)
                {
                    DirectoryInfo dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo d in dirs)
                    {
                        node.Nodes.Add(d.Name);
                    }
                }
                if (node.FullPath.StartsWith("桌面") && node.Level != 0)
                {
                    string DestTopDirPath = node.FullPath.Remove(0, 2);
                    DirectoryInfo dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + DestTopDirPath);
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo d in dirs)
                    {
                        node.Nodes.Add(d.Name);
                    }
                }
                else
                {
                    DirectoryInfo dir = new DirectoryInfo(node.FullPath);
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo d in dirs)
                    {
                        node.Nodes.Add(d.Name);
                    }
                }
            }
            catch (IOException ex)
            {
                //设备未就绪
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                //无访问权限
                return;
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info("错误：" + ex.Message);
            }
        }
        /// <summary>
        /// 更新列表(列出当前目录下的目录和文件)
        /// </summary>
        /// <param name="newPath"></param>
        private void ListUpdate(string newPath)
        {
            if (newPath == "")
                ListDrivers();
            else
            {
                try
                {
                    this.listView1.Items.Clear();
                    DirectoryInfo currentDir = new DirectoryInfo(newPath);
                    FileInfo[] files = currentDir.GetFiles();   //获取文件     

                    if (files != null && files.Length > 0)
                        Array.Sort(files, (x1, x2) => x1.Name.PadLeft(10, '0').CompareTo(x2.Name.PadLeft(10, '0')));


                    //列出文件
                    ImageList listSmall = new ImageList();
                    ImageList listLarge = new ImageList();
                    foreach (FileInfo fi in files)
                    {
                        if (MyCommon.CheckFileType(fi.Extension))
                        {
                            string str = fi.FullName;
                            string[] arrSubItem = new string[4];
                            if (!fi.Name.Equals("pagefile.sys"))
                            {
                                arrSubItem[0] = fi.Name;
                                arrSubItem[1] = fi.Length + " 字节";
                                arrSubItem[2] = fi.Extension;
                                arrSubItem[3] = fi.LastAccessTime.ToString();
                            }
                            else
                            {
                                arrSubItem[0] = fi.Name;
                                arrSubItem[1] = "未知大小";
                                arrSubItem[2] = "未知类型";
                                arrSubItem[3] = "未知日期";
                            }

                            if (!listSmall.Images.ContainsKey(fi.Extension))  //ImageList中不存在此类图标
                            {
                                Icon fileIcon = GetSystemIcon.GetIconByFileName(fi.FullName);
                                listSmall.Images.Add(fi.Extension, fileIcon);
                                listLarge.Images.Add(fi.Extension, fileIcon);
                            }
                            ListViewItem tnDir = new ListViewItem();
                            tnDir.ImageKey = fi.Extension;
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
                        }
                    }
                }
                catch (Exception ex)
                {
                    TXMessageBoxExtensions.Question(ex.Message);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
            string dirInfo_temp = null;
            if (e.Node.Text.Equals("桌面") && e.Node.Level == 0)
            {
                dirInfo_temp = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                if (!System.IO.Directory.Exists(dirInfo_temp))
                    return;
            }
            else if (e.Node.FullPath.StartsWith("桌面"))
            {
                dirInfo_temp = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + e.Node.FullPath.Remove(0, 2);
                if (!System.IO.Directory.Exists(dirInfo_temp))
                    return;
            }
            else
                dirInfo_temp = e.Node.FullPath;

            //dirInfo_temp=e.Node.FullPath;
            ListUpdate(dirInfo_temp);
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            NodeUpdate(e.Node); //更新当前结点
            foreach (TreeNode node in e.Node.Nodes) //更新所有子结点
            {
                NodeUpdate(node);
            }
        }

        #endregion

        private void treeFile_MouseDown(object sender, MouseEventArgs e)
        {
            TreeOrList = 1;
        }
        private void treeRight_MouseDown(object sender, MouseEventArgs e)
        {
            TreeOrList = 0;
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
        /// 目录当前状态 默认"" 全部
        /// </summary>
        string TreeNodeState_flg = "";
        /// <summary>
        /// 有电子文件的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drptsmiNoAttachment_Click(object sender, EventArgs e)
        {
            string where = "filestatus=2";
            treeFactory.GetTree(treeRight, Globals.ProjectNO, where, true, true, 2, true, isdy);
            this.drpFileStatus.Text = drpFileStaus2.Text;
            TreeNodeState_flg = "filestatus=2";
        }
        /// <summary>
        /// 已登记的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drptsmiNoRegost_Click(object sender, EventArgs e)
        {
            string where = "filestatus=4";
            treeFactory.GetTree(treeRight, Globals.ProjectNO, where, true, true, 2, true, isdy);
            this.drpFileStatus.Text = drpFileStaus4.Text;
            TreeNodeState_flg = "filestatus=4";
        }
        /// <summary>
        /// 未组卷的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drptsmiNoPaper_Click(object sender, EventArgs e)
        {
            string where = "filestatus in('0','1','2','3','4','5')";
            treeFactory.GetTree(treeRight, Globals.ProjectNO, where, true, true, 2, true, isdy);
            this.drpFileStatus.Text = drpFileStaus5.Text;
            TreeNodeState_flg = "filestatus in('0','1','2','3','4','5')";
        }
        /// <summary>
        /// 组卷的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drptsmiIsPaper_Click(object sender, EventArgs e)
        {
            string where = "filestatus=6";
            treeFactory.GetTree(treeRight, Globals.ProjectNO, where, true, true, 2, true, isdy);
            this.drpFileStatus.Text = drpFileStaus6.Text;
            TreeNodeState_flg = "filestatus=6";
        }
        /// <summary>
        /// 全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drptsmiIsFull_Click(object sender, EventArgs e)
        {
            isdy = 3;
            treeFactory.GetTree(treeRight, Globals.ProjectNO, "", true, true, 2, true, isdy);
            this.drpFileStatus.Text = drpFileStaus0.Text;
            TreeNodeState_flg = "";

        }
        /// <summary>
        /// 过滤条件 系统条目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpFileStaus7_Click(object sender, EventArgs e)
        {
            isdy = 0;
            treeFactory.GetTree(treeRight, Globals.ProjectNO, " IsUseDefined = 0", true, true, 2, true, isdy);
            this.drpFileStatus.Text = drpFileStaus7.Text;
            TreeNodeState_flg = "";

        }
        /// <summary>
        /// 过滤条件 自定义条目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpFileStaus8_Click(object sender, EventArgs e)
        {
            isdy = 1;
            treeFactory.GetTree(treeRight, Globals.ProjectNO, " IsUseDefined = 1", true, true, 2, true, isdy);
            this.drpFileStatus.Text = drpFileStaus8.Text;
            TreeNodeState_flg = "";

        }
        /// <summary>
        /// 无电子文件的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string where = "filestatus=1";
            treeFactory.GetTree(treeRight, Globals.ProjectNO, where, true, true, 2, true, isdy);
            this.drpFileStatus.Text = drpFileStaus1.Text;
            TreeNodeState_flg = "filestatus=1";
        }
        /// <summary>
        /// 未登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string where = "filestatus in ('0','1','2','3','5')";

            treeFactory.GetTree(treeRight, Globals.ProjectNO, where, true, true, 2, true, isdy);
            this.drpFileStatus.Text = drpFileStaus3.Text;
            TreeNodeState_flg = "filestatus in ('0','1','2','3','5')";
        }
        public bool RegistFirst = false;
        /// <summary>
        /// 快速查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
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
        /// 重命名节点操作
        /// </summary>
        private void RenameNodetext(string NewText)
        {
            if (!String.IsNullOrEmpty(NewText))
            {
                if (MyCommon.HasFilterChars(NewText))
                {
                    TXMessageBoxExtensions.Info("不能包含有" + MyCommon.Chars2String() + "等字符！");
                    return;
                }
                frmReName frm = new frmReName((TreeNodeEx)this.treeRight.SelectedNode);
                frm.Save(NewText);
            }
        }
        /// <summary>
        /// 是否跳到下一节点判断变量
        /// </summary>
        bool isNextNode_flg = true;
        private void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.treeRight.SelectedNode;
            if (theNode == null || theNode.ImageIndex == 1 || theNode.ImageIndex == 0 || theNode.ImageIndex == 3
                || (theNode.Text.Trim() == "最近著录过的文件") || (theNode.Parent != null &&
                theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件！");
                return;
            }
            Globals.ZRR = fileBaseInfo.cmbzrz.SelectedText;
            isNextNode_flg = true;
            btnSave_Click(sender, e);

            if (theNode != null && isNextNode_flg && theNode.NextNode != null)
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
            //foreach (TreeNodeEx obj in currentNode.Nodes)
            //{
            //    if (obj.Nodes.Count < 1)
            //    {
            //        int iTag = 0;
            //        if (obj.Tag != null)
            //        {
            //            iTag = int.Parse(obj.Tag.ToString());
            //        }
            //        treeFactory.LoadFileChildNodes(obj.Nodes, obj.Name, iTag, 2);
            //    }
            //}
        }
        private void treeRight_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //ExpendNode(e.Node);
            if (e.Node.Level != 2)
                return;
            if (e.Node.Nodes.Count <= 0)
            {
                BLL.T_CellAndEFile_BLL cellFile = new ERM.BLL.T_CellAndEFile_BLL();
                IList<MDL.T_CellAndEFile> cellList =
                    cellFile.FindByGdFileID(e.Node.Name, Globals.ProjectNO);

                foreach (MDL.T_CellAndEFile obj in cellList)
                {
                    TreeNodeEx cnode = new TreeNodeEx();
                    cnode.Text = obj.title;
                    cnode.Name = obj.CellID;
                    cnode.NodeValue = obj.filepath;
                    cnode.ImageIndex = 3;
                    cnode.SelectedImageIndex = 3;
                    e.Node.Nodes.Add(cnode);
                }
                e.Node.ExpandAll();
            }
            else
            {
                BLL.T_CellAndEFile_BLL cellFile = new ERM.BLL.T_CellAndEFile_BLL();
                IList<MDL.T_CellAndEFile> cellList =
                    cellFile.FindByGdFileID(e.Node.Name, Globals.ProjectNO);
                if (cellList.Count != e.Node.Nodes.Count)
                {
                    e.Node.Nodes.Clear();
                    foreach (MDL.T_CellAndEFile obj in cellList)
                    {
                        TreeNodeEx cnode = new TreeNodeEx();
                        cnode.Text = obj.title;
                        cnode.Name = obj.CellID;
                        cnode.NodeValue = obj.filepath;
                        cnode.ImageIndex = 3;
                        cnode.SelectedImageIndex = 3;
                        e.Node.Nodes.Add(cnode);
                    }
                    e.Node.ExpandAll();
                }
            }
        }
        private void ts_SavaItem_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
        }

        private void treeRight_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode curNode = treeRight.SelectedNode;
            if (curNode != null)
            {
                if ((curNode.ImageIndex == 2 || curNode.ImageIndex == 5 || curNode.ImageIndex == 7)
                    && curNode.Parent != null && curNode.Parent.Text.Trim() != "最近著录过的文件")
                {
                    if (fileBaseInfo.btnbEnableQuickInput.Checked == true)
                        btnSave_Click(null, null);
                    else if (fileBaseInfo.isUpdateInfo_flg)
                    {
                        string showText = "[" + this.treeRight.SelectedNode.Text.Substring(this.treeRight.SelectedNode.Text.LastIndexOf("]") + 1) + "]";
                        DialogResult dirsult = TXMessageBoxExtensions.Question("提示：节点：" + showText + " 的内容已经改变   \n 是否保存改变内容？");
                        if (dirsult == DialogResult.OK)
                            btnSave_Click(null, null);
                        else if (dirsult != DialogResult.Cancel && e != null)
                            e.Cancel = true;
                    }
                }
            }
        }
        /// <summary>
        /// 重新生成PDF 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCreateEFile_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.treeRight.SelectedNode;
            if (theNode == null || theNode.ImageIndex == 1 || theNode.ImageIndex == 0
                || (theNode.Text.Trim() == "最近著录过的文件") || (theNode.Parent != null &&
                theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件或电子文件生成PDF！");
                return;
            }

            if (theNode.ImageIndex == 3)
            {
                DialogResult diaresult = TXMessageBoxExtensions.Question("提示：确定将电子文件：" + theNode.Text + " 重新生成PDF文件吗？");
                if (diaresult == DialogResult.OK)
                    ConvertEFileToPDF(theNode.Name);
            }
            else
            {
                string showText = "[" + theNode.Text.Substring(theNode.Text.LastIndexOf("]") + 1) + "]";
                DialogResult diaresult = TXMessageBoxExtensions.Question("提示：确定将节点 " + showText + " 重新生成PDF文件吗？");
                if (diaresult == DialogResult.OK)
                {
                    ConvertAllEFileToPDF((TreeNodeEx)theNode);
                    treeRightAfterSelect();
                }
            }
        }

        /// <summary>
        /// 重新生成PDF
        /// </summary>
        /// <param name="FileID">节点ID</param>
        private void ConvertAllEFileToPDF(TreeNodeEx theNode)
        {
            string FileID = theNode.Name;
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            MDL.T_FileList fileMDL = fileBLL.Find(FileID, Globals.ProjectNO);
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            IList<MDL.T_CellAndEFile> cellList =
                cellBLL.FindByGdFileID(FileID, Globals.ProjectNO);

            System.Collections.ArrayList fileArryList = new ArrayList();

            frm2PDFProgressMsg dfmsg = null;
            if (cellList != null && cellList.Count > 0)
            {
                dfmsg = new frm2PDFProgressMsg();
                dfmsg.progressBar1.Maximum = cellList.Count;
                dfmsg.label2.Text = "正在转换 0/" + cellList.Count;
                dfmsg.Show();
            }

            int curIndex = 1;

            foreach (MDL.T_CellAndEFile cellMDL in cellList)
            {
                dfmsg.label2.Text = "正在转换 " + curIndex + "/" + cellList.Count;
                dfmsg.progressBar1.Value = curIndex;
                Application.DoEvents();

                curIndex++;
                string pdfPath = "";

                //if (axpdfInterface1.FileName != null && axpdfInterface1.FileName.Length > 0)
                //    axpdfInterface1.CloseFile();

                using (ConvertCell2PDF c1 = new ConvertCell2PDF(false))
                {
                    #region
                    /*暂时屏蔽掉，验证当个PDF的功能
                     */
                    //System.IO.FileInfo fileInfo = new System.IO.FileInfo(Globals.ProjectPath + cellMDL.filepath);
                    //if (fileInfo.Extension.ToLower() == ".pdf")
                    //{
                    //    if (!c1.CheckPDF(Globals.ProjectPath + cellMDL.filepath))
                    //    {
                    //        if (dfmsg != null)
                    //        {
                    //            dfmsg.Dispose();
                    //            dfmsg.Close();
                    //        }
                    //        TXMessageBoxExtensions.Info("提示：[ " + cellMDL.title + " ]无法进行PDF合并，请确认此文件是否有误！");
                    //        fileArryList.Clear();
                    //        break;
                    //    }
                    //}
                    #endregion

                    try
                    {
                        if (cellMDL.DocYs == null || cellMDL.DocYs == 1 || cellMDL.fileTreePath == String.Empty || cellMDL.fileTreePath == "")
                        {
                            int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath, Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".pdf");
                            if (iPageCount == 0)
                                cellMDL.fileTreePath = "";
                            else
                                cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".pdf";
                            cellMDL.DocYs = 0;
                            cellMDL.DoStatus = 1;
                            cellMDL.ys = iPageCount;
                            cellBLL.Update(cellMDL);
                        }
                    }
                    catch (Exception e)
                    {
                        cellMDL.fileTreePath = "";
                        MyCommon.WriteLog("PDF转换失败！错误信息：" + e.Message);
                    }
                    pdfPath = cellMDL.fileTreePath;
                }

                if (!System.IO.File.Exists(Globals.ProjectPath + pdfPath))
                {
                    continue;
                }
                fileArryList.Add(Globals.ProjectPath + pdfPath);
            }
            string[] FileList = new string[fileArryList.Count];
            for (int i = 0; i < fileArryList.Count; i++)
            {
                FileList[i] = fileArryList[i].ToString();
            }
            using (ConvertCell2PDF c1 = new ConvertCell2PDF())
            {
                int iPageCount = 0;
                if (FileList.Length > 0)
                {
                    try
                    {
                        iPageCount = c1.MergePDF(FileList, Globals.ProjectPath + "MPDF\\" + FileID + ".pdf");

                        if (iPageCount == 0)
                            fileMDL.filepath = "";
                        else
                            fileMDL.filepath = "MPDF\\" + FileID + ".pdf";
                    }
                    catch (Exception ex)
                    {
                        iPageCount = 0;
                        fileMDL.filepath = "";
                        MyCommon.WriteLog("合并PDF失败！错误信息：" + ex.Message);
                    }
                }
                else
                {
                    fileMDL.filepath = "";
                }
                if (dfmsg != null)
                {
                    dfmsg.Close();
                }
                //fileMDL.sl = iPageCount;

                //1 文字数量  2声像 3照片数量
                bool update_flg = this.fileBaseInfo.isUpdateInfo_flg;
                int EFileType_flg = 1;
                MyCommon.GetParentNodeType((TreeNode)theNode, ref EFileType_flg);
                if (EFileType_flg == 1)
                {
                    fileMDL.sl = iPageCount;
                    this.fileBaseInfo.sl.Text = iPageCount.ToString();
                }
                else if (EFileType_flg == 3)
                {
                    int tzz = MyCommon.ToInt(this.fileBaseInfo.tzz.Text.Trim());
                    int dtz = MyCommon.ToInt(this.fileBaseInfo.dtz.Text.Trim());
                    int zpz = MyCommon.ToInt(this.fileBaseInfo.zpz.Text.Trim());
                    int dpz = MyCommon.ToInt(this.fileBaseInfo.dpz.Text.Trim());

                    fileMDL.dw = (iPageCount + dtz).ToString();
                    // this.fileBaseInfo.dw.Text = fileMDL.dw;
                    fileMDL.tzz = (iPageCount).ToString();
                    this.fileBaseInfo.tzz.Text = fileMDL.tzz;
                    fileMDL.dtz = dtz.ToString();

                    fileMDL.wzz = (zpz + dpz).ToString();
                    // this.fileBaseInfo.wzz.Text = fileMDL.wzz;
                    fileMDL.zpz = zpz.ToString();
                    fileMDL.dpz = dpz.ToString();
                }
                else if (EFileType_flg == 2)
                {
                    int tzz = MyCommon.ToInt(this.fileBaseInfo.tzz.Text.Trim());
                    int dtz = MyCommon.ToInt(this.fileBaseInfo.dtz.Text.Trim());
                    int zpz = MyCommon.ToInt(this.fileBaseInfo.zpz.Text.Trim());
                    int dpz = MyCommon.ToInt(this.fileBaseInfo.dpz.Text.Trim());

                    fileMDL.dw = (tzz + dtz).ToString();
                    // this.fileBaseInfo.dw.Text = fileMDL.dw;
                    fileMDL.tzz = tzz.ToString();
                    fileMDL.dtz = dtz.ToString();

                    fileMDL.wzz = (iPageCount + dpz).ToString();
                    //  this.fileBaseInfo.wzz.Text = fileMDL.wzz;
                    fileMDL.zpz = (iPageCount).ToString();
                    this.fileBaseInfo.zpz.Text = fileMDL.zpz;
                    fileMDL.dpz = dpz.ToString();
                }
                this.fileBaseInfo.isUpdateInfo_flg = update_flg;
                fileMDL.selected = 0;
                fileBLL.Update(fileMDL);
            }

            ShowPDF(Globals.ProjectPath + fileMDL.filepath, true);
        }
        /// <summary>
        /// 根据文件ID 合并PDF
        /// </summary>
        /// <param name="FileID">文件ID</param>
        /// <returns>文件PDF路径</returns>
        private string ConvertFile2PDF2(string FileID)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            MDL.T_FileList fileMDL = fileBLL.Find(FileID, Globals.ProjectNO);
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();

            //IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByFileIDAndNOCell(FileID, Globals.ProjectNO);
            IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByGdFileID(FileID, Globals.ProjectNO);

            System.Collections.ArrayList fileArryList = new System.Collections.ArrayList();

            bool isUpdateFileSelect_flg = false;
            foreach (MDL.T_CellAndEFile cellMDL in cellList)
            {
                string pdfPath = "";
                if (cellMDL.DocYs == null || cellMDL.DocYs == 1 || cellMDL.fileTreePath == String.Empty || cellMDL.fileTreePath == "")
                {
                    if (!isUpdateFileSelect_flg)
                        isUpdateFileSelect_flg = true;

                    using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                    {
                        #region
                        /*暂时屏蔽掉，验证当个PDF的功能
                         */
                        //System.IO.FileInfo fileInfo = new System.IO.FileInfo(Globals.ProjectPath + cellMDL.filepath);
                        //if (fileInfo.Extension.ToLower() == ".pdf")
                        //{
                        //    if (!c1.CheckPDF(Globals.ProjectPath + cellMDL.filepath))
                        //    {
                        //        TXMessageBoxExtensions.Info("提示：[ " + cellMDL.title + " ]无法进行PDF合并，请确认此文件是否有误！");
                        //        fileArryList.Clear();
                        //        break;
                        //    }
                        //}
                        #endregion

                        try
                        {
                            int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath, Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".pdf");
                            if (iPageCount != 0)
                                cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".pdf";
                            else
                                cellMDL.fileTreePath = "";
                            cellMDL.DocYs = 0;
                            cellMDL.DoStatus = 1;
                            cellMDL.ys = iPageCount;
                            cellBLL.Update(cellMDL);
                        }
                        catch (Exception e)
                        {
                            cellMDL.fileTreePath = "";
                            MyCommon.WriteLog("转换PDF失败！错误信息：" + e.Message);
                        }
                        pdfPath = cellMDL.fileTreePath;
                    }
                }
                else
                {
                    pdfPath = cellMDL.fileTreePath;
                    if (!System.IO.File.Exists(Globals.ProjectPath + pdfPath)
                        && !string.IsNullOrWhiteSpace(cellMDL.fileTreePath))
                    {
                        if (!isUpdateFileSelect_flg)
                            isUpdateFileSelect_flg = true;
                        using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                        {
                            try
                            {
                                int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath,
                                    Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".pdf");
                                if (iPageCount == 0)
                                    cellMDL.fileTreePath = "";
                                else
                                    cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".pdf";
                                cellMDL.DocYs = 0;
                                cellMDL.DoStatus = 1;
                                cellMDL.ys = iPageCount;
                                cellBLL.Update(cellMDL);
                            }
                            catch (Exception e)
                            {
                                cellMDL.fileTreePath = "";
                                MyCommon.WriteLog("PDF转换失败！错误信息：" + e.Message);
                            }
                            pdfPath = cellMDL.fileTreePath;
                        }
                    }
                }

                if (!System.IO.File.Exists(Globals.ProjectPath + pdfPath))
                {
                    continue;
                }
                fileArryList.Add(Globals.ProjectPath + pdfPath);
            }

            string[] FileList = new string[fileArryList.Count];

            for (int i = 0; i < fileArryList.Count; i++)
            {
                FileList[i] = fileArryList[i].ToString();
            }
            using (ConvertCell2PDF c1 = new ConvertCell2PDF())
            {
                int iPageCount = 0;
                if (FileList.Length > 0)
                {
                    try
                    {
                        iPageCount = c1.MergePDF(FileList, Globals.ProjectPath + "MPDF\\" + FileID + ".pdf");
                        fileMDL.filepath = "MPDF\\" + FileID + ".pdf";
                    }
                    catch (Exception e)
                    {
                        iPageCount = 0;
                        fileMDL.filepath = "";
                        MyCommon.WriteLog("合并PDF失败！错误信息：" + e.Message);
                    }
                }
                else
                {
                    fileMDL.filepath = "";
                }
                //fileMDL.sl = iPageCount;

                //1 文字数量  2声像 3照片数量
                int EFileType_flg = 1;
                TreeFactory treeFactory = new TreeFactory();
                treeFactory.GetParentNodeType(FileID, ref EFileType_flg);

                if (EFileType_flg == 1)
                    fileMDL.sl = iPageCount;
                else if (EFileType_flg == 3)
                {
                    int tzz = MyCommon.ToInt(fileMDL.tzz);
                    int dtz = MyCommon.ToInt(fileMDL.dtz);
                    int zpz = MyCommon.ToInt(fileMDL.zpz);
                    int dpz = MyCommon.ToInt(fileMDL.dpz);

                    fileMDL.dw = (iPageCount + dtz).ToString();
                    fileMDL.tzz = (iPageCount).ToString();
                    fileMDL.dtz = dtz.ToString();

                    fileMDL.wzz = (zpz + dpz).ToString();
                    fileMDL.zpz = zpz.ToString();
                    fileMDL.dpz = dpz.ToString();
                }
                else if (EFileType_flg == 2)
                {
                    int tzz = MyCommon.ToInt(fileMDL.tzz);
                    int dtz = MyCommon.ToInt(fileMDL.dtz);
                    int zpz = MyCommon.ToInt(fileMDL.zpz);
                    int dpz = MyCommon.ToInt(fileMDL.dpz);

                    fileMDL.dw = (tzz + dtz).ToString();
                    fileMDL.tzz = tzz.ToString();
                    fileMDL.dtz = dtz.ToString();

                    fileMDL.wzz = (iPageCount + dpz).ToString();
                    fileMDL.zpz = iPageCount.ToString();
                    fileMDL.dpz = dpz.ToString();
                }

                fileMDL.selected = 0;
                fileBLL.Update(fileMDL);
            }
            return fileMDL.filepath;
        }
        /// <summary>
        /// 重新将一份电子文件重新生成PDF
        /// </summary>
        /// <param name="CellID"></param>
        private void ConvertEFileToPDF(string CellID)
        {
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            MDL.T_CellAndEFile cellMDL = cellBLL.Find(CellID, Globals.ProjectNO);
            if (cellMDL != null)
            {
                //if (axpdfInterface1.FileName != null && axpdfInterface1.FileName.Length > 0)
                //    axpdfInterface1.CloseFile();


                ERM.BLL.T_FileList_BLL FileList_BLL = new ERM.BLL.T_FileList_BLL();
                MDL.T_FileList fileMDL = (FileList_BLL).Find(cellMDL.GdFileID, Globals.ProjectNO);
                //判断是否签过章
                using (ConvertCell2PDF cl = new ConvertCell2PDF())
                {
                    if (cl.GetPDFKEYCount(Globals.ProjectPath + fileMDL.filepath) > 0)
                    {
                        if (TXMessageBoxExtensions.Question("提示：此文件 " + fileMDL.wjtm + " \n 已签过章，如果重新生成PDF，此前的签章就会失效，确定继续操作吗？") != DialogResult.OK)
                            return;
                    }
                }
                using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                {
                    #region
                    /*暂时屏蔽掉，验证当个PDF的功能
                     */
                    //System.IO.FileInfo fileInfo = new System.IO.FileInfo(Globals.ProjectPath + cellMDL.filepath);
                    //if (fileInfo.Extension.ToLower() == ".pdf")
                    //{
                    //    if (!c1.CheckPDF(Globals.ProjectPath + cellMDL.filepath))
                    //    {
                    //        TXMessageBoxExtensions.Info("提示：[ " + cellMDL.title + " ]无法进行PDF合并，请确认此文件是否有误！");
                    //        return;
                    //    }
                    //}
                    #endregion
                    try
                    {
                        int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath, Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".pdf");
                        if (iPageCount == 0)
                            cellMDL.fileTreePath = "";
                        else
                            cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".pdf";
                        cellMDL.DocYs = 0;
                        cellMDL.DoStatus = 1;
                        cellMDL.ys = iPageCount;
                        cellBLL.Update(cellMDL);

                        fileMDL.selected = 1;//有新内容,有日期型数据有错。
                        (FileList_BLL).Update(fileMDL);
                    }
                    catch (Exception e)
                    {
                        cellMDL.fileTreePath = "";
                        MyCommon.WriteLog("PDF转换失败！错误信息：" + e.Message);
                    }
                }

                ShowPDF(Globals.ProjectPath + cellMDL.fileTreePath, false);
            }
        }
        private string ConvertCell2PDF(string CellID)
        {
            string PDFFileName = "";
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            MDL.T_CellAndEFile cellMDL = cellBLL.Find(CellID, Globals.ProjectNO);
            if (cellMDL != null)
            {
                ERM.BLL.T_FileList_BLL FileList_BLL = new ERM.BLL.T_FileList_BLL();
                MDL.T_FileList fileMDL = (FileList_BLL).Find(cellMDL.FileID, Globals.ProjectNO);

                if (cellMDL.DocYs == null || cellMDL.DocYs == 1 || cellMDL.fileTreePath == String.Empty || cellMDL.fileTreePath == "")
                {
                    //if (axpdfInterface1.FileName != null && axpdfInterface1.FileName.Length > 0)
                    //    axpdfInterface1.CloseFile();

                    using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                    {
                        try
                        {
                            int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath, Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".pdf");
                            if (iPageCount == 0)
                                cellMDL.fileTreePath = "";
                            else
                                cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".pdf";
                            cellMDL.DocYs = 0;
                            cellMDL.DoStatus = 1;
                            cellMDL.ys = iPageCount;
                            cellBLL.Update(cellMDL);

                            fileMDL.selected = 1;//有新内容,有日期型数据有错。
                            (FileList_BLL).Update(fileMDL);
                        }
                        catch (Exception e)
                        {
                            cellMDL.fileTreePath = "";
                            MyCommon.WriteLog("PDF转换失败！错误信息：" + e.Message);
                        }
                        PDFFileName = cellMDL.fileTreePath;
                    }
                }
                else
                {
                    PDFFileName = cellMDL.fileTreePath;
                    if (!System.IO.File.Exists(Globals.ProjectPath + PDFFileName)
                       && !string.IsNullOrWhiteSpace(cellMDL.fileTreePath))
                    {
                        using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                        {
                            try
                            {
                                int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath,
                                    Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".pdf");
                                if (iPageCount == 0)
                                    cellMDL.fileTreePath = "";
                                else
                                    cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".pdf";
                                cellMDL.DocYs = 0;
                                cellMDL.DoStatus = 1;
                                cellMDL.ys = iPageCount;
                                cellBLL.Update(cellMDL);
                            }
                            catch (Exception e)
                            {
                                cellMDL.fileTreePath = "";
                                MyCommon.WriteLog("PDF转换失败！错误信息：" + e.Message);
                            }
                            PDFFileName = cellMDL.fileTreePath;
                        }
                    }
                }
            }
            return PDFFileName;
        }
        private string ConvertFile2PDF(TreeNodeEx theNode, string filetype = "")
        {
            string FileID = theNode.Name;
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            MDL.T_FileList fileMDL = fileBLL.Find(FileID, Globals.ProjectNO);
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByGdFileID(FileID, Globals.ProjectNO);

            System.Collections.ArrayList fileArryList = new ArrayList();

            bool isUpdateFileSelect_flg = false;
            frm2PDFProgressMsg dfmsg = null;

            #region add
            if (fileMDL == null)
            {
                return "";
            }
            #endregion

            if (fileMDL.selected == 1 && cellList != null && cellList.Count > 0)
            {
                dfmsg = new frm2PDFProgressMsg();
                dfmsg.progressBar1.Maximum = cellList.Count;
                dfmsg.label2.Text = "正在转换 0/" + cellList.Count;
                dfmsg.Show();
                isUpdateFileSelect_flg = true;
            }
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
                        Thread.Sleep(200);
                    }
                }
                curIndex++;
                string pdfPath = "";
                if (cellMDL.DocYs == null || cellMDL.DocYs == 1 || cellMDL.fileTreePath == String.Empty || cellMDL.fileTreePath == "")
                {
                    if (!isUpdateFileSelect_flg)
                        isUpdateFileSelect_flg = true;

                    //if (axpdfInterface1.FileName != null && axpdfInterface1.FileName.Length > 0)
                    //    axpdfInterface1.CloseFile();

                    using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                    {
                        try
                        {
                            int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath,
                                Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".pdf");
                            if (iPageCount == 0)
                                cellMDL.fileTreePath = "";
                            else
                                cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".pdf";
                            cellMDL.DocYs = 0;
                            cellMDL.DoStatus = 1;
                            cellMDL.ys = iPageCount;
                            cellBLL.Update(cellMDL);
                        }
                        catch (Exception e)
                        {
                            cellMDL.fileTreePath = "";
                            MyCommon.WriteLog("PDF转换失败！错误信息：" + e.Message);
                        }
                        pdfPath = cellMDL.fileTreePath;
                    }
                }
                else
                {
                    pdfPath = cellMDL.fileTreePath;
                    if (!System.IO.File.Exists(Globals.ProjectPath + pdfPath)
                        && !string.IsNullOrWhiteSpace(cellMDL.fileTreePath))
                    {
                        if (!isUpdateFileSelect_flg)
                            isUpdateFileSelect_flg = true;
                        using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                        {
                            try
                            {
                                int iPageCount = 0;
                                iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cellMDL.filepath,
                                   Globals.ProjectPath + "PDF\\" + cellMDL.CellID + ".pdf");

                                if (iPageCount == 0)
                                    cellMDL.fileTreePath = "";
                                else
                                    cellMDL.fileTreePath = "PDF\\" + cellMDL.CellID + ".pdf";
                                cellMDL.DocYs = 0;
                                cellMDL.DoStatus = 1;
                                cellMDL.ys = iPageCount;
                                cellBLL.Update(cellMDL);
                            }
                            catch (Exception e)
                            {
                                cellMDL.fileTreePath = "";
                                MyCommon.WriteLog("PDF转换失败！错误信息：" + e.Message);
                            }
                            pdfPath = cellMDL.fileTreePath;
                        }
                    }
                }

                if (!System.IO.File.Exists(Globals.ProjectPath + pdfPath))
                {
                    continue;
                }
                fileArryList.Add(Globals.ProjectPath + pdfPath);
            }
            if (dfmsg != null)
            {
                dfmsg.Close();
            }
            if (!isUpdateFileSelect_flg
                && (cellList == null || cellList.Count == 0
                || string.IsNullOrWhiteSpace(fileMDL.filepath)
                || !System.IO.File.Exists(Globals.ProjectPath + fileMDL.filepath)
                ))
            {
                isUpdateFileSelect_flg = true;
            }
            if (isUpdateFileSelect_flg)
            {
                string[] FileList = new string[fileArryList.Count];
                for (int i = 0; i < fileArryList.Count; i++)
                {
                    FileList[i] = fileArryList[i].ToString();
                }
                using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                {
                    int iPageCount = 0;
                    if (FileList.Length > 0)
                    {
                        try
                        {
                            iPageCount = c1.MergePDF(FileList, Globals.ProjectPath + "MPDF\\" + FileID + ".pdf");

                            if (iPageCount == 0)
                                fileMDL.filepath = "";
                            else
                                fileMDL.filepath = "MPDF\\" + FileID + ".pdf";
                        }
                        catch (Exception e)
                        {
                            iPageCount = 0;
                            fileMDL.filepath = "";
                            MyCommon.WriteLog("PDF合并失败！错误信息：" + e.Message);
                        }
                    }
                    else
                    {
                        fileMDL.filepath = "";
                    }
                    //1 文字数量  2声像 3照片数量
                    bool update_flg = this.fileBaseInfo.isUpdateInfo_flg;
                    int EFileType_flg = 1;
                    MyCommon.GetParentNodeType((TreeNode)theNode, ref EFileType_flg);
                    bool isShowText = true;
                    TreeNode temp_node = this.treeRight.SelectedNode;
                    if (temp_node != null && temp_node.Name == theNode.Name)
                    {
                        isShowText = true;
                    }
                    else
                    {
                        isShowText = false;
                    }


                    if (EFileType_flg == 1)
                    {
                        fileMDL.sl = iPageCount;
                        if (FileList.Length > 0)  //jdk 20151117  判断如果有电子文件，则获取PDF页数,否则获取手工录入
                            fileMDL.sl = iPageCount;
                        else
                            fileMDL.sl = MyCommon.ToInt(fileBaseInfo.sl.Text);

                        if (isShowText && FileList.Length > 0)  //jdk 20151117
                            this.fileBaseInfo.sl.Text = iPageCount.ToString();
                    }
                    else if (EFileType_flg == 3)
                    {
                        if (isShowText)
                        {
                            int tzz = MyCommon.ToInt(this.fileBaseInfo.tzz.Text.Trim());
                            int dtz = MyCommon.ToInt(this.fileBaseInfo.dtz.Text.Trim());
                            int zpz = MyCommon.ToInt(this.fileBaseInfo.zpz.Text.Trim());
                            int dpz = MyCommon.ToInt(this.fileBaseInfo.dpz.Text.Trim());

                            fileMDL.dw = (iPageCount + dtz).ToString();
                            // this.fileBaseInfo.dw.Text = fileMDL.dw;
                            fileMDL.tzz = (iPageCount).ToString();
                            this.fileBaseInfo.tzz.Text = fileMDL.tzz;
                            fileMDL.dtz = dtz.ToString();

                            fileMDL.wzz = (zpz + dpz).ToString();
                            //  this.fileBaseInfo.wzz.Text = fileMDL.wzz;
                            fileMDL.zpz = zpz.ToString();
                            fileMDL.dpz = dpz.ToString();
                        }
                        else
                        {
                            fileMDL.dw = (iPageCount + MyCommon.ToInt(fileMDL.dtz.Trim())).ToString();
                            fileMDL.tzz = (iPageCount).ToString();
                        }
                    }
                    else if (EFileType_flg == 2)
                    {
                        if (isShowText)
                        {
                            int tzz = MyCommon.ToInt(this.fileBaseInfo.tzz.Text.Trim());
                            int dtz = MyCommon.ToInt(this.fileBaseInfo.dtz.Text.Trim());
                            int zpz = MyCommon.ToInt(this.fileBaseInfo.zpz.Text.Trim());
                            int dpz = MyCommon.ToInt(this.fileBaseInfo.dpz.Text.Trim());

                            fileMDL.dw = (tzz + dtz).ToString();
                            //  this.fileBaseInfo.dw.Text = fileMDL.dw;
                            fileMDL.tzz = tzz.ToString();
                            fileMDL.dtz = dtz.ToString();

                            fileMDL.wzz = (iPageCount + dpz).ToString();
                            //  this.fileBaseInfo.wzz.Text = fileMDL.wzz;
                            fileMDL.zpz = (iPageCount).ToString();
                            this.fileBaseInfo.zpz.Text = fileMDL.zpz;
                            fileMDL.dpz = dpz.ToString();
                        }
                        else
                        {
                            fileMDL.wzz = (iPageCount + MyCommon.ToInt(fileMDL.dpz.Trim())).ToString();
                            fileMDL.zpz = (iPageCount).ToString();
                        }
                    }
                    this.fileBaseInfo.isUpdateInfo_flg = update_flg;
                    fileMDL.selected = 0;
                    fileBLL.Update(fileMDL);
                }
            }
            return fileMDL.filepath;
        }
        /// <summary>
        /// 显示归档目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmgdExplorer_Click(object sender, EventArgs e)
        {
            sp1.Panel1Collapsed = false;
        }

        /// <summary>
        /// 电子文件合并有误过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            treeFactory.GetTree(treeRight, Globals.ProjectNO, "filestatus=2", true, true, 2, true, isdy);
            this.drpFileStatus.Text = toolStripMenuItem2.Text;
            if (treeRight.Nodes.Count > 0)
            {
                if (treeRight.Nodes[0].Nodes.Count > 0)
                {
                    frm2PDFProgressMsg dfmsg = new frm2PDFProgressMsg();
                    dfmsg.Text = "查询分析中...";
                    dfmsg.progressBar1.Maximum = 100;
                    dfmsg.label2.Text = "正在分析中...";
                    dfmsg.Show();
                    Application.DoEvents();
                    this.Enabled = false;
                    CheckRightTreeViewFilePDF(treeRight.Nodes[0].Nodes[0].Nodes, 1, dfmsg, isdy);
                    this.Enabled = true;
                    dfmsg.Dispose();
                    dfmsg.Close();
                }
            }
        }
        /// <summary>
        /// 无电子文件，却已保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            treeFactory.GetTree(treeRight, Globals.ProjectNO, "filestatus=4", true, true, 2, true, isdy);
            this.drpFileStatus.Text = toolStripMenuItem3.Text;
            if (treeRight.Nodes.Count > 0)
            {
                if (treeRight.Nodes[0].Nodes.Count > 0)
                {
                    frm2PDFProgressMsg dfmsg = new frm2PDFProgressMsg();
                    dfmsg.Text = "查询分析中...";
                    dfmsg.progressBar1.Maximum = 100;
                    dfmsg.label2.Text = "正在分析中...";
                    dfmsg.Show();
                    Application.DoEvents();
                    this.Enabled = false;
                    CheckRightTreeViewFilePDF(treeRight.Nodes[0].Nodes[0].Nodes, 2, dfmsg, isdy);
                    this.Enabled = true;
                    dfmsg.Dispose();
                    dfmsg.Close();
                }
            }
        }
        /// <summary>
        /// 刷新提示窗体
        /// </summary>
        /// <param name="dfmsg"></param>
        private void ShowMessage(frm2PDFProgressMsg dfmsg)
        {
            dfmsg.progressBar1.Value = dfmsg.progressBar1.Value + 1;
            if (dfmsg.progressBar1.Value == dfmsg.progressBar1.Maximum)
                dfmsg.progressBar1.Value = 1;
            Application.DoEvents();
        }
        /// <summary>
        /// 有电子文件，却未保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            treeFactory.GetTree(treeRight, Globals.ProjectNO, "filestatus=2", true, true, 2, true, isdy);
            this.drpFileStatus.Text = toolStripMenuItem4.Text;
            if (treeRight.Nodes.Count > 0)
            {
                if (treeRight.Nodes[0].Nodes.Count > 0)
                {
                    frm2PDFProgressMsg dfmsg = new frm2PDFProgressMsg();
                    dfmsg.Text = "查询分析中...";
                    dfmsg.progressBar1.Maximum = 100;
                    dfmsg.label2.Text = "正在分析中...";
                    dfmsg.Show();
                    Application.DoEvents();
                    this.Enabled = false;
                    CheckRightTreeViewFilePDF(treeRight.Nodes[0].Nodes[0].Nodes, 3, dfmsg, isdy);
                    this.Enabled = true;
                    dfmsg.Dispose();
                    dfmsg.Close();
                }
            }
        }

        /// <summary>
        /// 右边TreeView 选中文件的电子文件是否正确
        /// </summary>
        /// <param name="rightMoveNode">右边TreeView节点集合</param>
        private void CheckRightTreeViewFilePDF(TreeNodeCollection rightMoveNode,
            int flg_Type, frm2PDFProgressMsg dfmsg, int isDefined = 0)
        {
            for (int i = 0; i < rightMoveNode.Count; i++)
            {
                TreeNode chird = rightMoveNode[i];
                ShowMessage(dfmsg);
                if (chird.ImageIndex == 1 && chird.Nodes.Count > 0)
                {
                    CheckRightTreeViewFilePDF(chird.Nodes, flg_Type, dfmsg);
                }
                else
                {
                    if (chird.ImageIndex == 2 || chird.ImageIndex == 5 || chird.ImageIndex == 4 || chird.ImageIndex == 7)
                    {
                        if (flg_Type == 1)//电子文件合并有误
                        {
                            T_FileList fileList = (new BLL.T_FileList_BLL()).Find(chird.Name, Globals.ProjectNO);
                            if (fileList.IsUseDefined != isDefined)
                                continue;
                            if (fileList.selected == 1 || fileList.filepath == null || fileList.filepath == "")
                            {
                                ConvertFile2PDF2(fileList.FileID);
                            }
                            else
                            {
                                string tFilePath = fileList.filepath.Replace("MPDF\\", "");
                                string sourMfile = Globals.ProjectPath + fileList.filepath;
                                if (!System.IO.File.Exists(sourMfile))
                                {
                                    ConvertFile2PDF2(fileList.FileID);
                                }
                            }

                            IList<MDL.T_CellAndEFile> cellList =
                                (new BLL.T_CellAndEFile_BLL()).FindByGdFileID(chird.Name, Globals.ProjectNO);

                            T_FileList fileList_temp = (new BLL.T_FileList_BLL()).Find(chird.Name, Globals.ProjectNO);
                            if (fileList_temp.IsUseDefined != isDefined)
                                continue;
                            if ((fileList_temp.filepath == null || fileList_temp.filepath == "" && cellList.Count > 0))//&& cellList.Count > 0
                            {
                                //continue;
                                //break;
                            }
                            else
                            {
                                chird.Remove();
                                i--;
                            }
                        }
                        else if (flg_Type == 2)//无电子文件，却保存
                        {
                            IList<MDL.T_CellAndEFile> cellList =
                                (new BLL.T_CellAndEFile_BLL()).FindByGdFileID(chird.Name, Globals.ProjectNO);
                            if (cellList != null && cellList.Count > 0)
                            {
                                chird.Remove();
                                i--;
                            }
                        }
                        else if (flg_Type == 3)//有电子文件，没有保存
                        {
                            T_FileList fileList = (new BLL.T_FileList_BLL()).Find(chird.Name, Globals.ProjectNO);
                            if (fileList.IsUseDefined != isDefined)
                                continue;
                            if (fileList.selected == 1 || fileList.filepath == null || fileList.filepath == "")
                            {
                                ConvertFile2PDF2(fileList.FileID);
                            }
                            else
                            {
                                string tFilePath = fileList.filepath.Replace("MPDF\\", "");
                                string sourMfile = Globals.ProjectPath + fileList.filepath;
                                if (!System.IO.File.Exists(sourMfile))
                                {
                                    ConvertFile2PDF2(fileList.FileID);
                                }
                            }
                            IList<MDL.T_CellAndEFile> cellList =
                                (new BLL.T_CellAndEFile_BLL()).FindByGdFileID(chird.Name, Globals.ProjectNO);
                            if (cellList != null && cellList.Count > 0
                                && (fileList.fileStatus == "4" || fileList.fileStatus == "6"))
                            {
                                chird.Remove();
                                i--;
                            }
                            else
                            {
                            }
                        }
                    }
                }
                if (chird.ImageIndex == 1 && chird.Nodes.Count == 0)
                {
                    chird.Remove();
                    i--;
                }
            }
        }

        /// <summary>
        /// 批量生成PDF功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMoreToPDF_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.treeRight.SelectedNode;

            if (theNode != null && (theNode.ImageIndex == 1 || (theNode.ImageIndex == 0 && theNode.Text.Trim() == "房屋建筑工程")))
            {
                DialogResult diaresult = TXMessageBoxExtensions.Question("确定将：" + theNode.Text + " 下所有文件生成PDF文件？  \n [温馨提示：如果目录下有签章的文件会失去签章] ");
                if (diaresult == DialogResult.OK)
                {
                    List<string> fileList = new List<string>();

                    CheckRightTreeViewCountFile(theNode.Nodes, ref fileList);

                    if (fileList.Count > 0)
                    {
                        frm2PDFProgressMsg dfmsg = new frm2PDFProgressMsg();

                        dfmsg.progressBar1.Maximum = fileList.Count;
                        dfmsg.label2.Text = "正在转换 1/" + fileList.Count;
                        dfmsg.Show();
                        int curIndex = 1;

                        foreach (string filename in fileList)
                        {
                            dfmsg.label2.Text = "正在转换 " + curIndex + "/" + fileList.Count;
                            dfmsg.progressBar1.Value = curIndex;
                            Application.DoEvents();
                            Thread.Sleep(100);
                            ConvertFile2PDF2(filename);

                            curIndex++;
                        }

                        dfmsg.Dispose();
                        dfmsg.Close();
                    }
                }
            }
            else
            {
                TXMessageBoxExtensions.Info("提示：请选择有效文件夹节点！");
                return;
            }
        }

        /// <summary>
        /// 右边TreeView 选中文件的电子文件是否正确
        /// </summary>
        /// <param name="rightMoveNode">右边TreeView节点集合</param>
        private void CheckRightTreeViewCountFile(TreeNodeCollection rightMoveNode, ref List<string> fileList)
        {
            for (int i = 0; i < rightMoveNode.Count; i++)
            {
                TreeNode chird = rightMoveNode[i];

                if (chird.ImageIndex == 1 && chird.Nodes.Count > 0)
                {
                    CheckRightTreeViewCountFile(chird.Nodes, ref fileList);
                }
                else
                {
                    if (chird.ImageIndex == 2 || chird.ImageIndex == 5
                        || chird.ImageIndex == 4 || chird.ImageIndex == 7)
                    {
                        fileList.Add(chird.Name);
                    }
                }
            }
        }
        /// <summary>
        /// 导出原文信息，因为某些格式文件无法进行合并PDF
        /// 所以采用将此文件下所有原文，
        /// 20140402 YQ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsOutPutYWFile_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.treeRight.SelectedNode;
            if (theNode == null || theNode.ImageIndex == 1 || theNode.ImageIndex == 0
                || (theNode.Text.Trim() == "最近著录过的文件") || (theNode.Parent != null &&
                theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件或电子文件！");
                return;
            }
            string savaPath = null;
            //临时目录
            string TempPath = Path.Combine(Application.StartupPath, Guid.NewGuid().ToString());
            if (theNode.ImageIndex == 3)
            {
                #region 电子文件导出
                DialogResult diaresult = TXMessageBoxExtensions.Question("提示：确定将电子文件：" + theNode.Text + " 的原文导出吗？");
                if (diaresult == DialogResult.OK)
                {
                    SaveFileDialog sfDialog = new SaveFileDialog();
                    sfDialog.Filter = "待导出(*.zip) | *.zip";
                    sfDialog.FileName = Globals.ProjectNO + "-" + theNode.Text + ".zip";

                    if (sfDialog.ShowDialog() == DialogResult.OK)
                    {
                        savaPath = sfDialog.FileName;
                    }
                    else
                        return;
                    if (System.IO.Directory.Exists(TempPath))
                        MyCommon.DeleteAndCreateEmptyDirectory(TempPath, false);
                    MyCommon.DeleteAndCreateEmptyDirectory(TempPath);
                    BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
                    MDL.T_CellAndEFile cell_MDL = cellBLL.Find(theNode.Name, Globals.ProjectNO);
                    if (cell_MDL != null)
                    {
                        if (System.IO.File.Exists(Globals.ProjectPath + cell_MDL.filepath))//原件
                        {
                            string outFileName = null;
                            try
                            {
                                outFileName =
                                    Path.Combine(TempPath, cell_MDL.title + Path.GetExtension(Globals.ProjectPath + cell_MDL.filepath));
                                System.IO.File.Copy(Globals.ProjectPath + cell_MDL.filepath, outFileName, true);
                                //如果拷贝失败，采用原文
                                if (!System.IO.File.Exists(outFileName))
                                {
                                    outFileName =
                                        Path.Combine(TempPath, cell_MDL.title + Path.GetFileName(Globals.ProjectPath + cell_MDL.filepath));
                                    System.IO.File.Copy(Globals.ProjectPath + cell_MDL.filepath, outFileName, true);
                                }
                                //压缩文件
                                SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
                                SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
                                tmp.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                                tmp.CompressDirectory(TempPath + "\\", savaPath);

                                System.Threading.Thread.Sleep(100);
                                MyCommon.DeleteAndCreateEmptyDirectory(TempPath, false);//删除文件夹
                            }
                            catch (Exception ex)
                            {
                                MyCommon.WriteLog("导出原文错误：" + ex.Message);
                                TXMessageBoxExtensions.Info("提示：导出原文错误！");
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region 文件导出
                string showText = "[" + theNode.Text.Substring(theNode.Text.LastIndexOf("]") + 1) + "]";
                DialogResult diaresult = TXMessageBoxExtensions.Question("提示：确定将节点 " + showText + " 的原文导出？");
                if (diaresult == DialogResult.OK)
                {
                    SaveFileDialog sfDialog = new SaveFileDialog();
                    sfDialog.Filter = "待导出(*.zip) | *.zip";
                    sfDialog.FileName = Globals.ProjectNO + "-" + showText + ".zip";
                    if (sfDialog.ShowDialog() == DialogResult.OK)
                    {
                        savaPath = sfDialog.FileName;
                    }
                    else
                        return;
                    if (System.IO.Directory.Exists(TempPath))
                        MyCommon.DeleteAndCreateEmptyDirectory(TempPath, false);
                    MyCommon.DeleteAndCreateEmptyDirectory(TempPath);
                    BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
                    IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByGdFileID(theNode.Name, Globals.ProjectNO);

                    if (cellList.Count > 0)
                    {
                        try
                        {
                            foreach (MDL.T_CellAndEFile cell_MDL in cellList)
                            {
                                if (cell_MDL.DocYs == 0 && System.IO.File.Exists(Globals.ProjectPath + cell_MDL.filepath))//原件
                                {
                                    string outFileName = null;

                                    outFileName =
                                        Path.Combine(TempPath, cell_MDL.title + Path.GetExtension(Globals.ProjectPath + cell_MDL.filepath));
                                    System.IO.File.Copy(Globals.ProjectPath + cell_MDL.filepath, outFileName, true);
                                    //如果拷贝失败，采用原文
                                    if (!System.IO.File.Exists(outFileName))
                                    {
                                        outFileName =
                                            Path.Combine(TempPath, cell_MDL.title + Path.GetFileName(Globals.ProjectPath + cell_MDL.filepath));
                                        System.IO.File.Copy(Globals.ProjectPath + cell_MDL.filepath, outFileName, true);
                                    }
                                }
                            }
                            //压缩文件
                            SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
                            SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
                            tmp.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                            tmp.CompressDirectory(TempPath + "\\", savaPath);

                            System.Threading.Thread.Sleep(100);
                            MyCommon.DeleteAndCreateEmptyDirectory(TempPath, false);//删除文件夹
                        }
                        catch (Exception ex)
                        {
                            MyCommon.WriteLog("导出原文错误：" + ex.Message);
                            TXMessageBoxExtensions.Info("提示：导出原文错误！");
                        }
                    }
                }
                #endregion
            }
        }
        /// <summary>
        /// 批量删除电子文件操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsPLDeleteEfile_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.treeRight.SelectedNode;
            if (theNode == null || theNode.ImageIndex == 1 || theNode.ImageIndex == 0
                || (theNode.Text.Trim() == "最近著录过的文件") || (theNode.Parent != null &&
                theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件或电子文件！");
                return;
            }
            if (theNode.ImageIndex == 2 || theNode.ImageIndex == 3 ||
               theNode.ImageIndex == 5 || theNode.ImageIndex == 4 || theNode.ImageIndex == 7)
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
                    TXMessageBoxExtensions.Info("提示：已经组卷的文件不允许修改！");
                    return;
                }
            }
            //临时目录
            if (theNode.ImageIndex == 3)
            {
                #region 电子文件删除
                try
                {
                    DialogResult diaresult = TXMessageBoxExtensions.Question("提示：确定删除电子文件：" + theNode.Text + " 吗？");
                    if (diaresult == DialogResult.OK)
                    {
                        BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
                        MDL.T_CellAndEFile cell_MDL = cellBLL.Find(theNode.Name, Globals.ProjectNO);
                        if (cell_MDL != null)
                        {
                            if (System.IO.File.Exists(Globals.ProjectPath + cell_MDL.filepath)
                                && !string.IsNullOrWhiteSpace(cell_MDL.filepath)
                                && cell_MDL.filepath.EndsWith(".cll"))//原件
                            {
                                cell_MDL.GdFileID = "";
                                cellBLL.Update(cell_MDL);
                            }
                            else
                            {
                                if (System.IO.File.Exists(Globals.ProjectPath + cell_MDL.filepath))
                                {
                                    System.IO.File.Delete(Globals.ProjectPath + cell_MDL.filepath);
                                }
                                if (System.IO.File.Exists(Globals.ProjectPath + cell_MDL.fileTreePath))
                                {
                                    System.IO.File.Delete(Globals.ProjectPath + cell_MDL.fileTreePath);
                                }
                                MyCommon.DeleteOldEfile(cell_MDL.CellID, Globals.ProjectNO);  //删除电子文件对应的原文信息
                                cellBLL.Delete(cell_MDL.CellID, Globals.ProjectNO);
                            }
                        }
                        if (treeRight.SelectedNode.Parent != null)
                        {
                            treeRight.SelectedNode.Parent.Nodes.Remove(theNode);
                        }
                    }
                }
                catch (Exception ex)
                {
                    TXMessageBoxExtensions.Info(ex.Message.ToString());
                }
                #endregion
            }
            else
            {
                #region 文件删除
                string showText = "[" + theNode.Text.Substring(theNode.Text.LastIndexOf("]") + 1) + "]";
                DialogResult diaresult = TXMessageBoxExtensions.Question("提示：确定删除节点 " + showText + " 的下的所有电子文件吗？");
                if (diaresult == DialogResult.OK)
                {
                    BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
                    IList<MDL.T_CellAndEFile> cellList =
                        cellBLL.FindByGdFileID(theNode.Name, Globals.ProjectNO);

                    if (cellList.Count > 0)
                    {
                        try
                        {
                            foreach (MDL.T_CellAndEFile cell_MDL in cellList)
                            {
                                if (cell_MDL.DocYs == 0 &&
                                    System.IO.File.Exists(Globals.ProjectPath + cell_MDL.filepath)
                                    && !string.IsNullOrWhiteSpace(cell_MDL.filepath)
                                    && cell_MDL.filepath.EndsWith(".cll"))//原件
                                {
                                    cell_MDL.GdFileID = "";
                                    cellBLL.Update(cell_MDL);
                                }
                                else
                                {
                                    if (System.IO.File.Exists(Globals.ProjectPath + cell_MDL.filepath))
                                    {
                                        System.IO.File.Delete(Globals.ProjectPath + cell_MDL.filepath);
                                    }
                                    if (System.IO.File.Exists(Globals.ProjectPath + cell_MDL.fileTreePath))
                                    {
                                        System.IO.File.Delete(Globals.ProjectPath + cell_MDL.fileTreePath);
                                    }

                                    MyCommon.DeleteOldEfile(cell_MDL.CellID, Globals.ProjectNO);  //删除电子文件对应的原文信息
                                    cellBLL.Delete(cell_MDL.CellID, Globals.ProjectNO);
                                }
                            }

                            BLL.T_FileList_BLL fileList_bll = (new BLL.T_FileList_BLL());
                            MDL.T_FileList fileList_mdl =
                                fileList_bll.Find(theNode.Name, Globals.ProjectNO);

                            fileList_mdl.selected = 1;
                            fileList_bll.Update(fileList_mdl);

                            UpdatePDFView((TreeNodeEx)theNode);

                            MDL.T_FileList showfileList_mdl = fileList_bll.Find(theNode.Name, Globals.ProjectNO);
                            bool update_flg = this.fileBaseInfo.isUpdateInfo_flg;
                            this.fileBaseInfo.sl.Text = MyCommon.ToInt(showfileList_mdl.sl).ToString();//文字张
                            // this.fileBaseInfo.wzz.Text = MyCommon.ToInt(showfileList_mdl.wzz).ToString();// 照片张 注：图样张=图纸张+底图张
                            this.fileBaseInfo.tzz.Text = MyCommon.ToInt(showfileList_mdl.tzz).ToString();//图纸张
                            this.fileBaseInfo.dtz.Text = MyCommon.ToInt(showfileList_mdl.dtz).ToString();//底图张
                            // this.fileBaseInfo.dw.Text = MyCommon.ToInt(showfileList_mdl.dw).ToString(); //注：图样张=照片张+底片张
                            this.fileBaseInfo.zpz.Text = MyCommon.ToInt(showfileList_mdl.zpz).ToString();//照片张  
                            this.fileBaseInfo.dpz.Text = MyCommon.ToInt(showfileList_mdl.dpz).ToString();//底片张
                            this.fileBaseInfo.isUpdateInfo_flg = update_flg;

                            //统计电子文件数
                            TreeNodeEx theNodeParentNode = (TreeNodeEx)theNode;
                            treeFactory.GetCellFileNodesCount(theNodeParentNode, true);
                            theNodeParentNode.Nodes.Clear();

                            if (theNode.ImageIndex == 2 || theNode.ImageIndex == 7)
                                theNode.ImageIndex = (treeFactory.CheckEFileByFileID(theNode.Name, 2) == true) ? 7 : 2;//判断是否有电子文件
                            theNode.SelectedImageIndex = theNode.ImageIndex;
                        }
                        catch (Exception ex)
                        {
                            MyCommon.WriteLog("删除原文错误：" + ex.Message);
                            TXMessageBoxExtensions.Info("提示：删除失败！");
                        }
                    }
                }
                #endregion
            }
        }
        /// <summary>
        /// 设置显示PDF
        /// </summary>
        /// <param name="pdfPath">pdf路径</param>
        /// <param name="isQZ_flg">是否显示签章：只有文件级才能签章，电子文件级不能</param>
        private void ShowPDF(string pdfPath, bool isQZ_flg)
        {
            if (pdfPath != null
               && pdfPath != ""
               && System.IO.File.Exists(pdfPath))
            {
                try
                {
                    axSPApplication1.CommandBars["DigitalSignature"].Visible = isQZ_flg;
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                    axSPApplication1.Documents.Open(pdfPath);
                }
                catch (Exception ex)
                {
                    MyCommon.WriteLog("读取PDF失败！错误信息：" + ex.Message);
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                }
            }
            else
            {
                if (axSPApplication1.Documents.ActiveDocument != null)
                    axSPApplication1.Documents.CloseAll();
            }
        }
        private void axpdfInterface1_OnAddSealFinish(object sender, EventArgs e)
        {
            //axpdfInterface1.SaveFile();
        }
        /// <summary>
        /// 导出PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmOutPDF_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.treeRight.SelectedNode;
            if (theNode == null || theNode.ImageIndex == 1 || theNode.ImageIndex == 0
                || (theNode.Text.Trim() == "最近著录过的文件") || (theNode.Parent != null &&
                theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件或电子文件！");
                return;
            }
            string savaPath = null;

            if (theNode.ImageIndex == 3)
            {
                #region 电子文件导出
                DialogResult diaresult = TXMessageBoxExtensions.Question("提示：确定将电子文件：" + theNode.Text + " 的PDF导出吗？");
                if (diaresult == DialogResult.OK)
                {
                    SaveFileDialog sfDialog = new SaveFileDialog();
                    sfDialog.Filter = "所有文件|*.*";
                    sfDialog.FileName = Globals.ProjectNO + "-" + theNode.Text + ".pdf";

                    if (sfDialog.ShowDialog() == DialogResult.OK)
                    {
                        savaPath = sfDialog.FileName;
                    }
                    else
                        return;

                    BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
                    MDL.T_CellAndEFile cell_MDL = cellBLL.Find(theNode.Name, Globals.ProjectNO);
                    if (cell_MDL != null)
                    {
                        if (cell_MDL.DocYs == null || cell_MDL.DocYs == 1 ||
                            string.IsNullOrEmpty(cell_MDL.fileTreePath) || cell_MDL.fileTreePath == "")
                        {
                            using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                            {
                                try
                                {
                                    int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cell_MDL.filepath, Globals.ProjectPath + "PDF\\" + cell_MDL.CellID + ".pdf");
                                    if (iPageCount != 0)
                                        cell_MDL.fileTreePath = "PDF\\" + cell_MDL.CellID + ".pdf";
                                    else
                                        cell_MDL.fileTreePath = "";
                                    cell_MDL.DocYs = 0;
                                    cell_MDL.DoStatus = 1;
                                    cell_MDL.ys = iPageCount;
                                    cellBLL.Update(cell_MDL);
                                }
                                catch (Exception cex)
                                {
                                    cell_MDL.fileTreePath = "";
                                    MyCommon.WriteLog("转换PDF失败！错误信息：" + cex.Message);
                                }
                            }
                        }
                        if (System.IO.File.Exists(Globals.ProjectPath + cell_MDL.fileTreePath))//原件
                        {
                            System.IO.File.Copy(Globals.ProjectPath + cell_MDL.fileTreePath, savaPath, true);
                        }
                        TXMessageBoxExtensions.Info("提示：导出成功！");
                    }
                }
                #endregion
            }
            else
            {
                #region 文件导出
                string showText = "[" + theNode.Text.Substring(theNode.Text.LastIndexOf("]") + 1) + "]";
                DialogResult diaresult = TXMessageBoxExtensions.Question("提示：确定将节点 " + showText + " 的PDF文件导出？");
                if (diaresult == DialogResult.OK)
                {
                    SaveFileDialog sfDialog = new SaveFileDialog();
                    sfDialog.Filter = "所有文件|*.*";
                    sfDialog.FileName = Globals.ProjectNO + "-" + theNode.Text.Substring(theNode.Text.LastIndexOf("]") + 1) + ".pdf";
                    if (sfDialog.ShowDialog() == DialogResult.OK)
                    {
                        savaPath = sfDialog.FileName;
                    }
                    else
                        return;

                    BLL.T_FileList_BLL File_BLL = new BLL.T_FileList_BLL();
                    MDL.T_FileList File_MDL = File_BLL.Find(theNode.Name, Globals.ProjectNO);

                    if (File_MDL != null)
                    {
                        try
                        {
                            if (File_MDL.selected == 1 || File_MDL.filepath == null || File_MDL.filepath == "")
                            {
                                ConvertFile2PDF2(File_MDL.FileID);
                            }
                            File_MDL = File_BLL.Find(theNode.Name, Globals.ProjectNO);

                            if (System.IO.File.Exists(Globals.ProjectPath + File_MDL.filepath))//原件
                            {
                                System.IO.File.Copy(Globals.ProjectPath + File_MDL.filepath, savaPath, true);
                            }
                            TXMessageBoxExtensions.Info("提示：导出成功！");
                        }
                        catch (Exception ex)
                        {
                            MyCommon.WriteLog("导出PDF错误：" + ex.Message);
                            TXMessageBoxExtensions.Info("提示：导出PDF错误！");
                        }
                    }
                }
                #endregion
            }
        }
        /// <summary>
        /// 替换文件PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_replescPDF_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.treeRight.SelectedNode;
            if (theNode == null || theNode.ImageIndex == 1 || theNode.ImageIndex == 0 || theNode.ImageIndex == 3
                || (theNode.Text.Trim() == "最近著录过的文件") || (theNode.Parent != null &&
                theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件！");
                return;
            }

            if (theNode.ImageIndex == 2 || theNode.ImageIndex == 5
                || theNode.ImageIndex == 4 || theNode.ImageIndex == 7)
            {
                //判断文件状态 已经组卷的文件不允许修改
                string fileID = string.Empty;
                if (theNode.ImageIndex == 2 || theNode.ImageIndex == 5 || theNode.ImageIndex == 4 || theNode.ImageIndex == 7)
                    fileID = theNode.Name;
                else
                    fileID = theNode.Parent.Name;

                string showText = "[" + theNode.Text.Substring(theNode.Text.LastIndexOf("]") + 1) + "]";
                MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(fileID, Globals.ProjectNO);
                if (fileMDL1.fileStatus == "6")
                {
                    //if (TXMessageBoxExtensions.Question("确定对已经组卷的文件进行PDF文件替换吗？ \n 【温馨提示：请确保PDF文件的页数和文件中著录的页数一致】") != DialogResult.OK)
                    //    return;
                    //TXMessageBoxExtensions.Info("提示：已经组卷的文件不允许修改！");
                    //return;
                    showText = "确定对已经组卷的文件 " + showText + " \n 进行PDF文件替换吗？ \n 【温馨提示：请确保PDF文件的页数和文件中著录的页数一致】";
                }
                else
                {
                    showText = "提示：确定要替换 " + showText + " 的PDF文件吗？";
                }
                if (TXMessageBoxExtensions.Question(showText) == DialogResult.OK)
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Filter = "PDF文件(*.pdf) | *.pdf";
                    openFileDialog1.Title = "文件PDF替换";
                    DialogResult ret = openFileDialog1.ShowDialog();
                    if (ret == DialogResult.OK)
                    {
                        string Infile = openFileDialog1.FileName;
                        if (System.IO.File.Exists(Infile))
                        {
                            //if (axpdfInterface1.FileName != null
                            //    && axpdfInterface1.FileName.Length > 0)
                            //    this.axpdfInterface1.CloseFile();

                            try
                            {
                                System.IO.File.Copy(Infile, Globals.ProjectPath + fileMDL1.filepath, true);
                                ShowPDF(Globals.ProjectPath + fileMDL1.filepath, true);
                                TXMessageBoxExtensions.Info("提示：替换完成！");
                            }
                            catch (Exception)
                            {
                                TXMessageBoxExtensions.Info("要替换的文件不存在！");
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 右键打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsPrintTS_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.treeRight.SelectedNode;
            if (theNode == null || theNode.ImageIndex == 1 || theNode.ImageIndex == 0
                || (theNode.Text.Trim() == "最近著录过的文件") || (theNode.Parent != null &&
                theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件！");
                return;
            }

            if (theNode.ImageIndex == 2 || theNode.ImageIndex == 5
                || theNode.ImageIndex == 4 || theNode.ImageIndex == 7)
            {
                //判断文件状态 已经组卷的文件不允许修改
                string fileID = string.Empty;
                if (theNode.ImageIndex == 2 || theNode.ImageIndex == 5 || theNode.ImageIndex == 4 || theNode.ImageIndex == 7)
                    fileID = theNode.Name;
                else
                    fileID = theNode.Parent.Name;
                MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(fileID, Globals.ProjectNO);
                if (fileMDL != null && fileMDL.filepath != null)
                {
                    /*
                     * 拷贝到临时目录进行打印，因为隐藏章打印会删除掉，影响系统查看
                     * */
                    if (System.IO.File.Exists(Globals.ProjectPath + fileMDL.filepath))
                    {
                        string tempFolder =
                            System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "erm_print");
                        if (!System.IO.Directory.Exists(tempFolder))
                        {
                            MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, true);
                        }
                        string tempFile = System.IO.Path.Combine(tempFolder, fileMDL.wjtm + ".pdf");
                        System.IO.File.Copy(Globals.ProjectPath + fileMDL.filepath, tempFile, true);
                        using (ConvertCell2PDF cl = new ConvertCell2PDF())
                        {
                            cl.BathPrintPDF(tempFile);
                        }
                    }
                }
            }
            else if (theNode.ImageIndex == 3)
            {
                //电子文件打印
                BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
                MDL.T_CellAndEFile cell_MDL = cellBLL.Find(theNode.Name, Globals.ProjectNO);
                if (cell_MDL != null)
                {
                    if (cell_MDL.DocYs == null || cell_MDL.DocYs == 1 ||
                        string.IsNullOrEmpty(cell_MDL.fileTreePath) || cell_MDL.fileTreePath == "")
                    {
                        using (ConvertCell2PDF c1 = new ConvertCell2PDF())
                        {
                            try
                            {
                                int iPageCount = c1.PrintCellToPDF(Globals.ProjectPath + cell_MDL.filepath, Globals.ProjectPath + "PDF\\" + cell_MDL.CellID + ".pdf");
                                if (iPageCount != 0)
                                    cell_MDL.fileTreePath = "PDF\\" + cell_MDL.CellID + ".pdf";
                                else
                                    cell_MDL.fileTreePath = "";
                                cell_MDL.DocYs = 0;
                                cell_MDL.DoStatus = 1;
                                cell_MDL.ys = iPageCount;
                                cellBLL.Update(cell_MDL);
                            }
                            catch (Exception cex)
                            {
                                cell_MDL.fileTreePath = "";
                                MyCommon.WriteLog("转换PDF失败！错误信息：" + cex.Message);
                            }
                        }
                    }
                    if (System.IO.File.Exists(Globals.ProjectPath + cell_MDL.fileTreePath))//PDF
                    {
                        string tempFolder =
                            System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "erm_print");
                        if (!System.IO.Directory.Exists(tempFolder))
                        {
                            MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, true);
                        }
                        string tempFile = System.IO.Path.Combine(tempFolder, cell_MDL.title + ".pdf");
                        System.IO.File.Copy(Globals.ProjectPath + cell_MDL.fileTreePath, tempFile, true);
                        using (ConvertCell2PDF cl = new ConvertCell2PDF())
                        {
                            cl.BathPrintPDF(tempFile);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 多选批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_CheckDel_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.treeRight.SelectedNode;
            if (theNode == null || theNode.ImageIndex == 0 || theNode.ImageIndex == 3
                || (theNode.Text.Trim() == "最近著录过的文件") || (theNode.Parent != null &&
                theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件！");
                return;
            }
            if (theNode.ImageIndex == 2 || theNode.ImageIndex == 5 || theNode.ImageIndex == 4 || theNode.ImageIndex == 7)
            {
                MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(theNode.Name, Globals.ProjectNO);
                if (MyCommon.ToInt(fileMDL1.IsUseDefined) == 0)
                {
                    TXMessageBoxExtensions.Info("提示：系统目录不能进行删除！");
                    return;
                }
            }
            else
            {
                DataTable dtisdefined = (new BLL.T_FileList_BLL()).GetFileByGDID(Globals.ProjectNO, theNode.Name);
                if (dtisdefined.Rows.Count > 0)
                {
                    if (MyCommon.ToInt(dtisdefined.Rows[0]["IsUseDefined"]) == 0)
                    {
                        TXMessageBoxExtensions.Info("提示：系统目录不能进行删除！");
                        return;
                    }
                }
            }
            //要先关闭文件，避免资源冲突
            if (axSPApplication1.Documents.ActiveDocument != null)
                axSPApplication1.Documents.CloseAll();

            if (theNode.ImageIndex == 1)
            {
                frmDelInfo frm_DelInfo = new frmDelInfo(theNode, 1, this, TreeNodeState_flg);
                DialogResult dResult = frm_DelInfo.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    (new TreeFactory()).InitGDTree(Globals.ProjectNO, TreeNodeState_flg, theNode,
                                    true, 2, true);
                }
            }
            else
            {
                BLL.T_FileList_BLL FileList_BLL = new ERM.BLL.T_FileList_BLL();
                MDL.T_FileList fileMDL1 = FileList_BLL.Find(theNode.Name, Globals.ProjectNO);
                if (fileMDL1.fileStatus == "6")
                {
                    TXMessageBoxExtensions.Info("提示：已经组卷的文件不允许修改！");
                    return;
                }

                frmDelInfo frm_DelInfo = new frmDelInfo(theNode, 2, this, TreeNodeState_flg);
                DialogResult dResult = frm_DelInfo.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    theNode.Nodes.Clear();
                    BLL.T_CellAndEFile_BLL cellFile = new ERM.BLL.T_CellAndEFile_BLL();
                    IList<MDL.T_CellAndEFile> cellList =
                        cellFile.FindByGdFileID(theNode.Name, Globals.ProjectNO);
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

                    MDL.T_FileList fileList_mdl = FileList_BLL.Find(theNode.Name, Globals.ProjectNO);
                    fileList_mdl.selected = 1;
                    FileList_BLL.Update(fileList_mdl);

                    UpdatePDFView((TreeNodeEx)theNode);

                    MDL.T_FileList showfileList_mdl = FileList_BLL.Find(theNode.Name, Globals.ProjectNO);
                    bool update_flg = this.fileBaseInfo.isUpdateInfo_flg;
                    this.fileBaseInfo.sl.Text = MyCommon.ToInt(showfileList_mdl.sl).ToString();//文字张
                    //this.fileBaseInfo.wzz.Text = MyCommon.ToInt(showfileList_mdl.wzz).ToString();// 照片张 注：图样张=图纸张+底图张
                    this.fileBaseInfo.tzz.Text = MyCommon.ToInt(showfileList_mdl.tzz).ToString();//图纸张
                    this.fileBaseInfo.dtz.Text = MyCommon.ToInt(showfileList_mdl.dtz).ToString();//底图张
                    // this.fileBaseInfo.dw.Text = MyCommon.ToInt(showfileList_mdl.dw).ToString(); //注：图样张=照片张+底片张
                    this.fileBaseInfo.zpz.Text = MyCommon.ToInt(showfileList_mdl.zpz).ToString();//照片张  
                    this.fileBaseInfo.dpz.Text = MyCommon.ToInt(showfileList_mdl.dpz).ToString();//底片张
                    this.fileBaseInfo.isUpdateInfo_flg = update_flg;

                    //统计电子文件数
                    TreeNodeEx theNodeParentNode = (TreeNodeEx)theNode;
                    treeFactory.GetCellFileNodesCount(theNodeParentNode, true);

                    if (theNode.ImageIndex == 2 || theNode.ImageIndex == 7)
                        theNode.ImageIndex = (treeFactory.CheckEFileByFileID(theNode.Name, 2) == true) ? 7 : 2;//判断是否有电子文件
                    theNode.SelectedImageIndex = theNode.ImageIndex;
                }
            }
        }

        /// <summary>
        /// 设置签章日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnSetQZDt_Click(object sender, EventArgs e)
        {
            frmSetSignatureDt frm = new frmSetSignatureDt();
            frm.ShowDialog();
        }

        #region 筑业接口导入
        Hashtable htXML = new Hashtable();
        /// <summary>
        /// 导入筑业数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbarImportXML_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                GetAnalyticIndexXML(dialog.SelectedPath);
                //InsertGdList();
                if (htXML.Count > 0)
                {
                    GetAnalyticFileListXML(dialog.SelectedPath);
                }
            }
        }
        /// <summary>
        /// 解析FileList.xml
        /// </summary>
        /// <param name="xmlPath"></param>
        private void GetAnalyticFileListXML(string xmlPath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath + "\\FileList.xml");
                BLL.T_GdListTemplate_BLL GdListTemplate_BLL = new BLL.T_GdListTemplate_BLL();
                XmlNodeList listNode = doc.DocumentElement.SelectNodes("FILELIST[contains(ISFOLDER,'0')]");
                foreach (XmlNode node in listNode)
                {
                    if (Convert.ToInt16(node["SID"].InnerText) < 1)
                        continue;

                    T_FileList fileListMDL = new T_FileList();
                    string gdid = GdListTemplate_BLL.FindOrderIndex(MyCommon.ToInt(node["ARCHIVE_TYPE"].InnerText));
                    //string fromSingleID = htXML["DIR_GUID"].ToString();
                    string newFileID = String.Concat(gdid, "-", node["SID"].InnerText);

                    if (node["FILEID"] != null)
                        fileListMDL.wh = node["FILEID"].InnerText;
                    fileListMDL.FileID = newFileID;
                    fileListMDL.GDID = gdid;
                    fileListMDL.ParentID = gdid;
                    fileListMDL.ProjectNO = Globals.ProjectNO;
                    fileListMDL.wjtm = String.Concat(node["TITLE"].InnerText, "(", htXML["DIR_NAME"], ")");
                    fileListMDL.isvisible = 1;
                    fileListMDL.selected = 0;
                    fileListMDL.filepath = String.Concat("MPDF\\", newFileID, ".pdf");
                    fileListMDL.CreateDate = node["START_DATE"].InnerText;
                    fileListMDL.zrr = htXML["DIR_NAME"].ToString();

                    fileListMDL.BRANCH = node["BRANCH"].InnerText;
                    fileListMDL.SUBBRANCH = node["SUBBRANCH"].InnerText;
                    fileListMDL.SUBPROJCET = node["SUBPROJCET"].InnerText;

                    InsertFileListAndEFile(fileListMDL, xmlPath, node["PDFFILEPATH"].InnerText);
                }
                TXMessageBoxExtensions.Info("导入成功!");
                treeFactory.GetTree(treeRight, Globals.ProjectNO, "", true, true, 2, true);
                //treeFactory.GetTree(treeRight, Globals.ProjectNO, "", true, true, 2, true);
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info("导入包不合法,原因:" + ex.Message);
            }
        }
        ERM.BLL.T_FileList_BLL fileListBLL = new BLL.T_FileList_BLL();
        ERM.BLL.T_CellAndEFile_BLL eFileBLL = new BLL.T_CellAndEFile_BLL();
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="fileListMDL">T_FileList对象</param>
        /// <param name="sourcePdfpath">远PDF所属文件路径</param>
        /// <param name="oldPdfFilePath">原PDF名称</param>
        private void InsertFileListAndEFile(T_FileList fileListMDL, string sourcePdfpath, string oldPdfFilePath)
        {
            /*----------------------------------先删除,后添加文件-----------------------------------------*/
            fileListBLL.Delete(fileListMDL);
            fileListBLL.Add(fileListMDL);

            /*----------------------------------先删除,后添加电子文件-------------------------------------*/
            T_CellAndEFile eFileMDL = new T_CellAndEFile();
            eFileMDL.CellID = fileListMDL.FileID;
            eFileMDL.FileID = fileListMDL.FileID;
            eFileMDL.GdFileID = fileListMDL.FileID;
            eFileMDL.title = fileListMDL.wjtm;
            eFileMDL.DocYs = 0;
            eFileMDL.DoStatus = 1;
            eFileMDL.fileTreePath = String.Concat("ODOC\\", fileListMDL.FileID, ".pdf");
            eFileMDL.filepath = String.Concat("ODOC\\", fileListMDL.FileID, ".pdf");
            eFileMDL.ProjectNO = Globals.ProjectNO;
            eFileBLL.Delete(eFileMDL);
            eFileBLL.Add(eFileMDL);

            /*----------------------------------复制电子文件到指定目录------------------------------------*/
            MyCommon.CopyFile(String.Concat(Application.StartupPath + "\\Project\\" + Globals.ProjectNO + "\\", "ODOC\\", fileListMDL.FileID, ".pdf"),
                String.Concat(sourcePdfpath, "\\", oldPdfFilePath));
            MyCommon.CopyFile(String.Concat(Application.StartupPath + "\\Project\\" + Globals.ProjectNO + "\\", "MPDF\\", fileListMDL.FileID, ".pdf"),
                   String.Concat(sourcePdfpath, "\\", oldPdfFilePath));
        }
        ERM.BLL.T_GdList_BLL gdListBLL = new BLL.T_GdList_BLL();
        /// <summary>
        /// 添加文件类别
        /// </summary>
        private void InsertGdList()
        {
            gdListBLL.Delete(htXML["DIR_GUID"].ToString());

            T_GdList gdListMDL = new T_GdList();
            gdListMDL.ID = htXML["DIR_GUID"].ToString();
            gdListMDL.GdName = String.Concat("筑业导入(", htXML["DIR_NAME"], ")");
            gdListMDL.OrderIndex = 100;
            gdListMDL.ProjectNo = Globals.ProjectNO;
            gdListMDL.IsShow = 0;
            gdListBLL.Insert(gdListMDL);
        }
        /// <summary>
        /// 解析Index.xml
        /// </summary>
        /// <param name="xmlPath"></param>
        private void GetAnalyticIndexXML(string xmlPath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath + "\\Index.xml");
                XmlNode node = doc.DocumentElement.SelectSingleNode("/RESULT");

                htXML["FOLDERS_COUNT"] = node["FOLDERS_COUNT"].InnerText;
                htXML["FILES_COUNT"] = node["FILES_COUNT"].InnerText;
                htXML["PDF_COUNT"] = node["PDF_COUNT"].InnerText;
                htXML["DIR_NAME"] = node["DIR_NAME"].InnerText;
                htXML["DIR_GUID"] = node["DIR_GUID"].InnerText;
                htXML["OUT_DATE"] = node["OUT_DATE"].InnerText;
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info("导入包不合法,原因:" + ex.Message);
            }
        }
        #endregion

        /// <summary>
        ///导入文件条目信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_InsertExcel_Click(object sender, EventArgs e)
        {
            TreeNode FileNode = this.treeRight.SelectedNode;
            if (FileNode != null && FileNode.Level != 0 &&
                (FileNode.ImageIndex == 1
                || (FileNode.ImageIndex == 0 && FileNode.Text != "最近著录过的文件")))
            {
                #region 是否自定义导入
                if (FileNode.ImageIndex == 2 || FileNode.ImageIndex == 5 || FileNode.ImageIndex == 4 || FileNode.ImageIndex == 7)
                {
                    MDL.T_FileList fileMDL1 = (new BLL.T_FileList_BLL()).Find(FileNode.Name, Globals.ProjectNO);
                    if (MyCommon.ToInt(fileMDL1.IsUseDefined) == 0)
                    {
                        TXMessageBoxExtensions.Info("提示：请用自定义文件夹导入Excel！");
                        return;
                    }
                }
                else
                {
                    DataTable dtisdefined = (new BLL.T_FileList_BLL()).GetFileByGDID(Globals.ProjectNO, FileNode.Name);
                    if (dtisdefined.Rows.Count > 0)
                    {
                        if (MyCommon.ToInt(dtisdefined.Rows[0]["IsUseDefined"]) == 0)
                        {
                            TXMessageBoxExtensions.Info("提示：请用自定义文件夹导入Excel！");
                            return;
                        }
                    }
                }
                #endregion
                DialogResult diaresult = TXMessageBoxExtensions.Question("提示：确定案卷【 " + FileNode.Text + "】 导入文件信息吗？");
                if (diaresult == DialogResult.OK)
                {
                    OpenFileDialog Open_FileDialog = new OpenFileDialog();
                    Open_FileDialog.Filter = "文件列表信息(*.xlsx)| *.xlsx|(*.xls) | *.xls";
                    Open_FileDialog.Title = "文件列表信息";
                    DialogResult ret = Open_FileDialog.ShowDialog();
                    if (ret == DialogResult.OK)
                    {
                        BLL.T_FileList_BLL FileList_BLL = new BLL.T_FileList_BLL();
                        string Infile = Open_FileDialog.FileName;
                        ExcelHelp ExcelHelp = new ExcelHelp();
                        DataTable tbl_FileInfo = ExcelHelp.GetData(Infile, true);
                        try
                        {
                            if (tbl_FileInfo != null && tbl_FileInfo.Rows.Count > 0)
                            {
                                int row_Index = 1;
                                bool check_flg = true;
                                try
                                {
                                    foreach (DataRow i_row in tbl_FileInfo.Select())
                                    {
                                        if (MyCommon.ToString(i_row["文件题名"]) == "" &&
                                           MyCommon.ToString(i_row["责任者"]) == "" &&
                                           MyCommon.ToString(i_row["文(图)号"]) == "" &&
                                           MyCommon.ToString(i_row["日期"]) == "" &&
                                           MyCommon.ToString(i_row["页次"]) == "" &&
                                           MyCommon.ToString(i_row["备注"]) == "")
                                        {
                                            continue;
                                        }
                                        //对Excel内容进行检查解析
                                        string Wjtm = MyCommon.ToString(i_row["文件题名"]);//文件名称
                                        if (string.IsNullOrWhiteSpace(Wjtm))
                                        {
                                            TXMessageBoxExtensions.Info("提示：文件题名不能为空！\n 行数：" + row_Index);
                                            check_flg = false;
                                            break;
                                        }
                                        string YC = MyCommon.ToString(i_row["页次"]);
                                        if (!string.IsNullOrWhiteSpace(YC))
                                        {
                                            try
                                            {
                                                if (!YC.Contains("-"))
                                                {
                                                    Convert.ToInt32(YC);
                                                }
                                                else
                                                {
                                                    string[] t = YC.Split('-');
                                                    if (t.Length == 1)
                                                    {
                                                        Convert.ToInt32(t[0]);
                                                    }
                                                    else if (t.Length > 1)
                                                    {
                                                        Convert.ToInt32(t[0]);
                                                        Convert.ToInt32(t[1]);
                                                    }
                                                }
                                            }
                                            catch
                                            {
                                                TXMessageBoxExtensions.Info("提示：页次格式输入不正确！\n 行数：" + row_Index);
                                                check_flg = false;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            i_row["页次"] = "0";
                                        }
                                        string EditTime = MyCommon.ToString(i_row["日期"]);
                                        if (!string.IsNullOrWhiteSpace(EditTime))
                                        {
                                            try
                                            {
                                                string[] t = EditTime.Split('-');
                                                if (t.Length == 1 && !string.IsNullOrWhiteSpace(t[0]))
                                                {
                                                    Convert.ToDateTime(t[0]);
                                                }
                                                else if (t.Length > 1)
                                                {
                                                    if (!string.IsNullOrWhiteSpace(t[0]))
                                                    {
                                                        Convert.ToDateTime(t[0]);
                                                    }
                                                    if (!string.IsNullOrWhiteSpace(t[1]))
                                                    {
                                                        Convert.ToDateTime(t[1]);
                                                    }
                                                }
                                                else if (t.Length > 2)
                                                {
                                                    TXMessageBoxExtensions.Info("提示：日期，格式输入不正确！ \n 【温馨提示：正确格式2015.05.20】\n 行数：" + row_Index);
                                                    check_flg = false;
                                                    break;
                                                }
                                            }
                                            catch
                                            {
                                                TXMessageBoxExtensions.Info("提示：日期，格式输入不正确！ \n 【温馨提示：正确格式2015.05.20】\n 行数：" + row_Index);
                                                check_flg = false;
                                                break;
                                            }
                                        }
                                        row_Index++;
                                    }
                                    if (check_flg)
                                    {
                                        tbl_FileInfo = finalArchive.JNMLData(tbl_FileInfo, "import");
                                        int OrderIndex = 1; string ParentID = ""; int isupdate = 0;
                                        foreach (DataRow i_row in tbl_FileInfo.Select("文件题名<>''", "序号"))
                                        {
                                            OrderIndex = FileList_BLL.GetMaxGdFileOrderIndex(FileNode.Name, Globals.ProjectNO);
                                            MDL.T_FileList fileMDL = new T_FileList();

                                            #region 查找工程下文件名称是否存在
                                            MDL.T_FileList fileMDLTmp = new T_FileList();
                                            fileMDLTmp.GDID = FileNode.Name;
                                            fileMDLTmp.ProjectNO = Globals.ProjectNO;
                                            IList<T_FileList> fileMDLList = FileList_BLL.GetFileByGDIDList(fileMDLTmp);
                                            foreach (T_FileList tfi in fileMDLList)
                                            {
                                                if (tfi.wjtm == MyCommon.ToString(i_row["文件题名"]).Trim())
                                                {
                                                    fileMDL = tfi; break;
                                                }
                                                if (tfi.wjtm == FileNode.Text.Trim() && ParentID == "")
                                                {
                                                    ParentID = tfi.ParentID;
                                                }
                                            }
                                            #endregion

                                            fileMDL.ProjectNO = Globals.ProjectNO;
                                            fileMDL.wjtm = MyCommon.ToString(i_row["文件题名"]).Trim();//文件名称
                                            fileMDL.zrr = MyCommon.ToString(i_row["责任者"]).Trim();//责任者
                                            fileMDL.wh = MyCommon.ToString(i_row["文(图)号"]).Trim();//文(图)号
                                            fileMDL.stys = MyCommon.ToInt(i_row["页次"]);//页数
                                            //if(fileMDL.ztlx=="纸质"){
                                            //    fileMDL.sl = MyCommon.ToInt(i_row["页数"]);//页数
                                            //}    
                                            //else if(fileMDL.ztlx=="图样"){
                                            //    fileMDL.tzz = MyCommon.ToString(i_row["页数"]);//页数
                                            //}
                                            //else if (fileMDL.ztlx == "底图")
                                            //{
                                            //    fileMDL.dtz = MyCommon.ToString(i_row["页数"]);//页数
                                            //}
                                            //else if (fileMDL.ztlx == "照片")
                                            //{
                                            //    fileMDL.zpz = MyCommon.ToString(i_row["页数"]);//页数
                                            //}
                                            //else if (fileMDL.ztlx == "底片")
                                            //{
                                            //    fileMDL.dpz = MyCommon.ToString(i_row["页数"]);//页数
                                            //} 
                                            fileMDL.bz = MyCommon.ToString(i_row["备注"]).Trim();//备注
                                            string[] dateList = new string[2];
                                            if (!string.IsNullOrWhiteSpace(MyCommon.ToString(i_row["日期"])))
                                            {
                                                if (i_row["日期"].ToString().Trim().IndexOf('-') > 0 &&
                                                    i_row["日期"].ToString().Split('-').Length == 2)
                                                {
                                                    dateList = i_row["日期"].ToString().Split('-');
                                                }
                                                else if (i_row["日期"].ToString().Trim().IndexOf('-') > 0)//开始日期
                                                {
                                                    dateList[0] = i_row["日期"].ToString().Replace("-", "");
                                                    dateList[1] = "";
                                                }
                                                else if (i_row["日期"].ToString().Trim().IndexOf('-') == 0)//结束日期
                                                {
                                                    dateList[0] = "";
                                                    dateList[1] = i_row["日期"].ToString().Replace("-", "");
                                                }
                                                else
                                                {
                                                    dateList[0] = i_row["日期"].ToString();
                                                }
                                            }
                                            if (!string.IsNullOrWhiteSpace(MyCommon.ToString(dateList[0])))
                                            {
                                                fileMDL.CreateDate = MyCommon.ToDate(dateList[0]).ToString("yyyy-MM-dd");//形成开始日期
                                            }
                                            if (!string.IsNullOrWhiteSpace(MyCommon.ToString(dateList[1])))
                                            {
                                                fileMDL.CreateDate2 = MyCommon.ToDate(dateList[1]).ToString("yyyy-MM-dd");//形成结束日期
                                            }

                                            fileMDL.OrderIndex = OrderIndex + 1;
                                            fileMDL.fileStatus = "0";
                                            fileMDL.FL = 1;
                                            fileMDL.GDID = FileNode.Name;
                                            fileMDL.IsUseDefined = 1;

                                            if (!string.IsNullOrEmpty(fileMDL.FileID))
                                            {
                                                FileList_BLL.Update(fileMDL);
                                            }
                                            else
                                            {
                                                fileMDL.FileID = Guid.NewGuid().ToString();
                                                fileMDL.ParentID = ParentID;
                                                TreeNodeEx newNode = new TreeNodeEx();
                                                newNode.Name = fileMDL.FileID;
                                                newNode.Text = fileMDL.wjtm;
                                                newNode.ImageIndex = 2;
                                                newNode.SelectedImageIndex = 2;
                                                fileMDL.isvisible = 1;
                                                treeFactory.GetCellFileNodesCount(newNode, true);//获取文件下的电子文件数量

                                                fileMDL.GdFileOrderIndex =
                                                    FileList_BLL.GetMaxGdFileOrderIndex(FileNode.Name, Globals.ProjectNO) + 1;
                                                FileList_BLL.Add(fileMDL);

                                                FileNode.Nodes.Add(newNode);
                                                FileNode.Expand();
                                            }
                                            isupdate++;
                                        }
                                        if (isupdate > 0)
                                            TXMessageBoxExtensions.Info("提示：导入文件信息成功！");
                                        else
                                            TXMessageBoxExtensions.Info("提示：没有找到匹配的文件信息！");
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MyCommon.WriteLog("导入Excel错误：" + ex.Message);
                                    TXMessageBoxExtensions.Info("导入Excel错误：" + ex.Message);
                                    return;
                                }
                            }
                            else
                            {
                                TXMessageBoxExtensions.Info("提示：Excel无任何记录！");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MyCommon.WriteLog("导入Excel错误：" + ex.Message);
                            TXMessageBoxExtensions.Info("提示：导入文件信息失败！");
                        }
                    }
                }

            }
            else
            {
                TXMessageBoxExtensions.Info("请选中有效目录进行添加节点！");
            }
        }
        private void tsmPX_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.treeRight.SelectedNode;
            if (theNode == null || theNode.ImageIndex == 0 || theNode.ImageIndex == 3
                || (theNode.Text.Trim() == "最近著录过的文件") || (theNode.Parent != null &&
                theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件！");
                return;
            }

            //要先关闭文件，避免资源冲突
            if (axSPApplication1.Documents.ActiveDocument != null)
                axSPApplication1.Documents.CloseAll();

            if (theNode.ImageIndex == 1)
            {
                frmPX frm_PX = new frmPX(theNode.Name, 0);
                DialogResult dResult = frm_PX.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    (new TreeFactory()).InitGDTree(Globals.ProjectNO, TreeNodeState_flg, theNode,
                                    true, 2, true);
                }
            }
            else
            {
                BLL.T_FileList_BLL FileList_BLL = new ERM.BLL.T_FileList_BLL();
                MDL.T_FileList fileMDL1 = FileList_BLL.Find(theNode.Name, Globals.ProjectNO);
                if (fileMDL1.fileStatus == "6")
                {
                    TXMessageBoxExtensions.Info("提示：已经组卷的文件不允许修改！");
                    return;
                }

                frmPX frm_PX = new frmPX(theNode.Name, 1);
                DialogResult dResult = frm_PX.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    theNode.Nodes.Clear();
                    BLL.T_CellAndEFile_BLL cellFile = new ERM.BLL.T_CellAndEFile_BLL();
                    IList<MDL.T_CellAndEFile> cellList =
                        cellFile.FindByGdFileID(theNode.Name, Globals.ProjectNO);
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

                    MDL.T_FileList fileList_mdl = FileList_BLL.Find(theNode.Name, Globals.ProjectNO);
                    fileList_mdl.selected = 1;
                    FileList_BLL.Update(fileList_mdl);

                    UpdatePDFView((TreeNodeEx)theNode);

                    MDL.T_FileList showfileList_mdl = FileList_BLL.Find(theNode.Name, Globals.ProjectNO);
                    bool update_flg = this.fileBaseInfo.isUpdateInfo_flg;
                    this.fileBaseInfo.sl.Text = MyCommon.ToInt(showfileList_mdl.sl).ToString();//文字张
                    //this.fileBaseInfo.wzz.Text = MyCommon.ToInt(showfileList_mdl.wzz).ToString();// 照片张 注：图样张=图纸张+底图张
                    this.fileBaseInfo.tzz.Text = MyCommon.ToInt(showfileList_mdl.tzz).ToString();//图纸张
                    this.fileBaseInfo.dtz.Text = MyCommon.ToInt(showfileList_mdl.dtz).ToString();//底图张
                    //this.fileBaseInfo.dw.Text = MyCommon.ToInt(showfileList_mdl.dw).ToString(); //注：图样张=照片张+底片张
                    this.fileBaseInfo.zpz.Text = MyCommon.ToInt(showfileList_mdl.zpz).ToString();//照片张  
                    this.fileBaseInfo.dpz.Text = MyCommon.ToInt(showfileList_mdl.dpz).ToString();//底片张
                    this.fileBaseInfo.isUpdateInfo_flg = update_flg;

                    //统计电子文件数
                    TreeNodeEx theNodeParentNode = (TreeNodeEx)theNode;
                    treeFactory.GetCellFileNodesCount(theNodeParentNode, true);

                    if (theNode.ImageIndex == 2 || theNode.ImageIndex == 7)
                        theNode.ImageIndex = (treeFactory.CheckEFileByFileID(theNode.Name, 2) == true) ? 7 : 2;//判断是否有电子文件
                    theNode.SelectedImageIndex = theNode.ImageIndex;
                }
            }
        }
        /// <summary>
        /// 添加组卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddArchive_Click(object sender, EventArgs e)
        {
            this.treeRight.SelectedNode = null;

            frmZJ frmzj = new frmZJ(this);  //初始化资料组卷主窗 传入父窗体
            this.Hide();
            frmzj.ShowDialog();
        }
        /// <summary>
        /// 批量撤销登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsUnMoreRegist_Click(object sender, EventArgs e)
        {
            TreeNode theNode = this.treeRight.SelectedNode;
            if (theNode == null || theNode.ImageIndex == 0 || theNode.ImageIndex == 3
                || (theNode.Text.Trim() == "最近著录过的文件") || (theNode.Parent != null &&
                theNode.Parent.Text.Trim() == "最近著录过的文件"))
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件！");
                return;
            }
            if (theNode.ImageIndex == 1)
            {
                //要先关闭文件，避免资源冲突
                if (axSPApplication1.Documents.ActiveDocument != null)
                    axSPApplication1.Documents.CloseAll();

                FrmUnRegist frm_UnRegist = new FrmUnRegist(theNode, this, "fileStatus=6", treeFactory);
                DialogResult dResult = frm_UnRegist.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    (new TreeFactory()).InitGDTree(Globals.ProjectNO, TreeNodeState_flg, theNode,
                                    true, 2, true);
                }
            }
            else if (theNode.ImageIndex == 2 || theNode.ImageIndex == 5 || theNode.ImageIndex == 4 || theNode.ImageIndex == 7)
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
                    DialogResult check_result =
                        TXMessageBoxExtensions.Question("确定将已经组卷的文件撤销登记吗？  \r\n\n【温馨提示：撤销登记后，文件自动从组卷中移除】");
                    if (check_result == DialogResult.Cancel)
                        return;
                }
                else if (fileMDL1.fileStatus == "0")
                {
                    TXMessageBoxExtensions.Info("提示：成功撤消文件！");
                    return;
                }

                MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(theNode.Name, Globals.ProjectNO);
                if (fileMDL != null && fileMDL.isvisible == 1)
                {
                    fileMDL.ArchiveID = "";
                    fileMDL.fileStatus = "3";
                    theNode.ImageIndex = (treeFactory.CheckEFileByFileID(theNode.Name, 2) == true) ? 7 : 2;//判断是否有电子文件
                    theNode.SelectedImageIndex = theNode.ImageIndex;
                    (new BLL.T_FileList_BLL()).Update(fileMDL);
                    fileBaseInfo.Enabled = true;
                    TXMessageBoxExtensions.Info("提示：成功撤消文件！");
                }
                else
                {
                    TXMessageBoxExtensions.Info("提示：请选择需要撤消的文件！");
                }
            }
            else if (theNode.ImageIndex == 3)
            {
                TXMessageBoxExtensions.Info("提示：请选择有效的文件！");
                return;
            }
        }

        public List<ConvertPdfFile> GeneratePDFList(ListView.SelectedListViewItemCollection ListItems, frm2PDFProgressMsg dlg, string strNameBK = "", TreeNodeEx targeNode = null)
        {
            string tempFolder =
            System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "erm_temp");
            List<ConvertPdfFile> cplist = new List<ConvertPdfFile>();
            int i1 = 0;
            ConvertPdfFile cp = null;
            TransAndSignFile.UserControl1 s = null;
            s = new TransAndSignFile.UserControl1();

            foreach (ListViewItem item in ListItems)
            {
                string eFileID = Guid.NewGuid().ToString();
                string fnOri = item.Name;
                string sExt = System.IO.Path.GetExtension(fnOri);
                string fnPDF = Globals.ProjectPath + "PDF\\" + eFileID + ".pdf";
                if ((sExt.Equals(".jpg", StringComparison.InvariantCultureIgnoreCase) ||
                    sExt.Equals(".jpeg", StringComparison.InvariantCultureIgnoreCase) ||
                    sExt.Equals(".tif", StringComparison.InvariantCultureIgnoreCase) ||
                    sExt.Equals(".tiff", StringComparison.InvariantCultureIgnoreCase) ||
                    sExt.Equals(".bmp", StringComparison.InvariantCultureIgnoreCase) ||
                    sExt.Equals(".png", StringComparison.InvariantCultureIgnoreCase) ||
                    sExt.Equals(".gif", StringComparison.InvariantCultureIgnoreCase) ||
                    sExt.Equals(".doc", StringComparison.InvariantCultureIgnoreCase) ||
                    sExt.Equals(".docx", StringComparison.InvariantCultureIgnoreCase) ||
                    sExt.Equals(".xls", StringComparison.InvariantCultureIgnoreCase) ||
                    sExt.Equals(".xlsx", StringComparison.InvariantCultureIgnoreCase)) && fnOri != "")
                {
                    MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, false);
                    MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, true);
                    try
                    {
                        i1++;
                        if (dlg.label2.Text != "")
                        {
                            dlg.label2.Text = "正在导入：" + i1.ToString() + "/" + ListItems.Count.ToString();
                            dlg.progressBar1.Value = i1;
                            Application.DoEvents();
                        }
                        targeNode.Text = "导入中(" + i1 + "/" + ListItems.Count + ") " + strNameBK;
                        string file_pdf = Path.Combine(tempFolder, Path.GetFileNameWithoutExtension(fnOri) + ".pdf");
                        string msg = string.Empty;

                        //判断文件大小
                        double size = 0;
                        double.TryParse(System.Configuration.ConfigurationManager.AppSettings["uploadFileSize"].ToString(),out size);
                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(fnOri);
                        double fileSize = System.Math.Ceiling(fileInfo.Length / 1024.0 / 1024.0);
                        if (size<fileSize)
                        {
                            TXMessageBoxExtensions.Info("文件大小超过"+size+"M,上传失败!");
                            continue;
                        }

                        string[] jpeg = new string[] { ".jpg", ".jpeg", ".png", ".tif", ".tiff" };
                        int flag = 0;
                        bool result = false;
                        for (int i = 0; i < jpeg.Length; i++)
                        {
                            if (jpeg[i] == sExt.ToLower())
                            {
                                result = ConvertPDF.ImageConvertPdf(fnOri, file_pdf, out msg);
                                flag = 1;
                            }
                        }

                        //string[] excel = new string[] { ".xls", ".xlsx" };
                        //for (int j = 0; j < excel.Length; j++)
                        //{
                        //    if (excel[j] == sExt.ToLower())
                        //    {
                        //        result = ConvertPDF.ExcelConvertPdf(fnOri, file_pdf, out msg);
                        //        flag = 1;
                        //    }
                        //}

                        //string[] word = new string[] { ".doc", ".docx" };
                        //for (int j = 0; j < word.Length; j++)
                        //{
                        //    if (word[j] == sExt.ToLower())
                        //    {
                        //        result = ConvertPDF.WordConvertPdf(fnOri, file_pdf, out msg);
                        //        flag = 1;
                        //    }
                        //}

                        if (flag == 0)
                        {
                            try
                            {
                                 result = s.TransFileToPDF(fnOri, tempFolder, "error");
                            }
                            catch (Exception)
                            {
                               
                            }
                        }

                        if (File.Exists(file_pdf))
                        {
                            File.Copy(file_pdf, fnPDF, true);

                            File.SetAttributes(fnPDF, FileAttributes.Normal);
                        }

                        if (!result)
                        {
                            MyCommon.WriteLog("FileMain转换PDF错误：" + s.GetLastError());
                            TXMessageBoxExtensions.Info("转换PDF失败！\r\n" + s.GetLastError());
                        }
                        else
                        {
                            cp = new ConvertPdfFile();
                            cp.SourceFilePath = fnOri;
                            cp.PDFFilePath = fnPDF;
                            cplist.Add(cp);
                        }
                    }
                    catch (Exception ex)
                    {
                        MyCommon.WriteLog("FileMain转换PDF错误：" + fnOri + " " + ex.Message);
                        TXMessageBoxExtensions.Info("转换PDF失败！\r\n" + fnOri + " " + ex.Message);
                    }
                }
                else if (sExt.Equals(".pdf", StringComparison.InvariantCultureIgnoreCase))
                {
                    i1++;
                    if (dlg.label2.Text != "")
                    {
                        dlg.label2.Text = "正在导入：" + i1.ToString() + "/" + ListItems.Count.ToString();
                        dlg.progressBar1.Value = i1;
                        Application.DoEvents();
                    }
                    targeNode.Text = "导入中(" + i1 + "/" + ListItems.Count + ") " + strNameBK;
                  
                    File.Copy(fnOri, fnPDF);
                    File.SetAttributes(fnPDF, FileAttributes.Normal);

                    cp = new ConvertPdfFile();
                    cp.SourceFilePath = fnOri;
                    cp.PDFFilePath = fnPDF;
                    cplist.Add(cp);
                    Thread.Sleep(100);
                }
            }
            if (dlg != null)
                dlg.Close();

            s.Dispose();
            return cplist;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (treeRight.SelectedNode != null)
                {
                    UpdatePDFView((TreeNodeEx)treeRight.SelectedNode);
                }
            }
            else
            {
                if (axSPApplication1.Documents.ActiveDocument != null)
                    axSPApplication1.Documents.CloseAll();
            }

        }

        private void sp1_MouseUp(object sender, MouseEventArgs e)
        {
        }
    }
}
