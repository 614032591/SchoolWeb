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
    public partial class 增减分析 : System.Web.UI.Page
    {
        School折旧分析BLL bll = new School折旧分析BLL();
        School增减分析BLL zjfxbll = new School增减分析BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                二级.Enabled = false;
                三级.Enabled = false;
                负责人.Enabled = false;
                房间.Enabled = false;
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


                //DataSet dsa = bll.资产汇总查询();

                //DataTable dta = dsa.Tables[0].Copy();//复制一份table
                //DataTable sourcea = dta;
                //// 3.绑定到Grid
                //Grid1.DataSource = dta;//DataTable
                //Grid1.DataBind();


                DataSet dss = zjfxbll.一级类别();
                DataTable dts = dss.Tables[0].Copy();//复制一份table
                DataTable sourcea = dts;
                Grid1.DataSource = dts;
                Grid1.DataBind();


                DataSet ds = bll.资产明细查询();
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                DataTable source = dt;
                // 3.绑定到Grid
                //Grid2.DataSource = dt;//DataTable
                //Grid2.DataBind();
            }
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
                二级.DataValueField = "ID";
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
                二级.DataValueField = "ID";
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
                三级.DataValueField = "ID";
                三级.DataSource = listuser;
                三级.DataBind();
            }
            else
            {
                三级.Enabled = false;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School三级类别表> listuser = pdbll.查询三级类别(ID);
                三级.DataTextField = "名称";
                三级.DataValueField = "ID";
                三级.DataSource = listuser;
                三级.DataBind();
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
                房间.DataValueField = "ID";
                房间.DataSource = 查询房间信息;
                房间.DataBind();
            }
            else
            {
                房间.Enabled = false;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School房间信息表> 查询房间信息 = pdbll.查询房间信息表(ID);
                房间.DataTextField = "名称";
                房间.DataValueField = "ID";
                房间.DataSource = 查询房间信息;
                房间.DataBind();
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            School查询办公设备条件表 model = new School查询办公设备条件表();
            string str一级 = 一级.SelectedText;
            string str二级 = 二级.SelectedText;
            string str三级 = 三级.SelectedText;
            if (str一级 == "全部" || str一级 == null)
            {
                str一级 = "";
                str二级 = "";
                str三级 = "";
                if (str二级 == "全部" || str二级 == null)
                {
                    str二级 = "";
                    str三级 = "";
                }
                if (str三级 == "全部" || str三级 == null)
                {
                    str三级 = "";
                }
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
                    model.负责人 = Convert.ToInt32(负责人.SelectedValue);
                }
                else
                {
                    model.负责人 = 0;
                }
            }
            else
            {
                model.归属部门 = 0;
            }

            if (存放地点.SelectedText != null)
            {
                model.存放地点 = Convert.ToInt32(存放地点.SelectedValue);
                if (房间.SelectedText != null)
                {
                    model.房间 = Convert.ToInt32(房间.SelectedValue);
                }
                else
                {
                    model.房间 = 0;
                }
            }
            else
            {
                model.存放地点 = 0;
            }

            if (开始日期.Text != "")
            {
                model.起始投入日期 = Convert.ToDateTime(开始日期.Text).ToShortDateString();
            }
            else
            {
                model.起始投入日期 = "";
            }
            if (截止日期.Text != "")
            {
                model.结束投入日期 = Convert.ToDateTime(截止日期.Text).ToShortDateString();
            }
            else
            {
                model.结束投入日期 = "";
            }


            //model.关键字 = TwinTriggerBox1.Text;

            School资产处置BLL bll = new School资产处置BLL();
            DataSet ds = bll.查询全部资产信息(model);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;


            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();

            //二级.Enabled = false;
            //三级.Enabled = false;
            //负责人.Enabled = false;
            //房间.Enabled = false;

            二级.EmptyText = "全部";
            三级.EmptyText = "全部";
            负责人.EmptyText = "全部";
            房间.EmptyText = "全部";
        }
    }
}