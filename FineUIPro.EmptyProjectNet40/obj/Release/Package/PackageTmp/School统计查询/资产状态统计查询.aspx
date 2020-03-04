<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="资产状态统计查询.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.统计查询.资产状态统计查询" %>

<!DOCTYPE html>

<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<head runat="server">
    <%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <title></title>
        <style type="text/css">
        span{
            font-weight:bold;
        }
       
    </style>
</head>
<html>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Form ID="Form2" ShowBorder="false" ShowHeader="false" runat="server">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <%--<f:TriggerBox runat="server" EmptyText="输入要搜索的关键词" ID="ttSearch" ShowLabel="false" Readonly="false" OnTriggerClick="ttSearch_TriggerClick" EnableClickAction="true">
                                </f:TriggerBox>--%>
                                <%--<f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="ttSearch"  ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search">
                                </f:TwinTriggerBox>--%>
                                <%--  <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="ttSearch" ShowTrigger1="false" Trigger1Icon="Search"  OnTrigger1Click="ttSearch_Trigger1Click">
                                </f:TwinTriggerBox>--%>
                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="ttSearch" ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search" OnTrigger2Click="ttbSearch_Trigger2Click">
                                </f:TwinTriggerBox>

                                <f:DropDownList ID="DropDownList1" ShowLabel="false" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server">
                                    <f:ListItem Text="资产状态-全部" Value="filter1" />
                                    <f:ListItem Text="资产状态-使用中" Value="filter2" />
                                    <%--<f:ListItem Text="流程状态-已完成" Value="filter3" />--%>
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID,资产状态,编号,名称,类型,型号,房间名称,部门名称,负责人,投入使用日期,价格" OnRowCommand="Grid1_RowCommand" >
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <%--<f:Button ID="btnCheckSelection" runat="server" Text="资产处置"></f:Button>--%>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>
                        <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产类型"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="资产型号"></f:RenderField>
                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="位置" />
                        <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                        <f:RenderField ColumnID="投入使用日期" DataField="投入使用日期" HeaderText="投运日期" />
                        <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" ExpandUnusedSpace="true" />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
