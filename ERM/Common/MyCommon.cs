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
    /// ���������࣬��̬����
    /// </summary>
    public class MyCommon
    {
        /// <summary>
        /// �ж��Ƿ���������ַ�
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsMatchCode(string value)
        {
           // Regex regex = new Regex(@"[��������?~������'\""��������������]");
            Regex regex = new Regex(ConfigurationManager.AppSettings["isMatchCode"].ToString());
            if (regex.IsMatch(value))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// �ݹ�ɾ��Ŀ¼�����ļ����ļ���
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
            MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// ��ʾ������Ϣ��
        /// </summary>
        /// <param name="strMsg">��Ϣ</param>
        public static void ShowError(string strMsg)
        {
            MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// ��ʾYes,No,Cancel������ť
        /// </summary>
        /// <param name="strMsg"></param>
        public static DialogResult ShowYesNoCancel(string strMsg)
        {
            return MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
        /// <summary>
        /// ��ʾ��ʾ��Ϣ��
        /// </summary>
        /// <param name="strMsg">��Ϣ</param>
        public static void ShowInfo(string strMsg)
        {
            Show(strMsg);
        }
        public static void Show(string strMsg)
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
        /// ��ʾ�Ի���Ϣ�� ���þ���ͼ��
        /// </summary>
        /// <param name="strMsg">��Ϣ</param>
        public static DialogResult ShowQuestionWarning(string strMsg)
        {
            return MessageBox.Show(strMsg, Globals.PromptTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        /// <summary>
        /// ��ʾ��ʾ��
        /// </summary>
        /// <param name="prompt">����</param>
        /// <param name="title">����</param>
        /// <param name="defaultValue">Ĭ��ֵ</param>
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
        /// ת����SQL����е��ַ���
        /// </summary>
        /// <param name="str">�ִ�</param>
        public static string ToSqlString(string str)
        {
            return str.Trim().Replace("'", "''");
        }
        /// <summary>
        /// ���̹������չ��Ϣ�����,�����'�Ų��ø�
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSqlString2(string str)
        {
            return str.Trim().Replace("'", "");
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
        /// /���̹������õ����Ƿ�Ϊ������������ڵ���0
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
        /// ���̹������õ����жϣ�����������
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
        /// <summary>
        /// ������Tag�����л�ȡLastLeafֵ
        /// </summary>
        /// <param name="obj">Tag����</param>
        /// <returns>�Ƿ����һ���ڵ�</returns>
        public static int GetLastLeafFromTag(object obj)
        {
            string[] str = (string[])obj;
            return MyCommon.ToInt(str[0]);
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
        public static string GetTreePathFromTag(object obj)
        {
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
            return str[0];
        }
        public static string GetDocStatutsFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[1];
        }
        /// <summary>
        /// ������Tag�����л�ȡhasAttachֵ(CustomDefine��ʾ�ñ���Ƿ��и���)
        /// </summary>
        /// <param name="obj">Tag����</param>
        /// <returns>hasAttach(0-�� 1-��)</returns>
        public static int GethasAttachFromTag(object obj)
        {
            string[] str = (string[])obj;
            return MyCommon.ToInt(str[3]);
        }

        /// <summary>
        /// ����Tag�����л�ȡ�ӷֲ�����
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetZfbmcFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[3];
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
        public static string GetZrrFromTag(object obj)
        {
            string[] str = (string[])obj;
            return str[2];
        }
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
        public static int GetRGBFromColor(int r, int g, int b)
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
            if (System.IO.File.Exists(fullFilePath))
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
                o = "+" + o;//���Ҫ���ţ��Ҳ���Ϊ����
            Cell1.S(col2, row2, sheet, o);
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
        /// <summary>
        /// ��ȡ�����
        /// </summary>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <param name="outputInt">true����������false����С��</param>
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
        /// ȥ��·���е�[0],*
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
        /// ����Ŀ¼
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
                if (myProc.HasExited)//�ж��Ƿ����н���       
                    myProc.Kill();
            }
            catch { }
        }
        public static DataTable ToDataTable<T>(IList<T> entitys)
        {
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("��ת���ļ���Ϊ��");
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
                    throw new Exception("Ҫת���ļ���Ԫ�����Ͳ�һ��");
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
                throw new Exception("��ת���ļ���Ϊ��");
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
                    throw new Exception("Ҫת���ļ���Ԫ�����Ͳ�һ��");
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
        /// �ж��ļ���׺�Ƿ���ָ���ĺ�׺��ͬ
        /// </summary>
        /// <param name="filename">�ļ�·��������</param>
        /// <param name="suffixname">��׺���Σ����磺.doc,.cll,.excl��</param>
        /// <returns>bool:true��ͬ false��ͬ</returns>
        public static bool CheckFillSuffix(string filename, string suffixname)
        {
            System.IO.FileInfo f1 = new FileInfo(Globals.ProjectPath + filename);
            string filesuffix = f1.Extension;//��ȡ�ļ���׺
            if (filesuffix != null && string.Compare(filesuffix.ToLower(), suffixname.ToLower()) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region ϵͳȨ�޺�ҳ��һЩ���Ի���������Ϣ
        /// <summary>
        /// �ж�һ���˵���ʾ״̬����
        /// </summary>
        /// <param name="menu_flg">�жϱ�ǣ�1��Դ�ñ� 2�ļ��Ǽ� 3��� 4�����ƽ� 5������� 6����ɾ��</param>
        /// <returns>bool:true��ʾ false����</returns>
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
        /// ��⹤�̱�ź͹��������Ƿ���Ա༭
        /// </summary>
        /// <returns>bool:true���Ա༭ false���ɱ༭</returns>
        public static bool CheckProjectBind()
        {
            return string.Compare(Properties.Settings.Default.ProjectNameBind, Globals.IsOkGuid) == 0 ? true : false;
        }

        /// <summary>
        /// ���Ի���ʾ�󶨷���
        /// </summary>
        /// <param name="lbl_showLable">��ʾ��Lable�ؼ�����</param>
        /// <param name="lable_flg">
        ///  �󶨵�Text���ݱ�� 
        ///  0 ���̱��(������)
        ///  1 �����õ���׼���
        ///  2 �õع滮���֤��
        ///  3 ���̹滮���֤��
        ///  4 �õع滮���֤��
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
        /// ����Ƿ���ҪUkey
        /// </summary>
        /// <returns>bool: true��Ҫ false����Ҫ</returns>
        public static bool IsCheckFD()
        {
            return Properties.Settings.Default.fd == "f" ? true : false;
        }

        /// <summary>
        /// ��ȡĿ¼�������ļ�����
        /// </summary>
        /// <param name="sourceDirName">�ļ���·��</param>
        /// <param name="tempfileCount">ͳ���ļ���������ʱ����</param>
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
        /// ��ȡ�ļ�����
        /// </summary>
        /// <param name="sourceDirName">�ļ���·��</param>
        /// <param name="check_flg">�����״ֵ̬�� ����false ��ʾ�ļ����д��� </param>
        /// <param name="fileCount">�ļ�����</param>
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
                    MessageBox.Show("��ʾ���ļ���·������'" + sourceDirName + "' \n ����ܰ��ʾ���ļ�·�������ڻ��ļ���β�����ܰ��������ַ���ȫ���ַ� ���磺�ո�,�Ǻ�...��",
                        "��ܰ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// ��֤�Ƿ�Ϊ0��������
        /// </summary>
        /// <param name="num">����</param>
        /// <returns></returns>
        public static bool VldIntegerZ(string num)
        {
            string sPattern = @"^\d+$";
            return Regex.IsMatch(num, sPattern);
        }

        /// <summary>
        /// �жϹ��̱�Ÿ�ʽ ���֣���ĸ���»��ߣ�����
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static bool isYesProjectNo(string dateStr)
        {
            return Regex.IsMatch(dateStr, @"^[A-Za-z0-9_-]+$");
        }

        /// <summary>
        /// �ж��ϴ��ļ����͵� .*
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
        /// �жϵ�ǰǨ����ļ� ��ʲô���� 1 ��������  2���� 3��Ƭ����
        /// </summary>
        /// <param name="fileNode">Ŀ¼�ڵ�</param>
        /// <param name="efile_type">���ͱ�ǣ����Ĭ��ֵ1</param>
        public static void GetParentNodeType(TreeNode fileNode, ref int efile_type)
        {
            if (fileNode != null && fileNode.Parent != null && fileNode.Parent.ImageIndex == 1)
                GetParentNodeType(fileNode.Parent, ref efile_type);

            if (fileNode != null && fileNode.Parent != null && fileNode.Parent.Level == 0)
            {
                if (fileNode.Text.Trim().IndexOf("����") != -1)
                    efile_type = 2;
                else if (fileNode.Text.Trim().IndexOf("ͼ") != -1)
                    efile_type = 3;
            }
        }

        /// <summary>
        /// �жϵ�ǰǨ����ļ� ��ʲô���� 1 ��������  2���� 3��Ƭ����
        /// </summary>
        /// <param name="fileNode">�ļ�Ŀ¼ID</param>
        /// <param name="efile_type">���ͱ�ǣ����Ĭ��ֵ1</param>
        public static void GetParentNodeType(string fileID, ref int efile_type)
        {
            ERM.BLL.T_FileList_BLL file_bll = new ERM.BLL.T_FileList_BLL();
            ERM.MDL.T_FileList file_model = file_bll.Find(fileID, Globals.ProjectNO);
            if (file_model != null && file_model.ParentID != null && file_model.ParentID.Trim() != "")
                GetParentNodeType(file_model.ParentID, ref efile_type);

            if (file_model != null && file_model.ParentID != null && file_model.ParentID.Trim() == "")
            {
                if (file_model.gdwj.Trim().IndexOf("����") != -1)
                    efile_type = 2;
                else if (file_model.gdwj.Trim().IndexOf("ͼ") != -1)
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
            //string.Format("{0}  �ܿռ䣺{1} GB,ʣ��:{2} GB",
            //    hp_disk.PartitionName, hp_disk.ManagerDoubleValue(hp_disk.SumSpace, 1),
            //    hp_disk.ManagerDoubleValue(disk.FreeSpace, 1));
        }

        /// <summary>
        ///  ��־��¼�������������¼��
        /// </summary>
        /// <param name="MessageLog">��־��Ϣ</param>
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
                s1.WriteLine("[ʱ�䣺" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + MessageLog);
                s1.Close();
                s1.Dispose();
            }
            else
            {
                StreamWriter r1 = new StreamWriter(errLog_path, false, Encoding.Default);
                //System.IO.TextWriter r1 = System.IO.File.CreateText(errLog_path);
                r1.WriteLine("[ʱ�䣺" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + MessageLog);
                r1.Close();
                r1.Dispose();
            }
        }
        /// <summary>
        /// ԴĿ¼��Ŀ��Ŀ¼�����ļ���ԴĿ¼�����·��
        /// </summary>
        /// <param name="destpath">Ŀ¼·��</param>
        /// <param name="sourcepath">Դ·��</param>
        /// <param name="relativeName">����ļ���</param>
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
            string str = "";
            for (int i = 0; i < filter.Length; i++)
            {
                str += " " + filter[i];
            }
            return str.Trim(' ');
        }

        /// <summary>
        /// ���ԭ�������Ϣ
        /// </summary>
        /// <param name="eFileID">�����ļ�������</param>
        /// <param name="projNo">���̱��</param>
        /// <param name="createUser">������</param>
        /// <param name="operationType">��������</param>
        /// <param name="fullFilePath">�ļ�·��,�����ļ��� eg: d://a/a.cll</param>
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
                mdl.CellID = eFileID;//ԭ�Ĵ�����Ϊ�˵������ļ�ɾ��ʱ,ԭ����Ϣ����֮ɾ�� ���ݵ����ļ�ID �͹��̱��
                mdl.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string fileName = fullFilePath.Substring(fullFilePath.LastIndexOf("\\") + 1);
                mdl.FileName = fileName;
                mdl.FileFormat = fileName.Substring(fileName.LastIndexOf("."));
                bll.Insert(mdl);
            }
        }

        /// <summary>
        /// ɾ�������ļ���Ӧ��ԭ����Ϣ
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
            if (TXMessageBoxExtensions.Question("��ʾ��ȷ��������" + projName + " ��Ŀ��Ϣ��") == DialogResult.OK)
            {
                SaveFileDialog YJ_JAVA = new SaveFileDialog();
                YJ_JAVA.Title = "��ѡ��:" + projName + ",���ϵĴ�ŵ�ַ!";
                YJ_JAVA.FileName = projName + "(��Ŀ��Ϣ).zip";
                YJ_JAVA.Filter = "ZIP(��Ŀ��Ϣ�ļ�) | *.zip";
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

                ProjectItemUnits projectFactory = new ProjectItemUnits(projNo);//��Ŀ��Ϣ
                MDL.T_Projects project_MDL = (new BLL.T_Projects_BLL()).Find(projNo);//������Ϣ

                //xml �ļ�����Ŀ¼
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
                TXMessageBoxExtensions.Info("����ɹ���");
            }
        }
        /// <summary>
        /// ͨ�ô���XmlElement����
        /// </summary>
        /// <param name="KeyName">KeyName</param>
        /// <param name="KeyValue">KeyValue</param>
        /// <param name="xDoc">XmlDocument����</param>
        /// <param name="PElement">XmlElement��������</param>
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


            //�����Q����   
            return xInfo.FullName.CompareTo(yInfo.FullName);//�f��   
            //return yInfo.FullName.CompareTo(xInfo.FullName);//�f�p   

            //���޸���������   
            //return xInfo.LastWriteTime.CompareTo(yInfo.LastWriteTime);//�f��   
            //return yInfo.LastWriteTime.CompareTo(xInfo.LastWriteTime);//�f�p   
        }
        #endregion
    }

    public class ConvertPdfFile
    {
        public String SourceFilePath { set; get; }
        public String PDFFilePath { set; get; }
    }
}
