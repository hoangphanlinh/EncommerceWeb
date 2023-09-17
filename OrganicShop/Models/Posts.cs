using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Models
{
    public class Posts
    {
        [Key]
        public int PostID { get; set; }
        public string? Title { get; set; }
        public string? SContents { get; set; }
        public string? Contents { get; set; }
        public string? Thumb { get; set; }
        
        public bool Published { get; set; }
        public string? Alias { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? Author { get; set; }
        [ForeignKey("Accounts")]
        public int? AccountID { get; set; }
        public Accounts? Accounts { get; set; }
        public string? Tags { get; set; }
        [ForeignKey("NewsDirectory")]
        public int? NewDirID { get; set; }
        public NewsDirectory? NewsDirectory { get; set; }
        public bool isHot { get; set; }
        public bool isNewfeed { get; set; }
        public string? MetaDesc { get; set; }
        public string? MetaKey { get; set; }

        public int? Views { get; set; }
      
    }
}
