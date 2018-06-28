using System;
using System.Collections.Generic;
using System.Text;

namespace Digi.B
{

    #region ImageLists 枚举类
    /// <summary>
    /// ImageLists枚举类，用于树上的图标
    /// </summary>
    public class ImageLists
    {
        /// <summary>
        /// 枚举
        /// </summary>
        private enum Images
        {
            Root, Folder, Table, Cell, CellLock, TableSelect
        }

        /// <summary>
        /// 根节点(0)
        /// </summary>
        public static int Root
        {
            get { return (int)Images.Root; }
        }

        /// <summary>
        /// 文件夹(1)
        /// </summary>
        public static int Folder
        {
            get { return (int)Images.Folder; }
        }

        /// <summary>
        /// 模板(2)
        /// </summary>
        public static int Table
        {
            get { return (int)Images.Table; }
        }


        /// <summary>
        /// 未审核的普通表格(3)
        /// </summary>
        public static int Cell
        {
            get { return (int)Images.Cell; }
        }


        /// <summary>
        /// 审核的表格(4)
        /// </summary>
        public static int CellLock
        {
            get { return (int)Images.CellLock; }
        }


        /// <summary>
        /// 选中的模板(5)
        /// </summary>
        public static int TableSelect
        {
            get { return (int)Images.TableSelect; }
        }
    }
    #endregion



    #region Themes 枚举类
    /// <summary>
    /// Themes枚举类，样式
    /// </summary>
    public class Themes
    {
        /// <summary>
        /// 枚举
        /// </summary>
        private enum ThemeCollection
        {
            XP = 1,Office003
        }

        /// <summary>
        /// XP风格
        /// </summary>
        public static int XP
        {
            get { return (int)ThemeCollection.XP ; }

        }

        /// <summary>
        /// XP风格
        /// </summary>
        public static int Office2003
        {
            get { return (int)ThemeCollection.Office003; }

        }
    }
    #endregion


    #region 下拉选单选项管理
    /// <summary>
    /// 下拉选单选项管理
    /// </summary>
    public class ItemObject
    {
        private string _name;
        private string _value1;
        private string _value2;
        private string _value3;

        /// <summary>
        /// 构造函数
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
        /// Name项
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



    #region 文件登记树枚举

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
