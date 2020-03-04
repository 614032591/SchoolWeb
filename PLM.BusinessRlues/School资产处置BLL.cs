using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using PLM_Model;
using PLM_SQLDAL;
namespace PLM_Model
{

    public class School资产处置BLL
    {
        School资产处置SQL sql = new School资产处置SQL();

        public DataSet 查询全部资产信息()
        {
            return sql.查询全部资产信息();
        }

        public DataSet 查询全部资产信息(School查询办公设备条件表 model)
        {
            return sql.查询全部资产信息(model);
        }

        public DataSet 购置验收条件查询(School查询办公设备条件表 model)
        {
            return sql.购置验收条件查询(model);
        }

        public int 资产处置(List<int> ID, string comtxt)
        {
            return sql.资产处置(ID, comtxt);
        }
        public DataSet DataSet资产状态查询(string sSearch, string flowstate)
        {
            return sql.DataSet资产状态查询(sSearch, flowstate);
        }


        public DataSet 资产处置统计查询表(string sSearch, string flowstate)
        {
            return sql.资产处置统计查询表(sSearch, flowstate);
        }

    }
}
