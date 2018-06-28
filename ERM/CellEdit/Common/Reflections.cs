using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;

namespace ERM.UI.Common
{
    public class Reflections
    {
        /// <summary>
        /// 控件赋值或取值
        /// </summary>
        /// <param name="controlName">控件命名规则前缀</param>
        /// <param name="type">反射类型</param>
        /// <param name="classModel">反射类型实例</param>
        /// <param name="flag">0：赋值，1：取值</param>
        /// <param name="collection">控件集合</param>
        public static object Control_Reflection(Type type, object classModel, System.Windows.Forms.Control.ControlCollection collection, string controlName = "txt_|cbo_", int flag = 0)
        {
            object model = new object();
            if (classModel != null)
            {
                Control[] c = new Control[] { };
                PropertyInfo[] properties = type.GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    string propertyID = properties[i].Name;
                    PropertyInfo pinfo = type.GetProperty(propertyID);
                    string[] cName = controlName.Split('|');

                    for (int k = 0; k < cName.Length; k++)
                    {
                        string ControlName = cName[k] + propertyID.ToLower();
                        c = collection.Find(ControlName, true);
                        if (c.Length > 0)
                        {
                            break;
                        }
                    }
                    object obj = pinfo.GetValue(classModel, null) == null ? "" : pinfo.GetValue(classModel, null);
                    string Value = obj == null ? "" : obj.ToString();

                    if (c.Length > 0)
                    {
                        Type t = c[0].GetType();
                        switch (t.Name)
                        {
                            case "TextBox":
                                if (flag == 0)
                                {
                                    (c[0] as TextBox).Text = Value;
                                }
                                else
                                {
                                    pinfo.SetValue(classModel, (c[0] as TextBox).Text, null);
                                }
                                break;
                            case "TXTextBox":
                                if (flag == 0)
                                {
                                    (c[0] as TXTextBox).Text = Value;
                                }
                                else
                                {
                                    pinfo.SetValue(classModel, (c[0] as TXTextBox).Text, null);
                                }
                                break;
                            case "MaskedTextBox":
                                if (flag == 0)
                                {
                                    (c[0] as MaskedTextBox).Text = Value;
                                }
                                else
                                {
                                    pinfo.SetValue(classModel, (c[0] as MaskedTextBox).Text, null);
                                }
                                break;
                            case "NumberTextBox":
                                if (flag == 0)
                                {
                                    (c[0] as MaskedTextBox).Text = Value;
                                }
                                else
                                {
                                    object controlValue = (c[0] as MaskedTextBox).Text;
                                    switch (pinfo.PropertyType.Name)
                                    {
                                        case "String": controlValue = controlValue.ToString(); break;
                                        case "Int32": controlValue = (controlValue == null || controlValue.ToString() == "") ? 0 : Convert.ToInt32(controlValue); break;
                                        case "Double": controlValue = controlValue == null || controlValue.ToString() == "" ? 0.00 : Convert.ToDouble(controlValue); break;
                                        case "Nullable`1": controlValue = controlValue == null || controlValue.ToString() == "" ? 0.00 : Convert.ToDouble(controlValue); break;
                                    }
                                    pinfo.SetValue(classModel, controlValue, null);
                                }
                                break;
                            case "ComboBox":
                                if (flag == 0)
                                {
                                    (c[0] as ComboBox).SelectedValue = Value;
                                }
                                else
                                {
                                    pinfo.SetValue(classModel, (c[0] as ComboBox).SelectedValue == null ? "" : (c[0] as ComboBox).SelectedValue.ToString(), null);
                                }
                                break;
                            case "ComboBoxEx":
                                if (flag == 0)
                                {
                                    (c[0] as ComboBoxEx).SelectedValue = Value;
                                }
                                else
                                {
                                    pinfo.SetValue(classModel, (c[0] as ComboBoxEx).SelectedValue == null ? "" : (c[0] as ComboBoxEx).SelectedValue.ToString(), null);
                                }
                                break;
                            case "TXComboBox":
                                if (flag == 0)
                                {
                                    (c[0] as TXComboBox).SelectedValue = Value;
                                }
                                else
                                {
                                    pinfo.SetValue(classModel, (c[0] as TXComboBox).SelectedValue == null ? "" : (c[0] as ComboBoxEx).SelectedValue.ToString(), null);
                                }
                                break;
                            case "DateTimePicker":
                                if (flag == 0)
                                {
                                    (c[0] as DateTimePicker).Text = Value;
                                }
                                else
                                {
                                    pinfo.SetValue(classModel, (c[0] as DateTimePicker).Text, null);
                                }
                                break;
                            case "DateTimeEx":
                                if (flag == 0)
                                {
                                    (c[0] as DateTimeEx).TextEx = Value;
                                }
                                else
                                {
                                    pinfo.SetValue(classModel, (c[0] as DateTimeEx).TextEx, null);
                                }
                                break;
                        }
                    }
                    model = classModel;
                }
            }
            return model;
        }

        /// <summary>
        /// 反射指定类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object obj_Reflections(Type type, object classModel)
        {
            object obj = null;
            //PropertyInfo[] properties = type.GetProperties();
            //for (int i = 0; i < properties.Length; i++)
            //{
            //    string propertyID = properties[i].Name;
            //    PropertyInfo pinfo = type.GetProperty(propertyID);
            //    obj = pinfo.GetValue(classModel, null) == null ? "" : pinfo.GetValue(classModel, null);
            //}
            return obj;
        }
    }
}
