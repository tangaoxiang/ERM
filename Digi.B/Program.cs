using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Digi.B
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmWelcome());
            //Application.Run(new Form1());
            //Application.Run(new frmCellEdit(@"C:\zjg\通风与空调\KT1_1_ 通风空调工程概况表.cll"));
        }
    }
}