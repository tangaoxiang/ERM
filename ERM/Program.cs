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
        /// 应用程序的主入口点。
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
                TXMessageBoxExtensions.Info("程序已经运行！");
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
            //启动清空临时打印目录
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
            ///移交时生成的临时目录
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
             * 验证：
             * C7643B2A-EC98-4A8C-ACDD-1BF0A20F8C04：次数+天数
             * 99673744-DF8F-4001-83A9-8E77DF2D1EEB：时间
             * CC4526BE-800D-4EBC-BFE9-9D44C88ED7EE：次数
             **********************************************************************************************/
            //判断注册项表中的值
            //判断注册项表中的值
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
            //                TXMessageBoxExtensions.Info("提示：软件已过期 或 已过使用次数" + UseCount + "！ \n  【温馨提示：如有疑问请与我们联系，0755-83995038】");
            //                return;
            //            }
            //            else
            //            {
            //                if (Convert.ToInt32(UseCount) - Convert.ToInt32(UseCurCount) <= 10)
            //                {
            //                    TXMessageBoxExtensions.Info("提示：软件使用次数只剩：" + (Convert.ToInt32(UseCount) - Convert.ToInt32(UseCurCount)) + " 次！ \n  【温馨提示：如有疑问请与我们联系，0755-83995038】");
            //                }
            //                else if (Convert.ToInt32((Convert.ToDateTime(UseDay) - DateTime.Now).TotalDays) <= 10)
            //                {
            //                    TXMessageBoxExtensions.Info("提示：软件使用天数只剩：" + Convert.ToInt32((Convert.ToDateTime(UseDay) - DateTime.Now).TotalDays) + " 天！ \n  【温馨提示：如有疑问请与我们联系，0755-83995038】");
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
            //                TXMessageBoxExtensions.Info("提示：软件已过期 ！ \n  【温馨提示：如有疑问请与我们联系，0755-83995038】");
            //                return;
            //            }
            //            else
            //            {
            //                if (Convert.ToInt32((Convert.ToDateTime(UseDate) - DateTime.Now).TotalDays) <= 10)
            //                {
            //                    TXMessageBoxExtensions.Info("提示：软件使用天数只剩：" + Convert.ToInt32((Convert.ToDateTime(UseDate) - DateTime.Now).TotalDays) + " 天！ \n  【温馨提示：如有疑问请与我们联系，0755-83995038】");
            //                }
            //            }
            //        }
            //        else
            //        {
            //            string date_flg = configAction.Read("UseValue");
            //            string dataValue = rAction.Decrypt(date_flg, "digipowo");
            //            if (DateTime.Compare(Convert.ToDateTime(dataValue), DateTime.Now) < 0)
            //            {
            //                TXMessageBoxExtensions.Info("提示：软件已过期 ！ \n  【温馨提示：如有疑问请与我们联系，0755-83995038】");
            //                return;
            //            }
            //            rAction.WTRegedit("UseDate", dataValue);
            //        }
            //    }
            //    else if (configAction.Read("UseType") == "CC4526BE-800D-4EBC-BFE9-9D44C88ED7EE")
            //    {
            //        //次数 100次：tkHPYaX8TwI= 150次：GnDjrw+KlkA= 0次：MoYeGrkYqas=
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
            //            TXMessageBoxExtensions.Info("提示：软件已过期 ！ \n  【温馨提示：如有疑问请与我们联系，0755-83995038】");
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        TXMessageBoxExtensions.Info("注册信息读取失败！ \n     【温馨提示：如有疑问请与我们联系，0755-83995038】");
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    TXMessageBoxExtensions.Info("注册信息读取失败！ \n     【温馨提示：如有疑问请与我们联系，0755-83995038】");
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
            //catch (Exception ex) { MyCommon.WriteLog("注册插件失败：" + ex.Message); }

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
