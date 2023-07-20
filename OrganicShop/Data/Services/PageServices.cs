using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class PageServices : IPageServices
    {
        private readonly AppDBContext _context;
        public PageServices(AppDBContext context)
        {
            _context = context;
        }
        public IOrderedQueryable<Pages> GetAllPages()
        {
            var result = _context.Pages.AsNoTracking().OrderByDescending(x => x.PageID);
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
