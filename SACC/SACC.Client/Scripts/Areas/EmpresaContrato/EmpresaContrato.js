$(function () {
    EmpresaContrato.inicializa($("#txtApuntadorEmpresaContrato").val());
});




var EmpresaContrato = {
    evento:            null,
    inicializa:        function (evento) {
        this.evento = evento;

        if (this.evento == 'EMPRESA_CONTRATO_INDEX') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    guardar:           function () {
        var data = $('#dgDatosCtrlUserBusquedaContrato').bootstrapTable('getSelections');

        if (data.length == 0) {
            swal("Debe seleccionar al menos un contrato", "", "warning");

            return;
        }

        $("#myModalContrato").modal('hide');

        var _listContratos = [];

        $.each(data, function (index, value) {
            var contrato = {
                EmpresaContratoId: 0,
                EmpresaId:         $("#txtEmpresaId").val(),
                ContratoId:        value.ContratoId
            }

            _listContratos.push(contrato);
        });

        var objJSON = {
            list: _listContratos
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.EmpresaContrato + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { EmpresaContrato.redirecciona('EMPRESA_CONTRATO_INDEX'); }, 2000);
                else
                    this.redirecciona('EMPRESA_CONTRATO_INDEX');
    },
    baja:              function (pEmpresaContratoId, pContratoDescripcion) {
        swal({
            title:              "¿Estás seguro de eliminar permanentemente el congrato (" + pContratoDescripcion + ")?",
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
                    EmpresaContratoId: pEmpresaContratoId
                };

                var objJSON = {
                    model: _obj
                };

                var json = JSON.stringify(objJSON, null, 2);

                var res = getJSON(
                    URL.EmpresaContrato + 'Delete',
                    json
                );

                if (res != null)
                    if (!res.data.Error)
                        if (res.data.MuestraAlert)
                            setTimeout(function () { EmpresaContrato.redirecciona('EMPRESA_CONTRATO_INDEX'); }, 2000);
                        else
                            this.redirecciona('EMPRESA_CONTRATO_INDEX');
            }
            else {
                swal.close();
            }
        });
    },
    llenaCombo:        function (pCtrlName, pOpcion, pEmpresaId) {
        var res = getJSON(
            URL.EmpresaContrato + "EmpresaContratoComboJson?_opcion=" + pOpcion + "&pEmpresaId=" + pEmpresaId,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosEmpresaContrato').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'EmpresaContratoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ContratoId',
                        title:     'ContratoId',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ContratoDescripcion',
                        title:     'Contrato',
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
                        events:    'EmpresaContrato_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pEmpresaId:  $('#txtEmpresaId').val().trim(),
                pContratoId: -1,
                pEstatusId:  ESTATUS_ENTIDAD.ACTIVO,
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.EmpresaContrato + 'EmpresaContratoGridJson',
                json
            );

            $('#dgDatosEmpresaContrato').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<a class="removeEmpresaContrato" href="javascript:void(0)" title="Eliminar">',
                '<i class="text-danger fa fa-close fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    validaGuardar:     function () {
        if ($("#txtEmpresaContratoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="EmpresaContratoDescripcion"]').text('Campo Requerido');
            $("#txtEmpresaContratoDescripcion").focus();

            return false;
        }

        return true;
    },
    redirecciona:      function (evento) {
        if (evento == 'EMPRESA_INDEX') {
            $(location).attr('href', URL.Empresa);
        };

        if (evento == 'EMPRESA_CONTRATO_INDEX') {
            $(location).attr('href', URL.EmpresaContrato + '?pEmpresaId=' + $('#txtEmpresaId').val() + '&pEmpresaDescripcion=' + $('#txtEmpresaDescripcion').val());
        };
    },
    AbreModalContrato: function () {
        $("#myModalContrato").modal('show');

        CtrlUserBusquedaContrato.inicializa('CTRL_USER_BUSQUEDA_CONTRATO');
    },
};




window.EmpresaContrato_ActionEvents = {
    'click .removeEmpresaContrato': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        EmpresaContrato.baja(row.EmpresaContratoId, row.ContratoDescripcion);
        //$(location).attr('href', URL.EmpresaContrato + 'Delete?pEmpresaContratoId=' + row.EmpresaContratoId);
    }
};