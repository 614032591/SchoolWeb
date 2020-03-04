using PLM.BusinessRlues;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.统计查询
{
    public partial class 资产维修统计查询 : PageBase
    {
        School资产报修BLL bll = new School资产报修BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadioButton.SelectedValue = "报修大厅";
                DataSet ds = bll.首页_X_资产报修流程表("全部", "报修大厅");

                DataTable dt = ds.Tables[0].Copy();//复制一份table
                DataTable source = dt;

                // 3.绑定到Grid
                Grid1.DataSource = dt;//DataTable
                Grid1.DataBind();
            }
        }
        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string str = DropDownList1.SelectedText;
            string state = "";
            if (RadioButton.SelectedValue == "报修大厅")
            {
                state = "";
            }
            else
            {
                state = HttpContext.Current.Session["f_user_name"].ToString();
            }
            DataSet ds = bll.首页_X_资产报修流程表(str, state);
            //ds = bll.首页_X_资产报修流程表(str, RadioButton.SelectedValue);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;

            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }
        //protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
        //{
        //  string str = DropDownList1.SelectedText;
        //string state = "";
        //if (RadioButton.SelectedValue == "保修大厅")
        //{
        //    state = "";
        //}
        //else
        //{
        //    state = HttpContext.Current.Session["f_user_name"].ToString();
        //}  
        //    string sSearch = ttSearch.Text.ToString();
        //    DataSet ds = zcztbll.DataSet资产状态查询(sSearch, DropDownList1.SelectedText);
        //    DataTable dt = ds.Tables[0].Copy();//复制一份table
        //    Grid1.DataSource = dt;//DataTable
        //    Grid1.DataBind();
        //}

        protected void RadioButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            string state = RadioButton.SelectedValue;

            if (RadioButton.SelectedValue == "报修大厅")
            {
                RadioButton.SelectedValue = "报修大厅";
                state = "报修大厅";
                DataSet ds = bll.首页_X_资产报修流程表(DropDownList1.SelectedText, state);
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                // 3.绑定到Grid
                Grid1.DataSource = dt;//DataTable
                Grid1.DataBind();

            }
            else if (RadioButton.SelectedValue == "我的报修")
            {
                RadioButton.SelectedValue = "我的报修";
                state = HttpContext.Current.Session["姓名"].ToString();
                DataSet ds = bll.首页_X_资产报修流程表(DropDownList1.SelectedText, state);
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                // 3.绑定到Grid
                Grid1.DataSource = dt;//DataTable
                Grid1.DataBind();
            }


            //DataTable dt = ds.Tables[0].Copy();//复制一份table


            //// 3.绑定到Grid
            //Grid1.DataSource = dt;//DataTable
            //Grid1.DataBind();
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                流程状态待派单.Hidden = false;
                object[] keys = Grid1.DataKeys[e.RowIndex];
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                xx.Text = ID.ToString();
                查看报修人.Text = keys[3].ToString();
                查看报修时间.Text = keys[4].ToString();
                查看单号.Text = keys[2].ToString();
                查看报修地址.Text = keys[5].ToString();
                查看故障描述.Text = keys[6].ToString();
                if (keys[10] == null)
                {
                    Image2.ImageUrl = "/res/images/zwzp.png";
                }
                else
                {
                    Image2.ImageUrl = keys[10].ToString();

                }

                DataSet ds = bll.资产报修查看详情(ID);
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                Grid3.DataSource = dt;//DataTable
                Grid3.DataBind();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            流程状态待派单.Hidden = true;
        }

        protected string GetEditUrls(object id, object sort)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("事项名称", "事项名称" + id);
            joBuilder.AddProperty("title", "流程进度 - " + id);
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("/School资产报修/School资产报修流程进度.aspx?SBBH={0}&sort={1}", id, HttpUtility.UrlEncode(sort.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }
    }
}