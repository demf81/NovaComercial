var ContratoCoberturaPaqueteExclusion = {
    evento:                     null,
    PaqueteId:                  0,
    ContratoCoberturaPaqueteId: 0,
    inicializa:      function (evento, pPaqueteId, pContratoCoberturaPaqueteId) {
        this.evento                     = evento;
        this.ContratoCoberturaPaqueteId = pContratoCoberturaPaqueteId;
        this.PaqueteId                  = pPaqueteId;

        if (this.evento == 'CONTRATO_COBERTURA_PAQUETE_EXCLUSION_INDEX') {
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos(pPaqueteId, pContratoCoberturaPaqueteId, '');
        };
    },
    keyEvent: function () {
        $("#txtCtrlUserBusqueadaContratoDescripcion").on("change paste keyup", function () {
            if ($("#txtCtrlUserBusqueadaContratoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="CtrlUserBusqueadaContratoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserBusqueadaContratoDescripcion"]').text('');
        });
    },
    cargaDatos:      function (pPaqueteId, pContratoCoberturaPaqueteId) {
        var objJSON = {
            pPaqueteId:                  pContratoCoberturaPaqueteId,
            pContratoCoberturaPaqueteId: pContratoCoberturaPaqueteId
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoCoberturaPaqueteExclusion + 'ContratoCoberturaPaqueteExclusionElementoJsonConJoin',
            json
        );

        if (res != null) {

        }
    },
    guardar:         function () {
        var data = $('#dgDatosCtrlUserContratoCoberturaPaqueteExclusion').bootstrapTable('getData');

        if (data.length == 0) {
            swal("Debe seleccionar al menos un contrato", "", "warning");
            return;
        }

        var _list= [];

        $.each(data, function (index, value) {
            if (
                value.ContratoCoberturaPaqueteExclusionId == 0
                &&
                value.EstatusExcluido == true
            ) {
                var objContratoCoberturaPaqueteExclusion = {
                    ContratoCoberturaPaqueteExclusionId: 0,
                    ContratoCoberturaPaqueteId:          ContratoCoberturaPaqueteExclusion.ContratoCoberturaPaqueteId,
                    PaqueteId:                           value.PaqueteId,
                    PaqueteDetalleId:                    value.PaqueteDetalleId,
                    ItemTipoId:                          value.ItemTipoId,
                    ItemId:                              value.ItemId,
                    ServicioId:                          value.ItemId
                };

                _list.push(objContratoCoberturaPaqueteExclusion);
            }
            
            if (
                value.ContratoCoberturaPaqueteExclusionId > 0
                &&
                value.EstatusExcluido == false
            ) {
                var objContratoCoberturaPaqueteExclusion = {
                    ContratoCoberturaPaqueteExclusionId: value.ContratoCoberturaPaqueteExclusionId,
                    ContratoCoberturaPaqueteId:          ContratoCoberturaPaqueteExclusion.ContratoCoberturaPaqueteId,
                    PaqueteId:                           value.PaqueteId,
                    PaqueteDetalleId:                    value.PaqueteDetalleId,
                    ItemTipoId:                          value.ItemTipoId,
                    ItemId:                              value.ItemId,
                    ServicioId:                          value.ItemId
                };

                _list.push(objContratoCoberturaPaqueteExclusion);
            }
        });

        var objJSON = {
            list: _list
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoCoberturaPaqueteExclusion + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ContratoCoberturaPaqueteExclusion.redirecciona('CONTRATO_COBERTURA_PAQUETE_INDEX'); }, 2000);
                else
                    ContratoCoberturaPaqueteExclusion.redirecciona('PERSONA_CONTRATO_INDEX');

        //$("#myModalContrato").modal('hide');
    },
    actualizar:      function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            EmpresaId:          $("#txtEmpresaId").val(),
            EmpresaDescripcion: $("#txtEmpresaDescripcion").val().trim(),
            InicioOperaciones:  $("#FechaInicioOperaciones").val(),
            EstatusId:          ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var _objDF = {
            EmpresaId:              $("#txtEmpresaId").val(),
            EmpresaDatosFiscalesId: $("#txtEmpresaDatosFiscalesId").val(),
            RazonSocial:            $("#txtRazonSocial").val().trim(),
            RFC:                    $("#txtRfc").val().trim(),
            PaisId:                 $("#ddlPaisId").val(),
            EstadoId:               $("#ddlEstadoId").val(),
            MunicipioId:            $("#ddlMunicipioId").val(),
            ColoniaDescripcion:     $("#txtColoniaDescripcion").val().trim(),
            CalleDescripcion:       $("#txtCalleDescripcion").val().trim(),
            NumeroExterior:         $("#txtNumeroExterior").val().trim(),
            NumeroInterior:         $("#txtNumeroInterior").val().trim(),
            CodigoPostal:           $("#txtCodigoPostal").val().trim(),
        };

        var objJSON = {
            model:   _obj,
            modelDF: _objDF
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Empresa + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Empresa.redirecciona('EMPRESA_INDEX'); }, 2000);
                else
                    this.redirecciona('EMPRESA_INDEX');
    },
    //cambioEstatus: function () {

    //},
    baja:            function (pContratoCoberturaPaqueteId, pPaqueteDescripcion) {
        swal({
            title:              "¿Estás seguro de eliminar permanentemente el paquete (" + pPaqueteDescripcion + ")?",
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
    keyEvent_Create: function () {
        $('#ddl_Create_CoberturaCondicionTipoId').change(function () {
            if ($('#ddl_Create_CoberturaCondicionTipoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="Create_CoberturaCondicionTipoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="Create_CoberturaCondicionTipoId"]').text('');
            };
        });

        $('#ddl_Create_CoberturaPeriodoTipoId').change(function () {
            if ($('#ddl_Create_CoberturaPeriodoTipoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="Create_CoberturaPeriodoTipoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="Create_CoberturaPeriodoTipoId"]').text('');
            };
        });

        $('#ddl_Create_CoberturaCantidadTipoId').change(function () {
            if ($('#ddl_Create_CoberturaCantidadTipoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="Create_CoberturaCantidadTipoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="Create_CoberturaCantidadTipoId"]').text('');

                $("#txtContratoCoberturaPaqueteDescripcion").on("change paste keyup", function () {
                    if ($("#txtContratoCoberturaPaqueteDescripcion").val().trim() == "")
                        $('span[data-valmsg-for="ContratoCoberturaPaqueteDescripcion"]').text('Campo Requerido');
                    else
                        $('span[data-valmsg-for="ContratoCoberturaPaqueteDescripcion"]').text('');
                });
            };
        });



        $('#ddlPaqueteTipoId').change(function () {
            if ($('#ddlPaqueteTipoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="PaqueteTipoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="PaqueteTipoId"]').text('');
            };
        });

        $("#txtContratoCoberturaPaqueteDescripcion").on("change paste keyup", function () {
            if ($("#txtContratoCoberturaPaqueteDescripcion").val().trim() == "")
                $('span[data-valmsg-for="ContratoCoberturaPaqueteDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ContratoCoberturaPaqueteDescripcion"]').text('');
        });
    },
    keyEventGrid:    function () {
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
            $('#dgDatosCtrlUserContratoCoberturaPaqueteExclusion').bootstrapTable({
                search: false,
                columns: [
                    {
                        field:     'ContratoCoberturaPaqueteExclusionId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'PaqueteDetalleId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'PaqueteId',
                        title:     'PaqueteId',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ItemTipoId',
                        title:     'ItemTipoId',
                        sortable:  true,
                        align:     'left',
                        visible:   false
                    },
                    {
                        field:     'ItemTipoDescripcion',
                        title:     'Tipo de Servicio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ItemId',
                        title:     'ItemId',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ServicioDescripcion',
                        title:     'Servicio',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'ServicioTipoId',
                        title:     'ServicioTipoId',
                        sortable:  true,
                        align:     'left',
                        visible:   false
                    },
                    {
                        field:     'ServicioTipoDescripcion',
                        title:     'Clasificacion',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'Excluido',
                        title:     'Estatus',
                        sortable:  true,
                        formatter: 'ContratoCoberturaPaqueteExclusionIdFormatter',
                        align:     'center'
                    },
                    {
                        field:     'EstatusExcluido',
                        title:     '',
                        checkbox:  true
                    }
                ]
            });
        },
        datos:      function (pPaqueteId, pContratoCoberturaPaqueteId, pItemDescripcion) {
            var objJSON = {
                pPaqueteId:                  pPaqueteId,
                pContratoCoberturaPaqueteId: pContratoCoberturaPaqueteId,
                pItemDescripcion:            pItemDescripcion
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ContratoCoberturaPaqueteExclusion + 'ContratoCoberturaPaqueteExclusionElementoJsonConJoin',
                json
            );

            $('#dgDatosCtrlUserContratoCoberturaPaqueteExclusion').bootstrapTable("load", res.data.Datos);
        }
    },
    buscar: function (pItemDescripcion) {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos(this.PaqueteId, this.ContratoCoberturaPaqueteId, pItemDescripcion);
    },
    validaBusqueda: function () {
        if ($("#txtCtrlUserBusqueadaItemDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="CtrlUserBusqueadaItemDescripcion"]').text('Campo Requerido');
            $("#txtCtrlUserBusqueadaItemDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:   function () {
        if ($("#txtContratoCoberturaPaqueteDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ContratoCoberturaPaqueteDescripcion"]').text('Campo Requerido');
            $("#txtContratoCoberturaPaqueteDescripcion").focus();

            return false;
        }

        return true;
    },
    redirecciona:    function (evento) {
        if (evento == 'CONTRATO_COBERTURA_PAQUETE_INDEX') {
            $(location).attr('href', URL.ContratoCoberturaPaquete + "?pContratoCoberturaId=" + $("#txtContratoCoberturaId").val() + "&pContratoCoberturaDescripcion=" + $("#txtContratoCoberturaDescripcion").val() + "&pContratoId=" + $("#txtContratoId").val() + " & pContratoDescripcion=" + $("#txtContratoDescripcion").val());
        };
    },
    limpiarCtrls: function () {
        $('#txtCtrlUserBusqueadaItemDescripcion').val('');

        $('span[data-valmsg-for="CtrlUserBusqueadaItemDescripcion"]').text('');
    }
};