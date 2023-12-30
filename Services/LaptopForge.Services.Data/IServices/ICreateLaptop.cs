namespace LaptopForge.Services.Data.IServices
{
    using LaptopForge.Data.Common.Repositories;
    using LaptopForge.Data.Models.Models;
    using LaptopForge.Web.ViewModels.ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICreateLaptop
    {
		Task GetLaptop(CreateLaptopInputModel model);

        DisplayLaptopViewModel LaptopToViewModel(int id);

        DeletableEntityRepository<Laptop> GetLaptops();

        List<Laptop> GetLaptopsForCarousel();
    }
}
