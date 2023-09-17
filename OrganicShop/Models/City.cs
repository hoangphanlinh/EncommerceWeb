using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Models
{
    public class City
    {
        [Key]
        public int cityId { get; set; }
        [Required]
        public string? cityName { get; set; }

    }
}
