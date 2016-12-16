using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models
{
    public class EntityBase
    {
        [Key]
        public virtual Guid ID { get; set; }
    }
}
