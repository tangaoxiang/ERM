using Microsoft.Office.Interop.Excel;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI.Common
{
    /// <summary>
    /// 组卷和移交打印公共类
    /// </summary>
    public class Print_Common
    {
        private StiReport stiReport = null;
        private string startPath = string.Empty;
        frmReport frmReports = null;

        public Print_Common(string startPath)
        {
            this.startPath = startPath;
        }

        /// <summary>
        /// 打印公共方法
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="dv">数据视图</param>
        /// <returns></returns>
        public void DoPrint(string reportName, DataView dv)
        {
            string reportPath = startPath + @"\Reports\" + reportName + ".mrt";

            ////报表文件是否存在
            if (!System.IO.File.Exists(reportPath))
            {
                TXMessageBoxExtensions.Info("报表文件丢失！");
                return;
            }

            this.stiReport = new StiReport();
            this.stiReport.Load(reportPath);
            this.stiReport.RegData(reportName, dv);
            this.stiReport.Compile();
            this.stiReport.Render();
            string pdfPath = string.Empty;
            string rootPath = startPath + @"\Reports\printPdf_temp\";

            MyCommon.DeleteAndCreateEmptyDirectory(rootPath, true);

            pdfPath = rootPath + reportName + ".pdf";
            stiReport.ExportDocument(StiExportFormat.Pdf, pdfPath);
            frmReports = new frmReport(pdfPath);
            frmReports.ShowDialog();
        }
    }
}
