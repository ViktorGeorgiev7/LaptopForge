namespace LaptopForge.Services.Data.IServices
{
	using AutoMapper;
	using LaptopForge.Data.Common.Repositories;
	using LaptopForge.Data.Models.Models;
    using LaptopForge.Web.ViewModels.ViewModels;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateLaptop : ICreateLaptop
    {
		private readonly IDeletableEntityRepository<Laptop> laptops;

		public CreateLaptop(IDeletableEntityRepository<Laptop> laptops)
        {
			this.laptops = laptops;
		}

		public async Task GetLaptop(CreateLaptopInputModel model)
        {
			Laptop laptop = new Laptop()
            {
                Category = model.Category.ToString(),
                CPU = model.CPU,
                GPU = model.GPU,
                Manufacturer = model.Manufacturer.ToString(),
                ModelName = model.ModelName,
                OperatingSystem = model.OperatingSystem,
                OperatingSystemVersion = model.OperatingSystemVersion,
                Screen = model.Screen,
                ScreenSize = model.ScreenSize,
                Ram = model.Ram,
                Storage = model.Storage,
                ImageUrl = model.ImageUrl,
                Weight = model.Weight,
                Price = model.Price,
            };
            await this.laptops.AddAsync(laptop);
            await this.laptops.SaveChangesAsync();
        }

        public DisplayLaptopViewModel LaptopToViewModel(int id)
        {
            var model = this.laptops.All().Where(x => x.Id == id).FirstOrDefault();
            var viewModel = new DisplayLaptopViewModel() {
                Category = model.Category.ToString(),
                CPU = model.CPU,
                GPU = model.GPU,
                Manufacturer = model.Manufacturer.ToString(),
                ModelName = model.ModelName,
                OperatingSystem = model.OperatingSystem,
                OperatingSystemVersion = model.OperatingSystemVersion,
                Screen = model.Screen,
                ScreenSize = model.ScreenSize,
                Ram = model.Ram,
                Storage = model.Storage,
                ImageUrl = model.ImageUrl,
                Weight = model.Weight,
                Price = model.Price,
            };
            return viewModel;
        }
    }
}
