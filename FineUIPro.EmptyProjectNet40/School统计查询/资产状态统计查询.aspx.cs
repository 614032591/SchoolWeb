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
    public partial class 资产状态统计查询 : PageBase
    {
        School资产处置BLL zcztbll = new School资产处置BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = zcztbll.DataSet资产状态查询("","资产状态-全部");
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                DataTable source = dt;
                // 3.绑定到Grid
                Grid1.DataSource = dt;//DataTable
                Grid1.DataBind();
              
            }
        }
        //private void BindGrid()
        //{
        //    DataSet ds = zcztbll.查询全部资产信息();
        //    DataTable dt = ds.Tables[0].Copy();//复制一份table
        //    DataTable source = dt;

        //    // 3.绑定到Grid
        //    Grid1.DataSource = dt;//DataTable
        //    Grid1.DataBind();
        //}

        //protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        //{
        //    BindGrid();
        //}


        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                //Window3.Hidden = false;


            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string flowstate = DropDownList1.SelectedText;
            DataSet ds = zcztbll.DataSet资产状态查询(ttSearch.Text, flowstate);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;
            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
            
        }



        protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
        {
            string sSearch = ttSearch.Text.ToString();
            Console.Write("取到的结果为：" + sSearch);
            DataSet ds = zcztbll.DataSet资产状态查询(sSearch, DropDownList1.SelectedText);


            DataTable dt = ds.Tables[0].Copy();//复制一份table
         
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
           
        }


    }
}       