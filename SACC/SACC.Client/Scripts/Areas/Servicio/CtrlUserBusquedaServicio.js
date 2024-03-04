var ctrlSelections = []


var CtrlUserBusquedaServicio = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_BUSQUEDA_SERVICIO_INDEX') {
            this.tabla.inicializa();
            this.keyEvent();
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosBusquedaServicio').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'AreaNegocioId',
                        title:     'AreaNegocioId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ServicioId',
                        title:     'ServicioId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ItemId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ItemDescripcion',
                        title:     'Descripci&oacute;n',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'ItemTipoId',
                        title:     'Tipo',
                        sortable:  true,
                        align:     'left',
                        visible:   false
                    },
                    {
                        field:     'ItemTipoDescripcion',
                        title:     'Tipo',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Costo',
                        title:     'Costo ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                        visible:   false
                    },
                    {
                        field:     'Precio',
                        title:     'Precio ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                        visible:   false
                    },
                    {
                        field:     'PrecioConIva',
                        title:     'Precio ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter'
                    },
                    {
                        field:     'Anticipo',
                        title:     'Anticipo ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                        visible:   false
                    },
                    {
                        field:     'Iva',
                        title:     'Iva ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                        visible:   false
                    },
                    {
                        field:     'state',
                        title:     '',
                        checkbox:  true
                    }
                ],
                responseHandler: function (res) {
                    $.each(res.rows, function (i, row) {
                        row.state = $.inArray(row.id, ctrlSelections) !== -1
                    })

                    return res
                }
            });
        },
        datos: function () {
            var _url    = "";
            var objJSON = {};

            if (parseInt($("#ddlCtrlUserBusquedaServicioId").val()) == 1) {
                _url = URL.Servicio + 'CtrlUserPaqueteConPrecioGridJson';

                objJSON = {
                    pServicioDescripcion: $('#txtCtrlUserBusquedaServicioDescripcion').val(),
                    pServicioTipoId:      -1
                };
            }
            else if (parseInt($("#ddlCtrlUserBusquedaServicioId").val()) == 2) {
                _url = URL.Servicio + 'CtrlUserServicioMedicoConPrecioGridJson';

                objJSON = {
                    pServicioDescripcion: $('#txtCtrlUserBusquedaServicioDescripcion').val(),
                    pServicioTipoId:      -1
                };
            }
            else if (parseInt($("#ddlCtrlUserBusquedaServicioId").val()) == 3) {
                _url = URL.Servicio + 'CtrlUserCirugiaConPrecioGridJson';

                objJSON = {
                    pServicioDescripcion: $('#txtCtrlUserBusquedaServicioDescripcion').val()
                };
            }
            else if (parseInt($("#ddlCtrlUserBusquedaServicioId").val()) == 4) {
                _url = URL.Servicio + 'CtrlUserEstudioConPrecioGridJson';

                objJSON = {
                    pServicioDescripcion: $('#txtCtrlUserBusquedaServicioDescripcion').val()
                };
            }
            else if (parseInt($("#ddlCtrlUserBusquedaServicioId").val()) == 5) {
                _url = URL.Servicio + 'CtrlUserMaterialConPrecioGridJson';

                objJSON = {
                    pServicioDescripcion: $('#txtCtrlUserBusquedaServicioDescripcion').val()
                };
            }
            else if (parseInt($("#ddlCtrlUserBusquedaServicioId").val()) == 6) {
                _url = URL.Servicio + 'CtrlUserMedicamentoConPrecioGridJson';

                objJSON = {
                    pServicioDescripcion: $('#txtCtrlUserBusquedaServicioDescripcion').val(),
                    pServicioTipoId:      -1
                };
            }
            else if (parseInt($("#ddlCtrlUserBusquedaServicioId").val()) == 7) {
                _url = URL.Servicio + 'CtrlUserServicioAdministrativoConPrecioGridJson';

                objJSON = {
                    pServicioDescripcion: $('#txtCtrlUserBusquedaServicioDescripcion').val()
                };
            }
            else if (parseInt($("#ddlCtrlUserBusquedaServicioId").val()) == 8) {
                _url = URL.Servicio + 'CtrlUserSubrogadoConPrecioGridJson';

                objJSON = {
                    pServicioDescripcion: $('#txtCtrlUserBusquedaServicioDescripcion').val(),
                    pServicioTipoId:      -1
                };
            }
            else if (parseInt($("#ddlCtrlUserBusquedaServicioId").val()) == 9) {
                _url = URL.Servicio + 'CtrlUserProcedimientoConPrecioGridJson';

                objJSON = {
                    pServicioDescripcion: $('#txtCtrlUserBusquedaServicioDescripcion').val()
                };
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                _url,
                json
            );

            $('#dgDatosBusquedaServicio').bootstrapTable("load", res.data.Datos);
        }
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.datos();
    },
    keyEvent: function () {
        $("#txtCtrlUserBusquedaServicioDescripcion").on("change paste keyup", function () {
            if ($("#txtCtrlUserBusquedaServicioDescripcion").val().trim() == "")
                $('span[data-valmsg-for="CtrlUserBusquedaServicioDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserBusquedaServicioDescripcion"]').text('');
        });

        $('#ddlCtrlUserBusquedaServicioId').change(function () {
            if ($('#ddlCtrlUserBusquedaServicioId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="CtrlUserBusquedaServicioId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="CtrlUserBusquedaServicioId"]').text('');
            };
        });
    },
    validaBusqueda: function () {
        if ($('#ddlCtrlUserBusquedaServicioId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="CtrlUserBusquedaServicioId"]').text('Campo Requerido');
            $("#ddlCtrlUserBusquedaServicioId").focus();

            return false;
        };

        if ($("#txtCtrlUserBusquedaServicioDescripcion").val() == "") {
            $('span[data-valmsg-for="CtrlUserBusquedaServicioDescripcion"]').text('Campo Requerido');
            $("#txtCtrlUserBusquedaServicioDescripcion").focus();

            return false;
        };

        return true;
    },
};



$('#dgDatosBusquedaServicio').on('check.bs.table check-all.bs.table uncheck.bs.table uncheck-all.bs.table',
    function (e, rowsAfter, rowsBefore) {
        var rows = rowsAfter

        if (e.type === 'uncheck-all') {
            rows = rowsBefore
        }

        var ids = $.map(!$.isArray(rows) ? [rows] : rows, function (row) {
            return row.id
        })

        var func = $.inArray(e.type, ['check', 'check-all']) > -1 ? 'union' : 'difference'
        ctrlSelections = window._[func](ctrlSelections, ids)
    }
);