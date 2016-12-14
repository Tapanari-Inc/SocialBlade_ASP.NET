using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models.PostViewModels
{
    public class PostViewModel:ShortPostViewModel
    {
        public List<Comment> Comments { get; set; }
    }
}
