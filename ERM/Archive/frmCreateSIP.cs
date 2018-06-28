using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using ERM.BLL;
using ERM.Common;
using System.Threading;
using TX.Framework.WindowUI.Forms;
using ERM.UI.Common.XmlMapping;
using System.Collections;
namespace ERM.UI
{
    public partial class frmCreateSIP : ERM.UI.Controls.Skin_DevEX
    {
        ERM.CBLL.FinalArchive CBFinalArchive = new ERM.CBLL.FinalArchive();
        ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);

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
            this.lbl_ProjectName.Text = Globals.Projectname.ToString();
            panelTop.Dock = DockStyle.Fill;
            panelBottom.Dock = DockStyle.Fill;
            panelTop.Visible = true;
            panelBottom.Visible = false;
            progressBar2.Maximum = 5; //5������
            txtLoc.Text = System.IO.Directory.GetCurrentDirectory() + "\\" + Globals.Projectname;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            #region �첽����ѹ��
            string dest_temp = Path.GetDirectoryName(txtLoc.Text);
            if (!Directory.Exists(dest_temp))
            {
                TXMessageBoxExtensions.Info("�洢��·�������ڣ�");
                return;
            }
            #endregion

            #region ����ѹ��
            bool? b = ConfirmSplitForfrmArchive();
            if (System.IO.Directory.Exists(tempFullName))
                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName, false);
            if (b.HasValue)
            {
                this.Close();
            }
            #endregion
        }
        string tempFullName = "";
        /// <summary>
        /// �������ϱ�
        /// </summary>
        /// <returns></returns>
        private bool? ConfirmSplitForfrmArchive()
        {
            if (txtLoc.Text == "")
            {
                TXMessageBoxExtensions.Info("��ѡ�񵼳��ļ��Ĵ洢·����");
                txtLoc.Focus();
                return null;
            }
            string destFilename = Globals.Projectname;
            destFolder = txtLoc.Text;

            string dest_temp = Path.GetDirectoryName(txtLoc.Text);
            if (!Directory.Exists(dest_temp))
            {
                TXMessageBoxExtensions.Info("�洢��·�������ڣ�");
                return null;
            }

            double projectSize = Convert.ToDouble(DirectoryInfoCommon.GetDirectorySpace(Application.StartupPath + "\\Project\\" + Globals.ProjectNO) / Convert.ToDouble(1024 * 1024 * 1024));
            ReadWriteAppConfig config = new ReadWriteAppConfig();
            if (config.Read("Upload_ProjectSize") == "")
                config.Write("Upload_ProjectSize", "4");
            string upload_size = config.Read("Upload_ProjectSize");

            if (projectSize > Convert.ToDouble(upload_size))
            {
                DialogResult dresult = TXMessageBoxExtensions.Question("�ϱ����̴���" + upload_size + "G����ǰ���̴�СΪ��" + System.Math.Round(projectSize, 2) + "G \r\n\n ����ܰ��ʾ������̫�������ƽ��ļ���Ҫ�Ƚϳ���ʱ�䡿  \r\n\n �Ƿ���������ƽ���");
                if (dresult != DialogResult.OK)
                    return null;
            }
            else if (MyCommon.CheckDisk(destFolder) < projectSize)
            {
                //Ӳ�̿ռ䲻��
                TXMessageBoxExtensions.Info("�ϱ����̴�СΪ��" + System.Math.Round(projectSize, 2) + "G ����Ŀ¼Ӳ�̿ռ䲻��,�޷����ɣ� \r\n ����ܰ��ʾ����ѡ��ȽϿ��е��̷���");
                txtLoc.Focus();
                return null;
            }

            tempFullName = dest_temp + "\\" + Guid.NewGuid().ToString();
            if (System.IO.Directory.Exists(tempFullName))
                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName, false);
            MyCommon.DeleteAndCreateEmptyDirectory(tempFullName);

            MyCommon.DeleteAndCreateEmptyDirectory(destFolder, false);
            MyCommon.DeleteAndCreateEmptyDirectory(destFolder, true);

            panelBottom.Visible = true;
            panelTop.Visible = false;
            Application.DoEvents();
            butClose.Enabled = false;
            ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);
            //DataSet dsFinalArchive = projectFactory.GetListArchive(Globals.ProjectNO, "");
            DataSet dsFinalArchive = new Archive().pb_setXmlInfo();
            if (dsFinalArchive.Tables.Count < 1 || dsFinalArchive.Tables[0].Rows.Count < 1)
            {
                TXMessageBoxExtensions.Info("û���κΰ�������ƽ���");
                return false;
            }
            int count_FinalArchive = dsFinalArchive.Tables[0].Rows.Count;
            bool checkfile_flag = true;
            for (int i = 0; i < count_FinalArchive; i++)
            {
                BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                IList<MDL.T_FileList> fileList = fileBLL.FindByArchiveID2(dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString(), Globals.ProjectNO);
                foreach (MDL.T_FileList obj in fileList)
                {
                    if (obj.selected == 1 || obj.filepath == null || obj.filepath == "")
                    {
                        ConvertAllEFileToPDF(obj.FileID);
                    }
                    else
                    {
                        string tFilePath = obj.filepath.Replace("MPDF\\", "");
                        string sourMfile = Globals.ProjectPath + obj.filepath;
                        if (!System.IO.File.Exists(sourMfile))
                        {
                            ConvertAllEFileToPDF(obj.FileID);
                        }
                    }
                    IList<MDL.T_CellAndEFile> cellList = (new ERM.BLL.T_CellAndEFile_BLL()).FindByGdFileID(obj.FileID, Globals.ProjectNO);
                    ERM.MDL.T_FileList file_model = (new ERM.BLL.T_FileList_BLL()).Find(obj.FileID, Globals.ProjectNO);
                    if ((file_model.filepath == null || file_model.filepath == "") &&
                         cellList.Count > 0)
                    {
                        TXMessageBoxExtensions.Info("��ʾ���ļ���" + obj.gdwj + "�������ļ���Ϣ�����޷��ƽ��������");
                        checkfile_flag = false;
                        break;
                    }
                }
                if (!checkfile_flag)
                    break;
            }
            if (!checkfile_flag)
                return false;

            progressBar2.Maximum = count_FinalArchive;
            progressBar2.Minimum = 0;
            progressBar2.MarqueeAnimationSpeed = 1000;
            progressBar2.Step = 1;
            lblMsg.Text = "�������Ԫ������Ϣ...";
            Application.DoEvents();

            GetListArchiveXML(projectFactory, tempFullName);
            try
            {
                for (int i = 0; i < count_FinalArchive; i++)
                {
                    if (!Directory.Exists(tempFullName))
                    {
                        MyCommon.DeleteAndCreateEmptyDirectory(tempFullName, true);
                    }
                    //20120530 ����XML�ļ�
                    GetProjectXML(projectFactory, tempFullName);

                    if (Convert.ToBoolean(Properties.Settings.Default.SipIncludeDoc))
                    {
                        //20120530 ����XML�ļ�
                        GetListArchiveXMLEx(dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString(), tempFullName);
                        GetDocumentXMLEx(dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString(), tempFullName);

                        BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                        IList<MDL.T_FileList> fileList = fileBLL.FindByArchiveID2(dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString(), Globals.ProjectNO);
                        foreach (MDL.T_FileList obj in fileList)
                        {
                            //20120530 ����XML�ļ�
                            //getDocModel(obj);                            
                            getDocModel_NEW(obj, tempFullName);
                        }
                    }
                    lblMsg.Text = "���ڶ����ݰ����з�װ...";
                    Application.DoEvents();

                    if (System.IO.File.Exists(tempFullName + "\\index.dat"))//Application.StartupPath + "\\temp\\index.dat"
                    {
                        System.IO.File.Move(tempFullName + "\\index.dat", destFolder + "\\index.dat");

                        string gcInfo = System.IO.File.ReadAllText(tempFullName + "\\a#sgwj_gc.xml", Encoding.GetEncoding("gb2312"));
                        string docList = System.IO.File.ReadAllText(destFolder + "\\index.dat");
                        gcInfo = gcInfo.Replace("</��Ŀ������Ϣ>", "<ArchiveFileList>" + docList + "</ArchiveFileList></��Ŀ������Ϣ>");
                        System.IO.File.WriteAllText(destFolder + "\\index.dat", gcInfo, Encoding.GetEncoding("gb2312"));
                    }

                    SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
                    SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
                    {
                        tmp.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                        tmp.CompressDirectory(tempFullName, destFolder + "\\" + dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString() + ".sip");
                    }
                    MyCommon.DeleteAndCreateEmptyDirectory(tempFullName, false);
                    progressBar2.Value = progressBar2.Value + 1;
                }
            }
            catch (Exception ex)
            {
                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName, false);
                TXMessageBoxExtensions.Info("��װ����ʱ����������󣡴���002");
                MyCommon.WriteLog("�����ƽ��ļ�ʱʧ�ܣ�������Ϣ��" + ex.Message);
                return false;
            }
            butClose.Text = "�ر�";
            butClose.Enabled = true;
            TXMessageBoxExtensions.Info("�Ѿ��ɹ������ϱ��ļ���");
            return true;
        }

        /// <summary>
        /// ������Ϣ a#sgwj_file.xml
        /// </summary>
        /// <param name="projectFactory"></param>
        private void GetListArchiveXML(ERM.CBLL.CreateSip projectFactory, string filepath_flg)
        {
            Archive archive = new Archive();
            //DataSet dsFinalArchive = projectFactory.GetListArchive(Globals.ProjectNO, "");
            DataSet dsFinalArchive = archive.pb_setXmlInfo();
            dsFinalArchive.DataSetName = "������Ϣ";
            dsFinalArchive.Tables[0].TableName = "��¼";
            string _filename = filepath_flg + "\\index.dat";
            StreamWriter w1 = new StreamWriter(_filename, false, Encoding.Default);
            if (dsFinalArchive != null && dsFinalArchive.Tables.Count > 0 && dsFinalArchive.Tables[0].Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dsFinalArchive.Tables[0].Rows.Count; i1++)
                {
                    w1.WriteLine("<FileList><File>" + dsFinalArchive.Tables[0].Rows[i1][0].ToString() + ".sip</File>");
                    w1.WriteLine("<Title>" + dsFinalArchive.Tables[0].Rows[i1]["��������"].ToString() + "</Title></FileList>");
                }
            }
            w1.Close();
        }
        /// <summary>
        /// ϵͳ����Ҫ�ֿ��
        /// </summary>
        /// <param name="projectFactory"></param>
        private static void GetProjectXML(ERM.CBLL.CreateSip projectFactory, string filepath_flg)
        {
            StreamWriter gc = new StreamWriter(filepath_flg + "\\a#sgwj_gc.xml", false, Encoding.Default);
            gc.WriteLine("<?xml version=\"1.0\" encoding=\"gb2312\" standalone=\"no\"?>");
            gc.WriteLine("<��Ŀ������Ϣ>");
            gc.WriteLine("  <��Ŀ��Ϣ>");
            DataSet ds = new Item().pb_setXmlInfo(new T_Projects_BLL().Find(Globals.ProjectNO).ItemID);
            Hashtable _Item = new Hashtable();
            if (ds.Tables.Count == 0 || ds.Tables == null)
            {
                return;
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    _Item.Add(ds.Tables[0].Columns[j].ColumnName, ds.Tables[0].Rows[i][j].ToString());
                }
            }

            foreach (System.Collections.DictionaryEntry objDE in _Item)
            {
                if (_Item[objDE.Key] != null)
                {
                    if (_Item[objDE.Key].GetType() != typeof(System.String[]))
                    {
                        gc.WriteLine("    <" + objDE.Key + ">" + objDE.Value + "</" + objDE.Key + ">");
                    }
                    else
                    {
                        gc.WriteLine("    <" + objDE.Key + ">" + ((string[])_Item[objDE.Key])[0] + "</" + objDE.Key + ">");
                    }
                }
                else
                {
                    gc.WriteLine("    <" + objDE.Key + "></" + objDE.Key + ">");
                }
            }
            gc.WriteLine("  </��Ŀ��Ϣ>");
            gc.WriteLine("  <������Ϣ>");

            Hashtable _detail = new Hashtable();
            string projectType = new T_Projects_BLL().Find(Globals.ProjectNO).ProjectCategory;
            DataSet ds1 = new ERM.UI.Common.XmlMapping.Project().pb_setXmlInfo(projectType);
            if (ds1.Tables.Count > 0)
            {
                for (int n = 0; n < ds1.Tables[0].Rows.Count; n++)
                {
                    for (int j = 0; j < ds1.Tables[0].Columns.Count; j++)
                    {
                        _detail.Add(ds1.Tables[0].Columns[j].ColumnName, ds1.Tables[0].Rows[n][j].ToString());
                    }
                }
                projectFactory.UnitSetting(_detail);
                foreach (System.Collections.DictionaryEntry objDE in _detail)
                {
                    if (_detail[objDE.Key] != null)
                    {
                        if (_detail[objDE.Key].GetType() != typeof(System.String[]))
                        {
                            gc.WriteLine("    <" + objDE.Key + ">" + objDE.Value + "</" + objDE.Key + ">");
                        }
                        else
                        {
                            gc.WriteLine("    <" + objDE.Key + ">" + ((string[])_detail[objDE.Key])[0] + "</" + objDE.Key + ">");
                        }
                    }
                    else
                    {
                        gc.WriteLine("    <" + objDE.Key + "></" + objDE.Key + ">");
                    }
                }

                if (projectType == "Traffic")
                {
                    DataSet _trafficDetail = new Traffic().PB_setXmlInfo(ds1.Tables[0].Rows[0]["ID"].ToString());
                    if (_trafficDetail.Tables.Count > 0)
                    {
                        gc.WriteLine("<��ͨ�ܵ���ϸ>");
                        for (int n = 0; n < _trafficDetail.Tables[0].Rows.Count; n++)
                        {
                            gc.WriteLine("<" + ReplaceColumnName(_trafficDetail.Tables[0].Rows[n]["Types"].ToString()) + ">");
                            for (int j = 0; j < _trafficDetail.Tables[0].Columns.Count; j++)
                            {
                                if (_trafficDetail.Tables[0].Columns[j].ColumnName != "Types")
                                {
                                    gc.WriteLine("    <" + _trafficDetail.Tables[0].Columns[j].ColumnName + ">" + _trafficDetail.Tables[0].Rows[n][j].ToString() + "</" + _trafficDetail.Tables[0].Columns[j].ColumnName + ">");
                                }
                            }
                            gc.WriteLine("</" + ReplaceColumnName(_trafficDetail.Tables[0].Rows[n]["types"].ToString()) + ">");
                        }
                        gc.WriteLine("</��ͨ�ܵ���ϸ>");
                    }
                }

                gc.WriteLine("  </������Ϣ>");
                gc.WriteLine("</��Ŀ������Ϣ>");
                gc.Flush();
                gc.Close();
            }
        }

        private static string ReplaceColumnName(string oldName)
        {
            if (oldName.Contains("ysg"))
            {
                return oldName.Replace("ysg", "��ˮ��");
            }
            if (oldName.Contains("zh"))
            {
                return oldName.Replace("zh", "�ۺϹܹ�");
            }
            if (oldName.Contains("ddsd"))
            {
                return oldName.Replace("ddsd", "�������");
            }
            if (oldName.Contains("dlg"))
            {
                return oldName.Replace("dlg", "���¹�");
            }
            if (oldName.Contains("wsg"))
            {
                return oldName.Replace("wsg", "��ˮ��");
            }
            if (oldName.Contains("yl"))
            {
                return oldName.Replace("yl", "Ԥ����");
            }
            if (oldName.Contains("gsg"))
            {
                return oldName.Replace("gsg", "��ˮ��");
            }
            return "";
        }

        private void GetListArchiveXMLEx(string archiveID, string filepath_flg)
        {
            ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);
            //DataSet dsFinalArchive = projectFactory.GetListArchive(Globals.ProjectNO, archiveID);
            DataSet dsFinalArchive = new Archive().pb_setXmlInfo(Globals.ProjectNO, archiveID);
            dsFinalArchive.DataSetName = "������Ϣ";
            dsFinalArchive.Tables[0].TableName = "��¼";
            string _filename = filepath_flg + "\\a#sgwj_file.xml";
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
        private void GetDocumentXMLEx(string archiveID, string filepath_flg)
        {
            ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);
            //DataSet dsFinalFile = projectFactory.GetListFile(Globals.ProjectNO, archiveID);
            DataSet dsFinalFile = new ERM.UI.Common.XmlMapping.File().pb_setXmlInfo(archiveID, Globals.ProjectNO, "pb_queryByFileNo");
            dsFinalFile.DataSetName = "�ļ���Ϣ";
            dsFinalFile.Tables[0].TableName = "��¼";
            string _filename = filepath_flg + "\\a#sgwj_document.xml";
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
        /// �ȷ���   ԭ�Ĵ��
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="i"></param>
        private void getDocModel_NEW(MDL.T_FileList obj, string filepath_flg)
        {
            string FileID = obj.FileID;
            if (obj.filepath != null)
            {
                string tFilePath = obj.filepath.Replace("MPDF\\", "");
                string decMfile = filepath_flg + "\\" + tFilePath;
                string sourMfile = Globals.ProjectPath + obj.filepath;
                try
                {
                    if (System.IO.File.Exists(sourMfile))
                        System.IO.File.Copy(sourMfile, decMfile, true);
                }
                catch (Exception ex)
                {
                    MyCommon.WriteLog("�����ƽ��ļ�ʱ�������ļ�ʧ�ܣ�������Ϣ��" + ex.Message);
                }
            }
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByFileID(FileID, Globals.ProjectNO, 1);

            foreach (MDL.T_CellAndEFile obj2 in cellList)
            {
                string yswjpath = obj2.filepath.Replace("ODOC\\", "");

                string dec = filepath_flg + "\\" + yswjpath;
                string sour = Globals.ProjectPath + obj2.filepath;
                try
                {
                    if (System.IO.File.Exists(sour))
                        System.IO.File.Copy(sour, dec, true);
                }
                catch (Exception ex)
                {
                    MyCommon.WriteLog("�����ƽ��ļ�ʱ������ԭ�ļ�ʧ�ܣ�������Ϣ��" + ex.Message);
                }
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
        }

        #region

        /// <summary>
        /// ��������PDF
        /// </summary>
        /// <param name="FileID">�ڵ�ID</param>
        private void ConvertAllEFileToPDF(string FileID)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            MDL.T_FileList fileMDL = fileBLL.Find(FileID, Globals.ProjectNO);
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            IList<MDL.T_CellAndEFile> cellList =
                cellBLL.FindByGdFileID(FileID, Globals.ProjectNO);

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
                        }
                        catch (Exception e)
                        {
                            cellMDL.fileTreePath = "";
                            MyCommon.WriteLog("PDFת��ʧ�ܣ�������Ϣ��" + e.Message);
                        }
                        pdfPath = cellMDL.fileTreePath;
                    }
                }
                else
                {
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
                        MyCommon.WriteLog("�ϲ�PDFʧ�ܣ�������Ϣ��" + ex.Message);
                    }
                }
                else
                {
                    fileMDL.filepath = "";
                }

                //1 ��������  2���� 3��Ƭ����
                int EFileType_flg = 1;
                TreeFactory treeFactory = new TreeFactory();
                treeFactory.GetParentNodeType(FileID, ref EFileType_flg);
                if (EFileType_flg == 1)
                {
                    fileMDL.sl = iPageCount;
                }
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
                    fileMDL.zpz = (iPageCount).ToString();
                    fileMDL.dpz = dpz.ToString();
                }
                fileMDL.selected = 0;
                fileBLL.Update(fileMDL);
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
            thisDataSet.WriteXml(xmlWriter);//XmlWriteMode.WriteSchema
            xmlWriter.Close();
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExplorer_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "��ѡ��һ����Ź��̱��:" + Globals.ProjectNO + ",�ϱ����ϵĴ�ŵ�ַ!";
            saveFileDialog1.FileName = Globals.Projectname;
            saveFileDialog1.Filter = "*.* | *.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLoc.Text = saveFileDialog1.FileName;
            }
        }
        /// <summary>
        /// ʱ��ؼ����ƽ�����
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

        #endregion

        #region �첽ѹ��
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string Argument = e.Argument as string;
            e.Result = StartRemove(Argument, bgWorker);
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool b_result = (bool)e.Result;
            if (b_result)
            {
                TXMessageBoxExtensions.Info("�Ѿ��ɹ������ϱ��ļ���");
            }
            this.Close();
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblMsg.Text = "����ѹ��������Ϣ...";
            progressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100)
            {
                Thread.Sleep(100);

                progressBar2.Value = progressBar2.Value + 1;
                if (progressBar2.Value == 99)
                {
                    progressBar2.Value = progressBar2.Value - 1;
                }
            }
        }

        int Index_temp = 0;
        private bool StartRemove(string saveLoc, System.ComponentModel.BackgroundWorker _bgWorker)
        {
            string destFilename = Globals.Projectname;
            destFolder = saveLoc;

            string dest_temp = Path.GetDirectoryName(saveLoc);

            tempFullName = dest_temp + "\\" + Guid.NewGuid().ToString();
            if (System.IO.Directory.Exists(tempFullName))
                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName, false);
            MyCommon.DeleteAndCreateEmptyDirectory(tempFullName);

            MyCommon.DeleteAndCreateEmptyDirectory(destFolder, false);
            MyCommon.DeleteAndCreateEmptyDirectory(destFolder, true);

            if (Index_temp > 100)
            {
                Index_temp = 0;
            }
            _bgWorker.ReportProgress(Index_temp++);


            ERM.CBLL.CreateSip projectFactory = new ERM.CBLL.CreateSip(Globals.ProjectNO);
            // DataSet dsFinalArchive = projectFactory.GetListArchive(Globals.ProjectNO, "");
            DataSet dsFinalArchive = new Archive().pb_setXmlInfo();
            if (dsFinalArchive.Tables.Count < 1 || dsFinalArchive.Tables[0].Rows.Count < 1)
            {
                TXMessageBoxExtensions.Info("û���κΰ�������ƽ���");
                return false;
            }
            int count_FinalArchive = dsFinalArchive.Tables[0].Rows.Count;

            //DataSet dsFinalArchive_temp = projectFactory.GetListArchive(Globals.ProjectNO, "");
            DataSet dsFinalArchive_temp = dsFinalArchive;
            dsFinalArchive_temp.DataSetName = "������Ϣ";
            dsFinalArchive_temp.Tables[0].TableName = "��¼";

            string _filename = tempFullName + "\\index.dat";
            StreamWriter w1 = new StreamWriter(_filename, false, Encoding.Default);
            if (dsFinalArchive_temp != null && dsFinalArchive_temp.Tables.Count > 0 && dsFinalArchive_temp.Tables[0].Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dsFinalArchive_temp.Tables[0].Rows.Count; i1++)
                {
                    w1.WriteLine("<FileList><File>" + dsFinalArchive_temp.Tables[0].Rows[i1][0].ToString() + ".sip</File>");
                    w1.WriteLine("<Title>" + dsFinalArchive_temp.Tables[0].Rows[i1]["��������"].ToString() + "</Title></FileList>");
                }
            }
            w1.Flush();
            w1.Close();

            if (Index_temp > 100)
            {
                Index_temp = 0;
            }
            _bgWorker.ReportProgress(Index_temp++);

            try
            {
                for (int i = 0; i < count_FinalArchive; i++)
                {
                    if (Index_temp > 100)
                    {
                        Index_temp = 0;
                    }
                    _bgWorker.ReportProgress(Index_temp++);

                    if (!Directory.Exists(tempFullName))
                    {
                        MyCommon.DeleteAndCreateEmptyDirectory(tempFullName, true);
                    }

                    StreamWriter gc = new StreamWriter(tempFullName + "\\a#sgwj_gc.xml", false, Encoding.Default);
                    gc.WriteLine("<?xml version=\"1.0\" encoding=\"gb2312\" standalone=\"no\"?>");
                    gc.WriteLine("<��Ŀ������Ϣ>");
                    gc.WriteLine("  <��Ŀ��Ϣ>");
                    DataSet ds = new Item().pb_setXmlInfo(new T_Projects_BLL().Find(Globals.ProjectNO).ItemID);
                    Hashtable _Item = new Hashtable();
                    if (ds.Tables.Count > 0)
                    {
                        for (int n = 0; n < ds.Tables[0].Rows.Count; n++)
                        {
                            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                            {
                                _Item.Add(ds.Tables[0].Columns[j].ColumnName, ds.Tables[0].Rows[n][j].ToString());
                            }
                        }

                        foreach (System.Collections.DictionaryEntry objDE in _Item)
                        {
                            if (_Item[objDE.Key] != null)
                            {
                                if (_Item[objDE.Key].GetType() != typeof(System.String[]))
                                {
                                    gc.WriteLine("    <" + objDE.Key + ">" + objDE.Value + "</" + objDE.Key + ">");
                                }
                                else
                                {
                                    gc.WriteLine("    <" + objDE.Key + ">" + ((string[])_Item[objDE.Key])[0] + "</" + objDE.Key + ">");
                                }
                            }
                            else
                            {
                                gc.WriteLine("    <" + objDE.Key + "></" + objDE.Key + ">");
                            }
                        }
                    }
                    gc.WriteLine("  </��Ŀ��Ϣ>");
                    gc.WriteLine("  <������Ϣ>");
                    Hashtable _detail = new Hashtable();
                    DataSet ds1 = new ERM.UI.Common.XmlMapping.Project().pb_setXmlInfo(new T_Projects_BLL().Find(Globals.ProjectNO).ProjectCategory);
                    if (ds1.Tables.Count > 0)
                    {
                        for (int n = 0; n < ds1.Tables[0].Rows.Count; n++)
                        {
                            for (int j = 0; j < ds1.Tables[0].Columns.Count; j++)
                            {
                                _detail.Add(ds1.Tables[0].Columns[j].ColumnName, ds1.Tables[0].Rows[n][j].ToString());
                            }
                        }

                        foreach (System.Collections.DictionaryEntry objDE in _detail)
                        {
                            if (_detail[objDE.Key] != null)
                            {
                                if (_detail[objDE.Key].GetType() != typeof(System.String[]))
                                {
                                    gc.WriteLine("    <" + objDE.Key + ">" + objDE.Value + "</" + objDE.Key + ">");
                                }
                                else
                                {
                                    gc.WriteLine("    <" + objDE.Key + ">" + ((string[])_detail[objDE.Key])[0] + "</" + objDE.Key + ">");
                                }
                            }
                            else
                            {
                                gc.WriteLine("    <" + objDE.Key + "></" + objDE.Key + ">");
                            }
                        }
                        gc.WriteLine("  </������Ϣ>");
                        gc.WriteLine("</��Ŀ������Ϣ>");
                        gc.Flush();
                        gc.Close();
                    }

                    if (Convert.ToBoolean(Properties.Settings.Default.SipIncludeDoc))
                    {
                        #region ==================================
                        //20120530 ����XML�ļ�

                        //DataSet dsFinalArchive_temp1 = projectFactory.GetListArchive(Globals.ProjectNO, dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString());
                        DataSet dsFinalArchive_temp1 = new Archive().pb_setXmlInfo(Globals.ProjectNO, dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString());
                        dsFinalArchive_temp1.DataSetName = "������Ϣ";
                        dsFinalArchive_temp1.Tables[0].TableName = "��¼";

                        _filename = tempFullName + "\\a#sgwj_file.xml";
                        if (System.IO.File.Exists(_filename))
                        {
                            try
                            {
                                System.IO.File.Delete(_filename);
                            }
                            catch { }
                        }

                        gc = new StreamWriter(_filename, true, Encoding.Default);
                        gc.WriteLine("<?xml version=\"1.0\" encoding=\"gb2312\" standalone=\"no\"?>");
                        gc.Flush();
                        gc.Close();
                        System.IO.FileStream stream_archive = new System.IO.FileStream(_filename, System.IO.FileMode.Append);
                        System.Xml.XmlTextWriter xmlWriter_archive = new System.Xml.XmlTextWriter(stream_archive, System.Text.Encoding.Default);
                        dsFinalArchive_temp1.WriteXml(xmlWriter_archive);
                        xmlWriter_archive.Close();

                        #endregion

                        #region ===========================

                        //DataSet dsFinalFile = projectFactory.GetListFile(Globals.ProjectNO,
                        //  dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString());
                        DataSet dsFinalFile = new ERM.UI.Common.XmlMapping.File().pb_setXmlInfo("pb_queryByFileNo", dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString(), Globals.ProjectNO);

                        dsFinalFile.DataSetName = "�ļ���Ϣ";
                        dsFinalFile.Tables[0].TableName = "��¼";

                        _filename = tempFullName + "\\a#sgwj_document.xml";
                        if (System.IO.File.Exists(_filename))
                        {
                            try
                            {
                                System.IO.File.Delete(_filename);
                            }
                            catch { }
                        }

                        gc = new StreamWriter(_filename, true, Encoding.Default);
                        gc.WriteLine("<?xml version=\"1.0\" encoding=\"gb2312\" standalone=\"no\"?>");
                        gc.Flush();
                        gc.Close();
                        System.IO.FileStream stream_file = new System.IO.FileStream(_filename, System.IO.FileMode.Append);
                        System.Xml.XmlTextWriter xmlWriter_file = new System.Xml.XmlTextWriter(stream_file, System.Text.Encoding.Default);
                        dsFinalFile.WriteXml(xmlWriter_file);
                        xmlWriter_file.Close();

                        #endregion

                        BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                        //IList<MDL.T_FileList> fileList = fileBLL.FindByArchiveID2(dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString(), Globals.ProjectNO);
                        DataSet fileList = new ERM.UI.Common.XmlMapping.File().pb_setXmlInfo("pb_FindByArchiveID2", dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString(), Globals.ProjectNO);
                        if (fileList.Tables.Count > 0)
                        {
                            for (int j = 0; j < fileList.Tables[0].Rows.Count; j++)
                            {
                                DataRow obj = fileList.Tables[0].Rows[j];
                                if (Index_temp > 100)
                                {
                                    Index_temp = 0;
                                }
                                _bgWorker.ReportProgress(Index_temp++);

                                string FileID = obj["FileID"].ToString();
                                if (obj["filepath"] != null)
                                {
                                    string tFilePath = obj["filepath"].ToString().Replace("MPDF\\", "");
                                    string decMfile = tempFullName + "\\" + tFilePath;
                                    string sourMfile = Globals.ProjectPath + obj["filepath"];
                                    try
                                    {
                                        if (System.IO.File.Exists(sourMfile))
                                            System.IO.File.Copy(sourMfile, decMfile, true);
                                    }
                                    catch (Exception ex)
                                    {
                                        MyCommon.WriteLog("�����ƽ��ļ�ʱ�������ļ�ʧ�ܣ�������Ϣ��" + ex.Message);
                                    }
                                }
                                BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
                                IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByFileID(FileID, Globals.ProjectNO, 1);

                                foreach (MDL.T_CellAndEFile obj2 in cellList)
                                {
                                    string yswjpath = obj2.filepath.Replace("ODOC\\", "");

                                    string dec = tempFullName + "\\" + yswjpath;
                                    string sour = Globals.ProjectPath + obj2.filepath;
                                    try
                                    {
                                        if (System.IO.File.Exists(sour))
                                            System.IO.File.Copy(sour, dec, true);
                                    }
                                    catch (Exception ex)
                                    {
                                        MyCommon.WriteLog("�����ƽ��ļ�ʱ������ԭ�ļ�ʧ�ܣ�������Ϣ��" + ex.Message);
                                    }
                                }
                            }
                        }
                    }
                    if (System.IO.File.Exists(tempFullName + "\\index.dat"))
                    {
                        System.IO.File.Move(tempFullName + "\\index.dat", destFolder + "\\index.dat");

                        string gcInfo = System.IO.File.ReadAllText(tempFullName + "\\a#sgwj_gc.xml", Encoding.GetEncoding("gb2312"));
                        string docList = System.IO.File.ReadAllText(destFolder + "\\index.dat");
                        gcInfo = gcInfo.Replace("</��Ŀ������Ϣ>", "<ArchiveFileList>" + docList + "</ArchiveFileList></��Ŀ������Ϣ>");
                        System.IO.File.WriteAllText(destFolder + "\\index.dat", gcInfo, Encoding.GetEncoding("gb2312"));
                    }
                    SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
                    SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
                    tmp.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                    tmp.CompressDirectory(tempFullName, destFolder + "\\" + dsFinalArchive.Tables[0].Rows[i]["����ID"].ToString() + ".sip");

                    MyCommon.DeleteAndCreateEmptyDirectory(tempFullName, false);
                }
            }
            catch (Exception ex)
            {
                MyCommon.DeleteAndCreateEmptyDirectory(tempFullName, false);
                TXMessageBoxExtensions.Info("��װ����ʱ����������󣡴���002");
                MyCommon.WriteLog("�����ƽ��ļ�ʱʧ�ܣ�������Ϣ��" + ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
