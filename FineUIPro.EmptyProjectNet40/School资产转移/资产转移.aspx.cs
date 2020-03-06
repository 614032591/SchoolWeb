using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PLM_Common;


namespace FineUIPro.EmptyProjectNet40.资产转移
{
    public partial class 资产转移 : System.Web.UI.Page
    {
        School资产转移BLL bll = new School资产转移BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 1.获取数据总数
                流程状态.Text = "待审核";
                string str = "ZCZY";
               
                单据编号.Text = SchoolUtility.strbumber(str);
                OffSession();
                申请人.Text = HttpContext.Current.Session["姓名"].ToString();
                Button9.Enabled = false;
                Button3.Enabled = false;

                二级.Enabled = false;
                三级.Enabled = false;
                负责人.Enabled = false;
                房间.Enabled = false;

                // 2.获取当前分页数据
                //DataTable table = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);//查询方法
                DataSet ds = bll.首页_X_资产转移流程表("流程状态-全部");
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                DataTable source = dt;

                // 3.绑定到Grid
                Grid1.DataSource = dt;//DataTable
                Grid1.DataBind();

                List<School一级部门表> gsbm = bll.byzc();
                归属部门变更为.DataTextField = "名称";
                归属部门变更为.DataValueField = "ID";
                归属部门变更为.DataSource = gsbm;
                归属部门变更为.DataBind();

                List<School房间信息表> cfdd = bll.cfdd();

                存放地点变更为.DataTextField = "名称";
                存放地点变更为.DataValueField = "ID";
                存放地点变更为.DataSource = cfdd;
                存放地点变更为.DataBind();



            }



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

        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {

            DataSet ds = bll.首页_X_资产转移流程表("");
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
        //int qjid = 0;
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                xx.Text = ID.ToString();
                查看流程状态.Text = keys[1].ToString();
                OffSession();
                string zw= Session["职务"].ToString();
                if (查看流程状态.Text == "待审核" && zw == "资产管理员")
                {
                    Button9.Enabled = true;
                    Button3.Enabled = true;
                }
                else
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

        protected void btnCheckSelection_Click(object sender, EventArgs e)
        {
            Window1.Hidden = false;
            申请日期.Text = DateTime.Now.ToString();
            OffSession();
            string xm=HttpContext.Current.Session["姓名"].ToString();
            联系方式.Text = bll.查询用户电话(xm);
        }

        protected void 归属部门变更为_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(归属部门变更为.SelectedValue);
            List<用户表> listuser = bll.listuser(ID);
            负责人变更为.DataTextField = "姓名";
            负责人变更为.DataValueField = "ID";
            负责人变更为.DataSource = listuser;
            负责人变更为.DataBind();
        }

        protected void btnIcon1_Click(object sender, EventArgs e)
        {

            School资产处置BLL bll = new School资产处置BLL();
            DataSet ds = bll.查询全部资产信息();
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;


            // 3.绑定到Grid
            Grid3.DataSource = dt;//DataTable
            Grid3.DataBind();
            //绑定条件
            School清查盘点BLL pdbll = new School清查盘点BLL();

            List<School一级部门表> xxmc = pdbll.查询一级部门();
            部门.DataTextField = "名称";
            部门.DataValueField = "ID";
            部门.DataSource = xxmc;
            部门.DataBind();

            List<School一级类别表> yjlb = pdbll.查询一级类别();
            一级.DataTextField = "名称";
            一级.DataValueField = "ID";
            一级.DataSource = yjlb;
            一级.DataBind();


            List<School建筑物信息表> 查询建筑物 = pdbll.查询建筑物信息表();
            存放地点.DataTextField = "名称";
            存放地点.DataValueField = "ID";
            存放地点.DataSource = 查询建筑物;
            存放地点.DataBind();


            二级.Enabled = false;
            三级.Enabled = false;
            负责人.Enabled = false;
            房间.Enabled = false;

            二级.EmptyText = "全部";
            三级.EmptyText = "全部";
            负责人.EmptyText = "全部";
            房间.EmptyText = "全部";

            Window2.Hidden = false;
        }




        protected void Button5_Click(object sender, EventArgs e)
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

