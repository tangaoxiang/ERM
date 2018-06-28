using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Net;
using System.Collections;
using System.Diagnostics;
using TX.Framework.WindowUI.Forms;
namespace AutoUpdate
{
    public partial class frmUpdateMain : Form
    {
        ////配置文件
        ////服务器地址
        ////最后更新时间
        ////版本
        ////更新文件存放的临时路径
        ////需要更新的文件列表
        ////主应用程序名
        ////更新完成后是否启动主应用程序,"yes"表示要重启
        public frmUpdateMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            tmrStart.Enabled = true;
        }
        private void tmrStart_Tick(object sender, EventArgs e)
        {
            tmrStart.Enabled = false;
            string versionFile = Application.StartupPath + "\\ERM_LangFang_Version.txt";
            try
            {
                foreach (System.Diagnostics.Process ERMpro in
                                        System.Diagnostics.Process.GetProcessesByName("ERM2.0"))
                {
                    ERMpro.Kill();
                }

                using (System.Net.WebClient w1 = new System.Net.WebClient())
                {
                    w1.DownloadFile("http://www.digipower.cn/ERMUpdate/ERM_LangFang_Version.txt", versionFile);
                    //前面下载过了w1.DownloadFile("http://gti2000.vicp.net:8003/ERM_LangFang_Version.txt", versionFile);
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                    string oldVersino = assembly.GetName().Version.ToString();
                    if (System.IO.File.Exists(versionFile))
                    {
                        string strL1 = System.IO.File.ReadAllText(versionFile, Encoding.GetEncoding("gb2312"));
                        string[] strL2 = strL1.Split(';');
                        if (strL2.Length > 1)
                        {
                            string newVersion = strL2[0];
                            lblTitle.Text = "正在升到到" + newVersion + "版本";
                            progressBar2.Maximum = (strL2.Length - 1) * 2;//用文件数量
                            Application.DoEvents();
                            string tempPath = Application.StartupPath + "\\temp\\";
                            if (System.IO.Directory.Exists(tempPath))
                            {
                                //string[] files = System.IO.Directory.GetFiles(tempPath);
                                //foreach (string f1 in files)
                                //{
                                //    System.IO.File.Delete(f1);
                                //}
                                DeleteAndCreateEmptyDirectory(tempPath, false);
                                DeleteAndCreateEmptyDirectory(tempPath, true);
                            }
                            else
                            {
                                DeleteAndCreateEmptyDirectory(tempPath, true);
                            }
                            ArrayList newFileList = new ArrayList();
                            StringBuilder filepath = new StringBuilder();
                            StringBuilder dirPath = new StringBuilder();
                            for (int i1 = 1; i1 < strL2.Length - 1; i1++)
                            {
                                try
                                {
                                    string strNewFileWeb = strL2[i1];
                                    //int iPos1 = strNewFileWeb.LastIndexOf('/');
                                    //int iPos1 = strNewFileWeb.IndexOf("8003/");
                                    int iPos1 = strNewFileWeb.IndexOf("ERMUpdate/");
                                    if (iPos1 > 0)
                                    {
                                        //string NewFileLocal = strNewFileWeb.Substring(iPos1 + 1);
                                        //string NewFileLocal = strNewFileWeb.Substring(iPos1 + 5);
                                        string NewFileLocal = strNewFileWeb.Substring(iPos1 + 10);
                                        dirPath.Remove(0, dirPath.Length);
                                        filepath.Remove(0, filepath.Length);
                                        if (NewFileLocal.IndexOf('/') != -1)
                                        {
                                            string[] directoryList = NewFileLocal.Split(new char[] { '/' });
                                            for (int d = 0; d < directoryList.Length; d++)
                                            {
                                                if (d < directoryList.Length - 1)
                                                    dirPath.Append("\\" + directoryList[d]);
                                                filepath.Append("\\" + directoryList[d]);
                                            }

                                            if (!System.IO.Directory.Exists(tempPath + dirPath.ToString()))
                                                DeleteAndCreateEmptyDirectory(tempPath + dirPath.ToString(), true);
                                            if (!System.IO.Directory.Exists(Application.StartupPath + dirPath.ToString()))
                                                DeleteAndCreateEmptyDirectory(Application.StartupPath + dirPath.ToString(), true);
                                        }
                                        else
                                        {
                                            filepath.Append(NewFileLocal);
                                        }
                                        //newFileList.Add(NewFileLocal);
                                        newFileList.Add(filepath.ToString());

                                        w1.DownloadFile(strNewFileWeb, tempPath + filepath.ToString());

                                        if (progressBar2.Maximum > progressBar2.Value)
                                            progressBar2.Value++;
                                        Application.DoEvents();
                                    }
                                }
                                catch
                                {
                                    if (progressBar2.Maximum > progressBar2.Value)
                                        progressBar2.Value++;
                                    Application.DoEvents();
                                }
                            }
                            btnCancel.Enabled = false;
                            lblMsg.Text = "升级中......";
                            Application.DoEvents();
                            foreach (string tempFile in newFileList)
                            {
                                try
                                {
                                    if (System.IO.File.Exists(Application.StartupPath + "\\" + tempFile))
                                    {
                                        System.IO.File.Delete(Application.StartupPath + "\\" + tempFile);
                                    }
                                    if (System.IO.File.Exists(tempPath + tempFile))
                                        System.IO.File.Move(tempPath + tempFile, Application.StartupPath + "\\" + tempFile);
                                    if (progressBar2.Maximum > progressBar2.Value)
                                        progressBar2.Value++;
                                    Application.DoEvents();
                                }
                                catch
                                {
                                    if (progressBar2.Maximum > progressBar2.Value)
                                        progressBar2.Value++;
                                    Application.DoEvents();
                                }
                            }
                            lblMsg.Text = "升级完成！";
                            if (TXMessageBoxExtensions.Question("更新完成,请重新启动电子文件归档系统，现在启动吗？") == DialogResult.OK)
                            {
                                System.Diagnostics.Process.Start(Application.StartupPath + "\\ERM2.0.exe");
                            }
                            this.Close();
                        }
                    }
                    else
                    {
                       TXMessageBoxExtensions.Info("更新失败！");
                        this.Close();
                    }
                }
            }
            catch
            {
                 TXMessageBoxExtensions.Info("更新失败！");
                this.Close();
            }
            ////读取本地配置文件信息
            ////下载服务器上的配置文件到本地临时目录
            ////读取服务器配置文件
            ////检查是否有新版本可以下载
            ////关闭执行程序
            ////初始化下载信息
            ////下载文件
            ////更新配置文件，删除临时目录
            ////关闭，重启主程序
        }

