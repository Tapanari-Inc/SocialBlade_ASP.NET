﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialBlade.Utilities;

namespace SocialBlade.Models.PostViewModels
{
    public class CommentViewModel
    {
        public CommentViewModel()
        {
            
        }

        public CommentViewModel(Comment comment)
        {
            Id = comment.ID;
            AuthorFullName = $"{comment.Author.FirstName} {comment.Author.LastName}";
            AuthorProfilePictureUrl = HelperClass.GetPostImagePath( comment.Author.ProfilePictureUrl,HelperClass.PROFILE_IMAGES_PATH);
            AuthorId = comment.Author.Id;
            Content = comment.Content;
            Likes = comment.Likes;
            Dislikes = comment.Dislikes;
            ParentCommentId = comment.ParentComment?.ID;
            RepliesCount = comment.Replies?.Count??0;
            CreateTime = comment.DateCreated;

        }
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string AuthorId { get; set; }
        public string AuthorProfilePictureUrl{ get; set; }
        public string AuthorFullName { get; set; }
        public Guid? ParentCommentId { get; set; }
        public int RepliesCount { get; set; }
        public List<Comment> Replies { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
