using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Models
{
    public class Payments
    {
        [Key]
        public int PaymentID { get; set; }
        public string? Type { get; set; }
        public bool Allowed { get; set; }
    }
}
