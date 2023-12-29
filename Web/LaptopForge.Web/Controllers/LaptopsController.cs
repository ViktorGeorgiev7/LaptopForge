using LaptopForge.Data;
using LaptopForge.Services.Data.IServices;
using LaptopForge.Web.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace LaptopForge.Web.Controllers
{
    public class LaptopsController : Controller
    {
        private readonly ICreateLaptop createLaptop;

        public LaptopsController(ICreateLaptop createLaptop)
        {
            this.createLaptop = createLaptop;
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

        public IActionResult Collection(string sortOrder,int currentPage = 1)
        {
            var laptopsDb = this.createLaptop.GetLaptops();
            var laptops = from s in laptopsDb.All()
                           select s;
            this.ViewBag.LaptopCount = laptops.Count();
            // this.ViewBag.PageSize = 25;
            // this.ViewBag.TotalPages = Math.Ceiling(laptops.Count() / 25.0);
            // laptops = laptops.Skip((currentPage - 1) * 25).Take(25);
            // this.ViewBag.currentPage = currentPage;

            this.ViewData["ManufacturerSortParm"] = string.IsNullOrEmpty(sortOrder) ? "manufacturer_desc" : "";
            this.ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";

            switch (sortOrder)
            {
                case "manufacturer_desc":
                    laptops = laptops.OrderByDescending(l => l.Manufacturer);
                    break;
                case "Price":
                    laptops = laptops.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    laptops = laptops.OrderByDescending(s => s.Price);
                    break;
                default:
                    laptops = laptops.OrderBy(l => l.Manufacturer);
                    break;
            }
            return this.View(laptops.ToList());
        }

        public ViewResult GetLaptop(int id)
        {
            var model = this.createLaptop.LaptopToViewModel(id);
            if (model == null)
            {
                //return this.RedirectToAction("Error", "Home");
            }

            return this.View(model);
        }
    }
}
