using Newtonsoft.Json.Linq;
using PLM.BusinessRlues;
using PLM_Common;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FineUIPro.EmptyProjectNet40
{
    public partial class 资产处置 : PageBase
    {
        School资产处置BLL bll = new School资产处置BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                二级.Enabled = false;
                三级.Enabled = false;
                负责人.Enabled = false;
                房间.Enabled = false;
                btnCheckSelection.OnClientClick = Grid1.GetNoSelectionAlertInTopReference("没有选中项！");
                BindGrid();


                School清查盘点BLL pdbll = new School清查盘点BLL();

                List<School一级部门表> xxmc = pdbll.查询一级部门();
                部门.DataTextField = "名称";
                部门.DataValueField = "ID";
                部门.DataSource = xxmc;
                部门.DataBind();
                部门.EmptyText = "全部";

                List<School建筑物信息表> 查询建筑物 = pdbll.查询建筑物信息表();
                存放地点.DataTextField = "名称";
                存放地点.DataValueField = "ID";
                存放地点.DataSource = 查询建筑物;
                存放地点.DataBind();
                存放地点.EmptyText = "全部";

                List<School一级类别表> yjlb = pdbll.查询一级类别();
                一级.DataTextField = "名称";
                一级.DataValueField = "ID";
                一级.DataSource = yjlb;
                一级.DataBind();
                一级.EmptyText = "全部";

                

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
        private void BindGrid()
        {
            DataSet ds = bll.查询全部资产信息();
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;

            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }

        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {

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
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                //Window3.Hidden = false;


            }
        }

        protected void btnCheckSelection_Click(object sender, EventArgs e)
        {
             


            //labResult.Text = sb.ToString();

            Window1.Hidden = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            List<int> inlist = new List<int>();
            //StringBuilder sb = new StringBuilder();
            int[] selections = Grid1.SelectedRowIndexArray;

            foreach (int rowIndex in selections)
            {
                int ID = Convert.ToInt32(Grid1.DataKeys[rowIndex][0]);
                inlist.Add(ID);
                //sb.AppendFormat("行号:{0} 用户名:{1}<br />", rowIndex + 1, Grid1.DataKeys[rowIndex][1]);
            }
            if (inlist.Count == 0)
            {
                Alert.ShowInTop("请选中！", "提示信息", MessageBoxIcon.Warning);
                return;
            }


            string comtxt = this.处置方式.SelectedItem.Text;
            if (comtxt == "请选择")
            {
                Alert.ShowInTop("请选择！", "提示信息", MessageBoxIcon.Warning);
                return;
            }
            if (comtxt == "转入待报废库") { comtxt = "待报废"; }
            else if (comtxt == "转入待调拨库") { comtxt = "待调拨"; }
            else if (comtxt == "转入待报损库") { comtxt = "待报损"; }
            else if (comtxt == "转入待出售库") { comtxt = "待出售"; }
            int result = bll.资产处置(inlist, comtxt);
            if (result > 0)
            {
                Alert.ShowInTop("处置成功，已转入处置库！", "提示信息", MessageBoxIcon.Success);
                Window1.Hidden = true;
                Grid1.RecordCount = 700;//测试，去数据库获取总数
                // 2.获取当前分页数据
                DataTable table = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);//查询方法
                // 3.绑定到Grid
                Grid1.DataSource = table;//DataTable
                Grid1.DataBind();
                //处置成功
            }


        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            BindGrid();
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            School申报审批BLL bll = new School申报审批BLL();
            Window2.Hidden = false;
            DataSet ds = bll.待处置库查询("待报废","");
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid2.DataSource = dt;//DataTable
            Grid2.DataBind();
        }

        protected void 类别_SelectedIndexChanged(object sender, EventArgs e)
        {
            School申报审批BLL bll = new School申报审批BLL();
            string flowstate = 类别.SelectedValue;
            DataSet ds = bll.待处置库查询(flowstate,时间排序.SelectedValue);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid2.DataSource = dt;//DataTable
            Grid2.DataBind();
        }

        protected void 时间排序_SelectedIndexChanged(object sender, EventArgs e)
        {
            School申报审批BLL bll = new School申报审批BLL();
            string flowstate = 类别.SelectedValue;
            DataSet ds = bll.待处置库查询(flowstate,时间排序.SelectedValue);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid2.DataSource = dt;//DataTable
            Grid2.DataBind();
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
        protected void 发起申报_zccz_Click(object sender, EventArgs e)
        {
            School申报审批BLL bll = new School申报审批BLL();
            if (类别.SelectedValue.ToString() == "待报废")
            {

                if (类别.SelectedValue.ToString() == "待报废")
                {
                    OffSession();
                    string 职务 = Session["职务"].ToString();
                    List<int> intlist = new List<int>();
                    int[] selections = Grid2.SelectedRowIndexArray;
                    Console.Write(selections.Length);
                    if (selections.Length == 0)
                    {
                        Alert.Show("请选择");
                    }
                    else
                    {
                        Window3.Hidden = false;
                        Console.Write(selections);
                        foreach (int rowIndex in selections)
                        {
                            int ID = Convert.ToInt32(Grid2.DataKeys[rowIndex][0]);
                            intlist.Add(ID);
                        }
                        List<School办公设备信息表> listdata = bll.资产申报确定设备(intlist, 类别.SelectedValue);
                        string flowstate = 类别.SelectedValue;
                        //int 总数 = 0;
                        //int 总价 = 0;
                        float 总数 = 0.0f;
                        float 总价 = 0.0f;
                        if (listdata != null)
                        {
                            foreach (School办公设备信息表 itemjj in listdata)
                            {
                                总数 += itemjj.数量;
                                总价 += Convert.ToInt32(itemjj.价格);
                            }
                        }
                        Grid3.DataSource = listdata;//DataTable
                        Grid3.DataBind();

                        Grid4.DataSource = listdata;//DataTable
                        Grid4.DataBind();
                        JObject summary = new JObject();
                        //summary.Add("major", "全部合计");
                        summary.Add("数量", 总数.ToString("F2"));
                        summary.Add("价格", 总价.ToString("F2"));

                        Grid3.SummaryData = summary;
                        Grid4.SummaryData = summary;
                        //Grid7.SummaryData = summary;
                        //Grid8.SummaryData = summary;
                        //待报废Grid3
                        报废流程状态.Text = "待审核";
                        
                        报废_申报单位.Text = Session["二级部门名称"].ToString();
                        
                        报废_申报日期.Text = DateTime.Now.ToShortDateString();
                        报废单据编号.Text = SchoolUtility.strbumber("ZCCZBF"); ;
                        
                        报废_申请人.Text = HttpContext.Current.Session["姓名"].ToString();
                        

                        报废_职务.Text = 职务;
                        

                    }
                }
            }
            else if (类别.SelectedValue.ToString() == "待调拨")
            {
                OffSession();
                string 职务 = Session["职务"].ToString();
                if (职务 == "资产管理员")
                {
                    School清查盘点BLL pdbll = new School清查盘点BLL();
                    List<School一级部门表> xxmc = SchoolUtility.查询一级部门不带全部(); ;
                    调拨调入单位.DataTextField = "名称";
                    调拨调入单位.DataValueField = "ID";
                    调拨调入单位.DataSource = xxmc;
                    调拨调入单位.DataBind();

                    List<int> intlist = new List<int>();
                    int[] selections = Grid2.SelectedRowIndexArray;
                    if (selections.Length == 0)
                    {
                        Alert.Show("请选择");
                    }
                    else
                    {
                        Window4.Hidden = false;
                        foreach (int rowIndex in selections)
                        {
                            int ID = Convert.ToInt32(Grid2.DataKeys[rowIndex][0]);
                            intlist.Add(ID);
                        }
                        List<School办公设备信息表> listdata = bll.资产申报确定设备(intlist, 类别.SelectedValue);
                        string flowstate = 类别.SelectedValue;
                        Grid5.DataSource = listdata;//DataTable
                        Grid5.DataBind();

                        Grid6.DataSource = listdata;
                        Grid6.DataBind();


                        //当前用户部门是调出单位  调入单位操作人选填
                        调拨流程状态.Text = "待审核";
                        
                        调拨调出单位.Text = Session["二级部门名称"].ToString();
                        
                        调拨申报日期.Text = DateTime.Now.ToShortDateString();
                        调拨验收日期.Text = DateTime.Now.ToShortDateString();

                        float 总数 = 0.0f;
                        float 总价 = 0.0f;
                        if (listdata != null)
                        {
                            foreach (School办公设备信息表 itemjj in listdata)
                            {
                                总数 += itemjj.数量;
                                总价 += Convert.ToInt32(itemjj.价格);
                            }
                        }



                        JObject summary = new JObject();
                        //summary.Add("major", "全部合计");
                        summary.Add("数量", 总数.ToString("F2"));
                        summary.Add("价格", 总价.ToString("F2"));

                        Grid5.SummaryData = summary;
                        Grid6.SummaryData = summary;


                        DateTime dt = DateTime.Now;
                        string y = dt.Year.ToString();
                        string m = dt.Month.ToString();
                        string d = dt.Day.ToString();
                        string h = dt.Hour.ToString();
                        string mm = dt.Minute.ToString();
                        调拨单据编号.Text = SchoolUtility.strbumber("ZCCZDB");
                       
                        调拨_申请人.Text = HttpContext.Current.Session["姓名"].ToString();
                        
                        调拨职务.Text = HttpContext.Current.Session["职务"].ToString();
                        try
                        {
                            调拨电话.Text = HttpContext.Current.Session["联系电话"].ToString();
                        }
                        catch (Exception)
                        {
                            调拨电话.Text = "";

                        }
                    }
                }
                else
                {
                    Alert.Show("您没有资产处置-调拨处理的权限，请联系资产管理员", MessageBoxIcon.Warning);
                }



            }
        }

        protected void 资产处置报废申报_Click(object sender, EventArgs e)
        {
            string sid = "";
            List<int> intlist = new List<int>();
            int[] selections = Grid2.SelectedRowIndexArray;
            School申报审批BLL bll = new School申报审批BLL();

            foreach (int rowIndex in selections)
            {
                int ID = Convert.ToInt32(Grid2.DataKeys[rowIndex][0]);
                sid += ID.ToString() + ",";
                intlist.Add(ID);
            }
            List<School办公设备信息表> listdata = bll.资产申报确定设备(intlist, 类别.SelectedValue);
            float 总数 = 0.0f;
            float 总价 = 0.0f;
            if (listdata != null)
            {
                foreach (School办公设备信息表 itemjj in listdata)
                {
                    总数 += itemjj.数量;
                    总价 += Convert.ToInt32(itemjj.价格);
                }
            }

            SchoolX_资产处置流程表 model = new SchoolX_资产处置流程表();
            model.SID = sid;
            model.Sort = 1;
            model.FlowName = "资产处置-报废";
            model.流程状态 = 报废流程状态.Text;
            model.单据编号 = 报废单据编号.Text;
            model.申请人 = 报废_申请人.Text;
            model.申报单位 = 报废_申报单位.Text;

            model.职务 = 报废_职务.Text;
            model.电话 = 报废_电话.Text;
            model.事项名称 = 报废_事项名称.Text;
            model.申报日期 = 报废_申报日期.Text;

            model.原因说明 = 报废_原因说明.Text;
            model.总价 = Convert.ToInt32(总价);
            model.总数 = Convert.ToInt32(总数);

            model.调入单位分管领导意见 = "未处理";
            model.调入单位分管领导 = "未处理";
            //model.调入单位分管领导处理时间 = "未处理";
            model.调入单位分管领导处理时间 = "未处理";

            model.主管部门意见 = "未处理";
            model.主管部门处理时间 = "未处理";
            model.主管部门 = "未处理";

            model.财政部门意见 = "未处理";
            model.财政部门 = "未处理";
            model.财政部门处理时间 = "未处理";
            if (bll.创建处置申报资产报废(model) > 0)
            {
                Alert.ShowInTop("处置成功！", "提示信息", MessageBoxIcon.Information);
                Window3.Hidden = true;
                BindGrid();
            }
        }

        protected void 资产处置调拨申报_Click(object sender, EventArgs e)
        {
            string sid = "";
            List<int> intlist = new List<int>();
            int[] selections = Grid2.SelectedRowIndexArray;
            School申报审批BLL bll = new School申报审批BLL();

            foreach (int rowIndex in selections)
            {
                int ID = Convert.ToInt32(Grid2.DataKeys[rowIndex][0]);
                sid += ID.ToString() + ",";
                intlist.Add(ID);
            }
            List<School办公设备信息表> listdata = bll.资产申报确定设备(intlist, 类别.SelectedValue);
            float 总数 = 0.0f;
            float 总价 = 0.0f;
            if (listdata != null)
            {
                foreach (School办公设备信息表 itemjj in listdata)
                {
                    总数 += itemjj.数量;
                    总价 += Convert.ToInt32(itemjj.价格);
                }
            }

            SchoolX_资产处置流程表 model = new SchoolX_资产处置流程表();
            model.Sort = 1;
            model.FlowName = "资产处置-调拨";
            model.单据编号 = 调拨单据编号.Text;
            model.流程状态 = 调拨流程状态.Text;
            model.申报日期 = 调拨申报日期.Text;
            model.SID = sid;
            model.总价 = Convert.ToInt32(总价);
            model.总数 = Convert.ToInt32(总数);
            model.原因说明 = 调拨原因说明.Text;
            model.申请人 = 调拨_申请人.Text;
            model.职务 = 调拨职务.Text;
            model.电话 = 调拨电话.Text;
            model.验收日期 = 调拨验收日期.Text;
            if (调拨调入单位.SelectedText == "" || 调拨调入单位.SelectedText == null)
            {
                Alert.ShowInTop("请选择调入单位！", "提示信息", MessageBoxIcon.Warning);
                return;
            }
            model.调入单位 = 调拨调入单位.SelectedText;
            model.调出单位 = 调拨调出单位.Text;
            model.事项名称 = 调拨_事项名称.Text;
            //以下字段未处理
            model.调出单位分管领导意见 = "未处理";
            model.调出单位分管领导 = "未处理";
            model.调出单位分管领导处理时间 = "未处理";

            model.调入单位管理员意见 = "未处理";
            model.调入单位管理员 = "未处理";
            model.调入单位管理员处理时间 = "未处理";

            model.调入单位分管领导意见 = "未处理";
            model.调入单位分管领导 = "未处理";
            model.调入单位分管领导处理时间 = "未处理";

            model.主管部门意见 = "未处理";
            model.主管部门处理时间 = "未处理";
            model.主管部门 = "未处理";

            model.财政部门意见 = "未处理";
            model.财政部门 = "未处理";
            model.财政部门处理时间 = "未处理";



            int result = bll.插入资产处置调拨单(model);
            if (result > 0)
            {
                Alert.ShowInTop("处置成功！", "提示信息", MessageBoxIcon.Information);
                Window4.Hidden = true;
                
                BindGrid();
            }
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList2.SelectedValue == "处置单")
            {
                Grid3.Hidden = false;
                Grid4.Hidden = true;
            }
            else
            {
                Grid3.Hidden = true;
                Grid4.Hidden = false;
            }
        }

        protected void btnon_Click(object sender, EventArgs e)
        {
            Window3.Hidden = true;
        }

        protected void Unnamed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Unnamed.SelectedValue == "处置单")
            {
                Grid5.Hidden = false;
                Grid6.Hidden = true;
            }
            else
            {
                Grid5.Hidden = true;
                Grid6.Hidden = false;
            }
        }

        protected void 添加资产_zccz_Click(object sender, EventArgs e)
        {
            添加资产.Hidden = false;
            DataSet ds = bll.查询全部资产信息();
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;

            // 3.绑定到Grid

            Grid12.DataSource = dt;//DataTable
            Grid12.DataBind();

            School清查盘点BLL pdbll = new School清查盘点BLL();
            List<School一级类别表> yjlb = pdbll.查询一级类别();
            资产分类_tjcz.DataTextField = "名称";
            资产分类_tjcz.DataValueField = "ID";
            资产分类_tjcz.DataSource = yjlb;
            资产分类_tjcz.DataBind();
            资产分类_tjcz.EmptyText = "全部";


            List<School一级部门表> xxmc = pdbll.查询一级部门();
            归属信息_tjcz.DataTextField = "名称";
            归属信息_tjcz.DataValueField = "ID";
            归属信息_tjcz.DataSource = xxmc;
            归属信息_tjcz.DataBind();
            归属信息_tjcz.EmptyText = "全部";

            List<School建筑物信息表> 查询建筑物 = pdbll.查询建筑物信息表();
            存放地点_tjcz.DataTextField = "名称";
            存放地点_tjcz.DataValueField = "ID";
            存放地点_tjcz.DataSource = 查询建筑物;
            存放地点_tjcz.DataBind();
            存放地点_tjcz.EmptyText = "全部";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            List<int> inlist = new List<int>();
            //StringBuilder sb = new StringBuilder();
            int[] selections = Grid12.SelectedRowIndexArray;

            foreach (int rowIndex in selections)
            {
                int ID = Convert.ToInt32(Grid12.DataKeys[rowIndex][0]);
                inlist.Add(ID);
                //sb.AppendFormat("行号:{0} 用户名:{1}<br />", rowIndex + 1, Grid1.DataKeys[rowIndex][1]);
            }
            if (inlist.Count == 0)
            {
                Alert.ShowInTop("请选中！", "提示信息", MessageBoxIcon.Warning);
                return;
            }


            string comtxt = this.处置方式_tjzcczfs.SelectedItem.Text;
            if (comtxt == "请选择")
            {
                Alert.ShowInTop("请选择！", "提示信息", MessageBoxIcon.Warning);
                return;
            }
            if (comtxt == "转入待报废库") { comtxt = "待报废"; }
            else if (comtxt == "转入待调拨库") { comtxt = "待调拨"; }
            else if (comtxt == "转入待报损库") { comtxt = "待报损"; }
            else if (comtxt == "转入待出售库") { comtxt = "待出售"; }
            int result = bll.资产处置(inlist, comtxt);
            if (result > 0)
            {
                Alert.ShowInTop("处置成功，已转入处置库！", "提示信息", MessageBoxIcon.Success);
                添加资产资产处置.Hidden = true;
                Grid12.RecordCount = 700;//测试，去数据库获取总数
                // 2.获取当前分页数据
                DataTable table = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);//查询方法
                // 3.绑定到Grid
                Grid12.DataSource = table;//DataTable
                Grid12.DataBind();
                //处置成功
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            添加资产资产处置.Hidden = true;
        }

        protected void 确认添加_tjcz_Click(object sender, EventArgs e)
        {
            添加资产资产处置.Hidden = false;
        }

        protected void 确认查询_tjcz_Click(object sender, EventArgs e)
        {
            School查询办公设备条件表 model = new School查询办公设备条件表();

            model.一级分类 = 资产分类_tjcz.SelectedText;
            model.存放地点s = 存放地点_tjcz.SelectedText;
            model.归属部门 = Convert.ToInt32(归属信息_tjcz.SelectedValue);
            model.起始投入日期 = 起始日期_tjcz.Text;
            model.结束投入日期 = 截止日期_tjcz.Text;
            School资产处置BLL bll = new School资产处置BLL();
            DataSet ds = bll.查询全部资产信息(model);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;



            // 3.绑定到Grid
            Grid12.DataSource = dt;//DataTable
            Grid12.DataBind();
        }
    }
}