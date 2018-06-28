/*
   ���ߣ� �Ž���
   ���ڣ�2008-12-03
   ���ܣ�������ܽ����� 
   ��ע��������ܽ�����
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
        /// ���ܷ���
        /// - DES �ļ��ܷ��� ��
        /// - ˽Կ���� / �Գ��㷨 ��
        /// </summary>
        /// <param name="encryptString">�����ܵ��ַ���</param>
        /// <returns>�Ѿ����ܵ��ַ���</returns>
        public static string Encrypt(string encryptString)
        {
            byte[] KEY_64 = { 142, 116, 93, 156, 78, 4, 218, 132 };	// ָ���� Key
            byte[] IV_64 = { 65, 103, 246, 79, 36, 99, 167, 13 };	// ��ʼ��������IV��
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
        /// ���ܷ���
        /// - DES �Ľ��ܷ��� ��
        /// - ˽Կ���� / �Գ��㷨 ��
        /// </summary>
        /// <param name="decryptString">�����ܵ��ַ���</param>
        /// <returns>�Ѿ����ܵ��ַ���</returns>
        public static string Decrypt(string decryptString)
        {
            byte[] KEY_64 = { 142, 116, 93, 156, 78, 4, 218, 132 };	// ָ���� Key
            byte[] IV_64 = { 65, 103, 246, 79, 36, 99, 167, 13 };	// ��ʼ��������IV��
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
