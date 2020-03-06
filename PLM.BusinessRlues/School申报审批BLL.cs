using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    public class School申报审批BLL
    {
        School申报审批SQL sql = new School申报审批SQL();

        public DataSet 首页_X_资产处置流程表(string state, string declareTypes)
        {
            return sql.首页_X_资产处置流程表(state, declareTypes);
        }

        public DataSet 待处置库查询(string state, string purchaseTime)
        {
            return sql.待处置库查询(state,purchaseTime);
        }

        public List<School办公设备信息表> 资产申报确定设备(List<int> listid, string 处置方式)
        {
            return sql.资产申报确定设备(listid, 处置方式);
        }
        //public int 插入资产处置(SchoolX_资产处置流程表 model)
        //{
        //    return sql.插入资产处置(model);
        //}

        public int 插入资产处置调拨单(SchoolX_资产处置流程表 model)
        {
            return sql.插入资产处置调拨单(model);
        }

        public List<School办公设备信息表> 处置申报查询(string sid, string mark)
        {
            return sql.处置申报查询(sid, mark);
        }

        //申报记录统计查询
        public DataSet 申报记录统计查询(string sSearch, string flowstate)
        {
            return sql.申报记录统计查询(sSearch, flowstate);
        }

        public string 用户权限(int ID)
        {
            return sql.用户权限(ID);
        }

        public string 资产处置调出单位(int ID)
        {
            return sql.资产处置调出单位(ID);
        }

        public string 资产处置调入单位(int ID)
        {
            return sql.资产处置调入单位(ID);
        }

        public int 创建处置申报资产报废(SchoolX_资产处置流程表 model)
        {
            return sql.创建处置申报资产报废(model);
        }
        public int 处置申报待报废处理流程(SchoolX_资产处置流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            return sql.处置申报待报废处理流程(model, ammodel, dbmodel);
        }

        public int 调拨流程处理(SchoolX_资产处置流程表 model)
        {
            return sql.调拨流程处理(model);
        }
        public int 处置申报报废处理流程(SchoolX_资产处置流程表 model)
        {
            return sql.处置申报报废处理流程(model);
        }



        public string 资产处置调拨调出单位管理员姓名(int ID)
        {
            return sql.资产处置调拨调出单位管理员姓名(ID);
        }

        public string 资产处置调拨调入单位管理员姓名(int ID)
        {
            return sql.资产处置调拨调入单位管理员姓名(ID);
        }

    }
}
