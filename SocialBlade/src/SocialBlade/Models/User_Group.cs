using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models
{
    public class User_Group:EntityBase
    {
        [ForeignKey("User")]
        public virtual string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("Group")]
        public virtual Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
