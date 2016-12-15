using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models
{
    public class User_Like:EntityBase
    {
        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}
