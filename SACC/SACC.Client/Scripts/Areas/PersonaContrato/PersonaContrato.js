$(function () {
    PersonaContrato.inicializa($("#txtApuntadorPersonaContrato").val());
});




var PersonaContrato = {
    evento:                    null,
    inicializa:                function (evento) {
        this.evento = evento;

        if (this.evento == 'PERSONA_CONTRATO_INDEX') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    guardar:                   function () {
        var data = $('#dgDatosCtrlUserBusquedaContrato').bootstrapTable('getSelections');

        if (data.length == 0) {
            swal("Debe seleccionar al menos un contrato", "", "warning");
            return;
        }
        
        var _listContratos = [];

        $.each(data, function (index, value) {
            var contrato = {
                PersonaContratoId: 0,
                PersonaId:         $("#txtPersonaId").val(),
                ContratoId:        value.ContratoId
            }

            _listContratos.push(contrato);
        });

        var objJSON = {
            list: _listContratos
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.PersonaContrato + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { PersonaContrato.redirecciona('PERSONA_CONTRATO_INDEX'); }, 2000);
                else
                    this.redirecciona('PERSONA_CONTRATO_INDEX');

        $("#myModalContrato").modal('hide');
    },
    activaCobertura:           function () {
        var data = $('#dgDatosCtrlUserPersonaCobertura').bootstrapTable('getSelections');

        if (data.length == 0) {
            swal("Debe seleccionar al menos un contrato", "", "warning");
            return;
        }

        var _listCobertura = [];

        $.each(data, function (index, value) {
            var cobertura = {
                Seleccionado:            value.Seleccionado,
                PersonaContratoId:       value.PersonaContratoId,
                PersonaId:               $("#txtPersonaId").val(),
                EntidadDescripcion:      "",
                ContratoId:              value.ContratoId,
                ContratoDescripcion:     value.ContratoDescripcion,
                ContratoCoberturaId:     value.ContratoCoberturaId,
                ContratoTipoDescripcion: value.ContratoTipoDescripcion
            }

            _listCobertura.push(cobertura);
        });

        var objJSON = {
            list: _listCobertura
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.PersonaContrato + 'ActivaCobertura',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { PersonaContrato.redirecciona('PERSONA_CONTRATO_INDEX'); }, 2000);
                else
                    this.redirecciona('PERSONA_CONTRATO_INDEX');

        $("#myModalPersonaCobertura").modal('hide');
    },
    inactivaCobertura:         function () {
        var pPersonaId = $("#txtPersonaId").val();
        var pNombre    = $("#txtNombre").val();

        swal({
            title:              "¿Estás seguro de desactivar la cobertura?",
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

                    var objJSON = {
                        pPersonaId: pPersonaId
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.PersonaContrato + 'InactivaCobertura',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { PersonaContrato.redirecciona('PERSONA_CONTRATO_INDEX'); }, 2000);
                            else
                                this.redirecciona('PERSONA_CONTRATO_INDEX');
                }
                else {
                    swal("La acción se ha cancelado", "", "error");
                    return false;
                }
            });
    },
    baja:                      function (pPersonaContratoId) {
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
                        PersonaContratoId: pPersonaContratoId
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.PersonaContrato + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { PersonaContrato.redirecciona('PERSONA_CONTRATO_INDEX'); }, 2000);
                            else
                                this.redirecciona('PERSONA_CONTRATO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent:                  function () {
        $("#txtPersonaContratoDescripcion").on("change paste keyup", function () {
            if ($("#txtPersonaContratoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="PersonaContratoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="PersonaContratoDescripcion"]').text('');
        });
    },
    keyEventGrid:              function () {
        $('#dgDatosContrato').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosContrato tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosPersonaContrato').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'PersonaContratoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ContratoDescripcion',
                        title:     'Contrato',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'ContratoCoberturaDescripcion',
                        title:     'Cobertura Activa',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'PaqueteDescripcion',
                        title:     'Paquete Activo',
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
                        events:    'PersonaContrato_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pPersonaId: $('#txtPersonaId').val(),
                pEstatusId: 1,
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.PersonaContrato + 'PersonaContratoGridJson',
                json
            );

            $('#dgDatosPersonaContrato').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<a class="removePersonaContrato" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-close fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    validaBusqueda:            function () {
        if ($("#txtPersonaContratoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="PersonaContratoDescripcion"]').text('Campo Requerido');
            $("#txtPersonaContratoDescripcion").focus();

            return false;
        }

        return true;
    },
    redirecciona:              function (evento) {
        if (evento == 'PERSONA_INDEX') {
            $(location).attr('href', URL.Persona);
        };

        if (evento == 'PERSONA_CONTRATO_INDEX') {
            $(location).attr('href', URL.PersonaContrato + '?pPersonaId=' + $("#txtPersonaId").val() + '&pNombre=' + $("#txtNombre").val());
        };

        if (evento == 'PERSONA_CONTRATO_CREATE') {
            $(location).attr('href', URL.PersonaContrato + 'Create');
        };
    },
    //limpiarCtrls: function () {
    //    $('#txtPersonaContratoDescripcion').val('');

    //    $('span[data-valmsg-for="PersonaContratoDescripcion"]').text('');

    //    $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
    //    $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
    //    $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    //},
    //habilitaDesHabilitaCtrls: function (isDisabled) {
    //    DisabledEneableElement('txtPersonaContratoDescripcion', isDisabled);
    //}
    AbreModalContrato:         function () {
        $("#myModalContrato").modal('show');

        CtrlUserBusquedaContrato.inicializa('CTRL_USER_BUSQUEDA_CONTRATO');
    },
    AbreModalPersonaCobertura: function() {
        $("#myModalPersonaCobertura").modal('show');

        CtrlUserPersonaCobertura.inicializa('CTRL_USER_PERSONA_COBERTURA_INDEX');

        $('#dgDatosCtrlUserPersonaCoberturaDefault').bootstrapTable('removeAll');
        //GridCtrlUserPersonaCoberturaDefault($("#PersonaId").val());
    }
};




window.PersonaContrato_ActionEvents = {
    'click .removePersonaContrato': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        PersonaContrato.baja();
    }
};





//$(function () {
//    $('#dgDatosPersonaContrato').bootstrapTable({});

//    $('#dgDatosCtrlUserPersonaCoberturaDefault').bootstrapTable({});
//});

//function GridPersonaContrato(pPersonaId) {
//    $.ajax({
//        url: URL.PersonaContrato + 'PersonaContratoJson?pPersonaId=' + pPersonaId,
//        data: "",
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $('#dgDatosPersonaContrato').bootstrapTable("load", response.result.data);
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });
//};



