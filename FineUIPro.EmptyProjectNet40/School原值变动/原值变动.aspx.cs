using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using PLM.BusinessRlues;
using PLM_Model;
using Newtonsoft.Json.Linq;
namespace FineUIPro.EmptyProjectNet40
{
    public partial class 原值变动 : PageBase
    {
        School原值变动BLL bll = new School原值变动BLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                OffSession();
                流程状态.Text = "待审核";
                
                单据编号.Text = "ZCZY00001";
                
                if (HttpContext.Current.Session["姓名"].ToString() == "")
                {
                    FineUIPro.Alert.Show("登录超时，请重新登陆！！！");
                    Response.Redirect("../UserLoginPage.aspx");
                }
                else
                {
                    申请人.Text = HttpContext.Current.Session["姓名"].ToString();
                }
                BindGrid();
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
        private void BindGrid()
        {
            int off = 0;
            DataSet ds = bll.首页_X_原值变动流程表("流程状态-全部");
            DataTable dt = ds.Tables[0].Copy();//复制一份table

            Grid1.DataSource = dt;
            Grid1.DataBind();
            if (off != 0)
            {
                btn5click();
            }
            off++;

        }



        protected void btnCheckSelection_Click(object sender, EventArgs e)
        {
            OffSession();
            string 职务 = Session["职务"].ToString();
            if (职务 == "资产管理员")
            {
                Window1.Hidden = false;
            }
            else
            {
                Alert alert = new Alert();
                alert.Message = "您不能创建原值变动";
                alert.Title = "提示信息";
                alert.MessageBoxIcon = MessageBoxIcon.Warning;
                alert.Show();
                return;

            }
            Window1.Hidden = false;
        }

        protected void btnIcon1_Click(object sender, EventArgs e)
        {
            Grid3.RecordCount = 700;//测试，去数据库获取总数
            // 2.获取当前分页数据
            DataTable table = GetPagedDataTableall(Grid3.PageIndex, Grid3.PageSize);//查询方法
            // 3.绑定到Grid
            Grid3.DataSource = table;//DataTable
            Grid3.DataBind();

            Window2.Hidden = false;
        }


        private DataTable GetPagedDataTableall(int pageIndex, int pageSize)
        {
            School资产处置BLL bll = new School资产处置BLL();
            DataSet ds = bll.查询全部资产信息();
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;
            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Rows.Count)
            {
                rowend = source.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Rows[i]);
            }

