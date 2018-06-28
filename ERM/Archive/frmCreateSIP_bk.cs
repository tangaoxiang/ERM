using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;
using ERM.Common;
using System.Threading;
namespace ERM.UI
{
    public partial class frmCreateSIP : Form
    {
        ERM.CBLL.FinalArchive CBFinalArchive = new ERM.CBLL.FinalArchive();
        ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);
        FileToStringXml filetostringxml = new FileToStringXml();
        string destFolder;
        public frmCreateSIP()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCreateSIP_Load(object sender, EventArgs e)
        {
            this.txtProjectName.Text = Globals.Projectname.ToString();
            panelTop.Dock = DockStyle.Fill;
            panelBottom.Dock = DockStyle.Fill;
            panelTop.Visible = true;
            panelBottom.Visible = false;
            progressBar2.Maximum = 5; //5个环节
            txtLoc.Text = System.IO.Directory.GetCurrentDirectory();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool? b = ConfirmSplitForfrmArchive();
            if (b.HasValue)
            {
                if (b.Value)
                    MyCommon.ShowInfo("已经成功生成上报文件！");
                this.Close();
            }
        }
        /// <summary>
        /// 按案卷上报
        /// </summary>
        /// <returns></returns>
        private bool? ConfirmSplitForfrmArchive()
        {
            if (txtLoc.Text == "")
            {
                MyCommon.ShowWarning("请选择导出文件的存储路径！");
                txtLoc.Focus();
                return null;
            }
            string destFilename = Globals.ProjectNO;
            destFolder = txtLoc.Text + "\\" + destFilename;
            MyCommon.DeleteAndCreateEmptyDirectory(destFolder);
            panelBottom.Visible = true;
            panelTop.Visible = false;
            Application.DoEvents();
            butClose.Enabled = false;
            ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);
            DataSet dsFinalArchive = projectFactory.GetListArchive(Globals.ProjectNO, "");
            if (dsFinalArchive.Tables.Count < 1 || dsFinalArchive.Tables[0].Rows.Count < 1)
            {
                MyCommon.ShowWarning("没有任何案卷可以移交！");
                return false;
            }            
            int count_FinalArchive = dsFinalArchive.Tables[0].Rows.Count;
            progressBar2.Maximum = count_FinalArchive;
            progressBar2.Minimum = 0;
            progressBar2.MarqueeAnimationSpeed = 1000;
            progressBar2.Step = 1;
            lblMsg.Text = "正在输出元数据信息...";
            Application.DoEvents();
            MyCommon.DeleteAndCreateEmptyDirectory(Application.StartupPath + "\\temp");
                //List<string> fontList = GetDWGFontInfo();
                //GetProjectXML(projectFactory, fontList);
            GetProjectXML(projectFactory);
                GetListArchiveXML(projectFactory);
                GetDocumentXML(projectFactory);
            for (int i = 0; i < count_FinalArchive; i++)
            {
                if (!Directory.Exists(Application.StartupPath + "\\temp"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\temp");
                }                
                if (Properties.Settings.Default.SipIncludeDoc)
                {
                    GetListArchiveXMLEx(dsFinalArchive.Tables[0].Rows[i]["案卷ID"].ToString());
                    GetDocumentXMLEx(dsFinalArchive.Tables[0].Rows[i]["案卷ID"].ToString());
                    BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                    IList<MDL.T_FileList> fileList = fileBLL.FindByArchiveID(dsFinalArchive.Tables[0].Rows[i]["案卷ID"].ToString(),Globals.ProjectNO);
                    foreach (MDL.T_FileList obj in fileList)
                    {
                        getDocModel(obj);
                    }
                }
                lblMsg.Text = "正在对数据包进行封装...";
                Application.DoEvents();
                try
                {
                    if (System.IO.File.Exists(Application.StartupPath + "\\temp\\index.dat"))
                    {
                        System.IO.File.Move(Application.StartupPath + "\\temp\\index.dat", destFolder + "\\index.dat");
                        string gcInfo = System.IO.File.ReadAllText(Application.StartupPath + "\\temp\\a#sgwj_gc.xml", Encoding.GetEncoding("gb2312"));
                        string docList = System.IO.File.ReadAllText(destFolder + "\\index.dat");
                        gcInfo = gcInfo.Replace("</项目工程信息>", "<ArchiveFileList>" + docList + "</ArchiveFileList></项目工程信息>");
                        System.IO.File.WriteAllText(destFolder + "\\index.dat", gcInfo, Encoding.GetEncoding("gb2312"));
                    }
                }
                catch { }
                Common.ZipFile zip = new Common.ZipFile(Application.StartupPath + "\\temp", destFolder + "\\" + dsFinalArchive.Tables[0].Rows[i]["案卷ID"].ToString() + ".sip");
                if (!zip.StartZip())
                {
                    MyCommon.DeleteAndCreateEmptyDirectory(Application.StartupPath + "\\temp");
                    MyCommon.ShowWarning("封装数据时发生意外！");
                    return false;
                }
                MyCommon.DeleteAndCreateEmptyDirectory(Application.StartupPath + "\\temp");
                progressBar2.Value = progressBar2.Value + 1;
            }
            butClose.Text = "关闭";
            butClose.Enabled = true;
            return true;
        }
        private bool? Confirm()
        {
            if (txtLoc.Text == "")
            {
                MyCommon.ShowWarning("请选择导出文件的存储路径！");
                txtLoc.Focus();
                return null;
            }
            string destFilename = MyCommon.GetFileShortName(txtLoc.Text);
            destFolder = Path.GetDirectoryName(txtLoc.Text);
            if (!Directory.Exists(destFolder))
            {
                MyCommon.ShowWarning("存储的路径不存在！");
                return null;
            }
            panelBottom.Visible = true;
            panelTop.Visible = false;
            Application.DoEvents();
            butClose.Enabled = false;
            MyCommon.DeleteAndCreateEmptyDirectory(Application.StartupPath + "\\temp");
            ////开始遍历
            if (Properties.Settings.Default.SipIncludeDoc)
            {
                if (!this.CreateXML())
                {
                    return false;
                }
            }
            else
            {
                if (!this.CreateXML2())
                {
                    return false;
                }
            }
            lblMsg.Text = "正在对数据包进行封装...";
            Application.DoEvents();
            Common.ZipFile zip = new Common.ZipFile(Application.StartupPath + "\\temp", txtLoc.Text);
            if (!zip.StartZip())
            {
                MyCommon.DeleteAndCreateEmptyDirectory(Application.StartupPath + "\\temp");
                MyCommon.ShowWarning("封装数据时发生意外！");
                return false;
            }
            tmrStart.Enabled = false;
            progressBar1.Value = progressBar1.Maximum;
            progressBar2.Value = progressBar2.Maximum;
            butClose.Text = "关闭";
            butClose.Enabled = true;
            return true;
        }
        private bool CreateXML()
        {
            try
            {
                ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);
                //List<string> fontList = GetDWGFontInfo();
                //GetProjectXML(projectFactory, fontList);
                GetProjectXML(projectFactory);
                GetListArchiveXML(projectFactory);
                GetDocumentXML(projectFactory);
                lblMsg.Text = "正在输出元数据信息...";
                Application.DoEvents();
                DataSet ds = CBFinalArchive.GetFinal_FileISP("ProjectNO='" + Globals.ProjectNO + "'");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (progressBar2.Value < progressBar2.Maximum)
                    {
                        progressBar2.Value++;
                    }
                    else
                    {
                        progressBar2.Value = 1;
                    }
                    Application.DoEvents();
                }
                return true;
            }
            catch (System.Exception ex)
            {
                MyCommon.DeleteAndCreateEmptyDirectory(Application.StartupPath + "\\temp");
                return false;
            }
        }
        /// <summary>
        /// 廊坊的   原文打包
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="i"></param>
        private void getDocModel(MDL.T_FileList obj)
        {
            string FileID = obj.FileID;// ds.Tables[0].Rows[fileIndex]["FileID"].ToString();            
            string decFilePath = Application.StartupPath + "\\temp\\" + obj.FileID + ".xml";
            string sourFilePath = Application.StartupPath + "\\Reports\\model.xml";
            System.IO.File.Copy(sourFilePath, decFilePath);
            XmlDocument document = new XmlDocument();
            document.Load(decFilePath);
            XmlNode rootFirst = document.SelectSingleNode("元数据/内容信息/数据对象");
            XmlNode childNode = rootFirst.FirstChild;
            if (childNode.Name == "数字对象")
            {
                string tFilePath = obj.filepath.Replace("MPDF\\","");
                string decMfile = Application.StartupPath + "\\temp\\" + tFilePath;
                string sourMfile = Globals.ProjectPath + obj.filepath;
                try
                {
                    System.IO.File.Copy(sourMfile, decMfile);
                    childNode.InnerText = obj.filepath;
                    document.Save(decFilePath);
                }
                catch { }
            }
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByFileID(FileID, Globals.ProjectNO, 1);
            XmlNode root1 = document.SelectSingleNode("元数据/内容信息/数据对象/物理对象");
            foreach(MDL.T_CellAndEFile obj2 in cellList)
            {
                string yswjpath = obj2.filepath.Replace("ODOC\\", "");
                XmlElement elementRecord = document.CreateElement("记录");
                elementRecord.InnerText = "";
                XmlElement element = document.CreateElement("对象名称");
                element.InnerText = yswjpath;// dsAttachment.Tables[0].Rows[ii]["yswjpath"].ToString();
                elementRecord.AppendChild(element);
                string dec = Application.StartupPath + "\\temp\\" + yswjpath;// dsAttachment.Tables[0].Rows[ii]["yswjpath"];
                string sour = Globals.ProjectPath + obj2.filepath;// dsAttachment.Tables[0].Rows[ii]["yswjpath"];
                try
                {
                    System.IO.File.Copy(sour, dec);
                }
                catch { }
                if (progressBar1.Value < progressBar1.Maximum)
                {
                    progressBar1.Value++;
                }
                else
                {
                    progressBar1.Value = 1;
                }
                Application.DoEvents();
            }
            document.Save(decFilePath);
        }
        /// <summary>
        /// 得到字体信息
        /// </summary>
        /// <returns></returns>
        //private List<string> GetDWGFontInfo()
        //{
        //    lblMsg.Text = "正在检查并处理字库信息...";
        //    Application.DoEvents();
        //    DirectoryInfo fontdir = new DirectoryInfo(Globals.DWGFont);
        //    List<string> fontList = new List<string>();
        //    if (fontdir.Exists)
        //    {
        //        DirectoryInfo[] fontDirName = fontdir.GetDirectories();
        //        FileCopy fileCopy = new FileCopy();
        //        foreach (DirectoryInfo dir in fontDirName)
        //        {
        //            if (dir.GetFiles().Length != 0)//空目录不拷
        //            {
        //                string strRela = "\\" + dir.Parent.Name + "\\" + dir.Name;
        //                if (fileCopy.CopyDir(Application.StartupPath + "\\temp" + strRela, dir.FullName))
        //                {
        //                    fontList.Add(strRela);
        //                }
        //            }
        //        }
        //    }
        //    return fontList;
        //}
        /// <summary>
        /// 文件信息 a#sgwj_document.xml
        /// </summary>
        /// <param name="projectFactory"></param>
        private void GetDocumentXML(ERM.CBLL.CreateSip projectFactory)
        {
            DataSet dsFinalFile = projectFactory.GetListFile(Globals.ProjectNO, "");
            dsFinalFile.DataSetName = "文件信息";
            dsFinalFile.Tables[0].TableName = "记录";
        }
        private void GetDocumentXMLEx(string archiveID)
        {
            ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);
            DataSet dsFinalFile = projectFactory.GetListFile(Globals.ProjectNO, archiveID);
            dsFinalFile.DataSetName = "文件信息";
            dsFinalFile.Tables[0].TableName = "记录";
            string _filename=Application.StartupPath + "\\temp\\a#sgwj_document.xml";
            if (System.IO.File.Exists(_filename))
            {
                try
                {
                    System.IO.File.Delete(_filename);
                }
                catch { }
            }
            WriteXmlToFile(dsFinalFile, _filename);
        }
        /// <summary>
        /// 案卷信息 a#sgwj_file.xml
        /// </summary>
        /// <param name="projectFactory"></param>
        private void GetListArchiveXML(ERM.CBLL.CreateSip projectFactory)
        {
            DataSet dsFinalArchive = projectFactory.GetListArchive(Globals.ProjectNO, "");
            dsFinalArchive.DataSetName = "案卷信息";
            dsFinalArchive.Tables[0].TableName = "记录";
            string _filename = Application.StartupPath + "\\temp\\a#sgwj_file.xml";
            _filename = Application.StartupPath + "\\temp\\index.dat";
            System.IO.TextWriter w1 = System.IO.File.CreateText(_filename);
            if (dsFinalArchive != null && dsFinalArchive.Tables.Count > 0 && dsFinalArchive.Tables[0].Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dsFinalArchive.Tables[0].Rows.Count; i1++)
                {
                    w1.WriteLine("<FileList><File>" + dsFinalArchive.Tables[0].Rows[i1][0].ToString() + ".sip</File>");
                    w1.WriteLine("<Title>" + dsFinalArchive.Tables[0].Rows[i1]["案卷题名"].ToString() + "</Title></FileList>");
                }
            }
            w1.Close();
        }
        private void GetListArchiveXMLEx(string archiveID)
        {
            ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);
            DataSet dsFinalArchive = projectFactory.GetListArchive(Globals.ProjectNO, archiveID);
            dsFinalArchive.DataSetName = "案卷信息";
            dsFinalArchive.Tables[0].TableName = "记录";
            string _filename = Application.StartupPath + "\\temp\\a#sgwj_file.xml";
            if (System.IO.File.Exists(_filename))
            {
                try
                {
                    System.IO.File.Delete(_filename);
                }
                catch { }
            }
            WriteXmlToFile(dsFinalArchive, _filename);
        }
        /// <summary>
        /// 廊坊系统,需要字库CAD文件的
        /// </summary>
        /// <param name="projectFactory"></param>
        /// <param name="fontList">字库列表</param>
        private static void GetProjectXML(ERM.CBLL.CreateSip projectFactory, List<string> fontList)
        {
            StreamWriter gc = new StreamWriter(Application.StartupPath + "\\temp\\a#sgwj_gc.xml", false, Encoding.Default);
            gc.WriteLine("<?xml version=\"1.0\" encoding=\"gb2312\" standalone=\"no\"?>");
            gc.WriteLine("<项目工程信息>");
            gc.WriteLine("  <项目信息>");
            foreach (System.Collections.DictionaryEntry objDE in projectFactory.Item)
            {
                if (projectFactory.Item[objDE.Key].GetType() != typeof(System.String[]))
                {
                    gc.WriteLine("    <" + objDE.Key + ">" + objDE.Value + "</" + objDE.Key + ">");
                }
                else
                {
                    gc.WriteLine("    <" + objDE.Key + ">" + ((string[])projectFactory.Item[objDE.Key])[0] + "</" + objDE.Key + ">");
                }
            }
            gc.WriteLine("  </项目信息>");
            gc.WriteLine("  <工程信息>");
            foreach (System.Collections.DictionaryEntry objDE in projectFactory.ProjectDetail)
            {
                if (projectFactory.ProjectDetail[objDE.Key].GetType() != typeof(System.String[]))
                {
                    gc.WriteLine("    <" + objDE.Key + ">" + objDE.Value + "</" + objDE.Key + ">");
                }
                else
                {
                    gc.WriteLine("    <" + objDE.Key + ">" + ((string[])projectFactory.ProjectDetail[objDE.Key])[0] + "</" + objDE.Key + ">");
                }
            }
            gc.WriteLine("  </工程信息>");
            gc.WriteLine("  <字库信息>");
            foreach (string str in fontList)
            {
                gc.WriteLine("    <记录>");
                gc.WriteLine("      <字库目录>" + str + "</字库目录>");
                gc.WriteLine("    </记录>");
            }
            gc.WriteLine("  </字库信息>");
            gc.WriteLine("</项目工程信息>");
            gc.Flush();
            gc.Close();
        }
        private void GotoError(string ex)
        {
            MyCommon.ShowWarning(ex);
            MyCommon.DeleteAndCreateEmptyDirectory(Application.StartupPath + "\\temp");
        }
        /// <summary>
        /// 珠海的不要DWG字库，不要原文
        /// </summary>
        /// <returns></returns>
        private bool CreateXML2()
        {
            try
            {
                ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);
                GetProjectXML(projectFactory);
                GetListArchiveXML(projectFactory);
                GetDocumentXML(projectFactory);
                lblMsg.Text = "正在输出元数据信息...";
                Application.DoEvents();
                DataSet ds = CBFinalArchive.GetFinal_FileISP("ProjectNO='" + Globals.ProjectNO + "'");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    GetZHDocModel(ds, i);
                    if (progressBar2.Value < progressBar2.Maximum)
                    {
                        progressBar2.Value++;
                    }
                    else
                    {
                        progressBar2.Value = 1;
                    }
                    Application.DoEvents();
                }
                return true;
            }
            catch (System.SystemException ex)
            {
                MyCommon.DeleteAndCreateEmptyDirectory(Application.StartupPath + "\\temp");
                return false;
            }
        }
        /// <summary>
        /// 珠海的不要DWG字库及原文
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="i"></param>
        private static void GetZHDocModel(DataSet ds, int i)
        {
            string FileID = ds.Tables[0].Rows[i]["FileID"].ToString();
            string decFilePath = Application.StartupPath + "\\temp\\" + ds.Tables[0].Rows[i]["FileID"].ToString() + ".xml";
            string sourFilePath = Application.StartupPath + "\\Reports\\model.xml";
            System.IO.File.Copy(sourFilePath, decFilePath);
            XmlDocument document = new XmlDocument();
            document.Load(decFilePath);
            XmlNode rootFirst = document.SelectSingleNode("元数据/内容信息/数据对象");
            XmlNode childNode = rootFirst.FirstChild;
            if (childNode.Name == "数字对象")
            {
                string pathFinalFile = Globals.MPDFPath + "\\" + ds.Tables[0].Rows[i]["filepath"].ToString();
                string _strfinalfile = null;
                if (System.IO.File.Exists(pathFinalFile))
                {
                    string decMfile = Application.StartupPath + "\\temp\\" + ds.Tables[0].Rows[i]["filepath"].ToString();
                    string sourMfile = Globals.MPDFPath + "\\" + ds.Tables[0].Rows[i]["filepath"].ToString();
                    System.IO.File.Copy(sourMfile, decMfile);
                }
                childNode.InnerText = ds.Tables[0].Rows[i]["filepath"].ToString();
                document.Save(decFilePath);
            }
            document.Save(decFilePath);
        }
        /// <summary>
        /// 珠海系统不需要字库的
        /// </summary>
        /// <param name="projectFactory"></param>
        private static void GetProjectXML(ERM.CBLL.CreateSip projectFactory)
        {
            StreamWriter gc = new StreamWriter(Application.StartupPath + "\\temp\\a#sgwj_gc.xml", false, Encoding.Default);
            gc.WriteLine("<?xml version=\"1.0\" encoding=\"gb2312\" standalone=\"no\"?>");
            gc.WriteLine("<项目工程信息>");
            gc.WriteLine("  <项目信息>");
            foreach (System.Collections.DictionaryEntry objDE in projectFactory.Item)
            {
                if (projectFactory.Item[objDE.Key].GetType() != typeof(System.String[]))
                {
                    gc.WriteLine("    <" + objDE.Key + ">" + objDE.Value + "</" + objDE.Key + ">");
                }
                else
                {
                    gc.WriteLine("    <" + objDE.Key + ">" + ((string[])projectFactory.Item[objDE.Key])[0] + "</" + objDE.Key + ">");
                }
            }
            gc.WriteLine("  </项目信息>");
            gc.WriteLine("  <工程信息>");
            foreach (System.Collections.DictionaryEntry objDE in projectFactory.ProjectDetail)
            {
                if (projectFactory.ProjectDetail[objDE.Key].GetType() != typeof(System.String[]))
                {
                    gc.WriteLine("    <" + objDE.Key + ">" + objDE.Value + "</" + objDE.Key + ">");
                }
                else
                {
                    gc.WriteLine("    <" + objDE.Key + ">" + ((string[])projectFactory.ProjectDetail[objDE.Key])[0] + "</" + objDE.Key + ">");
                }
            }
            gc.WriteLine("  </工程信息>");
            gc.WriteLine("</项目工程信息>");
            gc.Flush();
            gc.Close();
        }
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="sourceFolder">压缩目录</param>
        /// <param name="DestFile">压缩成文件</param>
        /// <returns>成功与否</returns>
        private bool StartZip(string sourceFolder, string DestFile)
        {
            try
            {
                string[] filenames = Directory.GetFiles(sourceFolder);
                ZipOutputStream s = new ZipOutputStream(System.IO.File.Create(DestFile));
                s.SetLevel(5);
                FileStream fs;
                foreach (string file in filenames)
                {
                    fs = System.IO.File.OpenRead(file);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    ZipEntry entry = new ZipEntry(file.Replace(sourceFolder, ""));
                    s.PutNextEntry(entry);
                    s.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                s.Finish();
                s.Close();
                s.Dispose();
                return true;
            }
            catch (Exception e)
            {
                MyCommon.ShowInfo("文件生成失败：" + e.Message);
                return false;
            }
        }
        private void WriteXmlToFile(DataSet thisDataSet, string _filename)
        {
            if (thisDataSet == null)
            {
                return;
            }
            string filename = _filename;
            StreamWriter gc = new StreamWriter(_filename, true, Encoding.Default);
            gc.WriteLine("<?xml version=\"1.0\" encoding=\"gb2312\" standalone=\"no\"?>");
            gc.Flush();
            gc.Close();
            System.IO.FileStream stream = new System.IO.FileStream(filename, System.IO.FileMode.Append);
            System.Xml.XmlTextWriter xmlWriter = new System.Xml.XmlTextWriter(stream, System.Text.Encoding.Default);
            thisDataSet.WriteXml(xmlWriter);
            xmlWriter.Close();
        }
        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExplorer_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "请选择一个存放工程编号:" + Globals.ProjectNO + ",上报资料的存放地址!";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLoc.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        /// <summary>
        /// 时间控件控制进度条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrStart_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                progressBar1.Value = 0;
            }
        }
        private void btnNetSetup_Click(object sender, EventArgs e)
        {
        }
    }
}
