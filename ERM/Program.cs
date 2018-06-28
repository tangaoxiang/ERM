using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using ERM;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    static class Program
    {
        /// <summary>
        /// Ӧ�ó��������ڵ㡣
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool bRun = true;
            Mutex m = new Mutex(true, Application.ProductName, out bRun);
            if (bRun)
                m.ReleaseMutex();
            else
            {
                TXMessageBoxExtensions.Info("�����Ѿ����У�");
                return;
            }
            if (!System.IO.Directory.Exists(Globals.ProjectPath))
            {
                System.IO.Directory.CreateDirectory(Globals.ProjectPath);
            }
            if (!System.IO.Directory.Exists(Globals.CellPath))
            {
                System.IO.Directory.CreateDirectory(Globals.CellPath);
            }
            if (!Globals.UpdateSettings() ||
                !System.IO.Directory.Exists(Globals.CellPath)
                || !System.IO.Directory.Exists(Globals.ProjectPath))
            {
                return;
            }
            //���������ʱ��ӡĿ¼
            #region
            System.Diagnostics.Process[] pro_Print = System.Diagnostics.Process.GetProcessesByName("JRPDFPrint");
            string tempFolder = string.Empty;
            if (pro_Print == null || pro_Print.Length == 0)
            {
                tempFolder =
                    System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "erm_print");
                if (System.IO.Directory.Exists(tempFolder))
                {
                    MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, false);
                    MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, true);
                }
                else
                    MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, true);
            }
            ///�ƽ�ʱ���ɵ���ʱĿ¼
            tempFolder = System.IO.Path.Combine(Application.StartupPath, "temp_YJ");
            if (System.IO.Directory.Exists(tempFolder))
            {
                MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, false);
                MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, true);
            }
            else
                MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, true);
            #endregion

            ReadWriteAppConfig config = new ReadWriteAppConfig();
            if (config.Read("Upload_ProjectSize") == "")
                config.Write("Upload_ProjectSize", "4");

            /**************************************************************************************************
             * ��֤��
             * C7643B2A-EC98-4A8C-ACDD-1BF0A20F8C04������+����
             * 99673744-DF8F-4001-83A9-8E77DF2D1EEB��ʱ��
             * CC4526BE-800D-4EBC-BFE9-9D44C88ED7EE������
             **********************************************************************************************/
            //�ж�ע������е�ֵ
            //�ж�ע������е�ֵ
            //try
            //{
            //    RegistAction rAction = new RegistAction();
            //    ReadWriteAppConfig configAction = new ReadWriteAppConfig();
            //    if (configAction.Read("UseType") == "C7643B2A-EC98-4A8C-ACDD-1BF0A20F8C04")
            //    {
            //        if (rAction.IsRegeditExit("UseCount"))
            //        {
            //            string UseCount = rAction.GetRegistData("UseCount");
            //            string UseCurCount = rAction.GetRegistData("UseCurCount");
            //            string UseDay = rAction.GetRegistData("UseDay");
            //            if (Convert.ToInt32(UseCount) <= Convert.ToInt32(UseCurCount) ||
            //                DateTime.Now >= Convert.ToDateTime(UseDay))
            //            {
            //                TXMessageBoxExtensions.Info("��ʾ������ѹ��� �� �ѹ�ʹ�ô���" + UseCount + "�� \n  ����ܰ��ʾ��������������������ϵ��0755-83995038��");
            //                return;
            //            }
            //            else
            //            {
            //                if (Convert.ToInt32(UseCount) - Convert.ToInt32(UseCurCount) <= 10)
            //                {
            //                    TXMessageBoxExtensions.Info("��ʾ�����ʹ�ô���ֻʣ��" + (Convert.ToInt32(UseCount) - Convert.ToInt32(UseCurCount)) + " �Σ� \n  ����ܰ��ʾ��������������������ϵ��0755-83995038��");
            //                }
            //                else if (Convert.ToInt32((Convert.ToDateTime(UseDay) - DateTime.Now).TotalDays) <= 10)
            //                {
            //                    TXMessageBoxExtensions.Info("��ʾ�����ʹ������ֻʣ��" + Convert.ToInt32((Convert.ToDateTime(UseDay) - DateTime.Now).TotalDays) + " �죡 \n  ����ܰ��ʾ��������������������ϵ��0755-83995038��");
            //                }
            //                rAction.WTRegedit("UseCurCount", (Convert.ToInt32(UseCurCount) + 1).ToString());
            //            }
            //        }
            //        else
            //        {
            //            rAction.WTRegedit("UseCount", configAction.Read("UseCount"));
            //            rAction.WTRegedit("UseCurCount", "1");
            //            rAction.WTRegedit("UseDay", DateTime.Now.AddDays(Convert.ToDouble(configAction.Read("UseDay"))).ToString("yyyy-MM-dd hh:mm:ss"));
            //        }
            //    }
            //    else if (configAction.Read("UseType") == "99673744-DF8F-4001-83A9-8E77DF2D1EEB")
            //    {
            //        if (rAction.IsRegeditExit("UseDate"))
            //        {
            //            string UseDate = rAction.GetRegistData("UseDate");
            //            if (DateTime.Compare(Convert.ToDateTime(UseDate), DateTime.Now) < 0)
            //            {
            //                TXMessageBoxExtensions.Info("��ʾ������ѹ��� �� \n  ����ܰ��ʾ��������������������ϵ��0755-83995038��");
            //                return;
            //            }
            //            else
            //            {
            //                if (Convert.ToInt32((Convert.ToDateTime(UseDate) - DateTime.Now).TotalDays) <= 10)
            //                {
            //                    TXMessageBoxExtensions.Info("��ʾ�����ʹ������ֻʣ��" + Convert.ToInt32((Convert.ToDateTime(UseDate) - DateTime.Now).TotalDays) + " �죡 \n  ����ܰ��ʾ��������������������ϵ��0755-83995038��");
            //                }
            //            }
            //        }
            //        else
            //        {
            //            string date_flg = configAction.Read("UseValue");
            //            string dataValue = rAction.Decrypt(date_flg, "digipowo");
            //            if (DateTime.Compare(Convert.ToDateTime(dataValue), DateTime.Now) < 0)
            //            {
            //                TXMessageBoxExtensions.Info("��ʾ������ѹ��� �� \n  ����ܰ��ʾ��������������������ϵ��0755-83995038��");
            //                return;
            //            }
            //            rAction.WTRegedit("UseDate", dataValue);
            //        }
            //    }
            //    else if (configAction.Read("UseType") == "CC4526BE-800D-4EBC-BFE9-9D44C88ED7EE")
            //    {
            //        //���� 100�Σ�tkHPYaX8TwI= 150�Σ�GnDjrw+KlkA= 0�Σ�MoYeGrkYqas=
            //        //string temp = rAction.Decrypt("lrfJqKfPr2I=", "digipowo");
            //        string UseCount = configAction.Read("UseCount");
            //        string UseCurCount = configAction.Read("UseCurCount");
            //        UseCount = rAction.Decrypt(UseCount, "digipowo");
            //        UseCurCount = rAction.Decrypt(UseCurCount, "digipowo");

            //        if (Convert.ToInt32(UseCurCount) < Convert.ToInt32(UseCount))
            //        {
            //            configAction.Write("UseCurCount", rAction.Encrypt((Convert.ToInt32(UseCurCount) + 1).ToString(), "digipowo"));
            //        }
            //        else
            //        {
            //            TXMessageBoxExtensions.Info("��ʾ������ѹ��� �� \n  ����ܰ��ʾ��������������������ϵ��0755-83995038��");
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        TXMessageBoxExtensions.Info("ע����Ϣ��ȡʧ�ܣ� \n     ����ܰ��ʾ��������������������ϵ��0755-83995038��");
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    TXMessageBoxExtensions.Info("ע����Ϣ��ȡʧ�ܣ� \n     ����ܰ��ʾ��������������������ϵ��0755-83995038��");
            //    return;
            //}

            //string system32Path = Environment.GetFolderPath(Environment.SpecialFolder.System);//"C:\\Windows\\system32"
            //try
            //{
            //    if (!System.IO.File.Exists(system32Path + "\\CellCtrl5.ocx"))
            //    {
            //        System.IO.File.Copy(Application.StartupPath + "\\SystemFiles\\CellCtrl5.ocx", system32Path + "\\CellCtrl5.ocx", true);
            //    }
            //}
            //catch (Exception ex) { MyCommon.WriteLog("ע����ʧ�ܣ�" + ex.Message); }

            frmLogin frm = new frmLogin();
            DialogResult ret = frm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                Application.Run(new frmMDIMain());
            }
            else
            {
                Application.Exit();
            }

        }
    }
}
