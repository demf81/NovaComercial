$(function () {
    MembresiaRenovacion.inicializa($("#txtApuntadorMembresiaRenovacion").val());
});




var MembresiaRenovacion = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'MEMBRESIA_RENOVACION_INDEX') {
            this.keyEventIndex();
            this.limpiarCtrls();

            InicializarDtp('dtpFechaInicial');
            InicializarDtp('dtpFechaFinal');

            InicializarDtp('dtpVigenciaInicial');
            InicializarDtp('dtpVigenciaFinal');

            $("#datepicker").on("changeDate", function (event) {
                $("#my_hidden_input").val(
                    $("#datepicker").datepicker('getFormattedDate')
                )
            });

            MembresiaTipo.llenaCombo('ddlMembresiaTipoId', 'TODOS', '');

            this.tabla.inicializa();
            this.tabla.datos();

            $('#ddlMembresiaTipoId').val(parseInt($("#txtOpcion").val()));
            $('#ddlMembresiaTipoId').prop('disabled', true);
        };

        if (this.evento == 'MEMBRESIA_RENOVACION_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });

            MembresiaTipo.llenaCombo('ddlMembresiaTipoId', 'SELECCIONE', '');

            this.cargaDatos();
        };
    },
    cargaDatos:               function () {
        var objJSON = {
            pMembresiaId: $('#txtMembresiaId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.MembresiaRenovacion + 'MembresiaRenovacionElementoQJson',
            json
        );

        if (res != null) {
            $("#ddlMembresiaTipoId").val(res.data.Datos[0].MembresiaTipoId);
            $("#txtContratante").val(res.data.Datos[0].Contratante);
            $("#txtFechaContrato").val(formatFecha(res.data.Datos[0].FechaContrato));
            $("#txtFechaVencimiento").val(formatFecha(res.data.Datos[0].FechaVigencia));
            $("#txtCantidadAfiliados").val(res.data.Datos[0].CantidadAfiliados);
            $("#txtCantidadAdicionales").val(res.data.Datos[0].CantidadAdicionales);
        }
    },
    guardar:                  function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            MembresiaRenovacionId: 0,
            MembresiaId:           $("#txtMembresiaId").val(),
            NumPedido:             $("#txtNumPedido").val(),
            NumRecibo:             $("#txtNumRecibo").val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.MembresiaRenovacion + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { MembresiaRenovacion.redirecciona('MEMBRESIA_RENOVACION_INDEX'); }, 2000);
                else
                    this.redirecciona('MEMBRESIA_RENOVACION_INDEX');
    },
    keyEvent:                 function () {
        $("#txtNumPedido").on("change paste keyup", function () {
            if ($("#txtNumPedido").val() == "")
                $('span[data-valmsg-for="NumPedido"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="NumPedido"]').text('');
        });

        $("#txtNumRecibo").on("change paste keyup", function () {
            if ($("#txtNumRecibo").val() == "")
                $('span[data-valmsg-for="NumRecibo"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="NumRecibo"]').text('');
        });

        $("#txtNumPedido").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });

        $("#txtNumRecibo").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 46 || e.which > 58)) {
                return false;
            }
        });
    },
    keyEventIndex:            function () {
        $('#dgDatosMembresiaRenovacion').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosMembresiaRenovacion tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosMembresiaRenovacion').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'MembresiaId',
                        title:     'Folio',
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
                        field:     'NombreComplento',
                        title:     'Contratante',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'NombreTitular',
                        title:     'Titular',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Fecha',
                        title:     'Fecha Alta',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'Vigencia',
                        title:     'Vigencia',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'MembresiaTipoDescripcion',
                        title:     'Tipo de Membresia',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'CantidadBeneficiarios',
                        title:     'Cant. Beneficiarios',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'MembresiaEstatusId',
                        title:     'Activo',
                        formatter: 'MembresiaEstatusIdFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        formatter: this.accion(),
                        events:    'MembresiaRenovacion_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pFechaInicio:     ($("#dtpFechaInicial").val() == "" ? null : $("#dtpFechaInicial").val()),
                pFechaFin:        ($("#dtpFechaFinal").val() == "" ? null : $("#dtpFechaFinal").val()),
                pVigenciaInicio:  ($("#dtpVigenciaInicial").val() == "" ? null : $("#dtpVigenciaInicial").val()),
                pVigenciaFin:     ($("#dtpVigenciaFinal").val() == "" ? null : $("#dtpVigenciaFinal").val()),
                pMembresiaTipoId: $("#ddlMembresiaTipoId").val(),
                pNumSocio:        ($("#txtNumSocio").val() == "" ? -1 : parseInt($("#txtNumSocio").val())),
                pEstatusId:       3,
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.MembresiaRenovacion + 'MembresiaRenovacionGridJson',
                json
            );

            $('#dgDatosMembresiaRenovacion').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<a class="registMembresiaRenovacion" href="javascript:void(0)" title="Registrar Pago">',
                '<i class="text-success fa fa-money fa-2x"></i>',
                '</a>',
            ].join('');
        }
    },
    buscar:                   function () {
        if (!this.validaBusqueda()) return;

        this.tabla.datos();
    },
    validaBusqueda:           function () {
        if ($("#txtMembresiaRenovacionDescripcion").val() == "") {
            $('span[data-valmsg-for="MembresiaRenovacionDescripcion"]').text('Campo Requerido');
            $("#txtMembresiaRenovacionDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:            function () {
        if ($("#txtNumPedido").val() == "") {
            $('span[data-valmsg-for="NumPedido"]').text('Campo Requerido');
            $("#txtNumPedido").focus();

            return false;
        }

        if ($("#txtNumRecibo").val() == "") {
            $('span[data-valmsg-for="NumRecibo"]').text('Campo Requerido');
            $("#txtNumRecibo").focus();

            return false;
        }

        return true;
    },
    limpiar:                  function () {
        this.inicializa('MEMBRESIA_RENOVACION_INDEX');
    },
    redirecciona:             function (evento) {
        if (evento == 'MEMBRESIA_RENOVACION_INDEX') {
            $(location).attr('href', URL.MembresiaRenovacion + '?pOpcion=1');
        };

        if (evento == 'MEMBRESIA_RENOVACION_CREATE') {
            $(location).attr('href', URL.MembresiaRenovacion + 'Create');
        };
    },
    limpiarCtrls:             function () {
        $('#dtpFechaInicial').val('');
        $('#dtpFechaFinal').val('');

        $('#dtpVigenciaInicial').val('');
        $('#dtpVigenciaFinal').val('');

        $('#txtNumSocio').val('');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtMembresiaRenovacionDescripcion', isDisabled);
    }
};




window.MembresiaRenovacion_ActionEvents = {
    'click .registMembresiaRenovacion': function (e, value, row, index) {
        $(location).attr('href', URL.MembresiaRenovacion + 'Create?pMembresiaId=' + row.MembresiaId);
    },
};