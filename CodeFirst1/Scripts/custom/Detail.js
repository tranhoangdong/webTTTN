$(document).ready(function () {

    $(document).on('click', '#detail', function () {
        var id = $(this).attr("data-idproduct");
        $.ajax({
            url: '/Home/Detail',
            type: 'get',
            dataType: 'html',
            data: { id: id },
            success: function () {
            },
            error: function () {
                alert('Lỗi');
            }
        });
    });

    $(document).on('click', '#dat-hang', function () {
        var user = $("#dat-hang").data('value');
        if (user === '') {
            var newlocation = `/Cart/CheckOut`;
            location.href = `/Login/Index?newLocation=${newlocation}`;
        }
        else {
            location.href = `/Cart/CheckOut`;
        }
    });

    $(document).on('click', '#xoa-khoi-gio-hang', function () {
        var masanpham = $(this).attr("data-idsp");
        var categoryId = $(this).attr("data-CategoryId-lk");
        var name = $(this).attr("data-tensp");
        $.ajax({
            url: '/Cart/Xoagiohang',
            type: 'POST',
            dataType: 'JSON',
            data: { masanpham: masanpham, categoryId: categoryId },
            success: function (data) {
                $(`#modalDelele-${masanpham}-${categoryId}`).modal('hide');
                if (data.tongSL === 0) {
                    $('#td-row').html(' <div class="gio-hang-rong"> <h3>Không có sản phẩm nào trong giỏ hàng</h3>  <br /><a class="btn btn-success" href="~/Home/">Tiếp tục mua sắm</a>  </div>');
                }
                else {
                    $(`#td-${masanpham}-${categoryId}`).fadeOut();
                    $('#tong-so-luong').text(data.tongSL);
                    $('#tong-tien').text(data.toTal);
                }
                new Toast('Đã xóa ' + name+ ' ra khỏi giỏ hàng' , 'done', '5000');
            },
            error: function () {
                alert('Lỗi');
            }
        });
    });

    $(document).on('click', '#capnhat-giohang', function () {
        var masanpham = $(this).attr("data-idprd");
        var categoryId = $(this).attr("data-CategoryId");
        var txtsoluong = $(`#qty-${masanpham}-${categoryId}`).val();
        var name = $(this).attr("data-nameprd");
        $.ajax({
            url: '/Cart/CapNhatgiohang',
            type: 'POST',
            dataType: 'JSON',
            data: { masanpham: masanpham, txtsoluong: txtsoluong, categoryId: categoryId },
         success: function (data) {
             $(`#into-money-${masanpham}-${categoryId}`).text(data.thanhtien);
             $('#tong-so-luong').text(data.tongSL);
                $('#tong-tien').text(data.toTal);
                new Toast('Số lượng của máy tính ' + name + ' đã thay đổi thành ' + txtsoluong, 'done', '5000');
            },
            error: function () {
                alert('Lỗi');
            }
        });
    });

    $(document).on('submit', '#form-comment', function (e) {
        e.preventDefault();
    });
    $(document).on('submit', '#form-checkout', function (e) {
        e.preventDefault();
    });
    //Lấy thông tin để lưu vào đơn hàng
    $(document).on('click', '#checkout-xacnhan', function (e) {

        if ($('#CustomerViewModel_Address').attr("aria-invalid") === 'false') {
            var idUser = $('#checkout-xacnhan').data('value');
            var address = $('#CustomerViewModel_Address').val();
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
                Total: total,
                Status: status,
                ResonCancel: resonCancel,
                CustomerId: idUser,
                ProvisionalAmount: provisionalAmount,
                PointsUse: pointsUse,
                DateProcessing: dateProcessing
            };
            $.ajax({
                url: '/Cart/Luudonhang',
                type: 'POST',
                dataType: 'JSON',
                data: data,
                success: function (data) {
                    location.href = `/Cart/DatHangThanhCong?OrderId=${data}&UserId=${idUser}`;
                },
                error: function () {

                }
            });
        }
        else {
            //debug
        }
                  

    });

 
    $("#CustomerViewModel_Account").keypress(function () {
        var tk = $('#CustomerViewModel_Account').val();
        $.ajax({
            url: '/Cart/KiemTraTK',
            type: 'POST',
            dataType: 'JSON',
            data: { tk:tk},
            success: function (data) {
                $('#ktratk').text(data);
            },
            error: function () {
                alert('Lỗi');
            }
        });
        });

    $(document).on('click', '#submit-comment', function (e) {
            var id = $(this).attr("data-idproduct");
            var currentdate = new Date();
        var datetime = currentdate.getDate() + "/"
            + (currentdate.getMonth() + 1) + "/"
            + currentdate.getFullYear() + " -- "
            + currentdate.getHours() + ":"
            + currentdate.getMinutes() + ":"
            + currentdate.getSeconds();
        var phone = "";
        var content = "";
        var email = "";
            var user = $("#submit-comment").data('value');
            if (user === '') {
                if ($("#Comment_Name").attr("aria-invalid") === 'false' && $("#Comment_Email").attr("aria-invalid") === 'false' && $("#Comment_Phone").attr("aria-invalid") === 'false' && $("#Comment_Content").attr("aria-invalid") === 'false') {
                    user = document.getElementById('Comment_Name').value;
                    phone = document.getElementById('Comment_Phone').value;
                    email = document.getElementById('Comment_Email').value;
                    content = document.getElementById('Comment_Content').value;
                    var dataPost = {
                        ProductId: id,
                        Name: user,
                        Email: email,
                        Content: content,
                        Phone: phone
                    };
                    $.ajax({
                        url: '/Home/Comment',
                        type: 'POST',
                        dataType: 'html',
                        data: dataPost,
                        success: function () {
                            var div = '<div class="single-blog-replay" id="cmt-prepend"> <div class="replay-img">  <a href="#"><img src="/image/user.png" alt="" style="width:70px; height:70px;"></a> </div> <div class="replay-info-wrapper"> <div class="replay-info">     <div class="replay-name-date"> <h5><a href="#" id="cmt-name"></a></h5> <span id="cmt-time"></span>  </div>   <div class="replay-btn"> <a href="#">Reply</a> </div> </div>  <p id="cmt-content"></p> </div> </div>';
                            // Tim #p
                            $('#list-comment').prepend(div);
                            $('#cmt-prepend').show();
                            $('#cmt-name').text(user);
                            $('#cmt-time').text(datetime);
                            $('#cmt-content').text(content);
                            new Toast('Đã gửi bình luận', 'done', '15000');
                        },
                        error: function () {
                            alert('Đã xảy ra lỗi');
                        }
                    });
                }
                else {
                    new Toast('Hiện chưa đủ thông tin', 'done', '15000');
                }
            }
            else {
                if ($("#Comment_Content").attr("aria-invalid") === 'false') {
                    user = $("#submit-comment").data('value');
                    phone = "";
                    email = "";
                    content = document.getElementById('Comment_Content').value;
                    var Data = {
                        ProductId: id,
                        Name: user,
                        Email: email,
                        Content: content,
                        Phone: phone
                    };
                    $.ajax({
                        url: '/Home/Comment',
                        type: 'POST',
                        dataType: 'html',
                        data: Data,
                        success: function () {
                            var div = '<div class="single-blog-replay" id="cmt-prepend"> <div class="replay-img">  <a href="#"><img src="/image/user.png" alt="" style="width:70px; height:70px;"></a> </div> <div class="replay-info-wrapper"> <div class="replay-info">     <div class="replay-name-date"> <h5><a href="#" id="cmt-name"></a></h5> <span id="cmt-time"></span>  </div>   <div class="replay-btn"> <a href="#">Reply</a> </div> </div>  <p id="cmt-content"></p> </div> </div>';
                            // Tim #p

                            $('#list-comment').prepend(div);
                            $('#cmt-prepend').show();
                            $('#cmt-name').text(user);
                            $('#cmt-time').text(datetime);
                            $('#cmt-content').text(content);
                            new Toast('Đã gửi bình luận', 'done', '15000');
                        },
                        error: function () {
                            alert('Đã xảy ra lỗi');
                        }
                    });
                }
                else {;
                    new Toast('Hiện chưa đủ thông tin', 'done', '15000');
                }
            }   
    });

 

    function test() {
        alert('aloo');
    }

// JS cho Xử Lý Đơn Hàng Start
    $('#show-info').on('click', function () {
        $('#info-km').slideToggle(900);
    });
   
    $(".cart-plus-minus-box").keypress(function (evt) {
        evt.preventDefault();
    });
    $(".sl-sanpham-chitiethoadon").keypress(function (evt) {
        evt.preventDefault();
    });
    $(".so-luong-san-pham-don-hang").keypress(function (evt) {
        evt.preventDefault();
    });
    $("#ip-dtl").keypress(function (evt) {
        evt.preventDefault();
    });
    $("#soluongsp").keypress(function (evt) {
        evt.preventDefault();
    });

   //cập nhật "thanh toán" khi F
    var thanhtoan = $('#tong-tien-hide').val() - $('#doi-tien-hide').val();
    $('#thanh-toan-hide').val(thanhtoan);
    var output = parseInt(thanhtoan).toLocaleString();
        $('#thanh-toan').text(output);
      $(document).on('keyup mouseup', '#ip-dtl', function () {
        $('#diem-tl').text(parseInt($('#ip-dtl').val()).toLocaleString());
        //500 điểm -> 100.000 đ
        var a = ($('#ip-dtl').val() / 500) * 100000;
        $('#doi-tien').text(parseInt(a).toLocaleString());
        // sửa "Thanh toán"
          $('#thanh-toan').text(parseInt($('#tong-tien-hide').val() - a).toLocaleString());
          $('#thanh-toan-hide').val($('#tong-tien-hide').val() - a);
    });
    // tính điểm tối đa có thể sử dụng cho đơn hàng
    var diemNguoiDung = $('#tong-dtl-hide').val();
    //Không được sử dụng điểm tích lũy để thanh toán hết tiền của đơn hàng
    var diemToiDaCoTheSuDung = (($('#tong-tien-hide').val() * 500) / 100000) - 500;
    var diemMax = diemNguoiDung < diemToiDaCoTheSuDung ? diemNguoiDung : diemToiDaCoTheSuDung;
    // Gán gtri Max cho input Chọn điểm 
    $('#ip-dtl').attr('Max', diemMax);
    $('#diem-max').text(parseInt(diemMax).toLocaleString());
// JS cho Xử Lý Đơn Hàng  End

 
});
