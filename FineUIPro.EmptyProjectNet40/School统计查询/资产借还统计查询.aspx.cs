using PLM.BusinessRlues;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.School统计查询
{
    public partial class 资产借还统计查询 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OffSession();
                BindGrid();
            }
        }

        private void BindGrid()
        {
            School资产借还交接BLL bll = new School资产借还交接BLL();
            DataSet ds = bll.查询资产借还("");
            DataTable dt = ds.Tables[0].Copy();//复制一份table

            Grid1.DataSource = dt;
            Grid1.DataBind();

        }

        protected void ttSearch_Trigger2Click(object sender, EventArgs e)
        {
            School资产借还交接BLL bll = new School资产借还交接BLL();
            DataSet ds = bll.查询资产借还(DropDownList1.Text, ttSearch.Text);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid1.DataSource = dt;
            Grid1.DataBind();
        }

        protected string GetEditUrls(object id, object sort)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("事项名称", "事项名称" + id);
            joBuilder.AddProperty("title", "流程进度 - " + id);
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("/School资产借还借用/School资产借还流程进度.aspx?SBBH={0}&sort={1}", id, HttpUtility.UrlEncode(sort.ToString()))));
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
                string username = Session["姓名"].ToString();
                //ID,流程状态,单据编号,借用人,借出人,提交时间,借用时间,预计归还时间,备注信息,Sort,资产ID
                object[] keys = Grid1.DataKeys[e.RowIndex];
                int Sort = Convert.ToInt32(keys[9].ToString());
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                FlowID.Text = ID.ToString();
                查看流程状态.Text = keys[1].ToString();
                //if (查看流程状态.Text == "完成")
                //{
                //    btnok.Enabled = false;
                //    btnon.Text = "关闭";
                //}
                查看单据编号.Text = keys[2].ToString();
                查看借用人.Text = keys[3].ToString();
                查看借出人.Text = keys[4].ToString();
                //if (username == 查看借出人.Text && Sort == 1)
                //{
                //    btnok.Text = "同意借出";
                //    btnon.Text = "拒绝借出";
                //}
                //else if (Sort == 2 && 查看借用人.Text == username)
                //{
                //    btnok.Text = "确认归还";
                //    btnon.Text = "关闭";
                //}
                //else if (Sort == 3 && 查看借出人.Text == username)
                //{
                //    btnok.Text = "已归还";
                //    btnon.Text = "未归还";
                //}
                //else
                //{
                //    btnok.Text = "";
                //    btnon.Text = "关闭";
                //}
                查看提交时间.Text = keys[5].ToString();
                查看借用时间.Text = keys[6].ToString();
                查看预计归还时间.Text = keys[7].ToString();
                查看备注信息.Text = keys[8].ToString();

                string zcid = keys[10].ToString();
                资产ID.Text = zcid;

                if (keys[11]==null)
                {
                    是否同意.Text = "";
                }
                else
                {
                    是否同意.Text = keys[11].ToString();
                }
                if (keys[12] == null)
                {
                    借出人操作时间.Text = "";
                }
                else
                {
                    借出人操作时间.Text = keys[12].ToString();
                }
                if (keys[13] == null)
                {
                    操作人.Text = "";
                }
                else
                {
                    操作人.Text = keys[13].ToString();
                }

                if (keys[14] == null)
                {
                    申请人是否归还.Text = "";
                }
                else
                {
                    申请人是否归还.Text = keys[14].ToString();
                }
                if (keys[15] == null)
                {
                    申请人归还时间.Text = "";
                }
                else
                {
                    申请人归还时间.Text = keys[15].ToString();
                }
                if (keys[16] == null)
                {
                    出借人确认归还.Text = "";
                }
                else
                {
                    出借人确认归还.Text = keys[16].ToString();
                }
                if (keys[17] == null)
                {
                    出借人确认时间.Text = "";
                }
                else
                {
                    出借人确认时间.Text = keys[17].ToString();
                }
                //借出人操作时间.Text = keys[12].ToString();
                //操作人.Text = keys[13].ToString();
                //申请人是否归还.Text = keys[14].ToString();
                //申请人归还时间.Text = keys[15].ToString();
                //出借人确认归还.Text = keys[16].ToString();
                //出借人确认时间.Text = keys[17].ToString();

        School资产借还交接BLL bll = new School资产借还交接BLL();
                Grid3.DataSource = bll.资产借还查看详情(zcid);
                Grid3.DataBind();

                Window3.Hidden = false;
            }
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            School资产借还交接BLL bll = new School资产借还交接BLL();
            DataSet ds = bll.查询资产借还(DropDownList1.SelectedText, ttSearch.Text);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid1.DataSource = dt;
            Grid1.DataBind();
        }
    }
}