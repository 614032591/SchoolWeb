using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.School购置验收
{
    public partial class School购置验收流程进度 : System.Web.UI.Page
    {
        School流程进度查看详情BLL bll = new School流程进度查看详情BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//是否是客户端回发而加载
            {
                //获取设备编号
                string paramName = Request.QueryString["SBBH"];
                Label6.Text = "购置验收/入库-单据编号：" + paramName;
                string Sort = Request.QueryString["sort"];
                Label1.Text = Sort;
                string FlowID = Request.QueryString["FlowID"];                           
            }
        }

        protected void 查看详情_Click(object sender, EventArgs e)
        {
            string FlowID = Request.QueryString["FlowID"];
            if (FlowID != "" && FlowID != null)
            {
                ID = FlowID;
            }
            else
            {
                ID = Request.QueryString["ID"];
            }
            string SID = "";
            List<流程进度查看详情表> listdatas = bll.购置验收查看详情(ID, SID);
            float 总数 = 0.0f;
            float 总价 = 0.0f;
            总数 = float.Parse(listdatas[0].总数.ToString());
            总价 = float.Parse(listdatas[0].总价.ToString());

            查看流程状态.Text = listdatas[0].流程状态.ToString();
            查看事项名称.Text = listdatas[0].事项名称.ToString();
            查看单据编号.Text = listdatas[0].单据编号.ToString();
            查看取得方式.Text = listdatas[0].取得方式.ToString();
            查看制单日期.Text = listdatas[0].制单日期.ToString();
            查看购置日期.Text = listdatas[0].购置日期s.ToString();
            查看供应商.Text = listdatas[0].供应商.ToString();
            查看供应商联系方式.Text = listdatas[0].供应商联系方式.ToString();
            查看合同编号.Text = listdatas[0].合同编号.ToString();
            查看发票号.Text = listdatas[0].发票号.ToString();
            查看申请人.Text = listdatas[0].申请人.ToString();
            查看记账人.Text = listdatas[0].记账人.ToString();
            //string FlowName = listdatas[0].FlowName.ToString();
            查看备注.Text = listdatas[0].备注信息.ToString();

            School购置验收流程BLL gzysbll = new School购置验收流程BLL();
            DataSet ds = gzysbll.购置验收查询设备(Convert.ToInt32(ID));
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;
            Grid3.DataSource = dt;//DataTable
            Grid3.DataBind();
            处理资产.Hidden = false;
        }
    }
}