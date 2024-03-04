$(function () {
    ServicioMedico.inicializa($("#txtApuntadorServicioMedico").val());
});




var ServicioMedico = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'SERVICIO_MEDICO_INDEX') {
            this.keyEvent();
            this.limpiarCtrls();

            ServicioTipo.llenaCombo('ddlServicioTipoId');

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'SERVICIO_MEDICO_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'SERVICIO_MEDICO_EDIT') {
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

        if (this.evento == 'SERVICIO_MEDICO_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pServicioMedicoId: $('#txtServicioMedicoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ServicioMedico + 'ServicioMedicoElementoJson',
            json
        );

        if (res != null) {
            $("#txtServicioMedicoDescripcion").val(res.data.Datos[0].ServicioMedicoDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ServicioMedicoId:          0,
            ServicioMedicoDescripcion: $("#txtServicioMedicoDescripcion").val().trim()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ServicioMedico + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ServicioMedico.redirecciona('SERVICIO_MEDICO_INDEX'); }, 2000);
                else
                    this.redirecciona('SERVICIO_MEDICO_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ServicioMedicoId:          $("#txtServicioMedicoId").val(),
            ServicioMedicoDescripcion: $("#txtServicioMedicoDescripcion").val().trim(),
            EstatusId:                 ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ServicioMedico + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ServicioMedico.redirecciona('SERVICIO_MEDICO_INDEX'); }, 2000);
                else
                    this.redirecciona('SERVICIO_MEDICO_INDEX');
    },
    //cambioEstatus: function () {

    //},
    baja: function () {
        swal({
            title:              "¿Estás seguro de eliminar permanentemente el registro?",
            text:               "",
            type:               "warning",
            showCancelButton:   true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText:  "Si",
            cancelButtonText:   "No",
            closeOnConfirm:     false,
            closeOnCancel:      false
        },
            function (isConfirm) {
                if (isConfirm) {
                    swal.close();

                    var _obj = {
                        ServicioMedicoId: $("#txtServicioMedicoId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.ServicioMedico + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { ServicioMedico.redirecciona('SERVICIO_MEDICO_INDEX'); }, 2000);
                            else
                                this.redirecciona('SERVICIO_MEDICO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtServicioMedicoDescripcion").on("change paste keyup", function () {
            if ($("#txtServicioMedicoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="ServicioMedicoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ServicioMedicoDescripcion"]').text('');
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
            URL.ServicioMedico + "ServicioMedicoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosServicioMedico').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ServicioMedicoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    //{
                    //    field: 'CodigoServiciosMedicos',
                    //    title: 'Codigo Nexus',
                    //    sortable: true,
                    //    align: 'center'
                    //},
                    {
                        field:     'ServicioMedicoDescripcion',
                        title:     'Tipo de Membresia',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'EstatusId',
                        title:     'Activo',
                        sortable:  false,
                        formatter: 'EstatusIdFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'ServicioMedico_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pServicioMedicoDescripcion: $('#txtServicioMedicoDescripcion').val().trim(),
                pEstatusId:                 $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ServicioMedico + 'ServicioMedicoGridJson',
                json
            );

            $('#dgDatosServicioMedico').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editServicioMedico" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeServicioMedico" href="javascript:void(0)" title="Inactivo">',
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
        if ($("#txtServicioMedicoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ServicioMedicoDescripcion"]').text('Campo Requerido');
            $("#txtServicioMedicoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtServicioMedicoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ServicioMedicoDescripcion"]').text('Campo Requerido');
            $("#txtServicioMedicoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('SERVICIO_MEDICO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'SERVICIO_MEDICO_INDEX') {
            $(location).attr('href', URL.ServicioMedico);
        };

        if (evento == 'SERVICIO_MEDICO_CREATE') {
            $(location).attr('href', URL.ServicioMedico + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtServicioMedicoDescripcion').val('');

        $('span[data-valmsg-for="ServicioMedicoDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtServicioMedicoDescripcion', isDisabled);
    }
};




window.ServicioMedico_ActionEvents = {
    'click .editServicioMedico': function (e, value, row, index) {
        $(location).attr('href', URL.ServicioMedico + 'Edit?pServicioMedicoId=' + row.ServicioMedicoId);
    },
    'click .removeServicioMedico': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.ServicioMedico + 'Delete?pServicioMedicoId=' + row.ServicioMedicoId);
    }
};




//$(function () {
//    $('#dgDatosServicio').bootstrapTable({});
//});

//function GridServicio(pServicioDescripcion, pServicioTipoId, pEstatusId) {
//    var objJSON = {
//        pServicioDescripcion: pServicioDescripcion,
//        pServicioTipoId:      pServicioTipoId,
//        pEstatusId:           pEstatusId
//    };

//    var json = JSON.stringify(objJSON, null, 2);

//    var res = getJSON(
//        URL.ServicioMedico + 'ServicioMedico/ServicioMedico/ServicioGridJson',
//        json
//    );

//    $('#dgDatosServicio').bootstrapTable("load", res.data.Datos);
//};

//function RegresarServicio() {
//    $.cookie("servicioEstatusId", 0);
//    $.cookie('servicioDescripcion', "");

//    $(location).attr('href', URL.Servicio + 'Index');
//}

//function operateActionFormatter_Servicio(value, row, index) {
//    return [
//        '<a class="edit" href="' + URL.Servicio + 'Edit?pServicioId=' + row.ServicioId + '" title="Editar">',
//        '<i class="text-success fa fa-pencil fa-lg"></i>',
//        '</a>',
//        '<span>&nbsp;&nbsp;</span>',
//        '<a class="remove" href="' + URL.Servicio + 'Delete?pServicioId=' + row.ServicioId + '" title="Inactivo">',
//        '<i class="text-danger fa fa-times fa-lg"></i>',
//        '</a>'
//    ].join('');
//};