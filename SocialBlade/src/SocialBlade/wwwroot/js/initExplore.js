$('.time').click(function () {
    if ($(this).hasClass('following')) {
        $(this).find('.unfollow').hide();
        $(this).find('.fol').show();
        $(this).attr('style', '');
        $(this).removeClass('following');
    } else {
        $(this).addClass('following');
        $(this).find('.fol').hide();
        $(this).find('.already').show();
    }
});

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
    $('.content').masonry({
        itemSelector: '.post',
        columnWidth: 420,
        gutter: 10,
        fitWidth: true,
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


$('.like').click(function () {
    if ($(this).hasClass('clicked')) {
        $(this).removeClass('clicked');
    } else {
        $('.dislike').removeClass('clicked');
        $(this).addClass('clicked');
    }
});

$('.dislike').click(function () {
    if ($(this).hasClass('clicked')) {
        $(this).removeClass('clicked');
    } else {
        $('.like').removeClass('clicked');
        $(this).addClass('clicked');
    }
});
