using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    public class 消息中心BLL
    {
        消息中心SQL sql = new 消息中心SQL();
        public int 未读总数(string 通知职务)
        {
            return sql.未读总数(通知职务);
        }

        public DataSet 查询消息中心(string 职务)
        {
            return sql.查询消息中心(职务);
        }
    }
}
