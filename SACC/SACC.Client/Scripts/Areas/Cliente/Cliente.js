$(function () {
    Cliente.inicializa($("#txtApuntadorCliente").val());
});




var Cliente = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'CLIENTE_INDEX') {
            this.keyEvent();
            this.limpiarCtrls();

            ClienteTipo.llenaCombo('ddlClienteTipoId', 'TODOS');

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'CLIENTE_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            ClienteTipo.llenaCombo('ddlClienteTipoId', 'SELECCIONE');
        };

        if (this.evento == 'CLIENTE_EDIT') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            ClienteTipo.llenaCombo('ddlClienteTipoId', 'SELECCIONE');

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'CLIENTE_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:               function () {
        var objJSON = {
            pClienteId:     $('#txtClienteId').val(),
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Cliente + 'ClienteElementoJson',
            json
        );

        if (res != null) {
            $("#txtClienteDescripcion").val(res.data.Datos[0].ClienteDescripcion);
            $("#txtClienteDescripcionCorta").val(res.data.Datos[0].ClienteDescripcionCorta);
            $("#ddlClienteTipoId").val(res.data.Datos[0].ClienteTipoId);

            if (res.data.Datos[0].BajaProgramada == true)
                $("input[name=chkBajaProgramada]").prop('checked', true).iCheck('update');
            else
                $("input[name=chkBajaProgramada]").prop('checked', false).iCheck('update');

            $("#dtpFechaBajaProgramada").val(formatFecha(res.data.Datos[0].FechaBajaProgramada));
            $("#dtpInicioOperaciones").val(formatFecha(res.data.Datos[0].InicioOperaciones));


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar:                  function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ClienteId: 0,
            ClienteDescripcion:      $("#txtClienteDescripcion").val(),
            Codigo:                  $("#txtCodigo").val(),
            ClienteTipoId:           $("#ddlClienteTipoId").val(),
            BajaProgramada:          $("#chkBajaProgramada").is(":checked") ? 1 : 0,
            FechaBajaProgramada:     $('#dtpFechaBajaProgramada').val() == "" ? null : $('#dtpFechaBajaProgramada').val(),
            PreActivo:               $("#chkPreActivo").is(":checked") ? 1 : 0,
            FechaPreActivo:          $('#dtpFechaActivacion').val() == "" ? null : $('#dtpFechaActivacion').val(),
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Cliente + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Cliente.redirecciona('CLIENTE_INDEX'); }, 2000);
                else
                    this.redirecciona('CLIENTE_INDEX');
    },
    actualizar:               function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ClienteId:          $("#txtClienteId").val(),
            ClienteDescripcion: $("#txtClienteDescripcion").val().trim(),
            Rfc:                $("#txtRfc").val().trim(),
            Telefono:           $("#txtTelefono").val().trim(),
            EstatusId:          ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Cliente + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Cliente.redirecciona('CLIENTE_INDEX'); }, 2000);
                else
                    this.redirecciona('CLIENTE_INDEX');
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
                        ClienteId: $("#txtClienteId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Cliente + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Cliente.redirecciona('CLIENTE_INDEX'); }, 2000);
                            else
                                this.redirecciona('CLIENTE_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent:                 function () {
        $("#txtClienteDescripcion").on("change paste keyup", function () {
            if ($("#txtClienteDescripcion").val().trim() == "")
                $('span[data-valmsg-for="ClienteDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ClienteDescripcion"]').text('');
        });

        $("#txtClienteDescripcionCorta").on("change paste keyup", function () {
            if ($("#txtClienteDescripcionCorta").val().trim() == "")
                $('span[data-valmsg-for="ClienteDescripcionCorta"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ClienteDescripcionCorta"]').text('');
        });

        $('#ddlClienteTipoId').change(function () {
            if ($('#ddlClienteTipoId  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="ClienteTipoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="ClienteTipoId"]').text('');
            };
        });

        $("#dtpInicioOperaciones").on("change paste keyup", function () {
            if ($("#dtpInicioOperaciones").val().trim() == "")
                $('span[data-valmsg-for="InicioOperaciones"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="InicioOperaciones"]').text('');



        });

        $("#dtpFechaBajaProgramada").on("change paste keyup", function () {
            if ($("#dtpFechaBajaProgramada").val().trim() == "")
                $('span[data-valmsg-for="dtpFechaBajaProgramada"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="dtpFechaBajaProgramada"]').text('');
        });

        
        $("input[name='cbBajaProgramada']").on("ifToggled", function () {
            if ($(this).is(":checked")) {
                $('#dtpFechaBajaProgramada').prop('disabled', false);

            } else {
                $('#dtpFechaBajaProgramada').prop('disabled', true);
                $('#dtpFechaBajaProgramada').val("");

            }
        });
    },
    keyEventIndex: function () {
        $('#dgDatosCliente').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosCliente tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    llenaCombo:               function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.Cliente + "ClienteComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCliente').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ClienteId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'ClienteDescripcion',
                        title:     'Descripción',
                        sortable:   true,
                        align:     'left'
                    },
                    {
                        field:     'ClienteTipoDescripcion',
                        title:     'Tipo de Cliente',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'InicioOperaciones',
                        title:     'Inicio de Operaciones',
                        sortable:  true,
                        align:     'center'


                    },
                    {
                        field:     'FechaReactivacion',
                        title:     'Fecha de Reactivaci&oacute;n',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'FechaBaja',
                        title:     'Fecha de Baja',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'EstatusId',
                        title:     'Activo',
                        sortable:  false,
                        //formatter: 'ClienteEstatusIdFormatter',
                        formatter: (value, ClienteId, row) => {
                            if (value == 1)
                                return '<input type="checkbox" checked id="toggle-Cliente32" "data-toggle="toggle" data-onstyle="success" data-offstyle="danger" data-on="SI" data-off="NO"  data-size="sm">'
                            else
                                return '<input type="checkbox" id="toggle-Cliente' + ClienteId.ClienteId + ' "data-toggle="toggle" data-onstyle="success" data-offstyle="danger" data-on="SI" data-off="NO"  data-size="sm">'
                        },
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'Cliente_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pClienteDescripcion: $('#txtClienteDescripcion').val().trim(),
                pClienteTipoId:      $('#ddlClienteTipoId').val(),
                pEstatusId:          $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Cliente + 'ClienteGridJson',
                json
            );

            $('#dgDatosCliente').bootstrapTable("load", res.data.Datos);

            $('#toggle-Cliente32').bootstrapToggle()
        },
        accion:     function (value, row, index) {
            return [
                '<div class="btn-group">',
                    '<button data-toggle="dropdown" class="btn btn-default btn-sm dropdown-toggle" aria-expanded="false">',
                        '<span><i class="fa fa-ellipsis-h"></i></span>',
                    '</button>',
                    '<ul class="dropdown-menu pull-right">',
                        '<li>',
                            '<a class="editCliente" href="javascript:void(0)">',
                                '<i class="text-success fa fa-pencil fa-2x"></i>&nbsp;&nbsp; Editar',
                            '</a>',
                        '</li>',

                        '<li>',
                            '<a class="clienteEmpresa" href="javascript:void(0)">',
                                '<i class="text-warning fa fa-cog fa-2x"></i>&nbsp;&nbsp; Empresas',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="clienteHistorico" href="javascript:void(0)">',
                                '<i class="text-primary fa fa-calendar fa-2x"></i>&nbsp;&nbsp; Historico',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="removeCliente" href="javascript:void(0)">',
                                '<i class="text-danger fa fa-trash fa-2x"></i>&nbsp;&nbsp; Eliminar',
                            '</a>',
                        '</li>',
                    '</ul >',
                '</div>'


                //'<a class="editCliente" href="javascript:void(0)" title="Editar">',
                //'<i class="text-success fa fa-pencil fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="clienteEmpresa" href="javascript:void(0)" title="Empresas">',
                //'<i class="text-warning fa fa-industry fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="clienteHistorico" href="javascript:void(0)" title="Historico">',
                //'<i class="text-primary fa fa-calendar fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                //'<a class="removeCliente" href="javascript:void(0)" title="Eliminar">',
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
        if ($("#txtClienteDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ClienteDescripcion"]').text('Campo Requerido');
            $("#txtClienteDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:            function () {
        if ($("#txtClienteDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="ClienteDescripcion"]').text('Campo Requerido');
            $("#txtClienteDescripcion").focus();

            return false;
        }

        if ($("#txtCodigo").val().trim() == "") {
            $('span[data-valmsg-for="Codigo"]').text('Campo Requerido');
            $("#txtCodigo").focus();

            return false;
        }

        if ($('#ddlClienteTipoId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="ddlClienteTipoId"]').text('Campo Requerido');
            $("#ddlClienteTipoId").focus();

            return false;
        }

        if ($("#chkBajaProgramada").is(":checked")) {
            if ($("#dtpFechaBajaProgramada").val().trim() == "") {
                $('span[data-valmsg-for="FechaBajaProgramada"]').text('Campo Requerido');
                $("#dtpFechaBajaProgramada").focus();

                return false;
            }
        }

        //if ($("#dtpInicioOperaciones").val().trim() == "") {
        //    $('span[data-valmsg-for="InicioOperaciones"]').text('Campo Requerido');
        //    $("#dtpInicioOperaciones").focus();

        //    return false;
        //}

        return true;
    },
    limpiar:                  function () {
        this.inicializa('CLIENTE_INDEX');
    },
    redirecciona:             function (evento) {
        if (evento == 'CLIENTE_INDEX') {
            $(location).attr('href', URL.Cliente);
        };

        if (evento == 'CLIENTE_CREATE') {
            $(location).attr('href', URL.Cliente + 'Create');
        };
    },
    switchCliente:            function (pId, pDescripcion) {
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
                        Cliente.redirecciona('CLIENTE_INDEX');
                        break;

                    case "configurar":
                        $(location).attr('href', URL.ClienteContrato + 'Index?pClienteId=' + pId + '&pClienteDescripcion=' + pDescripcion);
                        break;

                    case "agregar":
                        Cliente.redirecciona('CLIENTE_CREATE');
                        break;
                }
            });
    },
    limpiarCtrls:             function () {
        $('#txtClienteDescripcion').val('');
        $('span[data-valmsg-for="ClienteDescripcion"]').text('');

        $('#txtRfc').val('');
        $('span[data-valmsg-for="Rfc"]').text('');

        $('#txtTelefono').val('');
        $('span[data-valmsg-for="Telefono"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtClienteDescripcion', isDisabled);
    }
};




window.Cliente_ActionEvents = {
    'click .editCliente': function (e, value, row, index) {
        $(location).attr('href', URL.Cliente + 'Edit?pClienteId=' + row.ClienteId);
    },
    //'click .empresaContrato': function (e, value, row, index) {
    //    if (row.Baja == true) {
    //        swal('El registro esta inactivo.', '', 'info');
    //        return;
    //    };

    //    $(location).attr('href', URL.ClienteContrato + 'Index?pClienteId=' + row.ClienteId + '&pClienteDescripcion=' + row.ClienteDescripcion);
    //},
    'click .clienteEmpresa': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Empresa + 'Index?pClienteId=' + row.ClienteId + '&pClienteDescripcion=' + row.ClienteDescripcion);
    },
    'click .clienteHistorico': function (e, value, row, index) {
        Cliente.AbreModalClienteHistorico(row.ClienteId);
    },
    'click .removeCliente': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Cliente + 'Delete?pClienteId=' + row.ClienteId);
    }
};