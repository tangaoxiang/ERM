using System;
using System.Collections.Generic;
using System.Text;

namespace Digi.B
{

    #region ImageLists ö����
    /// <summary>
    /// ImageListsö���࣬�������ϵ�ͼ��
    /// </summary>
    public class ImageLists
    {
        /// <summary>
        /// ö��
        /// </summary>
        private enum Images
        {
            Root, Folder, Table, Cell, CellLock, TableSelect
        }

        /// <summary>
        /// ���ڵ�(0)
        /// </summary>
        public static int Root
        {
            get { return (int)Images.Root; }
        }

        /// <summary>
        /// �ļ���(1)
        /// </summary>
        public static int Folder
        {
            get { return (int)Images.Folder; }
        }

        /// <summary>
        /// ģ��(2)
        /// </summary>
        public static int Table
        {
            get { return (int)Images.Table; }
        }


        /// <summary>
        /// δ��˵���ͨ���(3)
        /// </summary>
        public static int Cell
        {
            get { return (int)Images.Cell; }
        }


        /// <summary>
        /// ��˵ı��(4)
        /// </summary>
        public static int CellLock
        {
            get { return (int)Images.CellLock; }
        }


        /// <summary>
        /// ѡ�е�ģ��(5)
        /// </summary>
        public static int TableSelect
        {
            get { return (int)Images.TableSelect; }
        }
    }
    #endregion



    #region Themes ö����
    /// <summary>
    /// Themesö���࣬��ʽ
    /// </summary>
    public class Themes
    {
        /// <summary>
        /// ö��
        /// </summary>
        private enum ThemeCollection
        {
            XP = 1,Office003
        }

        /// <summary>
        /// XP���
        /// </summary>
        public static int XP
        {
            get { return (int)ThemeCollection.XP ; }

        }

        /// <summary>
        /// XP���
        /// </summary>
        public static int Office2003
        {
            get { return (int)ThemeCollection.Office003; }

        }
    }
    #endregion


    #region ����ѡ��ѡ�����
    /// <summary>
    /// ����ѡ��ѡ�����
    /// </summary>
    public class ItemObject
    {
        private string _name;
        private string _value1;
        private string _value2;
        private string _value3;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        public ItemObject(string name, string value1, string value2, string value3)
        {
            this._name = name;
            this._value1 = value1;
            this._value2 = value2;
            this._value3 = value3;
        }

        /// <summary>
        /// Name��
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
         }

        /// <summary>
         /// Value1
        /// </summary>
        public string Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }

        /// <summary>
        /// Value2
        /// </summary>
        public string Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }

        /// <summary>
        /// Value3
        /// </summary>
        public string Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
    }
    #endregion



    #region �ļ��Ǽ���ö��

    public enum RegistEnum
    {
        FULL,

        NOREGIST,

        NOATTACHMENT,

        NOPAPER,

        NOCHECK,

        ISPAPER
    }


    #endregion

}
