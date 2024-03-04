$(function () {
    $('#dgDatosUsuario').bootstrapTable({});
});

function GridUsuario(pUsuarioNombre, pEstatusId) {
    $.ajax({
        url: URL.Usuario + 'UsuarioJson?pUsuarioNombre=' + pUsuarioNombre + '&pEstatusId=' + parseInt(pEstatusId),
        data: "",
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#dgDatosUsuario').bootstrapTable("load", response.result.data);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
};

function RegresarUsuario() {
    $.cookie("usuarioEstatusId", 0);
    $.cookie('usuarioNombre', "");

    $(location).attr('href', URL.Usuario + 'Index');
}

function operateActionFormatter_Usuario(value, row, index) {
    return [
        '<a class="edit" href="' + URL.Usuario + 'Edit?pUsuarioId=' + row.UsuarioId + '" title="Editar">',
            '<i class="text-success fa fa-pencil fa-lg"></i>',
        '</a>',
        '<span>&nbsp;&nbsp;</span>',
        '<a class="contratos" href="' + URL.UsuarioContrato + 'Index?pUsuarioId=' + row.UsuarioId + '&pNombre=' + row.CampoComplemento_NombreCompleto + '" title="Contratos">',
            '<i class="text-warning fa fa-cog fa-lg"></i>',
        '</a>',
        '<span>&nbsp;&nbsp;</span>',
        '<a class="remove" href="' + URL.Usuario + 'Delete?pUsuarioId=' + row.UsuarioId + '" title="Inactivo">',
            '<i class="text-danger fa fa-times fa-lg"></i>',
        '</a>'
    ].join('');
};