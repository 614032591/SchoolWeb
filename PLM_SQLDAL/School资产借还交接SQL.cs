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
    public class School资产借还交接SQL
    {
        public int 创建资产借还(AM_资产借还流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO AM_资产借还流程表 ");
            sb.Append(" (流程状态,Sort,发起人,借用人,提交时间,预计归还时间,单据编号,借出人,借用时间,备注信息,资产ID,资产数量");
            sb.Append(" ) VALUES( ");
            sb.Append(" @流程状态,@Sort,@发起人,@借用人,@提交时间,@预计归还时间,@单据编号,@借出人,@借用时间,@备注信息,@资产ID,@资产数量");
            sb.Append(")");
            sb.Append(" SELECT ");
            sb.Append(" @@identity ");
            SqlParameter[] para = {
                                       new SqlParameter("@流程状态",model.流程状态),
                                       new SqlParameter("@Sort",model.Sort),
                                       new SqlParameter("@发起人",model.发起人),
                                       new SqlParameter("@借用人",model.借用人),
                                       new SqlParameter("@提交时间",model.提交时间),
                                       new SqlParameter("@预计归还时间",model.预计归还时间),
                                       new SqlParameter("@单据编号",model.单据编号),
                                       new SqlParameter("@借出人",model.借出人),
                                       new SqlParameter("@借用时间",model.借用时间),
                                       new SqlParameter("@备注信息",model.备注信息),
                                       new SqlParameter("@资产ID",model.资产ID),
                                        new SqlParameter("@资产数量",model.资产数量),
                                   };
            int result = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para));
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

                //DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);
                StringBuilder dbsb = new StringBuilder();
                dbsb.Append("INSERT INTO AM_待办业务 ");
                dbsb.Append("(流程状态,FlowID,事项名称,通知内容,发起人,发起时间,处理人,处理方式,Sort,FlowName ");
                dbsb.Append(" ) VALUES( ");
                dbsb.Append(" @流程状态,@FlowID,@事项名称,@通知内容,@发起人,@发起时间,@处理人,@处理方式,@Sort,@FlowName ");
                dbsb.Append(")");
                SqlParameter[] dbpara = {


                                       new SqlParameter("@流程状态",dbmodel.流程状态),
                                       new SqlParameter("@FlowID",result),
                                       new SqlParameter("@事项名称",dbmodel.事项名称),
                                       new SqlParameter("@通知内容",dbmodel.通知内容),
                                       new SqlParameter("@发起人",dbmodel.发起人),
                                       new SqlParameter("@发起时间",dbmodel.发起时间),
                                       new SqlParameter("@处理人",dbmodel.处理人),
                                       new SqlParameter("@处理方式",dbmodel.处理方式),
                                       new SqlParameter("@Sort",dbmodel.Sort),
                                       new SqlParameter("@FlowName",dbmodel.FlowName)
                                   };
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, dbsb.ToString(), dbpara);
                return result;
            }
            else
            {
                return 0;
            }
        }



        public DataSet 查询资产借还(string 流程状态)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select  * from  AM_资产借还流程表");
            sb.Append("  where  ID>0  ");
            if (流程状态 == "流程状态-待审核")
            {
                sb.Append(" and 流程状态='待审核'");
            }
            else if (流程状态 == "流程状态-已完成")
            {
                sb.Append(" and 流程状态='已完成'");
            }
            //sb.Append(" and 事项名称 !=''");
            //SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }


        public DataSet 查询资产借还(string 流程状态, string 模糊查询)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select  * from  AM_资产借还流程表");
            sb.Append("  where  ID>0  ");
            if (流程状态 == "流程状态-全部")
            {
                sb.Append(" ");
            }
            else if (流程状态 == "完成")
            {
                sb.Append(" and 流程状态='完成'");
            }else if (流程状态 == "已提交")
            {
                sb.Append(" and 流程状态='已提交'");
            }else if (流程状态 == "已出借,待归还")
            {
                sb.Append(" and 流程状态='已出借,待归还'");
            }
            if (模糊查询 != "")
            {
                sb.Append("  and( 单据编号 like '%"+ 模糊查询 + "%' or 借用人 like '%" + 模糊查询 + "%' or 借出人 like '%" + 模糊查询 + "%')");
            }
            
            //sb.Append(" and 事项名称 !=''");
            //SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }

        public int 操作资产借还流程(AM_资产借还流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            try
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
                                       new SqlParameter("@FlowID",ammodel.FlowID)
                                   };

                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);

                if (model.Sort == 1)//同意借出
                {
                    string sql = string.Format("UPDATE AM_资产借还流程表 SET 是否同意 ='{0}' ,借出人操作时间 = '{1}' , 操作人 = '{2}',Sort=2 ,流程状态='已出借,待归还' where ID = {3}", model.是否同意, model.借出人操作时间, model.操作人, model.ID);
                    DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                    string strid = model.资产ID;
                    strid = strid.Substring(0, strid.Length - 1);//删除最后一个字符
                    string[] arr = strid.Split(',');
                    List<string> worklist = new List<string>();
                    string workstr = "";
                    foreach (string item in arr)
                    {
                        workstr = string.Format("   UPDATE 办公设备信息表 SET 借用 = {0}  where ID = {1}", 1, item);
                        worklist.Add(workstr.ToString());
                    }
                    DBHelper.ExecuteSqlTran(worklist);

                }
                else if (model.Sort == 2)//已归还待确认
                {
                    string sql = string.Format("UPDATE AM_资产借还流程表 SET 申请人是否归还 ='{0}' ,申请人归还时间 = '{1}' ,Sort=3 ,流程状态='已归还,待确认' where ID = {2}", model.申请人是否归还, model.申请人归还时间, model.ID);
                    DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                }
                else if (model.Sort == 3) //完成
                {
                    string sql = string.Format("UPDATE AM_资产借还流程表 SET 出借人确认归还 ='{0}' ,出借人确认时间 = '{1}' ,Sort=0 ,流程状态='完成' where ID = {2}", model.出借人确认归还, model.出借人确认时间, model.ID);
                    DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                }
                string sqlup = string.Format("UPDATE AM_待办业务 SET 流程状态='{0}',通知内容 ='{1}' ,处理方式='{2}',处理人='{3}',Sort='{4}' where FlowID = {5} and FlowName='{6}'", dbmodel.流程状态, dbmodel.通知内容, dbmodel.处理方式, dbmodel.处理人, dbmodel.Sort, dbmodel.FlowID, dbmodel.FlowName);
                return DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sqlup.ToString());
            }
            catch (Exception)
            {
                return 0;
            }





        }

        public DataSet 资产借还查看详情(string strid)
        {
            strid = strid.Substring(0, strid.Length - 1);//删除最后一个字符
            string[] arr = strid.Split(',');
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  办公设备信息表.ID, 办公设备信息表.编号 ,办公设备信息表.名称,办公设备信息表.资产状态 ,办公设备信息表.投入使用日期, ");
            sb.Append("  办公设备信息表.型号,办公设备信息表.类型 as 类型  ,办公设备信息表.归属学校,办公设备信息表.归属教师ID");
            sb.Append(" ,办公设备信息表.位置,办公设备信息表.归属部门, 办公设备信息表.价格 ,办公设备信息表.数量,办公设备信息表.使用方向,d.学校名称");
            sb.Append(" , e.姓名 AS 负责人,         b.名称 AS 房间名称,c.名称 AS 部门名称 from 办公设备信息表 , 房间信息表 AS b     ");
            sb.Append(", 一级部门表 as c,学校名称表 as d,用户表 AS e  where 办公设备信息表.位置 =  b.ID ");
            sb.Append("   and  办公设备信息表.归属部门 = c.ID and 办公设备信息表.位置 =  b.ID   and 办公设备信息表.归属部门 = c.ID  ");
            sb.Append("     and       办公设备信息表.归属学校 = d.ID        and 办公设备信息表.归属教师ID = e.ID");


            sb.Append(" and ( ");
            int kz = 0;
            foreach (string item in arr)
            {
                if (kz == 0)
                {
                    //第一次进循环
                    sb.Append(" 办公设备信息表.ID= " + item);
                }
                else
                {
                    sb.Append(" or 办公设备信息表.ID= " + item);
                }
                kz++;
            }
            sb.Append(") ");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }


        public DataSet per()
        {
            string sql = string.Format("select * from 用户表 where ID>0");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
        }

        public DataSet 查询资产交接(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select  * from  AM_资产交接流程表");
            sb.Append("  where  ID>0  ");
            if (str == "流程状态-待审核")
            {
                sb.Append(" and 流程状态='待审核'");
            }
            else if (str == "流程状态-已完成")
            {
                sb.Append(" and 流程状态='已完成'");
            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }


        public int 创建资产交接(AM_资产交接流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO AM_资产交接流程表 ");
            sb.Append(" (流程状态,Sort,发起人,单据编号,资产数量,交付人,接收人,提交时间,备注信息,完成时间,资产ID");
            sb.Append(" ) VALUES( ");
            sb.Append(" @流程状态,@Sort,@发起人,@单据编号,@资产数量,@交付人,@接收人,@提交时间,@备注信息,@完成时间,@资产ID");
            sb.Append(")");
            sb.Append(" SELECT ");
            sb.Append(" @@identity ");
            SqlParameter[] para = {
                                       new SqlParameter("@流程状态",model.流程状态),
                                       new SqlParameter("@Sort",model.Sort),
                                       new SqlParameter("@发起人",model.发起人),
                                       new SqlParameter("@单据编号",model.单据编号),
                                       new SqlParameter("@资产数量",model.资产数量),
                                       new SqlParameter("@交付人",model.交付人),
                                       new SqlParameter("@接收人",model.接收人),
                                       new SqlParameter("@提交时间",model.提交时间),
                                       new SqlParameter("@备注信息",model.备注信息),
                                       new SqlParameter("@完成时间",model.完成时间),
                                       new SqlParameter("@资产ID",model.资产ID),
                                   };
            int result = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para));
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

                //DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);
                StringBuilder dbsb = new StringBuilder();
                dbsb.Append("INSERT INTO AM_待办业务 ");
                dbsb.Append("(流程状态,FlowID,处理方式,通知内容,发起人,发起时间,FlowName,处理人,Sort,事项名称 ");
                dbsb.Append(" ) VALUES( ");
                dbsb.Append(" @流程状态,@FlowID,@处理方式,@通知内容,@发起人,@发起时间,@FlowName,@处理人,@Sort,@事项名称 ");
                dbsb.Append(")");
                SqlParameter[] dbpara = {


                                       new SqlParameter("@流程状态",dbmodel.流程状态),
                                       new SqlParameter("@FlowID",result),
                                       new SqlParameter("@处理方式",dbmodel.处理方式),
                                       new SqlParameter("@通知内容",dbmodel.通知内容),
                                       new SqlParameter("@发起人",dbmodel.发起人),
                                       new SqlParameter("@发起时间",dbmodel.发起时间),
                                       new SqlParameter("@处理人",dbmodel.处理人),
                                       new SqlParameter("@Sort",dbmodel.Sort),
                                       new SqlParameter("@事项名称",dbmodel.事项名称),
                                       new SqlParameter("@FlowName",dbmodel.FlowName)
                                   };
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, dbsb.ToString(), dbpara);
                return result;
            }
            else
            {
                return 0;
            }
        }


        public int 操作资产交接流程(AM_资产交接流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            try
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
                                       new SqlParameter("@FlowID",ammodel.FlowID)
                                   };

                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);

                if (model.Sort == 1)//接收
                {
                    string sql = string.Format("UPDATE AM_资产交接流程表 SET 是否接收 ='{0}' ,接收人接收时间 = '{1}' , 接收人 = '{2}',Sort=2 ,流程状态='已接收,待确认' where ID = {3}", model.是否接收, model.接收人接收时间, model.接收人, model.ID);
                    DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                    string sdd = string.Format("SELECT ID FROM 用户表 WHERE 姓名='{0}'", model.接收人);
                    SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sdd.ToString());
                    int 用户ID;
                    if (read.Read())
                    {
                        用户ID = Convert.ToInt32(read["ID"]);
                        string swww = string.Format("SELECT * FROM AM_资产交接流程表 WHERE ID='{0}'",model.ID);
                        SqlDataReader wwread = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, swww.ToString());
                        if (wwread.Read())
                        {
                            string 资产ID = wwread["资产ID"].ToString();
                            
                            string[] zcid = 资产ID.Split(',');
                            for(int i = 0; i < zcid.Length-1; i++)
                            {
                                if (zcid[i] != "" || zcid[i] != null)
                                {
                                    int xx = Convert.ToInt32(zcid[i]);
                                    string sqd = string.Format("UPDATE 办公设备信息表 SET 归属教师ID=" + 用户ID + " where ID=" + xx);
                                    DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sqd.ToString());
                                }
                                
                            }
                        }
                        
                    }
                }
                else if (model.Sort == 2) //管理员确认完成
                {
                    string sql = string.Format("UPDATE AM_资产交接流程表 SET 管理员 ='{0}' ,管理员通过时间 = '{1}',管理员是否通过='{2}' ,Sort=0 ,流程状态='完成' where ID = {3}", model.管理员, model.管理员通过时间, model.管理员是否通过, model.ID);
                    DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                }
                string sqlup = string.Format("UPDATE AM_待办业务 SET 流程状态='{0}',通知内容 ='{1}' ,处理职务='{2}',Sort='{3}',处理方式='{4}' where FlowID = {5} and FlowName='资产交接'", dbmodel.流程状态, dbmodel.通知内容, dbmodel.处理职务,dbmodel.Sort,dbmodel.处理方式, dbmodel.FlowID);
                DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sqlup.ToString());
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }





        }


        public string 查询接收人(int id)
        {
            string sql = string.Format("SELECT * FROM AM_资产交接流程表 WHERE ID='{0}'", id);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                return read["接收人"].ToString();
            }
            else
            {
                return "空";
            }
        }


        //资产交接

        #region  资产交接查看详情  
        public AM_资产交接流程表 资产交接查看详情(int id)
        {
            AM_资产交接流程表 model = new AM_资产交接流程表();
            string sql = string.Format("SELECT * FROM AM_待办业务 WHERE ID=" + id + "AND FlowName='资产交接'");
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                int 交接ID = Convert.ToInt32(read["FlowID"]);
                string srr = string.Format("SELECT * FROM AM_资产交接流程表 WHERE ID=" + 交接ID);
                SqlDataReader red = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, srr.ToString());
                if (red.Read())
                {
                    model.流程状态 = red["流程状态"].ToString();
                    model.交付人 = red["交付人"].ToString();
                    model.提交时间 = red["提交时间"].ToString();
                    model.完成时间 = red["完成时间"].ToString();
                    model.单据编号 = red["单据编号"].ToString();
                    model.接收人 = red["接收人"].ToString();
                    model.备注信息 = red["备注信息"].ToString();
                    model.资产ID = red["资产ID"].ToString();
                    model.ID = Convert.ToInt32(red["ID"]);
                    model.Sort = Convert.ToInt32(red["Sort"]);
                    return model;
                }
            }
            return model;
        }
        #endregion

        #region  资产借还查看详情  
        public AM_资产借还流程表 资产借还查看详情(int id)
        {
            AM_资产借还流程表 model = new AM_资产借还流程表();
            string sql = string.Format("SELECT * FROM AM_待办业务 WHERE ID=" + id + " AND FlowName='资产借还'");
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                int 借还ID = Convert.ToInt32(read["FlowID"]);
                string sdd = string.Format("SELECT * FROM AM_资产借还流程表 WHERE ID=" + 借还ID);
                SqlDataReader red = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sdd.ToString());
                if (red.Read())
                {
                    model.流程状态 = red["流程状态"].ToString();
                    model.单据编号 = red["单据编号"].ToString();
                    model.借用人 = red["借用人"].ToString();
                    model.借出人 = red["借出人"].ToString();
                    model.提交时间 = red["提交时间"].ToString();
                    model.借用时间 = red["借用时间"].ToString();
                    model.预计归还时间 = red["预计归还时间"].ToString();
                    model.备注信息 = red["备注信息"].ToString();
                    model.资产ID = red["资产ID"].ToString();
                    model.Sort = Convert.ToInt32(red["Sort"]);
                    model.ID = Convert.ToInt32(red["ID"]);
                    return model;
                }
            }
            return model;
        }

        #endregion

        #region 查看借用人
        public string 查借用人(int id)
        {
            string sql = string.Format("SELECT * FROM AM_资产借还流程表 WHERE ID=" + id);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                string str = read["借用人"].ToString();
                return str;
            }
            return "空";
        }

        #endregion


        #region 查询出借人
        public string 查询出借人(int id)
        {
            string sql = string.Format("SELECT * FROM AM_资产借还流程表 WHERE ID=" + id);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                string str = read["借出人"].ToString();
                return str;
            }
            return "空";
        }
        #endregion

        #region 借出与借入
        public DataSet 借还条件(string str, string name)

        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM AM_资产借还流程表");
            if (str == "我的借入")
            {
                sb.Append(" where 借用人='" + name + "'");
            }
            else if (str == "我的借出")
            {
                sb.Append(" where 借出人='" + name + "'");
            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }
        #endregion

        #region 借还条件按状态
        public DataSet 借还条件按状态(string str, string name, string zt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM AM_资产借还流程表");
            if (str == "我的借入")
            {
                sb.Append(" where 借用人='" + name + "'");
                if (zt != "全部")
                {
                    sb.Append(" AND 流程状态='" + zt + "'");
                }

            }
            else if (str == "我的借出")
            {
                sb.Append(" where 借出人='" + name + "'");
                if (zt != "全部")
                {
                    sb.Append(" AND 流程状态='" + zt + "'");
                }
            }
            else if (str == "借还大厅")
            {
                if (zt != "全部")
                {
                    sb.Append(" WHERE 流程状态='" + zt + "'");
                }
            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }
        #endregion

    }
}
