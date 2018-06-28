using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using System.Threading;
using System.Collections;
using System.Xml;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using iTextSharp.text.pdf;
namespace ERM.UI
{
    public partial class ConvertCell2PDF : UserControl
    {
        public ConvertCell2PDF(bool isInit=true)
        {
            if (isInit)
            {
                InitializeComponent();

                this.Cell2.Login("digipower", "11100101845", "1040-1145-0062-4005");
                this.Cell2.LocalizeControl(0x804);
            }
        }
        private string tempPath = Application.StartupPath + "\\tempesaypdf\\";

        string tempFolder =
            System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "erm_temp");

        public int PrintCellToPDF(string cellFileName, string outFileName)
        {
            if (!System.IO.File.Exists(cellFileName))
            {
                return 0;
            }

            string FileExt = System.IO.Path.GetExtension(cellFileName);//文件后缀
            try
            {
                if (FileExt.ToLower() != ".cll")
                {
                    if (FileExt.ToLower() == ".pdf"
                        || FileExt.ToLower() == ".daf")
                    {
                        System.IO.File.Copy(cellFileName, outFileName, true);
                        return this.MergePDFFilesPages(outFileName);
                    }
                    else
                    {
                        if (this.FileConverToPDF(cellFileName, outFileName))
                        {
                            return this.MergePDFFilesPages(outFileName);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyCommon.WriteLog("50cllPdf 转换pdf异常：" + ex.Message);
            }
            //System.Collections.ArrayList fileList = new System.Collections.ArrayList();
            //Cell2.SetPrinter(PrinterOperate.UsePrinterName);
            //Cell2.PrintPara(1, 1, 0, 0); //单色打印

            if (System.IO.Directory.Exists(tempPath))
            {
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath, false);
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath, true);
            }
            else
            {
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath, true);
            }

            ArrayList fileList = new ArrayList();
            try
            {
                if (Cell2.OpenFile(cellFileName, "") != 1)
                    return 0;
            
                Cell2.PrintSetAlign(1, 1);
                Cell2.PrintSetMargin(5, 5, 5, 5);
                Cell2.PrintPara(1, 1, 0, 0); //单色打印
                //Cell2.SetCurSheet(j);
                //Cell2.PrintPageBreak(0);
            }
            catch (Exception ex)
            {
                MyCommon.WriteLog("Cell2 打开错误：" + ex.Message);
            }
            //判断当前页 所有的单元是否只读
            // 如果当前页的所有单元格只读，就不转换PDF
            // 否则 就直接转换PDF
            Assembly asm = Assembly.GetExecutingAssembly();
            string AppPath = asm.Location;
            try
            { 
                bool isToPDF_flg = true;
                for (int j = 0; j < Cell2.GetTotalSheets(); j++)
                {
                    Cell2.SetCurSheet(j);
                    string TittleName = Cell2.GetSheetLabel(j);
                    if (TittleName != null)
                    {
                        if (TittleName.Contains("填表提示") || TittleName.Contains("填表说明") || TittleName.Trim() == "说明")//
                            continue;
                    }

                    string tempoutfileName = Guid.NewGuid().ToString() + ".pdf";
                    isToPDF_flg = true;
                    for (int iRow = 1; iRow < Cell2.GetRows(j) - 1; iRow++)
                    {
                        if (!isToPDF_flg)
                            break;
                        if (Cell2.IsRowHidden(iRow, j) == false && Cell2.GetRowHeight(1, iRow, j) > 10)
                        {
                            for (int iCol = 1; iCol < Cell2.GetCols(j) - 1; iCol++)
                            {
                                if (!isToPDF_flg)
                                    break;
                                if (Cell2.IsColHidden(iCol, j) == false && Cell2.GetColWidth(1, iCol, j) > 10)
                                {
                                    if (Cell2.GetCellInput(iCol, iRow, j) != 5)
                                    {
                                        isToPDF_flg = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if ((!isToPDF_flg))
                    {
                        //ConverToPDF.PreparePrint(Assembly.GetExecutingAssembly().FullName, "", tempPath + tempoutfileName);
                        //Cell2.PrintSheet(0, j);
                        //ConverToPDF.Wait4PringFinish("", tempPath + tempoutfileName);
                        if (Cell2.ExportPdfFile(tempPath + tempoutfileName, j, 0, 1))
                            fileList.Add(tempPath + tempoutfileName);
                    }
                }
                Cell2.closefile();
            }
            catch (Exception ex)
            {
                MyCommon.WriteLog("Cell2 转换PDF错误：" + ex.Message);
            }
            #region
            /*
            //Cell2.ExportPdfFile(tempPath + tempoutfileName, -1, 0, Cell2.GetTotalSheets());


            //for (int j = 0; j < Cell2.GetTotalSheets(); j++)
            //{
            //    string TittleName = Cell2.GetSheetLabel(j);
            //    if (!TittleName.Contains(Globals.Descriptive))
            //    {
            //        fileList.Add(tempFile + j.ToString() + ".pdf");
            //        outFile = tempFile + j.ToString() + ".pdf";
            //        NewPrint();
            //        oPrinterMonitor.OnPrinterInit += new _IPrinterMonitorEvents_OnPrinterInitEventHandler(oPrinterMonitor_OnPrinterInit);
            //        Cell2.PrintSheet(0, j);
            //        oPrinterMonitor.OnPrinterInit -= new _IPrinterMonitorEvents_OnPrinterInitEventHandler(oPrinterMonitor_OnPrinterInit);
            //        Application.DoEvents();
            //    }
            //}

            //foreach (object obj in fileList)
            //{
            //    if(!System.IO.File.Exists(obj.ToString()))
            //    {
            //        fileList.Remove(obj);
            //    }
            //}
            //if (fileList.Count <= 0)
            //{
            //    return 0;
            //}
            * */
            #endregion
            string[] FileName = new string[fileList.Count];
            for (int i = 0; i < fileList.Count; i++)
            {
                FileName[i] = fileList[i].ToString();
            }
            if (FileName.Length <= 0)
            {
                return 0;
            }
            return MergePDFFilesPages(outFileName);
        }
        /// <summary>
        /// 返回页数
        /// </summary>
        /// <param name="FileList"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public int MergePDF(string[] FileList, string FileName)
        {
            if (System.IO.File.Exists(FileName))
            {
                System.IO.File.Delete(FileName);
            }
            int iPageCount = 0;
            if (FileList.Length == 1)
            {
                System.IO.File.Copy(FileList[0], FileName, true);
                /*
                 * 修改人：侯波
                 * 修改时间：2017-04-12
                 * 描述：拖入一页电子文件计算页数
                 */
                if (File.Exists(FileName))
                {
                    try
                    { 
                        PdfReader reader1;
                        reader1 = new PdfReader(FileName);
                        if (reader1 != null)
                        {
                            iPageCount = reader1.NumberOfPages;
                            reader1.Close();
                            reader1.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        MyCommon.WriteLog("Cell2 MergeMultiPdf合并PDF异常：" + ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    #region 金格合并
                    //List<Stream> FSList = new List<Stream>();
                    //foreach (string file_pdf in FileList)
                    //{
                    //    FSList.Add(new FileStream(file_pdf, FileMode.Open));
                    //}
                    //using (FileStream os = new FileStream(FileName, FileMode.Create, FileAccess.ReadWrite))
                    //{
                    //    com.kinggrid.pdf.KGPdfHummerUtils.MergeMultiPdf(FSList, os);
                    //    if (System.IO.File.Exists(FileName))
                    //    {
                    //        iPageCount = MergePDFFilesPages(FileName);
                    //    }
                    //    else
                    //    {
                    //        MyCommon.WriteLog("合并PDF错误");
                    //    }
                    //}
                    #endregion

                    PdfReader reader;
                    using (iTextSharp.text.Document document = new iTextSharp.text.Document())
                    {
                        PdfImportedPage newPage;
                        PdfCopy copy = new PdfCopy(document, (new FileStream(FileName, FileMode.Create)));
                        document.Open();
                        for (int i = 0; i < FileList.Length; i++)
                        {
                            reader = new PdfReader(FileList[i], null, true);
                            int iPageNum = reader.NumberOfPages;
                            for (int j = 1; j <= iPageNum; j++)
                            {
                                document.NewPage();
                                newPage = copy.GetImportedPage(reader, j);
                                copy.AddPage(newPage);
                            }
                            reader.Close();
                            reader.Dispose();
                        }
                        document.Close();
                        document.Dispose();
                        if (File.Exists(FileName))
                        {
                            reader = new PdfReader(FileName);
                            if (reader != null)
                            {
                                iPageCount = reader.NumberOfPages;
                                reader.Close();
                                reader.Dispose();
                            }
                        }
                        copy.Close();
                        copy.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MyCommon.WriteLog("Cell2 MergeMultiPdf合并PDF异常：" + ex.Message);
                }
            }
            return iPageCount;
        }
        /// <summary>
        /// 返回页数 PdfReader
        /// </summary>
        /// <param name="outMergeFile"></param>
        /// <returns></returns>
        public int MergePDFFilesPages(string outMergeFile)
        {
            int page = 0;
            PdfReader reader;
            try
            {
                using (iTextSharp.text.Document document = new iTextSharp.text.Document())
                {
                    if (File.Exists(outMergeFile))
                    {
                        reader = new PdfReader(outMergeFile);
                        if (reader != null)
                        {
                            page = reader.NumberOfPages;
                            reader.Close();
                            reader.Dispose();
                        }
                    }
                    document.Close();
                    document.Dispose();
                  
                    File.SetAttributes(outMergeFile, FileAttributes.Normal);
                }
                
                return page;
            }
            catch (Exception ex)
            {
                MyCommon.WriteLog("取PDF页数报错" + ex.Message);
                return page;
            }
        }
        /// <summary>
        /// 文件转换成PDF
        /// </summary>
        /// <param name="fnOri">源文件</param>
        /// <param name="fnPDF">生成的PDF文件</param>
        /// <returns></returns>
        private bool FileConverToPDF(string fnOri, string fnPDF)
        {
            //.JPG,.JPEG,.PNG,.GIF,.BMP,.DOC,.DOCX,.XLS,.XLSX,.TIF,.TIFF,.PDF
            bool result_flg = false;
            string sExt = System.IO.Path.GetExtension(fnOri);
            if (sExt.Equals(".jpg", StringComparison.InvariantCultureIgnoreCase) ||
                sExt.Equals(".jpeg", StringComparison.InvariantCultureIgnoreCase) ||
                sExt.Equals(".tif", StringComparison.InvariantCultureIgnoreCase) ||
                sExt.Equals(".tiff", StringComparison.InvariantCultureIgnoreCase) ||
                sExt.Equals(".bmp", StringComparison.InvariantCultureIgnoreCase) ||
                sExt.Equals(".png", StringComparison.InvariantCultureIgnoreCase) ||
                sExt.Equals(".gif", StringComparison.InvariantCultureIgnoreCase) ||
                sExt.Equals(".doc", StringComparison.InvariantCultureIgnoreCase) ||
                sExt.Equals(".docx", StringComparison.InvariantCultureIgnoreCase) ||
                sExt.Equals(".xls", StringComparison.InvariantCultureIgnoreCase) ||
                sExt.Equals(".xlsx", StringComparison.InvariantCultureIgnoreCase))
            {
                MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, false);
                MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, true);
                try
                {
                    using (TransAndSignFile.UserControl1 s = new TransAndSignFile.UserControl1())
                    {
                        if (s.TransFileToPDF(fnOri, tempFolder, "error"))
                        {
                            string file_pdf = Path.Combine(tempFolder, Path.GetFileNameWithoutExtension(fnOri) + ".pdf");
                            if (File.Exists(file_pdf))
                            {
                                File.Copy(file_pdf, fnPDF, true);
                            }
                            result_flg = true;
                        }
                        else
                        {
                            MyCommon.WriteLog("ConvertCell2PDF转换PDF错误：" + s.GetLastError());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MyCommon.WriteLog("ConvertCell2PDF转换PDF错误：" + fnOri + " " + ex.Message);
                }
            }
            return result_flg;
        }
        /// <summary>
        /// 获取PDf文件页数
        /// </summary>
        /// <param name="pdfFile">pdf文件路径</param>
        /// <returns></returns>
        public int GetPDFPageCount(string pdfFile)
        {
            int relust_flg = 0;
            if (pdfFile != null
                && pdfFile != ""
                && System.IO.File.Exists(pdfFile))
            {
                try
                {
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                    axSPApplication1.Documents.Open(pdfFile);
                    relust_flg = axSPApplication1.Documents.ActiveDocument.Pages.Count;
                }
                catch (Exception ex)
                {
                    MyCommon.WriteLog("读取PDF失败！错误信息：" + ex.Message);
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                }
                finally
                {
                    if (axSPApplication1.Documents.ActiveDocument != null)
                    {
                        axSPApplication1.Documents.CloseAll();
                    }
                }
            }
            else
            {
                if (axSPApplication1.Documents.ActiveDocument != null)
                    axSPApplication1.Documents.CloseAll();
            }
            return relust_flg;
        }

        /// <summary>
        /// 批量打印
        /// </summary>
        /// <param name="pdfNames">打印的PDF数组</param>
        public void BathPrintPDF(string[] pdfNames)
        {
            foreach (string pdfFile in pdfNames)
            {
                if (pdfFile != null
                    && pdfFile != ""
                    && System.IO.File.Exists(pdfFile))
                {
                    try
                    {
                        if (axSPApplication1.Documents.ActiveDocument != null)
                            axSPApplication1.Documents.CloseAll();
                        axSPApplication1.Documents.Open(pdfFile);
                        axSPApplication1.Documents.ActiveDocument.PrintOut("", null, 1 - 2 - 4 - 256);
                        Thread.Sleep(800);
                    }
                    catch (Exception ex)
                    {
                        MyCommon.WriteLog("读取PDF失败！错误信息：" + ex.Message);
                        if (axSPApplication1.Documents.ActiveDocument != null)
                            axSPApplication1.Documents.CloseAll();
                    }
                    finally
                    {
                        if (axSPApplication1.Documents.ActiveDocument != null)
                            axSPApplication1.Documents.CloseAll();
                    }
                }
                else
                {
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                }
            }
        }

        /// <summary>
        /// 单个打印
        /// </summary>
        /// <param name="pdfNames">打印的PDF</param>
        public void BathPrintPDF(string pdfFile)
        {
            //打印章不显示
            //参数1 打印机名称 string
            //参数2 打印页面范围 连续页面范围 "1-9", 默认传值为Missing 打印全部页
            //参数3 打印内容选项，下面几个值的或值 1：文档内容 2：批注 4：图章 8：表单 256 灰度 int  参数3传值显示签章为"1-2-4"，不显示签章则传值为"1-2";不显示签章则传值为"1";
            //参数4 打印份数 int
            //参数5 后台打印 boolean

            if (pdfFile != null
                && pdfFile != ""
                && System.IO.File.Exists(pdfFile))
            {
                try
                {
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                    axSPApplication1.Documents.Open(pdfFile);
                    axSPApplication1.Documents.ActiveDocument.PrintOut("", null, 1 - 2 - 4 - 256);
                }
                catch (Exception ex)
                {
                    MyCommon.WriteLog("读取PDF失败！错误信息：" + ex.Message);
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                }
                finally
                {
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                }
            }
            else
            {
                if (axSPApplication1.Documents.ActiveDocument != null)
                    axSPApplication1.Documents.CloseAll();
            }
        }
        /// <summary>
        /// 检查PDF文件是否有签章，并返回签章数量
        /// </summary>
        /// <param name="pdfName">PDF文件</param>
        /// <returns>int：签章数量</returns>
        public int GetPDFKEYCount(string pdfName)
        {
            int KeyCount = 0;
            if (pdfName != null
                && pdfName != ""
                && System.IO.File.Exists(pdfName))
            {
                try
                {
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                    axSPApplication1.Documents.Open(pdfName);
                    KeyCount = axSPApplication1.Documents.ActiveDocument.Fields.SignatureCount;
                }
                catch (Exception ex)
                {
                    MyCommon.WriteLog("读取PDF失败！错误信息：" + ex.Message);
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                }
                finally
                {
                    if (axSPApplication1.Documents.ActiveDocument != null)
                        axSPApplication1.Documents.CloseAll();
                }
            }
            else
            {
                if (axSPApplication1.Documents.ActiveDocument != null)
                    axSPApplication1.Documents.CloseAll();
            }
            return KeyCount;
        }

        public List<ConvertPdfFile> GeneratePDFList(ListView.SelectedListViewItemCollection ListItems, frm2PDFProgressMsg dlg, string strNameBK = "", TreeNodeEx targeNode = null)
        {
            List<ConvertPdfFile> cplist=new List<ConvertPdfFile>();
            int i1 = 0;
            TransAndSignFile.UserControl1 s = null;
            s = new TransAndSignFile.UserControl1();
            
                foreach (ListViewItem item in ListItems)
                {
                    string eFileID = Guid.NewGuid().ToString();
                    string fnOri = item.Name;
                    string sExt = System.IO.Path.GetExtension(fnOri);
                    string fnPDF = Globals.ProjectPath + "PDF\\" + eFileID + ".pdf";
                    if ((sExt.Equals(".jpg", StringComparison.InvariantCultureIgnoreCase) ||
                        sExt.Equals(".jpeg", StringComparison.InvariantCultureIgnoreCase) ||
                        sExt.Equals(".tif", StringComparison.InvariantCultureIgnoreCase) ||
                        sExt.Equals(".tiff", StringComparison.InvariantCultureIgnoreCase) ||
                        sExt.Equals(".bmp", StringComparison.InvariantCultureIgnoreCase) ||
                        sExt.Equals(".png", StringComparison.InvariantCultureIgnoreCase) ||
                        sExt.Equals(".gif", StringComparison.InvariantCultureIgnoreCase) ||
                        sExt.Equals(".doc", StringComparison.InvariantCultureIgnoreCase) ||
                        sExt.Equals(".docx", StringComparison.InvariantCultureIgnoreCase) ||
                        sExt.Equals(".xls", StringComparison.InvariantCultureIgnoreCase) ||
                        sExt.Equals(".xlsx", StringComparison.InvariantCultureIgnoreCase)) && fnOri != "")
                    {
                        MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, false);
                        MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, true);
                        try
                        {
                            i1++;
                            if (dlg.label2.Text != "")
                            {
                                dlg.label2.Text = "正在导入：" + i1.ToString() + "/" + ListItems.Count.ToString();
                                dlg.progressBar1.Value = i1;
                                Application.DoEvents();
                            }
                            targeNode.Text = "导入中(" + i1 + "/" + ListItems.Count + ") " + strNameBK;
                            if (s.TransFileToPDF(fnOri, tempFolder, "error"))
                            {
                                string file_pdf = Path.Combine(tempFolder, Path.GetFileNameWithoutExtension(fnOri) + ".pdf");
                                if (File.Exists(file_pdf))
                                {
                                    File.Copy(file_pdf, fnPDF);
                                }
                                ConvertPdfFile cp=new ConvertPdfFile();
                                cp.SourceFilePath = fnOri;
                                cp.PDFFilePath = fnPDF;
                                cplist.Add(cp);
                            }
                            else
                            {
                                MyCommon.WriteLog("转换PDF错误：" + s.GetLastError());
                            }
                        }
                        catch (Exception ex)
                        {
                            MyCommon.WriteLog("转换PDF错误：" + fnOri + " " + ex.Message);
                        }
                    }
                }
                if (dlg != null)
                {
                    dlg.Close();
                }
                if (s != null)
                {
                    s = null;
                }
            return cplist;
        }
    }
}
