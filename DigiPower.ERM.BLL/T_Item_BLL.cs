using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_Item_BLL : IBLL
    {
        public int GetCount()
        {
            String stmtId = "T_Item.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }
        public T_Item Find(String itemID)
        {
            String stmtId = "T_Item.Find";
            T_Item result = MyISqlMap.QueryForObject<T_Item>(stmtId, itemID);
            return result;
        }
        public bool Exists(String projectID)
        {
            String stmtId = "T_Item.Find";
            T_Item result = MyISqlMap.QueryForObject<T_Item>(stmtId, projectID);
            if (result == null)
                return false;
            else
                return true;
        }
        public IList<T_Item> GetAll()
        {
            String stmtId = "T_Item.GetAll";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, null);
            return result;
        }
        public System.Data.DataSet GetList(String strWhere)
        {
            String stmtId = "T_Item.GetList";
            if (strWhere == null || strWhere == "" || strWhere == "1=1")
            {
                strWhere = null;
                stmtId = "T_Item.GetAll";
            }
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, strWhere);
            return result;
        }
        public IList<T_Item> FindByConStructionProjectName(String conStructionProjectName)
        {
            String stmtId = "T_Item.FindByConStructionProjectName";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, conStructionProjectName);
            return result;
        }
        public IList<T_Item> FindByRespective(String respective)
        {
            String stmtId = "T_Item.FindByRespective";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, respective);
            return result;
        }
        public IList<T_Item> FindByConstructionProjectAdd(String constructionProjectAdd)
        {
            String stmtId = "T_Item.FindByConstructionProjectAdd";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, constructionProjectAdd);
            return result;
        }
        public IList<T_Item> FindByProjectType(String projectType)
        {
            String stmtId = "T_Item.FindByProjectType";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, projectType);
            return result;
        }
        public IList<T_Item> FindByUseSoiAreaSum(String useSoiAreaSum)
        {
            String stmtId = "T_Item.FindByUseSoiAreaSum";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, useSoiAreaSum);
            return result;
        }
        public IList<T_Item> FindByConstructionAreaSum(String constructionAreaSum)
        {
            String stmtId = "T_Item.FindByConstructionAreaSum";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, constructionAreaSum);
            return result;
        }
        public IList<T_Item> FindByConstructionScale(String constructionScale)
        {
            String stmtId = "T_Item.FindByConstructionScale";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, constructionScale);
            return result;
        }
        public IList<T_Item> FindByProjectCost(String projectCost)
        {
            String stmtId = "T_Item.FindByProjectCost";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, projectCost);
            return result;
        }
        public IList<T_Item> FindByProjectSettlement(String projectSettlement)
        {
            String stmtId = "T_Item.FindByProjectSettlement";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, projectSettlement);
            return result;
        }
        public IList<T_Item> FindByStartDate(String startDate)
        {
            String stmtId = "T_Item.FindByStartDate";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, startDate);
            return result;
        }
        public IList<T_Item> FindByFinishDate(String finishDate)
        {
            String stmtId = "T_Item.FindByFinishDate";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, finishDate);
            return result;
        }
        public IList<T_Item> FindByUseSoiType(String useSoiType)
        {
            String stmtId = "T_Item.FindByUseSoiType";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, useSoiType);
            return result;
        }
        public IList<T_Item> FindByCollectionType(String collectionType)
        {
            String stmtId = "T_Item.FindByCollectionType";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, collectionType);
            return result;
        }
        public IList<T_Item> FindByOriginalSoiType(String originalSoiType)
        {
            String stmtId = "T_Item.FindByOriginalSoiType";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, originalSoiType);
            return result;
        }
        public IList<T_Item> FindByUseSoiArea(String useSoiArea)
        {
            String stmtId = "T_Item.FindByUseSoiArea";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, useSoiArea);
            return result;
        }
        public IList<T_Item> FindByApprovedate(String approvedate)
        {
            String stmtId = "T_Item.FindByApprovedate";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, approvedate);
            return result;
        }
        public IList<T_Item> FindByCreateUnit(String createUnit)
        {
            String stmtId = "T_Item.FindByCreateUnit";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, createUnit);
            return result;
        }
        public IList<T_Item> FindByItemFzr(String itemFzr)
        {
            String stmtId = "T_Item.FindByItemFzr";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, itemFzr);
            return result;
        }
        public IList<T_Item> FindByAllCost(String allCost)
        {
            String stmtId = "T_Item.FindByAllCost";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, allCost);
            return result;
        }
        public IList<T_Item> FindByVolumeFar(String volumeFar)
        {
            String stmtId = "T_Item.FindByVolumeFar";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, volumeFar);
            return result;
        }
        public IList<T_Item> FindByGreenFar(String greenFar)
        {
            String stmtId = "T_Item.FindByGreenFar";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, greenFar);
            return result;
        }
        public IList<T_Item> FindByBuildingDensity(String buildingDensity)
        {
            String stmtId = "T_Item.FindByBuildingDensity";
            IList<T_Item> result = MyISqlMap.QueryForList<T_Item>(stmtId, buildingDensity);
            return result;
        }
        public void Insert(T_Item obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Item.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Add(T_Item obj)
        {
            Insert(obj);
        }
        public void Update(T_Item obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Item.Update";
            MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(T_Item obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Item.Delete";
            MyISqlMap.Delete(stmtId, obj);
        }
        public void Delete(String cellID)
        {
            if (cellID == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Item.Delete";
            T_Item obj = new T_Item();
            obj.ItemID = cellID;
            MyISqlMap.Delete(stmtId, obj);
        }
    }
}
