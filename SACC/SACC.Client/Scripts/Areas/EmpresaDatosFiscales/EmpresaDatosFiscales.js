var EmpresaDatosFiscales = {
    evento:     null,
    cargaDatos: function () {
        var objJSON = {
            pEmpresaDatosFiscalesId: 0, //$('#txtEmpresaDatosFiscalesId').val(),
            pEmpresaId:              $('#txtEmpresaId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.EmpresaDatosFiscales + 'EmpresaDatosFiscalesElementoJson',
            json
        );

        if (res != null) {
            $('#txtEmpresaDatosFiscalesId').val(res.data.Datos[0].EmpresaDatosFiscalesId);
            $("#txtRazonSocial").val(res.data.Datos[0].RazonSocial);
            $("#txtRFC").val(res.data.Datos[0].RFC);

            $("#ddlPaisId").val(res.data.Datos[0].PaisId);
            Estado.llenaCombo('ddlEstadoId', 'SELECCIONE', $("#ddlPaisId").val());

            $("#ddlEstadoId").val(res.data.Datos[0].EstadoId);
            Municipio.llenaCombo('ddlMunicipioId', 'SELECCIONE', $("#ddlPaisId").val(), $("#ddlEstadoId").val());

            $("#ddlMunicipioId").val(res.data.Datos[0].MunicipioId);
            $("#txtColonia").val(res.data.Datos[0].Colonia);
            $("#txtCalle").val(res.data.Datos[0].Calle);
            $("#txtNumeroExterior").val(res.data.Datos[0].NumeroExterior);
            $("#txtNumeroInterior").val(res.data.Datos[0].NumeroInterior);
            $("#txtCodigoPostal").val(res.data.Datos[0].CodigoPostal);
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            EmpresaDatosFiscalesId: 0,
            EmpresaDatosFiscalesDescripcion: $("#txtEmpresaDatosFiscalesDescripcion").val().trim()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.EmpresaDatosFiscales + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { EmpresaDatosFiscales.redirecciona('EMPRESA_DATOS_FISCALES_INDEX'); }, 2000);
                else
                    this.redirecciona('EMPRESA_DATOS_FISCALES_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            EmpresaDatosFiscalesId: $("#txtEmpresaDatosFiscalesId").val(),
            EmpresaDatosFiscalesDescripcion: $("#txtEmpresaDatosFiscalesDescripcion").val().trim(),
            EstatusId: ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.EmpresaDatosFiscales + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { EmpresaDatosFiscales.redirecciona('EMPRESA_DATOS_FISCALES_INDEX'); }, 2000);
                else
                    this.redirecciona('EMPRESA_DATOS_FISCALES_INDEX');
    },
    //cambioEstatus: function () {

    //},
    baja: function () {
        swal({
            title: "¿Estás seguro de eliminar permanentemente el registro?",
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
                        EmpresaDatosFiscalesId: $("#txtEmpresaDatosFiscalesId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.EmpresaDatosFiscales + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { EmpresaDatosFiscales.redirecciona('EMPRESA_DATOS_FISCALES_INDEX'); }, 2000);
                            else
                                this.redirecciona('EMPRESA_DATOS_FISCALES_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtEmpresaDatosFiscalesDescripcion").on("change paste keyup", function () {
            if ($("#txtEmpresaDatosFiscalesDescripcion").val().trim() == "")
                $('span[data-valmsg-for="EmpresaDatosFiscalesDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="EmpresaDatosFiscalesDescripcion"]').text('');
        });
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtEmpresaDatosFiscalesDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="EmpresaDatosFiscalesDescripcion"]').text('Campo Requerido');
            $("#txtEmpresaDatosFiscalesDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtEmpresaDatosFiscalesDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="EmpresaDatosFiscalesDescripcion"]').text('Campo Requerido');
            $("#txtEmpresaDatosFiscalesDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('EMPRESA_DATOS_FISCALES_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'EMPRESA_DATOS_FISCALES_INDEX') {
            $(location).attr('href', URL.EmpresaDatosFiscales);
        };

        if (evento == 'EMPRESA_DATOS_FISCALES_CREATE') {
            $(location).attr('href', URL.EmpresaDatosFiscales + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtEmpresaDatosFiscalesDescripcion').val('');

        $('span[data-valmsg-for="EmpresaDatosFiscalesDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtEmpresaDatosFiscalesDescripcion', isDisabled);
    }
};




window.EmpresaDatosFiscales_ActionEvents = {
    'click .editEmpresaDatosFiscales': function (e, value, row, index) {
        $(location).attr('href', URL.EmpresaDatosFiscales + 'Edit?pEmpresaDatosFiscalesId=' + row.EmpresaDatosFiscalesId);
    },
    'click .removeEmpresaDatosFiscales': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.EmpresaDatosFiscales + 'Delete?pEmpresaDatosFiscalesId=' + row.EmpresaDatosFiscalesId);
    }
};