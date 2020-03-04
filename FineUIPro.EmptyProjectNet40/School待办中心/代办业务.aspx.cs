
using System;
using PLM.BusinessRlues;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PLM_BusinessRlues;
using PLM_Model;
using MvcGuestBook.Common;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;
using System.Text;
using Newtonsoft.Json.Linq;

namespace FineUIPro.EmptyProjectNet40.School代办中心
{
    public partial class 代办业务 : PageBase
    {
        School待办业务BLL bll = new School待办业务BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DateTime dtime = DateTime.Now;
                string sj = dtime.Year + "-" + dtime.Month + "-" + dtime.Day;
                DatePicker1.EmptyText = sj;
                完成时间.EmptyText = sj;
                DatePicker2.EmptyText = sj;
                bindd();
                selectedBind();
                
            }
        }
        private void selectedBind()
        {
            List<string> list = bll.查询全部事项名称();
    
            OffSession();
            
            string zw = HttpContext.Current.Session["职务"].ToString();
            string rm = HttpContext.Current.Session["姓名"].ToString();
            foreach (string item in list)
            {
                int xx=bll.事项拥有的数量(item, rm, zw);
                //事项名称.Items.Add(item+ " <span style='color:red;font-weight:bold;'>(" + xx + ")</span>", item);
                事项名称.Items.Add(item + "("+xx+ ")" , item);
            }
            事项名称.Items.Insert(0, new FineUIPro.ListItem("全部消息", "全部消息"));
        }
        private void bindd()
        {
            OffSession();
            string zw = HttpContext.Current.Session["职务"].ToString();
            string xm = HttpContext.Current.Session["姓名"].ToString();           
            int xx = bll.总数(xm,zw);
            YOU.Text = "您当前共有" + " <span style='color:red;font-weight:bold;'>" + xx + "</span> " + "项待处理业务";
            DataSet ds = bll.职务条件(xm, zw);
            DataTable dt = ds.Tables[0];
            Grid1.DataSource = dt;
            Grid1.DataBind();
            
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
        protected void Unnamed_SelectedIndexChanged(object sender, EventArgs e)
        {
            OffSession();
            string zw = HttpContext.Current.Session["职务"].ToString();
            string xm = HttpContext.Current.Session["姓名"].ToString();
            if (Unnamed.SelectedValue == "待我处理")
            {
                Grid1.Hidden = false;
                Grid4.Hidden = true;
                事项名称.Items.Clear();
                bindd();
                selectedBind();
            }
            else if (Unnamed.SelectedValue == "我发起的")
            {
                Grid1.Hidden = true;
                Grid4.Hidden = false;
                int a = bll.总数我处理(xm);
                int xx = bll.我发起的数量(xm);
                事项名称.Items.Clear();
                YOU.Text = "您当前共有" + " <span style='color:red;font-weight:bold;'>" + xx + "</span> " + "项您发起的业务";
                DataSet ds = bll.查询我发起的(xm);
                DataTable dt = ds.Tables[0];
                Grid4.DataSource = dt;
                Grid4.DataBind();
                List<string> list = bll.查询全部事项名称();
                foreach (string item in list)
                {
                    int shuliang = bll.我发起的事项数量(xm, item);
                    事项名称.Items.Add(item + " (" + shuliang + ")", item);
                }
                事项名称.Items.Insert(0, new FineUIPro.ListItem("全部消息", "全部消息"));
            }
        }
        protected void 事项名称_SelectedIndexChanged(object sender, EventArgs e)
        {
            string 事项 = 事项名称.SelectedValue;

            // 事项名称.SelectedText = 事项;
            OffSession();
            string zw = HttpContext.Current.Session["职务"].ToString();
            string xm = HttpContext.Current.Session["姓名"].ToString();

            if (Unnamed.SelectedValue == "待我处理")
            {
                if (事项 == "全部消息")
                {
                    bindd();
                }
                else
                {
                    DataSet ds = bll.待我处理事项查询(xm, zw, 事项);
                    DataTable dt = ds.Tables[0];
                    Grid1.DataSource = dt;
                    Grid1.DataBind();
                }


            }
            else if (Unnamed.SelectedValue == "我发起的")
            {
                Grid1.Hidden = true;
                Grid4.Hidden = false;
                if (事项 == "全部消息")
                {
                    DataSet ds = bll.查询我发起的(xm);
                    DataTable dt = ds.Tables[0];
                    Grid4.DataSource = dt;
                    Grid4.DataBind();
                }
                else
                {
                    DataSet ds = bll.我发起的事项查询(xm, 事项);
                    DataTable dt = ds.Tables[0];
                    Grid4.DataSource = dt;
                    Grid4.DataBind();
                }
            }

        }
        //protected void Unnamed_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    List<AM_待办业务> list = bll.分类();
        //    string a = "";
        //    if (Tree1.SelectedNode == null)
        //    {

        //        foreach (AM_待办业务 row in list)
        //        {
        //            a = row.事项名称;
        //            break;
        //        }
        //    }
        //    else
        //    {
        //        a = Tree1.SelectedNode.Text.Substring(0, Tree1.SelectedNode.Text.IndexOf("<"));
        //    }

        //    if (Unnamed.SelectedValue == "待我处理")
        //    {
        //        string zw = HttpContext.Current.Session["职务"].ToString();
        //        int xx = bll.总数(zw);

        //        YOU.Text = "您当前共有" + " <span style='color:red;font-weight:bold;'>" + xx + "</span> " + "项待处理业务";
        //        DataSet ds = bll.职务条件(zw, a);
        //        DataTable dt = ds.Tables[0];
        //        Grid1.DataSource = dt;
        //        Grid1.DataBind();
        //        List<AM_待办业务> lista = bll.分类();
        //        Tree1.Nodes.Clear();
        //        foreach (AM_待办业务 row in list)
        //        {
        //            if (row.事项名称 != "" && row.事项名称 != null)
        //            {
        //                TreeNode node = new TreeNode();
        //                node.IconUrl = @"~/res/icon/asterisk_orange.png";
        //                string aa = row.事项名称;
        //                int ss = bll.C数量(aa, zw);
        //                node.Text = aa + "<span style='color:red;font-weight:bold;'>(" + ss + ")</span>";
        //                //node.NodeID = row.ID.ToString();
        //                Tree1.Nodes.Add(node);
        //                node.EnableClickEvent = true;
        //            }
        //        }
        //    }
        //    if (Unnamed.SelectedValue == "我发起的")
        //    {
        //        string nm = HttpContext.Current.Session["姓名"].ToString();
        //        int xx = bll.总数我处理(nm);
        //        YOU.Text = "您当前共有" + " <span style='color:red;font-weight:bold;'>" + xx + "</span> " + "项我发起的";
        //        DataSet ds = bll.发起人条件(nm, a);
        //        DataTable dt = ds.Tables[0];
        //        Grid1.DataSource = dt;
        //        Grid1.DataBind();
        //        List<AM_待办业务> lista = bll.分类();
        //        Tree1.Nodes.Clear();
        //        foreach (AM_待办业务 row in list)
        //        {

        //            if (row.事项名称 != "" && row.事项名称 != null)
        //            {

        //                TreeNode node = new TreeNode();
        //                node.IconUrl = @"~/res/icon/asterisk_orange.png";
        //                string aa = row.事项名称;
        //                string zw = HttpContext.Current.Session["姓名"].ToString();
        //                int ss = bll.R数量(aa, zw);
        //                node.Text = aa + "<span style='color:red;font-weight:bold;'>(" + ss + ")</span>";

        //                //node.NodeID = row.ID.ToString();
        //                Tree1.Nodes.Add(node);
        //                node.EnableClickEvent = true;
        //            }
        //        }
        //    }
        //}
        //private void LoadData()
        //{
        //    List<AM_待办业务> list = bll.分类();

        //    foreach (AM_待办业务 row in list)
        //    {
        //        if (row.事项名称 != "" && row.事项名称 != null)
        //        {
        //            TreeNode node = new TreeNode();
        //            node.IconUrl = @"~/res/icon/asterisk_orange.png";
        //            string xx = row.事项名称;
        //            string zw = HttpContext.Current.Session["职务"].ToString();
        //            int ss = bll.C数量(xx, zw);
        //            node.Text = xx + "<span style='color:red;font-weight:bold;'>(" + ss + ")</span>";

        //            //node.NodeID = row.ID.ToString();
        //            Tree1.Nodes.Add(node);
        //            node.EnableClickEvent = true;

        //        }
        //    }
        //}

        protected void Tree1_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            string nodetext = e.Node.Text.Substring(0, e.Node.Text.IndexOf("<"));
            string id;


            string z = Unnamed.SelectedValue;
            if (z == "待我处理")
            {
                OffSession();
                string zw = HttpContext.Current.Session["职务"].ToString();
                string xm = HttpContext.Current.Session["姓名"].ToString();
                int xx = bll.总数(xm, zw);
                YOU.Text = "您当前共有" + " <span style='color:red;font-weight:bold;'>" + xx + "</span> " + "项待处理业务";
                if (nodetext.Length > 0)
                {
                    id = nodetext.ToString();
                    Grid1.DataSource = bll.职务条件(zw, nodetext);//职务，发布人，事项名称
                    Grid1.DataBind();
                }

            }
            if (z == "我发起的")
            {
                string nm = HttpContext.Current.Session["姓名"].ToString();
                int xx = bll.总数我处理(nm);
                YOU.Text = "您当前共有" + " <span style='color:red;font-weight:bold;'>" + xx + "</span> " + "项我发起的";
                if (nodetext.Length > 0)
                {
                    id = nodetext.ToString();
                    Grid1.DataSource = bll.查事项名称(id, nm);
                    Grid1.DataBind();
                }
            }
        }
        protected void 查看图片_Click(object sender, EventArgs e)
        {

            if (Image2.ImageUrl == "" || Image2.ImageUrl == null)
            {
                Alert.ShowInTop("照片未上传！");
                return;
            }
            else
            {
                查看图片3.Hidden = false;
            }

        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                string 事项名称 = Grid1.SelectedRow.DataKeys[3].ToString();
                int 待办ID = Convert.ToInt32(Grid1.SelectedRow.DataKeys[0]);
                string 流程状态 = Grid1.SelectedRow.DataKeys[1].ToString();
                FlowID.Text = Grid1.SelectedRow.DataKeys[2].ToString(); 
                FlowName.Text= Grid1.SelectedRow.DataKeys[3].ToString();
                if (事项名称 == "资产报修")
                {
                    School待办业务BLL bll = new School待办业务BLL();
                    SchoolX_资产报修流程表 model = bll.获取报修信息(待办ID);
                    查看报修人.Text = model.报修人;
                    查看报修时间.Text = model.报修时间;
                    查看单号.Text = model.报修单号;
                    查看报修地址.Text = model.报修地址;
                    查看维修人员.Text = model.维修人员;
                    查看解决时间.Text = model.解决时间;
                    查看管理员.Text = model.管理员;
                    查看派单时间.Text = model.派单时间;
                    查看报修人电话.Text = model.报修人电话;
                    查看维修人电话.Text = model.维修人电话;
                    查看管理员电话.Text = model.管理员电话;
                    查看故障描述.Text = model.故障描述;
                    查看结果反馈.Text = model.结果反馈;
                    Image2.ImageUrl = model.故障照片;
                    if (流程状态 == "待派单")
                    {
                        Button9.Text = "提交派单";
                    }
                    else if (流程状态 == "派单中")
                    {
                        Button9.Text = "提交维修";
                    }
                    else if (流程状态 == "维修完成")
                    {
                        Button9.Text = "完成提交";
                    }
                    else if (流程状态 == "已完成")
                    {
                        Button9.Hidden = true;
                    }

                    string 设备id = model.设备ID;
                    List<int> inlist = new List<int>();
                    string[] sbid = 设备id.Split(',');
                    foreach (string item in sbid)
                    {
                        if (item == "" || item == null)
                        {
                            break;
                        }
                        inlist.Add(Convert.ToInt32(item));
                    }
                    School资产报修BLL blla = new School资产报修BLL();
                    List<School办公设备信息表> listdata = blla.资产转移确定设备(inlist);
                    Grid3.DataSource = listdata;//DataTable
                    Grid3.DataBind();

                    流程状态待派单.Hidden = false;

                }
                else if (事项名称 == "资产交接")
                {
                    School资产借还交接BLL bll = new School资产借还交接BLL();
                    待办ID = Convert.ToInt32(Grid1.SelectedRow.DataKeys[0]);
                    AM_资产交接流程表 model = bll.资产交接查看详情(待办ID);

                    查看流程状态.Text = model.流程状态;


                    查看单据编号.Text = model.单据编号;
                    查看交付人.Text = model.交付人;
                    查看接收人.Text = model.接收人;
                    查看提交时间.Text = model.提交时间;
                    查看完成时间.Text = model.完成时间;
                    查看备注信息.Text = model.备注信息;

                    string zcid = model.资产ID;
                    FlowID.Text = model.ID.ToString();
                    资产ID.Text = zcid;

                    int sort = model.Sort;
                    if (sort == 2)
                    {
                        btnok.Text = "确认通过";
                    }
                    else if (sort == 1)
                    {
                        btnok.Text = "确认接收";
                    }
                    Grid2.DataSource = bll.资产借还查看详情(zcid);
                    Grid2.DataBind();

                    Window3.Hidden = false;
                }
                else if (事项名称 == "资产借还")
                {
                    OffSession();
                    string username = Session["姓名"].ToString();
                    待办ID = Convert.ToInt32(Grid1.SelectedRow.DataKeys[0]);
                    School资产借还交接BLL bll = new School资产借还交接BLL();
                    AM_资产借还流程表 model = bll.资产借还查看详情(待办ID);
                    TextBox6.Text = model.单据编号;
                    查看借用人.Text = model.借用人;
                    查看借出人.Text = model.借出人;
                    TextBox5.Text = model.流程状态;
                    DatePicker3.Text = model.提交时间;
                    TextBox8.Text = model.备注信息;
                    TextBox9.Text = model.ID.ToString();
                    int Sort = model.Sort;
                    if (username == 查看借出人.Text && Sort == 1)
                    {
                        Button1.Text = "同意借出";
                        Button2.Text = "拒绝借出";
                    }
                    else if (Sort == 2 && 查看借用人.Text == username)
                    {
                        Button1.Text = "确认归还";
                        Button2.Text = "关闭";
                    }
                    else if (Sort == 3 && 查看借出人.Text == username)
                    {
                        Button1.Text = "已归还";
                        Button2.Text = "未归还";
                    }
                    else
                    {
                        Button1.Hidden = true;
                        Button2.Text = "关闭";
                    }

                    查看借用时间.Text = model.借用时间;
                    查看预计归还时间.Text = model.预计归还时间;
                    查看备注信息.Text = model.备注信息;

                    string zcid = model.资产ID;
                    资产ID.Text = zcid;

                    Grid5.DataSource = bll.资产借还查看详情(zcid);
                    Grid5.DataBind();

                    Window1.Hidden = false;
                }
                else if (事项名称 == "资产处置-报废")
                {
                    OffSession();
                    School流程进度查看详情BLL bll = new School流程进度查看详情BLL();
                    string 职务 = Session["职务"].ToString();
                    //string FlowID = Request.QueryString["FlowID"];
                    string FlowID = Grid1.SelectedRow.DataKeys[2].ToString();
                    int sort = Convert.ToInt32(Grid1.SelectedRow.DataKeys[9].ToString());
                    Sort.Text = sort.ToString();
                    //if (FlowID != "" && FlowID != null)
                    //{
                    //    ID = FlowID;
                    //}
                    //else
                    //{
                    //    ID = Request.QueryString["ID"];
                    //}



                    //string ID = Request.QueryString["ID"];
                    string ID = FlowID;
                    //string SID = Request.QueryString["SID"];
                    待我处理资产处置_报废.Hidden = false;
                    string SID = bll.资产处置SID(Convert.ToInt32(FlowID));
                    List<流程进度查看详情表> listdatas = bll.资产处置待报废查看详情(ID, SID);


                    流程状态db.Text = listdatas[0].流程状态.ToString();
                    单据编号db.Text = listdatas[0].单据编号.ToString();
                    float 总数 = 0.0f;
                    float 总价 = 0.0f;
                    总数 = float.Parse(listdatas[0].总数.ToString());
                    总价 = float.Parse(listdatas[0].总价.ToString());
                    分管领导dbfg.Text = listdatas[0].调入单位分管领导.ToString();
                    处理意见dbfg.Text = listdatas[0].调入单位分管领导意见.ToString();
                    操作时间dbfg.Text = listdatas[0].调入单位分管领导处理时间.ToString();
                    电话db.Text = listdatas[0].电话.ToString();

                    职务db.Text = listdatas[0].职务.ToString();
                    事项名称db.Text = listdatas[0].事项名称.ToString();
                    操作人dbzg.Text = listdatas[0].主管部门.ToString();
                    处理意见dbzg.Text = listdatas[0].主管部门意见.ToString();

                    操作时间dbzg.Text = listdatas[0].主管部门处理时间.ToString();
                    处理意见dbcz.Text = listdatas[0].财政部门意见.ToString();
                    操作人dbcz.Text = listdatas[0].财政部门.ToString();
                    操作时间dbcz.Text = listdatas[0].财政部门处理时间.ToString();
                    原因说明db.Text = listdatas[0].原因说明.ToString();
                    申请人db.Text = listdatas[0].申请人.ToString();
                    申报单位db.Text = listdatas[0].申报单位.ToString();
                    申报日期db.Text = listdatas[0].申报日期.ToString();
                    string FlowName = listdatas[0].FlowName.ToString();

                    School申报审批BLL sbspbll = new School申报审批BLL();
                    List<School办公设备信息表> listdata = sbspbll.处置申报查询(SID, FlowName);

                    Grid13.DataSource = listdata;
                    Grid13.DataBind();
                    Grid14.DataSource = listdata;
                    Grid14.DataBind();

                    JObject summary = new JObject();
                    summary.Add("major", "全部合计");
                    summary.Add("数量_bfxq", 总数.ToString("F2"));
                    summary.Add("价格_bfxq", 总价.ToString("F2"));
                    Grid13.SummaryData = summary;
                    Grid14.SummaryData = summary;

                    if (职务 == "分管领导" && sort == 1)
                    {
                        报废处理.Hidden = false;

                    }
                    else if (职务 == "主管部门" && sort == 2)
                    {
                        报废处理.Hidden = false;
                    }
                    else if (职务 == "财务人员" && sort == 3)
                    {
                        报废处理.Hidden = false;
                    }
                    else if (sort == 0)
                    {
                        报废处理.Hidden = true;
                    }
                    else
                    {
                        报废处理.Hidden = false;
                    }
                }
                else if (事项名称 == "资产处置-调拨")
                {
                    OffSession();
                    string 职务 = Session["职务"].ToString();
                    School流程进度查看详情BLL bll = new School流程进度查看详情BLL();
                    //string FlowID = Request.QueryString["FlowID"];
                    string FlowID = Grid1.SelectedRow.DataKeys[2].ToString();
                    int sort = Convert.ToInt32(Grid1.SelectedRow.DataKeys[9].ToString());
                    Sort.Text = sort.ToString();
                    string ID = FlowID;
                    待我处理资产处置_调拨.Hidden = false;
                    string SID = bll.资产处置SID(Convert.ToInt32(ID));
                    List<流程进度查看详情表> listdatas = bll.资产处置待报废查看详情(ID, SID);


                    流程状态ab.Text = listdatas[0].流程状态.ToString();
                    单据编号ab.Text = listdatas[0].单据编号.ToString();
                    float 总数 = 0.0f;
                    float 总价 = 0.0f;
                    总数 = float.Parse(listdatas[0].总数.ToString());
                    总价 = float.Parse(listdatas[0].总价.ToString());
                    调出单位分管领导ab.Text = listdatas[0].调出单位分管领导.ToString();
                    调出单位分管领导意见ab.Text = listdatas[0].调出单位分管领导意见.ToString();
                    调出单位分管领导处理时间ab.Text = listdatas[0].调出单位分管领导处理时间.ToString();

                    调入单位分管领导意见ab.Text = listdatas[0].调入单位分管领导意见.ToString();
                    调入单位分管领导ab.Text = listdatas[0].调入单位分管领导.ToString();
                    调入单位分管领导处理时间ab.Text = listdatas[0].调入单位分管领导处理时间.ToString();
                    调入单位管理员意见ab.Text = listdatas[0].调入单位管理员意见.ToString();
                    调入单位管理员ab.Text = listdatas[0].调入单位管理员.ToString();
                    调入单位管理员处理时间ab.Text = listdatas[0].调入单位管理员处理时间.ToString();


                    电话ab.Text = listdatas[0].电话.ToString();

                    职务ab.Text = listdatas[0].职务.ToString();
                    事项名称ab.Text = listdatas[0].事项名称.ToString();
                    主管部门ab.Text = listdatas[0].主管部门.ToString();
                    调拨主管部门意见ab.Text = listdatas[0].主管部门意见.ToString();

                    主管部门处理时间ab.Text = listdatas[0].主管部门处理时间.ToString();
                    调拨财政部门意见ab.Text = listdatas[0].财政部门意见.ToString();
                    财政部门ab.Text = listdatas[0].财政部门.ToString();
                    财政部门处理时间ab.Text = listdatas[0].财政部门处理时间.ToString();
                    //原因说明_bfckxq.Text = listdatas[0].原因说明.ToString();
                    申请人ab.Text = listdatas[0].申请人.ToString();
                    //申报单位_bfckxq.Text = listdatas[0].申报单位.ToString();
                    调出单位ab.Text = listdatas[0].调出单位.ToString();
                    调入单位ab.Text = listdatas[0].调入单位.ToString();
                    申报日期ab.Text = listdatas[0].申报日期.ToString();
                    验收日期ab.Text = listdatas[0].验收日期.ToString();

                    string FlowName = listdatas[0].FlowName.ToString();

                    School申报审批BLL sbspbll = new School申报审批BLL();
                    List<School办公设备信息表> listdata = sbspbll.处置申报查询(SID, FlowName);

                    Grid17.DataSource = listdata;
                    Grid17.DataBind();
                    Grid18.DataSource = listdata;
                    Grid18.DataBind();

                    JObject summary = new JObject();
                    summary.Add("major", "全部合计");
                    summary.Add("数量_ab", 总数.ToString("F2"));
                    summary.Add("价格_ab", 总价.ToString("F2"));
                    Grid17.SummaryData = summary;
                    Grid18.SummaryData = summary;
                }
                else if (事项名称 == "资产转移")
                {
                    OffSession();
                    string 职务 = Session["职务"].ToString();
                    int FlowID = Convert.ToInt32(Grid1.SelectedRow.DataKeys[2].ToString());
                    SchoolX_资产转移流程表 model = bll.获取资产转移信息(FlowID);
                    TextBox13.Text = model.流程状态;
                    TextBox14.Text = model.单据编号;
                    查看事项名称.Text = model.事项名称;
                    查看申请人.Text = model.申请人;
                    查看申请日期.Text = model.申请日期;
                    查看联系方式.Text = model.联系方式;
                    School资产转移BLL bllc = new School资产转移BLL();
                    DataSet ds = bllc.资产转移查看详情(FlowID);
                    DataTable dt = ds.Tables[0].Copy();//复制一份table
                    Grid6.DataSource = dt;//DataTable
                    Grid6.DataBind();
                    SchoolX_资产转移改动信息表 modela = bllc.查询变更为(FlowID);
                    查看存放地点变更为.Text = modela.现存放地点;
                    查看归属部门变更为.Text = modela.现归属部门;
                    查看负责人变更为.Text = modela.现负责人;
                    新增资产转移查看详情.Hidden = false;
                }
                else if (事项名称 == "购置验收")
                {
                    OffSession();
                    string 职务 = Session["职务"].ToString();
                    //string FlowID = Request.QueryString["FlowID"];
                    string FlowID = Grid1.SelectedRow.DataKeys[2].ToString();
                    int sort = Convert.ToInt32(Grid1.SelectedRow.DataKeys[9].ToString());
                    flowid_gzys.Text = FlowID;
                    Sort.Text = sort.ToString();
                    string ID = FlowID;
                    购置验收待我处理查看详情.Hidden = false;
                    string SID = "";
                    School流程进度查看详情BLL bll = new School流程进度查看详情BLL();
                    List<流程进度查看详情表> listdatas = bll.购置验收查看详情(ID, SID);

                    
                    float 总数 = 0.0f;
                    float 总价 = 0.0f;
                    总数 = float.Parse(listdatas[0].总数.ToString());
                    总价 = float.Parse(listdatas[0].总价.ToString());

                    流程状态_gzys.Text = listdatas[0].流程状态.ToString();
                    事项名称_gzys.Text = listdatas[0].事项名称.ToString();
                    单据编号_gzys.Text = listdatas[0].单据编号.ToString();
                    取得方式_gzys.Text = listdatas[0].取得方式.ToString();
                    查看制单日期.Text = listdatas[0].制单日期.ToString();
                    查看购置日期.Text = listdatas[0].购置日期s.ToString();
                    查看供应商.Text = listdatas[0].供应商.ToString();
                    查看供应商联系方式.Text = listdatas[0].供应商联系方式.ToString();
                    查看合同编号.Text = listdatas[0].合同编号.ToString();
                    查看发票号.Text = listdatas[0].发票号.ToString();
                    申请人_gzys.Text = listdatas[0].申请人.ToString();
                    查看记账人.Text = listdatas[0].记账人.ToString();                  
                    //string FlowName = listdatas[0].FlowName.ToString();
                    查看备注.Text = listdatas[0].备注信息.ToString();

                    School购置验收流程BLL gzysbll = new School购置验收流程BLL();
                    DataSet ds = gzysbll.购置验收查询设备(Convert.ToInt32(ID));
                    DataTable dt = ds.Tables[0].Copy();//复制一份table
                    DataTable source = dt;
                    Grid11.DataSource = dt;//DataTable
                    Grid11.DataBind();

                }
            }
            else if (e.CommandName == "Action2")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                int 报修ID = Convert.ToInt32(keys[2]);
                int sort = bll.报修Sort(报修ID);
                School资产报修BLL bllx = new School资产报修BLL();
                OffSession();
                string nm = HttpContext.Current.Session["姓名"].ToString();
                int xx = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                string ren = bllx.ren(报修ID);
                string 职务 = HttpContext.Current.Session["职务"].ToString();
                string 事项名称 = keys[3].ToString();
                //判断事项名称
                if (事项名称 == "资产报修")
                {
                    if (sort == 1 && 职务 == "资产管理员")
                    {
                        DataSet ds = bllx.查维修人();
                        DataTable dt = ds.Tables[0];
                        DropDownList3.DataTextField = "姓名";
                        DropDownList3.DataValueField = "ID";
                        DropDownList3.DataSource = dt;
                        DropDownList3.DataBind();

                        TextBox4.Text = nm;
                        Window4.Hidden = false;
                    }
                    else if (职务 == "维修人员" && sort == 2)
                    {

                        TextBox2.Text = nm;
                        Window5.Hidden = false;
                    }
                    else if (sort == 3 && ren == nm)
                    {
                        DateTime dtime = DateTime.Now;
                        string sj = dtime.Year + "-" + dtime.Month + "-" + dtime.Day;
                        DatePicker2.EmptyText = sj;
                        if (DatePicker2.Text == "")
                        {
                            DatePicker2.Text = DatePicker2.EmptyText;
                        }
                        Window6.Hidden = false;
                    }
                    else
                    {
                        Alert.ShowInTop("您没有此权限！");
                    }
                }
                else if (事项名称 == "资产交接")
                {

                }

            }
        }





        protected void Button9_Click1(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            School资产报修BLL bll = new School资产报修BLL();
            string xa = bll.用户权限(ID);
            object a = Grid1.SelectedRow.DataKeys[2];
            int 待办ID = Convert.ToInt32(Grid1.SelectedRow.DataKeys[0]);
            int xx = Convert.ToInt32(a);
            int sort = bll.sort(待办ID);
            string nm = HttpContext.Current.Session["姓名"].ToString();
            string ren = bll.ren(xx);
            if (xa == "资产管理员" && sort == 1)
            {
                DataSet ds = bll.查维修人();
                DataTable dt = ds.Tables[0];
                DropDownList3.DataTextField = "姓名";
                DropDownList3.DataValueField = "ID";
                DropDownList3.DataSource = dt;
                DropDownList3.DataBind();

                TextBox4.Text = nm;

                Window4.Hidden = false;
            }
            else if (xa == "维修人员" && sort == 2)
            {

                TextBox2.Text = nm;
                Window5.Hidden = false;
            }
            else if (sort == 3 && ren == nm)
            {

                if (DatePicker2.Text == "")
                {
                    DatePicker2.Text = DatePicker2.EmptyText;
                }
                Window6.Hidden = false;
            }
            else
            {
                Alert.ShowInTop("您没有此权限！");
            }


        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (DatePicker1.Text == "")
            {
                DatePicker1.Text = DatePicker1.EmptyText;
            }
            if (DropDownList3.SelectedText != null && TextBox7.Text != "" && DatePicker1.Text != "")
            {
                SchoolX_资产报修流程表 model = new SchoolX_资产报修流程表();
                model.维修人员 = DropDownList3.SelectedText;
                model.管理员电话 = TextBox7.Text;
                model.派单时间 = DatePicker1.Text;
                model.管理员 = TextBox4.Text;
                model.流程状态 = "派单中";
                AM_提醒通知 ammodel = new AM_提醒通知();

                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "维修人员";
                ammodel.发起人 = Session["姓名"].ToString();
                ammodel.消息内容 = "您来自" + ammodel.发起人 + "的资产报修申请,请及时处理！";
                ammodel.消息事项 = "资产报修";
                ammodel.是否已读 = "否";
                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.处理方式 = "个人";
                dbmodel.处理人 = DropDownList3.SelectedText;
                dbmodel.Sort = 2;
                dbmodel.流程状态 = model.流程状态;
                dbmodel.事项名称 = "资产报修";
                dbmodel.FlowName = "资产报修";
                dbmodel.发起人 = Session["姓名"].ToString();
                dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产报修维修申请,请及时处理！";
                dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                School资产报修BLL bll = new School资产报修BLL();
                object a = Grid1.SelectedRow.DataKeys[2];
                int id = Convert.ToInt32(a);
                int xx = bll.添加维修信息(id, model, ammodel, dbmodel);




                if (xx > 0)
                {
                    //Tree1.Nodes.Clear();
                    bindd();
                    Window4.Hidden = true;
                    流程状态待派单.Hidden = true;
                    Alert.ShowInTop("提交成功！");
                }
                else
                {
                    // Tree1.Nodes.Clear();
                    bindd();
                    Alert.ShowInTop("提交错误！");
                }


            }
            else
            {
                Alert.ShowInTop("请填写信息完整！");
                return;
            }

        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            object a = Grid1.SelectedRow.DataKeys[2];
            int id = Convert.ToInt32(a);
            SchoolX_资产报修流程表 model = new SchoolX_资产报修流程表();
            model.完工时间 = DatePicker2.Text;
            model.结果反馈 = 结果反馈.Text;
            model.流程状态 = "已完成";
            AM_提醒通知 ammodel = new AM_提醒通知();
            School资产报修BLL bll = new School资产报修BLL();
            string 职务 = bll.报修ID查询职务(id);
            ammodel.发起时间 = DateTime.Now;
            ammodel.是否已读 = "否";
            ammodel.通知类型 = "结果反馈通知";
            ammodel.通知职务 = 职务;
            ammodel.发起人 = Session["姓名"].ToString();

            ammodel.消息事项 = "资产报修";
            ammodel.是否已读 = "否";
            AM_待办业务 dbmodel = new AM_待办业务();
            dbmodel.处理方式 = "个人";
            dbmodel.处理人 = bll.ren(id);
            dbmodel.流程状态 = model.流程状态;
            dbmodel.事项名称 = "资产报修";
            dbmodel.FlowName = dbmodel.事项名称;
            dbmodel.Sort = 0;
            dbmodel.发起人 = Session["姓名"].ToString();
            dbmodel.通知内容 = "您来自" + dbmodel.处理人 + "的资产报修申请已完成！";
            ammodel.消息内容 = "您来自" + dbmodel.处理人 + "的资产报修申请已完成！";
            dbmodel.发起时间 = DateTime.Now.ToLongDateString();

            int xx = bll.报修结算(id, model, ammodel, dbmodel);
            if (xx > 0)
            {
                Alert.ShowInTop("提交成功！");
                流程状态待派单.Hidden = true;
                Window6.Hidden = true;
                //Tree1.Nodes.Clear();
                bindd();
                return;
            }
            else
            {
                Alert.ShowInTop("提交错误！");
            }

        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (完成时间.Text == "")
            {
                完成时间.Text = 完成时间.EmptyText;
            }
            if (TextBox1.Text != "" && 完成时间.Text != "" && TextBox3.Text != "")
            {
                School资产报修BLL bll = new School资产报修BLL();
                SchoolX_资产报修流程表 model = new SchoolX_资产报修流程表();
                model.维修人电话 = TextBox1.Text;
                model.完工时间 = 完成时间.Text;
                model.故障原因 = TextBox3.Text;
                model.维修人员 = TextBox2.Text;
                model.流程状态 = "维修完成";
                object a = Grid1.SelectedRow.DataKeys[2];
                int id = Convert.ToInt32(a);
                AM_提醒通知 ammodel = new AM_提醒通知();
                string 职务 = bll.报修ID查询职务(id);
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = 职务;
                ammodel.发起人 = Session["姓名"].ToString();
                ammodel.消息内容 = "您来自" + ammodel.发起人 + "的资产报修申请,请及时处理！";
                ammodel.消息事项 = "资产报修";
                ammodel.是否已读 = "否";
                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.处理方式 = "个人";
                dbmodel.处理人 = bll.ren(id);
                dbmodel.流程状态 = model.流程状态;
                dbmodel.事项名称 = "资产报修";
                dbmodel.发起人 = Session["姓名"].ToString();
                dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产报修完成申请,请及时处理！";
                dbmodel.FlowName = "资产报修";
                dbmodel.Sort = 3;
                dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                int xx = bll.添加完成信息(id, model, ammodel, dbmodel);
                if (xx > 0)
                {
                    //Tree1.Nodes.Clear();
                    bindd();
                    Alert.ShowInTop("提交成功！");
                    Window5.Hidden = true;
                    流程状态待派单.Hidden = true;
                }
                else
                {
                    Alert.ShowInTop("提交错误！");
                }

            }
            else
            {
                Alert.ShowInTop("请填写信息完整！");
                return;
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Window4.Hidden = true;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            流程状态待派单.Hidden = true;
        }

        #region  资产交接流程
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
                model.接收人接收时间 = DateTime.Now.ToLongDateString();

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "资产管理员管理员";
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
                    bindd();
                    selectedBind();
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
                    bindd();
                    selectedBind();
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
        #endregion

        #region  查看详情
        protected void Grid4_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                string 事项名称 = Grid4.SelectedRow.DataKeys[3].ToString();
                int 待办ID = Convert.ToInt32(Grid4.SelectedRow.DataKeys[0]);
                string 流程状态 = Grid4.SelectedRow.DataKeys[1].ToString();
                if (事项名称 == "资产报修")
                {
                    School待办业务BLL bll = new School待办业务BLL();
                    SchoolX_资产报修流程表 model = bll.获取报修信息(待办ID);
                    查看报修人.Text = model.报修人;
                    查看报修时间.Text = model.报修时间;
                    查看单号.Text = model.报修单号;
                    查看报修地址.Text = model.报修地址;
                    查看维修人员.Text = model.维修人员;
                    查看解决时间.Text = model.解决时间;
                    查看管理员.Text = model.管理员;
                    查看派单时间.Text = model.派单时间;
                    查看报修人电话.Text = model.报修人电话;
                    查看维修人电话.Text = model.维修人电话;
                    查看管理员电话.Text = model.管理员电话;
                    查看故障描述.Text = model.故障描述;
                    查看结果反馈.Text = model.结果反馈;
                    Image2.ImageUrl = model.故障照片;
                    if (流程状态 == "待派单")
                    {
                        Button9.Text = "提交派单";
                    }
                    else if (流程状态 == "派单中")
                    {
                        Button9.Text = "提交维修";
                    }
                    else if (流程状态 == "维修完成")
                    {
                        Button9.Text = "完成提交";
                    }
                    else if (流程状态 == "已完成")
                    {
                        Button9.Hidden = true;
                    }

                    string 设备id = model.设备ID;
                    List<int> inlist = new List<int>();
                    string[] sbid = 设备id.Split(',');
                    foreach (string item in sbid)
                    {
                        if (item == "" || item == null)
                        {
                            break;
                        }
                        inlist.Add(Convert.ToInt32(item));
                    }
                    School资产报修BLL blla = new School资产报修BLL();
                    List<School办公设备信息表> listdata = blla.资产转移确定设备(inlist);
                    Grid3.DataSource = listdata;//DataTable
                    Grid3.DataBind();
                    Button9.Hidden = true;
                    流程状态待派单.Title = "查看详情";
                    流程状态待派单.Hidden = false;

                }
                else if (事项名称 == "资产交接")
                {
                    btnok.Hidden = true;
                    Window3.Title = "查看详情";
                    School资产借还交接BLL bll = new School资产借还交接BLL();
                    待办ID = Convert.ToInt32(Grid4.SelectedRow.DataKeys[0]);
                    AM_资产交接流程表 model = bll.资产交接查看详情(待办ID);

                    查看流程状态.Text = model.流程状态;


                    查看单据编号.Text = model.单据编号;
                    查看交付人.Text = model.交付人;
                    查看接收人.Text = model.接收人;
                    查看提交时间.Text = model.提交时间;
                    查看完成时间.Text = model.完成时间;
                    查看备注信息.Text = model.备注信息;

                    string zcid = model.资产ID;
                    FlowID.Text = model.ID.ToString();
                    资产ID.Text = zcid;

                    int sort = model.Sort;
                    if (sort == 2)
                    {
                        btnok.Text = "确认通过";
                    }
                    else if (sort == 1)
                    {
                        btnok.Text = "确认接收";
                    }
                    Grid2.DataSource = bll.资产借还查看详情(zcid);
                    Grid2.DataBind();

                    Window3.Hidden = false;
                }
                else if (事项名称 == "资产借还")
                {
                    OffSession();
                    string username = Session["姓名"].ToString();
                    待办ID = Convert.ToInt32(Grid4.SelectedRow.DataKeys[0]);
                    School资产借还交接BLL bll = new School资产借还交接BLL();
                    AM_资产借还流程表 model = bll.资产借还查看详情(待办ID);
                    TextBox6.Text = model.单据编号;
                    查看借用人.Text = model.借用人;
                    查看借出人.Text = model.借出人;
                    TextBox5.Text = model.流程状态;
                    DatePicker3.Text = model.提交时间;
                    TextBox8.Text = model.备注信息;
                    TextBox9.Text = model.ID.ToString();
                    int Sort = model.Sort;
                    //if (username == 查看借出人.Text && Sort == 1)
                    //{
                    //    Button1.Text = "同意借出";
                    //    Button2.Text = "拒绝借出";
                    //}
                    //else if (Sort == 2 && 查看借用人.Text == username)
                    //{
                    //    Button1.Text = "确认归还";
                    //    Button2.Text = "关闭";
                    //}
                    //else if (Sort == 3 && 查看借出人.Text == username)
                    //{
                    //    Button1.Text = "已归还";
                    //    Button2.Text = "未归还";
                    //}
                    //else
                    //{
                    //    Button1.Hidden = true;
                    //    Button2.Text = "关闭";
                    //}
                    Button1.Hidden = true;
                    Button2.Hidden = false;
                    查看借用时间.Text = model.借用时间;
                    查看预计归还时间.Text = model.预计归还时间;
                    查看备注信息.Text = model.备注信息;

                    string zcid = model.资产ID;
                    资产ID.Text = zcid;

                    Grid5.DataSource = bll.资产借还查看详情(zcid);
                    Grid5.DataBind();

                    Window1.Hidden = false;
                }
                else if (事项名称 == "资产处置-报废")
                {
                    OffSession();
                    School流程进度查看详情BLL bll = new School流程进度查看详情BLL();
                    string 职务 = Session["职务"].ToString();
                    //string FlowID = Request.QueryString["FlowID"];
                    string FlowID=Grid4.SelectedRow.DataKeys[2].ToString();
                    int sort = Convert.ToInt32(Grid4.SelectedRow.DataKeys[9].ToString());
                    //if (FlowID != "" && FlowID != null)
                    //{
                    //    ID = FlowID;
                    //}
                    //else
                    //{
                    //    ID = Request.QueryString["ID"];
                    //}



                    //string ID = Request.QueryString["ID"];
                    string ID = FlowID;
                    //string SID = Request.QueryString["SID"];
                    资产处置_报废.Hidden = false;
                    string SID = bll.资产处置SID(Convert.ToInt32(FlowID));
                    List<流程进度查看详情表> listdatas = bll.资产处置待报废查看详情(ID, SID);


                    流程状态_abfckxq.Text = listdatas[0].流程状态.ToString();
                    单据编号_bfckxq.Text = listdatas[0].单据编号.ToString();
                    float 总数 = 0.0f;
                    float 总价 = 0.0f;
                    总数 = float.Parse(listdatas[0].总数.ToString());
                    总价 = float.Parse(listdatas[0].总价.ToString());
                    分管领导_bfckxq.Text = listdatas[0].调入单位分管领导.ToString();
                    分管领导处理意见_bfckxq.Text = listdatas[0].调入单位分管领导意见.ToString();
                    分管领导操作时间_bfckxq.Text = listdatas[0].调入单位分管领导处理时间.ToString();
                    电话_bfckxq.Text = listdatas[0].电话.ToString();

                    职务_bfckxq.Text = listdatas[0].职务.ToString();
                    事项名称_bfckxq.Text = listdatas[0].事项名称.ToString();
                    主管部门_bfckxq.Text = listdatas[0].主管部门.ToString();
                    主管部门处理意见_bfckxq.Text = listdatas[0].主管部门意见.ToString();

                    主管部门操作时间_bfckxq.Text = listdatas[0].主管部门处理时间.ToString();
                    财政部门意见_bfckxq.Text = listdatas[0].财政部门意见.ToString();
                    财政部门_bfckxq.Text = listdatas[0].财政部门.ToString();
                    财政部门操作时间_bfckxq.Text = listdatas[0].财政部门处理时间.ToString();
                    原因说明_bfckxq.Text = listdatas[0].原因说明.ToString();
                    申请人_bfckxq.Text = listdatas[0].申请人.ToString();
                    申报单位_bfckxq.Text = listdatas[0].申报单位.ToString();
                    申报日期_ckxq.Text = listdatas[0].申报日期.ToString();
                    string FlowName = listdatas[0].FlowName.ToString();

                    School申报审批BLL sbspbll = new School申报审批BLL();
                    List<School办公设备信息表> listdata = sbspbll.处置申报查询(SID, FlowName);

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

                    if (职务 == "分管领导" && sort == 1)
                    {
                        报废处理.Hidden = false;

                    }
                    else if (职务 == "主管部门" && sort == 2)
                    {
                        报废处理.Hidden = false;
                    }
                    else if (职务 == "财务人员" && sort == 3)
                    {
                        报废处理.Hidden = false;
                    }
                    else if (sort == 0)
                    {
                        报废处理.Hidden = true;
                    }
                    else
                    {
                        报废处理.Hidden = false;
                    }
                }
                else if (事项名称 == "资产处置-调拨")
                {
                    OffSession();
                    string 职务 = Session["职务"].ToString();
                    School流程进度查看详情BLL bll = new School流程进度查看详情BLL();
                    //string FlowID = Request.QueryString["FlowID"];
                    string FlowID = Grid4.SelectedRow.DataKeys[2].ToString();  
                    int sort = Convert.ToInt32(Grid4.SelectedRow.DataKeys[9].ToString());
                    string ID = FlowID;
                    资产处置_调拨.Hidden = false;
                    string SID = bll.资产处置SID(Convert.ToInt32(ID));
                    List<流程进度查看详情表> listdatas = bll.资产处置待报废查看详情(ID, SID);


                    流程状态_dbckxq.Text = listdatas[0].流程状态.ToString();
                    单据编号_dbckxq.Text = listdatas[0].单据编号.ToString();
                    float 总数 = 0.0f;
                    float 总价 = 0.0f;
                    总数 = float.Parse(listdatas[0].总数.ToString());
                    总价 = float.Parse(listdatas[0].总价.ToString());
                    调出单位分管领导.Text = listdatas[0].调出单位分管领导.ToString();
                    调出单位分管领导意见.Text = listdatas[0].调出单位分管领导意见.ToString();
                    调出单位分管领导处理时间.Text = listdatas[0].调出单位分管领导处理时间.ToString();

                    调入单位分管领导意见.Text = listdatas[0].调入单位分管领导意见.ToString();
                    调入单位分管领导.Text = listdatas[0].调入单位分管领导.ToString();
                    调入单位分管领导处理时间.Text = listdatas[0].调入单位分管领导处理时间.ToString();
                    调入单位管理员意见.Text = listdatas[0].调入单位管理员意见.ToString();
                    调入单位管理员.Text = listdatas[0].调入单位管理员.ToString();
                    调入单位管理员处理时间.Text = listdatas[0].调入单位管理员处理时间.ToString();


                    电话_dbckxq.Text = listdatas[0].电话.ToString();

                    职务_dbckxq.Text = listdatas[0].职务.ToString();
                    事项名称_dbckxq.Text = listdatas[0].事项名称.ToString();
                    主管部门.Text = listdatas[0].主管部门.ToString();
                    调拨主管部门意见.Text = listdatas[0].主管部门意见.ToString();

                    主管部门处理时间.Text = listdatas[0].主管部门处理时间.ToString();
                    调拨财政部门意见.Text = listdatas[0].财政部门意见.ToString();
                    财政部门.Text = listdatas[0].财政部门.ToString();
                    财政部门处理时间.Text = listdatas[0].财政部门处理时间.ToString();
                    //原因说明_bfckxq.Text = listdatas[0].原因说明.ToString();
                    申请人_dbckxq.Text = listdatas[0].申请人.ToString();
                    //申报单位_bfckxq.Text = listdatas[0].申报单位.ToString();
                    调出单位_dbckxq.Text = listdatas[0].调出单位.ToString();
                    调入单位_dbckxq.Text = listdatas[0].调入单位.ToString();
                    申报日期_dbckxq.Text = listdatas[0].申报日期.ToString();
                    验收日期_dbckxq.Text = listdatas[0].验收日期.ToString();

                    string FlowName = listdatas[0].FlowName.ToString();

                    School申报审批BLL sbspbll = new School申报审批BLL();
                    List<School办公设备信息表> listdata = sbspbll.处置申报查询(SID, FlowName);

                    Grid9.DataSource = listdata;
                    Grid9.DataBind();
                    Grid10.DataSource = listdata;
                    Grid10.DataBind();

                    JObject summary = new JObject();
                    summary.Add("major", "全部合计");
                    summary.Add("数量_dbckxq", 总数.ToString("F2"));
                    summary.Add("价格_dbckxq", 总价.ToString("F2"));
                    Grid9.SummaryData = summary;
                    Grid10.SummaryData = summary;
                    
                }
                else if (事项名称 == "资产转移")
                {
                    int FlowID = Convert.ToInt32(Grid4.SelectedRow.DataKeys[2].ToString());
                    SchoolX_资产转移流程表 model = bll.获取资产转移信息(FlowID);
                    TextBox13.Text = model.流程状态;
                    TextBox14.Text = model.单据编号;
                    查看事项名称.Text = model.事项名称;
                    查看申请人.Text = model.申请人;
                    查看申请日期.Text = model.申请日期;
                    查看联系方式.Text = model.联系方式;
                    School资产转移BLL bllc = new School资产转移BLL();
                    DataSet ds = bllc.资产转移查看详情(FlowID);
                    DataTable dt = ds.Tables[0].Copy();//复制一份table
                    Grid6.DataSource = dt;//DataTable
                    Grid6.DataBind();
                    SchoolX_资产转移改动信息表 modela = bllc.查询变更为(FlowID);
                    查看存放地点变更为.Text = modela.现存放地点;
                    查看归属部门变更为.Text = modela.现归属部门;
                    查看负责人变更为.Text = modela.现负责人;
                    Toolbar12.Hidden = true;
                    新增资产转移查看详情.Hidden = false;
                }else if (事项名称 == "购置验收")
                {
                    

                    OffSession();
                    string 职务 = Session["职务"].ToString();
                    if (职务 == "财务人员")
                    {
                        购置验收待我处理_wdgzyscl.Text = "同意";
                        购置验收待我处理_wdgzysgb.Text = "拒绝";
                    }
                    else
                    {
                        购置验收待我处理_wdgzyscl.Enabled = false;
                        购置验收待我处理_wdgzysgb.Text = "关闭";

                    }
                    //string FlowID = Request.QueryString["FlowID"];
                    int FlowID = Convert.ToInt32(Grid4.SelectedRow.DataKeys[2].ToString());
                    
                    int sorts = Convert.ToInt32(Grid4.SelectedRow.DataKeys[9].ToString());
                    //flowid_gzys.Text = FlowID.ToString();
                    //Sort.Text = sort.ToString();
                    string ID = FlowID.ToString();
                    
                    string SID = "";
                    School流程进度查看详情BLL bll = new School流程进度查看详情BLL();
                    List<流程进度查看详情表> listdatas = bll.购置验收查看详情(ID, SID);


                    float 总数 = 0.0f;
                    float 总价 = 0.0f;
                    总数 = float.Parse(listdatas[0].总数.ToString());
                    总价 = float.Parse(listdatas[0].总价.ToString());

                    流程状态_wdgzys.Text = listdatas[0].流程状态.ToString();
                    事项名称_wdgzys.Text = listdatas[0].事项名称.ToString();
                    单据编号_wdgzys.Text = listdatas[0].单据编号.ToString();
                    取得方式_wdgzys.Text = listdatas[0].取得方式.ToString();
                    查看制单日期_wdgzys.Text = listdatas[0].制单日期.ToString();
                    查看购置日期_wdgzys.Text = listdatas[0].购置日期s.ToString();
                    查看供应商_wdgzys.Text = listdatas[0].供应商.ToString();
                    查看供应商联系方式_wdgzys.Text = listdatas[0].供应商联系方式.ToString();
                    查看合同编号_wdgzys.Text = listdatas[0].合同编号.ToString();
                    查看发票号_wdgzys.Text = listdatas[0].发票号.ToString();
                    申请人_wdgzys.Text = listdatas[0].申请人.ToString();
                    查看记账人_wdgzys.Text = listdatas[0].记账人.ToString();
                    //string FlowName = listdatas[0].FlowName.ToString();
                    查看备注_wdgzys.Text = listdatas[0].备注信息.ToString();

                    School购置验收流程BLL gzysbll = new School购置验收流程BLL();
                    DataSet ds = gzysbll.购置验收查询设备(Convert.ToInt32(ID));
                    DataTable dt = ds.Tables[0].Copy();//复制一份table
                    DataTable source = dt;
                    Grid12.DataSource = dt;//DataTable
                    Grid12.DataBind();
                    购置验收我的发起处理查看详情.Hidden = false;
                }
            }
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "同意借出")
            {
                School资产借还交接BLL bll = new School资产借还交接BLL();
                string processingtime = DateTime.Now.ToShortDateString();//处理时间
                string username = Session["姓名"].ToString();//处理人
                int flowid = Convert.ToInt32(TextBox9.Text);
                string 借用人name = bll.查借用人(flowid);
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
                ammodel.通知职务 = "财务人员";
                ammodel.消息内容 = "您来自" + username + "的资产借还已同意,请及时处理！";
                ammodel.消息事项 = "资产借还";
                ammodel.发起人 = username;//处理人
                ammodel.FlowID = flowid;

                AM_待办业务 dbmodel = new AM_待办业务();
                dbmodel.处理方式 = "个人";
                dbmodel.处理人 = 借用人name;
                dbmodel.发起人 = username;
                dbmodel.FlowID = flowid;
                dbmodel.流程状态 = "已出借,待归还";
                dbmodel.事项名称 = "资产借还";
                dbmodel.通知内容 = "您来自" + username + "的资产借还已同意,请及时处理！";
                dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                dbmodel.FlowName = "资产借还";
                dbmodel.Sort = 2;


                string sql = string.Format("UPDATE dbo.AM_待办业务 set 流程状态 = '{0}',处理职务='{1}',处理方式='{2}',处理人='{3}'  where FlowID = {4} AND FlowName = '{5}'", ammodel.流程状态, ammodel.处理职务, ammodel.处理方式, ammodel.处理人, ammodel.FlowID, ammodel.FlowName);

                if (bll.操作资产借还流程(model, ammodel, dbmodel) > 0)
                {
                    Alert alert = new Alert();
                    alert.Message = "处理成功";
                    alert.Title = "提示信息";
                    alert.MessageBoxIcon = MessageBoxIcon.Success;
                    alert.Show();
                    Window3.Hidden = true;
                    bindd();
                    selectedBind();
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
            else if (Button1.Text == "确认归还")
            {
                School资产借还交接BLL bll = new School资产借还交接BLL();
                string processingtime = DateTime.Now.ToShortDateString();//处理时间
                string username = Session["姓名"].ToString();//处理人
                int flowid = Convert.ToInt32(TextBox9.Text);
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
                ammodel.消息内容 = "资产借还流程" + username + "已归还，等待借出人确认。";
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
                    Window1.Hidden = true;
                    bindd();
                    selectedBind();
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
            else if (Button1.Text == "已归还")
            {
                string processingtime = DateTime.Now.ToShortDateString();//处理时间
                string username = Session["姓名"].ToString();//处理人
                int flowid = Convert.ToInt32(TextBox9.Text);
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
                ammodel.消息内容 = "您的资产借还流程已全部完成！";
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
                    Window1.Hidden = true;
                    bindd();
                    selectedBind();
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



        #region//流程状态
        protected string GetEditUrls(object FlowID, object FlowName, object ReceiptNumber, object sort)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("事项名称", "事项名称" + ReceiptNumber);
            joBuilder.AddProperty("title", "流程进度 - " + ReceiptNumber);
            string flowname = FlowName.ToString();
            if (flowname == "资产处置-报废")
            {
                joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("/School申报管理/School处置申报资产报废流程进度.aspx?SBBH={0}&sort={1}&FlowID={2}", ReceiptNumber, HttpUtility.UrlEncode(sort.ToString()), FlowID)));
            }
            else if (flowname == "资产处置-调拨")
            {
                joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("/School申报管理/School处置申报资产调拨流程进度.aspx?SBBH={0}&sort={1}&FlowID={2}", ReceiptNumber, HttpUtility.UrlEncode(sort.ToString()), FlowID)));
            }
            else if (flowname == "购置验收")
            {
                joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("/School购置验收/School购置验收流程进度.aspx?SBBH={0}&sort={1}&FlowID={2}", ReceiptNumber, HttpUtility.UrlEncode(sort.ToString()), FlowID)));
            }
            //joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("School购置验收流程进度.aspx?SBBH={0}&sort={1}", id, HttpUtility.UrlEncode(sort.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }
        #endregion

        #region//查看详情报废切换按钮
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
        #endregion

        protected void btnClose_Click(object sender, EventArgs e)
        {
            资产处置_调拨.Hidden = true;
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

        protected void 报废关闭_Click(object sender, EventArgs e)
        {
            资产处置_报废.Hidden = true;
        }


        protected void 报废处理_Click(object sender, EventArgs e)
        {
            string zcid = 资产ID.Text;
            报废处理.Hidden = false;
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
        protected void ZCCLSPNO_Click(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList2.SelectedValue == "处置单")
            {
                Grid13.Hidden = false;
                Grid14.Hidden = true;
            }
            else
            {
                Grid13.Hidden = true;
                Grid14.Hidden = false;
            }
        }

        protected void 待我处理资产处置_报废处理_Click(object sender, EventArgs e)
        {
            string zcid = 资产ID.Text;
            //Button15.Hidden = false;
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

        protected void 待我处理报废关闭_Click(object sender, EventArgs e)
        {
            待我处理资产处置_报废.Hidden = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            待我处理资产处置_调拨.Hidden = true;
        }

        protected void RadioButtonList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList6.SelectedValue == "处置单")
            {
                Grid17.Hidden = false;
                Grid18.Hidden = true;
            }
            else
            {
                Grid17.Hidden = true;
                Grid18.Hidden = false;
            }
        }

        protected void ZCCLSPYES_Click(object sender, EventArgs e)
        {
            School申报审批BLL bll = new School申报审批BLL();
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
                        待我处理资产处置_调拨.Hidden = true;
                        审批处理界面.Hidden = true;
                        bindd();
                        selectedBind();
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
                        待我处理资产处置_调拨.Hidden = true;
                        审批处理界面.Hidden = true;
                         bindd();
                        selectedBind();
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
                        待我处理资产处置_调拨.Hidden = true;
                        审批处理界面.Hidden = true;
                        bindd();
                        selectedBind();
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
                        待我处理资产处置_调拨.Hidden = true;
                        审批处理界面.Hidden = true;
                        bindd();
                        selectedBind();
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
                        待我处理资产处置_调拨.Hidden = true;
                        审批处理界面.Hidden = true;
                        bindd();
                        selectedBind();
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
                            待我处理资产处置_调拨.Hidden = true;
                            审批处理界面.Hidden = true;
                            bindd();
                            selectedBind();
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
                    if (dcname == username)
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
                            待我处理资产处置_调拨.Hidden = true;
                            审批处理界面.Hidden = true;
                            bindd();
                            selectedBind();
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
            }
            #region
            else if (FlowName.Text == "资产处置-报废")
            {
                if (职务 == "分管领导" && Sort.Text == "1")
                {
                    model.ID = flowid;
                    model.SID = 资产ID.Text;
                    model.调入单位分管领导处理时间 = processingtime;
                    if (处理意见.Text == "")
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
                        待我处理资产处置_报废.Hidden = true;
                        bindd();
                        selectedBind();
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
                        待我处理资产处置_报废.Hidden = true;
                        bindd();
                        selectedBind();
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
                        待我处理资产处置_报废.Hidden = true;
                        bindd();
                        selectedBind();
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

        protected void 待我处理资产处置_调拨处理_Click(object sender, EventArgs e)
        {
            if (FlowName.Text == "资产处置-调拨")
            {

                审批处理界面.Hidden = false;
            }
        }




        protected void Button5_Click(object sender, EventArgs e)
        {
            School资产转移BLL bll = new School资产转移BLL();
            int FlowID = Convert.ToInt32(Grid1.SelectedRow.DataKeys[2].ToString());

            OffSession();
            string username = Session["姓名"].ToString();
            AM_提醒通知 ammodel = new AM_提醒通知();

            ammodel.发起时间 = DateTime.Now;
            ammodel.是否已读 = "否";
            ammodel.通知类型 = "结果通知";
            ammodel.通知职务 = "资产管理员";
            ammodel.发起人 = username;
            ammodel.消息内容 = "您来自" + ammodel.发起人 + "的资产转移结果通知！";
            ammodel.消息事项 = "资产转移";
            ammodel.是否已读 = "否";
            AM_待办业务 dbmodel = new AM_待办业务();
            dbmodel.处理方式 = "职务";
            dbmodel.处理职务 = "资产管理员";
            dbmodel.流程状态 = "已完成";
            dbmodel.发起人 = ammodel.发起人;
            dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产转移结果通知！";
            dbmodel.发起时间 = DateTime.Now.ToLongDateString();
            dbmodel.Sort = 0;

            int num = bll.修改数据(FlowID, 查看归属部门变更为.Text, 查看存放地点变更为.Text, 查看负责人变更为.Text, ammodel, dbmodel);
            if (num > 0)
            {
                Alert.ShowInTop("转移成功！", "提示信息", MessageBoxIcon.Information);
                新增资产转移查看详情.Hidden = true;
                bindd();
                selectedBind();
            }
        }

        protected void 购置验收待我处理_cl_Click(object sender, EventArgs e)
        {
            OffSession();

            if (购置验收待我处理_cl.Text == "同意")
            {

                string username = Session["姓名"].ToString();//处理人
                string processingtime = DateTime.Now.ToShortDateString();//处理时间
                int FlowID = Convert.ToInt32(flowid_gzys.Text);
                SchoolX_购置验收流程表 model = new SchoolX_购置验收流程表();
                model.ID = FlowID;
                model.操作人 = username;
                model.操作时间 = processingtime;
                model.是否同意 = "是";
                model.记账人 = username;

                //AM_待办业务 dbmodel = new AM_待办业务();
                //dbmodel.处理方式 = "职务";
                //dbmodel.处理职务 = "财政人员";
                //dbmodel.流程状态 = "已完成";
                //dbmodel.处理人 = username;
                //dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产转移结果通知！";
                //dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                //dbmodel.Sort = 0;


                AM_提醒通知 ammodel = new AM_提醒通知();

                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "结果反馈通知";
                ammodel.通知职务 = "发起人";
                ammodel.消息内容 = "购置验收/入库-任务已全部完成！";
                ammodel.消息事项 = "购置验收/入库-结果反馈";
                ammodel.发起人 = username;//处理人
                ammodel.FlowID = FlowID;
                School购置验收流程BLL gzysbll = new School购置验收流程BLL();
                if (gzysbll.操作购置验收流程(model, ammodel) > 0)
                {
                    Alert alert = new Alert();
                    alert.Message = "处理成功";
                    alert.Title = "提示信息";
                    alert.MessageBoxIcon = MessageBoxIcon.Success;
                    alert.Show();
                    购置验收待我处理查看详情.Hidden = true;
                    bindd();
                    selectedBind();
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
                //    string username = Session["姓名"].ToString();//处理人
                //    string processingtime = DateTime.Now.ToShortDateString();//处理时间
                //    int FlowID = Convert.ToInt32(flowid.Text);
                //    SchoolX_购置验收流程表 model = new SchoolX_购置验收流程表();
                //    model.ID = FlowID;
                //    model.操作人 = username;
                //    model.操作时间 = processingtime;
                //    model.是否同意 = "否";

                //    AM_提醒通知 ammodel = new AM_提醒通知();
                //    ammodel.发起时间 = DateTime.Now;
                //    ammodel.是否已读 = "否";
                //    ammodel.通知类型 = "结果反馈通知";
                //    ammodel.通知职务 = "发起人";
                //    ammodel.消息内容 = "购置验收/入库-任务已全部完成！";
                //    ammodel.消息事项 = "购置验收/入库-结果反馈";
                //    ammodel.发起人 = username;//处理人
                //    ammodel.FlowID = FlowID;

                //    AM_待办业务 dbmodel = new AM_待办业务();
                //    dbmodel.处理方式 = "职务";
                //    dbmodel.处理职务 = "财政人员";
                //    dbmodel.流程状态 = "已拒绝";
                //    dbmodel.处理人 = username;
                //    dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产转移结果通知！";
                //    dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                //    dbmodel.Sort = 0;

                //    if (gzysbll.操作购置验收流程(model, dbmodel,ammodel) > 0)
                //    {
                //        Alert alert = new Alert();
                //        alert.Message = "处理成功";
                //        alert.Title = "提示信息";
                //        alert.MessageBoxIcon = MessageBoxIcon.Success;
                //        alert.Show();
                //        处理资产.Hidden = true;
                //        BindGrid();
                //        return;
                //    }
                //    else
                //    {
                //        Alert alert = new Alert();
                //        alert.Message = "处理失败";
                //        alert.Title = "提示信息";
                //        alert.MessageBoxIcon = MessageBoxIcon.Error;
                //        alert.Show();
                //        return;
                //    }
            }
        }

        protected void 购置验收待我处理_gb_Click(object sender, EventArgs e)
        {
            购置验收待我处理查看详情.Hidden = true;
        }

        protected void 购置验收待我处理_wdgzyscl_Click(object sender, EventArgs e)
        {
            OffSession();

            if (购置验收待我处理_wdgzyscl.Text == "同意")
            {

                string username = Session["姓名"].ToString();//处理人
                string processingtime = DateTime.Now.ToShortDateString();//处理时间
                int FlowID = Convert.ToInt32(flowid_wdgzys.Text);
                SchoolX_购置验收流程表 model = new SchoolX_购置验收流程表();
                model.ID = FlowID;
                model.操作人 = username;
                model.操作时间 = processingtime;
                model.是否同意 = "是";
                model.记账人 = username;

                AM_提醒通知 ammodel = new AM_提醒通知();
                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "结果反馈通知";
                ammodel.通知职务 = "发起人";
                ammodel.消息内容 = "购置验收/入库-任务已全部完成！";
                ammodel.消息事项 = "购置验收/入库-结果反馈";
                ammodel.发起人 = username;//处理人
                ammodel.FlowID = FlowID;

                School购置验收流程BLL gzysbll = new School购置验收流程BLL();
                if (gzysbll.操作购置验收流程(model, ammodel) > 0)
                {
                    Alert alert = new Alert();
                    alert.Message = "处理成功";
                    alert.Title = "提示信息";
                    alert.MessageBoxIcon = MessageBoxIcon.Success;
                    alert.Show();
                    购置验收我的发起处理查看详情.Hidden = true;
                    bindd();
                    selectedBind();
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
                //    string username = Session["姓名"].ToString();//处理人
                //    string processingtime = DateTime.Now.ToShortDateString();//处理时间
                //    int FlowID = Convert.ToInt32(flowid.Text);
                //    SchoolX_购置验收流程表 model = new SchoolX_购置验收流程表();
                //    model.ID = FlowID;
                //    model.操作人 = username;
                //    model.操作时间 = processingtime;
                //    model.是否同意 = "否";

                //    AM_提醒通知 ammodel = new AM_提醒通知();
                //    ammodel.发起时间 = DateTime.Now;
                //    ammodel.是否已读 = "否";
                //    ammodel.通知类型 = "结果反馈通知";
                //    ammodel.通知职务 = "发起人";
                //    ammodel.消息内容 = "购置验收/入库-任务已全部完成！";
                //    ammodel.消息事项 = "购置验收/入库-结果反馈";
                //    ammodel.发起人 = username;//处理人
                //    ammodel.FlowID = FlowID;

                //    AM_待办业务 dbmodel = new AM_待办业务();
                //    dbmodel.处理方式 = "职务";
                //    dbmodel.处理职务 = "财政人员";
                //    dbmodel.流程状态 = "已拒绝";
                //    dbmodel.处理人 = username;
                //    dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产转移结果通知！";
                //    dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                //    dbmodel.Sort = 0;

                //    if (gzysbll.操作购置验收流程(model, dbmodel,ammodel) > 0)
                //    {
                //        Alert alert = new Alert();
                //        alert.Message = "处理成功";
                //        alert.Title = "提示信息";
                //        alert.MessageBoxIcon = MessageBoxIcon.Success;
                //        alert.Show();
                //        处理资产.Hidden = true;
                //        BindGrid();
                //        return;
                //    }
                //    else
                //    {
                //        Alert alert = new Alert();
                //        alert.Message = "处理失败";
                //        alert.Title = "提示信息";
                //        alert.MessageBoxIcon = MessageBoxIcon.Error;
                //        alert.Show();
                //        return;
                //    }
            }
        }

        protected void 购置验收待我处理_wdgzysgb_Click(object sender, EventArgs e)
        {

        }
    }
}