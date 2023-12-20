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
        Unknown,
        Notebook,
        Ultrabook,
        [Display(Name = "2 in 1 Convertible")]
        Convertible,
        Gaming,
        Netbook,
    }

    public enum Manufacturer
    {
        Unknown,
        Acer,
        Apple,
        Asus,
        Dell,
        HP,
        Lenovo,
        MSI,
        Microsoft,
    }


    public class CreateLaptopInputModel
    {
        [Required]
        public Manufacturer Manufacturer { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Model name")]
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
		[DisplayName("Operating System")]
		public string OperatingSystem { get; set; }

		[DisplayName("Operating System Version")]
		public double? OperatingSystemVersion { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Ram { get; set; }

        [Required]
        public string Screen { get; set; }

        [Required]
        [Range(9, 20)]
		[DisplayName("Screen Size")]

		public double ScreenSize { get; set; }

        [Required]
        public string Storage { get; set; }

        [Required]
        public string Weight { get; set; }

    }
}
