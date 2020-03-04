<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="School资产借还流程进度.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.School资产借还借用.School资产借还流程进度" %>

<!DOCTYPE html>
<html>

<head runat="server">
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="../res/css/lib/bootstrap.min.css" />
    <!--<link rel="stylesheet/less" type="text/css" href="css/less/style.less?1.10" />
		<script type="text/javascript" src="js/lib/less.js"></script>-->
    <link rel="stylesheet" type="text/css" href="../res/css/less/style.css" />
    <title></title>
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
                    <a>申请人申请<span class="caret"></span></a>
                    <br />
                    <asp:Button ID="s" runat="server" Text="查看详情" />
                </li>

                <li>
                    <a>出借人出借<span class="caret"></span></a>
                    <br />
                    <%-- <asp:Button ID="Button1" runat="server" Text="查看详情"  />--%>
                </li>
                 <li>
                    <a>申请人归还<span class="caret"></span></a>
                    <br />
                    <%--<asp:Button ID="Button1" runat="server" Text="查看详情" />--%>
                </li>
                 <li>
                    <a>出借人确认<span class="caret"></span></a>
                    <br />
                   <%-- <asp:Button ID="Button2" runat="server" Text="查看详情" />--%>
                </li>


            </ul>
            <style type="text/css">
                .vertical li > a {
                    padding: 45px 15px;
                }
            </style>
            <hr />


        </div>


       

        <script src="../res/js/jquery-1.10.2.js"></script>
        <script type="text/javascript" src="../res/js/lib/lib.js"></script>
        <script>
            $(function () {
                var sort = document.getElementById("<%= Label1.ClientID %>").innerText;
                if (sort == 0) {
                    //完成
                    bsStep(4);
                } else
                {
                    bsStep(sort);
                }
                
                document.getElementById("<%= Label1.ClientID %>").style.display = "none";//隐藏lable
                //bsStep(i) i 为number 可定位到第几步 如bsStep(2)/bsStep(3)
            })
        </script>
    </form>
</body>

</html>
