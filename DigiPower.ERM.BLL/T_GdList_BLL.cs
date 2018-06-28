using ERM.MDL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERM.BLL
{
     public class T_GdList_BLL : IBLL
    {
        public int GetCount()
        {
            String stmtId = "T_GdList.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }
        public MDL.T_GdList FindID(String ID)
        {
            String stmtId = "T_GdList.FindID";
            MDL.T_GdList temp_MDL = new MDL.T_GdList();
            temp_MDL.ID = ID;
            MDL.T_GdList result = MyISqlMap.QueryForObject<MDL.T_GdList>(stmtId, temp_MDL);
            return result;
        }
        public MDL.T_GdList FindIDAndProjectNo(String ID,string ProjectNo)
        {
            String stmtId = "T_GdList.FindIDAndProjectNo";
            MDL.T_GdList temp_MDL = new MDL.T_GdList();
            temp_MDL.ID = ID;
            temp_MDL.ProjectNo = ProjectNo;
            MDL.T_GdList result = MyISqlMap.QueryForObject<MDL.T_GdList>(stmtId, temp_MDL);
            return result;
        }
        public IList<MDL.T_GdList> GetAll()
        {
            String stmtId = "T_GdList.GetAll";
            IList<MDL.T_GdList> result = MyISqlMap.QueryForList<MDL.T_GdList>(stmtId, null);
            return result;
        }

        public IList<MDL.T_GdList> FindByProjectNo(string ProjectNo)
        {
            String stmtId = "T_GdList.FindByProjectNo";
            MDL.T_GdList obj = new MDL.T_GdList();
            obj.ProjectNo = ProjectNo;

            T_Projects_BLL BLL = new T_Projects_BLL();
            IList<MDL.T_GdList> result = MyISqlMap.QueryForList<MDL.T_GdList>(stmtId, obj);
            return result;
        }

        public void Insert(MDL.T_GdList obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_GdList.Insert";

            obj.ProjectCategory = new T_Projects_BLL().Find(obj.ProjectNo).ProjectCategory;

            MyISqlMap.Insert(stmtId, obj);
        }
        public void Update(MDL.T_GdList obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_GdList.Update";
            MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(String ID)
        {
            if (ID == null) throw new ArgumentNullException("obj");
            String stmtId = "T_GdList.Delete";
            MDL.T_GdList obj = new MDL.T_GdList();
            obj.ID = ID;
            MyISqlMap.Delete(stmtId, obj);
        }
        public int GetMaxTemplateOrderIndex(string ProjectNo)
        {
            MDL.T_GdList obj = new MDL.T_GdList();
            String stmtId = "T_GdList.GetMaxTemplateOrderIndex";
            obj.ProjectNo = ProjectNo;
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }
    }
}
