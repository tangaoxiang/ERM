using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Management;
using System.IO;
using System.Reflection;

namespace ERM.UI
{
    /// <summary>
    /// USB操作
    /// </summary>
    public class USBKey
    {

        /// <summary>
        /// 检测USB
        /// </summary>
        /// <returns></returns>
        public bool CheckUSB()
        {
            bool return_flg = false;


            //PropertyInfo[] peroperties = typeof(A).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //foreach (PropertyInfo property in peroperties)
            //{
            //    object[] objs = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
            //}

            ManagementObject disk = null;
            string filePath = string.Empty;
            DriveInfo[] s = DriveInfo.GetDrives();
            foreach (DriveInfo drive in s)
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    try
                    {
                        string driver = "win32_logicaldisk='" + drive.Name.Replace("\\", "") + "'";
                        disk = new ManagementObject(driver);

                        if (disk.Properties["VolumeSerialNumber"].Value.ToString() == "32485067")//EOTp0A2f
                        {
                            return_flg = true;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MyCommon.WriteLog("读取U盘失败！错误信息：" + ex.Message);
                        return_flg = false;
                    }
                }
            }

            return return_flg;
        }

        /// <summary>
        /// 检测USB
        /// </summary>
        /// <returns></returns>
        //public bool CheckUSB()
        //{
        //    bool return_flg = false;
        //    ManagementObject disk = null;
        //    string filePath = string.Empty;
        //    DriveInfo[] s = DriveInfo.GetDrives();
        //    foreach (DriveInfo drive in s)
        //    {
        //        if (drive.DriveType == DriveType.Removable)
        //        {
        //            string driver = "win32_logicaldisk='" + drive.Name.Replace("\\", "") + "'";
        //            disk = new ManagementObject(driver);

        //            if (disk.Properties["VolumeSerialNumber"].Value.ToString() == "EOTp0A2f")
        //            {
        //                filePath = drive.Name;
        //                break;
        //            }
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(filePath) && System.IO.File.Exists(filePath + "erm.dat"))
        //    {
        //        return_flg = CheckKey(filePath + "erm.dat");
        //    }
        //    return return_flg;
        //}
        /// <summary>
        /// 判断U盘信息
        /// </summary>
        /// <returns></returns>
        private bool CheckKey(string filepath)
        {
            bool return_flg = false;
            Dictionary<string, string> hTable = new Dictionary<string, string>();
            try
            {
                if (System.IO.File.Exists(filepath))
                {
                    string contentFavoritesNode = System.IO.File.ReadAllText(filepath);
                    if (contentFavoritesNode != null && contentFavoritesNode != "")
                    {
                        string[] C2 = contentFavoritesNode.Split('|');
                        if (C2 != null && C2.Length > 1)
                        {
                            string keyString = Decrypt(C2[1], "digipowe");
                            if (keyString != null && keyString.EndsWith("0755digipower"))
                                return_flg = true;
                        }
                    }
                }
            }
            catch { return_flg = false; }

            return return_flg;
        }

        //MD5不可解密
        //32位加密
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="_input_charset"></param>
        /// <returns></returns>
        private string GetMD5_32(string s, string _input_charset)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        //16位加密
        private static string GetMd5_16(string ConvertString)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        /// <summary>
        /// 进行DES加密。
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串。</param>
        /// <param name="sKey">密钥，且必须为8位。例如：digipowe</param>
        /// <returns>以Base64格式返回的加密字符串。</returns>
        private string Encrypt(string pToEncrypt, string sKey)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        /// <summary>
        /// 进行DES解密。
        /// </summary>
        /// <param name="pToDecrypt">要解密的以Base64</param>
        /// <param name="sKey">密钥，且必须为8位。例如：digipowe</param>
        /// <returns>已解密的字符串。</returns>
        private string Decrypt(string pToDecrypt, string sKey)
        {
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }
    }
}
