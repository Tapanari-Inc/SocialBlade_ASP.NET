using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models
{
    public class Post:EntityBase
    {
        [Required]
        public virtual string Content { get; set; }
        public virtual int Likes { get; set; }
        public virtual int Dislikes { get; set; }
        [Required]
        public virtual ApplicationUser Author { get; set; }
    }
}
