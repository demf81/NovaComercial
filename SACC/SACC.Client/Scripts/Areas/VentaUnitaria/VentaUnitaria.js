$(function () {
    $('#dgDatosVentaUnitaria').bootstrapTable({});
    $('#dgDatosPaqueteDetalle').bootstrapTable({});
    $('#dgDatosResumen').bootstrapTable({});


    $('#wizard_ContratoId').change(function () {
        if ($('#wizard_ContratoId  option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="wizard_ContratoId"]').text('Campo Requerido');
        }
        else {
            $('span[data-valmsg-for="wizard_ContratoId"]').text('');
            $('span[data-valmsg-for="EmpresaId"]').text('');
        };
    });

    $('#wizard_CoberturaProductoId').change(function () {
        if ($('#wizard_CoberturaProductoId  option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="wizard_CoberturaProductoId"]').text('Campo Requerido');
        }
        else {
            $('span[data-valmsg-for="wizard_CoberturaProductoId"]').text('');
            $('span[data-valmsg-for="ContratoId"]').text('');
        };
    });

    $('#wizard_PaqueteId').change(function () {
        if ($('input[name="wizard_rbServicioTipoId"]:checked').val() == 'False') { // COBERTURA
        }
        else { // PRODUCTO
            if ($('#wizard_PaqueteId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="wizard_PaqueteId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="wizard_PaqueteId"]').text('');
            };
        }
    });

    $('.input-group.date').datepicker({
        format:    "yyyy-mm-dd",
        autoclose: true,
        language:  'es',
        minDate:   new Date(),
        startDate: new Date()
    }).on('changeDate', function (ev) {
        //$('#FechaVigencia').val(ConvertString_ToDate(ev.date.toJSON().toString().substring(0, 10)));
        $('#FechaVigencia').val(ev.date.toJSON().toString().substring(0, 10));
    });

    $('#rootwizard').bootstrapWizard({
        'tabClass': 'nav nav-pills nav-justified',
        onNext: function (tab, navigation, index) {
            if (index == 1) {
                if ($('#wizard_txtPersonaId').val() == 0) {
                    $('span[data-valmsg-for="wizard_txtPersonaId"]').text('Campo Requerido');
                    $('span[data-valmsg-for="wizard_txtNombre"]').text('Campo Requerido');

                    return false;
                }
            }


            if (index == 2) {
                var _rbCobertura = $('input:radio[name=wizard_rbServicioTipoId]')[0].checked;
                var _rbProducto = $('input:radio[name=wizard_rbServicioTipoId]')[1].checked;

                if (_rbCobertura == false && _rbProducto == false) {
                    $('span[data-valmsg-for="wizard_rbServicioTipoId"]').text('Campo Requerido');

                    return false;
                }
            }


            if (index == 3) {
                if ($('#wizard_ContratoId option:selected').text() == "[Seleccione...]") {
                    $('span[data-valmsg-for="wizard_ContratoId"]').text('Campo Requerido');

                    return false;
                }

                if ($('#wizard_CoberturaProductoId option:selected').text() == "[Seleccione...]") {
                    $('span[data-valmsg-for="wizard_CoberturaProductoId"]').text('Campo Requerido');

                    return false;
                }

                if ($('input[name="wizard_rbServicioTipoId"]:checked').val() == 'False') { // COBERTURA
                }
                else { // PRODUCTO
                    if ($('#wizard_PaqueteId option:selected').text() == "[Seleccione...]") {
                        $('span[data-valmsg-for="wizard_PaqueteId"]').text('Campo Requerido');

                        return false;
                    }
                }
            }


            if (index == 4) {
                if ($('#wizard_txtFechaVigencia').val() == '') {
                    $('span[data-valmsg-for="wizard_txtFechaVigencia"]').text('Campo Requerido');

                    return false;
                }
            }
        }
    });
});

