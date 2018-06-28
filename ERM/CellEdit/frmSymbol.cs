using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace ERM.UI
{
    public partial class frmSymbol : ERM.UI.Controls.Skin_DevEX
    {
        public frmSymbol()
        {
            InitializeComponent();
            InitMe();
        }
        private void InitMe()
        {
            string[] str1 = { "��", "��", "��", "��", "��", "��", "��", "��", "�U", "��", "�E", "��", "�F", "��", "��", "��", "��", "��", "�o", "�p", "�q", "��", "�r", "�s", "�t", "�u", "��", "�C", "��", "��", "��", "��", "�n", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "�v", "�w", "�x", "�y", "�z", "�{", "��", "��", "��", "��", "��", "��", "�A", "�@" };
            DrawSymbol(dg1, str1);
            string[] str2 = { "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "�H", "��", "��", "��", "��", "�T", "�L", "�M", "�N", "�Q", "�O", "�J", "�K", "�P", "��", "��", "��", "��" };
            DrawSymbol(dg2, str2);
            string[] str3 = { "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��" };
            DrawSymbol(dg3, str3);
            string[] str4 = { "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "�I", "�G", "��", "��", "��", "�h", "�i", "�l", "�m", "�j", "�k", "�|", "�}", "�~", "��", "��", "��", "��", "��", "��", "��", "��", "�I", "�J", "�L", "�K", "��", "�O", "��", "��", "�M", "��" };
            DrawSymbol(dg4, str4);
            string[] str5 = { "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "�Q", "�R", "�P", "��", "��", "��", "��", "��", "��", "��", "�N", "�S", "�S", "�R" };
            DrawSymbol(dg5, str5);
            string[] str6 = { "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��" };
            DrawSymbol(dg6, str6);
            string[] str7 = { "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��" };
            DrawSymbol(dg7, str7);
            string[] str8 = { "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��" };
            DrawSymbol(dg8, str8);
        }
        private void DrawSymbol(DataGridView grid, string[] symbol)
        {
            int cols = 14;
            int rows = (symbol.Length - 1) / cols + 1;
            for (int i = 0; i < cols; i++)
            {
                grid.Columns.Add("", "");
                grid.Columns[i].Width = 30;
            }
            for (int i = 0; i < rows; i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Height = 30;
            }
            for (int i = 0; i < symbol.Length; i++)
            {
                int row = (i / cols);
                int col = (i % cols);
                grid.Rows[row].Cells[col].Value = (symbol[i]);
            }
        }
        private void frmSymbol_Load(object sender, EventArgs e)
        {
            this.Zoom(dg1, 0, 0);
        }
        /// <summary>
        /// �Ŵ� �ľ��巽����way��hoverʱ��ʾ�Ŵ����������Ǹ����ţ�selectʱ��ʾ�Ŵ�ѡ�е��Ǹ�����
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="way"></param>
        private void Zoom(DataGridView grid, int col, int row)
        {
            if (row >= 0 && col >= 0 && grid.Rows[row].Cells[col].Value != null)
                lblBig.Text = grid.Rows[row].Cells[col].Value.ToString();
            else
            {
                lblBig.Text = "";
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (lblBig.Text != "")
                this.DialogResult = DialogResult.OK;
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    this.Zoom(dg1, 0, 0);
                    break;
                case 1:
                    this.Zoom(dg2, 0, 0);
                    break;
                case 2:
                    this.Zoom(dg3, 0, 0);
                    break;
                case 3:
                    this.Zoom(dg4, 0, 0);
                    break;
                case 4:
                    this.Zoom(dg5, 0, 0);
                    break;
                case 5:
                    this.Zoom(dg6, 0, 0);
                    break;
                case 6:
                    this.Zoom(dg7, 0, 0);
                    break;
                case 7:
                    this.Zoom(dg8, 0, 0);
                    break;
            }
        }
        private void dg1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            Zoom(dg, e.ColumnIndex, e.RowIndex);
        }
        private void dg1_MouseLeave(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            Zoom(dg, dg.CurrentCell.ColumnIndex, dg.CurrentCell.RowIndex);
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void lblBig_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
