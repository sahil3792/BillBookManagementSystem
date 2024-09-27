$(document).ready(function () {
    $('input[name="GSTRegistered"]').change(function () {
        if ($(this).val() == 'true') {
            $('#gstNumberField').show();
        } else {
            $('#gstNumberField').hide();
        }
    });
});