$(".write-comment").keyup(function (event) {
    let me = $(this);
    postComment(getPostId(me),
        me.val(),
        function(data) {
            //alert(data);
            $(".post-comments").append(data);
        });
});



function postComment(postId, content, onSuccess) {
    $.ajax(
    {
        type: "POST",
        url: "/Post/PostComment",
        data: { 'postId': postId, 'content': content },
        success: function (data) {
            onSuccess(data);
        },
        error: function(error) {
            //alert(error);
        }
    });
}

function getComments(postId) {
    
}
function getCommentId(refferenceNode) {
    return refferenceNode.closest(".row").find(".id").val();
}
function getPostId(refferenceNode) {
    return refferenceNode.closest(".post").find("input").val();
}
