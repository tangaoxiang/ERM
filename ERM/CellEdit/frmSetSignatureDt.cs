using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI.CellEdit
{
    public partial class frmSetSignatureDt : ERM.UI.Controls.Skin_DevEX
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        private static extern bool SetLocalTime(ref  SYSTEMTIME systimelp);
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }
        private void SetSystemTime(DateTime date)
        {
            SYSTEMTIME lpTime = new SYSTEMTIME();
            lpTime.wYear = Convert.ToUInt16(date.Year);
            lpTime.wMonth = Convert.ToUInt16(date.Month);
            lpTime.wDayOfWeek = Convert.ToUInt16(date.DayOfWeek);
            lpTime.wDay = Convert.ToUInt16(date.Day);
            DateTime time = DateTime.Now;
            lpTime.wHour = Convert.ToUInt16(time.Hour);
            lpTime.wMinute = Convert.ToUInt16(time.Minute);
            lpTime.wSecond = Convert.ToUInt16(time.Second);
            lpTime.wMilliseconds = Convert.ToUInt16(time.Millisecond);
            SetLocalTime(ref lpTime);
        }

        public frmSetSignatureDt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimeEx1.TextEx.Length > 0)
            {
                SetSystemTime(DateTime.Parse(dateTimeEx1.TextEx));
                TXMessageBoxExtensions.Info("系统日期已更改，窗体讲关闭！");
                this.Close();
            }
        }

        private void frmSetSignatureDt_Load(object sender, EventArgs e)
        {
            dateTimeEx1.TextEx = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExplorer_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
