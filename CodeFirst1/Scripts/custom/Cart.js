$(document).ready(function () {
    $(document).on('click', '.AddToCart', function () {
        // show message
        var id = $(this).attr("data-idprodt");
        var sl = $("#soluongsp").val();
        var CategoryId = 1;
        $.ajax({
            url: '/Cart/ThemGioHang',
            type: 'post',
            dataType: 'html',
            data: { masanpham: id, sl: sl, CategoryId: CategoryId },
            success: function (data) {
                if (data === '"ThanhCong"') {
                    new Toast('Đã thêm vào giỏ hàng thành công', 'done', '8000');
                }
                else {
                    new Toast('Đã bị lỗi', 'warning', '8000');
                }
            },
            error: function () {
                new Toast('Xảy ra lỗi', 'error', '8000');
            }
        });

    });
    $(document).on('click', '.AddToCartAccessories', function () {
        // show message
        var id = $(this).attr("data-idsanpham");
        var sl = $(`#slsp-linhkien-${id}`).val();
        var CategoryId = 2;
        $.ajax({
            url: '/Cart/ThemGioHang',
            type: 'post',
            dataType: 'html',
            data: { masanpham: id, sl: sl, CategoryId: CategoryId},
            success: function (data) {
                if (data === '"ThanhCong"') {
                    new Toast('Đã thêm vào giỏ hàng thành công', 'done', '8000');
                }
                else {
                    new Toast('Đã bị lỗi', 'warning', '8000');
                }
            },
            error: function () {
                new Toast('Xảy ra lỗi', 'error', '8000');
            }
        });

    });

    $(document).on('click', '#dangkyvaluu', function (e) {

        if ($('#CustomerViewModel_Address').attr("aria-invalid") === 'false' && $('#CustomerViewModel_Name').attr("aria-invalid") === 'false' && $('#CustomerViewModel_Account').attr("aria-invalid") === 'false' && $('#CustomerViewModel_City').attr("aria-invalid") === 'false' && $('#CustomerViewModel_Email').attr("aria-invalid") === 'false'  && $('#ktratk').text() ==="") {
            var address = $('#CustomerViewModel_Address').val();
            var Name = $('#CustomerViewModel_Name').val();
            var Account = $('#CustomerViewModel_Account').val();
            var phone = $('#CustomerViewModel_Phone').val();
            var city = $('#CustomerViewModel_City').val();
            var email = $('#CustomerViewModel_Email').val();
            var currentdate = new Date();
            var total = $('#thanh-toan-hide').val();
            var status = 0;
            var resonCancel = "";
            var provisionalAmount = $('#tong-cong-hide').val();
            var pointsUse = $('#ip-dtl').val();
            var dateProcessing = "";
            var data = {
                Address: address,
                Phone: phone,
                City: city,
                Email: email,
                Name: Name,
                Account: Account,
                Total: total,
                Status: status,
                ResonCancel: resonCancel,
                CustomerId: "",
                ProvisionalAmount: provisionalAmount,
                PointsUse: pointsUse,
                DateProcessing: dateProcessing
            };
            $.ajax({
                url: '/Cart/DangKyValuuDonhang',
                type: 'POST',
                dataType: 'JSON',
                data: data,
                success: function (data) {
                    location.href = `/Cart/DatHangThanhCong?OrderId=${data.iddhh}&UserId=${data.iduser}`;
                },
                error: function () {

                }
            });
        }
        else {
            //debug
        }


    });


});