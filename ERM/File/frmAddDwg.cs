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
        /// 加载上一次操作的数据
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
        /// 导入操作
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
        /// 绑定数据
        /// </summary>
        private void DataBind()
        {
            this.dataGridView1.DataSource = dt;
            if (!this.dataGridView1.Columns.Contains("add"))
            {
                DataGridViewButtonColumn con = new DataGridViewButtonColumn();
                con.Text = "添加";
                con.Name = "add";
                con.HeaderText = "添加PDF文件";
                con.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(con);
            }
            this.SetGridStyle();
        }
        /// <summary>
        /// 创建datatable
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
        /// 添加行
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
        /// 获取选中的DWG文件列表
        /// </summary>
        /// <returns></returns>
        private string[] DWGInput()
        { 
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "C:\\Documents and Settings";
            openFileDialog1.Filter = "DWG文件 (*.dwg)|*.dwg";
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
        /// 保存
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
                    MessageBox.Show("数据不完整,请检查DWG与PDF的匹配情况！");
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
            openFileDialog2.Filter = "PDF文件 (*.pdf)|*.pdf";
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
        /// 设置DATAGRIDVIEW样式
        /// </summary>
        private void SetGridStyle()
        {
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.Columns["DwgName"].HeaderText = "DWG文件名称";
            this.dataGridView1.Columns["DwgPath"].HeaderText = "DWG文件路径";
            this.dataGridView1.Columns["PdfName"].HeaderText = "PDF文件名称";
            this.dataGridView1.Columns["PdfPath"].HeaderText = "PDF文件路径";
            this.dataGridView1.Columns["DwgName"].Width = 150;
            this.dataGridView1.Columns["DwgPath"].Width = 300;
            this.dataGridView1.Columns["PdfName"].Width = 150;
            this.dataGridView1.Columns["PdfPath"].Width = 300;
        }
        /// <summary>
        /// 关闭窗体
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
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsClose_Click(object sender, EventArgs e)
        {
            FromClose();
        }
        /// <summary>
        /// 导入字库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsInputFont_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog3 = new OpenFileDialog();
            openFileDialog3.InitialDirectory = "C:\\Documents and Settings";
            openFileDialog3.Filter = "DWG字库文件 (*.shx)|*.shx";
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
