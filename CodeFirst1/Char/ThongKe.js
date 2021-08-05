$(document).ready(function () {
    $.getJSON("/User/GetData", function (data) {
        var Names = []
        var Qts = []
        for (var i = 0; i < data.length; i++) {
            Names.push(data[i].name)
            Qts.push(data[i].count)

        }
        Highcharts.chart('container', {
            chart: {
                type: 'line'
            },
            title: {
                text: 'Biểu đồ thống kê theo số lượng sản phẩm đã bán'
            },
            subtitle: {
                text: 'Source: WorldClimate.com'
            },
            xAxis: {
                categories: Names
            },
            yAxis: {
                title: {
                    text: 'Đơn vị (cái)'
                }
            },
            plotOptions: {
                line: {
                    dataLabels: {
                        enabled: true
                    },
                    enableMouseTracking: false
                }
            },
            series: [{
                name: 'Laptop',
                data: Qts
            }]
        });
    });
});