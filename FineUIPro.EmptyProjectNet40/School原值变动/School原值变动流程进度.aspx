<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="School原值变动流程进度.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.School原值变动.School原值变动流程进度" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="../res/css/lib/bootstrap.min.css" />
    <!--<link rel="stylesheet/less" type="text/css" href="css/less/style.less?1.10" />
		<script type="text/javascript" src="js/lib/less.js"></script>-->
    <link rel="stylesheet" type="text/css" href="../res/css/less/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" ></asp:Label>
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <div class="container">
            <h3>流程进度</h3>
            <hr />

            <h5>
                <asp:Label ID="Label6" runat="server" Text="Label" Font-Size="X-Large" ForeColor="#ff3300"></asp:Label></h5>
            <ul class="nav nav-pills nav-justified step step-progress" data-step="4">
                <li>
                    <a>申请人已提交<span class="caret"></span></a>
                    <br />
                    <asp:Button ID="s" runat="server" Text="查看详情" />
                </li>

                <li>
                    <a>财务人员已通过<span class="caret"></span></a>
                    <br />
                    <%-- <asp:Button ID="Button1" runat="server" Text="查看详情"  />--%>
                </li>

                

            </ul>
            <style type="text/css">
                .vertical li > a {
                    padding: 45px 15px;
                }
            </style>
            <hr />


        </div>


        <f:Window ID="Window1" Title="查看详情" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="900px">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="hfFormID" runat="server"></f:HiddenField>
                        <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" Height="550px" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server" AutoPostBack="true">
                            <Tabs>
                                <f:Tab Title="<span class='highlight'>基础信息</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    
                                </f:Tab>
                                <f:Tab Title="购置验收信息" BodyPadding="10px" Layout="Fit" runat="server" IconUrl="../res/icon/arrow_switch.png">
                                    <Items>
                                        <%--  <asp:Label ID="Label1" runat="server" Text="暂无数据"></asp:Label>--%>
                                        <f:Label ID="Label4" Text="暂无数据" runat="server"></f:Label>
                                    </Items>
                                </f:Tab>

                                <f:Tab Title="相关文件" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">
                                    <Items>
                                        <%--  <asp:Label ID="Label2" runat="server" Text="暂无数据"></asp:Label>--%>
                                        <f:Label ID="Label3" Text="暂无数据" runat="server"></f:Label>
                                    </Items>
                                </f:Tab>

                            </Tabs>
                        </f:TabStrip>
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="btnClose" Icon="SystemClose" runat="server" Text="关闭"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>

        <script src="../res/js/jquery-1.10.2.js"></script>
        <script type="text/javascript" src="../res/js/lib/lib.js"></script>
        <script>
            $(function () {
                var sort = document.getElementById("<%= Label1.ClientID %>").innerText;
                bsStep(sort);
                document.getElementById("<%= Label1.ClientID %>").style.display = "none";//隐藏lable
                //bsStep(i) i 为number 可定位到第几步 如bsStep(2)/bsStep(3)
            })
        </script>
    </form>
</body>
</html>
