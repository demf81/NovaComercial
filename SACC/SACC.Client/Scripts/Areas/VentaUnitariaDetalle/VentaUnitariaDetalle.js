$(function () {
    $('#dgDatosVentaUnitariaDetalle').bootstrapTable({});

    $('.input-group.date').datepicker({
        format: "yyyy-mm-dd",
        autoclose: true,
        language: 'es',
        minDate: new Date(),
        startDate: new Date()
    }).on('changeDate', function (ev) {
        $('#FechaVigencia').val(ev.date.toJSON().toString().substring(0, 10));
    });
});

function GridVentaUnitariaDetalle(pVentaUnitariaId) {
    $.ajax({
        url: URL.VentaUnitariaDetalle + 'VentaUnitariaDetalleJson?pVentaUnitariaId=' + pVentaUnitariaId,
        data: "",
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#dgDatosVentaUnitariaDetalle').bootstrapTable("load", response.result.data);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
};

function CambioVigenciaVentaUnitaria() {
    $.ajax({
        url: URL.VentaUnitaria + 'CambioVigencia?pVentaUnitariaId=' + $('#VentaUnitariaId').val() + '&pFechaVigencia=' + $('#FechaVigencia').val() + ' 23:59:59.000',
        data: "",
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $(location).attr('href', URL.VentaUnitaria + 'Index');
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
}

function AmparadoFormatter(value) {
    var _res = 'No Amparado';
    var _class = 'text-danger';

    if (value) {
        _res = 'Amparado';
        _class = 'text-success'
    }


    return [
        '<i class="' + _class + '"><span>' + _res + '</span></i>'
    ].join('');
}