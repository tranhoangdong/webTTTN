
$(document).ready(function () {

    $(document).on('click', '#cb-show', function () {

        if (document.getElementById("khung-chinh-sua-tt").style.display = "none") {
            document.getElementById("khung-chinh-sua-tt").style.display = "block";
        }
     
    });
    $('#khung-chinh-sua-tt').click(function () {
        var TaiKhoan = $('#tenngdung').val();
        if (TaiKhoan.length === 0) {
            $('#hien-thi-loi-ten').text('Tên người dùng không được trống');
        }
        else {
            $('#hien-thi-loi-ten').text('');
        }
        var Email = $('#emailngdung').val();
        var ma = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

        if (Email.length === 0) {
            $('#hien-thi-email').text('không được trống.');
        }
        else if (!ma.test(Email)) {
            $('#hien-thi-email').text('Sai định dạng . VD "phuongdeptrai@gmail.com"');
        }
        else {
            $('#hien-thi-email').text('');
        }
        var SDT = $('#sdtngdung').val();
        var ph = /^[0-9]+$/;
        if (SDT.length === 0) {
            $('#hien-thi-sdt').text('không được trống.');
        }
        else if (!ph.test(SDT)) {
            $('#hien-thi-sdt').text('Chỉ được nhập số');
        }

        else {
            $('#hien-thi-sdt').text('');
        }
        var DiaCHi = $('#diachingdung').val();
        if (DiaCHi.length === 0) {
            $('#hien-thi-loi-diachi').text(' không được trống.');
        }
        else {
            $('#hien-thi-loi-diachi').text('');
        }
    });
    $(document).on('click', '#bt-luuuu', function () {
        if ($('#hien-thi-loi-ten').text() === '' && $('#hien-thi-email').text() === '' && $('#hien-thi-sdt').text() === '' ) {
            $('#loitt').text('');
            var tk = $('#tenngdung').val();
            var em = $('#emailngdung').val();
            var sdt = $('#sdtngdung').val();
            var mk = $('#pass').val();

            $.ajax({
                url: '/Customer/SuaThongTinTaiKhoan',
                type: 'post',
                dataType: 'html',
                data: { tk: tk, em: em, sdt: sdt, mk: mk },

                success: function (data) {

                    if (data === '"ThanhCong"') {
                        new Toast('Thay đổi thông tin thành công!', 'done', '5000');
                        document.getElementById("khung-chinh-sua-tt").style.display = "none";
                        $('#ten-tk-hientai').text(tk);
                        $('#mail-hien-tai').text(em);
                        $('#sdt-hien-tai').text(sdt);
                    }
                    else {
                        alert('Xảy ra lỗi');
                    }
                },
                error: function (data) {
                    alert('Xảy ra lỗi');

                }
            });

        }
        else {
            $('#loitt').text('Lỗi ! Kiểm tra lại thông tin');
        }
    });
});