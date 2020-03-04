using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.School资产交接
{
    public partial class 资产交接 : System.Web.UI.Page
    {
        School资产借还交接BLL bll = new School资产借还交接BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OffSession();
                BindGrid();
                perbind();
                DateTime dtime = DateTime.Now;
                string sj = dtime.Year + "-" + dtime.Month + "-" + dtime.Day;
                提交时间.EmptyText = sj;
                完成时间.EmptyText = sj;
                
            }
        }

        protected void perbind()
        {
            DataSet ds = bll.per();
            DataTable dt = ds.Tables[0];
            负责人.DataTextField = "姓名";
            负责人.DataValueField = "ID";
            负责人.DataSource = dt;
            负责人.DataBind();
            接收人List.DataTextField = "姓名";
            接收人List.DataValueField = "ID";
            接收人List.DataSource = dt;
            接收人List.DataBind();
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

        protected void Button1_Click(object sender, EventArgs e)
        {

            流程状态.Text = "已交付";
            流程状态.Enabled = false;
            提交时间.Text = DateTime.Now.ToShortDateString();
            完成时间.Text = DateTime.Now.ToShortDateString();
            OffSession();
            交付人.Text = Session["姓名"].ToString();

            DateTime dt = DateTime.Now;
            string y = dt.Year.ToString();
            string m = dt.Month.ToString();
            string d = dt.Day.ToString();
            string h = dt.Hour.ToString();
            string mm = dt.Minute.ToString();
            单据编号.Text = "ZCJJ" + y + m + d + h + mm;
            单据编号.Enabled = false;
            交付人.Enabled = false;
            Window1.Hidden = false;
        }


        protected void 负责人_SelectedIndexChanged(object sender, EventArgs e)
        {
            School查询办公设备条件表 model = new School查询办公设备条件表();
            if (负责人.SelectedText != null)
            {
                model.负责人 = Convert.ToInt32(负责人.SelectedValue);
            }
            else
            {
                model.负责人 = 0;
                Alert.ShowInTop("必须选择负责人！");
                return;
            }


            model.关键字 = TwinTriggerBox1.Text;
            School资产处置BLL bll = new School资产处置BLL();
            DataSet ds = bll.查询全部资产信息(model);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;


            // 3.绑定到Grid
            Grid4.DataSource = dt;//DataTable
            Grid4.DataBind();
        }


        protected void Button5_Click(object sender, EventArgs e)
        {
            string sid = "";
            List<int> inlist = new List<int>();
            //获取grid3选中行数据
            int[] selections = Grid4.SelectedRowIndexArray;
            foreach (int rowIndex in selections)
            {
                int ID = Convert.ToInt32(Grid4.DataKeys[rowIndex][0]);
                sid += rowIndex.ToString() + ",";
                inlist.Add(ID);
            }
            if (inlist.Count == 0)
            {
                Alert.ShowInTop("请选中！", "提示信息", MessageBoxIcon.Warning);
                return;
            }
            School资产报修BLL bll = new School资产报修BLL();
            List<School办公设备信息表> listdata = bll.资产转移确定设备(inlist);

            接收人List.Text = 负责人.SelectedText;

            Grid2.DataSource = listdata;//DataTable
            Grid2.DataBind();
            Window2.Hidden = true;
        }

        protected void btnIcon1_Click(object sender, EventArgs e)
        {
            School清查盘点BLL pdbll = new School清查盘点BLL();
            List<School一级部门表> xxmc = pdbll.查询一级部门();

            Window2.Hidden = false;
        }

        private void BindGrid()
        {
            School资产借还交接BLL bll = new School资产借还交接BLL();
            DataSet ds = bll.查询资产交接("");
            DataTable dt = ds.Tables[0].Copy();//复制一份table

            Grid1.DataSource = dt;
            Grid1.DataBind();

        }

        public string sj(DateTime dt)
        {
            string y = dt.Year.ToString();
            string m = dt.Month.ToString();
            string d = dt.Day.ToString();
            string h = dt.Hour.ToString();
            string mm = dt.Minute.ToString();
            return y + "-" + m + "-" + d;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            AM_资产交接流程表 model = new AM_资产交接流程表();
            if (Grid2.Rows.Count == 0)
            {
                Alert.ShowInTop("请先添加资产！", "提示信息", MessageBoxIcon.Warning);
                return;
            }
            if (接收人List.SelectedText == ""|| 接收人List.SelectedText==null)
            {
                Alert.ShowInTop("请先添加接收人！", "提示信息", MessageBoxIcon.Warning);
                return;
            }
            model.Sort = 1;
            model.流程状态 = 流程状态.Text;
            model.接收人 = 接收人List.SelectedText;
            model.备注信息 = 备注信息.Text;
            OffSession();
            model.交付人 = Session["姓名"].ToString();
            model.发起人 = Session["姓名"].ToString();
            model.单据编号 = 单据编号.Text;
            DateTime dt = Convert.ToDateTime(提交时间.SelectedDate);
            string sd = 提交时间.Text;
            
            model.提交时间 = 提交时间.Text;
            DateTime dd = Convert.ToDateTime(完成时间.SelectedDate);
            model.完成时间 = 完成时间.Text;
            model.接收人 = 接收人List.SelectedText;

            int[] selections = Grid4.SelectedRowIndexArray;
            int i = 0;
            foreach (int rowIndex in selections)
            {
                int ID = Convert.ToInt32(Grid4.DataKeys[rowIndex][0]);
                string xxx = Grid4.DataKeys[rowIndex][0].ToString();
                model.资产ID += ID.ToString() + ",";
                i++;
            }
            model.资产数量 = i.ToString(); ;
            School资产借还交接BLL bll = new School资产借还交接BLL();

            AM_提醒通知 ammodel = new AM_提醒通知();

            ammodel.发起时间 = DateTime.Now;
            ammodel.是否已读 = "否";
            ammodel.通知类型 = "待办事项通知";
            ammodel.通知职务 = "财务人员";
            ammodel.发起人 = Session["姓名"].ToString();
            ammodel.消息内容 = "您来自" + ammodel.发起人 + "的资产交接申请,请及时处理！";
            ammodel.消息事项 = "资产交接";
            ammodel.是否已读 = "否";
            AM_待办业务 dbmodel = new AM_待办业务();
            dbmodel.处理方式 = "个人";
            dbmodel.处理人 = model.接收人;
            dbmodel.流程状态 = 流程状态.Text;
            dbmodel.事项名称 = "资产交接";
            dbmodel.FlowName = "资产交接";
            dbmodel.发起人 = Session["姓名"].ToString();
            dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产交接申请,请及时处理！";
            dbmodel.发起时间 = DateTime.Now.ToLongDateString();
            dbmodel.Sort = 1;
            if (bll.创建资产交接(model, ammodel, dbmodel) > 0)
            {
                Window1.Hidden = true;
                Alert.ShowInTop("创建成功！");
            }
            BindGrid();

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
                    btnok.Hidden = false;
                    btnok.Text = "确认接收";
                    btnon.Text = "关闭";
                }
                else if (Sort == 2 && 查职务 == "资产管理员")
                {
                    btnok.Hidden = false;
                    btnok.Text = "确认通过";
                    btnon.Text = "关闭";
                }
                else
                {
                    btnok.Hidden = true;
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
        //流程进度
        protected string GetEditUrls(object id, object sort)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("事项名称", "事项名称" + id);
            joBuilder.AddProperty("title", "流程进度 - " + id);
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("School资产交接流程进度.aspx?SBBH={0}&sort={1}", id, HttpUtility.UrlEncode(sort.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }


        protected void btnok_Click(object sender, EventArgs e)
        {
            if (btnok.Text == "确认接收")
            {
                string processingtime = DateTime.Now.ToShortDateString();//处理时间
                string username = Session["姓名"].ToString();//处理人
                int flowid = Convert.ToInt32(FlowID.Text);
                string zcid = 资产ID.Text;
                AM_资产交接流程表 model = new AM_资产交接流程表();
                model.ID = flowid;
                model.资产ID = zcid;
                model.Sort = 1;
                model.是否接收 = "是";
                model.接收人 = username;
                model.流程状态 = "已接收,待确认";
                model.接收人接收时间= DateTime.Now.ToLongDateString(); 

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "管理员";
                ammodel.消息内容 = "已接收，待管理员确认！";
                ammodel.消息事项 = "资产交接";
                ammodel.发起人 = username;//处理人
                ammodel.FlowID = flowid;

                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.处理方式 = "职务";
                dbmodel.处理职务 = "资产管理员";
                dbmodel.发起人 = username;
                dbmodel.FlowID = flowid;
                dbmodel.流程状态 = "已接收,待确认";             
                dbmodel.通知内容 = username + "的资产交接已接收,请及时处理！";
                dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                dbmodel.Sort = 2;

                School资产借还交接BLL bll = new School资产借还交接BLL();

                if (bll.操作资产交接流程(model, ammodel, dbmodel) > 0)
                {
                    Alert alert = new Alert();
                    alert.Message = "处理成功";
                    alert.Title = "提示信息";
                    alert.MessageBoxIcon = MessageBoxIcon.Success;
                    alert.Show();
                    Window3.Hidden = true;
                    BindGrid();
                    return;
                }
                else
                {
                    Alert alert = new Alert();
                    alert.Message = "处理失败";
                    alert.Title = "提示信息";
                    alert.MessageBoxIcon = MessageBoxIcon.Error;
                    alert.Show();
                    return;
                }

            }
            else if (btnok.Text == "确认通过")
            {
                string processingtime = DateTime.Now.ToShortDateString();//处理时间
                string username = Session["姓名"].ToString();//处理人
                int flowid = Convert.ToInt32(FlowID.Text);
                AM_资产交接流程表 model = new AM_资产交接流程表();
                model.ID = flowid;
                model.管理员是否通过 = "是";
                model.管理员通过时间 = processingtime;
                model.Sort = 2;
                model.管理员 = username;
                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "交付人";
                ammodel.消息内容 = "您的资产交接流程已全部完成";
                ammodel.消息事项 = "资产交接";
                ammodel.发起人 = username;//处理人
                ammodel.FlowID = flowid;


                AM_待办业务 dbmodel = new AM_待办业务();
                School资产借还交接BLL bll = new School资产借还交接BLL();
                dbmodel.处理人 = bll.查询接收人(flowid);
                dbmodel.处理职务 = "个人";
                dbmodel.发起人 = username;
                dbmodel.流程状态 = "已完成";
                dbmodel.事项名称 = "资产交接";
                dbmodel.通知内容 = "您的资产交接流程已全部完成";
                dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                dbmodel.Sort = 0;
                dbmodel.FlowID = flowid;

                

                if (bll.操作资产交接流程(model, ammodel, dbmodel) > 0)
                {
                    Alert alert = new Alert();
                    alert.Message = "处理成功";
                    alert.Title = "提示信息";
                    alert.MessageBoxIcon = MessageBoxIcon.Success;
                    alert.Show();
                    Window3.Hidden = true;
                    BindGrid();
                    return;
                }
                else
                {
                    Alert alert = new Alert();
                    alert.Message = "处理失败";
                    alert.Title = "提示信息";
                    alert.MessageBoxIcon = MessageBoxIcon.Error;
                    alert.Show();
                    return;
                }

            }
            
        }

        protected void TwinTriggerBox1_TextChanged(object sender, EventArgs e)
        {
            School查询办公设备条件表 model = new School查询办公设备条件表();
            if (负责人.SelectedText != null)
            {
                model.负责人 = Convert.ToInt32(负责人.SelectedValue);
            }
            else
            {
                model.负责人 = 0;
                Alert.ShowInTop("必须选择负责人！");
                return;
            }


            model.关键字 = TwinTriggerBox1.Text;
            School资产处置BLL bll = new School资产处置BLL();
            DataSet ds = bll.查询全部资产信息(model);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;


            // 3.绑定到Grid
            Grid4.DataSource = dt;//DataTable
            Grid4.DataBind();
        }


    }
}