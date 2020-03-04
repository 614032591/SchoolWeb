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
    public class 用户操作SQL
    {
        public 用户表 UserLogin(用户表 au) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT A.ID, A.用户名,A.权限,A.姓名,A.部门ID,A.学校ID,A.职务,A.人员照片,C.名称 as 部门名称,C.名称 as 学校名称 FROM 用户表 as a");
            sb.Append(" INNER   join 一级部门表    as c ON a.部门ID=c.ID ");
            sb.Append("INNER JOIN 学校名称表 as s ON c.学校ID =  s.ID");
            sb.Append("    where (A.用户名=@username and A.密码 =@userpassword)");
            SqlParameter[] para = { new SqlParameter("username", au.用户名), new SqlParameter("@userpassword", au.密码) };
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para);
            用户表 csuser = new 用户表();
            if (read.Read())
            {
                csuser.ID = Convert.ToInt32(read["ID"]);
                csuser.用户名 = read["用户名"].ToString();
                csuser.权限 = Convert.ToInt32(read["权限"]);
                csuser.二级部门ID = Convert.ToInt32(read["学校ID"]);
                csuser.三级部门ID = Convert.ToInt32(read["部门ID"]);
                csuser.姓名 = read["姓名"].ToString();
                csuser.职务 = read["职务"].ToString();
                csuser.人员照片 = read["人员照片"].ToString();
                csuser.三级部门名称 = read["部门名称"].ToString();
                csuser.二级部门名称 = read["学校名称"].ToString();
            }
            read.Close();
            return csuser;
        }
    }
}
