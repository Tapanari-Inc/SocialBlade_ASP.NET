//Likes
$('.like').click(function () {
    let me = $(this);
    if (me.hasClass('clicked')) {//stop liking
        updateReaction(getPostId(me),
            0,
            function (res) {
                let correspondingLikesCount = getAmount("like", me);
                incrementCount(correspondingLikesCount, -1);
                me.removeClass('clicked');
            });

    } else {//start liking and stop disliking
        updateReaction(getPostId(me),
            1,
            function (res) {
                let correspondingDislike = getCorresponding("dislike", me);

                if (correspondingDislike.hasClass('clicked')) {
                    let correspondingDisikesCount = getAmount("dislike", me);
                    incrementCount(correspondingDisikesCount, -1);
                    correspondingDislike.removeClass('clicked');
                }

                let correspondingLikesCount = getAmount("like", me);
                incrementCount(correspondingLikesCount, 1);
                me.addClass('clicked');
            });
    }

});

//Dislikes
$('.dislike').click(function () {
    let me = $(this);
    if (me.hasClass('clicked')) {//stop liking
        updateReaction(getPostId(me),
            0,
            function (res) {
                let correspondingDislikesCount = getAmount("dislike", me);
                incrementCount(correspondingDislikesCount, -1);
                me.removeClass('clicked');
            });
    } else {//start disliking and stop liking
        updateReaction(getPostId(me),
            -1,
            function (res) {
                let correspondingLike = getCorresponding("like", me);

                if (correspondingLike.hasClass('clicked')) {
                    let correspondingLikesCount = getAmount("like", me);
                    incrementCount(correspondingLikesCount, -1);
                    correspondingLike.removeClass('clicked');
                }

                let correspondingDislikesCount = getAmount("dislike", me);
                incrementCount(correspondingDislikesCount, 1);
                me.addClass('clicked');
            });
    }
});

function updateReaction(postId, reaction, onSuccess) {
    $.ajax(
    {
        type: "POST",
        url: "/Post/Reacted",
        data: { 'postId': postId, 'reaction': reaction },
        success: function (data) {
            onSuccess(data);
        },
        error: function(error) {
            //alert(error);
        }
    });
}

function getPostId(refferenceNode) {
    return refferenceNode.closest('.row').find('.id').val();
}

function getCorresponding(reaction, refferenceNode) {//implement with me
    let r;
    if (reaction === "like") {
        r = '.like';
    } else {
        r = '.dislike';
    }
    return refferenceNode.closest('.row').find(r);
}

function getAmount(reaction, refferenceNode) {
    let row = refferenceNode.closest('.row');
    let className;

    if (reaction === "like") {
        className = ".amountLike";
    } else {
        className = ".amountDislike";
    }

    let amountsParentDiv = row.find(className);
    return amountsParentDiv.find('b');
}

function incrementCount(element, incrementBy) {
    element.html(parseInt(element.text()) + incrementBy);
}