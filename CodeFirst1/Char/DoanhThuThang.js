
$(document).ready(function () {
    $.getJSON("/User/TKDoanhThuThang", function (data) {

        var Thang = [];
        var Tien = [];

        for (var i = 0; i < data.thang.length; i++) {
            Thang.push(data.thang[i])
            Tien.push(data.tien[i])
        }

        Highcharts.chart('container', {
            chart: {
                type: 'column',
                options3d: {
                    enabled: true,
                    alpha: 10,
                    beta: 25,
                    depth: 70
                }
            },
            title: {
                text: '3D chart with null values'
            },
            subtitle: {
                text: 'Notice the difference between a 0 value and a null point'
            },
            plotOptions: {
                column: {
                    depth: 25
                }
            },
            xAxis: {
                categories: Thang,
                labels: {
                    skew3d: true,
                    style: {
                        fontSize: '16px'
                    }
                }
            },
            yAxis: {
                title: {
                    text: null
                }
            },
            series: [{
                name: 'Điện thoại',
                data: Tien
            }]
        });
    });
});