function ClienteEstatusIdFormatter(value, ClienteId) {
    return '<input type="checkbox" id="toggle-demo" data-size="sm">'
    if (value == 1)
        return '<input type="checkbox" checked id="toggle-Cliente' + ClienteId + '"data-toggle="toggle" data-onstyle="success" data-offstyle="danger" data-on="SI" data-off="NO"  data-size="sm">'
        //'<h4 class="h45"><span class="label label-success">Si</span></h4>'
        //'<input type="checkbox" name="checkbox" checked="checked" data-on-color="success" data-off-color="danger" data-on-text="Si" data-off-text="No">'
    else
        return '<input type="checkbox" id="toggle-Cliente' + ClienteId + '" data-toggle="toggle" data-onstyle="success" data-offstyle="danger" data-on="SI" data-off="NO"  data-size="sm">'
    //    //'<h4 class="h45"><span class="label label-danger">No</span></h4 >'
    //    //'<input type="checkbox" name="checkbox" checked                  data-on-color="success" data-off-color="danger" data-on-text="Si" data-off-text="No">'
};




function EstatusTieneCondicion(value) {
    if (value == true)
        return '<h4 class="h45"><span class="label label-success">SI</span></h4>'
    else
        return '<h4 class="h45"><span class="label label-primary">NO</span></h4 >'
};




function EstatusTieneExclusion(value) {
    if (value == true)
        return '<h4 class="h45"><span class="label label-success">SI</span></h4>'
    else
        return '<h4 class="h45"><span class="label label-primary">No</span></h4 >'
};





function EstatusContratoCoberturaTodos(value) {
    //return (value == true ? 'TODOS' : 'N/A')
    if (value == true)
        return '<h4 class="h45"><span class="label label-success">TODOS</span></h4>'
    else
        return '<h4 class="h45"><span class="label label-warning">N/A</span></h4 >'
};




function ConvertString_ToDate(str) {
    var month = {
        "Enero":      "01",
        "Febrero":    "02",
        "Marzo":      "03",
        "Abril":      "04",
        "Mayo":       "05",
        "Junio":      "06",
        "Julio":      "07",
        "Agosto2":    "08",
        "Septiembre": "09",
        "Octubre":    "10",
        "Noviembre":  "11",
        "Diciembre":  "12"
    };

    var from = str.split("-");

    return from[2] + '-' + month[from[1]] + '-' + from[0];
};




function formatFecha (value) {
    myDate = new Date(parseInt(value.replace('/Date(', '')));

    var month = {
        "1":  "Ene",
        "2":  "Feb",
        "3":  "Mar",
        "4":  "Abr",
        "5":  "May",
        "6":  "Jun",
        "7":  "Jul",
        "8":  "Ago",
        "9":  "Sep",
        "10": "Oct",
        "11": "Nov",
        "12": "Dic"
    };
    
    return ("00" + myDate.getDate()).slice(-2) + "-" + month[myDate.getMonth() + 1] + "-" + myDate.getFullYear();
};




function getDateNow() {
    var _date = new Date();

    var month = {
        "1":  "01",
        "2":  "02",
        "3":  "03",
        "4":  "04",
        "5":  "05",
        "6":  "06",
        "7":  "07",
        "8":  "08",
        "9":  "09",
        "10": "10",
        "11": "11",
        "12": "12"
    };

    var _dateStr = _date.getDate().toString().padStart(2, '0') + '-' + month[_date.getMonth() + 1] + '-' + _date.getFullYear();

    return _dateStr;
};




function ValidaEmail(text) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    return regex.test(text);
};




function EstatusIdFormatter(value) {
    if (value == 1)
        return '<h4 class="h45"><span class="label label-success">Si</span></h4>'
    else
        return '<h4 class="h45"><span class="label label-danger">No</span></h4 >'
}; 




function ContratoCoberturaPaqueteExclusionIdFormatter(value) {
    if (value == false)
        return '<h4 class="h45"><span class="label label-success">Incluido</span></h4>'

    if (value == true)
        return '<h4 class="h45"><span class="label label-danger">Excluido</span></h4>'
};




function MembresiaPersonaEstatusIdFormatter(value) {
    if (value == 1)
        return '<input type="checkbox" name="checkbox" checked="checked" disabled="disabled" class="disabled">' //'<span class="label label-success">SI</span>'

    if (value == 2)
        return '<span class="label label-warning">NO</span>'
};




function MembresiaEstatusIdFormatter (value) {
    if (value == 1)
        return '<h4 class="h45"><span class="label label-warning">Pendiente de Pago</span></h4>'

    if (value == 2)
        return '<h4 class="h45"><span class="label label-success">Activa</span></h4>'

    if (value == 3)
        return '<h4 class="h45"><span class="label label-danger">Suspendida</span></h4>'
};




function CotizacionEstatusIdFormatter (value) {
    if (value == 1)
        return '<h4 class="h45"><span class="label label-success">Activa</span></h4>'

    if (value == 2)
        return '<h4 class="h45"><span class="label label-danger">Cancelada</span></h4>'

    if (value == 3)
        return '<h4 class="h45"><span class="label label-info">Procesada</span></h4>'
};




