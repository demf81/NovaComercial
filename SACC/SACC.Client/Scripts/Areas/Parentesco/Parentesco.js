$(function () {
    Parentesco.inicializa($("#txtApuntadorParentesco").val());
});




var Parentesco = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'PARENTESCO_INDEX') {
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();

            $("[name='checkbox']").bootstrapSwitch({
                on:       'SI',
                off:      'NO',
                onClass:  'success',
                offClass: 'danger',
                size:     'xs'
            });
        };

        if (this.evento == 'PARENTESCO_CREATE') {
            this.keyEvent();
        };

        if (this.evento == 'PARENTESCO_EDIT') {
            this.keyEvent();

            this.cargaDatos();

            if ($("input[name=rbEstatusId][value=1]").prop('checked'))
                this.habilitaDesHabilitaCtrls(false);
            else
                this.habilitaDesHabilitaCtrls(true);
        };

        if (this.evento == 'PARENTESCO_DELETE') {
            this.cargaDatos();

            this.habilitaDesHabilitaCtrls(true);
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pParentescoId: $('#txtParentescoId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Parentesco + 'ParentescoElementoJson',
            json
        );

        if (res != null) {
            $("#txtParentescoDescripcion").val(res.data.Datos[0].ParentescoDescripcion);
            $("#txtClaveFamiliarInicio").val(res.data.Datos[0].ClaveFamiliarInicio);
            $("#txtClaveFamiliarFin").val(res.data.Datos[0].ClaveFamiliarFin);

            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    guardar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ParentescoId: 0,
            ParentescoDescripcion: $("#txtParentescoDescripcion").val(),
            ClaveFamiliarInicio:   $("#txtClaveFamiliarInicio").val(),
            ClaveFamiliarFin:      $("#txtClaveFamiliarFin").val()
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Parentesco + 'Create',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Parentesco.redirecciona('PARENTESCO_INDEX'); }, 2000);
                else
                    this.redirecciona('PARENTESCO_INDEX');
    },
    actualizar: function () {
        if (!this.validaGuardar()) return;

        var _obj = {
            ParentescoId:          $("#txtParentescoId").val(),
            ParentescoDescripcion: $("#txtParentescoDescripcion").val(),
            ClaveFamiliarInicio:   $("#txtClaveFamiliarInicio").val(),
            ClaveFamiliarFin:      $("#txtClaveFamiliarFin").val(),
            EstatusId:             ($("input[name='rbEstatusId'][value=0]:checked").val() ? false : true)
        };

        var objJSON = {
            model: _obj
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Parentesco + 'Edit',
            json
        );

        if (res != null)
            if (!res.data.Error)
                if (res.data.MuestraAlert)
                    setTimeout(function () { Parentesco.redirecciona('PARENTESCO_INDEX'); }, 2000);
                else
                    this.redirecciona('PARENTESCO_INDEX');
    },
    baja: function () {
        swal({
            title:              "¿Estás seguro de eliminar el registro?",
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
                        ParentescoId: $("#txtParentescoId").val()
                    };

                    var objJSON = {
                        model: _obj
                    };

                    var json = JSON.stringify(objJSON, null, 2);

                    var res = getJSON(
                        URL.Parentesco + 'Delete',
                        json
                    );

                    if (res != null)
                        if (!res.data.Error)
                            if (res.data.MuestraAlert)
                                setTimeout(function () { Parentesco.redirecciona('PARENTESCO_INDEX'); }, 2000);
                            else
                                this.redirecciona('PARENTESCO_INDEX');
                }
                else {
                    swal.close();
                }
            });
    },
    keyEvent: function () {
        $("#txtParentescoDescripcion").on("change paste keyup", function () {
            if ($("#txtParentescoDescripcion").val() == "")
                $('span[data-valmsg-for="ParentescoDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ParentescoDescripcion"]').text('');
        });

        $("#txtClaveFamiliarInicio").on("change paste keyup", function () {
            if ($("#txtClaveFamiliarInicio").val() == "")
                $('span[data-valmsg-for="ClaveFamiliarInicio"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ClaveFamiliarInicio"]').text('');
        });

        $("#txtClaveFamiliarFin").on("change paste keyup", function () {
            if ($("#txtClaveFamiliarFin").val() == "")
                $('span[data-valmsg-for="ClaveFamiliarFin"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="ClaveFamiliarFin"]').text('');
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
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.Parentesco + "ParentescoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosParentesco').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'ParentescoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:    'ParentescoDescripcion',
                        title:    'Tipo de Membresia',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'ClaveFamiliarInicio',
                        title:     'Clave Inicio',
                        sortable:  true,
                        //formatter: 'padNumberFormatter',
                        align:     'right'
                    },
                    {
                        field:     'ClaveFamiliarFin',
                        title:     'Clave Fin',
                        sortable:  true,
                        align:     'right'
                    },
                    {
                        field:     'EstatusId',
                        title:     'Estatus',
                        sortable:  false,
                        formatter: 'EstatusFormatter',
                        align:     'center'
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'Parentesco_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pParentescoDescripcion: $('#txtParentescoDescripcion').val(),
                pEstatusId: $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Parentesco + 'ParentescoGridJson',
                json
            );

            $('#dgDatosParentesco').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="editParentesco" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;</span>',
                '<a class="removeParentesco" href="javascript:void(0)" title="Inactivo">',
                '<i class="text-danger fa fa-trash fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtParentescoDescripcion").val() == "") {
            $('span[data-valmsg-for="ParentescoDescripcion"]').text('Campo Requerido');
            $("#txtParentescoDescripcion").focus();

            return false;
        }

        return true;
    },
    validaGuardar: function () {
        if ($("#txtParentescoDescripcion").val() == "") {
            $('span[data-valmsg-for="ParentescoDescripcion"]').text('Campo Requerido');
            $("#txtParentescoDescripcion").focus();

            return false;
        }

        if ($("#txtClaveFamiliarInicio").val() == "") {
            $('span[data-valmsg-for="ClaveFamiliarInicio"]').text('Campo Requerido');
            $("#txtClaveFamiliarInicio").focus();

            return false;
        }

        if ($("#txtClaveFamiliarFin").val() == "") {
            $('span[data-valmsg-for="ClaveFamiliarFin"]').text('Campo Requerido');
            $("#txtClaveFamiliarFin").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('PARENTESCO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'PARENTESCO_INDEX') {
            $.cookie("ParentescoEstatusId", 0);
            $.cookie('ParentescoDescripcion', "");

            $(location).attr('href', URL.Parentesco);
        };

        if (evento == 'PARENTESCO_CREATE') {
            $(location).attr('href', URL.Parentesco + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtParentescoDescripcion').val('');
    },
    habilitaDesHabilitaCtrls: function (estatus) {
        $("#txtParentescoDescripcion").prop("readonly", estatus);
        $("#txtClaveFamiliarInicio").prop("readonly", estatus);
        $("#txtClaveFamiliarFin").prop("readonly", estatus);
    }
};




window.Parentesco_ActionEvents = {
    'click .editParentesco': function (e, value, row, index) {
        $(location).attr('href', URL.Parentesco + 'Edit?pParentescoId=' + row.ParentescoId);
    },
    'click .removeParentesco': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Parentesco + 'Delete?pParentescoId=' + row.ParentescoId);
    }
};