$(function () {
    PaqueteTipo.inicializa($("#txtApuntadorPaqueteTipo").val());
});




var PaqueteTipo = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'PAQUETE_TIPO_INDEX') {
            this.keyEventIndex();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'PAQUETE_TIPO_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'PAQUETE_TIPO_EDIT') {
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

        if (this.evento == 'PAQUETE_TIPO_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:               function () {
        var objJSON = {
            pPaqueteTipoId: $('#txtPaqueteTipoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.PaqueteTipo + 'PaqueteTipoElementoJson',
            json
        );

        if (res != null) {
            $("#txtPaqueteTipoDescripcion").val(res.data.Datos[0].PaqueteTipoDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar:                  function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            PaqueteTipoId:          0,
            PaqueteTipoDescripcion: $("#txtPaqueteTipoDescripcion").val().trim()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.PaqueteTipo + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { PaqueteTipo.redirecciona('PAQUETE_TIPO_INDEX'); }, 2000);
                else
                    this.redirecciona('PAQUETE_TIPO_INDEX');
    },
    actualizar:               function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            PaqueteTipoId:          $("#txtPaqueteTipoId").val(),
            PaqueteTipoDescripcion: $("#txtPaqueteTipoDescripcion").val().trim(),
            EstatusId:              ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.PaqueteTipo + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { PaqueteTipo.redirecciona('PAQUETE_TIPO_INDEX'); }, 2000);
                else
                    this.redirecciona('PAQUETE_TIPO_INDEX');
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
                        PaqueteTipoId: $("#txtPaqueteTipoId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.PaqueteTipo + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { PaqueteTipo.redirecciona('PAQUETE_TIPO_INDEX'); }, 2000);
                            else
                                this.redirecciona('PAQUETE_TIPO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent:                 function () {
        $("#txtPaqueteTipoDescripcion").on("change paste keyup", function () {
            if ($("#txtPaqueteTipoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="PaqueteTipoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="PaqueteTipoDescripcion"]').text('');
        });
    },
    keyEventIndex:            function () {
        $('#dgDatosPaqueteTipo').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosPaqueteTipo tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    llenaCombo:               function (pCtrlName, pOpcion) {
        var res = getJSON(
            URL.PaqueteTipo + "PaqueteTipoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosPaqueteTipo').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'PaqueteTipoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'PaqueteTipoDescripcion',
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
                        events:    'PaqueteTipo_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pPaqueteTipoDescripcion: $('#txtPaqueteTipoDescripcion').val().trim(),
                pEstatusId:              $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.PaqueteTipo + 'PaqueteTipoGridJson',
                json
            );

            $('#dgDatosPaqueteTipo').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<div class="btn-group">',
                    '<button data-toggle="dropdown" class="btn btn-default btn-sm dropdown-toggle" aria-expanded="false">',
                        '<span><i class="fa fa-ellipsis-h"></i></span>',
                    '</button>',
                    '<ul class="dropdown-menu pull-right">',
                        '<li>',
                            '<a class="editPaqueteTipo" href="javascript:void(0)">',
                                '<i class="text-success fa fa-pencil fa-2x"></i>&nbsp;&nbsp; Editar',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="removePaqueteTipo" href="javascript:void(0)">',
                                '<i class="text-danger fa fa-trash fa-2x"></i>&nbsp;&nbsp; Eliminar',
                            '</a>',
                        '</li>',
                    '</ul >',
                '</div>'


                //'<a class="editPaqueteTipo" href="javascript:void(0)" title="Editar">',
                //'<i class="text-success fa fa-pencil fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="removePaqueteTipo" href="javascript:void(0)" title="Inactivo">',
                //'<i class="text-danger fa fa-trash fa-2x"></i>',
                //'</a>'
            ].join('');
        }
    },
    buscar:                   function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda:           function () {
        if ($("#txtPaqueteTipoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="PaqueteTipoDescripcion"]').text('Campo Requerido');
            $("#txtPaqueteTipoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:            function () {
        if ($("#txtPaqueteTipoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="PaqueteTipoDescripcion"]').text('Campo Requerido');
            $("#txtPaqueteTipoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar:                  function () {
        this.inicializa('PAQUETE_TIPO_INDEX');
    },
    redirecciona:             function (evento) {
        if (evento == 'PAQUETE_TIPO_INDEX') {
            $(location).attr('href', URL.PaqueteTipo);
        };

        if (evento == 'PAQUETE_TIPO_CREATE') {
            $(location).attr('href', URL.PaqueteTipo + 'Create');
        };
    },
    limpiarCtrls:             function () {
        $('#txtPaqueteTipoDescripcion').val('');

        $('span[data-valmsg-for="PaqueteTipoDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtPaqueteTipoDescripcion', isDisabled);
    }
};




window.PaqueteTipo_ActionEvents = {
    'click .editPaqueteTipo':   function (e, value, row, index) {
        $(location).attr('href', URL.PaqueteTipo + 'Edit?pPaqueteTipoId=' + row.PaqueteTipoId);
    },
    'click .removePaqueteTipo': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.PaqueteTipo + 'Delete?pPaqueteTipoId=' + row.PaqueteTipoId);
    }
};