        /// <summary>
        /// 创建与删除目录
        /// </summary>
        /// <param name="BackupPath">目录路径</param>
        /// <param name="bCreate">bool: true创建 false删除</param>
        public void DeleteAndCreateEmptyDirectory(string BackupPath, bool bCreate)
        {
            if (bCreate == true)
            {
                if (!Directory.Exists(BackupPath))
                    Directory.CreateDirectory(BackupPath);
            }
            else
            {
                foreach (string f1 in System.IO.Directory.GetFiles(BackupPath))
                {
                    try
                    {
                        System.IO.File.Delete(f1);
                    }
                    catch { }
                }
                try
                {
                    Directory.Delete(BackupPath, true);
                    if (bCreate == true)
                    {
                        Directory.CreateDirectory(BackupPath);
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// 获取文件总数
        /// </summary>
        /// <param name="sourceDirName">文件夹路径</param>
        /// <param name="check_flg">传入的状态值， 返回false 表示文件夹有错误 </param>
        /// <param name="fileCount">文件总数</param>
        public void GetFileCount(string sourceDirName, ref bool check_flg, ref int fileCount)
        {
            if (check_flg)
            {
                if (System.IO.Directory.Exists(sourceDirName))
                {
                    string[] files = Directory.GetFiles(sourceDirName);
                    if (files != null && files.Length > 0)
                    {
                        fileCount += files.Length;
                    }
                    string[] dirs = Directory.GetDirectories(sourceDirName);
                    foreach (string dir in dirs)
                    {
                        GetFileCount(dir, ref check_flg, ref fileCount);
                    }
                }
                else
                {
                    check_flg = false;
                    fileCount = 0;
                     TXMessageBoxExtensions.Info("提示：文件夹路径错误：'" + sourceDirName + "' \n 【温馨提示：文件路径不存在或文件夹尾部可能包含特殊字符或全角字符 例如：空格,星号...】");
                }
            }
        }

        ////读取本地配置文件信息
        ////与服务器连接,下载更新配置文件
        ////读取服务器配置文件
        ////检查是否有新版本可以下载
        ////创建目录
        ///// <summary>
        ///// 下载更新文件
        ///// </summary>
        ///// <param name="updateFile">服务器上需要下载的文件</param>
        ///// <param name="path">本地路径</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
