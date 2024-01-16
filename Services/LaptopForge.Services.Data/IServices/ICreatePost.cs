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

    public interface ICreatePost
    {
        DeletableEntityRepository<Post> GetPosts();

        DisplayPostViewModel PostToViewModel(int id);

        public Task AddComment(string commentContent, int postId, string username);
    }
}
