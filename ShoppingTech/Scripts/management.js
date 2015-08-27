/// <reference path="jquery-2.1.4.min.js" />


$("#addModal").submit(function (event) {
    //disable the default form submission
    event.preventDefault();

    //grab all form data  
    var form = document.getElementById('add-cat-form');
    var formData = new FormData(form);
    console.log(formData);

    console.log(formData);
    $.ajax({
        url: '../../api/Categories',
        type: 'POST',
        data: formData,
        async: true,
        cache: false,
        mimeType: "multipart/form-data",
        contentType: false,
        processData: false,
        success: function (data, textStatus, jqXHR) {
            window.location.reload();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(textStatus);
        }

    });

    return false;
});