using LaptopForge.Data;
using LaptopForge.Data.Common.Repositories;
using LaptopForge.Data.Models.Models;
using LaptopForge.Services.Data.IServices;
using LaptopForge.Web.ViewModels.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LaptopForge.Services.Data.Tests
{
    public class PostServiceTests
    {

        [Fact]
        public async Task GetPostCountShouldReturnCorrectCount()
        {
            var list = new List<Post>();
            var mockrepo = new Mock<DeletableEntityRepository<Post>>();
            mockrepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockrepo.Setup(x => x.AddAsync(It.IsAny<Post>()))
                .Callback((Post post) => list.Add(post));
            var service = new CreatePost(mockrepo.Object);
            await service.GetPost(new CreatePostViewModel());
            
            Assert.Equal(1, list.Count);
        } 

        [Fact]
        public async Task GetPostCountShouldReturnWrongCount()
        {
            var list = new List<Post>();
            var mockrepo = new Mock<DeletableEntityRepository<Post>>();
            mockrepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockrepo.Setup(x => x.AddAsync(It.IsAny<Post>()))
                .Callback((Post post) => list.Add(post));
            var service = new CreatePost(mockrepo.Object);
            await service.GetPost(new CreatePostViewModel());

            Assert.NotEqual(2, list.Count);
        }
    }
}
