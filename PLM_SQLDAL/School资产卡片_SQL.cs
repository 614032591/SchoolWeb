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
    public class School资产卡片_SQL
    {
        public List<School办公设备信息表> 查询所有资产()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select  * from (select   row_number() over(order by 办公设备信息表.ID) as row, 办公设备信息表.ID, 办公设备信息表.编号 ,  ");
            sb.Append("    办公设备信息表.名称,办公设备信息表.资产状态 ,办公设备信息表.投入使用日期,   ");
            sb.Append(" 办公设备信息表.型号,办公设备信息表.一级类别名称 as 类型 ");
            sb.Append(" ,办公设备信息表.归属学校,办公设备信息表.归属教师ID,办公设备信息表.位置,办公设备信息表.归属部门,办公设备信息表.价格 ,办公设备信息表.数量,办公设备信息表.使用方向,d.学校名称, e.姓名 AS 负责人,   ");
            sb.Append("     b.名称 AS 房间名称,c.名称 AS 部门名称 ");
            sb.Append("from 办公设备信息表 , dbo.房间信息表 AS b , 一级部门表 as c,学校名称表 as d,用户表 AS e  where 办公设备信息表.位置 =  b.ID and  ");
            sb.Append("办公设备信息表.归属部门 = c.ID and 办公设备信息表.位置 =  b.ID and 办公设备信息表.归属部门 = c.ID  and ");
            sb.Append("      办公设备信息表.归属学校 = d.ID  and 办公设备信息表.归属教师ID = e.ID  ");
            sb.Append(")  as a");

            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            List<School办公设备信息表> list = new List<School办公设备信息表>();
            while (read.Read())
            {
                School办公设备信息表 model = new School办公设备信息表();
                model.ID = Convert.ToInt32(read["ID"].ToString());
                model.编号 = read["编号"].ToString();
                model.名称 = read["名称"].ToString();
                model.资产状态 = read["资产状态"].ToString();
                model.投入使用日期 = read["投入使用日期"].ToString();
                model.型号 = read["型号"].ToString();
                model.类型 = read["类型"].ToString();
                model.学校名称 = read["学校名称"].ToString();
                model.归属教师ID = Convert.ToInt32(read["归属教师ID"].ToString());
                model.负责人 = read["负责人"].ToString();
                model.房间名称 = read["房间名称"].ToString();
                model.部门名称 = read["部门名称"].ToString();
                model.价格 = Convert.ToDouble(read["价格"].ToString());
                model.数量 = Convert.ToInt32(read["数量"].ToString());
                model.使用方向 = read["使用方向"].ToString();

                list.Add(model);
            }
            return list;
        }


        public DataSet DataSet查询所有资产()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select  * from (select   row_number() over(order by 办公设备信息表.ID) as row, 办公设备信息表.ID, 办公设备信息表.编号 ,  ");
            sb.Append("    办公设备信息表.名称,办公设备信息表.资产状态 ,办公设备信息表.投入使用日期,   ");
            sb.Append(" 办公设备信息表.型号,办公设备信息表.一级类别名称 as 类型 ");
            sb.Append(" ,办公设备信息表.归属学校,办公设备信息表.归属教师ID,办公设备信息表.位置,办公设备信息表.归属部门,办公设备信息表.价格 ,办公设备信息表.数量,办公设备信息表.使用方向,d.学校名称, e.姓名 AS 负责人,   ");
            sb.Append("     b.名称 AS 房间名称,c.名称 AS 部门名称 ");
            sb.Append("from 办公设备信息表 , dbo.房间信息表 AS b , 一级部门表 as c,学校名称表 as d,用户表 AS e  where 办公设备信息表.位置 =  b.ID and  ");
            sb.Append("办公设备信息表.归属部门 = c.ID and 办公设备信息表.位置 =  b.ID and 办公设备信息表.归属部门 = c.ID  and ");
            sb.Append("      办公设备信息表.归属学校 = d.ID  and 办公设备信息表.归属教师ID = e.ID  ");
            sb.Append(")  as a");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }
    }
}
