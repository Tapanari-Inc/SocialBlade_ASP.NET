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

$('#modal1').openModal();

$(document).ready(function () {
    $('.modal-trigger').leanModal();
});

$(document).ready(function () {
    $('.modal').modal();
});

$('.burger').click(function(){
  $('.burger-container').toggleClass('open');
  $('.menu').toggleClass('show');
});


$('.addImg').click(function(){
  $(this).hide();
  $('.fileIn').show();
});
