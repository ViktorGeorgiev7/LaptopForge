namespace LaptopForge.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LaptopForge.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post() {
        this.Comments = new HashSet<Comment>();
        }
        
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public string? ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public HashSet<Comment> Comments { get; set; }
    }
}
