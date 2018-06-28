using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
namespace ERM.Common
{
    /// <summary>
    /// 使用MangageMent名称空间win2000有问题
    /// </summary>
    public class PrinterOperate2
    {
        public const string UsePrinterName = "Digipower PDF Printer";//打印机名称
        /// <summary>
        /// 检查是否安装了PDF打印机
        /// </summary>
        /// <returns></returns>
        public static bool CheckPrinter()
        {
            string strSeacherPrinter = "Select * From Win32_Printer where Name='" + UsePrinterName + "'";
            System.Management.ManagementObjectSearcher seacherPrinter = new System.Management.ManagementObjectSearcher(strSeacherPrinter);
            System.Management.ManagementObjectCollection searchResult = seacherPrinter.Get();
            if (searchResult.Count == 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 获得当前默认打印机名
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultPrinterName()
        {
            System.Management.ManagementObjectSearcher query;
            System.Management.ManagementObjectCollection queryCollection;
            string _classname = "";
            _classname = "select * from Win32_Printer where default=true";
            query = new System.Management.ManagementObjectSearcher(_classname);
            queryCollection = query.Get();
            string _Name = "";
            foreach (System.Management.ManagementObject mo in queryCollection)
            {
                _Name = mo["Name"].ToString();
                break;
            }
            return _Name;
        }
        /// <summary>
        /// 设置 默认打印机
        /// </summary>
        /// <param name="PrinterName"></param>
        public static void SetPrinter(string PrinterName)
        {
            System.Management.ManagementObjectSearcher query;
            System.Management.ManagementObjectCollection queryCollection;
            string _classname = "";
            _classname = "SELECT * FROM Win32_Printer  where Name='" + PrinterName + "'";
            query = new System.Management.ManagementObjectSearcher(_classname);
            queryCollection = query.Get();
            foreach (System.Management.ManagementObject mo in queryCollection)
            {
                mo.InvokeMethod("SetDefaultPrinter", null);
                break;
            }
        }
    }
    public class PrinterOperate
    {
        public const string UsePrinterName = "Digipower PDF Printer";//打印机名称
        /// <summary>
        /// 检查是否安装了PDF打印机
        /// </summary>
        /// <returns></returns>
        public static bool CheckPrinter()
        {
            foreach (string str in PrinterSettings.InstalledPrinters)
            {
                if (string.Compare(UsePrinterName, str, true) == 0)
                {
                    return true;
                    break;
                }
            }
            return false;
        }
        /// <summary>
        /// 获得当前默认打印机名
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultPrinterName()
        {
            string str = "";
            PrintDocument doc = new PrintDocument();
            return doc.PrinterSettings.PrinterName;
        }
        /// <summary>
        /// 设置 默认打印机
        /// </summary>
        /// <param name="PrinterName"></param>
        public static void SetPrinter(string PrinterName)
        {
            SetDefaultPrinter(PrinterName);
        }
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool SetDefaultPrinter(string Name);
        public static List<string> GetPrinterList()
        {
            List<string> list = new List<string>();
            foreach (string str in PrinterSettings.InstalledPrinters)
            {
                list.Add(str);
            }
            return list;
        }
    }
}
