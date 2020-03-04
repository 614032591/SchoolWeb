using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class School办公设备信息表
    {
        public int ID { get; set; }

        public string 编号 { get; set; }

        public string 名称 { get; set; }

        public string 类型 { get; set; }

        public string 型号 { get; set; }

        public int 位置 { get; set; }

        public int 归属部门 { get; set; }

        public string str归属部门 { get; set; }

        public string 使用方向 { get; set; }

        public string 生产厂家 { get; set; }

        public string 投运日期 { get; set; }

        public string 备注 { get; set; }

        public string 标签值 { get; set; }

        public int 异常状态 { get; set; }

        public int 借用 { get; set; }

        public int 故障状态 { get; set; }

        public int 归属学校 { get; set; }

        public int 标识 { get; set; }


        public int 归属教师ID { get; set; }

        public string 处置临时状态 { get; set; }

        public string 学校名称 { get; set; }

        public string 负责人 { get; set; }

        public string 房间名称 { get; set; }

        public string 部门名称 { get; set; }


        public string 处置状态 { get; set; }

        public double 价格 { get; set; }

        public int 是否已读 { get; set; }

        public string 小分类名称 { get; set; }

        public string 增加方式 { get; set; }

        public DateTime 购置日期 { get; set; }

        public string 投入使用日期 { get; set; }

        public int 预计使用年数 { get; set; }

        public string 使用状态 { get; set; }

        public string 大分类名称 { get; set; }

        public string 一级类别名称 { get; set; }
        public string 二级类别名称 { get; set; }
        public string 三级类别名称 { get; set; }

        public string 存放地点 { get; set; }

        public int 使用部门 { get; set; }

        public string 资产状态 { get; set; }

        public DateTime 维修日期 { get; set; }

        public string 异常日期 { get; set; }

        public DateTime 处置日期 { get; set; }

        public string 处置类型 { get; set; }

        public string 处置方式 { get; set; }

        public int 盘点 { get; set; }

        public int 二级盘点 { get; set; }

        public int 三级盘点 { get; set; }

        public int 盘点状态 { get; set; }

        public int 二级盘点状态 { get; set; }

        public int 三级盘点状态 { get; set; }

        public int 处置记录ID { get; set; }

        public int 是否盘盈 { get; set; }

        public int 盘点记录ID { get; set; }

        public int 临时申报ID { get; set; }

        public int 是否已登记 { get; set; }

        public int 数量 { get; set; }

        public string 拍照补录 { get; set; }

        public double 变动金额 { get; set; }

        public int 变动后金额 { get; set; }
    }
}
