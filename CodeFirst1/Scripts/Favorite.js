

$(document).ready(function () {
   
    $(document).on('click', '#add-del-favorive', function () {
        var $this = $(this);
        var id = $(this).attr('data-id-sp');
        var status = $(this).attr('data-status');

        $.ajax({

            url: '/Home/AddDeleteFavoriteProducts',
            type: 'post',
            dataType: 'html',
            data: { id: id, status: status },

            success: function (data) {
                if (data === '"ThemThanhCong"') {
                    $(`#img-${id}`).attr('src', '~/../image/heart.png');
                    $this.attr('data-status', 2).attr('title', 'Xóa khỏi sản phẩm yêu thích');
                    new Toast('Đã thêm vào sản phẩm yêu thích thành công !', 'warning', '15000');
                }
                else if (data === '"XoaThanhCong"') {
                    $(`#img-${id}`).attr('src', '~/../image/black-heart.jpg');
                    $this.attr('data-status', 1).attr('title', 'Thêm vào sản phẩm yêu thích');
                    new Toast('Đã xóa khỏi danh sách sản phẩm yêu thích !', 'done', '15000');
                }
                else if (data === '"ChuaDangNhap"') {
                    new Toast('Cần đăng nhập để thêm vào danh sách sản phẩm yêu thích!', 'warning', '15000');
                }
            },
            error: function () {
                new Toast('Cần đăng nhập để thêm vào danh sách sản phẩm yêu thích!', 'warning', '15000');
            }
        });
    });

});