Globalize.culture('es');

$.validator.methods.number = function (value, element) {
    var esOpcional = this.optional(element);
    var globalizado = Globalize.parseFloat(value);
    var esNumerico = $.isNumeric(globalizado);

    return esOpcional || esNumerico;

    // return this.optional(element) || jQuery.isNumeric(Globalize.parseFloat(value));
};

//$.validator.methods.date = function (value, element) {
//    return (this.optional(element) || Globalize.parseDate(value));
//};

$.validator.methods.range = function (value, element, param) {
    if ($(element).attr('data-val-date')) {
        var min = $(element).attr('data-val-range-min');
        var max = $(element).attr('data-val-range-max');
        var date = new Date(value).getTime();
        var minDate = new Date(min).getTime();
        var maxDate = new Date(max).getTime();
        return this.optional(element) || (date >= minDate && date <= maxDate);
    }
    // use the default method
    // return this.optional(element) || (value >= param[0] && value <= param[1]);
    var val = Globalize.parseFloat(value);
    return this.optional(element) || (val >= param[0] && val <= param[1]);
};
