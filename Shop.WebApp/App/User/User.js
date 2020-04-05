var homeConfig = {
    pageIndex: 1,
    pageSize: 5
}
var userController = {
    initial: function () {
        userController.loadData();        
    },
    registerEvent: function () {
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Bạn có muốn xóa tài khoản này?", function (result) {
                if (result) {
                    userController.DeleteData(id);
                }
            });
        });
        $('#btnAdd').off('click').on('click', function () {
            if (userController.ValidationForm() == 1) {
                userController.AddData();
            }
            if (userController.ValidationForm()==2) {
                bootbox.alert("Không được để trống thông tin!");
            }
            if (userController.ValidationForm() == 0) {
                bootbox.alert("Tài khoản hoặc mật khẩu lớn hơn 6 kí tự!");
            }
        });
        $('#btn-image').off('click').on('click', function (e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function (url) {
                $('#image').val(url);
            };
            finder.popup();
        });
        $('.btn-search').off('click').on('click', function () {
            userController.loadData(true);
        });
        $('#btn-add').off('click').on('click', function () {
            $('#myModal').modal('show');
            $('#btnUpdate').hide();
            $('#btnAdd').show();
            userController.RestForm();
        });
        $('.btn-edit').off('click').on('click', function () {
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
            userController.RestForm();
        });
    },
    loadData: function (changePageSize) {
        var keyword = $('#formsearch').val();
        $.ajax({
            url: '/Admin/User/GetAllPaging',
            type: 'GET',
            dataType: 'JSON',
            data: {
                keyword: keyword,
                pageIndex: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            success: function (response) {
                if (response != null) {
                    var data = response.Items;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ID: item.ID,
                            UserName: item.UserName,
                            Name: item.Name,
                            Email: item.Email,
                            Phone: item.Phone,
                            Address: item.Address,
                            Status: item.Status == true ? "<span class=\"badge badge-success\">Hoạt Động</span>" : "<span class=\"badge badge-danger\">Khóa</span>"
                        });
                    });
                    $('#data-table').html(html);
                    userController.paginData(response.TotalRecord, function () {
                        userController.loadData();
                    }, changePageSize);
                    userController.registerEvent();
                };
            }
        });
    },
    paginData: function (totalRow, callback, changePageSize) {
        debugger
        var totalpage = Math.ceil(totalRow / homeConfig.pageSize);
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        };
        $('#pagination').twbsPagination({
            totalPages: totalpage,
            first: "Đầu",
            next: "Tiếp",
            last: "Cuối",
            prev: "Trước",
            visiblePages: 5,
            onPageClick: function (event, page) {
                if (page != homeConfig.pageIndex) {
                    homeConfig.pageIndex = page;
                    setTimeout(callback, 100);
                };
            }
        });
    },
    AddData: function () {       
        var data = {
            UserName: $('#user').val(),
            PassWord: $('#pass').val(),
            Name: $('#name').val(),
            Email: $('#email').val(),
            Phone: $('#phone').val(),
            Address: $('#address').val(),
            Status: $('#status').prop('checked')
        };       
        $.ajax({
            url: '/Admin/User/Create',
            type: 'POST',
            data: data,
            dataType: 'json',
            success: function (result) {
                bootbox.alert("Thêm tài khoản thành công!", function () {
                    $('#myModal').modal('hide');
                    userController.loadData(true);
                });
            },
            error: function (error) {
                console.log(error);
            }
        });
    },
    UpdateData: function () {

    },
    DeleteData: function (id) {      
        $.ajax({
            url: '/Admin/User/Delete/' + id,
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                if (result.Success) {
                    bootbox.alert("Xóa tài khoản thành công!", function () {
                        userController.loadData(true);
                    });
                }
            }
        })
    },
    ValidationForm: function () {
        var UserName = $('#user').val();
        var PassWord = $('#pass').val();
        var Name = $('#name').val();
        var Email = $('#email').val();
        var Phone = $('#phone').val();
        var Address = $('#address').val();
        if (UserName.length <= 6 || PassWord.length <= 6 || UserName == " " || PassWord == " ") {
            return 0;
        }
        if (Name == "" || Email == "" || Phone == "" || Address == "") {
            return 2;
        }
        return 1;
    },
    RestForm: function () {
        $('#user').val('');
        $('#pass').val('');
        $('#name').val('');
        $('#email').val('');
        $('#phone').val('');
        $('#address').val('');
        $('#status').prop('checked', false);
    }
}
userController.initial();