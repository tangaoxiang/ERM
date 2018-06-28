using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using ERM.Common;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    public partial class frmPrintBat : ERM.UI.Controls.Skin_DevEX
    {
        private const int SC_CLOSE = 0xF060;
        private const int MF_ENABLED = 0x00000000;
        private const int MF_GRAYED = 0x00000001;
        private const int MF_DISABLED = 0x00000002;
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, int bRevert);
        [DllImport("User32.dll")]
        public static extern bool EnableMenuItem(IntPtr hMenu, int uIDEnableItem, int uEnable);
        private List<TreeNode> Nodes;
        private DelPrint TargetMothod;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nodes">案卷集合</param>
        public frmPrintBat(List<TreeNode> _nodes,DelPrint _del)
        { 
            InitializeComponent();
            Nodes = _nodes;
            TargetMothod = _del;
            for (int i = 0; i < _nodes.Count; i++)
            {
                lstFiles.Items.Add(_nodes[i].Text);
            }
        }
        private void frmPrintCell_Load(object sender, EventArgs e)
        {
        }
        private void lstFiles_Click(object sender, EventArgs e)
        {
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lstFiles.Items.Count; i++)
            {
                lstFiles.SetItemChecked(i, chkAll.Checked);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lstFiles.CheckedItems.Count == 0) return;
          // frmPrinterList frm = new frmPrinterList();
          //DialogResult drs = frm.ShowDialog();
            //if (drs != DialogResult.OK)
             //   return;
           // string printername = frm.GetSelected;
            string strDefault = PrinterOperate.GetDefaultPrinterName();
            //if (string.Compare(strDefault, printername, true) != 0)
           // {
           //     PrinterOperate.SetPrinter(printername);
          //  }
            try
            {
                //btnPrint.Enabled = false;
                btnCancel.Enabled = false;
                //lstFiles.Enabled = false;
                //chkAll.Enabled = false;
                IntPtr hMenu = GetSystemMenu(this.Handle, 0);
                EnableMenuItem(hMenu, SC_CLOSE, MF_DISABLED | MF_GRAYED);

                List<string> selectID = new List<string>();
                for (int i = 0; i < lstFiles.Items.Count; i++)
                {
                    if (lstFiles.GetItemChecked(i))
                    {
                        selectID.Add(Nodes[i].Tag.ToString());
                    }
                }

                TargetMothod(selectID);
               
                //if (string.Compare(strDefault, printername, true) != 0)
               // {
               //     PrinterOperate.SetPrinter(strDefault);
               // }
                btnCancel.Enabled = true;
                hMenu = GetSystemMenu(this.Handle, 0);
                EnableMenuItem(hMenu, SC_CLOSE, MF_ENABLED);
                
               // TXMessageBoxExtensions.Info("打印任务已经全部输送到打印机，现在可以关闭窗口了，请耐心等待打印机的处理。");
            }
            catch (Exception ex)
            {
                btnPrint.Enabled = true;
                btnCancel.Enabled = true;
               // if (string.Compare(strDefault, printername, true) != 0)
               // {
               //     PrinterOperate.SetPrinter(strDefault);
               // }                
            }
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
