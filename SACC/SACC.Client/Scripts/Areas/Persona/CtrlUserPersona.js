$(function () {
    $('#dgDatosCtrlUserPersona').bootstrapTable({});

    $("#CtrlUserPersona_Nombre").on("change paste keyup", function () {
        if ($("#CtrlUserPersona_Nombre").val() == "")
            $('span[data-valmsg-for="CtrlUserPersona_Nombre"]').text('Campo Requerido');
        else
            $('span[data-valmsg-for="CtrlUserPersona_Nombre"]').text('');
    });
});

function GridCtrlUserPersona(pNombre) {
    if ($("#CtrlUserPersona_Nombre").val() == "") {
        $('span[data-valmsg-for="CtrlUserPersona_Nombre"]').text('Campo Requerido');
        return;
    };

    var objJSON = {
        pNombre: $('#CtrlUserPersona_Nombre').val(),
        pNumSocio: -1,
        pClaveFamiliar: '',
        pBaja: 0,
        pBajaAsociado: 0
    };

    var json = JSON.stringify(objJSON, null, 2);

    $.ajax({
        url: URL.Persona + 'CtrlUserBusquedaPersonaJson',
        data: json,
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#dgDatosCtrlUserPersona').bootstrapTable("load", response.result.data);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
};