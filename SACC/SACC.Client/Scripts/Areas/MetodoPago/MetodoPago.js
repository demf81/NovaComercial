var MetodoPago = {
    llenaCombo: function (pCtrlName, pOpcion) {
        var res = getJSON(
            URL.MetodoPago + "MetodoPagoComboJson?_opcion=" + pOpcion,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    }
};