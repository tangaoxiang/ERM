using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace ERM.UI
{
    public partial class frmOutInError : Form
    {
        private frmMain _parentForm;
        private frmFileAdd _parentFormAdd;
        private bool InOunt;
        private int RegistInOut;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="dt"></param>
        /// <param name="_inOunt">导入为true导出为false</param>
        public frmOutInError(Form frm, DataTable dt ,bool _inOunt)
        {
            InitializeComponent();
            this._parentForm = (frmMain)frm;
            dt.Columns["xh"].ColumnName = "序号";
            dt.Columns["nodeid"].ColumnName = "节点号";
            dt.Columns["title"].ColumnName = "表格名称";
            dt.Columns["errorinfo"].ColumnName = "错误描述";
            dt.Columns["imageindex"].ColumnName = "节点类别";
            dt.Columns["parentid"].ColumnName = "父节点";
            dt.AcceptChanges();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            InOunt = _inOunt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="dt"></param>
        /// <param name="_inOunt">导入为0导出为1</param>
        public frmOutInError(Form frm, DataTable dt, int _inOunt)
        {
            InitializeComponent();
            this._parentFormAdd = (frmFileAdd)frm;
            dt.Columns["title"].ColumnName = "表格名称";
            dt.Columns["errorinfo"].ColumnName = "错误描述";
            dt.AcceptChanges();
            dataGridView1.DataSource = dt;
            RegistInOut = _inOunt;
        }
        private void btnSearchCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int row = e.RowIndex;
        //    int col = e.ColumnIndex;
        //    if (row !=-1 && col != -1)
        //    {
        //        ;
        //        string id = "";
        //        if (dataGridView1.Rows[row].Cells[4].Value.ToString() == "3")
        //            id = dataGridView1.Rows[row].Cells[5].Value.ToString();
        //        else
        //            id = dataGridView1.Rows[row].Cells[1].Value.ToString();
        //        bool refresh = _parentForm.IsUse;
        //        if (InOunt)
        //        {
        //            if (refresh)
        //            {
        //                _parentForm.IsUse = false;
        //            }
        //        }
        //        _parentForm.Focus();
        //        _parentForm.treeFactory.SelectNodeO(_parentForm.treeView1, id);
        //    }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "c:\\";
            op.Title = "保存错误信息";
            op.Filter = "文本文件|*.txt";
            DialogResult drs = op.ShowDialog();
            if (drs == DialogResult.OK)
            {
                System.IO.StreamWriter sr = new System.IO.StreamWriter(op.FileName, false);
                try
                {
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sr.Write(dt.Columns[i].Caption + "    ");
                    }
                    sr.Write(Environment.NewLine);
                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sr.Write(dr[i].ToString() + "    ");
                        }
                        sr.Write(Environment.NewLine);
                    }
                    Functions.ShowInfo("保存成功！");
                }
                catch
                {
                    Functions.ShowWarning("保存失败！");
                }
                finally
                {
                    sr.Close();
                }
            }
        }
    }
}
