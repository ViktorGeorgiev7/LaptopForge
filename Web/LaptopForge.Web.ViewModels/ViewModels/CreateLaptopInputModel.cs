namespace LaptopForge.Web.ViewModels.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;
    using LaptopForge.Data.Models;
    using LaptopForge.Data.Models.Models;
    using LaptopForge.Services.Mapping;
    using LaptopForge.Web.ViewModels.Settings;

    public enum Category
    {
    }

    public class CreateLaptopInputModel
    {
        [StringLength(20, MinimumLength = 3)]
        public string Manufacturer { get; set; }

        [StringLength(50, MinimumLength = 3)]
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

    }
}
