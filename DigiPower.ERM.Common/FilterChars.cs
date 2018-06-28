using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.Common
{
    public class FilterChars
    {
        private static readonly Char[] filter = new char[] { '\\','*','\'','[',']'};
        /// <summary>
        /// 检查非法字符  被检查的内容，包含在当前类的filter中，如果增加非法字符，修改filter
        /// </summary>
        /// <param name="str">被检查的字符串</param>
        /// <returns>如果含有非法字符返回true ,否则反回false</returns>
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
        /// 将filter数组转成string 提示的时候用
        /// </summary>
        /// <returns>转换后的字符串</returns>
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
