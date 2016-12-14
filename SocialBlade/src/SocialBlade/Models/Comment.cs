using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models
{
    public class Comment : EntityBase
    {
        [Required]
        public virtual string Content { get; set; }
        public virtual int Likes { get; set; }
        public virtual int Dislikes { get; set; }
        [Required]
        public virtual ApplicationUser Author { get; set; }
        [Required]
        public virtual Post Post { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual List<Comment> Replies { get; set; }
    }
}
