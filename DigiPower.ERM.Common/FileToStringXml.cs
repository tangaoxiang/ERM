using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace ERM.Common
{
    public class FileToStringXml
    {
        public string FileToXml(string path)
        {
            if (!File.Exists(path))
            {
                return "";
            }
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            try
            {
                byte[] imageBuffer = new byte[br.BaseStream.Length];
                br.Read(imageBuffer, 0, Convert.ToInt32(br.BaseStream.Length));
                string textString = "";
                if (imageBuffer != null && imageBuffer.Length > 0)
                {
                    textString = System.Convert.ToBase64String(imageBuffer);
                }
                br.Close();
                fs.Close();
                return textString;
            }
            catch(Exception ex)
            {
                br.Close();
                fs.Close();
                return "";
            }
        }
    }
}
