using Microsoft.AspNetCore.Http;
using SocialBlade.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models.AccountViewModels
{
    public class EditProfileViewModel
    {
        public EditProfileViewModel(ApplicationUser user)
        {
            ID = user.Id;
            FullName = user.FirstName + " " + user.LastName;
        }
        public EditProfileViewModel() { }
        public string ID { get; set; }

        [Required]
        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
    }
}
