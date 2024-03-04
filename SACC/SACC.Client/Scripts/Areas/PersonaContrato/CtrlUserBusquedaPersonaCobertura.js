var CtrlUserPersonaCobertura = {
    inicializa:     function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_PERSONA_COBERTURA_INDEX') {
            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserPersonaCobertura').bootstrapTable({
                pagination: false,
                search: false,
                columns: [
                    {
                        field:     'PersonaContratoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'PersonaId',
                        title:     'PersonaId',
                        sortable:  true,
                        align:     'left',
                        visible:   false
                    },
                    {
                        field:     'NombreCompleto',
                        title:     'Nombre',
                        align:     'left',
                        visible:   false
                    },
                    {
                        field:     'ContratoId',
                        title:     'ContratoId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:     'PaqueteId',
                        title:     'PaqueteId',
                        align:     'center',
                        visible:   false
                    },
                    {
                        field:    'ContratoDescripcion',
                        title:    'Contrato',
                        sortable: true,
                        align:    'left'
                    },
                    {
                        field:    'ContratoCoberturaId',
                        title:    'ContratoCoberturaId',
                        align:    'center',
                        visible:  false
                    },
                    {
                        field:    'ContratoCoberturaDescripcion',
                        title:    'Cobertura',
                        sortable: true,
                        align:    'left'
                    },
                    {
                        field:    'PaqueteDescripcion',
                        title:    'Paquete',
                        sortable: true,
                        align:    'left'
                    },
                    {
                        field:    'state',
                        title:    '',
                        checkbox: true
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pPersonaId: $('#txtPersonaId').val()
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.PersonaContrato + 'PersonaContratoCoberturaJson',
                json
            );

            $('#dgDatosCtrlUserPersonaCobertura').bootstrapTable("load", res.data.Datos);
        }
    },
    buscar:         function () {
        if (!this.validaBusqueda()) return;

        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtCtrlUserNombrePersona").val() == "") {
            $('span[data-valmsg-for="CtrlUserNombrePersona"]').text('Campo Requerido');
            $("#txtCtrlUserNombrePersona").focus();

            return false;
        }

        return true;
    },
    limpiarCtrls:   function () {
        $('#txtCtrlUserNombrePersona').val('');
    }
}