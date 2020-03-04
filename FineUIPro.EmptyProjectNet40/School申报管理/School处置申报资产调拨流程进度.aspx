<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="School处置申报资产调拨流程进度.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.School申报管理.School处置申报资产调拨流程进度" %>

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

        <style>
        .f-grid-row-summary .f-grid-cell-inner {
            font-weight: bold;
            color: red;
        }


        span {
            font-weight: bold;
        }
    </style>
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
                    <a>申报人发起<span class="caret"></span></a>
                    <br />
<%--                    <asp:Button ID="s" runat="server" Text="查看详情" />--%>
                </li>

                <li>
                    <a>分管领导通过<span class="caret"></span></a>
                    <br />
                </li>

                 <li>
                    <a>调入单位管理员<span class="caret"></span></a>
                    <br />
                </li>

                 <li>
                    <a>调入单位分管领导<span class="caret"></span></a>
                    <br />
                </li>

                 <li>
                    <a>主管部门<span class="caret"></span></a>
                    <br />
                </li>

                 <li>
                    <a>财务部门<span class="caret"></span></a>
                    <br />
                </li>

                 <li>
                    <a>调出单位确认<span class="caret"></span></a>
                    <br />
                </li>

                 <li>
                    <a>调入单位确认入库<span class="caret"></span></a>
                    <br />                   
                </li>
            </ul>
             <f:Button ID="查看详情" runat="server" OnClick="查看详情_Click" Text="查看详情"></f:Button>
            <style type="text/css">
                .vertical li > a {
                    padding: 45px 15px;
                }
            </style>
            <hr />


        </div>


        <f:Window ID="Window1" Title="固定资产处置单" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1400px">
            <Items>


                <f:Form ID="Form2" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="25% 25% 25% 25% ">
                            <Items>
                                <f:TextBox ID="流程状态_dbckxq" Label="流程状态" Width="250px" runat="server" LabelWidth="90">
                                </f:TextBox>

                                <f:TextBox ID="单据编号_dbckxq" Label="单据编号" Width="250px" runat="server" LabelWidth="90">
                                </f:TextBox>

                                <f:TextBox ID="申请人_dbckxq" Label="申请人" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="调出单位_dbckxq" Label="调出单位" Width="250px" runat="server" LabelWidth="90">
                                </f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>

                                <f:TextBox ID="职务_dbckxq" Label="职务" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="电话_dbckxq" Label="电话" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="事项名称_dbckxq" Label="事项名称" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="申报日期" EmptyText="请选择日期"
                                    ID="申报日期_dbckxq" ShowRedStar="true" Width="250px" LabelWidth="90">
                                </f:DatePicker>
                            </Items>
                        </f:FormRow>


                        <f:FormRow ColumnWidths="25% 25% 10% ">
                            <Items>

                                <f:TextBox ID="调入单位_dbckxq" Label="调入单位" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="验收日期" EmptyText="请选择日期"
                                    ID="验收日期_dbckxq" ShowRedStar="true" Width="250px" LabelWidth="90">
                                </f:DatePicker>
                                <f:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" AutoColumnWidth="false" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                    <f:RadioItem Text="处置单" Selected="true" Value="处置单" />
                                    <f:RadioItem Text="明细表" Value="明细表" />
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>


                    </Rows>
                </f:Form>



                <f:Grid ID="Grid9" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="true" runat="server" EnableSummary="true" SummaryPosition="Bottom" DataKeyNames="ID" Height="300px">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="类型_dbckxq" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="数量_dbckxq" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格_dbckxq" DataField="价格" HeaderText="原值"></f:RenderField>
                        <f:RenderField ColumnID="净值_bfckxq" DataField="净值" HeaderText="净值"></f:RenderField>
                        <f:RenderField ColumnID="处置方式_dbckxq" DataField="处置方式" HeaderText="处置方式" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>

                <f:Grid ID="Grid10" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="true" runat="server" EnableSummary="true" SummaryPosition="Bottom" DataKeyNames="ID" Height="300px" Hidden="true">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID_bfckxq" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="编号_bfckxq" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="类型_bfckxq" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="名称_bfckxq" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="型号_bfckxq" DataField="型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="使用方向_bfckxq" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                        <f:RenderField ColumnID="数量_dbckxq" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格_dbckxq" DataField="价格" HeaderText="价格" />
                        <f:RenderField ColumnID="房间名称_bfckxq" DataField="房间名称" HeaderText="存放地点" />
                        <f:RenderField ColumnID="部门名称_bfckxq" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人_bfckxq" DataField="负责人" HeaderText="负责人" />
                        <f:RenderField ColumnID="资产状态_bfckxq" DataField="资产状态" HeaderText="资产状态" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>


                <f:Form ID="Form4" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="调出单位分管领导" runat="server"></f:Label>
                                <f:TextBox ID="调出单位分管领导意见" Label="处理意见" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="调出单位分管领导" Label="分管领导" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="调出单位分管领导处理时间" Label="操作日期" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="调入单位管理员" runat="server"></f:Label>
                                <f:TextBox ID="调入单位管理员意见" Label="处理意见" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="调入单位管理员" Label="分管领导" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="调入单位管理员处理时间" Label="操作日期" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="调入单位分管领导" runat="server"></f:Label>
                                <f:TextBox ID="调入单位分管领导意见" Label="处理意见" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="调入单位分管领导" Label="分管领导" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="调入单位分管领导处理时间" Label="操作日期" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="主管部门" runat="server"></f:Label>
                                <f:TextBox ID="调拨主管部门意见" Label="处理意见" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="主管部门" Label="操作人" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="主管部门处理时间" Label="操作日期" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="财政部门" runat="server"></f:Label>
                                <f:TextBox ID="调拨财政部门意见" Label="处理意见" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="财政部门" Label="操作人" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="财政部门处理时间" Label="操作日期" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                            </Items>
                        </f:FormRow>




                    </Rows>
                </f:Form>






            </Items>

             <Toolbars>
                <f:Toolbar ID="Toolbar1" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="btnClose" Icon="SystemClose" runat="server" OnClick="btnClose_Click" Text="关闭"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>












        </f:Window>
        <script src="../res/js/jquery-1.10.2.js"></script>
        <script type="text/javascript" src="../res/js/lib/lib.js"></script>
        <script>


            $(function () {
                var sort = document.getElementById("<%= Label1.ClientID %>").innerText;
                if (sort == 0) {
                    //完成
                    bsStep(8);
                } else {
                    bsStep(sort);
                }

                document.getElementById("<%= Label1.ClientID %>").style.display = "none";//隐藏lable
                //bsStep(i) i 为number 可定位到第几步 如bsStep(2)/bsStep(3)
            })
</script>
    </form>
</body>
</html>
