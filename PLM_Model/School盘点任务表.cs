using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{

    public class School盘点任务表
    {
        public int ID { get; set; }

        public string 名称 { get; set; }

        public DateTime 起始时间 { get; set; }

        public DateTime 截止时间 { get; set; }

        public string 计划日期 { get; set; }

        public int 等级 { get; set; }

        public string 清查范围 { get; set; }

        public string 描述 { get; set; }

        public int 学校ID { get; set; }

        public string 完成状态 { get; set; }

        public string 清查ID { get; set; }

        public string 是否已读 { get; set; }

        public string 盘点完成 { get; set; }


        public string 盘点单号 { get; set; }

        public string 发布方 { get; set; }

        public string 盘点方式 { get; set; }

        public string 单号 { get; set; }

        public string 备注 { get; set; }

    }
}
