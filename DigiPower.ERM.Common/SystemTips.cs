/*
   作者： 张建宏
   日期：2008-12-03
   功能：系统提示类常量  
   备注：信息提示统一写在此类中 定义为常量信息 方便管理
 */
using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.Common
{
    public class SystemTips
    {
        public SystemTips()
        {
        }
        public const  string MSG_TITLE = "系统信息提示"; // 提示框标题
        public const string MSG_SURE_EXIT_SYSTEM = "您确定要退出系统吗?";
        public const string MSG_PASSWORD_OR_USERNAME_NOTNULL = "用户名或密码不能为空，请重新输入！";
        public const string MSG_PASSWORD_ERROR = "密码错误，请重新输入！";
        public const string MSG_EDIT_PW_FAILE = "修改密码失败！";
        public const string MSG_EDIT_PW_SUCC = "修改密码成功！";
        public const string MSG_ARE_SURE = "确定要删除记录吗 ？";
        public const string MSG_SAVE_SUCC = "数据保存成功 ！";
        public const string MSG_SAVE_FAILE = "数据保存失败 ！";
        public const string MSG_DELETE_SUCC = "数据删除成功 ！";
        public const string MSG_DELETE_FAILE = "数据删除失败 ！";
        public const string MSG_USERID_NOTNULL = "用户名不能为空";
        public const string MSG_USERPWD_NOTNULL = "用户密码不能为空";
        public const string MSG_USERFULLNAME_NOTNULL = "用户姓名不能为空";
        public const string MSG_USER_THEM_PLEASE = "请选择系统样式";
        public const string MSG_ATLAST_SELECTROW_OP = "至少要选择一行记录才能够操作";
        public const string MSG_USERNAME_EXITS = "已经存相同的用户名";
        public const string MSG_PAGESIZE_TYPE_NOT_NULL = "卷册类型不能为空";
        public const string MSG_PAGESIZE_TYPE_HAVESAME = "卷册类型存在相同的";
        public const string MSG_PAGESIZE_ISDEFAULT_HAVESAME = "已经存在卷册的默认值";
        public const string　MSG_DISTRICTNAME_NOT_NULL ="区域名不能为空";
        public const string MSG_DISTRICTNAME_HAVESAME　="已经存相同的区域名称";
        public const string MSG_PROJECT_NOT_NULL = "备案登记号不能为空";
        public const string MSG_AJTM_NOT_NULL = "案卷题名不能为空";
        public const string MSG_EXPANG_SUCC = "案卷拆卷成功 ！";
        public const string MSG_EXPANG_FAILE = "案卷拆卷失败 ！";
        public const string MSG_ARE_SURE_PROJECT_ARCHIVE_REMOVE = "确定要移除整个工程的案卷目录的所有文件吗 ？";
        public const string MSG_ARE_SURE_ARCHIVE_REMOVE = "确定要移除案卷目录的整个文件吗 ？";
        public const string MSG_ARE_SURE_ARCHIVE_FILE_REMOVE = "确定要移除所选中的文件吗 ？";
        public const string MSG_ARE_SURE_PROJECT_ALL_FILE = "确定要将整个工程的所有文件移动到案卷目录下吗 ？";
        public const string MSG_ARE_NEW_CREATE_ARCHIVE = "是否新建案卷？";
        public const string MSG_PLEASE_SELECT_ARCHIVE = "请选择案卷目录";
        public const string MSG_ARE_SURE_PROJECT_ARCHIVE_DELETE = "确定要删除整个工程的案卷目录吗 ？";
        public const string MSG_PLEASE_SELECT_ARCHIVE_MJ = "请选择案卷密级";
        public const string MSG_PLEASE_SELECT_ARCHIVE_BGQX = "请选择案卷保管期限";
        public const string MSG_PLEASE_SELECT_ARCHIVE_TYPE = "请选择案卷案卷类型";
        public const string MSG_PLEASE_SELECT_ARCHIVE_BZDW = "请选择案卷编制单位";
        public const string MSG_ARE_SURE_MOVE_FILE = "确定移除文件吗 ？";
        public const string MSG_ARE_SURE__ARCHIVE_DELETE = "确定要删除案卷吗 ？";
        public const string MSG_PROJECTNO_NO_ARCHIVE_FILE = "该工程下没有案卷和文件,不能执行删除";
    }
}
