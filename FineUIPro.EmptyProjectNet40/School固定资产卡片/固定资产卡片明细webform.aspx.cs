
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

using System.Linq;
using PLM_Model;
using PLM.BusinessRlues;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;


namespace FineUIPro.EmptyProjectNet40.固定资产卡片明细
{
    public partial class 固定资产卡片明细webform : PageBase
    {
        School资产处置BLL bll = new School资产处置BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OffSession();

                二级分类.Enabled = false;
                三级分类.Enabled = false;
                负责人_a.Enabled = false;
                房间.Enabled = false;
               
                BindGrid();

                //BindGrid();
                //btnCheckSelection.OnClientClick = Grid2.GetNoSelectionAlertReference("请至少选择一项！");

                School清查盘点BLL pdbll = new School清查盘点BLL();

                List<School一级部门表> xxmc = pdbll.查询一级部门();
                部门归属.DataTextField = "名称";
                部门归属.DataValueField = "ID";
                部门归属.DataSource = xxmc;
                部门归属.DataBind();
                部门归属.EmptyText = "全部";

                List<School一级类别表> yjlb = pdbll.查询一级类别();
                一级分类.DataTextField = "名称";
                一级分类.DataValueField = "ID";
                一级分类.DataSource = yjlb;
                一级分类.DataBind();
                一级分类.EmptyText = "全部";

                List<School建筑物信息表> 查询建筑物 = pdbll.查询建筑物信息表();
                存放地点_a.DataTextField = "名称";
                存放地点_a.DataValueField = "ID";
                存放地点_a.DataSource = 查询建筑物;
                存放地点_a.DataBind();
                存放地点_a.EmptyText = "全部";

                二级分类.Enabled = false;
                三级分类.Enabled = false;
                负责人_a.Enabled = false;
                房间.Enabled = false;

