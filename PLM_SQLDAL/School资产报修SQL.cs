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
    public class School资产报修SQL
    {
        public DataSet 首页_X_资产报修流程表(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM X_资产报修流程表  WHERE ID >0");
            if (str == "待派单")
            {
                sb.Append(" and 流程状态='待派单' ");
            }
            else if (str == "维修中")
            {
                sb.Append(" and 流程状态='维修中'");
            }
            else if (str == "维修完成")
            {
                sb.Append(" and 流程状态='维修完成' ");
            }
            else if (str == "已完成")
            {
                sb.Append(" and 流程状态='已完成' ");
            }
            sb.Append(" order by 流程状态,报修时间 DESC");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }

        public DataSet 首页_X_资产报修流程表(string str, string state)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM X_资产报修流程表  WHERE ID >0");
            if (str == "待派单")
            {
                sb.Append(" and 流程状态='待派单'");
            }
            else if (str == "维修中")
            {
                sb.Append(" and 流程状态='维修中'");
            }
            else if (str == "维修完成")
            {
                sb.Append(" and 流程状态='维修完成'");
            }
            else if (str == "已完成")
            {
                sb.Append(" and 流程状态='已完成'");
            }
            else if (str == "全部")
            {
                sb.Append("");
            }

            if (state == "报修大厅" || state == "")
            {
                sb.Append("");
            }
            else
            {
                sb.Append("  and 报修人='" + state + "' ");
            }
            sb.Append(" order by 流程状态,报修时间 DESC");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }

        public List<School房间信息表> cfdd()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT    *  from dbo.房间信息表");
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
                List<School房间信息表> list = new List<School房间信息表>();
                while (read.Read())
                {
                    School房间信息表 model = new School房间信息表();
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.名称 = read["名称"].ToString();
                    list.Add(model);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<用户表> listuser(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string sql = string.Format("SELECT * FROM 用户表 where 部门ID = {0} ", id);
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                List<用户表> list = new List<用户表>();
                while (read.Read())
                {
                    用户表 model = new 用户表();
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.姓名 = read["姓名"].ToString();
                    list.Add(model);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<School办公设备信息表> 资产转移确定设备(List<int> listid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("     select a.ID, a.编号 ,a.名称,a.资产状态 ,a.投入使用日期,    a.型号,a.一级类别名称 as 类型  ");
            sb.Append(" ,a.归属学校,a.归属教师ID,a.位置,a.归属部门,a.价格 ,a.数量,   ");
            sb.Append(" a.使用方向,d.学校名称, e.姓名 AS 负责人,        b.名称 AS 房间名称,c.名称 AS 部门名称 ");
            sb.Append("	from 办公设备信息表 as a , dbo.房间信息表 AS b , 一级部门表 as c,学校名称表 as d,用户表 AS e       ");
            sb.Append("  where  (");
            sb.Append(" a.ID =" + listid[0]);
            foreach (int item in listid)
            {
                sb.Append(" OR a.ID =" + item);
            }
            sb.Append(")");

            sb.Append("and a.位置 =  b.ID and  a.归属部门 = c.ID and a.位置 = b.ID and a.归属部门 = c.ID  ");
            sb.Append("  and   a.归属学校 = d.ID  and a.归属教师ID = e.ID    ");
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            List<School办公设备信息表> list = new List<School办公设备信息表>();
            while (read.Read())
            {
                School办公设备信息表 model = new School办公设备信息表();
                model.ID = Convert.ToInt32(read["ID"].ToString());
                model.编号 = read["编号"].ToString();
                model.名称 = read["名称"].ToString();
                model.资产状态 = read["资产状态"].ToString();
                if (read["投入使用日期"] != null && read["投入使用日期"].ToString() != "")
                {
                    model.投入使用日期 = read["投入使用日期"].ToString();
                }

                model.型号 = read["型号"].ToString();
                model.类型 = read["类型"].ToString();
                model.学校名称 = read["学校名称"].ToString();
                model.归属教师ID = Convert.ToInt32(read["归属教师ID"].ToString());
                model.负责人 = read["负责人"].ToString();
                model.房间名称 = read["房间名称"].ToString();
                model.部门名称 = read["部门名称"].ToString();
                if (read["价格"] != null && read["价格"].ToString() != "")
                {
                    model.价格 = Convert.ToDouble(read["价格"]);
                }

                model.数量 = Convert.ToInt32(read["数量"].ToString());
                model.使用方向 = read["使用方向"].ToString();
                model.变动金额 = 0;
                list.Add(model);
            }
            return list;
            //return sql.资产转移确定设备(listid);
        }





        public int 添加资产报修(SchoolX_资产报修流程表 model)
        {
            int sort = 1;
            
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO X_资产报修流程表 ");
                sb.Append(" (流程状态,报修单号,报修人,报修时间,报修地址,故障描述,设备ID,故障照片,Sort,报修人电话");
                sb.Append(" ) VALUES( ");
                sb.Append(" @流程状态,@报修单号,@报修人,@报修时间,@报修地址,@故障描述,@设备ID,@故障照片,"+1+",@报修人电话");
                sb.Append(")");
                sb.Append(" SELECT ");
                sb.Append(" @@identity ");
                SqlParameter[] para = {
                                       new SqlParameter("@流程状态",model.流程状态),
                                       new SqlParameter("@报修单号",model.报修单号),                            
                                       new SqlParameter("@报修人",model.报修人),
                                       new SqlParameter("@报修时间",model.报修时间),
                                       new SqlParameter("@报修地址",model.报修地址),
                                       new SqlParameter("@故障描述",model.故障描述),
                                       new SqlParameter("@设备ID",model.设备ID),
                                       new SqlParameter("@故障照片",model.故障照片),
                                       //new SqlParameter("@sort",sort),
                                       new SqlParameter("@报修人电话",model.报修人电话),
                                   };
                DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para);
                return 1;
         
        }
        public int 添加资产报修(SchoolX_资产报修流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            int sort = 1;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO X_资产报修流程表 ");
                sb.Append(" (流程状态,报修单号,报修人,报修时间,报修地址,故障描述,设备ID,故障照片,Sort,报修人电话");
                sb.Append(" ) VALUES( ");
                sb.Append(" @流程状态,@报修单号,@报修人,@报修时间,@报修地址,@故障描述,@设备ID,@故障照片,@sort,@报修人电话");
                sb.Append(")");
                sb.Append(" SELECT ");
                sb.Append(" @@identity ");
                SqlParameter[] para = {
                                       new SqlParameter("@流程状态",model.流程状态),
                                       new SqlParameter("@报修单号",model.报修单号),
                                       new SqlParameter("@报修人",model.报修人),
                                       new SqlParameter("@报修时间",model.报修时间),
                                       new SqlParameter("@报修地址",model.报修地址),
                                       new SqlParameter("@故障描述",model.故障描述),
                                       new SqlParameter("@设备ID",model.设备ID),
                                       new SqlParameter("@故障照片",model.故障照片),
                                       new SqlParameter("@sort",sort),
                                       new SqlParameter("@报修人电话",model.报修人电话),
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
                    dbsb.Append("(流程状态,FlowID,事项名称,通知内容,发起人,发起时间,处理职务,处理方式,FlowName,Sort ");
                    dbsb.Append(" ) VALUES( ");
                    dbsb.Append(" @流程状态,@FlowID,@事项名称,@通知内容,@发起人,@发起时间,@处理职务,@处理方式,@FlowName,@Sort ");
                    dbsb.Append(")");
                    SqlParameter[] dbpara = {


                                       new SqlParameter("@流程状态",dbmodel.流程状态),
                                       new SqlParameter("@FlowID",result),
                                       new SqlParameter("@事项名称",dbmodel.事项名称),
                                       new SqlParameter("@通知内容",dbmodel.通知内容),
                                       new SqlParameter("@发起人",dbmodel.发起人),
                                       new SqlParameter("@发起时间",dbmodel.发起时间),
                                       new SqlParameter("@处理职务",dbmodel.处理职务),
                                       new SqlParameter("@处理方式",dbmodel.处理方式),
                                       new SqlParameter("@FlowName",dbmodel.FlowName),
                                       new SqlParameter("@Sort",dbmodel.Sort)
                                   };
                    DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, dbsb.ToString(), dbpara);
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
                //throw;
            }
        }



        public DataSet 资产报修查看详情(int ID)
        {
            string sql = string.Format("SELECT 设备ID FROM X_资产报修流程表 WHERE ID = {0}", ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            string SID = "";
            if (read.Read())
            {
                SID = read["设备ID"].ToString();
            }
            read.Close();
            string[] condition = { "," };
            string[] result = SID.Split(condition, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            sb.Append("select  编号,一级类别名称,名称,型号,使用方向,数量,价格,资产状态 ,存放地点,归属部门1,负责人");
            sb.Append(" from 办公设备信息表 as a  where ");
            foreach (string item in result)
            {
                sb.Append(" a.ID  =" + item + " or ");
            }
            string sqlsb = sb.ToString();
            string sqly = sqlsb.Substring(0, sqlsb.Length - 3);//循环多个or 删减最后两个字符
            // sqly += ") and a.ID = b.办公设备信息表ID";





            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sqly.ToString());
        }

        public DataSet 查维修人()
        {
            string sql = string.Format("SELECT * FROM 用户表 WHERE 职务='维修人员'");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
        }
        public string 用户权限(int ID)
        {
            string sql = string.Format("SELECT 职务 FROM 用户表 WHERE ID=" + ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                string zhi = read["职务"].ToString();
                return zhi;
            }
            else
            {
                return "空";
            }
        }
        public int sort(int id)
        {
            string sql = string.Format("SELECT * FROM AM_待办业务 where ID=" + id);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                int FlowID = Convert.ToInt32(read["FlowID"]);
                string sl = string.Format("SELECT * FROM X_资产报修流程表 where ID=" + FlowID);
                SqlDataReader red = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sl.ToString());
                if (red.Read())
                {
                    int sort = Convert.ToInt32(red["Sort"]);
                    return sort;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public int 添加维修信息(int id, SchoolX_资产报修流程表 model)
        {
            try
            {
                string sql = string.Format("UPDATE X_资产报修流程表 SET 管理员电话 = '{0}',维修人员='{1}',派单时间='{2}',管理员='{3}',流程状态='{4}',Sort=2 WHERE ID = " + id, model.管理员电话, model.维修人员, model.派单时间, model.管理员, model.流程状态);
                DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        public int 添加维修信息(int id, SchoolX_资产报修流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            try
            {
                string sql = string.Format("UPDATE X_资产报修流程表 SET 管理员电话 = '{0}',维修人员='{1}',派单时间='{2}',管理员='{3}',流程状态='{4}',Sort=2 WHERE ID = " + id, model.管理员电话, model.维修人员, model.派单时间, model.管理员, model.流程状态);
                DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

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
                                       new SqlParameter("@FlowID",id)
                                   };
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);

                StringBuilder dbsb = new StringBuilder();
                dbsb.Append("update AM_待办业务 SET ");
                dbsb.Append("流程状态=@流程状态,事项名称=@事项名称,通知内容=@通知内容,发起人=@发起人,发起时间=@发起时间,处理方式=@处理方式,处理人=@处理人,Sort=@Sort WHERE FlowID= " + id+" AND FlowName=@FlowName");

                SqlParameter[] dbpara = {


                                       new SqlParameter("@流程状态",dbmodel.流程状态),
                                       new SqlParameter("@事项名称",dbmodel.事项名称),
                                       new SqlParameter("@通知内容",dbmodel.通知内容),
                                       new SqlParameter("@发起人",dbmodel.发起人),
                                       new SqlParameter("@发起时间",dbmodel.发起时间),
                                       new SqlParameter("@处理方式",dbmodel.处理方式),
                                       new SqlParameter("@处理人",dbmodel.处理人),
                                       new SqlParameter("@FlowName",dbmodel.FlowName),
                                       new SqlParameter("@Sort",dbmodel.Sort)

                                   };
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, dbsb.ToString(), dbpara);
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        public int 添加完成信息(int id, SchoolX_资产报修流程表 model)
        {
            try
            {
                string sql = string.Format("UPDATE X_资产报修流程表 SET 维修人电话='{0}',解决时间='{1}',故障原因='{2}',维修人员='{3}',流程状态='{4}',Sort=3 where ID=" + id, model.维修人电话, model.完工时间, model.故障原因, model.维修人员, model.流程状态);
                DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int 添加完成信息(int id, SchoolX_资产报修流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            try
            {
                string sql = string.Format("UPDATE X_资产报修流程表 SET 维修人电话='{0}',解决时间='{1}',故障原因='{2}',维修人员='{3}',流程状态='{4}',Sort=3 where ID=" + id, model.维修人电话, model.完工时间, model.故障原因, model.维修人员, model.流程状态);
                DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
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
                                       new SqlParameter("@FlowID",id)
                                   };
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);

                StringBuilder dbsb = new StringBuilder();
                dbsb.Append("update AM_待办业务 SET ");
                dbsb.Append("流程状态=@流程状态,事项名称=@事项名称,通知内容=@通知内容,发起人=@发起人,发起时间=@发起时间,处理人=@处理人,处理方式=@处理方式,Sort=@Sort WHERE FlowID= " + id+ " AND FlowName=@FlowName");

                SqlParameter[] dbpara = {


                                       new SqlParameter("@流程状态",dbmodel.流程状态),
                                       new SqlParameter("@事项名称",dbmodel.事项名称),
                                       new SqlParameter("@通知内容",dbmodel.通知内容),
                                       new SqlParameter("@发起人",dbmodel.发起人),
                                       new SqlParameter("@发起时间",dbmodel.发起时间),
                                       new SqlParameter("@处理人",dbmodel.处理人),
                                       new SqlParameter("@处理方式",dbmodel.处理方式),
                                       new SqlParameter("@FlowName",dbmodel.FlowName),
                                       new SqlParameter("@Sort",dbmodel.Sort)
                                   };
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, dbsb.ToString(), dbpara);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int 报修结算(int id, SchoolX_资产报修流程表 model)
        {
            try
            {
                string sql = string.Format("UPDATE X_资产报修流程表 SET 完工时间='{0}',结果反馈='{1}',流程状态='{2}',Sort=4 where ID=" + id, model.完工时间, model.结果反馈, model.流程状态);
                DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                return 1;
            }


            catch
            {
                return 0;
            }
        }
        public int 报修结算(int id, SchoolX_资产报修流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            try
            {
                string sql = string.Format("UPDATE X_资产报修流程表 SET 完工时间='{0}',结果反馈='{1}',流程状态='{2}',Sort=4 where ID=" + id, model.完工时间, model.结果反馈, model.流程状态);
                DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
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
                                       new SqlParameter("@FlowID",id)
                                   };
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);

                StringBuilder dbsb = new StringBuilder();
                dbsb.Append("update AM_待办业务 SET ");
                dbsb.Append("流程状态=@流程状态,事项名称=@事项名称,通知内容=@通知内容,发起人=@发起人,发起时间=@发起时间,处理方式=@处理方式,处理人=@处理人,FlowName=@FlowName,Sort=@Sort WHERE FlowID= " + id+ " AND FlowName=@FlowName");

                SqlParameter[] dbpara = {


                                       new SqlParameter("@流程状态",dbmodel.流程状态),
                                       new SqlParameter("@事项名称",dbmodel.事项名称),
                                       new SqlParameter("@通知内容",dbmodel.通知内容),
                                       new SqlParameter("@发起人",dbmodel.发起人),
                                       new SqlParameter("@处理人",dbmodel.处理人),
                                       new SqlParameter("@发起时间",dbmodel.发起时间),
                                       new SqlParameter("@处理方式",dbmodel.处理方式),
                                       new SqlParameter("@FlowName",dbmodel.FlowName),
                                       new SqlParameter("@Sort",dbmodel.Sort)
                                   };

                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, dbsb.ToString(), dbpara);
                return 1;
            }


            catch
            {
                return 0;
            }
        }
        public string ren(int id)
        {
            string sql = string.Format("SELECT * FROM X_资产报修流程表 WHERE ID=" + id);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                string 报修人 = read["报修人"].ToString();
                return 报修人;
            }
            else
            {
                return "wu";
            }
        }
        public SchoolX_资产报修流程表 详情(int id)
        {
            SchoolX_资产报修流程表 model = new SchoolX_资产报修流程表();
            string sql = string.Format("SELECT * FROM X_资产报修流程表 WHERE ID=" + id);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                model.管理员 = read["管理员"].ToString();
                model.完工时间 = read["完工时间"].ToString();
                model.维修人员 = read["维修人员"].ToString();
                model.报修人电话 = read["报修人电话"].ToString();
                model.故障原因 = read["故障原因"].ToString();
                model.派单时间 = read["派单时间"].ToString();
                model.管理员电话 = read["管理员电话"].ToString();
                model.结果反馈 = read["结果反馈"].ToString();
                model.维修人电话 = read["维修人电话"].ToString();
            }
            return model;
        }
        public string 报修ID查询职务(int id)
        {
            string sql = string.Format("SELECT * FROM X_资产报修流程表 WHERE ID=" + id);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                string 报修人 = read["报修人"].ToString();
                string srr = string.Format("SELECT * FROM 用户表 WHERE 姓名='{0}'",报修人);
                SqlDataReader red= DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, srr.ToString());
                if (red.Read())
                {
                    string 职务 = red["职务"].ToString();
                    return 职务;
                }
            }
            return "";
        }
    }
}
