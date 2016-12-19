
$('.time').click(function () {
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


function toggleFollowButton(btn) {
    if (btn.hasClass('following')) {
        btn.find('.unfollow').hide();
        btn.find('.fol').show();
        btn.attr('style', '');
        btn.removeClass('following');
    } else {
        btn.addClass('following');
        btn.find('.fol').hide();
        btn.find('.already').show();
    }
};

$('.time').mouseenter(function () {
    if ($(this).hasClass('following')) {
        $(this).find('.already').hide();
        $(this).find('.unfollow').show();
        $(this).css("background", "red");
        $(this).css("color", "#eee");
    }
});

$('.time').mouseleave(function () {
    if ($(this).hasClass('following')) {
        $(this).find('.unfollow').hide();
        $(this).find('.already').show();
        $(this).css("background", "green");
    }
});


$(document).ready(function () {
    $('.content-ex').masonry({
        itemSelector: '.post',
        columnWidth: 420,
        gutter: 10,
        fitWidth: true
    });
});


var mywindow = $(window);
var mypos = mywindow.scrollTop();
mywindow.scroll(function () {
    if (mywindow.scrollTop() > mypos) {
        $('.menuSmall').removeClass('nav-down');
    }
    else {
        $('.menuSmall').addClass('nav-down');
    }
    mypos = mywindow.scrollTop();
});

$('.burger').click(function () {
    $('.burger-container').toggleClass('open');
    $('.menu').toggleClass('show');
});

$('.like-btn').click(function () {
    $(this).toggleClass('liked');
});
