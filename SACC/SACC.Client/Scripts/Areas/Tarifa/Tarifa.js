$(function () {
    Tarifa.inicializa($("#txtApuntadorTarifa").val());
});




var Tarifa = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'TARIFA_INDEX') {
            this.limpiarCtrls();

            AreaNegocio.llenaCombo('ddlAreaNegocioId', 'TODOS', '');

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'TARIFA_CREATE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.keyEvent();

            AreaNegocio.llenaCombo('ddlAreaNegocioId', 'SELECCIONE', '');
        };

        if (this.evento == 'TARIFA_EDIT') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.keyEvent();

            AreaNegocio.llenaCombo('ddlAreaNegocioId', 'SELECCIONE', '');

            this.cargaDatos();


            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'TARIFA_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            AreaNegocio.llenaCombo('ddlAreaNegocioId', 'SELECCIONE', '');

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pTarifaId: $('#txtTarifaId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Tarifa + 'TarifaElementoJson',
            json
        );

        if (res != null) {
            $("#txtTarifaDescripcion").val(res.data.Datos[0].TarifaDescripcion);
            $("#ddlAreaNegocioId").val(res.data.Datos[0].AreaNegocioId);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            TarifaId:          0,
            TarifaDescripcion: $("#txtTarifaDescripcion").val(),
            AreaNegocioId:     $("#ddlAreaNegocioId").val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Tarifa + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Tarifa.redirecciona('TARIFA_INDEX'); }, 2000);
                else
                    this.redirecciona('TARIFA_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            TarifaId:          $("#txtTarifaId").val(),
            TarifaDescripcion: $("#txtTarifaDescripcion").val(),
            AreaNegocioId:     $("#ddlAreaNegocioId").val(),
            EstatusId:         ($("input[name='rbEstatusId'][value=0]:checked").val() ? false : true)
        };

        var objJSON = {
            model: _obj,
            detalle: $('#dgDatosCtrlUserServicioAreaNegocio').bootstrapTable('getData')
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Tarifa + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Tarifa.redirecciona('TARIFA_INDEX'); }, 2000);
                else
                    this.redirecciona('TARIFA_INDEX');
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
                        TarifaId: $("#txtTarifaId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Tarifa + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Tarifa.redirecciona('TARIFA_INDEX'); }, 2000);
                            else
                                this.redirecciona('TARIFA_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtTarifaDescripcion").on("change paste keyup", function () {
            if ($("#txtTarifaDescripcion").val() == "")
                $('span[data-valmsg-for="TarifaDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="TarifaDescripcion"]').text('');
        });

        $('#ddlAreaNegocioId').change(function () {
            if ($('#ddlAreaNegocioId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="AreaNegocioId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="AreaNegocioId"]').text('');
            };
        });

        $('#ddlAreaNegocioId').change(function () {
            if ($('#ddlPaqueteTipoId  option:selected').text() == "[Seleccione...]") {
                CtrlUserBusquedaServicioTarifa.tabla.inicializa('dgDatosCtrlUserServicioAreaNegocio');
            }
            else {
                CtrlUserBusquedaServicioTarifa.tabla.datos($('#ddlAreaNegocioId').val(), 'dgDatosCtrlUserServicioAreaNegocio');
            };
        });
    },
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.Tarifa + "TarifaComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosTarifa').bootstrapTable({
                pagination: true,
                search: false,
                columns: [
                    {
                        field:     'TarifaId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'TarifaDescripcion',
                        title:     'Tarifa',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'AreaNegocioDescripcion',
                        title:     'Área de Negocio',
                        sortable:  true,
                        align:     'left'
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
                        events:    'Tarifa_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pTarifaDescripcion: $('#txtTarifaDescripcion').val(),
                pAreaNegocioId:     $('#ddlAreaNegocioId').val(),
                pEstatusId:         $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Tarifa + 'TarifaGridJson',
                json
            );

            $('#dgDatosTarifa').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editTarifa" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;</span>',
                '<a class="configuracionTarifa" href="javascript:void(0)" title="Configuración">',
                '<i class="text-warning fa fa-cog fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;</span>',
                '<a class="removeTarifa" href="javascript:void(0)" title="Inactivo">',
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
        if ($("#txtTarifaDescripcion").val() == "") {
            $('span[data-valmsg-for="TarifaDescripcion"]').text('Campo Requerido');
            $("#txtTarifaDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtTarifaDescripcion").val() == "") {
            $('span[data-valmsg-for="TarifaDescripcion"]').text('Campo Requerido');
            $("#txtTarifaDescripcion").focus();

            return false;
        }

        if ($('#ddlAreaNegocioId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="AreaNegocioId"]').text('Campo Requerido');
            $("#ddlAreaNegocioId").focus();
            return false;
        };

        return true;
    },
    limpiar: function () {
        this.inicializa('TARIFA_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'TARIFA_INDEX') {
            $.cookie("TarifaEstatusId", 0);
            $.cookie('TarifaDescripcion', "");

            $(location).attr('href', URL.Tarifa);
        };

        if (evento == 'TARIFA_CREATE') {
            $(location).attr('href', URL.Tarifa + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtTarifaDescripcion').val('');
    },
    habilitaDesHabilitaCtrls: function (estatus) {
        $("#txtTarifaDescripcion").prop("readonly", estatus);
        $("#ddlAreaNegocioId").prop("disabled", (estatus == true ? "disabled" : ""));
    }
};




window.Tarifa_ActionEvents = {
    'click .editTarifa': function (e, value, row, index) {
        $(location).attr('href', URL.Tarifa + 'Edit?pTarifaId=' + row.TarifaId);
    },
    'click .configuracionTarifa': function (e, value, row, index) {
        $(location).attr('href', URL.TarifaDetalle + 'Index?pTarifaId=' + row.TarifaId + '&pTarifaDescripcion=' + row.TarifaDescripcion);
    },
    'click .removeTarifa': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Tarifa + 'Delete?pTarifaId=' + row.TarifaId);
    }
};