<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="固定资产卡片明细webform.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.固定资产卡片明细.固定资产卡片明细webform" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta name="sourcefiles" content="~/grid/grid_iframe_window.aspx" />

    <style type="text/css">
       
        /*.f-grid-colheader {
            font-size:20px;
        }*/
        .f-grid-colheader-text{
            font-weight:bold;
        }
        .span{
            font-weight:bold;
        }
    
        .f-fieldlabel-text{
            font-weight:bold;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <f:Panel ID="Panel7" runat="server" BodyPadding="10px"
            Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">

            <Items>
                <f:Form ID="Form5" ShowBorder="False" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="8% 20% 20% 20%">
                            <Items>
                                <f:Label ID="Label2" runat="server" Label="资产分类" Width="100" LabelWidth="140"></f:Label>
                                <f:DropDownList ID="一级分类" Width="250px" EmptyText="全部" Label="一级" LabelWidth="60" AutoPostBack="true" AutoSelectFirstItem="false" OnSelectedIndexChanged="一级分类_SelectedIndexChanged" runat="server">
                                </f:DropDownList>
                                <f:DropDownList ID="二级分类" Width="260px" EmptyText="全部" Label="二级" LabelWidth="80" AutoPostBack="true" AutoSelectFirstItem="false" OnSelectedIndexChanged="二级分类_SelectedIndexChanged" runat="server">
                                </f:DropDownList>
                                <f:DropDownList ID="三级分类" Width="250px" runat="server" EmptyText="全部" Label="三级" AutoSelectFirstItem="false" LabelWidth="60" AutoPostBack="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="8% 20% 20% 20%">
                            <Items>
                                <f:Label ID="Label1" runat="server" Label="归属信息" LabelWidth="140" Width="100"></f:Label>
                                <f:DropDownList ID="部门归属" AutoPostBack="true" Width="250px" runat="server" Label="部门" AutoSelectFirstItem="false" LabelWidth="60" EmptyText="全部" OnSelectedIndexChanged="部门归属_SelectedIndexChanged">
                                </f:DropDownList>
                                <f:DropDownList ID="负责人_a" Width="250px" runat="server" AutoPostBack="true" Label="负责人" AutoSelectFirstItem="false" LabelWidth="80" EmptyText="全部">
                                </f:DropDownList>                              
                            </Items>
                        </f:FormRow>                          
                        <f:FormRow ColumnWidths="8% 20% 20% 20%">
                            <Items>
                                <f:Label runat="server" Label="存放地点" LabelWidth="140" Width="100"></f:Label>
                                <f:DropDownList ID="存放地点_a" Required="true" Width="230px" runat="server" AutoSelectFirstItem="false" EmptyText="全部" Label="地点" LabelWidth="60" AutoPostBack="true" OnSelectedIndexChanged="存放地点_a_SelectedIndexChanged">
                                </f:DropDownList>
                                <f:DropDownList ID="房间" Width="230px" runat="server" EmptyText="全部" AutoSelectFirstItem="false" Label="房间" LabelWidth="80" AutoPostBack="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="8% 15% 15% 15% ">
                            <Items>
                                <f:Label ID="Label4" runat="server" Label="投入时间" LabelWidth="140" Width="100"></f:Label>
                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd"
                                    ID="起始投入日期" ShowRedStar="true" Width="300px" EmptyText="请输入起始日期">
                                </f:DatePicker>

                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd"
                                    ID="结束投入日期" ShowRedStar="true" Width="300px" EmptyText="请输入截止日期">
                                </f:DatePicker>

                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="TwinTriggerBox1"
                                    ShowTrigger1="false"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" Width="250px">
                                </f:TwinTriggerBox>

                                <f:Button ID="Button5" Text="确认查询" IconUrl="../res/icon/application_form_magnify.png" runat="server" OnClick="Button5_Click" />

                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>

                <f:Grid ID="Grid2" Title="数据表格" PageSize="15" IsFluid="true"  ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" KeepCurrentSelection="false" DataKeyNames="ID,编号,名称,资产状态,投入使用日期,型号,类型,价格,数量,使用方向" EnableCheckBoxSelect="false" OnPageIndexChange="Grid2_PageIndexChange" OnRowCommand="Grid2_RowCommand">
              
                    <Columns>
                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField Width="200px" ColumnID="编号" DataField="编号" HeaderText="编号"></f:RenderField>
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="名称"></f:RenderField>
                        <f:RenderField ColumnID="资产状态" DataField="资产状态" HeaderText="资产状态"></f:RenderField>
                        <f:RenderField ColumnID="投入使用日期" DataField="投入使用日期" HeaderText="投入使用日期"></f:RenderField>
                        <f:RenderField ColumnID="型号" DataField="型号" HeaderText="型号" />
                        <f:RenderField ColumnID="类型" DataField="类型" HeaderText="类型" />
                        <f:RenderField ColumnID="负责人" DataField="负责人" HeaderText="负责人" />
                        <f:RenderField ColumnID="位置" DataField="位置" HeaderText="位置" />
                        <f:RenderField ColumnID="房间名称" DataField="房间名称" HeaderText="房间名称" Width="150px" />
                        <f:RenderField ColumnID="价格" DataField="价格" HeaderText="价格" />
                        <f:RenderField ColumnID="数量" DataField="数量" HeaderText="数量" />
                        <f:RenderField ColumnID="使用方向" DataField="使用方向" HeaderText="使用方向" Hidden="True"  />
                        <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="部门名称"  />
                        <f:LinkButtonField Width="80" CommandName="Action1" HeaderText="资产卡片" IconUrl="../res/icon/application_form.png" />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>

       <f:Window ID="Window1" Title="查看详情" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="900px">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="hfFormID" runat="server"></f:HiddenField>
                        <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" Height="500px" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server" AutoPostBack="true" OnTabIndexChanged="TabStrip1_TabIndexChanged">
                            <Tabs>
                                <f:Tab Title="<span class='highlight'>基础信息</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    <Items>
                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                            <br />
                                            <f:TextBox runat="server" Label="资产编号" ID="资产编号" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="资产名称" ID="资产名称" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />
                                            <f:TextBox runat="server" Label="资产状态" ID="资产状态" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="投入使用日期" ID="投入使用日期" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />
                                            <f:TextBox runat="server" Label="资产型号" ID="资产型号" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="资产类型" ID="资产类型" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />
                                            <f:TextBox runat="server" Label="资产价格" ID="资产价格" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="资产数量" ID="资产数量" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />
                                        <%--    <f:TextBox runat="server" Label="使用方向" ID="使用方向" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />--%>

                                            <asp:Image ID="Image1" runat="server"  ImageUrl="~/res/images/wzp.gif" Width="400" Height="270" AlternateText="图片" />
                                            &nbsp
                   
                                            <f:Image ID="Image3" runat="server" Width="400" Height="270"></f:Image>
                                        </f:ContentPanel>
                                    </Items>
                                </f:Tab>
                     

                                <f:Tab Title="维修记录" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">
                                    <Items>
                                        <f:Grid ID="Grid3" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false" ShowHeader="true" runat="server" Height="450px">
                                            <Columns>
                                                <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                                <f:RowNumberField />
                                                <f:RenderField ColumnID="故障时间" DataField="故障时间" HeaderText="故障时间"></f:RenderField>
                                                <f:RenderField ColumnID="报修时间" DataField="报修时间" HeaderText="报修时间"></f:RenderField>
                                                <f:RenderField ColumnID="故障描述" DataField="故障描述" HeaderText="故障描述" />
                                                <f:RenderField ColumnID="更换备件" DataField="更换备件" HeaderText="更换备件" />
                                                <f:RenderField ColumnID="故障分析" DataField="故障分析" HeaderText="故障分析" />
                                                <f:RenderField ColumnID="维修措施" DataField="维修措施" HeaderText="维修措施" />
                                                <f:RenderField ColumnID="解决故障时间" DataField="解决故障时间" HeaderText="解决故障时间" />
                                                <f:RenderField ColumnID="维修费用" DataField="维修费用" HeaderText="维修费用" />
                                                <f:RenderField ColumnID="解决方案及计划" DataField="解决方案及计划" HeaderText="解决方案及计划" />
                                                <f:RenderField ColumnID="维修人" DataField="维修人" HeaderText="维修人" />
                                                <f:RenderField ColumnID="完成情况" DataField="完成情况" HeaderText="完成情况" />
                                                <f:RenderField ColumnID="原因分析" DataField="原因分析" HeaderText="原因分析" />
                                                <f:RenderField ColumnID="解决故障办法" DataField="解决故障办法" HeaderText="解决故障办法" />
                                            </Columns>
                                        </f:Grid>
                                    </Items>
                                </f:Tab>

                   
                          
                            </Tabs>
                        </f:TabStrip>

                
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>

                                <f:Button ID="btnClose" Icon="SystemClose" runat="server" Text="关闭"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>
   
    </form>


</body>
</html>
