var Home = {
    evento: null,
    Autentica: function (pCuentaREd, pUsuario, pContrasenia) {
        if (!this.validaAutenticar()) return;

        var objJSON = {
            pMaterialId: $('#txtMaterialId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Material + 'MaterialElementoJson',
            json
        );

        if (res != null) {
            $("#txtMaterialDescripcion").val(res.data.Datos[0].MaterialDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    validaAutenticar: function () {
        if ($("#txtDominio").val().trim() == "") {
            $('span[data-valmsg-for="Dominio"]').text('Campo Requerido');
            $("#txtDominio").focus();

            return false;
        }

        if ($("#txtCuentaRed").val().trim() == "") {
            $('span[data-valmsg-for="CuentaRed"]').text('Campo Requerido');
            $("#txtCuentaRed").focus();

            return false;
        }

        if ($("#txtContrasenia").val().trim() == "") {
            $('span[data-valmsg-for="Contrasenia"]').text('Campo Requerido');
            $("#txtContrasenia").focus();

            return false;
        }

        return true;
    },


    keyEvent: function () {
        $("#txtMaterialDescripcion").on("change paste keyup", function () {
            if ($("#txtMaterialDescripcion").val().trim() == "")
                $('span[data-valmsg-for="MaterialDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="MaterialDescripcion"]').text('');
        });
    },
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.Material + "MaterialComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosMaterial').bootstrapTable({
                pagination: true,
                search: false,
                columns: [
                    {
                        field: 'MaterialId',
                        title: 'Folio',
                        sortable: true,
                        align: 'center'
                    },
                    {
                        field: 'MaterialDescripcion',
                        title: 'Tipo de Membresia',
                        sortable: true,
                        align: 'left'
                    },
                    {
                        field: 'EstatusId',
                        title: 'Activo',
                        sortable: false,
                        formatter: 'EstatusIdFormatter',
                        align: 'center'
                    },
                    {
                        field: '',
                        title: 'Acción',
                        sortable: true,
                        formatter: this.accion(),
                        events: 'Material_ActionEvents',
                        align: 'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pMaterialDescripcion: $('#txtMaterialDescripcion').val().trim(),
                pEstatusId: $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Material + 'MaterialGridJson',
                json
            );

            $('#dgDatosMaterial').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="viewMaterial" href="javascript:void(0);" title="Visualizar">',
                '<i class="text-info fa fa-search fa-lg"></i>',
                '</a>',
            ].join('');
        }
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtMaterialDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="MaterialDescripcion"]').text('Campo Requerido');
            $("#txtMaterialDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('MATERIAL_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'MATERIAL_INDEX') {
            $(location).attr('href', URL.Material);
        };

        if (evento == 'MATERIAL_CREATE') {
            $(location).attr('href', URL.Material + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtMaterialDescripcion').val('');

        $('span[data-valmsg-for="MaterialDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
};