using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    public class School资产借还交接BLL
    {
        School资产借还交接SQL sql = new School资产借还交接SQL();
        public int 创建资产借还(AM_资产借还流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            return sql.创建资产借还(model, ammodel, dbmodel);
        }

        public DataSet 查询资产借还(string 流程状态)
        {
            return sql.查询资产借还(流程状态);
        }
        public DataSet 查询资产借还(string 流程状态,string 模糊查询)
        {
            return sql.查询资产借还(流程状态, 模糊查询);
        }

        public DataSet 资产借还查看详情(string strid)
        {
            return sql.资产借还查看详情(strid);
        }
        public int 操作资产借还流程(AM_资产借还流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            return sql.操作资产借还流程(model, ammodel, dbmodel);
        }

       

        //资产交接BLL
        public DataSet 查询资产交接(string str)
        {
            return sql.查询资产交接(str);
        }
        public DataSet per()
        {
            return sql.per();
        }
        public int 创建资产交接(AM_资产交接流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            return sql.创建资产交接(model, ammodel, dbmodel);
        }

        public int 操作资产交接流程(AM_资产交接流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            return sql.操作资产交接流程(model, ammodel, dbmodel);
        }
        public string 查询接收人(int id)
        {
            return sql.查询接收人(id);
        }








        //资产交接
        public AM_资产交接流程表 资产交接查看详情(int id)
        {
            return sql.资产交接查看详情(id);
        }

        //资产借还
        public AM_资产借还流程表 资产借还查看详情(int id)
        {
            return sql.资产借还查看详情(id);
        }

        public string 查借用人(int id)
        {
            return sql.查借用人(id);
        }

        public string 查询出借人(int id)
        {
            return sql.查询出借人(id);
        }

        public DataSet 借还条件(string str, string name)//我的借还与借入
        {
            return sql.借还条件(str, name);
        }
        public DataSet 借还条件按状态(string str, string name, string zt)
        {
            return sql.借还条件按状态(str, name, zt);
        }
    }
}
