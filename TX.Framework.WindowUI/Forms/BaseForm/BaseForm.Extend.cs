using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TX.Framework.WindowUI.Forms
{
    /// <summary>
    /// 提供Winform的扩展处理类，如messagebox，waitingbox等
    /// </summary>
    public partial class BaseForm
    {
        #region fileds

        /// <summary>
        /// 错误信息的标题
        /// </summary>
        public string[] iErrorCaptions = new string[] { 
            "错误提示！"
            ,"系统错误！"
            ,"亲，出错了！"
            ,"额滴神啊，出错了！"
            ,"上帝都拯救不了你了！"
            ,"什么情况？"
            ,"错错更健康！"
            ,"Error!"
            ,"发现错误！"
            };

        #endregion

        #region waitingBox

        public object ShowWaitingBox(EventHandler<WaitWindowEventArgs> workerMethod)
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            string message = this.iWaittingMessage[ran.Next(0, this.iWaittingMessage.Length)];
            return WaitWindow.Show(workerMethod, message);
        }

        public object ShowWaitingBox(EventHandler<WaitWindowEventArgs> workerMethod, string message)
        {
            return WaitWindow.Show(workerMethod, message, new List<object>());
        }

        public object ShowWaitingBox(EventHandler<WaitWindowEventArgs> workerMethod, string message, params object[] args)
        {
            List<object> arguments = new List<object>();
            arguments.AddRange(args);
            return WaitWindow.Show(workerMethod, message, arguments);
        }

        #endregion

        #region MessageBox

        public DialogResult Info(string captionText, string message)
        {
            return TXMessageBoxExtensions.Info(captionText, message);
        }

        public DialogResult Info(string message)
        {
            return this.Info("提示信息", message);
        }

        public DialogResult Error(string captionText, string message)
        {
            return TXMessageBoxExtensions.Error(captionText, message);
        }

        public DialogResult Error(string message)
        {
            Random ran = new Random(DateTime.Now.Second);
            return this.Error(this.iErrorCaptions[ran.Next(0, this.iErrorCaptions.Length)], message);
        }

        public DialogResult Question(string captionText, string message)
        {
            return TXMessageBoxExtensions.Question(captionText, message);
        }

        public DialogResult Question(string message)
        {
            return this.Question("询问信息", message);
        }

        public DialogResult Warning(string captionText, string message)
        {
            return TXMessageBoxExtensions.Warning(captionText, message);
        }

        public DialogResult Warning(string message)
        {
            return this.Warning("警告信息", message);
        }

        #endregion

        #region PopMessageBox

        /// <summary>
        /// 显示消息弹出窗体
        /// </summary>
        /// <param name="messageInfo">消息内容</param>
        /// User:Ryan  CreateTime:2011-08-18 11:11.
        public void ShowPopBox(string messageInfo)
        {
            this.ShowPopBox(string.Empty, messageInfo);
        }

        /// <summary>
        /// 显示消息弹出窗体
        /// </summary>
        /// <param name="captionText">消息框的标题.</param>
        /// <param name="messageInfo">消息内容.</param>
        /// User:Ryan  CreateTime:2011-08-18 11:11.
        public void ShowPopBox(string captionText, string messageInfo)
        {
            //TXPopBoxExtensions.ShowPopBox(captionText, messageInfo);
        }

        #endregion

        #region  InvokeBackgroudMethod（后台异步执行方法）

        /// <summary>
        /// 异步执行方法
        /// </summary>
        /// User:Ryan  CreateTime:2012-11-26 21:29.
        public void InvokeBackgroudMethod(MethodInvoker method)
        {
            method.BeginInvoke(null, null);
        }

        #endregion
    }
}
