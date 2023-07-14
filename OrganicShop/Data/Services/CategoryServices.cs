using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly AppDBContext _context;
        public CategoryServices(AppDBContext context) {  _context = context; }
        public IOrderedQueryable<Categories> GetAllCategories()
        {
            var result = _context.Categories.AsNoTracking().OrderByDescending(x => x.CatID);
            return result;
        }

        public List<SelectListItem> GetPublished()
        {
            List<SelectListItem> Status = new()
            {
                new SelectListItem { Value = "1", Text = "Active" },
                new SelectListItem { Value = "0", Text = "Disable" }
            };
            return Status;
        }
    }
}
