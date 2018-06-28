using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using System.IO;
namespace ERM.UI
{
    public partial class frmAddDwg : Form
    {
        string MovedCellPath = Globals.ODOCPath + "\\";
        string PDFPath = Globals.SPDFPath + "\\";
        string PDFTemp = Globals.PDFTemp + "\\";
        string DWGXML = Globals.DWGXML + "\\";
        string DWGFont = Globals.DWGFont + "\\";
        string[] FileNames = null;
        TreeNodeEx NewNode = null;
        DataTable dt = new DataTable("DwgFile");
        Form _parentForm;
        public frmAddDwg(TreeNodeEx node,Form par)
        {
            InitializeComponent();
            NewNode = node;
            _parentForm = par;
            CreateTable();
            LoadData();
        }
        private void tsInput_Click(object sender, EventArgs e)
        {
            Input();
        }
        /// <summary>
        /// ������һ�β���������
        /// </summary>
        private void LoadData()
        {
            if (System.IO.File.Exists(DWGXML + "dwg.xml"))
            {
                dt.ReadXml(DWGXML + "dwg.xml");
                DataBind();
            }
        }
        /// <summary>
        /// �������
        /// </summary>
        private void Input()
        { 
            FileNames = DWGInput();
            if (FileNames != null)
            {
                WriteTable(FileNames);
                DataBind();
            }
        }
        /// <summary>
        /// ������
        /// </summary>
        private void DataBind()
        {
            this.dataGridView1.DataSource = dt;
            if (!this.dataGridView1.Columns.Contains("add"))
            {
                DataGridViewButtonColumn con = new DataGridViewButtonColumn();
                con.Text = "���";
                con.Name = "add";
                con.HeaderText = "���PDF�ļ�";
                con.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(con);
            }
            this.SetGridStyle();
        }
        /// <summary>
        /// ����datatable
        /// </summary>
        /// <returns></returns>
        private void CreateTable()
        {
            DataColumn dc;
            dc = new DataColumn("DwgName");
            dt.Columns.Add(dc);
            dc = new DataColumn("DwgPath");
            dt.Columns.Add(dc);
            dc = new DataColumn("PdfName");
            dt.Columns.Add(dc);
            dc = new DataColumn("PdfPath");
            dt.Columns.Add(dc);
        }
        /// <summary>
        /// �����
        /// </summary>
        /// <param name="FileNames"></param>
        private void WriteTable(string[] FileNames)
        {
            string strDWGName = null;
            for (int i = 0; i < FileNames.Length; i++)
            {
                strDWGName = FileNames[i].Substring(FileNames[i].LastIndexOf("\\")+1);
                strDWGName = strDWGName.Substring(0,strDWGName.LastIndexOf("."));
                string[] row1 ={ strDWGName,FileNames[i] };
                dt.Rows.Add(row1);
            }
        }
        private void CopyDWG(string[] FileNames)
        {
            for (int i = 0; i < FileNames.Length; i++)
            {
                if (System.IO.File.Exists(FileNames[i]))
                {
                    System.IO.File.Copy(FileNames[i], MovedCellPath + FileNames[i]);
                }
            }
        }
        /// <summary>
        /// ��ȡѡ�е�DWG�ļ��б�
        /// </summary>
        /// <returns></returns>
        private string[] DWGInput()
        { 
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "C:\\Documents and Settings";
            openFileDialog1.Filter = "DWG�ļ� (*.dwg)|*.dwg";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileNames;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsSave_Click(object sender, EventArgs e)
        {
            string[] DwgFileNames = new string[dt.Rows.Count];
            string[] PdfFileNames = new string[dt.Rows.Count];
            for(int i =0;i<dt.Rows.Count;i++)
            {
                if((!String.IsNullOrEmpty(dt.Rows[i]["DwgPath"].ToString())) && (!String.IsNullOrEmpty(dt.Rows[i]["PdfPath"].ToString())))
                {
                    DwgFileNames[i] = dt.Rows[i]["DwgPath"].ToString();
                    PdfFileNames[i] = dt.Rows[i]["PdfPath"].ToString();
                }
                else
                {
                    MessageBox.Show("���ݲ�����,����DWG��PDF��ƥ�������");
                    return;
                }
            }
            frmFileAdd frm = new frmFileAdd(_parentForm);
            for (int i = 0; i < DwgFileNames.Length; i++)
            {
                frm.AddExternalFile(DwgFileNames[i],NewNode,null,"DWG",PdfFileNames[i]);
            }
            if (System.IO.File.Exists(DWGXML + "dwg.xml"))
            {
                System.IO.File.Delete(DWGXML + "dwg.xml");
            }
            this.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.InitialDirectory = "C:\\Documents and Settings";
            openFileDialog2.Filter = "PDF�ļ� (*.pdf)|*.pdf";
            openFileDialog2.RestoreDirectory = true;
            string strPDFName = null;
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                strPDFName = openFileDialog2.FileName.Substring(openFileDialog2.FileName.LastIndexOf("\\") + 1);
                strPDFName = strPDFName.Substring(0, strPDFName.LastIndexOf("."));
                dt.Rows[e.RowIndex]["PdfName"] = strPDFName;
                dt.Rows[e.RowIndex]["PdfPath"] = openFileDialog2.FileName;
                dt.AcceptChanges();
                this.dataGridView1.DataSource = dt;
            }
        }
        /// <summary>
        /// ����DATAGRIDVIEW��ʽ
        /// </summary>
        private void SetGridStyle()
        {
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.Columns["DwgName"].HeaderText = "DWG�ļ�����";
            this.dataGridView1.Columns["DwgPath"].HeaderText = "DWG�ļ�·��";
            this.dataGridView1.Columns["PdfName"].HeaderText = "PDF�ļ�����";
            this.dataGridView1.Columns["PdfPath"].HeaderText = "PDF�ļ�·��";
            this.dataGridView1.Columns["DwgName"].Width = 150;
            this.dataGridView1.Columns["DwgPath"].Width = 300;
            this.dataGridView1.Columns["PdfName"].Width = 150;
            this.dataGridView1.Columns["PdfPath"].Width = 300;
        }
        /// <summary>
        /// �رմ���
        /// </summary>
        private void FromClose()
        {
            try
            {
                if (System.IO.File.Exists(DWGXML + "dwg.xml"))
                {
                    System.IO.File.Delete(DWGXML + "dwg.xml");
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    FileStream fs1 = System.IO.File.Create(DWGXML + "dwg.xml");
                    fs1.Close();
                    dt.WriteXml(DWGXML + "dwg.xml");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            this.Close();
        }
        /// <summary>
        /// �رմ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsClose_Click(object sender, EventArgs e)
        {
            FromClose();
        }
        /// <summary>
        /// �����ֿ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsInputFont_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog3 = new OpenFileDialog();
            openFileDialog3.InitialDirectory = "C:\\Documents and Settings";
            openFileDialog3.Filter = "DWG�ֿ��ļ� (*.shx)|*.shx";
            openFileDialog3.RestoreDirectory = true;
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                if (!System.IO.Directory.Exists(DWGFont))
                {
                    System.IO.Directory.CreateDirectory(DWGFont);
                }
                string FileName = openFileDialog3.FileName.Substring(openFileDialog3.FileName.LastIndexOf('\\')+1);
                System.IO.File.Copy(openFileDialog3.FileName, DWGFont + FileName);
            }
        }
    }
}
