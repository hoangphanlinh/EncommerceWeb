using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Models
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        public string? FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? Avatar { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        //[ForeignKey("Locations")]
        //public int? LocationID { get; set; }
        //public Locations? Locations { get; set; }
        [ForeignKey("district")]
        public int District { get; set; }
        public District district { get; set; }
        [ForeignKey("ward")]
        public int Ward { get; set; }
        public Ward ward { get; set; }
        [ForeignKey("city")]
        public int City { get; set; }
        public City city { get; set; } 
        public DateTime? CreatedDate { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool Active { get; set; }
    }
}
