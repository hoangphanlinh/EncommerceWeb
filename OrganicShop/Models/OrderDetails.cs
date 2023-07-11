using static NuGet.Packaging.PackagingConstants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailID { get; set; }
        [ForeignKey("Orders")]
        public int? OrderID { get; set; }
        public Orders Orders { get; set; }
        [ForeignKey("Products")]
        public int? ProductID { get; set; }
        public Products Products { get; set; }
        public int? OrderNumber { get; set; }
        public int? Quantity { get; set; }
        public int? Discount { get; set; }
        public int? Total { get; set; }
        public DateTime? ShipDate { get; set; }
        [ForeignKey("Shippers")]
        public int? ShipperID { get; set; }
        public Shippers Shippers { get; set; }
    }
}
