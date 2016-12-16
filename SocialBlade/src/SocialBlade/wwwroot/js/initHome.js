$('.burger').click(function(){
  $('.burger-container').toggleClass('open');
  $('.menu').toggleClass('show');
});

$('.like-btn').click(function(){
  $(this).toggleClass('liked');
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


//Likes
$('.like').click(function () {
    if ($(this).hasClass('clicked')) {
        //stop liking
        $(this).removeClass('clicked');
    } else {
        //start liking and stop disliking
        let correspondingDislike = this.parentNode.parentNode.parentNode.children[2].children[0].children[0];
        $(correspondingDislike).removeClass('clicked');
        $(this).addClass('clicked');
    }
    
});

//Dislikes
$('.dislike').click(function () {
    if ($(this).hasClass('clicked')) {
        //stop disliking
        $(this).removeClass('clicked');
    } else {
        //start disliking and stop liking
        let correspondingLike = this.parentNode.parentNode.parentNode.children[1].children[0].children[0];
        $(correspondingLike).removeClass('clicked');
        $(this).addClass('clicked');
    }
});