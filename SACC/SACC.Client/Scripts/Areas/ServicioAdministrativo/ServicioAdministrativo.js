$(function () {
    ServicioAdministrativo.inicializa($("#txtApuntadorServicioAdministrativo").val());
});




var ServicioAdministrativo = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'SERVICIO_ADMINISTRATIVO_INDEX') {
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();

            $("[name='checkbox']").bootstrapSwitch({
                on:       'SI',
                off:      'NO',
                onClass:  'success',
                offClass: 'danger',
                size:     'xs'
            });
        };

        if (this.evento == 'SERVICIO_ADMINISTRATIVO_CREATE') {
            this.keyEvent();
        };

        if (this.evento == 'SERVICIO_ADMINISTRATIVO_EDIT') {
            this.keyEvent();

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'SERVICIO_ADMINISTRATIVO_DELETE') {
            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pServicioAdministrativoId: $('#txtServicioAdministrativoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ServicioAdministrativo + 'ServicioAdministrativoElementoJson',
            json
        );

        if (res != null) {
            $("#txtServicioAdministrativoDescripcion").val(res.data.Datos[0].ServicioAdministrativoDescripcion);
            $("#txtCodigo").val(res.data.Datos[0].Codigo);
            $("#txtCosto").val(res.data.Datos[0].Costo);

            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ServicioAdministrativoId:          0,
            ServicioAdministrativoDescripcion: $("#txtServicioAdministrativoDescripcion").val(),
            Codigo:                            $("#txtCodigo").val(),
            Costo:                             $("#txtCosto").val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ServicioAdministrativo + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ServicioAdministrativo.redirecciona('SERVICIO_ADMINISTRATIVO_INDEX'); }, 2000);
                else
                    this.redirecciona('SERVICIO_ADMINISTRATIVO_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ServicioAdministrativoId:          $("#txtServicioAdministrativoId").val(),
            ServicioAdministrativoDescripcion: $("#txtServicioAdministrativoDescripcion").val(),
            Codigo:                            $("#txtCodigo").val(),
            Costo:                             $("#txtCosto").val(),
            EstatusId:                         ($("input[name='rbEstatusId'][value=1]:checked").val() ? false : true)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ServicioAdministrativo + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ServicioAdministrativo.redirecciona('SERVICIO_ADMINISTRATIVO_INDEX'); }, 2000);
                else
                    this.redirecciona('SERVICIO_ADMINISTRATIVO_INDEX');
    },
    baja: function () {
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
                    ServicioAdministrativoId: $("#txtServicioAdministrativoId").val()
                };

                var objJSON = {
                    model: _obj
                };

                var json = JSON.stringify(objJSON, null, 2);

                var res = getJSON(
                    URL.ServicioAdministrativo + 'Delete',
                    json
                );

                if (res != null)
                    if (!res.data.Error)
                        if (res.data.MuestraAlert)
                            setTimeout(function () { ServicioAdministrativo.redirecciona('SERVICIO_ADMINISTRATIVO_INDEX'); }, 2000);
                        else
                            this.redirecciona('SERVICIO_ADMINISTRATIVO_INDEX');
            }
            else {
                swal.close();
            }
        });
    },
    keyEvent: function () {
        $("#txtServicioAdministrativoDescripcion").on("change paste keyup", function () {
            if ($("#txtServicioAdministrativoDescripcion").val() == "")
                $('span[data-valmsg-for="ServicioAdministrativoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ServicioAdministrativoDescripcion"]').text('');
        });

        $("#txtCodigo").on("change paste keyup", function () {
            if ($("#txtCodigo").val() == "")
                $('span[data-valmsg-for="Codigo"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Codigo"]').text('');
        });

        $("#txtCosto").on("change paste keyup", function () {
            if ($("#txtCosto").val() == "")
                $('span[data-valmsg-for="Costo"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Costo"]').text('');
        });

        $("#txtCosto").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
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
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.ServicioAdministrativo + "ServicioAdministrativoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosServicioAdministrativo').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ServicioAdministrativoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ServicioAdministrativoDescripcion',
                        title:     'Servicio Administrativo',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Codigo',
                        title:     'Código',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Costo',
                        title:     'Costo ($)',
                        sortable:  true,
                        align:     'right'
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
                        events:    'ServicioAdministrativo_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pServicioAdministrativoDescripcion: $('#txtServicioAdministrativoDescripcion').val(),
                pCodigo:                            $('#txtCodigo').val(),
                pEstatusId:                         $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ServicioAdministrativo + 'ServicioAdministrativoGridJson',
                json
            );

            $('#dgDatosServicioAdministrativo').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editServicioAdministrativo" href="javascript:void(0)" title="Editar">',
                    '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeServicioAdministrativo" href="javascript:void(0)" title="Inactivo">',
                    '<i class="text-danger fa fa-trash fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtServicioAdministrativoDescripcion").val() == "") {
            $('span[data-valmsg-for="ServicioAdministrativoDescripcion"]').text('Campo Requerido');
            $("#txtServicioAdministrativoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtServicioAdministrativoDescripcion").val() == "") {
            $('span[data-valmsg-for="ServicioAdministrativoDescripcion"]').text('Campo Requerido');
            $("#txtServicioAdministrativoDescripcion").focus();

            return false;
        }

        if ($("#txtCodigo").val() == "") {
            $('span[data-valmsg-for="Codigo"]').text('Campo Requerido');
            $("#txtCodigo").focus();

            return false;
        }

        if ($("#txtCosto").val() == "") {
            $('span[data-valmsg-for="Costo"]').text('Campo Requerido');
            $("#txtCosto").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('SERVICIO_ADMINISTRATIVO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'SERVICIO_ADMINISTRATIVO_INDEX') {
            $.cookie("ServicioAdministrativoEstatusId", 0);
            $.cookie('ServicioAdministrativoDescripcion', "");

            $(location).attr('href', URL.ServicioAdministrativo);
        };

        if (evento == 'SERVICIO_ADMINISTRATIVO_CREATE') {
            $(location).attr('href', URL.ServicioAdministrativo + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtServicioAdministrativoDescripcion').val('');
        $('#txtCosto').val('');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtServicioAdministrativoDescripcion', isDisabled);
        DisabledEneableElement('txtCodigo', isDisabled);
        DisabledEneableElement('txtCosto', isDisabled);
    }
};




window.ServicioAdministrativo_ActionEvents = {
    'click .editServicioAdministrativo': function (e, value, row, index) {
        $(location).attr('href', URL.ServicioAdministrativo + 'Edit?pServicioAdministrativoId=' + row.ServicioAdministrativoId);
    },
    'click .removeServicioAdministrativo': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.ServicioAdministrativo + 'Delete?pServicioAdministrativoId=' + row.ServicioAdministrativoId);
    }
};