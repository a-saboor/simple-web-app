"use strict";
var tableData;
var KTDatatablesBasicScrollable = function () {
    var initTableData = function () {


        var table = $('#stator-dataTable2');

        // begin first table
        tableData = table.DataTable({
            //stateSave: true,
            //"bDestroy": true,
            //"order": [[1, "desc"]],
            scrollX: true,
            scrollCollapse: true,
            searchDelay: 500,
            processing: true,
            serverSide: true,
            ajax: {
                url: 'List',
                type: 'POST',
                data: (d) => {
                    d.startD = $('#startD').val();
                    d.endD = $('#endD').val();
                }, beforeSend: () => {
                    $("#listing-data").attr("disabled", true);
                    $('#listing-data').html(`<i class="fa fa-spinner fa-spin"></i>`);
                }, complete: () => {
                    $("#listing-data").attr("disabled", false);
                    $("#listing-data").html(`<i class="fa fa-arrow-circle-right"></i>`);

                },
                error: (xhr, ajaxOptions, thrownError) => {
                    $("#listing-data").attr("disabled", false);
                    $("#listing-data").html(`<i class="fa fa-arrow-circle-right"></i>`);
                }
            },
            dom: `Bfl<'row'<'col-sm-12'tr>>
                    <'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'p>>`,
            buttons: [{
                extend: 'collection',
                text: 'Export Data',
                buttons: [
                    'copy',
                    'excel',
                    'csv',
                    'print'
                ]
            }],
            lengthMenu: [
                [25, 50, 100],
                [25, 50, 100],
            ],
            "language": {
                processing: '<i class="fa fa-2x fa-circle-o-notch fa-spin"></i>'
            },
            "initComplete": function (settings, json) {

                if (json.data.length > 0) {
                    $('#stator-dataTable2 tbody').fadeIn();
                }
                else {
                    $('#stator-dataTable2_processing').remove();
                    $('#stator-dataTable2 tbody').html(`<tr class="odd"><td valign="top" colspan="11" class="dataTables_empty">No matching records found</td></tr>`)
                }
            },
            columns: [
                {
                    data: 'transCode'
                },
                {
                    data: 'transDate'
                },
                //{
                //    data: 'shift'
                //},
                //{
                //    data: 'shiftTiming'
                //},
                {
                    data: 'generator'
                },
                {
                    data: 'hour'
                },
                {
                    data: 'load'
                },
                {
                    data: 'u'
                },
                {
                    data: 'v'
                },
                {
                    data: 'w'
                },
                //{
                //    data: 'Actions',
                //    responsivePriority: -1
                //},
            ],
            columnDefs: [
                //{
                //    targets: -1,
                //    title: 'Actions',
                //    Visible: false,
                //    orderable: false,
                //    render: function (data, type, full, meta) {
                //        var actions = '';
                //        actions += '<a class="btn btn-secondary btn-sm mr-1" href="javaacript:void(0)" >' +
                //            '<i class="fa fa-folder-open"></i> Details' +
                //            '</a> ';
                //        return actions;
                //    },
                //},
                {
                    targets: 0,
                    orderable: false,
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
                        return `${data}`;
                    },
                },
                //{
                //    targets: 2,
                //    render: function (data, type, full, meta) {
                //        return `<span class="text-muted font-weight-bold d-block" >${data}</span>`;
                //    },
                //},
                //{
                //    targets: 3,
                //    //width: '75px',
                //    render: function (data, type, full, meta) {
                //        if (!data) {
                //            return '<span>-</span>';
                //        }
                //        return `${data}`;
                //    },
                //},
                {
                    targets: 2,
                    //width: '75px',
                    render: function (data, type, full, meta) {
                        if (!data) {
                            return '<span>-</span>';
                        }
                        return `<a href="javascript:;" class="text-dark-75 font-weight-bolder text-hover-primary mb-1 font-size-lg">${data}</a>`;
                    },
                },

                {
                    targets: 3,
                    //width: '75px',
                    render: function (data, type, full, meta) {
                        if (!data) {
                            return '<span>-</span>';
                        }
                        return `<span class="text-muted font-weight-bold d-block" >${data}</span>`;
                    },
                },
                {
                    targets: 4,
                    //width: '75px',
                    render: function (data, type, full, meta) {
                        if (!data) {
                            return '<span>-</span>';
                        }
                        return `<span class="text-muted font-weight-bold d-block" >${data}</span>`;
                    },
                },
                {
                    targets: 5,
                    //width: '75px',
                    render: function (data, type, full, meta) {
                        if (!data) {
                            return '<span>-</span>';
                        }
                        return `<span class="text-muted font-weight-bold d-block" >${data}</span>`;
                    },
                },
                {
                    targets: 6,
                    width: '75px',
                    render: function (data, type, full, meta) {
                        if (!data) {
                            return '<span>-</span>';
                        }
                        return `<span class="text-muted font-weight-bold d-block" >${data}</span>`;
                    },
                },
                {
                    targets: 7,
                    width: '75px',
                    render: function (data, type, full, meta) {

                        if (!data) {
                            return '<span>-</span>';
                        }
                        return `<span class="text-muted font-weight-bold d-block" >${data}</span>`;

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

    $('#datepicker').datepicker({
        format: 'dd/mm/yyyy',
    });

});

let RefreshDataTable = () => {
    tableData.draw();
}


//addRow = (row) => {

//    table1.row.add([
//        row.Date,
//        row.OrderNo,
//        row.Customer ? row.Customer.Name + '|' + row.Customer.Contact : '',
//        row.TotalAmount + ' ' + row.Currency,
//        row.ShipmentStatus,
//        row.Status,
//        row.ID,
//    ]).draw(true);

//}


let Export = (event) => {

    let startD = $('#startD').val();
    let endD = $('#endD').val();

    if (startD <= endD && startD != "" && endD != "") {

        $('#export').attr('href', '/admin/Reports/ExportToExcel?startD=' + startD + '&endD=' + endD);
        return true;
    }
    else {
        toastr.info('Please input proper date range', 'Date Error!');
        return false;
    }
};

