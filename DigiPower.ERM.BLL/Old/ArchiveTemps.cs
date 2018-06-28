using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// ҵ���߼���ArchiveTemps ��ժҪ˵����
	/// </summary>
	public class ArchiveTemps
	{
		private readonly ERM.DAL.ArchiveTemps dal=new ERM.DAL.ArchiveTemps();
		public ArchiveTemps()
		{}
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int tempid)
		{
			return dal.Exists(tempid);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ERM.MDL.ArchiveTemps model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ERM.MDL.ArchiveTemps model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int tempid)
		{
			dal.Delete(tempid);
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ERM.MDL.ArchiveTemps Find(int tempid)
		{
			return dal.Find(tempid);
		}
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ERM.MDL.ArchiveTemps GetModelByCache(int tempid)
		{
			string CacheKey = "ArchiveTempsModel-" + tempid;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.Find(tempid);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.ArchiveTemps)objModel;
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
		public List<ERM.MDL.ArchiveTemps> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.ArchiveTemps> modelList = new List<ERM.MDL.ArchiveTemps>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.ArchiveTemps model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.ArchiveTemps();
					model.Cell_Templet_Name=ds.Tables[0].Rows[n]["Cell_Templet_Name"].ToString();
					model.Cell_Templet_Table=ds.Tables[0].Rows[n]["Cell_Templet_Table"].ToString();
					model.fileRecording_Templet_Table=ds.Tables[0].Rows[n]["fileRecording_Templet_Table"].ToString();
					if(ds.Tables[0].Rows[n]["isDefault"].ToString()!="")
					{
						model.isDefault=int.Parse(ds.Tables[0].Rows[n]["isDefault"].ToString());
					}
					if(ds.Tables[0].Rows[n]["orderindex"].ToString()!="")
					{
						model.orderindex=int.Parse(ds.Tables[0].Rows[n]["orderindex"].ToString());
					}
					model.Recording_Templet_Name=ds.Tables[0].Rows[n]["Recording_Templet_Name"].ToString();
					if(ds.Tables[0].Rows[n]["tempid"].ToString()!="")
					{
						model.tempid=int.Parse(ds.Tables[0].Rows[n]["tempid"].ToString());
					}
					model.UserTitle=ds.Tables[0].Rows[n]["UserTitle"].ToString();
					if(ds.Tables[0].Rows[n]["visible"].ToString()!="")
					{
						model.visible=int.Parse(ds.Tables[0].Rows[n]["visible"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
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
