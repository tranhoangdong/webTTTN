$(document).ready(function () {
    $(document).on('click', '#dhkh', function () {
        var id = $(this).attr("data-iddh");
        $.ajax({
            url: '/Customer/OrderView',
            type: 'post',
            dataType: 'html',
            data: { id: id },
            success: function (Respone) {
                if (Respone.trim() === "") {
                    $('#x_content_Order1').html("Không tìm thấy đơn hàng");
                }
                else {
                    $('#x_content_Order1').html(Respone);
                }
            },
            error: function () {
                new Toast('Xảy ra lỗi', 'error', '8000');
            }
        });
    });
});