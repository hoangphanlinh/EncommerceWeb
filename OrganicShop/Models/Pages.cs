using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Models
{
    public class Pages
    {
        [Key]
        public int PageID { get; set; }
        [Required]
        public string? PageName { get; set; }
        [Required]
        public string? Contents { get; set; }
        [Required]
        public string? Thumb { get; set; }
        [Required]
        public bool Published { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? MetaDesc { get; set; }
        [Required]
        public string? MetaKey { get; set; }
        [Required]
        public string? Alias { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public int? Ordering { get; set; }
    }
}
