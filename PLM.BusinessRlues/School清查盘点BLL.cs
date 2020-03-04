using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{

    public class School清查盘点BLL
    {
        School清查盘点SQL us = new School清查盘点SQL();

        public Boolean addpdrw(School盘点任务表 model)
        {
            return us.addpdrw(model);
        }


        public DataSet DataSet清查盘点()
        {
            return us.DataSet清查盘点();
        }

        public List<School盘点进度> 查询盘点进度(int sid, string 清查范围)
        {
            return us.查询盘点进度(sid, 清查范围);
        }

        public DataSet 拍照补录查询(string whe)
        {
            return us.拍照补录查询(whe);
        }

        public DataSet 盘亏处理查询(string whe)
        {
            return us.盘亏处理查询(whe);
        }

        public List<School盘点报告> 查询盘点报告()
        {
            return us.查询盘点报告();
        }

        public DataSet 筛选存放地点(int id)
        {
            return us.筛选存放地点(id);
        }

        public DataSet 筛选用户(int id)
        {
            return us.筛选用户(id);
        }

        public DataSet 查询部门()
        {
            return us.查询部门();
        }


        public List<School学校名称表> 查询学校名称()
        {
            return us.查询学校名称();
        }

        public List<School一级部门表> 查询一级部门()
        {
            return us.查询一级部门();
        }

        public List<School一级类别表> 查询一级类别()
        {
            return us.查询一级类别();
        }


        public List<School一级类别表> 查询一级类别s()
        {
            return us.查询一级类别s();

        }

        public List<School二级类别表> 查询二级类别s(int id)
        {
            return us.查询二级类别s(id);
        }

        public List<School三级类别表> 查询三级类别s(int id)
        {
            return us.查询三级类别s(id);
        }



        public List<School二级类别表> 查询二级类别(int id)
        {
            return us.查询二级类别(id);
        }

        public List<School三级类别表> 查询三级类别(int id)
        {
            return us.查询三级类别(id);
        }

        public List<School房间信息表> 查询房间信息表(int id)
        {
            return us.查询房间信息表(id);
        }

        public List<School建筑物信息表> 查询建筑物信息表()
        {
            return us.查询建筑物信息表();
        }
        public List<School盘点人员进度> 查询盘点人员进度(int ID)
        {
            return us.查询盘点人员进度(ID);
        }
        public List<School一级类别表> 一级类别()
        {
            return us.一级类别();
        }

        public List<School二级类别表> 二级类别()
        {
            return us.二级类别();
        }

        public List<School一级部门表> 一级部门()
        {
            return us.一级部门();
        }

        //public int 一级部门ID(string part)
        //{
        //    return us.一级部门ID(part);
        //}

        public List<用户表> 用户表()
        {
            return us.用户表();
        }

        public List<School建筑物信息表> 建筑物信息表()
        {
            return us.建筑物信息表();
        }

        public List<School一级类别表> 查询一级类别(string kind)
        {
            return us.查询一级类别(kind);
        }

        public List<School二级类别表> 查询二级类别(string kind)
        {
            return us.查询二级类别(kind);
        }

        public List<School三级类别表> 三级(string kind)
        {
            return us.三级(kind);
        }
    }
}