            return paged;
        }

        protected void Grid3_PageIndexChange(object sender, GridPageEventArgs e)
        {
            BindGrid();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            btn5click();
        }


        public void btn5click()
        {
            string sid = "";
            List<int> inlist = new List<int>();
            int 总数 = 0;
            int 总价 = 0;

            //获取grid3选中行数据
            int[] selections = Grid3.SelectedRowIndexArray;

            foreach (int rowIndex in selections)
            {
                int ID = Convert.ToInt32(Grid3.DataKeys[rowIndex][0]);
                sid += rowIndex.ToString() + ",";
                inlist.Add(ID);
            }
            if (inlist.Count == 0)
            {
                Alert.ShowInTop("请选中！", "提示信息", MessageBoxIcon.Warning);
                return;
            }
            School资产转移BLL bll = new School资产转移BLL();
            List<School办公设备信息表> listdata = bll.资产转移确定设备(inlist);
            foreach (School办公设备信息表 itemjj in listdata)
            {
                总数 += itemjj.数量;
                总价 += Convert.ToInt32(itemjj.价格);
            }

            Grid2.DataSource = listdata;//DataTable
            Grid2.DataBind();
            Grid2.SelectedRowIndexArray = new int[] { 0, 1 };
            Window2.Hidden = true;
           
            
        }


        protected string GetEditUrls(object id, object sort)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("事项名称", "事项名称" + id);
            joBuilder.AddProperty("title", "流程进度 - " + id);
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("School原值变动流程进度.aspx?SBBH={0}&sort={1}", id, HttpUtility.UrlEncode(sort.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }



        protected void Button1_Click(object sender, EventArgs e)
        {


            if (Grid2.GetMergedData().Count==0)
            {
                Alert.ShowInTop("请选择！", "提示信息", MessageBoxIcon.Warning);
                return;
            }
            SchoolX_原值变动流程表 model = new SchoolX_原值变动流程表();
            model.流程状态 = 流程状态.Text;
            model.单据编号 = 单据编号.Text;
            model.事项名称 = 事项名称.Text;
            model.申请人 = 申请人.Text;
            model.申请日期 = 申请日期.Text;
            model.记账人 = 记账人.Text;
            model.变动方式 = 变动方式.SelectedText;
            model.变动原因 = 变动原因.Text;
            model.记账人意见 = 记账人意见.Text;
            model.备注 = 备注.Text;
            double dj = 0;

            List<School办公设备信息表> listbg = new List<School办公设备信息表>();
            string sbid = "";
            string bdje = "";
            
            JArray mergedData = Grid2.GetMergedData();

            foreach (JObject mergedRow in mergedData)
            {
                JObject values = mergedRow.Value<JObject>("values");
                School办公设备信息表 bgmo = new School办公设备信息表();
                bgmo.ID=(Convert.ToInt32(values.Value<string>("ID")));
                sbid += values.Value<string>("ID").ToString()+",";
                try
                {
                    dj += Convert.ToDouble(values.Value<string>("价格"));
                    bgmo.变动金额 = (Convert.ToDouble(values.Value<string>("变动金额")));
                    if (bgmo.变动金额<1)
                    {
                        Alert.ShowInTop("请输入变动金额！", "提示信息", MessageBoxIcon.Warning);
                        return;
                    }
                    bdje += values.Value<string>("变动金额").ToString() + ",";
                }
                catch (Exception)
                {
                    //没填写   
                    Alert.ShowInTop("请填写变动金额！", "提示信息", MessageBoxIcon.Warning);
                    return;
                }

                listbg.Add(bgmo);
               

            }
            model.str变动金额 = bdje;
            model.资产ID = sbid;
            model.总价 = dj;
            model.总数 = Grid2.GetMergedData().Count;
            this.Label4.Text = "数量合计:" + Grid2.GetMergedData().Count + "---金额合计：" + dj + "元";


            AM_提醒通知 ammodel = new AM_提醒通知();
            ammodel.发起人 = 申请人.Text;
            ammodel.发起时间 = DateTime.Now;
            ammodel.是否已读 = "否";
            ammodel.通知类型 = "待办事项通知";
            ammodel.通知职务 = "财务人员";
            ammodel.消息内容 = "您来自" + 申请人.Text + "的原值变动申请通知！";
            ammodel.消息事项 = "购置验收";

            AM_待办业务 dbmodel = new AM_待办业务();
            dbmodel.处理职务 = "财务人员";
            dbmodel.发起人 = 申请人.Text;
            dbmodel.流程状态 = 流程状态.Text;
            dbmodel.事项名称 = "购置验收";
            dbmodel.通知内容 = "您来自" + 申请人.Text + "的原值变动申请,请及时处理！";
            dbmodel.发起时间 = DateTime.Now.ToLongDateString();

            //插入数据库
            if (bll.新增原值变动(model, listbg, ammodel, dbmodel) > 0) 
            {
                Window1.Hidden = true;
                Alert.ShowInTop("创建成功！");
                //return;
                BindGrid();
            }

        }




        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string flowstate = DropDownList1.SelectedText;
            DataSet ds = bll.首页_X_原值变动流程表(flowstate);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid1.DataSource = dt;
            Grid1.DataBind();
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                OffSession();
                string 职务 = Session["职务"].ToString();
                if (职务 == "财务人员")
                {
                    Button4.Text = "同意";
                    Button6.Text = "拒绝";
                }
                else
                {
                    Button4.Enabled = false;
                    Button6.Text = "关闭";
                }

                object[] keys = Grid1.DataKeys[e.RowIndex];
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                flowid.Text = ID.ToString();
                查看流程状态.Text = keys[1].ToString();
                if (查看流程状态.Text == "完成")
                {
                    Button4.Enabled = false;
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
                if (keys[15]==null)
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Button4.Text == "同意")
            {
                string username = Session["姓名"].ToString();//处理人
                string processingtime = DateTime.Now.ToShortDateString();//处理时间
                int FlowID = Convert.ToInt32(flowid.Text);
                SchoolX_原值变动流程表 model = new SchoolX_原值变动流程表();
                model.ID = FlowID;
                model.操作人 = username;
                model.操作时间 = processingtime;
                model.是否同意 = "是";

                AM_提醒通知 ammodel = new AM_提醒通知();

                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "结果反馈通知";
                ammodel.通知职务 = "发起人";
                ammodel.消息内容 = "原值变动任务已全部完成！";
                ammodel.消息事项 = "原值变动";
                ammodel.发起人 = username;//处理人
                ammodel.FlowID = FlowID;

                if (bll.操作原值变动流程(model, ammodel) > 0)
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
            else 
            {
                //不同意

            }

        }
        //流程状态
       
        protected void Button6_Click(object sender, EventArgs e)
        {


        }


    }
}