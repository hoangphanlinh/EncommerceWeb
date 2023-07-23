using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Models
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        public string? DistrictName { get; set;}
        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City? City { get; set; }
    }
}
