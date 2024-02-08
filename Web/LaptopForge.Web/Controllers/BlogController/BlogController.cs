using LaptopForge.Data;
using LaptopForge.Data.Models.Models;
using LaptopForge.Services.Data.IServices;
using LaptopForge.Web.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LaptopForge.Web.Controllers.BlogController
{
    public class BlogController : Controller
    {

        public readonly ICreatePost createPost;
        private readonly ApplicationDbContext context;

        public BlogController(ICreatePost createPost, ApplicationDbContext context)
        {
            this.createPost = createPost;
            this.context = context;
        }

        public IActionResult Blog()
        {
            return this.View(this.createPost.GetPosts().AllAsNoTracking().ToList());
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreatePostViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.createPost.GetPost(model);

            return this.Redirect("/");
        }

        public ViewResult Details(int id)
        {
            var model = this.createPost.PostToViewModel(id);

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddComment(int postId, string commentContent)
        {
            if (!string.IsNullOrEmpty(commentContent))
            {
                this.createPost.AddComment(commentContent, postId,this.User.Identity.Name);
                context.SaveChanges();
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
