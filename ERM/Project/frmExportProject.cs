using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using System.Data.OleDb;
using TX.Framework.WindowUI.Forms;
using CCWin.SkinControl;
namespace ERM.UI
{
    /// <summary>
    /// ������Ϣ���� ���ݣ��ָ�������
    /// </summary>
    public partial class frmExportProject : ERM.UI.Controls.Skin_DevEX
    {
        #region ������ʼ��
        private string _projectNO = string.Empty;
        private string _projectName = string.Empty;
        private string _opType = string.Empty;
        private static object m_monitorObject = new object();
        bool chk_DBPath = true;
        delegate void addMessage(string msg);
        delegate void setText(string msg, SkinLabel label);
        delegate void setEanble(bool flag, Button btn);
        delegate void showBar();
        delegate void setBar(int value);
        delegate void closeWin();
        Thread t = null;
        public string OpType
        {
            get
            {
                return _opType;
            }
            set
            {
                _opType = value;
            }
        }
        public string ProjectNO
        {
            get
            {
                return _projectNO;
            }
            set
            {
                _projectNO = value;
            }
        }
        public string ProjectName
        {
            get
            {
                return _projectName;
            }
            set
            {
                _projectName = value;
            }
        }
        #endregion

        #region ���庯��
        public frmExportProject()
        {
            InitializeComponent();
        }

        public void CloseWin()
        {
            this.Close();
        }

        public void SetEanble(bool flag, Button btn)
        {
            btn.Enabled = flag;
        }

        public void SetText(string msg, SkinLabel label)
        {
            label.Text = msg;
        }

