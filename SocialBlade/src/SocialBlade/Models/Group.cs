using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
