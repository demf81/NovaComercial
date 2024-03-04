$(function () {
    TarifaDetalle.inicializa($("#txtApuntadorTarifaDetalle").val());
});




var TarifaDetalle = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'TARIFA_DETALLE_INDEX') {
            this.limpiarCtrls();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'TARIFA_DETALLE_CREATE') {
            this.keyEvent();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'TARIFA_DETALLE_EDIT') {
            this.keyEvent();

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'TARIFA_DETALLE_DELETE') {
            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pTarifaDetalleId: $('#txtTarifaDetalleId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.TarifaDetalle + 'TarifaDetalleElementoJson',
            json
        );

        if (res != null) {
            $("#txtTarifaDetalleDescripcion").val(res.data.Datos[0].TarifaDetalleDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            TarifaDetalleId:          0,
            TarifaDetalleDescripcion: $("#txtTarifaDetalleDescripcion").val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.TarifaDetalle + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { TarifaDetalle.redirecciona('TARIFA_DETALLE_INDEX'); }, 2000);
                else
                    this.redirecciona('TARIFA_DETALLE_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            TarifaDetalleId:          $("#txtTarifaDetalleId").val(),
            TarifaDetalleDescripcion: $("#txtTarifaDetalleDescripcion").val(),
            EstatusId:                ($("input[name='rbEstatusId'][value=0]:checked").val() ? false : true)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.TarifaDetalle + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { TarifaDetalle.redirecciona('TARIFA_DETALLE_INDEX'); }, 2000);
                else
                    this.redirecciona('TARIFA_DETALLE_INDEX');
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
                        TarifaDetalleId: $("#txtTarifaDetalleId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.TarifaDetalle + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { TarifaDetalle.redirecciona('TARIFA_DETALLE_INDEX'); }, 2000);
                            else
                                this.redirecciona('TARIFA_DETALLE_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtTarifaDetalleDescripcion").on("change paste keyup", function () {
            if ($("#txtTarifaDetalleDescripcion").val() == "")
                $('span[data-valmsg-for="TarifaDetalleDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="TarifaDetalleDescripcion"]').text('');
        });
    },
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.TarifaDetalle + "TarifaDetalleComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < _data.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosTarifaDetalle').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'TarifaDetalleId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ServicioDescripcion',
                        title:     'Servicio',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Porcentaje',
                        title:     'Porcentaje',
                        align:     'right',
                        editable: {
                            type:  'text',
                            title: 'Debe teclear un porcentaje'
                        },
                    },
                    {
                        field:     'Ajuste',
                        title:     '% de Ajuste',
                        align:     'right',
                        editable: {
                            type:  'text',
                            title: 'Debe teclear un porcentaje'
                        },
                    },
                    {
                        field:     'EstatusId',
                        title:     'Estatus',
                        sortable:  false,
                        formatter: 'EstatusIdFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'TarifaDetalle_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pTarifaId:      $("#txtTarifaId").val(),
                pAreaNegocioId: 1,
                pEstatusId:     1,
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.TarifaDetalle + 'TarifaDetalleGridJson',
                json
            );

            $('#dgDatosTarifaDetalle').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editTarifaDetalle" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;</span>',
                '<a class="removeTarifaDetalle" href="javascript:void(0)" title="Inactivo">',
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
        if ($("#txtTarifaDetalleDescripcion").val() == "") {
            $('span[data-valmsg-for="TarifaDetalleDescripcion"]').text('Campo Requerido');
            $("#txtTarifaDetalleDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtTarifaDetalleDescripcion").val() == "") {
            $('span[data-valmsg-for="TarifaDetalleDescripcion"]').text('Campo Requerido');
            $("#txtTarifaDetalleDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('TARIFA_DETALLE_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'TARIFA_DETALLE_INDEX') {
            $(location).attr('href', URL.TarifaDetalle);
        };

        if (evento == 'TARIFA_DETALLE_CREATE') {
            //$(location).attr('href', URL.TarifaDetalle + 'Create');
            
            
        };
    },
    limpiarCtrls: function () {
        $('#txtTarifaDetalleDescripcion').val('');
    },
    habilitaDesHabilitaCtrls: function (estatus) {
        $("#txtTarifaDetalleDescripcion").prop("readonly", estatus);
    },
    AbreModalCreate: function () {
        $("#myModalTarifaDetalleCreare").modal();
    }
};




window.TarifaDetalle_ActionEvents = {
    'click .editTarifaDetalle': function (e, value, row, index) {
        $(location).attr('href', URL.TarifaDetalle + 'Edit?pTarifaDetalleId=' + row.TarifaDetalleId);
    },
    'click .removeTarifaDetalle': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.TarifaDetalle + 'Delete?pTarifaDetalleId=' + row.TarifaDetalleId);
    }
};