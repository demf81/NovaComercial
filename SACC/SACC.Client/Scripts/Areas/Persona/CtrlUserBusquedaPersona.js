var CtrlUserBusquedaPersona = {
    evento:           null,
    personaEstatusId: 0,
    baja:             0,
    bajaAsociado:     0,
    inicializa:       function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_BUSQUEDA_PERSONA_INDEX') {
            this.limpiarCtrls();

            this.keyEvent();

            this.tabla.inicializa();
        };
    },
    keyEvent:         function () {
        $("#txtCtrlUserNumSocio").on("change paste keyup", function () {
            if ($("#txtCtrlUserNumSocio").val() == "")
                $('span[data-valmsg-for="CtrlUserNumSocio"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserNumSocio"]').text('');
        });

        $("#txtCtrlUserClaveFamiliar").on("change paste keyup", function () {
            if ($("#txtCtrlUserClaveFamiliar").val() == "")
                $('span[data-valmsg-for="CtrlUserClaveFamiliar"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserClaveFamiliar"]').text('');
        });

        $("#txtCtrlUserNombrePersona").on("change paste keyup", function () {
            if ($("#txtCtrlUserNombrePersona").val() == "")
                $('span[data-valmsg-for="CtrlUserNombrePersona"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="CtrlUserNombrePersona"]').text('');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'PersonaId',
                        title:     'Folio',
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
                        field:     'NumSocio',
                        title:     'Num. Socio',
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
                        field:     'Genero',
                        title:     'Género',
                        align:     'left'
                    },
                    {
                        field:     'Edad',
                        title:     'Edad',
                        align:     'center'
                    },
                    {
                        field:     'state',
                        title:     '',
                        checkbox:  true
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pNombre:        $('#txtCtrlUserNombrePersona').val(),
                pNumSocio:      ($('#txtCtrlUserNumSocio').val() == '' ? -1 : $('#txtCtrlUserNumSocio').val()),
                pClaveFamiliar: $('#txtCtrlUserClaveFamiliar').val(),
                pBaja:          CtrlUserBusquedaPersona.baja,
                pBajaAsociado:  CtrlUserBusquedaPersona.bajaAsociado
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Persona + 'CtrlUserBusquedaPersonaJson',
                json
            );

            $('#dgDatosCtrlUserBusquedaPersona').bootstrapTable("load", res.data.Datos);

            if (res.data.Datos.length == 0) {
                //swal("No se encontraton coinsidencias", "", "alert");
                swal({
                    title: "No se encontraton coinsidencias",
                    text: "",
                    type: "info"
                });
            }
        }
    },
    buscar:            function () {
        if (!this.validaBusqueda()) return;

        this.tabla.datos();
    },
    validaBusqueda:    function () {
        if (
            $("#txtCtrlUserNumSocio").val() == ""
            &&
            $("#txtCtrlUserClaveFamiliar").val() == ""
            &&
            $("#txtCtrlUserNombrePersona").val() == ""
        )
        {
            $('span[data-valmsg-for="CtrlUserNumSocio"]').text('Campo Requerido');
            $('span[data-valmsg-for="CtrlUserClaveFamiliar"]').text('Campo Requerido');
            $('span[data-valmsg-for="CtrlUserNombrePersona"]').text('Campo Requerido');

            $("#txtCtrlUserNombrePersona").focus();

            return false;
        }

        return true;
    },
    limpiarCtrls:      function () {
        $('#txtCtrlUserNumSocio').val('');
        $('#txtCtrlUserClaveFamiliar').val('');
        $('#txtCtrlUserNombrePersona').val('');
    }
};