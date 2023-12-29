using LaptopForge.Data;
using LaptopForge.Data.Models.Models;
using LaptopForge.Services.Data.IServices;
using LaptopForge.Web.HelpfulModels;
using LaptopForge.Web.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Collection(string sortOrder,string searchString,string currentFilter,int? pageNumber,int currentPage = 1)
        {
            this.ViewData["CurrentSort"] = sortOrder;
            this.ViewData["ManufacturerSortParm"] = string.IsNullOrEmpty(sortOrder) ? "manufacturer_desc" : "";
            this.ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var laptopsDb = this.createLaptop.GetLaptops();
            var laptops = from s in laptopsDb.All()
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                laptops = laptops.Where(s => s.Manufacturer.Contains(searchString)
                                       || s.ModelName.Contains(searchString));
            }
            this.ViewData["CurrentFilter"] = searchString;


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

            this.ViewBag.LaptopCount = laptops.Count();
            int pageSize = 24;
            return View(await PaginatedList<Laptop>.CreateAsync(laptops.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public ViewResult GetLaptop(int id)
        {
            var model = this.createLaptop.LaptopToViewModel(id);

            return this.View(model);
        }
    }
}
