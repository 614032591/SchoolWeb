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
    public class School流程进度查看详情SQL
    {
        public List<流程进度查看详情表> 资产处置待报废查看详情(string ID,string SID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT * FROM X_资产处置流程表  where ID = " + ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            List<流程进度查看详情表> list = new List<流程进度查看详情表>();
            while (read.Read())
            {
                流程进度查看详情表 model = new 流程进度查看详情表();
                model.ID = Convert.ToInt32(read["ID"].ToString());
                model.FlowName= read["FlowName"].ToString();
                model.单据编号= read["单据编号"].ToString();
                model.流程状态= read["流程状态"].ToString();
                model.申报日期= read["申报日期"].ToString();
                model.申报单位= read["申报单位"].ToString();
                model.SID= read["SID"].ToString();
                model.总数 = Convert.ToInt32(read["总数"].ToString());
                model.总价 = Convert.ToInt32(read["总价"].ToString());
                model.原因说明 = read["原因说明"].ToString();
                model.申请人 = read["申请人"].ToString();
                model.职务 = read["职务"].ToString();
                model.电话 = read["电话"].ToString();
                model.事项名称 = read["事项名称"].ToString();
                model.验收日期 = read["验收日期"].ToString();
                model.调入单位 = read["调入单位"].ToString();
                model.调出单位 = read["调出单位"].ToString();
                model.调入单位分管领导意见 = read["调入单位分管领导意见"].ToString();
                model.调入单位分管领导 = read["调入单位分管领导"].ToString();
                model.调入单位分管领导处理时间 = read["调入单位分管领导处理时间"].ToString();
                model.主管部门意见 = read["主管部门意见"].ToString();
                model.主管部门处理时间 = read["主管部门处理时间"].ToString();
                model.主管部门 = read["主管部门"].ToString();
                model.财政部门意见 = read["财政部门意见"].ToString();
                model.财政部门 = read["财政部门"].ToString();
                model.财政部门处理时间 = read["财政部门处理时间"].ToString();




                model.调出单位分管领导意见 = read["调出单位分管领导意见"].ToString();
                model.调出单位分管领导 = read["调出单位分管领导"].ToString();
                model.调出单位分管领导处理时间 = read["调出单位分管领导处理时间"].ToString();
                model.调入单位管理员意见 = read["调入单位管理员意见"].ToString();
                model.调入单位管理员 = read["调入单位管理员"].ToString();
                model.调入单位管理员处理时间 = read["调入单位管理员处理时间"].ToString();
                #region
                //    string[] condition = { "," };
                //    string[] result = SID.Split(condition, StringSplitOptions.RemoveEmptyEntries);

                //    StringBuilder sbd = new StringBuilder();
                //    sbd.Append("     select a.ID, a.编号 ,a.名称,a.资产状态 ,a.投入使用日期,    a.型号,a.一级类别名称 as 类型  ");
                //    sbd.Append(" ,a.归属学校,a.归属教师ID,a.位置,a.归属部门,a.价格 ,a.数量,   ");
                //    sbd.Append(" a.使用方向,d.学校名称, e.姓名 AS 负责人,        b.名称 AS 房间名称,c.名称 AS 部门名称  from 办公设备信息表 as a , dbo.房间信息表 AS b , 一级部门表 as c,学校名称表 as d,用户表 AS e    ");

                //    sbd.Append("  where  (");
                //    foreach (string item in result)
                //    {
                //        sbd.Append(" a.ID  =" + item + " or ");
                //    }

                //    string sqlsb = sbd.ToString();
                //    string sqly = sqlsb.Substring(0, sqlsb.Length - 3);//循环多个or 删减最后两个字符
                //    sqly += ") and a.位置 =  b.ID and  a.归属部门 = c.ID and a.位置 = b.ID and a.归属部门 = c.ID  and   a.归属学校 = d.ID  and a.归属教师ID = e.ID";
                //    SqlDataReader reada = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sqly.ToString());

                //    while (reada.Read())
                //    {
                //        //流程进度查看详情表 modela = new 流程进度查看详情表();
                //        model.BID = Convert.ToInt32(reada["ID"].ToString());
                //        model.类型 = reada["类型"].ToString();
                //        try
                //        {
                //            model.价格 = Convert.ToDouble(reada["价格"].ToString());
                //        }
                //        catch (Exception)
                //        {
                //            model.价格 = 0;
                //            //throw;
                //        }
                //        model.数量 = Convert.ToInt32(reada["数量"].ToString());
                //        model.名称 = reada["名称"].ToString();
                //        model.编号 = reada["编号"].ToString();
                //        model.型号 = reada["型号"].ToString();
                //        model.部门名称 = reada["部门名称"].ToString();
                //        model.房间名称 = reada["房间名称"].ToString();
                //        model.资产状态 = reada["资产状态"].ToString();
                //        model.负责人 = reada["负责人"].ToString();
                //        //modela.处置方式 = mark;
                //        //list.Add(modela);

                #endregion
                list.Add(model);
            //}          
            }
            return list;
            
        }


        public List<流程进度查看详情表> 购置验收查看详情(string ID, string SID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT * FROM X_购置验收流程表  where ID = " + ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            List<流程进度查看详情表> list = new List<流程进度查看详情表>();
            while (read.Read())
            {
                流程进度查看详情表 model = new 流程进度查看详情表();
                model.ID = Convert.ToInt32(read["ID"].ToString());
                //model.FlowName = read["FlowName"].ToString();              
                model.流程状态 = read["流程状态"].ToString();
                model.事项名称 = read["事项名称"].ToString();                
                model.单据编号 = read["单据编号"].ToString();
                model.取得方式 = read["取得方式"].ToString();
                model.制单日期 = read["制单日期"].ToString();
                model.购置日期s = read["购置日期"].ToString();
                model.供应商 = read["供应商"].ToString();
                model.供应商联系方式 = read["供应商联系方式"].ToString();
                model.合同编号 = read["合同编号"].ToString();
                model.发票号 = read["发票号"].ToString();
                model.申请人 = read["申请人"].ToString();
                model.记账人 = read["记账人"].ToString();
                model.数量合计 = read["数量合计"].ToString();
                model.金额合计 = read["金额合计"].ToString();
                model.备注信息 = read["备注信息"].ToString();
           
                list.Add(model);
                //}          
            }
            return list;

        }






        public string 资产处置SID(int ID)
        {
            string sql = string.Format("SELECT SID FROM X_资产处置流程表 WHERE ID=" + ID);
            //string sql = string.Format("SELECT B.名称 as 调入单位  FROM 用户表 as A,一级部门表 as B where A.学校ID=B.ID and A.ID=" + ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            if (read.Read())
            {
                string fname = read["SID"].ToString();
                return fname;
            }
            else
            {
                return "空";
            }
        }
    }
}
