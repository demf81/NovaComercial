$(function () {
    ContratoTipo.inicializa($("#txtApuntadorContratoTipo").val());
});




var ContratoTipo = {
    evento: null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'CONTRATO_TIPO_INDEX') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'CONTRATO_TIPO_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'CONTRATO_TIPO_EDIT') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'CONTRATO_TIPO_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pContratoTipoId: $('#txtContratoTipoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoTipo + 'ContratoTipoElementoJson',
            json
        );

        if (res != null) {
            $("#txtContratoTipoDescripcion").val(res.data.Datos[0].ContratoTipoDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ContratoTipoId: 0,
            ContratoTipoDescripcion: $("#txtContratoTipoDescripcion").val().trim()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoTipo + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ContratoTipo.redirecciona('CONTRATO_TIPO_INDEX'); }, 2000);
                else
                    this.redirecciona('CONTRATO_TIPO_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ContratoTipoId: $("#txtContratoTipoId").val(),
            ContratoTipoDescripcion: $("#txtContratoTipoDescripcion").val().trim(),
            EstatusId: ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoTipo + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ContratoTipo.redirecciona('CONTRATO_TIPO_INDEX'); }, 2000);
                else
                    this.redirecciona('CONTRATO_TIPO_INDEX');
    },
    //cambioEstatus: function () {

    //},
    baja: function () {
        swal({
            title: "¿Estás seguro de eliminar permanentemente el registro?",
            text: "",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Si",
            cancelButtonText: "No",
            closeOnConfirm: false,
            closeOnCancel: false
        },
            function (isConfirm) {
                if (isConfirm) {
                    swal.close();

                    var _obj = {
                        ContratoTipoId: $("#txtContratoTipoId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.ContratoTipo + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { ContratoTipo.redirecciona('CONTRATO_TIPO_INDEX'); }, 2000);
                            else
                                this.redirecciona('CONTRATO_TIPO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtContratoTipoDescripcion").on("change paste keyup", function () {
            if ($("#txtContratoTipoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="ContratoTipoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ContratoTipoDescripcion"]').text('');
        });
    },
    keyEventGrid: function () {
        $('#dgDatosContrato').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosContrato tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.ContratoTipo + "ContratoTipoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosContratoTipo').bootstrapTable({
                pagination: true,
                search: false,
                columns: [
                    {
                        field: 'ContratoTipoId',
                        title: 'Folio',
                        sortable: true,
                        align: 'center'
                    },
                    {
                        field: 'ContratoTipoDescripcion',
                        title: 'Descripción',
                        sortable: true,
                        align: 'left'
                    },
                    {
                        field: 'EstatusId',
                        title: 'Activo',
                        sortable: false,
                        formatter: 'EstatusIdFormatter',
                        align: 'center'
                    },
                    {
                        field: '',
                        title: 'Acción',
                        sortable: true,
                        formatter: this.accion(),
                        events: 'ContratoTipo_ActionEvents',
                        align: 'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pContratoTipoDescripcion: $('#txtContratoTipoDescripcion').val().trim(),
                pEstatusId: $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ContratoTipo + 'ContratoTipoGridJson',
                json
            );

            $('#dgDatosContratoTipo').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editContratoTipo" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeContratoTipo" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-trash fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtContratoTipoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ContratoTipoDescripcion"]').text('Campo Requerido');
            $("#txtContratoTipoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtContratoTipoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ContratoTipoDescripcion"]').text('Campo Requerido');
            $("#txtContratoTipoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('CONTRATO_TIPO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'CONTRATO_TIPO_INDEX') {
            $(location).attr('href', URL.ContratoTipo);
        };

        if (evento == 'CONTRATO_TIPO_CREATE') {
            $(location).attr('href', URL.ContratoTipo + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtContratoTipoDescripcion').val('');

        $('span[data-valmsg-for="ContratoTipoDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtContratoTipoDescripcion', isDisabled);
    }
};




window.ContratoTipo_ActionEvents = {
    'click .editContratoTipo': function (e, value, row, index) {
        $(location).attr('href', URL.ContratoTipo + 'Edit?pContratoTipoId=' + row.ContratoTipoId);
    },
    'click .removeContratoTipo': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.ContratoTipo + 'Delete?pContratoTipoId=' + row.ContratoTipoId);
    }
};