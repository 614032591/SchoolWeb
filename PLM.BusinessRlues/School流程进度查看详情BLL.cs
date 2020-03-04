using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using PLM_Model;

namespace PLM.BusinessRlues
{
    public class School流程进度查看详情BLL
    {
        School流程进度查看详情SQL sql = new School流程进度查看详情SQL();
        public List<流程进度查看详情表> 资产处置待报废查看详情(string ID, string SID)
        {
            return sql.资产处置待报废查看详情(ID,SID);
        }

        public List<流程进度查看详情表> 购置验收查看详情(string ID, string SID)
        {
            return sql.购置验收查看详情(ID, SID);
        }

        public string 资产处置SID(int ID)
        {
            return sql.资产处置SID(ID);
        }
    }
}
