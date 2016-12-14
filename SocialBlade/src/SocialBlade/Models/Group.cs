using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialBlade.Models
{
    public class Group:EntityBase
    {
        [Required]
        public virtual string Name { get; set; }
        public virtual List<User_Group> Members { get; set; }
        public virtual List<Message> Messages { get; set; }
    }
}
