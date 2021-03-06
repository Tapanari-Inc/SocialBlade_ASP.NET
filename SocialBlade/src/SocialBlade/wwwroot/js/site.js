﻿$(document).ready(function () {
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
    // the "href" attribute of .modal-trigger must specify the modal ID that wants to be triggered
    $('.modal').modal();
});

$(document).ready(function() {
    if ($('.follow-btn').hasClass('following')) {
        $('.fol').hide();
        $('.already').show();
    } else {
        $('.already').hide();
        $('.fol').show();
    }
});

$('.getStarted').click(function() {
    window.location.href = "Account/Register";
});

$('.login').click(function () {
    window.location.href = "Account/Login";
});


