using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    public class FileRegistrationList
    {
        public FileRegistrationList()
        {
        }
        private string _parentid;
        private string _projectno;
        private string _title;
        private string _filepath;
        private string _fileID;
        private string _fileTreePath;
        private string _FileOrderIndex;
        private string _ArchiveID;
        private string _OrderIndex2;
        private string _zrzbsm;
        private string _zrzlb;
        private string _zrzmc;
        private string _zezzzfw;
        private string _ext;
        private string _wjly;
        private string _DocYs;
        private string _yswjpath;
        private string _docType;
        private string _docFormat;
        private string _Draft;
        private string _OriOpenPro;
        public string OriOpenPro
        {
            get { return this._OriOpenPro; }
            set { this._OriOpenPro = value; }
        }
        public string Draft
        {
            get { return this._Draft; }
            set { this._Draft = value; }
        }
        public string docFormat
        {
            get { return this._docFormat; }
            set { this._docFormat = value; }
        }
        public string docType
        {
            get { return this._docType; }
            set { this._docType = value; }
        }
        public string yswjpath
        {
            get { return this._yswjpath; }
            set { this._yswjpath = value; }
        }
        public string DocYs
        {
            get { return this._DocYs; }
            set { this._DocYs = value; }
        }
        public string wjly
        {
            get { return this._wjly; }
            set { this._wjly = value; }
        }
        public string ext
        {
            get { return this._ext; }
            set { this._ext = value; }
        }
        public string zezzzfw
        {
            get { return this._zezzzfw; }
            set { this._zezzzfw = value; }
        }
        public string zrzmc
        {
            get { return this._zrzmc; }
            set { this._zrzmc = value; }
        }
        public string zrzlb
        {
            get { return this._zrzlb; }
            set { this._zrzlb = value; }
        }
        public string zrzbsm
        {
            get { return this._zrzbsm; }
            set { this._zrzbsm = value; }
        }
        public string OrderIndex2
        {
            get { return this._OrderIndex2; }
            set { this._OrderIndex2 = value; }
        }
        public string ArchiveID
        {
            get { return this._ArchiveID; }
            set { this._ArchiveID = value; }
        }
        public string FileOrderIndex
        {
            get { return this._FileOrderIndex; }
            set { this._FileOrderIndex = value; }
        }
        public string fileTreePath
        {
            get { return this._fileTreePath; }
            set { this._fileTreePath = value; }
        }
        public string fileID
        {
            get { return this._fileID; }
            set { this._fileID = value; }
        }
        public string filepath
        {
            get { return this._filepath; }
            set { this._filepath = value; }
        }
        public string title
        {
            get { return this._title; }
            set { this._title = value; }
        }
        public string ProjectNO
        {
            get { return this._projectno; }
            set { this._projectno = value; }
        }
        public string parentid
        {
            get { return this._parentid; }
            set { this._parentid = value; }
        }
    }
}
