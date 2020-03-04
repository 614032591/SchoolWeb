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
    public class School代办业务SQL
    {
        public int 总数(string renming, string zhiwu)
        {
            string sql = string.Format("SELECT count(*) FROM AM_待办业务 where (( 处理方式='个人' AND 处理人='" + renming + "') OR (处理方式='职务' AND 处理职务='" + zhiwu + "')) AND Sort>0");
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString()));
        }
        public int 总数我处理(string str)
        {
            string sql = string.Format("SELECT COUNT(*) FROM AM_待办业务 WHERE 发起人='{0}'", str);
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString()));
        }
        public DataSet 职务条件(string renming, string zhiwu)
        {
            string sql = string.Format("SELECT * FROM AM_待办业务 WHERE (( 处理方式='个人' AND 处理人='" + renming + "') OR (处理方式='职务' AND 处理职务='" + zhiwu + "')) AND Sort>0");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
        }
        public int 我发起的数量(string str)
        {
            string sql = string.Format("SELECT COUNT(*) FROM AM_待办业务 WHERE 发起人='{0}'", str);
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString()));
        }
        public DataSet 查询我发起的(string str)
        {
            string sql = string.Format("SELECT * FROM AM_待办业务 WHERE 发起人='{0}'", str);
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
        }
        public List<string> 查询全部事项名称()
        {
            string sql = string.Format("SELECT distinct FlowName  FROM AM_待办业务");
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            List<string> list = new List<string>();
            while (read.Read())
            {
                list.Add(read["FlowName"].ToString());
            }
            return list;
        }
        public int 事项拥有的数量(string str, string renming, string zhiwu)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(*) FROM AM_待办业务 WHERE (( 处理方式='个人' AND ");
            sb.Append("处理人='" + renming + "')");
            sb.Append("OR (处理方式='职务' AND 处理职务='" + zhiwu + "')) AND FlowName='" + str + "' AND Sort>0");
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString()));

        }
        public int 我发起的事项数量(string rm, string sx)
        {
            string sql = string.Format("SELECT COUNT(*) FROM AM_待办业务 WHERE 发起人='{0}' AND FlowName='{1}'", rm, sx);
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString()));
        }
        public DataSet 查事项名称(string id, string nm)
        {
            string sql = string.Format("SELECT * FROM AM_待办业务 WHERE 事项名称='{0}' and 发起人='{1}'", id, nm);
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
        }
        //public DataSet 职务事项发起(string z, string s, string f)
        //{
        //    string sql=string.Format("SELECT * FROM AM_待办业务 WHERE ")
        //}
        public DataSet 待我处理事项查询(string rm, string zw, string sx)
        {
            string sql = string.Format("SELECT * FROM AM_待办业务 WHERE  (( 处理方式='个人' AND 处理人='" + rm + "') OR (处理方式='职务' AND 处理职务='" + zw + "')) and FlowName='" + sx + "' AND Sort>0");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
        }
        public DataSet 我发起的事项查询(string rm, string sx)
        {
            string sql = string.Format("SELECT * FROM AM_待办业务 WHERE 发起人='" + rm + "' AND FlowName='" + sx + "'");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
        }
        public int C数量(string str, string stt)
        {
            string sql = string.Format("SELECT COUNT(*) FROM AM_待办业务 WHERE 事项名称='{0}' AND 处理职务='{1}'", str, stt);
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString()));
        }
        public int R数量(string str, string stt)
        {
            string sql = string.Format("SELECT COUNT(*) FROM AM_待办业务 WHERE 事项名称='{0}' AND 发起人='{1}'", str, stt);
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString()));
        }

        //待办处理________________________________________________________________________________________________
        public SchoolX_资产报修流程表 获取报修信息(int 待办id)
        {
            string sql = string.Format("SELECT FlowID FROM AM_待办业务 WHERE ID=" + 待办id);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            int xx;
            SchoolX_资产报修流程表 model = new SchoolX_资产报修流程表();
            if (read.Read())
            {
                xx = Convert.ToInt32(read["FlowID"]);
                string str = string.Format("SELECT * FROM X_资产报修流程表 WHERE ID=" + xx);
                SqlDataReader readd = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, str.ToString());

                if (readd.Read())
                {
                    model.报修人 = readd["报修人"].ToString();
                    model.报修时间 = readd["报修时间"].ToString();
                    model.报修单号 = readd["报修单号"].ToString();
                    model.报修地址 = readd["报修地址"].ToString();
                    model.维修人员 = readd["维修人员"].ToString();
                    model.解决时间 = readd["解决时间"].ToString();
                    model.管理员 = readd["管理员"].ToString();
                    model.派单时间 = readd["派单时间"].ToString();
                    model.报修人电话 = readd["报修人电话"].ToString();
                    model.维修人电话 = readd["维修人电话"].ToString();
                    model.管理员电话 = readd["管理员电话"].ToString();
                    model.故障照片 = readd["故障照片"].ToString();
                    model.故障原因 = readd["故障原因"].ToString();
                    model.结果反馈 = readd["结果反馈"].ToString();
                    model.设备ID = readd["设备ID"].ToString();
                }
            }
            read.Close();
            return model;
        }
        public int 报修Sort(int id)
        {
            string sql = string.Format("SELECT * FROM X_资产报修流程表 WHERE ID=" + id);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                return Convert.ToInt32(read["Sort"]);
            }
            else
            {
                return 0;
            }
        }


        #region 获取资产转移信息
        public SchoolX_资产转移流程表 获取资产转移信息(int id)
        {
            string sql = string.Format("SELECT * FROM X_资产转移流程表 WHERE ID=" + id);
            SchoolX_资产转移流程表 model = new SchoolX_资产转移流程表();
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                model.流程状态 = read["流程状态"].ToString();
                model.单据编号 = read["单据编号"].ToString();
                model.事项名称 = read["事项名称"].ToString();
                model.申请人 = read["申请人"].ToString();
                model.申请日期 = read["申请日期"].ToString();
                model.联系方式 = read["联系方式"].ToString();

            }
            return model;
        }
        #endregion

    }
}
