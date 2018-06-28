using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.Windows.Forms;

namespace ERM.Common
{
    /// <summary>
    /// 压缩一个路径 
    /// </summary>
    public class ZipFile
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="_sourcePath"> 源目录</param>
        /// <param name="_destFileName">压缩后文件名</param>
        public ZipFile(string _sourcePath, string _destFileName)
        {
            sourcePath = _sourcePath;
            if (sourcePath.IndexOf("\\\\") != -1)
                sourcePath = sourcePath.Replace("\\\\", "\\");
            if (!sourcePath.EndsWith("\\"))
                sourcePath += "\\";
            destFileName = _destFileName;
        }
        ZipOutputStream zos = null;
        string sourcePath;
        string destFileName;
        /// <summary>
        /// 只有一个方法
        /// </summary>
        public bool StartZip()
        {
            using (zos = new ZipOutputStream(System.IO.File.Create(destFileName)))
            {
                try
                {
                    m_Crc = new ICSharpCode.SharpZipLib.Checksums.Crc32();
                    addZipEntryONE(sourcePath);
                    return true;
                }
                catch (Exception ex)
                {
                    WriteLog("压缩文件失败！错误信息：" + ex.Message);
                    return false;
                }
                finally
                {
                    zos.Finish();
                    zos.Close();
                    zos.Dispose();
                }
            }
        }
        private const int SIZE = 1024 * 1024 * 4;

        long pai = 1024 * 1024 * 4;//每M兆写一次 

        private void addZipEntry(string PathStr)
        {
            DirectoryInfo di = new DirectoryInfo(PathStr);
            foreach (DirectoryInfo item in di.GetDirectories())
            {
                //判断文件夹是否点开头的 例如：.svs , .vss
                if (item.FullName.Substring((item.FullName.LastIndexOf("\\")) + 1).StartsWith(".") == false)
                    addZipEntry(item.FullName);
            }
            foreach (FileInfo item in di.GetFiles())
            {
                //int offset = 0;
                int count = 0;
                FileStream fs = System.IO.File.OpenRead(item.FullName);
                string strEntryName = item.FullName.Replace(sourcePath, "");
                ZipEntry entry = new ZipEntry(strEntryName);
                entry.Size = fs.Length;// count;
                zos.PutNextEntry(entry);
                do
                {
                    byte[] buffer = new byte[SIZE];
                    count = fs.Read(buffer, 0, SIZE);
                    if (count <= 0)
                        break;
                    zos.Write(buffer, 0, count);
                    //offset += count;
                } while (count == SIZE);
                fs.Flush();
                fs.Close();
                //fs.Dispose();
                //Application.DoEvents();
            }
        }

        private ICSharpCode.SharpZipLib.Checksums.Crc32 m_Crc;

        private void addZipEntryONE(string PathStr)
        {
            DirectoryInfo di = new DirectoryInfo(PathStr);
            foreach (DirectoryInfo item in di.GetDirectories())
            {
                //判断文件夹是否点开头的 例如：.svs , .vss
                if (item.FullName.Substring((item.FullName.LastIndexOf("\\")) + 1).StartsWith(".") == false)
                    addZipEntryONE(item.FullName);
            }
            try
            {
                byte[] buffer = null;
                foreach (FileInfo item in di.GetFiles())
                {
                    if (item.Length <= 0)
                        continue;

                    using (FileStream fs = System.IO.File.OpenRead(item.FullName))
                    {
                        string strEntryName = item.FullName.Replace(sourcePath, "");

                        ZipEntry entry = new ZipEntry(strEntryName);
                        entry.Size = fs.Length;
                        entry.DateTime = DateTime.Now;
                        zos.PutNextEntry(entry);

                        #region YQ 屏蔽 2013-0508 测试大文件压缩
                        //int count = 0;
                        //do
                        //{
                        //    buffer = new byte[4096];
                        //    count = fs.Read(buffer, 0, 4096);
                        //    if (count <= 0)
                        //        break;
                        //    zos.Write(buffer, 0, count);
                        //} while (count > 0);
                        //fs.Flush();
                        //fs.Close();
                        //Application.DoEvents();
                        #endregion

                        long forint = fs.Length / pai + 1;

                        for (long i = 1; i <= forint; i++)
                        {
                            if (pai * i < fs.Length)
                            {
                                buffer = new byte[pai];
                                fs.Seek(pai * (i - 1), System.IO.SeekOrigin.Begin);
                            }
                            else
                            {
                                if (fs.Length < pai)
                                {
                                    buffer = new byte[fs.Length];
                                }
                                else
                                {
                                    buffer = new byte[fs.Length - pai * (i - 1)];
                                    fs.Seek(pai * (i - 1), System.IO.SeekOrigin.Begin);
                                }
                            }
                            fs.Read(buffer, 0, buffer.Length);
                            m_Crc.Reset();
                            m_Crc.Update(buffer);
                            zos.Write(buffer, 0, buffer.Length);
                            zos.Flush();
                        }
                        fs.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            GC.Collect();
        }
        /// <summary>
        ///  日志记录方法（按当天记录）
        /// </summary>
        /// <param name="MessageLog">日志信息</param>
        private void WriteLog(string MessageLog)
        {
            string errLog_path = Application.StartupPath + "\\log";
            if (!Directory.Exists(errLog_path))
                Directory.CreateDirectory(errLog_path);
            errLog_path += "\\log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

            if (System.IO.File.Exists(errLog_path))
            {
                //StreamWriter s1 = System.IO.File.AppendText(errLog_path);
                StreamWriter s1 = new StreamWriter(errLog_path, true, Encoding.Default);
                s1.WriteLine("[时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + MessageLog);
                s1.Close();
                s1.Dispose();
            }
            else
            {
                //System.IO.TextWriter r1 = System.IO.File.CreateText(errLog_path);
                StreamWriter r1 = new StreamWriter(errLog_path, false, Encoding.Default);
                r1.WriteLine("[时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + MessageLog);
                r1.Close();
                r1.Dispose();
            }
        }

    }
}
