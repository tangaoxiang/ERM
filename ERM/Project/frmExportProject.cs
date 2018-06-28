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
    /// 工程信息操作 备份，恢复，导入
    /// </summary>
    public partial class frmExportProject : ERM.UI.Controls.Skin_DevEX
    {
        #region 参数初始化
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

        #region 窗体函数
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
        /// 备份
        /// </summary>
        /// <param name="setText">Label赋值委托实例</param>
        /// <param name="addMsg"></param>
        /// <param name="showBar">Bar显示进度委托实例</param>
        /// <param name="setBar">进度条赋值委托</param>
        /// <param name="enable">是否禁用</param>
        /// <param name="close">关闭窗体委托</param>
        /// <param name="t">线程实例</param>
        private void Backup(setText setText, addMessage addMsg, showBar showBar, setBar setBar, setEanble enable, closeWin close, Thread t)
        {
            #region 备份
            string FileName = strFileName.Text;
            FileInfo finfo = new FileInfo(FileName);
            string FilePath = finfo.DirectoryName;
            pgb_Bar.BeginInvoke(setBar, new object[] { 0 });
            lbl_BarText.BeginInvoke(setText, new object[] { "", this.lbl_BarText });
            lock (m_monitorObject)
            {
                lbl_BarText.BeginInvoke(setText, new object[] { "正在准备备份...", this.lbl_BarText });
                listBox1.BeginInvoke(addMsg, new object[] { "正在准备备份..." });
            }
            try
            {
                double projectSize = Convert.ToDouble(DirectoryInfoCommon.GetDirectorySpace(Application.StartupPath + "\\Project\\" + ProjectNO) / Convert.ToDouble(1024 * 1024 * 1024));
                if (MyCommon.CheckDisk(FilePath) < projectSize * 2)
                {
                    //硬盘空间不足
                    TXMessageBoxExtensions.Info("备份工程需要硬盘大小为：" + System.Math.Round(projectSize * 2, 2) + "G 保存目录硬盘空间不足,无法备份！ \r\n 【温馨提示：请选择保存到比较空闲的盘符】");

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
                    lbl_BarText.BeginInvoke(setText, new object[] { "正在数据库备份...", this.lbl_BarText });
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
                    lbl_BarText.BeginInvoke(setText, new object[] { "正在备份文件...", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "数据库备份成功..." });
                    listBox1.BeginInvoke(addMsg, new object[] { "正在准备文件..." });
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
                                    lbl_BarText.BeginInvoke(setText, new object[] { "正在备份文件：...\\" + finfo2.Name, this.lbl_BarText });
                                    this.pgb_Bar.BeginInvoke(showBar, new object[] { });
                                    listBox1.BeginInvoke(addMsg, new object[] { "成功备份文件：" + f1 });
                                }
                            }
                        }
                    }
                }
                lbl_BarText.BeginInvoke(setText, new object[] { "正在压缩备份信息,请稍候...", this.lbl_BarText });
                this.pgb_Bar.BeginInvoke(setBar, new object[] { pgb_Bar.Maximum / 2 });

                SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
                SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
                tmp.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                tmp.CompressDirectory(FilePath + "\\" + ProjectNO + "\\", FileName);

                ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNO + "\\", false);//这里不用创建
                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "备份完成！", this.lbl_BarText });
                }
                this.pgb_Bar.BeginInvoke(setBar, 100);
                TXMessageBoxExtensions.Info("提示：备份完成！");


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
                TXMessageBoxExtensions.Info("提示：备份失败！\r\n"+e.Message.ToString());
                ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNO + "\\", false);
                this.BeginInvoke(close, new object[] { });
                t.Abort();

            }
            t.Abort();
            #endregion
        }

        /// <summary>
        /// 恢复工程
        /// </summary>
        /// <param name="setText">文本显示委托</param>
        /// <param name="addMsg">文件信息设置</param>
        /// <param name="showBar">进度条显示</param>
        /// <param name="setBar">进度条设置值的委托</param>
        /// <param name="enable">操作按钮启用或禁用设置委托</param>
        /// <param name="close">关闭窗体委托</param>
        /// <param name="t">多线程对象</param>
        private void Restore(setText setText, addMessage addMsg, showBar showBar, setBar setBar, setEanble enable, closeWin close, Thread t)
        {
            #region 恢复
            string FileName = strFileName.Text;
            FileInfo finfo = new FileInfo(FileName);
            string FilePath = finfo.DirectoryName;

            this.pgb_Bar.BeginInvoke(setBar, new object[] { 0 });
            lbl_BarText.BeginInvoke(setText, new object[] { "", this.lbl_BarText });
            bool showLastMessage_flg = true;
            lock (m_monitorObject)
            {
                lbl_BarText.BeginInvoke(setText, new object[] { "正在准备恢复...", this.lbl_BarText });
                listBox1.BeginInvoke(addMsg, new object[] { "正在准备恢复..." });
            }
            string ProjectNOFolder = "tempProjectFolder";
            ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNOFolder + "\\", false);
            ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(FilePath + "\\" + ProjectNOFolder + "\\");
            try
            {
                double projectSize = Convert.ToDouble(DirectoryInfoCommon.FileSpace(FileName) / Convert.ToDouble(1024 * 1024 * 1024));
                if (MyCommon.CheckDisk(FilePath) < projectSize * 2)
                {
                    //硬盘空间不足
                    TXMessageBoxExtensions.Info("恢复工程需要硬盘大小为：" + System.Math.Round(projectSize * 2, 2) + "G 当前备份文件的目录硬盘空间不足,无法恢复！ \r\n 【温馨提示：请将备份文件拷贝到比较空闲的盘符】");
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
                        lbl_BarText.BeginInvoke(setText, new object[] { "正在解压文件：" + tmp.ArchiveFileData[i].FileName, this.lbl_BarText });
                    }
                }
                System.Threading.Thread.Sleep(1000);

                int barCount = 7;
                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "正在解压恢复文件...", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "正在解压恢复文件..." });
                }
                //z1.StartUnZip();
                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "正在恢复数据信息...", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "在恢复数据信息..." });
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
                        //统计状态栏信息
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
                            if (TXMessageBoxExtensions.Question("提示：存在相同的工程编号【" + FromProjectNO + "】,是否继续恢复？\n【温馨提示：存在相同的工程编号时，如果继续恢复，会将工程相同的记录更新成恢复文件中工程的信息】") != DialogResult.OK)
                            {
                                isGo_flag = false;
                            }
                        }
                        if (isGo_flag)
                        {
                            lbl_BarText.BeginInvoke(setText, new object[] { "正在恢复工程信息...", this.lbl_BarText });
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

                            #region 文件级恢复
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

                            #region 案卷级恢复
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

                            #region 电子文件级
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

                            #region 工程单位
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

                            #region 归档目录级
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

                            #region 坐标恢复
                            Restore_Items(conn, conn2, FromProjectNO, "T_Point", "ProjectNo", showBar);
                            #endregion

                            #region 桥梁工程恢复
                            Restore_Items(conn, conn2, FromProjectNO, "T_Project_Brige", "ProjectID", showBar);
                            #endregion

                            #region 路灯工程恢复
                            Restore_Items(conn, conn2, FromProjectNO, "T_Project_RoadLamp", "ProjectID", showBar);
                            #endregion

                            #region 交通工程恢复
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
                        TXMessageBoxExtensions.Info("提示：导入包有误，请确认导入包信息是否正确！");
                        showLastMessage_flg = false;
                    }
                    conn.Close();
                    conn2.Close();
                    Thread.Sleep(1000);
                    if (showLastMessage_flg)
                    {
                        lock (m_monitorObject)
                        {
                            lbl_BarText.BeginInvoke(setText, new object[] { "正在准备恢复文件：...", this.lbl_BarText });
                            listBox1.BeginInvoke(addMsg, new object[] { "数据库恢复成功..." });
                            listBox1.BeginInvoke(addMsg, new object[] { "正在准备恢复文件..." });
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
                                            lbl_BarText.BeginInvoke(setText, new object[] { "正在恢复文件：...\\" + finfo2.Name, this.lbl_BarText });
                                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });
                                            listBox1.BeginInvoke(addMsg, new object[] { "成功恢复文件：" + f1 });
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
                    TXMessageBoxExtensions.Info("提示：导入包有误，请确认导入包信息是否正确！");
                    showLastMessage_flg = false;
                    pgb_Bar.BeginInvoke(setBar, new object[] { barCount });
                }

                Thread.Sleep(1000);
                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "恢复完成！", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "恢复完成！" });
                }

                if (showLastMessage_flg && TXMessageBoxExtensions.Question("提示：恢复完成！ 是否继续恢复？") != DialogResult.OK)
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
                TXMessageBoxExtensions.Info("提示：恢复失败！\n" + ex.Message.ToString());
                MyCommon.WriteLog("恢复失败：" + ex.Message);
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
            #region 导入
            string FileName = strFileName.Text;
            FileInfo finfo = new FileInfo(FileName);
            string FilePath = finfo.DirectoryName;

            pgb_Bar.BeginInvoke(setBar, new object[] { 0 });
            lbl_BarText.BeginInvoke(setText, new object[] { "", this.lbl_BarText });
            bool showLastMessage_flg = true;
            lock (m_monitorObject)
            {
                lbl_BarText.BeginInvoke(setText, new object[] { "正在准备导入...", this.lbl_BarText });
                listBox1.BeginInvoke(addMsg, new object[] { "正在准备导入..." });
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
                    lbl_BarText.BeginInvoke(setText, new object[] { "正在解压导入文件...", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "正在解压导入文件..." });
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
                    lbl_BarText.BeginInvoke(setText, new object[] { "正在连接数据...", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "正在连接数据..." });
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
                            //存在相同的工程编号 直接跳过
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
                            //没有相同的工程编号
                            lbl_BarText.BeginInvoke(setText, new object[] { "正在导入工程信息...", this.lbl_BarText });

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
                            lbl_BarText.BeginInvoke(setText, new object[] { "正在导入文件信息...\\", this.lbl_BarText });

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
                            lbl_BarText.BeginInvoke(setText, new object[] { "正在导入电子文件信息...", this.lbl_BarText });

                            this.pgb_Bar.BeginInvoke(showBar, new object[] { });

                            UpdateOrAddTable(bExist, "T_CellAndEFile", conn2, conn);


                            #region add Import
                            #region import brige
                            Import(conn, comm1, conn2, ref strSql, FromProjectNO, ref bExist, "T_Project_Brige", "桥梁");
                            #endregion

                            #region import roadLamp
                            Import(conn, comm1, conn2, ref strSql, FromProjectNO, ref bExist, "T_Project_RoadLamp", "路灯");
                            #endregion

                            #region Traffic
                            Import(conn, comm1, conn2, ref strSql, FromProjectNO, ref bExist, "T_Traffic", "交通");
                            #endregion

                            #region Point
                            Import(conn,comm1,conn2,ref strSql,FromProjectNO,ref bExist,"T_Point","坐标");
                            #endregion

                            #endregion
                        }
                        else
                        {
                            TXMessageBoxExtensions.Info("提示：不允许导入相同编号的工程！");
                            showLastMessage_flg = false;
                        }
                    }
                    else
                    {
                        TXMessageBoxExtensions.Info("提示：导入包有误，请确认导入包信息是否正确！");
                        showLastMessage_flg = false;
                    }
                    conn.Close();
                    conn2.Close();
                    Thread.Sleep(1000);
                    lock (m_monitorObject)
                    {
                        if (showLastMessage_flg)
                        {
                            listBox1.BeginInvoke(addMsg, new object[] { "数据库导入成功..." });
                            listBox1.BeginInvoke(addMsg, new object[] { "正在准备恢复文件..." });
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
                    TXMessageBoxExtensions.Info("提示：导入包有误，请确认导入包信息是否正确！");
                    showLastMessage_flg = false;
                }
                pgb_Bar.BeginInvoke(setBar, new object[] { pgb_Bar.Maximum });
                Thread.Sleep(1000);
                lock (m_monitorObject)
                {
                    lbl_BarText.BeginInvoke(setText, new object[] { "导入完成！", this.lbl_BarText });
                    listBox1.BeginInvoke(addMsg, new object[] { "导入完成！" });
                }
                if (showLastMessage_flg && TXMessageBoxExtensions.Question("提示：导入完成！ 是否继续导入？") != DialogResult.OK)
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
                TXMessageBoxExtensions.Info("提示：导入失败！");
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

            lbl_BarText.Text = "正在导入" + projectName + "工程信息...\\";
            ShowBarIndex();

            UpdateOrAddTable(bExist, tableName, conn2, conn);

        }
        private void frmExportProject_Load(object sender, EventArgs e)
        {
            this.Text = OpType;
            lbl_BarText.Text = "";
            if (OpType == "备份")
            {
                button3.Text = "选择目录";
                this.Text = "备份：" + ProjectName;
            }
            tabControl1.TabPages[0].Text = OpType;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {

            #region 赋值委托
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

                if (OpType == "备份")
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
                else if (OpType == "恢复")
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
                else if (OpType == "导入")
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
                if (OpType == "备份")
                    message = "备份";
                else if (OpType == "恢复")
                    message = "恢复";
                else if (OpType == "导入")
                    message = "导入";
                MyCommon.WriteLog(message + "错误：" + ex.Message);
                TXMessageBoxExtensions.Info("提示：" + message + "失败！");

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

                if (OpType == "备份")
                {
                    saveFileDialog1.Filter = "工程备份(*.bak)|*.bak";

                    saveFileDialog1.FileName = ProjectName + ".bak";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        strFileName.Text = saveFileDialog1.FileName;
                    }
                }
                else if (OpType == "恢复")
                {
                    openFileDialog1.Filter = "工程恢复(*.bak)|*.bak";
                    openFileDialog1.FileName = "";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        strFileName.Text = openFileDialog1.FileName;
                    }
                }
                else if (OpType == "导入")
                {
                    openFileDialog1.Filter = "工程导入(*.dbbak)|*.dbbak";
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
                if (OpType == "备份")
                    message = "备份";
                else if (OpType == "恢复")
                    message = "恢复";
                else if (OpType == "导入")
                    message = "导入";
                TXMessageBoxExtensions.Info("提示：" + message + "失败！");
            }
        }
            #endregion

        #region 自定义函数
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
                        dr.SetAdded();//.net 2.0中新增的SetAdd()方法,1.1中没有。要是用DataAdapter去insert的话.就要确保他的行状态是Added.
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
        /// 递归获取到db文件夹级
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