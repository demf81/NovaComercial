function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
};


function priceFormatter(value) {
    return numberWithCommas(value.toFixed(2));
}


function estatusFormatter(value) {
    return (value == false ? 'Activo' : 'Inactivo')
}


function generoFormatter(value) {
    return (value == true ? 'Masculino' : 'Femenino')
}


function ConvertString_ToDate(str) {
    var month = {
        "01": "Enero",
        "02": "Febrero",
        "03": "Marzo",
        "04": "Abril",
        "05": "Mayo",
        "06": "Junio",
        "07": "Julio",
        "08": "Agosto2",
        "09": "Septiembre",
        "10": "Octubre",
        "11": "Noviembre",
        "12": "Diciembre"
    };
    //var month = { Ene: "01", Feb: "02", Mar: "03", Abr: "04", May: "05", Jun: "06", Jul: "07", Ago: "08", Sep: "09", Oct: "10", Nov: "11", Dic: "12" };
    var from = str.split("-");

    //return new Date(from[2], month[from[1]] - 1, from[0]);
    return from[2] + '-' +  month[from[1]] + '-' + from[0];
};

function GetUrlPrincipal() {
    return $("#txtUrlPrincipal").val();
}