using PLM_Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM_SQLDAL
{
    public class School增减分析SQL
    {
        public DataSet 一级类别()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT  * FROM 一级类别表");

            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }
    }
}
