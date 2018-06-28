using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace ERM.UI
{
    public partial class frmShowExample : Form
    {
        private string _filePath;
        public frmShowExample(string filePath)
        {
            InitializeComponent();
            this._filePath = filePath;
            Cell1.WorkbookReadonly = true;
        }
        private void frmShowExample_Load(object sender, EventArgs e)
        {
            int ret = Cell1.OpenFile(this._filePath,"");
            if (ret != 1)
            {
                this.Close();
            }
        }
    }
}
