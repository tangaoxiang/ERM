using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类wjssgclx 的摘要说明。
	/// </summary>
	public class wjssgclx
	{
		private readonly ERM.DAL.wjssgclx dal=new ERM.DAL.wjssgclx();
		public wjssgclx()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id2)
		{
			return dal.Exists(id2);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.wjssgclx model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.wjssgclx model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id2)
		{
			dal.Delete(id2);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.wjssgclx Find(int id2)
		{
			return dal.Find(id2);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
	}
}
