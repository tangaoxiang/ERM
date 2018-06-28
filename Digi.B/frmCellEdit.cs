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
        

        #region ��ʼ��

        //ʵ�����Զ������������
        private DigiPower.ERM.BLL.Vars varsData = new DigiPower.ERM.BLL.Vars();

        //�༭���ļ�
        private string _fileName;

        //�Զ�����ɫ 
        int[] CustomColors;

        //������ƶ�ʱ��MouseMoving�¼��Դ˸�ֵ�����Ը�����Ҽ��˵���λ
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

            //����ѡ��
            InitComboBox();
           
        }



        /// <summary>
        /// ��ʼ������ComboBox
        /// </summary>
        private void InitComboBox()
        {

            //������弯
            FontFamily[] fonts = (new InstalledFontCollection()).Families;
            for (int i = 0; i < fonts.Length; i++)
            {
                cboFonts.Items.Add(fonts[i].Name);
            }
            //����Ĭ������
            cboFonts.Text = Cell1.GetDefaultFontName();
            //����Ĭ�������С
            cboFontSize.Text = Cell1.GetDefaultFontSize().ToString();

            //�߿�������
            cboLine.ImageList = imageBorder;
            cboLine.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < imageBorder.Images.Count; i++)
            {
                cboLine.Items.Add(new Digi.B.ComboBoxExItem("", i));
            }
            cboLine.SelectedIndex = 0;

            //��ʾ����
            cboZoom.Text = "100%";

            //�Զ������
            DataSet ds = varsData.GetAllList();
            ds.Tables[0].DefaultView.Sort = "varid";
            cboVars.DisplayMember = "varTitle";
            cboVars.ValueMember = "varName";
            cboVars.DataSource = ds.Tables[0].DefaultView;
            cboVars.SelectedIndex = -1;

        }


        private void frmCellEdit_Load(object sender, EventArgs e)
        {   


            //�򿪱��
            Cell1.OpenFile(this._fileName, "");
            Cell1.SelectRange(-1, -1, -1, -1);
            Cell1.ShowCellTip = true;


            //����ע��
            this.DrawTips();

            this.ActiveControl = Cell1; //�۽�
            Cell1.EnableUndo(1);     //��������
            
        }

        private void frmCellEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CheckSave();
        }

        //�ļ��Ƿ���Ҫ�����ģ��Ƿ���Ҫ����
        private void CheckSave()
        {
            if (Cell1.IsModified() == 1) //�ļ��Ѿ����޸�
            {
                DialogResult ret = Functions.ShowQuestion("����Ѿ����޸ģ���Ҫ������");
                {
                    if (ret == DialogResult.Yes)
                    {
                        CellOperate("Save");
                    }
                }
            }
        }
        #endregion




        #region ���˵�
        private void tsmiSave_Click(object sender, EventArgs e)
        {
            this.CellOperate("Save");
        }

        //�˳�
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //����
        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Undo");
        }


        //����
        private void tsmiRedo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Redo");
        }

        //����
        private void tsmiCut_Click(object sender, EventArgs e)
        {
            this.CellOperate("Cut");
        }

        //����
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            this.CellOperate("Copy");
        }

        //ճ��
        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            this.CellOperate("Paste");
        }

        //ȫѡ
        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            this.CellOperate("SelectAll");
        }

        //�ظ����
        private void tsmiRepeatFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RepeatFill");
        }

        //������
        private void tsmiRndFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RndFill");
        }

        //�������
        private void tsmiSumH_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumH");
        }

        //�������
        private void tsmiSumV_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumV");
        }

        //˫�����
        private void tsmiSum_Click(object sender, EventArgs e)
        {
            this.CellOperate("Sum");
        }

        //�������
        private void tsmiClearText_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearText");
        }

        //���ͼ��
        private void tsmiClearImage_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearImage");
        }

        //�����ʽ
        private void tsmiClearFormat_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearFormat");
        }

        //���ȫ��
        private void tsmiClearAll_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearAll");
        }

        //�����������
        private void tsmiSymbol_Click(object sender, EventArgs e)
        {
            this.CellOperate("Symbol");
            //Cell1.InsertSpecialCharDlg();
        }

        //����ͼƬ
        private void tsmiInsertPic_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertPic");
        }

        //��ϵ�Ԫ��
        private void tsmiMergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("MergeCell");
        }

        //ȡ����ϵ�Ԫ
        private void tsmiUnmergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnmergeCell");
        }

        //������
        private void tsmiRepair_Click(object sender, EventArgs e)
        {
            this.CellOperate("Repair");
        }

        //��Ԫ������
        private void tsmiCellOption_Click(object sender, EventArgs e)
        {
            this.CellOperate("CellOption");
        }
        #endregion




        #region �˵���������ķ���
        /// <summary>
        /// ���ؼ����ֲ�����ʵ�ַ���(���塢�ֺš����塢б�塢���롢���ƵȵȵĴ���)
        /// </summary>
        /// <param name="key"></param>
        private void CellOperate(string key)
        {
            //ת���ɴ�д
            string UpKey = key.ToUpper();


            //�ҵ�ѡ�е�����
            int startCol = 0, startRow = 0, endCol = 0, endRow = 0;
            Cell1.GetSelectRange(ref startCol, ref startRow, ref endCol, ref endRow);

            //�ҵ���ǰ�Ĺ�����
            int sheet = Cell1.GetCurSheet();

            //��ɫѡ�۶Ի���
            ColorDialog colorDlg;
            DialogResult ret;

            //���²������⣬���ûѡ�е�Ԫ�����˳�
            if (UpKey != "SAVE" && UpKey != "PAGESETUP" && UpKey != "PRINTPREVIEW" && UpKey != "PRINT"          //"��ӡ������" ����Ҫѡ�е�Ԫ��
                && UpKey != "UNDO" && UpKey != "REDO"                                        //"��������" ����Ҫѡ�е�Ԫ��
                && UpKey != "ROWHIDESHOW" && UpKey != "COLHIDESHOW" && UpKey != "GRIDLINE"   //"��ʾ/�����бꡢ�бꡢ������" ����Ҫѡ�е�Ԫ��
                && UpKey != "ZOOM" && UpKey != "REPAIR" && UpKey != "SELECTALL")             //"��ʾ����������ȫѡ" ����Ҫѡ�е�Ԫ��
                if (startCol <= 0 || startRow <= 0 || endCol <= 0 || endRow <= 0) return;



            switch (UpKey)
            {
                //����
                case "FONTS":
                    int fontName = Cell1.FindFontIndex(cboFonts.SelectedItem.ToString(), 1);
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellFont(i, j, sheet, fontName);
                    }
                    break;


                //�ֺ�
                case "FONTSIZE":
                    int fontSize = Functions.IsInt(cboFontSize.Text) ? Convert.ToInt32(cboFontSize.Text) : 10;
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellFontSize(i, j, sheet, fontSize);
                    }
                    break;



                //����
                case "BOLD":
                    if (btnBold.Checked)  //Ӧ�ô���
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
                    else  //ȡ������
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





                //б��
                case "ITALIC":
                    if (btnItalic.Checked)  //Ӧ��б��
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
                    else  //ȡ��б��
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






                //�»���
                case "UNDERLINE":
                    if (btnItalic.Checked)  //Ӧ���»���
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
                    else  //ȡ���»���
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






                //����ɫ
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





                //ǰ��ɫ
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



                //������ʾ
                case "WORDWRAP":
                    if (btnWordWrap.Checked)  //Ӧ��������ʾ
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                                Cell1.SetCellTextStyle(i, j, sheet, 2);
                        }
                    }
                    else //ȡ��������ʾ
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                                Cell1.SetCellTextStyle(i, j, sheet, 1);
                        }
                    }
                    break;


                //����
                case "ALIGNLEFT":
                    if (btnAlignLeft.Checked)  //Ӧ�þ���
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                //��ȷ��û�о���,Ȼ������о��л���ң��ȳ�������Ӧ�þ���
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
                    else //ȡ������
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


                //����
                case "ALIGNCENTER":
                    if (btnAlignCenter.Checked)  //Ӧ�þ���
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
                    else //ȡ������
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


                //����
                case "ALIGNRIGHT":
                    if (btnAlignRight.Checked)  //Ӧ�þ���
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
                    else //ȡ������
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



                //����
                case "ALIGNTOP":
                    if (btnAlignTop.Checked)  //Ӧ�þ���
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                //��ȷ��û�о���,Ȼ������д�ֱ���л���£��ȳ�������Ӧ�þ���
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
                    else //ȡ������
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




                //��ֱ����
                case "ALIGNMIDDLE":
                    if (btnAlignMiddle.Checked)  //Ӧ�ô�ֱ����
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
                    else //ȡ����ֱ����
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




                //����
                case "ALIGNBOTTOM":
                    if (btnAlignBottom.Checked)  //Ӧ�þ���
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
                    else //ȡ������
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



                //��������
                case "DRAWBORDER1":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 0, cboLine.SelectedIndex + 2, -1);
                    break;



                //������
                case "DRAWBORDER2":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 1, cboLine.SelectedIndex + 2, -1);
                    break;



                //����Ԫ������
                case "DRAWBORDER3":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 2, cboLine.SelectedIndex + 2, -1);
                    break;



                //����Ԫ������
                case "DRAWBORDER4":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 3, cboLine.SelectedIndex + 2, -1);
                    break;



                //����Ԫ������
                case "DRAWBORDER5":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 4, cboLine.SelectedIndex + 2, -1);
                    break;



                //����Ԫ������
                case "DRAWBORDER6":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 5, cboLine.SelectedIndex + 2, -1);
                    break;



                //����б��
                case "DRAWBORDER7":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 6, cboLine.SelectedIndex + 2, -1);
                    break;



                //����б��
                case "DRAWBORDER8":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 7, cboLine.SelectedIndex + 2, -1);
                    break;



                //Ĩ������
                case "ERASEBORDER1":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 0);
                    break;



                //Ĩ����
                case "ERASEBORDER2":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 1);
                    break;




                //Ĩ��Ԫ������
                case "ERASEBORDER3":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 2);
                    break;




                //Ĩ��Ԫ������
                case "ERASEBORDER4":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 3);
                    break;




                //Ĩ��Ԫ������
                case "ERASEBORDER5":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 4);
                    break;




                //Ĩ��Ԫ������
                case "ERASEBORDER6":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 5);
                    break;




                //Ĩ��б��
                case "ERASEBORDER7":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 6);
                    break;




                //Ĩ��б��
                case "ERASEBORDER8":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 7);
                    break;




                //���������ַ�
                case "SYMBOL":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5) //δ����
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
                            //            if (Cell1.GetCellInput(i, j, sheet) != 5) //δ����
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




                //����ͼƬ
                case "INSERTPIC":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)  //δ����
                    {
                        Cell1.SetCellImageDlg();
                        Cell1.ReDraw();
                    }
                    break;


                //����
                case "SAVE":
                    string openfilename = Cell1.GetFileName();
                    if (openfilename != "")
                    {
                        this.RemoveTips();
                        Cell1.SaveFile(openfilename, 0);
                        this.DrawTips();
                    }
                    break;



                //��ӡ
                case "PRINT":
                    Cell1.PrintPara(1, 1, 0, 0);
                    Cell1.PrintSheet(1, sheet);
                    break;



                //��ӡԤ��
                case "PRINTPREVIEW":
                    Cell1.PrintPara(1, 1, 0, 0); //��ɫ��ӡ
                    Cell1.PrintPreview(1, sheet);//PrintPara
                    break;


                //ҳ������
                case "PAGESETUP":
                    Cell1.PrintPara(1, 1, 0, 0); //��ɫ��ӡ
                    Cell1.PrintPageSetup();
                    break;



                //����
                case "CUT":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)  //δ����
                        Cell1.CutRange(startCol, startRow, endCol, endRow);
                    break;



                //����
                case "COPY":
                    Cell1.CopyRange(startCol, startRow, endCol, endRow);
                    break;



                //ճ��
                case "PASTE":
                    Cell1.Paste(startCol, startRow, 2, 1, 1);
                    break;



                //����
                case "UNDO":
                    Cell1.Undo();
                    this.CheckUnDoReDo();
                    break;



                //����
                case "REDO":
                    Cell1.Redo();
                    this.CheckUnDoReDo();
                    break;



                //��ʾ/�����б�
                case "ROWHIDESHOW":
                    if (Cell1.GetTopLabelState(sheet) == 0) //δ��ʾ
                        Cell1.ShowTopLabel(1, sheet);
                    else
                        Cell1.ShowTopLabel(0, sheet);
                    break;



                //��ʾ/�����б�
                case "COLHIDESHOW":
                    if (Cell1.GetSideLabelState(sheet) == 0) //δ��ʾ
                        Cell1.ShowSideLabel(1, sheet);
                    else
                        Cell1.ShowSideLabel(0, sheet);
                    break;




                ///��ʾ/����������
                case "GRIDLINE":
                    if (Cell1.GetGridLineState(sheet) == 0) //δ��ʾ
                        Cell1.ShowGridLine(1, sheet);
                    else
                        Cell1.ShowGridLine(0, sheet);
                    break;



                //��ϵ�Ԫ��
                case "MERGECELL":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)  //δ����
                        Cell1.MergeCells(startCol, startRow, endCol, endRow);
                    break;



                //ȡ����ϵ�Ԫ
                case "UNMERGECELL":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5) //δ����
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




                //��ʾ����
                case "ZOOM":
                    string strZoom = (cboZoom.Text.Trim() == string.Empty ? "100" : cboZoom.Text.Trim());
                    strZoom = strZoom.Replace("%", "");
                    strZoom = strZoom.Replace(" ", "");
                    int scale = Functions.IsInt(strZoom) ? Convert.ToInt32(strZoom) : 100;
                    cboZoom.Text = scale.ToString() + "%";

                    Cell1.SetScreenScale(sheet, scale / 100.0);
                    break;


                //������
                case "INSERTCOL":
                    Cell1.InsertCol(startCol, endCol - startCol + 1, sheet);
                    break;



                //ɾ����
                case "DELETECOL":
                    Cell1.DeleteCol(startCol, endCol - startCol + 1, sheet);
                    break;



                //������
                case "INSERTROW":
                    Cell1.InsertRow(startRow, endRow - startRow + 1, sheet);
                    break;



                //ɾ����
                case "DELETEROW":
                    Cell1.DeleteRow(startRow, endRow - startRow + 1, sheet);
                    break;

                //ȫѡ
                case "SELECTALL":
                    Cell1.SelectRange(1, 1, Cell1.GetCols(sheet) - 1, Cell1.GetRows(sheet) - 1);
                    break;


                //������
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


                //�ظ����
                case "REPEATFILL":
                    Cell1.Fill(16);
                    break;



                //�������
                case "SUMH":
                    if (startCol == endCol)
                        Functions.ShowWarning("��ѡ��һ����������");
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



                //�������
                case "SUMV":
                    if (startRow == endRow)
                        Functions.ShowWarning("��ѡ��һ����������");
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



                //˫�����
                case "SUM":
                    if (startRow == endRow && startCol == endCol)
                        Functions.ShowWarning("��ѡ��һ����������");
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




                //�������
                case "CLEARTEXT":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //δ����
                                Cell1.ClearArea(i, j, i, j, sheet, 1);
                        }
                    }
                    break;




                //���ͼ��
                case "CLEARIMAGE":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //δ����
                                //Cell1.ClearArea(i, j, i, j, sheet, 16);
                                Cell1.SetCellImage(i, j, sheet, -1, 1, 0, 0);
                        }
                    }
                    break;




                //�����ʽ
                case "CLEARFORMAT":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //δ����
                                Cell1.ClearArea(i, j, i, j, sheet, 8);
                        }
                    }
                    break;




                //���ȫ��
                case "CLEARALL":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //δ����
                                Cell1.ClearArea(i, j, i, j, sheet, 32);
                        }
                    }
                    break;




                //�������
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
                    Functions.ShowInfo("������ɣ�");
                    break;


                //��Ԫ������
                case "CELLOPTION":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)
                        Cell1.CellPropertyDlg();
                    break;


                //����ֻ��
                case "READONLYT":
                    for (int i = startCol; i <= endCol; i++)
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellInput(i, j, sheet, 5);
                    break;

                //���ÿɶ�
                case "READONLYF":
                    for (int i = startCol; i <= endCol; i++)
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellInput(i, j, sheet, 1);
                    break;


            }

        }

        /// <summary>
        /// �Ե�Ԫ�����ݽ�������
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">��</param>
        /// <param name="sheet">ҳ</param>
        /// <param name="showWarn">����������ݽ��м���,�������ֵĻ�������ʾ��.(��������ʱ����Ҫ)</param>
        private void Evaluate(int col, int row, int sheet, bool showWarn)
        {
            //����
            string key = Cell1.GetCellNote(col, row, sheet);


            //��Ԫ�����Ϊ�գ����߱���������"run"��ʼ���˳�
            if (key == "" || !key.StartsWith("run", true, null)) return;


            //����
            string text = Cell1.GetCellString2(col, row, sheet);


            //�����дΪ�յĻ�,��Ϊ��ʼ״̬���˳�
            if (text.Trim() == "")
            {
                Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(Functions.GetRGBFromColor(0, 0, 255), 1));
                Cell1.SetCellImage(col, row, sheet, -1, 1, 0, 0);
                return;
            }

            //����ͼƬ
            int imageID = Cell1.AddImage(Application.StartupPath + "\\pd.wmf");

            //�����д���ݲ�����ֵ�Ļ��˳�
            if (!Functions.IsNumeric(text))
            {
                if (showWarn)
                {
                    Functions.ShowWarning("�������ݿ�����Ҫ��Ĳ��������飡");
                }
                Cell1.SetCellImage(col, row, sheet, imageID, 1, 0, 0);
                Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(Functions.GetRGBFromColor(255, 0, 255), 1));
                return;
            }



            //�Թ�ʽ��ʼ����
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
        /// �������ظ�������ť��״̬���
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



        #region Cell1 �Ҽ����ݲ˵�
        //����ֻ��
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

        //����
        private void menuCut_Click(object sender, EventArgs e)
        {
            this.CellOperate("Cut");
        }

        //����
        private void menuCopy_Click(object sender, EventArgs e)
        {
            this.CellOperate("Copy");
        }

        //ճ��
        private void menuPaste_Click(object sender, EventArgs e)
        {
            this.CellOperate("Paste");
        }


        //�ظ����
        private void menuRepeatFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RepeatFill");
        }

        //������
        private void menuRndFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RndFill");
        }

        //�������
        private void menuSumH_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumH");
        }

        //�������
        private void menuSumV_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumV");
        }

        //˫�����
        private void menuSum_Click(object sender, EventArgs e)
        {
            this.CellOperate("Sum");
        }

        //�����������
        private void menuSymbol_Click(object sender, EventArgs e)
        {
            this.CellOperate("Symbol");
            //Cell1.InsertSpecialCharDlg();
        }

        //�������
        private void menuClearText_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearText");
        }

        //���ͼ��
        private void menuClearImage_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearImage");
        }

        //�����ʽ
        private void menuClearFormat_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearFormat");
        }

        //���ȫ��
        private void menuClearAll_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearAll");
        }

        //����ͼƬ
        private void menuInsertPic_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertPic");
        }

        //��ϵ�Ԫ��
        private void menuMergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("MergeCell");
        }

        //ȡ����ϵ�Ԫ
        private void menuUnmergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnmergeCell");
        }


        //��Ԫ������
        private void menuCellOption_Click(object sender, EventArgs e)
        {
            this.CellOperate("CellOption");
        }

        //���ù�ʽ
        private void tsmiExpressVar_Click(object sender, EventArgs e)
        {
            frmVarGuide frm = new frmVarGuide();
            DialogResult ret = frm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                //�ҵ�ѡ�е�����
                int startCol = 0, startRow = 0, endCol = 0, endRow = 0;
                Cell1.GetSelectRange(ref startCol, ref startRow, ref endCol, ref endRow);

                //�ҵ���ǰ�Ĺ�����
                int sheet = Cell1.GetCurSheet();


                for (int i = startCol; i <= endCol; i++)
                {
                    for (int j = startRow; j <= endRow; j++)
                    {
                        Cell1.SetCellNote(i, j, sheet, frm.textBox1.Text);
                        //����ע��
                        Cell1.SetCellTip(i, j, sheet, "�б���");
                    }
                }

                //�ػ�
                Cell1.ReDraw();


            }

        }

        #endregion


        #region Cell1 ���¼�
        //�����˫����Ԫ��ʱ�������¼���
        private void Cell1_MouseDClick(object sender, AxCELL50LibU._DCell2000Events_MouseDClickEvent e)
        {
            //�ж��Ƿ�Ϊֻ����ֻ���򷵻�
            if (Cell1.WorkbookReadonly)
            {
                Functions.ShowInfo("��ǰ���Ϊģ����Ѿ���ˣ�������༭��");
                return;
            }
        }


        //�ƶ���Ԫ��ʱ�������¼���������������������ʾ
        private void Cell1_AllowMove(object sender, AxCELL50LibU._DCell2000Events_AllowMoveEvent e)
        {
            //���ֻ����˵����������disabled�����򷵻�
            if (Cell1.WorkbookReadonly) return;

            //��ȡ�С��С�ҳ����Ϣ
            int col = e.newcol;
            int row = e.newrow;
            int sheet = Cell1.GetCurSheet();

            //��������
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
            //��ʼ�Ե�Ԫ������ݽ����ж�
            //

            //����
            for (int i = 0; i < cboFonts.Items.Count; i++)
            {
                if (Cell1.GetFontName(Cell1.GetCellFont(col, row, sheet)) == cboFonts.Items[i].ToString())
                {
                    cboFonts.SelectedIndex = i;
                    break;
                }
            }

            //�ֺ�
            cboFontSize.Text = Cell1.GetCellFontSize(col, row, sheet).ToString();


            int style = this.Cell1.GetCellFontStyle(col, row, sheet); //������

            //�Ƿ����?
            if ((style & 2) == 2)
                btnBold.Checked = true;
            else
                btnBold.Checked = false;


            //�Ƿ�б��?
            if ((style & 4) == 4)
                btnItalic.Checked = true;
            else
                btnItalic.Checked = false;


            //�Ƿ����»���?
            if ((style & 8) == 8)
                btnUnderLine.Checked = true;
            else
                btnUnderLine.Checked = false;


            //�Ƿ�������ʾ?
            if (Cell1.GetCellTextStyle(col, row, sheet) == 2)
                btnWordWrap.Checked = true;
            else
                btnWordWrap.Checked = false;




            int align = this.Cell1.GetCellAlign(col, row, sheet);  //��Ԫ��Ķ��뷽ʽ
            btnAlignLeft.Checked = false;
            btnAlignCenter.Checked = false;
            btnAlignRight.Checked = false;
            btnAlignTop.Checked = false;
            btnAlignMiddle.Checked = false;
            btnAlignBottom.Checked = false;

            //�����
            if ((align & 1) == 1)
            {
                btnAlignLeft.Checked = true;
            }
            //�Ҷ���
            if ((align & 2) == 2)
            {
                btnAlignRight.Checked = true;
            }
            //ˮƽ����
            if ((align & 4) == 4)
            {
                btnAlignCenter.Checked = true;
            }
            //���϶���
            if ((align & 8) == 8)
            {
                btnAlignTop.Checked = true;
            }
            //���¶���
            if ((align & 16) == 16)
            {
                btnAlignBottom.Checked = true;
            }
            //��ֱ����
            if ((align & 32) == 32)
            {
                btnAlignMiddle.Checked = true;
            }


            //�Ƿ�ֻ��
            if (Cell1.GetCellInput(col,row,sheet) == 5)
                btnReadOnly.Checked = true;
            else
                btnReadOnly.Checked = false;


            //�ж�Undo��Redo
            this.CheckUnDoReDo();

            //
            //�����ж�
            ///////////////////////////////////////////////////////////////////

        }



        //������ƶ�ʱ�������¼���������ȡ������ڵ�X.Yλ��
        private void Cell1_MouseMoving(object sender, AxCELL50LibU._DCell2000Events_MouseMovingEvent e)
        {
            myX = e.x;
            myY = e.y;
        }


        //�� Cell ����ڵ������Ҽ�ʱ���ᴥ�����¼��������������ݲ˵�
        private void Cell1_MenuStart(object sender, AxCELL50LibU._DCell2000Events_MenuStartEvent e)
        {
            if (Cell1.WorkbookReadonly == true) return;

            if (e.section == 1) //����ڱ������
            {
                //���"����ֻ��"�Ƿ�ѡ��
                if (Cell1.GetCellInput(e.col, e.row, Cell1.GetCurSheet()) == 5)
                    menuReadOnly.Checked = true;
                else
                    menuReadOnly.Checked = false;

                //��ʾ���ݲ˵�
                contextMenuCell.Show(Cell1, myX, myY);
            }
        }

        //���༭����ʱ�����»س����������������Ԫ�񣩴������¼�
        private void Cell1_EditFinish(object sender, AxCELL50LibU._DCell2000Events_EditFinishEvent e)
        {
            //����Ƿ��б���������ǹ�ʽ�����Ļ��������������
            int col = Cell1.GetCurrentCol();
            int row = Cell1.GetCurrentRow();
            int sheet = Cell1.GetCurSheet();

            //�Ե�Ԫ���������
            this.Evaluate(col, row, sheet, false);

        }
        #endregion


        #region Cell1 �ϵĹ�����
        //���壬��Ҫ��SelectedIndexChanged��
        private void cboFonts_DropDownClosed(object sender, EventArgs e)
        {
            cboFonts.Text = cboFonts.SelectedItem.ToString();
            this.CellOperate("Fonts");
        }


        //�ֺ�
        private void cboFontSize_DropDownClosed(object sender, EventArgs e)
        {
            if (cboFontSize.SelectedItem == null) return;
            cboFontSize.Text = cboFontSize.SelectedItem.ToString();
            this.CellOperate("FontSize");
        }


        //�ֺ�(Enterʱ����)
        private void cboFontSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CellOperate("FontSize");
            }
        }


        //����
        private void btnBold_Click(object sender, EventArgs e)
        {
            this.CellOperate("Bold");
        }

        //б��
        private void btnItalic_Click(object sender, EventArgs e)
        {
            this.CellOperate("Italic");
        }

        //�»���
        private void btnUnderLine_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnderLine");
        }

        //����ɫ
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            this.CellOperate("BackColor");
        }

        //ǰ��ɫ
        private void btnForeColor_Click(object sender, EventArgs e)
        {
            this.CellOperate("ForeColor");
        }


        //������ʾ
        private void btnWordWrap_Click(object sender, EventArgs e)
        {
            this.CellOperate("WordWrap");
        }

        //����
        private void btnAlignLeft_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignLeft");

        }

        //����
        private void btnAlignCenter_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignCenter");
        }

        //����
        private void btnAlignRight_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignRight");
        }


        //����
        private void btnAlignTop_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignTop");
        }

        //��ֱ����
        private void btnAlignMiddle_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignMiddle");
        }

        //����
        private void btnAlignBottom_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignBottom");
        }


        //��������
        private void btnDrawBorder_ButtonClick(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder1");
        }


        //��������
        private void menuDrawBorder1_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder1");
        }

        //������
        private void menuDrawBorder2_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder2");
        }

        //����Ԫ������
        private void menuDrawBorder3_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder3");
        }

        //����Ԫ������
        private void menuDrawBorder4_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder4");
        }


        //����Ԫ������
        private void menuDrawBorder5_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder5");
        }

        //����Ԫ������
        private void menuDrawBorder6_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder6");
        }

        //����б��
        private void menuDrawBorder7_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder7");
        }

        //����б��
        private void menuDrawBorder8_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder8");
        }

        //Ĩ������
        private void btnEraseBorder_ButtonClick(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder1");
        }

        //Ĩ������
        private void menuEraseBorder1_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder1");
        }

        //Ĩ����
        private void menuEraseBorder2_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder2");
        }

        //Ĩ��Ԫ������
        private void menuEraseBorder3_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder3");
        }

        //Ĩ��Ԫ������
        private void menuEraseBorder4_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder4");
        }

        //Ĩ��Ԫ������
        private void menuEraseBorder5_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder5");
        }

        //Ĩ��Ԫ������
        private void menuEraseBorder6_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder6");
        }


        //Ĩ��б��
        private void menuEraseBorder7_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder7");
        }

        //Ĩ��б��
        private void menuEraseBorder8_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder8");
        }

        //�����������
        private void btnSymbol_Click(object sender, EventArgs e)
        {
            this.CellOperate("Symbol");
            //Cell1.InsertSpecialCharDlg();
        }

        //����ͼƬ
        private void btnInsertPic_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertPic");
        }

        //����
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.CellOperate("Save");
        }

        //��ӡ
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.CellOperate("Print");
        }


        //��ӡԤ��
        private void btnPrintpreview_Click(object sender, EventArgs e)
        {
            this.CellOperate("Printpreview");
        }

        //����
        private void btnCut_Click(object sender, EventArgs e)
        {
            this.CellOperate("Cut");
        }

        //����
        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.CellOperate("Copy");
        }

        //ճ��
        private void btnPaste_Click(object sender, EventArgs e)
        {
            this.CellOperate("Paste");
        }

        //����
        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Undo");
        }

        //����
        private void btnRedo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Redo");
        }

        //��ʾ/�����б�
        private void btnRow_Click(object sender, EventArgs e)
        {
            this.CellOperate("RowHideShow");
        }

        //��ʾ/�����б�
        private void btnCol_Click(object sender, EventArgs e)
        {
            this.CellOperate("ColHideShow");
        }

        //��ʾ/����������
        private void btnGridline_Click(object sender, EventArgs e)
        {
            this.CellOperate("Gridline");
        }

        //��ϵ�Ԫ��
        private void btnMergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("MergeCell");
        }

        //ȡ����ϵ�Ԫ
        private void btnUnmergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnmergeCell");
        }


        //��ʾ����
        private void cboZoom_DropDownClosed(object sender, EventArgs e)
        {
            if (cboZoom.SelectedItem == null) return;
            cboZoom.Text = cboZoom.SelectedItem.ToString();
            this.CellOperate("Zoom");
        }

        //��ʾ����(Enterʱ����)
        private void cboZoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CellOperate("Zoom");
            }
        }



        //������
        private void btnInsertCol_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertCol");
        }

        //ɾ����
        private void btnDeleteCol_Click(object sender, EventArgs e)
        {
            this.CellOperate("DeleteCol");
        }

        //������
        private void btnInsertRow_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertRow");
        }

        //ɾ����
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            this.CellOperate("DeleteRow");
        }

        //������
        private void btnRndFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RndFill");
        }

        //�������
        private void btnSumH_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumH");
        }

        //�������
        private void btnSumV_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumV");
        }

        //˫�����
        private void btnSum_Click(object sender, EventArgs e)
        {
            this.CellOperate("Sum");
        }

        //����ֻ��
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


        #region ��������¼���������
        //�Ƴ�����
        private void btnRemove_Click(object sender, EventArgs e)
        {
            //�ж�
            if (txtPos.Text == "") return;

            //��ȡ��Ԫ��λ��
            int sheet = 0, row = 0, col = 0;
            Cell1.LabelToCell(txtPos.Text, ref col, ref row);
            sheet = Cell1.GetCurSheet();


            //�Ƴ�����
            Cell1.SetCellNote(col, row, sheet, "");

            //�Ƴ�ע��
            Cell1.SetCellTip(col, row, sheet, "");

            txtVars.Text = "";
            
            //�ػ�
            Cell1.ReDraw();
        }

        //���±���
        private void btnUpdateVar_Click(object sender, EventArgs e)
        {
            //�ж�
            if (txtPos.Text == "" || cboVars.SelectedIndex == -1) return;

            //��ȡ��Ԫ��λ��
            int sheet = 0, row = 0, col = 0;
            Cell1.LabelToCell(txtPos.Text, ref col, ref row);
            sheet = Cell1.GetCurSheet();

            Cell1.SetCellNote(col, row, sheet, cboVars.SelectedValue.ToString());

            //����ע��
            Cell1.SetCellTip(col, row, sheet, "�б���");

            //�ػ�
            Cell1.ReDraw();
        }

        //���±���2
        private void btnUpdateVar2_Click(object sender, EventArgs e)
        {
            //�ж�
            if (txtPos.Text == "" || txtVars.Text.Trim() == "") return;

            //��ȡ��Ԫ��λ��
            int sheet = 0, row = 0, col = 0;
            Cell1.LabelToCell(txtPos.Text, ref col, ref row);
            sheet = Cell1.GetCurSheet();

            Cell1.SetCellNote(col, row, sheet, txtVars.Text.Trim());

            //����ע��
            Cell1.SetCellTip(col, row, sheet, "�б���");

            //�ػ�
            Cell1.ReDraw();
        }


        /// <summary>
        /// ����ע�ͣ������û��õ�Ԫ���б�����
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
                            Cell1.SetCellTip(col, row, sheet, "�б���");
                        }
                    }
                }
            }

            Cell1.ReDraw();
        }

        /// <summary>
        /// �Ƴ�ע��
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

        //�Ƴ�����
        private void tsmiRemove_Click(object sender, EventArgs e)
        {
            btnRemove.PerformClick();
        }


        //�Ƴ����б���
        private void btnRemoveAllVars_Click(object sender, EventArgs e)
        {
            if (Functions.ShowQuestion("ȷ��Ҫ�Ƴ����б�����") != DialogResult.Yes) return;

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
        /// �Թ�ʽ�������н���
        /// </summary>
        /// <param name="expression">���ʽ</param>
        /// <param name="sheet">ҳ������������ʱ�õ�</param>
        /// <param name="compare">��Ҫ�Ƚϵ�ֵ</param>
        /// <returns>������������ture</returns>
        /// <returns>�Ƿ�</returns>
        private bool parse(string expression, int sheet, double compare, bool debugMode)
        {
            string str = expression.Replace("\r", "").Replace("\n", "").Replace(" ", "").ToLower();
            str = str.Replace("run{", "");
            str = str.Replace("}", "");
            str = str.Replace("break;", "#");

            //���Ϊ��
            if (str == "") return false;

            //���ı��ʽ
            string newExpression = "";
            int col = 0;
            int row = 0;

            //��������
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



            //�������ʽ���н���
            string strMin = "";  //"��С"���ʽ
            string strMax = "";  //"���"���ʽ
            string strX = "";    //"����"���ʽ
            string strX1 = "";   //strX�ĺ�벿�֣�����Ԫ��
            string strXVal = ""; //��Ԫ���ֵ
            string strOther = ""; //��������

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

        //�Ƴ����й�ʽ
        private void btnRemoveAllExpression_Click(object sender, EventArgs e)
        {
            if (Functions.ShowQuestion("ȷ��Ҫ�Ƴ����й�ʽ��") != DialogResult.Yes) return;

            //������й�ʽ
            for (int sheet = 0; sheet < Cell1.GetTotalSheets(); sheet++)
            {
                Cell1.ClearArea(1, 1, Cell1.GetCols(sheet), Cell1.GetRows(sheet), sheet, 2);
            }

            Cell1.ReDraw();
        }



        

        

        

        

        


    }
}