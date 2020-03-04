<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="图表分析.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.清查盘点.图标分析" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />


    <title>数据分析报表</title>
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="keywords" content="keyword1,keyword2,keyword3" />
    <meta http-equiv="description" content="This is my page" />
    <script type="text/javascript" src="../res/js/jquery-1.5.2.min.js"></script>
    <script type="text/javascript" src="../res/js/highcharts.js"></script>
    <script type="text/javascript" src="../res/js/theme/grid.js"></script>
</head>
<body>
    <div id="container">
    </div>
    <div id="container2">
    </div>
    <div id="container3">
    </div>
    <div id="container7">
    </div>
    <div id="container4">
    </div>
    <div id="container5">
    </div>
    <div id="container6">
    </div>

    <div id="container8">
    </div>
    <div id="container9">
    </div>
    <div id="container10">
    </div>
</body>
</html>
<script>
    var chart;
    $(document).ready(function () {
        //折线图示例
        //chart = new Highcharts.Chart({
        //    chart: {
        //        renderTo: 'container',          //放置图表的容器
        //        plotBackgroundColor: null,
        //        plotBorderWidth: null,
        //        defaultSeriesType: 'line'
        //    },
        //    title: {
        //        text: '设备报修曲线图展示'
        //    },
        //    subtitle: {
        //        text: '副标题'
        //    },
        //    xAxis: {//X轴数据
        //        categories: ['一月份', '二月份', '三月份', '四月份', '五月份', '六月份', '七月份', '八月份', '九月份', '十月份', '十一月份', '十二月份'],
        //        labels: {
        //            rotation: -45, //字体倾斜
        //            align: 'right',
        //            style: { font: 'normal 13px 宋体' }
        //        }
        //    },
        //    yAxis: {//Y轴显示文字
        //        title: {
        //            text: '产量/百万'
        //        }
        //    },
        //    tooltip: {
        //        enabled: true,
        //        formatter: function () {
        //            return '<b>' + this.x + '</b><br/>' + this.series.name + ': ' + Highcharts.numberFormat(this.y, 1);
        //        }
        //    },
        //    plotOptions: {
        //        line: {
        //            dataLabels: {
        //                enabled: true
        //            },
        //            enableMouseTracking: true//是否显示title
        //        }
        //    },
        //    series: [{
        //        name: '1车间',
        //        data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
        //    }, {
        //        name: '2车间',
        //        data: [4.0, 2.9, 5.5, 24.5, 18.4, 11.5, 35.2, 36.5, 23.3, 38.3, 23.9, 3.6]
        //    }, {
        //        name: '3车间',
        //        data: [14.0, 12.9, 15.5, 14.5, 28.4, 21.5, 15.2, 16.5, 13.3, 28.3, 13.9, 13.6]
        //    }, {
        //        name: '4车间',
        //        data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8]
        //    }]
        //});
        //柱状图图示例
        chart = new Highcharts.Chart({
            chart: {
                renderTo: 'container2',          //放置图表的容器
                plotBackgroundColor: null,
                plotBorderWidth: null,
                defaultSeriesType: 'column'   //图表类型line, spline, area, areaspline, column, bar, pie , scatter 
            },
            title: {
                text: '盘盈分析'
            },
            xAxis: {//X轴数据
                categories: ['四中', '二十四中', '三中', '六中'],
                labels: {
                    rotation: -45, //字体倾斜
                    align: 'right',
                    style: { font: 'normal 13px 宋体' }
                }
            },
            yAxis: {//Y轴显示文字
                title: {
                    text: '数值'
                }
            },
            tooltip: {
                enabled: true,
                formatter: function () {
                    return '<b>' + this.x + '</b><br/>' + this.series.name + ': ' + Highcharts.numberFormat(this.y, 1) + "数值";
                }
            },
            plotOptions: {
                column: {
                    dataLabels: {
                        enabled: true
                    },
                    enableMouseTracking: true//是否显示title
                }
            },
            series: [{
                name: '四中',
                data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6, 9.6, 9.6]
            }, {
                name: '二十四中',
                data: [4.0, 2.9, 5.5, 24.5, 18.4, 11.5, 35.2, 36.5, 23.3, 38.3, 23.9, 3.6, 9.6, 9.6]
            }, {
                name: '三中',
                data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8, 9.6, 9.6]
            }]
        });


        chart = new Highcharts.Chart({
            chart: {
                renderTo: 'container3',          //放置图表的容器
                plotBackgroundColor: null,
                plotBorderWidth: null,
                defaultSeriesType: 'column'   //图表类型line, spline, area, areaspline, column, bar, pie , scatter 
            },
            title: {
                text: '盘亏分析'
            },
            xAxis: {//X轴数据
                categories: ['**中', '**中', '**中', '**中', '**中', '**中', '**中', '**中', '**中', '**中', '**中', '**中', '**中', '**中'],
                labels: {
                    rotation: -45, //字体倾斜
                    align: 'right',
                    style: { font: 'normal 13px 宋体' }
                }
            },
            yAxis: {//Y轴显示文字
                title: {
                    text: '数值'
                }
            },
            tooltip: {
                enabled: true,
                formatter: function () {
                    return '<b>' + this.x + '</b><br/>' + this.series.name + ': ' + Highcharts.numberFormat(this.y, 1) + "数值";
                }
            },
            plotOptions: {
                column: {
                    dataLabels: {
                        enabled: true
                    },
                    enableMouseTracking: true//是否显示title
                }
            },
            series: [{
                name: '**中',
                data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6, 9.6, 9.6]
            }, {
                name: '**中',
                data: [4.0, 2.9, 5.5, 24.5, 18.4, 11.5, 35.2, 36.5, 23.3, 38.3, 23.9, 3.6, 9.6, 9.6]
            }, {
                name: '**中',
                data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8, 9.6, 9.6]
            }]
        });

        //饼状图图示例
        //chart = new Highcharts.Chart({
        //    chart: {
        //        renderTo: 'container3',          //放置图表的容器
        //        plotBackgroundColor: null,
        //        plotBorderWidth: null,
        //        defaultSeriesType: 'pie'   //图表类型line, spline, area, areaspline, column, bar, pie , scatter 
        //    },
        //    title: {
        //        text: '设备报修饼状图展示'
        //    },
        //    xAxis: {//X轴数据
        //        categories: ['一月份', '二月份', '三月份', '四月份', '五月份', '六月份', '七月份', '八月份', '九月份', '十月份', '十一月份', '十二月份', '十三月份', '十四月份'],
        //        labels: {
        //            rotation: -45, //字体倾斜
        //            align: 'right',
        //            style: { font: 'normal 13px 宋体' }
        //        }
        //    },
        //    yAxis: {//Y轴显示文字
        //        title: {
        //            text: '产量/百万'
        //        }
        //    },
        //    tooltip: {
        //        enabled: true,
        //        formatter: function () {
        //            return '<b>' + this.x + '</b><br/>' + this.series.name + ': ' + Highcharts.numberFormat(this.y, 1) + "百万";
        //        }
        //    },
        //    plotOptions: {
        //        column: {
        //            dataLabels: {
        //                enabled: true
        //            },
        //            enableMouseTracking: true//是否显示title
        //        }
        //    },
        //    series: [{
        //        data: [
        //             ['一车间', 45.0],
        //             ['二车间', 26.8],
        //             { name: '三车间', y: 12.8, sliced: true, selected: true }, //选中状态
        //             ['四车间', 8.5],
        //             ['五车间', 6.2],
        //             ['六车间', 0.7]
        //        ]
        //    }]
        //});
        //spline 平滑曲线图示例
        //chart = new Highcharts.Chart({
        //    chart: {
        //        renderTo: 'container4',          //放置图表的容器
        //        plotBackgroundColor: null,
        //        plotBorderWidth: null,
        //        defaultSeriesType: 'spline'   //图表类型line, spline, area, areaspline, column, bar, pie , scatter 
        //    },
        //    title: {
        //        text: '设备报修平滑曲线展示'
        //    },
        //    xAxis: {//X轴数据
        //        categories: ['一月份', '二月份', '三月份', '四月份', '五月份', '六月份', '七月份', '八月份', '九月份', '十月份', '十一月份', '十二月份', '十三月份', '十四月份'],
        //        labels: {
        //            rotation: -45, //字体倾斜
        //            align: 'right',
        //            style: { font: 'normal 13px 宋体' }
        //        }
        //    },
        //    yAxis: {//Y轴显示文字
        //        title: {
        //            text: '产量/百万'
        //        }
        //    },
        //    tooltip: {
        //        enabled: true,
        //        formatter: function () {
        //            return '<b>' + this.x + '</b><br/>' + this.series.name + ': ' + Highcharts.numberFormat(this.y, 1) + "百万";
        //        }
        //    },
        //    plotOptions: {
        //        column: {
        //            dataLabels: {
        //                enabled: true
        //            },
        //            enableMouseTracking: true//是否显示title
        //        }
        //    },
        //    series: [{
        //        name: '一车间',
        //        data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6, 9.6, 9.6]
        //    }, {
        //        name: '二车间',
        //        data: [4.0, 2.9, 5.5, 24.5, 18.4, 11.5, 35.2, 36.5, 23.3, 38.3, 23.9, 3.6, 9.6, 9.6]
        //    }, {
        //        name: '三车间',
        //        data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8, 9.6, 9.6]
        //    }]
        //});
        //area 填充图示例
        //chart = new Highcharts.Chart({
        //    chart: {
        //        renderTo: 'container5',          //放置图表的容器
        //        plotBackgroundColor: null,
        //        plotBorderWidth: null,
        //        defaultSeriesType: 'area'   //图表类型line, spline, area, areaspline, column, bar, pie , scatter 
        //    },
        //    title: {
        //        text: '设备报修填充图'
        //    },
        //    xAxis: {//X轴数据
        //        categories: ['一月份', '二月份', '三月份', '四月份', '五月份', '六月份', '七月份', '八月份', '九月份', '十月份', '十一月份', '十二月份', '十三月份', '十四月份'],
        //        labels: {
        //            rotation: -45, //字体倾斜
        //            align: 'right',
        //            style: { font: 'normal 13px 宋体' }
        //        }
        //    },
        //    yAxis: {//Y轴显示文字
        //        title: {
        //            text: '产量/百万'
        //        }
        //    },
        //    tooltip: {
        //        enabled: true,
        //        formatter: function () {
        //            return '<b>' + this.x + '</b><br/>' + this.series.name + ': ' + Highcharts.numberFormat(this.y, 1) + "百万";
        //        }
        //    },
        //    plotOptions: {
        //        column: {
        //            dataLabels: {
        //                enabled: true
        //            },
        //            enableMouseTracking: true//是否显示title
        //        }
        //    },
        //    series: [{
        //        name: '一车间',
        //        data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6, 9.6, 9.6]
        //    }, {
        //        name: '二车间',
        //        data: [4.0, 2.9, 5.5, 24.5, 18.4, 11.5, 35.2, 36.5, 23.3, 38.3, 23.9, 3.6, 9.6, 9.6]
        //    }, {
        //        name: '三车间',
        //        data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8, 9.6, 9.6]
        //    }]
        //});
        //areaspline 填充图示例
        //chart = new Highcharts.Chart({
        //    chart: {
        //        renderTo: 'container6',          //放置图表的容器
        //        plotBackgroundColor: null,
        //        plotBorderWidth: null,
        //        defaultSeriesType: 'areaspline'   //图表类型line, spline, area, areaspline, column, bar, pie , scatter 
        //    },
        //    title: {
        //        text: '设备报修填充图'
        //    },
        //    xAxis: {//X轴数据
        //        categories: ['一月份', '二月份', '三月份', '四月份', '五月份', '六月份', '七月份', '八月份', '九月份', '十月份', '十一月份', '十二月份', '十三月份', '十四月份'],
        //        labels: {
        //            rotation: -45, //字体倾斜
        //            align: 'right',
        //            style: { font: 'normal 13px 宋体' }
        //        }
        //    },
        //    yAxis: {//Y轴显示文字
        //        title: {
        //            text: '产量/百万'
        //        }
        //    },
        //    tooltip: {
        //        enabled: true,
        //        formatter: function () {
        //            return '<b>' + this.x + '</b><br/>' + this.series.name + ': ' + Highcharts.numberFormat(this.y, 1) + "百万";
        //        }
        //    },
        //    plotOptions: {
        //        column: {
        //            dataLabels: {
        //                enabled: true
        //            },
        //            enableMouseTracking: true//是否显示title
        //        }
        //    },
        //    series: [{
        //        name: '一车间',
        //        data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6, 9.6, 9.6]
        //    }, {
        //        name: '二车间',
        //        data: [4.0, 2.9, 5.5, 24.5, 18.4, 11.5, 35.2, 36.5, 23.3, 38.3, 23.9, 3.6, 9.6, 9.6]
        //    }, {
        //        name: '三车间',
        //        data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8, 9.6, 9.6]
        //    }]
        //});
        //bar 图示例
        //chart = new Highcharts.Chart({
        //    chart: {
        //        renderTo: 'container7',          //放置图表的容器
        //        plotBackgroundColor: null,
        //        plotBorderWidth: null,
        //        defaultSeriesType: 'bar'   //图表类型line, spline, area, areaspline, column, bar, pie , scatter 
        //    },
        //    title: {
        //        text: '设备报修增长图'
        //    },
        //    xAxis: {//X轴数据
        //        categories: ['一月份', '二月份', '三月份', '四月份', '五月份', '六月份', '七月份', '八月份', '九月份', '十月份', '十一月份', '十二月份', '十三月份', '十四月份'],
        //        labels: {
        //            rotation: -45, //字体倾斜
        //            align: 'right',
        //            style: { font: 'normal 13px 宋体' }
        //        }
        //    },
        //    yAxis: {//Y轴显示文字
        //        title: {
        //            text: '产量/百万'
        //        }
        //    },
        //    tooltip: {
        //        enabled: true,
        //        formatter: function () {
        //            return '<b>' + this.x + '</b><br/>' + this.series.name + ': ' + Highcharts.numberFormat(this.y, 1) + "百万";
        //        }
        //    },
        //    plotOptions: {
        //        column: {
        //            dataLabels: {
        //                enabled: true
        //            },
        //            enableMouseTracking: true//是否显示title
        //        }
        //    },
        //    series: [{
        //        name: '一车间',
        //        data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6, 9.6, 9.6]
        //    }, {
        //        name: '二车间',
        //        data: [4.0, 2.9, 5.5, 24.5, 18.4, 11.5, 35.2, 36.5, 23.3, 38.3, 23.9, 3.6, 9.6, 9.6]
        //    }, {
        //        name: '三车间',
        //        data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8, 9.6, 9.6]
        //    }]
        //});
        //scatter 点位图示例
        //chart = new Highcharts.Chart({
        //    chart: {
        //        renderTo: 'container8',          //放置图表的容器
        //        plotBackgroundColor: null,
        //        plotBorderWidth: null,
        //        defaultSeriesType: 'scatter'   //图表类型line, spline, area, areaspline, column, bar, pie , scatter 
        //    },
        //    title: {
        //        text: '设备报修点位图'
        //    },
        //    xAxis: {//X轴数据
        //        categories: ['一月份', '二月份', '三月份', '四月份', '五月份', '六月份', '七月份', '八月份', '九月份', '十月份', '十一月份', '十二月份', '十三月份', '十四月份'],
        //        labels: {
        //            rotation: -45, //字体倾斜
        //            align: 'right',
        //            style: { font: 'normal 13px 宋体' }
        //        }
        //    },
        //    yAxis: {//Y轴显示文字
        //        title: {
        //            text: '产量/百万'
        //        }
        //    },
        //    tooltip: {
        //        enabled: true,
        //        formatter: function () {
        //            return '<b>' + this.x + '</b><br/>' + this.series.name + ': ' + Highcharts.numberFormat(this.y, 1) + "百万";
        //        }
        //    },
        //    plotOptions: {
        //        column: {
        //            dataLabels: {
        //                enabled: true
        //            },
        //            enableMouseTracking: true//是否显示title
        //        }
        //    },
        //    series: [{
        //        name: '一车间',
        //        data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6, 9.6, 9.6]
        //    }, {
        //        name: '二车间',
        //        data: [4.0, 2.9, 5.5, 24.5, 18.4, 11.5, 35.2, 36.5, 23.3, 38.3, 23.9, 3.6, 9.6, 9.6]
        //    }, {
        //        name: '三车间',
        //        data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8, 9.6, 9.6]
        //    }]
        //});
    });
</script>
