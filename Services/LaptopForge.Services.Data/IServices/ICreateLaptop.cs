namespace LaptopForge.Services.Data.IServices
{
    using LaptopForge.Data.Common.Repositories;
    using LaptopForge.Data.Models.Models;
    using LaptopForge.Web.ViewModels.ViewModels;
	using System.Threading.Tasks;

    public interface ICreateLaptop
    {
		Task GetLaptop(CreateLaptopInputModel model);

        DisplayLaptopViewModel LaptopToViewModel(int id);

        IDeletableEntityRepository<Laptop> GetLaptops();
    }
}
