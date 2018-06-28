using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using System.IO;
namespace ERM.UI
{
    public partial class FrmDeleteDwgFont : Form
    {
        string[] _dirNames;
        string DWGFont = Globals.DWGFont + "\\";
        public FrmDeleteDwgFont()
        {
            InitializeComponent();
            _dirNames = System.IO.Directory.GetDirectories(DWGFont);
            this.listView1.View = View.List;
            foreach (string str in _dirNames)
            {
                this.listView1.Items.Add(str);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = Environment.UserName;
                FolderBrowserDialog FolderBrowserDialog1 = new FolderBrowserDialog();
                FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
                FolderBrowserDialog1.ShowNewFolderButton = false;
                if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.label2.Text = "正在导入文件!";
                    string path = FolderBrowserDialog1.SelectedPath;
                    string pathname = FolderBrowserDialog1.SelectedPath.Substring(FolderBrowserDialog1.SelectedPath.LastIndexOf("\\") + 1);
                    if (!System.IO.Directory.Exists(DWGFont + pathname))
                    {
                        System.IO.Directory.CreateDirectory(DWGFont + pathname);
                    }
                    string[] FileNames = Directory.GetFiles(path);
                    string NewFileName = null;
                    foreach (string str in FileNames)
                    {
                        NewFileName = str.Substring(str.LastIndexOf("\\") + 1);
                        System.IO.File.Copy(str, DWGFont + pathname + "\\" + NewFileName, true);
                        FileAttributes attrs = System.IO.File.GetAttributes(DWGFont + pathname + "\\" + NewFileName);
                        if (attrs.ToString().ToUpper().LastIndexOf("READONLY")>=0)
                        {
                            System.IO.File.SetAttributes(DWGFont + pathname + "\\" + NewFileName, FileAttributes.Normal);
                        }
                    }
                    this.listView1.Items.Add(DWGFont + pathname);
                    this.label2.Text = "导入成功!";
                }
            }
            catch
            {
                MyCommon.Show("DWG字库文件导入失败!!");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.CheckedListViewItemCollection items = this.listView1.CheckedItems;
                this.label2.Text = "正在删除文件!";
                while(items.Count>0)
                {
                    if (System.IO.Directory.Exists(items[0].Text))
                    {
                        MyCommon.DeleteAndCreateEmptyDirectory(items[0].Text);
                        listView1.Items.Remove(items[0]);
                    }
                }
                this.label2.Text = "删除成功!";
            }
            catch
            {
                MyCommon.Show("DWG字库文件删除失败!!");
            }
        }
    }
}
