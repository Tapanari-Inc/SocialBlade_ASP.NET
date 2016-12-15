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
            Content = post.Content;
            Dislikes = post.Dislikes;
            Likes = post.Likes;
            CommentsCount = 19999999;
            AuthorName = post.Author.FirstName + " " + post.Author.LastName;
            AuthorPictureUrl = "https://scontent-frt3-1.xx.fbcdn.net/v/t1.0-9/14572841_1075302559184501_6972025272233313372_n.jpg?oh=4cca76a094121c379867a0a1d704d201&oe=58BC7252";
            CreateTime = post.DateCreated.ToString();
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
        public string  CreateTime { get; set; }
        public string ImageUrl { get; set; }
        public bool? Reaction { get; set; }
    }
}
