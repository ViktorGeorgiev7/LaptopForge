namespace LaptopForge.Data.Models.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUserLaptop
    {
        [Key]
        public int Id { get; set; }

        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
