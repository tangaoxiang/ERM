using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    public partial class frmCellFillRnd : ERM.UI.Controls.Skin_DevEX
    {
        public frmCellFillRnd()
        {
            InitializeComponent();
        }
        private double minData;
        private double maxData;
        private bool isInt;
        public double MinData
        {
            get { return minData; }
            set { minData = value; }
        }
        public double MaxData
        {
            get { return maxData; }
            set { maxData = value; }
        }
        public bool IsInt
        {
            get { return isInt; }
            set { isInt = value; }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtMin.Text.Trim() == "" || txtMax.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("输入不完整！");
                return;
            }
            if (!MyCommon.IsNumeric(txtMin.Text.Trim()) || !MyCommon.IsNumeric(txtMax.Text.Trim()))
            {
                TXMessageBoxExtensions.Info("请输入数值！");
                return;
            }
            if (Convert.ToDouble(txtMin.Text.Trim()) >= Convert.ToDouble(txtMax.Text.Trim()))
            {
                TXMessageBoxExtensions.Info("最大值必须大于最小值！");
                return;
            }
            IsInt = true;
            if (txtMin.Text.Contains(".") || txtMax.Text.Contains("."))
            {
                IsInt = false;
            }
            MinData = Convert.ToDouble(txtMin.Text.Trim());
            MaxData = Convert.ToDouble(txtMax.Text.Trim());
            this.DialogResult = DialogResult.OK;
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
