
$('.follow-btn').click(function () {
    let me = $(this);
    $.ajax(
        {
            type: "POST",
            url: "/Account/ToggleFollow",
            data: { 'userId': $('#ID').val() },
            success: function (data) {
                if(data.Status === '200')
                {
                    toggleFollowButton();
                    updateFollowersCount(data.FollowersCount);
                }
            }
        });
});

function toggleFollowButton()
{
    if($('.follow-btn').hasClass('following'))
    {
        $('.follow-btn').removeClass('following');
    }
    else
    {
        $('.follow-btn').addClass('following');
    }
}

function updateFollowersCount(newValue)
{
    $('#followersValue').html(newValue);
}