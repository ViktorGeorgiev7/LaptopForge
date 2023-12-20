using LaptopForge.Services.Data.IServices;
using LaptopForge.Web.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                return this.View();
            }
            this.createLaptop.GetLaptop(model);
            // TODO: redirect to the added laptop`s page
            return this.Redirect("/");
        }

    }
}
