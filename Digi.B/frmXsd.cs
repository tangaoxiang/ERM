using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Digi.B
{
    public partial class frmXsd : Form
    {
        public frmXsd()
        {
            InitializeComponent();
            UpDown1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if( Functions.IsInt(UpDown1.Text))
           {
            this.DialogResult = DialogResult.OK;
           }
            else
               Functions.ShowWarning("请输一个0-5的整数！");
        }
    }
}