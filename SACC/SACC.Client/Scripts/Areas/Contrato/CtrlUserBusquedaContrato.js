var CtrlUserBusquedaContrato = {
    evento:         null,
    inicializa:     function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_BUSQUEDA_CONTRATO') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    keyEvent:       function() {
        $("#txtCtrlUserBusqueadaContratoDescripcion").on("change paste keyup", function () {
            if ($("#txtCtrlUserBusqueadaContratoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="CtrlUserBusqueadaContratoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserBusqueadaContratoDescripcion"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserBusquedaContrato').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ContratoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ContratoDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'ContratoTipoDescripcion',
                        title:     'Tipo de Contrato',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'ContratoEstatusId',
                        title:     'Activo',
                        sortable:  false,
                        formatter: 'EstatusIdFormatter',
                        align:     'center'
                    },
                    {
                        field: 'state',
                        title: '',
                        checkbox: true
                    }
                    
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pContratoDescripcion: $("#txtCtrlUserBusqueadaContratoDescripcion").val(),
                pContratoTipoId:      -1,
                pContratoEstatusId:   ESTATUS_ENTIDAD.ACTIVO
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Contrato + 'CtrlUserContratoGridJson',
                json
            );

            $('#dgDatosCtrlUserBusquedaContrato').bootstrapTable("load", res.data.Datos);
        }
    },
    buscar:         function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtCtrlUserBusqueadaContratoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="tCtrlUserBusqueadaContratoDescripcion"]').text('Campo Requerido');
            $("#txtCtrlUserBusqueadaContratoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.limpiarCtrls();
        this.inicializa('CTRL_USER_BUSQUEDA_CONTRATO');
    },
    limpiarCtrls:   function () {
        $('#txtCtrlUserBusqueadaContratoDescripcion').val('');

        $('span[data-valmsg-for="CtrlUserBusqueadaContratoDescripcion"]').text('');
    }
};