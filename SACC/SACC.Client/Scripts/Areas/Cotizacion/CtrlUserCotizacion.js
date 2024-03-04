var CtrlUserCotizacion = {
    inicializa:     function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_BUSQUEDA_COTIZACION_INDEX') {
            this.limpiarCtrls();

            this.keyEvent();

            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    keyEvent:       function () {
        $("#txtCtrlUserNombrePersona").on("change paste keyup", function () {
            if ($("#txtCtrlUserNombrePersona").val() == "")
                $('span[data-valmsg-for="CtrlUserNombrePersona"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserNombrePersona"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgCtrlUserViewDatosCotizacion').bootstrapTable({
                pagination: false,
                search:     false,
                columns: [
                    {
                        field:     'CotizacionId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'Fecha',
                        title:     'Fecha',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'CotizacionDescripcion',
                        title:     'Descripción',
                        align:     'left'
                    },
                    {
                        field:     'PersonaId',
                        title:     'PersonaId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'PersonaNombre',
                        title:     'Nombre',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'EmpresaId',
                        title:     'EmpresaId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'EmpresaNombre',
                        title:     'Empresa',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Total',
                        title:     'Total ($)',
                        sortable:  true,
                        formatter: 'priceFormatter',
                        align:     'right'
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
                pCotizacionDescripcion: "",
                pCotizacionTipoId:      ($("input[name='rbVentaTipoId'][value=1]:checked").val() ? -100 : -200),
                pFechaInicio:           ($('#dtpFechaInicial').val() == "" ? null : $('#dtpFechaInicial').val()),
                pFechaFin:              ($('#dtpFechaFinal').val() == "" ? null : $('#dtpFechaFinal').val()),
                pEstatusId:             1,
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Cotizacion + 'CotizacionGridJson',
                json
            );

            $('#dgCtrlUserViewDatosCotizacion').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<a class="editCotizacion" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="printCotizacion" href="javascript:void(0)" title="Imprimir">',
                '<i class="text-primary fa fa-print fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="detailCotizacion" href="javascript:void(0)" title="Detalle">',
                '<i class="text-info fa fa-search fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeCotizacion" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-trash fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar:         function () {
        if (!this.validaBusqueda()) return;

        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtCtrlUserNombrePersona").val() == "") {
            $('span[data-valmsg-for="CtrlUserNombrePersona"]').text('Campo Requerido');
            $("#txtCtrlUserNombrePersona").focus();

            return false;
        }

        return true;
    },
    limpiarCtrls:   function () {
        $('#txtCtrlUserNombrePersona').val('');
    }
}