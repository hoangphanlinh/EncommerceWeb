using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Models
{
    public class AttributesPrices
    {
        [Key]
        public int AttributesPriceID { get; set; }
        [ForeignKey("Attributes")]
        public int? AttributeID { get; set; }
        public Attributes? Attributes { get; set; }
        [ForeignKey("Products")]
        public int? ProductID { get; set; }
        public Products? Products { get; set; }
        [Required]
        public int? Price { get; set; }
        public bool Active { get; set; }
    }
}
