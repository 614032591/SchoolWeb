<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="结存分析.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.School报表管理.结存分析" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <style>
        .f-grid-row-summary .f-grid-cell-inner {
            font-weight: bold;
            color: red;
        }

        .f-grid-cell[data-color=color1] {
            background-color: #0094ff;
            color: #fff;
        }

        .f-grid-row .f-grid-cell-总账面净值 {
            /*background-color: #0094ff;*/
            background-color: #609BF4;
            color: #fff;
        }

         .color1 {
            background-color: #0094ff;
            color: #fff;
        }

        .color2 {
            background-color: #0026ff;
            color: #fff;
        }

        .color3 {
            background-color: #b200ff;
            color: #fff;
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
                        <f:FormRow  ColumnWidths="12% 12% 12%">
                            <Items>
                                <f:DropDownList ID="DropDownList2" Label="单位" LabelWidth="80" EmptyText="四中" AutoPostBack="true" Enabled="false"
                                    runat="server">
                                    <f:ListItem Text="四中" Value="filter1" />
                                </f:DropDownList>

                                <f:DatePicker ID="EndTime" runat="server" EnableClickAction="true" DateFormatString="yyyy-MM-dd" Label="账期" Width="200px" EmptyText="请选择日期" AutoPostBack="true" OnDateSelect="账期_DateSelect" EnableDateSelectEvent="true" LabelWidth="80">
                                </f:DatePicker>
                                <f:DropDownList ID="DropDownList1" Label="统计方式" LabelWidth="100" Hidden="true" EmptyText="全部" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                    runat="server">
                                    <f:ListItem Text="全部" Value="0" />
                                    <f:ListItem Text="资产分类" Value="1" />
                                    <f:ListItem Text="归属信息" Value="2" />
                                    <f:ListItem Text="存放地点" Value="3" />
                                </f:DropDownList>


                                <%-- <f:DropDownList ID="DropDownList3" Label="层级" LabelWidth="50" AutoPostBack="true"
                                    runat="server">
                                    <f:ListItem Text="一级" Value="filter1" />
                                    <f:ListItem Text="二级" Value="filter2" />
                                    <f:ListItem Text="三级" Value="filter3" />
                                </f:DropDownList>--%>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="12% 11% ">
                            <Items>
                                <f:RadioButtonList ID="Radios" AutoPostBack="true" AutoColumnWidth="false" OnSelectedIndexChanged="Radios_SelectedIndexChanged1" runat="server">
                                    <f:RadioItem Text="汇总表" Selected="true" Value="汇总表" />
                                    <f:RadioItem Text="明细表" Value="明细表" />
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="fr1" Hidden="true" ColumnWidths="8% 18% 18% 18%">
                            <Items>
                                <f:Label ID="Label2" runat="server" Label="资产分类" Width="100" LabelWidth="140"></f:Label>

                                <f:DropDownList ID="一级" Width="260px" runat="server" Label="一级" LabelWidth="80" AutoPostBack="true" AutoSelectFirstItem="false" EmptyText="全部" OnSelectedIndexChanged="一级_SelectedIndexChanged">
                                </f:DropDownList>

                                <f:DropDownList ID="二级" Width="260px" runat="server" EmptyText="全部" Label="二级" AutoSelectFirstItem="false" LabelWidth="80" AutoPostBack="true" OnSelectedIndexChanged="二级_SelectedIndexChanged">
                                </f:DropDownList>

                                <f:DropDownList ID="三级" Width="260px" runat="server" EmptyText="全部" Label="三级" AutoSelectFirstItem="false" LabelWidth="80" AutoPostBack="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="fr2" Hidden="true" ColumnWidths="8% 18% 18%">
                            <Items>
                                <f:Label ID="Label1" runat="server" Label="归属信息" LabelWidth="140" Width="100"></f:Label>

                                <f:DropDownList ID="部门" AutoPostBack="true" Width="260px" runat="server" Label="部门" AutoSelectFirstItem="false" LabelWidth="80" EmptyText="全部" OnSelectedIndexChanged="部门_SelectedIndexChanged">
                                </f:DropDownList>

                                <f:DropDownList ID="负责人" Width="260px" runat="server" AutoPostBack="true" Label="负责人" AutoSelectFirstItem="false" LabelWidth="80" EmptyText="全部">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ID="fr3" Hidden="true" ColumnWidths="8% 18% 18%">
                            <Items>
                                <f:Label runat="server" Label="存放地点" LabelWidth="140" Width="100"></f:Label>

                                <f:DropDownList ID="存放地点" Required="true" Width="260px" runat="server" AutoSelectFirstItem="false" EmptyText="全部" Label="地点" LabelWidth="80" AutoPostBack="true" OnSelectedIndexChanged="存放地点_SelectedIndexChanged">
                                </f:DropDownList>

                                <f:DropDownList ID="房间" Width="260px" runat="server" EmptyText="全部" AutoSelectFirstItem="false" Label="房间" LabelWidth="80" AutoPostBack="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="fr4" Hidden="true" ColumnWidths="20% 10%">
                            <Items>
                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="TwinTriggerBox1"
                                    ShowTrigger1="false"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" Width="260px">
                                </f:TwinTriggerBox>
                                <f:Button ID="Button5" Text="确认查询" IconUrl="../res/icon/application_form_magnify.png" runat="server" OnClick="Button5_Click" />
                            </Items>
                        </f:FormRow>
                        

                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ForceFit="true" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID" EnableCheckBoxSelect="false" KeepCurrentSelection="false" EnableSummary="true" SummaryPosition="Top">
                    <%-- <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <f:Button ID="btnCheckSelection" Text="资产处置" IconUrl="../res/icon/add.png" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>--%>
                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" TextAlign="Center" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="总清查数量" DataField="总清查数量" TextAlign="Center" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="总账面原值" DataField="总账面原值" TextAlign="Center" HeaderText="原值"></f:RenderField>
                        <f:RenderField ColumnID="累计折旧" DataField="累计折旧" TextAlign="Center" HeaderText="累计折旧"></f:RenderField>
                        <f:RenderField ColumnID="总账面净值" DataField="总账面净值" TextAlign="Center" HeaderText="净值" />


                    </Columns>
                </f:Grid>
                <f:Grid ID="Grid2" Hidden="true" Title="数据表格" PageSize="15" IsFluid="true" ForceFit="true" CssClass="blockpanel" EnableCollapse="false" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID" EnableCheckBoxSelect="false"   KeepCurrentSelection="false" EnableSummary="true" OnRowDataBound="Grid2_RowDataBound" SummaryPosition="Top">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="资产编号" DataField="资产编号" HeaderText="资产编号" TextAlign="Center"></f:RenderField>
                        <f:BoundField  ColumnID="名称"  DataField="名称" HeaderText="资产名称" TextAlign="Center"></f:BoundField>
                        <f:RenderField ColumnID="btn类型" DataField="类型" HeaderText="资产分类" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号" TextAlign="Center"></f:RenderField>
                        <f:BoundField ColumnID="购置日期" DataField="购置日期" HeaderText="购置日期" TextAlign="Center"></f:BoundField>
                        <f:RenderField ColumnID="归属部门" DataField="归属部门" HeaderText="归属部门" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="存放地点" DataField="存放地点" HeaderText="存放地点" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="原值" DataField="原值" HeaderText="原值" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="净值" DataField="净值" HeaderText="净值" TextAlign="Center"></f:RenderField>
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
                        <f:HiddenField ID="hfFormID" runat="server"></f:HiddenField>
                        <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" Height="200px" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                            <Tabs>
                                <f:Tab Title="<span class='highlight'>资产处置</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    <Items>
                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                            <br />
                                            <f:DropDownList ID="处置方式" Label="处置方式" Width="350px" LabelWidth="90" runat="server">
                                                <f:ListItem Text="请选择" Value="请选择" EnableSelect="false" />
                                                <f:ListItem Text="转入待报废库" Value="转入待报废库" />
                                                <f:ListItem Text="转入待调拨库" Value="转入待调拨库" />
                                                <f:ListItem Text="转入待报损库" Value="转入待报损库" />
                                                <f:ListItem Text="转入待出售库" Value="转入待出售库" />
                                                <%--  <f:ListItem Text="可选项6" Value="Value6" />--%>
                                            </f:DropDownList>

                                        </f:ContentPanel>
                                    </Items>
                                </f:Tab>



                            </Tabs>
                        </f:TabStrip>

                        <%--        <f:Button ID="Button3" CssClass="marginr" ValidateForms="SimpleForm1"
                            Text="验证第一个标签中的表单" runat="server">
                        </f:Button>
                        <f:Button ID="Button4" Text="打开下一个标签"  runat="server">
                        </f:Button>--%>
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="Button1" IconUrl="../res/icon/accept.png" runat="server" Text="确定"></f:Button>
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


    </form>
</body>
</html>
