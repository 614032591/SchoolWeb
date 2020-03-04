<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="清查盘点.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.清查盘点.清查盘点" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <style type="text/css">
        .mypanel {
            display: inline-block;
            margin-right: 5px;
        }
         
        span{
            font-weight:bold;
        }
       
   

    </style>
    <%--<meta name="sourcefiles" content="~/grid/grid_iframe_window.aspx" />--%>
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
                                    runat="server">
                                    <f:ListItem Text="过滤条件一" Value="filter1" />
                                    <f:ListItem Text="过滤条件二" Value="filter2" />
                                    <f:ListItem Text="过滤条件三" Value="filter3" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="true"
                    ShowHeader="true" runat="server" DataKeyNames="ID,完成状态,盘点单号,名称,盘点方式,清查范围,发布方,起始时间,截止时间,描述" EnableCheckBoxSelect="true" OnRowCommand="Grid1_RowCommand">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>

                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="btnCheckSelection" Text="新建盘点任务" runat="server">
                                    <Listeners>
                                        <f:Listener Event="click" Handler="onEditButtonClick" />
                                    </Listeners>
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="完成状态" DataField="完成状态" HeaderText="状态"></f:RenderField>
                        <f:RenderField ColumnID="盘点单号" DataField="盘点单号" HeaderText="盘点单号"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="项目名称"></f:RenderField>
                        <f:RenderField ColumnID="起始时间" DataField="起始时间" HeaderText="起始时间" />
                        <f:RenderField ColumnID="截止时间" DataField="截止时间" HeaderText="截止时间" />
                        <f:RenderField ColumnID="盘点方式" DataField="盘点方式" HeaderText="盘点方式"></f:RenderField>
                        <f:RenderField ColumnID="清查范围" DataField="清查范围" HeaderText="清查范围" />
                        <f:RenderField ColumnID="发布方" DataField="发布方" HeaderText="发布方" />                       
                        <f:RenderField ColumnID="描述" DataField="描述" HeaderText="描述" ExpandUnusedSpace="true" />
                        <f:LinkButtonField Width="160" CommandName="Action1" Text="查看详情" Icon="ApplicationGo" />
                        <%--<f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" />
                        <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量" />
                        <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向" />--%>
                        <%-- <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="部门名称" ExpandUnusedSpace="true" />--%>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>

        <f:Window ID="Window1" Title="新建盘点任务" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1100px">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="hfFormID" runat="server"></f:HiddenField>
                        <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" Height="400px" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                            <Tabs>
                                <f:Tab Title="<span class='highlight'>创建盘点</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    <Items>
                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                            <br />
                                            <f:TextBox runat="server" Label="项目名称" ID="项目名称" Width="250px" LabelWidth="90"></f:TextBox>
                                            <f:TextBox runat="server" Label="单号" ID="单号" Width="250px" LabelWidth="90"></f:TextBox>
                                            <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="开始时间" EmptyText="请选择日期"
                                                ID="DatePicker1" ShowRedStar="true" Width="250px" LabelWidth="90">
                                            </f:DatePicker>
                                            <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="截止时间" EmptyText="请选择日期"
                                                ID="DatePicker2" ShowRedStar="true" Width="250px" LabelWidth="90">
                                            </f:DatePicker>

                                            <f:RadioButton ID="rbtnFirst" Label="盘点范围" Checked="true" GroupName="MyRadioGroup1" Text="全部(默认)" runat="server" Width="200px" LabelWidth="90" OnCheckedChanged="rbtnFirst_CheckedChanged" AutoPostBack="true">
                                            </f:RadioButton>
                                            <f:RadioButton ID="rbtnSecond" GroupName="MyRadioGroup1" Text="自定义" runat="server" Width="200px" OnCheckedChanged="rbtnFirst_CheckedChanged" AutoPostBack="true">
                                            </f:RadioButton>
                                            <br />
                                            <f:TriggerBox ID="tbxMyBox1" Label="存放地点" Readonly="false" TriggerIcon="Search"
                                                OnTriggerClick="tbxMyBox1_TriggerClick" EmptyText="请添加存放地点" runat="server" EnableClickAction="true" Width="250px" LabelWidth="90">
                                            </f:TriggerBox>
                                            <f:TriggerBox ID="TriggerBox1" Label="归属部门" Readonly="false" TriggerIcon="Search"
                                                EmptyText="请添加归属部门" runat="server" EnableClickAction="true" Width="250px" LabelWidth="90" OnTriggerClick="TriggerBox1_TriggerClick">
                                            </f:TriggerBox>
                                            <f:TriggerBox ID="TriggerBox2" Label="负责人" Readonly="false" TriggerIcon="Search"
                                                EmptyText="请添加负责人" runat="server" EnableClickAction="true" Width="250px" LabelWidth="90" OnTriggerClick="TriggerBox2_TriggerClick1">
                                            </f:TriggerBox>
                                            <f:TriggerBox ID="TriggerBox3" Label="资产分类" Readonly="false" TriggerIcon="Search"
                                                OnTriggerClick="tbxMyBox1_TriggerClick" EmptyText="请添加资产分类" runat="server" EnableClickAction="true" Width="250px" LabelWidth="90">
                                            </f:TriggerBox>
                                            <br />




                                            <f:RadioButton ID="RadioButton1" Label="盘点方式" Checked="true" GroupName="MyRadioGroup2" Text="按负责人" runat="server" Width="200px" LabelWidth="90" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="true">
                                            </f:RadioButton>
                                            <f:RadioButton ID="RadioButton2" GroupName="MyRadioGroup2" Text="按指定人员" ShowEmptyLabel="true" runat="server" Width="200px" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="true">
                                            </f:RadioButton>
                                            <f:RadioButton ID="RadioButton3" GroupName="MyRadioGroup2" Text="按服务机构" ShowEmptyLabel="true" runat="server" Width="200px" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="true">
                                            </f:RadioButton>
                                            <br />
                                            <f:TriggerBox ID="TriggerBox4" Label="添加人员" Readonly="false" TriggerIcon="Search"
                                                EmptyText="添加指定盘点人员" runat="server" EnableClickAction="true" Width="250px" LabelWidth="90" OnTriggerClick="TriggerBox4_TriggerClick">
                                            </f:TriggerBox>

                                            <f:DropDownList ID="drop" Label="任务分配" Required="true" Width="250px" LabelWidth="90" runat="server">
                                                <f:ListItem Text="教学设备" Value="教学设备" />
                                                <f:ListItem Text="实验设备" Value="教学设备" />
                                                <f:ListItem Text="科研设备" Value="教学设备" />
                                                <f:ListItem Text="办公设备" Value="教学设备" />
                                            </f:DropDownList>
                                            <%--<br />--%>
                                            <f:LinkButton ID="LinkButton2" Text="任务分配" EnablePostBack="false" runat="server" Hidden="true">
                                            </f:LinkButton>
                                            <br />
                                            <f:TextBox runat="server" Label="备注信息" ID="TextBox1" LabelWidth="90"></f:TextBox>
                                            <br />
                                            <f:FileUpload runat="server" ID="filePhoto" EmptyText="请选择文件" Label="附件上传" ButtonIcon="Add"
                                                ShowRedStar="true" LabelWidth="90">
                                            </f:FileUpload>
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
                                <f:Button ID="Button1" Icon="ApplicationGo" runat="server" Text="提交" OnClick="Button1_Click"></f:Button>
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

        <f:Window ID="Window2" Title="弹出窗口" BodyPadding="10px" IsModal="true" Hidden="true"
            Target="Top" Width="700px" Height="700px"
            runat="server">



            <Items>
                <f:Panel ID="Panel6" IsFluid="true" CssClass="blockpanel" runat="server" ShowBorder="true" EnableCollapse="false"
                    BodyPadding="10px" ShowHeader="false" Title="面板" AutoScroll="true" Margin="20px" Height="650px" Width="700px">
                    <Items>
                        <f:Panel ID="Panel8" Title="面板1" CssClass="mypanel" Width="200px" Height="540px" runat="server"
                            BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Tree ID="Tree1" IsFluid="true" CssClass="blockpanel" ShowHeader="true" EnableCollapse="false"
                                    Title="树控件" runat="server" OnNodeCommand="Tree1_NodeCommand" Height="540px">
                                    <Nodes>
                                        <f:TreeNode Text="全部" Expanded="true">
                                            <f:TreeNode Text="1号楼" EnableClickEvent="true" NodeID="1"></f:TreeNode>
                                            <f:TreeNode Text="2号楼" EnableClickEvent="true" NodeID="2"></f:TreeNode>
                                            <f:TreeNode Text="健身房" EnableClickEvent="true" NodeID="3"></f:TreeNode>
                                            <f:TreeNode Text="礼堂" EnableClickEvent="true" NodeID="4"></f:TreeNode>
                                            <f:TreeNode Text="梅香楼" EnableClickEvent="true" NodeID="5"></f:TreeNode>
                                            <f:TreeNode Text="解放楼555" EnableClickEvent="true" NodeID="6"></f:TreeNode>
                                            <f:TreeNode Text="配电室" EnableClickEvent="true" NodeID="7"></f:TreeNode>
                                            <f:TreeNode Text="沁心楼" EnableClickEvent="true" NodeID="8"></f:TreeNode>
                                            <f:TreeNode Text="信息大楼" EnableClickEvent="true" NodeID="9"></f:TreeNode>
                                            <f:TreeNode Text="图书馆" EnableClickEvent="true" NodeID="10"></f:TreeNode>
                                            <f:TreeNode Text="新华楼" EnableClickEvent="true" NodeID="11"></f:TreeNode>
                                            <f:TreeNode Text="育翠楼" EnableClickEvent="true" NodeID="12"></f:TreeNode>
                                            <f:TreeNode Text="钟书楼" EnableClickEvent="true" NodeID="13"></f:TreeNode>
                                        </f:TreeNode>
                                    </Nodes>


                                </f:Tree>
                            </Items>

                        </f:Panel>

                        <f:Panel ID="Panel9" Title="面板2" CssClass="mypanel" Width="400px" Height="540px" runat="server"
                            BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Grid ID="Grid6" Title="数据表格" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true"
                                    runat="server" DataKeyNames="ID,名称" EnableCheckBoxSelect="true" KeepCurrentSelection="true" Height="540px">

                                    <Columns>
                                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                        <f:RowNumberField />
                                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                                        <f:RenderField ColumnID="房间号" DataField="房间号" HeaderText="房间号"></f:RenderField>
                                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="房间名称" ExpandUnusedSpace="true">
                                        </f:RenderField>



                                    </Columns>
                                </f:Grid>
                            </Items>

                        </f:Panel>


                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar4" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="Button8" Icon="ApplicationGo" runat="server" Text="确定" OnClick="Button8_Click"></f:Button>
                                <f:Button ID="Button9" Icon="SystemClose" runat="server" Text="取消"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:Panel>




            </Items>
        </f:Window>



        <f:Window ID="Window4" Title="选择角色" BodyPadding="10px" IsModal="true" Hidden="true"
            Target="Top" Width="700px" Height="700px"
            runat="server">



            <Items>
                <f:Panel ID="Panel10" IsFluid="true" CssClass="blockpanel" runat="server" ShowBorder="true" EnableCollapse="false"
                    BodyPadding="10px" ShowHeader="false" Title="面板" AutoScroll="true" Margin="20px" Height="650px" Width="700px">
                    <Items>
                        <f:Panel ID="Panel11" Title="面板1" CssClass="mypanel" Width="200px" Height="540px" runat="server"
                            BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Tree ID="Tree2" IsFluid="true" CssClass="blockpanel" ShowHeader="true" EnableCollapse="false"
                                    Title="树控件" runat="server" Width="200px" Height="540px" OnNodeCommand="Tree2_NodeCommand">
                                    <Nodes>
                                        <f:TreeNode Text="全部" Expanded="true">
                                            <f:TreeNode Text="办公室11" EnableClickEvent="true" NodeID="1"></f:TreeNode>
                                            <f:TreeNode Text="仓库" EnableClickEvent="true" NodeID="2"></f:TreeNode>
                                            <f:TreeNode Text="地理组" EnableClickEvent="true" NodeID="3"></f:TreeNode>
                                            <f:TreeNode Text="工会" EnableClickEvent="true" NodeID="4"></f:TreeNode>
                                            <f:TreeNode Text="化学组" EnableClickEvent="true" NodeID="5"></f:TreeNode>
                                            <f:TreeNode Text="交流人员" EnableClickEvent="true" NodeID="6"></f:TreeNode>
                                            <f:TreeNode Text="教科处" EnableClickEvent="true" NodeID="7"></f:TreeNode>
                                            <f:TreeNode Text="教务室" EnableClickEvent="true" NodeID="8"></f:TreeNode>
                                            <f:TreeNode Text="历史组" EnableClickEvent="true" NodeID="9"></f:TreeNode>
                                            <f:TreeNode Text="生物组" EnableClickEvent="true" NodeID="10"></f:TreeNode>
                                            <f:TreeNode Text="食堂" EnableClickEvent="true" NodeID="11"></f:TreeNode>
                                            <f:TreeNode Text="数学组" EnableClickEvent="true" NodeID="15"></f:TreeNode>
                                            <f:TreeNode Text="体卫艺教处" EnableClickEvent="true" NodeID="16"></f:TreeNode>
                                            <f:TreeNode Text="体育组" EnableClickEvent="true" NodeID="17"></f:TreeNode>
                                            <f:TreeNode Text="图书馆" EnableClickEvent="true" NodeID="18"></f:TreeNode>
                                            <f:TreeNode Text="文印室" EnableClickEvent="true" NodeID="19"></f:TreeNode>
                                            <f:TreeNode Text="物理组" EnableClickEvent="true" NodeID="20"></f:TreeNode>
                                            <f:TreeNode Text="物业管理" EnableClickEvent="true" NodeID="21"></f:TreeNode>
                                            <f:TreeNode Text="校工" EnableClickEvent="true" NodeID="22"></f:TreeNode>
                                            <f:TreeNode Text="信息技术组" EnableClickEvent="true" NodeID="24"></f:TreeNode>
                                            <f:TreeNode Text="学生处团委" EnableClickEvent="true" NodeID="25"></f:TreeNode>

                                            <f:TreeNode Text="医务室" EnableClickEvent="true" NodeID="26"></f:TreeNode>
                                            <f:TreeNode Text="音美劳组" EnableClickEvent="true" NodeID="27"></f:TreeNode>
                                            <f:TreeNode Text="英语组" EnableClickEvent="true" NodeID="28"></f:TreeNode>
                                            <f:TreeNode Text="语文组" EnableClickEvent="true" NodeID="29"></f:TreeNode>
                                            <f:TreeNode Text="政治组" EnableClickEvent="true" NodeID="30"></f:TreeNode>
                                            <f:TreeNode Text="总务处" EnableClickEvent="true" NodeID="32"></f:TreeNode>
                                            <f:TreeNode Text="财会室" EnableClickEvent="true" NodeID="33"></f:TreeNode>
                                            <f:TreeNode Text="学术委员会" EnableClickEvent="true" NodeID="34"></f:TreeNode>
                                            <f:TreeNode Text="报告厅设备间" EnableClickEvent="true" NodeID="35"></f:TreeNode>
                                            <f:TreeNode Text="报告厅设备间" EnableClickEvent="true" NodeID="36"></f:TreeNode>
                                        </f:TreeNode>
                                    </Nodes>


                                </f:Tree>
                            </Items>

                        </f:Panel>

                        <f:Panel ID="Panel12" Title="面板2" CssClass="mypanel" Width="410px" Height="540px" runat="server"
                            BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Grid ID="Grid7" Title="数据表格" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true"
                                    runat="server" DataKeyNames="ID,姓名" EnableCheckBoxSelect="true" KeepCurrentSelection="true" Height="540px">

                                    <Columns>
                                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                        <f:RowNumberField />
                                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                                        <f:RenderField ColumnID="姓名" DataField="姓名" HeaderText="用户姓名"></f:RenderField>
                                        <f:RenderField ColumnID="学校名称" DataField="学校名称" HeaderText="学校名称"></f:RenderField>
                                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="所在部门" ExpandUnusedSpace="true">
                                        </f:RenderField>



                                    </Columns>
                                </f:Grid>
                            </Items>

                        </f:Panel>


                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar5" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="Button7" Icon="ApplicationGo" runat="server" Text="确定" OnClick="Button7_Click"></f:Button>
                                <f:Button ID="Button10" Icon="SystemClose" runat="server" Text="取消"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:Panel>




            </Items>
        </f:Window>



        <f:Window ID="Window5" Title="选择部门" BodyPadding="10px" IsModal="true" Hidden="true"
            Target="Top" Width="350px" Height="700px"
            runat="server">
            <Items>
                <f:Grid ID="Grid8" Title="数据表格" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true"
                    runat="server" DataKeyNames="ID,名称" EnableCheckBoxSelect="true" KeepCurrentSelection="true" Height="540px">

                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <%-- <f:RenderField ColumnID="房间号" DataField="房间号" HeaderText="房间号"></f:RenderField>--%>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="部门名称" ExpandUnusedSpace="true">
                        </f:RenderField>



                    </Columns>
                </f:Grid>
                <f:Toolbar ID="Toolbar6" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="Button11" Icon="ApplicationGo" runat="server" Text="确定" OnClick="Button11_Click"></f:Button>
                        <f:Button ID="Button12" Icon="SystemClose" runat="server" Text="取消"></f:Button>
                    </Items>
                </f:Toolbar>
            </Items>
        </f:Window>



        <f:Window ID="Window3" Title="清查盘点-盘点进度" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" AutoScroll="true" BodyPadding="10px" Width="1100px" Maximized="true">
            <Items>
                <f:SimpleForm ID="SimpleForm2" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="HiddenField1" runat="server"></f:HiddenField>
                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                            <br />
                            <f:TextBox runat="server" Label="项目名称" ID="盘点进度项目名称" Width="250px" LabelWidth="90"></f:TextBox>
                            <f:TextBox runat="server" Label="单号" ID="盘点进度单号" Width="250px" LabelWidth="90"></f:TextBox>
                            <f:TextBox runat="server" Label="状态" ID="盘点进度状态" Width="250px" LabelWidth="90"></f:TextBox>
                            <f:TextBox runat="server" Label="计划时间" ID="盘点进度计划时间" Width="250px" LabelWidth="90"></f:TextBox>
                            <br />
                            <f:TextBox runat="server" Label="盘点方式" ID="盘点进度盘点方式" Width="250px" LabelWidth="90"></f:TextBox>
                            <f:TextBox runat="server" Label="盘点范围" ID="盘点进度盘点范围" Width="250px" LabelWidth="90"></f:TextBox>
                            <f:TextBox runat="server" Label="发布日期" ID="盘点进度发布日期" Width="250px" LabelWidth="90"></f:TextBox>
                            <f:TextBox runat="server" Label="发布方" ID="盘点进度发布方" Width="250px" LabelWidth="90"></f:TextBox>
                            <br />
                            <f:TextBox runat="server" Label="备注" ID="盘点进度备注" Width="500px" LabelWidth="90"></f:TextBox>
                        </f:ContentPanel>
                        <f:TabStrip ID="TabStrip2" IsFluid="true" CssClass="blockpanel" Height="550px" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server" AutoPostBack="true" OnTabIndexChanged="TabStrip2_TabIndexChanged">

                            <Tabs>

                                <f:Tab Title="<span class='highlight'>盘点进度</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    <Items>
                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                            <br />


                                            <f:Grid ID="Grid2" Title="数据表格" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true"
                                                runat="server" DataKeyNames="ID" EnableCheckBoxSelect="true" Height="400px" OnRowCommand="Grid2_RowCommand">

                                                <Columns>
                                                    <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                                    <f:RowNumberField />
                                                    <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID"></f:RenderField>
                                                    <f:RenderField ColumnID="名称" DataField="名称" HeaderText="单位/部门/人"></f:RenderField>
                                                    <f:RenderField ColumnID="百分比" DataField="百分比" HeaderText="完成进度">
                                                        <%-- 找个JQ进度条控件 嵌套里 暂时先放这有时间完善下--%>
                                                    </f:RenderField>

                                                    <f:RenderField ColumnID="管理数量" DataField="管理数量" HeaderText="资产数量"></f:RenderField>
                                                    <f:RenderField ColumnID="已经盘点" DataField="已经盘点" HeaderText="已盘点"></f:RenderField>
                                                    <f:RenderField ColumnID="盘点结束" DataField="盘点结束" HeaderText="完成状态" />
                                                    <f:LinkButtonField Width="160" CommandName="Action1" Text="查看详情" Icon="ApplicationGo" />

                                                </Columns>
                                            </f:Grid>

                                            <br />

                                        </f:ContentPanel>
                                    </Items>
                                </f:Tab>

                                <f:Tab Title="拍照补录" BodyPadding="10px" Layout="Fit" runat="server" IconUrl="../res/icon/image_star.png">
                                    <Items>
                                        <f:SimpleForm ID="SimpleForm3" ShowBorder="false" ShowHeader="false" Title="SimpleForm1" LabelWidth="120px" runat="server">

                                            <Items>
                                                <f:ContentPanel runat="server" Title="asd" ShowHeader="False">




                                                    <br />
                                                    <f:RadioButton ID="RadioButton4" Label="盘点范围" Checked="true" GroupName="MyRadioGroup3" Text="全部(默认)" runat="server" Width="200px" LabelWidth="90" OnCheckedChanged="rbtnFirst_CheckedChanged" AutoPostBack="true">
                                                    </f:RadioButton>
                                                    <f:RadioButton ID="RadioButton5" GroupName="MyRadioGroup3" Text="自定义" runat="server" Width="200px" AutoPostBack="true">
                                                    </f:RadioButton>
                                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                                                 <%--   <f:Button ID="btnIcon1" Text="通过" Icon="ApplicationEdit" CssClass="marginr" runat="server" />
                                                    <f:Button ID="Button4" Text="拒绝" Icon="ApplicationError" CssClass="marginr" runat="server" />--%>

                                                    <br />

                                                    <%--     <f:Grid ID="Grid3" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="true"
                                                        ShowHeader="true" runat="server" DataKeyNames="ID,拍照补录" EnableCheckBoxSelect="true" KeepCurrentSelection="true" Height="400px" OnRowCommand="Grid3_RowCommand">--%>



                                                    <f:Grid ID="Grid3" Title="数据表格" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true"
                                                        runat="server" DataKeyNames="ID,拍照补录" EnableCheckBoxSelect="true" Height="400px" OnRowCommand="Grid3_RowCommand">
                                                        <Columns>
                                                            <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                                            <f:RowNumberField />

                                                            <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                                                            <f:LinkButtonField Width="160" CommandName="Action2" Text="查询照片" IconUrl="../res/icon/image.png" />
                                                            <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                                                            <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                                                            <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                                                            <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号"></f:RenderField>
                                                            <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量"></f:RenderField>
                                                            <f:RenderField ColumnID="价格" DataField="价格" HeaderText="原值"></f:RenderField>
                                                            <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门"></f:RenderField>
                                                            <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="盘点人员"></f:RenderField>                                                           
                                                            <f:RenderField ColumnID="拍照补录" DataField="拍照补录" HeaderText="拍照补录" Hidden="True"></f:RenderField>
                                                            <f:RenderField ColumnID="盘点" DataField="盘点" HeaderText="盘点" Hidden="True"></f:RenderField>
                                                        </Columns>
                                                    </f:Grid>
                                                </f:ContentPanel>
                                            </Items>
                                        </f:SimpleForm>
                                    </Items>
                                </f:Tab>

                                <f:Tab Title="盘亏处理" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">
                                    <Items>
                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">




                                            <br />
                                            <f:RadioButton ID="RadioButton6" Checked="true" GroupName="MyRadioGrouppy" Text="盘盈资产" runat="server" Width="200px" LabelWidth="90" OnCheckedChanged="rbtnFirst_CheckedChanged" AutoPostBack="true">
                                            </f:RadioButton>
                                            <f:RadioButton ID="RadioButton7" GroupName="MyRadioGrouppy" Text="盘亏资产" runat="server" Width="200px" AutoPostBack="true">
                                            </f:RadioButton>

                                            <f:DropDownList ID="DropDownList2" Label="处理方式" Required="true" Width="250px" LabelWidth="90" runat="server">
                                                <f:ListItem Text="提交入库" Value="提交入库" />
                                                <f:ListItem Text="转入待报废库" Value="转入待报废库" />

                                            </f:DropDownList>



                                            <f:Grid ID="Grid4" Title="数据表格" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true"
                                                runat="server" DataKeyNames="ID" EnableCheckBoxSelect="true" Height="400px">



                                                <Columns>
                                                    <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                                    <f:RowNumberField />

                                                    <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                                                    <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                                                    <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                                                    <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                                                    <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号"></f:RenderField>
                                                    <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门"></f:RenderField>
                                                    <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="盘点人员"></f:RenderField>
                                                    <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量"></f:RenderField>
                                                    <f:RenderField ColumnID="价格" DataField="价格" HeaderText="原值"></f:RenderField>
                                                    <f:RenderField ColumnID="拍照补录" DataField="拍照补录" HeaderText="拍照补录" Hidden="True"></f:RenderField>
                                                    <f:RenderField ColumnID="盘点" DataField="盘点" HeaderText="盘点" Hidden="True"></f:RenderField>





                                                </Columns>
                                            </f:Grid>
                                        </f:ContentPanel>
                                    </Items>
                                </f:Tab>

                                <f:Tab Title="盘点报告" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">

                                    <Items>
                                        <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="条件查询" runat="server">
                                            <Items>



                                                <f:Panel ID="Panel2" runat="server" Layout="HBox" ShowBorder="false" ShowHeader="false">
                                                    <Items>

                                                        <f:RadioButton ID="RadioButton8" Checked="true" GroupName="盘点" Text="盘盈&nbsp&nbsp&nbsp" runat="server" AutoPostBack="true" BoxFlex="0">
                                                        </f:RadioButton>


                                                        <f:DropDownList ID="DropDownList3" Width="180px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                                            <f:ListItem Text="汇总表" Value="汇总表" />
                                                            <f:ListItem Text="明细表" Value="明细表" />

                                                        </f:DropDownList>
                                                        <f:RadioButton ID="RadioButton9" GroupName="盘点" Text="盘亏&nbsp&nbsp&nbsp" runat="server" AutoPostBack="true">
                                                        </f:RadioButton>

                                                        <f:DropDownList ID="DropDownList4" Required="true" Width="180px" runat="server">
                                                            <f:ListItem Text="汇总表" Value="汇总表" />
                                                            <f:ListItem Text="明细表" Value="明细表" />
                                                        </f:DropDownList>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel1" runat="server" Layout="HBox" ShowBorder="false" ShowHeader="false">
                                                    <Items>
                                                        <f:Label ID="Label1" runat="server" Label="归属信息"></f:Label>
                                                        <f:CheckBox ID="CheckBox1" ShowLabel="false" runat="server" Text="单&nbsp&nbsp位&nbsp&nbsp&nbsp" Checked="true" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true">
                                                        </f:CheckBox>
                                                        <f:DropDownList ID="单位" Width="180px" runat="server" AutoPostBack="true" EmptyText="全部">
                                                        </f:DropDownList>
                                                        <f:CheckBox ID="CheckBox2" ShowLabel="false" runat="server" Text="部&nbsp&nbsp门&nbsp&nbsp&nbsp" Checked="true" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged">
                                                        </f:CheckBox>
                                                        <f:DropDownList ID="部门" AutoPostBack="true" Width="180px" runat="server" EmptyText="全部" OnSelectedIndexChanged="部门_SelectedIndexChanged">
                                                        </f:DropDownList>
                                                        <f:CheckBox ID="CheckBox3" ShowLabel="false" runat="server" Text="负责人&nbsp&nbsp&nbsp" Checked="true" AutoPostBack="true" OnCheckedChanged="CheckBox3_CheckedChanged">
                                                        </f:CheckBox>
                                                        <f:DropDownList ID="负责人" Width="180px" runat="server" AutoPostBack="true" EmptyText="全部">
                                                        </f:DropDownList>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel3" runat="server" Layout="HBox" ShowBorder="false" ShowHeader="false">
                                                    <Items>
                                                        <f:Label ID="Label2" runat="server" Label="资产分类"></f:Label>
                                                        <f:CheckBox ID="CheckBox4" ShowLabel="false" runat="server" Text="一&nbsp&nbsp级&nbsp&nbsp&nbsp" Checked="true" Enabled="false">
                                                        </f:CheckBox>
                                                        <f:DropDownList ID="一级" Width="180px" runat="server" AutoPostBack="true" EmptyText="全部" OnSelectedIndexChanged="一级_SelectedIndexChanged">
                                                        </f:DropDownList>
                                                        <f:CheckBox ID="CheckBox5" ShowLabel="false" runat="server" Text="二&nbsp&nbsp级&nbsp&nbsp&nbsp" Checked="true">
                                                        </f:CheckBox>
                                                        <f:DropDownList ID="二级" Width="180px" runat="server" EmptyText="全部" AutoPostBack="true" OnSelectedIndexChanged="二级_SelectedIndexChanged">
                                                        </f:DropDownList>
                                                        <f:CheckBox ID="CheckBox6" ShowLabel="false" runat="server" Text="三&nbsp&nbsp&nbsp级&nbsp&nbsp&nbsp" Checked="true">
                                                        </f:CheckBox>
                                                        <f:DropDownList ID="三级" Width="180px" runat="server" EmptyText="全部" AutoPostBack="true">
                                                        </f:DropDownList>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel4" runat="server" Layout="HBox" ShowBorder="false" ShowHeader="false">
                                                    <Items>
                                                        <f:Label ID="Label3" runat="server" Label="存放地点"></f:Label>
                                                        <f:CheckBox ID="CheckBox7" ShowLabel="false" runat="server" Text="建&nbsp&nbsp筑&nbsp&nbsp&nbsp" Checked="true">
                                                        </f:CheckBox>
                                                        <f:DropDownList ID="存放地点" Required="true" Width="180px" runat="server" EmptyText="全部" OnSelectedIndexChanged="存放地点_SelectedIndexChanged" AutoPostBack="true">
                                                        </f:DropDownList>
                                                        <f:CheckBox ID="CheckBox8" ShowLabel="false" runat="server" Text="房&nbsp&nbsp间&nbsp&nbsp&nbsp" Checked="true">
                                                        </f:CheckBox>
                                                        <f:DropDownList ID="房间" Width="180px" runat="server" EmptyText="全部" AutoPostBack="true">
                                                        </f:DropDownList>

                                                    </Items>
                                                </f:Panel>

                                                <f:Panel ID="Panel5" runat="server" Layout="HBox" ShowBorder="false" ShowHeader="false">
                                                    <Items>
                                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                                            <f:Button ID="btnIcon1" Text="查询" Icon="Email" runat="server" />
                                                            &nbsp &nbsp
                                                            <f:Button ID="Button4" Text="图表分析" Icon="Email" runat="server" EnablePostBack="false" OnClientClick="AddActiveTab();" >
                                                            </f:Button>
                                                            &nbsp &nbsp
                                                            <f:Button ID="Button5" Text="导出" Icon="Email" runat="server" />
                                                            &nbsp &nbsp
                                                            <f:Button ID="Button6" Text="打印" Icon="Email" runat="server" />
                                                        </f:ContentPanel>
                                                    </Items>
                                                </f:Panel>

                                                <f:Grid ID="Grid5" Title="数据表格" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true"
                                                    runat="server" DataKeyNames="ID" EnableCheckBoxSelect="true" Height="400px">



                                                    <Columns>
                                                        <f:RowNumberField />
                                                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                                                        <f:RenderField ColumnID="部门" DataField="部门" HeaderText="部门"></f:RenderField>
                                                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人"></f:RenderField>



                                                        <f:GroupField HeaderText="资产分类" TextAlign="Center">
                                                            <Columns>
                                                                <f:BoundField Width="150px" DataField="房屋及构筑物" HeaderText="房屋及构筑物" />
                                                                <f:BoundField Width="100px" DataField="通用设备" HeaderText="通用设备" />
                                                                <%--<f:RenderField ColumnID="部门" DataField="部门" HeaderText="部门"></f:RenderField>--%>
                                                                <f:BoundField Width="100px" DataField="专用设备" HeaderText="专用设备" />
                                                                <f:BoundField Width="150px" DataField="家具用具装具" HeaderText="家具用具装具" />
                                                                <f:BoundField Width="100px" DataField="文物陈列品" HeaderText="文物陈列品" />
                                                                <f:BoundField Width="100px" DataField="图书" HeaderText="图书" />
                                                            </Columns>
                                                        </f:GroupField>
                                                        <f:RenderField ColumnID="负责人" DataField="盘点数量" HeaderText="盘点数量"></f:RenderField>
                                                        <f:RenderField ColumnID="负责人" DataField="盘点金额" HeaderText="盘点金额"></f:RenderField>




                                                    </Columns>
                                                </f:Grid>


                                            </Items>
                                        </f:GroupPanel>



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
                        <f:Toolbar ID="Toolbar3" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="Button2" Icon="ApplicationGo" runat="server" Text="提交" OnClick="Button1_Click"></f:Button>
                                <f:Button ID="Button3" Icon="SystemClose" runat="server" Text="关闭"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>


        <f:Window ID="Window6" Title="选择角色" BodyPadding="10px" IsModal="true" Hidden="true"
            Target="Top" Width="700px" Height="700px"
            runat="server">



            <Items>
                <f:Panel ID="Panel13" IsFluid="true" CssClass="blockpanel" runat="server" ShowBorder="true" EnableCollapse="false"
                    BodyPadding="10px" ShowHeader="false" Title="面板" AutoScroll="true" Margin="20px" Height="650px" Width="700px">
                    <Items>
                        <f:Panel ID="Panel14" Title="面板1" CssClass="mypanel" Width="200px" Height="540px" runat="server"
                            BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Tree ID="Tree3" IsFluid="true" CssClass="blockpanel" ShowHeader="true" EnableCollapse="false"
                                    Title="树控件" runat="server" Width="200px" Height="540px" OnNodeCommand="Tree2_NodeCommand">
                                    <Nodes>
                                        <f:TreeNode Text="全部" Expanded="true">
                                            <f:TreeNode Text="办公室11" EnableClickEvent="true" NodeID="1"></f:TreeNode>
                                            <f:TreeNode Text="仓库" EnableClickEvent="true" NodeID="2"></f:TreeNode>
                                            <f:TreeNode Text="地理组" EnableClickEvent="true" NodeID="3"></f:TreeNode>
                                            <f:TreeNode Text="工会" EnableClickEvent="true" NodeID="4"></f:TreeNode>
                                            <f:TreeNode Text="化学组" EnableClickEvent="true" NodeID="5"></f:TreeNode>
                                            <f:TreeNode Text="交流人员" EnableClickEvent="true" NodeID="6"></f:TreeNode>
                                            <f:TreeNode Text="教科处" EnableClickEvent="true" NodeID="7"></f:TreeNode>
                                            <f:TreeNode Text="教务室" EnableClickEvent="true" NodeID="8"></f:TreeNode>
                                            <f:TreeNode Text="历史组" EnableClickEvent="true" NodeID="9"></f:TreeNode>
                                            <f:TreeNode Text="生物组" EnableClickEvent="true" NodeID="10"></f:TreeNode>
                                            <f:TreeNode Text="食堂" EnableClickEvent="true" NodeID="11"></f:TreeNode>
                                            <f:TreeNode Text="数学组" EnableClickEvent="true" NodeID="15"></f:TreeNode>
                                            <f:TreeNode Text="体卫艺教处" EnableClickEvent="true" NodeID="16"></f:TreeNode>
                                            <f:TreeNode Text="体育组" EnableClickEvent="true" NodeID="17"></f:TreeNode>
                                            <f:TreeNode Text="图书馆" EnableClickEvent="true" NodeID="18"></f:TreeNode>
                                            <f:TreeNode Text="文印室" EnableClickEvent="true" NodeID="19"></f:TreeNode>
                                            <f:TreeNode Text="物理组" EnableClickEvent="true" NodeID="20"></f:TreeNode>
                                            <f:TreeNode Text="物业管理" EnableClickEvent="true" NodeID="21"></f:TreeNode>
                                            <f:TreeNode Text="校工" EnableClickEvent="true" NodeID="22"></f:TreeNode>
                                            <f:TreeNode Text="信息技术组" EnableClickEvent="true" NodeID="24"></f:TreeNode>
                                            <f:TreeNode Text="学生处团委" EnableClickEvent="true" NodeID="25"></f:TreeNode>

                                            <f:TreeNode Text="医务室" EnableClickEvent="true" NodeID="26"></f:TreeNode>
                                            <f:TreeNode Text="音美劳组" EnableClickEvent="true" NodeID="27"></f:TreeNode>
                                            <f:TreeNode Text="英语组" EnableClickEvent="true" NodeID="28"></f:TreeNode>
                                            <f:TreeNode Text="语文组" EnableClickEvent="true" NodeID="29"></f:TreeNode>
                                            <f:TreeNode Text="政治组" EnableClickEvent="true" NodeID="30"></f:TreeNode>
                                            <f:TreeNode Text="总务处" EnableClickEvent="true" NodeID="32"></f:TreeNode>
                                            <f:TreeNode Text="财会室" EnableClickEvent="true" NodeID="33"></f:TreeNode>
                                            <f:TreeNode Text="学术委员会" EnableClickEvent="true" NodeID="34"></f:TreeNode>
                                            <f:TreeNode Text="报告厅设备间" EnableClickEvent="true" NodeID="35"></f:TreeNode>
                                            <f:TreeNode Text="报告厅设备间" EnableClickEvent="true" NodeID="36"></f:TreeNode>
                                        </f:TreeNode>
                                    </Nodes>


                                </f:Tree>
                            </Items>

                        </f:Panel>

                        <f:Panel ID="Panel15" Title="面板2" CssClass="mypanel" Width="410px" Height="540px" runat="server"
                            BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Grid ID="Grid9" Title="数据表格" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true"
                                    runat="server" DataKeyNames="ID,姓名" EnableCheckBoxSelect="true" KeepCurrentSelection="true" Height="540px">

                                    <Columns>
                                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                        <f:RowNumberField />
                                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                                        <f:RenderField ColumnID="姓名" DataField="姓名" HeaderText="用户姓名"></f:RenderField>
                                        <f:RenderField ColumnID="学校名称" DataField="学校名称" HeaderText="学校名称"></f:RenderField>
                                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="所在部门" ExpandUnusedSpace="true">
                                        </f:RenderField>



                                    </Columns>
                                </f:Grid>
                            </Items>

                        </f:Panel>


                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar7" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="Button13" Icon="ApplicationGo" runat="server" Text="确定" OnClick="Button13_Click"></f:Button>
                                <f:Button ID="Button14" Icon="SystemClose" runat="server" Text="取消"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:Panel>




            </Items>
        </f:Window>



        <f:Window ID="Window7" Title="人员进度" BodyPadding="10px" IsModal="true" Hidden="true"
            Target="Top" Width="500px" Height="500px"
            runat="server">
            <Items>
                <f:Grid ID="Grid10" Title="人员进度" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true"
                    runat="server" DataKeyNames="ID" KeepCurrentSelection="true" Height="400px">

                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="姓名" DataField="姓名" HeaderText="用户姓名"></f:RenderField>
                        <f:RenderField ColumnID="学校名称" DataField="学校名称" HeaderText="学校名称"></f:RenderField>
                        <f:RenderField ColumnID="管理数量" DataField="管理数量" HeaderText="管理数量"></f:RenderField>
                        <f:RenderField ColumnID="已盘点" DataField="已盘点" HeaderText="已盘点" ExpandUnusedSpace="true">
                        </f:RenderField>
                    </Columns>
                </f:Grid>


            </Items>
        </f:Window>






    </form>
    <script type="text/javascript">



        var windowClientID = '<%= Window1.ClientID %>';
        var gridClientID = '<%= Grid1.ClientID %>';
        var formClientID = '<%= SimpleForm1.ClientID %>';
        var hfFormIDClientID = '<%= hfFormID.ClientID %>';
