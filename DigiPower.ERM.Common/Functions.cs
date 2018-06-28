using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace DigiPower.ERM.Common
{
    public class Functions
    {
        ///// <summary>
        ///// ��ȡ���ļ���
        ///// </summary>
        ///// <param name="fullFilePath">�ļ�������·��</param>
        ///// <returns>���ļ���</returns>
        public string FileToXml(string path)
        {
            if (!File.Exists(path))
            {
                return "";
            }
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            byte[] imageBuffer = new byte[br.BaseStream.Length];
            br.Read(imageBuffer, 0, Convert.ToInt32(br.BaseStream.Length));
            string textString = System.Convert.ToBase64String(imageBuffer);
            fs.Close();
            br.Close();
            return textString;
        }
    }
}
