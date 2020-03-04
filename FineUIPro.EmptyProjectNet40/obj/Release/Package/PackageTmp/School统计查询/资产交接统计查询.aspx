<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="资产交接统计查询.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.School统计查询.资产交接统计查询" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                            <f:FormRow ColumnWidths="18% 10% 15% ">
                                <Items>
                                    <f:RadioButtonList ID="Unnamed" AutoPostBack="true" AutoColumnWidth="false" runat="server">
                                        <f:RadioItem Text="交接大厅 |" Selected="true" Value="交接大厅" />
                                        <f:RadioItem Text="我的交付" Value="我的交付" />
                                        <f:RadioItem Text="我的接收" Value="我的接收" />
                                    </f:RadioButtonList>
                                   <%-- <f:Button ID="Button1" Text="发起资产交接" runat="server" OnClick="Button1_Click" IconUrl="../res/icon/add.png">
                                    </f:Button>--%>
                                    <f:DropDownList ID="DropDownList1" runat="server" AutoSelectFirstItem="false" LabelWidth="110" Width="250px" EmptyText="全部" AutoPostBack="true">
                                        <f:ListItem Text="全部" Value="filter1" />
                                        <f:ListItem Text="待派单" Value="filter2" />
                                        <f:ListItem Text="维修中" Value="filter3" />
                                        <f:ListItem Text="维修完成" Value="filter4" />
                                        <f:ListItem Text="已完成" Value="filter5" />
                                    </f:DropDownList>
                                </Items>
                            </f:FormRow>



                        </Rows>
                    </f:Form>
                </Items>
                <%--</f:Panel>--%>
                <%--<f:Panel ID="Panel7" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">--%>
                <Items>
                    <f:Grid ID="Grid1" runat="server" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1"
                        AllowPaging="true" IsDatabasePaging="false" ShowHeader="false" 
                        DataKeyNames="ID,流程状态,单据编号,交付人,接收人,提交时间,完成时间,备注信息,Sort,资产ID" OnRowCommand="Grid1_RowCommand">
                        <Columns>
                            <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                            <f:RowNumberField />
                            <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                            <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                            <f:RenderField ColumnID="单据编号" DataField="单据编号" HeaderText="单据编号"></f:RenderField>
                            <%--<f:RenderField ColumnID="资产数量" DataField="资产数量" HeaderText="资产数量"></f:RenderField>--%>
                            <f:RenderField ColumnID="交付人" DataField="交付人" HeaderText="交付人"></f:RenderField>
                            <f:RenderField ColumnID="接收人" DataField="接收人" HeaderText="接收人"></f:RenderField>
                            <f:RenderField ColumnID="提交时间" DataField="提交时间" HeaderText="提交时间" />
                            <f:RenderField ColumnID="完成时间" DataField="完成时间" HeaderText="完成时间" />                           
                            <f:RenderField ColumnID="备注信息" DataField="备注信息" HeaderText="备注信息" ExpandUnusedSpace="true" />
                            <f:RenderField ColumnID="Sort" DataField="Sort" HeaderText="Sort" Hidden="true" />
                            <f:RenderField ColumnID="资产ID" DataField="资产ID" HeaderText="资产ID" Hidden="true" />
                            <f:LinkButtonField CommandName="Action1" Text="查看详情" Icon="ApplicationGo" />
                            <f:TemplateField HeaderText="新标签页打开" Width="100px">
                                <ItemTemplate>
                                    <a href="javascript:;" onclick="<%# GetEditUrls(Eval("单据编号"), Eval("Sort")) %>">流程进度</a>
                                </ItemTemplate>
                            </f:TemplateField>
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>

            <f:Window ID="Window1" Title="资产借还单" Hidden="true" TitleAlign="Center" EnableIFrame="false"
                EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
                IsModal="true" Width="1100px" TableConfigColumns="1" BlockConfigBlockCount="6">
                <Items>

                    <f:Form ID="Form2" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                        <Rows>
                            <f:FormRow ColumnWidths="25% 25% 25% 25%">
                                <Items>
                                    <f:TextBox runat="server" Label="流程状态" ID="流程状态" LabelWidth="80"></f:TextBox>
                                    <f:TextBox runat="server" Label="交付人" ID="交付人" LabelWidth="80"></f:TextBox>
                                    <%--  <f:TextBox runat="server" Label="提交时间" ID="提交时间"  LabelWidth="80"></f:TextBox>--%>

                                    <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="提交时间"
                                        ID="提交时间" LabelWidth="85">
                                    </f:DatePicker>
                                    <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="完成时间"
                                        ID="完成时间" LabelWidth="110" EmptyText="请输入归还时间">
                                    </f:DatePicker>

                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="25% 25% 50%">
                                <Items>
                                    <f:TextBox runat="server" Label="单据编号" ID="单据编号" LabelWidth="80"></f:TextBox>
                                    <f:DropDownList ID="接收人List" Width="230px" runat="server" AutoPostBack="true"  EmptyText="请选择接收人！"   Label="接收人" AutoSelectFirstItem="false" LabelWidth="80">
                                    </f:DropDownList>
                                    <f:TextBox runat="server" Label="备注信息" ID="备注信息" LabelWidth="85"></f:TextBox>

                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="30">
                                <Items>
                                    <f:Button ID="btnIcon1" Text="添加资产" Icon="Add" runat="server" OnClick="btnIcon1_Click" CssClass="marginr" />
                                </Items>
                            </f:FormRow>
                        </Rows>


                    </f:Form>


                    <f:Grid ID="Grid2" IsFluid="true" CssClass="blockpanel" ShowBorder="true" IsDatabasePaging="false"
                        ShowHeader="false" runat="server" EnableCheckBoxSelect="false" Height="250px">

                        <Columns>
                            <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
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
                            <%--<f:Button ID="Button2" Icon="ApplicationGo" runat="server" Text="提交" OnClick="Button2_Click"></f:Button>--%>
                            <f:Button ID="btnClose" Icon="SystemClose" runat="server" Text="取消"></f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>


            </f:Window>

