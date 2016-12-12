(function($){
  $(function(){

    $('.button-collapse').sideNav();

  }); // end of document ready
})(jQuery); // end of jQuery name space

$('#login').on('click', function(e){
  $('.login_form').delay(100).fadeIn(100);
	$('.reg_form').fadeOut(100);
	$('#register').removeClass('active');
	$(this).addClass('active');
	e.preventDefault();
});
$('#register').on('click', function(e){
  $('.reg_form').delay(100).fadeIn(100);
 	$('.login_form').fadeOut(100);
  $('#login').removeClass('active');
  $(this).addClass('active');
  e.preventDefault();
});

$(document).ready(function() {
  $('#fullpage').fullpage({
    css3: true,
    easingcss3: 'cubic-bezier(1, 0.01, 0.5, 1)',
    navigation: true
  });
});


$('.more').click(function(){
  $.fn.fullpage.moveSectionDown();
});

$('.desc').click(function(){
  $('.desch').toggleClass('show');
});
$('.ut').click(function(){
  $('.uth').toggleClass('show');
});
$('.pg').click(function(){
  $('.pgh').toggleClass('show');
});
