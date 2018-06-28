using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Digi.B
{
    public partial class frmSymbol : Form
    {
        public frmSymbol()
        {
            InitializeComponent();

            InitMe();
        }

        #region 初始化
        private void InitMe()
        {
            
            //常用符号
            string[] str1 = { "A1CC", "A1C1", "A1C6", "A1E6", "A1EB", "A6D8", "A6B8", "A6D5", "A6B5", "A3A4", "A94F", "AACB","A6CC" , "A1CF", "A1ED", "AAB1", "AAC3", "AAC4", "AAC5", "AAC6", "AAC7", "AAC8", "AAC9", "AAD0", "AAD1", "AAD2", "AAD3", "AAD5", "AAD6", "AAD7", "AAD8", "AAD9",
                                "A1F9","A1EC","A1FE","A1F0","A1F1","A1F7","A1F8","A1F2","A1EE","A1EF","A1F3","A1F4","A1F5","A1F6","A88C","A88B","A949","A847","A1E2","A1E1","A892","A1D1","A1FC","A1FD","A1FB","A1FA","A849","A84A","A84C","A84B","A1CE","A84F","A3AF","A3DC","A84D","A985","A1A5","A3FE","A3DF","A968","A969","A96C","A96D","A96A","A96B"};
            DrawSymbol(dg1, str1);

            //制表符号
            string[] str2 = { "A2D9", "A2DA", "A2DB", "A2DC", "A2DD", "A2DE", "A2DF", "A2E0", "A2E1", "A2E2", "ABC1", "ABC2", "ABC3", "ABC4", "ABC5", "ABC6", "ABC7", "ABC8", "ABC9", "ABCA", "ABCB", "ABCC", "ABCD", "ABCE", "ABCF", "ABD0", "ABD1", "ABD2", "ABD3", "ABD4", "ABD5", "ABD6", "ABD7", "ABD8", "ABD9", "ABDA", "ABDB", "ABDC", "ABDD", "ABDE", 
                            "ABDF","ABE0","ABE1","ABE2","ABE3","ABE4","ABE5","ABE6","ABE7","ABE8","ABE9","ABEA","ABEB","ABEC","ABED","ABEE","ABEF",
                            "ABF0" ,"ABF1","ABF2","ABF3","ABF4","ABF5","ABF6","ABF7","ABF8","ABF9","ABFA","ABFB","ABFC","ABFD","ABFE",
                            "ACA1","ACA2","ACA3","ACA4","ACA5","ACA6","ACA7","ACA8","ACA9","ACAA","ACAB","ACAC","ACAD","ACAE","ACAF",
                            "ACCB","ACCC","ACCD","ACCE","ACCF","ACD0","ACD1","ACD2","ACD3","ACD4","ACD5","ACD6","ACD7","ACB0","ACB1","ACB2","ACB3","ACB4","ACB5","ACB6","ACB7","ACB8","ACB9","ACBA","ACBB","ACBC","ACBD","ACBE","ACBF","ACC0","ACC1","ACC2","ACC3","ACC4","ACC5","ACC6","ACC7","ACC8","ACC9","ACE0","ACE1","ACE2","ACE3","ACE4","ACE5","ACE6",
                            "ACE7","ACE8","ACE9","ACEA","ACEB","ACEC","ACED","ACEE","ACEF","ACF0","ACF1","ACF2","ACF3","ACF4","ACF5","ACF6","ACF7","ACF8","ACF9","ACFA","ACFB","ACFC","ACFD","ACFE","ADA1","ADA3","ADA4","ADA5","ADA6","ADA7","ADA8","ADA9","ADAA","ADAB","ADAC","ADAD","ADAE","ADAF","ADB0","ADB1","ADB2","ADB3","ADB4","ADB5","ADB6","AEFD",
                            "AEFE","AFA1","AFA2","AFA3","AFA4","AFA5","AFA6","AFA7","AFA8","AFA9","AFAA","AFAB","AFAC","AFAD","AFAE","AFAF","AFB0","AFB1","AFB2","AFB3","AFB4","AFB5","AFB6","AFB7","AFB8","AFB9","AFBA","AFBB","AFBC","AFBD","AFBE","AFBF","AFC0","AFC1","AFC2","AFC3","AFC4","AFC5","AFC6","AFC7","AFC8","AFC9","AFCA","AFCB","AFCC","AFCD",
                            "AFCE","AFCF","AFD0","AFD1","AFD2","AFD3","AFD4","AFD5","AFD6","AFD7","AFD8","AFD9","AFDA","AFDB","AFDC","AFDD","AFDE","AFDF","AFE0","AFE1","AFE2","AFE3","AFE4","AFE5","AFE6","AFE7","AFE8","AFE9","AFEA","AFEB","AFEC","ACCA"};
            DrawSymbol(dg2, str2);


            //数字序号
            string[] str3 = { "A2F1", "A2F2", "A2F3", "A2F4", "A2F5", "A2F6", "A2F7", "A2F8", "A2F9", "A2FA", "A2FB", "A2FC", "A2B1", "A2B2", "A2B3", "A2B4", "A2B5", "A2B6", "A2B7", "A2B8", "A2B9", "A2BA", "A2E5", "A2E6", "A2E7", "A2E8", "A2E9", "A2EA", "A2EB", "A2EC", "A2ED", "A2EE", "A2D9", "A2DA", "A2DB", "A2DC", "A2DD", "A2DE", "A2DF", "A2E0", "A2E1", "A2E2", "A2C5", "A2C6", "A2C7", "A2C8", "A2C9", "A2CA", "A2CB", "A2CC", "A2CD", "A2CE"};
            DrawSymbol(dg3, str3);

            //数学符号
            string[] str4 = { "A1D6", "A1D4", "A1D9", "A3BD", "A1DC", "A1DD", "A3BC", "A3BE", "A1DA", "A1DB", "A1CB", "A1C0", "A3AB", "A3AD", "A1C1", "A1C2", "A3AF", "A1D2", "A1D3", "A1D8", "A1DE", "A1C4", "A1C5", "A1C6", "A1C7", "A1C8", "A1C9", "A1CA", "A1DF", "A1E0", "A1CD", "A1CE", "A1CF", "A1D0", "A1D1", "A1D5", "A1D7", "A1CC", "A851", "A852", "A850", "A1D4", "A980", "A981", "A982", "A983", "A984", "A1AB", "A84E", "A853", "A953", "A952"};
            DrawSymbol(dg4, str4);

            //标点符号
            string[] str5 = { "A1A3", "A3AC", "A1A2", "A3BB", "A3BA", "A3BF", "A3A1", "A1AD", "A1AA", "A1A4", "A1A5", "A1A6", "A1A7", "A1AE", "A1AF", "A1B0", "A1B1", "A1A9", "A1AB", "A1AC" ,
                             "A1C3" ,"A3A7","A3E0","A3FC","A1A8","A1B2","A1B3","A1B4","A1B5","A1B6","A1B7","A1B8","A1B9","A1BA","A1BB","A3AE","A1BC","A1BD","A1BE","A1BF","A3A8","A3A9","A3DB","A3DD","A3FB","A3FD"};
            DrawSymbol(dg5, str5);
           
        }




        //绘制符号
        private void DrawSymbol(DataGridView grid,string[] symbol)
        {
            int rows = (symbol.Length - 1) / 10 + 1;
            int cols = 10;
            //创建格子
            for (int i = 0; i < cols; i++)
            {
                grid.Columns.Add("", "");
                    grid.Columns[i].Width = 30;
            }
            for (int i = 0; i<rows;i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Height = 30;
            }



            //填入符号
            for (int i = 0; i < symbol.Length; i++)
            {
                int row = (i / 10);
                int col = (i % 10);
                grid.Rows[row].Cells[col].Value = Functions.Hex2str(symbol[i]);
            }
        }




        private void frmSymbol_Load(object sender, EventArgs e)
        {
            this.Zoom(dg1,0,0);
        }
        #endregion



        #region 放大 的具体方法
        /// <summary>
        /// 放大 的具体方法，way是hover时表示放大鼠标移入的那个符号，select时表示放大选中的那个符号
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="way"></param>
        private void Zoom(DataGridView grid,int col,int row)
        {

            if (row >= 0 && col >= 0 && grid.Rows[row].Cells[col].Value != null)
                lblBig.Text = grid.Rows[row].Cells[col].Value.ToString();
            else
            {
                lblBig.Text = "";
            }

        }
        #endregion

        #region 提交
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (lblBig.Text != "")
                this.DialogResult = DialogResult.OK;

        }
        #endregion


        #region Tab 选中事件
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    this.Zoom(dg1, 0,0);
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
            }
        }
        #endregion

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





    }
}