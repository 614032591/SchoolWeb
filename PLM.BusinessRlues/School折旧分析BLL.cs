using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    public class School折旧分析BLL
    {
        School折旧分析SQL sql = new School折旧分析SQL();
        public DataSet 资产明细查询()
        {
            return sql.资产明细查询();
        }

        public DataSet 资产汇总查询()
        {
            return sql.资产汇总查询();
        }

        public DataSet 资产汇总查询(string endTime)
        {
            return sql.资产汇总查询(endTime);
        }

        public List<School资产表> 资产汇总查询s()
        {
            return sql.资产汇总查询s();
        }

        public DataSet 折旧分析条件查询(School条件查询表 model)
        {
            return sql.折旧分析条件查询(model);
        }
    }
}
