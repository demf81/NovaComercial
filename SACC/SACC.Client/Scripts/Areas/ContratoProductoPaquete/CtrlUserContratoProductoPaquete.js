$(function () {
    $('#dgDatosCtrlUserContratoProductoPaquete').bootstrapTable({});
});

function GridContratoProductoPaqueteConPrecio(ContratoProductoId, PersonaId, PaqueteDescripcion, ctrl) {
    $.ajax({
        url: URL.ContratoProductoPaquete + 'ContratoProductoPaqueteConPrecioList?pContratoProductoId=' + ContratoProductoId + '&pPersonaId=' + PersonaId + '&pDescripcion=' + PaqueteDescripcion,
        data: "",
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#' + ctrl).bootstrapTable("load", response.result.data);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
};

function ValidaPrecioCero(value, row, index) {
    if (row.Precio == 0) {
        return {
            disabled: true,
            checked: false
        }
    }

    return value;
}