using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    public class School增减分析BLL
    {
        School增减分析SQL sql = new School增减分析SQL();
        public DataSet 一级类别()
        {
            return sql.一级类别();
        }
    }
}
