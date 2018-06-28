/************************************
 * ʱ��:2008-12-15
 * Ŀ��:�����ļ���
 ***********************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Digi.B.Common {
    /// <summary>
    /// �����ļ���
    /// </summary>
    class CopyDir {
        public CopyDir() { }

        #region ����ģ�巽��

        //����ģ��
        public static void GetTemplet(string destPath, string sourPath) {
            DirectoryInfo SourDir = new DirectoryInfo(sourPath);
            DirectoryInfo DestDir = new DirectoryInfo(destPath);
            if (!DestDir.Exists)
                DestDir.Create();
            GetDirFiles(SourDir, DestDir);
        }

        /// <summary>
        /// ��������·��,�ݹ�
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
        /// �����ļ�
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
