<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="School处置申报资产报废流程进度.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.School申报管理.School处置申报资产报废流程进度" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="../res/css/lib/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../res/css/less/style.css" />
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
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <div class="container">
            <h3>流程进度</h3>
            <hr />

            <h5>
                <asp:Label ID="Label6" runat="server" Text="Label" Font-Size="X-Large" ForeColor="#ff3300"></asp:Label></h5>
            <ul class="nav nav-pills nav-justified step step-progress" data-step="5">
                <li>
                    <a>申请人发起<span class="caret"></span></a>
                    <br />
                   <%-- <asp:Button ID="xxxxxxxs" runat="server" Text="查看详情" />--%>
                </li>
                <li>
                    <a>分管领导通过<span class="caret"></span></a>
                    <br />

                </li>
                <li>
                    <a>主管部门审核<span class="caret"></span></a>
                    <br />
                </li>
                <li>
                    <a>财政部门审核<span class="caret"></span></a>
                    <br />
                </li>
                <li>
                    <a>财务人员记账<span class="caret"></span></a>
                    <br />
                </li>
            </ul>
            <f:Button ID="查看详情" runat="server" OnClick="查看详情_Click" Text="查看详情"></f:Button>
            <style type="text/css">
                .vertical li > a {
                    padding: 45px 15px;
                }
            </style>
            <hr />
        </div>
        
        <f:Window ID="Window1" Title="查看详情" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1400px">
            <Items>

                <f:Form ID="Form8" BodyPadding="10px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="25% 25% 25% 25% ">
                            <Items>
                                <f:TextBox ID="流程状态_abfckxq" Label="流程状态" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="单据编号_bfckxq" Label="单据编号" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="申请人_bfckxq" Label="申请人" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="申报单位_bfckxq" Label="申报单位" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>
                                <f:TextBox ID="职务_bfckxq" Label="职务" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="电话_bfckxq" Label="电话" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="事项名称_bfckxq" Label="事项名称" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="申报日期" EmptyText="请选择日期"
                                    ID="申报日期_ckxq" ShowRedStar="true" Width="250px" LabelWidth="90">
                                </f:DatePicker>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="25% 10%">
                            <Items>
                                <f:TextBox ID="原因说明_bfckxq" Label="原因说明" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
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
                                <f:TextBox ID="分管领导处理意见_bfckxq" Label="处理意见" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="分管领导_bfckxq" Label="分管领导" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="分管领导操作时间_bfckxq" Label="操作时间" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="主管部门" runat="server"></f:Label>
                                <f:TextBox ID="主管部门处理意见_bfckxq" Label="处理意见" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="主管部门_bfckxq" Label="操作人" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="主管部门操作时间_bfckxq" Label="操作时间" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ColumnWidths="10% 25% 25% 25% ">
                            <Items>
                                <f:Label Text="财政部门" runat="server"></f:Label>
                                <f:TextBox ID="财政部门意见_bfckxq" Label="处理意见" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="财政部门_bfckxq" Label="操作人" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox ID="财政部门操作时间_bfckxq" Label="操作时间" Width="250px" runat="server" LabelWidth="90"></f:TextBox>
                                <f:TextBox runat="server" Label="FlowID" ID="TextBox1" Hidden="true" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="资产ID" ID="TextBox2" Hidden="true" LabelWidth="80"></f:TextBox>
                                <f:TextBox runat="server" Label="Sort" ID="Sort" Hidden="true" LabelWidth="80"></f:TextBox>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>


            </Items>
            
        </f:Window>

        <script src="../res/js/jquery-1.10.2.js"></script>
        <script type="text/javascript" src="../res/js/lib/lib.js"></script>
        <script>


            $(function () {
                var sort = document.getElementById("<%= Label1.ClientID %>").innerText;
                if (sort == 0) {
                    //完成
                    bsStep(5);
                } else {
                    bsStep(sort);
                }
                document.getElementById("<%= Label1.ClientID %>").style.display = "none";//隐藏lable
            })
        </script>
    </form>
</body>
</html>
