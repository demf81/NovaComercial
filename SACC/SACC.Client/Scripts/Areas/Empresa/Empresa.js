$(function () {
    Empresa.inicializa($("#txtApuntadorEmpresa").val());
});




var Empresa = {
    evento:                      null,
    inicializa:                  function (evento) {
        this.evento = evento;

        if (this.evento == 'EMPRESA_INDEX') {
            this.keyEventIndex();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'EMPRESA_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            $("#txtDiaPago").TouchSpin({
                min:            1,
                max:            31,
                step:           1,
                decimals:       0,
                boostat:        5,
                maxboostedstep: 10,
            });

            InicializarDtpClass('.input-group.date');
            $('.input-group.date').datepicker('update', new Date());

            Pais.llenaCombo('ddlPaisId',                     'SELECCIONE');
            Estado.llenaCombo('ddlEstadoId',                 'SELECCIONE', $("#ddlPaisId").val());
            Municipio.llenaCombo('ddlMunicipioId',           'SELECCIONE', $("#ddlPaisId").val(), $("#ddlEstadoId").val());

            EmpresaTipo.llenaCombo('ddlEmpresaTipoId',       'SELECCIONE');
            FormaPago.llenaCombo('ddlMetodoPagoId',          'SELECCIONE');
            FrecuenciaPago.llenaCombo('ddlFormaPagoId',      'SELECCIONE');
            MetodoPago.llenaCombo('ddlFrecuenciaPagoId',     'SELECCIONE');
            EmpresaPlanta.llenaCombo('ddlEmpresaVigenciaId', 'SELECCIONE');
        };

        if (this.evento == 'EMPRESA_EDIT') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            $("#txtDiaPago").TouchSpin({
                min:            1,
                max:            31,
                step:           1,
                decimals:       0,
                boostat:        5,
                maxboostedstep: 10,
            });

            InicializarDtpClass('.input-group.date');
            $('.input-group.date').datepicker('update', new Date());

            Pais.llenaCombo('ddlPaisId',                     'SELECCIONE');
            Estado.llenaCombo('ddlEstadoId',                 'SELECCIONE', $("#ddlPaisId").val());
            Municipio.llenaCombo('ddlMunicipioId',           'SELECCIONE', $("#ddlPaisId").val(), $("#ddlEstadoId").val());

            EmpresaTipo.llenaCombo('ddlEmpresaTipoId',       'SELECCIONE');
            FormaPago.llenaCombo('ddlMetodoPagoId',          'SELECCIONE');
            FrecuenciaPago.llenaCombo('ddlFormaPagoId',      'SELECCIONE');
            MetodoPago.llenaCombo('ddlFrecuenciaPagoId',     'SELECCIONE');
            EmpresaPlanta.llenaCombo('ddlEmpresaVigenciaId', 'SELECCIONE');

            this.cargaDatos();
            EmpresaDatosFiscales.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);

            CtrlUserBusquedaEmpresaContactoView.inicializa('CTRL_USER_BUSQUEDA_EMPRESA_CONTACTO_VIEW');
        };

        if (this.evento == 'EMPRESA_DELETE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            $("#txtDiaPago").TouchSpin({
                min:            1,
                max:            31,
                step:           1,
                decimals:       0,
                boostat:        5,
                maxboostedstep: 10,
            });

            Pais.llenaCombo('ddlPaisId',                     'SELECCIONE');
            Estado.llenaCombo('ddlEstadoId',                 'SELECCIONE', $("#ddlPaisId").val());
            Municipio.llenaCombo('ddlMunicipioId',           'SELECCIONE', $("#ddlPaisId").val(), $("#ddlEstadoId").val());

            EmpresaTipo.llenaCombo('ddlEmpresaTipoId',       'SELECCIONE');
            FormaPago.llenaCombo('ddlMetodoPagoId',          'SELECCIONE');
            FrecuenciaPago.llenaCombo('ddlFormaPagoId',      'SELECCIONE');
            MetodoPago.llenaCombo('ddlFrecuenciaPagoId',     'SELECCIONE');
            EmpresaPlanta.llenaCombo('ddlEmpresaVigenciaId', 'SELECCIONE');

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:                  function () {
        var objJSON = {
            pEmpresaId: $('#txtEmpresaId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Empresa + 'EmpresaElementoJson',
            json
        );

        if (res != null) {
            $("#txtEmpresaDescripcion").val(res.data.Datos[0].EmpresaDescripcion);
            $("#txtCodigo").val(res.data.Datos[0].Codigo);

            $("#ddlEmpresaTipoId").val(res.data.Datos[0].EmpresaTipoId);
            $("#ddlMetodoPagoId").val(res.data.Datos[0].MetodoPagoId);
            $("#ddlFormaPagoId").val(res.data.Datos[0].FormaPagoId);
            $("#ddlFrecuenciaPagoId").val(res.data.Datos[0].FrecuenciaPagoId);

            $("#txtDiaPago").val(res.data.Datos[0].DiaPago);
            //$("txtDiaPago").trigger("touchspin.updatesettings", { max: res.data.Datos[0].DiaPago });

            $("#dtpInicioOperaciones").val(formatFecha(res.data.Datos[0].InicioOperaciones));
            $("#ddlEmpresaVigenciaId").val(res.data.Datos[0].EmpresaVigenciaId);

            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar:                     function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            EmpresaId:          0,
            EmpresaDescripcion: $("#txtEmpresaDescripcion").val().trim(),
            Codigo:             $("#txtCodigo").val().trim(),
            EmpresaTipoId:      $("#ddlEmpresaTipoId").val(),
            MetodoPagoId:       $("#ddlMetodoPagoId").val(),
            FormaPagoId:        $("#ddlFormaPagoId").val(),
            FrecuenciaPagoId:   $("#ddlFrecuenciaPagoId").val(),
            DiaPago:            $("#txtDiaPago").val(),
            EmpresaVigenciaId: $("#ddlEmpresaVigenciaId").val(),
            InicioOperaciones: $("#dtpInicioOperaciones").val().trim()
        };

        var objJSON = {
            model:   _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Empresa + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Empresa.redirecciona('EMPRESA_INDEX'); }, 2000);
                else
                    this.redirecciona('EMPRESA_INDEX');
    },
    actualizar:                  function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            EmpresaId:          $("#txtEmpresaId").val(),
            EmpresaDescripcion: $("#txtEmpresaDescripcion").val(),
            Codigo:             $("#txtCodigo").val().trim(),
            EmpresaTipoId:      $("#ddlEmpresaTipoId").val(),
            MetodoPagoId:       $("#ddlMetodoPagoId").val(),
            FormaPagoId:        $("#ddlFormaPagoId").val(),
            FrecuenciaPagoId:   $("#ddlFrecuenciaPagoId").val(),
            DiaPago:            $("#txtDiaPago").val(),
            EmpresaVigenciaId:  $("#ddlEmpresaVigenciaId").val(),
            InicioOperaciones:  $("#dtpInicioOperaciones").val(),
            EstatusId:          ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var _objDF = {
            EmpresaDatosFiscalesId: $("#txtEmpresaDatosFiscalesId").val(),
            EmpresaId:              $("#txtEmpresaId").val(),
            RazonSocial:            $("#txtRazonSocial").val(),
            RFC:                    $("#txtRFC").val().trim(),
            PaisId:                 $("#ddlPaisId").val(),
            EstadoId:               $("#ddlEstadoId").val(),
            MunicipioId:            $("#ddlMunicipioId").val(),
            Colonia:                $("#txtColonia").val().trim(),
            Calle:                  $("#txtCalle").val().trim(),
            NumeroExterior:         $("#txtNumeroExterior").val(),
            NumeroInterior:         $("#txtNumeroInterior").val(),
            CodigoPostal:           $("#txtCodigoPostal").val(),
        };

        var objJSON = {
            model:   _obj,
            modelDF: _objDF
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Empresa + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Empresa.redirecciona('EMPRESA_INDEX'); }, 2000);
                else
                    this.redirecciona('EMPRESA_INDEX');
    },
    //cambioEstatus: function () {

    //},
    baja:                        function () {
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
                        EmpresaId: $("#txtEmpresaId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Empresa + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Empresa.redirecciona('EMPRESA_INDEX'); }, 2000);
                            else
                                this.redirecciona('EMPRESA_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent:                    function () {
        $("#txtEmpresaDescripcion").on("change paste keyup", function () {
            if ($("#txtEmpresaDescripcion").val().trim() == "")
                $('span[data-valmsg-for="EmpresaDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="EmpresaDescripcion"]').text('');
        });

        $("#txtCodigo").on("change paste keyup", function () {
            if ($("#txtCodigo").val().trim() == "")
                $('span[data-valmsg-for="Codigo"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Codigo"]').text('');
        });

        $("#txtRazonSocial").on("change paste keyup", function () {
            if ($("#txtRazonSocial").val().trim() == "")
                $('span[data-valmsg-for="RazonSocial"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="RazonSocial"]').text('');
        });

        $("#txtRFC").on("change paste keyup", function () {
            if ($("#txtRFC").val().trim() == "")
                $('span[data-valmsg-for="RFC"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="RFC"]').text('');
        });

        $('#ddlPaisId').change(function () {
            if ($('#ddlPaisId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="PaisId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="PaisId"]').text('');
            };

            Estado.llenaCombo('ddlEstadoId', 'SELECCIONE', $("#ddlPaisId").val());
            Municipio.llenaCombo('ddlMunicipioId', 'SELECCIONE', $("#ddlPaisId").val(), $("#ddlEstadoId").val());
        });

        $('#ddlEstadoId').change(function () {
            if ($('#ddlEsatdoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="EstadoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="EstadoId"]').text('');
            };

            Municipio.llenaCombo('ddlMunicipioId', 'SELECCIONE', $("#ddlPaisId").val(), $("#ddlEstadoId").val());
        });

        $('#ddlMunicipioId').change(function () {
            if ($('#ddlMunicipioId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="MunicipioId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="MunicipioId"]').text('');
            };
        });

        $("#txtColonia").on("change paste keyup", function () {
            if ($("#txtColonia").val().trim() == "")
                $('span[data-valmsg-for="Colonia"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Colonia"]').text('');
        });

        $("#txtCalle").on("change paste keyup", function () {
            if ($("#txtCalle").val().trim() == "")
                $('span[data-valmsg-for="txtCalle"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="txtCalle"]').text('');
        });

        $("#txtNumeroExterior").on("change paste keyup", function () {
            if ($("#txtNumeroExterior").val().trim() == "")
                $('span[data-valmsg-for="NumeroExterior"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="NumeroExterior"]').text('');
        });

        $("#txtCodigoPostal").on("change paste keyup", function () {
            if ($("#txtCodigoPostal").val().trim() == "")
                $('span[data-valmsg-for="CodigoPostal"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CodigoPostal"]').text('');
        });

        $('#ddlEmpresaTipoId').change(function () {
            if ($('#ddlEmpresaTipoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="EmpresaTipoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="EmpresaTipoId"]').text('');
            };
        });

        $("#dtpFechaInicioOperaciones").on("change paste keyup", function () {
            if ($("#dtpFechaInicioOperaciones").val().trim() == "")
                $('span[data-valmsg-for="InicioOperaciones"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="InicioOperaciones"]').text('');
        });

        $('#ddlEmpresaVigenciaId').change(function () {
            if ($('#ddlEmpresaVigenciaId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="EmpresaVigenciaId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="EmpresaVigenciaId"]').text('');
            };
        });
    },
    keyEventIndex:               function () {
        $('#dgDatosEmpresa').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosEmpresa tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    llenaCombo:                  function (pCtrlName, pOpcion) {
        var res = getJSON(
            URL.Empresa + "EmpresaComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosEmpresa').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'EmpresaId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'EmpresaDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'RFC',
                        title:     'RFC',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Poblacion',
                        title:     'Población',
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
                        events:    'Empresa_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pEmpresaDescripcion: $('#txtEmpresaDescripcion').val().trim(),
                pEstatusId:          $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Empresa + 'EmpresaGridJson',
                json
            );

            $('#dgDatosEmpresa').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<div class="btn-group">',
                    '<button data-toggle="dropdown" class="btn btn-default btn-sm dropdown-toggle" aria-expanded="false">',
                        '<span><i class="fa fa-ellipsis-h"></i></span>',
                    '</button>',
                    '<ul class="dropdown-menu pull-right">',
                        '<li>',
                            '<a class="editEmpresa" href="javascript:void(0)">',
                                '<i class="text-success fa fa-pencil fa-2x"></i>&nbsp;&nbsp; Editar',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="empresaContrato" href="javascript:void(0)">',
                                '<i class="text-warning fa fa-cog fa-2x"></i>&nbsp;&nbsp; Contratos',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="empresaContratoCobertura" href="javascript:void(0)">',
                                '<i class="text-primary fa fa-list-alt fa-2x"></i>&nbsp;&nbsp; Contratos y Coberturas',
                            '<a>',
                        '</li>',

                        '<li>',
                            '<a class="empresaDocumentos" href="javascript:void(0)">',
                                '<i class="text-primary2 fa fa-folder-open fa-2x"></i>&nbsp;&nbsp;  Documentos',
                            '</a>',
                        '</li>',

                        '<li>',
                            '<a class="empresaInformacion" href="javascript:void(0)">',
                                '<i class="text-info fa fa-info-circle fa-2x"></i>&nbsp;&nbsp; Informacion',
                            '</a>',
                        '</li>',

                        '<li>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="removeEmpresa" href="javascript:void(0)">',
                                '<i class="text-danger fa fa-trash fa-2x"></i>&nbsp;&nbsp; Eliminar',
                            '</a>',
                        '</li>',
                    '</ul >',
                '</div>'


                //'<a class="editEmpresa" href="javascript:void(0)" title="Editar">',
                //    '<i class="text-success fa fa-pencil fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="empresaContrato" href="javascript:void(0)" title="Contratos">',
                //    '<i class="text-warning fa fa-cog fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="empresaContratoCobertura" href="javascript:void(0)" title="Contratos y Coberturas">',
                //    '<i class="text-primary fa fa-list-alt fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="empresaDocumentos" href="javascript:void(0)" title="Documentos">',
                //    '<i class="text-primary2 fa fa-folder-open fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="empresaInformacion" href="javascript:void(0)" title="Informacion">',
                //    '<i class="text-info fa fa-info-circle fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="removeEmpresa" href="javascript:void(0)" title="Eliminar">',
                //'<i class="text-danger fa fa-trash fa-2x"></i>',
                //'</a>'
            ].join('');
        }
    },
    buscar:                      function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda:              function () {
        if ($("#txtEmpresaDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="EmpresaDescripcion"]').text('Campo Requerido');
            $("#txtEmpresaDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:               function () {
        if ($("#txtEmpresaDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="EmpresaDescripcion"]').text('Campo Requerido');
            $("#txtEmpresaDescripcion").focus();

            $('#rootwizard').find("a[href*='tab1']").trigger('click');

            return false;
        };

        if ($("#txtCodigo").val().trim() == "") {
            $('span[data-valmsg-for="Codigo"]').text('Campo Requerido');
            $("#txtCodigo").focus();

            $('#rootwizard').find("a[href*='tab1']").trigger('click');

            return false;
        };


        if ($("#txtRazonSocial").val().trim() == "") {
            $('span[data-valmsg-for="RazonSocial"]').text('Campo Requerido');
            $("#txtRazonSocial").focus();

            $('#rootwizard').find("a[href*='tab2']").trigger('click');

            return false;
        };

        if ($("#txtRFC").val().trim() == "") {
            $('span[data-valmsg-for="RFC"]').text('Campo Requerido');
            $("#txtRFC").focus();

            $('#rootwizard').find("a[href*='tab2']").trigger('click');

            return false;
        };

        if ($("#txtRFC").val().trim().split("").length < 12) {
            $('span[data-valmsg-for="RFC"]').text('RFC inválido');
            $("#txtRFC").focus();

            return false;
        };

        if ($('#ddlPaisId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="PaisId"]').text('Campo Requerido');
            $("#ddlPaisId").focus();

            return false;
        };

        if ($('#ddlEstadoId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="EstadoId"]').text('Campo Requerido');
            $("#ddlEstadoId").focus();

            valido = false;
        };

        if ($('#ddlMunicipioId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="MunicipioId"]').text('Campo Requerido');
            $("#ddlMunicipioId").focus();

            return false;
        };

        if ($("#txtColonia").val().trim() == "") {
            $('span[data-valmsg-for="Colonia"]').text('Campo Requerido');
            $("#txtColonia").focus();

            return false;
        };

        if ($("#txtCalle").val().trim() == "") {
            $('span[data-valmsg-for="Calle"]').text('Campo Requerido');
            $("#txtCalle").focus();

            return false;
        };

        if ($("#txtNumeroExterior").val().trim() == "") {
            $('span[data-valmsg-for="NumeroExterior"]').text('Campo Requerido');
            $("#txtNumeroExterior").focus();

            return false;
        };

        if ($("#txtCodigoPostal").val().trim() == "") {
            $('span[data-valmsg-for="CodigoPostal"]').text('Campo Requerido');
            $("#txtCodigoPostal").focus();

            return false;
        }


        if ($('#ddlEmpresaTipoId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="EmpresaTipoId"]').text('Campo Requerido');
            $("#ddlEmpresaTipoId").focus();

            return false;
        };

        if ($("#dtpInicioOperaciones").val().trim() == "") {
            $('span[data-valmsg-for="InicioOperaciones"]').text('Campo Requerido');
            $("#dtpInicioOperaciones").focus();

            return false;
        };

        if ($('#ddlEmpresaVigenciaId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="EmpresaVigenciaId"]').text('Campo Requerido');
            $("#ddlEmpresaVigenciaId").focus();

            return false;
        };
        return true;
    },
    limpiar:                     function () {
        this.inicializa('EMPRESA_INDEX');
    },
    redirecciona:                function (metodo) {
        if (metodo == 'EMPRESA_INDEX') {
            $(location).attr('href', URL.Empresa);
        };

        if (metodo == 'EMPRESA_CREATE') {
            $(location).attr('href', URL.Empresa + 'Create');
        };
    },
    switchEmpresa:               function (pId, pDescripcion) {
        swal({
            title: "¿Que desea hacer?",
            text: "¡Ir a la pantalla principal, configuar un congtrato o agregar una nueva empresa.?",
            icon: "info",
            //buttons: true,
            buttons: {
                btnPrincilap: {
                    text: "Principal",
                    value: "principal",
                    color: "warning"
                },
                btnConfigurar: {
                    text: "Configurar",
                    value: "configurar",
                },
                btnAgregar: {
                    text: "Agregar",
                    value: "agregar",
                }
            },
            dangerMode: true,
        })
        .then((value) => {
            switch (value) {

                case "principal":
                    Empresa.redirecciona('EMPRESA_INDEX');
                    break;

                case "configurar":
                    $(location).attr('href', URL.EmpresaContrato + 'Index?pEmpresaId=' + pId + '&pEmpresaDescripcion=' + pDescripcion);
                    break;

                case "agregar":
                    Empresa.redirecciona('EMPRESA_CREATE');
                    break;
            }
        });
    },
    limpiarCtrls:                function () {
        $('#txtEmpresaDescripcion').val('');

        $('span[data-valmsg-for="EmpresaDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls:    function (isDisabled) {
        DisabledEneableElement('txtEmpresaDescripcion', isDisabled);
        DisabledEneableElement('txtCodigo',             isDisabled);
        DisabledEneableElement('txtRazonSocial',        isDisabled);
        DisabledEneableElement('txtRFC',                isDisabled);
        DisabledEneableElement('ddlPaisId',             isDisabled);
        DisabledEneableElement('ddlEstadoId',           isDisabled);
        DisabledEneableElement('ddlMunicipioId',        isDisabled);
        DisabledEneableElement('txtColonia',            isDisabled);
        DisabledEneableElement('txtCalle',              isDisabled);
        DisabledEneableElement('txtNumeroExterior',     isDisabled);
        DisabledEneableElement('txtNumeroInterior',     isDisabled);
        DisabledEneableElement('txtCodigoPostal',       isDisabled);
        DisabledEneableElement('ddlEmpresaTipoId',      isDisabled);
        DisabledEneableElement('ddlMetodoPagoId',       isDisabled);
        DisabledEneableElement('ddlFormaPagoId',        isDisabled);
        DisabledEneableElement('ddlFrecuenciaPagoId',   isDisabled);
        DisabledEneableElement('txtDiaPago',            isDisabled);
        DisabledEneableElement('dtpInicioOperaciones',  isDisabled);
        DisabledEneableElement('ddlEmpresaVigenciaId',  isDisabled);
    },
    AbreModalContacto: function (metodo) {
        if (metodo == 'AGREGAR') {
            $("#myModalCreateContacto").modal();

            EmpresaContacto.inicializa('EMPRESA_CONTACTO_CREATE');
        };

        if (metodo == 'EDITAR') {
            $("#myModalEditContacto").modal();

            EmpresaContacto.inicializa('EMPRESA_CONTACTO_EDIT');
        };
    },
    AbreModalCoberturaCondicion: function (pEmpresaId) {
        CtrlUserEmpresaCoberturaCondicion.inicializa('CTRL_USER_EMPRESA_COBERTURA_CONDICION', pEmpresaId);

        $("#myModalEmpresaCoberturaCondicion").modal();
    }
};




window.Empresa_ActionEvents = {
    'click .editEmpresa':              function (e, value, row, index) {
        $(location).attr('href', URL.Empresa + 'Edit?pEmpresaId=' + row.EmpresaId);
    },
    'click .empresaContrato':          function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.EmpresaContrato + 'Index?pEmpresaId=' + row.EmpresaId + '&pEmpresaDescripcion=' + row.EmpresaDescripcion);
    },
    'click .empresaContratoCobertura': function (e, value, row, index) {
        Empresa.AbreModalCoberturaCondicion(row.EmpresaId);
    },
    'click .empresaDocumentos':        function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.EmpresaDocumento + 'Index?pEmpresaId=' + row.EmpresaId + '&' + 'pEmpresaDescripcion=' + row.EmpresaDescripcion);
    },
    'click .removeEmpresa':            function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Empresa + 'Delete?pEmpresaId=' + row.EmpresaId);
    }
};