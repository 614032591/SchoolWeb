<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="购置验收首页.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.购置验收.购置验收首页" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="sourcefiless" content="School购置验收流程进度.aspx" />
    <title></title>
    <style type="text/css">


        .f-grid-colheader {
            font-weight: bold;
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
                                <f:DropDownList ID="DropDownList1" ShowLabel="false" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server">
                                    <f:ListItem Text="流程状态-全部" Value="filter1" />
                                    <f:ListItem Text="流程状态-待审核" Value="filter2" />
                                    <f:ListItem Text="流程状态-已完成" Value="filter3" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="span" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID,流程状态,单据编号,事项名称,备注信息,数量合计,金额合计,申请人,制单日期,供应商,供应商联系方式,合同编号,发票号,验收人,记账人,取得方式,购置日期,验收日期" EnableCheckBoxSelect="false" OnRowCommand="Grid1_RowCommand">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server">
                            <Items>

                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="btnCheckSelection" Text="创建购置验收" IconUrl="../res/icon/application_add.png" runat="server" OnClick="btnCheckSelection_Click">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                        <%--单据编号--%>
                        <f:RenderField ColumnID="单据编号" DataField="单据编号" HeaderText="单据编号"></f:RenderField>
                        <f:RenderField ColumnID="事项名称" DataField="事项名称" HeaderText="事项名称"></f:RenderField>
                        <f:RenderField ColumnID="备注信息" DataField="备注信息" HeaderText="备注信息"></f:RenderField>
                        <f:RenderField ColumnID="数量合计" DataField="数量合计" HeaderText="数量合计" />
                        <f:RenderField ColumnID="金额合计" DataField="金额合计" HeaderText="金额合计" />
                        <f:RenderField ColumnID="申请人" DataField="申请人" HeaderText="申请人" />
                        <f:RenderField ColumnID="制单日期" DataField="制单日期" HeaderText="制单日期" ExpandUnusedSpace="true" />
                        <f:RenderField ColumnID="Sort" DataField="Sort" HeaderText="Sort" Hidden="True" />
                        <f:LinkButtonField CommandName="Action1" Text="查看详情" Icon="ApplicationGo" />
                        <f:TemplateField HeaderText="新标签页打开" Width="100px">
                            <ItemTemplate>
                                <a href="javascript:;" onclick="<%# GetEditUrls(Eval("事项名称"), Eval("Sort")) %>">流程进度</a>
                            </ItemTemplate>
                        </f:TemplateField>

                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <br />
        <br />





        <f:Window ID="Window1" Title="添加资产" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1100">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="hfFormID" runat="server"></f:HiddenField>
                        <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                            <Tabs>
                                <f:Tab Title="<span class='highlight'>添加资产</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    <Items>


                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                            <br />
                                            <f:TextBox ID="流程状态" Label="流程状态" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="事项名称" Label="事项名称" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="单据编号" Label="单据编号" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <Items>

                                                <f:DropDownList ID="取得方式" Label="取得方式" Width="250px" LabelWidth="90" runat="server">
                                                </f:DropDownList>
                                            </Items>
                                            <br />

                                            <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="制单日期" EmptyText="请选择日期"
                                                ID="制单日期" ShowRedStar="true" Width="250px" LabelWidth="90" Enabled="false">
                                            </f:DatePicker>

                                            <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="购置日期" EmptyText="请选择日期"
                                                ID="购置日期" ShowRedStar="true" Width="250px" LabelWidth="90">
                                            </f:DatePicker>

                                            <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="验收日期" EmptyText="请选择日期"
                                                ID="验收日期" ShowRedStar="true" Width="250px" LabelWidth="90">
                                            </f:DatePicker>

                                        </f:ContentPanel>

                                        <f:Grid ID="Grid2" IsFluid="true" CssClass="span" ShowBorder="true" ShowHeader="true" Title="表格（双击编辑）" EnableCollapse="false"
                                            runat="server" AllowCellEditing="true" ClicksToEdit="2"
                                            DataIDField="ID" EnableCheckBoxSelect="true" Height="300">
                                            <Toolbars>
                                                <f:Toolbar ID="Toolbar3" runat="server">
                                                    <Items>
                                                        <f:Button ID="Button1" Text="新增数据" Icon="Add" EnablePostBack="false" runat="server">
                                                            <Listeners>

                                                                <f:Listener Event="click" Handler="onNewClick" />
                                                            </Listeners>
                                                        </f:Button>
                                                        <f:Button ID="Button2" Text="删除选中行" Icon="Delete" EnablePostBack="false" runat="server">
                                                            <Listeners>
                                                                <f:Listener Event="click" Handler="onDeleteClick" />
                                                            </Listeners>
                                                        </f:Button>
                                                        <f:ToolbarFill runat="server">
                                                        </f:ToolbarFill>
                                                        <f:Button ID="Button3" Text="重置表格数据" EnablePostBack="false" runat="server">
                                                            <Listeners>
                                                                <f:Listener Event="click" Handler="onResetClick" />
                                                            </Listeners>
                                                        </f:Button>
                                                    </Items>
                                                </f:Toolbar>
                                            </Toolbars>
                                            <Columns>
                                                <f:RowNumberField></f:RowNumberField>
                                                <f:RenderField Width="100px" ColumnID="资产编号" DataField="资产编号"
                                                    HeaderText="资产编号">
                                                    <Editor>
                                                        <f:TextBox ID="TextBox1" Required="true" runat="server">
                                                        </f:TextBox>
                                                    </Editor>
                                                </f:RenderField>


                                                <f:RenderField Width="150px" ColumnID="资产分类" DataField="资产分类" HeaderText="资产分类">
                                                    <Editor>
                                                        <f:DropDownList ID="一级" Required="true" AutoPostBack="true" AutoSelectFirstItem="false" runat="server">
                                                        </f:DropDownList>
                                                    </Editor>
                                                </f:RenderField>

                                                <f:RenderField Width="100px" ColumnID="资产名称" DataField="资产名称"
                                                    HeaderText="资产名称">
                                                    <Editor>
                                                        <f:TextBox ID="TextBox2" Required="true" runat="server">
                                                        </f:TextBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField Width="100px" ColumnID="规格型号" DataField="规格型号"
                                                    HeaderText="规格型号">
                                                    <Editor>
                                                        <f:TextBox ID="TextBox13" Required="true" runat="server">
                                                        </f:TextBox>
                                                    </Editor>
                                                </f:RenderField>


                                                <f:RenderField Width="100px" ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向">
                                                    <Editor>
                                                        <f:DropDownList ID="使用方向" AutoPostBack="true" Required="true" runat="server">
                                                            <f:ListItem Text="行政办公" Value="行政办公" />
                                                            <f:ListItem Text="教学" Value="教学" />
                                                            <f:ListItem Text="教研" Value="教研" />
                                                            <f:ListItem Text="生活后勤" Value="生活后勤" />
                                                            <f:ListItem Text="其他" Value="其他" />
                                                        </f:DropDownList>
                                                    </Editor>
                                                </f:RenderField>


                                                <f:RenderField Width="100px" ColumnID="数量" DataField="数量"
                                                    HeaderText="数量">
                                                    <Editor>
                                                        <f:TextBox ID="TextBox14" Required="true" runat="server">
                                                        </f:TextBox>
                                                    </Editor>
                                                </f:RenderField>

                                                <f:RenderField Width="100px" ColumnID="单价" DataField="单价"
                                                    HeaderText="单价">
                                                    <Editor>
                                                        <f:TextBox ID="TextBox15" Required="true" runat="server">
                                                        </f:TextBox>
                                                    </Editor>
                                                </f:RenderField>

                                                <f:RenderField Width="100px" ColumnID="归属部门" DataField="归属部门" HeaderText="归属部门">
                                                    <Editor>
                                                        <f:DropDownList ID="一级部门" Text="" Required="true" AutoPostBack="true" runat="server">
                                                        </f:DropDownList>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField Width="100px" ColumnID="负责人" DataField="负责人" HeaderText="负责人">
                                                    <Editor>
                                                        <f:DropDownList ID="负责人" AutoPostBack="true" Required="true" runat="server">
                                                        </f:DropDownList>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField Width="100px" ColumnID="存放地点" DataField="存放地点" HeaderText="存放地点">
                                                    <Editor>
                                                        <f:DropDownList ID="存放地点" AutoPostBack="true" Required="true" runat="server">
                                                        </f:DropDownList>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField Width="100px" ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态">
                                                    <Editor>
                                                        <f:DropDownList Required="true" runat="server">
                                                            <f:ListItem Text="使用中" Value="使用中" />
                                                        </f:DropDownList>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:LinkButtonField ColumnID="Delete" Width="80px" EnablePostBack="false" Icon="Delete" />
                                            </Columns>
                                        </f:Grid>

                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">

                                            <f:Label ID="labResult" ShowLabel="false" runat="server" CssClass="red"></f:Label>
                                            <br />
                                            <f:TextBox ID="供应商" Label="供应商" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="供应商联系方式" Label="供应商联系方式" Width="250px" runat="server" LabelWidth="130">
                                            </f:TextBox>
                                            <f:TextBox ID="合同编号" Label="合同编号" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="发票号" Label="发票号" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <br />
                                            <f:TextBox ID="备注" Label="备注" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <br />
                                            <f:TextBox ID="申请人" Label="申请人" Width="250px" Enabled="false" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="验收人" Label="验收人" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="记账人" Label="记账人" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                        </f:ContentPanel>


                                    </Items>
                                </f:Tab>

                            </Tabs>
                        </f:TabStrip>
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>

                                <f:Button ID="Button4" runat="server" Text="保存数据" IconUrl="../res/icon/accept.png" OnClick="Button4_Click">
                                </f:Button>

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



        <f:Window ID="处理资产" Title="查看/处理资产信息" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1100">
            <Items>
                <f:SimpleForm ID="SimpleForm2" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="HiddenField1" runat="server"></f:HiddenField>
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
                                            <f:TextBox ID="查看事项名称" Label="事项名称" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看单据编号" Label="单据编号" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看取得方式" Label="取得方式" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <br />

                                            <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="制单日期"
                                                ID="查看制单日期" ShowRedStar="true" Width="250px" LabelWidth="90">
                                            </f:DatePicker>

                                            <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="购置日期"
                                                ID="查看购置日期" ShowRedStar="true" Width="250px" LabelWidth="90">
                                            </f:DatePicker>

                                            <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="验收日期"
                                                ID="查看验收日期" ShowRedStar="true" Width="250px" LabelWidth="90">
                                            </f:DatePicker>

                                        </f:ContentPanel>

                                        <f:Grid ID="Grid3" IsFluid="true" CssClass="span" ShowBorder="true" ShowHeader="true" Title="表格" EnableCollapse="false"
                                            runat="server" AllowCellEditing="true" ClicksToEdit="2"
                                            DataIDField="ID" EnableCheckBoxSelect="true" Height="300">

                                            <Columns>
                                                <f:RowNumberField></f:RowNumberField>
                                                <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                                                <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                                                <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产类型"></f:RenderField>
                                                <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                                                <f:RenderField ColumnID="型号" DataField="型号" HeaderText="资产型号"></f:RenderField>
                                                <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向"></f:RenderField>


                                                <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量"></f:RenderField>
                                                <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格"></f:RenderField>
                                                <f:RenderField ColumnID="归属部门" DataField="归属部门" HeaderText="归属部门"></f:RenderField>
                                                <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人"></f:RenderField>
                                                <f:RenderField ColumnID="存放地点" DataField="存放地点" HeaderText="存放地点"></f:RenderField>
                                                <f:RenderField ColumnID="使用状态" DataField="使用状态" HeaderText="资产状态"></f:RenderField>
                                            </Columns>

                                        </f:Grid>


                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                            <%--     <f:Label ID="Label1" runat="server"  ForeColor="Red"></f:Label>--%>
                                            <f:Label ID="Label1" ShowLabel="false" runat="server" CssClass="red"></f:Label>
                                            <br />
                                            <f:TextBox ID="查看供应商" Label="供应商" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看供应商联系方式" Label="供应商联系方式" Width="250px" runat="server" LabelWidth="130">
                                            </f:TextBox>
                                            <f:TextBox ID="查看合同编号" Label="合同编号" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看发票号" Label="发票号" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <br />
                                            <f:TextBox ID="查看备注" Label="备注" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <br />
                                            <f:TextBox ID="查看申请人" Label="申请人" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看验收人" Label="验收人" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看记账人" Label="记账人" Width="250px" runat="server" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="flowid" Label="flowid" runat="server" Hidden="true">
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
                                <f:Button ID="Button5" runat="server" IconUrl="../res/icon/accept.png" OnClick="Button5_Click">
                                </f:Button>
                                <f:Button ID="Button6" Icon="SystemClose" Text="关闭" runat="server" OnClick="Button6_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>



    </form>
    <script>






        var windowClientID = '<%= Window1.ClientID %>';
        var gridClientID = '<%= Grid1.ClientID %>';
        var gridClientIDtwo = '<%= Grid2.ClientID %>';
        var formClientID = '<%= SimpleForm1.ClientID %>';
        var hfFormIDClientID = '<%= hfFormID.ClientID %>';

        function onNewButtonClick(event) {
            // 重置表单字段
            F(formClientID).reset();

            // 弹出窗体
            F(windowClientID).show();
            F(windowClientID).setTitle('新增数据');
        }

        function onEditButtonClick(event) {
            showEditWindow();
        }


        var grid1ClientID = '<%= Grid2.ClientID %>';

        function onNewClick(event) {
            F(grid1ClientID).addNewRecord({
                '资产编号': '',
                //'Gender': 1,
                //'EntranceYear': '2015',
                //'EntranceDate': '2015-09-01',
                //'AtSchool': false,
                //'Major': '化学系',
                'Delete': '<a href="javascript:;"><img src="../res/icon/delete.png"/></a>'
            }, false);
        }

        function onDeleteClick(event) {
            var grid = F(grid1ClientID);

            // 如果没有选中项，弹出提示信息
            if (!grid.hasSelection()) {
                F.alert('请至少选择一项！');
                return;
            }

            // 删除选中行之前先弹出确认对话框
            F.confirm({
                message: '删除选中行？',
                ok: function () {
                    // 删除选中行
                    grid.deleteSelectedRows();
                }
            });
        }


        function onResetClick(event) {
            F.confirm({
                message: '确定要重置表格数据？',
                ok: function () {
                    F(gridClientIDtwo).rejectChanges();
                }
            });
        }


        F.ready(function () {

            var grid = F(grid1ClientID);
            // 注册点击行中删除图片的事件处理函数
            grid.el.on('click', '.f-grid-cell-Delete a', function (event) {
                // 删除选中行之前先弹出确认对话框
                F.confirm({
                    message: '删除选中行？',
                    ok: function () {
                        // 删除选中行
                        grid.deleteSelectedRows();
                    }
                });
            });

        });

    </script>
</body>
</html>
