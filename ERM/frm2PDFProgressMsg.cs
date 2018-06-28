using ERM.UI.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace ERM.UI
{
    public partial class frm2PDFProgressMsg : Skin_DevEX
    {
        public frm2PDFProgressMsg()
        {
            InitializeComponent();
        }

        private void frm2PDFProgressMsg_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            //e.Cancel = true;
        }

        private void frm2PDFProgressMsg_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
