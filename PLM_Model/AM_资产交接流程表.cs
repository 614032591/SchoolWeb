using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class AM_资产交接流程表
    {
        public int ID { get; set; }

        public string 流程状态 { get; set; }

        public int Sort { get; set; }
        public string 发起人 { get; set; }
        public string 单据编号 { get; set; }
        public string 资产数量 { get; set; }
        public string 交付人 { get; set; }
        public string 接收人 { get; set; }

        public string 提交时间 { get; set; }
        public string 备注信息 { get; set; }
        public string 完成时间 { get; set; }
        public string 资产ID { get; set; }
        public string 接收人接收时间 { get; set; }
        public string 是否接收 { get; set; }
        public string 管理员 { get; set; }
        public string 管理员通过时间 { get; set; }
        public string 管理员是否通过 { get; set; }





    }
}
