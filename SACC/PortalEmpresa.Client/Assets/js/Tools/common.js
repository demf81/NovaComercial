function AjaxCall(Area, Controlador, Accion, Parametros, Tipo, TipoDato, Callback, EsAsync) {
    $.ajax({
        url: getFullPath(Area, Controlador, Accion),
        contentType: "application/json; charset=utf-8",
        dataType: TipoDato,
        data: Parametros,
        cache: false,
        async: EsAsync,
        success: function (data) {
            if (Callback)
                Callback(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { }
    });
}

function getFullPath(area, controller, action) {
    var path = URLRoot;
    if (typeof (area) !== "undefined" && area !== "") {
        path += area + "/";
    }
    if (typeof (controller) !== "undefined" && controller !== "") {
        path += controller + "/";
    }
    if (typeof (action) !== "undefined" && action !== "") {
        path += action + "/";
    }
    return path;
}
