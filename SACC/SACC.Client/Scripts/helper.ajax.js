var Ajax_DataType_Enum = {
    JSON: 'json'
};


var Ajax_Type_Enum = {
    POST: 'post',
    GET:  'get'
};


var Ajax_CtrlType_Enum = {
	GRId:  'grid',
	COMBO: 'combo'
};




function getJSON(pUrl, pData) {
    var strArray = [];

    $.ajax({
        url:         pUrl,
        datatype:    Ajax_DataType_Enum.JSON,
        data:        pData,
        type:        Ajax_Type_Enum.POST,
        async:       false,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.data.MuestraAlert) {
                if (response.data.Error) {
                    if (response.data.TipoMensaje == "error")
                        RunAlert(response.data, RunAlert_Type_Enum.ERROR);
                    else
                        RunAlert(response.data, RunAlert_Type_Enum.WARNING);
                }
                else {
                    RunAlert(response.data, RunAlert_Type_Enum.SUCCESS);
                }
            };

            strArray = response;
        },
        error: function (XMLHttpRequest, satus, errorThrown) {
            //if (XMLHttpRequest.status == 500) {
            //    if (XMLHttpRequest.responseJSON.data.TipoMensaje == "error")
            //        RunAlert(XMLHttpRequest.responseJSON.data, RunAlert_Type_Enum.ERROR);
            //    else
            //        RunAlert(XMLHttpRequest.responseJSON.data, RunAlert_Type_Enum.WARNING);
            //}
            //else {
            //    var strError = '';

            //    switch (XMLHttpRequest.status) {
            //        case 404:
            //            strError = 'Recurso no encontrado';
            //            break;
            //        default:
            //            strError = 'Error no espesificado';
            //    };

            //    var objJSON = {
            //        success: false,
            //        data: {
            //            Id:           -1,
            //            Mensaje:      '',
            //            TipoMensaje:  'error',
            //            TituloError:  'Error JS - El ajax no se pudo procesar',
            //            Error:        true,
            //            MensajeError: strError,
            //            StatusCode:   XMLHttpRequest.status,
            //            MuestraAlert: true,
            //            DelayTime:    false,
            //        }
            //    };

            //    RunAlert(objJSON.data, RunAlert_Type_Enum.ERROR);
            //};

            var strError = '';

            //    switch (XMLHttpRequest.status) {
            //        case 404:
            //            strError = 'Recurso no encontrado';
            //            break;
            //        default:
            //            strError = 'Error no espesificado';
            //    };

            //    var objJSON = {
            //        success: false,
            //        data: {
            //            Id:           -1,
            //            Mensaje:      '',
            //            TipoMensaje:  'error',
            //            TituloError:  'Error JS - El ajax no se pudo procesar',
            //            Error:        true,
            //            MensajeError: strError,
            //            StatusCode:   XMLHttpRequest.status,
            //            MuestraAlert: true,
            //            DelayTime:    false,
            //        }
            //    };

            //    RunAlert(objJSON.data, RunAlert_Type_Enum.ERROR);

            var strError = '';

            switch (XMLHttpRequest.status) {
                case 404:
                    strError = 'Recurso no encontrado';
                    break;
                default:
                    strError = 'Error no espesificado';
            };

            var objJSON = {
                success: false,
                data: {
                    Id:           -1,
                    Mensaje:      '',
                    TipoMensaje:  'error',
                    TituloError:  'Error JS - El ajax no se pudo procesar',
                    Error:        true,
                    MensajeError: strError,
                    StatusCode:   XMLHttpRequest.status,
                    MuestraAlert: true,
                    DelayTime:    false,
                }
            };

            RunAlert(objJSON.data, RunAlert_Type_Enum.ERROR);

            strArray = XMLHttpRequest.responseJSON;
        }
    });

    return strArray;
};