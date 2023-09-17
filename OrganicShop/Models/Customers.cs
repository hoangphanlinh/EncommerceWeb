using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Models
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public DateTime? BirthDay { get; set; }
        [Required]
        public string? Avatar { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        //[ForeignKey("Locations")]
        //public int? LocationID { get; set; }
        //public Locations? Locations { get; set; }
        [Required]
        [ForeignKey("district")]
        public int District { get; set; }
        public District district { get; set; }
        [Required]
        [ForeignKey("ward")]
        public int Ward { get; set; }
        public Ward ward { get; set; }
        [Required]
        [ForeignKey("city")]
        public int City { get; set; }
        public City city { get; set; } 
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool Active { get; set; }
    }
}
