namespace LaptopForge.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using LaptopForge.Data;
    using LaptopForge.Data.Models.Models;
    using LaptopForge.Services.Data.IServices;
    using LaptopForge.Web.ViewModels;
    using LaptopForge.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;
        private readonly ICreateLaptop createLaptop;

        public HomeController(ApplicationDbContext db, ICreateLaptop createLaptop)
        {
            this.db = db;
            this.createLaptop = createLaptop;
        }

        public IActionResult Index()
        {
            var laptops = this.createLaptop.GetLaptopsForCarousel();
            ViewBag.LaptopCount = this.db.Laptops.Count();
            ViewBag.UserCount = this.db.Users.Count();
            return this.View(laptops);
        }

        public IActionResult Privacy()
        {
            //string jsonPath = @"C:\Users\35988\Desktop\LaptopForge\Web\LaptopForge.Web\wwwroot\Laptops.json";
            //StreamReader reader = new StreamReader(jsonPath);
            //string json = reader.ReadToEnd();
            //var laptops = JsonConvert.DeserializeObject<HashSet<Laptop>>(json);
            //var dbLaptops = this.db.Laptops;
            //dbLaptops.AddRange(laptops);
            //this.db.SaveChanges();
            return this.View();
        }
        
        public IActionResult ContactUs()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
