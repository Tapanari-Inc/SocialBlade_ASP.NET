using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialBlade.Data;
using Microsoft.AspNetCore.Identity;
using SocialBlade.Models;
using SocialBlade.Models.PostViewModels;
using SocialBlade.Utilities;
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
        public async Task<IViewComponentResult> InvokeAsync(ListType type = ListType.Default,string userId = null)
        {
            ApplicationUser user = null;
            if (userId == null)
            {
                user = await _userManager.GetUserAsync(HttpContext.User);
            }
            else
            {
                user = _context.Users
                    .Include(x=>x.Following)
                    .ThenInclude(x=>x.Followee)
                    .SingleOrDefault(x => x.Id == userId);
                if(user==null)
                {
                    return View("Default", new List<ShortPostViewModel>());
                }
            }

            List<Post> posts  = GetList(type, user);

            var model = posts.Select(x =>
            {
                return new ShortPostViewModel(x)
                {
                    Reaction = HelperClass.GetReaction(x, user),
                    ImageUrl = HelperClass.GetPostImagePath(x.ImageUrl)
                };
            });

            return View(GetViewName(type), model);
        }

        private List<Post> GetList(ListType type, ApplicationUser user)
        {
            var postsQuery = _context.Posts
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .Include(x => x.LikedBy).ThenInclude(x => x.User)
                .Include(x => x.DislikedBy).ThenInclude(x => x.User);
            IQueryable<Post> resultQuery;
            var followingIds = user.Following.Select(y => y.Followee.Id);
            switch (type)
            {
                case ListType.UserOnly:
                    resultQuery = postsQuery.Where(x => x.Author.Id == user.Id);
                    break;
                case ListType.Explore:
                    resultQuery = postsQuery.Where(x => !followingIds.Contains(x.Author.Id));
                    break;
                default:
                    resultQuery = postsQuery.Where(x => followingIds.Contains(x.Author.Id));
                    break;
            }
            return resultQuery.ToList();
        }

        private string GetViewName(ListType type)
        {
            switch(type)
            {
                case ListType.Explore:
                case ListType.UserOnly:
                    return "Explore";
                default: return "Default";
            }
        }

        public enum ListType
        {
            Default,
            Explore,
            UserOnly
        }
    }
}
