using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models.PostViewModels
{
    public class ShortPostViewModel
    {
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int CommentsCount { get; set; }
        public string AuthorPictureUrl { get; set; }
        public string AuthorName { get; set; }
        public string  CreateTime { get; set; }
        public string ImageUrl { get; set; }
        public bool? Reaction { get; set; }
    }
}
