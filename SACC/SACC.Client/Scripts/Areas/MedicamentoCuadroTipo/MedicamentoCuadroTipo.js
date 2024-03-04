$(function () {
    MedicamentoCuadroTipo.inicializa($("#txtApuntadorMedicamentoCuadroTipo").val());
});




var MedicamentoCuadroTipo = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'MEDICAMENTO_CUADRO_TIPO_INDEX') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'MEDICAMENTO_CUADRO_TIPO_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'MEDICAMENTO_CUADRO_TIPO_EDIT') {
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

        if (this.evento == 'MEDICAMENTOCUADRO_TIPO_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pMedicamentoCuadroTipoId: $('#txtMedicamentoCuadroTipoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.MedicamentoCuadroTipo + 'MedicamentoCuadroTipoElementoJson',
            json
        );

        if (res != null) {
            $("#txtMedicamentoCuadroTipoDescripcion").val(res.data.Datos[0].MedicamentoCuadroTipoDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            MedicamentoCuadroTipoId:          0,
            MedicamentoCuadroTipoDescripcion: $("#txtMedicamentoCuadroTipoDescripcion").val().trim()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.MedicamentoCuadroTipo + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { MedicamentoCuadroTipo.redirecciona('MEDICAMENTOCUADRO_TIPO_INDEX'); }, 2000);
                else
                    this.redirecciona('MEDICAMENTOCUADRO_TIPO_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            MedicamentoCuadroTipoId:          $("#txtMedicamentoCuadroTipoId").val(),
            MedicamentoCuadroTipoDescripcion: $("#txtMedicamentoCuadroTipoDescripcion").val().trim(),
            EstatusId:                        ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.MedicamentoCuadroTipo + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { MedicamentoCuadroTipo.redirecciona('MEDICAMENTOCUADRO_TIPO_INDEX'); }, 2000);
                else
                    this.redirecciona('MEDICAMENTOCUADRO_TIPO_INDEX');
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
                        MedicamentoCuadroTipoId: $("#txtMedicamentoCuadroTipoId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.MedicamentoCuadroTipo + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { MedicamentoCuadroTipo.redirecciona('MEDICAMENTOCUADRO_TIPO_INDEX'); }, 2000);
                            else
                                this.redirecciona('MEDICAMENTOCUADRO_TIPO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtMedicamentoCuadroTipoDescripcion").on("change paste keyup", function () {
            if ($("#txtMedicamentoCuadroTipoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="MedicamentoCuadroTipoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="MedicamentoCuadroTipoDescripcion"]').text('');
        });
    },
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.MedicamentoCuadroTipo + "MedicamentoCuadroTipoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosMedicamentoCuadroTipo').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'MedicamentoCuadroTipoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'MedicamentoCuadroTipoDescripcion',
                        title:     'Tipo de MEDICAMENTOCUADRO',
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
                        field:      '',
                        title:      'Acción',
                        sortable:   true,
                        formatter:  this.accion(),
                        events:     'MedicamentoCuadroTipo_ActionEvents',
                        align:      'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pMedicamentoCuadroTipoDescripcion: $('#txtMedicamentoCuadroTipoDescripcion').val().trim(),
                pEstatusId:                        $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.MedicamentoCuadroTipo + 'MedicamentoCuadroTipoGridJson',
                json
            );

            $('#dgDatosMedicamentoCuadroTipo').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editMedicamentoCuadroTipo" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeMedicamentoCuadroTipo" href="javascript:void(0)" title="Inactivo">',
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
        if ($("#txtMedicamentoCuadroTipoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="MedicamentoCuadroTipoDescripcion"]').text('Campo Requerido');
            $("#txtMedicamentoCuadroTipoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtMedicamentoCuadroTipoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="MedicamentoCuadroTipoDescripcion"]').text('Campo Requerido');
            $("#txtMedicamentoCuadroTipoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('MEDICAMENTOCUADRO_TIPO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'MEDICAMENTOCUADRO_TIPO_INDEX') {
            $(location).attr('href', URL.MedicamentoCuadroTipo);
        };

        if (evento == 'MEDICAMENTOCUADRO_TIPO_CREATE') {
            $(location).attr('href', URL.MedicamentoCuadroTipo + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtMedicamentoCuadroTipoDescripcion').val('');

        $('span[data-valmsg-for="MedicamentoCuadroTipoDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtMedicamentoCuadroTipoDescripcion', isDisabled);
    }
};




window.MedicamentoCuadroTipo_ActionEvents = {
    'click .editMedicamentoCuadroTipo': function (e, value, row, index) {
        $(location).attr('href', URL.MedicamentoCuadroTipo + 'Edit?pMedicamentoCuadroTipoId=' + row.MedicamentoCuadroTipoId);
    },
    'click .removeMedicamentoCuadroTipo': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.MedicamentoCuadroTipo + 'Delete?pMedicamentoCuadroTipoId=' + row.MedicamentoCuadroTipoId);
    }
};