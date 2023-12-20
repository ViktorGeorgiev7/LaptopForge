namespace LaptopForge.Services.Data.IServices
{
    using LaptopForge.Data.Models.Models;
    using LaptopForge.Web.ViewModels.ViewModels;
	using System.Threading.Tasks;

    public interface ICreateLaptop
    {
		Task GetLaptop(CreateLaptopInputModel model);
    }
}
