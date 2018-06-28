using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_Project_RoadLamp_BLL : IBLL
    {
        /// <summary>
        /// 根据项目ID获取相应市政路灯工程明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T_Project_RoadLamp QueryRoadLamp_ByProjID(string ID)
        {
            String stmtId = "T_Project_RoadLamp.QueryRoadLamp_ByProjID";
            T_Project_RoadLamp result = MyISqlMap.QueryForObject<T_Project_RoadLamp>(stmtId, ID);
            return result;
        }

        public void Insert(T_Project_RoadLamp obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Project_RoadLamp.InsertT_RoadLamp";
            MyISqlMap.Insert(stmtId, obj);
        }

        public bool Add(T_Projects model_Projects, T_Item model_Item, T_Project_RoadLamp model_RoadLamp)
        {
            BLL.T_Projects_BLL proj_bll = new T_Projects_BLL();
            bool flag = proj_bll.Add(model_Projects, model_Item);

            if (flag)
            {
                this.Insert(model_RoadLamp);
                return true;
            }
            return false;
        }
        public bool Update(T_Projects model_Projects, T_Item model_Item, T_Project_RoadLamp model_RoadLamp)
        {
            BLL.T_Projects_BLL proj_bll = new T_Projects_BLL();
            bool flag = proj_bll.Update(model_Projects, model_Item);

            if (flag)
            {
                this.Update(model_RoadLamp);
                return true;
            }
            return false;
        }

        public void Update(T_Project_RoadLamp obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Project_RoadLamp.UpdateT_RoadLamp";
            MyISqlMap.Update(stmtId, obj);
        }

        public void Delete(String ID)
        {
            if (ID == null) throw new ArgumentNullException("ID");
            String stmtId = "T_Project_RoadLamp.DeleteT_RoadLamp";
            T_Project_RoadLamp obj = new T_Project_RoadLamp();
            obj.ID = ID;
            MyISqlMap.Delete(stmtId, obj);
        }
    }
}
