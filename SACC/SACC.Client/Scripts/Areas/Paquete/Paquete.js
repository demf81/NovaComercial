$(function () {
    Paquete.inicializa($("#txtApuntadorPaquete").val());
});




var Paquete = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'PAQUETE_INDEX') {
            this.keyEventIndex();
            this.limpiarCtrls();

            PaqueteTipo.llenaCombo('ddlPaqueteTipoId', 'TODOS');

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'PAQUETE_CREATE') {
            this.keyEvent();

            PaqueteTipo.llenaCombo('ddlPaqueteTipoId', 'SELECCIONE');
            Genero.llenaCombo('ddlGeneroId', 'SELECCIONE');

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'PAQUETE_EDIT') {
            this.keyEvent();

            PaqueteTipo.llenaCombo('ddlPaqueteTipoId', 'SELECCIONE');
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

        if (this.evento == 'PAQUETE_DELETE') {
            PaqueteTipo.llenaCombo('ddlPaqueteTipoId', 'SELECCIONE');
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
            URL.Paquete + 'PaqueteElementoJson',
            json
        );

        if (res != null) {
            $("#txtCodigo").val(res.data.Datos[0].Codigo);
            $("#txtPaqueteDescripcion").val(res.data.Datos[0].PaqueteDescripcion);
            $("#ddlPaqueteTipoId").val(res.data.Datos[0].PaqueteTipoId);
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
            PaqueteId:          0,
            Codigo:             $("#txtCodigo").val().trim(),
            PaqueteDescripcion: $("#txtPaqueteDescripcion").val().trim(),
            PaqueteTipoId:      $("#ddlPaqueteTipoId").val(),
            GeneroId:           $("#ddlGeneroId").val(),
            EdadDesde:          $("#txtEdadDesde").val().trim(),
            EdadHasta:          $("#txtEdadHasta").val().trim(),
            PrecioLista:        $("#txtPrecioLista").val().trim(),
            PrecioVenta:        $("#txtPrecioVenta").val().trim(),
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Paquete + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Paquete.redirecciona('PAQUETE_INDEX'); }, 2000);
                else
                    this.redirecciona('PAQUETE_INDEX');
    },
    actualizar:               function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            PaqueteId:          $("#txtPaqueteId").val(),
            Codigo:             $("#txtCodigo").val().trim(),
            PaqueteDescripcion: $("#txtPaqueteDescripcion").val().trim(),
            PaqueteTipoId:      $("#ddlPaqueteTipoId").val(),
            GeneroId:           $("#ddlGeneroId").val(),
            EdadDesde:          $("#txtEdadDesde").val().trim(),
            EdadHasta:          $("#txtEdadHasta").val().trim(),
            PrecioLista:        $("#txtPrecioLista").val().trim(),
            PrecioVenta:        $("#txtPrecioVenta").val().trim(),
            EstatusId:          ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Paquete + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Paquete.redirecciona('PAQUETE_INDEX'); }, 2000);
                else
                    this.redirecciona('PAQUETE_INDEX');
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
                        PaqueteId: $("#txtPaqueteId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Paquete + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Paquete.redirecciona('PAQUETE_INDEX'); }, 2000);
                            else
                                this.redirecciona('PAQUETE_INDEX');
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

        $('#ddlPaqueteTipoId').change(function () {
            if ($('#ddlPaqueteTipoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="PaqueteTipoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="PaqueteTipoId"]').text('');
            };
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

        $("#txtPrecioLista").on("change paste keyup", function () {
            if ($("#txtPrecioLista").val().trim() == "")
                $('span[data-valmsg-for="PrecioLista"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="PrecioLista"]').text('');
        });

        $("#txtPrecioLista").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });

        $("#txtPrecioVenta").on("change paste keyup", function () {
            if ($("#txtPrecioVenta").val().trim() == "")
                $('span[data-valmsg-for="PrecioVenta"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="PrecioVenta"]').text('');
        });

        $("#txtPrecioVenta").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });
    },
    keyEventIndex:             function () {
        $('#dgDatosPaquete').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosPaquete tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    llenaCombo:               function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.Paquete + "PaqueteComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosPaquete').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:    'PaqueteId',
                        title:    'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'Codigo',
                        title:     'Código',
                        sortable:  true,
                        align:     'left'
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
                        field:    'PaqueteTipoDescripcion',
                        title:    'Tipo de Paquete',
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
                        events:    'Paquete_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pPaqueteDescripcion: $('#txtPaqueteDescripcion').val().trim(),
                pPaqueteTipoId:      $('#ddlPaqueteTipoId').val(),
                pEstatusId:          $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Paquete + 'PaqueteGridJson',
                json
            );

            $('#dgDatosPaquete').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<div class="btn-group">',
                    '<button data-toggle="dropdown" class="btn btn-default btn-sm dropdown-toggle" aria-expanded="false">',
                        '<span><i class="fa fa-ellipsis-h"></i></span>',
                    '</button>',
                    '<ul class="dropdown-menu pull-right">',
                        '<li>',
                            '<a class="editPaquete" href="javascript:void(0)">',
                                '<i class="text-success fa fa-pencil fa-2x"></i>&nbsp;&nbsp; Editar',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="paqueteDetalle" href="javascript:void(0)">',
                                '<i class="text-warning fa fa-cog fa-2x"></i>&nbsp;&nbsp; Configuración',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="removePaquete" href="javascript:void(0)">',
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
            $('span[data-valmsg-for="PaqueteDescripcion"]').text('Campo Requerido');
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

        if ($('#ddlPaqueteTipoId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="PaqueteTipoId"]').text('Campo Requerido');
            $("#ddlPaqueteTipoId").focus();

            return false;
        };

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

        if ($("#txtPrecioLista").val().trim() == "") {
            $('span[data-valmsg-for="PrecioLista"]').text('Campo Requerido');
            $("#txtPrecioLista").focus();

            return false;
        };

        $("#txtPrecioLista").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });

        if ($("#txtPrecioVenta").val().trim() == "") {
            $('span[data-valmsg-for="PrecioVenta"]').text('Campo Requerido');
            $("#txtPrecioVenta").focus();

            return false;
        };

        $("#txtPrecioLista").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });

        return true;
    },
    limpiar:                  function () {
        this.inicializa('PAQUETE_INDEX');
    },
    redirecciona:             function (evento) {
        if (evento == 'PAQUETE_INDEX') {
            $(location).attr('href', URL.Paquete);
        };

        if (evento == 'PAQUETE_CREATE') {
            $(location).attr('href', URL.Paquete + 'Create');
        };
    },
    limpiarCtrls:             function () {
        $('#txtPaqueteDescripcion').val('');

        $('span[data-valmsg-for="PaqueteDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtCodigo',             isDisabled);
        DisabledEneableElement('txtPaqueteDescripcion', isDisabled);
        DisabledEneableElement('ddlPaqueteTipoId',      isDisabled);
        DisabledEneableElement('ddlGeneroId',           isDisabled);
        DisabledEneableElement('txtEdadDesde',          isDisabled);
        DisabledEneableElement('txtEdadHasta',          isDisabled);
        DisabledEneableElement('txtPrecioLista',        isDisabled);
        DisabledEneableElement('txtPrecioVenta',        isDisabled);
    }
};




window.Paquete_ActionEvents = {
    'click .editPaquete':    function (e, value, row, index) {
        $(location).attr('href', URL.Paquete + 'Edit?pPaqueteId=' + row.PaqueteId);
    },
    'click .paqueteDetalle': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.PaqueteDetalle + 'Index?pPaqueteId=' + row.PaqueteId + '&pPaqueteDescripcion=' + row.PaqueteDescripcion + '&pPestaniaActiva=SERVICIOS_MEDICOS');
    },
    'click .removePaquete':  function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Paquete + 'Delete?pPaqueteId=' + row.PaqueteId);
    }
};