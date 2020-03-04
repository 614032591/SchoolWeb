using Newtonsoft.Json.Linq;
using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FineUIPro.EmptyProjectNet40.购置验收
{
    public partial class 购置验收首页 : PageBase
    {
        School购置验收流程BLL gzysbll = new School购置验收流程BLL();
        School清查盘点BLL pdbll = new School清查盘点BLL();

        private bool AppendToEnd = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OffSession();
                流程状态.Text = "待审核";

                申请人.Text = Session["姓名"].ToString();
                制单日期.Text = DateTime.Now.ToShortDateString();
                // 绑定表格
                BindGrid();
                //BindEnumrableToDropDownList();//绑定List
                BindEnumrable();

                //List<School一级类别表> yjlb = pdbll.一级类别();
                //一级分类.DataTextField = "名称";
                //一级分类.DataValueField = "名称";
                //一级分类.DataSource = yjlb;
                //一级分类.DataBind();
                ////一级.EmptyText = "全部";

                //List<School一级类别表> yjlb = pdbll.查询一级类别s();
                //firstKind.DataTextField = "名称";
                //firstKind.DataValueField = "名称";
                //firstKind.DataSource = yjlb;
                //firstKind.DataBind();
                //firstKind.EmptyText = "请选择一级类别";
                //firstKind.AutoSelectFirstItem = true;
                //string daaaa = firstKind.SelectedText.ToString();
                //secondKind.Enabled = true;



                List<School一级部门表> xxmc = pdbll.一级部门();
                一级部门.DataTextField = "名称";
                一级部门.DataValueField = "名称";
                一级部门.DataSource = xxmc;
                一级部门.DataBind();


                List<用户表> yhxm = pdbll.用户表();
                负责人.DataTextField = "姓名";
                负责人.DataValueField = "姓名";
                负责人.DataSource = yhxm;
                负责人.DataBind();


                List<School建筑物信息表> jzw = pdbll.建筑物信息表();
                存放地点.DataTextField = "名称";
                存放地点.DataValueField = "名称";
                存放地点.DataSource = jzw;
                存放地点.DataBind();



               




                

            }
        }

        #region JQueryFeature

        public class JQueryFeature
        {
            private string _id;

            public string Id
            {
                get { return _id; }
                set { _id = value; }
            }
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private int _level;

            public int Level
            {
                get { return _level; }
                set { _level = value; }
            }

            private bool _enableSelect;

            public bool EnableSelect
            {
                get { return _enableSelect; }
                set { _enableSelect = value; }
            }

            public JQueryFeature(string id, string name, int level, bool enableSelect)
            {
                _id = id;
                _name = name;
                _level = level;
                _enableSelect = enableSelect;
            }

            public override string ToString()
            {
                return String.Format("Name:{0}+Id:{1}", Name, Id);
            }
        }
        #endregion

    

        private void BindEnumrable()
        {
            List<JQueryFeature> myList = new List<JQueryFeature>();

            List<School一级类别表> yjlb = pdbll.查询一级类别s();
            
            int num = 0;
            for (int i=1;i<= yjlb.Count;i++)
            {
                
                myList.Add(new JQueryFeature(num.ToString(), yjlb[i-1].名称.ToString(), 0, true));


                List<School二级类别表> listuser = pdbll.查询二级类别s(i);                              
                for (int t=1;t<=listuser.Count;t++)
                {
                    myList.Add(new JQueryFeature((++num).ToString(), listuser[t-1].名称.ToString()+".", 1, true));

                    List<School三级类别表> listusers = pdbll.三级(listuser[t - 1].名称.ToString());
                    for (int s = 1; s <= listusers.Count; s++)
                    {
                        myList.Add(new JQueryFeature((++num).ToString(), listusers[s - 1].名称.ToString() + "..", 2, true));
                    }
                }
                num++;
            }
            //firstKind.DataValueField = "名称";
            


            //myList.Add(new JQueryFeature("0", "jQuery", 0, false));
            //myList.Add(new JQueryFeature("1", "zzzzz", 0, false));
            //myList.Add(new JQueryFeature("0", "核心", 1, false));


            //myList.Add(new JQueryFeature("2", "选择符", 1, false));
            //myList.Add(new JQueryFeature("3", "基本选择符", 2, true));
            //myList.Add(new JQueryFeature("4", "内容选择符", 2, true));
            //myList.Add(new JQueryFeature("5", "属性选择符", 2, true));

            //myList.Add(new JQueryFeature("6", "筛选", 1, false));
            //myList.Add(new JQueryFeature("7", "过滤", 2, true));
            //myList.Add(new JQueryFeature("8", "查找", 2, true));


            //myList.Add(new JQueryFeature("9", "事件", 1, false));
            //myList.Add(new JQueryFeature("10", "页面载入",2, true));
            //myList.Add(new JQueryFeature("11", "jQuery", 3, false));

            //myList.Add(new JQueryFeature("11", "事件处理", 2, true));
            //myList.Add(new JQueryFeature("12", "事件委托", 2, true));

            ddlBox.DataTextField = "Name";
            ddlBox.DataValueField = "Name";
            ddlBox.DataSimulateTreeLevelField = "Level";
            ddlBox.DataEnableSelectField = "EnableSelect";
            ddlBox.DataSource = myList;
            ddlBox.DataBind();

            ddlBox.SelectedValue = "3";
        }
        //protected void firstKind_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string kind = firstKind.SelectedValue.ToString();
            
        //    if (kind != "" && kind != null)
        //    {
               
        //        thirdKind.Enabled = false;
        //        secondKind.Enabled = true;
              
        //        List<School二级类别表> listuser = pdbll.查询二级类别(kind);
        //        secondKind.DataTextField = "名称";
        //        secondKind.DataValueField = "名称";               
        //        secondKind.DataSource = listuser;
        //        secondKind.DataBind();
                

        //        List<School三级类别表> listusers = pdbll.查询三级类别(kind);
        //        thirdKind.DataTextField = "名称";
        //        thirdKind.DataValueField = "名称";
        //        thirdKind.DataSource = listusers;
        //        thirdKind.DataBind();
        //    }
        //    else
        //    {
        //        secondKind.Enabled = false;
        //        thirdKind.Enabled = false;
                
        //        List<School二级类别表> listuser = pdbll.查询二级类别(kind);
        //        secondKind.DataTextField = "名称";
        //        secondKind.DataValueField = "名称";
        //        secondKind.DataSource = listuser;
        //        thirdKind.DataSource = listuser;
        //        secondKind.DataBind();
        //        thirdKind.DataBind();
        //    }

        //}

        //protected void secondKind_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string kind = secondKind.SelectedValue.ToString();
        //    //int ID = Convert.ToInt32(secondKind.SelectedValue);
        //    if (kind != "" && kind != null)
        //    {
        //        thirdKind.Enabled = true;
               
        //        List<School三级类别表> listuser = pdbll.查询三级类别(kind);
        //        thirdKind.DataTextField = "名称";
        //        thirdKind.DataValueField = "名称";
        //        thirdKind.DataSource = listuser;
        //        thirdKind.DataBind();
        //    }
        //    else
        //    {
        //        thirdKind.Enabled = false;
                
        //        List<School三级类别表> listuser = pdbll.查询三级类别(kind);
        //        thirdKind.DataTextField = "名称";
        //        thirdKind.DataValueField = "名称";
        //        thirdKind.DataSource = listuser;
        //        thirdKind.DataBind();
        //    }

        //}

       



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
        #region CustomClass

        public class CustomClass
        {
            private string _id;

            public string ID
            {
                get { return _id; }
                set { _id = value; }
            }
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public CustomClass(string id, string name)
            {
                _id = id;
                _name = name;
            }
        }
        #endregion


        #region BindEnumrableToDropDownList

        //private void BindEnumrableToDropDownList()
        //{
        //    List<CustomClass> myList = new List<CustomClass>();
        //    myList.Add(new CustomClass("1", "可选项1"));
        //    myList.Add(new CustomClass("2", "可选项2"));
        //    myList.Add(new CustomClass("3", "可选项3"));
        //    myList.Add(new CustomClass("4", "可选项4"));
        //    myList.Add(new CustomClass("5", "可选项5"));
        //    myList.Add(new CustomClass("6", "可选项6"));
        //    myList.Add(new CustomClass("7", "可选择项7"));
        //    myList.Add(new CustomClass("8", "可选择项8"));
        //    myList.Add(new CustomClass("9", "可选择项9"));

        //    取得方式.DataTextField = "Name";
        //    取得方式.DataValueField = "ID";
        //    取得方式.DataSource = myList;
        //    取得方式.DataBind();

        //}

        #endregion

        protected string GetEditUrls(object 单据编号, object sort)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("单据编号", "单据编号" + 单据编号);
            joBuilder.AddProperty("title", "流程进度 - " + 单据编号);
            
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("School购置验收流程进度.aspx?SBBH={0}&sort={1}", 单据编号, HttpUtility.UrlEncode(sort.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }


        private void BindGrid()
        {
            DataSet ds = gzysbll.DataSet购置验收查询("流程状态-全部", Session["姓名"].ToString(), Session["职务"].ToString());
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();



            DataTable table = GetSourceData();

            Grid2.DataSource = table;
            Grid2.DataBind();
        }

        //private static readonly string KEY_FOR_DATASOURCE_SESSION = "购置验收";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private DataTable GetSourceData()
        {
            return GetSimpleDataTable();
            //if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
            //{
            //    Session[KEY_FOR_DATASOURCE_SESSION] = GetSimpleDataTable();
            //}
            //return (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];
        }

        /// <summary>
        /// 获取模拟表格（简单表格）
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSimpleDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("资产编号", typeof(String)));
            table.Columns.Add(new DataColumn("资产分类", typeof(String)));
            table.Columns.Add(new DataColumn("资产名称", typeof(String)));
            table.Columns.Add(new DataColumn("规格型号", typeof(String)));
            table.Columns.Add(new DataColumn("使用方向", typeof(String)));
            table.Columns.Add(new DataColumn("数量", typeof(int)));
            table.Columns.Add(new DataColumn("单价", typeof(double)));


            table.Columns.Add(new DataColumn("归属部门", typeof(String)));
            table.Columns.Add(new DataColumn("负责人", typeof(String)));
            table.Columns.Add(new DataColumn("存放地点", typeof(String)));
            table.Columns.Add(new DataColumn("资产状态", typeof(String)));
            return table;
        }





        protected void Button4_Click(object sender, EventArgs e)
        {


            if (Grid2.GetModifiedData().Count == 0)
            {
                //labResult.Text = "";
                //ShowNotify("表格数据没有变化！");
                Alert.ShowInTop("表格内没有数据！");
                return;
            }

            // 复制原始表格的结构
            DataTable newTable = GetSourceData().Clone();
            DataRow newRow;

            int rowIndex = 0;
            JArray mergedData = Grid2.GetMergedData();


            int 总数 = 0;
            double 价格 = 0;
            SchoolX_购置验收流程表 modelgz = new SchoolX_购置验收流程表();
            modelgz.流程状态 = 流程状态.Text;
            modelgz.单据编号 = 单据编号.Text;
            modelgz.事项名称 = 事项名称.Text;
            modelgz.备注信息 = 备注.Text;
            modelgz.申请人 = 申请人.Text;
            modelgz.制单日期 = 制单日期.Text;
            modelgz.供应商 = 供应商.Text;
            modelgz.供应商联系方式 = 供应商联系方式.Text;
            modelgz.合同编号 = 合同编号.Text;
            modelgz.发票号 = 发票号.Text;
            //modelgz.验收人 = 验收人.Text;
            //modelgz.记账人 = 记账人.Text;
            modelgz.取得方式 = 取得方式.SelectedItem.Text;
            modelgz.购置日期 = 购置日期.Text;
            //modelgz.验收日期 = 验收日期.Text;
            List<School办公设备信息表> listmodel = new List<School办公设备信息表>();
            foreach (JObject mergedRow in mergedData)
            {
                School办公设备信息表 model = new School办公设备信息表();
                JObject values = mergedRow.Value<JObject>("values");
                newRow = newTable.NewRow();
                newRow[0] = rowIndex; // 实际项目中请使用数据库中的自增长主键，无需设置此列的值
                newRow[1] = values.Value<string>("资产编号");
                newRow[2] = values.Value<string>("资产分类");
                newRow[3] = values.Value<string>("资产名称");
                newRow[4] = values.Value<string>("规格型号");
                newRow[5] = values.Value<string>("使用方向");
                try
                {
                    newRow[6] = values.Value<int>("number");
                    newRow[7] = values.Value<double>("prise");
                }
                catch (Exception)
                {
                    Alert.ShowInTop("数量/单价请填写数字！", "警告信息", MessageBoxIcon.Error);
                    return;
                }

                newRow[8] = values.Value<string>("归属部门");
                newRow[9] = values.Value<string>("负责人");
                newRow[10] = values.Value<string>("存放地点");
                newRow[11] = values.Value<string>("资产状态");

                newTable.Rows.Add(newRow);

                model.编号 = values.Value<string>("资产编号");
                string 类别名称 = values.Value<string>("三级分类名称");
                string[] arr = 类别名称.Split('.');
                if (arr.Length==2)
                {
                    model.二级类别名称 = arr[0];
                    List <School一级类别表> listuser = pdbll.查询一级类别(model.二级类别名称);

                    model.一级类别名称 = listuser[0].名称.ToString();
                }
                else if (arr.Length==3)
                {
                    model.三级类别名称 = arr[0];
                    List<School二级类别表> listusers = pdbll.查询二级类别(arr[0]);
                    
                    model.二级类别名称=listusers[0].名称.ToString();

                    List<School一级类别表> listuser = pdbll.查询一级类别(model.二级类别名称);
                    
                    model.一级类别名称 = listuser[0].名称.ToString();
                }else if (arr.Length==1)
                {
                    model.一级类别名称 = arr[0];
                }
                //model.二级类别名称 = values.Value<string>("Window1_SimpleForm1_TabStrip1_ctl00_Grid2_ctl02_ctl01");
                //model.三级类别名称 = values.Value<string>("Window1_SimpleForm1_TabStrip1_ctl00_Grid2_ctl02_ctl02");

                model.名称 = values.Value<string>("资产名称");
                model.型号 = values.Value<string>("规格型号");
                model.使用方向 = values.Value<string>("使用方向");
                try
                {
                    model.数量 = values.Value<int>("number");
                    总数 += model.数量;
                    model.价格 = values.Value<double>("prise");
                    价格 += model.价格;
                }
                catch (Exception)
                {
                    Alert.ShowInTop("数量/单价请填写数字！", "警告信息", MessageBoxIcon.Error);
                    return;
                }
                model.str归属部门 = values.Value<string>("归属部门");
                model.负责人 = values.Value<string>("负责人");
                model.存放地点 = values.Value<string>("存放地点");
                model.资产状态 = values.Value<string>("资产状态");
                if (model.编号 == null || model.名称 == null || model.型号 == null || model.使用方向 == null || model.str归属部门 == null || model.负责人 == null || model.存放地点 == null || model.资产状态 == null || modelgz.购置日期 == null)
                {
                    Alert.ShowInTop("请将信息填写完整！", "警告信息", MessageBoxIcon.Error);
                    return;
                }
                listmodel.Add(model);
                rowIndex++;
            }
            modelgz.数量合计 = 总数;
            modelgz.金额合计 = 价格;

            AM_提醒通知 ammodel = new AM_提醒通知();
            ammodel.发起人 = 申请人.Text;
            ammodel.发起时间 = DateTime.Now;
            ammodel.是否已读 = "否";
            ammodel.通知类型 = "待办事项通知";
            ammodel.通知职务 = "财务人员";
            ammodel.消息内容 = "您来自" + 申请人.Text + "的购置验收/入库-申请通知！";
            ammodel.消息事项 = "购置验收";

           

            int result = gzysbll.插入X_购置验收流程表(modelgz, listmodel, ammodel);
            if (result > 0)
            {
                Grid2.GetRejectChangesReference();
                Window1.Hidden = true;
                Alert.ShowInTop("创建成功！");
                //return;
                BindGrid();
            }


        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                OffSession();

                string 职务 = Session["职务"].ToString();
                if (职务 == "财务人员")
                {
                    Button5.Text = "同意";
                    Button6.Text = "拒绝";
                }
                else
                {
                    Button5.Enabled = false;
                    Button6.Text = "关闭";

                }
                object[] keys = Grid1.DataKeys[e.RowIndex];
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                flowid.Text = ID.ToString();
                查看流程状态.Text = keys[1].ToString();
                if (查看流程状态.Text=="完成")
                {
                    Button5.Enabled = false;
                    Button6.Text = "关闭";
                }
                查看单据编号.Text = keys[2].ToString();
                查看事项名称.Text = keys[3].ToString();
                查看备注.Text = keys[4].ToString();
                this.Label1.Text = "数量合计:" + keys[5].ToString() + "---金额合计：" + keys[6].ToString() + "元";
                查看申请人.Text = keys[7].ToString();
                查看制单日期.Text = keys[8].ToString();
                查看供应商.Text = keys[9].ToString();
                查看供应商联系方式.Text = keys[10].ToString();
                查看合同编号.Text = keys[11].ToString();
                查看发票号.Text = keys[12].ToString();
                //查看验收人.Text = keys[13].ToString();
                if (keys[14]==null)
                {
                    查看记账人.Text = "";
                }
                else
                {
                    查看记账人.Text = keys[14].ToString();

                }
                
                查看取得方式.Text = keys[15].ToString();
                查看购置日期.Text = keys[16].ToString();
                //查看验收日期.Text = keys[17].ToString();
                DataSet ds = gzysbll.购置验收查询设备(ID);
                DataTable dt = ds.Tables[0].Copy();//复制一份table
                DataTable source = dt;
                Grid3.DataSource = dt;//DataTable
                Grid3.DataBind();
                处理资产.Hidden = false;
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string flowstate = DropDownList1.SelectedText;
            DataSet ds = gzysbll.DataSet购置验收查询(flowstate, Session["姓名"].ToString(), Session["职务"].ToString());
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            DataTable source = dt;
            // 3.绑定到Grid
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }

        protected void btnCheckSelection_Click(object sender, EventArgs e)
        {

            OffSession();
            string 职务 = Session["职务"].ToString();
            if (职务 == "资产管理员")
            {
                Window1.Hidden = false;
                OutputSummaryData();
            }
            else
            {
                Alert alert = new Alert();
                alert.Message = "您不能创建购置验收";
                alert.Title = "提示信息";
                alert.MessageBoxIcon = MessageBoxIcon.Warning;
                alert.Show();
                return;

            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            OffSession();
            
            if (Button5.Text == "同意")
            {

                string username = Session["姓名"].ToString();//处理人
                string processingtime = DateTime.Now.ToShortDateString();//处理时间
                int FlowID = Convert.ToInt32(flowid.Text);
                SchoolX_购置验收流程表 model = new SchoolX_购置验收流程表();
                model.ID = FlowID;
                model.操作人 = username;
                model.操作时间 = processingtime;
                model.是否同意 = "是";
                model.记账人 = username;

                //AM_待办业务 dbmodel = new AM_待办业务();
                //dbmodel.处理方式 = "职务";
                //dbmodel.处理职务 = "财政人员";
                //dbmodel.流程状态 = "已完成";
                //dbmodel.处理人 = username;
                //dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产转移结果通知！";
                //dbmodel.发起时间 = DateTime.Now.ToLongDateString();
                //dbmodel.Sort = 0;


                AM_提醒通知 ammodel = new AM_提醒通知();

                ammodel.发起时间 = DateTime.Now;
                ammodel.是否已读 = "否";
                ammodel.通知类型 = "结果反馈通知";
                ammodel.通知职务 = "发起人";
                ammodel.消息内容 = "购置验收/入库-任务已全部完成！";
                ammodel.消息事项 = "购置验收/入库-结果反馈";
                ammodel.发起人 = username;//处理人
                ammodel.FlowID = FlowID;

                if (gzysbll.操作购置验收流程(model,ammodel) > 0)
                {
                    Alert alert = new Alert();
                    alert.Message = "处理成功";
                    alert.Title = "提示信息";
                    alert.MessageBoxIcon = MessageBoxIcon.Success;
                    alert.Show();
                    处理资产.Hidden = true;
                    BindGrid();
                    return;
                }
                else
                {
                    Alert alert = new Alert();
                    alert.Message = "处理失败";
                    alert.Title = "提示信息";
                    alert.MessageBoxIcon = MessageBoxIcon.Error;
                    alert.Show();
                    return;
                }
            }
            else
            {
            //    string username = Session["姓名"].ToString();//处理人
            //    string processingtime = DateTime.Now.ToShortDateString();//处理时间
            //    int FlowID = Convert.ToInt32(flowid.Text);
            //    SchoolX_购置验收流程表 model = new SchoolX_购置验收流程表();
            //    model.ID = FlowID;
            //    model.操作人 = username;
            //    model.操作时间 = processingtime;
            //    model.是否同意 = "否";

            //    AM_提醒通知 ammodel = new AM_提醒通知();
            //    ammodel.发起时间 = DateTime.Now;
            //    ammodel.是否已读 = "否";
            //    ammodel.通知类型 = "结果反馈通知";
            //    ammodel.通知职务 = "发起人";
            //    ammodel.消息内容 = "购置验收/入库-任务已全部完成！";
            //    ammodel.消息事项 = "购置验收/入库-结果反馈";
            //    ammodel.发起人 = username;//处理人
            //    ammodel.FlowID = FlowID;

            //    AM_待办业务 dbmodel = new AM_待办业务();
            //    dbmodel.处理方式 = "职务";
            //    dbmodel.处理职务 = "财政人员";
            //    dbmodel.流程状态 = "已拒绝";
            //    dbmodel.处理人 = username;
            //    dbmodel.通知内容 = "您来自" + dbmodel.发起人 + "的资产转移结果通知！";
            //    dbmodel.发起时间 = DateTime.Now.ToLongDateString();
            //    dbmodel.Sort = 0;

            //    if (gzysbll.操作购置验收流程(model, dbmodel,ammodel) > 0)
            //    {
            //        Alert alert = new Alert();
            //        alert.Message = "处理成功";
            //        alert.Title = "提示信息";
            //        alert.MessageBoxIcon = MessageBoxIcon.Success;
            //        alert.Show();
            //        处理资产.Hidden = true;
            //        BindGrid();
            //        return;
            //    }
            //    else
            //    {
            //        Alert alert = new Alert();
            //        alert.Message = "处理失败";
            //        alert.Title = "提示信息";
            //        alert.MessageBoxIcon = MessageBoxIcon.Error;
            //        alert.Show();
            //        return;
            //    }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (Button6.Text == "关闭")
            {
                处理资产.Hidden = true;
            }
            else
            {

            }
        }



        #region //合计
        private void OutputSummaryData()
        {
            int numberTotal = 0;
            int priseTotal = 0;
            foreach (JObject mergedRow in Grid2.GetMergedData())
            {
                JObject values = mergedRow.Value<JObject>("values");

                numberTotal += values.Value<int>("number");
                priseTotal += values.Value<int>("prise");
            }

            JObject summary = new JObject();
            summary.Add("number", numberTotal);
            summary.Add("prise", priseTotal);

            Grid2.SummaryData = summary;
        }
        //private void OutputSummaryData()
        //{
        //    DataTable source = GetSourceData();

        //    int 数量 = 0;
        //    int 单价 = 0;
        //    foreach (DataRow row in source.Rows)
        //    {
        //        数量 += Convert.ToInt32(row["number"]);
        //        单价 += Convert.ToInt32(row["prise"]);
        //    }


        //    JObject summary = new JObject();
        //    summary.Add("major", "全部合计");
        //    summary.Add("number", 数量.ToString("F2"));
        //    summary.Add("prise", 单价.ToString("F2"));


        //    Grid2.SummaryData = summary;

        //}

        #endregion

        protected void 一级分类_SelectedIndexChanged(object sender, EventArgs e)
        {
            //window100.Hidden = false;
            //string kind = 一级分类.SelectedValue.ToString();
            
            //if (kind!=""&& kind!=null)
            //{
            //    三级分类.Enabled = false;
            //    二级分类.Enabled = true;
            //    School清查盘点BLL pdbll = new School清查盘点BLL();
            //    List<School二级类别表> listuser = pdbll.查询二级类别(kind);
            //    二级分类.DataTextField = "名称";
            //    二级分类.DataValueField = "名称";
            //    二级分类.DataSource = listuser;
            //    二级分类.DataBind();
            //    三级分类.DataBind();
            //}
            //else
            //{
            //    二级分类.Enabled = false;
            //    三级分类.Enabled = false;
            //    School清查盘点BLL pdbll = new School清查盘点BLL();
            //    List<School二级类别表> listuser = pdbll.查询二级类别(kind);
            //    二级分类.DataTextField = "名称";
            //    二级分类.DataValueField = "名称";
            //    二级分类.DataSource = listuser;
            //    三级分类.DataSource = listuser;
            //    二级分类.DataBind();
            //    三级分类.DataBind();
            //}
        }

        protected void 二级分类_SelectedIndexChanged(object sender, EventArgs e)
        {
            //window100.Hidden = false;

            //string kind = 二级分类.SelectedValue.ToString();
            //if (kind != "" && kind != null)
            //{
            //    三级分类.Enabled = true;
            //    School清查盘点BLL pdbll = new School清查盘点BLL();
            //    List<School三级类别表> listuser = pdbll.查询三级类别(kind);
            //    三级分类.DataTextField = "名称";
            //    三级分类.DataValueField = "名称";
            //    三级分类.DataSource = listuser;
            //    三级分类.DataBind();
            //}
            //else
            //{
            //    三级分类.Enabled = false;
            //    School清查盘点BLL pdbll = new School清查盘点BLL();
            //    List<School三级类别表> listuser = pdbll.查询三级类别(kind);
            //    三级分类.DataTextField = "名称";
            //    三级分类.DataValueField = "名称";
            //    三级分类.DataSource = listuser;
            //    三级分类.DataBind();
            //}

        }

        protected void 一级部门_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (一级部门.SelectedValue!="")
            {
                资产状态.Text = "使用中";
         
            }
            else
            {
                资产状态.Text = "空闲中";
            }
        }

        protected void 负责人_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (负责人.SelectedValue != "")
            {
                资产状态.Text = "使用中";
            }
            else
            {
                资产状态.Text = "空闲中";
            }
        }

        protected void 三级分类_SelectedIndexChanged(object sender, EventArgs e)
        {
            //window100.Hidden = false;
        }
    }
}