using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Models
{
    public class Categories
    {
        [Key]
        public int CatID { get; set; }
        [Required]
        public string? CatName { get; set; }
        [Required]
        public string? Description { get; set; }
        public int? ParentID { get; set; }
        public int? Levels { get; set; }
        public int? Ordering { get; set; }
        public bool Published { get; set; }
        [Required]
        public string? Thumb { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Alias { get; set; }
        [Required]
        public string? MetaDesc { get; set; }
        [Required]
        public string? MetaKey { get; set; }
        [Required]
        public string? Cover { get; set; }
        [Required]
        public string? SchemeMarkup { get; set; }
        
    }
}
