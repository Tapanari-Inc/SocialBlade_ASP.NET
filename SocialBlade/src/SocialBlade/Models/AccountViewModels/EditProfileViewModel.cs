using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SocialBlade.Models.AccountViewModels
{
    public class EditProfileViewModel
    {

        public EditProfileViewModel()
        {
            
        }
        public EditProfileViewModel( ApplicationUser user )
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            FullName = $"{FirstName} {LastName}";
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            ProfilePictureUrl = user.ProfilePictureUrl;
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Upload)]
        [Utilities.FileExtensions("jpeg,png,jpg,gif", "This file type is not allowed!")]
        public IFormFile Image { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
