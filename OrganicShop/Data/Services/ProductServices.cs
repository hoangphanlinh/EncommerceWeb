using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class ProductServices : IProductServices
    {
        private readonly AppDBContext _context;
        public ProductServices(AppDBContext context) { 
            _context = context;
        }
        public IOrderedQueryable<Products> GetAllProduct()
        {
            var result = _context.Products.Include(x=>x.Categories).AsNoTracking().OrderByDescending(x => x.ProductID);
            return result;
        }

        public List<Categories> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public List<SelectListItem> GetStatus()
        {
            List<SelectListItem> Status = new()
            {
                new SelectListItem { Value = "1", Text = "Active" },
                new SelectListItem { Value = "0", Text = "Disable" }
            };
            return Status;
        }

        public List<SelectListItem> getStock()
        {
            List<SelectListItem> Status = new()
            {
                new SelectListItem { Value = "1", Text = "A" },
                new SelectListItem { Value = "0", Text = "Disable" }
            };
            return Status;
        }
    }
}
