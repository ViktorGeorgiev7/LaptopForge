namespace LaptopForge.Web.ViewModels.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LaptopForge.Data.Models.Models;

    public class DisplayPostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public string? ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
