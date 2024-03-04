$(function () {
    Estudio.inicializa($("#txtApuntadorEstudio").val());
});




var Estudio = {
    evento:     null,
    inicializa: function (evento) {
        this.evento = evento;

        if (this.evento == 'ESTUDIO_INDEX') {
            this.keyEvent();
            this.limpiarCtrls();

            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    cargaDatos: function () {
        var objJSON = {
            pEstudioId: $('#txtEstudioId').val()
        };

        var json = JSON.stringify(objJSON, null, 2);

        var res = getJSON(
            URL.Estudio + 'EstudioElementoJson',
            json
        );

        if (res != null) {
            $("#txtEstudioDescripcion").val(res.data.Datos[0].EstudioDescripcion);


            if (res.data.Datos[0].EstatusId == 1)
                $("input[name=rbEstatusId][value=1]").prop('checked', true).iCheck('update');
            else
                $("input[name=rbEstatusId][value=2]").prop('checked', true).iCheck('update');
        }
    },
    keyEvent: function () {
        $("#txtEstudioDescripcion").on("change paste keyup", function () {
            if ($("#txtEstudioDescripcion").val().trim() == "")
                $('span[data-valmsg-for="EstudioDescripcion"]').text('Campo Requerido');
            else
                $('span[data-valmsg-for="EstudioDescripcion"]').text('');
        });
    },
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.Estudio + "EstudioComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosEstudio').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:    'EstudioId',
                        title:    'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'EstudioDescripcion',
                        title:     'Descripción',
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
                        events:    'Estudio_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos: function () {
            var objJSON = {
                pEstudioDescripcion: $('#txtEstudioDescripcion').val().trim(),
                pEstatusId:          $('#rbEstatusId:checked').val(),
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.Estudio + 'EstudioGridJson',
                json
            );

            $('#dgDatosEstudio').bootstrapTable("load", res.data.Datos);
        },
        accion: function (value, row, index) {
            return [
                '<a class="viewEstudio" href="javascript:void(0)" title="Visualizar">',
                '<i class="text-info fa fa-search fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
    buscar: function () {
        if (!this.validaBusqueda()) return;

        this.tabla.inicializa();
        this.tabla.datos();
    },
    validaBusqueda: function () {
        if ($("#txtEstudioDescripcion").val().trim() == "") {
            $('span[data-valmsg-for="EstudioDescripcion"]').text('Campo Requerido');
            $("#txtEstudioDescripcion").focus();

            return false;
        }

        return true;
    },
    limpiar: function () {
        this.inicializa('ESTUDIO_INDEX');
    },
    redirecciona: function (evento) {
        if (evento == 'ESTUDIO_INDEX') {
            $(location).attr('href', URL.Estudio);
        };

        if (evento == 'ESTUDIO_CREATE') {
            $(location).attr('href', URL.Estudio + 'Create');
        };
    },
    limpiarCtrls: function () {
        $('#txtEstudioDescripcion').val('');

        $('span[data-valmsg-for="EstudioDescripcion"]').text('');

        $("input[name=rbEstatusId][value=1]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=2]").prop('checked', false).iCheck('update');
        $("input[name=rbEstatusId][value=-1]").prop('checked', true).iCheck('update');
    },
};




window.Estudio_ActionEvents = {
    'click .viewEstudio': function (e, value, row, index) {
        $(location).attr('href', URL.Estudio + 'Visualizer?pEstudioId=' + row.EstudioId);
    }
};




//$(function () {
//    $('#dgDatosEstudio').bootstrapTable({});
//});

//function GridEstudio(pEstudioDescripcion, pEstatusId) {
//    var objJSON = {
//        pEstudioDescripcion: pEstudioDescripcion,
//        pEstatusId:          pEstatusId
//    };

//    var json = JSON.stringify(objJSON, null, 2);

//    var res = getJSON(
//        URL.Estudio + 'EstudioGridJson',
//        json
//    );

//    $('#dgDatosEstudio').bootstrapTable("load", res.data.Datos);
//};

//function RegresarEstudio() {
//    $.cookie("estudioEstatusId", 0);
//    $.cookie('estudioDescripcion', "");

//    $(location).attr('href', URL.Estudio + 'Index');
//}

//function operateActionFormatter_Estudio(value, row, index) {
//    return [
//        '<a class="view" href="' + URL.Estudio + 'View?pEstudioId=' + row.EstudioId + '" title="Visualizar">',
//        '<i class="text-info fa fa-search fa-lg"></i>',
//        '</a>'
//    ].join('');
//};