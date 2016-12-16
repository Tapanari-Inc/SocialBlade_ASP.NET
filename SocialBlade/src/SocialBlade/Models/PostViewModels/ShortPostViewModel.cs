using Microsoft.AspNetCore.Mvc;
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
            Dislikes = post.Dislikes;
            Likes = post.Likes;
            CommentsCount = 19999999;
            AuthorName = post.Author.FirstName + " " + post.Author.LastName;
            AuthorPictureUrl = post.Author.ProfilePictureUrl;
            CreateTime = post.DateCreated;
            ImageUrl = post.ImageUrl;
        }

        public Guid ID { get; set; }
        [Required]
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int CommentsCount { get; set; }
        public string AuthorPictureUrl { get; set; }
        public string AuthorName { get; set; }
        public DateTime  CreateTime { get; set; }
        public string ImageUrl { get; set; }
        public bool? Reaction { get; set; }
    }
}
