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
                Title = model.Title,
                Content = model.Content,
                ImageUrl = model.ImageUrl,
                VideoUrl = model.VideoUrl,
                Comments = [.. model.Comments],
            };
            return viewModel;
        }

    }
}
