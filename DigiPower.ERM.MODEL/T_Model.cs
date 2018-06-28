using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ERM.MDL
{
    /// <summary>
    /// 用于移交导出XML的模板列
    /// </summary>
    public class T_Model : DynamicObject
    {
    //    public T_Model() { }
    //    Dictionary<string, object> Properties = new Dictionary<string, object>();

    //    public override bool TrySetMember(SetMemberBinder binder, object value)
    //    {
    //        if (!Properties.Keys.Contains(binder.Name))
    //        {
    //            Properties.Add(binder.Name, value.ToString());
    //        }
    //        return true;
    //    }
    //    public override bool TryGetMember(GetMemberBinder binder, out object result)
    //    {
    //        return Properties.TryGetValue(binder.Name, out result);
    //    }
        /// <summary>
        /// 列名称
        /// </summary>
        public string Column { get; set; }
        /// <summary>
        /// 列别名
        /// </summary>
        public string MappColumn { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public string Display { get; set; }
        /// <summary>
        /// 是否为数据库取值
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 默认值 
        /// </summary>
        public string Default { get; set; }
    }
}
