using System;
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


namespace FineUIPro.EmptyProjectNet40.报修管理
{
    public partial class 资产报修 : PageBase
    {
        School资产报修BLL bll = new School资产报修BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = bll.首页_X_资产报修流程表("全部");
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                DataTable source = dt;

                // 3.绑定到Grid
                Grid1.DataSource = dt;//DataTable
                Grid1.DataBind();
                DateTime dtime = DateTime.Now;
                string sj = dtime.Year + "-" + dtime.Month + "-" + dtime.Day;
                报修时间2.EmptyText = sj;
                DatePicker1.EmptyText = sj;
                完成时间.EmptyText = sj;
                List<School房间信息表> cfdd = bll.cfdd();
                报修地址.DataTextField = "名称";
                报修地址.DataValueField = "ID";
                报修地址.DataSource = cfdd;
                报修地址.DataBind();

                //DatePicker1.MinDate = DateTime.Now;
                //DatePicker1.MaxDate = DateTime.Now.AddDays(10);


                // 3.绑定到Grid
                Grid4.DataSource = dt;//DataTable
                Grid4.DataBind();
                //绑定条件
                School清查盘点BLL pdbll = new School清查盘点BLL();

                List<School一级部门表> xxmc = pdbll.查询一级部门();
                部门.DataTextField = "名称";
                部门.DataValueField = "ID";
                部门.DataSource = xxmc;
                部门.DataBind();

                List<School一级类别表> yjlb = pdbll.查询一级类别();
                一级.DataTextField = "名称";
                一级.DataValueField = "ID";
                一级.DataSource = yjlb;
                一级.DataBind();


                List<School建筑物信息表> 查询建筑物 = pdbll.查询建筑物信息表();
                存放地点.DataTextField = "名称";
                存放地点.DataValueField = "ID";
                存放地点.DataSource = 查询建筑物;
                存放地点.DataBind();


                二级.Enabled = false;
                三级.Enabled = false;
                负责人.Enabled = false;
                房间.Enabled = false;

