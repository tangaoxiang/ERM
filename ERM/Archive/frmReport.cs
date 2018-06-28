using System;
using System.Data;
using System.Windows.Forms;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using System.IO;
using System.Drawing.Printing;
using Spire.Pdf;
using TX.Framework.WindowUI.Forms;
using System.Collections;

namespace ERM.UI
{
    public partial class frmReport : ERM.UI.Controls.Skin_DevEX
    {
        /// <summary>
        /// 报表显示构造涵数传参
        /// </summary>
        /// <param name="reportPath">报表对象</param>
        /// <param name="dv">视图数据</param>
        /// <param name="reportName">报表名称</param>
        public frmReport(string reportPath)
        {
            InitializeComponent();
            try
            {
                ShowPDF(reportPath);
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 设置显示PDF
        /// </summary>
        /// <param name="pdfPath">pdf路径</param>
        private void ShowPDF(string pdfPath)
        {
            if (pdfPath != null
              && pdfPath != ""
              && System.IO.File.Exists(pdfPath))
            {
                try
                {
                    if (axsp.Documents.ActiveDocument != null)
                        axsp.Documents.CloseAll();
                    axsp.Documents.Open(pdfPath);
                }
                catch (Exception ex)
                {
                    MyCommon.WriteLog("读取PDF失败！错误信息：" + ex.Message);
                    if (axsp.Documents.ActiveDocument != null)
                        axsp.Documents.CloseAll();
                }
            }
            else
            {
                if (axsp.Documents.ActiveDocument != null)
                    axsp.Documents.CloseAll();
            }
        }
    }
}
