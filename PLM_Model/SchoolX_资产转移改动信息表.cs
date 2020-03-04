using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class SchoolX_资产转移改动信息表
    {
        public int ID { get; set; }

        public int 转移流程表ID { get; set; }

        public int 办公设备信息表ID { get; set; }

        public string 原存放地点 { get; set; }

        public string 原归属部门 { get; set; }

        public string 原负责人 { get; set; }

        public string 现存放地点 { get; set; }

        public string 现归属部门 { get; set; }

        public string 现负责人 { get; set; }
    }
}
