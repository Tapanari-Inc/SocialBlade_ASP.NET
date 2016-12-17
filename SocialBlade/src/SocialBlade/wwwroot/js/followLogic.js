$('.follow-btn').click(function () {
    let me = $(this);
    $.ajax(
        {
            type: "POST",
            url: "/Account/ToggleFollow",
            data: { 'userId': $('#ID').val() },
            success: function (data) {
            }
        });
});