function VentaEstatusIdFormatter (value) {
    if (value == 1)
        return '<h4 class="h45"><span class="label label-warning">Pendiente de Pago</span></h4>'

    if (value == 2)
        return '<h4 class="h45"><span class="label label-danger">Cancelada</span></h4>'

    if (value == 3)
        return '<h4 class="h45"><span class="label label-success">Pagada</span></h4>'

    if (value == 4)
        return '<h4 class="h45"><span class="label label-info">Procesada</span></h4>'

    if (value == 5)
        return '<h4 class="h45"><span class="label label-danger">Cancelada</span></h4>'
};




function GeneroFormatter (value) {
    return (value == true ? 'Masculino' : 'Femenino')
};




function InicializarDtp(Ctrl) {

    //var today    = new Date();
    //var date     = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    //var time     = today.getHours() + ":" + today.getMinutes();
    //var dateTime = date + ' ' + time;

    $('#' + Ctrl).datepicker({
        format:         "dd-MM-yyyy",
        language:       'es',
        autoclose:      true,
        toggleActive:   true,
        showOnFocus:    true,
        todayHighlight: true,
        //minDate:   new Date(),
        //startDate: dateTime
    });

    //var items = $(".datepicker");

    //items.each(function () {
    //    //$(this).addClass('has-feedback-right').append('<span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true" style="top: 38px !important; color:#00A0E1"></span>');

    //    var item = $(this);
    //    var today = item.data("date");
    //    var minDate = item.data("min-date");
    //    var maxDate = item.data("max-date");
    //    var formatIn = item.data("format-in");
    //    var formatOut = item.data("format-out");

    //    //CJ: Con recargas parciales pierden el valor los campos que no se recargan
    //    if (item.val() != null && item.val() !== "") {
    //        var lastValue = moment(item.val(), "DD/MM/YYYY");
    //        if (lastValue.isValid())
    //            today = lastValue.format("DD/MM/YYYY");
    //    }

    //    if (formatIn !== undefined && formatOut !== undefined)
    //        today = moment(today, formatIn).format(formatOut);

    //    item.daterangepicker(common.updateConfig(today, minDate, maxDate), function (start, end, label) { });
    //});
};




function InicializarDtpClass(Ctrl) {

    //var today    = new Date();
    //var date     = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    //var time     = today.getHours() + ":" + today.getMinutes();
    //var dateTime = date + ' ' + time;

    $(Ctrl).datepicker({
        format: "yyyy-MM-dd",
        //language: '',
        //autoclose: true,
        //minDate:   new Date(),
        //startDate: dateTime
    });

    //var items = $(".datepicker");

    //items.each(function () {
    //    //$(this).addClass('has-feedback-right').append('<span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true" style="top: 38px !important; color:#00A0E1"></span>');

    //    var item = $(this);
    //    var today = item.data("date");
    //    var minDate = item.data("min-date");
    //    var maxDate = item.data("max-date");
    //    var formatIn = item.data("format-in");
    //    var formatOut = item.data("format-out");

    //    //CJ: Con recargas parciales pierden el valor los campos que no se recargan
    //    if (item.val() != null && item.val() !== "") {
    //        var lastValue = moment(item.val(), "DD/MM/YYYY");
    //        if (lastValue.isValid())
    //            today = lastValue.format("DD/MM/YYYY");
    //    }

    //    if (formatIn !== undefined && formatOut !== undefined)
    //        today = moment(today, formatIn).format(formatOut);

    //    item.daterangepicker(common.updateConfig(today, minDate, maxDate), function (start, end, label) { });
    //});
};




function DisabledEneableElement (elementId, isDisabled) {
    if (isDisabled)
        $('#' + elementId).prop('disabled', true);
    else
        $('#' + elementId).removeProp('disabled');
};




function DisabledEneableElementCheck(elementId, isDisabled) {
    if (isDisabled)
        $(elementId).iCheck('disable');
    else
        $(elementId).iCheck('enable');
};




//common.ResetCombo = function (elementId) {
//    $('#' + elementId).val(null).trigger('change');
//};

//common.GetJsonStringfy = function (data) {
//    return JSON.stringify(data);
//};

//common.DisabledEneableElement = function (elementId, isDisabled) {
//    if (isDisabled)
//        $('#' + elementId).prop('disabled', false);
//    else
//        $('#' + elementId).removeProp('disabled');
//};

//common.NumericField = function (elementId, isDecimalFlag) {
//    if (isDecimalFlag) {
//        $('#' + elementId).on("keypress keyup blur", function (event) {
//            $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
//            if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
//                event.preventDefault();
//            }
//        });
//    }
//    else {
//        $('#' + elementId).on("keypress keyup blur", function (event) {
//            $(this).val($(this).val().replace(/[^\d].+/, ""));
//            if ((event.which < 48 || event.which > 57)) {
//                event.preventDefault();
//            }
//        });
//    }
//}



//common.setRangoDatePicker = function (txtFechaId, minDate, maxDate) {
//    //Funcion para establecer rango de fechas minimo y máximo a un campo de texto selector de fechas (datepicker)
//    $('#' + txtFechaId).data('min-date', minDate);
//    $('#' + txtFechaId).data('max-date', maxDate);
//};

//common.setDateToPicker = function (txtFechaId) {
//    var txtId = '#' + txtFechaId;
//    var fecha = new Date($(txtId).val());

//    $(txtId).val(fecha);
//};