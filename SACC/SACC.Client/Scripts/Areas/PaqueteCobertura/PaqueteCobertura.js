$(function () {
    PaqueteCobertura.inicializa($("#txtApuntadorPaqueteCobertura").val());
});




var PaqueteCobertura = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'PAQUETE_COBERTURA_INDEX') {
            this.keyEventIndex();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'PAQUETE_COBERTURA_CREATE') {
            this.keyEvent();

            Genero.llenaCombo('ddlGeneroId', 'SELECCIONE');

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'PAQUETE_COBERTURA_EDIT') {
            this.keyEvent();

            Genero.llenaCombo('ddlGeneroId', 'SELECCIONE');

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'PAQUETE_COBERTURA_DELETE') {
            Genero.llenaCombo('ddlGeneroId', 'SELECCIONE');

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:               function () {
        var objJSON = {
            pPaqueteId: $('#txtPaqueteId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.PaqueteCobertura + 'PaqueteCoberturaElementoJson',
            json
        );

        if (res != null) {
            $("#txtCodigo").val(res.data.Datos[0].Codigo);
            $("#txtPaqueteDescripcion").val(res.data.Datos[0].PaqueteDescripcion);
            $("#ddlGeneroId").val(res.data.Datos[0].GeneroId);
            $("#txtEdadDesde").val(res.data.Datos[0].EdadDesde);
            $("#txtEdadHasta").val(res.data.Datos[0].EdadHasta);
            $("#txtPrecioLista").val(res.data.Datos[0].PrecioLista);
            $("#txtPrecioVenta").val(res.data.Datos[0].PrecioVenta);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar:                  function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            PaqueteCoberturaId: 0,
            Codigo:             $("#txtCodigo").val().trim(),
            PaqueteDescripcion: $("#txtPaqueteDescripcion").val().trim(),
            PaqueteTipoId:      4,
            GeneroId:           $("#ddlGeneroId").val(),
            EdadDesde:          $("#txtEdadDesde").val().trim(),
            EdadHasta:          $("#txtEdadHasta").val().trim(),
            PrecioLista:        0,
            PrecioVenta:        0,
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.PaqueteCobertura + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { PaqueteCobertura.redirecciona('PAQUETE_COBERTURA_INDEX'); }, 2000);
                else
                    this.redirecciona('PAQUETE_COBERTURA_INDEX');
    },
    actualizar:               function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            PaqueteId:          $("#txtPaqueteId").val(),
            Codigo:             $("#txtCodigo").val().trim(),
            PaqueteDescripcion: $("#txtPaqueteDescripcion").val().trim(),
            PaqueteTipoId:      0,
            GeneroId:           $("#ddlGeneroId").val(),
            EdadDesde:          $("#txtEdadDesde").val().trim(),
            EdadHasta:          $("#txtEdadHasta").val().trim(),
            PrecioLista:        0,
            PrecioVenta:        0,
            EstatusId:          ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.PaqueteCobertura + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { PaqueteCobertura.redirecciona('PAQUETE_COBERTURA_INDEX'); }, 2000);
                else
                    this.redirecciona('PAQUETE_COBERTURA_INDEX');
    },
    //cambioEstatus: function () {

    //},
    baja:                     function () {
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
                        PaqueteCoberturaId: $("#txtPaqueteCoberturaId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.PaqueteCobertura + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { PaqueteCobertura.redirecciona('PAQUETE_COBERTURA_INDEX'); }, 2000);
                            else
                                this.redirecciona('PAQUETE_COBERTURA_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent:                 function () {
        $("#txtCodigo").on("change paste keyup", function () {
            if ($("#txtCodigo").val().trim() == "")
                $('span[data-valmsg-for="Codigo"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Codigo"]').text('');
        });

        $("#txtPaqueteDescripcion").on("change paste keyup", function () {
            if ($("#txtPaqueteDescripcion").val().trim() == "")
                $('span[data-valmsg-for="PaqueteDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="PaqueteDescripcion"]').text('');
        });

        $('#ddlGeneroId').change(function () {
            if ($('#ddlGeneroId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="GeneroId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="GeneroId"]').text('');
            };
        });

        $("#txtEdadDesde").on("change paste keyup", function () {
            if ($("#txtEdadDesde").val().trim() == "")
                $('span[data-valmsg-for="EdadDesde"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="EdadDesde"]').text('');
        });

        $("#txtEdadDesde").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });

        $("#txtEdadHasta").on("change paste keyup", function () {
            if ($("#txtEdadHasta").val().trim() == "")
                $('span[data-valmsg-for="EdadHasta"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="EdadHasta"]').text('');
        });

        $("#txtEdadHasta").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });
    },
    keyEventIndex:            function () {
        $('#dgDatosPaqueteCobertura').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosPaqueteCobertura tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosPaqueteCobertura').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'PaqueteId',
                        title:     'Folio',
                        sortable:  true,
                        align:    'center'
                    },
                    {
                        field:     'Codigo',
                        title:     'Código',
                        sortable:  true,
                        align:    'left'
                    },
                    {
                        field:     'PaqueteDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Genero',
                        title:     'Genero',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'RangoEdad',
                        title:     'Rango de Edad',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'PaqueteTipoDescripcion',
                        title:     'Tipo de Paquete',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'PrecioLista',
                        title:     'Precio de Lista',
                        sortable:  true,
                        align:     'right',
                        formatter: 'priceFormatter',
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
                        events:    'PaqueteCobertura_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pPaqueteDescripcion: $('#txtPaqueteDescripcion').val().trim(),
                pEstatusId:          $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.PaqueteCobertura + 'PaqueteCoberturaGridJson',
                json
            );

            $('#dgDatosPaqueteCobertura').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<div class="btn-group">',
                    '<button data-toggle="dropdown" class="btn btn-default btn-sm dropdown-toggle" aria-expanded="false">',
                        '<span><i class="fa fa-ellipsis-h"></i></span>',
                    '</button>',
                    '<ul class="dropdown-menu pull-right">',
                        '<li>',
                            '<a class="editPaqueteCobertura" href="javascript:void(0)">',
                                '<i class="text-success fa fa-pencil fa-2x"></i>&nbsp;&nbsp; Editar',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="paqueteCoberturaDetalle" href="javascript:void(0)">',
                                '<i class="text-warning fa fa-cog fa-2x"></i>&nbsp;&nbsp; Configuraci&oacute;n',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="removePaqueteCobertura" href="javascript:void(0)">',
                                '<i class="text-danger fa fa-trash fa-2x"></i>&nbsp;&nbsp; Eliminar',
                            '</a>',
                        '</li>',
                    '</ul >',
                '</div>'
            ].join('');
        }
    },
    buscar:                   function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda:           function () {
        if ($("#txtPaqueteDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="PaqueteCoberturaDescripcion"]').text('Campo Requerido');
            $("#txtPaqueteDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:            function () {
        if ($("#txtCodigo").val().trim() == "") {
            $('span[data-valmsg-for="Codigo"]').text('Campo Requerido');
            $("#txtCodigo").focus();

            return false;
        }

        if ($("#txtPaqueteDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="PaqueteDescripcion"]').text('Campo Requerido');
            $("#txtPaqueteDescripcion").focus();

            return false;
        }

        if ($('#ddlGeneroId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="GeneroId"]').text('Campo Requerido');
            $("#ddlGEneroId").focus();

            return false;
        };

        if ($("#txtEdadDesde").val().trim() == "") {
            $('span[data-valmsg-for="EdadDesde"]').text('Campo Requerido');
            $("#txtEdadDesde").focus();

            return false;
        }

        $("#txtEdadDesde").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });

        if ($("#txtEdadHasta").val().trim() == "") {
            $('span[data-valmsg-for="EdadHasta"]').text('Campo Requerido');
            $("#txtEdadHasta").focus();

            return false;
        }

        $("#txtEdadHasta").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });

        //if ($("#txtPrecioLista").val().trim() == "") {
        //    $('span[data-valmsg-for="PrecioLista"]').text('Campo Requerido');
        //    $("#txtPrecioLista").focus();

        //    return false;
        //};

        //$("#txtPrecioLista").keypress(function (e) {
        //    if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
        //        return false;
        //    }
        //});

        //if ($("#txtPrecioVenta").val().trim() == "") {
        //    $('span[data-valmsg-for="PrecioVenta"]').text('Campo Requerido');
        //    $("#txtPrecioVenta").focus();

        //    return false;
        //};

        //$("#txtPrecioLista").keypress(function (e) {
        //    if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
        //        return false;
        //    }
        //});

        return true;
    },
    limpiar:                  function () {
        this.inicializa('PAQUETE_COBERTURA_INDEX');
    },
    redirecciona:             function (evento) {
        if (evento == 'PAQUETE_COBERTURA_INDEX') {
            $(location).attr('href', URL.PaqueteCobertura);
        };

        if (evento == 'PAQUETE_COBERTURA_CREATE') {
            $(location).attr('href', URL.PaqueteCobertura + 'Create');
        };
    },
    limpiarCtrls:             function () {
        $('#txtPaqueteCoberturaDescripcion').val('');

        $('span[data-valmsg-for="PaqueteCoberturaDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtCodigo',             isDisabled);
        DisabledEneableElement('txtPaqueteDescripcion', isDisabled);
        DisabledEneableElement('ddlGeneroId',           isDisabled);
        DisabledEneableElement('txtEdadDesde',          isDisabled);
        DisabledEneableElement('txtEdadHasta',          isDisabled);
    }
};




window.PaqueteCobertura_ActionEvents = {
    'click .editPaqueteCobertura':    function (e, value, row, index) {
        $(location).attr('href', URL.PaqueteCobertura + 'Edit?pPaqueteId=' + row.PaqueteId);
    },
    'click .paqueteCoberturaDetalle': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.PaqueteCoberturaDetalle + 'Index?pPaqueteId=' + row.PaqueteId + '&pPaqueteDescripcion=' + row.PaqueteDescripcion);
    },
    'click .removePaqueteCobertura':  function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.PaqueteCobertura + 'Delete?pPaqueteId=' + row.PaqueteId);
    }
};