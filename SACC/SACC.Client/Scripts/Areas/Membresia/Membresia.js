$(function () {
    Membresia.inicializa($("#txtApuntadorMembresia").val());
});




var Membresia = {
    evento:                   null,
    inicializa:               function (evento) {
        this.evento = evento;

        if (this.evento == 'MEMBRESIA_INDEX') {
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

            //$('#datepicker').datepicker();
            //InicializarDtpClass('.input-group.date');
            //$('.input-group.date').datepicker('update', new Date());

            //$("#datepicker").on("changeDate", function (event) {
            //    $("#my_hidden_input").val(
            //        $("#datepicker").datepicker('getFormattedDate')
            //    )
            //});

            MembresiaTipo.llenaCombo('ddlMembresiaTipoId', 'TODOS');

            this.tabla.inicializa();
            this.tabla.datos();

            $('#ddlMembresiaTipoId').val(parseInt($("#txtOpcion").val()));
            $('#ddlMembresiaTipoId').prop('disabled', true);

            //$("[name='checkbox']").bootstrapSwitch({
            //    on:       'SI',
            //    off:      'NO',
            //    onClass:  'success',
            //    offClass: 'danger',
            //    size:     'xs'
            //});
        };

        if (this.evento == 'MEMBRESIA_CREATE') {
            this.keyEvent();

            $('#rootwizard').bootstrapWizard({
                'tabClass': 'nav nav-pills nav-justified'
            });
        };

        if (this.evento == 'MEMBRESIA_EDIT') {
            this.keyEvent();

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'MEMBRESIA_DELETE') {
            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos:               function () {
        var objJSON = {
            pMembresiaId: $('#txtMembresiaId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Membresia + 'MembresiaElementoJson',
            json
        );

        if (res != null) {
            $("#txtMembresiaDescripcion").val(res.data.Datos[0].MembresiaDescripcion);

            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar:                  function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            MembresiaId:         0,
            Fecha:               getDateNow(),
            Vigencia:            getDateNow(),
            MembresiaTipoId:     1,
            ContratanteId:       0,
            CantidadAfiliados:   0,
            CantidadAdicionales: 0,
            NumPedido:           $('#txtNumPedido').val(),
            NumRecibo:           $('#txtNumRecibo').val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Membresia + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Membresia.redirecciona('MEMBRESIA_INDEX', 1); }, 2000);
                else
                    this.redirecciona('MEMBRESIA_INDEX', 1);
    },
    actualizar:               function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            MembresiaId:          $("#txtMembresiaId").val(),
            MembresiaDescripcion: $("#txtMembresiaDescripcion").val(),
            EstatusId:            ($("input[name='rbEstatusId'][value=0]:checked").val() ? false : true)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Membresia + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Membresia.redirecciona('MEMBRESIA_INDEX'); }, 2000);
                else
                    this.redirecciona('MEMBRESIA_INDEX');
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
                        MembresiaId: $("#txtMembresiaId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Membresia + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Membresia.redirecciona('MEMBRESIA_INDEX'); }, 2000);
                            else
                                this.redirecciona('MEMBRESIA_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    actualizarVigencia: function (pMembresiaId, pNumeroSocio) {
        //var _obj = {
        //    pNumeroSocio: $("#pNumeroSocio").val()
        //};

        var objJSON = {
            pMembresiaId: pMembresiaId,
            pNumeroSocio: pNumeroSocio
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Membresia + 'ActualizaVigencia',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Membresia.redirecciona('MEMBRESIA_INDEX', 1); }, 2000);
                else
                    this.redirecciona('MEMBRESIA_INDEX', 1);

    },
    keyEvent:                 function () {
        //$("#txtMembresiaDescripcion").on("change paste keyup", function () {
        //    if ($("#txtMembresiaDescripcion").val() == "")
        //        $('span[data-valmsg-for="MembresiaDescripcion"]').text('Campo Requerido');
        //    else
        //        $('span[data-valmsg-for="MembresiaDescripcion"]').text('');
        //});

        $("#txtNumSocio").keypress(function (e) {
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
        $('#dgDatosMembresia').on('click', 'tbody tr', function (event) {
            var selected = $(this).hasClass("warning");

            $("#dgDatosMembresia tr").removeClass("warning");

            if (!selected)
                $(this).addClass("warning");
            //$(this).addClass('warning').siblings().removeClass('warning');
        });
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosMembresia').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:    'MembresiaId',
                        title:    'Folio',
                        sortable: true,
                        align:    'center'
                    },
                    {
                        field:    'NumSocio',
                        title:    'No. Socio',
                        sortable: true,
                        align:    'center'
                    },
                    {
                        field:    'NombreComplento',
                        title:    'Contratante',
                        sortable: true,
                        align:    'left'
                    },
                    {
                        field:     'NombreTitular',
                        title:     'Titular',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:    'Fecha',
                        title:    'Fecha Alta',
                        sortable: true,
                        align:    'center'
                    },
                    {
                        field:    'Vigencia',
                        title:    'Vigencia',
                        sortable: true,
                        align:    'center'
                    },
                    {
                        field:    'MembresiaTipoDescripcion',
                        title:    'Tipo de Membresia',
                        sortable: true,
                        align:    'left'
                    },
                    {
                        field:    'CantidadAfiliadosRegistrados',
                        title:    'Ben. Reg.',
                        sortable: true,
                        align:    'center'
                    },
                    {
                        field:     'CantidadAfiliadosAmparados',
                        title:     'Ben. Amp.',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'CantidadAdicionales',
                        title:     'CantidadAdicionales',
                        sortable:  true,
                        align:     'center',
                        visible:   false
                    },
                    //{
                    //    field:     'NumPedido',
                    //    title:     'Num. Pedido',
                    //    sortable:  true,
                    //    align:     'left'
                    //},
                    {
                        field:     'NumRecibo',
                        title:     'Num. Recibo',
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
                        events:    'Membresia_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pFechaInicio:     ($("#dtpFechaInicial").val() == "" ? null : $("#dtpFechaInicial").val() ),
                pFechaFin:        ($("#dtpFechaFinal").val() == "" ? null : $("#dtpFechaFinal").val()),
                pVigenciaInicio:  ($("#dtpVigenciaInicial").val() == "" ? null : $("#dtpVigenciaInicial").val()),
                pVigenciaFin:     ($("#dtpVigenciaFinal").val() == "" ? null : $("#dtpVigenciaFinal").val()),
                pMembresiaTipoId: $("#ddlMembresiaTipoId").val(),
                pNombre:          $("#txtNombre").val(),
                pNumSocio:        ($("#txtNumSocio").val() == "" ? -1 : parseInt($("#txtNumSocio").val())),
                pClaveFamiliar:   ($("#txtClaveFamiliar").val() == "" ? -1 : parseInt($("#txtClaveFamiliar").val())),
                pNumRecibo:       ($("#txtNumRecibo").val() == "" ? -1 : parseInt($("#txtNumRecibo").val())),
                pEstatusId:       $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Membresia + 'MembresiaGridJson',
                json
            );

            $('#dgDatosMembresia').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<div class="btn-group">',
                    '<button data-toggle="dropdown" class="btn btn-default btn-sm dropdown-toggle" aria-expanded="false">',
                        '<span><i class="fa fa-ellipsis-h"></i></span>',
                    '</button>',
                    '<ul class="dropdown-menu pull-right">',
                        '<li>',
                            '<a class="printAfiliacion" href="javascript:void(0)">',
                                '<i class="text-primary fa fa-download fa-2x"></i>&nbsp;&nbsp; Descargar',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="actualizaVigencia" href="javascript:void(0)">',
                                '<i class="text-warning fa fa-calendar fa-2x"></i>&nbsp;&nbsp; Actualizar Vigencia',
                            '</a>',
                        '</li>',

                        '<li class= "divider"></li>',

                        '<li>',
                            '<a class="poblacionMembresia" href="javascript:void(0)">',
                                '<i class="text-info fa fa-users fa-2x"></i>&nbsp;&nbsp; Afiliados',
                            '</a>',
                        '</li>',
                    '</ul >',
                '</div>'
            ].join('');
        }
    },
    buscar:                   function () {
        if (!this.validaBusqueda()) return;

        this.tabla.datos();
    },
    validaBusqueda:           function () {
        if ($("#txtMembresiaDescripcion").val() == "") {
            $('span[data-valmsg-for="MembresiaDescripcion"]').text('Campo Requerido');
            $("#txtMembresiaDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar:            function () {
        if ($("#txtNumPedido").val() == "") {
            $('span[data-valmsg-for="NumPedido"]').text('Campo Requerido');
            $("#NumPedido").focus();

            return false;
        }

        if ($("#txtNumRecibo").val() == "") {
            $('span[data-valmsg-for="NumRecibo"]').text('Campo Requerido');
            $("#NumRecibo").focus();

            return false;
        }

        return true;
    },
    limpiar:                  function () {
        this.inicializa('MEMBRESIA_INDEX');
    },
    redirecciona:             function (evento, pOpcion) {
        if (evento == 'MEMBRESIA_INDEX') {
            this.limpiarCtrls();

            $(location).attr('href', URL.Membresia + '?pOpcion=' + pOpcion);
        };

        if (evento == 'MEMBRESIA_CREATE') {
            $(location).attr('href', URL.Membresia + 'Create');
        };
    },
    limpiarCtrls:             function () {
        $('#dtpFechaInicial').val('');
        $('#dtpFechaFinal').val('');

        $('#dtpVigenciaInicial').val('');
        $('#dtpVigenciaFinal').val('');

        $('#txtNombre').val('');
        $('#txtNumSocio').val('');
        $('#txtClaveFamiliar').val('');

        $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        $("input[name=rbEstatusId][value=3]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', false).iCheck('update');

        $("#txtNumRecibo").val('');
    },
    habilitaDesHabilitaCtrls: function (isDisabled) {
        DisabledEneableElement('txtMembresiaDescripcion', isDisabled);
    }
};




window.Membresia_ActionEvents = {
    //'click .editMembresia': function (e, value, row, index) {
    //    $(location).attr('href', URL.Membresia + 'Edit?pMembresiaId=' + row.MembresiaId);
    //},
    'click .poblacionMembresia': function (e, value, row, index) {
        //if (row.MembresiaEstatusId == 3) {
        //    swal('La membresia esta suspendida.', '', 'info');
        //    return;
        //};

        $(location).attr('href', URL.MembresiaPersona + 'Index?pMembresiaId=' + row.MembresiaId + '&pNumSocio=' + row.NumSocio + '&pContratante=' + row.NombreComplento + '&pCantidadAfiliadosRegistrados=' + row.CantidadAfiliadosRegistrados + '&pCantidadAfiliadosAmparados=' + row.CantidadAfiliadosAmparados + '&pCantidadAdicional=' + row.CantidadAdicionales + '&pMembresiaEstatusId=' + row.MembresiaEstatusId);
    },
    'click .printAfiliacion': function (e, value, row, index) {
        $(location).attr('href', URL.Membresia + 'CreatePDFJson?pMembresiaId=' + row.MembresiaId);
    },
    'click .actualizaVigencia': function (e, value, row, index) {
        if (row.MembresiaEstatusId == 3) {
            swal('La membresia esta suspendida.', '', 'info');
            return;
        };

        if (row.NumSocio == '000000-31') {
            swal('Debe agregar al menos un socio a la membresia.', '', 'warning');
            return;
        };

        Membresia.actualizarVigencia(row.MembresiaId, row.NumSocio);
    },
    'click .liveLineMembresia': function (e, value, row, index) {
        $("#myModalLineaVida").modal();
    }
};