$(function () {
    $('#dgDatosPersonaPaquete').bootstrapTable({});
});

function GridPersonaPaquete(pPersonaId) {
    $.ajax({
        url: GetUrlPrincipal() + 'PersonaPaquete/PersonaPaquete/PersonaPaqueteJson?pPersonaId=' + pPersonaId,
        data: "",
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#dgDatosPersonaPaquete').bootstrapTable("load", response.result.data);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
};

function GuardaPersonaPaquete() {
    var data = $('#dgDatosCtrlUserPaquete').bootstrapTable('getSelections');

    if (data.length == 0) {
        swal("Debe seleccionar al menos un paquete", "", "warning");
        return;
    }

    $.ajax({
        url: GetUrlPrincipal() + 'PersonaPaquete/PersonaPaquete/Create',
        datatype: "json",
        data: JSON.stringify(data),
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $(location).attr('href', GetUrlPrincipal() + 'PersonaPaquete/PersonaPaquete/Index?pPersonaId=' + parseInt(data[0].PersonaId) + '&pNombre=' + data[0].Nombre);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });

    $("#myModal").modal('hide');
};

function operateActionFormatter_PersonaPaquete(value, row, index) {
    return [
        '<a class="remove" href="' + GetUrlPrincipal() + 'PersonaPaquete/PersonaPaquete/Delete?pPersonaPaqueteId=' + row.PersonaPaqueteId + '&pPersonaId=' + row.PersonaId + '&pNombre=' + row.CampoComplemento_NombreCompleto + '&pPaqueteId=' + row.PaqueteId + '&pPaqueteDescripcion=' + row.CampoComplemento_PaqueteDescripcion + '" title="Inactivo">',
            '<i class="text-danger fa fa-times fa-lg"></i>',
        '</a>'
    ].join('');
};