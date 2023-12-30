namespace LaptopForge.Services.Data.IServices
{
	using AutoMapper;
	using LaptopForge.Data.Common.Repositories;
	using LaptopForge.Data.Models.Models;
    using LaptopForge.Data.Repositories;
    using LaptopForge.Web.ViewModels.ViewModels;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateLaptop : ICreateLaptop
    {
		private readonly DeletableEntityRepository<Laptop> laptops;

		public CreateLaptop(DeletableEntityRepository<Laptop> laptops)
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
                Id = model.Id,
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
        public DeletableEntityRepository<Laptop> GetLaptops()
        {
            return this.laptops;
        }

        public List<Laptop> GetLaptopsForCarousel()
        {//Takes laptops from db and makes a list of them filtered on day of week so every day carousel would look different
            var laptops = from s in this.laptops.All()
                          select s;
            string dayOfWeek = DateTime.UtcNow.DayOfWeek.ToString();
            switch (dayOfWeek)
            {
                case "Monday":
                    laptops = laptops.Where(x => x.Manufacturer == "Acer").Take(5);
                    break;
                case "Tuesday":
                    laptops = laptops.Where(x => x.Manufacturer == "Apple").Take(5);
                    break;
                case "Wednesday":
                    laptops = laptops.Where(x => x.Manufacturer == "Asus").Take(5);
                    break;
                case "Thursday":
                    laptops = laptops.Where(x => x.Manufacturer == "Dell").Take(5);
                    break;
                case "Friday":
                    laptops = laptops.Where(x => x.Manufacturer == "HP").Take(5);
                    break;
                case "Saturday":
                    laptops = laptops.Where(x => x.Manufacturer == "Lenovo").Take(5);
                    break;
                case "Sunday":
                    laptops = laptops.Where(x => x.Manufacturer == "Apple").Take(5);
                    break;
            }
            return laptops.ToList();
        }
    }
}
