var CtrlUserBusquedaCirugia = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_CIRUGIA_VIEW') {

            this.tabla.inicializa();
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pCirugiaId: $('#txtCirugiaId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Cirugia + 'CirugiaElementoJson',
            json
        );

        if (res != null) {
            $("#txtCirugiaDescripcion").val(res.data.Datos[0].CirugiaDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            CirugiaId: 0,
            CirugiaDescripcion: $("#txtCirugiaDescripcion").val().trim()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Cirugia + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Cirugia.redirecciona('SERVICIO_MEDICO_INDEX'); }, 2000);
                else
                    this.redirecciona('SERVICIO_MEDICO_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            CirugiaId: $("#txtCirugiaId").val(),
            CirugiaDescripcion: $("#txtCirugiaDescripcion").val().trim(),
            EstatusId: ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Cirugia + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Cirugia.redirecciona('SERVICIO_MEDICO_INDEX'); }, 2000);
                else
                    this.redirecciona('SERVICIO_MEDICO_INDEX');
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
                        CirugiaId: $("#txtCirugiaId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Cirugia + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Cirugia.redirecciona('SERVICIO_MEDICO_INDEX'); }, 2000);
                            else
                                this.redirecciona('SERVICIO_MEDICO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtCirugiaDescripcion").on("change paste keyup", function () {
            if ($("#txtCirugiaDescripcion").val().trim() == "")
                $('span[data-valmsg-for="CirugiaDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CirugiaDescripcion"]').text('');
        });
    },
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.Cirugia + "CirugiaComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserCirugiaView').bootstrapTable({
                pagination: true,
                search: false,
                columns: [
                    {
                        field: 'PaqueteDetalleId',
                        title: 'Folio',
                        sortable: true,
                        align: 'center'
                    },
                    {
                        field: 'ServicioDescripcion',
                        title: 'Cirugia',
                        sortable: true,
                        align: 'left'
                    },
                    {
                        field: '',
                        title: 'Acción',
                        sortable: true,
                        formatter: this.accion(),
                        events: 'CtelUserCirugiaView_ActionEvents',
                        align: 'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pCirugiaDescripcion: $('#txtCirugiaDescripcion').val().trim(),
                pEstatusId: $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Cirugia + 'CirugiaGridJson',
                json
            );

            $('#dgDatosCirugia').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                //'<a class="editCtrlUSerCirugiaView" href="javascript:void(0)" title="Editar">',
                //'<i class="text-success fa fa-pencil fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeCtrlUSerCirugiaView" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-trash fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtCirugiaDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="CirugiaDescripcion"]').text('Campo Requerido');
            $("#txtCirugiaDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtCirugiaDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="CirugiaDescripcion"]').text('Campo Requerido');
            $("#txtCirugiaDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('SERVICIO_MEDICO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'SERVICIO_MEDICO_INDEX') {
            $(location).attr('href', URL.Cirugia);
        };

        if (evento == 'SERVICIO_MEDICO_CREATE') {
            $(location).attr('href', URL.Cirugia + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtCirugiaDescripcion').val('');

        $('span[data-valmsg-for="CirugiaDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtCirugiaDescripcion', isDisabled);
    }
};




window.Cirugia_ActionEvents = {
    'click .editCirugia': function (e, value, row, index) {
        $(location).attr('href', URL.Cirugia + 'Edit?pCirugiaId=' + row.CirugiaId);
    },
    'click .removeCirugia': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Cirugia + 'Delete?pCirugiaId=' + row.CirugiaId);
    }
};




//$(function () {
//    $('#dgDatosCtrlUserCirugiaView').bootstrapTable({});
//    $('#dgDatosCtrlUserCirugia').bootstrapTable({});
//});

//function GridCtrlUserCirugiaView(pPaqueteId, pCirugiaDescripcion) {
//    $.ajax({
//        url: URL.Cirugia + 'CtrlUserCirugiaPaqueteViewJson?pPaqueteId=' + pPaqueteId + '&pCirugiaDescripcion=' + pCirugiaDescripcion,
//        data: "",
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $('#dgDatosCtrlUserCirugiaView').bootstrapTable("load", response.result.data);

