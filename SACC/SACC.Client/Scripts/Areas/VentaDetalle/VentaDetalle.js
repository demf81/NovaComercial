var VentaDetalleView = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'VENTA_DETALLE_VIEW_INDEX') {

            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosVentaDetalleView').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'VentaDetalleId',
                        title:     'VentaDetalleId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'VentaId',
                        title:     'VentaId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'AreaNegocioId',
                        title:     'AreaNegocioId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:    'ServicioId',
                        title:    'ServicioId',
                        align:    'left',
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
                        field:     'Cantidad',
                        title:     'Cantidad',
                        align:     'center'
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
                        field:     'PrecioConIva',
                        title:     'Precio ($)',
                        sortable:  true,
                        formatter: 'priceFormatter',
                        align:     'right',
                    },
                    {
                        field:     'SubTotalConIva',
                        title:     'SubTotal ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter'
                    },
                    {
                        field:     'Referencia',
                        title:     'Referencia',
                        align:     'center',
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pVentaDetalleId: 0,
                pVentaId:        $('#txtModalVentaId').val(),
                pEstatusId:      1
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.VentaDetalle + 'VentaDetalleConPrecioGridJson',
                json
            );

            $('#dgDatosVentaDetalleView').bootstrapTable("load", res.data.Datos);

            var _SubTotal  = 0;
            var _Descuento = 0;
            var _Iva       = 0;
            var _Total     = 0;

            $.each(res.data.Datos, function (index, value) {
                _SubTotal  += value.SubTotalConIva;
                _Descuento += value.Descuento;
                _Total     += value.SubTotalConIva;
            });

            $("#txtModalSubTotal").val(priceFormatter(_SubTotal));
            $("#txModalDescuento").val(priceFormatter(_Descuento));
            $("#txtModalIva").val(priceFormatter(_SubTotal * (16 / 100)));
            $("#txtModalTotal").val(priceFormatter(_Total));
        },
        accion: function (value, row, index) {
            return [
                '<a class="editMembresiaTipo" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeMembresiaTipo" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-trash fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
};