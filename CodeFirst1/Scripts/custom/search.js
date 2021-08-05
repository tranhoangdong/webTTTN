
$(document).ready(function () {
    $("#view-resulf").click(function () {
        var manufacture = [];
        var Hang = document.getElementsByName('manufacture');
        for (var i = 0; i < Hang.length; i++) {
            if (Hang[i].checked === true) {
                manufacture.push(Hang[i].value);
            }
        }
        var Gia= "";
        var danhSach = document.getElementsByName('gia');
        for (var j = 0; j < danhSach.length; j++) {
            if (danhSach[j].checked === true) {
                Gia = danhSach[j].value;
            }   
        }
        var priceMin = 0;
        var priceMax = 0;
        if (Gia === "0") {
            priceMin = 0;
            priceMax = 100000000000000;
        }
        if (Gia === "1") {
            priceMin = 0;
            priceMax = 2000000;
        }
        if (Gia === "2") {
            priceMin = 2000000;
            priceMax = 10000000;
        }
        if (Gia === "3") {
            priceMin = 10000000;
            priceMax = 20000000;
        }
        if (Gia === "4") {
            priceMin = 20000000;
            priceMax = 100000000000000;
        }
        var a = "js";
        //var sliderrange = $('#slider-range');
        //var priceMin = sliderrange.slider("values", 0);
        //var priceMax = sliderrange.slider("values", 1);
        var data1 = {
            Manufacture: manufacture,
            giaMin: priceMin,
            giaMax: priceMax,
            a:a
        };
        $.ajax({
            url: '/Home/SearchProduct',
            type: 'POST',
            dataType: 'html',
            data: data1 ,
            success: function (response) {
                if (response.trim() === "") {
                    $('#div_product').html("Không tìm thấy sản phẩm bạn cần tìm!");
                }
                else {
                    $('#div_product').html(response);
                }
             },
            error: function () {
                alert('Lỗi');
            }
        });
    });
});