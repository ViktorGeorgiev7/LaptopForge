namespace LaptopForge.Web.ViewModels.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreatePostViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 30)]
        public string Content { get; set; }

        [Required]
        [DisplayName("Image Url")]
        public string? ImageUrl { get; set; }

        [Required]
        [DisplayName("Video Url")]
        public string VideoUrl { get; set; }
    }
}
