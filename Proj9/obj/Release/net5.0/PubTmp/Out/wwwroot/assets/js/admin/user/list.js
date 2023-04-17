"use strict";
var tableData;
var KTDatatablesBasicScrollable = function () {
    var initTableData = function () {


        var table = $('#user-dataTable2');

        // begin first table
        tableData = table.DataTable({
            scrollX: true,
            scrollCollapse: true,
            searchDelay: 500,
            info: false,
            processing: true,
            serverSide: true,
            ajax: {
                url: 'List',
                type: 'POST',
                error: (xhr, ajaxOptions, thrownError) => {

                    $("#listing-data").attr("disabled", false);
                    $("#listing-data").html(`<i class="fa fa-arrow-circle-right"></i>`);
                }
            },
            "language": {
                processing: '<i class="fa fa-2x fa-circle-o-notch fa-spin"></i>'
            },
            "initComplete": function (settings, json) {

                if (json.data.length > 0) {
                    $('#user-dataTable2 tbody').fadeIn();
                }
                else {
                    $('#user-dataTable2_processing').remove();
                    $('#user-dataTable2 tbody').html(`<tr class="odd"><td valign="top" colspan="11" class="dataTables_empty">No matching records found</td></tr>`)
                }
            },
            columns: [
                {
                    data: 'createdOn'
                },
                {
                    data: 'name'
                },
                {
                    data: 'email'
                },
                {
                    data: 'role'
                },
                {
                    data: 'role'
                },
                {
                    data: 'isActive'
                },
                {
                    data: 'role',
                    responsivePriority: -1
                },
            ],
            columnDefs: [
                {
                    targets: -1,
                    title: 'Actions',
                    Visible: false,
                    orderable: false,
                    render: function (data, type, full, meta) {
                        let html = '';
                        let roleVar = data.name;
                        if (!roleVar) { return `<span>-</span>`; }
                        if (roleVar.toLowerCase() === 'admin') {
                            html = `<span>-</span>`;
                        }
                        else {
                            html = `<button type="button" class="btn waves-effect waves-light btn-rounded  btn btn-info btn-sm" onclick="showPopup('Edit?id=${full.userId}','Edit User')" dataUserId="${full.userId}">
                                     <i class="fa fa-edit" aria-hidden="true"></i>
                                     </button>`;

                            html += `<button type="button" class="btn waves-effect waves-light btn-rounded btn btn-danger btn-sm" onclick="DeleteFunc(this)" dataUserId="${full.userId}">
                                     <i class="fa fa-trash" aria-hidden="true"></i>
                                     </button>`;
                        }
                        return html;
                    },
                },
                {
                    targets: 0,
                    render: function (data, type, full, meta) {
                        if (!data) {
                            return `<span>-</span>`;
                        }
                        return `<span class="font-weight-bold text-info">${data}</span>`;
                    },
                },
                {
                    targets: 1,
                    render: function (data, type, full, meta) {
                        if (!data) {
                            return '<span>-</span>';
                        }
                        return `<span class="text-muted font-weight-bold d-block" >${data}</span>`;
                    },
                },
                {
                    targets: 2,
                    render: function (data, type, full, meta) {

                        if (!data) {
                            return '<span>-</span>';
                        }
                        return `<a href="javascript:;" class="text-dark-75 font-weight-bolder text-hover-primary mb-1 font-size-lg">${data}</a>`;
                    },
                },

                {
                    targets: 3,
                    render: function (data, type, full, meta) {
                        if (!data) {
                            return '<span>-</span>';
                        }
                        return `<span class="text-muted font-weight-bold d-block" >${data.name}</span>`;
                    },
                },
                {
                    targets: 4,
                    render: function (data, type, full, meta) {
                        let roleVar = full.role.name;
                        if (!roleVar) { return `<span>-</span>`; }
                        if (roleVar.toLowerCase() === 'admin') {
                            return `<span>-</span>`;
                        }

                        return `<span class="btn btn-primary btn-md font-weight-bold btn-inline" onclick="showPopup('UserPrivilege?id=${full.userId}','User Access  <small class=text-info>${full.email}</small> ')" >Edit</span>`;
                    },
                },
                {
                    targets: 5,
                    render: function (data, type, full, meta) {
                        let roleVar = full.role.name;
                        if (!roleVar) { return `<span>-</span>`; }
                        if (roleVar.toLowerCase() === 'admin') {
                            return `<span>-</span>`;
                        }

                        data = data;
                        var status = {
                            "true": {
                                'title': 'Active',
                                'class': 'btn-success'
                            },
                            "false": {
                                'title': 'InActive',
                                'class': 'btn-danger'
                            },
                        };
                        if (typeof status[data] === 'undefined') {

                            return '<span class="btn btn-md font-weight-bold btn-danger btn-inline" onclick="ChangeActiveInActive(this)" data-id="' + full.userId + '">Inactive</span>';
                        }
                        return '<span class="btn btn-md font-weight-bold ' + status[data].class + ' btn-inline" onclick="ChangeActiveInActive(this)" data-id="' + full.userId + '">' + status[data].title + '</span>';
                    },
                }
            ],
        });
    };

    return {
        //main function to initiate the module
        init: function () {
            initTableData();
        },
    };
}();


jQuery(document).ready(function () {

    KTDatatablesBasicScrollable.init();
});

let RefreshDataTable = () => {
    tableData.draw();
}

let ChangeActiveInActive = (elem) => {
    $.confirm({
        title: 'Change Status!',
        content: 'are you sure want to continue',
        type: 'blue',
        typeAnimated: true,
        closeIcon: true,
        animationBounce: 1.5,
        buttons: {
            confirm: () => {

                let id = elem.getAttribute("data-id");
                if (id) {
                    $.ajax({
                        url: 'ChangeActiveInActive',
                        type: 'POST',
                        dataType: "json",
                        data: { "id": id },
                        success: (data) => {
                            if (data.success) { toastr.success(data.userMessage); RefreshDataTable(); }
                            else
                                toastr.error(data.userMessage);
                        },
                        error: (xhr, ajaxOptions, thrownError) => { toastr.error('Internal server error..!'); }
                    });

                }
            }

        }
    });
}


let DeleteFunc = (elem) => {
    $.confirm({
        title: 'Delete!',
        content: 'are you sure want to continue?',
        type: 'red',
        typeAnimated: true,
        closeIcon: true,
        animationBounce: 1.5,
        buttons: {
            confirm: () => {

                let id = elem.getAttribute("dataUserId");
                if (id) {
                    $.ajax({
                        url: 'SoftDelete',
                        type: 'POST',
                        dataType: "json",
                        data: { "id": id },
                        success: (data) => {
                            if (data.success) { toastr.success(data.userMessage); RefreshDataTable(); }
                            else
                                toastr.error(data.userMessage);
                        },
                        error: (xhr, ajaxOptions, thrownError) => { toastr.error('Internal server error..!'); }
                    });

                }
            }

        }
    });
}