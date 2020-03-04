<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="原值变动.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.原值变动" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .f-grid-row .f-grid-cell-变动金额 {
            background-color: #0094ff;
            color: #fff;
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
                        <f:FormRow>
                            <Items>
                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="ttbSearch"
                                    ShowTrigger1="false"
                                    Trigger1Icon="Clear" Trigger2Icon="Search">
                                </f:TwinTriggerBox>
                                <f:DropDownList ID="DropDownList1" ShowLabel="false" AutoPostBack="true"
                                    runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    <f:ListItem Text="流程状态-全部" Value="filter1" />
                                    <f:ListItem Text="流程状态-待审核" Value="filter2" />
                                    <f:ListItem Text="流程状态-已完成" Value="filter3" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID,流程状态,单据编号,事项名称,申请人,申请日期,记账人,总数,总价,变动方式,变动原因,记账人意见,备注信息,资产ID,str变动金额,Sort" EnableCheckBoxSelect="true" OnRowCommand="Grid1_RowCommand">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <f:Button ID="btnCheckSelection" Text="新增原值变动" IconUrl="../res/icon/application_add.png" runat="server" OnClick="btnCheckSelection_Click">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField />
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
                        <f:RenderField ColumnID="资产ID" DataField="资产ID" HeaderText="资产ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="str变动金额" DataField="str变动金额" HeaderText="str变动金额" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="Sort" DataField="Sort" HeaderText="Sort" Hidden="True"></f:RenderField>
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





        <f:Window ID="Window1" Title="新增原值变动" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            Width="1100px">
            <Items>
                <f:Panel ID="Panel2" IsFluid="true" CssClass="blockpanel" runat="server" ShowBorder="false" Layout="VBox" BodyPadding="10px" ShowHeader="false">
                    <Items>
                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">

                            <f:Button ID="btnIcon1" Text="添加资产" Icon="Add" runat="server" CssClass="marginr" OnClick="btnIcon1_Click" />
                            <br />
                            <br />
                            <f:TextBox runat="server" Label="流程状态" ID="流程状态" Width="300px" LabelWidth="120"></f:TextBox>
                            <f:TextBox runat="server" Label="单据编号" ID="单据编号" Width="300px" LabelWidth="120"></f:TextBox>
                            <f:TextBox runat="server" Label="事项名称" ID="事项名称" Width="300px" LabelWidth="120"></f:TextBox>
                            <br />
                            <f:TextBox runat="server" Label="申请人" ID="申请人" Width="300px" LabelWidth="120"></f:TextBox>
                            <%--<f:TextBox runat="server" Label="申请日期" ID="申请日期" Width="300px" LabelWidth="120"></f:TextBox>--%>
                            <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="申请日期" EmptyText="申请日期"
                                ID="申请日期" ShowRedStar="true" Width="300px" LabelWidth="120">
                            </f:DatePicker>

                            <f:TextBox runat="server" Label="记账人" ID="记账人" Width="300px" LabelWidth="120"></f:TextBox>

                            <f:Grid ID="Grid2" ShowBorder="true" BoxFlex="1" ShowHeader="true" Title="原值变动"
                                EnableCollapse="false" runat="server"
                                DataKeyNames="ID" AllowCellEditing="true" ClicksToEdit="1" Height="200px">


                                <Columns>
                                    <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
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
                                    <f:RenderField Width="100px" ColumnID="变动金额" DataField="变动金额" FieldType="Int"
                                        HeaderText="变动金额">
                                        <Editor>
                                            <f:NumberBox ID="moneynum" NoDecimal="true" NoNegative="true" runat="server">
                                            </f:NumberBox>
                                        </Editor>
                                    </f:RenderField>
                                </Columns>

                            </f:Grid>

                            <br />
                            <f:Label ID="Label4" ShowLabel="false" runat="server" CssClass="red"></f:Label>
                            <br />
                            <f:DropDownList ID="变动方式" Label="变动方式" Width="300px" LabelWidth="120" AutoPostBack="true" runat="server">
                                <f:ListItem Text="盘盈" Value="盘盈" />
                                <f:ListItem Text="资产核资增加" Value="资产核资增加" />
                                <f:ListItem Text="其他增加" Value="其他增加" />
                                <f:ListItem Text="盘亏" Value="盘亏" />
                                <f:ListItem Text="资产核资减少" Value="资产核资减少" />
                                <f:ListItem Text="其他减少" Value="其他减少" />

                            </f:DropDownList>
                            <f:TextBox runat="server" Label="变动原因" ID="变动原因" Width="300px" LabelWidth="120"></f:TextBox>
                            <f:TextBox runat="server" Label="记账人意见" ID="记账人意见" Width="300px" LabelWidth="120"></f:TextBox>

                            <br />
                            <f:TextBox runat="server" Label="备注" ID="备注" LabelWidth="120"></f:TextBox>
                        </f:ContentPanel>
                    </Items>

                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="Button1" Icon="ApplicationGo" runat="server" Text="提交" OnClick="Button1_Click"></f:Button>
                                <f:Button ID="btnClose" Icon="SystemClose" runat="server" Text="关闭"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:Panel>
            </Items>

        </f:Window>


        <f:Window ID="Window3" Title="查看/处理" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            Width="1100px">
            <Items>
                <f:Panel ID="Panel1" IsFluid="true" CssClass="blockpanel" runat="server" ShowBorder="false" Layout="VBox" BodyPadding="10px" ShowHeader="false">
                    <Items>
                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                            <br />
                            <br />
                            <f:TextBox runat="server" Label="流程状态" ID="查看流程状态" Width="300px" LabelWidth="120"></f:TextBox>
                            <f:TextBox runat="server" Label="单据编号" ID="查看单据编号" Width="300px" LabelWidth="120"></f:TextBox>
                            <f:TextBox runat="server" Label="事项名称" ID="查看事项名称" Width="300px" LabelWidth="120"></f:TextBox>
                            <br />
                            <f:TextBox runat="server" Label="申请人" ID="查看申请人" Width="300px" LabelWidth="120"></f:TextBox>
                            <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="申请日期" EmptyText="申请日期"
                                ID="查看申请日期" ShowRedStar="true" Width="300px" LabelWidth="120">
                            </f:DatePicker>

                            <f:TextBox runat="server" Label="记账人" ID="查看记账人" Width="300px" LabelWidth="120"></f:TextBox>

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
                            <f:DropDownList ID="查看变动方式" Label="变动方式" Width="300px" LabelWidth="120" AutoPostBack="true" runat="server">
                                <f:ListItem Text="盘盈" Value="盘盈" />
                                <f:ListItem Text="资产核资增加" Value="资产核资增加" />
                                <f:ListItem Text="其他增加" Value="其他增加" />
                                <f:ListItem Text="盘亏" Value="盘亏" />
                                <f:ListItem Text="资产核资减少" Value="资产核资减少" />
                                <f:ListItem Text="其他减少" Value="其他减少" />

                            </f:DropDownList>
                            <f:TextBox runat="server" Label="变动原因" ID="查看变动原因" Width="300px" LabelWidth="120"></f:TextBox>
                            <f:TextBox runat="server" Label="记账人意见" ID="查看记账人意见" Width="300px" LabelWidth="120"></f:TextBox>

                            <br />
                            <f:TextBox runat="server" Label="备注" ID="查看备注" LabelWidth="120"></f:TextBox>
                            <f:TextBox ID="flowid" Label="flowid" runat="server" Hidden="true"></f:TextBox>
                        </f:ContentPanel>
                    </Items>

                    <Toolbars>
                        <f:Toolbar ID="Toolbar3" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="Button4" IconUrl="../res/icon/accept.png" runat="server" OnClick="Button4_Click"></f:Button>
                                <f:Button ID="Button6" Icon="SystemClose" runat="server" OnClick="Button6_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:Panel>
            </Items>

        </f:Window>


        <f:Window ID="Window2" Title="添加需要转移的资产" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1200px">
            <Items>

                <f:Form ID="Form2" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="8% 20% 20% 20%">
                            <Items>
                                <f:Label ID="Label2" runat="server" Label="资产分类" Width="100" LabelWidth="140"></f:Label>

                                <f:DropDownList ID="一级" Width="250px" runat="server" Label="一级" LabelWidth="60" AutoPostBack="true" AutoSelectFirstItem="false" EmptyText="全部">
                                </f:DropDownList>

                                <f:DropDownList ID="二级" Width="250px" runat="server" EmptyText="全部" Label="二级" AutoSelectFirstItem="false" LabelWidth="60" AutoPostBack="true">
                                </f:DropDownList>

                                <f:DropDownList ID="三级" Width="250px" runat="server" EmptyText="全部" Label="三级" AutoSelectFirstItem="false" LabelWidth="60" AutoPostBack="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="8% 20% 20% 20% 20%">
                            <Items>
                                <f:Label ID="Label1" runat="server" Label="归属信息/存放地点" LabelWidth="140" Width="100"></f:Label>
                                <f:DropDownList ID="部门" AutoPostBack="true" Width="230px" runat="server" Label="部门" AutoSelectFirstItem="false" LabelWidth="60" EmptyText="全部">
                                </f:DropDownList>

                                <f:DropDownList ID="负责人" Width="230px" runat="server" AutoPostBack="true" Label="负责人" AutoSelectFirstItem="false" LabelWidth="70" EmptyText="全部">
                                </f:DropDownList>

                                <f:DropDownList ID="存放地点" Required="true" Width="230px" runat="server" AutoSelectFirstItem="false" EmptyText="全部" Label="存放地点" LabelWidth="80" AutoPostBack="true">
                                </f:DropDownList>

                                <f:DropDownList ID="房间" Width="230px" runat="server" EmptyText="全部" AutoSelectFirstItem="false" Label="房间" LabelWidth="60" AutoPostBack="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="8% 18% 18% 18% 18% 18%">
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

                                <f:Button ID="Button2" Text="确认查询" IconUrl="../res/icon/application_form_magnify.png" Width="150px" runat="server" />

                                <f:Button ID="Button5" Text="确认添加" IconUrl="../res/icon/application_form_magnify.png" Width="150px" OnClick="Button5_Click" runat="server" />

                            </Items>
                        </f:FormRow>



                    </Rows>

                </f:Form>

                <f:Grid ID="Grid3" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="true"
                    ShowHeader="true" runat="server" DataKeyNames="ID" EnableCheckBoxSelect="true" Height="400px" KeepCurrentSelection="true" ShowPagingMessage="false" OnPageIndexChange="Grid3_PageIndexChange">

                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                        <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量" />
                        <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" />
                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="原存放地点" />
                        <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="原归属部门" />
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="原负责人" />
                        <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>
                    </Columns>
                </f:Grid>


            </Items>
        </f:Window>
    </form>
    <script type="text/javascript">

        var gridClientID = '<%= Grid2.ClientID %>';

        function calculateHejiValue(rowValue) {
            var total = 0;

            function addColumnValue(columnName) {
                var columnValue = rowValue[columnName];
                if (typeof (columnValue) === 'number') {
                    total += columnValue;
                }
            }

            addColumnValue('变动金额');
            return total;
        }

        // 渲染合计列
        function renderHeji(value, params) {
            return calculateHejiValue(params.rowValue);
        }

        function onGridAfterEdit(event, value, params) {
            this.updateCellValue(params.rowId, 'Heji', calculateHejiValue(params.rowValue));
        }
    </script>
</body>
</html>
