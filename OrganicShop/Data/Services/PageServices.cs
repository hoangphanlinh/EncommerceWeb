using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;
using static OrganicShop.Data.ViewModels.PagesViewModel;

namespace OrganicShop.Data.Services
{
    public class PageServices : IPageServices
    {
        private readonly AppDBContext _context;
        public PageServices(AppDBContext context)
        {
            _context = context;
        }

        public void Create(Pages page)
        {
            _context.Pages.Add(page);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var page = _context.Pages.FirstOrDefault(x=>x.PageID ==  id);
            if(page != null)
            {
                _context.Pages.Remove(page);

            }
            _context.SaveChanges();
        }

        public IOrderedQueryable<Pages> GetAllPages()
        {
            var result = _context.Pages.AsNoTracking().OrderByDescending(x => x.PageID);
            return result;
        }

        public Pages GetById(int id)
        {
            var page = _context.Pages.FirstOrDefault(c => c.PageID== id);
            return page ?? throw new NotImplementedException();
        }

        public List<SelectListItem> GetPublished()
        {
            List<SelectListItem> Status = new()
            {
                new SelectListItem { Value = "True", Text = "Public" },
                new SelectListItem { Value = "False", Text = "Non-Public" }
            };
            return Status;
        }

        public IOrderedQueryable<Pages> searchPage(string searchString)
        {
            var model = from page in _context.Pages select page;
            if(!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.PageName.Contains(searchString));
            }
            return (IOrderedQueryable<Pages>)model;
        }

        public void Update(UpdatePageViewModel page)
        {
            var model = GetById(page.PageID);
            if(model != null)
            {
                model.PageID = page.PageID;
                model.PageName = page.PageName;
                model.Contents = page.Contents;
                model.Thumb = page.Thumb;
                model.Published = page.Published;
                model.Title = page.Title;
                model.MetaDesc = page.MetaDesc;
                model.MetaKey = page.MetaKey;
                model.Alias = page.Alias;
                model.CreatedDate = DateTime.Now;
                model.Ordering = page.Ordering;
            }
            _context.SaveChanges();
        }

    }
}
