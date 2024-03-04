var _listDetalle              = [];
var _listProcedimientoDetalle = { Datos: [] };
var _SubTotal                 = 0;
var _Descuento                = 0;
var _Iva                      = 0;
var _Total                    = 0;




$(function () {
    Cotizacion.inicializa($("#txtApuntadorCotizacion").val());
});




var Cotizacion = {
    evento:                       null,
    inicializa:                   function (evento) {
        this.evento = evento;

        if (this.evento == 'COTIZACION_INDEX') {
            this.keyEventIndex();
            this.limpiarCtrls();

            InicializarDtp('dtpFechaInicial');
            InicializarDtp('dtpFechaFinal');
            
            $("#datepicker").on("changeDate", function (event) {
                $("#my_hidden_input").val(
                    $("#datepicker").datepicker('getFormattedDate')
                )
            });
			
            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'COTIZACION_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified',
                onTabClick: function (tan, nabigation, index) {
                    return false;
                },
                onNext: function (tab, navigation, index) {
                    if (index == 1) {
                        if ($("#txtCotizacionDescripcion").val().trim() == "") {
                            $('span[data-valmsg-for="CotizacionDescripcion"]').text('Campo Requerido');
                            $("#txtCotizacionDescripcion").focus();

                            return false;
                        }

                        if ($("#dtpFecha").val().trim() == "") {
                            $('span[data-valmsg-for="Fecha"]').text('Campo Requerido');
                            $("#dtpFecha").focus();

                            return false;
                        }

                        var _opcionSeleccionada = $('#rbCotizacionTipoId:checked').val();
                        if (_opcionSeleccionada == 1) {
                            if ($("#txtNombre").val().trim() == "") {
                                $('span[data-valmsg-for="Nombre"]').text('Campo Requerido');
                                $("#txtNombre").focus();

                                return false;
                            }

                            if ($("#txtTelefono").val().trim() == "") {
                                $('span[data-valmsg-for="Telefono"]').text('Campo Requerido');
                                $("#txtTelefono").focus();

                                return false;
                            }

                            if ($("#txtCorreoElectronico").val().trim() == "") {
                                $('span[data-valmsg-for="CorreoElectronico"]').text('Campo Requerido');
                                $("#txtCorreoElectronico").focus();

                                return false;
                            }
                            else {
                                if (!ValidaEmail($("#txtCorreoElectronico").val().trim())) {
                                    $('span[data-valmsg-for="CorreoElectronico"]').text('Formato Inválido');

                                    return false;
                                }
                            }
                        };

                        if (_opcionSeleccionada == 2) {
                            if ($("#txtNombrePersona").val().trim() == "") {
                                $('span[data-valmsg-for="NombrePersona"]').text('Campo Requerido');
                                $("#txtNombrePersona").focus();

                                return false;
                            }
                        };

                        if (_opcionSeleccionada == 3) {
                            if ($("#txtEmpresa").val().trim() == "") {
                                $('span[data-valmsg-for="Empresa"]').text('Campo Requerido');
                                $("#txtEmpresa").focus();

                                return false;
                            }

                            if ($("#txtContacto").val().trim() == "") {
                                $('span[data-valmsg-for="Contacto"]').text('Campo Requerido');
                                $("#txtContacto").focus();

                                return false;
                            }

                            if ($("#txtTelefono").val().trim() == "") {
                                $('span[data-valmsg-for="Telefono"]').text('Campo Requerido');
                                $("#txtTelefono").focus();

                                return false;
                            }

                            if ($("#txtCorreoElectronico").val().trim() == "") {
                                $('span[data-valmsg-for="CorreoElectronico"]').text('Campo Requerido');
                                $("#txtCorreoElectronico").focus();

                                return false;
                            }
                            else {
                                if (!ValidaEmail($("#txtCorreoElectronico").val().trim())) {
                                    $('span[data-valmsg-for="CorreoElectronico"]').text('Formato Inválido');

                                    return false;
                                }
                            }
                        };

                        if (_opcionSeleccionada == 4) {
                            if ($("#txtNombreEmpresa").val().trim() == "") {
                                $('span[data-valmsg-for="NombreEmpresa"]').text('Campo Requerido');
                                $("#EmpresaId").focus();

                                return false;
                            }
                        };
                    }
                    
                    if (index == 2) {
                        var _data = $('#dgDatosCotizacionDetalle').bootstrapTable('getData');
                        if (_data.length == 0) {
                            $('span[data-valmsg-for="DatosCotizacionDetalle"]').text('Debe seleccionar los artículos a cotizar');

                            return false;
                        }
                    }
                }
            });

            InicializarDtpClass('.input-group.date');
            $('.input-group.date').datepicker('update', new Date());

            this.tablaDetalle.inicializa();

            $("input[name=rbCotizacionTipoId][value=1]").prop('checked', true).iCheck('update');
            $("input[name=rbCotizacionTipoId][value=2]").prop('checked', false).iCheck('update');
        };

        if (this.evento == 'COTIZACION_EDIT') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified',
                onTabClick: function (tan, nabigation, index) {
                    return false;
                },
                onNext: function (tab, navigation, index) {
                    if (index == 1) {
                        if ($("#txtCotizacionDescripcion").val().trim() == "") {
                            $('span[data-valmsg-for="CotizacionDescripcion"]').text('Campo Requerido');
                            $("#txtCotizacionDescripcion").focus();

                            return false;
                        }

                        if ($("#dtpFecha").val().trim() == "") {
                            $('span[data-valmsg-for="Fecha"]').text('Campo Requerido');
                            $("#dtpFecha").focus();

                            return false;
                        }

                        var _opcionSeleccionada = $('#rbCotizacionTipoId:checked').val();
                        if (_opcionSeleccionada == 1) {
                            if ($("#txtNombre").val().trim() == "") {
                                $('span[data-valmsg-for="Nombre"]').text('Campo Requerido');
                                $("#txtNombre").focus();

                                return false;
                            }

                            if ($("#txtTelefono").val().trim() == "") {
                                $('span[data-valmsg-for="Telefono"]').text('Campo Requerido');
                                $("#txtTelefono").focus();

                                return false;
                            }

                            if ($("#txtCorreoElectronico").val().trim() == "") {
                                $('span[data-valmsg-for="CorreoElectronico"]').text('Campo Requerido');
                                $("#txtCorreoElectronico").focus();

                                return false;
                            }
                        };

                        if (_opcionSeleccionada == 2) {
                            if ($("#txtNombrePersona").val().trim() == "") {
                                $('span[data-valmsg-for="NombrePersona"]').text('Campo Requerido');
                                $("#txtNombrePersona").focus();

                                return false;
                            }
                        };

                        if (_opcionSeleccionada == 3) {
                            if ($("#txtEmpresa").val().trim() == "") {
                                $('span[data-valmsg-for="Empresa"]').text('Campo Requerido');
                                $("#txtEmpresa").focus();

                                return false;
                            }

                            if ($("#txtContacto").val().trim() == "") {
                                $('span[data-valmsg-for="Contacto"]').text('Campo Requerido');
                                $("#txtContacto").focus();

                                return false;
                            }

                            if ($("#txtTelefono").val().trim() == "") {
                                $('span[data-valmsg-for="Telefono"]').text('Campo Requerido');
                                $("#txtTelefono").focus();

                                return false;
                            }

                            if ($("#txtCorreoElectronico").val().trim() == "") {
                                $('span[data-valmsg-for="CorreoElectronico"]').text('Campo Requerido');
                                $("#txtCorreoElectronico").focus();

                                return false;
                            }
                        };

                        if (_opcionSeleccionada == 4) {
                            if ($("#txtNombreEmpresa").val().trim() == "") {
                                $('span[data-valmsg-for="NombreEmpresa"]').text('Campo Requerido');
                                $("#EmpresaId").focus();

                                return false;
                            }
                        };
                    }

                    if (index == 2) {
                        var _data = $('#dgDatosCotizacionDetalle').bootstrapTable('getData');
                        if (_data.length == 0) {
                            $('span[data-valmsg-for="DatosCotizacionDetalle"]').text('Debe seleccionar los artículos a cotizar');

                            return false;
                        }
                    }
                }
            });

            InicializarDtpClass('.input-group.date');

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'COTIZACION_DELETE') {
            this.cargaDatos();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified',
                onTabClick: function (tan, nabigation, index) {
                },
                onNext: function (tab, navigation, index) {
                }
            });

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:                   function () {
        var objJSON = {
            pCotizacionId:          $('#txtCotizacionId').val(),
            pCotizacionDescripcion: '',
            pEstatusId:             -1
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Cotizacion + 'CotizacionElementoJson',
            json
        );

        if (res != null) {
            $("#txtCotizacionDescripcion").val(res.data.Datos[0].CotizacionDescripcion);
            $("#dtpFecha").val(formatFecha(res.data.Datos[0].Fecha));

            if (res.data.Datos[0].CotizacionTipoId == 1) {
                $("input[name=rbCotizacionTipoId][value=1]").prop('checked', true).iCheck('update');

                $("#divNombre").removeClass("hide");
                $("#divTelefono").removeClass("hide");
                $("#divCorreoElectronico").removeClass("hide");

                $("#divAfiliado").addClass("hide");
                $("#divEmpresa").addClass("hide");
                $("#divContacto").addClass("hide");
                $("#divConvenio").addClass("hide");

                $("#txtNombre").val(res.data.Datos[0].PersonaNombre);
                $("#txtTelefono").val(res.data.Datos[0].Telefono);
                $("#txtCorreoElectronico").val(res.data.Datos[0].CorreoElectronico);
            };

            if (res.data.Datos[0].CotizacionTipoId == 2) {
                $("input[name=rbCotizacionTipoId][value=2]").prop('checked', true).iCheck('update');

                $("#divAfiliado").removeClass("hide");
                
                $("#divNombre").addClass("hide");
                $("#divTelefono").addClass("hide");
                $("#divCorreoElectronico").addClass("hide");
                $("#divEmpresa").addClass("hide");
                $("#divContacto").addClass("hide");
                $("#divConvenio").addClass("hide");

                $("#txtPersonaId").val(res.data.Datos[0].PersonaId);
                $("#txtNombrePersona").val(res.data.Datos[0].PersonaNombre);
            };

            if (res.data.Datos[0].CotizacionTipoId == 3) {
                $("input[name=rbCotizacionTipoId][value=3]").prop('checked', true).iCheck('update');

                $("#divEmpresa").removeClass("hide");
                $("#divContacto").removeClass("hide");
                $("#divTelefono").removeClass("hide");
                $("#divCorreoElectronico").removeClass("hide");
                
                $("#divNombre").addClass("hide");
                $("#divAfiliado").addClass("hide");
                $("#divConvenio").addClass("hide");

                $("#txtEmpresa").val(res.data.Datos[0].EmpresaNombre);
                $("#txtContacto").val(res.data.Datos[0].Contacto);
                $("#txtTelefono").val(res.data.Datos[0].Telefono);
                $("#txtCorreoElectronico").val(res.data.Datos[0].CorreoElectronico);
            };

            if (res.data.Datos[0].CotizacionTipoId == 4) {
                $("input[name=rbCotizacionTipoId][value=4]").prop('checked', true).iCheck('update');

                $("#divConvenio").removeClass("hide");
                
                $("#divNombre").addClass("hide");
                $("#divTelefono").addClass("hide");
                $("#divCorreoElectronico").addClass("hide");
                $("#divAfiliado").addClass("hide");
                $("#divEmpresa").addClass("hide");
                $("#divContacto").addClass("hide");

                $("#txtEmprsaId").val(res.data.Datos[0].EmpresaId);
                $("#txtEmpresaPersona").val(res.data.Datos[0].EmpresaNombre);
            };

            $("#txtTotalCotizado").val(priceFormatter(res.data.Datos[0].Total));
            
            if (res.data.Datos[0].CotizacionEstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');

            var objJSON_Detalle = {
                pCotizacionDetalleId: 0,
                pCotizacionId:        $('#txtCotizacionId').val(),
                pEstatusId:           1
            };

            var json_Detalle = JSON.stringify(objJSON_Detalle, null, 2);

            var res_Detalle = getJSON(
                URL.CotizacionDetalle + 'CotizacionDetalleConPrecioGridJson',
                json_Detalle
            );

            if (res_Detalle != null) {
                if (this.evento == 'COTIZACION_EDIT') {
                    this.tablaDetalle.inicializa();
                };

                if (this.evento == 'COTIZACION_DELETE') {
                    this.tablaDetalleDetalle.inicializa();
                };

                _listDetalle = res_Detalle.data.Datos;
                $('#dgDatosCotizacionDetalle').bootstrapTable("load", _listDetalle);

                $.each(res_Detalle.data.Datos, function (index, value) {
                    _SubTotal  = _SubTotal + value.SubTotal;
                    _Descuento = 0;
                    _Iva       = _Iva + value.Iva;

                    if (value.ServicioId == 9) {
                        _listProcedimientoDetalle = ObtieneCotizacionProcedimientoDetalle(value.CotizacionDetalleId);
                    };
                });

                $("#txtSubTotal").val(priceFormatter(_SubTotal));
                $("#txDescuento").val(priceFormatter(_Descuento));
                $("#txtIva").val(priceFormatter(_Iva));
                $("#txtTotal").val(priceFormatter(res.data.Datos[0].Total));
                $("#txtTotalCotizado").val(priceFormatter(res.data.Datos[0].Total));
            };
        }
    },
    guardar:                      function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            CotizacionId:          $("#txtCotizacionId").val(),
            CotizacionDescripcion: "",
            Fecha:                 null,
            CotizacionTipoId:      -1,
            PersonaId:             -1,
            PersonaNombre:         "",
            Telefono:              "",
            CorreoElectronico:     "",
            Contacto:              "",
            EmpresaId:             -1,
            SubTotal:              0,
            Descuento:             0,
            CampaniaId:            -1,
            Iva:                   0,
            Total:                 0,
            EmpresaNombre:         ''
        };

        var _opcionSeleccionada = $('#rbCotizacionTipoId:checked').val();
        if (_opcionSeleccionada == 1) {
            _obj.PersonaNombre = $("#txtNombre").val();
        };

        if (_opcionSeleccionada == 2) {
            _obj.PersonaId = $("#txtPersonaId").val();
        };

        if (_opcionSeleccionada == 3) {
            _obj.EmpresaNombre = $("#txtEmpresa").val();
            _obj.Contacto      = $("#txtContacto").val();
        };

        if (_opcionSeleccionada == 4) {
            _obj.EmpresaId = $("#txtEmpresaId").val();
        };

        _obj.CotizacionDescripcion = $("#txtCotizacionDescripcion").val();
        _obj.Fecha                 = $("#dtpFecha").val();
        _obj.CotizacionTipoId      = $("input[name='rbCotizacionTipoId']:checked").val();
        _obj.Telefono              = $("#txtTelefono").val();
        _obj.CorreoElectronico     = $("#txtCorreoElectronico").val();
        _obj.SubTotal              = parseFloat(numberNotCommas($('#txtSubTotal').val()));
        _obj.Descuento             = parseFloat(numberNotCommas($('#txtDescuento').val()));
        _obj.CampaniaId            = 0;
        _obj.Iva                   = parseFloat(numberNotCommas($('#txtIva').val()));
        _obj.Total                 = parseFloat(numberNotCommas($('#txtTotal').val()));

        var _data = $('#dgDatosCotizacionDetalle').bootstrapTable('getData', false);
        var _dataDetalle = [];
        var item = {};

        $.each(_listProcedimientoDetalle, function (index, value) {
            item = {
                CotizacionProcedimientoDetalleId: 0,
                CotizacionDetalleId:              0,
                CotizacionId:                     0,
                ProcedimientoDetalleId:           value.ProcedimientoDetalleId,
                ProcedimientoId:                  value.ProcedimientoId,
                ServicioId:                       value.ServicioId,
                ServicioPartidaId:                value.ServicioPartidaId,
                ProcedimientoDetalleDescripcion:  value.ProcedimientoDetalleDescripcion,
                Posicion:                         value.Posicion,
                ClaseOperacion:                   value.ClaseOperacion,
                ElementoId:                       value.ElementoId,
                CantidadOriginal:                 value.CantidadOriginal,
                Cantidad:                         value.Cantidad,
                Unidad:                           value.Unidad,
                CantidadBase:                     value.CantidadBase,
                Tarifa:                           value.Tarifa,
                Costo:                            value.Costo,
                Precio:                           value.PrecioConIva,
                Iva:                              value.Iva,
                TarifaId:                         value.TarifaId,
                SubTotal:                         value.SubTotal,
                Seleccionado:                     value.Seleccionado,
            };

            _dataDetalle.push(item);
        });
        
        var objJSON = {
            model:                      _obj,
            modelDetalle:               _data,
            modelProcedimientoDetalle: _dataDetalle
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Cotizacion + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Cotizacion.redirecciona('COTIZACION_INDEX'); }, 2000);
                else
                    this.redirecciona('COTIZACION_INDEX');
    },
    actualizar:                   function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            CotizacionId:          $("#txtCotizacionId").val(),
            CotizacionDescripcion: "",
            Fecha:                 null,
            CotizacionTipoId:      -1,
            PersonaId:             -1,
            PersonaNombre:         "",
            Telefono:              "",
            CorreoElectronico:     "",
            Contacto:              "",
            EmpresaId:             -1,
            SubTotal:              0,
            Descuento:             0,
            CampaniaId:            -1,
            Iva:                   0,
            Total:                 0,
            EmpresaNombre:         '',
            CotizacionEstatusId:   ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var _opcionSeleccionada = $('#rbCotizacionTipoId:checked').val();
        if (_opcionSeleccionada == 1) {
            _obj.PersonaNombre = $("#txtNombre").val();
        };

        if (_opcionSeleccionada == 2) {
            _obj.PersonaId = $("#txtPersonaId").val();
        };

        if (_opcionSeleccionada == 3) {
            _obj.EmpresaNombre = $("#txtEmpresa").val();
            _obj.Contacto = $("#txtContacto").val();
        };

        if (_opcionSeleccionada == 4) {
            _obj.EmpresaId = $("#txtEmpresaId").val();
        };

        _obj.CotizacionDescripcion = $("#txtCotizacionDescripcion").val();
        _obj.Fecha                 = $("#dtpFecha").val();
        _obj.CotizacionTipoId      = $("input[name='rbCotizacionTipoId']:checked").val();
        _obj.Telefono              = $("#txtTelefono").val();
        _obj.CorreoElectronico     = $("#txtCorreoElectronico").val();
        _obj.SubTotal              = parseFloat(numberNotCommas($('#txtSubTotal').val()));
        _obj.Descuento             = 0;
        _obj.CampaniaId            = 0;
        _obj.Iva                   = parseFloat(numberNotCommas($('#txtIva').val()));
        _obj.Total                 = parseFloat(numberNotCommas($('#txtTotal').val()));

        var _data        = $('#dgDatosCotizacionDetalle').bootstrapTable('getData', false);
        var _dataDetalle = [];
        var item         = {};

        $.each(_listProcedimientoDetalle, function (index, value) {
            item = {
                CotizacionProcedimientoDetalleId: value.CotizacionProcedimientoDetalleId,
                CotizacionDetalleId:              value.CotizacionDetalleId,
                CotizacionId:                     value.CotizacionId,
                ProcedimientoDetalleId: value.ProcedimientoDetalleId,
                ProcedimientoId: value.ProcedimientoId,
                ServicioId:                       value.ServicioId,
                ServicioPartidaId:                value.ServicioPartidaId,
                ProcedimientoDetalleDescripcion:  value.ProcedimientoDetalleDescripcion,
                Posicion:                         value.Posicion,
                ClaseOperacion:                   value.ClaseOperacion,
                ElementoId:                       value.ElementoId,
                CantidadOriginal:                 value.CantidadOriginal,
                Cantidad:                         value.Cantidad,
                Unidad:                           value.Unidad,
                CantidadBase:                     value.CantidadBase,
                Tarifa:                           value.Tarifa,
                Costo:                            value.Costo,
                Precio:                           value.Precio,
                Iva:                              value.Iva,
                TarifaId:                         value.TarifaId,
                SubTotal:                         value.SubTotal,
                Seleccionado:                     value.Seleccionado,
            };

            _dataDetalle.push(item);
        });

        var objJSON = {
            model:                     _obj,
            modelDetalle:              _data,
            modelProcedimientoDetalle: _dataDetalle
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Cotizacion + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Cotizacion.redirecciona('COTIZACION_INDEX'); }, 2000);
                else
                    this.redirecciona('COTIZACION_INDEX');
    },
    //actualizarProcedimientoDetalle: function () {
    //    var _dataProcedimeinto = [];
    //    var item               = {};

    //    $.each(_listProcedimientoDetalle, function (index, value) {
    //        item = {
    //            CotizacionProcedimientoDetalleId: value.CotizacionProcedimientoDetalleId,
    //            Cantidad:                         value.Cantidad,
    //            CantidadOriginal:                 value.CantidadOriginal,
    //            CantidadBase:                     value.CantidadBase,
    //            Costo:                            value.Costo,
    //            Precio:                           value.Precio,
    //            Iva:                              value.Iva,
    //            SubTotal:                         value.SubTotal,
    //            Seleccionado:                     value.Seleccionado,
    //        };

    //        _dataProcedimeinto.push(item);
    //    });

    //    var objJSON = {
    //        model: _dataProcedimeinto
    //    };

    //    var json = JSON.stringify(objJSON, null, 2);
        
    //    var res = getJSON(
    //        URL.CotizacionProcedimientoDetalle + 'Edit',
    //        json
    //    );

    //    if (res != null)
    //        if (!res.data.Error)
    //            if (res.data.MuestraAlert)
    //                setTimeout(function () { $(location).attr('href', URL.Cotizacion + 'Edit?pCotizacionId=' + $("#txtCotizacionId").val()) }, 2000);
    //            //else
    //            //    this.redirecciona('COTIZACION_INDEX');
    //},
    baja:                         function () {
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
                    CotizacionId: $("#txtCotizacionId").val()
                };

                var objJSON = {
                    model: _obj
                };

                var json = JSON.stringify(objJSON, null, 2);

                var res = getJSON(
                    URL.Cotizacion + 'Delete',
                    json
                );

                if (res != null)
                    if (!res.data.Error)
                        if (res.data.MuestraAlert)
                            setTimeout(function () { Cotizacion.redirecciona('COTIZACION_INDEX'); }, 2000);
                        else
                            this.redirecciona('COTIZACION_INDEX');
            }
            else {
                swal.close();
            }
        });
    },
    keyEvent:                     function () {
        $("#txtCotizacionDescripcion").on("change paste keyup", function () {
            if ($("#txtCotizacionDescripcion").val().trim() == "")
                $('span[data-valmsg-for="CotizacionDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CotizacionDescripcion"]').text('');
        });
        
        $("#dtpFecha").on("change paste keyup", function () {
            if ($("#dtpFecha").val().trim() == "")
                $('span[data-valmsg-for="Fecha"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Fecha"]').text('');
        });

        $("#txtNombre").on("change paste keyup", function () {
            if ($("#txtNombre").val().trim() == "")
                $('span[data-valmsg-for="Nombre"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Nombre"]').text('');
        });

        $("#txtEmpresa").on("change paste keyup", function () {
            if ($("#txtEmpresa").val().trim() == "")
                $('span[data-valmsg-for="Empresa"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Empresa"]').text('');
        });

        $("#txtTelefono").on("change paste keyup", function () {
            if ($("#txtTelefono").val().trim() == "")
                $('span[data-valmsg-for="Telefono"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Telefono"]').text('');
        });

        $("#txtTelefono").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });

        $("#txtCorreoElectronico").on("change paste keyup", function () {
            if ($("#txtCorreoElectronico").val().trim() == "")
                $('span[data-valmsg-for="CorreoElectronico"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CorreoElectronico"]').text('');
        });

        $("#txtContacto").on("change paste keyup", function () {
            if ($("#txtContacto").val().trim() == "")
                $('span[data-valmsg-for="Contacto"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Contacto"]').text('');
        });

        $("#txtNombrePersona").on("change paste keyup", function () {
            if ($("#txtPersonaId").val().trim() == "")
                $('span[data-valmsg-for="NombrePersona"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="NombrePersona"]').text('');
        });

        $("#txtNombreEmpresa").on("change paste keyup", function () {
            if ($("#txtNombreEmpresa").val().trim() == "")
                $('span[data-valmsg-for="NombreEmpresa"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="NombreEmpresa"]').text('');
        });

        $("input:radio[name='rbCotizacionTipoId']").on('ifChecked', function (event) {
            // PERSONA FISICA
            if (this.value == 1) {
                $("#divNombre").removeClass("hide");
                $("#txtNombre").val('');

                $("#divTelefono").removeClass("hide");
                $("#txtTelefono").val('');

                $("#divCorreoElectronico").removeClass("hide");
                $("#txtCorreoElectronico").val('');
                
                $("#divAfiliado").addClass("hide");
                $("#divEmpresa").addClass("hide");
                $("#divContacto").addClass("hide");
                $("#divConvenio").addClass("hide");
            };

            // PERSONA EXISTENTE
            if (this.value == 2) {
                $("#divAfiliado").removeClass("hide");
                $("#txtPersonaId").val('');
                $("#txtNombrePersona").val('');

                $("#divNombre").addClass("hide");
                $("#divTelefono").addClass("hide");
                $("#divCorreoElectronico").addClass("hide");
                $("#divEmpresa").addClass("hide");
                $("#divContacto").addClass("hide");
                $("#divConvenio").addClass("hide");
            };

            // EMPRESARIAL
            if (this.value == 3) {
                $("#divEmpresa").removeClass("hide");
                $("#txtEmpresa").val('');
                
                $("#divContacto").removeClass("hide");
                $("#txtContacto").val('');

                $("#divTelefono").removeClass("hide");
                $("#txtTelefono").val('');

                $("#divCorreoElectronico").removeClass("hide");
                $("#txtCorreoElectronico").val('');
                
                $("#divNombre").addClass("hide");
                $("#divAfiliado").addClass("hide");
                $("#divConvenio").addClass("hide");
            };

            // CONVENIO
            if (this.value == 4) {
                $("#divConvenio").removeClass("hide");
                $("#txtEmprsaId").val('');
                $("#txtEmpresaPersona").val('');

                $("#divNombre").addClass("hide");
                $("#divTelefono").addClass("hide");
                $("#divCorreoElectronico").addClass("hide");
                $("#divAfiliado").addClass("hide");
                $("#divEmpresa").addClass("hide");
                $("#divContacto").addClass("hide");
            };
        });
    },
    keyEventIndex:                function () {
        $("input:radio[name='rbCotizacionTipoId']").on('ifChecked', function (event) {
            if (this.value == 1) {
                $("#divNumSocio").removeClass("hide");
                $("#divEmpresa").addClass("hide");
            } else if (this.value == 2) {
                $("#divNumSocio").addClass("hide");
                $("#divEmpresa").removeClass("hide");
            } else if (this.value == -1) {
                $("#divNumSocio").addClass("hide");
                $("#divEmpresa").addClass("hide");
            }
        });

        $('#dgDatosCotizacion').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosCotizacion tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCotizacion').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'CotizacionId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'Fecha',
                        title:     'Fecha',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'CotizacionDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'CotizacionTipoDescripcion',
                        title:     'Tipo',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'PersonaNombre',
                        title:     'Nombre',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'EmpresaNombre',
                        title:     'Empresa',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Total',
                        title:     'Total ($)',
                        sortable:  true,
                        formatter: 'priceFormatter',
                        align:     'right'
                    },
                    {
                        field:     'CotizacionEstatusId',
                        title:     'Estatus',
                        formatter: 'CotizacionEstatusIdFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        formatter: this.accion(),
                        events:    'Cotizacion_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pCotizacionDescripcion: $('#txtCotizacionDescripcion').val(),
                pFechaInicio:           ($('#dtpFechaInicial').val() == "" ? null : $('#dtpFechaInicial').val()),
                pFechaFin:              ($('#dtpFechaFinal').val()   == "" ? null : $('#dtpFechaFinal').val()),
                pCotizacionTipoId:      parseInt($('#rbCotizacionTipoId:checked').val()),
                pEstatusId:             parseInt($('#rbEstatusId:checked').val()),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Cotizacion + 'CotizacionGridJson',
                json
            );

            $('#dgDatosCotizacion').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<div class="btn-group">',
                    '<button data-toggle="dropdown" class="btn btn-default btn-sm dropdown-toggle" aria-expanded="false">',
                        '<span><i class="fa fa-ellipsis-h"></i></span>',
                    '</button>',
                    '<ul class="dropdown-menu pull-right">',
                        '<li>',
                            '<a class="editCotizacion" href="javascript:void(0)">',
                                '<i class="text-success fa fa-pencil fa-2x"></i>&nbsp;&nbsp; Editar',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="printCotizacion" href="javascript:void(0)">',
                                '<i class="text-primary fa fa-download fa-2x"></i>&nbsp;&nbsp; Descargar',
                            '</a>',
                        '</li>',

                        '<li>',
                            '<a class="detailCotizacion" href="javascript:void(0)">',
                                '<i class="text-info fa fa-search fa-2x"></i>&nbsp;&nbsp; Detalle',
                            '</a>',
                        '</li>',

                        '<li>',
                            '<a class="procCotizacion" href="javascript:void(0)">',
                                '<i class="text-warning2 fa fa-gears fa-2x"></i>&nbsp;&nbsp; Procedimiento',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="removeCotizacion" href="javascript:void(0)">',
                                '<i class="text-danger fa fa-trash fa-2x"></i>&nbsp;&nbsp; Eliminar',
                            '</a>',
                        '</li>',
                    '</ul >',
                '</div>'


                //'<a class="editCotizacion" href="javascript:void(0)" title="Editar">',
                //    '<i class="text-success fa fa-pencil fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="printCotizacion" href="javascript:void(0)" title="Descargar">',
                //    '<i class="text-primary fa fa-download fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="detailCotizacion" href="javascript:void(0)" title="Detalle">',
                //    '<i class="text-info fa fa-search fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="liveLineCotizacion" href="javascript:void(0)" title="Línea de Vida">',
                //'<i class="text-primary2 fa fa-exclamation-circle fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="sendEmailCotizacion" href="javascript:void(0)" title="Enviar Correo">',
                //'<i class="text-muted fa fa-envelope fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="procCotizacion" href="javascript:void(0)" title="Procedimiento">',
                //'<i class="text-warning2 fa fa-gears fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="removeCotizacion" href="javascript:void(0)" title="Inactivo">',
                //    '<i class="text-danger fa fa-trash fa-2x"></i>',
                //'</a>'
            ].join('');
        }
    },
    tablaDetalle: {
        inicializa:    function () {
            $('#dgDatosCotizacionDetalle .editable').editable('toggleDisabled');
            
            $('#dgDatosCotizacionDetalle').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'CotizacionDetalleId',
                        title:     'CotizacionDetalleId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'CotizacionId',
                        title:     'CotizacionId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'AreaNegocioId',
                        title:     'AreaNegocioId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ServicioId',
                        title:     'ServicioId',
                        align:     'left',
                        visible:   false
                    },
                    {
                        field:     'ItemId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ItemDescripcion',
                        title:     'Descripci&oacute;n',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'ItemTipoId',
                        title:     'Tipo',
                        sortable:  true,
                        align:     'left',
                        visible:   false
                    },
                    {
                        field:     'ItemTipoDescripcion',
                        title:     'Tipo',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Cantidad',
                        title:     'Cantidad',
                        sortable:  true,
                        editable: {
                            type:  'text',
                            title: 'Debe teclear la cantidad'
                        },
                        align:     'center'
                    },
                    {
                        field:     'Costo',
                        title:     'Costo ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                        visible:   false
                    },
                    {
                        field:     'Precio',
                        title:     'Precio ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                        visible:   false
                    },
                    {
                        field:     'PrecioConIva',
                        title:     'Precio ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter'
                    },
                    {
                        field:     'Iva',
                        title:     'Iva ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                        visible:   false
                    },
                    {
                        field:     'SubTotal',
                        title:     'SubTotal ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                        visible:   false
                    },
                    {
                        field:     'SubTotalConIva',
                        title:     'SubTotal ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        formatter: this.accionDetalle(),
                        events:    'CotizacionDetalle_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        accionDetalle: function (value, row, index) {
            return [
                '<a class="removeItem" href="javascript:void(0)" title="Eliminar">',
                	'<i class="text-danger fa fa-times fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="detalleProcedimientoItem" href="javascript:void(0)" title="Detalle">',
                	'<i class="text-warning fa fa-cog fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    tablaDetalleDetalle: {
        inicializa: function () {
            $('#dgDatosCotizacionDetalle').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'CotizacionDetalleId',
                        title:     'CotizacionDetalleId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'CotizacionId',
                        title:     'CotizacionId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'AreaNegocioId',
                        title:     'AreaNegocioId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ServicioId',
                        title:     'ServicioId',
                        align:     'left',
                        visible:   false
                    },
                    {
                        field:     'ItemId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'ItemDescripcion',
                        title:     'Descripci&oacute;n',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'ItemTipoId',
                        title:     'Tipo',
                        sortable:  true,
                        align:     'left',
                        visible:   false
                    },
                    {
                        field:     'ItemTipoDescripcion',
                        title:     'Tipo',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Cantidad',
                        title:     'Cantidad',
                        align:     'center',
                        align:     'center'
                    },
                    {
                        field:     'Costo',
                        title:     'Costo ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                        visible:   false
                    },
                    {
                        field:     'Precio',
                        title:     'Precio ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter'
                    },
                    {
                        field:     'PrecioConIva',
                        title:     'Precio ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter'
                    },
                    {
                        field:     'Iva',
                        title:     'Iva ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter'
                    },
                    {
                        field:     'SubTotal',
                        title:     'SubTotal ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter'
                    }
                ]
            });
        },
    },
    buscar:                        function () {
        //if (!this.validaBusqueda()) return;

        this.tabla.datos();
    },
    validaBusqueda:                function () {
        if ($("#txtCotizacionDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="CotizacionDescripcion"]').text('Campo Requerido');
            $("#txtCotizacionDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:                 function () {
        if ($("#txtCotizacionDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="CotizacionDescripcion"]').text('Campo Requerido');
            $("#txtCotizacionDescripcion").focus();

            $('#rootwizard').find("a[href*='tab1']").trigger('click');

            return false;
        }

        if ($("#dtpFecha").val().trim() == "") {
            $('span[data-valmsg-for="Fecha"]').text('Campo Requerido');
            $("#dtpFecha").focus();

            $('#rootwizard').find("a[href*='tab1']").trigger('click');

            return false;
        }

        var _opcionSeleccionada = $('#rbCotizacionTipoId:checked').val();
        if (_opcionSeleccionada == 1) {
            if ($("#txtNombre").val().trim() == "") {
                $('span[data-valmsg-for="Nombre"]').text('Campo Requerido');
                $("#txtNombre").focus();

                $('#rootwizard').find("a[href*='tab1']").trigger('click');

                return false;
            }

            if ($("#txtTelefono").val().trim() == "") {
                $('span[data-valmsg-for="Telefono"]').text('Campo Requerido');
                $("#txtTelefono").focus();

                $('#rootwizard').find("a[href*='tab1']").trigger('click');

                return false;
            }

            if ($("#txtCorreoElectronico").val().trim() == "") {
                $('span[data-valmsg-for="CorreoElectronico"]').text('Campo Requerido');
                $("#txtCorreoElectronico").focus();

                $('#rootwizard').find("a[href*='tab1']").trigger('click');

                return false;
            }
        };

        if (_opcionSeleccionada == 2) {
            if ($("#txtNombrePersona").val().trim() == "") {
                $('span[data-valmsg-for="NombrePersona"]').text('Campo Requerido');
                $("#txtNombrePersona").focus();

                return false;
            }
        };

        if (_opcionSeleccionada == 3) {
            if ($("#txtEmpresa").val().trim() == "") {
                $('span[data-valmsg-for="Empresa"]').text('Campo Requerido');
                $("#txtEmpresa").focus();

                return false;
            }

            if ($("#txtContacto").val().trim() == "") {
                $('span[data-valmsg-for="Contacto"]').text('Campo Requerido');
                $("#txtContacto").focus();

                return false;
            }

            if ($("#txtTelefono").val().trim() == "") {
                $('span[data-valmsg-for="Telefono"]').text('Campo Requerido');
                $("#txtTelefono").focus();

                return false;
            }

            if ($("#txtCorreoElectronico").val().trim() == "") {
                $('span[data-valmsg-for="CorreoElectronico"]').text('Campo Requerido');
                $("#txtCorreoElectronico").focus();

                return false;
            }
        };

        if (_opcionSeleccionada == 4) {
            if ($("#txtEmpresaId").val().trim() == "") {
                $('span[data-valmsg-for="EmpresaId"]').text('Campo Requerido');
                $("#EmpresaId").focus();

                return false;
            }
        };

        var _text = $('#dgDatosCotizacionDetalle').bootstrapTable('getData');
        if (_text.length == 0) {
            swal({
                title: "Debe seleccionar al menos un artículo",
                text:  "",
                type:  "warning"
            });

            return false;
        }

        return true;
    },
    limpiar:                       function () {
        this.inicializa('COTIZACION_INDEX');
    },
    redirecciona:                  function (evento) {
        if (evento == 'COTIZACION_INDEX') {
            $(location).attr('href', URL.Cotizacion);
        };

        if (evento == 'COTIZACION_CREATE') {
            $(location).attr('href', URL.Cotizacion + 'Create');
        };
    },
    limpiarCtrls:                  function () {
        $('#txtCotizacionDescripcion').val('');
        
        $('span[data-valmsg-for="CotizacionDescripcion"]').text('');
		
        $('#dtpFechaInicial').val('');
        $('#dtpFechaFinal').val('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=3]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');


        $("input[name=rbCotizacionTipoId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbCotizacionTipoId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbCotizacionTipoId][value=3]").prop('checked', false).iCheck('update');
        $("input[name=rbCotizacionTipoId][value=4]").prop('checked', false).iCheck('update');
        $("input[name=rbCotizacionTipoId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls:      function (isDisabled) {
        DisabledEneableElement('txtCotizacionDescripcion', isDisabled);
    },
    AbreModalArticulo:             function () {
        $("#myModalBusquedaServicio").modal();

        Servicio.llenaCombo("ddlCtrlUserBusquedaServicioId", "SELECCIONE");
        $("#ddlCtrlUserBusquedaServicioId").val(0);
        $("#txtCtrlUserBusquedaServicioDescripcion").val("");

        $('#dgDatosBusquedaServicio').bootstrapTable('removeAll');

        CtrlUserBusquedaServicio.inicializa("CTRL_USER_BUSQUEDA_SERVICIO_INDEX");
    },
    AgregarItem:                   function () {
        var data        = $('#dgDatosBusquedaServicio').bootstrapTable('getSelections');
        var dataDetalle = $('#dgDatosCotizacionDetalle').bootstrapTable('getData');

        if (data.length == 0) {
            swal("Debe seleccionar al menos un artículo", "", "warning");

            return;
        }

        if (ValidaPrecioCero(data)) return false;

        if (ValidaDuplicados(dataDetalle, data)) return false;

        var item  = {};

        $('span[data-valmsg-for="DatosCotizacionDetalle"]').text('');
        
        $.each(data, function (index, value) {
            if (value.ServicioId == 9) {
                _listProcedimientoDetalle = ObtieneProcedimientoDetalle(value.ItemId);
            }

            item = {
                CotizacionDetalleId: 0,
                CotizacionId:        0,
                AreaNegocioId:       value.AreaNegocioId,
                ServicioId:          value.ServicioId,
                ItemId:              value.ItemId,
                ItemDescripcion:     value.ItemDescripcion,
                ItemTipoId:          value.ItemTipoId,
                ItemTipoDescripcion: value.ItemTipoDescripcion,
                Cantidad:            1,
                Costo:               value.Costo,
                Precio:              value.Precio,
                PrecioConIva:        value.PrecioConIva,
                Iva:                 value.Iva,
                Descuento:           0, //value.Descuento,
                CampaniaId:          0, //value.CampaniaId,
                TarifaId:            value.TarifaId,
                SubTotal:            value.Precio * 1,
                SubTotalConIva:      value.PrecioConIva * 1,
                Amparada:            value.Amparada
            }

            _listDetalle.push(item);

            _SubTotal = _SubTotal + item.SubTotal;
            _Iva      = _Iva + item.Iva;
            _Total    = _Total + item.SubTotalConIva;
        });

        $('#dgDatosCotizacionDetalle').bootstrapTable("load", _listDetalle);
        
        $("#txtSubTotal").val(priceFormatter(_SubTotal));
        $("#txDescuento").val(priceFormatter(_Descuento));
        $("#txtIva").val(priceFormatter(_Iva));
        $("#txtTotal").val(priceFormatter(_Total));
        $("#txtTotalCotizado").val(priceFormatter(_Total));

        swal({
            title: "El item seleccionado ha sido agregado",
            text: "",
            type: "success",
            timer: 800
        });

        $("#txtServicioDescripcion").val("");
        $('#dgDatosBusquedaServicio').bootstrapTable('removeAll');
    },
    AbreModalPersona:              function () {
        $("#myModalBusquedaPersona").modal();

        $("#txtPersonaId").val("");
        $("#txtNombrePersona").val("");

        $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('removeAll');

        CtrlUserBusquedaPersona.baja         = 0;
        CtrlUserBusquedaPersona.bajaAsociado = null;
        CtrlUserBusquedaPersona.inicializa("CTRL_USER_BUSQUEDA_PERSONA_INDEX");
    },
    AgregarPersona:                function () {
        var data = $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('getSelections');
        
        if ((data.length >= 2) || (data.length == 0)) {
            swal("Debe seleccionar una persona", "", "warning");

            return;
        }

        $("#txtPersonaId").val(data[0].PersonaId);
        $("#txtNombrePersona").val(data[0].NombreCompleto);

        $('span[data-valmsg-for="NombrePersona"]').text('');

        $("#myModalBusquedaPersona").modal("toggle");
    },
    AbreModalEmpresa:              function () {
        $("#myModalBusquedaEmpresa").modal();

        $("#txtEmpresaId").val("");
        $("#txtNombreEmpresa").val("");

        $('#dgDatosCtrlUserBusquedaEmpresa').bootstrapTable('removeAll');

        CtrlUserBusquedaEmpresa.inicializa("CTRL_USER_BUSQUEDA_EMPRESA_INDEX");
    },
    AgregarEmpresa:                function () {
        var data = $('#dgDatosCtrlUserBusquedaEmpresa').bootstrapTable('getSelections');

        if ((data.length >= 2) || (data.length == 0)) {
            swal("Debe seleccionar una empresa", "", "warning");

            return;
        }

        $("#txtEmpresaId").val(data[0].EmpresaId);
        $("#txtNombreEmpresa").val(data[0].EmpresaDescripcion);

        $('span[data-valmsg-for="NombreEmpresa"]').text('');

        $("#myModalBusquedaEmpresa").modal("toggle");
    },
    AbreModalProcedimientoDetalle: function (procedimeintoId, procedimientoDetalle, data) {
        $("#myModalProcedimientoDetalle").modal();

        $('#dgDatosCotizacionProcedimientoDetalle').bootstrapTable('removeAll');

        if (this.evento == 'COTIZACION_CREATE')
            CtrlUserCotizacionProcedimientoDetalle.inicializa('CTRL_USER_COTIZACION_PROCEDIMIENTO_DETALLE_INDEX', procedimeintoId, procedimientoDetalle, data);

        if (this.evento == 'COTIZACION_EDIT')
            CtrlUserCotizacionProcedimientoDetalle.inicializa('CTRL_USER_COTIZACION_PROCEDIMIENTO_DETALLE_EDIT', procedimeintoId, procedimientoDetalle, data);
    },
    ActualizaProcedimientoDetalle: function () {
        swal("El procedimiento fue actualizado satisfactoriemente.", "", "success");

        $.each(_listDetalle, function (index, value) {
            if (value.ServicioId == 9) {
                var _procedimientoId       = value.ItemId;
                var _subTotalProcedimeinto = 0;

                $.each(_listProcedimientoDetalle, function (index2, value2) {
                    if (value2.ProcedimientoId == _procedimientoId && value2.Seleccionado == true) {
                        _subTotalProcedimeinto = _subTotalProcedimeinto + (value2.PrecioConIva * value2.Cantidad);
                    }
                });

                value.Costo          = _subTotalProcedimeinto;
                value.Precio         = _subTotalProcedimeinto;
                value.PrecioConIva   = _subTotalProcedimeinto;
                value.SubTotal       = _subTotalProcedimeinto;
                value.SubTotalConIva = _subTotalProcedimeinto;
                value.Total          = _subTotalProcedimeinto;
            }
        });

        CalculaTotal();

        $('#dgDatosCotizacionDetalle').bootstrapTable("load", _listDetalle);

        $("#myModalProcedimientoDetalle").modal("toggle");
    }
};




function ObtieneProcedimientoDetalle(procedimientoId) {
    var objJSON = {
        pProcedimientoId:          procedimientoId,
        pProcedimientoDescripcion: '',
        pEstatusId:                1
    };

    var json = JSON.stringify(objJSON, null, 2);

    var res = getJSON(
        URL.ProcedimientoDetalle + 'ProcedimientoDetalleGridConPrecioJson',
        json
    );

    var _array = [];
    var item   = {};

    $.each(res.data.Datos, function (index, value) {
        item = {
            ProcedimientoDetalleId:          value.ProcedimientoDetalleId,
            ProcedimientoId:                 procedimientoId,
            ServicioId:                      value.ServicioId,
            ServicioPartidaId:               value.ServicioPartidaId,
            ProcedimientoDetalleDescripcion: value.ProcedimientoDetalleDescripcion,
            Posicion:                        value.Posicion,
            ClaseOperacion:                  value.ClaseOperacion,
            ElementoId:                      value.ElementoId,
            CantidadOriginal:                value.Cantidad,
            Cantidad:                        value.Cantidad,
            Unidad:                          value.Unidad,
            CantidadBase:                    value.CantidadBase,
            Descripción:                     value.Descripción,
            Tarifa:                          value.Tarifa,
            Costo:                           value.Costo,
            Precio:                          value.Precio,
            PrecioConIva:                    value.PrecioConIva,
            Iva:                             value.Iva,
            SubTotal:                        value.SubTotal,
            SubTotalConIva:                  value.SubTotalConIva,
            EstatusId:                       value.EstatusId,
            Seleccionado:                    true
        };

        _array.push(item);
    });

    return _array;
};




function ObtieneCotizacionProcedimientoDetalle(cotizacionDetalleId) {
    var objJSON = {
        pCotizacionDetalleId: cotizacionDetalleId,
        pCotizacionId:        0,
        pEstatusId:           1
    };

    var json = JSON.stringify(objJSON, null, 2);

    var res = getJSON(
        URL.CotizacionProcedimientoDetalle + 'CotizacionProcedimientoDetalleGridConPrecioJson',
        json
    );

    var _array = [];
    var item   = {};

    $.each(res.data.Datos, function (index, value) {
        item = {
            CotizacionProcedimientoDetalleId: value.CotizacionProcedimientoDetalleId,
            CotizacionDetalleId:              value.CotizacionDetalleId,
            CotizacionId:                     value.CotizacionId,
            ProcedimientoDetalleId:           value.ProcedimientoDetalleId,
            ProcedimientoId:                  value.ProcedimientoId,
            ServicioId:                       value.ServicioId,
            ServicioPartidaId:                value.ServicioPartidaId,
            ProcedimientoDetalleDescripcion:  value.ProcedimientoDetalleDescripcion,
            Posicion:                         value.Posicion,
            ClaseOperacion:                   value.ClaseOperacion,
            ElementoId:                       value.ElementoId,
            CantidadOriginal:                 value.Cantidad,
            Cantidad:                         value.Cantidad,
            Unidad:                           value.Unidad,
            CantidadBase:                     value.CantidadBase,
            Descripción:                      value.Descripción,
            Tarifa:                           value.Tarifa,
            Costo:                            value.Costo,
            Precio:                           value.Precio,
            PrecioConIva:                     value.PrecioConIva,
            Iva:                              value.Iva,
            SubTotal:                         value.SubTotal,
            SubTotalConIva:                   value.SubTotalConIva,
            EstatusId:                        value.EstatusId,
            Seleccionado:                     value.Seleccionado
        };

        _array.push(item);
    });

    return _array;
};




function ValidaDuplicados(dataActual, dataNuevo) {
    var existe = false;

    if (dataActual.length > 0) {
        jQuery.each(dataNuevo, function (index, value) {
            if (!existe) {
                var rowActual_ServicioId      = value.ServicioId;
                var rowActual_ItemId          = value.ItemId;
                var rowActual_ItemDescripcion = value.ItemDescripcion;

                jQuery.each(dataActual, function (index, value) {
                    if (!existe) {
                        var rowNuevo_ServicioId      = value.ServicioId;
                        var rowNuevo_ItemId          = value.ItemId;
                        var rowNuevo_ItemDescripcion = value.ItemDescripcion;

                        if (
                            rowActual_ServicioId == rowNuevo_ServicioId
                            &&
                            rowActual_ItemId == rowNuevo_ItemId
                            &&
                            rowActual_ItemDescripcion == rowNuevo_ItemDescripcion
                        ) {
                            existe = true;

                            swal("El servicio ya fue agregado previamente.", "", "warning");
                        };
                    };
                });
            };
        });
    }

    return existe;
};




function ValidaPrecioCero(data) {
    var existe = false;

    jQuery.each(data, function (index, value) {
        if (!existe) {
            if (value.Precio == 0) {
                existe = true;

                swal("No se puede agregar items com precio cero", "", "warning");
            }
        }
    });

    return existe;
};




function ValidaSoloProcedimeinto(data) {
    var existe = false;

    if (data.length > 0) {
        jQuery.each(data, function (index, value) {
            //if (!existe) {
            //    var rowActual_ServicioId = value.ServicioId;
            //    var rowActual_ItemId = value.ItemId;
            //    var rowActual_ItemDescripcion = value.ItemDescripcion;

            //    jQuery.each(dataActual, function (index, value) {
            //        if (!existe) {
            //            var rowNuevo_ServicioId = value.ServicioId;
            //            var rowNuevo_ItemId = value.ItemId;
            //            var rowNuevo_ItemDescripcion = value.ItemDescripcion;

            //            if (
            //                rowActual_ServicioId == rowNuevo_ServicioId
            //                &&
            //                rowActual_ItemId == rowNuevo_ItemId
            //                &&
            //                rowActual_ItemDescripcion == rowNuevo_ItemDescripcion
            //            ) {
            //                existe = true;

            //                swal("El servicio ya fue agregado previamente.", "", "warning");
            //            };
            //        };
            //    });
            //};
        });
    }

    return existe;
};




function CalculaTotal() {
    var dataDatos = $('#dgDatosCotizacionDetalle').bootstrapTable('getData', false);

    var _SubTotalGrid       = 0;
    var _SubTotalConIvaGrid = 0;
    var _DescuentoGrid 		= 0;
    var _IvaGrid            = 0;

    $.each(dataDatos, function (clave, valor) {
        $.each(valor, function (clave2, valor2) {
            if (clave2 == "Iva") {
                _IvaGrid += valor2;
            };

            if (clave2 == "SubTotal") {
                _SubTotalGrid += valor2;
            };

            if (clave2 == "SubTotalConIva") {
                _SubTotalConIvaGrid += valor2;
            };
        });
    });

    $("#txtSubTotal").val(priceFormatter(_SubTotalGrid));
    _SubTotal = _SubTotalGrid;

    //$("#txDescuento").val(priceFormatter(_DescuentoGrid));
    //_Descuento = _DescuentoGrid;

    $("#txtIva").val(priceFormatter(_IvaGrid));
    _Iva = _IvaGrid;

    $("#txtTotal").val(priceFormatter(_SubTotalConIvaGrid));
    _Total = _SubTotalConIvaGrid;

    $("#txtTotalCotizado").val(priceFormatter(_SubTotalConIvaGrid));
}




$('#dgDatosCotizacionDetalle').on('editable-save.bs.table', function (e, field, renglon, old, $el) {
    if (field == "Cantidad") {
        if (!Number(renglon.Cantidad))
            renglon.Cantidad = 1;
		
		if ((parseInt(renglon.Cantidad) <= 0) == true)
            renglon.Cantidad = 1;

        if (renglon.ServicioId == 9) {
            if (renglon.Cantidad > 1) {
                renglon.Cantidad = 1;

                swal({
                    title: "Por efecto de anticipo no se puede cotizar mas de un mismo proceimineto para una sola persona",
                    text: "",
                    type: "warning"
                });
            }
        }

        var $table = $('#dgDatosCotizacionDetalle');
        var $els = $table.find('.editable');

        row_index = $els.index($el);

        $table.bootstrapTable('updateRow', {
            index: row_index,
            row: {
                ItemId:         renglon.ItemId,
                SubTotal:       renglon.Precio * renglon.Cantidad,
                SubTotalConIva: renglon.PrecioConIva * renglon.Cantidad
            }
        });

        CalculaTotal();
    };
});




window.Cotizacion_ActionEvents = {
    'click .editCotizacion':   function (e, value, row, index) {
        if (row.EstatusId == 3) {
            swal('La cotización ya fue procesada y no se puede editar.', '', 'info');
            
            return;
        };

        $(location).attr('href', URL.Cotizacion + 'Edit?pCotizacionId=' + row.CotizacionId);
    },
    'click .printCotizacion':  function (e, value, row, index) {
        if (row.EstatusId == 3) {
            swal('La cotización ya fue procesada y no se puede editar.', '', 'info');
            
            return;
        };

        $(location).attr('href', URL.Cotizacion + 'CreatePDFJson?parCotizacionId=' + row.CotizacionId);
    },
    'click .detailCotizacion': function (e, value, row, index) {
        $("#txtModalCotizacionId").val(row.CotizacionId);

        CotizacionDetalleView.inicializa('COTIZACION_DETALLE_VIEW_INDEX');

        $("#myModalCotizacionDetalle").modal();
    },
    'click .removeCotizacion': function (e, value, row, index) {
        if (row.EstatusId == 3) {
            swal('La cotización ya fue procesada y no se puede eliminar.', '', 'info');

            return;
        };

        $(location).attr('href', URL.Cotizacion + 'Delete?pCotizacionId=' + row.CotizacionId);
    }
};




window.CotizacionDetalle_ActionEvents = {
    'click .removeItem':               function (e, value, row, index) {
        var $tableDetalle = $('#dgDatosCotizacionDetalle');
        $tableDetalle.bootstrapTable('remove', {
            field: 'ItemDescripcion',
            values: [row.ItemDescripcion]
        });

        CalculaTotal();
    },
    'click .detalleProcedimientoItem': function (e, value, row, index) {
        if (row.ServicioId == 9) {
            var _data = _listProcedimientoDetalle.filter(function (proc) {
                if (proc.ProcedimientoId == row.ItemId) {
                    return proc;
                }
            });

            Cotizacion.AbreModalProcedimientoDetalle(row.ItemId, row.ItemDescripcion, _data);
        };
    }
};