var CtrlUserBusquedaMedicamento = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_BUSQUEDA_MEDICAMENTO') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
        };
    },
    keyEvent: function () {
        $("#txtCtrlUserBusquedaMedicamentoDescripcion").on("change paste keyup", function () {
            if ($("#txtCtrlUserBusquedaMedicamentoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="CtrlUserBusquedaMedicamentoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserBusquedaMedicamentoDescripcion"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserBusquedaMedicamento').bootstrapTable({
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
                        title:    'Cuadro Tipo',
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
                        title:    'Material',
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
                pServicioDescripcion: $('#txtCtrlUserBusquedaMedicamentoDescripcion').val().trim(),
                pServicioTipoId:      -1
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Servicio + 'CtrlUserMedicamentoConPrecioGridJson',
                json
            );

            $('#dgDatosCtrlUserBusquedaMedicamento').bootstrapTable("load", res.data.Datos);
        }
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtCtrlUserBusquedaMedicamentoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="CtrlUserBusquedaMedicamentoDescripcion"]').text('Campo Requerido');
            $("#txtCtrlUserBusquedaMedicamentoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiarCtrls: function () {
        $('#txtCtrlUserBusquedaMedicamentoDescripcion').val('');
        $('span[data-valmsg-for="CtrlUserBusquedaMedicamentoDescripcion"]').text('');

        $('#dgDatosCtrlUserBusquedaMedicamento').bootstrapTable('removeAll');
    },
};