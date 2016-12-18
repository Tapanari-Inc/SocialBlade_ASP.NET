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
