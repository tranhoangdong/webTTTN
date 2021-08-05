

$(document).ready(function () {
    $(document).on('click', '#dh', function () {
        var id = $(this).attr("data-iddh");
        $.ajax({
            url: '/User/OrderView',
            type: 'post',
            dataType: 'html',
            data: { id: id },
            success: function (Respone) {
                if (Respone.trim() === "") {
                    $('#x_content_Order').html("Không tìm thấy đơn hàng");
                }
                else {
                    $('#x_content_Order').html(Respone);
                }
            },
            error: function () {
                new Toast('Xảy ra lỗi', 'error', '8000');
            }
        });
    });
});



$(document).ready(function () {

    $(document).on('click', '#btnEditEmaill', function () {

        var email = $('#txtemail').val();
        var id = $(this).attr("data-idemail");
        $.ajax({
            url: '/User/Edit_email',
            type: 'post',
            dataType: 'html',
            data: { email: email, id: id },
            success: function (data) {
                if (data === '"ThanhCong"') {
                    $('#modalEmail').modal('hide');
                    new Toast('Cập nhật thành công!', 'done', '15000');
                    $('#email-id').text(email);
                }
                else {
                    $('#modalEmail').modal('hide');
                    new Toast('Xảy ra lỗi!', 'done', '15000');
                }

            },
            error: function () {
                //debuger
            }
        });
    });
    $(document).on('click', '#btnEDitDiaChi', function () {
        var Phone = $('#Phone1').val();
        var DiaChi = $('#DiaChi1').val();
        var ThanhPho = $('#ThanhPho1').val();
        var id = $(this).attr("data-idDiaChi");
        $.ajax({
            url: '/User/Edit_DiaChi',
            type: 'post',
            dataType: 'html',
            data: { Phone: Phone, DiaChi: DiaChi, ThanhPho: ThanhPho, id: id },
            success: function (data) {
                if (data === '"ThanhCong"') {
                    $('#modalDiaChi').modal('hide');
                    new Toast('Cập nhật thành công', 'done', '15000');
                    //new Toast('Cập nhật thành công!', 'done', '15000');
                    $('#phone-id').text(Phone);
                    $('#Address-id').text("Địa Chỉ: " + DiaChi);
                    $('#thanhpho-id').text("Thành Phố: " + ThanhPho);
                }
                else {
                    $('#modalDiaChi').modal('hide');
                    new Toast('Xảy ra lỗi', 'done', '15000');
                }

            },
            error: function () {

                //debuger
            }
        });
    });

    $(document).on('click', '#xac-nhan-thanh-toan', function () {
        var id = $(this).attr("data-idxacnhan");
        $.ajax({
            url: '/QuanLyDonDatHang/XuatPhieuGiaoHang',
            type: 'post',
            dataType: 'html',
            data: { id: id },
            success: function () {
                window.location.reload();
            },
            error: function () {
                //debuger
            }
        });
    });

    $(document).on('click', '#btnCancelOrder', function () {

        var id = $(this).attr("data-idCancel");
        var LyDo = $('#iputLydo').val();
        $.ajax({
            url: '/User/HuyDatHang',
            type: 'post',
            dataType: 'html',
            data: { id: id, LyDo: LyDo },
            success: function (data) {
                if (data === '"Xong"') {
                    Toastify({
                        text: "Cập nhật thành công",
                        duration: 3000
                    }).showToast();

                    $('#modalCancel').modal('hide');
                    $('#LyDoHuyDonHang').text('Lý do: ' + LyDo);
                    window.location.reload();
                }
                else {
                    Toastify({
                        text: "Xảy ra lỗi!!!",
                        duration: 3000
                    }).showToast();
                }
            },
            error: function () {
                //debuger
            }
        });
    });

    $(".UpdateProduct").click(function () {

        var idsp = $(this).attr("data-idsp");
        var idhd = $(this).attr("data-idhd");
        var idCategory = $(this).attr("data-CategoryId");

        var sl = $('#ip-' + idsp + '-' + idCategory).val();

        $.post("/User/CapNhatSoLuongSanPhamChiTietHoaDon", { "idhd": idhd, "idsp": idsp, "sl": sl, "idCategory": idCategory },
            function (data) {

                Toastify({
                    text: 'Bạn đã cập nhật số lượng ' + data.TenSP + ' thành ' + data.SoLuongDatHang + '',
                    duration: 15000
                }).showToast();
                $('.sldh-' + data.IDSP + '-' + data.CategoryId).text(data.SoLuongDatHang);
                $('.sl-' + data.IDSP + '-' + data.CategoryId).text(data.SoLuongDatHang);
                $('.tong-noi-sp-' + data.IDSP + '-' + data.CategoryId).text(data.TongGiaMoiSanPham);
                $('.tong-gtsp').text(data.TongGiaTriDonHang);
                $('.giatri-tamtinh').text(data.TamTinh);
                $('.tong-gtsp1').text(data.TongGiaTriDonHang);
            });

    });

    $(".DeleteProduct").click(function () {
        var idsp = $(this).attr("data-idsanpham");
        var idhd = $(this).attr("data-iddonhang");
        var IdCategory = $(this).attr("data-idCategory");
        $.post("/User/XoaSanPhamTrongChiTietHoaDon", { "idhd": idhd, "idsp": idsp, "IdCategory": IdCategory },
            function (data) {

                Toastify({
                    text: 'Bạn đã xóa ' + data.TenSanPham + ' ra khỏi hóa đơn',
                    duration: 15000
                }).showToast();
                $('.ct-sp-' + data.IDSanPham + '-' + data.idCategorysp).fadeOut('slow');
                $('.giatri-tamtinh').text(data.TamTinh);
                $('.tong-gtsp').text(data.TongTien);
                $('.tong-gtsp1').text(data.TongTien);
            });

    });

    $(document).on('click', '#xac-nhan-thanh-toan', function () {
        var id = $(this).attr("data-idxacnhan");
        $.ajax({
            url: '/User/XuLyDonHang',
            type: 'post',
            dataType: 'html',
            data: { id: id },
            success: function (data) {
                if (data === '"Xong"') {
                    window.location.reload();
                }
                else {
                    new Toast('Xảy ra lỗi', 'done', '15000');
                }
            },
            error: function () {
                //debuger
            }
        });
    });

    $(document).on('click', '#thanh-toan-don-hang', function () {
        var id = $(this).attr("data-idxacnhan");
        $.ajax({
            url: '/User/DongYThanhToan',
            type: 'post',
            dataType: 'html',
            data: { id: id },
            success: function (data) {
                if (data === '"Xong"') {
                    window.location.reload();
                }
                else {
                    new Toast('Xảy ra lỗi', 'done', '15000');
                }
            },
            error: function () {
                //debuger
            }
        });
    });
});


