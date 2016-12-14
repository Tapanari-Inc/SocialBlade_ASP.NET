using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models
{
    public class UserRelation:EntityBase
    {
        public virtual ApplicationUser Follower { get; set; }
        public virtual ApplicationUser Followee { get; set; }
    }
}
