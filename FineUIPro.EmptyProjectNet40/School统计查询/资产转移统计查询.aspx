<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="资产转移统计查询.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.统计查询.资产转移统计查询" %>

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
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <f:Panel ID="Panel7" runat="server" BodyPadding="10px"
            Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Form ID="Form5" ShowBorder="False" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow Hidden="false" ID="frHidden">
                            <Items>
                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="ttbSearch"
                                    ShowTrigger1="false"
                                    Trigger1Icon="Clear" Trigger2Icon="Search">
                                </f:TwinTriggerBox>
                                <f:DropDownList ID="DropDownList1" ShowLabel="false"
                                    runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    <f:ListItem Text="流程状态-全部" Value="filter1" />
                                    <f:ListItem Text="流程状态-待审核" Value="filter2" />
                                    <f:ListItem Text="流程状态-已完成" Value="filter3" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>

                        <%-- 二级菜单 --%>
                        <f:FormRow ID="fr1" ColumnWidths="8% 20% 20% 20%" Hidden="true">
                            <Items>
                                <f:Label ID="Label2" runat="server" Label="资产分类"  Width="100"  LabelWidth="140"></f:Label>

                                <f:DropDownList ID="一级" Width="250px" runat="server" Label="一级" LabelWidth="60" AutoPostBack="true" AutoSelectFirstItem="false" EmptyText="全部" OnSelectedIndexChanged="一级_SelectedIndexChanged">
                                </f:DropDownList>

                                <f:DropDownList ID="二级" Width="250px" runat="server" EmptyText="全部" Label="二级" AutoSelectFirstItem="false" LabelWidth="60" AutoPostBack="true" OnSelectedIndexChanged="二级_SelectedIndexChanged">
                                </f:DropDownList>

                                <f:DropDownList ID="三级" Width="250px" runat="server" EmptyText="全部" Label="三级" AutoSelectFirstItem="false" LabelWidth="60" AutoPostBack="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="fr2" ColumnWidths="8% 20% 20% 20%" Hidden="true">
                            <Items>
                                 <f:Label ID="Label1" runat="server" Label="归属信息" LabelWidth="140"  Width="100"></f:Label>
                                    <f:DropDownList ID="部门" AutoPostBack="true" Width="230px" runat="server" Label="部门" AutoSelectFirstItem="false" LabelWidth="60" EmptyText="全部" OnSelectedIndexChanged="部门_SelectedIndexChanged">
                                    </f:DropDownList>
                                    
                                    <f:DropDownList ID="负责人" Width="250px" runat="server" AutoPostBack="true" Label="负责人"  AutoSelectFirstItem="false" LabelWidth="60" EmptyText="全部">
                                    </f:DropDownList>
                                    
                                    
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="fr4" ColumnWidths="8% 20% 20% 20%" Hidden="true">
                            <Items>
                                <f:Label ID="Label4" runat="server" Label="存放地点" LabelWidth="140"  Width="100"></f:Label>
                                <f:DropDownList ID="存放地点" Required="true" Width= "230px" runat="server" AutoSelectFirstItem="false" EmptyText="全部" Label="地点" LabelWidth="60" AutoPostBack="true"  OnSelectedIndexChanged="存放地点_SelectedIndexChanged">
                                </f:DropDownList>
                                  
                                <f:DropDownList ID="房间" Width="230px" runat="server" EmptyText="全部" AutoSelectFirstItem="false" Label="房间" LabelWidth="60" AutoPostBack="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ID="fr3" ColumnWidths="8% 25% 25% 25% " Hidden="true">
                            <Items>
                                <f:Label ID="Label3" runat="server" Label="投入时间" LabelWidth="140" Width="100"></f:Label>
                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" 
                                    ID="起始投入日期" ShowRedStar="true" Width="300px"  EmptyText="请输入起始日期">
                                </f:DatePicker>

                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" 
                                    ID="结束投入日期" ShowRedStar="true" Width="300px"  EmptyText="请输入截止日期">
                                </f:DatePicker>

                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="TwinTriggerBox1"
                                    ShowTrigger1="false"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" Width="250px">
                                </f:TwinTriggerBox>

                                <f:Button ID="Button5" Text="确认查询"  IconUrl="../res/icon/application_form_magnify.png" runat="server" OnClick="Button5_Click" />

                            </Items>
                        </f:FormRow>




                        <f:FormRow ColumnWidths="8% 25% 25% 25% ">
                            <Items>
                                <%--<f:CheckBox ID="CheckBox2" ShowLabel="false" runat="server" Text="事项表/明细表(默认事项表，单击切换)"
                                    Checked="true" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged">
                                </f:CheckBox>--%>
                                <f:RadioButtonList AutoPostBack="true" ID="Radios" OnSelectedIndexChanged="Radios_SelectedIndexChanged" runat="server">
                                    <f:RadioItem Text="事项表" Selected="true" Value="事项表"/>
                                    <f:RadioItem Text="明细表" Value="明细表"/>
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID,流程状态,单据编号,事项名称,申请人,申请日期,联系方式" EnableCheckBoxSelect="true" OnRowCommand="Grid1_RowCommand">

                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                        <f:RenderField ColumnID="单据编号" DataField="单据编号" HeaderText="单据编号"></f:RenderField>
                        <f:RenderField ColumnID="事项名称" DataField="事项名称" HeaderText="事项名称"></f:RenderField>
                        <f:RenderField ColumnID="备注信息" DataField="备注信息" HeaderText="备注信息"></f:RenderField>
                        <f:RenderField ColumnID="总数" DataField="总数" HeaderText="总数" />
                        <f:RenderField ColumnID="总价" DataField="总价" HeaderText="总价" />
                        <f:RenderField ColumnID="申请人" DataField="申请人" HeaderText="申请人" />
                        <f:RenderField ColumnID="申请日期" DataField="申请日期" HeaderText="申请日期" />
                        <f:RenderField ColumnID="联系方式" DataField="联系方式" HeaderText="联系方式" ExpandUnusedSpace="true" />
                        <f:TemplateField HeaderText="新标签页打开" Width="100px">
                            <ItemTemplate>
                                <a href="javascript:;" onclick="<%# GetEditUrls(Eval("单据编号"), Eval("Sort")) %>">流程进度</a>
                            </ItemTemplate>
                        </f:TemplateField>
                    </Columns>
                </f:Grid>
                    <%-- 明细表 --%>
                 <f:Grid ID="Grid2" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID" EnableCheckBoxSelect="true" KeepCurrentSelection="true" >
                    <Columns>
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
           
                 <%--<f:Grid ID="Grid3" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID" EnableCheckBoxSelect="true" KeepCurrentSelection="true" OnRowCommand="Grid1_RowCommand" OnPageIndexChange="Grid1_PageIndexChange">
                    <Columns>
                        
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
                </f:Grid>--%>



            </Items>
        </f:Panel>



        <br />
        <br />
        <br />



        <%-- 查看详情 --%>
        <f:Window ID="新增资产转移查看详情" Title="新增资产转移（查看详情）" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1100">
            <Items>
                <f:SimpleForm ID="SimpleForm3" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="HiddenField2" runat="server"></f:HiddenField>
                        <f:TabStrip ID="TabStrip2" IsFluid="true" CssClass="blockpanel" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                            <Tabs>
                                <f:Tab Title="<span class='highlight'>资产信息</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    <Items>


                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                            <br />
                                            <f:TextBox ID="查看流程状态" Label="流程状态" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看单据编号" Label="单据编号" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看事项名称" Label="事项名称" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>

                                            <br />
                                            <f:TextBox ID="查看申请人" Label="申请人" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="申请日期"
                                                ID="查看申请日期" ShowRedStar="true" Width="250px" LabelWidth="90">
                                            </f:DatePicker>

                                            <f:TextBox ID="查看联系方式" Label="联系方式" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:Label ID="xx" Text="" runat="server" Hidden="true"></f:Label>
                                        </f:ContentPanel>

                                        <f:Grid ID="Grid4" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true" Title="表格" EnableCollapse="false"
                                            runat="server" AllowCellEditing="true" ClicksToEdit="2"
                                            Height="300">

                                            <Columns>
                                                <f:RowNumberField></f:RowNumberField>

                                                <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                                                <f:RenderField ColumnID="一级类别名称" DataField="一级类别名称" HeaderText="资产类型"></f:RenderField>
                                                <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                                                <f:RenderField ColumnID="型号" DataField="型号" HeaderText="资产型号"></f:RenderField>
                                                <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                                                <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量"></f:RenderField>
                                                <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格"></f:RenderField>
                                                <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>
                                                <f:RenderField ColumnID="原存放地点" DataField="原存放地点" HeaderText="原存放地点"></f:RenderField>
                                                <f:RenderField ColumnID="原归属部门" DataField="原归属部门" HeaderText="原归属部门"></f:RenderField>
                                                <f:RenderField ColumnID="原负责人" DataField="原负责人" HeaderText="原负责人"></f:RenderField>

                                            </Columns>

                                        </f:Grid>


                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                            <%--     <f:Label ID="Label1" ShowLabel="false" runat="server" CssClass="red"></f:Label>--%>
                                            <br />
                                            <f:TextBox ID="查看存放地点变更为" Label="存放地点变更为" Width="300px" runat="server" LabelWidth="130">
                                            </f:TextBox>
                                            <f:TextBox ID="查看归属部门变更为" Label="归属部门变更为" Width="300px" runat="server" LabelWidth="130">
                                            </f:TextBox>
                                            <f:TextBox ID="查看负责人变更为" Label="负责人变更为" Width="300px" runat="server" LabelWidth="130">
                                            </f:TextBox>
                                        </f:ContentPanel>


                                    </Items>
                                </f:Tab>

                            </Tabs>
                        </f:TabStrip>


                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar5" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>

                                <f:Button ID="Button9" IconUrl="../res/icon/accept.png" runat="server" Text="同意" ConfirmText="是否审核通过？">
                                </f:Button>
                                <f:Button ID="Button3" IconUrl="../res/icon/cross.png" runat="server" Text="拒绝"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>






    </form>
    <%--    <script>
        var windowClientID = '<%= Window1.ClientID %>';
        var gridClientID = '<%= Grid1.ClientID %>';
        var formClientID = '<%= SimpleForm1.ClientID %>';
        var hfFormIDClientID = '<%= hfFormID.ClientID %>';



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
    </script>--%>
</body>
</html>
