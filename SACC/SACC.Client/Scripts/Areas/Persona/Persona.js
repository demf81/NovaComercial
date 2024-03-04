$(function () {
    //$('.ladda-button-buscar').ladda();
    //$('.ladda-button-limpiar').ladda();
    //$('.ladda-button-create').ladda();
    //$('.ladda-button-importar').ladda();

    Persona.inicializa($("#txtApuntadorPersona").val());
});




var Persona = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'PERSONA_INDEX') {
            this.keyEventIndex();
            this.limpiarCtrls();

            Genero.llenaCombo('ddlGeneroId', 'TODOS', '');

            this.tabla.inicializa();
            this.tabla.datos();
        };

        if (this.evento == 'PERSONA_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'PERSONA_EDIT') {
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

        if (this.evento == 'PERSONA_DELETE') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:               function () {
        var objJSON = {
            pPersonaId: $('#txtPersonaId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Persona + 'PersonaElementoJson',
            json
        );

        if (res != null) {
            $("#txtCurp").val(res.data.Datos[0].CURP);

            if (res.data.Datos[0].RN == true)
                $("input[name=chkRecienNacido]").prop('checked', true).iCheck('update');
            else
                $("input[name=chkRecienNacido]").prop('checked', false).iCheck('update');

            if (res.data.Datos[0].Extranjero == true)
                $("input[name=chkExtranjero]").prop('checked', true).iCheck('update');
            else
                $("input[name=chkExtranjero]").prop('checked', false).iCheck('update');

            $("#txtNombre").val(res.data.Datos[0].Nombre);
            $("#txtPaterno").val(res.data.Datos[0].Paterno);
            $("#txtMaterno").val(res.data.Datos[0].Materno);

            if (res.data.Datos[0].Genero == 1)
                $("input[name=rbGeneroId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbGeneroId][value=0]").prop('checked', true).iCheck('update');

            $("#dtpFechaNacimiento").val(formatFecha(res.data.Datos[0].FechaNacimiento));

            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar:                  function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            PersonaId:       0,
            Nombre:          $("#txtNombre").val().trim(),
            Paterno:         $("#txtPaterno").val().trim(),
            Materno:         $("#txtMaterno").val().trim(),
            Genero:          ($("input[name='rbGeneroId'][value=1]:checked").val() ? true : false),
            FechaNacimiento: $("#dtpFechaNacimiento").val().trim(),
            CURP:            $("#txtCurp").val().trim(),
            RN:              ($("input[name='chkRecienNacido']:checked").val() ? true : false),
            Extranjero:      ($("input[name='chkExtranjero']:checked").val() ? true : false),
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Persona + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Persona.redirecciona('PERSONA_INDEX'); }, 2000);
                else
                    this.redirecciona('PERSONA_INDEX');
    },
    actualizar:               function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            PersonaId:       $("#txtPersonaId").val(),
            Nombre:          $("#txtNombre").val().trim(),
            Paterno:         $("#txtPaterno").val().trim(),
            Materno:         $("#txtMaterno").val().trim(),
            Genero:          ($("input[name='rbGeneroId'][value=1]:checked").val() ? true : false),
            FechaNacimiento: $("#dtpFechaNacimiento").val().trim(),
            CURP:            $("#txtCurp").val().trim(),
            RN:              ($("input[name='chkRecienNacido']:checked").val() ? true : false),
            Extranjero:      ($("input[name='chkExtranjero']:checked").val()? true : false),
            EstatusId:       ($("input[name='rbEstatusId'][value=1]:checked").val() ? 1 : 2)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Persona + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Persona.redirecciona('PERSONA_INDEX'); }, 2000);
                else
                    this.redirecciona('PERSONA_INDEX');
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
                        PersonaId: $("#txtPersonaId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Persona + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Persona.redirecciona('PERSONA_INDEX'); }, 2000);
                            else
                                this.redirecciona('PERSONA_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent:                 function () {
        $("#txtCurp").on("change paste keyup", function () {
            if ($("#txtCurp").val().trim() == "")
                $('span[data-valmsg-for="Curp"]').text('Campo Requerido');
            else {
                $('span[data-valmsg-for="Curp"]').text('');

                var str = $("#txtCurp").val().trim();

                var anio          = str.substring(4, 6);
                var mes           = str.substring(6, 8);
                var dia           = str.substring(8, 10);
                var genero        = str.substring(10, 11);
                var diferenciador = str.substring(16, 17);

                var anioComplemento = 19;

                if (genero == "H") {
                    $('input:radio[name=rbGeneroId][value="1"]').prop('checked', true).iCheck('update');
                    $('input:radio[name=rbGeneroId][value="0"]').prop('checked', false).iCheck('update');
                }
                else {
                    $('input:radio[name=Genero][value="0"]').prop('checked', true).iCheck('update');
                    $('input:radio[name=Genero][value="1"]').prop('checked', false).iCheck('update');
                }

                if ($.isNumeric(diferenciador)) {
                    anioComplemento = 19;
                }
                else {
                    anioComplemento = 20;
                }

                $("#dtpFechaNacimiento").val(anioComplemento + anio + '-' + mes + '-' + dia);
            }
        });

        $("#txtNombre").on("change paste keyup", function () {
            if ($("#txtNombre").val().trim() == "")
                $('span[data-valmsg-for="Nombre"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Nombre"]').text('');
        });

        $("#txtPaterno").on("change paste keyup", function () {
            if ($("#txtPaterno").val().trim() == "")
                $('span[data-valmsg-for="Paterno"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Paterno"]').text('');
        });

        $("#txtMaterno").on("change paste keyup", function () {
            if ($("#txtMaterno").val().trim() == "")
                $('span[data-valmsg-for="Materno"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="Materno"]').text('');
        });

        $("#dtpFechaNacimiento").on("change paste keyup", function () {
            if ($("#dtpFechaNacimiento").val().trim() == "")
                $('span[data-valmsg-for="FechaNacimiento"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="FechaNacimiento"]').text('');
        });
    },
    keyEventIndex:            function () {
        $('#dgDatosPersona').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosPersona tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    llenaCombo:               function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.Persona + "PersonaComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosPersona').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:    'PersonaId',
                        title:    'No. Cliente',
                        sortable:  true,
                        align:    'center'
                    },
                    {
                        field:     'NombreCompleto',
                        title:     'Nombre',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'CURP',
                        title:     'CURP',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'GeneroDescripcion',
                        title:     'G&eacute;nero',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Edad',
                        title:     'Edad',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'NumSocio',
                        title:     'No. Socio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'CoberturaDefault',
                        title:     'Cobertura Activa',
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
                        field:     'EstatusVigencia',
                        title:     'Vigencia',
                        formatter: 'EstatusIdFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        formatter: this.accion(),
                        events:    'Persona_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pPersonaId:     0,
                pNumSocio:      ($('#txtNumSocio').val().trim() == '' ? -1 : $('#txtNumSocio').val().trim()),
                pClaveFamiliar: ($('#txtClaveFamiliar').val().trim() == '' ? 0 : $('#txtClaveFamiliar').val().trim()),
                pNombre:        $('#txtNombre').val().trim(),
                pCURP:          $('#txtCurp').val().trim(),
                pGeneroId:      $('#ddlGeneroId').val().trim(),
                pContratoId:    0,
                pEstatusId:     $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Persona + 'PersonaGridJson',
                json
            );

            $('#dgDatosPersona').bootstrapTable("load", res.data.Datos);
        },
        accion:     function () {
            return [
                '<div class="btn-group">',
                    '<button data-toggle="dropdown" class="btn btn-default btn-sm dropdown-toggle" aria-expanded="false">',
                        '<span><i class="fa fa-ellipsis-h"></i></span>',
                    '</button>',
                    '<ul class="dropdown-menu pull-right">',
                        '<li>',
                            '<a class="editPersona" href="javascript:void(0)">',
                                '<i class="text-success fa fa-pencil fa-2x"></i>&nbsp;&nbsp; Editar',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="personaContrato" href="javascript:void(0)">',
                                '<i class="text-warning fa fa-cog fa-2x"></i>&nbsp;&nbsp; Contratos',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="removePersona" href="javascript:void(0)">',
                                '<i class="text-danger fa fa-trash fa-2x"></i>&nbsp;&nbsp; Eliminar',
                            '</a>',
                        '</li>',
                    '</ul >',
                '</div>'
            ].join('');

            //return [
            //    '<a class="editPersona" href="javascript:void(0)" title="Editar">',
            //    '<i class="text-success fa fa-pencil fa-2x"></i>',
            //    '</a>',
            //    '<span>&nbsp;&nbsp;</span>',
            //    '<a class="contratos" href="javascript:void(0)" title="Contratos">',
            //    '<i class="text-warning fa fa-cog fa-2x"></i>',
            //    '</a>',
            //    '<span>&nbsp;&nbsp;&nbsp;</span>',
            //    '<a class="removePersona" href="javascript:void(0)" title="Inactivo">',
            //    '<i class="text-danger fa fa-trash fa-2x"></i>',
            //    '</a>'
            //].join('');
        }
    },
    buscar:                   function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda:           function () {
        //if ($("#txtPersonaDescripcion").val().trim() == "") {
        //    $('span[data-valmsg-for="PersonaDescripcion"]').text('Campo Requerido');
        //    $("#txtPersonaDescripcion").focus();

        //    return false;
        //}

        return true;
    },
    validaGuardar:            function () {
        if ($("#txtCurp").val().trim() == "") {
            $('span[data-valmsg-for="Curp"]').text('Campo Requerido');
            $("#txtCurp").focus();

            return false;
        }

        if ($("#txtNombre").val().trim() == "") {
            $('span[data-valmsg-for="Nombre"]').text('Campo Requerido');
            $("#txtNombre").focus();

            return false;
        }

        if ($("#txtPaterno").val().trim() == "") {
            $('span[data-valmsg-for="Paterno"]').text('Campo Requerido');
            $("#txtPaterno").focus();

            return false;
        }

        if ($("#txtMaterno").val().trim() == "") {
            $('span[data-valmsg-for="Materno"]').text('Campo Requerido');
            $("#txtMaterno").focus();

            return false;
        }

        if ($("#dtpFechaNacimiento").val().trim() == "") {
            $('span[data-valmsg-for="FechaNacimiento"]').text('Campo Requerido');
            $("#dtpFechaNacimiento").focus();

            return false;
        }

        return true;
    },
    limpiar:                  function () {
        $('.ladda-button-limpiar').ladda('start');

        //this.limpiarCtrls();

        setTimeout(function () {
            $('.ladda-button-limpiar').ladda('stop');
        }, 800)

        this.redirecciona('PERSONA_INDEX');
    },
    redirecciona:             function (evento) {
        if (evento == 'PERSONA_INDEX') {
            $(location).attr('href', URL.Persona);
        };

        if (evento == 'PERSONA_CREATE') {
            $(location).attr('href', URL.Persona + 'Create');
        };
    },
    limpiarCtrls:             function () {
        $('#txtNumSocio').val('');
        $('span[data-valmsg-for="NumSocio"]').text('');

        $('#txtClaveFamiliar').val('');
        $('span[data-valmsg-for="ClaveFamiliar"]').text('');

        $('#txtNombre').val('');
        $('span[data-valmsg-for="Nombre"]').text('');

        $('#txtCurp').val('');
        $('span[data-valmsg-for="Curp"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtCurp', isDisabled);

        DisabledEneableElementCheck("input[name='chkRecienNacido']", isDisabled);
        DisabledEneableElementCheck("input[name='chkExtranjero']", isDisabled);

        DisabledEneableElement('txtNombre',             isDisabled);
        DisabledEneableElement('txtPaterno',            isDisabled);
        DisabledEneableElement('txtMaterno',            isDisabled);
        DisabledEneableElement('txtPersonaDescripcion', isDisabled);

        DisabledEneableElementCheck("input[name='rbGeneroId']",  isDisabled);
        DisabledEneableElementCheck("input[name='rbEstatusId']", isDisabled);
    },
    ImportacionBajoDemanda:   function () {
        $('#pleaseWaitDialog').modal('show');

        $.ajax({
            url: URL.Asociado + 'ImportacionBajoDemanda',
            data:        "",
            type:        'POST',
            async:       false,
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.result.data.Id > 0) {
                    swal({
                        text: '',
                        title: '' + response.result.data.Mensaje,
                        type: 'success'
                    },
                    function () {
                        $(location).attr('href', URL.Persona + 'Index');
                    });
                }
            },
            error: function (XMLHttpRequest, success, errorThrown) {
                alert("Error", "NovaSys", XMLHttpRequest.responseText)
            }
        });

    $('#pleaseWaitDialog').modal('hide');
    },
    ProcesaGuion80: function () {
        $('#pleaseWaitDialog').modal('show');

        $.ajax({
            url: URL.Persona + 'ProcesaGuion80',
            data: "",
            type: 'POST',
            async: false,
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.result.data.Id > 0) {
                    swal({
                        text: '',
                        title: '' + response.result.data.Mensaje,
                        type: 'success'
                    },
                        function () {
                            $(location).attr('href', URL.Persona + 'Index');
                        });
                }
            },
            error: function (XMLHttpRequest, success, errorThrown) {
                alert("Error", "NovaSys", XMLHttpRequest.responseText)
            }
        });

        $('#pleaseWaitDialog').modal('hide');
    }
};




window.Persona_ActionEvents = {
    'click .editPersona':     function (e, value, row, index) {
        $(location).attr('href', URL.Persona + 'Edit?pPersonaId=' + row.PersonaId);
    },
    'click .personaContrato': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.PersonaContrato + 'Index?pPersonaId=' + row.PersonaId + '&pNombre=' + row.NombreCompleto);
    },
    'click .removePersona':   function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Persona + 'Delete?pPersonaId=' + row.PersonaId);
    }
};