using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    public class OpenNewForm
    {
        public OpenNewForm() { }
        /// <summary>
        /// 打开窗体的通用方法,如果没有处于打开状态,则实例化并打开,否则将光标聚焦到窗体上
        /// </summary>
        /// <param name="formName">这个参数是完整的类名,命名空间+窗体名称</param>
        public Form ShowOnce(string formName)
        {
            Form form;
            string name = formName.Substring(formName.LastIndexOf(".") + 1);//先得到窗体的名称(无命名空间)
            form = Application.OpenForms[name];//打开窗体,如果窗体是打开状态,则返回值不为null
            if (form != null)//如果窗体处于打开状态,则将光标聚集到窗体
            {
                form.Focus();
            }
            else//如果窗体不在打开状态,则通过简单工厂反射得到窗体,然后将窗体打开
            {
                Type type = Type.GetType(formName);
                if (type != null)
                {
                    form = (Form)System.Activator.CreateInstance(type);
                    form.Show();
                }
                else
                {
                    TXMessageBoxExtensions.Info("检测OpenOnceForm方法的参数是否输入了完整的窗体类名");
                }
            }
            return form;
        }
    }
}
