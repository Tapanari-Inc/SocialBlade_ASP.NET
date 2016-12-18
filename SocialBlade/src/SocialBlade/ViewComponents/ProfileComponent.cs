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
                int following = Db.UserRelations.Count(x => x.Follower.Id == user.Id) - 1;
                int postsCount = Db.Posts.Include(x => x.Author).Count(x => x.Author.Id == user.Id);
                model.FollowersCountDisplay = followers.Format();
                model.FollowingCountDisplay = following.Format();
                model.PostsCountDisplay = postsCount.Format();
                model.IsFollowed = Db.UserRelations
                    .SingleOrDefault(x => x.Followee.Id == user.Id
                    && x.Follower.Id == _userManager.GetUserId(HttpContext.User)) != null;
            }
            return View(viewName,model);
        }
    }
}
