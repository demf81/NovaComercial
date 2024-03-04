$(function () {
    MembresiaTipo.inicializa($("#txtApuntadorMembresiaTipo").val());
});




var MembresiaTipo = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'MEMBRESIA_TIPO_INDEX') {
            this.keyEventIndex();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'MEMBRESIA_TIPO_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'MEMBRESIA_TIPO_EDIT') {
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

        if (this.evento == 'MEMBRESIA_TIPO_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:               function () {
        var objJSON = {
            pMembresiaTipoId: $('#txtMembresiaTipoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.MembresiaTipo + 'MembresiaTipoElementoJson',
            json
        );

        if (res != null) {
            $("#txtMembresiaTipoDescripcion").val(res.data.Datos[0].MembresiaTipoDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar:                  function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            MembresiaTipoId:          0,
            MembresiaTipoDescripcion: $("#txtMembresiaTipoDescripcion").val().trim()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.MembresiaTipo + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { MembresiaTipo.redirecciona('MEMBRESIA_TIPO_INDEX'); }, 2000);
                else
                    this.redirecciona('MEMBRESIA_TIPO_INDEX');
    },
    actualizar:               function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            MembresiaTipoId:          $("#txtMembresiaTipoId").val(),
            MembresiaTipoDescripcion: $("#txtMembresiaTipoDescripcion").val().trim(),
            EstatusId:                ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.MembresiaTipo + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { MembresiaTipo.redirecciona('MEMBRESIA_TIPO_INDEX'); }, 2000);
                else
                    this.redirecciona('MEMBRESIA_TIPO_INDEX');
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
                    MembresiaTipoId: $("#txtMembresiaTipoId").val()
                };

                var objJSON = {
                    model: _obj
                };

                var json = JSON.stringify(objJSON, null, 2);

                var res = getJSON(
                    URL.MembresiaTipo + 'Delete',
                    json
                );

                if (res != null)
                    if (!res.data.Error)
                        if (res.data.MuestraAlert)
                            setTimeout(function () { MembresiaTipo.redirecciona('MEMBRESIA_TIPO_INDEX'); }, 2000);
                        else
                            this.redirecciona('MEMBRESIA_TIPO_INDEX');
            }
            else {
                swal.close();
            }
        });
    },
    keyEvent:                 function () {
        $("#txtMembresiaTipoDescripcion").on("change paste keyup", function () {
            if ($("#txtMembresiaTipoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="MembresiaTipoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="MembresiaTipoDescripcion"]').text('');
        });
    },
    keyEventIndex:            function () {
        $('#dgDatosMembresiaTipo').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosMembresiaTipo tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    llenaCombo:               function (pCtrlName, pOpcion) {
        var res = getJSON(
            URL.MembresiaTipo + "MembresiaTipoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosMembresiaTipo').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'MembresiaTipoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'MembresiaTipoDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
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
                        events:    'MembresiaTipo_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pMembresiaTipoDescripcion: $('#txtMembresiaTipoDescripcion').val().trim(),
                pEstatusId:                $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.MembresiaTipo + 'MembresiaTipoGridJson',
                json
            );

            $('#dgDatosMembresiaTipo').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<div class="btn-group">',
                    '<button data-toggle="dropdown" class="btn btn-default btn-sm dropdown-toggle" aria-expanded="false">',
                        '<span><i class="fa fa-ellipsis-h"></i></span>',
                    '</button>',
                    '<ul class="dropdown-menu pull-right">',
                        '<li>',
                            '<a class="editMembresiaTipo" href="javascript:void(0)">',
                                '<i class="text-success fa fa-pencil fa-2x"></i>&nbsp;&nbsp; Editar',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="removeMembresiaTipo" href="javascript:void(0)">',
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
        if ($("#txtMembresiaTipoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="MembresiaTipoDescripcion"]').text('Campo Requerido');
            $("#txtMembresiaTipoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:            function () {
        if ($("#txtMembresiaTipoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="MembresiaTipoDescripcion"]').text('Campo Requerido');
            $("#txtMembresiaTipoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar:                  function () {
        this.inicializa('MEMBRESIA_TIPO_INDEX');
    },
    redirecciona:             function (evento) {
        if (evento == 'MEMBRESIA_TIPO_INDEX') {
            $(location).attr('href', URL.MembresiaTipo);
        };

        if (evento == 'MEMBRESIA_TIPO_CREATE') {
            $(location).attr('href', URL.MembresiaTipo + 'Create');
        };
    },
    limpiarCtrls:             function () {
        $('#txtMembresiaTipoDescripcion').val('');

        $('span[data-valmsg-for="MembresiaTipoDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtMembresiaTipoDescripcion', isDisabled);
    }
};




window.MembresiaTipo_ActionEvents = {
    'click .editMembresiaTipo':   function (e, value, row, index) {
        $(location).attr('href', URL.MembresiaTipo + 'Edit?pMembresiaTipoId=' + row.MembresiaTipoId);
    },
    'click .removeMembresiaTipo': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.MembresiaTipo + 'Delete?pMembresiaTipoId=' + row.MembresiaTipoId);
    }
};