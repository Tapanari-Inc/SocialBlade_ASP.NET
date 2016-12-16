using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models
{
    public class User_Dislike:EntityBase
    {
        [Required]
        public virtual ApplicationUser User { get; set; }
        [Required]
        public virtual Post Post { get; set; }
    }
}
