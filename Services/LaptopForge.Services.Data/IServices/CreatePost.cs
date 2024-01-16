namespace LaptopForge.Services.Data.IServices
{
    using LaptopForge.Data;
    using LaptopForge.Data.Common.Repositories;
    using LaptopForge.Data.Models.Models;
    using LaptopForge.Web.ViewModels.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreatePost : ICreatePost
    {
        private readonly DeletableEntityRepository<Post> posts;
        private readonly DeletableEntityRepository<Comment> comments;
        private readonly ApplicationDbContext context;

        public CreatePost(DeletableEntityRepository<Post> posts, DeletableEntityRepository<Comment> comments,ApplicationDbContext context)
        {
            this.posts = posts;
            this.comments = comments;
            this.context = context;
        }

        public DeletableEntityRepository<Post> GetPosts()
        {
            return this.posts;
        }

        public DisplayPostViewModel PostToViewModel(int id)
        {
            var model = this.posts.AllAsNoTracking().Include(x => x . Comments).Where(x => x.Id == id).FirstOrDefault();
            var viewModel = new DisplayPostViewModel()
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                ImageUrl = model.ImageUrl,
                VideoUrl = model.VideoUrl,
                Comments = [.. model.Comments],
            };
            return viewModel;
        }

        public async Task AddComment(string commentContent, int postId, string username)
        {
            var post = this.posts.All().Include(p => p.Comments).FirstOrDefault(x => x.Id == postId);
            int x = 0;
            username = username.Split('@')[0];
            if (post != null)
            {
                post.Comments.Add(new Comment
                {
                    CContent = commentContent,
                    Author=username,
                });
            }
        }
    }
}
