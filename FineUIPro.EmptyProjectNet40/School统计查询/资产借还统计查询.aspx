<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="资产借还统计查询.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.School统计查询.资产借还统计查询" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<style>
        .f-grid-colheader-inner{
            background-color:red;
        }
        span{
            font-weight:bold;
            font-size:larger;
            
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Form ID="Form2" ShowBorder="false" ShowHeader="false" runat="server">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" AutoPostBack="true" ID="ttSearch" ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search" OnTrigger2Click="ttSearch_Trigger2Click">
                                </f:TwinTriggerBox>

                                <f:DropDownList ID="DropDownList1" runat="server" AutoSelectFirstItem="false" LabelWidth="110" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="250px" EmptyText="流程状态-全部" AutoPostBack="true">
                                    <f:ListItem Text="流程状态-全部" Value="filter1" />
                                    <f:ListItem Text="完成" Value="filter2" />
                                    <f:ListItem Text="已提交" Value="filter3" />
                                    <f:ListItem Text="已出借,待归还" Value="filter4" />
                                    <%--<f:ListItem Text="已完成" Value="filter5" />--%>
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" runat="server" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1"
                    AllowPaging="true" IsDatabasePaging="false" ShowHeader="false"
                    DataKeyNames="ID,流程状态,单据编号,借用人,借出人,提交时间,借用时间,预计归还时间,备注信息,Sort,资产ID,是否同意,借出人操作时间,操作人,申请人是否归还,申请人归还时间,出借人确认归还,出借人确认时间" OnRowCommand="Grid1_RowCommand">
                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="流程状态" DataField="流程状态" HeaderText="流程状态"></f:RenderField>
                        <f:RenderField ColumnID="单据编号" DataField="单据编号" HeaderText="单据编号"></f:RenderField>
                        <%--<f:RenderField ColumnID="资产数量" DataField="资产数量" HeaderText="资产数量"></f:RenderField>--%>
                        <f:RenderField ColumnID="借用人" DataField="借用人" HeaderText="借用人"></f:RenderField>
                        <f:RenderField ColumnID="借出人" DataField="借出人" HeaderText="借出人"></f:RenderField>
                        <f:RenderField ColumnID="提交时间" DataField="提交时间" HeaderText="提交时间" />
                        <f:RenderField ColumnID="借用时间" DataField="借用时间" HeaderText="借用时间" />
                        <f:RenderField ColumnID="预计归还时间" DataField="预计归还时间" HeaderText="预计归还时间" />
                        <f:RenderField ColumnID="备注信息" DataField="备注信息" HeaderText="备注信息" ExpandUnusedSpace="true" />
                        <f:RenderField ColumnID="Sort" DataField="Sort" HeaderText="Sort" Hidden="true" />
                        <f:RenderField ColumnID="资产ID" DataField="资产ID" HeaderText="资产ID" Hidden="true" />
                        <f:RenderField ColumnID="是否同意" DataField="是否同意" HeaderText="是否同意" Hidden="true" />
                        <f:RenderField ColumnID="借出人操作时间" DataField="借出人操作时间" HeaderText="借出人操作时间" Hidden="true" />
                        <f:RenderField ColumnID="操作人" DataField="操作人" HeaderText="操作人" Hidden="true" />
                        <f:RenderField ColumnID="申请人是否归还" DataField="申请人是否归还" HeaderText="申请人是否归还" Hidden="true" />
                        <f:RenderField ColumnID="申请人归还时间" DataField="申请人归还时间" HeaderText="申请人归还时间" Hidden="true" />
                        <f:RenderField ColumnID="出借人确认归还" DataField="出借人确认归还" HeaderText="出借人确认归还" Hidden="true" />
                        <f:RenderField ColumnID="出借人确认时间" DataField="出借人确认时间" HeaderText="出借人确认时间" Hidden="true" />
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


        <f:Window ID="Window3" Title="查看/处理" Hidden="true" TitleAlign="Center" EnableIFrame="false"
                EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
                IsModal="true" Width="1100px" TableConfigColumns="1" BlockConfigBlockCount="6">
                <Items>

                    <f:Form ID="Form3" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                        <Rows>
                            <f:FormRow ColumnWidths="25% 25% 25% 25%">
                                <Items>
                                    <f:TextBox runat="server" Label="流程状态" ID="查看流程状态" Enabled="false" LabelWidth="80"></f:TextBox>
                                    <f:TextBox runat="server" Label="借用人" ID="查看借用人" LabelWidth="80" Enabled="false"></f:TextBox>
                                    <%--  <f:TextBox runat="server" Label="提交时间" ID="提交时间"  LabelWidth="80"></f:TextBox>--%>

                                    <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="提交时间"
                                        ID="查看提交时间" LabelWidth="85" Enabled="false">
                                    </f:DatePicker>
                                    <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="预计归还时间"
                                        ID="查看预计归还时间" LabelWidth="110" Enabled="false">
                                    </f:DatePicker>

                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="25% 25% 25% 25%">
                                <Items>
                                    <f:TextBox runat="server" Label="单据编号" ID="查看单据编号" LabelWidth="80" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" Label="借出人" ID="查看借出人" LabelWidth="80" Enabled="false"></f:TextBox>
                                    <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="借用时间"
                                        ID="查看借用时间" LabelWidth="85" Enabled="false">
                                    </f:DatePicker>
                                    <f:TextBox runat="server" Label="备注信息" ID="查看备注信息" LabelWidth="80" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" Label="FlowID" ID="FlowID" Hidden="true" LabelWidth="80"></f:TextBox>
                                    <f:TextBox runat="server" Label="资产ID" ID="资产ID" Hidden="true" LabelWidth="80"></f:TextBox>
                                </Items>
                            </f:FormRow>
                        </Rows>
                    </f:Form>
                    <f:Grid ID="Grid3" IsFluid="true" Title="资产借还资产数据" CssClass="blockpanel" ForceFit="true" ShowBorder="true" IsDatabasePaging="false"
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
                <Items>
                    <f:Form  BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                        <Rows>
                            <f:FormRow ColumnWidths="25% 25% 25% 25%">
                                <Items>
                                    <f:TextBox ID="是否同意" Label="是否同意"  LabelWidth="130" Enabled="false" runat="server"></f:TextBox>
                                    <f:TextBox ID="借出人操作时间" Label="借出人操作时间"  LabelWidth="130" Enabled="false" runat="server"></f:TextBox>
                                    <f:TextBox ID="操作人" Label="操作人"  LabelWidth="130" Enabled="false" runat="server"></f:TextBox>
                                    <f:TextBox ID="申请人归还时间" Label="申请人归还时间"  LabelWidth="130" Enabled="false" runat="server"></f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ColumnWidths="25% 25% 25%">
                                <Items>
                                    
                                    <f:TextBox ID="申请人是否归还" Label="申请人是否归还"  LabelWidth="130" Enabled="false" runat="server"></f:TextBox>
                                    <f:TextBox ID="出借人确认归还" Label="出借人确认归还"  LabelWidth="130" Enabled="false" runat="server"></f:TextBox>
                                    <f:TextBox ID="出借人确认时间" Label="出借人确认时间"  LabelWidth="130" Enabled="false" runat="server"></f:TextBox>

                                </Items>
                            </f:FormRow>
                        </Rows>
                    </f:Form>
                </Items>

                <Toolbars>
                    <f:Toolbar ID="Toolbar2" Position="Bottom" ToolbarAlign="Right" runat="server">
                        <Items>
                            <%--<f:Button ID="btnok" Icon="ApplicationGo" runat="server" OnClick="btnok_Click"></f:Button>--%>
                            <f:Button ID="btnon" Icon="SystemClose" runat="server" Text="关闭"></f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>


            </f:Window>
    </form>
</body>
</html>
