using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ERM.Common;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI
{
    /// <summary>
    ///  导出数据
    /// </summary>
    public partial class frmExpData : ERM.UI.Controls.Skin_DevEX
    {
        #region 参数自定义
        ///实例化树的访问类
        private ITreeFactory treeFactory;
        TreeNodeEx TheNode = null;
        string OperationType = null;
        #endregion

        #region 窗体函数

        public frmExpData(TreeNodeEx theNode)
        {
            InitializeComponent();
            treeFactory = new TreeFactory();
            this.Text += "-" + Globals.Projectname;
            TheNode = theNode;
        }
        private void btnExplorer_Click(object sender, EventArgs e)
        {
            if (TheNode != null)
            {
                string showText = TheNode.Text.Substring(TheNode.Text.LastIndexOf("]") + 1);
                saveFileDialog1.FileName = Globals.Projectname + GetParentName(TheNode) + "-" + showText + "(" + DateTime.Now.ToString("yyyyMMdd") + ")";
                saveFileDialog1.FileName = saveFileDialog1.FileName.Replace("--", "-").Replace("*", "").Replace("<", "").Replace(">", "");
            }
            else
            {
                saveFileDialog1.FileName = Globals.Projectname + "-" + "(" + DateTime.Now.ToString("yyyyMMdd") + ")";
            }
            saveFileDialog1.Filter = "待导出NOD包(*.nod) | *.nod";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLoc.Text = saveFileDialog1.FileName;
            }
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            txtLoc.Text = txtLoc.Text.Trim();
            if (txtLoc.Text == "")
            {
                TXMessageBoxExtensions.Info("提示：请选择导出文件的存储路径！");
                txtLoc.Focus();
                return;
            }
            string destFilename = MyCommon.GetFileShortName(txtLoc.Text);
            string destFolder = Path.GetDirectoryName(txtLoc.Text);
            if (!Directory.Exists(destFolder))
            {
                TXMessageBoxExtensions.Info("存储的路径不存在！");
                return;
            }
            /// <summary>
            /// 导出功能涉及的文件临时存放目录
            /// </summary>
            string tempFullName =
                Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\ERM\\OutDataTemp";

            try
            {
                btnCancel.Enabled = false;
                btnConfirm.Enabled = false;
                btnExplorer.Enabled = false;

                if (System.IO.Directory.Exists(tempFullName))
                    MyCommon.DeleteFilesAndFolders(tempFullName);
                Directory.CreateDirectory(tempFullName);
                   // MyCommon.DeleteAndCreateEmptyDirectory(tempFullName, false);
                //MyCommon.DeleteAndCreateEmptyDirectory(tempFullName);

                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName + "\\" + TheNode.Name + "\\T_GdList\\");
                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName + "\\" + TheNode.Name + "\\T_FileList\\");
                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName + "\\" + TheNode.Name + "\\T_CellAndEFile\\");
                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName + "\\" + TheNode.Name + "\\T_CellAndEFile\\ODOC\\");//原文
                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName + "\\" + TheNode.Name + "\\T_CellAndEFile\\PDF\\");//原文的PDF文件
                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName + "\\" + TheNode.Name + "\\T_CellAndEFile\\MPDF\\");//文件级电子文件，带章

                int sumCount = 0;
                GetNodesCount(TheNode, ref sumCount);
                GetChildToFileCount(TheNode, ref sumCount);
                progressBar1.Maximum = sumCount;

                ParentToFile(TheNode, tempFullName + "\\" + TheNode.Name);
                ChildToFile(TheNode, tempFullName + "\\" + TheNode.Name);

                lblTitle.Text = @"正在压缩导出数据....";
                progressBar1.Value = progressBar1.Maximum / 2;
                Application.DoEvents();

                //Common.ZipFile zip = new Common.ZipFile(tempFullName + "\\", txtLoc.Text);
                //zip.StartZip();

                SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
                SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
                tmp.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                tmp.CompressDirectory(tempFullName + "\\", txtLoc.Text);

                System.Threading.Thread.Sleep(1000);

                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName, false);//删除文件夹

                lblTitle.Text = @"导出完成！";
                Application.DoEvents();

                this.DialogResult = DialogResult.OK;
                btnCancel.Enabled = true;
                btnConfirm.Enabled = true;
                btnExplorer.Enabled = true;
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info(ex.Message);
                this.DialogResult = DialogResult.Cancel;
                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName, false);//删除文件夹
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 自定义函数
        private string GetParentName(TreeNodeEx node)
        {
            string _result = string.Empty;
            if (node.Level != 0)
            {
                if (node.Parent.Level != 0)
                {
                    _result = node.Parent.Text + "-" + _result;
                    _result = GetParentName((TreeNodeEx)node.Parent) + "-" + _result;
                }
            }
            if (_result == string.Empty)
            {
                _result = "-";
            }
            return _result;
        }
        /// <summary>
        /// 获取父节点总数 YQ 2011-0617
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeSumCount"></param>
        private void GetNodesCount(TreeNodeEx node, ref int nodeSumCount)
        {
            if (node != null)
            {
                nodeSumCount++;
            }
            if (node.Parent != null)
            {
                GetNodesCount((TreeNodeEx)node.Parent, ref nodeSumCount);
            }
        }
        /// <summary>
        /// 获取子节点总数 YQ 2011-0617
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeSumCount"></param>
        private void GetChildToFileCount(TreeNodeEx node, ref int nodeSumCount)
        {
            foreach (TreeNodeEx childNode in node.Nodes)
            {
                nodeSumCount++;
            }
            nodeSumCount++;
        }

        int curIndex = 0;//状态栏 变量 YQ 2011-0617
        private void ParentToFile(TreeNodeEx node, string TempSavePath)
        {
            if (node != null)
            {//父 一定是文件级
                CreateFile("T_FileList", node.Name, TempSavePath);
            }
            if (node.Parent != null)
            {
                ParentToFile((TreeNodeEx)node.Parent, TempSavePath);
            }
        }
        private void ChildToFile(TreeNodeEx node, string TempSavePath)
        {
            foreach (TreeNodeEx childNode in node.Nodes)
            {
                if (childNode.ImageIndex != 3)
                {
                    CreateFile("T_FileList", childNode.Name, TempSavePath);
                    ChildToFile(childNode, TempSavePath);
                }
            }
            if (node.ImageIndex != 3)
                CreateFile("T_CellAndEFile", node.Name, TempSavePath);
        }

        private void CreateFile(string TableName, string ID, string TempSavePath)
        {
            if (TableName == "T_FileList")
            {
                BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                MDL.T_FileList fileMDL = fileBLL.Find(ID, Globals.ProjectNO);
                if (fileMDL != null)
                {
                    List<MDL.T_FileList> fileList = new List<ERM.MDL.T_FileList>();
                    fileList.Add(fileMDL);
                    DataTable ds = MyCommon.ToDataTable<MDL.T_FileList>(fileList);
                    ds.TableName = "T_FileList_" + ID;
                    ds.WriteXml(TempSavePath + "\\T_FileList\\" + ID + ".xml", XmlWriteMode.WriteSchema);

                    lblTitle.Text = @"正在导出：" + fileMDL.wjtm;

                    if (!string.IsNullOrEmpty(fileMDL.filepath)&&
                        System.IO.File.Exists(Globals.ProjectPath + fileMDL.filepath))//pdf文件
                    {
                        System.IO.File.Copy(Globals.ProjectPath + fileMDL.filepath,
                            TempSavePath + "\\T_CellAndEFile\\" + fileMDL.filepath, true);
                    }
                }
                else
                {
                    MDL.T_GdList gdList_MDL = (new BLL.T_GdList_BLL()).FindIDAndProjectNo(ID, Globals.ProjectNO);
                    if (gdList_MDL != null)
                    {
                        List<MDL.T_GdList> GdList = new List<ERM.MDL.T_GdList>();
                        GdList.Add(gdList_MDL);
                        DataTable ds = MyCommon.ToDataTable<MDL.T_GdList>(GdList);
                        ds.TableName = "T_GdList_" + ID;
                        ds.WriteXml(TempSavePath + "\\T_GdList\\" + ID + ".xml", XmlWriteMode.WriteSchema);

                        lblTitle.Text = @"正在导出：" + gdList_MDL.GdName;
                    }
                }
                if (curIndex < progressBar1.Maximum)
                    progressBar1.Value = curIndex++;
                else
                    progressBar1.Value = progressBar1.Maximum - 1;
                Application.DoEvents();
            }
            else if (TableName == "T_CellAndEFile")
            {
                BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
                IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByGdFileID(ID, Globals.ProjectNO);
                if (cellList.Count > 0)
                {
                    ///移除没有保存的电子表格
                    //    for (int i = 0; i < cellList.Count; i++)
                    //    {
                    //        if (cellList[i].DoStatus != 1)
                    //        {
                    //            cellList.RemoveAt(i);
                    //            i--;
                    //        }
                    //    }

                    if (cellList.Count > 0)
                    {
                        BLL.T_CellFileTemplate_BLL cellTplBLL = new ERM.BLL.T_CellFileTemplate_BLL();
                        foreach (MDL.T_CellAndEFile cellMDL in cellList)
                        {
                            if (cellMDL.filepath == null || cellMDL.filepath.Trim() == "")
                            {
                                MDL.T_CellFileTemplate cellTplMDL = cellTplBLL.Find(cellMDL.CellID);
                                if (cellTplMDL != null)
                                {
                                    string CelllTplFile = Application.StartupPath + "\\Template" + cellTplMDL.filepath;
                                    if (System.IO.File.Exists(CelllTplFile))
                                    {
                                        FileInfo fileInfo = new FileInfo(CelllTplFile);
                                        string NewCellFileID = cellMDL.CellID;
                                        cellMDL.filepath = "ODOC\\" + NewCellFileID + fileInfo.Extension;
                                        string NewCellFile = TempSavePath + "\\T_CellAndEFile\\ODOC\\" + NewCellFileID + fileInfo.Extension;
                                        System.IO.File.Copy(CelllTplFile, NewCellFile, true);
                                    }
                                }
                            }
                            else
                            {
                                if (System.IO.File.Exists(Globals.ProjectPath + cellMDL.filepath))//原件
                                    System.IO.File.Copy(Globals.ProjectPath + cellMDL.filepath, TempSavePath + "\\T_CellAndEFile\\" + cellMDL.filepath, true);
                                if (System.IO.File.Exists(Globals.ProjectPath + cellMDL.fileTreePath))//pdf文件
                                    System.IO.File.Copy(Globals.ProjectPath + cellMDL.fileTreePath, TempSavePath + "\\T_CellAndEFile\\" + cellMDL.fileTreePath, true);
                            }
                        }
                        DataTable ds2 = MyCommon.ToDataTable<MDL.T_CellAndEFile>(cellList);
                        ds2.TableName = "T_CellAndEFile_" + ID;
                        ds2.WriteXml(TempSavePath + "\\T_CellAndEFile\\" + ID + ".xml", XmlWriteMode.WriteSchema);

                    }
                }
                if (curIndex < progressBar1.Maximum)
                    progressBar1.Value = curIndex++;
                else
                    progressBar1.Value = progressBar1.Maximum - 1;
                Application.DoEvents();
            }
        }
        #endregion

        private void frmExpData_Load(object sender, EventArgs e)
        {

        }

        private void btnExplorer_Click_1(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