<%--            <f:Window ID="Window2" Title="添加资产" Hidden="true" EnableIFrame="false" EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
                IsModal="true" Width="1200px">
                <Items>
                    <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="条件查询" runat="server" BodyPadding="10px">
                        <Items>
                            <f:Panel ID="Panel1" runat="server" Layout="HBox" ShowBorder="false" ShowHeader="false">
                                <Items>
                                    <f:ContentPanel runat="server" Title="asd" ShowBorder="false" ShowHeader="False">

                                       
                                    <f:DropDownList ID="负责人" Width="230px" runat="server" AutoPostBack="true"  EmptyText="请选择负责人！" OnSelectedIndexChanged="负责人_SelectedIndexChanged"  Label="负责人" AutoSelectFirstItem="false" LabelWidth="70">
                                    </f:DropDownList>
                                        &nbsp
                                     <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="TwinTriggerBox1"
                                         ShowTrigger1="false"  OnTextChanged="TwinTriggerBox1_TextChanged"
                                         Trigger1Icon="Clear" Trigger2Icon="Search" Width="250px">
                                     </f:TwinTriggerBox>
                                        
                                        &nbsp
                                    <f:Button ID="Button5" Text="确认添加" CssStyle="position:absolute;top:0px;" Icon="Add" runat="server" CssClass="marginr" OnClick="Button5_Click" />

                                    </f:ContentPanel>
                                </Items>
                            </f:Panel>


                        </Items>
                    </f:GroupPanel>
                    <f:Grid ID="Grid4" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                        ShowHeader="true" runat="server" DataKeyNames="ID" EnableCheckBoxSelect="true" Height="400px" KeepCurrentSelection="true">
                        <Columns>
                            
                            <f:RowNumberField />
                            <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                            <f:RenderField ColumnID="编号" DataField="编号" HeaderText="资产编号"></f:RenderField>
                            <f:RenderField ColumnID="类型" DataField="类型" HeaderText="资产分类"></f:RenderField>
                            <f:RenderField ColumnID="名称" DataField="名称" HeaderText="资产名称"></f:RenderField>
                            <f:RenderField ColumnID="型号" DataField="型号" HeaderText="规格型号"></f:RenderField>
                            <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向" Hidden="true"></f:RenderField>
                            <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量" />
                            <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" />
                            <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="存放地点" />
                            <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="归属部门" />
                            <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                            <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Window>--%>



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


                    <f:Grid ID="Grid3" IsFluid="true" Title="资产借还资产数据" CssClass="blockpanel" ShowBorder="true" IsDatabasePaging="false"
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
                    <f:Toolbar ID="Toolbar2" Position="Bottom" ToolbarAlign="Right" runat="server">
                        <Items>
                            <%--<f:Button ID="btnok" Icon="ApplicationGo" runat="server" OnClick="btnok_Click"></f:Button>--%>
                            <f:Button ID="btnon" Icon="SystemClose" OnClick="btnon_Click" runat="server" Text="关闭"></f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>


            </f:Window>
        </div>
    </form>
</body>
</html>
