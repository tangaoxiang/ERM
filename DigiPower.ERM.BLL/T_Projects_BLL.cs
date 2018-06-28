using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_Projects_BLL : IBLL
    {
        public int GetCount()
        {
            String stmtId = "T_Projects.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }
        public T_Projects Find(String projectNO)
        {
            String stmtId = "T_Projects.Find";
            MDL.T_Projects obj = new T_Projects();
            obj.ProjectNO = projectNO;
            T_Projects result = MyISqlMap.QueryForObject<T_Projects>(stmtId, obj);
            return result;
        }
        public bool Exists(String projectNO)
        {
            String stmtId = "T_Projects.Exists";
            bool result = MyISqlMap.QueryForObject<bool>(stmtId, projectNO);
            return result;
        }
        public bool ExistsName(String projectName)
        {
            String stmtId = "T_Projects.ExistsName";
            bool result = MyISqlMap.QueryForObject<bool>(stmtId, projectName);
            return result;
        }
        public IList<T_Projects> GetAll()
        {
            String stmtId = "T_Projects.GetAll";
            IList<T_Projects> result = MyISqlMap.QueryForList<T_Projects>(stmtId, null);
            return result;
        }
        public void Insert(T_Projects obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Projects.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Update(T_Projects obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Projects.Update";
            MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(String projectNO)
        {
            if (projectNO == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Projects.Delete";
            T_Projects obj = new T_Projects();
            obj.ProjectNO = projectNO;
            MyISqlMap.Delete(stmtId, obj);
        }
        public bool Add(ERM.MDL.T_Projects model_Projects, ERM.MDL.T_Item itemMDL)
        {
            this.Insert(model_Projects);
            BLL.T_Item_BLL itemBLL = new ERM.BLL.T_Item_BLL();
            itemBLL.Add(itemMDL);
            return true;
        }
        public bool Update(ERM.MDL.T_Projects model_Projects, ERM.MDL.T_Item itemMDL)
        {
            BLL.T_Item_BLL itemBLL = new ERM.BLL.T_Item_BLL();
            itemMDL.ItemID = model_Projects.ItemID;
            itemBLL.Update(itemMDL);
            this.Update(model_Projects);
            return true;
        }
        public System.Data.DataSet GetListInfo(String projectNO)
        {
            String stmtId = "T_Projects.GetList";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, projectNO);
            return result;
        }
    }
}
