using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using PLM_SQLDAL;
namespace PLM_Model
{
    public class School资产卡片BLL
    {
        School资产卡片_SQL us = new School资产卡片_SQL();
        public List<School办公设备信息表> 查询所有资产()
        {
            return us.查询所有资产();
        }

        public DataSet DataSet查询所有资产()
        {
            return us.DataSet查询所有资产();
        }
    }
}
