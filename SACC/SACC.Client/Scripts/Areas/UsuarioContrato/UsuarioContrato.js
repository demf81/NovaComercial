$(function () {
    $('#dgDatosUsuarioContrato').bootstrapTable({});
});

function GridUsuarioContrato(pUsuarioId) {
    $.ajax({
        url: URL.UsuarioContrato + 'UsuarioContratoJson?pUsuarioId=' + pUsuarioId,
        data: "",
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#dgDatosUsuarioContrato').bootstrapTable("load", response.result.data);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
};

function GuardaUsuarioContrato() {
    var data = $('#dgDatosCtrlUserContrato').bootstrapTable('getSelections');

    if (data.length == 0) {
        swal("Debe seleccionar al menos un contrato", "", "warning");
        return;
    }

    $.ajax({
        url: URL.UsuarioContrato+ 'Create',
        datatype: "json",
        data: JSON.stringify(data),
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $(location).attr('href', URL.UsuarioContrato + 'Index?pUsuarioId=' + parseInt(data[0].EntidadId) + '&pEmpresaDescripcion=' + data[0].EntidadDescripcion);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });

    $("#myModal").modal('hide');
};

function operateActionFormatter_UsuarioContrato(value, row, index) {
    return [
        '<a class="remove" href="' + URL.UsuarioContrato + 'Delete?pUsuarioContratoId=' + row.UsuarioContratoId + '&pUsUarioId=' + row.UsuarioId + '&pNombre=' + row.CampoComplemento_NombreCompleto + '&pContratoId=' + row.ContratoId + '&pContratoDescripcion=' + row.CampoComplemento_ContratoDescripcion + '" title="Inactivo">',
            '<i class="text-danger fa fa-times fa-lg"></i>',
        '</a>'
    ].join('');
};