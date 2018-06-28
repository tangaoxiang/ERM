using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.IO;

namespace ERM.UI
{
    ///
    /// 盘符信息
    ///
    public class HardDiskPartition
    {
        #region Data
        private string _PartitionName;
        private double _FreeSpace;
        private double _SumSpace;
        #endregion //Data

        #region Properties
        ///
        /// 空余大小
        ///
        public double FreeSpace
        {
            get { return _FreeSpace; }
            set { this._FreeSpace = value; }
        }
        ///
        /// 使用空间
        ///
        public double UseSpace
        {
            get { return _SumSpace - _FreeSpace; }
        }
        ///
        /// 总空间
        ///
        public double SumSpace
        {
            get { return _SumSpace; }
            set { this._SumSpace = value; }
        }
        ///
        /// 分区名称
        ///
        public string PartitionName
        {
            get { return _PartitionName; }
            set { this._PartitionName = value; }
        }
        ///
        /// 是否主分区
        ///
        public bool IsPrimary
        {
            get
            {
                //判断是否为系统安装分区
                if (System.Environment.GetEnvironmentVariable("windir").Remove(2) == this._PartitionName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion //Properties

        /// <summary>
        /// 处理Double值，精确到小数点后几位
        /// </summary>
        /// <param name="_value">值</param>
        /// <param name="Length">精确到小数点后几位</param>
        /// <returns>返回值</returns>
        public double ManagerDoubleValue(double _value, int Length)
        {
            if (Length < 0)
            {
                Length = 0;
            }
            return System.Math.Round(_value, Length);
        }

        /// <summary>
        /// 获取硬盘上所有的盘符空间信息列表
        /// </summary>
        /// <returns></returns>
        public List<HardDiskPartition> GetDiskListInfo()
        {
            List<HardDiskPartition> list = null;
            //指定分区的容量信息
            try
            {
                SelectQuery selectQuery = new SelectQuery("select * from win32_logicaldisk");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);

                ManagementObjectCollection diskcollection = searcher.Get();

                if (diskcollection != null && diskcollection.Count > 0)
                {
                    list = new List<HardDiskPartition>();

                    HardDiskPartition harddisk = null;
                    foreach (ManagementObject disk in searcher.Get())
                    {
                        int nType = Convert.ToInt32(disk["DriveType"]);
                        if (nType != Convert.ToInt32(DriveType.Fixed))
                        {
                            continue;
                        }
                        else
                        {
                            harddisk = new HardDiskPartition();
                            harddisk.FreeSpace = Convert.ToDouble(disk["FreeSpace"]) / (1024 * 1024 * 1024);
                            harddisk.SumSpace = Convert.ToDouble(disk["Size"]) / (1024 * 1024 * 1024);
                            harddisk.PartitionName = disk["DeviceID"].ToString();

                            list.Add(harddisk);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return list;
        }
        /// <summary>
        /// 获取硬盘上指定名称的盘符空间信息列表
        /// </summary>
        /// <returns></returns>
        public HardDiskPartition GetDiskInfo(string diskname)
        {
            //指定分区的容量信息
            HardDiskPartition harddisk = null;
            try
            {
                SelectQuery selectQuery = new SelectQuery("select * from win32_logicaldisk");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);

                ManagementObjectCollection diskcollection = searcher.Get();

                if (diskcollection != null && diskcollection.Count > 0)
                {
                    foreach (ManagementObject disk in searcher.Get())
                    {
                        int nType = Convert.ToInt32(disk["DriveType"]);
                        if (nType != Convert.ToInt32(DriveType.Fixed))
                        {
                            continue;
                        }
                        else
                        {
                            if (disk["DeviceID"].ToString().ToUpper() == diskname.ToUpper())
                            {
                                harddisk = new HardDiskPartition();
                                harddisk.FreeSpace = Convert.ToDouble(disk["FreeSpace"]) / (1024 * 1024 * 1024);
                                harddisk.SumSpace = Convert.ToDouble(disk["Size"]) / (1024 * 1024 * 1024);
                                harddisk.PartitionName = disk["DeviceID"].ToString();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                harddisk = null;
            }
            return harddisk;
        }
    }
}
