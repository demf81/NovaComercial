$(function () {
    AreaNegocio.inicializa($("#txtApuntadorAreaNegocio").val());
});




var AreaNegocio = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'AREA_NEGOCIO_INDEX') {
            this.limpiarCtrls();
            this.keyEventIndex();

            this.tabla.inicializa();
            this.tabla.datos();

            //$("[name='checkbox']").bootstrapSwitch({
            //    on:       'SI',
            //    off:      'NO',
            //    onClass:  'success',
            //    offClass: 'danger',
            //    size:     'xs'
            //});
        };

        if (this.evento == 'AREA_NEGOCIO_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'AREA_NEGOCIO_EDIT') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'AREA_NEGOCIO_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:               function () {
        var objJSON = {
            pAreaNegocioId: $('#txtAreaNegocioId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.AreaNegocio + 'AreaNegocioElementoJson',
            json
        );

        if (res != null) {
            $("#txtAreaNegocioDescripcion").val(res.data.Datos[0].AreaNegocioDescripcion);

            if (res.data.Datos[0].NivelAfectacion == 0)
                $("input[name=rbAfectacionId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbAfectacionId][value=2]").prop('checked', true).iCheck('update');

            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar:                  function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            AreaNegocioId:          0,
            AreaNegocioDescripcion: $("#txtAreaNegocioDescripcion").val(),
            NivelAfectacion:        ($("input[name='rbAfectacionId'][value=1]:checked").val() ? false : true),
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.AreaNegocio + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { AreaNegocio.redirecciona('AREA_NEGOCIO_INDEX'); }, 2000);
                else
                    this.redirecciona('AREA_NEGOCIO_INDEX');
    },
    actualizar:               function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            AreaNegocioId:          $("#txtAreaNegocioId").val(),
            AreaNegocioDescripcion: $("#txtAreaNegocioDescripcion").val(),
            NivelAfectacion:        ($("input[name='rbAfectacionId'][value=1]:checked").val() ? false : true),
            EstatusId:              ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.AreaNegocio + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { AreaNegocio.redirecciona('AREA_NEGOCIO_INDEX'); }, 2000);
                else
                    this.redirecciona('AREA_NEGOCIO_INDEX');
    },
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
                    AreaNegocioId: $("#txtAreaNegocioId").val()
                };

                var objJSON = {
                    model: _obj
                };

                var json = JSON.stringify(objJSON, null, 2);

                var res = getJSON(
                    URL.AreaNegocio + 'Delete',
                    json
                );

                if (res != null)
                    if (!res.data.Error)
                        if (res.data.MuestraAlert)
                            setTimeout(function () { AreaNegocio.redirecciona('AREA_NEGOCIO_INDEX'); }, 2000);
                        else
                            this.redirecciona('AREA_NEGOCIO_INDEX');
            }
            else {
                swal.close();
            }
        });
    },
    keyEvent:                 function () {
        $("#txtAreaNegocioDescripcion").on("change paste keyup", function () {
            if ($("#txtAreaNegocioDescripcion").val() == "")
                $('span[data-valmsg-for="AreaNegocioDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="AreaNegocioDescripcion"]').text('');
        });
    },
    keyEventIndex: function () {
        $('#dgDatosAreaNegocio').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosAreaNegocio tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
        });
    },
    llenaCombo:               function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.AreaNegocio + "AreaNegocioComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosAreaNegocio').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'AreaNegocioId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'AreaNegocioDescripcion',
                        title:     'Servicio de Convenio',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'NivelAfectacionDescripcion',
                        title:     'Nivel de Afectaci&oacute;n',
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
                        events:    'AreaNegocio_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pAreaNegocioDescripcion: $('#txtAreaNegocioDescripcion').val(),
                pEstatusId:              $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.AreaNegocio + 'AreaNegocioGridJson',
                json
            );

            $('#dgDatosAreaNegocio').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<div class="btn-group">',
                    '<button data-toggle="dropdown" class="btn btn-default btn-sm dropdown-toggle" aria-expanded="false">',
                        '<span><i class="fa fa-ellipsis-h"></i></span>',
                    '</button>',
                    '<ul class="dropdown-menu pull-right">',
                        '<li>',
                            '<a class="editAreaNegocio" href="javascript:void(0)">',
                                '<i class="text-success fa fa-pencil fa-2x"></i>&nbsp;&nbsp; Editar',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="removeAreaNegocio" href="javascript:void(0)">',
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

        this.tabla.datos();
    },
    validaBusqueda:           function () {
        if ($("#txtAreaNegocioDescripcion").val() == "") {
            $('span[data-valmsg-for="AreaNegocioDescripcion"]').text('Campo Requerido');
            $("#txtAreaNegocioDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:            function () {
        if ($("#txtAreaNegocioDescripcion").val() == "") {
            $('span[data-valmsg-for="AreaNegocioDescripcion"]').text('Campo Requerido');
            $("#txtAreaNegocioDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar:                  function () {
        this.inicializa('AREA_NEGOCIO_INDEX');
    },
    redirecciona:             function (evento) {
        if (evento == 'AREA_NEGOCIO_INDEX') {
            $(location).attr('href', URL.AreaNegocio);
        };

        if (evento == 'AREA_NEGOCIO_CREATE') {
            $(location).attr('href', URL.AreaNegocio + 'Create');
        };
    },
    limpiarCtrls:             function () {
        $('#txtAreaNegocioDescripcion').val('');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtAreaNegocioDescripcion', isDisabled);

        DisabledEneableElementCheck("input[name='rbAfectacionId']", isDisabled);
    }
};




window.AreaNegocio_ActionEvents = {
    'click .editAreaNegocio':   function (e, value, row, index) {
        $(location).attr('href', URL.AreaNegocio + 'Edit?pAreaNegocioId=' + row.AreaNegocioId);
    },
    'click .removeAreaNegocio': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.AreaNegocio + 'Delete?pAreaNegocioId=' + row.AreaNegocioId);
    }
};