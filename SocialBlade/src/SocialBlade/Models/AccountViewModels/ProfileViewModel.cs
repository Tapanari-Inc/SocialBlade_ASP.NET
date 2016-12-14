using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models.AccountViewModels
{
    public class ProfileViewModel
    {
        public string FullName { get; set; }
        public string ProfileImageUrl { get; set; }
        public string FollowersCount { get; set; }
    }
}
