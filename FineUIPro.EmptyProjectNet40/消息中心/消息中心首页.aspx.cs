using System;
using PLM_Common;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using PLM.BusinessRlues;
using PLM_Model;

namespace FineUIPro.EmptyProjectNet40.消息中心
{
    public partial class 消息中心首页 : System.Web.UI.Page
    {
        AM_提醒通知BLL bll = new AM_提醒通知BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = bll.全部消息();
                DataTable dt = ds.Tables[0];
                Grid1.DataSource = dt;
                Grid1.DataBind();
                int xx = bll.默认消息数();
                Label1.Text = "<span style='color:red;font-weight:bold;'>" + xx + "</span>条未读数据";
                // 删除选中单元格的客户端脚本
               // 下拉();


            }
        }
        protected void 下拉()
        {

            DataSet ds = bll.xiala();
            DataTable dt = ds.Tables[0];
            通知类型.DataTextField = "通知类型";
            通知类型.DataValueField = "通知类型";
            通知类型.DataSource = dt;
            通知类型.DataBind();
            通知类型.Items.Insert(0, new FineUIPro.ListItem("全部", "0"));
            通知类型.Items[0].Selected = true;
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            Confirm.GetShowReference("全部设为已读？", String.Empty, MessageBoxIcon.Warning, bll.全部已读().ToString(), string.Empty, Target.Self);
            bind();
        }
        protected void bind()
        {
            DataSet ds = bll.全部消息();
            DataTable dt = ds.Tables[0];
            Grid1.DataSource = dt;
            Grid1.DataBind();
        }



        protected void btnExpandRowExpanders_Click(object sender, EventArgs e)
        {
            Grid1.ExpandRowExpanders();
        }


        protected void btnCollapseRowExpanders_Click(object sender, EventArgs e)
        {
            Grid1.CollapseRowExpanders();
        }

        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            Grid1.SelectAllRows();
        }

        protected void btnClearSelect_Click(object sender, EventArgs e)
        {
            Grid1.SelectedRowIndexArray = null;
        }

        protected void 通知类型_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (通知类型.SelectedText == "待办事项通知")
            {
                string str = "待办事项通知";
                DataSet ds = bll.条件查询(str);
                DataTable dt = ds.Tables[0];
                Grid1.DataSource = dt;
                Grid1.DataBind();
                int xx = bll.条件消息数(str);
                Label1.Text = "<span style='color:red;font-weight:bold;'>" + xx + "</span>条未读数据";
            }
            if (通知类型.SelectedText == "结果反馈通知")
            {
                string str = "结果反馈通知";
                DataSet ds = bll.条件查询(str);
                DataTable dt = ds.Tables[0];
                Grid1.DataSource = dt;
                Grid1.DataBind();
                int xx = bll.条件消息数(str);
                Label1.Text = "<span style='color:red;font-weight:bold;'>" + xx + "</span>条未读数据";
            }
            if (通知类型.SelectedValue == "全部消息")
            {
                DataSet ds = bll.全部消息();
                DataTable dt = ds.Tables[0];
                Grid1.DataSource = dt;
                Grid1.DataBind();
                int xx = bll.默认消息数();
                Label1.Text = "<span style='color:red;font-weight:bold;'>" + xx + "</span>条未读数据";
            }
        }



        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;

            string yen = row["是否已读"].ToString();
            BoundField cyen = Grid1.FindColumn("是否已读") as BoundField;
            //cyen.Attributes.Remove("data-color");
            if (yen == "是")
            {

                e.CellCssClasses[cyen.ColumnIndex - 4] = "color1";
            }
            else if (yen == "否")
            {
                e.CellCssClasses[cyen.ColumnIndex - 4] = "color2";
                e.CellAttributes[cyen.ColumnIndex]["data-color"] = "color2";

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int id;
            int selectedCount = Grid1.SelectedRowIndexArray.Length;
            if (selectedCount > 0)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid1.SelectedRowIndexArray[i];
                    if (Grid1.AllowPaging && !Grid1.IsDatabasePaging)
                    {
                        rowIndex = Grid1.PageIndex * Grid1.PageSize + rowIndex;
                        id = Convert.ToInt32(Grid1.DataKeys[rowIndex][0]);
                        int xx = bll.选中已读(id);
                        if (xx == 0)
                        {
                            Alert.ShowInTop("更新失败！");
                            return;
                        }
                    }
                    else
                    {
                        Alert.ShowInTop("更新失败！");
                    }
                }
                Alert.ShowInTop("更新成功！");
                bind();
            }
            else
            {
                Alert.ShowInTop("没有选中任何一行！");
            }

        }



    }
}