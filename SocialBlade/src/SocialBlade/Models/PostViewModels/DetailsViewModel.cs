using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialBlade.Utilities;

namespace SocialBlade.Models.PostViewModels
{
    public class DetailsViewModel
    {
        public DetailsViewModel()
        {

        }

        public DetailsViewModel( Post post, List<CommentViewModel> comments, ApplicationUser user )
        {
            Post = new ShortPostViewModel(post)
            {
                Reaction = HelperClass.GetReaction(post, user),
                ImageUrl = HelperClass.GetPostImagePath(post.ImageUrl)
            };
            Comments = comments;
        }
        public DetailsViewModel( Post post, List<Comment> comments,ApplicationUser user )
        {
            Post = new ShortPostViewModel(post)
            {
                Reaction = HelperClass.GetReaction(post, user),
                ImageUrl = HelperClass.GetPostImagePath(post.ImageUrl)
            };
            Comments = comments.Select(x => new CommentViewModel(x)).ToList();
        }

        public ApplicationUser CurrentUser { get; set; }
        public ShortPostViewModel Post { get; set; }
        public bool IsThisUserAuthor { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
