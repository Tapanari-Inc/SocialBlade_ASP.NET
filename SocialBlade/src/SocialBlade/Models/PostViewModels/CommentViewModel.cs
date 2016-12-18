using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            AuthorProfilePictureUrl = comment.Author.ProfilePictureUrl;
            Content = comment.Content;
            Likes = comment.Likes;
            Dislikes = comment.Dislikes;
            ParentCommentId = comment.ParentComment?.ID;
            RepliesCount = comment.Replies?.Count??0;

        }
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string AuthorProfilePictureUrl{ get; set; }
        public string AuthorFullName { get; set; }
        public Guid? ParentCommentId { get; set; }
        public int RepliesCount { get; set; }
        public List<Comment> Replies { get; set; }
    }
}
