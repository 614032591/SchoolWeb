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
    public partial class 价格变动统计查询 : PageBase
    {
        School原值变动BLL bll = new School原值变动BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                DataSet ds = bll.首页_X_价格变动流程表("", "流程状态-全部");
                DataTable dt = ds.Tables[0].Copy();//复制一份table

                Grid1.DataSource = dt;
                Grid1.DataBind();
                OffSession();
            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string flowstate = DropDownList1.SelectedText;
            DataSet ds = bll.首页_X_价格变动流程表(tSearch.Text, flowstate);
            DataTable dt = ds.Tables[0].Copy();//复制一份table

            Grid1.DataSource = dt;
            Grid1.DataBind();
        }

        protected void tSearch_Trigger2Click(object sender, EventArgs e)
        {
            string sSearch = tSearch.Text.ToString();
            DataSet ds = bll.首页_X_价格变动流程表(sSearch, DropDownList1.SelectedText);
            DataTable dt = ds.Tables[0].Copy();//复制一份table

            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }


        protected void Button6_Click(object sender, EventArgs e)
        {
            Window3.Hidden = true;

        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                OffSession();
                string 职务 = Session["职务"].ToString();
                if (职务 == "财务人员")
                {
                    //Button4.Text = "同意";
                    Button6.Text = "拒绝";
                }
                else
                {
                    //Button4.Enabled = false;
                    Button6.Text = "关闭";
                }

                object[] keys = Grid1.DataKeys[e.RowIndex];
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                flowid.Text = ID.ToString();
                查看流程状态.Text = keys[1].ToString();
                if (查看流程状态.Text == "完成")
                {
                    //Button4.Enabled = false;
                    Button6.Text = "关闭";
                }
                查看单据编号.Text = keys[2].ToString();
                查看事项名称.Text = keys[3].ToString();
                查看申请人.Text = keys[4].ToString();
                查看申请日期.Text = keys[5].ToString();
                查看记账人.Text = keys[6].ToString();
                //赋值lable
                this.Label5.Text = "数量合计:" + keys[7].ToString() + "---金额合计：" + keys[8].ToString() + "元";
                查看变动方式.Text = keys[9].ToString();
                查看变动原因.Text = keys[10].ToString();
                查看记账人意见.Text = keys[11].ToString();
                查看备注.Text = keys[12].ToString();
                string 资产ID = keys[13].ToString();
                string str变动金额 = keys[14].ToString();
                if (keys[15] == null)
                {
                    int Sort = 0;
                }
                else
                {
                    int Sort = Convert.ToInt32(keys[15].ToString());
                }


                //通过ID查询资产数据
                Grid4.DataSource = bll.原值变动查看详情(资产ID);
                Grid4.DataBind();

                Window3.Hidden = false;

            }
        }


        protected string GetEditUrls(object id, object sort)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("事项名称", "事项名称" + id);
            joBuilder.AddProperty("title", "流程进度 - " + id);
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("/School原值变动/School原值变动流程进度.aspx?SBBH={0}&sort={1}", id, HttpUtility.UrlEncode(sort.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }
        private void OffSession()
        {
            try
            {
                if (Session["用户名"].ToString() == null)
                {
                    Response.Write("<script>alert('Session已失效，请点击系统名称返回登录页面')</script>");
                    Response.End();
                }
                else
                {
                    //不等于null
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Session已失效，请点击系统名称返回登录页面')</script>");
                Response.End();
            }
        }
    }
}