            List<School办公设备信息表> listdata = bll.资产转移确定设备(inlist);
            foreach (School办公设备信息表 itemjj in listdata)
            {
                总数 += itemjj.数量;
                总价 += Convert.ToInt32(itemjj.价格);
            }

            Grid2.DataSource = listdata;//DataTable
            Grid2.DataBind();
            Window2.Hidden = true;



            //获取填写数据

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //获取原存放地

            string sid = "";
            List<int> inlist = new List<int>();
            int 总数 = 0;
            int 总价 = 0;

            //获取grid3选中行数据
            int[] selections = Grid3.SelectedRowIndexArray;
            List<SchoolX_资产转移改动信息表> listmodel = new List<SchoolX_资产转移改动信息表>();

            foreach (int rowIndex in selections)
            { 
                SchoolX_资产转移改动信息表 modelx = new SchoolX_资产转移改动信息表();
                int ID = Convert.ToInt32(Grid3.DataKeys[rowIndex][0]);

                modelx.原存放地点 = Grid3.DataKeys[rowIndex][1].ToString();
                modelx.原归属部门 = Grid3.DataKeys[rowIndex][2].ToString();
                modelx.原负责人 = Grid3.DataKeys[rowIndex][3].ToString();

                sid += ID.ToString() + ",";
                inlist.Add(ID);
                listmodel.Add(modelx);
                //sb.AppendFormat("行号:{0} 用户名:{1}<br />", rowIndex + 1, Grid1.DataKeys[rowIndex][1]);
            }

            List<School办公设备信息表> listdata = bll.资产转移确定设备(inlist);
            foreach (School办公设备信息表 itemjj in listdata)
            {
                总数 += itemjj.数量;
                总价 += Convert.ToInt32(itemjj.价格);
            }
            SchoolX_资产转移流程表 model = new SchoolX_资产转移流程表();
            model.流程状态 = 流程状态.Text;
            model.单据编号 = 单据编号.Text;
            model.事项名称 = 事项名称.Text;
            model.申请人 = 申请人.Text;
            model.申请日期 = 申请日期.Text;
            model.联系方式 = 联系方式.Text;
            model.存放地点变更为 = 存放地点变更为.SelectedItem.Text;
            model.归属部门变更为 = 归属部门变更为.SelectedItem.Text;
            model.负责人变更为 = 负责人变更为.SelectedItem.Text;
            model.备注信息 = 备注.Text;
            model.S_ID = sid;
            model.总数 = 总数;
            model.总价 = 总价;
            AM_提醒通知 ammodel = new AM_提醒通知();

            ammodel.发起时间 = DateTime.Now;
            ammodel.是否已读 = "否";
            ammodel.通知类型 = "待办事项通知";
            ammodel.通知职务 = "资产管理员";
            ammodel.发起人 = model.申请人;
            ammodel.消息内容 = "您来自" + ammodel.发起人 + "的资产交接申请,请及时处理！";
            ammodel.消息事项 = "资产转移";
            ammodel.是否已读 = "否";
            AM_待办业务 dbmodel = new AM_待办业务();
            dbmodel.处理方式 = "职务";
            dbmodel.处理职务 = "资产管理员"; 
            dbmodel.流程状态 = 流程状态.Text;
            dbmodel.事项名称 = model.事项名称;
            dbmodel.FlowName = "资产转移";
            dbmodel.发起人 = model.申请人;
            dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产交接申请,请及时处理！";
            dbmodel.发起时间 = DateTime.Now.ToLongDateString();
            dbmodel.Sort = 1;

            if (model.存放地点变更为 == "" || model.存放地点变更为 == null || model.归属部门变更为 == "" || model.归属部门变更为 == null || model.负责人变更为 == "" || model.负责人变更为 == "请选择")
            {
                Alert.ShowInTop("请将信息填写完整！", "提示信息", MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int result = bll.upzczy(model, inlist, listmodel,ammodel,dbmodel);
                if (result > 0)
                {
                    Alert.ShowInTop("提交成功！", "提示信息", MessageBoxIcon.Information);
                    Window1.Hidden = true;
                    DataSet ds = bll.首页_X_资产转移流程表("流程状态-全部");
                    DataTable dt = ds.Tables[0].Copy();//复制一份table
                    DataTable source = dt;

                    // 3.绑定到Grid
                    Grid1.DataSource = dt;//DataTable
                    Grid1.DataBind();

                    return;
                }
            }
        }

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

