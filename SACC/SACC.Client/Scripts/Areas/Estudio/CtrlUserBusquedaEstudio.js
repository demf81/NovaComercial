var CtrlUserBusquedaEstudio = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_BUSQUEDA_ESTUDIO') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
        };
    },
    keyEvent: function () {
        $("#txtCtrlUserBusquedaEstudioDescripcion").on("change paste keyup", function () {
            if ($("#txtCtrlUserBusquedaEstudioDescripcion").val().trim() == "")
                $('span[data-valmsg-for="CtrlUserBusquedaEstudioDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserBusquedaEstudioDescripcion"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserBusquedaEstudio').bootstrapTable({
                pagination: true,
                search: false,
                columns: [
                    {
                        field:    'ItemId',
                        title:    'Folio',
                        sortable: true,
                        align:    'center'
                    },
                    {
                        field:    'ItemTipoId',
                        title:    'ItemTipoId',
                        sortable: true,
                        align:    'left',
                        visible:  false
                    },
                    {
                        field:    'ItemDescripcion',
                        title:    'Estudio',
                        sortable: true,
                        align:    'left'
                    },
                    {
                        field:   'state',
                        title:    '',
                        checkbox: true
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pServicioDescripcion: $('#txtCtrlUserBusquedaEstudioDescripcion').val().trim(),
                pServicioTipoId: -1
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Servicio + 'CtrlUserEstudioConPrecioGridJson',
                json
            );

            $('#dgDatosCtrlUserBusquedaEstudio').bootstrapTable("load", res.data.Datos);
        },
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtCtrlUserBusquedaEstudioDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="CtrlUserBusquedaEstudioDescripcion"]').text('Campo Requerido');
            $("#txtCtrlUserBusquedaEstudioDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiarCtrls: function () {
        $('#txtCtrlUserBusquedaEstudioDescripcion').val('');
        $('span[data-valmsg-for="CtrlUserBusquedaEstudioDescripcion"]').text('');

        $('#dgDatosCtrlUserBusquedaEstudio').bootstrapTable('removeAll');
    }
};




window.Estudio_ActionEvents = {
    'click .editEstudio': function (e, value, row, index) {
        $(location).attr('href', URL.Estudio + 'Edit?pEstudioId=' + row.EstudioId);
    },
    'click .removeEstudio': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Estudio + 'Delete?pEstudioId=' + row.EstudioId);
    }
};




//$(function () {
//    $('#dgDatosCtrlUserEstudioView').bootstrapTable({});
//    $('#dgDatosCtrlUserEstudio').bootstrapTable({});
//});

//function GridCtrlUserEstudioView(pPaqueteId, pEstudioDescripcion) {
//    $.ajax({
//        url: URL.Estudio + 'CtrlUserEstudioPaqueteViewJson?pPaqueteId=' + pPaqueteId + '&pEstudioDescripcion=' + pEstudioDescripcion,
//        data: "",
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $('#dgDatosCtrlUserEstudioView').bootstrapTable("load", response.result.data);

//            if (response.result.data.length > 0)
//                $("#lblTabEstudio").text('Estudioes(' + response.result.data[0].CantidadEstudio + ')');
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });
//};

//function AbreModalCtrlUserEstudio() {
//    $('#dgDatosCtrlUserEstudio').bootstrapTable('removeAll');
//    $('#CtrlEstudioDescripcion').val('');

//    $("#myModalEstudio").modal();
//};

//function GridCtrlUserEstudio(pPaqueteId, pPaqueteDescripcion, pEstudioDescripcion) {
//    $.ajax({
//        url: URL.Estudio + 'CtrlUserEstudioJson?pPaqueteId=' + pPaqueteId + '&pPaqueteDescripcion=' + pPaqueteDescripcion + '&pEstudioDescripcion=' + pEstudioDescripcion,
//        data: "",
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $('#dgDatosCtrlUserEstudio').bootstrapTable("load", response.result.data);
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });
//};

//function EstudioConPrecio(EstudioDescripcion, ctrl) {
//    $.ajax({
//        url: URL.Estudio + 'EstudioConPrecioListJson?pDescripcion=' + EstudioDescripcion,
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

//function BajaLogicaEstudio(pPaqueteDetalleId) {
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

//function operateActionFormatter_CtrlUserEstudioView(value, row, index) {
//    return [
//        '<a class="remove" href="javascript:BajaLogicaEstudio(' + row.PaqueteDetalleId + ');" title="Inactivo">',
//            '<i class="text-danger fa fa-times fa-lg"></i>',
//        '</a>'
//    ].join('');
//};




//$(function () {
//    $('#dgDatosCtrlUserEstudioView').bootstrapTable({});
//    $('#dgDatosCtrlUserEstudio').bootstrapTable({});
//});

//function GridCtrlUserEstudioView(pPaqueteId, pEstudioDescripcion) {
//    $.ajax({
//        url: URL.Estudio + 'CtrlUserEstudioPaqueteViewJson?pPaqueteId=' + pPaqueteId + '&pEstudoiDescripcion=' + pEstudioDescripcion,
//        data: "",
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $('#dgDatosCtrlUserEstudioView').bootstrapTable("load", response.result.data);

//            if (response.result.data.length > 0)
//                $("#lblTabEstudio").text('Estudios (' + response.result.data[0].CantidadEstudio + ')');
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });
//};

//function AbreModalCtrlUserEstudio() {
//    $('#dgDatosCtrlUserEstudio').bootstrapTable('removeAll');
//    $('#CtrlEstudioDescripcion').val('');

//    $("#myModalEstudio").modal();
//};

//function GridCtrlUserEstudio(pPaqueteId, pPaqueteDescripcion, pEstudioDescripcion) {
//    $.ajax({
//        url: URL.Estudio + 'CtrlUserEstudioJson?pPaqueteId=' + pPaqueteId + '&pPaqueteDescripcion=' + pPaqueteDescripcion + '&pEstudioDescripcion=' + pEstudioDescripcion,
//        data: "",
//        type: 'POST',
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $('#dgDatosCtrlUserEstudio').bootstrapTable("load", response.result.data);
//        },
//        error: function (XMLHttpRequest, success, errorThrown) {
//            alert("Error", "NovaSys", XMLHttpRequest.responseText)
//        }
//    });
//};

//function EstudioConPrecio(EstudioDescripcion, ctrl) {
//    $.ajax({
//        url: URL.Estudio + 'EstudioConPrecioListJson?pDescripcion=' + EstudioDescripcion,
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

//function BajaLogicaEstudio(pPaqueteDetalleId) {
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

//function operateActionFormatter_CtrlUserEstudioView(value, row, index) {
//    return [
//        '<a class="remove" href="javascript:BajaLogicaEstudio(' + row.PaqueteDetalleId + ')" title="Inactivo">',
//            '<i class="text-danger fa fa-times fa-lg"></i>',
//        '</a>'
//    ].join('');
//};