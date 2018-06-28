using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace ERM.UI
{
    public partial class PrintNow : ERM.UI.Controls.Skin_DevEX
    {
        public int index = 0;
        public PrintNow(int Count)
        {
            InitializeComponent();
            lblMsg.Text = "数据转换中！";
            index = Count;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.progressBar1.Value = this.progressBar1.Value + 10;
                if (this.progressBar1.Value >= this.progressBar1.Maximum)
                {
                    this.progressBar1.Value = 0;
                }
            }
            catch { }
        }
    }
}
