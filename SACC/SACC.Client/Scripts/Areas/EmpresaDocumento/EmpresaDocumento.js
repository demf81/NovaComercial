$(function () {
    EmpresaDocumento.inicializa($("#txtApuntadorEmpresaDocumento").val());
});




var EmpresaDocumento = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'EMPRESA_DOCUMENTO_INDEX') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'EMPRESA_DOCUMENTO_CREATE') {
            this.limpiarCtrls();
            this.keyEvent();
        };
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        debugger;

        var file = $("#txtEmpresaDocumentoArchivo").get(0).files[0];

        //var _obj = new FormData();
        //_obj.append("Archivo",                file);
        //_obj.append("NombreArchivo",          file.name);
        //_obj.append("EmpresaId",              $("#txtEmpresaId").val());
        //_obj.append("EmpresaDocumentoTipoId", $("#ddlEmpresaDocumentoTipoId").val());
        //_obj.append("EmpresaArchivoTipoId",   $("#ddlEmpresaDocumentoArchivoTipo").val());

        var _obj = {
            EmpresaDocumentoId: 0,
            EmpresaId: $("#txtEmpresaId").val(),
            EmpresaDocumentoTipoId: $("#ddlEmpresaDocumentoTipoId").val(),
            EmpresaArchivoTipoId: $("#ddlEmpresaDocumentoArchivoTipoId").val(),
            NombreArchivo: file.name,
            ArchivoH: file,
            Extension: file.name
        };

        var objJSON = {
            model: _obj
        };

        debugger;

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.EmpresaDocumento + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { EmpresaDocumento.redirecciona('EMPRESA_DOCUMENTO_INDEX'); }, 2000);
                else
                    this.redirecciona('EMPRESA_DOCUMENTO_INDEX');
    },
    guardarUpLoad: function () {
        if (!this.validaGuardar()) return;

        var file = $("#txtEmpresaDocumentoArchivo").get(0).files[0];
        var data = new FormData();
        var res;

        data.append("ArchivoH", file);
        data.append("NombreArchivo", file.name);
        data.append("EmpresaId", $("#txtEmpresaId").val());
        data.append("EmpresaDocumentoTipoId", $("#ddlEmpresaDocumentoTipoId").val());
        data.append("EmpresaArchivoTipoId", $("#ddlEmpresaDocumentoArchivoTipoId").val());

        $.ajax({
            type: "POST",
            url: URL.EmpresaDocumento + 'CreateUpLoad',
            data: data,
            processData: false,
            contentType: false,
        }).done(function (data) {
            res = data;
        }).fail(function (response) {
            var strError = '';

            switch (response.status) {
                case 404:
                    strError = 'Recurso no encontrado';
                    break;
                default:
                    strError = 'Error no espesificado';
            };

            var objJSON = {
                success: false,
                data: {
                    Id: -1,
                    Mensaje: '',
                    TipoMensaje: 'error',
                    TituloError: 'Error JS - El ajax no se pudo procesar',
                    Error: true,
                    MensajeError: strError,
                    StatusCode: response.status,
                    MuestraAlert: true,
                    DelayTime: false,
                }
            };

            RunAlert(objJSON.data, RunAlert_Type_Enum.ERROR);
        }).always(function (data) {

            $("#myModalCreateEmpresaDocumento").modal("toggle");

            if (res != null)
                if (!res.data.Error)
                    if (res.data.MuestraAlert) {
                        RunAlert(res.data, RunAlert_Type_Enum.SUCCESS);

                        setTimeout(function () { EmpresaDocumento.redirecciona('EMPRESA_DOCUMENTO_INDEX'); }, 2000);
                    }
                    else
                        this.redirecciona('EMPRESA_DOCUMENTO_INDEX');
        });
    },
    baja: function (pEmpresaDocumentoId) {
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
                        EmpresaDocumentoId: pEmpresaDocumentoId
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.EmpresaDocumento + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { EmpresaDocumento.redirecciona('EMPRESA_DOCUMENTO_INDEX'); }, 2000);
                            else
                                this.redirecciona('EMPRESA_DOCUMENTO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $('#ddlEmpresaDocumentoTipoId').change(function () {
            if ($('#ddlEmpresaDocumentoTipoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="EmpresaDocumentoTipoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="EmpresaDocumentoTipoId"]').text('');
            };
        });

        $('#ddlEmpresaDocumentoArchivoTipoId').change(function () {
            if ($('#ddlEmpresaDocumentoArchivoTipoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="EmpresaDocumentoArchivoTipoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="EmpresaDocumentoArchivoTipoId"]').text('');
            };
        });

        $("#txtEmpresaDocumentoArchivo").on("change paste keyup", function () {
            if ($("#txtEmpresaDocumentoArchivo").val().trim() == "")
                $('span[data-valmsg-for="EmpresaDocumentoArchivo"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="EmpresaDocumentoArchivo"]').text('');
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
            $('#dgDatosEmpresaDocumento').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'EmpresaDocumentoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'EmpresaDocumentoTipoDescripcion',
                        title:     'Tipo de Documento',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'EmpresaArchivoTipoDescripcion',
                        title:     'Tipo de Archivo',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'NombreArchivo',
                        title:     'Nombre del Archivo',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'FechaCreacion',
                        title:     'Fecha Creacion',
                        sortable:  true,
                        align:     'center'
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
                        events:    'EmpresaDocumento_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pEmpresaId: $('#txtEmpresaId').val().trim(),
                pEstatusId: 1,
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.EmpresaDocumento + 'EmpresaDocumentoGridJson',
                json
            );

            $('#dgDatosEmpresaDocumento').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="downloadEmpresaDocumento" href="javascript:void(0)" title="Descargar">',
                '<i class="text-primary fa fa-download fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeEmpresaDocumento" href="javascript:void(0)" title="Inactivo">',
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
        if ($("#txtEmpresaDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="EmpresaDescripcion"]').text('Campo Requerido');
            $("#txtEmpresaDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($('#ddlEmpresaDocumentoTipo option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="EmpresaDocumentoTipo"]').text('Campo Requerido');
            $("#ddlEmpresaDocumentoTipo").focus();

            return false;
        };
        if ($('#ddlEmpresaDocumentoArchivoTipo option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="EmpresaDocumentoArchivoTipo"]').text('Campo Requerido');
            $("#ddlEmpresaDocumentoArchivoTipo").focus();

            return false;
        };
        if ($("#txtEmpresaDocumentoArchivo").val().trim() == "") {
            $('span[data-valmsg-for="EmpresaDocumentoArchivo"]').text('Campo Requerido');
            //$("#txtEmpresaDocumentoArchivo").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('EMPRESA_DOCUMENTO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'EMPRESA_INDEX') {
            $(location).attr('href', URL.Empresa);
        };

        if (evento == 'EMPRESA_DOCUMENTO_INDEX') {
            $(location).attr('href', URL.EmpresaDocumento + 'Index?pEmpresaId=' + $('#txtEmpresaId').val() + '&pEmpresaDescripcion=' + $('#txtEmpresaDEscripcion').val());
        };
    },
    limpiarCtrls: function () {
        $('#txtEmpresaDescripcion').val('');

        $('span[data-valmsg-for="EmpresaDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtEmpresaDescripcion', isDisabled);
    },
    abreModalCreate: function () {
        this.inicializa('EMPRESA_DOCUMENTO_CREATE');

        $("#myModalCreateEmpresaDocumento").modal();

        EmpresaArchivoTipo.llenaCombo('ddlEmpresaDocumentoArchivoTipoId', 'SELECCIONE');
        EmpresaDocumentoTipo.llenaCombo('ddlEmpresaDocumentoTipoId', 'SELECCIONE');
    }
};




window.EmpresaDocumento_ActionEvents = {
    'click .downloadEmpresaDocumento': function (e, value, row, index) {

        $(location).attr('href', URL.EmpresaDocumento + 'DownloadEmpresaDocumento?pEmpresaDocumentoId=' + row.EmpresaDocumentoId);
    },
    'click .removeEmpresaDocumento':   function (e, value, row, index) {
        if (row.EstatusId == 2) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        EmpresaDocumento.baja(row.EmpresaDocumentoId);
    }
};