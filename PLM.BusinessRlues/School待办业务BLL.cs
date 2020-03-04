using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    public class School待办业务BLL
    {
        School代办业务SQL sql = new School代办业务SQL();
        public int 总数(string str, string sr)
        {
            return sql.总数(str, sr);
        }
        public int 总数我处理(string str)
        {
            return sql.总数我处理(str);
        }
        public DataSet 职务条件(string str, string a)
        {
            return sql.职务条件(str, a);
        }
        public int 我发起的数量(string str)
        {
            return sql.我发起的数量(str);
        }
        public DataSet 查询我发起的(string str)
        {
            return sql.查询我发起的(str);
        }
        public DataSet 查事项名称(string id, string nm)
        {
            return sql.查事项名称(id, nm);
        }
        public List<string> 查询全部事项名称()
        {
            return sql.查询全部事项名称();
        }
        public int 事项拥有的数量(string str, string renming, string zhiwu)
        {
            return sql.事项拥有的数量(str, renming, zhiwu);
        }
        public int 我发起的事项数量(string str, string sf)
        {
            return sql.我发起的事项数量(str, sf);
        }
        public DataSet 待我处理事项查询(string rm, string zw, string sx)
        {
            return sql.待我处理事项查询(rm, zw, sx);
        }
        public DataSet 我发起的事项查询(string rm, string sx)
        {
            return sql.我发起的事项查询(rm, sx);
        }
        public int C数量(string str, string stt)
        {
            return sql.C数量(str, stt);
        }
        public int R数量(string str, string stt)
        {
            return sql.R数量(str, stt);
        }
        //待办处理-------------------------------------------------------------
        public SchoolX_资产报修流程表 获取报修信息(int 待办id)
        {
            return sql.获取报修信息(待办id);
        }
        public int 报修Sort(int id)
        {
            return sql.报修Sort(id);
        }



        //资产转移--------------------------------------------------------------
        public SchoolX_资产转移流程表 获取资产转移信息(int id)
        {
            return sql.获取资产转移信息(id);
        }
    }
}
