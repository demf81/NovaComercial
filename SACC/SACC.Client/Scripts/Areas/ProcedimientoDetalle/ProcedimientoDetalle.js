$(function () {
    ProcedimientoDetalle.inicializa($("#txtApuntadorProcedimientoDetalle").val());
});




var ProcedimientoDetalle = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'PROCEDIMIENTO_DETALLE_INDEX') {
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'PROCEDIMIENTO_DETALLE_CREATE') {
            this.keyEvent();
        };

        if (this.evento == 'PROCEDIMIENTO_DETALLE_EDIT') {
            this.keyEvent();

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'PROCEDIMIENTO_DETALLE_DELETE') {
            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _data = $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('getSelections');

        var _obj = {
            ProcedimientoDetalleId: 0,
            ProcedimientoId:        $("#txtProcedimientoId").val(),
            PersonaId:              _data[0].PersonaId,
            ParentescoId:           $("#ddlCtrlUserParentescoId").val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ProcedimientoDetalle + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ProcedimientoDetalle.redirecciona('PROCEDIMIENTO_DETALLE_INDEX'); }, 2000);
                else
                    this.redirecciona('PROCEDIMIENTO_DETALLE_INDEX');
    },
    baja: function (pProcedimientoDetalleId) {
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
                        ProcedimientoDetalleId: pProcedimientoDetalleId
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.ProcedimientoDetalle + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { ProcedimientoDetalle.redirecciona('PROCEDIMIENTO_DETALLE_INDEX'); }, 2000);
                            else
                                this.redirecciona('PROCEDIMIENTO_DETALLE_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtProcedimientoDetalleDescripcion").on("change paste keyup", function () {
            if ($("#txtProcedimientoDetalleDescripcion").val() == "")
                $('span[data-valmsg-for="ProcedimientoDetalleDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ProcedimientoDetalleDescripcion"]').text('');
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
    tabla: {
        inicializa: function () {
            $('#dgDatosProcedimientoDetalle').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ProcedimientoDetalleId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'Posicion',
                        title:     'Posicion',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ClaseOperacion',
                        title:     'ClaseOperacion',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ElementoId',
                        title:     'Elemento',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ProcedimientoDetalleDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Cantidad',
                        title:     'Cantidad',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'Unidad',
                        title:     'Unidad',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'Costo',
                        title:     'Costo',
                        sortable:  true,
                        align:     'right'
                    },
                    {
                        field:     'Subtotal',
                        title:     'Subtotal',
                        sortable:  true,
                        align:     'right'
                    },
                    {
                        field:     'EstatusId',
                        title:     'Activo',
                        sortable:  false,
                        formatter: 'EstatusIdFormatter',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pProcedimientoId:          $('#txtProcedimientoId').val(),
                pProcedimientoDescripcion: '',
                pEstatusId:                1
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ProcedimientoDetalle + 'ProcedimientoDetalleGridJson',
                json
            );

            $('#dgDatosProcedimientoDetalle').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                //'<a class="editProcedimientoDetalle" href="javascript:void(0)" title="Editar">',
                //'<i class="text-success fa fa-pencil fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeProcedimientoDetalle" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-times fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    validaBusqueda: function () {
        if ($("#txtProcedimientoDetalleDescripcion").val() == "") {
            $('span[data-valmsg-for="ProcedimientoDetalleDescripcion"]').text('Campo Requerido');
            $("#txtProcedimientoDetalleDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        var _data = $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('getSelections');

        if (_data.length == 0) {
            swal("Debe seleccionar una persona", "", "warning");

            return;
        }

        if (_data.length == 2) {
            swal("Solo debe seleccionar una persona", "", "warning");

            return;
        }

        if ($('#ddlCtrlUserParentescoId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="CtrlUserParentescoId"]').text('Campo Requerido');
            $("#ddlCtrlUserParentescoId").focus();

            return false;
        };

        return true;
    },
    limpiar: function () {
        this.inicializa('PROCEDIMIENTO_DETALLE_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'PROCEDIMIENTO_INDEX') {
            $(location).attr('href', URL.Procedimiento + '?pOpcion=1');
        };

        if (evento == 'PROCEDIMIENTO_DETALLE_INDEX') {
            $(location).attr('href', URL.ProcedimientoDetalle + 'Index?pProcedimientoId=' + $('#txtProcedimientoId').val() + '&pNumSocio=' + '12345' + '&pContratante=' + $('#txtContratante').val());
        };

        if (evento == 'PROCEDIMIENTO_DETALLE_CREATE') {
            $(location).attr('href', URL.ProcedimientoDetalle + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtProcedimientoDetalleDescripcion').val('');
    },
    //habilitaDesHabilitaCtrls: function (isDisabled) {
    //    DisabledEneableElement('#txtProcedimientoDetalleDescripcion', isDisabled);
    //},
    AbreModalPersona: function () {
        $("#myModalBusquedaPersonaParentesco").modal();

        Parentesco.llenaCombo('ddlCtrlUserParentescoId', 'SELECCIONE', '');

        $("#txtPersonaId").val("");
        $("#txtNombrePersona").val("");

        $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('removeAll');

        CtrlUserBusquedaPersona.inicializa("CTRL_USER_BUSQUEDA_PERSONA_INDEX");
    },
    AgregarPersona: function () {
        var data = $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('getSelections');

        if (data.length == 0) {
            swal("Debe seleccionar una persona", "", "warning");

            return;
        }

        if (data.length == 2) {
            swal("Solo debe seleccionar una persona", "", "warning");

            return;
        }

        if ($('#ddlCtrlUserParentescoId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="CtrlUserParentescoId"]').text('Campo Requerido');
            $("#ddlCtrlUserParentescoId").focus();

            return false;
        };

        this.guardar();

        $("#myModalBusquedaPersonaParentesco").modal("toggle");
    },
};




window.ProcedimientoDetalle_ActionEvents = {
    'click .editProcedimientoDetalle': function (e, value, row, index) {
        $(location).attr('href', URL.ProcedimientoDetalle + 'Edit?pProcedimientoDetalleId=' + row.ProcedimientoDetalleId);
    },
    'click .removeProcedimientoDetalle': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        ProcedimientoDetalle.baja(row.ProcedimientoDetalleId);

        //$(location).attr('href', URL.ProcedimientoDetalle + 'Delete?pProcedimientoDetalleId=' + row.ProcedimientoDetalleId);
    }
};