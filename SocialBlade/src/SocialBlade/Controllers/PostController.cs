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
        public IActionResult List()
        {
            var posts = new List<ShortPostViewModel>();
            var dbPosts = _context.Posts
                .Include(x => x.Author)
                .OrderByDescending(x=>x.DateCreated).ToList();
            posts.AddRange(dbPosts.Select(x =>
                new ShortPostViewModel(x)
                {
                    ImageUrl = GetPostImagePath(x.ImageUrl)
                }));
            #region spam-data
            posts.AddRange
            (new List<ShortPostViewModel> {
                new ShortPostViewModel
                {
                    Content = "nekuf typ content",
                    Dislikes = 69,
                    Likes = 68,
                    CommentsCount = 19999999,
                    AuthorName = "Pesho",
                    AuthorPictureUrl = "https://scontent-frt3-1.xx.fbcdn.net/v/t1.0-9/14572841_1075302559184501_6972025272233313372_n.jpg?oh=4cca76a094121c379867a0a1d704d201&oe=58BC7252",
                    CreateTime = "V na maika ti kura chasa"
                },
                new ShortPostViewModel
                {
                    Content = "nekuf typ content 2",
                    Dislikes = 69,
                    Likes = 68,
                    CommentsCount = 10,
                    AuthorName = "Pesho",
                    AuthorPictureUrl = "http://kids.nationalgeographic.com/content/dam/kids/photos/animals/Mammals/H-P/pig-young-closeup.jpg.adapt.945.1.jpg",
                    CreateTime = "V na bashta ti kura chasa"
                },
                new ShortPostViewModel
                {
                    Content = "nekuf typ content 3",
                    Dislikes = 69,
                    Likes = 68,
                    CommentsCount = 5,
                    AuthorName = "Pesho",
                    AuthorPictureUrl = "http://kids.nationalgeographic.com/content/dam/kids/photos/animals/Mammals/H-P/pig-young-closeup.jpg.adapt.945.1.jpg",
                    CreateTime = "Tova hilqdoletie"
                }});
            #endregion
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
            if (ModelState.IsValid)
            {
                Post post;
                bool isNew = postViewModel.ID == Guid.Empty;
                if (isNew)
                {
                    post = new Models.Post();
                }
                else
                {
                    post = _context.Posts.FirstOrDefault(x => x.ID == postViewModel.ID);
                }
                post.ImageUrl = await UploadImageAsync(postViewModel.Image);
                post.Content = postViewModel.Content;
                post.Author = await _userManager.GetUserAsync(HttpContext.User);
                if (isNew)
                {
                    _context.Posts.Add(post);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View("Edit",postViewModel);
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
            return "/" + POST_IMAGES_PATH + "/"+imageFileName;
        }

        private string GetAbsolutePath(string relativePath)
        {
            return Path.Combine(_hostingEnvironment.WebRootPath, relativePath);
        }
    }
}