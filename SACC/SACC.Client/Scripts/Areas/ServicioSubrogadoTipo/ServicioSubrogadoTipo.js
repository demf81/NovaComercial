$(function () {
    ServicioSubrogadoTipo.inicializa($("#txtApuntadorServicioSubrogadoTipo").val());
});




var ServicioSubrogadoTipo = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'SERVICIO_SUBROGADO_TIPO_INDEX') {
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

        if (this.evento == 'SERVICIO_SUBROGADO_TIPO_CREATE') {
            this.keyEvent();
        };

        if (this.evento == 'SERVICIO_SUBROGADO_TIPO_EDIT') {
            this.keyEvent();

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'SERVICIO_SUBROGADO_TIPO_DELETE') {
            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pServicioSubrogadoTipoId: $('#txtServicioSubrogadoTipoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ServicioSubrogadoTipo + 'ServicioSubrogadoTipoElementoJson',
            json
        );

        if (res != null) {
            $("#txtServicioSubrogadoTipoDescripcion").val(res.data.Datos[0].ServicioSubrogadoTipoDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ServicioSubrogadoTipoId:          0,
            ServicioSubrogadoTipoDescripcion: $("#txtServicioSubrogadoTipoDescripcion").val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ServicioSubrogadoTipo + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ServicioSubrogadoTipo.redirecciona('SERVICIO_SUBROGADO_TIPO_INDEX'); }, 2000);
                else
                    this.redirecciona('SERVICIO_SUBROGADO_TIPO_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ServicioSubrogadoTipoId:          $("#txtServicioSubrogadoTipoId").val(),
            ServicioSubrogadoTipoDescripcion: $("#txtServicioSubrogadoTipoDescripcion").val(),
            EstatusId:                        ($("input[name='rbEstatusId'][value=0]:checked").val() ? false : true)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ServicioSubrogadoTipo + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ServicioSubrogadoTipo.redirecciona('SERVICIO_SUBROGADO_TIPO_INDEX'); }, 2000);
                else
                    this.redirecciona('SERVICIO_SUBROGADO_TIPO_INDEX');
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
                    ServicioSubrogadoTipoId: $("#txtServicioSubrogadoTipoId").val()
                };

                var objJSON = {
                    model: _obj
                };

                var json = JSON.stringify(objJSON, null, 2);

                var res = getJSON(
                    URL.ServicioSubrogadoTipo + 'Delete',
                    json
                );

                if (res != null)
                    if (!res.data.Error)
                        if (res.data.MuestraAlert)
                            setTimeout(function () { ServicioSubrogadoTipo.redirecciona('SERVICIO_SUBROGADO_TIPO_INDEX'); }, 2000);
                        else
                            this.redirecciona('SERVICIO_SUBROGADO_TIPO_INDEX');
            }
            else {
                swal.close();
            }
        });
    },
    keyEvent: function () {
        $("#txtServicioSubrogadoTipoDescripcion").on("change paste keyup", function () {
            if ($("#txtServicioSubrogadoTipoDescripcion").val() == "")
                $('span[data-valmsg-for="ServicioSubrogadoTipoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ServicioSubrogadoTipoDescripcion"]').text('');
        });
    },
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.ServicioSubrogadoTipo + "ServicioSubrogadoTipoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosServicioSubrogadoTipo').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ServicioSubrogadoTipoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ServicioSubrogadoTipoDescripcion',
                        title:     'Tipo de Servicio Subrogado',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'EstatusId',
                        title:     'Activo',
                        sortable:  false,
                        formatter: 'EstatusFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'ServicioSubrogadoTipo_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pServicioSubrogadoTipoDescripcion: $('#txtServicioSubrogadoTipoDescripcion').val(),
                pEstatusId:                        $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ServicioSubrogadoTipo + 'ServicioSubrogadoTipoGridJson',
                json
            );

            $('#dgDatosServicioSubrogadoTipo').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editServicioSubrogadoTipo" href="javascript:void(0)" title="Editar">',
                    '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeServicioSubrogadoTipo" href="javascript:void(0)" title="Inactivo">',
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
        if ($("#txtServicioSubrogadoTipoDescripcion").val() == "") {
            $('span[data-valmsg-for="ServicioSubrogadoTipoDescripcion"]').text('Campo Requerido');
            $("#txtServicioSubrogadoTipoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtServicioSubrogadoTipoDescripcion").val() == "") {
            $('span[data-valmsg-for="ServicioSubrogadoTipoDescripcion"]').text('Campo Requerido');
            $("#txtServicioSubrogadoTipoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('SERVICIO_SUBROGADO_TIPO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'SERVICIO_SUBROGADO_TIPO_INDEX') {
            $.cookie("ServicioSubrogadoTipoEstatusId", 0);
            $.cookie('ServicioSubrogadoTipoDescripcion', "");

            $(location).attr('href', URL.ServicioSubrogadoTipo);
        };

        if (evento == 'SERVICIO_SUBROGADO_TIPO_CREATE') {
            $(location).attr('href', URL.ServicioSubrogadoTipo + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtServicioSubrogadoTipoDescripcion').val('');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtServicioSubrogadoTipoDescripcion', isDisabled);
    }
};




window.ServicioSubrogadoTipo_ActionEvents = {
    'click .editServicioSubrogadoTipo': function (e, value, row, index) {
        $(location).attr('href', URL.ServicioSubrogadoTipo + 'Edit?pServicioSubrogadoTipoId=' + row.ServicioSubrogadoTipoId);
    },
    'click .removeServicioSubrogadoTipo': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.ServicioSubrogadoTipo + 'Delete?pServicioSubrogadoTipoId=' + row.ServicioSubrogadoTipoId);
    }
};