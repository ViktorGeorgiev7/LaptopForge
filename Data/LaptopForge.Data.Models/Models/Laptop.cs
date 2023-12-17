namespace LaptopForge.Data.Models.Models
{
    using System.Collections.Generic;

    using LaptopForge.Data.Common.Models;

    public class Laptop : BaseDeletableModel<int>
    {
        public Laptop()
        {
            this.Users = new HashSet<ApplicationUserLaptop>();
        }

        public string Manufacturer { get; set; }

        public string ModelName { get; set; }

        public string Category { get; set; }

        public string CPU { get; set; }

        public string GPU { get; set; }

        public string ImageUrl { get; set; }

        public string OperatingSystem { get; set; }

        public double? OperatingSystemVersion { get; set; }

        public double Price { get; set; }

        public string Ram { get; set; }

        public string Screen { get; set; }

        public double ScreenSize { get; set; }

        public string Storage { get; set; }

        public string Weight { get; set; }

        public ICollection<ApplicationUserLaptop> Users { get; set; }
    }
}
