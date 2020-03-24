var homeConfig = {
    pageIndex: 1,
    pageSize: 1
}
var userController = {

    initial: function () {
        this.registerEvent();
    },
    registerEvent: function () {
        this.loadData();
    },
    loadData: function () {
        $.ajax({
            url: '/Admin/User/GetAllPaging',
            type: 'POST',
            dataType: 'JSON',
            data: {
                pageIndex: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            success: function (response) {
                if (response != null) {
                    var data = response.Items;
                    var html = '';
                    var template = $('#data-template').html();
                    debugger
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            UserName: item.UserName,
                            Name: item.Name,
                            Email: item.Email,
                            Phone: item.Phone,
                            Address: item.Address,
                            status: item.Status
                        });
                    });
                    $('#data-table').html(html);
                    debugger
                    userController.paginData(response.TotalRecord, function () {
                        userController.loadData();
                    })
                }
            }
        })
    },
    paginData: function (totalRow, callback) {
        var totalpage = Math.ceil(totalRow / homeConfig.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalpage,
            visiblePages: 5,
            onPageClick: function (event, page) {
                debugger
                homeConfig.pageIndex = page
                setTimeout(callback, 200);
            }
        });
    },
    AddData: function () {

    },
    UpdateData: function () {

    },
    DeleteData: function () {

    },
    ValidationForm: function () {

    },
    SaveData: function () {

    },
    RestForm: function () {

    }
}
userController.initial();