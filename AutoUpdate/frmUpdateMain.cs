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
        ////�����ļ�
        ////��������ַ
        ////������ʱ��
        ////�汾
        ////�����ļ���ŵ���ʱ·��
        ////��Ҫ���µ��ļ��б�
        ////��Ӧ�ó�����
        ////������ɺ��Ƿ�������Ӧ�ó���,"yes"��ʾҪ����
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
                    //ǰ�����ع���w1.DownloadFile("http://gti2000.vicp.net:8003/ERM_LangFang_Version.txt", versionFile);
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                    string oldVersino = assembly.GetName().Version.ToString();
                    if (System.IO.File.Exists(versionFile))
                    {
                        string strL1 = System.IO.File.ReadAllText(versionFile, Encoding.GetEncoding("gb2312"));
                        string[] strL2 = strL1.Split(';');
                        if (strL2.Length > 1)
                        {
                            string newVersion = strL2[0];
                            lblTitle.Text = "����������" + newVersion + "�汾";
                            progressBar2.Maximum = (strL2.Length - 1) * 2;//���ļ�����
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
                            lblMsg.Text = "������......";
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
                            lblMsg.Text = "������ɣ�";
                            if (TXMessageBoxExtensions.Question("�������,���������������ļ��鵵ϵͳ������������") == DialogResult.OK)
                            {
                                System.Diagnostics.Process.Start(Application.StartupPath + "\\ERM2.0.exe");
                            }
                            this.Close();
                        }
                    }
                    else
                    {
                       TXMessageBoxExtensions.Info("����ʧ�ܣ�");
                        this.Close();
                    }
                }
            }
            catch
            {
                 TXMessageBoxExtensions.Info("����ʧ�ܣ�");
                this.Close();
            }
            ////��ȡ���������ļ���Ϣ
            ////���ط������ϵ������ļ���������ʱĿ¼
            ////��ȡ�����������ļ�
            ////����Ƿ����°汾��������
            ////�ر�ִ�г���
            ////��ʼ��������Ϣ
            ////�����ļ�
            ////���������ļ���ɾ����ʱĿ¼
            ////�رգ�����������
        }

        /// <summary>
        /// ������ɾ��Ŀ¼
        /// </summary>
        /// <param name="BackupPath">Ŀ¼·��</param>
        /// <param name="bCreate">bool: true���� falseɾ��</param>
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
        /// ��ȡ�ļ�����
        /// </summary>
        /// <param name="sourceDirName">�ļ���·��</param>
        /// <param name="check_flg">�����״ֵ̬�� ����false ��ʾ�ļ����д��� </param>
        /// <param name="fileCount">�ļ�����</param>
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
                     TXMessageBoxExtensions.Info("��ʾ���ļ���·������'" + sourceDirName + "' \n ����ܰ��ʾ���ļ�·�������ڻ��ļ���β�����ܰ��������ַ���ȫ���ַ� ���磺�ո�,�Ǻ�...��");
                }
            }
        }

        ////��ȡ���������ļ���Ϣ
        ////�����������,���ظ��������ļ�
        ////��ȡ�����������ļ�
        ////����Ƿ����°汾��������
        ////����Ŀ¼
        ///// <summary>
        ///// ���ظ����ļ�
        ///// </summary>
        ///// <param name="updateFile">����������Ҫ���ص��ļ�</param>
        ///// <param name="path">����·��</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
