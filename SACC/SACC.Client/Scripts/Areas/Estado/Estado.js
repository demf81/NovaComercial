var Estado = {
    llenaCombo:               function (pCtrlName, pOpcion, pPaisId) {
        var res = getJSON(
            URL.Estado + "EstadoComboJson?_opcion=" + pOpcion + '&pPaisId=' + pPaisId,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    }
};