using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.统计查询
{
    public partial class 资产处置统计查询 : PageBase
    {
        School资产处置BLL zcczbll = new School资产处置BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            DataSet ds = zcczbll.资产处置统计查询表("","处置临时状态-全部");
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;
            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind(); 
            }       
        }

        protected void tSearch_Trigger2Click(object sender, EventArgs e)
        {
            string sSearch = tSearch.Text.ToString();
            Console.Write("取到的结果为：" + sSearch);
            DataSet ds = zcczbll.资产处置统计查询表(sSearch, DropDownList1.SelectedText);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string flowstate = DropDownList1.SelectedText;
            DataSet ds = zcczbll.资产处置统计查询表(tSearch.Text, flowstate);

            Console.Write(ds.ToString());
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;
            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }
    }
}