//            if (response.result.data.length > 0)
//                $("#lblTabCirugia").text('Cirugiaes(' + response.result.data[0].CantidadCirugia + ')');
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });
//};

//function AbreModalCtrlUserCirugia() {
//    $('#dgDatosCtrlUserCirugia').bootstrapTable('removeAll');
//    $('#CtrlCirugiaDescripcion').val('');

//    $("#myModalCirugia").modal();
//};

//function GridCtrlUserCirugia(pPaqueteId, pPaqueteDescripcion, pCirugiaDescripcion) {
//    $.ajax({
//        url: URL.Cirugia + 'CtrlUserCirugiaJson?pPaqueteId=' + pPaqueteId + '&pPaqueteDescripcion=' + pPaqueteDescripcion + '&pCirugiaDescripcion=' + pCirugiaDescripcion,
//        data: "",
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $('#dgDatosCtrlUserCirugia').bootstrapTable("load", response.result.data);
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });
//};

//function CirugiaConPrecio(CirugiaDescripcion, ctrl) {
//    $.ajax({
//        url: URL.Cirugia + 'CirugiaConPrecioListJson?pDescripcion=' + CirugiaDescripcion,
//        data: "",
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $('#' + ctrl).bootstrapTable("load", response.result.data);
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });
//};

//function BajaLogicaCirugia(pPaqueteDetalleId) {
//    swal({
//        title: "¿Estás seguro de eliminar el registro?",
//        text: "",
//        type: "warning",
//        showCancelButton: true,
//        confirmButtonColor: "#DD6B55",
//        confirmButtonText: "Si",
//        cancelButtonText: "No",
//        closeOnConfirm: false,
//        closeOnCancel: false
//    },
//        function (isConfirm) {
//            if (isConfirm) {
//                $.ajax({
//                    url: URL.PaqueteDetalle + 'Delete?pPaqueteDetalleId=' + pPaqueteDetalleId,
//                    data: "",
//                    type: 'POST',
//                    async: false,
//                    contentType: "application/json; charset=utf-8",
//                    success: function (response) {
//                        if (response.result.data.Id > 0) {
//                            swal({
//                                text: '',
//                                title: '' + response.result.data.Mensaje,
//                                type: 'success'
//                            },
//                            function () {
//                                if ($("#txtApuntador").val() == "PRODUCTO")
//                                    $(location).attr('href', URL.PaqueteDetalle + 'Index?pPaqueteId=' + $("#PaqueteId").val() + '&pPaqueteDescripcion=' + $("#PaqueteDescripcion").val());
//                                else
//                                    $(location).attr('href', URL.PaqueteCoberturaDetalle + 'Index?pPaqueteId=' + $("#PaqueteId").val() + '&pPaqueteDescripcion=' + $("#PaqueteDescripcion").val());
//                            });
//                        }
//                    },
//                    error: function (XMLHttpRequest, success, errorThrown) {
//                        alert("Error", "NovaSys", XMLHttpRequest.responseText)
//                    }
//                });
//            }
//            else {
//                swal("La acción se ha cancelado", "", "error");
//                return false;
//            }
//        });
//}

//function operateActionFormatter_CtrlUserCirugiaView(value, row, index) {
//    return [
//        '<a class="remove" href="javascript:BajaLogicaCirugia(' + row.PaqueteDetalleId + ');" title="Inactivo">',
//            '<i class="text-danger fa fa-times fa-lg"></i>',
//        '</a>'
//    ].join('');
//};




//$(function () {
//    $('#dgDatosCtrlUserCirugiaView').bootstrapTable({});
//    $('#dgDatosCtrlUserCirugia').bootstrapTable({});
//});

