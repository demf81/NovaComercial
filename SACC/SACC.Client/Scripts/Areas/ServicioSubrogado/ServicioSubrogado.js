$(function () {
    ServicioSubrogado.inicializa($("#txtApuntadorServicioSubrogado").val());
});




var ServicioSubrogado = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'SERVICIO_SUBROGADO_INDEX') {
            this.limpiarCtrls();

            ServicioSubrogadoTipo.llenaCombo('ddlServicioSubrogadoTipoId', 'TODOS', '');

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

        if (this.evento == 'SERVICIO_SUBROGADO_CREATE') {
            this.keyEvent();

            ServicioSubrogadoTipo.llenaCombo('ddlServicioSubrogadoTipoId', 'SELECCIONE', '');
        };

        if (this.evento == 'SERVICIO_SUBROGADO_EDIT') {
            this.keyEvent();

            ServicioSubrogadoTipo.llenaCombo('ddlServicioSubrogadoTipoId', 'SELECCIONE', '');

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'SERVICIO_SUBROGADO_DELETE') {
            ServicioSubrogadoTipo.llenaCombo('ddlServicioSubrogadoTipoId', 'SELECCIONE', '');

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pServicioSubrogadoId: $('#txtServicioSubrogadoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ServicioSubrogado + 'ServicioSubrogadoElementoJson',
            json
        );

        if (res != null) {
            $("#txtServicioSubrogadoDescripcion").val(res.data.Datos[0].ServicioSubrogadoDescripcion);
            $("#txtCodigo").val(res.data.Datos[0].Codigo);
            $("#ddlServicioSubrogadoTipoId").val(res.data.Datos[0].ServicioSubrogadoTipoId);
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
            ServicioSubrogadoId:          0,
            ServicioSubrogadoDescripcion: $("#txtServicioSubrogadoDescripcion").val(),
            Codigo:                       $("#txtCodigo").val(),
            ServicioSubrogadoTipoId:      $("#ddlServicioSubrogadoTipoId").val,
            Costo:                        $("#txtCosto").val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ServicioSubrogado + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ServicioSubrogado.redirecciona('SERVICIO_SUBROGADO_INDEX'); }, 2000);
                else
                    this.redirecciona('SERVICIO_SUBROGADO_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ServicioSubrogadoId:          $("#txtServicioSubrogadoId").val(),
            ServicioSubrogadoDescripcion: $("#txtServicioSubrogadoDescripcion").val(),
            Codigo:                       $("#txtCodigo").val(),
            ServicioSubrogadoTipoId:      $("#ddlServicioSubrogadoTipoId").val,
            Costo:                        $("#txtCosto").val(),
            EstatusId:                    ($("input[name='rbEstatusId'][value=0]:checked").val() ? false : true)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ServicioSubrogado + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ServicioSubrogado.redirecciona('SERVICIO_SUBROGADO_INDEX'); }, 2000);
                else
                    this.redirecciona('SERVICIO_SUBROGADO_INDEX');
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
                    ServicioSubrogadoId: $("#txtServicioSubrogadoId").val()
                };

                var objJSON = {
                    model: _obj
                };

                var json = JSON.stringify(objJSON, null, 2);

                var res = getJSON(
                    URL.ServicioSubrogado + 'Delete',
                    json
                );

                if (res != null)
                    if (!res.data.Error)
                        if (res.data.MuestraAlert)
                            setTimeout(function () { ServicioSubrogado.redirecciona('SERVICIO_SUBROGADO_INDEX'); }, 2000);
                        else
                            this.redirecciona('SERVICIO_SUBROGADO_INDEX');
            }
            else {
                swal.close();
            }
        });
    },
    keyEvent: function () {
        $("#txtServicioSubrogadoDescripcion").on("change paste keyup", function () {
            if ($("#txtServicioSubrogadoDescripcion").val() == "")
                $('span[data-valmsg-for="ServicioSubrogadoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ServicioSubrogadoDescripcion"]').text('');
        });

        $("#txtCodigo").on("change paste keyup", function () {
            if ($("#txtCodigo").val() == "")
                $('span[data-valmsg-for="Codigo"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Codigo"]').text('');
        });

        $('#ddlServicioSubrogadoTipoId').change(function () {
            if ($('#ddlServicioSubrogadoTipoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="ServicioSubrogadoTipoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="ServicioSubrogadoTipoId"]').text('');
            };
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
            URL.ServicioSubrogado + "ServicioSubrogadoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosServicioSubrogado').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ServicioSubrogadoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ServicioSubrogadoDescripcion',
                        title:     'Servicio Subrogado',
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
                        field:     'ServicioSubrogadoTipoDescripcion',
                        title:     'Tipo de Servicio Subrogado',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Costo',
                        title:     'Costo ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter'
                    },
                    {
                        field:     'EstatusId',
                        title:     'Activo',
                        sortable:  false,
                        formatter: 'EstatusFormatter',
                        align:     'center'
                    },
                    {
                        field:    '',
                        title:    'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'ServicioSubrogado_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pServicioSubrogadoDescripcion: $('#txtServicioSubrogadoDescripcion').val(),
                pEstatusId: $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ServicioSubrogado + 'ServicioSubrogadoGridJson',
                json
            );

            $('#dgDatosServicioSubrogado').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editServicioSubrogado" href="javascript:void(0)" title="Editar">',
                    '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeServicioSubrogado" href="javascript:void(0)" title="Inactivo">',
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
        if ($("#txtServicioSubrogadoDescripcion").val() == "") {
            $('span[data-valmsg-for="ServicioSubrogadoDescripcion"]').text('Campo Requerido');
            $("#txtServicioSubrogadoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtServicioSubrogadoDescripcion").val() == "") {
            $('span[data-valmsg-for="ServicioSubrogadoDescripcion"]').text('Campo Requerido');
            $("#txtServicioSubrogadoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('SERVICIO_SUBROGADO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'SERVICIO_SUBROGADO_INDEX') {
            $.cookie("ServicioSubrogadoEstatusId", 0);
            $.cookie('ServicioSubrogadoDescripcion', "");

            $(location).attr('href', URL.ServicioSubrogado);
        };

        if (evento == 'SERVICIO_SUBROGADO_CREATE') {
            $(location).attr('href', URL.ServicioSubrogado + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtServicioSubrogadoDescripcion').val('');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtServicioSubrogadoDescripcion', isDisabled);
        DisabledEneableElement('txtCodigo', isDisabled);
        DisabledEneableElement('ddlServicioSubrogadoTipoId', isDisabled);
        DisabledEneableElement('txtCosto', isDisabled);
    }
};




window.ServicioSubrogado_ActionEvents = {
    'click .editServicioSubrogado': function (e, value, row, index) {
        $(location).attr('href', URL.ServicioSubrogado + 'Edit?pServicioSubrogadoId=' + row.ServicioSubrogadoId);
    },
    'click .removeServicioSubrogado': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.ServicioSubrogado + 'Delete?pServicioSubrogadoId=' + row.ServicioSubrogadoId);
    }
};