using System;

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
        public string ProfilePictureUrl { get; set; }
    }
}
