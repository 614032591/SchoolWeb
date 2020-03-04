<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="折旧分析.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.School报表管理.折旧分析" %>

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
            background-color:#609BF4;
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
                                <f:DropDownList ID="DropDownList2" Label="单位" LabelWidth="80" EmptyText="四中" Enabled="false" AutoPostBack="true"
                                    runat="server">
                                    <f:ListItem Text="四中" Value="filter1" />
                                    <%--<f:ListItem Text="过滤条件二" Value="filter2" />
                                    <f:ListItem Text="过滤条件三" Value="filter3" />--%>
                                </f:DropDownList>
                               <f:DatePicker ID="EndTime" runat="server" EnableClickAction="true" DateFormatString="yyyy-MM-dd" Label="账期" Width="200px" EmptyText="请选择日期" AutoPostBack="true" OnDateSelect="EndTime_DateSelect" EnableDateSelectEvent="true" LabelWidth="80">
                                </f:DatePicker>
                                <f:DropDownList ID="DropDownList1" Label="统计方式" LabelWidth="110" Hidden="true" EmptyText="全部" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                    runat="server">
                                    <f:ListItem Text="全部" Value="0" />
                                    <f:ListItem Text="资产分类" Value="1" />
                                    <f:ListItem Text="归属信息" Value="2" />
                                    <f:ListItem Text="存放地点" Value="3" />
                                </f:DropDownList>                          
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
                    </Rows>
                    <Rows>
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
                        <%-- <f:FormRow ColumnWidths="8% 20% 20% 20%">
                            <Items>
                                <f:Label runat="server" Label="存放地点" LabelWidth="140" Width="100"></f:Label>
                                <f:DropDownList ID="存放地点_a" Required="true" Width="230px" runat="server" AutoSelectFirstItem="false" EmptyText="全部" Label="地点" LabelWidth="60" AutoPostBack="true" OnSelectedIndexChanged="存放地点_a_SelectedIndexChanged">
                                </f:DropDownList>
                                <f:DropDownList ID="房间" Width="230px" runat="server" EmptyText="全部" AutoSelectFirstItem="false" Label="房间" LabelWidth="80" AutoPostBack="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow> --%>
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
                    ShowHeader="true" runat="server" DataKeyNames="ID" EnableCheckBoxSelect="false" KeepCurrentSelection="false"  EnableSummary="true" SummaryPosition="Top">
                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="资产名称" DataField="名称" HeaderText="资产名称" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="总清查数量" DataField="总清查数量" HeaderText="数量" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="总账面原值" DataField="总账面原值" HeaderText="原值" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="本期折旧" DataField="本期折旧" HeaderText="本期折旧" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="累计折旧" DataField="累计折旧" HeaderText="累计折旧" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="总账面净值" DataField="总账面净值" HeaderText="净值" TextAlign="Center"></f:RenderField>
                        <%--<f:RenderField ColumnID="资产编号" DataField="资产编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="资产分类" DataField="资产分类" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="规格型号" DataField="规格型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="购置日期" DataField="购置日期" HeaderText="购置日期"></f:RenderField>
                        <f:RenderField ColumnID="归属部门" DataField="归属部门" HeaderText="归属部门"></f:RenderField>
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人"></f:RenderField>
                        <f:RenderField ColumnID="存放地点" DataField="存放地点" HeaderText="存放地点"></f:RenderField>
                        <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                        <f:RenderField ColumnID="折旧年限" DataField="折旧年限" HeaderText="折旧年限" ExpandUnusedSpace="true"></f:RenderField>--%>
                    </Columns>
                </f:Grid>
                <f:Grid ID="Grid2" Hidden="true" Title="数据表格" PageSize="15" IsFluid="true"  ForceFit="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID" EnableCheckBoxSelect="false" KeepCurrentSelection="false"  EnableSummary="true" SummaryPosition="Top">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="资产编号" DataField="资产编号" HeaderText="资产编号" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="资产分类" DataField="类型" HeaderText="资产分类" TextAlign="Center"></f:RenderField>
                        <%--<f:RenderField ColumnID="类型" DataField="类型" HeaderText="规格型号" TextAlign="Center"></f:RenderField>--%>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="购置日期" DataField="购置日期" HeaderText="购置日期" TextAlign="Center"></f:RenderField>
                         <f:RenderField ColumnID="归属部门" DataField="归属部门" HeaderText="归属部门" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="存放地点" DataField="存放地点" HeaderText="存放地点" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="本期折旧" DataField="本期折旧" HeaderText="本期折旧" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="累计折旧" DataField="累计折旧" HeaderText="累计折旧" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="净值" DataField="净值" HeaderText="净值" TextAlign="Center"></f:RenderField>
                        <f:RenderField ColumnID="预计使用年数" DataField="预计使用年数" HeaderText="折旧年限" TextAlign="Center"></f:RenderField>
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
