using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_CellFile
    {
        private String m_cellID;
        public String CellID
        {
            get { return m_cellID; }
            set { m_cellID = value; }
        }
        private String m_fileID;
        public String FileID
        {
            get { return m_fileID; }
            set { m_fileID = value; }
        }
        private String m_id;
        public String id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        private String m_projectNO;
        public String ProjectNO
        {
            get { return m_projectNO; }
            set { m_projectNO = value; }
        }
        private String m_treePath;
        public String TreePath
        {
            get { return m_treePath; }
            set { m_treePath = value; }
        }
        private String m_parentid;
        public String parentid
        {
            get { return m_parentid; }
            set { m_parentid = value; }
        }
        private String m_pTreePath;
        public String PTreePath
        {
            get { return m_pTreePath; }
            set { m_pTreePath = value; }
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
        private String m_examplepath;
        public String examplepath
        {
            get { return m_examplepath; }
            set { m_examplepath = value; }
        }
        private String m_codeno;
        public String codeno
        {
            get { return m_codeno; }
            set { m_codeno = value; }
        }
        private Int32? m_customdefine;
        public Int32? customdefine
        {
            get { return m_customdefine; }
            set { m_customdefine = value; }
        }
        private String m_zrr;
        public String zrr
        {
            get { return m_zrr; }
            set { m_zrr = value; }
        }
        private Int32? m_codetype;
        public Int32? codetype
        {
            get { return m_codetype; }
            set { m_codetype = value; }
        }
        private String m_fbmc;
        public String fbmc
        {
            get { return m_fbmc; }
            set { m_fbmc = value; }
        }
        private String m_fxmc;
        public String fxmc
        {
            get { return m_fxmc; }
            set { m_fxmc = value; }
        }
        private String m_zfbmc;
        public String zfbmc
        {
            get { return m_zfbmc; }
            set { m_zfbmc = value; }
        }
        private Int32 m_ys;
        public Int32 ys
        {
            get { return m_ys; }
            set { m_ys = value; }
        }
        private Int32? m_isvisible;
        public Int32? isvisible
        {
            get { return m_isvisible; }
            set { m_isvisible = value; }
        }
        private Int32? m_orderindex;
        public Int32? orderindex
        {
            get { return m_orderindex; }
            set { m_orderindex = value; }
        }
    }
}
