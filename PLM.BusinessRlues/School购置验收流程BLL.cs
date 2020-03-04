using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    public class School购置验收流程BLL
    {
        School购置验收流程SQL us = new School购置验收流程SQL();
        public DataSet DataSet购置验收查询(string flowstate,string startname,string duty)
        {
            return us.DataSet购置验收查询(flowstate, startname,duty);
        }


        public int 插入X_购置验收流程表(SchoolX_购置验收流程表 model, List<School办公设备信息表> listmodel,AM_提醒通知 ammodel)
        {
            return us.插入X_购置验收流程表(model, listmodel, ammodel);
        }

        public DataSet 购置验收查询设备(int xid)
        {
            return us.购置验收查询设备(xid);
        }


        public DataSet 购置验收查询明细()
        {
            return us.购置验收查询明细();
        }

        public int 操作购置验收流程(SchoolX_购置验收流程表 model, AM_提醒通知 txmodel)
        {
            return us.操作购置验收流程(model,txmodel);
        }
    }
}
