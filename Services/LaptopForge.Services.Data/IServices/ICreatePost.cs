namespace LaptopForge.Services.Data.IServices
{
    using LaptopForge.Data.Common.Repositories;
    using LaptopForge.Data.Models.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICreatePost
    {
        DeletableEntityRepository<Post> GetPosts();
    }
}
