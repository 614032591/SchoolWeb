using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FineUIPro.EmptyProjectNet40.统计查询
{
    public partial class 资产转移统计查询 : PageBase
    {
        School资产处置BLL bl2 = new School资产处置BLL();
        School资产转移BLL bll = new School资产转移BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                Grid2.Hidden = true;
                //Grid3.Hidden = true;
                DataSet ds = bll.首页_X_资产转移流程表("流程状态-全部");
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                DataTable source = dt;

                // 3.绑定到Grid
                Grid1.DataSource = dt;//DataTable
                Grid1.DataBind();
                二级.Enabled = false;
                三级.Enabled = false;
                负责人.Enabled = false;
                房间.Enabled = false;

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
            }

        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                xx.Text = ID.ToString();
                查看流程状态.Text = keys[1].ToString();
                if (查看流程状态.Text != "待审核")
                {
                    Button9.Enabled = false;
                    Button3.Enabled = false;
                }
                查看单据编号.Text = keys[2].ToString();
                查看事项名称.Text = keys[3].ToString();
                查看申请人.Text = keys[4].ToString();
                查看申请日期.Text = keys[5].ToString();
                查看联系方式.Text = keys[6].ToString();

                DataSet ds = bll.资产转移查看详情(ID);
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                Grid4.DataSource = dt;//DataTable
                Grid4.DataBind();
                //查询现负责人等
                SchoolX_资产转移改动信息表 model = bll.查询变更为(ID);
                查看存放地点变更为.Text = model.现存放地点;
                查看归属部门变更为.Text = model.现归属部门;
                查看负责人变更为.Text = model.现负责人;

                新增资产转移查看详情.Hidden = false;

            }
        }

        //事项表/明细表切换
        protected void Radios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Radios.SelectedValue == "事项表")
            {
                frHidden.Hidden = false;
                Grid1.Hidden = false;
                Grid2.Hidden = true;
                //Grid3.Hidden = true;
                fr1.Hidden = true;
                fr2.Hidden = true;
                fr3.Hidden = true;
                fr4.Hidden = true;
            }
            else if (Radios.SelectedValue == "明细表")
            {
                frHidden.Hidden = true;
                Grid1.Hidden = true;
                Grid2.Hidden = false;
                //Grid3.Hidden = true;
                fr1.Hidden = false;
                fr2.Hidden = false;
                fr3.Hidden = false;
                fr4.Hidden = false;
                //绑定数据

                DataSet ds = bll.资产转移查询明细();

                DataTable dt = ds.Tables[0].Copy();//复制一份table
                DataTable source = dt;

                // 3.绑定到Grid
                Grid2.DataSource = dt;//DataTable
                Grid2.DataBind();
            }
        }

        //流程状态
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string flowstate = DropDownList1.SelectedText;
            DataSet ds = bll.首页_X_资产转移流程表(flowstate);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;

            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }

       
        //二级菜单
        protected void 一级_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(一级.SelectedValue);
            if (ID > 0)
            {
                二级.Enabled = true;
                三级.Enabled = false;
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
            房间.Enabled = true;
            int ID = Convert.ToInt32(存放地点.SelectedValue);
            if (ID > 0)
            {
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
        //protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        //{
        //    BindGrid();
        //}

        //private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        //{

        //    DataSet ds = bl2.查询全部资产信息();
        //    DataTable dt = ds.Tables[0].Copy();//复制一份table
        //    DataTable source = dt;
        //    DataTable paged = source.Clone();

        //    int rowbegin = pageIndex * pageSize;
        //    int rowend = (pageIndex + 1) * pageSize;
        //    if (rowend > source.Rows.Count)
        //    {
        //        rowend = source.Rows.Count;
        //    }

        //    for (int i = rowbegin; i < rowend; i++)
        //    {
        //        paged.ImportRow(source.Rows[i]);
        //    }

        //    return paged;
        //}
        //private void BindGrid()
        //{
        //    DataSet ds = bl2.查询全部资产信息();
        //    DataTable dt = ds.Tables[0].Copy();//复制一份table
        //    DataTable source = dt;

        //    // 3.绑定到Grid
        //    Grid3.DataSource = dt;//DataTable
        //    Grid3.DataBind();
        //}

        protected void Button5_Click(object sender, EventArgs e)
        {
            Grid1.Hidden = true;
            Grid2.Hidden = false;
            School查询办公设备条件表 model = new School查询办公设备条件表();
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

            if (起始投入日期.Text != "")
            {
                model.起始投入日期 = Convert.ToDateTime(起始投入日期.Text).ToShortDateString();
            }
            else
            {
                model.起始投入日期 = "";
            }
            if (结束投入日期.Text != "")
            {
                model.结束投入日期 = Convert.ToDateTime(结束投入日期.Text).ToShortDateString();
            }
            else
            {
                model.结束投入日期 = "";
            }


            model.关键字 = TwinTriggerBox1.Text;

            School资产转移BLL bll = new School资产转移BLL();

            DataSet ds = bll.资产转移查询明细_X(model);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;

            // 3.绑定到Grid
            Grid2.DataSource = dt;//DataTable
            Grid2.DataBind();
          
            二级.EmptyText = "全部";
            三级.EmptyText = "全部";
            负责人.EmptyText = "全部";
            房间.EmptyText = "全部";
        }

        protected string GetEditUrls(object id, object sort)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("事项名称", "事项名称" + id);
            joBuilder.AddProperty("title", "流程进度 - " + id);
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("/School资产转移/School资产转移流程进度.aspx?SBBH={0}&sort={1}", id, HttpUtility.UrlEncode(sort.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }

        //protected void CheckBox2_CheckedChanged(object sender, CheckedEventArgs e)
        //{
        //    if (CheckBox2.Checked == true)
        //    {
        //        frHidden.Hidden = false;
        //        Grid1.Hidden = false;
        //        Grid2.Hidden = true;
        //        Grid3.Hidden = true;
        //        fr1.Hidden = true;
        //        fr2.Hidden = true;
        //        fr3.Hidden = true;
        //    }
        //    else
        //    {
        //        frHidden.Hidden = true;
        //        Grid1.Hidden = true;
        //        Grid2.Hidden = false;
        //        Grid3.Hidden = true;
        //        fr1.Hidden = false;
        //        fr2.Hidden = false;
        //        fr3.Hidden = false;
        //        //绑定数据

        //        DataSet ds = bll.资产转移查询明细();

        //        DataTable dt = ds.Tables[0].Copy();//复制一份table
        //        DataTable source = dt;

        //        // 3.绑定到Grid
        //        Grid2.DataSource = dt;//DataTable
        //        Grid2.DataBind();
        //    }
        //}


    }
}