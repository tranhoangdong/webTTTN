

$(document).ready(function () {
    $("#myInput").keydown(function () {
        var query = $('#myInput').val();
        var parent = this.parentNode;
        $.ajax({
            url: '/Home/GetDataAutocomplete',
            type: 'post',
            dataType: 'html',
            data: { query: query },
            success: function (data) {
                var a, b , val = $('#myInput').val();
                closeAllLists();
                if (!val) { return false; }
                a = document.createElement("DIV");
                a.setAttribute("id", $('#myInput').attr("id") + "autocomplete-list");
                a.setAttribute("class", "autocomplete-items");
                parent.appendChild(a);
                    json = JSON.parse(data);
                    for (i = 0; i < json.length; i++) {
                        b = document.createElement("DIV");
                        b.setAttribute("id", "chonsanpham");
                        b.setAttribute("data-idspt", json[i].id);
                        b.innerHTML += "<div id=noidung><a href=\"/Home/Detail?id=" + json[i].id+"\"> <div id=anhspauto><img src=\'/image/AnhDienThoai/" + json[i].img + "\' id = \"imgautocomplete\"> </div> </a>  <div id=khungttgia><span><strong> " + json[i].name + "</strong> </span> <br>  <span>Giá: " + json[i].price + " VNĐ " + json[i].status + "</span><br><span>HSX: " + json[i].Manufacturer + "</span></div> </div>";
                        b.innerHTML += "<input type='hidden' value='" + json[i] + "'>";
                        a.appendChild(b);
                    }
            },
            error: function () {
                //debugger
            }
        });
    });
    function closeAllLists(elmnt) {
        var inp = document.getElementById("myInput");
        var x = document.getElementsByClassName("autocomplete-items");
        for (var i = 0; i < x.length; i++) {
            if (elmnt != x[i] && elmnt != inp) {
                x[i].parentNode.removeChild(x[i]);
            }
        }
    }
});