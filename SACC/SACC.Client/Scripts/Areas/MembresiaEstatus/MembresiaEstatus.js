$(function () {
    MembresiaEstatus.inicializa($("#txtApuntadorMembresiaEstatus").val());
});




var MembresiaEstatus = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'MEMBRESIA_ESTATUS_INDEX') {
            this.keyEventIndex();
            this.limpiarCtrls();

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

        if (this.evento == 'MEMBRESIA_ESTATUS_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'MEMBRESIA_ESTATUS_EDIT') {
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

        if (this.evento == 'MEMBRESIA_ESTATUS_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:               function () {
        var objJSON = {
            pMembresiaEstatusId: $('#txtMembresiaEstatusId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.MembresiaEstatus + 'MembresiaEstatusElementoJson',
            json
        );

        if (res != null) {
            $("#txtMembresiaEstatusDescripcion").val(res.data.Datos[0].MembresiaEstatusDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar:                  function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            MembresiaEstatusId:          0,
            MembresiaEstatusDescripcion: $("#txtMembresiaEstatusDescripcion").val().trim()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.MembresiaEstatus + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { MembresiaEstatus.redirecciona('MEMBRESIA_ESTATUS_INDEX'); }, 2000);
                else
                    this.redirecciona('MEMBRESIA_ESTATUS_INDEX');
    },
    actualizar:               function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            MembresiaEstatusId:          $("#txtMembresiaEstatusId").val(),
            MembresiaEstatusDescripcion: $("#txtMembresiaEstatusDescripcion").val().trim(),
            EstatusId:                   ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.MembresiaEstatus + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { MembresiaEstatus.redirecciona('MEMBRESIA_ESTATUS_INDEX'); }, 2000);
                else
                    this.redirecciona('MEMBRESIA_ESTATUS_INDEX');
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
                    MembresiaEstatusId: $("#txtMembresiaEstatusId").val()
                };

                var objJSON = {
                    model: _obj
                };

                var json = JSON.stringify(objJSON, null, 2);

                var res = getJSON(
                    URL.MembresiaEstatus + 'Delete',
                    json
                );

                if (res != null)
                    if (!res.data.Error)
                        if (res.data.MuestraAlert)
                            setTimeout(function () { MembresiaEstatus.redirecciona('MEMBRESIA_ESTATUS_INDEX'); }, 2000);
                        else
                            this.redirecciona('MEMBRESIA_ESTATUS_INDEX');
            }
            else {
                swal.close();
            }
        });
    },
    keyEvent:                 function () {
        $("#txtMembresiaEstatusDescripcion").on("change paste keyup", function () {
            if ($("#txtMembresiaEstatusDescripcion").val().trim() == "")
                $('span[data-valmsg-for="MembresiaEstatusDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="MembresiaEstatusDescripcion"]').text('');
        });
    },
    keyEventIndex:            function () {
        $('#dgDatosMembresiaEstatus').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosMembresiaEstatus tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    llenaCombo:               function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.MembresiaEstatus + "MembresiaEstatusComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosMembresiaEstatus').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'MembresiaEstatusId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'MembresiaEstatusDescripcion',
                        title:     'Descripcióin',
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
                        events:    'MembresiaEstatus_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pMembresiaEstatusDescripcion: $('#txtMembresiaEstatusDescripcion').val().trim(),
                pEstatusId:                   $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.MembresiaEstatus + 'MembresiaEstatusGridJson',
                json
            );

            $('#dgDatosMembresiaEstatus').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<div class="btn-group">',
                    '<button data-toggle="dropdown" class="btn btn-default btn-sm dropdown-toggle" aria-expanded="false">',
                        '<span><i class="fa fa-ellipsis-h"></i></span>',
                    '</button>',
                    '<ul class="dropdown-menu pull-right">',
                        '<li>',
                            '<a class="editMembresiaEstatus" href="javascript:void(0)">',
                                '<i class="text-success fa fa-pencil fa-2x"></i>&nbsp;&nbsp; Editar',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="removeMembresiaEstatus" href="javascript:void(0)">',
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
        if ($("#txtMembresiaEstatusDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="MembresiaEstatusDescripcion"]').text('Campo Requerido');
            $("#txtMembresiaEstatusDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:            function () {
        if ($("#txtMembresiaEstatusDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="MembresiaEstatusDescripcion"]').text('Campo Requerido');
            $("#txtMembresiaEstatusDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar:                  function () {
        this.inicializa('MEMBRESIA_ESTATUS_INDEX');
    },
    redirecciona:             function (evento) {
        if (evento == 'MEMBRESIA_ESTATUS_INDEX') {
            $(location).attr('href', URL.MembresiaEstatus);
        };

        if (evento == 'MEMBRESIA_ESTATUS_CREATE') {
            $(location).attr('href', URL.MembresiaEstatus + 'Create');
        };
    },
    limpiarCtrls:             function () {
        $('#txtMembresiaEstatusDescripcion').val('');

        $('span[data-valmsg-for="MembresiaEstatusDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtMembresiaEstatusDescripcion', isDisabled);
    }
};




window.MembresiaEstatus_ActionEvents = {
    'click .editMembresiaEstatus':   function (e, value, row, index) {
        $(location).attr('href', URL.MembresiaEstatus + 'Edit?pMembresiaEstatusId=' + row.MembresiaEstatusId);
    },
    'click .removeMembresiaEstatus': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.MembresiaEstatus + 'Delete?pMembresiaEstatusId=' + row.MembresiaEstatusId);
    }
};