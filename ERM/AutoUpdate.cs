using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace DigiPower.ERM
{
    public partial class AutoUpdate : Form
    {
        public AutoUpdate()
        {
            InitializeComponent();
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}
