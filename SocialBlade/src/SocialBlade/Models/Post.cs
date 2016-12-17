using System;
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
        public virtual int Likes => LikedBy?.Count ?? 0;
        [NotMapped]
        public virtual int Dislikes => DislikedBy?.Count ?? 0;
        public virtual List<User_Like> LikedBy { get; set; }
        public virtual List<User_Dislike> DislikedBy { get; set; }
        [Required]
        public virtual ApplicationUser Author { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime DateCreated { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime DateModified { get; set; }
        public string ImageUrl { get; set; }
    }
}
