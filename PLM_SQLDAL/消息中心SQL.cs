using PLM_Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM_SQLDAL
{
    public class 消息中心SQL
    {
        public int 未读总数(string 通知职务)
        {
            string sql = "SELECT COUNT(*) as 总数 FROM dbo.AM_提醒通知 WHERE 是否已读 = '否'";
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql));
        }

        public DataSet 查询消息中心(string 职务)
        {
            string sql = string.Format("SELECT * FROM dbo.AM_提醒通知 WHERE 是否已读 = '否'");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql);
        }

    }
}
