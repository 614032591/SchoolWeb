using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class AM_资产借还流程表
    {
        public int ID { get; set; }

        public string 流程状态 { get; set; }

        public int Sort { get; set; }

        public string 发起人 { get; set; }

        public string 借用人 { get; set; }

        public string 提交时间 { get; set; }

        public string 预计归还时间 { get; set; }

        public string 单据编号 { get; set; }

        public string 借出人 { get; set; }

        public string 借用时间 { get; set; }

        public string 备注信息 { get; set; }

        public string 资产ID { get; set; }

        public string 是否同意 { get; set; }

        public string 借出人操作时间 { get; set; }

        public string 操作人 { get; set; }

        public string 申请人是否归还 { get; set; }

        public string 申请人归还时间 { get; set; }

        public string 出借人确认归还 { get; set; }

        public string 出借人确认时间 { get; set; }


    }
}
