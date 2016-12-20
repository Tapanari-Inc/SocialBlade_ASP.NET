
$('.follow-btn').click(function () {
    let me = $(this);
    let id = me.closest('.post-header').find('#ID').val();
    console.log(id);
    $.ajax(
        {
            type: "POST",
            url: "/Account/ToggleFollow",
            data: { 'userId': id },
            success: function (data) {
                if (data.Status === '200') {
                    toggleFollowButton(me);
                }
            }
        });
});


function toggleFollowButton() {
    if ($('.follow-btn').hasClass('following')) {
        $('.follow-btn').removeClass('following');
    }
    else {
        $('.follow-btn').addClass('following');
    }
}

$('.follow-btn').mouseenter(function () {
    if ($(this).hasClass('following')) {
        $(this).find('.already').hide();
        $(this).find('.unfollow').show();
        $(this).css("background", "red");
        $(this).css("color", "#eee");
    }
});

$('.follow-btn').mouseleave(function () {
    if ($(this).hasClass('following')) {
        $(this).find('.unfollow').hide();
        $(this).find('.already').show();
        $(this).css("background", "green");
    }
});