//function GridCtrlUserCirugiaView(pPaqueteId, pCirugiaDescripcion) {
//    $.ajax({
//        url: URL.Cirugia + 'CtrlUserCirugiaPaqueteViewJson?pPaqueteId=' + pPaqueteId + '&pCirugiaDescripcion=' + pCirugiaDescripcion,
//        data: "",
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $('#dgDatosCtrlUserCirugiaView').bootstrapTable("load", response.result.data);

//            if (response.result.data.length > 0)
//                $("#lblTabCirugia").text('Cirugías (' + response.result.data[0].CantidadCirugia + ')');
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });
//};

//function AbreModalCtrlUserCirugia() {
//    $('#dgDatosCtrlUserCirugia').bootstrapTable('removeAll');
//    $('#CtrlCirugiaDescripcion').val('');

//    $("#myModalCirugia").modal();
//};

//function GridCtrlUserCirugia(pPaqueteId, pPaqueteDescripcion, pCirugiaDescripcion) {
//    $.ajax({
//        url: URL.Cirugia + 'CirugiaJson?pPaqueteId=' + pPaqueteId + '&pPaqueteDescripcion=' + pPaqueteDescripcion + '&pCirugiaDescripcion=' + pCirugiaDescripcion,
//        data: "",
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $('#dgDatosCtrlUserCirugia').bootstrapTable("load", response.result.data);
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });
//};

//function CirugiaConPrecio(CirugiaDescripcion, ctrl) {
//    $.ajax({
//        url: URL.Cirugia + 'CirugiaConPrecioListJson?pDescripcion=' + CirugiaDescripcion,
//        data: "",
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $('#' + ctrl).bootstrapTable("load", response.result.data);
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });
//};

//function ValidaPrecioCero(value, row, index) {
//    if (row.Precio == 0) {
//        return {
//            disabled: true,
//            checked: false
//        }
//    }

//    return value;
//}

//function BajaLogicaCirugia(pPaqueteDetalleId) {
//    swal({
//        title: "¿Estás seguro de eliminar el registro?",
//        text: "",
//        type: "warning",
//        showCancelButton: true,
//        confirmButtonColor: "#DD6B55",
//        confirmButtonText: "Si",
//        cancelButtonText: "No",
//        closeOnConfirm: false,
//        closeOnCancel: false
//    },
//        function (isConfirm) {
//            if (isConfirm) {
//                $.ajax({
//                    url: URL.PaqueteDetalle + 'Delete?pPaqueteDetalleId=' + pPaqueteDetalleId,
//                    data: "",
//                    type: 'POST',
//                    async: false,
//                    contentType: "application/json; charset=utf-8",
//                    success: function (response) {
//                        if (response.result.data.Id > 0) {
//                            swal({
//                                text: '',
//                                title: '' + response.result.data.Mensaje,
//                                type: 'success'
//                            },
//                            function () {
//                                if ($("#txtApuntador").val() == "PRODUCTO")
//                                    $(location).attr('href', URL.PaqueteDetalle + 'Index?pPaqueteId=' + $("#PaqueteId").val() + '&pPaqueteDescripcion=' + $("#PaqueteDescripcion").val());
//                                else
//                                    $(location).attr('href', URL.PaqueteCoberturaDetalle + 'Index?pPaqueteId=' + $("#PaqueteId").val() + '&pPaqueteDescripcion=' + $("#PaqueteDescripcion").val());
//                            });
//                        }
//                    },
//                    error: function (XMLHttpRequest, success, errorThrown) {
//                        alert("Error", "NovaSys", XMLHttpRequest.responseText)
//                    }
//                });
//            }
//            else {
//                swal("La acción se ha cancelado", "", "error");
//                return false;
//            }
//        });
//}

//function operateActionFormatter_CtrlUserCirugiaView(value, row, index) {
//    return [
//        '<a class="remove" href="javascript:BajaLogicaCirugia(' + row.PaqueteDetalleId + ');" title="Inactivo">',
//            '<i class="text-danger fa fa-times fa-lg"></i>',
//        '</a>'
//    ].join('');
//};