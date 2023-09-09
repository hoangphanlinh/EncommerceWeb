using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Models
{
    public class NewsDirectory
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
