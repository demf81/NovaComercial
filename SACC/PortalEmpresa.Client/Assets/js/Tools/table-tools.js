//responsive server side datatable
$.fn.rssDataTable = function (options) {
    var $dt = $(this);
    //$dt.dataTable().fnDestroy();
    var buttons = _getExportButtons(options);

    var ajaxOptions = {
        url: options.url,
        type: options.type || 'POST',
        data: function (d, e) {
            if (options.data) {
                return $.extend({}, d, options.data);
            }
            return d;
        },
        dataSrc: function (json) {
            if (options.dataSrc) {
                return options.dataSrc(json);
            } else {
                return json.data;
            }
        }
    };
    var $dataTable;
    var finalOptions = {
        serverSide: true,
        responsive: {
            details:{
                type: "inline",
                renderer: options.detailRenderer
            }
        },
        retrieve: true,
        searching: false,
        buttons: buttons,
        columnDefs: options.columnDef,
        dom: "<'row'<'col-sm-6'l><'col-sm-6'f>><'row'<'col-sm-12'tr>><'row'<'col-sm-5'B><'col-sm-7'p>>",
        language: getSpanishLang(),
        ajax: ajaxOptions,
        initComplete: function () {
            if (options.initComplete) {
                options.initComplete();
            }
        },
        drawCallback: function () {
            if (options.drawCallback) {
                options.drawCallback();
            }
            $dt.css('width', '');
        }
    };
    $dataTable = $dt.DataTable(finalOptions);
    $(window).resize(function () {
        $dataTable.columns.adjust().draw();
    })
    function _getExportButtons(options) {
        var exportButtons = [];
        if (options.pdfEnabled != false) {
            exportButtons.push({
                extend: 'pdf',
                text: 'PDF',
                className: 'btn btn-sm btn-warning'
            });
        }

        if (options.excelEnabled != false) {
            exportButtons.push({
                extend: 'excel',
                text: 'EXCEL',
                className: 'btn btn-sm btn-warning'
            });
        }

        if (options.printEnabled != false) {
            exportButtons.push({
                extend: 'print',
                text: 'IMPRIMIR',
                className: 'btn btn-sm btn-warning'
            });
        }

        return exportButtons;
    };
    function getSpanishLang() {
        return {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        };
    }

    return $dataTable;
};