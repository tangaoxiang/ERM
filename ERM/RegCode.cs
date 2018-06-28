using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Management;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
namespace ERM.UI
{
    /// <summary>
    /// 注册USB Key类
    /// </summary>
    public class RY3_DEFINE
    {
        public const uint RY_SUCCESS = 0x00000000;              // 操作成功
        public const uint RY_NOT_FOUND = 0xF0000001;            // 未找到指定的设备
        public const uint RY_INVALID_PARAMETER = 0xF0000002;	// 参数错误
        public const uint RY_COMM_ERROR = 0xF0000003;			// 通讯错误
        public const uint RY_INSUFFICIENT_BUFFER = 0xF0000004;	// 缓冲区空间不足
        public const uint RY_NO_LIST = 0xF0000005;			    // 没有找到设备列表
        public const uint RY_DEVPIN_NOT_CHECK = 0xF0000006;		// 开发商口令没有验证
        public const uint RY_USERPIN_NOT_CHECK = 0xF0000007;	// 用户口令没有验证
        public const uint RY_RSA_FILE_FORMAT_ERROR = 0xF0000008;// RSA文件格式错误
        public const uint RY_DIR_NOT_FOUND = 0xF0000009;		// 目录没有找到
        public const uint RY_ACCESS_DENIED = 0xF000000A;		// 访问被拒绝
        public const uint RY_ALREADY_INITIALIZED = 0xF000000B;	// 产品已经初始化
        public const uint RY_INCORRECT_PIN = 0xF0000C00;		// 密码不正确
        public const uint RY_DF_SIZE = 0xF000000D;		        // 指定的目录空间大小不够
        public const uint RY_FILE_EXIST = 0xF000000E;		    // 文件已存在
        public const uint RY_UNSUPPORTED = 0xF000000F;			// 功能不支持或尚未建立文件系统
        public const uint RY_FILE_NOT_FOUND = 0xF0000010;		// 未找到指定的文件
        public const uint RY_ALREADY_OPENED = 0xF0000011;		// 卡已经被打开
        public const uint RY_DIRECTORY_EXIST = 0xF0000012;		// 目录已存在
        public const uint RY_CODE_RANGE = 0xF0000013;			// 虚拟机内存地址溢出
        public const uint RY_INVALID_POINTER = 0xF0000014;		// 虚拟机错误的指针
        public const uint RY_GENERAL_FILESYSTEM = 0xF0000015;	// 常规文件系统错误 
        public const uint RY_OFFSET_BEYOND = 0xF0000016;		// 文件偏移量超出文件大小
        public const uint RY_FILE_TYPE_MISMATCH = 0xF0000017;   // 文件类型不匹配
        public const uint RY_PIN_BLOCKED = 0xF0000018;		    // PIN码锁死
        public const uint RY_INVALID_HANDLE = 0xF0000019;		// 无效的句柄
        public const uint RY_ERROR_UNKNOWN = 0xFFFFFFFF;		// 未知的错误
        public const uint RY_C51_SUCCESS = 0x00000000;			//	成功
        public const uint RY_C51_UNKNOWN = 0x00000001;			//	未知错误
        public const uint RY_C51_INVALID_PARAMETER = 0x00000002;//	无效的参数
        public const uint RY_C51_INVALID_ADDRESS = 0x00000003;	//	无效的地址,虚拟机地址越界
        public const uint RY_C51_INVALID_SIZE = 0x00000004;		//	无效的长度
        public const uint RY_C51_FILE_NOT_FOUND = 0x00000005;	//	文件没找到
        public const uint RY_C51_ACCESS_DENIED = 0x00000006;	//	访问文件失败
        public const uint RY_C51_FILE_SELECT = 0x00000007;		//	文件打开个数已达上限
        public const uint RY_C51_INVALID_HANDLE = 0x00000008;	//	无效的文件句柄
        public const uint RY_C51_FILE_OUT_OF_RANGE = 0x00000009;//	文件读写越界
        public const uint RY_C51_FILE_TYPE_MISMATCH = 0x0000000A;//	文件存在但类型不匹配
        public const uint RY_C51_FILE_SIZE_MISMATCH = 0x0000000B;//	文件存在但长度不匹配
        public const uint RY_C51_NO_SPACE = 0x0000000C;			 //	文件夹空间不足
        public const uint RY_C51_FILE_EXIST = 0x0000000D;		 //	文件或子目录已存在
        public const uint RY_C51_INVALID_KEY_FORMAT = 0x0000000E;//	无效的RSA密钥文件格式
        public const uint RY_C51_KEY_LEN_MISMATCH = 0x0000000F;	 //  用户传入的密钥长度与实际长度不匹配
        public const uint RY_C51_RSA_INVALID_KEY_FILE = 0x00000010;	//	文件类型不符合要求
        public const uint RY_C51_RSA_ENC_DEC_FAILED = 0x00000011;	//	RSA加密解密失败
    }
    public class WriteDog
    {
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_Find(string strVendorID, ref int iCount);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_Open(ref uint hHandle, int iIndex);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_SetVendorID(uint handle, string pSeed, int len, byte[] pOutVendorID);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_VerifyDevPin(uint handle, string pInPin, ref int pRemainCount);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_ChangeDevPin(uint handle, string pOldPin, string pNewPin, int TryCount);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_Read(uint handle, int offset, byte[] pOutbuf, int len);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_Write(uint handle, int offset, string pInbuf, int len);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_ReadShare(uint handle, int offset, byte[] pbuf, int len);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_WriteShare(uint handle, int offset, byte[] pbuf, int len);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_LEDControl(uint handle, int flag);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_GetHardID(uint handle, byte[] pbuf);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_GetFreeSize(uint handle, ref int pSize);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_GenRandom(uint handle, int len_need, byte[] pOutbuf);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_CreateFile(uint handle, UInt16 FileID, int Size, int Type);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_WriteFile(uint handle, UInt16 FileID, int offset, byte[] pbuf, int Size);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_VendorWrite(uint handle, int offset, byte[] pInbuf, int len);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_ExecuteFile(uint handle, UInt16 FileID, byte[] pInBuf, int InSize, byte[] pOutBuf, ref int pOutSize);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_EraseAllFile(uint handle);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_GenRsaKey(uint handle, int kid, byte[] pPubBakup, byte[] pPriBakup);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_SetRsaKey(uint handle, int kid, byte[] pPubKey, byte[] pPriKey);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_PublicEncrypt(uint handle, int kid, byte[] pBuf, int len);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_PrivateDecrypt(uint handle, int kid, byte[] pBuf, int len);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_MD5(uint handle, byte[] pBuf, int len, byte[] pMD5);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_SHA1(uint handle, byte[] pBuf, int len, byte[] pSHA1);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_Set3DESKey(uint handle, int kid, byte[] pKey);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_3DES(uint handle, int kid, int flag, byte[] pInBuf, int len);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_GenUpdatePacket(uint handle, string pLicSN, int type, int kid_offset, byte[] pbuf, int len, byte[] pUPubKey, byte[] pOutData, ref int pOutLen);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_Update(uint handle, byte[] pbuf, int len);
        [DllImport("Rockey3.dll")]
        public static extern uint RY3_Close(uint hHandle, bool bIsReset);
        private static uint WriteUSBKey(uint handle, string pInbuf)
        {
            if (pInbuf.Length > 0)
            {
                if (pInbuf[pInbuf.Length - 1] != ',')
                {
                    pInbuf += ",";
                }
            }
            return RY3_Write(handle, 0, pInbuf, pInbuf.Length);
        }
        public static string DoReader()
        {            
            uint iRes = 0;
            uint hHandle = 0;
            int iCount = 0;
            byte[] bVendorID = new byte[8];
            string strtemp = "";
            string sVendorID = "92799461";//
            string sDef_PIN = "123456781234567812345678";//
            iRes = RY3_Find(sVendorID, ref iCount);
            if (iRes != RY3_DEFINE.RY_SUCCESS)
            {//不是我们公司的KEY
                return "对不起，此USB-Key非本公司发布，请与供应商联系！";
            }
            iRes = RY3_Open(ref hHandle, 1);
            if (iRes != RY3_DEFINE.RY_SUCCESS)
            {
                return "USB-Key打开失败，可能已经损坏，请联系供应商更换！";
            }
            iRes = RY3_VerifyDevPin(hHandle, sDef_PIN, ref iCount);
            if (iRes != RY3_DEFINE.RY_SUCCESS)
            {
                return "对不起，此USB-Key非本公司发布，请与供应商联系！";
            }
            iRes = RY3_LEDControl(hHandle, 1);
            byte[] bb = new byte[500];
            ////读存储区(0-8192字节)
            iRes = RY3_Read(hHandle, 0, bb, 500);
            if (iRes != RY3_DEFINE.RY_SUCCESS)
            {
                return "USB-Key读取失败，可能已经损坏，请联系供应商更换！";
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < bb.Length; i++)
            {
                if (bb[i] != 0)
                {
                    list.Add(bb[i]);
                }
            }
            byte[] bbResult = new byte[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                bbResult[i] = (byte)list[i];
            }
            if (iRes == RY3_DEFINE.RY_SUCCESS)
            {
                strtemp = System.Text.Encoding.ASCII.GetString(bbResult);
                if (!String.IsNullOrEmpty(strtemp) && strtemp.Length > 10)
                {
                    string begin = strtemp.Substring(0, strtemp.LastIndexOf(','));
                    string end = strtemp.Substring(strtemp.LastIndexOf(','));
                    if (end.IndexOf('a') > 0)
                    {
                        end = end.Substring(0, end.IndexOf('a'));
                    }
                    strtemp = begin + end;
                    strtemp = strtemp.Trim();
                }
                else
                {
                    RY3_Update(hHandle, null, strtemp.Length + 10);
                    string strGuid = Guid.NewGuid().ToString();
                    strGuid = strGuid + "," + MD5Encrypt(strGuid) + ",2020-01-01," + System.DateTime.Now.ToString("yyyy-MM-dd");
                    iRes = WriteUSBKey(hHandle, strGuid);
                    RY3_Close(hHandle, true);
                    return "USB-Key发生故障，已经复位，请重启本程序！";
                }
            }
            string[] str = strtemp.Split(',');
            string result = "";
            try
            {
                if (str != null && str.Length > 0)
                {
                    DateTime ExpireDate = System.DateTime.Now;
                    if (System.DateTime.TryParse(str[2], out ExpireDate))
                    {
                        ExpireDate = System.DateTime.Parse(str[2]);
                    }
                    else
                    {
                        ExpireDate = System.DateTime.Parse(str[2], System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    }
                    if (!MD5Encrypt(str[0]).Equals(str[1]))
                    {
                        string strGuid = Guid.NewGuid().ToString();
                        strGuid = strGuid + "," + MD5Encrypt(strGuid) + ",2020-01-01," + System.DateTime.Now.ToString("yyyy-MM-dd");
                        iRes = WriteUSBKey(hHandle, strGuid);
                        RY3_Close(hHandle, true);
                        return "USB-Key发生故障，已经复位，请重启本程序！";
                    }
                    if (str.Length == 3 && DateTime.Now < ExpireDate)
                    {
                        strtemp = str[0] + "," + str[1] + "," + ExpireDate.ToString("yyyy-MM-dd") + "," + DateTime.Now.ToString("yyyy-MM-dd");//日期标准化
                        if (!String.IsNullOrEmpty(strtemp))
                        {//写Key
                            iRes = WriteUSBKey(hHandle, strtemp);
                        }
                    }
                    else
                    {
                        if (str.Length >= 4)
                        {
                            DateTime LastUserDate = System.DateTime.Now;
                            if (System.DateTime.TryParse(str[3], out LastUserDate))
                            {
                                LastUserDate = System.DateTime.Parse(str[3]);
                            }
                            else
                            {
                                LastUserDate = System.DateTime.Parse(str[3], System.Globalization.DateTimeFormatInfo.InvariantInfo);
                            }
                            if (LastUserDate > System.DateTime.Now)
                            {
                                result = "USB-Key已过有效期！";// false;
                            }
                            else
                            {
                                if (DateTime.Now < ExpireDate)
                                {
                                    if (DateTime.Now.Day != LastUserDate.Day)
                                    {//DateTime.Now.Year >= LastUserDate.Year && DateTime.Now.Month >= LastUserDate.Month &&
                                        strtemp = str[0] + "," + str[1] + "," + str[2] + "," + DateTime.Now.ToString("yyyy-MM-dd");//日期标准化
                                        if (!String.IsNullOrEmpty(strtemp))
                                        {
                                            iRes = WriteUSBKey(hHandle, strtemp);
                                        }
                                    }
                                }
                                else
                                {
                                    result = "USB-Key已过有效期，请与供应商联系!";// false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    result = "USB-Key无效!";// false;                   
                }
                return result;
            }
            catch
            {
                RY3_Update(hHandle, null, strtemp.Length + 10);
                string strGuid = Guid.NewGuid().ToString();
                strGuid = strGuid + "," + MD5Encrypt(strGuid) + ",2020-01-01," + System.DateTime.Now.ToString("yyyy-MM-dd");
                iRes = WriteUSBKey(hHandle, strGuid);
                RY3_Close(hHandle, true);
                return "USB-Key发生故障，已经复位，请重启本程序！";
            }
            finally
            {
                iRes = RY3_Close(hHandle, true);
            }            
        }        
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string MD5Encrypt(string s)
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
    }
}
