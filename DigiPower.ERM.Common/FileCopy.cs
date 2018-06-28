using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ERM.Common
{
    /// <summary>
    /// ���Ƶ����ļ� ���뵼��ʱ�õ�
    /// </summary>
    public class FileCopy
    {
        public FileCopy()
        { }
        /// <summary>
        /// ԴĿ¼��Ŀ��Ŀ¼�����ļ���ԴĿ¼�����·��
        /// </summary>
        /// <param name="destpath">Ŀ¼·��</param>
        /// <param name="sourcepath">Դ·��</param>
        /// <param name="relativeName">����ļ���</param>
        /// <returns></returns>
        public static bool CopyFile(string destpath, string sourcepath)
        {
            FileInfo sourcefile = new FileInfo(sourcepath);
            if (!sourcefile.Exists)
                return false;
            sourcefile.Attributes = FileAttributes.Archive;
            FileInfo destfile = new FileInfo(destpath);
            if (!destfile.Directory.Exists)
                destfile.Directory.Create();
            try
            {
                sourcefile.CopyTo(destpath, true);
            }
            catch (FileLoadException ex)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// �����ļ���ֻ������
        /// </summary>
        /// <param name="fi"></param>
        private void SetFile(string fi)
        {
            if ((File.GetAttributes(fi) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                System.IO.File.SetAttributes(fi, System.IO.FileAttributes.Archive);
            }
        }
        public  bool CopyDir(string destPath, string sourPath)
        {
            DirectoryInfo SourDir = new DirectoryInfo(sourPath);
            DirectoryInfo DestDir = new DirectoryInfo(destPath);
            try
            {
                if (!DestDir.Exists)
                    DestDir.Create();
                GetDirFiles(SourDir, DestDir);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// ��������·��,�ݹ�
        /// </summary>
        /// <param name="sourDir"></param>
        /// <param name="destDir"></param>
        private void GetDirFiles(DirectoryInfo sourDir, DirectoryInfo destDir)
        {
            GetFiles(sourDir, destDir);
            foreach (DirectoryInfo dir in sourDir.GetDirectories())
            {
                destDir.CreateSubdirectory(dir.Name);
                GetDirFiles(dir, new DirectoryInfo(destDir.FullName + "\\" + dir.Name));
            }
        }
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="sourDir"></param>
        /// <param name="destDir"></param>
        private void GetFiles(DirectoryInfo sourDir, DirectoryInfo destDir)
        {
            string destPath = destDir.FullName + "\\";
            foreach (FileInfo file in sourDir.GetFiles())
            {
                file.CopyTo(destPath + file.Name);
            }
        }
    }
}
