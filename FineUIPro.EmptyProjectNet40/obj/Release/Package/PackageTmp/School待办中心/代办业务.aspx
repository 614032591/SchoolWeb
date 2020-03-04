<%@ Page Language="C#" validateRequest="false" AutoEventWireup="true" CodeBehind="代办业务.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.School代办中心.代办业务" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        
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
                                    <f:Label runat="server" ></f:Label>
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
                                OnRowCommand="Grid1_RowCommand" DataKeyNames="ID,流程状态,FlowID,事项名称,通知内容,发起人,发起时间,处理职务"
                                AllowPaging="true" IsDatabasePaging="false" ShowHeader="false">
                                <Columns>
                                    <f:RowNumberField />
                                    <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                                    <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                                    <f:RenderField ColumnID="FlowID" DataField="FlowID" HeaderText="FlowID" Hidden="true"></f:RenderField>
                                    <f:RenderField ColumnID="事项名称" DataField="事项名称" HeaderText="事项名称"></f:RenderField>
                                    <f:RenderField ColumnID="通知内容" DataField="通知内容" TextAlign="Center" ExpandUnusedSpace="true" HeaderText="通知内容"></f:RenderField>
                                    <f:RenderField ColumnID="发起人" DataField="发起人" HeaderText="发起人"></f:RenderField>
                                    <f:RenderField ColumnID="发起时间" DataField="发起时间" Width="120" HeaderText="发起时间"></f:RenderField>
                                    <f:RenderField ColumnID="处理职务" DataField="处理职务" HeaderText="处理职务" Hidden="true"></f:RenderField>
                                    <f:LinkButtonField CommandName="Action1" Text="处理" Icon="ApplicationGo" />
                                    <f:LinkButtonField Hidden="true" CommandName="Action2" Text="处理" IconUrl="../res/icon/application_form_edit.png" />
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
    </form>
</body>
</html>
