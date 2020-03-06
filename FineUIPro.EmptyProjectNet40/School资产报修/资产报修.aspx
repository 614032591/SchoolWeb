<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="资产报修.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.报修管理.资产报修" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .photo {
            height: 130px;
            line-height: 100px;
            width: 100px;
            overflow: hidden;
        }

            .photo img {
                height: 100px;
                vertical-align: middle;
                width: 100px;
            }

        .photot img {
            height: 50px;
            line-height: 100px;
        }

        span {
            font-weight: bold;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <f:PageManager ID="Page17" AutoSizePanelID="Panel7" runat="server" />
            <f:Panel ID="Panel7" ShowBorder="false" ShowHeader="false" Layout="VBox" BodyPadding="10px" BoxConfigAlign="Stretch" runat="server">

                <Items>
                    <f:Form ShowBorder="False" ShowHeader="False" runat="server">
                        <Rows>
                            <f:FormRow ColumnWidths="12% 10% 20% ">
                                <Items>
                                    <f:RadioButtonList ID="Unnamed" AutoPostBack="true" AutoColumnWidth="false" OnSelectedIndexChanged="Unnamed_SelectedIndexChanged" runat="server">
                                        <f:RadioItem Text="报修大厅" Selected="true" Value="报修大厅" />
                                        <f:RadioItem Text="我的报修" Value="我的报修" />
                                    </f:RadioButtonList>
                                    <f:Button ID="Button1" Hidden="true" Text="发起报修" runat="server" OnClick="Button9_Click" IconUrl="../res/icon/add.png">
                                    </f:Button>
                                    <f:DropDownList ID="DropDownList1" runat="server" AutoSelectFirstItem="false" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" Label="流程状态筛选" LabelWidth="110" Width="250px" EmptyText="全部" AutoPostBack="true">
                                        <f:ListItem Text="全部" Value="filter1" />
                                        <f:ListItem Text="已报修，待派单" Value="filter2" />
                                        <f:ListItem Text="已派单，维修中" Value="filter3" />
                                        <f:ListItem Text="已完工，待反馈" Value="filter4" />
                                        <f:ListItem Text="已完成" Value="filter5" />
                                        <f:ListItem Text="已退回" Value="filter6" />
                                    </f:DropDownList>
                                </Items>
                            </f:FormRow>



                        </Rows>
                    </f:Form>
                </Items>
                <%--</f:Panel>--%>
                <%--<f:Panel ID="Panel7" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">--%>
                <Items>
                    <f:Grid ID="Grid1" runat="server" PageSize="20" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1"
                        AllowPaging="true" IsDatabasePaging="false" ShowHeader="false"
                        OnRowCommand="Grid1_RowCommand"
                        DataKeyNames="ID,流程状态,报修单号,报修人,报修时间,报修地址,故障描述,维修人员,完工时间,Sort,结果反馈,故障照片,设备ID">
                        <Columns>
                            <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                            <f:RowNumberField />
                            <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                            <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                            <f:RenderField ColumnID="报修单号" DataField="报修单号" HeaderText="报修单号"></f:RenderField>
                            <f:RenderField ColumnID="报修人" DataField="报修人" HeaderText="报修人"></f:RenderField>
                            <f:RenderField ColumnID="报修时间" DataField="报修时间" HeaderText="报修时间"></f:RenderField>
                            <f:RenderField ColumnID="报修地址" DataField="报修地址" HeaderText="报修地址"></f:RenderField>
                            <f:RenderField ColumnID="故障描述" DataField="故障描述" HeaderText="故障描述" />
                            <f:RenderField ColumnID="维修人员" DataField="维修人员" HeaderText="维修人员" />
                            <f:RenderField ColumnID="完工时间" DataField="完工时间" HeaderText="完工时间" />
                            <f:RenderField ColumnID="Sort" DataField="Sort" HeaderText="Sort" Hidden="true" />
                            <f:RenderField ColumnID="结果反馈" DataField="结果反馈" HeaderText="结果反馈" ExpandUnusedSpace="true" />
                            <f:RenderField ColumnID="故障照片" DataField="故障照片" HeaderText="故障照片" Hidden="true" />
                            <f:LinkButtonField CommandName="Action1" Text="查看详情" Icon="ApplicationGo" />
                            <f:TemplateField HeaderText="新标签页打开" Width="100px">
                                <ItemTemplate>
                                    <a href="javascript:;" onclick="<%# GetEditUrls(Eval("报修单号"), Eval("Sort")) %>">流程进度</a>
                                </ItemTemplate>
                            </f:TemplateField>
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>

            <f:Window ID="Window1" Title="资产报修单" Hidden="true" TitleAlign="Center" EnableIFrame="false"
                EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
                IsModal="true" Width="1100px" TableConfigColumns="1" BlockConfigBlockCount="6">
                <Items>
                    <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                        <Items>
                            <f:HiddenField ID="hfFormID" runat="server"></f:HiddenField>
                            <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" ShowBorder="true" TabPosition="Top"
                                EnableTabCloseMenu="false" ActiveTabIndex="0" ShowTabHeader="false" runat="server">
                                <Tabs>
                                    <f:Tab BodyPadding="10px"
                                        runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                        <Items>
                                            <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                                <f:Button ID="btnIcon1" Text="添加资产" Icon="Add" runat="server" OnClick="btnIcon1_Click" CssClass="marginr" />
                                                <f:Grid ID="Grid2" IsFluid="true" CssClass="blockpanel" ShowBorder="true" IsDatabasePaging="false"
                                                    ShowHeader="false" runat="server" EnableCheckBoxSelect="false" Height="155px">

                                                    <Columns>
                                                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                                        <f:RowNumberField />
                                                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                                                        <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                                                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                                                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                                                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号"></f:RenderField>

                                                        <f:RenderField ColumnID="数量" DataField="数量" Hidden="true" HeaderText="数量" />
                                                        <f:RenderField ColumnID="价格" DataField="价格" Hidden="true" HeaderText="价格" />
                                                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="存放地点" />
                                                        <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                                                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                                                        <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>


                                                    </Columns>
                                                </f:Grid>

                                                <f:Panel ID="Panel6" runat="server" BodyPadding="10" Layout="HBox" ShowBorder="false" ShowHeader="false">
                                                    <Items>
                                                        <f:ContentPanel runat="server" ShowBorder="false" Title="asd" ShowHeader="False">
                                                            <f:TextBox runat="server" Label="报修人" Readonly="true" Required="true" BoxConfigAlign="Center" ID="报修人" Width="300px" LabelWidth="120"></f:TextBox>
                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  
                                                                             &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                             <f:TextBox runat="server" Label="联系电话" Readonly="true" Required="true" ID="联系电话" Width="300px" LabelWidth="120"></f:TextBox>
                                                            <f:DatePicker runat="server" Required="true" Readonly="true" DateFormatString="yyyy-MM-dd" Label="报修时间" EmptyText="报修时间"
                                                                ID="报修时间2" ShowRedStar="true" Width="300px" LabelWidth="120">
                                                            </f:DatePicker>
                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  
                                                                             &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                     <f:TextBox runat="server" Label="报修单号" Required="true" ID="报修单号" Width="300px" LabelWidth="120"></f:TextBox>
                                                            <br />
                                                            <f:DropDownList ID="报修地址" Required="true" Label="报修地址" Width="300px" LabelWidth="120" OnSelectedIndexChanged="报修地址_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                            </f:DropDownList>
                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  
                                                                             &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                    <f:DropDownList ID="房间1" Label="房间" Required="true" Width="300px" LabelWidth="120" AutoPostBack="true" runat="server">
                                                                    </f:DropDownList>

                                                            <f:TextBox runat="server" Label="故障描述" ID="故障描述" Width="600px" LabelWidth="120" EmptyText="请输入故障描述!"></f:TextBox>
                                                            <%--  <f:TextBox runat="server" Label="申请日期" ID="申请日期" Width="300px" LabelWidth="120"></f:TextBox>--%>

                                                            <br />
                                                            <f:Image runat="server" Hidden="true" ID="imgPhoto"></f:Image>
                                                            <f:TextBox runat="server" Hidden="true" ID="cundi"></f:TextBox>
                                                            <f:FileUpload runat="server" ID="filePhoto" ShowRedStar="false" ShowEmptyLabel="true" Label="上传图片"
                                                                ButtonText="上传图片" Required="false" ButtonIcon="ImageAdd" ShowLabel="true" LabelWidth="120" Width="600"
                                                                AutoPostBack="true" OnFileSelected="filePhoto_FileSelected">
                                                            </f:FileUpload>


                                                        </f:ContentPanel>
                                                    </Items>
                                                </f:Panel>


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
                                    <f:Button ID="Button2" Icon="ApplicationGo" runat="server" Text="确认报修" OnClick="Button2_Click"></f:Button>
                                    <f:Button ID="btnClose" Icon="SystemClose" runat="server" Text="取消" OnClick="btnClose_Click"></f:Button>
                                </Items>
                            </f:Toolbar>
                        </Toolbars>
                    </f:SimpleForm>
                </Items>
            </f:Window>

            <f:Window ID="流程状态待派单" Title="流程状态：待派单" IsFluid="true" Hidden="true" EnableIFrame="false"
                EnableMaximize="false" Target="Self" EnableResize="true" runat="server"
                IsModal="true" Width="1200">
                <Items>
                    <f:SimpleForm ID="SimpleForm3" IsFluid="true" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                        <Items>

                            <f:TabStrip ID="TabStrip2" IsFluid="true" CssClass="blockpanel" ShowTabHeader="true" ShowBorder="false" TabPosition="Top"
                                EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                                <Tabs>
                                    <f:Tab BodyPadding="10px"
                                        runat="server" TableColspan="0" Title="资产详情" TableRowspan="0">
                                        <Items>
                                            <f:Grid ID="Grid3" IsFluid="true" CssClass="blockpanel" ShowBorder="true" IsDatabasePaging="false"
                                                ShowHeader="false" runat="server" Height="130px">

                                                <Columns>
                                                    <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                                    <f:RowNumberField />
                                                    <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                                                    <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                                                    <f:RenderField ColumnID="一级类别名称" DataField="一级类别名称" HeaderText="资产分类"></f:RenderField>
                                                    <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                                                    <f:RenderField ColumnID="型号" DataField="型号" HeaderText="资产型号"></f:RenderField>
                                                    <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量" />
                                                    <f:RenderField ColumnID="价格" Hidden="true" DataField="价格" HeaderText="价格" />
                                                    <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="存放地点" />
                                                    <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                                                    <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                                                    <f:RenderField ColumnID="资产状态" DataField="资产状态" ExpandUnusedSpace="true" HeaderText="资产状态"></f:RenderField>
                                                </Columns>
                                            </f:Grid>
                                            <f:ContentPanel runat="server" ShowHeader="false" ShowBorder="false">
                                                <br />
                                            </f:ContentPanel>
                                            <%-- 这里是详情页面 --%>
                                            <f:ContentPanel runat="server" IsFluid="true" Title="报修信息" BodyPadding="20" ShowHeader="false" ShowBorder="true">
                                                <br />
                                                <f:TextBox runat="server" Label="报修人" Readonly="true" ID="查看报修人" Width="250" LabelWidth="80"></f:TextBox>
                                                <f:TextBox runat="server" MarginLeft="30" Label="报修时间" Readonly="true" ID="查看报修时间" Width="270" LabelWidth="80"></f:TextBox>
                                                <f:TextBox runat="server" MarginLeft="30" Label="报修单号" Readonly="true" ID="查看单号" Width="270" LabelWidth="80"></f:TextBox>
                                                <f:TextBox runat="server" MarginLeft="30" Label="报修地址" Readonly="true" ID="查看报修地址" Width="270" LabelWidth="80"></f:TextBox>
                                                <f:TextBox runat="server" Label="维修人员" Readonly="true" ID="TextBox5" Width="250" LabelWidth="80"></f:TextBox>
                                                <f:TextBox runat="server" MarginLeft="30" Label="解决时间" Readonly="true" ID="TextBox6" Width="270" LabelWidth="80"></f:TextBox>
                                                <f:TextBox runat="server" MarginLeft="30" Label="管理员" Readonly="true" ID="TextBox8" Width="270" LabelWidth="80"></f:TextBox>
                                                <f:TextBox runat="server" MarginLeft="30" Label="派单时间" Readonly="true" ID="TextBox9" Width="270" LabelWidth="80"></f:TextBox>
                                                <f:TextBox runat="server" Label="报修人电话" Readonly="true" ID="TextBox10" Width="250" LabelWidth="89"></f:TextBox>
                                                <f:TextBox runat="server" MarginLeft="15" Label="维修人电话" Readonly="true" ID="TextBox11" Width="270" LabelWidth="98"></f:TextBox>
                                                <f:TextBox runat="server" MarginLeft="15" Label="管理员电话" Readonly="true" ID="TextBox12" Width="270" LabelWidth="92"></f:TextBox>
                                                <f:Button ID="查看图片" MarginLeft="110" Width="270" IconUrl="../res/icon/bullet_magnify.png" CssStyle="position:absolute; top:122px;" runat="server" OnClick="查看图片_Click" Text="查看图片">
                                                </f:Button>
                                                <f:TextBox runat="server" Label="故障原因" ID="查看故障描述" Readonly="true" Width="522px" LabelWidth="80"></f:TextBox>
                                                <f:TextBox runat="server" MarginLeft="30" Label="结果反馈" Readonly="true" ID="TextBox13" Width="542" LabelWidth="80"></f:TextBox>


                                                <%--  <f:TextBox runat="server" Label="申请日期" ID="申请日期" Width="300px" LabelWidth="120"></f:TextBox>--%>
                                                <f:Label ID="xx" Text="" runat="server" Hidden="true"></f:Label>
                                                <br />


                                            </f:ContentPanel>

                                            <%--<f:ContentPanel runat="server" Title="结果反馈" ShowHeader="true" ShowBorder="true">
                                                 <f:Label ID="Label1" ShowLabel="false" runat="server" CssClass="red"></f:Label>
                                            <br />
                                             <f:Label ID="Label1" runat="server" Label="" Text="故障是否解决："></f:Label>
                                             <f:RadioButton ID="RadioButton1" runat="server" Label="" GroupName="jiejue" Text="是"></f:RadioButton>
                                             <f:RadioButton ID="RadioButton4" runat="server" Label="" GroupName="jiejue" Text="否"></f:RadioButton>
                                             <f:TextBox runat="server" Label="问题说明" ID="TextBox8" Width="300px" LabelWidth="120"></f:TextBox>
                                             <f:TextBox runat="server" Label="反馈人" ID="TextBox9" Width="300px" LabelWidth="120"></f:TextBox>
                                             <f:DatePicker runat="server" Required="true" Label="日期" EmptyText="选择日期" ID="DatePicker1"
                                                 Width="300"    ShowRedStar="true">
                                             </f:DatePicker>
                                          </f:ContentPanel>--%>
                                        </Items>
                                    </f:Tab>

                                </Tabs>
                            </f:TabStrip>


                        </Items>
                        <Toolbars>
                            <f:Toolbar ID="Toolbar5" Position="Bottom" ToolbarAlign="Right" runat="server">
                                <Items>

                                    <f:Button ID="Button9" Hidden="false" IconUrl="../res/icon/accept.png" runat="server" OnClick="Button9_Click1" Text="处理">
                                    </f:Button>
                                    <f:Button ID="Button3" IconUrl="../res/icon/cross.png" runat="server" Text="拒绝" OnClick="Button3_Click"></f:Button>
                                </Items>
                            </f:Toolbar>
                        </Toolbars>
                    </f:SimpleForm>
                </Items>
            </f:Window>
            <f:Window ID="Window4" Title="派单" TitleAlign="Center" Hidden="true" EnableIFrame="false" EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
                IsModal="true" BodyPadding="20">
                <Items>
                    <f:ContentPanel runat="server" Title="维修信息" ShowHeader="false" ShowBorder="false">
                        <%--     <f:Label ID="Label1" ShowLabel="false" runat="server" CssClass="red"></f:Label>--%>
                        <br />
                        <f:TextBox runat="server" Label="请选择维修人员，已选择" Readonly="true" ID="TextBox4" Width="300px" LabelWidth="120"></f:TextBox>
                        <br />
                        <f:Grid ID="Grid5"  IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="false" IsDatabasePaging="false"
                        ShowHeader="false" runat="server" DataKeyNames="ID,姓名,电话号码" EnableCheckBoxSelect="false" Height="200px" KeepCurrentSelection="true"
                             EnableRowClickEvent="true"
                            EnableRowDoubleClickEvent="true"  OnRowClick="Grid5_RowClick" EnableMultiSelect="false">
                            <Columns>                                
                                <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                                <f:RenderField ColumnID="姓名" DataField="姓名" HeaderText="姓名"></f:RenderField>
                                <f:RenderField ColumnID="电话号码" DataField="电话号码" HeaderText="电话" ExpandUnusedSpace="true"></f:RenderField>
                            </Columns>
                        </f:Grid>
                        
                        <f:TextBox runat="server" Label="请选择维修人员，已选择" Readonly="true" Hidden="true" ID="TextBox7" Width="300px" LabelWidth="120"></f:TextBox>
                       
                        <br />
                        <f:DatePicker runat="server" Readonly="true" Required="true" DateFormatString="yyyy-MM-dd" Label="派单时间"
                            ID="DatePicker1" ShowRedStar="true" Width="300px" LabelWidth="120">
                        </f:DatePicker>
                    </f:ContentPanel>
                </Items>
                <Toolbars>
                    <f:Toolbar ID="Toolbar2" Position="Bottom" ToolbarAlign="Right" runat="server">
                        <Items>

                            <f:Button ID="Button6" IconUrl="../res/icon/accept.png" runat="server" OnClick="Button6_Click" Text="提交">
                            </f:Button>
                            <f:Button ID="Button7" IconUrl="../res/icon/cross.png" runat="server" OnClick="Button7_Click" Text="取消"></f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
            </f:Window>
            <f:Window ID="Window5" Title="维修信息" Hidden="true" EnableIFrame="false" EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
                IsModal="true" BodyPadding="20">
                <Items>
                    <f:ContentPanel runat="server" Title="维修信息" ShowHeader="false" ShowBorder="false">
                        <%--     <f:Label ID="Label1" ShowLabel="false" runat="server" CssClass="red"></f:Label>--%>
                        <br />
                        <f:TextBox runat="server" Label="维修人" ID="TextBox2" Readonly="true" Width="300px" LabelWidth="120"></f:TextBox>
                        <f:TextBox runat="server" Label="联系电话" ID="TextBox1" Readonly="true" Width="300px" LabelWidth="120"></f:TextBox>
                        <br />
                        <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="完成时间"
                            ID="完成时间" ShowRedStar="true" Width="300px" LabelWidth="120">
                        </f:DatePicker>
                        <f:TextBox runat="server" Label="故障原因" ID="TextBox3" Width="300px" LabelWidth="120"></f:TextBox>
                    </f:ContentPanel>
                </Items>
                <Toolbars>
                    <f:Toolbar ID="Toolbar3" Position="Bottom" ToolbarAlign="Right" runat="server">
                        <Items>

                            <f:Button ID="Button8" IconUrl="../res/icon/accept.png" OnClick="Button8_Click" runat="server" Text="提交">
                            </f:Button>
                            <f:Button ID="Button10" IconUrl="../res/icon/cross.png" runat="server" Text="取消"></f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
            </f:Window>
            <f:Window ID="Window3" Title="查看图片" Hidden="true" EnableIFrame="false" EnableMaximize="false" Target="Self" EnableResize="true" runat="server"
                IsModal="true">
                <Items>
                    <f:Image ID="Image2" runat="server" ImageWidth="600" ImageHeight="500" Width="400" Height="400"></f:Image>
                </Items>
            </f:Window>
            <f:Window ID="Window6" Title="确认完成" BodyPadding="20" Hidden="true" EnableIFrame="false" EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
                IsModal="true">
                <Items>
                    <f:ContentPanel BodyPadding="20" runat="server" Title="维修信息" ShowHeader="false" ShowBorder="false">
                        <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="完工时间"
                            ID="DatePicker2" ShowRedStar="true" Width="300px" LabelWidth="120">
                        </f:DatePicker>
                        <f:TextBox runat="server" Label="结果反馈" ID="结果反馈" Width="300px" LabelWidth="120"></f:TextBox>
                    </f:ContentPanel>
                </Items>
                <Toolbars>
                    <f:Toolbar ID="Toolbar4" Position="Bottom" ToolbarAlign="Right" runat="server">
                        <Items>

                            <f:Button ID="Button11" IconUrl="../res/icon/accept.png" OnClick="Button11_Click" runat="server" Text="提交">
                            </f:Button>
                            <f:Button ID="Button12" IconUrl="../res/icon/cross.png" runat="server" Text="取消"></f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
            </f:Window>



            <f:Window ID="Window2" Title="添加资产" Hidden="true" EnableIFrame="false" EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
                IsModal="true" Width="1200px">
                <Items>
                    <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="条件查询" runat="server" BodyPadding="10px">
                        <Items>
                            <f:Panel ID="Panel3" runat="server" Layout="HBox" ShowBorder="false" ShowHeader="false">
                                <Items>
                                    <f:ContentPanel runat="server" Title="asd" ShowBorder="false" ShowHeader="False">
                                        <f:Label ID="Label2" runat="server" Label="资产分类"></f:Label>

                                        <f:DropDownList ID="一级" Width="250px" runat="server" Label="一级" LabelWidth="60" AutoPostBack="true" EmptyText="全部" OnSelectedIndexChanged="一级_SelectedIndexChanged">
                                        </f:DropDownList>
                                        &nbsp
                                <f:DropDownList ID="二级" Width="250px" runat="server" EmptyText="全部" Label="二级" AutoSelectFirstItem="false" LabelWidth="60" AutoPostBack="true" OnSelectedIndexChanged="二级_SelectedIndexChanged">
                                </f:DropDownList>
                                        &nbsp
                                <f:DropDownList ID="三级" Width="250px" runat="server" EmptyText="全部" Label="三级" AutoSelectFirstItem="false" LabelWidth="60" AutoPostBack="true">
                                </f:DropDownList>
                                    </f:ContentPanel>
                                </Items>
                            </f:Panel>

                            <f:Panel ID="Panel1" runat="server" Layout="HBox" ShowBorder="false" ShowHeader="false">
                                <Items>
                                    <f:ContentPanel runat="server" Title="asd" ShowBorder="false" ShowHeader="False">
                                        <f:Label ID="Label3" runat="server" Label="归属信息/存放地点" LabelWidth="140"></f:Label>
                                        <f:DropDownList ID="部门" AutoPostBack="true" Width="230px" runat="server" Label="部门" LabelWidth="60" EmptyText="全部" OnSelectedIndexChanged="部门_SelectedIndexChanged">
                                        </f:DropDownList>
                                        &nbsp
                                    <f:DropDownList ID="负责人" Width="230px" runat="server" AutoPostBack="true" Label="负责人" AutoSelectFirstItem="false" LabelWidth="70" EmptyText="全部">
                                    </f:DropDownList>
                                        &nbsp
                                    <f:DropDownList ID="存放地点" Required="true" Width="230px" runat="server" EmptyText="全部" Label="存放地点" LabelWidth="80" AutoPostBack="true" OnSelectedIndexChanged="存放地点_SelectedIndexChanged">
                                    </f:DropDownList>
                                        &nbsp
                                    <f:DropDownList ID="房间" Width="230px" runat="server" EmptyText="全部" AutoSelectFirstItem="false" Label="房间" LabelWidth="60" AutoPostBack="true">
                                    </f:DropDownList>
                                    </f:ContentPanel>
                                </Items>
                            </f:Panel>

                            <f:Panel ID="Panel4" runat="server" Layout="HBox" ShowBorder="false" ShowHeader="false">
                                <Items>
                                    <f:ContentPanel runat="server" Title="asd" ShowBorder="false" ShowHeader="False">
                                        <f:Label ID="Label4" runat="server" Label="投入时间/关键字" LabelWidth="140"></f:Label>
                                        <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="起始投入日期"
                                            ID="起始投入日期" ShowRedStar="true" Width="300px" LabelWidth="120" EmptyText="请输入日期">
                                        </f:DatePicker>
                                        &nbsp
                                    <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="结束投入日期"
                                        ID="结束投入日期" ShowRedStar="true" Width="300px" LabelWidth="120" EmptyText="请输入日期">
                                    </f:DatePicker>
                                        &nbsp
                                    <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="TwinTriggerBox1"
                                        ShowTrigger1="false"
                                        Trigger1Icon="Clear" Trigger2Icon="Search" Width="250px">
                                    </f:TwinTriggerBox>
                                    </f:ContentPanel>
                                </Items>
                            </f:Panel>
                            <f:Panel ID="Panel5" runat="server" Layout="HBox" ShowBorder="false" ShowHeader="false">
                                <Items>
                                    <f:ContentPanel runat="server" ShowBorder="false" Title="asd" ShowHeader="False">
                                        <f:Button ID="Button4" Text="确认查询" IconUrl="../res/icon/application_form_magnify.png" runat="server" CssClass="marginr" OnClick="Button4_Click" />
                                        &nbsp &nbsp
                                    <f:Button ID="Button5" Text="确认添加" Icon="Add" runat="server" CssClass="marginr" OnClick="Button5_Click" />

                                    </f:ContentPanel>
                                </Items>
                            </f:Panel>


                        </Items>
                    </f:GroupPanel>
                    <f:Grid ID="Grid4" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                        IsDatabasePaging="false"
                        ShowHeader="true" runat="server" DataKeyNames="ID" EnableCheckBoxSelect="true" Height="400px" KeepCurrentSelection="true">

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
                            <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="存放地点" />
                            <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                            <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                            <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>
                        </Columns>
                    </f:Grid>


                </Items>




            </f:Window>




        </div>
    </form>
</body>
</html>
