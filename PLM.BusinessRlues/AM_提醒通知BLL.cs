using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    public class AM_提醒通知BLL
    {
        AM_提醒通知SQL sql = new AM_提醒通知SQL();
        public DataSet 全部消息()
        {
            return sql.全部消息();
        }
        public int 默认消息数()
        {
            return sql.默认消息数();
        }//sss
        public DataSet 条件查询(string str)
        {
            return sql.条件查询(str);
        }
        public int 条件消息数(string str)
        {
            return sql.条件消息数(str);
        }
        public List<AM_提醒通知> 判断颜色()
        {
            return sql.判断颜色();
        }
        public int 全部已读()
        {
            return sql.全部已读();

        }
        public int 选中已读(int ID)
        {
            return sql.选中已读(ID);
        }
        public DataSet xiala()
        {
            return sql.xiala();
        }
    }
}
