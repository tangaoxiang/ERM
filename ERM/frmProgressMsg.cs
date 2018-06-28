using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ERM.UI
{
    public partial class frmProgressMsg:ERM.UI.Controls.Skin_DevEX
    {
        public frmProgressMsg()
        {
            InitializeComponent();
        }
        BackgroundWorker backgroundWorker;
        public frmProgressMsg(BackgroundWorker _backgroundWorker)
        {
            InitializeComponent();
            backgroundWorker = _backgroundWorker;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            this.Dispose();
        }
        /// <summary>
        /// 显示状态
        /// </summary>
        /// <param name="ProgressValue">Values 进度</param>
        public void SetProcessValue(int ProgressValue)
        {
            if (pbProcess.Value <= ProgressValue)
                pbProcess.Value = ProgressValue;
            else
                pbProcess.Value = pbProcess.Maximum;
            lbl_Message.Text = ProgressValue + "%";
        }

        /// <summary>
        /// 显示状态
        /// </summary>
        /// <param name="ProgressValue">Values 进度</param>
        /// <param name="showText">显示文字提示</param>
        public void SetProcessValue(int ProgressValue, string showText)
        {
            if (pbProcess.Value <= ProgressValue)
                pbProcess.Value = ProgressValue;
            else
                pbProcess.Value = pbProcess.Maximum;

            lbl_Message.Text = showText;
        }

        private void frmProgressMsg_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btn_Cancel_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click_2(object sender, EventArgs e)
        {

        }
    }
}
