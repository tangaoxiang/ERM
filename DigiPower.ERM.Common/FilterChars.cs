using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.Common
{
    public class FilterChars
    {
        private static readonly Char[] filter = new char[] { '\\','*','\'','[',']'};
        /// <summary>
        /// ���Ƿ��ַ�  ���������ݣ������ڵ�ǰ���filter�У�������ӷǷ��ַ����޸�filter
        /// </summary>
        /// <param name="str">�������ַ���</param>
        /// <returns>������зǷ��ַ�����true ,���򷴻�false</returns>
        public static bool HasFilterChars(string str)
        {
            int len = str.Split(filter).Length;
            if (len != 1)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// ��filter����ת��string ��ʾ��ʱ����
        /// </summary>
        /// <returns>ת������ַ���</returns>
        public static string Chars2String()
        {
            string str ="";
            for (int i = 0; i < filter.Length; i++)
            {
                str += " " + filter[i];
            }
            return str.Trim(' ');
        }
    }
}
