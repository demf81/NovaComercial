var CtrlUserEmpresaCoberturaCondicion = {
    evento:     null,
    inicializa: function (evento, pEmpresaId) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_EMPRESA_COBERTURA_CONDICION') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            EmpresaContrato.llenaCombo('ddlEmpresaContratoId', 'SELECCIONE', pEmpresaId);

            $('#dgDatosEmpresaContratoCoberturaCondicion').bootstrapTable('removeAll');
            this.tablaEmpresaContratoCoberturaCondicion.inicializa();

            this.tablaEmpresaContratoCoberturaConsumo.inicializa();
        };

        if (this.evento == 'CTRL_USER_CONTRATO_COBERTURA_CONDICION_PERSONA') {
            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            this.tablaCoberturaConsumo.inicializa();
            this.tablaCoberturaConsumo.datos();
        };

    },
    keyEvent:   function () {
        $('#ddlEmpresaContratoId').change(function () {
            if ($('#ddlContrato  option:selected').text() == "[Seleccione...]") {
                $('span[data-valmsg-for="EmpresaContratoId"]').text('Campo Requerido');
            }
            else {
                $('span[data-valmsg-for="EmpresaContratoId"]').text('');

                CtrlUserEmpresaCoberturaCondicion.tablaEmpresaContratoCoberturaCondicion.datos();
            };
        });
    },
    tablaEmpresaContratoCoberturaCondicion: {
        inicializa: function () {
            $('#dgDatosEmpresaContratoCoberturaCondicion').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field: 'PaqueteDescripcion',
                        title: 'Cobertura',
                        align: 'left'
                    },
                    {
                        field: 'CoberturaCondicion',
                        title: 'Condición',
                        align: 'left'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pContratoId: $('#ddlEmpresaContratoId').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ContratoCoberturaPaquete + 'ContratoCoberturaPaquetePorContrato',
                json
            );

            $('#dgDatosEmpresaContratoCoberturaCondicion').bootstrapTable("load", res.data.Datos);
        }
    },
    tablaEmpresaContratoCoberturaConsumo: {
        inicializa: function () {
            $('#dgDatosEmpresaContratoCoberturaConsumo').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field: 'CoberturaDescripcion',
                        title: 'Cobertura',
                        align: 'left'
                    },
                    {
                        field: 'CondicionDescripcion',
                        title: 'Condición',
                        align: 'left'
                    }
                    ,
                    {
                        field: 'Consumo',
                        title: 'Consumo',
                        align: 'center'
                    }
                    ,
                    {
                        field: 'Disponible',
                        title: 'Disponible',
                        align: 'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pContratoId: $('#txtModalContratoId').val(),
                pPersonaId: $("#txtModalPersonaId").val()
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.ContratoCobertura + 'ContratoCoberturaConsumo',
                json
            );

            $('#dgDatosCoberturaAtencionExterna').bootstrapTable("load", res.data.Datos);
        }
    }
};