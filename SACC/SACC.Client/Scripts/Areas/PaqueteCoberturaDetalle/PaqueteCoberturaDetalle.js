$(function () {
    PaqueteCoberturaDetalle.inicializa($("#txtApuntadorPaqueteCoberturaDetalle").val());
});




var PaqueteCoberturaDetalle = {
    evento:                            null,
    inicializa:                        function (evento) {
        this.evento = evento;

        if (this.evento == 'PAQUETE_COBERTURA_DETALLE_INDEX') {
            this.keyEventIndex();

            $('#rootwizardDetalle').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified',
                onTabShow: function (tab, navigation, index) {
                    if (index == 0) {
                        $("#txtPestaniaActiva").val("SERVICIOS_MEDICOS");
                    } else if (index == 1) {
                        $("#txtPestaniaActiva").val("MAERIALES");
                    } else if (index == 2) {
                        $("#txtPestaniaActiva").val("MEDICAMENTOS");
                    } else if (index == 3) {
                        $("#txtPestaniaActiva").val("ESTUDIOS");
                    } else if (index == 2) {
                        $("#txtPestaniaActiva").val("CIRUGIAS")
                    }
                }
            });

            CtrlUserServicioMedicoPaqueteCoberturaDetalleView.inicializa('CTRL_USER_SERVICIO_MEDICO_PAQUETE_COBERTURA_DETALLE_VIEW');
            CtrlUserMaterialPaqueteCoberturaDetalleView.inicializa('CTRL_USER_MATERIAL_PAQUETE_COBERTURA_DETALLE_VIEW');
            CtrlUserMedicamentoPaqueteCoberturaDetalleView.inicializa('CTRL_USER_MEDICAMENTO_PAQUETE_COBERTURA_DETALLE_VIEW');
            CtrlUserEstudioPaqueteCoberturaDetalleView.inicializa('CTRL_USER_ESTUDIO_PAQUETE_COBERTURA_DETALLE_VIEW');
            CtrlUserCirugiaPaqueteCoberturaDetalleView.inicializa('CTRL_USER_CIRUGIA_PAQUETE_COBERTURA_DETALLE_VIEW');

            if ($("#txtPestaniaActiva").val() == "SERVICIOS_MEDICOS")
                $('#rootwizardDetalle').find("a[href*='tabD1']").trigger('click');

            if ($("#txtPestaniaActiva").val() == "MAERIALES")
                $('#rootwizardDetalle').find("a[href*='tabD2']").trigger('click');

            if ($("#txtPestaniaActiva").val() == "MEDICAMENTOS")
                $('#rootwizardDetalle').find("a[href*='tabD3']").trigger('click');

            if ($("#txtPestaniaActiva").val() == "ESTUDIOS")
                $('#rootwizardDetalle').find("a[href*='tabD4']").trigger('click');

            if ($("#txtPestaniaActiva").val() == "CIRUGIAS")
                $('#rootwizardDetalle').find("a[href*='tabD5']").trigger('click');
        };
    },
    guardar:                           function (pMetodo) {
        if (!this.validaGuardar(pMetodo)) return;

        var data       = null;
        var ItemTipoId = 0;

        if (pMetodo == "MODAL_SERVICIO_MEDICO") {
            data       = $('#dgDatosCtrlUserBusquedaServicioMedico').bootstrapTable('getSelections');
            ItemTipoId = 1;

            $("#myModalBusquedaServicioMedico").modal('hide');
        };

        if (pMetodo == "MODAL_MATERIAL") {
            data       = $('#dgDatosCtrlUserBusquedaMaterial').bootstrapTable('getSelections');
            ItemTipoId = 2;

            $("#myModalBusquedaMaterial").modal('hide');
        };

        if (pMetodo == "MODAL_MEDICAMENTO") {
            data       = $('#dgDatosCtrlUserBusquedaMedicamento').bootstrapTable('getSelections');
            ItemTipoId = 3;

            $("#myModalBusquedaMedicamento").modal('hide');
        };

        if (pMetodo == "MODAL_CIRUGIA") {
            data       = $('#dgDatosCtrlUserBusquedaCirugia').bootstrapTable('getSelections');
            ItemTipoId = 4;

            $("#myModalBusquedaCirugia").modal('hide');
        };

        if (pMetodo == "MODAL_ESTUDIO") {
            data       = $('#dgDatosCtrlUserBusquedaEstudio').bootstrapTable('getSelections');
            ItemTipoId = 5;

            $("#myModalBusquedaEstudio").modal('hide');
        };

        var _listItems = [];

        $.each(data, function (index, value) {
            var item = {
                PaqueteId:  $("#txtPaqueteId").val(),
                ItemTipoId: ItemTipoId,
                ItemId:     value.ItemId,
            }

            _listItems.push(item);
        });

        var objJSON = {
            lista: _listItems
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.PaqueteDetalle + 'Create',
            json
        );

        var pPestaniaActiva = '';
        switch (pMetodo) {
            case "MODAL_SERVICIO_MEDICO":
                pPestaniaActiva = 'SERVICIOS_MEDICOS';
                break;

            case "MODAL_MATERIAL":
                pPestaniaActiva = 'MAERIALES';
                break;

            case "MODAL_MEDICAMENTO":
                pPestaniaActiva = 'MEDICAMENTOS';
                break;

            case "MODAL_CIRUGIA":
                pPestaniaActiva = 'CIRUGIAS';
                break;

            case "MODAL_ESTUDIO":
                pPestaniaActiva = 'ESTUDIOS';
                break;

            default:
                pPestaniaActiva = 'SERVICIOS_MEDICOS';
                break;
        }

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { PaqueteCoberturaDetalle.redirecciona('PAQUETE_COBERTURA_DETALLE_INDEX', pPestaniaActiva); }, 2000);
                else
                    this.redirecciona('PAQUETE_COBERTURA_DETALLE_INDEX', pPestaniaActiva);
    },
    baja:                              function (pPaqueteDetalleId, pItemDescripcion, pPestaniaActiva) {
        swal({
            title:              "¿Estás seguro de eliminar permanentemente el registro: (" + pItemDescripcion + ")?",
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

                    var objJSON = {
                        pPaqueteDetalleId: pPaqueteDetalleId
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.PaqueteDetalle + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { PaqueteCoberturaDetalle.redirecciona('PAQUETE_COBERTURA_DETALLE_INDEX', pPestaniaActiva); }, 2000);
                            else
                                PaqueteCoberturaDetalle.redirecciona('PAQUETE_COBERTURA_DETALLE_INDEX', pPestaniaActiva);
                }
                else {
                    swal.close();
                }
            });
    },
    validaGuardar:                     function (pMetodo) {
        if (pMetodo == "MODAL_SERVICIO_MEDICO") {
            var dataServicioMedico = $('#dgDatosCtrlUserBusquedaServicioMedico').bootstrapTable('getSelections');

            if (dataServicioMedico.length == 0) {
                swal("Debe seleccionar al menos un servicio", "", "warning");
                return false;
            }
        };

        if (pMetodo == "MODAL_MATERIAL") {
            var dataServicioMedico = $('#dgDatosCtrlUserBusquedaMaterial').bootstrapTable('getSelections');

            if (dataServicioMedico.length == 0) {
                swal("Debe seleccionar al menos un servicio", "", "warning");
                return false;
            }
        };

        if (pMetodo == "MODAL_MEDICAMENTO") {
            var dataServicioMedico = $('#dgDatosCtrlUserBusquedaServicioMedico').bootstrapTable('getSelections');

            if (dataServicioMedico.length == 0) {
                swal("Debe seleccionar al menos un servicio", "", "warning");
                return false;
            }
        };

        if (pMetodo == "MODAL_CIRUGIA") {
            var dataServicioMedico = $('#dgDatosCtrlUserBusquedaServicioMedico').bootstrapTable('getSelections');

            if (dataServicioMedico.length == 0) {
                swal("Debe seleccionar al menos un servicio", "", "warning");
                return false;
            }
        };

        if (pMetodo == "MODAL_ESTUDIO") {
            var dataServicioMedico = $('#dgDatosCtrlUserBusquedaServicioMedico').bootstrapTable('getSelections');

            if (dataServicioMedico.length == 0) {
                swal("Debe seleccionar al menos un servicio", "", "warning");
                return false;
            }
        };

        return true;
    },
    keyEventIndex:                     function () {
        $('#dgDatosCtrlUserServicioMedicoPaqueteCoberturaDetalleView').on('click', 'tbody tr', function (event) {
            if ($("#txtPestaniaActiva").val() == "SERVICIOS_MEDICOS") {
                var selected = $(this).hasClass("warning");

                $("#dgDatosCtrlUserServicioMedicoPaqueteCoberturaDetalleView tr").removeClass("warning");

                if (!selected)
                    $(this).addClass("warning");
            }
        });

        $('#dgDatosCtrlUserMaterialPaqueteCoberturaDetalleView').on('click', 'tbody tr', function (event) {
            if ($("#txtPestaniaActiva").val() == "MAERIALES") {
                var selected = $(this).hasClass("warning");

                $("#dgDatosCtrlUserMaterialPaqueteCoberturaDetalleView tr").removeClass("warning");

                if (!selected)
                    $(this).addClass("warning");
            }
        });

        $('#dgDatosCtrlUserMedicamentoPaqueteCoberturaDetalleView').on('click', 'tbody tr', function (event) {
            if ($("#txtPestaniaActiva").val() == "MEDICAMENTOS") {
                var selected = $(this).hasClass("warning");

                $("#dgDatosCtrlUserMedicamentoPaqueteCoberturaDetalleView tr").removeClass("warning");

                if (!selected)
                    $(this).addClass("warning");
            }
        });

        $('#dgDatosCtrlUserEstudioPaqueteCoberturaDetalleView').on('click', 'tbody tr', function (event) {
            if ($("#txtPestaniaActiva").val() == "ESTUDIOS") {
                var selected = $(this).hasClass("warning");

                $("#dgDatosCtrlUserEstudioPaqueteCoberturaDetalleView tr").removeClass("warning");

                if (!selected)
                    $(this).addClass("warning");
            }
        });

        $('#dgDatosCtrlUserCirugiaPaqueteCoberturaDetalleView').on('click', 'tbody tr', function (event) {
            if ($("#txtPestaniaActiva").val() == "CIRUGIAS") {
                var selected = $(this).hasClass("warning");

                $("#dgDatosCtrlUserCirugiaPaqueteCoberturaDetalleView tr").removeClass("warning");

                if (!selected)
                    $(this).addClass("warning");
            }
        });
    },
    limpiar:                           function () {
        this.inicializa('PAQUETE_COBERTURA_INDEX');
    },
    redirecciona:                      function (evento, pPestaniaActiva) {
        if (evento == 'PAQUETE_COBERTURA_INDEX') {
            $(location).attr('href', URL.PaqueteCobertura);
        };

        if (evento == 'PAQUETE_COBERTURA_DETALLE_INDEX') {
            $(location).attr('href', URL.PaqueteCoberturaDetalle + '?pPaqueteId=' + $("#txtPaqueteId").val() + '&pPaqueteDescripcion=' + $("#txtPaqueteDescripcion").val() + '&pPestaniaActiva=' + pPestaniaActiva);
        };
    },
    AbreModalBusquedaServiciosMedicos: function () {
        $("#myModalBusquedaServicioMedico").modal();

        CtrlUserBusquedaServicioMedico.inicializa('CTRL_USER_BUSQUEDA_SERVICIO_MEDICO');
    },
    AbreModalBusquedaMateriales:       function () {
        $("#myModalBusquedaMaterial").modal();

        CtrlUserBusquedaMaterial.inicializa('CTRL_USER_BUSQUEDA_MATERIAL');
    },
    AbreModalBusquedaMedicamentos:     function () {
        debugger;
        $("#myModalBusquedaMedicamento").modal();

        CtrlUserBusquedaMedicamento.inicializa('CTRL_USER_BUSQUEDA_MEDICAMENTO');
    },
    AbreModalBusquedaEstudios:         function () {
        $("#myModalBusquedaEstudio").modal();

        CtrlUserBusquedaEstudio.inicializa('CTRL_USER_BUSQUEDA_ESTUDIO');
    },
    AbreModalBusquedaCirugias:         function () {
        $("#myModalBusquedaCirugia").modal();

        CtrlUserBusquedaCirugia.inicializa('CTRL_USER_BUSQUEDA_CIRUGIA');
    }
};