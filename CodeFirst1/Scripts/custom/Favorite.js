

$(document).ready(function () {
   
    $(document).on('click', '.add-del-favorive', function () {
        var $this = $(this);
        var id = $(this).attr('data-id-sp');
        var status = $(this).attr('data-status');
        var CategoryId = $(this).attr('data-idCategory');
        $.ajax({
            url: '/Home/AddDeleteFavoriteProducts',
            type: 'post',
            dataType: 'html',
            data: { id: id, status: status, IdCategrory: CategoryId },
            success: function (data) {
                if (data === '"ThemThanhCong"') {
                    $(`#img-${id}`).attr('src', '../../image/heart.png');
                    $this.attr('data-status', 2).attr('title', 'Xóa khỏi sản phẩm yêu thích');
                    new Toast('Thêm thành công!', 'done', '15000');
                }
                else if (data === '"XoaThanhCong"') {
                    $(`#img-${id}`).attr('src', '../../image/black-heart.jpg');
                    $this.attr('data-status', 1).attr('title', 'Thêm vào sản phẩm yêu thích');
                    new Toast('Xóa thành công !', 'warning', '15000');
                }
           
                else if (data === '"ChuaDangNhap"') {
                    new Toast('Bạn cần đăng nhập!', 'warning', '15000');
                }
            },
            error: function () {
                new Toast('Bạn cần đăng nhập!', 'warning', '15000');
            }
        });
    });
    $(document).on('click', '.add-del-accessoriesld', function () {
        var $this = $(this);
        var id = $(this).attr('data-id-sp');
        var status = $(this).attr('data-status');
        var CategoryId = $(this).attr('data-idCategory');
        $.ajax({
            url: '/Home/AddDeleteFavoriteProducts',
            type: 'post',
            dataType: 'html',
            data: { id: id, status: status, IdCategrory: CategoryId },
            success: function (data) {
              if (data === '"XoaThanhCongLinhKien"') {
                    $(`#imglk-${id}`).attr('src', '../../image/black-heart.jpg');
                    $this.attr('data-status', 1).attr('title', 'Thêm vào sản phẩm yêu thích');
                    new Toast('Xóa thành công !', 'warning', '15000');
                }
                if (data === '"ThemThanhCongLinhKien"') {
                    $(`#imglk-${id}`).attr('src', '../../image/heart.png');
                    $this.attr('data-status', 2).attr('title', 'Xóa khỏi sản phẩm yêu thích');
                    new Toast('Thêm thành công!', 'done', '15000');
                }
                else if (data === '"ChuaDangNhap"') {
                    new Toast('Bạn cần đăng nhập!', 'warning', '15000');
                }
            },
            error: function () {
                new Toast('Bạn cần đăng nhập!', 'warning', '15000');
            }
        });
    });
    $(document).on('click', '#xem-linh-kien', function () {
        var $this = $(this);
        var id = $(this).attr('data-id-product');
        $.ajax({
            url: '/Home/ThemDaXemLinhKien',
            type: 'post',
            dataType: 'html',
            data: { id: id },
            success: function (data) {
                if (data === '"ok"') {
                    new Toast('Đã thêm vào sản phẩm đã xem !', 'done', '1000');
                }
                if (data === '"chuadangnhap"') {
                    new Toast('', 'done', '100');
                }
            },
            error: function () {
                new Toast('Đã xảy ra lỗi!', 'warning', '15000');
            }
        });
    });
});

