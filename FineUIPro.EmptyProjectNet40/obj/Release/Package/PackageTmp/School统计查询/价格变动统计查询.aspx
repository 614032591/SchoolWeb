<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="价格变动统计查询.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.统计查询.价格变动统计查询" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
        <style type="text/css">
        span{
            font-weight:bold;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Form runat="server" ID="Form6" ShowBorder="false" ShowHeader="false">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="tSearch" ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search" OnTrigger2Click="tSearch_Trigger2Click">
                                </f:TwinTriggerBox>
                                <f:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    <f:ListItem Text="流程状态-全部" Value="filter1" />
                                    <f:ListItem Text="流程状态-待审核" Value="filter2" />
                                    <f:ListItem Text="流程状态-已完成" Value="filter3" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid runat="server" ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    IsDatabasePaging="false" ShowHeader="true" OnRowCommand="Grid1_RowCommand" DataKeyNames="ID,流程状态,单据编号,事项名称,申请人,申请日期,记账人,总数,总价,变动方式,变动原因,记账人意见,备注信息,资产ID,str变动金额,Sort" EnableCheckBoxSelect="false" >
                    <Columns>
                        <f:RowNumberField></f:RowNumberField>
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                        <f:RenderField ColumnID="单据编号" DataField="单据编号" HeaderText="单据编号"></f:RenderField>
                        <f:RenderField ColumnID="事项名称" DataField="事项名称" HeaderText="事项名称"></f:RenderField>
                        <f:RenderField ColumnID="申请人" DataField="申请人" HeaderText="申请人"></f:RenderField>
                        <f:RenderField ColumnID="申请日期" DataField="申请日期" HeaderText="申请日期" />
                        <f:RenderField ColumnID="记账人" DataField="记账人" HeaderText="记账人" />
                        <f:RenderField ColumnID="总数" DataField="总数" HeaderText="总数" />
                        <f:RenderField ColumnID="总价" DataField="总价" HeaderText="总价" />
                        <f:RenderField ColumnID="变动方式" DataField="变动方式" HeaderText="变动方式" />
                        <f:RenderField ColumnID="变动原因" DataField="变动原因" HeaderText="变动原因"></f:RenderField>
                        <f:RenderField ColumnID="记账人意见" DataField="记账人意见" HeaderText="记账人意见"></f:RenderField>
                        <f:RenderField ColumnID="备注信息" DataField="备注信息" HeaderText="备注信息" ExpandUnusedSpace="true"></f:RenderField>
                        <f:LinkButtonField Width="160" CommandName="Action1" Text="查看详情" Icon="ApplicationGo" />
                        <f:TemplateField HeaderText="新标签页打开" Width="100px">
                            <ItemTemplate>
                                <a href="javascript:;" onclick="<%# GetEditUrls(Eval("单据编号"), Eval("Sort")) %>">流程进度</a>
                            </ItemTemplate>
                        </f:TemplateField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>

        <f:Window ID="Window3" Title="查看/处理" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            Width="1100px">
            <Items>
                <f:Panel ID="Panel2" IsFluid="true" CssClass="blockpanel" runat="server" ShowBorder="false" Layout="VBox" BodyPadding="10px" ShowHeader="false">
                    <Items>
                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                            <br />
                            <br />
                            <f:TextBox runat="server" Label="流程状态" ID="查看流程状态" Width="300px" LabelWidth="120" Enabled="false"></f:TextBox>
                            <f:TextBox runat="server" Label="单据编号" ID="查看单据编号" Width="300px" LabelWidth="120" Enabled="false"></f:TextBox>
                            <f:TextBox runat="server" Label="事项名称" ID="查看事项名称" Width="300px" LabelWidth="120" Enabled="false"></f:TextBox>
                            <br />
                            <f:TextBox runat="server" Label="申请人" ID="查看申请人" Width="300px" LabelWidth="120" Enabled="false"></f:TextBox>
                            <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="申请日期" EmptyText="申请日期"
                                ID="查看申请日期" ShowRedStar="true" Width="300px" LabelWidth="120" Enabled="false">
                            </f:DatePicker>

                            <f:TextBox runat="server" Label="记账人" ID="查看记账人" Width="300px" LabelWidth="120" Enabled="false"></f:TextBox>

                            <f:Grid ID="Grid4" ShowBorder="true" BoxFlex="1" ShowHeader="true" Title="原值变动资产数据"
                                EnableCollapse="false" runat="server"
                                DataKeyNames="ID" AllowCellEditing="true" ClicksToEdit="1" Height="200px">


                                <Columns>
                                    <f:RowNumberField />
                                    <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                                    <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                                    <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                                    <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                                    <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号" Hidden="true"></f:RenderField>
                                    <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向" Hidden="true"></f:RenderField>
                                    <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量" />
                                    <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="房间名称" />
                                    <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="部门名称" />
                                    <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                                    <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>
                                    <f:BoundField Width="120px" DataField="价格" HeaderText="价格" EnableColumnHide="false" DataFormatString="¥{0:F}" />
                                    <f:BoundField Width="120px" DataField="变动金额" HeaderText="变动金额" EnableColumnHide="false" DataFormatString="¥{0:F}" />
                                </Columns>

                            </f:Grid>

                            <br />
                            <f:Label ID="Label5" ShowLabel="false" runat="server" CssClass="red"></f:Label>
                            <br />
                            <f:DropDownList ID="查看变动方式" Label="变动方式" Width="300px" LabelWidth="120" AutoPostBack="true" Enabled="false" runat="server">
                                <f:ListItem Text="盘盈" Value="盘盈" />
                                <f:ListItem Text="资产核资增加" Value="资产核资增加" />
                                <f:ListItem Text="其他增加" Value="其他增加" />
                                <f:ListItem Text="盘亏" Value="盘亏" />
                                <f:ListItem Text="资产核资减少" Value="资产核资减少" />
                                <f:ListItem Text="其他减少" Value="其他减少" />

                            </f:DropDownList>
                            <f:TextBox runat="server" Label="变动原因" ID="查看变动原因" Width="300px" LabelWidth="120"  Enabled="false"></f:TextBox>
                            <f:TextBox runat="server" Label="记账人意见" ID="查看记账人意见" Width="300px" LabelWidth="120" Enabled="false"></f:TextBox>

                            <br />
                            <f:TextBox runat="server" Label="备注" ID="查看备注" LabelWidth="120" Enabled="false"></f:TextBox>
                             <f:TextBox ID="flowid" Label="flowid" runat="server" Hidden="true" Enabled="false"> </f:TextBox>
                        </f:ContentPanel>
                    </Items>

                    <Toolbars>
                        <f:Toolbar ID="Toolbar3" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <%--<f:Button ID="Button4" IconUrl="../res/icon/accept.png" runat="server" OnClick="Button4_Click"></f:Button>--%>
                                <f:Button ID="Button6" Icon="SystemClose" runat="server" OnClick="Button6_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:Panel>
            </Items>

        </f:Window>
    </form>
</body>
</html>
