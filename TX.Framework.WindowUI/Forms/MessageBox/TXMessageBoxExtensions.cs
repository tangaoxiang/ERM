using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TX.Framework.WindowUI.Forms
{

    /// <summary>
    /// MessageBox的扩展类
    /// </summary>
    /// User:Ryan  CreateTime:2011-08-10 10:56.
    public class TXMessageBoxExtensions
    {
        #region MessageBox

        public static DialogResult Info(string captionText, string message)
        {
            return ShowMessageBox(message,captionText, EnumMessageBox.Info);
        }

        public static DialogResult Info(string message)
        {
            return Info(message, "提示信息");
        }

        public static DialogResult Error(string captionText, string message)
        {
            return ShowMessageBox(message, captionText, EnumMessageBox.Error);
        }

        public static DialogResult Error(string message)
        {
            return Error(message, "错误信息");
        }

        public static DialogResult Question(string captionText, string message)
        {
            return ShowMessageBox(message, captionText, EnumMessageBox.Question);
        }

        public static DialogResult Question(string message)
        {
            return Question( message,"询问信息");
        }

        public static DialogResult Warning(string captionText, string message)
        {
            return ShowMessageBox(message, captionText, EnumMessageBox.Warning);
        }

        public static DialogResult Warning(string message)
        {
            return Warning(message,"警告信息");
        }

        private static DialogResult ShowMessageBox(string captionText, string message, EnumMessageBox infoType)
        {
            TXMessageBox frm = new TXMessageBox(message,captionText, infoType);
            DialogResult result = frm.ShowDialog();
            frm.Dispose();
            return result;
        }
        #endregion
    }
}
