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

$('.delete-category').on('click', function(e) {
    var rowId = $(this).closest('tr').attr('id');
    console.log("rowId" + rowId);
    var id = $('#rowId');
    id.innerHTML = rowId;
    
    $('#deleteModal').on('show.bs.modal', function() {        
        $('#deleteModal').find('#rowId').html(rowId);
    });
});

$('#delete-cat').on('click', function(e) {
    e.preventDefault();
    var rowId = $('#rowId')[0].innerText;
    console.log(rowId);

    $.ajax({
        url: '../../api/Categories/' + rowId,
        type: 'DELETE',
        async: true,
        success: function(data, textStatus, jqXHR) {
            window.location.reload();
        },
        error: function(jqXHR, textStatus, errorThrown) {
            alert(textStatus);
        }
    });
});

$('input[type=file]').on('change', function() {
    var reader = new FileReader();

    reader.onload = function(e) {
        var list = $('.upload-img-preview');
        for (var i = 0; i < list.length; i++) {
            list[i].src = e.target.result;
        }
    };

    reader.readAsDataURL(this.files[0]);
});

$(".edit-category").on("click", function (e) {
    var row = $(this).closest('tr');
    var rowId = row.attr('id');
    
    // assign Id label
    var id = $('#cat-id');
    id.innerHTML = rowId;
    
    var th = row.children('th');
    
    // assign Category name input
    $('#edit-cat-name')[0].value = th[1].innerText;
    
    $('#editModal').on('show.bs.modal', function () {
        $('#editModal').find('#cat-id').html(rowId);
        // assign Category img input
        var img = th[2].firstElementChild;
        console.log(img);        
        $('#edit-img-preview')[0].src = img.src;
    });

})