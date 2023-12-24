using LaptopForge.Data;
using LaptopForge.Services.Data.IServices;
using LaptopForge.Web.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LaptopForge.Web.Controllers
{
    public class LaptopsController : Controller
    {
        private readonly ICreateLaptop createLaptop;
        private readonly ApplicationDbContext db;

        public LaptopsController(ICreateLaptop createLaptop,ApplicationDbContext db)
        {
            this.createLaptop = createLaptop;
            this.db = db;
        }

        [Authorize]
		public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
		public IActionResult Create(CreateLaptopInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            this.createLaptop.GetLaptop(model);
            // TODO: redirect to the added laptop`s page
            return this.Redirect("/");
        }

        public IActionResult Collection()
        {
            this.ViewBag.LaptopCount = this.db.Laptops.Count();
            this.ViewBag.LaptopFrom0To500 = this.db.Laptops.Where(x => x.Price < 500).Count();
            this.ViewBag.LaptopFrom500To1000 = this.db.Laptops.Where(x => x.Price >= 500 && x.Price < 1000).Count();
            this.ViewBag.LaptopFrom1000To1500 = this.db.Laptops.Where(x => x.Price >= 1000 && x.Price < 1500).Count();
            this.ViewBag.LaptopFrom1500To2000 = this.db.Laptops.Where(x => x.Price >= 1500 && x.Price < 2000).Count();
            this.ViewBag.LaptopAbove2000 = this.db.Laptops.Where(x => x.Price > 2000).Count();
            return this.View();
        }
    }
}
