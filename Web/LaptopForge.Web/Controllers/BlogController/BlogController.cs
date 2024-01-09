using Microsoft.AspNetCore.Mvc;

namespace LaptopForge.Web.Controllers.BlogController
{
    public class BlogController : Controller
    {
        public IActionResult Blog()
        {
            return this.View();
        }
    }
}
