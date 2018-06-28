using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace ERM.UI
{
    public partial class frmSignNow : Form
    {
        public int index = 0;
        public frmSignNow(int Count)
        {
            InitializeComponent();
            lblMsg.Text = "数据转换中！";
            index = Count;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = index;
        }
    }
}
