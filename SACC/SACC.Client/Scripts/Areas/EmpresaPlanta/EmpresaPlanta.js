$(function () {
    EmpresaPlanta.inicializa($("#txtApuntadorEmpresaPlanta").val());
});




var EmpresaPlanta = {
    evento: null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'EMPRESA_PLANTA_INDEX') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'EMPRESA_PLANTA_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'EMPRESA_PLANTA_EDIT') {
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

        if (this.evento == 'EMPRESA_PLANTA_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pEmpresaPlantaId: $('#txtEmpresaPlantaId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.EmpresaPlanta + 'EmpresaPlantaElementoJson',
            json
        );

        if (res != null) {
            $("#txtEmpresaPlantaDescripcion").val(res.data.Datos[0].EmpresaPlantaDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            EmpresaPlantaId: 0,
            EmpresaPlantaDescripcion: $("#txtEmpresaPlantaDescripcion").val().trim()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.EmpresaPlanta + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { EmpresaPlanta.redirecciona('EMPRESA_PLANTA_INDEX'); }, 2000);
                else
                    this.redirecciona('EMPRESA_PLANTA_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            EmpresaPlantaId: $("#txtEmpresaPlantaId").val(),
            EmpresaPlantaDescripcion: $("#txtEmpresaPlantaDescripcion").val().trim(),
            EstatusId: ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.EmpresaPlanta + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { EmpresaPlanta.redirecciona('EMPRESA_PLANTA_INDEX'); }, 2000);
                else
                    this.redirecciona('EMPRESA_PLANTA_INDEX');
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
                        EmpresaPlantaId: $("#txtEmpresaPlantaId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.EmpresaPlanta + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { EmpresaPlanta.redirecciona('EMPRESA_PLANTA_INDEX'); }, 2000);
                            else
                                this.redirecciona('EMPRESA_PLANTA_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtEmpresaPlantaDescripcion").on("change paste keyup", function () {
            if ($("#txtEmpresaPlantaDescripcion").val().trim() == "")
                $('span[data-valmsg-for="EmpresaPlantaDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="EmpresaPlantaDescripcion"]').text('');
        });
    },
    llenaCombo: function (pCtrlName, pOpcion) {
        var res = getJSON(
            URL.EmpresaPlanta + "EmpresaPlantaComboJson?pEmpresaId=-1&_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosEmpresaPlanta').bootstrapTable({
                pagination: true,
                search: false,
                columns: [
                    {
                        field: 'EmpresaPlantaId',
                        title: 'Folio',
                        sortable: true,
                        align: 'center'
                    },
                    {
                        field: 'EmpresaPlantaDescripcion',
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
                        events: 'EmpresaPlanta_ActionEvents',
                        align: 'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pEmpresaPlantaDescripcion: $('#txtEmpresaPlantaDescripcion').val().trim(),
                pEstatusId: $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.EmpresaPlanta + 'EmpresaPlantaGridJson',
                json
            );

            $('#dgDatosEmpresaPlanta').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editEmpresaPlanta" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeEmpresaPlanta" href="javascript:void(0)" title="Inactivo">',
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
        if ($("#txtEmpresaPlantaDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="EmpresaPlantaDescripcion"]').text('Campo Requerido');
            $("#txtEmpresaPlantaDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtEmpresaPlantaDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="EmpresaPlantaDescripcion"]').text('Campo Requerido');
            $("#txtEmpresaPlantaDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('EMPRESA_PLANTA_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'EMPRESA_PLANTA_INDEX') {
            $(location).attr('href', URL.EmpresaPlanta);
        };

        if (evento == 'EMPRESA_PLANTA_CREATE') {
            $(location).attr('href', URL.EmpresaPlanta + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtEmpresaPlantaDescripcion').val('');

        $('span[data-valmsg-for="EmpresaPlantaDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtEmpresaPlantaDescripcion', isDisabled);
    }
};




window.EmpresaPlanta_ActionEvents = {
    'click .editEmpresaPlanta': function (e, value, row, index) {
        $(location).attr('href', URL.EmpresaPlanta + 'Edit?pEmpresaPlantaId=' + row.EmpresaPlantaId);
    },
    'click .removeEmpresaPlanta': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.EmpresaPlanta + 'Delete?pEmpresaPlantaId=' + row.EmpresaPlantaId);
    }
};