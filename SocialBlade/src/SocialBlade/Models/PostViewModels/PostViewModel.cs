using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models.PostViewModels
{
    public class PostViewModel:ShortPostViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
    }
}
