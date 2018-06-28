using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Reflection;
using System.Collections;
using ERM.MDL;
using ERM.BLL;
using System.Xml;
using TX.Framework.WindowUI.Forms;
using ERM.UI.Controls;
using System.Threading;
using ERM.UI.Common;
using System.Configuration;

namespace ERM.UI
{
    /// <summary>
    /// 公共函数类，静态访问
    /// </summary>
    public class MyCommon
    {
        /// <summary>
        /// 判断是否包含中文字符
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsMatchCode(string value)
        {
           // Regex regex = new Regex(@"[，。；？?~！：‘'\""“”’【】（）]");
            Regex regex = new Regex(ConfigurationManager.AppSettings["isMatchCode"].ToString());
            if (regex.IsMatch(value))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 递归删除目录下子文件及文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFilesAndFolders(string path)
        {
            // Delete files.  
            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                File.Delete(file);
            }

            // Delete folders.  
            string[] folders = Directory.GetDirectories(path);
            foreach (var folder in folders)
            {
                DeleteFilesAndFolders(folder);
                Directory.Delete(folder);
            }
        }  

        public static bool RegexDate(string date, string formattype = "-")
        {
            string pattern = "";
            if (formattype == "-")
                pattern = @"^((?:19|20)\d\d)-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])$";
            else if (formattype == ".")
                pattern = @"^((?:19|20)\d\d).(0[1-9]|1[012]).(0[1-9]|[12][0-9]|3[01])$";

            Match m = Regex.Match(date, pattern);
            return m.Success;
        }
        public static double ToDouble(object obj)
        {
            double strOut = 0;
            if (obj != null && obj.ToString() != "")
            {
                try
                {
                    strOut = double.Parse(obj.ToString());
                }
                catch { }
            }
            return strOut;
        }

        public static DateTime ToDate(object obj)
        {
            DateTime strOut = DateTime.Now;
            if (obj != null && obj.ToString() != "")
            {
                try
                {
                    strOut = DateTime.Parse(obj.ToString());
                }
                catch { }
            }
            return strOut;
        }

        public static double ToFloat(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            double f1 = 0;
            string str = obj.ToString();
            string str2 = "0";
            foreach (char c1 in str)
            {
                if ((c1 >= 48 && c1 <= 57) || c1 == '.' || c1 == '-')
                {
                    str2 += c1;
                }
            }
            try
            {
                f1 = float.Parse(str2);
            }
            catch { }
            return f1;
        }

        public static int ToInt(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            int f1 = 0;
            string str = obj.ToString();
            string str2 = "0";
            foreach (char c1 in str)
            {
                if (c1 >= 48 && c1 <= 57)
                {
                    str2 += c1;
                }
            }
            try
            {
                f1 = int.Parse(str2);
            }
            catch { }
            return f1;
        }

        public static long ToLong(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            long f1 = 0;
            string str = obj.ToString();
            string str2 = "0";
            foreach (char c1 in str)
            {
                if (c1 >= 48 && c1 <= 57)
                {
                    str2 += c1;
                }
            }
            try
            {
                f1 = long.Parse(str2);
            }
            catch { }
            return f1;
        }

        public static decimal ToMoney(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            double f1 = 0;
            string str = obj.ToString();
            string str2 = "0";
            foreach (char c1 in str)
            {
                if ((c1 >= 48 && c1 <= 57) || c1 == '.' || c1 == '-')
                {
                    str2 += c1;
                }
            }
            try
            {
                f1 = double.Parse(str2, System.Globalization.NumberStyles.Currency);
                return decimal.Parse(f1.ToString("0.00"));
            }
            catch { return 0; }
        }