        protected void Button9_Click(object sender, EventArgs e)
        {
            OffSession();
            string username = Session["姓名"].ToString();
            AM_提醒通知 ammodel = new AM_提醒通知();

            ammodel.发起时间 = DateTime.Now;
            ammodel.是否已读 = "否";
            ammodel.通知类型 = "结果反馈通知";
            ammodel.通知职务 = "资产管理员";
            ammodel.发起人 = username;
            ammodel.消息内容 = "您来自" + ammodel.发起人 + "的资产转移已完成！";
            ammodel.消息事项 = "资产转移";
            ammodel.是否已读 = "否";
            AM_待办业务 dbmodel = new AM_待办业务();
            dbmodel.处理方式 = "职务";
            dbmodel.处理职务 = "资产管理员";
            dbmodel.流程状态 = "已完成";
            dbmodel.发起人 = ammodel.发起人;
            dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产转移已完成！";
            dbmodel.发起时间 = DateTime.Now.ToLongDateString();
            dbmodel.Sort = 0;

            //执行修改
            int id = Convert.ToInt16(xx.Text);
            if (id > 0)
            {
                int num = bll.修改数据(id, 查看归属部门变更为.Text, 查看存放地点变更为.Text, 查看负责人变更为.Text,ammodel,dbmodel);
                if (num > 0)
                {
                    Alert.ShowInTop("转移成功！", "提示信息", MessageBoxIcon.Information);
                    新增资产转移查看详情.Hidden = true;
                    DataSet ds = bll.首页_X_资产转移流程表("流程状态-全部");
                    DataTable dt = ds.Tables[0].Copy();//复制一份table
                    DataTable source = dt;
                    // 3.绑定到Grid
                    Grid1.DataSource = dt;//DataTable
                    Grid1.DataBind();
                }
            }
            else
            {
                Alert.ShowInTop("未获取选择行！", "警告信息", MessageBoxIcon.Error);
            }


            //

        }

        protected void 一级_SelectedIndexChanged(object sender, EventArgs e)
        {
            二级.Enabled = true;
            int ID = Convert.ToInt32(一级.SelectedValue);
            if (ID > 0)
            {
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School二级类别表> listuser = pdbll.查询二级类别(ID);
                二级.DataTextField = "名称";
                二级.DataValueField = "ID";
                二级.DataSource = listuser;
                二级.DataBind();
            }
        }

        protected void 二级_SelectedIndexChanged(object sender, EventArgs e)
        {
            三级.Enabled = true;
            int ID = Convert.ToInt32(二级.SelectedValue);
            if (ID > 0)
            {
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
                List<用户表> listuser = bll.listuser(ID);
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
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            School查询办公设备条件表 model = new School查询办公设备条件表();
            string str一级 = 一级.SelectedText;
            string str二级 = 二级.SelectedText;
            string str三级 = 三级.SelectedText;
            if (str一级 == "全部" || str一级==null) 
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
            if (str部门 != "全部"&&str部门!=null)
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

            School资产处置BLL bll = new School资产处置BLL();
            DataSet ds = bll.查询全部资产信息(model);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;


            // 3.绑定到Grid
            Grid3.DataSource = dt;//DataTable
            Grid3.DataBind();

            //二级.Enabled = false;
            //三级.Enabled = false;
            //负责人.Enabled = false;
            //房间.Enabled = false;

            二级.EmptyText = "全部";
            三级.EmptyText = "全部";
            负责人.EmptyText = "全部";
            房间.EmptyText = "全部";

        }

        //流程进度
        protected string GetEditUrls(object id, object sort)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("事项名称", "事项名称" + id);
            joBuilder.AddProperty("title", "流程进度 - " + id);
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("School资产转移流程进度.aspx?SBBH={0}&sort={1}", id, HttpUtility.UrlEncode(sort.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }

    }
}