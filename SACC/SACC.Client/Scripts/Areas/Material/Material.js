$(function () {
    Material.inicializa($("#txtApuntadorMaterial").val());
});




var Material = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'MATERIAL_INDEX') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    cargaDatos: function () {
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
                search:     false,
                columns: [
                    {
                        field:     'MaterialId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'MaterialDescripcion',
                        title:     'Tipo de Membresia',
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
                        field:     '',
                        title:     'Acción',
                        sortable:  true,
                        formatter: this.accion(),
                        events:    'Material_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pMaterialDescripcion: $('#txtMaterialDescripcion').val().trim(),
                pEstatusId:           $('#rbEstatusId:checked').val(),
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




window.Material_ActionEvents = {
    'click .viewMaterial': function (e, value, row, index) {
        $(location).attr('href', URL.Material + 'Visualizer?pMaterialId=' + row.MaterialId);
    },
    'click .removeMaterial': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.Material + 'Delete?pMaterialId=' + row.MaterialId);
    }
};


//$(function () {
//    $('#dgDatosMaterial').bootstrapTable({});
//});

//function GridMaterial(pMaterialDescripcion, pEstatusId) {
//    var objJSON = {
//        pMaterialDescripcion: pMaterialDescripcion,
//        pEstatusId:           pEstatusId
//    };

//    var json = JSON.stringify(objJSON, null, 2);

//    var res = getJSON(
//        URL.Material + 'MaterialGridJson',
//        json
//    );

//    $('#dgDatosMaterial').bootstrapTable("load", res.data.Datos);
//};

//function RegresarMaterial() {
//    $.cookie("materialEstatusId", 0);
//    $.cookie('materialDescripcion', "");

//    $(location).attr('href', URL.Medicamento + 'Index');
//}

//function operateActionFormatter_Material(value, row, index) {
//    return [
//        '<a class="view" href="' + URL.Material + 'View?pMaterialId=' + row.MaterialId + '" title="Visualizar">',
//        '<i class="text-info fa fa-search fa-lg"></i>',
//        '</a>'
//    ].join('');
//};