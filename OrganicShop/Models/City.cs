using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Models
{
    public class City
    {
        [Key]
        public int cityId { get; set; }
        public string? cityName { get; set; }

    }
}
