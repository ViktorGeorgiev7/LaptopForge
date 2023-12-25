using LaptopForge.Data;
using LaptopForge.Services.Data.IServices;
using LaptopForge.Web.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public IActionResult Collection(int currentPage = 1)
        {
            var laptops = this.db.Laptops.AsEnumerable();
            //-------------------------------------------------------------------------
            this.ViewBag.LaptopCount = laptops.Count();
            this.ViewBag.LaptopFrom0To500 = laptops.Where(x => x.Price < 500).Count();
            this.ViewBag.LaptopFrom500To1000 = laptops.Where(x => x.Price >= 500 && x.Price < 1000).Count();
            this.ViewBag.LaptopFrom1000To1500 = laptops.Where(x => x.Price >= 1000 && x.Price < 1500).Count();
            this.ViewBag.LaptopFrom1500To2000 = laptops.Where(x => x.Price >= 1500 && x.Price < 2000).Count();
            this.ViewBag.LaptopAbove2000 = laptops.Where(x => x.Price > 2000).Count();
            //-------------------------------------------------------------------------
            this.ViewBag.PageSize = 25;
            this.ViewBag.TotalPages = Math.Ceiling(laptops.Count() / 25.0);
            laptops = laptops.Skip((currentPage - 1) * 25).Take(25);
            this.ViewBag.Laptops = laptops;
            this.ViewBag.currentPage = currentPage;
            return this.View();
        }
    }
}
