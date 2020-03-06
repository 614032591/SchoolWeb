<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="处置申报.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.申报审批.处置申报" %>

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
    <%-- 处置申报 --%>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <f:Panel ID="Panel7" runat="server" BodyPadding="10px"
            Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Form ID="Form5" ShowBorder="False" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidth="50% 50%">
                            <Items>
                                <f:DropDownList ID="申报种类"  Label="申报种类" AutoSelectFirstItem="true" AutoPostBack="true" OnSelectedIndexChanged="申报种类_SelectedIndexChanged" runat="server">
                                    <f:ListItem Text="全部" Value="全部" />
                                    <f:ListItem Text="报废" Value="报废" />
                                    <f:ListItem Text="调拨" Value="调拨" />
                                    <f:ListItem Text="报损" Value="报损" />
                                    <f:ListItem Text="出售" Value="出售" />
                                    
                                </f:DropDownList>
                                <%--<f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="ttbSearch"
                                    ShowTrigger1="false"
                                    Trigger1Icon="Clear" Trigger2Icon="Search">
                                </f:TwinTriggerBox>--%>
                                <f:DropDownList ID="流程状态" ShowLabel="false" Label="流程状态" AutoPostBack="true"
                                    OnSelectedIndexChanged="流程状态_SelectedIndexChanged" runat="server">
                                    <f:ListItem Text="流程状态-全部" Value="filter1" />
                                    <f:ListItem Text="流程状态-待审核" Value="filter2" />
                                    <f:ListItem Text="流程状态-已通过" Value="filter3" />
                                    <f:ListItem Text="流程状态-未通过" Value="filter3" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID,SID,Sort,流程状态,单据编号,FlowName,总数,总价,申报日期,申报单位,申请人,原因说明,职务,电话,验收日期,调入单位,调出单位,事项名称,调出单位分管领导意见,调出单位分管领导,调出单位分管领导处理时间,调入单位管理员意见,调入单位管理员,调入单位管理员处理时间,调入单位分管领导意见,调入单位分管领导,调入单位分管领导处理时间,主管部门意见,主管部门处理时间,主管部门,财政部门意见,财政部门,财政部门处理时间" EnableCheckBoxSelect="true" OnRowCommand="Grid1_RowCommand">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <f:Button ID="btnCheckSelection" Text="发起申报(待处置库)" IconUrl="../res/icon/add.png" runat="server" OnClick="btnCheckSelection_Click">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="SID" DataField="SID" HeaderText="SID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="Sort" DataField="Sort" HeaderText="Sort" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                        <f:RenderField ColumnID="单据编号" DataField="单据编号" HeaderText="单据编号"></f:RenderField>
                        <f:RenderField ColumnID="事项名称" DataField="事项名称" HeaderText="事项名称" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="总数" DataField="总数" HeaderText="数量合计" />
                        <f:RenderField ColumnID="总价" DataField="总价" HeaderText="原值合计" />
                        <f:RenderField ColumnID="FlowName" DataField="FlowName" HeaderText="申报种类" Width="120" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="申报单位" DataField="申报单位" HeaderText="申报单位" />
                        <f:RenderField ColumnID="申请人" DataField="申请人" HeaderText="申请人" />
                        <f:RenderField ColumnID="申报日期" DataField="申报日期" HeaderText="申报日期" ExpandUnusedSpace="true" />
                        <f:RenderField ColumnID="原因说明" DataField="原因说明" HeaderText="原因说明" Hidden="True" />
                        <f:RenderField ColumnID="分管领导" DataField="分管领导" HeaderText="分管领导" Hidden="True" />
                        <f:RenderField ColumnID="职务" DataField="职务" HeaderText="职务" Hidden="True" />
                        <f:RenderField ColumnID="电话" DataField="电话" HeaderText="电话" Hidden="True" />
                        <f:RenderField ColumnID="调入单位" DataField="调入单位" HeaderText="调入单位" Hidden="True" />
                        <f:RenderField ColumnID="调出单位" DataField="调出单位" HeaderText="调出单位" Hidden="True" />
                        <f:RenderField ColumnID="SID" DataField="SID" HeaderText="SID" Hidden="True" />
                        <f:RenderField ColumnID="验收日期" DataField="验收日期" HeaderText="验收日期" Hidden="True" />

                        <f:RenderField ColumnID="调出单位分管领导意见" DataField="调出单位分管领导意见" HeaderText="调出单位分管领导意见" Hidden="True" />
                        <f:RenderField ColumnID="调出单位分管领导" DataField="调出单位分管领导" HeaderText="调出单位分管领导" Hidden="True" />
                        <f:RenderField ColumnID="调出单位分管领导处理时间" DataField="调出单位分管领导处理时间" HeaderText="调出单位分管领导处理时间" Hidden="True" />
                        <f:RenderField ColumnID="调入单位管理员意见" DataField="调入单位管理员意见" HeaderText="调入单位管理员意见" Hidden="True" />
                        <f:RenderField ColumnID="调入单位管理员" DataField="调入单位管理员" HeaderText="调入单位管理员" Hidden="True" />
                        <f:RenderField ColumnID="调入单位管理员处理时间" DataField="调入单位管理员处理时间" HeaderText="调入单位管理员处理时间" Hidden="True" />
                        <f:RenderField ColumnID="调入单位分管领导意见" DataField="调入单位分管领导意见" HeaderText="调入单位分管领导意见" Hidden="True" />
                        <f:RenderField ColumnID="调入单位分管领导" DataField="调入单位分管领导" HeaderText="调入单位分管领导" Hidden="True" />
                        <f:RenderField ColumnID="调入单位分管领导处理时间" DataField="调入单位分管领导处理时间" HeaderText="调入单位分管领导处理时间" Hidden="True" />
                        <f:RenderField ColumnID="主管部门意见" DataField="主管部门意见" HeaderText="主管部门意见" Hidden="True" />
                        <f:RenderField ColumnID="主管部门处理时间" DataField="主管部门处理时间" HeaderText="主管部门处理时间" Hidden="True" />
                        <f:RenderField ColumnID="主管部门" DataField="主管部门" HeaderText="主管部门" Hidden="True" />
                        <f:RenderField ColumnID="财政部门意见" DataField="财政部门意见" HeaderText="财政部门意见" Hidden="True" />
                        <f:RenderField ColumnID="财政部门" DataField="财政部门" HeaderText="财政部门" Hidden="True" />
                        <f:RenderField ColumnID="财政部门处理时间" DataField="财政部门处理时间" HeaderText="财政部门处理时间" Hidden="True" />




                        <f:LinkButtonField Width="160" CommandName="Action1" Text="查看详情" Icon="ApplicationGo" />
                        <f:TemplateField HeaderText="新标签页打开" Width="100px">
                            <ItemTemplate>
                                <a href="javascript:;" onclick="<%# GetEditUrls(Eval("ID"),Eval("FlowName"),Eval("单据编号"), Eval("Sort"), Eval("SID")) %>">流程进度</a>
                            </ItemTemplate>
                        </f:TemplateField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>

        <%-- 待处置库 --%>
        <f:Window ID="Window1" Title="待处置库" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1200px">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="hfFormID" runat="server"></f:HiddenField>
                        <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" Height="500px" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                            <Tabs>
                                <f:Tab Title="<span class='highlight'>待处置库</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    <Items>
                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                            <br />
                                            <f:DropDownList ID="类别" Label="类别" Required="true" Width="300px" LabelWidth="120" AutoPostBack="true" runat="server" OnSelectedIndexChanged="类别_SelectedIndexChanged">
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
                                            
                                            <f:DropDownList ID="是否到期" Label="是否到期" Required="true" Width="300px" LabelWidth="120" runat="server">
                                                <f:ListItem Text="全部" Value="全部" />
                                                <f:ListItem Text="是" Value="是" />
                                                <f:ListItem Text="否" Value="否" />
                                            </f:DropDownList>

                                            <f:Grid ID="Grid2" Title="数据选择" IsFluid="true" CssClass="blockpanel" ShowBorder="true" IsDatabasePaging="false"
                                                ShowHeader="true" runat="server" EnableCheckBoxSelect="true" DataKeyNames="ID" KeepCurrentSelection="true" Height="350px">

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
                                                    <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" />
                                                    <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="存放地点" />
                                                    <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                                                    <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                                                    <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>
                                                    <%--  <f:LinkButtonField CommandName="Action1" Text="删除" Icon="Delete" />--%>
                                                </Columns>
                                            </f:Grid>
                                        </f:ContentPanel>
                                    </Items>
                                </f:Tab>
                            </Tabs>
                        </f:TabStrip>
                        <%--<f:Button ID="Button3" CssClass="marginr" ValidateForms="SimpleForm1"
                            Text="验证第一个标签中的表单" runat="server">
                        </f:Button>
                        <f:Button ID="Button4" Text="打开下一个标签"  runat="server">
                        </f:Button>--%>
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="Button1" Icon="ApplicationGo" runat="server" Text="确认申报" OnClick="Button1_Click"></f:Button>
                                <f:Button ID="btnClose" Icon="SystemClose" runat="server" Text="关闭" OnClick="btnClose_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>
        <br />
        <br />
        <br />
        <%-- 固定资产处置单(报废) --%>
        <f:Window ID="Window2" Title="固定资产处置单(报废)" Hidden="true" EnableIFrame="false"
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
                        <f:Button ID="Button2" Icon="ApplicationGo" runat="server" Text="提交" OnClick="Button2_Click"></f:Button>
                        <f:Button ID="btnon" Icon="SystemClose" OnClick="btnon_Click" runat="server" Text="关闭"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>

        <%-- 固定资产处置单(调拨) --%>
        <f:Window ID="Window3" Title="固定资产处置单(调拨)" Hidden="true" TitleAlign="Center" EnableIFrame="false"
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
                <f:Grid ID="Grid5" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" AllowPaging="true"  EnableSummary="true" SummaryPosition="Bottom"
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



                <f:Grid ID="Grid6" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" AllowPaging="true"  EnableSummary="true" SummaryPosition="Bottom"
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
                        <f:Button ID="Button7" Icon="ApplicationGo" runat="server" Text="提交" OnClick="Button8_Click"></f:Button>
                        <f:Button ID="Button8" Icon="ApplicationGo" runat="server" Hidden="true" Text="处理" ConfirmText="是否审核通过？"></f:Button>
                        <f:Button ID="Button9" Icon="SystemClose" runat="server" Text="关闭"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>



        <%-- 待处置库报废查看详情 --%>

        <f:Window ID="Window4" Title="固定资产处置单" Hidden="true" TitleAlign="Center" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1400px">
            <Items>
                <f:Form ID="Form8" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="25% 25% 25% 25% ">
                            <Items>
                                <f:TextBox ID="流程状态_abfckxq" Label="流程状态" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="单据编号_bfckxq" Label="单据编号" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="申请人_bfckxq" Label="申请人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="申报单位_bfckxq" Label="申报单位" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <%--<f:DropDownList ID="报废_申报单位" Width="250px" runat="server" Label="调入单位" LabelWidth="90" AutoPostBack="true" AutoSelectFirstItem="false" EmptyText="请选择！">
                                </f:DropDownList>--%>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>
                                <f:TextBox ID="职务_bfckxq" Label="职务" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="电话_bfckxq" Label="电话" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="事项名称_bfckxq" Label="事项名称" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="申报日期" EmptyText="请选择日期"
                                    ID="申报日期_ckxq" ShowRedStar="true" Width="250px" LabelWidth="90" Readonly="true">
                                </f:DatePicker>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="25% 10%">
                            <Items>
                                <f:TextBox ID="原因说明_bfckxq" Label="原因说明" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:RadioButtonList ID="RadioButtonList3" AutoPostBack="true" AutoColumnWidth="false" runat="server" OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged">
                                    <f:RadioItem Text="处置单" Selected="true" Value="处置单" />
                                    <f:RadioItem Text="明细表" Value="明细表" />
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>

                <f:Grid ID="Grid7" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="true" runat="server" DataKeyNames="ID" Height="300px" EnableSummary="true" SummaryPosition="Bottom">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="类型_bfckxq" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="数量_bfckxq" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格_bfckxq" DataField="价格" HeaderText="原值"></f:RenderField>
                        <f:RenderField ColumnID="净值_bfckxq" DataField="净值" HeaderText="净值"></f:RenderField>
                        <f:RenderField ColumnID="处置方式_bfckxq" DataField="处置方式" HeaderText="处置方式" ExpandUnusedSpace="true"></f:RenderField>

                    </Columns>
                </f:Grid>

                <f:Grid ID="Grid8" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="true" runat="server" DataKeyNames="ID" Height="300px" EnableSummary="true" SummaryPosition="Bottom" Hidden="true">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID_bfckxq" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="编号_bfckxq" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="类型_bfckxq" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="名称_bfckxq" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="型号_bfckxq" DataField="型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="使用方向_bfckxq" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                        <f:RenderField ColumnID="数量_bfckxq" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格_bfckxq" DataField="价格" HeaderText="价格" />
                        <f:RenderField ColumnID="房间名称_bfckxq" DataField="房间名称" HeaderText="存放地点" />
                        <f:RenderField ColumnID="部门名称_bfckxq" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人_bfckxq" DataField="负责人" HeaderText="负责人" />
                        <f:RenderField ColumnID="资产状态_bfckxq" DataField="资产状态" HeaderText="资产状态" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>
            </Items>
            <Items>
                <f:Form ID="Form9" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="分管领导" runat="server"></f:Label>
                                <f:TextBox ID="分管领导处理意见_bfckxq" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="分管领导_bfckxq" Label="分管领导" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="分管领导操作时间_bfckxq" Label="操作时间" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <%--<f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="操作时间" EmptyText="请选择日期"
                                    ID="分管领导操作时间_bfckxq" ShowRedStar="true" Width="250px" LabelWidth="90">
                                </f:DatePicker>--%>

                                <%--<br />
                                <f:Label runat="server" Width="100px"></f:Label>
                                <f:TextBox ID="TextBox2" Label="事项名称" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="职务_bfckxq" Label="职务" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="电话_bfckxq" Label="电话" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <br />
                                <f:TextBox ID="主管部门意见_bfckxq" Label="主管部门意见" Width="400px" runat="server" LabelWidth="120"></f:TextBox>
                                <f:TextBox ID="财政部门意见_bfckxq" Label="财政部门意见" Width="400px" runat="server" LabelWidth="120"></f:TextBox>
                                <br />
                                <f:TextBox ID="批复文号_bfckxq" Label="批复文号" Width="400px" runat="server" LabelWidth="120"></f:TextBox>
                                <f:TextBox ID="申报文号_bfckxq" Label="申报文号" Width="400px" runat="server" LabelWidth="120"></f:TextBox>--%>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="主管部门" runat="server"></f:Label>
                                <f:TextBox ID="主管部门处理意见_bfckxq" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="主管部门_bfckxq" Label="操作人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="主管部门操作时间_bfckxq" Label="操作时间" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <%-- <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="操作时间" EmptyText="请选择日期"
                                    ID="主管部门操作时间_bfckxq" ShowRedStar="true" Width="250px" LabelWidth="90">
                                </f:DatePicker>--%>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="财政部门" runat="server"></f:Label>
                                <f:TextBox ID="财政部门意见_bfckxq" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="财政部门_bfckxq" Label="操作人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="财政部门操作时间_bfckxq" Label="操作时间" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <%--<f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="操作时间" EmptyText="请选择日期"
                                    ID="财政部门操作时间_bfckxq" ShowRedStar="true" Width="250px" LabelWidth="90">
                                </f:DatePicker>--%>
                                <%--<f:TextBox ID="批复文号_bfckxq" Label="批复文号" Width="400px" runat="server" LabelWidth="120"></f:TextBox>
                                <f:TextBox ID="申报文号_bfckxq" Label="申报文号" Width="400px" runat="server" LabelWidth="120"></f:TextBox>--%>
                                <f:TextBox runat="server" Label="FlowID" ID="TextBox1" Hidden="true" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="资产ID" ID="TextBox2" Hidden="true" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="Sort" ID="Sort" Hidden="true" LabelWidth="80"></f:TextBox>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>

            <Toolbars>
                <f:Toolbar ID="Toolbar8" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="Button15" Icon="ApplicationGo" runat="server" Text="处理" OnClick="Button15_Click"></f:Button>
                        <f:Button ID="Button16" Icon="SystemClose" runat="server" Text="关闭" OnClick="Button16_Click1"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>



        <%-- 待处置库调拨查看详情 --%>

        <f:Window ID="Window5" Title="固定资产处置单" Hidden="true" TitleAlign="Center" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1400px">
            <Items>


                <f:Form ID="Form2" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="25% 25% 25% 25% ">
                            <Items>
                                <f:TextBox ID="流程状态_dbckxq" Label="流程状态" Width="250px" runat="server" LabelWidth="90" Readonly="true">
                                </f:TextBox>

                                <f:TextBox ID="单据编号_dbckxq" Label="单据编号" Width="250px" runat="server" LabelWidth="90" Readonly="true">
                                </f:TextBox>

                                <f:TextBox ID="申请人_dbckxq" Label="申请人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调出单位_dbckxq" Label="调出单位" Width="250px" runat="server" LabelWidth="90" Readonly="true">
                                </f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>

                                <f:TextBox ID="职务_dbckxq" Label="职务" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="电话_dbckxq" Label="电话" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="事项名称_dbckxq" Label="事项名称" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="申报日期" EmptyText="请选择日期"
                                    ID="申报日期_dbckxq" ShowRedStar="true" Width="250px" LabelWidth="90" Readonly="true">
                                </f:DatePicker>
                            </Items>
                        </f:FormRow>


                        <f:FormRow ColumnWidths="25% 25% 10% ">
                            <Items>

                                <f:TextBox ID="调入单位_dbckxq" Label="调入单位" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="验收日期" EmptyText="请选择日期"
                                    ID="验收日期_dbckxq" ShowRedStar="true" Width="250px" LabelWidth="90" Readonly="true">
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
                    ShowHeader="true" runat="server" DataKeyNames="ID" Height="300px" EnableSummary="true" SummaryPosition="Bottom">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="类型_dbckxq" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="数量_db" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格_db" DataField="价格" HeaderText="原值"></f:RenderField>
                        <f:RenderField ColumnID="净值_bfckxq" DataField="净值" HeaderText="净值"></f:RenderField>
                        <f:RenderField ColumnID="处置方式_dbckxq" DataField="处置方式" HeaderText="处置方式" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>

                <f:Grid ID="Grid10" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="true" runat="server" DataKeyNames="ID" Height="300px" Hidden="true" EnableSummary="true" SummaryPosition="Bottom">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID_bfckxq" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="编号_bfckxq" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="类型_bfckxq" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="名称_bfckxq" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="型号_bfckxq" DataField="型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="使用方向_bfckxq" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                        <f:RenderField ColumnID="数量_db" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格_db" DataField="价格" HeaderText="价格" />
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
                                <f:TextBox ID="调出单位分管领导意见" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调出单位分管领导" Label="分管领导" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调出单位分管领导处理时间" Label="操作日期" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="调入单位管理员" runat="server"></f:Label>
                                <f:TextBox ID="调入单位管理员意见" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调入单位管理员" Label="分管领导" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调入单位管理员处理时间" Label="操作日期" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="调入单位分管领导" runat="server"></f:Label>
                                <f:TextBox ID="调入单位分管领导意见" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调入单位分管领导" Label="分管领导" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调入单位分管领导处理时间" Label="操作日期" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="主管部门" runat="server"></f:Label>
                                <f:TextBox ID="调拨主管部门意见" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="主管部门" Label="操作人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="主管部门处理时间" Label="操作日期" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="财政部门" runat="server"></f:Label>
                                <f:TextBox ID="调拨财政部门意见" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="财政部门" Label="操作人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="财政部门处理时间" Label="操作日期" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>




                    </Rows>
                </f:Form>






            </Items>

            <Toolbars>
                <f:Toolbar ID="Toolbar9" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <%--  <f:Button ID="btnzcczdbok" Icon="ApplicationGo" EnablePostBack="false" runat="server" Text="处理" OnClick="btnzcczdbok_Click"></f:Button>--%>
                        <f:Button ID="btntanchuang" Icon="ApplicationGo" runat="server" Text="处理" OnClick="btntanchuang_Click"></f:Button>
                        <f:Button ID="btnzcczdbno" Icon="SystemClose" runat="server" Text="关闭" OnClick="btnzcczdbno_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>












        </f:Window>


        <f:Window ID="审批处理界面" Title="审批/处理界面" Hidden="true"
            Target="Self" runat="server"
            IsModal="true" Width="350px">
            <Items>
                <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                    <br />
                    <f:TextArea runat="server" ID="处理意见" LabelWidth="90" EmptyText="请输入！默认同意！" Label="处理意见">
                    </f:TextArea>
                    <br />
                </f:ContentPanel>
            </Items>

            <Toolbars>
                <f:Toolbar ID="Toolbar6" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="ZCCLSPYES" Icon="ApplicationGo" runat="server" Text="同意" OnClick="ZCCLSPYES_Click"></f:Button>
                        <f:Button ID="ZCCLSPNO" Icon="SystemClose" runat="server" Text="拒绝" OnClick="ZCCLSPNO_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>


    </form>
    <script>
        var windowClientID = '<%= Window1.ClientID %>';
        var gridClientID = '<%= Grid1.ClientID %>';
        var formClientID = '<%= SimpleForm1.ClientID %>';
        var hfFormIDClientID = '<%= hfFormID.ClientID %>';
        <%--var mainTabStripClientID = '<%= mainTabStrip.ClientID %>';
        var windowThemeRollerClientID = '<%= windowThemeRoller.ClientID %>';--%>

        function onEditButtonClick(event) {
            F(windowClientID).show();
            //showEditWindow();
        }

        function showEditWindow(rowId) {
            var grid = F(gridClientID);

            // 如果传入参数为空，则获取当前选中行
            if (!rowId) {
                var selectedRowIds = grid.getSelectedRows();
                if (!selectedRowIds.length) {
                    //F.alert('请至少选择一项！');
                    //return;
                }

                rowId = selectedRowIds[0];
            }


            F(windowClientID).setTitle('xxx');

            // 当前行数据
            var rowValue = grid.getRowValue(rowId);
            F(windowClientID).show();
        }
    </script>
</body>
</html>
