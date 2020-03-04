<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="申报记录统计查询.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.统计查询.申报记录统计查询" %>

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
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel9" runat="server" />
        <f:Panel ID="Panel7" runat="server" BodyPadding="10px"
            Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Form ID="Form5" ShowBorder="False" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="ttbSearch"
                                    ShowTrigger1="false"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" OnClientTrigger2Click="" OnTrigger2Click="ttbSearch_Trigger2Click">
                                </f:TwinTriggerBox>
                                <f:DropDownList ID="DropDownList1" ShowLabel="false" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server">
                                    <f:ListItem Text="流程状态-全部" Value="filter1" />
                                    <f:ListItem Text="流程状态-待审核" Value="filter2" />
                                    <f:ListItem Text="流程状态-已完成" Value="filter3" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true"
                     BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID,SID,Sort,流程状态,单据编号,Mark,总数,总价,申报日期,申报单位,申请人,原因说明,分管领导,职务,电话,主管部门意见,财政部门意见,批复文号,申报文号" EnableCheckBoxSelect="true">

                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="Sort" DataField="Sort" HeaderText="Sort" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                        <f:RenderField ColumnID="单据编号" DataField="单据编号" HeaderText="单据编号"></f:RenderField>
                        <f:RenderField ColumnID="Mark" DataField="Mark" HeaderText="处置方式"></f:RenderField>
                        <f:RenderField ColumnID="总数" DataField="总数" HeaderText="数量合计" />
                        <f:RenderField ColumnID="总价" DataField="总价" HeaderText="原值合计" />
                        <f:RenderField ColumnID="申报日期" DataField="申报日期" HeaderText="申报日期" />
                        <f:RenderField ColumnID="申报单位" DataField="申报单位" HeaderText="申报单位" />
                        <f:RenderField ColumnID="申请人" DataField="申请人" HeaderText="申请人" ExpandUnusedSpace="true" />
                        <f:RenderField ColumnID="原因说明" DataField="原因说明" HeaderText="原因说明" Hidden="True" />
                        <f:RenderField ColumnID="分管领导" DataField="分管领导" HeaderText="分管领导" Hidden="True" />
                        <f:RenderField ColumnID="职务" DataField="职务" HeaderText="职务" Hidden="True" />
                        <f:RenderField ColumnID="电话" DataField="电话" HeaderText="电话" Hidden="True" />

                        <f:RenderField ColumnID="主管部门意见" DataField="主管部门意见" HeaderText="主管部门意见" Hidden="True" />
                        <f:RenderField ColumnID="财政部门意见" DataField="财政部门意见" HeaderText="财政部门意见" Hidden="True" />
                        <f:RenderField ColumnID="批复文号" DataField="批复文号" HeaderText="批复文号" Hidden="True" />
                        <f:RenderField ColumnID="申报文号" DataField="申报文号" HeaderText="申报文号" Hidden="True" />
                         <f:RenderField ColumnID="SID" DataField="SID" HeaderText="SID" Hidden="True" />
                        <f:RenderField ColumnID="验收日期" DataField="验收日期" HeaderText="验收日期" Hidden="True" />
                        <f:RenderField ColumnID="调入单位" DataField="调入单位" HeaderText="调入单位" Hidden="True" />
                        <f:RenderField ColumnID="调出单位" DataField="调出单位" HeaderText="调出单位" Hidden="True" />
                        <f:RenderField ColumnID="调入单位意见" DataField="调入单位意见" HeaderText="调入单位意见" Hidden="True" />
                        <f:LinkButtonField Width="160" CommandName="Action1" Text="查看详情" Icon="ApplicationGo" />
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
                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="ttbSearch" ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search" OnTrigger2Click="ttbSearch_Trigger2Click">
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
                <f:Grid runat="server" ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false" ShowHeader="true" DataKeyNames="ID" EnableCheckBoxSelect="false">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="Sort" DataField="Sort" HeaderText="Sort" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                        <f:RenderField ColumnID="单据编号" DataField="单据编号" HeaderText="单据编号"></f:RenderField>
                        <f:RenderField ColumnID="Mark" DataField="Mark" HeaderText="处置方式"></f:RenderField>
                        <f:RenderField ColumnID="总数" DataField="总数" HeaderText="数量合计" />
                        <f:RenderField ColumnID="总价" DataField="总价" HeaderText="原值合计" />
                        <f:RenderField ColumnID="申报日期" DataField="申报日期" HeaderText="申报日期" />
                        <f:RenderField ColumnID="申报单位" DataField="申报单位" HeaderText="申报单位" />
                        <f:RenderField ColumnID="申请人" DataField="申请人" HeaderText="申请人" ExpandUnusedSpace="true" />
                        <f:RenderField ColumnID="原因说明" DataField="原因说明" HeaderText="原因说明" Hidden="True" />
                        <f:RenderField ColumnID="分管领导" DataField="分管领导" HeaderText="分管领导" Hidden="True" />
                        <f:RenderField ColumnID="职务" DataField="职务" HeaderText="职务" Hidden="True" />
                        <f:RenderField ColumnID="电话" DataField="电话" HeaderText="电话" Hidden="True" />

                        <f:RenderField ColumnID="主管部门意见" DataField="主管部门意见" HeaderText="主管部门意见" Hidden="True" />
                        <f:RenderField ColumnID="财政部门意见" DataField="财政部门意见" HeaderText="财政部门意见" Hidden="True" />
                        <f:RenderField ColumnID="批复文号" DataField="批复文号" HeaderText="批复文号" Hidden="True" />
                        <f:RenderField ColumnID="申报文号" DataField="申报文号" HeaderText="申报文号" Hidden="True" />
                         <f:RenderField ColumnID="SID" DataField="SID" HeaderText="SID" Hidden="True" />
                        <f:RenderField ColumnID="验收日期" DataField="验收日期" HeaderText="验收日期" Hidden="True" />
                        <f:RenderField ColumnID="调入单位" DataField="调入单位" HeaderText="调入单位" Hidden="True" />
                        <f:RenderField ColumnID="调出单位" DataField="调出单位" HeaderText="调出单位" Hidden="True" />
                        <f:RenderField ColumnID="调入单位意见" DataField="调入单位意见" HeaderText="调入单位意见" Hidden="True" />
                        <f:LinkButtonField Width="160" CommandName="Action1" Text="查看详情" Icon="ApplicationGo" />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
