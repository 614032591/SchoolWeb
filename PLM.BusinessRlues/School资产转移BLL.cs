using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using PLM_Model;
using PLM_SQLDAL;
namespace PLM.BusinessRlues
{


    public class School资产转移BLL
    {
        School资产转移SQL sql = new School资产转移SQL();

        public DataSet 首页_X_资产转移流程表(string state)
        {
            return sql.首页_X_资产转移流程表(state);
        }


        public DataSet 资产转移查看详情(int ID)
        {
            return sql.资产转移查看详情(ID);
        }

        public SchoolX_资产转移改动信息表 查询变更为(int ID)
        {
            return sql.查询变更为(ID);
        }



        public List<School一级部门表> byzc()
        {
            return sql.byzc();
        }

        public List<School房间信息表> cfdd()
        {
            return sql.cfdd();
        }
        public List<用户表> listuser(int id)
        {
            return sql.listuser(id);
        }

        public List<School办公设备信息表> 资产转移确定设备(List<int> listid)
        {
            return sql.资产转移确定设备(listid);
        }

        public int 修改数据(int ID, string 归属部门变更为, string 存放地点变更为, string 负责人变更为, AM_提醒通知 ammodel, AM_待办业务 dbmode)
        {
            return sql.修改数据(ID, 归属部门变更为, 存放地点变更为, 负责人变更为,ammodel,dbmode);
        }


        public int upzczy(SchoolX_资产转移流程表 model, List<int> listid, List<SchoolX_资产转移改动信息表> listmodel, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            return sql.upzczy(model, listid, listmodel,ammodel,dbmodel);
        }

        public DataSet 资产转移查询明细()
        {
            return sql.资产转移查询明细();
        }
        public DataSet 资产转移查询明细_X(School查询办公设备条件表 model)
        {
            return sql.资产转移查询明细_X(model);
        }

        public string 查询用户电话(string str)
        {
            return sql.查询用户电话(str);
        }

    }
}
