using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Management;
using System.Security.Cryptography;
using System.IO;
namespace Digipower.OperatorRegedit
{
    public class OperatorRegedit
    {
        Byte[] key = { 11, 21, 35, 47, 52, 64, 73, 86 };
        Byte[] iv = { 121, 231, 12, 5, 17, 25, 34, 46 };
        public OperatorRegedit()
        { }
        /// <summary>
        /// 添加使用期限
        /// </summary>
        /// <param name="Period">使用期限</param>
        private void AddPeriod(string Period)
        {
            if (!String.IsNullOrEmpty(Period))
            {
                string First = Period.Substring(Period.Length - 4, 1);
                string Second = Period.Substring(Period.Length - 3, 1);
                int month = Convert.ToInt32(ItemCryptoDe(First) + ItemCryptoDe(Second));
                string result = null;
                result = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddMonths(month).ToShortDateString();
                AddRegedit(result, "qwbcd");
            }
        }
        /// <summary>
        /// 添加安装时间
        /// </summary>
        /// <param name="RegistTime">安装时间</param>
        private RegistryKey AddRegistTime()
        {
            return AddRegedit(DateTime.Now.ToString(), "bfdefd");
        }
        /// <summary>
        /// 添加最后使用时间
        /// </summary>
        /// <param name="RegistTime">安装时间</param>
        private RegistryKey AddLastTime()
        {
            return AddRegedit(DateTime.Now.ToString(), "jkdsgd");
        }
        /// <summary>
        /// 添加注册码
        /// </summary>
        /// <param name="ID">注册码</param>
        private RegistryKey AddDigipowerID(string CpuID)
        {
            return AddRegedit(CpuID, "ewrcv");
        }
        /// <summary>
        /// 添加注册表项
        /// </summary>
        /// <param name="objName">值</param>
        /// <param name="RegeditName">名称</param>
        /// <returns>操作项</returns>
        private RegistryKey AddRegedit(string objName, string objRegedit)
        {
            RegistryKey pregkey;
            pregkey = AddDigipower();
            RegistryKey RegeditName = pregkey.OpenSubKey(objRegedit, true);
            if (RegeditName == null)
            {
                RegeditName = pregkey.CreateSubKey(objRegedit);
            }
            RegeditName.SetValue(objRegedit, MyDESCrypto(objName));
            return RegeditName;
        }
        /// <summary>
        /// 添加最上级目录
        /// </summary>
        /// <returns></returns>
        private RegistryKey AddDigipower()
        {
            RegistryKey pregkey;
            pregkey = Registry.CurrentUser.OpenSubKey("Consele", true);
            if (pregkey == null)
            {
                pregkey = Registry.CurrentUser.CreateSubKey("Consele");
            }
            return pregkey;
        }
        /// <summary>
        /// 对比CpuID
        /// </summary>
        /// <param name="CpuID">CPUID</param>
        /// <returns>相等返回true</returns>
        private bool GetCpuID()
        {
            return ContrastRegedit(GetCpuNum(), "CpuID");
        }
        /// <summary>
        /// 获取注册时间
        /// </summary>
        /// <param name="DeleteRegistTime">注册时间</param>
        /// <returns>相等返回true</returns>
        private string GetRegistTime()
        {
            return ContrastRegistInfo("bfdefd");
        }
        /// <summary>
        /// 获取最后一次使用时间
        /// </summary>
        /// <param name="DeleteRegistTime">注册时间</param>
        /// <returns>相等返回true</returns>
        private string GetLastTime()
        {
            return ContrastRegistInfo("jkdsgd");
        }
        /// <summary>
        /// 获取注册时间
        /// </summary>
        /// <param name="RegistName">获取项</param>
        /// <returns></returns>
        private string ContrastRegistInfo(string RegistName)
        {
            string now = null;
            RegistryKey pregkey;
            pregkey = AddDigipower();
            RegistryKey objkey = pregkey.OpenSubKey(RegistName);
            if (objkey != null)
            {
                now = MyDESCryptoDe(objkey.GetValue(RegistName, "").ToString());
            }
            return now;
        }
        /// <summary>
        /// 获取标识码
        /// </summary>
        /// <param name="DigipowerID">标识码</param>
        /// <returns>相等返回true</returns>
        private string GetDigipowerID()
        {
            return ContrastRegistInfo("ewrcv");
        }
        /// <summary>
        /// 对比注册表
        /// </summary>
        /// <param name="objName">对比值</param>
        /// <param name="RegistName">对比项</param>
        /// <returns></returns>
        private bool ContrastRegedit(string objName, string RegistName)
        {
            string now = null;
            RegistryKey pregkey;
            pregkey = AddDigipower();
            RegistryKey objkey = pregkey.OpenSubKey(RegistName);
            if (objkey != null)
            {
                now = MyDESCryptoDe(objkey.GetValue(RegistName, "").ToString());
            }
            if (objName.Equals(now))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="keys"></param>
        /// <param name="ivs"></param>
        /// <returns></returns>
        private string MyDESCrypto(string str)
        {
            byte[] strs = Encoding.Unicode.GetBytes(str);
            DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            ICryptoTransform transform = desc.CreateEncryptor(key, iv);//加密对象
            CryptoStream cStream = new CryptoStream(mStream, transform, CryptoStreamMode.Write);
            cStream.Write(strs, 0, strs.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="keys"></param>
        /// <param name="ivs"></param>
        /// <returns></returns>
        private string MyDESCryptoDe(string str)
        {
            byte[] strs = Convert.FromBase64String(str);
            DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            ICryptoTransform transform = desc.CreateDecryptor(key, iv);//解密对象
            CryptoStream cStream = new CryptoStream(mStream, transform, CryptoStreamMode.Write);
            cStream.Write(strs, 0, strs.Length);
            cStream.FlushFinalBlock();
            return Encoding.Unicode.GetString(mStream.ToArray());
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string MD5Encrypt(string s)
        {
            string pwd = "";
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] md5s = md5.ComputeHash(Encoding.Unicode.GetBytes(s));//计算输入数据的Md5哈希值。 
            foreach (byte b in md5s)
            {
                pwd = pwd + b.ToString("x");//16进制
            }
            return pwd;
        }
        /// <summary>
        /// 数组加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string ItemCrypto(string str)
        {
            switch (str)
            {
                case "0":
                    return "A";
                case "1":
                    return "D";
                case "2":
                    return "B";
                case "3":
                    return "T";
                case "4":
                    return "K";
                case "5":
                    return "L";
                case "6":
                    return "Q";
                case "7":
                    return "W";
                case "8":
                    return "U";
                case "9":
                    return "M";
                default:
                    return null;
            }
        }
        /// <summary>
        /// 数组解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string ItemCryptoDe(string str)
        {
            switch (str)
            {
                case "A":
                    return "0";
                case "D":
                    return "1";
                case "B":
                    return "2";
                case "T":
                    return "3";
                case "K":
                    return "4";
                case "L":
                    return "5";
                case "Q":
                    return "6";
                case "W":
                    return "7";
                case "U":
                    return "8";
                case "M":
                    return "9";
                default:
                    return null;
            }
        }
        /// <summary>
        /// 获取CPU ID
        /// </summary>
        private string GetCpuNum()
        {
            string cpuInfo = " ";
            ManagementClass cimobject = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = cimobject.GetInstances();
            StringBuilder sb = new StringBuilder();
            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                sb.Append(cpuInfo.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// 验证注册号
        /// </summary>
        /// <returns>验证通过返回true</returns>
        private bool ContrastRegistNum()
        {
            try
            {
                string strNew = MD5Encrypt(this.GetCpuNum());
                strNew = strNew.Substring(strNew.Length - 8);
                string strOld = this.GetDigipowerID();
                strOld = strOld.Substring(0, strOld.Length - 4);
                if (!String.IsNullOrEmpty(strNew) && !String.IsNullOrEmpty(strOld))
                {
                    if (strNew.Trim().Equals(strOld.Trim()))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 验证最后一次使用时间
        /// </summary>
        /// <returns></returns>
        private bool ContrastLastTime()
        {
            try
            {
                string strOld = this.GetLastTime();
                if (!String.IsNullOrEmpty(strOld))
                {
                    if (DateTime.Parse(strOld) > DateTime.Now)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 验证使用期限
        /// </summary>
        /// <param name="objName">对比值</param>
        /// <param name="RegistName">对比项</param>
        /// <returns></returns>
        private bool ContrastGetPeriod()
        {
            try
            {
                string now = null;
                RegistryKey pregkey;
                pregkey = AddDigipower();
                RegistryKey objkey = pregkey.OpenSubKey("qwbcd");
                if (objkey != null)
                {
                    now = MyDESCryptoDe(objkey.GetValue("qwbcd", "").ToString());
                }
                if (!String.IsNullOrEmpty(now))
                {
                    if (DateTime.Now <= DateTime.Parse(now))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 验证注册次数
        /// </summary>
        /// <param name="RegistID">注册码</param>
        /// <returns>成功返回true</returns>
        private bool ContrastRegistCount(string RegistID)
        {
            if (!String.IsNullOrEmpty(RegistID))
            {
                string strNowIDFirst = RegistID.Substring(RegistID.Length - 2, 1);
                string strNowIDSecond = RegistID.Substring(RegistID.Length - 1, 1);
                int NewNum = Convert.ToInt32(ItemCryptoDe(strNowIDFirst) + ItemCryptoDe(strNowIDSecond));
                string RegistStr = GetDigipowerID();
                if (!String.IsNullOrEmpty(RegistStr))
                {
                    string strOldIDFirst = RegistStr.Substring(RegistStr.Length - 2, 1);
                    string strOldIDSecond = RegistStr.Substring(RegistStr.Length - 1, 1);
                    int OldNum = 0;
                    if (!String.IsNullOrEmpty(RegistStr))
                    {
                        OldNum = Convert.ToInt32(ItemCryptoDe(strOldIDFirst) + ItemCryptoDe(strOldIDSecond));
                    }
                    if (NewNum > OldNum)
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 获取CPUID
        /// </summary>
        /// <returns></returns>
        public string DigipowerGetNum()
        {
            return this.GetCpuNum();
        }
        /// <summary>
        /// 获取注册号
        /// </summary>
        /// <returns></returns>
        public string DigipowerGetRegistNum(string ID, string UserTimeFirst, string UserTimeSecond, string UserCountFirst, string UserCountSecond)
        {
            string TFirst = ItemCrypto(UserTimeFirst);
            string TSecond = ItemCrypto(UserTimeSecond);
            string CFirst = ItemCrypto(UserCountFirst);
            string CSecond = ItemCrypto(UserCountSecond);
            string CPUID = MD5Encrypt(ID);
            CPUID = CPUID.Substring(CPUID.Length - 8);
            return CPUID + TFirst + TSecond + CFirst + CSecond;
        }
        /// <summary>
        /// 添加注册表
        /// </summary>
        /// <param name="RegistID">注册号</param>
        public bool DigipowerAddRegedit(string RegistID)
        {
            if (!String.IsNullOrEmpty(RegistID))
            {
                if (ContrastRegistCount(RegistID))
                {
                    this.AddDigipowerID(RegistID);
                    this.AddRegistTime();
                    this.AddPeriod(RegistID);
                    this.AddLastTime();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 添加最后一次使用时间
        /// </summary>
        public void DigipowerAddLastTime()
        {
            this.AddLastTime();
        }
        /// <summary>
        /// 验证注册信息
        /// </summary>
        /// <returns>成功返回true</returns>
        public bool DigipowerCheckRegist()
        {
            try
            {
                if (ContrastRegistNum() && ContrastGetPeriod() && ContrastLastTime())
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    } 
}
