using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace ERM.UI
{
    /// <summary>
    /// 注册项表操作类
    /// </summary>
    public class RegistAction
    {
        /// <summary>
        /// 读取指定名称的注册表的值
        /// 读取的注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下的XXX目录中名称为name的注册表值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetRegistData(string name)
        {
            string registData;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
            RegistryKey aimdir = software.OpenSubKey("ERMRegistInfo", true);
            registData = aimdir.GetValue(name).ToString();
            return registData;
        }

        /// <summary>
        /// 向注册表中写数据
        /// 在注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下新建XXX目录并在此目录下创建名称为name值为tovalue的注册表项
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tovalue"></param>
        public void WTRegedit(string name, string tovalue)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
            RegistryKey aimdir = software.CreateSubKey("ERMRegistInfo");
            aimdir.SetValue(name, tovalue);
        }

        /// <summary>
        /// 删除注册表中指定的注册表项
        /// 在注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下XXX目录中删除名称为name注册表项
        /// </summary>
        /// <param name="name"></param>
        public void DeleteRegist(string name)
        {
            string[] aimnames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
            RegistryKey aimdir = software.OpenSubKey("ERMRegistInfo", true);
            aimnames = aimdir.GetSubKeyNames();
            foreach (string aimKey in aimnames)
            {
                if (aimKey == name)
                    aimdir.DeleteSubKeyTree(name);
            }
        }
        /// <summary>
        /// 判断指定注册表项是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsRegeditExit(string name)
        {
            bool _exit = false;
            try
            {
                string[] subkeyNames;
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.OpenSubKey("ERMRegistInfo", true);
                subkeyNames = aimdir.GetValueNames();
                foreach (string keyName in subkeyNames)
                {
                    if (keyName == name)
                    {
                        _exit = true;
                        return _exit;
                    }
                }
            }
            catch
            { }
            return _exit;
        }
        /// <summary>
        /// 进行DES加密。
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串。</param>
        /// <param name="sKey">密钥，且必须为8位。例如：digipowo</param>
        /// <returns>以Base64格式返回的加密字符串。</returns>
        public string Encrypt(string pToEncrypt, string sKey)
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
        /// <param name="sKey">密钥，且必须为8位。例如：digipowo</param>
        /// <returns>已解密的字符串。</returns>
        public string Decrypt(string pToDecrypt, string sKey)
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
