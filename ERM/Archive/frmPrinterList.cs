using ERM.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ERM.UI
{
    public partial class frmPrinterList : Skin_DevEX
    {
        public frmPrinterList()
        {
            InitializeComponent();
            this.lstPrinter.DataSource=ERM.Common.PrinterOperate.GetPrinterList();
            this.lstPrinter.SelectedItem = ERM.Common.PrinterOperate.GetDefaultPrinterName();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (lstPrinter.SelectedItems.Count == 0)
            {
                MyCommon.Show("ÇëÑ¡Ôñ´òÓ¡»ú£¡");
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        public string GetSelected
        {
            get { return lstPrinter.SelectedItem.ToString(); }
        }
    }
}
