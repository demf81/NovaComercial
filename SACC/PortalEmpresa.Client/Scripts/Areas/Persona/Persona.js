$(function () {
    $('#dgDatosPersona').bootstrapTable({});
});

function GridPersona(pNombre) {
    $.ajax({
        url: GetUrlPrincipal() + 'Persona/Persona/PersonaJson?pNombre=' + pNombre,
        data: "",
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#dgDatosPersona').bootstrapTable("load", response.result.data);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
};

function operateActionFormatter_Persona(value, row, index) {
    return [
        '<a class="edit" href="' + GetUrlPrincipal() + 'Persona/Persona/Edit?pPersonaId=' + row.PersonaId + '" title="Editar">',
            '<i class="text-success fa fa-pencil fa-lg"></i>',
        '</a>',
        '<span>&nbsp;&nbsp;</span>',

        '<a class="contratos" href="' + GetUrlPrincipal() + 'PersonaPaquete/PersonaPaquete/Index?pPersonaId=' + row.PersonaId + '&pNombre=' + row.CampoComplemento_NombreCompleto + '" title="Servicios">',
            '<i class="text-warning fa fa-cog fa-lg"></i>',
        '</a>',

        '<span>&nbsp;&nbsp;</span>',
        '<a class="remove" href="' + GetUrlPrincipal() + 'Persona/Persona/Delete?pPersonaId=' + row.PersonaId + '" title="Inactivo">',
            '<i class="text-danger fa fa-times fa-lg"></i>',
        '</a>'
    ].join('');
};