//function GridCtrlUserPersonaCoberturaDefault(pPersonaId) {
//    $.ajax({
//        url: URL.PersonaContrato + 'PersonaContratoCoberturaDefaultJson?pPersonaId=' + pPersonaId,
//        data: "",
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $('#dgDatosCtrlUserPersonaCoberturaDefault').bootstrapTable("load", response.result.data);
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });
//};

//function GuardaPersonaCoberturaDefault() {
//    var data = $('#dgDatosCtrlUserPersonaCoberturaDefault').bootstrapTable('getSelections');

//    if (data.length == 0) {
//        swal("Debe seleccionar al menos una cobertura", "", "warning");
//        return;
//    }

//    $.ajax({
//        url: URL.PersonaContrato + 'Edit',
//        datatype: "json",
//        data: JSON.stringify(data),
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $(location).attr('href', URL.PersonaContrato + 'Index?pPersonaId=' + parseInt(data[0].PersonaId) + '&pNombre=' + data[0].CampoComplemento_NombreCompleto);
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });

//    $("#myModalCoberturaDefault").modal('hide');
//};

//function AbreModalContrato() {
//    
//};

//function GuardaPersonaContrato() {
//    var data = $('#dgDatosCtrlUserContrato').bootstrapTable('getSelections');

//    if (data.length == 0) {
//        swal("Debe seleccionar al menos un contrato", "", "warning");
//        return;
//    }

//    $.ajax({
//        url: URL.PersonaContrato + 'Create',
//        datatype: "json",
//        data: JSON.stringify(data),
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $(location).attr('href', URL.PersonaContrato + 'Index?pPersonaId=' + parseInt(data[0].EntidadId) + '&pNombre=' + data[0].EntidadDescripcion);
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });

//    $("#myModal").modal('hide');
//};

//function InactivaCobertura(pPersonaId, pNombre) {
//    
//};

//function operateActionFormatter_PersonaContrato(value, row, index) {
//    return [
//        '<a class="remove" href="' + URL.PersonaContrato + 'Delete?pPersonaContratoId=' + row.PersonaContratoId + '&pContrato=' + row.CampoComplemento_ContratoDescripcion + '&pPersonaId=' + parseInt(row.PersonaId) + '&pNombre=' + $("#Nombre").val() + '" title="Inactivar Contrato">',
//            '<i class="text-danger fa fa-times fa-lg"></i>',
//        '</a>'
//    ].join('');
//};