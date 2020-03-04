using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.School资产交接
{
    public partial class School资产交接流程进度 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取设备编号
            string paramName = Request.QueryString["SBBH"];
            Label6.Text = "资产交接：" + paramName;
            string Sort = Request.QueryString["sort"];
            Label1.Text = Sort;
        }
    }
}