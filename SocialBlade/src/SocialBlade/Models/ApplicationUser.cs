using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SocialBlade.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public virtual string FirstName { get; set; }
        [Required]
        public virtual string LastName { get; set; }
        public virtual List<User_Group> Groups { get; set; }
        public virtual List<ApplicationUser> Following { get; set; }
        public virtual List<ApplicationUser> Followers { get; set; }
    }
}
