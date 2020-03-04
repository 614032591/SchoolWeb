using PLM.BusinessRlues;
using PLM_BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40
{
    public partial class index : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetUserInfo();
                if (Constants.IS_BASE)
                {
                    
                    try
                    {
                        btn1.Text = HttpContext.Current.Session["用户名"].ToString();
                    }
                    catch (Exception)
                    {
                        Alert.ShowInTop("Session已失效,跳转登录页面！");
                        System.Diagnostics.Process.Start("http://localhost:2850/LoginTest.aspx");
                        return;
                    }

                    treeMenu.HideHScrollbar = false;
                    treeMenu.HideVScrollbar = false;
                    treeMenu.ExpanderToRight = false;
                    treeMenu.HeaderStyle = false;
                    //Label1.Text = bll.未读总数("").ToString() + "条未读数据";
                    消息中心BLL bll = new 消息中心BLL();
                    btnThemeSelect.Text = "消息中心（"+bll.未读总数("").ToString()+"）";
                }
                
            }
        }

        用户操作BLL bll = new 用户操作BLL();
        protected void GetUserInfo()
        {
            用户表 loginuser = new 用户表();
            string username_Value = Request.QueryString["userName"];
            string password_Valud = Request.QueryString["Password"];
            loginuser.用户名 = username_Value;
            loginuser.密码 = password_Valud;
            用户表 user = bll.UserLogin(loginuser);
            //跳转页面
            Session["UserID"] = user.ID;
            Session["用户名"] = user.用户名;
            Session["权限"] = user.权限;
            Session["二级部门ID"] = user.二级部门ID;

            Session["三级部门ID"] = user.三级部门ID;
            Session["姓名"] = user.姓名;
            Session["职务"] = user.职务;
            Session["联系电话"] = user.联系电话;
            Session["三级部门名称"] = user.三级部门名称;
            Session["二级部门名称"] = user.二级部门名称;
        }
        private void LoadData()
        {
            //绑定单位
            //List<用户单位表> list = gzbll.查询二级单位();
            //二级单位.DataTextField = "名称";
            //二级单位.DataValueField = "ID";
            //二级单位.DataSource = list;
            //二级单位.DataBind();
            //二级单位.EmptyText = "全部";
        }

   


  
    }
}