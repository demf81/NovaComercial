var CtrlUserBusquedaServicioMedico = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_BUSQUEDA_SERVICIO_MEDICO') {
            this.keyEvent();
            this.limpiarCtrls();

            ServicioMedicoTipo.llenaCombo('ddlCtrlUserBusquedaServicioMedicoTipoId', 'TODOS');

            this.tabla.inicializa();
        };
    },
    keyEvent: function () {
        $("#txtCtrlUserBusquedaServicioMedicoDescripcion").on("change paste keyup", function () {
            if ($("#txtCtrlUserBusquedaServicioMedicoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="CtrlUserBusquedaServicioMedicoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserBusquedaServicioMedicoDescripcion"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserBusquedaServicioMedico').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:    'ItemId',
                        title:    'Folio',
                        sortable: true,
                        align:    'center'
                    },
                    {
                        field:    'ItemTipoDescripcion',
                        title:    'Servicio Tipo',
                        sortable: true,
                        align:    'left'
                    },
                    {
                        field:    'ItemTipoId',
                        title:    'ItemTipoId',
                        sortable: true,
                        align:    'left',
                        visible:  false
                    },
                    {
                        field:    'ItemDescripcion',
                        title:    'Servicio',
                        sortable: true,
                        align:    'left'
                    },
                    {
                        field:    'state',
                        title:    '',
                        checkbox: true
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pServicioDescripcion: $('#txtCtrlUserBusquedaServicioMedicoDescripcion').val(),
                pServicioTipoId:      -1
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Servicio + 'CtrlUserServicioMedicoConPrecioGridJson',
                json
            );

            $('#dgDatosCtrlUserBusquedaServicioMedico').bootstrapTable("load", res.data.Datos);
        },
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtCtrlUserBusquedaServicioMedicoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="CtrlUserBusquedaServicioMedicoDescripcion"]').text('Campo Requerido');
            $("#txtCtrlUserBusquedaServicioMedicoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiarCtrls: function () {
        $('#txtCtrlUserBusquedaServicioMedicoDescripcion').val('');
        $('span[data-valmsg-for="CtrlUserBusquedaServicioMedicoDescripcion"]').text('');

        $('#dgDatosCtrlUserBusquedaServicioMedico').bootstrapTable('removeAll');
    },
}