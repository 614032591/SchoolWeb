<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="代办业务.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.School代办中心.代办业务" %>



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
        <div>
            <f:PageManager AutoSizePanelID="Panel7" runat="server" />
            <f:Panel ID="Pane27" ShowBorder="false" ShowHeader="false" Layout="VBox" BodyPadding="10px" BoxConfigAlign="Stretch" runat="server">
                <Items>
                    <f:Form ID="Form_Panel1" runat="server" ShowBorder="false" ShowHeader="false">
                        <Items>
                            <f:FormRow runat="server" ColumnWidths="12% 12% 20% 46% 20%">
                                <Items>
                                    <f:RadioButtonList ID="Unnamed" AutoPostBack="true" runat="server" OnSelectedIndexChanged="Unnamed_SelectedIndexChanged">
                                        <f:RadioItem Text="待我处理" Selected="true" Value="待我处理" />
                                        <f:RadioItem Text="我发起的" Value="我发起的" />
                                    </f:RadioButtonList>
                                </Items>
                                <Items>
                                    <f:Label runat="server" EncodeText="false" ID="YOU"></f:Label>
                                </Items>
                                <Items>
                                    <f:DropDownList ID="事项名称" Width="250px" runat="server" Label="流程类型" LabelWidth="90" AutoPostBack="true" AutoSelectFirstItem="false" OnSelectedIndexChanged="事项名称_SelectedIndexChanged"
                                        EmptyText="全部消息">
                                    </f:DropDownList>
                                </Items>
                                <Items>
                                    <f:Label runat="server"></f:Label>
                                </Items>
                                <Items>
                                    <f:Button IconUrl="../res/icon/add.png" runat="server" Text="发起一项业务流程"></f:Button>
                                </Items>
                            </f:FormRow>
                        </Items>
                    </f:Form>
                </Items>
            </f:Panel>

            <f:Panel ID="Panel7" IsFluid="true" MarginTop="50" CssClass="blockpanel" Layout="Region" Height="500px" ShowHeader="false" Title="左右区域布局"
                ShowBorder="true" runat="server">
                <Items>
                    <%--<f:Tree ID="Tree1" Width="300" IsFluid="true" RegionPosition="Left" CssClass="blockpanel" ShowHeader="false" EnableCollapse="false"
                        runat="server" Height="900px" EnableSingleExpand="true" OnNodeCommand="Tree1_NodeCommand">
                    </f:Tree>--%>
                    <f:Panel ID="Panel1" ShowHeader="false" EnableIFrame="false" AutoScroll="true" ShowBorder="false"
                        RegionPosition="Center" runat="server">
                        <Items>
                            <f:Grid runat="server" ID="Grid1" Height="740" PageSize="20" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1"
                                OnRowCommand="Grid1_RowCommand" DataKeyNames="ID,流程状态,FlowID,FlowName,事项名称,通知内容,发起人,发起时间,处理职务,Sort"
                                AllowPaging="true" IsDatabasePaging="false" ShowHeader="false">
                                <Columns>
                                    <f:RowNumberField />
                                    <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                                    <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                                    <f:RenderField ColumnID="FlowID" DataField="FlowID" HeaderText="FlowID" Hidden="true"></f:RenderField>
                                    <f:RenderField ColumnID="FlowName" DataField="FlowName" HeaderText="FlowName" Hidden="true"></f:RenderField>
                                    <f:RenderField ColumnID="事项名称" DataField="事项名称" HeaderText="事项名称" Width="120"></f:RenderField>
                                    <f:RenderField ColumnID="通知内容" DataField="通知内容" TextAlign="Center" ExpandUnusedSpace="true" HeaderText="通知内容"></f:RenderField>
                                    <f:RenderField ColumnID="发起人" DataField="发起人" HeaderText="发起人"></f:RenderField>
                                    <f:RenderField ColumnID="发起时间" DataField="发起时间" Width="120" HeaderText="发起时间"></f:RenderField>
                                    <f:RenderField ColumnID="处理职务" DataField="处理职务" HeaderText="处理职务" Hidden="true"></f:RenderField>
                                    <f:RenderField ColumnID="Sort" DataField="Sort" HeaderText="Sort" Hidden="true"></f:RenderField>
                                    <f:LinkButtonField CommandName="Action1" Text="处理" Icon="ApplicationGo" />
                                    <f:LinkButtonField Hidden="true" CommandName="Action2" Text="处理" IconUrl="../res/icon/application_form_edit.png" />

                                    <%--<f:TemplateField HeaderText="新标签页打开" Width="100px">
                                        <ItemTemplate>
                                            <a href="javascript:;" onclick="<%# GetEditUrls(Eval("FlowID"),Eval("FlowName"),Eval("事项名称"), Eval("Sort")) %>">流程进度</a>
                                        </ItemTemplate>
                                    </f:TemplateField>--%>
                                </Columns>
                            </f:Grid>
                            <f:Grid runat="server" ID="Grid4" Hidden="true" Height="740" PageSize="20" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1"
                                OnRowCommand="Grid4_RowCommand" DataKeyNames="ID,流程状态,FlowID,FlowName,事项名称,通知内容,发起人,发起时间,处理职务,Sort"
                                AllowPaging="true" IsDatabasePaging="false" ShowHeader="false">
                                <Columns>
                                    <f:RowNumberField />
                                    <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                                    <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                                    <f:RenderField ColumnID="FlowID" DataField="FlowID" HeaderText="FlowID" Hidden="true"></f:RenderField>
                                    <f:RenderField ColumnID="FlowName" DataField="FlowName" HeaderText="FlowName" Hidden="true"></f:RenderField>
                                    <f:RenderField ColumnID="事项名称" DataField="事项名称" HeaderText="事项名称" Width="120"></f:RenderField>
                                    <f:RenderField ColumnID="通知内容" DataField="通知内容" TextAlign="Center" ExpandUnusedSpace="true" HeaderText="通知内容"></f:RenderField>
                                    <f:RenderField ColumnID="发起人" DataField="发起人" HeaderText="发起人"></f:RenderField>
                                    <f:RenderField ColumnID="发起时间" DataField="发起时间" Width="120" HeaderText="发起时间"></f:RenderField>
                                    <f:RenderField ColumnID="处理职务" DataField="处理职务" HeaderText="处理职务" Hidden="true"></f:RenderField>
                                    <f:RenderField ColumnID="Sort" DataField="Sort" HeaderText="Sort" Hidden="true"></f:RenderField>
                                    <f:LinkButtonField CommandName="Action1" Text="查看详情" Icon="ApplicationGo" />
                                    <f:TemplateField HeaderText="新标签页打开" Width="100px">
                                        <ItemTemplate>
                                            <a href="javascript:;" onclick="<%# GetEditUrls(Eval("FlowID"),Eval("FlowName"),Eval("事项名称"), Eval("Sort")) %>">流程进度</a>
                                        </ItemTemplate>
                                    </f:TemplateField>
                                </Columns>
                            </f:Grid>




                        </Items>
                    </f:Panel>
                </Items>
               
            </f:Panel>




        </div>
        <%-- 资产报修 --%>
        <f:Window ID="流程状态待派单" Title="流程状态：待派单" IsFluid="true" Hidden="true" EnableIFrame="false"
            EnableMaximize="false" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1200">
            <Items>
                <f:SimpleForm ID="SimpleForm3" IsFluid="true" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>

                        <f:TabStrip ID="TabStrip2" IsFluid="true" CssClass="blockpanel" ShowTabHeader="false" ShowBorder="false" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                            <Tabs>
                                <f:Tab BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0">
                                    <Items>
                                        <f:Grid ID="Grid3" IsFluid="true" CssClass="blockpanel" ShowBorder="true" IsDatabasePaging="false"
                                            ShowHeader="false" runat="server" Height="130px">

                                            <Columns>
                                                <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                                <f:RowNumberField />
                                                <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                                                <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号" MinWidth="180"></f:RenderField>
                                                <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                                                <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                                                <f:RenderField ColumnID="型号" DataField="型号" HeaderText="资产型号"></f:RenderField>
                                                <%--<f:RenderField ColumnID="使用方向" DataField="使用方向" Hidden="true" HeaderText="使用方向"></f:RenderField>--%>
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
                                            <f:TextBox runat="server" Label="报修人" Readonly="true" ID="查看报修人" Width="250" LabelWidth="89"></f:TextBox>
                                            <f:TextBox runat="server" MarginLeft="30" Label="报修时间" Readonly="true" ID="查看报修时间" Width="270" LabelWidth="82"></f:TextBox>
                                            <f:TextBox runat="server" MarginLeft="30" Label="报修单号" Readonly="true" ID="查看单号" Width="270" LabelWidth="80"></f:TextBox>
                                            <f:TextBox runat="server" MarginLeft="30" Label="报修地址" Readonly="true" ID="查看报修地址" Width="270" LabelWidth="80"></f:TextBox>
                                            <f:TextBox runat="server" Label="维修人员" Readonly="true" ID="查看维修人员" Width="250" LabelWidth="89"></f:TextBox>
                                            <f:TextBox runat="server" MarginLeft="30" Label="解决时间" Readonly="true" ID="查看解决时间" Width="270" LabelWidth="82"></f:TextBox>
                                            <f:TextBox runat="server" MarginLeft="30" Label="管理员" Readonly="true" ID="查看管理员" Width="270" LabelWidth="80"></f:TextBox>
                                            <f:TextBox runat="server" MarginLeft="30" Label="派单时间" Readonly="true" ID="查看派单时间" Width="270" LabelWidth="80"></f:TextBox>
                                            <f:TextBox runat="server" Label="报修人电话" Readonly="true" ID="查看报修人电话" Width="250" LabelWidth="89"></f:TextBox>
                                            <f:TextBox runat="server" MarginLeft="15" Label="维修人电话" Readonly="true" ID="查看维修人电话" Width="270" LabelWidth="98"></f:TextBox>
                                            <f:TextBox runat="server" MarginLeft="15" Label="管理员电话" Readonly="true" ID="查看管理员电话" Width="270" LabelWidth="92"></f:TextBox>
                                            <f:Button ID="查看图片" MarginLeft="110" Width="270" IconUrl="../res/icon/bullet_magnify.png" CssStyle="position:absolute; top:122px;" runat="server" Text="查看图片" OnClick="查看图片_Click">
                                            </f:Button>
                                            <f:TextBox runat="server" Label="故障原因" ID="查看故障描述" Readonly="true" Width="522px" LabelWidth="89"></f:TextBox>
                                            <f:TextBox runat="server" MarginLeft="30" Label="结果反馈" Readonly="true" ID="查看结果反馈" Width="542" LabelWidth="80"></f:TextBox>


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

                                <f:Button ID="Button9" IconUrl="../res/icon/accept.png" runat="server" Text="处理" OnClick="Button9_Click1">
                                </f:Button>
                                <f:Button ID="Button3" IconUrl="../res/icon/cross.png" runat="server" Text="关闭" OnClick="Button3_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>
        <f:Window ID="查看图片3" Title="查看图片" Hidden="true" EnableIFrame="false" EnableMaximize="false" Target="Self" EnableResize="true" runat="server"
            IsModal="true">
            <Items>
                <f:Image ID="Image2" runat="server" ImageWidth="600" ImageHeight="500" Width="400" Height="400"></f:Image>
            </Items>
        </f:Window>
        <f:Window ID="Window4" Title="维修信息" Hidden="true" EnableIFrame="false" EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" BodyPadding="20">
            <Items>
                <f:ContentPanel runat="server" Title="维修信息" ShowHeader="false" ShowBorder="false">
                    <%--     <f:Label ID="Label1" ShowLabel="false" runat="server" CssClass="red"></f:Label>--%>
                    <br />
                    <f:TextBox runat="server" Label="管理员" Readonly="true" ID="TextBox4" Width="300px" LabelWidth="120"></f:TextBox>
                    <br />
                    <f:DropDownList ID="DropDownList3" runat="server" Label="维修人员:" EnableMultiSelect="true" Required="true" LabelWidth="120" Width="300" EmptyText="请选择维修人员" AutoPostBack="true">
                    </f:DropDownList>
                    <br />
                    <f:TextBox runat="server" Label="联系电话" ID="TextBox7" Width="300px" LabelWidth="120"></f:TextBox>
                    <br />
                    <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="派单时间"
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
                    <f:TextBox runat="server" Label="联系电话" ID="TextBox1" Width="300px" LabelWidth="120"></f:TextBox>
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
        <%-- 资产交接 --%>
        <f:Window ID="Window3" Title="查看/处理" Hidden="true" TitleAlign="Center" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1100px" TableConfigColumns="1" BlockConfigBlockCount="6">
            <Items>

                <f:Form ID="Form3" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>
                                <f:TextBox runat="server" Label="流程状态" ID="查看流程状态" Enabled="false" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="交付人" ID="查看交付人" LabelWidth="80" Enabled="false"></f:TextBox>
                                <%--  <f:TextBox runat="server" Label="提交时间" ID="提交时间"  LabelWidth="80"></f:TextBox>--%>

                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="提交时间"
                                    ID="查看提交时间" LabelWidth="85" Enabled="false">
                                </f:DatePicker>
                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="完成时间"
                                    ID="查看完成时间" LabelWidth="110" Enabled="false">
                                </f:DatePicker>

                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="25% 25% 50%">
                            <Items>
                                <f:TextBox runat="server" Label="单据编号" ID="查看单据编号" LabelWidth="80" Enabled="false"></f:TextBox>
                                <f:TextBox runat="server" Label="接收人" ID="查看接收人" LabelWidth="80" Enabled="false"></f:TextBox>
                                <f:TextBox runat="server" Label="备注信息" ID="查看备注信息" LabelWidth="80" Enabled="false"></f:TextBox>
                                <f:TextBox runat="server" Label="FlowID" ID="FlowID" Hidden="true" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="资产ID" ID="资产ID" Hidden="true" LabelWidth="80"></f:TextBox>
                            </Items>
                        </f:FormRow>
                    </Rows>


                </f:Form>


                <f:Grid ID="Grid2" IsFluid="true" Title="资产借还资产数据" CssClass="blockpanel" ShowBorder="true" IsDatabasePaging="false"
                    ShowHeader="false" runat="server" EnableCheckBoxSelect="false" Height="250px">

                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="使用方向" DataField="使用方向" Hidden="true" HeaderText="使用方向"></f:RenderField>
                        <f:RenderField ColumnID="数量" DataField="数量" Hidden="true" HeaderText="数量" />
                        <f:RenderField ColumnID="价格" DataField="价格" Hidden="true" HeaderText="价格" />
                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="存放地点" />
                        <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                        <%-- <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>--%>
                    </Columns>
                </f:Grid>




            </Items>


            <Toolbars>
                <f:Toolbar ID="Toolbar1" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="btnok" Icon="ApplicationGo" runat="server" Text="处理" OnClick="btnok_Click"></f:Button>
                        <f:Button ID="btnon" Icon="SystemClose" runat="server" Text="关闭"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>


        </f:Window>







        <%-- 资产借还 --%>
        <f:Window ID="Window1" Title="查看/处理" Hidden="true" TitleAlign="Center" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1100px" TableConfigColumns="1" BlockConfigBlockCount="6">
            <Items>

                <f:Form ID="Form2" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>
                                <f:TextBox runat="server" Label="流程状态" ID="TextBox5" Enabled="false" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="借用人" ID="查看借用人" LabelWidth="80" Enabled="false"></f:TextBox>
                                <%--  <f:TextBox runat="server" Label="提交时间" ID="提交时间"  LabelWidth="80"></f:TextBox>--%>

                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="提交时间"
                                    ID="DatePicker3" LabelWidth="85" Enabled="false">
                                </f:DatePicker>
                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="预计归还时间"
                                    ID="查看预计归还时间" LabelWidth="110" Enabled="false">
                                </f:DatePicker>

                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>
                                <f:TextBox runat="server" Label="单据编号" ID="TextBox6" LabelWidth="80" Enabled="false"></f:TextBox>
                                <f:TextBox runat="server" Label="借出人" ID="查看借出人" LabelWidth="80" Enabled="false"></f:TextBox>
                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="借用时间"
                                    ID="查看借用时间" LabelWidth="85" Enabled="false">
                                </f:DatePicker>
                                <f:TextBox runat="server" Label="备注信息" ID="TextBox8" LabelWidth="80" Enabled="false"></f:TextBox>
                                <f:TextBox runat="server" Label="FlowID" ID="TextBox9" Hidden="true" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="资产ID" ID="TextBox10" Hidden="true" LabelWidth="80"></f:TextBox>
                            </Items>
                        </f:FormRow>
                    </Rows>


                </f:Form>


                <f:Grid ID="Grid5" IsFluid="true" Title="资产借还资产数据" CssClass="blockpanel" ShowBorder="true" IsDatabasePaging="false"
                    ShowHeader="false" runat="server" EnableCheckBoxSelect="false" Height="250px">

                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="使用方向" DataField="使用方向" Hidden="true" HeaderText="使用方向"></f:RenderField>
                        <f:RenderField ColumnID="数量" DataField="数量" Hidden="true" HeaderText="数量" />
                        <f:RenderField ColumnID="价格" DataField="价格" Hidden="true" HeaderText="价格" />
                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="存放地点" />
                        <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                        <%-- <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>--%>
                    </Columns>
                </f:Grid>




            </Items>


            <Toolbars>
                <f:Toolbar ID="Toolbar6" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="Button1" Icon="ApplicationGo" runat="server" Text="同意" OnClick="Button1_Click"></f:Button>
                        <f:Button ID="Button2" Icon="SystemClose" runat="server" Text="拒绝"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>


        </f:Window>

        <%-- 待我处理资产处置-报废 --%>
        <f:Window ID="待我处理资产处置_报废" Title="查看详情" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1400px">
            <Items>
                <f:Form BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="25% 25% 25% 25% ">
                            <Items>
                                <f:TextBox ID="流程状态db" Label="流程状态" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="单据编号db" Label="单据编号" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="申请人db" Label="申请人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="申报单位db" Label="申报单位" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>                          
                        </f:FormRow>
                        <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>
                                <f:TextBox ID="职务db" Label="职务" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="电话db" Label="电话" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="事项名称db" Label="事项名称" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="申报日期" EmptyText="请选择日期"
                                    ID="申报日期db" ShowRedStar="true" Width="250px" LabelWidth="90" Readonly="true">
                                </f:DatePicker>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="25% 10%">
                            <Items>
                                <f:TextBox ID="原因说明db" Label="原因说明" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" AutoColumnWidth="false" runat="server" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                                    <f:RadioItem Text="处置单" Selected="true" Value="处置单" />
                                    <f:RadioItem Text="明细表" Value="明细表" />
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid13" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="true" runat="server" DataKeyNames="ID" Height="300px" EnableSummary="true" SummaryPosition="Bottom">
                     <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="类型_bfckxq" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="数量_bfxq" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格_bfxq" DataField="价格" HeaderText="原值"></f:RenderField>
                        <f:RenderField ColumnID="净值_bfckxq" DataField="净值" HeaderText="净值"></f:RenderField>
                        <f:RenderField ColumnID="处置方式_bfckxq" DataField="处置方式" HeaderText="处置方式" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>
                <f:Grid ID="Grid14" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="true" runat="server" DataKeyNames="ID" Height="300px" EnableSummary="true" SummaryPosition="Bottom" Hidden="true">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID_bfckxq" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="编号_bfckxq" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="类型_bfckxq" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="名称_bfckxq" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="型号_bfckxq" DataField="型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="使用方向_bfckxq" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                        <f:RenderField ColumnID="数量_bfxq" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格_bfxq" DataField="价格" HeaderText="价格" />
                        <f:RenderField ColumnID="房间名称_bfckxq" DataField="房间名称" HeaderText="存放地点" />
                        <f:RenderField ColumnID="部门名称_bfckxq" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人_bfckxq" DataField="负责人" HeaderText="负责人" />
                        <f:RenderField ColumnID="资产状态_bfckxq" DataField="资产状态" HeaderText="资产状态" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>
                <f:Form ID="Form10" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="分管领导" runat="server"></f:Label>
                                <f:TextBox ID="处理意见dbfg" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="分管领导dbfg" Label="分管领导" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="操作时间dbfg" Label="操作时间" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="主管部门" runat="server"></f:Label>
                                <f:TextBox ID="处理意见dbzg" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="操作人dbzg" Label="操作人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="操作时间dbzg" Label="操作时间" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="财政部门" runat="server"></f:Label>
                                <f:TextBox ID="处理意见dbcz" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="操作人dbcz" Label="操作人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="操作时间dbcz" Label="操作时间" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox runat="server" Label="FlowID" ID="TextBox22" Hidden="true" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="资产ID" ID="TextBox23" Hidden="true" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="Sort" ID="Sortdb" Hidden="true" LabelWidth="80"></f:TextBox>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Toolbars>
                <f:Toolbar ID="Toolbar10" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="待我处理资产处置_报废处理" Icon="ApplicationGo" runat="server" Text="处理" OnClick="待我处理资产处置_报废处理_Click"></f:Button>
                        <f:Button ID="待我处理报废关闭" Icon="SystemClose" runat="server" Text="关闭" OnClick="待我处理报废关闭_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>

        <%-- 资产处置-报废 --%>
        <f:Window ID="资产处置_报废" Title="查看详情" Hidden="true" EnableIFrame="false"
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


                <f:Form ID="Form9" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="分管领导" runat="server"></f:Label>
                                <f:TextBox ID="分管领导处理意见_bfckxq" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="分管领导_bfckxq" Label="分管领导" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="分管领导操作时间_bfckxq" Label="操作时间" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="主管部门" runat="server"></f:Label>
                                <f:TextBox ID="主管部门处理意见_bfckxq" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="主管部门_bfckxq" Label="操作人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="主管部门操作时间_bfckxq" Label="操作时间" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="财政部门" runat="server"></f:Label>
                                <f:TextBox ID="财政部门意见_bfckxq" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="财政部门_bfckxq" Label="操作人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="财政部门操作时间_bfckxq" Label="操作时间" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox runat="server" Label="FlowID" ID="TextBox11" Hidden="true" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="资产ID" ID="TextBox12" Hidden="true" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="Sort" ID="Sort" Hidden="true" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="FlowName" ID="FlowName" Hidden="true" LabelWidth="80"></f:TextBox>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>


            </Items>
             <Toolbars>
                <f:Toolbar ID="Toolbar8" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="报废处理" Icon="ApplicationGo" runat="server" Text="处理" OnClick="报废处理_Click"></f:Button>
                        <f:Button ID="报废关闭" Icon="SystemClose" runat="server" Text="关闭" OnClick="报废关闭_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>

        
        <%-- 待我处理资产处置-调拨 --%>
        <f:Window ID="待我处理资产处置_调拨" Title="固定资产处置单" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1400px">
            <Items>
                <f:Form ID="Form6" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="25% 25% 25% 25% ">
                            <Items>
                                <f:TextBox ID="流程状态ab" Label="流程状态" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="单据编号ab" Label="单据编号" Width="250px" runat="server" LabelWidth="90" Readonly="true">
                                </f:TextBox>

                                <f:TextBox ID="申请人ab" Label="申请人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调出单位ab" Label="调出单位" Width="250px" runat="server" LabelWidth="90" Readonly="true">
                                </f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>

                                <f:TextBox ID="职务ab" Label="职务" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="电话ab" Label="电话" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="事项名称ab" Label="事项名称" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="申报日期" EmptyText="请选择日期"
                                    ID="申报日期ab" ShowRedStar="true" Width="250px" LabelWidth="90" Readonly="true">
                                </f:DatePicker>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="25% 25% 10% ">
                            <Items>

                                <f:TextBox ID="调入单位ab" Label="调入单位" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="验收日期" EmptyText="请选择日期"
                                    ID="验收日期ab" ShowRedStar="true" Width="250px" LabelWidth="90" Readonly="true">
                                </f:DatePicker>
                                <f:RadioButtonList ID="RadioButtonList6" AutoPostBack="true" AutoColumnWidth="false" runat="server" OnSelectedIndexChanged="RadioButtonList6_SelectedIndexChanged">
                                    <f:RadioItem Text="处置单" Selected="true" Value="处置单" />
                                    <f:RadioItem Text="明细表" Value="明细表" />
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>


                <f:Grid ID="Grid17" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="true" runat="server" EnableSummary="true" SummaryPosition="Bottom" DataKeyNames="ID" Height="300px">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="类型_ab" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="数量_ab" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格_ab" DataField="价格" HeaderText="原值"></f:RenderField>
                        <f:RenderField ColumnID="净值_ab" DataField="净值" HeaderText="净值"></f:RenderField>
                        <f:RenderField ColumnID="处置方式_ab" DataField="处置方式" HeaderText="处置方式" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>

                <f:Grid ID="Grid18" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="true" runat="server" EnableSummary="true" SummaryPosition="Bottom" DataKeyNames="ID" Height="300px" Hidden="true">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="_ab" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="编号_ab" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="类型_ab" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="名称_ab" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="型号_ab" DataField="型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="使用方向_ab" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                        <f:RenderField ColumnID="数量_ab" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格_ab" DataField="价格" HeaderText="价格" />
                        <f:RenderField ColumnID="房间名称_ab" DataField="房间名称" HeaderText="存放地点" />
                        <f:RenderField ColumnID="部门名称_ab" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人_ab" DataField="负责人" HeaderText="负责人" />
                        <f:RenderField ColumnID="资产状态_ab" DataField="资产状态" HeaderText="资产状态" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>
                <f:Form ID="Form11" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="调出单位分管领导" runat="server"></f:Label>
                                <f:TextBox ID="调出单位分管领导意见ab" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调出单位分管领导ab" Label="分管领导" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调出单位分管领导处理时间ab" Label="操作日期" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="调入单位管理员" runat="server"></f:Label>
                                <f:TextBox ID="调入单位管理员意见ab" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调入单位管理员ab" Label="分管领导" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调入单位管理员处理时间ab" Label="操作日期" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>

                         <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="调入单位分管领导" runat="server"></f:Label>
                                <f:TextBox ID="调入单位分管领导意见ab" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调入单位分管领导ab" Label="分管领导" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="调入单位分管领导处理时间ab" Label="操作日期" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="主管部门" runat="server"></f:Label>
                                <f:TextBox ID="调拨主管部门意见ab" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="主管部门ab" Label="操作人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="主管部门处理时间ab" Label="操作日期" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="财政部门" runat="server"></f:Label>
                                <f:TextBox ID="调拨财政部门意见ab" Label="处理意见" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="财政部门ab" Label="操作人" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                                <f:TextBox ID="财政部门处理时间ab" Label="操作日期" Width="250px" runat="server" LabelWidth="90" Readonly="true"></f:TextBox>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>

            <Toolbars>
                <f:Toolbar ID="Toolbar11" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="待我处理资产处置_调拨处理" Icon="ApplicationGo" runat="server" Text="处理" OnClick="待我处理资产处置_调拨处理_Click"></f:Button>
                        <f:Button ID="Button4" Icon="SystemClose" runat="server" OnClick="Button4_Click" Text="关闭"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>

        <%-- 资产处置-调拨 --%>
        <f:Window ID="资产处置_调拨" Title="固定资产处置单" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1400px">
            <Items>


                <f:Form ID="Form4" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
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
                    ShowHeader="true" runat="server" EnableSummary="true" SummaryPosition="Bottom" DataKeyNames="ID" Height="300px">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="类型_dbckxq" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="数量_dbckxq" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格_dbckxq" DataField="价格" HeaderText="原值"></f:RenderField>
                        <f:RenderField ColumnID="净值_bfckxq" DataField="净值" HeaderText="净值"></f:RenderField>
                        <f:RenderField ColumnID="处置方式_dbckxq" DataField="处置方式" HeaderText="处置方式" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>

                <f:Grid ID="Grid10" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="true" runat="server" EnableSummary="true" SummaryPosition="Bottom" DataKeyNames="ID" Height="300px" Hidden="true">
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID_bfckxq" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="编号_bfckxq" DataField="编号" HeaderText="资产编号"></f:RenderField>
                        <f:RenderField ColumnID="类型_bfckxq" DataField="类型" HeaderText="资产分类"></f:RenderField>
                        <f:RenderField ColumnID="名称_bfckxq" DataField="名称" HeaderText="资产名称"></f:RenderField>
                        <f:RenderField ColumnID="型号_bfckxq" DataField="型号" HeaderText="规格型号"></f:RenderField>
                        <f:RenderField ColumnID="使用方向_bfckxq" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                        <f:RenderField ColumnID="数量_dbckxq" DataField="数量" HeaderText="数量"></f:RenderField>
                        <f:RenderField ColumnID="价格_dbckxq" DataField="价格" HeaderText="价格" />
                        <f:RenderField ColumnID="房间名称_bfckxq" DataField="房间名称" HeaderText="存放地点" />
                        <f:RenderField ColumnID="部门名称_bfckxq" DataField="部门名称" HeaderText="归属部门" />
                        <f:RenderField ColumnID="负责人_bfckxq" DataField="负责人" HeaderText="负责人" />
                        <f:RenderField ColumnID="资产状态_bfckxq" DataField="资产状态" HeaderText="资产状态" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>


                <f:Form ID="Form5" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
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
                <f:Toolbar ID="Toolbar7" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="btnClose" Icon="SystemClose" runat="server" OnClick="btnClose_Click" Text="关闭"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>












        </f:Window>

        <%-- 处置申报弹窗 --%>
        <f:Window ID="审批处理界面" Title="审批/处理界面" Hidden="true"
            Target="Self" runat="server"
            IsModal="true" Width="350px">
            <Items>
                <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                    <br />
                    <f:TextArea runat="server" ID="处理意见" LabelWidth="90" EmptyText="请输入！默认同意！" Label="处理意见"
                       >
                    </f:TextArea>
                    <br />
                </f:ContentPanel>
            </Items>

            <Toolbars>
                <f:Toolbar ID="Toolbar9" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="ZCCLSPYES" Icon="ApplicationGo" runat="server" Text="同意" OnClick="ZCCLSPYES_Click"></f:Button>
                        <f:Button ID="ZCCLSPNO" Icon="SystemClose" runat="server" Text="拒绝" OnClick="ZCCLSPNO_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>

        <f:Window ID="新增资产转移查看详情" Title="新增资产转移（查看详情）" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1100" TitleAlign="Center">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:Form ID="Form7" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                            <Rows>
                                <f:FormRow ColumnWidths="33% 33% 33% ">
                                    <Items>
                                        <f:TextBox ID="TextBox13" Readonly="true" Label="流程状态" Width="250px" runat="server" LabelWidth="90">
                                        </f:TextBox>
                                        <f:TextBox ID="TextBox14" Readonly="true" Label="单据编号" Width="250px" runat="server" LabelWidth="90">
                                        </f:TextBox>
                                        <f:TextBox ID="查看事项名称" Readonly="true" Label="事项名称" Width="250px" runat="server" LabelWidth="90">
                                        </f:TextBox>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ColumnWidths="33% 33% 33% ">
                                    <Items>

                                        <f:TextBox ID="查看申请人" Readonly="true" Label="申请人" Width="250px" runat="server" LabelWidth="90">
                                        </f:TextBox>
                                        <f:DatePicker runat="server" Readonly="true" DateFormatString="yyyy-MM-dd" Label="申请日期"
                                            ID="查看申请日期" ShowRedStar="true" Width="250px" LabelWidth="90">
                                        </f:DatePicker>
                                        <f:TextBox ID="查看联系方式" Label="联系方式" Readonly="true" Width="250px" runat="server" LabelWidth="90">
                                        </f:TextBox>
                                        <f:Label ID="Label1" Text="" runat="server" Hidden="true"></f:Label>
                                    </Items>
                                </f:FormRow>
                            </Rows>
                        </f:Form>

                        <f:Grid ID="Grid6" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true" Title="表格" EnableCollapse="false"
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



                        <%--     <f:Label ID="Label1" ShowLabel="false" runat="server" CssClass="red"></f:Label>--%>
                        <f:Form ID="Form12" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                            <Rows>
                                <f:FormRow ColumnWidths="33% 33% 33% ">
                                       <Items>
                                        <f:TextBox ID="查看存放地点变更为" Label="存放地点变更为" Readonly="true" Width="300px" runat="server" LabelWidth="130">
                                        </f:TextBox>
                                        <f:TextBox ID="查看归属部门变更为" Label="归属部门变更为" Readonly="true" Width="300px" runat="server" LabelWidth="130">
                                        </f:TextBox>
                                        <f:TextBox ID="查看负责人变更为" Label="负责人变更为" Readonly="true" Width="300px" runat="server" LabelWidth="130">
                                        </f:TextBox>
                                    </Items>
                                </f:FormRow>
                            </Rows>
                        </f:Form>
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar12" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>

                                <f:Button ID="Button5" IconUrl="../res/icon/accept.png" runat="server" Text="同意" ConfirmText="是否审核通过？" OnClick="Button5_Click">
                                </f:Button>
                                <f:Button ID="Button13" IconUrl="../res/icon/cross.png" runat="server" Text="拒绝"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>


        <%-- 购置验待带我处理查看详情 --%>
        <f:Window ID="购置验收待我处理查看详情" Title="查看/处理资产信息" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1100">
            <Items>
                <f:SimpleForm ID="SimpleForm2" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="HiddenField1" runat="server"></f:HiddenField>
                        <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                            <Tabs>
                                <f:Tab Title="<span class='highlight'>资产信息</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    <Items>


                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                            <br />
                                            <f:TextBox ID="流程状态_gzys" Label="流程状态" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="事项名称_gzys" Label="事项名称" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="单据编号_gzys" Label="单据编号" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="取得方式_gzys" Label="取得方式" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <br />

                                            <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="制单日期"
                                                ID="查看制单日期" ShowRedStar="true" Width="250px" Readonly="true" LabelWidth="90">
                                            </f:DatePicker>

                                            <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="购置日期"
                                                ID="查看购置日期" ShowRedStar="true" Width="250px" Readonly="true" LabelWidth="90">
                                            </f:DatePicker>

                                            <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="验收日期"
                                                ID="查看验收日期" ShowRedStar="true" Width="250px" Readonly="true" LabelWidth="90">
                                            </f:DatePicker>

                                        </f:ContentPanel>

                                        <f:Grid ID="Grid11" IsFluid="true" CssClass="span" ShowBorder="true" ShowHeader="true" Title="表格" EnableCollapse="false"
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
                                            
                                            <f:Label ID="Label2" ShowLabel="false" runat="server" CssClass="red"></f:Label>
                                            <br />
                                            <f:TextBox ID="查看供应商" Label="供应商" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看供应商联系方式" Label="供应商联系方式" Width="250px" runat="server" Readonly="true" LabelWidth="130">
                                            </f:TextBox>
                                            <f:TextBox ID="查看合同编号" Label="合同编号" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看发票号" Label="发票号" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <br />
                                            <f:TextBox ID="查看备注" Label="备注" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <br />
                                            <f:TextBox ID="申请人_gzys" Label="申请人" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看验收人" Label="验收人" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看记账人" Label="记账人" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="flowid_gzys" Label="flowid" runat="server" Hidden="true">
                                            </f:TextBox>
                                        </f:ContentPanel>


                                    </Items>
                                </f:Tab>

                            </Tabs>
                        </f:TabStrip>

                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar13" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="购置验收待我处理_cl" runat="server" IconUrl="../res/icon/accept.png" OnClick="购置验收待我处理_cl_Click">
                                </f:Button>
                                <f:Button ID="购置验收待我处理_gb" Icon="SystemClose" Text="关闭" runat="server" OnClick="购置验收待我处理_gb_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>

         <%-- 购置验收我的发起处理查看详情 --%>
         <f:Window ID="购置验收我的发起处理查看详情" Title="查看/处理资产信息" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1100">
            <Items>
                <f:SimpleForm ID="SimpleForm4" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="HiddenField2" runat="server"></f:HiddenField>
                        <f:TabStrip ID="TabStrip3" IsFluid="true" CssClass="blockpanel" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                            <Tabs>
                                <f:Tab Title="<span class='highlight'>资产信息</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    <Items>


                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                            <br />
                                            <f:TextBox ID="流程状态_wdgzys" Label="流程状态" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="事项名称_wdgzys" Label="事项名称" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="单据编号_wdgzys" Label="单据编号" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="取得方式_wdgzys" Label="取得方式" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <br />

                                            <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="制单日期"
                                                ID="查看制单日期_wdgzys" ShowRedStar="true" Width="250px" LabelWidth="90" Readonly="true">
                                            </f:DatePicker>

                                            <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="购置日期"
                                                ID="查看购置日期_wdgzys" ShowRedStar="true" Width="250px" LabelWidth="90" Readonly="true">
                                            </f:DatePicker>

                                            <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="验收日期"
                                                ID="查看验收日期_wdgzys" ShowRedStar="true" Width="250px" LabelWidth="90" Readonly="true">
                                            </f:DatePicker>

                                        </f:ContentPanel>

                                        <f:Grid ID="Grid12" IsFluid="true" CssClass="span" ShowBorder="true" ShowHeader="true" Title="表格" EnableCollapse="false"
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
                                            
                                            <f:Label ID="Label3" ShowLabel="false" runat="server" CssClass="red"></f:Label>
                                            <br />
                                            <f:TextBox ID="查看供应商_wdgzys" Label="供应商" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看供应商联系方式_wdgzys" Label="供应商联系方式" Width="250px" runat="server" Readonly="true" LabelWidth="130">
                                            </f:TextBox>
                                            <f:TextBox ID="查看合同编号_wdgzys" Label="合同编号" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <f:TextBox ID="查看发票号_wdgzys" Label="发票号" Width="250px" runat="server" Readonly="true" LabelWidth="90">
                                            </f:TextBox>
                                            <br />
                                            <f:TextBox ID="查看备注_wdgzys" Label="备注" runat="server" LabelWidth="90" Readonly="true">
                                            </f:TextBox>
                                            <br />
                                            <f:TextBox ID="申请人_wdgzys" Label="申请人" Width="250px" runat="server" LabelWidth="90" Readonly="true">
                                            </f:TextBox>
                                            <f:TextBox ID="查看验收人_wdgzys" Label="验收人" Width="250px" runat="server" LabelWidth="90" Readonly="true">
                                            </f:TextBox>
                                            <f:TextBox ID="查看记账人_wdgzys" Label="记账人" Width="250px" runat="server" LabelWidth="90" Readonly="true">
                                            </f:TextBox>
                                            <f:TextBox ID="flowid_wdgzys" Label="flowid" runat="server" Hidden="true">
                                            </f:TextBox>
                                        </f:ContentPanel>


                                    </Items>
                                </f:Tab>

                            </Tabs>
                        </f:TabStrip>

                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar14" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="购置验收待我处理_wdgzyscl" runat="server" IconUrl="../res/icon/accept.png" OnClick="购置验收待我处理_wdgzyscl_Click">
                                </f:Button>
                                <f:Button ID="购置验收待我处理_wdgzysgb" Icon="SystemClose" Text="关闭" runat="server" OnClick="购置验收待我处理_wdgzysgb_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window> 
    </form>
</body>
</html>
