"use strict";
var tableData;
var KTDatatablesBasicScrollable = function () {
    var initTableData = function () {


        var table = $('#dashboard-dataTable2');

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
                [10, 50, 100],
                [10, 50, 100],
            ],
            "language": {
                processing: '<i class="fa fa-2x fa-circle-o-notch fa-spin"></i>'
            },
            "initComplete": function (settings, json) {

                if (json.data.length > 0) {
                    $('#dashboard-dataTable2 tbody').fadeIn();
                }
                else {
                    $('#dashboard-dataTable2_processing').remove();
                    $('#dashboard-dataTable2 tbody').html(`<tr class="odd"><td valign="top" colspan="11" class="dataTables_empty">No matching records found</td></tr>`)
                }
            },
            columns: [
               
                {
                    data: 'transDate'
                },
                {
                    data: 'Plant Name'
                },
                {
                    data: 'Depart Name'
                },
                {
                    data: 'Forms',
                    responsivePriority: -1
                },
            ],
            columnDefs: [{
                targets: -1,
                title: 'Forms',
                orderable: false,
                render: function (data, type, full, meta) {
                    var actions = '';
                    actions += `<span>Stator Temp Electrical</span>`;
                    return actions;
                },
            },
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
                    //if (!data) {
                    //    return '<span>-</span>';
                    //}
                    return `T4`;
                },
            },
            {
                targets: 2,
                render: function (data, type, full, meta) {
                    return `<span class="text-muted font-weight-bold d-block" >Electrical</span>`;
                },
            },
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

    //$('#datepicker').datepicker({
    //    format: 'dd/mm/yyyy',
    //});

});
