namespace LaptopForge.Web.ViewModels.ViewModels
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel;
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
        Notebook,
        Ultrabook,
        [Display(Name="2 in 1 Convertible")]
        Convertible,
        Gaming,
        Netbook,
    }

    public class CreateLaptopInputModel
    {
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ModelName { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string CPU { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string GPU { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string OperatingSystem { get; set; }

        public double? OperatingSystemVersion { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Ram { get; set; }

        [Required]
        public string Screen { get; set; }

        [Required]
        [Range(9,20)]
        public double ScreenSize { get; set; }

        [Required]
        public string Storage { get; set; }

        [Required]
        public string Weight { get; set; }

    }
}
