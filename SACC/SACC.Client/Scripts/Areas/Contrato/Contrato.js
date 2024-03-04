$(function () {
    Contrato.inicializa($("#txtApuntadorContrato").val());
});




var Contrato = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'CONTRATO_INDEX') {
            this.keyEventIndex();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'CONTRATO_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            ContratoTipo.llenaCombo('ddlContratoTipoId', 'SELECCIONE');
            EmpresaPlanta.llenaCombo('ddlContratanteId', 'SELECCIONE');
        };

        if (this.evento == 'CONTRATO_EDIT') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            ContratoTipo.llenaCombo('ddlContratoTipoId', 'SELECCIONE');
            EmpresaPlanta.llenaCombo('ddlContratanteId', 'SELECCIONE');

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'CONTRATO_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            ContratoTipo.llenaCombo('ddlContratoTipoId', 'SELECCIONE');
            EmpresaPlanta.llenaCombo('ddlContratanteId', 'SELECCIONE');

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:               function () {
        var objJSON = {
            pContratoId: $('#txtContratoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Contrato + 'ContratoElementoJson',
            json
        );

        if (res != null) {
            $("#txtContratoDescripcion").val(res.data.Datos[0].ContratoDescripcion);
            $("#ddlContratoTipoId").val(res.data.Datos[0].ContratoTipoId);
            $("#ddlContratanteId").val(res.data.Datos[0].ContratanteId);

            if (res.data.Datos[0].ContratoEstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar:                  function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ContratoId:          0,
            ContratoDescripcion: $("#txtContratoDescripcion").val().trim(),
            ContratoTipoId:      $("#ddlContratoTipoId").val(),
            ContratanteId:       $("#ddlContratanteId").val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Contrato + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Contrato.redirecciona('CONTRATO_INDEX'); }, 2000);
                else
                    this.redirecciona('CONTRATO_INDEX');
    },
    actualizar:               function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ContratoId:          $("#txtContratoId").val(),
            ContratoDescripcion: $("#txtContratoDescripcion").val().trim(),
            ContratoTipoId:      $("#ddlContratoTipoId").val(),
            ContratanteId:       $("#ddlContratanteId").val(),
            ContratoEstatusId:   ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Contrato + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Contrato.redirecciona('CONTRATO_INDEX'); }, 2000);
                else
                    this.redirecciona('CONTRATO_INDEX');
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
                        ContratoId: $("#txtContratoId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Contrato + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Contrato.redirecciona('CONTRATO_INDEX'); }, 2000);
                            else
                                this.redirecciona('CONTRATO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent:                 function () {
        $("#txtContratoDescripcion").on("change paste keyup", function () {
            if ($("#txtContratoDescripcion").val().trim() == "")
                $('span[data-valmsg-for="ContratoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ContratoDescripcion"]').text('');
        });
    },
    keyEventIndex:            function () {
        $('#dgDatosContrato').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosContrato tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    llenaCombo:               function (pCtrlName, pOpcion) {
        var res = getJSON(
            URL.Contrato + "ContratoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosContrato').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ContratoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ContratoDescripcion',
                        title:     'Descripción',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'ContratoTipoDescripcion',
                        title:     'Tipo de Contrato',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'EmpresaPlantaDescripcion',
                        title:     'Empresa Planta',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'ContratoEstatusId',
                        title:     'Activo',
                        formatter: 'EstatusIdFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        formatter: this.accion(),
                        events:    'Contrato_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pContratoDescripcion: $('#txtContratoDescripcion').val().trim(),
                pContratoTipoId:      -1,
                pContratanteId:       -1,
                pEstatusId:           $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Contrato + 'ContratoGridJson',
                json
            );

            $('#dgDatosContrato').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<div class="btn-group">',
                    '<button data-toggle="dropdown" class="btn btn-default btn-sm dropdown-toggle" aria-expanded="false">',
                        '<span><i class="fa fa-ellipsis-h"></i></span>',
                    '</button>',
                    '<ul class="dropdown-menu pull-right">',
                        '<li>',
                            '<a class="editContrato" href="javascript:void(0)">',
                                '<i class="text-success fa fa-pencil fa-2x"></i>&nbsp;&nbsp; Editar',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="contratoCobertura" href="javascript:void(0)">',
                                '<i class="text-warning fa fa-cog fa-2x"></i>&nbsp;&nbsp; Coberturas',
                            '</a>',
                        '</li>',

                        '<li>',
                            '<a class="contratoProducto" href="javascript:void(0)">',
                                '<i class="text-info fa fa-list fa-2x"></i>&nbsp;&nbsp; Productos',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="removeContrato" href="javascript:void(0)">',
                                '<i class="text-danger fa fa-trash fa-2x"></i>&nbsp;&nbsp; Eliminar',
                            '</a>',
                        '</li>',
                    '</ul >',
                '</div>'

                //'<a class="editContrato" href="javascript:void(0)" title="Editar">',
                //'<i class="text-success fa fa-pencil fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;</span>',
                //'<a class="contratoCobertura" href="javascript:void(0)" title="Coberturas">',
                //'<i class="text-warning fa fa-cog fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;</span>',
                //'<a class="contratoProducto" href="javascript:void(0)" title="Productos">',
                //'<i class="text-info fa fa-list fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="removeContrato" href="javascript:void(0)" title="Inactivo">',
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
        if ($("#txtContratoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ContratoDescripcion"]').text('Campo Requerido');
            $("#txtContratoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:            function () {
        if ($("#txtContratoDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ContratoDescripcion"]').text('Campo Requerido');
            $("#txtContratoDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar:                  function () {
        this.inicializa('CONTRATO_INDEX');
    },
    redirecciona:             function (evento) {
        if (evento == 'CONTRATO_INDEX') {
            $(location).attr('href', URL.Contrato);
        };

        if (evento == 'CONTRATO_CREATE') {
            $(location).attr('href', URL.Contrato + 'Create');
        };
    },
    limpiarCtrls:             function () {
        $('#txtContratoDescripcion').val('');

        $('span[data-valmsg-for="ContratoDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtContratoDescripcion', isDisabled);
        DisabledEneableElement('ddlContratoTipoId', isDisabled);
        DisabledEneableElement('ddlContratanteId', isDisabled);
    }
};




window.Contrato_ActionEvents = {
    'click .editContrato':      function (e, value, row, index) {
        $(location).attr('href', URL.Contrato + 'Edit?pContratoId=' + row.ContratoId);
    },
    'click .contratoCobertura': function (e, value, row, index) {
        if (row.EstatusId == 2) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.ContratoCobertura + 'Index?pContratoId=' + row.ContratoId + '&pContratoDescripcion=' + row.ContratoDescripcion);
    },
    'click .contratoProducto':  function (e, value, row, index) {
        if (row.EstatusId == 2) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.ContratoProducto + 'Index?pContratoId=' + row.ContratoId + '&pContratoDescripcion=' + row.ContratoDescripcion);
    },
    'click .removeContrato':    function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Contrato + 'Delete?pContratoId=' + row.ContratoId);
    }
};