        public void SetBar(int value)
        {
            this.pgb_Bar.Value = value;
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="setText">Label��ֵί��ʵ��</param>
        /// <param name="addMsg"></param>
        /// <param name="showBar">Bar��ʾ����ί��ʵ��</param>
        /// <param name="setBar">��������ֵί��</param>
        /// <param name="enable">�Ƿ����</param>
        /// <param name="close">�رմ���ί��</param>
        /// <param name="t">�߳�ʵ��</param>
        private void Backup(setText setText, addMessage addMsg, showBar showBar, setBar setBar, setEanble enable, closeWin close, Thread t)
        {
            #region ����
            string FileName = strFileName.Text;
            FileInfo finfo = new FileInfo(FileName);
            string FilePath = finfo.DirectoryName;
            pgb_Bar.BeginInvoke(setBar, new object[] { 0 });
            lbl_BarText.BeginInvoke(setText, new object[] { "", this.lbl_BarText });
            lock (m_monitorObject)
            {
                lbl_BarText.BeginInvoke(setText, new object[] { "����׼������...", this.lbl_BarText });
                listBox1.BeginInvoke(addMsg, new object[] { "����׼������..." });
            }
            try
            {
                double projectSize = Convert.ToDouble(DirectoryInfoCommon.GetDirectorySpace(Application.StartupPath + "\\Project\\" + ProjectNO) / Convert.ToDouble(1024 * 1024 * 1024));
                if (MyCommon.CheckDisk(FilePath) < projectSize * 2)
                {
                    //Ӳ�̿ռ䲻��
                    TXMessageBoxExtensions.Info("���ݹ�����ҪӲ�̴�СΪ��" + System.Math.Round(projectSize * 2, 2) + "G ����Ŀ¼Ӳ�̿ռ䲻��,�޷����ݣ� \r\n ����ܰ��ʾ����ѡ�񱣴浽�ȽϿ��е��̷���");

                    button1.BeginInvoke(enable, new object[] { true, button1 });
                    button2.BeginInvoke(enable, new object[] { true, button2 });
                    button3.BeginInvoke(enable, new object[] { true, button3 });
                    return;
                }

                int barCount = 1;
                if (Directory.Exists(Application.StartupPath + "\\Project\\" + ProjectNO + "\\"))
                {
                    MyCommon.GetFileCountByDirectory(Application.StartupPath + "\\Project\\" + ProjectNO + "\\", ref barCount);
                }
                lock (m_monitorObject)
                {
                    pgb_Bar.BeginInvoke(setBar, new object[] { barCount });
                }
                ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNO + "\\");
                ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNO + "\\Project\\");
                ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNO + "\\Project\\" + ProjectNO);
                ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNO + "\\db\\");
                string DataBaseName = "ERMDB.mdb";
                System.IO.File.Copy(Application.StartupPath + "\\db\\" + DataBaseName, FilePath + "\\" + ProjectNO + "\\db\\" + DataBaseName, true);
                string Connection = "Provider=Microsoft.Jet.OLEDB.4.0;jet OleDB:Database Password=;Data Source=" + FilePath + "\\" + ProjectNO + "\\db\\" + DataBaseName + ";Persist Security Info=true";
                OleDbConnection conn = new OleDbConnection(Connection);
                conn.Open();
                OleDbCommand comm1 = new OleDbCommand();
                comm1.Connection = conn;
                string strSql = "SELECT * FROM T_Projects WHERE ProjectNO='" + ProjectNO + "'";
                comm1.CommandText = strSql;
                System.Data.OleDb.OleDbDataReader rs1 = comm1.ExecuteReader();
                string ItemID = "";
                if (rs1.Read())
                {
                    ItemID = rs1["ItemID"].ToString();
                }
                rs1.Close();
                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "�������ݿⱸ��...", this.lbl_BarText });
                    this.pgb_Bar.BeginInvoke(showBar, new object[] { });
                }
                if (ItemID != string.Empty)
                {
                    strSql = "delete from T_Item where ItemID<>'" + ItemID + "'";
                    comm1.CommandText = strSql;
                    comm1.ExecuteNonQuery();

                    strSql = "delete from T_Projects where ProjectNO<>'" + ProjectNO + "'";
                    comm1.CommandText = strSql;
                    comm1.ExecuteNonQuery();

                    strSql = "delete from T_FileList where ProjectNO<>'" + ProjectNO + "'";
                    comm1.CommandText = strSql;
                    comm1.ExecuteNonQuery();

                    strSql = "delete from T_Archive where ProjectNO<>'" + ProjectNO + "'";
                    comm1.CommandText = strSql;
                    comm1.ExecuteNonQuery();

                    strSql = "delete from T_CellAndEFile where ProjectNO<>'" + ProjectNO + "'";
                    comm1.CommandText = strSql;
                    comm1.ExecuteNonQuery();

                    strSql = "delete from T_Units where ProjectNO<>'" + ProjectNO + "'";
                    comm1.CommandText = strSql;
                    comm1.ExecuteNonQuery();

                    strSql = "delete from T_GdList where ProjectNo<>'" + ProjectNO + "'";
                    comm1.CommandText = strSql;
                    comm1.ExecuteNonQuery();

                    #region add backup
                    strSql = "delete from T_Traffic where ProjectID<>'" + ProjectNO + "'";
                    comm1.CommandText = strSql;
                    comm1.ExecuteNonQuery();

                    strSql = "delete from T_Traffic_Detail where Trafficid<>(select id from t_traffic where projectid='" + ProjectNO + "')";
                    comm1.CommandText = strSql;
                    comm1.ExecuteNonQuery();

                    strSql = "delete from T_Project_RoadLamp where ProjectID<>'" + ProjectNO + "'";
                    comm1.CommandText = strSql;
                    comm1.ExecuteNonQuery();

                    strSql = "delete from T_Project_Brige where ProjectID<>'" + ProjectNO + "'";
                    comm1.CommandText = strSql;
                    comm1.ExecuteNonQuery();

                    strSql = "delete from T_Point where ProjectNo<>'" + ProjectNO + "'";
                    comm1.CommandText = strSql;
                    comm1.ExecuteNonQuery();
                    #endregion


                    conn.Close();
                }

                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "���ڱ����ļ�...", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "���ݿⱸ�ݳɹ�..." });
                    listBox1.BeginInvoke(addMsg, new object[] { "����׼���ļ�..." });
                }
                if (Directory.Exists(Application.StartupPath + "\\Project\\" + ProjectNO + "\\"))
                {
                    List<string> folderList = new List<string>();
                    folderList.Add("ODOC");
                    folderList.Add("PDF");
                    folderList.Add("MPDF");

                    foreach (string folderName in folderList)
                    {
                        if (System.IO.Directory.Exists(Application.StartupPath + "\\Project\\" + ProjectNO + "\\" + folderName + "\\"))
                        {
                            string[] Files = System.IO.Directory.GetFiles(Application.StartupPath + "\\Project\\" + ProjectNO + "\\" + folderName + "\\");
                            System.IO.Directory.CreateDirectory(FilePath + "\\" + ProjectNO + "\\Project\\" + ProjectNO + "\\" + folderName + "\\");
                            foreach (string f1 in Files)
                            {
                                System.IO.FileInfo finfo2 = new System.IO.FileInfo(f1);
                                System.IO.File.Copy(f1, FilePath + "\\" + ProjectNO + "\\Project\\" + ProjectNO + "\\" + folderName + "\\" + finfo2.Name, true);
                                lock (m_monitorObject)
                                {
                                    lbl_BarText.BeginInvoke(setText, new object[] { "���ڱ����ļ���...\\" + finfo2.Name, this.lbl_BarText });
                                    this.pgb_Bar.BeginInvoke(showBar, new object[] { });
                                    listBox1.BeginInvoke(addMsg, new object[] { "�ɹ������ļ���" + f1 });
                                }
                            }
                        }
                    }
                }
                lbl_BarText.BeginInvoke(setText, new object[] { "����ѹ��������Ϣ,���Ժ�...", this.lbl_BarText });
                this.pgb_Bar.BeginInvoke(setBar, new object[] { pgb_Bar.Maximum / 2 });

                SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
                SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
                tmp.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                tmp.CompressDirectory(FilePath + "\\" + ProjectNO + "\\", FileName);

                ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNO + "\\", false);//���ﲻ�ô���
                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "������ɣ�", this.lbl_BarText });
                }
                this.pgb_Bar.BeginInvoke(setBar, 100);
                TXMessageBoxExtensions.Info("��ʾ��������ɣ�");


                button1.BeginInvoke(enable, new object[] { true, button1 });
                button2.BeginInvoke(enable, new object[] { true, button2 });
                button3.BeginInvoke(enable, new object[] { true, button3 });
                this.BeginInvoke(close, new object[] { });
            }
            catch(Exception e)
            {
                button1.BeginInvoke(enable, new object[] { true, button1 });
                button2.BeginInvoke(enable, new object[] { true, button2 });
                button3.BeginInvoke(enable, new object[] { true, button3 });
                TXMessageBoxExtensions.Info("��ʾ������ʧ�ܣ�\r\n"+e.Message.ToString());
                ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNO + "\\", false);
                this.BeginInvoke(close, new object[] { });
                t.Abort();

            }
            t.Abort();
            #endregion
        }

        /// <summary>
        /// �ָ�����
        /// </summary>
        /// <param name="setText">�ı���ʾί��</param>
        /// <param name="addMsg">�ļ���Ϣ����</param>
        /// <param name="showBar">��������ʾ</param>
        /// <param name="setBar">����������ֵ��ί��</param>
        /// <param name="enable">������ť���û��������ί��</param>
        /// <param name="close">�رմ���ί��</param>
        /// <param name="t">���̶߳���</param>
        private void Restore(setText setText, addMessage addMsg, showBar showBar, setBar setBar, setEanble enable, closeWin close, Thread t)
        {
            #region �ָ�
            string FileName = strFileName.Text;
            FileInfo finfo = new FileInfo(FileName);
            string FilePath = finfo.DirectoryName;

            this.pgb_Bar.BeginInvoke(setBar, new object[] { 0 });
            lbl_BarText.BeginInvoke(setText, new object[] { "", this.lbl_BarText });
            bool showLastMessage_flg = true;
            lock (m_monitorObject)
            {
                lbl_BarText.BeginInvoke(setText, new object[] { "����׼���ָ�...", this.lbl_BarText });
                listBox1.BeginInvoke(addMsg, new object[] { "����׼���ָ�..." });
            }
            string ProjectNOFolder = "tempProjectFolder";
            ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNOFolder + "\\", false);
            ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNOFolder + "\\");
            try
            {
                double projectSize = Convert.ToDouble(DirectoryInfoCommon.FileSpace(FileName) / Convert.ToDouble(1024 * 1024 * 1024));
                if (MyCommon.CheckDisk(FilePath) < projectSize * 2)
                {
                    //Ӳ�̿ռ䲻��
                    TXMessageBoxExtensions.Info("�ָ�������ҪӲ�̴�СΪ��" + System.Math.Round(projectSize * 2, 2) + "G ��ǰ�����ļ���Ŀ¼Ӳ�̿ռ䲻��,�޷��ָ��� \r\n ����ܰ��ʾ���뽫�����ļ��������ȽϿ��е��̷���");
                    button1.BeginInvoke(enable, new object[] { true, button1 });
                    return;
                }
                //Common.UpZipFile z1 = new Common.UpZipFile(FileName, FilePath + "\\" + ProjectNOFolder + "\\");

                using (SevenZip.SevenZipExtractor tmp = new SevenZip.SevenZipExtractor(FileName))
                {
                    SevenZip.SevenZipExtractor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
                    for (int i = 0; i < tmp.ArchiveFileData.Count; i++)
                    {
                        tmp.ExtractFiles(System.IO.Path.Combine(FilePath, ProjectNOFolder), tmp.ArchiveFileData[i].Index);
                        lbl_BarText.BeginInvoke(setText, new object[] { "���ڽ�ѹ�ļ���" + tmp.ArchiveFileData[i].FileName, this.lbl_BarText });
                    }
                }
                System.Threading.Thread.Sleep(1000);

                int barCount = 7;
                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "���ڽ�ѹ�ָ��ļ�...", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "���ڽ�ѹ�ָ��ļ�..." });
                }
                //z1.StartUnZip();
                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "���ڻָ�������Ϣ...", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "�ڻָ�������Ϣ..." });
                }

                if (!System.IO.Directory.Exists(FilePath + "\\" + ProjectNOFolder + "\\db"))
                {
                    if (FilePath.EndsWith("\\"))
                        FilePath = FilePath.Substring(0, FilePath.Length - 1);

                    chk_DBPath = true;
                    GetDBPath(FilePath + "\\" + ProjectNOFolder, ref ProjectNOFolder);
                    if (ProjectNOFolder != "tempProjectFolder")
                        ProjectNOFolder = ProjectNOFolder.Replace(FilePath + "\\", "");
                }

                if (System.IO.File.Exists(FilePath + "\\" + ProjectNOFolder + "\\db\\ERMDB.mdb"))
                {
                    string Connection = Digi.DBUtility.PubConstant.ConnectionString;
                    OleDbConnection conn = new OleDbConnection(Connection);
                    conn.Open();
                    OleDbCommand comm1 = new OleDbCommand();
                    comm1.Connection = conn;

                    string Connection2 = "Provider=Microsoft.Jet.OLEDB.4.0;jet OleDB:Database Password=;Data Source=" + FilePath + "\\" + ProjectNOFolder + "\\db\\ERMDB.mdb;Persist Security Info=true";
                    OleDbConnection conn2 = new OleDbConnection(Connection2);
                    conn2.Open();

                    string strSql = "SELECT * FROM T_Projects";
                    OleDbCommand comm2 = new OleDbCommand();
                    comm2.Connection = conn2;
                    comm2.CommandText = strSql;

                    System.Data.OleDb.OleDbDataReader rs1 = comm2.ExecuteReader();
                    string ItemID = "";
                    string FromProjectNO = "";
                    if (rs1.Read())
                    {
                        FromProjectNO = rs1["ProjectNO"].ToString();
                        ItemID = rs1["ItemID"].ToString();
                    }
                    rs1.Close();
                    if (FromProjectNO != null && ItemID != string.Empty)
                    {
                        //ͳ��״̬����Ϣ
                        #region
                        if (Directory.Exists(FilePath + "\\" + ProjectNOFolder + "\\Project\\" + FromProjectNO + "\\"))
                        {
                            MyCommon.GetFileCountByDirectory(FilePath + "\\" + ProjectNOFolder + "\\Project\\" + FromProjectNO + "\\", ref barCount);
                        }

                        pgb_Bar.BeginInvoke(new Action(delegate() { pgb_Bar.Maximum = barCount; }));

                        strSql = "SELECT * FROM T_Projects WHERE ProjectNO='" + FromProjectNO + "'";
                        comm1.CommandText = strSql;
                        OleDbDataReader rs2 = comm1.ExecuteReader();
                        bool bExist = false;
                        if (rs2.Read())
                        {
                            bExist = true;
                            ItemID = rs2["ItemID"].ToString();
                        }
                        else
                        {
                            ItemID = "";
                        }
                        rs2.Close();
                        bool isGo_flag = true;
                        if (bExist == true)
                        {
                            if (TXMessageBoxExtensions.Question("��ʾ��������ͬ�Ĺ��̱�š�" + FromProjectNO + "��,�Ƿ�����ָ���\n����ܰ��ʾ��������ͬ�Ĺ��̱��ʱ����������ָ����Ὣ������ͬ�ļ�¼���³ɻָ��ļ��й��̵���Ϣ��") != DialogResult.OK)
                            {
                                isGo_flag = false;
                            }
                        }
                        if (isGo_flag)
                        {
                            lbl_BarText.BeginInvoke(setText, new object[] { "���ڻָ�������Ϣ...", this.lbl_BarText });
                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });
                            UpdateOrAddTable(bExist, "T_Projects", conn2, conn);

                            strSql = "SELECT * FROM T_Item WHERE ItemID='" + ItemID + "'";
                            comm1.CommandText = strSql;
                            OleDbDataReader rs3 = comm1.ExecuteReader();
                            bExist = false;
                            if (rs3.Read())
                            {
                                bExist = true;
                            }
                            rs3.Close();
                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });
                            UpdateOrAddTable(bExist, "T_Item", conn2, conn);

                            #region �ļ����ָ�
                            using (DataSet ds_Source = new DataSet())
                            {
                                OleDbDataAdapter adp2 = new OleDbDataAdapter("select * from T_FileList", conn2);
                                adp2.Fill(ds_Source);
                                if (ds_Source.Tables.Count > 0)
                                {
                                    DataTable tbl_Source = ds_Source.Tables[0];

                                    OleDbDataAdapter adp1 = new OleDbDataAdapter("SELECT * FROM T_FileList WHERE ProjectNO='" + FromProjectNO + "'", conn);
                                    DataTable tbl_FileList = new DataTable();
                                    adp1.Fill(tbl_FileList);

                                    if (tbl_FileList != null && tbl_FileList.Rows.Count > 0)
                                    {
                                        foreach (DataRow sfilelist_row in tbl_Source.Rows)
                                        {
                                            DataRow[] temp_rows =
                                                tbl_FileList.Select("FileID='" + sfilelist_row["FileID"] + "' AND projectNO='" + FromProjectNO + "'");
                                            if (temp_rows != null && temp_rows.Length > 0)
                                                sfilelist_row.SetModified();
                                            else
                                                sfilelist_row.SetAdded();
                                        }
                                    }
                                    else
                                    {
                                        foreach (DataRow sfilelist_row in tbl_Source.Rows)
                                        {
                                            sfilelist_row.SetAdded();
                                        }
                                    }
                                    UpdateOrAddTable("T_FileList", ds_Source, conn);
                                }
                            }

                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });
                            #endregion

                            #region �����ָ�
                            using (DataSet ds_Source = new DataSet())
                            {
                                OleDbDataAdapter adp2 = new OleDbDataAdapter("select * from T_Archive", conn2);
                                adp2.Fill(ds_Source);
                                if (ds_Source.Tables.Count > 0)
                                {
                                    DataTable tbl_Source = ds_Source.Tables[0];

                                    OleDbDataAdapter adp1 = new OleDbDataAdapter("SELECT * FROM T_Archive WHERE ProjectNO='" + FromProjectNO + "'", conn);
                                    DataTable tbl_FileList = new DataTable();
                                    adp1.Fill(tbl_FileList);

                                    if (tbl_FileList != null && tbl_FileList.Rows.Count > 0)
                                    {
                                        foreach (DataRow s_row in tbl_Source.Rows)
                                        {
                                            DataRow[] temp_rows =
                                                tbl_FileList.Select("ArchiveID='" + s_row["ArchiveID"] + "' AND ProjectNO='" + FromProjectNO + "'");
                                            if (temp_rows != null && temp_rows.Length > 0)
                                                s_row.SetModified();
                                            else
                                                s_row.SetAdded();
                                        }
                                    }
                                    else
                                    {
                                        foreach (DataRow s_row in tbl_Source.Rows)
                                        {
                                            s_row.SetAdded();
                                        }
                                    }
                                    UpdateOrAddTable("T_Archive", ds_Source, conn);
                                }
                            }

                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });
                            #endregion

                            #region �����ļ���
                            using (DataSet ds_Source = new DataSet())
                            {
                                OleDbDataAdapter adp2 = new OleDbDataAdapter("select * from T_CellAndEFile", conn2);
                                adp2.Fill(ds_Source);
                                if (ds_Source.Tables.Count > 0)
                                {
                                    DataTable tbl_Source = ds_Source.Tables[0];

                                    OleDbDataAdapter adp1 = new OleDbDataAdapter("SELECT * FROM T_CellAndEFile WHERE ProjectNO='" + FromProjectNO + "'", conn);
                                    DataTable tbl_FileList = new DataTable();
                                    adp1.Fill(tbl_FileList);

                                    if (tbl_FileList != null && tbl_FileList.Rows.Count > 0)
                                    {
                                        foreach (DataRow s_row in tbl_Source.Rows)
                                        {
                                            DataRow[] temp_rows =
                                                tbl_FileList.Select("CellID='" + s_row["CellID"] + "' AND ProjectNO='" + FromProjectNO + "'");
                                            if (temp_rows != null && temp_rows.Length > 0)
                                                s_row.SetModified();
                                            else
                                                s_row.SetAdded();
                                        }
                                    }
                                    else
                                    {
                                        foreach (DataRow s_row in tbl_Source.Rows)
                                        {
                                            s_row.SetAdded();
                                        }
                                    }
                                    UpdateOrAddTable("T_CellAndEFile", ds_Source, conn);
                                }
                            }
                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });
                            #endregion

                            #region ���̵�λ
                            using (DataSet ds_Source = new DataSet())
                            {
                                OleDbDataAdapter adp2 = new OleDbDataAdapter("select * from T_Units", conn2);
                                adp2.Fill(ds_Source);
                                if (ds_Source.Tables.Count > 0)
                                {
                                    DataTable tbl_Source = ds_Source.Tables[0];

                                    OleDbDataAdapter adp1 = new OleDbDataAdapter("SELECT * FROM T_Units WHERE ProjectNO='" + FromProjectNO + "'", conn);
                                    DataTable tbl_FileList = new DataTable();
                                    adp1.Fill(tbl_FileList);

                                    if (tbl_FileList != null && tbl_FileList.Rows.Count > 0)
                                    {
                                        foreach (DataRow s_row in tbl_Source.Rows)
                                        {
                                            DataRow[] temp_rows =
                                                tbl_FileList.Select("UnitID='" + s_row["UnitID"] + "' AND ProjectNO='" + FromProjectNO + "'");
                                            if (temp_rows != null && temp_rows.Length > 0)
                                                s_row.SetModified();
                                            else
                                                s_row.SetAdded();
                                        }
                                    }
                                    else
                                    {
                                        foreach (DataRow s_row in tbl_Source.Rows)
                                        {
                                            s_row.SetAdded();
                                        }
                                    }
                                    UpdateOrAddTable("T_Units", ds_Source, conn);
                                }
                            }
                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });
                            #endregion

                            #region �鵵Ŀ¼��
                            using (DataSet ds_Source = new DataSet())
                            {
                                OleDbDataAdapter adp2 = new OleDbDataAdapter("select * from T_GdList", conn2);
                                adp2.Fill(ds_Source);
                                if (ds_Source.Tables.Count > 0)
                                {
                                    DataTable tbl_Source = ds_Source.Tables[0];

                                    OleDbDataAdapter adp1 = new OleDbDataAdapter("SELECT * FROM T_GdList WHERE ProjectNo='" + FromProjectNO + "'", conn);
                                    DataTable tbl_GdList = new DataTable();
                                    adp1.Fill(tbl_GdList);

                                    if (tbl_GdList != null && tbl_GdList.Rows.Count > 0)
                                    {
                                        foreach (DataRow sgd_row in tbl_Source.Rows)
                                        {
                                            DataRow[] temp_rows =
                                                tbl_GdList.Select("ID='" + sgd_row["ID"] + "' AND projectNo='" + FromProjectNO + "'");
                                            if (temp_rows != null && temp_rows.Length > 0)
                                                sgd_row.SetModified();
                                            else
                                                sgd_row.SetAdded();
                                        }
                                    }
                                    else
                                    {
                                        foreach (DataRow sgd_row in tbl_Source.Rows)
                                        {
                                            sgd_row.SetAdded();
                                        }
                                    }
                                    UpdateOrAddTable("T_GdList", ds_Source, conn);
                                }
                            }

                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });
                            #endregion

                            #region add restore

                            #region ����ָ�
                            Restore_Items(conn, conn2, FromProjectNO, "T_Point", "ProjectNo", showBar);
                            #endregion

                            #region �������ָ̻�
                            Restore_Items(conn, conn2, FromProjectNO, "T_Project_Brige", "ProjectID", showBar);
                            #endregion

                            #region ·�ƹ��ָ̻�
                            Restore_Items(conn, conn2, FromProjectNO, "T_Project_RoadLamp", "ProjectID", showBar);
                            #endregion

                            #region ��ͨ���ָ̻�
                            Restore_Items(conn, conn2, FromProjectNO, "T_Traffic", "ProjectID", showBar);

                            string sql = "select * from t_traffic where projectid='" + FromProjectNO + "'";
                            OleDbCommand comm3 = new OleDbCommand();
                            comm3.Connection = conn2;
                            comm3.CommandText = sql;

                            System.Data.OleDb.OleDbDataReader rs4 = comm3.ExecuteReader();
                            string trafficID = "";
                            if (rs4.Read())
                            {
                                trafficID = rs4["id"].ToString();
                            }
                            if (!string.IsNullOrEmpty(trafficID))
                            {
                                Restore_Items(conn, conn2, trafficID, "T_Traffic_Detail", "TrafficID", showBar);
                            }
                            #endregion
                        }
                        else
                            showLastMessage_flg = false;

                            #endregion
                    }
                    else
                    {
                        TXMessageBoxExtensions.Info("��ʾ�������������ȷ�ϵ������Ϣ�Ƿ���ȷ��");
                        showLastMessage_flg = false;
                    }
                    conn.Close();
                    conn2.Close();
                    Thread.Sleep(1000);
                    if (showLastMessage_flg)
                    {
                        lock (m_monitorObject)
                        {
                            lbl_BarText.BeginInvoke(setText, new object[] { "����׼���ָ��ļ���...", this.lbl_BarText });
                            listBox1.BeginInvoke(addMsg, new object[] { "���ݿ�ָ��ɹ�..." });
                            listBox1.BeginInvoke(addMsg, new object[] { "����׼���ָ��ļ�..." });
                        }


                        if (Directory.Exists(FilePath + "\\" + ProjectNOFolder + "\\Project\\" + FromProjectNO + "\\"))
                        {
                            List<string> folderList = new List<string>();
                            folderList.Add("ODOC");
                            folderList.Add("PDF");
                            folderList.Add("MPDF");

                            foreach (string folderName in folderList)
                            {
                                if (Directory.Exists(FilePath + "\\" + ProjectNOFolder + "\\Project\\" + FromProjectNO + "\\" + folderName))
                                {
                                    string[] Files = System.IO.Directory.GetFiles(FilePath + "\\" + ProjectNOFolder + "\\Project\\" + FromProjectNO + "\\" + folderName);
                                    ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(Application.StartupPath + "\\Project\\" + FromProjectNO + "\\" + folderName + "\\");
                                    foreach (string f1 in Files)
                                    {
                                        System.IO.FileInfo finfo2 = new System.IO.FileInfo(f1);
                                        System.IO.File.Copy(f1, Application.StartupPath + "\\Project\\" + FromProjectNO + "\\" + folderName + "\\" + finfo2.Name, true);
                                        File.SetAttributes(Application.StartupPath + "\\Project\\" + FromProjectNO + "\\" + folderName + "\\" + finfo2.Name,
                                            FileAttributes.Normal);
                                        lock (m_monitorObject)
                                        {
                                            lbl_BarText.BeginInvoke(setText, new object[] { "���ڻָ��ļ���...\\" + finfo2.Name, this.lbl_BarText });
                                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });
                                            listBox1.BeginInvoke(addMsg, new object[] { "�ɹ��ָ��ļ���" + f1 });
                                        }
                                    }
                                }
                            }
                        }
                    }
                    ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNOFolder + "\\", false);
                }
                else
                {
                    TXMessageBoxExtensions.Info("��ʾ�������������ȷ�ϵ������Ϣ�Ƿ���ȷ��");
                    showLastMessage_flg = false;
                    pgb_Bar.BeginInvoke(setBar, new object[] { barCount });
                }

                Thread.Sleep(1000);
                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "�ָ���ɣ�", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "�ָ���ɣ�" });
                }

                if (showLastMessage_flg && TXMessageBoxExtensions.Question("��ʾ���ָ���ɣ� �Ƿ�����ָ���") != DialogResult.OK)
                { this.BeginInvoke(close, new object[] { }); }
                button1.BeginInvoke(enable, new object[] { true, button1 });
                button2.BeginInvoke(enable, new object[] { true, button1 });
                button3.BeginInvoke(enable, new object[] { true, button1 });
            }
            catch (Exception ex)
            {
                button1.BeginInvoke(enable, new object[] { true, button1 });
                button2.BeginInvoke(enable, new object[] { true, button1 });
                button3.BeginInvoke(enable, new object[] { true, button1 });
                TXMessageBoxExtensions.Info("��ʾ���ָ�ʧ�ܣ�\n" + ex.Message.ToString());
                MyCommon.WriteLog("�ָ�ʧ�ܣ�" + ex.Message);
                ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNOFolder + "\\", false);
                this.BeginInvoke(close, new object[] { });
                t.Abort();
            }
            t.Abort();
                        #endregion
        }

        private void Restore_Items(OleDbConnection conn, OleDbConnection conn2, string FromProjectNO, string tableName, string property, showBar showBar)
        {
            using (DataSet ds_Source = new DataSet())
            {
                OleDbDataAdapter adp2 = new OleDbDataAdapter("select * from " + tableName, conn2);
                adp2.Fill(ds_Source);
                if (ds_Source.Tables.Count > 0)
                {
                    DataTable tbl_Source = ds_Source.Tables[0];

                    OleDbDataAdapter adp1 = new OleDbDataAdapter("SELECT * FROM " + tableName + " WHERE " + property + "='" + FromProjectNO + "'", conn);
                    DataTable tbl_FileList = new DataTable();
                    adp1.Fill(tbl_FileList);

                    if (tbl_FileList != null && tbl_FileList.Rows.Count > 0)
                    {
                        foreach (DataRow s_row in tbl_Source.Rows)
                        {
                            DataRow[] temp_rows =
                                tbl_FileList.Select("ID='" + s_row["ID"] + "' AND " + property + "='" + FromProjectNO + "'");
                            if (temp_rows != null && temp_rows.Length > 0)
                                s_row.SetModified();
                            else
                                s_row.SetAdded();
                        }
                    }
                    else
                    {
                        foreach (DataRow s_row in tbl_Source.Rows)
                        {
                            s_row.SetAdded();
                        }
                    }
                    UpdateOrAddTable(tableName, ds_Source, conn);
                }
            }
            this.pgb_Bar.BeginInvoke(showBar, new object[] { });
        }
        private void DaoRu(setText setText, addMessage addMsg, showBar showBar, setBar setBar, setEanble enable, closeWin close, Thread t)
        {
            #region ����
            string FileName = strFileName.Text;
            FileInfo finfo = new FileInfo(FileName);
            string FilePath = finfo.DirectoryName;

            pgb_Bar.BeginInvoke(setBar, new object[] { 0 });
            lbl_BarText.BeginInvoke(setText, new object[] { "", this.lbl_BarText });
            bool showLastMessage_flg = true;
            lock (m_monitorObject)
            {
                lbl_BarText.BeginInvoke(setText, new object[] { "����׼������...", this.lbl_BarText });
                listBox1.BeginInvoke(addMsg, new object[] { "����׼������..." });
            }
            string ProjectNOFolder = "tempProjectFolder";
            ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNOFolder + "\\", false);
            ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNOFolder + "\\");

            try
            {
                //Common.UpZipFile z1 = new Common.UpZipFile(FileName, FilePath + "\\" + ProjectNOFolder + "\\");

                int barCount = 3;

                pgb_Bar.BeginInvoke(new Action(delegate() { pgb_Bar.Maximum = barCount; }));
                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "���ڽ�ѹ�����ļ�...", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "���ڽ�ѹ�����ļ�..." });
                }
                //z1.StartUnZip();

                using (SevenZip.SevenZipExtractor tmp = new SevenZip.SevenZipExtractor(FileName))
                {
                    SevenZip.SevenZipExtractor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
                    for (int i = 0; i < tmp.ArchiveFileData.Count; i++)
                    {
                        tmp.ExtractFiles(FilePath + "\\" + ProjectNOFolder + "\\", tmp.ArchiveFileData[i].Index);
                    }
                }

                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "������������...", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "������������..." });
                }

                if (System.IO.File.Exists(FilePath + "\\" + ProjectNOFolder + "\\ERMDB.mdb"))
                {
                    string Connection = Digi.DBUtility.PubConstant.ConnectionString;
                    OleDbConnection conn = new OleDbConnection(Connection);
                    conn.Open();
                    OleDbCommand comm1 = new OleDbCommand();
                    comm1.Connection = conn;

                    string Connection2 = "Provider=Microsoft.Jet.OLEDB.4.0;jet OleDB:Database Password=;Data Source=" + FilePath + "\\" + ProjectNOFolder + "\\ERMDB.mdb;Persist Security Info=true";
                    OleDbConnection conn2 = new OleDbConnection(Connection2);
                    conn2.Open();

                    string strSql = "SELECT * FROM T_Projects";
                    OleDbCommand comm2 = new OleDbCommand();
                    comm2.Connection = conn2;
                    comm2.CommandText = strSql;

                    System.Data.OleDb.OleDbDataReader rs1 = comm2.ExecuteReader();
                    string ItemID = "";
                    string FromProjectNO = "";
                    if (rs1.Read())
                    {
                        FromProjectNO = rs1["ProjectNO"].ToString();
                        ItemID = rs1["ItemID"].ToString();
                    }
                    rs1.Close();
                    if (FromProjectNO != null && ItemID != string.Empty)
                    {
                        strSql = "SELECT * FROM T_Projects WHERE ProjectNO='" + FromProjectNO + "'";// or ItemID='" + ItemID + "'
                        comm1.CommandText = strSql;
                        OleDbDataReader rs2 = comm1.ExecuteReader();
                        bool bExist = false;
                        if (rs2.Read())
                        {
                            //������ͬ�Ĺ��̱�� ֱ������
                            bExist = true;
                            ItemID = rs2["ItemID"].ToString();
                        }
                        else
                        {
                            ItemID = "";
                        }
                        rs2.Close();
                        if (!bExist)
                        {
                            //û����ͬ�Ĺ��̱��
                            lbl_BarText.BeginInvoke(setText, new object[] { "���ڵ��빤����Ϣ...", this.lbl_BarText });

                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });

                            UpdateOrAddTable(bExist, "T_Projects", conn2, conn);

                            strSql = "SELECT * FROM T_Item WHERE ItemID='" + ItemID + "'";
                            comm1.CommandText = strSql;
                            OleDbDataReader rs3 = comm1.ExecuteReader();
                            bExist = false;
                            if (rs3.Read())
                            {
                                bExist = true;
                            }
                            rs3.Close();

                            UpdateOrAddTable(bExist, "T_Item", conn2, conn);

                            strSql = "SELECT * FROM T_FileList WHERE ProjectNO='" + FromProjectNO + "'";
                            comm1.CommandText = strSql;
                            OleDbDataReader rs4 = comm1.ExecuteReader();
                            bExist = false;
                            if (rs4.Read())
                            {
                                bExist = true;
                            }
                            rs4.Close();
                            lbl_BarText.BeginInvoke(setText, new object[] { "���ڵ����ļ���Ϣ...\\", this.lbl_BarText });

                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });

                            UpdateOrAddTable(bExist, "T_FileList", conn2, conn);

                            strSql = "SELECT * FROM T_CellAndEFile WHERE ProjectNO='" + FromProjectNO + "'";
                            comm1.CommandText = strSql;
                            OleDbDataReader rs6 = comm1.ExecuteReader();
                            bExist = false;
                            if (rs6.Read())
                            {
                                bExist = true;
                            }
                            rs6.Close();
                            lbl_BarText.BeginInvoke(setText, new object[] { "���ڵ�������ļ���Ϣ...", this.lbl_BarText });

                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });

                            UpdateOrAddTable(bExist, "T_CellAndEFile", conn2, conn);


                            #region add Import
                            #region import brige
                            Import(conn, comm1, conn2, ref strSql, FromProjectNO, ref bExist, "T_Project_Brige", "����");
                            #endregion

                            #region import roadLamp
                            Import(conn, comm1, conn2, ref strSql, FromProjectNO, ref bExist, "T_Project_RoadLamp", "·��");
                            #endregion

                            #region Traffic
                            Import(conn, comm1, conn2, ref strSql, FromProjectNO, ref bExist, "T_Traffic", "��ͨ");
                            #endregion

                            #region Point
                            Import(conn,comm1,conn2,ref strSql,FromProjectNO,ref bExist,"T_Point","����");
                            #endregion

                            #endregion
                        }
                        else
                        {
                            TXMessageBoxExtensions.Info("��ʾ������������ͬ��ŵĹ��̣�");
                            showLastMessage_flg = false;
                        }
                    }
                    else
                    {
                        TXMessageBoxExtensions.Info("��ʾ�������������ȷ�ϵ������Ϣ�Ƿ���ȷ��");
                        showLastMessage_flg = false;
                    }
                    conn.Close();
                    conn2.Close();
                    Thread.Sleep(1000);
                    lock (m_monitorObject)
                    {
                        if (showLastMessage_flg)
                        {
                            listBox1.BeginInvoke(addMsg, new object[] { "���ݿ⵼��ɹ�..." });
                            listBox1.BeginInvoke(addMsg, new object[] { "����׼���ָ��ļ�..." });
                        }
                    }
                    if (Directory.Exists(FilePath + "\\" + ProjectNOFolder + "\\"))
                    {
                        ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNOFolder + "\\", false);
                    }
                }
                else
                {
                    this.pgb_Bar.BeginInvoke(setBar, new object[] { pgb_Bar.Maximum });
                    TXMessageBoxExtensions.Info("��ʾ�������������ȷ�ϵ������Ϣ�Ƿ���ȷ��");
                    showLastMessage_flg = false;
                }
                pgb_Bar.BeginInvoke(setBar, new object[] { pgb_Bar.Maximum });
                Thread.Sleep(1000);
                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "������ɣ�", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "������ɣ�" });
                }
                if (showLastMessage_flg && TXMessageBoxExtensions.Question("��ʾ��������ɣ� �Ƿ�������룿") != DialogResult.OK)
                {
                    this.BeginInvoke(close, new object[] { });
                }
                button1.BeginInvoke(enable, new object[] { true, button1 });
                button2.BeginInvoke(enable, new object[] { true, button1 });
                button3.BeginInvoke(enable, new object[] { true, button1 });
            }
            catch
            {
                button1.BeginInvoke(enable, new object[] { true, button1 });
                button2.BeginInvoke(enable, new object[] { true, button1 });
                button3.BeginInvoke(enable, new object[] { true, button1 });
                TXMessageBoxExtensions.Info("��ʾ������ʧ�ܣ�");
                ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNOFolder + "\\", false);
                this.BeginInvoke(close, new object[] { });
            }
            #endregion
        }

        private void Import(OleDbConnection conn, OleDbCommand comm1, OleDbConnection conn2, ref string strSql, string FromProjectNO, ref bool bExist, string tableName, string projectName)
        {
            strSql = "SELECT * FROM " + tableName + " WHERE ProjectID='" + FromProjectNO + "'";
            comm1.CommandText = strSql;
            OleDbDataReader rs = comm1.ExecuteReader();
            bExist = false;
            if (rs.Read())
            {
                bExist = true;
            }
            rs.Close();

            lbl_BarText.Text = "���ڵ���" + projectName + "������Ϣ...\\";
            ShowBarIndex();

            UpdateOrAddTable(bExist, tableName, conn2, conn);

        }
        private void frmExportProject_Load(object sender, EventArgs e)
        {
            this.Text = OpType;
            lbl_BarText.Text = "";
            if (OpType == "����")
            {
                button3.Text = "ѡ��Ŀ¼";
                this.Text = "���ݣ�" + ProjectName;
            }
            tabControl1.TabPages[0].Text = OpType;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {

            #region ��ֵί��
            setText setText = new frmExportProject.setText(SetText);
            addMessage addMsg = new addMessage(AddMessage);
            showBar showBar = new showBar(ShowBarIndex);
            setBar setBar = new setBar(SetBar);
            setEanble enable = new setEanble(SetEanble);
            closeWin close = new closeWin(CloseWin);
            #endregion

            try
            {
                listBox1.Items.Clear();

                if (OpType == "����")
                {
                    if (strFileName.Text == "")
                    {
                        button3_Click(sender, e);
                    }
                    if (strFileName.Text != "")
                    {
                        t = new Thread(delegate()
                        {
                            button1.BeginInvoke(enable, new object[] { false, button1 });
                            button2.BeginInvoke(enable, new object[] { false, button2 });
                            button3.BeginInvoke(enable, new object[] { false, button3 });
                            Backup(setText, addMsg, showBar, setBar, enable, close, t);
                        });
                        t.Start();
                    }
                }
                else if (OpType == "�ָ�")
                {
                    if (strFileName.Text == "")
                    {
                        button3_Click(sender, e);
                    }
                    if (strFileName.Text != "")
                    {
                        t = new Thread(delegate()
                        {
                            button1.BeginInvoke(enable, new object[] { false, button1 });
                            button2.BeginInvoke(enable, new object[] { false, button2 });
                            button3.BeginInvoke(enable, new object[] { false, button3 });
                            Restore(setText, addMsg, showBar, setBar, enable, close, t);
                        });
                        t.Start();
                    }
                }
                else if (OpType == "����")
                {
                    if (strFileName.Text == "")
                    {
                        button3_Click(sender, e);
                    }
                    if (strFileName.Text != "")
                    {
                        t = new Thread(delegate()
                        {
                            button1.BeginInvoke(enable, new object[] { false, button1 });
                            button2.BeginInvoke(enable, new object[] { false, button2 });
                            button3.BeginInvoke(enable, new object[] { false, button3 });
                            DaoRu(setText, addMsg, showBar, setBar, enable, close, t);
                        });
                        t.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "";
                if (OpType == "����")
                    message = "����";
                else if (OpType == "�ָ�")
                    message = "�ָ�";
                else if (OpType == "����")
                    message = "����";
                MyCommon.WriteLog(message + "����" + ex.Message);
                TXMessageBoxExtensions.Info("��ʾ��" + message + "ʧ�ܣ�");

                button1.BeginInvoke(enable, new object[] { true, button1 });
                button2.BeginInvoke(enable, new object[] { true, button2 });
                button3.BeginInvoke(enable, new object[] { true, button3 });
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                setText setText1 = new frmExportProject.setText(SetText);

                if (OpType == "����")
                {
                    saveFileDialog1.Filter = "���̱���(*.bak)|*.bak";

                    saveFileDialog1.FileName = ProjectName + ".bak";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        strFileName.Text = saveFileDialog1.FileName;
                    }
                }
                else if (OpType == "�ָ�")
                {
                    openFileDialog1.Filter = "���ָ̻�(*.bak)|*.bak";
                    openFileDialog1.FileName = "";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        strFileName.Text = openFileDialog1.FileName;
                    }
                }
                else if (OpType == "����")
                {
                    openFileDialog1.Filter = "���̵���(*.dbbak)|*.dbbak";
                    openFileDialog1.FileName = "";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        strFileName.Text = openFileDialog1.FileName;
                    }
                }
            }
            catch
            {
                string message = "";
                if (OpType == "����")
                    message = "����";
                else if (OpType == "�ָ�")
                    message = "�ָ�";
                else if (OpType == "����")
                    message = "����";
                TXMessageBoxExtensions.Info("��ʾ��" + message + "ʧ�ܣ�");
            }
        }
            #endregion

        #region �Զ��庯��
        private void UpdateOrAddTable(bool bExist, string TableName, OleDbConnection fromConnection, OleDbConnection toConnection)
        {
            DataSet ds2 = new DataSet();
            OleDbDataAdapter adp2 = new OleDbDataAdapter("select * from " + TableName + "", fromConnection);
            adp2.Fill(ds2);
            OleDbDataAdapter adp1 = new OleDbDataAdapter("select * from " + TableName + "", toConnection);
            OleDbCommandBuilder Comm = new OleDbCommandBuilder(adp1);
            try
            {
                DataTable dt = ds2.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    if (bExist == true)
                    {
                        dr.SetModified();
                    }
                    else
                    {
                        dr.SetAdded();//.net 2.0��������SetAdd()����,1.1��û�С�Ҫ����DataAdapterȥinsert�Ļ�.��Ҫȷ��������״̬��Added.
                    }
                }
                adp1.Update(dt);
            }
            catch { }
        }

        private void UpdateOrAddTable(string TableName, DataSet ds2, OleDbConnection toConnection)
        {
            OleDbDataAdapter adp1 = new OleDbDataAdapter("select * from " + TableName + "", toConnection);
            OleDbCommandBuilder Comm = new OleDbCommandBuilder(adp1);
            try
            {
                DataTable dt = ds2.Tables[0];
                adp1.Update(dt);
            }
            catch { }
        }

        private void AddMessage(string Msg)
        {
            SkinListBoxItem item = new SkinListBoxItem(Msg);

            listBox1.Items.Add(item);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            //Application.DoEvents();
        }
        private void ShowBarIndex()
        {
            if (pgb_Bar.Value <= pgb_Bar.Maximum - 1)
                pgb_Bar.Value += 1;
        }
        /// <summary>
        /// �ݹ��ȡ��db�ļ��м�
        /// </summary>
        /// <param name="IntoPath"></param>
        /// <param name="DBtempPath"></param>
        private void GetDBPath(string IntoPath, ref string DBtempPath)
        {
            if (chk_DBPath)
            {
                if (System.IO.Directory.Exists(IntoPath + "\\db"))
                {
                    chk_DBPath = false;
                    DBtempPath = IntoPath;
                    return;
                }
                DirectoryInfo IntoDirectory = new DirectoryInfo(IntoPath);
                foreach (DirectoryInfo into_temp in IntoDirectory.GetDirectories())
                {
                    GetDBPath(into_temp.FullName, ref DBtempPath);
                }
            }
        }
        #endregion

        private void frmExportProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button1.Enabled == false)
                e.Cancel = true;
            // this.Dispose();
        }
    }
}
        #endregion