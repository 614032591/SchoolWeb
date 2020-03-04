using PLM_Common;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PLM_SQLDAL
{
    public class AM_提醒通知SQL
    {
        public DataSet 全部消息()
        {
            string sql = string.Format("SELECT * FROM AM_提醒通知 order by 发起时间 DESC");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
        }
        public int 默认消息数()
        {
            string sql = string.Format("SELECT COUNT(*) FROM AM_提醒通知 WHERE 是否已读='否'");
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString()));
        }
        public DataSet 条件查询(string str)
        {
            if (str == "待办事项通知")
            {
                string sql = string.Format("SELECT * FROM AM_提醒通知 WHERE 通知类型='待办事项通知' order by 发起时间 DESC");
                return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            }
            else if (str == "结果反馈通知")
            {
                string sql = string.Format("SELECT * FROM AM_提醒通知 WHERE 通知类型='结果反馈通知' order by 发起时间 DESC");
                return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            }
            else
            {
                DataSet ds = new DataSet();
                return ds;
            }
        }
        public int 条件消息数(string str)
        {
            if (str == "待办事项通知")
            {
                string sql = string.Format("SELECT COUNT(*) FROM AM_提醒通知 WHERE 是否已读='否' AND 通知类型='待办事项通知'");
                return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString()));
            }
            else if (str == "结果反馈通知")
            {
                string sql = string.Format("SELECT COUNT(*) FROM AM_提醒通知 WHERE 是否已读='否' AND 通知类型='结果反馈通知'");
                return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString()));
            }
            else
            {
                return 0;
            }
        }
        public List<AM_提醒通知> 判断颜色()
        {
            string sql = string.Format("SELECT * FROM AM_提醒通知");
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

            List<AM_提醒通知> list = new List<AM_提醒通知>();
            while (read.Read())
            {
                AM_提醒通知 model = new AM_提醒通知();
                model.是否已读 = read["是否已读"].ToString();
                model.ID = Convert.ToInt32(read["ID"]);
                list.Add(model);
            }
            read.Close();
            return list;
        }
        public int 全部已读()
        {
            try
            {
                string sql = string.Format("UPDATE AM_提醒通知 SET 是否已读='是'");
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        public int 选中已读(int ID)
        {
            try
            {
                string sql = string.Format("UPDATE AM_提醒通知 SET 是否已读='是' WHERE ID=" + ID);
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                return 1;

            }
            catch
            {
                return 0;
            }

        }
        public DataSet xiala()
        {
            string DepartmentClassSql = @"SELECT distinct [通知类型]  FROM AM_提醒通知";
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, DepartmentClassSql);
        }
    }
}
