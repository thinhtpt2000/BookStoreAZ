$(document).ready(function () {
    $('#add-more-category').on('click', function (event) {
        event.preventDefault();
        $('#form-category-modal').modal('show');
    });

    $('#add-more-author').on('click', function (event) {
        event.preventDefault();
        $('#form-author-modal').modal('show');
    });

    $('#category-form').on('submit', function (event) {
        event.preventDefault();
        let dataString = new FormData($('#category-form').get(0));
        let contentType = false;
        let processData = false;
        let action = $('#category-form').attr("action");
        $.ajax({
            type: "POST",
            url: action,
            data: dataString,
            dataType: "json",
            contentType: contentType,
            processData: processData,
            success: function (result) {
                onAddCategorySucess(result);
            },
            error: function (jqXHR, textStatus, errorThrown) { 
                alert("An error occurs while inserting new category");
            }
        });
    });

    $('#clear-dob').on('click', function (event) {
        event.preventDefault();
        $('#Author_DateOfBirth').val('');
    });

    $('#author-form').on('submit', function (event) {
        event.preventDefault();
        let dataString = new FormData($('#author-form').get(0));
        let contentType = false;
        let processData = false;
        let action = $('#author-form').attr("action");
        $.ajax({
            type: "POST",
            url: action,
            data: dataString,
            dataType: "json",
            contentType: contentType,
            processData: processData,
            success: function (result) {
                onAddAuthorSucess(result);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("An error occurs while inserting new author");
            }
        });
    });
});

let onAddCategorySucess = function (result) {
    if (result.EnableError) {
        alert(result.ErrorMsg);
    } else if (result.EnableSuccess) {
        let option = new Option(result.Name, result.ID);
        $('#Book_CategoryID').append(option);
        $('#Book_CategoryID').val(result.ID);
        $('#form-category-modal').modal('hide');
    }
}
let onAddAuthorSucess = function (result) {
    if (result.EnableError) {
        alert(result.ErrorMsg);
    } else if (result.EnableSuccess) {
        let option = new Option(result.Name, result.ID);
        $('#Book_AuthorID').append(option);
        $('#Book_AuthorID').val(result.ID);
        $('#form-author-modal').modal('hide');
    }
}