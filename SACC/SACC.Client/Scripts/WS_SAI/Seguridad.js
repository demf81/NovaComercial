$(function () {
    Seguridad.inicializa($("#txtApuntadorSeguridad").val());
});




var Seguridad = {
    evento: null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'SEGURIDAD_INDEX') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'SEGURIDAD_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'SEGURIDAD_EDIT') {
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

        if (this.evento == 'SEGURIDAD_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pSeguridadId: $('#txtSeguridadId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Seguridad + 'SeguridadElementoJson',
            json
        );

        if (res != null) {
            $("#txtSeguridadDescripcion").val(res.data.Datos[0].SeguridadDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            SeguridadId: 0,
            SeguridadDescripcion: $("#txtSeguridadDescripcion").val().trim()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Seguridad + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Seguridad.redirecciona('SEGURIDAD_INDEX'); }, 2000);
                else
                    this.redirecciona('SEGURIDAD_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            SeguridadId: $("#txtSeguridadId").val(),
            SeguridadDescripcion: $("#txtSeguridadDescripcion").val().trim(),
            EstatusId: ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Seguridad + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Seguridad.redirecciona('SEGURIDAD_INDEX'); }, 2000);
                else
                    this.redirecciona('SEGURIDAD_INDEX');
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
                        SeguridadId: $("#txtSeguridadId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Seguridad + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Seguridad.redirecciona('SEGURIDAD_INDEX'); }, 2000);
                            else
                                this.redirecciona('SEGURIDAD_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtSeguridadDescripcion").on("change paste keyup", function () {
            if ($("#txtSeguridadDescripcion").val().trim() == "")
                $('span[data-valmsg-for="SeguridadDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="SeguridadDescripcion"]').text('');
        });
    },
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.Seguridad + "SeguridadComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosSeguridad').bootstrapTable({
                pagination: true,
                search: false,
                columns: [
                    {
                        field: 'SeguridadId',
                        title: 'Folio',
                        sortable: true,
                        align: 'center'
                    },
                    {
                        field: 'SeguridadDescripcion',
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
                        events: 'Seguridad_ActionEvents',
                        align: 'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pSeguridadDescripcion: $('#txtSeguridadDescripcion').val().trim(),
                pEstatusId: $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Seguridad + 'SeguridadGridJson',
                json
            );

            $('#dgDatosSeguridad').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editSeguridad" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeSeguridad" href="javascript:void(0)" title="Inactivo">',
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
        if ($("#txtSeguridadDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="SeguridadDescripcion"]').text('Campo Requerido');
            $("#txtSeguridadDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtSeguridadDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="SeguridadDescripcion"]').text('Campo Requerido');
            $("#txtSeguridadDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('SEGURIDAD_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'SEGURIDAD_INDEX') {
            $(location).attr('href', URL.Seguridad);
        };

        if (evento == 'SEGURIDAD_CREATE') {
            $(location).attr('href', URL.Seguridad + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtSeguridadDescripcion').val('');

        $('span[data-valmsg-for="SeguridadDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtSeguridadDescripcion', isDisabled);
    }
};




window.Seguridad_ActionEvents = {
    'click .editSeguridad': function (e, value, row, index) {
        $(location).attr('href', URL.Seguridad + 'Edit?pSeguridadId=' + row.SeguridadId);
    },
    'click .removeSeguridad': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Seguridad + 'Delete?pSeguridadId=' + row.SeguridadId);
    }
};