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
    public class School申报审批SQL
    {
        public DataSet 首页_X_资产处置流程表(string state,string declareTypes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select  *  from X_资产处置流程表 where  ID>0 ");
            if (state == "流程状态-待审核")
            {
                sb.Append(" and 流程状态='待审核'");
            }
            else if (state == "流程状态-已通过")
            {
                sb.Append(" and 流程状态='已通过'");
            }
            else if (state == "流程状态-未通过")
            {
                sb.Append(" and 流程状态='未通过'");
            }
            if (declareTypes=="报废")
            {
                sb.Append(" and FlowName='资产处置-报废'");
            }
            else if (declareTypes == "调拨")
            {
                sb.Append(" and FlowName='资产处置-调拨'");
            }
            else if (declareTypes == "报损")
            {
                sb.Append(" and FlowName='资产处置-报损'");
            }
            else if (declareTypes == "出售")
            {
                sb.Append(" and FlowName='资产处置-出售'");
            }
            sb.Append(" and 事项名称 !=''");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());


        }

        public DataSet 待处置库查询(string state,string purchaseTime)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  办公设备信息表.ID, 办公设备信息表.编号 ,办公设备信息表.名称,办公设备信息表.资产状态,办公设备信息表.原值,办公设备信息表.净值");
            sb.Append(" ,办公设备信息表.投入使用日期,    办公设备信息表.型号,办公设备信息表.一级类别名称 as 类型 ");
            sb.Append(" ,办公设备信息表.归属学校,办公设备信息表.归属教师ID,办公设备信息表.位置,办公设备信息表.归属部门,");
            sb.Append(" 办公设备信息表.价格 ,办公设备信息表.数量,办公设备信息表.使用方向,办公设备信息表.购置日期,d.学校名称, e.姓名 AS 负责人,   ");
            sb.Append("      b.名称 AS 房间名称,c.名称 AS 部门名称 from 办公设备信息表 , dbo.房间信息表 AS b ");
            sb.Append("     , 一级部门表 as c,学校名称表 as d,用户表 AS e  where 办公设备信息表.位置 =  b.ID ");
            sb.Append(" and  办公设备信息表.归属部门 = c.ID and 办公设备信息表.位置 =  b.ID ");
            sb.Append("  and 办公设备信息表.归属部门 = c.ID  and       办公设备信息表.归属学校 = d.ID ");
            sb.Append("       and 办公设备信息表.归属教师ID = e.ID   ");
            if (state != "")
            {
                sb.Append(" and  办公设备信息表.处置临时状态 = '" + state + "'");
            }
            if (purchaseTime== "购置时间正序")
            {
                sb.Append(" order by  办公设备信息表.购置日期 ASC");
            }else if (purchaseTime == "购置时间倒序")
            {
                sb.Append(" order by  办公设备信息表.购置日期 DESC");
            }

            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }


        public List<School办公设备信息表> 资产申报确定设备(List<int> listid, string 处置方式)
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
                model.类型 = read["类型"].ToString();
                try
                {
                    model.价格 = Convert.ToDouble(read["价格"].ToString());
                }
                catch (Exception)
                {
                    model.价格 = 0;
                    //throw;
                }
                model.数量 = Convert.ToInt32(read["数量"].ToString());
                model.名称 = read["名称"].ToString();
                model.型号 = read["型号"].ToString();
                model.使用方向 = read["使用方向"].ToString();
                model.负责人 = read["负责人"].ToString();
                model.学校名称 = read["学校名称"].ToString();
                model.房间名称 = read["房间名称"].ToString();
                model.部门名称 = read["部门名称"].ToString();
                model.资产状态 = read["资产状态"].ToString();
                model.处置方式 = 处置方式;
                list.Add(model);
            }
            return list;
        }

        //public int 资产处置调拨单(X_资产处置调拨表 model)
        //{
        //    StringBuilder sb = new StringBuilder();


        //    SqlParameter[] para ={ new SqlParameter()};
        //    int num = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para));
        //    //修改 XID临时状态
        //    return num;
        //}

        //public int 插入资产处置(SchoolX_资产处置流程表 model)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("INSERT INTO X_资产处置流程表 ");
        //    sb.Append(" (Sort,Mark,单据编号,流程状态,申报日期,申报单位,SID,总数,总价,原因说明,分管领导,申请人,职务 ");
        //    sb.Append(",电话,主管部门意见,财政部门意见,批复文号,申报文号,事项名称 ");
        //    sb.Append(" ) VALUES( ");
        //    sb.Append(" @Sort,@Mark,@单据编号,@流程状态,@申报日期,@申报单位,@SID,@总数,@总价,@原因说明,@分管领导,@申请人,@职务 ");
        //    sb.Append(" ,@电话,@主管部门意见,@财政部门意见,@批复文号,@申报文号,@事项名称 ");
        //    sb.Append(")");
        //    sb.Append(" SELECT ");
        //    sb.Append(" @@identity ");
        //    SqlParameter[] para = {


        //                               new SqlParameter("@Sort",model.Sort),
        //                               new SqlParameter("@Mark",model.Mark),                            
        //                               new SqlParameter("@单据编号",model.单据编号),
        //                               new SqlParameter("@流程状态",model.流程状态),
        //                               new SqlParameter("@申报日期",model.申报日期),
        //                               new SqlParameter("@申报单位",model.申报单位),
        //                               new SqlParameter("@SID",model.SID),
        //                               new SqlParameter("@总数",model.总数),                            
        //                               new SqlParameter("@总价",model.总价),
        //                               new SqlParameter("@原因说明",model.原因说明),
        //                               new SqlParameter("@分管领导",model.分管领导),
        //                               new SqlParameter("@申请人",model.申请人),
        //                               new SqlParameter("@职务",model.职务),
        //                               new SqlParameter("@电话",model.电话),
        //                               new SqlParameter("@主管部门意见",model.主管部门意见),
        //                               new SqlParameter("@财政部门意见",model.财政部门意见),                            
        //                               new SqlParameter("@批复文号",model.批复文号),
        //                               new SqlParameter("@申报文号",model.申报文号),
        //                               new SqlParameter("事项名称",model.事项名称),

        //                           };
        //    int num = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para));
        //    //修改 XID临时状态
        //    return num;

        //}


        #region 插入资产处置调拨
        public int 插入资产处置调拨单(SchoolX_资产处置流程表 model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO X_资产处置流程表 ");
            sb.Append(" (Sort,FlowName,单据编号,流程状态,申报日期,SID,总数,总价,原因说明,申请人,职务 ");
            sb.Append(",验收日期,调入单位,调出单位,事项名称,电话");
            sb.Append(",调出单位分管领导意见,调出单位分管领导,调出单位分管领导处理时间,调入单位管理员意见,调入单位管理员");
            sb.Append(",调入单位管理员处理时间,调入单位分管领导意见,调入单位分管领导,调入单位分管领导处理时间");
            sb.Append(",主管部门意见,主管部门处理时间,主管部门,财政部门意见,财政部门,财政部门处理时间");
            sb.Append(" ) VALUES( ");
            sb.Append(" @Sort,@FlowName,@单据编号,@流程状态,@申报日期,@SID,@总数,@总价,@原因说明,@申请人,@职务 ");
            sb.Append(" ,@验收日期,@调入单位,@调出单位,@事项名称,@电话   ");
            sb.Append(",@调出单位分管领导意见,@调出单位分管领导,@调出单位分管领导处理时间,@调入单位管理员意见,@调入单位管理员");
            sb.Append(",@调入单位管理员处理时间,@调入单位分管领导意见,@调入单位分管领导,@调入单位分管领导处理时间");
            sb.Append(",@主管部门意见,@主管部门处理时间,@主管部门,@财政部门意见,@财政部门,@财政部门处理时间");
            sb.Append(")");
            sb.Append(" SELECT ");
            sb.Append(" @@identity ");
            SqlParameter[] para = {
                                       new SqlParameter("@Sort",model.Sort),
                                       new SqlParameter("@FlowName",model.FlowName),
                                       new SqlParameter("@单据编号",model.单据编号),
                                       new SqlParameter("@流程状态",model.流程状态),
                                       new SqlParameter("@申报日期",model.申报日期),
                                       new SqlParameter("@SID",model.SID),
                                       new SqlParameter("@总数",model.总数),
                                       new SqlParameter("@总价",model.总价),
                                       new SqlParameter("@原因说明",model.原因说明),
                                       new SqlParameter("@申请人",model.申请人),
                                       new SqlParameter("@职务",model.职务),
                                       new SqlParameter("@验收日期",model.验收日期),
                                       new SqlParameter("@调入单位",model.调入单位),
                                       new SqlParameter("@调出单位",model.调出单位),
                                       new SqlParameter("@事项名称",model.事项名称),
                                       new SqlParameter("@电话",model.电话),
                                       //流程未处理

                                       new SqlParameter("@调出单位分管领导意见",model.调出单位分管领导意见),
                                       new SqlParameter("@调出单位分管领导",model.调出单位分管领导),
                                       new SqlParameter("@调出单位分管领导处理时间",model.调出单位分管领导处理时间),
                                       new SqlParameter("@调入单位管理员意见",model.调入单位管理员意见),
                                       new SqlParameter("@调入单位管理员",model.调入单位管理员),
                                       new SqlParameter("@调入单位管理员处理时间",model.调入单位管理员处理时间),
                                       new SqlParameter("@调入单位分管领导意见",model.调入单位分管领导意见),
                                       new SqlParameter("@调入单位分管领导",model.调入单位分管领导),
                                       new SqlParameter("@调入单位分管领导处理时间",model.调入单位分管领导处理时间),
                                       new SqlParameter("@主管部门意见",model.主管部门意见),
                                       new SqlParameter("@主管部门处理时间",model.主管部门处理时间),
                                       new SqlParameter("@主管部门",model.主管部门),
                                       new SqlParameter("@财政部门意见",model.财政部门意见),
                                       new SqlParameter("@财政部门",model.财政部门),
                                       new SqlParameter("@财政部门处理时间",model.财政部门处理时间),


                                   };
            int num = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para));

            AM_提醒通知 ammodel = new AM_提醒通知();
            ammodel.发起人 = model.申请人;
            ammodel.发起时间 = DateTime.Now;
            ammodel.是否已读 = "否";
            ammodel.通知类型 = "待办事项通知";
            ammodel.通知职务 = "分管领导";
            ammodel.消息内容 = "您来自" + model.申请人 + "的资产处置-调拨申请通知！";
            ammodel.消息事项 = "资产处置-调拨";
            ammodel.FlowID = num;
            ammodel.处理职务 = "分管领导";
            ammodel.处理方式 = "职务";
            ammodel.处理人 = "分管领导";
            ammodel.FlowName = "资产处置-调拨";
            ammodel.流程状态 = model.流程状态;
            ammodel.Sort = model.Sort;
            SchoolUtility.插入消息中心(ammodel);

            AM_待办业务 dbmodel = new AM_待办业务();
            dbmodel.处理职务 = "分管领导";
            dbmodel.发起人 = model.申请人;
            dbmodel.FlowID = num;
            dbmodel.流程状态 = model.流程状态;
            dbmodel.事项名称 = "资产处置-调拨";
            dbmodel.通知内容 = "您来自" + model.申请人 + "的资产处置-调拨申请,请及时处理！";
            dbmodel.发起时间 = DateTime.Now.ToLongDateString();
            dbmodel.处理方式 = "职务";
            dbmodel.处理人 = "分管领导";
            dbmodel.FlowName = "资产处置-调拨";
            dbmodel.Sort = model.Sort;
            SchoolUtility.插入待办中心(dbmodel);
            return num;

        }


        #endregion


        public List<School办公设备信息表> 处置申报查询(string sid, string mark)
        {
            Console.Write(sid);
            string[] condition = { "," };
            string[] result = sid.Split(condition, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();
            sb.Append("     select a.ID, a.编号 ,a.名称,a.资产状态 ,a.投入使用日期,    a.型号,a.一级类别名称 as 类型  ");
            sb.Append(" ,a.归属学校,a.归属教师ID,a.位置,a.归属部门,a.价格 ,a.数量,   ");
            sb.Append(" a.使用方向,d.学校名称, e.姓名 AS 负责人,        b.名称 AS 房间名称,c.名称 AS 部门名称  from 办公设备信息表 as a , dbo.房间信息表 AS b , 一级部门表 as c,学校名称表 as d,用户表 AS e    ");

            sb.Append("  where  (");
            foreach (string item in result)
            {
                sb.Append(" a.ID  =" + item + " or ");
            }

            string sqlsb = sb.ToString();
            string sqly = sqlsb.Substring(0, sqlsb.Length - 3);//循环多个or 删减最后两个字符
            sqly += ") and a.位置 =  b.ID and  a.归属部门 = c.ID and a.位置 = b.ID and a.归属部门 = c.ID  and   a.归属学校 = d.ID  and a.归属教师ID = e.ID";
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sqly.ToString());
            List<School办公设备信息表> list = new List<School办公设备信息表>();
            while (read.Read())
            {
                School办公设备信息表 model = new School办公设备信息表();
                model.ID = Convert.ToInt32(read["ID"].ToString());
                model.类型 = read["类型"].ToString();
                try
                {
                    model.价格 = Convert.ToDouble(read["价格"].ToString());
                }
                catch (Exception)
                {
                    model.价格 = 0;
                    //throw;
                }
                model.数量 = Convert.ToInt32(read["数量"].ToString());
                model.名称 = read["名称"].ToString();
                model.编号 = read["编号"].ToString();
                model.型号 = read["型号"].ToString();
                model.部门名称 = read["部门名称"].ToString();
                model.房间名称 = read["房间名称"].ToString();
                model.资产状态 = read["资产状态"].ToString();
                model.负责人 = read["负责人"].ToString();
                model.处置方式 = mark;
                list.Add(model);
            }
            return list;



        }


        public DataSet 申报记录统计查询(string sSearch, string flowstate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select  *  from X_资产处置流程表 where  ID>0 ");
            if (sSearch == "")
            {
                sb.Append("");
            }
            else
            {
                sb.Append(" and 申报单位 like '%" + sSearch + "%'");
            }
            if (flowstate == "流程状态-待审核")
            {
                sb.Append(" and 流程状态='待审核'");
            }
            else if (flowstate == "流程状态-已完成")
            {
                sb.Append(" and 流程状态='已完成'");
            }
            else if (flowstate == "流程状态-全部")
            {
                sb.Append("");
            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
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


        public string 资产处置调出单位(int ID)
        {
            //string sql = string.Format("SELECT 分管领导 FROM X_资产处置流程表 WHERE ID=" + ID);
            string sql = string.Format("SELECT B.名称 as 调出单位  FROM 用户表 as A,一级部门表 as B where A.学校ID=B.ID and A.ID=" + ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                string fname = read["调出单位"].ToString();
                return fname;
            }
            else
            {
                return "空";
            }
        }


        public string 资产处置调入单位(int ID)
        {
            //string sql = string.Format("SELECT 分管领导 FROM X_资产处置流程表 WHERE ID=" + ID);
            string sql = string.Format("SELECT B.名称 as 调入单位  FROM 用户表 as A,一级部门表 as B where A.学校ID=B.ID and A.ID=" + ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                string fname = read["调入单位"].ToString();
                return fname;
            }
            else
            {
                return "空";
            }
        }


        public int 创建处置申报资产报废(SchoolX_资产处置流程表 model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO X_资产处置流程表  ");
            sb.Append(" (Sort,FlowName,单据编号,流程状态,申请人,事项名称,申报日期,申报单位,SID,总数,总价,职务,原因说明,主管部门 ,主管部门处理时间,主管部门意见,电话,调入单位分管领导,调入单位分管领导处理时间,调入单位分管领导意见,财政部门,财政部门处理时间,财政部门意见");
            sb.Append(" ) VALUES( ");
            sb.Append(" @Sort,@FlowName,@单据编号,@流程状态,@申请人,@事项名称,@申报日期,@申报单位,@SID,@总数,@总价,@职务,@原因说明,@主管部门 ,@主管部门处理时间,@主管部门意见,@电话,@调入单位分管领导,@调入单位分管领导处理时间,@调入单位分管领导意见,@财政部门,@财政部门处理时间,@财政部门意见");

            sb.Append(")");
            sb.Append(" SELECT ");
            sb.Append(" @@identity ");
            SqlParameter[] para = {

                                       new SqlParameter("@Sort",model.Sort),
                                       new SqlParameter("@FlowName",model.FlowName),
                                       new SqlParameter("@单据编号",model.单据编号),
                                       new SqlParameter("@流程状态",model.流程状态),
                                       new SqlParameter("@申请人",model.申请人),
                                       new SqlParameter("事项名称",model.事项名称),
                                       new SqlParameter("@申报日期",model.申报日期),
                                       new SqlParameter("@申报单位",model.申报单位),
                                       new SqlParameter("@SID",model.SID),
                                       new SqlParameter("@总数",model.总数),
                                       new SqlParameter("@总价",model.总价),
                                       new SqlParameter("@职务",model.职务),
                                       new SqlParameter("@原因说明",model.原因说明),
                                       new SqlParameter("@主管部门",model.主管部门),
                                       new SqlParameter("@主管部门处理时间",model.主管部门处理时间),
                                       new SqlParameter("@主管部门意见",model.主管部门意见),
                                       new SqlParameter("@电话",model.电话),
                                       new SqlParameter("@调入单位分管领导",model.调入单位分管领导),
                                       new SqlParameter("@调入单位分管领导处理时间",model.调入单位分管领导处理时间),
                                       new SqlParameter("@调入单位分管领导意见",model.调入单位分管领导意见),
                                       new SqlParameter("@财政部门",model.财政部门),
                                       new SqlParameter("@财政部门处理时间",model.财政部门处理时间),
                                       new SqlParameter("@财政部门意见",model.财政部门意见),
                                   };
            int num = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para));

            AM_提醒通知 ammodel = new AM_提醒通知();
            ammodel.发起人 = model.申请人;
            ammodel.发起时间 = DateTime.Now;
            ammodel.是否已读 = "否";
            ammodel.通知类型 = "待办事项通知";
            ammodel.通知职务 = "分管领导";
            ammodel.消息内容 = "您来自" + model.申请人 + "的资产处置-调拨申请通知！";
            ammodel.消息事项 = "资产处置-报废";
            ammodel.FlowID = num;
            ammodel.处理职务 = "分管领导";
            ammodel.处理方式 = "职务";
            ammodel.处理人 = "分管领导";
            ammodel.FlowName = "资产处置";
            ammodel.流程状态 = model.流程状态;
            SchoolUtility.插入消息中心(ammodel);

            AM_待办业务 dbmodel = new AM_待办业务();
            dbmodel.处理职务 = "分管领导";
            dbmodel.发起人 = model.申请人;
            dbmodel.FlowID = num;
            dbmodel.流程状态 = model.流程状态;
            dbmodel.事项名称 = "资产处置-报废";
            dbmodel.通知内容 = "您来自" + model.申请人 + "的资产处置-报废申请,请及时处理！";
            dbmodel.发起时间 = DateTime.Now.ToLongDateString();
            dbmodel.处理方式 = "职务";
            dbmodel.处理人 = "分管领导";
            dbmodel.FlowName = "资产处置-报废";
            dbmodel.Sort = model.Sort;
            SchoolUtility.插入待办中心(dbmodel);
            return num;

        }



        //处置申报待报废处理流程
        public int 处置申报待报废处理流程(SchoolX_资产处置流程表 model, AM_提醒通知 ammodel, AM_待办业务 dbmodel)
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

                if (model.Sort == 1)//分管领导通过
                {
                    //string sql = string.Format("UPDATE X_资产处置流程表 SET 是否同意 ='{0}' ,分管领导通过时间 = '{1}' , 申请人 = '{2}',Sort=2 ,流程状态='分管领导已通过,待主管部门审核' where ID = {3}", model.是否同意, model.分管领导通过时间, model.申请人, model.ID);
                    //DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                }
                else if (model.Sort == 2)//主管部门审核
                {
                    //string sql = string.Format("UPDATE X_资产处置流程表 SET 主管部门确认通过 ='{0}' ,主管部门通过时间 = '{1}' ,Sort=3 ,流程状态='主管部门已审核通过,待财政部门审核' where ID = {2}", model.主管部门确认通过, model.主管部门通过时间, model.ID);
                    //DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                }
                else if (model.Sort == 3) //财政部门审核
                {
                    //string sql = string.Format("UPDATE X_资产处置流程表 SET 财务部门确认通过 ='是' ,财政部门通过时间 = '2020/2/4' ,Sort=0 ,流程状态='完成' where ID = {2}", model.财政部门确认通过, model.财政部门通过时间, model.ID);
                    //DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                }
                string sqlup = string.Format("UPDATE AM_待办业务 SET 流程状态='{0}',通知内容 ='{1}' ,处理职务='{2}' where FlowID = {3} and 事项名称='{4}'", dbmodel.流程状态, dbmodel.通知内容, dbmodel.处理职务, dbmodel.FlowID, dbmodel.事项名称);
                return DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sqlup.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #region //调拨流程处理
        public int 调拨流程处理(SchoolX_资产处置流程表 model)
        {
            if (model.Sort == 2)//分管领导处理
            {
                string sql = string.Format("UPDATE dbo.X_资产处置流程表 set 调出单位分管领导意见 = '{0}' , 调出单位分管领导 = '{1}' ,调出单位分管领导处理时间='{2}' ,Sort = {3} ,流程状态='{4}' where ID = {5} and FlowName='{6}'", model.调出单位分管领导意见, model.调出单位分管领导, model.调出单位分管领导处理时间, model.Sort, model.流程状态, model.ID, model.FlowName);
                int result = DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起人 = model.调出单位分管领导;
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "资产管理员";
                ammodel.消息内容 = "您来自" + model.调出单位分管领导 + "的资产处置-调拨处理通知！";
                ammodel.消息事项 = "资产处置-调拨";
                ammodel.FlowID = model.ID;
                ammodel.处理职务 = "资产管理员";
                ammodel.处理方式 = "职务";
                ammodel.处理人 = "资产管理员";
                ammodel.FlowName = "资产处置-调拨";
                ammodel.流程状态 = model.流程状态;
                ammodel.Sort = model.Sort;
                SchoolUtility.插入消息中心(ammodel);



                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.流程状态 = model.流程状态;
                dbmodel.通知内容 = "您来自" + model.调出单位分管领导 + "的资产处置-调拨处理,请及时处理！";
                dbmodel.处理职务 = "资产管理员";
                dbmodel.处理方式 = "职务";
                //dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                dbmodel.处理人 = "资产管理员";
                dbmodel.Sort = model.Sort;
                dbmodel.FlowID = model.ID;
                dbmodel.事项名称 = "资产处置-调拨";
                dbmodel.FlowName = dbmodel.事项名称;

                SchoolUtility.修改待办中心(dbmodel);
                return result;
            }
            else if (model.Sort == 3)
            {
                string sql = string.Format("UPDATE dbo.X_资产处置流程表 set 调入单位管理员意见 = '{0}' , 调入单位管理员 = '{1}' ,调入单位管理员处理时间='{2}' ,Sort = {3} ,流程状态='{4}' where ID = {5} and FlowName='{6}'", model.调入单位管理员意见, model.调入单位管理员, model.调入单位管理员处理时间, model.Sort, model.流程状态, model.ID, model.FlowName);
                int result = DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起人 = model.调入单位管理员;
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "资产管理员";
                ammodel.消息内容 = "您来自" + model.调入单位管理员 + "的资产处置-调拨处理通知！";
                ammodel.消息事项 = "资产处置-调拨";
                ammodel.FlowID = model.ID;
                ammodel.处理职务 = "分管领导";
                ammodel.处理方式 = "职务";
                ammodel.处理人 = "分管领导";
                ammodel.FlowName = "资产处置-调拨";
                ammodel.流程状态 = model.流程状态;
                ammodel.Sort = model.Sort;
                SchoolUtility.插入消息中心(ammodel);



                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.流程状态 = model.流程状态;
                dbmodel.通知内容 = "您来自" + model.调入单位管理员 + "的资产处置-调拨处理,请及时处理！";
                dbmodel.处理职务 = "分管领导";
                dbmodel.处理方式 = "职务";
                //dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                dbmodel.处理人 = "分管领导";
                dbmodel.Sort = model.Sort;
                dbmodel.FlowID = model.ID;
                dbmodel.事项名称 = "资产处置-调拨";
                dbmodel.FlowName = dbmodel.事项名称;

                SchoolUtility.修改待办中心(dbmodel);
                return result;
            }
            else if (model.Sort == 4)
            {
                string sql = string.Format("UPDATE dbo.X_资产处置流程表 set 调入单位分管领导意见 = '{0}' , 调入单位分管领导 = '{1}' ,调入单位分管领导处理时间='{2}' ,Sort = {3} ,流程状态='{4}' where ID = {5} and FlowName='{6}'", model.调入单位分管领导意见, model.调入单位分管领导, model.调入单位分管领导处理时间, model.Sort, model.流程状态, model.ID, model.FlowName);
                int result = DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起人 = model.调入单位分管领导;
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "资产管理员";
                ammodel.消息内容 = "您来自" + model.调入单位分管领导 + "的资产处置-调拨处理通知！";
                ammodel.消息事项 = "资产处置-调拨";
                ammodel.FlowID = model.ID;
                ammodel.处理职务 = "主管部门";
                ammodel.处理方式 = "职务";
                ammodel.处理人 = "主管部门";
                ammodel.FlowName = "资产处置-调拨";
                ammodel.流程状态 = model.流程状态;
                ammodel.Sort = model.Sort;
                SchoolUtility.插入消息中心(ammodel);



                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.流程状态 = model.流程状态;
                dbmodel.通知内容 = "您来自" + model.调入单位分管领导 + "的资产处置-调拨处理,请及时处理！";
                dbmodel.处理职务 = "主管部门";
                dbmodel.处理方式 = "职务";
                //dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                dbmodel.处理人 = "主管部门";
                dbmodel.Sort = model.Sort;
                dbmodel.FlowID = model.ID;
                dbmodel.事项名称 = "资产处置-调拨";
                dbmodel.FlowName = model.FlowName;



                SchoolUtility.修改待办中心(dbmodel);
                return result;
            }
            else if (model.Sort == 5)
            {
                string sql = string.Format("UPDATE dbo.X_资产处置流程表 set 主管部门意见 = '{0}' , 主管部门处理时间 = '{1}' ,主管部门='{2}' ,Sort = {3} ,流程状态='{4}' where ID = {5} and FlowName='{6}'", model.主管部门意见, model.主管部门处理时间, model.主管部门, model.Sort, model.流程状态, model.ID, model.FlowName);
                int result = DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起人 = model.主管部门;
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "主管部门";
                ammodel.消息内容 = "您来自" + model.主管部门 + "的资产处置-调拨处理通知！";
                ammodel.消息事项 = "资产处置-调拨";
                ammodel.FlowID = model.ID;
                ammodel.处理职务 = "财务人员";
                ammodel.处理方式 = "职务";
                ammodel.处理人 = "财务人员";
                ammodel.FlowName = "资产处置-调拨";
                ammodel.流程状态 = model.流程状态;
                ammodel.Sort = model.Sort;
                SchoolUtility.插入消息中心(ammodel);


                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.流程状态 = model.流程状态;
                dbmodel.通知内容 = "您来自" + model.主管部门 + "的资产处置-调拨处理,请及时处理！";
                dbmodel.处理职务 = "财务人员";
                dbmodel.处理方式 = "职务";
                dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                dbmodel.处理人 = "财务人员";
                dbmodel.Sort = model.Sort;
                dbmodel.FlowID = model.ID;
                dbmodel.事项名称 = "资产处置-调拨";
                dbmodel.FlowName = model.FlowName;



                SchoolUtility.修改待办中心(dbmodel);
                return result;
            }
            else if (model.Sort == 6)
            {
                string sql = string.Format("UPDATE dbo.X_资产处置流程表 set 财政部门意见 = '{0}' , 财政部门处理时间 = '{1}' ,财政部门='{2}' ,Sort = {3} ,流程状态='{4}' where ID = {5} and FlowName='{6}'", model.财政部门意见, model.财政部门处理时间, model.财政部门, model.Sort, model.流程状态, model.ID, model.FlowName);
                int result = DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起人 = model.财政部门;
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "财政部门";
                ammodel.消息内容 = "您来自" + model.财政部门 + "的资产处置-调拨处理通知！";
                ammodel.消息事项 = "资产处置-调拨";
                ammodel.FlowID = model.ID;
                ammodel.处理职务 = "资产管理员";
                ammodel.处理方式 = "职务";
                ammodel.处理人 = "资产管理员";
                ammodel.FlowName = "资产处置-调拨";
                ammodel.流程状态 = model.流程状态;
                ammodel.Sort = model.Sort;
                SchoolUtility.插入消息中心(ammodel);

                /*
                 AM_待办业务 upmodel = new AM_待办业务();
                    1 upmodel.流程状态 = "分管领导已通过,待主管部门审核";
                    1 upmodel.通知内容 = "您来自" + model.调入单位分管领导 + "的资产处置报废申请分管领导已通过,请及时处理！";
                    1 upmodel.处理职务 = "主管部门";
                    1 upmodel.处理方式 = "职务";
                    upmodel.发起时间 = DateTime.Now.ToLongDateString();
                    1 upmodel.处理人 = "主管部门";
                    1 upmodel.Sort = 2;
                    1 upmodel.FlowID = model.ID;
                    upmodel.事项名称 = "资产处置-报废";
                    1 upmodel.FlowName = upmodel.事项名称;
                    SchoolUtility.修改待办中心(upmodel);
                 */

                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.流程状态 = model.流程状态;
                dbmodel.处理职务 = "资产管理员";
                dbmodel.处理方式 = "职务";
                dbmodel.处理人 = "资产管理员";
                dbmodel.FlowName = model.FlowName;
                dbmodel.FlowID = model.ID;
                dbmodel.通知内容 = "您来自" + model.财政部门 + "的资产处置-调拨处理,请及时处理！";
                dbmodel.Sort = model.Sort;
                SchoolUtility.修改待办中心(dbmodel);
                return result;
            }

            else if (model.Sort == 7)
            {
                string sql = string.Format("UPDATE dbo.X_资产处置流程表 set  调出单位管理员处理时间 = '{0}' ,调出单位管理员='{1}' ,Sort = {2} ,流程状态='{3}' where ID = {4} and FlowName='{5}'", model.调出单位管理员处理时间, model.调出单位管理员, model.Sort, model.流程状态, model.ID, model.FlowName);
                int result = DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起人 = model.调出单位管理员;
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "资产管理员";
                ammodel.消息内容 = "您来自" + model.调出单位管理员 + "的资产处置-调拨处理通知！";
                ammodel.消息事项 = "资产处置-调拨";
                ammodel.FlowID = model.ID;
                ammodel.处理职务 = "资产管理员";
                ammodel.处理方式 = "职务";
                ammodel.处理人 = "资产管理员";
                ammodel.FlowName = "资产处置-调拨";
                ammodel.流程状态 = model.流程状态;
                ammodel.Sort = model.Sort;
                SchoolUtility.插入消息中心(ammodel);

                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.流程状态 = model.流程状态;
                dbmodel.处理职务 = "资产管理员";
                dbmodel.处理方式 = "职务";
                dbmodel.处理人 = "资产管理员";
                dbmodel.FlowName = model.FlowName;
                dbmodel.FlowID = model.ID;
                dbmodel.通知内容 = "您来自" + model.调出单位管理员 + "的资产处置-调拨处理,请及时处理！";
                dbmodel.Sort = model.Sort;
                SchoolUtility.修改待办中心(dbmodel);
                return result;
            }


            else if (model.Sort == 0)
            {
                string sql = string.Format("UPDATE dbo.X_资产处置流程表 set  调入单位管理员确认处理时间 = '{0}' ,调入单位管理员确认='{1}' ,Sort = {2} ,流程状态='{3}' where ID = {4} and FlowName='{5}'", model.调入单位管理员确认处理时间, model.调入单位管理员确认, model.Sort, model.流程状态, model.ID, model.FlowName);
                int result = DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起人 = model.调入单位管理员确认;
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "系统通知";
                ammodel.通知职务 = "资产管理员";
                ammodel.消息内容 = "您来自" + model.调入单位管理员确认 + "的资产处置-调拨处理通知！";
                ammodel.消息事项 = "资产处置-调拨";
                ammodel.FlowID = model.ID;
                ammodel.处理职务 = "调入单位管理员";
                ammodel.处理方式 = "职务";
                ammodel.处理人 = "调入单位管理员";
                ammodel.FlowName = "资产处置-调拨";
                ammodel.流程状态 = model.流程状态;
                ammodel.Sort = model.Sort;
                SchoolUtility.插入消息中心(ammodel);

                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.流程状态 = model.流程状态;
                dbmodel.处理职务 = "调入单位管理员";
                dbmodel.处理方式 = "职务";
                dbmodel.处理人 = "调入单位管理员";
                dbmodel.FlowName = model.FlowName;
                dbmodel.FlowID = model.ID;
                dbmodel.通知内容 = "您来自" + model.调入单位管理员确认 + "的资产处置-调拨处理,请及时处理！";
                dbmodel.Sort = model.Sort;
                SchoolUtility.修改待办中心(dbmodel);



                string sid = model.SID;
                string[] arr = sid.Split(',');
                foreach (string item in arr)
                {

                    if (item != "")
                    {
                        string sqls = string.Format("update  办公设备信息表 set 使用状态='已调拨',处置临时状态='' where ID=" + Convert.ToInt32(item));
                        DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                    }

                }


                return result;


            }
            else
            {
                return 0;
            }
        }
        #endregion


        public int 处置申报报废处理流程(SchoolX_资产处置流程表 model)
        {
            try
            {
                //分管领导通过
                if (model.Sort == 1)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE X_资产处置流程表 SET 调入单位分管领导意见 =@调入单位分管领导意见 ,调入单位分管领导处理时间 = @调入单位分管领导处理时间 , 调入单位分管领导 = @调入单位分管领导,");
                    sb.Append(" Sort=2 ,流程状态='分管领导已通过,待主管部门审核' where ID = @ID");
                    SqlParameter[] para = {
                        new SqlParameter("@调入单位分管领导意见",model.调入单位分管领导意见),
                        new SqlParameter("@调入单位分管领导处理时间",model.调入单位分管领导处理时间),
                        new SqlParameter("@调入单位分管领导",model.调入单位分管领导),
                        //new SqlParameter("@原因说明",model.原因说明),
                        new SqlParameter("@ID",model.ID),
                    };
                    int num = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para));

                    AM_提醒通知 ammodel = new AM_提醒通知();
                    ammodel.消息事项 = "资产处置";
                    ammodel.消息内容 = "您来自" + model.调入单位分管领导 + "的资产处置报废申请分管领导已通过！";
                    ammodel.发起人 = model.调入单位分管领导;
                    ammodel.发起时间 = DateTime.Now;
                    ammodel.通知类型 = "待办事项通知";
                    ammodel.是否已读 = "否";
                    ammodel.通知职务 = "主管部门";
                    ammodel.FlowID = model.ID;
                    ammodel.FlowName = "资产处置-报废";
                    ammodel.处理职务 = "主管部门";
                    ammodel.处理方式 = "职务";
                    ammodel.处理人 = "主管部门";
                    ammodel.流程状态 = "分管领导已通过,待主管部门审核";
                    SchoolUtility.插入消息中心(ammodel);

                    AM_待办业务 upmodel = new AM_待办业务();
                    upmodel.流程状态 = "分管领导已通过,待主管部门审核";
                    upmodel.通知内容 = "您来自" + model.调入单位分管领导 + "的资产处置报废申请分管领导已通过,请及时处理！";
                    upmodel.处理职务 = "主管部门";
                    upmodel.处理方式 = "职务";
                    upmodel.发起时间 = DateTime.Now.ToLongDateString();
                    upmodel.处理人 = "主管部门";
                    upmodel.Sort = 2;
                    upmodel.FlowID = model.ID;
                    upmodel.事项名称 = "资产处置-报废";
                    upmodel.FlowName = upmodel.事项名称;
                    SchoolUtility.修改待办中心(upmodel);

                }
                //主管部门审核
                else if (model.Sort == 2)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE X_资产处置流程表 SET 主管部门 =@主管部门 ,主管部门处理时间 = @主管部门处理时间  ,Sort=3 ,");
                    sb.Append("流程状态='主管部门已审核通过,待财政部门审核',主管部门意见=@主管部门意见 where ID = @ID");
                    SqlParameter[] para = {
                        new SqlParameter("@主管部门",model.主管部门),
                        new SqlParameter("@主管部门处理时间",model.主管部门处理时间),
                        new SqlParameter("@主管部门意见",model.主管部门意见),
                        new SqlParameter("@ID",model.ID),
                    };
                    int num = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para));

                    AM_提醒通知 ammodel = new AM_提醒通知();
                    ammodel.消息事项 = "资产处置";
                    ammodel.消息内容 = "您来自" + model.主管部门 + "的资产处置报废申请主管部门已通过！";
                    ammodel.发起人 = model.主管部门;
                    ammodel.发起时间 = DateTime.Now;
                    ammodel.通知类型 = "待办事项通知";
                    ammodel.是否已读 = "否";
                    ammodel.通知职务 = "财务人员";
                    ammodel.FlowID = model.ID;
                    ammodel.FlowName = "资产处置-报废";
                    ammodel.处理职务 = "财务人员";
                    ammodel.处理方式 = "职务";
                    ammodel.处理人 = "财务人员";
                    ammodel.流程状态 = "主管部门已通过,待财务部门审核";
                    SchoolUtility.插入消息中心(ammodel);

                    AM_待办业务 upmodel = new AM_待办业务();
                    upmodel.处理职务 = "财务人员";
                    upmodel.处理方式 = "职务";
                    upmodel.处理人 = "财务人员";
                    upmodel.流程状态 = "主管部门已通过,待财务部门审核";
                    upmodel.事项名称 = "资产处置-报废";
                    upmodel.FlowID = model.ID;
                    upmodel.Sort = 3;
                    upmodel.FlowName = upmodel.事项名称;
                    upmodel.通知内容 = "您来自" + model.主管部门 + "的资产处置报废申请主管部门已通过,请及时处理！";
                    upmodel.发起时间 = DateTime.Now.ToLongDateString();
                    SchoolUtility.修改待办中心(upmodel);

                }
                //财政部门审核
                else if (model.Sort == 3)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE X_资产处置流程表 SET 财政部门意见 =@财政部门意见,财政部门处理时间 =@财政部门处理时间 ,财政部门=@财政部门 ,Sort=0 ,");
                    sb.Append("流程状态='完成' where ID = @ID");
                    SqlParameter[] para = {
                        new SqlParameter("@财政部门意见",model.财政部门意见),
                        new SqlParameter("@财政部门处理时间",model.财政部门处理时间),
                        new SqlParameter("@财政部门",model.财政部门),
                        new SqlParameter("@ID",model.ID),
                    };
                    int num = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para));

                    AM_提醒通知 ammodel = new AM_提醒通知();
                    ammodel.消息事项 = "资产处置";
                    ammodel.消息内容 = "您来自" + model.财政部门 + "的资产处置报废申请分管领导已通过！";
                    ammodel.发起人 = model.财政部门;
                    ammodel.发起时间 = DateTime.Now;
                    ammodel.通知类型 = "结果反馈通知";
                    ammodel.是否已读 = "否";
                    ammodel.通知职务 = "财务部门";
                    ammodel.FlowID = model.ID;
                    ammodel.FlowName = "资产处置-报废";
                    ammodel.处理职务 = "财务部门";
                    ammodel.处理方式 = "财务";
                    ammodel.处理人 = "财务人员";
                    ammodel.流程状态 = "您的资产处置流程已全部完成！";
                    SchoolUtility.插入消息中心(ammodel);


                    AM_待办业务 upmodel = new AM_待办业务();
                    upmodel.处理职务 = "财务人员";
                    upmodel.处理方式 = "职务";
                    upmodel.处理人 = "财务人员";
                    upmodel.流程状态 = "完成";
                    upmodel.事项名称 = "资产处置-报废";
                    upmodel.FlowID = model.ID;
                    upmodel.Sort = 0;
                    upmodel.FlowName = upmodel.事项名称;
                    upmodel.通知内容 = "您的资产处置流程已全部完成";
                    upmodel.发起时间 = DateTime.Now.ToLongDateString();
                    SchoolUtility.修改待办中心(upmodel);

                    string sid = model.SID;
                    string[] arr=sid.Split(',');
                    foreach(string item in arr)
                    {
                       
                        if (item != "")
                        {
                            string sql = string.Format("update  办公设备信息表 set 使用状态='已报废',处置临时状态='' where ID=" + Convert.ToInt32(item));
                            DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                        }
                        
                    }
                
                }
                //else if (model.Sort == 6)
                //{
                //    string sql = string.Format("UPDATE dbo.X_资产处置流程表 set 财政部门意见 = '{0}' , 财政部门处理时间 = '{1}' ,财政部门='{2}' ,Sort = {3} ,流程状态='{4}' where ID = {5} and FlowName='{6}'", model.财政部门意见, model.财政部门处理时间, model.财政部门, model.Sort, model.流程状态, model.ID, model.FlowName);
                //    int result = DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                //    AM_提醒通知 ammodel = new AM_提醒通知();
                //    ammodel.发起人 = model.主管部门;
                //    ammodel.发起时间 = DateTime.Now;
                //    ammodel.是否已读 = "否";
                //    ammodel.通知类型 = "待办事项通知";
                //    ammodel.通知职务 = "资产管理员";
                //    ammodel.消息内容 = "您来自" + model.主管部门 + "的资产处置-调拨处理通知！";
                //    ammodel.消息事项 = "资产处置-调拨";
                //    ammodel.FlowID = model.ID;
                //    ammodel.处理职务 = "主管部门";
                //    ammodel.处理方式 = "职务";
                //    ammodel.处理人 = "主管部门";
                //    ammodel.FlowName = "资产处置-调拨";
                //    ammodel.流程状态 = model.流程状态;
                //    ammodel.Sort = model.Sort;
                //    SchoolUtility.插入消息中心(ammodel);

                //    AM_待办业务 dbmodel = new AM_待办业务();
                //    dbmodel.流程状态 = model.流程状态;
                //    dbmodel.处理职务 = "主管部门";
                //    dbmodel.处理方式 = "职务";
                //    dbmodel.处理人 = "主管部门";
                //    dbmodel.FlowName = model.FlowName;
                //    dbmodel.FlowID = model.ID;
                //    dbmodel.通知内容 = "您来自" + model.主管部门 + "的资产处置-调拨处理,请及时处理！";
                //    dbmodel.Sort = model.Sort;
                //    SchoolUtility.修改待办中心(dbmodel);
                //}
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }



        public string 资产处置调拨调出单位管理员姓名(int ID)
        {
            string sql = string.Format("SELECT * FROM X_资产处置流程表 WHERE ID=" + ID);
            //string sql = string.Format("SELECT B.名称 as 调入单位  FROM 用户表 as A,一级部门表 as B where A.学校ID=B.ID and A.ID=" + ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                string dcname = read["申请人"].ToString();
                return dcname;
            }
            else
            {
                return "空"; 
            }
        }


        public string 资产处置调拨调入单位管理员姓名(int ID)
        {
            string sql = string.Format("SELECT * FROM X_资产处置流程表 WHERE ID=" + ID);
            //string sql = string.Format("SELECT B.名称 as 调入单位  FROM 用户表 as A,一级部门表 as B where A.学校ID=B.ID and A.ID=" + ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                string drname = read["调入单位管理员"].ToString();
                return drname;
            }
            else
            {
                return "空";
            }
        }
    }
}
