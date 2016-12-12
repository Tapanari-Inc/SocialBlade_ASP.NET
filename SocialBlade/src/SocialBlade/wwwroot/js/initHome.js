$('.burger').click(function(){
  $('.burger-container').toggleClass('open');
  $('.menu').toggleClass('show');
});

$('.like-btn').click(function(){
  $(this).toggleClass('liked');
});


$('.like').click(function(){
  if($(this).hasClass('clicked')){
    $(this).removeClass('clicked');
  } else{
    $('.dislike').removeClass('clicked');
    $(this).addClass('clicked');
  }
});

$('.dislike').click(function(){
  if($(this).hasClass('clicked')){
    $(this).removeClass('clicked');
  } else{
    $('.like').removeClass('clicked');
    $(this).addClass('clicked');
  }
});


//Scroll thing
var mywindow = $(window);
var mypos = mywindow.scrollTop();
mywindow.scroll(function() {
  if(mywindow.scrollTop() > mypos)
  {
    $('.menuSmall').removeClass('nav-down');
  }
  else
  {
    $('.menuSmall').addClass('nav-down');
  }
  mypos = mywindow.scrollTop();
});
