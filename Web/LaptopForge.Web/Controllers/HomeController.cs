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
    using LaptopForge.Web.ViewModels.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class HomeController : BaseController
    {
        private readonly ICreateLaptop createLaptop;

        public HomeController(ICreateLaptop createLaptop)
        {
            this.createLaptop = createLaptop;
        }

        public IActionResult Index()
        {
            var laptops = this.createLaptop.GetLaptopsForCarousel();
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

        //[HttpPost]
        //public IActionResult Compare(CreateLaptopInputModel model)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.View(model);
        //    }
        //    this.createLaptop.GetLaptop(model);
        //    // TODO: redirect to the added laptop`s page
        //    return this.Redirect("/");
        //}

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
