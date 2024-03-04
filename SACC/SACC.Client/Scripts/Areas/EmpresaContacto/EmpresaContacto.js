var EmpresaContacto = {
    evento:        null,
    inicializa:    function (evento) {
        this.evento = evento;

        if (this.evento == 'EMPRESA_CONTACTO_INDEX') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'EMPRESA_CONTACTO_CREATE') {
            this.limpiarCtrls('Create');
            this.keyEvent('Create');

            ContactoTipo.llenaCombo('ddl_Create_ContactoTipoId', 'SELECCIONE');
        };

        if (this.evento == 'EMPRESA_CONTACTO_EDIT') {
            this.limpiarCtrls('Edit');
            this.keyEvent('Edit');

            ContactoTipo.llenaCombo('ddl_Edit_ContactoTipoId', 'SELECCIONE');

            this.cargaDatos();
        };

        if (this.evento == 'EMPRESA_CONTACTO_DELETE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            $("#txtDiaPago").TouchSpin({
                min: 1,
                max: 31,
                step: 1,
                decimals: 0,
                boostat: 5,
                maxboostedstep: 10,
            });

            Pais.llenaCombo('ddlPaisId', 'SELECCIONE');
            Estado.llenaCombo('ddlEstadoId', 'SELECCIONE', $("#ddlPaisId").val());
            Municipio.llenaCombo('ddlMunicipioId', 'SELECCIONE', $("#ddlPaisId").val(), $("#ddlEstadoId").val());

            EmpresaTipo.llenaCombo('ddlEmpresaTipoId', 'SELECCIONE');
            FormaPago.llenaCombo('ddlMetodoPagoId', 'SELECCIONE');
            FrecuenciaPago.llenaCombo('ddlFormaPagoId', 'SELECCIONE');
            MetodoPago.llenaCombo('ddlFrecuenciaPagoId', 'SELECCIONE');
            EmpresaPlanta.llenaCombo('ddlEmpresaVigenciaId', 'SELECCIONE');

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:    function () {
        var objJSON = {
            pEmpresaContactoId: $('#txtEmpresaContactoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.EmpresaContacto + 'EmpresaContactoElementoJson',
            json
        );

        if (res != null) {
            $("#txt_Edit_NombreContacto").val(res.data.Datos[0].Nombre);
            $("#txt_Edit_PaternoContacto").val(res.data.Datos[0].Paterno);
            $("#txt_Edit_MaternoContacto").val(res.data.Datos[0].Materno);
            $("#txt_Edit_DepartametoContacto").val(res.data.Datos[0].DepartamentoDescripcion);
            $("#ddl_Edit_ContactoTipoId").val(res.data.Datos[0].ContactoTipoId);
            $("#txt_Edit_TelefonoContacto").val(res.data.Datos[0].Telefono);
            $("#txt_Edit_ExtensionContacto").val(res.data.Datos[0].Extension);
            $("#txt_Edit_CorreoElectronicoContacto").val(res.data.Datos[0].CorreoElectronico);
        }
    },
    guardar:       function () {
        if (!this.validaGuardar('Create')) return;

        var _obj = {
            EmpresaContactoId:       0,
            EmpresaId:               $("#txtEmpresaId").val().trim(),
            Nombre:                  $("#txt_Create_NombreContacto").val().trim(),
            Paterno:                 $("#txt_Create_PaternoContacto").val().trim(),
            Materno:                 $("#txt_Create_MaternoContacto").val().trim(),
            DepartamentoDescripcion: $("#txt_Create_DepartametoContacto").val().trim(),
            ContactoTipoId:          $("#ddl_Create_ContactoTipoId").val(),
            Telefono:                parseInt($("#txt_Create_TelefonoContacto").val().trim()),
            Extension:               $("#txt_Create_ExtensionContacto").val().trim(),
            CorreoElectronico:       $("#txt_Create_CorreoElectronicoContacto").val().trim()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.EmpresaContacto + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error) {
                if (res.data.MuestraAlert)
                    setTimeout(function () { EmpresaContacto.redirecciona('EMPRESA_CONTACTO_CONTACTO'); }, 2000);
                else
                    this.redirecciona('EMPRESA_CONTACTO_CONTACTO');
            }

        $("#myModalCreateContacto").modal("toggle");
    },
    actualizar:    function () {
        if (!this.validaGuardar('Edit')) return;

        var _obj = {
            EmpresaContactoId:       $("#txtEmpresaContactoId").val(),
            EmpresaId:               $("#txtEmpresaId").val().trim(),
            Nombre:                  $("#txt_Edit_NombreContacto").val().trim(),
            Paterno:                 $("#txt_Edit_PaternoContacto").val().trim(),
            Materno:                 $("#txt_Edit_MaternoContacto").val().trim(),
            DepartamentoDescripcion: $("#txt_Edit_DepartametoContacto").val().trim(),
            ContactoTipoId:          $("#ddl_Edit_ContactoTipoId").val(),
            Telefono:                parseInt($("#txt_Edit_TelefonoContacto").val().trim()),
            Extension:               $("#txt_Edit_ExtensionContacto").val().trim(),
            CorreoElectronico:       $("#txt_Edit_CorreoElectronicoContacto").val().trim(),
        };

        var objJSON = {
            model: _obj,
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.EmpresaContacto + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error) {
                if (res.data.MuestraAlert)
                    setTimeout(function () { Empresa.redirecciona('EMPRESA_CONTACTO_CONTACTO'); }, 2000);
                else
                    this.redirecciona('EMPRESA_CONTACTO_CONTACTO');
            }

        $("#myModalEditContacto").modal("toggle");
    },
    baja:          function (pEmpresaContactoId, pContactoDescripcion) {
        swal({
            title:              "¿Estás seguro de eliminar permanentemente el congrato (" + pContactoDescripcion + ")?",
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
                        EmpresaContactoId: pEmpresaContactoId
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.EmpresaContacto + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { EmpresaContacto.redirecciona('EMPRESA_CONTACTO_CONTACTO'); }, 2000);
                            else
                                this.redirecciona('EMPRESA_CONTACTO_CONTACTO');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent:      function (metodo) {
        $('#txt_' + metodo + '_NombreContacto').on('change paste keyup', function () {
            if ($('#txt_' + metodo + '_NombreContacto').val().trim() == "")
                $('span[data-valmsg-for="' + metodo + '_NombreContacto"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="' + metodo + '_NombreContacto"]').text('');
        });

        $('#txt_' + metodo + '_PaternoContacto').on('change paste keyup', function () {
            if ($('#txt_' + metodo + '_PaternoContacto').val().trim() == "")
                $('span[data-valmsg-for="' + metodo + '_PaternoContacto"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="' + metodo + '_PaternoContacto"]').text('');
        });

        $('#txt_' + metodo + '_MaternoContacto').on('change paste keyup', function () {
            if ($('#txt_' + metodo + '_MaternoContacto').val().trim() == "")
                $('span[data-valmsg-for="' + metodo + '_MaternoContacto"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="' + metodo + '_MaternoContacto"]').text('');
        });

        $('#txt_' + metodo + '_DepartametoContacto').on("change paste keyup", function () {
            if ($('#txt_' + metodo + '_DepartametoContacto').val().trim() == "")
                $('span[data-valmsg-for="' + metodo + '_DepartametoContacto"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="' + metodo + '_DepartametoContacto"]').text('');
        });

        $('#ddl_' + metodo + '_ContactoTipoId').change(function () {
            if ($('#ddl_' + metodo + '_ContactoTipoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="' + metodo + '_ContactoTipoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="' + metodo + '_ContactoTipoId"]').text('');
            };

            if ($('#ddl_' + metodo + '_ContactoTipoId option:selected').text() == "Oficina") {
                $('span[data-valmsg-for="_' + metodo + '_Extension"]').text('');
            };
        });

        $('#txt_' + metodo + '_TelefonoContacto').on('change paste keyup', function () {
            if ($('#txt_' + metodo + '_TelefonoContacto').val().trim() == "")
                $('span[data-valmsg-for="' + metodo + '_TelefonoContacto"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="' + metodo + '_TelefonoContacto"]').text('');
        });

        $('#txt_' + metodo + '_TelefonoContacto').on('change paste keyup', function () {
            if ($('#txt_' + metodo + '_TelefonoContacto').val().length < 10)
                $('span[data-valmsg-for="' + metodo + '_TelefonoContacto"]').text('Teléfono invalido');
            else
                $('span[data-valmsg-for="' + metodo + '_TelefonoContacto"]').text('');
        });

        $('#txt_' + metodo + '_TelefonoContacto').keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });

        //$("#txtTelefono").keypress(function (e) {
        //    if ($("#txtTelefono").val().length == 10)
        //        return false;
        //});

        $('#txt_' + metodo + '_ExtensionContacto').on('change paste keyup', function () {
            if ($('#ddl_' + metodo + '_ContactoTipoId  option:selected').text() == "Oficina") {
                $('span[data-valmsg-for="' + metodo + '_ExtensionContacto"]').text('');
            }
            else {
                if ($('#txtE_' + metodo + '_xtension').val().trim() == "")
                    $('span[data-valmsg-for="' + metodo + '_ExtensionContacto"]').text('Campo Requerido');
                else
                    $('span[data-valmsg-for="' + metodo + '_ExtensionContacto"]').text('');
            };
        });

        $('#txt_' + metodo + '_ExtensionContacto').keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });

        $('#txt_' + metodo + '_CorreoElectronicoContacto').on('change paste keyup', function () {
            if ($('#txt_' + metodo + '_CorreoElectronicoContacto').val().trim() == "")
                $('span[data-valmsg-for="' + metodo + '_CorreoElectronicoContacto"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="' + metodo + '_CorreoElectronicoContacto"]').text('');
        });

        var validarEmail = /^\w+([.-_+]?\w+)*@\w+([.-]?\w+)*(\.\w{2,10})+$/;
        $('#txt_' + metodo + '_CorreoElectronicoContacto').on('change paste keyup', function () {
            if (!validarEmail.test($('#txt_' + metodo + '_CorreoElectronicoContacto').val().trim()))
                $('span[data-valmsg-for="' + metodo + '_CorreoElectronicoContacto"]').text('Correo inválido');
            else
                $('span[data-valmsg-for="' + metodo + '_CorreoElectronicoContacto"]').text('');
        });
    },
    //tabla: {
    //    inicializa: function () {
    //        $('#dgDatosEmpresaContacto').bootstrapTable({
    //            pagination: true,
    //            search:     false,
    //            columns: [
    //                {
    //                    field: 'EmpresaContactoId',
    //                    title: 'Folio',
    //                    sortable: true,
    //                    align: 'center'
    //                },
    //                {
    //                    field: 'ContactoId',
    //                    title: 'ContactoId',
    //                    sortable: true,
    //                    align: 'center',
    //                    visible: false
    //                },
    //                {
    //                    field: 'ContactoDescripcion',
    //                    title: 'Contacto',
    //                    sortable: true,
    //                    align: 'left'
    //                },
    //                {
    //                    field: 'EstatusId',
    //                    title: 'Activo',
    //                    sortable: false,
    //                    formatter: 'EstatusIdFormatter',
    //                    align: 'center'
    //                },
    //                {
    //                    field: '',
    //                    title: 'Acción',
    //                    sortable: true,
    //                    formatter: this.accion(),
    //                    events: 'EmpresaContacto_ActionEvents',
    //                    align: 'center'
    //                }
    //            ]
    //        });
    //    },
    //    datos:      function () {
    //        var objJSON = {
    //            pEmpresaId: $('#txtEmpresaId').val().trim(),
    //            pContactoId: -1,
    //            pEstatusId: ESTATUS_ENTIDAD.ACTIVO,
    //        };

    //        var json = JSON.stringify(objJSON, null, 2);

    //        var res = getJSON(
    //            URL.EmpresaContacto + 'EmpresaContactoGridJson',
    //            json
    //        );

    //        $('#dgDatosEmpresaContacto').bootstrapTable("load", res.data.Datos);
    //    },
    //    accion:     function (value, row, index) {
    //        return [
    //            '<a class="removeEmpresaContacto" href="javascript:void(0)" title="Eliminar">',
    //            '<i class="text-danger fa fa-close fa-2x"></i>',
    //            '</a>'
    //        ].join('');
    //    }
    //},
    validaGuardar: function (metodo) {
        if ($('#txt_' + metodo + '_NombreContacto').val().trim() == "") {
            $('span[data-valmsg-for="' + metodo + '_NombreContacto"]').text('Campo Requerido');
            $('#txt_' + metodo + '_NombreContacto').focus();

            return false;
        };

        if ($('#txt_' + metodo + '_PaternoContacto').val().trim() == "") {
            $('span[data-valmsg-for="' + metodo + '_PaternoContacto"]').text('Campo Requerido');
            $('#txt_' + metodo + '_PaternoContacto').focus();

            return false;
        };

        if ($('#txt_' + metodo + '_MaternoContacto').val().trim() == "") {
            $('span[data-valmsg-for="' + metodo + '_MaternoContacto"]').text('Campo Requerido');
            $('#txt_' + metodo + '_MaternoContacto').focus();

            return false;
        };

        if ($('#txt_' + metodo + '_DepartametoContacto').val().trim() == "") {
            $('span[data-valmsg-for="' + metodo + '_DepartametoContacto"]').text('Campo Requerido');
            $('#txt_' + metodo + '_DepartametoContacto').focus();

            return false;
        };

        if ($('#ddl_' + metodo + '_ContactoTipoId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="' + metodo + '_ContactoTipoId"]').text('Campo Requerido');
            $('#ddl_' + metodo + '_ContactoTipoId').focus();

            return false;
        };

        if ($('#txt_' + metodo + '_TelefonoContacto').val().trim() == "") {
            $('span[data-valmsg-for="' + metodo + '_TelefonoContacto"]').text('Campo Requerido');
            $('#txt_' + metodo + '_TelefonoContacto').focus();

            return false;
        };

        if ($('#ddl_' + metodo + '_ContactoTipoId  option:selected').text() == "Oficina") {
            if ($('#txt_' + metodo + '_ExtensionContacto').val().trim() == "") {
                $('span[data-valmsg-for="' + metodo + '_ExtensionContacto"]').text('Campo Requerido');
                $('#txt_' + metodo + '_ExtensionContacto').focus();

                return false;
            };
        };

        if ($('#txt_' + metodo + '_CorreoElectronicoContacto').val().trim() == "") {
            $('span[data-valmsg-for="' + metodo + '_CorreoElectronicoContacto"]').text('Campo Requerido');
            $('#txt_' + metodo + '_CorreoElectronicoContacto').focus();

            return false;
        };

        var validarEmail = /^\w+([.-_+]?\w+)*@\w+([.-]?\w+)*(\.\w{2,10})+$/;

        if (!validarEmail.test($('#txt_' + metodo + '_CorreoElectronicoContacto').val().trim())) {
            $('span[data-valmsg-for="' + metodo + '_CorreoElectronicoContacto"]').text('Correo inválido');
            $('#txt_' + metodo + '_CorreoElectronicoContacto').focus();

            return false;
        };

        return true;
    },
    redirecciona: function (metodo) {
        if (metodo == 'EMPRESA_INDEX') {
            $(location).attr('href', URL.Empresa);
        };

        if (metodo == 'EMPRESA_CONTACTO_INDEX') {
            $(location).attr('href', URL.EmpresaContacto + '?pEmpresaId=' + $('#txtEmpresaId').val() + '&pEmpresaDescripcion=' + $('#txtEmpresaDescripcion').val());
        };

        if (metodo == 'EMPRESA_CONTACTO_CONTACTO') {
            CtrlUserBusquedaEmpresaContactoView.inicializa('CTRL_USER_BUSQUEDA_EMPRESA_CONTACTO_VIEW');
        }
    },
    limpiarCtrls: function (metodo) {
        $('#txt_' + metodo + '_NombreContacto').val(''),
        $('#txt_' + metodo + '_PaternoContacto').val('');
        $('#txt_' + metodo + '_MaternoContacto').val('');
        $('#txt_' + metodo + '_DepartametoContacto').val('');
        $('#ddl_' + metodo + '_ContactoTipoId').val(0);
        $('#txt_' + metodo + '_TelefonoContacto').val('');
        $('#txt_' + metodo + '_ExtensionContacto').val('');
        $('#txt_' + metodo + '_CorreoElectronicoContacto').val('');
    },
};