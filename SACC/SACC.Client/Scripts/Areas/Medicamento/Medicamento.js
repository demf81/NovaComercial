$(function () {
    Medicamento.inicializa($("#txtApuntadorMedicamento").val());
});




var Medicamento = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'MEDICAMENTO_INDEX') {
            this.keyEvent();
            this.limpiarCtrls();

            MedicamentoCuadroTipo.llenaCombo('ddlMedicamentoCUadroTipoId');
            this.tabla.inicializa();
            this.tabla.datos();

            //$("[name='checkbox']").bootstrapSwitch({
            //    on:       'SI',
            //    off:      'NO',
            //    onClass:  'success',
            //    offClass: 'danger',
            //    size:     'xs'
            //});
        };

        if (this.evento == 'MEDICAMENTO_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'MEDICAMENTO_EDIT') {
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

        if (this.evento == 'MEDICAMENTO_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pMedicamentoId: $('#txtMedicamentoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Medicamento + 'MedicamentoElementoJson',
            json
        );

        if (res != null) {
            $("#txtMedicamentoDescripcion").val(res.data.Datos[0].MedicamentoDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            MedicamentoId: 0,
            MedicamentoDescripcion: $("#txtMedicamentoDescripcion").val().trim()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Medicamento + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Medicamento.redirecciona('MEDICAMENTO_INDEX'); }, 2000);
                else
                    this.redirecciona('MEDICAMENTO_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            MedicamentoId:          $("#txtMedicamentoId").val(),
            MedicamentoDescripcion: $("#txtMedicamentoDescripcion").val().trim(),
            EstatusId:              ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Medicamento + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Medicamento.redirecciona('MEDICAMENTO_INDEX'); }, 2000);
                else
                    this.redirecciona('MEDICAMENTO_INDEX');
    },
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
                        MedicamentoId: $("#txtMedicamentoId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Medicamento + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Medicamento.redirecciona('MEDICAMENTO_INDEX'); }, 2000);
                            else
                                this.redirecciona('MEDICAMENTO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtMedicamentoDescripcion").on("change paste keyup", function () {
            if ($("#txtMedicamentoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="MedicamentoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="MedicamentoDescripcion"]').text('');
        });
    },
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.Medicamento + "MedicamentoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosMedicamento').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'MedicamentoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'MedicamentoDescripcion',
                        title:     'Descripción',
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
                        events:    'Medicamento_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pMedicamentoDescripcion: $('#txtMedicamentoDescripcion').val().trim(),
                pEstatusId:              $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Medicamento + 'MedicamentoGridJson',
                json
            );

            $('#dgDatosMedicamento').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editMedicamento" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeMedicamento" href="javascript:void(0)" title="Inactivo">',
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
        if ($("#txtMedicamentoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="MedicamentoDescripcion"]').text('Campo Requerido');
            $("#txtMedicamentoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtMedicamentoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="MedicamentoDescripcion"]').text('Campo Requerido');
            $("#txtMedicamentoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('MEDICAMENTO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'MEDICAMENTO_INDEX') {
            $(location).attr('href', URL.Medicamento);
        };

        if (evento == 'MEDICAMENTO_CREATE') {
            $(location).attr('href', URL.Medicamento + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtMedicamentoDescripcion').val('');

        $('span[data-valmsg-for="MedicamentoDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtMedicamentoDescripcion', isDisabled);
    }
};




window.Medicamento_ActionEvents = {
    'click .editMedicamento': function (e, value, row, index) {
        $(location).attr('href', URL.Medicamento + 'Edit?pMedicamentoId=' + row.MedicamentoId);
    },
    'click .removeMedicamento': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Medicamento + 'Delete?pMedicamentoId=' + row.MedicamentoId);
    }
};



//$(function () {
//    $('#dgDatosMedicamento').bootstrapTable({});
//});

//function GridMedicamento(pMedicamentoDescripcion, pMedicamentoCuadroTipoId, pEstatusId) {
//    var objJSON = {
//        pMedicamentoDescripcion:  pMedicamentoDescripcion,
//        pMedicamentoCuadroTipoId: pMedicamentoCuadroTipoId,
//        pEstatusId:               pEstatusId
//    };

//    var json = JSON.stringify(objJSON, null, 2);

//    var res = getJSON(
//        URL.Medicamento + 'MedicamentoGridJson',
//        json
//    );

//    $('#dgDatosMedicamento').bootstrapTable("load", res.data.Datos);
//};

//function RegresarMedicamento() {
//    $.cookie("medicamentoEstatusId", 0);
//    $.cookie('medicamentoDescripcion', "");

//    $(location).attr('href', URL.Medicamento + 'Index');
//}

//function operateActionFormatter_Medicamento(value, row, index) {
//    return [
//        '<a class="view" href="' + URL.Medicamento + 'View?pMedicamentoId=' + row.MedicamentoId + '" title="Visualizar">',
//        '<i class="text-info fa fa-search fa-lg"></i>',
//        '</a>'
//    ].join('');
//};