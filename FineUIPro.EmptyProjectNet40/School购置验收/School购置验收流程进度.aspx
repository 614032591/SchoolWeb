<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="School购置验收流程进度.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.School购置验收.School购置验收流程进度" %>

<!DOCTYPE html>
<html>

<head runat="server">
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="../res/css/lib/bootstrap.min.css" />
    <!--<link rel="stylesheet/less" type="text/css" href="css/less/style.less?1.10" />
		<script type="text/javascript" src="js/lib/less.js"></script>-->
    <link rel="stylesheet" type="text/css" href="../res/css/less/style.css" />
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" ></asp:Label>
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <div class="container">
            <h3>流程进度</h3>
            <hr />

            <h5>
                <asp:Label ID="Label6" runat="server" Text="Label" Font-Size="X-Large" ForeColor="#ff3300"></asp:Label></h5>
            <ul class="nav nav-pills nav-justified step step-progress" data-step="4">
                <li>
                    <a>管理员申请<span class="caret"></span></a>
                    <br />
                    
                </li>

                <li>
                    <a>财务人员通过<span class="caret"></span></a>
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
                                            <f:Label ID="Label2" ShowLabel="false" runat="server" CssClass="red"></f:Label>
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
                   <%-- <Toolbars>
                        <f:Toolbar ID="Toolbar5" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>
                                <f:Button ID="Button5" runat="server" IconUrl="../res/icon/accept.png" OnClick="Button5_Click">
                                </f:Button>
                                <f:Button ID="Button6" Icon="SystemClose" Text="关闭" runat="server" OnClick="Button6_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>--%>
                </f:SimpleForm>
            </Items>
        </f:Window>

       

        <script src="../res/js/jquery-1.10.2.js"></script>
        <script type="text/javascript" src="../res/js/lib/lib.js"></script>
        <script>
            $(function () {
                var sort = document.getElementById("<%= Label1.ClientID %>").innerText;
                if (sort == 0) {
                    //完成
                    bsStep(2);
                } else {
                    bsStep(sort);
                }

                document.getElementById("<%= Label1.ClientID %>").style.display = "none";//隐藏lable
                //bsStep(i) i 为number 可定位到第几步 如bsStep(2)/bsStep(3)
            })
        </script>
    </form>
</body>

</html>
