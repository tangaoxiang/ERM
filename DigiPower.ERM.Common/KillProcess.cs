using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace ERM.Common
{
    public class KillProcess 
    {
        /// <summary>
        /// 关闭 AcroRd32
        /// </summary>
        public static bool KillProAcroRd32()
        {
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            try
            {
                foreach (Process thisproc in Process.GetProcessesByName("AcroRd32"))
                {
                    if (!thisproc.CloseMainWindow())
                    {
                        thisproc.Kill();
                    }
                }
                return true;
            }
            catch (Exception Exc)
            {
                return false;
            }
        }
        /// <summary>
        /// 杀死特定的进程
        /// </summary>
        /// <returns></returns>
        public static void GetProcessID(string TargetProcessName, int ParentProcessID)
        {
            string strGetProcessID = "Select ProcessID,Name From Win32_Process where ParentProcessID=" + ParentProcessID +"  and name='" + TargetProcessName + "'";
            System.Management.ManagementObjectSearcher seacherPrinter = new System.Management.ManagementObjectSearcher(strGetProcessID);
            System.Management.ManagementObjectCollection searchResult = seacherPrinter.Get();
            foreach (System.Management.ManagementObject mo in searchResult)
            {
                int processID= Convert.ToInt32( mo["ProcessID"]);
                System.Diagnostics.Process.GetProcessById(processID).Kill();
            }
        }
    }
}
