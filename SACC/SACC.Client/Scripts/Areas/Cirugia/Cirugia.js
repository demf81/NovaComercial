$(function () {
    $('#dgDatosCirugia').bootstrapTable({});
});

function GridCirugia(pCirugiaDescripcion, pEstatusId) {
    var objJSON = {
        pCirugiaDescripcion: pCirugiaDescripcion,
        pEstatusId: pEstatusId
    };

    var json = JSON.stringify(objJSON, null, 2);

    var res = getJSON(
        URL.Cirugia + 'CirugiaGridJson',
        json
    );

    $('#dgDatosCirugia').bootstrapTable("load", res.data.Datos);
};

function RegresarCirugia() {
    $.cookie("cirugiaEstatusId", 0);
    $.cookie('cirugiaDescripcion', "");

    $(location).attr('href', URL.Cirugia + 'Index');
}

function operateActionFormatter_Cirugia(value, row, index) {
    return [
        '<a class="edit" href="' + URL.Cirugia + 'Edit?pCirugiaId=' + row.CirugiaId + '" title="Editar">',
        '<i class="text-success fa fa-pencil fa-lg"></i>',
        '</a>',
        '<span>&nbsp;&nbsp;</span>',
        '<a class="remove" href="' + URL.Cirugia + 'Delete?pCirugiaId=' + row.CirugiaId + '" title="Inactivo">',
        '<i class="text-danger fa fa-times fa-lg"></i>',
        '</a>'
    ].join('');
};