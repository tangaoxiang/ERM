/*
   作者： 张建宏
   日期：2008-12-03
   功能：密码加密解密类 
   备注：密码加密解密类
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
namespace ERM.Common
{
      public class HandlePwd
    {
        /// <summary>
        /// 加密方法
        /// - DES 的加密方法 。
        /// - 私钥加密 / 对称算法 。
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <returns>已经加密的字符串</returns>
        public static string Encrypt(string encryptString)
        {
            byte[] KEY_64 = { 142, 116, 93, 156, 78, 4, 218, 132 };	// 指定的 Key
            byte[] IV_64 = { 65, 103, 246, 79, 36, 99, 167, 13 };	// 初始化向量（IV）
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, provider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(encryptString);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();
            string returnString = Convert.ToBase64String(ms.GetBuffer(), 0, int.Parse((ms.Length.ToString())));
            return returnString;
        }
        /// <summary>
        /// 解密方法
        /// - DES 的解密方法 。
        /// - 私钥加密 / 对称算法 。
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <returns>已经解密的字符串</returns>
        public static string Decrypt(string decryptString)
        {
            byte[] KEY_64 = { 142, 116, 93, 156, 78, 4, 218, 132 };	// 指定的 Key
            byte[] IV_64 = { 65, 103, 246, 79, 36, 99, 167, 13 };	// 初始化向量（IV）
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] buffer = Convert.FromBase64String(decryptString);
            MemoryStream ms = new MemoryStream(buffer);
            CryptoStream cs = new CryptoStream(ms, provider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            string returnString = sr.ReadToEnd();
            return returnString;
        }
    }
}
