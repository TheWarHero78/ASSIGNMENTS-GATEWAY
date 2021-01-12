
$.validator.unobtrusive.adapters.addSingleVal("maxwords", "wordcount");
$.validator.unobtrusive.adapters.add('filetype', ['validtypes'], function (options) {
    options.rules['filetype'] = { validtypes: options.params.validtypes.split(',') };
    options.messages['filetype'] = options.message;
});
$.validator.unobtrusive.adapters.addSingleVal("daterange", "value");
$.validator.addMethod("maxwords", function (value, element, maxwords) {
    if (value) {

        if (value.split(' ').length > maxwords) {
            return false;
        }
    }
    return true;


});
$.validator.addMethod("filetype", function (value, element, param) {
    var extension = getFileExtension(element.files[0].name);
    console.log(element.files);
    if ($.inArray(extension, param.validtypes) === -1) {
        return false;
    }
    return true;
});

$.validator.addMethod("daterange", function (value, element, param) {
    if (value.length == 0) {
        return false;
    }
    //console.log(value);
    var dob = new Date(Date.parse(value));
    var currentDate = new Date();
    //console.log(dob+" "+currentDate);
    if (dob > currentDate || dob == 'Invalid Date') {
        return false;
    }
    return true;
});

function getFileExtension(fileName) {
    if (/[.]/.exec(fileName)) {
        return /[^.]+$/.exec(fileName)[0].toLowerCase();
    }
    return null;
}