using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_Item
    {
        private String m_itemID;
        public String ItemID
        {
            get { return m_itemID; }
            set { m_itemID = value; }
        }
        private String m_conStructionProjectName;
        public String ConStructionProjectName
        {
            get { return m_conStructionProjectName; }
            set { m_conStructionProjectName = value; }
        }
        private String m_respective;
        public String Respective
        {
            get { return m_respective; }
            set { m_respective = value; }
        }
        private String m_constructionProjectAdd;
        public String ConstructionProjectAdd
        {
            get { return m_constructionProjectAdd; }
            set { m_constructionProjectAdd = value; }
        }
        private String m_projectType;
        public String ProjectType
        {
            get { return m_projectType; }
            set { m_projectType = value; }
        }
        private String m_useSoiAreaSum;
        public String UseSoiAreaSum
        {
            get { return m_useSoiAreaSum; }
            set { m_useSoiAreaSum = value; }
        }
        private String m_constructionAreaSum;
        public String ConstructionAreaSum
        {
            get { return m_constructionAreaSum; }
            set { m_constructionAreaSum = value; }
        }
        private String m_constructionScale;
        public String ConstructionScale
        {
            get { return m_constructionScale; }
            set { m_constructionScale = value; }
        }
        private String m_projectCost;
        public String ProjectCost
        {
            get { return m_projectCost; }
            set { m_projectCost = value; }
        }
        private String m_projectSettlement;
        public String ProjectSettlement
        {
            get { return m_projectSettlement; }
            set { m_projectSettlement = value; }
        }
        private String m_startDate;
        public String StartDate
        {
            get { return m_startDate; }
            set { m_startDate = value; }
        }
        private String m_finishDate;
        public String FinishDate
        {
            get { return m_finishDate; }
            set { m_finishDate = value; }
        }
        private String m_useSoiType;
        public String UseSoiType
        {
            get { return m_useSoiType; }
            set { m_useSoiType = value; }
        }
        private String m_collectionType;
        public String CollectionType
        {
            get { return m_collectionType; }
            set { m_collectionType = value; }
        }
        private String m_originalSoiType;
        public String OriginalSoiType
        {
            get { return m_originalSoiType; }
            set { m_originalSoiType = value; }
        }
        private String m_useSoiArea;
        public String UseSoiArea
        {
            get { return m_useSoiArea; }
            set { m_useSoiArea = value; }
        }
        private String m_approvedate;
        public String Approvedate
        {
            get { return m_approvedate; }
            set { m_approvedate = value; }
        }
        private String m_createUnit;
        public String CreateUnit
        {
            get { return m_createUnit; }
            set { m_createUnit = value; }
        }
        private String m_itemFzr;
        public String ItemFzr
        {
            get { return m_itemFzr; }
            set { m_itemFzr = value; }
        }
        private String m_allCost;
        public String AllCost
        {
            get { return m_allCost; }
            set { m_allCost = value; }
        }
        private String m_volumeFar;
        public String VolumeFar
        {
            get { return m_volumeFar; }
            set { m_volumeFar = value; }
        }
        private String m_greenFar;
        public String GreenFar
        {
            get { return m_greenFar; }
            set { m_greenFar = value; }
        }
        private String m_buildingDensity;
        public String BuildingDensity
        {
            get { return m_buildingDensity; }
            set { m_buildingDensity = value; }
        }
    }
}
