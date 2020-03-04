using Newtonsoft.Json.Linq;
using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.School申报管理
{
    public partial class School处置申报资产调拨流程进度 : System.Web.UI.Page
    {
        School流程进度查看详情BLL bll = new School流程进度查看详情BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//是否是客户端回发而加载
            {
                //获取设备编号
                string paramName = Request.QueryString["SBBH"];

                string FlowID = Request.QueryString["FlowID"];
                Label6.Text = "资产申报-资产调拨流程，单号：" + paramName;
                string Sort = Request.QueryString["sort"];
                Label1.Text = Sort;
            }
        }

        protected void 查看详情_Click(object sender, EventArgs e)
        {
            string FlowID = Request.QueryString["FlowID"];
            if (FlowID!="" && FlowID!=null)
            {
                 ID = FlowID;
            }
            else
            {
                 ID = Request.QueryString["ID"];
            }
            //
            //string SID = Request.QueryString["SID"];
            Window1.Hidden = false;
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

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Window1.Hidden = true;
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
    }
}