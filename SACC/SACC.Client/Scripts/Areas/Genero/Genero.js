//$(function () {
//    Genero.inicializa($("#txtApuntadorGenero").val());
//});




var Genero = {
    evento: null,
    inicializa: function (evento) {
        this.evento = evento;
    },
    llenaCombo: function (pCtrlName, pOpcion, pOrigen) {
        var res = getJSON(
            URL.Genero + "GeneroComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    }
};