var _listDetalle              = [];
var _listProcedimientoDetalle = { Datos: [] };
var _SubTotal                 = 0;
var _Descuento                = 0;
var _Iva                      = 0;
var _Total                    = 0;
var _Anticipo                 = 0;




$(function () {
    Venta.inicializa($("#txtApuntadorVenta").val());
});




var Venta = {
    evento:                         null,
    inicializa:                     function (evento) {
        this.evento = evento;

        if (this.evento == 'VENTA_INDEX') {
            this.keyEventIndex();
            this.limpiarCtrls();

            VentaMotivoCancelacionTipo.llenaCombo('dllVentaMotivoCancelacionTipoId', 'SELECCIONE');

            InicializarDtp('dtpFechaInicial');
            InicializarDtp('dtpFechaFinal');
            
            //$("#datepicker").on("changeDate", function (event) {
            //    $("#my_hidden_input").val(
            //        $("#datepicker").datepicker('getFormattedDate')
            //    )
            //});
			
            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'VENTA_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified',
                onTabClick: function (tan, nabigation, index) {
                    return false;
                },
                onNext: function (tab, navigation, index) {
                    if (index == 1) {
                        if ($("#txtVentaDescripcion").val().trim() == "") {
                            $('span[data-valmsg-for="VentaDescripcion"]').text('Campo Requerido');
                            $("#txtVentaDescripcion").focus();

                            return false;
                        }

                        if ($("#dtpFecha").val().trim() == "") {
                            $('span[data-valmsg-for="Fecha"]').text('Campo Requerido');
                            $("#dtpFecha").focus();

                            return false;
                        }

                        var _opcionSeleccionada = $('#rbVentaTipoId:checked').val();
                        if (_opcionSeleccionada == 1) {
                            if ($("#txtNombrePersona").val().trim() == "") {
                                $('span[data-valmsg-for="NombrePersona"]').text('Campo Requerido');
                                $("#txtNombrePersona").focus();

                                return false;
                            }
                        };

                        if (_opcionSeleccionada == 2) {
                            if ($("#txtNombreEmpresa").val().trim() == "") {
                                $('span[data-valmsg-for="NombreEmpresa"]').text('Campo Requerido');
                                $("#EmpresaId").focus();

                                return false;
                            }
                        };
                    }
                    
                    if (index == 2) {
                        var _data = $('#dgDatosVentaDetalle').bootstrapTable('getData');
                        if (_data.length == 0) {
                            $('span[data-valmsg-for="DatosVentaDetalle"]').text('Debe seleccionar los artículos a cotizar');

                            return false;
                        }
                    }
                }
            });

            InicializarDtpClass('.input-group.date');
            $('.input-group.date').datepicker('update', new Date());

            this.tablaDetalle.inicializa();
            
            $("input[name=rbVentaTipoId][value=1]").prop('checked', true).iCheck('update');
            $("input[name=rbVentaTipoId][value=2]").prop('checked', false).iCheck('update');
        };

        if (this.evento == 'VENTA_EDIT') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified',
                onTabClick: function (tan, nabigation, index) {
                    return false;
                },
                onNext: function (tab, navigation, index) {
                    if (index == 1) {
                        if ($("#txtVentaDescripcion").val().trim() == "") {
                            $('span[data-valmsg-for="VentaDescripcion"]').text('Campo Requerido');
                            $("#txtVentaDescripcion").focus();

                            return false;
                        }

                        if ($("#dtpFecha").val().trim() == "") {
                            $('span[data-valmsg-for="Fecha"]').text('Campo Requerido');
                            $("#dtpFecha").focus();

                            return false;
                        }

                        var _opcionSeleccionada = $('#rbVentaTipoId:checked').val();
                        if (_opcionSeleccionada == 1) {
                            if ($("#txtNombrePersona").val().trim() == "") {
                                $('span[data-valmsg-for="NombrePersona"]').text('Campo Requerido');
                                $("#txtNombrePersona").focus();

                                return false;
                            }
                        };

                        if (_opcionSeleccionada == 2) {
                            if ($("#txtNombreEmpresa").val().trim() == "") {
                                $('span[data-valmsg-for="NombreEmpresa"]').text('Campo Requerido');
                                $("#EmpresaId").focus();

                                return false;
                            }
                        };
                    }

                    if (index == 2) {
                        var _data = $('#dgDatosVentaDetalle').bootstrapTable('getData');
                        if (_data.length == 0) {
                            $('span[data-valmsg-for="DatosVentaDetalle"]').text('Debe seleccionar los artículos a cotizar');

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

        if (this.evento == 'VENTA_DELETE') {
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
    cargaDatos:                     function () {
        var objJSON = {
            pVentaId:          $('#txtVentaId').val(),
            pVentaDescripcion: '',
            pEstatusId:        -1
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Venta + 'VentaElementoJson',
            json
        );

        if (res != null) {
            $("#txtVentaDescripcion").val(res.data.Datos[0].VentaDescripcion);
            $("#dtpFecha").val(formatFecha(res.data.Datos[0].Fecha));

            if (res.data.Datos[0].VentaTipoId == 1) {
                $("input[name=rbVentaTipoId][value=1]").prop('checked', true).iCheck('update');

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

            if (res.data.Datos[0].VentaTipoId == 2) {
                $("input[name=rbVentaTipoId][value=2]").prop('checked', true).iCheck('update');

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

            $("#txtTotalVenta").val(priceFormatter(res.data.Datos[0].Total));

            if (res.data.Datos[0].VentaEstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');

            var objJSON_Detalle = {
                pVentaDetalleId: 0,
                pVentaId:        $('#txtVentaId').val(),
                pEstatusId:      1
            };

            var json_Detalle = JSON.stringify(objJSON_Detalle, null, 2);

            var res_Detalle = getJSON(
                URL.VentaDetalle + 'VentaDetalleConPrecioGridJson',
                json_Detalle
            );

            if (res_Detalle != null) {
                if (this.evento == 'VENTA_EDIT') {
                    this.tablaDetalle.inicializa();
                };

                if (this.evento == 'VENTA_DELETE') {
                    this.tablaDetalleDetalle.inicializa();
                };

                _listDetalle = res_Detalle.data.Datos;
                $('#dgDatosVentaDetalle').bootstrapTable("load", _listDetalle);

                $.each(res_Detalle.data.Datos, function (index, value) {
                    _SubTotal  = _SubTotal + value.SubTotal;
                    _Descuento = 0;
                    _Iva = _Iva + value.Iva;

                    if (value.ServicioId == 9) {
                        _listProcedimientoDetalle = ObtieneVentaProcedimientoDetalle(value.VentaDetalleId);
                    };
                });

                $("#txtSubTotal").val(priceFormatter(_SubTotal));
                $("#txDescuento").val(priceFormatter(_Descuento));
                $("#txtIva").val(priceFormatter(_Iva));
                $("#txtTotal").val(priceFormatter(res.data.Datos[0].Total));
                $("#txtTotalVenta").val(priceFormatter(res.data.Datos[0].Total));
            };
        }
    },
    guardar:                        function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            VentaId:           0,
            CotizacionId:      $("#txtCoticacionId").val(),
            VentaDescripcion:  "",
            Fecha:             null,
            VentaTipoId:       -1,
            PersonaId:         -1,
            EmpresaId:         -1,
            SubTotal:          0,
            Descuento:         0,
            CampaniaId:        -1,
            Iva:               0,
            Total:             0,
            Anticipo:          0,
            EmpresaNombre:     ''
        };

        var _opcionSeleccionada = $('#rbVentaTipoId:checked').val();
        if (_opcionSeleccionada == 1) {
            _obj.PersonaId = $("#txtPersonaId").val();
        };

        if (_opcionSeleccionada == 2) {
            _obj.EmpresaId = $("#txtEmpresaId").val();
        };

        _obj.VentaDescripcion  = $("#txtVentaDescripcion").val();
        _obj.Fecha             = $("#dtpFecha").val();
        _obj.VentaTipoId       = $("input[name='rbVentaTipoId']:checked").val();
        _obj.SubTotal          = parseFloat(numberNotCommas($("#txtSubTotal").val()));
        _obj.Descuento         = parseFloat(numberNotCommas($("#txtDescuento").val()));
        _obj.CampaniaId        = 0;
        _obj.Iva               = parseFloat(numberNotCommas($("#txtIva").val()));
        _obj.Total             = parseFloat(numberNotCommas($("#txtTotal").val()));
        _obj.Anticipo          = parseFloat(numberNotCommas($("#txtAnticipo").val()));
        _obj.Referencia        = $("#txtReferencia").val();
		
        var _data = $('#dgDatosVentaDetalle').bootstrapTable('getData', false);
        var _dataDetalle = [];
        var item = {};
        
        $.each(_listProcedimientoDetalle, function (index, value) {
            item = {
                VentaProcedimientoDetalleId:      0,
                VentaDetalleId:                   0,
                VentaId:                          0,
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
                Anticipo:                         value.Anticipo,
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
            URL.Venta + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Venta.redirecciona('VENTA_INDEX', $('#txtOpcion').val()); }, 2000);
                else
                    this.redirecciona('VENTA_INDEX', $('#txtOpcion').val());
    },
    actualizar:                     function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            VentaId:          $("#txtVentaId").val(),
            VentaDescripcion: $("#txtVentaDescripcion").val(),
            Baja:             ($("input[name='rbEstatusId'][value=0]:checked").val() ? false : true)
        };

        var _data = $('#dgDatosVentaDetalle').bootstrapTable('getData', false);

        var objJSON = {
            model:        _obj,
            modelDetalle: _data
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Venta + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Venta.redirecciona('VENTA_INDEX', $('#txtOpcion').val()); }, 2000);
                else
                    this.redirecciona('VENTA_INDEX', $('#txtOpcion').val());
    },
    actualizarProcedimientoDetalle: function () {
        var _dataProcedimeinto = [];
        var item = {};

        $.each(_listProcedimientoDetalle, function (index, value) {
            item = {
                VentaProcedimientoDetalleId: value.VEntaProcedimientoDetalleId,
                Cantidad:                    value.Cantidad,
                CantidadOriginal:            value.CantidadOriginal,
                CantidadBase:                value.CantidadBase,
                Costo:                       value.Costo,
                Precio:                      value.Precio,
                Iva:                         value.Iva,
                SubTotal:                    value.SubTotal,
                Seleccionado:                value.Seleccionado,
            };

            _dataProcedimeinto.push(item);
        });

        var objJSON = {
            model: _dataProcedimeinto
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.VentaProcedimientoDetalle + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { $(location).attr('href', URL.Venta + 'Edit?pVentaId=' + $("#txtVentaId").val()) }, 2000);
        //else
        //    this.redirecciona('COTIZACION_INDEX');
    },
    baja:                           function () {
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
                    VentaId: $("#txtVentaId").val()
                };

                var objJSON = {
                    model: _obj
                };

                var json = JSON.stringify(objJSON, null, 2);

                var res = getJSON(
                    URL.Venta + 'Delete',
                    json
                );

                if (res != null)
                    if (!res.data.Error)
                        if (res.data.MuestraAlert)
                            setTimeout(function () { Venta.redirecciona('VENTA_INDEX'); }, 2000);
                        else
                            this.redirecciona('VENTA_INDEX');
            }
            else {
                swal.close();
            }
        });
    },
    cancelar:                       function () {
        if (!this.validaCancelar()) return;

        swal({
            title:              "¿Estás seguro de cancelar la venta?",
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
                    pVentaId:                      $("#txtDelete_VentaId").val(),
                    pVentaMotivoCancelacionTipoId: $("#dllVentaMotivoCancelacionTipoId").val(),
                    pComentario:                   $("#txtComectarioCancelacion").val()
                };

                var json = JSON.stringify(objJSON, null, 2);

                var res = getJSON(
                    URL.Venta + 'Delete',
                    json
                );

                if (res != null)
                    if (!res.data.Error)
                        if (res.data.MuestraAlert)
                            setTimeout(function () { Venta.redirecciona('VENTA_INDEX', $('#txtOpcion').val()); }, 2000);
                        else
                            this.redirecciona('VENTA_INDEX', $('#txtOpcion').val());
            }
            else {
                swal.close();
            }
        });
    },
    keyEvent:                       function () {
        $("#txtVentaDescripcion").on("change paste keyup", function () {
            if ($("#txtVentaDescripcion").val().trim() == "")
                $('span[data-valmsg-for="VentaDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="VentaDescripcion"]').text('');
        });

        $("#dtpFecha").on("change paste keyup", function () {
            if ($("#dtpFecha").val().trim() == "")
                $('span[data-valmsg-for="Fecha"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Fecha"]').text('');
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

        $("input:radio[name='rbVentaTipoId']").on('ifChecked', function (event) {
            // PERSONA EXISTENTE
            if (this.value == 1) {
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

            // CONVENIO
            if (this.value == 2) {
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
    keyEventIndex:                  function () {
        $("input:radio[name='rbVentaTipoId']").on('ifChecked', function (event) {
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

        $('#dgDatosVenta').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosVenta tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });

        $('#dllVentaMotivoCancelacionTipoId').change(function () {
            if ($('#dllVentaMotivoCancelacionTipoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="VentaMotivoCancelacionTipoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="VentaMotivoCancelacionTipoId"]').text('');
            };
        });

        $("#txtComectarioCancelacion").on("change paste keyup", function () {
            if ($("#txtComectarioCancelacion").val().trim() == "")
                $('span[data-valmsg-for="ComectarioCancelacion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ComectarioCancelacion"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosVenta').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'VentaId',
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
                        field:     'VentaDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'VentaTipoDescripcion',
                        title:     'Tipo',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'NumSocio',
                        title:     'Num Socio',
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
                        field:     'Anticipo',
                        title:     'Anticipo ($)',
                        sortable:  true,
                        formatter: 'priceFormatter',
                        align:     'right'
                    },
                    {
                        field:     'VentaEstatusId',
                        title:     'Estatus',
                        sortable:  false,
                        formatter: 'VentaEstatusIdFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'Venta_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pVentaDescripcion: $('#txtVentaDescripcion').val(),
                pFechaInicio:      $('#dtpFechaInicial').val(),
                pFechaFin:         $('#dtpFechaFinal').val(),
                pVentaTipoId:      $('#rbVentaTipoId:checked').val(),
                pEstatusId:        $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Venta + 'VentaGridJson',
                json
            );

            $('#dgDatosVenta').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<a class="detailVenta" href="javascript:void(0)" title="Detalle">',
                    '<i class="text-info fa fa-search fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeVenta" href="javascript:void(0)" title="Cancelar Venta">',
                    '<i class="text-danger fa fa-trash fa-2x"></i>',
                '</a>'
                //'<a class="liveLineVenta" href="javascript:void(0)" title="Línea de Vida">',
                //'<i class="text-primary2 fa fa-info-circle fa-2x"></i>',
                //'</a>'
            ].join('');
        }
    },
    tablaDetalle: {
        inicializa:    function () {
            $('#dgDatosVentaDetalle .editable').editable('toggleDisabled');
            $.fn.editable.defaults.mode = 'inline';

            $('#dgDatosVentaDetalle').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'VentaDetalleId',
                        title:     'VentaDetalleId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'VentaId',
                        title:     'Folio',
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
                        field:     'Referencia',
                        title:     'Referencia',
                        sortable:  true,
                        editable: {
                            type:  'text',
                            title: 'Debe teclear una referencia'
                        },
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
                        field:     'Anticipo',
                        title:     'Anticipo ($)',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
                        visible:   false
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        formatter: this.accionDetalle(),
                        events:    'VentaDetalle_ActionEvents',
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
            $('#dgDatosVentaDetalle').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'VentaDetalleId',
                        title:     'VentaDetalleId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'VentaId',
                        title:     'VentaId',
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
    buscar:                         function () {
        //if (!this.validaBusqueda()) return;

        this.tabla.datos();
    },
    validaBusqueda:                 function () {
        if ($("#txtVentaDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="VentaDescripcion"]').text('Campo Requerido');
            $("#txtVentaDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:                  function () {
        if ($("#txtVentaDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="VentaDescripcion"]').text('Campo Requerido');
            $("#txtVentaDescripcion").focus();

            $('#rootwizard').find("a[href*='tab1']").trigger('click');

            return false;
        }

        if ($("#dtpFecha").val().trim() == "") {
            $('span[data-valmsg-for="Fecha"]').text('Campo Requerido');
            $("#dtpFecha").focus();

            $('#rootwizard').find("a[href*='tab1']").trigger('click');

            return false;
        }

        var _opcionSeleccionada = $('#rbVentaTipoId:checked').val();
        if (_opcionSeleccionada == 1) {
            if ($("#txtNombrePersona").val().trim() == "") {
                $('span[data-valmsg-for="NombrePersona"]').text('Campo Requerido');
                $("#txtNombrePersona").focus();

                return false;
            }
        };

        if (_opcionSeleccionada == 2) {
            if ($("#txtNombreEmpresa").val().trim() == "") {
                $('span[data-valmsg-for="NombreEmpresa"]').text('Campo Requerido');
                $("#txtNombreEmpresa").focus();

                return false;
            }
        };

        var _text = $('#dgDatosVentaDetalle').bootstrapTable('getData');
        if (_text.length == 0) {
            swal({
                title: "Debe seleccionar al menos un artículo",
                text:  "",
                type:  "warning"
            });

            return false;
        }

        var _data = $('#dgDatosVentaDetalle').bootstrapTable('getData');

        /* VALIDA MEMBRESIA 1RA VEZ */
        var _membresia1raVez = false;
        $.each(_data, function (index, value) {
            if (value.ServicioId == 7) {
                var _servicioAdministrativoId = value.ItemId;

                if (_servicioAdministrativoId == 1) {
                    _membresia1raVez = true;
                }
            }
        });

        if (_membresia1raVez == true && $("#txtReferencia").val() == '') {
            swal({
                title: "Debe de teclear un nombre para la membresia",
                text: "",
                type: "warning"
            });

            $('span[data-valmsg-for="Referencia"]').text('Campo Requerido');
            $("#txtReferencia").focus();

            return false;
        }
        /* VALIDA MEMBRESIA 1RA VEZ */

        /* VALIDA MEMBRESIA ADICIONAL Y RENOVACION */
        var _adicionalSinReferencia  = false;
        var _renovacionSinReferencia = false;

        $.each(_data, function (index, value) {
            if (value.ServicioId == 7) {
                var _servicioAdministrativoId = value.ItemId;

                if (_servicioAdministrativoId == 2) {
                    if (value.Referencia == "") {
                        _adicionalSinReferencia = true;
                    }

                    if (value.Referencia == "CSN-AD") {
                        _adicionalSinReferencia = false;
                    }

                    if (parseInt(value.Referencia) <= 0) {
                        _adicionalSinReferencia = true;
                    }
                }

                if (_servicioAdministrativoId == 3) {
                    if (value.Referencia == "") {
                        _renovacionSinReferencia = true;
                    }

                    if (value.Referencia == "CSN-AD") {
                        _renovacionSinReferencia = false;
                    }

                    if (parseInt(value.Referencia) <= 0) {
                        _renovacionSinReferencia = true;
                    }
                }
            }
        });

        if (_adicionalSinReferencia == true) {
            swal({
                title: "Debe de teclear una referencia para la membresia adicional",
                text: "",
                type: "warning"
            });

            return false;
        }

        if (_renovacionSinReferencia == true) {
            swal({
                title: "Debe de teclear un nombre para la renovacion de membresia",
                text: "",
                type: "warning"
            });

            return false;
        }
        /* VALIDA MEMBRESIA ADICIONAL Y RENOVACION */

        /* VALIDA ADICIONAL SIN principal */
        /* VALIDA ADICIONAL SIN principal */

        return true;
    },
    validaCancelar: function () {
        if ($('#dllVentaMotivoCancelacionTipoId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="VentaMotivoCancelacionTipoId"]').text('Campo Requerido');

            $("#dllVentaMotivoCancelacionTipoId").focus();

            return false;
        };

        if ($("#txtComectarioCancelacion").val().trim() == "") {
            $('span[data-valmsg-for="ComectarioCancelacion"]').text('Campo Requerido');
            $("#txtComectarioCancelacion").focus();

            return false;
        }

        return true;
    },
    limpiar:                        function () {
        this.inicializa('VENTA_INDEX');
    },
    redirecciona:                   function (evento, pOpcion) {
        if (evento == 'VENTA_INDEX') {
            $(location).attr('href', URL.Venta + 'Index?pOpcion=' + pOpcion);
        };

        if (evento == 'VENTA_CREATE') {
            $(location).attr('href', URL.Venta + 'Create?pOpcion=' + pOpcion);
        };
    },
    limpiarCtrls:                   function () {
        $('#txtVentaDescripcion').val('');
        
        $('span[data-valmsg-for="VentaDescripcion"]').text('');
		
        $('#dtpFechaInicio').val('');
		$('#dtpFechaFin').val('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=3]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=4]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');

        $("input[name=rbVentaTipoId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbVentaTipoId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbVentaTipoId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls:       function (estatus) {
        $("#txtVentaDescripcion").prop("readonly", estatus);
    },
    AbreModalArticulo:              function () {
        $("#myModalBusquedaServicio").modal();

        var pFiltro = ""

        if ($("#txtOpcion").val() == "1")
            pFiltro = "PAQUETE";

        if ($("#txtOpcion").val() == "2")
            pFiltro = "SERVICIOS";

        if ($("#txtOpcion").val() == "3")
            pFiltro = "PROCEDIMIENTOS";

        if ($("#txtOpcion").val() == "4")
            pFiltro = "ADMINISTRATIVOS";


        Servicio.llenaCombo("ddlCtrlUserBusquedaServicioId", "SELECCIONE", pFiltro);


        if ($("#txtOpcion").val() == "1")
            $('#ddlCtrlUserBusquedaServicioId').val('1');

        if ($("#txtOpcion").val() == "2")
            $('#ddlCtrlUserBusquedaServicioId').val('2');

        if ($("#txtOpcion").val() == "3")
            $('#ddlCtrlUserBusquedaServicioId').val('9');

        if ($("#txtOpcion").val() == "4")
            $('#ddlCtrlUserBusquedaServicioId').val('7');
        $("#txtCtrlUserBusquedaServicioDescripcion").val("");


        $('#dgDatosBusquedaServicio').bootstrapTable('removeAll');

        CtrlUserBusquedaServicio.inicializa("CTRL_USER_BUSQUEDA_SERVICIO_INDEX");
    },
    AgregarItem:                    function () {
        var data        = $('#dgDatosBusquedaServicio').bootstrapTable('getSelections');
        var dataDetalle = $('#dgDatosVentaDetalle').bootstrapTable('getData');;

        if (data.length == 0) {
            swal("Debe seleccionar al menos un artículo", "", "warning");

            return;
        }

        if (ValidaPrecioCero(data)) return false;

        if (ValidaDuplicados(dataDetalle, data)) return false;

        if (ValidaSoloProcedimiento(dataDetalle, data)) return false;

        var item  = {};

        $('span[data-valmsg-for="DatosCotizacionDetalle"]').text('');
        
        $.each(data, function (index, value) {
            if (value.ServicioId == 9) {
                _listProcedimientoDetalle = ObtieneProcedimientoDetalle(value.ItemId);
            }

            var _referencia = "";

            if (value.ServicioId == 7 && value.ItemId == 2) {
                _referencia = "CSN-AD";
            }

            if (value.ServicioId == 7 && value.ItemId == 3) {
                _referencia = "CSN-RE";
            }

            item = {
                VentaDetalleId:      0,
                VentaId:             0,
                AreaNegocioId:       value.AreaNegocioId,
                ServicioId:          value.ServicioId,
                ItemId:              value.ItemId,
                ItemDescripcion:     value.ItemDescripcion,
                ItemTipoId:          value.ItemTipoId,
                ItemTipoDescripcion: value.ItemTipoDescripcion,
                Referencia:          _referencia,
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
                Anticipo:            value.Anticipo,
                Amparada:            value.Amparada
            }

            _listDetalle.push(item);

            _SubTotal = _SubTotal + item.SubTotal;
            _Iva      = _Iva + item.Iva;
            _Total    = _Total + item.SubTotalConIva;
            _Anticipo = _Anticipo + item.Anticipo;
        });

        $('#dgDatosVentaDetalle').bootstrapTable("load", _listDetalle);
		
        $("#txtSubTotal").val(priceFormatter(_SubTotal));
        $("#txDescuento").val(priceFormatter(_Descuento));
        $("#txtIva").val(priceFormatter(_Iva));
        $("#txtAnticipo").val(priceFormatter(_Anticipo));
        $("#txtAnticipoVenta").val(priceFormatter(_Anticipo));
        $("#txtTotal").val(priceFormatter(_Total));
        $("#txtTotalVenta").val(priceFormatter(_Total));

        swal({
            title: "El item seleccionado ha sido agregado",
            text: "",
            type: "success",
            timer: 800
        });

        $("#txtCtrlUserBusquedaServicioDescripcion").val("");
        //$("#ddlCtrlUserBusquedaServicioId").val(0);
        $('#dgDatosBusquedaServicio').bootstrapTable('removeAll');
    },
    AbreModalPersona:               function () {
        $("#myModalBusquedaPersona").modal();

        $("#txtPersonaId").val("");
        $("#txtNombrePersona").val("");

        $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('removeAll');

        CtrlUserBusquedaPersona.baja = 0;
        if ($("#txtOpcion").val() == "4")
            CtrlUserBusquedaPersona.bajaAsociado = null;
        else
            CtrlUserBusquedaPersona.bajaAsociado = 0;
        CtrlUserBusquedaPersona.inicializa("CTRL_USER_BUSQUEDA_PERSONA_INDEX");
    },
    AgregarPersona:                 function () {
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
    AbreModalEmpresa:               function () {
        $("#myModalBusquedaEmpresa").modal();

        $("#txtEmpresaId").val("");
        $("#txtNombreEmpresa").val("");

        $('#dgDatosCtrlUserBusquedaEmpresa').bootstrapTable('removeAll');

        CtrlUserBusquedaEmpresa.inicializa("CTRL_USER_BUSQUEDA_EMPRESA_INDEX");
    },
    AgregarEmpresa:                 function () {
        var data = $('#dgDatosCtrlUserBusquedaEmpresa').bootstrapTable('getSelections');

        if ((data.length >= 2) || (data.length == 0)) {
            swal("Debe seleccionar una empresa", "", "warning");

            return;
        }

        $("#txtEmpresaId").val(data[0].EmpresaId);
        $("#txtNombreEmpresa").val(data[0].EmpresaDescripcion);

        $("#myModalBusquedaEmpresa").modal("toggle");
    },
    AbreModalCotizacion:            function () {
        $("#myModalImportarCotizacion").modal();

        $('#dgCtrlUserViewDatosCotizacion').bootstrapTable('removeAll');

        CtrlUserCotizacion.inicializa('CTRL_USER_BUSQUEDA_COTIZACION_INDEX');
    },
    AgregarCotizacion:              function () {
        var _data = $('#dgCtrlUserViewDatosCotizacion').bootstrapTable('getSelections');

        if (_data.length == 0) {
            swal("Debe seleccionar una cotización", "", "warning");

            return;
        }

        if (_data.length > 1) {
            swal("Solo puede seleccionar una cotizació", "", "warning");

            return;
        }

        $("#txtCoticacionId").val(_data[0].CotizacionId);
        $("#dtpFecha").val(_data[0].Fecha);
        $("#txtVentaDescripcion").val(_data[0].CotizacionDescripcion);

        if ($("input[name='rbVentaTipoId'][value=1]:checked").val() == 1) {
            if (_data[0].PersonaId > -1) {
                $("#txtPersonaId").val(_data[0].PersonaId);
                $("#txtNombrePersona").val(_data[0].PersonaNombre);
            };
        }
        else {
            if (_data[0].EmpresaId > -1) {
                $("#txtEmpresaId").val(_data[0].EmpresaId);
                $("#txtNombreEmpresa").val(_data[0].EmpresaNombre);
            };
        };

        var objJSON_Detalle = {
            pCotizacionDetalleId: 0,
            pCotizacionId:        _data[0].CotizacionId,
            pEstatusId:           1
        };

        var json_Detalle = JSON.stringify(objJSON_Detalle, null, 2);

        var res_Detalle = getJSON(
            URL.CotizacionDetalle + 'CotizacionDetalleConPrecioGridJson',
            json_Detalle
        );

        if (res_Detalle != null) {
            this.tablaDetalle.inicializa();
            
            _listDetalle = res_Detalle.data.Datos;
            $('#dgDatosVentaDetalle').bootstrapTable("load", res_Detalle.data.Datos);

            $.each(res_Detalle.data.Datos, function (index, value) {
                _SubTotal  = _SubTotal + value.SubTotal;
                _Descuento = 0;
                _Iva       = _Iva + value.Iva;

                if (value.ServicioId == 9) {
                    _listProcedimientoDetalle = ObtieneCotizacionProcedimientoDetalle(value.CotizacionDetalleId);
                };
            });
        };

        CalculaTotal();

        $("#myModalImportarCotizacion").modal("toggle");
    },
    AbreModalProcedimientoDetalle:  function (procedimeintoId, procedimientoDetalle, data) {
        $("#myModalProcedimientoDetalle").modal();

        $('#dgDatosVentaProcedimientoDetalle').bootstrapTable('removeAll');

        if (this.evento == 'VENTA_CREATE')
            CtrlUserVentaProcedimientoDetalle.inicializa('CTRL_USER_VENTA_PROCEDIMIENTO_DETALLE_INDEX', procedimeintoId, procedimientoDetalle, data);

        if (this.evento == 'VENTA_EDIT')
            CtrlUserVentaProcedimientoDetalle.inicializa('CTRL_USER_VENTA_PROCEDIMIENTO_DETALLE_EDIT', procedimeintoId, procedimientoDetalle, data);
    },
    ActualizaProcedimientoDetalle:  function () {
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

        $('#dgDatosVentaDetalle').bootstrapTable("load", _listDetalle);

        $("#myModalProcedimientoDetalle").modal("toggle");
    }
};




function ValidaSoloProcedimiento(dataDetalle, dataModal) {
    var existeProcedimiento = false;
    var existeOtroServicio  = false;

    if (dataDetalle.length >= 1)
    {
        jQuery.each(dataDetalle, function (index, value) {
            if (!existeProcedimiento) {
                if (value.ServicioId == 9) {
                    existeProcedimiento = true;

                    swal("Por efecto de anticipo no se puede agregar mas item a un procedimiento seleccionado", "", "warning");
                }
                else {
                    existeOtroServicio = true;
                };
            };
        });

        jQuery.each(dataModal, function (index, value) {
            if (!existeProcedimiento) {
                if (value.ServicioId == 9) {
                    existeProcedimiento = true;

                    swal("Por efecto de anticipo no se puede agregar un procedimiento si ya existe items seleccionado", "", "warning");
                }
                else {
                    existeOtroServicio = true;
                };
            };
        });
        if (!existeProcedimiento && existeOtroServicio) {

        };
    }

    return existeProcedimiento;
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




function ObtieneVentaProcedimientoDetalle(ventaDetalleId) {
    var objJSON = {
        pVentaDetalleId: ventaDetalleId,
        pVentaId:        0,
        pEstatusId:           1
    };

    var json = JSON.stringify(objJSON, null, 2);

    var res = getJSON(
        URL.VentaProcedimientoDetalle + 'VentaProcedimientoDetalleGridConPrecioJson',
        json
    );

    var _array = [];
    var item   = {};

    $.each(res.data.Datos, function (index, value) {
        item = {
            VentaProcedimientoDetalleId:     value.VentaProcedimientoDetalleId,
            VentaDetalleId:                  value.VentaDetalleId,
            VentaId:                         value.VentaId,
            ProcedimientoDetalleId:          value.ProcedimientoDetalleId,
            ProcedimientoId:                 value.ProcedimientoId,
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
            Seleccionado:                    value.Seleccionado
        };

        _array.push(item);
    });

    return _array;
};


//function ObtieneVentaProcedimientoDetalle(cotizacionDetalleId) {
//    var objJSON = {
//        pCotizacionDetalleId: cotizacionDetalleId,
//        pCotizacionId: 0,
//        pEstatusId: 1
//    };

//    var json = JSON.stringify(objJSON, null, 2);

//    var res = getJSON(
//        URL.VentaProcedimientoDetalle + 'VentaProcedimientoDetalleGridConPrecioJson',
//        json
//    );

//    var _array = [];
//    var item = {};

//    $.each(res.data.Datos, function (index, value) {
//        item = {
//            VentaProcedimientoDetalleId:     value.VentaProcedimientoDetalleId,
//            VentaDetalleId:                  value.VentaDetalleId,
//            VentaId:                         value.VentaId,
//            ProcedimientoDetalleId:          value.ProcedimientoDetalleId,
//            ProcedimientoId:                 value.ProcedimientoId,
//            ServicioId:                      value.ServicioId,
//            ServicioPartidaId:               value.ServicioPartidaId,
//            ProcedimientoDetalleDescripcion: value.ProcedimientoDetalleDescripcion,
//            Posicion:                        value.Posicion,
//            ClaseOperacion:                  value.ClaseOperacion,
//            ElementoId:                      value.ElementoId,
//            CantidadOriginal:                value.Cantidad,
//            Cantidad:                        value.Cantidad,
//            Unidad:                          value.Unidad,
//            CantidadBase:                    value.CantidadBase,
//            Descripción:                     value.Descripción,
//            Tarifa:                          value.Tarifa,
//            Costo:                           value.Costo,
//            Precio:                          value.Precio,
//            PrecioConIva:                    value.PrecioConIva,
//            Iva:                             value.Iva,
//            SubTotal:                        value.SubTotal,
//            SubTotalConIva:                  value.SubTotalConIva,
//            EstatusId:                       value.EstatusId,
//            Seleccionado:                    value.Seleccionado
//        };

//        _array.push(item);
//    });

//    return _array;
//};




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




function CalculaTotal() {
    var dataDatos = $('#dgDatosVentaDetalle').bootstrapTable('getData', false);

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

    $("#txtTotalVenta").val(priceFormatter(_SubTotalConIvaGrid));
}




function ValidaMembresia(data) {
    var _response = true;

    var _existeMembresia      = false;

    var _existeAdicional      = false;
    var _referenciaAdicional  = "";

    var _existeRenovacion     = false;
    var _referecniaRenovacion = "";

    jQuery.each(data, function (index, value) {
        if (value.ServicioId == 7) {
            if (value.ItemId == 1) {
                _existeMembresia = true;
            };

            if (value.ItemId == 2) {
                _existeAdicional     = true;
                _referenciaAdicional = value.Referencia;
            };

            if (value.ItemId == 3) {
                _existeRenovacion     = true;
                _referecniaRenovacion = value.Referencia;
            };
        };

        if (_existeMembresia == false && _existeAdicional == true) {

            _response = false;
            swal("No se puede generar la venta de una membresia adicion sin la membresia principal", "", "warning");
        }
        //if (!existe) {
        //    if (value.Precio == 0) {
        //        existe = true;

        //        swal("No se puede agregar items com precio cero", "", "warning");
        //    }
        //}

        return _response;
    });
};




$('#dgDatosVentaDetalle').on('editable-save.bs.table', function (e, field, renglon, old, $el) {
    if (field == "Cantidad") {
        if (!Number(renglon.Cantidad))
            renglon.Cantidad = 1;
		
		if ((parseInt(renglon.Cantidad) <= 0) == true)
            renglon.Cantidad = 1;

        if (renglon.ServicioId == 9) {
            if (renglon.Cantidad > 1) {
                renglon.Cantidad = 1;

                swal({
                    title: "Por efecto de anticipo no se puede cotizar mas de un mismo procedimineto para una sola persona",
                    text:  "",
                    type:  "warning"
                });
            }
        }

        var $table = $('#dgDatosVentaDetalle');
        var $els = $table.find('a[data-name="Cantidad"].editable');

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




window.Venta_ActionEvents = {
    'click .editVenta': function (e, value, row, index) {
        if (row.EstatusId == 3) {
            swal('La venta ya fue procesada y no se puede editar.', '', 'info');
            
            return;
        };

        $(location).attr('href', URL.Venta + 'Edit?pVentaId=' + row.VentaId);
    },
    'click .detailVenta': function (e, value, row, index) {
        $("#txtModalVentaId").val(row.VentaId);

        VentaDetalleView.inicializa('VENTA_DETALLE_VIEW_INDEX');

        $("#myModalVentaDetalle").modal();
    },
    'click .removeVenta': function (e, value, row, index) {
        if (row.VentaEstatusId != 1) {
            swal('Atención', 'Solo ventas en estatus Pendiente de Pago se pueden cancelar.', 'warning');

            return;
        };

        //CtrlUserCancelarVenta.ventaId = row.VentaId;
        //CtrlUserCancelarVenta.ventaDescripcion = row.VentaDescripcion;
        //CtrlUserCancelarVenta.ventaNombre = row.PersonaNombre;
        //CtrlUserCancelarVenta.ventaTotal = row.Total;
        //CtrlUserCancelarVenta.inicializa('CTRL_USER_CANCELAR_VENTA_INDEX');
        $('#txtDelete_VentaId').val(row.VentaId);
        $('#txtDelete_VentaDescripcion').val(row.VentaDescripcion);
        $('#txtDelete_Nombre').val(row.PersonaNombre);
        $('#txtDelete_TotalVenta').val(row.Total);

        $("#myModalDeleteVenta").modal();
    },
    'click .liveLineVenta': function (e, value, row, index) {
        $("#myModalLineaVida").modal();
    }
};




window.VentaDetalle_ActionEvents = {
    'click .removeItem': function (e, value, row, index) {
        var $tableDetalle = $('#dgDatosVentaDetalle');

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

            Venta.AbreModalProcedimientoDetalle(row.ItemId, row.ItemDescripcion, _data);
        };
    }
};