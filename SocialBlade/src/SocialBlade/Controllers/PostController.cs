using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialBlade.Models.PostViewModels;

namespace SocialBlade.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            var posts = new List<ShortPostViewModel>
            {
                new ShortPostViewModel
                {
                    Content = "nekuf typ content",
                    Dislikes=69,
                    Likes=68,
                    CommentsCount = 19999999,
                    AuthorName = "Pesho",
                    AuthorPictureUrl = "https://scontent-frt3-1.xx.fbcdn.net/v/t1.0-9/14572841_1075302559184501_6972025272233313372_n.jpg?oh=4cca76a094121c379867a0a1d704d201&oe=58BC7252",
                    CreateTime = "V na maika ti kura chasa"
                },
                new ShortPostViewModel
                {
                    Content = "nekuf typ content 2",
                    Dislikes=69,
                    Likes=68,
                    CommentsCount = 10,
                    AuthorName = "Pesho",
                    AuthorPictureUrl = "http://kids.nationalgeographic.com/content/dam/kids/photos/animals/Mammals/H-P/pig-young-closeup.jpg.adapt.945.1.jpg",
                    CreateTime = "V na bashta ti kura chasa"
                },
                new ShortPostViewModel
                {
                    Content = "nekuf typ content 3",
                    Dislikes=69,
                    Likes=68,
                    CommentsCount = 5,
                    AuthorName = "Pesho",
                    AuthorPictureUrl = "http://kids.nationalgeographic.com/content/dam/kids/photos/animals/Mammals/H-P/pig-young-closeup.jpg.adapt.945.1.jpg",
                    CreateTime = "Tova hilqdoletie"
                },
            };
            return View(posts);
        }
    }
}