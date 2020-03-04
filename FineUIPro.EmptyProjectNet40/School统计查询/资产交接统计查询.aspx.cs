using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.School统计查询
{
    public partial class 资产交接统计查询 : System.Web.UI.Page
    {
        School资产借还交接BLL bll = new School资产借还交接BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OffSession();
                BindGrid();
                perbind();
            }
        }
        protected void perbind()
        {
            DataSet ds = bll.per();
            DataTable dt = ds.Tables[0];
            //负责人.DataTextField = "姓名";
            //负责人.DataValueField = "ID";
            //负责人.DataSource = dt;
            //负责人.DataBind();
            接收人List.DataTextField = "姓名";
            接收人List.DataValueField = "ID";
            接收人List.DataSource = dt;
            接收人List.DataBind();
        }

        private void BindGrid()
        {
            School资产借还交接BLL bll = new School资产借还交接BLL();
            DataSet ds = bll.查询资产交接("");
            DataTable dt = ds.Tables[0].Copy();//复制一份table

            Grid1.DataSource = dt;
            Grid1.DataBind();

        }

        private void OffSession()
        {
            try
            {
                if (Session["用户名"].ToString() == null)
                {
                    Alert.ShowInTop("Session已失效,跳转登录页面！");
                    System.Diagnostics.Process.Start("http://localhost:2850/LoginTest.aspx");
                    return;
                }
                else
                {
                    //不等于null
                }
            }
            catch (Exception)
            {
                Alert.ShowInTop("Session已失效,跳转登录页面！");
                System.Diagnostics.Process.Start("http://localhost:2850/LoginTest.aspx");
                return;
            }
        }

        protected string GetEditUrls(object id, object sort)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("事项名称", "事项名称" + id);
            joBuilder.AddProperty("title", "流程进度 - " + id);
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("/School资产交接/School资产交接流程进度.aspx?SBBH={0}&sort={1}", id, HttpUtility.UrlEncode(sort.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                OffSession();
                School资产借还交接BLL bll = new School资产借还交接BLL();
                string username = Session["姓名"].ToString();
                //ID,流程状态,单据编号,借用人,接收人,提交时间,借用时间,预计归还时间,备注信息,Sort,资产ID
                object[] keys = Grid1.DataKeys[e.RowIndex];
                int Sort = Convert.ToInt32(keys[8].ToString());
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                FlowID.Text = ID.ToString();
                查看流程状态.Text = keys[1].ToString();
                //if (查看流程状态.Text == "完成")
                //{
                //    btnok.Enabled = false;
                //    btnon.Text = "关闭";
                //}
                string 查职务 = Session["职务"].ToString();
                查看单据编号.Text = keys[2].ToString();
                查看交付人.Text = keys[3].ToString();
                查看接收人.Text = keys[4].ToString();
                if (Sort == 1 && 查看接收人.Text == username)
                {
                    //btnok.Hidden = false;
                    //btnok.Text = "确认接收";
                    btnon.Text = "关闭";
                }
                else if (Sort == 2 && 查职务 == "资产管理员")
                {
                    //btnok.Hidden = false;
                    //btnok.Text = "确认通过";
                    btnon.Text = "关闭";
                }
                else
                {
                    //btnok.Hidden = true;
                    btnon.Text = "关闭";
                }
                查看提交时间.Text = keys[5].ToString();
                查看完成时间.Text = keys[6].ToString();
                查看备注信息.Text = keys[7].ToString();

                string zcid = keys[9].ToString();
                资产ID.Text = zcid;

                Grid3.DataSource = bll.资产借还查看详情(zcid);
                Grid3.DataBind();

                Window3.Hidden = false;
            }
        }


        protected void btnIcon1_Click(object sender, EventArgs e)
        {
            School清查盘点BLL pdbll = new School清查盘点BLL();
            List<School一级部门表> xxmc = pdbll.查询一级部门();

            //Window2.Hidden = false;
        }

        protected void btnon_Click(object sender, EventArgs e)
        {
            Window3.Hidden = true;
        }
    }
}