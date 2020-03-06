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


    public class School资产处置SQL
    {
        public DataSet 查询全部资产信息(School查询办公设备条件表 model)
        {
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
            if (model != null)
            {
                if (model.一级分类 != "" && model.一级分类 != null)
                {
                    if (model.一级分类!="全部")
                    {
                        sb.Append(" and 办公设备信息表.一级类别名称 = '" + model.一级分类 + "' ");
                    }
                   
                    
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

                if (model.归属部门s != "" && model.归属部门s!=null)
                {
                    sb.Append(" and 办公设备信息表.归属部门='" + model.归属部门s+"'");
                }
                if (model.负责人 > 0)
                {
                    sb.Append(" and 办公设备信息表.归属教师ID=" + model.负责人);
                }

                if (model.存放地点 > 0 && model.房间 == 0)
                {
                    //根据存放地点ID 查询房间
                    string sql = string.Format("        SELECT * FROM 房间信息表  where 建筑物ID = {0}", model.存放地点);
                    List<int> inlist = new List<int>();
                    SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
                    while (read.Read())
                    {
                        inlist.Add(Convert.ToInt32(read["ID"]));
                    }
                    read.Close();
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

                if (model.存放地点s != "" && model.存放地点s != null)
                {
                    if (model.存放地点s=="全部")
                    {
                        sb.Append("");
                    }
                    else
                    {
                        sb.Append(" and 办公设备信息表.存放地点='" + model.存放地点s + "'");
                    }
                    
                }
                if (model.房间 > 0)
                {
                    sb.Append(" and 办公设备信息表.位置=" + model.房间);
                }

                if (model.起始投入日期 != "" && model.结束投入日期 != "" && model.结束投入日期 != null && model.结束投入日期!=null)
                {
                    sb.Append("  and 办公设备信息表.投入使用日期  between '" + model.起始投入日期 + "' and '" + model.结束投入日期 + "'");
                }
                if (model.关键字 != "" && model.关键字 != null)
                {
                    sb.Append(" and 办公设备信息表.名称 like '%" + model.关键字 + "%'");
                }

            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }


        public DataSet 购置验收条件查询(School查询办公设备条件表 model)
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


            //sb.Append("SELECT  办公设备信息表.ID, 办公设备信息表.编号 ,办公设备信息表.名称,办公设备信息表.资产状态");
            //sb.Append(" ,办公设备信息表.投入使用日期,    办公设备信息表.型号,办公设备信息表.一级类别名称 as 类型 ");
            //sb.Append(" ,办公设备信息表.归属学校,办公设备信息表.归属教师ID,办公设备信息表.位置,办公设备信息表.归属部门,");
            //sb.Append(" 办公设备信息表.价格 ,办公设备信息表.数量,办公设备信息表.使用方向,d.学校名称, e.姓名 AS 负责人,   ");
            //sb.Append("      b.名称 AS 房间名称,c.名称 AS 部门名称 from 办公设备信息表 , dbo.房间信息表 AS b ");
            //sb.Append("     , 一级部门表 as c,学校名称表 as d,用户表 AS e  where 办公设备信息表.位置 =  b.ID ");
            //sb.Append(" and  办公设备信息表.归属部门 = c.ID and 办公设备信息表.位置 =  b.ID ");
            //sb.Append("  and 办公设备信息表.归属部门 = c.ID  and       办公设备信息表.归属学校 = d.ID ");
            //sb.Append("       and 办公设备信息表.归属教师ID = e.ID   ");
            sb.Append(" SELECT  a.ID, a.编号 ,a.名称,a.资产状态 ,a.投入使用日期,a.型号,a.一级类别名称 as 类型  ,a.负责人,a.存放地点,a.归属学校,a.归属教师ID,a.位置, a.价格 ,a.数量,a.使用方向,    ");
            sb.Append("   a.投入使用日期,c.名称 AS 部门名称 from 办公设备信息表 as a , 一级部门表 as c  where  a.归属部门 = c.ID      ");

            if (model != null)
            {
                //if (model.一级分类 != "" && model.一级分类 != null)
                //{
                //    sb.Append(" and 办公设备信息表.一级类别名称 = '" + model.一级分类 + "' ");
                //}
                //if (model.二级分类 != "" && model.二级分类 != null)
                //{
                //    sb.Append("  and  办公设备信息表.二级类别名称 ='" + model.二级分类 + "'");
                //}
                //if (model.三级分类 != "" && model.三级分类 != null)
                //{
                //    sb.Append(" and 办公设备信息表.三级类别名称 ='" + model.三级分类 + "'");
                //}

                if (model.归属部门 > 0)
                {
                    sb.Append(" and a.归属部门=" + model.归属部门);
                }
                //if (model.负责人 > 0)
                //{
                //    sb.Append(" and a.负责人=" + model.负责人);
                //}
                if (model.负责人名 != "全部" && model.负责人名 != null && model.负责人名 != "")
                {
                    sb.Append(" and a.负责人='" + model.负责人名 + "'");
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
                        sb.Append("and  a.位置 in(");
                        for (int i = 0; i < inlist.Count; i++)
                        {
                            sb.Append(inlist[i] + ",");

                        }
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append(")");
                    }
                    else
                    {
                        sb.Append("and  a.位置 in(0)");
                    }
                }
                if (model.房间 > 0)
                {
                    sb.Append(" and a.位置=" + model.房间);
                }

                if (model.起始投入日期 != "" && model.结束投入日期 != "")
                {
                    sb.Append("  and a.投入使用日期  between '" + model.起始投入日期 + "' and '" + model.结束投入日期 + "'");
                }
                if (model.关键字 != "")
                {
                    sb.Append(" and a.名称 like '%" + model.关键字 + "%'");
                }

            }

            if (xid != "")
            {

                sb.Append(" and a.X_ID in(" + SID + ")");

            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }

     








        public DataSet 查询全部资产信息()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  办公设备信息表.ID, 办公设备信息表.编号 ,办公设备信息表.名称,办公设备信息表.资产状态");
            sb.Append(" ,办公设备信息表.投入使用日期,    办公设备信息表.型号,办公设备信息表.类型 as 类型 ");
            sb.Append(" ,办公设备信息表.归属学校,办公设备信息表.归属教师ID,办公设备信息表.位置,办公设备信息表.归属部门,");
            sb.Append(" 办公设备信息表.价格 ,办公设备信息表.数量,办公设备信息表.使用方向,d.学校名称, e.姓名 AS 负责人,   ");
            sb.Append("      b.名称 AS 房间名称,c.名称 AS 部门名称 from 办公设备信息表 , 房间信息表 AS b ");
            sb.Append("     , 一级部门表 as c,学校名称表 as d,用户表 AS e  where 办公设备信息表.位置 =  b.ID ");
            sb.Append(" and  办公设备信息表.归属部门 = c.ID and 办公设备信息表.位置 =  b.ID ");
            sb.Append("  and 办公设备信息表.归属部门 = c.ID  and       办公设备信息表.归属学校 = d.ID ");
            sb.Append("       and 办公设备信息表.归属教师ID = e.ID   ");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }


        //-------------------------------------------------
        public DataSet DataSet资产状态查询(string sSearch, string flowstate)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT  办公设备信息表.ID, 办公设备信息表.编号 ,办公设备信息表.名称,办公设备信息表.资产状态");
            sb.Append(" ,办公设备信息表.投入使用日期, 办公设备信息表.型号,办公设备信息表.一级类别名称 as 类型 ");
            sb.Append(" ,办公设备信息表.归属学校,办公设备信息表.归属教师ID,办公设备信息表.位置,办公设备信息表.归属部门,");
            sb.Append(" 办公设备信息表.价格 ,办公设备信息表.数量,办公设备信息表.使用方向,d.学校名称, e.姓名 AS 负责人,   ");
            sb.Append("      b.名称 AS 房间名称,c.名称 AS 部门名称 from 办公设备信息表 , dbo.房间信息表 AS b ");
            sb.Append("     , 一级部门表 as c,学校名称表 as d,用户表 AS e  where 办公设备信息表.位置 =  b.ID ");
            sb.Append(" and  办公设备信息表.归属部门 = c.ID and 办公设备信息表.位置 =  b.ID ");
            sb.Append("  and 办公设备信息表.归属部门 = c.ID  and       办公设备信息表.归属学校 = d.ID ");
            sb.Append("       and 办公设备信息表.归属教师ID = e.ID   ");
            if (flowstate == "资产状态-使用中")
            {
                sb.Append(" and 办公设备信息表.资产状态='使用中'");
            }
            //else if (flowstate == "资产状态-已完成")
            //{
            //    sb.Append(" and 资产状态='已完成'");
            //}
            if (sSearch == "")
            {
                sb.Append("");
            }
            else
            {
                sb.Append(" and 办公设备信息表.名称 like '%" + sSearch + "%'");
            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }


        public DataSet 资产处置统计查询表(string sSearch, string flowstate)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT  办公设备信息表.ID, 办公设备信息表.处置临时状态 ,办公设备信息表.编号 ,办公设备信息表.名称,办公设备信息表.资产状态");
            sb.Append(" ,办公设备信息表.投入使用日期, 办公设备信息表.型号,办公设备信息表.一级类别名称 as 类型 ");
            sb.Append(" ,办公设备信息表.归属学校,办公设备信息表.归属教师ID,办公设备信息表.位置,办公设备信息表.归属部门,");
            sb.Append(" 办公设备信息表.价格 ,办公设备信息表.数量,办公设备信息表.使用方向,d.学校名称, e.姓名 AS 负责人,   ");
            sb.Append("      b.名称 AS 房间名称,c.名称 AS 部门名称 from 办公设备信息表 , dbo.房间信息表 AS b ");
            sb.Append("     , 一级部门表 as c,学校名称表 as d,用户表 AS e  where 办公设备信息表.位置 =  b.ID ");
            sb.Append(" and  办公设备信息表.归属部门 = c.ID and 办公设备信息表.位置 =  b.ID ");
            sb.Append("  and 办公设备信息表.归属部门 = c.ID  and       办公设备信息表.归属学校 = d.ID ");
            sb.Append("       and 办公设备信息表.归属教师ID = e.ID   ");
            sb.Append("  and 办公设备信息表.处置临时状态 !='  ' and 办公设备信息表.处置临时状态 != 'null' ");

            if (flowstate == "处置临时状态-待报废")
            {
                sb.Append(" and 办公设备信息表.处置临时状态='待报废' ");
            }
            else if (flowstate == "处置临时状态-待出售")
            {
                sb.Append(" and 办公设备信息表.处置临时状态='待出售' ");
            }
            else if (flowstate == "处置临时状态-待调拨")
            {
                sb.Append(" and 办公设备信息表.处置临时状态='待调拨' ");
            }
            else if (flowstate == "处置临时状态-全部")
            {
                sb.Append("");
            }
            if (sSearch == "")
            {
                sb.Append("");
            }
            else
            {
                sb.Append(" and 办公设备信息表.名称 like '%" + sSearch + "%'");
            }

            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }


        public int 资产处置(List<int> ID, string comtxt)
        {
            List<string> cstrlist = new List<string>();
            string csqls = "";
            foreach (int item in ID)
            {
                csqls = string.Format(" UPDATE 办公设备信息表 SET 处置临时状态 = '{0}' where ID = {1}", comtxt, item);
                cstrlist.Add(csqls.ToString());
            }
            return DBHelper.ExecuteSqlTran(cstrlist);
        }




    }
}