<%--        var 资产编号 = '<%= 资产编号.ClientID %>';
        var 资产名称 = '<%= 资产名称.ClientID %>';
        var 型号 = '<%= 型号.ClientID %>';
        var 归属部门 = '<%= 归属部门.ClientID %>';
        var 存放地点 = '<%= 存放地点.ClientID %>';
        var 负责人 = '<%= 负责人.ClientID %>';
        var 使用状态 = '<%= 使用状态.ClientID %>';--%>



        function imageurl(imgurl) {
            imgurl = (imgurl.substring(imgurl.length - 1) == ',') ? imgurl.substring(0, imgurl.length - 1) : imgurl;
            var result = imgurl.split(",");
            for (var i = 0; i < result.length; i++) {
                //document.write(result[i]);
                //alert(result[i]);
                window.open('https://www.btsoftwl.cn:2323/bgsbgl/' + result[i], "_blank", "scrollbars=yes,resizable=1,modal=false,alwaysRaised=yes");
            }
        }

        function onEditButtonClick(event) {
            showEditWindow();
        }

        function AddActiveTab() {
            window.open("图表分析.aspx", "图表分析");
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


            F(windowClientID).setTitle('卡片详情');

            // 当前行数据
            var rowValue = grid.getRowValue(rowId);
            //alert(rowId);
            // 使用当前行数据填充表单字段
            //F(hfFormIDClientID).setValue(rowId);
            //F(资产编号).setValue(rowValue['编号']);
            //F(资产名称).setValue(rowValue['名称']);
            //F(型号).setValue(rowValue['型号']);
            //F(归属部门).setValue(rowValue['位置']);
            //F(存放地点).setValue(rowValue['房间名称']);
            //F(负责人).setValue(rowValue['负责人']);
            //F(使用状态).setValue(rowValue['资产状态']);
            //F(tbxFormUserNameClientID).setValue('123');
            //F(rblFormGenderClientID).setValue(rowValue['Gender']);
            //F(nbFormEntranceYearClientI   D).setValue(rowValue['EntranceYear']);
            //F(dpFormEntranceDateClientID).setValue(rowValue['EntranceDate']);
            //F(cbFormAtSchoolClientID).setValue(rowValue['AtSchool']);
            //F(ddlFormMajorClientID).setValue(rowValue['Major']);

            // 弹出新增窗体
            F(windowClientID).show();
        }


    </script>
</body>
</html>
