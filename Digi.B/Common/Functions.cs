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
    /// ���������࣬��̬����
    /// </summary>
    public class Functions
    {
        
        /// <summary>
        /// ��ȡMD5�ִ�
        /// </summary>
        /// <param name="normalString">δ�����ִ�</param>
        /// <returns></returns>
        public static string MD5String(string normalString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            string str = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(normalString)));
            str = str.Replace("-", "").ToUpper();
            return str;
        }

        /// <summary>
        /// ��ʾ������Ϣ��
        /// </summary>
        /// <param name="strMsg">��Ϣ</param>
        public static void ShowWarning(string strMsg)
        {
            MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// ��ʾ��ʾ��Ϣ��
        /// </summary>
        /// <param name="strMsg">��Ϣ</param>
        public static void ShowInfo(string strMsg)
        {
            MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ��ʾ�Ի���Ϣ��
        /// </summary>
        /// <param name="strMsg">��Ϣ</param>
        /// <returns>�Ի���ķ���ֵ</returns>
        public static DialogResult ShowQuestion(string strMsg)
        {
            return MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }


        /// <summary>
        /// ������Ի���
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowErrors(Exception ex)
        {
            string title = ex.Message;
            string description = ex.StackTrace.Trim();

            ShowErrors(title, description);
        }

        /// <summary>
        /// ������Ի���
        /// </summary>
        /// <param name="title">������ʾ��Ϣ</param>
        /// <param name="description">����ĳ�����Ϣ</param>
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
        /// ��ʾ��ʾ��
        /// </summary>
        /// <param name="prompt">����</param>
        /// <param name="title">����</param>
        /// <param name="defaultValue">Ĭ��ֵ</param>
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
        /// ת����SQL����е��ַ���
        /// </summary>
        /// <param name="str">�ִ�</param>
        public static string ToSqlString(string str)
        {
            return str.Trim().Replace("'", "''");
        }

        /// <summary>
        /// ת����SQL����е�����
        /// </summary>
        /// <param name="str">�ִ�</param>
        /// <returns></returns>
        public static string ToSqlNumber(string str)
        {
            if (IsNumeric(str.Trim()) == false)
                return "0";
            else
                return str.Trim();
        }

        /// <summary>
        /// SQL��������������ִ������ӷ�
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
        /// �ж�������Ƿ�������
        /// </summary>
        /// <param name="value"></param>
        /// <returns>bool true:�ǡ�false:��</returns>
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
        /// �ж�������Ƿ�����������
        /// </summary>
        /// <param name="value"></param>
        /// <returns>bool true:�ǡ�false:��</returns>
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
        /// �����ִ�Сд��Replace
        /// </summary>
        /// <param name="strSource">�������ַ���</param>
        /// <param name="strRe">Ҫ�滻���ַ���</param>
        /// <param name="strTo">�滻��</param>
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


        #region ȡnode�����tagֵ
        /// <summary>
        /// ������Tag�����л�ȡLastLeafֵ
        /// </summary>
        /// <param name="obj">Tag����</param>
        /// <returns>�Ƿ����һ���ڵ�</returns>
        public static int GetLastLeafFromTag(object obj)
        {
            string[] str = (string[])obj;
            return Convert.ToInt32(str[0]);
        }

        /// <summary>
        /// ������Tag�����л�ȡExamplePathֵ
        /// </summary>
        /// <param name="obj">Tag����</param>
        /// <returns>����·��</returns>
        public static string GetExamplePathFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[0];
        }

        /// <summary>
        /// ������Tag�����л�ȡExamplePathֵ
        /// </summary>
        /// <param name="obj">Tag����</param>
        /// <returns>����·��</returns>
        public static string GetCodeTypeFromTag(object obj) {
            string[] str = (string[])obj;
            return str[1];
        }

        /// <summary>
        /// ������Tag�����л�ȡExamplePathֵ
        /// </summary>
        /// <param name="obj">Tag����</param>
        /// <returns>����·��</returns>
        public static string GetZrrFromTag(object obj) {
            string[] str = (string[])obj;
            return str[2];
        }

        /// <summary>
        /// ������Tag�����л�ȡCustomDefineֵ(CustomDefine��ʾ�ñ���Ƿ����û��Խ��ı��)
        /// </summary>
        /// <param name="obj">Tag����</param>
        /// <returns>CustomDefine</returns>
        public static string GetCustomDefineFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[2];
        }

        /// <summary>
        /// ������Tag�����л�ȡhasAttachֵ(CustomDefine��ʾ�ñ���Ƿ��и���)
        /// </summary>
        /// <param name="obj">Tag����</param>
        /// <returns>hasAttach(0-�� 1-��)</returns>
        public static int GethasAttachFromTag(object obj)
        {
            string[] str = (string[])obj;
            return Convert.ToInt32(str[3]);
        }

        /// <summary>
        /// ������Tag�����л�ȡcellWBSֵ(cellWBS=1��ʾ�ñ�����ޱ�ʽ)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetcellWBSFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[4];
        }
        /// <summary>
        /// ����Tag�����л�ȡcodetypeֵ(�ڵ����ͷ���ֲ���ʩ������)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetcodetypeFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[1];
        }
        /// <summary>
        /// ����Tag�����л�ȡ�ֲ�����
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetFbmcFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[3];
        }
        /// <summary>
        /// ����Tag�����л�ȡ�ӷֲ�����
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetZfbmcFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[5];
        }
        /// <summary>
        /// ����Tag�����л�ȡ��������
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetFxmcFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[4];
        }

        /// <summary>
        /// ����Tag�����л�ȡ˳���
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetOrderIndexFromTag(object obj) {
            string[] str = (string[])obj;
            return str[6];
        }

        #endregion
        /// <summary>
        /// ����߻�ȡ�ַ���
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
        /// ���ɱ߻�ȡ�ַ���
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
        /// ��ȡ���ļ���
        /// </summary>
        /// <param name="fullFilePath">�ļ�������·��</param>
        /// <returns>���ļ���</returns>
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
        /// ��ȡû����չ���Ķ��ļ���
        /// </summary>
        /// <param name="fullFilePath">�ļ�������·��</param>
        /// <returns>���ļ���</returns>
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
        /// ��ȡ�ļ�����չ��
        /// </summary>
        /// <param name="fullFilePath">�ļ�������·��</param>
        /// <returns>��չ��������".")</returns>
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
        /// ����ɫת��Ϊ32bit RGBֵ:
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
        /// ����ɫת��Ϊ32bit RGBֵ:
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
        /// ���ֱȽϣ����ԭʼ�����а���Ҫ�Ƚϵ����ݣ����ȥ�Ժ󷵻أ�����Cell�ؼ���Ԫ���ֵ������
        /// </summary>
        /// <param name="orgVal">ԭʼ����</param>
        /// <param name="includeVal">��Ҫ�Ƚϵ�����</param>
        /// <returns></returns>
        public static int NumberMinus(int orgVal, int includeVal)
        {
            if ((orgVal & includeVal) == includeVal)
                return (orgVal - includeVal);
            else
                return orgVal;
           
        }






        /// <summary>
        /// ��16����ת�����ַ���
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
        /// Ӧ�ý�����ʽ
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
        /// ��ȡ�����������ַ���
        /// </summary>
        /// <returns></returns>
        public static string GetUnique()
        {
            Guid g = Guid.NewGuid();
            return g.ToString();
        }


        /// <summary>
        /// ����ת��Ϊ�����е������б�
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
        /// �򿪻�ִ��һ���ⲿ�ļ�
        /// </summary>
        /// <param name="fullFilePath">�������ļ�·��</param>
        public static void OpenDocument(string fullFilePath)
        {
            if (File.Exists(fullFilePath))
            {
                System.Diagnostics.Process.Start(fullFilePath);
            }
        }


        /// <summary>
        /// ���������ʽ�������㣬�������
        /// </summary>
        /// <param name="expression">���ʽ����"5>(1+3)"�򷵻�true</param>
        /// <returns>�������</returns>
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
        /// ����ֵ��������funcion�е�eval
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
        /// �ı�����ת�� xmlʱ�����ݹ���
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
        /// �Ƿ�Ϸ���IP��ַ
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
        /// ������
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="col2"></param>
        /// <param name="row2"></param>
        /// <param name="sheet"></param>
        /// <param name="Cell1"></param>
        public static void parse(string expression, int col2, int row2, int sheet, AxCELL50LibU.AxCell Cell1, int ws)
        {
            #region �����ַ���
            string str = expression.Replace("\r", "").Replace("\n", "").Replace(" ", "").ToLower();
            str = str.Replace("run{", "");
            str = str.Replace("}", "");
            str = str.Replace("break;", "#");

            //���Ϊ��
            if (str == "") return;

            //���ı��ʽ
            string newExpression = "";
            int col = 0;
            int row = 0;


            //��������
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


            //�������ʽ���н���
            string strMin = "";  //"��С"���ʽ
            string strMax = "";  //"���"���ʽ
            string strX = "";    //"����"���ʽ
            string strX1 = "";   //strX�ĺ�벿�֣�����Ԫ��
            string strXVal = ""; //��Ԫ���ֵ
            string strOther = ""; //��������

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
            //��x�滻Ϊֵ
            strMin = strMin.Replace("x", strXVal);
            strMax = strMax.Replace("x", strXVal);
            strOther = strOther.Replace("x", strXVal);

            //�����������max min otherֵ
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

            //�����
            string o = Rnd(Convert.ToDouble(min), Convert.ToDouble(max), ws);
            Cell1.S(col2, row2, sheet, o.ToString());

        }

        /// <summary>
        /// �������������ͬ���ã���ֹ�����Ľ����ͬ
        /// </summary>
        private static int roCount = 0;

        /// <summary>
        /// ��ȡ�����
        /// </summary>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <param name="outputInt">true����������false����С��</param>
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
