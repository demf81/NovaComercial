var CtrlUserBusquedaPaquete = {
    evento:         null,
    origen:         null,
    inicializa:     function (evento, origen) {
        this.evento = evento;
        this.origen = origen;

        if (this.evento == 'CTRL_USER_BUSQUEDA_PAQUETE') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    keyEvent:       function () {
        $("#txtCtrlUserBusqueadaPaqueteDescripcion").on("change paste keyup", function () {
            if ($("#txtCtrlUserBusqueadaPaqueteDescripcion").val().trim() == "")
                $('span[data-valmsg-for="CtrlUserBusqueadaPaqueteDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserBusqueadaPaqueteDescripcion"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserBusquedaPaquete').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'PaqueteId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'PaqueteDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'PaqueteTipoDescripcion',
                        title:     'Tipo de Paquete',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'EstatusId',
                        title:     'Activo',
                        sortable:  false,
                        formatter: 'EstatusIdFormatter',
                        align:     'center'
                    },
                    {
                        field:     'state',
                        title:     '',
                        checkbox:  true
                    }

                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pPaqueteTipo:        CtrlUserBusquedaPaquete.origen,
                pPaqueteDescripcion: $("#txtCtrlUserBusqueadaPaqueteDescripcion").val(),
                pEstatusId:          ESTATUS_ENTIDAD.ACTIVO
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Paquete + 'CtrlUserBusquedaPaqueteJson',
                json
            );

            $('#dgDatosCtrlUserBusquedaPaquete').bootstrapTable("load", res.data.Datos);
        }
    },
    buscar:         function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtCtrlUserBusqueadaPaqueteDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="tCtrlUserBusqueadaPaqueteDescripcion"]').text('Campo Requerido');
            $("#txtCtrlUserBusqueadaPaqueteDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiarCtrls:   function () {
        $('#txtCtrlUserBusqueadaPaqueteDescripcion').val('');

        $('span[data-valmsg-for="CtrlUserBusqueadaPaqueteDescripcion"]').text('');
    }
};