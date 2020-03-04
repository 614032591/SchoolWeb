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
    public class School资产转移SQL
    {

        public DataSet 首页_X_资产转移流程表(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM X_资产转移流程表  WHERE ID >0");
            if (str == "流程状态-待审核")
            {
                sb.Append(" and 流程状态='待审核'");
            }
            else if (str == "流程状态-已完成")
            {
                sb.Append(" and 流程状态='已完成'");
            }
            sb.Append(" and 事项名称 !=''");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }


        public DataSet 资产转移查看详情(int ID)
        {
            string sql = string.Format("SELECT * FROM dbo.X_资产转移流程表 WHERE ID = {0}", ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            string SID = "";
            if (read.Read())
            {
                SID = read["S_ID"].ToString();
            }
            read.Close();
            string[] condition = { "," };
            string[] result = SID.Split(condition, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            sb.Append("select  编号,一级类别名称,名称,型号,使用方向,数量,价格,资产状态 ,原存放地点,原归属部门,原负责人");
            sb.Append(" from 办公设备信息表 as a ,[X_资产转移改动信息表] as b   where (");
            foreach (string item in result)
            {
                sb.Append(" a.ID  =" + item + " or ");
            }
            string sqlsb = sb.ToString();
            string sqly = sqlsb.Substring(0, sqlsb.Length - 3);//循环多个or 删减最后两个字符
            sqly += ") and a.ID = b.办公设备信息表ID and b.转移流程表ID =" + ID;
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sqly.ToString());

        }

        public int 修改数据(int ID, string 归属部门变更为, string 存放地点变更为, string 负责人变更为, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
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
                                       new SqlParameter("@FlowID",ID)
                                   };
            DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);

            StringBuilder dbsb = new StringBuilder();
            dbsb.Append("update AM_待办业务 SET ");
            dbsb.Append("流程状态=@流程状态,通知内容=@通知内容,发起人=@发起人,发起时间=@发起时间,处理方式=@处理方式,处理职务=@处理职务,Sort=@Sort WHERE FlowID= " + ID + " AND FlowName='资产转移'");

            SqlParameter[] dbpara = {


                                       new SqlParameter("@流程状态",dbmodel.流程状态),
                                       
                                       new SqlParameter("@通知内容",dbmodel.通知内容),
                                       new SqlParameter("@发起人",dbmodel.发起人),
                                       new SqlParameter("@发起时间",dbmodel.发起时间),
                                       new SqlParameter("@处理方式",dbmodel.处理方式),
                                       new SqlParameter("@处理职务",dbmodel.处理职务),
                                      
                                       new SqlParameter("@Sort",dbmodel.Sort)

                                   };
            DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, dbsb.ToString(), dbpara);

            string sql = string.Format("SELECT * FROM dbo.X_资产转移流程表 WHERE ID = {0}", ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            string SID = "";
            if (read.Read())
            {
                SID = read["S_ID"].ToString();
            }
            read.Close();
            string[] condition = { "," };
            string[] result = SID.Split(condition, StringSplitOptions.RemoveEmptyEntries);

            List<int> inlist = new List<int>();
            foreach (string item in result)
            {
                inlist.Add(Convert.ToInt32(item));
            }

            int upgsbm = 0;
            int upcfdd = 0;
            int upfzr = 0;
            string sqlx = string.Format("SELECT ID FROM dbo.一级部门表 where 名称='{0}'", 归属部门变更为);
            SqlDataReader readx = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sqlx.ToString());
            while (readx.Read())
            {
                upgsbm = Convert.ToInt32(readx["ID"]);
            }
            readx.Close();


            string sqlup2 = string.Format("SELECT   *  from dbo.房间信息表 where 名称 =  '{0}'", 存放地点变更为);
            SqlDataReader readup2 = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sqlup2.ToString());
            while (readup2.Read())
            {
                upcfdd = Convert.ToInt32(readup2["ID"]);
            }
            readup2.Close();


            string sqlup3 = string.Format("SELECT * FROM 用户表  where 姓名 =  '{0}'", 负责人变更为);
            SqlDataReader readup3 = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sqlup3.ToString());
            while (readup3.Read())
            {
                upfzr = Convert.ToInt32(readup3["ID"]);
            }
            readup3.Close();
            List<string> cstrlist = new List<string>();
            string csqls = "";
            for (int i = 0; i < inlist.Count; i++)
            {
                csqls = string.Format("   UPDATE 办公设备信息表 SET 归属部门 = {0} ,位置 = {1}, 归属教师ID = {2} where ID = {3}", upgsbm, upcfdd, upfzr, inlist[i]);
                cstrlist.Add(csqls.ToString());
            }

            string sqlflowstate = string.Format("UPDATE X_资产转移流程表 SET 流程状态='已完成' where ID = {0}", ID);
            DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sqlflowstate.ToString());
            return DBHelper.ExecuteSqlTran(cstrlist);


        }


        public SchoolX_资产转移改动信息表 查询变更为(int ID)
        {
            string sql = string.Format("SELECT  TOP 1 * FROM [X_资产转移改动信息表] WHERE 转移流程表ID ={0}", ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            SchoolX_资产转移改动信息表 model = new SchoolX_资产转移改动信息表();
            if (read.Read())
            {
                model.现存放地点 = read["现存放地点"].ToString();
                model.现归属部门 = read["现归属部门"].ToString();
                model.现负责人 = read["现负责人"].ToString();
            }
            read.Close();
            return model;

        }


        public List<School一级部门表> byzc()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM dbo.一级部门表");

                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

                List<School一级部门表> list = new List<School一级部门表>();
                while (read.Read())
                {
                    School一级部门表 model = new School一级部门表();
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
                用户表 modelx = new 用户表();
                modelx.ID = 0;
                modelx.姓名 = "全部";
                list.Add(modelx);
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
                try
                {
                    model.投入使用日期 = read["投入使用日期"].ToString();
                }
                catch (Exception)
                {
                    model.投入使用日期 = ""; ;
                    //throw;
                }
                model.型号 = read["型号"].ToString();
                model.类型 = read["类型"].ToString();
                model.学校名称 = read["学校名称"].ToString();
                model.归属教师ID = Convert.ToInt32(read["归属教师ID"].ToString());
                model.负责人 = read["负责人"].ToString();
                model.房间名称 = read["房间名称"].ToString();
                model.部门名称 = read["部门名称"].ToString();
                try
                {
                    model.价格 = Convert.ToDouble(read["价格"].ToString());
                }
                catch (Exception)
                {

                    model.价格 = 0.0;
                }
                model.数量 = Convert.ToInt32(read["数量"].ToString());
                model.使用方向 = read["使用方向"].ToString();
                model.变动金额 = 0;
                list.Add(model);
            }
            return list;
            //return sql.资产转移确定设备(listid);
        }


        public int upzczy(SchoolX_资产转移流程表 model, List<int> listid, List<SchoolX_资产转移改动信息表> listmodel, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO X_资产转移流程表 ");
                sb.Append(" (流程状态,单据编号,事项名称,申请人,申请日期,联系方式,存放地点变更为,归属部门变更为,负责人变更为,备注信息,S_ID,总数,总价,Sort ");
                sb.Append(" ) VALUES( ");
                sb.Append(" @流程状态,@单据编号,@事项名称,@申请人,@申请日期,@联系方式,@存放地点变更为,@归属部门变更为,@负责人变更为,@备注信息,@S_ID,@总数,@总价,"+1);
                sb.Append(")");
                sb.Append(" SELECT ");
                sb.Append(" @@identity ");
                SqlParameter[] para = {
                                       new SqlParameter("@流程状态",model.流程状态),
                                       new SqlParameter("@单据编号",model.单据编号),                            
                                       new SqlParameter("@事项名称",model.事项名称),
                                       new SqlParameter("@申请人",model.申请人),
                                       new SqlParameter("@申请日期",model.申请日期),
                                       new SqlParameter("@联系方式",model.联系方式),
                                       new SqlParameter("@存放地点变更为",model.存放地点变更为),
                                       new SqlParameter("@归属部门变更为",model.归属部门变更为),                            
                                       new SqlParameter("@负责人变更为",model.负责人变更为),
                                       new SqlParameter("@备注信息",model.备注信息),
                                       new SqlParameter("@S_ID",model.S_ID),
                                       new SqlParameter("@总数",model.总数),
                                       new SqlParameter("@总价",model.总价),

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
                                       new SqlParameter("@发起时间",ammodel.发起时间),
                                       new SqlParameter("@通知类型",ammodel.通知类型),
                                       new SqlParameter("@是否已读",ammodel.是否已读),
                                       new SqlParameter("@通知职务",ammodel.通知职务),
                                       new SqlParameter("@FlowID",num)
                                   };
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);

                //DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz);
                StringBuilder dbsb = new StringBuilder();
                dbsb.Append("INSERT INTO AM_待办业务 ");
                dbsb.Append("(流程状态,FlowID,处理方式,通知内容,发起人,发起时间,FlowName,处理职务,Sort,事项名称 ");
                dbsb.Append(" ) VALUES( ");
                dbsb.Append(" @流程状态,@FlowID,@处理方式,@通知内容,@发起人,@发起时间,@FlowName,@处理职务,@Sort,@事项名称 ");
                dbsb.Append(")");
                SqlParameter[] dbpara = {


                                       new SqlParameter("@流程状态",dbmodel.流程状态),
                                       new SqlParameter("@FlowID",num),
                                       new SqlParameter("@处理方式",dbmodel.处理方式),
                                       new SqlParameter("@通知内容",dbmodel.通知内容),
                                       new SqlParameter("@发起人",dbmodel.发起人),
                                       new SqlParameter("@发起时间",dbmodel.发起时间),
                                       new SqlParameter("@处理职务",dbmodel.处理职务),
                                       new SqlParameter("@Sort",dbmodel.Sort),
                                       new SqlParameter("@事项名称",dbmodel.事项名称),
                                       new SqlParameter("@FlowName",dbmodel.FlowName)
                                   };
                DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, dbsb.ToString(), dbpara);

                List<string> strlist = new List<string>();
                string sqlzy = "";
                for (int i = 0; i < listmodel.Count; i++)
                {
                    sqlzy = string.Format("INSERT INTO  [X_资产转移改动信息表] ([转移流程表ID],[办公设备信息表ID],[原存放地点],[原归属部门],[原负责人],[现存放地点],[现归属部门],[现负责人]) VALUES ({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}')", num, listid[i], listmodel[i].原存放地点, listmodel[i].原归属部门, listmodel[i].原负责人, model.存放地点变更为, model.归属部门变更为, model.负责人变更为);
                    strlist.Add(sqlzy);
                }
                int XX = DBHelper.ExecuteSqlTran(strlist);
                //int AA = XX;


                return XX;

                //if (num > 0)
                //{
                //    int upgsbm = 0;
                //    int upcfdd = 0;
                //    int upfzr = 0;
                //    string sql = string.Format("SELECT ID FROM dbo.一级部门表 where 名称='{0}'", model.归属部门变更为);
                //    SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                //    while (read.Read())
                //    {
                //        upgsbm = Convert.ToInt32(read["ID"]);
                //    }
                //    read.Close();


                //    string sqlup2 = string.Format("SELECT   *  from dbo.房间信息表 where 名称 =  '{0}'", model.存放地点变更为);
                //    SqlDataReader readup2 = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sqlup2.ToString());
                //    while (readup2.Read())
                //    {
                //        upcfdd = Convert.ToInt32(readup2["ID"]);
                //    }
                //    readup2.Close();


                //    string sqlup3 = string.Format("SELECT * FROM 用户表  where 姓名 =  '{0}'", model.负责人变更为);
                //    SqlDataReader readup3 = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sqlup3.ToString());
                //    while (readup3.Read())
                //    {
                //        upfzr = Convert.ToInt32(readup3["ID"]);
                //    }
                //    readup3.Close();
                //    List<string> cstrlist = new List<string>();
                //    string csqls = "";
                //    for (int i = 0; i < listid.Count; i++)
                //    {
                //        csqls = string.Format("   UPDATE 办公设备信息表 SET 归属部门 = {0} ,位置 = {1}, 归属教师ID = {2} where ID = {3}", upgsbm, upcfdd, upfzr, listid[i]);
                //        cstrlist.Add(csqls.ToString());
                //    }


                //    return DBHelper.ExecuteSqlTran(cstrlist);




                //}
                //else
                //{
                //    return 0;
                //}
            }
            catch (Exception)
            {
                return 0;
                //throw;
            }

            //return sql.upzczy(model, listid);
        }


        public DataSet 资产转移查询明细()
        {
            string sid = "";
            string sql = "SELECT * FROM dbo.X_资产转移流程表";
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            while (read.Read())
            {
                sid += read["S_ID"].ToString();
            }
            read.Close();
            string SID = sid.Substring(0, sid.Length - 1);
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  办公设备信息表.ID, 办公设备信息表.编号 ,办公设备信息表.名称,办公设备信息表.资产状态");
            sb.Append(" ,办公设备信息表.投入使用日期,    办公设备信息表.型号,办公设备信息表.一级类别名称 as 类型 ");
            sb.Append(" ,办公设备信息表.归属学校,办公设备信息表.归属教师ID,办公设备信息表.位置,办公设备信息表.归属部门,");
            sb.Append(" 办公设备信息表.价格 ,办公设备信息表.数量,办公设备信息表.使用方向,d.学校名称, e.姓名 AS 负责人,   ");
            sb.Append("      b.名称 AS 房间名称,c.名称 AS 部门名称 from 办公设备信息表 , dbo.房间信息表 AS b ");
            sb.Append("     , 一级部门表 as c,学校名称表 as d,用户表 AS e  where 办公设备信息表.位置 =  b.ID ");
            sb.Append(" and  办公设备信息表.归属部门 = c.ID and 办公设备信息表.位置 =  b.ID ");
            sb.Append("  and 办公设备信息表.归属部门 = c.ID  and       办公设备信息表.归属学校 = d.ID ");
            sb.Append("       and 办公设备信息表.归属教师ID = e.ID   ");
            if (sid != "")
            {

                sb.Append(" and 办公设备信息表.ID in(" + SID + ")");

            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }



        public DataSet 资产转移查询明细_X(School查询办公设备条件表 model)
        {
            string sid = "";
            string sql = "SELECT * FROM dbo.X_资产转移流程表";
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            while (read.Read())
            {
                sid += read["S_ID"].ToString();
            }
            read.Close();
            string SID = sid.Substring(0, sid.Length - 1);
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  办公设备信息表.ID, 办公设备信息表.编号 ,办公设备信息表.名称,办公设备信息表.资产状态");
            sb.Append(" ,办公设备信息表.投入使用日期,    办公设备信息表.型号,办公设备信息表.一级类别名称 as 类型 ");
            sb.Append(" ,办公设备信息表.归属学校,办公设备信息表.归属教师ID,办公设备信息表.位置,办公设备信息表.归属部门,");
            sb.Append(" 办公设备信息表.价格 ,办公设备信息表.数量,办公设备信息表.使用方向,d.学校名称, e.姓名 AS 负责人,   ");
            sb.Append("      b.名称 AS 房间名称,c.名称 AS 部门名称 from 办公设备信息表 , dbo.房间信息表 AS b ");
            sb.Append("     , 一级部门表 as c,学校名称表 as d,用户表 AS e  where 办公设备信息表.位置 =  b.ID ");
            sb.Append(" and  办公设备信息表.归属部门 = c.ID and 办公设备信息表.位置 =  b.ID ");
            sb.Append("  and 办公设备信息表.归属部门 = c.ID  and       办公设备信息表.归属学校 = d.ID ");
            sb.Append("       and 办公设备信息表.归属教师ID = e.ID   ");
            if (sid != "")
            {

                sb.Append(" and 办公设备信息表.ID in(" + SID + ")");

            }
            if (model != null)
            {
                if (model.一级分类 != "" && model.一级分类 != null)
                {
                    sb.Append(" and 办公设备信息表.一级类别名称 = '" + model.一级分类 + "' ");
                }
                if (model.二级分类 != "" && model.二级分类 != null)
                {
                    sb.Append("  and  办公设备信息表.二级类别名称 ='" + model.二级分类 + "'");
                }
                if (model.三级分类 != "" && model.三级分类 != null)
                {
                    sb.Append(" and 办公设备信息表.三级类别名称 ='" + model.三级分类 + "'");
                }

                if (model.归属部门 > 0)
                {
                    sb.Append(" and 办公设备信息表.归属部门=" + model.归属部门);
                }
                if (model.负责人 > 0)
                {
                    sb.Append(" and 办公设备信息表.归属教师ID=" + model.负责人);
                }

                if (model.存放地点 > 0 && model.房间 == 0)
                {
                    //根据存放地点ID 查询房间
                    string sqla = string.Format("        SELECT * FROM 房间信息表  where 建筑物ID = {0}", model.存放地点);
                    List<int> inlist = new List<int>();
                    SqlDataReader reada = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                    while (reada.Read())
                    {
                        inlist.Add(Convert.ToInt32(reada["ID"]));
                    }
                    reada.Close();
                    if (inlist.Count > 0)
                    {
                        sb.Append("and  办公设备信息表.位置 in(");
                        for (int i = 0; i < inlist.Count; i++)
                        {
                            sb.Append(inlist[i] + ",");

                        }
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append(")");
                    }
                    else
                    {
                        sb.Append("and  办公设备信息表.位置 in(0)");
                    }
                }
                if (model.房间 > 0)
                {
                    sb.Append(" and 办公设备信息表.位置=" + model.房间);
                }

                if (model.起始投入日期 != "" && model.结束投入日期 != "")
                {
                    sb.Append("  and 办公设备信息表.投入使用日期  between '" + model.起始投入日期 + "' and '" + model.结束投入日期 + "'");
                }
                if (model.关键字 != "")
                {
                    sb.Append(" and 办公设备信息表.名称 like '%" + model.关键字 + "%'");
                }
            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }
        public string 查询用户电话(string str)
        {
            string sql = string.Format("SELECT 电话号码 FROM 用户表 WHERE 姓名='" + str+"'");
            return DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString()).ToString();
        }
    }
}
