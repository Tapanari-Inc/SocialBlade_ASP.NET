using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models.AccountViewModels
{
    public class ProfileViewModel
    {

        public ProfileViewModel(ApplicationUser user)
        {
            UserId = user.Id;
            FullName = user.FirstName + " " + user.LastName;
            ProfilePictureUrl = !string.IsNullOrEmpty(user.ProfilePictureUrl) ? user.ProfilePictureUrl :
                    @"http://orig13.deviantart.net/10e3/f/2013/114/8/4/facebook_default_profile_picture___clone_trooper_by_captaintom-d62v2dr.jpg";
        }

        public string UserId { get; set; }
        public string FullName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string PostsCountDisplay { get; set; }
        public string FollowersCountDisplay { get; set; }
        public string FollowingCountDisplay { get; set; }
        public bool IsFollowed { get; set; }
    }
}
