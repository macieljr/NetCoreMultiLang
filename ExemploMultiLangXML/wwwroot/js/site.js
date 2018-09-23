// Write your JavaScript code.
$('#cmbMultiLang').change(function () {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: MultiLangChangeHandler,
        data: JSON.stringify($(this).val()),
        success: function (data) {
            window.location.href = window.location.href;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            
        }
    });
});