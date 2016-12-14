using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialBlade.Models
{
    public class Post : EntityBase
    {
        [Required]
        public virtual string Content { get; set; }
        [NotMapped]
        public virtual int Likes => LikedBy.Count;
        [NotMapped]
        public virtual int Dislikes => DislikedBy.Count;
        public virtual List<ApplicationUser> LikedBy { get; set; }
        public virtual List<ApplicationUser> DislikedBy { get; set; }
        [Required]
        public virtual ApplicationUser Author { get; set; }
    }
}
