using LaptopForge.Web.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LaptopForge.Web.Controllers
{
    public class LaptopsController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateLaptopInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.View();
            }

            // TODO: create laptop using service method
            // TODO: redirect to the added laptop`s page
            return this.Redirect("/");
        }

    }
}
