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
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialBlade.Utilities;

namespace SocialBlade.Controllers
{
    [Authorize]
    public class PostController : Controller
    {

        const string POST_IMAGES_PATH = "user_content/post_images";
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _hostingEnvironment;
        public PostController( ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironment )
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        //Method: Route
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult List()
        {
            return View(model: _userManager.GetUserId(User));

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Edit", new EditPostViewModel());
        }

        [HttpGet]
        public IActionResult Edit( Guid id )
        {
            var post = _context.Posts
                .Include(x => x.Author)
                .SingleOrDefault(x => x.ID == id && x.Author.Id == _userManager.GetUserId(User));
            if(post == null)
            {
                return View("Error");
            }
            EditPostViewModel model = new EditPostViewModel(post);
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save( EditPostViewModel postViewModel )
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
        public string Reacted( Guid postId, int reaction )
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
                .Include(x => x.LikedBy).ThenInclude(x => x.User)
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
                if(post.DislikedBy.Any(x => x.User.Id == user.Id)) return "403";
                post.LikedBy.RemoveAll(x => x.User.Id == user.Id);
                post.DislikedBy.Add(new User_Dislike { Post = post, User = user });
            }
            _context.SaveChanges();

            return "200";
        }

        private async Task<string> UploadImageAsync( IFormFile file )
        {
            Directory.CreateDirectory(HelperClass.GetAbsolutePath(POST_IMAGES_PATH, _hostingEnvironment));
            string imageFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string imagePath = Path.Combine(POST_IMAGES_PATH, imageFileName);
            string uploadPath = HelperClass.GetAbsolutePath(imagePath, _hostingEnvironment);
            using(Stream uploadStream = new FileStream(uploadPath, FileMode.Create))
                await file.CopyToAsync(uploadStream);
            return imageFileName;
        }


        public IActionResult Details( Guid id )
        {
            if(id == Guid.Empty || !_context.Posts.Any(x => x.ID == id))
            {
                return RedirectToAction("List");
            }

            var post = _context.Posts
                .Include(x => x.Author)
                .Include(x => x.LikedBy)
                .Include(x => x.DislikedBy)
                .Include(x => x.Comments)
                .First(x => x.ID == id);

            var currentUser = _context.Users
                .First(x => x.UserName == User.Identity.Name);

            var comments = _context.Comments
                .Where(x => x.Post.ID == post.ID && x.ParentComment == null)
                .Include(x => x.Author)
                .OrderBy(x => x.DateCreated)
                .ToList();

            var detailsViewModel = new DetailsViewModel(post, comments, currentUser)
            {
                //TODO: Or Admin
                IsThisUserAuthor = currentUser.Id == post.Author.Id,
                CurrentUser = currentUser
            };

            return View(detailsViewModel);
        }

        [HttpGet]
        public IActionResult Explore()
        {
            return View();
        }

        public IActionResult Delete( Guid id )
        {
            if(id == Guid.Empty || !_context.Posts.Any(x => x.ID == id))
            {
                return RedirectToAction("List");
            }

            var currentUser = _context.Users
                .First(x => x.UserName == User.Identity.Name);

            var post = _context.Posts
                .Include(x => x.Author)
                .First(x => x.ID == id);

            if(post.Author.Id == currentUser.Id)
            {
                _context.Comments.RemoveRange(_context.Comments.Where(x => x.Post.ID == id));
                _context.Posts.Remove(post);
                _context.SaveChanges();
                return RedirectToAction("List");
            }

            return RedirectToAction("Details", new { id = id });
        }

        //POST: PostComment
        [HttpPost]
        public string PostComment( Guid postId, string content )
        {
            var currentUser = _context.Users
                .First(x => x.UserName == User.Identity.Name);

            var post = _context.Posts
                .First(x => x.ID == postId);

            var comment = new Comment
            {
                Author = currentUser,
                Content = content,
                Dislikes = 0,
                Likes = 0,
                Post = post
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
            var commentViewModel = new CommentViewModel(comment);
            return "200";
        }

        //GET: Post/GetPostComments
        [HttpGet]
        public ActionResult GetPostComments( Guid postId )
        {
            if(postId == Guid.Empty || !_context.Posts.Any(x => x.ID == postId))
            {
                return RedirectToAction("List");
            }
            var currentUser = _context.Users
                .First(x => x.UserName == User.Identity.Name);

            var post = _context.Posts
                .Include(x => x.Author)
                .First(x => x.ID == postId);

            var comments = _context.Comments
                .Include(x=>x.Author)
                .Where(x => x.Post.ID == postId && x.ParentComment == null)
                .ToList();

            var commentsViewModel = comments.Select(x => new CommentViewModel(x));


            return PartialView("CommentPartials/_MultipleComments",commentsViewModel);
        }


    }
}