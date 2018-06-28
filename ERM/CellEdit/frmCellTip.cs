using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERM.UI.CellEdit
{
    public partial class frmCellTip : ERM.UI.Controls.Skin_DevEX
    {
        public frmCellTip(string _HTMValue)
        {
            InitializeComponent();
            this.htmlEditor1.BodyInnerHTML = _HTMValue;
        }
    }
}
