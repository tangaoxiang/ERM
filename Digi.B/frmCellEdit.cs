using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Digi.B
{
    public partial class frmCellEdit : Form
    {
        

        #region 初始化

        //实例化自定义变量访问类
        private DigiPower.ERM.BLL.Vars varsData = new DigiPower.ERM.BLL.Vars();

        //编辑的文件
        private string _fileName;

        //自定义颜色 
        int[] CustomColors;

        //当鼠标移动时由MouseMoving事件对此赋值，用以给鼠标右键菜单定位
        private int myX = 0;
        private int myY = 0;


        public frmCellEdit(string fileName)
        {
            ToolStripManager.VisualStylesEnabled = true;

            InitializeComponent();

            //login
            this.Cell1.Login("digipower", "11100101845", "1040-1145-0062-4005");
            this.Cell1.LocalizeControl(0x804);

            //filename
            this._fileName = fileName;

            //下拉选框
            InitComboBox();
           
        }



        /// <summary>
        /// 初始化所有ComboBox
        /// </summary>
        private void InitComboBox()
        {

            //填充字体集
            FontFamily[] fonts = (new InstalledFontCollection()).Families;
            for (int i = 0; i < fonts.Length; i++)
            {
                cboFonts.Items.Add(fonts[i].Name);
            }
            //设置默认字体
            cboFonts.Text = Cell1.GetDefaultFontName();
            //设置默认字体大小
            cboFontSize.Text = Cell1.GetDefaultFontSize().ToString();

            //边框线下拉
            cboLine.ImageList = imageBorder;
            cboLine.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < imageBorder.Images.Count; i++)
            {
                cboLine.Items.Add(new Digi.B.ComboBoxExItem("", i));
            }
            cboLine.SelectedIndex = 0;

            //显示比例
            cboZoom.Text = "100%";

            //自定义变量
            DataSet ds = varsData.GetAllList();
            ds.Tables[0].DefaultView.Sort = "varid";
            cboVars.DisplayMember = "varTitle";
            cboVars.ValueMember = "varName";
            cboVars.DataSource = ds.Tables[0].DefaultView;
            cboVars.SelectedIndex = -1;

        }


        private void frmCellEdit_Load(object sender, EventArgs e)
        {   


            //打开表格
            Cell1.OpenFile(this._fileName, "");
            Cell1.SelectRange(-1, -1, -1, -1);
            Cell1.ShowCellTip = true;


            //设置注释
            this.DrawTips();

            this.ActiveControl = Cell1; //聚焦
            Cell1.EnableUndo(1);     //允许重做
            
        }

        private void frmCellEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CheckSave();
        }

        //文件是否需要被更改，是否需要保存
        private void CheckSave()
        {
            if (Cell1.IsModified() == 1) //文件已经被修改
            {
                DialogResult ret = Functions.ShowQuestion("表格已经被修改，需要保存吗？");
                {
                    if (ret == DialogResult.Yes)
                    {
                        CellOperate("Save");
                    }
                }
            }
        }
        #endregion




        #region 主菜单
        private void tsmiSave_Click(object sender, EventArgs e)
        {
            this.CellOperate("Save");
        }

        //退出
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //撤消
        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Undo");
        }


        //重做
        private void tsmiRedo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Redo");
        }

        //剪切
        private void tsmiCut_Click(object sender, EventArgs e)
        {
            this.CellOperate("Cut");
        }

        //复制
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            this.CellOperate("Copy");
        }

        //粘贴
        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            this.CellOperate("Paste");
        }

        //全选
        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            this.CellOperate("SelectAll");
        }

        //重复填充
        private void tsmiRepeatFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RepeatFill");
        }

        //随机填充
        private void tsmiRndFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RndFill");
        }

        //横向求和
        private void tsmiSumH_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumH");
        }

        //纵向求和
        private void tsmiSumV_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumV");
        }

        //双向求和
        private void tsmiSum_Click(object sender, EventArgs e)
        {
            this.CellOperate("Sum");
        }

        //清除文字
        private void tsmiClearText_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearText");
        }

        //清除图像
        private void tsmiClearImage_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearImage");
        }

        //清除格式
        private void tsmiClearFormat_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearFormat");
        }

        //清除全部
        private void tsmiClearAll_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearAll");
        }

        //插入特殊符号
        private void tsmiSymbol_Click(object sender, EventArgs e)
        {
            this.CellOperate("Symbol");
            //Cell1.InsertSpecialCharDlg();
        }

        //插入图片
        private void tsmiInsertPic_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertPic");
        }

        //组合单元格
        private void tsmiMergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("MergeCell");
        }

        //取消组合单元
        private void tsmiUnmergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnmergeCell");
        }

        //整理表格
        private void tsmiRepair_Click(object sender, EventArgs e)
        {
            this.CellOperate("Repair");
        }

        //单元格属性
        private void tsmiCellOption_Click(object sender, EventArgs e)
        {
            this.CellOperate("CellOption");
        }
        #endregion




        #region 菜单操作具体的方法
        /// <summary>
        /// 表格控件各种操作的实现方法(字体、字号、粗体、斜体、对齐、复制等等的处理)
        /// </summary>
        /// <param name="key"></param>
        private void CellOperate(string key)
        {
            //转换成大写
            string UpKey = key.ToUpper();


            //找到选中的行列
            int startCol = 0, startRow = 0, endCol = 0, endRow = 0;
            Cell1.GetSelectRange(ref startCol, ref startRow, ref endCol, ref endRow);

            //找到当前的工作簿
            int sheet = Cell1.GetCurSheet();

            //颜色选折对话框
            ColorDialog colorDlg;
            DialogResult ret;

            //以下操作除外，如果没选中单元格则退出
            if (UpKey != "SAVE" && UpKey != "PAGESETUP" && UpKey != "PRINTPREVIEW" && UpKey != "PRINT"          //"打印、保存" 不需要选中单元格
                && UpKey != "UNDO" && UpKey != "REDO"                                        //"撤消重做" 不需要选中单元格
                && UpKey != "ROWHIDESHOW" && UpKey != "COLHIDESHOW" && UpKey != "GRIDLINE"   //"显示/隐藏行标、列标、网格线" 不需要选中单元格
                && UpKey != "ZOOM" && UpKey != "REPAIR" && UpKey != "SELECTALL")             //"显示比例、整理、全选" 不需要选中单元格
                if (startCol <= 0 || startRow <= 0 || endCol <= 0 || endRow <= 0) return;



            switch (UpKey)
            {
                //字体
                case "FONTS":
                    int fontName = Cell1.FindFontIndex(cboFonts.SelectedItem.ToString(), 1);
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellFont(i, j, sheet, fontName);
                    }
                    break;


                //字号
                case "FONTSIZE":
                    int fontSize = Functions.IsInt(cboFontSize.Text) ? Convert.ToInt32(cboFontSize.Text) : 10;
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellFontSize(i, j, sheet, fontSize);
                    }
                    break;



                //粗体
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





                //斜体
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






                //下划线
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






                //背景色
                case "BACKCOLOR":
                    colorDlg = new ColorDialog();
                    colorDlg.AllowFullOpen = true;
                    colorDlg.CustomColors = CustomColors;
                    ret = colorDlg.ShowDialog();

                    if (ret == DialogResult.OK)
                    {
                        CustomColors = colorDlg.CustomColors;
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int index = Cell1.FindColorIndex(Functions.GetRGBFromColor(colorDlg.Color), 1);
                                if (index != -1)
                                    Cell1.SetCellBackColor(i, j, sheet, index);
                            }
                        }
                    }
                    break;





                //前景色
                case "FORECOLOR":
                    colorDlg = new ColorDialog();
                    colorDlg.AllowFullOpen = true;
                    colorDlg.CustomColors = CustomColors;                    
                    ret = colorDlg.ShowDialog();

                    if (ret == DialogResult.OK)
                    {
                        CustomColors = colorDlg.CustomColors;
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int index = Cell1.FindColorIndex(Functions.GetRGBFromColor(colorDlg.Color), 1);
                                if (index != -1)
                                    Cell1.SetCellTextColor(i, j, sheet, index);
                            }
                        }
                    }
                    break;



                //折行显示
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


                //居左
                case "ALIGNLEFT":
                    if (btnAlignLeft.Checked)  //应用居左
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                //先确认没有居左,然后如果有居中或居右，先撤消，再应用居左
                                if ((align & 1) != 1)
                                {
                                    align = Functions.NumberMinus(align, 2);
                                    align = Functions.NumberMinus(align, 4);
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


                //居中
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
                                    align = Functions.NumberMinus(align, 1);
                                    align = Functions.NumberMinus(align, 2);
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


                //居右
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
                                    align = Functions.NumberMinus(align, 1);
                                    align = Functions.NumberMinus(align, 4);
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



                //居上
                case "ALIGNTOP":
                    if (btnAlignTop.Checked)  //应用居上
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                //先确认没有居上,然后如果有垂直居中或居下，先撤消，再应用居左
                                if ((align & 8) != 8)
                                {
                                    align = Functions.NumberMinus(align, 16);
                                    align = Functions.NumberMinus(align, 32);
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




                //垂直居中
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
                                    align = Functions.NumberMinus(align, 8);
                                    align = Functions.NumberMinus(align, 16);
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




                //居下
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
                                    align = Functions.NumberMinus(align, 8);
                                    align = Functions.NumberMinus(align, 32);
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



                //画网格线
                case "DRAWBORDER1":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 0, cboLine.SelectedIndex + 2, -1);
                    break;



                //画框线
                case "DRAWBORDER2":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 1, cboLine.SelectedIndex + 2, -1);
                    break;



                //画单元格左线
                case "DRAWBORDER3":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 2, cboLine.SelectedIndex + 2, -1);
                    break;



                //画单元格右线
                case "DRAWBORDER4":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 3, cboLine.SelectedIndex + 2, -1);
                    break;



                //画单元格上线
                case "DRAWBORDER5":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 4, cboLine.SelectedIndex + 2, -1);
                    break;



                //画单元格下线
                case "DRAWBORDER6":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 5, cboLine.SelectedIndex + 2, -1);
                    break;



                //画正斜线
                case "DRAWBORDER7":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 6, cboLine.SelectedIndex + 2, -1);
                    break;



                //画反斜线
                case "DRAWBORDER8":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 7, cboLine.SelectedIndex + 2, -1);
                    break;



                //抹网格线
                case "ERASEBORDER1":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 0);
                    break;



                //抹框线
                case "ERASEBORDER2":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 1);
                    break;




                //抹单元格左线
                case "ERASEBORDER3":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 2);
                    break;




                //抹单元格右线
                case "ERASEBORDER4":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 3);
                    break;




                //抹单元格上线
                case "ERASEBORDER5":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 4);
                    break;




                //抹单元格下线
                case "ERASEBORDER6":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 5);
                    break;




                //抹正斜线
                case "ERASEBORDER7":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 6);
                    break;




                //抹反斜线
                case "ERASEBORDER8":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 7);
                    break;




                //插入特殊字符
                case "SYMBOL":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5) //未锁定
                    {
                        frmSymbol SymbolForm = new frmSymbol();
                        ret = SymbolForm.ShowDialog();
                        if (ret == DialogResult.OK)
                        {
                            Cell1.InsertString(startCol, startRow, SymbolForm.lblBig.Text);

                            //    for (int i = startCol; i <= endCol; i++)
                            //    {
                            //        for (int j = startRow; j <= endRow; j++)
                            //        {
                            //            if (Cell1.GetCellInput(i, j, sheet) != 5) //未锁定
                            //            {
                            //                //Point pt = PointToClient(Control.MousePosition);

                            //                string cellString = Cell1.GetCellString2(i, j, sheet);

                            //                Cell1.SetCellString(i, j, sheet, cellString + SymbolForm.lblBig.Text);

                            //        }
                            //    }
                            //}
                        }
                    }
                    break;




                //插入图片
                case "INSERTPIC":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)  //未锁定
                    {
                        Cell1.SetCellImageDlg();
                        Cell1.ReDraw();
                    }
                    break;


                //保存
                case "SAVE":
                    string openfilename = Cell1.GetFileName();
                    if (openfilename != "")
                    {
                        this.RemoveTips();
                        Cell1.SaveFile(openfilename, 0);
                        this.DrawTips();
                    }
                    break;



                //打印
                case "PRINT":
                    Cell1.PrintPara(1, 1, 0, 0);
                    Cell1.PrintSheet(1, sheet);
                    break;



                //打印预览
                case "PRINTPREVIEW":
                    Cell1.PrintPara(1, 1, 0, 0); //单色打印
                    Cell1.PrintPreview(1, sheet);//PrintPara
                    break;


                //页面设置
                case "PAGESETUP":
                    Cell1.PrintPara(1, 1, 0, 0); //单色打印
                    Cell1.PrintPageSetup();
                    break;



                //剪切
                case "CUT":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)  //未锁定
                        Cell1.CutRange(startCol, startRow, endCol, endRow);
                    break;



                //复制
                case "COPY":
                    Cell1.CopyRange(startCol, startRow, endCol, endRow);
                    break;



                //粘贴
                case "PASTE":
                    Cell1.Paste(startCol, startRow, 2, 1, 1);
                    break;



                //撤消
                case "UNDO":
                    Cell1.Undo();
                    this.CheckUnDoReDo();
                    break;



                //重做
                case "REDO":
                    Cell1.Redo();
                    this.CheckUnDoReDo();
                    break;



                //显示/隐藏行标
                case "ROWHIDESHOW":
                    if (Cell1.GetTopLabelState(sheet) == 0) //未显示
                        Cell1.ShowTopLabel(1, sheet);
                    else
                        Cell1.ShowTopLabel(0, sheet);
                    break;



                //显示/隐藏列标
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



                //组合单元格
                case "MERGECELL":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)  //未锁定
                        Cell1.MergeCells(startCol, startRow, endCol, endRow);
                    break;



                //取消组合单元
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




                //显示比例
                case "ZOOM":
                    string strZoom = (cboZoom.Text.Trim() == string.Empty ? "100" : cboZoom.Text.Trim());
                    strZoom = strZoom.Replace("%", "");
                    strZoom = strZoom.Replace(" ", "");
                    int scale = Functions.IsInt(strZoom) ? Convert.ToInt32(strZoom) : 100;
                    cboZoom.Text = scale.ToString() + "%";

                    Cell1.SetScreenScale(sheet, scale / 100.0);
                    break;


                //插入列
                case "INSERTCOL":
                    Cell1.InsertCol(startCol, endCol - startCol + 1, sheet);
                    break;



                //删除列
                case "DELETECOL":
                    Cell1.DeleteCol(startCol, endCol - startCol + 1, sheet);
                    break;



                //插入行
                case "INSERTROW":
                    Cell1.InsertRow(startRow, endRow - startRow + 1, sheet);
                    break;



                //删除行
                case "DELETEROW":
                    Cell1.DeleteRow(startRow, endRow - startRow + 1, sheet);
                    break;

                //全选
                case "SELECTALL":
                    Cell1.SelectRange(1, 1, Cell1.GetCols(sheet) - 1, Cell1.GetRows(sheet) - 1);
                    break;


                //随机填充
                case "RNDFILL":
                    frmXsd frm = new frmXsd();
                    DialogResult drs = frm.ShowDialog();
                    if (drs == DialogResult.OK)
                    {
                        int ws = int.Parse(frm.UpDown1.Text);
                        for (int sheet1 = 0; sheet1 < Cell1.GetTotalSheets(); sheet1++)
                        {
                            for (int col = 1; col < Cell1.GetCols(sheet1); col++)
                            {
                                for (int row = 1; row < Cell1.GetRows(sheet1); row++)
                                {
                                    string no = Cell1.GetCellNote(col, row, sheet1);
                                    if (no.Trim() != "")
                                    {
                                        if (no.Trim().StartsWith("run", true, null))
                                            Functions.parse(no, col, row, sheet1, Cell1, ws);
                                    }
                                }
                            }
                        }
                        Cell1.Refresh();
                    }
                    break;


                //重复填充
                case "REPEATFILL":
                    Cell1.Fill(16);
                    break;



                //横向求和
                case "SUMH":
                    if (startCol == endCol)
                        Functions.ShowWarning("请选择一个矩形区域！");
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



                //纵向求和
                case "SUMV":
                    if (startRow == endRow)
                        Functions.ShowWarning("请选择一个矩形区域！");
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



                //双向求和
                case "SUM":
                    if (startRow == endRow && startCol == endCol)
                        Functions.ShowWarning("请选择一个矩形区域！");
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




                //清除文字
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




                //清除图像
                case "CLEARIMAGE":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //未锁定
                                //Cell1.ClearArea(i, j, i, j, sheet, 16);
                                Cell1.SetCellImage(i, j, sheet, -1, 1, 0, 0);
                        }
                    }
                    break;




                //清除格式
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




                //清除全部
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




                //表格评定
                case "REPAIR":
                    for (int st = 0; st < Cell1.GetTotalSheets(); st++)
                    {
                        for (int col = 1; col < Cell1.GetCols(st); col++)
                        {
                            for (int row = 1; row < Cell1.GetRows(st); row++)
                            {
                                key = Cell1.GetCellNote(col, row, st).ToLower();
                                if (key != "" && key.StartsWith("run"))
                                {
                                    this.Evaluate(col, row, st, false);
                                }

                            }
                        }
                    }
                    Functions.ShowInfo("评定完成！");
                    break;


                //单元格设置
                case "CELLOPTION":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)
                        Cell1.CellPropertyDlg();
                    break;


                //设置只读
                case "READONLYT":
                    for (int i = startCol; i <= endCol; i++)
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellInput(i, j, sheet, 5);
                    break;

                //设置可读
                case "READONLYF":
                    for (int i = startCol; i <= endCol; i++)
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellInput(i, j, sheet, 1);
                    break;


            }

        }

        /// <summary>
        /// 对单元格内容进行评定
        /// </summary>
        /// <param name="col">列</param>
        /// <param name="row">行</param>
        /// <param name="sheet">页</param>
        /// <param name="showWarn">对输入的内容进行检验,不是数字的话跳出提示框.(批量评定时不需要)</param>
        private void Evaluate(int col, int row, int sheet, bool showWarn)
        {
            //变量
            string key = Cell1.GetCellNote(col, row, sheet);


            //单元格变量为空，或者变量不是以"run"开始，退出
            if (key == "" || !key.StartsWith("run", true, null)) return;


            //内容
            string text = Cell1.GetCellString2(col, row, sheet);


            //如果填写为空的话,置为初始状态，退出
            if (text.Trim() == "")
            {
                Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(Functions.GetRGBFromColor(0, 0, 255), 1));
                Cell1.SetCellImage(col, row, sheet, -1, 1, 0, 0);
                return;
            }

            //加载图片
            int imageID = Cell1.AddImage(Application.StartupPath + "\\pd.wmf");

            //如果填写内容不是数值的话退出
            if (!Functions.IsNumeric(text))
            {
                if (showWarn)
                {
                    Functions.ShowWarning("输入内容可能与要求的不符，请检查！");
                }
                Cell1.SetCellImage(col, row, sheet, imageID, 1, 0, 0);
                Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(Functions.GetRGBFromColor(255, 0, 255), 1));
                return;
            }



            //对公式开始解析
            if (this.parse(key, sheet, Convert.ToDouble(text),showWarn))
            {
                Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(Functions.GetRGBFromColor(0, 0, 255), 1));
                Cell1.SetCellImage(col, row, sheet, -1, 1, 0, 0);
            }
            else
            {

                Cell1.SetCellImage(col, row, sheet, imageID, 1, 0, 0);
                Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(Functions.GetRGBFromColor(255, 0, 255), 1));
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
                tsmiUndo.Enabled = true;
            }
            else
            {
                btnUndo.Enabled = false;
                tsmiUndo.Enabled = false;
            }
            if (Cell1.GetRedoState() == 1)
            {
                btnRedo.Enabled = true;
                tsmiRedo.Enabled = true;
            }
            else
            {
                btnRedo.Enabled = false;
                tsmiRedo.Enabled = false;
            }
        }
        #endregion



        #region Cell1 右键内容菜单
        //设置只读
        private void menuReadOnly_Click(object sender, EventArgs e)
        {
            if (menuReadOnly.Checked)
            {
                menuReadOnly.Checked = false;
                this.CellOperate("ReadOnlyF");
            }
            else
            {
                menuReadOnly.Checked = true;
                this.CellOperate("ReadOnlyT");
            }
        }

        //剪切
        private void menuCut_Click(object sender, EventArgs e)
        {
            this.CellOperate("Cut");
        }

        //复制
        private void menuCopy_Click(object sender, EventArgs e)
        {
            this.CellOperate("Copy");
        }

        //粘贴
        private void menuPaste_Click(object sender, EventArgs e)
        {
            this.CellOperate("Paste");
        }


        //重复填充
        private void menuRepeatFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RepeatFill");
        }

        //随机填充
        private void menuRndFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RndFill");
        }

        //横向求和
        private void menuSumH_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumH");
        }

        //纵向求和
        private void menuSumV_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumV");
        }

        //双向求和
        private void menuSum_Click(object sender, EventArgs e)
        {
            this.CellOperate("Sum");
        }

        //插入特殊符号
        private void menuSymbol_Click(object sender, EventArgs e)
        {
            this.CellOperate("Symbol");
            //Cell1.InsertSpecialCharDlg();
        }

        //清除文字
        private void menuClearText_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearText");
        }

        //清除图像
        private void menuClearImage_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearImage");
        }

        //清除格式
        private void menuClearFormat_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearFormat");
        }

        //清除全部
        private void menuClearAll_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearAll");
        }

        //插入图片
        private void menuInsertPic_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertPic");
        }

        //组合单元格
        private void menuMergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("MergeCell");
        }

        //取消组合单元
        private void menuUnmergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnmergeCell");
        }


        //单元格设置
        private void menuCellOption_Click(object sender, EventArgs e)
        {
            this.CellOperate("CellOption");
        }

        //设置公式
        private void tsmiExpressVar_Click(object sender, EventArgs e)
        {
            frmVarGuide frm = new frmVarGuide();
            DialogResult ret = frm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                //找到选中的行列
                int startCol = 0, startRow = 0, endCol = 0, endRow = 0;
                Cell1.GetSelectRange(ref startCol, ref startRow, ref endCol, ref endRow);

                //找到当前的工作簿
                int sheet = Cell1.GetCurSheet();


                for (int i = startCol; i <= endCol; i++)
                {
                    for (int j = startRow; j <= endRow; j++)
                    {
                        Cell1.SetCellNote(i, j, sheet, frm.textBox1.Text);
                        //设置注释
                        Cell1.SetCellTip(i, j, sheet, "有变量");
                    }
                }

                //重绘
                Cell1.ReDraw();


            }

        }

        #endregion


        #region Cell1 的事件
        //当鼠标双击单元格时触发该事件。
        private void Cell1_MouseDClick(object sender, AxCELL50LibU._DCell2000Events_MouseDClickEvent e)
        {
            //判断是否为只读，只读则返回
            if (Cell1.WorkbookReadonly)
            {
                Functions.ShowInfo("当前表格为模板或已经审核，不允许编辑！");
                return;
            }
        }


        //移动单元格时触发该事件，用来调整工具条的显示
        private void Cell1_AllowMove(object sender, AxCELL50LibU._DCell2000Events_AllowMoveEvent e)
        {
            //如果只读（说明工具条是disabled），则返回
            if (Cell1.WorkbookReadonly) return;

            //获取列、行、页的信息
            int col = e.newcol;
            int row = e.newrow;
            int sheet = Cell1.GetCurSheet();

            //变量属性
            txtPos.Text = Cell1.CellToLabel(col, row);
            string var = Cell1.GetCellNote(col, row, sheet);
            cboVars.SelectedIndex = -1;
            for (int i = 0; i < cboVars.Items.Count; i++)
            {
                DataRowView item = (DataRowView)cboVars.Items[i];
                if (item["varName"].ToString() == var)
                {
                    cboVars.SelectedIndex = i;
                    break;
                }
            }

            txtVars.Text = var;
            //cboVars.Text = Cell1.GetCellNote(col, row, sheet);



            ///////////////////////////////////////////////////////////////////
            //开始对单元格的内容进行判断
            //

            //字体
            for (int i = 0; i < cboFonts.Items.Count; i++)
            {
                if (Cell1.GetFontName(Cell1.GetCellFont(col, row, sheet)) == cboFonts.Items[i].ToString())
                {
                    cboFonts.SelectedIndex = i;
                    break;
                }
            }

            //字号
            cboFontSize.Text = Cell1.GetCellFontSize(col, row, sheet).ToString();


            int style = this.Cell1.GetCellFontStyle(col, row, sheet); //字体风格

            //是否粗体?
            if ((style & 2) == 2)
                btnBold.Checked = true;
            else
                btnBold.Checked = false;


            //是否斜体?
            if ((style & 4) == 4)
                btnItalic.Checked = true;
            else
                btnItalic.Checked = false;


            //是否有下划线?
            if ((style & 8) == 8)
                btnUnderLine.Checked = true;
            else
                btnUnderLine.Checked = false;


            //是否折行显示?
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

            //左对齐
            if ((align & 1) == 1)
            {
                btnAlignLeft.Checked = true;
            }
            //右对齐
            if ((align & 2) == 2)
            {
                btnAlignRight.Checked = true;
            }
            //水平居中
            if ((align & 4) == 4)
            {
                btnAlignCenter.Checked = true;
            }
            //居上对齐
            if ((align & 8) == 8)
            {
                btnAlignTop.Checked = true;
            }
            //居下对齐
            if ((align & 16) == 16)
            {
                btnAlignBottom.Checked = true;
            }
            //垂直居中
            if ((align & 32) == 32)
            {
                btnAlignMiddle.Checked = true;
            }


            //是否只读
            if (Cell1.GetCellInput(col,row,sheet) == 5)
                btnReadOnly.Checked = true;
            else
                btnReadOnly.Checked = false;


            //判断Undo和Redo
            this.CheckUnDoReDo();

            //
            //结束判断
            ///////////////////////////////////////////////////////////////////

        }



        //当鼠标移动时触发该事件，用来获取鼠标所在的X.Y位置
        private void Cell1_MouseMoving(object sender, AxCELL50LibU._DCell2000Events_MouseMovingEvent e)
        {
            myX = e.x;
            myY = e.y;
        }


        //在 Cell 组件内点击鼠标右键时，会触发该事件，用来调出内容菜单
        private void Cell1_MenuStart(object sender, AxCELL50LibU._DCell2000Events_MenuStartEvent e)
        {
            if (Cell1.WorkbookReadonly == true) return;

            if (e.section == 1) //鼠标在表格区内
            {
                //检查"设置只读"是否选中
                if (Cell1.GetCellInput(e.col, e.row, Cell1.GetCurSheet()) == 5)
                    menuReadOnly.Checked = true;
                else
                    menuReadOnly.Checked = false;

                //显示内容菜单
                contextMenuCell.Show(Cell1, myX, myY);
            }
        }

        //当编辑结束时（按下回车键或鼠标点击其它单元格）触发该事件
        private void Cell1_EditFinish(object sender, AxCELL50LibU._DCell2000Events_EditFinishEvent e)
        {
            //检查是否有变量，如果是公式变量的话对输入进行评定
            int col = Cell1.GetCurrentCol();
            int row = Cell1.GetCurrentRow();
            int sheet = Cell1.GetCurSheet();

            //对单元格进行评定
            this.Evaluate(col, row, sheet, false);

        }
        #endregion


        #region Cell1 上的工具条
        //字体，不要用SelectedIndexChanged！
        private void cboFonts_DropDownClosed(object sender, EventArgs e)
        {
            cboFonts.Text = cboFonts.SelectedItem.ToString();
            this.CellOperate("Fonts");
        }


        //字号
        private void cboFontSize_DropDownClosed(object sender, EventArgs e)
        {
            if (cboFontSize.SelectedItem == null) return;
            cboFontSize.Text = cboFontSize.SelectedItem.ToString();
            this.CellOperate("FontSize");
        }


        //字号(Enter时触发)
        private void cboFontSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CellOperate("FontSize");
            }
        }


        //粗体
        private void btnBold_Click(object sender, EventArgs e)
        {
            this.CellOperate("Bold");
        }

        //斜体
        private void btnItalic_Click(object sender, EventArgs e)
        {
            this.CellOperate("Italic");
        }

        //下划线
        private void btnUnderLine_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnderLine");
        }

        //背景色
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            this.CellOperate("BackColor");
        }

        //前景色
        private void btnForeColor_Click(object sender, EventArgs e)
        {
            this.CellOperate("ForeColor");
        }


        //折行显示
        private void btnWordWrap_Click(object sender, EventArgs e)
        {
            this.CellOperate("WordWrap");
        }

        //居左
        private void btnAlignLeft_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignLeft");

        }

        //居中
        private void btnAlignCenter_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignCenter");
        }

        //居右
        private void btnAlignRight_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignRight");
        }


        //居上
        private void btnAlignTop_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignTop");
        }

        //垂直居中
        private void btnAlignMiddle_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignMiddle");
        }

        //居下
        private void btnAlignBottom_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignBottom");
        }


        //画网格线
        private void btnDrawBorder_ButtonClick(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder1");
        }


        //画网格线
        private void menuDrawBorder1_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder1");
        }

        //画框线
        private void menuDrawBorder2_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder2");
        }

        //画单元格左线
        private void menuDrawBorder3_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder3");
        }

        //画单元格右线
        private void menuDrawBorder4_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder4");
        }


        //画单元格上线
        private void menuDrawBorder5_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder5");
        }

        //画单元格下线
        private void menuDrawBorder6_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder6");
        }

        //画正斜线
        private void menuDrawBorder7_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder7");
        }

        //画反斜线
        private void menuDrawBorder8_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder8");
        }

        //抹网格线
        private void btnEraseBorder_ButtonClick(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder1");
        }

        //抹网格线
        private void menuEraseBorder1_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder1");
        }

        //抹框线
        private void menuEraseBorder2_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder2");
        }

        //抹单元格左线
        private void menuEraseBorder3_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder3");
        }

        //抹单元格右线
        private void menuEraseBorder4_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder4");
        }

        //抹单元格上线
        private void menuEraseBorder5_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder5");
        }

        //抹单元格下线
        private void menuEraseBorder6_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder6");
        }


        //抹正斜线
        private void menuEraseBorder7_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder7");
        }

        //抹反斜线
        private void menuEraseBorder8_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder8");
        }

        //插入特殊符号
        private void btnSymbol_Click(object sender, EventArgs e)
        {
            this.CellOperate("Symbol");
            //Cell1.InsertSpecialCharDlg();
        }

        //插入图片
        private void btnInsertPic_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertPic");
        }

        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.CellOperate("Save");
        }

        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.CellOperate("Print");
        }


        //打印预览
        private void btnPrintpreview_Click(object sender, EventArgs e)
        {
            this.CellOperate("Printpreview");
        }

        //剪切
        private void btnCut_Click(object sender, EventArgs e)
        {
            this.CellOperate("Cut");
        }

        //复制
        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.CellOperate("Copy");
        }

        //粘贴
        private void btnPaste_Click(object sender, EventArgs e)
        {
            this.CellOperate("Paste");
        }

        //撤消
        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Undo");
        }

        //重做
        private void btnRedo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Redo");
        }

        //显示/隐藏行标
        private void btnRow_Click(object sender, EventArgs e)
        {
            this.CellOperate("RowHideShow");
        }

        //显示/隐藏列标
        private void btnCol_Click(object sender, EventArgs e)
        {
            this.CellOperate("ColHideShow");
        }

        //显示/隐藏网格线
        private void btnGridline_Click(object sender, EventArgs e)
        {
            this.CellOperate("Gridline");
        }

        //组合单元格
        private void btnMergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("MergeCell");
        }

        //取消组合单元
        private void btnUnmergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnmergeCell");
        }


        //显示比例
        private void cboZoom_DropDownClosed(object sender, EventArgs e)
        {
            if (cboZoom.SelectedItem == null) return;
            cboZoom.Text = cboZoom.SelectedItem.ToString();
            this.CellOperate("Zoom");
        }

        //显示比例(Enter时触发)
        private void cboZoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CellOperate("Zoom");
            }
        }



        //插入列
        private void btnInsertCol_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertCol");
        }

        //删除列
        private void btnDeleteCol_Click(object sender, EventArgs e)
        {
            this.CellOperate("DeleteCol");
        }

        //插入行
        private void btnInsertRow_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertRow");
        }

        //删除行
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            this.CellOperate("DeleteRow");
        }

        //随机填充
        private void btnRndFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RndFill");
        }

        //横向求和
        private void btnSumH_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumH");
        }

        //纵向求和
        private void btnSumV_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumV");
        }

        //双向求和
        private void btnSum_Click(object sender, EventArgs e)
        {
            this.CellOperate("Sum");
        }

        //设置只读
        private void btnReadOnly_Click(object sender, EventArgs e)
        {
            if (btnReadOnly.Checked)
            {
                this.CellOperate("ReadOnlyT");
            }
            else
            {
                this.CellOperate("ReadOnlyF");
            }
        }
        #endregion


        #region 变量面板事件及处理方法
        //移除变量
        private void btnRemove_Click(object sender, EventArgs e)
        {
            //判断
            if (txtPos.Text == "") return;

            //获取单元格位置
            int sheet = 0, row = 0, col = 0;
            Cell1.LabelToCell(txtPos.Text, ref col, ref row);
            sheet = Cell1.GetCurSheet();


            //移除变量
            Cell1.SetCellNote(col, row, sheet, "");

            //移除注释
            Cell1.SetCellTip(col, row, sheet, "");

            txtVars.Text = "";
            
            //重绘
            Cell1.ReDraw();
        }

        //更新变量
        private void btnUpdateVar_Click(object sender, EventArgs e)
        {
            //判断
            if (txtPos.Text == "" || cboVars.SelectedIndex == -1) return;

            //获取单元格位置
            int sheet = 0, row = 0, col = 0;
            Cell1.LabelToCell(txtPos.Text, ref col, ref row);
            sheet = Cell1.GetCurSheet();

            Cell1.SetCellNote(col, row, sheet, cboVars.SelectedValue.ToString());

            //设置注释
            Cell1.SetCellTip(col, row, sheet, "有变量");

            //重绘
            Cell1.ReDraw();
        }

        //更新变量2
        private void btnUpdateVar2_Click(object sender, EventArgs e)
        {
            //判断
            if (txtPos.Text == "" || txtVars.Text.Trim() == "") return;

            //获取单元格位置
            int sheet = 0, row = 0, col = 0;
            Cell1.LabelToCell(txtPos.Text, ref col, ref row);
            sheet = Cell1.GetCurSheet();

            Cell1.SetCellNote(col, row, sheet, txtVars.Text.Trim());

            //设置注释
            Cell1.SetCellTip(col, row, sheet, "有变量");

            //重绘
            Cell1.ReDraw();
        }


        /// <summary>
        /// 设置注释（提醒用户该单元格有变量）
        /// </summary>
        private void DrawTips()
        {
            for (int sheet = 0; sheet < Cell1.GetTotalSheets(); sheet++)
            {
                for (int col = 1; col < Cell1.GetCols(sheet); col++)
                {
                    for (int row = 1; row < Cell1.GetRows(sheet); row++)
                    {
                        if (Cell1.GetCellNote(col, row, sheet) != "")
                        {
                            Cell1.SetCellTip(col, row, sheet, "有变量");
                        }
                    }
                }
            }

            Cell1.ReDraw();
        }

        /// <summary>
        /// 移除注释
        /// </summary>
        private void RemoveTips()
        {
            for (int sheet = 0; sheet < Cell1.GetTotalSheets(); sheet++)
            {
                for (int col = 1; col < Cell1.GetCols(sheet); col++)
                {
                    for (int row = 1; row < Cell1.GetRows(sheet); row++)
                    {
                        if (Cell1.GetCellNote(col, row, sheet) != "")
                            Cell1.SetCellTip(col, row, sheet, "");
                    }
                }
            }
            Cell1.ReDraw();
        }

        //移除变量
        private void tsmiRemove_Click(object sender, EventArgs e)
        {
            btnRemove.PerformClick();
        }


        //移除所有变量
        private void btnRemoveAllVars_Click(object sender, EventArgs e)
        {
            if (Functions.ShowQuestion("确定要移除所有变量？") != DialogResult.Yes) return;

            for (int sheet = 0; sheet < Cell1.GetTotalSheets(); sheet++)
            {
                for (int col = 1; col < Cell1.GetCols(sheet); col++)
                {
                    for (int row = 1; row < Cell1.GetRows(sheet); row++)
                    {
                        if (Cell1.GetCellNote(col, row, sheet) != "")
                        {
                            Cell1.SetCellTip(col, row, sheet, "");
                            Cell1.SetCellNote(col, row, sheet, "");
                        }
                    }
                }
            }
            Cell1.ReDraw();
        }
        #endregion

        /// <summary>
        /// 对公式变量进行解析
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="sheet">页，检查条件语句时用到</param>
        /// <param name="compare">需要比较的值</param>
        /// <returns>符合条件返回ture</returns>
        /// <returns>是否</returns>
        private bool parse(string expression, int sheet, double compare, bool debugMode)
        {
            string str = expression.Replace("\r", "").Replace("\n", "").Replace(" ", "").ToLower();
            str = str.Replace("run{", "");
            str = str.Replace("}", "");
            str = str.Replace("break;", "#");

            //如果为空
            if (str == "") return false;

            //最后的表达式
            string newExpression = "";
            int col = 0;
            int row = 0;

            //条件数组
            string[] condArr = str.Split('#');
            if (condArr.Length > 1)
            {
                for (int i = 0; i < condArr.Length; i++)
                {
                    if (condArr[i] != "")
                    {
                        string[] subCondArr = condArr[i].Split(':');
                        
                        if (subCondArr.Length > 1)
                        {
                            if (Cell1.LabelToCell(subCondArr[0], ref col, ref row))
                            {
                                if (Cell1.GetCellDouble(col, row, sheet).ToString() == "1")
                                {
                                    newExpression = subCondArr[1];
                                    break;
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                newExpression = str;
            }



            //对最后表达式进行解析
            string strMin = "";  //"最小"表达式
            string strMax = "";  //"最大"表达式
            string strX = "";    //"变量"表达式
            string strX1 = "";   //strX的后半部分，即单元格
            string strXVal = ""; //单元格的值
            string strOther = ""; //其他变量

            if (newExpression == "") return false;

            string[] arr = newExpression.Split(';');
            if (arr.Length <= 1) return false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].StartsWith("min"))
                    strMin = arr[i];
                if (arr[i].StartsWith("max"))
                    strMax = arr[i];
                if (arr[i].StartsWith("x"))
                    strX = arr[i];
                if (arr[i].StartsWith("value"))
                    strOther = arr[i];
            }
            if (strX != "" && strX.Contains("="))
            {
                strX1 = strX.Split('=')[1];
                if (Cell1.LabelToCell(strX1, ref col, ref row))
                {
                    strXVal = Cell1.GetCellString(col, row, sheet);
                    if (!Functions.IsNumeric(strXVal))
                        strXVal = "";
                }
            }

            strMin = strMin.Replace("min", compare.ToString()).Replace("x", strXVal);
            strMax = strMax.Replace("max", compare.ToString()).Replace("x", strXVal);
            strOther = strOther.Replace("value", compare.ToString()).Replace("x", strXVal);

            if (debugMode)
            {
                Functions.ShowInfo("Min = " + strMin);
                Functions.ShowInfo("Max = " + strMax);
                Functions.ShowInfo("Value = " + strOther);
            }


            if (((strMin == "") ? true : Functions.Eval(strMin)) && ((strMax == "") ? true : Functions.Eval(strMax)) && ((strOther == "") ? true : Functions.Eval(strOther)))
                return true;
            else
                return false;

        }

        //移除所有公式
        private void btnRemoveAllExpression_Click(object sender, EventArgs e)
        {
            if (Functions.ShowQuestion("确定要移除所有公式？") != DialogResult.Yes) return;

            //清除所有公式
            for (int sheet = 0; sheet < Cell1.GetTotalSheets(); sheet++)
            {
                Cell1.ClearArea(1, 1, Cell1.GetCols(sheet), Cell1.GetRows(sheet), sheet, 2);
            }

            Cell1.ReDraw();
        }



        

        

        

        

        


    }
}