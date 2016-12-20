$(document).ready(function () {
    $('.tooltipped').tooltip({ delay: 50 });
    $('body').css("overflow-x", "hidden");
});

$('.burger-container').click(function () {
    if ($('.overlay').hasClass("show-overlay")) {
        $('.overlay').removeClass("show-overlay").hide();
    } else {
        $('.overlay').show().addClass("show-overlay");
    }
});

$(document).ready(function () {
    $('.modal').modal();
    if ($('.follow-btn').hasClass('following')) {
        $('.fol').hide();
        $('.already').show();
    } else {
        $('.already').hide();
        $('.fol').show();
    }
});



