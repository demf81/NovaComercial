var CtrlUserBusquedaEmpresa = {
    inicializa: function (evento) {
        this.evento = evento;

        //this.limpiarCtrls();

        //this.tabla.inicializa();
        //this.tabla.datos();


        if (this.evento == 'CTRL_USER_BUSQUEDA_EMPRESA_INDEX') {
            this.limpiarCtrls();

            this.keyEvent();

            this.tabla.inicializa();
            //this.tabla.datos();
        };

        //if (this.evento == 'CTRLUSERBUSQUEDA_ARTICULO_TIPO_CREATE') {
        //    this.keyEvent();

        //    $("input[name=rbEstatusId][value=0]").prop("disabled", true);
        //    $("input[name=rbEstatusId][value=0]").prop('checked', true).iCheck('update');

        //    $("input[name=rbEstatusId][value=1]").prop("disabled", true);
        //    $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        //};

        //if (this.evento == 'CTRLUSERBUSQUEDA_ARTICULO_TIPO_EDIT') {
        //    this.keyEvent();

        //    this.cargaDatos();

        //    if ($("input[name=rbEstatusId][value=0]").prop('checked'))
        //        this.habilitaDesHabilitaCtrls(false);
        //    else
        //        this.habilitaDesHabilitaCtrls(true);
        //};

        //if (this.evento == 'CTRLUSERBUSQUEDA_ARTICULO_TIPO_DELETE') {
        //    this.cargaDatos();

        //    this.habilitaDesHabilitaCtrls(true);

        //    $("input[name=rbEstatusId][value=0]").prop("disabled", true);
        //    $("input[name=rbEstatusId][value=0]").prop('checked', false).iCheck('update');

        //    $("input[name=rbEstatusId][value=1]").prop("disabled", true);
        //    $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
        //};
    },
    keyEvent: function () {
        $("#txtCtrlUserNombreEmpresa").on("change paste keyup", function () {
            if ($("#txtCtrlUserNombreEmpresa").val() == "")
                $('span[data-valmsg-for="CtrlUserNombreEmpresa"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserNombreEmpresa"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserBusquedaEmpresa').bootstrapTable({
                pagination: true,
                search: false,
                columns: [
                    {
                        field: 'EmpresaId',
                        title: 'Folio',
                        sortable: true,
                        align: 'center'
                    },
                    {
                        field: 'EmpresaDescripcion',
                        title: 'Nombre',
                        sortable: true,
                        align: 'left'
                    },
                    {
                        field: 'state',
                        title: '',
                        checkbox: true
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pEmpresaDescripcion: $('#txtCtrlUserNombreEmpresa').val()
            };


            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Empresa + 'CtrlUserBusquedaEmpresaJson',
                json
            );

            $('#dgDatosCtrlUserBusquedaEmpresa').bootstrapTable("load", res.data.Datos);
        }
        //accion: function (value, row, index) {
        //    return [
        //        '<a class="editServicioTipo" href="javascript:void(0)" title="Editar">',
        //        '<i class="text-success fa fa-pencil fa-lg"></i>',
        //        '</a>',
        //        '<span>&nbsp;&nbsp;</span>',
        //        '<a class="removeServicioTipo" href="javascript:void(0)" title="Inactivo">',
        //        '<i class="text-danger fa fa-times fa-lg"></i>',
        //        '</a>'
        //    ].join('');
        //}
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtCtrlUserNombreEmpresa").val() == "") {
            $('span[data-valmsg-for="CtrlUserNombreEmpresa"]').text('Campo Requerido');
            $("#txtCtrlUserNombreEmpresa").focus();

            return false;
        }

        return true;
    },
    limpiarCtrls: function () {
        $('#txtCtrlUserNombreEmpresa').val('');
    }
};