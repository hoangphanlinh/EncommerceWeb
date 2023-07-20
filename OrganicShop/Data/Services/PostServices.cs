using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class PostServices : IPostServices
    {
        private readonly AppDBContext _context;
        public PostServices(AppDBContext context)
        {
            _context = context;
        }
        public IOrderedQueryable<Posts> GetAllPost()
        {
            var result = _context.Posts.Include(x => x.Categories).Include(y=>y.Accounts).AsNoTracking().OrderByDescending(x => x.PostID);
            return result;
        }

        public List<Categories> GetCategories()
        {
            return _context.Categories.ToList();
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
