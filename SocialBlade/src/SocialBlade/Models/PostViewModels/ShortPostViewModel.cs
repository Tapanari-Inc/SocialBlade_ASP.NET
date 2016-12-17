using Microsoft.AspNetCore.Mvc;
using SocialBlade.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models.PostViewModels
{
    public class ShortPostViewModel
    {

        public ShortPostViewModel()
        {

        }
        public ShortPostViewModel(Post post)
        {
            ID = post.ID;
            Content = post.Content;
            Likes = post.Likes;
            Dislikes = post.Dislikes;
            CommentsCount = 0;
            AuthorId = post.Author.Id;
            CreateTime = post.DateCreated;
            ImageUrl = post.ImageUrl;
        }

        public Guid ID { get; set; }
        [Required]
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int CommentsCount { get; set; }
        public string AuthorId { get; set; }
        public DateTime  CreateTime { get; set; }
        public string ImageUrl { get; set; }
        public bool? Reaction { get; set; }
    }
}
