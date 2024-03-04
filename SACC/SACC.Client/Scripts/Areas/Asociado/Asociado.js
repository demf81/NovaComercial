$(function () {
    $('#dgDatosCtrlUserAsociado').bootstrapTable({});
});

function GridCtrlUserAsociado(pSocioId, pCveFamiliar, pNombre) {
    $.ajax({
        url: URL.Asociado + 'AsociadoJson?pSocioId=' + pSocioId + '&pCveFamiliar=' + pCveFamiliar + '&pNombre=' + pNombre,
        data: "",
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#dgDatosCtrlUserAsociado').bootstrapTable("load", response.result.data);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
};

function sexoFormatter(value) {
    return (value == 2 ? 'Masculino' : 'Femenino')
}