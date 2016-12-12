$('.follow-btn').click(function(){
  if($(this).hasClass('following')){
    $('.following .already').css("display", "none");
    $('.following .fol').css("display", "block");
    $(this).removeClass('following');
  } else{
    $(this).addClass('following');
    $('.following .fol').css("display", "none");
    $('.following .already').css("display", "block");
  }
});
