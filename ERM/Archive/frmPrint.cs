using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Configuration;
using ERM.Common;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    public partial class frmPrint : ERM.UI.Controls.Skin_DevEX
    {
        private string PrintID;
        private string ProjectFilePathName;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename">报表文件名</param>
        /// <param name="dv">dv为传递过来需要打印的数据集</param>
        /// <param name="dv">为特殊页打印而设置的参数，如卷内目录打印，其他页打印可以提交空值</param>
        public frmPrint(string filename, DataView dv, string printID, DataSet ds)
        {
            try
            {
                 PrintID = printID;
            if (printID.ToLower() == "xiangmudjb")
            {
                ProjectFilePathName = Application.StartupPath + "\\Project\\" + Globals.ProjectNO + @"\xiangmudjb.cll";
            }
            if (printID.ToLower() == "yijiaodjb")
            {
                ProjectFilePathName = Application.StartupPath + "\\Project\\" + Globals.ProjectNO + @"\yijiaodjb.cll";
            }
            InitializeComponent();
            this.Cell1.Login("digipower", "11100101845", "1040-1145-0062-4005");
            this.Cell1.LocalizeControl(0x804);
            InitCell();
            ////报表文件是否存在7
            if (!System.IO.File.Exists(filename))
            {
                TXMessageBoxExtensions.Info("报表文件丢失！");
                return;
            }
            if (printID.ToLower() == "fengmian")
            {
                #region
                Cell1.OpenFile(filename, "");
                string key = "";
                for (int col = 1; col < Cell1.GetCols(0); col++)
                {
                    for (int row = 1; row < Cell1.GetRows(0); row++)
                    {
                        key = Cell1.GetCellNote(col, row, 0);
                        if (key != "")
                        {
                            if (dv.Table.Columns.Contains(key))
                            {
                                if (key == "ajtm")
                                {   //60
                                    Cell1.S(col, row, 0, dv[0][key].ToString().PadRight(60, ' '));
                                }
                                else
                                {
                                    Cell1.S(col, row, 0, dv[0][key].ToString().Trim());
                                }
                            }
                            else if (key == "dagdh")//档案馆代号
                            {
                                Cell1.S(col, row, 0, ConfigurationManager.AppSettings["dadh"]);
                            }
                            else if (MyCommon.Left(key, 1) == "2") //时间
                            {
                                Cell1.S(col, row, 0, DateTime.Now.ToString("yyyy.MM.dd"));
                            }
                            else if (string.Compare("dagdh", key, true) == 0)//档案馆代号
                            {
                                Cell1.S(col, row, 0, Globals.DagDh);
                            }
                        }//endkey
                    }//endfor
                }//endfor
                #endregion
            }//endif
            else if (printID.ToLower() == "bkb")
            {
                #region
                Cell1.OpenFile(filename, "");
                string key = "";
                for (int col = 1; col < Cell1.GetCols(0); col++)
                {
                    for (int row = 1; row < Cell1.GetRows(0); row++)
                    {
                        key = Cell1.GetCellNote(col, row, 0);
                        if (key != "")
                        {
                            if (dv.Table.Columns.Contains(key))
                            {
                                Cell1.S(col, row, 0, dv[0][key].ToString());
                            }
                            else
                            {
                                if (MyCommon.Left(key, 1) == "2") //时间
                                {
                                    Cell1.S(col, row, 0, DateTime.Now.ToString("yyyy年MM月dd日"));
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            else if (printID.ToLower() == "jnml")
            {
                #region
                Cell1.OpenFile(filename, "");
                int pages = dv.Count / 15;
                if ((dv.Count % 15) > 0)
                    pages++;
                if (pages > 1)
                {
                    Cell1.InsertSheet(1, pages - 1);
                    for (int i = 1; i < pages; i++)
                        Cell1.CopySheet(i, 0);
                }
                int?[] LocalProjectName = new int?[2];
                int?[] LocalOrderIndex = new int?[2];
                for (int col = 1; col < Cell1.GetCols(0); col++)
                {
                    for (int row = 1; row < Cell1.GetRows(0); row++)
                    {
                        string key = Cell1.GetCellNote(col, row, 0);
                        if (key != "")
                        {
                            if (key == "ajtm")
                            {
                                LocalProjectName[0] = col;
                                LocalProjectName[1] = row;
                            }
                            else if (key == "dh")
                            {
                                LocalOrderIndex[0] = col;
                                LocalOrderIndex[1] = row;
                            }
                        }
                    }
                }
                for (int i = 0; i < Cell1.GetTotalSheets(); i++)
                {
                    if (LocalOrderIndex[0].HasValue)
                        Cell1.S(LocalOrderIndex[0].Value, LocalOrderIndex[1].Value, i, dv[i]["dh"].ToString().Trim());
                    if (LocalProjectName[0].HasValue)
                        Cell1.S(LocalProjectName[0].Value, LocalProjectName[1].Value, i, dv[i]["ajtm"].ToString().Trim());
                }
                int yc = 1; //页次
                for (int i = 0; i < dv.Count; i++)
                {
                    int curPage = i / 15;  //当前页
                    int curRow = (i % 15) + 1; //当前行
                    Cell1.S(2, curRow + 3, curPage, (i + 1).ToString());
                    //Cell1.S(3, curRow + 3, curPage, dv[i]["wjbsm"].ToString().Trim());
                    Cell1.S(3, curRow + 3, curPage, dv[i]["wh"] == null ? "" : dv[i]["wh"].ToString().Trim());//文图号
                    Cell1.S(5, curRow + 3, curPage, dv[i]["zrr"].ToString().Trim());
                    Cell1.S(6, curRow + 3, curPage, dv[i]["wjtm"].ToString().Trim());
                    string dateText = dv[i]["CreateDate"] != null && dv[i]["CreateDate"].ToString() != ""
                        ? Convert.ToDateTime(dv[i]["CreateDate"]).ToString("yyyy-MM-dd") : "";
                    string endDate = dv[i]["CreateDate2"] != null && dv[i]["CreateDate2"].ToString() != ""
                        ? Convert.ToDateTime(dv[i]["CreateDate2"]).ToString("yyyy-MM-dd") : "";

                    if (string.IsNullOrWhiteSpace(dateText) && !string.IsNullOrWhiteSpace(endDate))
                    {
                        dateText = endDate;
                    }
                    else if (!string.IsNullOrWhiteSpace(dateText) && !string.IsNullOrWhiteSpace(endDate))
                    {
                        dateText = dateText + " - " + endDate;
                    }

                    Cell1.S(8, curRow + 3, curPage, dateText);

                    Cell1.S(10, curRow + 3, curPage, dv[i]["bz"].ToString().Trim());

                    int sl = (MyCommon.ToInt(dv[i]["sl"]) + MyCommon.ToInt(dv[i]["dw"]) + MyCommon.ToInt(dv[i]["wzz"]));
                    if (sl == 0)
                    {
                        sl = 1;
                        if (i < dv.Count - 1)
                            Cell1.S(9, curRow + 3, curPage, yc.ToString());
                        else
                            Cell1.S(9, curRow + 3, curPage, yc.ToString() + "-" + (yc - 1 + sl));

                        yc = yc + sl;
                    }
                    else
                    {
                        if (i < dv.Count - 1)
                            Cell1.S(9, curRow + 3, curPage, yc.ToString());
                        else
                            Cell1.S(9, curRow + 3, curPage, yc.ToString() + "-" + (yc - 1 + sl));

                        yc = yc + sl;
                    }

                    //if (i < dv.Count - 1)
                    //    Cell1.S(9, curRow + 3, curPage, yc.ToString());
                    //else
                    //    Cell1.S(9, curRow + 3, curPage, yc.ToString() + "-" + (yc - 1 + MyCommon.ToInt(dv[i]["sl"])));

                    //yc = yc + MyCommon.ToInt(dv[i]["sl"]) + MyCommon.ToInt(dv[i]["dw"]) + MyCommon.ToInt(dv[i]["wzz"]);
                }
                if (pages > 1) Cell1.SetCurSheet(0);
                #endregion
            }
            else if (printID.ToLower() == "unarchived")
            {
                #region
                Cell1.OpenFile(filename, "");
                for (int col = 1; col < Cell1.GetCols(0); col++)
                {
                    for (int row = 1; row < Cell1.GetRows(0); row++)
                    {
                        string key = Cell1.GetCellNote(col, row, 0);
                        if (string.Compare(key, "ProjectNO", true) == 0)
                            Cell1.S(col, row, 0, Globals.ProjectNO);
                        else if (string.Compare(key, "projectname", true) == 0)
                            Cell1.S(col, row, 0, Globals.Projectname);
                    }
                }
                int pages = dv.Count / 20;
                if ((dv.Count % 20) > 0)
                    pages++;
                if (pages > 1)
                {
                    Cell1.InsertSheet(1, pages - 1);
                    for (int i = 1; i < pages; i++)
                        Cell1.CopySheet(i, 0);
                }
                for (int i = 0; i < dv.Count; i++)
                {
                    int curPage = i / 20;  //当前页
                    int curRow = (i % 20) + 1; //当前行
                    Cell1.S(2, curRow + 4, curPage, dv[i][1].ToString().Trim());
                    Cell1.S(3, curRow + 4, curPage, dv[i][0].ToString().Trim());
                }
                if (pages > 1) Cell1.SetCurSheet(0);
                #endregion
            }
            else if (printID.ToLower() == "projectfile")
            {
                #region
                Cell1.OpenFile(filename, "");
                int pages = dv.Count / 15;
                if ((dv.Count % 15) > 0)
                    pages++;
                for (int col = 1; col < Cell1.GetCols(0); col++)
                {
                    for (int row = 1; row < Cell1.GetRows(0); row++)
                    {
                        string key = Cell1.GetCellNote(col, row, 0).ToLower();
                        if (key != "")
                        {
                            if (key.ToLower() == "projectno".ToLower())
                                Cell1.S(col, row, 0, Globals.ProjectNO);
                            else if (key.ToLower() == "projectname".ToLower())
                                Cell1.S(col, row, 0, Globals.Projectname);
                        }
                    }
                }
                if (pages > 1)
                {
                    Cell1.InsertSheet(1, pages - 1);
                    for (int i = 1; i < pages; i++)
                        Cell1.CopySheet(i, 0);
                }
                for (int i = 0; i < dv.Count; i++)
                {
                    int curPage = i / 15;  //当前页
                    int curRow = (i % 15) + 1; //当前行
                    //Cell1.S(1, curRow + 6, curPage, dv[i]["wjbsm"].ToString().Trim());
                    Cell1.S(1, curRow + 6, curPage, dv[i]["wh"] == null ? "" : dv[i]["wh"].ToString().Trim());//文图号
                    Cell1.S(2, curRow + 6, curPage, dv[i]["wjtm"].ToString().Trim());
                    Cell1.S(4, curRow + 6, curPage, dv[i]["wjgbdm"].ToString().Trim());
                    Cell1.S(5, curRow + 6, curPage, dv[i]["wjlxdm"].ToString().Trim());
                    Cell1.S(6, curRow + 6, curPage,
                        (dv[i]["CreateDate"] != null && dv[i]["CreateDate"].ToString() != "")
                        ? Convert.ToDateTime(dv[i]["CreateDate"]).ToString("yyyy.MM.dd") : "");
                    Cell1.S(7, curRow + 6, curPage, dv[i]["ztlx"].ToString().Trim());
                    Cell1.S(8, curRow + 6, curPage, dv[i]["bgqx"].ToString().Trim());
                    Cell1.S(9, curRow + 6, curPage, dv[i]["bz"].ToString().Trim());
                }
                if (pages > 1) Cell1.SetCurSheet(0);
                #endregion
            }
            else if (printID.ToLower() == "xiangmudjb")
            {
                #region
                this.btnSave.Visible = true;
                if (!System.IO.File.Exists(ProjectFilePathName))
                {
                    Cell1.OpenFile(filename, "");
                    string key = "";
                    for (int col = 1; col < Cell1.GetCols(0); col++)
                    {
                        for (int row = 1; row < Cell1.GetRows(0); row++)
                        {
                            key = Cell1.GetCellNote(col, row, 0);
                            if (key != "" && dv.Table.Columns.Contains(key))
                            {
                                Cell1.S(col, row, 0, dv[0][key].ToString());
                            }
                        }
                    }
                    if (dv[0]["dwmc"] != null)
                        Cell1.S(4, 6, 0, dv[0]["dwmc"].ToString());
                    if (dv[0]["tel"] != null)
                        Cell1.S(4, 7, 0, dv[0]["tel"].ToString());
                    Cell1.ReDraw();
                    Cell1.SelectRange(-1, -1, -1, -1);
                }
                else
                {
                    Cell1.OpenFile(ProjectFilePathName, "");
                }
                #endregion
            }
            else if (printID.ToLower() == "yijiaodjb")
            {
                #region
                this.btnSave.Visible = true;
                if (!System.IO.File.Exists(ProjectFilePathName))
                {
                    Cell1.OpenFile(filename, "");
                    string key = "";
                    for (int col = 1; col < Cell1.GetCols(0); col++)
                    {
                        for (int row = 1; row < Cell1.GetRows(0); row++)
                        {
                            key = Cell1.GetCellNote(col, row, 0);
                            if (key != "" && dv.Table.Columns.Contains(key))
                            {
                                Cell1.S(col, row, 0, dv[0][key].ToString());
                            }
                        }
                    }
                    Cell1.ReDraw();
                    Cell1.SelectRange(-1, -1, -1, -1);
                }
                else
                {  //打开文件
                    Cell1.OpenFile(ProjectFilePathName, "");
                }
                #endregion
            }
            else if (printID.ToLower() == "jzgczl" || printID.ToLower() == "sxdazl")
            {
                #region
                this.btnSave.Visible = true;
                if (!System.IO.File.Exists(ProjectFilePathName))
                {
                    Cell1.OpenFile(filename, "");
                    string key = "";
                    string keyType = "";
                    string trueKey = "";
                    for (int sheet = 0; sheet < Cell1.GetTotalSheets(); sheet++)
                    {
                        for (int col = 1; col < Cell1.GetCols(sheet); col++)
                        {
                            for (int row = 1; row < Cell1.GetRows(sheet); row++)
                            {
                                key = Cell1.GetCellNote(col, row, sheet);
                                if (key != "")
                                {
                                    keyType = MyCommon.Left(key, 1);
                                    trueKey = MyCommon.Right(key, key.Length - 2);
                                    if (string.Compare(keyType, "2", true) == 0)//目录汇总
                                    {
                                        DataView dvFilter = new DataView(ds.Tables[1]);
                                        //dvFilter.RowFilter = "table_name='" + trueKey + "'";
                                        dvFilter.RowFilter = "wjtm='" + trueKey + "'";
                                        if (dvFilter.Count > 0)
                                        {
                                            Cell1.S(col, row, sheet, dvFilter[0]["ys"].ToString());
                                        }
                                    }
                                    else if (string.Compare(keyType, "1", true) == 0)//工程名称,工程号,建设单位
                                    {
                                        if (ds.Tables[0].Columns.Contains(trueKey))
                                            Cell1.S(col, row, sheet, ds.Tables[0].Rows[0][trueKey].ToString().Trim());
                                    }
                                    else if (string.Compare(keyType, "3", true) == 0)//最后一页的汇总
                                    {
                                        if (ds.Tables[2].Columns.Contains(trueKey))
                                        {
                                            string str = ds.Tables[2].Rows[0][trueKey].ToString().Trim();
                                            Cell1.S(col, row, sheet, string.IsNullOrEmpty(str) ? "0" : str);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Cell1.ReDraw();
                    Cell1.SelectRange(-1, -1, -1, -1);
                }
                else
                {  //打开文件
                    Cell1.OpenFile(ProjectFilePathName, "");
                }
                #endregion
            }
            }
            catch (Exception e)
            {
                TXMessageBoxExtensions.Error(e.Message.ToString());
            }
        }

        public frmPrint(string filename, ProjectItemUnits projectFactory, string printID)
        {
            PrintID = printID;
            InitializeComponent();
            this.Cell1.Login("digipower", "11100101845", "1040-1145-0062-4005");
            this.Cell1.LocalizeControl(0x804);
            InitCell();
            ////报表文件是否存在7
            if (!System.IO.File.Exists(filename))
            {
                TXMessageBoxExtensions.Info("报表文件丢失！");
                return;
            }
            if (printID.ToLower() == "gcgk")
            {
                #region
                //Cell1.OpenFile(filename, "");
                //string key = "";
                //for (int col = 1; col < Cell1.GetCols(0); col++)
                //{
                //    for (int row = 1; row < Cell1.GetRows(0); row++)
                //    {
                //        key = Cell1.GetCellNote(col, row, 0);
                //        if (key != "")
                //        {
                //            object keyvalues = projectFactory.ProjectDetail[key];
                //            if (keyvalues != null && (keyvalues is System.String))
                //            {
                //                Cell1.S(col, row, 0, keyvalues.ToString());
                //            }
                //            else if (keyvalues != null && (keyvalues is System.String[]))
                //            {
                //                string Svalue = "";
                //                foreach (string values in (keyvalues as System.String[]))
                //                {
                //                    if (!string.IsNullOrWhiteSpace(values))
                //                        Svalue += values + "，";
                //                }
                //                if (Svalue.EndsWith("，"))
                //                {
                //                    Svalue = Svalue.Remove(Svalue.Length - 1);
                //                }
                //                Cell1.S(col, row, 0, Svalue);
                //            }
                //            else
                //            {
                //                if (MyCommon.Left(key, 1) == "2") //时间
                //                {
                //                    Cell1.S(col, row, 0, DateTime.Now.ToString("yyyy.MM.dd"));
                //                }
                //                //else if(keyvalues.GetType())
                //            }
                //        }
                //    }
                //}
                #endregion
                Cell1.OpenFile(filename, "");
                string key = "";
                for (int sheet = 0; sheet < Cell1.GetTotalSheets(); sheet++)
                {
                    for (int col = 1; col < Cell1.GetCols(sheet); col++)
                    {
                        for (int row = 1; row < Cell1.GetRows(sheet); row++)
                        {
                            key = Cell1.GetCellNote(col, row, sheet).ToLower();
                            if (projectFactory.ProjectDetail.Contains(key.ToLower()))
                            {
                                if (projectFactory.ProjectDetail[key.ToLower()].GetType() == typeof(System.String[]))
                                {
                                    Cell1.SetDroplistCell(col, row, sheet, MyCommon.Array2DroplistCell((string[])projectFactory.ProjectDetail[key.ToLower()]), 2);
                                    Cell1.SetCellString(col, row, sheet, ((string[])projectFactory.ProjectDetail[key.ToLower()])[0]);
                                }
                                else
                                {
                                    Cell1.S(col, row, sheet, projectFactory.ProjectDetail[key.ToLower()].ToString());
                                }
                            }
                        }
                    }
                }
                Cell1.SelectRange(-1, -1, -1, -1);
            }
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            this.ActiveControl = Cell1;
            Cell1.SelectRange(-1, -1, -1, -1);
            Cell1.EnableUndo(1);
            Cell1.ShowSheetLabel(1, 0);
        }
        /// <summary>
        /// 初始化所有ComboBox
        /// </summary>
        private void InitCell()
        {
            FontFamily[] fonts = (new InstalledFontCollection()).Families;
            for (int i = 0; i < fonts.Length; i++)
            {
                cboFonts.Items.Add(fonts[i].Name);
            }
            cboFonts.Text = Cell1.GetDefaultFontName();
            cboFontSize.Text = Cell1.GetDefaultFontSize().ToString();
            cboLine.ImageList = imageBorder;
            cboLine.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < imageBorder.Images.Count; i++)
            {
                cboLine.Items.Add(new ComboBoxExItem("", i));
            }
            cboLine.SelectedIndex = 0;
            cboZoom.Text = "100%";
        }
        private void cboFonts_DropDownClosed(object sender, EventArgs e)
        {
            cboFonts.Text = cboFonts.SelectedItem.ToString();
            this.CellOperate("Fonts");
        }
        private void cboFontSize_DropDownClosed(object sender, EventArgs e)
        {
            if (cboFontSize.SelectedItem == null) return;
            cboFontSize.Text = cboFontSize.SelectedItem.ToString();
            this.CellOperate("FontSize");
        }
        private void cboFontSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CellOperate("FontSize");
            }
        }
        private void btnBold_Click(object sender, EventArgs e)
        {
            this.CellOperate("Bold");
        }
        private void btnItalic_Click(object sender, EventArgs e)
        {
            this.CellOperate("Italic");
        }
        private void btnUnderLine_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnderLine");
        }
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            this.CellOperate("BackColor");
        }
        private void btnForeColor_Click(object sender, EventArgs e)
        {
            this.CellOperate("ForeColor");
        }
        private void btnWordWrap_Click(object sender, EventArgs e)
        {
            this.CellOperate("WordWrap");
        }
        private void btnAlignLeft_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignLeft");
        }
        private void btnAlignCenter_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignCenter");
        }
        private void btnAlignRight_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignRight");
        }
        private void btnAlignTop_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignTop");
        }
        private void btnAlignMiddle_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignMiddle");
        }
        private void btnAlignBottom_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignBottom");
        }
        private void btnDrawBorder_ButtonClick(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder1");
        }
        private void menuDrawBorder1_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder1");
        }
        private void menuDrawBorder2_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder2");
        }
        private void menuDrawBorder3_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder3");
        }
        private void menuDrawBorder4_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder4");
        }
        private void menuDrawBorder5_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder5");
        }
        private void menuDrawBorder6_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder6");
        }
        private void menuDrawBorder7_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder7");
        }
        private void menuDrawBorder8_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder8");
        }
        private void btnEraseBorder_ButtonClick(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder1");
        }
        private void menuEraseBorder1_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder1");
        }
        private void menuEraseBorder2_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder2");
        }
        private void menuEraseBorder3_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder3");
        }
        private void menuEraseBorder4_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder4");
        }
        private void menuEraseBorder5_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder5");
        }
        private void menuEraseBorder6_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder6");
        }
        private void menuEraseBorder7_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder7");
        }
        private void menuEraseBorder8_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder8");
        }
        private void btnSymbol_Click(object sender, EventArgs e)
        {
            this.CellOperate("Symbol");
        }
        private void btnInsertPic_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertPic");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.CellOperate("Save");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.CellOperate("Print");
            btnSave_Click(null, null);//保存
        }
        private void btnPrintpreview_Click(object sender, EventArgs e)
        {
            this.CellOperate("Printpreview");
        }
        private void btnCut_Click(object sender, EventArgs e)
        {
            this.CellOperate("Cut");
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.CellOperate("Copy");
        }
        private void btnPaste_Click(object sender, EventArgs e)
        {
            this.CellOperate("Paste");
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Undo");
        }
        private void btnRedo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Redo");
        }
        private void btnRow_Click(object sender, EventArgs e)
        {
            this.CellOperate("RowHideShow");
        }
        private void btnCol_Click(object sender, EventArgs e)
        {
            this.CellOperate("ColHideShow");
        }
        private void btnGridline_Click(object sender, EventArgs e)
        {
            this.CellOperate("Gridline");
        }
        private void btnMergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("MergeCell");
        }
        private void btnUnmergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnmergeCell");
        }
        private void cboZoom_DropDownClosed(object sender, EventArgs e)
        {
            if (cboZoom.SelectedItem == null) return;
            cboZoom.Text = cboZoom.SelectedItem.ToString();
            this.CellOperate("Zoom");
        }
        private void cboZoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CellOperate("Zoom");
            }
        }
        private void btnInsertCol_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertCol");
        }
        private void btnDeleteCol_Click(object sender, EventArgs e)
        {
            this.CellOperate("DeleteCol");
        }
        private void btnInsertRow_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertRow");
        }
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            this.CellOperate("DeleteRow");
        }
        private void btnRndFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RndFill");
        }
        private void btnSumH_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumH");
        }
        private void btnSumV_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumV");
        }
        private void btnSum_Click(object sender, EventArgs e)
        {
            this.CellOperate("Sum");
        }
        /// <summary>
        /// 表格控件各种操作的实现方法(字体、字号、粗体、斜体、对齐、复制等等的处理)
        /// </summary>
        /// <param name="key"></param>
        private void CellOperate(string key)
        {
            string UpKey = key.ToUpper();
            int startCol = 0, startRow = 0, endCol = 0, endRow = 0;
            Cell1.GetSelectRange(ref startCol, ref startRow, ref endCol, ref endRow);
            int sheet = Cell1.GetCurSheet();
            ColorDialog colorDlg;
            DialogResult ret;
            if (UpKey != "SAVE" && UpKey != "PAGESETUP" && UpKey != "PRINTPREVIEW" && UpKey != "PRINT"          //"打印、保存" 不需要选中单元格
                && UpKey != "UNDO" && UpKey != "REDO"                                        //"撤消重做" 不需要选中单元格
                && UpKey != "ROWHIDESHOW" && UpKey != "COLHIDESHOW" && UpKey != "GRIDLINE"   //"显示/隐藏行标、列标、网格线" 不需要选中单元格
                && UpKey != "ZOOM" && UpKey != "REPAIR" && UpKey != "SELECTALL")             //"显示比例、整理、全选" 不需要选中单元格
                if (startCol <= 0 || startRow <= 0 || endCol <= 0 || endRow <= 0) return;
            switch (UpKey)
            {
                case "FONTS":
                    int fontName = Cell1.FindFontIndex(cboFonts.SelectedItem.ToString(), 1);
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellFont(i, j, sheet, fontName);
                    }
                    break;
                case "FONTSIZE":
                    int fontSize = MyCommon.IsInt(cboFontSize.Text) ? MyCommon.ToInt(cboFontSize.Text) : 10;
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellFontSize(i, j, sheet, fontSize);
                    }
                    break;
                case "BOLD":
                    if (btnBold.Checked)  //应用粗体
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int style = Cell1.GetCellFontStyle(i, j, sheet);
                                if ((style & 2) != 2)
                                    Cell1.SetCellFontStyle(i, j, sheet, style + 2);
                            }
                        }
                    }
                    else  //取消粗体
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int style = Cell1.GetCellFontStyle(i, j, sheet);
                                if ((style & 2) == 2)
                                    Cell1.SetCellFontStyle(i, j, sheet, style - 2);
                            }
                        }
                    }
                    break;
                case "ITALIC":
                    if (btnItalic.Checked)  //应用斜体
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int style = Cell1.GetCellFontStyle(i, j, sheet);
                                if ((style & 4) != 4)
                                    Cell1.SetCellFontStyle(i, j, sheet, style + 4);
                            }
                        }
                    }
                    else  //取消斜体
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int style = Cell1.GetCellFontStyle(i, j, sheet);
                                if ((style & 4) == 4)
                                    Cell1.SetCellFontStyle(i, j, sheet, style - 4);
                            }
                        }
                    }
                    break;
                case "UNDERLINE":
                    if (btnItalic.Checked)  //应用下划线
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int style = Cell1.GetCellFontStyle(i, j, sheet);
                                if ((style & 8) != 8)
                                    Cell1.SetCellFontStyle(i, j, sheet, style + 8);
                            }
                        }
                    }
                    else  //取消下划线
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int style = Cell1.GetCellFontStyle(i, j, sheet);
                                if ((style & 8) == 8)
                                    Cell1.SetCellFontStyle(i, j, sheet, style - 8);
                            }
                        }
                    }
                    break;
                case "BACKCOLOR":
                    colorDlg = new ColorDialog();
                    colorDlg.AllowFullOpen = true;
                    ret = colorDlg.ShowDialog();
                    if (ret == DialogResult.OK)
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int index = Cell1.FindColorIndex(MyCommon.GetRGBFromColor(colorDlg.Color), 1);
                                if (index != -1)
                                    Cell1.SetCellBackColor(i, j, sheet, index);
                            }
                        }
                    }
                    break;
                case "FORECOLOR":
                    colorDlg = new ColorDialog();
                    colorDlg.AllowFullOpen = true;
                    ret = colorDlg.ShowDialog();
                    if (ret == DialogResult.OK)
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int index = Cell1.FindColorIndex(MyCommon.GetRGBFromColor(colorDlg.Color), 1);
                                if (index != -1)
                                    Cell1.SetCellTextColor(i, j, sheet, index);
                            }
                        }
                    }
                    break;
                case "WORDWRAP":
                    if (btnWordWrap.Checked)  //应用折行显示
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                                Cell1.SetCellTextStyle(i, j, sheet, 2);
                        }
                    }
                    else //取消折行显示
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                                Cell1.SetCellTextStyle(i, j, sheet, 1);
                        }
                    }
                    break;
                case "ALIGNLEFT":
                    if (btnAlignLeft.Checked)  //应用居左
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 1) != 1)
                                {
                                    align = MyCommon.NumberMinus(align, 2);
                                    align = MyCommon.NumberMinus(align, 4);
                                    Cell1.SetCellAlign(i, j, sheet, align + 1);
                                    btnAlignCenter.Checked = false;
                                    btnAlignRight.Checked = false;
                                }
                            }
                        }
                    }
                    else //取消居左
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 1) == 1)
                                    Cell1.SetCellAlign(i, j, sheet, align - 1);
                            }
                        }
                    }
                    break;
                case "ALIGNCENTER":
                    if (btnAlignCenter.Checked)  //应用居中
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 4) != 4)
                                {
                                    align = MyCommon.NumberMinus(align, 1);
                                    align = MyCommon.NumberMinus(align, 2);
                                    Cell1.SetCellAlign(i, j, sheet, align + 4);
                                    btnAlignLeft.Checked = false;
                                    btnAlignRight.Checked = false;
                                }
                            }
                        }
                    }
                    else //取消居中
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 4) == 4)
                                    Cell1.SetCellAlign(i, j, sheet, align - 4);
                            }
                        }
                    }
                    break;
                case "ALIGNRIGHT":
                    if (btnAlignRight.Checked)  //应用居右
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 2) != 2)
                                {
                                    align = MyCommon.NumberMinus(align, 1);
                                    align = MyCommon.NumberMinus(align, 4);
                                    Cell1.SetCellAlign(i, j, sheet, align + 2);
                                    btnAlignLeft.Checked = false;
                                    btnAlignCenter.Checked = false;
                                }
                            }
                        }
                    }
                    else //取消居右
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 2) == 2)
                                    Cell1.SetCellAlign(i, j, sheet, align - 2);
                            }
                        }
                    }
                    break;
                case "ALIGNTOP":
                    if (btnAlignTop.Checked)  //应用居上
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 8) != 8)
                                {
                                    align = MyCommon.NumberMinus(align, 16);
                                    align = MyCommon.NumberMinus(align, 32);
                                    Cell1.SetCellAlign(i, j, sheet, align + 8);
                                    btnAlignMiddle.Checked = false;
                                    btnAlignBottom.Checked = false;
                                }
                            }
                        }
                    }
                    else //取消居上
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 8) == 8)
                                    Cell1.SetCellAlign(i, j, sheet, align - 8);
                            }
                        }
                    }
                    break;
                case "ALIGNMIDDLE":
                    if (btnAlignMiddle.Checked)  //应用垂直居中
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 32) != 32)
                                {
                                    align = MyCommon.NumberMinus(align, 8);
                                    align = MyCommon.NumberMinus(align, 16);
                                    Cell1.SetCellAlign(i, j, sheet, align + 32);
                                    btnAlignTop.Checked = false;
                                    btnAlignBottom.Checked = false;
                                }
                            }
                        }
                    }
                    else //取消垂直居中
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 32) == 32)
                                    Cell1.SetCellAlign(i, j, sheet, align - 32);
                            }
                        }
                    }
                    break;
                case "ALIGNBOTTOM":
                    if (btnAlignBottom.Checked)  //应用居下
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 16) != 16)
                                {
                                    align = MyCommon.NumberMinus(align, 8);
                                    align = MyCommon.NumberMinus(align, 32);
                                    Cell1.SetCellAlign(i, j, sheet, align + 16);
                                    btnAlignTop.Checked = false;
                                    btnAlignMiddle.Checked = false;
                                }
                            }
                        }
                    }
                    else //取消居下
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 16) == 16)
                                    Cell1.SetCellAlign(i, j, sheet, align - 16);
                            }
                        }
                    }
                    break;
                case "DRAWBORDER1":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 0, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER2":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 1, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER3":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 2, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER4":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 3, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER5":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 4, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER6":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 5, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER7":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 6, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER8":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 7, cboLine.SelectedIndex + 2, -1);
                    break;
                case "ERASEBORDER1":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 0);
                    break;
                case "ERASEBORDER2":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 1);
                    break;
                case "ERASEBORDER3":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 2);
                    break;
                case "ERASEBORDER4":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 3);
                    break;
                case "ERASEBORDER5":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 4);
                    break;
                case "ERASEBORDER6":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 5);
                    break;
                case "ERASEBORDER7":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 6);
                    break;
                case "ERASEBORDER8":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 7);
                    break;
                case "SYMBOL":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5) //未锁定
                    {
                        frmSymbol SymbolForm = new frmSymbol();
                        ret = SymbolForm.ShowDialog();
                        if (ret == DialogResult.OK)
                        {
                            Cell1.InsertString(startCol, startRow, SymbolForm.lblBig.Text);
                        }
                    }
                    break;
                case "INSERTPIC":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)  //未锁定
                    {
                        Cell1.SetCellImageDlg();
                        Cell1.ReDraw();
                    }
                    break;
                case "SAVE":
                    if (PrintID.ToLower() == "yijiaodjb")//移交
                    {
                        Cell1.SaveFile(ProjectFilePathName, 0);
                    }
                    if (PrintID.ToLower() == "xiangmudjb")//项目登记
                    {
                        Cell1.SaveFile(ProjectFilePathName, 0);
                    }
                    break;
                case "PRINT":
                    Cell1.PrintSetAlign(1, 1);
                    Cell1.PrintPara(1, 1, 0, 0);
                    Cell1.PrintSheet(1, sheet);
                    break;
                case "PRINTPREVIEW":
                    Cell1.PrintSetAlign(1, 1);
                    Cell1.PrintPara(1, 1, 0, 0); //单色打印
                    Cell1.PrintPreview(1, sheet);//PrintPara
                    break;
                case "PAGESETUP":
                    Cell1.PrintSetAlign(1, 1);
                    Cell1.PrintPara(1, 1, 0, 0); //单色打印
                    Cell1.PrintPageSetup();
                    break;
                case "CUT":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)  //未锁定
                        Cell1.CutRange(startCol, startRow, endCol, endRow);
                    break;
                case "COPY":
                    Cell1.CopyRange(startCol, startRow, endCol, endRow);
                    break;
                case "PASTE":
                    Cell1.Paste(startCol, startRow, 2, 1, 1);
                    break;
                case "UNDO":
                    Cell1.Undo();
                    this.CheckUnDoReDo();
                    break;
                case "REDO":
                    Cell1.Redo();
                    this.CheckUnDoReDo();
                    break;
                case "ROWHIDESHOW":
                    if (Cell1.GetTopLabelState(sheet) == 0) //未显示
                        Cell1.ShowTopLabel(1, sheet);
                    else
                        Cell1.ShowTopLabel(0, sheet);
                    break;
                case "COLHIDESHOW":
                    if (Cell1.GetSideLabelState(sheet) == 0) //未显示
                        Cell1.ShowSideLabel(1, sheet);
                    else
                        Cell1.ShowSideLabel(0, sheet);
                    break;
                ///显示/隐藏网格线
                case "GRIDLINE":
                    if (Cell1.GetGridLineState(sheet) == 0) //未显示
                        Cell1.ShowGridLine(1, sheet);
                    else
                        Cell1.ShowGridLine(0, sheet);
                    break;
                case "MERGECELL":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)  //未锁定
                        Cell1.MergeCells(startCol, startRow, endCol, endRow);
                    break;
                case "UNMERGECELL":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5) //未锁定
                    {
                        int startCol1 = 0, startRow1 = 0, endCol1 = 0, endRow1 = 0;
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                Cell1.GetMergeRange(i, j, ref startCol1, ref startRow1, ref endCol1, ref endRow1);
                                Cell1.UnmergeCells(startCol1, startRow1, endCol1, endRow1);
                            }
                        }
                    }
                    break;
                case "ZOOM":
                    string strZoom = (cboZoom.Text.Trim() == string.Empty ? "100" : cboZoom.Text.Trim());
                    strZoom = strZoom.Replace("%", "");
                    strZoom = strZoom.Replace(" ", "");
                    int scale = MyCommon.IsInt(strZoom) ? MyCommon.ToInt(strZoom) : 100;
                    cboZoom.Text = scale.ToString() + "%";
                    Cell1.SetScreenScale(sheet, scale / 100.0);
                    break;
                case "INSERTCOL":
                    Cell1.InsertCol(startCol, endCol - startCol + 1, sheet);
                    break;
                case "DELETECOL":
                    Cell1.DeleteCol(startCol, endCol - startCol + 1, sheet);
                    break;
                case "INSERTROW":
                    Cell1.InsertRow(startRow, endRow - startRow + 1, sheet);
                    break;
                case "DELETEROW":
                    Cell1.DeleteRow(startRow, endRow - startRow + 1, sheet);
                    break;
                case "SELECTALL":
                    Cell1.SelectRange(1, 1, Cell1.GetCols(sheet) - 1, Cell1.GetRows(sheet) - 1);
                    break;
                case "RNDFILL":
                    frmCellFillRnd frm = new frmCellFillRnd();
                    ret = frm.ShowDialog();
                    if (ret == DialogResult.OK)
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                if (Cell1.GetCellInput(i, j, sheet) != 5)
                                    Cell1.SetCellDouble(i, j, sheet, Convert.ToDouble(MyCommon.Rnd(frm.MinData, frm.MaxData, frm.IsInt)));
                            }
                        }
                    }
                    break;
                case "REPEATFILL":
                    Cell1.Fill(16);
                    break;
                case "SUMH":
                    if (startCol == endCol)
                        TXMessageBoxExtensions.Info("请选择一个矩形区域！");
                    else
                    {
                        for (int i = startRow; i <= endRow; i++)
                        {
                            string formula;
                            formula = "sum(" + Cell1.CellToLabel(startCol, i) + ":" + Cell1.CellToLabel(endCol - 1, i) + ")";
                            Cell1.SetFormula(endCol, i, sheet, formula);
                        }
                        Cell1.ReDraw();
                    }
                    break;
                case "SUMV":
                    if (startRow == endRow)
                        TXMessageBoxExtensions.Info("请选择一个矩形区域！");
                    else
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            string formula;
                            formula = "sum(" + Cell1.CellToLabel(i, startRow) + ":" + Cell1.CellToLabel(i, endRow - 1) + ")";
                            Cell1.SetFormula(i, endRow, sheet, formula);
                        }
                        Cell1.ReDraw();
                    }
                    break;
                case "SUM":
                    if (startRow == endRow && startCol == endCol)
                        TXMessageBoxExtensions.Info("请选择一个矩形区域！");
                    else
                    {
                        string formula;
                        for (int i = startRow; i <= endRow; i++)
                        {
                            formula = "sum(" + Cell1.CellToLabel(startCol, i) + ":" + Cell1.CellToLabel(endCol - 1, i) + ")";
                            Cell1.SetFormula(endCol, i, sheet, formula);
                        }
                        for (int i = startCol; i <= endCol; i++)
                        {
                            formula = "sum(" + Cell1.CellToLabel(i, startRow) + ":" + Cell1.CellToLabel(i, endRow - 1) + ")";
                            Cell1.SetFormula(i, endRow, sheet, formula);
                        }
                        formula = "sum(" + Cell1.CellToLabel(startCol, startRow) + ":" + Cell1.CellToLabel(endCol - 1, endRow - 1) + ")";
                        Cell1.SetFormula(endCol, endRow, sheet, formula);
                        Cell1.ReDraw();
                    }
                    break;
                case "CLEARTEXT":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //未锁定
                                Cell1.ClearArea(i, j, i, j, sheet, 1);
                        }
                    }
                    break;
                case "CLEARIMAGE":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //未锁定
                                Cell1.ClearArea(i, j, i, j, sheet, 16);
                        }
                    }
                    break;
                case "CLEARFORMAT":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //未锁定
                                Cell1.ClearArea(i, j, i, j, sheet, 8);
                        }
                    }
                    break;
                case "CLEARALL":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //未锁定
                                Cell1.ClearArea(i, j, i, j, sheet, 32);
                        }
                    }
                    break;
                case "REPAIR":
                    Cell1.ClearArea(1, 1, Cell1.GetCols(sheet), Cell1.GetRows(sheet), sheet, 2); //清除公式
                    break;
                case "CELLOPTION":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)
                        Cell1.CellPropertyDlg();
                    break;
                case "READONLYT":
                    for (int i = startCol; i <= endCol; i++)
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellInput(i, j, sheet, 5);
                    break;
                case "READONLYF":
                    for (int i = startCol; i <= endCol; i++)
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellInput(i, j, sheet, 1);
                    break;
            }
        }
        /// <summary>
        /// 撤消、重复两个按钮的状态检查
        /// </summary>
        private void CheckUnDoReDo()
        {
            if (Cell1.GetUndoState() == 1)
            {
                btnUndo.Enabled = true;
            }
            else
            {
                btnUndo.Enabled = false;
            }
            if (Cell1.GetRedoState() == 1)
            {
                btnRedo.Enabled = true;
            }
            else
            {
                btnRedo.Enabled = false;
            }
        }
        private void Cell1_AllowMove(object sender, AxCELL50Lib._DCell2000Events_AllowMoveEvent e)
        {
            if (Cell1.WorkbookReadonly) return;
            int col = e.newcol;
            int row = e.newrow;
            int sheet = Cell1.GetCurSheet();
            ///////////////////////////////////////////////////////////////////
            for (int i = 0; i < cboFonts.Items.Count; i++)
            {
                if (Cell1.GetFontName(Cell1.GetCellFont(col, row, sheet)) == cboFonts.Items[i].ToString())
                {
                    cboFonts.SelectedIndex = i;
                    break;
                }
            }
            cboFontSize.Text = Cell1.GetCellFontSize(col, row, sheet).ToString();
            int style = this.Cell1.GetCellFontStyle(col, row, sheet); //字体风格
            if ((style & 2) == 2)
                btnBold.Checked = true;
            else
                btnBold.Checked = false;
            if ((style & 4) == 4)
                btnItalic.Checked = true;
            else
                btnItalic.Checked = false;
            if ((style & 8) == 8)
                btnUnderLine.Checked = true;
            else
                btnUnderLine.Checked = false;
            if (Cell1.GetCellTextStyle(col, row, sheet) == 2)
                btnWordWrap.Checked = true;
            else
                btnWordWrap.Checked = false;
            int align = this.Cell1.GetCellAlign(col, row, sheet);  //单元格的对齐方式
            btnAlignLeft.Checked = false;
            btnAlignCenter.Checked = false;
            btnAlignRight.Checked = false;
            btnAlignTop.Checked = false;
            btnAlignMiddle.Checked = false;
            btnAlignBottom.Checked = false;
            if ((align & 1) == 1)
            {
                btnAlignLeft.Checked = true;
            }
            if ((align & 2) == 2)
            {
                btnAlignRight.Checked = true;
            }
            if ((align & 4) == 4)
            {
                btnAlignCenter.Checked = true;
            }
            if ((align & 8) == 8)
            {
                btnAlignTop.Checked = true;
            }
            if ((align & 16) == 16)
            {
                btnAlignBottom.Checked = true;
            }
            if ((align & 32) == 32)
            {
                btnAlignMiddle.Checked = true;
            }
            this.CheckUnDoReDo();
            ///////////////////////////////////////////////////////////////////
        }
    }
}
