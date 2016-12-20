
$('.follow-btn').click(function () {
    let me = $(this);
    let id = me.prev().val();
    $.ajax(
        {
            type: "POST",
            url: "/Account/ToggleFollow",
            data: { 'userId': id },
            success: function (data) {
                if (data.Status === '200') {
                    clearPosts(id);
                    console.log("called");
                }
            }
        });
});

function clearPosts(authorId) {
    let body = $("body");
    let posts = body.find(".post");
    let smallPosts = body.find(".post-small");
    console.log(authorId);
    for (let i = 0; i < posts.size() ; i++) {
        let post = posts[i];
        let id = $(post).find(".author-id").val();
        if (id) {
            if (id === authorId) {
                $(post).remove();
            }
        }
    };
    for (let i = 0; i < smallPosts.size() ; i++) {
        let smallPost = smallPosts[i];
        let id = $(smallPost).find(".author-id").val();
        if (id) {
            if (id === authorId) {
                $(smallPost).remove();
            }
        }
    };
}

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
/*let me = $(this);
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
        });*/