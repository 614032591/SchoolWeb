using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.School原值变动
{
    public partial class School原值变动流程进度 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//是否是客户端回发而加载
            {
                //获取设备编号
                string paramName = Request.QueryString["SBBH"];
                Label6.Text = "原值变动流程，单号：" + paramName;
                string Sort = Request.QueryString["sort"];
                Label1.Text = Sort;
            }
        }
    }
}