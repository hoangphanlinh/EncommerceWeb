using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Models
{
    public class Accounts
    {
        [Key]
        public int AccountID { get; set; }
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public bool Active { get; set; }
        [Required]
        public string? FullName { get; set; }
        [ForeignKey("Roles")]
        public int? RoleID { get; set; }
        public Roles? Roles { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
