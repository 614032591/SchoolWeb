using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class SchoolX_原值变动流程表
    {
        public int ID { get; set; }

        public string 流程状态 { get; set; }

        public string 单据编号 { get; set; }

        public string 事项名称 { get; set; }

        public string 申请人 { get; set; }

        public string 申请日期 { get; set; }

        public string 记账人 { get; set; }

        public int 总数 { get; set; }

        public double 总价 { get; set; }

        public string 变动方式 { get; set; }

        public string 变动原因 { get; set; }

        public string 记账人意见 { get; set; }

        public string 备注信息 { get; set; }

        public string 资产ID { get; set; }

        public int 变动金额 { get; set; }

        public string  str变动金额 { get; set; }

        public string 备注 { get; set; }

        public string 变动金额Json { get; set; }

        public string 是否同意 { get; set; }

        public string 操作时间 { get; set; }
        public string 操作人 { get; set; }

        public string 驳回意见 { get; set; }
    }
}
