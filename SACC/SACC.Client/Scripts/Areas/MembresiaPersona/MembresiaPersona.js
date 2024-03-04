$(function () {
    MembresiaPersona.inicializa($("#txtApuntadorMembresiaPersona").val());
});




var MembresiaPersona = {
    evento:           null,
    inicializa:       function (evento) {
        this.evento = evento;

        if (this.evento == 'MEMBRESIA_PERSONA_INDEX') {
            this.limpiarCtrls();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.tabla.inicializa();
            this.tabla.datos();

            $("#txtAfiliados").text("La membresia ampara " + $("#txtCantidadAfiliadosAmparados").val() + " afiliados y " + $("#txtCantidadAdicional").val() + " adicionales");

            var data = $('#dgDatosMembresiaPersona').bootstrapTable('getData');

            if (data.length == 1)
                $("#txtAfiliadosRegistradosEnGrid").text(data.length + " Afiliado registrado");
            else
                $("#txtAfiliadosRegistradosEnGrid").text(data.length + " Afiliados registrados");

            if (parseInt($('#txtMembresiaEstatusId').val()) != 3) {
                $('#btnAgregar').removeAttr('disabled');
            };
            //$("[name='checkbox']").bootstrapSwitch({
            //    on:       'SI',
            //    off:      'NO',
            //    onClass:  'success',
            //    offClass: 'danger',
            //    size:     'xs'
            //});
        };

        if (this.evento == 'MEMBRESIA_PERSONA_CREATE') {
            this.keyEvent();
        };

        if (this.evento == 'MEMBRESIA_PERSONA_EDIT') {
            this.keyEvent();

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'MEMBRESIA_PERSONA_DELETE') {
            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    guardar:          function () {
        if (!this.validaGuardar()) return;

        var _data        = $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('getSelections');
        var _persona     = {};
        var listaPersona = [];

        for (i = 0; i < _data.length; i++) {
            _persona = {
                MembresiaPersonaId:   0,
                MembresiaId:          $("#txtMembresiaId").val(),
                PersonaId:            _data[i].PersonaId,
                NumSocio:             _data[i].NumSocio
            };

            listaPersona.push(_persona);

            _persona = {};
        }

        var objJSON = {
            Lista: listaPersona
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.MembresiaPersona + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { MembresiaPersona.redirecciona('MEMBRESIA_PERSONA_INDEX'); }, 2000);
                else
                    this.redirecciona('MEMBRESIA_PERSONA_INDEX');
    },
    baja:             function (pMembresiaPersonaId) {
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
                    MembresiaPersonaId: pMembresiaPersonaId
                };

                var objJSON = {
                    model: _obj
                };

                var json = JSON.stringify(objJSON, null, 2);

                var res = getJSON(
                    URL.MembresiaPersona + 'Delete',
                    json
                );

                if (res != null)
                    if (!res.data.Error)
                        if (res.data.MuestraAlert)
                            setTimeout(function () { MembresiaPersona.redirecciona('MEMBRESIA_PERSONA_INDEX'); }, 2000);
                        else
                            this.redirecciona('MEMBRESIA_PERSONA_INDEX');
            }
            else {
                swal.close();
            }
        });
    },
    keyEvent:         function () {
        $("#txtMembresiaPersonaDescripcion").on("change paste keyup", function () {
            if ($("#txtMembresiaPersonaDescripcion").val() == "")
                $('span[data-valmsg-for="MembresiaPersonaDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="MembresiaPersonaDescripcion"]').text('');
        });
    },
    keyEventGrid: function () {
        $('#dgDatosContrato').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosContrato tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosMembresiaPersona').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'MembresiaPersonaId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'MembresiaId',
                        title:     'MembresiaId',
                        sortable:  true,
                        align:     'center',
                        visible:    false
                    },
                    {
                        field:     'PersonaId',
                        title:     'PersonaId',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'NumSocio',
                        title:     'Num Socio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'NombreCompleto',
                        title:     'Nombre',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Edad',
                        title:     'Edad',
                        sortable:  true,
                        align:     'center'
                    },
                    //{
                    //    field:     'ParentescoDescripcion',
                    //    title:     'Parentesco',
                    //    sortable:  true,
                    //    align:     'center'
                    //},
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
                        sortable:  false,
                        formatter: 'EstatusIdFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'MembresiaPersona_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pMembresiaId: $('#txtMembresiaId').val(),
                pEstatusId:   1
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.MembresiaPersona + 'MembresiaPersonaGridJson',
                json
            );

            $('#dgDatosMembresiaPersona').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                //'<a class="editMembresiaPersona" href="javascript:void(0)" title="Editar">',
                //'<i class="text-success fa fa-pencil fa-2x"></i>',
                //'</a>',
                //'<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeMembresiaPersona" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-times fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    validaBusqueda:   function () {
        if ($("#txtMembresiaPersonaDescripcion").val() == "") {
            $('span[data-valmsg-for="MembresiaPersonaDescripcion"]').text('Campo Requerido');
            $("#txtMembresiaPersonaDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:    function () {
        var CantidadEnGrid       = 0;
        var CantidadAmparada     = 0;
        var CantidadAdicional    = 0;
        var CantidadSeleccionada = 0;

        var data = $('#dgDatosMembresiaPersona').bootstrapTable('getData');

        CantidadEnGrid    = data.length;
        CantidadAmparada  = parseInt($('#txtCantidadAfiliadosAmparados').val());
        CantidadAdicional = parseInt($('#txtCantidadAdicional').val());

        var _data = $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('getSelections');

        CantidadSeleccionada = _data.length;

        if (_data.length == 0) {
            swal("Debe seleccionar una persona", "", "warning");

            return;
        }

        if ((CantidadEnGrid + CantidadSeleccionada) > (CantidadAmparada + CantidadAdicional)) {
            swal("La cantidad de personas por agregar es mayor a las personas contratadas en la membresía.", "", "warning");

            return;
        }

        if ($('#ddlCtrlUserParentescoId option:selected').text() == "[Seleccione...]") {
            $('span[data-valmsg-for="CtrlUserParentescoId"]').text('Campo Requerido');
            $("#ddlCtrlUserParentescoId").focus();

            return false;
        };

        return true;
    },
    limpiar:          function () {
        this.inicializa('MEMBRESIA_PERSONA_INDEX');
    },
    redirecciona:     function (evento) {
        if (evento == 'MEMBRESIA_INDEX') {
            $(location).attr('href', URL.Membresia + '?pOpcion=1');
        };

        if (evento == 'MEMBRESIA_PERSONA_INDEX') {
            $(location).attr('href', URL.MembresiaPersona + 'Index?pMembresiaId=' + $('#txtMembresiaId').val() + '&pNumSocio=' + $('#txtNumSocio').val() + '&pContratante=' + $('#txtContratante').val() + '&pCantidadAfiliadosRegistrados=' + $('#txtCantidadAfiliadosRegistrados').val() + '&pCantidadAfiliadosAmparados=' + $("#txtCantidadAfiliadosAmparados").val() + '&pCantidadAdicional=' + $("#txtCantidadAdicional").val() + '&pMembresiaEstatusId=' + $("#txtMembresiaEstatusId").val());
        };

        if (evento == 'MEMBRESIA_PERSONA_CREATE') {
            $(location).attr('href', URL.MembresiaPersona + 'Create');
        };
    },
    limpiarCtrls:     function () {
        $('#txtMembresiaPersonaDescripcion').val('');
    },
    //habilitaDesHabilitaCtrls: function (isDisabled) {
    //    DisabledEneableElement('#txtMembresiaPersonaDescripcion', isDisabled);
    //},
    AbreModalPersona: function () {
        var CantidadEnGrid    = 0;
        var CantidadAmparada  = 0;
        var CantidadAdicional = 0;
        var data              = $('#dgDatosMembresiaPersona').bootstrapTable('getData');

        CantidadEnGrid    = data.length;
        CantidadAmparada  = parseInt($('#txtCantidadAfiliadosAmparados').val());
        CantidadAdicional = parseInt($('#txtCantidadAdicional').val());

        if (CantidadEnGrid == (CantidadAmparada + CantidadAdicional)) {
            swal('La membresia ya tiene todos sus beneficiarios registrados.', '', 'info');

            return;
        };

        $("#myModalBusquedaPersona").modal();

        $("#txtPersonaId").val("");
        $("#txtNombrePersona").val("");

        $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('removeAll');

        CtrlUserBusquedaPersona.baja         = 0;
        CtrlUserBusquedaPersona.bajaAsociado = 0;
        CtrlUserBusquedaPersona.inicializa("CTRL_USER_BUSQUEDA_PERSONA_INDEX");
    },
    AgregarPersona:   function () {
        var data = $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable('getSelections');

        //if ((data.length >= 2) || (data.length == 0)) {
        //    swal("Debe seleccionar una persona", "", "warning");

        //    return;
        //}

        this.guardar();

        $("#myModalBusquedaPersonaParentesco").modal("toggle");
    },
};




window.MembresiaPersona_ActionEvents = {
    'click .editMembresiaPersona': function (e, value, row, index) {
        $(location).attr('href', URL.MembresiaPersona + 'Edit?pMembresiaPersonaId=' + row.MembresiaPersonaId);
    },
    'click .removeMembresiaPersona': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        MembresiaPersona.baja(row.MembresiaPersonaId);

        //$(location).attr('href', URL.MembresiaPersona + 'Delete?pMembresiaPersonaId=' + row.MembresiaPersonaId);
    }
};