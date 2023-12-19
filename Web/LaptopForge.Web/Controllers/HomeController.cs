namespace LaptopForge.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using LaptopForge.Data;
    using LaptopForge.Data.Models.Models;
    using LaptopForge.Web.ViewModels;
    using LaptopForge.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.LaptopCount = this.db.Laptops.Count();
            model.UserCount = this.db.Users.Count();
            return this.View(model);
        }

        public IActionResult Privacy()
        {
            // fix path for urself
            // string jsonPath = @"C:\Users\35988\Desktop\LaptopForge\Web\LaptopForge.Web\wwwroot\Laptops.json";
            // StreamReader reader = new StreamReader(jsonPath);
            // string json = reader.ReadToEnd();
            // var laptops = JsonConvert.DeserializeObject<HashSet<Laptop>>(json);
            // var dbLaptops = this.db.Laptops;
            // dbLaptops.AddRange(laptops);
            // this.db.SaveChanges();
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