function GridVentaUnitaria(pEmpresaId, pNombre, pEstatusId) {
    $.ajax({
        url:         URL.VentaUnitaria + 'VentaUnitariaJson?pEmpresaId=' + pEmpresaId + '&pNombre=' + pNombre + '&pEstatusId=' + parseInt(pEstatusId),
        data:        "",
        type:        'POST',
        async:       false,
        contentType: "application/json; charset=utf-8",
        success:     function (response) {
            $('#dgDatosVentaUnitaria').bootstrapTable("load", response.result.data);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
};

function RegresarVentaUnitaria() {
    $.cookie("ventaUnitariaEstatusId", 0);
    $.cookie('ventaUnitariaEmpresaId', "0");

    $(location).attr('href', URL.VentaUnitaria + 'VentaUnitaria/VentaUnitaria/Index');
}

function AbreModalPersona() {
    //$("#CtrlUserPersona_Nombre").val('');

    //$('#dgDatosCtrlUserPersona').bootstrapTable('removeAll');

    $("#myModalBusquedaPersona").modal();

    $("#txtPersonaId").val("");
    $("#txtNombrePersona").val("");

    $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('removeAll');

    CtrlUserBusquedaPersona.baja = 0;
    CtrlUserBusquedaPersona.bajaAsociado = 0;
    CtrlUserBusquedaPersona.inicializa("CTRL_USER_BUSQUEDA_PERSONA_INDEX");
};

function AgregarPersona() {
    var data = $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('getSelections');

    if (data.length == 0) {
        swal("Debe seleccionar una persona", "", "warning");
        return;
    }

    $("#wizard_txtPersonaId").val(data[0].PersonaId);
    $("#wizard_txtNombre").val(data[0].NombreCompleto);

    $("#PersonaId").val(data[0].PersonaId);
    $("#Nombre").val(data[0].NombreCompleto);

    $('span[data-valmsg-for="PersonaId"]').text('');
    $('span[data-valmsg-for="wizard_txtPersonaId"]').text('');
    $('span[data-valmsg-for="wizard_txtNombre"]').text('');

    $.ajax({
        url:         URL.PersonaContrato + 'PersonaContratoComboJson?_opcion=1&pPersonaId=' + $("#wizard_txtPersonaId").val(),
        data:        "",
        type:        'POST',
        async:       false,
        contentType: "application/json; charset=utf-8",
        success:     function (response) {
            $("#wizard_ContratoId").empty();

            for (var i = 0; i < response.data.Lista.length; i++) {
                $("#wizard_ContratoId").append($("<option></option>").attr("value", response.data.Lista[i].Value).text(response.data.Lista[i].Text));
            };

            $("#wizard_CoberturaProductoId").empty();
            $("#wizard_CoberturaProductoId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

            $("#wizard_PaqueteId").empty();
            $("#wizard_PaqueteId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
        }
    });

    $("#myModalBusquedaPersona").modal('hide');
};

$('#wizard_ContratoId').change(function () {
    if ($('#wizard_ContratoId  option:selected').text() != "[Seleccione...]") {
        var _url = "";

        $("#ContratoId").val($('#wizard_ContratoId').val());
        $("#Contrato").val($('#wizard_ContratoId  option:selected').text());
        
        $.ajax({
            url:         URL.EmpresaContrato + 'EmpresaContratoGridJson?pEmpresaContratoId=0&pEmpresaId=-1&pContratoId=' + $("#wizard_ContratoId option:selected").val() + '&pEstatusId=1',
            data:        "",
            type:        'POST',
            async:       false,
            contentType: "application/json; charset=utf-8",
            success:     function (response) {
                $("#EmpresaId").val(response.data.Datos[0].EmpresaId);
                $("#Empresa").val(response.data.Datos[0].EmpresaDescripcion);
            },
            error: function (XMLHttpRequest, success, errorThrown) {
                alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
            }
        });

        if ($('input[name="wizard_rbServicioTipoId"]:checked').val() == 'False') { // COBERTURA
            _url = URL.ContratoCobertura + 'ContratoCoberturaList?_opcion=1&pContratoId=' + $("#wizard_ContratoId option:selected").val();
            $("label[for='wizard_lblCoberturaProductoId']").text("Cobertura");
        }
        else { // PRODUCTO
            _url = URL.ContratoProducto + 'ContratoProductoList?_opcion=1&pContratoId=' + $("#wizard_ContratoId option:selected").val();
            $("label[for='wizard_lblCoberturaProductoId']").text("Producto");
        }

        $.ajax({
            url:         _url,
            data:        "",
            type:        'POST',
            async:       false,
            contentType: "application/json; charset=utf-8",
            success:     function (response) {
                $("#wizard_CoberturaProductoId").empty();

                $("#wizard_PaqueteId").empty();
                $("#wizard_PaqueteId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

                for (var i = 0; i < response.data.Lista.length; i++) {
                    $("#wizard_CoberturaProductoId").append($("<option></option>").attr("value", response.data.Lista[i].Value).text(response.data.Lista[i].Text));
                };
            },
            error: function (XMLHttpRequest, success, errorThrown) {
                alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
            }
        });
    }
});

$('#wizard_CoberturaProductoId').change(function () {
    if ($('#wizard_CoberturaProductoId  option:selected').text() != "[Seleccione...]") {
        if ($('input[name="wizard_rbServicioTipoId"]:checked').val() == 'False') { // COBERTURA
            _url = URL.ContratoCoberturaPaquete + 'ContratoCoberturaPaqueteList?_opcion=1&pContratoCoberturaId=' + $("#wizard_CoberturaProductoId option:selected").val();
        }
        else { // PRODUCTO
            _url = URL.ContratoProductoPaquete + 'ContratoProductoPaquetePaqueteJson?_opcion=1&pContratoProductoId=' + $("#wizard_CoberturaProductoId option:selected").val() + '&pPersonaId=' + $("#wizard_txtPersonaId").val();
        }

        $.ajax({
            url:         _url,
            data:        "",
            type:        'POST',
            async:       false,
            contentType: "application/json; charset=utf-8",
            success:     function (response) {
                $("#wizard_PaqueteId").empty();

                $("#wizard_PaqueteId").empty();
                //$("#wizard_PaqueteId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

                for (var i = 0; i < response.data.Lista.length; i++) {
                    $("#wizard_PaqueteId").append($("<option></option>").attr("value", response.data.Lista[i].Value).text(response.data.Lista[i].Text));
                };
            },
            error: function (XMLHttpRequest, success, errorThrown) {
                alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
            }
        });

        if ($('input[name="wizard_rbServicioTipoId"]:checked').val() == 'False') { // COBERTURA
            _url = URL.ContratoCobertura + 'ContratoCoberturaItem?pContratoCoberturaId=' + $("#wizard_CoberturaProductoId option:selected").val();
        }
        else { // PRODUCTO
            _url = URL.ContratoProducto + 'ContratoProductoElementoJson?pContratoProductoId=' + $("#wizard_CoberturaProductoId option:selected").val();
        }

        $.ajax({
            url:         _url,
            data:        "",
            type:        'POST',
            async:       false,
            contentType: "application/json; charset=utf-8",
            success:     function (response) {
                $('#wizard_TodoMedicamento').prop('checked', response.result.data[0].TodoMedicamento).iCheck('update');
                $("#wizard_TodoMaterial").prop('checked', response.result.data[0].TodoMaterial).iCheck('update');
                $("#wizard_TodoCirugia").prop('checked', response.result.data[0].TodoCirugia).iCheck('update');
                $("#wizard_TodoEstudio").prop('checked', response.result.data[0].TodoEstudio).iCheck('update');
                $("#wizard_TodoServicio").prop('checked', response.result.data[0].TodoServicio).iCheck('update');

                $("#PorcentajeUtilidadSobreTarifa").val(response.data.Datos[0].PorcentajeUtilidadSobreTarifa);
                $("#PorcentajeCopagoContratante").val(response.data.Datos[0].PorcentajeCopagoContratante);
                $("#PorcentajeDescuentoSobreTarifa").val(response.data.Datos[0].PorcentajeDescuentoSobreTarifa);
            },
            error: function (XMLHttpRequest, success, errorThrown) {
                alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
            }
        });
    }
});

$('#wizard_PaqueteId').change(function () {
    if ($('#wizard_PaqueteId  option:selected').text() != "[Seleccione...]") {
        if ($('input[name="wizard_rbServicioTipoId"]:checked').val() == 'False') { // COBERTURA

        }
        else { // PRODUCTO
            $.ajax({
                url:         URL.PaqueteDetalle + 'PaqueteDetalleListAll?pPaqueteId=' + $('#wizard_PaqueteId  option:selected').val(),
                data:        "",
                type:        'POST',
                async:       false,
                contentType: "application/json; charset=utf-8",
                success:     function (response) {
                    $('#dgDatosPaqueteDetalle').bootstrapTable('removeAll');

                    //$.each(response.result.data, function (key, value) {
                    //    response.data[key].Amparado = true;
                    //    response.result.data[key].PaqueteCoberturaId = 0;
                    //});

                    $('#dgDatosPaqueteDetalle').bootstrapTable("load", response.data.Datos);
                },
                error: function (XMLHttpRequest, success, errorThrown) {
                    alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
                }
            });

            $("#VentaUnitariaDescripcion").val($('#wizard_PaqueteId  option:selected').text());

            $.ajax({
                url:         URL.ContratoProductoPaquete + 'ContratoProductoPaqueteConPrecioList?pContratoProductoId=' + $("#wizard_CoberturaProductoId option:selected").val() + '&pPaqueteId=' + $("#wizard_PaqueteId option:selected").val() + '&pPersonaId=' + $("#wizard_txtPersonaId").val() + '&pDescripcion=',
                data:        "",
                type:        'POST',
                async:       false,
                contentType: "application/json; charset=utf-8",
                success:     function (response) {
                    $('#dgDatosResumen').bootstrapTable('removeAll');
                    $('#dgDatosResumen').bootstrapTable("load", response.data.Datos);

                    CalculaTotal();
                },
                error: function (XMLHttpRequest, success, errorThrown) {
                    alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
                }
            });
        }
    }
    else {
        $('#dgDatosPaqueteDetalle').bootstrapTable('removeAll');

        $("#VentaUnitariaDescripcion").val('');

        $('#dgDatosResumen').bootstrapTable('removeAll');
    }
});

$('input').on('ifChecked', function (event) {
    if ($('input[name="wizard_rbServicioTipoId"]:checked').val() == 'False') { // COBERTURA
        $("label[for='wizard_CoberturaProductoId']").text("Cobertura");
        $("#TipoDeServicio").val('Cobertura');

        $("#div_AddServicio").removeClass('form-group hidden').addClass('form-group');
        $("#div_DetalleCobertura").removeClass('hidden').addClass('');
    }
    else { // PRODUCTO
        $("label[for='wizard_CoberturaProductoId']").text("Producto");
        $("#TipoDeServicio").val('Producto');

        $("#div_AddServicio").removeClass('form-group').addClass('form-group hidden');
        $("#div_DetalleCobertura").removeClass('').addClass('hidden');
    }

    $('span[data-valmsg-for="wizard_rbServicioTipoId"]').text('');
    $('span[data-valmsg-for="TipoDeServicio"]').text('');
    
    $("#divWizard_ContratoId").removeClass('form-group hidden').addClass('form-group');
    $("#divWizard_CoberturaProductoId").removeClass('form-group hidden').addClass('form-group');
    $("#divWizard_PaqueteId").removeClass('form-group hidden').addClass('form-group');

    $("#wizard_ContratoId").val(0);

    $("#wizard_CoberturaProductoId").empty();
    $("#wizard_CoberturaProductoId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

    $("#wizard_PaqueteId").empty();
    $("#wizard_PaqueteId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

    $('#dgDatosPaqueteDetalle').bootstrapTable('removeAll');
    $('#dgDatosResumen').bootstrapTable('removeAll');
});

function GuardaVentaUnitaria() {
    if (!ValidaGuardar()) return;

    var _text = $('#dgDatosResumen').bootstrapTable('getData');
    if (_text.length > 0) {
        $("#VentaUnitariaDescripcion").val(_text[0].ArticuloDescripcion);
    }

    var _PaqueteCobertura = 0;

    if ($('input[name="wizard_rbServicioTipoId"]:checked').val() == 'False') {
        _PaqueteCobertura = $("#wizard_CoberturaProductoId").val();
    }

    var obj = {
        wizard_txtNumSocio:             $("#wizard_txtNumSocio").val(),
        wizard_txtNombre:               $("#wizard_txtNombre").val(),
        wizard_EmpresaPlantaId:         $("#wizard_EmpresaPlantaId").val(),
        wizard_ContratoId:              $("#wizard_ContratoId").val(),
        wizard_CoberturaProductoId:     $("#wizard_CoberturaProductoId").val(),
        wizard_PaqueteId:               $("#wizard_PaqueteId").val(),
        wizard_txtFechaVigencia:        new Date(),
        VentaUnitariaId:                0,
        VentaUnitariaDescripcion:       $("#VentaUnitariaDescripcion").val(),
        VentaTipoId:                    0,
        EmpresaId:                      $("#EmpresaId").val(),
        Empresa:                        $("#Empresa").val(),
        TitularId:                      $("#PersonaId").val(),
        PersonaId:                      $("#PersonaId").val(),
        Nombre:                         $("#Nombre").val(),
        ContratoId:                     $("#ContratoId").val(),
        Contrato:                       $("#Contrato").val(),
        FechaVigencia:                  $("#FechaVigencia").val() + ' 23:59:59.000',
        AutorizacionId:                 0,
        EsquemaPrePago:                 ($("#EsquemaPrePago").is(':checked') ? true : false),
        CobroAnticipado:                ($("#CobroAnticipado").is(':checked') ? true : false),
        CobroAnticipadoMonto:           0,
        MontoLimite:                    0,
        PrecioCobertura:                false,
        PorcentajeUtilidadSobreTarifa:  $("#PorcentajeUtilidadSobreTarifa").val(),
        CopagoTipoId:                   0,
        PorcentajeCopagoContratante:    $("#PorcentajeCopagoContratante").val(),
        PorcentajeDescuentoSobreTarifa: $("#PorcentajeDescuentoSobreTarifa").val(),
        Total:                          $("#Total").val(),
        EstatusId:                      1,
        ManejaPrecioLista:              false,
    };

    var _data = $('#dgDatosResumen').bootstrapTable('getData');

    var objJSON = {
        model: obj,
        list: _data
    };

    $.ajax({
        url:         URL.VentaUnitaria + 'Create',
        datatype:    "json",
        data:        JSON.stringify(objJSON),
        type:        'POST',
        async:       false,
        contentType: "application/json; charset=utf-8",
        success:     function (response) {
            $(location).attr('href', URL.VentaUnitaria + 'Index');
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
        }
    });
};

function ReprecesaVentaUnitaria(pVentaUnitariaId) {
    $.ajax({
        url:         URL.VentaUnitaria + 'Reprocesar?pVentaUnitariaId=' + pVentaUnitariaId,
        data:        "",
        type:        'POST',
        async:       false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $(location).attr('href', URL.VentaUnitaria + 'Index');
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
}

function AbreModalItemCobertura() {
    if ($('#wizard_txtPersonaId').val() == 0) {
        $('span[data-valmsg-for="CtrlUserPersona_Nombre"]').text('Campo Requerido')
        $('.tabbable a[href="#tab1"]').tab('show');

        return;
    }

    if ($('#wizard_ContratoId option:selected').text() == "[Seleccione...]") {
        swal({
            title: "Debe seleccionar un contrato",
            text:  "",
            type:  "warning"
        });

        $('.tabbable a[href="#tab3"]').tab('show');

        return;
    }

    if ($('#wizard_CoberturaProductoId option:selected').text() == "[Seleccione...]") {
        swal({
            title: "Debe seleccionar un producto",
            text:  "",
            type:  "warning"
        });

        $('.tabbable a[href="#tab3"]').tab('show');

        return;
    }

    if ($('input[name="wizard_rbServicioTipoId"]:checked').val() == 'False') {
        // COBERTURA
        $("#CtrlUserContratoCoberturaPaquete_TipoArticuloId").val(0);
        $("#CtrlUserContratoCoberturaPaquete_Descripcion").val('');
        $('#dgDatosCtrlUserContratoCoberturaPaquete').bootstrapTable('removeAll');

        $("#myModalAddItemCobertura").modal();
    }
};

function AgregarItemCobertura() {
    var dataArticulo = $('#dgDatosCtrlUserContratoCoberturaPaquete').bootstrapTable('getSelections');

    if (dataArticulo.length == 0) {
        swal({
            title: "Debe seleccionar al menos un artículo",
            text:  "",
            type:  "warning"
        });

        return;
    }

    var dataPrincipal = $('#dgDatosResumen').bootstrapTable('getData');

    if (dataPrincipal.length >= 1) {
        if (!ValidaDuplicados(dataPrincipal, dataArticulo)) {
            swal({
                title: "No se pueden agregar partidas duplicadas.",
                text:  "",
                type:  "warning"
            });

            return;
        };
    };

    if ($("#CtrlUserContratoCoberturaPaquete_TipoArticuloId option:selected").text() == "SERVICIOS") {
        if ($("#wizard_TodoMedicamento").is(':checked') == true) {
            $.each(dataArticulo, function (key, value) {
                dataArticulo[key].Amparado = true;
                dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
            });
        }
        else {
            if ($("#wizard_PaqueteId option:selected").val() == 0) {
                $.each(dataArticulo, function (key, value) {
                    dataArticulo[key].Amparado = false;
                    dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
                });
            }
            else {
                $.each(dataArticulo, function (key, value) {
                    dataArticulo[key].Amparado = ServicioAmparado(value.itemId, $("#wizard_PaqueteId option:selected").val());
                    dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
                });
            }
        }
    }

    if ($("#CtrlUserContratoCoberturaPaquete_TipoArticuloId option:selected").text() == "CIRUGÍAS") {
        if ($("#wizard_TodoCirugia").is(':checked') == true) {
            $.each(dataArticulo, function (key, value) {
                dataArticulo[key].Amparado = true;
                dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
            });
        }
        else {
            if ($("#wizard_PaqueteId option:selected").val() == 0) {
                $.each(dataArticulo, function (key, value) {
                    dataArticulo[key].Amparado = false;
                    dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
                });
            }
            else {
                $.each(dataArticulo, function (key, value) {
                    dataArticulo[key].Amparado = CirugiaAmparado(value.itemId, $("#wizard_PaqueteId option:selected").val());
                    dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
                });
            }
        }
    }

    if ($("#CtrlUserContratoCoberturaPaquete_TipoArticuloId option:selected").text() == "ESTUDIOS") {
        if ($("#wizard_TodoEstudio").is(':checked') == true) {
            $.each(dataArticulo, function (key, value) {
                dataArticulo[key].Amparado = true;
                dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
            });
        }
        else {
            if ($("#wizard_PaqueteId option:selected").val() == 0) {
                $.each(dataArticulo, function (key, value) {
                    dataArticulo[key].Amparado = false;
                    dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
                });
            }
            else {
                $.each(dataArticulo, function (key, value) {
                    dataArticulo[key].Amparado = EstudioAmparado(value.itemId, $("#wizard_PaqueteId option:selected").val());
                    dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
                });
            }
        }
    }

    if ($("#CtrlUserContratoCoberturaPaquete_TipoArticuloId option:selected").text() == "MATERIALES") {
        if ($("#wizard_TodoMaterial").is(':checked') == true) {
            $.each(dataArticulo, function (key, value) {
                dataArticulo[key].Amparado = true;
                dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
            });
        }
        else {
            if ($("#wizard_PaqueteId option:selected").val() == 0) {
                $.each(dataArticulo, function (key, value) {
                    dataArticulo[key].Amparado = false;
                    dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
                });
            }
            else {
                $.each(dataArticulo, function (key, value) {
                    dataArticulo[key].Amparado = MaterialAmparado(value.itemId, $("#wizard_PaqueteId option:selected").val());
                    dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
                });
            }
        }
    }

    if ($("#CtrlUserContratoCoberturaPaquete_TipoArticuloId option:selected").text() == "MEDICAMENTOS") {
        if ($("#wizard_TodoMedicamento").is(':checked') == true) {
            $.each(dataArticulo, function (key, value) {
                dataArticulo[key].Amparado = true;
                dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
            });
        }
        else {
            if ($("#wizard_PaqueteId option:selected").val() == 0) {
                $.each(dataArticulo, function (key, value) {
                    dataArticulo[key].Amparado = false;
                    dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
                });
            }
            else {
                $.each(dataArticulo, function (key, value) {
                    dataArticulo[key].Amparado = MedicamentoAmparado(value.itemId, $("#wizard_PaqueteId option:selected").val());
                    dataArticulo[key].PaqueteCoberturaId = $('#wizard_PaqueteId  option:selected').val();
                });
            }
        }
    }

    var objDetalle = [];
    var objRow = {};

    $.each(dataArticulo, function (index, value) {
        objRow = {};
        objRow['CampoComplemento_ServicioDescripcion'] = value.ArticuloDescripcion
        objRow['CampoComplemento_ServicioTipoDescripcion'] = value.ArticuloTipoDescripcion;
        objRow['Cantidad'] = 1;
        objRow['Amparado'] = value.Amparado;

        objDetalle.push(objRow);
    });

    $('#dgDatosPaqueteDetalle').bootstrapTable('append', objDetalle);

    $('#dgDatosResumen').bootstrapTable('append', dataArticulo);
    CalculaTotal();

    $("#myModalAddItemCobertura").modal('hide');
};

function ValidaGuardar() {
    if ($("#PersonaId").val() == "0" || $("#PersonaId").val() == "") {
        $('span[data-valmsg-for="wizard_txtPersonaId"]').text('Campo Requerido');
        $('span[data-valmsg-for="wizard_txtNombre"]').text('Campo Requerido');

        $('span[data-valmsg-for="PersonaId"]').text('Campo Requerido');

        $('.tab-pane a[href="#tab1"]').tab('show');

        return false;
    }

    if ($("#TipoDeServicio").val() == "") {
        $('span[data-valmsg-for="wizard_rbServicioTipoId"]').text('Campo Requerido');

        $('span[data-valmsg-for="TipoDeServicio"]').text('Campo Requerido');

        $('.tab-pane a[href="#tab2"]').tab('show');

        return false;
    }

    if ($("#EmpresaId").val() == "0" || $("#EmpresaId").val() == "") {
        $('span[data-valmsg-for="wizard_ContratoId"]').text('Campo Requerido');

        $('span[data-valmsg-for="EmpresaId"]').text('Campo Requerido');

        $('.tab-pane a[href="#tab3"]').tab('show');

        return false;
    }

    if ($("#ContratoId").val() == "0" || $("#ContratoId").val() == "") {
        $('span[data-valmsg-for="wizard_CoberturaProductoId"]').text('Campo Requerido');

        $('span[data-valmsg-for="ContratoId"]').text('Campo Requerido');

        $('.tab-pane a[href="#tab3"]').tab('show');

        return false;
    }

    var _text = $('#dgDatosResumen').bootstrapTable('getData');
    if (_text.length == 0) {
        $('span[data-valmsg-for="Resumen"]').text('Debe seleccionar un item');

        $('.tab-pane a[href="#tab4"]').tab('show');

        return false;
    }

    return true;
};

function CantidadFormatter(value) {
    return (1)
}

function AmparadoFormatter(value) {
    var _res   = 'No Amparado';
    var _class = 'text-danger';

    if (value) {
        _res   = 'Amparado';
        _class ='text-success'
    }
        

    return [
        '<i class="' + _class + '"><span>' + _res + '</span></i>'
    ].join('');
}

function CalculaTotal() {
    var dataDatos = $('#dgDatosResumen').bootstrapTable('getData', false);

    varTotalGrid = 0;

    $.each(dataDatos, function (clave, valor) {
        $.each(valor, function (clave2, valor2) {
            if (clave2 == "Subtotal") {
                varTotalGrid += valor2;
            }
        });
    });

    $("#Total").val(numberWithCommas(varTotalGrid.toFixed(2)));
}

function ValidaDuplicados(dataActual, dataNuevo) {
    var existe = true;

    jQuery.each(dataNuevo, function (index, value) {
        rowActual_ItemId                     = value.itemId;
        rowActual_VentaUnitariaDetalleTipoId = value.VentaUnitariaDetalleTipoId;

        jQuery.each(dataActual, function (index, value) {
            rowNuevo_ItemId                     = value.itemId;
            rowNuevo_VentaUnitariaDetalleTipoId = value.VentaUnitariaDetalleTipoId;

            if (rowActual_ItemId == rowNuevo_ItemId && rowActual_VentaUnitariaDetalleTipoId == rowNuevo_VentaUnitariaDetalleTipoId) {
                existe = false;
            };
        });
    });

    return existe;
};

function operateDeleteDetalleFormatter(value, row, index) {
    return [
        '<a class="remove" href="javascript:void(0)" title="Eliminar">',
        '<i class="text-danger fa fa-times fa-lg"></i>',
        '</a>'
    ].join('');
}

window.operateDeleteDetalleEvents = {
    'click .remove': function (e, value, row, index) {
        var $tableResumen = $('#dgDatosResumen');
        $tableResumen.bootstrapTable('remove', {
            field: 'ArticuloDescripcion',
            values: [row.ArticuloDescripcion]
        });

        var $tableDetalle = $('#dgDatosPaqueteDetalle');
        $tableDetalle.bootstrapTable('remove', {
            field: 'CampoComplemento_ServicioDescripcion',
            values: [row.ArticuloDescripcion]
        });

        $("#VentaUnitariaDescripcion").val('');

        CalculaTotal();
    }
};

function operateActionFormatter_VentaUnitaria(value, row, index) {
    return [
        '<a class="edit" href="' + URL.VentaUnitaria + 'Edit?pVentaUnitariaId=' + row.VentaUnitariaId + '" title="Editar">',
            '<i class="text-success fa fa-pencil fa-lg"></i>',
        '</a>'
    ].join('');
};