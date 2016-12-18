using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialBlade.Data;
using Microsoft.AspNetCore.Identity;
using SocialBlade.Models;
using SocialBlade.Models.PostViewModels;
using SocialBlade.Utilities;
using SocialBlade.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace SocialBlade.ViewComponents
{
    public class PostListComponent : ViewComponent
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        public PostListComponent(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id, string viewName = "Default")
        {
            id = string.IsNullOrEmpty(id) ? _userManager.GetUserId(HttpContext.User) : id;
            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                ApplicationUser currentUser = _context.Users
                    .First(x => x.UserName == User.Identity.Name);

                var posts = new List<ShortPostViewModel>();
                var dbPosts = _context.Posts
                    .Include(x => x.Author)
                    .Include(x => x.Comments)
                    .Include(x => x.LikedBy).ThenInclude(x => x.User)
                    .Include(x => x.DislikedBy).ThenInclude(x => x.User)
                    .Where(x => x.Author.Id == currentUser.Id).ToList();
                posts.AddRange(dbPosts.Select(x =>
                {

                    return new ShortPostViewModel(x)
                    {
                        Reaction = HelperClass.GetReaction(x, currentUser),
                        ImageUrl = HelperClass.GetPostImagePath(x.ImageUrl)
                    };
                }));
                return View(viewName, posts);
            }
            return View("Error", new ErrorViewModel { ErrorCode = 404 });
        }
    }
}
