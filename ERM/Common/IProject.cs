using ERM.MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace ERM.UI.Controls
{
    /// <summary>
    /// 用户控件对象接口
    /// </summary>
    public interface IProject
    {
        /// <summary>
        /// 获取或设置控件需要显示的信息
        /// </summary>
        /// <param name="where">查询条件，可选</param>
        /// <param name="objModel">查询模型，可选</param>
        /// <returns>查询结果对象</returns>
        Object GetInfo(string where="",object objModel=null,int flag=0);
        /// <summary>
        /// 新增对象
        /// </summary>
        /// <param name="ProjectModel">工程实体</param>
        /// <param name="ItemModel">项目实体</param>
        /// <param name="Model">用户控件扩展实体</param>
        /// <returns></returns>
        bool Add(T_Projects ProjectModel, T_Item ItemModel,object Model=null);
       /// <summary>
       ///  更新对象
       /// </summary>
        /// <param name="ProjectModel"></param>
        /// <param name="ItemModel"></param>
        /// <param name="Model">用户控件扩展实体</param>
       /// <returns></returns>
        bool Updates(T_Projects ProjectModel, T_Item ItemModel, object Model = null);
    }
}
