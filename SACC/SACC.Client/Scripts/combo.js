//combo.InitCombo = function (elementId, itemsList) {

//    var items = [];
//    $.each(itemsList, function (i, elemento) {
//        var item = {
//            id: elemento.Value,
//            text: elemento.Text
//        }
//        items.push(item);
//    });

//    var options = {
//        data: items
//    };

//    combo.ConfigureSelect2(elementId, options);
//    common.ResetCombo(elementId);
//};

//combo.ConfigureSelect2 = function (elementId, option, allowClear) {
//    $('#' + elementId).empty();
//    var placeholderCombo = sirhMessage.labels.lblSeleccionar;

//    if (allowClear == null)
//        allowClear = true;


//    var defaultOption = {
//        placeholder: placeholderCombo,
//        allowClear: allowClear,
//        language: {
//            "noResults": function () {
//                return sirhMessage.labels.lblTablaNoSeEncontraronRegistros;
//            }
//        }
//    };

//    var options = $.extend({}, defaultOption, option);

//    $('#' + elementId).select2(options);
//};