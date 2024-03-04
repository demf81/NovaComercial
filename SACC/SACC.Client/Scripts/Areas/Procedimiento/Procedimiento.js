$(function () {
    Procedimiento.inicializa($("#txtApuntadorProcedimiento").val());
});




var Procedimiento = {
    evento: null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'PROCEDIMIENTO_INDEX') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'PROCEDIMIENTO_CREATE') {
            this.keyEvent();
        };

        if (this.evento == 'PROCEDIMIENTO_EDIT') {
            this.keyEvent();

            this.cargaDatos();

            //if ($("input[name=rbEstatusId][value=1]").prop('checked'))
            //    this.habilitaDesHabilitaCtrls(false);
            //else
            //    this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'PROCEDIMIENTO_DELETE') {
            this.cargaDatos();

            //this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pProcedimientoId: $('#txtProcedimientoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Procedimiento + 'ProcedimientoElementoJson',
            json
        );

        if (res != null) {
            $("#txtProcedimientoDescripcion").val(res.data.Datos[0].ProcedimientoDescripcion);
            $("#txtServicioId").val(res.data.Datos[0].ServicioId);
            $("#txtCosto").val(res.data.Datos[0].Costo);
            $("#txtPorcentajeAnticipo").val(res.data.Datos[0].PorcentajeAnticipo);


            //if (res.data.Datos[0].EstatusId == 1)
            //    $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            //else
            //    $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ProcedimientoId:          0,
            ProcedimientoDescripcion: $("#txtProcedimientoDescripcion").val().trim(),
            Costo:                    $("#txtCosto").val(),
            PorcentajeAnticipo:       $("#txtPorcentajeAnticipo").val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Procedimiento + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Procedimiento.redirecciona('PROCEDIMIENTO_INDEX'); }, 2000);
                else
                    this.redirecciona('PROCEDIMIENTO_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ProcedimientoId:          $("#txtProcedimientoId").val(),
            ProcedimientoDescripcion: $("#txtProcedimientoDescripcion").val().trim(),
            Costo:                    $("#txtCosto").val(),
            PorcentajeAnticipo:       $("#txtPorcentajeAnticipo").val(),
            EstatusId:                1
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Procedimiento + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Procedimiento.redirecciona('PROCEDIMIENTO_INDEX'); }, 2000);
                else
                    this.redirecciona('PROCEDIMIENTO_INDEX');
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
                        ProcedimientoId: $("#txtProcedimientoId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Procedimiento + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Procedimiento.redirecciona('PROCEDIMIENTO_INDEX'); }, 2000);
                            else
                                this.redirecciona('PROCEDIMIENTO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtProcedimientoDescripcion").on("change paste keyup", function () {
            if ($("#txtProcedimientoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="ProcedimientoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ProcedimientoDescripcion"]').text('');
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
            URL.Procedimiento + "ProcedimientoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosProcedimiento').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ProcedimientoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ProcedimientoDescripcion',
                        title:     'Procedimiento',
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
                        field:     'PorcentajeAnticipo',
                        title:     '% Anticipo',
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
                        events:    'Procedimiento_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pProcedimientoDescripcion: $('#txtProcedimientoDescripcion').val().trim(),
                pEstatusId:                $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Procedimiento + 'ProcedimientoGridJson',
                json
            );

            $('#dgDatosProcedimiento').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editProcedimiento" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="detalleProcedimiento" href="javascript:void(0)" title="Detalle">',
                '<i class="text-warning fa fa-cog fa-2x"></i>',
                //'<a class="removeProcedimiento" href="javascript:void(0)" title="Inactivo">',
                //'<i class="text-danger fa fa-trash fa-2x"></i>',
                //'</a>'
            ].join('');
        }
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtProcedimientoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ProcedimientoDescripcion"]').text('Campo Requerido');
            $("#txtProcedimientoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtProcedimientoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ProcedimientoDescripcion"]').text('Campo Requerido');
            $("#txtProcedimientoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('PROCEDIMIENTO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'PROCEDIMIENTO_INDEX') {
            $(location).attr('href', URL.Procedimiento);
        };

        if (evento == 'PROCEDIMIENTO_CREATE') {
            $(location).attr('href', URL.Procedimiento + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtProcedimientoDescripcion').val('');

        $('span[data-valmsg-for="ProcedimientoDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtProcedimientoDescripcion', isDisabled);
    }
};




window.Procedimiento_ActionEvents = {
    'click .editProcedimiento': function (e, value, row, index) {
        $(location).attr('href', URL.Procedimiento + 'Edit?pProcedimientoId=' + row.ProcedimientoId);
    },
    'click .detalleProcedimiento': function (e, value, row, index) {
        $(location).attr('href', URL.ProcedimientoDetalle + 'Index?pProcedimientoId=' + row.ProcedimientoId + '&pProcedimientoDescripcion=' + row.ProcedimientoDescripcion);
    },
    'click .removeProcedimiento': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Procedimiento + 'Delete?pProcedimientoId=' + row.ProcedimientoId);
    }
};