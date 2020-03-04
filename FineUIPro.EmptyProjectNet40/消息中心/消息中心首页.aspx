<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="消息中心首页.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.消息中心.消息中心首页" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <style type="text/css">
         .f-grid-row .f-grid-cell-消息事项 [data-color=color1]{
            background-color: #0094ff;
            color: #fff;
        }
         .f-grid-row .f-grid-cell-消息事项 [data-color=color2]{
            background-color: red;
            color: #fff;
        }
       .color1 {
            background-color: #0094ff;
            color: #fff;
        }

        .color2 {
            background-color: red;
            color: #fff;
        }

        .color3 {
            background-color: #b200ff;
            color: #fff;
        }

        /*.f-grid-row[data-color=color2],
        .f-grid-row[data-color=color2] .f-icon,
        .f-grid-row[data-color=color2] a {
            background-color: red;
            color: #fff;
        }
        .f-grid-row[data-color=color1],
        .f-grid-row[data-color=color1] .f-icon,
        .f-grid-row[data-color=color1] a {
            background-color: #0094ff;
            color: #fff;
        }*/
       
        /*.f-grid-row .f-grid-cell-盘盈或盘亏简要原因 {
            background-color: #ff006e; 
            color: #fff;
        }

        .f-grid-row .f-grid-cell-闲置或待报废简要原因 {
            background-color: #ff6a00;
            color: #fff;
        }*/
        /*.f-grid-row .f-grid-cell-盘盈或盘亏简要原因 {
            background-color: #b200ff;
            color: #fff;
        }

            .f-grid-row .f-grid-cell-闲置或待报废简要原因 a,
            .f-grid-row .f-grid-cell-闲置或待报废简要原因 a:hover {
                color: #fff;
            }*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />


        <f:Panel ID="Panel7" runat="server" BodyPadding="10px"
            Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox">
            <Items>
                <f:Form ID="Form5" ShowBorder="False" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="8% 10% 10% 20%">
                            <Items>

                                <%--   <f:TextBox runat="server" Label="单位名称" ID="二级单位" Width="250px" LabelWidth="90" Enabled="false"></f:TextBox>--%>
                                 <f:Button Text="全部设为已读" runat="server" ID="Button1" EnablePostBack="true" ConfirmText="全部设为已读？" OnClick="Button1_Click" Icon="Anchor">
                                </f:Button>
                                <f:Button Text="选中设为已读" runat="server" ID="Button2" Icon="Anchor" OnClick="Button2_Click">
                                </f:Button>

                                <f:Label ID="Label1" Text="XXX条未读数据" EncodeText="false" runat="server">
                                </f:Label>


                                <f:DropDownList ID="通知类型" Width="250px" runat="server" Label="通知类型" LabelWidth="90" AutoPostBack="true" AutoSelectFirstItem="false"
                                    OnSelectedIndexChanged="通知类型_SelectedIndexChanged" EmptyText="全部消息">
                                    <f:ListItem Text="全部消息" Value="全部消息" />
                                    <f:ListItem Text="待办事项通知" Value="待办事项通知" />
                                    <f:ListItem Text="结果反馈通知" Value="结果反馈通知" />
                                    <f:ListItem Text="临界到期提醒" Value="临界到期提醒" />
                                    <f:ListItem Text="异常告警提醒" Value="异常告警提醒" />
                                    <f:ListItem Text="系统通知" Value="系统通知" />                           
                                </f:DropDownList>

                                <%--    <f:Button ID="SelectContentBtn" runat="server" Text="查询" Icon="Magnifier"></f:Button>--%>
                                <%--    <f:Button ID="Button1" runat="server" Text="设置" Icon="Magnifier"></f:Button>--%>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>



                <f:Grid ID="Grid1" IsFluid="true" CssClass="blockpanel" ShowBorder="true" PageSize="15" ShowHeader="true" Title="提醒通知（未读事项红色标识，已读为蓝色）" EnableCollapse="false" Height="730px" AutoExpandColumn="true" 
                    runat="server" DataKeyNames="Id,消息事项,消息内容,发起人,发起时间,通知类型,是否已读,通知职务,FlowID" ExpandAllRowExpanders="true" EnableCheckBoxSelect="true"  AllowPaging="True" OnRowDataBound="Grid1_RowDataBound">
                    <Columns>
                       
                        <f:TemplateField RenderAsRowExpander="true">
                            <ItemTemplate>
                                <div class="expander">
                                    <p>
                                        <strong><%# Eval("消息事项") %></strong>
                                    </p>
                                    <p>
                                        <strong><%# Eval("消息内容") %></strong>
                                    </p>
                                </div>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:BoundField Width="450px" ColumnID="消息事项" DataField="消息事项" HeaderText="消息事项" />
                        <f:RenderField ColumnID="发起人" DataField="发起人" HeaderText="发起人"></f:RenderField>
                        <f:RenderField ColumnID="发起时间" DataField="发起时间" HeaderText="时间"></f:RenderField>
                        <f:RenderField ColumnID="通知类型" DataField="通知类型" HeaderText="通知类型" Width="150px"></f:RenderField>
                        <f:BoundField ColumnID="是否已读" DataField="是否已读"  HeaderText="是否已读" Hidden="true"></f:BoundField>


                    </Columns>

                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <f:Button ID="btnCollapseRowExpanders" runat="server" Text="折叠" OnClick="btnCollapseRowExpanders_Click">
                                </f:Button>
                                <f:Button ID="btnExpandRowExpanders" runat="server" CssClass="marginr" Text="展开" OnClick="btnExpandRowExpanders_Click">
                                </f:Button>
                         
         
                               
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:Grid>

            </Items>
        </f:Panel>
    </form>
</body>
</html>
