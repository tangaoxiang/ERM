using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_EFile
    {
        private String m_eFileID;
        public String EFileID
        {
            get { return m_eFileID; }
            set { m_eFileID = value; }
        }
        private String m_fileID;
        public String FileID
        {
            get { return m_fileID; }
            set { m_fileID = value; }
        }
        private Int32 m_attachid;
        public Int32 attachid
        {
            get { return m_attachid; }
            set { m_attachid = value; }
        }
        private String m_projectno;
        public String projectno
        {
            get { return m_projectno; }
            set { m_projectno = value; }
        }
        private String m_title;
        public String title
        {
            get { return m_title; }
            set { m_title = value; }
        }
        private String m_filepath;
        public String filepath
        {
            get { return m_filepath; }
            set { m_filepath = value; }
        }
        private String m_fileTreePath;
        public String fileTreePath
        {
            get { return m_fileTreePath; }
            set { m_fileTreePath = value; }
        }
        private Int32? m_fileOrderIndex;
        public Int32? FileOrderIndex
        {
            get { return m_fileOrderIndex; }
            set { m_fileOrderIndex = value; }
        }
        private String m_archiveID;
        public String ArchiveID
        {
            get { return m_archiveID; }
            set { m_archiveID = value; }
        }
        private Int32? m_orderIndex2;
        public Int32? OrderIndex2
        {
            get { return m_orderIndex2; }
            set { m_orderIndex2 = value; }
        }
        private String m_zrzbsm;
        public String zrzbsm
        {
            get { return m_zrzbsm; }
            set { m_zrzbsm = value; }
        }
        private String m_zrzlb;
        public String zrzlb
        {
            get { return m_zrzlb; }
            set { m_zrzlb = value; }
        }
        private String m_zrzmc;
        public String zrzmc
        {
            get { return m_zrzmc; }
            set { m_zrzmc = value; }
        }
        private String m_zezzzfw;
        public String zezzzfw
        {
            get { return m_zezzzfw; }
            set { m_zezzzfw = value; }
        }
        private String m_ext;
        public String ext
        {
            get { return m_ext; }
            set { m_ext = value; }
        }
        private String m_wjly;
        public String wjly
        {
            get { return m_wjly; }
            set { m_wjly = value; }
        }
        private Int32? m_docYs;
        public Int32? DocYs
        {
            get { return m_docYs; }
            set { m_docYs = value; }
        }
        private String m_yswjpath;
        public String yswjpath
        {
            get { return m_yswjpath; }
            set { m_yswjpath = value; }
        }
        private String m_docType;
        public String docType
        {
            get { return m_docType; }
            set { m_docType = value; }
        }
        private String m_docFormat;
        public String docFormat
        {
            get { return m_docFormat; }
            set { m_docFormat = value; }
        }
        private String m_draft;
        public String Draft
        {
            get { return m_draft; }
            set { m_draft = value; }
        }
        private String m_oriOpenPro;
        public String OriOpenPro
        {
            get { return m_oriOpenPro; }
            set { m_oriOpenPro = value; }
        }
        private Int32? m_orderIndex;
        public Int32? OrderIndex
        {
            get { return m_orderIndex; }
            set { m_orderIndex = value; }
        }
    }
}
