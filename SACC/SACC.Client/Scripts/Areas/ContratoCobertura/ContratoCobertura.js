$(function () {
    ContratoCobertura.inicializa($("#txtApuntadorContratoCobertura").val());
});




var ContratoCobertura = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'CONTRATO_COBERTURA_INDEX') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'CONTRATO_COBERTURA_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            InicializarDtpClass('.input-group.date');
            $('.input-group.date').datepicker('update', new Date());
        };

        if (this.evento == 'CONTRATO_COBERTURA_EDIT') {
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

        if (this.evento == 'CONTRATO_COBERTURA_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:               function () {
        var objJSON = {
            pContratoCoberturaId: $('#txtContratoCoberturaId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoCobertura + 'ContratoCoberturaElementoJson',
            json
        );

        if (res != null) {
            $("#txtContratoCoberturaDescripcion").val(res.data.Datos[0].ContratoCoberturaDescripcion);

            if (res.data.Datos[0].TodoMedicamento == true)
                $("input[name=chkTodoMedicamento]").prop('checked', true).iCheck('update');
            else
                $("input[name=chkTodoMedicamento]").prop('checked', false).iCheck('update');

            if (res.data.Datos[0].TodoMaterial == true)
                $("input[name=chkTodoMaterial]").prop('checked', true).iCheck('update');
            else
                $("input[name=chkTodoMaterial]").prop('checked', false).iCheck('update');

            if (res.data.Datos[0].TodoCirugia == true)
                $("input[name=chkTodoCirugia]").prop('checked', true).iCheck('update');
            else
                $("input[name=chkTodoCirugia]").prop('checked', false).iCheck('update');

            if (res.data.Datos[0].TodoEstudio == true)
                $("input[name=chkTodoEstudio]").prop('checked', true).iCheck('update');
            else
                $("input[name=chkTodoEstudio]").prop('checked', false).iCheck('update');

            if (res.data.Datos[0].TodoServicio == true)
                $("input[name=chkTodoServicio]").prop('checked', true).iCheck('update');
            else
                $("input[name=chkTodoServicio]").prop('checked', false).iCheck('update');

            if (res.data.Datos[0].EsquemaPrePago == true)
                $("input[name=chkPrePago]").prop('checked', true).iCheck('update');
            else
                $("input[name=chkPrePago]").prop('checked', false).iCheck('update');

            if (res.data.Datos[0].CobroAnticipado == true)
                $("input[name=chkCobroAnticipado]").prop('checked', true).iCheck('update');
            else
                $("input[name=chkCobroAnticipado]").prop('checked', false).iCheck('update');

            $("#dtpVigenciaDesde").val(formatFecha(res.data.Datos[0].VigenciaDesde));
            $("#dtpVigenciaHasta").val(formatFecha(res.data.Datos[0].VigenciaHasta));

            $("#txtPorcentajeUtilidadSobreTarifa").val(res.data.Datos[0].PorcentajeUtilidadSobreTarifa);
            $("#txtPorcentajeCopagoContratante").val(res.data.Datos[0].PorcentajeCopagoContratante);
            $("#txtPorcentajeDescuentoSobreTarifa").val(res.data.Datos[0].PorcentajeDescuentoSobreTarifa);

            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar:                  function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ContratoCoberturaId:            0,
            ContratoId:                     $("#txtContratoId").val(),
            ContratoCoberturaDescripcion:   $("#txtContratoCoberturaDescripcion").val().trim(),
            TodoMedicamento:                $("input[name='chkTodoMedicamento']").prop("checked"),
            TodoMaterial:                   $("input[name='chkTodoMaterial']").prop("checked"),
            TodoCirugia:                    $("input[name='chkTodoCirugia']").prop("checked"),
            TodoEstudio:                    $("input[name='chkTodoEstudio']").prop("checked"),
            TodoServicio:                   $("input[name='chkTodoServicio']").prop("checked"),
            ContratoCoberturaTipoId:        1,
            VigenciaDesde:                  $("#dtpVigenciaDesde").val(),
            VigenciaHasta:                  $("#dtpVigenciaDesde").val(),
            EsquemaPrePago:                 $("input[name='chkPrePago']").prop("checked"),
            CobroAnticipado:                $("input[name='chkCobroAnticipado']").prop("checked"),
            TarifaId:                       1,
            PorcentajeUtilidadSobreTarifa:  $("#txtPorcentajeUtilidadSobreTarifa").val(),
            PorcentajeCopagoContratante:    $("#txtPorcentajeCopagoContratante").val(),
            PorcentajeDescuentoSobreTarifa: $("#txtPorcentajeDescuentoSobreTarifa").val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoCobertura + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ContratoCobertura.redirecciona('CONTRATO_COBERTURA_INDEX'); }, 2000);
                else
                    this.redirecciona('CONTRATO_COBERTURA_INDEX');
    },
    actualizar:               function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ContratoCoberturaId:            $("#txtContratoCoberturaId").val(),
            ContratoId:                     $("#txtContratoId").val(),
            ContratoCoberturaDescripcion:   $("#txtContratoCoberturaDescripcion").val().trim(),
            TodoMedicamento:                $("input[name='chkTodoMedicamento']").prop("checked"),
            TodoMaterial:                   $("input[name='chkTodoMaterial']").prop("checked"),
            TodoCirugia:                    $("input[name='chkTodoCirugia']").prop("checked"),
            TodoEstudio:                    $("input[name='chkTodoEstudio']").prop("checked"),
            TodoServicio:                   $("input[name='chkTodoServicio']").prop("checked"),
            ContratoCoberturaTipoId:        1,
            VigenciaDesde:                  $("#dtpVigenciaDesde").val(),
            VigenciaHasta:                  $("#dtpVigenciaDesde").val(),
            EsquemaPrePago:                 $("input[name='chkPrePago']").prop("checked"),
            CobroAnticipado:                $("input[name='chkCobroAnticipado']").prop("checked"),
            TarifaId:                       1,
            PorcentajeUtilidadSobreTarifa:  $("#txtPorcentajeUtilidadSobreTarifa").val(),
            PorcentajeCopagoContratante:    $("#txtPorcentajeCopagoContratante").val(),
            PorcentajeDescuentoSobreTarifa: $("#txtPorcentajeDescuentoSobreTarifa").val(),
            EstatusId:                      ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoCobertura + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ContratoCobertura.redirecciona('CONTRATO_COBERTURA_INDEX'); }, 2000);
                else
                    this.redirecciona('CONTRATO_COBERTURA_INDEX');
    },
    //cambioEstatus: function () {

    //},
    baja:                     function () {
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
                        ContratoCoberturaId: $("#txtContratoCoberturaId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.ContratoCobertura + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { ContratoCobertura.redirecciona('CONTRATO_COBERTURA_INDEX'); }, 2000);
                            else
                                this.redirecciona('CONTRATO_COBERTURA_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent:                 function () {
        $("#txtContratoCoberturaDescripcion").on("change paste keyup", function () {
            if ($("#txtContratoCoberturaDescripcion").val().trim() == "")
                $('span[data-valmsg-for="ContratoCoberturaDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ContratoCoberturaDescripcion"]').text('');
        });
    },
    llenaCombo:               function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.ContratoCobertura + "ContratoCoberturaComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosContratoCobertura').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ContratoCoberturaId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ContratoCoberturaDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'TodoMedicamento',
                        title:     'Medicamentos',
                        sortable:  true,
                        formatter: 'EstatusContratoCoberturaTodos',
                        align:     'center'
                    },
                    {
                        field:     'TodoMaterial',
                        title:     'Materiales',
                        sortable:  true,
                        formatter: 'EstatusContratoCoberturaTodos',
                        align:     'center'
                    },
                    {
                        field:     'TodoCirugia',
                        title:     'Cirugias',
                        sortable:  true,
                        formatter: 'EstatusContratoCoberturaTodos',
                        align:     'center'
                    },
                    {
                        field:     'TodoEstudio',
                        title:     'Estudios',
                        sortable:  true,
                        formatter: 'EstatusContratoCoberturaTodos',
                        align:     'center'
                    },
                    {
                        field:     'TodoServicio',
                        title:     'Servicios',
                        sortable:  true,
                        formatter: 'EstatusContratoCoberturaTodos',
                        align:     'center'
                    },
                    {
                        field:     'PorcentajeCopagoContratante',
                        title:     'Copago',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                    },
                    {
                        field:     'PorcentajeDescuentoSobreTarifa',
                        title:     'Descuento',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                    },
                    {
                        field:     'EstatusId',
                        title:     'Activo',
                        formatter: 'EstatusIdFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        formatter: this.accion(),
                        events:    'ContratoCobertura_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pContratoId: $('#txtContratoId').val()
                //pContratoCoberturaDescripcion: $('#txtContratoCoberturaDescripcion').val().trim(),
                //pEstatusId: $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ContratoCobertura + 'ContratoCoberturaGridJson',
                json
            );

            $('#dgDatosContratoCobertura').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<a class="editContratoCobertura" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="paqueteContratoCobertura" href="javascript:void(0)" title="Paquete">',
                '<i class="text-warning fa fa-cog fa-2x"></i>',
                '</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="condicionContratoCobertura" href="javascript:void(0)" title="Condiciones">',
                //'<i class="text-primary fa fa-list-alt fa-2x"></i>',
                //'</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeContratoCobertura" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-trash fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar:                   function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda:           function () {
        if ($("#txtContratoCoberturaDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ContratoCoberturaDescripcion"]').text('Campo Requerido');
            $("#txtContratoCoberturaDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:            function () {
        if ($("#txtContratoCoberturaDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ContratoCoberturaDescripcion"]').text('Campo Requerido');
            $("#txtContratoCoberturaDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar:                  function () {
        this.inicializa('CONTRATO_COBERTURA_INDEX');
    },
    redirecciona:             function (evento) {
        if (evento == 'CONTRATO_INDEX') {
            $(location).attr('href', URL.Contrato);
        };

        if (evento == 'CONTRATO_COBERTURA_INDEX') {
            $(location).attr('href', URL.ContratoCobertura + 'Index?pContratoId=' + $('#txtContratoId').val() + '&pContratoDescripcion=' + $('#txtContratoDescripcion').val());
        };

        if (evento == 'CONTRATO_COBERTURA_CREATE') {
            $(location).attr('href', URL.ContratoCobertura + 'Create?pContratoId=' + $('#txtContratoId').val() + '&pContratoDescripcion=' + $('#txtContratoDescripcion').val());
        };
    },
    limpiarCtrls:             function () {
        $('#txtContratoCoberturaDescripcion').val('');

        $('span[data-valmsg-for="ContratoCoberturaDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtContratoCoberturaDescripcion', isDisabled);

        DisabledEneableElementCheck("input[name='chkTodoMedicamento']", isDisabled);
        DisabledEneableElementCheck("input[name='chkTodoMaterial']",    isDisabled);
        DisabledEneableElementCheck("input[name='chkTodoCirugia']",     isDisabled);
        DisabledEneableElementCheck("input[name='chkTodoEstudio']",     isDisabled);
        DisabledEneableElementCheck("input[name='chkTodoServicio']",    isDisabled);

        DisabledEneableElementCheck("input[name='chkPrePago']",         isDisabled);
        DisabledEneableElementCheck("input[name='chkCobroAnticipado']", isDisabled);

        DisabledEneableElement('txtPorcentajeUtilidadSobreTarifa',  isDisabled);
        DisabledEneableElement('txtPorcentajeCopagoContratante',    isDisabled);
        DisabledEneableElement('txtPorcentajeDescuentoSobreTarifa', isDisabled);
    }
};




window.ContratoCobertura_ActionEvents = {
    'click .editContratoCobertura':      function (e, value, row, index) {
        $(location).attr('href', URL.ContratoCobertura + 'Edit?pContratoCoberturaId=' + row.ContratoCoberturaId + '&pContratoId=' + $('#txtContratoId').val() + '&pContratoDescripcion=' + $('#txtContratoDescripcion').val());
    },
    'click .paqueteContratoCobertura':   function (e, value, row, index) {
        $(location).attr('href', URL.ContratoCoberturaPaquete + 'Index?pContratoCoberturaId=' + row.ContratoCoberturaId + '&pContratoCoberturaDescripcion=' + row.ContratoCoberturaDescripcion + '&pContratoId=' + $("#txtContratoId").val() + '&pContratoDescripcion=' + $("#txtContratoDescripcion").val());
    },
    'click .CondicionContratoCobertura': function (e, value, row, index) {
        $(location).attr('href', URL.ContratoCobertura + 'Edit?pContratoCoberturaId=' + row.ContratoCoberturaId);
    },
    'click .removeContratoCobertura':    function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.ContratoCobertura + 'Delete?pContratoCoberturaId=' + row.ContratoCoberturaId + '&pContratoId=' + $('#txtContratoId').val() + '&pContratoDescripcion=' + $('#txtContratoDescripcion').val());
    }
};