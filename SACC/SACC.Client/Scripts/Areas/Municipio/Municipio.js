var Municipio = {
    llenaCombo: function (pCtrlName, pOpcion, pPaisId, pEstadoId) {
        var res = getJSON(
            URL.Municipio + "MunicipioComboJson?_opcion=" + pOpcion + '&pPaisId=' + pPaisId + '&pEstadoId=' + pEstadoId,
            null
        );

        $("#" + pCtrlName).empty();

        for (var i = 0; i < res.data.Lista.length; i++) {
            $("#" + pCtrlName).append($("<option></option>").attr("value", res.data.Lista[i].Value).text(res.data.Lista[i].Text));
        };
    }
};