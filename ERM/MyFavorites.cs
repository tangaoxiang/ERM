using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace ERM.UI
{
    public class MyFavorites
    {
        public Dictionary<string, string> Read()
        {
            Dictionary<string, string> hTable = new Dictionary<string, string>();
            try
            {
                string FileName1 = GetDirectory() + "myFavoritesNode_" + Globals.ProjectNO + ".dat";
                if (System.IO.File.Exists(FileName1))
                {
                    string contentFavoritesNode = System.IO.File.ReadAllText(FileName1);
                    if (contentFavoritesNode != null && contentFavoritesNode != "")
                    {
                        string[] C2 = contentFavoritesNode.Split('|');
                        foreach (string c3 in C2)
                        {
                            string[] c4 = c3.Split("?".ToCharArray());
                            if (c4.Length == 2)
                            {
                                string tValue = c4[1];
                                int iPos1 = tValue.IndexOf("]");
                                if (iPos1 > 0)
                                {
                                    tValue = tValue.Substring(iPos1 + 1);
                                }
                                hTable.Add(c4[0], tValue);
                            }
                        }
                    }
                }
            }
            catch { }

            return hTable;
        }
        public void Write(string Key, string Value)
        {
            try
            {
                Dictionary<string, string> hTable = Read();
                if (!hTable.ContainsKey(Key))
                {
                    string FileName1 = GetDirectory() + "myFavoritesNode_" + ERM.UI.Globals.ProjectNO + ".dat";
                    if (!System.IO.File.Exists(FileName1))
                    {

                        StreamWriter w2 = System.IO.File.CreateText(FileName1);
                        w2.Close();
                    }
                    while (hTable.Count > 19)//不可以超过20
                    {
                        foreach (KeyValuePair<string, string> obj in hTable)
                        {
                            hTable.Remove(obj.Key);
                            break;
                        }
                    }
                    string strContnet = "";
                    foreach (KeyValuePair<string, string> obj in hTable)
                    {
                        strContnet += obj.Key + "?" + obj.Value + "|";
                    }
                    strContnet += Key + "?" + Value + "|";
                    StreamWriter w1 = new StreamWriter(FileName1, false);
                    w1.Write(strContnet);
                    w1.Flush();
                    w1.Close();
                }
            }
            catch { }
        }
        public void Delete(string Key)
        {
            try
            {
                Dictionary<string, string> hTable = Read();
                if (hTable.ContainsKey(Key))
                {
                    string FileName1 = GetDirectory() + "myFavoritesNode_" + ERM.UI.Globals.ProjectNO + ".dat";
                    foreach (KeyValuePair<string, string> obj in hTable)
                    {
                        if (obj.Key == Key)
                        {
                            hTable.Remove(obj.Key);
                            break;
                        }
                    }
                    string strContnet = "";
                    foreach (KeyValuePair<string, string> obj in hTable)
                    {
                        strContnet += obj.Key + "?" + obj.Value + "|";
                    }
                    StreamWriter w1 = new StreamWriter(FileName1, false);
                    w1.Write(strContnet);
                    w1.Flush();
                    w1.Close();
                }
            }
            catch { }
        }
        public string GetDirectory()
        {
            //System.IO.DirectoryInfo sysRootInfo = new DirectoryInfo(Environment.SystemDirectory);
            //string strOut = "";
            //string[] D1 = System.IO.Directory.GetLogicalDrives();
            //foreach (string D2 in D1)
            //{
            //    System.IO.DriveInfo dInfo = new DriveInfo(D2);
            //    if (D2.ToLower() != sysRootInfo.Root.ToString().ToLower() && dInfo.DriveFormat.ToLower() != "cdrom")
            //    {
            //        strOut = D2;
            //        break;
            //    }
            //}
            //return strOut;
            string strOut = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\ERM\\";
            if (!System.IO.Directory.Exists(strOut))
            {
                ERM.UI.MyCommon.DeleteAndCreateEmptyDirectory(strOut, true);
            }
            return strOut;
        }
    }
}
