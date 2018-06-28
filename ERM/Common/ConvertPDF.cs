using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using System.Collections;

namespace ERM.UI
{
    public static class ConvertPDF {

        /// <summary>
        /// 图片转换PDF jpg,jpeg,png,tif,tiff
        /// </summary>
        /// <param name="imgfile">图片名称,包含路径</param>
        /// <param name="newPdfFile">pdf文件路径</param>           
        /// <returns>返回转换成功后的PDF文件名称</returns>
        public static bool ImageConvertPdf(string imgfile, string newPdfFile, out string errorMsg) {
            try {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imgfile);
                float percentage = 1;
                float resizedWidht = image.Width;
                float resizedHeight = image.Height;

                while (resizedWidht > (image.Width - 36 - 36) * 0.8) {
                    percentage = percentage * 0.9f;
                    resizedHeight = image.Height * percentage;
                    resizedWidht = image.Width * percentage;
                }
                while (resizedHeight > (image.Height - 36 - 36) * 0.8) {
                    percentage = percentage * 0.9f;
                    resizedHeight = image.Height * percentage;
                    resizedWidht = image.Width * percentage;
                }
                image.ScalePercent(percentage * 100);
                iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(resizedWidht, resizedHeight);
                using (iTextSharp.text.Document doc = new iTextSharp.text.Document(rec)) {
                    PdfWriter write = PdfWriter.GetInstance(doc, new FileStream(newPdfFile, FileMode.Create));
                    doc.Open();
                    doc.Add(image);
                }
                errorMsg = string.Empty;
                return true;
            } catch (Exception ex) {
                errorMsg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// word转换PDF 
        /// </summary>
        /// <param name="wordfile">word文件路径<</param>
        /// <param name="newPdfFile">pdf文件路径</param>
        /// <param name="errorMsg">转换失败后的详细信息</param>
        /// <returns></returns>
        public static bool WordConvertPdf(string wordfile, string newPdfFile, out string errorMsg)
        {
            WdExportFormat exportFormat = WdExportFormat.wdExportFormatPDF;
            object paramMissing = Type.Missing;
            Microsoft.Office.Interop.Word.Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word._Document wordDocument = null;
            try
            {
                object paramSourceDocPath = wordfile;
                string paramExportFilePath = newPdfFile;
                WdExportFormat paramExportFormat = exportFormat;
                bool paramOpenAfterExport = false;
                WdExportOptimizeFor paramExportOptimizeFor = WdExportOptimizeFor.wdExportOptimizeForPrint;
                WdExportRange paramExportRange = WdExportRange.wdExportAllDocument;
                int paramStartPage = 0;
                int paramEndPage = 0;
                WdExportItem paramExportItem = WdExportItem.wdExportDocumentContent;
                bool paramIncludeDocProps = true;
                bool paramKeepIRM = true;
                WdExportCreateBookmarks paramCreateBookmarks = WdExportCreateBookmarks.wdExportCreateWordBookmarks;
                bool paramDocStructureTags = true;
                bool paramBitmapMissingFonts = true;
                bool paramUseISO19005_1 = false;
                wordDocument = wordApplication.Documents.Open(ref paramSourceDocPath, ref paramMissing,
                    ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing,
                    ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing,
                    ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing);
                if (wordDocument != null)
                    wordDocument.ExportAsFixedFormat(paramExportFilePath, paramExportFormat,
                        paramOpenAfterExport, paramExportOptimizeFor, paramExportRange, paramStartPage,
                        paramEndPage, paramExportItem, paramIncludeDocProps, paramKeepIRM, paramCreateBookmarks,
                        paramDocStructureTags, paramBitmapMissingFonts, paramUseISO19005_1, ref paramMissing);
                if (wordDocument != null)
                {
                    wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordDocument = null;
                }
                if (wordApplication != null)
                {
                    wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordApplication = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                errorMsg = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                if (wordDocument != null)
                {
                    wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordDocument = null;
                }
                if (wordApplication != null)
                {
                    wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordApplication = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                errorMsg = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// excel转换PDF 
        /// </summary>
        /// <param name="excelfile">word文件路径<</param>
        /// <param name="newPdfFile">pdf文件路径</param>
        /// <param name="errorMsg">转换失败后的详细信息</param>
        /// <returns></returns>
        public static bool ExcelConvertPdf(string excelfile, string newPdfFile, out string errorMsg)
        {
            object missing = Type.Missing;
            Microsoft.Office.Interop.Excel.XlFixedFormatType excelType = Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF;
            Microsoft.Office.Interop.Excel.ApplicationClass application = null;
            Workbook workBook = null;
            try
            {
                application = new Microsoft.Office.Interop.Excel.ApplicationClass();
                workBook = application.Workbooks.Open(excelfile, missing, missing, missing, missing, missing,
                        missing, missing, missing, missing, missing, missing, missing, missing, missing);

                workBook.ExportAsFixedFormat(excelType, newPdfFile, XlFixedFormatQuality.xlQualityStandard,
                    true, false, missing, missing, missing, missing);
                errorMsg = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.Close(true, missing, missing);
                    workBook = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        ///// <summary>
        ///// 合并PDF文件 
        ///// </summary>
        ///// <param name="fileList">PDF集合</param>
        ///// <param name="outMergeFile">合并后的PDF文件路径</param>
        ///// <param name="outErrorMessage">out 错误信息</param>
        ///// <returns>返回合并后的PDF页数</returns>
        //public static int MergePDFFiles(ArrayList fileList, string outMergeFile, out string outErrorMessage) {
        //    int page = 0;
        //    try {
        //        PdfReader reader;
        //        outErrorMessage = string.Empty;

        //        using (iTextSharp.text.Document document = new iTextSharp.text.Document()) {
        //            PdfImportedPage newPage;
        //            PdfCopy copy = new PdfCopy(document, (new FileStream(outMergeFile, FileMode.Create)));
        //            document.Open();
        //            for (int i = 0; i < fileList.Count; i++) {
        //                reader = new PdfReader(fileList[i].ToString(), null, true);
        //                int iPageNum = reader.NumberOfPages;
        //                for (int j = 1; j <= iPageNum; j++) {
        //                    document.NewPage();
        //                    newPage = copy.GetImportedPage(reader, j);
        //                    copy.AddPage(newPage);
        //                }
        //                reader.Close();
        //            }
        //            copy.Close();
        //            document.Close();
        //            if (File.Exists(outMergeFile)) {
        //                reader = new PdfReader(outMergeFile);
        //                if (reader != null) {
        //                    page = reader.NumberOfPages;
        //                    reader.Close();
        //                }
        //            }
        //        }
        //        return page;
        //    } catch (Exception ex) {
        //        outErrorMessage = ex.Message;
        //        return page;
        //    }
        //}
    }
}
