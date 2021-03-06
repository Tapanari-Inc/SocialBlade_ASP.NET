﻿using Microsoft.AspNetCore.Http;
using SocialBlade.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Models.PostViewModels
{
    public class EditPostViewModel
    {
        public EditPostViewModel(Post post)
        {
            Content = post.Content;
            ID = post.ID;
        }
        public EditPostViewModel() { }
        public Guid ID { get; set; }
        [Required]
        public string Content { get; set; }

        [DataType(DataType.Upload)]
        [Utilities.FileExtensions("jpeg,png,jpg,gif", "This file type is not allowed!")]
        public IFormFile Image { get; set ; }

        public string ImageUrl { get; set; }
    }
}
