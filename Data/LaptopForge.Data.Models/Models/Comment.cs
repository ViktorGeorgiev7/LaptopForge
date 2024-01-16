using LaptopForge.Data.Common.Models;

namespace LaptopForge.Data.Models.Models
{
    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            Author = "Anonymous";
        }

        public string CContent { get; set; }

        public string Author { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

    }
}