using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERM.UI
{
    public partial class frmTemplateInfo : ERM.UI.Controls.Skin_DevEX
    {
        string _cellID = String.Empty;
        public frmTemplateInfo(string cellID)
        {
            InitializeComponent();
            _cellID = cellID;
        }
        private void showCell(string cellID)
        {
            IList<MDL.T_CellFileTemplate> EFTemplate_List =
               (new BLL.T_CellFileTemplate_BLL()).FindByFileID(cellID);
            if (EFTemplate_List != null && EFTemplate_List.Count > 0)
            {
                string CelllTplFile = Application.StartupPath + "\\Template\\FL" + EFTemplate_List[0].filepath;
                if (System.IO.File.Exists(CelllTplFile))
                {
                    int retValue = axCell1.OpenFile(CelllTplFile, "");
                    axCell1.HScrollHeight = 1;
                    //Cell2.VScrollWidth = 0;
                    if (axCell1.GetTotalSheets() > 1)
                        axCell1.SetCurSheet(0);
                }
                else
                {
                    axCell1.OpenFile(Globals.BlankCell, "");
                }
            }
            else
            {
                axCell1.OpenFile(Globals.BlankCell, "");
            }
        }

        private void frmTemplateInfo_Load(object sender, EventArgs e)
        {
            showCell(_cellID);
        }
    }
}
