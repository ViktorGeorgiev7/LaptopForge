using LaptopForge.Data.Models.Models;
using LaptopForge.Services.Data.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LaptopForge.Web.Controllers.BlogController
{
    public class BlogController : Controller
    {

        public readonly ICreatePost createPost;

        public BlogController(ICreatePost createPost)
        {
            this.createPost = createPost;
        }

        public IActionResult Blog()
        {
            return this.View(this.createPost.GetPosts().AllAsNoTracking().ToList());
        }

        public ViewResult Details(int id)
        {
            var model = this.createPost.PostToViewModel(id);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult AddComment(int postId, string commentContent)
        {
            if (!string.IsNullOrEmpty(commentContent))
            {
                this.createPost.AddComment(commentContent, postId);
                return this.RedirectToAction("Details", new { id = postId });
            }
            else
            {
                this.ModelState.AddModelError("commentContent", "Comment cannot be empty.");
            }
            return this.RedirectToAction("Details", new { id = postId });
        }
    }
}
