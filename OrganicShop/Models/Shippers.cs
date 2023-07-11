using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Models
{
    public class Shippers
    {

        [Key]
        public int ShipperID { get; set; }
        public string? ShipperName { get; set; }
        public string? Phone { get; set; }
        public string? Company { get; set; }
        public DateTime? ShipDate { get; set; }
    }
}
