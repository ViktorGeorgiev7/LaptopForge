namespace LaptopForge.Services.Data.IServices
{
    using LaptopForge.Data.Common.Repositories;
    using LaptopForge.Data.Models.Models;

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

    }
}
