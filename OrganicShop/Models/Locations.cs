using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Models
{
    public class Locations
    {
        [Key]
        public int LocationID { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Slug { get; set; }
        public string? NameWithType { get; set; }
        public string? PathWithType { get; set; }
        public int? ParentCode { get; set; }
        public int? Levels { get; set; }
    }
}
