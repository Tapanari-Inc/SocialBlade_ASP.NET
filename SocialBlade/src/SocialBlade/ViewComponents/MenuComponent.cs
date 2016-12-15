using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialBlade.Models;
using SocialBlade.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialBlade.Data;
using SocialBlade.Utilities;

namespace SocialBlade.ViewComponents
{
    [ViewComponent(Name = "MenuComponent")]
    public class MenuComponent : ViewComponent
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ApplicationDbContext Db { get; set; }
        public MenuComponent( UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext dbContext )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Db = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(User.Identity.IsAuthenticated)
            {
                var model = new ProfileViewModel();
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                ApplicationUser u = Db.Users.Where(x => x.Id.Equals(user.Id)).Include(x => x.RelationA).First();


                model.FullName = user.FirstName + " " + user.LastName;
                model.ProfileImageUrl = !string.IsNullOrEmpty(u.ProfilePictureUrl) ? u.ProfilePictureUrl :
                    @"http://orig13.deviantart.net/10e3/f/2013/114/8/4/facebook_default_profile_picture___clone_trooper_by_captaintom-d62v2dr.jpg";
                model.FollowersCount = string.Format($"{HelperClass.ConvertNumbers(u.RelationA.Count - 1)} followers");
                return View(model);
            }
            return null;
        }
    }
}
