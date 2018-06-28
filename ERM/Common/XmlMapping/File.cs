using ERM.BLL;
using ERM.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace ERM.UI.Common.XmlMapping
{
    /// <summary>
    /// 文件XML
    /// </summary>
    public class File : IProjectXML
    {
        private string tempPath;  //临时路径
        private T_FileList obj;//文件列表
        private int fileIndex = 1;
        private int archIndex = 1;
        XmlElement X_temp = null;
        List<string> list = new List<string>();

        public File() { }
        public File(string tempPath, T_FileList obj, int archIndex, int fileIndex)
        {
            this.tempPath = tempPath;
            this.obj = obj;
            this.archIndex = archIndex;
            this.fileIndex = fileIndex;
        }        

        public void setXmlInfo(System.Xml.XmlDocument To_JavaXml, System.Xml.XmlElement engBaseInfo, MDL.T_Projects project = null, System.Xml.XmlElement root = null)
        {
            XmlElement fileInfo = To_JavaXml.CreateElement("fileInfo");
            engBaseInfo.AppendChild(fileInfo);
            List<T_Model> listModel =  ProjectXML_Factory.setXmlInfo(To_JavaXml, project, "queryByFileNo", fileInfo, "File", " where ProjectNO='" + project.ProjectNO + "' and FileID='" + obj.FileID + "'");

            //判断文件是否有电子扫描件，有就扫描件拷贝到指定目录
            if (!String.IsNullOrEmpty(obj.filepath) && obj.filepath != "")
            {
                string efile = System.IO.Path.Combine(Globals.ProjectPath, obj.filepath);

                if (System.IO.File.Exists(efile))
                {
                    //PDF 存储拷贝
                    string pdfPath = @"/efile/" + archIndex.ToString();
                    string pdfOurcePath = @"/yw/" + archIndex.ToString() + "/" + fileIndex.ToString();

                    string pdfName = Globals.ProjectNO + "-" + archIndex.ToString().PadLeft(4, '0')
                        + "-" + fileIndex.ToString().PadLeft(4, '0') + ".pdf";
                    string outfile = tempPath + "\\efile\\" + archIndex.ToString() + "\\" + pdfName;

                    System.IO.File.Copy(efile, outfile, true);

                    if (listModel != null)
                    {
                        foreach (var item in listModel)
                        {
                            XmlNodeList xmlList = fileInfo.GetElementsByTagName(item.MappColumn);

                            if (xmlList.Count == 0)
                            {
                                X_temp = To_JavaXml.CreateElement(item.MappColumn);
                            }
                            else
                            {
                                continue;
                            }
 
                            switch (item.MappColumn)
                            {
                                case "pdfPath"://PDF电子文件路径  
                                    X_temp.SetAttribute("value", pdfPath);
                                    break;
                                case "pdfFilename"://电子文件名称  
                                    X_temp.SetAttribute("value", pdfName);
                                    break;
                                case "pdfSourcePath": //原文
                                    X_temp.SetAttribute("value", pdfOurcePath);
                                    break;
                                default:
                                    X_temp.SetAttribute("value", item.Default);
                                    break;
                            }
                            
                            //X_temp.SetAttribute("description", item.Description);
                            fileInfo.AppendChild(X_temp);
                        }
                    }

                    #region 原文 拷贝
                    IList<MDL.T_CellAndEFile> EFileList =
                        (new BLL.T_CellAndEFile_BLL()).FindByGdFileID(obj.FileID, Globals.ProjectNO);
                    int efileIndex = 1;
                    foreach (MDL.T_CellAndEFile efile_MDL in EFileList)
                    {
                        string ywfile = Globals.ProjectPath + efile_MDL.filepath;
                        if (System.IO.File.Exists(ywfile))
                        {
                            string fileExtension = System.IO.Path.GetExtension(ywfile);

                            outfile = tempPath + "\\yw\\" +
                                archIndex.ToString() + "\\" + fileIndex + "\\" +
                                efileIndex + fileExtension;
                            //拷贝电子文件
                            System.IO.File.Copy(ywfile, outfile, true);


                            GetEFileXE(efile_MDL, To_JavaXml, fileInfo, "\\yw\\" +
                                  archIndex.ToString() + "\\" + fileIndex + "\\" +
                                  efileIndex + fileExtension, efileIndex + fileExtension, efileIndex.ToString(), project);

                            efileIndex++;
                        }
                    }
                    #endregion
                }
            }
            else
            {
                if (listModel != null)
                {
                    foreach (var item in listModel)
                    {
                        XmlNodeList xmlList = fileInfo.GetElementsByTagName(item.MappColumn);

                        if (xmlList.Count == 0)
                        {
                            X_temp = To_JavaXml.CreateElement(item.MappColumn);
                        }
                        else
                        {
                            continue;
                        }

                        switch (item.MappColumn)
                        {
                            case "scanFlag": //是否扫描
                                X_temp.SetAttribute("value", "false");
                                break;
                            default:
                                X_temp.SetAttribute("value", item.Default);
                                break;
                        }

                        //X_temp.SetAttribute("description", item.Description);
                        fileInfo.AppendChild(X_temp);
                    }
                }
            }
        }

        /// <summary>
        /// 构建原文XML
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="xDoc"></param>
        /// <param name="PElement"></param>
        private void GetEFileXE(T_CellAndEFile obj, XmlDocument xDoc, XmlElement PElement, string filePath, string fileName, string orerIndex, T_Projects project)
        {
            //YW_CellAndEFile file = new YW_CellAndEFile(fileName, filePath, obj, orerIndex);
            //file.setXmlInfo(xDoc, PElement, project);
        }
        public DataSet pb_setXmlInfo(string archiveID,string projectNo,string sqlID)
        {
            return ProjectXML_Factory.setXmlInfo(sqlID, "File", "ArchiveID='" + archiveID + "',ProjectNO='" + projectNo + "'");
        }
    }
}
