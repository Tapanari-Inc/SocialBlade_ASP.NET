using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models
{
    public class Message:EntityBase
    {
        [Required]
        public virtual string Content { get; set; }
        public virtual DateTime DateSent { get; set; }
        public virtual DateTime DateSeen { get; set; }
        [ForeignKey("Group")]
        public virtual Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
        [ForeignKey("ApplicationUser")]
        public virtual string ApplicationUserId { get; set; }
        public virtual ApplicationUser Author { get; set; }

    }
}
