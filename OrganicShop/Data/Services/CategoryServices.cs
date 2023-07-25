using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.ViewModels;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly AppDBContext _context;
        public CategoryServices(AppDBContext context) {  _context = context; }

        public void Add(Categories categories)
        {
            _context.Categories.Add(categories);
            _context.SaveChanges();
        }

        public Categories Detail(int id)
        {
            var category = _context.Categories.FirstOrDefault(x=>x.CatID == id);
            if (category == null)
            {
                return NotFound();
            }
           return category;
            
        }

        private Categories NotFound()
        {
            throw new NotImplementedException();
        }

        public void Edit(UpdateCategoriesViewModel category)
        {
            var model = Detail(category.CatID);
            if(model != null)
            {
                model.CatID = category.CatID;
                model.CatName = category.CatName;
                model.Description = category.Description;
                model.ParentID = category.ParentID;
                model.Levels = category.Levels;
                model.Ordering = category.Ordering;
                model.Published = category.Published;
                model.Thumb = category.Thumb;
                model.Title = category.Title;
                model.Alias = category.Alias;
                model.MetaDesc = category.MetaDesc;
                model.MetaKey   = category.MetaKey;
                model.Cover = category.Cover;
                model.SchemeMarkup = category.SchemeMarkup;
            }
            _context.SaveChanges();
        }

        public IOrderedQueryable<Categories> GetAllCategories()
        {
            var result = _context.Categories.AsNoTracking().OrderByDescending(x => x.CatID);
            return result;
        }

        public List<SelectListItem> GetPublished()
        {
            List<SelectListItem> Status = new()
            {
                new SelectListItem { Value = "True", Text = "Active" },
                new SelectListItem { Value = "False", Text = "Disable" }
            };
            return Status;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IOrderedQueryable<Categories> SearchCategory(string searchString)
        {
          var result = from category in _context.Categories select category;
            if(!String.IsNullOrEmpty(searchString) )
            {
                result = result.Where(x => x.CatName.Contains(searchString));
            }
            return (IOrderedQueryable<Categories>)result;
        }
    }
}
