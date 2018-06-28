using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
namespace ERM.UI.File
{
    public partial class Explorer : UserControl
    {
        public Explorer()
        {
            InitializeComponent();
            Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 15);
            TreeImageList.Images.Add(ic0);
            Icon ic1 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 5);
            TreeImageList.Images.Add(ic1);
            Icon ic2 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 7);
            TreeImageList.Images.Add(ic2);
            Icon ic3 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 11);
            TreeImageList.Images.Add(ic3);
            Icon ic4 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 3);
            TreeImageList.Images.Add(ic4);
            Icon ic5 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 4);
            TreeImageList.Images.Add(ic5);
            Icon ic6 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 101);
            TreeImageList.Images.Add(ic6);
            GetDrive();
        }
        [DllImport("Shell32.dll")]
        public static extern int ExtractIcon(IntPtr h, string strx, int ii);
        [DllImport("Shell32.dll")]
        public static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            public char szDisplayName;
            public char szTypeName;
        }
        string strFilePath = "";
        protected virtual Icon myExtractIcon(string FileName, int iIndex)
        {
            try
            {
                IntPtr hIcon = (IntPtr)ExtractIcon(this.Handle, FileName, iIndex);
                if (!hIcon.Equals(null))
                {
                    Icon icon = Icon.FromHandle(hIcon);
                    return icon;
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); 
            }
            return null;
        }
        protected virtual void SetIcon(ImageList imageList, string FileName, bool tf)
        {
            SHFILEINFO fi = new SHFILEINFO();
            if (tf == true)
            {
                int iTotal = (int)SHGetFileInfo(FileName, 0, ref fi, 100, 16640);//SHGFI_ICON|SHGFI_SMALLICON
                try
                {
                    if (iTotal > 0)
                    {
                        Icon ic = Icon.FromHandle(fi.hIcon);
                        imageList.Images.Add(ic);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
            }
            else
            {
                int iTotal = (int)SHGetFileInfo(FileName, 0, ref fi, 100, 257);
                try
                {
                    if (iTotal > 0)
                    {
                        Icon ic = Icon.FromHandle(fi.hIcon);
                        imageList.Images.Add(ic);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
            }
        }
        public void GetDrive()
        {
            treeView1.ImageList = TreeImageList;
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            TreeNode RootNode = new TreeNode("我的电脑", 0, 0);
            treeView1.Nodes.Add(RootNode);
            int iImageIndex = 2; int iSelectedIndex = 2;
            string[] astrDrives = Directory.GetLogicalDrives();
            foreach (string str in astrDrives)
            {
                if (str == "A:\\")
                { iImageIndex = 1; iSelectedIndex = 1; }
                else if (str == "G:\\")
                { iImageIndex = 3; iSelectedIndex = 3; }
                else
                { iImageIndex = 2; iSelectedIndex = 2; }
                TreeNode tnDrive = new TreeNode(str, iImageIndex, iSelectedIndex);
                treeView1.Nodes[0].Nodes.Add(tnDrive);
                AddDirectories(tnDrive);
                if (str == "C:\\")
                { treeView1.SelectedNode = tnDrive; }
            }
            treeView1.EndUpdate();
        }
        void AddDirectories(TreeNode tn)
        {
            tn.Nodes.Clear();
            string strPath = tn.FullPath;
            strPath = strPath.Remove(0, 5);
            DirectoryInfo dirinfo = new DirectoryInfo(strPath);
            DirectoryInfo[] adirinfo;
            try
            {
                adirinfo = dirinfo.GetDirectories();
            }
            catch
            { return; }
            int iImageIndex = 4; int iSelectedIndex = 5;
            foreach (DirectoryInfo di in adirinfo)
            {
                if (di.Name == "RECYCLER" || di.Name == "RECYCLED" || di.Name == "Recycled")
                { iImageIndex = 6; iSelectedIndex = 6; }
                else
                { iImageIndex = 4; iSelectedIndex = 5; }
                TreeNode tnDir = new TreeNode(di.Name, iImageIndex, iSelectedIndex);
                tn.Nodes.Add(tnDir);
            }
           FileInfo[] dirFiles;
           dirFiles=dirinfo.GetFiles();
           int iCount=7;
           foreach (FileInfo fi in dirFiles)
           {
              string str=fi.FullName;
              try
              {
                SetIcon(TreeImageList,str,false);
              }
              catch(Exception ex)
              { MessageBox.Show(ex.Message,"错误提示",0,MessageBoxIcon.Error);}
              TreeNode tnDir = new TreeNode(fi.Name, iCount, iCount);
              tn.Nodes.Add(tnDir);
              iCount++;
           }
        }
        private void treeView1_BeforeExpand_1(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            treeView1.BeginUpdate();
            foreach (TreeNode tn in e.Node.Nodes)
            { AddDirectories(tn); }
            treeView1.EndUpdate();
        }
        protected virtual void InitList(TreeNode tn)
        {
            this.LisrimageList2.Images.Clear();
            this.LisrimageList.Images.Clear();
            Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 3);
            LisrimageList.Images.Add(ic0);
            LisrimageList2.Images.Add(ic0);
            string strPath = tn.FullPath;
            strPath = strPath.Remove(0, 5);
            DirectoryInfo curDir = new DirectoryInfo(strPath);//创建目录对象。
            FileInfo[] dirFiles;
            if (String.IsNullOrEmpty(curDir.Extension))
            {
                try
                {
                    dirFiles = curDir.GetFiles();
                }
                catch { return; }
                int iCount = 0; int iconIndex = 1;//用1，而不用0是要让过0号图标。
                foreach (FileInfo fileInfo in dirFiles)
                {
                    string strFileName = fileInfo.Name;
                    string str = fileInfo.FullName;
                    try
                    {
                        SetIcon(LisrimageList, str, false);
                        SetIcon(LisrimageList2, str, true);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
                    iCount++;
                    iconIndex++;
                }
                strFilePath = strPath;
            }
        }
        private void treeView1_AfterSelect_1(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node.Text == "我的电脑")
            { return; }
            InitList(e.Node);
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            this.panel1.Hide();
        }
        ////*************************************************************************************
    }
}
