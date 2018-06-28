/************************************
 * 时间:2008-12-15
 * 目的:拷贝文件类
 ***********************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Digi.B.Common {
    /// <summary>
    /// 拷贝文件类
    /// </summary>
    class CopyDir {
        public CopyDir() { }

        #region 拷贝模板方法

        //拷贝模板
        public static void GetTemplet(string destPath, string sourPath) {
            DirectoryInfo SourDir = new DirectoryInfo(sourPath);
            DirectoryInfo DestDir = new DirectoryInfo(destPath);
            if (!DestDir.Exists)
                DestDir.Create();
            GetDirFiles(SourDir, DestDir);
        }

        /// <summary>
        /// 遍历所有路径,递规
        /// </summary>
        /// <param name="sourDir"></param>
        /// <param name="destDir"></param>
        private static void GetDirFiles(DirectoryInfo sourDir, DirectoryInfo destDir) {
            GetFiles(sourDir, destDir);
            foreach (DirectoryInfo dir in sourDir.GetDirectories()) {
                destDir.CreateSubdirectory(dir.Name);
                GetDirFiles(dir, new DirectoryInfo(destDir.FullName + "\\" + dir.Name));
            }
        }
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="sourDir"></param>
        /// <param name="destDir"></param>
        private static void GetFiles(DirectoryInfo sourDir, DirectoryInfo destDir) {
            string destPath = destDir.FullName + "\\";
            foreach (FileInfo file in sourDir.GetFiles("*.cll")) {
                file.CopyTo(destPath + file.Name);
            }
        }

        #endregion
    }
}
