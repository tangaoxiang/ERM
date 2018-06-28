using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Configuration;


namespace Digi.B
{
    /// <summary>
    /// 公共函数类，静态访问
    /// </summary>
    public class Functions
    {
        
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
            MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示提示消息框
        /// </summary>
        /// <param name="strMsg">消息</param>
        public static void ShowInfo(string strMsg)
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
        /// 出错处理对话框
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowErrors(Exception ex)
        {
            string title = ex.Message;
            string description = ex.StackTrace.Trim();

            ShowErrors(title, description);
        }

        /// <summary>
        /// 出错处理对话框
        /// </summary>
        /// <param name="title">出错提示信息</param>
        /// <param name="description">具体的出错信息</param>
        public static void ShowErrors(string title, string description)
        {

            //frmErrInfo ErrorInfo = new frmErrInfo(title, title + "\r\n" + description);
            //ErrorInfo.ShowDialog();

            //System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(true);
            //MessageBox.Show(trace.GetFrame(0).GetFileName());
            //MessageBox.Show(trace.GetFrame(0).GetMethod().Name);
            //MessageBox.Show("Line: " + trace.GetFrame(0).GetFileLineNumber());
            //MessageBox.Show("Column: " + trace.GetFrame(0).GetFileColumnNumber());
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="prompt">标题</param>
        /// <param name="title">描述</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string ShowInputBox(string prompt,string title, string defaultValue)
        {
            InputBoxDialog ib = new InputBoxDialog();
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

            //return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
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

            //return Regex.IsMatch(value, @"^[+-]?\d*$");
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


        #region 取node上面的tag值
        /// <summary>
        /// 从树的Tag对象中获取LastLeaf值
        /// </summary>
        /// <param name="obj">Tag对象</param>
        /// <returns>是否最后一个节点</returns>
        public static int GetLastLeafFromTag(object obj)
        {
            string[] str = (string[])obj;
            return Convert.ToInt32(str[0]);
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

        /// <summary>
        /// 从树的Tag对象中获取ExamplePath值
        /// </summary>
        /// <param name="obj">Tag对象</param>
        /// <returns>范例路径</returns>
        public static string GetCodeTypeFromTag(object obj) {
            string[] str = (string[])obj;
            return str[1];
        }

        /// <summary>
        /// 从树的Tag对象中获取ExamplePath值
        /// </summary>
        /// <param name="obj">Tag对象</param>
        /// <returns>范例路径</returns>
        public static string GetZrrFromTag(object obj) {
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
            return str[2];
        }

        /// <summary>
        /// 从树的Tag对象中获取hasAttach值(CustomDefine表示该表格是否有附件)
        /// </summary>
        /// <param name="obj">Tag对象</param>
        /// <returns>hasAttach(0-无 1-有)</returns>
        public static int GethasAttachFromTag(object obj)
        {
            string[] str = (string[])obj;
            return Convert.ToInt32(str[3]);
        }

        /// <summary>
        /// 从树的Tag对象中获取cellWBS值(cellWBS=1表示该表格是无表式)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetcellWBSFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[4];
        }
        /// <summary>
        /// 从树Tag对象中获取codetype值(节点类型分项、分部、施工表……)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetcodetypeFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[1];
        }
        /// <summary>
        /// 从树Tag对象中获取分部名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetFbmcFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[3];
        }
        /// <summary>
        /// 从树Tag对象中获取子分部名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetZfbmcFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[5];
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

        /// <summary>
        /// 从树Tag对象中获取顺序号
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetOrderIndexFromTag(object obj) {
            string[] str = (string[])obj;
            return str[6];
        }

        #endregion
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
        public static int GetRGBFromColor(int r,int g, int b)
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
            if (File.Exists(fullFilePath))
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
        public static void parse(string expression, int col2, int row2, int sheet, AxCELL50LibU.AxCell Cell1, int ws)
        {
            #region 解析字符串
            string str = expression.Replace("\r", "").Replace("\n", "").Replace(" ", "").ToLower();
            str = str.Replace("run{", "");
            str = str.Replace("}", "");
            str = str.Replace("break;", "#");

            //如果为空
            if (str == "") return;

            //最后的表达式
            string newExpression = "";
            int col = 0;
            int row = 0;


            //条件数组
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


            //对最后表达式进行解析
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
                        strXVal = "0";
                }
            }
            #endregion
            //将x替换为值
            strMin = strMin.Replace("x", strXVal);
            strMax = strMax.Replace("x", strXVal);
            strOther = strOther.Replace("x", strXVal);

            //计算出真正的max min other值
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
                max = Convert.ToDouble( min) * 1.1;
            }

            if (min == null)
            {
                min = Convert.ToDouble( max)*0.9;
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

            //随机数
            string o = Rnd(Convert.ToDouble(min), Convert.ToDouble(max), ws);
            Cell1.S(col2, row2, sheet, o.ToString());

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

    }
}
