using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using ICSharpCode.SharpZipLib.Zip;
using System.Windows.Forms;
using System.IO;
namespace ERM.UI
{
    /// <summary>
    /// Excel导入文件条目信息
    /// </summary>
    public class ExcelHelp
    {
        /// <summary>
        /// 读取Excel数据
        /// </summary>
        /// <param name="filePath">excel文件路径</param>
        /// <returns></returns>
        public DataTable GetData(string filePath, bool bTitle)
        {
            #region
            //string strConn = string.Concat("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=",
            //filePath, ";extended properties='Excel 8.0;HDR=" + (bTitle ? "YES" : "NO") + ";IMEX=1;'");
            //返回Excel的架构，包括各个sheet表的名称,类型，创建日期和修改时间等 
            //string strTableName = string.Empty;
            ////包含excel中表名的字符串数组
            //for (int k = 0; k < dtSheetName.Rows.Count; k++)
            //{
            //    if (dtSheetName.Rows[k]["TABLE_NAME"] != null &&
            //        dtSheetName.Rows[k]["TABLE_NAME"].ToString().Replace("'", "").EndsWith("$"))
            //    {
            //        strTableName = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
            //        if (strTableName.Contains("文件信息目录"))
            //        {
            //            break;
            //        }
            //    }
            //}
            //if (!string.IsNullOrWhiteSpace(strTableName))
            //{
            //    string str = "select * from [" + strTableName + "]";
            //    OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
            //    da.Fill(ds, strTableName.Replace("$", "").ToLower());
            //    da.Dispose();
            //}
            #endregion
                DataTable dtSheetName = new DataTable();
                try
                {
                     dtSheetName = ExcelToDataTable(filePath, "文件信息目录", true);
                }
                catch (Exception ex)
                {
                    MyCommon.WriteLog("导入Excel错误：" + ex.Message);
                }               
            return dtSheetName;
        }

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string fileName,string sheetName, bool isFirstRowColumn)
        {
            IWorkbook workbook = null;
            FileStream fs = null;
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            int wjtmindex = 0;
            DataColumn column = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.Contains(".xlsx"))
                    workbook = new XSSFWorkbook(fs);
                else
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue == "文件题名")
                                {
                                    wjtmindex = i;
                                }
                                if (cellValue != null)
                                {
                                    if (cellValue == "序号")//序号需要做排序
                                    {
                                        column = new DataColumn(cellValue,typeof(Int32));
                                    }
                                    else
                                    {
                                        column = new DataColumn(cellValue);
                                    }
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null || row.FirstCellNum<0) continue; //没有数据的行默认是null　　　　　　　
                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            {
                                ICell ic = row.GetCell(j);
                                switch(ic.CellType)
                                {
                                    case CellType.Numeric:
                                        if (HSSFDateUtil.IsCellDateFormatted(ic))
                                            dataRow[j] = ic.DateCellValue;
                                        else
                                            dataRow[j] = ic.NumericCellValue.ToString();
                                        break;
                                    case CellType.String:
                                        dataRow[j] = ic.StringCellValue.ToString();
                                        break;
                                    default:
                                      break;
                                }
                            }
                        }
                        if (row.GetCell(wjtmindex) != null && row.GetCell(wjtmindex).ToString() != "")
                            data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="FileName">文件名称</param>
        /// <param name="exceltype">是否模板</param>
        public void DataTableToExcel(DataTable dtSource, string ExportType, string strHeaderText,string FileName = "")
        {
            NPOI.SS.UserModel.IWorkbook workbook = null;
            SaveFileDialog savefd = new SaveFileDialog();

            if (FileName != "")
                savefd.FileName = FileName + ".xls";
            savefd.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            if (savefd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            if (savefd.FilterIndex == 1)
            {
                workbook = new NPOI.HSSF.UserModel.HSSFWorkbook();
            }
            else
            {
                workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
            }

            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(ExportType);            
            HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = SetExcelColWidth(dtSource, ExportType);

            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = (HSSFSheet)workbook.CreateSheet(ExportType);
                    }
                    #region 表头及样式
                    {
                        if (strHeaderText != "")
                        {
                            HSSFRow headerRow = (HSSFRow)sheet.CreateRow(rowIndex);
                            headerRow.HeightInPoints = 25;
                            headerRow.CreateCell(0).SetCellValue(strHeaderText);

                            HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                            HSSFFont font = (HSSFFont)workbook.CreateFont();
                            font.FontHeightInPoints = 18;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            headerRow.GetCell(0).CellStyle = headStyle;
                            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                            //headerRow.Dispose();

                            rowIndex = 1;
                        }
                    }
                    #endregion

                    #region 列头及样式
                    {
                        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(rowIndex);
                        HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                        HSSFFont font = (HSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 11;
                        font.Boldweight = 700;
                        font.IsBold = true;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                        // headerRow.Dispose();
                    }
                    #endregion

                    rowIndex++;
                }
                #endregion
                
                #region 填充内容
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            System.DateTime dateV;
                            System.DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }
                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                sheet = null;
                using (FileStream fs = new FileStream(savefd.FileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }
        /// <summary>
        /// DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="exceltype">是否模板</param>
        /// <param name="FileName">文件名称</param>
        public void DataTableToExcelTemplet(DataTable dtSource, string ExportType,string FileName = "")
        {
            string TempletFileName = "";//模板文件名称
            FileStream file = null;
            NPOI.SS.UserModel.IWorkbook workbook = null;
            SaveFileDialog savefd = new SaveFileDialog();

            //模板文件
            TempletFileName = Application.StartupPath + "\\JNMLTemp.xls";
            file = new FileStream(TempletFileName, FileMode.Open, FileAccess.Read);

            if (FileName != "")
                savefd.FileName = FileName + ".xls";
            savefd.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            if (savefd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            if (savefd.FilterIndex == 1)
            {
                workbook = new NPOI.HSSF.UserModel.HSSFWorkbook(file);
            }
            else
            {
                workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(file);
            }

            HSSFSheet sheet = (HSSFSheet)workbook.GetSheet("Sheet1");
            HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            
            int rowIndex = 1;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 填充内容
                HSSFRow dataRow = (HSSFRow)sheet.GetRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = (HSSFCell)dataRow.GetCell(column.Ordinal);

                    string drValue = row[column].ToString();
                    if (column.ColumnName == "numxh")
                    {
                        newCell.SetCellValue(rowIndex.ToString());
                        continue;
                    }
                    
                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            System.DateTime dateV;
                            System.DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }
                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                sheet = null;
                using (FileStream fs = new FileStream(savefd.FileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
            if (file != null)
            {
                file.Dispose();
                file.Close();
            }
        }
        /// <summary>
        /// excel列宽
        /// </summary>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        int[] SetExcelColWidth(DataTable dtSource,string ExportType)
        {
            int[] arrColWidth = new int[dtSource.Columns.Count];
            int rownum=1;
            foreach (DataColumn item in dtSource.Columns)
            {
                int widthtmp = 0;
                
                if (ExportType == "案卷目录")
                {
                    #region 案卷目录
                    switch (item.ColumnName.ToString())
                    {
                        case "序号":
                            widthtmp = 8;
                            break;
                        case "案卷题名":
                            widthtmp = 50;
                            break;
                        case "页数":
                            widthtmp = 15;
                            break;
                        case "文字页":
                            widthtmp = 15;
                            break;
                        case "图纸页":
                            widthtmp = 15;
                            break;
                        case "备注":
                            widthtmp = 60;
                            break;
                    }
                   #endregion
                }
                
                item.ColumnName = item.ColumnName.Substring(item.ColumnName.Length - 1) == "页" ? 
                    item.ColumnName.ToString().Replace("页", "(页)") : 
                    item.ColumnName;
                arrColWidth[item.Ordinal] = widthtmp;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
                if (dtSource.Columns[0].ColumnName == "序号")
                {
                    dtSource.Rows[i][0] = rownum.ToString();
                }
                rownum++;
            }
            return arrColWidth;
        }
    }
}
