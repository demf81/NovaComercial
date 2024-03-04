$(function () {
    ContratoProductoPaquete.inicializa($("#txtApuntadorContratoProductoPaquete").val());
});




var ContratoProductoPaquete = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'CONTRATO_PRODUCTO_PAQUETE_INDEX') {
            //this.keyEvent();
            //this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    guardar:                  function (data) {
        var objJSON = {
            list: data
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.ContratoProductoPaquete + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { ContratoProductoPaquete.redirecciona('CONTRATO_PRODUCTO_PAQUETE_INDEX'); }, 2000);
                else
                    this.redirecciona('CONTRATO_PRODUCTO_PAQUETE_INDEX');
    },
    //cambioEstatus: function () {

    //},
    baja:                     function (pContratoProductoPaqueteId, pPaqueteDescripcion) {
        swal({
            title:              "¿Estás seguro de eliminar permanentemente el paquete (" + pPaqueteDescripcion + ")?",
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
                        ContratoProductoPaqueteId: pContratoProductoPaqueteId
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.ContratoProductoPaquete + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { ContratoProductoPaquete.redirecciona('CONTRATO_PRODUCTO_PAQUETE_INDEX'); }, 2000);
                            else
                                this.redirecciona('CONTRATO_PRODUCTO_PAQUETE_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    //keyEvent: function () {
    //    $("#txtContratoProductoPaqueteDescripcion").on("change paste keyup", function () {
    //        if ($("#txtContratoProductoPaqueteDescripcion").val().trim() == "")
    //            $('span[data-valmsg-for="ContratoProductoPaqueteDescripcion"]').text('Campo Requerido');
    //        else
    //            $('span[data-valmsg-for="ContratoProductoPaqueteDescripcion"]').text('');
    //    });
    //},
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
            $('#dgDatosContratoProductoPaquete').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ContratoProductoPaqueteId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'PaqueteId',
                        title:     'PaqueteId',
                        sortable:  true,
                        align:     'left',
                        visible:   false,
                    },
                    {
                        field:     'PaqueteDescripcion',
                        title:     'Paquete',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'EstatusId',
                        title:     'Activo',
                        formatter: 'EstatusIdFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        formatter: this.accion(),
                        events:    'ContratoProductoPaquete_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pContratoProductoId: $("#txtContratoProductoId").val()
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ContratoProductoPaquete + 'ContratoProductoPaqueteJson',
                json
            );

            $('#dgDatosContratoProductoPaquete').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<a class="removeContratoProductoPaquete" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-close fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    //buscar: function () {
    //    if (!this.validaBusqueda()) return;

    //    this.tabla.inicializa();
    //    this.tabla.datos();
    //},
    //validaBusqueda: function () {
    //    if ($("#txtContratoProductoPaqueteDescripcion").val().trim() == "") {
    //        $('span[data-valmsg-for="ContratoProductoPaqueteDescripcion"]').text('Campo Requerido');
    //        $("#txtContratoProductoPaqueteDescripcion").focus();

    //        return false;
    //    }

    //    return true;
    //},
    validaGuardar:            function () {
        if ($("#txtContratoProductoPaqueteDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ContratoProductoPaqueteDescripcion"]').text('Campo Requerido');
            $("#txtContratoProductoPaqueteDescripcion").focus();

            return false;
        }

        return true;
    },
    //limpiar: function () {
    //    this.inicializa('CONTRATO_PRODUCTO_PAQUETE_INDEX');
    //},
    redirecciona:             function (evento) {
        if (evento == 'CONTRATO_PRODUCTO_INDEX') {
            $(location).attr('href', URL.ContratoProducto + "?pContratoId=" + $("#txtContratoId").val() + "&pContratoDescripcion=" + $("#txtContratoDescripcion").val());
        };

        if (evento == 'CONTRATO_PRODUCTO_PAQUETE_INDEX') {
            $(location).attr('href', URL.ContratoProductoPaquete + "?pContratoProductoId=" + $("#txtContratoProductoId").val() + "&pContratoProductoDescripcion=" + $("#txtContratoProductoDescripcion").val() + "&pContratoId=" + $("#txtContratoId").val() + " & pContratoDescripcion=" + $("#txtContratoDescripcion").val());
        };

        if (evento == 'CONTRATO_PRODUCTO_PAQUETE_CREATE') {
            $(location).attr('href', URL.ContratoProductoPaquete + 'Create');
        };
    },
    //limpiarCtrls: function () {
    //    $('#txtContratoProductoPaqueteDescripcion').val('');

    //    $('span[data-valmsg-for="ContratoProductoPaqueteDescripcion"]').text('');

    //    $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
    //    $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
    //    $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    //},
    //habilitaDesHabilitaCtrls: function (isDisabled) {
    //    DisabledEneableElement('txtContratoProductoPaqueteDescripcion', isDisabled);
    //}
    AbreModalPaqueteProducto: function () {
        $("#myModalPaquetesProducto").modal();

        $("#txtCtrlUserBusqueadaPaqueteDescripcion").val("");

        $('#dgDatosCtrlUserBusquedaPaquete').bootstrapTable('removeAll');

        CtrlUserBusquedaPaquete.inicializa("CTRL_USER_BUSQUEDA_PAQUETE", "PRODUCTO");
    },
    AgregarPaqueteProducto:   function () {
        var data = $('#dgDatosCtrlUserBusquedaPaquete').bootstrapTable('getSelections');

        if (data.length == 0) {
            swal("Debe seleccionar un paquete", "", "warning");

            return;
        }

        var item         = {};
        var _listDetalle = [];

        $('span[data-valmsg-for="CtrlUserBusqueadaPaqueteDescripcion"]').text('');

        $.each(data, function (index, value) {
            item = {
                ContratoProductoPaqueteId: 0,
                ContratoProductoId:        $("#txtContratoProductoId").val(),
                PaqueteId:                 value.PaqueteId
            }

            _listDetalle.push(item);
        });

        ContratoProductoPaquete.guardar(_listDetalle);

        $("#myModalPaquetesProducto").modal("toggle");
    }
};




window.ContratoProductoPaquete_ActionEvents = {
    'click .editContratoProductoPaquete':   function (e, value, row, index) {
        $(location).attr('href', URL.ContratoProductoPaquete + 'Edit?pContratoProductoPaqueteId=' + row.ContratoProductoPaqueteId);
    },
    'click .removeContratoProductoPaquete': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        ContratoProductoPaquete.baja(row.ContratoProductoPaqueteId, row.PaqueteDescripcion);
        //$(location).attr('href', URL.ContratoProductoPaquete + 'Delete?pContratoProductoPaqueteId=' + row.ContratoProductoPaqueteId);
    }
};