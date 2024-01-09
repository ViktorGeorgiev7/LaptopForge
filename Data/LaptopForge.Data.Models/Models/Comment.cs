using LaptopForge.Data.Common.Models;

namespace LaptopForge.Data.Models.Models
{
    public class Comment:BaseDeletableModel<int>
    {
        public string CContent { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}