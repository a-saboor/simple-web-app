

showPopup = (url, title) => {

    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            $("#popup-modal .modal-body").html(response);
            $("#popup-modal .modal-title").html(title);
            $("#popup-modal").modal('show');
        }
    });

}