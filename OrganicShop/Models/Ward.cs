using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Models
{
    public class Ward
    {
        [Key]
        public int WardId { get; set; }
        public string? WardName { get; set; }
        [ForeignKey("district")]
        public int? DistrictId { get; set; }
        public District? district { get; set; }
    }
}
