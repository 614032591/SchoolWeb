using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class SchoolX_资产报修流程表
    {
        public int ID { get; set; }

        public string 流程状态 { get; set; }

        public string 报修单号 { get; set; }

        public string 报修人 { get; set; }

        public string 报修时间 { get; set; }

        public string 报修地址 { get; set; }

        public string 故障描述 { get; set; }

        public string 维修人员 { get; set; }

        public string 完工时间 { get; set; }

        public string 结果反馈 { get; set; }
        public string 故障照片 { get; set; }
        public string 设备ID { get; set; }
        public string 报修人电话 { get; set; }
        public string 维修人电话 { get; set; }
        public string 管理员电话 { get; set; }
        public string 派单时间 { get; set; }
        public string 故障原因 { get; set; }
        public string 管理员 { get; set; }
        public string 解决时间 { get; set; }
    }
}
