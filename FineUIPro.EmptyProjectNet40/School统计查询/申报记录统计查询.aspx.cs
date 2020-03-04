using PLM.BusinessRlues;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.统计查询
{
    public partial class 申报记录统计查询 : PageBase
    {
        School申报审批BLL bll = new School申报审批BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                DataSet ds = bll.申报记录统计查询("", "流程状态-全部");
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                DataTable source = dt;
                // 3.绑定到Grid  
                Grid1.DataSource = dt;
                Grid1.DataBind(); 
            }
        }
 
 
   

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string flowstate = DropDownList1.SelectedText;
            DataSet ds = bll.申报记录统计查询(ttbSearch.Text, flowstate);


            Console.Write(ds.ToString());
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;
            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }

        protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
        {
            string sSearch = ttbSearch.Text.ToString();
            DataSet ds = bll.申报记录统计查询(sSearch, DropDownList1.SelectedText);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind(); 
        }
    }
}