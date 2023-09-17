using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Models
{
    public class Attributes
    {
        [Key]
        public int AttributeID { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
