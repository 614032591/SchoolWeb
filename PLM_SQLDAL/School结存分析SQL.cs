using PLM_Common;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM_SQLDAL
{
    public class School结存分析SQL
    {
        public DataSet 结存分析条件查询(School条件查询表 model)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" select A.编号 as 资产编号,A.类型,A.名称,A.型号,A.购置日期,A.负责人,A.存放地点,A.使用方向,A.数量,A.价格,A.原值,A.净值, B.名称 as 归属部门   from 办公设备信息表 as A,一级部门表 as B where B.ID=A.归属部门  ");
            //sb.Append("SELECT  A.ID, A.资产编号, A.资产代码 , A.标签值, A.类别代码 , A.资产名称 , A.取得方式, A.规格型号, A.产品序列号 ");
            //sb.Append(" , A.计量单位, A.取得日期, A.入账日期, A.价值类型 , A.账面数量, A.账面原值 , A.账面累计折旧 , A.账面净值 ");
            //sb.Append(" , A.清查数量 , A.清查原值, A.清查累计折旧 , A.清查净值, A.损益类型, A.使用状况, A.使用部门 ");
            //sb.Append(", A.使用人, A.原资产编号, A.清查基准日, A.备注 , A.录入日期 , A.累计使用年限, A.权属性质, A.是否确权   ");
            //sb.Append("    , A.入账形式, A.单位 ,B.名称 as 类别名称,C.名称 as 存放地点   ");
            //sb.Append("   FROM   资产表 as A,一级类别表 as B,建筑物信息表 as C ");
            //sb.Append(" ,一级部门表 as D");
            //sb.Append(" where  A.类别代码 = B.ID  and A.存放地点 = C.ID ");
            //sb.Append("  and A.使用部门 = D.ID ");
            if (model != null)
            {
                if (model.一级分类 != "" && model.一级分类 != null)
                {
                    sb.Append(" and A.一级类别名称 = '" + model.一级分类 + "' ");
                }
                if (model.二级分类 != "" && model.二级分类 != null)
                {
                    sb.Append("  and  A.二级类别名称 ='" + model.二级分类 + "'");
                }
                if (model.三级分类 != "" && model.三级分类 != null)
                {
                    sb.Append(" and A.三级类别名称 ='" + model.三级分类 + "'");
                }
                if (model.归属部门 > 0)
                {
                    sb.Append(" and A.归属部门=" + model.归属部门);
                }
                if (model.负责人 !="" && model.负责人 != null)
                {
                    sb.Append(" and A.负责人=" + model.负责人);
                }

                if (model.存放地点 !="" && model.存放地点!=null)
                {
                    sb.Append(" and A.存放地点='" + model.存放地点+"'");
                }
                if (model.房间 != "" && model.房间 !=null)
                {
                    sb.Append(" and A.位置=" + model.房间);
                }

                if (model.结束投入日期 != "")
                {
                    sb.Append("  and A.入账日期  <= '" + model.结束投入日期 + "'");
                }
                if (model.关键字 != "")
                {
                    sb.Append(" and A.名称 like '%" + model.关键字 + "%'");
                }

            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }
    }
}
