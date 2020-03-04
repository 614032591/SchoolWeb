<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="资产维修统计查询.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.统计查询.资产维修统计查询" %>

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

         
        span{
            font-weight:bold;
        }
       
   
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <f:PageManager ID="Page1" AutoSizePanelID="Panel1" runat="server" />
            <f:Panel ID="Panel1" BodyPadding="10px"
                Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                <Items>
                    <f:Form ShowBorder="False" ShowHeader="False" runat="server">
                        <Rows>
                            <f:FormRow>
                                <Items>
                                    <f:DropDownList ID="DropDownList1" runat="server"  Required="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" Label="流程状态" MarginLeft="20"  AutoSelectFirstItem="false" LabelWidth="110" Width="230px" EmptyText="全部" AutoPostBack="true">
                                        <f:ListItem Text="全部" Value="filter1" />                                                                                       
                                        <f:ListItem Text="待派单" Value="filter2" />
                                        <f:ListItem Text="维修中" Value="filter3" />
                                        <f:ListItem Text="已完成" Value="filter4" />
                                    </f:DropDownList>
                                   <%-- <f:DropDownList ID="DropDownList1" runat="server" Required="true"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" AutoSelectFirstItem="false" Width="230px" Label="地点" LabelWidth="80" EmptyText="全部" AutoPostBack="true">
                                        <f:ListItem Text="全部" Value="filter1" />                                                                                       
                                        <f:ListItem Text="待派单" Value="filter2" />
                                        <f:ListItem Text="维修中" Value="filter3" />
                                        <f:ListItem Text="已完成" Value="filter4" />
                                </f:DropDownList>--%>
                                </Items>
                            </f:FormRow>
                            <f:FormRow  ColumnWidths="13% 13% ">
                                <Items>
                                    <f:RadioButtonList ID="RadioButton" AutoPostBack="true" AutoColumnWidth="false" OnSelectedIndexChanged="RadioButton_SelectedIndexChanged" runat="server">
                                        <f:RadioItem  Text="报修大厅" Value="报修大厅"/>
                                        <f:RadioItem  Text="我的报修" Value="我的报修"/>
                                    </f:RadioButtonList>
                                </Items>
                            </f:FormRow>
                        </Rows>
                    </f:Form>
                </Items>
                <Items>
                    <f:Grid ID="Grid1" runat="server" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1"
                        AllowPaging="true" IsDatabasePaging="false" ShowHeader="false" EnableCheckBoxSelect="true" DataKeyNames="ID,流程状态,报修单号,报修人,报修时间,报修地址,故障描述,维修人员,完工时间,结果反馈,故障照片" OnRowCommand="Grid1_RowCommand">
                        <Columns>
                            <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                            <f:RowNumberField />
                            <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                            <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                            <f:RenderField ColumnID="报修单号" DataField="报修单号" HeaderText="报修单号"></f:RenderField>
                            <f:RenderField ColumnID="报修人" DataField="报修人" HeaderText="报修人"></f:RenderField>
                            <f:RenderField ColumnID="报修时间" DataField="报修时间" HeaderText="报修时间"></f:RenderField>
                            <f:RenderField ColumnID="报修地址" DataField="报修地址" HeaderText="报修地址" Width="150"></f:RenderField>
                            <f:RenderField ColumnID="故障描述" DataField="故障描述" HeaderText="故障描述" />
                            <f:RenderField ColumnID="维修人员" DataField="维修人员" HeaderText="维修人员" />
                            <f:RenderField ColumnID="完工时间" DataField="完工时间" HeaderText="完工时间" />
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
                    <f:Window ID="流程状态待派单" Title="流程状态：待派单" Height="750" IsFluid="true" Hidden="true" EnableIFrame="false"
                        EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
                        IsModal="true" Width="1300">
                        <Items>
                            <f:SimpleForm ID="SimpleForm3" IsFluid="true" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                                <Items>
                                    <f:TabStrip ID="TabStrip2" IsFluid="true" CssClass="blockpanel" ShowBorder="true" TabPosition="Top"
                                        EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                                        <Tabs>
                                            <f:Tab Title="<span class='highlight'>报修资产</span>" BodyPadding="10px"
                                                runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                                <Items>
                                                    <f:Grid ID="Grid3" IsFluid="true" CssClass="blockpanel" ShowBorder="true" IsDatabasePaging="false"
                                                        ShowHeader="false" runat="server" Height="200px">
                                                        <Columns>
                                                            <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                                            <f:RowNumberField />
                                                            <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                                                            <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                                                            <f:RenderField ColumnID="一级类别名称" DataField="一级类别名称" HeaderText="资产分类"></f:RenderField>
                                                            <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                                                            <f:RenderField ColumnID="型号" DataField="型号" HeaderText="资产型号"></f:RenderField>
                                                            <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向"></f:RenderField>
                                                            <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量" />
                                                            <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" />
                                                            <f:RenderField ColumnID="原存放地点" DataField="原存放地点" HeaderText="原存放地点" />
                                                            <f:RenderField ColumnID="原归属部门" DataField="原归属部门" HeaderText="原归属部门" />
                                                            <f:RenderField ColumnID="原负责人" DataField="原负责人" HeaderText="原负责人" />
                                                            <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态" ExpandUnusedSpace="true"></f:RenderField>
                                                            <f:LinkButtonField CommandName="Action1" Text="删除" Icon="Delete" Hidden="true" />
                                                        </Columns>
                                                    </f:Grid>
                                                    <%-- 这里是详情页面 --%>
                                                    <f:ContentPanel runat="server" IsFluid="true" Title="报修信息" Height="315" ShowHeader="false" ShowBorder="true">
                                                        <br />
                                                        <f:TextBox runat="server" Label="报修人" Readonly="true" ID="查看报修人" Width="300px" LabelWidth="120"></f:TextBox>
                                                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  
                                                                             &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp                                             
                                             <f:TextBox runat="server" Label="报修时间" Readonly="true" ID="查看报修时间" Width="300px" LabelWidth="120"></f:TextBox>
                                                        <br />
                                                        <f:TextBox runat="server" Label="报修单号" Readonly="true" ID="查看单号" Width="300px" LabelWidth="120"></f:TextBox>
                                                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  
                                                                             &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                                                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp          
                                             <f:TextBox runat="server" Label="报修地址" Readonly="true" ID="查看报修地址" Width="300px" LabelWidth="120"></f:TextBox>
                                                        <br />
                                                        <f:TextBox runat="server" Label="故障描述" ID="查看故障描述" Readonly="true" Width="600px" LabelWidth="120"></f:TextBox>
                                                        <br />
                                                        <f:Image ID="Image2" CssClass="photo" Label="故障照片" ImageUrl="~/res/images/blank.png" ShowEmptyLabel="true" runat="server"></f:Image>
                                                        <%--  <f:TextBox runat="server" Label="申请日期" ID="申请日期" Width="300px" LabelWidth="120"></f:TextBox>--%>
                                                        <f:Label ID="xx" Text="" runat="server" Hidden="true"></f:Label>
                                                        <br />
                                                    </f:ContentPanel>
                                                    <f:ContentPanel runat="server" Title="维修信息" ShowHeader="false" ShowBorder="true">
                                                        <%--     <f:Label ID="Label1" ShowLabel="false" runat="server" CssClass="red"></f:Label>--%>
                                                        <br />
                                                        <f:DropDownList ID="DropDownList3" runat="server" Label="维修人员:" EnableMultiSelect="true" Required="true" LabelWidth="110" Width="300" EmptyText="请选择维修人员" AutoPostBack="true">
                                                        </f:DropDownList>
                                                        <f:TextBox runat="server" Label="联系电话" ID="TextBox7" Width="300px" LabelWidth="120"></f:TextBox>
                                                        <f:TextBox runat="server" Label="完工时间" ID="TextBox6" Width="300px" LabelWidth="120"></f:TextBox>
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
                                            <%--<f:Button ID="Button9" IconUrl="../res/icon/accept.png" runat="server" Text="同意" ConfirmText="是否确认派单？">
                                    </f:Button>--%>
                                            <f:Button ID="Button3" IconUrl="../res/icon/cross.png" Icon="SystemClose" runat="server" Text="关闭" OnClick="Button3_Click"></f:Button>
                                        </Items>
                                    </f:Toolbar>
                                </Toolbars>
                            </f:SimpleForm>
                        </Items>
                    </f:Window>
                </Items>
            </f:Panel>
        </div>
    </form>
</body>
</html>
