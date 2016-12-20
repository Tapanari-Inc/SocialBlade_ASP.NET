
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
                }
            }
        });
});

function clearPosts(authorId) {
    let body = $("body");
    let posts = body.find(".post");
    let smallPosts = body.find(".post-small");
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