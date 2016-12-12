using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models
{
    public class Comment : Post
    {
        [Required]
        public virtual Post Post { get; set; }
        public virtual Comment ParentComment { get; set; }
    }
}
