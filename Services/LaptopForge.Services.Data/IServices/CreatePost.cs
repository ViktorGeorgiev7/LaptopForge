namespace LaptopForge.Services.Data.IServices
{
    using LaptopForge.Data.Common.Repositories;
    using LaptopForge.Data.Models.Models;
    using LaptopForge.Web.ViewModels.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreatePost : ICreatePost
    {
        private readonly DeletableEntityRepository<Post> posts;

        public CreatePost(DeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        public DeletableEntityRepository<Post> GetPosts()
        {
            return this.posts;
        }

        public DisplayPostViewModel PostToViewModel(int id)
        {
            var model = this.posts.AllAsNoTracking().Where(x => x.Id == id).FirstOrDefault();
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

        public async Task AddComment(string commentContent, int postId)
        {
            Comment newComment = new Comment
            {
                CContent = commentContent,
            };

            var post = this.posts.AllAsNoTracking().FirstOrDefault(x => x.Id == postId);
            post.Comments.Add(newComment);
            await this.posts.SaveChangesAsync();
        }
    }
}
