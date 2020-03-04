using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using PLM_SQLDAL;


namespace PLM.BusinessRlues
{
    public class School结存分析BLL
    {
        School结存分析SQL sql = new School结存分析SQL();
        //public DataSet 购置验收条件查询(School查询办公设备条件表 model)
        //{
        //    return sql.购置验收条件查询(model);
        //}

        public DataSet 结存分析条件查询(School条件查询表 model)
        {
            return sql.结存分析条件查询(model);
        }
    }
}
