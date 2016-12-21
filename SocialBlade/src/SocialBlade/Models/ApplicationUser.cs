using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SocialBlade.Utilities;

namespace SocialBlade.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public virtual string FirstName { get; set; }
        [Required]
        public virtual string LastName { get; set; }

        public string ProfilePictureUrl { get; set; } = HelperClass.GetDefaultProfilePictureUrl();
            //"http://orig13.deviantart.net/10e3/f/2013/114/8/4/facebook_default_profile_picture___clone_trooper_by_captaintom-d62v2dr.jpg";
        public virtual List<User_Group> Groups { get; set; }

        public virtual List<User_Like> Likes { get; set; }
        public virtual List<User_Dislike> Dislikes { get; set; }

        public virtual List<UserRelation> Following { get; set; }
        public virtual List<UserRelation> Followers { get; set; }
    }
}
