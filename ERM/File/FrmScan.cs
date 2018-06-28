using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using System.Collections;
using System.IO;
using BCL.easyPDF6.Interop.EasyPDFPrinter.Digipower;
using BCL.easyPDF6.Interop.EasyPDFProcessor.Digipower;
using ERM.MDL;
using ERM.CBLL;
using System.Threading;
using System.Runtime.InteropServices;
using CAPICOM;
namespace ERM.UI
{
    public partial class FrmScan : Form
    {
        int curSelNoFrmThum = 0;
        bool hasEdit = false;
        string strCurrentPicPath = string.Empty;
        public string strTitle = string.Empty;
        int regionLeft = 0;
        int regionTop = 0;
        int regionWidth = 0;
        int regionHeight = 0;
        ArrayList arrPic = new ArrayList();
        private TreeNodeEx NewNode;
        string MovedCellPath = Globals.ODOCPath + "\\";
        string PDFPath = Globals.SPDFPath + "\\";
        string projectPath = Globals.ProjectPath + "\\";
        string reportsPath = Globals.ReportsPath + "\\";
        private Form _parentForm;
        private string FileID = null;
        private ITreeFactory treeFactory;
        public FrmScan(TreeNodeEx node,Form PartentForm,ITreeFactory Itree)
        {
            treeFactory = Itree;
            try
            {
                InitializeComponent();
            }
            catch
            {
                MessageBox.Show("没有安装扫描控件，请打开安装包安装！");
                this.DialogResult = DialogResult.OK;
                return;
            }
            tssLabel1.Text = "就绪";
            tssLabel2.Text = Globals.AppTitle;
            tssLabel3.Text = Globals.LoginUser;
                string strSql = "select filestatus from T_FileList where ProjectNO='" + Globals.ProjectNO + "' and treepath='" + Functions.OpeartPath(node) + "'";
                object tmp = Digi.DBUtility.DbHelperOleDb.GetSingle(strSql);
                if (tmp != null && (tmp.ToString() == "4" || tmp.ToString() == "5"))
                {
                    MessageBox.Show("该模板已提交，不能扫描或编辑之下的文件。");
                    this.DialogResult = DialogResult.OK;
                }
                NewNode = node;
                getAllFileFromTemplateNode(node);
                _parentForm = PartentForm;
                FileID = Guid.NewGuid().ToString();
        }
        private void getAllFileFromTemplateNode(TreeNodeEx node)
        {
            tscmbDisp.SelectedIndex = 0;
            tscmbScale.SelectedIndex = 2;
            tsCut.SelectedIndex = 0;
            if(System.IO.File.Exists(reportsPath+"temp.tif"))
            {
                System.IO.File.Delete(reportsPath+"temp.tif");
            }
            string strSql = "select * from attachment where fileTreePath='" + treeFactory.OpeartPath(node) + "' and ProjectNO='" + Globals.ProjectNO + "'";
            strSql += " order by fileorderindex,attachid";
            DataSet ds = null;
            ds = Digi.DBUtility.DbHelperOleDb.Query(strSql);
            axImgAdmin1.Image = reportsPath + "temp.tif";
            axImgAdmin1.Append(reportsPath+"blank.tif",1,1);
            string str = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                str = ds.Tables[0].Rows[i]["yswjpath"].ToString();
                str = str.Substring(str.LastIndexOf(".") + 1);
                str = str.ToLower();
                if(str=="jpg"||str=="bmp"||str=="gif"||str=="tif")
                {
                    arrPic.Add(projectPath+Globals.ProjectNO+"\\ODoc\\"+ds.Tables[0].Rows[i]["yswjpath"].ToString());
                    axImgAdmin1.Append(projectPath + Globals.ProjectNO + "\\ODoc\\" + ds.Tables[0].Rows[i]["yswjpath"].ToString(), 1, 1);
                }
            }
            axImgAdmin1.DeletePages(1, 1);
            axImgEdit1.ImagePalette = ImgeditLibCtl.ImagePaletteConstants.wiPaletteRGB24;
            if (arrPic.Count == 0)
                this.axImgEdit1.Image = reportsPath + "blank.jpg";
            else
            {
                axImgThumbnail1.Image = reportsPath + "temp.tif";
                this.axImgEdit1.Image = arrPic[0].ToString();
            }
            axImgEdit1.RenderAllPages(-100,-100);
             axImgEdit1.Display();
            if (arrPic.Count > 0)
                curSelNoFrmThum = 1;
            else
                curSelNoFrmThum = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsScan_Click(object sender, EventArgs e)
        {
            Scan();
            for (int i = 1; i < axImgThumbnail1.ThumbCount;i++ )
            {
                axImgThumbnail1.ScrollThumbs(0, 0);
            }
        }
        /// <summary>
        /// 扫描
        /// </summary>
        public void Scan()
        {
            if (!imageScan.ScannerAvailable())
            {
                MessageBox.Show("没有扫描仪，无法扫描！");
                return;
            }
            try
            {
                if (NewNode.ImageIndex == 2)
                {
                    frmFileAdd fileAdd = new frmFileAdd(_parentForm);
                    fileAdd.Regist(NewNode);
                }
                FileID = Guid.NewGuid().ToString();
                imageScan.OpenScanner();
                imageScan.ScanTo = ScanLibCtl.ScanToConstants.FileOnly;
                imageScan.MultiPage = true;
                imageScan.FileType = ScanLibCtl.FileTypeConstants.TIFF;
                imageScan.Image = MovedCellPath + FileID + ".tif";
                if (tscmbDisp.SelectedItem.ToString() == "不显示扫描设置")
                    imageScan.ShowSetupBeforeScan = false;
                else
                    imageScan.ShowSetupBeforeScan = true;
                int iScan = imageScan.StartScan();
                if (iScan > 0)
                    return;
                string strScanFileName = string.Empty;
                System.IO.DirectoryInfo dcInfo = new System.IO.DirectoryInfo(imageScan.Image);
                strScanFileName = dcInfo.Name;
                imageScan.CloseScanner();
                if (strScanFileName != "")
                {
                    ERM.UI.File.frmTitle formTitle = new ERM.UI.File.frmTitle(this);
                    if (formTitle.ShowDialog() == DialogResult.OK)
                    {
                        frmFileAdd add = new frmFileAdd(_parentForm);
                        TreeNode tn = add.AddExternalFile(MovedCellPath + FileID + ".tif", NewNode, null, "OTHER", "");
                        strCurrentPicPath = MovedCellPath + FileID + ".tif";
                        ////修改数据库中title
                        ERM.CBLL.FileRegist fileRegist = new FileRegist();
                        fileRegist.UpdateAttachmentTitle(OpeartPath((TreeNodeEx)(NewNode)), Globals.ProjectNO, FileID, strTitle);
                        tn.Text = strTitle;
                        axImgEdit1.ImagePalette = ImgeditLibCtl.ImagePaletteConstants.wiPaletteRGB24;
                        this.axImgEdit1.Image = MovedCellPath + tn.Name + ".tif";
                        this.axImgEdit1.Zoom = 100;
                        this.axImgEdit1.Display();
                        arrPic.Add(this.axImgEdit1.Image);
                        axImgAdmin1.Insert(this.axImgEdit1.Image, 1, axImgThumbnail1.ThumbCount + 1, 1);
                        axImgAdmin1.Refresh();
                        axImgThumbnail1.Image = reportsPath + "temp.tif";
                        axImgThumbnail1.Refresh();
                        if (System.IO.File.Exists(MovedCellPath + FileID + ".tif"))
                        {
                            System.IO.File.Delete(MovedCellPath + FileID + ".tif");
                        }
                        hasEdit = false;
                        curSelNoFrmThum = 1;
                    }
                }
                else
                {
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 去掉路径中的[0],*
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string OpeartPath(TreeNodeEx node)
        {
            if (node != null && node.Parent != null)
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
        /// 左转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsLeft_Click(object sender, EventArgs e)
        {
            this.axImgEdit1.RotateLeft();
            hasEdit = true;
        }
        /// <summary>
        /// 右转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsRight_Click(object sender, EventArgs e)
        {
            this.axImgEdit1.RotateRight();
            hasEdit = true;
        }
        /// <summary>
        /// 裁切
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCurt_Click(object sender, EventArgs e)
        {
            try
            {
                this.axImgEdit1.Crop();
                hasEdit = true;
            }
            catch
            {
                MessageBox.Show("请先框选图片内容后再裁切！");
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsSave_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
        { 
            try
            {
                if (!hasEdit)
                    return;
                this.axImgEdit1.SaveAs(this.axImgEdit1.Image);
                System.IO.File.Delete(this.axImgEdit1.Image.Substring(0, this.axImgEdit1.Image.Length - 4) + "daf");
                string newDafName = PrintToPDF(this.axImgEdit1.Image, null, Guid.NewGuid().ToString());
                string strSql = "update attachment set filepath='"+newDafName+"'";
                strSql += " where ProjectNO='"+Globals.ProjectNO+"' and yswjpath='"+this.axImgEdit1.Image.Substring(axImgEdit1.Image.LastIndexOf("\\")+1)+"'";
                Digi.DBUtility.DbHelperOleDb.ExecuteSql(strSql);
                axImgAdmin1.Refresh();
                axImgAdmin1.DeletePages(curSelNoFrmThum, 1);
                axImgAdmin1.Insert(this.axImgEdit1.Image, 1, curSelNoFrmThum, 1);
                axImgAdmin1.Refresh();
                axImgThumbnail1.Image = reportsPath + "temp.tif";
                axImgThumbnail1.Refresh();
                hasEdit = false;
                for (int i = 1; i < curSelNoFrmThum; i++)
                {
                    axImgThumbnail1.ScrollThumbs(0, 0);
                }
            }
            catch
            {
                hasEdit = true;
                MessageBox.Show("保存失败！");
            }
        }
        private void saveExit()
        {
            try
            {
                if (!hasEdit)
                    return;
                this.axImgEdit1.SaveAs(this.axImgEdit1.Image);
                System.IO.File.Delete(this.axImgEdit1.Image.Substring(0, this.axImgEdit1.Image.Length - 4) + "daf");
                string newDafName = PrintToPDF(this.axImgEdit1.Image, null, Guid.NewGuid().ToString());
                string strSql = "update attachment set filepath='" + newDafName + "'";
                strSql += " where ProjectNO='" + Globals.ProjectNO + "' and yswjpath='" + this.axImgEdit1.Image.Substring(axImgEdit1.Image.LastIndexOf("\\") + 1) + "'";
                Digi.DBUtility.DbHelperOleDb.ExecuteSql(strSql);
                axImgAdmin1.Refresh();
                axImgAdmin1.DeletePages(curSelNoFrmThum, 1);
                axImgAdmin1.Insert(this.axImgEdit1.Image, 1, curSelNoFrmThum, 1);
                axImgAdmin1.Refresh();
                axImgThumbnail1.Image = reportsPath + "temp.tif";
                axImgThumbnail1.Refresh();
                hasEdit = false;
            }
            catch
            {
                MessageBox.Show("保存失败！");
                hasEdit = true;
            }
        }
        private void tsMax_Click(object sender, EventArgs e)
        {
            try
            {
                axImgEdit1.Zoom = axImgEdit1.Zoom * 1.2f;
                axImgEdit1.Refresh();
                hasEdit = true;
            }
            catch
            {}
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                axImgEdit1.Zoom = axImgEdit1.Zoom * 0.8f;
                axImgEdit1.Refresh();
                hasEdit = true;
            }
            catch
            { }
        }
        private void tsFix_Click(object sender, EventArgs e)
        {
            axImgEdit1.FitTo(0);
            hasEdit = true;
        }
        private void tsWidthFix_Click(object sender, EventArgs e)
        {
            try
            {
                float bei = 0;
                bei = (float)axImgEdit1.Width / (float)axImgEdit1.ImageScaleWidth;
                axImgEdit1.Zoom = axImgEdit1.Zoom * bei;
                axImgEdit1.Refresh();
                hasEdit = true;
            }
            catch
            {}
        }
        private void tsMicro_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = true;
        }
        private void tsSinglePage_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
        }
        private void tsPageMicro_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = false;
        }
        private void tscmbDisp_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            if (hasEdit)
            {
                dialog = MessageBox.Show("是否保存已作的修改？", "扫描", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button3);
                if (dialog == DialogResult.Yes)
                { 
                    saveExit();
                    this.DialogResult = DialogResult.OK;
                }
                if (dialog == DialogResult.No)
                { 
                    hasEdit = false;
                    this.DialogResult = DialogResult.OK;
                }
                if (dialog == DialogResult.Cancel)
                {}
            }
            else
                this.DialogResult = DialogResult.OK;
        }
        private void FrmScan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hasEdit)
            {
                DialogResult dialog = MessageBox.Show("是否保存已作的修改？", "扫描", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                if (dialog == DialogResult.Yes)
                {
                    saveExit();
                    this.DialogResult = DialogResult.OK;
                }
                if (dialog == DialogResult.No)
                {
                    this.DialogResult = DialogResult.OK;
                    hasEdit = false;
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
            TreeFactory treeFactory = new TreeFactory();
            NewNode.Nodes.Clear();
            if (NewNode.Nodes.Count <= 0)
            {
                treeFactory.AddFileNode(NewNode, Globals.ProjectNO);
            }
            frmFileAdd frm = new frmFileAdd(_parentForm);
            frm.treeRight.SelectedNode = NewNode.LastNode;
        }
        private void tsNewScan_Click(object sender, EventArgs e)
        {
            if (!imageScan.ScannerAvailable())
            {
                MessageBox.Show("没有扫描仪，无法扫描！");
                return;
            }
            if(MessageBox.Show("你确定要替换扫描吗？","替换扫描",MessageBoxButtons.YesNo,MessageBoxIcon.None,MessageBoxDefaultButton.Button1)==DialogResult.Yes)
            {
                if (curSelNoFrmThum == 0)
                    return;
                int selNo = curSelNoFrmThum;
                if (selNo == 0)
                    return;
                string pathSrc = arrPic[selNo - 1].ToString();
                string nameDaf = pathSrc;
                nameDaf = nameDaf.Substring(nameDaf.LastIndexOf("\\") + 1);
                nameDaf = nameDaf.Substring(0, nameDaf.LastIndexOf(".") + 1) + "daf";
                string pathDaf = Globals.SPDFPath + "\\" + nameDaf;
                System.IO.File.Delete(pathSrc);
                System.IO.File.Delete(pathDaf);
                if(NewNode.ImageIndex==2)
                {
                    frmFileAdd fileAdd = new frmFileAdd(_parentForm);
                    fileAdd.Regist(NewNode);
                }
                imageScan.OpenScanner();
                string newName = Guid.NewGuid().ToString();
                axImgEdit1.ImagePalette = ImgeditLibCtl.ImagePaletteConstants.wiPaletteRGB24;
                imageScan.ScanTo = ScanLibCtl.ScanToConstants.FileOnly;
                imageScan.MultiPage = true;
                imageScan.FileType = ScanLibCtl.FileTypeConstants.TIFF;
                imageScan.Image = Globals.ODOCPath+"\\"+newName+".tif";
                if (tscmbDisp.SelectedItem.ToString() == "不显示扫描设置")
                    imageScan.ShowSetupBeforeScan = false;
                else
                    imageScan.ShowSetupBeforeScan = true;
                int iScan = imageScan.StartScan();
                if (iScan > 0)
                    return;
                string strScanFileName = string.Empty;
                System.IO.DirectoryInfo dcInfo = new System.IO.DirectoryInfo(imageScan.Image);
                strScanFileName = dcInfo.Name;
                imageScan.CloseScanner();
                if (strScanFileName != "")
                {
                    PrintToPDF(Globals.ODOCPath + "\\" + newName + ".tif", null, newName);
                    axImgAdmin1.DeletePages(selNo, 1);
                    axImgAdmin1.Insert(Globals.ODOCPath + "\\" + newName + ".tif", 1, selNo, 1);
                    axImgAdmin1.Refresh();
                    axImgEdit1.ImagePalette = ImgeditLibCtl.ImagePaletteConstants.wiPaletteRGB24;
                    arrPic[selNo-1] = Globals.ODOCPath+"\\"+newName+".tif";
                    this.axImgEdit1.Image = arrPic[selNo-1].ToString();
                    this.axImgEdit1.Display();
                    axImgThumbnail1.Image = reportsPath + "temp.tif";
                    axImgThumbnail1.Refresh();
                    for (int i = 1; i < selNo; i++)
                    {
                        axImgThumbnail1.ScrollThumbs(0, 0);
                    }
                    hasEdit = false;
                    string strSql = "update attachment set yswjpath='"+newName+".tif',ext='tif',filepath='"+newName+".daf'";
                    strSql += " where ProjectNO='"+Globals.ProjectNO+"' and yswjpath='"+pathSrc.Substring(pathSrc.LastIndexOf("\\")+1)+"'";
                    Digi.DBUtility.DbHelperOleDb.ExecuteSql(strSql);
                    RegistEnum treeEnum = RegistEnum.FULL;
                    TreeFactory treeFactory = new TreeFactory();
                    treeFactory.RefreshFileNode(NewNode, true, Globals.ProjectNO, true, false, treeEnum,true);
                    MessageBox.Show("替换扫描成功！");
                }
            }
            ////取待删除的文件名
            ////扫描
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton2.PerformClick();
        }
        private void ToolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            tsSave.PerformClick();
        }
        private void ToolStripMenuItemScanNew_Click(object sender, EventArgs e)
        {
            tsScan.PerformClick();
        }
        private void ToolStripMenuItemScanAgain_Click(object sender, EventArgs e)
        {
            tsNewScan.PerformClick();
        }
        private void ToolStripMenuItemCut_Click(object sender, EventArgs e)
        {
            tsCurt.PerformClick();
        }
        private void ToolStripMenuItemMax_Click(object sender, EventArgs e)
        {
            tsMax.PerformClick();
        }
        private void ToolStripMenuItemMin_Click(object sender, EventArgs e)
        {
            toolStripButton1.PerformClick();
        }
        private void ToolStripMenuItemTurnLeft_Click(object sender, EventArgs e)
        {
            tsLeft.PerformClick();
        }
        private void ToolStripMenuItemTurnRight_Click(object sender, EventArgs e)
        {
            tsRight.PerformClick();
        }
        private void ToolStripMenuItemFix_Click(object sender, EventArgs e)
        {
            tsFix.PerformClick();
        }
        private void ToolStripMenuItemFixWidth_Click(object sender, EventArgs e)
        {
            tsWidthFix.PerformClick();
        }
        private void ToolStripMenuItemMicro_Click(object sender, EventArgs e)
        {
            tsMicro.PerformClick();
        }
        private void ToolStripMenuItemSingle_Click(object sender, EventArgs e)
        {
            tsSinglePage.PerformClick();
        }
        private void ToolStripMenuItemPageAndMicro_Click(object sender, EventArgs e)
        {
            tsPageMicro.PerformClick();
        }
        private void ToolStripMenuItemselectscan_Click(object sender, EventArgs e)
        {
            imageScan.ShowSelectScanner();
        }
        private void tsdel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要删除吗？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                del(curSelNoFrmThum);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thumNo">待删除图片在缩略图中的序号，从1开始</param>
        private void del(int thumNo)
        {
            int selNo = thumNo;
            if (selNo == 0)
                return;
            string pathSrc = arrPic[selNo-1].ToString();
            string nameDaf = pathSrc;
            nameDaf = nameDaf.Substring(nameDaf.LastIndexOf("\\") + 1);
            nameDaf = nameDaf.Substring(0, nameDaf.LastIndexOf(".") + 1) + "daf";
            string pathDaf = Globals.SPDFPath + "\\" + nameDaf;
            System.IO.File.Delete(pathSrc);
            System.IO.File.Delete(pathDaf);
            string strSql = "delete from attachment where ProjectNO='" + Globals.ProjectNO + "' and yswjpath='" + pathSrc.Substring(pathSrc.LastIndexOf("\\") + 1) + "'";
            Digi.DBUtility.DbHelperOleDb.ExecuteSql(strSql);
            arrPic.Remove(axImgEdit1.Image);
                axImgAdmin1.DeletePages(selNo, 1);
            if (arrPic.Count > 0)
            {
                axImgThumbnail1.Image = reportsPath + "temp.tif";
                axImgThumbnail1.Refresh();
                axImgThumbnail1.set_ThumbSelected(1, true);
                axImgEdit1.Image = arrPic[0].ToString();
                axImgEdit1.Display();
                strCurrentPicPath = arrPic[0].ToString();
                curSelNoFrmThum = 1;
                hasEdit = false;
            }
            else
            { 
                axImgThumbnail1.Image = "";
                axImgThumbnail1.Refresh();
                axImgEdit1.Image = reportsPath + "blank.jpg";
                curSelNoFrmThum = 0;
                strCurrentPicPath = "";
                hasEdit = false;
            }
        }
        private void tscmbScale_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void tscmbDisp_DropDownClosed(object sender, EventArgs e)
        {
            string disp = tscmbDisp.SelectedItem.ToString();
            if (disp == "显示扫描设置")
            {
                imageScan.ShowSetupBeforeScan = true;
            }
            else
            {
                imageScan.ShowSetupBeforeScan = false;
            }
        }
        private void tscmbScale_DropDownClosed(object sender, EventArgs e)
        {
            if (axImgEdit1.Image != "")
            {
                string strZoomSize = this.tscmbScale.SelectedItem.ToString();
                int zoomSize = 100;
                switch (strZoomSize)
                {
                    case "25%":
                        zoomSize = 25;
                        break;
                    case "50%":
                        zoomSize = 50;
                        break;
                    case "100%":
                        zoomSize = 100;
                        break;
                    case "150%":
                        zoomSize = 150;
                        break;
                    case "200%":
                        zoomSize = 200;
                        break;
                    case "300%":
                        zoomSize = 300;
                        break;
                    case "400%":
                        zoomSize = 400;
                        break;
                }
                this.axImgEdit1.Zoom = zoomSize;
                this.axImgEdit1.Refresh();
            }
        }
        private void tsCut_DropDownClosed(object sender, EventArgs e)
        {
            string removeType = this.tsCut.SelectedItem.ToString();
            if (removeType == "请选择去除方式")
                return;
            int width = this.axImgEdit1.ImageScaleWidth;
            int height = this.axImgEdit1.ImageScaleHeight;
            if (regionWidth == 0)
            {
                MessageBox.Show("未选中任何区域！");
                return;
            }
            switch (removeType)
            {
                case "去除选中区域":
                    this.axImgEdit1.DeleteImageData(regionLeft, regionTop, regionWidth, regionHeight);
                    hasEdit = true;
                    break;
                case "去除未选中区域":
                    this.axImgEdit1.DeleteImageData(0, 0, width, regionTop);
                    this.axImgEdit1.DeleteImageData(0, regionTop + regionHeight, width, height - regionTop - regionHeight);
                    this.axImgEdit1.DeleteImageData(0, regionTop, regionLeft, regionHeight);
                    this.axImgEdit1.DeleteImageData(regionLeft + regionWidth, regionTop, width - regionLeft - regionWidth, regionHeight);
                    hasEdit = true;
                    break;
            }
        }
        private void axImgThumbnail1_ClickEvent_1(object sender, AxThumbnailLibCtl._DImgThumbnailEvents_ClickEvent e)
        {
            if (hasEdit)
            {
                if (MessageBox.Show("是否需要保存刚才编辑过的图片？", "保存图片", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    save();
                else
                    hasEdit = false;
            }
            int selNo = e.thumbNumber;
            curSelNoFrmThum = selNo;
            if (selNo == 0)
            {
                return;
            }
            string picPath = arrPic[selNo-1].ToString();
            axImgEdit1.RemoveImageCache(axImgEdit1.Image, 1);
            axImgEdit1.Image = picPath;
            axImgEdit1.Zoom = 100;
            axImgEdit1.Display();
            strCurrentPicPath = arrPic[selNo-1].ToString();
            for (int i = 1; i <= axImgThumbnail1.ThumbCount; i++)
            {
                this.axImgThumbnail1.set_ThumbSelected(i, false);    
            }
            this.axImgThumbnail1.set_ThumbSelected(selNo, true);
        }
        ////////////根据模板节点和原始图片物理路径得到电子文件节点
        //////////private TreeNodeEx getNodeByOldFile(TreeNodeEx node,string filePath)
        //////////{
        //////////    TreeNodeEx treeNode = new TreeNodeEx();
        //////////    //不含路径的文件名
        //////////    string strFileName = string.Empty;
        //////////    strFileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
        //////////    //根据文件物理路径从数据库中取treepath（即节点的fullpath）
        //////////    string strSql = "select fileTreePath from attachment";
        //////////    strSql += " where ProjectNO='"+Globals.ProjectNO+"'";
        //////////    strSql += " and yswjpath='"+strFileName+"'";
        //////////    object result = Digi.DBUtility.DbHelperOleDb.GetSingle(strSql);
        //////////    string treePath = string.Empty;
        //////////    if (result != null)
        //////////        treePath = result.ToString();
        //////////    foreach (TreeNodeEx tn in node.Nodes)
        //////////    {
        //////////        if (tn.FullPath == result)
        //////////        {
        //////////            treeNode = tn;
        //////////            break;
        //////////        }
        //////////    }
        //////////    return treeNode;
        //////////}
        /// <summary>
        /// 将指定文件打印成PDF
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="NewNode"></param>
        private string PrintToPDF(string FilePath, TreeNodeEx NewNode, string ArID)
        {
            PrintNow p = new PrintNow(1);
            Printer oPrinter = null;
            PrintJob oPrintJob = null;
            Type type = Type.GetTypeFromProgID("easyPDF.Printer.Digipower.6");
            oPrinter = (Printer)Activator.CreateInstance(type);
            oPrinter.Initialize("Digipower PDF Printer");
            oPrinter.LicenseKey = GetLicenseKey();
            oPrintJob = oPrinter.PrintJob;
            p.Show();
            oPrintJob.PrintOut(FilePath, PDFPath + ArID + ".pdf");
            if (System.IO.File.Exists(PDFPath + ArID + ".pdf"))
            {
                System.IO.File.Copy(PDFPath + ArID + ".pdf", PDFPath + ArID + ".daf", true);
                System.IO.File.Delete(PDFPath + ArID + ".pdf");
            }
            p.timer1.Stop();
            p.Close();
            return ArID + ".daf";
        }
        private void tsmnuRotateAny_Click(object sender, EventArgs e)
        {
            ERM.UI.File.frmRotate frm = new ERM.UI.File.frmRotate(this);
            frm.ShowDialog();
        }
        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void axImgEdit1_SelectionRectDrawn_1(object sender, AxImgeditLibCtl._DImgEditEvents_SelectionRectDrawnEvent e)
        {
            regionLeft = e.left;
            regionTop = e.top;
            regionWidth = e.width;
            regionHeight = e.height;
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private string GetLicenseKey()
        {
            return Globals.LicenseKey;
        }
    }
}
