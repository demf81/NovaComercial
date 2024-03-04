var CtrlUserBusquedaServicioTarifa = {
    evento: null,
    tabla: {
        inicializa: function (pCtrlName) {
            $('#' + pCtrlName + ' .editable').editable('toggleDisabled');

            $('#' + pCtrlName).bootstrapTable({
                pagination:      true,
                search:          false,
                clickToSelect:   true,
                showSelectTitle: false,
                columns: [
                    {
                        field:     'ServicioId',
                        title:     'Folio',
                        align:     'center'
                    },
                    {
                        field:     'ServicioDescripcion',
                        title:     'Servicio',
                        align:     'left'
                    },
                    {
                        field:     'Porcentaje',
                        title:     'Porcentaje',
                        align:     'right',
                        editable: {
                            type:  'text',
                            title: 'Debe teclear un porcentaje'
                        },
                    },
                    {
                        field:     'Ajuste',
                        title:     '% de Ajuste',
                        align:     'right',
                        editable: {
                            type:  'text',
                            title: 'Debe teclear un porcentaje'
                        },
                    },
                ]
            });
        },
        datos: function (pAreaNegocioId, pCtrlName) {
            var objJSON = {
                pAreaNegocioId: pAreaNegocioId
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Servicio + 'CtrlUSerServicioTarifaJson',
                json
            );

            $('#' + pCtrlName).bootstrapTable("load", res.data.Datos);
        },
    }
};