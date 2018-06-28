using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace ERM.UI
{
    public partial class frmDWGCheck : Form
    {
        public frmDWGCheck(ArrayList list)
        {
            InitializeComponent();
            this.listView1.View = View.List;
            foreach (object obj in list)
            {
                this.listView1.Items.Add(obj.ToString());
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
