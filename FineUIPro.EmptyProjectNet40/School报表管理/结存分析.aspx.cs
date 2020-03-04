﻿using Newtonsoft.Json.Linq;
using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.School报表管理
{
    public partial class 结存分析 : System.Web.UI.Page
    {
        School折旧分析BLL bll = new School折旧分析BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                负责人.Enabled = false;
                房间.Enabled = false;
                二级.Enabled = false;
                三级.Enabled = false;
                //btnCheckSelection.OnClientClick = Grid1.GetNoSelectionAlertInTopReference("没有选中项！");
                //BindGrid();

                School清查盘点BLL pdbll = new School清查盘点BLL();

                List<School一级部门表> xxmc = pdbll.查询一级部门();
                部门.DataTextField = "名称";
                部门.DataValueField = "ID";
                部门.DataSource = xxmc;
                部门.DataBind();
                部门.EmptyText = "全部";

                List<School一级类别表> yjlb = pdbll.查询一级类别();
                一级.DataTextField = "名称";
                一级.DataValueField = "ID";
                一级.DataSource = yjlb;
                一级.DataBind();
                一级.EmptyText = "全部";

                List<School建筑物信息表> 查询建筑物 = pdbll.查询建筑物信息表();
                存放地点.DataTextField = "名称";
                存放地点.DataValueField = "ID";
                存放地点.DataSource = 查询建筑物;
                存放地点.DataBind();
                存放地点.EmptyText = "全部";

                二级.Enabled = false;
                三级.Enabled = false;
                负责人.Enabled = false;
                房间.Enabled = false;

                二级.EmptyText = "全部";
                三级.EmptyText = "全部";
                负责人.EmptyText = "全部";
                房间.EmptyText = "全部";



                DataSet ds = bll.资产明细查询();
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                DataTable source = dt;

                // 3.绑定到Grid
                Grid2.DataSource = dt;//DataTable
                Grid2.DataBind();

                OutputSummaryData1(dt);

                DataSet dsa = bll.资产汇总查询();

                DataTable dta = dsa.Tables[0].Copy();//复制一份table
                DataTable sourcea = dta;
                // 3.绑定到Grid
                Grid1.DataSource = dta;//DataTable
                Grid1.DataBind();

                OutputSummaryData(dta);

            }
        }

        private void OutputSummaryData(DataTable source)
        {
            float 总清查数量 = 0.0f;
            float 总账面原值 = 0.0f;
            float 累计折旧 = 0.0f;
            float 总账面净值 = 0.0f;
            foreach (DataRow row in source.Rows)
            {
                总清查数量 += Convert.ToInt32(row["总清查数量"]);
                if (row["总账面原值"]==DBNull.Value)
                {
                    总账面原值 += 0;
                }
                else
                {
                    总账面原值 += Convert.ToInt32(row["总账面原值"]);
                }

                if (row["总账面净值"] == DBNull.Value)
                {
                    总账面净值 += 0;
                }
                else
                {
                    总账面净值 += Convert.ToInt32(row["总账面净值"]);
                }

                累计折旧 += Convert.ToInt32(row["累计折旧"]);
                //总账面净值 += Convert.ToInt32(row["总账面净值"]);
            }
            JObject summary = new JObject();
            summary.Add("名称", "合计");
            summary.Add("总账面原值", 总账面原值.ToString("F2") + "元");
            summary.Add("总清查数量", 总清查数量.ToString("F2"));
            summary.Add("累计折旧", 累计折旧.ToString("F2") + "元");
            summary.Add("总账面净值", 总账面净值.ToString("F2") + "元");
            Grid1.SummaryData = summary;

        }

        private void OutputSummaryData1(DataTable source)
        {
            float 数量 = 0.0f;
            float 原值 = 0.0f;
            float 净值 = 0.0f;
            foreach (DataRow row in source.Rows)
            {
                数量 += Convert.ToInt32(row["数量"]);
                if (row["原值"]== DBNull.Value)
                {
                    原值 += 0;
                }
                else
                {
                    原值 += Convert.ToInt32(row["原值"]);
                }
                if (row["净值"] == DBNull.Value)
                {
                    净值 += 0;
                }
                else
                {
                    净值 += Convert.ToInt32(row["净值"]);
                }

                //净值 += Convert.ToInt32(row["净值"]);
            }
            JObject summary1 = new JObject();
            summary1.Add("资产编号", "合计");
            summary1.Add("数量", 数量.ToString("F2"));
            summary1.Add("原值", 原值.ToString("F2") + "元");
            summary1.Add("净值", 净值.ToString("F2") + "元");
            Grid2.SummaryData = summary1;
        }

        protected void Radios_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Grid1.Hidden = true;
            if (Radios.SelectedValue == "汇总表")
            {
                Grid1.Hidden = false;
                Grid2.Hidden = true;
                DropDownList1.Hidden = true;
                fr1.Hidden = true;
                fr2.Hidden = true;
                fr3.Hidden = true;
                fr4.Hidden = true;
                EndTime.Hidden = false;
            }
            else if (Radios.SelectedValue == "明细表")
            {
                Grid1.Hidden = true;
                Grid2.Hidden = false;
                DropDownList1.Hidden = false;
                fr1.Hidden = false;
                fr2.Hidden = false;
                fr3.Hidden = false;
                fr4.Hidden = false;
                EndTime.Hidden = true;
            }
        }

       

        

        protected void 部门_SelectedIndexChanged(object sender, EventArgs e)
        {
            负责人.Enabled = true;
            int ID = Convert.ToInt32(部门.SelectedValue);
            if (ID > 0)
            {
                School资产转移BLL zybll = new School资产转移BLL();
                List<用户表> listuser = zybll.listuser(ID);
                负责人.DataTextField = "姓名";
                负责人.DataValueField = "ID";
                负责人.DataSource = listuser;
                负责人.DataBind();
            }
            else
            {
                负责人.Enabled = false;
                School资产转移BLL zybll = new School资产转移BLL();
                List<用户表> listuser = zybll.listuser(ID);
                负责人.DataTextField = "姓名";
                负责人.DataValueField = "ID";
                负责人.DataSource = listuser;
                负责人.DataBind();
            }

        }

        protected void 存放地点_SelectedIndexChanged(object sender, EventArgs e)
        {

            int ID = Convert.ToInt32(存放地点.SelectedValue);
            if (ID > 0)
            {
                房间.Enabled = true;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School房间信息表> 查询房间信息 = pdbll.查询房间信息表(ID);
                房间.DataTextField = "名称";
                房间.DataValueField = "名称";
                房间.DataSource = 查询房间信息;
                房间.DataBind();
            }
            else
            {
                房间.Enabled = false;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School房间信息表> 查询房间信息 = pdbll.查询房间信息表(ID);
                房间.DataTextField = "名称";
                房间.DataValueField = "名称";
                房间.DataSource = 查询房间信息;
                房间.DataBind();
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            School条件查询表 model = new School条件查询表();
            string str一级 = 一级.SelectedText;
            string str二级 = 二级.SelectedText;
            string str三级 = 三级.SelectedText;
            if (str一级 == "全部" || str一级 == null)
            {
                str一级 = "";
            }
            if (str二级 == "全部" || str二级 == null)
            {
                str二级 = "";
            }
            if (str三级 == "全部" || str三级 == null)
            {
                str三级 = "";
            }
            model.一级分类 = str一级;
            model.二级分类 = str二级;
            model.三级分类 = str三级;
            string str部门 = 部门.SelectedText;
            if (str部门 != "全部" && str部门 != null)
            {
                model.归属部门 = Convert.ToInt32(部门.SelectedValue);
                if (负责人.SelectedText != null)
                {
                    model.负责人 = 负责人.SelectedValue;
                }
                else
                {
                    model.负责人 = "";
                }
            }
            else
            {
                model.归属部门 = 0;
            }

            if (存放地点.SelectedText != null && 存放地点.SelectedText != "全部")
            {
                model.存放地点 =存放地点.SelectedText;
                if (房间.SelectedText != null)
                {
                    model.房间 = 房间.SelectedValue;
                }
                else
                {
                    model.房间 = "";
                }
            }
            else
            {
                model.存放地点 = "";
            }

            //if (起始投入日期.Text != "")
            //{
            //    model.起始投入日期 = Convert.ToDateTime(起始投入日期.Text).ToShortDateString();
            //}
            //else
            //{
            //    model.起始投入日期 = "";
            //}
            if (EndTime.Text != "")
            {
                model.结束投入日期 = Convert.ToDateTime(EndTime.Text).ToShortDateString();
            }
            else
            {
                model.结束投入日期 = "";
            }


            model.关键字 = TwinTriggerBox1.Text;

            School结存分析BLL bll = new School结存分析BLL();
            //DataSet ds = bll.查询全部资产信息(model);
            DataSet ds = bll.结存分析条件查询(model);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;


            // 3.绑定到Grid
            Grid2.DataSource = dt;//DataTable
            Grid2.DataBind();

            //二级.Enabled = false;
            //三级.Enabled = false;
            //负责人.Enabled = false;
            //房间.Enabled = false;

            二级.EmptyText = "全部";
            三级.EmptyText = "全部";
            负责人.EmptyText = "全部";
            房间.EmptyText = "全部";

            OutputSummaryData1(dt);
        }

        protected void 一级_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(一级.SelectedValue);
            if (ID > 0)
            {
                三级.Enabled = false;
                二级.Enabled = true;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School二级类别表> listuser = pdbll.查询二级类别(ID);
                二级.DataTextField = "名称";
                二级.DataValueField = "名称";
                二级.DataSource = listuser;
                二级.DataBind();
                三级.DataBind();
            }
            else
            {
                二级.Enabled = false;
                三级.Enabled = false;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School二级类别表> listuser = pdbll.查询二级类别(ID);
                二级.DataTextField = "名称";
                二级.DataValueField = "名称";
                二级.DataSource = listuser; 
                三级.DataSource = listuser;
                二级.DataBind();
                三级.DataBind();
            }
        }

        protected void 二级_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(二级.SelectedValue);
            if (ID > 0)
            {
                三级.Enabled = true;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School三级类别表> listuser = pdbll.查询三级类别(ID);
                三级.DataTextField = "名称";
                三级.DataValueField = "名称";
                三级.DataSource = listuser;
                三级.DataBind();
            }
            else
            {
                三级.Enabled = false;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School三级类别表> listuser = pdbll.查询三级类别(ID);
                三级.DataTextField = "名称";
                三级.DataValueField = "名称";
                三级.DataSource = listuser;
                三级.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "0")
            {
                fr1.Hidden = false;
                fr2.Hidden = false;
                fr3.Hidden = false;
                fr4.Hidden = false;
            }
            else if (DropDownList1.SelectedValue == "1")
            {
                fr1.Hidden = false;
                fr2.Hidden = true;
                fr3.Hidden = true;
                fr4.Hidden = true;
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                fr1.Hidden = true;
                fr2.Hidden = false;
                fr3.Hidden = true;
                fr4.Hidden = true;
            }
            else if (DropDownList1.SelectedValue == "3")
            {
                fr1.Hidden = true;
                fr2.Hidden = true;
                fr3.Hidden = false;
                fr4.Hidden = true;
            }
        }



        protected void 账期_DateSelect(object sender, EventArgs e)
        {
            DataSet dsa = bll.资产汇总查询(EndTime.Text);
            DataTable dta = dsa.Tables[0].Copy();//复制一份table
            Grid1.DataSource = dta;//DataTable
            Grid1.DataBind();
            OutputSummaryData(dta);
        }

        protected void Grid2_RowDataBound(object sender, GridRowEventArgs e)
        {

            DataRowView row = e.DataItem as DataRowView;
            string entranceYear = row["类型"].ToString();
            BoundField bfEntranceYear = Grid2.FindColumn("btn类型") as BoundField;
            if (entranceYear == "房屋及构筑物")
            {
                e.RowAttributes["data-color"] = "color1";
            }
            else
            {
                e.RowAttributes["data-color"] = "color3";
            }

        }
    }
}