var CtrlUserCotizacionProcedimientoDetalle = {
    evento:     null,
    inicializa: function (evento, procedimeintoId, procedimientoDescripcion, data) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_COTIZACION_PROCEDIMIENTO_DETALLE_INDEX') {
            this.tabla.inicializa();
            this.tabla.datos(procedimeintoId, procedimientoDescripcion, data);
        };

        if (this.evento == 'CTRL_USER_COTIZACION_PROCEDIMIENTO_DETALLE_EDIT') {
            this.tablaEdit.inicializa();
            this.tablaEdit.datos(procedimeintoId, procedimientoDescripcion, data);
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCotizacionProcedimientoDetalle .editable').editable('toggleDisabled');

            $('#dgDatosCotizacionProcedimientoDetalle').bootstrapTable({
                pagination: false,
                search:     false,
                columns: [
                    {
                        field:     'ProcedimientoDetalleId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ServicioId',
                        title:     'ServicioId',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ServicioPartidaId',
                        title:     'ServicioPartidaId',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'Posicion',
                        title:     'Posicion',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ClaseOperacion',
                        title:     'ClaseOperacion',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ElementoId',
                        title:     'Elemento',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'CantidadBase',
                        title:     'CantidadBase',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ProcedimientoDetalleDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'CantidadOriginal',
                        title:     'Cant Orig',
                        sortable:  true,
                        align:     'center',
                    },
                    {
                        field:     'Cantidad',
                        title:     'Cantidad',
                        sortable:  true,
                        align:     'center',
                        editable: {
                            type:  'text',
                            title: 'Debe teclear una cantidad'
                        },
                    },
                    {
                        field:     'TarifaId',
                        title:     'TarifaId',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'Costo',
                        title:     'Costo',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'Precio',
                        title:     'Precio',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'PrecioConIva',
                        title:     'Precio',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                    },
                    {
                        field:    'Iva',
                        title:    'Iva',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'SubTotal',
                        title:     'SubTotal',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'SubTotalConIva',
                        title:     'SubTotal',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                    },
                    {
                        field:     'EstatusId',
                        title:     'EstatusId',
                        sortable:  true,
                        align:     'center',
                        visible:    false
                    },
                    {
                        field:     'Seleccionado',
                        title:     '',
                        checkbox:  true
                    }
                ]
            });
        },
        datos: function (procedimeintoId, procedimientoDescripcion, data) {
            $('#dgDatosCotizacionProcedimientoDetalle').bootstrapTable("load", data);
        },
    },
    tablaEdit: {
        inicializa: function () {
            $('#dgDatosCotizacionProcedimientoDetalle .editable').editable('toggleDisabled');

            $('#dgDatosCotizacionProcedimientoDetalle').bootstrapTable({
                pagination: false,
                search: false,
                columns: [
                    {
                        field:     'CotizacionProcedimientoDetalleId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ProcedimientoDetalleDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'CantidadBase',
                        title:     'Cant Orig',
                        sortable:  true,
                        align:     'center',
                    },
                    {
                        field:     'Cantidad',
                        title:     'Cantidad',
                        sortable:  true,
                        align:     'center',
                        editable: {
                            type:  'text',
                            title: 'Debe teclear una cantidad'
                        },
                    },
                    {
                        field:     'Costo',
                        title:     'Costo',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'Precio',
                        title:     'Precio',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'PrecioConIva',
                        title:     'Precio',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                    },
                    {
                        field:     'Iva',
                        title:     'Iva',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'SubTotal',
                        title:     'SubTotal',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'SubTotalConIva',
                        title:     'SubTotal',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                    },
                    {
                        field:     'Seleccionado',
                        title:     '',
                        checkbox:  true
                    }
                ]
            });
        },
        datos: function (procedimeintoId, procedimientoDescripcion, data) {
            $('#dgDatosCotizacionProcedimientoDetalle').bootstrapTable("load", data);
        },
    }
};




$('#dgDatosCotizacionProcedimientoDetalle').on('editable-save.bs.table', function (e, field, renglon, old, $el) {
    if (field == "Cantidad") {
        if (!Number(renglon.Cantidad))
            renglon.Cantidad = 1;

        if ((parseInt(renglon.Cantidad) <= 0) == true)
            renglon.Cantidad = 1;

        var $table = $('#dgDatosCotizacionProcedimientoDetalle');

        var $els = $table.find('.editable');
        row_index = $els.index($el);

        $table.bootstrapTable('updateRow', {
            index: row_index,
            row: {
                ItemId:         renglon.ItemId,
                SubTotalConIva: renglon.PrecioConIva * renglon.Cantidad,
            }
        });
    };
});