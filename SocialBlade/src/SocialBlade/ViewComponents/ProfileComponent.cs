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
using Microsoft.AspNetCore.Authorization;

namespace SocialBlade.ViewComponents
{
    [Authorize]
    [ViewComponent(Name = "ProfileComponent")]
    public class ProfileComponent : ViewComponent
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ApplicationDbContext Db { get; set; }
        public ProfileComponent( UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext dbContext )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Db = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync(string viewName, string userId = null)
        {
            ApplicationUser user;
            if (string.IsNullOrEmpty(userId))
            {
                user = (await _userManager.GetUserAsync(HttpContext.User));
            }
            else
            {
                user = Db.Users.Single(x => x.Id == userId);
            }
            ProfileViewModel model = null;
            if (user == null)
            {
                await _signInManager.SignOutAsync();
            }
            else
            {
                model = new ProfileViewModel(user);
                int followers = Db.UserRelations.Count(x => x.Followee.Id == user.Id) - 1;
                model.FollowersCount = string.Format($"{followers.Format()} followers");
            }
            return View(viewName,model);
        }
    }
}
