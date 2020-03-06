<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="资产处置.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.资产处置" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

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
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <f:Panel ID="Panel7" runat="server" BodyPadding="10px"
            Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Form ID="Form5" ShowBorder="False" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="8% 20% 20% 20%">
                            <Items>
                                <f:Label ID="Label2" runat="server" Label="资产分类" Width="100" LabelWidth="140"></f:Label>
                                <f:DropDownList ID="一级" Width="250px" runat="server" Label="一级" LabelWidth="60" AutoPostBack="true" AutoSelectFirstItem="false" EmptyText="全部" OnSelectedIndexChanged="一级_SelectedIndexChanged">
                                </f:DropDownList>
                                <f:DropDownList ID="二级" Width="250px" runat="server" EmptyText="全部" Label="二级" AutoSelectFirstItem="false" LabelWidth="80" AutoPostBack="true" OnSelectedIndexChanged="二级_SelectedIndexChanged">
                                </f:DropDownList>
                                <f:DropDownList ID="三级" Width="250px" runat="server" EmptyText="全部" Label="三级" AutoSelectFirstItem="false" LabelWidth="60" AutoPostBack="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="8% 20% 20% 20%">
                            <Items>
                                <f:Label ID="Label1" runat="server" Label="归属信息" LabelWidth="140" Width="100"></f:Label>
                                <f:DropDownList ID="部门" AutoPostBack="true" Width="250px" runat="server" Label="部门" AutoSelectFirstItem="false" LabelWidth="60" EmptyText="全部" OnSelectedIndexChanged="部门_SelectedIndexChanged">
                                </f:DropDownList>

                                <f:DropDownList ID="负责人" Width="250px" runat="server" AutoPostBack="true" Label="负责人" AutoSelectFirstItem="false" LabelWidth="80" EmptyText="全部">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="8% 20% 20% 20%">
                            <Items>
                                <f:Label runat="server" Label="存放地点" LabelWidth="140" Width="100"></f:Label>
                                <f:DropDownList ID="存放地点" Required="true" Width="230px" runat="server" AutoSelectFirstItem="false" EmptyText="全部" Label="地点" LabelWidth="60" AutoPostBack="true" OnSelectedIndexChanged="存放地点_SelectedIndexChanged">
                                </f:DropDownList>
                                <f:DropDownList ID="房间" Width="230px" runat="server" EmptyText="全部" AutoSelectFirstItem="false" Label="房间" LabelWidth="80" AutoPostBack="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="8% 20% 20% 20% ">
                            <Items>
                                <f:Label ID="Label3" runat="server" Label="投入时间" LabelWidth="140" Width="100"></f:Label>
                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd"
                                    ID="起始投入日期" ShowRedStar="true" Width="300px" EmptyText="请输入起始日期">
                                </f:DatePicker>

                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd"
                                    ID="结束投入日期" ShowRedStar="true" Width="300px" EmptyText="请输入截止日期">
                                </f:DatePicker>

                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="TwinTriggerBox1"
                                    ShowTrigger1="false"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" Width="250px">
                                </f:TwinTriggerBox>

                                <f:Button ID="Button5" Text="确认查询" IconUrl="../res/icon/application_form_magnify.png" runat="server" OnClick="Button5_Click" />

                            </Items>
                        </f:FormRow>
                    </Rows>

                </f:Form>
                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID" EnableCheckBoxSelect="true" KeepCurrentSelection="true" OnRowCommand="Grid1_RowCommand" OnPageIndexChange="Grid1_PageIndexChange">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>


                                <f:Button ID="btnCheckSelection" Text="资产处置" IconUrl="../res/icon/add.png" runat="server" OnClick="btnCheckSelection_Click">
                                </f:Button>


                                <f:Button ID="Button2" Text="待处置库" IconUrl="../res/icon/flag_yellow.png" runat="server" OnClick="Button2_Click">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产类型"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="资产型号"></f:RenderField>
                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="位置" />
                        <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                        <f:RenderField ColumnID="投入使用日期" DataField="投入使用日期" HeaderText="投运日期" />
                        <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" />
                        <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>

        <f:Window ID="Window1" Title="资产处置" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="400px">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>

                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                            <br />
                            <f:DropDownList ID="处置方式" Label="处置方式" Width="350px" LabelWidth="90" runat="server">
                                <f:ListItem Text="请选择" Value="请选择" EnableSelect="false" />
                                <f:ListItem Text="转入待报废库" Value="转入待报废库" />
                                <f:ListItem Text="转入待调拨库" Value="转入待调拨库" />
                                <f:ListItem Text="转入待报损库" Value="转入待报损库" />
                                <f:ListItem Text="转入待出售库" Value="转入待出售库" />
                            </f:DropDownList>

                        </f:ContentPanel>
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="Button1" IconUrl="../res/icon/accept.png" runat="server" Text="确定" OnClick="Button1_Click"></f:Button>
                                <f:Button ID="btnClose" Icon="SystemClose" runat="server" Text="关闭"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>
        <br />
        <br />
        <br />
        <%--  EnableIFrame="false"
            EnableMaximize="true" Target="Self" runat="server"
            --%>

        <f:Window ID="Window2" Title="待处置库" TitleAlign="Center" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self"  EnableResize="true" runat="server"
            IsModal="true" Width="1200px">
            <Items>
                <f:Form BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidth="25% 25% 25% 25%">
                            <Items>
                                <f:DropDownList ID="类别" Label="处置类别" Required="true" Width="300px" LabelWidth="120" AutoPostBack="true" runat="server" OnSelectedIndexChanged="类别_SelectedIndexChanged">
                                    <f:ListItem Text="待报废库" Value="待报废" />
                                    <f:ListItem Text="待调拨库" Value="待调拨" />
                                    <f:ListItem Text="待破损库" Value="待破损" />
                                    <f:ListItem Text="待出售库" Value="待出售" />
                                </f:DropDownList>

                                <f:DropDownList ID="添加方式" Label="添加方式" Required="true" Width="300px" LabelWidth="120" runat="server">
                                    <f:ListItem Text="全部" Value="全部" />
                                    <f:ListItem Text="普通添加" Value="普通添加" />
                                    <f:ListItem Text="盘亏处理" Value="盘亏处理" />
                                </f:DropDownList>

                                <f:DropDownList ID="时间排序" Label="排序方式" Required="true" AutoSelectFirstItem="true" AutoPostBack="true" OnSelectedIndexChanged="时间排序_SelectedIndexChanged" Width="300px" LabelWidth="120" runat="server">
                                    <f:ListItem Text="添加时间正序" Value="添加时间正序" />
                                    <f:ListItem Text="添加时间倒序" Value="添加时间倒序" />
                                    <f:ListItem Text="购置时间正序" Value="购置时间正序" />
                                    <f:ListItem Text="购置时间倒序" Value="购置时间倒序" />
                                </f:DropDownList>

                                <f:DropDownList ID="是否到期" Label="是否到期" Required="true" Width="300px" LabelWidth="120" runat="server">
                                    <f:ListItem Text="全部" Value="全部" />
                                    <f:ListItem Text="是" Value="是" />
                                    <f:ListItem Text="否" Value="否" />
                                </f:DropDownList>

                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
               
                <f:Grid ID="Grid2" Title="数据选择" IsFluid="true" CssClass="blockpanel" ShowBorder="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" EnableCheckBoxSelect="true" DataKeyNames="ID" KeepCurrentSelection="true">
                    <Toolbars>
                        <f:Toolbar Position="Top" ToolbarAlign="Left" runat="server">
                            <Items>
                                <f:Button ID="发起申报_zccz" Text="发起申报" Width="100" OnClick="发起申报_zccz_Click" runat="server"></f:Button>
                                <f:Button ID="添加资产_zccz" Text="添加资产" Width="100" OnClick="添加资产_zccz_Click" runat="server"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                        <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量" />
                        <f:RenderField ColumnID="原值" DataField="原值" HeaderText="原值" />
                        <f:RenderField ColumnID="净值" DataField="净值" HeaderText="净值" />
                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="存放地点" />
                        <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                        <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>
                        <f:RenderField ColumnID="购置日期" DataField="购置日期" HeaderText="购置日期"></f:RenderField>
                        <f:RenderField ColumnID="是否到期" DataField="是否到期" HeaderText="是否到期"></f:RenderField>
                        <f:RenderField ColumnID="添加时间" DataField="添加时间" HeaderText="添加时间"></f:RenderField>

                        <%--  <f:LinkButtonField CommandName="Action1" Text="删除" Icon="Delete" />--%>
                    </Columns>
                </f:Grid>

                <%-- <f:SimpleForm ID="SimpleForm2" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="HiddenField1" runat="server"></f:HiddenField>
                        <f:TabStrip ID="TabStrip2" IsFluid="true" CssClass="blockpanel" Height="500px" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                            <Tabs>
                                <f:Tab Title="<span class='highlight'>待处置库</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    <Items>
                                        <f:Form runat="server">
                                            <Items>
                                            </Items>
                                        </f:Form>
                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">

                                            
                                        </f:ContentPanel>
                                    </Items>
                                </f:Tab>



                            </Tabs>
                        </f:TabStrip>
                    </Items>

                </f:SimpleForm>--%>
            </Items>
        </f:Window>



        <%-- 固定资产处置单(报废) --%>
        <f:Window ID="Window3" Title="固定资产处置单(报废)" Hidden="true" TitleAlign="Center" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1400px">
            <Items>
                <f:Form ID="Form7" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="25% 25% 25% 25% ">
                            <Items>
                                <f:TextBox ID="报废流程状态" Label="流程状态" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="报废单据编号" Label="单据编号" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="报废_申请人" Label="申请人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="报废_申报单位" Label="申报单位" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <%--<f:DropDownList ID="报废_申报单位" Width="250px" runat="server" Label="调入单位" LabelWidth="90" AutoPostBack="true" AutoSelectFirstItem="false" EmptyText="请选择！">
                                </f:DropDownList>--%>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>
                                <f:TextBox ID="报废_职务" Label="职务" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="报废_电话" Label="电话" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="报废_事项名称" Label="事项名称" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="申报日期" EmptyText="请选择日期"
                                    ID="报废_申报日期" ShowRedStar="true" Width="250px" LabelWidth="90" Readonly="true">
                                </f:DatePicker>



                                <%--<f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="验收日期" EmptyText="请选择日期"
                                    ID="报废验收日期" ShowRedStar="true" Width="250px" LabelWidth="90">
                                </f:DatePicker>--%>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="25% 10%">
                            <Items>
                                <f:TextBox ID="报废_原因说明" Label="原因说明" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" AutoColumnWidth="false" runat="server" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                                    <f:RadioItem Text="处置单" Selected="true" Value="处置单" />
                                    <f:RadioItem Text="明细表" Value="明细表" />
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid3" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="true" runat="server" DataKeyNames="ID" Height="300px" EnableSummary="true" SummaryPosition="Bottom">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格" DataField="价格" HeaderText="原值"></f:RenderField>
                        <f:RenderField ColumnID="净值" DataField="净值" HeaderText="净值"></f:RenderField>
                        <f:RenderField ColumnID="处置方式" DataField="处置方式" HeaderText="处置方式" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>

                <f:Grid ID="Grid4" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="true" runat="server" DataKeyNames="ID" Height="300px" EnableSummary="true" SummaryPosition="Bottom" Hidden="true">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                        <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" />
                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="存放地点" />
                        <f:RenderField ColumnID="部门名称" DataField="归属部门1" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                    </Columns>
                </f:Grid>
            </Items>

            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:TextBox runat="server" Label="FlowID" ID="FlowID" Hidden="true" LabelWidth="80"></f:TextBox>
                        <f:TextBox runat="server" Label="资产ID" ID="资产ID" Hidden="true" LabelWidth="80"></f:TextBox>
                        <f:TextBox runat="server" Label="FlowName" ID="FlowName" Hidden="true" LabelWidth="80"></f:TextBox>
                        <f:Button ID="资产处置报废申报" Icon="ApplicationGo" runat="server" Text="提交" OnClick="资产处置报废申报_Click"></f:Button>
                        <f:Button ID="btnon" Icon="SystemClose" OnClick="btnon_Click" runat="server" Text="关闭"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>

        <%-- 固定资产处置单(调拨) --%>
        <f:Window ID="Window4" Title="固定资产处置单(调拨)" Hidden="true" TitleAlign="Center"  EnableIFrame="false"
            EnableMaximize="true" Target="Self" runat="server"
            IsModal="true" Width="1400px">
            <Items>

                <f:Form ID="Form3" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="25% 25% 25% 25% ">
                            <Items>
                                <f:TextBox ID="调拨流程状态" Label="流程状态" Width="250px" runat="server" LabelWidth="90" Readonly="true">
                                </f:TextBox>
                                <f:TextBox ID="调拨单据编号" Label="单据编号" Width="250px" runat="server" LabelWidth="90" Readonly="true">
                                </f:TextBox>
                                <f:TextBox ID="调拨_申请人" Label="申请人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调拨调出单位" Label="调出单位" Width="250px" runat="server" LabelWidth="90" Readonly="true">
                                </f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>
                                <f:TextBox ID="调拨职务" Label="职务" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调拨电话" Label="电话" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调拨_事项名称" Label="事项名称" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="申报日期" EmptyText="请选择日期"
                                    ID="调拨申报日期" ShowRedStar="true" Width="250px" LabelWidth="90" Readonly="true">
                                </f:DatePicker>

                            </Items>
                        </f:FormRow>


                        <f:FormRow ColumnWidths="25% 25% 25% 10%">
                            <Items>
                                <f:DropDownList ID="调拨调入单位" Width="250px" runat="server" Label="调入单位" LabelWidth="90" AutoPostBack="true" AutoSelectFirstItem="false" EmptyText="请选择！">
                                </f:DropDownList>

                                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="验收日期" EmptyText="请选择日期"
                                    ID="调拨验收日期" ShowRedStar="true" Width="250px" LabelWidth="90">
                                </f:DatePicker>

                                <f:TextBox ID="调拨原因说明" Label="原因说明" Width="250px" runat="server" LabelWidth="90"></f:TextBox>

                                <f:RadioButtonList ID="Unnamed" AutoPostBack="true" AutoColumnWidth="false" runat="server" OnSelectedIndexChanged="Unnamed_SelectedIndexChanged">
                                    <f:RadioItem Text="处置单" Selected="true" Value="处置单" />
                                    <f:RadioItem Text="明细表" Value="明细表" />
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>

                        <%--   <f:FormRow ColumnWidths="10%">
                            <Items>
                                <f:RadioButtonList ID="Unnamed" AutoPostBack="true" AutoColumnWidth="false" runat="server" OnSelectedIndexChanged="Unnamed_SelectedIndexChanged">
                                    <f:RadioItem Text="处置单" Selected="true" Value="处置单" />
                                    <f:RadioItem Text="明细表" Value="明细表" />
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>--%>

                        
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid5" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" AllowPaging="true" EnableSummary="true" SummaryPosition="Bottom"
                    ShowHeader="false" runat="server" DataKeyNames="ID" Height="300px" EnableCheckBoxSelect="false" IsDatabasePaging="false">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格" DataField="价格" HeaderText="原值"></f:RenderField>
                        <f:RenderField ColumnID="净值" DataField="净值" HeaderText="净值"></f:RenderField>
                        <f:RenderField ColumnID="处置方式" DataField="处置方式" HeaderText="处置方式" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>



                <f:Grid ID="Grid6" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" AllowPaging="true" EnableSummary="true" SummaryPosition="Bottom"
                    ShowHeader="false" runat="server" DataKeyNames="ID" Height="300px" EnableCheckBoxSelect="false" IsDatabasePaging="false" Hidden="true">

                    <Columns>
                        <f:RowNumberField />

                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                        <%--     <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" />--%>
                        <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" />
                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="存放地点" />
                        <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                        <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态" ExpandUnusedSpace="true"></f:RenderField>


                    </Columns>
                </f:Grid>




            </Items>
            <Toolbars>
                <f:Toolbar ID="Toolbar5" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="资产处置调拨申报" Icon="ApplicationGo" runat="server" Text="提交" OnClick="资产处置调拨申报_Click"></f:Button>
                        <f:Button ID="Button8" Icon="ApplicationGo" runat="server" Hidden="true" Text="处理" ConfirmText="是否审核通过？"></f:Button>
                        <f:Button ID="Button9" Icon="SystemClose" runat="server" Text="关闭"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>


        <%-- 资产处置添加资产 --%>
        <f:Window ID="添加资产" Title="添加资产" Hidden="true" TitleAlign="Center"  EnableIFrame="false"
            EnableMaximize="true" Target="Self" runat="server"
            IsModal="true" Width="1400px">
            <Items>
                <f:Form BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidth="25% 25% 25% 25%">
                            <Items>
                                <f:DropDownList ID="资产分类_tjcz" Width="250px" runat="server" Label="资产分类" LabelWidth="80" EmptyText="全部">
                                </f:DropDownList>
                                <f:DropDownList ID="存放地点_tjcz" Width="250px" runat="server" Label="存放地点" LabelWidth="80" EmptyText="全部">
                                </f:DropDownList>
                                <f:DropDownList ID="归属信息_tjcz" Width="250px" runat="server" Label="归属信息" LabelWidth="80" EmptyText="全部">
                                </f:DropDownList>
                                <f:DropDownList ID="是否到期_tjcz" Width="250px" runat="server" Label="是否到期" LabelWidth="80" EmptyText="全部">
                                    <f:ListItem  Text="是"/>
                                    <f:ListItem  Text="否"/>
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidth="20%" >
                            <Items>
                                
                                <f:DatePicker ID="起始日期_tjcz" EmptyText="请输入起始日期" Label="购置日期" runat="server"></f:DatePicker>
                                <f:DatePicker ID="截止日期_tjcz" EmptyText="请输入截止日期" runat="server"></f:DatePicker>
                               <%-- <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="模糊查询_tjcz"
                                    ShowTrigger1="false"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" Width="250px">
                                </f:TwinTriggerBox>--%>
                                <f:Button ID="确认查询_tjcz" Text="确认查询" runat="server" OnClick="确认查询_tjcz_Click"></f:Button>
                                <f:Button ID="确认添加_tjcz" Text="确认添加" runat="server" OnClick="确认添加_tjcz_Click"></f:Button>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <%--  ID="Grid资产处置添加资产" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID" EnableCheckBoxSelect="true" KeepCurrentSelection="true" --%>
                <f:Grid ID="Grid12" runat="server" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false" DataKeyNames="ID"
                    ShowHeader="true" EnableCheckBoxSelect="true" KeepCurrentSelection="true">
                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产类型"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="资产型号"></f:RenderField>
                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="位置" />
                        <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                        <f:RenderField ColumnID="投入使用日期" DataField="投入使用日期" HeaderText="投运日期" />
                        <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" />
                        <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Window>


                <f:Window ID="添加资产资产处置" Title="资产处置" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="400px">
            <Items>
                <f:SimpleForm ID="SimpleForm2" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>

                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                            <br />
                            <f:DropDownList ID="处置方式_tjzcczfs" Label="处置方式" Width="350px" LabelWidth="90" runat="server">
                                <f:ListItem Text="请选择" Value="请选择" EnableSelect="false" />
                                <f:ListItem Text="转入待报废库" Value="转入待报废库" />
                                <f:ListItem Text="转入待调拨库" Value="转入待调拨库" />
                                <f:ListItem Text="转入待报损库" Value="转入待报损库" />
                                <f:ListItem Text="转入待出售库" Value="转入待出售库" />
                            </f:DropDownList>

                        </f:ContentPanel>
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar4" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="Button3" IconUrl="../res/icon/accept.png" runat="server" Text="确定" OnClick="Button3_Click"></f:Button>
                                <f:Button ID="Button4" Icon="SystemClose" runat="server" Text="关闭" OnClick="Button4_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>
    </form>
</body>
</html>
