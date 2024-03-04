$(function () {
    $('#dgDatosCtrlUserPaquete').bootstrapTable({});
});

function GridCtrlUserPaquete(pPersonaId, pNombre) {
    $.ajax({
        url: GetUrlPrincipal() + 'Paquete/Paquete/CtrlUserPaqueteJson?pPersonaId=' + pPersonaId + '&pNombre=' + pNombre+ '&pContratoId=',
        data: "",
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#dgDatosCtrlUserPaquete').bootstrapTable("load", response.result.data);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
};