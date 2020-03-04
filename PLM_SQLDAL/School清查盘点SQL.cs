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
    public class School清查盘点SQL
    {
        public Boolean addpdrw(School盘点任务表 model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT ");
            sb.Append(" INTO");
            sb.Append(" 盘点任务表 (名称,盘点单号,起始时间,截止时间,等级,清查范围,清查ID,盘点方式,描述,学校ID,盘点完成,完成状态)");
            sb.Append("VALUES");
            sb.Append("(");
            sb.Append(" @名称");
            sb.Append(",@盘点单号");
            sb.Append(",@起始时间");
            sb.Append(",@截止时间");
            sb.Append(",@等级");
            sb.Append(",@清查范围");
            sb.Append(",@清查ID");
            sb.Append(",@盘点方式");
            sb.Append(",@描述");
            sb.Append(",@学校ID");
            sb.Append(",@盘点完成");
            sb.Append(",@完成状态");
            sb.Append(" )");
            SqlParameter[] para = {
                                  new SqlParameter("@名称",model.名称), 
                                  new SqlParameter("@盘点单号",model.盘点单号),
                                  new SqlParameter("@起始时间",model.起始时间), 
                                  new SqlParameter("@截止时间",model.截止时间),
                                  new SqlParameter("@等级",model.等级), 
                                  new SqlParameter("@清查范围",model.清查范围),
                                  new SqlParameter("@清查ID",model.清查ID), 
                                  new SqlParameter("@盘点方式",model.盘点方式),
                                  new SqlParameter("@描述",model.备注),
                                  new SqlParameter("@学校ID",model.学校ID), 
                                  new SqlParameter("@盘点完成",model.盘点完成),
                                  new SqlParameter("@完成状态",model.完成状态),
                                 };
            int insertNum = DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para);
            if (insertNum > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public DataSet DataSet清查盘点()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT * FROM 盘点任务表  WHERE ID >0");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }


        public List<School盘点进度> 查询盘点进度(int sid, string 清查范围)
        {
            StringBuilder sb = new StringBuilder();
            if (清查范围 == "个人")
            {
                sb.Append(" SELECT  bumen1.ID  , bumen1.名称, bumen1.学校ID, t.管理数量, p.已经盘点,pdjs.盘点结束 from  ");
                sb.Append(" (SELECT  b.ID, b.姓名 as 名称, b.学校ID FROM  用户表 AS b,(select 清查范围,清查ID from 盘点任务表 where ID = 102)");
                sb.Append(" as tab4 where charindex(','+CAST(b.ID AS nvarchar(50))+',',tab4.清查ID)>0 ) as bumen1  LEFT OUTER JOIN  (SELECT COUNT(*) AS 管理数量, 归属教师ID  ");
                sb.Append("FROM  办公设备信息表 as tab1,(select 清查范围,清查ID from 盘点任务表 where ID =" + sid);
                sb.Append(" ) as tab2 WHERE (归属学校 =1) and charindex(','+CAST(tab1.归属教师ID AS nvarchar(50))+',',tab2.清查ID)>0  ");
                sb.Append("    GROUP BY 归属教师ID) AS t ON bumen1.ID  = t.归属教师ID LEFT OUTER JOIN    (SELECT COUNT(*) AS 已经盘点, 办公设备信息表_1.归属教师ID  ");
                sb.Append("   FROM  办公设备信息表 AS 办公设备信息表_1 ,(select 清查范围,清查ID from 盘点任务表 where ID =" + sid + ") as tab3 ");
                sb.Append("WHERE  (盘点 = 1) AND (归属学校 =1) and charindex(','+CAST(办公设备信息表_1.归属教师ID AS nvarchar(50))+',',tab3.清查ID)>0   GROUP BY 归属教师ID) AS p ON bumen1.ID ");
                sb.Append("   = p.归属教师ID LEFT OUTER JOIN  (SELECT COUNT(盘点) AS 盘点结束, 办公设备信息表_5.归属教师ID ");
                sb.Append(" FROM  办公设备信息表 AS 办公设备信息表_5 ,(select 清查范围,清查ID from 盘点任务表 where ID =" + sid + ") as tab5 ");
                sb.Append(" WHERE  (办公设备信息表_5.盘点 >0) AND (归属学校 =1) and charindex(','+CAST(办公设备信息表_5.归属教师ID AS nvarchar(50))+',',tab5.清查ID)>0 ");
                sb.Append("GROUP BY 归属教师ID) AS pdjs ON bumen1.ID  = pdjs.归属教师ID");

            }
            else if (清查范围 == "部门")
            {
                sb.Append("SELECT  bumen1.ID , bumen1.名称, bumen1.学校ID, t.管理数量, p.已经盘点, pdjs.盘点结束 ");
                sb.Append("from (SELECT  b.ID, b.名称, b.学校ID FROM  一级部门表 AS b,");
                sb.Append("(select 清查范围,清查ID from 盘点任务表 where ID = " + sid + ") as tab4 where charindex(','+CAST(b.ID AS nvarchar(50))+',',tab4.清查ID)>0 ) as bumen1  ");
                sb.Append("LEFT OUTER JOIN  (SELECT COUNT(*) AS 管理数量, 归属部门 FROM  办公设备信息表 as tab1,(select 清查范围,清查ID from 盘点任务表 where ID =" + sid + ") as tab2 ");
                sb.Append("WHERE (归属学校 = 1) and charindex(','+CAST(tab1.归属部门 AS nvarchar(50))+',',tab2.清查ID)>0 GROUP BY 归属部门) AS t ON bumen1.ID = t.归属部门 ");
                sb.Append("LEFT OUTER JOIN (SELECT COUNT(*) AS 已经盘点, 办公设备信息表_1.归属部门 FROM  办公设备信息表 AS 办公设备信息表_1 ,");
                sb.Append("(select 清查范围,清查ID from 盘点任务表 where ID = " + sid + ") as tab3 WHERE  (盘点 = 1) AND (归属学校 = 1) ");
                sb.Append("and charindex(','+CAST(办公设备信息表_1.归属部门 AS nvarchar(50))+',',tab3.清查ID)>0 GROUP BY 归属部门) AS p ON bumen1.ID = p.归属部门 ");
                sb.Append("LEFT OUTER JOIN (SELECT COUNT(*) AS 盘点结束, 办公设备信息表_5.归属部门 FROM  办公设备信息表 AS 办公设备信息表_5 ,");
                sb.Append("(select 清查范围,清查ID from 盘点任务表 where ID = " + sid + ") as tab5 WHERE  (盘点 > 0) AND (归属学校 = 1) ");
                sb.Append("and charindex(','+CAST(办公设备信息表_5.归属部门 AS nvarchar(50))+',',tab5.清查ID)>0 GROUP BY 归属部门) AS pdjs  ON bumen1.ID = pdjs.归属部门");
            }
            else
            {
                sb.Append("SELECT  b.ID, b.名称, b.学校ID, t.管理数量, p.已经盘点,pdjs.盘点结束 ");
                sb.Append("FROM  一级部门表 AS b LEFT OUTER JOIN  (SELECT COUNT(*) AS 管理数量, 归属部门  ");
                sb.Append("	FROM  办公设备信息表 WHERE (归属学校 = 1)  GROUP BY 归属部门) AS t ON b.ID = t.归属部门 LEFT OUTER JOIN  ");
                sb.Append("(SELECT COUNT(*) AS 已经盘点, 归属部门  FROM  办公设备信息表 AS 办公设备信息表_1  WHERE  (盘点 = 1) AND (归属学校 = 1)  GROUP BY 归属部门)");
                sb.Append("AS p ON b.ID = p.归属部门  LEFT OUTER JOIN  (SELECT COUNT(*) AS 盘点结束,办公设备信息表_5.归属部门  FROM  办公设备信息表 AS 办公设备信息表_5 ");
                sb.Append("WHERE  盘点>0 AND (归属学校 = 1)  GROUP BY 归属部门) AS pdjs ON b.ID = pdjs.归属部门  ");
            }


            int GLSLZS = 0;
            int YJPDZC = 0;
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            List<School盘点进度> list = new List<School盘点进度>();
            while (read.Read())
            {

                School盘点进度 model = new School盘点进度();
                model.ID = Convert.ToInt32(read["ID"]);
                model.名称 = read["名称"].ToString();
                model.学校ID = 1;
                model.管理数量 = read["管理数量"].ToString();

                string 管理数量ls = read["管理数量"].ToString();
                if (管理数量ls == "")
                {
                    model.管理数量 = "无";
                    model.百分比 = "0";
                }
                else
                {

                    model.管理数量int = Convert.ToInt32(model.管理数量);
                    GLSLZS += Convert.ToInt32(model.管理数量);

                    model.管理数量 = model.管理数量int.ToString();
                }


                string 已经盘点ls = read["已经盘点"].ToString();
                if (已经盘点ls == "")
                {

                    model.已经盘点int = 0;
                    model.已经盘点 = "0";
                    if (管理数量ls == "")
                    {
                        model.已经盘点 = "无";
                    }
                }
                else
                {

                    model.已经盘点int = Convert.ToInt32(已经盘点ls);
                    YJPDZC += Convert.ToInt32(已经盘点ls);
                    model.已经盘点 = model.已经盘点int.ToString();


                }
                model.盘点结束 = read["盘点结束"].ToString();
                if (管理数量ls == "")
                {
                    model.盘点结束 = "已完成";
                }
                else
                {
                    if (管理数量ls != "" && 已经盘点ls != "0")
                    {
                        if (model.管理数量int == model.已经盘点int)
                        {
                            model.盘点结束 = "已完成";
                        }
                        else
                        {
                            model.盘点结束 = "未完成";
                        }
                    }
                    else
                    {
                        model.盘点结束 = "未完成";
                    }
                }

                if (管理数量ls != "")
                {
                    if (model.已经盘点int != 0)
                    {
                        double bfb = Convert.ToDouble(model.已经盘点int) / Convert.ToDouble(model.管理数量int) * 100;
                        int bfbthis = Convert.ToInt32(bfb);
                        model.百分比 = bfbthis.ToString();
                    }
                    else
                    {
                        model.百分比 = "0";
                    }

                }


                model.管理数量总数 = GLSLZS;
                model.已经盘点总数 = YJPDZC;

                list.Add(model);




            }


            return list;



        }


        public DataSet 拍照补录查询(string whe)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select  办公设备信息表.ID,办公设备信息表.编号 ,办公设备信息表.名称,办公设备信息表.资产状态 ,办公设备信息表.投入使用日期, ");
            sb.Append(" 办公设备信息表.型号,办公设备信息表.一级类别名称 as 类型  ,办公设备信息表.归属学校,办公设备信息表.归属教师ID,办公设备信息表.位置,办公设备信息表.归属部门,办公设备信息表.价格");
            sb.Append(",办公设备信息表.数量,    办公设备信息表.使用方向  ,  办公设备信息表.拍照补录,    办公设备信息表.盘点 , ");
            sb.Append("d.学校名称, e.姓名 AS 负责人       ,c.名称 AS 部门名称         from 办公设备信息表 ,   一级部门表");
            sb.Append(" as c,学校名称表 as d,用户表 AS e  where   办公设备信息表.归属部门 = c.ID   and 办公设备信息表.归属部门 = c.ID");
            sb.Append("  and       办公设备信息表.归属学校 = d.ID     and 办公设备信息表.归属教师ID = e.ID ");
            sb.Append(" and 办公设备信息表.拍照补录 is not null ");
            //先查询所有  不加条件
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }


        public DataSet 盘亏处理查询(string whe)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select  办公设备信息表.ID,办公设备信息表.编号 ,办公设备信息表.名称,办公设备信息表.资产状态 ,办公设备信息表.投入使用日期, ");
            sb.Append(" 办公设备信息表.型号,办公设备信息表.一级类别名称 as 类型  ,办公设备信息表.归属学校,办公设备信息表.归属教师ID,办公设备信息表.位置,办公设备信息表.归属部门,办公设备信息表.价格");
            sb.Append(",办公设备信息表.数量,    办公设备信息表.使用方向  ,  办公设备信息表.拍照补录,    办公设备信息表.盘点 , ");
            sb.Append("d.学校名称, e.姓名 AS 负责人       ,c.名称 AS 部门名称         from 办公设备信息表 ,   一级部门表");
            sb.Append(" as c,学校名称表 as d,用户表 AS e  where   办公设备信息表.归属部门 = c.ID   and 办公设备信息表.归属部门 = c.ID");
            sb.Append("  and       办公设备信息表.归属学校 = d.ID     and 办公设备信息表.归属教师ID = e.ID ");
            sb.Append("   and 办公设备信息表.盘点 = 2 ");
            //先查询所有  不加条件
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());


        }


        public List<School盘点报告> 查询盘点报告()
        {
            List<int> listbmid = new List<int>();
            List<School一级部门表> modelbm = new List<School一级部门表>();
            List<School盘点报告> modellist = new List<School盘点报告>();
            string sqlbm = "select * from  一级部门表";
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sqlbm.ToString());
            while (read.Read())
            {
                School一级部门表 model = new School一级部门表();
                model.ID = Convert.ToInt32(read["ID"]);
                model.名称 = read["名称"].ToString();
                modelbm.Add(model);
            }
            read.Close();
            for (int i = 0; i < modelbm.Count; i++)
            {
                School盘点报告 model = new School盘点报告();
                model.部门 = modelbm[i].名称;
                //负责人可以在这里查询
                string sql房屋及构筑物 = string.Format(" select count(一级类别名称) as 数量 from 办公设备信息表   where 归属部门 = {0} and 一级类别名称 like '{1}' and 盘点 = 0", modelbm[i].ID, "房屋及构筑物");
                SqlDataReader read房屋及构筑物 = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql房屋及构筑物.ToString());
                if (read房屋及构筑物.Read())
                {
                    model.房屋及构筑物 = read房屋及构筑物["数量"].ToString() == null ? "0" : read房屋及构筑物["数量"].ToString();

                    if (model.房屋及构筑物 == "")
                    {
                        model.房屋及构筑物 = "0";
                    }
                }
                read房屋及构筑物.Close();

                string sql通用设备 = string.Format(" select count(一级类别名称) as 数量 from 办公设备信息表   where 归属部门 = {0} and 一级类别名称 like '{1}' and 盘点 = 0", modelbm[i].ID, "通用设备");
                SqlDataReader read通用设备 = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql通用设备.ToString());
                if (read通用设备.Read())
                {
                    model.通用设备 = read通用设备["数量"].ToString() == null ? "0" : read通用设备["数量"].ToString();

                    if (model.通用设备 == "")
                    {
                        model.通用设备 = "0";
                    }
                }
                read通用设备.Close();


                string sql专用设备 = string.Format(" select count(一级类别名称) as 数量 from 办公设备信息表   where 归属部门 = {0} and 一级类别名称 like '{1}' and 盘点 = 0", modelbm[i].ID, "专用设备");
                SqlDataReader read专用设备 = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql专用设备.ToString());
                if (read专用设备.Read())
                {
                    model.专用设备 = read专用设备["数量"].ToString() == null ? "0" : read专用设备["数量"].ToString();

                    if (model.专用设备 == "")
                    {
                        model.专用设备 = "0";
                    }
                }
                read专用设备.Close();

                string sql家具用具装具 = string.Format(" select count(一级类别名称) as 数量 from 办公设备信息表   where 归属部门 = {0} and 一级类别名称 like '{1}' and 盘点 = 0", modelbm[i].ID, "家具、用具、装具");
                SqlDataReader read家具用具装具 = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql家具用具装具.ToString());
                if (read家具用具装具.Read())
                {
                    model.家具用具装具 = read家具用具装具["数量"].ToString() == null ? "0" : read家具用具装具["数量"].ToString();

                    if (model.家具用具装具 == "")
                    {
                        model.家具用具装具 = "0";
                    }
                }
                read家具用具装具.Close();

                string sql文物陈列品 = string.Format(" select count(一级类别名称) as 数量 from 办公设备信息表   where 归属部门 = {0} and 一级类别名称 like '{1}' and 盘点 = 0", modelbm[i].ID, "文物陈列品");
                SqlDataReader read文物陈列品 = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql文物陈列品.ToString());
                if (read文物陈列品.Read())
                {
                    model.文物陈列品 = read文物陈列品["数量"].ToString() == null ? "0" : read文物陈列品["数量"].ToString();

                    if (model.文物陈列品 == "")
                    {
                        model.文物陈列品 = "0";
                    }
                }
                read文物陈列品.Close();

                string sql图书 = string.Format(" select count(一级类别名称) as 数量 from 办公设备信息表   where 归属部门 = {0} and 一级类别名称 like '{1}' and 盘点 = 0", modelbm[i].ID, "图书");
                SqlDataReader read图书 = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql图书.ToString());
                if (read图书.Read())
                {
                    model.图书 = read图书["数量"].ToString() == null ? "0" : read图书["数量"].ToString();

                    if (model.图书 == "")
                    {
                        model.图书 = "0";
                    }
                }
                read图书.Close();
                modellist.Add(model);

            }
            return modellist;
        }


        public DataSet 筛选存放地点(int id)
        {
            string sql = string.Format("SELECT * FROM 房间信息表 WHERE 建筑物ID = {0}", id);
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            //return us.筛选存放地点(id);
        }


        public DataSet 筛选用户(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select  用户表.ID ,用户表.姓名  ,用户表.电话号码 ,b.名称 , c.学校名称   from 用户表  , 一级部门表 as b ,学校名称表 as c ");
            sb.Append(" where  用户表.部门ID = b.ID   and  用户表.学校ID  = c.ID and 用户表.部门ID  =" + id);
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            //return us.筛选用户(id);
        }

        public DataSet 查询部门()
        {
            string sql = string.Format("SELECT * FROM 一级部门表");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            //return us.查询部门();
        }

        public List<School学校名称表> 查询学校名称()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM dbo.学校名称表");

                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

                List<School学校名称表> list = new List<School学校名称表>();
                while (read.Read())
                {
                    School学校名称表 model = new School学校名称表();
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.学校名称 = read["学校名称"].ToString();
                    list.Add(model);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<School一级部门表> 查询一级部门()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM dbo.一级部门表");

                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

                List<School一级部门表> list = new List<School一级部门表>();
                School一级部门表 modelx = new School一级部门表();
                modelx.ID = 0;
                modelx.名称 = "全部";
                list.Add(modelx);
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


        public List<School一级类别表> 查询一级类别()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM dbo.一级类别表");

                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

                List<School一级类别表> list = new List<School一级类别表>();
                School一级类别表 modelx = new School一级类别表();
                modelx.ID = 0;
                modelx.名称 = "全部";
                list.Add(modelx);
                while (read.Read())
                {
                    School一级类别表 model = new School一级类别表();
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

        public List<School建筑物信息表> 查询建筑物信息表()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM dbo.建筑物信息表");

                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

                List<School建筑物信息表> list = new List<School建筑物信息表>();
                School建筑物信息表 modelx = new School建筑物信息表();
                modelx.ID = 0;
                modelx.名称 = "全部";
                list.Add(modelx);
                while (read.Read())
                {
                    School建筑物信息表 model = new School建筑物信息表();
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


        public List<School盘点人员进度> 查询盘点人员进度(int ID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  SELECT  b.ID, b.姓名 as mc, b.学校ID, t.管理数量 as glsl, p.已经盘点 as ypd ");
            sb.Append("    FROM (select ID, 姓名,学校ID from 用户表 where 部门ID = " + ID);
            sb.Append(" )  AS b  LEFT OUTER JOIN  (SELECT COUNT(*) AS 管理数量, 归属教师ID FROM  办公设备信息表 WHERE ");
            sb.Append("  (归属学校 = 1) GROUP BY 归属教师ID) AS t ON b.ID = t.归属教师ID LEFT OUTER JOIN (SELECT COUNT(*) ");
            sb.Append(" AS 已经盘点, 归属教师ID FROM  办公设备信息表 AS 办公设备信息表_1 WHERE  (盘点 = 1) AND (归属学校 =1)");
            sb.Append("   GROUP BY 归属教师ID) AS p ON b.ID = p.归属教师ID");
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            List<School盘点人员进度> list = new List<School盘点人员进度>();
            while (read.Read())
            {
                School盘点人员进度 model = new School盘点人员进度();
                model.ID = Convert.ToInt32(read["ID"]);
                model.学校名称 = "四中";
                model.姓名 = read["mc"].ToString();
                try
                {
                    model.管理数量 = Convert.ToInt32(read["glsl"]);
                }
                catch (Exception)
                {
                    model.管理数量 = 0;

                }
                try
                {
                    model.已盘点 = Convert.ToInt32(read["ypd"]);
                }
                catch (Exception)
                {
                    model.已盘点 = 0;
                }
                list.Add(model);

            }
            return list;


        }

        public List<School二级类别表> 查询二级类别(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string sql = string.Format("SELECT * FROM 二级类别表 WHERE SSID =  {0} ", id);
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                List<School二级类别表> list = new List<School二级类别表>();
                School二级类别表 modelx = new School二级类别表();
                modelx.ID = 0;
                modelx.名称 = "全部";
                list.Add(modelx);
                while (read.Read())
                {
                    School二级类别表 model = new School二级类别表();
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
            //return us.查询二级类别(id);
        }


        public List<School三级类别表> 查询三级类别(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string sql = string.Format("SELECT * FROM 三级类别表 WHERE SSID =  {0} ", id);
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                List<School三级类别表> list = new List<School三级类别表>();
                School三级类别表 modelx = new School三级类别表();
                modelx.ID = 0;
                modelx.名称 = "全部";
                list.Add(modelx);
                while (read.Read())
                {
                    School三级类别表 model = new School三级类别表();
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

        public List<School房间信息表> 查询房间信息表(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string sql = string.Format("SELECT * FROM 房间信息表 WHERE 建筑物ID =  {0} ", id);
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                List<School房间信息表> list = new List<School房间信息表>();
                School房间信息表 modelx = new School房间信息表();
                modelx.ID = 0;
                modelx.名称 = "全部";
                list.Add(modelx);

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




        public List<School一级类别表> 一级类别()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM dbo.一级类别表");

                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

                List<School一级类别表> list = new List<School一级类别表>();
                while (read.Read())
                {
                    School一级类别表 model = new School一级类别表();
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

        public List<School二级类别表> 二级类别()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM dbo.二级类别表");

                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

                List<School二级类别表> list = new List<School二级类别表>();
                while (read.Read())
                {
                    School二级类别表 model = new School二级类别表();
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



        public List<School一级部门表> 一级部门()
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

        public List<用户表> 用户表()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM dbo.用户表");

                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

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

        public List<School建筑物信息表> 建筑物信息表()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM dbo.建筑物信息表");

                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

                List<School建筑物信息表> list = new List<School建筑物信息表>();
                while (read.Read())
                {
                    School建筑物信息表 model = new School建筑物信息表();
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








        public List<School一级类别表> 查询一级类别s()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM dbo.一级类别表");

                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

                List<School一级类别表> list = new List<School一级类别表>();
                //School一级类别表 modelx = new School一级类别表();
                //modelx.ID = 0;
                //modelx.名称 = "请选择一级类别";
                //list.Add(modelx);
                while (read.Read())
                {
                    School一级类别表 model = new School一级类别表();
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



        public List<School二级类别表> 查询二级类别s(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string sql = string.Format("SELECT * FROM 二级类别表 WHERE SSID =  {0} ", id);
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                List<School二级类别表> list = new List<School二级类别表>();
                //School二级类别表 modelx = new School二级类别表();
                //modelx.ID = 0;
                //modelx.名称 = "全部";
                //list.Add(modelx);
                while (read.Read())
                {
                    School二级类别表 model = new School二级类别表();
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
            //return us.查询二级类别(id);
        }


        public List<School三级类别表> 查询三级类别s(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string sql = string.Format("SELECT * FROM 三级类别表 WHERE SSID =  {0} ", id);
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                List<School三级类别表> list = new List<School三级类别表>();
                //School三级类别表 modelx = new School三级类别表();
                //modelx.ID = 0;
                //modelx.名称 = "全部";
                //list.Add(modelx);
                while (read.Read())
                {
                    School三级类别表 model = new School三级类别表();
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


















        public List<School一级类别表> 查询一级类别(string kind)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string sql = string.Format("  select * from 一级类别表 WHERE ID = (SELECT SSID FROM 二级类别表 WHERE 名称 = '{0}' ) ",kind);
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                List<School一级类别表> list = new List<School一级类别表>();
               
                while (read.Read())
                {
                    School一级类别表 models = new School一级类别表();
                    models.ID = Convert.ToInt32(read["ID"]);
                    models.名称 = read["名称"].ToString();
                    list.Add(models);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
            //return us.查询二级类别(id);
        }

        public List<School二级类别表> 查询二级类别(string kind)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string sql = string.Format(" SELECT * FROM 二级类别表 WHERE ID =  (SELECT SSID FROM 三级类别表 WHERE 名称 = '{0}')  ", kind);
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                List<School二级类别表> list = new List<School二级类别表>();               
                while (read.Read())
                {
                    School二级类别表 model = new School二级类别表();
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



        public List<School三级类别表> 三级(string kind)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string sql = string.Format(" SELECT * FROM 三级类别表 WHERE SSID =  (SELECT ID FROM 二级类别表 WHERE 名称 = '{0}')  ", kind);
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

                List<School三级类别表> list = new List<School三级类别表>();
                while (read.Read())
                {
                    School三级类别表 model = new School三级类别表();
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

    }
}
