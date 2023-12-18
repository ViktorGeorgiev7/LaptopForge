namespace LaptopForge.Web.Areas.Administration.Controllers
{
    using LaptopForge.Services.Data;
    using LaptopForge.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;

        public DashboardController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
