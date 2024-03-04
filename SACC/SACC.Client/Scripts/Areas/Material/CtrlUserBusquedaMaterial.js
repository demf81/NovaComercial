var CtrlUserBusquedaMaterial = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_BUSQUEDA_MATERIAL') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
        };
    },
    keyEvent: function () {
        $("#txtCtrlUserBusquedaMaterialDescripcion").on("change paste keyup", function () {
            if ($("#txtCtrlUserBusquedaMaterialDescripcion").val().trim() == "")
                $('span[data-valmsg-for="CtrlUserBusquedaMaterialDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserBusquedaMaterialDescripcion"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserBusquedaMaterial').bootstrapTable({
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
                pServicioDescripcion: $('#txtCtrlUserBusquedaMaterialDescripcion').val(),
                pServicioTipoId: -1
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Servicio + 'CtrlUserMaterialConPrecioGridJson',
                json
            );

            $('#dgDatosCtrlUserBusquedaMaterial').bootstrapTable("load", res.data.Datos);
        },
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtCtrlUserBusquedaMaterialDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="CtrlUserBusquedaMaterialDescripcion"]').text('Campo Requerido');
            $("#txtCtrlUserBusquedaMaterialDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiarCtrls: function () {
        $('#txtCtrlUserBusquedaMaterialDescripcion').val('');
        $('span[data-valmsg-for="CtrlUserBusquedaMaterialDescripcion"]').text('');

        $('#dgDatosCtrlUserBusquedaMaterial').bootstrapTable('removeAll');
    }
}