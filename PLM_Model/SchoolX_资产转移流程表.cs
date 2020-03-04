using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class SchoolX_资产转移流程表
    {
        public int ID { get; set; }

        public string 流程状态 { get; set; }

        public string 单据编号 { get; set; }

        public string 事项名称 { get; set; }

        public string 申请人 { get; set; }

        public string 申请日期 { get; set; }

        public string 联系方式 { get; set; }

        public string 存放地点变更为 { get; set; }

        public string 归属部门变更为 { get; set; }

        public string 负责人变更为 { get; set; }

        public string 备注信息 { get; set; }

        public string S_ID { get; set; }

        public int 总数 { get; set; }

        public int 总价 { get; set; }
    }
}
