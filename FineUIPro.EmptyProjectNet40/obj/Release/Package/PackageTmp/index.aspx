<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.index" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="sourcefiles" content="~/消息中心/消息中心首页.aspx" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>PLM-资产全生命周期管理系统</title>
    <link href="~/res/css/index.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server"></f:PageManager>
        <f:Panel ID="Panel1" Layout="Region" CssClass="mainpanel" ShowBorder="false" ShowHeader="false" runat="server">
            <Items>
                <f:ContentPanel ID="topPanel" CssClass="topregion bgpanel" RegionPosition="Top" ShowBorder="false" ShowHeader="false" EnableCollapse="true" runat="server">
                    <div id="header" class="f-widget-header f-mainheader">
                        <table>
                            <tr>
                                <td>
                                    <f:Button runat="server" CssClass="icononlyaction" ID="btnHomePage" ToolTip="首页" IconAlign="Top" IconFont="_Home"
                                        EnablePostBack="false" EnableDefaultState="false" EnableDefaultCorner="false"
                                        OnClientClick="window.open('','_blank');">
                                    </f:Button>
                                    <a class="logo" href="./LoginTest.aspx" title="教育资产物联管理系统">教育资产物联管理系统
                                    </a>
                                </td>
                                <td style="text-align: right;">
                             
                                    <f:Button runat="server" CssClass="icontopaction themes" ID="btnThemeSelect" Text="消息中心(8)" IconAlign="Top" IconUrl="~/res/images/message.png"
                                        EnablePostBack="false" EnableDefaultState="false" EnableDefaultCorner="false" OnClientClick="openHelloFineUI();">
                                        <%--    <Listeners>
                                            <f:Listener Event="click" Handler="onThemeSelectClick" />
                                        </Listeners>--%>
                                    </f:Button>
                                    <f:Button runat="server" CssClass="userpicaction" Text="" ID="btn1" IconUrl="~/res/images/my_face_8012.png" IconAlign="Left"
                                        EnablePostBack="false" EnableDefaultState="false" EnableDefaultCorner="false">
                                        <Menu runat="server">
                                            <f:MenuButton Text="个人信息" IconFont="_User" EnablePostBack="false" runat="server">
                                                <Listeners>
                                                    <f:Listener Event="click" Handler="onUserProfileClick" />
                                                </Listeners>
                                            </f:MenuButton>
                                            <f:MenuSeparator runat="server"></f:MenuSeparator>
                                            <f:MenuButton Text="安全退出" IconFont="_SignOut" EnablePostBack="false" runat="server">
                                                <Listeners>
                                                    <f:Listener Event="click" Handler="onSignOutClick" />
                                                </Listeners>
                                            </f:MenuButton>
                                        </Menu>
                                    </f:Button>
                                </td>
                            </tr>
                        </table>
                    </div>
                </f:ContentPanel>
                <f:Panel ID="leftPanel" CssClass="leftregion bgpanel" Width="220px" ShowHeader="false" Title="菜单"
                    EnableCollapse="true" Layout="Fit" RegionPosition="Left"
                    RegionSplit="true" RegionSplitWidth="3" RegionSplitIcon="false" runat="server">
                    <Items>
                        <f:Tree runat="server" ShowBorder="false" ShowHeader="false" ID="treeMenu" EnableSingleClickExpand="true"
                            HeaderStyle="true" HideHScrollbar="true" HideVScrollbar="true" ExpanderToRight="true">
                            <Nodes>
                                <f:TreeNode Text="待办中心" IconUrl="res/icon/user_mature.png" NavigateUrl="School待办中心/代办业务.aspx">
                                </f:TreeNode>



                                <f:TreeNode Text="卡片管理" IconUrl="res/icon/SB1.png" NavigateUrl="School固定资产卡片/固定资产卡片明细webform.aspx">
                                    <%-- <f:TreeNode Text="设备全生命周期" NavigateUrl="PLM设备信息/设备台账.aspx" IconUrl="res/icon/QSMZQ1.png"></f:TreeNode>--%>
                                    <%--  <f:TreeNode Text="设备卡片" NavigateUrl="PLM设备信息/圆形进度条.aspx"></f:TreeNode>--%>
                                    <%--  <f:TreeNode Text="设备预防性维修" NavigateUrl="PLM设备信息/设备名称预防性维修.aspx"></f:TreeNode>--%>
                                    <%-- <f:TreeNode Text="设备文档" NavigateUrl="~/login.aspx"></f:TreeNode>--%>
                                </f:TreeNode>

                                <f:TreeNode Text="日常管理" IconUrl="res/icon/SBYX.png">

                                    <f:TreeNode Text="购置验收/入库" NavigateUrl="School购置验收/购置验收首页.aspx"></f:TreeNode>
                                    <f:TreeNode Text="资产报修" NavigateUrl="School资产报修/资产报修.aspx"></f:TreeNode>
                                    <f:TreeNode Text="原值变动" NavigateUrl="School原值变动/原值变动.aspx"></f:TreeNode>
                                    <f:TreeNode Text="资产处置" NavigateUrl="School资产处置/资产处置.aspx"></f:TreeNode>
                                    <f:TreeNode Text="资产借还" NavigateUrl="School资产借还借用/资产借还.aspx"></f:TreeNode>
                                    <f:TreeNode Text="资产交接" NavigateUrl="School资产交接/资产交接.aspx" IconUrl="res/icon/arrow_refresh_small.png"></f:TreeNode>
                                    <f:TreeNode Text="日期调整" NavigateUrl=""></f:TreeNode>
                                    <f:TreeNode Text="折旧管理" NavigateUrl=""></f:TreeNode>
                                </f:TreeNode>

                                <f:TreeNode Text="申报管理" IconUrl="res/icon/SBGC.png">
                                    <f:TreeNode Text="处置申报" NavigateUrl="School申报管理/处置申报.aspx"></f:TreeNode>
                                    <f:TreeNode Text="购置申报" NavigateUrl="School申报管理/购置申报.aspx"></f:TreeNode>
                                </f:TreeNode>

                                <f:TreeNode Text="清查盘点" IconUrl="res/icon/PD.png">
                                   <%-- <f:TreeNode Text="创建资产清查" NavigateUrl="资产清查盘点/创建清查盘点.aspx" IconUrl="res/icon/cjpd.png"></f:TreeNode>--%>
                                    <f:TreeNode Text="清查盘点" NavigateUrl="School清查盘点/清查盘点.aspx" IconUrl="res/icon/zcqc1.png"></f:TreeNode>
                                    <%--<f:TreeNode Text="已清查台账" NavigateUrl="资产清查盘点/查询已盘点数据.aspx" IconUrl="res/icon/wcpd.png"></f:TreeNode>
                                    <f:TreeNode Text="清查统计" NavigateUrl="资产清查盘点/盘点统计.aspx" IconUrl="res/icon/pdtj.png"></f:TreeNode>--%>
                                </f:TreeNode>

                                  <f:TreeNode Text="统计查询" IconUrl="res/icon/application_side_boxes.png">
                                    <f:TreeNode Text="购置验收查询" IconUrl="res/icon/application_cascade.png" NavigateUrl="School统计查询/购置验收统计查询.aspx"></f:TreeNode>
                                    <f:TreeNode Text="资产借还查询" IconUrl="res/icon/application_cascade.png" NavigateUrl="School统计查询/资产借还统计查询.aspx"></f:TreeNode>
                                    <f:TreeNode Text="维修记录查询" IconUrl="res/icon/application_cascade.png" NavigateUrl="School统计查询/资产维修统计查询.aspx"></f:TreeNode>
                                    <f:TreeNode Text="转移记录查询" IconUrl="res/icon/application_cascade.png" NavigateUrl="School统计查询/资产转移统计查询.aspx"></f:TreeNode>
                                    <f:TreeNode Text="原值变动查询" IconUrl="res/icon/application_cascade.png" NavigateUrl="School统计查询/价格变动统计查询.aspx"></f:TreeNode>
                                    <f:TreeNode Text="资产处置查询" IconUrl="res/icon/application_cascade.png" NavigateUrl="School统计查询/资产处置统计查询.aspx"></f:TreeNode>
                                    <f:TreeNode Text="申报记录查询" IconUrl="res/icon/application_cascade.png" NavigateUrl="School统计查询/申报记录统计查询.aspx"></f:TreeNode>
                                    <f:TreeNode Text="资产状态查询" IconUrl="res/icon/application_cascade.png" NavigateUrl="School统计查询/资产状态统计查询.aspx"></f:TreeNode>
                                    <f:TreeNode Text="资产交接查询" IconUrl="res/icon/application_cascade.png" NavigateUrl="School统计查询/资产交接统计查询.aspx"></f:TreeNode>
                                </f:TreeNode>

                                <f:TreeNode Text="报表管理" IconUrl="res/icon/SBGC.png">
                                    <f:TreeNode Text="结存分析" IconUrl="res/icon/shape_align_bottom.png" NavigateUrl="School报表管理/结存分析.aspx"></f:TreeNode>
                                    <f:TreeNode Text="增减分析" IconUrl="res/icon/shape_align_bottom.png" NavigateUrl="School报表管理/增减分析.aspx"></f:TreeNode>
                                    <f:TreeNode Text="折旧分析" IconUrl="res/icon/shape_align_bottom.png" NavigateUrl="School报表管理/折旧分析.aspx"></f:TreeNode>
                                </f:TreeNode>

                                <f:TreeNode Text="内控分析" IconUrl="res/icon/SBGC.png">
                                </f:TreeNode>

                                <f:TreeNode Text="数据看板" IconUrl="res/icon/ZCTJ.png">
                                    <f:TreeNode Text="设备统计分析" NavigateUrl="统计查询/设备统计分析.aspx"></f:TreeNode>
                                </f:TreeNode>

                            </Nodes>
                        </f:Tree>



                    </Items>
                </f:Panel>
                <f:Panel ID="mainPanel" CssClass="centerregion" ShowHeader="false" Layout="Fit" RegionPosition="Center" runat="server">
                    <Items>
                        <f:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server" ShowInkBar="true">
                            <Tabs>
                                <f:Tab ID="Tab1" Title="首页" BodyPadding="10px" AutoScroll="true" EnableIFrame="true" Icon="House" runat="server" IFrameUrl="统计查询/数据看板.aspx">
                                    <Content>
                                    </Content>
                                </f:Tab>
                            </Tabs>
                        </f:TabStrip>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>

        <f:Window ID="windowThemeRoller" Title="主题仓库" Hidden="true" EnableIFrame="true" IFrameUrl="./common/themes.aspx" ClearIFrameAfterClose="false"
            runat="server" IsModal="true" Width="1020px" Height="600px" EnableClose="true"
            EnableMaximize="true" EnableResize="true">
        </f:Window>
    </form>
    <script>
        var basePath = '<%= ResolveUrl("~/") %>';
        var treeMenuClientID = '<%= treeMenu.ClientID %>';
        var mainTabStripClientID = '<%= mainTabStrip.ClientID %>';
        var windowThemeRollerClientID = '<%= windowThemeRoller.ClientID %>';


        function openHelloFineUI() {
            parent.addExampleTab({
                id: 'hello_fineui_tab',
                iframeUrl: basePath + '消息中心/消息中心首页.aspx',
                title: '消息中心首页',
                icon: basePath + 'res/images/message.png',
                refreshWhenExist: true
            });
        }

        // 点击主题仓库
        function onThemeSelectClick(event) {
            F(windowThemeRollerClientID).show();
        }

        function onUserProfileClick(event) {
            F.alert('尚未实现');
        }

        function onSignOutClick(event) {
            F.alert('尚未实现');
        }
        function addExampleTab(tabOptions, actived) {

            if (typeof (tabOptions) === 'string') {
                tabOptions = {
                    id: arguments[0],
                    iframeUrl: arguments[1],
                    title: arguments[2],
                    icon: arguments[3],
                    createToolbar: arguments[4],
                    refreshWhenExist: arguments[5],
                    iconFont: arguments[6]
                };
            }

            F.addMainTab(F(mainTabStripClientID), tabOptions, actived);
        }

        // 页面控件初始化完毕后执行
        F.ready(function () {
            var treeMenu = F(treeMenuClientID);
            var mainTabStrip = F(mainTabStripClientID);
            if (!treeMenu) return;

            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // updateHash: 切换Tab时，是否更新地址栏Hash值（默认值：true）
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame（默认值：false）
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame（默认值：false）
            // maxTabCount: 最大允许打开的选项卡数量
            // maxTabMessage: 超过最大允许打开选项卡数量时的提示信息
            F.initTreeTabStrip(treeMenu, mainTabStrip, {
                maxTabCount: 10,
                maxTabMessage: '请先关闭一些选项卡（最多允许打开 10 个）！'
            });

        });
    </script>
</body>
</html>
