using System;
using System.Collections.Generic;
using System.Text;

namespace ERM.BLL
{
    public class T_GdListTemplate_BLL : IBLL
    {
        public int GetCount()
        {
            String stmtId = "T_GdListTemplate.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }
        public MDL.T_GdListTemplate FindID(String ID)
        {
            String stmtId = "T_GdListTemplate.FindID";
            MDL.T_GdListTemplate temp_MDL = new MDL.T_GdListTemplate();
            temp_MDL.ID = ID;
            MDL.T_GdListTemplate result = MyISqlMap.QueryForObject<MDL.T_GdListTemplate>(stmtId, temp_MDL);
            return result;
        }
        public IList<MDL.T_GdListTemplate> GetAll()
        {
            String stmtId = "T_GdListTemplate.GetAll";
            IList<MDL.T_GdListTemplate> result = MyISqlMap.QueryForList<MDL.T_GdListTemplate>(stmtId, null);
            return result;
        }

        public IList<MDL.T_GdListTemplate> GetAllByCategory(MDL.T_GdListTemplate obj)
        {
            String stmtId = "T_GdListTemplate.GetAllByCategory";
            IList<MDL.T_GdListTemplate> result = MyISqlMap.QueryForList<MDL.T_GdListTemplate>(stmtId, obj);
            return result;
        }

        public void Insert(MDL.T_GdListTemplate obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_GdListTemplate.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Update(MDL.T_GdListTemplate obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_GdListTemplate.Update";
            MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(String ID)
        {
            if (ID == null) throw new ArgumentNullException("obj");
            String stmtId = "T_GdListTemplate.Delete";
            MDL.T_GdListTemplate obj = new MDL.T_GdListTemplate();
            obj.ID = ID;
            MyISqlMap.Delete(stmtId, obj);
        }

        public string FindOrderIndex(int OrderIndex)
        {
            String stmtId = "T_GdListTemplate.FindOrderIndex";
            MDL.T_GdListTemplate temp_MDL = new MDL.T_GdListTemplate();
            temp_MDL.OrderIndex = OrderIndex;
            MDL.T_GdListTemplate result = MyISqlMap.QueryForObject<MDL.T_GdListTemplate>(stmtId, temp_MDL);
            if (result != null)
            {
                return result.ID;
            }
            else
            {
                return "";
            }
        }
    }
}
