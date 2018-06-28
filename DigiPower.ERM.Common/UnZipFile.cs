using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.Windows.Forms;

namespace ERM.Common
{
    public class UpZipFile
    {
        string file;
        string TempPath;
        public UpZipFile(string _file, string _TempPath)
        {
            file = _file;
            TempPath = _TempPath;
            if (!Directory.Exists(TempPath))
                Directory.CreateDirectory(TempPath);
        }
        public void StartUnZipONE()
        {
            ZipInputStream zis = new ZipInputStream(System.IO.File.OpenRead(file));
            ZipEntry theEntry = null;
            byte[] data = null;

            while ((theEntry = zis.GetNextEntry()) != null)
            {
                string directoryName = Path.GetDirectoryName(theEntry.Name);
                int iPos = directoryName.IndexOf(':');
                if (iPos > 0)
                {
                    directoryName = directoryName.Substring(iPos + 1);
                }
                string fileName = Path.GetFileName(theEntry.Name);
                if (directoryName != string.Empty)
                    Directory.CreateDirectory(TempPath + "\\" + directoryName);
                if (fileName != string.Empty)
                {
                    string dbFileName = theEntry.Name;
                    iPos = dbFileName.IndexOf(':');
                    if (iPos > 0)
                    {
                        dbFileName = dbFileName.Substring(iPos + 1);
                    }
                    FileStream streamWriter = System.IO.File.Create(TempPath + "\\" + dbFileName);
                    if (theEntry.Size > 0)
                    {
                        int size = 1024 * 1024 * 4;// 2048;
                        data = new byte[size];
                        while (true)
                        {
                            size = zis.Read(data, 0, data.Length);
                            if (size > 0) //&& size == data.Length
                                streamWriter.Write(data, 0, size);
                            else
                                break;
                        }
                    }

                    //data = new byte[zis.Length];
                    //streamWriter.Write(data, 0, (int)zis.Length);

                    //streamWriter.Flush();
                    streamWriter.Close();
                    //streamWriter.Dispose();
                    Application.DoEvents();
                    //GC.Collect();
                }
            }
            //zis.Flush();
            zis.Close();
            //zis.Dispose();
            Application.DoEvents();
            // GC.Collect();
        }
        public void StartUnZip()
        {
            ZipInputStream zis = new ZipInputStream(System.IO.File.OpenRead(file));
            ZipEntry theEntry = null;
            byte[] data = null;

            int size = 0;

            while ((theEntry = zis.GetNextEntry()) != null)
            {
                string directoryName = Path.GetDirectoryName(theEntry.Name);
                int iPos = directoryName.IndexOf(':');
                if (iPos > 0)
                {
                    directoryName = directoryName.Substring(iPos + 1);
                }
                string fileName = Path.GetFileName(theEntry.Name);
                if (directoryName != string.Empty)
                    Directory.CreateDirectory(TempPath + "\\" + directoryName);
                if (fileName != string.Empty)
                {
                    string dbFileName = theEntry.Name;
                    iPos = dbFileName.IndexOf(':');
                    if (iPos > 0)
                    {
                        dbFileName = dbFileName.Substring(iPos + 1);
                    }
                    FileStream streamWriter = System.IO.File.Create(TempPath + "\\" + dbFileName);
                    if (theEntry.Size > 0)
                    {
                        while (true)
                        {
                            data = new byte[4096];
                            size = zis.Read(data, 0, data.Length);
                            if (size > 0)
                                streamWriter.Write(data, 0, size);
                            else
                                break;
                        }
                    }
                    streamWriter.Close();
                }
            }
            zis.Close();
            GC.Collect();

        }
    }
}
