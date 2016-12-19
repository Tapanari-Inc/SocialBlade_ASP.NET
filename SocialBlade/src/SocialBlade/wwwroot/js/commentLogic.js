$(".write-comment")
    .keyup(function (event) {
        let me = $(this);
        var code = (event.keyCode ? event.keyCode : event.which);
        if (code === 13) {
            //alert("Enter");
            validateSubmitComment(getSubmitCommentDiv(me));
            event.preventDefault();
        } else {
            toggleValidationMessage(getSubmitCommentDiv(me), false);
        }
    });
$(".btnPostComment")
    .click(function (event) {
        let me = $(this);
        validateSubmitComment(getSubmitCommentDiv(me));
    });
function validateSubmitComment(submitCommentDiv) {
    if (getSubmitCommentContent(submitCommentDiv) !== "") {
        startProcedureForCommenting(submitCommentDiv);
        afterSubmitProcedure(submitCommentDiv);
    } else {
        toggleValidationMessage(submitCommentDiv, true);
    }
}
function afterSubmitProcedure(submitCommentDiv) {
    submitCommentDiv.find(".write-comment").val("");
    let comments = $(".post").find(".commentActual");
    setPostCommentsCount(comments.size());

    $("#toBottom").click();
}


function startProcedureForCommenting(commentDiv) {
    postComment(getPostId(commentDiv),
        getSubmitCommentContent(commentDiv),
        function (data) {
            getPostComments(getPostId(), function (comments) {
                $(".commentActual-wrapper").empty();
                $(".commentActual-wrapper").append(comments);
            } );
        });
}



function postComment(postId, content, onSuccess) {
    $.ajax(
    {
        type: "POST",
        url: "/Post/PostComment",
        data: { 'postId': postId, 'content': content },
        success: function (data) {
            onSuccess(data);
        },
        error: function (error) {
            //alert(error);
        }
    });
}
function getPostComments(postId,onSuccess) {
    $.ajax(
    {
        type: "GET",
        url: "/Post/GetPostComments",
        data: { 'postId': postId},
        success: function (data) {
            onSuccess(data);
        },
        error: function (error) {
            //alert(error);
        }
    });
}

function getSubmitCommentDiv(refferenceNode) {
    return refferenceNode.closest(".commentActual");
}
function getSubmitCommentContent(commentDiv) {
    return commentDiv.find(".write-comment").val();
}
function getCommentId(refferenceNode) {
    return refferenceNode.closest(".row").find(".id").val();
}
function getPostId() {
    return $(".post").find("input").val();
}

function toggleValidationMessage(commentDiv, state) {
    let validationSpan = commentDiv.find(".validationMessage");
    if (state === true) {
        if (validationSpan.hasClass("hidden")) {
            validationSpan.removeClass("hidden");
        }
    } else {
        if (!validationSpan.hasClass("hidden")) {
            validationSpan.addClass("hidden");
        }
    }
}

function setPostCommentsCount(count) {
    let postCommentsCount = $(".post").find(".amountComments").find("b");
    postCommentsCount.text(count);
}

$('a[href*="#"]:not([href="#"])').click(function () {
    if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
        var target = $(this.hash);
        target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
        if (target.length) {
            $('html, body').animate({
                scrollTop: target.offset().top
            }, 1000);
            return false;
        }
    }
});