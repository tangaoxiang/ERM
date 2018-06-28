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
        /// �򿪴����ͨ�÷���,���û�д��ڴ�״̬,��ʵ��������,���򽫹��۽���������
        /// </summary>
        /// <param name="formName">�������������������,�����ռ�+��������</param>
        public Form ShowOnce(string formName)
        {
            Form form;
            string name = formName.Substring(formName.LastIndexOf(".") + 1);//�ȵõ����������(�������ռ�)
            form = Application.OpenForms[name];//�򿪴���,��������Ǵ�״̬,�򷵻�ֵ��Ϊnull
            if (form != null)//������崦�ڴ�״̬,�򽫹��ۼ�������
            {
                form.Focus();
            }
            else//������岻�ڴ�״̬,��ͨ���򵥹�������õ�����,Ȼ�󽫴����
            {
                Type type = Type.GetType(formName);
                if (type != null)
                {
                    form = (Form)System.Activator.CreateInstance(type);
                    form.Show();
                }
                else
                {
                    TXMessageBoxExtensions.Info("���OpenOnceForm�����Ĳ����Ƿ������������Ĵ�������");
                }
            }
            return form;
        }
    }
}
