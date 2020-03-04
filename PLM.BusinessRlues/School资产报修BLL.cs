using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    public class School资产报修BLL
    {
        School资产报修SQL sql = new School资产报修SQL();
        public DataSet 首页_X_资产报修流程表(string state)
        {
            return sql.首页_X_资产报修流程表(state);
        }

        public DataSet 首页_X_资产报修流程表(string str, string state)
        {
            return sql.首页_X_资产报修流程表(str, state);
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

        public int 添加资产报修表(SchoolX_资产报修流程表 model)
        {
            return sql.添加资产报修(model);
        }
        public int 添加资产报修表(SchoolX_资产报修流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            return sql.添加资产报修(model, ammodel, dbmodel);
        }
        public DataSet 资产报修查看详情(int ID)
        {
            return sql.资产报修查看详情(ID);
        }
        public DataSet 查维修人()
        {
            return sql.查维修人();
        }
        public string 用户权限(int ID)
        {
            return sql.用户权限(ID);
        }
        public int sort(int id)
        {
            return sql.sort(id);
        }
        public int 添加维修信息(int id, SchoolX_资产报修流程表 model)
        {
            return sql.添加维修信息(id, model);
        }
        public int 添加维修信息(int id, SchoolX_资产报修流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            return sql.添加维修信息(id, model, ammodel, dbmodel);
        }
        public int 添加完成信息(int id, SchoolX_资产报修流程表 model)
        {
            return sql.添加完成信息(id, model);
        }
        public int 添加完成信息(int id, SchoolX_资产报修流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            return sql.添加完成信息(id, model, ammodel, dbmodel);
        }
        public int 报修结算(int id, SchoolX_资产报修流程表 model)
        {
            return sql.报修结算(id, model);
        }
        public int 报修结算(int id, SchoolX_资产报修流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            return sql.报修结算(id, model, ammodel, dbmodel);
        }
        public string ren(int id)
        {
            return sql.ren(id);
        }
        public SchoolX_资产报修流程表 详情(int id)
        {
            return sql.详情(id);
        }
        public string 报修ID查询职务(int id)
        {
            return sql.报修ID查询职务(id);
        }
    }
}
