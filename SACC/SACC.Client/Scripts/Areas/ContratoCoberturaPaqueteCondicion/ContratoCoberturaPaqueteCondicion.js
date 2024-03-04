var ContratoCoberturaPaqueteCondicion = {
    evento: null,
    inicializa: function (evento, pContratoCoberturaPaqueteId) {
        this.evento = evento;

        if (this.evento == 'CONTRATO_COBERTURA_PAQUETE_CONDICION_CREATE') {
            this.keyEvent_Create();
            //this.limpiarCtrls();

            $("#txt_Create_ContratoCoberturaPaqueteId").val(pContratoCoberturaPaqueteId);

            CoberturaCantidadTipo.llenaCombo('ddl_Create_CoberturaCantidadTipoId',   'SELECCIONE');
            CoberturaCondicionTipo.llenaCombo('ddl_Create_CoberturaCondicionTipoId', 'SELECCIONE');
            CoberturaCopagoTipo.llenaCombo('ddl_Create_CoberturaCopagoTipoId',       'SELECCIONE');
            CoberturaPeriodoTipo.llenaCombo('ddl_Create_CoberturaPeriodoTipoId',     'SELECCIONE');
        };

        if (this.evento == 'CONTRATO_COBERTURA_PAQUETE_CONDICION_EDIT') {
            //this.keyEvent();
            //this.limpiarCtrls();

            CoberturaCantidadTipo.llenaCombo('ddl_Edit_CoberturaCantidadTipoId',   'SELECCIONE');
            CoberturaCondicionTipo.llenaCombo('ddl_Edit_CoberturaCondicionTipoId', 'SELECCIONE');
            CoberturaCopagoTipo.llenaCombo('ddl_Edit_CoberturaCopagoTipoId',       'SELECCIONE');
            CoberturaPeriodoTipo.llenaCombo('ddl_Edit_CoberturaPeriodoTipoId',     'SELECCIONE');

            this.cargaDatos(pContratoCoberturaPaqueteId);
        };
    },
    cargaDatos: function (pContratoCoberturaPaqueteId) {
        var objJSON = {
            pContratoCoberturaPaqueteId: pContratoCoberturaPaqueteId
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoCoberturaPaqueteCondicion + 'ContratoCoberturaPaqueteCondicionElementoJsonConJoin',
            json
        );

        if (res != null) {
            $("#txt_Edit_ContratoCoberturaPaqueteCondicionId").val(res.data.Datos[0].ContratoCoberturaPaqueteCondicionId);
            $("#ddl_Edit_CoberturaCondicionTipoId").val(res.data.Datos[0].CoberturaCondicionTipoId);
            $("#ddl_Edit_CoberturaPeriodoTipoId").val(res.data.Datos[0].CoberturaPeriodoTipoId);
            $("#ddl_Edit_CoberturaCantidadTipoId").val(res.data.Datos[0].CoberturaCantidadTipoId);
            $("#txt_Edit_CoberturaCantidadTipo").val(res.data.Datos[0].Cantidad);
            $("#ddl_Edit_CoberturaCopagoTipoId").val(res.data.Datos[0].CoberturaCopagoTipoId);
            $("#txt_Edit_CoberturaCopagoTipo").val(res.data.Datos[0].Copago);

            //if (res.data.Datos[0].EstatusId == 1)
            //    $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            //else
            //    $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        var _obj = {
            ContratoCoberturaPaqueteCondicionId: $("#txt_Create_ContratoCoberturaPaqueteCondicionId").val(),
            ContratoCoberturaPaqueteId:          $("#txt_Create_ContratoCoberturaPaqueteId").val(),
            CoberturaCondicionTipoId:            $("#ddl_Create_CoberturaCondicionTipoId").val(),
            CoberturaPeriodoTipoId:              $("#ddl_Create_CoberturaPeriodoTipoId").val(),
            CoberturaCantidadTipoId:             $("#ddl_Create_CoberturaCantidadTipoId").val(),
            Cantidad:                            $("#txt_Create_CoberturaCantidadTipo").val(),
            CoberturaCopagoTipoId:               $("#ddl_Create_CoberturaCopagoTipoId").val(),
            Copago:                              $("#txt_Create_CoberturaCopagoTipo").val(),
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoCoberturaPaqueteCondicion + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ContratoCoberturaPaquete.redirecciona('CONTRATO_COBERTURA_PAQUETE_INDEX'); }, 2000);
                else
                    this.redirecciona('CONTRATO_COBERTURA_PAQUETE_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            EmpresaId: $("#txtEmpresaId").val(),
            EmpresaDescripcion: $("#txtEmpresaDescripcion").val().trim(),
            InicioOperaciones: $("#FechaInicioOperaciones").val(),
            EstatusId: ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var _objDF = {
            EmpresaId: $("#txtEmpresaId").val(),
            EmpresaDatosFiscalesId: $("#txtEmpresaDatosFiscalesId").val(),
            RazonSocial: $("#txtRazonSocial").val().trim(),
            RFC: $("#txtRfc").val().trim(),
            PaisId: $("#ddlPaisId").val(),
            EstadoId: $("#ddlEstadoId").val(),
            MunicipioId: $("#ddlMunicipioId").val(),
            ColoniaDescripcion: $("#txtColoniaDescripcion").val().trim(),
            CalleDescripcion: $("#txtCalleDescripcion").val().trim(),
            NumeroExterior: $("#txtNumeroExterior").val().trim(),
            NumeroInterior: $("#txtNumeroInterior").val().trim(),
            CodigoPostal: $("#txtCodigoPostal").val().trim(),
        };

        var objJSON = {
            model: _obj,
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
    baja: function (pContratoCoberturaPaqueteId, pPaqueteDescripcion) {
        swal({
            title: "¿Estás seguro de eliminar permanentemente el paquete (" + pPaqueteDescripcion + ")?",
            text: "",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Si",
            cancelButtonText: "No",
            closeOnConfirm: false,
            closeOnCancel: false
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
    validaGuardar: function () {
        if ($("#txtContratoCoberturaPaqueteDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ContratoCoberturaPaqueteDescripcion"]').text('Campo Requerido');
            $("#txtContratoCoberturaPaqueteDescripcion").focus();

            return false;
        }

        return true;
    },
    redirecciona: function (evento) {
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
};