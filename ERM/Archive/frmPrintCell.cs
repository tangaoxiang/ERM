using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using ERM.Common;
using TX.Framework.WindowUI.Forms;
using ERM.UI.Common;

namespace ERM.UI
{
    public partial class frmPrintCell : ERM.UI.Controls.Skin_DevEX
    {
        private const int SC_CLOSE = 0xF060;
        private const int MF_ENABLED = 0x00000000;
        private const int MF_GRAYED = 0x00000001;
        private const int MF_DISABLED = 0x00000002;

        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, int bRevert);
        [DllImport("User32.dll")]
        public static extern bool EnableMenuItem(IntPtr hMenu, int uIDEnableItem, int uEnable);
        delPrintPDF del;
        bool setDefaultPrinter;
        TreeNode tn = null;
        public frmPrintCell(DataView dv, delPrintPDF _del, TreeNode node)
            : this(dv, _del, false)
        {
            tn = node;
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="dv">Ҫ��ӡ�ľ���Ŀ¼</param>
        public frmPrintCell(DataView dv, delPrintPDF _del, bool _setDefaultPrinter)
        {
            InitializeComponent();
            this.setDefaultPrinter = _setDefaultPrinter;
            lstFiles.DataSource = dv;
            lstFiles.DisplayMember = "title";
            lstFiles.ValueMember = "filed";
            del = _del;
        }
        private void frmPrintCell_Load(object sender, EventArgs e)
        {
        }
        private void lstFiles_Click(object sender, EventArgs e)
        {
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lstFiles.Items.Count; i++)
            {
                lstFiles.SetItemChecked(i, chkAll.Checked);
            }
        }
        private bool CheckFileExist(DataTable _dt)
        {
            List<int> delrow = new List<int>();
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (!System.IO.File.Exists(_dt.Rows[i]["filed"].ToString()))
                {
                    if (TXMessageBoxExtensions.Question("�ڣ�" + (i + 1) + "�� \n " + _dt.Rows[i]["title"].ToString() + " \n ��PDF���Ӽ������ڣ�Ҫ���Բ�������") != DialogResult.OK)
                    {
                        return false;
                    }
                    else
                    {
                        delrow.Add(i);
                    }
                }
            }
            for (int j = delrow.Count - 1; j >= 0; j--)
            {
                _dt.Rows[delrow[j]].Delete();
            }
            return true;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstFiles.CheckedItems.Count == 0) return;
                DataTable dt = ((DataView)lstFiles.DataSource).ToTable();
                for (int j = lstFiles.Items.Count - 1; j >= 0; j--)
                {
                    if (!lstFiles.GetItemChecked(j))
                    {
                        dt.Rows[j].Delete();
                    }
                }
                if (!CheckFileExist(dt))
                    return;
                if (dt.Rows.Count == 0)
                {
                    TXMessageBoxExtensions.Info("û��Ҫ��ӡ���ļ���");
                    return;
                }
                string PrintMode = "2";
                if (PrintMode.Equals("2") && tn != null)
                {
                    string[] printFileList = new string[dt.Rows.Count];
                    string tempFolder =
                                System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "erm_print");
                    if (!System.IO.Directory.Exists(tempFolder))
                    {
                        MyCommon.DeleteAndCreateEmptyDirectory(tempFolder, true);
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*
                         * * ��������ʱĿ¼���д�ӡ����Ϊ�����´�ӡ��ɾ������Ӱ��ϵͳ�鿴
                         * * */
                        string tempFile = System.IO.Path.Combine(tempFolder, dt.Rows[i]["title"].ToString() + ".pdf");
                        System.IO.File.Copy(dt.Rows[i]["filed"].ToString(), tempFile, true);
                        printFileList[i] = tempFile;
                    }

                    using (ConvertCell2PDF cl_print = new ConvertCell2PDF())
                    {
                        MyCommon.DeleteAndCreateEmptyDirectory(Application.StartupPath + @"\Reports\printPdf_temp", true);
                        cl_print.MergePDF(printFileList, Application.StartupPath + @"\Reports\printPdf_temp\printFile.pdf");
                        frmReport frmReports = new frmReport("printFile.pdf");
                        frmReports.ShowDialog();
                        //cl_print.BathPrintPDF(printFileList);
                    }
                    //switch (tn.ImageIndex)
                    //{
                    //    case 0://����
                    //        string[] printFileList = new string[dt.Rows.Count];
                    //        for (int i = 0; i < dt.Rows.Count; i++)
                    //        {
                    //            printFileList[i] = dt.Rows[i]["filed"].ToString();
                    //        }
                    //        break;
                    //    case 1://����
                    //        //OperatorFile(dt, printername, ref hMenu, strDefault, dtNew, tn, StartPageNo);
                    //        break;
                    //    case 2://�ļ�
                    //        //hMenu = OperatorTem(dt, printername, hMenu, strDefault, dtNew, StartPageNo);
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
                else
                {
                    frmPrinterList frm = new frmPrinterList();
                    DialogResult drs = frm.ShowDialog();
                    if (drs != DialogResult.OK)
                        return;
                    string printername = frm.GetSelected;
                    btnPrint.Enabled = false;
                    btnCancel.Enabled = false;
                    lstFiles.Enabled = false;
                    chkAll.Enabled = false;
                    IntPtr hMenu = GetSystemMenu(this.Handle, 0);
                    EnableMenuItem(hMenu, SC_CLOSE, MF_DISABLED | MF_GRAYED);
                    string strDefault = "";
                    if (setDefaultPrinter)
                    {
                        strDefault = PrinterOperate.GetDefaultPrinterName();
                        if (string.Compare(strDefault, printername, true) != 0)
                        {
                            PrinterOperate.SetPrinter(printername);
                        }
                    }

                    hMenu = PrintFile(dt, printername, hMenu, strDefault);
                    if (setDefaultPrinter)//�����
                    {
                        if (string.Compare(strDefault, printername, true) != 0)
                        {
                            PrinterOperate.SetPrinter(strDefault);
                        }
                    }
                    btnCancel.Enabled = true;
                    hMenu = GetSystemMenu(this.Handle, 0);
                    EnableMenuItem(hMenu, SC_CLOSE, MF_ENABLED);
                    if (TXMessageBoxExtensions.Question("��ӡ�����Ѿ�ȫ�����͵���ӡ�������ڿ��Թرմ����ˣ������ĵȴ���ӡ���Ĵ���\n �Ƿ������ӡ��") != DialogResult.OK)
                        this.Close();
                    else
                    {
                        btnPrint.Enabled = true;
                        btnCancel.Enabled = true;
                        lstFiles.Enabled = true;
                        chkAll.Enabled = true;
                    }
                }
                btnPrint.Enabled = true;
                btnCancel.Enabled = true;
                lstFiles.Enabled = true;
                chkAll.Enabled = true;
            }
            catch (Exception ex)
            {
                btnPrint.Enabled = true;
                btnCancel.Enabled = true;
            }
        }
        /// <summary>
        /// ȡ��ʼҳ��
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int GetStartPageNo(DataTable dt, TreeNode node)
        {
            CBLL.FinalArchive cbll = new ERM.CBLL.FinalArchive(); ;
            int count = 0;
            string Sqlwhere = null;
            if (node.ImageIndex == 1)
            {
                Sqlwhere = GetSql(dt, node.Tag.ToString());
                count = cbll.GetgFinal_archivePDFByCheckStartPageNo(Sqlwhere, Globals.ProjectNO, node.Tag.ToString());
            }
            if (node.ImageIndex == 2)
            {
                Sqlwhere = GetSql(dt, node.Parent.Tag.ToString());
                count = cbll.GetgFinal_archivePDFByCheckStartPageNo(Sqlwhere, Globals.ProjectNO, node.Parent.Tag.ToString());
            }
            return count;
        }

        /// <summary>
        /// ������table����
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private DataTable CreateNewTable(string path)
        {
            DataTable dtNew = new DataTable();
            dtNew.Columns.Add("title", typeof(string));
            dtNew.Columns.Add("filed", typeof(string));
            dtNew.Rows.Add(new object[] { "", path });
            return dtNew;
        }
        ///// <summary>
        ///// �ļ��в���
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <param name="printername"></param>
        ///// <param name="hMenu"></param>
        ///// <param name="strDefault"></param>
        ///// <param name="processor"></param>
        ///// <param name="dtNew"></param>
        //private void OperatorFile(DataTable dt, string printername, ref IntPtr hMenu, string strDefault, PDFProcessor processor, DataTable dtNew, TreeNode tn, int StartPageNo)
        //{
        //    dtNew = GetFileTabelByCheck(dt, tn);
        //    if (dtNew != null)
        //    {
        //        MyCommon.DeleteAndCreateEmptyDirectory(Globals.PDFTemp + "\\", false);
        //        MyCommon.DeleteAndCreateEmptyDirectory(Globals.PDFTemp + "\\", true);
        //        string mpath = MergerFileToTemp(dtNew, processor, tn.Tag.ToString(), "1");
        //        DataTable dtMNew = CreateNewTable(mpath);
        //        AddText(dtMNew.Rows[0]["filed"].ToString(), processor, dtMNew.Rows[0]["filed"].ToString(), StartPageNo);
        //        hMenu = PrintFile(dtMNew, printername, hMenu, strDefault);
        //    }
        //}
        ///// <summary>
        ///// ģ���ӡ����
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <param name="printername"></param>
        ///// <param name="hMenu"></param>
        ///// <param name="strDefault"></param>
        ///// <param name="processor"></param>
        ///// <param name="dtNew"></param>
        ///// <returns></returns>
        //private IntPtr OperatorTem(DataTable dt, string printername, IntPtr hMenu, string strDefault, PDFProcessor processor, DataTable dtNew, int StartPageNo)
        //{
        //    dtNew.Rows.Add(new object[] { "", addPageCount(dt.Rows[0]["filed"].ToString(), processor, StartPageNo) });
        //    //dtNew.Rows.Add(new object[] { "", dt.Rows[0]["filed"].ToString() });
        //    hMenu = PrintFile(dtNew, printername, hMenu, strDefault);
        //    return hMenu;
        //}
        ///// <summary>
        ///// �ϲ�Ҫ�����ļ�����ʱĿ¼
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //private string MergerFileToTemp(DataTable dt, PDFProcessor processor, string id)
        //{
        //    string[] filename = new string[dt.Rows.Count];
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        filename[i] = Globals.MPDFPath + "\\" + dt.Rows[i]["filed"].ToString();
        //    }
        //    processor.MergeBatch(filename, Globals.PDFTemp + "\\" + id + ".pdf");
        //    return Globals.PDFTemp + "\\" + id + ".pdf";
        //}
        ///// <summary>
        ///// �ϲ�Ҫ�����ļ�����ʱĿ¼ ���ݿ��ѯ����
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //private string MergerFileToTemp(DataTable dt, PDFProcessor processor, string id, string flg)
        //{
        //    string[] filename = new string[dt.Rows.Count];
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        filename[i] = Globals.ProjectPath + "\\" + dt.Rows[i]["filepath"].ToString();
        //    }
        //    processor.MergeBatch(filename, Globals.PDFTemp + "\\" + id + ".pdf");
        //    return Globals.PDFTemp + "\\" + id + ".pdf";
        //}
        ///// <summary>
        ///// ���ҳ��
        ///// </summary>
        ///// <param name="filepath">�ļ�·��</param>
        ///// <param name="processor"></param>
        ///// <returns>ת������ļ�·��</returns>
        //private string addPageCount(string filepath, PDFProcessor processor, int StartPageNo)
        //{
        //    if (System.IO.File.Exists(filepath))
        //    {
        //        filepath = CopyFileToTemp(filepath, processor, StartPageNo);
        //    }
        //    return filepath;
        //}
        ///// <summary>
        ///// �����ļ�����ʱĿ¼
        ///// </summary>
        ///// <param name="filepath">�ļ�·��</param>
        ///// <param name="processor"></param>
        ///// <returns>���Ƶ���ʱĿ¼���ļ�·��</returns>
        //private string CopyFileToTemp(string filepath, PDFProcessor processor, int StartPageNo)
        //{
        //    MyCommon.DeleteAndCreateEmptyDirectory(Globals.PDFTemp + "\\", false);
        //    MyCommon.DeleteAndCreateEmptyDirectory(Globals.PDFTemp + "\\", true);
        //    if (System.IO.File.Exists(filepath))
        //    {
        //        string OutFileName = Globals.PDFTemp + "\\" + filepath.Substring(filepath.LastIndexOf("\\") + 1);
        //        System.IO.File.Copy(filepath, OutFileName, true);
        //        return AddText(filepath, processor, OutFileName, StartPageNo);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        ///// <summary>
        ///// ���PDF�ı�
        ///// </summary>
        ///// <param name="filepath"></param>
        ///// <param name="processor"></param>
        ///// <param name="OutFileName"></param>
        ///// <param name="StartPageNo">��ʼҳ��</param>
        ///// <returns></returns>
        //private string AddText(string filepath, PDFProcessor processor, string OutFileName, int StartPageNo)
        //{
        //    if (Globals.IsPageNo.Equals("1"))
        //    {
        //        if (!System.IO.Directory.Exists(Globals.PDFTemp + "\\printTemp" + "\\"))
        //            MyCommon.DeleteAndCreateEmptyDirectory(Globals.PDFTemp + "\\printTemp" + "\\");

        //        string tempPDF = Globals.PDFTemp + "\\printTemp" + "\\temp.pdf";
        //        System.IO.File.Copy(filepath, tempPDF, true);

        //        int count = processor.GetPageCount(filepath, "");
        //        uint cor = (uint)System.Drawing.ColorTranslator.ToOle(Color.FromArgb(0, 0, 0));
        //        double pageW = 0;
        //        double pageH = 0;
        //        if (StartPageNo == 0)
        //        {
        //            for (int i = 0; i < count; i++)
        //            {
        //                processor.GetPageSize(OutFileName, i, out pageW, out pageH);
        //                processor.AddPDFText(OutFileName, tempPDF, i, i, pageW - Globals.PageNoLocationX, pageH - Globals.PageNoLocationY, "", Globals.PageNoLocationSize, prcDefaultFont.PRC_DEFFONT_HELVETICA, cor);
        //            }
        //        }
        //        else
        //        {
        //            for (int i = 0; i < count; i++)
        //            {
        //                processor.GetPageSize(OutFileName, i, out pageW, out pageH);
        //                processor.AddPDFText(OutFileName, tempPDF, i, i, pageW - Globals.PageNoLocationX, pageH - Globals.PageNoLocationY, "", Globals.PageNoLocationSize, prcDefaultFont.PRC_DEFFONT_HELVETICA, cor);
        //            }
        //        }
        //    }
        //    return OutFileName;
        //}
        /// <summary>
        /// ������ѡ�ļ��к�ģ����������ļ��б�
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable GetFileTabelByCheck(DataTable dt, TreeNode node)
        {
            string Sqlwhere = GetSql(dt, node.Tag.ToString());
            CBLL.FinalArchive cbll = new ERM.CBLL.FinalArchive();
            DataSet dd = cbll.GetgFinal_archivePDFByCheck(Sqlwhere, Globals.ProjectNO);
            if (dd != null && dd.Tables[0].Rows.Count > 0)
            {
                return dd.Tables[0];
            }
            return null;
        }
        /// <summary>
        /// ���ݿ��ѯ�����ַ���
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetSql(DataTable dt, string ArchiveID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("and wjtm in (");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("'" + dt.Rows[i]["title"] + "',");
            }
            if (sb.ToString().EndsWith(","))
            {
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append(")");
            sb.Append(" and ");
            sb.Append("ArchiveID='" + ArchiveID + "'");
            return sb.ToString();
        }
        /// <summary>
        /// ִ�д�ӡ
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="printername"></param>
        /// <param name="hMenu"></param>
        /// <param name="strDefault"></param>
        /// <returns></returns>
        private IntPtr PrintFile(DataTable dt, string printername, IntPtr hMenu, string strDefault)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!del(dt.Rows[i]["filed"].ToString(), printername))
                {
                    if (TXMessageBoxExtensions.Question(dt.Rows[i]["title"].ToString() + "��ӡʧ�ܣ�Ҫ������") != DialogResult.OK)
                    {
                        btnCancel.Enabled = true;
                        hMenu = GetSystemMenu(this.Handle, 0);
                        EnableMenuItem(hMenu, SC_CLOSE, MF_ENABLED);
                        if (setDefaultPrinter)//�����
                        {
                            if (string.Compare(strDefault, printername, true) != 0)
                            {
                                PrinterOperate.SetPrinter(strDefault);
                            }
                        }
                        break;
                    }
                }
            }
            return hMenu;
        }

        /// <summary>
        /// ���к�
        /// </summary>
        /// <returns></returns>
        private string GetLicenseKey()
        {
            return Globals.LicenseKey;
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
