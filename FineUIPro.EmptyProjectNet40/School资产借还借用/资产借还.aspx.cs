using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.School资产借还借用
{
    public partial class 资产借还 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                OffSession();
                BindGrid();
            }
        }
        protected void 部门_SelectedIndexChanged(object sender, EventArgs e)
        {
            School资产报修BLL bll = new School资产报修BLL();
            负责人.Enabled = true;
            int ID = Convert.ToInt32(部门.SelectedValue);
            if (ID > 0)
            {
                List<用户表> listuser = bll.listuser(ID);
                负责人.DataTextField = "姓名";
                负责人.DataValueField = "ID";
                负责人.DataSource = listuser;
                负责人.DataBind();
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

        protected void Button1_Click(object sender, EventArgs e)
        {

            流程状态.Text = "已提交";
            流程状态.Enabled = false;
            提交时间.Text = DateTime.Now.ToShortDateString();
            借用时间.Text = DateTime.Now.ToShortDateString();
            借用人.Text = Session["姓名"].ToString();
            借出人.Enabled = false;
            DateTime dt = DateTime.Now;
            string y = dt.Year.ToString();
            string m = dt.Month.ToString();
            string d = dt.Day.ToString();
            string h = dt.Hour.ToString();
            string mm = dt.Minute.ToString();
            单据编号.Text = "ZCJH" + y + m + d + h + mm;
            单据编号.Enabled = false;
            借用人.Enabled = false;
            Window1.Hidden = false;
        }

        

        protected void Button4_Click(object sender, EventArgs e)
        {
            School查询办公设备条件表 model = new School查询办公设备条件表();
            string str部门 = 部门.SelectedText;
            if (str部门 != null)
            {
                model.归属部门 = Convert.ToInt32(部门.SelectedValue);
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
            }
            else 
            {
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

            借出人.Text = 负责人.SelectedText;
          
            Grid2.DataSource = listdata;//DataTable
            Grid2.DataBind();
            Window2.Hidden = true;
        }

        protected void btnIcon1_Click(object sender, EventArgs e)
        {
            School清查盘点BLL pdbll = new School清查盘点BLL();
            List<School一级部门表> xxmc = pdbll.查询一级部门();
            部门.DataTextField = "名称";
            部门.DataValueField = "ID";
            部门.DataSource = xxmc;
            部门.DataBind();
            Window2.Hidden = false;
        }

        private void BindGrid()
        {
            School资产借还交接BLL bll = new School资产借还交接BLL();
            DataSet ds = bll.查询资产借还("");
            DataTable dt = ds.Tables[0].Copy();//复制一份table

            Grid1.DataSource = dt;
            Grid1.DataBind();

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            AM_资产借还流程表 model = new AM_资产借还流程表();
            if (Grid2.Rows.Count == 0)
            {
                Alert.ShowInTop("请先添加资产！", "提示信息", MessageBoxIcon.Warning);
                return;
            }
            model.Sort = 1;
            model.流程状态 = 流程状态.Text;
            model.发起人 = 借用人.Text;
            model.借出人 = 借出人.Text;
            model.借用人 = 借用人.Text;
            model.提交时间 = 提交时间.Text;
            if (预计归还时间.Text == null || 预计归还时间.Text=="")
            {
                Alert.ShowInTop("请输入归还时间！", "提示信息", MessageBoxIcon.Warning);
                return;
            }
            model.预计归还时间 = 预计归还时间.Text;
            model.单据编号 = 单据编号.Text;
            model.借出人 = 借出人.Text;
            model.借用时间 = 借用时间.Text;
            model.备注信息 = 备注信息.Text;
            int[] selections = Grid4.SelectedRowIndexArray;
            int 资产数量 = 0;
            foreach (int rowIndex in selections)
            {
                int ID = Convert.ToInt32(Grid4.DataKeys[rowIndex][0]);
                string xxx = Grid4.DataKeys[rowIndex][0].ToString();
                model.资产ID += ID.ToString() + ",";
                资产数量++;
            }
            model.资产数量 = 资产数量.ToString();
            School资产借还交接BLL bll = new School资产借还交接BLL();

            AM_提醒通知 ammodel = new AM_提醒通知();
            ammodel.发起人 = 借用人.Text;
            ammodel.发起时间 = DateTime.Now;
            ammodel.是否已读 = "否";
            ammodel.通知类型 = "待办事项通知";
            ammodel.通知职务 = "财务人员";
            ammodel.消息内容 = "您来自" + 借用人.Text + "的资产借还申请通知！";
            ammodel.消息事项 = "资产借还";

            AM_待办业务 dbmodel = new AM_待办业务();
            dbmodel.处理方式 = "个人";
            dbmodel.处理人 = model.借出人;
            dbmodel.Sort = 1;
            dbmodel.发起人 = 借用人.Text;
            dbmodel.流程状态 = 流程状态.Text;
            dbmodel.事项名称 = "资产借还";
            dbmodel.通知内容 = "您来自" + 借用人.Text + "的资产借还申请,请及时处理！";
            dbmodel.FlowName = "资产借还";
            dbmodel.发起时间 = DateTime.Now.ToLongDateString();
            if (bll.创建资产借还(model,ammodel, dbmodel) > 0)
            {
                Window1.Hidden = true;
                Alert.ShowInTop("创建成功！");
                BindGrid();
            }

        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                OffSession();
                string username = Session["姓名"].ToString();
                //ID,流程状态,单据编号,借用人,借出人,提交时间,借用时间,预计归还时间,备注信息,Sort,资产ID
                object[] keys = Grid1.DataKeys[e.RowIndex];
                int Sort = Convert.ToInt32( keys[9].ToString());
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
                if (username == 查看借出人.Text && Sort==1)
                {
                    btnok.Text = "同意借出";
                    btnon.Text = "拒绝借出";
                }
                else if (Sort == 2 && 查看借用人.Text==username)
                {
                    btnok.Text = "确认归还";
                    btnon.Text = "关闭";
                }
                else if (Sort == 3 && 查看借出人.Text == username) 
                {
                    btnok.Text = "已归还";
                    btnon.Text = "未归还";
                }
                else 
                {
                    btnok.Text = "";
                    btnon.Text = "关闭";
                }
                查看提交时间.Text = keys[5].ToString();
                查看借用时间.Text = keys[6].ToString();
                查看预计归还时间.Text = keys[7].ToString();
                查看备注信息.Text = keys[8].ToString();
                
                string zcid = keys[10].ToString();
                资产ID.Text = zcid;
                School资产借还交接BLL bll = new School资产借还交接BLL();
                Grid3.DataSource = bll.资产借还查看详情(zcid);
                Grid3.DataBind(); 

                Window3.Hidden = false;
            }
        }

        protected string GetEditUrls(object id, object sort)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("事项名称", "事项名称" + id);
            joBuilder.AddProperty("title", "流程进度 - " + id);
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("School资产借还流程进度.aspx?SBBH={0}&sort={1}", id, HttpUtility.UrlEncode(sort.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }


        protected void btnok_Click(object sender, EventArgs e)
        {
            if (btnok.Text == "同意借出")
            {
                string processingtime = DateTime.Now.ToShortDateString();//处理时间
                string username = Session["姓名"].ToString();//处理人
                int flowid = Convert.ToInt32(FlowID.Text);
                string zcid = 资产ID.Text;
                AM_资产借还流程表 model = new AM_资产借还流程表();
                model.ID = flowid;
                model.资产ID = zcid;
                model.借出人操作时间 = processingtime;
                model.是否同意 = "是";
                model.操作人 = username;
                model.Sort = 1;

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "发起人";
                ammodel.消息内容 = "资产借还任务已全部完成！";
                ammodel.消息事项 = "资产借还";
                ammodel.发起人 = username;//处理人
                ammodel.FlowID = flowid;

                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.处理方式 = "个人";
                dbmodel.处理人 = model.借用人;
                dbmodel.发起人 = username;
                dbmodel.FlowID = flowid;
                dbmodel.流程状态 = "已出借,待归还";
                dbmodel.事项名称 = "资产借还";
                dbmodel.通知内容 = "您来自" + username + "的资产借还已同意,请及时处理！";
                dbmodel.Sort = 2;
                dbmodel.FlowName = "资产借还";
                dbmodel.发起时间 = DateTime.Now.ToLongDateString();

                School资产借还交接BLL bll = new School资产借还交接BLL();


                string sql = string.Format("UPDATE dbo.AM_待办业务 set 流程状态 = '{0}',处理职务='{1}',处理方式='{2}',处理人='{3}'  where FlowID = {4} AND FlowName = '{5}'", ammodel.流程状态, ammodel.处理职务, ammodel.处理方式, ammodel.处理人, ammodel.FlowID, ammodel.FlowName);

                if (bll.操作资产借还流程(model, ammodel, dbmodel) > 0)
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
            else if (btnok.Text == "确认归还")
            {
                School资产借还交接BLL bll = new School资产借还交接BLL();
                string processingtime = DateTime.Now.ToShortDateString();//处理时间
                string username = Session["姓名"].ToString();//处理人
                int flowid = Convert.ToInt32(FlowID.Text);
                string 出借人 = bll.查询出借人(flowid);
                AM_资产借还流程表 model = new AM_资产借还流程表();
                model.ID = flowid;
                model.申请人是否归还 = "是";
                model.申请人归还时间 = processingtime;
                model.Sort = 2;

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "出借人";
                ammodel.消息内容 = "资产借还流程"+username+"已归还，等待借出人确认。";
                ammodel.消息事项 = "资产借还";
                ammodel.发起人 = username;//处理人
                ammodel.FlowID = flowid;
                

                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.处理方式 = "个人";
                dbmodel.处理人 = 出借人;
                dbmodel.发起人 = username;
                dbmodel.流程状态 = "已归还,待确认";
                dbmodel.事项名称 = "资产借还";
                dbmodel.通知内容 = "您来自" + username + "的资产借还归还申请,请及时处理！";
                dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                dbmodel.FlowID = flowid;
                dbmodel.FlowName = "资产借还";
                dbmodel.Sort = 3;

               

                if (bll.操作资产借还流程(model, ammodel, dbmodel) > 0)
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
            else if (btnok.Text == "已归还") 
            {
                string processingtime = DateTime.Now.ToShortDateString();//处理时间
                string username = Session["姓名"].ToString();//处理人
                int flowid = Convert.ToInt32(FlowID.Text);
                AM_资产借还流程表 model = new AM_资产借还流程表();
                model.ID = flowid;
                model.出借人确认归还 = "是";
                model.出借人确认时间 = processingtime;
                model.Sort = 3;

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "结果反馈通知";
                ammodel.通知职务 = "发起人";
                ammodel.消息内容 = "您来自" + username + "的资产借还已同意,请及时处理！";
                ammodel.消息事项 = "资产借还";
                ammodel.发起人 = username;//处理人
                ammodel.FlowID = flowid;


                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.处理方式 = "";
                dbmodel.处理人 = "";
                dbmodel.发起人 = username;
                dbmodel.流程状态 = "完成";
                dbmodel.事项名称 = "资产借还";
                dbmodel.通知内容 = "您的资产借还流程已全部完成";
                dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                dbmodel.FlowID = flowid;
                dbmodel.Sort = 0;
                dbmodel.FlowName = "资产借还";

                School资产借还交接BLL bll = new School资产借还交接BLL();

                if (bll.操作资产借还流程(model, ammodel, dbmodel) > 0)
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

        protected void Unnamed_SelectedIndexChanged(object sender, EventArgs e)
        {
            School资产借还交接BLL bll = new School资产借还交接BLL();
            OffSession();
            string username = Session["姓名"].ToString();
            string 借还 = Unnamed.SelectedValue;
            DataSet ds = bll.借还条件(借还, username);
            DataTable dt = ds.Tables[0].Copy();
            Grid1.DataSource = dt;
            Grid1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            School资产借还交接BLL bll = new School资产借还交接BLL();
            OffSession();
            string username = Session["姓名"].ToString();
            string 状态 = DropDownList1.SelectedValue;
            string 借还 = Unnamed.SelectedValue;
            DataSet ds = bll.借还条件按状态(借还, username, 状态);
            DataTable dt = ds.Tables[0].Copy();
            Grid1.DataSource = dt;
            Grid1.DataBind();
        }
    }
}