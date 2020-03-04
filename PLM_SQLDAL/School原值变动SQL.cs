using PLM_Common;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PLM_SQLDAL
{
    public class School原值变动SQL
    {
        public DataSet 首页_X_原值变动流程表(string state)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select  * from  X_原值变动流程表");
            sb.Append("  where  ID>0  ");
            if (state == "流程状态-待审核")
            {
                sb.Append(" and 流程状态='待审核'");
            }
            else if (state == "流程状态-已完成")
            {
                sb.Append(" and 流程状态='已完成'");
            }
            sb.Append(" and 事项名称 !=''");
            //SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }

        public DataSet 原值变动查看详情(string strid)
        {
            strid = strid.Substring(0, strid.Length - 1);//删除最后一个字符
            string[] arr = strid.Split(',');
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT * FROM 办公设备信息表 where ( ");
            int kz = 0;
            foreach (string item in arr)
            {
                if(kz==0)
                {
                    //第一次进循环
                    sb.Append(" ID= "+item);
                }else
                {
                    sb.Append(" or ID= "+item);
                }
                kz++;
            }
            sb.Append(") ");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }


        //价格变动统计查询
        public DataSet 首页_X_价格变动流程表(string sSearch, string flowstate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select  * from  X_原值变动流程表");
            sb.Append("  where  ID>0  ");
            if (flowstate == "流程状态-待审核")
            {
                sb.Append(" and 流程状态='待审核'");
            }
            else if (flowstate == "流程状态-已完成")
            {
                sb.Append(" and 流程状态='已完成'");
            }
            if (sSearch == "")
            {
                sb.Append("");
            }
            else
            {
                sb.Append(" and 事项名称 like '%" + sSearch + "%'");
            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }

        public int 操作原值变动流程(SchoolX_原值变动流程表 model, AM_提醒通知 ammodel)
        {
            string sql = string.Format("UPDATE X_原值变动流程表 SET 是否同意 ='{0}' ,操作时间 = '{1}' , 操作人 = '{2}',Sort=2 ,流程状态='完成' where ID = {3}", model.是否同意, model.操作时间, model.操作人, model.ID);
           
            StringBuilder sbtz = new StringBuilder();
            sbtz.Append("INSERT INTO AM_提醒通知 ");
            sbtz.Append("(消息事项,消息内容,发起人,发起时间,通知类型,是否已读,通知职务,FlowID ");
            sbtz.Append(" ) VALUES( ");
            sbtz.Append(" @消息事项,@消息内容,@发起人,@发起时间,@通知类型,@是否已读,@通知职务,@FlowID ");
            sbtz.Append(")");
            SqlParameter[] paratz = {
                                       

                                       new SqlParameter("@消息事项",ammodel.消息事项),
                                       new SqlParameter("@消息内容",ammodel.消息内容),
                                       new SqlParameter("@发起人",ammodel.发起人),
                                       new SqlParameter("@发起时间",ammodel.发起时间),
                                       new SqlParameter("@通知类型",ammodel.通知类型),
                                       new SqlParameter("@是否已读",ammodel.是否已读),
                                       new SqlParameter("@通知职务",ammodel.通知职务),
                                       new SqlParameter("@FlowID",ammodel.FlowID)
                                   };
            DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);
            return DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

        }
        public int 新增原值变动(SchoolX_原值变动流程表 model ,List<School办公设备信息表> workmodel,AM_提醒通知 ammodel,AM_待办业务 dbmodel) 
        {


            string sql = string.Format("INSERT INTO X_原值变动流程表 (流程状态,单据编号,事项名称,申请人,申请日期,记账人,总数,总价,变动方式,变动原因,记账人意见,备注信息,资产ID,str变动金额,Sort)VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}','{9}','{10}','{11}','{12}','{13}','{14}')SELECT  @@identity", model.流程状态, model.单据编号, model.事项名称, model.申请人, model.申请日期, model.记账人, model.总数, model.总价, model.变动方式, model.变动原因, model.记账人意见, model.备注, model.资产ID, model.str变动金额, 1);
            int result = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql));

            if (result > 0)
            {

                StringBuilder sbtz = new StringBuilder();
                sbtz.Append("INSERT INTO AM_提醒通知 ");
                sbtz.Append("(消息事项,消息内容,发起人,发起时间,通知类型,是否已读,通知职务,FlowID ");
                sbtz.Append(" ) VALUES( ");
                sbtz.Append(" @消息事项,@消息内容,@发起人,@发起时间,@通知类型,@是否已读,@通知职务,@FlowID ");
                sbtz.Append(")");
                SqlParameter[] paratz = {
                                       new SqlParameter("@消息事项",ammodel.消息事项),
                                       new SqlParameter("@消息内容",ammodel.消息内容),
                                       new SqlParameter("@发起人",ammodel.发起人),
                                       new SqlParameter("@发起时间",ammodel.发起时间),
                                       new SqlParameter("@通知类型",ammodel.通知类型),
                                       new SqlParameter("@是否已读",ammodel.是否已读),
                                       new SqlParameter("@通知职务",ammodel.通知职务),
                                       new SqlParameter("@FlowID",result)
                                   };
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);
                StringBuilder dbsb = new StringBuilder();
                dbsb.Append("INSERT INTO AM_待办业务 ");
                dbsb.Append("(流程状态,FlowID,事项名称,通知内容,发起人,发起时间,处理职务 ");
                dbsb.Append(" ) VALUES( ");
                dbsb.Append(" @流程状态,@FlowID,@事项名称,@通知内容,@发起人,@发起时间,@处理职务 ");
                dbsb.Append(")");
                SqlParameter[] dbpara = {
                                       

                                       new SqlParameter("@流程状态",dbmodel.流程状态),
                                       new SqlParameter("@FlowID",result),
                                       new SqlParameter("@事项名称",dbmodel.事项名称),
                                       new SqlParameter("@通知内容",dbmodel.通知内容),
                                       new SqlParameter("@发起人",dbmodel.发起人),
                                       new SqlParameter("@发起时间",dbmodel.发起时间),
                                       new SqlParameter("@处理职务",dbmodel.处理职务)
                                   };
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, dbsb.ToString(), dbpara);


                List<string> worklist = new List<string>();
                string workstr = "";
                for (int i = 0; i < workmodel.Count; i++)
                {
                    workstr = string.Format("   UPDATE 办公设备信息表 SET 变动金额 = {0}  where ID = {1}", workmodel[i].变动金额, workmodel[i].ID);
                    worklist.Add(workstr.ToString());
                }
                return DBHelper.ExecuteSqlTran(worklist);
            }
            else 
            {
                return 0;
            }


          
        }
    }
}
