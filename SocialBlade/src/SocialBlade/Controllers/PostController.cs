using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialBlade.Models.PostViewModels;
using SocialBlade.Data;
using SocialBlade.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace SocialBlade.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        const string POST_IMAGES_PATH = "user_content\\post_images";
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _hostingEnvironment;
        public PostController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        [Authorize]
        public IActionResult List()
        {
            var posts = new List<ShortPostViewModel>();
            var dbPosts = _context.Posts
                .Include(x => x.Author)
                .Include(x => x.LikedBy).ThenInclude(x=>x.User)
                .Include(x => x.DislikedBy).ThenInclude(x => x.User)
                .OrderByDescending(x => x.DateCreated).ToList();
            ApplicationUser user = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            posts.AddRange(dbPosts.Select(x =>
            {
                bool? r;
                if(x.LikedBy.Any(y => y.User?.Id == user.Id))
                {
                    r = true;
                }
                else if(x.DislikedBy.Any(y => y.User?.Id == user.Id))
                {
                    r = false;
                }
                else
                {
                    r = null;
                }
                return new ShortPostViewModel(x)
                {
                    Reaction = r,
                    ImageUrl = GetPostImagePath(x.ImageUrl)
                };
            }));
            return View(posts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Edit", new EditPostViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(EditPostViewModel postViewModel)
        {
            if(ModelState.IsValid)
            {
                Post post;
                bool isNew = postViewModel.ID == Guid.Empty;
                if(isNew)
                {
                    post = new Models.Post();
                }
                else
                {
                    post = _context.Posts.FirstOrDefault(x => x.ID == postViewModel.ID);
                }
                if(postViewModel.Image != null)
                post.ImageUrl = await UploadImageAsync(postViewModel.Image);
                post.Content = postViewModel.Content;
                post.Author = await _userManager.GetUserAsync(HttpContext.User);
                if(isNew)
                {
                    _context.Posts.Add(post);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View("Edit", postViewModel);
        }

        //Post: Post/Reacted
        [HttpPost]
        [Authorize]
        public string Reacted(Guid postId, int reaction)
        {
            //TODO: Check Follower-Followee rule and validate
            var user = _context
                .Users
                .Include(x => x.Likes)
                .Include(x => x.Dislikes)
                .First(x => x.UserName == User.Identity.Name);
            var post = _context
                .Posts
                .Include(x => x.DislikedBy).ThenInclude(x => x.User)
                .Include(x => x.LikedBy).ThenInclude(x=>x.User)
                .First(x => x.ID == postId);
            if(reaction == 0)
            {
                if(post.LikedBy.RemoveAll(x => x.User.Id == user.Id) == 0)
                    post.DislikedBy.RemoveAll(x => x.User.Id == user.Id);
            }
            else if(reaction == 1)
            {
                if(post.LikedBy.Any(x => x.User.Id == user.Id)) return "403";
                post.DislikedBy.RemoveAll(x => x.User.Id == user.Id);
                post.LikedBy.Add(new User_Like { Post = post, User = user });
            }
            else//reaction == -1
            {
                if (post.DislikedBy.Any(x => x.User.Id == user.Id)) return "403";
                post.LikedBy.RemoveAll(x => x.User.Id == user.Id);
                post.DislikedBy.Add(new User_Dislike { Post = post, User = user });
            }
            _context.SaveChanges();

            return "200";
        }

        private async Task<string> UploadImageAsync(IFormFile file)
        {
            Directory.CreateDirectory(GetAbsolutePath(POST_IMAGES_PATH));
            string imageFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string imagePath = Path.Combine(POST_IMAGES_PATH, imageFileName);
            string uploadPath = GetAbsolutePath(imagePath);
            using (Stream uploadStream = new FileStream(uploadPath, FileMode.Create))
                await file.CopyToAsync(uploadStream);
            return imageFileName;
        }

        private string GetPostImagePath(string imageFileName)
        {
            if(!string.IsNullOrEmpty(imageFileName))
            return "/" + POST_IMAGES_PATH + "/"+imageFileName;
            return string.Empty;
        }

        private string GetAbsolutePath(string relativePath)
        {
            return Path.Combine(_hostingEnvironment.WebRootPath, relativePath);
        }

        public IActionResult Details(Guid postId)
        {
            var post = _context.Posts
                .Include(x=>x.Author)
                .Include(x=>x.DateCreated)
                .Include(x=>x.ImageUrl)
                .Include(x=>x.LikedBy)
                .Include(x=>x.DislikedBy)
                .First(x => x.ID == postId);
            
            return View();
        }
    }
}