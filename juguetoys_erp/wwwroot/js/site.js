// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function modalLoad(id) {
    var loadingContent = '<div class="text-center"><span class="fa fa-spinner fa-spin fa-3x"></span> Cargando ...</div>';
    $('#dialog-form').modal('show');
    $('#dialog-form .modal-body').html(loadingContent);
    var url = $("#" + id).attr("data-url");
    var title = $("#" + id).attr("data-title");
    $('#dialog-form .modal-title').text(title);
    $.ajax({
        type: "GET",
        url: url,
        dataType: 'html',
        success: function (res) {
            $('#dialog-form .modal-body').html(res);

        },
        error: function (request, status, error) {
            console.log("ajax call went wrong:" + request.responseText);
        }
    });

}

function closeDialog() {
    $("#dialog-form").modal('hide');
}

function modalLoadReport(url) {
    window.open(url, 'ventana');
    return false;
}

function SweetAlertMessage(data) {
    if (data.id == 200) {
        Swal.fire({
            text: data.message,
            showDenyButton: false,
            icon: 'success',
            showCancelButton: false,
            confirmButtonText: `Aceptar`,
        }).then((result) => {
            if (result.isConfirmed) {
                location.reload();
            }
        })

    }
    else {
        Swal.fire({
            text: data.message,
            icon: 'error',
            showDenyButton: false,
            showCancelButton: false,
            confirmButtonText: `Aceptar`,
        })
    }
}

function SweetAlertMessageWithRedirect(data, url) {
    if (data.id == 200) {
        Swal.fire({
            text: data.message,
            showDenyButton: false,
            icon: 'success',
            showCancelButton: false,
            confirmButtonText: `Aceptar`,
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.replace(url);
            }
        })

    }
    else {
        Swal.fire({
            text: data.message,
            icon: 'error',
            showDenyButton: false,
            showCancelButton: false,
            confirmButtonText: `Aceptar`,
        })
    }
}