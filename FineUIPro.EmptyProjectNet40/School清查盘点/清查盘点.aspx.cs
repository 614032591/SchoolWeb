using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FineUIPro.EmptyProjectNet40.清查盘点
{
    public partial class 清查盘点 : PageBase
    {
        School清查盘点BLL bll = new School清查盘点BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbxMyBox1.Enabled = false;
                TriggerBox1.Enabled = false;
                TriggerBox2.Enabled = false;
                TriggerBox3.Enabled = false;
                TriggerBox4.Enabled = false;
                drop.Enabled = false;

                //Button4.OnClientClick = Window8.GetShowReference();


               


                // 1.获取数据总数
                Grid1.RecordCount = 700;//测试，去数据库获取总数
                // 2.获取当前分页数据
                DataTable table = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);//查询方法
                // 3.绑定到Grid
                Grid1.DataSource = table;//DataTable
                Grid1.DataBind();

                //AutoBindGrid();
                //BindGrid();
                //btnCheckSelection.OnClientClick = Grid2.GetNoSelectionAlertReference("请至少选择一项！");
            }
        }

        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {

            DataSet ds = bll.DataSet清查盘点();
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;
            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Rows.Count)
            {
                rowend = source.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Rows[i]);
            }

            return paged;
        }


        protected void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Window2.Hidden = true;

            tbxMyBox1.Text = "弹出窗口被关闭了";
        }


        private void LoadData()
        {
            // 模拟从数据库返回数据表
            DataTable table = CreateDataTable();

            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            ds.Relations.Add("TreeRelation", ds.Tables[0].Columns["Id"], ds.Tables[0].Columns["ParentId"]);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.IsNull("ParentId"))
                {
                    TreeNode node = new TreeNode();
                    node.Text = row["Text"].ToString();
                    Tree1.Nodes.Add(node);

                    ResolveSubTree(row, node);
                }
            }
        }

        private void ResolveSubTree(DataRow dataRow, TreeNode treeNode)
        {
            DataRow[] rows = dataRow.GetChildRows("TreeRelation");
            if (rows.Length > 0)
            {
                // 如果是目录，则默认展开
                treeNode.Expanded = true;
                foreach (DataRow row in rows)
                {
                    TreeNode node = new TreeNode();
                    node.Text = row["Text"].ToString();
                    treeNode.Nodes.Add(node);

                    ResolveSubTree(row, node);
                }
            }
        }

        #region CreateDataTable

        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable();
            DataColumn column1 = new DataColumn("Id", typeof(string));
            DataColumn column2 = new DataColumn("Text", typeof(String));
            DataColumn column3 = new DataColumn("ParentId", typeof(string));
            table.Columns.Add(column1);
            table.Columns.Add(column2);
            table.Columns.Add(column3);

            DataRow row = table.NewRow();
            row[0] = "all";
            row[1] = "全部";
            row[2] = DBNull.Value;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "1号楼";
            row[1] = "1号楼";
            row[2] = "all";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "2号楼";
            row[1] = "2号楼";
            row[2] = "all";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "健身房";
            row[1] = "健身房";
            row[2] = "all";
            table.Rows.Add(row);


            //row = table.NewRow();
            //row[0] = "zhumadian";
            //row[1] = "驻马店市";
            //row[2] = "henan";
            //table.Rows.Add(row);

            //row = table.NewRow();
            //row[0] = "luohe";
            //row[1] = "漯河市";
            //row[2] = "henan";
            //table.Rows.Add(row);

            //row = table.NewRow();
            //row[0] = "anhui";
            //row[1] = "安徽省";
            //row[2] = "china";
            //table.Rows.Add(row);

            //row = table.NewRow();
            //row[0] = "hefei";
            //row[1] = "合肥市";
            //row[2] = "anhui";
            //table.Rows.Add(row);

            //row = table.NewRow();
            //row[0] = "golden";
            //row[1] = "金色池塘小区";
            //row[2] = "hefei";
            //table.Rows.Add(row);

            //row = table.NewRow();
            //row[0] = "ustc";
            //row[1] = "中国科学技术大学";
            //row[2] = "hefei";
            //table.Rows.Add(row);

            return table;
        }


        #endregion



        protected void tbxMyBox1_TriggerClick(object sender, EventArgs e)
        {
            //打开窗口
            Window2.Hidden = false;
            //LoadData();

        }

        protected void rbtnFirst_CheckedChanged(object sender, CheckedEventArgs e)
        {
            if (rbtnFirst.Checked == true)
            {
                tbxMyBox1.Enabled = false;
                TriggerBox1.Enabled = false;
                TriggerBox2.Enabled = false;
                TriggerBox3.Enabled = false;
            }
            else
            {
                tbxMyBox1.Enabled = true;
                TriggerBox1.Enabled = true;
                TriggerBox2.Enabled = true;
                TriggerBox3.Enabled = true;
                //drop.Enabled = false;

            }
        }

        protected void RadioButton1_CheckedChanged(object sender, CheckedEventArgs e)
        {
            if (RadioButton1.Checked == true)
                TriggerBox4.Enabled = false;
            else
                TriggerBox4.Enabled = true;

            if (rbtnFirst.Checked == true)
                drop.Enabled = true;
            else
                drop.Enabled = false;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            School盘点任务表 model = new School盘点任务表();
            model.名称 = this.项目名称.Text;
            model.盘点单号 = 单号.Text;
            model.起始时间 = Convert.ToDateTime(DatePicker1.Text);
            model.截止时间 = Convert.ToDateTime(DatePicker2.Text);
            model.等级 = 1;
            //后续判断下checked
            model.清查范围 = rbtnFirst.Text;
            model.清查ID = "全部";
            model.完成状态 = "进行中";
            model.盘点方式 = RadioButton1.Text;
            model.备注 = TextBox1.Text;
            model.学校ID = 1;
            model.盘点完成 = "1";
            School清查盘点BLL bll = new School清查盘点BLL();
            if (bll.addpdrw(model))
            {
                Alert.Show("chengg！");
                Window1.Hidden = true;
                //Window1.Hidden();
            }
            else
            {
                Alert.Show("xxx！");
            }
        }



        public string imgurl(string url)
        {
            return url;
        }

        protected void Grid3_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action2")
            {
                object[] keys = Grid3.DataKeys[e.RowIndex];
                string imageurl = keys[1].ToString();
                //Response.Write("<script>imageurl('" + imageurl + "')</script>");
                //imgurl(imageurl);

                //如果有UpdatePanel就用如下代码调用前台js
                //ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "Ceshi();", true);
                //如果没有就如下代码
                //PageContext.RegisterPreStartupScript("imageurl('" + imageurl + ");");
                string url = "imageurl('" + imageurl + "')";
                PageContext.RegisterStartupScript(url);
                //Response.Write("<script type='text/javascript'>alert('1');</script>"); 

                //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>imageurl();</script>", true);
                //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>imageurl(" + imageurl + ");</script>", true);
                //string[] sArray = imageurl.Split(',');
                //foreach (string i in sArray) 
                //{

                //}

            }
        }
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            Window3.Hidden = false;
            if (e.CommandName == "Action1")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                盘点进度状态.Text = keys[1].ToString();
                //完成状态,盘点单号,名称,盘点方式,清查范围,发布方,起始时间,截止时间
                //盘点进度单号.Text = keys[2].ToString();
                盘点进度项目名称.Text = keys[3].ToString();
                盘点进度盘点方式.Text = keys[4].ToString();
                盘点进度盘点范围.Text = keys[5].ToString();
                //盘点进度发布方.Text = keys[6].ToString();
                string 计划日期 = Convert.ToDateTime(keys[7]).ToLongDateString().ToString() + "----" + Convert.ToDateTime(keys[8]).ToLongDateString().ToString();
                盘点进度计划时间.Text = 计划日期;
                盘点进度备注.Text = keys[9].ToString();
                盘点进度发布日期.Text = Convert.ToDateTime(keys[7]).ToLongDateString().ToString();




                List<School盘点进度> dts = new List<School盘点进度>();

                List<School盘点进度> 查询盘点进度 = bll.查询盘点进度(ID, 盘点进度盘点范围.Text);


                School盘点进度 model1 = new School盘点进度();
                int 数量总数 = 查询盘点进度[查询盘点进度.Count - 1].管理数量总数;
                int 盘点总数 = 查询盘点进度[查询盘点进度.Count - 1].已经盘点总数;


                double bfb1 = Convert.ToDouble(盘点总数) / Convert.ToDouble(数量总数) * 100;
                int bfbthis1 = Convert.ToInt32(bfb1);
                model1.ID = 9999;
                model1.名称 = "总进度";
                model1.百分比 = bfbthis1.ToString();
                model1.管理数量 = 数量总数.ToString();
                model1.已经盘点 = 盘点总数.ToString();
                model1.完成状态 = "进行中";
                model1.盘点结束 = "未完成";
                //model1.管理数量 = "0";
                dts.Add(model1);
                foreach (School盘点进度 item in 查询盘点进度)
                {
                    dts.Add(item);
                }


                //DataTable table = DataSourceUtil.GetDataTable();

                Grid2.DataSource = dts;
                Grid2.DataBind();









            }

        }

        //protected void Button7_Click(object sender, EventArgs e)
        //{
        //    //string selectedId = Tree1.SelectedNodeID;
        //    //if (!String.IsNullOrEmpty(selectedId))
        //    //{

        //    //    string message = "选中的节点：" + Tree1.FindNode(selectedId).Text;
        //    //    //Alert.Show(message);

        //    //}
        //    //else
        //    //{
        //    //    Alert.Show("chengg！");
        //    //}
        //}

        protected void Tree1_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            //int id = Convert.ToInt32(e.Node.NodeID);
            DataSet ds = bll.筛选存放地点(Convert.ToInt32(e.Node.NodeID));
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;

            // 3.绑定到Grid
            Grid6.DataSource = source;//DataTable
            Grid6.DataBind();
            //Alert.Show(e.Node.NodeID);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int[] selections = Grid6.SelectedRowIndexArray;
            foreach (int rowIndex in selections)
            {
                sb.AppendFormat(Grid6.DataKeys[rowIndex][1].ToString() + ",");
            }

            tbxMyBox1.Text = sb.ToString();
            Window2.Hidden = true;
        }

        protected void TriggerBox2_TriggerClick(object sender, EventArgs e)
        {

            Window4.Hidden = false;
        }

        protected void Tree2_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            //int id = Convert.ToInt32(e.Node.NodeID);
            DataSet ds = bll.筛选用户(Convert.ToInt32(e.Node.NodeID));
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;

            // 3.绑定到Grid
            Grid7.DataSource = source;//DataTable
            Grid7.DataBind();

            Grid9.DataSource = source;//DataTable
            Grid9.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int[] selections = Grid7.SelectedRowIndexArray;
            foreach (int rowIndex in selections)
            {
                sb.AppendFormat(Grid7.DataKeys[rowIndex][1].ToString() + ",");
            }

            TriggerBox2.Text = sb.ToString();
            Window4.Hidden = true;
        }

        protected void TriggerBox1_TriggerClick(object sender, EventArgs e)
        {
            //填充grid
            DataSet ds = bll.查询部门();
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;

            // 3.绑定到Grid
            Grid8.DataSource = source;//DataTable
            Grid8.DataBind();
            Window5.Hidden = false;
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int[] selections = Grid8.SelectedRowIndexArray;
            foreach (int rowIndex in selections)
            {
                sb.AppendFormat(Grid8.DataKeys[rowIndex][1].ToString() + ",");
            }

            TriggerBox1.Text = sb.ToString();
            Window5.Hidden = true;
        }

        protected void TriggerBox2_TriggerClick1(object sender, EventArgs e)
        {
            Window4.Hidden = false;
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int[] selections = Grid9.SelectedRowIndexArray;
            foreach (int rowIndex in selections)
            {
                sb.AppendFormat(Grid9.DataKeys[rowIndex][1].ToString() + ",");
            }

            TriggerBox4.Text = sb.ToString();
            Window6.Hidden = true;
        }

        protected void TriggerBox4_TriggerClick(object sender, EventArgs e)
        {
            Window6.Hidden = false;
            LinkButton2.Hidden = false;
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedItem.Text == "明细表")
            {
                CheckBox1.Hidden = true;//隐藏所有checkbox
                CheckBox2.Hidden = true;
                CheckBox3.Hidden = true;
                CheckBox4.Hidden = true;
                CheckBox5.Hidden = true;
                CheckBox6.Hidden = true;
                CheckBox7.Hidden = true;
                CheckBox8.Hidden = true;
                //把下拉菜单数据填充

                //labResult.Text = String.Format("选中项：{0}（值：{1}）", DropDownList1.SelectedItem.Text, DropDownList1.SelectedValue);
            }
            else
            {
                CheckBox1.Hidden = false;
                CheckBox2.Hidden = false;
                CheckBox3.Hidden = false;
                CheckBox4.Hidden = false;
                CheckBox5.Hidden = false;
                CheckBox6.Hidden = false;
                CheckBox7.Hidden = false;
                CheckBox8.Hidden = false;

            }
        }

        protected void TabStrip2_TabIndexChanged(object sender, EventArgs e)
        {
            if (TabStrip2.ActiveTabIndex == 0)
            {

            }
            else if (TabStrip2.ActiveTabIndex == 1)
            {
                //查询 拍照补录
                // 1.获取数据总数
                // Grid3.RecordCount = 700;//测试，去数据库获取总数
                // 2.获取当前分页数据

                DataSet ds = bll.拍照补录查询("");
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                DataTable source = dt;
                // 3.绑定到Grid
                Grid3.DataSource = source;//DataTable
                Grid3.DataBind();
            }
            else if (TabStrip2.ActiveTabIndex == 2)
            {

                DataSet dspk = bll.盘亏处理查询("");
                DataTable dtpk = dspk.Tables[0].Copy();//复制一份table
                Grid4.DataSource = dtpk;//DataTable
                Grid4.DataBind();
            }
            else if (TabStrip2.ActiveTabIndex == 3)
            {
                //Grid5
                Grid5.DataSource = bll.查询盘点报告();//DataTable
                Grid5.DataBind();
                //绑定条件数据

                List<School学校名称表> xxmc = bll.查询学校名称();
                单位.DataTextField = "学校名称";
                单位.DataValueField = "ID";
                单位.DataSource = xxmc;
                单位.DataBind();


                School资产转移BLL bllzy = new School资产转移BLL();
                List<School一级部门表> gsbm = bllzy.byzc();
                部门.DataTextField = "名称";
                部门.DataValueField = "ID";
                部门.DataSource = gsbm;
                部门.DataBind();

                List<School一级类别表> yjlb = bll.查询一级类别();
                一级.DataTextField = "名称";
                一级.DataValueField = "ID";
                一级.DataSource = yjlb;
                一级.DataBind();


                List<School建筑物信息表> 查询建筑物 = bll.查询建筑物信息表();
                存放地点.DataTextField = "名称";
                存放地点.DataValueField = "ID";
                存放地点.DataSource = 查询建筑物;
                存放地点.DataBind();



            }
        }

        protected void CheckBox1_CheckedChanged(object sender, CheckedEventArgs e)
        {

        }

        protected void CheckBox2_CheckedChanged(object sender, CheckedEventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                GridColumn column = Grid5.FindColumn("部门");//根据条件来隐藏列
                column.Hidden = !column.Hidden;
            }
            else
            {
                GridColumn column = Grid5.FindColumn("部门");//根据条件来隐藏列
                column.Hidden = !column.Hidden;
            }
        }

        protected void CheckBox3_CheckedChanged(object sender, CheckedEventArgs e)
        {
            if (CheckBox3.Checked == true)
            {
                GridColumn column = Grid5.FindColumn("负责人");//根据条件来隐藏列
                column.Hidden = !column.Hidden;
            }
            else
            {
                GridColumn column = Grid5.FindColumn("负责人");//根据条件来隐藏列
                column.Hidden = !column.Hidden;
            }
        }

        protected void 部门_SelectedIndexChanged(object sender, EventArgs e)
        {
            School资产转移BLL blluser = new School资产转移BLL();
            int ID = Convert.ToInt32(部门.SelectedValue);
            if (ID > 0)
            {
                List<用户表> listuser = blluser.listuser(ID);
                负责人.DataTextField = "姓名";
                负责人.DataValueField = "ID";
                负责人.DataSource = listuser;
                负责人.DataBind();
            }
        }

        protected void 一级_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(一级.SelectedValue);
            if (ID > 0)
            {
                List<School二级类别表> listuser = bll.查询二级类别(ID);
                二级.DataTextField = "名称";
                二级.DataValueField = "ID";
                二级.DataSource = listuser;
                二级.DataBind();
            }
        }

        protected void 二级_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(二级.SelectedValue);
            if (ID > 0)
            {
                List<School三级类别表> listuser = bll.查询三级类别(ID);
                三级.DataTextField = "名称";
                三级.DataValueField = "ID";
                三级.DataSource = listuser;
                三级.DataBind();
            }
        }

        protected void 存放地点_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(存放地点.SelectedValue);
            if (ID > 0)
            {
                List<School房间信息表> 查询房间信息 = bll.查询房间信息表(ID);
                房间.DataTextField = "名称";
                房间.DataValueField = "ID";
                房间.DataSource = 查询房间信息;
                房间.DataBind();
            }
        }

        protected void Grid2_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                object[] keys = Grid2.DataKeys[e.RowIndex];
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                if (ID > 0 && ID != 9999)
                {
                   List<School盘点人员进度> pdry = bll.查询盘点人员进度(ID);
                   Grid10.DataSource = pdry;//DataTable
                   Grid10.DataBind();
                   Window7.Hidden = false;
                }

                
              
            }
            else
            {

            }

        }


    }
}