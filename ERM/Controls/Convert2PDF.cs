using System;
using System.Collections.Generic;
using System.Text;
//using BCL.easyPDF6.Interop.EasyPDFPrinter.Digipower;
//using BCL.easyPDF6.Interop.EasyPDFProcessor.Digipower;
using System.Threading;
namespace ERM.UI
{
    public class Convert2PDF:IDisposable
    {
        //public int Print2PDF(string inFile, string outFile)
        //{
        //    try
        //    {
        //        Printer oPrinter = null;
        //        PrintJob oPrintJob = null;
        //        Type type = Type.GetTypeFromProgID("easyPDF.Printer.Digipower.6");
        //        oPrinter = (Printer)Activator.CreateInstance(type);
        //        oPrinter.Initialize("Digipower PDF Printer");
        //        oPrinter.LicenseKey = Globals.LicenseKey;
        //        oPrintJob = oPrinter.PrintJob;
        //        oPrintJob.PDFSetting.FontEmbedAsType0 = true;
        //        oPrintJob.PDFSetting.FontEmbedding = prnFontEmbedding.PRN_FONT_EMBED_SUBSET;
        //        oPrintJob.PDFSetting.FontSubstitution = prnFontSubstitution.PRN_FONT_SUBST_PDF;
        //        oPrintJob.PrintOut(CheckEFile(inFile), outFile);

        //        int PageCount = 0;
        //        if (System.IO.File.Exists(outFile))
        //        {
        //            PDFProcessor processor = new PDFProcessor();
        //            processor.Initialize("Digipower PDF Printer");
        //            processor.LicenseKey = Globals.LicenseKey;
        //            PageCount = processor.GetPageCount(outFile, "");
        //        }
        //        return PageCount;
        //    }
        //    catch { return 0; }
        //}

        //public int GetPDFPageCount(string outFile)
        //{
        //    try
        //    {
        //        Printer oPrinter = null;
        //        PrintJob oPrintJob = null;
        //        Type type = Type.GetTypeFromProgID("easyPDF.Printer.Digipower.6");
        //        oPrinter = (Printer)Activator.CreateInstance(type);
        //        oPrinter.Initialize("Digipower PDF Printer");
        //        oPrinter.LicenseKey = Globals.LicenseKey;
        //        oPrintJob = oPrinter.PrintJob;
        //        oPrintJob.PDFSetting.FontEmbedAsType0 = true;
        //        oPrintJob.PDFSetting.FontEmbedding = prnFontEmbedding.PRN_FONT_EMBED_SUBSET;
        //        oPrintJob.PDFSetting.FontSubstitution = prnFontSubstitution.PRN_FONT_SUBST_PDF;

        //        int PageCount = 0;
        //        if (System.IO.File.Exists(outFile))
        //        {
        //            PDFProcessor processor = new PDFProcessor();
        //            processor.Initialize("Digipower PDF Printer");
        //            processor.LicenseKey = Globals.LicenseKey;
        //            PageCount = processor.GetPageCount(outFile, "");
        //        }
        //        return PageCount;
        //    }
        //    catch { return 0; }
        //}

        ///// <summary>
        /////  将需要合并的电子文件进行
        /////  检查和移交到 “我的文档” 目录下
        ///// </summary>
        ///// <param name="efile_Name">电子文件</param>
        ///// <returns>返回“我的目录” 文件</returns>
        //private string CheckEFile(string efile_Name)
        //{
        //    string tempFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    tempFolder = System.IO.Path.Combine(tempFolder, "erm_temp");
        //    MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, false);
        //    MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, true);

        //    string tempEFile = System.IO.Path.Combine(tempFolder, System.IO.Path.GetFileName(efile_Name));
        //    System.IO.File.Copy(efile_Name, tempEFile, true);
        //    return tempEFile;
        //}
        ///// <summary>
        /////  多文件合并PDF
        ///// </summary>
        ///// <param name="efile_list">需要合并的PDF数组</param>
        ///// <returns>string[] 数组集合</returns>
        //private string[] CheckEFiles(object efile_list)
        //{
        //    string tempFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    tempFolder = System.IO.Path.Combine(tempFolder, "erm_temp");
        //    MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, false);
        //    MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, true);

        //    string[] FileList = efile_list as string[];
        //    string[] mergeList = new string[FileList.Length];
        //    string tempEFile = null;
        //    for (int i = 0; i < FileList.Length; i++)
        //    {
        //        string efile_Name = FileList[i];
        //        tempEFile = System.IO.Path.Combine(tempFolder, System.IO.Path.GetFileName(efile_Name));
        //        System.IO.File.Copy(efile_Name, tempEFile, true);
        //        mergeList[i] = tempEFile;
        //    }
        //    return mergeList;
        //}

        //#region IDisposable 成员

        //void IDisposable.Dispose()
        //{
        //    Dispose();
        //}

        /// <summary>
        /// 释放SQLBaseDALImpl对象
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //#endregion
    }
}
