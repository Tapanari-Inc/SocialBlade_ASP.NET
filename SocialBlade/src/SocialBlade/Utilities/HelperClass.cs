using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using SocialBlade.Models;

namespace SocialBlade.Utilities
{
    public static class HelperClass
    {
        public static string GetPostImagePath( string imageFileName, string POST_IMAGES_PATH = "user_content/post_images" )
        {
            if(!string.IsNullOrEmpty(imageFileName))
                return "/" + POST_IMAGES_PATH + "/" + imageFileName;
            return string.Empty;
        }
        public static string GetAbsolutePath( string relativePath, IHostingEnvironment hostingEnvironment )
        {
            return Path.Combine(hostingEnvironment.WebRootPath, relativePath);
        }

        public static bool? GetReaction( Post post, ApplicationUser user )
        {
            if(post.LikedBy.Any(y => y.User?.Id == user.Id))
            {
                return true;
            }
            if(post.DislikedBy.Any(y => y.User?.Id == user.Id))
            {
                return false;
            }
            return null;
        }
    }
}
