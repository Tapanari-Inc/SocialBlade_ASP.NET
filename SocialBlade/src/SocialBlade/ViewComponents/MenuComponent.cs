using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialBlade.Models;
using SocialBlade.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.ViewComponents
{
    [ViewComponent(Name = "MenuComponent")]
    public class MenuComponent:ViewComponent
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        public MenuComponent(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var model = new ProfileViewModel();
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                model.FullName = user.FirstName + " " + user.LastName;
                model.ProfileImageUrl = "";
                model.FollowersCount = "14M followers";
                return View(model);
            }
            return null;
        }
    }
}