        public static string ToString(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString().Trim();
            }
        }
        public static string ToString(string obj)
        {
            if (string.IsNullOrWhiteSpace(obj))
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        public static bool ToBoolean(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                try
                {
                    return bool.Parse(obj.ToString());
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取MD5字串
        /// </summary>
        /// <param name="normalString">未加密字串</param>
        /// <returns></returns>
        public static string MD5String(string normalString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            string str = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(normalString)));
            str = str.Replace("-", "").ToUpper();
            return str;
        }
        /// <summary>
        /// 显示警告消息框
        /// </summary>
        /// <param name="strMsg">消息</param>
        public static void ShowWarning(string strMsg)
        {
            MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// 显示错误消息框
        /// </summary>
        /// <param name="strMsg">消息</param>
        public static void ShowError(string strMsg)
        {
            MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 显示Yes,No,Cancel三个按钮
        /// </summary>
        /// <param name="strMsg"></param>
        public static DialogResult ShowYesNoCancel(string strMsg)
        {
            return MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
        /// <summary>
        /// 显示提示消息框
        /// </summary>
        /// <param name="strMsg">消息</param>
        public static void ShowInfo(string strMsg)
        {
            Show(strMsg);
        }
        public static void Show(string strMsg)
        {
            MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 显示对话消息框
        /// </summary>
        /// <param name="strMsg">消息</param>
        /// <returns>对话框的返回值</returns>
        public static DialogResult ShowQuestion(string strMsg)
        {
            return MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        /// <summary>
        /// 显示对话消息框 并用警告图标
        /// </summary>
        /// <param name="strMsg">消息</param>
        public static DialogResult ShowQuestionWarning(string strMsg)
        {
            return MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="prompt">标题</param>
        /// <param name="title">描述</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string ShowInputBox(string prompt, string title, string defaultValue)
        {
            ERM.UI.InputBoxDialog ib = new ERM.UI.InputBoxDialog();
            ib.FormPrompt = prompt;
            ib.FormCaption = title;
            ib.DefaultValue = defaultValue;
            ib.ShowDialog();
            string s = ib.InputResponse;
            ib.Close();
            return s;
        }
        /// <summary>
        /// 转换成SQL语句中的字符串
        /// </summary>
        /// <param name="str">字串</param>
        public static string ToSqlString(string str)
        {
            return str.Trim().Replace("'", "''");
        }
        /// <summary>
        /// 工程管理的扩展信息用这个,里面的'号不好搞
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSqlString2(string str)
        {
            return str.Trim().Replace("'", "");
        }
        /// <summary>
        /// 转换成SQL语句中的数字
        /// </summary>
        /// <param name="str">字串</param>
        /// <returns></returns>
        public static string ToSqlNumber(string str)
        {
            if (IsNumeric(str.Trim()) == false)
                return "0";
            else
                return str.Trim();
        }
        /// <summary>
        /// SQL语句中用于日期字串的连接符
        /// </summary>
        /// <returns></returns>
        public static string DataTimeChar()
        {
            if (Globals.DBType == "Access")
                return "#";
            else
                return "'";
        }
        public static bool IsDateTime(string value)
        {
            if (value == string.Empty)
                return false;
            try
            {
                DateTime.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// /工程管理中用到的是否为整数，必须大于等于0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ProjectIsIntParse(string value)
        {
            if (value == string.Empty)
                return false;
            try
            {
                int i = int.Parse(value);
                if (i >= 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 工程管理中用到的判断，必须是正数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ProjectIsNumericParse(string value)
        {
            if (value == string.Empty)
                return false;
            try
            {
                decimal d = decimal.Parse(value);
                if (d >= 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 判断输入的是否是数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns>bool true:是　false:否</returns>
        public static bool IsNumeric(string value)
        {
            if (value == string.Empty)
                return false;
            try
            {
                decimal.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 判断输入的是否是整型数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns>bool true:是　false:否</returns>
        public static bool IsInt(string value)
        {
            if (value == string.Empty)
                return false;
            try
            {
                int.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 不区分大小写的Replace
        /// </summary>
        /// <param name="strSource">完整的字符串</param>
        /// <param name="strRe">要替换的字符串</param>
        /// <param name="strTo">替换成</param>
        /// <returns></returns>
        public static string Replace(string strSource, string strRe, string strTo)
        {
            string strSl, strRl;
            strSl = strSource.ToLower();
            strRl = strRe.ToLower();
            int start = strSl.IndexOf(strRl);
            if (start != -1)
            {
                strSource = strSource.Substring(0, start) + strTo
                + Replace(strSource.Substring(start + strRe.Length), strRe, strTo);
            }
            return strSource;
        }
        /// <summary>
        /// 从树的Tag对象中获取LastLeaf值
        /// </summary>
        /// <param name="obj">Tag对象</param>
        /// <returns>是否最后一个节点</returns>
        public static int GetLastLeafFromTag(object obj)
        {
            string[] str = (string[])obj;
            return MyCommon.ToInt(str[0]);
        }
        /// <summary>
        /// 从树的Tag对象中获取ExamplePath值
        /// </summary>
        /// <param name="obj">Tag对象</param>
        /// <returns>范例路径</returns>
        public static string GetExamplePathFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[0];
        }
        public static string GetTreePathFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[2];
        }
        /// <summary>
        /// 从树的Tag对象中获取CustomDefine值(CustomDefine表示该表格是否是用户自建的表格)
        /// </summary>
        /// <param name="obj">Tag对象</param>
        /// <returns>CustomDefine</returns>
        public static string GetCustomDefineFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[0];
        }
        public static string GetDocStatutsFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[1];
        }
        /// <summary>
        /// 从树的Tag对象中获取hasAttach值(CustomDefine表示该表格是否有附件)
        /// </summary>
        /// <param name="obj">Tag对象</param>
        /// <returns>hasAttach(0-无 1-有)</returns>
        public static int GethasAttachFromTag(object obj)
        {
            string[] str = (string[])obj;
            return MyCommon.ToInt(str[3]);
        }

        /// <summary>
        /// 从树Tag对象中获取子分部名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetZfbmcFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[3];
        }
        /// <summary>
        /// 从树Tag对象中获取分项名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetFxmcFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[4];
        }
        public static string GetZrrFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[2];
        }
        /// <summary>
        /// 从左边获取字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Left(string s, int len)
        {
            string tmp = string.Empty;
            int stringLen = s.Length;
            if (len <= stringLen)
            {
                for (int i = 0; i < len; i++)
                    tmp = tmp + s[i];
            }
            else
                tmp = s;
            return tmp;
        }
        /// <summary>
        /// 从由边获取字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Right(string s, int len)
        {
            string tmp = string.Empty;
            int stringLen = s.Length;
            if (len <= stringLen)
            {
                for (int i = stringLen - len; i < stringLen; i++)
                    tmp = tmp + s[i];
            }
            else
                tmp = s;
            return tmp;
        }
        /// <summary>
        /// 获取短文件名
        /// </summary>
        /// <param name="fullFilePath">文件的整个路径</param>
        /// <returns>短文件名</returns>
        public static string GetFileShortName(string fullFilePath)
        {
            try
            {
                FileInfo file = new FileInfo(fullFilePath);
                return file.Name;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 获取没有扩展名的短文件名
        /// </summary>
        /// <param name="fullFilePath">文件的整个路径</param>
        /// <returns>短文件名</returns>
        public static string GetFileShortNameNoExt(string fullFilePath)
        {
            try
            {
                FileInfo file = new FileInfo(fullFilePath);
                return file.Name.Replace(file.Extension, "");
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 获取文件的扩展名
        /// </summary>
        /// <param name="fullFilePath">文件的整个路径</param>
        /// <returns>扩展名（包含".")</returns>
        public static string GetFileExtension(string fullFilePath)
        {
            try
            {
                FileInfo file = new FileInfo(fullFilePath);
                return file.Extension;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 将颜色转化为32bit RGB值:
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static int GetRGBFromColor(System.Drawing.Color color)
        {
            byte r = color.R;
            byte g = color.G;
            byte b = color.B;
            int rgb = (r & 0xff) | ((g & 0xff) << 8) | ((b & 0xff) << 16);
            return rgb;
        }
        /// <summary>
        /// 将颜色转化为32bit RGB值:
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GetRGBFromColor(int r, int g, int b)
        {
            int rgb = (r & 0xff) | ((g & 0xff) << 8) | ((b & 0xff) << 16);
            return rgb;
        }
        /// <summary>
        /// 数字比较，如果原始数字中包含要比较的数据，则减去以后返回，用在Cell控件单元格的值计算中
        /// </summary>
        /// <param name="orgVal">原始数字</param>
        /// <param name="includeVal">需要比较的数字</param>
        /// <returns></returns>
        public static int NumberMinus(int orgVal, int includeVal)
        {
            if ((orgVal & includeVal) == includeVal)
                return (orgVal - includeVal);
            else
                return orgVal;
        }
        /// <summary>
        /// 将16进制转换成字符串
        /// </summary>
        /// <param name="hexstring"></param>
        /// <returns></returns>
        public static string Hex2str(string hexstring)
        {
            Encoding encode = Encoding.GetEncoding("GB2312");
            byte[] b = new byte[hexstring.Length / 2];
            for (int i = 0; i < hexstring.Length / 2; i++)
            {
                b[i] = Convert.ToByte("0x" + hexstring.Substring(i * 2, 2), 16);
            }
            return encode.GetString(b);
        }
        /// <summary>
        /// 应用界面样式
        /// </summary>
        /// <param name="theme">1-XP, 2-Office2003</param>
        public static void ApplyTheme(int theme)
        {
            if (theme == Themes.XP)
            {
                ToolStripManager.RenderMode = ToolStripManagerRenderMode.Professional;
                ToolStripManager.VisualStylesEnabled = false;
            }
            else if (theme == Themes.Office2003)
            {
                ToolStripManager.RenderMode = ToolStripManagerRenderMode.Professional;
                ToolStripManager.VisualStylesEnabled = true;
            }
        }
        /// <summary>
        /// 获取不会重名的字符串
        /// </summary>
        /// <returns></returns>
        public static string GetUnique()
        {
            Guid g = Guid.NewGuid();
            return g.ToString();
        }
        /// <summary>
        /// 数组转换为华表中的下拉列表
        /// </summary>
        /// <returns></returns>
        public static string Array2DroplistCell(string[] str)
        {
            string ret = "";
            for (int i = 0; i < str.Length; i++)
            {
                ret += str[i] + "\r\n";
            }
            return ret;
        }
        /// <summary>
        /// 打开或执行一个外部文件
        /// </summary>
        /// <param name="fullFilePath">完整的文件路径</param>
        public static void OpenDocument(string fullFilePath)
        {
            if (System.IO.File.Exists(fullFilePath))
            {
                System.Diagnostics.Process.Start(fullFilePath);
            }
        }
        /// <summary>
        /// 对算数表达式进行运算，返回真假
        /// </summary>
        /// <param name="expression">表达式，如"5>(1+3)"则返回true</param>
        /// <returns>返回真假</returns>
        public static bool Eval(string expression)
        {
            try
            {
                System.Data.DataTable table = new System.Data.DataTable();
                System.Data.DataColumn Col = new System.Data.DataColumn("col1", typeof(string), expression);
                table.Columns.Add(Col);
                table.Rows.Add(new object[] { "" });
                return Convert.ToBoolean(table.Rows[0][0]);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 计算值，类似于funcion中的eval
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static object otherEval(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            System.Data.DataColumn Col = new System.Data.DataColumn("col1", typeof(string), expression);
            table.Columns.Add(Col);
            table.Rows.Add(new object[] { "" });
            return table.Rows[0][0];
        }
        /// <summary>
        /// 文本内容转成 xml时的内容过滤
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TextToXml(string str)
        {
            string ret = str;
            ret = ret.Replace("<", "&lt;");
            ret = ret.Replace(">", "&gt;");
            ret = ret.Replace("\n", "");
            ret = ret.Replace("\r", "");
            return ret;
        }
        /// <summary>
        /// 是否合法的IP地址
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidIP(string strIn)
        {
            string[] str = strIn.Split('.');
            int a1 = int.Parse(str[0].Trim());
            int a2 = int.Parse(str[1].Trim());
            int a3 = int.Parse(str[2].Trim());
            int a4 = int.Parse(str[3].Trim());
            if (a1 > 255 || a2 > 255 || a3 > 255 || a4 > 255)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 随机填充
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="col2"></param>
        /// <param name="row2"></param>
        /// <param name="sheet"></param>
        /// <param name="Cell1"></param>
        public static void parse(string expression, int col2, int row2, int sheet, AxCELL50Lib.AxCell Cell1, int ws, bool fh)
        {
            string str = expression.Replace("\r", "").Replace("\n", "").Replace(" ", "").ToLower();
            str = str.Replace("run{", "");
            str = str.Replace("}", "");
            str = str.Replace("break;", "#");
            if (str == "") return;
            string newExpression = "";
            int col = 0;
            int row = 0;
            string[] condArr = str.Split('#');
            if (condArr.Length > 1)
            {
                for (int i = 0; i < condArr.Length; i++)
                {
                    if (condArr[i] != "")
                    {
                        string[] subCondArr = condArr[i].Split(':');
                        if (subCondArr.Length > 1)
                        {
                            if (Cell1.LabelToCell(subCondArr[0], ref col, ref row))
                            {
                                if (Cell1.GetCellDouble(col, row, sheet).ToString() == "1")
                                {
                                    newExpression = subCondArr[1];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                newExpression = str;
            }
            string strMin = "";  //"最小"表达式
            string strMax = "";  //"最大"表达式
            string strX = "";    //"变量"表达式
            string strX1 = "";   //strX的后半部分，即单元格
            string strXVal = ""; //单元格的值
            string strOther = ""; //其他变量
            if (newExpression == "") return;
            string[] arr = newExpression.Split(';');
            if (arr.Length <= 1) return;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].StartsWith("min"))
                    strMin = arr[i];
                if (arr[i].StartsWith("max"))
                    strMax = arr[i];
                if (arr[i].StartsWith("x"))
                    strX = arr[i];
                if (arr[i].StartsWith("value"))
                    strOther = arr[i];
            }
            if (strX != "" && strX.Contains("="))
            {
                strX1 = strX.Split('=')[1];
                if (Cell1.LabelToCell(strX1, ref col, ref row))
                {
                    strXVal = Cell1.GetCellString(col, row, sheet);
                    if (!IsNumeric(strXVal))
                    {
                        return;
                    }
                }
            }
            strMin = strMin.Replace("x", strXVal);
            strMax = strMax.Replace("x", strXVal);
            strOther = strOther.Replace("x", strXVal);
            string[] strarray = strMin.Split(new char[] { '>', '=', '<' });
            object min = null;
            if (strarray[strarray.Length - 1] != "")
                min = otherEval(strarray[strarray.Length - 1]);
            strarray = strMax.Split(new char[] { '>', '=', '<' });
            object max = null;
            if (strarray[strarray.Length - 1] != "")
                max = otherEval(strarray[strarray.Length - 1]);
            strarray = strOther.Split(new char[] { '>', '=', '<' });
            object other = null;
            if (strarray[strarray.Length - 1] != "")
                other = otherEval(strarray[strarray.Length - 1]);
            if (max == null)
            {
                max = Convert.ToDouble(min) * 1.1;
            }
            if (min == null)
            {
                min = Convert.ToDouble(max) * 0.9;
            }
            if (other != null)
            {
                if (strOther.Contains(">"))
                {
                    if (Convert.ToDouble(other) > Convert.ToDouble(min))
                    {
                        min = other;
                    }
                }
                else
                {
                    if (Convert.ToDouble(other) < Convert.ToDouble(max))
                    {
                        max = other;
                    }
                }
            }
            string o = Rnd(Convert.ToDouble(min), Convert.ToDouble(max), ws);
            if (fh && !o.ToString().StartsWith("-"))
                o = "+" + o;//如果要符号，且不是为负数
            Cell1.S(col2, row2, sheet, o);
        }
        /// <summary>
        /// 跟随机数函数共同作用，防止出来的结果相同
        /// </summary>
        private static int roCount = 0;
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="outputInt">true返回整数，false返回小数</param>
        /// <returns></returns>
        public static string Rnd(double d_min, double d_max, int _outXsw)
        {
            int xsw = _outXsw;
            for (int i = 0; i < xsw; i++)
            {
                d_max *= 10;
                d_min *= 10;
            }
            Random ro = new Random(unchecked(roCount * (int)DateTime.Now.Ticks));
            double d = ro.Next((Int32)d_min, (Int32)d_max);
            for (int i = 0; i < xsw; i++)
                d = d / 10;
            string bb = "#0.";
            if (_outXsw > 0)
            {
                for (int i = 0; i < _outXsw; i++)
                    bb += '0';
            }
            roCount++;
            return d.ToString(bb);
        }
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="outputInt">true返回整数，false返回小数</param>
        /// <returns></returns>
        public static object Rnd(double d_min, double d_max, bool outputInt)
        {
            int min = MyCommon.ToInt(d_min);
            int max = MyCommon.ToInt(d_max);
            int num = 0;
            Random ro = new Random(unchecked(roCount * (int)DateTime.Now.Ticks));
            num = ro.Next(min, max);
            roCount++;
            if (outputInt)
                return num;
            else
            {
                if (min == max && min == 0 && d_max > 0)
                    return (d_max * ro.NextDouble()).ToString("#0.000");
                else
                    return (num * ro.NextDouble()).ToString("#0.0");
            }
        }
        /// <summary>
        /// 去掉路径中的[0],*
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string OpeartPath(TreeNodeEx node)
        {
            if (node != null)
            {
                if (node.ImageIndex == 2 | node.ImageIndex == 4 | node.ImageIndex == 5)
                {
                    string treepath = node.Parent.FullPath + "\\" + node.Text.Substring(node.Text.LastIndexOf("]") + 1);
                    treepath = treepath.Replace("*", "");
                    return treepath;
                }
                if (node.ImageIndex == 3)
                {
                    string treepath = node.Parent.Parent.FullPath + "\\" + node.Parent.Text.Substring(node.Text.LastIndexOf("]") + 1) + "\\" + node.Text;
                    treepath = treepath.Replace("*", "");
                    return treepath;
                }
                return null;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static void DeleteAndCreateEmptyDirectory(string BackupPath)
        {
            DeleteAndCreateEmptyDirectory(BackupPath, true);
        }
        public static void DeleteAndCreateEmptyDirectory(string BackupPath, bool bCreate)
        {
            if (bCreate == true)
            {
                if (!Directory.Exists(BackupPath))
                    Directory.CreateDirectory(BackupPath);
            }
            else
            {
                if (System.IO.Directory.Exists(BackupPath))
                {
                    string[] fileList = Directory.GetFiles(BackupPath);
                    if (fileList.Length > 0)
                    {
                        Directory.Delete(BackupPath, true);

                        if (!Directory.Exists(BackupPath))
                            Directory.CreateDirectory(BackupPath);
                        //foreach (string f1 in System.IO.Directory.GetFiles(BackupPath))
                        //{
                        //    try
                        //    {
                        //        System.IO.File.Delete(f1);
                        //    }
                        //    catch { }
                        //}
                        //try
                        //{
                        //    Directory.Delete(BackupPath, true);
                        //    if (bCreate == true)
                        //    {
                        //        Directory.CreateDirectory(BackupPath);
                        //    }
                        //}
                        //catch { }
                    }
                }
            }
        }
        public static void DWG2PDF(string InFile, string OutFile)
        {
            string exeFile = @"C:\Program Files\Acme CAD Converter\AcmeCADConverter.exe ";
            string exePara = " /r /e /f 105 /d \"" + OutFile + "\" \"" + InFile + "\"";
            System.Diagnostics.Process myProc = new System.Diagnostics.Process();
            myProc.StartInfo.FileName = exeFile;
            myProc.StartInfo.Arguments = exePara;
            myProc.Start();
            while (!myProc.HasExited)
            {
                System.Threading.Thread.Sleep(3000);
            }
            try
            {
                if (myProc.HasExited)//判断是否运行结束       
                    myProc.Kill();
            }
            catch { }
        }
        public static DataTable ToDataTable<T>(IList<T> entitys)
        {
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();
            DataTable dt = new DataTable();
            int iColumnCount = 0;
            for (int i = 0; i < entityProperties.Length; i++)
            {
                if (!entityProperties[i].PropertyType.Name.Contains("Nullable"))
                {
                    iColumnCount++;
                    dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                }
            }
            foreach (object entity in entitys)
            {
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[iColumnCount];
                int curColumnIndex = 0;
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    if (!entityProperties[i].PropertyType.Name.Contains("Nullable"))
                    {
                        entityValues[curColumnIndex++] = entityProperties[i].GetValue(entity, null);
                    }
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }
        public static DataTable ToDataTable<T>(List<T> entitys)
        {
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();
            DataTable dt = new DataTable();
            int iColumnCount = 0;
            for (int i = 0; i < entityProperties.Length; i++)
            {
                if (!entityProperties[i].PropertyType.Name.Contains("Nullable"))
                {
                    iColumnCount++;
                    dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                }
            }
            foreach (object entity in entitys)
            {
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[iColumnCount];
                int curColumnIndex = 0;
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    if (!entityProperties[i].PropertyType.Name.Contains("Nullable"))
                    {
                        entityValues[curColumnIndex++] = entityProperties[i].GetValue(entity, null);
                    }
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }

        public static IList<T> DataTableToList<T>(DataTable dt)
        {
            if (dt == null)
                return null;
            IList<T> result = new List<T>();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (pi.Name.Equals(dt.Columns[i].ColumnName))
                        {
                            if (dt.Rows[j][i] != DBNull.Value)
                            {
                                if (pi.PropertyType.ToString() == "System.Int32")
                                {
                                    pi.SetValue(_t, Int32.Parse(dt.Rows[j][i].ToString()), null);
                                }
                                if (pi.PropertyType.ToString() == "System.DateTime")
                                {
                                    pi.SetValue(_t, Convert.ToDateTime(dt.Rows[j][i].ToString()), null);
                                }
                                if (pi.PropertyType.ToString() == "System.String")
                                {
                                    pi.SetValue(_t, dt.Rows[j][i].ToString(), null);
                                }
                                if (pi.PropertyType.ToString() == "System.Boolean")
                                {
                                    pi.SetValue(_t, Convert.ToBoolean(dt.Rows[j][i].ToString()), null);
                                }
                            }
                            else
                                pi.SetValue(_t, null, null);
                            break;
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }

        //2011-03-15 YQ
        /// <summary>
        /// 判断文件后缀是否与指定的后缀相同
        /// </summary>
        /// <param name="filename">文件路径或名称</param>
        /// <param name="suffixname">后缀名次（例如：.doc,.cll,.excl）</param>
        /// <returns>bool:true相同 false不同</returns>
        public static bool CheckFillSuffix(string filename, string suffixname)
        {
            System.IO.FileInfo f1 = new FileInfo(Globals.ProjectPath + filename);
            string filesuffix = f1.Extension;//获取文件后缀
            if (filesuffix != null && string.Compare(filesuffix.ToLower(), suffixname.ToLower()) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 系统权限和页面一些个性化的需求信息
        /// <summary>
        /// 判断一级菜单显示状态方法
        /// </summary>
        /// <param name="menu_flg">判断标记：1资源用表 2文件登记 3组卷 4工程移交 5工程添加 6工程删除</param>
        /// <returns>bool:true显示 false隐藏</returns>
        public static bool CheckMenuState(string menu_flg)
        {
            int menuState = 0;
            switch (menu_flg)
            {
                case "1":
                    menuState = string.Compare(Properties.Settings.Default.Module1, Globals.IsOkGuid);
                    break;
                case "2":
                    menuState = string.Compare(Properties.Settings.Default.Module2, Globals.IsOkGuid);
                    break;
                case "3":
                    menuState = string.Compare(Properties.Settings.Default.Module3, Globals.IsOkGuid);
                    break;
                case "4":
                    menuState = string.Compare(Properties.Settings.Default.Module4, Globals.IsOkGuid);
                    break;
                case "5":
                    menuState = string.Compare(Properties.Settings.Default.Project_Add, Globals.IsOkGuid);
                    break;
                case "6":
                    menuState = string.Compare(Properties.Settings.Default.Project_Del, Globals.IsOkGuid);
                    break;
            }
            return menuState == 0 ? true : false;
        }

        /// <summary>
        /// 检测工程编号和工程名称是否可以编辑
        /// </summary>
        /// <returns>bool:true可以编辑 false不可编辑</returns>
        public static bool CheckProjectBind()
        {
            return string.Compare(Properties.Settings.Default.ProjectNameBind, Globals.IsOkGuid) == 0 ? true : false;
        }

        /// <summary>
        /// 个性化显示绑定方法
        /// </summary>
        /// <param name="lbl_showLable">显示的Lable控件对象</param>
        /// <param name="lable_flg">
        ///  绑定的Text内容标记 
        ///  0 工程编号(备案号)
        ///  1 工程用地批准书号
        ///  2 用地规划许可证号
        ///  3 工程规划许可证号
        ///  4 用地规划许可证号
        /// </param>
        public static void ShowTextBind(SkinLabelEX lbl_showLable,
            string lable_flg)
        {
            switch (lable_flg)
            {
                case "0":
                    lbl_showLable.Text = Properties.Settings.Default.lbl_ProjectNO;
                    break;
                case "1":
                    lbl_showLable.Text = Properties.Settings.Default.lbl_wh1;
                    break;
                case "2":
                    lbl_showLable.Text = Properties.Settings.Default.lbl_wh2;
                    break;
                case "3":
                    lbl_showLable.Text = Properties.Settings.Default.lbl_wh3;
                    break;
                case "4":
                    lbl_showLable.Text = Properties.Settings.Default.lbl_wh4;
                    break;
            }
        }
        /// <summary>
        /// 检测是否需要Ukey
        /// </summary>
        /// <returns>bool: true需要 false不需要</returns>
        public static bool IsCheckFD()
        {
            return Properties.Settings.Default.fd == "f" ? true : false;
        }

        /// <summary>
        /// 获取目录下所有文件总数
        /// </summary>
        /// <param name="sourceDirName">文件夹路径</param>
        /// <param name="tempfileCount">统计文件总数的临时变量</param>
        public static void GetFileCountByDirectory(string sourceDirName, ref int tempfileCount)
        {
            string[] files = Directory.GetFiles(sourceDirName);
            if (files != null && files.Length > 0)
            {
                tempfileCount += files.Length;
            }
            string[] dirs = Directory.GetDirectories(sourceDirName);
            foreach (string dir in dirs)
            {
                GetFileCountByDirectory(dir, ref tempfileCount);
            }
        }

        /// <summary>
        /// 获取文件总数
        /// </summary>
        /// <param name="sourceDirName">文件夹路径</param>
        /// <param name="check_flg">传入的状态值， 返回false 表示文件夹有错误 </param>
        /// <param name="fileCount">文件总数</param>
        public static void GetFileCount(string sourceDirName, ref bool check_flg, ref int fileCount)
        {
            if (check_flg)
            {
                if (System.IO.Directory.Exists(sourceDirName))
                {
                    string[] files = Directory.GetFiles(sourceDirName);
                    if (files != null && files.Length > 0)
                    {
                        fileCount += files.Length;
                    }
                    string[] dirs = Directory.GetDirectories(sourceDirName);
                    foreach (string dir in dirs)
                    {
                        GetFileCount(dir, ref check_flg, ref fileCount);
                    }
                }
                else
                {
                    check_flg = false;
                    fileCount = 0;
                    MessageBox.Show("提示：文件夹路径错误：'" + sourceDirName + "' \n 【温馨提示：文件路径不存在或文件夹尾部可能包含特殊字符或全角字符 例如：空格,星号...】",
                        "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// 验证是否为0和正整数
        /// </summary>
        /// <param name="num">数字</param>
        /// <returns></returns>
        public static bool VldIntegerZ(string num)
        {
            string sPattern = @"^\d+$";
            return Regex.IsMatch(num, sPattern);
        }

        /// <summary>
        /// 判断工程编号格式 数字，字母，下划线，减号
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static bool isYesProjectNo(string dateStr)
        {
            return Regex.IsMatch(dateStr, @"^[A-Za-z0-9_-]+$");
        }

        /// <summary>
        /// 判断上传文件类型的 .*
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public static bool CheckFileType(string fileExtension)
        {
            ReadWriteAppConfig config = new ReadWriteAppConfig();
            string fileType = config.Read("uplodafileType");
            if (fileType == null || fileType == "")
            {
                fileType = ".JPG,.DOC,.DOCX,.XLS,.XLSX,.TIF,.PDF";//,.DWG.XML,
                config.Write("uplodafileType", fileType);
            }
            else
            {
                if (fileType.IndexOf(",PPTX,") != -1)
                {
                    fileType = fileType.Replace(",PPTX,", ",.PPTX,");
                    config.Write("uplodafileType", fileType);
                }
            }
            bool return_Flg = false;
            if (fileExtension == null || fileExtension == "")
                return_Flg = false;
            else if (fileType.IndexOf(fileExtension.ToUpper()) != -1)
                return_Flg = true;
            return return_Flg;
        }

        /// <summary>
        /// 判断当前迁入的文件 是什么类型 1 文字数量  2声像 3照片数量
        /// </summary>
        /// <param name="fileNode">目录节点</param>
        /// <param name="efile_type">类型标记：请给默认值1</param>
        public static void GetParentNodeType(TreeNode fileNode, ref int efile_type)
        {
            if (fileNode != null && fileNode.Parent != null && fileNode.Parent.ImageIndex == 1)
                GetParentNodeType(fileNode.Parent, ref efile_type);

            if (fileNode != null && fileNode.Parent != null && fileNode.Parent.Level == 0)
            {
                if (fileNode.Text.Trim().IndexOf("声像") != -1)
                    efile_type = 2;
                else if (fileNode.Text.Trim().IndexOf("图") != -1)
                    efile_type = 3;
            }
        }

        /// <summary>
        /// 判断当前迁入的文件 是什么类型 1 文字数量  2声像 3照片数量
        /// </summary>
        /// <param name="fileNode">文件目录ID</param>
        /// <param name="efile_type">类型标记：请给默认值1</param>
        public static void GetParentNodeType(string fileID, ref int efile_type)
        {
            ERM.BLL.T_FileList_BLL file_bll = new ERM.BLL.T_FileList_BLL();
            ERM.MDL.T_FileList file_model = file_bll.Find(fileID, Globals.ProjectNO);
            if (file_model != null && file_model.ParentID != null && file_model.ParentID.Trim() != "")
                GetParentNodeType(file_model.ParentID, ref efile_type);

            if (file_model != null && file_model.ParentID != null && file_model.ParentID.Trim() == "")
            {
                if (file_model.gdwj.Trim().IndexOf("声像") != -1)
                    efile_type = 2;
                else if (file_model.gdwj.Trim().IndexOf("图") != -1)
                    efile_type = 3;
            }
        }
        #endregion

        public static double CheckDisk(string filepath)
        {
            double return_flg = 0;
            string diskName = filepath.Substring(0, filepath.IndexOf(":") + 1);
            HardDiskPartition hp_disk = new HardDiskPartition();
            HardDiskPartition harddisk = hp_disk.GetDiskInfo(diskName);
            if (harddisk != null)
            {
                return_flg = hp_disk.ManagerDoubleValue(harddisk.FreeSpace, 2);
            }
            return return_flg;
            //string.Format("{0}  总空间：{1} GB,剩余:{2} GB",
            //    hp_disk.PartitionName, hp_disk.ManagerDoubleValue(hp_disk.SumSpace, 1),
            //    hp_disk.ManagerDoubleValue(disk.FreeSpace, 1));
        }

        /// <summary>
        ///  日志记录方法（按当天记录）
        /// </summary>
        /// <param name="MessageLog">日志信息</param>
        public static void WriteLog(string MessageLog)
        {
            string errLog_path = Application.StartupPath + "\\log";
            if (!Directory.Exists(errLog_path))
                Directory.CreateDirectory(errLog_path);
            errLog_path += "\\log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

            if (System.IO.File.Exists(errLog_path))
            {
                //StreamWriter s1 = System.IO.File.AppendText(errLog_path);
                StreamWriter s1 = new StreamWriter(errLog_path, true, Encoding.Default);
                s1.WriteLine("[时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + MessageLog);
                s1.Close();
                s1.Dispose();
            }
            else
            {
                StreamWriter r1 = new StreamWriter(errLog_path, false, Encoding.Default);
                //System.IO.TextWriter r1 = System.IO.File.CreateText(errLog_path);
                r1.WriteLine("[时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + MessageLog);
                r1.Close();
                r1.Dispose();
            }
        }
        /// <summary>
        /// 源目录，目标目录，和文件与源目录的相对路径
        /// </summary>
        /// <param name="destpath">目录路径</param>
        /// <param name="sourcepath">源路径</param>
        /// <param name="relativeName">相对文件名</param>
        /// <returns></returns>
        public static bool CopyFile(string destpath, string sourcepath)
        {
            FileInfo sourcefile = new FileInfo(sourcepath);
            if (!sourcefile.Exists)
                return false;
            sourcefile.Attributes = FileAttributes.Archive;
            FileInfo destfile = new FileInfo(destpath);
            if (!destfile.Directory.Exists)
                destfile.Directory.Create();
            try
            {
                sourcefile.CopyTo(destpath, true);
            }
            catch (FileLoadException ex)
            {
                return false;
            }
            return true;
        }
        private static readonly Char[] filter = new char[] { '\\', '*', '\'', '[', ']' };
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
            string str = "";
            for (int i = 0; i < filter.Length; i++)
            {
                str += " " + filter[i];
            }
            return str.Trim(' ');
        }

        /// <summary>
        /// 添加原文相关信息
        /// </summary>
        /// <param name="eFileID">电子文件表主键</param>
        /// <param name="projNo">工程编号</param>
        /// <param name="createUser">创建人</param>
        /// <param name="operationType">操作类型</param>
        /// <param name="fullFilePath">文件路径,包括文件名 eg: d://a/a.cll</param>
        public static void InsertOldEfile(string eFileID, string projNo, string createUser,
            string operationType, string fullFilePath)
        {
            if (File.Exists(fullFilePath))
            {
                T_YW_CellAndEFile_BLL bll = new T_YW_CellAndEFile_BLL();
                T_YW_CellAndEFile mdl = new T_YW_CellAndEFile();
                mdl.ProjectNO = projNo;
                mdl.CreateUser = createUser;
                mdl.OperationType = operationType;
                mdl.CellID = eFileID;//原文存入是为了当电子文件删除时,原文信息会随之删除 根据电子文件ID 和工程编号
                mdl.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string fileName = fullFilePath.Substring(fullFilePath.LastIndexOf("\\") + 1);
                mdl.FileName = fileName;
                mdl.FileFormat = fileName.Substring(fileName.LastIndexOf("."));
                bll.Insert(mdl);
            }
        }

        /// <summary>
        /// 删除电子文件对应的原文信息
        /// </summary>
        /// <param name="eFileID"></param>
        /// <param name="projNo"></param>
        public static void DeleteOldEfile(string eFileID, string projNo)
        {
            T_YW_CellAndEFile_BLL bll = new T_YW_CellAndEFile_BLL();
            T_YW_CellAndEFile mdl = new T_YW_CellAndEFile();
            mdl.CellID = eFileID;
            mdl.ProjectNO = projNo;
            bll.Delete(mdl);
        }

        public static void DaoChuPrjectInfo(string projNo, string projName)
        {
            if (TXMessageBoxExtensions.Question("提示：确定导出：" + projName + " 项目信息吗？") == DialogResult.OK)
            {
                SaveFileDialog YJ_JAVA = new SaveFileDialog();
                YJ_JAVA.Title = "请选择:" + projName + ",资料的存放地址!";
                YJ_JAVA.FileName = projName + "(项目信息).zip";
                YJ_JAVA.Filter = "ZIP(项目信息文件) | *.zip";
                string filePath = "";
                if (YJ_JAVA.ShowDialog() == DialogResult.OK)
                {
                    filePath = YJ_JAVA.FileName;
                }
                else
                    return;

                XmlDocument To_JavaConStrProXml = new System.Xml.XmlDocument();
                XmlDeclaration decConStrPro = To_JavaConStrProXml.CreateXmlDeclaration("1.0", "UTF-8", null);
                To_JavaConStrProXml.AppendChild(decConStrPro);

                XmlElement rootConStrPro = To_JavaConStrProXml.CreateElement("information");
                To_JavaConStrProXml.AppendChild(rootConStrPro);

                XmlElement projBaseInfoXML = To_JavaConStrProXml.CreateElement("projBaseInfo");
                rootConStrPro.AppendChild(projBaseInfoXML);

                IProjectXML projectXML = new ERM.UI.Common.XmlMapping.Item(new ProjectItemUnits(projNo));
                if (projectXML != null)
                {
                    projectXML.setXmlInfo(To_JavaConStrProXml, projBaseInfoXML, new T_Projects_BLL().Find(projNo));
                }

                ProjectItemUnits projectFactory = new ProjectItemUnits(projNo);//项目信息
                MDL.T_Projects project_MDL = (new BLL.T_Projects_BLL()).Find(projNo);//工程信息

                //xml 文件保存目录
                string tempPath = System.IO.Path.Combine(Application.StartupPath, "erm_yj");
                if (System.IO.Directory.Exists(tempPath))
                {
                    MyCommon.DeleteAndCreateEmptyDirectory(tempPath, true);
                }
                else
                {
                    MyCommon.DeleteAndCreateEmptyDirectory(tempPath, false);
                    MyCommon.DeleteAndCreateEmptyDirectory(tempPath, true);
                }

                To_JavaConStrProXml.Save(System.IO.Path.Combine(tempPath, "projInfo.xml"));
                SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
                SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
                tmp.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                tmp.CompressDirectory(tempPath, filePath);

                MyCommon.DeleteAndCreateEmptyDirectory(tempPath, false);
                MyCommon.DeleteAndCreateEmptyDirectory(tempPath, true);
                TXMessageBoxExtensions.Info("保存成功！");
            }
        }
        /// <summary>
        /// 通用创建XmlElement对象
        /// </summary>
        /// <param name="KeyName">KeyName</param>
        /// <param name="KeyValue">KeyValue</param>
        /// <param name="xDoc">XmlDocument对象</param>
        /// <param name="PElement">XmlElement父级对象</param>
        public static void CreateElement(string KeyName, string KeyValue,
            XmlDocument xDoc, XmlElement PElement)
        {
            XmlElement X_temp = xDoc.CreateElement(KeyName);
            X_temp.SetAttribute("value", KeyValue);
            PElement.AppendChild(X_temp);
        }

    }
    public class MyDateSorter : IComparer
    {
        #region IComparer Members
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = (FileInfo)x;
            FileInfo yInfo = (FileInfo)y;


            //依名稱排序   
            return xInfo.FullName.CompareTo(yInfo.FullName);//遞增   
            //return yInfo.FullName.CompareTo(xInfo.FullName);//遞減   

            //依修改日期排序   
            //return xInfo.LastWriteTime.CompareTo(yInfo.LastWriteTime);//遞增   
            //return yInfo.LastWriteTime.CompareTo(xInfo.LastWriteTime);//遞減   
        }
        #endregion
    }

    public class ConvertPdfFile
    {
        public String SourceFilePath { set; get; }
        public String PDFFilePath { set; get; }
    }
}
