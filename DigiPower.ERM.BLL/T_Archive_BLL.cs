using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_Archive_BLL : IBLL
    {
        public int GetCount()
        {
            String stmtId = "T_Archive.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }
        public T_Archive Find(String archiveID)
        {
            String stmtId = "T_Archive.Find";
            T_Archive result = MyISqlMap.QueryForObject<T_Archive>(stmtId, archiveID);
            return result;
        }
        public System.Data.DataSet GetList(T_Archive obj)
        {
            String stmtId = "T_Archive.GetList";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
            return result;
        }
        public System.Data.DataSet GetListByArchiveID(string archiveID)
        {
            String stmtId = "T_Archive.GetListByArchiveID";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, archiveID);
            return result;
        }
        public System.Data.DataSet GetList(String strWhere)
        {
            String stmtId = "T_Archive.GetList";
            if (strWhere == null || strWhere == "" || strWhere == "1=1")
            {
                strWhere = null;
                stmtId = "T_Archive.GetAll";
            }
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, strWhere);
            return result;
        }
        public bool Exists(String archiveID)
        {
            String stmtId = "T_Archive.Exists";
            bool result = MyISqlMap.QueryForObject<bool>(stmtId, archiveID);
            return result;
        }
        public IList<T_Archive> GetAll()
        {
            String stmtId = "T_Archive.GetAll";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, null);
            return result;
        }
        public IList<T_Archive> FindByProjectNO(String projectNO)
        {
            String stmtId = "T_Archive.FindByProjectNO";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, projectNO);
            return result;
        }
        public System.Data.DataSet FindByProjectNO2(String projectNO)
        {
            String stmtId = "T_Archive.FindByProjectNO2";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, projectNO);
            return result;
        }
        public IList<T_Archive> FindBydh(String dh)
        {
            String stmtId = "T_Archive.FindBydh";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, dh);
            return result;
        }
        public IList<T_Archive> FindByajtm(String ajtm)
        {
            String stmtId = "T_Archive.FindByajtm";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, ajtm);
            return result;
        }
        public IList<T_Archive> FindBybzdw(String bzdw)
        {
            String stmtId = "T_Archive.FindBybzdw";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, bzdw);
            return result;
        }
        public IList<T_Archive> FindBysl(String sl)
        {
            String stmtId = "T_Archive.FindBysl";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, sl);
            return result;
        }
        public IList<T_Archive> FindBydw(String dw)
        {
            String stmtId = "T_Archive.FindBydw";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, dw);
            return result;
        }
        public IList<T_Archive> FindByysfw(String ysfw)
        {
            String stmtId = "T_Archive.FindByysfw";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, ysfw);
            return result;
        }
        public IList<T_Archive> FindBybgqx(String bgqx)
        {
            String stmtId = "T_Archive.FindBybgqx";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, bgqx);
            return result;
        }
        public IList<T_Archive> FindBymj(String mj)
        {
            String stmtId = "T_Archive.FindBymj";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, mj);
            return result;
        }
        public IList<T_Archive> FindByljr(String ljr)
        {
            String stmtId = "T_Archive.FindByljr";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, ljr);
            return result;
        }
        public IList<T_Archive> FindBybzrq(String bzrq)
        {
            String stmtId = "T_Archive.FindBybzrq";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, bzrq);
            return result;
        }
        public IList<T_Archive> FindByajlx(String ajlx)
        {
            String stmtId = "T_Archive.FindByajlx";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, ajlx);
            return result;
        }
        public IList<T_Archive> FindBywzz(String wzz)
        {
            String stmtId = "T_Archive.FindBywzz";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, wzz);
            return result;
        }
        public IList<T_Archive> FindBytzz(String tzz)
        {
            String stmtId = "T_Archive.FindBytzz";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, tzz);
            return result;
        }
        public IList<T_Archive> FindBydtz(String dtz)
        {
            String stmtId = "T_Archive.FindBydtz";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, dtz);
            return result;
        }
        public IList<T_Archive> FindByzpz(String zpz)
        {
            String stmtId = "T_Archive.FindByzpz";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, zpz);
            return result;
        }
        public IList<T_Archive> FindBydpz(String dpz)
        {
            String stmtId = "T_Archive.FindBydpz";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, dpz);
            return result;
        }
        public IList<T_Archive> FindBylydh(String lydh)
        {
            String stmtId = "T_Archive.FindBylydh";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, lydh);
            return result;
        }
        public IList<T_Archive> FindBylxdh(String lxdh)
        {
            String stmtId = "T_Archive.FindBylxdh";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, lxdh);
            return result;
        }
        public IList<T_Archive> FindBygpz(String gpz)
        {
            String stmtId = "T_Archive.FindBygpz";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, gpz);
            return result;
        }
        public IList<T_Archive> FindBycdh(String cdh)
        {
            String stmtId = "T_Archive.FindBycdh";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, cdh);
            return result;
        }
        public IList<T_Archive> FindBycpz(String cpz)
        {
            String stmtId = "T_Archive.FindBycpz";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, cpz);
            return result;
        }
        public IList<T_Archive> FindByp(String p)
        {
            String stmtId = "T_Archive.FindByp";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, p);
            return result;
        }
        public IList<T_Archive> FindByz(String z)
        {
            String stmtId = "T_Archive.FindByz";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, z);
            return result;
        }
        public IList<T_Archive> FindByqt(String qt)
        {
            String stmtId = "T_Archive.FindByqt";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, qt);
            return result;
        }
        public IList<T_Archive> FindBybz(String bz)
        {
            String stmtId = "T_Archive.FindBybz";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, bz);
            return result;
        }
        public IList<T_Archive> FindByajs(String ajs)
        {
            String stmtId = "T_Archive.FindByajs";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, ajs);
            return result;
        }
        public IList<T_Archive> FindByswp(String swp)
        {
            String stmtId = "T_Archive.FindByswp";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, swp);
            return result;
        }
        public IList<T_Archive> FindByjhlx(String jhlx)
        {
            String stmtId = "T_Archive.FindByjhlx";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, jhlx);
            return result;
        }
        public IList<T_Archive> FindByOrderIndex(Int32? orderIndex)
        {
            String stmtId = "T_Archive.FindByOrderIndex";
            IList<T_Archive> result = MyISqlMap.QueryForList<T_Archive>(stmtId, orderIndex);
            return result;
        }
        public void Insert(T_Archive obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Archive.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Add(T_Archive obj)
        {
            Insert(obj);
        }
        public void Update(T_Archive obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Archive.Update";
            MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(T_Archive obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Archive.Delete";
            MyISqlMap.Delete(stmtId, obj);
        }
        public void Delete(String archiveID)
        {
            if (archiveID == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Archive.Delete";
            T_Archive obj = new T_Archive();
            obj.ArchiveID = archiveID;
            MyISqlMap.Delete(stmtId, obj);
        }
        public int GetMaxOrderIndex(string ProjectNO)
        {
            String stmtId = "T_Archive.GetMaxOrderIndex";
            MDL.T_Archive obj = new T_Archive();
            obj.ProjectNO = ProjectNO;
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }


        /// <summary>
        /// 更新案卷下的文字页数
        /// </summary>
        /// <param name="ProjectNO"></param>
        /// <param name="ArchiveID"></param>
        /// <returns></returns>
        public void UpdateArchiveTextNums(T_Archive obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");

            T_FileList_BLL fileListBLL = new T_FileList_BLL();
            obj.wzz = fileListBLL.GetWzCount(obj.ArchiveID, obj.ProjectNO).ToString();  
                        
            String stmtId = "T_Archive.Update";
            MyISqlMap.Update(stmtId, obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateByBK(T_Archive obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            obj.ljrq = DateTime.Now.Date.ToString("yyyy.MM.dd");
            String stmtId = "T_Archive.UpdateByBK";
            MyISqlMap.Update(stmtId, obj);
        }
    }
}
