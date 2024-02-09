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
        private readonly ApplicationDbContext db;

        public HomeController(ICreateLaptop createLaptop,ApplicationDbContext db)
        {
            this.createLaptop = createLaptop;
            this.db = db;
        }

        public IActionResult Index()
        {
            var laptops = this.createLaptop.GetLaptopsForCarousel();
            return this.View(laptops);
        }

        //IMPORTANT:
        //Uncomment code in privacy if you want to upload records to your database
        //Steps
        //1. Add migration with following command: dotnet ef migrations add 'name of migration'
        //2. Uncomment code in privacy and and set the paths correctly
        //3. Run app and press on Privacy Policy in footer ONCE
        //4. Close app and commment or delete the code in privacy except return this.View(); ofcourse
        //5. Enjoy 101 laptop records and 4 blog records
        public IActionResult Privacy()
        {
            //string jsonPath = @"C:\Users\35988\Desktop\LaptopForge\Web\LaptopForge.Web\wwwroot\Laptops.json";
            //StreamReader reader = new StreamReader(jsonPath);
            //string json = reader.ReadToEnd();
            //var laptops = JsonConvert.DeserializeObject<HashSet<Laptop>>(json);
            //var dbLaptops = this.db.Laptops;
            //dbLaptops.AddRange(laptops);
            //this.db.SaveChanges();
            //string jsonPath = @"C:\Users\35988\Desktop\LaptopForge\Web\LaptopForge.Web\wwwroot\Posts.json";
            //StreamReader reader = new StreamReader(jsonPath);
            //string json = reader.ReadToEnd();
            //var posts = JsonConvert.DeserializeObject<HashSet<Post>>(json);
            //var dbPosts = this.db.Posts;
            //dbPosts.AddRange(posts);
            //this.db.SaveChanges();
            return this.View();
        }

        public IActionResult ContactUs()
        {
            return this.View();
        }

        public IActionResult AboutUs()
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