                二级分类.EmptyText = "全部";
                三级分类.EmptyText = "全部";
                负责人_a.EmptyText = "全部";
                房间.EmptyText = "全部";
            }


        }

        private void OffSession()
        {
            try
            {
                if (Session["用户名"].ToString() == null)
                {
                    Alert.ShowInTop("Session已失效,跳转登录页面！");
                    System.Diagnostics.Process.Start("http://localhost:2850/LoginTest.aspx");
                    return;
                }
                else
                {
                    //不等于null
                }
            }
            catch (Exception)
            {
                Alert.ShowInTop("Session已失效,跳转登录页面！");
                System.Diagnostics.Process.Start("http://localhost:2850/LoginTest.aspx");
                return;
            }
        }

        #region BindGrid

   
        
      


        protected void Grid2_PageIndexChange(object sender, GridPageEventArgs e)
        {
            BindGrid();
        }
        
        private List<School办公设备信息表> GetPagedDataTable()
        {

            //默认 没有条件查询 内存分页
            School资产卡片BLL zckpbll = new School资产卡片BLL();
            List<School办公设备信息表> list = zckpbll.查询所有资产();
            return list;
        }



        #endregion

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindGrid();
        //}

        protected void Grid2_Sort(object sender, GridSortEventArgs e)
        {
            //ShowNotify(e.SortField);

        }




        private void BindGrid()
        {
            DataSet ds = bll.查询全部资产信息();
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;

            // 3.绑定到Grid
            Grid2.DataSource = dt;//DataTable
            Grid2.DataBind();
        }

        protected void Grid2_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            // 如果绑定到 DataTable，那么这里的 DataItem 就是 DataRowView
            //DataRowView row = e.DataItem as DataRowView;
            //int rowId = Convert.ToInt32(row["ID"]);

            //LinkButtonField editField = Grid2.FindColumn("Edit") as LinkButtonField;
            //editField.OnClientClick = String.Format("showEditWindow('{0}');", rowId);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string ids;
            List<string> SelectedRowIDArray = new List<string>(Grid2.SelectedRowIDArray);
            List<string> newselectIdRows = new List<string>();
            for (int i = 0; i < SelectedRowIDArray.Count; i++)
            {
                newselectIdRows.Add(SelectedRowIDArray[i].Replace("frow", ""));
            }
            for (int j = 0; j < newselectIdRows.Count; j++)
            {
                sb.AppendFormat(",{0}", Grid2.DataKeys[Convert.ToInt32(newselectIdRows[j])][0]);
                //sb.AppendFormat(",{0}", Grid2.DataKeys[Convert.ToInt32(newselectIdRows[j])][1]);
            }
            ids = sb.ToString().Substring(1);
        }



        protected void btnClose_Click(object sender, EventArgs e)
        {
            Window1.Hidden = true;
        }

        protected void 一级分类_SelectedIndexChanged(object sender, EventArgs e)
        {

            int ID = Convert.ToInt32(一级分类.SelectedValue);
            if (ID > 0)
            {
                二级分类.Enabled = true;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School二级类别表> listuser = pdbll.查询二级类别(ID);
                二级分类.DataTextField = "名称";
                二级分类.DataValueField = "ID";
                二级分类.DataSource = listuser;
                二级分类.DataBind();
            }
            else
            {
                二级分类.Enabled = false;
                三级分类.Enabled = false;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School二级类别表> listuser = pdbll.查询二级类别(ID);
                二级分类.DataTextField = "名称";
                二级分类.DataValueField = "ID";
                二级分类.DataSource = listuser;
                三级分类.DataSource = listuser;
                二级分类.DataBind();
                三级分类.DataBind();
            }
            
        }

        protected void 二级分类_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(二级分类.SelectedValue);
            if (ID > 0)
            {
                三级分类.Enabled = true;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School三级类别表> listuser = pdbll.查询三级类别(ID);
                三级分类.DataTextField = "名称";
                三级分类.DataValueField = "ID";
                三级分类.DataSource = listuser;
                三级分类.DataBind();
            }
            else
            {
                三级分类.Enabled = false;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School三级类别表> listuser = pdbll.查询三级类别(ID);
                三级分类.DataTextField = "名称";
                三级分类.DataValueField = "ID";
                三级分类.DataSource = listuser;
                三级分类.DataBind();
            }
        }

        protected void 部门归属_SelectedIndexChanged(object sender, EventArgs e)
        {
            负责人_a.Enabled = true;
            int ID = Convert.ToInt32(部门归属.SelectedValue);
            if (ID > 0)
            {
                School资产转移BLL zybll = new School资产转移BLL();
                List<用户表> listuser = zybll.listuser(ID);
                负责人_a.DataTextField = "姓名";
                负责人_a.DataValueField = "ID";
                负责人_a.DataSource = listuser;
                负责人_a.DataBind();
            }
            else
            {
                负责人_a.Enabled = false;
                School资产转移BLL zybll = new School资产转移BLL();
                List<用户表> listuser = zybll.listuser(ID);
                负责人_a.DataTextField = "姓名";
                负责人_a.DataValueField = "ID";
                负责人_a.DataSource = listuser;
                负责人_a.DataBind();
            }
            //int ID = Convert.ToInt32(部门归属.SelectedValue);
            //if (ID > 0)
            //{
            //    负责人_a.Enabled = true;
            //    资产转移BLL zybll = new 资产转移BLL();
            //    List<用户表> listuser = zybll.listuser(ID);
            //    负责人_a.DataTextField = "姓名";
            //    负责人_a.DataValueField = "ID";
            //    负责人_a.DataSource = listuser;
            //    负责人_a.DataBind();
            //}
            //else
            //{
            //    负责人_a.Enabled = false;
            //    资产转移BLL zybll = new 资产转移BLL();
            //    List<用户表> listuser = zybll.listuser(ID);
            //    负责人_a.DataTextField = "姓名";
            //    负责人_a.DataValueField = "ID";
            //    负责人_a.DataSource = listuser;
            //    负责人_a.DataBind();
            //}
        }

        protected void 存放地点_a_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(存放地点_a.SelectedValue);
            if (ID > 0){
                房间.Enabled = true;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School房间信息表> 查询房间信息 = pdbll.查询房间信息表(ID);
                房间.DataTextField = "名称";
                房间.DataValueField = "ID";
                房间.DataSource = 查询房间信息;
                房间.DataBind();
            }
            else 
            {
                房间.Enabled = false;
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School房间信息表> 查询房间信息 = pdbll.查询房间信息表(ID);
                房间.DataTextField = "名称";
                房间.DataValueField = "ID";
                房间.DataSource = 查询房间信息;
                房间.DataBind();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            School查询办公设备条件表 model = new School查询办公设备条件表();
            string str一级 = 一级分类.SelectedText;
            string str二级 = 二级分类.SelectedText;
            string str三级 = 三级分类.SelectedText;
            if (str一级 == "全部" || str一级 == null)
            {
                str一级 = "";
            }
            if (str二级 == "全部" || str二级 == null)
            {
                str二级 = "";               
            }
            if (str三级 == "全部" || str三级 == null)
            {
                str三级 = "";
            }

            model.一级分类 = str一级;
            model.二级分类 = str二级;
            model.三级分类 = str三级;
            string str部门 = 部门归属.SelectedText;


            
            if (str部门 != "全部" && str部门 != null)
            {
                model.归属部门 = Convert.ToInt32(部门归属.SelectedValue);
                if (部门归属.SelectedText != null)
                {
                    model.负责人 = Convert.ToInt32(负责人_a.SelectedValue);
                }
                else
                {
                    model.负责人 = 0;
                }
            }
            else
            {
                model.归属部门 = 0;
            }


            if (存放地点_a.SelectedText != null)
            {
                model.存放地点 = Convert.ToInt32(存放地点_a.SelectedValue);
                if (房间.SelectedText != null)
                {
                    model.房间 = Convert.ToInt32(房间.SelectedValue);
                }
                else
                {
                    model.房间 = 0;
                }
            }
            else
            {
                model.存放地点 = 0;
            }

            if (起始投入日期.Text != "")
            {
                model.起始投入日期 = Convert.ToDateTime(起始投入日期.Text).ToShortDateString();
            }
            else
            {
                model.起始投入日期 = "";
            }
            if (结束投入日期.Text != "")
            {
                model.结束投入日期 = Convert.ToDateTime(结束投入日期.Text).ToShortDateString();
            }
            else
            {
                model.结束投入日期 = "";
            }


            model.关键字 = TwinTriggerBox1.Text;

            School资产处置BLL bll = new School资产处置BLL();
            DataSet ds = bll.查询全部资产信息(model);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;


            // 3.绑定到Grid
            Grid2.DataSource = dt;//DataTable
            Grid2.DataBind();

            //二级.Enabled = false;
            //三级.Enabled = false;
            //负责人.Enabled = false;
            //房间.Enabled = false;

            二级分类.EmptyText = "全部";
            三级分类.EmptyText = "全部";
            负责人_a.EmptyText = "全部";
            房间.EmptyText = "全部";
        }

        //查看图片


        protected void Grid2_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                //ID,编号,名称,资产状态,投入使用日期,型号,类型,价格,数量,使用方向
                object[] keys = Grid2.DataKeys[e.RowIndex];
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                if (ID > 0)
                {
                    资产编号.Text = keys[1].ToString();
                    资产名称.Text = keys[2].ToString();
                    资产状态.Text = keys[3].ToString();
                    try
                    {
                        投入使用日期.Text = keys[4].ToString();
                    }
                    catch (Exception)
                    {
                        
                       投入使用日期.Text = "";
                    }
                    资产型号.Text = keys[5].ToString();
                    资产类型.Text = keys[6].ToString();
                    try
                    {
                        资产价格.Text = keys[7].ToString();
                    }
                    catch (Exception)
                    {
                        
                      资产价格.Text = "0.0";
                    }
                    资产数量.Text = keys[8].ToString();
                    string xx = 资产编号.Text + "," + 资产名称.Text;
                    CreateQRImg(xx);
                    Window1.Hidden = false;
                }
            }
        }

        private void CreateQRImg(string str)
        {
            //Image2.Visible = true;
            Bitmap bt;
            string enCodeString = str;
            //生成设置编码实例
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            //设置二维码的规模，默认4
            qrCodeEncoder.QRCodeScale = 4;
            //设置二维码的版本，默认7
            qrCodeEncoder.QRCodeVersion = 7;
            //设置错误校验级别，默认中等
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            //生成二维码图片
            bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
            //二维码图片的名称
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss");
            //保存二维码图片在photos路径下
            bt.Save(Server.MapPath("~/photos/") + filename + ".jpg");
            //图片控件要显示的二维码图片路径
            this.Image3.ImageUrl = "~/photos/" + filename + ".jpg";
        }
        protected void TabStrip1_TabIndexChanged(object sender, EventArgs e)
        {
            if (TabStrip1.ActiveTabIndex == 0)
            {



            }
            else if (TabStrip1.ActiveTabIndex == 1)
            {
               

            }
            else if (TabStrip1.ActiveTabIndex == 2)
            {

            }
            else if (TabStrip1.ActiveTabIndex == 3)
            {
                //设备BOM
            }
            else if (TabStrip1.ActiveTabIndex == 4)
            {
           
            }
            else if (TabStrip1.ActiveTabIndex == 5)
            {
               

            }
        }




    }
}