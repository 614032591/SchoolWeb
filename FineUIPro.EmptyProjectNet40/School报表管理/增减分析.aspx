<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="增减分析.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.School报表管理.增减分析" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <f:Panel ID="Panel7" runat="server" BodyPadding="10px"
            Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Form ID="Form5" ShowBorder="False" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:DropDownList ID="DropDownList2" Label="单位" LabelWidth="50" Enabled="false" AutoPostBack="true"
                                    runat="server">
                                    <f:ListItem Text="四中" Value="filter1" />
                                    <%--<f:ListItem Text="过滤条件二" Value="filter2" />
                                    <f:ListItem Text="过滤条件三" Value="filter3" />--%>
                                </f:DropDownList>
                                <f:DropDownList ID="DropDownList1" Label="统计方式" LabelWidth="100" EmptyText="全部" AutoPostBack="true"
                                    runat="server">
                                    <f:ListItem Text="全部" Value="filter1" />
                                    <f:ListItem Text="资产分类" Value="filter2" />
                                    <f:ListItem Text="归属信息" Value="filter3" />
                                    <f:ListItem Text="存放地点" Value="filter4" />
                                </f:DropDownList>
                                <f:DropDownList ID="DropDownList3" Label="层级" LabelWidth="50" AutoPostBack="true"
                                    runat="server">
                                    <f:ListItem Text="过滤条件一" Value="filter1" />
                                    <f:ListItem Text="过滤条件二" Value="filter2" />
                                    <f:ListItem Text="过滤条件三" Value="filter3" />
                                </f:DropDownList>
                                <%-- <f:TextBox runat="server" Label="资产分类" ID="资产分类" LabelWidth="100"></f:TextBox>
                                <f:TextBox runat="server" Label="归属信息" ID="归属信息" LabelWidth="100"></f:TextBox>
                                <f:TextBox runat="server" Label="存放地点" ID="存放地点" LabelWidth="100"></f:TextBox>--%>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="8% 18% 20%">
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
                        <f:FormRow ColumnWidths="8% 15% 17%">
                            <Items>
                                <f:Label ID="Label1" runat="server" Label="归属信息" LabelWidth="140" Width="100"></f:Label>
                                <f:DropDownList ID="部门" AutoPostBack="true" Width="250px" runat="server" Label="部门" AutoSelectFirstItem="false" LabelWidth="60" EmptyText="全部" OnSelectedIndexChanged="部门_SelectedIndexChanged">
                                </f:DropDownList>

                                <f:DropDownList ID="负责人" Width="250px" runat="server" AutoPostBack="true" Label="负责人" AutoSelectFirstItem="false" LabelWidth="80" EmptyText="全部">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="8% 15% 17%">
                            <Items>
                                <f:Label runat="server" Label="存放地点" LabelWidth="140" Width="100"></f:Label>
                                <f:DropDownList ID="存放地点" Required="true" Width="230px" runat="server" AutoSelectFirstItem="false" EmptyText="全部" Label="地点" LabelWidth="60" AutoPostBack="true" OnSelectedIndexChanged="存放地点_SelectedIndexChanged">
                                </f:DropDownList>
                                <f:DropDownList ID="房间" Width="230px" runat="server" EmptyText="全部" AutoSelectFirstItem="false" Label="房间" LabelWidth="80" AutoPostBack="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="12% 11% ">
                            <Items>
                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="账期" Width="200px" EmptyText="请输入起始日期"
                                    ID="开始日期" LabelWidth="50">
                                </f:DatePicker>
                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Width="150px" EmptyText="请输入截止日期"
                                    ID="截止日期">
                                </f:DatePicker>
                                <f:Button ID="btnIcon1" Text="确认查询" IconUrl="../res/icon/application_form_magnify.png" runat="server" CssClass="marginr" />
                                <%--<f:Button ID="Button2" Text="图标在左侧" Icon="Star" runat="server" CssClass="marginr" />--%>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ForceFit="true" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="true"
                    ShowHeader="true" runat="server" DataKeyNames="ID" EnableCheckBoxSelect="false" KeepCurrentSelection="false">
                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:GroupField HeaderText="资产分类" TextAlign="Center">
                            <Columns>
                                <f:BoundField Width="100px" DataField="名称" HeaderText="一级" TextAlign="Center" />
                                <f:BoundField Width="100px" DataField="二级" HeaderText="二级" TextAlign="Center" />
                                <f:BoundField Width="100px" DataField="三级" HeaderText="三级" TextAlign="Center" />
                            </Columns>
                        </f:GroupField>

                        <f:GroupField HeaderText="增加" TextAlign="Center">
                            <Columns>
                                <f:BoundField Width="100px" TextAlign="Center" DataField="数量" HeaderText="数量" />
                                <f:BoundField Width="100px" TextAlign="Center" DataField="原值" HeaderText="原值" />
                            </Columns>
                        </f:GroupField>
                        <f:GroupField HeaderText="减少" TextAlign="Center">
                            <Columns>
                                <f:BoundField Width="100px" TextAlign="Center" DataField="数量" HeaderText="数量" />
                                <f:BoundField Width="100px" TextAlign="Center" DataField="原值" HeaderText="原值" />
                            </Columns>
                        </f:GroupField>
                        <f:GroupField HeaderText="结存" TextAlign="Center">
                            <Columns>
                                <f:BoundField Width="100px" TextAlign="Center" DataField="数量" HeaderText="数量" />
                                <f:BoundField Width="100px" TextAlign="Center" DataField="原值" HeaderText="原值" />
                            </Columns>
                        </f:GroupField>
                                
                        <%--<f:RenderField ColumnID="资产分类" DataField="资产分类" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="原值" DataField="原值" HeaderText="原值"></f:RenderField>
                        <f:RenderField ColumnID="累计折旧" DataField="累计折旧" HeaderText="累计折旧"></f:RenderField>
                        <f:RenderField ColumnID="净值" DataField="净值" HeaderText="净值" ExpandUnusedSpace="true" />--%>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
