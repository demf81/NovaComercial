$(function () {
    $('#dgDatosCtrlUserContratoCoberturaPaquete').bootstrapTable({});
});

function GridContratoCoberturaPaqueteConPrecio(ContratoProductoId, PersonaId, PaqueteDescripcion, ctrl) {
    if ($("#CtrlUserContratoCoberturaPaquete_TipoArticuloId").val() == 0) {
        $('span[data-valmsg-for="CtrlUserContratoCoberturaPaquete_TipoArticuloId"]').text('Campo Requerido');
        return;
    }

    if ($("#CtrlUserContratoCoberturaPaquete_Descripcion").val() == '') {
        $('span[data-valmsg-for="CtrlUserContratoCoberturaPaquete_Descripcion"]').text('Campo Requerido')
        return;
    }

    $('span[data-valmsg-for="CtrlUserContratoCoberturaPaquete_TipoArticuloId"]').text('')
    $('span[data-valmsg-for="CtrlUserContratoCoberturaPaquete_Descripcion"]').text('')

    if ($('#CtrlUserContratoCoberturaPaquete_TipoArticuloId option:selected').text() == "SERVICIOS") {
        ServicioConPrecio($("#CtrlUserContratoCoberturaPaquete_Descripcion").val(), 'dgDatosCtrlUserContratoCoberturaPaquete');
    };

    if ($('#CtrlUserContratoCoberturaPaquete_TipoArticuloId option:selected').text() == "ESTUDIOS") {
        EstudioConPrecio($("#CtrlUserContratoCoberturaPaquete_Descripcion").val(), 'dgDatosCtrlUserContratoCoberturaPaquete');
    };

    if ($('#CtrlUserContratoCoberturaPaquete_TipoArticuloId option:selected').text() == "CIRUGÍAS") {
        CirugiaConPrecio($("#CtrlUserContratoCoberturaPaquete_Descripcion").val(), 'dgDatosCtrlUserContratoCoberturaPaquete');
    };

    if ($('#CtrlUserContratoCoberturaPaquete_TipoArticuloId option:selected').text() == "MATERIALES") {
        MaterialConPrecio($("#CtrlUserContratoCoberturaPaquete_Descripcion").val(), 'dgDatosCtrlUserContratoCoberturaPaquete');
    };

    if ($('#CtrlUserContratoCoberturaPaquete_TipoArticuloId option:selected').text() == "MEDICAMENTOS") {
        MedicamentoConPrecio($("#CtrlUserContratoCoberturaPaquete_Descripcion").val(), 'dgDatosCtrlUserContratoCoberturaPaquete');
    };
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