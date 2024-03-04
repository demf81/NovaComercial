﻿var CtrlUserServicioMedicoPaqueteDetalleView = {
    evento:         null,
    inicializa:     function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_SERVICIO_MEDICO_PAQUETE_DETALLE_VIEW') {
            ServicioMedicoTipo.llenaCombo('ddlCtrlUSerServicioTipoViewId', 'TODOS');

            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    keyEvent:       function () {
        $("#txtMaterialDescripcion").on("change paste keyup", function () {
            if ($("#txtMaterialDescripcion").val().trim() == "")
                $('span[data-valmsg-for="MaterialDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="MaterialDescripcion"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserServicioMedicoPaqueteDetalleView').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'PaqueteDetalleId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'CodigoServiciosMedicos',
                        title:     'Codigo Nexus',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:      'ItemTipoDescripcion',
                        title:      'Servicio Tipo',
                        sortable:   true,
                        align:      'left'
                    },
                    {
                        field:      'ItemDescripcion',
                        title:      'Servicio',
                        sortable:   true,
                        align:      'left'
                    },
                    {
                        field:     'EstudioRelacionado',
                        title:     'Estudio Relacionado',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'CtrlUser_PaqueteDetalle_ServicioMedico_View_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pOpcion:          7,
                pPaqueteId:       $('#txtPaqueteId').val().trim(),
                pItemId:          -1,
                pItemDescripcion: $("#txtCtrlUserServicioMedicoViewDescripcion").val(),
                pItenTipoId:      $("#ddlCtrlUSerServicioTipoViewId").val(),
                pEstatusId:       1,
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.PaqueteDetalle + 'CtrlUSerPaqueteDetalleViewJson',
                json
            );

            $('#dgDatosCtrlUserServicioMedicoPaqueteDetalleView').bootstrapTable("load", res.data.Datos);

            if (res.data.Datos.length > 0)
                $("#span_servisio").text('Servicios (' + res.data.Datos.length  + ')');
        },
        accion:     function (value, row, index) {
            return [
                '<a class="remove_CtrlUser_PaqueteDetalle_ServicioMedico_View" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-close fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar:         function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtMaterialDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="MaterialDescripcion"]').text('Campo Requerido');
            $("#txtMaterialDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar:        function () {
        this.inicializa('SERVICIO_MEDICO_INDEX');
    },
    limpiarCtrls:   function () {
        $('#txtServicioMedicoDescripcion').val('');

        $('span[data-valmsg-for="ServicioMedicoDescripcion"]').text('');
    }
};

window.CtrlUser_PaqueteDetalle_ServicioMedico_View_ActionEvents = {
    'click .remove_CtrlUser_PaqueteDetalle_ServicioMedico_View': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        PaqueteDetalle.baja(row.PaqueteDetalleId, row.ItemDescripcion, 'SERVICIOS_MEDICOS');
    }
};




var CtrlUserMaterialPaqueteDetalleView = {
    evento:         null,
    inicializa:     function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_MATERIAL_PAQUETE_DETALLE_VIEW') {
            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    keyEvent:       function () {
        $("#txtMaterialDescripcion").on("change paste keyup", function () {
            if ($("#txtMaterialDescripcion").val().trim() == "")
                $('span[data-valmsg-for="MaterialDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="MaterialDescripcion"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserMaterialPaqueteDetalleView').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'PaqueteDetalleId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'CodigoServiciosMedicos',
                        title:     'Codigo Nexus',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ItemDescripcion',
                        title:     'Material',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'CtrlUser_PaqueteDetalle_Material_View_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pOpcion:          8,
                pPaqueteId:       $('#txtPaqueteId').val().trim(),
                pItemId:          -1,
                pItemDescripcion: $("#txtCtrlUserMaterialViewDescripcion").val(),
                pItenTipoId:      -1,
                pEstatusId:       1,
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.PaqueteDetalle + 'CtrlUSerPaqueteDetalleViewJson',
                json
            );

            $('#dgDatosCtrlUserMaterialPaqueteDetalleView').bootstrapTable("load", res.data.Datos);

            if (res.data.Datos.length > 0)
                $("#span_material").text('Materiales (' + res.data.Datos.length + ')');
        },
        accion:     function (value, row, index) {
            return [
                '<a class="remove_CtrlUser_PaqueteDetalle_Material_View" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-close fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar:         function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtMaterialDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="MaterialDescripcion"]').text('Campo Requerido');
            $("#txtMaterialDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar:        function () {
        this.inicializa('SERVICIO_MEDICO_INDEX');
    },
    limpiarCtrls:   function () {
        $('#txtMaterialDescripcion').val('');

        $('span[data-valmsg-for="MaterialDescripcion"]').text('');
    }
};

window.CtrlUser_PaqueteDetalle_Material_View_ActionEvents = {
    'click .remove_CtrlUser_PaqueteDetalle_Material_View': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        PaqueteDetalle.baja(row.PaqueteDetalleId, row.ItemDescripcion, 'MAERIALES');
    }
};




var CtrlUserMedicamentoPaqueteDetalleView = {
    evento:         null,
    inicializa:     function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_MEDICAMENTO_PAQUETE_DETALLE_VIEW') {
            MedicamentoCuadroTipo.llenaCombo('ddlCtrlUserMedicamentoCuadroTipoViewId', 'TODOS');

            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    keyEvent:       function () {
        $("#txtMedicamentoDescripcion").on("change paste keyup", function () {
            if ($("#txtMedicamentoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="MedicamentoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="MedicamentoDescripcion"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserMedicamentoPaqueteDetalleView').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'PaqueteDetalleId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'CodigoServiciosMedicos',
                        title:     'Codigo Nexus',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ItemTipoDescripcion',
                        title:     'Cuadro Tipo',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'ItemDescripcion',
                        title:     'Medicamento',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'CtrlUser_PaqueteDetalle_Medicamento_View_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pOpcion:          9,
                pPaqueteId:       $('#txtPaqueteId').val().trim(),
                pItemId:          -1,
                pItemDescripcion: "",
                pItenTipoId:      -1,
                pEstatusId:       1,
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.PaqueteDetalle + 'CtrlUSerPaqueteDetalleViewJson',
                json
            );

            $('#dgDatosCtrlUserMedicamentoPaqueteDetalleView').bootstrapTable("load", res.data.Datos);

            if (res.data.Datos.length > 0)
                $("#span_medicamento").text('Medicamentos (' + res.data.Datos.length + ')');
        },
        accion:     function (value, row, index) {
            return [
                '<a class="remove_CtrlUser_PaqueteDetalle_Medicamento_View" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-close fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar:         function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtMedicamentoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="MedicamentoDescripcion"]').text('Campo Requerido');
            $("#txtMedicamentoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar:        function () {
        this.inicializa('SERVICIO_MEDICO_INDEX');
    },
    limpiarCtrls:   function () {
        $('#txtMedicamentoDescripcion').val('');

        $('span[data-valmsg-for="MedicamentoDescripcion"]').text('');
    },
};

window.CtrlUser_PaqueteDetalle_Medicamento_View_ActionEvents = {
    'click .remove_CtrlUser_PaqueteDetalle_Medicamento_View': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        PaqueteDetalle.baja(row.PaqueteDetalleId, row.ItemDescripcion, 'MEDICAMENTOS');
    }
};



var CtrlUserEstudioPaqueteDetalleView = {
    evento:         null,
    inicializa:     function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_ESTUDIO_PAQUETE_DETALLE_VIEW') {
            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    keyEvent:       function () {
        $("#txtEstudioDescripcion").on("change paste keyup", function () {
            if ($("#txtEstudioDescripcion").val().trim() == "")
                $('span[data-valmsg-for="EstudioDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="EstudioDescripcion"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserEstudioPaqueteDetalleView').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'PaqueteDetalleId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'CodigoServiciosMedicos',
                        title:     'Codigo Nexus',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ItemDescripcion',
                        title:     'Estudio',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'CtrlUser_PaqueteDetalle_Estudio_View_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pOpcion:          10,
                pPaqueteId:       $('#txtPaqueteId').val().trim(),
                pItemId:          -1,
                pItemDescripcion: "",
                pItenTipoId:      -1,
                pEstatusId:       1
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.PaqueteDetalle + 'CtrlUSerPaqueteDetalleViewJson',
                json
            );

            $('#dgDatosCtrlUserEstudioPaqueteDetalleView').bootstrapTable("load", res.data.Datos);

            if (res.data.Datos.length > 0)
                $("#span_estudio").text('Estudios (' + res.data.Datos.length + ')');
        },
        accion:     function (value, row, index) {
            return [
                '<a class="remove_CtrlUser_PaqueteDetalle_Estudio_View" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-close fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar:         function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtEstudioDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="EstudioDescripcion"]').text('Campo Requerido');
            $("#txtEstudioDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('SERVICIO_MEDICO_INDEX');
    },
    limpiarCtrls:   function () {
        $('#txtEstudioDescripcion').val('');

        $('span[data-valmsg-for="EstudioDescripcion"]').text('');
    },
};

window.CtrlUser_PaqueteDetalle_Estudio_View_ActionEvents = {
    'click .remove_CtrlUser_PaqueteDetalle_Estudio_View': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        PaqueteDetalle.baja(row.PaqueteDetalleId, row.ItemDescripcion, 'ESTUDIOS');
    }
};




var CtrlUserCirugiaPaqueteDetalleView = {
    evento:         null,
    inicializa:     function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_CIRUGIA_PAQUETE_DETALLE_VIEW') {
            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    keyEvent:       function () {
        $("#txtCirugiaDescripcion").on("change paste keyup", function () {
            if ($("#txtCirugiaDescripcion").val().trim() == "")
                $('span[data-valmsg-for="CirugiaDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CirugiaDescripcion"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserCirugiaPaqueteDetalleView').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'PaqueteDetalleId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ItemDescripcion',
                        title:     'Cirugia',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'CtelUserCirugiaView_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pOpcion:          11,
                pPaqueteId:       $('#txtPaqueteId').val().trim(),
                pItemId:          -1,
                pItemDescripcion: "",
                pItenTipoId:      -1,
                pEstatusId:       1
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.PaqueteDetalle + 'CtrlUSerPaqueteDetalleViewJson',
                json
            );

            $('#dgDatosCtrlUserCirugiaPaqueteDetalleView').bootstrapTable("load", res.data.Datos);

            if (res.data.Datos.length > 0)
                $("#span_cirugia").text('Cirugias (' + res.data.Datos.length + ')');
        },
        accion:     function (value, row, index) {
            return [
                '<a class="removeCtrlUSerCirugiaView" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-close fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar:         function () {
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
    limpiar:        function () {
        this.inicializa('SERVICIO_MEDICO_INDEX');
    },
    limpiarCtrls:   function () {
        $('#txtCirugiaDescripcion').val('');

        $('span[data-valmsg-for="CirugiaDescripcion"]').text('');
    },
};

window.CirugiaPaqueteDetalleView_ActionEvents = {
    'click .removeCirugia': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Cirugia + 'Delete?pCirugiaId=' + row.CirugiaId);
    }
};