using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_YW_CellAndEFile
    {
        /// <summary>
        /// ����
        /// </summary>
        public String ID { set; get; }

        /// <summary>
        /// �ļ�ID
        /// </summary>
        public String FileID { set; get; } 
     
        /// <summary>
        /// ���̱��
        /// </summary>
        public String ProjectNO { set; get; }

        /// <summary>
        /// ������
        /// </summary>
        public String CreateUser { set; get; }

         /// <summary>
         /// ����ʱ��
         /// </summary>
        public String CreateDate { set; get; }

        /// <summary>
        /// �ļ���ʽ
        /// </summary>
        public String FileFormat { set; get; }

        /// <summary>
        /// �ļ�����
        /// </summary>
        public String FileName { set; get; }

        /// <summary>
        /// �ļ���СKB
        /// </summary>
        public Int32? FileSize { set; get; } 

        /// <summary>
        /// ������ʽ
        /// </summary>
        public String OperationType { set; get; }
       
        /// <summary>
        /// ԭ�Ķ�Ӧ�ĵ����ļ���Ϣ
        /// </summary>
        public String CellID { set; get; }       
        
    }
}