                二级.EmptyText = "全部";
                三级.EmptyText = "全部";
                负责人.EmptyText = "全部";
                房间.EmptyText = "全部";
            }
        }




        protected void btnIcon1_Click(object sender, EventArgs e)
        {

            School资产处置BLL bll = new School资产处置BLL();
            DataSet ds = bll.查询全部资产信息();
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;


            // 3.绑定到Grid
            Grid4.DataSource = dt;//DataTable
            Grid4.DataBind();
            //绑定条件
            School清查盘点BLL pdbll = new School清查盘点BLL();

            List<School一级部门表> xxmc = pdbll.查询一级部门();
            部门.DataTextField = "名称";
            部门.DataValueField = "ID";
            部门.DataSource = xxmc;
            部门.DataBind();

            List<School一级类别表> yjlb = pdbll.查询一级类别();
            一级.DataTextField = "名称";
            一级.DataValueField = "ID";
            一级.DataSource = yjlb;
            一级.DataBind();


            List<School建筑物信息表> 查询建筑物 = pdbll.查询建筑物信息表();
            存放地点.DataTextField = "名称";
            存放地点.DataValueField = "ID";
            存放地点.DataSource = 查询建筑物;
            存放地点.DataBind();


            二级.Enabled = false;
            三级.Enabled = false;
            负责人.Enabled = false;
            房间.Enabled = false;

            二级.EmptyText = "全部";
            三级.EmptyText = "全部";
            负责人.EmptyText = "全部";
            房间.EmptyText = "全部";



            Window2.Hidden = false;
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Window1.Hidden = true;
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Window1.Hidden = false;
            School清查盘点BLL pdbll = new School清查盘点BLL();
            List<School建筑物信息表> 查询建筑物 = pdbll.查询建筑物信息表();
            报修地址.DataTextField = "名称";
            报修地址.DataValueField = "ID";
            报修地址.DataSource = 查询建筑物;
            报修地址.DataBind();
            DateTime dt = DateTime.Now;
            string y = dt.Year.ToString();
            string m = dt.Month.ToString();
            string d = dt.Day.ToString();
            string h = dt.Hour.ToString();
            string mm = dt.Minute.ToString();
            报修单号.Text = "ZCBX" + y + m + d + h + mm;
            报修单号.Enabled = false;
            OffSession();
            string nm = HttpContext.Current.Session["姓名"].ToString();
            if (nm == "" || nm == null)
            {
                Alert.ShowInTop("验证过期，请重新登陆！");
                return;
            }
            报修人.Text = HttpContext.Current.Session["姓名"].ToString();
        }
        protected void 报修地址_SelectedIndexChanged(object sender, EventArgs e)
        {

            int ID = Convert.ToInt32(报修地址.SelectedValue);
            if (ID > 0)
            {
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School房间信息表> 查询房间信息 = pdbll.查询房间信息表(ID);
                房间1.DataTextField = "名称";
                房间1.DataValueField = "ID";
                房间1.DataSource = 查询房间信息;
                房间1.DataBind();

            }

        }




        //上传图片
        public Boolean ImageType()
        {
            string fileName = filePhoto.ShortFileName;
            string ll = fileName.Substring(fileName.IndexOf("."), fileName.Length - fileName.IndexOf("."));
            if (ll == ".png" || ll == ".jpg" || ll == ".tiff" || ll == ".gif" || ll == ".bmp" || ll == ".ico" || ll == ".PNG" || ll == ".JPG" || ll == ".TIFF" || ll == ".GIF" || ll == ".ICO" || ll == ".BMP")
            {
                return true;
            }
            else
            {

                return false;

            }

        }
        protected void filePhoto_FileSelected(object sender, EventArgs e)
        {
            if (ImageType())
            {
                string fileName = filePhoto.ShortFileName;

                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;
                filePhoto.SaveAs(Server.MapPath("~/upload/" + fileName));
                imgPhoto.ImageUrl = "~/upload/" + fileName;
                cundi.Text= "~/upload/" + fileName;
                // 清空文件上传组件（上传后要记着清空，否则点击提交表单时会再次上传！！）
                //filePhoto.Reset();

            }
            else
            {
                Alert.ShowInTop("无效的文件类型！");
                return;
            }

        }





        protected void 一级_SelectedIndexChanged(object sender, EventArgs e)
        {
            二级.Enabled = true;
            int ID = Convert.ToInt32(一级.SelectedValue);
            if (ID > 0)
            {
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School二级类别表> listuser = pdbll.查询二级类别(ID);
                二级.DataTextField = "名称";
                二级.DataValueField = "ID";
                二级.DataSource = listuser;
                二级.DataBind();
            }
        }

        protected void 二级_SelectedIndexChanged(object sender, EventArgs e)
        {
            三级.Enabled = true;
            int ID = Convert.ToInt32(二级.SelectedValue);
            if (ID > 0)
            {
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School三级类别表> listuser = pdbll.查询三级类别(ID);
                三级.DataTextField = "名称";
                三级.DataValueField = "ID";
                三级.DataSource = listuser;
                三级.DataBind();
            }
        }

        protected void 部门_SelectedIndexChanged(object sender, EventArgs e)
        {
            负责人.Enabled = true;
            int ID = Convert.ToInt32(部门.SelectedValue);
            if (ID > 0)
            {
                List<用户表> listuser = bll.listuser(ID);
                负责人.DataTextField = "姓名";
                负责人.DataValueField = "ID";
                负责人.DataSource = listuser;
                负责人.DataBind();
            }
        }

        protected void 存放地点_SelectedIndexChanged(object sender, EventArgs e)
        {
            房间.Enabled = true;
            int ID = Convert.ToInt32(存放地点.SelectedValue);
            if (ID > 0)
            {
                School清查盘点BLL pdbll = new School清查盘点BLL();
                List<School房间信息表> 查询房间信息 = pdbll.查询房间信息表(ID);
                房间.DataTextField = "名称";
                房间.DataValueField = "ID";
                房间.DataSource = 查询房间信息;
                房间.DataBind();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            School查询办公设备条件表 model = new School查询办公设备条件表();
            string str一级 = 一级.SelectedText;
            string str二级 = 二级.SelectedText;
            string str三级 = 三级.SelectedText;
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
            string str部门 = 部门.SelectedText;
            if (str部门 != "全部" && str部门 != null)
            {
                model.归属部门 = Convert.ToInt32(部门.SelectedValue);
                if (负责人.SelectedText != null)
                {
                    model.负责人 = Convert.ToInt32(负责人.SelectedValue);
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

            if (存放地点.SelectedText != null)
            {
                model.存放地点 = Convert.ToInt32(存放地点.SelectedValue);
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
            Grid4.DataSource = dt;//DataTable
            Grid4.DataBind();

            //二级.Enabled = false;
            //三级.Enabled = false;
            //负责人.Enabled = false;
            //房间.Enabled = false;

            二级.EmptyText = "全部";
            三级.EmptyText = "全部";
            负责人.EmptyText = "全部";
            房间.EmptyText = "全部";

        }





        protected void DropDownListdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            string flowstate = DropDownList1.SelectedText;

            DataSet ds = bll.首页_X_资产报修流程表(flowstate);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;

            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }
        protected void grid1_bind()
        {
            DataSet ds = bll.首页_X_资产报修流程表("全部", "");
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;

            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }


        protected void Button5_Click(object sender, EventArgs e)
        {
            string sid = "";
            List<int> inlist = new List<int>();

            //获取grid3选中行数据
            int[] selections = Grid4.SelectedRowIndexArray;

            foreach (int rowIndex in selections)
            {
                int ID = Convert.ToInt32(Grid4.DataKeys[rowIndex][0]);
                sid += rowIndex.ToString() + ",";
                inlist.Add(ID);
            }
            if (inlist.Count == 0)
            {
                Alert.ShowInTop("请选中！", "提示信息", MessageBoxIcon.Warning);
                return;
            }

            List<School办公设备信息表> listdata = bll.资产转移确定设备(inlist);


            Grid2.DataSource = listdata;//DataTable
            Grid2.DataBind();
            Window2.Hidden = true;



            //获取填写数据

        }


        //protected void bind()
        //{
        //    SqlConnection myConn = new SqlConnection();
        //    myConn.ConnectionString = "Data Source=114.115.220.70;Initial Catalog=SZ_sbgl4z;User ID=sa;Password=Bitsoft123;Integrated Security=false;Connect Timeout=30";
        //    myConn.Open();
        //    string sqlStr = "select * from X_资产报修流程表";
        //    SqlDataAdapter myDa = new SqlDataAdapter(sqlStr, myConn);
        //    DataSet myDs = new DataSet();
        //    myDa.Fill(myDs);
        //    Grid1.DataSource = myDs;

        //    Grid1.DataBind();
        //    myDa.Dispose();
        //    myDs.Dispose();
        //    myConn.Close();
        //}
        protected void Button2_Click(object sender, EventArgs e)
        {
            SchoolX_资产报修流程表 model = new SchoolX_资产报修流程表();
            if (Grid2.Rows.Count == 0)
            {
                Alert.ShowInTop("请先添加资产！", "提示信息", MessageBoxIcon.Warning);
                return;
            }
            DateTime dtime = DateTime.Now;
            string sj = dtime.Year + "-" + dtime.Month + "-" + dtime.Day;
            //获取报修时间参数
            if (报修时间2.EmptyText != null && 报修时间2.Text == "")
            {
                报修时间2.Text = 报修时间2.EmptyText;
            }
            if (报修时间2.Text.ToString() != null && 报修时间2.Text.ToString() != "")
            {
                DateTime date = DateTime.Parse(报修时间2.Text);
                
                string Y = date.Year.ToString();            //年
                string M = date.Month.ToString();           //月
                string D = date.Day.ToString();             //日
                string h = Y + "-" + M + "-" + D;           //拼接年月日
                string di = 报修地址.SelectedText;            //获取选中的一级地点
                string fang = 房间1.SelectedText;           //获取选中的二级地点
                int[] selections = Grid4.SelectedRowIndexArray;
                model.设备ID = "";
                foreach (int rowIndex in selections)
                {

                    int ID = Convert.ToInt32(Grid4.DataKeys[rowIndex][0]);
                    string xxx = Grid4.DataKeys[rowIndex][0].ToString();
                    string ss = xxx;

                    model.设备ID += ID.ToString() + ",";

                    //sb.AppendFormat("行号:{0} 用户名:{1}<br />", rowIndex + 1, Grid1.DataKeys[rowIndex][1]);
                }


                if (报修人.Text != "" && 联系电话.Text != "" && h != "" && 报修单号.Text != "" && di != "" && 故障描述.Text != "")
                {
                    //判断二级地点是否为空
                    if (房间1.SelectedText == "" || 房间1.SelectedText == null)
                    {
                        model.报修地址 = di;
                    }
                    else
                    {
                        string F1 = "—" + fang;
                        model.报修地址 = di + F1;
                    }
                    if (报修地址.Text == "全部")
                    {
                        Alert.ShowInTop("请选择报修地址！");
                        return;
                    }
                    model.流程状态 = "待派单";
                    model.报修单号 = 报修单号.Text;
                    model.报修人 = 报修人.Text;
                    model.报修时间 = 报修时间2.Text;
                    model.故障描述 = 故障描述.Text;
                    string fileName = filePhoto.ShortFileName;

                    fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                    fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;
                    filePhoto.SaveAs(Server.MapPath("~/upload/" + fileName));
                    imgPhoto.ImageUrl = "~/upload/" + fileName;
                    model.故障照片 = "~/upload/" + fileName;
                    model.报修人电话 = 联系电话.Text;
                    //model.报修单号 

                    AM_提醒通知 ammodel = new AM_提醒通知();
                    OffSession();
                    ammodel.发起时间 = DateTime.Now;
                    ammodel.是否已读 = "否";
                    ammodel.通知类型 = "待办事项通知";
                    ammodel.通知职务 = "资产管理员";
                    ammodel.发起人 = Session["姓名"].ToString();
                    ammodel.消息内容 = "您来自" + ammodel.发起人 + "的资产报修申请,请及时处理！";
                    ammodel.消息事项 = "资产报修";
                    ammodel.是否已读 = "否";
                    AM_待办业务 dbmodel = new AM_待办业务();
                    dbmodel.处理职务 = "资产管理员";
                    dbmodel.处理方式 = "职务";
                    dbmodel.FlowName = "资产报修";
                    dbmodel.Sort = 1;
                    dbmodel.流程状态 = model.流程状态;
                    dbmodel.事项名称 = "资产报修";
                    dbmodel.发起人 = Session["姓名"].ToString();
                    dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产报修申请,请及时处理！";
                    dbmodel.发起时间 = DateTime.Now.ToLongDateString();

                    int xx = bll.添加资产报修表(model, ammodel, dbmodel);
                    if (xx > 0)
                    {
                        Alert.ShowInTop("提交成功！", "提示信息", MessageBoxIcon.Information);
                        Window1.Hidden = true;
                        DataSet ds = bll.首页_X_资产报修流程表("全部");
                        DataTable dt = ds.Tables[0].Copy();//复制一份table
                        DataTable source = dt;

                        //绑定到Grid
                        Grid1.DataSource = dt;//DataTable
                        Grid1.DataBind();

                        return;
                    }
                    else
                    {
                        Alert.ShowInTop("添加失败！", "提示信息", MessageBoxIcon.Warning);
                        return;
                    }

                    //   string sql="insert into dbo.X_资产报修成表 流程状态,报修单号,报修人,报修时间,报修地址,故障描述,维修人员,完工时间,结果反馈 values(1,'"+报修单号.Text+"','"+报修人.Text+"','"+h+"','"+fang+"','"+故障描述.Text+"')";   


                }
                else
                {
                    Alert.ShowInTop("请填写完整信息！", "提示信息", MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                Alert.ShowInTop("请填写完整信息！", "提示信息", MessageBoxIcon.Warning);
                return;
            }


        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string flowstate = DropDownList1.SelectedText;
            DataSet ds = bll.首页_X_资产报修流程表("全部");

            if (flowstate == "待派单")
            {
                ds = bll.首页_X_资产报修流程表("待派单");
            }
            else if (flowstate == "维修中")
            {
                ds = bll.首页_X_资产报修流程表("维修中");
            }
            else if (flowstate == "维修完成")
            {
                ds = bll.首页_X_资产报修流程表("维修完成");
            }
            else if (flowstate == "已完成")
            {
                ds = bll.首页_X_资产报修流程表("已完成");
            }

            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;

            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
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



        //点击查看详情
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                OffSession();
                string username = Session["姓名"].ToString();
                流程状态待派单.Hidden = false;
                object[] keys = Grid1.DataKeys[e.RowIndex];
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
               
                int Sort = Convert.ToInt32(keys[9].ToString());

                string 流程状态 = keys[1].ToString();
                if (流程状态 == "待派单")
                {
                    Button9.Text = "提交派单";
                }
                else if (流程状态 == "派单中")
                {
                    Button9.Text = "提交维修";
                }
                else if (流程状态=="维修完成")
                {
                    Button9.Text = "完成提交";
                }



                xx.Text = ID.ToString();
                查看报修人.Text = keys[3].ToString();
                查看报修时间.Text = keys[4].ToString();
                查看单号.Text = keys[2].ToString();
                查看报修地址.Text = keys[5].ToString();

                string zt = keys[1].ToString();
                SchoolX_资产报修流程表 model = bll.详情(ID);
                if (model.派单时间 != "" && model.派单时间 != null)
                {
                    TextBox9.Text = model.派单时间;
                }
                else
                {
                    TextBox9.Text = "未完成";
                }
                TextBox5.Text = "未完成";
                TextBox6.Text = "未完成";
                TextBox8.Text = "未完成";
                TextBox9.Text = "未完成";
                TextBox10.Text = "未完成";
                TextBox11.Text = "未完成";
                TextBox12.Text = "未完成";
                查看故障描述.Text = "未完成";
                TextBox13.Text = "未完成";
                if (model.维修人员 != "" & model.维修人员 != null)
                {
                    TextBox5.Text = model.维修人员;
                }
                if (model.维修人电话 != "" && model.维修人电话 != null)
                {
                    TextBox11.Text = model.维修人电话;
                }
                if (model.解决时间 != "" && model.解决时间 != null)
                {
                    TextBox6.Text = model.解决时间;
                }
                if (model.管理员 != "" && model.管理员 != null)
                {
                    TextBox8.Text = model.管理员;
                }
                if (model.派单时间 != "" && model.派单时间 != null)
                {
                    TextBox9.Text = model.派单时间;
                }
                if (model.报修人电话 != "" && model.报修人电话 != null)
                {
                    TextBox10.Text = model.报修人电话;
                }
                if (model.维修人电话 != "" && model.维修人电话 != null)
                {
                    TextBox11.Text = model.维修人电话;
                }
                if (model.管理员电话 != "" && model.管理员电话 != null)
                {
                    TextBox12.Text = model.管理员电话;
                }
                if (model.结果反馈 != "" && model.结果反馈 != null)
                {
                    TextBox13.Text = model.结果反馈;
                }
                if (model.故障原因 != "" && model.故障原因 != null)
                {
                    查看故障描述.Text = model.故障原因;
                }
                if (zt == "已完成")
                {
                    Button9.Hidden = true;
                    Button3.Text = "关闭";
                }
                else
                {
                    Button9.Hidden = false;
                    Button3.Text = "拒绝";
                }
                try
                {
                    string iamgeurl = keys[11].ToString();

                    Image2.ImageUrl = iamgeurl;
                }
                catch (Exception)
                {


                }
                List<int> inlist = new List<int>();
                string[] sbid = keys[12].ToString().Split(',');
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
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            流程状态待派单.Hidden = true;
        }


        protected void Unnamed_SelectedIndexChanged(object sender, EventArgs e)
        {
            string state = Unnamed.SelectedValue;

            if (Unnamed.SelectedValue == "报修大厅")
            {
                Unnamed.SelectedValue = "报修大厅";
                state = "报修大厅";
                DataSet ds = bll.首页_X_资产报修流程表(DropDownList1.SelectedText, state);
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                // 3.绑定到Grid
                Grid1.DataSource = dt;//DataTable
                Grid1.DataBind();

            }
            else if (Unnamed.SelectedValue == "我的报修")
            {
                Unnamed.SelectedValue = "我的报修";
                if (HttpContext.Current.Session["用户名"].ToString() == null || HttpContext.Current.Session["用户名"].ToString() == "")
                {
                    Alert.ShowInTop("验证过期，请重新登陆！");
                    return;
                }
                state = HttpContext.Current.Session["用户名"].ToString();
                DataSet ds = bll.首页_X_资产报修流程表(DropDownList1.SelectedText, state);
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                // 3.绑定到Grid
                Grid1.DataSource = dt;//DataTable
                Grid1.DataBind();
            }
        }

        protected void 查看图片_Click(object sender, EventArgs e)
        {
            object a = Grid1.SelectedRow.DataKeys[11];
            string xx = a.ToString();
            if (xx == "" || xx == null)
            {
                Alert.ShowInTop("照片未上传！");
                return;
            }
            else
            {
                Window3.Hidden = false;
            }

        }

        protected void Button9_Click1(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            School资产报修BLL bll = new School资产报修BLL();
                string xa = bll.用户权限(ID);
            object a = Grid1.SelectedRow.DataKeys[0];
            int xx = Convert.ToInt32(a);
            int sort = Convert.ToInt32(Grid1.SelectedRow.DataKeys[9]);
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
                ammodel.消息内容 = "您来自" + ammodel.发起人 + "的资产报修维修申请,请及时处理！";
                ammodel.消息事项 = "资产报修";
                ammodel.是否已读 = "否";
                AM_待办业务 dbmodel = new AM_待办业务();                
                dbmodel.处理方式 = "个人";
                dbmodel.处理人= DropDownList3.SelectedText;
                dbmodel.Sort = 2;
                dbmodel.流程状态 = model.流程状态;
                dbmodel.事项名称 = "资产报修";
                dbmodel.FlowName = "资产报修";
                dbmodel.发起人 = Session["姓名"].ToString();
                dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产报修维修申请,请及时处理！";
                dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                School资产报修BLL bll = new School资产报修BLL();
                object a = Grid1.SelectedRow.DataKeys[0];
                int id = Convert.ToInt32(a);
                int xx = bll.添加维修信息(id, model, ammodel, dbmodel);
                if (xx > 0)
                {
                    grid1_bind();
                    Window4.Hidden = true;
                    流程状态待派单.Hidden = true;
                    Alert.ShowInTop("提交成功！");
                }
                else
                {
                    grid1_bind();
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
                object a = Grid1.SelectedRow.DataKeys[0];
                int id = Convert.ToInt32(a);
                AM_提醒通知 ammodel = new AM_提醒通知();

                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "待办事项通知";
                ammodel.通知职务 = "发起人";
                ammodel.发起人 = Session["姓名"].ToString();
                ammodel.消息内容 = "您来自" + ammodel.发起人 + "的资产报修完成申请,请及时处理！";
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
                    grid1_bind();
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

        protected void Button11_Click(object sender, EventArgs e)
        {
            object a = Grid1.SelectedRow.DataKeys[0];
            int id = Convert.ToInt32(a);
            SchoolX_资产报修流程表 model = new SchoolX_资产报修流程表();
            model.完工时间 = DatePicker2.Text;
            model.结果反馈 = 结果反馈.Text;
            model.流程状态 = "已完成";
            AM_提醒通知 ammodel = new AM_提醒通知();

            ammodel.发起时间 = DateTime.Now;
            ammodel.是否已读 = "否";
            ammodel.通知类型 = "结果反馈通知";
            ammodel.通知职务 = "发起人";
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
                grid1_bind();
                return;
            }
            else
            {
                Alert.ShowInTop("提交错误！");
            }

        }

        protected string GetEditUrls(object id, object sort)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("事项名称", "事项名称" + id);
            joBuilder.AddProperty("title", "流程进度 - " + id);
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("School资产报修流程进度.aspx?SBBH={0}&sort={1}", id, HttpUtility.UrlEncode(sort.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }

    }
}