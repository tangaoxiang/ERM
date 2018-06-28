using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ERM.Common
{
    /// <summary>
    /// 复制单个文件 导入导出时用到
    /// </summary>
    public class FileCopy
    {
        public FileCopy()
        { }
        /// <summary>
        /// 源目录，目标目录，和文件与源目录的相对路径
        /// </summary>
        /// <param name="destpath">目录路径</param>
        /// <param name="sourcepath">源路径</param>
        /// <param name="relativeName">相对文件名</param>
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
        /// 更改文件的只读属性
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
        /// 遍历所有路径,递规
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
        /// 复制文件
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
