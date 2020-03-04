<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="资产处置统计查询.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.统计查询.资产处置统计查询" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <style type="text/css">
        span{
            font-weight:bold;
        }
       
    </style>
</head>
<body>
<%--    <form id="form1" runat="server">
       <f:PageManager ID="PageManager1" AutoSizePanelID="Panel5" runat="server" />
        <f:Panel runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Form runat="server" ID="Form5" ShowBorder="false" ShowHeader="false">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TwinTriggerBox runat="server"  EmptyText="输入要搜索的关键词" ShowLabel="false" ID="tSearch" ShowTrigger1="false" 
                                    Trigger1Icon="Clear" Trigger2Icon="Search" OnClientTrigger2Click="" OnTrigger2Click="tSearch_Trigger2Click">
                                </f:TwinTriggerBox>
                                <f:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    <f:ListItem Text="处置临时状态-全部" Value="filter1" />
                                    <f:ListItem Text="处置临时状态-待报废" Value="filter2" />
                                    <f:ListItem Text="处置临时状态-待出售" Value="filter3" />
                                    <f:ListItem Text="处置临时状态-待调拨" Value="filter4" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid runat="server" ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" EnableCollapse="false" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                     IsDatabasePaging="false" ShowHeader="true" DataKeyNames="ID" EnableCheckBoxSelect="false">
                    <Columns>
                        <f:RowNumberField></f:RowNumberField>
                        <f:RenderField ColumnID="处置临时状态" DataField="处置临时状态" HeaderText="处置临时状态"></f:RenderField>
                        <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产类型"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="资产型号"></f:RenderField>
                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="位置" />
                        <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>
                        <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                        <f:RenderField ColumnID="投入使用日期" DataField="投入使用日期" HeaderText="投运日期" />
                        <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" ExpandUnusedSpace="true" />
                    </Columns>

                </f:Grid>
            </Items>
        </f:Panel>
    </form>--%>
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
                                    <f:ListItem Text="处置临时状态-全部" Value="filter1" />
                                    <f:ListItem Text="处置临时状态-待报废" Value="filter2" />
                                    <f:ListItem Text="处置临时状态-待出售" Value="filter3" />
                                    <f:ListItem Text="处置临时状态-待调拨" Value="filter4" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid runat="server" ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false" ShowHeader="true" DataKeyNames="ID" EnableCheckBoxSelect="false">
                    <Columns>
                        <f:RowNumberField></f:RowNumberField>
                        <f:RenderField ColumnID="处置临时状态" DataField="处置临时状态" HeaderText="处置临时状态"></f:RenderField>
                        <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产类型"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="资产型号"></f:RenderField>
                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="位置" />
                        <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>
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
