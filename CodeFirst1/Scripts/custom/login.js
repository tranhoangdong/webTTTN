

$(document).ready(function () {
    $('#show-password').click(function () {
        var x = document.getElementById("Password");
        if (x.type === "password") {
            x.type = "text";
        } else {
            x.type = "password";
        }
           
    }); 
});