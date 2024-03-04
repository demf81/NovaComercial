$(function () {
    Servicio.inicializa($("#txtApuntadorServicio").val());
});




var Servicio = {
    evento: null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'ARTICULO_TIPO_INDEX') {
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'ARTICULO_TIPO_CREATE') {
            this.keyEvent();

            $("input[name=rbEstatusId][value=0]").prop("disabled", true);
            $("input[name=rbEstatusId][value=0]").prop('checked', true).iCheck('update');

            $("input[name=rbEstatusId][value=1]").prop("disabled", true);
            $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        };

        if (this.evento == 'ARTICULO_TIPO_EDIT') {
            this.keyEvent();

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=0]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'ARTICULO_TIPO_DELETE') {
            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);

            $("input[name=rbEstatusId][value=0]").prop("disabled", true);
            $("input[name=rbEstatusId][value=0]").prop('checked', false).iCheck('update');

            $("input[name=rbEstatusId][value=1]").prop("disabled", true);
            $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pServicioId: $('#txtServicioId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Servicio + 'ServicioElementoJson',
            json
        );

        if (res != null) {
            $("#txtServicioDescripcion").val(res.data.Datos[0].ServicioDescripcion);


            if (res.data.Datos[0].Baja)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=0]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ServicioId: 0,
            ServicioDescripcion: $("#txtServicioDescripcion").val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Servicio + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Servicio.redirecciona('ARTICULO_TIPO_INDEX'); }, 2000);
                else
                    this.redirecciona('ARTICULO_TIPO_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ServicioId:          $("#txtServicioId").val(),
            ServicioDescripcion: $("#txtServicioDescripcion").val(),
            Baja:                ($("input[name='rbEstatusId'][value=0]:checked").val() ? false : true)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Servicio + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Servicio.redirecciona('ARTICULO_TIPO_INDEX'); }, 2000);
                else
                    this.redirecciona('ARTICULO_TIPO_INDEX');
    },
    baja: function () {
        swal({
            title:              "¿Estás seguro de eliminar el registro?",
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
                        ServicioId: $("#txtServicioId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Servicio + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Servicio.redirecciona('ARTICULO_TIPO_INDEX'); }, 2000);
                            else
                                this.redirecciona('ARTICULO_TIPO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtServicioDescripcion").on("change paste keyup", function () {
            if ($("#txtServicioDescripcion").val() == "")
                $('span[data-valmsg-for="ServicioDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ServicioDescripcion"]').text('');
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
    llenaCombo: function (pCtrlName, pOpcion, pFiltro) {
        var res = getJSON(
            URL.Servicio + "ServicioComboJson?_opcion=" + pOpcion + "&pFiltro=" + pFiltro,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#' + _articuloTipo_GridName).bootstrapTable({
                pagination: true,
                search: false,
                columns: [
                    {
                        field:     'ServicioId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ServicioDescripcion',
                        title:     'Tipo de Articulo',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Baja',
                        title:     'Estatus',
                        sortable:  false,
                        formatter: 'estatusFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'Servicio_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pServicioId:          0,
                pServicioDescripcion: $('#txtServicioDescripcion').val(),
                pEstatusId:           $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Servicio + 'ServicioGridJson',
                json
            );

            $('#' + _articuloTipo_GridName).bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editServicio" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-lg"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;</span>',
                '<a class="removeServicio" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-times fa-lg"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.datos();
    },
    validaBusqueda: function () {
        //if ($("#txtServicioDescripcion").val() == "") {
        //    $('span[data-valmsg-for="ServicioDescripcion"]').text('Campo Requerido');
        //    $("#txtServicioDescripcion").focus();

        //    return false;
        //}

        return true;
    },
    validaGuardar: function () {
        if ($("#txtServicioDescripcion").val() == "") {
            $('span[data-valmsg-for="ServicioDescripcion"]').text('Campo Requerido');
            $("#txtServicioDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('ARTICULO_TIPO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'ARTICULO_TIPO_INDEX') {
            $.cookie("ServicioEstatusId", 0);
            $.cookie('ServicioDescripcion', "");

            $(location).attr('href', URL.Servicio);
        };

        if (evento == 'ARTICULO_TIPO_CREATE') {
            $(location).attr('href', URL.Servicio + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtServicioDescripcion').val('');
    },
    habilitaDesHabilitaCtrls: function (estatus) {
        $("#txtServicioDescripcion").prop("readonly", estatus);
    }
};




window.Servicio_ActionEvents = {
    'click .editServicio': function (e, value, row, index) {
        $(location).attr('href', URL.Servicio + 'Edit?pServicioId=' + row.ServicioId);
    },
    'click .removeServicio': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Servicio + 'Delete?pServicioId=' + row.ServicioId);
    }
};