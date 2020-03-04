using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    public class School原值变动BLL
    {
        School原值变动SQL sql = new School原值变动SQL();
        public DataSet 首页_X_原值变动流程表(string state)
        {
            return sql.首页_X_原值变动流程表(state);
        }
        public DataSet 首页_X_价格变动流程表(string sSearch, string flowstate)
        {
            return sql.首页_X_价格变动流程表(sSearch, flowstate);
        }
        public int 新增原值变动(SchoolX_原值变动流程表 model, List<School办公设备信息表> workmodel, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            return sql.新增原值变动(model, workmodel, ammodel, dbmodel);
        }
        public DataSet 原值变动查看详情(string strid) 
        {
            return sql.原值变动查看详情(strid);
        }

        public int 操作原值变动流程(SchoolX_原值变动流程表 model, AM_提醒通知 ammodel)
        {
            return sql.操作原值变动流程(model, ammodel);
        }
    }
}
