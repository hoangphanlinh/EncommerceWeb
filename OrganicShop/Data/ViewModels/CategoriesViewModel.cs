namespace OrganicShop.Data.ViewModels
{
    //Admin//
    public class UpdateCategoriesViewModel
    {
        public int CatID { get; set; }
        public string? CatName { get; set; }
        public string? Description { get; set; }
        public int? ParentID { get; set; }
        public int? Levels { get; set; }
        public int? Ordering { get; set; }
        public bool Published { get; set; }
        public string? Thumb { get; set; }
        public string? Title { get; set; }
        public string? Alias { get; set; }
        public string? MetaDesc { get; set; }
        public string? MetaKey { get; set; }
        public string? Cover { get; set; }
        public string? SchemeMarkup { get; set; }
    }
    //User//
   
}
