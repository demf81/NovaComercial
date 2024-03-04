$(document).ready(function () {
    $(".select2-chosen").select2();
});

$(function () {
    $('#dgDatosVentaUnitariaEspecial').bootstrapTable({});
    $('#dgDatosPaqueteDetalle').bootstrapTable({});
    $('#dgDatosResumen').bootstrapTable({});

    $('#wizard_EmpresaPlantaId').change(function () {
        if ($('#wizard_EmpresaPlantaId  option:selected').text() == "[Seleccione]") {
            $('span[data-valmsg-for="wizard_EmpresaPlantaId"]').text('Campo Requerido');
        }
        else {
            $('span[data-valmsg-for="wizard_EmpresaPlantaId"]').text('');
        };
    });

    $('#wizard_ContratoId').change(function () {
        if ($('#wizard_ContratoId  option:selected').text() == "[Seleccione]") {
            $('span[data-valmsg-for="wizard_ContratoId"]').text('Campo Requerido');
        }
        else {
            $('span[data-valmsg-for="wizard_ContratoId"]').text('');
        };
    });

    $('#wizard_ContratoProductoId').change(function () {
        if ($('#wizard_ContratoProductoId  option:selected').text() == "[Seleccione]") {
            $('span[data-valmsg-for="wizard_ContratoProductoId"]').text('Campo Requerido');
        }
        else {
            $('span[data-valmsg-for="wizard_ContratoProductoId"]').text('');
        };
    });

    $('#wizard_PaqueteId').change(function () {
        if ($('#wizard_PaqueteId  option:selected').text() == "[Seleccione]") {
            $('span[data-valmsg-for="wizard_PaqueteId"]').text('Campo Requerido');
        }
        else {
            $('span[data-valmsg-for="wizard_PaqueteId"]').text('');
        };
    });

    $('.input-group.date').datepicker({
        format: "yyyy--mm-dd",
        autoclose: true,
        language: 'es',
        minDate: new Date(),
        startDate: new Date()
    }).on('changeDate', function (ev) {
        //$('#FechaVigencia').val($('#wizard_FechaVigencia').val());
        $('#FechaVigencia').val(ev.date.toJSON().toString().substring(0, 10));
    });

    $('#rootwizard').bootstrapWizard({
        'tabClass': 'nav nav-pills nav-justified',
        onNext: function (tab, navigation, index) {
            if (index == 1) {
                if ($('#wizard_txtPersonaId').val() == 0) {
                    $('span[data-valmsg-for="wizard_txtPersonaId"]').text('Campo Requerido');
                    $('span[data-valmsg-for="wizard_txtNumSocio"]').text('Campo Requerido');
                    $('span[data-valmsg-for="wizard_txtNombre"]').text('Campo Requerido');

                    return false;
                }
            }


            if (index == 2) {
                if ($('#wizard_EmpresaPlantaId option:selected').text() == "[Seleccione...]") {
                    $('span[data-valmsg-for="wizard_EmpresaPlantaId"]').text('Campo Requerido');

                    return false;
                }
            }

            if (index == 3) {
                if ($('#wizard_ContratoId option:selected').text() == "[Seleccione...]") {
                    $('span[data-valmsg-for="wizard_ContratoId"]').text('Campo Requerido');

                    return false;
                }

                if ($('#wizard_ContratoProductoId option:selected').text() == "[Seleccione...]") {
                    $('span[data-valmsg-for="wizard_ContratoProductoId"]').text('Campo Requerido');

                    return false;
                }

                if ($('#wizard_PaqueteId option:selected').text() == "[Seleccione...]") {
                    $('span[data-valmsg-for="wizard_PaqueteId"]').text('Campo Requerido');

                    return false;
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

function GridVentaUnitariaEspecial(pEmpresaId, pNombre, pEstatusId) {
    $.ajax({
        url: URL.VentaUnitariaEspecial + 'VentaUnitariaEspecialJson?pEmpresaId=' + pEmpresaId + '&pNombre=' + pNombre + '&pEstatusId=' + parseInt(pEstatusId),
        data: "",
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#dgDatosVentaUnitariaEspecial').bootstrapTable("load", response.result.data);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error", "NovaSys", XMLHttpRequest.responseText)
        }
    });
};

function RegresarVentaUnitariaEspecial() {
    $.cookie("ventaUnitariaEspecialEstatusId", 0);
    $.cookie('ventaUnitariaEspecialEmpresaId', "0");

    $(location).attr('href', URL.VentaUnitariaEspecial + 'Index');
}

function AbreModalAfiliado() {
    $("#CtrlUserAsociado_NumSocio").val('');
    $("#CtrlUserAsociado_ClaveFamiliar").val('');
    $("#CtrlUserAsociado_Nombre").val('');

    $('#dgDatosCtrlUserAsociado').bootstrapTable('removeAll');

    $("#myModalAsociado").modal();
};

function AgregarAsociado() {
    var data = $('#dgDatosCtrlUserAsociado').bootstrapTable('getSelections');

    if (data.length == 0) {
        swal("Debe seleccionar un socio", "" , "warning");
        return;
    }

    $("#wizard_txtPersonaId").val(data[0].AsociadoId);
    $("#wizard_txtNumSocio").val(data[0].CampoComplemento_SocioId);
    $("#wizard_txtNombre").val(data[0].CampoComplemento_NombreCompleto);

    $("#PersonaId").val(data[0].AsociadoId);
    $("#Nombre").val(data[0].CampoComplemento_NombreCompleto);

    $('span[data-valmsg-for="wizard_txtPersonaId"]').text('');
    $('span[data-valmsg-for="wizard_txtNumSocio"]').text('');
    $('span[data-valmsg-for="wizard_txtNombre"]').text('');

    $('#lblNombreEdad').text(data[0].CampoComplemento_NombreCompleto + ' | Num. Socio: ' + data[0].CampoComplemento_SocioId + ' | Edad: ' + data[0].CampoComplemento_Edad)

    $("#myModalAsociado").modal('hide');
};

$('#wizard_EmpresaPlantaId').change(function () {
    if ($('#wizard_EmpresaPlantaId  option:selected').text() != "[Seleccione...]") {

        $("#wizard_ContratoId").empty();
        $("#wizard_ContratoId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

        $("#wizard_ProductoId").empty();
        $("#wizard_ProductoId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

        $.ajax({
            url: URL.Contrato + 'ContratoJson?pContratoDescripcion=&pContratanteId=' + $("#wizard_EmpresaPlantaId option:selected").val() + '&pEstatusId=0',
            data: "",
            type: 'POST',
            async: false,
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                for (var i = 0; i < response.result.data.length; i++) {
                    $("#wizard_ContratoId").append($("<option></option>").attr("value", response.result.data[i].ContratoId).text(response.result.data[i].ContratoDescripcion));
                };
            },
            error: function (XMLHttpRequest, success, errorThrown) {
                alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
            }
        });

        $("#EmpresaId").val($('#wizard_EmpresaPlantaId  option:selected').val());
        $("#Empresa").val($('#wizard_EmpresaPlantaId  option:selected').text());
    }
    else {
        $("#wizard_ContratoId").empty();
        $("#wizard_ContratoId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

        $("#EmpresaId").val('0');
        $("#Empresa").val('');
    }
});

$('#wizard_ContratoId').change(function () {
    if ($('#wizard_ContratoId  option:selected').text() != "[Seleccione...]") {

        $("#wizard_ContratoProductoId").empty();
        $("#wizard_ContratoProductoId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

        $.ajax({
            url: URL.ContratoProducto + 'ContratoProductoJson?pContratoId=' + $("#wizard_ContratoId  option:selected").val(),
            data: "",
            type: 'POST',
            async: false,
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                for (var i = 0; i < response.result.data.length; i++) {
                    $("#wizard_ContratoProductoId").append($("<option></option>").attr("value", response.result.data[i].ContratoProductoId).text(response.result.data[i].ContratoProductoDescripcion));
                };
            },
            error: function (XMLHttpRequest, success, errorThrown) {
                alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
            }
        });

        $("#ContratoId").val($('#wizard_ContratoId  option:selected').val());
        $("#Contrato").val($('#wizard_ContratoId  option:selected').text());
    }
    else {
        $("#wizard_ContratoProductoId").empty();
        $("#wizard_ContratoProductoId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

        $("#wizard_ProductoId").empty();
        $("#wizard_ProductoId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

        $("#ContratoId").val('0');
        $("#Contrato").val('');
    }
});

$('#wizard_ContratoProductoId').change(function () {
    if ($('#wizard_ContratoProductoId  option:selected').text() != "[Seleccione...]") {
        $.ajax({
            url: URL.ContratoProductoPaquete + 'ContratoProductoPaqueteJson?_opcion=1&pContratoProductoId=' + $("#wizard_ContratoProductoId option:selected").val(),
            data: "",
            type: 'POST',
            async: false,
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                $("#wizard_PaqueteId").empty();

                $("#wizard_PaqueteId").empty();
                $("#wizard_PaqueteId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

                for (var i = 0; i < response.result.data.length; i++) {
                    $("#wizard_PaqueteId").append($("<option></option>").attr("value", response.result.data[i].PaqueteId).text(response.result.data[i].CampoComplemento_PaqueteDescripcion));
                };
            },
            error: function (XMLHttpRequest, success, errorThrown) {
                alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
            }
        });

        $.ajax({
            url: URL.ContratoProducto + 'ContratoProductoItem?pContratoProductoId=' + $("#wizard_ContratoProductoId option:selected").val(),
            data: "",
            type: 'POST',
            async: false,
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                $("#PorcentajeUtilidadSobreTarifa").val(response.result.data[0].PorcentajeUtilidadSobreTarifa);
                $("#PorcentajeCopagoContratante").val(response.result.data[0].PorcentajeCopagoContratante);
                $("#PorcentajeDescuentoSobreTarifa").val(response.result.data[0].PorcentajeDescuentoSobreTarifa);
            },
            error: function (XMLHttpRequest, success, errorThrown) {
                alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
            }
        });
    }
    else {

        $("#wizard_PaqueteId").empty();
        $("#wizard_PaqueteId").append($("<option></option>").attr("value", 0).text("[Seleccione...]"));

        $("#PorcentajeUtilidadSobreTarifa").val('0');
        $("#PorcentajeCopagoContratante").val('0');
        $("#PorcentajeDescuentoSobreTarifa").val('0');
    }
});

$('#wizard_PaqueteId').change(function () {
    if ($('#wizard_PaqueteId  option:selected').text() != "[Seleccione...]") {
        $.ajax({
            url: URL.PaqueteDetalle + 'PaquetedetalleList?pPaqueteId=' + $('#wizard_PaqueteId  option:selected').val(),
            data: "",
            type: 'POST',
            async: false,
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                $('#dgDatosPaqueteDetalle').bootstrapTable('removeAll');

                $('#dgDatosPaqueteDetalle').bootstrapTable("load", response.result.data);
            },
            error: function (XMLHttpRequest, success, errorThrown) {
                alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
            }
        });

        $("#VentaUnitariaDescripcion").val($('#wizard_PaqueteId  option:selected').text());

        $.ajax({
            url: URL.ContratoProductoPaquete + 'ContratoProductoPaqueteConPrecioList?pContratoProductoId=' + $("#wizard_ContratoProductoId option:selected").val() + '&pPaqueteId=' + $("#wizard_PaqueteId option:selected").val() + '&pPersonaId=0&pDescripcion=',
            data: "",
            type: 'POST',
            async: false,
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                $('#dgDatosResumen').bootstrapTable('removeAll');
                $('#dgDatosResumen').bootstrapTable("load", response.result.data);

                CalculaTotal();
            },
            error: function (XMLHttpRequest, success, errorThrown) {
                alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
            }
        });   
    }
    else {
        $('#dgDatosPaqueteDetalle').bootstrapTable('removeAll');

        $("#VentaUnitariaDescripcion").val('');

        $('#dgDatosResumen').bootstrapTable('removeAll');
    }
});

function GuardaVentaUnitariaEspecial() {

    var obj = {
        wizard_txtNumSocio: $("#wizard_txtNumSocio").val(),
        wizard_txtNombre: $("#wizard_txtNombre").val(),
        wizard_EmpresaPlantaId: $("#wizard_EmpresaPlantaId").val(),
        wizard_ContratoId: $("#wizard_ContratoId").val(),
        wizard_ContratoProductoId: $("#wizard_ContratoProductoId").val(),
        wizard_PaqueteId: $("#wizard_PaqueteId").val(),
        wizard_txtFechaVigencia: new Date(),
        VentaUnitariaId: 0,
        VentaUnitariaDescripcion: $("#VentaUnitariaDescripcion").val(),
        VentaTipoId: 0,
        EmpresaId: $("#EmpresaId").val(),
        Empresa: $("#Empresa").val(),
        TitularId: $("#PersonaId").val(),
        PersonaId: $("#PersonaId").val(),
        Nombre: $("#Nombre").val(),
        ContratoId: $("#ContratoId").val(),
        Contrato: $("#Contrato").val(),
        //VigenciaInicio: ConvertString_ToDate($("#FechaVigencia").val()),
        //VigenciaTermino: ConvertString_ToDate($("#FechaVigencia").val()),
        FechaVigencia: $("#FechaVigencia").val() + ' 23:59:59.000',
        AutorizacionId: 0,
        EsquemaPrePago: ($("#EsquemaPrePago").is(':checked') ? true : false),
        CobroAnticipado: ($("#CobroAnticipado").is(':checked') ? true : false),
        CobroAnticipadoMonto: 0,
        MontoLimite: 0,
        PrecioCobertura: false,
        PorcentajeUtilidadSobreTarifa: $("#PorcentajeUtilidadSobreTarifa").val(),
        CopagoTipoId: 0,
        PorcentajeCopagoContratante: $("#PorcentajeCopagoContratante").val(),
        PorcentajeDescuentoSobreTarifa: $("#PorcentajeDescuentoSobreTarifa").val(),
        Total: $("#Total").val(),
        EstatusId: 1,
        ManejaPrecioLista: false,
    };

    var _data = $('#dgDatosResumen').bootstrapTable('getData');
    
    var objJSON = {
        model: obj,
        list: _data
    };

    $.ajax({
        url: URL.VentaUnitariaEspecial + 'Create',
        datatype: "json",
        data: JSON.stringify(objJSON),
        type: 'POST',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $(location).attr('href', URL.VentaUnitariaEspecial + 'Index');
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert('Error' + XMLHttpRequest + ' ' + XMLHttpRequest);
        }
    });
};

function CantidadFormatter(value) {
    return (1)
}

function AmparadoFormatter(value) {
    return [
        '<i class="text-success"><span>Amparado</span></i>'
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

function operateDeleteDetalleFormatter(value, row, index) {
    return [
        '<a class="remove" href="javascript:void(0)" title="Eliminar">',
        '<i class="text-danger fa fa-times fa-lg"></i>',
        '</a>'
    ].join('');
}

window.operateDeleteDetalleEvents = {
    'click .remove': function (e, value, row, index) {
        var $table = $('#dgDatosResumen');
        $table.bootstrapTable('remove', {
            field: 'ArticuloDescripcion',
            values: [row.ArticuloDescripcion]
        });

        $('#dgDatosPaqueteDetalle').bootstrapTable('removeAll');
        $("#VentaUnitariaDescripcion").val('');

        CalculaTotal();
    }
};

function operateActionFormatter_VentaUnitariaEspecial(value, row, index) {
    return [
        '<a class="edit" href="' + URL.VentaUnitariaEspecial + 'Edit?pVentaUnitariaId=' + row.VentaUnitariaId + '" title="Editar">',
            '<i class="text-success fa fa-pencil fa-lg"></i>',
        '</a>'
    ].join('');
};