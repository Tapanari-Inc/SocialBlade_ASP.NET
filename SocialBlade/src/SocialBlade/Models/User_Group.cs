using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models
{
    public class User_Group:EntityBase
    {
        public virtual ApplicationUser User { get; set; }
        public virtual Group Group { get; set; }
    }
}
