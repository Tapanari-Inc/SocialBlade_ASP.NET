using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models.PostViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public Guid AuthorId { get; set; }
        public Guid ParentCommentId { get; set; }
        public List<Comment> Replies { get; set; }
    }
}
