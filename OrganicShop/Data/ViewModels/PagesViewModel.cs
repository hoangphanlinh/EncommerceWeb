namespace OrganicShop.Data.ViewModels
{
    public class PagesViewModel
    {
        public class UpdatePageViewModel
        {
            public int PageID { get; set; }
            public string? PageName { get; set; }
            public string? Contents { get; set; }
            public string? Thumb { get; set; }
            public bool Published { get; set; }
            public string? Title { get; set; }
            public string? MetaDesc { get; set; }
            public string? MetaKey { get; set; }
            public string? Alias { get; set; }
            public DateTime? CreatedDate { get; set; } = DateTime.Now;
            public int? Ordering { get; set; }
        }
    }
}
