using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// ҵ���߼���wjssgclx ��ժҪ˵����
	/// </summary>
	public class wjssgclx
	{
		private readonly ERM.DAL.wjssgclx dal=new ERM.DAL.wjssgclx();
		public wjssgclx()
		{}
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id2)
		{
			return dal.Exists(id2);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ERM.MDL.wjssgclx model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ERM.MDL.wjssgclx model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id2)
		{
			dal.Delete(id2);
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ERM.MDL.wjssgclx Find(int id2)
		{
			return dal.Find(id2);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
		/// <summary>
		/// ��������б�
		/// </summary>
	}
}
