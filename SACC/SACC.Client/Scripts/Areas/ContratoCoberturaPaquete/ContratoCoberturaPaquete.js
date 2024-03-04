$(function () {
    ContratoCoberturaPaquete.inicializa($("#txtApuntadorContratoCoberturaPaquete").val());
});




var ContratoCoberturaPaquete = {
    evento:                    null,
    inicializa:                function (evento) {
        this.evento = evento;

        if (this.evento == 'CONTRATO_COBERTURA_PAQUETE_INDEX') {
            //this.keyEvent();
            //this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    guardar:                   function (data) {
        var objJSON = {
            list: data
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoCoberturaPaquete + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ContratoCoberturaPaquete.redirecciona('CONTRATO_COBERTURA_PAQUETE_INDEX'); }, 2000);
                else
                    this.redirecciona('CONTRATO_COBERTURA_PAQUETE_INDEX');
    },
    //cambioEstatus: function () {

    //},
    baja:                      function (pContratoCoberturaPaqueteId, pPaqueteDescripcion) {
        swal({
            title:              "¿Estás seguro de eliminar permanentemente el paquete (" + pPaqueteDescripcion  + ")?",
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
                        ContratoCoberturaPaqueteId: pContratoCoberturaPaqueteId
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.ContratoCoberturaPaquete + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { ContratoCoberturaPaquete.redirecciona('CONTRATO_COBERTURA_PAQUETE_INDEX'); }, 2000);
                            else
                                this.redirecciona('CONTRATO_COBERTURA_PAQUETE_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    //keyEvent: function () {
    //    $("#txtContratoCoberturaPaqueteDescripcion").on("change paste keyup", function () {
    //        if ($("#txtContratoCoberturaPaqueteDescripcion").val().trim() == "")
    //            $('span[data-valmsg-for="ContratoCoberturaPaqueteDescripcion"]').text('Campo Requerido');
    //        else
    //            $('span[data-valmsg-for="ContratoCoberturaPaqueteDescripcion"]').text('');
    //    });
    //},
    tabla: {
        inicializa: function () {
            $('#dgDatosContratoCoberturaPaquete').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ContratoCoberturaPaqueteId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'PaqueteId',
                        title:     'PaqueteId',
                        sortable:  true,
                        align:     'left',
                        visible:   false,
                    },
                    {
                        field:     'PaqueteDescripcion',
                        title:     'Paquete de Cobertura',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'TieneCondicion',
                        title:     'Tiene Condici&oacute;n',
                        sortable:   true,
                        formatter: 'EstatusTieneCondicion',
                        align:     'center'
                    },
                    {
                        field:     'TieneExclusion',
                        title:     'Tiene Excusi&oacute;n',
                        sortable:  true,
                        formatter: 'EstatusTieneExclusion',
                        align:     'center'
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
                        events:    'ContratoCoberturaPaquete_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pContratoCoberturaId: $("#txtContratoCoberturaId").val()
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ContratoCoberturaPaquete + 'ContratoCoberturaPaqueteJson',
                json
            );

            $('#dgDatosContratoCoberturaPaquete').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<a class="contratoCoberturaPaqueteCondicion" href="javascript:void(0)" title="Condiciones">',
                '<i class="text-warning fa fa-cog fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;</span>',
                '<a class="contratoCoberturaPaqueteExclusion" href="javascript:void(0)" title="Excluciones">',
                '<i class="text-info fa fa-calendar-times-o fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;</span>',
                '<a class="removeContratoCoberturaPaquete" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-close fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    //buscar: function () {
    //    if (!this.validaBusqueda()) return;

    //    this.tabla.inicializa();
    //    this.tabla.datos();
    //},
    //validaBusqueda: function () {
    //    if ($("#txtContratoCoberturaPaqueteDescripcion").val().trim() == "") {
    //        $('span[data-valmsg-for="ContratoCoberturaPaqueteDescripcion"]').text('Campo Requerido');
    //        $("#txtContratoCoberturaPaqueteDescripcion").focus();

    //        return false;
    //    }

    //    return true;
    //},
    validaGuardar:             function () {
        if ($("#txtContratoCoberturaPaqueteDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ContratoCoberturaPaqueteDescripcion"]').text('Campo Requerido');
            $("#txtContratoCoberturaPaqueteDescripcion").focus();

            return false;
        }

        return true;
    },
    //limpiar: function () {
    //    this.inicializa('CONTRATO_COBERTURA_PAQUETE_INDEX');
    //},
    redirecciona:              function (evento) {
        if (evento == 'CONTRATO_COBERTURA_INDEX') {
            $(location).attr('href', URL.ContratoCobertura + "?pContratoId=" + $("#txtContratoId").val() + "&pContratoDescripcion=" + $("#txtContratoDescripcion").val());
        };

        if (evento == 'CONTRATO_COBERTURA_PAQUETE_INDEX') {
            $(location).attr('href', URL.ContratoCoberturaPaquete + "?pContratoCoberturaId=" + $("#txtContratoCoberturaId").val() + "&pContratoCoberturaDescripcion=" + $("#txtContratoCoberturaDescripcion").val() + "&pContratoId=" + $("#txtContratoId").val() + " & pContratoDescripcion=" + $("#txtContratoDescripcion").val());
        };

        if (evento == 'CONTRATO_COBERTURA_PAQUETE_CREATE') {
            $(location).attr('href', URL.ContratoCoberturaPaquete + 'Create');
        };
    },
    //limpiarCtrls: function () {
    //    $('#txtContratoCoberturaPaqueteDescripcion').val('');

    //    $('span[data-valmsg-for="ContratoCoberturaPaqueteDescripcion"]').text('');

    //    $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
    //    $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
    //    $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    //},
    //habilitaDesHabilitaCtrls: function (isDisabled) {
    //    DisabledEneableElement('txtContratoCoberturaPaqueteDescripcion', isDisabled);
    //}
    AbreModalPaqueteCobertura: function () {
        $("#myModalPaquetesCobertura").modal();

        $("#txtCtrlUserBusqueadaPaqueteDescripcion").val("");

        $('#dgDatosCtrlUserBusquedaPaquete').bootstrapTable('removeAll');

        CtrlUserBusquedaPaquete.inicializa("CTRL_USER_BUSQUEDA_PAQUETE", "COBERTURA");
    },
    AgregarPaqueteCobertura:   function () {
        var data = $('#dgDatosCtrlUserBusquedaPaquete').bootstrapTable('getSelections');

        if (data.length == 0) {
            swal("Debe seleccionar un paquete", "", "warning");

            return;
        }

        var item         = {};
        var _listDetalle = [];

        $('span[data-valmsg-for="CtrlUserBusqueadaPaqueteDescripcion"]').text('');

        $.each(data, function (index, value) {
            item = {
                ContratoCoberturaPaqueteId: 0,
                ContratoCoberturaId:        $("#txtContratoCoberturaId").val(),
                PaqueteId:                  value.PaqueteId
            }

            _listDetalle.push(item);
        });

        ContratoCoberturaPaquete.guardar(_listDetalle);

        $("#myModalPaquetesCobertura").modal("toggle");
    },
    AbreModalCondiciones:      function (pTieneCondicion, pPaqueteDescripcion, pContratoCoberturaPaqueteId) {
        if (!pTieneCondicion) {
            $('#TituloConcicionCreate').text('(' + pPaqueteDescripcion + ')');

            ContratoCoberturaPaqueteCondicion.inicializa('CONTRATO_COBERTURA_PAQUETE_CONDICION_CREATE', pContratoCoberturaPaqueteId);

            $("#myModalCondicionesCreate").modal();
        }
        else {
            $('#TituloConcicionEdit').text('(' + pPaqueteDescripcion + ')');

            ContratoCoberturaPaqueteCondicion.inicializa('CONTRATO_COBERTURA_PAQUETE_CONDICION_EDIT', pContratoCoberturaPaqueteId);

            $("#myModalCondicionesEdit").modal();
        }
    },
    AgregarCondicion:          function () {
        $("#myModalCondicionesCreate").modal("toggle");
    },
    AbreModalExclusion:        function (pPaqueteId, pPaqueteDescripcion, pContratoCoberturaPaqueteId) {
        $('#TituloExclusionIndex').text('(' + pPaqueteDescripcion + ')');

        ContratoCoberturaPaqueteExclusion.inicializa('CONTRATO_COBERTURA_PAQUETE_EXCLUSION_INDEX', pPaqueteId, pContratoCoberturaPaqueteId);

        $("#myModalExclusionesIndex").modal();
    },
    AgregarExclusion:          function () {
        $("#myModalExclusiones").modal("toggle");
    }
};




window.ContratoCoberturaPaquete_ActionEvents = {
    'click .contratoCoberturaPaqueteCondicion': function (e, value, row, index) {
        ContratoCoberturaPaquete.AbreModalCondiciones(row.TieneCondicion, row.PaqueteDescripcion, row.ContratoCoberturaPaqueteId);
    },
    'click .contratoCoberturaPaqueteExclusion': function (e, value, row, index) {
        ContratoCoberturaPaquete.AbreModalExclusion(row.PaqueteId, row.PaqueteDescripcion, row.ContratoCoberturaPaqueteId);
    },
    'click .removeContratoCoberturaPaquete':    function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        ContratoCoberturaPaquete.baja(row.ContratoCoberturaPaqueteId, row.PaqueteDescripcion);
        //$(location).attr('href', URL.ContratoCoberturaPaquete + 'Delete?pContratoCoberturaPaqueteId=' + row.ContratoCoberturaPaqueteId);
    }
};