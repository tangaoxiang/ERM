using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_FileList
    {
        public String FileID { set; get; }
        public String ParentID { set; get; }
        public String ProjectNO { set; get; }
        public String ArchiveID { set; get; }
        public Int32 ArchiveIndex { set; get; }
        public String id { set; get; }
        public String gdwj { set; get; }
        public String jsdw { set; get; }
        public String sgdw { set; get; }
        public String sjdw { set; get; }
        public String jldw { set; get; }
        public String cjdag { set; get; }
        public String datawindow_id { set; get; }
        public String table_name { set; get; }
        public String table_standerd { set; get; }
        public String extension1 { set; get; }
        public String extension2 { set; get; }
        public String extension3 { set; get; }
        public Int32 selected { set; get; }
        public String wjmj { set; get; }
        public String zrr { set; get; }
        public String gclx { set; get; }
        public String TreePath { set; get; }
        public Int32 OrderIndex { set; get; }
        public Int32 isvisible { set; get; }
        public String pTreePath { set; get; }
        public String wjcj { set; get; }
        public String wjbsm { set; get; }
        public String wjtm { set; get; }
        public String wjmc { set; get; }
        public String bzdw { set; get; }
        public String wh { set; get; }
        public String bgqx { set; get; }
        public String mj { set; get; }
        public string CreateDate { set; get; }
        public string CreateDate2 { set; get; }
        public String ztlx { set; get; }
        public Int32 sl { set; get; }
        public String dw { set; get; }
        public String gg { set; get; }
        public String wjgbdm { set; get; }
        public String wjlxdm { set; get; }
        public String wjgs { set; get; }
        public String wjdx { set; get; }
        public String psdd { set; get; }
        public String psz { set; get; }
        public String pssj { set; get; }
        public String sb { set; get; }
        public String fbl { set; get; }
        public String xjpp { set; get; }
        public String xjxh { set; get; }
        public String bz { set; get; }
        public String filepath { set; get; }
        public String fileStatus { set; get; }
        public String wzz { set; get; }
        public String tzz { set; get; }
        public String dtz { set; get; }
        public String zpz { set; get; }
        public String dpz { set; get; }
        public Int32 isSign { set; get; }
        public Int32 IsUseDefined { set; get; }
        /// <summary>
        /// �鵵���
        /// </summary>
        public String GDID { set; get; }
        /// <summary>
        ///��ʾ���� �����ñ� or �ļ��ǼǺ����
        ///</summary>
        public Int32 FL { set; get; }
        /// <summary>
        ///��ԴID
        /// </summary>
        public String FromFileID { set; get; }
        /// <summary>
        /// �鵵������ļ�����
        /// </summary>
        public Int32 GdFileOrderIndex { set; get; }
        /// <summary>
        /// �ļ�����
        /// </summary>
        public String wjlx { set; get; }

        /// <summary>
        /// �ֲ�
        /// </summary>
        public String BRANCH { set; get; }

        /// <summary>
        /// �ӷֲ�
        /// </summary>
        public String SUBBRANCH { set; get; }

        /// <summary>
        /// ����
        /// </summary>
        public String SUBPROJCET { set; get; }

        /// <summary>
        /// ��������
        /// </summary>
        public string ProjectCategory { set; get; }

        public int stys { get; set; }

        public int wzys { get; set; }
    }
}
