using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        [ForeignKey("Customers")]
        public int? CustomerID { get; set; }
        public Customers? Customers { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        [ForeignKey("Transactions")]
        public int? TransactStatusID { get; set; }
        public TransactStatus? TransactStatus { get; set; }
        public bool Deleted { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        [ForeignKey("Payments")]
        public int? PaymentID { get; set; }
        public Payments? Payments { get; set; }
        public string? Note { get; set; }
    }
}
