var RunAlert_TipoAlerta_Enum = {
    SIMPLE:  'simple',
    CONFIRM: 'confirm'
};

var RunAlert_Type_Enum = {
    SUCCESS: 'success',
    WARNING: 'warning',
    ERROR:   'error'
};




function RunAlert(pData, pAlertType) {
    switch (pAlertType) {
        case 'error':
            showModalError(pData.MensajeError, pData.TituloError, pData.DelayTime);
            break;
        case 'warning':
            showModalWarning(pData.MensajeError, pData.TituloError, pData.DelayTime);
            break;
        case 'success':
            showModalSuccess(pData.Mensaje, pData.TituloError, pData.DelayTime);
            break;
        default:
            break;
    }
};




function showModalError(pTexto, pStatusText, pDelayTime) {
    $("#txtAlertError_StatusCode").empty();
    $("#txtAlertError_StatusCode").append(pStatusText);


    $("#txtAlertError_StatusText").empty();
    $("#txtAlertError_StatusText").append(pTexto);


    $("#myModalAlertError").modal('show');


    if (pDelayTime)
        setTimeout(function () { $("#myModalAlertError").modal('hide'); }, 2000);
};




function showModalWarning(pTexto, pStatusText, pDelayTime) {
    $("#txtAlertWarning_StatusCode").empty();
    $("#txtAlertWarning_StatusCode").append(pStatusText);


    $("#txtAlertWarning_StatusText").empty();
    $("#txtAlertWarning_StatusText").append(pTexto);


    $("#myModalAlertWarning").modal('show');


    if (pDelayTime)
        setTimeout(function () { $("#myModalAlertWarning").modal('hide'); }, 2000);
};




function showModalSuccess(pTexto, pStatusText, pDelayTime) {
    $("#txtAlertSuccess_StatusText").empty();
    $("#txtAlertSuccess_StatusText").append(pTexto);


    $("#myModalAlertSuccess").modal('show');


    if (pDelayTime)
        setTimeout(function () { $("#myModalAlertSuccess").modal('hide'); }, 2000);
};