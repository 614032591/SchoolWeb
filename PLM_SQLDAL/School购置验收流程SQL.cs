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
    public class School购置验收流程SQL
    {
        public DataSet DataSet购置验收查询(string flowstate,string startname,string duty)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT * FROM X_购置验收流程表  WHERE ID >0");
            if (flowstate == "流程状态-待审核")
            {
                sb.Append(" and 流程状态='待审核'");
            }
            else if (flowstate == "流程状态-已通过")
            {
                sb.Append(" and 流程状态='已通过'");
            }
            else if (flowstate == "流程状态-未通过")
            {
                sb.Append(" and 流程状态='未通过'");
            }
            //if (duty != "财务人员")
            //{
            //    sb.Append(" and 申请人 = '" + startname + "'");
            //}
            //else 
            //{

            //}

            //sb.Append(" and 流程状态 ='待审核'");

            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }

        public int 操作购置验收流程(SchoolX_购置验收流程表 model, AM_提醒通知 ammodel)
        {
            string sql = string.Format("UPDATE X_购置验收流程表 SET 是否同意 ='{0}' ,操作时间 = '{1}' , 操作人 = '{2}',Sort=0 ,流程状态='完成',记账人='{3}' where ID = {4}",model.是否同意,model.操作时间,model.操作人,model.记账人,model.ID);
            string sqlzc = string.Format("UPDATE 办公设备信息表 SET 是否通过审批='{0}' where  X_ID={1}", model.是否同意,model.ID);


            AM_待办业务 dbmodel = new AM_待办业务();
            dbmodel.流程状态 = "完成";
            dbmodel.通知内容 = "您来自" + model.操作人 + "的购置验收结果通知！";
            dbmodel.处理职务 = "财政人员";
            dbmodel.处理方式 = "职务";
            //dbmodel.发起时间 = DateTime.Now.ToLongDateString();
            dbmodel.处理人 = "财政人员";
            dbmodel.Sort = 0;
            dbmodel.FlowID = model.ID;
            dbmodel.事项名称 = "购置验收";
            dbmodel.FlowName = dbmodel.事项名称;

            SchoolUtility.修改待办中心(dbmodel);


            //StringBuilder dbsb = new StringBuilder();
            //dbsb.Append("update AM_待办业务 SET ");
            //dbsb.Append("流程状态=@流程状态,通知内容=@通知内容,处理人=@处理人,发起时间=@发起时间,处理方式=@处理方式,处理职务=@处理职务,Sort=@Sort WHERE FlowID= " + model.ID + " AND FlowName='资产转移'");

            //SqlParameter[] dbpara = {


            //                           new SqlParameter("@流程状态",dbmodel.流程状态),

            //                           new SqlParameter("@通知内容",dbmodel.通知内容),
            //                           new SqlParameter("@处理人",dbmodel.处理人),
            //                           new SqlParameter("@发起时间",dbmodel.发起时间),
            //                           new SqlParameter("@处理方式",dbmodel.处理方式),
            //                           new SqlParameter("@处理职务",dbmodel.处理职务),

            //                           new SqlParameter("@Sort",dbmodel.Sort)

            //                       };
            //DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, dbsb.ToString(), dbpara);





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
            DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sqlzc.ToString());
            return DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

        }


        public int 插入X_购置验收流程表(SchoolX_购置验收流程表 model, List<School办公设备信息表> listmodel,AM_提醒通知 ammodel)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO X_购置验收流程表 ");
                sb.Append(" (流程状态,单据编号,事项名称,备注信息,数量合计,金额合计,申请人,制单日期,供应商,供应商联系方式,合同编号,发票号 ");
                sb.Append(",取得方式,购置日期,Sort");
                sb.Append(" ) VALUES( ");
                sb.Append(" @流程状态,@单据编号,@事项名称,@备注信息,@数量合计,@金额合计,@申请人,@制单日期,@供应商,@供应商联系方式,@合同编号,@发票号 ");
                sb.Append(",@取得方式,@购置日期,@Sort");
                sb.Append(")");
                sb.Append(" SELECT ");
                sb.Append(" @@identity ");
                SqlParameter[] para = {
                                       

                                       new SqlParameter("@流程状态",model.流程状态),
                                       new SqlParameter("@单据编号",model.单据编号),
                                       new SqlParameter("@事项名称",model.事项名称),
                                       new SqlParameter("@备注信息",model.备注信息),
                                       new SqlParameter("@数量合计",model.数量合计),
                                       new SqlParameter("@金额合计",model.金额合计),
                                       new SqlParameter("@申请人",model.申请人),
                                       new SqlParameter("@制单日期",model.制单日期),
                                       new SqlParameter("@供应商",model.供应商),
                                       new SqlParameter("@供应商联系方式",model.供应商联系方式),
                                       new SqlParameter("@合同编号",model.合同编号),
                                       new SqlParameter("@发票号",model.发票号),                                      
                                       
                                       new SqlParameter("@取得方式",model.取得方式),
                                       new SqlParameter("@购置日期",model.购置日期),                                     
                                       new SqlParameter("@Sort",1),
                                       //new SqlParameter("@Sort",model),
                                   };


                int num = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para));

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
                                       new SqlParameter("@发起时间",model.购置日期),
                                       new SqlParameter("@通知类型",ammodel.通知类型),
                                       new SqlParameter("@是否已读",ammodel.是否已读),
                                       new SqlParameter("@通知职务",ammodel.通知职务),
                                       new SqlParameter("@FlowID",num)
                                   };
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);


                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.处理职务 = "财务人员";
                dbmodel.发起人 = model.申请人;
                dbmodel.FlowID = num;
                dbmodel.流程状态 = model.流程状态;
                dbmodel.事项名称 = "购置验收";
                dbmodel.通知内容 = "您来自" + model.申请人 + "的购置验收/入库-申请,请及时处理！";
                dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                dbmodel.处理方式 = "职务";
                dbmodel.处理人 = "财务人员";
                dbmodel.FlowName = "购置验收";
                dbmodel.Sort = 1;
                SchoolUtility.插入待办中心(dbmodel);


                List<string> cstrlist = new List<string>();
                string csqls = "";
                string csssqls = "";

                if (num > 0)
                {
                    try
                    {
                        for (int i = 0; i < listmodel.Count; i++)
                        {
                            string part = listmodel[i].str归属部门;
                            csssqls = string.Format(" SELECT * FROM dbo.一级部门表  WHERE 名称= '" + part + "'");
                            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, csssqls.ToString());
                            List<School办公设备信息表> list = new List<School办公设备信息表>();
                            int 归属部门_ID = 0;
                            while (read.Read())
                            {
                                School办公设备信息表 model_a = new School办公设备信息表();
                                model_a.ID = Convert.ToInt32(read["ID"].ToString());
                                归属部门_ID = model_a.ID;
                            }


                            //int 归属部门_ID = model_a.ID;
                            csqls = string.Format("INSERT INTO 办公设备信息表 (编号,类型,名称,型号,使用方向,数量,价格,归属部门,负责人,存放地点,使用状态,X_ID,是否通过审批,购置日期,二级类别名称,三级类别名称) VALUES('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},'{8}','{9}','{10}',{11},'{12}','{13}','{14}','{15}')", listmodel[i].编号, listmodel[i].一级类别名称, listmodel[i].名称, listmodel[i].型号, listmodel[i].使用方向, listmodel[i].数量, listmodel[i].价格, 归属部门_ID, listmodel[i].负责人, listmodel[i].存放地点, listmodel[i].资产状态, num, "否", model.购置日期,listmodel[i].二级类别名称,listmodel[i].三级类别名称);
                            cstrlist.Add(csqls.ToString());
                        }
                        int copyunitcount = DBHelper.ExecuteSqlTran(cstrlist);
                        return copyunitcount;
                    }
                    catch (Exception)
                    {
                        return -1;//转换数字出错
                        throw;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
                //throw;
            }


        }


        public DataSet 购置验收查询设备(int xid)
        {
            //string sql = string.Format("SELECT ID, 编号,类型,名称,型号,使用方向,数量,价格,归属部门,负责人,存放地点,资产状态 FROM dbo.办公设备信息表 WHERE X_ID = {0}", xid);
            string sql = string.Format("SELECT a.ID, a.编号,a.类型,a.名称,a.型号,a.使用方向,a.数量,a.价格,b.名称 as 归属部门,a.负责人,a.存放地点,a.资产状态 FROM dbo.办公设备信息表 as a,一级部门表 as b WHERE   a.归属部门=b.ID and X_ID ={0}", xid);
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

            //    SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            //    List<办公设备信息表> list = new List<办公设备信息表>();
            //    while (read.Read())
            //    {
            //        办公设备信息表 model = new 办公设备信息表();
            //        model.ID = Convert.ToInt32(read["ID"]);
            //        model.编号 = read["编号"].ToString();
            //        model.名称 = read["名称"].ToString();
            //        model.类型 = read["类型"].ToString();
            //        model.型号 = read["型号"].ToString();
            //        model.使用方向 = read["使用方向"].ToString();
            //        model.数量 = Convert.ToInt32(read["数量"].ToString());
            //        model.价格 = Convert.ToDouble(read["价格"].ToString());
            //        model.归属部门 = Convert.ToInt32(read["归属部门"].ToString());
            //        model.负责人 = read["负责人"].ToString();

            //        model.存放地点 = read["存放地点"].ToString();
            //        model.资产状态 = read["资产状态"].ToString();

            //        list.Add(model);
            //    }

            //    return list;

        }

        public DataSet 购置验收查询明细()
        {
            string xid = "";
            string sql = "SELECT * FROM dbo.办公设备信息表";
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            while (read.Read())
            {
                if (read["X_ID"].ToString() == "")
                {
                    xid += read["X_ID"].ToString();
                }
                else
                {
                    xid += read["X_ID"].ToString() + ",";
                }

            }
            read.Close();
            string SID = xid.Substring(0, xid.Length - 1);
            StringBuilder sb = new StringBuilder();
    
            sb.Append("SELECT  a.ID, a.编号 ,a.名称,a.资产状态 ,a.投入使用日期,a.型号,a.一级类别名称 as 类型  ,a.负责人,a.存放地点,a.归属学校,a.归属教师ID,a.位置, a.价格 ,a.数量,a.使用方向, ");
            sb.Append("  a.投入使用日期,c.名称 AS 部门名称 from 办公设备信息表 as a , 一级部门表 as c  where  a.归属部门 = c.ID   ");
            if (xid != "")
            {

                sb.Append(" and a.X_ID in(" + SID + ")");

            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }
    }
}
