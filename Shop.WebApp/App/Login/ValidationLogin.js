var validateForm = function () {
    debugger
    var user = $('#username').val();
    var pass = $('#password').val();
    if (user == "" || pass == "" || user.length <= 6 || pass <= 6) {
        alert('Tài khoản và mật khẩu lớn hơn 6 kí tự!');
    }
}