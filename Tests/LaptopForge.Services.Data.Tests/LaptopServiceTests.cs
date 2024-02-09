using LaptopForge.Data.Common.Repositories;
using LaptopForge.Data.Models;
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
    public class LaptopServiceTests
    {
        [Fact]
        public async Task GetLaptopsCountShouldReturnCorrectCount()
        {
            var list = new List<Laptop>();
            var mockrepo = new Mock<DeletableEntityRepository<Laptop>>();
            mockrepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockrepo.Setup(x => x.AddAsync(It.IsAny<Laptop>()))
                .Callback((Laptop laptop) => list.Add(laptop));

            var service = new CreateLaptop(mockrepo.Object);
            await service.GetLaptop(new CreateLaptopInputModel());
            Assert.Equal(1,list.Count);
        }

        [Fact]
        public async Task GetLaptopsCountShouldReturnWrongCount()
        {
            var list = new List<Laptop>();
            var mockrepo = new Mock<DeletableEntityRepository<Laptop>>();
            mockrepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockrepo.Setup(x => x.AddAsync(It.IsAny<Laptop>()))
                .Callback((Laptop laptop) => list.Add(laptop));

            var service = new CreateLaptop(mockrepo.Object);
            await service.GetLaptop(new CreateLaptopInputModel());
            Assert.NotEqual(2, list.Count);
        }

        [Fact]
        public async Task GetCarouselLaptopsCountShouldReturnCorrectCount()
        {
            var list = new List<Laptop>();
            var mockrepo = new Mock<DeletableEntityRepository<Laptop>>();
            mockrepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockrepo.Setup(x => x.AddAsync(It.IsAny<Laptop>()))
                .Callback((Laptop laptop) => list.Add(laptop));

            var service = new CreateLaptop(mockrepo.Object);
            await service.GetLaptop(new CreateLaptopInputModel());
            //as there are no actual brands setup in the test it should return 0 laptops from the carousel
            Assert.Equal(0, service.GetLaptopsForCarousel().Count);
        }
    }
}
