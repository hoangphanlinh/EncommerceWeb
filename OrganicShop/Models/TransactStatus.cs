using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Models
{
    public class TransactStatus
    {
        [Key]
        public int TransactStatusID { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
    }
}
