$(function () {
    ContratoProducto.inicializa($("#txtApuntadorContratoProducto").val());
});




var ContratoProducto = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'CONTRATO_PRODUCTO_INDEX') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'CONTRATO_PRODUCTO_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            InicializarDtpClass('.input-group.date');
            $('.input-group.date').datepicker('update', new Date());
        };

        if (this.evento == 'CONTRATO_PRODUCTO_EDIT') {
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

        if (this.evento == 'CONTRATO_PRODUCTO_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:               function () {
        var objJSON = {
            pContratoProductoId: $('#txtContratoProductoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoProducto + 'ContratoProductoElementoJson',
            json
        );

        if (res != null) {
            $("#txtContratoProductoDescripcion").val(res.data.Datos[0].ContratoProductoDescripcion);

            if (res.data.Datos[0].EsquemaPrePago == true)
                $("input[name=chkPrePago]").prop('checked', true).iCheck('update');
            else
                $("input[name=chkPrePago]").prop('checked', false).iCheck('update');

            if (res.data.Datos[0].CobroAnticipado == true)
                $("input[name=chkCobroAnticipado]").prop('checked', true).iCheck('update');
            else
                $("input[name=chkCobroAnticipado]").prop('checked', false).iCheck('update');

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
            ContratoProductoId:             0,
            ContratoId:                     $("#txtContratoId").val(),
            ContratoProductoDescripcion:    $("#txtContratoProductoDescripcion").val().trim(),
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
            URL.ContratoProducto + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ContratoProducto.redirecciona('CONTRATO_PRODUCTO_INDEX'); }, 2000);
                else
                    this.redirecciona('CONTRATO_PRODUCTO_INDEX');
    },
    actualizar:               function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ContratoProductoId:             $("#txtContratoProductoId").val(),
            ContratoId:                     $("#txtContratoId").val(),
            ContratoProductoDescripcion:    $("#txtContratoProductoDescripcion").val().trim(),
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
            URL.ContratoProducto + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ContratoProducto.redirecciona('CONTRATO_PRODUCTO_INDEX'); }, 2000);
                else
                    this.redirecciona('CONTRATO_PRODUCTO_INDEX');
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
                        ContratoProductoId: $("#txtContratoProductoId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.ContratoProducto + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { ContratoProducto.redirecciona('CONTRATO_PRODUCTO_INDEX'); }, 2000);
                            else
                                this.redirecciona('CONTRATO_PRODUCTO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent:                 function () {
        $("#txtContratoProductoDescripcion").on("change paste keyup", function () {
            if ($("#txtContratoProductoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="ContratoProductoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ContratoProductoDescripcion"]').text('');
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
    llenaCombo:               function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.ContratoProducto + "ContratoProductoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosContratoProducto').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ContratoProductoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ContratoProductoDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
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
                        events:    'ContratoProducto_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pContratoId: $('#txtContratoId').val()
                //pContratoProductoDescripcion: $('#txtContratoProductoDescripcion').val().trim(),
                //pEstatusId: $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ContratoProducto + 'ContratoProductoGridJson',
                json
            );

            $('#dgDatosContratoProducto').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<a class="editContratoProducto" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="paqueteContratoProducto" href="javascript:void(0)" title="Producto">',
                '<i class="text-warning fa fa-cog fa-2x"></i>',
                '</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="condicionContratoProducto" href="javascript:void(0)" title="Condiciones">',
                //'<i class="text-primary fa fa-list-alt fa-2x"></i>',
                //'</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeContratoProducto" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-close fa-2x"></i>',
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
        if ($("#txtContratoProductoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ContratoProductoDescripcion"]').text('Campo Requerido');
            $("#txtContratoProductoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:            function () {
        if ($("#txtContratoProductoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ContratoProductoDescripcion"]').text('Campo Requerido');
            $("#txtContratoProductoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar:                  function () {
        this.inicializa('CONTRATO_PRODUCTO_INDEX');
    },
    redirecciona:             function (evento) {
        if (evento == 'CONTRATO_INDEX') {
            $(location).attr('href', URL.Contrato);
        };

        if (evento == 'CONTRATO_PRODUCTO_INDEX') {
            $(location).attr('href', URL.ContratoProducto + 'Index?pContratoId=' + $('#txtContratoId').val() + '&pContratoDescripcion=' + $('#txtContratoDescripcion').val());
        };

        if (evento == 'CONTRATO_PRODUCTO_CREATE') {
            $(location).attr('href', URL.ContratoProducto + 'Create?pContratoId=' + $('#txtContratoId').val() + '&pContratoDescripcion=' + $('#txtContratoDescripcion').val());
        };
    },
    limpiarCtrls:             function () {
        $('#txtContratoProductoDescripcion').val('');

        $('span[data-valmsg-for="ContratoProductoDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtContratoProductoDescripcion', isDisabled);
    }
};




window.ContratoProducto_ActionEvents = {
    'click .editContratoProducto':    function (e, value, row, index) {
        $(location).attr('href', URL.ContratoProducto + 'Edit?pContratoProductoId=' + row.ContratoProductoId + '&pContratoId=' + $('#txtContratoId').val() + '&pContratoDescripcion=' + $('#txtContratoDescripcion').val());
    },
    'click .paqueteContratoProducto': function (e, value, row, index) {
        $(location).attr('href', URL.ContratoProductoPaquete + 'Index?pContratoProductoId=' + row.ContratoProductoId + '&pContratoProductoDescripcion=' + row.ContratoProductoDescripcion + '&pContratoId=' + $("#txtContratoId").val() + '&pContratoDescripcion=' + $("#txtContratoDescripcion").val());
    },
    //'click .CondicionContratoProducto': function (e, value, row, index) {
    //    $(location).attr('href', URL.ContratoProducto + 'Edit?pContratoProductoId=' + row.ContratoProductoId);
    //},
    'click .removeContratoProducto':  function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.ContratoProducto + 'Delete?pContratoProductoId=' + row.ContratoProductoId);
    }
};