using Newtonsoft.Json.Linq;
using PLM.BusinessRlues;
using PLM_Common;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.申报审批
{
    public partial class 处置申报 : PageBase
    {
        School申报审批BLL bll = new School申报审批BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //btnzcczdbok.OnClientClick = Confirm.GetShowReference("确定审批通过？", String.Empty, MessageBoxIcon.Question, btnzcczdbok.GetPostBackEventReference(), String.Empty);
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataSet ds = bll.首页_X_资产处置流程表("");
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }

        //流程状态
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string flowstate = DropDownList1.SelectedText;

            DataSet ds = bll.首页_X_资产处置流程表(flowstate);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }
        //
        protected void btnCheckSelection_Click(object sender, EventArgs e)
        {
            Window1.Hidden = false;
            DataSet ds = bll.待处置库查询("待报废");
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid2.DataSource = dt;//DataTable
            Grid2.DataBind();
        }

        //待处置库类别
        protected void 类别_SelectedIndexChanged(object sender, EventArgs e)
        {

            string flowstate = 类别.SelectedValue;
            DataSet ds = bll.待处置库查询(flowstate);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid2.DataSource = dt;//DataTable
            Grid2.DataBind();

        }
        //确认申报
        protected void Button1_Click(object sender, EventArgs e)
        {
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
                        Window2.Hidden = false;
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
                        报废流程状态.Enabled = false;
                        报废_申报单位.Text = Session["二级部门名称"].ToString();
                        报废_申报单位.Enabled = false;
                        报废_申报日期.Text = DateTime.Now.ToShortDateString();
                        报废单据编号.Text = SchoolUtility.strbumber("ZCCZBF"); ;
                        报废单据编号.Enabled = false;
                        报废_申请人.Text = HttpContext.Current.Session["姓名"].ToString();
                        报废_申请人.Enabled = false;

                        报废_职务.Text = 职务;
                        报废_职务.Enabled = false;

                    }
                }
            }
            else if (类别.SelectedValue.ToString() == "待调拨")
            {
                OffSession();
                string 职务 = Session["职务"].ToString();
                if (职务== "资产管理员")
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
                        Window3.Hidden = false;
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
                        调拨流程状态.Enabled = false;
                        调拨调出单位.Text = Session["二级部门名称"].ToString();
                        调拨调出单位.Enabled = false;
                        调拨申报日期.Text = DateTime.Now.ToShortDateString();
                        调拨验收日期.Text = DateTime.Now.ToShortDateString();

                        DateTime dt = DateTime.Now;
                        string y = dt.Year.ToString();
                        string m = dt.Month.ToString();
                        string d = dt.Day.ToString();
                        string h = dt.Hour.ToString();
                        string mm = dt.Minute.ToString();
                        调拨单据编号.Text = SchoolUtility.strbumber("ZCCZDB");
                        调拨单据编号.Enabled = false;
                        调拨_申请人.Text = HttpContext.Current.Session["姓名"].ToString();
                        调拨_申请人.Enabled = false;
                        调拨职务.Enabled = false;
                        调拨电话.Enabled = false;
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
                    Alert.Show("您没有资产处置-调拨处理的权限，请联系资产管理员",MessageBoxIcon.Warning);
                }
                
                

            }

        }

        //固定资产处置单(报废)
        protected void Button2_Click(object sender, EventArgs e)
        {


            string sid = "";
            List<int> intlist = new List<int>();
            int[] selections = Grid2.SelectedRowIndexArray;

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
                Window2.Hidden = true;
                Window1.Hidden = true;
                BindGrid();
            }

        }

        //固定资产处置单(调拨)
        protected void Button8_Click(object sender, EventArgs e)
        {

            string sid = "";
            List<int> intlist = new List<int>();
            int[] selections = Grid2.SelectedRowIndexArray;

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
                Window3.Hidden = true;
                Window1.Hidden = true;
                BindGrid();
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

        protected void btnzcczdbok_Click(object sender, EventArgs e)
        {
            OffSession();
            string 职务 = Session["职务"].ToString();
            string sort = Sort.Text;
            if (职务 == "分管领导" && sort == "1")
            {
                审批处理界面.Hidden = false;

            }
            else if (职务 == "主管部门" && sort == "2")
            {
                审批处理界面.Hidden = false;
            }
            else if (职务 == "财务人员" && sort == "3")
            {
                审批处理界面.Hidden = false;
            }
        }

        protected void btntanchuang_Click(object sender, EventArgs e)
        {
            OffSession();
            string 职务 = Session["职务"].ToString();
            string sort = Sort.Text;
            if (FlowName.Text == "资产处置-调拨")
            {

                审批处理界面.Hidden = false;
            }
        }

        //待报废查看详情处理
        protected void Button15_Click(object sender, EventArgs e)
        {
            string zcid = 资产ID.Text;
            Button15.Hidden = false;
            OffSession();
            string 职务 = Session["职务"].ToString();
            string sort = Sort.Text;


            #region//分管领导
            if (职务 == "分管领导" && sort == "1")
            {
                审批处理界面.Hidden = false;
                ZCCLSPYES.Text = "分管领导同意";

            }
            #endregion
            #region//主管部门
            else if (职务 == "主管部门" && sort == "2")
            {
                审批处理界面.Hidden = false;
                ZCCLSPYES.Text = "主管部门同意";
   
            }
            #endregion
            #region//财务
            else if (职务 == "财务人员" && sort == "3")
            {

                审批处理界面.Hidden = false;
                ZCCLSPYES.Text = "财务人员同意";
    
            }
            #endregion
            else
            {
                if (sort == "1")
                {
                    Alert.Show("您没有处理权限,请分管领导处理", MessageBoxIcon.Warning);
                }
                else if (sort == "2")
                {
                    Alert.Show("您没有处理权限,请主管部门处理", MessageBoxIcon.Warning);
                }
                else if (sort == "3")
                {
                    Alert.Show("您没有处理权限,请财务部门处理", MessageBoxIcon.Warning);
                }
                else
                {
                    Alert.Show("您没有处理权限", MessageBoxIcon.Warning);
                }

            }
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                OffSession();

                string username = Session["姓名"].ToString();
                object[] keys = Grid1.DataKeys[e.RowIndex];
                string 职务 = Session["职务"].ToString();
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                FlowID.Text = ID.ToString();
                School申报审批BLL sbspbll = new School申报审批BLL();
                string xa = "";
                string SID = keys[1].ToString();//获取SID
                资产ID.Text = SID;
                string Mark = keys[5].ToString();//获取FlowName
                FlowName.Text = Mark;
                Sort.Text = keys[2].ToString();
                #region 报废判断
                if (Mark == "资产处置-报废")
                {
                    int sort = Convert.ToInt32(keys[2]);
                    Sort.Text = sort.ToString();
                    if (sort == 2)
                    {
                        //Button14.Hidden = true;
                        //Button6.Hidden = false;
                    }
                    else
                    {
                        Button2.Hidden = true;
                    }

                    if (keys[11] == null)
                    {
                        原因说明_bfckxq.Text = "";
                    }
                    else
                    {
                        原因说明_bfckxq.Text = keys[11].ToString();
                    }

                    分管领导_bfckxq.Text = keys[25].ToString();
                    分管领导处理意见_bfckxq.Text = keys[24].ToString();
                    分管领导操作时间_bfckxq.Text = keys[26].ToString();
                    电话_bfckxq.Text = keys[13].ToString();
 
                    职务_bfckxq.Text = keys[13].ToString();
                    事项名称_bfckxq.Text = keys[17].ToString();
                    主管部门_bfckxq.Text = keys[29].ToString();
                    主管部门处理意见_bfckxq.Text = keys[27].ToString();

                    主管部门操作时间_bfckxq.Text = keys[28].ToString();
                    财政部门意见_bfckxq.Text = keys[30].ToString();
                    财政部门_bfckxq.Text = keys[31].ToString();
                    财政部门操作时间_bfckxq.Text = keys[32].ToString();

                    if (职务 == "分管领导" && sort == 1)
                    {
                        Button15.Hidden = false;

                    }
                    else if (职务 == "主管部门" && sort == 2)
                    {
                        Button15.Hidden = false;
                    }
                    else if (职务 == "财务人员" && sort == 3)
                    {
                        Button15.Hidden = false;
                    }
                    else if (sort == 0)
                    {
                        Button15.Hidden = true;
                    }
                    else
                    {
                        Button15.Hidden = false;
                    }

                    流程状态_abfckxq.Text = keys[3].ToString();
                    单据编号_bfckxq.Text = keys[4].ToString();
                    float 总数 = 0.0f;
                    float 总价 = 0.0f;
                    总数 = float.Parse(keys[6].ToString());
                    总价 = float.Parse(keys[7].ToString());                
                    申报日期_ckxq.Text = keys[8].ToString();
                    申报单位_bfckxq.Text = keys[9].ToString();
                    申请人_bfckxq.Text = keys[10].ToString();
                    List<School办公设备信息表> listdata = bll.处置申报查询(SID, keys[5].ToString());

                    Grid7.DataSource = listdata;
                    Grid7.DataBind();

                    Grid8.DataSource = listdata;
                    Grid8.DataBind();
                    JObject summary = new JObject();
                    summary.Add("major", "全部合计");
                    summary.Add("数量_bfckxq", 总数.ToString("F2"));
                    summary.Add("价格_bfckxq", 总价.ToString("F2"));
                    Grid7.SummaryData = summary;
                    Grid8.SummaryData = summary;
                    Window4.Hidden = false;
                    string zcid = keys[1].ToString();
                    资产ID.Text = zcid;
                }
                #endregion
                #region 调拨
                else if (Mark == "资产处置-调拨")
                {
                    /*
                     *ID（0）,SID（1）,Sort（2）,流程状态（3）,单据编号（4）,FlowName（5）,总数（6）,总价（7）,申报日期（8）,申报单位（9）,申请人（10）
                     * ,原因说明（11）,职务（12）,电话（13）,验收日期（14）,调入单位（15）,调出单位（16）,事项名称（17）
                     * ,调出单位分管领导意见（18）,调出单位分管领导（19）,调出单位分管领导处理时间（20）,调入单位管理员意见（21）,调入单位管理员（22）
                     * ,调入单位管理员处理时间（23）,调入单位分管领导意见（24）,调入单位分管领导（25）,调入单位分管领导处理时间（26）,主管部门意见（27）
                     * ,主管部门处理时间（28）,主管部门（29）,财政部门意见（30）,财政部门（31）,财政部门处理时间（32）
                     */
                    Window5.Hidden = false;
                    int sort = Convert.ToInt32(keys[2]);
                    btntanchuang.Text = "处理";
                    btntanchuang.Enabled = false;
                    if (sort == 1)
                    {
                        //分管领导处理
                        if (职务 == "分管领导")
                        {
                            btntanchuang.Text = "分管领导处理";
                            btntanchuang.Enabled = true;
                        }
                    }
                    else if (sort == 2)
                    {
                        //资产管理员处理
                        if (职务 == "资产管理员")
                        {
                            btntanchuang.Text = "资产管理员处理";
                            btntanchuang.Enabled = true;
                        }
                    }
                    //调入单位分管领导
                    else if (sort == 3)
                    {
                        if (职务 == "分管领导")
                        {
                            btntanchuang.Text = "分管领导处理";
                            btntanchuang.Enabled = true;
                        }
                    }
                    else if (sort == 4)
                    {
                        if (职务 == "主管部门")
                        {
                            btntanchuang.Text = "主管部门处理";
                            btntanchuang.Enabled = true;
                        }
                    }else if (sort==5)
                    {
                        if(职务== "财务人员")
                        {
                            btntanchuang.Text = "财政部门处理";
                            btntanchuang.Enabled = true;
                        }
                    }
                    else if (sort == 6)
                    {
                        //string aID = Session["ID"].ToString();
                        //int zcczID = Convert.ToInt32(Session["UserID"].ToString());
                        //string fname = sbspbll.资产处置调出单位(zcczID);
                        if (职务 == "资产管理员" && keys[10].ToString()== username)
                        {
                            btntanchuang.Text = "资产管理员处理";
                            btntanchuang.Enabled = true;
                        }
                    }
                    else if (sort == 7)
                    {
                        //string aID = Session["ID"].ToString();
                        //int zcczID = Convert.ToInt32(Session["UserID"].ToString());
                        //string fname = sbspbll.资产处置调入单位(zcczID);
                        if (职务 == "资产管理员" && keys[22].ToString() == username)
                        {
                            btntanchuang.Text = "资产管理员处理";
                            btntanchuang.Enabled = true;
                        }
                    }else if (sort == 0)
                    {
                        btntanchuang.Hidden = true;
                    }



                    else
                    {
                        Button2.Hidden = true;
                    }
                    /*
                        ID（0）,SID（1）,Sort（2）,流程状态（3）,单据编号（4）,FlowName（5）,总数（6）,总价（7）,申报日期（8）,申报单位（9）,申请人（10）
                     * ,原因说明（11）,职务（12）,电话（13）,验收日期（14）,调入单位（15）,调出单位（16）,事项名称（17）
                     * ,调出单位分管领导意见（18）,调出单位分管领导（19）,调出单位分管领导处理时间（20）,调入单位管理员意见（21）,调入单位管理员（22）
                     * ,调入单位管理员处理时间（23）,调入单位分管领导意见（24）,调入单位分管领导（25）,调入单位分管领导处理时间（26）,主管部门意见（27）
                     * ,主管部门处理时间（28）,主管部门（29）,财政部门意见（30）,财政部门（31）,财政部门处理时间（32）
                     */

                    流程状态_dbckxq.Text = keys[3].ToString();
                    单据编号_dbckxq.Text = keys[4].ToString();
                    int 总数 = 0;
                    int 总价 = 0;
                    总数 = Convert.ToInt32(keys[6].ToString());
                    总价 = Convert.ToInt32(keys[7].ToString());
                    申报日期_dbckxq.Text = keys[8].ToString();
                    申请人_dbckxq.Text = keys[10].ToString();
                    调拨原因说明.Text = keys[11].ToString();
                    职务_dbckxq.Text = keys[12].ToString();
                    电话_dbckxq.Text = keys[13].ToString();
                    验收日期_dbckxq.Text = keys[14].ToString();
                    调入单位_dbckxq.Text = keys[15].ToString();
                    调出单位_dbckxq.Text = keys[16].ToString();
                    事项名称_dbckxq.Text = keys[17].ToString();

                    调出单位分管领导意见.Text = keys[18].ToString();
                    调出单位分管领导.Text = keys[19].ToString();
                    调出单位分管领导处理时间.Text = keys[20].ToString();

                    调入单位管理员意见.Text = keys[21].ToString();
                    调入单位管理员.Text = keys[22].ToString();
                    调入单位管理员处理时间.Text = keys[23].ToString();

                    调入单位分管领导意见.Text = keys[24].ToString();
                    调入单位分管领导.Text = keys[25].ToString();
                    调入单位分管领导处理时间.Text = keys[26].ToString();

                    调拨主管部门意见.Text = keys[27].ToString();
                    主管部门处理时间.Text = keys[28].ToString();
                    主管部门.Text = keys[29].ToString();

                    调拨财政部门意见.Text = keys[30].ToString();
                    财政部门.Text = keys[31].ToString();
                    财政部门处理时间.Text = keys[32].ToString();



                    List<School办公设备信息表> listdata = bll.处置申报查询(SID, keys[5].ToString());
                    Grid9.DataSource = listdata;
                    Grid9.DataBind();
                    Grid10.DataSource = listdata;
                    Grid10.DataBind();
                    JObject summary = new JObject();
                    summary.Add("major", "全部合计");
                    summary.Add("数量_db", 总数.ToString("F2"));
                    summary.Add("价格_db", 总价.ToString("F2"));
                    Grid9.SummaryData = summary;
                    Grid10.SummaryData = summary;

                }
                #endregion

            }

        }


        protected string GetEditUrls(object ID,object Mark, object ReceiptNumber, object sort,object SID)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("事项名称", "事项名称" + ReceiptNumber);
            joBuilder.AddProperty("title", "流程进度 - " + ReceiptNumber);
            string flowname = Mark.ToString();
            if (flowname == "资产处置-报废")
            {
                joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("School处置申报资产报废流程进度.aspx?SBBH={0}&sort={1}&ID={2}&SID={3}", ReceiptNumber, HttpUtility.UrlEncode(sort.ToString()),ID,SID)));
            }
            else if (flowname == "资产处置-调拨")
            {
                joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("School处置申报资产调拨流程进度.aspx?SBBH={0}&sort={1}&ID={2}&SID={3}", ReceiptNumber, HttpUtility.UrlEncode(sort.ToString()), ID, SID)));
            }
            //joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("School购置验收流程进度.aspx?SBBH={0}&sort={1}", id, HttpUtility.UrlEncode(sort.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            Window4.Hidden = true;
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

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "处置单")
            {
                Grid9.Hidden = false;
                Grid10.Hidden = true;
            }
            else
            {
                Grid9.Hidden = true;
                Grid10.Hidden = false;
            }
        }



       

        //调拨处理
        protected void ZCCLSPYES_Click(object sender, EventArgs e)
        {
            string processingtime = DateTime.Now.ToShortDateString();//处理时间
            string username = Session["姓名"].ToString();//处理人
            int flowid = Convert.ToInt32(FlowID.Text);
            string 职务 = Session["职务"].ToString();
            SchoolX_资产处置流程表 model = new SchoolX_资产处置流程表();
            if (FlowName.Text == "资产处置-调拨")
            {
                if (Sort.Text == "1")
                {
                    model.调出单位分管领导意见 = 处理意见.Text;
                    if (model.调出单位分管领导意见 == "" || model.调出单位分管领导意见 == null)
                    {
                        model.调出单位分管领导意见 = "同意";
                    }
                    model.调出单位分管领导 = username;
                    model.调出单位分管领导处理时间 = processingtime;
                    model.FlowName = FlowName.Text;
                    model.Sort = 2; 
                    model.ID = flowid;
                    model.流程状态 = "等待调入单位管理员处理";
                    if (bll.调拨流程处理(model) > 0)
                    {
                        Alert.ShowInTop("审批成功！", "提示信息", MessageBoxIcon.Information);
                        Window5.Hidden = true;
                        审批处理界面.Hidden = true;
                        BindGrid();
                    }
                    else
                    {
                        Alert.ShowInTop("操作失败，请联系管理员！", "提示信息", MessageBoxIcon.Information);
                    }
                }
                else if (Sort.Text == "2")
                {
                    model.调入单位管理员意见 = 处理意见.Text;
                    if (model.调入单位管理员意见 == "" || model.调入单位管理员意见 == null)
                    {
                        model.调入单位管理员意见 = "同意";
                    }
                    model.调入单位管理员 = username;
                    model.调入单位管理员处理时间 = processingtime;
                    model.FlowName = FlowName.Text;
                    model.Sort = 3;
                    model.ID = flowid;
                    model.流程状态 = "等待调入单位分管领导处理";
                    if (bll.调拨流程处理(model) > 0)
                    {
                        Alert.ShowInTop("审批成功！", "提示信息", MessageBoxIcon.Information);
                        Window5.Hidden = true;
                        审批处理界面.Hidden = true;
                        BindGrid();
                    }
                    else
                    {
                        Alert.ShowInTop("操作失败，请联系管理员！", "提示信息", MessageBoxIcon.Information);
                    }
                }
                else if (Sort.Text == "3")
                {
                    model.调入单位分管领导意见 = 处理意见.Text;
                    if (model.调入单位分管领导意见 == "" || model.调入单位分管领导意见 == null)
                    {
                        model.调入单位分管领导意见 = "同意";
                    }
                    model.调入单位分管领导 = username;
                    model.调入单位分管领导处理时间 = processingtime;
                    model.FlowName = FlowName.Text;
                    model.Sort = 4;
                    model.ID = flowid;
                    model.流程状态 = "等待主管部门处理";
                    if (bll.调拨流程处理(model) > 0)
                    {
                        Alert.ShowInTop("审批成功！", "提示信息", MessageBoxIcon.Information);
                        Window5.Hidden = true;
                        审批处理界面.Hidden = true;
                        BindGrid();
                    }
                    else
                    {
                        Alert.ShowInTop("操作失败，请联系管理员！", "提示信息", MessageBoxIcon.Information);
                    }
                }
                else if (Sort.Text == "4")
                {
                    model.主管部门意见 = 处理意见.Text;
                    if (model.主管部门意见 == "" || model.主管部门意见 == null)
                    {
                        model.主管部门意见 = "同意";
                    }
                    model.主管部门 = username;
                    model.主管部门处理时间 = processingtime;
                    model.FlowName = FlowName.Text;
                    model.Sort = 5;
                    model.ID = flowid;
                    model.流程状态 = "等待财政部门处理";
                    if (bll.调拨流程处理(model) > 0)
                    {
                        Alert.ShowInTop("审批成功！", "提示信息", MessageBoxIcon.Information);
                        Window5.Hidden = true;
                        审批处理界面.Hidden = true;
                        BindGrid();
                    }
                    else
                    {
                        Alert.ShowInTop("操作失败，请联系管理员！", "提示信息", MessageBoxIcon.Information);
                    }

                }
                else if (Sort.Text == "5")
                {
                    model.财政部门意见 = 处理意见.Text;
                    if (model.财政部门意见 == "" || model.财政部门意见 == null)
                    {
                        model.财政部门意见 = "同意";
                    }
                    model.财政部门 = username;
                    model.财政部门处理时间 = processingtime;
                    model.FlowName = FlowName.Text;
                    model.Sort = 6;
                    model.ID = flowid;
                    model.流程状态 = "等待调出单位管理员处理";
                    if (bll.调拨流程处理(model) > 0)
                    {
                        Alert.ShowInTop("审批成功！", "提示信息", MessageBoxIcon.Information);
                        Window5.Hidden = true;
                        审批处理界面.Hidden = true;
                        BindGrid();
                    }
                    else
                    {
                        Alert.ShowInTop("操作失败，请联系管理员！", "提示信息", MessageBoxIcon.Information);
                    }

                }

                else if (Sort.Text == "6")
                {
                    string dcname = bll.资产处置调拨调出单位管理员姓名(Convert.ToInt32(flowid));
                    if (dcname == username)
                    {
                        //model.财政部门意见 = 处理意见.Text;
                        //if (model.财政部门意见 == "" || model.财政部门意见 == null)
                        //{
                        //    model.财政部门意见 = "同意";
                        //}
                        model.调出单位管理员 = username;
                        model.调出单位管理员处理时间 = processingtime;
                        model.FlowName = FlowName.Text;
                        model.Sort = 7;
                        model.ID = flowid;
                        model.流程状态 = "等待调入单位管理员处理";
                        if (bll.调拨流程处理(model) > 0)
                        {
                            Alert.ShowInTop("审批成功！", "提示信息", MessageBoxIcon.Information);
                            Window5.Hidden = true;
                            审批处理界面.Hidden = true;
                            BindGrid();
                            return;
                        }
                        else
                        {
                            Alert.ShowInTop("操作失败，请联系管理员！", "提示信息", MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        Alert.ShowInTop("你没有权限！", "提示信息", MessageBoxIcon.Information);
                    }
                    

                }

                else if (Sort.Text == "7")
                {
                    string dcname = bll.资产处置调拨调入单位管理员姓名(Convert.ToInt32(flowid));
                    if (dcname== username)
                    {
                        model.调入单位管理员确认 = username;
                        model.调入单位管理员确认处理时间 = processingtime;
                        model.FlowName = FlowName.Text;
                        model.Sort = 0;
                        model.ID = flowid;
                        model.流程状态 = "完成";
                        if (bll.调拨流程处理(model) > 0)
                        {
                            Alert.ShowInTop("审批成功！", "提示信息", MessageBoxIcon.Information);
                            Window5.Hidden = true;
                            审批处理界面.Hidden = true;
                            BindGrid();
                        }
                        else
                        {
                            Alert.ShowInTop("操作失败，请联系管理员！", "提示信息", MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        Alert.ShowInTop("你没有权限！", "提示信息", MessageBoxIcon.Information);
                    }
                    

                }
            }
            #region
            else if (FlowName.Text == "资产处置-报废") 
            {
                if (职务 == "分管领导" && Sort.Text == "1")
                {
                    model.ID = flowid;
                    model.SID = 资产ID.Text;
                    model.调入单位分管领导处理时间 = processingtime;
                    if (处理意见.Text== "")
                    {
                        model.调入单位分管领导意见 = "同意";
                    }
                    else
                    {
                        model.调入单位分管领导意见 = 处理意见.Text;
                    }
                   
                    model.调入单位分管领导 = username;
                    model.Sort = 1;
                    //model.原因说明 = 原因说明_bfckxq.Text;
                    model.职务 = 职务;

                    if (bll.处置申报报废处理流程(model) > 0)
                    {
                        审批处理界面.Hidden = true;
                        Alert alert = new Alert();
                        alert.Message = "处理成功";
                        alert.Title = "提示信息";
                        alert.MessageBoxIcon = MessageBoxIcon.Success;
                        alert.Show();
                        Window4.Hidden = true;
                        BindGrid();
                        return;
                    }
                    else
                    {
                        审批处理界面.Hidden = true;
                        Alert alert = new Alert();
                        alert.Message = "处理失败";
                        alert.Title = "提示信息";
                        alert.MessageBoxIcon = MessageBoxIcon.Error;
                        alert.Show();
                        return;
                    }
                }

                else if (职务 == "主管部门" && Sort.Text == "2")
                {
                    
                    model.主管部门处理时间 = processingtime;
                    model.主管部门意见 = "通过";
                    if (处理意见.Text == "")
                    {
                        model.主管部门意见 = "同意";
                    }
                    else
                    {
                        model.主管部门意见 = 处理意见.Text;
                    }

                    model.主管部门 = username;
                    model.职务 = 职务;
                    model.ID = flowid;
                    model.Sort = 2;



                    if (bll.处置申报报废处理流程(model) > 0)
                    {
                        审批处理界面.Hidden = true;
                        Alert alert = new Alert();
                        alert.Message = "处理成功";
                        alert.Title = "提示信息";
                        alert.MessageBoxIcon = MessageBoxIcon.Success;
                        alert.Show();
                        Window4.Hidden = true;
                        BindGrid();
                        return;
                    }
                    else
                    {
                        审批处理界面.Hidden = true;
                        Alert alert = new Alert();
                        alert.Message = "处理失败";
                        alert.Title = "提示信息";
                        alert.MessageBoxIcon = MessageBoxIcon.Error;
                        alert.Show();
                        return;
                    }
                    //财务部门
                }
                else if (职务 == "财务人员" && Sort.Text == "3")
                {
                    ZCCLSPYES.Text = "财务人员同意";
                    model.财政部门处理时间 = processingtime;
                    model.ID = flowid;
                    if (处理意见.Text == "")
                    {
                        model.财政部门意见 = "同意";
                    }
                    else
                    {
                        model.财政部门意见 = 处理意见.Text;
                    }
                    
                    model.Sort = 3;
                    model.财政部门 = username;

                    if (bll.处置申报报废处理流程(model) > 0)
                    {
                        审批处理界面.Hidden = true;
                        Alert alert = new Alert();
                        alert.Message = "处理成功";
                        alert.Title = "提示信息";
                        alert.MessageBoxIcon = MessageBoxIcon.Success;
                        alert.Show();
                        Window4.Hidden = true;
                        BindGrid();
                        return;
                    }
                    else
                    {
                        审批处理界面.Hidden = true;
                        Alert alert = new Alert();
                        alert.Message = "处理失败";
                        alert.Title = "提示信息";
                        alert.MessageBoxIcon = MessageBoxIcon.Error;
                        alert.Show();
                        return;
                    }
                }
            }
            #endregion
        }

        protected void ZCCLSPNO_Click(object sender, EventArgs e)
        {

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
            Window2.Hidden = true;
        }


        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList3.SelectedValue == "处置单")
            {
                Grid7.Hidden = false;
                Grid8.Hidden = true;
            }
            else
            {
                Grid7.Hidden = true;
                Grid8.Hidden = false;
            }
        }

        protected void Button16_Click1(object sender, EventArgs e)
        {
            Window4.Hidden = true;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Window1.Hidden = true;
        }

        protected void btnzcczdbno_Click(object sender, EventArgs e)
        {
            Window5.Hidden = true;
        }
    }
}