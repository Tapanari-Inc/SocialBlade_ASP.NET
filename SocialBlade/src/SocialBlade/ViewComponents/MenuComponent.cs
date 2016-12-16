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
            var model = new ProfileViewModel();
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                if (user != null)
                {
                    int followers = Db.UserRelations.Count(x => x.Followee.Id == user.Id) - 1;
                    model.FullName = user.FirstName + " " + user.LastName;
                    model.ProfileImageUrl = !string.IsNullOrEmpty(user.ProfilePictureUrl) ? user.ProfilePictureUrl :
                        @"http://orig13.deviantart.net/10e3/f/2013/114/8/4/facebook_default_profile_picture___clone_trooper_by_captaintom-d62v2dr.jpg";
                    model.FollowersCount = string.Format($"{HelperClass.ConvertNumbers(followers)} followers");
                }
            }
            return View(model);
        }
    }
}
