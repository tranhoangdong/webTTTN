$(document).ready(function () {
    $.getJSON("/User/laysoluongton", function (data) {
        var Tensp = [];
        var Soluongton = [];
        for (var i = 0; i < data.length; i++) {
            Tensp.push(data[i].tensp);
            Soluongton.push(data[i].soluong);
        }
        Highcharts.chart('container', {
            chart: {
                type: 'column'
            },
            title: {
                text: 'Biểu đồ thống kê số lượng sản phẩm tồn'
            },
            subtitle: {
                text: 'Trung tâm tin hoc Hoàng Phương'
            },
            xAxis: {
                categories: Tensp
            },
            yAxis: {
                title: {
                    text: 'Số lượng'
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
                name: 'Số lượng (Đơn vị: cái)',
                data: Soluongton
            },]
        });
    });
});