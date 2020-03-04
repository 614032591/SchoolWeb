using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{

    public class School盘点报告
    {
        public int ID { get; set; }

        public string 部门 { get; set; }

        public string 负责人 { get; set; }

        public string 房屋及构筑物 { get; set; }

        public string 通用设备 { get; set; }

        public string 专用设备 { get; set; }

        public string 家具用具装具 { get; set; }

        public string 文物陈列品 { get; set; }

        public string 图书 { get; set; }

        public int 盘亏数量 { get; set; }

        public int 盘亏金额 { get; set; }
    }
}
